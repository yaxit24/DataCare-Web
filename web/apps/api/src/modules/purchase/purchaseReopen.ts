import { round, toIsoDate, type LabourType } from '@datacare/core';
import { legacyLabourModeFor } from '../shared/labourDesktop.js';
import { hallmarkLineView } from './purchaseHallmark.js';

/**
 * The reopen view of a saved purchase (`GET /purchases/:vchNo`), shaped as the edit request (`PUT`) takes it.
 *
 * WP-28 (D6, G1, G2, G10). The desktop reopens with `SELECT *` (TR_PURC.cs:12120, :12364; TR_PURC_HM.cs:7216, :7462)
 * and keeps every column in a grid cell, so an unchanged save writes back what it read. The web edit rebuilds the
 * write set from the request, so this view returns EVERY value the writer owns under the name the writer reads, and
 * returns stored results (typed amount, typed fine, labour amount, the date) rather than recomputing them. A screen
 * that sends the view back unchanged therefore reproduces every stored row.
 */

const text = (value: unknown): string => String(value ?? '').trim();
const num = (value: unknown): number => (value == null ? 0 : Number(value));
const optional = (value: unknown): number | undefined =>
  value == null ? undefined : Number(value);

export function purchaseStoneView(row: Record<string, unknown>): Record<string, unknown> {
  return {
    isrNo: num(row.ISR_NO),
    itCode: text(row.IT_CODE),
    dmCode: text(row.DM_CODE),
    dmName: text(row.DM_NAME),
    dmColor: text(row.DM_COLOR),
    dmSize: text(row.DM_SIZE),
    dmOrigin: text(row.DM_ORIGIN),
    dmRemark: text(row.DM_REMARK),
    dmSfNo: text(row.DM_SFNO),
    dmLeb: text(row.DM_LEB),
    pcs: num(row.IT_PCS),
    grossWt: num(row.IT_GWT),
    pcsWt: num(row.IT_PCS_WT),
    conPct: num(row.IT_CON_PRC),
    conWt: num(row.IT_CON_WT),
    rateType: text(row.IT_RATE_TYPE),
    rate: num(row.IT_RATE),
    amount: num(row.IT_AMT),
    lbrRate: num(row.IT_LBR_RATE),
    lbrAmount: num(row.IT_LBR_AMT),
    netAmount: num(row.IT_NET_AMT),
    itType: text(row.IT_TYPE),
    karigarWt: num(row.KR_WT),
    karigarLessPct: num(row.KR_LESS_PRC),
    karigarConPct: num(row.KR_CON_PRC),
    karigarConWt: num(row.KR_CON_WT),
    karigarRate: num(row.KR_RATE),
    karigarAmount: num(row.KR_AMT),
    karigarLabourRate: num(row.KR_LBR_RATE),
    karigarLabourAmount: num(row.KR_LBR_AMT),
    karigarNetAmount: num(row.KR_NET_AMT),
  };
}

