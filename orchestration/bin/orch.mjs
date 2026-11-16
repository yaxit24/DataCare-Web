#!/usr/bin/env node
// DataCare-Web orchestration dispatcher. Usage: node orchestration/bin/orch.mjs <command> [options]
// It contains no model. The supervisor session calls it; it starts one worker session per packet and checks the
// result with scripts. See orchestration/README.md.
import fs from 'node:fs';
import path from 'node:path';
import { checkCitationFile } from '../lib/cite.mjs';
import { outlineForm, renderOutline } from '../lib/outline.mjs';
import { parsePacket, validatePacket } from '../lib/packet.mjs';
import { candidateProblem, providerEnv, runPacket, runnerInstalled, summarise, worktreeFor } from '../lib/run.mjs';
import { DESKTOP_SRC, REPO, findBash, findPython, git, layout, loadConfig, sh } from '../lib/util.mjs';

const HELP = `DataCare-Web orchestration dispatcher

  doctor                       Check this machine: tools, clone settings, disk, worker tools, provider keys
  providers                    Which worker tools and providers are installed, keyed and ready, per model tier
  run <packet.md> [options]    Run one packet: worktree, context pack, worker, guards, gates, result
      --dry-run                Build the context pack and show the worker command; start nothing
      --tier A|B|C             Override the packet's model tier
      --runner <name>          Force a worker tool from config/runners.json (--model <id> to force a model)
      --runner-cmd "<cmd>"     Use this shell command as the worker (the prompt arrives on stdin)
      --no-worker              Re-run guards and gates on the worktree as it is
      --attempts <n>           Re-launch the worker with the failed checks, up to n times (default 1)
      --commit                 Commit the worker's files when the verdict is pass
      --accept-partial         Also commit when the worker reports PARTIAL (tests it could not run here) and the
                               guards and gates pass; the verdict is then "partial" and CI must run the tests
      --force                  Ignore dependsOn
      --no-fetch               Do not fetch origin before creating a worktree
  check <packet.md>            Validate a packet file
  outline <FORM.cs> [--out f]  Form index of a desktop form (members, captions, messages, tables)
  cite <file> [--require-snippets]   Check desktop citations in a file
  worktree <branch> [--base ref]     Create or find the worktree of a branch
  push <packet.md|branch>      Push a work branch to origin (refuses main)
  status [--prs]               Recent runs, worktrees, free disk, optionally open pull requests
`;

function parseArgs(argv) {
  const flags = {};
  const rest = [];
  const valued = new Set(['tier', 'runner', 'model', 'runner-cmd', 'attempts', 'out', 'base']);
  for (let i = 0; i < argv.length; i++) {
    const a = argv[i];
    if (a.startsWith('--')) {
      const key = a.slice(2);
      flags[key.replace(/-([a-z])/g, (m, c) => c.toUpperCase())] = valued.has(key) ? argv[++i] : true;
    } else rest.push(a);
  }
  return { flags, rest };
}

function freeGb(dir) {
  try {
    const s = fs.statfsSync(dir);
    return Math.round((s.bavail * s.bsize) / 1e8) / 10;
  } catch {
    return null;
  }
}

