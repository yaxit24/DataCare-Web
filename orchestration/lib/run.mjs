// The pipeline for one packet: worktree -> context pack -> worker session -> guards -> gates -> result.
import fs from 'node:fs';
import path from 'node:path';
import { checkCitationFile } from './cite.mjs';
import { compilePrompt, writeFormIndexes } from './compile.mjs';
import { runGuards } from './guards.mjs';
import { effectiveScope, parsePacket, validatePacket } from './packet.mjs';
import { DESKTOP_SRC, REPO, fill, findBash, findPython, git, launch, layout, loadConfig, loadEnvFile, nowStamp, sh } from './util.mjs';

/**
 * On Windows, package scripts run through cmd.exe, which rejects the Unix forms the repository's scripts use
 * (`NODE_OPTIONS=... tsc`). Pointing npm and pnpm at Git bash for the gates and the worker sessions makes those
 * scripts run as they do on CI, without changing the user's own npm configuration.
 */
function scriptShellEnv() {
  const bash = process.platform === 'win32' ? findBash() : null;
  return bash ? { npm_config_script_shell: bash } : {};
}

/**
 * Per-machine facts the repository cannot know, read from <root>/state/machine.json when it exists:
 * { "skipGates": ["pnpm lint", ...] } lists gate commands (matched as substrings) that misreport on this machine.
 * A skipped gate is shown as skipped, never as passed, and CI remains the judge of it.
 */
export function machineProfile() {
  try {
    return JSON.parse(fs.readFileSync(path.join(layout().stateRoot, 'machine.json'), 'utf8'));
  } catch {
    return {};
  }
}

export function providerEnv(stateRoot) {
  return loadEnvFile(path.join(stateRoot, 'providers.env'));
}

const installedCache = new Map();
export function runnerInstalled(runner) {
  if (!installedCache.has(runner.bin)) {
    const probe = process.platform === 'win32' ? sh('where', [runner.bin]) : sh('which', [runner.bin]);
    installedCache.set(runner.bin, probe.code === 0);
  }
  return installedCache.get(runner.bin);
}

/** Why a candidate cannot be used right now, or null when it is ready. */
export function candidateProblem(candidate, runners, providers, env) {
  const runner = runners[candidate.runner];
  if (!runner) return `unknown runner ${candidate.runner}`;
  if (!runnerInstalled(runner)) return `${runner.bin} is not installed`;
  if (!candidate.model && runner.modelRequired !== false) return 'no model set in routing.json';
  if (candidate.provider) {
    const provider = providers[candidate.provider];
    if (!provider) return `unknown provider ${candidate.provider}`;
    const missing = (provider.env || []).filter((k) => !env[k] && !process.env[k]);
    if (missing.length) return `missing key ${missing.join(', ')}`;
  }
  return null;
}

export function pickCandidate(tier, { runnerName, model } = {}, stateRoot) {
  const routing = loadConfig('routing.json');
  const runners = loadConfig('runners.json');
  const providers = loadConfig('providers.json').providers;
  const env = providerEnv(stateRoot);
  if (runnerName) {
    const fromTier = (routing.tiers[tier]?.candidates || []).find((c) => c.runner === runnerName) || {};
    const candidate = { ...fromTier, runner: runnerName, ...(model ? { model } : {}) };
    const problem = candidateProblem(candidate, runners, providers, env);
    if (problem) throw new Error(`runner ${runnerName}: ${problem}`);
    return candidate;
  }
  const skipped = [];
  for (const candidate of routing.tiers[tier]?.candidates || []) {
    const c = model ? { ...candidate, model } : candidate;
    const problem = candidateProblem(c, runners, providers, env);
    if (!problem) return { ...c, skipped };
    skipped.push(`${c.runner}${c.provider ? `/${c.provider}` : ''}: ${problem}`);
  }
  throw new Error(`no ready worker for tier ${tier}. ${skipped.join('; ')}. Run: node orchestration/bin/orch.mjs providers`);
}

