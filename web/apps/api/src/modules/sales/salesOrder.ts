import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  assertBalanced,
  reverseVoucherTx,
  assertPeriodOpen,
  insertRowTx,
  type LedgerLine,
} from '../posting/posting.js';
import { billTotals } from '@datacare/core';
import { SaleValidationError } from './sales.js';
import { fineWt } from '../shared/fine.js';
import { buildOrderRojmel } from '../shared/rojmel.js';
import {
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';

/**
 * Sales order (TR_SALE_ORD.cs): a customer order placed for later fulfilment. It is NOT a sale —
 * no income is recognised. We record the order header in SL_ORD_DATA. If an advance is taken, that
 * IS a money movement, posted balanced: Dr CASH / Cr customer (advance liability). Order book 'SOR'.
 */

export interface SalesOrderInput {
  scope: VoucherScope;
  acCode: string;
  acName?: string;
  billNo?: string;
  netAmount?: number;
  lines?: SalesOrderLine[];
  taxRatePct: number;
  interState?: boolean;
  advanceAmount?: number;
  vchDate?: Date | string;
  cashAc?: string;
  mainUser?: string;
  // Desktop SL_ORD_DATA header fields (TR_SALE_ORD.cs:9120-9161).
  taxCode?: string; // MSG2_TOTAL[1,4] :9120
  upiAmount?: number; // MSG2_TOTAL[3,1] :9141
  bankAc?: string; // MSG2_TOTAL[4,4] :9149
  chequeNo?: string; // MSG2_TOTAL[4,2] :9150
  bankName?: string; // tBankName.Text  :9151
  cardAc?: string; // MSG2_TOTAL[5,4] :9148
  cardAdj?: string; // CardCommAdj     :9154
  oldGoldFine?: number; // MSG2_TOTAL[6,2]+[9,2] :9143
  oldGoldAmount?: number; // MSG2_TOTAL[6,3] :9136
  oldSilverFine?: number; // MSG2_TOTAL[7,2] :9144
  oldSilverAmount?: number; // MSG2_TOTAL[7,3] :9137
  schemeAmount?: number; // MSG2_TOTAL[8,3] :9142
  rateCutRate?: number; // MSG2_TOTAL[9,1] :9134
  rateCutFine?: number; // MSG2_TOTAL[9,2] :9135
  rateCutAmount?: number; // MSG2_TOTAL[9,3] :9126
  adjustGold?: number; // AdjGold      :9146
  adjustSilver?: number; // AdjSilver    :9147
  orderAdjustAmount?: number; // RecAdjAmt    :9145
  deliveryDate?: Date | string; // DEL_DATE     :9152
  functionDate?: Date | string; // FUN_DATE     :9153
  address1?: string; // tAdd1.Text   :9157
  address2?: string; // tAdd2.Text   :9158
  address3?: string; // tAdd3.Text   :9159
  city?: string; // tCity.Text   :9160
  mobile?: string; // tMobile.Text :9161
  empCode?: string; // tEmpCode.Text (detail) :9296
}

/** A sales-order line (weight-based, like a sale line). */
export interface SalesOrderLine {
  itCode: string;
  designNo?: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  rate?: number;
  making?: number; // per-gram making
  remark?: string;
  // Desktop SL_ORD_DETL grid columns (TR_SALE_ORD.cs `mSG[i, c]`).
  tblCode?: string; // mSG[i,3]  :9216
  itmColor?: string; // mSG[i,5]  :9218
  itmSize?: string; // mSG[i,6]  :9219
  bagWt?: number; // mSG[i,7]  :9220
  lessWt?: number; // mSG[i,10] :9223 (ITM_OTH_WT)
  ghtPct?: number; // mSG[i,12] :9225
  rateFix?: string; // mSG[i,17] :9237
  labourPct?: number; // mSG[i,20] :9230
  labourType?: string; // mSG[i,21] :9231
  labourRate?: number; // mSG[i,22] :9232
  otherAmount?: number; // mSG[i,24] :9234
  mrp?: number; // mSG[i,25] :9249
  orderDeliveryDate?: Date | string; // mSG[i,26] :9290
  karigarNetWt?: number; // mSG[i,32] :9254
  karigarTouch?: number; // mSG[i,35] :9255
  karigarWestPct?: number; // mSG[i,36] :9256
  karigarFine?: number; // mSG[i,37] :9257
  karigarName?: string; // mSG[i,30] :9258

  // ---- Stone / diamond sub-detail (SL_ORD_IDTL) -------------------------------------------------
  // TR_SALE_ORD.cs fills SL_ORD_IDTL from its `DtIdtl` grid, one row per stone under the item line.
  // Column indices are the DtIdtl ordinals the desktop reads (`DtIdtl.Rows[i][n]`).
  dmCode?: string; // DtIdtl[3]  -> DM_CODE
  dmName?: string; // DtIdtl[4]  -> DM_NAME
  dmSize?: string; // DtIdtl[5]  -> DM_SIZE
  dmSfNo?: string; // DtIdtl[6]  -> DM_SFNO
  dmColor?: string; // DM_COLOR
  dmOrigin?: string; // DM_ORIGIN
  dmRemark?: string; // DM_REMARK
  dmLeb?: string; // DM_LEB (certificate/lab)
  stonePcsWt?: number; // IT_PCS_WT
  stoneConPct?: number; // DtIdtl[9]  -> IT_CON_PRC
  stoneConWt?: number; // DtIdtl[16] -> IT_CON_WT
  stoneRateType?: string; // DtIdtl[10] -> IT_RATE_TYPE
  stoneRate?: number; // DtIdtl[11] -> IT_RATE
  stoneLabourRate?: number; // DtIdtl[13] -> IT_LBR_RATE
  stoneLabourAmount?: number; // DtIdtl[14] -> IT_LBR_AMT
  stoneKarigarWt?: number; // DtIdtl[17] -> KR_WT
  stoneKarigarLessPct?: number; // KR_LESS_PRC
  stoneKarigarConPct?: number; // KR_CON_PRC
  stoneKarigarConWt?: number; // KR_CON_WT
  stoneKarigarRate?: number; // KR_RATE
  stoneKarigarAmount?: number; // KR_AMT
  stoneKarigarLabourRate?: number; // KR_LBR_RATE
  stoneKarigarLabourAmount?: number; // KR_LBR_AMT
  stoneKarigarNetAmount?: number; // KR_NET_AMT
  tagCost?: number; // mSG[i,43] :9250
  vchSrno?: number; // mSG[i,42] :9262
  oldSrNo?: number; // mSG[i,47] :9205
  rateType?: string; // mSG[i,48] :9259
  itType?: string; // mSG[i,49] :9260
  prCode?: string; // mSG[i,51] :9261
  oldTblCode?: string; // mSG[i,69] :9266
  tagStockLess?: string; // mSG[i,70] :9267
  designImageId?: string; // mSG[i,71] :9297
  huid?: string; // mSG[i,72] :9298
  hallmarkId2?: string; // mSG[i,73] :9299
  hallmarkId3?: string; // mSG[i,74] :9300
  hallmarkId4?: string; // mSG[i,75] :9301
  hallmarkIdWt?: number; // mSG[i,76] :9302
  hallmarkId2Wt?: number; // mSG[i,77] :9303
  hallmarkId3Wt?: number; // mSG[i,78] :9304
  hallmarkId4Wt?: number; // mSG[i,79] :9305
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

function keyOf(s: VoucherScope, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'SOR',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

type OrderWriteContext = {
  tx: any;
  vchNo: number;
  hdVchNo: string;
  mainUser: string;
  persistedClock?: unknown;
};

export async function createSalesOrder(
  prisma: any,
  input: SalesOrderInput,
  lifecycle?: OrderWriteContext,
): Promise<{ vchNo: number; total: number; advance: number }> {
  if (!input.acCode) throw new SaleValidationError('customer account (acCode) is required');
  const N = (v: unknown): number => (v == null ? 0 : Number(v));
  /** Desktop grid cells persist as trimmed text bounded by the column width; blank ⇒ null. */
  const txt = (v: unknown, len: number): string | null =>
    String(v ?? '')
      .trim()
      .slice(0, len) || null;
  // Compute each line's net (fine = net×touch/100, metal = fine×rate, making = net×making/g) when lines given.
  const orderLines = input.lines ?? [];
  const computed = orderLines.map((l) => {
    const fine = fineWt(l.netWt, l.ghtWt, l.touch, l.westPct);
    const metal = round2(fine * N(l.rate));
    const making = round2(N(l.netWt) * N(l.making));
    return { in: l, fine, metal, making, net: round2(metal + making) };
  });
  const linesNet = round2(computed.reduce((s, c) => s + c.net, 0));
  const baseNet = linesNet > 0 ? linesNet : Number(input.netAmount || 0);
  if (!(baseNet > 0))
    throw new SaleValidationError('order amount (or line weights/rate) is required');
  const tenantId = input.scope.tenantId;
  const totals = billTotals({
    lineNetTotal: baseNet,
    taxRatePct: input.taxRatePct,
    interState: !!input.interState,
  });
  const adv = round2(Number(input.advanceAmount || 0));
  const cashAc = input.cashAc ?? 'CASH';

  const run = async (tx: any) => {
    const no = lifecycle?.vchNo ?? (await nextVoucherNoTx(tx, input.scope));
    const hdVchNo =
      lifecycle?.hdVchNo ??
      (await nextHiddenVoucherNoTx(tx, { ...input.scope, coBook: input.scope.coBook ?? 'SOR' }));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    const key = keyOf(input.scope, no);
    const vchDate = voucherTimestamp(
      input.vchDate ? new Date(input.vchDate) : new Date(),
      lifecycle?.persistedClock,
    );
    const header = {
      ...key,
      VCH_DATE: vchDate,
      BILL_NO: input.billNo ?? formatVoucherNo(no),
      AC_CODE: input.acCode,
      AC_NAME: input.acName ?? null,
      NET_AMT: totals.taxable,
      TAX_PRC: input.taxRatePct,
      TAX_AMT: totals.tax,
      TOT_AMT: totals.total,
      ADV_AMT: adv,
      VCH_TIME: vchDate,
      ENTRY_TIME: vchDate,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
      // Desktop SL_ORD_DATA columns (TR_SALE_ORD.cs:9120-9161): tax code, tender rows from the
      // settlement grid, old-metal and rate-cut adjustment, delivery/function dates and the party
      // address block. A blank desktop grid cell persists as ''/0.
      TAX_CODE: txt(input.taxCode, 2), // MSG2_TOTAL[1,4] :9120
      UPI_AMT: round2(N(input.upiAmount)), // MSG2_TOTAL[3,1] :9141
      BANK_AC: txt(input.bankAc, 9), // MSG2_TOTAL[4,4] :9149
      CHQ_NO: txt(input.chequeNo, 10), // MSG2_TOTAL[4,2] :9150
      BANK_NAME: txt(input.bankName, 50), // tBankName.Text  :9151
      CARD_AC: txt(input.cardAc, 9), // MSG2_TOTAL[5,4] :9148
      CARD_ADJ: txt(input.cardAdj, 1), // CardCommAdj     :9154
      OLD_GL: N(input.oldGoldFine), // [6,2]+[9,2]    :9143
      OLD_GL_AMT: round2(N(input.oldGoldAmount)), // MSG2_TOTAL[6,3] :9136
      OLD_SL: N(input.oldSilverFine), // MSG2_TOTAL[7,2] :9144
      OLD_SL_AMT: round2(N(input.oldSilverAmount)), // MSG2_TOTAL[7,3] :9137
      SCHM_AMT: round2(N(input.schemeAmount)), // MSG2_TOTAL[8,3] :9142
      RCUT_RATE: N(input.rateCutRate), // MSG2_TOTAL[9,1] :9134
      RCUT_FINE: N(input.rateCutFine), // MSG2_TOTAL[9,2] :9135
      RCUT_AMT: round2(N(input.rateCutAmount)), // MSG2_TOTAL[9,3] :9126
      ADJ_GOLD: N(input.adjustGold), // AdjGold  :9146
      ADJ_SILVER: N(input.adjustSilver), // AdjSilver:9147
      ORD_ADJ_AMT: round2(N(input.orderAdjustAmount)), // RecAdjAmt:9145
      DEL_DATE: input.deliveryDate ? new Date(input.deliveryDate) : null, // :9152
      FUN_DATE: input.functionDate ? new Date(input.functionDate) : null, // :9153
      ADD1: txt(input.address1, 50), // tAdd1.Text  :9157
      ADD2: txt(input.address2, 50), // tAdd2.Text  :9158
      ADD3: txt(input.address3, 50), // tAdd3.Text  :9159
      CITY: txt(input.city, 20), // tCity.Text  :9160
      MOBILE: txt(input.mobile, 21), // tMobile.Text:9161
    };
    const detl = computed.map((c, i) => ({
      ...key,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      IT_CODE: c.in.itCode,
      DESIGN_NO: c.in.designNo ?? null,
      ITM_PCS: N(c.in.pcs),
      ITM_GWT: N(c.in.grossWt),
      ITM_NWT: N(c.in.netWt),
      ITM_TOUCH: N(c.in.touch),
      ITM_FINE: c.fine,
      ITM_RATE: N(c.in.rate),
      ITM_AMT: c.metal,
      LBR_AMT: c.making,
      NET_AMT: c.net,
      TOT_AMT: c.net,
      ITM_REMARK: c.in.remark ?? null,
      VCH_TIME: vchDate,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
      TAG_SALE: 'N',
      TAG_GEN: 'N',
      DESIGN_ISU: 'N',
      // Desktop SL_ORD_DETL grid columns (TR_SALE_ORD.cs:9205-9306).
      TBL_CODE: txt(c.in.tblCode, 3), // mSG[i,3]  :9216
      ITM_COLOR: txt(c.in.itmColor, 15), // mSG[i,5]  :9218
      ITM_SIZE: txt(c.in.itmSize, 20), // mSG[i,6]  :9219
      BAG_WT: N(c.in.bagWt), // mSG[i,7]  :9220
      ITM_OTH_WT: N(c.in.lessWt), // mSG[i,10] :9223
      ITM_GHT_PRC: N(c.in.ghtPct), // mSG[i,12] :9225
      ITM_GHT_WT: N(c.in.ghtWt), // mSG[i,13] :9226
      ITM_WEST_PRC: N(c.in.westPct), // mSG[i,15] :9228
      RATE_FIX: txt(c.in.rateFix, 1), // mSG[i,17] :9237
      LBR_PRC: N(c.in.labourPct), // mSG[i,20] :9230
      LBR_TYPE: txt(c.in.labourType, 1), // mSG[i,21] :9231
      LBR_RATE: N(c.in.labourRate), // mSG[i,22] :9232
      OTH_AMT: round2(N(c.in.otherAmount)), // mSG[i,24] :9234
      ITM_MRP: N(c.in.mrp), // mSG[i,25] :9249
      ORD_DEL_DATE: c.in.orderDeliveryDate ? new Date(c.in.orderDeliveryDate) : null, // :9290
      KR_NET_WT: N(c.in.karigarNetWt), // mSG[i,32] :9254
      KR_TOUCH: N(c.in.karigarTouch), // mSG[i,35] :9255
      KR_WEST_PRC: N(c.in.karigarWestPct), // mSG[i,36] :9256
      KR_FINE: N(c.in.karigarFine), // mSG[i,37] :9257
      KR_NAME: txt(c.in.karigarName, 5), // mSG[i,30] :9258
      TAG_COST: N(c.in.tagCost), // mSG[i,43] :9250
      VCH_SRNO: N(c.in.vchSrno), // mSG[i,42] :9262
      OLD_SRNO: c.in.oldSrNo ?? i + 1, // mSG[i,47] :9205
      RATE_TYPE: txt(c.in.rateType, 1), // mSG[i,48] :9259
      IT_TYPE: txt(c.in.itType, 1), // mSG[i,49] :9260
      PR_CODE: txt(c.in.prCode, 2), // mSG[i,51] :9261
      OLD_TBL_CODE: txt(c.in.oldTblCode, 3), // mSG[i,69] :9266
      TAG_STK_LESS: txt(c.in.tagStockLess, 1), // mSG[i,70] :9267
      DESIGN_IMG_ID: txt(c.in.designImageId, 50), // mSG[i,71] :9297
      HM_ID: txt(c.in.huid, 10), // mSG[i,72] :9298
      HM_ID2: txt(c.in.hallmarkId2, 10), // mSG[i,73] :9299
      HM_ID3: txt(c.in.hallmarkId3, 10), // mSG[i,74] :9300
      HM_ID4: txt(c.in.hallmarkId4, 10), // mSG[i,75] :9301
      HM_ID_WT: N(c.in.hallmarkIdWt), // mSG[i,76] :9302
      HM_ID2_WT: N(c.in.hallmarkId2Wt), // mSG[i,77] :9303
      HM_ID3_WT: N(c.in.hallmarkId3Wt), // mSG[i,78] :9304
      HM_ID4_WT: N(c.in.hallmarkId4Wt), // mSG[i,79] :9305
      EMP_CODE: txt(input.empCode, 5), // tEmpCode.Text :9296
      TAG_NO: 'N', // literal       :9210
      ORD_REC_AMT: 0, // literal       :9306
    }));
    const idtl = computed.map((c, i) => ({
      ...key,
      SR_NO: i + 1,
      ISR_NO: 1,
      VCH_DATE: vchDate,
      IT_CODE: c.in.itCode,
      IT_PCS: N(c.in.pcs),
      IT_GWT: N(c.in.grossWt),
      IT_AMT: c.metal,
      IT_NET_AMT: c.net,
      // Stone / diamond identity — widths taken from the live schema (DM_NAME 50, DM_SIZE 20, DM_LEB 15).
      DM_CODE: text(c.in.dmCode).slice(0, 8) || null,
      DM_NAME: text(c.in.dmName).slice(0, 50) || null,
      DM_SIZE: text(c.in.dmSize).slice(0, 20) || null,
      DM_SFNO: text(c.in.dmSfNo).slice(0, 20) || null,
      DM_COLOR: text(c.in.dmColor).slice(0, 15) || null,
      DM_ORIGIN: text(c.in.dmOrigin).slice(0, 20) || null,
      DM_REMARK: text(c.in.dmRemark).slice(0, 20) || null,
      DM_LEB: text(c.in.dmLeb).slice(0, 15) || null,
      // Stone valuation
      IT_PCS_WT: N(c.in.stonePcsWt),
      IT_CON_PRC: N(c.in.stoneConPct),
      IT_CON_WT: N(c.in.stoneConWt),
      IT_RATE_TYPE: text(c.in.stoneRateType).slice(0, 1) || null,
      IT_RATE: N(c.in.stoneRate),
      IT_LBR_RATE: N(c.in.stoneLabourRate),
      IT_LBR_AMT: N(c.in.stoneLabourAmount),
      // Karigar side of the stone line
      KR_WT: N(c.in.stoneKarigarWt),
      KR_LESS_PRC: N(c.in.stoneKarigarLessPct),
      KR_CON_PRC: N(c.in.stoneKarigarConPct),
      KR_CON_WT: N(c.in.stoneKarigarConWt),
      KR_RATE: N(c.in.stoneKarigarRate),
      KR_AMT: N(c.in.stoneKarigarAmount),
      KR_LBR_RATE: N(c.in.stoneKarigarLabourRate),
      KR_LBR_AMT: N(c.in.stoneKarigarLabourAmount),
      KR_NET_AMT: N(c.in.stoneKarigarNetAmount),
      NEW_VCH_NO: null,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
    }));
    const ledger: LedgerLine[] =
      adv > 0
        ? [
            { ...key, VCH_TYPE: 'SORD', AC_CODE: cashAc, DR_AMT: adv, CR_AMT: 0, SIGN: 'D' },
            { ...key, VCH_TYPE: 'SORD', AC_CODE: input.acCode, DR_AMT: 0, CR_AMT: adv, SIGN: 'C' },
          ]
        : [];
    if (ledger.length) assertBalanced(ledger);

    // The Rojmel (day book). Book 020 carries 55 real rows across four types; the other four in
    // Ac_Rojmel.Order_Rojmel never fired here. Type 01 is the advance as a CREDIT with the book's slot-1
    // account as contra - verified: slot 1 on book 020 is 00001 and every real type-01 row has LD_CODE
    // 00001. Type 02 is a cheque, and note it names the BANK in AC_CODE with the party in LD_CODE, the
    // reverse of the advance row.
    //
    // NOT written, on evidence: type 03 card (CARD_AMT is 0 of 76 orders), type 07 rate-cut fine
    // (RCUT_FINE 0 of 76), type 08 UPI (UPI_DATA has 1 row company-wide), and type 05 scheme adjustment -
    // which is an unresolved ANOMALY: SCHM_AMT is non-zero on 7 of 76 orders yet there are ZERO type-05
    // rows. Emitting it would add rows the desktop does not have, which is harder to notice than a
    // missing row and equally a parity failure. See docs/PLAN-SALESORDER-ROJMEL.md section 2.4.
    //
    // The old-metal detail rows (types 04 and 06) come from SL_PR_DETL, which this function does not
    // currently write on an order - so they cannot fire yet. They are implemented in the shared builder
    // and will be exercised when an order accepts metal in part-exchange.
    const rojmelRows = buildOrderRojmel(
      {
        scope: {
          coCode: input.scope.coCode,
          lcCode: input.scope.lcCode,
          coYear: input.scope.coYear!,
        },
        key,
        coBook: key.CO_BOOK,
        vchNo: key.VCH_NO,
        vchDate,
        vchType: 'SORD',
        bookName: 'SALES ORDER',
        partyName: input.acName ?? '',
        partyCode: input.acCode,
      },
      {
        // Slot 1 is the book's advance contra. `cashAc` is what the ledger already debits for the
        // advance, which is the same account the desktop names in LD_CODE.
        advanceContraAc: cashAc,
        bankAc: cashAc,
        advanceAmount: adv,
        // An order's cheque tender is not modelled separately from the advance here, so type 02 stays
        // dormant rather than being fed a value it does not have.
        chequeAmount: 0,
      },
    );
    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_BOOK: input.scope.coBook ?? 'SOR',
      VCH_NO: hdVchNo,
      BOOK_NAME: 'SALES ORDER',
    });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [
        { table: 'SL_ORD_DATA', rows: [header] },
        ...(detl.length ? [{ table: 'SL_ORD_DETL', rows: detl }] : []),
        ...(idtl.length ? [{ table: 'SL_ORD_IDTL', rows: idtl }] : []),
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    return { vchNo: no, total: totals.total, advance: adv };
  };
  return lifecycle ? run(lifecycle.tx) : withTenant(prisma, tenantId, run);
}

type CompleteOrderScope = VoucherScope & { coYear: string; coBook: string };
const ORDER_WRITE_TABLES = [
  'SL_ORD_DATA',
  'SL_ORD_DETL',
  'SL_ORD_IDTL',
  'SL_PR_DETL',
  'SL_ORD_ADJ',
  'UPI_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
] as const;
const text = (v: unknown): string => String(v ?? '').trim();
const n = (v: unknown): number => Number(v ?? 0);
function completeOrderScope(scope: VoucherScope): asserts scope is CompleteOrderScope {
  if (!scope.coYear || !scope.coBook)
    throw new SaleValidationError('complete voucher scope (coYear and coBook) is required');
}
const orderParams = (scope: CompleteOrderScope, voucherNo: string): unknown[] => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];

export async function getSalesOrder(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeOrderScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const params = orderParams(scope, voucherNo);
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","BILL_NO","HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME","NET_AMT","TAX_PRC","TAX_AMT","TOT_AMT","ADV_AMT" FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...params,
    );
    if (h.length !== 1)
      throw new SaleValidationError(
        h.length
          ? `sales order voucher is ambiguous: ${voucherNo}`
          : `sales order voucher not found: ${voucherNo}`,
      );
    const d: any[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","DESIGN_NO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE","ITM_RATE","ITM_AMT","LBR_AMT","NET_AMT","ITM_REMARK","TAG_SALE","TAG_GEN","DESIGN_ISU" FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...params,
    );
    const x = h[0];
    return {
      voucherNo: text(x.VCH_NO),
      hiddenVoucherNo: text(x.HD_VCH_NO),
      mainUser: text(x.MAIN_USER),
      vchDate: text(x.VCH_DATE).slice(0, 10),
      billNo: text(x.BILL_NO),
      acCode: text(x.AC_CODE),
      acName: text(x.AC_NAME),
      netAmount: n(x.NET_AMT),
      taxRatePct: n(x.TAX_PRC),
      total: n(x.TOT_AMT),
      advanceAmount: n(x.ADV_AMT),
      lines: d.map((r) => ({
        srNo: n(r.SR_NO),
        itCode: text(r.IT_CODE),
        designNo: text(r.DESIGN_NO),
        pcs: n(r.ITM_PCS),
        grossWt: n(r.ITM_GWT),
        netWt: n(r.ITM_NWT),
        touch: n(r.ITM_TOUCH),
        rate: n(r.ITM_RATE),
        making: n(r.ITM_NWT) ? round2(n(r.LBR_AMT) / n(r.ITM_NWT)) : 0,
        remark: text(r.ITM_REMARK),
        consumed: [r.TAG_SALE, r.TAG_GEN, r.DESIGN_ISU].some((v) => text(v) === 'Y'),
      })),
    };
  });
}

