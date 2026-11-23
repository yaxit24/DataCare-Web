/**
 * Web-side shape of the RP_ALL Order result (`GET /reports/order-report`).
 *
 * The server owns every selected value, group band and total (web/apps/api/src/modules/reports/rpAll/index.ts).
 * These types describe that JSON at the browser boundary; the screen only formats the cells for display.
 */
export type OrderReportMode =
  'report' | 'advance' | 'adjust' | 'with-bill' | 'pending' | 'summary' | 'bill-wise';

export type OrderColumnKind = 'text' | 'date' | 'money' | 'weight' | 'pcs' | 'rate';
export type OrderRowLevel = 'voucher' | 'line' | 'sub';

export interface OrderColumn {
  key: string;
  caption: string;
  kind: OrderColumnKind;
  level: OrderRowLevel;
  total?: boolean;
}

export interface OrderRow {
  level: OrderRowLevel;
  groupPath: string[];
  voucherKey: string;
  cells: Record<string, string | number | null>;
}

export interface OrderGroup {
  depth: number;
  key: string;
  label: string;
  groupPath: string[];
  rowCount: number;
  totals: Record<string, number>;
}

export interface OrderResult {
  branch: 'order';
  mode: OrderReportMode;
  caption: string;
  title: string;
  columns: OrderColumn[];
  groups: OrderGroup[];
  groupLevels: { key: string; subtotal: 'header' | 'footer' | 'none'; subtotalCaption?: string }[];
  rows: OrderRow[];
  totals: Record<string, number>;
  grandTotal: boolean;
  grandTotalCaption?: string;
  voucherCount: number;
}

export interface OrderFilters {
  /** Displayed dd/MM/yyyy on the desktop mask; sent to the API as yyyy-mm-dd. */
  fromDate: string;
  toDate: string;
  lcCode: string;
  bookCode: string;
  partyCode: string;
  prCode: string;
  grCode: string;
  custName: string;
  city: string;
  area: string;
  itemType: string;
}

const PRECISION: Record<OrderColumnKind, number | null> = {
  text: null,
  date: null,
  money: 2,
  rate: 2,
  weight: 3,
  pcs: 0,
};

const pad = (value: number): string => String(value).padStart(2, '0');

/** yyyy-mm-dd → dd/MM/yyyy, the desktop mask and the RptTitel format (RP_ALL.cs:7604). */
export function displayDate(iso: string): string {
  const match = /^(\d{4})-(\d{2})-(\d{2})$/.exec(iso);
  return match ? `${match[3]}/${match[2]}/${match[1]}` : iso;
}

/** Accept the desktop mask text and the ISO form the API uses, refusing impossible calendar dates. */
export function isoDate(text: string): string | null {
  const trimmed = text.trim();
  const mdY = /^(\d{2})\/(\d{2})\/(\d{4})$/.exec(trimmed);
  const iso = /^(\d{4})-(\d{2})-(\d{2})$/.exec(trimmed);
  let year: number;
  let month: number;
  let day: number;
  if (mdY) {
    day = Number(mdY[1]);
    month = Number(mdY[2]);
    year = Number(mdY[3]);
  } else if (iso) {
    year = Number(iso[1]);
    month = Number(iso[2]);
    day = Number(iso[3]);
  } else return null;
  const date = new Date(Date.UTC(year, month - 1, day));
  if (
    date.getUTCFullYear() !== year ||
    date.getUTCMonth() + 1 !== month ||
    date.getUTCDate() !== day
  )
    return null;
  return `${year}-${pad(month)}-${pad(day)}`;
}

/** The printed cell text, matching the API's formatCell (engine.ts:263). */
export function formatCell(kind: OrderColumnKind, value: string | number | null): string {
  if (value === null || value === undefined || value === '') return '';
  if (kind === 'date') return displayDate(String(value));
  const places = PRECISION[kind];
  if (places === null) return String(value);
  const number = Number(value);
  if (!Number.isFinite(number)) return '';
  return number.toFixed(places);
}
