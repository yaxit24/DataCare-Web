import { gstSplit } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
import { gstTaxRows } from '../shared/taxDataRows.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { resolveBookAccountTx, type BookPolicy } from '../shared/bookPolicy.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  type LedgerLine,
} from '../posting/posting.js';

/**
 * Fine Sale / Fine Purchase (TR_FINE_SL_PR) — the bullion-style PURE-METAL trade priced on fine
 * weight. Two sides chosen by `side`: FINE SALE (sell loose fine out) / FINE PURC (buy fine in).
 * Value is ALWAYS fine × FINE_RATE (no labour/MRP); GST applies on the metal value.
 *
 *  FINE SALE: Dr party/cash (net) / Cr fine-sales (metal) + Cr GST (tax); metal OUT leg (FINE_WT, '-')
 *  FINE PURC: Dr fine-purchase (metal) + Dr input-GST (tax) / Cr supplier (net); metal IN leg ('+')
 *
 * Writes CUT_DATA (header) + CUT_DETL (lines) + TAX_DATA + MAIN_STOCK + AC_DATA. A fine purchase may
 * also "cut" (rate-fix) open fine on existing purchase lines: each cut writes a CUT_STK_DETL link row
 * (SL_* → source PR_DETL) and increments PR_DETL.FINE_CUT_* (guarded ≤ open balance); delete restores
 * it. Money 2 dp, fine 3 dp. Book FSL (sale) / FPR (purchase). (spec 11_Bullion_Tour_VP/TR_FINE_SL_PR.md)
 */
export class FineSaleValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'FineSaleValidationError';
  }
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
const num = (v: unknown): number => (v == null ? 0 : Number(v));
const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
/** An ISO yyyy-mm-dd regardless of whether the column comes back as a Date or a text string. */
const isoDate = (v: unknown): string => {
  if (v == null) return '';
  if (v instanceof Date) return v.toISOString().slice(0, 10);
  return String(v).slice(0, 10);
};

export interface FineLine {
  itCode?: string;
  itType?: 'G' | 'S';
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  fineWt?: number;
  fineRate: number;
  taxPct?: number;
}
/** A rate-cut: fix `fine` of the open balance on a source purchase line (PR_DETL key). */
export interface FineCut {
  coBook: string;
  coYear?: string;
  vchNo: string;
  srNo: number;
  fine: number;
  netWt?: number;
  grossWt?: number;
  pcs?: number;
}

export interface FineSalePurchaseInput {
  scope: VoucherScope;
  side: 'SALE' | 'PURC';
  partyAc: string;
  partyName?: string;
  itType?: 'G' | 'S';
  taxPct?: number;
  interState?: boolean;
  vchDate?: Date | string;
  lines: FineLine[];
  cuts?: FineCut[];
  fineSalesAc?: string; // Cr on sale (default 'FINESALE')
  finePurchaseAc?: string; // Dr on purchase (default 'FINEPURC')
  taxAc?: string; // GST (default 'GST' sale / 'GSTINPUT' purc)
  cashAc?: string; // settle to cash/bank instead of party balance (optional)
}

/** Per-line fine + metal + tax + net (pure). */
export function fineLineCalc(
  l: FineLine,
  taxPct: number,
): { fine: number; metal: number; tax: number; net: number } {
  const fine = l.fineWt != null ? r3(num(l.fineWt)) : r3((num(l.netWt) * num(l.touch)) / 100);
  const metal = r2(fine * num(l.fineRate));
  const tax = r2((metal * taxPct) / 100);
  return { fine, metal, tax, net: r2(metal + tax) };
}

function keyOf(s: VoucherScope, vchNo: number, book: string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? book,
    VCH_NO: formatVoucherNo(vchNo),
  };
}