/** One PR_DETL row as a `PurchaseLineInput` (every column the writer reads, by the writer's own field name). */
export function purchaseLineView(
  row: Record<string, unknown>,
  stones: Array<Record<string, unknown>>,
): Record<string, unknown> {
  return {
    // The persisted line identity: the writer keeps this row's unmodelled columns and stored item type (D6, D12).
    srNo: num(row.SR_NO),
    itCode: text(row.IT_CODE),
    metal: text(row.IT_TYPE) === 'S' ? 'S' : 'G',
    tagNo: text(row.TAG_NO) === 'N' ? '' : text(row.TAG_NO),
    vchSrno: num(row.VCH_SRNO),
    pcs: num(row.ITM_PCS),
    grossWt: num(row.ITM_GWT),
    netWt: num(row.ITM_NWT),
    touch: num(row.ITM_TOUCH),
    ghtWt: num(row.ITM_GHT_WT),
    westPct: num(row.ITM_WEST_PRC),
    // Stored results, never recomputed on reopen: the typed fine and amount win in the writer.
    fineWt: num(row.ITM_FINE),
    otherFineWt: num(row.ITM_OTH_FINE),
    silverFineWt: num(row.SILVER_FINE),
    rate: num(row.ITM_RATE),
    rateType: text(row.RATE_TYPE),
    urdRateType: text(row.URD_RATE_TYPE),
    metalAmount: num(row.ITM_AMT),
    labourType: legacyLabourModeFor(row.LBR_TYPE) as LabourType | undefined,
    labourPct: num(row.LBR_PRC),
    labourRate: num(row.LBR_RATE),
    labourFixed: text(row.LBR_TYPE) === 'N' ? num(row.LBR_AMT) : undefined,
    labourAmount: num(row.LBR_AMT),
    otherAmount: num(row.OTH_AMT),
    netAmount: num(row.NET_AMT),
    huid: text(row.HM_ID),
    designNo: text(row.DESIGN_NO),
    tblCode: text(row.TBL_CODE),
    itDesc: text(row.IT_DESC),
    bagWt: num(row.BAG_WT),
    lessWt: num(row.ITM_OTH_WT),
    mrp: num(row.ITM_MRP),
    otherRate: num(row.ITM_OTH_RATE),
    commissionPct: num(row.COMM_PRC),
    // G1: the fourteen columns the desktop reopens (TR_PURC.cs:12384-12458) and the web reader used to drop.
    lotNo: text(row.LOT_NO),
    itmLot: text(row.ITM_LOT),
    withStock: text(row.WITH_STOCK),
    lossWt: num(row.ITM_LOSS_WT),
    ghtPct: num(row.ITM_GHT_PRC),
    lessTouch: num(row.ITM_LESS_TCH),
    convRate: num(row.CONV_RATE),
    convPct: num(row.CONV_PRC),
    commissionAmount: num(row.COMM_AMT),
    fineCutPcs: num(row.FINE_CUT_PCS),
    fineCutGrossWt: num(row.FINE_CUT_GWT),
    fineCutNetWt: num(row.FINE_CUT_NWT),
    fineCutFine: num(row.FINE_CUT_FINE),
    prCode: text(row.PR_CODE),
    // G3: the hallmark receive columns (TR_PURC_HM.cs:7469-7574).
    ...hallmarkLineView(row),
    saleBillNo: text(row.SL_BILL_NO),
    saleBillLc: text(row.SL_BILL_LC),
    saleBillYear: text(row.SL_BILL_YRCD),
    saleBillBook: text(row.SL_BILL_DBCD),
    consiNo: text(row.CONSI_NO),
    consiYrcd: text(row.CONSI_YRCD),
    consiDbcd: text(row.CONSI_DBCD),
    consiSrno: num(row.CONSI_SRNO),
    stones,
  };
}

