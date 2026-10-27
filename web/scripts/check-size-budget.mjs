#!/usr/bin/env node
/**
 * Source file-size budget ratchet (N95 / G79, SP03).
 *
 * WHY THIS EXISTS
 * `routes/txn.ts` is 8,558 lines and nine modules exceed 1,500; G79 records this as a maintainability risk
 * that N88 reduces by extracting per-module route plugins and a shared voucher editor. Nothing stopped those
 * files from growing further in the meantime. This gate freezes each large file's line count as a CEILING
 * that may only fall, and caps any NEW source file, so the extraction can only shrink the tree — never the
 * reverse — and a raised ceiling is a visible baseline diff in review rather than a silent regression.
 *
 * WHAT IT ENFORCES
 *   • Every file already in the baseline must stay at or below its recorded line count (a ceiling).
 *   • A file not in the baseline must be at or below DEFAULT_CAP lines.
 *   • A file that has shrunk is reported so `--write` tightens its ceiling (ceilings only fall).
 *
 * The baseline is data, so it can be edited — what makes the ratchet real is that a loosened ceiling shows as
 * a baseline diff, and `--audit` re-derives every count from source so a hand-edited baseline cannot hide a
 * file that actually grew.
 *
 * Usage:
 *   node scripts/check-size-budget.mjs           # ratchet
 *   node scripts/check-size-budget.mjs --audit    # print all measured counts, no pass/fail
 *   node scripts/check-size-budget.mjs --write     # (re)record/tighten the baseline; review the diff
 */
import { readFileSync, writeFileSync, existsSync, readdirSync, statSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve, relative, join } from 'node:path';

const here = dirname(fileURLToPath(import.meta.url));
const root = resolve(here, '..');
const BASELINE = resolve(root, 'parity', 'size-budget.json');

/** New source files may not exceed this many lines without being added to the baseline deliberately. */
const DEFAULT_CAP = 1500;

/**
 * Pure evaluation: given measured line counts and a baseline, return violations (a file over its ceiling or
 * the default cap) and files that have shrunk below their recorded ceiling. Exported for the ratchet's test.
 */
export function evaluateBudget(counts, baseline) {
  const ceilings = baseline?.ceilings ?? {};
  const cap = baseline?.defaultCap ?? DEFAULT_CAP;
  const violations = [];
  const shrunk = [];
  for (const [path, lines] of Object.entries(counts)) {
    const ceiling = ceilings[path] ?? cap;
    if (lines > ceiling) {
      violations.push(
        `${path}: ${lines} lines exceeds its ${ceilings[path] != null ? 'ceiling' : 'default cap'} of ${ceiling}`,
      );
    } else if (ceilings[path] != null && lines < ceilings[path]) {
      shrunk.push(`${path}: ${lines} < recorded ${ceilings[path]} — run --write to tighten`);
    }
  }
  return { violations, shrunk, cap, tracked: Object.keys(ceilings).length };
}

const SOURCE_ROOTS = [
  'apps/api/src',
  'apps/web/app',
  'apps/web/components',
  'apps/web/lib',
  'packages',
];
const IGNORED_DIR = new Set(['node_modules', '.next', '.turbo', 'dist', 'coverage', 'generated']);
const isSource = (p) => /\.(ts|tsx)$/.test(p);
const isTest = (p) =>
  /(?:^|\/)test(?:s)?\//.test(p) || /\.test\.[cm]?tsx?$/.test(p) || /\/integration\//.test(p);

function* walk(dir) {
  let entries;
  try {
    entries = readdirSync(dir, { withFileTypes: true });
  } catch {
    return;
  }
  for (const e of entries) {
    if (IGNORED_DIR.has(e.name)) continue;
    const p = join(dir, e.name);
    if (e.isDirectory()) yield* walk(p);
    else if (isSource(p)) yield p;
  }
}

/** Measure every non-test source file's line count, keyed by repo-relative path. */
function measure() {
  const counts = {};
  for (const r of SOURCE_ROOTS) {
    for (const abs of walk(resolve(root, r))) {
      const rel = relative(root, abs);
      if (isTest(rel)) continue;
      const lines = readFileSync(abs, 'utf8').split('\n').length;
      counts[rel] = lines;
    }
  }
  return counts;
}

const argv = process.argv.slice(2);
const has = (f) => argv.includes(f);

// Only run the CLI when executed directly (`node check-size-budget.mjs`); the test imports evaluateBudget.
const invokedDirectly = resolve(process.argv[1] ?? '') === fileURLToPath(import.meta.url);
if (!invokedDirectly) {
  // Imported as a module: expose evaluateBudget only, do not scan the tree or exit.
} else {
  runCli();
}

function runCli() {
  const counts = measure();

  if (has('--audit')) {
    const sorted = Object.entries(counts).sort((a, b) => b[1] - a[1]);
    for (const [path, lines] of sorted) console.log(`${String(lines).padStart(6)}  ${path}`);
    process.exit(0);
  }

  if (has('--write') || !existsSync(BASELINE)) {
    // Record every file that is over the default cap as an explicit ceiling at its current size; smaller
    // files are governed by DEFAULT_CAP and need no entry.
    const ceilings = {};
    for (const [path, lines] of Object.entries(counts)) {
      if (lines > DEFAULT_CAP) ceilings[path] = lines;
    }
    // Tighten: if the baseline already had a file that has since shrunk, record the smaller number.
    if (existsSync(BASELINE)) {
      const prev = JSON.parse(readFileSync(BASELINE, 'utf8')).ceilings ?? {};
      for (const [path, prevMax] of Object.entries(prev)) {
        if (counts[path] != null && counts[path] <= DEFAULT_CAP) continue; // dropped below the cap
        if (counts[path] != null) ceilings[path] = Math.min(prevMax, counts[path]);
      }
    }
    const body = {
      kind: 'size-budget',
      note:
        'Per-file line ceilings (may only fall). Files at or below defaultCap need no entry. A raised ' +
        'ceiling or a new over-cap file is a reviewed baseline diff. Counts are re-derived by --audit.',
      defaultCap: DEFAULT_CAP,
      ceilings: Object.fromEntries(Object.entries(ceilings).sort((a, b) => b[1] - a[1])),
    };
    writeFileSync(BASELINE, JSON.stringify(body, null, 2) + '\n');
    console.log(
      `Wrote ${BASELINE} with ${Object.keys(ceilings).length} ceiling(s), defaultCap ${DEFAULT_CAP}.`,
    );
    console.log(
      'Review the diff: a raised ceiling is a maintainability regression being accepted.',
    );
    process.exit(0);
  }

  const baseline = JSON.parse(readFileSync(BASELINE, 'utf8'));
  const { violations, shrunk, cap, tracked } = evaluateBudget(counts, baseline);

  if (violations.length) {
    console.error(`Size budget failed with ${violations.length} violation(s):`);
    for (const v of violations) console.error(`- ${v}`);
    console.error(
      'Split the file (extract a module/plugin) or, only with review, raise its ceiling via --write.',
    );
    process.exit(1);
  }

  console.log(
    `Size budget OK: ${Object.keys(counts).length} source files, ${tracked} tracked ceiling(s), cap ${cap}.` +
      (shrunk.length
        ? ` ${shrunk.length} file(s) shrank below their ceiling (tighten with --write).`
        : ''),
  );
}
