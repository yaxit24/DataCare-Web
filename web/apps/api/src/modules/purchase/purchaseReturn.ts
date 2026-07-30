import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { issueTagTx, restoreTagTx } from '../stock/stock.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  type LedgerLine,
} from '../posting/posting.js';
import { receiptLegs } from '../finance/tender.js';
import { billTotals, type BillTotals } from '@datacare/core';
import {
  buildExpenseLegs,
  computeLine,
  type PurchaseLineInput,
  PurchaseValidationError,
} from './purchase.js';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
import { resolveBookAccountTx, resolveBookPolicyTx } from '../shared/bookPolicy.js';
import { resolveRoundingPolicyTx } from '../shared/roundingPolicyLoader.js';

export interface PurchaseReturnInput {
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
  purchaseAc?: string;
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
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
const num = (v: unknown): number => (v == null ? 0 : Number(v));
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

function keyOf(s: VoucherScope, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'PRT',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

export function buildPurchaseReturnLedger(p: {
  key: VoucherKey;
  acCode: string;
  purchaseAc: string;
  taxAc: string;
  roundAc: string;
  controlAc?: string;
  vchType?: string;
  totals: Pick<BillTotals, 'total' | 'taxable' | 'tax' | 'roundOff'>;
  expenseLegs?: { ac: string; amount: number }[];
}): LedgerLine[] {
  const base = { ...p.key, VCH_TYPE: p.vchType ?? 'PRTN' };
  const lines: LedgerLine[] = [];
  if (p.totals.total !== 0)
    lines.push({
      ...base,
      AC_CODE: p.acCode,
      LD_CODE: p.controlAc ?? p.purchaseAc,
      DR_AMT: p.totals.total,
      CR_AMT: 0,
      SIGN: 'D',
    });
  const expense = p.expenseLegs?.length
    ? p.expenseLegs
    : [{ ac: p.purchaseAc, amount: p.totals.taxable }];
  for (const leg of expense)
    if (leg.amount !== 0)
      lines.push({
        ...base,
        AC_CODE: leg.ac,
        LD_CODE: p.acCode,
        DR_AMT: 0,
        CR_AMT: leg.amount,
        SIGN: 'C',
      });
  if (p.totals.tax !== 0)
    lines.push({
      ...base,
      AC_CODE: p.taxAc,
      LD_CODE: p.acCode,
      DR_AMT: 0,
      CR_AMT: p.totals.tax,
      SIGN: 'C',
    });
  if (p.totals.roundOff > 0)
    lines.push({
      ...base,
      AC_CODE: p.roundAc,
      LD_CODE: p.acCode,
      DR_AMT: 0,
      CR_AMT: p.totals.roundOff,
      SIGN: 'C',
    });
  else if (p.totals.roundOff < 0)
    lines.push({
      ...base,
      AC_CODE: p.roundAc,
      LD_CODE: p.acCode,
      DR_AMT: Math.abs(p.totals.roundOff),
      CR_AMT: 0,
      SIGN: 'D',
    });
  return lines;
}

export interface PurchaseReturnResult {
  vchNo: number;
  totals: BillTotals;
}

async function resolvePurchaseReturnTags(
  tx: any,
  input: PurchaseReturnInput,
  lines: PurchaseLineInput[],
): Promise<Map<number, Awaited<ReturnType<typeof issueTagTx>>>> {
  const tagged = lines.map((line, index) => ({ line, index })).filter(({ line }) => line.tagNo);
  const resolved = new Map<number, Awaited<ReturnType<typeof issueTagTx>>>();
  if (!tagged.length) return resolved;
  if (input.origVchNo == null)
    throw new PurchaseValidationError('original purchase voucher is required for a tagged return');
  const originalBook = String(input.origBook ?? 'PUR').trim();
  const originalNo = formatVoucherNo(input.origVchNo);
  const header: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE" FROM "PR_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    input.scope.lcCode,
    input.scope.coYear ?? '',
    originalBook,
    originalNo,
  );
  if (header.length !== 1 || String(header[0]?.AC_CODE ?? '').trim() !== input.acCode.trim())
    throw new PurchaseValidationError('original purchase does not match the return supplier/scope');
  const seen = new Set<string>();
  for (const { line, index } of tagged) {
    const tagNo = String(line.tagNo);
    const original: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_SRNO","IT_CODE" FROM "PR_DETL"
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
    if (original.length !== 1)
      throw new PurchaseValidationError(
        `tag is not an unambiguous line of the original purchase: ${tagNo}`,
      );
    const vchSrno = Number(original[0]?.VCH_SRNO ?? 0);
    const identity = `${tagNo}|${vchSrno}|${line.itCode}`;
    if (seen.has(identity)) throw new PurchaseValidationError(`duplicate returned tag: ${tagNo}`);
    seen.add(identity);
    if (line.vchSrno != null && Number(line.vchSrno) !== vchSrno)
      throw new PurchaseValidationError(`tag serial does not match original purchase: ${tagNo}`);
    resolved.set(
      index,
      await issueTagTx(tx, {
        CO_CODE: input.scope.coCode,
        LC_CODE: input.scope.lcCode,
        TAG_NO: tagNo,
        VCH_SRNO: vchSrno,
        IT_CODE: line.itCode,
      }),
    );
  }
  return resolved;
}

export async function createPurchaseReturn(
  prisma: any,
  input: PurchaseReturnInput,
  lines: PurchaseLineInput[],
): Promise<PurchaseReturnResult> {
  if (!input.acCode) throw new PurchaseValidationError('supplier account (acCode) is required');
  if (!lines?.length) throw new PurchaseValidationError('at least one return line is required');
  const purchaseAc = input.purchaseAc ?? 'PURCHASE';
  const fallbackTaxAc = input.taxAc ?? 'GSTINPUT';
  const tenantId = input.scope.tenantId;

  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo);
    const bookPolicy = await resolveBookPolicyTx(tx, input.scope, 'PURCHASE RETURN');
    const roundingPolicy = await resolveRoundingPolicyTx(tx, input.scope);
    const taxPolicy = await resolveTaxPolicyTx(tx, input.scope, {
      acCode: input.acCode,
      taxPct: input.taxRatePct,
      taxCode: input.taxCode,
    });
    if (input.interState !== taxPolicy.interState)
      throw new PurchaseValidationError(
        'interState does not match the persisted supplier GST type',
      );
    const taxAc = taxPolicy.taxAc ?? fallbackTaxAc;
    const computed = lines.map((line) => {
      const rounded =
        line.rate == null ? line : { ...line, rate: roundingPolicy.roundPurchaseRate(line.rate) };
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
    const issued = await resolvePurchaseReturnTags(tx, input, lines);

    const itCodes = [...new Set(lines.map((line) => String(line.itCode).trim()))];
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT i."IT_CODE" ic,g."PURC_AC" pac FROM "ITEM_MAST" i
       LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id
        AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
       WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."IT_CODE"::text=ANY($3::text[])`,
      tenantId,
      input.scope.coCode,
      itCodes,
    );
    const purcAcByItem: Record<string, string> = {};
    for (const row of rows) {
      const item = String(row.ic ?? '').trim();
      const account = String(row.pac ?? '').trim();
      if (item && account) purcAcByItem[item] = account;
    }
    const missing = itCodes.filter((item) => !purcAcByItem[item]);
    if (missing.length)
      throw new PurchaseValidationError(
        `item/group posting configuration missing: ${missing.join(', ')}`,
      );
    const expenseLegs = buildExpenseLegs(
      computed.map((line) => ({
        net: line.calc.net,
        ac: purcAcByItem[String(line.in.itCode).trim()] ?? purchaseAc,
      })),
      totals.taxable,
      lineNetTotal,
    );

    const controlAc =
      totals.total === 0 ? purchaseAc : await resolveBookAccountTx(tx, input.scope, bookPolicy, 1);
    let cashAc = input.cashAc ?? 'CASH';
    if (round2(num(input.cashAmt)) !== 0) {
      const configured = await resolveBookAccountTx(tx, input.scope, bookPolicy, 2);
      if (input.cashAc && input.cashAc.trim() !== configured)
        throw new PurchaseValidationError('cash account does not match BOOK_DETL configuration');
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
        throw new PurchaseValidationError(
          'round/kasar account does not match BOOK_DETL configuration',
        );
      roundAc = configured;
      kasarAc = configured;
    }

    const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
    const originalBook = input.origVchNo == null ? null : String(input.origBook ?? 'PUR').trim();
    const originalNo = input.origVchNo == null ? null : formatVoucherNo(input.origVchNo);
    const detl = computed.map((line, index) => ({
      ...key,
      VCH_DATE: vchDate,
      VCH_TYPE: bookPolicy.vchType,
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'R',
      BOOK_NAME: bookPolicy.bookName,
      AC_CODE: input.acCode,
      SR_NO: index + 1,
      IT_CODE: line.in.itCode,
      TAG_NO: line.in.tagNo ?? 'N',
      VCH_SRNO: issued.get(index)?.VCH_SRNO ?? 0,
      ITM_PCS: num(line.in.pcs),
      ITM_GWT: num(line.in.grossWt),
      ITM_NWT: num(line.in.netWt),
      ITM_TOUCH: num(line.in.touch),
      ITM_WEST_PRC: num(line.in.westPct),
      ITM_FINE: line.calc.fine,
      ITM_OTH_FINE: num(line.in.otherFineWt),
      SILVER_FINE: num(line.in.silverFineWt),
      ITM_RATE: num(line.in.rate),
      ITM_AMT: line.calc.metal,
      LBR_AMT: line.calc.labour,
      OTH_AMT: num(line.in.otherAmount),
      NET_AMT: line.calc.net,
      TAX_PRC: input.taxRatePct,
      HM_ID: line.in.huid ?? null,
    }));
    const header = {
      ...key,
      BILL_NO: input.billNo ?? formatVoucherNo(vchNo),
      SL_BILL_NO: originalNo,
      SL_BILL_DBCD: originalBook,
      SL_BILL_LC: originalNo ? input.scope.lcCode : null,
      SL_BILL_YRCD: originalNo ? (input.scope.coYear ?? '') : null,
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
    };
    const ledger = buildPurchaseReturnLedger({
      key,
      acCode: input.acCode,
      purchaseAc,
      taxAc,
      roundAc,
      controlAc,
      vchType: bookPolicy.vchType,
      totals,
      expenseLegs,
    });
    const tender = receiptLegs(
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
    ledger.push(...tender.legs);
    assertBalanced(ledger);
    Object.assign(header, {
      CASH_AMT: tender.cashAmt,
      CHQ_AMT: round2(num(input.chequeAmt)),
      CARD_AMT: round2(num(input.cardAmt)),
      KASAR_AMT: tender.kasar,
      BILL_OS: round2(totals.total - tender.paidNow - tender.kasar),
      BANK_AC: input.bankAc ?? null,
    });

    const taxBase = {
      ...key,
      TRAN_TYPE: 'P',
      BOOK_NAME: bookPolicy.bookName,
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      PARTY_NAME: input.acName ?? null,
      NET_AMT: totals.taxable,
      DISC_AMT: totals.discount,
      TOT_AMT: totals.total,
      TAX_SIGN: '+',
      TAX_CODE: taxPolicy.taxCode,
    };
    const taxRows: Record<string, unknown>[] = [];
    if (totals.tax !== 0) {
      if (taxPolicy.interState)
        taxRows.push({
          ...taxBase,
          SR_NO: 1,
          TAX_TYPE: taxPolicy.taxGroup,
          TAX_PRC: input.taxRatePct,
          TAX_AMT: totals.igst,
        });
      else {
        taxRows.push({
          ...taxBase,
          SR_NO: 1,
          TAX_TYPE: taxPolicy.taxGroup,
          TAX_PRC: round2(input.taxRatePct / 2),
          TAX_AMT: totals.cgst,
        });
        taxRows.push({
          ...taxBase,
          SR_NO: 2,
          TAX_TYPE: taxPolicy.taxGroup,
          TAX_PRC: round2(input.taxRatePct / 2),
          TAX_AMT: totals.sgst,
        });
      }
    }
    const mainStock = computed.map((line, index) => ({
      ...key,
      SR_NO: index + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: bookPolicy.vchType,
      BOOK_NAME: bookPolicy.bookName,
      AC_CODE: input.acCode,
      IT_CODE: line.in.itCode,
      TAG_NO: line.in.tagNo ?? 'N',
      VCH_SRNO: issued.get(index)?.VCH_SRNO ?? 0,
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      ITM_QTY: num(line.in.netWt) || num(line.in.pcs) || 1,
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

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: bookPolicy.bookName,
      writes: [
        { table: 'PR_DATA', rows: [header] },
        { table: 'PR_DETL', rows: detl },
        { table: 'MAIN_STOCK', rows: mainStock },
        ...(taxRows.length ? [{ table: 'TAX_DATA', rows: taxRows }] : []),
      ],
    });
    return { vchNo, totals };
  });
}

export interface DeletePurchaseReturnInput {
  scope: VoucherScope;
  vchNo: number | string;
  deleteUser?: string;
}

export async function deletePurchaseReturn(
  prisma: any,
  input: DeletePurchaseReturnInput,
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo));
  const params = [tenantId, key.CO_CODE, key.LC_CODE, key.CO_YEAR, key.CO_BOOK, key.VCH_NO];
  return withTenant(prisma, tenantId, async (tx: any) => {
    const tags: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT"
         FROM "PR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "TAG_NO"::text<>'N'
          AND nullif(btrim(coalesce("TAG_NO"::text,'')),'') IS NOT NULL`,
      ...params,
    );
    const legacy: Array<
      Record<string, unknown> & { CO_CODE: string; LC_CODE: string; TAG_NO: string }
    > = [];
    for (const tag of tags) {
      const provenance: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "BAR_DETL"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"::text=$4
            AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)
            AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'')`,
        tenantId,
        key.CO_CODE,
        key.LC_CODE,
        String(tag.TAG_NO),
        tag.VCH_SRNO ?? 0,
        tag.IT_CODE ?? '',
      );
      if (Number(provenance[0]?.n ?? 0) === 0)
        legacy.push({
          CO_CODE: key.CO_CODE,
          LC_CODE: key.LC_CODE,
          TAG_NO: String(tag.TAG_NO),
          VCH_SRNO: Number(tag.VCH_SRNO ?? 0),
          IT_CODE: tag.IT_CODE,
          ITM_PCS: tag.ITM_PCS,
          ITM_GWT: tag.ITM_GWT,
          ITM_NWT: tag.ITM_NWT,
          STK_TYPE: 'R',
        });
    }
    await reverseVoucherTx(tx, tenantId, {
      tables: ['PR_DATA', 'PR_DETL', 'AC_DATA', 'TAX_DATA', 'MAIN_STOCK'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'PRTN', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    for (const tag of legacy) await restoreTagTx(tx, tenantId, tag);
    return { reversed: true };
  });
}
