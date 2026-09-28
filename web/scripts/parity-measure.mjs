#!/usr/bin/env node
/**
 * `pnpm parity:measure` — one command, the parity numbers, and a ratchet that refuses a regression.
 *
 * WHAT THIS IS FOR
 * ================
 * `check-g5-parity.mjs` answers "is the web at parity?" — correctly, and the answer is no. It cannot say
 * whether the gap is closing. This can.
 *
 * The need is not theoretical. The comparison went unrun for a month; when it was finally run, 1,354 of its
 * 3,787 field differences turned out to be already fixed weeks earlier, because the web-side bundle predated
 * the fix. Both directions were invisible: real progress unmeasured, and a regression would have been too.
 *
 * WHAT IT DOES
 * ============
 *   1. compares the newest desktop and web bundles with `parity-compare.mjs` (or reuses a diff with --reuse)
 *   2. extracts the tracked metrics and the per-case detail
 *   3. evaluates them against the recorded ceiling in project-memory/parity/PARITY-RATCHET.json
 *   4. exits non-zero if anything got worse
 *
 * USAGE
 *   node scripts/parity-measure.mjs                  # measure and check the ratchet
 *   node scripts/parity-measure.mjs --record         # ...and record the result as the new ceiling
 *   node scripts/parity-measure.mjs --reuse          # evaluate the newest existing diff, no re-comparison
 *   node scripts/parity-measure.mjs --desktop A --web B
 *
 * --record is deliberately explicit. An automatic re-record would move the ceiling to whatever the last run
 * produced, which is a ratchet that ratchets in both directions — that is, not a ratchet.
 */

import { execFileSync } from 'node:child_process';
import { existsSync, readFileSync, readdirSync, writeFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve, relative } from 'node:path';

const HERE = dirname(fileURLToPath(import.meta.url));
const WEB = resolve(HERE, '..');
const REPO = resolve(WEB, '..');
const BUNDLES = resolve(REPO, 'project-memory', 'parity', 'bundles');
const G5 = resolve(REPO, 'project-memory', 'parity', 'g5');
const RATCHET = resolve(REPO, 'project-memory', 'parity', 'PARITY-RATCHET.json');

const argv = process.argv.slice(2);
const has = (flag) => argv.includes(flag);
const valueOf = (flag) => {
  const i = argv.indexOf(flag);
  return i >= 0 && argv[i + 1] ? argv[i + 1] : '';
};

const die = (why, ...detail) => {
  console.error(`PARITY_MEASURE_FAILED ${why}`);
  for (const d of detail) console.error(`  ${d}`);
  process.exit(1);
};

const ratchetModule = resolve(WEB, 'apps/api/dist/modules/ops/parityRatchet.js');
if (!existsSync(ratchetModule)) {
  die(
    'the API is not built',
    'run: pnpm --filter @datacare/api build',
    relative(REPO, ratchetModule),
  );
}
const { evaluateRatchet, metricsFromDiff, perCaseFromDiff, agreementPct } = await import(
  ratchetModule
);

/** Newest file matching a prefix, excluding the moving `-latest` alias so ordering stays meaningful. */
const newest = (dir, prefix) => {
  if (!existsSync(dir)) return '';
  const files = readdirSync(dir)
    .filter((f) => f.startsWith(prefix) && f.endsWith('.json') && !f.includes('-latest'))
    .sort();
  return files.length ? resolve(dir, files[files.length - 1]) : '';
};

// ---------------------------------------------------------------------------------------------------
// 1. Obtain a diff artefact.
// ---------------------------------------------------------------------------------------------------
let diffPath = '';
if (has('--reuse')) {
  diffPath = newest(G5, 'parity-diff-');
  if (!diffPath) die('no existing diff artefact to reuse', `looked in ${relative(REPO, G5)}`);
} else {
  const desktop =
    valueOf('--desktop') || newest(BUNDLES, 'desktop-') || resolve(BUNDLES, 'desktop-latest.json');
  const web = valueOf('--web') || newest(BUNDLES, 'web-') || resolve(BUNDLES, 'web-latest.json');
  for (const [label, p] of [
    ['desktop', desktop],
    ['web', web],
  ]) {
    if (!p || !existsSync(p)) {
      die(
        `no ${label} bundle`,
        `expected under ${relative(REPO, BUNDLES)}`,
        label === 'desktop'
          ? 'a desktop capture comes from parity-extract-mssql.mjs on the Windows box'
          : 'a web capture comes from parity-extract-pg.mjs after replaying the cases',
      );
    }
  }
  console.log(`desktop  ${relative(REPO, desktop)}`);
  console.log(`web      ${relative(REPO, web)}`);
  try {
    // The differ exits non-zero when the sides differ, which is the normal state today. Its own failure to
    // RUN is what matters here, so stderr is surfaced and the exit code is not treated as fatal.
    execFileSync('node', [resolve(WEB, 'apps/api/integration/parity-compare.mjs'), desktop, web], {
      cwd: WEB,
      encoding: 'utf8',
      stdio: ['ignore', 'pipe', 'pipe'],
    });
  } catch (err) {
    const out = `${err.stdout ?? ''}${err.stderr ?? ''}`;
    if (!/PARITY_COMPARE_(DIFF|MATCH)/.test(out)) {
      die('the comparison did not run', ...out.split('\n').filter(Boolean).slice(-6));
    }
  }
  diffPath = newest(G5, 'parity-diff-');
  if (!diffPath) die('the comparison produced no artefact', `expected under ${relative(REPO, G5)}`);
}