export async function createFineSalePurchase(
  prisma: any,
  input: FineSalePurchaseInput,
  context?: { tx: any; forceVchNo: number },
): Promise<{ vchNo: number; totals: { fine: number; metal: number; tax: number; net: number } }> {
  if (!input.partyAc) throw new FineSaleValidationError('party account (partyAc) is required');
  const lines = (input.lines ?? []).filter(
    (l) => l && (l.fineWt != null || (l.netWt != null && l.touch != null)),
  );
  if (!lines.length) throw new FineSaleValidationError('at least one fine line is required');
  for (const l of lines)
    if (!(num(l.fineRate) > 0))
      throw new FineSaleValidationError('fine rate must be > 0 on every line');

  const isSale = input.side === 'SALE';
  const taxPct = num(input.taxPct);
  const itType = input.itType ?? 'G';
  const inter = !!input.interState;
  const tenantId = input.scope.tenantId;
  const book = isSale ? 'FSL' : 'FPR';
  const vchType = isSale ? 'FNSL' : 'FNPR';
  const bookName = isSale ? 'FINE SALE' : 'FINE PURC';
  const taxAc = input.taxAc ?? (isSale ? 'GST' : 'GSTINPUT');
  const metalAcOverride = (isSale ? input.fineSalesAc : input.finePurchaseAc)?.trim() || '';
  const partyAc = input.cashAc ?? input.partyAc;

  const computed = lines.map((l) => ({
    in: l,
    calc: fineLineCalc(l, l.taxPct != null ? num(l.taxPct) : taxPct),
  }));
  const totFine = r3(computed.reduce((s, c) => s + c.calc.fine, 0));
  const totMetal = r2(computed.reduce((s, c) => s + c.calc.metal, 0));
  const totTax = r2(computed.reduce((s, c) => s + c.calc.tax, 0));
  const totNet = r2(totMetal + totTax);
  const cgst = inter ? 0 : r2(totTax / 2);
  const sgst = inter ? 0 : r2(totTax - cgst);
  const igst = inter ? totTax : 0;

  const run = async (tx: any) => {
    // G92: the tax code resolved like every other family (Ac_Tax.cs Fine_Cut_GST :289-293 joins TAX_MAST on
    // CUT_DATA.TAX_CODE); geography comes from the party's AC_GST_TYPE.
    const policy =
      totMetal !== 0
        ? await resolveTaxPolicyTx(tx, input.scope, { acCode: input.partyAc, taxPct })
        : null;
    if (policy && policy.interState !== inter)
      throw new FineSaleValidationError('interState does not match the persisted party GST type');
    // G121 / P0-04: the fine metal account is the FSL/FPR book's BOOK_DETL slot 1 (seed FINESALE/FINEPURC),
    // not a literal; an explicit caller override wins.
    const metalAc =
      metalAcOverride ||
      (await resolveBookAccountTx(
        tx,
        { ...input.scope, coBook: input.scope.coBook ?? book },
        {
          coBook: input.scope.coBook ?? book,
          vchType,
          bookName,
          mainBook: bookName,
          inout: isSale ? 'O' : 'I',
        } as BookPolicy,
        1,
      ));
    // RATE_PAR mirrors the company's configured metal-rate basis. The desktop sets CurRatePar from MsRatePar
    // for a new voucher (TR_FINE_SL_PR.cs:3955-3963) and reads it back on reopen (:4288), so a hardcoded 'G'
    // mislabels every voucher at a shop quoting per-10-gram or per-kilogram rates.
    const { rateBasis } = await resolveSettingsBehaviorTx(tx, input.scope);
    // Validate cuts against open balance on the source PR_DETL line.
    for (const cut of input.cuts ?? []) {
      const rows: any[] = await tx.$queryRawUnsafe(
        `SELECT coalesce("ITM_FINE",0)::float itf, coalesce("FINE_CUT_FINE",0)::float fcf FROM "PR_DETL"
         WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "SR_NO"=$4 LIMIT 1`,
        input.scope.coCode,
        cut.coBook,
        formatVoucherNo(cut.vchNo),
        num(cut.srNo),
      );
      if (!rows.length)
        throw new FineSaleValidationError(
          `rate-cut: purchase line ${cut.vchNo}/${cut.srNo} not found`,
        );
      const open = r3(num(rows[0].itf) - num(rows[0].fcf));
      if (num(cut.fine) > open + 1e-6)
        throw new FineSaleValidationError(
          `rate-cut: fine ${cut.fine} exceeds open balance ${open} on line ${cut.vchNo}/${cut.srNo}`,
        );
    }

    const no = context?.forceVchNo ?? (await nextVoucherNoTx(tx, input.scope));
    const key = keyOf(input.scope, no, book);
    const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();

    // Balanced ledger (money) + metal fine-weight leg (DR=CR=0, never unbalances money).
    const base = { ...key, VCH_TYPE: vchType };
    const ledger: LedgerLine[] = [];
    if (isSale) {
      ledger.push({ ...base, AC_CODE: partyAc, DR_AMT: totNet, CR_AMT: 0, SIGN: 'D' }); // Dr customer/cash (net)
      ledger.push({ ...base, AC_CODE: metalAc, DR_AMT: 0, CR_AMT: totMetal, SIGN: 'C' }); // Cr fine-sales (metal)
      if (totTax !== 0)
        ledger.push({ ...base, AC_CODE: taxAc, DR_AMT: 0, CR_AMT: totTax, SIGN: 'C' }); // Cr GST
    } else {
      ledger.push({ ...base, AC_CODE: metalAc, DR_AMT: totMetal, CR_AMT: 0, SIGN: 'D' }); // Dr fine-purchase (metal)
      if (totTax !== 0)
        ledger.push({ ...base, AC_CODE: taxAc, DR_AMT: totTax, CR_AMT: 0, SIGN: 'D' }); // Dr input GST
      ledger.push({ ...base, AC_CODE: partyAc, DR_AMT: 0, CR_AMT: totNet, SIGN: 'C' }); // Cr supplier (net)
    }
    assertBalanced(ledger);
    // metal custody leg: fine OUT on sale ('-'), IN on purchase ('+').
    ledger.push({
      ...base,
      AC_CODE: input.partyAc,
      IT_TYPE: itType,
      SIGN: isSale ? '-' : '+',
      FINE_WT: totFine,
      FINE_RATE: 0,
      DR_AMT: 0,
      CR_AMT: 0,
    });

    const header = {
      ...key,
      VCH_DATE: vchDate,
      BILL_NO: formatVoucherNo(no),
      VCH_TYPE: vchType,
      INOUT_TYPE: isSale ? 'O' : 'I',
      ENTRY_TYPE: isSale ? 'S' : 'P',
      BOOK_NAME: bookName,
      AC_CODE: input.partyAc,
      AC_NAME: input.partyName ?? null,
      IT_TYPE: itType,
      FINE_TYPE: itType,
      NET_AMT: totMetal,
      TAX_CODE: policy?.taxCode || null,
      TAX_PRC: taxPct,
      TAX_AMT: totTax,
      TOT_AMT: totNet,
      CGST_TAX: cgst,
      SGST_TAX: sgst,
      IGST_TAX: igst,
      BILL_OS: input.cashAc ? 0 : totNet,
      MAIN_USER: 'system',
      DATA_TRFR: 'N',
    };
    const detl = computed.map((c, i) => ({
      ...key,
      SR_NO: i + 1,
      OLD_SRNO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      INOUT_TYPE: isSale ? 'O' : 'I',
      ENTRY_TYPE: isSale ? 'S' : 'P',
      BOOK_NAME: bookName,
      AC_CODE: input.partyAc,
      IT_TYPE: c.in.itType ?? itType,
      FINE_TYPE: c.in.itType ?? itType,
      // sale: fine OUT (CR_FINE) + value DR_AMT; purchase: fine IN (DR_FINE) + value CR_AMT
      DR_FINE: isSale ? 0 : c.calc.fine,
      CR_FINE: isSale ? c.calc.fine : 0,
      DR_AMT: isSale ? c.calc.metal : 0,
      CR_AMT: isSale ? 0 : c.calc.metal,
      FINE_RATE: num(c.in.fineRate),
      RATE_PAR: rateBasis,
      TAX_PRC: c.in.taxPct != null ? num(c.in.taxPct) : taxPct,
      TOT_AMT: c.calc.metal,
      NET_AMT: c.calc.net,
      MAIN_USER: 'system',
    }));

    const taxBase = {
      ...key,
      TRAN_TYPE: isSale ? 'S' : 'P',
      BOOK_NAME: bookName,
      VCH_DATE: vchDate,
      AC_CODE: input.partyAc,
      PARTY_NAME: input.partyName ?? null,
      NET_AMT: totMetal,
      TOT_AMT: totNet,
      TAX_SIGN: isSale ? '+' : '-',
    };
    // TAX_DATA from the code's component rows (Fine_Cut_GST :289-293): SR_NO 1/2 (3 inter-state), each half
    // TAX_AMT/2 unrounded; nothing for a code without component rows.
    const taxRows: Record<string, unknown>[] =
      policy?.taxCode && (policy.components.size > 0 || totTax !== 0)
        ? gstTaxRows({ ...taxBase, TAX_CODE: policy.taxCode, DISC_AMT: 0 }, policy, {
            interState: inter,
            ratePct: taxPct,
            ...gstSplit(totTax, inter),
          })
        : [];
    // loose-fine MAIN_STOCK movement (no tag): IN on purchase ('+'), OUT on sale ('-').
    const mainStock = computed.map((c, i) => ({
      ...key,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      BOOK_NAME: bookName,
      AC_CODE: input.partyAc,
      IT_CODE: (c.in.itCode ?? itType).slice(0, 5),
      TAG_NO: 'N',
      TBL_CODE: '000',
      TR_TYPE: isSale ? 'O' : 'P',
      ITM_SIGN: isSale ? '-' : '+',
      ITM_QTY: c.calc.fine || 1,
      ITM_PCS: num(c.in.pcs),
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.calc.fine,
      ITM_RATE: num(c.in.fineRate),
      ITM_AMT: c.calc.metal,
      NET_AMT: c.calc.net,
    }));
    // rate-cut link rows (CUT_STK_DETL) → source PR_DETL line.
    const cutStk = (input.cuts ?? []).map((cut, i) => ({
      ...key,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      INOUT_TYPE: isSale ? 'O' : 'I',
      ENTRY_TYPE: isSale ? 'S' : 'P',
      BOOK_NAME: bookName,
      AC_CODE: input.partyAc,
      IT_CODE: itType === 'S' ? 'SLV' : 'GOLD',
      STK_FINE: r3(num(cut.fine)),
      STK_NWT: r3(num(cut.netWt)),
      STK_GWT: r3(num(cut.grossWt)),
      STK_PCS: num(cut.pcs),
      SL_NO: formatVoucherNo(cut.vchNo),
      SL_LC_CODE: input.scope.lcCode,
      SL_YRCD: cut.coYear ?? null,
      SL_DBCD: cut.coBook,
      SL_SRNO: num(cut.srNo),
      MAIN_USER: 'system',
    }));

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName,
      writes: [
        { table: 'CUT_DATA', rows: [header] },
        { table: 'CUT_DETL', rows: detl },
        ...(cutStk.length ? [{ table: 'CUT_STK_DETL', rows: cutStk }] : []),
        ...(taxRows.length ? [{ table: 'TAX_DATA', rows: taxRows }] : []),
        { table: 'MAIN_STOCK', rows: mainStock },
      ],
    });

    // draw down open fine on each linked purchase line (rate-cut / fixing).
    for (const cut of input.cuts ?? []) {
      await tx.$executeRawUnsafe(
        `UPDATE "PR_DETL" SET "FINE_CUT_FINE"=(coalesce("FINE_CUT_FINE",0)+$5)::text, "FINE_CUT_NWT"=(coalesce("FINE_CUT_NWT",0)+$6)::text,
           "FINE_CUT_GWT"=(coalesce("FINE_CUT_GWT",0)+$7)::text, "FINE_CUT_PCS"=(coalesce("FINE_CUT_PCS",0)+$8)::text
         WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "SR_NO"=$4`,
        input.scope.coCode,
        cut.coBook,
        formatVoucherNo(cut.vchNo),
        num(cut.srNo),
        r3(num(cut.fine)),
        r3(num(cut.netWt)),
        r3(num(cut.grossWt)),
        num(cut.pcs),
      );
    }
    return { vchNo: no, totals: { fine: totFine, metal: totMetal, tax: totTax, net: totNet } };
  };
  if (context) return run(context.tx);
  return withTxBudget(prisma, tenantId, 'voucher', (tx: any) => run(tx));
}

