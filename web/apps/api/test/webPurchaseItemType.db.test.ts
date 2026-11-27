import { readFileSync } from 'node:fs';
import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * The web-provisioned purchase books PR and TPR are all-metal books: ITM_TYPE 'A', like the desktop 'Other Purchase'.
 *
 * Purc_Ledr posts an 'A' book's lines to each item group's PURC_AC and any other book to BOOK_DETL slot 1
 * (Ac_Ledr.cs:410-421). seedCompany now gives both books 'A', and migration 20261127120000_web_purchase_item_type gives
 * it to a company provisioned before, so its purchases keep posting to the group accounts. Its DML runs here through
 * the runtime role inside this test's tenant; the preflight is checked separately. Every value here is synthetic.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'web-purchase-item-type';
const sql = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20261127120000_web_purchase_item_type/migration.sql',
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

(enabled ? describe : describe.skip)('web purchase item type', () => {
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
  const types = async () =>
    (await owner.$queryRawUnsafe(
      `SELECT "CO_CODE" co,btrim("CO_BOOK") book,"ITM_TYPE" it FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND btrim("CO_BOOK") IN ('PR','TPR') ORDER BY "CO_CODE","CO_BOOK"`,
      tenantId,
    )) as Array<Record<string, string | null>>;
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
    for (const co of ['01', '02'])
      await seedCompany(runtime, tenantId, co, { coName: `Purchase Type ${co}`, lcCode: '01' });
  }, 60_000);
  afterAll(async () => {
    if (owner) await wipe();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('provisions PR and TPR as all-metal books', async () => {
    expect(await types()).toEqual([
      { co: '01', book: 'PR', it: 'A' },
      { co: '01', book: 'TPR', it: 'A' },
      { co: '02', book: 'PR', it: 'A' },
      { co: '02', book: 'TPR', it: 'A' },
    ]);
  });

  it('is one guarded transaction: complete tenant visibility, or it refuses to run', async () => {
    expect(statements[0]).toBe('BEGIN');
    expect(statements[statements.length - 1]).toBe('COMMIT');
    expect(statements).toContain('SET LOCAL row_security=off');
    const preflight = statements.find((s) => s.startsWith('DO $preflight$'));
    await expect(runtime.$executeRawUnsafe(preflight!)).rejects.toThrow(
      'web purchase item type backfill requires a migration role with complete tenant visibility',
    );
    await expect(owner.$executeRawUnsafe(preflight!)).resolves.toBeDefined();
    expect(dml).toHaveLength(1);
  });

  it('types a blank old book, keeps an operator type, and reruns as a no-op', async () => {
    await exec(
      `UPDATE "BOOK_DATA" SET "ITM_TYPE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01' AND btrim("CO_BOOK") IN ('PR','TPR')`,
      tenantId,
    );
    await exec(
      `UPDATE "BOOK_DATA" SET "ITM_TYPE"='G' WHERE tenant_id=$1 AND "CO_CODE"='02' AND btrim("CO_BOOK")='PR'`,
      tenantId,
    );
    expect(await run()).toEqual([2]);
    expect(await types()).toEqual([
      { co: '01', book: 'PR', it: 'A' },
      { co: '01', book: 'TPR', it: 'A' },
      { co: '02', book: 'PR', it: 'G' },
      { co: '02', book: 'TPR', it: 'A' },
    ]);
    expect(await run()).toEqual([0]);
  });
});
