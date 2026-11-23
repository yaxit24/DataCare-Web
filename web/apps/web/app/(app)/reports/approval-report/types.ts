import { round } from '@datacare/core';

/**
 * Web-side shape of the RP_ALL Approval result (`GET /reports/approval-report`).
 *
 * The server owns every selected value, group band and total (web/apps/api/src/modules/reports/rpAll/index.ts,
 * approvalLayouts.ts). These types describe that JSON at the browser boundary; the screen only formats cells.
 */
export type ApprovalReportMode = 'issue' | 'inout' | 'pending';

export type ApprovalColumnKind = 'text' | 'date' | 'money' | 'weight' | 'pcs' | 'rate';
export type ApprovalRowLevel = 'voucher' | 'line' | 'sub';

export interface ApprovalColumn {
  key: string;
  caption: string;
  kind: ApprovalColumnKind;
  level: ApprovalRowLevel;
  total?: boolean;
}

export interface ApprovalRow {
  level: ApprovalRowLevel;
  groupPath: string[];
  voucherKey: string;
  cells: Record<string, string | number | null>;
}

export interface ApprovalGroup {
  depth: number;
  key: string;
  label: string;
  groupPath: string[];
  rowCount: number;
  /** Effective placement after conditional suppression (AprPan.xml:936 hides a zero tag footer). */
  subtotal?: 'header' | 'footer' | 'none';
  totals: Record<string, number>;
}

export interface ApprovalResult {
  branch: 'approval';
  mode: ApprovalReportMode;
  caption: string;
  /** The Crystal template the button opens: AprPartyWise, AprInOut or AprPan. */
  template: string;
  title: string;
  columns: ApprovalColumn[];
  groups: ApprovalGroup[];
  groupLevels: { key: string; subtotal: 'header' | 'footer' | 'none'; subtotalCaption?: string }[];
  rows: ApprovalRow[];
  totals: Record<string, number>;
  grandTotal: boolean;
  grandTotalCaption?: string;
  voucherCount: number;
}

export interface ApprovalFilters {
  /** Displayed dd/MM/yyyy on the desktop mask; sent to the API as yyyy-mm-dd. */
  fromDate: string;
  toDate: string;
  lcCode: string;
  bookCode: string;
  prCode: string;
  grCode: string;
  partyCode: string;
  custName: string;
  city: string;
  area: string;
  itemType: string;
}

/** cboItemTyp items, verbatim and in order, blank selected (RP_ALL.cs:7165-7173; "Emitation" is the desktop's). */
export const ITEM_TYPES: readonly string[] = [
  '',
  'Gold',
  'Silver',
  'Diamond',
  'Real Stone',
  'Emitation',
  'Other',
  'Platinum',
];

/** The desktop messages of DC_Main.SetDate (DC_Main.cs:1644, :1664). */
export const DATE_NOT_VALID = 'Date Not Valid...';
export const MONTH_NOT_VALID = 'Month Not Valid...';
/** The mask a refused date is reset to (DC_Main.cs:1645 {{MsDate.Text = "__/__/____";}}). */
export const EMPTY_MASK = '__/__/____';

const PRECISION: Record<ApprovalColumnKind, number | null> = {
  text: null,
  date: null,
  money: 2,
  rate: 2,
  weight: 3,
  pcs: 0,
};

const pad = (value: number): string => String(value).padStart(2, '0');

/** yyyy-mm-dd → dd/MM/yyyy, the desktop mask and the RptTitel format. */
export function displayDate(iso: string): string {
  const match = /^(\d{4})-(\d{2})-(\d{2})$/.exec(iso);
  return match ? `${match[3]}/${match[2]}/${match[1]}` : iso;
}

