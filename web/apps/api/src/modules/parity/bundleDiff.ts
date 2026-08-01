import {
  canonicalise,
  comparisonScale,
  exclusionReason,
  NULL_SENTINEL,
  type BundleCase,
  type BundleColumn,
  type BundleTable,
  type ParityBundle,
} from './bundle.js';

/**
 * The desktop-vs-web differ.
 *
 * Replaces a comparison that could not fail. The predecessor had six proven defects, each demonstrated by
 * executing its own helpers:
 *
 *  1. every `Date` canonicalised to `''`, so 64 date/datetime columns across 42 tables always matched —
 *     a voucher dated 2099-01-01 compared equal to one dated 2024-06-10, and a real date compared equal to
 *     NULL;
 *  2. values rounded to 3 decimals, so 1.5000 and 1.5004 matched even though `ITM_WEST_PRC` stores scale 4;
 *  3. NULL and the empty string were the same value;
 *  4. numeric agreement was judged by comparing column SUMS, so `[100, -100]` matched `[250, -250]`;
 *  5. text was upper-cased, so a genuine code difference `abc` vs `ABC` matched;
 *  6. worst — the table set was the INTERSECTION of both schemas, so a table the desktop writes and the web
 *     does not was silently excluded. The harness could not detect a missing write, which is the single most
 *     important parity failure for a voucher.
 *
 * This differ inverts all six: dates are compared, precision comes from the declared scale, NULL is distinct,
 * every ROW is compared rather than a sum, text case is preserved, and the table set is the UNION so a missing
 * write is a finding.
 *
 * It also reports its own denominator. A verdict of "matched" is meaningless without knowing how many fields
 * were looked at, so `fieldsCompared` and `fieldsExcluded` travel with every result.
 */

/** Business keys used to pair rows within a table, in priority order. */
export const ROW_KEYS: Record<string, readonly string[]> = {
  // Detail lines are identified by their line serial.
  SL_DETL: ['SR_NO'],
  PR_DETL: ['SR_NO'],
  SL_DETL_RTN: ['SR_NO'],
  SL_IDTL: ['SR_NO', 'TAG_NO'],
  BAR_IDTL: ['SR_NO', 'TAG_NO'],
  LBR_ISU_DETL: ['SR_NO'],
  KR_DETL: ['SR_NO'],
  MFG_DETL: ['SR_NO'],
  // Tag rows are identified by the tag instance.
  BAR_DETL: ['TAG_NO', 'VCH_SRNO'],
  // IT_CODE leads, because the other three cannot tell two lines apart on an UNTAGGED sale - TAG_NO 'N',
  // VCH_SRNO 0 and ITM_SIGN '-' are constant across every line, so a real two-line invoice had desktop line 2
  // compared against web line 1 and every numeric column in both rows reported a difference.
  //
  // SR_NO deliberately does NOT lead: the desktop writes SR_NO 1 on BOTH rows of a two-line sale and
  // distinguishes them by TAG_NO, while the web numbers them 1 and 2. Keying on it would preserve the
  // mispairing and hide the numbering difference itself, which is a finding worth keeping visible.
  // A KEY COLUMN MUST NOT BE A COLUMN UNDER TEST. TAG_NO and VCH_SRNO are exactly the columns the comparison
  // is examining - the desktop sold a tagged instance (TAG_NO 'MAS00013', VCH_SRNO a 12-digit composite) where
  // the web wrote 'N' and 0 - so including them in the key GUARANTEES the rows cannot pair, which then hides
  // every other difference in that row behind a missing/extra pair or a forced one.
  //
  // Adding IT_CODE fixed the cross-line mispairing but left TAG_NO in place, so MAIN_STOCK was still being
  // force-paired one row at a time. The forced-pair report is what made that visible.
  //
  // What remains is stable identity for a stock movement: which item, which direction. Two lines of the same
  // item in the same direction would collide, and that case falls through to the content key rather than being
  // mispaired.
  MAIN_STOCK: ['IT_CODE', 'ITM_SIGN'],
  // ROJ_MEL_DATA's primary key is LEDR_KEY ALONE, and the web reproduces it byte-for-byte - asserted in
  // rojmel.test.ts against the real 33-character example '01002024-20250270000101         1'. So it is
  // legitimate identity here rather than a column under test.
  //
  // Without this entry the table fell back to the CONTENT key, where any single differing field changes the
  // key and the row cannot pair. The real comparison therefore reported ROJ_MEL_DATA as 4 rows missing, 5 rows
  // extra and ZERO differences - which reads as agreement and is nothing of the kind. The most-worked
  // subsystem in the project, 3179 real rows and nine builders, had never actually been compared field by
  // field.
  ROJ_MEL_DATA: ['LEDR_KEY'],
  BAR_CAN_DETL: ['TAG_NO', 'VCH_SRNO'],
  // Ledger rows are identified by account and side. Several rows can share an account, so the amount pair is
  // part of the key.
  AC_DATA: ['AC_CODE', 'DR_AMT', 'CR_AMT'],
  TAX_DATA: ['TAX_CODE', 'IT_TAX_AMT'],
  CASH_DATA: ['AC_CODE', 'DR_AMT', 'CR_AMT'],
};

