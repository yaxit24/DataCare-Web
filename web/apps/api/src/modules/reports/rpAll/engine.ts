import { round } from '@datacare/core';
import type {
  RpAllColumn,
  RpAllColumnKind,
  RpAllEngineResult,
  RpAllGroup,
  RpAllLayout,
  RpAllLevel,
  RpAllRecord,
  RpAllRow,
  RpAllValue,
} from './types.js';

/**
 * The pure RP_ALL engine: (layout, records) → ordered rows, group bands and totals. No I/O, no clock.
 *
 * WHY "COUNT ONCE"
 * A Crystal template reads a LEFT OUTER join of header → lines → sub-lines (for SaleReport:
 * SL_DATA → SL_DETL → SL_IDTL, extraction_output/rpt_xml/SaleReport.xml TableLinks), so a header amount
 * repeats on every line record. The templates guard against that in two different ways:
 *   - SaleReport / EmpSaleReport total header fields with running totals "evaluated on change of group"
 *     (one evaluation per voucher group), i.e. once per voucher;
 *   - SalesSumm totals with plain `Sum({SL_DATA.NET_AMT})`, which adds the header value once per joined
 *     RECORD, so a two-line bill is counted twice.
 * The engine counts every value once per distinct key of its own level (voucher, line, sub-line). That is
 * the running-total behaviour, and for SalesSumm it is a deliberate difference from the literal Crystal
 * sum, recorded in docs/parity/rpall-sales-inventory.md §6 rather than ported (a doubled bill amount is a
 * defect, not a business rule).
 */

const PRECISION: Record<RpAllColumnKind, number | null> = {
  text: null,
  date: null,
  money: 2,
  rate: 2,
  weight: 3,
  pcs: 0,
};

/** Sum with the shared core rounding, kept at 6 dp while accumulating so float noise never reaches a total. */
function addExact(a: number, b: number): number {
  return round(a + b, 6);
}

function num(value: RpAllValue): number {
  if (value === null || value === '') return 0;
  const n = typeof value === 'number' ? value : Number(value);
  return Number.isFinite(n) ? n : 0;
}

/** Key of a record at one level; null when the record has no row at that level (an outer-join gap). */
export function levelKey(
  record: RpAllRecord,
  fields: readonly string[] | undefined,
): string | null {
  if (!fields || fields.length === 0) return null;
  const parts: string[] = [];
  for (const field of fields) {
    const v = record[field];
    if (v === null || v === undefined) return null;
    parts.push(String(v));
  }
  return parts.join('|');
}

function keyFieldsFor(layout: RpAllLayout, level: RpAllLevel): readonly string[] | undefined {
  if (level === 'voucher') return layout.keys.voucher;
  if (level === 'line') return [...layout.keys.voucher, ...(layout.keys.line ?? [])];
  return [...layout.keys.voucher, ...(layout.keys.line ?? []), ...(layout.keys.sub ?? [])];
}

/**
 * Crystal ascending order: nulls first, numbers numerically, everything else by code point. Dates arrive
 * as ISO yyyy-mm-dd strings, so they order correctly as text.
 */
export function compareValues(a: RpAllValue, b: RpAllValue): number {
  const aNull = a === null || a === undefined;
  const bNull = b === null || b === undefined;
  if (aNull || bNull) return aNull === bNull ? 0 : aNull ? -1 : 1;
  if (typeof a === 'number' && typeof b === 'number') return a - b;
  const sa = String(a);
  const sb = String(b);
  return sa < sb ? -1 : sa > sb ? 1 : 0;
}

/** Group keys first (ascending, in group order), then the record sort keys; stable for equal records. */
export function sortRecords(layout: RpAllLayout, records: readonly RpAllRecord[]): RpAllRecord[] {
  const keys = [...layout.groups.map((g) => g.key), ...layout.sort.map((s) => s.key)];
  return records
    .map((record, index) => ({ record, index }))
    .sort((x, y) => {
      for (const key of keys) {
        const c = compareValues(x.record[key] ?? null, y.record[key] ?? null);
        if (c !== 0) return c;
      }
      return x.index - y.index;
    })
    .map((entry) => entry.record);
}

/**
 * Totals of the layout's total columns over `records`, each value counted once per distinct key of its
 * own level and rounded to the column's precision.
 */
export function countOnceTotals(
  layout: RpAllLayout,
  records: readonly RpAllRecord[],
): Record<string, number> {
  const totals: Record<string, number> = {};
  for (const column of layout.columns) {
    if (!column.total) continue;
    const fields = keyFieldsFor(layout, column.level);
    const seen = new Set<string>();
    let sum = 0;
    for (const record of records) {
      const key = levelKey(record, fields);
      if (key === null || seen.has(key)) continue;
      seen.add(key);
      sum = addExact(sum, num(record[column.key] ?? null));
    }
    const dp = PRECISION[column.kind];
    totals[column.key] = dp === null ? sum : round(sum, dp);
  }
  return totals;
}

function cellsFor(
  columns: readonly RpAllColumn[],
  level: RpAllLevel,
  record: RpAllRecord,
): Record<string, RpAllValue> {
  const cells: Record<string, RpAllValue> = {};
  for (const column of columns) {
    if (column.level !== level) continue;
    const raw = record[column.key] ?? null;
    const dp = PRECISION[column.kind];
    cells[column.key] = dp === null || raw === null ? raw : round(num(raw), dp);
  }
  return cells;
}

