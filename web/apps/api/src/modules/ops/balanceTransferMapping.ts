/**
 * Balance TrFr: the row mappings of the three datasets whose write waits on an owner decision (Tag Stock Q8, Sales
 * Order Q1, Approval Q1/Q5). The mappings are the desktop's insert value lists, column by column, so the writer that
 * follows the decision only has to place the rows. Pure, unit-tested in balanceTransferMapping.test.ts.
 *
 * Notation of the desktop lists: a column is copied from the source row, copied through DC_Main.Fnv (NULL or blank →
 * 0, DC_Main.cs:2088), or set to a constant. String values are concatenated into the SQL unescaped on the desktop; the
 * web writes parameters, so the copy is exact.
 */

type Row = Record<string, unknown>;

/** DC_Main.Fnv: NULL, undefined and blank are 0; otherwise the number (Conversion.Val of the text). */
export function fnv(value: unknown): number {
  if (value === null || value === undefined) return 0;
  if (typeof value === 'number') return Number.isFinite(value) ? value : 0;
  const text = String(value).trim();
  if (text === '') return 0;
  const match = /^[+-]?(?:\d+(?:\.\d*)?|\.\d+)/.exec(text.replace(/\s/g, ''));
  return match ? Number(match[0]) : 0;
}

const copy = (src: Row, cols: readonly string[]): Row =>
  Object.fromEntries(cols.map((c) => [c, src[c] ?? null]));
const fnvs = (src: Row, cols: readonly string[]): Row =>
  Object.fromEntries(cols.map((c) => [c, fnv(src[c])]));

const HM_IDS = ['HM_ID', 'HM_ID2', 'HM_ID3', 'HM_ID4'] as const;
const HM_WTS = ['HM_ID_WT', 'HM_ID2_WT', 'HM_ID3_WT', 'HM_ID4_WT'] as const;

/** The Transfer Year's scope and the opening day of a carried stock row. */
export interface CarryContext {
  coCode: string;
  lcCode: string;
  toYear: string;
  /** OP_DATE − 1 day (`mTrfr_dt.AddDays(-1.0)`), ISO date. */
  stockDate: string;
  mainUser: string;
}

// ---------------------------------------------------------------------------------------------------------------
// Tag Stock (Rtl_BarData, BtmSchm.cs:2319-2640)
// ---------------------------------------------------------------------------------------------------------------

const TAG_COPY = [
  'VCH_TYPE',
  'BOOK_NAME',
  'AC_CODE',
  'IT_CODE',
  'TAG_NO',
  'DESIGN_NO',
  'TBL_CODE',
  'ITM_SIZE',
  'LBR_TYPE',
  'ITM_REMARK',
  'SF_NO',
  'KR_NAME',
  'RATE_TYPE',
  'IT_TYPE',
  'TAG_TYPE',
  'PR_CODE',
  'ORD_NO',
  'ORD_YRCD',
  'ORD_DBCD',
  'ORD_AC',
  'OLD_VCH_NO',
  'NEW_VCH_NO',
  ...HM_IDS,
  'DATA_TYPE',
  'APP_TRFR',
  'ITM_COLOR',
  'EMP_ISU',
  'LBR_CODE',
  'DESIGN_IMG_ID',
  'SL_TYPE',
  'ITM_STYLE',
  'ORD_LC_CODE',
  'MFG_YRCD',
  'MFG_DBCD',
  'MFG_NO',
] as const;
const TAG_FNV = [
  'ITM_PCS',
  'BAG_WT',
  'ITM_GWT',
  'ITM_OTH_WT',
  'ITM_NWT',
  'ITM_GHT_PRC',
  'ITM_GHT_WT',
  'ITM_TOUCH',
  'ITM_WEST_PRC',
  'ITM_FINE',
  'LBR_PRC',
  'LBR_RATE',
  'LBR_AMT',
  'OTH_AMT',
  'ITM_RATE',
  'ITM_AMT',
  'TAG_COST',
  'ITM_MARGIN',
  'ITM_MRP',
  'KR_OTH_WT',
  'KR_NET_WT',
  'KR_GHT_PRC',
  'KR_GHT_WT',
  'KR_TOUCH',
  'KR_WEST_PRC',
  'KR_FINE',
  'KR_LBR_RATE',
  'KR_LBR_AMT',
  'KR_OTH_AMT',
  'KR_COST',
  'TAG_SRNO',
  'VCH_SRNO',
  'ORD_SRNO',
  ...HM_WTS,
  'MAIN_MARGIN_PRC',
  'MAIN_MRP',
  'JDT_JDT_WT',
  'JDT_GHT_WT',
  'JDT_KUN_WT',
  'JDT_WAX_WT',
  'KR_WAX_WT',
  'JDT_KUN_TOUCH',
  'JDT_KUN_NET',
  'KR_OTH_RATE',
  'KR_OTH_FINE',
  'KR_TOT_FINE',
  'KR_GWT_TOUCH',
  'MFG_SRNO',
] as const;

