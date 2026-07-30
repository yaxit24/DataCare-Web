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
import { receiptLegs } from '../finance/tender.js';
import { SaleValidationError } from './sales.js';
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
export interface LabourLine {
  itCode: string;
  desc?: string;
  pcs?: number;
  netWt?: number;
  metalAmount?: number;
  labourAmount?: number;
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
  const labourAc = input.labourAc ?? 'LABOUR';
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
      TAX_AMT: metalT.tax,
      TAX_PRC: metalPct,
      LBR_DR_AMT: labourT.taxable,
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
    }));
    // TAX_DATA: two rows — metal GST (SALES) + labour GST (LABOUR).
    const taxBase = {
      ...key,
      TRAN_TYPE: 'S',
      BOOK_NAME: 'LABOUR',
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      PARTY_NAME: input.acName ?? null,
      TAX_SIGN: '+',
    };
    const split = (t: typeof metalT, pct: number, net: number, sr0: number) =>
      inter
        ? [
            {
              ...taxBase,
              SR_NO: sr0,
              TAX_TYPE: 'IGST',
              NET_AMT: net,
              TAX_PRC: pct,
              TAX_AMT: t.igst,
              TOT_AMT: t.total,
            },
          ]
        : [
            {
              ...taxBase,
              SR_NO: sr0,
              TAX_TYPE: 'CGST',
              NET_AMT: net,
              TAX_PRC: r2(pct / 2),
              TAX_AMT: t.cgst,
              TOT_AMT: t.total,
            },
            {
              ...taxBase,
              SR_NO: sr0 + 1,
              TAX_TYPE: 'SGST',
              NET_AMT: net,
              TAX_PRC: r2(pct / 2),
              TAX_AMT: t.sgst,
              TOT_AMT: t.total,
            },
          ];
    const taxRows = [
      ...(metalBase > 0 ? split(metalT, metalPct, metalT.taxable, 1) : []),
      ...(labourBase > 0 ? split(labourT, labourPct, labourT.taxable, 5) : []),
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
  return lifecycle ? run(lifecycle.tx) : withTenant(prisma, tenantId, run);
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
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
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
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
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
  return withTenant(prisma, tenantId, async (tx: any) => {
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
