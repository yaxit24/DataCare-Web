import { readFileSync } from 'node:fs';
import { PrismaClient, withTenant } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N240 (G252) data migration 20261122120000_book_template_slots, run against companies provisioned the OLD way.
 *
 * seedCompany only seeds an absent book, so a company provisioned before N240 kept the old web slots: TAG SPLIT
 * 6 PURCHASE / 7 SALES / 8 PURCHASE / 9 SALES (the desktop template MS_UPDATE.cs:32078-32110 is 6 sales gold,
 * 7 purchase gold, 8 sales silver, 9 purchase silver), and no OTH INC/OTH EXP 2-3, PURCHASE/TAG PURCHASE 5 or
 * LABOUR WORK 8-11. Tag_Split_Ledr (Ac_Ledr.cs:1951ff, tagSplitRows.ts) posts the gold debit fine to slot 6, so
 * those companies posted it to PURCHASE. The migration rewrites a slot only while it still holds the old seed's
 * account, inserts only absent template slots, and changes nothing on a second run.
 *
 * The DML statements are the migration file's own, run through the row-level-security runtime role inside this
 * test's tenant so a shared database is not touched; the preflight and `row_security=off` are checked separately.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'book-template-slots-mig';
const PASSWORD = 'Book-Template-Slots!2026';
const SECRET = 'book-template-slots-migration-test-signing-secret';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const TAG = 'RNG00001';
const sql = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20261122120000_book_template_slots/migration.sql',
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

/** The BOOK_DETL rows the pre-N240 seed wrote (AC_NAME = the code, DATA_TYPE 'L'). */
const OLD_SEED: Record<string, { main: string; slots: Array<[number, string]> }> = {
  OIN: { main: 'OTH INC', slots: [[1, 'INTINC']] },
  OEX: { main: 'OTH EXP', slots: [[1, 'OTHCHRG']] },
  PR: {
    main: 'PURCHASE',
    slots: [
      [1, 'PURCHASE'],
      [2, 'CASH'],
      [3, 'ROUNDOFF'],
      [4, 'LBREXP'],
    ],
  },
  TPR: {
    main: 'TAG PURCHASE',
    slots: [
      [1, 'PURCHASE'],
      [2, 'CASH'],
      [3, 'ROUNDOFF'],
      [4, 'LBREXP'],
    ],
  },
  TSP: {
    main: 'TAG SPLIT',
    slots: [
      [5, 'LBREXP'],
      [6, 'PURCHASE'],
      [7, 'SALES'],
      [8, 'PURCHASE'],
      [9, 'SALES'],
    ],
  },
  LBR: {
    main: 'LABOUR WORK',
    slots: [
      [1, 'LBRINC'],
      [6, 'LBRINC'],
    ],
  },
};

/** The desktop templates seedCompany now writes for those books. */
const TEMPLATE: Record<string, string[]> = {
  OIN: ['1 INTINC', '2 CASH', '3 KASAR'],
  OEX: ['1 OTHCHRG', '2 CASH', '3 KASAR'],
  PR: ['1 PURCHASE', '2 CASH', '3 ROUNDOFF', '4 LBREXP', '5 DISCOUNT'],
  TPR: ['1 PURCHASE', '2 CASH', '3 ROUNDOFF', '4 LBREXP', '5 DISCOUNT'],
  TSP: [
    '1 CASH',
    '2 KASAR',
    '3 KASAR',
    '4 LBRINC',
    '5 LBREXP',
    '6 SALES',
    '7 PURCHASE',
    '8 SLVSALE',
    '9 SLVPURC',
  ],
  LBR: ['1 LBRINC', '6 LBRINC', '8 SLVSALE', '9 SLVPURC', '10 OG', '11 OS'],
};