async function assertOrderUnconsumedTx(
  tx: any,
  scope: CompleteOrderScope,
  voucherNo: string,
): Promise<void> {
  const blocked: any[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "SL_ORD_DETL" d WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 AND (coalesce(d."TAG_SALE",'N')='Y' OR coalesce(d."TAG_GEN",'N')='Y' OR coalesce(d."DESIGN_ISU",'N')='Y' OR EXISTS (SELECT 1 FROM "SL_ORD_ADJ" a WHERE a.tenant_id=d.tenant_id AND a."CO_CODE"=d."CO_CODE" AND a."ORD_NO"=d."VCH_NO")) LIMIT 1 FOR UPDATE OF d`,
    ...orderParams(scope, voucherNo),
  );
  if (blocked.length)
    throw new SaleValidationError(
      'sales order cannot be edited — it has already been issued, tagged, delivered, or adjusted',
    );
}

export async function editSalesOrder(
  prisma: any,
  input: SalesOrderInput,
  requestedVoucherNo: number | string,
): Promise<{ vchNo: number; total: number; advance: number }> {
  completeOrderScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const persisted = await persistedVoucherHeaderTx(tx, {
      table: 'SL_ORD_DATA',
      scope,
      voucherNo,
      extraColumns: [],
    });
    for (const date of [persisted.VCH_DATE, requestedDate])
      await assertPeriodOpen(tx, scope.tenantId, {
        ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
      });
    await assertOrderUnconsumedTx(tx, scope, voucherNo);
    const hd = formatVoucherNo(text(persisted.HD_VCH_NO));
    await deleteVoucherWriteSetTx(tx, {
      tables: ORDER_WRITE_TABLES,
      key: { scope, voucherNo },
      tempBook: { voucherNo: hd },
    });
    return createSalesOrder(prisma, input, {
      tx,
      vchNo: Number(voucherNo),
      hdVchNo: hd,
      mainUser: text(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
    });
  });
}

export async function listSalesOrders(
  prisma: any,
  scope: VoucherScope,
): Promise<Record<string, any>[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const yr = scope.coYear ? ' AND "CO_YEAR"::text=$2' : '';
    const params = scope.coYear ? [scope.coCode, scope.coYear] : [scope.coCode];
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO" AS "vchNo", "CO_BOOK" AS "book", "VCH_DATE" AS "vchDate", "AC_CODE" AS "acCode", "AC_NAME" AS "acName", coalesce(NULLIF("TOT_AMT"::text,'')::numeric,0) AS "total", coalesce(NULLIF("ADV_AMT"::text,'')::numeric,0) AS "advance", "DEL_DATE" AS "delDate" FROM "SL_ORD_DATA" WHERE "CO_CODE"=$1${yr} ORDER BY "VCH_DATE" DESC,"VCH_NO" DESC LIMIT 300`,
      ...params,
    );
    return rows.map((r) => ({
      ...r,
      vchNo: String(r.vchNo),
      total: Number(r.total),
      advance: Number(r.advance),
    }));
  });
}

