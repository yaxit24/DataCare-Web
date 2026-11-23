// Shared helpers for the orchestration dispatcher. No dependencies: Node 20+ only.
import { spawn, spawnSync } from 'node:child_process';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

export const REPO = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '..', '..');
export const ORCH = path.join(REPO, 'orchestration');
export const DESKTOP_SRC = 'unified/src/csharp/DataCareNext';

export function configDir() {
  return process.env.DATACARE_ORCH_CONFIG || path.join(ORCH, 'config');
}

export function readJson(file) {
  return JSON.parse(fs.readFileSync(file, 'utf8'));
}

export function loadConfig(name) {
  return readJson(path.join(configDir(), name));
}

/** Run a program directly (no shell). Returns { code, out, err }. */
export function sh(cmd, args = [], opts = {}) {
  const r = spawnSync(cmd, args, { encoding: 'utf8', maxBuffer: 256 * 1024 * 1024, windowsHide: true, ...opts });
  return {
    code: r.error ? 127 : (r.status ?? 1),
    out: (r.stdout || '').replace(/\s+$/, ''),
    err: (r.stderr || '').replace(/\s+$/, ''),
  };
}

export function git(args, cwd = REPO, { allowFail = false } = {}) {
  const r = sh('git', args, { cwd });
  if (r.code !== 0 && !allowFail) throw new Error(`git ${args.join(' ')} failed in ${cwd}: ${r.err || r.out}`);
  return r;
}

/**
 * The machine layout needs no configuration: <root>/DataCare-Web is the base clone, <root>/wt holds one worktree
 * per branch and <root>/state holds run records and the provider keys. Environment variables override each part.
 */
export function layout(cwd = REPO) {
  const common = git(['rev-parse', '--path-format=absolute', '--git-common-dir'], cwd).out;
  const base = path.dirname(common);
  const root = path.dirname(base);
  return {
    base,
    root,
    wtRoot: process.env.DATACARE_WT_ROOT || path.join(root, 'wt'),
    stateRoot: process.env.DATACARE_STATE_ROOT || path.join(root, 'state'),
  };
}

/** Git for Windows bash, so the repository's bash runbook commands run unchanged on Windows. */
export function findBash() {
  if (process.platform !== 'win32') return 'bash';
  const candidates = [
    process.env.DATACARE_BASH,
    'C:\\Program Files\\Git\\bin\\bash.exe',
    'C:\\Program Files\\Git\\usr\\bin\\bash.exe',
  ].filter(Boolean);
  return candidates.find((p) => fs.existsSync(p)) || null;
}

let pythonCache;
/** A real Python 3 (the Windows Store stub named python3 is rejected). Returns a command string or null. */
export function findPython() {
  if (pythonCache !== undefined) return pythonCache;
  const candidates = [['python3', []], ['python', []], ['py', ['-3']]];
  if (process.platform === 'win32' && process.env.LOCALAPPDATA) {
    // A per-user Python install is not on PATH until a new terminal is opened.
    const dir = path.join(process.env.LOCALAPPDATA, 'Programs', 'Python');
    const found = fs.existsSync(dir) ? fs.readdirSync(dir).filter((d) => /^Python3\d+$/.test(d)).sort().reverse() : [];
    for (const d of found) candidates.push([path.join(dir, d, 'python.exe'), []]);
  }
  if (process.env.DATACARE_PYTHON) candidates.unshift([process.env.DATACARE_PYTHON, []]);
  for (const [cmd, args] of candidates) {
    const r = sh(cmd, [...args, '--version']);
    if (r.code === 0 && /^Python 3\./.test(`${r.out}${r.err}`.trim())) {
      pythonCache = [/\s/.test(cmd) ? `"${cmd}"` : cmd, ...args].join(' ').replace(/\\/g, '/');
      return pythonCache;
    }
  }
  pythonCache = null;
  return null;
}

/** KEY=VALUE lines; blank lines and # comments ignored. Values are never printed by this tool. */
export function loadEnvFile(file) {
  const env = {};
  if (!fs.existsSync(file)) return env;
  for (const line of fs.readFileSync(file, 'utf8').split(/\r?\n/)) {
    const m = line.match(/^\s*([A-Za-z_][A-Za-z0-9_]*)\s*=\s*(.*?)\s*$/);
    if (m && !line.trim().startsWith('#')) env[m[1]] = m[2].replace(/^(['"])(.*)\1$/, '$2');
  }
  return env;
}

export function globToRegExp(glob) {
  let re = '';
  for (let i = 0; i < glob.length; i++) {
    const c = glob[i];
    if (c === '*') {
      if (glob[i + 1] === '*') {
        i++;
        if (glob[i + 1] === '/') {
          i++;
          re += '(?:.*/)?';
        } else re += '.*';
      } else re += '[^/]*';
    } else if (c === '?') re += '[^/]';
    else re += c.replace(/[.+^${}()|[\]\\]/g, '\\$&');
  }
  return new RegExp(`^${re}$`);
}

export function matchAny(file, globs) {
  return (globs || []).some((g) => globToRegExp(g).test(file));
}

export function killTree(child) {
  if (!child || child.exitCode !== null) return;
  if (process.platform === 'win32') sh('taskkill', ['/pid', String(child.pid), '/T', '/F']);
  else {
    try {
      process.kill(-child.pid, 'SIGKILL');
    } catch {
      child.kill('SIGKILL');
    }
  }
}

/**
 * Start a long-running child with its output appended to a log file. `command` is either a shell string
 * (run through bash where available) or { bin, args } (argv kept intact; on Windows it goes through bash so the
 * npm shims of CLI tools resolve).
 */
export function launch(command, { cwd, env = {}, logFile, stdin, timeoutMs } = {}) {
  return new Promise((resolve) => {
    const bash = findBash();
    const fullEnv = { ...process.env, ...env };
    let child;
    const spawnOpts = { cwd, env: fullEnv, windowsHide: true, detached: process.platform !== 'win32' };
    if (typeof command === 'string') {
      child = bash ? spawn(bash, ['-c', command], spawnOpts) : spawn(command, { ...spawnOpts, shell: true });
    } else if (process.platform === 'win32' && bash) {
      child = spawn(bash, ['-c', '"$0" "$@"', command.bin, ...command.args], spawnOpts);
    } else {
      child = spawn(command.bin, command.args, { ...spawnOpts, shell: process.platform === 'win32' });
    }
    const log = logFile ? fs.createWriteStream(logFile, { flags: 'a' }) : null;
    let tail = '';
    const onData = (d) => {
      if (log) log.write(d);
      tail = (tail + d.toString()).slice(-6000);
    };
    child.stdout.on('data', onData);
    child.stderr.on('data', onData);
    if (stdin !== undefined) child.stdin.end(stdin);
    else child.stdin.end();
    let timedOut = false;
    const timer = timeoutMs
      ? setTimeout(() => {
          timedOut = true;
          killTree(child);
        }, timeoutMs)
      : null;
    const done = (code) => {
      if (timer) clearTimeout(timer);
      if (log) log.end();
      resolve({ code: timedOut ? 124 : (code ?? 1), timedOut, tail });
    };
    child.on('error', (e) => {
      tail += `\n${e.message}`;
      done(127);
    });
    child.on('close', done);
  });
}

export function nowStamp(d = new Date()) {
  return d.toISOString().replace(/[-:]/g, '').replace(/\.\d+Z$/, 'Z');
}

export function fill(template, vars) {
  return template.replace(/\{(\w+)\}/g, (m, k) => (k in vars ? String(vars[k]) : m));
}
