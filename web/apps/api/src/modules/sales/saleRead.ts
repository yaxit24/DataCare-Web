import { round, toIsoDate, type LabourType } from '@datacare/core';
import { legacyLabourModeFor } from '../shared/labourDesktop.js';
import { withTxBudget } from '../shared/txBudget.js';
import { voucherVersionTx, versionKeyOf } from '../vouchers/version.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { readSaleResidualsTx, stonesByLine } from './saleResiduals.js';
import { readOrderAdvanceNotesTx } from './orderAdvanceConfirm.js';
import { hasWebRoundOffLegTx } from '../shared/legacyRoundOff.js';
import { SALE_WRITE_TABLES, SaleValidationError, completeSaleScope, saleParams } from './sales.js';

/**
 * The saved Sales Invoice as the screen reopens it (TR_SALE `DISPLAY_DATA`, TR_SALE.cs:14226-14855). Moved out of
 * `sales.ts` by WP-26 (size budget) and extended with every column and child table the desktop reloads, so an
 * unchanged save can write the voucher back as it was.
 */
const num = (v: unknown): number => (v == null ? 0 : Number(v));
const text = (value: unknown): string => String(value ?? '').trim();
const round2s = (n: number): number => round(n, 2);

async function taxNameTx(tx: any, coCode: string, taxCode: string): Promise<string> {
  if (!taxCode) return '';
  const rows: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "TAX_NAME" AS n FROM "TAX_MAST" WHERE tenant_id=current_setting('app.tenant_id', true)
        AND "CO_CODE"=$1 AND "TAX_CODE"=$2 AND coalesce("SR_NO",0)=0 LIMIT 1`,
    coCode,
    taxCode,
  );
  return text(rows[0]?.n);
}

/** Open a persisted sale by voucher number using server-derived tenant scope only. */
export async function getSale(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeSaleScope(scope);
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    getSaleTx(tx, scope, requestedVoucherNo),
  );
}

/** The sale read inside a caller's transaction (also the linked old-gold read, linkedOldPurchaseSale.ts). */
export async function getSaleTx(
  tx: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeSaleScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const params = saleParams(scope, voucherNo);
  const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","BILL_NO","HD_VCH_NO","MAIN_USER",
              "AC_CODE","AC_NAME","NET_AMT","DISC_AMT","TAX_CODE","TAX_PRC","TAX_AMT",
              "AC_GST_TYPE","CGST_TAX","SGST_TAX","IGST_TAX","ROF_AMT","TOT_AMT",
              "RATE_UNFIX","CASH_AMT","CARD_AMT","UPI_AMT","CHQ_AMT","OLD_GL_AMT",
              "BILL_OS","HM_AMT","HM_TAX_AMT","TCS_PRC","TCS_AMT","KASAR_AMT",
              "CR_DAYS","EMP_CODE","VCH_DESC","DISC_PRC","TCS_CODE","TDS_CODE","TDS_PRC","TDS_AMT",
              "ADD1","ADD2","ADD3","CITY","MOBILE","BANK_AC","CARD_AC","CHQ_NO","BANK_NAME",
              "CARD_COM_AMT","CASH_PAID","CRNT_ADJ_AMT","SCHM_AC","SCHM_AMT","POINT_VAL",
              "ISU_NO","ISU_YRCD","ISU_DBCD","ORNA_ISU","OLD_SL_AMT","OLD_GL","OLD_SL","ADV_AMT",
              "CARD_ADJ","MEMB_COM_AC_CODE","WHOUT_COMM_BILL","DATA_TRFR","RE_TRFR","USER_UPDATE","USER_DELETE"
         FROM "SL_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
    ...params,
  );
  if (headers.length !== 1) {
    throw new SaleValidationError(
      headers.length
        ? `sale voucher is ambiguous: ${voucherNo}`
        : `sale voucher not found: ${voucherNo}`,
    );
  }
  const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "SR_NO","IT_CODE","IT_TYPE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT",
              "ITM_NWT","ITM_TOUCH","ITM_GHT_WT","ITM_WEST_PRC","ITM_FINE","ITM_RATE",
              "ITM_AMT","LBR_TYPE","LBR_PRC","LBR_RATE","LBR_AMT","OTH_AMT","NET_AMT",
              "DESIGN_NO","ITM_SIZE","ITM_OTH_WT","TBL_CODE","ITM_MRP","HM_ID",
              "ORD_NO","ORD_YRCD","ORD_DBCD","ORD_SRNO","ISU_NO","ISU_YRCD","ISU_DBCD","ISU_SRNO",
              "BAG_WT","TAG_GWT","TAG_NWT","ITM_GHT_PRC","ITM_STYLE","ITM_LOT","ITM_REMARK",
              "DISC_PRC","DISC_AMT","GHT_AMT","RATE_WITH","RATE_TYPE","TAG_COST","KR_NET_WT",
              "KR_TOUCH","KR_WEST_PRC","KR_FINE","KR_NAME","EMP_CODE","PR_CODE","ORD_TAG_STK_ADD",
              "DESIGN_IMG_ID","HM_ID2","HM_ID3","HM_ID4","HM_ID_WT","HM_ID2_WT","HM_ID3_WT","HM_ID4_WT"
         FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
    ...params,
  );
  const oldGold: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "SR_NO","IT_CODE","IT_TYPE","IT_DESC","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_TOUCH",
              "ITM_FINE","CON_PRC","CON_WT","ITM_RATE","ITM_RATE_TYPE","NET_AMT","PR_COST"
         FROM "SL_PR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
    ...params,
  );
  // WP-26: UPI, credit-note, order and stone rows the desktop reloads (TR_SALE.cs:14670-14812).
  const residual = await readSaleResidualsTx(tx, params);
  const stones = stonesByLine(
    residual.idtl,
    details.map((d) => ({ srNo: num(d.SR_NO), tagNo: text(d.TAG_NO), itCode: text(d.IT_CODE) })),
  );
  const h = headers[0]!;
  // Must agree with `desktopLabourTypeFor`. Reading 'N' as 'fixed' would corrupt the round trip now that
  // per-gram is correctly written as 'N'; 'G' and 'K' have no legacy mode and yield undefined rather than a
  // wrong one. `labourBasis` below carries the raw code so nothing is lost.
  const labourType = (value: unknown): LabourType | undefined =>
    legacyLabourModeFor(value) as LabourType | undefined;
  return {
    voucherNo: text(h.VCH_NO),
    hiddenVoucherNo: text(h.HD_VCH_NO),
    mainUser: text(h.MAIN_USER),
    vchDate: toIsoDate(h.VCH_DATE),
    billNo: text(h.BILL_NO),
    acCode: text(h.AC_CODE),
    acName: text(h.AC_NAME),
    taxCode: text(h.TAX_CODE),
    taxRatePct: num(h.TAX_PRC),
    interState: num(h.IGST_TAX) !== 0 || text(h.AC_GST_TYPE).toUpperCase() !== 'L',
    discountAmount: num(h.DISC_AMT),
    discountPct: num(h.DISC_PRC),
    rateUnfix: text(h.RATE_UNFIX).toUpperCase() === 'Y',
    cashAmt: num(h.CASH_AMT),
    cardAmt: num(h.CARD_AMT),
    upiAmt: num(h.UPI_AMT),
    chequeAmt: num(h.CHQ_AMT),
    hallmarkAmount: num(h.HM_AMT),
    hallmarkTaxAmount: num(h.HM_TAX_AMT),
    tcsPct: num(h.TCS_PRC),
    tcsAmount: num(h.TCS_AMT),
    tcsCode: text(h.TCS_CODE),
    tdsCode: text(h.TDS_CODE),
    tdsPct: num(h.TDS_PRC),
    tdsAmount: num(h.TDS_AMT),
    // A computed ROF_AMT of the old web (its '99' leg) is not a typed round-off (legacyRoundOff.ts).
    roundOffAmount: (await hasWebRoundOffLegTx(tx, params)) ? 0 : num(h.ROF_AMT),
    kasarAmount: num(h.KASAR_AMT),
    oldGoldAmount: num(h.OLD_GL_AMT),
    billOutstanding: num(h.BILL_OS),
    crDays: num(h.CR_DAYS),
    empCode: text(h.EMP_CODE),
    description: text(h.VCH_DESC),
    address1: text(h.ADD1),
    address2: text(h.ADD2),
    address3: text(h.ADD3),
    city: text(h.CITY),
    mobile: text(h.MOBILE),
    bankAc: text(h.BANK_AC),
    cardAc: text(h.CARD_AC),
    chequeNo: text(h.CHQ_NO),
    bankName: text(h.BANK_NAME),
    cardCommissionAmount: num(h.CARD_COM_AMT),
    cashPaid: num(h.CASH_PAID),
    currentAdjustmentAmount: num(h.CRNT_ADJ_AMT),
    schemeAc: text(h.SCHM_AC),
    schemeAmount: num(h.SCHM_AMT),
    pointValue: num(h.POINT_VAL),
    issueNo: text(h.ISU_NO),
    issueYear: text(h.ISU_YRCD),
    issueBook: text(h.ISU_DBCD),
    ornamentIssued: text(h.ORNA_ISU) !== 'N',
    orderRef: residual.orders[0]
      ? { ordNo: text(residual.orders[0].ordNo), adjustAmt: num(residual.orders[0].amount) }
      : null,
    orders: residual.orders,
    // Owner decision 3B: who confirmed another customer's or an over-open order advance, and when.
    orderAdvanceNotes: await readOrderAdvanceNotesTx(tx, params, residual.orders),
    upiRows: residual.upiRows,
    creditNotes: residual.creditNotes,
    advanceAmount: num(h.ADV_AMT),
    oldSilverAmount: num(h.OLD_SL_AMT),
    oldGoldWeight: num(h.OLD_GL),
    oldSilverWeight: num(h.OLD_SL),
    memberCommissionAc: text(h.MEMB_COM_AC_CODE),
    withoutCommissionBill: text(h.WHOUT_COMM_BILL) === 'Y',
    // TR_SALE.cs:14412-14417: transferred flag and the per-voucher edit/delete grant.
    dataTransfer: text(h.DATA_TRFR) === 'Y' || text(h.RE_TRFR) === 'Y',
    userUpdate: text(h.USER_UPDATE) === 'Y',
    userDelete: text(h.USER_DELETE) === 'Y',
    // TR_SALE.cs:14337: the tax name is the parent row's (SR_NO = 0).
    taxName: await taxNameTx(tx, scope.coCode, text(h.TAX_CODE)),
    totals: {
      net: num(h.NET_AMT),
      discount: num(h.DISC_AMT),
      taxable: round2s(num(h.NET_AMT) - num(h.DISC_AMT)),
      tax: num(h.TAX_AMT),
      cgst: num(h.CGST_TAX),
      sgst: num(h.SGST_TAX),
      igst: num(h.IGST_TAX),
      roundOff: num(h.ROF_AMT),
      total: num(h.TOT_AMT),
    },
    lines: details.map((row) => ({
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
      fineWt: num(row.ITM_FINE),
      rate: num(row.ITM_RATE),
      metalAmount: num(row.ITM_AMT),
      labourType: labourType(row.LBR_TYPE),
      labourPct: num(row.LBR_PRC),
      labourRate: num(row.LBR_RATE),
      labourFixed: text(row.LBR_TYPE) === 'N' ? num(row.LBR_AMT) : undefined,
      otherAmount: num(row.OTH_AMT),
      netAmount: num(row.NET_AMT),
      designNo: text(row.DESIGN_NO),
      itmSize: text(row.ITM_SIZE),
      lessWt: num(row.ITM_OTH_WT),
      tblCode: text(row.TBL_CODE),
      mrp: num(row.ITM_MRP),
      huid: text(row.HM_ID),
      ordNo: text(row.ORD_NO),
      ordYrcd: text(row.ORD_YRCD),
      ordDbcd: text(row.ORD_DBCD),
      ordSrno: num(row.ORD_SRNO),
      isuNo: text(row.ISU_NO),
      isuYrcd: text(row.ISU_YRCD),
      isuDbcd: text(row.ISU_DBCD),
      isuSrno: num(row.ISU_SRNO),
      bagWt: num(row.BAG_WT),
      tagGrossWt: num(row.TAG_GWT),
      tagNetWt: num(row.TAG_NWT),
      ghtPct: num(row.ITM_GHT_PRC),
      style: text(row.ITM_STYLE),
      itemLot: text(row.ITM_LOT),
      remark: text(row.ITM_REMARK),
      discountPct: num(row.DISC_PRC),
      discountAmount: num(row.DISC_AMT),
      ghatAmount: num(row.GHT_AMT),
      rateWith: text(row.RATE_WITH),
      rateType: text(row.RATE_TYPE),
      tagCost: num(row.TAG_COST),
      karigarNetWt: num(row.KR_NET_WT),
      karigarTouch: num(row.KR_TOUCH),
      karigarWestPct: num(row.KR_WEST_PRC),
      karigarFine: num(row.KR_FINE),
      karigarName: text(row.KR_NAME),
      employeeCode: text(row.EMP_CODE),
      prCode: text(row.PR_CODE),
      orderTagStockAdd: text(row.ORD_TAG_STK_ADD),
      designImageId: text(row.DESIGN_IMG_ID),
      hallmarkId2: text(row.HM_ID2),
      hallmarkId3: text(row.HM_ID3),
      hallmarkId4: text(row.HM_ID4),
      hallmarkIdWt: num(row.HM_ID_WT),
      hallmarkId2Wt: num(row.HM_ID2_WT),
      hallmarkId3Wt: num(row.HM_ID3_WT),
      hallmarkId4Wt: num(row.HM_ID4_WT),
      stones: stones.get(num(row.SR_NO)) ?? [],
    })),
    oldGold: oldGold.map((row) => ({
      metal: text(row.IT_TYPE) === 'G' ? 'G' : 'S',
      itType: text(row.IT_TYPE),
      prCost: num(row.PR_COST),
      itCode: text(row.IT_CODE),
      description: text(row.IT_DESC),
      pcs: num(row.ITM_PCS),
      grossWt: num(row.ITM_GWT),
      otherWt: num(row.ITM_OTH_WT),
      netWt: num(row.ITM_NWT),
      touch: num(row.ITM_TOUCH),
      fineWt: num(row.ITM_FINE),
      conversionPct: num(row.CON_PRC),
      conversionWt: num(row.CON_WT),
      rate: num(row.ITM_RATE),
      rateType: text(row.ITM_RATE_TYPE),
      amount: num(row.NET_AMT),
    })),
    version: await voucherVersionTx(tx, SALE_WRITE_TABLES, versionKeyOf(scope, voucherNo)),
  };
}
