import { EXPECTED_MIGRATIONS } from './migrationManifest.js';

const bool = (value: unknown): boolean =>
  value === true || value === 't' || String(value ?? '').toLowerCase() === 'true';

export interface OperationalInvariants {
  healthy: boolean;
  checkedAt: string;
  rls: { forcedTables: number; tenantTables: number; safe: boolean };
  auditLog: {
    select: boolean;
    insert: boolean;
    update: boolean;
    delete: boolean;
    truncate: boolean;
    appendOnly: boolean;
  };
  migrations: {
    expected: number;
    applied: number;
    missing: string[];
    unexpected: string[];
    checksumMismatch: string[];
    incomplete: string[];
    driftFree: boolean;
  };
}

export async function operationalInvariants(prisma: any): Promise<OperationalInvariants> {
  const [rlsRows, auditRows, migrationRows] = await Promise.all([
    prisma.$queryRawUnsafe(
      `SELECT COUNT(*)::int AS tenant_tables,
              COUNT(*) FILTER (WHERE c.relrowsecurity AND c.relforcerowsecurity)::int AS forced_tables
         FROM pg_class c
         JOIN pg_namespace n ON n.oid = c.relnamespace
        WHERE n.nspname = 'public'
          AND c.relkind IN ('r','p')
          AND EXISTS (
            SELECT 1 FROM pg_attribute a
             WHERE a.attrelid = c.oid AND a.attname = 'tenant_id' AND NOT a.attisdropped
          )`,
    ),
    prisma.$queryRawUnsafe(
      `SELECT has_table_privilege(current_user, 'public.audit_log', 'SELECT') AS can_select,
              has_table_privilege(current_user, 'public.audit_log', 'INSERT') AS can_insert,
              has_table_privilege(current_user, 'public.audit_log', 'UPDATE') AS can_update,
              has_table_privilege(current_user, 'public.audit_log', 'DELETE') AS can_delete,
              has_table_privilege(current_user, 'public.audit_log', 'TRUNCATE') AS can_truncate`,
    ),
    prisma.$queryRawUnsafe(
      // `prisma migrate resolve --applied` marks the failed attempt rolled back and inserts a SECOND row
      // with the same name, so a name can legitimately appear twice. Ordering by name alone leaves the tie
      // unspecified, and because the rows are collapsed into a Map keyed by name, whichever arrived last
      // would win — making the health verdict differ between runs on identical data.
      //
      // Rolled-back attempts are therefore excluded here: a rolled-back record is by definition not applied.
      // A migration present ONLY as a rolled-back row then correctly reports as missing rather than silently
      // counting as applied.
      `SELECT migration_name, checksum, finished_at, rolled_back_at
         FROM "_prisma_migrations"
        WHERE rolled_back_at IS NULL
        ORDER BY migration_name, started_at`,
    ),
  ]);

  const rls = rlsRows[0] ?? {};
  const tenantTables = Number(rls.tenant_tables ?? 0);
  const forcedTables = Number(rls.forced_tables ?? 0);
  const rlsSafe = tenantTables > 0 && forcedTables === tenantTables;

  const permissions = auditRows[0] ?? {};
  const auditLog = {
    select: bool(permissions.can_select),
    insert: bool(permissions.can_insert),
    update: bool(permissions.can_update),
    delete: bool(permissions.can_delete),
    truncate: bool(permissions.can_truncate),
    appendOnly: false,
  };
  auditLog.appendOnly =
    auditLog.select &&
    auditLog.insert &&
    !auditLog.update &&
    !auditLog.delete &&
    !auditLog.truncate;

  const expected = new Map(EXPECTED_MIGRATIONS.map((row) => [row.name, row.checksum]));
  const applied = new Map<string, any>(
    migrationRows.map((row: any) => [String(row.migration_name), row]),
  );
  const missing = [...expected.keys()].filter((name) => !applied.has(name));
  const unexpected = [...applied.keys()].filter((name) => !expected.has(name));
  const checksumMismatch = [...expected].flatMap(([name, checksum]) => {
    const row = applied.get(name);
    return row && String(row.checksum) !== checksum ? [name] : [];
  });
  const incomplete = [...applied].flatMap(([name, row]) =>
    row.finished_at == null || row.rolled_back_at != null ? [name] : [],
  );
  const driftFree =
    missing.length === 0 &&
    unexpected.length === 0 &&
    checksumMismatch.length === 0 &&
    incomplete.length === 0;

  return {
    healthy: rlsSafe && auditLog.appendOnly && driftFree,
    checkedAt: new Date().toISOString(),
    rls: { forcedTables, tenantTables, safe: rlsSafe },
    auditLog,
    migrations: {
      expected: expected.size,
      applied: applied.size,
      missing,
      unexpected,
      checksumMismatch,
      incomplete,
      driftFree,
    },
  };
}