/** The PR_DATA header as a `PurchaseInput`, plus the read-only totals and identity the screen shows. */
export function purchaseHeaderView(
  h: Record<string, unknown>,
  computedRoundOff = false,
): Record<string, unknown> {
  return {
    voucherNo: text(h.VCH_NO),
    hiddenVoucherNo: text(h.HD_VCH_NO),
    mainUser: text(h.MAIN_USER),
    // The STORED date, from the text cast: an edit sends it back and never defaults to today.
    vchDate: toIsoDate(h.VCH_DATE_TEXT),
    // As typed: the writer stores BILL_NO without trimming, so the reader must not trim it either.
    billNo: String(h.BILL_NO ?? ''),
    saleBillNo: text(h.SL_BILL_NO),
    saleBillLc: text(h.SL_BILL_LC),
    saleBillYear: text(h.SL_BILL_YRCD),
    saleBillBook: text(h.SL_BILL_DBCD),
    consiNo: text(h.SL_BILL_NO),
    consiLcCode: text(h.SL_BILL_LC),
    consiYrcd: text(h.SL_BILL_YRCD),
    consiDbcd: text(h.SL_BILL_DBCD),
    acCode: text(h.AC_CODE),
    acName: text(h.AC_NAME),
    taxCode: text(h.TAX_CODE),
    taxRatePct: num(h.TAX_PRC),
    interState: num(h.IGST_TAX) !== 0 || text(h.AC_GST_TYPE).toUpperCase() !== 'L',
    urd: num(h.TAX_PRC) === 0 && num(h.TAX_AMT) === 0,
    discountAmount: num(h.DISC_AMT),
    rateUnfix: text(h.RATE_UNFIX).toUpperCase() === 'Y',
    cashAmt: num(h.CASH_AMT),
    cardAmt: num(h.CARD_AMT),
    upiAmt: 0,
    chequeAmt: num(h.CHQ_AMT),
    kasar: num(h.KASAR_AMT),
    billOutstanding: num(h.BILL_OS),
    bankAc: text(h.BANK_AC),
    hmAmount: num(h.HM_AMT),
    hmTaxPct: optional(h.HM_TAX_PRC),
    hmTaxAmount: num(h.HM_TAX_AMT),
    metal: text(h.IT_TYPE) === 'S' ? 'S' : 'G',
    partyFine: num(h.PARTY_FINE),
    description: text(h.VCH_DESC),
    // G2: header columns the desktop reopens (TR_PURC_HM.cs:7232-7340) and the web reader used to drop.
    vchDesc: text(h.VCH_DESC),
    empCode: text(h.EMP_CODE),
    hmTaxCode: text(h.HM_TAX_CODE),
    discountPct: num(h.DISC_PRC),
    tcsCode: text(h.TCS_CODE),
    tcsPct: num(h.TCS_PRC),
    tcsAmount: num(h.TCS_AMT),
    tdsCode: text(h.TDS_CODE),
    tdsPct: num(h.TDS_PRC),
    tdsAmount: num(h.TDS_AMT),
    // The typed row 4 (TR_PURC.cs:11790); 0 for the old web's computed one (shared/legacyRoundOff.ts).
    roundOffAmount: computedRoundOff ? 0 : num(h.ROF_AMT),
    chequeNo: text(h.CHQ_NO),
    bankName: text(h.BANK_NAME),
    cardAc: text(h.CARD_AC),
    creditDays: num(h.CR_DAYS),
    address1: text(h.ADD1),
    address2: text(h.ADD2),
    address3: text(h.ADD3),
    city: text(h.CITY),
    mobile: text(h.MOBILE),
    totals: {
      net: num(h.NET_AMT),
      discount: num(h.DISC_AMT),
      taxable: round(num(h.NET_AMT) - num(h.DISC_AMT), 2),
      tax: num(h.TAX_AMT),
      cgst: num(h.CGST_TAX),
      sgst: num(h.SGST_TAX),
      igst: num(h.IGST_TAX),
      roundOff: num(h.ROF_AMT),
      total: num(h.TOT_AMT),
    },
  };
}

/** A BAR_DETL tag row, read-only on the screen. */
export function purchaseTagView(row: Record<string, unknown>): Record<string, unknown> {
  return {
    srNo: num(row.SR_NO),
    itCode: text(row.IT_CODE),
    metal: text(row.IT_TYPE) === 'S' ? 'S' : 'G',
    tagNo: text(row.TAG_NO),
    vchSrno: num(row.VCH_SRNO),
    pcs: num(row.ITM_PCS),
    grossWt: num(row.ITM_GWT),
    netWt: num(row.ITM_NWT),
    touch: num(row.ITM_TOUCH),
    fineWt: num(row.ITM_FINE),
    rate: num(row.ITM_RATE),
    metalAmount: num(row.ITM_AMT),
    labourAmount: num(row.LBR_AMT),
    otherAmount: num(row.OTH_AMT),
    huid: text(row.HM_ID),
  };
}
