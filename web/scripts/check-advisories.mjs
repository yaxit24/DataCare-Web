#!/usr/bin/env node
/**
 * Dependency advisory gate (N86 / G72).
 *
 * Audits the locked dependency graph (`pnpm audit --json`) and fails when any installed package matches a
 * known CRITICAL or HIGH advisory, unless that advisory is listed in `security/advisory-exceptions.json` with
 * a reason, an owner and an expiry date that has not passed. Moderate and low advisories are reported but do
 * not fail the gate.
 *
 * An exception is a reviewed decision, not a mute button:
 *   { "id": "GHSA-xxxx-xxxx-xxxx", "package": "name", "reason": "...", "owner": "...", "expires": "YYYY-MM-DD" }
 * An expired exception fails the gate, and so does an exception for an advisory that no longer applies, so the
 * file cannot keep stale entries.
 *
 * Fails closed: if the audit cannot run or its output cannot be read, the gate fails.
 *
 * Usage: node scripts/check-advisories.mjs
 */
import { execFileSync } from 'node:child_process';
import { readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import process from 'node:process';
import { fileURLToPath } from 'node:url';

const web = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const BLOCKING = new Set(['critical', 'high']);

function audit() {
  let out;
  try {
    out = execFileSync('pnpm', ['audit', '--json'], {
      cwd: web,
      encoding: 'utf8',
      maxBuffer: 64 * 1024 * 1024,
      stdio: ['ignore', 'pipe', 'pipe'],
    });
  } catch (error) {
    // pnpm audit exits non-zero when it finds advisories; its JSON is still on stdout.
    out = error?.stdout;
    if (!out) {
      console.error(
        `ADVISORIES_FAIL audit did not run: ${String(error?.message ?? error).split('\n')[0]}`,
      );
      process.exit(1);
    }
  }
  try {
    return JSON.parse(out);
  } catch {
    console.error('ADVISORIES_FAIL audit output is not JSON');
    process.exit(1);
  }
}

const report = audit();
const advisories = Object.values(report.advisories ?? {});
const exceptions = JSON.parse(
  readFileSync(resolve(web, 'security/advisory-exceptions.json'), 'utf8'),
);
const today = new Date().toISOString().slice(0, 10);
const problems = [];

const exceptionById = new Map();
for (const entry of exceptions.exceptions ?? []) {
  for (const field of ['id', 'package', 'reason', 'owner', 'expires']) {
    if (!entry[field]) problems.push(`exception ${entry.id ?? '?'} is missing ${field}`);
  }
  if (entry.expires && !/^\d{4}-\d{2}-\d{2}$/.test(entry.expires))
    problems.push(`exception ${entry.id} has an invalid expiry ${entry.expires}`);
  else if (entry.expires && entry.expires < today)
    problems.push(`exception ${entry.id} (${entry.package}) expired on ${entry.expires}`);
  exceptionById.set(entry.id, entry);
}

const found = new Set();
const reported = [];
for (const advisory of advisories) {
  const id = advisory.github_advisory_id || `npm-${advisory.id}`;
  found.add(id);
  const versions = [...new Set((advisory.findings ?? []).map((f) => f.version))].join(', ');
  const line = `${advisory.severity} ${advisory.module_name}@${versions} ${id} (patched ${advisory.patched_versions})`;
  if (!BLOCKING.has(advisory.severity)) {
    reported.push(`  note: ${line}`);
    continue;
  }
  if (exceptionById.has(id)) {
    reported.push(`  excepted until ${exceptionById.get(id).expires}: ${line}`);
    continue;
  }
  problems.push(`unexcepted ${line}`);
}
for (const id of exceptionById.keys()) {
  if (!found.has(id)) problems.push(`exception ${id} no longer matches any advisory; remove it`);
}

const counts = report.metadata?.vulnerabilities ?? {};
console.log(
  `advisories: critical ${counts.critical ?? 0}, high ${counts.high ?? 0}, moderate ${counts.moderate ?? 0}, low ${counts.low ?? 0}`,
);
for (const line of reported) console.log(line);
if (problems.length) {
  console.log(`ADVISORIES_RED ${problems.length} problem(s)`);
  for (const problem of problems) console.log(`    ${problem}`);
  process.exit(1);
}
console.log('ADVISORIES_OK no unexcepted critical or high advisory in the locked dependency graph');