export interface FieldDifference {
  table: string;
  /** Business key of the row, rendered for a human reader. */
  rowKey: string;
  column: string;
  desktop: string;
  web: string;
  /** Decimal places the comparison used, so the reader knows how tight it was. */
  scale?: number;
}

export interface TableDiff {
  table: string;
  presentOn: 'both' | 'desktop-only' | 'web-only';
  desktopRows: number;
  webRows: number;
  /** Rows the desktop wrote that the web did not produce. */
  missingRows: string[];
  /** Rows the web produced that the desktop did not. */
  extraRows: string[];
  /** Columns the desktop has that the web's schema lacks entirely. */
  missingColumns: string[];
  fieldsCompared: number;
  fieldsExcluded: number;
  /**
   * Rows compared by FORCE rather than by key: one row left unpaired on each side, so they are compared
   * field-by-field because that yields more information than reporting one missing plus one extra.
   *
   * Surfaced because it is the differ's only signal that its own PAIRING may be wrong. The shortcut is useful -
   * it is why `SL_DATA` was compared at all while the row keys were defective - but it also means a broken key
   * on a single-row table looks perfectly clean: the rows get compared anyway, and if their values agree there
   * is nothing to report. A regression test for the key defect passed against broken code for exactly this
   * reason.
   *
   * So a non-zero count here on a table that OUGHT to pair by key is a warning, not a detail.
   */
  forcedPairs: number;
  differences: FieldDifference[];
}

export interface CaseDiff {
  caseId: string;
  description: string;
  desktopVoucher: string;
  webVoucher: string;
  matched: boolean;
  tables: TableDiff[];
  totals: {
    tablesCompared: number;
    tablesDesktopOnly: number;
    tablesWebOnly: number;
    rowsMissing: number;
    rowsExtra: number;
    fieldsCompared: number;
    fieldsExcluded: number;
    fieldDifferences: number;
  };
}

/**
 * Provenance carried from a bundle into the report.
 *
 * `appVersion` and `host` MUST be propagated. The G5 gate decides whether an artifact is real evidence or the
 * synthetic bundle used to prove the differ, and it can only do that if the provenance survives the
 * comparison. An earlier version of this type dropped both fields, and the gate consequently certified
 * synthetic data as desktop-compared parity — the precise failure it exists to prevent.
 */
export interface SideProvenance {
  capturedAt: string;
  database: string;
  engine: string;
  /** For SQL Server, the `@@VERSION` banner. The gate requires a real one. */
  appVersion?: string;
  host?: string;
}

export interface BundleDiffReport {
  kind: 'datacare.parity-diff/1.0';
  comparedAt: string;
  desktop: SideProvenance;
  web: SideProvenance;
  matched: boolean;
  cases: CaseDiff[];
  /** Cases present on one side only — a case never entered is not a pass. */
  desktopOnlyCases: string[];
  webOnlyCases: string[];
  totals: CaseDiff['totals'] & { cases: number; casesMatched: number };
}

