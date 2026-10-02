import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Exercises the SQL behind `GET /integrations/readiness`.
 *
 * This exists because the first version of that query named `E_MAST."E_USER_NAME"` and
 * `E_MAST."E_PASSWORD"`, neither of which exists — the endpoint would have failed at runtime while every
 * unit test passed, because nothing executed the SQL. A query is only proven by running it.
 */
d('company mail configuration query', () => {
  // Seeding needs the owner connection: CO_MAST is under forced RLS, so the runtime role cannot insert
  // rows for a tenant it is not scoped to.
  let owner: PrismaClient;
  const TENANT = 'readiness-db';

  const clean = async () => {
    await owner.$executeRawUnsafe(`DELETE FROM "CO_MAST" WHERE tenant_id='${TENANT}'`);
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    if (!ownerUrl) throw new Error('MIGRATE_DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    await clean();
  });
  afterAll(async () => {
    await clean();
    await owner.$disconnect();
  });

  const mailConfigured = async (): Promise<boolean> => {
    const rows: Array<{ n: number }> = await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "CO_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND coalesce("CO_MAIL",'') <> '' AND coalesce("MAIL_API",'') <> ''`,
      TENANT,
      '01',
    );
    return Number(rows[0]?.n ?? 0) > 0;
  };

  it('runs against the real columns and reports unconfigured when they are blank', async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","CO_MAIL","MAIL_API")
        VALUES ($1,'01','Readiness Co','','')`,
      TENANT,
    );
    expect(await mailConfigured()).toBe(false);
  }, 30_000);

  it('reports configured only when BOTH the address and the API key are set', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "CO_MAST" SET "CO_MAIL"='shop@example.com' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      TENANT,
    );
    // Address alone is not enough: Module_Save.cs needs the API credential too.
    expect(await mailConfigured()).toBe(false);
    await owner.$executeRawUnsafe(
      `UPDATE "CO_MAST" SET "MAIL_API"='key' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      TENANT,
    );
    expect(await mailConfigured()).toBe(true);
  }, 30_000);
});
