import {
  baselineFromCells,
  round,
  tagCancelRecompute,
  tagCancelStone,
  tagCancelStoneEffect,
  type TagCancelBaseline,
  type TagCancelSettings,
  type TagCancelStoneCells,
} from '@datacare/core';

/**
 * TR_TAG_CAN row model — Tag Cancel and Tag Transfer (contract:
 * `parity-plan-2026-09-10/evidence/implementation-2026-09-29-n18/contract.md`, clauses K3-K8, K11).
 *
 * Pure functions only: the tag fill, the operator's edits replayed through the desktop grid arithmetic, and the
 * exact desktop rows for BAR_CAN_DATA / BAR_CAN_DETL / BAR_CAN_IDTL / MAIN_STOCK / DM_DATA / DELETE_DATA. The
 * transaction flow (book, locks, identity, persistence) lives in `tagCancel.ts`.
 *
 * Desktop source: TR_TAG_CAN.cs (sha256/16 04e7ae5842f63116) and Ac_Stock.cs (946f9ba4f7e85835). Column numbers
 * in comments are the desktop `MSG` grid's.
 */

export type TagCancelMode = 'cancel' | 'transfer';

/** The `MAIN_BOOK` each menu opens the form on (MDI_FORM.cs:8586 "TAG CANCEL", :8664 "TAG TRFR"). */
export const TAG_CANCEL_MAIN_BOOKS: Readonly<Record<TagCancelMode, string>> = Object.freeze({
  cancel: 'TAG CANCEL',
  transfer: 'TAG TRFR',
});

export class TagCancelValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TagCancelValidationError';
  }
}

/** Two writers raced for the same tags and the database aborted one of them; nothing was written. */
export class TagCancelConflictError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TagCancelConflictError';
  }
}

/** One stone of a line (`MSG_IDTL`, TR_TAG_CAN.cs:1865-1953), as a caller supplies it. */
export interface TagCancelStoneInput {
  itCode?: string;
  pcs?: number;
  /** Col 4 "Weight" → IT_GWT. */
  grossWt?: number;
  /** Col 5 "KrWt" → KR_WT. */
  karigarWt?: number;
  /** Col 6 "Con%" → IT_CON_PRC. */
  conPct?: number;
  /** Col 7 "P/W" → IT_RATE_TYPE. */
  rateType?: string;
  rate?: number;
  /** Col 9 "ItAmt" → IT_AMT. */
  amount?: number;
  lbrRate?: number;
  /** Col 11 "LbrAmt" → IT_LBR_AMT. */
  lbrAmount?: number;
  /** Col 12 "NetAmt" → IT_NET_AMT. */
  netAmount?: number;
  /** Col 13 "ConWt" (hidden) → IT_CON_WT. */
  conWt?: number;
  /** Col 15 "ItType" (hidden) → IT_TYPE. */
  itType?: string;
}

/**
 * One grid row as a caller supplies it.
 *
 * A row with a tag number is a TAG line: it starts from the tag (K3) and only the cells the operator can type on a
 * tag line may differ from it. A row without one is a LOOSE line (TAG_NO 'N', VCH_SRNO 0). Every cell given is
 * stored as given; a cell left out is derived by replaying the given cells through the desktop grid arithmetic in
 * column order (K4). The screen sends every cell, so what it shows is what is saved.
 */
export interface TagCancelLineInput {
  /** Col 1 TagNo. Blank → a loose line. */
  tagNo?: string;
  /** Col 40, the tag instance. Required when two live instances share the tag number. */
  vchSrno?: number;
  /** Col 4 ItCode. From the tag on a tag line; required on a loose line (and on a web TAG_STOCK tag). */
  itCode?: string;
  /** Col 47 OLD_SRNO of a line already on the voucher being edited; a line without one is new. */
  oldSrNo?: number;
  /** Col 5 Counter (TBL_CODE) — typed on a loose line only. */
  tblCode?: string;
  /** Col 6 Design. */
  designNo?: string;
  /** Col 7 Size. */
  itmSize?: string;
  /** Col 9 BagWt. */
  bagWt?: number;
  /** Col 10 Pcs — typed on a loose line only. */
  pcs?: number;
  /** Col 11 GrWt. */
  grossWt?: number;
  /** Col 12 LsWt → ITM_OTH_WT. */
  lessWt?: number;
  /** Col 13 NetWt. */
  netWt?: number;
  /** Col 15 GhtWt (Tag Cancel grid only). */
  ghtWt?: number;
  /** Col 16 Touch. */
  touch?: number;
  /** Col 17 West%. */
  westPct?: number;
  /** Col 18 Fine. */
  fine?: number;
  /** Col 24 LbrRate (Tag Cancel grid only). */
  lbrRate?: number;
  /** Col 25 LbrAmt (Tag Cancel grid only). */
  lbrAmt?: number;
  /** Col 26 OthAmt (Tag Cancel grid only). */
  othAmt?: number;
  /** Col 27 Mrp (Tag Cancel grid only). */
  mrp?: number;
  /** Col 42 ItAmt — a hidden cell the grid computes; accepted so the screen saves the row it shows. */
  amount?: number;
  /** Col 28 KrCode (Tag Cancel grid, loose line only) → KR_NAME. */
  krName?: string;
  /** Cols 30, 33, 34, 35 — hidden karigar cells the grid computes; accepted for the same reason as `amount`. */
  krNetWt?: number;
  krTouch?: number;
  krWestPct?: number;
  krFine?: number;
  /** Col 20 TrfrItm (Tag Transfer grid only) → TRFR_IT_CODE: the loose item the metal moves to. */
  trfrItCode?: string;
  /**
   * The line's stones. Omitted: a new tag line copies the tag's `BAR_IDTL` rows (K5.1) and a line kept from the
   * saved voucher keeps its saved stones (K5.2). Given (an empty array included): exactly these.
   */
  stones?: TagCancelStoneInput[];
}