const upper = (s: string) => s.toUpperCase();

/** Index a table's columns by upper-case name. */
function columnIndex(table: BundleTable): Map<string, { column: BundleColumn; at: number }> {
  const map = new Map<string, { column: BundleColumn; at: number }>();
  table.columns.forEach((column, at) => map.set(upper(column.name), { column, at }));
  return map;
}

/**
 * Key for pairing a row with its counterpart.
 *
 * A declared business key is used where one exists. Otherwise the key is a hash of every COMPARED field,
 * which means identical rows pair with each other and genuinely different rows show up as one missing and one
 * extra — rather than being mispaired and producing a shower of phantom field differences, which is what
 * index-based pairing did.
 */
function rowKeyOf(
  table: string,
  row: unknown[],
  index: Map<string, { column: BundleColumn; at: number }>,
  comparedColumns: string[],
  // The COUNTERPART side's columns, so a key is built at the scale both sides can express.
  //
  // Without this the key was built with `comparisonScale(hit.column, hit.column)` - the same column twice,
  // i.e. that side's own scale - and SQL Server numeric(18,6) against Postgres numeric(_,2) rendered the same
  // serial as `SR_NO=1` on one side and `SR_NO=1.000000` on the other. The keys never matched, so the rows
  // never paired.
  //
  // That silently disabled comparison of the two most important tables. AC_DATA (all three ledger legs) and
  // SL_DETL (both lines) were reported as "missing" plus "extra" instead of being diffed, and a real
  // difference in SL_DETL.ITM_AMT - 354.00 against 354.20 - went unreported through three consecutive runs
  // while the field count looked healthy at 271.
  otherIndex?: Map<string, { column: BundleColumn; at: number }>,
): string {
  const scaleFor = (name: string, hit: { column: BundleColumn; at: number }) =>
    comparisonScale(hit.column, otherIndex?.get(upper(name))?.column ?? hit.column);
  const declared = ROW_KEYS[upper(table)];
  const parts: string[] = [];
  if (declared) {
    for (const name of declared) {
      const hit = index.get(upper(name));
      if (!hit) continue;
      parts.push(`${name}=${canonicalise(row[hit.at], hit.column.type, scaleFor(name, hit))}`);
    }
    if (parts.length) return parts.join(' ');
  }
  // Content key. Deterministic and order-independent of the column layout.
  const fields = comparedColumns
    .map((name) => {
      const hit = index.get(upper(name));
      if (!hit) return `${name}=`;
      return `${name}=${canonicalise(row[hit.at], hit.column.type, scaleFor(name, hit))}`;
    })
    .sort();
  return `content:${fields.join('|')}`;
}

