import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  assertBalanced,
  reverseVoucherTx,
  assertPeriodOpen,
  insertRowTx,
  type LedgerLine,
} from '../posting/posting.js';
import { billTotals, fineFor } from '@datacare/core';
import { receiptLegs } from '../finance/tender.js';
import { SaleValidationError } from './sales.js';
import { resolveTaxPolicyTx, type ResolvedTaxPolicy } from '../shared/taxPolicy.js';
import {
  resolveBookAccountTx,
  BookPolicyValidationError,
  type BookPolicy,
} from '../shared/bookPolicy.js';
import { gstTaxRows } from '../shared/taxDataRows.js';

/** Numeric coercion for a persisted column: a blank or absent cell is 0, never NaN. */
const num = (v: unknown): number => {
  const parsed = Number(String(v ?? '').trim());
  return Number.isFinite(parsed) ? parsed : 0;
};
import {
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';

/**
 * Labour Invoice (desktop "Labour Invoice", TR_MFG_LBR / LBR_DATA): bill only the MAKING when the
 * customer supplied the gold (via a sales order). DUAL GST — metal value at metalTaxPct (3%) + labour
 * at labourTaxPct (5%) — two TAX_DATA rows. The customer's order-gold reduces the chargeable metal and
 * is recorded as a Cr-Gold fine leg. Writes LBR_DATA (+ LBR_ISU_DETL) + TAX_DATA + BILL_OS. Book 'LBR'.
 */
/**
 * A labour-invoice line.
 *
 * P7: extended from 6 fields to the desktop's `TR_SALE_LBR` MSG grid, which has 30 named columns
 * (Sr, TagNo, ItCode, ItName, Design, HuId, Pcs, GrWt, OthWt, NetWt, Ght%, GhtWt, Touch, West%,
 * Fine, Lbr%, LType, LbrRate, LbrAmt, OthAmt, NetAmt, Counter, KrCode, Mrp, KrOthWt, KrNwt,
 * KrTouch, KrWst%, KrFine, TagCost). Every field below maps to a real `LBR_ISU_DETL` column — that
 * table carries 113 columns and the writer previously populated ten, so the operator could record a
 * labour bill but none of the weight, touch, karigar or tag detail that the desktop captures.
 */
export interface LabourLine {
  itCode: string;
  /** ITM_REMARK. Kept as `desc` for the existing callers. */
  desc?: string;
  pcs?: number;
  netWt?: number;
  metalAmount?: number;
  labourAmount?: number;
  // --- identity and description ---
  tagNo?: string; // TAG_NO
  designNo?: string; // DESIGN_NO
  hallmarkId?: string; // HM_ID — alphanumeric HUID, so a string
  tblCode?: string; // TBL_CODE (desktop "Counter")
  itmSize?: string; // ITM_SIZE
  itemLot?: string; // ITM_LOT
  lotNo?: string; // LOT_NO
  itmColor?: string; // ITM_COLOR
  // --- weights ---
  grossWt?: number; // ITM_GWT
  otherWt?: number; // ITM_OTH_WT
  bagWt?: number; // BAG_WT
  ghtPct?: number; // ITM_GHT_PRC
  ghtWt?: number; // ITM_GHT_WT
  touch?: number; // ITM_TOUCH
  westPct?: number; // ITM_WEST_PRC
  /** ITM_FINE. Derived from the sale fine policy when absent. */
  fineWt?: number;
  // --- money ---
  rate?: number; // ITM_RATE
  labourPct?: number; // LBR_PRC
  labourType?: string; // LBR_TYPE
  labourRate?: number; // LBR_RATE
  otherAmount?: number; // OTH_AMT
  mrp?: number; // ITM_MRP
  tagCost?: number; // TAG_COST
  rateType?: string; // RATE_TYPE
  // --- karigar block ---
  karigarName?: string; // KR_NAME
  karigarOtherWt?: number; // KR_OTH_WT
  karigarNetWt?: number; // KR_NET_WT
  karigarTouch?: number; // KR_TOUCH
  karigarWestPct?: number; // KR_WEST_PRC
  karigarFine?: number; // KR_FINE
  karigarLbrRate?: number; // KR_LBR_RATE
  karigarLbrAmt?: number; // KR_LBR_AMT
  // --- provenance ---
  employeeCode?: string; // EMP_CODE
  prCode?: string; // PR_CODE
  lbrCode?: string; // LBR_CODE
}
/**
 * A labour-invoice RECEIVE line — the metal the customer hands over against the labour bill.
 *
 * P8: the desktop's `TR_SALE_LBR` has TWO item grids. `mSG` is the labour being billed (written to
 * `LBR_ISU_DETL`) and `mSG_PR` is the metal RECEIVED, written to `LBR_REC_DETL` — a 95-column table
 * the web never wrote at all. `mSG_PR` is referenced 268 times in the desktop form and has 32 named
 * columns (Sr, ItCode, ItName, Pcs, GrWt, NetWt, Touch, LTouch, Fine, GhtWt, Counter, Design, BagWt,
 * PsWt, OthWt, West%, HmFine, SlvFine, Sign, Rate, ItAmt, Lbr%, Ltype, LRate, LAmt, OthAmt, ORate,
 * OFine, Mrp, NetAmt, TotAmt, TaxPrc).
 *
 * Without it, a labour bill settled with metal had nowhere to record what came in: the whole receive
 * half of the workflow was missing, not merely shallow.
 */
export interface LabourReceiptLine {
  itCode: string;
  /** ITM_SIGN. '+' takes metal in, '-' gives it back; the desktop grid's "Sign" column. */
  sign?: '+' | '-';
  pcs?: number; // ITM_PCS
  grossWt?: number; // ITM_GWT
  netWt?: number; // ITM_NWT
  otherWt?: number; // ITM_OTH_WT   "OthWt"
  bagWt?: number; // BAG_WT
  ghtWt?: number; // ITM_GHT_WT
  touch?: number; // ITM_TOUCH
  westPct?: number; // ITM_WEST_PRC
  lessTouch?: number; // LESS_TOUCH   "LTouch"
  /** ITM_FINE. Derived from the shared purchase-old-gold policy when absent. */
  fineWt?: number;
  rate?: number; // ITM_RATE
  amount?: number; // ITM_AMT
  labourPct?: number; // LBR_PRC
  labourType?: string; // LBR_TYPE
  labourRate?: number; // LBR_RATE
  labourAmount?: number; // LBR_AMT
  otherAmount?: number; // OTH_AMT
  otherRate?: number; // ITM_OTH_RATE "ORate"
  otherFine?: number; // ITM_OTH_FINE "OFine"
  mrp?: number; // ITM_MRP
  netAmount?: number; // NET_AMT
  totalAmount?: number; // TOT_AMT
  taxPct?: number; // TAX_PRC
  tblCode?: string; // TBL_CODE     "Counter"
  designNo?: string; // DESIGN_NO
  remark?: string; // ITM_REMARK
  // DELIBERATELY ABSENT: the desktop mSG_PR grid also shows PsWt, HmFine and SlvFine, but
  // LBR_REC_DETL has no ITM_PCS_WT, HM_FINE or SLV_FINE column — verified against information_schema.
  // Declaring them here would create cells that silently discard what the operator types, which is
  // worse than not showing the column. They are display-only on the desktop, or derived elsewhere.
}

export interface LabourInvoiceInput {
  scope: VoucherScope;
  acCode: string;
  acName?: string;
  billNo?: string;
  vchDate?: Date | string;
  interState?: boolean;
  metalTaxPct?: number; // default 3 (GST on metal value)
  labourTaxPct?: number; // default 5 (GST on making/labour)
  salesAc?: string;
  labourAc?: string;
  taxAc?: string;
  roundAc?: string;
  orderGoldFine?: number; // fine (g) supplied via order — Cr Gold
  lines: LabourLine[];
  /**
   * P8: the desktop's mSG_PR grid — metal RECEIVED against this labour bill, written to
   * LBR_REC_DETL. Optional, because a labour bill settled in cash has no receive side.
   */
  receiveLines?: LabourReceiptLine[];
  // tender (money in now)
  cashAmt?: number;
  chequeAmt?: number;
  cardAmt?: number;
  upiAmt?: number;
  kasar?: number;
  cashAc?: string;
  bankAc?: string;
  kasarAc?: string;
  mainUser?: string;
  vchDesc?: string;
}
export interface LabourInvoiceResult {
  vchNo: number;
  metalTaxable: number;
  labourTaxable: number;
  metalTax: number;
  labourTax: number;
  total: number;
}

const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;

type LabourWriteContext = {
  tx: any;
  vchNo: number;
  hdVchNo: string;
  mainUser: string;
  persistedClock?: unknown;
};

/**
 * G115 / P0-04: the labour-income account comes from the book's BOOK_DETL slot SR_NO 6, exactly
 * as the desktop credits A.DR_LBR to B.AC_CODE where B.SR_NO = 6 (Ac_Ledr.cs:1203). We resolve it
 * through the kernel primitive (resolveBookAccountTx) — fail-closed on a missing/ambiguous row —
 * rather than inventing a literal 'LABOUR' account that only the provisioning seed carries. The
 * labour book is modelled MAIN_BOOK 'LABOUR WORK', direction 'O' (seedCompany), matching the slot.
 */
async function resolveLabourIncomeAc(tx: any, scope: VoucherScope): Promise<string> {
  const coBook = scope.coBook ?? 'LBR';
  const policy: BookPolicy = {
    coBook,
    vchType: 'LBRI',
    bookName: 'LABOUR WORK',
    mainBook: 'LABOUR WORK',
    inout: 'O',
  };
  try {
    return await resolveBookAccountTx(tx, { ...scope, coBook }, policy, 6);
  } catch (e) {
    if (e instanceof BookPolicyValidationError)
      throw new SaleValidationError(
        `labour book ${coBook} income account (BOOK_DETL SR_NO 6) is not configured: ${e.message}`,
      );
    throw e;
  }
}

export async function createLabourInvoice(
  prisma: any,
  input: LabourInvoiceInput,
  lifecycle?: LabourWriteContext,
): Promise<LabourInvoiceResult> {
  if (!input.acCode) throw new SaleValidationError('customer account (acCode) is required');
  const lines = (input.lines ?? []).filter((l) => l && l.itCode);
  if (!lines.length) throw new SaleValidationError('at least one labour line is required');
  const inter = !!input.interState;
  const metalPct = input.metalTaxPct ?? 3;
  const labourPct = input.labourTaxPct ?? 5;
  const salesAc = input.salesAc ?? 'SALES';
  // G115 / P0-04: the labour-income account is NOT a literal. The desktop (Ac_Ledr.cs:1203,
  // leg '01') credits A.DR_LBR to the book's BOOK_DETL slot SR_NO 6 (MAIN_BOOK 'LABOUR WORK'),
  // never a hard-coded 'LABOUR' account — which exists only in the provisioning seed and is
  // absent on a migrated company. We resolve it from the book inside the tx; an explicit
  // caller override still wins.
  const taxAc = input.taxAc ?? 'GST';
  const roundAc = input.roundAc ?? 'ROUNDOFF';
  const tenantId = input.scope.tenantId;

  const metalBase = r2(lines.reduce((s, l) => s + Number(l.metalAmount ?? 0), 0));
  const labourBase = r2(lines.reduce((s, l) => s + Number(l.labourAmount ?? 0), 0));
  if (metalBase <= 0 && labourBase <= 0)
    throw new SaleValidationError('labour or metal amount is required');
  const metalT = billTotals({ lineNetTotal: metalBase, taxRatePct: metalPct, interState: inter });
  const labourT = billTotals({
    lineNetTotal: labourBase,
    taxRatePct: labourPct,
    interState: inter,
  });
  const grand = r2(metalT.total + labourT.total);
  const tax = r2(metalT.tax + labourT.tax);
  const roundOff = r2(metalT.roundOff + labourT.roundOff);

  const run = async (tx: any): Promise<LabourInvoiceResult> => {
    const no =
      lifecycle?.vchNo ??
      (await nextVoucherNoTx(tx, { ...input.scope, coBook: input.scope.coBook ?? 'LBR' }));
    const hdVchNo =
      lifecycle?.hdVchNo ??
      (await nextHiddenVoucherNoTx(tx, { ...input.scope, coBook: input.scope.coBook ?? 'LBR' }));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    // G115 / P0-04: resolve the labour-income account from the book's BOOK_DETL slot SR_NO 6
    // (desktop Ac_Ledr.cs:1203 join on B.SR_NO = 6), honouring an explicit caller override.
    const labourAc = input.labourAc ?? (await resolveLabourIncomeAc(tx, input.scope));
    // G92: the metal and labour tax codes, resolved like every other family (Ac_Tax.cs LbrWork_GST :164-174 joins
    // TAX_MAST on LBR_DATA.TAX_CODE and LBR_TAX_CODE). Geography comes from the party's AC_GST_TYPE.
    const policyFor = async (base: number, pct: number): Promise<ResolvedTaxPolicy | null> => {
      if (base <= 0) return null;
      const policy = await resolveTaxPolicyTx(tx, input.scope, {
        acCode: input.acCode,
        taxPct: pct,
      });
      if (policy.interState !== inter)
        throw new SaleValidationError('interState does not match the persisted customer GST type');
      return policy;
    };
    const metalPolicy = await policyFor(metalBase, metalPct);
    const labourPolicy = await policyFor(labourBase, labourPct);
    const key = {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_YEAR: input.scope.coYear ?? '',
      CO_BOOK: input.scope.coBook ?? 'LBR',
      VCH_NO: formatVoucherNo(no),
    };
    const vchDate = voucherTimestamp(
      input.vchDate ? new Date(input.vchDate) : new Date(),
      lifecycle?.persistedClock,
    );
    const base = { ...key, VCH_TYPE: 'LBRI' };

    // Ledger: Dr customer (grand) / Cr metal-sale + Cr labour + Cr GST(metal+labour) + Cr/Dr round-off.
    const ledger: LedgerLine[] = [
      { ...base, AC_CODE: input.acCode, DR_AMT: grand, CR_AMT: 0, SIGN: 'D' },
    ];
    if (metalT.taxable !== 0)
      ledger.push({ ...base, AC_CODE: salesAc, DR_AMT: 0, CR_AMT: metalT.taxable, SIGN: 'C' });
    if (labourT.taxable !== 0)
      ledger.push({ ...base, AC_CODE: labourAc, DR_AMT: 0, CR_AMT: labourT.taxable, SIGN: 'C' });
    if (tax !== 0) ledger.push({ ...base, AC_CODE: taxAc, DR_AMT: 0, CR_AMT: tax, SIGN: 'C' });
    if (roundOff !== 0)
      ledger.push({ ...base, AC_CODE: roundAc, DR_AMT: 0, CR_AMT: roundOff, SIGN: 'C' });
    assertBalanced(ledger);

    // Order-gold supplied by the customer → Cr Gold fine leg (metal reduces; no money).
    const orderGoldFine = r2(Number(input.orderGoldFine ?? 0));
    if (orderGoldFine > 0)
      ledger.push({
        ...base,
        AC_CODE: input.acCode,
        IT_TYPE: 'G',
        SIGN: '+',
        FINE_WT: orderGoldFine,
        DR_AMT: 0,
        CR_AMT: 0,
      });

    // Settlement (money in now).
    const tender = receiptLegs(base, {
      partyAc: input.acCode,
      cashAmt: input.cashAmt,
      chequeAmt: input.chequeAmt,
      cardAmt: input.cardAmt,
      upiAmt: input.upiAmt,
      kasar: input.kasar,
      cashAc: input.cashAc,
      bankAc: input.bankAc,
      kasarAc: input.kasarAc,
    });
    ledger.push(...tender.legs);
    const billOS = r2(grand - tender.paidNow - tender.kasar);

    const header = {
      ...key,
      VCH_TYPE: 'LBRI',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'O',
      BOOK_NAME: 'LABOUR',
      BILL_NO: input.billNo ?? formatVoucherNo(no),
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      SL_NET_AMT: metalT.taxable,
      TAX_CODE: metalPolicy?.taxCode || null,
      TAX_AMT: metalT.tax,
      TAX_PRC: metalPct,
      LBR_DR_AMT: labourT.taxable,
      LBR_TAX_CODE: labourPolicy?.taxCode || null,
      LBR_TAX_AMT: labourT.tax,
      LBR_TAX_PRC: labourPct,
      TOT_DR_AMT: grand,
      CR_FINE: orderGoldFine,
      ORD_FINE: orderGoldFine,
      SL_CASH_AMT: tender.cashAmt,
      SL_CHQ_AMT: r2(Number(input.chequeAmt || 0)),
      SL_CARD_AMT: r2(Number(input.cardAmt || 0)),
      SL_KASAR_AMT: tender.kasar,
      SL_BILL_OS: billOS,
      VCH_TIME: vchDate,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
      VCH_DESC: input.vchDesc ?? null,
    };
    const detl = lines.map((l, i) => ({
      ...key,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: 'LBRI',
      BOOK_NAME: 'LABOUR',
      IT_CODE: l.itCode,
      ITM_REMARK: l.desc ?? null,
      ITM_PCS: Number(l.pcs ?? 0),
      ITM_NWT: Number(l.netWt ?? 0),
      ITM_AMT: r2(Number(l.metalAmount ?? 0)),
      LBR_AMT: r2(Number(l.labourAmount ?? 0)),
      NET_AMT: r2(Number(l.metalAmount ?? 0) + Number(l.labourAmount ?? 0)),
      VCH_TIME: vchDate,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
      // P7: the desktop TR_SALE_LBR MSG grid, persisted. Text columns default to null rather than ''
      // so an untouched cell is absent, and numerics go through num() so a blank is 0 rather than NaN.
      TAG_NO: text(l.tagNo) || 'N',
      DESIGN_NO: text(l.designNo) || null,
      // HM_ID is the alphanumeric HUID; coercing it to a number would destroy any id with a letter.
      HM_ID: text(l.hallmarkId).slice(0, 15) || null,
      TBL_CODE: text(l.tblCode).slice(0, 3) || null,
      ITM_SIZE: text(l.itmSize).slice(0, 20) || null,
      ITM_LOT: text(l.itemLot) || null,
      LOT_NO: text(l.lotNo) || null,
      ITM_COLOR: text(l.itmColor) || null,
      ITM_GWT: num(l.grossWt),
      ITM_OTH_WT: num(l.otherWt),
      BAG_WT: num(l.bagWt),
      ITM_GHT_PRC: num(l.ghtPct),
      ITM_GHT_WT: num(l.ghtWt),
      ITM_TOUCH: num(l.touch),
      ITM_WEST_PRC: num(l.westPct),
      // Fine follows the shared desktop policy rather than a local formula, so a labour bill agrees
      // with every other voucher family: (net + ghat) x (touch + wastage) / 100.
      ITM_FINE:
        l.fineWt != null
          ? num(l.fineWt)
          : fineFor('sale', {
              netWt: num(l.netWt),
              ghtWt: num(l.ghtWt),
              touch: num(l.touch),
              westPct: num(l.westPct),
            }),
      ITM_RATE: num(l.rate),
      LBR_PRC: num(l.labourPct),
      LBR_TYPE: text(l.labourType) || null,
      LBR_RATE: num(l.labourRate),
      OTH_AMT: num(l.otherAmount),
      ITM_MRP: num(l.mrp),
      TAG_COST: num(l.tagCost),
      RATE_TYPE: text(l.rateType) || null,
      KR_NAME: text(l.karigarName) || null,
      KR_OTH_WT: num(l.karigarOtherWt),
      KR_NET_WT: num(l.karigarNetWt),
      KR_TOUCH: num(l.karigarTouch),
      KR_WEST_PRC: num(l.karigarWestPct),
      KR_FINE: num(l.karigarFine),
      KR_LBR_RATE: num(l.karigarLbrRate),
      KR_LBR_AMT: num(l.karigarLbrAmt),
      EMP_CODE: text(l.employeeCode) || null,
      PR_CODE: text(l.prCode) || null,
      LBR_CODE: text(l.lbrCode) || null,
    }));
    // P8: the receive side. Rows are written only when the operator supplied them, so an unchanged
    // cash-settled bill keeps its existing footprint and the write-set assertions stay meaningful.
    const recDetl = (input.receiveLines ?? [])
      .filter((l) => text(l.itCode))
      .map((l, i) => ({
        ...key,
        SR_NO: i + 1,
        VCH_DATE: vchDate,
        VCH_TYPE: 'LBRI',
        BOOK_NAME: 'LABOUR',
        AC_CODE: input.acCode,
        IT_CODE: text(l.itCode),
        // '+' takes metal in. Defaulting to '+' matches the grid: a receive line exists because
        // something came in, and a return is the explicit exception.
        ITM_SIGN: l.sign === '-' ? '-' : '+',
        ITM_PCS: num(l.pcs),
        ITM_GWT: num(l.grossWt),
        ITM_NWT: num(l.netWt),
        ITM_OTH_WT: num(l.otherWt),
        BAG_WT: num(l.bagWt),
        ITM_GHT_WT: num(l.ghtWt),
        ITM_TOUCH: num(l.touch),
        ITM_WEST_PRC: num(l.westPct),
        LESS_TOUCH: num(l.lessTouch),
        // Old metal coming in follows the desktop's OLD-GOLD fine policy, which subtracts less-touch
        // from (touch + wastage) — TR_PURC.cs:7310-7317, shared via fineFor so this agrees with the
        // purchase screen instead of inventing a second formula.
        ITM_FINE:
          l.fineWt != null
            ? num(l.fineWt)
            : fineFor('purchaseOldGold', {
                netWt: num(l.netWt),
                ghtWt: num(l.ghtWt),
                touch: num(l.touch),
                westPct: num(l.westPct),
                lesTouch: num(l.lessTouch),
              }),
        ITM_RATE: num(l.rate),
        ITM_AMT: num(l.amount),
        ITM_OTH_RATE: num(l.otherRate),
        ITM_OTH_FINE: num(l.otherFine),
        LBR_PRC: num(l.labourPct),
        LBR_TYPE: text(l.labourType).slice(0, 1) || null,
        LBR_RATE: num(l.labourRate),
        LBR_AMT: num(l.labourAmount),
        OTH_AMT: num(l.otherAmount),
        ITM_MRP: num(l.mrp),
        NET_AMT: num(l.netAmount),
        TOT_AMT: num(l.totalAmount),
        TAX_PRC: num(l.taxPct),
        TBL_CODE: text(l.tblCode).slice(0, 3) || null,
        DESIGN_NO: text(l.designNo) || null,
        ITM_REMARK: text(l.remark) || null,
        VCH_TIME: vchDate,
        HD_VCH_NO: hdVchNo,
        MAIN_USER: mainUser,
      }));

    // TAX_DATA from each code's component rows (LbrWork_GST :164-174): metal at SR_NO 1/2 (3 inter-state) on
    // SL_NET_AMT, labour at 10/20 (30) on DR_LBR; each half TAX_AMT/2; TOT_AMT = net + tax (no round-off). The
    // desktop join writes nothing for a code without component rows, so a code-less 0% part writes no row.
    const taxBase = {
      ...key,
      TRAN_TYPE: 'S',
      BOOK_NAME: 'LABOUR',
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      PARTY_NAME: input.acName ?? null,
      TAX_SIGN: '+',
    };
    const rowsFor = (
      policy: ResolvedTaxPolicy | null,
      t: typeof metalT,
      pct: number,
      srNos?: readonly [number, number, number],
    ) =>
      policy?.taxCode && (policy.components.size > 0 || t.tax !== 0)
        ? gstTaxRows(
            {
              ...taxBase,
              TAX_CODE: policy.taxCode,
              NET_AMT: t.taxable,
              DISC_AMT: 0,
              TOT_AMT: r2(t.taxable + t.tax),
            },
            policy,
            { interState: inter, ratePct: pct, igst: t.igst, sgst: t.sgst, cgst: t.cgst },
            srNos,
          )
        : [];
    const taxRows = [
      ...rowsFor(metalPolicy, metalT, metalPct),
      ...rowsFor(labourPolicy, labourT, labourPct, [10, 20, 30]),
    ];
    const osRow = {
      ...key,
      VCH_TYPE: 'LBRI',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'O',
      BOOK_NAME: 'LABOUR',
      SR_NO: 1,
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      BILL_AMT: grand,
      REC_AMT: tender.paidNow,
      KASAR_AMT: tender.kasar,
    };

    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_BOOK: input.scope.coBook ?? 'LBR',
      VCH_NO: hdVchNo,
      BOOK_NAME: 'LABOUR',
    });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: 'LABOUR',
      writes: [
        { table: 'LBR_DATA', rows: [header] },
        { table: 'LBR_ISU_DETL', rows: detl },
        ...(recDetl.length ? [{ table: 'LBR_REC_DETL', rows: recDetl }] : []),
        ...(taxRows.length ? [{ table: 'TAX_DATA', rows: taxRows }] : []),
        { table: 'BILL_OS_DATA', rows: [osRow] },
      ],
    });
    return {
      vchNo: no,
      metalTaxable: metalT.taxable,
      labourTaxable: labourT.taxable,
      metalTax: metalT.tax,
      labourTax: labourT.tax,
      total: grand,
    };
  };
  return lifecycle ? run(lifecycle.tx) : withTxBudget(prisma, tenantId, 'voucher', run);
}

