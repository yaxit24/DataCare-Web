import { dateWhere } from './reports.js';
import { withTxBudget } from '../shared/txBudget.js';
import type { ReportScope, ListReport } from './reports.js';
import { barTagAvailableSql } from '../shared/stockSql.js';

/**
 * Phase 11 (cont.) — additional read-only report datasets, built in the exact style of reports.ts /
 * reports2.ts: withTenant() supplies the e2e-safe tenant context, NN() casts the desktop's
 * text-typed amount columns to numeric, every dataset returns the ListReport { rows, totals } shape,
 * and all queries are scoped by WHERE "CO_CODE"=$1 (with optional "CO_YEAR" where the source table
 * is fiscal-year keyed). No mutations.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const round3 = (x: number): number => Math.round((x + Number.EPSILON) * 1000) / 1000;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/**
 * Monthly GST sales summary (SL_DATA grouped by VCH_DATE month, SALES books only):
 * taxable = Σ NET_AMT, the CGST/SGST/IGST split, and tax = Σ TAX_AMT per YYYY-MM.
 * Optional fiscal-year scope ("CO_YEAR").
 */
export async function salesGstMonthly(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const yr = s.coYear ? ' AND "CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT to_char("VCH_DATE"::timestamp,'YYYY-MM') AS month,
              sum(${NN('"NET_AMT"')}) AS taxable, sum(${NN('"CGST_TAX"')}) AS cgst,
              sum(${NN('"SGST_TAX"')}) AS sgst, sum(${NN('"IGST_TAX"')}) AS igst, sum(${NN('"TAX_AMT"')}) AS tax
       FROM "SL_DATA" WHERE "CO_CODE"=$1${yr}${dt} AND "CO_BOOK" IN (SELECT b."CO_BOOK" FROM "BOOK_DATA" b WHERE b."CO_CODE"=$1 AND b."MAIN_BOOK"='SALES') AND "VCH_DATE" IS NOT NULL
       GROUP BY 1 ORDER BY 1`,
      ...params,
    );
    const out = rows.map((r) => ({
      month: r.month,
      taxable: round2(num(r.taxable)),
      cgst: round2(num(r.cgst)),
      sgst: round2(num(r.sgst)),
      igst: round2(num(r.igst)),
      tax: round2(num(r.tax)),
    }));
    return {
      rows: out,
      totals: { months: out.length, tax: round2(out.reduce((t, r) => t + r.tax, 0)) },
    };
  });
}

/**
 * Bill ageing (BILL_OS_DATA): net balance per bill = BILL_AMT − REC_AMT, bucketed by age in days
 * (CURRENT_DATE − VCH_DATE) into 0-30 / 31-60 / 61-90 / 90+. Only bills with an outstanding net
 * balance are aged. All four buckets are always returned (zero-filled) in fixed order. Optional
 * fiscal-year scope ("CO_YEAR").
 */
export async function billAging(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const yr = s.coYear ? ' AND "CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT CASE WHEN age<=30 THEN '0-30' WHEN age<=60 THEN '31-60' WHEN age<=90 THEN '61-90' ELSE '90+' END AS bucket,
              count(*)::int AS bills, sum(balance) AS balance
       FROM (SELECT (CURRENT_DATE - "VCH_DATE") AS age, ${NN('"BILL_AMT"')} - ${NN('"REC_AMT"')} AS balance
             FROM "BILL_OS_DATA" WHERE "CO_CODE"=$1${yr} AND "VCH_DATE" IS NOT NULL) t
       WHERE abs(balance) > 0.005 GROUP BY 1`,
      ...params,
    );
    const by = new Map<string, { bills: number; balance: number }>();
    for (const r of rows)
      by.set(String(r.bucket), { bills: Number(r.bills), balance: round2(num(r.balance)) });
    const out = ['0-30', '31-60', '61-90', '90+'].map((bucket) => ({
      bucket,
      bills: by.get(bucket)?.bills ?? 0,
      balance: by.get(bucket)?.balance ?? 0,
    }));
    return { rows: out, totals: { balance: round2(out.reduce((t, r) => t + r.balance, 0)) } };
  });
}

/**
 * Live stock by location (BAR_DETL grouped by LC_CODE): tags on hand, Σ net weight and Σ fine.
 * A tag is excluded once it has been sold/issued out — i.e. a matching MAIN_STOCK movement with
 * ITM_SIGN='-' exists for the same TAG_NO (same NOT EXISTS rule as stockValuation in reports.ts).
 */
export async function stockByLocation(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(b."LC_CODE",'(none)') AS location, count(*)::int AS tags,
              coalesce(sum(${NN('b."ITM_NWT"')}),0) AS "netWt", coalesce(sum(${NN('b."ITM_FINE"')}),0) AS fine
       FROM "BAR_DETL" b WHERE b."CO_CODE"=$1 AND ${barTagAvailableSql('b')}
       GROUP BY b."LC_CODE" ORDER BY "netWt" DESC`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      location: r.location,
      tags: Number(r.tags),
      netWt: round3(num(r.netWt)),
      fine: round3(num(r.fine)),
    }));
    return {
      rows: out,
      totals: { locations: out.length, netWt: round3(out.reduce((t, r) => t + r.netWt, 0)) },
    };
  });
}

/**
 * Purchase by item (PR_DETL grouped by IT_CODE): line count, Σ net weight, Σ fine and Σ NET_AMT
 * per item, ordered by amount (top 50).
 */
export async function purchaseByItem(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "IT_CODE" AS item, count(*)::int AS lines, sum(${NN('"ITM_NWT"')}) AS "netWt",
              sum(${NN('"ITM_FINE"')}) AS fine, sum(${NN('"NET_AMT"')}) AS amount
       FROM "PR_DETL" WHERE "CO_CODE"=$1 GROUP BY "IT_CODE" ORDER BY amount DESC NULLS LAST LIMIT 50`,
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
