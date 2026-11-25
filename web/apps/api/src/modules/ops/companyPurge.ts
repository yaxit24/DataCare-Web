import { withTxBudget } from '../shared/txBudget.js';
/** D38: operator-only worker; no restore/purge HTTP route. Run once per day for each tenant. */
export function purgeDeletedCompanies(prisma: any, tenant: string) {
  return withTxBudget(prisma, tenant, 'heavy', async (tx: any) => {
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `company-identity:${tenant}`,
    );
    const due = await tx.$queryRawUnsafe(
      `SELECT "CO_CODE" FROM "CO_MAST" WHERE tenant_id=$1 AND deleted_at <= clock_timestamp()-interval '30 days' FOR UPDATE`,
      tenant,
    );
    // Only actual base tables with BOTH scope columns; quote catalog identifiers, bind all values.
    const tables = await tx.$queryRawUnsafe(
      `SELECT c.table_name FROM information_schema.columns c JOIN information_schema.tables t USING(table_schema,table_name) WHERE c.table_schema='public' AND t.table_type='BASE TABLE' AND c.column_name IN ('tenant_id','CO_CODE') GROUP BY c.table_name HAVING count(*)=2 ORDER BY c.table_name='CO_MAST',c.table_name`,
    );
    for (const company of due)
      for (const { table_name } of tables) {
        const table = String(table_name).replace(/"/g, '""');
        await tx.$executeRawUnsafe(
          `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
          tenant,
          company.CO_CODE,
        );
      }
    return { purged: due.map((c: any) => c.CO_CODE) };
  });
}