/**
 * Reverse a Fine Sale / Fine Purchase inside an open transaction: restore the open-fine balance on
 * every cut source line (CUT_STK_DETL -> PR_DETL), then reverse the voucher's own write set and log
 * the delete. Shared by delete (its own tx) and edit (the repost tx), so both agree.
 */
async function reverseFineSaleTx(
  tx: any,
  tenantId: string,
  key: VoucherKey,
  side: 'SALE' | 'PURC' | undefined,
  deleteUser: string,
): Promise<void> {
  const cuts: any[] = await tx.$queryRawUnsafe(
    `SELECT "SL_DBCD" db, "SL_NO" no, "SL_SRNO" sr, coalesce("STK_FINE",0)::float f, coalesce("STK_NWT",0)::float nw, coalesce("STK_GWT",0)::float gw, coalesce("STK_PCS",0)::float pc
       FROM "CUT_STK_DETL" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND coalesce("SL_NO",'')<>''`,
    key.CO_CODE,
    key.CO_BOOK,
    key.VCH_NO,
  );
  await reverseVoucherTx(tx, tenantId, {
    tables: ['CUT_DATA', 'CUT_DETL', 'CUT_STK_DETL', 'AC_DATA', 'TAX_DATA', 'MAIN_STOCK'],
    key,
    deleteLog: {
      table: 'DELETE_DATA',
      row: { ...key, VCH_TYPE: side === 'PURC' ? 'FNPR' : 'FNSL', DELETE_USER: deleteUser },
    },
  });
  for (const c of cuts) {
    await tx.$executeRawUnsafe(
      `UPDATE "PR_DETL" SET "FINE_CUT_FINE"=greatest(coalesce("FINE_CUT_FINE",0)-$5,0)::text, "FINE_CUT_NWT"=greatest(coalesce("FINE_CUT_NWT",0)-$6,0)::text,
           "FINE_CUT_GWT"=greatest(coalesce("FINE_CUT_GWT",0)-$7,0)::text, "FINE_CUT_PCS"=greatest(coalesce("FINE_CUT_PCS",0)-$8,0)::text
         WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "SR_NO"=$4`,
      key.CO_CODE,
      String(c.db ?? ''),
      String(c.no ?? ''),
      Number(c.sr ?? 0),
      Number(c.f ?? 0),
      Number(c.nw ?? 0),
      Number(c.gw ?? 0),
      Number(c.pc ?? 0),
    );
  }
}