type CompleteLabourScope = VoucherScope & { coYear: string; coBook: string };
const LABOUR_WRITE_TABLES = [
  'LBR_DATA',
  'LBR_ISU_DETL',
  'LBR_REC_DETL',
  'LBR_ISU_IDTL',
  'SL_ORD_ADJ',
  'BILL_OS_DATA',
  'UPI_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'TAX_DATA',
  'DM_DATA',
  'REMARK_DATA',
] as const;
const text = (v: unknown): string => String(v ?? '').trim();
const number = (v: unknown): number => Number(v ?? 0);
function completeLabourScope(scope: VoucherScope): asserts scope is CompleteLabourScope {
  if (!scope.coYear || !scope.coBook)
    throw new SaleValidationError('complete voucher scope (coYear and coBook) is required');
}
const labourParams = (s: CompleteLabourScope, v: string): unknown[] => [
  s.tenantId,
  s.coCode,
  s.lcCode,
  s.coYear,
  s.coBook,
  v,
];
export async function getLabourInvoice(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeLabourScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const p = labourParams(scope, voucherNo);
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT a."VCH_NO",a."VCH_DATE"::text,a."VCH_TIME",a."BILL_NO",a."HD_VCH_NO",a."MAIN_USER",a."AC_CODE",m."AC_NAME",a."SL_NET_AMT",a."TAX_PRC",a."LBR_DR_AMT",a."LBR_TAX_PRC",a."TOT_DR_AMT",a."CR_FINE",a."SL_CASH_AMT",a."SL_CHQ_AMT",a."SL_CARD_AMT",a."UPI_AMT",a."SL_KASAR_AMT",a."VCH_DESC" FROM "LBR_DATA" a LEFT JOIN "AC_MAST" m ON m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE" AND m."AC_CODE"=a."AC_CODE" WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6`,
      ...p,
    );
    if (h.length !== 1)
      throw new SaleValidationError(
        h.length
          ? `labour voucher is ambiguous: ${voucherNo}`
          : `labour voucher not found: ${voucherNo}`,
      );
    const d: any[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","ITM_REMARK","ITM_PCS","ITM_NWT","ITM_AMT","LBR_AMT" FROM "LBR_ISU_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...p,
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
      metalTaxPct: number(x.TAX_PRC),
      labourTaxPct: number(x.LBR_TAX_PRC),
      orderGoldFine: number(x.CR_FINE),
      cashAmt: number(x.SL_CASH_AMT),
      chequeAmt: number(x.SL_CHQ_AMT),
      cardAmt: number(x.SL_CARD_AMT),
      upiAmt: number(x.UPI_AMT),
      kasar: number(x.SL_KASAR_AMT),
      vchDesc: text(x.VCH_DESC),
      total: number(x.TOT_DR_AMT),
      lines: d.map((r) => ({
        srNo: number(r.SR_NO),
        itCode: text(r.IT_CODE),
        desc: text(r.ITM_REMARK),
        pcs: number(r.ITM_PCS),
        netWt: number(r.ITM_NWT),
        metalAmount: number(r.ITM_AMT),
        labourAmount: number(r.LBR_AMT),
      })),
    };
  });
}
export async function editLabourInvoice(
  prisma: any,
  input: LabourInvoiceInput,
  requestedVoucherNo: number | string,
): Promise<LabourInvoiceResult> {
  completeLabourScope(input.scope);
  const scope = input.scope,
    voucherNo = formatVoucherNo(requestedVoucherNo),
    requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const persisted = await persistedVoucherHeaderTx(tx, {
      table: 'LBR_DATA',
      scope,
      voucherNo,
      extraColumns: [],
    });
    for (const date of [persisted.VCH_DATE, requestedDate])
      await assertPeriodOpen(tx, scope.tenantId, {
        ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
      });
    const hd = formatVoucherNo(text(persisted.HD_VCH_NO));
    await deleteVoucherWriteSetTx(tx, {
      tables: LABOUR_WRITE_TABLES,
      key: { scope, voucherNo },
      tempBook: { voucherNo: hd },
    });
    return createLabourInvoice(prisma, input, {
      tx,
      vchNo: Number(voucherNo),
      hdVchNo: hd,
      mainUser: text(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
    });
  });
}
export async function deleteLabourInvoice(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
): Promise<{ reversed: true }> {
  completeLabourScope(input.scope);
  const scope = input.scope,
    tenantId = scope.tenantId,
    voucherNo = formatVoucherNo(input.vchNo),
    key = {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_YEAR: scope.coYear,
      CO_BOOK: scope.coBook,
      VCH_NO: voucherNo,
    };
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const h = await persistedVoucherHeaderTx(tx, {
      table: 'LBR_DATA',
      scope,
      voucherNo,
      extraColumns: [
        'AC_CODE',
        'TOT_DR_AMT',
        'SL_CASH_AMT',
        'SL_CARD_AMT',
        'SL_CHQ_AMT',
        'DR_WT',
        'CR_WT',
        'VCH_DESC',
      ],
    });
    await assertPeriodOpen(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: h.VCH_DATE }] },
    });
    const cfg: any[] = await tx.$queryRawUnsafe(
      `SELECT b."BOOK_SNAME",b."BOOK_NAME",a."AC_NAME" FROM "BOOK_DATA" b LEFT JOIN "AC_MAST" a ON a.tenant_id=b.tenant_id AND a."CO_CODE"=b."CO_CODE" AND a."AC_CODE"=$5 WHERE b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3 AND b."CO_BOOK"=$4 LIMIT 1`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      h.AC_CODE,
    );
    if (cfg.length !== 1) throw new SaleValidationError('labour book configuration not found');
    await reverseVoucherTx(tx, tenantId, { tables: [...LABOUR_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      text(h.HD_VCH_NO),
    );
    const now = new Date();
    await insertRowTx(tx, 'DELETE_DATA', tenantId, {
      ...key,
      SR_NO: 0,
      VCH_DATE: h.VCH_DATE,
      DELETE_DATE: now,
      VCH_TYPE: cfg[0].BOOK_SNAME,
      VCH_TIME: h.VCH_TIME,
      DELETE_TIME: now,
      BOOK_NAME: cfg[0].BOOK_NAME,
      AC_CODE: h.AC_CODE,
      AC_NAME: cfg[0].AC_NAME,
      VCH_VAL_DR: number(h.TOT_DR_AMT),
      VCH_VAL_CR: r2(number(h.SL_CASH_AMT) + number(h.SL_CARD_AMT) + number(h.SL_CHQ_AMT)),
      FINE_TYPE: 'A',
      VCH_FINE_DR: number(h.DR_WT),
      VCH_FINE_CR: number(h.CR_WT),
      HD_VCH_NO: h.HD_VCH_NO,
      MAIN_USER: h.MAIN_USER,
      DELETE_USER: input.deleteUser ?? 'system',
      VCH_DESC: text(h.VCH_DESC).slice(0, 149),
    });
    return { reversed: true };
  });
}
