/**
 * The MAIN_STOCK rows of a sale, as Sale_Stk writes them (Ac_Stock.cs:98-132): one OUT row per SL_DETL line and one
 * IN row per old-metal SL_PR_DETL line, each copied from its source row.
 *
 * SR_NO is the section constant: 1 for the sale line and 2 for old metal, what this desktop build wrote on all 245 sale
 * and 22 old-metal stock rows of the 2024-25 year. The decompiled source's non-P branch numbers the same sections 3
 * and 4 (Ac_Stock.cs:114, :116), a build difference reported with the sale ledger codes.
 */

type Row = Record<string, any>;

export interface SaleStockContext {
  key: Record<string, unknown>;
  vchDate: Date;
  bookPolicy: { vchType: string; bookName: string };
  acCode: string;
  mainUser: string;
}

const num = (v: unknown): number => (v == null ? 0 : Number(v));
const round2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;

/**
 * The stock OUT row of one sale line (Ac_Stock.cs:114): ISR_NO = the line's SR_NO, STK_DATE = VCH_DATE, the book's
 * BOOK_SNAME and MAIN_BOOK, TAG_NO / VCH_SRNO / TBL_CODE, ITM_QTY 1, ITM_PCS, touch, fine, rate and amounts, LBR_RATE,
 * OTH_AMT, ITM_MRP, the karigar columns (KR_NWT = KR_NET_WT, KR_TOUCH, KR_WEST = KR_WEST_PRC, KR_FINE), KR_COST =
 * TAG_COST, EMP_CODE, DESIGN_NO, ITM_SIZE, GHT_PRC = ITM_GHT_PRC, ITM_LOT and ITM_DISC = IT_DISC_AMT + DISC_AMT;
 * ITM_WEST, KR_LBR_AMT and KR_OTH_AMT are 0 and ITM_DESC ''. The weights follow the stock-report view (:112-113),
 * which the caller resolves.
 */
export function saleStockRow(
  d: Row,
  weight: { grossWt: number; netWt: number },
  ctx: SaleStockContext,
): Row {
  return {
    ...ctx.key,
    SR_NO: 1,
    ISR_NO: d.SR_NO,
    VCH_DATE: ctx.vchDate,
    STK_DATE: ctx.vchDate.toISOString().slice(0, 10),
    VCH_TYPE: ctx.bookPolicy.vchType,
    BOOK_NAME: ctx.bookPolicy.bookName,
    AC_CODE: ctx.acCode,
    IT_CODE: d.IT_CODE,
    TAG_NO: d.TAG_NO,
    VCH_SRNO: d.VCH_SRNO,
    TBL_CODE: d.TBL_CODE,
    TR_TYPE: 'S',
    ITM_SIGN: '-',
    // A movement count, not a weight: the literal 1 (Ac_Stock.cs:114).
    ITM_QTY: 1,
    ITM_PCS: d.ITM_PCS,
    ITM_GWT: weight.grossWt,
    ITM_NWT: weight.netWt,
    ITM_TOUCH: d.ITM_TOUCH,
    ITM_WEST: 0,
    ITM_FINE: d.ITM_FINE,
    ITM_RATE: d.ITM_RATE,
    ITM_AMT: d.ITM_AMT,
    LBR_RATE: d.LBR_RATE,
    LBR_AMT: d.LBR_AMT,
    OTH_AMT: d.OTH_AMT,
    ITM_MRP: d.ITM_MRP,
    NET_AMT: d.NET_AMT,
    KR_NWT: d.KR_NET_WT,
    KR_TOUCH: d.KR_TOUCH,
    KR_WEST: d.KR_WEST_PRC,
    KR_FINE: d.KR_FINE,
    KR_LBR_AMT: 0,
    KR_OTH_AMT: 0,
    KR_COST: d.TAG_COST,
    EMP_CODE: d.EMP_CODE,
    MAIN_USER: ctx.mainUser,
    DESIGN_NO: d.DESIGN_NO,
    ITM_SIZE: d.ITM_SIZE,
    ITM_DESC: '',
    GHT_PRC: d.ITM_GHT_PRC,
    ITM_LOT: d.ITM_LOT,
    ITM_DISC: String(round2(num(d.IT_DISC_AMT) + num(d.DISC_AMT))),
  };
}

/**
 * The stock IN row of one old-metal line (Ac_Stock.cs:116): ISR_NO = the line, TAG_NO 'N', TR_TYPE 'P', '+', the
 * line's weights, touch, fine and rate, ITM_AMT = NET_AMT = KR_COST = the line amount, KR_NWT / KR_TOUCH / KR_FINE
 * from the line, every other amount 0.
 */
export function saleOldMetalStockRow(g: Row, ctx: SaleStockContext): Row {
  return {
    ...ctx.key,
    SR_NO: 2,
    ISR_NO: g.SR_NO,
    VCH_DATE: ctx.vchDate,
    STK_DATE: ctx.vchDate.toISOString().slice(0, 10),
    VCH_TYPE: ctx.bookPolicy.vchType,
    BOOK_NAME: ctx.bookPolicy.bookName,
    AC_CODE: ctx.acCode,
    IT_CODE: g.IT_CODE,
    TAG_NO: 'N',
    VCH_SRNO: 0,
    TBL_CODE: '',
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: 1,
    ITM_PCS: g.ITM_PCS,
    ITM_GWT: g.ITM_GWT,
    ITM_NWT: g.ITM_NWT,
    ITM_TOUCH: g.ITM_TOUCH,
    ITM_WEST: 0,
    ITM_FINE: g.ITM_FINE,
    ITM_RATE: g.ITM_RATE,
    ITM_AMT: g.NET_AMT,
    LBR_RATE: 0,
    LBR_AMT: 0,
    OTH_AMT: 0,
    ITM_MRP: 0,
    NET_AMT: g.NET_AMT,
    KR_NWT: g.ITM_NWT,
    KR_TOUCH: g.ITM_TOUCH,
    KR_WEST: 0,
    KR_FINE: g.ITM_FINE,
    KR_LBR_AMT: 0,
    KR_OTH_AMT: 0,
    KR_COST: g.NET_AMT,
    EMP_CODE: '',
    MAIN_USER: ctx.mainUser,
    DESIGN_NO: '',
    ITM_SIZE: '',
    ITM_DESC: '',
    GHT_PRC: 0,
    ITM_LOT: '',
    ITM_DISC: '0',
  };
}
