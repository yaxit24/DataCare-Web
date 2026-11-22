import { toIsoDate } from '@datacare/core';
import { legacyLabourModeFor } from '../shared/labourDesktop.js';
import type { SaleLineInput } from './sales.js';

/**
 * A saved Sales Return read back as the input that saved it (WP-27, N242, G254; decision D12).
 *
 * The desktop reopens a voucher by loading its stored rows into the grid and saves it again by deleting and
 * rewriting them (TR_SALE_RTN.cs:12496-13463). The web edit does the same in one transaction, so a reopened return
 * saved unchanged must produce the same rows: every column the writer stores is mapped back to the input field it
 * came from. Blank text comes back as `undefined` so that a NULL stays NULL and '' stays ''. Two values are derived
 * instead of copied:
 *  - the item amount is re-priced from the stored rate and weights, as the desktop grid re-prices column 20 from
 *    column 19 (TR_SALE_RTN.cs:4955); only a line with no rate keeps its stored amount;
 *  - labour is read from `LBR_PRC` (percentage), else the desktop `LBR_TYPE` basis with `LBR_RATE`, else the stored
 *    `LBR_AMT` as a fixed charge.
 */
const text = (value: unknown): string => String(value ?? '').trim();
const optionalText = (value: unknown): string | undefined => text(value) || undefined;
const num = (value: unknown): number => (value == null ? 0 : Number(value));
const optionalNum = (value: unknown): number | undefined => (value == null ? undefined : Number(value));

export function savedReturnLine(row: Record<string, unknown>): SaleLineInput & Record<string, unknown> {
  const rate = num(row.ITM_RATE);
  const labourPct = num(row.LBR_PRC);
  const labourRate = num(row.LBR_RATE);
  const mode = legacyLabourModeFor(row.LBR_TYPE);
  const labour =
    labourPct !== 0
      ? { labourType: 'percentage' as const, labourPct }
      : mode && labourRate !== 0
        ? { labourType: mode, labourRate }
        : num(row.LBR_AMT) !== 0
          ? { labourType: 'fixed' as const, labourFixed: num(row.LBR_AMT) }
          : {};
  const tagNo = text(row.TAG_NO);
  return {
    srNo: num(row.SR_NO),
    vchSrno: num(row.VCH_SRNO),
    netAmount: num(row.NET_AMT),
    itCode: text(row.IT_CODE),
    tagNo: tagNo === 'N' ? '' : tagNo,
    pcs: num(row.ITM_PCS),
    grossWt: num(row.ITM_GWT),
    netWt: num(row.ITM_NWT),
    touch: num(row.ITM_TOUCH),
    westPct: num(row.ITM_WEST_PRC),
    otherWt: num(row.ITM_OTH_WT),
    ghtWt: num(row.ITM_GHT_WT),
    rate,
    ...(rate === 0 && num(row.ITM_AMT) !== 0 ? { metalAmount: num(row.ITM_AMT) } : {}),
    ...labour,
    otherAmount: num(row.OTH_AMT),
    designNo: optionalText(row.DESIGN_NO),
    itmSize: optionalText(row.ITM_SIZE),
    tblCode: optionalText(row.TBL_CODE),
    oldSrNo: num(row.OLD_SRNO),
    tagLabourPct: num(row.TAG_LBR_PRC),
    tagLabourRate: num(row.TAG_LBR_RATE),
    tagLabourAmount: num(row.TAG_LBR_AMT),
    tagOtherAmount: num(row.TAG_OTH_AMT),
    mrp: num(row.ITM_MRP),
    rateType: optionalText(row.RATE_TYPE),
    itType: optionalText(row.IT_TYPE),
    dataTransfer: optionalText(row.DATA_TRFR),
    karigarName: optionalText(row.KR_NAME),
    tagCost: num(row.TAG_COST),
    margin: num(row.ITM_MARGIN),
    prCode: optionalText(row.PR_CODE),
    tagSrNo: num(row.TAG_SRNO),
    tagType: optionalText(row.TAG_TYPE),
    huid: optionalText(row.HM_ID),
    hallmarkId2: optionalText(row.HM_ID2),
    hallmarkId3: optionalText(row.HM_ID3),
    hallmarkId4: optionalText(row.HM_ID4),
    hallmarkIdWt: optionalNum(row.HM_ID_WT),
    hallmarkId2Wt: optionalNum(row.HM_ID2_WT),
    hallmarkId3Wt: optionalNum(row.HM_ID3_WT),
    hallmarkId4Wt: optionalNum(row.HM_ID4_WT),
    ghtPct: optionalNum(row.ITM_GHT_PRC),
    itemLot: optionalText(row.ITM_LOT),
    remark: optionalText(row.ITM_REMARK),
    discountPct: optionalNum(row.DISC_PRC),
    employeeCode: optionalText(row.EMP_CODE),
    designImageId: optionalText(row.DESIGN_IMG_ID),
  };
}

/** The header half of the same round trip, named as `POST /sales-returns` takes it. */
export function savedReturnHeader(h: Record<string, unknown>): Record<string, unknown> {
  return {
    voucherNo: text(h.VCH_NO),
    hiddenVoucherNo: text(h.HD_VCH_NO),
    mainUser: text(h.MAIN_USER),
    vchDate: toIsoDate(h.VCH_DATE),
    billNo: optionalText(h.BILL_NO),
    acCode: text(h.AC_CODE),
    acName: optionalText(h.AC_NAME),
    origVchNo: optionalText(h.ISU_NO),
    origBook: optionalText(h.ISU_DBCD),
    empCode: optionalText(h.EMP_CODE),
    discountAmount: num(h.DISC_AMT),
    taxCode: optionalText(h.TAX_CODE),
    taxRatePct: num(h.TAX_PRC),
    interState: num(h.IGST_TAX) !== 0,
    cashAmt: num(h.CASH_AMT),
    chequeAmt: num(h.CHQ_AMT),
    cardAmt: num(h.CARD_AMT),
    upiAmt: num(h.UPI_AMT),
    kasar: num(h.KASAR_AMT),
    bankAc: optionalText(h.BANK_AC),
    totals: { net: num(h.NET_AMT), tax: num(h.TAX_AMT), total: num(h.TOT_AMT) },
  };
}