(enabled ? describe : describe.skip)('N240 book template slots migration', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance | undefined;
  const exec = (text: string, ...params: unknown[]) => owner.$executeRawUnsafe(text, ...params);
  const query = <T>(text: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(text, ...params) as Promise<T>;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  /** Runs the migration's DML in this tenant; returns the rows each statement changed. */
  const run = () =>
    withTenant(runtime, tenantId, async (tx: any) => {
      const counts: number[] = [];
      for (const statement of dml) counts.push(Number(await tx.$executeRawUnsafe(statement)));
      return counts;
    });
  const slotsOf = async (coCode: string, coBook: string) =>
    (
      await query<Array<{ s: number; a: string }>>(
        `SELECT "SR_NO"::int s,"AC_CODE" a FROM "BOOK_DETL"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 ORDER BY "SR_NO"`,
        tenantId,
        coCode,
        coBook,
      )
    ).map((row) => `${row.s} ${row.a}`);
  const snapshot = async () => ({
    slots: await query(
      `SELECT "CO_CODE" co,"LC_CODE" lc,"CO_BOOK" b,"SR_NO"::int s,"AC_CODE" a,"AC_NAME" n,"DATA_TYPE" t,
              "BOOK_SNAME" sn,"MAIN_BOOK" mb FROM "BOOK_DETL" WHERE tenant_id=$1 ORDER BY 1,2,3,4,row_id`,
      tenantId,
    ),
    accounts: await query(
      `SELECT "CO_CODE" co,"AC_CODE" a,"AC_NAME" n,"AC_GR" g FROM "AC_MAST" WHERE tenant_id=$1 ORDER BY 1,2,row_id`,
      tenantId,
    ),
  });
  /** Puts a company's six families back to the BOOK_DETL rows the pre-N240 seed wrote, and drops DISCOUNT. */
  const provisionOldWay = async (coCode: string) => {
    await seedCompany(runtime, tenantId, coCode);
    await exec(
      `DELETE FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK" = ANY($3::text[])`,
      tenantId,
      coCode,
      Object.keys(OLD_SEED),
    );
    await exec(
      `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"='DISCOUNT'`,
      tenantId,
      coCode,
    );
    for (const [book, { main, slots }] of Object.entries(OLD_SEED))
      for (const [srNo, acCode] of slots)
        await exec(
          `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
             "BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
           SELECT tenant_id,"CO_CODE","LC_CODE","CO_BOOK",$4,"BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT",$5,$5,'L'
             FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "MAIN_BOOK"=$6`,
          tenantId,
          coCode,
          book,
          srNo,
          acCode,
          main,
        );
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    // Company 01: provisioned the old way, untouched since.
    await provisionOldWay('01');
    // Company 02: provisioned the old way, then an operator put its own account in TAG SPLIT slot 6.
    await provisionOldWay('02');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'02','01','GOLDADJ','Gold adjust')`,
      tenantId,
    );
    await exec(
      `UPDATE "BOOK_DETL" SET "AC_CODE"='GOLDADJ',"AC_NAME"='Gold adjust'
        WHERE tenant_id=$1 AND "CO_CODE"='02' AND "CO_BOOK"='TSP' AND "SR_NO"=6`,
      tenantId,
    );
    // A desktop TAG SPLIT book of company 02 holding the literal PURCHASE in slot 6: not a web-seeded book.
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE")
       VALUES ($1,'02','01','099','Tag Split','TGSPL','TAG SPLIT','O','Y')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","MAIN_BOOK","BOOK_SNAME","AC_CODE","AC_NAME","DATA_TYPE")
       VALUES ($1,'02','01','099',6,'TAG SPLIT','TGSPL','PURCHASE','PURCHASE','A')`,
      tenantId,
    );
  });
  afterAll(async () => {
    if (app) await app.close();
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
      'book template slots backfill requires a migration role with complete tenant visibility',
    );
    await expect(owner.$executeRawUnsafe(preflight!)).resolves.toBeDefined();
    expect(dml).toHaveLength(3);
  });

  it('brings old-way companies to the desktop template, keeps operator changes, and a second run changes nothing', async () => {
    expect(await slotsOf('01', 'TSP')).toEqual([
      '5 LBREXP',
      '6 PURCHASE',
      '7 SALES',
      '8 PURCHASE',
      '9 SALES',
    ]);
    const first = await run();
    // (a) Company 01: every family now carries its template; the rewritten slots carry the account's name.
    for (const [book, slots] of Object.entries(TEMPLATE))
      expect(await slotsOf('01', book), book).toEqual(slots);
    const tsp = await query<Array<{ s: number; n: string; t: string }>>(
      `SELECT "SR_NO"::int s,"AC_NAME" n,"DATA_TYPE" t FROM "BOOK_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_BOOK"='TSP' AND "SR_NO" IN (1,6,8) ORDER BY 1`,
      tenantId,
    );
    expect(tsp).toEqual([
      { s: 1, n: 'CASH ON HAND', t: 'L' },
      { s: 6, n: 'SALES A/C', t: 'L' },
      { s: 8, n: 'SALES SILVER A/C', t: 'L' },
    ]);
    expect(
      await query(
        `SELECT "CO_CODE" co,"AC_NAME" n,"AC_GR" g FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"='DISCOUNT' ORDER BY 1`,
        tenantId,
      ),
    ).toEqual([
      { co: '01', n: 'DISCOUNT A/C', g: '22' },
      { co: '02', n: 'DISCOUNT A/C', g: '22' },
    ]);
    // (b) Company 02: the customised slot 6 is kept; the slots still at the old default follow the template.
    expect(await slotsOf('02', 'TSP')).toEqual([
      '1 CASH',
      '2 KASAR',
      '3 KASAR',
      '4 LBRINC',
      '5 LBREXP',
      '6 GOLDADJ',
      '7 PURCHASE',
      '8 SLVSALE',
      '9 SLVPURC',
    ]);
    expect(
      await query(
        `SELECT "AC_NAME" n FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"='02' AND "CO_BOOK"='TSP' AND "SR_NO"=6`,
        tenantId,
      ),
    ).toEqual([{ n: 'Gold adjust' }]);
    // The desktop book is never matched.
    expect(await slotsOf('02', '099')).toEqual(['6 PURCHASE']);
    // Rows changed: 4 + 3 TAG SPLIT rewrites; 2 DISCOUNT accounts; per company 2+2+1+1+4+4 = 14 inserted slots.
    expect(first).toEqual([7, 2, 28]);

    // (c) A second run changes nothing.
    const after = await snapshot();
    expect(await run()).toEqual([0, 0, 0]);
    expect(await snapshot()).toEqual(after);
  });

  it('a tag split on the migrated book posts its gold debit fine to slot 6, SALES GOLD', async () => {
    await exec(
      `UPDATE "CO_SET" SET "TRAD_FINE"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","TAG_TYPE","RATE_TYPE")
       VALUES ($1,'01','RNG','RING 916','G','RG','R','G'),($1,'01','RNGH','HALF RING','G','RH','H','G')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','SPLITAC','Split absorb')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","ENTRY_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
         "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","KR_NET_WT","KR_TOUCH","KR_FINE","TBL_CODE","DESIGN_NO","ITM_SIZE",
         "KR_NAME","PR_CODE","IT_TYPE","TAG_TYPE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'PURCHASE','I','I',$4,100319000001,'RNG',1,10,10,
               91.6,0,9.16,10,91.6,9.16,'001','D-1','12','KJ','RG','G','R','N')`,
      tenantId,
      YEAR,
      DAY,
      TAG,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'RNG',$4,100319000001,'P','+',1,1,10,10,9.16)`,
      tenantId,
      YEAR,
      DAY,
      TAG,
    );
    await exec(
      `UPDATE "SRNO_MAST" SET "TAG_SRNO"=5000 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01','splitter',$2,'USER','Y','Y','Y','N')`,
      tenantId,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01','splitter','Inventory','Tag Split','Y','Y','Y','Y')`,
      tenantId,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: {
        coCode: '01',
        lcCode: '01',
        coYear: YEAR,
        loginName: 'splitter',
        password: PASSWORD,
      },
    });
    expect(login.statusCode, login.body).toBe(200);
    const setCookie = login.headers['set-cookie'];
    const cookie = (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');

    // Short by 1 g gross at 91.6: the absorbing account takes a gold debit fine of 0.916.
    const created = await app.inject({
      method: 'POST',
      url: '/stock/tag-split',
      headers: { cookie },
      payload: {
        coBook: 'TSP',
        vchDate: DAY,
        acCode: 'SPLITAC',
        drTouch: 91.6,
        parents: [{ tagNo: TAG }],
        children: [
          { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
          { itCode: 'RNGH', grossWt: 3, touch: 91.6 },
        ],
      },
    });
    expect(created.statusCode, created.body).toBe(201);
    const legs = await query<Array<{ ac: string; ld: string; sign: string; fine: number }>>(
      `SELECT "AC_CODE" ac,coalesce("LD_CODE",'') ld,"SIGN" sign,coalesce("FINE_WT",0)::float8 fine FROM "AC_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_BOOK"='TSP' ORDER BY "LEDR_KEY"`,
      tenantId,
    );
    expect(legs.map(({ ac, ld, sign }) => ({ ac, ld, sign }))).toEqual([
      { ac: 'SPLITAC', ld: 'SALES', sign: '-' },
      { ac: 'SALES', ld: 'SPLITAC', sign: '+' },
    ]);
    for (const leg of legs) expect(leg.fine).toBeCloseTo(0.916, 3);
    expect(legs.some((leg) => leg.ac === 'PURCHASE' || leg.ld === 'PURCHASE')).toBe(false);
  });
});
