import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';

/**
 * X16 over HTTP, on a company created by web provisioning — which now carries the desktop's two TR_WH_SALE
 * books (WHS `WH SALES`, RTC `RATE CUT`, twelve BOOK_DETL slots each).
 *
 * Desktop menus "Wh Sales" and "Rate Cut" open the same form scoped to their own MAIN_BOOK under their own
 * right (MDI_FORM.cs:8038-8118), so the two workflows have separate routes and rights here too.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'wh-rcut-route-db';
const PASSWORD = 'Wholesale-Route!2026';
const SECRET = 'wholesale-route-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('X16 wholesale sale and rate cut through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const request = (
    login: string,
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    url: string,
    payload?: unknown,
  ) =>
    app.inject({
      method,
      url,
      headers: { cookie: cookies[login] ?? '' },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const login = async (name: string, rights: string[]) => {
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      name,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of rights)
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Transaction',$3,'Y','Y','Y','Y')`,
        tenantId,
        name,
        subMenu,
      );
  };
  const available = async (tagNo: string): Promise<number> => {
    const [row] = await query<Array<{ bal: number }>>(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS bal FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenantId,
      tagNo,
    );
    return Number(row?.bal ?? 0);
  };

  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('wholesale route fixtures require isolated database 55433');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','WHCUST','Wholesale Customer','10')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE")
       VALUES ($1,'01','LR916','L RING 916','G','LR','G'),($1,'01','999','999 GOLD','G','FN','G')`,
      tenantId,
    );
    // A purchased tag: BAR_DETL plus the '+' stock row that makes it available.
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
    await login('wholesaler', ['Wh Sales']);
    await login('ratecutter', ['Rate Cut']);
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const name of ['wholesaler', 'ratecutter']) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const value = response.headers['set-cookie'];
      cookies[name] = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  const sale = {
    coBook: 'WHS',
    vchDate: DAY,
    acCode: 'WHCUST',
    acName: 'Wholesale Customer',
    itType: 'G',
    lines: [{ tagNo: 'LRG00001' }],
    receivedLines: [{ itCode: '999', grossWt: 10, netWt: 10, touch: 100 }],
    fineRate: 6400,
    settleCrFine: 1.931,
    pay: { cash: 12000 },
  };

  it('posts a wholesale sale that moves the tag out, cuts the balance fine into money, and reopens it', async () => {
    const created = await request('wholesaler', 'POST', '/wholesale-sales', sale);
    expect(created.statusCode, created.body).toBe(201);
    // 11.931 issued − 10.000 received leaves 1.931 fine; the operator cuts it at 6400 = 12358.4 → 12358.
    expect(created.json()).toMatchObject({
      vchNo: 1,
      settlement: { fineRate: 6400, crFine: 1.931, drAmt: 12358 },
    });
    expect(await available('LRG00001')).toBe(0);

    const legs = await query<Array<{ leg: string; ac: string; dr: number; cr: number }>>(
      `SELECT right("LEDR_KEY",2) AS leg,"AC_CODE" AS ac,"DR_AMT"::float8 AS dr,"CR_AMT"::float8 AS cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='WHS' ORDER BY "LEDR_KEY"`,
      tenantId,
    );
    // Provisioned slots: 1 SALES, 2 PURCHASE, 3 CASH.
    expect(legs).toEqual([
      { leg: '01', ac: 'WHCUST', dr: 12358, cr: 0 },
      { leg: '02', ac: 'SALES', dr: 0, cr: 12358 },
      { leg: '23', ac: 'WHCUST', dr: 0, cr: 0 },
      { leg: '29', ac: 'WHCUST', dr: 0, cr: 0 },
      { leg: '43', ac: 'WHCUST', dr: 0, cr: 12000 },
      { leg: '44', ac: 'CASH', dr: 12000, cr: 0 },
    ]);
    const [header] = await query<Array<Record<string, unknown>>>(
      `SELECT "MAIN_USER","SL_BILL_OS"::float8 AS os,"TOT_FINE_DR"::float8 AS fine_dr,
              "TOT_FINE_CR"::float8 AS fine_cr FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='WHS'`,
      tenantId,
    );
    // The signed-in user, not a body field; the outstanding is the net less the cash (12358 − 12000); the
    // party's fine closes: 11.931 issued against 10.000 received plus 1.931 cut.
    expect(header).toEqual({ MAIN_USER: 'wholesaler', os: 358, fine_dr: 11.931, fine_cr: 11.931 });

    const reopened = await request('wholesaler', 'GET', '/wholesale-sales/1?coBook=WHS');
    expect(reopened.statusCode, reopened.body).toBe(200);
    expect(reopened.json()).toMatchObject({
      settleCrFine: 1.931,
      settleDrAmt: 12358,
      lines: [
        {
          tagNo: 'LRG00001',
          vchSrno: 100312000009,
          itCode: 'LR916',
          itemName: 'L RING 916',
          tblCode: '001',
          karigarName: 'KJ',
          fine: 11.931,
        },
      ],
      receivedLines: [{ itCode: '999', itemName: '999 GOLD', fine: 10 }],
    });
  });

  it('refuses the sold tag, the other workflow’s book and the other workflow’s user with 400/403', async () => {
    const again = await request('wholesaler', 'POST', '/wholesale-sales', sale);
    expect(again.statusCode).toBe(400);
    expect(again.body).toMatch(/tag not available/);

    const wrongWorkflow = await request('ratecutter', 'POST', '/rate-cut', {
      ...sale,
      lines: [],
    });
    expect(wrongWorkflow.statusCode).toBe(400);
    expect(wrongWorkflow.body).toMatch(/use the wholesale sale workflow/);

    // A user holding only the desktop "Rate Cut" right may not post a wholesale sale.
    const forbidden = await request('ratecutter', 'POST', '/wholesale-sales', sale);
    expect(forbidden.statusCode).toBe(403);
  });

  it('posts a header-only rate cut in the provisioned Rate Cut book', async () => {
    const cut = await request('ratecutter', 'POST', '/rate-cut', {
      coBook: 'RTC',
      vchDate: DAY,
      acCode: 'WHCUST',
      itType: 'G',
      lines: [],
      receivedLines: [],
      fineRate: 7300,
      settleDrFine: 2.05,
      receivedPay: { cash: 14965 },
    });
    expect(cut.statusCode, cut.body).toBe(201);
    const legs = await query<Array<{ leg: string; ac: string; dr: number; cr: number }>>(
      `SELECT right("LEDR_KEY",2) AS leg,"AC_CODE" AS ac,"DR_AMT"::float8 AS dr,"CR_AMT"::float8 AS cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='RTC' ORDER BY "LEDR_KEY"`,
      tenantId,
    );
    expect(legs).toEqual([
      { leg: '08', ac: 'WHCUST', dr: 0, cr: 14965 },
      { leg: '09', ac: 'PURCHASE', dr: 14965, cr: 0 },
      { leg: '45', ac: 'WHCUST', dr: 14965, cr: 0 },
      { leg: '46', ac: 'CASH', dr: 0, cr: 14965 },
    ]);
  });

  it('an edit that drops the tag returns it to stock; the delete audits the signed-in user', async () => {
    const edited = await request('wholesaler', 'PUT', '/wholesale-sales/1', {
      ...sale,
      lines: [],
    });
    expect(edited.statusCode, edited.body).toBe(200);
    expect(await available('LRG00001')).toBe(1);

    const removed = await request('wholesaler', 'DELETE', '/wholesale-sales/1', { book: 'WHS' });
    expect(removed.statusCode, removed.body).toBe(200);
    const audit = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE","BOOK_NAME","DELETE_USER","MAIN_USER" FROM "DELETE_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(audit).toEqual([
      {
        VCH_TYPE: 'WSALE',
        BOOK_NAME: 'Wholesale Sale',
        DELETE_USER: 'wholesaler',
        MAIN_USER: 'wholesaler',
      },
    ]);
  });
});
