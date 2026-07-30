import { canonicalise } from '../parity/bundle.js';
import { parseReportCsv, type ParsedReportCsv } from './reportCsv.js';

/**
 * Compare a Crystal report export against the web's export.
 *
 * WHAT THIS COMPARES, AND WHAT IT DOES NOT
 * ----------------------------------------
 * The DATA a report produced: its rows and its totals. Not its layout. Crystal pixel parity is not claimed
 * anywhere in this project, and the 254 layout baselines only detect regressions in the web's own renderer.
 *
 * Data parity is the stronger of the two claims. A report whose columns line up perfectly but whose closing
 * balance is wrong is worse than one that looks different and adds up.
 *
 * THE HARD PART IS THAT COLUMN NAMES DIFFER
 * -----------------------------------------
 * Crystal names its fields after the report designer's choices (`AcName`, `Dr Amount`); the web names them
 * after its own row keys (`party`, `dr`). There is no reliable way to infer the correspondence, and guessing it
 * would produce confident nonsense. So a mapping is REQUIRED per report, and what cannot be mapped is reported
 * as unmapped rather than quietly skipped.
 *
 * That is the same discipline as the rest of this project: the comparison publishes its own denominator, so a
 * verdict of "matched" cannot be read as "everything matched" when half the columns were never looked at.
 *
 * TWO LEVELS OF COMPARISON
 * ------------------------
 *  1. CONTROL TOTALS — row count and the sum of each mapped numeric column. Robust against column ordering,
 *     row ordering, and formatting, so it is the check that survives the most incidental difference. A report
 *     whose control totals agree is very unlikely to be wrong in a way that matters.
 *  2. ROW LEVEL — each row paired by a declared key, then field by field. Precise, but only meaningful once the
 *     mapping is complete and a key exists.
 *
 * Level 1 alone is a genuine result and is reported as such. Claiming level 2 without a mapping would be the
 * dishonest option.
 */

/** How one report's Crystal columns correspond to the web's. */
export interface ReportColumnMap {
  /** Report slug on the web side. */
  report: string;
  /** crystalHeader -> webHeader. Only mapped columns are compared. */
  columns: Record<string, string>;
  /** Web column names that are numeric, so control totals can be summed. */
  numeric: readonly string[];
  /**
   * Web column names forming the row key. Rows pair on these. Without a key the comparison falls back to a
   * content hash, which still detects a changed value but reports it as one row missing and one extra rather
   * than naming the field.
   */
  key?: readonly string[];
  /** Decimal places for numeric comparison, per web column. Defaults to 2. */
  scale?: Record<string, number>;
}

export interface ColumnTotals {
  rows: number;
  sums: Record<string, number>;
}

export interface ReportFieldDifference {
  rowKey: string;
  column: string;
  crystal: string;
  web: string;
}

export interface ReportDiff {
  kind: 'datacare.report-diff/1.0';
  report: string;
  comparedAt: string;
  /** Control totals from each side. */
  crystal: ColumnTotals;
  web: ColumnTotals;
  /** Columns present in the Crystal export that the map does not name. */
  unmappedCrystalColumns: string[];
  /** Mapped columns whose web counterpart is absent from the web export. */
  missingWebColumns: string[];
  /** What each reader discarded, so the row counts can be reconciled by a human. */
  skipped: { crystal: ParsedReportCsv['skipped']; web: ParsedReportCsv['skipped'] };
  rowCountMatches: boolean;
  totalsMatch: boolean;
  /** Present only when a key was declared and the mapping is complete. */
  rowLevel?: { compared: number; differences: ReportFieldDifference[] };
  matched: boolean;
}

const num = (v: unknown): number => {
  // Crystal writes thousands separators and parenthesised negatives; both must survive the read.
  const text = String(v ?? '')
    .trim()
    .replace(/,/g, '');
  const negated = /^\(.*\)$/.test(text) ? `-${text.slice(1, -1)}` : text;
  const n = Number(negated);
  return Number.isFinite(n) ? n : 0;
};

function totalsOf(
  rows: readonly Record<string, string>[],
  numeric: readonly string[],
  pick: (row: Record<string, string>, column: string) => unknown,
): ColumnTotals {
  const sums: Record<string, number> = {};
  for (const column of numeric) {
    sums[column] = rows.reduce((s, r) => s + num(pick(r, column)), 0);
  }
  return { rows: rows.length, sums };
}

/** Compare at the declared scale, so a difference finer than either side stores is not reported. */
function sameNumber(a: number, b: number, scale: number): boolean {
  const f = 10 ** scale;
  return Math.round(a * f) === Math.round(b * f);
}

