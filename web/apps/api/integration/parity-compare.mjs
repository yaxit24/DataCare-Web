#!/usr/bin/env node
/**
 * Compare two parity bundles and write the retained evidence artifact.
 *
 * Runs anywhere — it needs only two JSON files, not a database. That is the point of the bundle split: the
 * comparison logic is exercised by unit tests here, and the expensive Windows session only has to produce an
 * extract.
 *
 * USAGE
 *   node apps/api/integration/parity-compare.mjs \
 *     project-memory/parity/bundles/desktop-latest.json \
 *     project-memory/parity/bundles/web-latest.json
 *
 * Exit codes
 *   0  every shared case matched, and no case was missing from either side
 *   1  a difference was found, or a case was captured on only one side
 *   2  a bundle is unreadable or is not a parity bundle
 */

import { mkdir, readFile, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = dirname(fileURLToPath(import.meta.url));
const REPO = resolve(HERE, '../../..');
const OUT_DIR = resolve(REPO, '..', 'project-memory', 'parity', 'g5');

async function loadBundle(path, expectedSide) {
  let parsed;
  try {
    parsed = JSON.parse(await readFile(path, 'utf8'));
  } catch (e) {
    console.error(`PARITY_COMPARE_FAIL cannot read ${path}: ${e instanceof Error ? e.message : e}`);
    process.exit(2);
  }
  if (parsed?.kind !== 'datacare.parity-bundle/1.0') {
    console.error(`PARITY_COMPARE_FAIL ${path} is not a datacare.parity-bundle/1.0`);
    process.exit(2);
  }
  if (parsed.side !== expectedSide) {
    // Swapping the arguments would invert every difference and read as though the web were authoritative.
    console.error(
      `PARITY_COMPARE_FAIL ${path} declares side="${parsed.side}" but was passed as the ${expectedSide} bundle`,
    );
    process.exit(2);
  }
  return parsed;
}

async function main() {
  const [desktopPath, webPath] = process.argv.slice(2);
  if (!desktopPath || !webPath) {
    console.error('usage: parity-compare.mjs <desktop-bundle.json> <web-bundle.json>');
    process.exit(2);
  }

  // The differ is compiled TypeScript, so the API build must have run.
  let diffBundles, formatDiff;
  try {
    ({ diffBundles, formatDiff } = await import(
      resolve(REPO, 'apps/api/dist/modules/parity/bundleDiff.js')
    ));
  } catch {
    console.error(
      'PARITY_COMPARE_FAIL apps/api/dist/modules/parity/bundleDiff.js is missing. Run: pnpm build',
    );
    process.exit(2);
  }

  const desktop = await loadBundle(resolve(process.cwd(), desktopPath), 'desktop');
  const web = await loadBundle(resolve(process.cwd(), webPath), 'web');

  const report = diffBundles(desktop, web);
  console.log(formatDiff(report));

  await mkdir(OUT_DIR, { recursive: true });
  const stamp = report.comparedAt.replace(/[:.]/g, '-');
  const path = resolve(OUT_DIR, `parity-diff-${stamp}.json`);
  await writeFile(path, `${JSON.stringify(report, null, 1)}\n`, 'utf8');
  await writeFile(
    resolve(OUT_DIR, 'parity-diff-latest.json'),
    `${JSON.stringify(report, null, 1)}\n`,
    'utf8',
  );

  const t = report.totals;
  if (report.matched) {
    console.log(
      `\nPARITY_COMPARE_OK ${t.casesMatched}/${t.cases} cases, ${t.fieldsCompared} fields compared -> ${path}`,
    );
    process.exit(0);
  }
  console.error(
    `\nPARITY_COMPARE_DIFF ${t.cases - t.casesMatched} of ${t.cases} case(s) differ; ` +
      `${t.fieldDifferences} field difference(s), ${t.rowsMissing} missing row(s), ` +
      `${t.tablesDesktopOnly} table(s) the web never wrote -> ${path}`,
  );
  process.exit(1);
}

main().catch((e) => {
  console.error(`PARITY_COMPARE_FAIL ${e instanceof Error ? e.message : String(e)}`);
  process.exit(2);
});