function groupLabel(layout: RpAllLayout, depth: number, record: RpAllRecord): string {
  const level = layout.groups[depth]!;
  const raw = record[level.key];
  if (level.labelMap) {
    const mapped = raw === null || raw === undefined ? undefined : level.labelMap[String(raw)];
    return mapped ?? level.labelDefault ?? String(raw ?? '');
  }
  return level.labelKeys
    .map((key) => {
      const column = layout.columns.find((c) => c.key === key);
      return formatCell(column?.kind ?? 'text', record[key] ?? null);
    })
    .filter((part) => part !== '')
    .join(' ');
}

/**
 * Run a layout over adapter records. Rows come out in the template's order; a voucher row precedes its
 * line rows, a line row its sub-line rows. Group bands carry their own count-once totals.
 */
export function runLayout(layout: RpAllLayout, records: readonly RpAllRecord[]): RpAllEngineResult {
  const sorted = sortRecords(layout, records);
  const rows: RpAllRow[] = [];
  const groups: RpAllGroup[] = [];
  const voucherFields = keyFieldsFor(layout, 'voucher');
  const lineFields = layout.keys.line ? keyFieldsFor(layout, 'line') : undefined;
  const subFields = layout.keys.sub ? keyFieldsFor(layout, 'sub') : undefined;

  // Group bands: walk the sorted records and open a band whenever any key at or above a depth changes.
  const open: { group: RpAllGroup; records: RpAllRecord[] }[] = [];
  const closeFrom = (depth: number) => {
    while (open.length > depth) {
      const band = open.pop()!;
      const level = layout.groups[band.group.depth]!;
      if (level.subtotal !== 'none') band.group.totals = countOnceTotals(layout, band.records);
      band.group.rowCount = band.records.length;
    }
  };
  let previousPath: string[] | null = null;
  let lastVoucher: string | null = null;
  let lastLine: string | null = null;
  const emitted = new Set<string>();

  for (const record of sorted) {
    const path = layout.groups.map((g) => String(record[g.key] ?? ''));
    const before = previousPath;
    const firstChange = before === null ? 0 : path.findIndex((value, i) => value !== before[i]);
    if (firstChange !== -1 && (before === null || layout.groups.length > 0)) {
      closeFrom(firstChange);
      for (let depth = firstChange; depth < layout.groups.length; depth += 1) {
        const group: RpAllGroup = {
          depth,
          key: path[depth]!,
          label: groupLabel(layout, depth, record),
          groupPath: path.slice(0, depth + 1),
          rowCount: 0,
          totals: {},
        };
        groups.push(group);
        open.push({ group, records: [] });
      }
      lastVoucher = null;
      lastLine = null;
    }
    for (const band of open) band.records.push(record);
    previousPath = path;

    const voucherKey = levelKey(record, voucherFields) ?? '';
    const shows = (level: RpAllLevel) =>
      layout.rowLevels.includes(level) && !layout.suppress?.[level]?.(record);
    if (voucherKey !== lastVoucher && shows('voucher')) {
      rows.push({
        level: 'voucher',
        groupPath: path,
        voucherKey,
        cells: cellsFor(layout.columns, 'voucher', record),
      });
    }
    if (voucherKey !== lastVoucher) lastLine = null;
    lastVoucher = voucherKey;

    const lineKey = levelKey(record, lineFields);
    if (lineKey !== null && lineKey !== lastLine) {
      if (shows('line')) {
        rows.push({
          level: 'line',
          groupPath: path,
          voucherKey,
          cells: cellsFor(layout.columns, 'line', record),
        });
      }
      lastLine = lineKey;
    }
    const subKey = levelKey(record, subFields);
    if (subKey !== null && !emitted.has(subKey) && shows('sub')) {
      emitted.add(subKey);
      rows.push({
        level: 'sub',
        groupPath: path,
        voucherKey,
        cells: cellsFor(layout.columns, 'sub', record),
      });
    }
  }
  closeFrom(0);

  const vouchers = new Set<string>();
  for (const record of sorted) {
    const key = levelKey(record, voucherFields);
    if (key !== null) vouchers.add(key);
  }
  return { rows, groups, totals: countOnceTotals(layout, sorted), voucherCount: vouchers.size };
}

/** dd/MM/yyyy, the format every RP_ALL title and date column uses (RP_ALL.cs:7604). */
export function formatDate(iso: string): string {
  const m = /^(\d{4})-(\d{2})-(\d{2})/.exec(iso);
  return m ? `${m[3]}/${m[2]}/${m[1]}` : iso;
}

/** Text of one cell as the printed report shows it. */
export function formatCell(kind: RpAllColumnKind, value: RpAllValue): string {
  if (value === null || value === undefined) return '';
  if (kind === 'date') return formatDate(String(value));
  const dp = PRECISION[kind];
  if (dp === null) return String(value);
  return round(num(value), dp).toFixed(dp);
}

/** "<prefix> From dd/MM/yyyy To dd/MM/yyyy", the RptTitel the desktop passes (RP_ALL.cs:7604, 7610). */
export function reportTitle(prefix: string, fromDate: string, toDate: string): string {
  return `${prefix} From ${formatDate(fromDate)} To ${formatDate(toDate)}`;
}