export async function deleteFineSalePurchase(
  prisma: any,
  input: {
    scope: VoucherScope;
    vchNo: number | string;
    side?: 'SALE' | 'PURC';
    deleteUser?: string;
  },
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const book = input.scope.coBook ?? (input.side === 'PURC' ? 'FPR' : 'FSL');
  const key = keyOf({ ...input.scope, coBook: book }, Number(input.vchNo), book);
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseFineSaleTx(tx, tenantId, key, input.side, input.deleteUser ?? 'system');
    return { reversed: true };
  });
}

/**
 * Edit a Fine Sale / Fine Purchase (desktop save-on-edit): in one transaction reverse the old
 * voucher (restoring cut drawdowns and stock) and repost the new input under the SAME voucher
 * number via createFineSalePurchase's forceVchNo context. Reversing first means the repost's own
 * rate-cut validation sees the restored open balances.
 */
export async function editFineSalePurchase(
  prisma: any,
  input: FineSalePurchaseInput,
  vchNo: number | string,
): Promise<{ vchNo: number; totals: { fine: number; metal: number; tax: number; net: number } }> {
  const tenantId = input.scope.tenantId;
  const isSale = input.side === 'SALE';
  const book = input.scope.coBook ?? (isSale ? 'FSL' : 'FPR');
  const no = Number(vchNo);
  const key = keyOf({ ...input.scope, coBook: book }, no, book);
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseFineSaleTx(tx, tenantId, key, input.side, 'system');
    return createFineSalePurchase(prisma, input, { tx, forceVchNo: no });
  });
}

