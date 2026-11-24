import { round } from '@datacare/core';

/**
 * Web-side shape of the RP_ALL Sales result (`GET /reports/sales-report`).
 *
 * The server owns every selected value, group band and total (web/apps/api/src/modules/reports/rpAll/index.ts).
 * These types describe that JSON at the browser boundary; the screen only formats the cells for display.
 */
export type SalesReportMode = 'report' | 'register' | 'item' | 'group' | 'employee' | 'with-order';

export type SalesColumnKind = 'text' | 'date' | 'money' | 'weight' | 'pcs' | 'rate';
export type SalesRowLevel = 'voucher' | 'line' | 'sub';

export interface SalesColumn {
  key: string;
  caption: string;
  kind: SalesColumnKind;
  level: SalesRowLevel;
  total?: boolean;
}

export interface SalesRow {
  level: SalesRowLevel;
  groupPath: string[];
  voucherKey: string;
  cells: Record<string, string | number | null>;
}

export interface SalesGroup {
  depth: number;
  key: string;
  label: string;
  groupPath: string[];
  rowCount: number;
  totals: Record<string, number>;
}

export interface SalesResult {
  branch: 'sales';
  template: string;
  variant: 'sale' | 'return';
  mode: SalesReportMode;
  caption: string;
  title: string;
  columns: SalesColumn[];
  groups: SalesGroup[];
  groupLevels: { key: string; subtotal: 'header' | 'footer' | 'none'; subtotalCaption?: string }[];
  rows: SalesRow[];
  totals: Record<string, number>;
  grandTotal: boolean;
  grandTotalCaption?: string;
  voucherCount: number;
  /** Selectors the request carried that this button's formula does not use (the desktop ignores them). */
  ignoredFilters: string[];
}

export interface SalesFilters {
  /** ISO yyyy-mm-dd; the date boxes show the desktop dd/MM/yyyy mask. */
  fromDate: string;
  toDate: string;
  lcCode: string;
  bookCode: string;
  /** Select Book: the ticked CO_BOOK codes after Ok, used only while the check box is ticked. */
  selectBook: boolean;
  books: string[];
  prCode: string;
  grCode: string;
  partyCode: string;
  city: string;
  area: string;
  itemType: string;
  employ: string;
}

const PRECISION: Record<SalesColumnKind, number | null> = {
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
export function formatCell(kind: SalesColumnKind, value: string | number | null): string {
  if (value === null || value === undefined || value === '') return '';
  if (kind === 'date') return displayDate(String(value));
  const places = PRECISION[kind];
  if (places === null) return String(value);
  const number = Number(value);
  if (!Number.isFinite(number)) return '';
  return round(number, places).toFixed(places);
}

/** One button of PanelSale (RP_ALL.cs:4364-4378, tab order); `mode` is absent where the API serves no report yet. */
export interface SalesButton {
  /** Caption verbatim, `&` marks the access key (WinForms mnemonic). */
  caption: string;
  mode?: SalesReportMode;
  /** The Yes/No prompt the click handler opens first. */
  prompt?: 'returns' | 'order';
}

export const SALES_PROMPTS = {
  // RP_ALL.cs:7584 {{MsgBox("Sales Return (Creditnote) Report", 260)}}: Yes/No, default button No.
  returns: { text: 'Sales Return (Creditnote) Report', defaultAnswer: 'No' },
  // RP_ALL.cs:11749 {{MsgBox("Only Item Sales With Order", 4)}}: Yes/No, default button Yes.
  order: { text: 'Only Item Sales With Order', defaultAnswer: 'Yes' },
} as const;

/** The 13 Lite buttons in desktop tab order (RP_ALL.cs:4409-4775; Item Bill and B2B Bill are UAE only, :6682-6686). */
export const SALES_BUTTONS: readonly SalesButton[] = [
  { caption: '&Sales Report', mode: 'report', prompt: 'returns' },
  { caption: '&Sales Reg', mode: 'register', prompt: 'returns' },
  { caption: '&Item Wise', mode: 'item', prompt: 'returns' },
  { caption: '&Sales Bill' },
  { caption: '&Wh Sales' },
  { caption: 'Employ  Sales', mode: 'employee' },
  { caption: '&Cash/Bank Bill' },
  { caption: '&Wh Summ' },
  { caption: 'Emp  WhSales' },
  { caption: '&Counter Sales' },
  { caption: '&Sale With Order', mode: 'with-order', prompt: 'order' },
  { caption: '&Group Sales', mode: 'group' },
  { caption: '&Labour Work' },
];

/** cboItemTyp items (RP_ALL.cs:7165-7172). */
export const ITEM_TYPES = [
  '',
  'Gold',
  'Silver',
  'Diamond',
  'Real Stone',
  'Emitation',
  'Other',
  'Platinum',
];

/** Captions of the selectors the API reports as ignored by a button's formula. */
export const FILTER_CAPTIONS: Record<string, string> = {
  coBook: 'Book',
  books: 'Select Book',
  acCode: 'Party Code',
  prCode: 'Pr Code',
  grCode: 'Gr Code',
  city: 'City',
  area: 'Area',
  state: 'State',
  empCode: 'Employ',
  itemType: 'Item Type',
};
