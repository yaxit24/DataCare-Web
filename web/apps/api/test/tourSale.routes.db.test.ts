import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N127 / G136: Tour Sales (desktop TR_TOUR_SALE). The desktop form posts the SAME TR_WH_SALE engine
 * (Wh_Sales_Ledr/Rojmel/Stk) on a TOUR SALES book. The web therefore serves it with the wholesale-sale
 * writers under a `tour-sale` book guard that accepts only the provisioned TSL (TOUR SALES) book.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'n127-tour-sale';
const PASSWORD = 'N127-Tour-Sale!2026';
const SECRET = 'n127-tour-sale-route-signing-secret-over-thirty-two-chars';
const LOGIN = 'tourclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('N127 tour sales through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...p: unknown[]) => owner.$executeRawUnsafe(sql, ...p);
  const query = <T>(sql: string, ...p: unknown[]) => owner.$queryRawUnsafe(sql, ...p) as Promise<T>;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const req = (method: string, url: string, payload?: unknown) =>
    app.inject({ method: method as any, url, headers: { cookie }, payload: payload as any });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','TOURCUST','Tour Customer','10')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE")
       VALUES ($1,'01','LR916','L RING 916','G','LR','G'),($1,'01','999','999 GOLD','G','FN','G')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH",
         "ITM_WEST_PRC","ITM_FINE","TBL_CODE","KR_NAME","PR_CODE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',1,$3::date,'PURCHASE','I','LRG00001',100312000009,'LR916',1,12.3,12.3,
               92,5,11.931,'001','KJ','LR','N')`,
      tenantId,
      YEAR,
      DAY,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','00001',2,1,$3::date,'LR916','LRG00001',100312000009,'P','+',1,1,12.3,12.3)`,
      tenantId,
      YEAR,
      DAY,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    // Tour Sales shares the desktop "Tour / Approval Sale" form right.
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Transaction','Tour','Y','Y','Y','Y')`,
      tenantId,
      LOGIN,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const res = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
    });
    expect(res.statusCode, res.body).toBe(200);
    const value = res.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  const sale = {
    coBook: 'TSL',
    vchDate: DAY,
    acCode: 'TOURCUST',
    acName: 'Tour Customer',
    itType: 'G',
    lines: [{ tagNo: 'LRG00001' }],
    receivedLines: [{ itCode: '999', grossWt: 10, netWt: 10, touch: 100 }],
    fineRate: 6400,
    settleCrFine: 1.931,
    pay: { cash: 12000 },
  };

  it('posts a tour sale on the TOUR SALES book, moves the tag out, cuts the fine, and reopens it', async () => {
    const created = await req('POST', '/tour-sales', sale);
    expect(created.statusCode, created.body).toBe(201);
    expect(created.json()).toMatchObject({ vchNo: 1 });

    // RATE_CUT_DATA row under the TSL book, posted via the wholesale engine
    const [hdr] = await query<Array<{ ac: string }>>(
      `SELECT "AC_CODE" ac FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSL' AND "VCH_NO"='00001'`,
      tenantId,
    );
    expect(hdr).toMatchObject({ ac: 'TOURCUST' });
    // the AC_DATA ledger carries the TOUR SALES book name (resolved per-voucher from BOOK_DATA)
    const [bn] = await query<Array<{ bn: string }>>(
      `SELECT "BOOK_NAME" bn FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSL' LIMIT 1`,
      tenantId,
    );
    expect(bn?.bn).toBe('TOUR SALES');
    // balanced AC_DATA legs on the TSL book
    const legs = await query<Array<{ dr: number; cr: number }>>(
      `SELECT "DR_AMT"::float8 dr,"CR_AMT"::float8 cr FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSL'`,
      tenantId,
    );
    const dr = legs.reduce((s, l) => s + l.dr, 0);
    const cr = legs.reduce((s, l) => s + l.cr, 0);
    expect(dr).toBeCloseTo(cr, 2);
    // the tag is no longer available
    const [stk] = await query<Array<{ bal: number }>>(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS bal FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"='LRG00001'`,
      tenantId,
    );
    expect(stk?.bal).toBe(0);

    // reopen
    const got = await req('GET', '/tour-sales/1?coBook=TSL');
    expect(got.statusCode, got.body).toBe(200);
    expect(got.json()).toMatchObject({ acCode: 'TOURCUST' });
  });

  it('rejects a tour sale posted on a non-TOUR-SALES book', async () => {
    const bad = await req('POST', '/tour-sales', {
      ...sale,
      coBook: 'WHS',
      lines: [],
      receivedLines: [],
    });
    expect(bad.statusCode).toBe(400);
    expect(bad.body).toMatch(/workflow|TOUR SALES|wholesale/i);
  });
});
