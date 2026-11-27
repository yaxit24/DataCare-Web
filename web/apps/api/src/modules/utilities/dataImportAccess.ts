import type { SourceReader, SourceRow, SourceTable } from './dataImportSource.js';

/**
 * Access SQL and VB semantics the Lite import steps reproduce over plain source rows (dataImportLite.ts).
 */
// ---- Access semantics -------------------------------------------------------------------------------------------

/** `x & ""`: NULL reads as the empty string. */
export const str = (v: unknown): string => (v === null || v === undefined ? '' : String(v));
/** VB Mid(s, 1, n). */
export const mid = (v: unknown, n: number): string => str(v).slice(0, n);
/** VB Conversion.Val: the leading number of the text, else 0. */
export function val(v: unknown): number {
  if (typeof v === 'number') return Number.isFinite(v) ? v : 0;
  if (typeof v === 'boolean') return v ? -1 : 0;
  const m = /^\s*[-+]?(\d+\.?\d*|\.\d+)(e[-+]?\d+)?/i.exec(str(v).replace(/\s+/g, ''));
  return m ? Number(m[0]) : 0;
}
/** DC_Main.Fnv (DC_Main.cs:2088-2103): NULL or '' is 0, else Val. */
export const fnv = (v: unknown): number => (v === null || v === undefined || v === '' ? 0 : val(v));
/** Access text equality (case-insensitive). NULL never equals anything. */
export const eq = (a: unknown, b: unknown): boolean =>
  a !== null &&
  a !== undefined &&
  b !== null &&
  b !== undefined &&
  str(a).toUpperCase() === str(b).toUpperCase();
/** `x <> ''` in Access: false for NULL. */
export const notBlank = (v: unknown): boolean => v !== null && v !== undefined && str(v) !== '';
/** Access text order (case-insensitive); NULL sorts first. */
export function cmpText(a: unknown, b: unknown): number {
  const na = a === null || a === undefined;
  const nb = b === null || b === undefined;
  if (na || nb) return na && nb ? 0 : na ? -1 : 1;
  const x = str(a).toUpperCase();
  const y = str(b).toUpperCase();
  return x < y ? -1 : x > y ? 1 : 0;
}
export const isoDay = (v: unknown): string | null => {
  if (v === null || v === undefined || v === '') return null;
  const s = str(v);
  return /^\d{4}-\d{2}-\d{2}/.test(s) ? s.slice(0, 10) : null;
};
/** Access Format(x, '0.00' / '0.000'): rounds half away from zero. */
export function fmtRound(x: number, places: number): number {
  const f = 10 ** places;
  return (Math.sign(x) * Math.round(Math.abs(x) * f + 1e-9)) / f;
}
export const sum = (values: Array<number | null>): number | null => {
  let total: number | null = null;
  for (const v of values) if (v !== null) total = (total ?? 0) + v;
  return total;
};
/** A numeric source cell for SUM: NULL stays NULL (Access SUM skips it). */
export const n = (v: unknown): number | null =>
  v === null || v === undefined || v === '' ? null : val(v);
export const signed = (sign: unknown, v: unknown): number | null => {
  const x = n(v);
  if (x === null) return null;
  return eq(sign, '+') ? x : -x; // IIf(SIGN = '+', x, -x): a NULL sign is not '+'
};
export const dayBefore = (iso: string): Date => {
  const d = new Date(`${iso}T00:00:00.000Z`);
  d.setUTCDate(d.getUTCDate() - 1);
  return d;
};
export const isoOf = (d: Date): string => d.toISOString().slice(0, 10);
/** dd/MM/yyyy, the text the Party screen shows and saves for BR_DATE / AN_DATE. */
export const ddmmyyyy = (iso: string): string =>
  `${iso.slice(8, 10)}/${iso.slice(5, 7)}/${iso.slice(0, 4)}`;

export function rowsOf(src: SourceReader, table: SourceTable): SourceRow[] {
  return src.rows(table) ?? [];
}