function buildCommand(candidate, vars) {
  const runner = loadConfig('runners.json')[candidate.runner];
  const all = { ...(runner.defaults || {}), ...candidate, ...vars };
  const args = [];
  for (const a of runner.args) {
    if (Array.isArray(a)) {
      const group = a.map((x) => fill(x, all));
      if (group.every((x) => x !== '' && !/\{\w+\}/.test(x))) args.push(...group);
    } else args.push(fill(a, all));
  }
  return { bin: runner.bin, args, prompt: runner.prompt };
}

function workerEnv(candidate, stateRoot) {
  const keys = providerEnv(stateRoot);
  const provider = candidate.provider ? loadConfig('providers.json').providers[candidate.provider] : null;
  const env = { ...scriptShellEnv(), ...keys };
  for (const [name, template] of Object.entries(provider?.set || {})) env[name] = fill(template, { ...process.env, ...keys });
  return env;
}

/** `.orch/` (prompt, form indexes, worker report) is ignored in every worktree, whatever the branch contains. */
function ignoreScratch() {
  const exclude = git(['rev-parse', '--path-format=absolute', '--git-path', 'info/exclude'], REPO).out;
  const text = fs.existsSync(exclude) ? fs.readFileSync(exclude, 'utf8') : '';
  if (!/^\.orch\/$/m.test(text)) {
    fs.mkdirSync(path.dirname(exclude), { recursive: true });
    fs.appendFileSync(exclude, `${text.endsWith('\n') || !text ? '' : '\n'}.orch/\n`);
  }
}

