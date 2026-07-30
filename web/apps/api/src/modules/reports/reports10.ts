import { dateWhere } from './reports.js';
import { withTenant } from '@datacare/db';
import type { ReportScope, ListReport } from './reports.js';

/**
 * Phase 12 (parity gap) — three desktop-only PURCHASE-side reports that complement the existing
 * sales reports (salesByParty / monthlySales in reports.ts, customerCrm in reports9.ts), built in
 * the exact style of reports.ts … reports9.ts: withTenant() supplies the e2e-safe tenant context,
 * NN() casts the desktop's (text-typed) amount columns to numeric, every dataset is scoped by
 * WHERE "CO_CODE"=$1 (plus the optional CO_YEAR, since the voucher tables are fiscal-year keyed)
 * and returns the uniform ListReport { rows, totals } shape. All queries are read-only.
 *
 * Columns confirmed live via information_schema (datacare DB):
 *   PR_DATA  : CO_CODE, CO_YEAR, CO_BOOK, LC_CODE, VCH_NO, VCH_DATE, AC_CODE, AC_NAME,
 *              NET_AMT / TAX_AMT / TOT_AMT (text-typed amounts → NN()).
 *   TAX_DATA : CO_CODE, CO_YEAR, VCH_DATE, AC_CODE, TRAN_TYPE, TAX_PRC, NET_AMT, TAX_AMT.
 *   AC_MAST  : CO_CODE, AC_CODE, AC_NAME. The PR_DATA↔AC_MAST supplier join is on
 *              ("CO_CODE","AC_CODE"), same as outstandingReport / customerCrm.
 *
 * NOTE on TRAN_TYPE: the desktop spec documents 'PR' for purchase input GST, but live verification
 * of TAX_DATA showed the actual marker in this DB is 'P' (CO_BOOK='041', BOOK_NAME='PURCHASE',
 * TAX_SIGN='-'); 'S' is sales output GST. We therefore match TRAN_TYPE IN ('P','PR') so the
 * register is correct whether the deployment stores 'P' or 'PR' (with 'PR' only it would be empty).
 * Cross-check: the 'P' input GST for 2024-07 (34022.58) ties to PR_DATA's July TAX_AMT (34022.58).
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/**
 * Purchase by party (desktop purchase ledger summary) — PR_DATA grouped by supplier AC_CODE,
 * LEFT JOINed to AC_MAST for the master name. Per party: bills = count of DISTINCT VCH_NO,
 * netValue = Σ NET_AMT, taxValue = Σ TAX_AMT, totalValue = Σ TOT_AMT. Ordered by totalValue desc,
 * top 200. Scoped by CO_CODE and the optional CO_YEAR. totals reports { parties, totalValue } over
 * the returned rows. This is the purchase-side mirror of salesByParty in reports.ts.
 *
 * Live sanity (CO_CODE='01'): 50 parties, totalValue 2819954.00; top supplier 000219 "J K SONS"
 * — 2 bills, netValue 1063887.00, taxValue 31916.61, totalValue 1096900.00.
 */
