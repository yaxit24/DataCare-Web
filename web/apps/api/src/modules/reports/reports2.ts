import { withTxBudget } from '../shared/txBudget.js';
import type { ReportScope, ListReport } from './reports.js';

/**
 * Phase 11 — additional read-only report datasets, built in the exact style of reports.ts:
 * withTenant() supplies the e2e-safe tenant context, NN() casts the desktop's text-typed amount
 * columns to numeric, and every dataset returns the ListReport { rows, totals } shape. All queries
 * are scoped by WHERE "CO_CODE"=$1. No mutations.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const round3 = (x: number): number => Math.round((x + Number.EPSILON) * 1000) / 1000;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/**
 * Cash / bank book (AC_DATA): every ledger movement on a cash or bank account. An account is treated
 * as cash/bank when its AC_CODE looks like CASH, or its AC_MAST name contains CASH/BANK. Particulars
 * is the account name resolved from AC_MAST. Dr/Cr footed in JS.
 */
export async function cashBook(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT d."VCH_DATE" AS date, d."CO_BOOK"||'/'||d."VCH_NO" AS voucher,
              (SELECT m."AC_NAME" FROM "AC_MAST" m
                 WHERE m."AC_CODE"::text=d."AC_CODE"::text AND m."CO_CODE"::text=d."CO_CODE"::text LIMIT 1) AS particulars,
              ${NN('d."DR_AMT"')} AS dr, ${NN('d."CR_AMT"')} AS cr
       FROM "AC_DATA" d
       WHERE d."CO_CODE"=$1
         AND (d."AC_CODE"::text ILIKE '%CASH%'
              OR EXISTS (SELECT 1 FROM "AC_MAST" m
                           WHERE m."AC_CODE"::text=d."AC_CODE"::text AND m."CO_CODE"::text=d."CO_CODE"::text
                             AND (m."AC_NAME" ILIKE '%CASH%' OR m."AC_NAME" ILIKE '%BANK%')))
       ORDER BY d."VCH_DATE", d."VCH_NO"`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      date: r.date ?? null,
      voucher: String(r.voucher ?? ''),
      particulars: r.particulars ?? null,
      dr: round2(num(r.dr)),
      cr: round2(num(r.cr)),
    }));
    return {
      rows: out,
      totals: {
        entries: out.length,
        dr: round2(out.reduce((t, r) => t + r.dr, 0)),
        cr: round2(out.reduce((t, r) => t + r.cr, 0)),
      },
    };
  });
}

/**
 * Party statement (AC_DATA): every movement for one account ordered by date, with a running balance
 * (cumulative Dr−Cr) computed in JS. The account is s.acCode when supplied, otherwise the first
 * account found for the company. closing = final running balance.
 */
export async function partyStatement(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    let acCode = (s as { acCode?: string }).acCode;
    if (!acCode) {
      const first: any[] = await tx.$queryRawUnsafe(
        `SELECT "AC_CODE" AS "acCode" FROM "AC_DATA"
          WHERE "CO_CODE"=$1 AND "AC_CODE" IS NOT NULL ORDER BY "AC_CODE" LIMIT 1`,
        s.coCode,
      );
      acCode = first[0]?.acCode != null ? String(first[0].acCode) : undefined;
    }
    if (!acCode) return { rows: [], totals: { dr: 0, cr: 0, closing: 0 } };
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_DATE" AS date, "CO_BOOK"||'/'||"VCH_NO" AS voucher, "VCH_TYPE" AS "vchType",
              ${NN('"DR_AMT"')} AS dr, ${NN('"CR_AMT"')} AS cr
       FROM "AC_DATA" WHERE "CO_CODE"=$1 AND "AC_CODE"::text=$2::text ORDER BY "VCH_DATE", "VCH_NO"`,
      s.coCode,
      acCode,
    );
    let balance = 0;
    const out = rows.map((r) => {
      const dr = round2(num(r.dr));
      const cr = round2(num(r.cr));
      balance = round2(balance + dr - cr);
      return {
        date: r.date ?? null,
        voucher: String(r.voucher ?? ''),
        vchType: r.vchType ?? null,
        dr,
        cr,
        balance,
      };
    });
    return {
      rows: out,
      totals: {
        dr: round2(out.reduce((t, r) => t + r.dr, 0)),
        cr: round2(out.reduce((t, r) => t + r.cr, 0)),
        closing: balance,
      },
    };
  });
}