/**
 * One carried tag (BAR_DETL insert, BtmSchm.cs:2378-2513) from the tag's latest BAR_DETL row of the closed year: every
 * value copied (numbers through Fnv) except CO_YEAR, book '000', the item's voucher number (also HD_VCH_NO), SR_NO and
 * OLD_SRNO the running number, VCH_DATE the opening day, STK_DATE and VCH_TIME the source STK_DATE, INOUT 'I', ENTRY
 * 'O', LOT_NO '', APR_ISU 'N', DATA_TRFR 'N', MAIN_USER and ADD_USER the operator. CO_CODE is the source row's.
 */
export function tagCarryRow(src: Row, ctx: CarryContext, vchNo: string, srNo: number): Row {
  return {
    ...copy(src, TAG_COPY),
    ...fnvs(src, TAG_FNV),
    CO_CODE: src.CO_CODE ?? ctx.coCode,
    LC_CODE: ctx.lcCode,
    CO_YEAR: ctx.toYear,
    CO_BOOK: '000',
    VCH_NO: vchNo,
    SR_NO: srNo,
    OLD_SRNO: srNo,
    VCH_DATE: ctx.stockDate,
    STK_DATE: src.STK_DATE ?? null,
    VCH_TIME: src.STK_DATE ?? null,
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    LOT_NO: '',
    APR_ISU: 'N',
    MAIN_USER: ctx.mainUser,
    ADD_USER: ctx.mainUser,
    DATA_TRFR: 'N',
    HD_VCH_NO: vchNo,
  };
}

const STONE_COPY = [
  'VCH_TYPE',
  'BOOK_NAME',
  'AC_CODE',
  'TAG_NO',
  'VCH_SRNO',
  'IT_CODE',
  'IT_TYPE',
  'DM_CODE',
  'DM_SIZE',
  'DM_SFNO',
  'DM_LEB',
  'IT_RATE_TYPE',
  'DM_NAME',
  'DM_ORIGIN',
  'DM_REMARK',
  'DM_COLOR',
] as const;
const STONE_FNV = [
  'IT_PCS',
  'IT_PCS_WT',
  'KR_WT',
  'KR_LESS_PRC',
  'IT_GWT',
  'IT_CON_PRC',
  'IT_CON_WT',
  'IT_RATE',
  'IT_AMT',
  'IT_LBR_RATE',
  'IT_LBR_AMT',
  'IT_NET_AMT',
  'KR_CON_PRC',
  'KR_CON_WT',
  'KR_RATE',
  'KR_AMT',
  'KR_LBR_RATE',
  'KR_LBR_AMT',
  'KR_NET_AMT',
  'KR_ACT_WT',
  'KR_ACT_PRC',
] as const;

/**
 * One stone row of a carried tag (BAR_IDTL insert, BtmSchm.cs:2520-2617): the parent's voucher and SR_NO, ISR_NO
 * renumbered 1.. in ISR_NO order, the opening day, INOUT 'I', ENTRY 'O'; everything else copied (numbers through Fnv).
 * The desktop writes MAIN_USER as Fnv of the user text, which turns a name into '0' (BtmSchm.cs:2597-2601); the web
 * keeps the source user.
 */
export function tagStoneRow(
  src: Row,
  ctx: CarryContext,
  vchNo: string,
  srNo: number,
  index: number,
): Row {
  return {
    ...copy(src, STONE_COPY),
    ...fnvs(src, STONE_FNV),
    KR_RATE_TYPE: src.KR_RATE_TYPE ?? null,
    IT_DISC_PRC: fnv(src.IT_DISC_PRC),
    IT_DISC_AMT: fnv(src.IT_DISC_AMT),
    CO_CODE: ctx.coCode,
    LC_CODE: ctx.lcCode,
    CO_YEAR: ctx.toYear,
    CO_BOOK: '000',
    VCH_NO: vchNo,
    SR_NO: srNo,
    ISR_NO: index + 1,
    VCH_DATE: ctx.stockDate,
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    MAIN_USER: src.MAIN_USER ?? null,
  };
}

