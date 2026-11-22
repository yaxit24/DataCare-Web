// Guards: what a worker actually changed, checked against what its packet allowed.
// These run after every worker session and do not depend on the worker's tool or model.
import { spawnSync } from 'node:child_process';
import fs from 'node:fs';
import path from 'node:path';
import { git, matchAny } from './util.mjs';

const TEST_FILE = /(^|\/)(test|tests|__tests__)\/|\.test\.[cm]?[jt]sx?$|\.spec\.[cm]?[jt]sx?$/;
const BASELINES = /(^|\/)(baseline|kernel-conformance-baseline|depth-parity-baseline|size-budget)\.json$/;

const CONTENT_RULES = [
  { id: 'conflict-marker', re: /^(<<<<<<< |>>>>>>> )/, where: () => true },
  { id: 'test-skipped-or-focused', re: /\b(?:it|test|describe)\.(?:skip|only|todo)\s*\(|\bx(?:it|describe)\s*\(/, where: (f) => TEST_FILE.test(f) },
  { id: 'hook-bypass', re: /--no-verify\b/, where: (f) => !f.endsWith('.md') },
  { id: 'private-key', re: /-----BEGIN [A-Z ]*PRIVATE KEY-----/, where: () => true },
  { id: 'credential-in-url', re: /\b(?:postgres(?:ql)?|mssql|sqlserver|mysql):\/\/[^\s:/@]+:[^\s@]+@(?!localhost|127\.0\.0\.1)/, where: () => true },
];

/** Everything that differs from the commit the worker started on: commits, edits and new files. */
export function changedFiles(worktree, startSha) {
  const files = new Map();
  for (const line of git(['diff', '--name-status', '--no-renames', startSha], worktree).out.split('\n').filter(Boolean)) {
    const [status, ...rest] = line.split('\t');
    files.set(rest.join('\t'), status[0]);
  }
  for (const f of git(['ls-files', '--others', '--exclude-standard'], worktree).out.split('\n').filter(Boolean)) files.set(f, 'A');
  return [...files].map(([file, status]) => ({ file, status })).sort((a, b) => a.file.localeCompare(b.file));
}

function addedLines(worktree, startSha, changed) {
  const added = [];
  let current = null;
  for (const line of git(['diff', '-U0', '--no-renames', startSha], worktree).out.split('\n')) {
    if (line.startsWith('+++ ')) current = line.slice(4).replace(/^b\//, '');
    else if (line.startsWith('+') && current && current !== '/dev/null') added.push({ file: current, text: line.slice(1) });
  }
  const tracked = new Set(added.map((a) => a.file));
  for (const { file, status } of changed) {
    if (status !== 'A' || tracked.has(file)) continue;
    const p = path.join(worktree, file);
    try {
      if (fs.statSync(p).size > 2_000_000) continue;
      for (const text of fs.readFileSync(p, 'utf8').split(/\r?\n/)) added.push({ file, text });
    } catch {
      /* unreadable: the path guard still lists the file */
    }
  }
  return added;
}

export function runGuards(worktree, startSha, scope, packet = {}) {
  const changed = changedFiles(worktree, startSha).filter((c) => !c.file.startsWith('.orch/'));
  const failures = [];
  const warnings = [];
  for (const { file, status } of changed) {
    if (matchAny(file, scope.deny)) failures.push(`changed a protected path: ${file}`);
    else if (!matchAny(file, scope.allow)) failures.push(`changed a path outside the packet's allow list: ${file}`);
    if (status === 'D' && TEST_FILE.test(file) && !packet.allowTestDeletion) failures.push(`deleted a test file: ${file}`);
    if (BASELINES.test(file)) warnings.push(`baseline or budget file changed, supervisor must read the diff: ${file}`);
  }
  // A tool on Windows can rewrite a whole LF file with CRLF endings (Python's text mode does). Git then shows
  // every line as changed and the format gate fails on CI, so refuse it here.
  for (const { file, status } of changed) {
    if (status !== 'M') continue;
    try {
      const now = fs.readFileSync(path.join(worktree, file));
      if (now.length > 5_000_000 || !now.includes('\r\n')) continue;
      const before = spawnSync('git', ['show', `${startSha}:${file}`], { cwd: worktree, maxBuffer: 64 * 1024 * 1024 }).stdout;
      if (before && !before.includes('\r\n')) failures.push(`line endings changed from LF to CRLF: ${file}`);
    } catch {
      /* deleted or unreadable: nothing to compare */
    }
  }
  const added = addedLines(worktree, startSha, changed);
  const perFile = new Map();
  for (const { file, text } of added) {
    perFile.set(file, (perFile.get(file) || 0) + 1);
    for (const rule of CONTENT_RULES) {
      if (rule.where(file) && rule.re.test(text)) failures.push(`${rule.id} in ${file}: ${text.trim().slice(0, 100)}`);
    }
  }
  const diffLines = added.length;
  if (changed.length > scope.limits.maxChangedFiles) failures.push(`changed ${changed.length} files, limit ${scope.limits.maxChangedFiles}`);
  if (diffLines > scope.limits.maxDiffLines) failures.push(`added ${diffLines} lines, limit ${scope.limits.maxDiffLines}`);
  const missing = (packet.outputs || []).filter((f) => !fs.existsSync(path.join(worktree, f)));
  for (const f of missing) failures.push(`required output is missing: ${f}`);
  return {
    ok: failures.length === 0,
    failures: [...new Set(failures)],
    warnings: [...new Set(warnings)],
    changed,
    addedLines: diffLines,
    largest: [...perFile].sort((a, b) => b[1] - a[1]).slice(0, 8).map(([file, lines]) => ({ file, lines })),
  };
}