function doctor() {
  const rows = [];
  const add = (name, ok, detail, required = true) => rows.push({ name, ok, detail, required });
  const version = (cmd, args = ['--version']) => {
    const r = sh(cmd, args, { shell: process.platform === 'win32' });
    return r.code === 0 ? `${r.out}${r.err}`.split(/\r?\n/)[0].trim() : null;
  };
  const node = Number(process.versions.node.split('.')[0]);
  add('node >= 20', node >= 20, `v${process.versions.node}${node === 24 ? '' : ' (the repository supports Node 24: pnpm runtime:check)'}`);
  for (const [tool, required] of [['git', true], ['pnpm', true], ['gh', true], ['docker', false]]) {
    const v = version(tool);
    add(tool, Boolean(v), v || 'not found', required);
  }
  const lfs = version('git', ['lfs', 'version']);
  add('git lfs', Boolean(lfs), lfs || 'not found');
  const python = findPython();
  add('python 3', Boolean(python), python ? `${python}` : 'not found (needed by validate_plan.py and docs_check.py)');
  const bash = findBash();
  add('bash', Boolean(bash), bash || 'Git for Windows bash not found; gate commands fall back to cmd.exe', process.platform !== 'win32' ? true : false);
  const dockerUp = sh('docker', ['info', '--format', '{{.ServerVersion}}']);
  add('docker engine running', dockerUp.code === 0, dockerUp.code === 0 ? dockerUp.out : 'not running: database and browser tests cannot run locally', false);
  const gh = sh('gh', ['auth', 'status']);
  add('gh signed in', gh.code === 0, gh.code === 0 ? 'ok' : 'run: gh auth login');
  const cfg = (key) => git(['config', '--get', key], REPO, { allowFail: true }).out;
  add('git identity', Boolean(cfg('user.name') && cfg('user.email')), cfg('user.name') || 'set user.name and user.email in this clone');
  add('core.autocrlf false', cfg('core.autocrlf') === 'false', cfg('core.autocrlf') || 'unset: CRLF checkouts fail pnpm format:check', process.platform === 'win32');
  add('LFS downloads skipped', /--skip/.test(cfg('filter.lfs.smudge')), /--skip/.test(cfg('filter.lfs.smudge')) ? 'worker worktrees hold pointers, not databases or binaries' : 'this clone downloads LFS binaries (fine for the reference copy, not for worker worktrees)', false);
  const l = layout();
  for (const dir of [l.wtRoot, l.stateRoot]) fs.mkdirSync(dir, { recursive: true });
  const free = freeGb(l.wtRoot);
  add('free disk at worktree root', free === null || free >= 8, free === null ? 'unknown' : `${free} GB at ${l.wtRoot}`);
  const width = Math.max(...rows.map((r) => r.name.length));
  for (const r of rows) console.log(`${r.ok ? 'ok  ' : r.required ? 'FAIL' : 'warn'}  ${r.name.padEnd(width)}  ${r.detail}`);
  console.log(`\nLayout: base ${l.base} · worktrees ${l.wtRoot} · state ${l.stateRoot}`);
  console.log('Worker tools and providers: node orchestration/bin/orch.mjs providers');
  return rows.some((r) => !r.ok && r.required) ? 1 : 0;
}

function providers() {
  const { stateRoot } = layout();
  const env = providerEnv(stateRoot);
  const runners = loadConfig('runners.json');
  const catalog = loadConfig('providers.json').providers;
  const routing = loadConfig('routing.json');
  console.log('Worker tools');
  for (const [id, r] of Object.entries(runners)) console.log(`  ${runnerInstalled(r) ? 'installed' : 'missing  '}  ${id.padEnd(10)} ${r.name}${runnerInstalled(r) ? '' : `  -> ${r.install}`}`);
  console.log('\nProviders and plans (keys are read from the environment or from state/providers.env; values are never shown)');
  for (const [id, p] of Object.entries(catalog)) {
    const missing = (p.env || []).filter((k) => !env[k] && !process.env[k]);
    const state = !(p.env || []).length ? 'login   ' : missing.length ? 'no key  ' : 'keyed   ';
    console.log(`  ${state}  ${id.padEnd(22)} ${p.kind.padEnd(12)} automation: ${String(p.automation).padEnd(8)} ${missing.length ? `needs ${missing.join(', ')}` : ''}`);
  }
  console.log('\nRouting (first ready candidate per tier is used)');
  for (const [tier, t] of Object.entries(routing.tiers)) {
    console.log(`  Tier ${tier}: ${t.use}`);
    let chosen = false;
    for (const c of t.candidates) {
      const problem = candidateProblem(c, runners, catalog, env);
      const mark = problem ? 'not ready' : chosen ? 'ready    ' : 'READY <- ';
      if (!problem) chosen = true;
      console.log(`    ${mark}  ${c.runner}${c.provider ? `/${c.provider}` : ''}:${c.model || '(model not set)'}${problem ? `  (${problem})` : ''}`);
    }
  }
  return 0;
}

