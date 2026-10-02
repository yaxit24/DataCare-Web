import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { operationalInvariants } from '../src/modules/ops/invariants.js';
import { EXPECTED_MIGRATIONS } from '../src/modules/ops/migrationManifest.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const roleName = `ops_invariants_scratch_${process.pid}`;
const qRole = `"${roleName}"`;

databaseDescribe('operational invariants against the restricted database role', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    if (owner) {
      await owner.$executeRawUnsafe(`DROP OWNED BY ${qRole}`).catch(() => undefined);
      await owner.$executeRawUnsafe(`DROP ROLE IF EXISTS ${qRole}`).catch(() => undefined);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('reports the real forced-RLS count, append-only audit rights, and migration state', async () => {
    const actualRls: Array<{ tenant_tables: unknown; forced_tables: unknown }> =
      await runtime.$queryRawUnsafe(
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
      );
    const result = await operationalInvariants(runtime);

    expect(result.rls).toEqual({
      tenantTables: Number(actualRls[0]?.tenant_tables),
      forcedTables: Number(actualRls[0]?.forced_tables),
      safe: true,
    });
    expect(result.rls.forcedTables).toBeGreaterThan(0);
    expect(result.auditLog).toEqual({
      select: true,
      insert: true,
      update: false,
      delete: false,
      truncate: false,
      appendOnly: true,
    });
    expect(result.migrations).toEqual({
      expected: EXPECTED_MIGRATIONS.length,
      applied: EXPECTED_MIGRATIONS.length,
      missing: [],
      unexpected: [],
      checksumMismatch: [],
      incomplete: [],
      driftFree: true,
    });
    expect(result.healthy).toBe(true);
  });

  it('becomes unhealthy when a controlled scratch role lacks audit INSERT permission', async () => {
    await owner.$executeRawUnsafe(`DROP OWNED BY ${qRole}`).catch(() => undefined);
    await owner.$executeRawUnsafe(`DROP ROLE IF EXISTS ${qRole}`).catch(() => undefined);
    await owner.$executeRawUnsafe(`CREATE ROLE ${qRole} NOLOGIN`);
    await owner.$executeRawUnsafe(`GRANT USAGE ON SCHEMA public TO ${qRole}`);
    await owner.$executeRawUnsafe(`GRANT SELECT ON public."_prisma_migrations" TO ${qRole}`);
    await owner.$executeRawUnsafe(`GRANT SELECT ON public.audit_log TO ${qRole}`);

    const result = await owner.$transaction(async (tx) => {
      await tx.$executeRawUnsafe(`SET LOCAL ROLE ${qRole}`);
      return operationalInvariants(tx);
    });

    expect(result.rls.safe).toBe(true);
    expect(result.migrations.driftFree).toBe(true);
    expect(result.auditLog.insert).toBe(false);
    expect(result.auditLog.appendOnly).toBe(false);
    expect(result.healthy).toBe(false);
  });
});
