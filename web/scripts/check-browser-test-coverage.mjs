#!/usr/bin/env node
/**
 * Browser-test gate (docs/handbook/web/testing.md §4a, "Rule for every feature slice").
 *
 * A pull request that changes what a screen or the API does must change a browser test in the same PR: a feature
 * module or its baseline (web/apps/web/test/features/), a zero-mock journey, or the surface baseline. When a change
 * truly has no browser-visible effect (a refactor, a comment, a log line), the PR body says so with a line
 *
 *     Browser-Test-Exempt: <at least 15 characters of reason>
 *
 * and the reason is printed in the CI log for review.
 *
 * Mapped areas are stricter: a change to a file that a feature module covers (features/coverage-map.json) must
 * change that module or the feature baseline, not just any test.
 *
 * Usage:
 *   node scripts/check-browser-test-coverage.mjs --base <ref> [--head <ref>]
 *   PR_BODY=... (CI passes the pull request body through the environment, never through the shell command line)
 */
import { spawnSync } from 'node:child_process';
import { readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const webRoot = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const repoRoot = resolve(webRoot, '..');

const args = process.argv.slice(2);
const option = (name, fallback) => {
  const i = args.indexOf(name);
  return i >= 0 ? args[i + 1] : fallback;
};
const base = option('--base', process.env.BROWSER_TEST_BASE);
const head = option('--head', 'HEAD');
if (!base) {
  console.error('check-browser-test-coverage: --base <ref> is required');
  process.exit(2);
}

const git = (...a) => {
  const out = spawnSync('git', a, { cwd: repoRoot, encoding: 'utf8' });
  if (out.status !== 0) throw new Error(`git ${a.join(' ')} failed: ${out.stderr}`);
  return out.stdout;
};
const changed = git('diff', '--name-only', `${base}...${head}`).split('\n').filter(Boolean);

/** Files whose change alters what an operator can do or see. */
const BEHAVIOUR = [
  /^web\/apps\/web\/app\/.*\.tsx?$/,
  /^web\/apps\/web\/components\/.*\.tsx?$/,
  /^web\/apps\/web\/lib\/.*\.ts$/,
  /^web\/apps\/api\/src\/(modules|routes)\/.*\.ts$/,
  /^web\/apps\/api\/src\/app\.ts$/,
  /^web\/packages\/core\/src\/.*\.ts$/,
];
/** Files that are browser tests. */
const BROWSER_TEST = [
  /^web\/apps\/web\/test\/features\//,
  /^web\/apps\/web\/test\/[^/]+\.journey\.mjs$/,
  /^web\/apps\/web\/test\/[^/]*real-stack[^/]*\.mjs$/,
];

const behaviour = changed.filter((f) => BEHAVIOUR.some((re) => re.test(f)));
const tests = changed.filter((f) => BROWSER_TEST.some((re) => re.test(f)));

const coverage = JSON.parse(
  readFileSync(resolve(webRoot, 'apps/web/test/features/coverage-map.json'), 'utf8'),
);
const problems = [];
for (const [module, entry] of Object.entries(coverage.modules)) {
  const touched = behaviour.filter((f) =>
    entry.covers.some(
      (pattern) => f === pattern || (pattern.endsWith('/') && f.startsWith(pattern)),
    ),
  );
  if (!touched.length) continue;
  const moduleFile = `web/apps/web/test/features/modules/${module}.mjs`;
  const updated =
    changed.includes(moduleFile) || changed.includes('web/apps/web/test/features/baseline.json');
  if (!updated)
    problems.push(
      `${touched.join(', ')} changed, but its feature module ${moduleFile} (or features/baseline.json) did not`,
    );
}
if (behaviour.length && !tests.length)
  problems.push(`behaviour changed (${behaviour.length} file(s)) but no browser test changed`);

const exemption = (process.env.PR_BODY ?? '').match(/^Browser-Test-Exempt:\s*(.{15,})$/m);
console.log(
  `browser-test gate: ${changed.length} changed file(s), ${behaviour.length} behaviour, ${tests.length} browser test`,
);
for (const f of behaviour) console.log(`  behaviour: ${f}`);
for (const f of tests) console.log(`  test:      ${f}`);
if (problems.length && exemption) {
  console.log(`BROWSER_TEST_EXEMPT: ${exemption[1].trim()}`);
  for (const p of problems) console.log(`  (exempted) ${p}`);
  process.exit(0);
}
if (problems.length) {
  console.error(`BROWSER_TEST_GATE_FAILED:\n- ${problems.join('\n- ')}`);
  console.error(
    'Add or update the browser test in this PR, or add "Browser-Test-Exempt: <reason>" to the PR body.',
  );
  process.exit(1);
}
console.log('BROWSER_TEST_GATE_PASSED');
