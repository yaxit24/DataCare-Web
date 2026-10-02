import { dateWhere } from './reports.js';
import { withTxBudget } from '../shared/txBudget.js';
import type { ReportScope, ListReport } from './reports.js';
import { barTagAvailableSql } from '../shared/stockSql.js';
import { applyFilters } from './reportFilters.js';

/**
 * Phase 11 (cont.) — purchase-return, contra, area-outstanding and item-group-stock report
 * datasets, built in the exact style of reports.ts … reports5.ts: withTenant() supplies the
 * e2e-safe tenant context, NN() casts the desktop's text-typed amount columns to numeric, every
 * dataset is scoped by WHERE "CO_CODE"=$1 (plus the optional CO_YEAR) and returns the uniform
 * ListReport { rows, totals } shape. All queries are read-only — no mutations.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const round3 = (x: number): number => Math.round((x + Number.EPSILON) * 1000) / 1000;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/**
 * Purchase-return register — one row per purchase-return voucher (PR_DATA header).
 *
 * Adaptation (verified against the live schema): PR_DATA has NO VCH_TYPE column, so returns cannot
 * be flagged by VCH_TYPE='PRTN'. Purchase returns are instead identified by their book: BOOK_DATA
 * maps the return books to PR_DATA — "Purchase Return Gold" (048), "Purches Return Silver" (049) and
 * "Mrp Purchase Return" (103). We therefore select PR_DATA rows whose CO_BOOK resolves (via BOOK_DATA,
 * same CO_CODE) to a PR_DATA book whose name contains "return". taxable = NET_AMT, tax = TAX_AMT,
 * total = TOT_AMT (falling back to taxable+tax when the header total is blank). party is the header
 * AC_NAME, falling back to AC_CODE. Scoped by CO_CODE and the optional CO_YEAR. The '%return%'
 * literal is an internal constant (never user input).
 *
 * Live sanity (CO_CODE='01'): 0 rows — this dataset's PR_DATA holds only the purchase books
 * 035–043 (Gold/Silver/Old/Tax purchase); none of the return books 048/049/103 are present, so the
 * filter correctly returns an empty register (totals { count: 0, total: 0 }).
 */
export async function purchaseReturnRegister(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const yr = s.coYear ? ' AND p."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    // Voucher-date window; appended after params so the positional indices are right.
    const dt = dateWhere(s, 'p."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT p."VCH_DATE" AS date, p."CO_BOOK"||'/'||p."VCH_NO" AS voucher,
              coalesce(NULLIF(p."AC_NAME"::text,''), p."AC_CODE") AS party,
              ${NN('p."NET_AMT"')} AS taxable, ${NN('p."TAX_AMT"')} AS tax,
              CASE WHEN ${NN('p."TOT_AMT"')} <> 0 THEN ${NN('p."TOT_AMT"')}
                   ELSE ${NN('p."NET_AMT"')} + ${NN('p."TAX_AMT"')} END AS total
       FROM "PR_DATA" p
       WHERE p."CO_CODE"=$1${yr}${dt}
         AND EXISTS (SELECT 1 FROM "BOOK_DATA" b
                       WHERE b."CO_CODE"::text=p."CO_CODE"::text AND b."CO_BOOK"::text=p."CO_BOOK"::text
                         AND b."BOOK_TBL_NAME"='PR_DATA' AND b."BOOK_NAME" ILIKE '%return%')
       ORDER BY p."VCH_DATE", p."VCH_NO"`,
      ...params,
    );
    const out = rows.map((r) => ({
      date: r.date ?? null,
      voucher: String(r.voucher ?? ''),
      party: r.party ?? null,
      taxable: round2(num(r.taxable)),
      tax: round2(num(r.tax)),
      total: round2(num(r.total)),
    }));
    return {
      rows: out,
      totals: { count: out.length, total: round2(out.reduce((t, r) => t + r.total, 0)) },
    };
  });
}

/**
 * Contra register — one row per cash/bank transfer voucher (the contra "Contra Entry" book).
 *
 * Adaptation (verified against the live schema): the canonical CONTRA_DATA table is EMPTY in this
 * dataset, so the contra postings are read from the ledger (AC_DATA), where each contra voucher
 * lives under a book whose BOOK_DATA name contains "contra" ("Contra Entry" 017, "Contra Entry 1"
 * 214 — both keyed to CONTRA_DATA). A contra voucher has two ledger legs: the credited account
 * (CR_AMT > 0) is the money source (fromAc) and the debited account (DR_AMT > 0) is the destination
 * (toAc). AC_DATA carries no AC_NAME, so each leg's name is resolved from AC_MAST (falling back to
 * AC_CODE). amount = Σ DR_AMT per voucher (= Σ CR_AMT, the transferred value). Scoped by CO_CODE and
 * the optional CO_YEAR. The '%contra%' literal is an internal constant (never user input).
 *
 * Live sanity (CO_CODE='01'): 37 vouchers, total amount 1035445.40; e.g. 017/00001 fromAc
 * "JASHRAJ PG…" → toAc "JASHRAJ DHAKAN", amount 11957.00.
 */
export async function contraRegister(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const yr = s.coYear ? ' AND d."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    // Voucher-date window; appended after params so the positional indices are right.
    const dt = dateWhere(s, 'd."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT d."VCH_DATE" AS date, d."CO_BOOK"||'/'||d."VCH_NO" AS voucher,
              max(CASE WHEN ${NN('d."CR_AMT"')} > 0
                       THEN coalesce((SELECT m."AC_NAME" FROM "AC_MAST" m
                                        WHERE m."AC_CODE"::text=d."AC_CODE"::text AND m."CO_CODE"::text=d."CO_CODE"::text LIMIT 1),
                                     d."AC_CODE") END) AS "fromAc",
              max(CASE WHEN ${NN('d."DR_AMT"')} > 0
                       THEN coalesce((SELECT m."AC_NAME" FROM "AC_MAST" m
                                        WHERE m."AC_CODE"::text=d."AC_CODE"::text AND m."CO_CODE"::text=d."CO_CODE"::text LIMIT 1),
                                     d."AC_CODE") END) AS "toAc",
              sum(${NN('d."DR_AMT"')}) AS amount
       FROM "AC_DATA" d
       WHERE d."CO_CODE"=$1${yr}${dt}
         AND EXISTS (SELECT 1 FROM "BOOK_DATA" b
                       WHERE b."CO_CODE"::text=d."CO_CODE"::text AND b."CO_BOOK"::text=d."CO_BOOK"::text
                         AND b."BOOK_NAME" ILIKE '%contra%')
       GROUP BY d."CO_BOOK", d."VCH_NO", d."VCH_DATE"
       ORDER BY d."VCH_DATE", d."VCH_NO"`,
      ...params,
    );
    const out = rows.map((r) => ({
      date: r.date ?? null,
      voucher: String(r.voucher ?? ''),
      fromAc: r.fromAc ?? null,
      toAc: r.toAc ?? null,
      amount: round2(num(r.amount)),
    }));
    return {
      rows: out,
      totals: { count: out.length, amount: round2(out.reduce((t, r) => t + r.amount, 0)) },
    };
  });
}

