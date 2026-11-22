import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-15 Tag Stock over HTTP: the List right opens the JSON report, the Print right is needed for CSV and Excel
 * (RP_TAG.cs:3257-3263 refuses Excel without the print right; the web also refuses the other outputs), a bad mode
 * is a 400 rather than a silent stock report, and the CSV carries every row plus a TOTAL row equal to the JSON
 * footer (no 5000-row cap, gap 7).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'tag-stock-routes';
const PASSWORD = 'Tag-Stock-Routes!2026';
const SECRET = 'tag-stock-routes-test-signing-secret-thirty-two';
const YEAR = '2026-2027';

(enabled ? describe : describe.skip)('Tag Stock routes (rights, validation, CSV = JSON)', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies = new Map<string, string>();
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const login = async (user: string): Promise<string> => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const setCookie = response.headers['set-cookie'];
    return (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };
  const get = (user: string, url: string) =>
    app.inject({ method: 'GET', url, headers: { cookie: cookies.get(user) ?? '' } });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    const hash = await hashPassword(PASSWORD);
    const users: Array<[string, string, string | null]> = [
      ['tsprint', 'Y', 'Y'],
      ['tslist', 'Y', 'N'],
      ['tsnone', 'N', 'N'],
    ];
    for (const [user, view, print] of users) {
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES ($1,'01',$2,$3,'USER','N','N',$4,'N')`,
        tenantId,
        user,
        hash,
        print,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES ($1,'01','01',$2,'Desktop','Tag Stock',$3,'N','N',$4)`,
        tenantId,
        user,
        view,
        print,
      );
    }
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES ($1,'01','GR','Gold Ring','G')`,
      tenantId,
    );
    // 5,100 tags (more than the former 5,000-row cap), each +1 id, 1 pc, 1.000 gross, 0.900 net, MRP 100.
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_DATE","VCH_TYPE",
         "IT_CODE","TAG_NO","TBL_CODE","ITM_PCS","ITM_GWT","ITM_NWT","LBR_AMT","OTH_AMT","KR_COST","ITM_MRP","VCH_SRNO","DATA_TYPE")
       SELECT $1,'01','01',$2,'TOP','B'||g,'2026-04-05','2026-04-05','TO','GR','B'||lpad(g::text,5,'0'),'C1',1,1.000,0.900,5,1,80,100,g,'A'
         FROM generate_series(1,5100) g`,
      tenantId,
      YEAR,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TYPE",
         "IT_CODE","TAG_NO","TBL_CODE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","VCH_SRNO","DATA_TYPE")
       SELECT $1,'01','01',$2,'TOP','B'||g,'2026-04-05','TO','GR','B'||lpad(g::text,5,'0'),'C1','+',1,1.000,0.900,g,'A'
         FROM generate_series(1,5100) g`,
      tenantId,
      YEAR,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const user of ['tsprint', 'tslist', 'tsnone']) cookies.set(user, await login(user));
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('a user without the List right is refused (JSON, CSV and Excel)', async () => {
    for (const path of ['/reports/tag-stock', '/reports/tag-stock.csv', '/reports/tag-stock.xlsx'])
      expect((await get('tsnone', path)).statusCode, path).toBe(403);
  });

  it('a list-only user reads the report but is refused CSV and Excel without the Print right', async () => {
    const json = await get('tslist', '/reports/tag-stock?tab=stock&toDate=2026-05-31');
    expect(json.statusCode, json.body).toBe(200);
    expect(json.json().rows).toHaveLength(5100);
    expect((await get('tslist', '/reports/tag-stock.csv?tab=stock')).statusCode).toBe(403);
    expect((await get('tslist', '/reports/tag-stock.xlsx?tab=stock')).statusCode).toBe(403);
  });

  it('JSON totals and the CSV cover all 5,100 rows and agree', async () => {
    const json = (await get('tsprint', '/reports/tag-stock?tab=stock&toDate=2026-05-31')).json();
    expect(json.rows).toHaveLength(5100);
    expect(json.totals).toMatchObject({
      qty: 5100,
      pcs: 5100,
      grossWt: 5100,
      mrp: 510000,
      prCost: 5100 * 80,
      lbrAmt: 5100 * 5,
      othAmt: 5100,
    });
    expect(Math.abs(json.totals.netWt - 5100 * 0.9)).toBeLessThan(1e-6);
    const csv = await get('tsprint', '/reports/tag-stock.csv?tab=stock&toDate=2026-05-31');
    expect(csv.statusCode).toBe(200);
    expect(String(csv.headers['content-type'])).toContain('text/csv');
    const lines = csv.body.split('\n');
    const header = lines[0]!.split(',');
    expect(header.slice(0, 6)).toEqual(['LcCode', 'VchTyp', 'VchNo', 'VchDate', 'Day', 'TagNo']);
    expect(lines).toHaveLength(1 + 5100 + 1);
    const total = lines[lines.length - 1]!.split(',');
    expect(total[0]).toBe('TOTAL');
    expect(Number(total[header.indexOf('Qty')])).toBe(5100);
    expect(Number(total[header.indexOf('Mrp')])).toBe(510000);
    const xlsx = await get('tsprint', '/reports/tag-stock.xlsx?tab=stock&toDate=2026-05-31');
    expect(xlsx.statusCode).toBe(200);
  });

  it('an unknown mode, view or date is a 400, never a silent stock report', async () => {
    for (const q of [
      'tab=bogus',
      'tab=STOCK%20;%20DROP',
      'view=sideways',
      'toDate=2026-02-30',
      'dataType=Z',
    ]) {
      const res = await get('tsprint', `/reports/tag-stock?${q}`);
      expect(res.statusCode, q).toBe(400);
      expect(res.json()).toMatchObject({ error: 'invalid-request' });
    }
  });

  it('hostile filter text is a value: zero rows, status 200', async () => {
    const res = await get(
      'tsprint',
      `/reports/tag-stock?tab=stock&tagNo=${encodeURIComponent("A'00")}&itCode=${encodeURIComponent("X' OR '1'='1")}`,
    );
    expect(res.statusCode).toBe(200);
    expect(res.json().rows).toHaveLength(0);
  });
});
