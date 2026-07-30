import { dateWhere } from './reports.js';
import { withTenant } from '@datacare/db';
import type { ReportScope, ListReport } from './reports.js';

/**
 * Phase 11 (cont.) — daily-sales, top-item and employee-sales report datasets, built in the exact
 * style of reports.ts / reports2.ts / reports3.ts / reports4.ts: withTenant() supplies the e2e-safe
 * tenant context, NN() casts the desktop's text-typed amount columns to numeric, coParams() applies
 * the optional CO_YEAR scope, and every dataset is scoped by WHERE "CO_CODE"=$1 and returns the
 * uniform ListReport { rows, totals } shape. All queries are read-only — no mutations.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const round3 = (x: number): number => Math.round((x + Number.EPSILON) * 1000) / 1000;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/** Optional financial-year scope: adds "CO_YEAR"=$2 when s.coYear is set (mirrors reports.ts coParams). */
const coParams = (s: ReportScope): { yr: string; params: unknown[] } =>
  s.coYear
    ? { yr: ' AND "CO_YEAR"=$2', params: [s.coCode, s.coYear] }
    : { yr: '', params: [s.coCode] };

/**
 * Daily sales summary (SL_DATA grouped by VCH_DATE, excludes returns book 'SRT'): one row per
 * sale-day with bill count, taxable (Σ NET_AMT), tax (Σ TAX_AMT) and gross (Σ TOT_AMT), ordered by
 * date. NULL voucher dates are excluded so the day buckets stay clean (matching monthlySales in
 * reports.ts). totals reports the day count and the grand gross total.
 */
export async function dailySalesSummary(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_DATE" AS date, count(*)::int AS bills,
              sum(${NN('"NET_AMT"')}) AS taxable, sum(${NN('"TAX_AMT"')}) AS tax, sum(${NN('"TOT_AMT"')}) AS total
       FROM "SL_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "CO_BOOK"<>'SRT' AND "VCH_DATE" IS NOT NULL
       GROUP BY "VCH_DATE" ORDER BY "VCH_DATE"`,
      ...params,
    );
    const out = rows.map((r) => ({
      date: r.date ?? null,
      bills: Number(r.bills),
      taxable: round2(num(r.taxable)),
      tax: round2(num(r.tax)),
      total: round2(num(r.total)),
    }));
    return {
      rows: out,
      totals: { days: out.length, total: round2(out.reduce((t, r) => t + r.total, 0)) },
    };
  });
}

/**
 * Top items by sales value (SL_DETL grouped by IT_CODE): line count, net weight (Σ ITM_NWT), fine
 * (Σ ITM_FINE) and amount (Σ NET_AMT) per item, ordered by amount descending and capped at the top
 * 50 (mirrors salesByItem in reports.ts, adding fine + the top-50 cap). totals reports the item
 * count (capped) and the summed amount of the returned rows.
 */
export async function topItems(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "IT_CODE" AS item, count(*)::int AS lines, sum(${NN('"ITM_NWT"')}) AS "netWt",
              sum(${NN('"ITM_FINE"')}) AS fine, sum(${NN('"NET_AMT"')}) AS amount
       FROM "SL_DETL" WHERE "CO_CODE"=$1 GROUP BY "IT_CODE" ORDER BY amount DESC NULLS LAST LIMIT 50`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      item: r.item,
      lines: Number(r.lines),
      netWt: round3(num(r.netWt)),
      fine: round3(num(r.fine)),
      amount: round2(num(r.amount)),
    }));
    return {
      rows: out,
      totals: { items: out.length, amount: round2(out.reduce((t, r) => t + r.amount, 0)) },
    };
  });
}

/**
 * Employee sales (SL_DATA grouped by EMP_CODE, excludes returns book 'SRT'): bill count and gross
 * (Σ TOT_AMT) per salesperson, ordered by gross descending. EMP_CODE was verified to exist on
 * SL_DATA (text type), so it is used directly as the grouping key — no AC_CODE salesman fallback is
 * needed. totals reports the employee count and the grand gross total.
 */
export async function employeeSales(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const { yr, params } = coParams(s);
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "EMP_CODE" AS employee, count(*)::int AS bills, sum(${NN('"TOT_AMT"')}) AS total
       FROM "SL_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "CO_BOOK"<>'SRT'
       GROUP BY "EMP_CODE" ORDER BY total DESC NULLS LAST`,
      ...params,
    );
    const out = rows.map((r) => ({
      employee: r.employee,
      bills: Number(r.bills),
      total: round2(num(r.total)),
    }));
    return {
      rows: out,
      totals: { employees: out.length, total: round2(out.reduce((t, r) => t + r.total, 0)) },
    };
  });
}