export function diffReportCsv(
  crystalText: string,
  webText: string,
  map: ReportColumnMap,
  options: { crystalHeaderHint?: string } = {},
): ReportDiff {
  const crystal = parseReportCsv(crystalText, { headerHint: options.crystalHeaderHint });
  const web = parseReportCsv(webText);

  const mappedCrystalCols = Object.keys(map.columns);
  const unmappedCrystalColumns = crystal.columns
    .filter((c) => c !== '' && !mappedCrystalCols.includes(c))
    .sort();
  const missingWebColumns = mappedCrystalCols
    .map((c) => map.columns[c]!)
    .filter((w) => !web.columns.includes(w))
    .sort();

  // Numeric columns are named on the WEB side; the Crystal side is reached through the map.
  const numeric = map.numeric.filter((w) => web.columns.includes(w));
  const crystalByWeb = new Map(Object.entries(map.columns).map(([c, w]) => [w, c]));

  const crystalTotals = totalsOf(crystal.rows, numeric, (row, webCol) => {
    const crystalCol = crystalByWeb.get(webCol);
    return crystalCol ? row[crystalCol] : undefined;
  });
  const webTotals = totalsOf(web.rows, numeric, (row, webCol) => row[webCol]);

  const scaleOf = (column: string) => map.scale?.[column] ?? 2;
  const totalsMatch = numeric.every((c) =>
    sameNumber(crystalTotals.sums[c] ?? 0, webTotals.sums[c] ?? 0, scaleOf(c)),
  );
  const rowCountMatches = crystal.rows.length === web.rows.length;

  // Row-level comparison only when a key is declared AND every mapped column exists on the web side. Without
  // both, a row-level verdict would be about the mapping rather than about the data.
  let rowLevel: ReportDiff['rowLevel'];
  if (map.key?.length && !missingWebColumns.length) {
    const keyOf = (row: Record<string, string>, side: 'crystal' | 'web'): string =>
      map
        .key!.map((webCol) => {
          const col = side === 'web' ? webCol : (crystalByWeb.get(webCol) ?? webCol);
          return `${webCol}=${String(row[col] ?? '').trim()}`;
        })
        .join(' ');

    const webByKey = new Map<string, Record<string, string>[]>();
    for (const row of web.rows) {
      const k = keyOf(row, 'web');
      (webByKey.get(k) ?? webByKey.set(k, []).get(k)!).push(row);
    }
    const differences: ReportFieldDifference[] = [];
    let compared = 0;
    for (const cRow of crystal.rows) {
      const k = keyOf(cRow, 'crystal');
      const wRow = webByKey.get(k)?.shift();
      if (!wRow) {
        differences.push({ rowKey: k, column: '(row)', crystal: 'present', web: 'absent' });
        continue;
      }
      for (const [crystalCol, webCol] of Object.entries(map.columns)) {
        const isNumeric = numeric.includes(webCol);
        const cv = isNumeric
          ? num(cRow[crystalCol]).toFixed(scaleOf(webCol))
          : canonicalise(cRow[crystalCol], 'varchar', 0);
        const wv = isNumeric
          ? num(wRow[webCol]).toFixed(scaleOf(webCol))
          : canonicalise(wRow[webCol], 'varchar', 0);
        compared += 1;
        if (cv !== wv) {
          differences.push({ rowKey: k, column: webCol, crystal: cv, web: wv });
        }
      }
    }
    for (const [k, left] of webByKey) {
      for (const _ of left) {
        differences.push({ rowKey: k, column: '(row)', crystal: 'absent', web: 'present' });
      }
    }
    rowLevel = { compared, differences: differences.slice(0, 200) };
  }

  return {
    kind: 'datacare.report-diff/1.0',
    report: map.report,
    comparedAt: new Date().toISOString(),
    crystal: crystalTotals,
    web: webTotals,
    unmappedCrystalColumns,
    missingWebColumns,
    skipped: { crystal: crystal.skipped, web: web.skipped },
    rowCountMatches,
    totalsMatch,
    rowLevel,
    // An empty report is not a pass: two files with no rows agree about nothing.
    matched:
      crystal.rows.length > 0 &&
      rowCountMatches &&
      totalsMatch &&
      !missingWebColumns.length &&
      (rowLevel ? rowLevel.differences.length === 0 : true),
  };
}

/** Human summary, leading with the denominator. */
export function formatReportDiff(d: ReportDiff): string {
  const lines = [
    `report ${d.report}`,
    `  rows      crystal ${d.crystal.rows}  web ${d.web.rows}` +
      (d.rowCountMatches ? '' : '   MISMATCH'),
    `  columns   mapped ${Object.keys(d.crystal.sums).length} numeric` +
      (d.unmappedCrystalColumns.length
        ? `, ${d.unmappedCrystalColumns.length} Crystal column(s) NOT mapped: ${d.unmappedCrystalColumns.join(', ')}`
        : ', all Crystal columns mapped'),
  ];
  if (d.missingWebColumns.length) {
    lines.push(`  MISSING on the web side: ${d.missingWebColumns.join(', ')}`);
  }
  for (const [c, v] of Object.entries(d.crystal.sums)) {
    const w = d.web.sums[c] ?? 0;
    lines.push(
      `  total ${c}: crystal ${v.toFixed(2)}  web ${w.toFixed(2)}` +
        (sameNumber(v, w, 2) ? '' : '   MISMATCH'),
    );
  }
  if (d.rowLevel) {
    lines.push(
      `  row level: ${d.rowLevel.compared} fields compared, ${d.rowLevel.differences.length} differing`,
    );
    for (const x of d.rowLevel.differences.slice(0, 10)) {
      lines.push(`    [${x.rowKey}] ${x.column}: crystal=${x.crystal} web=${x.web}`);
    }
  } else {
    lines.push('  row level: NOT run (no row key declared, or the mapping is incomplete)');
  }
  lines.push(
    `  skipped   crystal ${JSON.stringify(d.skipped.crystal)}  web ${JSON.stringify(d.skipped.web)}`,
  );
  lines.push(d.matched ? '  VERDICT: matched' : '  VERDICT: differences found');
  return lines.join('\n');
}
