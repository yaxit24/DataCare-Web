/**
 * TR_TAG_CAN — the one desktop form behind both "Tag Cancel" and "Tag Transfer".
 *
 * The desktop opens the same form from two menus, each on a book of its own `MAIN_BOOK`
 * (`CurBookHelp("TAG CANCEL")` MDI_FORM.cs:8586, `CurBookHelp("TAG TRFR")` :8664). The web keeps one form
 * (components/TagCancelForm.tsx) on two pages, each posting only to its own resource and books.
 *
 * This module is the form's pure half — row state, the desktop's cell events, the request payload and the reopen
 * mapping — so it can be tested without a browser. Every computed cell runs the SAME `@datacare/core` arithmetic the
 * API writes with (`tagCancelRecompute`, `tagCancelStone`, `tagCancelStoneEffect`, `tagCancelTotals`), cell by cell
 * in the operator's own order, with the row's recompute baseline — so what the operator sees is what is saved.
 *
 * Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-29-n18/contract.md (K3-K5, K15).
 */
import {
  baselineFromCells,
  decimalCellText,
  tagCancelRecompute,
  tagCancelStone,
  tagCancelStoneEffect,
  tagCancelTotals,
  type TagCancelBaseline,
  type TagCancelCells,
  type TagCancelSettings,
  type TagCancelTotals,
} from '@datacare/core';
import { companyFlag, companySetting, type CompanySettingValues } from './companySettings';

export type TagCancelMode = 'cancel' | 'transfer';

export interface TagCancelModeConfig {
  mode: TagCancelMode;
  title: string;
  /** API resource; each refuses a book of the other menu. */
  endpoint: '/stock/tag-cancel' | '/stock/tag-transfer';
  /** `BOOK_DATA.MAIN_BOOK` the book picker offers. */
  mainBook: 'TAG CANCEL' | 'TAG TRFR';
  testId: string;
}

export const TAG_CANCEL_MODES: Record<TagCancelMode, TagCancelModeConfig> = {
  cancel: {
    mode: 'cancel',
    title: 'Tag Cancel',
    endpoint: '/stock/tag-cancel',
    mainBook: 'TAG CANCEL',
    testId: 'tag-cancel',
  },
  transfer: {
    mode: 'transfer',
    title: 'Tag Transfer',
    endpoint: '/stock/tag-transfer',
    mainBook: 'TAG TRFR',
    testId: 'tag-transfer',
  },
};

/** Numeric cells an operator types, each with the format `MSG_LeaveCell` gives it. */
export type NumericCell =
  | 'bagWt'
  | 'pcs'
  | 'grossWt'
  | 'lessWt'
  | 'netWt'
  | 'ghtWt'
  | 'touch'
  | 'westPct'
  | 'fine'
  | 'lbrRate'
  | 'lbrAmt'
  | 'othAmt'
  | 'mrp';

export type TextCell =
  'tagNo' | 'itCode' | 'tblCode' | 'designNo' | 'itmSize' | 'krName' | 'trfrItCode';

/** Decimal places of each numeric cell (`MSG_LeaveCell`): weights 3, rates / money / purity 2, pieces 0. */
export const CELL_DECIMALS: Record<NumericCell, number> = {
  bagWt: 3,
  pcs: 0,
  grossWt: 3,
  lessWt: 3,
  netWt: 3,
  ghtWt: 3,
  touch: 2,
  westPct: 2,
  fine: 3,
  lbrRate: 2,
  lbrAmt: 2,
  othAmt: 2,
  mrp: 2,
};

/** One stone row, as the stone grid (`MSG_IDTL`) holds it: every cell a string. */
export interface StoneDraft {
  itCode?: string;
  pcs?: string;
  grossWt?: string;
  karigarWt?: string;
  conPct?: string;
  rateType?: string;
  rate?: string;
  amount?: string;
  lbrRate?: string;
  lbrAmount?: string;
  netAmount?: string;
  conWt?: string;
  karigarConWt?: string;
  itType?: string;
}

