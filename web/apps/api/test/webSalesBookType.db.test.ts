import { readFileSync } from 'node:fs';
import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { createSale } from '../src/modules/sales/sales.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * The web-provisioned sale book SL is a desktop tax-invoice book: BOOK_TYPE 'T', ITM_TYPE 'A' (MS_UPDATE.cs:7320).
 *
 * Sales_GST writes TAX_DATA only for BOOK_TYPE 'T' (Ac_Tax.cs:92-98). The sale writer used to write it for a blank type
 * too, because seedCompany created SL without one. seedCompany now gives SL its type, and migration
 * 20261126120000_web_sales_book_type gives it to a company provisioned before; its DML runs here through the runtime
 * role inside this test's tenant, and the preflight is checked separately. Every value here is synthetic.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'web-sales-book-type';
const YEAR = '2024-2025';
const sql = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20261126120000_web_sales_book_type/migration.sql',
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
const slotSql = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20261126130000_web_sales_discount_slot/migration.sql',
    import.meta.url,
  ),
  'utf8',
);
const slotInsert = slotSql.slice(
  slotSql.indexOf('INSERT INTO'),
  slotSql.lastIndexOf(';\n\nCOMMIT'),
);

(enabled ? describe : describe.skip)('web sale book type', () => {
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
      `SELECT "CO_CODE" co,"BOOK_TYPE" bt,"ITM_TYPE" it FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='SL' ORDER BY "CO_CODE"`,
      tenantId,
    )) as Array<Record<string, string | null>>;
  const run = () =>
    withTenant(runtime, tenantId, async (tx: any) => {
      const counts: number[] = [];
      for (const statement of dml) counts.push(Number(await tx.$executeRawUnsafe(statement)));
      return counts;
    });
  const sell = (coCode: string) =>
    createSale(
      runtime,
      {
        scope: { tenantId, coCode, lcCode: '01', coYear: YEAR, coBook: 'SL' },
        mainUser: 'tester',
        acCode: 'WSBCUS',
        acName: 'Synthetic Customer',
        vchDate: '2024-04-11',
        taxRatePct: 3,
        taxCode: '10',
        interState: false,
      } as any,
      [{ itCode: 'GOLD', pcs: 1, grossWt: 1, netWt: 1, touch: 90, metalAmount: 1000 } as any],
    );
  const taxRows = (coCode: string, vchNo: number) =>
    owner.$queryRawUnsafe(
      `SELECT 1 FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"='SL' AND "VCH_NO"=lpad($3::text,5,'0')`,
      tenantId,
      coCode,
      vchNo,
    ) as Promise<unknown[]>;

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    for (const co of ['01', '02']) {
      await seedCompany(runtime, tenantId, co, { coName: `Book Type ${co}`, lcCode: '01' });
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC") VALUES ($1,$2,'GW','Gold','SALES')`,
        tenantId,
        co,
      );
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
         VALUES ($1,$2,'01','WSBCUS','Synthetic Customer','L')`,
        tenantId,
        co,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
         VALUES ($1,$2,'GOLD','Gold','G','GW')`,
        tenantId,
        co,
      );
    }
  }, 60_000);
  afterAll(async () => {
    if (owner) await wipe();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('provisions SL as a tax-invoice book that writes the GST register', async () => {
    expect((await types())[0]).toEqual({ co: '01', bt: 'T', it: 'A' });
    const sale = await sell('01');
    expect(await taxRows('01', sale.vchNo)).toHaveLength(2);
  }, 30_000);

  it('is one guarded transaction: complete tenant visibility, or it refuses to run', async () => {
    expect(statements[0]).toBe('BEGIN');
    expect(statements[statements.length - 1]).toBe('COMMIT');
    expect(statements).toContain('SET LOCAL row_security=off');
    const preflight = statements.find((s) => s.startsWith('DO $preflight$'));
    await expect(runtime.$executeRawUnsafe(preflight!)).rejects.toThrow(
      'web sales book type backfill requires a migration role with complete tenant visibility',
    );
    await expect(owner.$executeRawUnsafe(preflight!)).resolves.toBeDefined();
    expect(dml).toHaveLength(1);
  });

  it('a blank-type book writes no register; the migration types an old SL, keeps an operator type, and reruns as a no-op', async () => {
    await exec(
      `UPDATE "BOOK_DATA" SET "BOOK_TYPE"=NULL,"ITM_TYPE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "CO_CODE"='01'`,
      tenantId,
    );
    await exec(
      `UPDATE "BOOK_DATA" SET "BOOK_TYPE"='M',"ITM_TYPE"='G' WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "CO_CODE"='02'`,
      tenantId,
    );
    // The desktop writes TAX_DATA only for type 'T' (Ac_Tax.cs:92-98): a blank type is not a tax book.
    const blank = await sell('01');
    expect(await taxRows('01', blank.vchNo)).toHaveLength(0);
    expect(await run()).toEqual([1]);
    expect(await types()).toEqual([
      { co: '01', bt: 'T', it: 'A' },
      { co: '02', bt: 'M', it: 'G' },
    ]);
    expect(await run()).toEqual([0]);
    const typed = await sell('01');
    expect(await taxRows('01', typed.vchNo)).toHaveLength(2);
  }, 60_000);

  it('the discount-slot migration gives an old SL its slot 5 DISCOUNT once (Ac_Ledr.cs:155-157)', async () => {
    const slot5 = () =>
      owner.$queryRawUnsafe(
        `SELECT "CO_CODE" co,"AC_CODE" ac,"MAIN_BOOK" mb FROM "BOOK_DETL"
          WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "SR_NO"=5 ORDER BY "CO_CODE"`,
        tenantId,
      ) as Promise<Array<Record<string, string>>>;
    expect(await slot5()).toHaveLength(2);
    await exec(
      `DELETE FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_BOOK"='SL' AND "SR_NO"=5`,
      tenantId,
    );
    const insert = () =>
      withTenant(runtime, tenantId, (tx: any) => tx.$executeRawUnsafe(slotInsert));
    expect(Number(await insert())).toBe(1);
    expect(Number(await insert())).toBe(0);
    expect(await slot5()).toEqual([
      { co: '01', ac: 'DISCOUNT', mb: 'SALES' },
      { co: '02', ac: 'DISCOUNT', mb: 'SALES' },
    ]);
  });
});