/**
 * HSN / slab summary (SL_DETL grouped by TAX_PRC as the slab proxy): taxable = Σ NET_AMT and
 * tax = Σ (ITM_CGST_AMT + ITM_SGST_AMT + ITM_IGST_AMT) per slab.
 */
export async function hsnSummary(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT ${NN('"TAX_PRC"')} AS slab, count(*)::int AS lines,
              sum(${NN('"NET_AMT"')}) AS taxable,
              sum(${NN('"ITM_CGST_AMT"')}+${NN('"ITM_SGST_AMT"')}+${NN('"ITM_IGST_AMT"')}) AS tax
       FROM "SL_DETL" WHERE "CO_CODE"=$1 GROUP BY ${NN('"TAX_PRC"')} ORDER BY 1`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      slab: num(r.slab),
      lines: Number(r.lines),
      taxable: round2(num(r.taxable)),
      tax: round2(num(r.tax)),
    }));
    return {
      rows: out,
      totals: {
        slabs: out.length,
        taxable: round2(out.reduce((t, r) => t + r.taxable, 0)),
        tax: round2(out.reduce((t, r) => t + r.tax, 0)),
      },
    };
  });
}

/** Membership / scheme adjustments register (AD_ADJ): member & scheme credits/adjustments. */
export async function schemeAdjustments(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_DATE" AS date, "CO_BOOK"||'/'||"VCH_NO" AS voucher, "VCH_TYPE" AS type, "SCHM_CODE" AS scheme,
              "MEMB_CODE" AS member, "AC_NAME" AS party, ${NN('"MEMB_AMT"')} AS "membAmt",
              ${NN('"MEMB_BONUS"')} AS bonus, ${NN('"ADJ_AMT"')} AS "adjAmt", "SIGN" AS sign
       FROM "AD_ADJ" WHERE "CO_CODE"=$1 ORDER BY "VCH_DATE", "VCH_NO"`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      date: r.date,
      voucher: r.voucher,
      type: r.type,
      scheme: r.scheme,
      member: r.member,
      party: r.party,
      membAmt: round2(num(r.membAmt)),
      bonus: round2(num(r.bonus)),
      adjAmt: round2(num(r.adjAmt)),
      sign: r.sign,
    }));
    return {
      rows: out,
      totals: {
        entries: out.length,
        membAmt: round2(out.reduce((t, r) => t + r.membAmt, 0)),
        adjAmt: round2(out.reduce((t, r) => t + r.adjAmt, 0)),
      },
    };
  });
}

/** Item stock ledger (MAIN_STOCK): per item, total IN vs OUT movements (pcs + fine) and net. */
export async function itemStockLedger(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "IT_CODE" AS item,
              sum(CASE WHEN "ITM_SIGN"='+' THEN ${NN('"ITM_FINE"')} ELSE 0 END) AS "inFine",
              sum(CASE WHEN "ITM_SIGN"='-' THEN ${NN('"ITM_FINE"')} ELSE 0 END) AS "outFine",
              sum(CASE WHEN "ITM_SIGN"='+' THEN ${NN('"ITM_PCS"')} ELSE 0 END) AS "inPcs",
              sum(CASE WHEN "ITM_SIGN"='-' THEN ${NN('"ITM_PCS"')} ELSE 0 END) AS "outPcs",
              count(*)::int AS moves
       FROM "MAIN_STOCK" WHERE "CO_CODE"=$1 GROUP BY "IT_CODE" ORDER BY "IT_CODE"`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      item: r.item,
      inFine: round3(num(r.inFine)),
      outFine: round3(num(r.outFine)),
      netFine: round3(num(r.inFine) - num(r.outFine)),
      inPcs: round3(num(r.inPcs)),
      outPcs: round3(num(r.outPcs)),
      moves: Number(r.moves),
    }));
    return {
      rows: out,
      totals: {
        items: out.length,
        inFine: round3(out.reduce((t, r) => t + r.inFine, 0)),
        outFine: round3(out.reduce((t, r) => t + r.outFine, 0)),
        netFine: round3(out.reduce((t, r) => t + r.netFine, 0)),
      },
    };
  });
}