/** One grid row. Typed cells are strings, so a blank stays distinguishable from 0 while it is typed. */
export interface GridRow {
  /** React key; never sent. */
  id: number;
  /** OLD_SRNO of a line reopened from the saved voucher ('' for a new line). */
  oldSrNo: string;
  tagNo: string;
  /** The tag instance (VCH_SRNO) the row was filled from. */
  vchSrno: string;
  /** The row was filled from a tag (or reopened as one): ItCode, Counter, Pcs and KrCode are read-only. */
  fromTag: boolean;
  /**
   * The tag number the row's cells came from. A retyped number that differs is not resolved yet: the row still
   * holds the old tag's cells and serial, so it must be resolved (or cleared) before the voucher can be saved.
   */
  filledTag: string;
  itCode: string;
  itName: string;
  tblCode: string;
  designNo: string;
  itmSize: string;
  krName: string;
  bagWt: string;
  pcs: string;
  grossWt: string;
  lessWt: string;
  netWt: string;
  /** Col 14 Ght%: shown from the tag, never saved, never used by the arithmetic. */
  ghtPct: string;
  ghtWt: string;
  touch: string;
  westPct: string;
  fine: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  mrp: string;
  /** Hidden cells the grid computes (cols 41/42, 29-35). */
  rate: string;
  amount: string;
  krOthWt: string;
  krNetWt: string;
  krGhtWt: string;
  krTouch: string;
  krWestPct: string;
  krFine: string;
  lbrType: string;
  rateType: string;
  itType: string;
  prCode: string;
  designImageId: string;
  trfrItCode: string;
  trfrItName: string;
  /** Hidden cols 56/57/60-64: what each input was when the row was last computed. */
  baseline: TagCancelBaseline;
  stones: StoneDraft[];
  /** The operator changed this row's stones; only then are they sent (otherwise the tag's or the saved ones stand). */
  stonesEdited: boolean;
}

export interface TagCancelScreenSettings extends TagCancelSettings {
  /** `CO_SET.LBR_TYPE` (`MsLbrType`, blank is 'G'): the labour basis of a new row (`CommPassAdd` col 23). */
  companyLabourType: string;
}

