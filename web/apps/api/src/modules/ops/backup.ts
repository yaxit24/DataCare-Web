import { withTenant } from '@datacare/db';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';

/** Logical company backup — exports the tenant's master + transaction tables to a JSON document
 *  (desktop UT_BKP equivalent for a single company). For full physical backups use deploy/backup.sh
 *  (pg_dump). RLS scopes every read to the tenant. */
export const COMPANY_BACKUP_TABLES = [
  'CO_MAST',
  'AC_MAST',
  'AC_GROUP',
  'ITEM_MAST',
  'GROUP_MAST',
  'PRODUCT_MAST',
  'RATE_MAST',
  'TAX_MAST',
  'BOOK_DATA',
  'EMP_MAST',
  'LOCT_MAST',
  'DESIGN_MAST',
  'STATE_MAST',
  'TABLE_MAST',
  'SL_DATA',
  'SL_DETL',
  'SL_IDTL',
  'SL_DETL_RTN',
  'SL_PR_DETL',
  'PR_DATA',
  'PR_DETL',
  'PAY_DATA',
  'PAY_DETL',
  'CASH_DATA',
  'CONTRA_DATA',
  'AC_DATA',
  'TAX_DATA',
  'SL_ORD_DATA',
  'SL_ORD_DETL',
  'SL_ORD_ADJ',
  'LBR_DATA',
  'LBR_ISU_DETL',
  'APR_DATA',
  'APR_DETL',
  'KR_DATA',
  'KR_DETL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'BAR_CAN_DATA',
  'BAR_CAN_DETL',
  'MAIN_STOCK',
  'ITM_OPBL',
  'OP_DATA',
  'BILL_OS_DATA',
  'TAG_STOCK',
  'POINT_MEMB',
  'POINT_DATA',
  'LOGIN_MAST',
  'USER_SET',
  'CO_SET',
  'SRNO_MAST',
  'YEAR_MAST',
];
const qid = (c: string): string => '"' + c.replace(/[^A-Za-z0-9_]/g, '') + '"';
const safe = (rows: Record<string, unknown>[]): Record<string, unknown>[] =>
  rows.map((r) =>
    Object.fromEntries(
      Object.entries(r).map(([k, v]) => [
        k,
        typeof v === 'bigint' ? v.toString() : Buffer.isBuffer(v) ? '[binary]' : v,
      ]),
    ),
  );

export async function backupCompany(
  prisma: any,
  tenantId: string,
  coCode: string,
): Promise<{
  generatedAt: string;
  tenant: string;
  company: string;
  databaseTarget: string;
  rowCount: number;
  tables: Record<string, unknown[]>;
}> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    const behavior = await resolveSettingsBehaviorTx(tx, { tenantId, coCode });
    const tables: Record<string, unknown[]> = {};
    let rowCount = 0;
    const companyTableRows: Array<{ table_name: string }> = await tx.$queryRawUnsafe(
      `SELECT table_name
         FROM information_schema.columns
        WHERE table_schema='public'
          AND column_name='CO_CODE'
          AND table_name = ANY($1::text[])`,
      [...COMPANY_BACKUP_TABLES],
    );
    const companyTables = new Set(companyTableRows.map((row) => row.table_name));
    for (const t of COMPANY_BACKUP_TABLES) {
      if (!companyTables.has(t)) {
        tables[t] = [];
        continue;
      }
      const rows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
        `SELECT * FROM ${qid(t)} WHERE "CO_CODE"::text=$1::text LIMIT 100000`,
        coCode,
      );
      tables[t] = safe(rows);
      rowCount += rows.length;
    }
    // UT_EXPORT.cs MsIpWith branches select the desktop source/destination; web records the validated target in the export payload.
    return {
      generatedAt: new Date().toISOString(),
      tenant: tenantId,
      company: coCode,
      databaseTarget: behavior.exportDatabaseTarget,
      rowCount,
      tables,
    };
  });
}

/**
 * Restore a company backup document into a tenant (desktop UT_BKP restore). Runs inside ONE tenant
 * transaction — every DELETE/INSERT is RLS-scoped to `tenantId`, so it can NEVER touch another
 * tenant's rows. `clear` (default true) wipes each table's tenant rows before re-inserting (a true
 * restore); set false to append. tenant_id on every row is forced to the target tenant; the serial
 * `row_id` is skipped so re-inserts don't collide. HIGH-RISK / admin-gated at the route.
 */
export async function restoreCompany(
  prisma: any,
  tenantId: string,
  doc: { tables?: Record<string, Record<string, unknown>[]> },
  opts?: { clear?: boolean },
): Promise<{ restored: number; tables: number; cleared: number }> {
  const clear = opts?.clear !== false;
  return withTenant(prisma, tenantId, async (tx: any) => {
    let restored = 0;
    let tables = 0;
    let cleared = 0;
    for (const t of COMPANY_BACKUP_TABLES) {
      const rows = (doc?.tables?.[t] ?? []) as Record<string, unknown>[];
      const colRows: { column_name: string }[] = await tx.$queryRawUnsafe(
        `SELECT column_name FROM information_schema.columns WHERE table_name=$1`,
        t,
      );
      const colset = new Set(colRows.map((c) => c.column_name));
      if (!colset.size) continue;
      if (clear) {
        await tx.$executeRawUnsafe(`DELETE FROM ${qid(t)}`);
        cleared += 1;
      } // RLS-scoped to this tenant only
      if (!rows.length) continue;
      tables += 1;
      for (const r of rows) {
        const keys = Object.keys(r).filter((k) => colset.has(k) && k !== 'row_id');
        if (!keys.length) continue;
        const vals = keys.map((k) => (k === 'tenant_id' ? tenantId : r[k]));
        const ph = keys.map((_, i) => `$${i + 1}`).join(',');
        // SAVEPOINT per row: a conflicting/incompatible row rolls back to the savepoint instead of
        // aborting the whole restore transaction (Postgres 25P02). ON CONFLICT DO NOTHING skips dups.
        await tx.$executeRawUnsafe('SAVEPOINT r');
        try {
          await tx.$executeRawUnsafe(
            `INSERT INTO ${qid(t)}(${keys.map(qid).join(',')}) VALUES (${ph}) ON CONFLICT DO NOTHING`,
            ...vals,
          );
          await tx.$executeRawUnsafe('RELEASE SAVEPOINT r');
          restored += 1;
        } catch {
          await tx.$executeRawUnsafe('ROLLBACK TO SAVEPOINT r');
        }
      }
    }
    return { restored, tables, cleared };
  });
}