function diffTable(
  table: string,
  desktop: BundleTable | undefined,
  web: BundleTable | undefined,
): TableDiff {
  const presentOn: TableDiff['presentOn'] =
    desktop && web ? 'both' : desktop ? 'desktop-only' : 'web-only';

  const dIndex = desktop ? columnIndex(desktop) : new Map();
  const wIndex = web ? columnIndex(web) : new Map();

  // Column set for comparison: the DESKTOP's columns are authoritative, because the question is whether the
  // web reproduced what the desktop wrote. A column only the web has is not a parity failure.
  const desktopColumns = desktop?.columns ?? [];
  const excluded = desktopColumns.filter((c) => exclusionReason(c.name)).length;
  const comparable = desktopColumns.filter((c) => !exclusionReason(c.name));
  const missingColumns = comparable
    .filter((c) => !wIndex.has(upper(c.name)))
    .map((c) => c.name)
    .sort();
  const comparedColumns = comparable.filter((c) => wIndex.has(upper(c.name))).map((c) => c.name);

  const differences: FieldDifference[] = [];
  // Counted at function scope because the return is outside the both-sides branch where forcing happens.
  let forcedPairCount = 0;
  const missingRows: string[] = [];
  const extraRows: string[] = [];
  let fieldsCompared = 0;

  if (presentOn === 'both' && desktop && web) {
    // Pair rows by key. Multiple rows can share a key (the key is a multiset), so each side keeps a queue.
    const bucket = (t: BundleTable, idx: typeof dIndex) => {
      const m = new Map<string, unknown[][]>();
      for (const row of t.rows) {
        const k = rowKeyOf(table, row, idx, comparedColumns, idx === dIndex ? wIndex : dIndex);
        const list = m.get(k);
        if (list) list.push(row);
        else m.set(k, [row]);
      }
      return m;
    };
    const dRows = bucket(desktop, dIndex);
    const wRows = bucket(web, wIndex);

    /**
     * Pair rows that a content key could not match, so a changed value yields FIELD-LEVEL evidence.
     *
     * Header tables (`SL_DATA`, `PR_DATA`, …) have one row per voucher and no line serial, so they fall back
     * to a content key. Any changed field then alters that key, the row fails to pair, and the report says
     * "1 missing row" without naming what diverged — technically a detection, but useless as evidence.
     *
     * Two pairings are unambiguous and are therefore applied:
     *  * exactly one row on each side — they must correspond;
     *  * after keyed matching, exactly one leftover on each side — likewise.
     *
     * Anything more ambiguous is deliberately left as missing/extra rather than guessed at, because
     * mispairing is what produced showers of phantom differences in the predecessor.
     */
    const unpairedD: unknown[][] = [];
    const unpairedW: unknown[][] = [];
    const forcedPairs: Array<[unknown[], unknown[], string]> = [];

    for (const [key, dList] of dRows) {
      const wList = wRows.get(key) ?? [];
      const pairs = Math.min(dList.length, wList.length);
      for (let i = 0; i < pairs; i += 1) {
        for (const name of comparedColumns) {
          const dHit = dIndex.get(upper(name))!;
          const wHit = wIndex.get(upper(name))!;
          const scale = comparisonScale(dHit.column, wHit.column);
          const dv = canonicalise(dList[i]![dHit.at], dHit.column.type, scale);
          const wv = canonicalise(wList[i]![wHit.at], wHit.column.type, scale);
          fieldsCompared += 1;
          if (dv !== wv) {
            differences.push({
              table,
              rowKey: key.startsWith('content:') ? `${key.slice(0, 80)}…` : key,
              column: name,
              desktop: dv === NULL_SENTINEL ? '(null)' : dv,
              web: wv === NULL_SENTINEL ? '(null)' : wv,
              scale,
            });
          }
        }
      }
      for (let i = pairs; i < dList.length; i += 1) unpairedD.push(dList[i]!);
    }
    for (const [, wList] of wRows) {
      const key = rowKeyOf(table, wList[0]!, wIndex, comparedColumns, dIndex);
      const dCount = dRows.get(key)?.length ?? 0;
      for (let i = dCount; i < wList.length; i += 1) unpairedW.push(wList[i]!);
    }

    if (unpairedD.length === 1 && unpairedW.length === 1) {
      forcedPairs.push([unpairedD[0]!, unpairedW[0]!, 'single unmatched row']);
      forcedPairCount += 1;
    } else {
      for (const row of unpairedD)
        missingRows.push(rowKeyOf(table, row, dIndex, comparedColumns, wIndex));
      for (const row of unpairedW)
        extraRows.push(rowKeyOf(table, row, wIndex, comparedColumns, dIndex));
    }

    for (const [dRow, wRow, label] of forcedPairs) {
      for (const name of comparedColumns) {
        const dHit = dIndex.get(upper(name))!;
        const wHit = wIndex.get(upper(name))!;
        const scale = comparisonScale(dHit.column, wHit.column);
        const dv = canonicalise(dRow[dHit.at], dHit.column.type, scale);
        const wv = canonicalise(wRow[wHit.at], wHit.column.type, scale);
        fieldsCompared += 1;
        if (dv !== wv) {
          differences.push({
            table,
            rowKey: label,
            column: name,
            desktop: dv === NULL_SENTINEL ? '(null)' : dv,
            web: wv === NULL_SENTINEL ? '(null)' : wv,
            scale,
          });
        }
      }
    }
  } else if (presentOn === 'desktop-only' && desktop) {
    // The web never wrote this table. Every desktop row is a missing write.
    for (const row of desktop.rows) missingRows.push(rowKeyOf(table, row, dIndex, comparedColumns));
  } else if (presentOn === 'web-only' && web) {
    for (const row of web.rows) extraRows.push(rowKeyOf(table, row, wIndex, comparedColumns));
  }

  return {
    table,
    presentOn,
    desktopRows: desktop?.rows.length ?? 0,
    webRows: web?.rows.length ?? 0,
    forcedPairs: forcedPairCount,
    missingRows: missingRows.slice(0, 50),
    extraRows: extraRows.slice(0, 50),
    missingColumns,
    fieldsCompared,
    fieldsExcluded: excluded,
    differences: differences.slice(0, 200),
  };
}

