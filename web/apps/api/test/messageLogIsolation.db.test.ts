import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Tenant isolation of the message delivery log.
 *
 * THE DEFECT THIS PINS
 * --------------------
 * `20260715010000_runtime_schema_security` enables and forces row level security on every table carrying
 * `tenant_id`. `message_attempt_log` was created LATER, so that blanket pass never covered it: on any database
 * built by applying the migration chain in order, the table had a `tenant_id` column, no RLS and no policy.
 *
 * It was invisible on a long-lived development database, which had acquired RLS through unrelated history. It
 * surfaced only when a FRESH database was provisioned from the chain and diffed against the working one.
 *
 * Two statements in `messaging.ts` filtered on `idempotency_key` ALONE, so without RLS a colliding key gave a
 * cross-tenant READ of delivery status and provider reference, and a cross-tenant WRITE that overwrote another
 * tenant's row. Keys derived from voucher identifiers collide across tenants routinely.
 *
 * Both layers are asserted here: the table's own RLS/policy, and that a query filtering only on the key cannot
 * reach another tenant's row.
 */
d('message log tenant isolation', () => {
  const prisma = new PrismaClient();
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL } },
  });
  const A = 'msglog-tenant-a';
  const B = 'msglog-tenant-b';
  // Deliberately identical: the whole point is that a shared key must not cross the tenant boundary.
  const KEY = 'SL/00001';

  const clean = async () => {
    for (const t of [A, B]) {
      await owner.$executeRawUnsafe(`DELETE FROM "message_attempt_log" WHERE "tenant_id"=$1`, t);
    }
  };

  beforeEach(clean);
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
    await owner.$disconnect();
  });

  const insert = (tenant: string, status: string, ref: string) =>
    withTenant(prisma, tenant, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "message_attempt_log"
           ("tenant_id","co_code","lc_code","channel","recipient","template_kind",
            "idempotency_key","status","provider_reference")
         VALUES ($1,'01','01','whatsapp','+910000000000','invoice',$2,$3,$4)`,
        tenant,
        KEY,
        status,
        ref,
      ),
    );

  it('forces row level security with a tenant policy', async () => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT c.relrowsecurity AS rls, c.relforcerowsecurity AS forced,
              (SELECT count(*)::int FROM pg_policies p
                WHERE p.tablename='message_attempt_log' AND p.policyname='tenant_isolation') AS policies
         FROM pg_class c WHERE c.relname='message_attempt_log'`,
    )) as Array<{ rls: boolean; forced: boolean; policies: number }>;
    // FORCED matters: without it the table owner bypasses the policy, and the API's role may own the table.
    expect(rows[0]?.rls, 'row level security must be enabled').toBe(true);
    expect(rows[0]?.forced, 'row level security must be FORCED').toBe(true);
    expect(rows[0]?.policies, 'the tenant_isolation policy must exist').toBe(1);
  });

  it('does not leak another tenant’s row to a key-only query', async () => {
    await insert(A, 'sent', 'REF-A');
    await insert(B, 'failed', 'REF-B');

    // The unique constraint is (tenant_id, idempotency_key), so BOTH rows exist with the same key.
    const total = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "message_attempt_log" WHERE "idempotency_key"=$1`,
      KEY,
    )) as Array<{ n: number }>;
    expect(total[0]!.n, 'the same key legitimately exists for two tenants').toBe(2);

    // A key-only query, exactly the shape the defective code used.
    const asA = await withTenant(prisma, A, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "tenant_id","status","provider_reference" FROM "message_attempt_log"
          WHERE "idempotency_key"=$1`,
        KEY,
      ),
    );
    expect(asA, 'tenant A must see exactly its own row').toHaveLength(1);
    expect((asA as any[])[0].tenant_id).toBe(A);
    expect((asA as any[])[0].provider_reference).toBe('REF-A');
  });

  it('does not let a key-only UPDATE overwrite another tenant’s row', async () => {
    await insert(A, 'pending', 'REF-A');
    await insert(B, 'pending', 'REF-B');

    // The defective UPDATE shape: no tenant predicate at all.
    await withTenant(prisma, A, (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "message_attempt_log" SET "status"='sent' WHERE "idempotency_key"=$1`,
        KEY,
      ),
    );
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "tenant_id","status" FROM "message_attempt_log"
        WHERE "idempotency_key"=$1 ORDER BY "tenant_id"`,
      KEY,
    )) as Array<{ tenant_id: string; status: string }>;
    expect(rows.map((r) => [r.tenant_id, r.status])).toEqual([
      [A, 'sent'],
      [B, 'pending'], // untouched
    ]);
  });

  it('every table carrying tenant_id has forced RLS and a policy', async () => {
    // The registry-wide guard. This is what would have caught the original defect: a table created after the
    // blanket security migration silently escapes it, and only a whole-schema assertion notices.
    const rows = (await owner.$queryRawUnsafe(
      `SELECT c.relname AS table_name, c.relrowsecurity AS rls, c.relforcerowsecurity AS forced,
              (SELECT count(*)::int FROM pg_policies p WHERE p.tablename = c.relname) AS policies
         FROM pg_class c
         JOIN information_schema.columns ic
           ON ic.table_schema='public' AND ic.table_name=c.relname AND ic.column_name='tenant_id'
        WHERE c.relnamespace='public'::regnamespace AND c.relkind='r'
        ORDER BY c.relname`,
    )) as Array<{ table_name: string; rls: boolean; forced: boolean; policies: number }>;

    expect(rows.length, 'the schema must have tenant-scoped tables to check').toBeGreaterThan(100);
    const unprotected = rows.filter((r) => !r.rls || !r.forced || r.policies < 1);
    expect(
      unprotected.map(
        (r) => `${r.table_name} (rls=${r.rls} forced=${r.forced} policies=${r.policies})`,
      ),
      'every table with a tenant_id column must have forced RLS and at least one policy',
    ).toEqual([]);
  });
});