/** The item's opening voucher header (BAR_DATA insert, BtmSchm.cs:2627), written once the item has a tag. */
export function tagHeaderRow(ctx: CarryContext, vchNo: string): Row {
  return {
    CO_CODE: ctx.coCode,
    LC_CODE: ctx.lcCode,
    CO_YEAR: ctx.toYear,
    CO_BOOK: '000',
    VCH_NO: vchNo,
    VCH_DATE: ctx.stockDate,
    AC_CODE: '',
    CUST_AC: '',
    OP_STK: 'Y',
    VCH_TIME: ctx.stockDate,
  };
}

/**
 * The voucher numbers of the carried items (BtmSchm.cs:2324-2342, :2369-2371, :2629): one voucher per item with at least
 * one tag, from 00001 up; when the Transfer Year's book '000' already starts at 00001, numbering continues after its
 * highest voucher. `existing` is the book-000 BAR_DATA voucher numbers left after the run's own deletes.
 */
export function tagVoucherNumbers(itemCount: number, existing: readonly string[]): string[] {
  const nums = existing.map((v) => Number(v)).filter((n) => Number.isFinite(n) && n > 0);
  const first = nums.length ? Math.min(...nums) : null;
  const next = nums.length ? Math.max(...nums) + 1 : 1;
  const out: string[] = [];
  let text = 1;
  for (let i = 0; i < itemCount; i += 1) {
    if (first !== null && text === first) text = next;
    out.push(String(text).padStart(5, '0'));
    text += 1;
  }
  return out;
}

// ---------------------------------------------------------------------------------------------------------------
// Sales Order (Rtl_Order, BtmSchm.cs:3016-3335)
// ---------------------------------------------------------------------------------------------------------------

/** One open order of the selection (BtmSchm.cs:3024): its adjusted-so-far figures. */
export interface OrderAdjusted {
  adjAmount: unknown;
  adjGold: unknown;
  adjSilver: unknown;
}

const ORDER_COPY = [
  'CO_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'VCH_DATE',
  'BILL_NO',
  'HD_VCH_NO',
  'AC_CODE',
  'AC_NAME',
  'TAX_CODE',
  'DEL_DATE',
  'CARD_AC',
  'BANK_AC',
  'CHQ_NO',
  'BANK_NAME',
  'EMP_CODE',
  'VCH_DESC',
  'CARD_ADJ',
  'DATA_TRFR',
  'MAIN_USER',
  'ADD1',
  'ADD2',
  'ADD3',
  'CITY',
  'MOBILE',
  'MOB_ENTRY_SAVE',
  'FUN_DATE',
] as const;
const ORDER_FNV = [
  'NET_AMT',
  'TAX_PRC',
  'TAX_AMT',
  'TOT_AMT',
  'ADV_AMT',
  'OLD_GL_AMT',
  'OLD_SL_AMT',
  'CASH_AMT',
  'CARD_AMT',
  'CHQ_AMT',
  'SCHM_AMT',
  'OLD_GL',
  'OLD_SL',
  'RCUT_AMT',
  'RCUT_RATE',
  'RCUT_FINE',
  'UPI_AMT',
] as const;

/**
 * An open order's header (SL_ORD_DATA insert, BtmSchm.cs:3048-3125): keeps its own CO_YEAR, CO_BOOK and VCH_NO; the
 * adjustment columns take the adjusted-so-far sums (ORD_ADJ_AMT, ADJ_GOLD, ADJ_SILVER); VCH_TIME and ENTRY_TIME are
 * the order date; SL_BILL_TYPE, OLD_VCH_NO and NEW_VCH_NO blank; everything else copied (numbers through Fnv).
 */
export function orderHeaderRow(src: Row, adj: OrderAdjusted, lcCode: string): Row {
  return {
    ...copy(src, ORDER_COPY),
    ...fnvs(src, ORDER_FNV),
    LC_CODE: lcCode,
    VCH_TIME: src.VCH_DATE ?? null,
    ENTRY_TIME: src.VCH_DATE ?? null,
    ORD_ADJ_AMT: fnv(adj.adjAmount),
    ADJ_GOLD: fnv(adj.adjGold),
    ADJ_SILVER: fnv(adj.adjSilver),
    SL_BILL_TYPE: '',
    OLD_VCH_NO: '',
    NEW_VCH_NO: '',
  };
}

