import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { isPartySql } from '../src/modules/ops/balanceTransfer.js';
import { DESKTOP_ACCOUNT_GROUPS } from '../src/modules/ops/desktopTemplateMasters.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * A fresh company's web system accounts sit in the desktop installer groups, so year end and the party carry
 * (balanceTransfer.ts isPartySql: AC_MAIN_GR < '3' is carried forward, >= '3' is closed to P&L) classify them as the
 * desktop does, and provisioning an existing company never adds groups to its chart.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'seeded-account-groups';
const CO = '91';
const OLD_CO = '92';

/** System accounts deliberately left without a group: none. */
const GROUPLESS: string[] = [];
const BALANCE_SHEET = ['CASH', 'BANK', 'CAPITAL', 'ORDADV'];
const PROFIT_AND_LOSS = ['LBRINC', 'LBREXP', 'INTINC', 'HMCHRG', 'DISCOUNT', 'SALES', 'PURCHASE'];

(enabled ? describe : describe.skip)('seeded account groups of a new company', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const groupCount = async (co: string) =>
    Number(
      (
        (await owner.$queryRawUnsafe(
          `SELECT count(*)::int n FROM "AC_GROUP" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
          tenantId,
          co,
        )) as Array<{ n: number }>
      )[0]?.n,
    );
  const isParty = (code: string) =>
    withTenant(runtime, tenantId, async (tx: any) => {
      const rows = await tx.$queryRawUnsafe(
        `SELECT ${isPartySql('a')} AS party FROM (SELECT $1::text AS "CO_CODE", $2::text AS "AC_CODE") a`,
        CO,
        code,
      );
      return rows[0].party as boolean;
    });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, CO);
  });
  afterAll(async () => {
    if (owner) await wipe();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('puts every system account in a seeded desktop group', async () => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT m."AC_CODE" code, m."AC_GR" gr, g."AC_GR" found
         FROM "AC_MAST" m LEFT JOIN "AC_GROUP" g
           ON g.tenant_id=m.tenant_id AND g."CO_CODE"=m."CO_CODE" AND g."AC_GR"=m."AC_GR"
        WHERE m.tenant_id=$1 AND m."CO_CODE"=$2`,
      tenantId,
      CO,
    )) as Array<{ code: string; gr: string | null; found: string | null }>;
    expect(rows.length).toBeGreaterThan(20);
    expect(await groupCount(CO)).toBe(DESKTOP_ACCOUNT_GROUPS.length);
    expect(
      rows
        .filter((r) => !r.found)
        .map((r) => r.code)
        .sort(),
    ).toEqual(GROUPLESS);
  });

  it('carries the balance-sheet accounts forward', async () => {
    for (const code of BALANCE_SHEET) expect([code, await isParty(code)]).toEqual([code, true]);
  });

  it('closes the profit and loss accounts', async () => {
    for (const code of PROFIT_AND_LOSS) expect([code, await isParty(code)]).toEqual([code, false]);
  });

  it('adds no group when an existing company is provisioned again', async () => {
    await seedCompany(runtime, tenantId, CO);
    expect(await groupCount(CO)).toBe(DESKTOP_ACCOUNT_GROUPS.length);

    // A company created before groups were seeded: its CO_MAST row exists and its chart has no groups.
    await seedCompany(runtime, tenantId, OLD_CO);
    await owner.$executeRawUnsafe(
      `DELETE FROM "AC_GROUP" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      tenantId,
      OLD_CO,
    );
    const result = await seedCompany(runtime, tenantId, OLD_CO);
    expect(result.created.coMast).toBe(false);
    expect(await groupCount(OLD_CO)).toBe(0);
  });
});