/** A grid row's cells: the tag fill (or a new row), then the operator's edits — exactly what BAR_CAN_DETL stores. */
export interface TagCancelRowCells {
  tagNo: string;
  vchSrno: number;
  itCode: string;
  tblCode: string;
  designNo: string;
  lotNo: string;
  itmLot: string;
  itmSize: string;
  bagWt: number;
  pcs: number;
  grossWt: number;
  lessWt: number;
  netWt: number;
  /** Col 14 Ght% — shown from the tag, never saved (BAR_CAN_DETL has no column) and never used by the arithmetic. */
  ghtPct: number;
  ghtWt: number;
  touch: number;
  westPct: number;
  fine: number;
  lbrPct: number;
  lbrType: string;
  lbrRate: number;
  lbrAmt: number;
  othAmt: number;
  rate: number;
  amount: number;
  mrp: number;
  /** Col 29 KrOthWt and col 32 KrGht: transient grid cells (no BAR_CAN_DETL column). */
  krOthWt: number;
  krNetWt: number;
  krGhtWt: number;
  krTouch: number;
  krWestPct: number;
  krFine: number;
  krName: string;
  rateType: string;
  itType: string;
  prCode: string;
  designImageId: string;
  trfrItCode: string;
}

/** One stone row as the stone grid holds it (DtIdtl, TR_TAG_CAN.cs:1252). */
export interface TagCancelStoneRow {
  isrNo: number;
  itCode: string;
  itName: string;
  pcs: number;
  grossWt: number;
  karigarWt: number;
  conPct: number;
  rateType: string;
  rate: number;
  amount: number;
  lbrRate: number;
  lbrAmount: number;
  netAmount: number;
  conWt: number;
  karigarConWt: number;
  itType: string;
}

/** A line ready to be written: its cells, its place on the voucher, and its stones. */
export interface TagCancelWriteLine {
  cells: TagCancelRowCells;
  srNo: number;
  oldSrNo: number;
  stones: TagCancelStoneRow[];
}

export interface TagCancelBookPolicy {
  /** BOOK_DATA.BOOK_NAME — TEMP_BOOK_DATA and DELETE_DATA. */
  name: string;
  /** BOOK_SNAME — VCH_TYPE on every row, and DM_DATA.BOOK_NAME. */
  shortName: string;
  /** MAIN_BOOK — BOOK_NAME on the register and stock rows. */
  mainBook: string;
  /** BOOK_INOUT — INOUT_TYPE on the register rows. */
  inout: string;
  /** BOOK_DATA.DATA_TYPE — MAIN_STOCK.DATA_TYPE ('A' when blank). */
  dataType: string;
}

export interface TagCancelWriteContext {
  mode: TagCancelMode;
  key: { CO_CODE: string; LC_CODE: string; CO_YEAR: string; CO_BOOK: string; VCH_NO: string };
  book: TagCancelBookPolicy;
  hiddenVoucherNo: string;
  vchDate: Date;
  vchTime: Date;
  mainUser: string;
  empCode: string;
  vchDesc: string;
}

// ---- value helpers -------------------------------------------------------------------------------

export const num = (value: unknown): number => {
  const x = Number(value ?? 0);
  return Number.isFinite(x) ? x : 0;
};
/** `Strings.Format(x, "0.000")`. */
export const f3 = (value: unknown): number => round(num(value), 3);
/** `Strings.Format(x, "0.00")`. */
export const f2 = (value: unknown): number => round(num(value), 2);
/** `Strings.Format(x, "0")` — the Pcs cell. */
const f0 = (value: unknown): number => round(num(value), 0);
/** A value read from the database, copied as the desktop copies it: NULL becomes '', nothing is trimmed. */
export const dbText = (value: unknown): string => (value == null ? '' : String(value));
/**
 * A value an operator typed. The form upper-cases every key and swallows the apostrophe
 * (`TR_TAG_CAN_KeyPress`, KeyPreview on — TR_TAG_CAN.cs:1247, :1851).
 */
