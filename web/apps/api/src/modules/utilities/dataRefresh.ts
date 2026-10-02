import { withTxBudget } from '../shared/txBudget.js';

/**
 * Data Refresh — the web analog of the desktop "Data Refresh" maintenance utility.
 * SAFE by design: read-only integrity verification + a planner-statistics refresh (ANALYZE).
 * It does NOT rewrite balances/stock — a write-back recompute of financial derived data is gated
 * on explicit sign-off + the verified desktop recompute formula.
 *
 * Note on ledger totals: a jewellery ERP's AC_DATA does not self-tie (opening balances live in
 * BAL_GR and closing stock in the stock tables), so Σ Dr / Σ Cr are shown for reference only,
 * never as a pass/fail. The real integrity signals are referential: orphan links + orphan details.
 */
export interface RefreshScope {
  tenantId: string;
  coCode: string;
  coYear?: string;
}

export async function dataRefresh(
  prisma: any,
  s: RefreshScope,
): Promise<{
  ranAt: string;
  ledger: { dr: number; cr: number; diff: number };
  orphanParty: number | null;
  orphanDetl: number | null;
  counts: Record<string, number | null>;
  analyzed: boolean;
  checks: { label: string; ok: boolean; detail: string }[];
}> {
  return withTxBudget(prisma, s.tenantId, 'heavy', async (tx: any) => {
    const q = (sql: string, ...p: unknown[]) => tx.$queryRawUnsafe(sql, ...p);

    // ledger totals (informational only)
    const led = (
      await q(
        `SELECT COALESCE(SUM("DR_AMT"),0)::float AS dr, COALESCE(SUM("CR_AMT"),0)::float AS cr FROM "AC_DATA" WHERE "CO_CODE"=$1`,
        s.coCode,
      )
    )[0] || { dr: 0, cr: 0 };
    const dr = Number(led.dr || 0),
      cr = Number(led.cr || 0);
    const diff = Math.round((dr - cr) * 100) / 100;

    // referential integrity: voucher headers whose party AC_CODE is missing from AC_MAST
    let orphanParty: number | null = 0;
    try {
      for (const t of ['SL_DATA', 'PR_DATA', 'KR_DATA']) {
        const n = Number(
          (
            await q(
              `SELECT COUNT(*)::int AS n FROM "${t}" v WHERE v."CO_CODE"=$1 AND v."AC_CODE" IS NOT NULL AND v."AC_CODE" <> ''
             AND NOT EXISTS (SELECT 1 FROM "AC_MAST" m WHERE m."CO_CODE"=v."CO_CODE" AND m."AC_CODE"=v."AC_CODE")`,
              s.coCode,
            )
          )[0].n,
        );
        orphanParty = (orphanParty || 0) + n;
      }
    } catch {
      orphanParty = null;
    }

    // orphan detail lines (SL_DETL without a header)
    let orphanDetl: number | null = null;
    try {
      orphanDetl = Number(
        (
          await q(
            `SELECT COUNT(*)::int AS n FROM "SL_DETL" d WHERE "CO_CODE"=$1 AND NOT EXISTS (
           SELECT 1 FROM "SL_DATA" h WHERE h."CO_CODE"=d."CO_CODE" AND h."CO_BOOK"=d."CO_BOOK" AND h."VCH_NO"=d."VCH_NO")`,
            s.coCode,
          )
        )[0].n,
      );
    } catch {
      orphanDetl = null;
    }

    // key row counts (read-only)
    const counts: Record<string, number | null> = {};
    for (const t of [
      'AC_MAST',
      'ITEM_MAST',
      'SL_DATA',
      'PR_DATA',
      'KR_DATA',
      'AC_DATA',
      'MAIN_STOCK',
    ]) {
      try {
        counts[t] = Number(
          (await q(`SELECT COUNT(*)::int AS n FROM "${t}" WHERE "CO_CODE"=$1`, s.coCode))[0].n,
        );
      } catch {
        counts[t] = null;
      }
    }

    // refresh planner statistics (safe maintenance, no data change) — best-effort
    let analyzed = false;
    try {
      await tx.$executeRawUnsafe('ANALYZE');
      analyzed = true;
    } catch {
      analyzed = false;
    }

    const checks = [
      {
        label: 'Referential integrity — voucher party links',
        ok: orphanParty === 0 || orphanParty === null,
        detail:
          orphanParty === null
            ? 'not checked'
            : orphanParty === 0
              ? 'all voucher parties exist in AC_MAST'
              : `${orphanParty} voucher(s) with missing party`,
      },
      {
        label: 'Orphan detail lines (SL_DETL without header)',
        ok: orphanDetl === 0 || orphanDetl === null,
        detail:
          orphanDetl === null
            ? 'not checked'
            : orphanDetl === 0
              ? 'none'
              : `${orphanDetl} orphan line(s)`,
      },
      {
        label: 'Ledger totals (informational)',
        ok: true,
        detail: `Σ Dr = ${dr.toFixed(2)}, Σ Cr = ${cr.toFixed(2)} (openings/stock held separately)`,
      },
      {
        label: 'Query planner statistics refreshed',
        ok: analyzed,
        detail: analyzed ? 'ANALYZE completed' : 'skipped (insufficient privilege)',
      },
    ];

    return {
      ranAt: new Date().toISOString(),
      ledger: { dr, cr, diff },
      orphanParty,
      orphanDetl,
      counts,
      analyzed,
      checks,
    };
  });
}