export function worktreeFor(branch, base = 'origin/main', { fetch = true } = {}) {
  const { wtRoot } = layout();
  ignoreScratch();
  const dir = path.join(wtRoot, branch.replace(/^agent\//, '').replace(/\//g, '-'));
  if (fs.existsSync(path.join(dir, '.git'))) {
    const current = git(['rev-parse', '--abbrev-ref', 'HEAD'], dir).out;
    if (current !== branch) throw new Error(`${dir} is on ${current}, expected ${branch}`);
    return dir;
  }
  fs.mkdirSync(wtRoot, { recursive: true });
  // A full checkout is about 1-2 GB; a full disk breaks every other session's builds and databases too.
  const st = fs.statfsSync(wtRoot);
  const freeGb = (st.bavail * st.bsize) / 1024 ** 3;
  const minGb = Number(process.env.DATACARE_MIN_FREE_GB || 4);
  if (freeGb < minGb) throw new Error(`only ${freeGb.toFixed(1)} GB free at ${wtRoot} (need ${minGb}): free disk before creating a worktree`);
  if (fetch) git(['fetch', 'origin', '--prune'], REPO, { allowFail: true });
  const has = (ref) => git(['rev-parse', '--verify', '--quiet', ref], REPO, { allowFail: true }).code === 0;
  // Two runs started together race on .git/config: retry while another git holds its lock.
  const add = (pick) => {
    for (let attempt = 1; ; attempt++) {
      const args = pick();
      const r = git(['worktree', 'add', ...args], REPO, { allowFail: true });
      if (r.code === 0) return;
      if (attempt >= 6 || !/could not lock|\.lock': File exists|unable to write upstream/.test(r.err)) {
        throw new Error(`git worktree add ${args.join(' ')} failed: ${r.err || r.out}`);
      }
      git(['worktree', 'prune'], REPO, { allowFail: true });
      Atomics.wait(new Int32Array(new SharedArrayBuffer(4)), 0, 0, 1000 * attempt);
    }
  };
  // Re-decided on every attempt: a failed attempt may already have created the branch.
  add(() => {
    if (has(`refs/heads/${branch}`)) return [dir, branch];
    if (has(`refs/remotes/origin/${branch}`)) return [dir, '-b', branch, `origin/${branch}`];
    // --no-track: a work-package branch must not track main, or a bare push would aim at main.
    return ['--no-track', dir, '-b', branch, base];
  });
  return dir;
}

function lastVerdict(stateRoot, packetId) {
  const ledger = path.join(stateRoot, 'ledger.jsonl');
  if (!fs.existsSync(ledger)) return null;
  const rows = fs.readFileSync(ledger, 'utf8').split('\n').filter(Boolean).map((l) => JSON.parse(l));
  return rows.filter((r) => r.packet === packetId).pop()?.verdict || null;
}

async function runGates(packet, worktree, runDir) {
  const results = [];
  let n = 0;
  const skip = machineProfile().skipGates || [];
  for (const gate of packet.gates || []) {
    n++;
    const started = Date.now();
    const unreliable = gate.type === 'cmd' && skip.find((x) => gate.run.includes(x));
    if (unreliable) {
      results.push({ gate: `${gate.cwd || '.'}: ${gate.run}`, ok: true, skipped: true, detail: [`skipped: this machine cannot run "${unreliable}" reliably (state/machine.json); CI runs it`] });
      continue;
    }
    if (gate.type === 'cite') {
      const file = path.join(worktree, gate.file);
      if (!fs.existsSync(file)) {
        results.push({ gate: `cite ${gate.file}`, ok: false, detail: ['file is missing'] });
        continue;
      }
      const r = checkCitationFile(file, { srcDir: path.join(worktree, DESKTOP_SRC), requireSnippets: gate.requireSnippets === true });
      const enough = r.total >= (gate.min ?? 1);
      results.push({
        gate: `cite ${gate.file}`,
        ok: r.errors.length === 0 && enough,
        detail: [`${r.total} citations, ${r.verified} verified by quote, ${r.rangeOnly} range only`, ...(enough ? [] : [`fewer than ${gate.min ?? 1} citations`]), ...r.errors.slice(0, 25)],
      });
      continue;
    }
    const python = findPython();
    const command = gate.type === 'node-test' ? `node --test ${gate.path || ''}` : gate.run.replaceAll('{python}', python || 'python3');
    const logFile = path.join(runDir, `gate-${n}.log`);
    // PYTHONUTF8: the repository's Python gates read UTF-8 files without naming the encoding, which fails on Windows.
    const r = await launch(command, { cwd: path.join(worktree, gate.cwd || '.'), env: { PYTHONUTF8: '1', ...scriptShellEnv(), ...(gate.env || {}) }, logFile, timeoutMs: (gate.timeoutMin ?? 20) * 60_000 });
    results.push({
      gate: `${gate.cwd || '.'}: ${command}`,
      ok: r.code === 0,
      detail: [`exit ${r.code}${r.timedOut ? ' (timed out)' : ''} in ${Math.round((Date.now() - started) / 1000)} s`, ...r.tail.trim().split(/\r?\n/).slice(-12)],
    });
    if (r.code !== 0 && gate.stopOnFail !== false) break;
  }
  return results;
}

function summarise(result) {
  const lines = [];
  lines.push(`# ${result.verdict.toUpperCase()}: ${result.packet} (${result.title})`, '');
  lines.push(`Run ${result.runId} · role ${result.role} · worker ${result.worker} · attempt(s) ${result.attempts} · ${result.minutes} min`);
  lines.push(`Worktree ${result.worktree} · branch ${result.branch}${result.commit ? ` · committed ${result.commit}` : ''}`, '');
  lines.push(`Worker: exit ${result.workerExit}${result.timedOut ? ' (timed out)' : ''}, report status: ${result.reportStatus || 'none'}${result.usage ? `, ${result.usage.turns ?? '?'} turns, ${result.usage.costUsd != null ? `${result.usage.costUsd.toFixed(2)} USD at list price` : 'cost not reported'}` : ''}`);
  lines.push(`Changed: ${result.guards.changed.length} files, ${result.guards.addedLines} added lines`);
  for (const c of result.guards.changed.slice(0, 20)) lines.push(`  ${c.status} ${c.file}`);
  if (result.guards.changed.length > 20) lines.push(`  ... ${result.guards.changed.length - 20} more`);
  lines.push('', `Guards: ${result.guards.ok ? 'pass' : 'FAIL'}`);
  for (const f of result.guards.failures) lines.push(`  FAIL ${f}`);
  for (const w of result.guards.warnings) lines.push(`  WARN ${w}`);
  lines.push('', 'Gates:');
  if (!result.gates.length) lines.push('  (none run)');
  for (const g of result.gates) {
    lines.push(`  ${g.skipped ? 'skip' : g.ok ? 'pass' : 'FAIL'} ${g.gate}`);
    for (const d of g.ok ? g.detail.slice(0, 1) : g.detail) lines.push(`      ${d}`);
  }
  lines.push('', `Worker report: ${result.reportFile || '(none written)'}`, `Full record: ${result.runDir}`);
  return `${lines.join('\n')}\n`;
}

export async function runPacket(packetFile, opts = {}) {
  const packet = parsePacket(packetFile);
  const routing = loadConfig('routing.json');
  const problems = validatePacket(packet, routing);
  if (problems.length) throw new Error(`${packetFile} is not a valid packet:\n  - ${problems.join('\n  - ')}`);
  const { stateRoot } = layout();
  for (const dep of packet.dependsOn || []) {
    if (!['pass', 'partial'].includes(lastVerdict(stateRoot, dep)) && !opts.force) throw new Error(`packet ${dep} has not passed on this machine (use --force if its work is already on the branch)`);
  }
  const scope = effectiveScope(packet, routing);
  if (opts.tier) scope.tier = opts.tier;
  const worktree = opts.worktree || worktreeFor(packet.branch, packet.base || 'origin/main', { fetch: opts.fetch !== false });
  const runId = `${nowStamp()}-${packet.id}`;
  const runDir = path.join(stateRoot, 'runs', runId);
  fs.mkdirSync(runDir, { recursive: true });
  fs.mkdirSync(path.join(worktree, '.orch'), { recursive: true });
  const startSha = git(['rev-parse', 'HEAD'], worktree).out;
  const indexes = writeFormIndexes(packet, worktree);
  const reportPath = path.join(worktree, '.orch', 'report.md');
  const promptPath = path.join(worktree, '.orch', 'prompt.md');
  const started = Date.now();

  let candidate = null;
  if (!opts.noWorker && !opts.runnerCmd) candidate = pickCandidate(scope.tier, { runnerName: opts.runner, model: opts.model }, stateRoot);
  const workerName = opts.noWorker ? 'none (checks only)' : opts.runnerCmd ? 'custom command' : `${candidate.runner}${candidate.provider ? `/${candidate.provider}` : ''}:${candidate.model || 'default'}`;

  let attempt = 0;
  let worker = { code: 0, timedOut: false, tail: '' };
  let guards;
  let gates = [];
  let failures = [];
  const maxAttempts = opts.noWorker ? 1 : Math.max(1, Number(opts.attempts || 1));
  while (attempt < maxAttempts) {
    attempt++;
    const prompt = compilePrompt(packet, scope, { worktree, indexes, attempt, previousFailures: failures, skipGates: machineProfile().skipGates || [] });
    fs.writeFileSync(promptPath, prompt);
    fs.writeFileSync(path.join(runDir, `prompt-${attempt}.md`), prompt);
    if (opts.dryRun) {
      const command = candidate ? buildCommand(candidate, { model: candidate.model || '', worktree, runId, pointer: '<pointer>', lastMessage: '<file>' }) : null;
      return { dryRun: true, packet: packet.id, worktree, worker: workerName, promptFile: promptPath, promptChars: prompt.length, approxTokens: Math.round(prompt.length / 4), command: command ? `${command.bin} ${command.args.join(' ')}` : opts.runnerCmd || null, skipped: candidate?.skipped || [] };
    }
    if (!opts.noWorker) {
      fs.rmSync(reportPath, { force: true });
      const pointer = `Read the file ${promptPath} completely and carry out the work packet it contains. Stop only when its "Done when" list holds or you have written a blocked report.`;
      const logFile = path.join(runDir, `worker-${attempt}.log`);
      const timeoutMs = scope.limits.minutes * 60_000;
      if (opts.runnerCmd) worker = await launch(opts.runnerCmd, { cwd: worktree, logFile, stdin: prompt, timeoutMs });
      else {
        const command = buildCommand(candidate, { model: candidate.model || '', worktree, runId, pointer, lastMessage: path.join(runDir, `last-message-${attempt}.txt`) });
        worker = await launch({ bin: command.bin, args: command.args }, { cwd: worktree, env: workerEnv(candidate, stateRoot), logFile, stdin: command.prompt === 'stdin' ? prompt : undefined, timeoutMs });
      }
    }
    guards = runGuards(worktree, startSha, scope, packet);
    gates = guards.ok ? await runGates(packet, worktree, runDir) : [];
    failures = [...guards.failures, ...gates.filter((g) => !g.ok).flatMap((g) => [`gate failed: ${g.gate}`, ...g.detail.slice(0, 6)])];
    if (!failures.length) break;
  }

  let reportStatus = null;
  let reportFile = null;
  if (fs.existsSync(reportPath)) {
    reportFile = path.join(runDir, 'report.md');
    fs.copyFileSync(reportPath, reportFile);
    reportStatus = (fs.readFileSync(reportPath, 'utf8').match(/^STATUS:\s*(DONE|PARTIAL|BLOCKED)/m) || [])[1] || 'unmarked';
  }
  let verdict = 'pass';
  if (failures.length) verdict = 'fail';
  else if (!opts.noWorker && (worker.code !== 0 || worker.timedOut)) verdict = 'fail';
  else if (reportStatus === 'BLOCKED') verdict = 'blocked';
  // A machine without Docker cannot run database or browser tests, so a worker that wrote them honestly reports
  // PARTIAL. With --accept-partial the supervisor has agreed in advance that CI will run them: the work is
  // committed when the guards and the gates pass, and the verdict says `partial` so nobody reads it as proven.
  else if (!opts.noWorker && reportStatus === 'PARTIAL' && opts.acceptPartial) verdict = 'partial';
  else if (!opts.noWorker && reportStatus !== 'DONE') verdict = 'fail';

  // Tools that end with one JSON object (claude -p --output-format json) report turns and cost: keep them.
  let usage = null;
  try {
    const last = fs.readFileSync(path.join(runDir, `worker-${attempt}.log`), 'utf8').trim().split(/\r?\n/).pop();
    const j = JSON.parse(last);
    if (j && (j.total_cost_usd !== undefined || j.num_turns !== undefined)) usage = { turns: j.num_turns ?? null, costUsd: j.total_cost_usd ?? null };
  } catch {
    /* other tools log differently; cost comes from the provider's own usage page */
  }

  let commit = null;
  if ((verdict === 'pass' || verdict === 'partial') && opts.commit && guards.changed.length) {
    git(['add', '--', ...guards.changed.map((c) => c.file)], worktree);
    const message = [packet.commit || `${packet.wp || packet.id}: ${packet.title}`, '', `Packet: ${packet.id} (${packet.role})`, `Worker: ${workerName}`, `Run: ${runId}`].join('\n');
    const staged = git(['diff', '--cached', '--quiet'], worktree, { allowFail: true }).code !== 0;
    if (staged) {
      git(['commit', '-m', message], worktree);
      commit = git(['rev-parse', '--short', 'HEAD'], worktree).out;
    }
  }
  const result = {
    packet: packet.id, wp: packet.wp || null, title: packet.title, role: packet.role, risk: packet.risk || null, tier: scope.tier,
    runId, runDir, worktree, branch: packet.branch, worker: workerName, attempts: attempt,
    startedAt: new Date(started).toISOString(), minutes: Math.round((Date.now() - started) / 6000) / 10,
    workerExit: worker.code, timedOut: worker.timedOut, reportStatus, reportFile, guards, gates, verdict, commit, usage,
  };
  fs.writeFileSync(path.join(runDir, 'result.json'), `${JSON.stringify(result, null, 2)}\n`);
  fs.writeFileSync(path.join(runDir, 'summary.md'), summarise(result));
  const row = { at: result.startedAt, packet: result.packet, wp: result.wp, role: result.role, tier: result.tier, worker: workerName, attempts: attempt, minutes: result.minutes, verdict, files: guards.changed.length, lines: guards.addedLines, commit, usage, runDir };
  fs.appendFileSync(path.join(stateRoot, 'ledger.jsonl'), `${JSON.stringify(row)}\n`);
  return result;
}

export { summarise };
