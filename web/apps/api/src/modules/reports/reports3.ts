import { dateWhere } from './reports.js';
import { withTxBudget } from '../shared/txBudget.js';
import type { ReportScope, ListReport } from './reports.js';
import { applyFilters } from './reportFilters.js';

/**
 * Phase 11 (cont.) — purchase, account-group and inward-GST report datasets, built in the exact
 * style of reports.ts / reports2.ts: withTenant() supplies the e2e-safe tenant context, NN() casts
 * the desktop's text-typed amount columns to numeric, coParams() applies the optional CO_YEAR scope,
 * and every dataset is scoped by WHERE "CO_CODE"=$1. All queries are read-only — no mutations.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/** Optional financial-year scope: adds "CO_YEAR"=$2 when s.coYear is set (mirrors reports.ts coParams). */
const coParams = (s: ReportScope): { yr: string; params: unknown[] } =>
  s.coYear
    ? { yr: ' AND "CO_YEAR"=$2', params: [s.coCode, s.coYear] }
    : { yr: '', params: [s.coCode] };

/**
 * Monthly purchase MIS (PR_DATA grouped by YYYY-MM of VCH_DATE): bill count, taxable (Σ NET_AMT),
 * tax (Σ TAX_AMT) and gross (Σ TOT_AMT) per month. NULL voucher dates are excluded so the month
 * buckets stay clean (matching monthlySales in reports.ts).
 */
export async function monthlyPurchase(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT to_char("VCH_DATE"::timestamp,'YYYY-MM') AS month, count(*)::int AS bills,
              sum(${NN('"NET_AMT"')}) AS taxable, sum(${NN('"TAX_AMT"')}) AS tax, sum(${NN('"TOT_AMT"')}) AS total
       FROM "PR_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "VCH_DATE" IS NOT NULL
       GROUP BY 1 ORDER BY 1`,
      ...params,
    );
    const out = rows.map((r) => ({
      month: r.month,
      bills: Number(r.bills),
      taxable: round2(num(r.taxable)),
      tax: round2(num(r.tax)),
      total: round2(num(r.total)),
    }));
    return {
      rows: out,
      totals: { months: out.length, total: round2(out.reduce((t, r) => t + r.total, 0)) },
    };
  });
}

/**
 * Purchase by party (PR_DATA grouped by supplier AC_CODE, with AC_NAME): bill count and gross spend
 * (Σ TOT_AMT) per supplier, ordered by spend descending.
 */
export async function purchaseByParty(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    // PR_DATA is UNALIASED in this builder, so the table name qualifies the filter columns. (A second
    // function of the same name in reports10.ts is aliased `pd`; this is the one the route registers.)
    const fl = applyFilters('purchase-by-party', s.filters, params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" AS "acCode", max("AC_NAME") AS party, count(*)::int AS bills, sum(${NN('"TOT_AMT"')}) AS total
       FROM "PR_DATA" WHERE "CO_CODE"=$1${yr}${dt}${fl} GROUP BY "AC_CODE" ORDER BY total DESC NULLS LAST`,
      ...params,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      party: r.party,
      bills: Number(r.bills),
      total: round2(num(r.total)),
    }));
    return {
      rows: out,
      totals: { parties: out.length, total: round2(out.reduce((t, r) => t + r.total, 0)) },
    };
  });
}

/**
 * Trial balance grouped by account group (AC_DATA → AC_MAST → account-group master): per group
 * dr (Σ DR_AMT), cr (Σ CR_AMT) and net (dr − cr), ordered by debit.
 *
 * Adaptation (verified against the live schema): AC_MAST has no GR_CODE column — its account-group
 * code is "AC_GR". The account-group NAME master is "AC_GROUP" (key "AC_GR" → "AC_GR_NAME"). GROUP_MAST
 * is the metal/item-group master (its GR_CODE = 916/DM/FGL… does not key to AC_MAST) and is therefore
 * NOT used here. The group label falls back to the raw AC_GR code when AC_GROUP has no matching row.
 */
export async function groupSummary(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const yr = s.coYear ? ' AND d."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, 'd."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(g."AC_GR_NAME", m."AC_GR", '(unmapped)') AS "group",
              sum(${NN('d."DR_AMT"')}) AS dr, sum(${NN('d."CR_AMT"')}) AS cr
       FROM "AC_DATA" d
       LEFT JOIN "AC_MAST" m ON m."AC_CODE"::text=d."AC_CODE"::text AND m."CO_CODE"::text=d."CO_CODE"::text
       LEFT JOIN "AC_GROUP" g ON g."AC_GR"::text=m."AC_GR"::text AND g."CO_CODE"::text=m."CO_CODE"::text
       WHERE d."CO_CODE"=$1${yr}${dt}
       GROUP BY 1 ORDER BY dr DESC`,
      ...params,
    );
    const out = rows.map((r) => {
      const dr = round2(num(r.dr));
      const cr = round2(num(r.cr));
      return { group: r.group, dr, cr, net: round2(dr - cr) };
    });
    return {
      rows: out,
      totals: {
        groups: out.length,
        dr: round2(out.reduce((t, r) => t + r.dr, 0)),
        cr: round2(out.reduce((t, r) => t + r.cr, 0)),
      },
    };
  });
}

/**
 * GSTR-2 inward-supply (ITC) summary (PR_DATA): single-row totals of taxable (Σ NET_AMT) and tax
 * (Σ TAX_AMT) with the CGST/SGST/IGST split. Computed like gstr3b in reports.ts but for the inward
 * (purchase) side, and returned as a one-row ListReport — { rows: [summary], totals: summary } — to
 * keep the uniform return type for this reporting surface.
 */
export async function gstr2Purchase(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(${NN('"NET_AMT"')}),0) AS taxable, coalesce(sum(${NN('"TAX_AMT"')}),0) AS tax,
              coalesce(sum(${NN('"CGST_TAX"')}),0) AS cgst, coalesce(sum(${NN('"SGST_TAX"')}),0) AS sgst,
              coalesce(sum(${NN('"IGST_TAX"')}),0) AS igst
       FROM "PR_DATA" WHERE "CO_CODE"=$1${yr}${dt}`,
      ...params,
    );
    const x = r[0];
    const summary = {
      taxable: round2(num(x.taxable)),
      tax: round2(num(x.tax)),
      cgst: round2(num(x.cgst)),
      sgst: round2(num(x.sgst)),
      igst: round2(num(x.igst)),
    };
    return { rows: [summary], totals: summary };
  });
}