export const typedText = (value: unknown, max = 255): string =>
  String(value ?? '')
    .replace(/'/g, '')
    .trim()
    .toUpperCase()
    .slice(0, max);
const given = (value: unknown): boolean =>
  value != null && !(typeof value === 'string' && value.trim() === '');
const isLoose = (tagNo: unknown): boolean => {
  const tag = String(tagNo ?? '').trim();
  return tag === '' || tag.toUpperCase() === 'N';
};

// ---- the tag fill (K3) ---------------------------------------------------------------------------

/**
 * Tag entry, TR_TAG_CAN.cs:4020-4085: the grid row filled from the first `BAR_DETL` row of the instance, with the
 * grid's own formats. A tag with no touch takes its karigar touch, wastage and fine instead (:4043-4050). KrNwt is
 * formatted to TWO places (:4053, "0.00"), so that is what the desktop saves for an untouched tag line.
 */
export function cellsFromBarDetl(source: Record<string, unknown>): TagCancelRowCells {
  const touch = f2(source.ITM_TOUCH);
  const karigarPurity = touch === 0;
  return {
    tagNo: dbText(source.TAG_NO),
    vchSrno: num(source.VCH_SRNO),
    itCode: dbText(source.IT_CODE),
    tblCode: dbText(source.TBL_CODE),
    designNo: dbText(source.DESIGN_NO),
    lotNo: '',
    itmLot: '',
    itmSize: dbText(source.ITM_SIZE),
    bagWt: f3(source.BAG_WT),
    pcs: num(source.ITM_PCS),
    grossWt: f3(source.ITM_GWT),
    lessWt: f3(source.ITM_OTH_WT),
    netWt: f3(source.ITM_NWT),
    ghtPct: f2(source.ITM_GHT_PRC),
    ghtWt: f3(source.ITM_GHT_WT),
    touch: karigarPurity ? f2(source.KR_TOUCH) : touch,
    westPct: karigarPurity ? f2(source.KR_WEST_PRC) : f2(source.ITM_WEST_PRC),
    fine: karigarPurity ? f3(source.KR_FINE) : f3(source.ITM_FINE),
    lbrPct: f2(source.LBR_PRC),
    lbrType: dbText(source.LBR_TYPE),
    lbrRate: f2(source.LBR_RATE),
    lbrAmt: f2(source.LBR_AMT),
    othAmt: f2(source.OTH_AMT),
    rate: f2(source.ITM_RATE),
    amount: f2(source.ITM_AMT),
    mrp: f2(source.ITM_MRP),
    krOthWt: 0,
    krNetWt: f2(source.KR_NET_WT),
    krGhtWt: 0,
    krTouch: f2(source.KR_TOUCH),
    krWestPct: f2(source.KR_WEST_PRC),
    krFine: f3(source.KR_FINE),
    krName: dbText(source.KR_NAME),
    rateType: dbText(source.RATE_TYPE),
    itType: dbText(source.IT_TYPE),
    prCode: dbText(source.PR_CODE),
    designImageId: dbText(source.DESIGN_IMG_ID),
    trfrItCode: '',
  };
}

export interface TagCancelItem {
  itCode: string;
  itName: string;
  itType: string;
  prCode: string;
  rateType: string;
  /** ITEM_MAST.OTH_DETL_POSTING = 'Y': its stones post to DM_DATA (Dm_Tag_Cancel_Detl). */
  postsDiamonds: boolean;
}

/**
 * A web-created tag that exists only in `TAG_STOCK` (the desktop has no such table). It carries no item code, touch
 * or karigar block, so the line names the item and the purity cells start at 0.
 */
export function cellsFromTagStock(
  source: Record<string, unknown>,
  item: TagCancelItem,
): TagCancelRowCells {
  return {
    ...blankCells(),
    tagNo: dbText(source.TAG_NO),
    vchSrno: num(source.VCH_SRNO),
    itCode: item.itCode,
    designNo: dbText(source.DESIGN_NO),
    itmSize: dbText(source.ITM_SIZE),
    pcs: num(source.ITM_PCS),
    grossWt: f3(source.ITM_GWT),
    netWt: f3(source.ITM_NWT),
    lbrPct: f2(source.LBR_PRC),
    lbrType: dbText(source.LBR_TYPE),
    lbrRate: f2(source.LBR_RATE),
    lbrAmt: f2(source.LBR_AMT),
    othAmt: f2(source.OTH_AMT),
    mrp: f2(source.ITM_MRP),
    rateType: item.rateType,
    itType: dbText(source.IT_TYPE) || item.itType,
    prCode: dbText(source.PR_CODE) || item.prCode,
    designImageId: dbText(source.DESIGN_IMG_ID),
  };
}

/**
 * A new loose row: `CommPassAdd` (LType = the company basis, Image 'N') and the item cell's lookup
 * (TR_TAG_CAN.cs:4219-4226: IT_TYPE, PR_CODE, RATE_TYPE from ITEM_MAST).
 */
export function looseCells(item: TagCancelItem, companyLabourType: string): TagCancelRowCells {
  return {
    ...blankCells(),
    itCode: item.itCode,
    lbrType: companyLabourType,
    rateType: item.rateType,
    itType: item.itType,
    prCode: item.prCode,
    designImageId: 'N',
  };
}

/** A saved line as `DISPLAY_DATA` puts it back on the grid (TR_TAG_CAN.cs:4747-4800). */
export function cellsFromSaved(row: Record<string, unknown>): TagCancelRowCells {
  const tagNo = dbText(row.TAG_NO);
  return {
    tagNo: tagNo === 'N' ? '' : tagNo,
    vchSrno: num(row.VCH_SRNO),
    itCode: dbText(row.IT_CODE),
    tblCode: dbText(row.TBL_CODE),
    designNo: dbText(row.DESIGN_NO),
    lotNo: dbText(row.LOT_NO),
    itmLot: dbText(row.ITM_LOT),
    itmSize: dbText(row.ITM_SIZE),
    bagWt: f3(row.BAG_WT),
    pcs: num(row.ITM_PCS),
    grossWt: f3(row.ITM_GWT),
    lessWt: f3(row.ITM_OTH_WT),
    netWt: f3(row.ITM_NWT),
    ghtPct: 0,
    ghtWt: f3(row.ITM_GHT_WT),
    touch: f2(row.ITM_TOUCH),
    westPct: f2(row.ITM_WEST_PRC),
    fine: f3(row.ITM_FINE),
    lbrPct: f2(row.LBR_PRC),
    lbrType: dbText(row.LBR_TYPE),
    lbrRate: f2(row.LBR_RATE),
    lbrAmt: f2(row.LBR_AMT),
    othAmt: f2(row.OTH_AMT),
    rate: f2(row.ITM_RATE),
    amount: f2(row.ITM_AMT),
    mrp: f2(row.ITM_MRP),
    krOthWt: 0,
    krNetWt: f3(row.KR_NET_WT),
    krGhtWt: 0,
    krTouch: f2(row.KR_TOUCH),
    krWestPct: f2(row.KR_WEST_PRC),
    krFine: f3(row.KR_FINE),
    krName: dbText(row.KR_NAME),
    rateType: dbText(row.RATE_TYPE),
    itType: dbText(row.IT_TYPE),
    prCode: dbText(row.PR_CODE),
    designImageId: dbText(row.DESIGN_IMG_ID),
    trfrItCode: dbText(row.TRFR_IT_CODE),
  };
}

function blankCells(): TagCancelRowCells {
  return {
    tagNo: '',
    vchSrno: 0,
    itCode: '',
    tblCode: '',
    designNo: '',
    lotNo: '',
    itmLot: '',
    itmSize: '',
    bagWt: 0,
    pcs: 0,
    grossWt: 0,
    lessWt: 0,
    netWt: 0,
    ghtPct: 0,
    ghtWt: 0,
    touch: 0,
    westPct: 0,
    fine: 0,
    lbrPct: 0,
    lbrType: '',
    lbrRate: 0,
    lbrAmt: 0,
    othAmt: 0,
    rate: 0,
    amount: 0,
    mrp: 0,
    krOthWt: 0,
    krNetWt: 0,
    krGhtWt: 0,
    krTouch: 0,
    krWestPct: 0,
    krFine: 0,
    krName: '',
    rateType: '',
    itType: '',
    prCode: '',
    designImageId: '',
    trfrItCode: '',
  };
}

// ---- stones (K5) ---------------------------------------------------------------------------------

/** A tag's stone as tag entry loads it (TR_TAG_CAN.cs:4050-4060): numbered 1…n, with the stone grid's formats. */
export function stoneFromTag(stone: Record<string, unknown>, isrNo: number): TagCancelStoneRow {
  return {
    isrNo,
    itCode: dbText(stone.IT_CODE),
    itName: dbText(stone.IT_NAME),
    pcs: num(stone.IT_PCS),
    grossWt: f3(stone.IT_GWT),
    karigarWt: f3(stone.KR_WT),
    conPct: f3(stone.IT_CON_PRC),
    rateType: dbText(stone.IT_RATE_TYPE),
    rate: f2(stone.IT_RATE),
    amount: f2(stone.IT_AMT),
    lbrRate: f2(stone.IT_LBR_RATE),
    lbrAmount: f2(stone.IT_LBR_AMT),
    netAmount: f2(stone.IT_NET_AMT),
    conWt: f3(stone.IT_CON_WT),
    karigarConWt: f3(stone.KR_CON_WT),
    itType: dbText(stone.IT_TYPE),
  };
}

/** A saved stone as `DISPLAY_DATA` reloads it (TR_TAG_CAN.cs:4847-4870): its own ISR_NO. */
export function stoneFromSaved(stone: Record<string, unknown>): TagCancelStoneRow {
  return stoneFromTag(stone, num(stone.ISR_NO));
}

/**
 * Stones a caller supplies. Each runs the stone grid's arithmetic (`CommPassTotal_Idtl`, core `tagCancelStone`)
 * and every cell the caller gave is kept as given. Numbered by position, as the stone grid numbers its rows.
 */
export function stonesFromInput(
  stones: readonly TagCancelStoneInput[],
  items: ReadonlyMap<string, TagCancelItem>,
): TagCancelStoneRow[] {
  const filled = stones.filter((stone) => Object.values(stone ?? {}).some((value) => given(value)));
  return filled.map((stone, index) => {
    const itCode = typedText(stone.itCode, 5);
    const item = itCode ? items.get(itCode) : undefined;
    const cells: TagCancelStoneCells = {
      pcs: num(stone.pcs),
      grossWt: f3(stone.grossWt),
      karigarWt: f3(stone.karigarWt),
      conPct: f3(stone.conPct),
      rateType: typedText(stone.rateType, 1),
      rate: f2(stone.rate),
      amount: f2(stone.amount),
      lbrRate: f2(stone.lbrRate),
      lbrAmount: f2(stone.lbrAmount),
      netAmount: f2(stone.netAmount),
      conWt: f3(stone.conWt),
      karigarConWt: 0,
    };
    const computed = tagCancelStone(cells);
    return {
      isrNo: index + 1,
      itCode,
      itName: item?.itName ?? '',
      pcs: given(stone.pcs) ? num(stone.pcs) : computed.pcs,
      grossWt: given(stone.grossWt) ? f3(stone.grossWt) : computed.grossWt,
      karigarWt: given(stone.karigarWt) ? f3(stone.karigarWt) : computed.karigarWt,
      conPct: f3(stone.conPct),
      rateType: typedText(stone.rateType, 1),
      rate: f2(stone.rate),
      amount: given(stone.amount) ? f2(stone.amount) : computed.amount,
      lbrRate: f2(stone.lbrRate),
      lbrAmount: given(stone.lbrAmount) ? f2(stone.lbrAmount) : computed.lbrAmount,
      netAmount: given(stone.netAmount) ? f2(stone.netAmount) : computed.netAmount,
      conWt: given(stone.conWt) ? f3(stone.conWt) : computed.conWt,
      karigarConWt: computed.karigarConWt,
      itType: given(stone.itType) ? typedText(stone.itType, 1) : (item?.itType ?? ''),
    };
  });
}

/** The save's stone filter, TR_TAG_CAN.cs:5200: pieces + weight + net amount ≠ 0. */
export const stoneQualifies = (stone: TagCancelStoneRow): boolean =>
  num(stone.pcs) + num(stone.grossWt) + num(stone.netAmount) !== 0;

// ---- the operator's edits (K4) --------------------------------------------------------------------

/** Visible numeric cells, in the grid's column order, and the format `MSG_LeaveCell` gives each. */
const REPLAY: ReadonlyArray<{
  field: keyof TagCancelLineInput & keyof TagCancelRowCells;
  format: (value: unknown) => number;
  /** `MSG_LeaveCell` runs `CommPassTotal` after this column (Pcs, col 10, only stores its value). */
  recompute: boolean;
}> = [
  { field: 'bagWt', format: f3, recompute: true },
  { field: 'pcs', format: f0, recompute: false },
  { field: 'grossWt', format: f3, recompute: true },
  { field: 'lessWt', format: f3, recompute: true },
  { field: 'netWt', format: f3, recompute: true },
  { field: 'ghtWt', format: f3, recompute: true },
  { field: 'touch', format: f2, recompute: true },
  { field: 'westPct', format: f2, recompute: true },
  { field: 'fine', format: f3, recompute: true },
  { field: 'lbrRate', format: f2, recompute: true },
  { field: 'lbrAmt', format: f2, recompute: true },
  { field: 'othAmt', format: f2, recompute: true },
  { field: 'mrp', format: f2, recompute: true },
];

/** Hidden cells the grid computes; a caller that gives them has them stored as given. */
const HIDDEN: ReadonlyArray<{
  field: keyof TagCancelLineInput & keyof TagCancelRowCells;
  format: (value: unknown) => number;
}> = [
  { field: 'amount', format: f2 },
  { field: 'krNetWt', format: f3 },
  { field: 'krTouch', format: f2 },
  { field: 'krWestPct', format: f2 },
  { field: 'krFine', format: f3 },
];

/**
 * Input cells of the Tag Cancel grid that the Tag Transfer grid hides (MSG_CLEAR, TR_TAG_CAN.cs:2568-2600) and nothing
 * computes: they keep the tag's value, so a different one is refused.
 */
const TRANSFER_HIDDEN_INPUTS: ReadonlyArray<{
  field: 'ghtWt' | 'lbrRate' | 'mrp';
  label: string;
  format: (value: unknown) => number;
}> = [
  { field: 'ghtWt', label: 'GhtWt', format: f3 },
  { field: 'lbrRate', label: 'LbrRate', format: f2 },
  { field: 'mrp', label: 'Mrp', format: f2 },
];

/**
 * Cells the Tag Transfer grid hides but still computes — LbrAmt (col 25) by `CommPassTotal` from the tag's labour rate
 * whenever a weight changes, OthAmt (col 26) by `CommPassTotal_Idtl` from the stones, whose grid GrWt hands focus to in
 * both menus (:4265-4278). On that grid they are hidden computed cells like `amount`: never an edit, stored as given.
 */
const TRANSFER_COMPUTED = new Set<keyof TagCancelLineInput>(['lbrAmt', 'othAmt']);

type Cells = TagCancelRowCells;

function recompute(
  cells: Cells,
  baseline: TagCancelBaseline,
  tagged: boolean,
  settings: TagCancelSettings,
): { cells: Cells; baseline: TagCancelBaseline } {
  const out = tagCancelRecompute({ ...cells, tagged }, baseline, settings);
  const { tagged: _tagged, ...core } = out.cells;
  return { cells: { ...cells, ...core }, baseline: out.baseline };
}

function withStoneEffect(cells: Cells, stones: readonly TagCancelStoneRow[]): Cells {
  const effect = tagCancelStoneEffect(
    {
      grossWt: cells.grossWt,
      lessWt: cells.lessWt,
      netWt: cells.netWt,
      krOthWt: cells.krOthWt,
      krNetWt: cells.krNetWt,
      othAmt: cells.othAmt,
    },
    stones,
  );
  return { ...cells, ...effect };
}

/**
 * Apply a caller's line to the row it starts from (K3/K4).
 *
 * - On a tag line ItCode, Counter, Pcs and KrCode come from the tag (`MSG_EnterCell` makes cols 4/5/10/28
 *   read-only once col 1 is filled); a different value is refused rather than silently ignored.
 * - The Tag Transfer grid hides GhtWt, LbrRate, Mrp and KrCode, and the Tag Cancel grid has no TrfrItm; a value for
 *   such a column that differs from the row's own is refused. The Transfer grid also hides LbrAmt and OthAmt, which it
 *   still computes, so there they are hidden computed cells (never an edit, stored as given).
 * - The visible numeric cells are replayed in column order, each as `MSG_LeaveCell` would after an edit: the value
 *   is formatted, and a changed value recomputes the row (`CommPassTotal`). Edited stones act on the row after the
 *   gross weight, where the desktop's grid hands focus to the stone grid (:4265-4278).
 * - Every cell the caller gave is then stored as given, so the screen — which runs the same arithmetic on each
 *   cell commit, in the operator's own order — saves exactly the row it shows.
 */
export function applyLineInput(options: {
  mode: TagCancelMode;
  row: number;
  tagged: boolean;
  base: Cells;
  baseline: TagCancelBaseline;
  input: TagCancelLineInput;
  stones: readonly TagCancelStoneRow[];
  stonesGiven: boolean;
  settings: TagCancelSettings;
}): Cells {
  const { mode, row, tagged, base, input, settings } = options;
  const refuse = (message: string): never => {
    throw new TagCancelValidationError(`row ${row}: ${message}`);
  };
  if (tagged) {
    if (given(input.pcs) && f0(input.pcs) !== f0(base.pcs)) refuse('Pcs comes from the tag');
    if (given(input.tblCode) && typedText(input.tblCode, 3) !== typedText(base.tblCode, 3)) {
      refuse('Counter comes from the tag');
    }
    if (given(input.krName) && typedText(input.krName, 5) !== typedText(base.krName, 5)) {
      refuse('KrCode comes from the tag');
    }
  }
  if (mode === 'transfer') {
    for (const hidden of TRANSFER_HIDDEN_INPUTS) {
      const value = input[hidden.field];
      if (given(value) && hidden.format(value) !== hidden.format(base[hidden.field])) {
        refuse(`${hidden.label} is not a Tag Transfer column`);
      }
    }
    if (given(input.krName) && typedText(input.krName, 5) !== typedText(base.krName, 5)) {
      refuse('KrCode is not a Tag Transfer column');
    }
  } else if (given(input.trfrItCode)) {
    refuse('TrfrItm is a Tag Transfer column');
  }

  let cells: Cells = { ...base };
  const setText = (field: 'designNo' | 'itmSize' | 'tblCode' | 'krName', max: number) => {
    const value = input[field];
    if (value == null) return;
    const next = typedText(value, max);
    // A value copied from the tag is kept verbatim unless the operator actually changed it.
    if (next !== typedText(cells[field], max)) cells[field] = next;
  };
  setText('designNo', 20);
  setText('itmSize', 20);
  if (!tagged) {
    setText('tblCode', 3);
    setText('krName', 5);
  }

  let baseline = { ...options.baseline };
  for (const step of REPLAY) {
    const value = input[step.field];
    // A hidden computed cell of the Transfer grid is not an operator edit; its value is stored below.
    if (given(value) && !(mode === 'transfer' && TRANSFER_COMPUTED.has(step.field))) {
      const next = step.format(value);
      if (next !== num(cells[step.field])) {
        cells = { ...cells, [step.field]: next };
        if (step.recompute) ({ cells, baseline } = recompute(cells, baseline, tagged, settings));
      }
    }
    if (step.field === 'grossWt' && options.stonesGiven) {
      cells = withStoneEffect(cells, options.stones);
      ({ cells, baseline } = recompute(cells, baseline, tagged, settings));
    }
  }

  for (const step of [...REPLAY, ...HIDDEN]) {
    const value = input[step.field];
    if (given(value)) cells = { ...cells, [step.field]: step.format(value) };
  }
  return cells;
}

/** The baseline a row starts its replay from: the loaded row, or zeros for a brand-new loose row (K4). */
export const replayBaseline = (loaded: Cells | null): TagCancelBaseline =>
  baselineFromCells(loaded);

// ---- rows (K6-K8, K11) ---------------------------------------------------------------------------

/** BAR_CAN_DATA, TR_TAG_CAN.cs:5035-5063. `AC_CODE` is the hidden party box, blank on this form. */
export function headerRow(ctx: TagCancelWriteContext): Record<string, unknown> {
  return {
    ...ctx.key,
    AC_CODE: '',
    VCH_DATE: ctx.vchDate,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    EMP_CODE: ctx.empCode,
    VCH_DESC: ctx.vchDesc,
    VCH_TIME: ctx.vchTime,
    DATA_TRFR: 'N',
    MAIN_USER: ctx.mainUser,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  };
}

/** TEMP_BOOK_DATA, TR_TAG_CAN.cs:5018-5031: the hidden number under the configured book name. */
export function tempBookRow(ctx: TagCancelWriteContext): Record<string, unknown> {
  return {
    CO_CODE: ctx.key.CO_CODE,
    LC_CODE: ctx.key.LC_CODE,
    CO_BOOK: ctx.key.CO_BOOK,
    VCH_NO: ctx.hiddenVoucherNo,
    BOOK_NAME: ctx.book.name,
  };
}

/** BAR_CAN_DETL, TR_TAG_CAN.cs:5103-5160 — exactly the desktop's column set. */
export function detailRow(
  ctx: TagCancelWriteContext,
  line: TagCancelWriteLine,
): Record<string, unknown> {
  const c = line.cells;
  return {
    ...ctx.key,
    VCH_DATE: ctx.vchDate,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    AC_CODE: '',
    VCH_TYPE: ctx.book.shortName,
    INOUT_TYPE: ctx.book.inout,
    ENTRY_TYPE: 'T',
    BOOK_NAME: ctx.book.mainBook,
    SR_NO: line.srNo,
    OLD_SRNO: line.oldSrNo,
    IT_CODE: c.itCode,
    TAG_NO: isLoose(c.tagNo) ? 'N' : c.tagNo,
    TBL_CODE: c.tblCode,
    DESIGN_NO: c.designNo,
    LOT_NO: c.lotNo,
    ITM_LOT: c.itmLot,
    ITM_SIZE: c.itmSize,
    ITM_SIGN: '-',
    // Written only by the transfer mode (:5125-5128); a cancel leaves the column untouched.
    ...(ctx.mode === 'transfer' ? { TRFR_IT_CODE: c.trfrItCode } : {}),
    BAG_WT: c.bagWt,
    ITM_PCS: c.pcs,
    ITM_GWT: c.grossWt,
    ITM_OTH_WT: c.lessWt,
    ITM_NWT: c.netWt,
    ITM_GHT_WT: c.ghtWt,
    ITM_TOUCH: c.touch,
    ITM_WEST_PRC: c.westPct,
    ITM_FINE: c.fine,
    LBR_PRC: c.lbrPct,
    LBR_TYPE: c.lbrType,
    LBR_RATE: c.lbrRate,
    LBR_AMT: c.lbrAmt,
    OTH_AMT: c.othAmt,
    ITM_RATE: c.rate,
    ITM_AMT: c.amount,
    ITM_MRP: c.mrp,
    KR_NET_WT: c.krNetWt,
    KR_TOUCH: c.krTouch,
    KR_WEST_PRC: c.krWestPct,
    KR_FINE: c.krFine,
    KR_NAME: c.krName,
    RATE_TYPE: c.rateType,
    IT_TYPE: c.itType,
    PR_CODE: c.prCode,
    VCH_SRNO: isLoose(c.tagNo) ? 0 : c.vchSrno,
    VCH_TIME: ctx.vchTime,
    DATA_TRFR: 'N',
    MAIN_USER: ctx.mainUser,
    DESIGN_IMG_ID: c.designImageId,
  };
}

/** BAR_CAN_IDTL, TR_TAG_CAN.cs:5194-5243: one row per stone with pieces, weight or value. */
export function stoneRows(
  ctx: TagCancelWriteContext,
  line: TagCancelWriteLine,
): Record<string, unknown>[] {
  return line.stones.filter(stoneQualifies).map((stone) => ({
    ...ctx.key,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    VCH_DATE: ctx.vchDate,
    AC_CODE: '',
    VCH_TYPE: ctx.book.shortName,
    INOUT_TYPE: ctx.book.inout,
    ENTRY_TYPE: 'T',
    BOOK_NAME: ctx.book.mainBook,
    SR_NO: line.oldSrNo,
    TAG_NO: line.cells.tagNo,
    VCH_SRNO: line.cells.vchSrno,
    ISR_NO: stone.isrNo,
    IT_CODE: stone.itCode,
    IT_PCS: stone.pcs,
    IT_GWT: stone.grossWt,
    KR_WT: stone.karigarWt,
    IT_CON_PRC: stone.conPct,
    IT_RATE_TYPE: stone.rateType,
    IT_RATE: stone.rate,
    IT_AMT: stone.amount,
    IT_LBR_RATE: stone.lbrRate,
    IT_LBR_AMT: stone.lbrAmount,
    IT_NET_AMT: stone.netAmount,
    IT_CON_WT: stone.conWt,
    IT_TYPE: stone.itType,
    MAIN_USER: ctx.mainUser,
  }));
}

/**
 * MAIN_STOCK, `Ac_Stock.Tag_Can_Stk` (Ac_Stock.cs:48-58), built from the very register rows written, as the
 * desktop's `INSERT … SELECT FROM BAR_CAN_DETL` does.
 *
 *   insert 1, every line:      ISR_NO 1, TR_TYPE 'O', '-', the line's item, tag and figures, NET_AMT 0, KR_COST 0
 *   insert 2, transfer lines:  ISR_NO 2, TRFR_IT_CODE, TAG_NO 'N', VCH_SRNO 0, TBL_CODE '001', TR_TYPE 'I', '+',
 *                              the same pieces, weights, touch, wastage, fine and karigar figures; every rate and
 *                              amount 0; ITM_LOT ''
 */
export function stockRows(
  ctx: TagCancelWriteContext,
  details: readonly Record<string, unknown>[],
): Record<string, unknown>[] {
  const stockDate = ctx.vchDate.toISOString().slice(0, 10);
  const common = (d: Record<string, unknown>) => ({
    ...ctx.key,
    SR_NO: d.SR_NO,
    VCH_DATE: ctx.vchDate,
    STK_DATE: stockDate,
    VCH_TYPE: ctx.book.shortName,
    BOOK_NAME: ctx.book.mainBook,
    AC_CODE: '',
    ITM_QTY: 1,
    ITM_PCS: d.ITM_PCS,
    ITM_GWT: d.ITM_GWT,
    ITM_NWT: d.ITM_NWT,
    ITM_TOUCH: d.ITM_TOUCH,
    ITM_WEST: d.ITM_WEST_PRC,
    ITM_FINE: d.ITM_FINE,
    NET_AMT: 0,
    KR_NWT: d.KR_NET_WT,
    KR_TOUCH: d.KR_TOUCH,
    KR_WEST: d.KR_WEST_PRC,
    KR_FINE: d.KR_FINE,
    KR_LBR_AMT: 0,
    KR_OTH_AMT: 0,
    KR_COST: 0,
    EMP_CODE: '',
    ENTRY_TIME: ctx.vchTime,
    MAIN_USER: ctx.mainUser,
    DATA_TYPE: ctx.book.dataType,
    DESIGN_NO: d.DESIGN_NO,
    ITM_SIZE: d.ITM_SIZE,
    ITM_DESC: '',
    GHT_PRC: 0,
    ITM_DISC: '0',
  });
  const out: Record<string, unknown>[] = details.map((d) => ({
    ...common(d),
    ISR_NO: 1,
    IT_CODE: d.IT_CODE,
    TAG_NO: isLoose(d.TAG_NO) ? 'N' : d.TAG_NO,
    VCH_SRNO: d.VCH_SRNO,
    TBL_CODE: d.TBL_CODE,
    TR_TYPE: 'O',
    ITM_SIGN: '-',
    ITM_RATE: d.ITM_RATE,
    ITM_AMT: d.ITM_AMT,
    LBR_RATE: d.LBR_RATE,
    LBR_AMT: d.LBR_AMT,
    OTH_AMT: d.OTH_AMT,
    ITM_MRP: d.ITM_MRP,
    ITM_LOT: d.ITM_LOT,
  }));
  if (ctx.mode === 'transfer') {
    for (const d of details) {
      if (dbText(d.TRFR_IT_CODE).trim() === '') continue;
      out.push({
        ...common(d),
        ISR_NO: 2,
        IT_CODE: d.TRFR_IT_CODE,
        TAG_NO: 'N',
        VCH_SRNO: 0,
        TBL_CODE: '001',
        TR_TYPE: 'I',
        ITM_SIGN: '+',
        ITM_RATE: 0,
        ITM_AMT: 0,
        LBR_RATE: 0,
        LBR_AMT: 0,
        OTH_AMT: 0,
        ITM_MRP: 0,
        ITM_LOT: '',
      });
    }
  }
  return out;
}

/**
 * DM_DATA, `Ac_Stock.Dm_Tag_Cancel_Detl` (Ac_Stock.cs:824-828) — Tag Cancel only: one row per saved stone whose item
 * posts other detail (`OTH_DETL_POSTING = 'Y'`), joined to its line by `OLD_SRNO = SR_NO`. `BOOK_NAME` is the
 * book's SHORT name here. The desktop's `TBL_CODE` has no DM_DATA column in the web schema.
 */
export function diamondRows(
  ctx: TagCancelWriteContext,
  lines: readonly TagCancelWriteLine[],
  items: ReadonlyMap<string, TagCancelItem>,
): Record<string, unknown>[] {
  if (ctx.mode !== 'cancel') return [];
  const out: Record<string, unknown>[] = [];
  for (const line of lines) {
    for (const stone of line.stones.filter(stoneQualifies)) {
      if (!items.get(stone.itCode.trim().toUpperCase())?.postsDiamonds) continue;
      out.push({
        ...ctx.key,
        MAIN_SRNO: 1,
        SR_NO: line.oldSrNo,
        ISR_NO: stone.isrNo,
        VCH_DATE: ctx.vchDate,
        ENTRY_TYPE: 'S',
        BOOK_NAME: ctx.book.shortName,
        AC_CODE: '',
        IT_CODE: stone.itCode,
        DM_LOT_NO: '',
        DM_PCS: stone.pcs,
        DM_WT: stone.grossWt,
        DM_SIGN: '-',
        DM_RATE: stone.rate,
        DM_AMT: stone.amount,
        EMP_CODE: '',
        TAG_NO: line.cells.tagNo,
        VCH_SRNO: line.cells.vchSrno,
        MAIN_IT_CODE: line.cells.itCode,
        INOUT_TYPE: 'O',
      });
    }
  }
  return out;
}

/**
 * DELETE_DATA, `BtnDelete_Click` TR_TAG_CAN.cs:5339: one row per saved line. `BOOK_NAME` is the configured book name
 * (the desktop column is 20 wide), the fine column carries the NET weight and the description names item and tag.
 */
export function deleteAuditRows(
  book: TagCancelBookPolicy,
  saved: readonly Record<string, unknown>[],
  deleteUser: string,
  at: Date,
): Record<string, unknown>[] {
  return saved.map((row) => ({
    CO_CODE: row.CO_CODE,
    LC_CODE: row.LC_CODE,
    CO_YEAR: row.CO_YEAR,
    CO_BOOK: row.CO_BOOK,
    VCH_NO: row.VCH_NO,
    SR_NO: row.SR_NO,
    VCH_DATE: row.VCH_DATE,
    DELETE_DATE: at,
    VCH_TYPE: book.shortName,
    VCH_TIME: row.VCH_TIME,
    DELETE_TIME: at,
    BOOK_NAME: book.name.slice(0, 20),
    AC_CODE: row.AC_CODE,
    AC_NAME: '',
    VCH_VAL_DR: 0,
    VCH_VAL_CR: 0,
    FINE_TYPE: row.IT_TYPE,
    VCH_FINE_DR: 0,
    VCH_FINE_CR: num(row.ITM_NWT),
    HD_VCH_NO: row.HD_VCH_NO,
    MAIN_USER: row.MAIN_USER,
    DELETE_USER: deleteUser,
    VCH_DESC: `ItCode/${dbText(row.IT_CODE)} TagNo/${dbText(row.TAG_NO)}`.slice(0, 150),
  }));
}