function status(flags) {
  const l = layout();
  console.log(`Base ${l.base}\nFree disk ${freeGb(l.wtRoot) ?? '?'} GB at ${l.wtRoot}\n`);
  console.log('Worktrees');
  console.log(git(['worktree', 'list'], REPO).out.split('\n').map((x) => `  ${x}`).join('\n'));
  const ledger = path.join(l.stateRoot, 'ledger.jsonl');
  console.log('\nLast runs on this machine');
  if (!fs.existsSync(ledger)) console.log('  (none)');
  else {
    for (const line of fs.readFileSync(ledger, 'utf8').split('\n').filter(Boolean).slice(-15)) {
      const r = JSON.parse(line);
      console.log(`  ${r.at.slice(0, 16)}  ${r.verdict.padEnd(7)} ${r.packet.padEnd(26)} ${r.worker}  ${r.minutes} min, ${r.files} files`);
    }
  }
  if (flags.prs) {
    console.log('\nOpen pull requests');
    console.log(sh('gh', ['pr', 'list', '--state', 'open', '--limit', '30'], { cwd: REPO }).out || '  (none, or gh is not signed in)');
  }
  return 0;
}

async function main() {
  const [command, ...argv] = process.argv.slice(2);
  const { flags, rest } = parseArgs(argv);
  switch (command) {
    case 'doctor':
      return doctor();
    case 'providers':
      return providers();
    case 'status':
      return status(flags);
    case 'check': {
      const errors = validatePacket(parsePacket(rest[0]));
      console.log(errors.length ? errors.map((e) => `- ${e}`).join('\n') : 'packet is valid');
      return errors.length ? 1 : 0;
    }
    case 'outline': {
      const file = fs.existsSync(rest[0]) ? rest[0] : path.join(REPO, DESKTOP_SRC, rest[0]);
      const text = renderOutline(outlineForm(file));
      if (flags.out) fs.writeFileSync(flags.out, text);
      else process.stdout.write(text);
      return 0;
    }
    case 'cite': {
      const r = checkCitationFile(rest[0], { requireSnippets: flags.requireSnippets === true });
      console.log(`${r.total} citations: ${r.verified} verified by quote, ${r.rangeOnly} range only, ${r.errors.length} wrong`);
      for (const e of r.errors) console.log(`  ${e}`);
      return r.errors.length ? 1 : 0;
    }
    case 'worktree':
      console.log(worktreeFor(rest[0], flags.base || 'origin/main'));
      return 0;
    case 'push': {
      const branch = fs.existsSync(rest[0]) ? parsePacket(rest[0]).branch : rest[0];
      if (!branch || /^(main|master)$/.test(branch)) throw new Error('refusing to push main');
      const dir = worktreeFor(branch, 'origin/main', { fetch: false });
      console.log(git(['push', '-u', 'origin', `${branch}:${branch}`], dir).err);
      return 0;
    }
    case 'run': {
      const result = await runPacket(rest[0], { dryRun: flags.dryRun, tier: flags.tier, runner: flags.runner, model: flags.model, runnerCmd: flags.runnerCmd, noWorker: flags.noWorker, attempts: flags.attempts, commit: flags.commit, force: flags.force, fetch: !flags.noFetch, acceptPartial: flags.acceptPartial });
      if (result.dryRun) {
        console.log(JSON.stringify(result, null, 2));
        return 0;
      }
      process.stdout.write(summarise(result));
      return result.verdict === 'pass' || result.verdict === 'partial' ? 0 : result.verdict === 'blocked' ? 3 : 2;
    }
    default:
      process.stdout.write(HELP);
      return command ? 1 : 0;
  }
}

main().then(
  (code) => process.exit(code),
  (e) => {
    console.error(`orch: ${e.message}`);
    process.exit(1);
  },
);
