/**
 * TR_TAG_SPLIT row builders — the desktop column sets for the Tag Split write set, kept database-free so they can be
 * unit-tested. The writer (tagSplit.ts) resolves tags, allocates child numbers and drives a transaction; this module
 * turns resolved cells into the exact rows the desktop writes.
 *
 * Sources (unified/src/csharp/DataCareNext): TR_TAG_SPLIT.cs BtnSave_Click 9960-10770; Ac_Stock.cs Tag_Split_Stk
 * 403-413 and Dm_Tag_Split_Detl 841-847; Ac_Ledr.cs Tag_Split_Ledr 1951-1985; Ac_Rojmel.cs Tag_Split_Rojmel 929-941.
 * Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md (K3-K9, K11).
 */
import {
  tagSplitChild,
  tagSplitStone,
  tagSplitStoneEffect,
  type TagSplitChildCells,
  type TagSplitSettings,
  type TagSplitStoneCells,
} from '@datacare/core';

export const TAG_SPLIT_MAIN_BOOK = 'TAG SPLIT';

export class TagSplitValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TagSplitValidationError';
  }
}
export class TagSplitConflictError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TagSplitConflictError';
  }
}

// ---- numbers and text --------------------------------------------------------------------------------

export const num = (value: unknown): number => {
  const x = Number(String(value ?? '').trim() || 0);
  return Number.isFinite(x) ? x : 0;
};
const round = (value: number, dp: number): number => {
  const f = 10 ** dp;
  return Math.round((value + (value >= 0 ? 1 : -1) * 1e-9) * f) / f;
};
export const f3 = (value: unknown): number => round(num(value), 3);
export const f2 = (value: unknown): number => round(num(value), 2);
const f0 = (value: unknown): number => Math.round(num(value));
export const dbText = (value: unknown): string => (value == null ? '' : String(value));
/** The form upper-cases keys and swallows the apostrophe (KeyPreview), as N18. */
export const typedText = (value: unknown, max = 255): string =>
  dbText(value).replace(/'/g, '').toUpperCase().trim().slice(0, max);

const isLoose = (tagNo: unknown): boolean => {
  const t = typedText(tagNo, 15);
  return t === '' || t === 'N';
};

// ---- types -------------------------------------------------------------------------------------------

export interface TagSplitItem {
  itCode: string;
  itName: string;
  itType: string;
  prCode: string;
  tagType: string;
  rateType: string;
  postsDiamonds: boolean;
}

/** A parent line: which live tag to consume. */
export interface TagSplitParentInput {
  tagNo: string;
  vchSrno?: number;
  itCode?: string;
  oldSrNo?: number;
}

/** A child line the operator builds. */
export interface TagSplitChildInput {
  itCode?: string;
  oldSrNo?: number;
  tblCode?: string;
  designNo?: string;
  itmSize?: string;
  sign?: string;
  bagWt?: number;
  pcs?: number;
  grossWt?: number;
  lessWt?: number;
  netWt?: number;
  ghtPct?: number;
  ghtWt?: number;
  touch?: number;
  westPct?: number;
  fine?: number;
  lbrType?: string;
  lbrRate?: number;
  lbrAmt?: number;
  othAmt?: number;
  rate?: number;
  amount?: number;
  mrp?: number;
  margin?: number;
  krName?: string;
  krOthWt?: number;
  krNetWt?: number;
  krTouch?: number;
  krWestPct?: number;
  krFine?: number;
  krLbrRate?: number;
  krLbrAmt?: number;
  krOthAmt?: number;
  stones?: TagSplitStoneInput[];
}

export interface TagSplitStoneInput {
  itCode?: string;
  pcs?: number;
  pcsWt?: number;
  grossWt?: number;
  karigarWt?: number;
  conPct?: number;
  rateType?: string;
  rate?: number;
  amount?: number;
  lbrRate?: number;
  lbrAmount?: number;
  netAmount?: number;
  itType?: string;
}

/** A parent's cells, filled from its BAR_DETL row (stored verbatim, K3). */
export interface TagSplitParentCells {
  tagNo: string;
  vchSrno: number;
  itCode: string;
  tblCode: string;
  designNo: string;
  itmColor: string;
  itmSize: string;
  hmId: string;
  bagWt: number;
  pcs: number;
  grossWt: number;
  lessWt: number;
  netWt: number;
  krOthWt: number;
  krNetWt: number;
  krGhtWt: number;
  krTouch: number;
  krWestPct: number;
  krFine: number;
  ghtPct: number;
  ghtWt: number;
  touch: number;
  westPct: number;
  fine: number;
  lbrCode: string;
  lbrPct: number;
  lbrType: string;
  lbrRate: number;
  lbrAmt: number;
  othAmt: number;
  krLbrRate: number;
  krLbrAmt: number;
  krOthAmt: number;
  rate: number;
  amount: number;
  krCost: number;
  tagCost: number;
  margin: number;
  mrp: number;
  krName: string;
  rateType: string;
  itType: string;
  tagType: string;
  prCode: string;
  dataType: string;
  designImageId: string;
}

/** A child's resolved cells (the desktop MSG_PR columns after CommPassTotal_Pr). */
export interface TagSplitChildResolved extends TagSplitChildCells {
  itCode: string;
  itName: string;
  tagNo: string;
  vchSrno: number;
  tagSrno: number;
  tblCode: string;
  designNo: string;
  itmSize: string;
  sign: string;
  bagWt: number;
  krName: string;
  rateType: string;
  itType: string;
  tagType: string;
  prCode: string;
  dataType: string;
}

export interface TagSplitStoneRow {
  isrNo: number;
  itCode: string;
  itName: string;
  itType: string;
  pcs: number;
  pcsWt: number;
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
}

export interface TagSplitBookPolicy {
  name: string;
  shortName: string;
  mainBook: string;
  inout: string;
  dataType: string;
  /** BOOK_DETL account slots 5-9 (labour, gold/silver DR/CR fine). */
  slots: Record<number, string>;
}

export interface TagSplitWriteContext {
  key: { CO_CODE: string; LC_CODE: string; CO_YEAR: string; CO_BOOK: string; VCH_NO: string };
  book: TagSplitBookPolicy;
  hiddenVoucherNo: string;
  vchDate: Date;
  vchTime: Date;
  mainUser: string;
  empCode: string;
  vchDesc: string;
  acCode: string;
  itType: string;
  balance: { drWt: number; crWt: number; drFine: number; crFine: number; crLbr: number };
}

export interface TagSplitWriteParent {
  cells: TagSplitParentCells;
  srNo: number;
  oldSrNo: number;
  stones: TagSplitStoneRow[];
}
export interface TagSplitWriteChild {
  cells: TagSplitChildResolved;
  srNo: number;
  oldSrNo: number;
  stones: TagSplitStoneRow[];
}

// ---- parent fill (K3) --------------------------------------------------------------------------------

/** A parent line's cells, from its first BAR_DETL row. */
export function parentCellsFromBarDetl(source: Record<string, unknown>): TagSplitParentCells {
  const touch = f2(source.ITM_TOUCH);
  const noTouch = touch === 0;
  return {
    tagNo: typedText(source.TAG_NO, 15),
    vchSrno: num(source.VCH_SRNO),
    itCode: dbText(source.IT_CODE),
    tblCode: dbText(source.TBL_CODE),
    designNo: dbText(source.DESIGN_NO),
    itmColor: dbText(source.ITM_COLOR),
    itmSize: dbText(source.ITM_SIZE),
    hmId: dbText(source.HM_ID),
    bagWt: f3(source.BAG_WT),
    pcs: num(source.ITM_PCS),
    grossWt: f3(source.ITM_GWT),
    lessWt: f3(source.ITM_OTH_WT),
    netWt: f3(source.ITM_NWT),
    krOthWt: f3(source.KR_OTH_WT),
    // Two-place karigar net, as the desktop tag fill formats it.
    krNetWt: f2(source.KR_NET_WT),
    krGhtWt: f3(source.KR_GHT_WT),
    krTouch: f2(source.KR_TOUCH),
    krWestPct: f2(source.KR_WEST_PRC),
    krFine: f3(source.KR_FINE),
    ghtPct: f2(source.ITM_GHT_PRC),
    ghtWt: f3(source.ITM_GHT_WT),
    // When the tag has no touch, take the karigar touch/wastage/fine (N18 K3 parity).
    touch: noTouch ? f2(source.KR_TOUCH) : touch,
    westPct: noTouch ? f2(source.KR_WEST_PRC) : f2(source.ITM_WEST_PRC),
    fine: noTouch ? f3(source.KR_FINE) : f3(source.ITM_FINE),
    lbrCode: dbText(source.LBR_CODE),
    lbrPct: f2(source.LBR_PRC),
    lbrType: dbText(source.LBR_TYPE) || 'G',
    lbrRate: f2(source.LBR_RATE),
    lbrAmt: f2(source.LBR_AMT),
    othAmt: f2(source.OTH_AMT),
    krLbrRate: f2(source.KR_LBR_RATE),
    krLbrAmt: f2(source.KR_LBR_AMT),
    krOthAmt: f2(source.KR_OTH_AMT),
    rate: f2(source.ITM_RATE),
    amount: f2(source.ITM_AMT),
    krCost: f2(source.KR_COST),
    tagCost: f2(source.TAG_COST),
    margin: f2(source.ITM_MARGIN),
    mrp: f2(source.ITM_MRP),
    krName: dbText(source.KR_NAME),
    rateType: dbText(source.RATE_TYPE),
    itType: dbText(source.IT_TYPE),
    tagType: dbText(source.TAG_TYPE),
    prCode: dbText(source.PR_CODE),
    dataType: dbText(source.DATA_TYPE).trim() || 'A',
    designImageId: dbText(source.DESIGN_IMG_ID),
  };
}

/** A stone from a tag's BAR_IDTL row (parent stones, K6). */
export function stoneFromTag(stone: Record<string, unknown>, isrNo: number): TagSplitStoneRow {
  return {
    isrNo,
    itCode: dbText(stone.IT_CODE),
    itName: dbText(stone.IT_NAME),
    itType: dbText(stone.IT_TYPE),
    pcs: num(stone.IT_PCS),
    pcsWt: f3(stone.IT_PCS_WT),
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
  };
}

/** A saved stone reopened from BAR_IDTL / LBR_*_IDTL. */
export function stoneFromSaved(stone: Record<string, unknown>): TagSplitStoneRow {
  return stoneFromTag(stone, num(stone.ISR_NO) || 1);
}

const given = (value: unknown): boolean =>
  value !== undefined && value !== null && !(typeof value === 'string' && value.trim() === '');

/** The operator's child stones, each run through the stone arithmetic. */
export function stonesFromInput(
  stones: readonly TagSplitStoneInput[],
  items: ReadonlyMap<string, TagSplitItem>,
): TagSplitStoneRow[] {
  const filled = stones.filter((stone) => Object.values(stone ?? {}).some((v) => given(v)));
  return filled.map((stone, index) => {
    const itCode = typedText(stone.itCode, 5);
    const item = itCode ? items.get(itCode) : undefined;
    const cells: TagSplitStoneCells = {
      pcs: num(stone.pcs),
      pcsWt: f3(stone.pcsWt),
      karigarWt: f3(stone.karigarWt),
      karigarActPct: 0,
      weight: f3(stone.grossWt),
      karigarLessPct: 0,
      conPct: f3(stone.conPct),
      rateType: typedText(stone.rateType, 1),
      rate: f2(stone.rate),
      amount: f2(stone.amount),
      karigarRate: 0,
      karigarAmount: 0,
      lbrRate: f2(stone.lbrRate),
      lbrAmount: f2(stone.lbrAmount),
      netAmount: f2(stone.netAmount),
      conWt: 0,
      karigarConWt: 0,
    };
    const computed = tagSplitStone(cells);
    return {
      isrNo: index + 1,
      itCode,
      itName: item?.itName ?? '',
      itType: item?.itType ?? typedText(stone.itType, 1),
      pcs: given(stone.pcs) ? num(stone.pcs) : computed.pcs,
      pcsWt: f3(stone.pcsWt),
      grossWt: given(stone.grossWt) ? f3(stone.grossWt) : computed.weight,
      karigarWt: computed.karigarWt,
      conPct: f3(stone.conPct),
      rateType: typedText(stone.rateType, 1),
      rate: f2(stone.rate),
      amount: given(stone.amount) ? f2(stone.amount) : computed.amount,
      lbrRate: f2(stone.lbrRate),
      lbrAmount: given(stone.lbrAmount) ? f2(stone.lbrAmount) : computed.lbrAmount,
      netAmount: given(stone.netAmount) ? f2(stone.netAmount) : computed.netAmount,
      conWt: computed.conWt,
      karigarConWt: computed.karigarConWt,
    };
  });
}

/** The save's stone filter (:10361): pieces + weight + net amount != 0. */
export const stoneQualifies = (stone: TagSplitStoneRow): boolean =>
  num(stone.pcs) + num(stone.grossWt) + num(stone.netAmount) !== 0;

// ---- child resolution (K4/K5) ------------------------------------------------------------------------

const NO_ITEM: TagSplitItem = {
  itCode: '',
  itName: '',
  itType: '',
  prCode: '',
  tagType: '',
  rateType: '',
  postsDiamonds: false,
};

/**
 * Resolve one child line: its typed cells run through `CommPassTotal_Pr`, edited stones applied after, and its
 * allocated identity (TAG_NO / VCH_SRNO / TAG_SRNO) stamped on. The identity is decided by the writer (K4); this
 * function is pure arithmetic.
 */
export function resolveChild(options: {
  input: TagSplitChildInput;
  item: TagSplitItem;
  identity: { tagNo: string; vchSrno: number; tagSrno: number };
  companyLabourType: string;
  stones: TagSplitStoneRow[];
  settings: TagSplitSettings;
}): TagSplitChildResolved {
  const { input, item, identity, stones, settings } = options;
  let cells: TagSplitChildCells = {
    pcs: given(input.pcs) ? num(input.pcs) : 1,
    grossWt: f3(input.grossWt),
    lessWt: f3(input.lessWt),
    netWt: f3(input.netWt),
    ghtPct: f2(input.ghtPct),
    ghtWt: f3(input.ghtWt),
    touch: f2(input.touch),
    westPct: f2(input.westPct),
    fine: f3(input.fine),
    krOthWt: f3(input.krOthWt),
    krNetWt: f3(input.krNetWt),
    krGhtWt: 0,
    krTouch: f2(input.krTouch),
    krWestPct: f2(input.krWestPct),
    krFine: f3(input.krFine),
    lbrType: typedText(input.lbrType, 1) || options.companyLabourType,
    lbrRate: f2(input.lbrRate),
    lbrAmt: f2(input.lbrAmt),
    othAmt: f2(input.othAmt),
    krLbrRate: f2(input.krLbrRate),
    krLbrAmt: f2(input.krLbrAmt),
    krOthAmt: f2(input.krOthAmt),
    rateType: item.rateType || typedText(input.rate != null ? '' : '', 1),
    rate: f2(input.rate),
    amount: f2(input.amount),
    krCost: 0,
    tagCost: 0,
    margin: f2(input.margin),
    mrp: f2(input.mrp),
  };
  cells = tagSplitChild(cells, settings);
  if (stones.length) {
    const effect = tagSplitStoneEffect(
      {
        grossWt: cells.grossWt,
        lessWt: cells.lessWt,
        netWt: cells.netWt,
        krOthWt: cells.krOthWt,
        krNetWt: cells.krNetWt,
        othAmt: cells.othAmt,
        krOthAmt: cells.krOthAmt,
      },
      stones.map((s) => ({
        conWt: s.conWt,
        karigarConWt: s.karigarConWt,
        netAmount: s.netAmount,
        karigarAmount: 0,
      })),
    );
    cells = tagSplitChild({ ...cells, ...effect }, settings);
  }
  // Cells the caller states explicitly (a hidden computed value the screen shows) are stored as given.
  const store = cells as unknown as Record<string, number>;
  for (const [field, value, money] of [
    ['fine', input.fine, false],
    ['amount', input.amount, true],
    ['lbrAmt', input.lbrAmt, true],
    ['mrp', input.mrp, true],
    ['krFine', input.krFine, false],
  ] as const) {
    if (given(value)) store[field] = money ? f2(value) : f3(value);
  }
  return {
    ...cells,
    itCode: item.itCode,
    itName: item.itName,
    tagNo: identity.tagNo,
    vchSrno: identity.vchSrno,
    tagSrno: identity.tagSrno,
    tblCode: typedText(input.tblCode, 3),
    designNo: typedText(input.designNo, 20),
    itmSize: typedText(input.itmSize, 20),
    sign: typedText(input.sign, 1) || '+',
    bagWt: f3(input.bagWt),
    krName: typedText(input.krName, 5),
    rateType: item.rateType,
    itType: item.itType,
    tagType: item.tagType,
    prCode: item.prCode,
    dataType: 'A',
  };
}

export { NO_ITEM };

// ---- desktop rows (K8) -------------------------------------------------------------------------------

/** LBR_DATA header, TR_TAG_SPLIT.cs:10094-10158. */
export function headerRow(ctx: TagSplitWriteContext): Record<string, unknown> {
  return {
    ...ctx.key,
    VCH_DATE: ctx.vchDate,
    AC_CODE: ctx.acCode,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    VCH_TYPE: ctx.book.shortName,
    INOUT_TYPE: ctx.book.inout,
    ENTRY_TYPE: 'C',
    BOOK_NAME: ctx.book.mainBook,
    CR_WT: ctx.balance.crWt,
    DR_WT: ctx.balance.drWt,
    CR_FINE: ctx.balance.crFine,
    DR_FINE: ctx.balance.drFine,
    CR_LBR: ctx.balance.crLbr,
    DR_LBR: 0,
    CR_RATE: 0,
    DR_RATE: 0,
    DR_AMT: 0,
    CR_AMT: 0,
    IT_TYPE: ctx.itType,
    EMP_CODE: ctx.empCode,
    VCH_DESC: ctx.vchDesc,
    VCH_TIME: ctx.vchTime,
    DATA_TRFR: 'N',
    MAIN_USER: ctx.mainUser,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  };
}

/** TEMP_BOOK_DATA, TR_TAG_SPLIT.cs:10145. */
export function tempBookRow(ctx: TagSplitWriteContext): Record<string, unknown> {
  return {
    CO_CODE: ctx.key.CO_CODE,
    LC_CODE: ctx.key.LC_CODE,
    CO_BOOK: ctx.key.CO_BOOK,
    VCH_NO: ctx.hiddenVoucherNo,
    BOOK_NAME: ctx.book.name,
  };
}

/** LBR_ISU_DETL — one row per parent (ENTRY_TYPE 'O'), TR_TAG_SPLIT.cs:10164-10254. */
export function parentDetailRow(
  ctx: TagSplitWriteContext,
  line: TagSplitWriteParent,
): Record<string, unknown> {
  const c = line.cells;
  return {
    ...ctx.key,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    VCH_DATE: ctx.vchDate,
    VCH_TYPE: ctx.book.shortName,
    INOUT_TYPE: ctx.book.inout,
    ENTRY_TYPE: 'O',
    BOOK_NAME: ctx.book.mainBook,
    SR_NO: line.srNo,
    OLD_SRNO: line.oldSrNo,
    IT_CODE: c.itCode,
    TAG_NO: c.tagNo,
    TBL_CODE: c.tblCode,
    DESIGN_NO: c.designNo,
    ITM_SIZE: c.itmSize,
    BAG_WT: c.bagWt,
    ITM_PCS: c.pcs,
    ITM_GWT: c.grossWt,
    ITM_OTH_WT: c.lessWt,
    ITM_NWT: c.netWt,
    KR_OTH_WT: c.krOthWt,
    KR_NET_WT: c.krNetWt,
    KR_GHT_WT: c.krGhtWt,
    KR_TOUCH: c.krTouch,
    KR_WEST_PRC: c.krWestPct,
    KR_FINE: c.krFine,
    ITM_GHT_PRC: c.ghtPct,
    ITM_GHT_WT: c.ghtWt,
    ITM_TOUCH: c.touch,
    ITM_WEST_PRC: c.westPct,
    ITM_FINE: c.fine,
    LBR_CODE: c.lbrCode,
    LBR_PRC: c.lbrPct,
    LBR_TYPE: c.lbrType,
    LBR_RATE: c.lbrRate,
    LBR_AMT: c.lbrAmt,
    OTH_AMT: c.othAmt,
    KR_LBR_RATE: c.krLbrRate,
    KR_LBR_AMT: c.krLbrAmt,
    KR_OTH_AMT: c.krOthAmt,
    ITM_RATE: c.rate,
    ITM_AMT: c.amount,
    KR_COST: c.krCost,
    TAG_COST: c.tagCost,
    ITM_MARGIN: c.margin,
    ITM_MRP: c.mrp,
    KR_NAME: c.krName,
    RATE_TYPE: c.rateType,
    IT_TYPE: c.itType,
    PR_CODE: c.prCode,
    VCH_SRNO: c.vchSrno,
    APR_ISU: 'N',
    VCH_TIME: ctx.vchTime,
    DATA_TRFR: 'N',
    DATA_TYPE: c.dataType,
    DESIGN_IMG_ID: c.designImageId,
    MAIN_USER: ctx.mainUser,
  };
}

const stoneRow = (
  ctx: TagSplitWriteContext,
  table: 'ISU' | 'REC',
  srNo: number,
  tagNo: string,
  vchSrno: number,
  stone: TagSplitStoneRow,
): Record<string, unknown> => ({
  ...ctx.key,
  // LBR_ISU_IDTL carries the hidden voucher number; BAR_IDTL (the child tag's stone rows) has no such column.
  ...(table === 'ISU' ? { HD_VCH_NO: ctx.hiddenVoucherNo } : {}),
  VCH_DATE: ctx.vchDate,
  AC_CODE: ctx.acCode,
  VCH_TYPE: ctx.book.shortName,
  INOUT_TYPE: ctx.book.inout,
  ENTRY_TYPE: 'S',
  BOOK_NAME: ctx.book.mainBook,
  SR_NO: srNo,
  TAG_NO: tagNo,
  VCH_SRNO: vchSrno,
  ISR_NO: stone.isrNo,
  IT_CODE: stone.itCode,
  IT_PCS: stone.pcs,
  IT_PCS_WT: stone.pcsWt,
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
  KR_CON_WT: stone.karigarConWt,
  IT_TYPE: stone.itType,
  MAIN_USER: ctx.mainUser,
});

/** LBR_ISU_IDTL — parent stones (keyed by the parent line's SR_NO). */
export function parentStoneRows(
  ctx: TagSplitWriteContext,
  line: TagSplitWriteParent,
): Record<string, unknown>[] {
  return line.stones
    .filter(stoneQualifies)
    .map((stone) => stoneRow(ctx, 'ISU', line.srNo, line.cells.tagNo, line.cells.vchSrno, stone));
}

/** LBR_REC_DETL — one row per child (ENTRY_TYPE 'O'), TR_TAG_SPLIT.cs:10336-10444. */
export function childReceiveRow(
  ctx: TagSplitWriteContext,
  line: TagSplitWriteChild,
): Record<string, unknown> {
  const c = line.cells;
  return {
    ...ctx.key,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    VCH_DATE: ctx.vchDate,
    VCH_TYPE: ctx.book.shortName,
    INOUT_TYPE: ctx.book.inout,
    ENTRY_TYPE: 'O',
    BOOK_NAME: ctx.book.mainBook,
    SR_NO: line.srNo,
    OLD_SRNO: line.oldSrNo,
    IT_CODE: c.itCode,
    TAG_NO: isLoose(c.tagNo) ? 'N' : c.tagNo,
    TBL_CODE: c.tblCode,
    DESIGN_NO: c.designNo,
    ITM_SIZE: c.itmSize,
    ITM_SIGN: c.sign,
    BAG_WT: c.bagWt,
    ITM_PCS: c.pcs,
    ITM_GWT: c.grossWt,
    ITM_OTH_WT: c.lessWt,
    ITM_NWT: c.netWt,
    KR_OTH_WT: c.krOthWt,
    KR_NET_WT: c.krNetWt,
    KR_GHT_WT: c.krGhtWt,
    KR_TOUCH: c.krTouch,
    KR_WEST_PRC: c.krWestPct,
    KR_FINE: c.krFine,
    ITM_GHT_PRC: c.ghtPct,
    ITM_GHT_WT: c.ghtWt,
    ITM_TOUCH: c.touch,
    ITM_WEST_PRC: c.westPct,
    ITM_FINE: c.fine,
    LBR_TYPE: c.lbrType,
    LBR_RATE: c.lbrRate,
    LBR_AMT: c.lbrAmt,
    OTH_AMT: c.othAmt,
    KR_LBR_RATE: c.krLbrRate,
    KR_LBR_AMT: c.krLbrAmt,
    KR_OTH_AMT: c.krOthAmt,
    ITM_RATE: c.rate,
    ITM_AMT: c.amount,
    KR_COST: c.krCost,
    TAG_COST: c.tagCost,
    ITM_MARGIN: c.margin,
    ITM_MRP: c.mrp,
    KR_NAME: c.krName,
    TAG_SRNO: c.tagSrno,
    RATE_TYPE: c.rateType,
    IT_TYPE: c.itType,
    TAG_TYPE: c.tagType,
    PR_CODE: c.prCode,
    VCH_SRNO: c.vchSrno,
    VCH_TIME: ctx.vchTime,
    DATA_TRFR: 'N',
    APR_ISU: 'N',
    DATA_TYPE: c.dataType || 'A',
    EMP_ISU: 'N',
    MAIN_USER: ctx.mainUser,
  };
}

/** BAR_DETL — the child tag record (ENTRY_TYPE 'I'), a real sellable tag. */
export function childBarDetlRow(
  ctx: TagSplitWriteContext,
  line: TagSplitWriteChild,
): Record<string, unknown> {
  // BAR_DETL shares LBR_REC_DETL's column set except for ITM_SIGN, which is a MAIN_STOCK movement concept — a
  // tag record itself carries no sign — so it is dropped here.
  const { ITM_SIGN: _sign, ...bar } = childReceiveRow(ctx, line);
  return {
    ...bar,
    ENTRY_TYPE: 'I',
  };
}

/** BAR_IDTL — child stones (ENTRY_TYPE 'S'). */
export function childStoneRows(
  ctx: TagSplitWriteContext,
  line: TagSplitWriteChild,
): Record<string, unknown>[] {
  return line.stones
    .filter(stoneQualifies)
    .map((stone) => stoneRow(ctx, 'REC', line.srNo, line.cells.tagNo, line.cells.vchSrno, stone));
}

/** BAR_DATA (one row). */
export function barDataRow(ctx: TagSplitWriteContext): Record<string, unknown> {
  return {
    ...ctx.key,
    VCH_DATE: ctx.vchDate,
    VCH_TIME: ctx.vchTime,
    AC_CODE: ctx.acCode,
    EMP_CODE: ctx.empCode,
    VCH_DESC: ctx.vchDesc,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    MAIN_USER: ctx.mainUser,
    DATA_TRFR: 'N',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  };
}

/**
 * MAIN_STOCK via Ac_Stock.Tag_Split_Stk (Ac_Stock.cs:409/411), built from the parent (insert 1) and child (insert 2)
 * detail rows, as the desktop's INSERT … SELECT does.
 */
export function stockRows(
  ctx: TagSplitWriteContext,
  parents: readonly TagSplitWriteParent[],
  children: readonly TagSplitWriteChild[],
): Record<string, unknown>[] {
  const stockDate = ctx.vchDate.toISOString().slice(0, 10);
  const common = (srNo: number, isrNo: number) => ({
    ...ctx.key,
    SR_NO: srNo,
    ISR_NO: isrNo,
    VCH_DATE: ctx.vchDate,
    STK_DATE: stockDate,
    VCH_TYPE: ctx.book.shortName,
    BOOK_NAME: ctx.book.mainBook,
    AC_CODE: ctx.acCode,
    ITM_QTY: 1,
    ENTRY_TIME: ctx.vchTime,
    MAIN_USER: ctx.mainUser,
    ITM_DESC: '',
    ITM_LOT: '',
    ITM_DISC: '0',
  });
  const out: Record<string, unknown>[] = [];
  // insert 1: every parent, SR_NO 1, ISR_NO = the line's SR_NO, TR_TYPE 'O', '-'.
  for (const p of parents) {
    const c = p.cells;
    out.push({
      ...common(1, p.srNo),
      IT_CODE: c.itCode,
      TAG_NO: isLoose(c.tagNo) ? 'N' : c.tagNo,
      VCH_SRNO: c.vchSrno,
      TBL_CODE: c.tblCode,
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      ITM_PCS: c.pcs,
      ITM_GWT: c.grossWt,
      ITM_NWT: c.netWt,
      ITM_TOUCH: c.touch,
      ITM_WEST: 0,
      ITM_FINE: c.fine,
      ITM_RATE: c.rate,
      ITM_AMT: c.amount,
      LBR_RATE: c.lbrRate,
      LBR_AMT: c.lbrAmt,
      OTH_AMT: c.othAmt,
      ITM_MRP: 0,
      NET_AMT: c.amount,
      KR_NWT: c.krNetWt,
      KR_TOUCH: c.krTouch,
      KR_WEST: c.krWestPct,
      KR_FINE: c.krFine,
      KR_LBR_AMT: 0,
      KR_OTH_AMT: 0,
      KR_COST: 0,
      EMP_CODE: '',
      DATA_TYPE: ctx.book.dataType,
      DESIGN_NO: c.designNo,
      ITM_SIZE: c.itmSize,
      GHT_PRC: 0,
    });
  }
  // insert 2: every child, SR_NO 2, ISR_NO = the line's SR_NO, TR_TYPE 'I' when '+' else 'O'.
  for (const ch of children) {
    const c = ch.cells;
    out.push({
      ...common(2, ch.srNo),
      IT_CODE: c.itCode,
      TAG_NO: isLoose(c.tagNo) ? 'N' : c.tagNo,
      VCH_SRNO: c.vchSrno,
      TBL_CODE: c.tblCode,
      TR_TYPE: c.sign === '+' ? 'I' : 'O',
      ITM_SIGN: c.sign,
      ITM_PCS: c.pcs,
      ITM_GWT: c.grossWt,
      ITM_NWT: c.netWt,
      ITM_TOUCH: c.touch,
      ITM_WEST: c.westPct,
      ITM_FINE: c.fine,
      ITM_RATE: c.rate,
      ITM_AMT: c.amount,
      LBR_RATE: c.lbrRate,
      LBR_AMT: c.lbrAmt,
      OTH_AMT: c.othAmt,
      ITM_MRP: c.mrp,
      NET_AMT: 0,
      KR_NWT: c.krNetWt,
      KR_TOUCH: c.krTouch,
      KR_WEST: c.krWestPct,
      KR_FINE: c.krFine,
      KR_LBR_AMT: c.krLbrAmt,
      KR_OTH_AMT: c.krOthAmt,
      KR_COST: c.krCost,
      EMP_CODE: '',
      DATA_TYPE: c.dataType || 'A',
      DESIGN_NO: c.designNo,
      ITM_SIZE: c.itmSize,
      GHT_PRC: c.ghtPct,
    });
  }
  return out;
}

/**
 * AC_DATA via Ac_Ledr.Tag_Split_Ledr (Ac_Ledr.cs:1953-1982): the labour and fine absorption legs. Only when the
 * header carries an absorbing account and a non-zero labour or fine difference. `TRAD_FINE` gates the even mirror
 * legs. `LEDR_KEY` = keys + a two-digit leg number + 'NN' suffix (the desktop appends 'NN').
 */
export function ledgerRows(
  ctx: TagSplitWriteContext,
  tradeFine: boolean,
): Record<string, unknown>[] {
  const rows: Record<string, unknown>[] = [];
  const key = `${ctx.key.CO_CODE}${ctx.key.LC_CODE}${ctx.key.CO_YEAR}${ctx.key.CO_BOOK}${ctx.key.VCH_NO}`;
  const base = {
    ...ctx.key,
    VCH_TYPE: ctx.book.shortName,
    VCH_DATE: ctx.vchDate,
    BOOK_NAME: ctx.book.mainBook,
    CHQ_NO: '',
    IT_DESC: '',
    ENTRY_TIME: ctx.vchTime,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    DATA_TRFR: 'N',
    MAIN_USER: ctx.mainUser,
    FINE_RATE: 0,
    LDR_NAME: '',
  };
  const leg = (
    n: string,
    ac: string,
    ld: string,
    crAmt: number,
    drAmt: number,
    itType: string,
    sign: string,
    fineWt: number,
    partyAc: string,
  ) =>
    rows.push({
      ...base,
      LEDR_KEY: `${key}${n}NN`,
      AC_CODE: ac,
      LD_CODE: ld,
      CR_AMT: crAmt,
      DR_AMT: drAmt,
      IT_TYPE: itType,
      SIGN: sign,
      FINE_WT: fineWt,
      PARTY_AC_CODE: partyAc,
    });
  const ac = ctx.acCode;
  const slot = (n: number) => ctx.book.slots[n] ?? '';
  const it = ctx.itType || 'G';
  // Legs 01/02: labour (party <-> slot 5).
  if (ctx.balance.crLbr !== 0 && ac) {
    leg('01', ac, slot(5), ctx.balance.crLbr, 0, 'A', '', 0, ac);
    leg('02', slot(5), ac, 0, ctx.balance.crLbr, 'A', '', 0, '');
  }
  // Legs 03/04 (gold DR fine, slot 6) or 05/06 (silver DR fine, slot 8).
  if (ctx.balance.drFine !== 0 && ac) {
    if (it === 'G') {
      leg('03', ac, slot(6), 0, 0, it, '-', ctx.balance.drFine, ac);
      if (tradeFine) leg('04', slot(6), ac, 0, 0, it, '+', ctx.balance.drFine, '');
    } else if (it === 'S') {
      leg('05', ac, slot(8), 0, 0, it, '-', ctx.balance.drFine, ac);
      if (tradeFine) leg('06', slot(8), ac, 0, 0, it, '+', ctx.balance.drFine, '');
    }
  }
  // Legs 07/08 (gold CR fine, slot 7) or 09/10 (silver CR fine, slot 9).
  if (ctx.balance.crFine !== 0 && ac) {
    if (it === 'G') {
      leg('07', ac, slot(7), 0, 0, it, '+', ctx.balance.crFine, ac);
      if (tradeFine) leg('08', slot(7), ac, 0, 0, it, '-', ctx.balance.crFine, '');
    } else if (it === 'S') {
      leg('09', ac, slot(9), 0, 0, it, '+', ctx.balance.crFine, ac);
      if (tradeFine) leg('10', slot(9), ac, 0, 0, it, '-', ctx.balance.crFine, '');
    }
  }
  return rows;
}

/**
 * ROJ_MEL_DATA via Ac_Rojmel.Tag_Split_Rojmel (Ac_Rojmel.cs:929-941): the day-book legs. Only for a gold or silver
 * fine difference and the labour, when the account is present.
 */
export function rojmelRows(
  ctx: TagSplitWriteContext,
  partyName: string,
  labourAcName: string,
): Record<string, unknown>[] {
  const rows: Record<string, unknown>[] = [];
  const key = `${ctx.key.CO_CODE}${ctx.key.LC_CODE}${ctx.key.CO_YEAR}${ctx.key.CO_BOOK}${ctx.key.VCH_NO}`;
  const base = {
    ...ctx.key,
    VCH_DATE: ctx.vchDate,
    VCH_TYPE: ctx.book.shortName,
    BOOK_NAME: ctx.book.mainBook,
    ITM_PCS: 0,
    ITM_RATE: 0,
    ITM_AMT: 0,
    LBR_RATE: 0,
    LBR_AMT: 0,
    OTH_AMT: 0,
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: ctx.book.dataType,
  };
  const ac = ctx.acCode;
  const it = ctx.itType || 'G';
  const slot = (n: number) => ctx.book.slots[n] ?? '';
  const roj = (
    n: string,
    acCode: string,
    ldCode: string,
    crAmt: number,
    drAmt: number,
    acName: string,
    sign: string,
    wt: number,
    touch: number,
    fine: number,
    itDesc: string,
  ) =>
    rows.push({
      ...base,
      LEDR_KEY: `${key}${n}`,
      AC_CODE: acCode,
      LD_CODE: ldCode,
      CR_AMT: crAmt,
      DR_AMT: drAmt,
      AC_NAME: acName,
      IT_TYPE: it,
      SIGN: sign,
      ITM_GWT: wt,
      ITM_NWT: wt,
      ITM_TOUCH: touch,
      ITM_WEST: 0,
      ITM_FINE: fine,
      NET_AMT: 0,
      IT_DESC: itDesc,
    });
  // Leg 01: gold DR fine.
  if (it === 'G' && ctx.balance.drFine !== 0 && ac) {
    roj('01', ac, slot(6), 0, 0, partyName, '-', ctx.balance.drWt, 0, ctx.balance.drFine, '');
    roj('02', slot(7), ac, 0, 0, partyName, '+', ctx.balance.crWt, 0, ctx.balance.crFine, '');
  }
  // Leg 05: labour.
  if (ctx.balance.crLbr !== 0 && ac) {
    rows.push({
      ...base,
      LEDR_KEY: `${key}05`,
      AC_CODE: slot(5),
      LD_CODE: ac,
      CR_AMT: 0,
      DR_AMT: ctx.balance.crLbr,
      AC_NAME: `LBR - ${labourAcName}`,
      IT_TYPE: 'A',
      SIGN: '',
      ITM_GWT: 0,
      ITM_NWT: 0,
      ITM_TOUCH: 0,
      ITM_WEST: 0,
      ITM_FINE: 0,
      NET_AMT: 0,
      IT_DESC: ctx.vchDesc,
    });
  }
  return rows;
}

/**
 * DM_DATA via Ac_Stock.Dm_Tag_Split_Detl (Ac_Stock.cs:843/845): OUT from parent stones, IN from child stones, for
 * items with OTH_DETL_POSTING = 'Y'. MAIN_SRNO 1 = OUT, 2 = IN.
 */
export function diamondRows(
  ctx: TagSplitWriteContext,
  parents: readonly TagSplitWriteParent[],
  children: readonly TagSplitWriteChild[],
  items: ReadonlyMap<string, TagSplitItem>,
): Record<string, unknown>[] {
  const out: Record<string, unknown>[] = [];
  const posts = (itCode: string) => items.get(itCode.trim().toUpperCase())?.postsDiamonds;
  const dm = (
    mainSrno: number,
    srNo: number,
    line: { cells: { tagNo: string; vchSrno: number; itCode: string } },
    stone: TagSplitStoneRow,
    sign: string,
    io: string,
  ) =>
    out.push({
      ...ctx.key,
      MAIN_SRNO: mainSrno,
      SR_NO: srNo,
      ISR_NO: stone.isrNo,
      VCH_DATE: ctx.vchDate,
      ENTRY_TYPE: 'S',
      BOOK_NAME: ctx.book.shortName,
      AC_CODE: ctx.acCode,
      IT_CODE: stone.itCode,
      DM_LOT_NO: '',
      DM_PCS: stone.pcs,
      DM_WT: stone.grossWt,
      DM_SIGN: sign,
      DM_RATE: stone.rate,
      DM_AMT: stone.amount,
      EMP_CODE: '',
      TAG_NO: line.cells.tagNo,
      VCH_SRNO: line.cells.vchSrno,
      MAIN_IT_CODE: line.cells.itCode,
      INOUT_TYPE: io,
      // The desktop's TBL_CODE has no DM_DATA column in the web schema (as documented for tag cancel).
    });
  for (const p of parents) {
    for (const stone of p.stones.filter(stoneQualifies)) {
      if (posts(stone.itCode)) dm(1, p.srNo, p, stone, '-', 'O');
    }
  }
  for (const ch of children) {
    for (const stone of ch.stones.filter(stoneQualifies)) {
      if (posts(stone.itCode)) dm(2, ch.srNo, ch, stone, '+', 'I');
    }
  }
  return out;
}

/**
 * DELETE_DATA — Web adaptation (K11.3): one row per parent line, as N18 writes for tag cancel. The desktop writes
 * none; we audit the reversal for parity with the other tag forms.
 */
export function deleteAuditRows(
  book: TagSplitBookPolicy,
  parents: readonly Record<string, unknown>[],
  deleteUser: string,
  at: Date,
): Record<string, unknown>[] {
  return parents.map((row) => ({
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