export async function cancelSalesOrder(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
): Promise<{ cancelled: true }> {
  completeOrderScope(input.scope);
  const scope = input.scope;
  const tenantId = scope.tenantId;
  const voucherNo = formatVoucherNo(input.vchNo);
  const key = keyOf(scope, Number(voucherNo));
  return withTenant(prisma, tenantId, async (tx: any) => {
    const header = await persistedVoucherHeaderTx(tx, {
      table: 'SL_ORD_DATA',
      scope,
      voucherNo,
      extraColumns: [
        'AC_CODE',
        'AC_NAME',
        'ADV_AMT',
        'CASH_AMT',
        'CHQ_AMT',
        'CARD_AMT',
        'OLD_GL_AMT',
        'OLD_SL_AMT',
        'OLD_GL',
        'OLD_SL',
      ],
    });
    await assertPeriodOpen(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: header.VCH_DATE }] },
    });
    await assertOrderUnconsumedTx(tx, scope, voucherNo);
    const books: any[] = await tx.$queryRawUnsafe(
      `SELECT "BOOK_SNAME","BOOK_NAME" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 LIMIT 1`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
    );
    if (books.length !== 1)
      throw new SaleValidationError('sales order book configuration not found');
    await reverseVoucherTx(tx, tenantId, { tables: [...ORDER_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      text(header.HD_VCH_NO),
    );
    const now = new Date();
    const desc =
      `Cash/Bank/Card/Ogl/Osl-${n(header.CASH_AMT)}/${n(header.CHQ_AMT)}/${n(header.CARD_AMT)}/${n(header.OLD_GL_AMT)}/${n(header.OLD_SL_AMT)} OG :${n(header.OLD_GL)} OS :${n(header.OLD_SL)}`.slice(
        0,
        150,
      );
    await insertRowTx(tx, 'DELETE_DATA', tenantId, {
      ...key,
      SR_NO: 0,
      VCH_DATE: header.VCH_DATE,
      DELETE_DATE: now,
      VCH_TYPE: books[0].BOOK_SNAME,
      VCH_TIME: header.VCH_TIME,
      DELETE_TIME: now,
      BOOK_NAME: books[0].BOOK_NAME,
      AC_CODE: header.AC_CODE,
      AC_NAME: header.AC_NAME,
      VCH_VAL_DR: 0,
      VCH_VAL_CR: n(header.ADV_AMT),
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      HD_VCH_NO: header.HD_VCH_NO,
      MAIN_USER: header.MAIN_USER,
      DELETE_USER: input.deleteUser ?? 'system',
      VCH_DESC: desc,
    });
    return { cancelled: true };
  });
}

