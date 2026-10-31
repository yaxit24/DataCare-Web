import { readFileSync } from 'node:fs';
import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N191 (G201) and N198 (G207, G208) data migration 20261031090000_book_tables_and_advance_slots, run against real rows.
 *
 * Companies provisioned before the change have NULL table names on the sale/purchase/order/contra families, no slot 4
 * on their sale books and the sales account in slot 1 of their order books. The migration fills those, and must leave
 * desktop-shaped data (its own table names and accounts) untouched.
 *
 * The DML statements are the migration file's own. They run through the row-level-security runtime role inside this
 * test's tenant, so a shared database is not touched; the preflight and `row_security=off` are checked separately.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'book-tables-migration';
const sql = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20261031090000_book_tables_and_advance_slots/migration.sql',
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
const dml = statements.filter((s) => /^(UPDATE|INSERT)/.test(s));

(enabled ? describe : describe.skip)('N191/N198 book tables and advance slots migration', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const wipe = async () => {
    for (const table of ['BOOK_DETL', 'BOOK_DATA', 'AC_MAST'])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  };
  const book = (coCode: string, coBook: string, mainBook: string, table: string | null) =>
    owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,'01',$3,$4,$5,$6,'O','Y',$7)`,
      TENANT,
      coCode,
      coBook,
      coBook,
      coBook,
      mainBook,
      table,
    );
  const slot = (coCode: string, coBook: string, mainBook: string, sr: number, ac: string) =>
    owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
       VALUES ($1,$2,'01',$3,$4,$5,$6,$7,'O',$8,$9,'L')`,
      TENANT,
      coCode,
      coBook,
      sr,
      coBook,
      coBook,
      mainBook,
      ac,
      ac,
    );
  const run = () =>
    withTenant(runtime, TENANT, async (tx: any) => {
      for (const statement of dml) await tx.$executeRawUnsafe(statement);
    });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    // Company 01: what web provisioning wrote before the change.
    for (const [b, mb] of [
      ['SL', 'SALES'],
      ['SRT', 'SALES RETURNE'],
      ['PR', 'PURCHASE'],
      ['PRT', 'PURC RETURN'],
      ['SOR', 'SALES ORDER'],
      ['CON', 'CONTRA'],
    ])
      await book('01', b!, mb!, null);
    for (const [sr, ac] of [
      [1, 'SALES'],
      [2, 'CASH'],
      [3, 'ROUNDOFF'],
    ] as const) {
      await slot('01', 'SL', 'SALES', sr, ac);
      await slot('01', 'SOR', 'SALES ORDER', sr, ac);
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','CASH','CASH ON HAND','01'),($1,'01','01','SALES','SALES A/C','20')`,
      TENANT,
    );
    // Company 02: desktop-shaped data (its own table names, numeric accounts, a slot 4 already present).
    await book('02', '021', 'SALES', 'SL_DATA');
    await book('02', '020', 'SALES ORDER', 'SL_ORD_DATA');
    await slot('02', '021', 'SALES', 1, '00003');
    await slot('02', '021', 'SALES', 4, '00020');
    await slot('02', '020', 'SALES ORDER', 1, '00001');
  });
  afterAll(async () => {
    if (owner) await wipe();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('is one guarded transaction: complete tenant visibility, or it refuses to run', async () => {
    expect(statements[0]).toBe('BEGIN');
    expect(statements[statements.length - 1]).toBe('COMMIT');
    expect(statements).toContain('SET LOCAL row_security=off');
    const preflight = statements.find((s) => s.startsWith('DO $preflight$'));
    await expect(runtime.$executeRawUnsafe(preflight!)).rejects.toThrow(
      'book provisioning backfill requires a migration role with complete tenant visibility',
    );
    await expect(owner.$executeRawUnsafe(preflight!)).resolves.toBeDefined();
    expect(dml).toHaveLength(4);
  });

  it('fills web-provisioned books and leaves desktop data alone, and running it again changes nothing', async () => {
    await run();
    const snapshot = async () => ({
      books: await owner.$queryRawUnsafe(
        `SELECT "CO_CODE" co,"CO_BOOK" b,"BOOK_TBL_NAME" t,"BOOK_TBL_DETL" d FROM "BOOK_DATA" WHERE tenant_id=$1 ORDER BY 1,2`,
        TENANT,
      ),
      slots: await owner.$queryRawUnsafe(
        `SELECT "CO_CODE" co,"CO_BOOK" b,"SR_NO"::int s,"AC_CODE" a FROM "BOOK_DETL" WHERE tenant_id=$1 ORDER BY 1,2,3`,
        TENANT,
      ),
      accounts: await owner.$queryRawUnsafe(
        `SELECT "CO_CODE" co,"AC_CODE" a,"AC_NAME" n FROM "AC_MAST" WHERE tenant_id=$1 ORDER BY 1,2`,
        TENANT,
      ),
    });
    const after = await snapshot();
    expect(after.books).toEqual([
      { co: '01', b: 'CON', t: 'CONTRA_DATA', d: 'CONTRA_DATA' },
      { co: '01', b: 'PR', t: 'PR_DATA', d: 'PR_DETL' },
      { co: '01', b: 'PRT', t: 'PR_DATA', d: 'PR_DETL' },
      { co: '01', b: 'SL', t: 'SL_DATA', d: 'SL_DETL' },
      { co: '01', b: 'SOR', t: 'SL_ORD_DATA', d: 'SL_ORD_DETL' },
      { co: '01', b: 'SRT', t: 'SL_DATA', d: 'SL_DETL' },
      // Desktop books keep their table names (the detail name was never written and stays empty).
      { co: '02', b: '020', t: 'SL_ORD_DATA', d: null },
      { co: '02', b: '021', t: 'SL_DATA', d: null },
    ]);
    expect(after.slots).toEqual([
      { co: '01', b: 'SL', s: 1, a: 'SALES' },
      { co: '01', b: 'SL', s: 2, a: 'CASH' },
      { co: '01', b: 'SL', s: 3, a: 'ROUNDOFF' },
      { co: '01', b: 'SL', s: 4, a: 'ORDADV' },
      { co: '01', b: 'SOR', s: 1, a: 'CASH' },
      { co: '01', b: 'SOR', s: 2, a: 'CASH' },
      { co: '01', b: 'SOR', s: 3, a: 'ROUNDOFF' },
      { co: '02', b: '020', s: 1, a: '00001' },
      { co: '02', b: '021', s: 1, a: '00003' },
      { co: '02', b: '021', s: 4, a: '00020' },
    ]);
    expect(after.accounts).toEqual([
      { co: '01', a: 'CASH', n: 'CASH ON HAND' },
      { co: '01', a: 'ORDADV', n: 'ORDER ADVANCE' },
      { co: '01', a: 'SALES', n: 'SALES A/C' },
    ]);
    await run();
    expect(await snapshot()).toEqual(after);
  });
});