const ORDER_LINE_COPY = [
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'VCH_DATE',
  'AC_CODE',
  'IT_CODE',
  'TAG_NO',
  'ITM_REMARK',
  'PR_CODE',
  'DESIGN_ISU',
  'TAG_GEN',
  'TAG_SALE',
  ...HM_IDS,
  'OLD_TBL_CODE',
  'ITM_COLOR',
  'ORD_DEL_DATE',
  'EMP_CODE',
  'TAG_STK_LESS',
  'RATE_FIX',
  'DESIGN_IMG_ID',
] as const;
const ORDER_LINE_FNV = [
  'ITM_PCS',
  'ITM_GWT',
  'ITM_NWT',
  'ITM_GHT_WT',
  'LBR_PRC',
  'LBR_RATE',
  'LBR_AMT',
  'OTH_AMT',
  'ITM_RATE',
  'ITM_AMT',
  'TOT_AMT',
  'TAX_PRC',
  'NET_AMT',
  'ITM_GHT_PRC',
  ...HM_WTS,
  'ORD_REC_AMT',
] as const;
const ORDER_LINE_ZERO = [
  'BAG_WT',
  'ITM_OTH_WT',
  'ITM_TOUCH',
  'ITM_WEST_PRC',
  'ITM_FINE',
  'TAG_COST',
  'ITM_MRP',
  'VCH_SRNO',
  'KR_NET_WT',
  'KR_TOUCH',
  'KR_WEST_PRC',
  'KR_FINE',
] as const;

/**
 * An order line (SL_ORD_DETL insert, BtmSchm.cs:3137-3213; the Order Tag Booking pass at :3245-3322 uses the same
 * list). `src` is the line joined to its BOOK_DATA row (BOOK_SNAME, MAIN_BOOK, BOOK_INOUT, :3127).
 */
export function orderLineRow(
  src: Row,
  ctx: { coCode: string; lcCode: string; mainUser: string },
): Row {
  const mid15 = (v: unknown) => `${v ?? ''}`.slice(0, 15);
  return {
    ...copy(src, ORDER_LINE_COPY),
    ...fnvs(src, ORDER_LINE_FNV),
    ...Object.fromEntries(ORDER_LINE_ZERO.map((c) => [c, 0])),
    CO_CODE: ctx.coCode,
    LC_CODE: ctx.lcCode,
    SR_NO: src.SR_NO ?? null,
    OLD_SRNO: src.SR_NO ?? null,
    VCH_TIME: src.VCH_DATE ?? null,
    VCH_TYPE: src.BOOK_SNAME ?? null,
    INOUT_TYPE: src.BOOK_INOUT ?? null,
    ENTRY_TYPE: 'O',
    BOOK_NAME: src.MAIN_BOOK ?? null,
    LOT_NO: '',
    DESIGN_NO: mid15(src.DESIGN_NO),
    TBL_CODE: '',
    ITM_SIZE: mid15(src.ITM_SIZE),
    LBR_TYPE: '',
    KR_NAME: '',
    RATE_TYPE: '',
    IT_TYPE: '',
    HD_VCH_NO: src.VCH_NO ?? null,
    DATA_TRFR: 'N',
    OLD_VCH_NO: '',
    NEW_VCH_NO: '',
    MAIN_USER: ctx.mainUser,
    ADD_USER: ctx.mainUser,
  };
}

// ---------------------------------------------------------------------------------------------------------------
// Approval (Rtl_Approval, BtmSchm.cs:4135-4650)
// ---------------------------------------------------------------------------------------------------------------

const APR_COPY = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'SR_NO',
  'OLD_SRNO',
  'VCH_DATE',
  'AC_CODE',
  'VCH_TIME',
  'VCH_TYPE',
  'INOUT_TYPE',
  'ENTRY_TYPE',
  'BOOK_NAME',
  'IT_CODE',
  'TAG_NO',
  'LOT_NO',
  'DESIGN_NO',
  'TBL_CODE',
  'ITM_SIZE',
  'LBR_TYPE',
  'ITM_REMARK',
  'KR_NAME',
  'RATE_TYPE',
  'IT_TYPE',
  'PR_CODE',
  'HD_VCH_NO',
  'MAIN_USER',
  'ISU_REC',
  'ISU_NO',
  'ISU_YRCD',
  'ISU_DBCD',
  'ISU_AC_CODE',
  'ISU_AC_NAME',
  'MTL_COLOR',
  ...HM_IDS,
  'ITM_COLOR',
  'EMP_CODE',
  'EMP_SALE',
  'DESIGN_IMG_ID',
] as const;
const APR_FNV = [
  'ITM_PCS',
  'BAG_WT',
  'ITM_GWT',
  'ITM_OTH_WT',
  'ITM_NWT',
  'ITM_GHT_WT',
  'ITM_TOUCH',
  'ITM_WEST_PRC',
  'ITM_FINE',
  'LBR_PRC',
  'LBR_RATE',
  'LBR_AMT',
  'OTH_AMT',
  'ITM_RATE',
  'ITM_AMT',
  'TAG_COST',
  'ITM_MRP',
  'NET_AMT',
  'VCH_SRNO',
  'KR_NET_WT',
  'KR_TOUCH',
  'KR_WEST_PRC',
  'KR_FINE',
  'ISU_SRNO',
  'ADJ_GWT',
  'ADJ_NWT',
  ...HM_WTS,
  'ITM_LESS_TCH',
  'ITM_LOSS_WT',
] as const;

