import { readFileSync } from 'node:fs';
import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-36: the web-provisioned sale, purchase and tax ledgers sit in the desktop groups the master helps filter on.
 *
 * Group Sales Ac lists group 25 and Purchase Ac group 30 (MS_GROUP.cs:2204-2208, :2242-2246); the Tax header help lists
 * group 12 (MS_TAX.cs:2039). seedCompany used to write SALES in 20, PURCHASE in 21 and the tax ledgers in 30, so those
 * helps listed none of them on a fresh company. Migration 20261123110000_seeded_ledger_groups moves an older company's
 * accounts while they still carry the old seed's group and name; its DML runs here through the runtime role inside
 * this test's tenant, and the preflight is checked separately.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'seeded-ledger-groups';
const sql = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20261123110000_seeded_ledger_groups/migration.sql',
    import.meta.url,
  ),
  'utf8',
);
const statements: string[] = [];
{
  let current: string[] = [];
  let quoted = false;
  for (const line of sql.split('\n')) {
    if (/^\s*--/.test(line)) continue;
    current.push(line);
    if ((line.match(/\$preflight\$/g) ?? []).length % 2 === 1) quoted = !quoted;
    if (!quoted && /;\s*$/.test(line)) {
      statements.push(current.join('\n').trim().replace(/;\s*$/, ''));
      current = [];
    }
  }
}
const dml = statements.filter((s) => /^UPDATE/.test(s));

/** The groups the old seed wrote. */
const OLD: Record<string, string> = {
  SALES: '20',
  SLVSALE: '20',
  FINESALE: '20',
  PURCHASE: '21',
  SLVPURC: '21',
  FINEPURC: '21',
  GST: '30',
  GSTINPUT: '30',
  TCS: '30',
};
const DESKTOP: Record<string, string> = {
  SALES: '25',
  SLVSALE: '25',
  FINESALE: '25',
  PURCHASE: '30',
  SLVPURC: '30',
  FINEPURC: '30',
  GST: '12',
  GSTINPUT: '12',
  TCS: '12',
};

(enabled ? describe : describe.skip)('WP-36 seeded ledger groups', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const exec = (text: string, ...params: unknown[]) => owner.$executeRawUnsafe(text, ...params);
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const groups = async (coCode: string) =>
    Object.fromEntries(
      (
        (await owner.$queryRawUnsafe(
          `SELECT "AC_CODE" a,"AC_GR" g FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE" = ANY($3::text[])`,
          tenantId,
          coCode,
          Object.keys(OLD),
        )) as Array<{ a: string; g: string }>
      ).map((row) => [row.a, row.g]),
    );
  const run = () =>
    withTenant(runtime, tenantId, async (tx: any) => {
      const counts: number[] = [];
      for (const statement of dml) counts.push(Number(await tx.$executeRawUnsafe(statement)));
      return counts;
    });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await seedCompany(runtime, tenantId, '02');
  });
  afterAll(async () => {
    if (owner) await wipe();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('provisions the sale ledgers in group 25, the purchase ledgers in 30 and the tax ledgers in 12', async () => {
    expect(await groups('01')).toEqual(DESKTOP);
  });

  it('is one guarded transaction: complete tenant visibility, or it refuses to run', async () => {
    expect(statements[0]).toBe('BEGIN');
    expect(statements[statements.length - 1]).toBe('COMMIT');
    expect(statements).toContain('SET LOCAL row_security=off');
    const preflight = statements.find((s) => s.startsWith('DO $preflight$'));
    await expect(runtime.$executeRawUnsafe(preflight!)).rejects.toThrow(
      'seeded ledger groups backfill requires a migration role with complete tenant visibility',
    );
    await expect(owner.$executeRawUnsafe(preflight!)).resolves.toBeDefined();
    expect(dml).toHaveLength(1);
  });

  it('moves an old-way company, keeps an account the operator renamed or regrouped, and a second run changes nothing', async () => {
    for (const co of ['01', '02'])
      for (const [code, gr] of Object.entries(OLD))
        await exec(
          `UPDATE "AC_MAST" SET "AC_GR"=$4 WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3`,
          tenantId,
          co,
          code,
          gr,
        );
    // Company 02: the operator renamed SLVSALE and moved TCS to a group of their own.
    await exec(
      `UPDATE "AC_MAST" SET "AC_NAME"='SILVER SALES' WHERE tenant_id=$1 AND "CO_CODE"='02' AND "AC_CODE"='SLVSALE'`,
      tenantId,
    );
    await exec(
      `UPDATE "AC_MAST" SET "AC_GR"='31' WHERE tenant_id=$1 AND "CO_CODE"='02' AND "AC_CODE"='TCS'`,
      tenantId,
    );
    expect(await run()).toEqual([9 + 7]);
    expect(await groups('01')).toEqual(DESKTOP);
    expect(await groups('02')).toEqual({ ...DESKTOP, SLVSALE: '20', TCS: '31' });
    expect(await run()).toEqual([0]);
  });
});