/** Accept the desktop mask text and the ISO form the API uses, refusing impossible calendar dates. */
export function isoDate(text: string): string | null {
  const trimmed = text.trim();
  const dmy = /^(\d{2})\/(\d{2})\/(\d{4})$/.exec(trimmed);
  const iso = /^(\d{4})-(\d{2})-(\d{2})$/.exec(trimmed);
  let year: number;
  let month: number;
  let day: number;
  if (dmy) {
    day = Number(dmy[1]);
    month = Number(dmy[2]);
    year = Number(dmy[3]);
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

/** Spread typed text over the `00/00/0000` mask (RP_ALL.cs:5619): digits fill the slots, the rest stay `_`. */
export function toMask(text: string): string {
  const iso = /^(\d{4})-(\d{2})-(\d{2})$/.exec(text.trim());
  const digits = iso ? `${iso[3]}${iso[2]}${iso[1]}` : text.replace(/\D/g, '').slice(0, 8);
  const slots = digits.padEnd(8, '_');
  return `${slots.slice(0, 2)}/${slots.slice(2, 4)}/${slots.slice(4, 8)}`;
}

export interface SetDateOptions {
  /** Company year as the session holds it, `yyyy-yyyy` (DC_Main.MCo_year). */
  coYear: string;
  /** dd/MM/yyyy of today (DC_Main.cs:1569 {{Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy")}}). */
  today: string;
  /** DC_Main.MsAlterYear = "Y" (not ported: no web setting supplies it). */
  alterYear?: boolean;
  /** DC_Main.MCo_SName = "UAE" (not ported: no web setting supplies it). */
  uae?: boolean;
}

export type SetDateResult =
  { ok: true; text: string } | { ok: false; message: string | null; text: string };

/**
 * DC_Main.SetDate (DC_Main.cs:1565-1690), run by the From/To Enter handlers (RP_ALL.cs:7517, :7533): complete a
 * partial mask from today and the financial-year convention, then refuse an impossible day or month with the desktop
 * message. A single typed digit sets RongDate silently (DC_Main.cs:1600-1603). Pure, so the rule is testable.
 */
export function setDate(typed: string, options: SetDateOptions): SetDateResult {
  const mask = toMask(typed);
  const today = options.today;
  const left = options.coYear.slice(0, 4);
  const right = options.coYear.slice(-4);
  const mid = (text: string, start: number, length: number) =>
    text.slice(start - 1, start - 1 + length);
  const val = (text: string) => {
    const match = /^\s*(\d+)/.exec(text);
    return match ? Number(match[1]) : 0;
  };
  // DC_Main.cs:1572-1575: i is the first `_` (1-based) within the first Len-1 characters.
  let i = 1;
  while (i <= mask.length - 1 && mid(mask, i, 1) !== '_' && mid(mask, i, 1) !== ' ') i += 1;
  const monthOf = (text: string) => val(mid(text, 4, 2));
  let fnYear: string;
  if (options.alterYear) {
    const month = i > 5 ? monthOf(mask) : monthOf(today);
    fnYear = month < 4 ? String(Number(left) + 1) : left;
  } else if (options.uae) {
    fnYear = left;
  } else {
    const month = i > 5 ? monthOf(mask) : monthOf(today);
    fnYear = month < 4 ? right : left;
  }
  if (i === 2) return { ok: false, message: null, text: mask };
  let text: string;
  if (i === 1) text = `${mid(today, 1, 2)}/${mid(today, 4, 2)}/${fnYear}`;
  else if (i >= 3 && i <= 5) text = `${mid(mask, 1, 2)}/${mid(today, 4, 2)}/${fnYear}`;
  else if (i >= 6 && i <= 9) text = `${mid(mask, 1, 2)}/${mid(mask, 4, 2)}/${fnYear}`;
  else text = `${mid(mask, 1, 2)}/${mid(mask, 4, 2)}/${mid(mask, 7, 4)}`;
  const month = val(mid(text, 4, 2));
  const day = val(mid(text, 1, 2));
  const refuse = (message: string): SetDateResult => ({ ok: false, message, text: EMPTY_MASK });
  if (month > 12) return refuse(MONTH_NOT_VALID);
  if (day > 31) return refuse(DATE_NOT_VALID);
  // The web refuses every impossible calendar date the desktop's later Conversions.ToDate would throw on
  // (D7, cases.md invalid.malformed-date-safe), with the desktop's own day message.
  if (!isoDate(text)) return refuse(DATE_NOT_VALID);
  return { ok: true, text };
}

/** The printed cell text, matching the API's formatCell (engine.ts). */
export function formatCell(kind: ApprovalColumnKind, value: string | number | null): string {
  if (value === null || value === undefined || value === '') return '';
  if (kind === 'date') return displayDate(String(value));
  const places = PRECISION[kind];
  if (places === null) return String(value);
  const number = Number(value);
  if (!Number.isFinite(number)) return '';
  return round(number, places).toFixed(places);
}
