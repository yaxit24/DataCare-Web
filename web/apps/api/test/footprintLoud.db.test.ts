/**
 * The footprint helper must fail loudly, never return a partial read as if it were a finding.
 *
 * `footprintOf` previously carried `.catch(() => [{ n: 0 }])`, so any table it could not read counted as zero.
 * The realistic cause is not an odd table shape - the table list comes from `information_schema`, so every
 * table in it has the column being queried - it is ROW-LEVEL SECURITY. Handed an RLS-bound client with no
 * tenant context, every query returns nothing and the footprint comes back EMPTY.
 *
 * That matters because an empty footprint does not read as a harness problem. It reads as "the module wrote
 * nothing", which is a defect report. So the swallow could turn a misconfigured probe into a false accusation
 * against working code - and the project has already lost time to exactly that class of error twice, once when
 * an under-seeded replay harness manufactured two rounding "defects".
 *
 * These tests use the RLS-bound application role deliberately, because that is the real failure mode.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { footprintOf } from './support/footprint.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'footprint-loud';
const VCH = '00001';

/** The OWNER: used to set up, and to prove the same call succeeds when it can read. */
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
/** The RLS-BOUND application role, with no tenant context set. This is what used to yield a silent empty. */
const runtime = new PrismaClient({
  datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
});

async function wipe() {
  await owner.$executeRawUnsafe(`DELETE FROM "SL_DATA" WHERE tenant_id=$1`, TENANT);
}

describe.runIf(RUN)('footprintOf failure behaviour', () => {
  beforeAll(async () => {
    await wipe();
    await withTenant(owner, TENANT, (tx) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO")
         VALUES ($1,'01','00','2024-2025','027',$2)`,
        TENANT,
        VCH,
      ),
    );
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('reports the write when it can read', async () => {
    const touched = await withTenant(owner, TENANT, (tx) =>
      footprintOf(tx, ['SL_DATA'], TENANT, VCH),
    );
    expect(touched).toEqual(['SL_DATA']);
  });

  it('THROWS rather than returning an empty footprint when a table cannot be read', async () => {
    // A table that does not exist stands in for any unreadable table. Before the fix this returned [] - a
    // clean-looking "nothing was written" - and the test that consumed it would have blamed the module.
    await expect(
      withTenant(owner, TENANT, (tx) =>
        footprintOf(tx, ['SL_DATA', 'TABLE_THAT_DOES_NOT_EXIST'], TENANT, VCH),
      ),
    ).rejects.toThrow(/could not read/);
  });

  it('names the table it could not read, so the cause is diagnosable', async () => {
    await expect(
      withTenant(owner, TENANT, (tx) =>
        footprintOf(tx, ['TABLE_THAT_DOES_NOT_EXIST'], TENANT, VCH),
      ),
    ).rejects.toThrow(/TABLE_THAT_DOES_NOT_EXIST/);
  });

  it('an RLS-bound client with no tenant context returns empty, which is why the call must be scoped', async () => {
    // Not a defect in footprintOf: RLS filtering is not an error, so there is nothing for it to throw on. The
    // row is invisible rather than unreadable. This test exists to PIN that distinction, because it is the
    // reason the documented call pattern wraps the helper in withTenant rather than passing a bare client.
    const unscoped = await footprintOf(runtime, ['SL_DATA'], TENANT, VCH);
    expect(unscoped).toEqual([]);

    // The same client, correctly scoped, sees it.
    const scoped = await withTenant(runtime, TENANT, (tx) =>
      footprintOf(tx, ['SL_DATA'], TENANT, VCH),
    );
    expect(scoped).toEqual(['SL_DATA']);
  });
});