/**
 * Area-wise outstanding (BILL_OS_DATA joined to AC_MAST): per city/area, balance = Σ (BILL_AMT −
 * REC_AMT). AC_CITY / AC_AREA live on AC_MAST (resolved via AC_CODE), not on BILL_OS_DATA; empty
 * city/area collapses to '(none)'. Near-zero net groups are dropped (matching billOutstanding in
 * reports.ts). Ordered by balance descending. Scoped by CO_CODE and the optional CO_YEAR.
 *
 * Live sanity (CO_CODE='01'): top area VISAVADAR ≈ 4542951.00 across 154 bills.
 */
export async function areaOutstanding(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const yr = s.coYear ? ' AND b."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, 'b."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(NULLIF(m."AC_CITY",''),'(none)') AS city,
              coalesce(NULLIF(m."AC_AREA",''),'(none)') AS area,
              count(*)::int AS bills,
              sum(${NN('b."BILL_AMT"')} - ${NN('b."REC_AMT"')}) AS balance
       FROM "BILL_OS_DATA" b
       LEFT JOIN "AC_MAST" m ON m."AC_CODE"::text=b."AC_CODE"::text AND m."CO_CODE"::text=b."CO_CODE"::text
       WHERE b."CO_CODE"=$1${yr}${dt}
       GROUP BY 1, 2 ORDER BY balance DESC NULLS LAST`,
      ...params,
    );
    const out = rows
      .map((r) => ({
        city: r.city,
        area: r.area,
        bills: Number(r.bills),
        balance: round2(num(r.balance)),
      }))
      .filter((r) => Math.abs(r.balance) > 0.005);
    return {
      rows: out,
      totals: { areas: out.length, balance: round2(out.reduce((t, r) => t + r.balance, 0)) },
    };
  });
}

/**
 * Item-group stock (BAR_DETL tag inventory joined to ITEM_MAST): per item group, tag count, net
 * weight (Σ ITM_NWT) and fine (Σ ITM_FINE). The group is ITEM_MAST's GR_CODE (verified to exist),
 * falling back to the first two characters of IT_CODE for tags whose item is not in ITEM_MAST, then
 * '(none)'. Sold tags are excluded the same way stockValuation does in reports.ts — via NOT EXISTS
 * against a MAIN_STOCK '-' (outward) movement for the tag. Ordered by net weight descending. Scoped
 * by CO_CODE.
 *
 * Live sanity (CO_CODE='01'): group 925 ≈ 471 tags / netWt 7381.890 / fine 7280.320 (top group).
 */
export async function itemGroupStock(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    // BAR_DETL d and ITEM_MAST i are real outer LEFT JOINs; BAR_DETL carries no EMP_CODE.
    const params: unknown[] = [s.coCode];
    const fl = applyFilters('item-group-stock', s.filters, params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(NULLIF(i."GR_CODE",''), left(d."IT_CODE", 2), '(none)') AS "group",
              count(*)::int AS tags,
              sum(${NN('d."ITM_NWT"')}) AS "netWt",
              sum(${NN('d."ITM_FINE"')}) AS fine
       FROM "BAR_DETL" d
       LEFT JOIN "ITEM_MAST" i ON i."IT_CODE"::text=d."IT_CODE"::text AND i."CO_CODE"::text=d."CO_CODE"::text
       WHERE d."CO_CODE"=$1
         AND ${barTagAvailableSql('d')}${fl}
       GROUP BY 1 ORDER BY "netWt" DESC NULLS LAST`,
      ...params,
    );
    const out = rows.map((r) => ({
      group: r.group,
      tags: Number(r.tags),
      netWt: round3(num(r.netWt)),
      fine: round3(num(r.fine)),
    }));
    return {
      rows: out,
      totals: { groups: out.length, netWt: round3(out.reduce((t, r) => t + r.netWt, 0)) },
    };
  });
}
