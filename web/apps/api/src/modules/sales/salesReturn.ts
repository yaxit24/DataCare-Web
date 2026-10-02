import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  assertPeriodOpen,
  insertRowTx,
  type LedgerLine,
} from '../posting/posting.js';
import { billTotals, type BillTotals } from '@datacare/core';
import {
  assertSaleTaxRate,
  buildIncomeLegs,
  computeLine,
  type SaleLineInput,
  SaleValidationError,
} from './sales.js';
import { payoutLegs } from '../finance/tender.js';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
import { gstTaxRows } from '../shared/taxDataRows.js';
import { resolveBookAccountTx, resolveBookPolicyTx } from '../shared/bookPolicy.js';
import { resolveRoundingPolicyTx } from '../shared/roundingPolicyLoader.js';
import { buildSaleRojmel, rojmelMetalFor } from '../shared/rojmel.js';
import {
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';

export interface SaleReturnInput {
  scope: VoucherScope;
  acCode: string;
  acName?: string;
  billNo?: string;
  origVchNo?: string | number;
  origBook?: string;
  vchDate?: Date | string;
  discountAmount?: number;
  taxRatePct: number;
  taxCode?: string;
  interState: boolean;
  salesAc?: string;
  taxAc?: string;
  roundAc?: string;
  cashAmt?: number;
  chequeAmt?: number;
  cardAmt?: number;
  upiAmt?: number;
  kasar?: number;
  cashAc?: string;
  bankAc?: string;
  kasarAc?: string;
  mainUser?: string;
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
const num = (v: unknown): number => (v == null ? 0 : Number(v));
const str = (v: unknown): string => String(v ?? '').trim();
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

function keyOf(s: VoucherScope, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'SRT',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

/** Reverse-of-sale ledger with desktop per-group income legs and actual contra accounts. */
export function buildReturnLedger(p: {
  key: VoucherKey;
  acCode: string;
  salesAc: string;
  taxAc: string;
  roundAc: string;
  controlAc?: string;
  vchType?: string;
  totals: Pick<BillTotals, 'total' | 'taxable' | 'tax' | 'roundOff'>;
  incomeLegs?: { ac: string; amount: number }[];
}): LedgerLine[] {
  const base = { ...p.key, VCH_TYPE: p.vchType ?? 'SRTN' };
  const lines: LedgerLine[] = [];
  const income = p.incomeLegs?.length
    ? p.incomeLegs
    : [{ ac: p.salesAc, amount: p.totals.taxable }];
  for (const leg of income)
    if (leg.amount !== 0)
      lines.push({
        ...base,
        AC_CODE: leg.ac,
        LD_CODE: p.acCode,
        DR_AMT: leg.amount,
        CR_AMT: 0,
        SIGN: 'D',
      });
  if (p.totals.total !== 0)
    lines.push({
      ...base,
      AC_CODE: p.acCode,
      LD_CODE: p.controlAc ?? p.salesAc,
      DR_AMT: 0,
      CR_AMT: p.totals.total,
      SIGN: 'C',
    });
  if (p.totals.tax !== 0)
    lines.push({
      ...base,
      AC_CODE: p.taxAc,
      LD_CODE: p.acCode,
      DR_AMT: p.totals.tax,
      CR_AMT: 0,
      SIGN: 'D',
    });
  if (p.totals.roundOff > 0)
    lines.push({
      ...base,
      AC_CODE: p.roundAc,
      LD_CODE: p.acCode,
      DR_AMT: p.totals.roundOff,
      CR_AMT: 0,
      SIGN: 'D',
    });
  else if (p.totals.roundOff < 0)
    lines.push({
      ...base,
      AC_CODE: p.roundAc,
      LD_CODE: p.acCode,
      DR_AMT: 0,
      CR_AMT: Math.abs(p.totals.roundOff),
      SIGN: 'C',
    });
  return lines;
}

export interface SaleReturnResult {
  vchNo: number;
  totals: BillTotals;
}

async function resolveReturnedTagIdentities(
  tx: any,
  input: SaleReturnInput,
  lines: SaleLineInput[],
): Promise<Map<number, { VCH_SRNO: number; IT_CODE: string }>> {
  const tagged = lines.map((line, index) => ({ line, index })).filter(({ line }) => line.tagNo);
  const resolved = new Map<number, { VCH_SRNO: number; IT_CODE: string }>();
  if (!tagged.length) return resolved;
  if (input.origVchNo == null) {
    throw new SaleValidationError('original sale voucher is required for a tagged return');
  }
  const originalBook = String(input.origBook ?? 'SAL').trim();
  const originalNo = formatVoucherNo(input.origVchNo);
  const header: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE" FROM "SL_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    input.scope.lcCode,
    input.scope.coYear ?? '',
    originalBook,
    originalNo,
  );
  if (header.length !== 1 || String(header[0]?.AC_CODE ?? '').trim() !== input.acCode.trim()) {
    throw new SaleValidationError('original sale does not match the return customer/scope');
  }
  const seen = new Set<string>();
  for (const { line, index } of tagged) {
    const tagNo = String(line.tagNo);
    const identityRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_SRNO","IT_CODE" FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "TAG_NO"::text=$7
          AND "IT_CODE"::text=$8 ORDER BY row_id LIMIT 2`,
      input.scope.tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      input.scope.coYear ?? '',
      originalBook,
      originalNo,
      tagNo,
      line.itCode,
    );
    if (identityRows.length !== 1) {
      throw new SaleValidationError(
        `tag is not an unambiguous line of the original sale: ${tagNo}`,
      );
    }
    const vchSrno = Number(identityRows[0]?.VCH_SRNO ?? 0);
    const identity = `${tagNo}|${vchSrno}|${line.itCode}`;
    if (seen.has(identity)) throw new SaleValidationError(`duplicate returned tag: ${tagNo}`);
    seen.add(identity);
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `tag-issue|${input.scope.coCode}|${input.scope.lcCode}|${tagNo}`,
    );
    const provenance: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "BAR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"::text=$4
          AND coalesce("VCH_SRNO",0)=$5::numeric AND "IT_CODE"::text=$6`,
      input.scope.tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      tagNo,
      vchSrno,
      line.itCode,
    );
    if (Number(provenance[0]?.n ?? 0) !== 1) {
      throw new SaleValidationError(`tag provenance is missing or ambiguous: ${tagNo}`);
    }
    const balance: Array<{ bal: unknown }> = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"::text='+' THEN 1 ELSE -1 END),0)::int bal
         FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"::text=$4
          AND coalesce("VCH_SRNO",0)=$5::numeric AND "IT_CODE"::text=$6`,
      input.scope.tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      tagNo,
      vchSrno,
      line.itCode,
    );
    if (Number(balance[0]?.bal ?? 0) !== 0) {
      throw new SaleValidationError(`tag is not currently sold or was already returned: ${tagNo}`);
    }
    resolved.set(index, { VCH_SRNO: vchSrno, IT_CODE: line.itCode });
  }
  return resolved;
}

type SaleReturnWriteContext = {
  tx: any;
  vchNo: number;
  hdVchNo: string;
  mainUser: string;
  persistedClock?: unknown;
};

export async function createSaleReturn(
  prisma: any,
  input: SaleReturnInput,
  lines: SaleLineInput[],
  lifecycle?: SaleReturnWriteContext,
): Promise<SaleReturnResult> {
  if (!input.acCode) throw new SaleValidationError('customer account (acCode) is required');
  if (!lines?.length) throw new SaleValidationError('at least one return line is required');
  assertSaleTaxRate(input.taxRatePct);
  const salesAc = input.salesAc ?? 'SALES';
  const fallbackTaxAc = input.taxAc ?? 'GST';
  const tenantId = input.scope.tenantId;

  const run = async (tx: any): Promise<SaleReturnResult> => {
    const vchNo = lifecycle?.vchNo ?? (await nextVoucherNoTx(tx, input.scope));
    const hdVchNo =
      lifecycle?.hdVchNo ??
      (await nextHiddenVoucherNoTx(tx, { ...input.scope, coBook: input.scope.coBook ?? 'SRT' }));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    const key = keyOf(input.scope, vchNo);
    const bookPolicy = await resolveBookPolicyTx(tx, input.scope, 'SALES RETURN');
    const roundingPolicy = await resolveRoundingPolicyTx(tx, input.scope);
    const taxPolicy = await resolveTaxPolicyTx(tx, input.scope, {
      acCode: input.acCode,
      taxPct: input.taxRatePct,
      taxCode: input.taxCode,
    });
    if (input.interState !== taxPolicy.interState)
      throw new SaleValidationError('interState does not match the persisted customer GST type');
    const taxAc = taxPolicy.taxAc ?? fallbackTaxAc;
    const computed = lines.map((line) => {
      const rounded =
        line.rate == null ? line : { ...line, rate: roundingPolicy.roundItemRate(line.rate) };
      return { in: rounded, calc: computeLine(rounded, roundingPolicy) };
    });
    const lineNetTotal = computed.reduce((sum, line) => sum + line.calc.net, 0);
    const totals = billTotals(
      {
        lineNetTotal,
        discountAmount: input.discountAmount,
        taxRatePct: input.taxRatePct,
        interState: taxPolicy.interState,
      },
      roundingPolicy,
    );
    const identities = await resolveReturnedTagIdentities(tx, input, lines);

    const itCodes = [...new Set(lines.map((line) => String(line.itCode).trim()))];
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT i."IT_CODE" ic,g."SALE_AC" sac FROM "ITEM_MAST" i
       LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id
        AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
       WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."IT_CODE"::text=ANY($3::text[])`,
      tenantId,
      input.scope.coCode,
      itCodes,
    );
    const saleAcByItem: Record<string, string> = {};
    for (const row of rows) {
      const item = String(row.ic ?? '').trim();
      const account = String(row.sac ?? '').trim();
      if (item && account) saleAcByItem[item] = account;
    }
    const missing = itCodes.filter((item) => !saleAcByItem[item]);
    if (missing.length)
      throw new SaleValidationError(
        `item/group posting configuration missing: ${missing.join(', ')}`,
      );
    const incomeLegs = buildIncomeLegs(
      computed.map((line) => ({
        net: line.calc.net,
        ac: saleAcByItem[String(line.in.itCode).trim()] ?? salesAc,
      })),
      totals.taxable,
      lineNetTotal,
    );

    const controlAc =
      totals.total === 0 ? salesAc : await resolveBookAccountTx(tx, input.scope, bookPolicy, 1);
    let cashAc = input.cashAc ?? 'CASH';
    if (round2(num(input.cashAmt)) !== 0) {
      const configured = await resolveBookAccountTx(tx, input.scope, bookPolicy, 2);
      if (input.cashAc && input.cashAc.trim() !== configured)
        throw new SaleValidationError('cash account does not match BOOK_DETL configuration');
      cashAc = configured;
    }
    let roundAc = input.roundAc ?? 'ROUNDOFF';
    let kasarAc = input.kasarAc ?? 'KASAR';
    if (totals.roundOff !== 0 || round2(num(input.kasar)) !== 0) {
      const configured = await resolveBookAccountTx(tx, input.scope, bookPolicy, 3);
      if (
        (input.roundAc && input.roundAc.trim() !== configured) ||
        (input.kasarAc && input.kasarAc.trim() !== configured)
      )
        throw new SaleValidationError('round/kasar account does not match BOOK_DETL configuration');
      roundAc = configured;
      kasarAc = configured;
    }

    const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
    const vchDate = voucherTimestamp(requestedDate, lifecycle?.persistedClock);
    const originalBook = input.origVchNo == null ? null : String(input.origBook ?? 'SAL').trim();
    const originalNo = input.origVchNo == null ? null : formatVoucherNo(input.origVchNo);
    const detl = computed.map((line, index) => ({
      ...key,
      VCH_DATE: vchDate,
      VCH_TYPE: bookPolicy.vchType,
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'R',
      BOOK_NAME: bookPolicy.bookName,
      AC_CODE: input.acCode,
      SR_NO: index + 1,
      IT_CODE: line.in.itCode,
      TAG_NO: line.in.tagNo ?? 'N',
      VCH_SRNO: identities.get(index)?.VCH_SRNO ?? 0,
      ITM_PCS: num(line.in.pcs),
      ITM_GWT: num(line.in.grossWt),
      ITM_NWT: num(line.in.netWt),
      ITM_TOUCH: num(line.in.touch),
      ITM_WEST_PRC: num(line.in.westPct),
      ITM_FINE: line.calc.fine,
      ITM_RATE: num(line.in.rate),
      ITM_AMT: line.calc.metal,
      LBR_AMT: line.calc.labour,
      OTH_AMT: num(line.in.otherAmount),
      NET_AMT: line.calc.net,
      TAX_PRC: input.taxRatePct,
      RTN_IT_TAX_AMT: round2((line.calc.net * input.taxRatePct) / 100),
      DESIGN_NO: line.in.designNo ?? null,
      ITM_SIZE: line.in.itmSize ?? null,
      // TR_SALE_RTN.cs carries the full item costing on the return line, mirroring SL_DETL: without
      // these the returned item loses its labour basis, tag cost and margin, so a re-issue of the same
      // tag would be priced from nothing. Widths verified against the live schema (KR_NAME 5, PR_CODE 2).
      OLD_SRNO: num(line.in.oldSrNo),
      ITM_OTH_WT: num(line.in.otherWt),
      ITM_GHT_WT: num(line.in.ghtWt),
      LBR_TYPE: str(line.in.labourType).slice(0, 1) || null,
      LBR_PRC: num(line.in.labourPct),
      LBR_RATE: num(line.in.labourRate),
      TAG_LBR_PRC: num(line.in.tagLabourPct),
      TAG_LBR_RATE: num(line.in.tagLabourRate),
      TAG_LBR_AMT: num(line.in.tagLabourAmount),
      TAG_OTH_AMT: num(line.in.tagOtherAmount),
      ITM_MRP: num(line.in.mrp),
      RATE_TYPE: str(line.in.rateType).slice(0, 1) || null,
      IT_TYPE: str(line.in.itType).slice(0, 1) || null,
      DATA_TRFR: str(line.in.dataTransfer).slice(0, 1) || null,
      KR_NAME: str(line.in.karigarName).slice(0, 5) || null,
      TAG_COST: num(line.in.tagCost),
      ITM_MARGIN: num(line.in.margin),
      PR_CODE: str(line.in.prCode).slice(0, 2) || null,
      TAG_SRNO: num(line.in.tagSrNo),
      TAG_TYPE: str(line.in.tagType).slice(0, 1) || null,
      TBL_CODE: line.in.tblCode ?? null,
      // Desktop TR_SALE_RTN incoming-grid columns the web form offers (HmId, Ght%, "Receive Item",
      // LDisc%, the lot/employee/image companions and the extra hallmark IDs with their weights).
      // They were accepted and then silently discarded; the saved row now carries what the operator
      // typed. Absent input stays NULL so an unchanged form keeps its exact write set. Widths are
      // the live SL_DETL_RTN columns (HM_ID* 10, ITM_LOT 10, ITM_REMARK 50, EMP_CODE 5).
      HM_ID: str(line.in.huid).slice(0, 10) || null,
      HM_ID2: str(line.in.hallmarkId2).slice(0, 10) || null,
      HM_ID3: str(line.in.hallmarkId3).slice(0, 10) || null,
      HM_ID4: str(line.in.hallmarkId4).slice(0, 10) || null,
      HM_ID_WT: line.in.hallmarkIdWt == null ? null : num(line.in.hallmarkIdWt),
      HM_ID2_WT: line.in.hallmarkId2Wt == null ? null : num(line.in.hallmarkId2Wt),
      HM_ID3_WT: line.in.hallmarkId3Wt == null ? null : num(line.in.hallmarkId3Wt),
      HM_ID4_WT: line.in.hallmarkId4Wt == null ? null : num(line.in.hallmarkId4Wt),
      ITM_GHT_PRC: line.in.ghtPct == null ? null : num(line.in.ghtPct),
      ITM_LOT: str(line.in.itemLot).slice(0, 10) || null,
      ITM_REMARK: str(line.in.remark).slice(0, 50) || null,
      DISC_PRC: line.in.discountPct == null ? null : num(line.in.discountPct),
      EMP_CODE: str(line.in.employeeCode).slice(0, 5) || null,
      DESIGN_IMG_ID: str(line.in.designImageId).slice(0, 50) || null,
      VCH_TIME: vchDate,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
    }));
    const header = {
      ...key,
      BILL_NO: input.billNo ?? formatVoucherNo(vchNo),
      ISU_NO: originalNo,
      ISU_DBCD: originalBook,
      ISU_LC_CODE: originalNo ? input.scope.lcCode : null,
      ISU_YRCD: originalNo ? (input.scope.coYear ?? '') : null,
      AC_CODE: input.acCode,
      AC_NAME: input.acName ?? null,
      VCH_DATE: vchDate,
      NET_AMT: totals.net,
      DISC_AMT: totals.discount,
      TAX_CODE: taxPolicy.taxCode,
      AC_GST_TYPE: taxPolicy.accountGstType,
      TAX_PRC: input.taxRatePct,
      TAX_AMT: totals.tax,
      CGST_TAX: totals.cgst,
      SGST_TAX: totals.sgst,
      IGST_TAX: totals.igst,
      ROF_AMT: totals.roundOff,
      TOT_AMT: totals.total,
      VCH_TIME: vchDate,
      ENTRY_TIME: vchDate,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
    };
    const ledger = buildReturnLedger({
      key,
      acCode: input.acCode,
      salesAc,
      taxAc,
      roundAc,
      controlAc,
      vchType: bookPolicy.vchType,
      totals,
      incomeLegs,
    });
    const refund = payoutLegs(
      { ...key, VCH_TYPE: bookPolicy.vchType },
      {
        partyAc: input.acCode,
        cashAmt: input.cashAmt,
        chequeAmt: input.chequeAmt,
        cardAmt: input.cardAmt,
        upiAmt: input.upiAmt,
        kasar: input.kasar,
        cashAc,
        bankAc: input.bankAc,
        kasarAc,
      },
    );
    ledger.push(...refund.legs);
    assertBalanced(ledger);
    Object.assign(header, {
      CASH_AMT: refund.cashAmt,
      CHQ_AMT: round2(num(input.chequeAmt)),
      CARD_AMT: round2(num(input.cardAmt)),
      UPI_AMT: round2(num(input.upiAmt)),
      KASAR_AMT: refund.kasar,
      BILL_OS: round2(totals.total - refund.paidNow - refund.kasar),
    });

    const taxBase = {
      ...key,
      TRAN_TYPE: 'S',
      BOOK_NAME: bookPolicy.bookName,
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      PARTY_NAME: input.acName ?? null,
      NET_AMT: totals.taxable,
      DISC_AMT: totals.discount,
      TOT_AMT: totals.total,
      TAX_SIGN: '-',
      TAX_CODE: taxPolicy.taxCode,
    };
    const taxRows: Record<string, unknown>[] =
      totals.tax !== 0
        ? gstTaxRows(taxBase, taxPolicy, {
            interState: taxPolicy.interState,
            ratePct: input.taxRatePct,
            igst: totals.igst,
            sgst: totals.sgst,
            cgst: totals.cgst,
          })
        : [];
    const mainStock = computed.map((line, index) => ({
      ...key,
      SR_NO: index + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: bookPolicy.vchType,
      BOOK_NAME: bookPolicy.bookName,
      AC_CODE: input.acCode,
      IT_CODE: line.in.itCode,
      TAG_NO: line.in.tagNo ?? 'N',
      VCH_SRNO: identities.get(index)?.VCH_SRNO ?? 0,
      TBL_CODE: line.in.tblCode ?? null,
      DESIGN_NO: line.in.designNo ?? null,
      ITM_SIZE: line.in.itmSize ?? null,
      TR_TYPE: 'I',
      ITM_SIGN: '+',
      ITM_QTY: 1,
      ITM_PCS: num(line.in.pcs) || 1,
      ITM_GWT: num(line.in.grossWt),
      ITM_NWT: num(line.in.netWt),
      ITM_TOUCH: num(line.in.touch),
      ITM_WEST: num(line.in.westPct),
      ITM_FINE: line.calc.fine,
      ITM_RATE: num(line.in.rate),
      ITM_AMT: line.calc.metal,
      LBR_AMT: line.calc.labour,
      OTH_AMT: num(line.in.otherAmount),
      NET_AMT: line.calc.net,
    }));

    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_BOOK: input.scope.coBook ?? 'SRT',
      VCH_NO: hdVchNo,
      BOOK_NAME: bookPolicy.bookName,
    });
    // The Rojmel, inward. A sales return brings metal BACK IN, so its rows carry SIGN '+' and mirror the
    // original sale: the revenue account is debited and the party credited. IT_TYPE comes from the
    // line's own item type, which SL_DETL_RTN already records.
    const rojmelRows = buildSaleRojmel(
      {
        scope: { coCode: input.scope.coCode, lcCode: input.scope.lcCode, coYear: key.CO_YEAR },
        key,
        coBook: key.CO_BOOK,
        vchNo: key.VCH_NO,
        vchDate,
        vchType: bookPolicy.vchType,
        bookName: bookPolicy.bookName,
        partyName: input.acName ?? '',
        partyCode: input.acCode,
      },
      computed.map((line, index) => {
        const item = String(line.in.itCode ?? '').trim();
        return {
          lineNo: index + 1,
          revenueAc: saleAcByItem[item] ?? salesAc,
          amount: line.calc.net,
          metal: rojmelMetalFor(line.in.itType),
          pcs: num(line.in.pcs),
          grossWt: num(line.in.grossWt),
          netWt: num(line.in.netWt),
          rate: num(line.in.rate),
        };
      }),
      { taxAc, taxAmount: totals.tax, partyAmount: totals.total },
      false, // inward: metal returns to stock, party credited
    );

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: bookPolicy.bookName,
      writes: [
        { table: 'SL_DATA', rows: [header] },
        { table: 'SL_DETL_RTN', rows: detl },
        { table: 'MAIN_STOCK', rows: mainStock },
        ...(taxRows.length ? [{ table: 'TAX_DATA', rows: taxRows }] : []),
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    return { vchNo, totals };
  };
  return lifecycle ? run(lifecycle.tx) : withTxBudget(prisma, tenantId, 'voucher', run);
}