function diffCase(desktop: BundleCase, web: BundleCase): CaseDiff {
  // UNION of table names, not intersection: a table the desktop wrote and the web did not is the most
  // important finding this harness can produce, and the predecessor discarded exactly that case.
  const names = [
    ...new Set([...Object.keys(desktop.tables), ...Object.keys(web.tables)].map(upper)),
  ].sort();

  const tables = names
    .map((name) => diffTable(name, desktop.tables[name], web.tables[name]))
    .filter((t) => t.desktopRows > 0 || t.webRows > 0);

  const totals = {
    tablesCompared: tables.filter((t) => t.presentOn === 'both').length,
    tablesDesktopOnly: tables.filter((t) => t.presentOn === 'desktop-only').length,
    tablesWebOnly: tables.filter((t) => t.presentOn === 'web-only').length,
    rowsMissing: tables.reduce((n, t) => n + t.missingRows.length, 0),
    rowsExtra: tables.reduce((n, t) => n + t.extraRows.length, 0),
    fieldsCompared: tables.reduce((n, t) => n + t.fieldsCompared, 0),
    fieldsExcluded: tables.reduce((n, t) => n + t.fieldsExcluded, 0),
    fieldDifferences: tables.reduce((n, t) => n + t.differences.length, 0),
  };
  const missingColumnCount = tables.reduce((n, t) => n + t.missingColumns.length, 0);

  return {
    caseId: desktop.caseId,
    description: desktop.description || web.description,
    desktopVoucher: `${desktop.voucher.book}/${desktop.voucher.vchNo}`,
    webVoucher: `${web.voucher.book}/${web.voucher.vchNo}`,
    matched:
      totals.fieldDifferences === 0 &&
      totals.rowsMissing === 0 &&
      totals.rowsExtra === 0 &&
      totals.tablesDesktopOnly === 0 &&
      missingColumnCount === 0,
    tables,
    totals,
  };
}

export function diffBundles(desktop: ParityBundle, web: ParityBundle): BundleDiffReport {
  const dById = new Map(desktop.cases.map((c) => [c.caseId, c]));
  const wById = new Map(web.cases.map((c) => [c.caseId, c]));
  const shared = [...dById.keys()].filter((id) => wById.has(id)).sort();

  const cases = shared.map((id) => diffCase(dById.get(id)!, wById.get(id)!));
  const desktopOnlyCases = [...dById.keys()].filter((id) => !wById.has(id)).sort();
  const webOnlyCases = [...wById.keys()].filter((id) => !dById.has(id)).sort();

  const sum = (pick: (t: CaseDiff['totals']) => number) =>
    cases.reduce((n, c) => n + pick(c.totals), 0);

  return {
    kind: 'datacare.parity-diff/1.0',
    comparedAt: new Date().toISOString(),
    desktop: {
      capturedAt: desktop.capturedAt,
      database: desktop.source.database,
      engine: desktop.source.engine,
      appVersion: desktop.source.appVersion,
      host: desktop.source.host,
    },
    web: {
      capturedAt: web.capturedAt,
      database: web.source.database,
      engine: web.source.engine,
      appVersion: web.source.appVersion,
      host: web.source.host,
    },
    // A case captured on one side only is NOT a pass: it means the scenario was never exercised on the other.
    matched:
      cases.length > 0 &&
      cases.every((c) => c.matched) &&
      desktopOnlyCases.length === 0 &&
      webOnlyCases.length === 0,
    cases,
    desktopOnlyCases,
    webOnlyCases,
    totals: {
      cases: cases.length,
      casesMatched: cases.filter((c) => c.matched).length,
      tablesCompared: sum((t) => t.tablesCompared),
      tablesDesktopOnly: sum((t) => t.tablesDesktopOnly),
      tablesWebOnly: sum((t) => t.tablesWebOnly),
      rowsMissing: sum((t) => t.rowsMissing),
      rowsExtra: sum((t) => t.rowsExtra),
      fieldsCompared: sum((t) => t.fieldsCompared),
      fieldsExcluded: sum((t) => t.fieldsExcluded),
      fieldDifferences: sum((t) => t.fieldDifferences),
    },
  };
}

