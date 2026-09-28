import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import { afterAll, afterEach, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createTourOrder,
  editTourOrder,
  getTourOrder,
  type SalesOrderInput,
} from '../src/modules/sales/salesOrder.js';
const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'tour-exact-values',
  foreignTenant = 'tour-exact-foreign';
const bytes = readFileSync(new URL('./fixtures/tourExactValues.independent.json', import.meta.url));
const fixture = JSON.parse(bytes.toString());
const scope = (coBook = 'E13') => ({
  tenantId,
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook,
});
type Raw = Record<string, string | null>;
type Physical = { raw: string; revision: string; locator: string };
const writes = [
  'SL_ORD_DATA',
  'SL_ORD_DETL',
  'SL_ORD_IDTL',
  'SL_PR_DETL',
  'SL_ORD_ADJ',
  'UPI_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'TEMP_BOOK_DATA',
  'DELETE_DATA',
] as const;
const protectedTables = [
  'CO_MAST',
  'LOCT_MAST',
  'YEAR_MAST',
  'CO_SET',
  'CO_SET_NEW',
  'BOOK_DATA',
  'ITEM_MAST',
  'AC_MAST',
  'auth_session',
] as const;
const allTables = [...writes, ...protectedTables];

db('Tour exact mapped saved values retain existing writer guards', () => {
  let owner: PrismaClient, runtime: PrismaClient;
  let sibling: Record<string, Physical[]> | undefined,
    foreign: Record<string, Physical[]> | undefined,
    protectedBefore: Record<string, Physical[]> | undefined;
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const cleanup = async () => {
    for (const table of allTables)
      await sql('DELETE FROM "' + table + '" WHERE tenant_id=ANY($1::text[])', [
        tenantId,
        foreignTenant,
      ]);
  };
  const physical = async (
    tables: readonly string[] = allTables,
    tenants = [tenantId, foreignTenant],
    book?: string,
  ) => {
    const out: Record<string, Physical[]> = {};
    for (const table of tables)
      out[table] = await owner.$queryRawUnsafe<Physical[]>(
        'SELECT to_jsonb(t)::text raw,xmin::text revision,ctid::text locator FROM "' +
          table +
          '" t WHERE tenant_id=ANY($1::text[])' +
          (book ? ' AND "CO_BOOK"=$2' : '') +
          ' ORDER BY to_jsonb(t)::text',
        tenants,
        ...(book ? [book] : []),
      );
    return out;
  };
  const business = async (tables: readonly (typeof writes)[number][] = writes) => {
    const out: Record<string, Raw[]> = {};
    for (const table of tables)
      out[table] = (
        await owner.$queryRawUnsafe<Array<{ raw: Raw }>>(
          "SELECT (SELECT jsonb_object_agg(j.key,j.value) FROM jsonb_each_text(to_jsonb(t)-'row_id') j) raw FROM \"" +
            table +
            "\" t WHERE tenant_id=$1 AND \"CO_BOOK\"='E13' ORDER BY (to_jsonb(t)-'row_id')::text",
          tenantId,
        )
      ).map((row) => row.raw);
    return out;
  };
  const get = () => getTourOrder(runtime, scope(), 1) as Promise<Record<string, any>>;
  const edit = (saved: Record<string, any>, changes: Record<string, unknown> = {}) =>
    editTourOrder(
      runtime,
      { ...saved, ...changes, scope: scope(), expectedVersion: saved.version } as SalesOrderInput,
      1,
    );
  const initial = (book: string): SalesOrderInput => ({
    scope: scope(book),
    mainUser: 'saved-creator',
    acCode: 'PARTY',
    acName: 'Customer',
    cashAc: 'CASH',
    taxRatePct: 0,
    advanceAmount: 25,
    vchDate: '2024-07-10',
    vchTime: '09:10:11.123456',
    lines: fixture.original.lines.map((line: any) => ({
      ...line,
      mrp: 0,
      components: line.components.map((child: any) => ({ ...child, karigarRate: 0 })),
    })),
  });
  beforeAll(() => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '4531bd17b90cd2c7700db743bb36b1981486d08fcc1c37511ac41efb4ea8917a',
    );
    for (const key of ['DATABASE_URL', 'MIGRATE_DATABASE_URL'] as const) {
      const url = new URL(process.env[key] ?? '');
      if (
        url.port !== '55433' ||
        (key === 'DATABASE_URL' && decodeURIComponent(url.username) !== 'app_user')
      )
        throw new Error('isolated55433/app_user wrapper required');
    }
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL } } });
  });
  beforeEach(async () => {
    sibling = foreign = protectedBefore = undefined;
    await cleanup();
    await sql(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","LBR_ROF","ALL_ROF_REMOVE") VALUES($1,'01',NULL,2,'N')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,'01','N')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01','2024-2025','2024-04-01','2025-03-31')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_NAME","BOOK_SNAME","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME") VALUES($1,'01','01','E13','TOUR ORDER','Exact Tour','TUROD','I','Y','SL_ORD_DATA'),($1,'01','01','E14','TOUR ORDER','Other Tour','TUROD','I','Y','SL_ORD_DATA')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PARTY','Customer'),($1,'01','01','CASH','Cash')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES($1,'01','GOLD','Gold'),($1,'01','SILVR','Silver'),($1,'01','STN1','Stone one'),($1,'01','STN2','Stone two')`,
      tenantId,
    );
    await createTourOrder(runtime, initial('E13'));
    await createTourOrder(runtime, initial('E14'));
    await sql(
      `UPDATE "SL_ORD_DATA" SET "MOBILE"=NULL,"ADD1"='',"ENTRY_TIME"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='E13'`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_DETL" SET "ITM_MRP"=999999999999999.99,"BAG_WT"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='E13' AND "SR_NO"=7`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_IDTL" SET "KR_RATE"=999999999999998.99,"DM_NAME"=NULL,"IT_RATE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='E13' AND "ISR_NO"=3`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_IDTL" SET "KR_RATE"=999999999999997.99,"DM_NAME"='',"IT_RATE"=0,"IT_LBR_RATE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='E13' AND "ISR_NO"=13`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_DATA"(tenant_id,"LEDR_KEY","CO_CODE","CO_BOOK","CR_AMT","DR_AMT","ENTRY_TIME") VALUES($1,'tour-exact-foreign','01','E13',90071992547409.91,NULL,'2024-07-10 09:10:11.123456')`,
      foreignTenant,
    );
    sibling = await physical(writes, [tenantId], 'E14');
    foreign = await physical(allTables, [foreignTenant]);
    protectedBefore = await physical(protectedTables);
  });
  afterEach(async () => {
    if (sibling) expect(await physical(writes, [tenantId], 'E14')).toEqual(sibling);
    if (foreign) expect(await physical(allTables, [foreignTenant])).toEqual(foreign);
    if (protectedBefore) expect(await physical(protectedTables)).toEqual(protectedBefore);
  });
  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('GET retains mapped exact strings, NULL and true zeros without changing its physical observation', async () => {
    const before = await physical(),
      saved = await get();
    expect(saved).toMatchObject({
      mobile: null,
      address1: '',
      advanceAmount: 25,
      vchTime: '09:10:11.123456',
      lines: [
        {
          srNo: 7,
          mrp: '999999999999999.99',
          bagWt: null,
          otherAmount: 0,
          components: [
            {
              isrNo: 3,
              dmCode: '00012',
              dmName: null,
              pcs: 0,
              rate: null,
              lbrRate: 0,
              karigarRate: '999999999999998.99',
            },
            { isrNo: 13, dmName: '', rate: 0, lbrRate: null, karigarRate: '999999999999997.99' },
          ],
        },
        { srNo: 19, mrp: 0, bagWt: 0, components: [] },
      ],
    });
    expect(await physical()).toEqual(before);
  });
  it('unchanged exact GET input preserves the complete business rows and changes only physical replacement/version', async () => {
    const saved = await get(),
      before = await business();
    await edit(saved);
    expect(await business()).toEqual(before);
    expect((await get()).version).not.toBe(saved.version);
  });
  it('advance-only exact input changes25 to40 and keeps every parent/child raw scalar, hidden identity and clock', async () => {
    const saved = await get(),
      before = await business();
    await edit(saved, { advanceAmount: '40' });
    const after = await business();
    expect(after.SL_ORD_DETL).toEqual(before.SL_ORD_DETL);
    expect(after.SL_ORD_IDTL).toEqual(before.SL_ORD_IDTL);
    expect(after.SL_ORD_DATA![0]).toEqual({ ...before.SL_ORD_DATA![0], ADV_AMT: '40' });
    expect(
      after
        .AC_DATA!.map(({ AC_CODE, DR_AMT, CR_AMT }) => ({ AC_CODE, DR_AMT, CR_AMT }))
        .sort((a, b) => String(a.AC_CODE).localeCompare(String(b.AC_CODE))),
    ).toEqual([
      { AC_CODE: 'CASH', DR_AMT: '40.00', CR_AMT: '0.00' },
      { AC_CODE: 'PARTY', DR_AMT: '0.00', CR_AMT: '40.00' },
    ]);
    expect(after.ROJ_MEL_DATA![0]).toMatchObject({
      AC_CODE: 'PARTY',
      LD_CODE: 'CASH',
      CR_AMT: '40.00',
    });
    for (const table of writes.filter(
      (table) => !['SL_ORD_DATA', 'AC_DATA', 'ROJ_MEL_DATA'].includes(table),
    ))
      expect(after[table]).toEqual(before[table]);
  });
  it.each(['parent', 'child'] as const)(
    'changed unsupported %s decimal refuses and restores the complete physical snapshot',
    async (kind) => {
      const saved = await get(),
        before = await physical();
      if (kind === 'parent') saved.lines[0].mrp = '999999999999998.99';
      else saved.lines[0].components[0].karigarRate = '999999999999996.99';
      await expect(edit(saved)).rejects.toMatchObject({ name: 'SaleValidationError' });
      expect(await physical()).toEqual(before);
    },
  );
  it('supported MRP replacement persists25.50 while retaining every other parent and child scalar', async () => {
    const saved = await get(),
      before = await business();
    saved.lines[0].mrp = '25.50';
    await edit(saved);
    const after = await business();
    expect(after.SL_ORD_DETL).toEqual(
      before.SL_ORD_DETL!.map((line) =>
        line.SR_NO === '7' ? { ...line, ITM_MRP: '25.50' } : line,
      ),
    );
    for (const table of writes.filter((table) => table !== 'SL_ORD_DETL'))
      expect(after[table]).toEqual(before[table]);
  });
  it('an old client still sending the rounded MRP remains refused without weakening the existing guard', async () => {
    const saved = await get(),
      before = await physical();
    saved.lines[0].mrp = Number(saved.lines[0].mrp);
    await expect(edit(saved)).rejects.toThrow('needs its exact decimal string');
    expect(await physical()).toEqual(before);
  });
  it('saved version conflict still precedes replacement after a successful exact edit', async () => {
    const saved = await get();
    await edit(saved);
    const before = await physical();
    await expect(edit(saved)).rejects.toMatchObject({ name: 'SalesOrderConflictError' });
    expect(await physical()).toEqual(before);
  });
});