export async function purchaseByParty(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const yr = s.coYear ? ' AND pd."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, 'pd."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT pd."AC_CODE" AS "acCode", max(m."AC_NAME") AS name, count(DISTINCT pd."VCH_NO")::int AS bills,
              sum(${NN('pd."NET_AMT"')}) AS "netValue", sum(${NN('pd."TAX_AMT"')}) AS "taxValue",
              sum(${NN('pd."TOT_AMT"')}) AS "totalValue"
       FROM "PR_DATA" pd LEFT JOIN "AC_MAST" m ON m."CO_CODE"=pd."CO_CODE" AND m."AC_CODE"=pd."AC_CODE"
       WHERE pd."CO_CODE"=$1${yr}${dt}
       GROUP BY pd."AC_CODE" ORDER BY "totalValue" DESC LIMIT 200`,
      ...params,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      name: r.name ?? null,
      bills: Number(r.bills),
      netValue: round2(num(r.netValue)),
      taxValue: round2(num(r.taxValue)),
      totalValue: round2(num(r.totalValue)),
    }));
    return {
      rows: out,
      totals: {
        parties: out.length,
        totalValue: round2(out.reduce((t, r) => t + r.totalValue, 0)),
      },
    };
  });
}

/**
 * Monthly purchase MIS (desktop purchase movement) — PR_DATA grouped by to_char(VCH_DATE,'YYYY-MM').
 * Per month: bills = count(*), netValue = Σ NET_AMT, taxValue = Σ TAX_AMT, totalValue = Σ TOT_AMT.
 * Ordered by month. Scoped by CO_CODE and the optional CO_YEAR; rows with a NULL VCH_DATE are
 * excluded, mirroring monthlySales in reports.ts. totals reports { months, totalValue } over the
 * returned rows. This is the purchase-side mirror of monthlySales.
 *
 * Live sanity (CO_CODE='01'): 4 months, totalValue 2819954.00 (2024-04 … 2024-07; peak 2024-07 =
 * 15 bills, netValue 1460243.00, taxValue 34022.58, totalValue 1495362.00).
 */
export async function monthlyPurchase(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const yr = s.coYear ? ' AND "CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT to_char("VCH_DATE"::timestamp,'YYYY-MM') AS month, count(*)::int AS bills,
              sum(${NN('"NET_AMT"')}) AS "netValue", sum(${NN('"TAX_AMT"')}) AS "taxValue",
              sum(${NN('"TOT_AMT"')}) AS "totalValue"
       FROM "PR_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "VCH_DATE" IS NOT NULL
       GROUP BY 1 ORDER BY 1`,
      ...params,
    );
    const out = rows.map((r) => ({
      month: r.month,
      bills: Number(r.bills),
      netValue: round2(num(r.netValue)),
      taxValue: round2(num(r.taxValue)),
      totalValue: round2(num(r.totalValue)),
    }));
    return {
      rows: out,
      totals: { months: out.length, totalValue: round2(out.reduce((t, r) => t + r.totalValue, 0)) },
    };
  });
}

/**
 * GST input / ITC register (desktop purchase GST return source) — TAX_DATA purchase-tax rows grouped
 * by to_char(VCH_DATE,'YYYY-MM'). Per month: taxable = Σ NET_AMT, inputGst = Σ TAX_AMT, entries =
 * count(*). Ordered by month. Scoped by CO_CODE and the optional CO_YEAR; NULL VCH_DATE excluded.
 * totals reports { months, inputGst } over the returned rows. See the TRAN_TYPE note above —
 * matched as IN ('P','PR'). TAX_DATA stores CGST/SGST as two rows per voucher, so inputGst is the
 * combined CGST+SGST (and ties to PR_DATA's TAX_AMT); taxable Σ NET_AMT is correspondingly the
 * two-row sum, exactly as the desktop GST register presents it. This is the purchase-side mirror of
 * the gstr3b outward summary in reports.ts.
 *
 * Live sanity (CO_CODE='01'): 1 month, inputGst 34022.58 (2024-07: taxable 2268172.00, 6 entries —
 * inputGst ties to monthlyPurchase 2024-07 taxValue 34022.58).
 */
export async function gstInputRegister(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const yr = s.coYear ? ' AND "CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT to_char("VCH_DATE"::timestamp,'YYYY-MM') AS month,
              sum(${NN('"NET_AMT"')}) AS taxable, sum(${NN('"TAX_AMT"')}) AS "inputGst",
              count(*)::int AS entries
       FROM "TAX_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "TRAN_TYPE" IN ('P','PR') AND "VCH_DATE" IS NOT NULL
       GROUP BY 1 ORDER BY 1`,
      ...params,
    );
    const out = rows.map((r) => ({
      month: r.month,
      taxable: round2(num(r.taxable)),
      inputGst: round2(num(r.inputGst)),
      entries: Number(r.entries),
    }));
    return {
      rows: out,
      totals: { months: out.length, inputGst: round2(out.reduce((t, r) => t + r.inputGst, 0)) },
    };
  });
}
