#!/usr/bin/env node
/**
 * Compare a Crystal report export against the web's export of the same report.
 *
 * Compares the DATA — rows and totals — not the layout. Crystal pixel parity is not claimed anywhere in this
 * project, and the 254 layout baselines only detect regressions in the web's own renderer.
 *
 * USAGE
 *   node apps/api/integration/report-compare.mjs <crystal.csv> <web.csv> <map.json>
 *
 * The map is required because Crystal names its fields after the report designer's choices and the web names
 * them after its own row keys. There is no reliable way to infer the correspondence, and guessing would produce
 * confident nonsense. A column the map does not name is REPORTED as unmapped, never silently dropped.
 *
 * Map shape (see ReportColumnMap):
 *   {
 *     "report":  "day-book",
 *     "columns": { "VchNo": "vchNo", "AcName": "party", "Dr Amount": "dr", "Cr Amount": "cr" },
 *     "numeric": ["dr", "cr"],
 *     "key":     ["vchNo", "party"],
 *     "scale":   { "dr": 2, "cr": 2 },
 *     "crystalHeaderHint": "VchNo"
 *   }
 *
 * Getting the two inputs:
 *   Crystal  open the report in DataCareNext, Export -> CSV
 *   Web      GET /reports/<slug>/export.csv
 * Use the SAME date range and filters on both sides, or the comparison is about the parameters rather than the
 * arithmetic.
 *
 * Exit codes
 *   0  matched
 *   1  differences found
 *   2  a file or the map could not be read
 */

import { mkdir, readFile, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = dirname(fileURLToPath(import.meta.url));
const REPO = resolve(HERE, '../../..');
const OUT_DIR = resolve(REPO, '..', 'project-memory', 'parity', 'reports');

async function readOrDie(path, what) {
  try {
    return await readFile(resolve(process.cwd(), path), 'utf8');
  } catch (e) {
    console.error(
      `REPORT_COMPARE_FAIL cannot read ${what} at ${path}: ${e instanceof Error ? e.message : e}`,
    );
    process.exit(2);
  }
}

const [crystalPath, webPath, mapPath] = process.argv.slice(2);
if (!crystalPath || !webPath || !mapPath) {
  console.error('usage: report-compare.mjs <crystal.csv> <web.csv> <map.json>');
  process.exit(2);
}

const crystalText = await readOrDie(crystalPath, 'the Crystal export');
const webText = await readOrDie(webPath, 'the web export');
const mapText = await readOrDie(mapPath, 'the column map');

let map;
try {
  map = JSON.parse(mapText);
} catch (e) {
  console.error(
    `REPORT_COMPARE_FAIL the column map is not valid JSON: ${e instanceof Error ? e.message : e}`,
  );
  process.exit(2);
}
for (const required of ['report', 'columns', 'numeric']) {
  if (map?.[required] === undefined) {
    console.error(`REPORT_COMPARE_FAIL the column map is missing "${required}"`);
    process.exit(2);
  }
}

let diffReportCsv, formatReportDiff;
try {
  ({ diffReportCsv, formatReportDiff } = await import(
    resolve(REPO, 'apps/api/dist/modules/reports/reportDiff.js')
  ));
} catch {
  console.error(
    'REPORT_COMPARE_FAIL apps/api/dist/modules/reports/reportDiff.js is missing. Run: pnpm build',
  );
  process.exit(2);
}

const diff = diffReportCsv(crystalText, webText, map, {
  crystalHeaderHint: map.crystalHeaderHint,
});
console.log(formatReportDiff(diff));

await mkdir(OUT_DIR, { recursive: true });
const stamp = diff.comparedAt.replace(/[:.]/g, '-');
const out = resolve(OUT_DIR, `${map.report}-${stamp}.json`);
await writeFile(out, `${JSON.stringify(diff, null, 1)}\n`, 'utf8');

if (diff.matched) {
  console.log(`\nREPORT_COMPARE_OK ${map.report}: ${diff.crystal.rows} rows -> ${out}`);
  process.exit(0);
}
console.error(`\nREPORT_COMPARE_DIFF ${map.report}: see ${out}`);
process.exit(1);