/** The settings the grid honours, from `GET /settings`. */
export function tagCancelSettings(values: CompanySettingValues | null): TagCancelScreenSettings {
  const labourType = String(companySetting(values, 'LBR_TYPE') ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  return {
    labourIncludesGhat: companyFlag(values, 'LBR_WITH_GHT', 'Y'),
    companyLabourType: ['G', 'N', 'K', 'P'].includes(labourType) ? labourType : 'G',
  };
}

// ---- helpers --------------------------------------------------------------------------------------

const n = (value: unknown): number => {
  const x = Number(String(value ?? '').trim() || 0);
  return Number.isFinite(x) ? x : 0;
};
const cellText = (value: unknown, decimals: number): string => decimalCellText(n(value), decimals);
/** A number shown in a grid cell: the desktop's fixed format, blank for a row that has nothing. */
export const showCell = (value: string, decimals: number): string =>
  String(value ?? '').trim() === '' ? '' : cellText(value, decimals);

/** The form upper-cases every key and swallows the apostrophe (KeyPreview, `TR_TAG_CAN_KeyPress`). */
export const typedText = (value: string): string => value.replace(/'/g, '').toUpperCase();

export function todayLocal(now = new Date()): string {
  const pad = (value: number) => String(value).padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}`;
}

let nextId = 1;
const rowId = () => nextId++;

// ---- rows -----------------------------------------------------------------------------------------

/**
 * A new grid row: `CommPassAdd` (TR_TAG_CAN.cs) — the company labour basis in LType, Image 'N', and in Tag Transfer
 * the previous row's transfer item.
 */
export function blankRow(
  settings: Pick<TagCancelScreenSettings, 'companyLabourType'>,
  mode: TagCancelMode,
  previous?: GridRow,
): GridRow {
  return {
    id: rowId(),
    oldSrNo: '',
    tagNo: '',
    vchSrno: '',
    fromTag: false,
    filledTag: '',
    itCode: '',
    itName: '',
    tblCode: '',
    designNo: '',
    itmSize: '',
    krName: '',
    bagWt: '',
    pcs: '',
    grossWt: '',
    lessWt: '',
    netWt: '',
    ghtPct: '',
    ghtWt: '',
    touch: '',
    westPct: '',
    fine: '',
    lbrRate: '',
    lbrAmt: '',
    othAmt: '',
    mrp: '',
    rate: '',
    amount: '',
    krOthWt: '',
    krNetWt: '',
    krGhtWt: '',
    krTouch: '',
    krWestPct: '',
    krFine: '',
    lbrType: settings.companyLabourType,
    rateType: '',
    itType: '',
    prCode: '',
    designImageId: 'N',
    trfrItCode: mode === 'transfer' && previous ? previous.trfrItCode : '',
    trfrItName: mode === 'transfer' && previous ? previous.trfrItName : '',
    baseline: baselineFromCells(null),
    stones: [],
    stonesEdited: false,
  };
}

/** A row the operator has put anything into; the spare last row is not sent. */
export function isActiveRow(row: GridRow): boolean {
  if (row.tagNo.trim() || row.itCode.trim() || row.oldSrNo) return true;
  return (Object.keys(CELL_DECIMALS) as NumericCell[]).some((field) => n(row[field]) !== 0);
}

/**
 * `CommPassAdd` in Tag Transfer: a new row starts with the previous row's transfer item (TR_TAG_CAN.cs:2830). The desktop
 * adds the row after the previous one is finished; the web keeps a spare row ready before the previous row's transfer
 * item is chosen, so the copy is made when the spare row is put to use — and only if it has no transfer item of its own.
 */
export function withPreviousTransfer(
  row: GridRow,
  previous: GridRow | undefined,
  mode: TagCancelMode,
): GridRow {
  if (mode !== 'transfer' || !previous || row.trfrItCode.trim() || !previous.trfrItCode.trim()) {
    return row;
  }
  return { ...row, trfrItCode: previous.trfrItCode, trfrItName: previous.trfrItName };
}

/** A row change, with `CommPassAdd`'s transfer-item copy when the change puts a spare row to use. */
export function changeRow(
  rows: readonly GridRow[],
  index: number,
  change: (row: GridRow) => GridRow,
  mode: TagCancelMode,
): GridRow[] {
  return rows.map((row, i) => {
    if (i !== index) return row;
    const next = change(row);
    return !isActiveRow(row) && isActiveRow(next)
      ? withPreviousTransfer(next, rows[i - 1], mode)
      : next;
  });
}

/** The desktop grid always keeps a spare row under the last one typed. */
export function withSpareRow(
  rows: GridRow[],
  settings: Pick<TagCancelScreenSettings, 'companyLabourType'>,
  mode: TagCancelMode,
): GridRow[] {
  const last = rows[rows.length - 1];
  if (!last) return [blankRow(settings, mode)];
  return isActiveRow(last) ? [...rows, blankRow(settings, mode, last)] : rows;
}

/** The fill the API returns for one live instance (`GET …/source`). */
export interface TagSourceView {
  tagNo: string;
  vchSrno: number;
  source: 'BAR_DETL' | 'TAG_STOCK';
  itName: string;
  line: Record<string, unknown>;
  stones: Array<Record<string, unknown>>;
}

const stoneFromApi = (stone: Record<string, unknown>): StoneDraft => ({
  itCode: String(stone.itCode ?? ''),
  pcs: String(n(stone.pcs)),
  grossWt: cellText(stone.grossWt, 3),
  karigarWt: cellText(stone.karigarWt, 3),
  conPct: cellText(stone.conPct, 3),
  rateType: String(stone.rateType ?? ''),
  rate: cellText(stone.rate, 2),
  amount: cellText(stone.amount, 2),
  lbrRate: cellText(stone.lbrRate, 2),
  lbrAmount: cellText(stone.lbrAmount, 2),
  netAmount: cellText(stone.netAmount, 2),
  conWt: cellText(stone.conWt, 3),
  karigarConWt: cellText(stone.karigarConWt, 3),
  itType: String(stone.itType ?? ''),
});

/** A grid row from the API's line cells (a tag fill or a saved line), with the desktop's cell formats. */
function rowFromCells(
  cells: Record<string, unknown>,
  base: Partial<GridRow>,
  settings: Pick<TagCancelScreenSettings, 'companyLabourType'>,
  mode: TagCancelMode,
): GridRow {
  const text = (field: string) => String(cells[field] ?? '');
  const row: GridRow = {
    ...blankRow(settings, mode),
    ...base,
    tagNo: text('tagNo'),
    vchSrno: n(cells.vchSrno) ? String(n(cells.vchSrno)) : '',
    fromTag: text('tagNo').trim() !== '',
    filledTag: text('tagNo').trim(),
    itCode: text('itCode'),
    tblCode: text('tblCode'),
    designNo: text('designNo'),
    itmSize: text('itmSize'),
    krName: text('krName'),
    bagWt: cellText(cells.bagWt, 3),
    pcs: String(n(cells.pcs)),
    grossWt: cellText(cells.grossWt, 3),
    lessWt: cellText(cells.lessWt, 3),
    netWt: cellText(cells.netWt, 3),
    ghtPct: cellText(cells.ghtPct, 2),
    ghtWt: cellText(cells.ghtWt, 3),
    touch: cellText(cells.touch, 2),
    westPct: cellText(cells.westPct, 2),
    fine: cellText(cells.fine, 3),
    lbrRate: cellText(cells.lbrRate, 2),
    lbrAmt: cellText(cells.lbrAmt, 2),
    othAmt: cellText(cells.othAmt, 2),
    mrp: cellText(cells.mrp, 2),
    rate: String(n(cells.rate)),
    amount: String(n(cells.amount)),
    krOthWt: '0',
    krNetWt: String(n(cells.krNetWt)),
    krGhtWt: '0',
    krTouch: String(n(cells.krTouch)),
    krWestPct: String(n(cells.krWestPct)),
    krFine: String(n(cells.krFine)),
    lbrType: text('lbrType'),
    rateType: text('rateType'),
    itType: text('itType'),
    prCode: text('prCode'),
    designImageId: text('designImageId'),
    stonesEdited: false,
  };
  // The tag fill sets cols 56/57/60/61 (and DISPLAY_DATA does too); nothing sets the karigar baseline.
  row.baseline = baselineFromCells({
    grossWt: n(row.grossWt),
    netWt: n(row.netWt),
    touch: n(row.touch),
    westPct: n(row.westPct),
  });
  return row;
}

/**
 * Tag entry (TR_TAG_CAN.cs:3859-4090): the row filled from the live instance the operator chose. The row keeps its
 * place on the voucher (OLD_SRNO) and, in Tag Transfer, its transfer item.
 */
export function rowFromSource(
  source: TagSourceView,
  current: GridRow,
  settings: Pick<TagCancelScreenSettings, 'companyLabourType'>,
  mode: TagCancelMode,
): GridRow {
  return rowFromCells(
    { ...source.line, tagNo: source.tagNo, vchSrno: source.vchSrno },
    {
      id: current.id,
      oldSrNo: current.oldSrNo,
      itName: source.itName,
      trfrItCode: current.trfrItCode,
      trfrItName: current.trfrItName,
      stones: source.stones.map(stoneFromApi),
    },
    settings,
    mode,
  );
}

/** A saved line, as `DISPLAY_DATA` puts it back on the grid (TR_TAG_CAN.cs:4747-4800). */
export function rowFromSaved(
  line: Record<string, unknown>,
  settings: Pick<TagCancelScreenSettings, 'companyLabourType'>,
  mode: TagCancelMode,
): GridRow {
  return rowFromCells(
    line,
    {
      oldSrNo: String(n(line.oldSrNo)),
      itName: String(line.itName ?? ''),
      trfrItCode: String(line.trfrItCode ?? ''),
      trfrItName: String(line.trfrItName ?? ''),
      stones: Array.isArray(line.stones)
        ? (line.stones as Array<Record<string, unknown>>).map(stoneFromApi)
        : [],
    },
    settings,
    mode,
  );
}

// ---- cell events ----------------------------------------------------------------------------------

/** Typing into a cell (the TEXT_ENTRY box): nothing is computed until the cell is left. */
export function setCell(row: GridRow, field: NumericCell | TextCell, value: string): GridRow {
  // Retyping the tag number of a filled row starts the row afresh only when the new number is resolved; until then
  // the old tag's cells stay, as the desktop leaves them until Enter.
  return { ...row, [field]: field in CELL_DECIMALS ? value : typedText(value) };
}

const toCells = (row: GridRow): TagCancelCells => ({
  tagged: row.fromTag,
  pcs: n(row.pcs),
  grossWt: n(row.grossWt),
  lessWt: n(row.lessWt),
  netWt: n(row.netWt),
  ghtWt: n(row.ghtWt),
  touch: n(row.touch),
  westPct: n(row.westPct),
  fine: n(row.fine),
  lbrType: row.lbrType,
  lbrRate: n(row.lbrRate),
  lbrAmt: n(row.lbrAmt),
  krOthWt: n(row.krOthWt),
  krNetWt: n(row.krNetWt),
  krGhtWt: n(row.krGhtWt),
  krTouch: n(row.krTouch),
  krWestPct: n(row.krWestPct),
  krFine: n(row.krFine),
  rate: n(row.rate),
  amount: n(row.amount),
  rateType: row.rateType,
});

function recompute(row: GridRow, settings: TagCancelSettings): GridRow {
  const { cells, baseline } = tagCancelRecompute(toCells(row), row.baseline, settings);
  return {
    ...row,
    netWt: cellText(cells.netWt, 3),
    fine: cellText(cells.fine, 3),
    lbrAmt: cellText(cells.lbrAmt, 2),
    amount: String(cells.amount),
    krNetWt: String(cells.krNetWt),
    krTouch: String(cells.krTouch),
    krWestPct: String(cells.krWestPct),
    krFine: String(cells.krFine),
    baseline,
  };
}

const stoneCells = (stone: StoneDraft) => ({
  pcs: n(stone.pcs),
  grossWt: n(stone.grossWt),
  karigarWt: n(stone.karigarWt),
  conPct: n(stone.conPct),
  rateType: String(stone.rateType ?? '')
    .trim()
    .toUpperCase(),
  rate: n(stone.rate),
  amount: n(stone.amount),
  lbrRate: n(stone.lbrRate),
  lbrAmount: n(stone.lbrAmount),
  netAmount: n(stone.netAmount),
  conWt: n(stone.conWt),
  karigarConWt: n(stone.karigarConWt),
});

/** What the row's stones do to it (`CommPassTotal_Idtl`, TR_TAG_CAN.cs:2330-2370). */
function applyStones(row: GridRow): GridRow {
  const effect = tagCancelStoneEffect(
    {
      grossWt: n(row.grossWt),
      lessWt: n(row.lessWt),
      netWt: n(row.netWt),
      krOthWt: n(row.krOthWt),
      krNetWt: n(row.krNetWt),
      othAmt: n(row.othAmt),
    },
    row.stones.map(stoneCells),
  );
  return {
    ...row,
    lessWt: cellText(effect.lessWt, 3),
    netWt: cellText(effect.netWt, 3),
    krOthWt: String(effect.krOthWt),
    krNetWt: String(effect.krNetWt),
    othAmt: cellText(effect.othAmt, 2),
  };
}

/**
 * Leaving a numeric cell (`MSG_LeaveCell`): the typed value takes the column's format and the row recomputes
 * (`CommPassTotal`) — whether or not the value changed, as the desktop does. Pcs (col 10) only stores its value;
 * LsWt (col 12) first re-applies the row's stones (`CommPassTotal_Idtl(1)`).
 */
export function commitCell(row: GridRow, field: NumericCell, settings: TagCancelSettings): GridRow {
  const formatted = { ...row, [field]: cellText(row[field], CELL_DECIMALS[field]) } as GridRow;
  if (field === 'pcs') return formatted;
  const withStones = field === 'lessWt' && row.stones.length ? applyStones(formatted) : formatted;
  return recompute(withStones, settings);
}

/**
 * Leaving a stone cell (`MSG_IDTL_LeaveCell` → `CommPassTotal_Idtl`): the stone row recomputes, and the row's stone
 * sums act on it (less / net weight, karigar weight, other amount). The main row's fine is not recomputed until one
 * of its own cells is left, as on the desktop.
 */
export function commitStone(row: GridRow, index: number): GridRow {
  const stone = row.stones[index];
  if (!stone) return row;
  const computed = tagCancelStone(stoneCells(stone));
  const stones = row.stones.map((current, i) =>
    i === index
      ? {
          ...current,
          itCode: typedText(String(current.itCode ?? '')),
          pcs: String(computed.pcs),
          grossWt: cellText(computed.grossWt, 3),
          karigarWt: cellText(computed.karigarWt, 3),
          conPct: cellText(computed.conPct, 3),
          rate: cellText(computed.rate, 2),
          amount: cellText(computed.amount, 2),
          lbrRate: cellText(computed.lbrRate, 2),
          lbrAmount: cellText(computed.lbrAmount, 2),
          netAmount: cellText(computed.netAmount, 2),
          conWt: cellText(computed.conWt, 3),
          karigarConWt: cellText(computed.karigarConWt, 3),
        }
      : current,
  );
  return applyStones({ ...row, stones, stonesEdited: true });
}

/** A row whose typed tag number has not been resolved to a live instance yet. */
export const unresolvedTag = (row: GridRow): boolean =>
  row.tagNo.trim() !== '' && row.tagNo.trim() !== row.filledTag;

/** "Duplicate Tag No" (TR_TAG_CAN.cs:3907-3915): the number is on another row already. */
export function duplicateTag(rows: readonly GridRow[], index: number, tagNo: string): boolean {
  const wanted = typedText(tagNo).trim();
  return (
    wanted !== '' &&
    rows.some((row, i) => i !== index && row.fromTag && row.tagNo.trim().toUpperCase() === wanted)
  );
}

/** `MSG_TOT_FILL`: the totals row under the grid. */
export function gridTotals(rows: readonly GridRow[]): TagCancelTotals {
  return tagCancelTotals(
    rows.map((row) => ({
      pcs: n(row.pcs),
      bagWt: n(row.bagWt),
      grossWt: n(row.grossWt),
      lessWt: n(row.lessWt),
      netWt: n(row.netWt),
      ghtWt: n(row.ghtWt),
      fine: n(row.fine),
      amount: n(row.amount),
      lbrAmt: n(row.lbrAmt),
      othAmt: n(row.othAmt),
      mrp: n(row.mrp),
      krNetWt: n(row.krNetWt),
      krFine: n(row.krFine),
    })),
  );
}

// ---- payload --------------------------------------------------------------------------------------

const filledStone = (stone: StoneDraft): boolean =>
  Object.values(stone).some((value) => String(value ?? '').trim() !== '');

/**
 * One line of the request. Every cell of the row is sent, so the server saves exactly the row on screen; the stones
 * only when the operator edited them (otherwise a new tag line takes the tag's own and a reopened line keeps its
 * saved ones). Read-only tag cells are sent as they came, which the server accepts.
 */
export function linePayload(row: GridRow, mode: TagCancelMode): Record<string, unknown> {
  const tagged = row.fromTag && row.filledTag !== '';
  const line: Record<string, unknown> = {
    tagNo: tagged ? row.filledTag : undefined,
    vchSrno: tagged && row.vchSrno ? n(row.vchSrno) : undefined,
    itCode: row.itCode.trim() || undefined,
    oldSrNo: row.oldSrNo ? n(row.oldSrNo) : undefined,
    tblCode: row.tblCode,
    designNo: row.designNo,
    itmSize: row.itmSize,
    bagWt: n(row.bagWt),
    pcs: n(row.pcs),
    grossWt: n(row.grossWt),
    lessWt: n(row.lessWt),
    netWt: n(row.netWt),
    ghtWt: n(row.ghtWt),
    touch: n(row.touch),
    westPct: n(row.westPct),
    fine: n(row.fine),
    lbrRate: n(row.lbrRate),
    lbrAmt: n(row.lbrAmt),
    othAmt: n(row.othAmt),
    mrp: n(row.mrp),
    amount: n(row.amount),
    krName: row.krName,
    krNetWt: n(row.krNetWt),
    krTouch: n(row.krTouch),
    krWestPct: n(row.krWestPct),
    krFine: n(row.krFine),
  };
  if (mode === 'transfer') line.trfrItCode = row.trfrItCode.trim();
  if (row.stonesEdited) {
    line.stones = row.stones.filter(filledStone).map((stone) => ({
      itCode: String(stone.itCode ?? '').trim() || undefined,
      pcs: n(stone.pcs),
      grossWt: n(stone.grossWt),
      karigarWt: n(stone.karigarWt),
      conPct: n(stone.conPct),
      rateType: String(stone.rateType ?? '').trim(),
      rate: n(stone.rate),
      amount: n(stone.amount),
      lbrRate: n(stone.lbrRate),
      lbrAmount: n(stone.lbrAmount),
      netAmount: n(stone.netAmount),
      conWt: n(stone.conWt),
      itType: String(stone.itType ?? '').trim() || undefined,
    }));
  }
  return line;
}

export interface VoucherHeaderDraft {
  vchDate: string;
  empCode: string;
  empName: string;
  vchDesc: string;
}

export const blankHeader = (vchDate = todayLocal()): VoucherHeaderDraft => ({
  vchDate,
  empCode: '',
  empName: '',
  vchDesc: '',
});

/** The request body: the header and every row the operator used (the spare row is not sent). */
export function voucherPayload(
  header: VoucherHeaderDraft,
  rows: readonly GridRow[],
  mode: TagCancelMode,
  scope: { coBook: string; coYear?: string; lcCode?: string },
): Record<string, unknown> {
  return {
    coBook: scope.coBook,
    coYear: scope.coYear,
    lcCode: scope.lcCode,
    vchDate: header.vchDate,
    empCode: header.empCode.trim(),
    vchDesc: typedText(header.vchDesc).trim(),
    lines: rows.filter(isActiveRow).map((row) => linePayload(row, mode)),
  };
}

/** The neighbour a `<` / `>` button opens: the nearest saved voucher below / above the current number. */
export function neighbourVoucher(
  numbers: readonly string[],
  current: string,
  direction: 'previous' | 'next',
): string | null {
  const here = n(current);
  const sorted = numbers.map((value) => n(value)).sort((a, b) => a - b);
  const found =
    direction === 'previous'
      ? [...sorted].reverse().find((value) => value < here)
      : sorted.find((value) => value > here);
  return found == null ? null : String(found).padStart(5, '0');
}