// ───────────────────────── F4 · SL_ORD_ADJ order-adjust helpers ─────────────────────────

/** Advance still available on an order to consume into a sale = ADV_AMT − Σ already-adjusted PAID_AMT. */
export async function orderAdvanceAvailableTx(
  tx: any,
  scope: VoucherScope,
  ordNo: number | string,
  ordBook = 'SOR',
): Promise<{ custAc: string; custName: string | null; advance: number; available: number }> {
  const ord: any = (
    await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" ac, "AC_NAME" nm, coalesce(NULLIF("ADV_AMT"::text,'')::numeric,0)::float adv FROM "SL_ORD_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1`,
      scope.coCode,
      ordBook,
      formatVoucherNo(ordNo),
    )
  )[0];
  if (!ord) throw new SaleValidationError(`sales order #${ordNo} not found`);
  const used: any = (
    await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(coalesce(NULLIF("PAID_AMT"::text,'')::numeric,0)),0)::float u FROM "SL_ORD_ADJ" WHERE "CO_CODE"=$1 AND "ORD_NO"=$2`,
      scope.coCode,
      formatVoucherNo(ordNo),
    )
  )[0];
  return {
    custAc: String(ord.ac),
    custName: ord.nm ?? null,
    advance: round2(Number(ord.adv)),
    available: round2(Number(ord.adv) - Number(used.u)),
  };
}

/** Write an SL_ORD_ADJ row consuming `adjustAmt` of an order's advance into a sale (within the sale's tx).
 *  No ledger here — the sale (createSale) reduces the customer Dr by adjustAmt (the advance is applied). */
export async function adjustOrderIntoSaleTx(
  tx: any,
  tenantId: string,
  scope: VoucherScope,
  args: {
    saleVchNo: string;
    ordNo: number | string;
    custAc: string;
    custName?: string | null;
    adjustAmt: number;
    vchDate: Date;
    /** ORD_HD_VCH_NO — the order's hidden book number, so the adjustment ties to the exact order row. */
    ordHiddenVchNo?: string | null;
    /** EMP_CODE — varchar(3); the salesperson credited with the order. */
    empCode?: string | null;
  },
): Promise<{ vchNo: number }> {
  const no = await nextVoucherNoTx(tx, { ...scope, coBook: 'ORA' });
  const key: VoucherKey = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear ?? '',
    CO_BOOK: 'ORA',
    VCH_NO: formatVoucherNo(no),
  };
  const row = {
    ...key,
    SR_NO: 1,
    VCH_DATE: args.vchDate,
    VCH_TYPE: 'SADJ',
    INOUT_TYPE: 'O',
    ENTRY_TYPE: 'A',
    BOOK_NAME: 'ORDER ADJUST',
    AC_CODE: args.custAc,
    AC_NAME: args.custName ?? null,
    ORD_NO: formatVoucherNo(args.ordNo),
    ORD_AC_CODE: args.custAc,
    ORD_SIGN: 'C',
    PAID_AMT: round2(args.adjustAmt),
    OLD_VCH_NO: scope.coBook,
    NEW_VCH_NO: args.saleVchNo,
    IT_DESC: `Advance adjusted into sale ${args.saleVchNo}`,
    // TR_SALE_HM.cs carries the full ORDER key on the adjustment so the advance can be traced back to the
    // exact order line: location, year and book alongside the order number, plus its hidden book number.
    ORD_LC: scope.lcCode,
    ORD_YRCD: scope.coYear ?? null,
    ORD_DBCD: scope.coBook ?? null,
    ORD_HD_VCH_NO: args.ordHiddenVchNo ?? null,
    // Metal advances are tracked separately from the money advance; a pure cash advance leaves both 0,
    // which is what the desktop writes.
    ORD_GOLD: 0,
    ORD_SILVER: 0,
    EMP_CODE: args.empCode ?? null,
  };
  await postVoucherTx(tx, tenantId, {
    ledger: { table: 'AC_DATA', lines: [] },
    writes: [{ table: 'SL_ORD_ADJ', rows: [row] }],
  });
  return { vchNo: no };
}

/**
 * Order Cancel with refund (desktop TR_SL_ORD_ADJ): refund the advance through an operator-chosen
 * account (PaiidAc, default CASH), writing SL_ORD_ADJ + a balanced refund — Dr customer (clear the
 * advance liability) / Cr PaiidAc (paidAmt) + Cr KASAR (kasarAmt kept as a cancellation write-off).
 * The order stays (audit); use cancelSalesOrder for the plain void. Book 'ORC'.
 */
export async function cancelSalesOrderAdjust(
  prisma: any,
  input: {
    scope: VoucherScope;
    vchNo: number | string;
    paidAc?: string;
    paidAmt?: number;
    kasarAmt?: number;
    itDesc?: string;
    kasarAc?: string;
    vchDate?: Date | string;
    mainUser?: string;
  },
  lifecycle?: OrderWriteContext,
): Promise<{ vchNo: number; refunded: number; kasar: number }> {
  const tenantId = input.scope.tenantId;
  const ordBook = input.scope.coBook ?? 'SOR';
  const run = async (tx: any) => {
    const ord: any = (
      await tx.$queryRawUnsafe(
        `SELECT "AC_CODE" ac, "AC_NAME" nm, coalesce(NULLIF("ADV_AMT"::text,'')::numeric,0)::float adv, coalesce(NULLIF("TOT_AMT"::text,'')::numeric,0)::float tot FROM "SL_ORD_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1`,
        input.scope.coCode,
        ordBook,
        formatVoucherNo(input.vchNo),
      )
    )[0];
    if (!ord) throw new SaleValidationError(`sales order #${input.vchNo} not found`);
    const custAc = String(ord.ac);
    const paidAmt = round2(input.paidAmt != null ? Number(input.paidAmt) : Number(ord.adv)); // default: refund full advance
    const kasar = round2(Number(input.kasarAmt || 0));
    const paidAc = input.paidAc ?? 'CASH';
    const kasarAc = input.kasarAc ?? 'KASAR';
    const no = lifecycle?.vchNo ?? (await nextVoucherNoTx(tx, { ...input.scope, coBook: 'ORC' }));
    const hdVchNo =
      lifecycle?.hdVchNo ?? (await nextHiddenVoucherNoTx(tx, { ...input.scope, coBook: 'ORC' }));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    const key: VoucherKey = {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_YEAR: input.scope.coYear ?? '',
      CO_BOOK: 'ORC',
      VCH_NO: formatVoucherNo(no),
    };
    const vchDate = voucherTimestamp(
      input.vchDate ? new Date(input.vchDate) : new Date(),
      lifecycle?.persistedClock,
    );
    const adjRow = {
      ...key,
      SR_NO: 1,
      VCH_DATE: vchDate,
      VCH_TYPE: 'SADJ',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'A',
      BOOK_NAME: 'ORDER CANCEL',
      AC_CODE: custAc,
      AC_NAME: ord.nm ?? null,
      ORD_NO: formatVoucherNo(input.vchNo),
      ORD_AC_CODE: custAc,
      ORD_SIGN: 'D',
      ORD_AMT: round2(Number(ord.tot)),
      PAID_AMT: paidAmt,
      PAID_AC: paidAc,
      KASAR_AMT: kasar,
      ORD_BAL_AMT: round2(Number(ord.tot) - paidAmt - kasar),
      IT_DESC: input.itDesc ?? 'Order Cancel',
      OLD_VCH_NO: formatVoucherNo(input.vchNo),
      VCH_TIME: vchDate,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
    };
    const ledger: LedgerLine[] = [];
    const drCust = round2(paidAmt + kasar);
    if (drCust > 0)
      ledger.push({
        ...key,
        VCH_TYPE: 'SADJ',
        AC_CODE: custAc,
        DR_AMT: drCust,
        CR_AMT: 0,
        SIGN: 'D',
      }); // clear advance liability
    if (paidAmt > 0)
      ledger.push({
        ...key,
        VCH_TYPE: 'SADJ',
        AC_CODE: paidAc,
        DR_AMT: 0,
        CR_AMT: paidAmt,
        SIGN: 'C',
      }); // refund out via chosen account
    if (kasar > 0)
      ledger.push({
        ...key,
        VCH_TYPE: 'SADJ',
        AC_CODE: kasarAc,
        DR_AMT: 0,
        CR_AMT: kasar,
        SIGN: 'C',
      }); // write-off kept
    if (ledger.length) assertBalanced(ledger);
    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_BOOK: 'ORC',
      VCH_NO: hdVchNo,
      BOOK_NAME: 'ORDER CANCEL',
    });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: 'ORDER CANCEL',
      writes: [{ table: 'SL_ORD_ADJ', rows: [adjRow] }],
    });
    return { vchNo: no, refunded: paidAmt, kasar };
  };
  return lifecycle ? run(lifecycle.tx) : withTenant(prisma, tenantId, run);
}

