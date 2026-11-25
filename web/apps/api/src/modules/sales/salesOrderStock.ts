/**
 * `Ac_Stock.Order_Stk` (`Ac_Stock.cs`, called after every order save: `TR_SALE_ORD.cs:9564-9566`,
 * `TR_TOUR_ORD.cs:7615-7617`). Both statements join BOOK_DATA and post only for a book whose BOOK_INOUT is 'I'.
 *
 * 1. Old metal taken in (SL_PR_DETL), SALES ORDER and TOUR ORDER: one '+' row per line, SR_NO 1, ISR_NO the line,
 *    TR_TYPE 'P', TAG_NO 'N', VCH_SRNO 0, TBL_CODE '', ITM_QTY 1, ITM_WEST 0, ITM_AMT and NET_AMT the line's NET_AMT,
 *    LBR_RATE/LBR_AMT/OTH_AMT/ITM_MRP 0, KR_NWT/KR_TOUCH/KR_FINE the line's net weight, touch and fine, KR_WEST,
 *    KR_LBR_AMT, KR_OTH_AMT, KR_COST 0, EMP_CODE '', ENTRY_TIME VCH_TIME, DATA_TYPE BOOK_DATA.DATA_TYPE, DESIGN_NO,
 *    ITM_SIZE, ITM_DESC, ITM_LOT '' and GHT_PRC, ITM_DISC 0.
 * 2. Order lines with TAG_STK_LESS = 'Y' (SL_ORD_DETL), SALES ORDER only: one '-' row per line, SR_NO 2, ISR_NO the
 *    line, TR_TYPE 'O', the line's tag, serial, table, weights, rate, amounts, MRP and karigar columns, KR_COST
 *    TAG_COST, GHT_PRC ITM_GHT_PRC, DATA_TYPE 'A'.
 *
 * The rows are built from the rows this save writes, as the desktop's INSERT ... SELECT reads them back.
 */
export interface OrderStockBook {
  mainBook: string;
  vchType: string;
  inoutType: string;
  dataType: string;
}

type Row = Record<string, unknown>;

export function orderStockWrites(
  key: Row,
  book: OrderStockBook,
  oldMetalRows: readonly Row[],
  orderLines: readonly Row[],
): Array<{ table: 'MAIN_STOCK'; rows: Row[] }> {
  if (book.inoutType !== 'I') return [];
  const common = (row: Row) => ({
    ...key,
    ISR_NO: row.SR_NO,
    VCH_DATE: row.VCH_DATE,
    // STK_DATE is character data; the web writes the date as YYYY-MM-DD, as its other stock writers do.
    STK_DATE: row.VCH_DATE instanceof Date ? row.VCH_DATE.toISOString().slice(0, 10) : row.VCH_DATE,
    VCH_TYPE: book.vchType,
    BOOK_NAME: book.mainBook,
    AC_CODE: row.AC_CODE,
    IT_CODE: row.IT_CODE,
    ITM_QTY: 1,
    ITM_PCS: row.ITM_PCS,
    ITM_GWT: row.ITM_GWT,
    ITM_NWT: row.ITM_NWT,
    ITM_TOUCH: row.ITM_TOUCH,
    ITM_WEST: 0,
    ITM_FINE: row.ITM_FINE,
    ITM_RATE: row.ITM_RATE,
    NET_AMT: row.NET_AMT,
    KR_LBR_AMT: 0,
    KR_OTH_AMT: 0,
    ENTRY_TIME: row.VCH_TIME,
    MAIN_USER: row.MAIN_USER,
    ITM_DESC: '',
    ITM_LOT: '',
    ITM_DISC: 0,
  });
  const metalIn = oldMetalRows.map((row) => ({
    ...common(row),
    SR_NO: 1,
    TAG_NO: 'N',
    VCH_SRNO: 0,
    TBL_CODE: '',
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_AMT: row.NET_AMT,
    LBR_RATE: 0,
    LBR_AMT: 0,
    OTH_AMT: 0,
    ITM_MRP: 0,
    KR_NWT: row.ITM_NWT,
    KR_TOUCH: row.ITM_TOUCH,
    KR_WEST: 0,
    KR_FINE: row.ITM_FINE,
    KR_COST: 0,
    EMP_CODE: '',
    DATA_TYPE: book.dataType,
    DESIGN_NO: '',
    ITM_SIZE: '',
    GHT_PRC: 0,
  }));
  const tagsOut =
    book.mainBook === 'SALES ORDER'
      ? orderLines
          .filter((row) => String(row.TAG_STK_LESS ?? '') === 'Y')
          .map((row) => ({
            ...common(row),
            SR_NO: 2,
            TAG_NO: row.TAG_NO,
            VCH_SRNO: row.VCH_SRNO,
            TBL_CODE: row.TBL_CODE,
            TR_TYPE: 'O',
            ITM_SIGN: '-',
            ITM_AMT: row.ITM_AMT,
            LBR_RATE: row.LBR_RATE,
            LBR_AMT: row.LBR_AMT,
            OTH_AMT: row.OTH_AMT,
            ITM_MRP: row.ITM_MRP,
            KR_NWT: row.KR_NET_WT,
            KR_TOUCH: row.KR_TOUCH,
            KR_WEST: row.KR_WEST_PRC,
            KR_FINE: row.KR_FINE,
            KR_COST: row.TAG_COST,
            EMP_CODE: row.EMP_CODE,
            DATA_TYPE: 'A',
            DESIGN_NO: row.DESIGN_NO,
            ITM_SIZE: row.ITM_SIZE,
            GHT_PRC: row.ITM_GHT_PRC,
          }))
      : [];
  const rows = [...metalIn, ...tagsOut];
  return rows.length ? [{ table: 'MAIN_STOCK', rows }] : [];
}

/** The old metal '+' rows (SR_NO 1, TR_TYPE 'P') are rebuilt by every save, so they never block an edit. */
export const isRebuiltOrderStockRow = (row: Row): boolean =>
  Number(row.SR_NO) === 1 && String(row.TR_TYPE ?? '').trim() === 'P';
