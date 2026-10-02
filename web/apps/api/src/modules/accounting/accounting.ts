import { withTxBudget } from '../shared/txBudget.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';

/**
 * Read-only accounting datasets over AC_DATA (no writes): trial balance and account ledger /
 * statement with a running balance. All amounts are NUMERIC; we coerce to JS numbers at the edge.
 */

export interface ScopeFilter {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

export interface TrialBalanceRow {
  acCode: string;
  dr: number;
  cr: number;
  balance: number; // dr - cr (positive = debit balance)
}

export interface TrialBalance {
  accounts: TrialBalanceRow[];
  grandDr: number;
  grandCr: number;
  balanced: boolean;
}

const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

/** Pure: roll up raw per-account dr/cr sums into a trial balance with a Dr=Cr check (Req 14.x). */
export function summarizeTrialBalance(
  rows: { AC_CODE: string; dr: unknown; cr: unknown }[],
): TrialBalance {
  const accounts: TrialBalanceRow[] = rows.map((r) => {
    const dr = round2(Number(r.dr ?? 0));
    const cr = round2(Number(r.cr ?? 0));
    return { acCode: r.AC_CODE, dr, cr, balance: round2(dr - cr) };
  });
  const grandDr = round2(accounts.reduce((s, a) => s + a.dr, 0));
  const grandCr = round2(accounts.reduce((s, a) => s + a.cr, 0));
  return { accounts, grandDr, grandCr, balanced: grandDr === grandCr };
}

export interface LedgerRow {
  vchNo: string;
  vchType: string;
  vchDate: Date | null;
  dr: number;
  cr: number;
  runningBalance: number;
}

/** Pure: attach a running balance to ordered ledger rows, starting from an opening balance. */
export function applyRunningBalance(
  opening: number,
  rows: { VCH_NO: string; VCH_TYPE: string; VCH_DATE: Date | null; dr: unknown; cr: unknown }[],
): {
  opening: number;
  rows: LedgerRow[];
  closing: number;
} {
  let bal = round2(opening);
  const out: LedgerRow[] = rows.map((r) => {
    const dr = round2(Number(r.dr ?? 0));
    const cr = round2(Number(r.cr ?? 0));
    bal = round2(bal + dr - cr);
    return {
      vchNo: r.VCH_NO,
      vchType: r.VCH_TYPE,
      vchDate: r.VCH_DATE ?? null,
      dr,
      cr,
      runningBalance: bal,
    };
  });
  return { opening: round2(opening), rows: out, closing: bal };
}

function scopeSql(s: ScopeFilter, startIdx: number): { sql: string; params: unknown[] } {
  const parts = ['"CO_CODE"=$' + startIdx];
  const params: unknown[] = [s.coCode];
  let i = startIdx + 1;
  if (s.lcCode) {
    parts.push('"LC_CODE"=$' + i++);
    params.push(s.lcCode);
  }
  if (s.coYear) {
    parts.push('"CO_YEAR"=$' + i++);
    params.push(s.coYear);
  }
  return { sql: parts.join(' AND '), params };
}

/** Trial balance: per-AC_CODE Σ DR / Σ CR with a grand Dr=Cr check (live, RLS-scoped). */
export async function trialBalance(prisma: any, s: ScopeFilter): Promise<TrialBalance> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const w = scopeSql(s, 1);
    const rows: { AC_CODE: string; dr: unknown; cr: unknown }[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE", coalesce(sum("DR_AMT"),0) AS dr, coalesce(sum("CR_AMT"),0) AS cr
       FROM "AC_DATA" WHERE ${w.sql} GROUP BY "AC_CODE" ORDER BY "AC_CODE"`,
      ...w.params,
    );
    return summarizeTrialBalance(rows);
  });
}

export interface LedgerOptions {
  fromDate?: Date | string;
  toDate?: Date | string;
}

/**
 * Account ledger / statement for one AC_CODE: opening balance (everything before fromDate) + the
 * period's rows with a running balance computed by a SQL window function (Req 14.x, 19.x).
 */
export async function accountLedger(
  prisma: any,
  s: ScopeFilter,
  acCode: string,
  opts: LedgerOptions = {},
): Promise<{
  acCode: string;
  opening: number;
  rows: LedgerRow[];
  closing: number;
}> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const behavior = await resolveSettingsBehaviorTx(tx, {
      tenantId: s.tenantId,
      coCode: s.coCode,
    });
    const base = scopeSql(s, 2); // $1 reserved for AC_CODE
    const acParams = [acCode, ...base.params];

    // opening balance = net of everything strictly before fromDate (if given)
    let opening = 0;
    if (opts.fromDate) {
      const openRows: { ob: unknown }[] = await tx.$queryRawUnsafe(
        `SELECT coalesce(sum("DR_AMT"-"CR_AMT"),0) AS ob FROM "AC_DATA"
         WHERE "AC_CODE"=$1 AND ${base.sql} AND "VCH_DATE" < $${acParams.length + 1}`,
        ...acParams,
        new Date(opts.fromDate),
      );
      opening = Number(openRows[0]?.ob ?? 0);
    }

    // period rows with a window-function running balance
    const conds = [`"AC_CODE"=$1`, base.sql];
    const params = [...acParams];
    if (opts.fromDate) {
      conds.push(`"VCH_DATE" >= $${params.length + 1}`);
      params.push(new Date(opts.fromDate));
    }
    if (opts.toDate) {
      conds.push(`"VCH_DATE" <= $${params.length + 1}`);
      params.push(new Date(opts.toDate));
    }
    const rows: {
      VCH_NO: string;
      VCH_TYPE: string;
      VCH_DATE: Date | null;
      dr: unknown;
      cr: unknown;
      rb: unknown;
    }[] = await tx.$queryRawUnsafe(
      behavior.ledgerSummary
        ? `SELECT "VCH_NO", max("VCH_TYPE") AS "VCH_TYPE", "VCH_DATE",
                  sum("DR_AMT") AS dr, sum("CR_AMT") AS cr,
                  sum(sum("DR_AMT"-"CR_AMT")) OVER (ORDER BY "VCH_DATE","VCH_NO" ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS rb
             FROM "AC_DATA" WHERE ${conds.join(' AND ')}
            GROUP BY "VCH_DATE","VCH_NO" ORDER BY "VCH_DATE","VCH_NO"`
        : `SELECT "VCH_NO", "VCH_TYPE", "VCH_DATE", "DR_AMT" AS dr, "CR_AMT" AS cr,
                  sum("DR_AMT"-"CR_AMT") OVER (ORDER BY "VCH_DATE","VCH_NO" ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS rb
             FROM "AC_DATA" WHERE ${conds.join(' AND ')} ORDER BY "VCH_DATE","VCH_NO"`,
      ...params,
    );

    // fold the SQL window result into the opening offset for the reported running balance
    const folded = applyRunningBalance(opening, rows);
    return { acCode, opening: folded.opening, rows: folded.rows, closing: folded.closing };
  });
}