const ADJUST_WRITE_TABLES = [
  'SL_ORD_ADJ',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'APR_DETL',
  'BAR_DETL',
  'BAR_IDTL',
] as const;
function adjustScope(scope: VoucherScope): CompleteOrderScope {
  if (!scope.coYear) throw new SaleValidationError('complete voucher scope (coYear) is required');
  return { ...scope, coYear: scope.coYear, coBook: 'ORC' };
}
export async function getSalesOrderAdjustment(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  const sc = adjustScope(scope),
    voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const p = orderParams(sc, voucherNo);
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME","ORD_NO","PAID_AMT","PAID_AC","KASAR_AMT","IT_DESC" FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...p,
    );
    if (!r.length)
      throw new SaleValidationError(`order adjustment voucher not found: ${voucherNo}`);
    const x = r[0];
    return {
      voucherNo: text(x.VCH_NO),
      hiddenVoucherNo: text(x.HD_VCH_NO),
      mainUser: text(x.MAIN_USER),
      vchDate: text(x.VCH_DATE).slice(0, 10),
      orderVchNo: text(x.ORD_NO),
      paidAmt: n(x.PAID_AMT),
      paidAc: text(x.PAID_AC),
      kasarAmt: n(x.KASAR_AMT),
      itDesc: text(x.IT_DESC),
      acCode: text(x.AC_CODE),
      acName: text(x.AC_NAME),
    };
  });
}
export async function editSalesOrderAdjustment(
  prisma: any,
  input: {
    scope: VoucherScope;
    vchNo: number | string;
    paidAc?: string;
    paidAmt?: number;
    kasarAmt?: number;
    itDesc?: string;
    kasarAc?: string;
    vchDate?: Date | string;
    mainUser?: string;
  },
  requestedVoucherNo: number | string,
): Promise<{ vchNo: number; refunded: number; kasar: number }> {
  const sc = adjustScope(input.scope),
    voucherNo = formatVoucherNo(requestedVoucherNo),
    requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const persisted = await persistedVoucherHeaderTx(tx, {
      table: 'SL_ORD_ADJ',
      scope: sc,
      voucherNo,
      extraColumns: [],
    });
    for (const date of [persisted.VCH_DATE, requestedDate])
      await assertPeriodOpen(tx, sc.tenantId, {
        ledger: { table: 'AC_DATA', lines: [{ CO_CODE: sc.coCode, VCH_DATE: date }] },
      });
    const hd = formatVoucherNo(text(persisted.HD_VCH_NO));
    await deleteVoucherWriteSetTx(tx, {
      tables: ADJUST_WRITE_TABLES,
      key: { scope: sc, voucherNo },
      tempBook: { voucherNo: hd },
    });
    return cancelSalesOrderAdjust(prisma, input, {
      tx,
      vchNo: Number(voucherNo),
      hdVchNo: hd,
      mainUser: text(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
    });
  });
}
export async function deleteSalesOrderAdjustment(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string },
): Promise<{ reversed: true }> {
  const sc = adjustScope(input.scope),
    voucherNo = formatVoucherNo(input.vchNo),
    key = keyOf(sc, Number(voucherNo));
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const persisted = await persistedVoucherHeaderTx(tx, {
      table: 'SL_ORD_ADJ',
      scope: sc,
      voucherNo,
      extraColumns: [],
    });
    await assertPeriodOpen(tx, sc.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: sc.coCode, VCH_DATE: persisted.VCH_DATE }] },
    });
    await reverseVoucherTx(tx, sc.tenantId, { tables: [...ADJUST_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      sc.tenantId,
      sc.coCode,
      sc.lcCode,
      sc.coBook,
      text(persisted.HD_VCH_NO),
    );
    return { reversed: true };
  });
}
