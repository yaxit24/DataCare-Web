import { dateWhere } from './reports.js';
import { withTxBudget } from '../shared/txBudget.js';
import type { ReportScope, ListReport } from './reports.js';

/**
 * Phase 11 (final) — trial-balance (full), sales-by-group and cash/bank day-summary report
 * datasets, built in the exact style of reports.ts … reports7.ts: withTenant() supplies the
 * e2e-safe tenant context, NN() casts the desktop's text-typed amount columns to numeric, every
 * dataset is scoped by WHERE "CO_CODE"=$1 (plus the optional CO_YEAR where the source table is
 * fiscal-year keyed) and returns the uniform ListReport { rows, totals } shape. All queries are
 * read-only — no mutations.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const round3 = (x: number): number => Math.round((x + Number.EPSILON) * 1000) / 1000;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/**
 * Trial balance (full) — one row per ledger account (AC_DATA grouped by AC_CODE): dr (Σ DR_AMT),
 * cr (Σ CR_AMT) and balance (dr − cr), with the account name resolved from AC_MAST via a correlated
 * subquery (the required name source). CO_CODE is added to GROUP BY so the name subquery can match
 * per company without splitting groups (CO_CODE is fixed by the WHERE, so grouping cardinality is
 * unchanged). Rows are ordered by absolute balance descending (largest movers first). Scoped by
 * CO_CODE and the optional CO_YEAR. totals reports the account count and the grand Σ dr / Σ cr.
 *
 * On "ties": a textbook trial balance has Σ dr = Σ cr. This jewellery ERP holds closing stock
 * OUTSIDE the ledger (see balanceSheet in reports.ts), so AC_DATA alone does NOT tie exactly — the
 * residual Σ cr − Σ dr is the off-ledger closing-stock / trading figure.
 *
 * Live sanity (CO_CODE='01'): 300 accounts, Σ dr 55180589.47, Σ cr 56302194.65 (gap 1121605.18 —
 * the off-ledger closing stock); top account by |balance| is 000858 "JAN - 24 TO DEC - 25",
 * balance −8781900.00.
 */
export async function trialBalanceFull(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const yr = s.coYear ? ' AND d."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    const dt = dateWhere(s, 'd."VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT d."AC_CODE" AS "acCode",
              (SELECT m."AC_NAME" FROM "AC_MAST" m
                 WHERE m."AC_CODE"::text=d."AC_CODE"::text AND m."CO_CODE"::text=d."CO_CODE"::text LIMIT 1) AS name,
              sum(${NN('d."DR_AMT"')}) AS dr, sum(${NN('d."CR_AMT"')}) AS cr
       FROM "AC_DATA" d WHERE d."CO_CODE"=$1${yr}${dt}
       GROUP BY d."AC_CODE", d."CO_CODE"
       ORDER BY abs(sum(${NN('d."DR_AMT"')}) - sum(${NN('d."CR_AMT"')})) DESC`,
      ...params,
    );
    const out = rows.map((r) => {
      const dr = round2(num(r.dr));
      const cr = round2(num(r.cr));
      return { acCode: r.acCode, name: r.name ?? r.acCode, dr, cr, balance: round2(dr - cr) };
    });
    return {
      rows: out,
      totals: {
        accounts: out.length,
        dr: round2(out.reduce((t, r) => t + r.dr, 0)),
        cr: round2(out.reduce((t, r) => t + r.cr, 0)),
      },
    };
  });
}

/**
 * Sales by item-group (SL_DETL joined to ITEM_MAST): per item group — line count, net weight
 * (Σ ITM_NWT), fine (Σ ITM_FINE) and amount (Σ NET_AMT). The group is ITEM_MAST's GR_CODE (verified
 * to exist — the same group key used by itemGroupStock in reports6.ts), falling back to the first
 * two characters of IT_CODE for lines whose item is not in ITEM_MAST, then '(none)'. Ordered by
 * amount descending. Scoped by CO_CODE. totals reports the group count and the grand Σ amount.
 *
 * Live sanity (CO_CODE='01'): 11 groups, Σ amount 5334847.00; top group 916 — 75 lines, netWt
 * 519.923, fine 535.382, amount 4007292.00.
 */
export async function salesByGroup(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(NULLIF(i."GR_CODE",''), left(d."IT_CODE", 2), '(none)') AS "group",
              count(*)::int AS lines,
              sum(${NN('d."ITM_NWT"')}) AS "netWt",
              sum(${NN('d."ITM_FINE"')}) AS fine,
              sum(${NN('d."NET_AMT"')}) AS amount
       FROM "SL_DETL" d
       LEFT JOIN "ITEM_MAST" i ON i."IT_CODE"::text=d."IT_CODE"::text AND i."CO_CODE"::text=d."CO_CODE"::text
       WHERE d."CO_CODE"=$1
       GROUP BY 1 ORDER BY amount DESC NULLS LAST`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      group: r.group,
      lines: Number(r.lines),
      netWt: round3(num(r.netWt)),
      fine: round3(num(r.fine)),
      amount: round2(num(r.amount)),
    }));
    return {
      rows: out,
      totals: { groups: out.length, amount: round2(out.reduce((t, r) => t + r.amount, 0)) },
    };
  });
}

/**
 * Cash / bank day-summary (AC_DATA filtered to cash/bank accounts, grouped by VCH_DATE): per day —
 * inAmt (Σ DR_AMT, money in), outAmt (Σ CR_AMT, money out) and net (in − out). An account is treated
 * as cash/bank when its AC_CODE matches CASH/BANK, or its AC_MAST name contains CASH/BANK (the same
 * cash/bank rule as cashBook in reports2.ts, broadened to also match BANK on the code side). Ordered
 * by date. Scoped by CO_CODE. totals reports the day count and the grand Σ inAmt / Σ outAmt.
 *
 * Live sanity (CO_CODE='01'): 120 days, Σ inAmt 25069253.24, Σ outAmt 17364838.72; first day
 * 2024-03-31 — inAmt 9669228.10, outAmt 3109303.88, net 6559924.22.
 */
export async function cashDaySummary(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT d."VCH_DATE" AS date,
              sum(${NN('d."DR_AMT"')}) AS "inAmt",
              sum(${NN('d."CR_AMT"')}) AS "outAmt"
       FROM "AC_DATA" d
       WHERE d."CO_CODE"=$1
         AND (d."AC_CODE"::text ILIKE '%CASH%' OR d."AC_CODE"::text ILIKE '%BANK%'
              OR EXISTS (SELECT 1 FROM "AC_MAST" m
                           WHERE m."AC_CODE"::text=d."AC_CODE"::text AND m."CO_CODE"::text=d."CO_CODE"::text
                             AND (m."AC_NAME" ILIKE '%CASH%' OR m."AC_NAME" ILIKE '%BANK%')))
       GROUP BY d."VCH_DATE" ORDER BY d."VCH_DATE"`,
      s.coCode,
    );
    const out = rows.map((r) => {
      const inAmt = round2(num(r.inAmt));
      const outAmt = round2(num(r.outAmt));
      return { date: r.date ?? null, inAmt, outAmt, net: round2(inAmt - outAmt) };
    });
    return {
      rows: out,
      totals: {
        days: out.length,
        inAmt: round2(out.reduce((t, r) => t + r.inAmt, 0)),
        outAmt: round2(out.reduce((t, r) => t + r.outAmt, 0)),
      },
    };
  });
}