export async function saleForReturn(
  prisma: any,
  input: { scope: VoucherScope; origVchNo: string | number; origBook?: string },
): Promise<{
  acCode: string;
  acName: string | null;
  taxRatePct: number;
  interState: boolean;
  billNo: string;
  lines: any[];
}> {
  const tenantId = input.scope.tenantId;
  const book = input.origBook ?? 'SAL';
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    // A return reverses a SALE. A quotation, order or credit-note book shares SL_DATA but is not a source.
    await resolveBookPolicyTx(tx, { ...input.scope, coBook: book }, 'SALES');
    const hdr: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME","TAX_PRC","IGST_TAX","BILL_NO" FROM "SL_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
      tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      input.scope.coYear ?? '',
      book,
      formatVoucherNo(input.origVchNo),
    );
    if (!hdr.length) throw new SaleValidationError('original bill not found');
    const detail: any[] = await tx.$queryRawUnsafe(
      `SELECT "IT_CODE","TAG_NO","VCH_SRNO",
              coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0)::float "pcs",
              coalesce(NULLIF("ITM_GWT"::text,'')::numeric,0)::float "grossWt",
              coalesce(NULLIF("ITM_NWT"::text,'')::numeric,0)::float "netWt",
              coalesce(NULLIF("ITM_TOUCH"::text,'')::numeric,0)::float "touch",
              coalesce(NULLIF("ITM_RATE"::text,'')::numeric,0)::float "rate",
              coalesce(NULLIF("ITM_AMT"::text,'')::numeric,0)::float "metalAmount",
              coalesce(NULLIF("LBR_AMT"::text,'')::numeric,0)::float "labourAmount",
              coalesce(NULLIF("NET_AMT"::text,'')::numeric,0)::float "net"
         FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      input.scope.coYear ?? '',
      book,
      formatVoucherNo(input.origVchNo),
    );
    return {
      acCode: hdr[0].AC_CODE,
      acName: hdr[0].AC_NAME ?? null,
      taxRatePct: Number(hdr[0].TAX_PRC ?? 3),
      interState: Number(hdr[0].IGST_TAX ?? 0) > 0,
      billNo: hdr[0].BILL_NO ?? formatVoucherNo(input.origVchNo),
      lines: detail,
    };
  });
}

type CompleteSaleReturnScope = VoucherScope & { coYear: string; coBook: string };
const SALE_RETURN_WRITE_TABLES = [
  'SL_DATA',
  'SL_DETL_RTN',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'REMARK_DATA',
] as const;
const text = (value: unknown): string => String(value ?? '').trim();
function completeReturnScope(scope: VoucherScope): asserts scope is CompleteSaleReturnScope {
  if (!scope.coYear || !scope.coBook)
    throw new SaleValidationError('complete voucher scope (coYear and coBook) is required');
}
const returnParams = (scope: CompleteSaleReturnScope, voucherNo: string): unknown[] => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];

export async function getSaleReturn(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeReturnScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const params = returnParams(scope, voucherNo);
    const headers: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","BILL_NO","HD_VCH_NO","MAIN_USER",
              "AC_CODE","AC_NAME","ISU_NO","ISU_DBCD","DISC_AMT","TAX_CODE","TAX_PRC",
              "IGST_TAX","CASH_AMT","CHQ_AMT","CARD_AMT","UPI_AMT","KASAR_AMT",
              "NET_AMT","TAX_AMT","TOT_AMT"
         FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...params,
    );
    if (headers.length !== 1)
      throw new SaleValidationError(
        headers.length
          ? `sales return voucher is ambiguous: ${voucherNo}`
          : `sales return voucher not found: ${voucherNo}`,
      );
    const details: any[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT",
              "ITM_TOUCH","ITM_WEST_PRC","ITM_RATE","LBR_AMT","OTH_AMT","DESIGN_NO",
              "ITM_SIZE","TBL_CODE","NET_AMT" FROM "SL_DETL_RTN"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...params,
    );
    const h = headers[0];
    return {
      voucherNo: text(h.VCH_NO),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      billNo: text(h.BILL_NO),
      acCode: text(h.AC_CODE),
      acName: text(h.AC_NAME),
      origVchNo: text(h.ISU_NO),
      origBook: text(h.ISU_DBCD),
      discountAmount: num(h.DISC_AMT),
      taxCode: text(h.TAX_CODE),
      taxRatePct: num(h.TAX_PRC),
      interState: num(h.IGST_TAX) !== 0,
      cashAmt: num(h.CASH_AMT),
      chequeAmt: num(h.CHQ_AMT),
      cardAmt: num(h.CARD_AMT),
      upiAmt: num(h.UPI_AMT),
      kasar: num(h.KASAR_AMT),
      totals: { net: num(h.NET_AMT), tax: num(h.TAX_AMT), total: num(h.TOT_AMT) },
      lines: details.map((r) => ({
        srNo: num(r.SR_NO),
        itCode: text(r.IT_CODE),
        tagNo: text(r.TAG_NO) === 'N' ? '' : text(r.TAG_NO),
        vchSrno: num(r.VCH_SRNO),
        pcs: num(r.ITM_PCS),
        grossWt: num(r.ITM_GWT),
        netWt: num(r.ITM_NWT),
        touch: num(r.ITM_TOUCH),
        westPct: num(r.ITM_WEST_PRC),
        rate: num(r.ITM_RATE),
        labourFixed: num(r.LBR_AMT),
        otherAmount: num(r.OTH_AMT),
        designNo: text(r.DESIGN_NO),
        itmSize: text(r.ITM_SIZE),
        tblCode: text(r.TBL_CODE),
        netAmount: num(r.NET_AMT),
      })),
    };
  });
}

export async function editSaleReturn(
  prisma: any,
  input: SaleReturnInput,
  lines: SaleLineInput[],
  requestedVoucherNo: number | string,
): Promise<SaleReturnResult> {
  completeReturnScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const persisted = await persistedVoucherHeaderTx(tx, {
      table: 'SL_DATA',
      scope,
      voucherNo,
      extraColumns: ['ISU_NO', 'ISU_DBCD'],
    });
    for (const date of [persisted.VCH_DATE, requestedDate])
      await assertPeriodOpen(tx, scope.tenantId, {
        ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
      });
    // Deliberate fail-closed hardening: a tag re-admitted by this return may not be removed once sold again.
    const consumed: any[] = await tx.$queryRawUnsafe(
      `SELECT r."TAG_NO" FROM "SL_DETL_RTN" r JOIN "SL_DETL" s
         ON s.tenant_id=r.tenant_id AND s."CO_CODE"=r."CO_CODE" AND s."LC_CODE"=r."LC_CODE"
        AND s."TAG_NO"=r."TAG_NO" AND coalesce(s."VCH_SRNO",0)=coalesce(r."VCH_SRNO",0)
       WHERE r.tenant_id=$1 AND r."CO_CODE"=$2 AND r."LC_CODE"=$3 AND r."CO_YEAR"=$4
         AND r."CO_BOOK"=$5 AND r."VCH_NO"=$6 AND r."TAG_NO"::text<>'N'
         AND NOT (s."CO_BOOK"::text=coalesce($7::text,'') AND s."VCH_NO"::text=coalesce($8::text,'')) LIMIT 1 FOR UPDATE OF r`,
      ...returnParams(scope, voucherNo),
      persisted.ISU_DBCD ?? '',
      persisted.ISU_NO ?? '',
    );
    if (consumed.length)
      throw new SaleValidationError(
        `sales return cannot be edited — returned tag ${text(consumed[0].TAG_NO)} was sold again`,
      );
    const hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
    await deleteVoucherWriteSetTx(tx, {
      tables: SALE_RETURN_WRITE_TABLES,
      key: { scope, voucherNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
    return createSaleReturn(prisma, input, lines, {
      tx,
      vchNo: Number(voucherNo),
      hdVchNo: hiddenVoucherNo,
      mainUser: text(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
    });
  });
}

export interface DeleteSaleReturnInput {
  scope: VoucherScope;
  vchNo: number | string;
  deleteUser?: string;
}
export async function deleteSaleReturn(
  prisma: any,
  input: DeleteSaleReturnInput,
): Promise<{ reversed: true }> {
  completeReturnScope(input.scope);
  const scope = input.scope;
  const tenantId = scope.tenantId;
  const voucherNo = formatVoucherNo(input.vchNo);
  const key = keyOf(scope, Number(voucherNo));
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const header = await persistedVoucherHeaderTx(tx, {
      table: 'SL_DATA',
      scope,
      voucherNo,
      extraColumns: ['AC_CODE', 'AC_NAME', 'TOT_AMT', 'RTN_TOT_AMT'],
    });
    await assertPeriodOpen(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: header.VCH_DATE }] },
    });
    const books: any[] = await tx.$queryRawUnsafe(
      `SELECT "BOOK_SNAME","BOOK_NAME" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND "LC_CODE"=$3 AND "CO_BOOK"=$4 LIMIT 1`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
    );
    if (books.length !== 1)
      throw new SaleValidationError('sales return book configuration not found');
    await reverseVoucherTx(tx, tenantId, { tables: [...SALE_RETURN_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      text(header.HD_VCH_NO),
    );
    const now = new Date();
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
      VCH_VAL_DR: num(header.TOT_AMT),
      VCH_VAL_CR: num(header.RTN_TOT_AMT),
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      HD_VCH_NO: header.HD_VCH_NO,
      MAIN_USER: header.MAIN_USER,
      DELETE_USER: input.deleteUser ?? 'system',
      VCH_DESC: `Sales RtnAmt-${num(header.RTN_TOT_AMT)} SalesAmt/${num(header.TOT_AMT)}`,
    });
    return { reversed: true };
  });
}