let report;
try {
  report = JSON.parse(readFileSync(diffPath, 'utf8'));
} catch {
  die('the diff artefact is unreadable', relative(REPO, diffPath));
}
if (report?.kind !== 'datacare.parity-diff/1.0') {
  die('not a parity diff artefact', `kind=${report?.kind}`, relative(REPO, diffPath));
}

const metrics = metricsFromDiff(report);
const perCase = perCaseFromDiff(report);
const caseIds = (report.cases ?? []).map((c) => String(c.caseId ?? '')).filter(Boolean);

// ---------------------------------------------------------------------------------------------------
// 2. Report the numbers.
// ---------------------------------------------------------------------------------------------------
const pct = agreementPct(metrics);
console.log(`\nartefact ${relative(REPO, diffPath)}`);
console.log(
  `captured desktop=${report.desktop?.capturedAt ?? '?'}  web=${report.web?.capturedAt ?? '?'}`,
);
console.log('\nD1 database parity');
console.log(`  cases matched          ${metrics.casesMatched} / ${metrics.cases}`);
console.log(
  `  fields                 ${metrics.fieldDifferences} differing of ${metrics.fieldsCompared} compared ` +
    `(${pct.toFixed(2)}% agree, ${metrics.fieldsExcluded} excluded)`,
);
console.log(`  rows                   ${metrics.rowsMissing} missing, ${metrics.rowsExtra} extra`);
console.log(
  `  tables                 ${metrics.tablesCompared} compared, ${metrics.tablesDesktopOnly} desktop-only, ` +
    `${metrics.tablesWebOnly} web-only`,
);

// ---------------------------------------------------------------------------------------------------
// 3. Evaluate against the ceiling.
// ---------------------------------------------------------------------------------------------------
let recorded = null;
if (existsSync(RATCHET)) {
  try {
    recorded = JSON.parse(readFileSync(RATCHET, 'utf8'));
  } catch {
    die('the recorded ratchet is unreadable', relative(REPO, RATCHET));
  }
}

const verdict = evaluateRatchet({ metrics, caseIds, perCase }, recorded);
console.log('\nratchet');
console.log(`  case set               ${verdict.caseSet}`);
if (verdict.addedCases.length) console.log(`  cases added            ${verdict.addedCases.length}`);
for (const n of verdict.notes) console.log(`  note                   ${n}`);
for (const i of verdict.improvements) console.log(`  IMPROVED               ${i}`);
for (const r of verdict.regressions) console.log(`  REGRESSED              ${r}`);

if (!verdict.ok) {
  console.error(
    '\nPARITY_RATCHET_REGRESSED a tracked parity number got worse; the listed items must be fixed',
  );
  console.error(
    '  a lower difference count achieved by comparing less is a regression, not progress',
  );
  if (has('--record')) {
    // Recording here would move the ceiling to the regressed value, which is a ratchet that ratchets both
    // ways — that is, not a ratchet. The earlier version of this script wrote the record before this check.
    console.error('  --record refused: a regressed run cannot become the new ceiling');
  }
  process.exit(1);
}

if (has('--record')) {
  const record = {
    recordedAt: new Date().toISOString(),
    // The certifier binds evidence to a commit: an artefact that does not name the release it was measured on
    // cannot be attributed to it, and is reported STALE rather than trusted.
    releaseSha: (process.env.RELEASE_SHA ?? '').trim().toLowerCase() || null,
    note:
      'Ceiling for pnpm parity:measure. Update only with a measured run that did not regress. ' +
      'See DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md Phase 0.',
    source: relative(REPO, diffPath),
    caseIds: [...caseIds].sort(),
    metrics,
    perCase,
  };
  writeFileSync(RATCHET, `${JSON.stringify(record, null, 2)}\n`);
  console.log(`\nrecorded ceiling -> ${relative(REPO, RATCHET)}`);
}

if (verdict.requiresRebaseline && !has('--record')) {
  console.log(
    '\nPARITY_RATCHET_UNBASELINED no comparable ceiling; re-run with --record to set one',
  );
} else {
  console.log('\nPARITY_RATCHET_OK no tracked parity number got worse');
}
