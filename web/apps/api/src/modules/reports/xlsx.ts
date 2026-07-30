import writeXlsxFile from 'write-excel-file/node';

/**
 * Shared XLSX writer.
 *
 * 38 desktop forms expose an Excel export (`BtnExel` / Excel automation) and the web had **none** — CSV only.
 * Every report, master list and utility export goes through this one writer so the behaviour, security
 * posture and cell typing are identical everywhere.
 *
 * FORMULA INJECTION
 * -----------------
 * Spreadsheet applications evaluate a cell whose text begins `=`, `+`, `-` or `@`. Exported business data
 * routinely contains such strings (a negative amount rendered as text, a remark starting with `-`), so every
 * value written from data is emitted as a STRING cell and never as a formula. There is no code path here that
 * produces a formula cell, which is why the test can assert the output XML contains no `<f>` element.
 *
 * PACKAGE CHOICE
 * --------------
 * `write-excel-file@4.1.1` (MIT, one dependency, no native build). SheetJS `xlsx` was rejected on supply
 * chain rather than on the well-known CVE: `GHSA-4r6h-8v6p-xvw6` is a READ-path prototype-pollution bug and
 * the advisory explicitly says write-only workflows are unaffected — but the fix is 0.19.3+ while public npm
 * stops at 0.18.5 and current builds ship from the vendor's own CDN. Adding a non-registry download path is
 * not justified for a write-only need. If a future legacy IMPORT needs SheetJS for reading, that decision
 * must be revisited with the CVE fully in scope.
 */

export type XlsxCellType = 'text' | 'number' | 'date' | 'boolean';

export interface XlsxColumn {
  /** Header text. */
  header: string;
  /** Key into each row object. */
  key: string;
  type?: XlsxCellType;
  /** Column width in characters; bounded to keep a sheet usable. */
  width?: number;
  /** Number/date format, e.g. `0.000` for metal weights or `dd/mm/yyyy`. */
  format?: string;
}

export interface XlsxSheet {
  name: string;
  columns: XlsxColumn[];
  rows: Record<string, unknown>[];
  /** Totals row appended as VALUES, never as formulas. */
  totals?: Record<string, unknown>;
}

const MAX_ROWS = 100_000;
const MAX_SHEET_NAME = 31;

/** Excel forbids : \ / ? * [ ] in a sheet name and caps it at 31 characters. */
export function safeSheetName(name: string, taken: Set<string>): string {
  let base = (name || 'Sheet')
    .replace(/[:\\/?*[\]]/g, ' ')
    .trim()
    .slice(0, MAX_SHEET_NAME);
  if (!base) base = 'Sheet';
  let candidate = base;
  let n = 2;
  while (taken.has(candidate.toLowerCase())) {
    const suffix = ` (${n})`;
    candidate = base.slice(0, MAX_SHEET_NAME - suffix.length) + suffix;
    n += 1;
  }
  taken.add(candidate.toLowerCase());
  return candidate;
}

/** A filename safe for a Content-Disposition header and for every desktop filesystem. */
export function safeFileName(name: string): string {
  const cleaned = String(name || 'export')
    .replace(/[^\w.-]/g, '_')
    .replace(/_+/g, '_');
  return (cleaned.replace(/^[._]+|[._]+$/g, '') || 'export').slice(0, 80);
}

/** True when a spreadsheet would treat this text as a formula. */
export const looksLikeFormula = (s: string): boolean => /^[=+\-@]/.test(s);

function cellFor(value: unknown, col: XlsxColumn): Record<string, unknown> {
  if (value == null || value === '') return { value: null };
  const type = col.type ?? 'text';
  if (type === 'number') {
    const n = typeof value === 'number' ? value : Number(String(value));
    // A non-numeric value in a numeric column is written as text rather than silently becoming 0.
    if (!Number.isFinite(n)) return { type: String, value: String(value) };
    return { type: Number, value: n, format: col.format };
  }
  if (type === 'boolean') return { type: Boolean, value: Boolean(value) };
  if (type === 'date') {
    const d = value instanceof Date ? value : new Date(String(value));
    if (Number.isNaN(d.getTime())) return { type: String, value: String(value) };
    return { type: Date, value: d, format: col.format ?? 'dd/mm/yyyy' };
  }
  // Text: always a string cell, so a leading = + - @ can never be evaluated as a formula.
  return { type: String, value: String(value) };
}

/** Build the sheet matrix write-excel-file expects. */
function sheetMatrix(sheet: XlsxSheet): Record<string, unknown>[][] {
  const header = sheet.columns.map((c) => ({
    value: c.header,
    fontWeight: 'bold' as const,
    type: String,
  }));
  const body = sheet.rows
    .slice(0, MAX_ROWS)
    .map((row) => sheet.columns.map((c) => cellFor(row[c.key], c)));
  const out = [header, ...body];
  if (sheet.totals) {
    out.push(
      sheet.columns.map((c) => {
        const v = sheet.totals?.[c.key];
        if (v == null || v === '') return { value: null };
        // Totals are written as VALUES; a formula would recompute in the client and could disagree
        // with the figure the report actually produced.
        return { ...cellFor(v, c), fontWeight: 'bold' as const };
      }),
    );
  }
  return out;
}

export interface XlsxResult {
  buffer: Buffer;
  fileName: string;
  contentType: string;
}

export const XLSX_CONTENT_TYPE =
  'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';

/** Render one or more sheets to an .xlsx buffer. */
export async function renderXlsx(sheets: XlsxSheet[], fileName: string): Promise<XlsxResult> {
  if (!sheets.length) throw new Error('xlsx export requires at least one sheet');
  const taken = new Set<string>();
  // Multi-sheet form: one object per sheet carrying its own name, column widths and data.
  const spec = sheets.map((s) => ({
    sheet: safeSheetName(s.name, taken),
    data: sheetMatrix(s),
    columns: s.columns.map((c) => ({ width: Math.min(Math.max(c.width ?? 14, 6), 60) })),
    stickyRowsCount: 1, // keep headers visible when scrolling a long report
  }));
  const buffer = await (await writeXlsxFile(spec as never)).toBuffer();
  return {
    buffer,
    fileName: `${safeFileName(fileName)}.xlsx`,
    contentType: XLSX_CONTENT_TYPE,
  };
}

/**
 * Convenience: turn a report's array-of-objects result into a single-sheet workbook, inferring a column
 * type per key from the values present. Explicit column metadata is always preferred where a caller has it.
 */
export function inferSheet(
  name: string,
  rows: Record<string, unknown>[],
  totals?: Record<string, unknown>,
): XlsxSheet {
  const keys: string[] = [];
  for (const r of rows) for (const k of Object.keys(r)) if (!keys.includes(k)) keys.push(k);
  const columns: XlsxColumn[] = keys.map((key) => {
    let numeric = false;
    let seen = false;
    for (const r of rows) {
      const v = r[key];
      if (v == null || v === '') continue;
      seen = true;
      if (
        typeof v === 'number' ||
        (typeof v === 'string' && v !== '' && Number.isFinite(Number(v)))
      ) {
        numeric = true;
      } else {
        numeric = false;
        break;
      }
    }
    return {
      header: key,
      key,
      type: seen && numeric ? 'number' : 'text',
      width: Math.min(Math.max(key.length + 2, 10), 30),
    };
  });
  return { name, columns, rows, totals };
}