/**
 * An open approval line (APR_DETL insert, BtmSchm.cs:4154-4283): a verbatim copy of the source row, its own keys
 * included, numbers through Fnv, ORNA_REC_DATE NULL.
 */
export function approvalLineRow(src: Row): Row {
  return { ...copy(src, APR_COPY), ...fnvs(src, APR_FNV), ORNA_REC_DATE: null };
}

/** A stone row of an open approval line (APR_IDTL insert, BtmSchm.cs:4291-4379): keys and ISR_NO kept. */
export function approvalStoneRow(src: Row, ctx: { coCode: string; lcCode: string }): Row {
  return {
    ...copy(src, STONE_COPY),
    ...fnvs(
      src,
      STONE_FNV.filter((c) => c !== 'KR_ACT_WT' && c !== 'KR_ACT_PRC'),
    ),
    CO_CODE: ctx.coCode,
    LC_CODE: ctx.lcCode,
    CO_YEAR: src.CO_YEAR ?? null,
    CO_BOOK: src.CO_BOOK ?? null,
    VCH_NO: src.VCH_NO ?? null,
    SR_NO: fnv(src.SR_NO),
    ISR_NO: fnv(src.ISR_NO),
    VCH_DATE: src.VCH_DATE ?? null,
    INOUT_TYPE: src.INOUT_TYPE ?? null,
    ENTRY_TYPE: src.ENTRY_TYPE ?? null,
    MAIN_USER: src.MAIN_USER ?? null,
  };
}

const APR_TAG_COPY = TAG_COPY.filter(
  (c) =>
    ![
      'VCH_TYPE',
      'BOOK_NAME',
      'ORD_NO',
      'ORD_YRCD',
      'ORD_DBCD',
      'ORD_AC',
      'SL_TYPE',
      'ITM_STYLE',
      'ORD_LC_CODE',
      'MFG_YRCD',
      'MFG_DBCD',
      'MFG_NO',
    ].includes(c),
);
const APR_TAG_FNV = TAG_FNV.filter(
  (c) =>
    ![
      'ITM_OTH_WT',
      'TAG_SRNO',
      'ORD_SRNO',
      'KR_OTH_RATE',
      'KR_OTH_FINE',
      'KR_TOT_FINE',
      'KR_GWT_TOUCH',
      'MFG_SRNO',
    ].includes(c),
);

/**
 * The approval tag's stock line in book '218' (BAR_DETL insert, BtmSchm.cs:4388-4542) from the tag's latest BAR_DETL
 * row: voucher '00001', SR_NO and OLD_SRNO the 0-based approval row index (`DC_Main.M`), VCH_TYPE 'APRTG', BOOK_NAME
 * 'APR TAG', the opening day, other weight = gross − net, TAG_SRNO 1, APR_ISU 'Y', the order link cleared.
 */
export function approvalTagRow(src: Row, ctx: CarryContext, index: number): Row {
  return {
    ...copy(src, APR_TAG_COPY),
    ...fnvs(src, APR_TAG_FNV),
    CO_CODE: src.CO_CODE ?? ctx.coCode,
    LC_CODE: ctx.lcCode,
    CO_YEAR: ctx.toYear,
    CO_BOOK: '218',
    VCH_NO: '00001',
    SR_NO: index,
    OLD_SRNO: index,
    VCH_DATE: ctx.stockDate,
    STK_DATE: src.STK_DATE ?? null,
    VCH_TIME: src.STK_DATE ?? null,
    VCH_TYPE: 'APRTG',
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    BOOK_NAME: 'APR TAG',
    LOT_NO: '',
    ITM_OTH_WT: fnv(src.ITM_GWT) - fnv(src.ITM_NWT),
    TAG_SRNO: 1,
    APR_ISU: 'Y',
    ORD_NO: '',
    ORD_SRNO: 0,
    ORD_YRCD: '',
    ORD_DBCD: '',
    ORD_AC: '',
    MAIN_USER: ctx.mainUser,
    ADD_USER: ctx.mainUser,
    DATA_TRFR: 'N',
    HD_VCH_NO: src.HD_VCH_NO ?? null,
  };
}
