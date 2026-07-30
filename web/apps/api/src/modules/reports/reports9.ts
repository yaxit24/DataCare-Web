import { dateWhere } from './reports.js';
import { withTenant } from '@datacare/db';
import type { ReportScope, ListReport } from './reports.js';

/**
 * Phase 11 (parity gap, audit-E) — three desktop-only reports that had no prior web equivalent,
 * built in the exact style of reports.ts … reports8.ts: withTenant() supplies the e2e-safe tenant
 * context, NN() casts the desktop's (text-typed) amount columns to numeric, every dataset is scoped
 * by WHERE "CO_CODE"=$1 (plus the optional CO_YEAR, since SL_DATA is fiscal-year keyed) and returns
 * the uniform ListReport { rows, totals } shape. All queries are read-only — no mutations.
 *
 * Columns confirmed live via information_schema (datacare DB):
 *   SL_DATA : CO_CODE, CO_YEAR, CO_BOOK, LC_CODE, VCH_NO (varchar), VCH_DATE (date), AC_CODE,
 *             NET_AMT / TAX_AMT / TOT_AMT (numeric).
 *   AC_MAST : CO_CODE, AC_CODE, AC_NAME, AC_CITY, AC_MOBILE, AC_AREA (all varchar).
 * The SL_DATA↔AC_MAST customer join is on ("CO_CODE","AC_CODE"), same as outstandingReport in
 * reports.ts.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/**
 * Customer CRM (desktop RP_CUST_CRM) — one row per customer drawn from the sales ledger SL_DATA,
 * LEFT JOINed to AC_MAST for the master name / city / mobile. Sales-return vouchers (CO_BOOK='SRT')
 * are excluded if present. Per customer: bills = count of DISTINCT VCH_NO, lastVisit = max VCH_DATE,
 * totalValue = Σ TOT_AMT. Ordered by totalValue desc, top 200. Scoped by CO_CODE and the optional
 * CO_YEAR. totals reports { customers, totalValue } over the returned rows.
 *
 * Live sanity (CO_CODE='01'): 126 customers, totalValue 5478196.00; top customer 001017
 * "MAHESHBHAI BABUBHAI GOHIL" (AMBALA, 9574066196) — 2 bills, lastVisit 2024-07-18, 467887.00.
 */
export async function customerCrm(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const yr = s.coYear ? ' AND sd."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, 'sd."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT sd."AC_CODE" AS "acCode", max(m."AC_NAME") AS name, max(m."AC_CITY") AS city,
              max(m."AC_MOBILE") AS mobile, count(DISTINCT sd."VCH_NO")::int AS bills,
              max(sd."VCH_DATE") AS "lastVisit", sum(${NN('sd."TOT_AMT"')}) AS "totalValue"
       FROM "SL_DATA" sd LEFT JOIN "AC_MAST" m ON m."CO_CODE"=sd."CO_CODE" AND m."AC_CODE"=sd."AC_CODE"
       WHERE sd."CO_CODE"=$1${yr}${dt} AND sd."CO_BOOK"<>'SRT'
       GROUP BY sd."AC_CODE" ORDER BY "totalValue" DESC LIMIT 200`,
      ...params,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      name: r.name ?? null,
      city: r.city ?? null,
      mobile: r.mobile ?? null,
      bills: Number(r.bills),
      lastVisit: r.lastVisit ?? null,
      totalValue: round2(num(r.totalValue)),
    }));
    return {
      rows: out,
      totals: {
        customers: out.length,
        totalValue: round2(out.reduce((t, r) => t + r.totalValue, 0)),
      },
    };
  });
}

/**
 * Area-wise sales (desktop RP_MOVEMENT, area pivot) — SL_DATA LEFT JOINed to AC_MAST and grouped by
 * the customer's area, coalesce(NULLIF(AC_AREA,''),'(none)') so blank/unmatched areas bucket into
 * '(none)'. Per area: bills = count(*), netValue = Σ NET_AMT, taxValue = Σ TAX_AMT, totalValue =
 * Σ TOT_AMT. Ordered by totalValue desc. Scoped by CO_CODE and the optional CO_YEAR. totals reports
 * { areas, totalValue } over the returned rows.
 *
 * Live sanity (CO_CODE='01'): 1 area ['(none)' — AC_AREA is blank for this dataset], 190 bills,
 * netValue 5334847.00, taxValue 143348.82, totalValue 5478196.00.
 */
export async function areaWiseSales(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const yr = s.coYear ? ' AND sd."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, 'sd."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(NULLIF(m."AC_AREA",''),'(none)') AS area, count(*)::int AS bills,
              sum(${NN('sd."NET_AMT"')}) AS "netValue", sum(${NN('sd."TAX_AMT"')}) AS "taxValue",
              sum(${NN('sd."TOT_AMT"')}) AS "totalValue"
       FROM "SL_DATA" sd LEFT JOIN "AC_MAST" m ON m."CO_CODE"=sd."CO_CODE" AND m."AC_CODE"=sd."AC_CODE"
       WHERE sd."CO_CODE"=$1${yr}${dt}
       GROUP BY 1 ORDER BY "totalValue" DESC`,
      ...params,
    );
    const out = rows.map((r) => ({
      area: r.area,
      bills: Number(r.bills),
      netValue: round2(num(r.netValue)),
      taxValue: round2(num(r.taxValue)),
      totalValue: round2(num(r.totalValue)),
    }));
    return {
      rows: out,
      totals: { areas: out.length, totalValue: round2(out.reduce((t, r) => t + r.totalValue, 0)) },
    };
  });
}

/**
 * Location-wise sales (desktop RP_MOVEMENT, location pivot) — SL_DATA grouped by LC_CODE,
 * coalesce("LC_CODE",'(none)'). Per location: bills = count(*), netValue = Σ NET_AMT, totalValue =
 * Σ TOT_AMT. Ordered by LC_CODE. Scoped by CO_CODE and the optional CO_YEAR. totals reports
 * { locations, totalValue } over the returned rows.
 *
 * Live sanity (CO_CODE='01'): 1 location ['00'], 190 bills, netValue 5334847.00,
 * totalValue 5478196.00.
 */
export async function locationWiseSales(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const yr = s.coYear ? ' AND "CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce("LC_CODE",'(none)') AS location, count(*)::int AS bills,
              sum(${NN('"NET_AMT"')}) AS "netValue", sum(${NN('"TOT_AMT"')}) AS "totalValue"
       FROM "SL_DATA" WHERE "CO_CODE"=$1${yr}${dt}
       GROUP BY "LC_CODE" ORDER BY "LC_CODE"`,
      ...params,
    );
    const out = rows.map((r) => ({
      location: r.location,
      bills: Number(r.bills),
      netValue: round2(num(r.netValue)),
      totalValue: round2(num(r.totalValue)),
    }));
    return {
      rows: out,
      totals: {
        locations: out.length,
        totalValue: round2(out.reduce((t, r) => t + r.totalValue, 0)),
      },
    };
  });
}