/** Human-readable summary for the console and for pasting into a review. */
export function formatDiff(report: BundleDiffReport): string {
  const t = report.totals;
  const lines: string[] = [
    `desktop  ${report.desktop.engine} ${report.desktop.database}  captured ${report.desktop.capturedAt}`,
    `web      ${report.web.engine} ${report.web.database}  captured ${report.web.capturedAt}`,
    '',
    `cases ${t.casesMatched}/${t.cases} matched   fields compared ${t.fieldsCompared} ` +
      `(excluded ${t.fieldsExcluded})   differences ${t.fieldDifferences}`,
    `rows missing ${t.rowsMissing}   rows extra ${t.rowsExtra}   ` +
      `tables desktop-only ${t.tablesDesktopOnly}   web-only ${t.tablesWebOnly}`,
  ];
  // Forced pairs are the differ's only signal that its own key construction may be wrong, so they are printed
  // even when nothing differed - a force-paired table with zero differences is precisely the case that looks
  // clean while proving nothing about pairing.
  // Only MULTI-row tables are warned about. A header table with one row per voucher - SL_DATA,
  // BILL_OS_DATA - has nothing to pair BY, so forcing is the correct behaviour there; reporting it would be
  // noise that trains the reader to ignore the line. A table with SEVERAL rows that still needed forcing has
  // a key that does not identify its rows, which is worth acting on.
  const forced = report.cases.flatMap((c) =>
    c.tables
      .filter((tb) => tb.forcedPairs > 0 && (tb.desktopRows > 1 || tb.webRows > 1))
      .map((tb) => `${c.caseId}/${tb.table} (${tb.desktopRows}v${tb.webRows} rows)`),
  );
  if (forced.length)
    lines.push(`KEY WARNING - multi-row tables compared without a key match: ${forced.join(', ')}`);
  if (report.desktopOnlyCases.length)
    lines.push(`cases never entered on the web: ${report.desktopOnlyCases.join(', ')}`);
  if (report.webOnlyCases.length)
    lines.push(`cases never entered on the desktop: ${report.webOnlyCases.join(', ')}`);
  for (const c of report.cases) {
    if (c.matched) {
      lines.push(
        `  OK   ${c.caseId}  ${c.totals.fieldsCompared} fields across ${c.tables.length} tables`,
      );
      continue;
    }
    lines.push(`  DIFF ${c.caseId}  desktop ${c.desktopVoucher} vs web ${c.webVoucher}`);
    for (const tb of c.tables) {
      if (tb.presentOn === 'desktop-only') {
        lines.push(
          `         ${tb.table}: WEB NEVER WROTE THIS TABLE (${tb.desktopRows} desktop rows)`,
        );
        continue;
      }
      if (tb.missingColumns.length)
        lines.push(
          `         ${tb.table}: columns absent from web schema: ${tb.missingColumns.join(', ')}`,
        );
      if (tb.desktopRows !== tb.webRows)
        lines.push(`         ${tb.table}: rows desktop ${tb.desktopRows} vs web ${tb.webRows}`);
      for (const d of tb.differences.slice(0, 12))
        lines.push(
          `         ${tb.table}.${d.column} [${d.rowKey}]  desktop=${d.desktop}  web=${d.web}`,
        );
    }
  }
  return lines.join('\n');
}