/**
 * Reopen a Fine Sale / Fine Purchase (N121): read the CUT_DATA header + CUT_DETL lines back into the
 * same shape the create endpoint accepts, so a trained operator can reload the voucher (mirrors
 * TR_FINE_SL_PR.cs:4288 reading RATE_PAR and the stored lines back into the form).
 */
export async function getFineSalePurchase(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
): Promise<{
  vchNo: string;
  side: 'SALE' | 'PURC';
  vchDate: string;
  partyAc: string;
  partyName: string | null;
  itType: 'G' | 'S';
  taxPct: number;
  interState: boolean;
  totals: { metal: number; tax: number; net: number };
  lines: Array<{
    srNo: number;
    itType: 'G' | 'S';
    fineWt: number;
    fineRate: number;
    taxPct: number;
    metal: number;
    net: number;
  }>;
} | null> {
  const tenantId = scope.tenantId;
  const book = scope.coBook ?? 'FSL';
  const key = keyOf({ ...scope, coBook: book }, Number(vchNo), book);
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CUT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
      tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_YEAR,
      key.CO_BOOK,
      key.VCH_NO,
    );
    if (!h.length) return null;
    const header = h[0];
    const d: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CUT_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_YEAR,
      key.CO_BOOK,
      key.VCH_NO,
    );
    const isSale = String(header.INOUT_TYPE ?? '').toUpperCase() === 'O';
    const lines = d.map((row) => ({
      srNo: num(row.SR_NO),
      itType: (String(row.IT_TYPE ?? 'G').toUpperCase() === 'S' ? 'S' : 'G') as 'G' | 'S',
      // on a sale the fine is stored as CR_FINE, on a purchase as DR_FINE
      fineWt: r3(num(row.CR_FINE) || num(row.DR_FINE)),
      fineRate: num(row.FINE_RATE),
      taxPct: num(row.TAX_PRC),
      metal: r2(num(row.TOT_AMT)),
      net: r2(num(row.NET_AMT)),
    }));
    return {
      vchNo: key.VCH_NO,
      side: isSale ? 'SALE' : 'PURC',
      vchDate: isoDate(header.VCH_DATE),
      partyAc: String(header.AC_CODE ?? ''),
      partyName: header.AC_NAME ?? null,
      itType: String(header.IT_TYPE ?? 'G').toUpperCase() === 'S' ? 'S' : 'G',
      taxPct: num(header.TAX_PRC),
      interState: num(header.IGST_TAX) > 0,
      totals: {
        metal: r2(num(header.NET_AMT)),
        tax: r2(num(header.TAX_AMT)),
        net: r2(num(header.TOT_AMT)),
      },
      lines,
    };
  });
}
