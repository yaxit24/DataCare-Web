import { DESKTOP_DATE_MASK, desktopSetDate, round } from '@datacare/core';

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

/** The mask a refused date is reset to (DC_Main.cs:1645 {{MsDate.Text = "__/__/____";}}). */
export const EMPTY_MASK = DESKTOP_DATE_MASK;

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

export type DateEnterResult =
  { ok: true; text: string } | { ok: false; message: string | null; text: string };

/**
 * The From/To Enter handlers run DC_Main.SetDate (RP_ALL.cs:7517, :7533) — the shared core rule
 * (packages/core/src/setDate.ts) completes a partial mask from today and the financial year and refuses an
 * impossible day or month with the desktop message; a single digit is refused silently. The web additionally
 * refuses a date SetDate lets through but the desktop's later Conversions.ToDate would throw on (31/04, 29/02 in a
 * common year), with the desktop's day message, instead of crashing the run (D7, invalid.malformed-date-safe).
 * MsAlterYear and the UAE year rule are not ported settings; the default convention applies.
 */
export function setDate(typed: string, context: { coYear: string; today: Date }): DateEnterResult {
  const result = desktopSetDate(toMask(typed), {
    coYear: context.coYear,
    today: { day: context.today.getDate(), month: context.today.getMonth() + 1 },
  });
  if (result.ok) {
    if (!isoDate(result.text)) return { ok: false, message: 'Date Not Valid...', text: EMPTY_MASK };
    return { ok: true, text: result.text };
  }
  return { ok: false, message: result.silent ? null : result.message, text: result.text };
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
