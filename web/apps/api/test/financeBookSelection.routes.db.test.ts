import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';

/**
 * D1 and the D6 provisioning half, over HTTP, on a company created by web provisioning (`seedCompany`).
 * This is the path the 28 September evaluation drove through the browser.
 *
 * Before the fix:
 * - Cash Received / Cash Payment could not be saved, because the form sent no book (HTTP 400).
 * - A write-off could not be saved either: nothing supplied its account.
 * - The company's CO_SET left SL_AMT_TYPE NULL.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'finance-book-route-db';
const PASSWORD = 'Finance-Book-Route!2026';
const SECRET = 'finance-book-route-test-signing-secret-over-thirty-two-chars';
const LOGIN = 'cashier';
// seedCompany opens the April-to-March fiscal year around today, as the desktop would.
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('D1 receipts, payments and contra through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
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
  const request = (method: 'GET' | 'POST', url: string, payload?: unknown) =>
    app.inject({
      method,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });

  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('finance route fixtures require isolated database 55433');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','CUST01','Walk-in Customer','10')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of ['Cash Received', 'Cash Payment', 'Contra Entry']) {
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Transaction',$3,'Y','Y','Y','Y')`,
        tenantId,
        LOGIN,
        subMenu,
      );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
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

  it('provisions desktop CO_SET amount types and a kasar account in slot 2 of the cash books', async () => {
    const [coSet] = await query<Array<{ sl: string; pr: string }>>(
      `SELECT "SL_AMT_TYPE" sl,"PR_AMT_TYPE" pr FROM "CO_SET" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(coSet).toEqual({ sl: 'N', pr: 'F' });
    const slots = await query<Array<{ book: string; sr: number; ac: string }>>(
      `SELECT "CO_BOOK" book,"SR_NO"::int sr,"AC_CODE" ac FROM "BOOK_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK" IN ('RCT','PAY') ORDER BY 1,2`,
      tenantId,
    );
    expect(slots).toEqual([
      { book: 'PAY', sr: 1, ac: 'CASH' },
      { book: 'PAY', sr: 2, ac: 'KASAR' },
      { book: 'RCT', sr: 1, ac: 'CASH' },
      { book: 'RCT', sr: 2, ac: 'KASAR' },
    ]);
  });

  it('D1-1: a cash receipt with the book the form now sends is saved, posted and printable', async () => {
    // The request the form used to send, without a book, is still refused, and explains why.
    const unbooked = await request('POST', '/receipts', {
      partyAc: 'CUST01',
      amount: 1000,
      mode: 'cash',
    });
    expect(unbooked.statusCode).toBe(400);
    expect(unbooked.body).toMatch(/configured book/);

    const saved = await request('POST', '/receipts', {
      coBook: 'RCT',
      partyAc: 'CUST01',
      partyName: 'Walk-in Customer',
      amount: 1000,
      kasar: 15,
      mode: 'cash',
    });
    expect(saved.statusCode, saved.body).toBe(201);
    expect(saved.json()).toEqual({ vchNo: 1 });
    const cash = await query<Array<Record<string, unknown>>>(
      `SELECT "CO_BOOK","VCH_NO","REC_AMT"::float rec,"KASAR_AMT"::float kasar,"REC_AC_CODE" FROM "CASH_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(cash).toEqual([
      { CO_BOOK: 'RCT', VCH_NO: '00001', rec: 1000, kasar: 15, REC_AC_CODE: 'CASH' },
    ]);
    const legs = await query<Array<{ ac: string; dr: number; cr: number }>>(
      `SELECT "AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='RCT' ORDER BY "LEDR_KEY"`,
      tenantId,
    );
    // 01/02 the money, 03/04 the write-off against the provisioned slot-2 KASAR account.
    expect(legs).toEqual([
      { ac: 'CUST01', dr: 0, cr: 1000 },
      { ac: 'CASH', dr: 1000, cr: 0 },
      { ac: 'CUST01', dr: 0, cr: 15 },
      { ac: 'KASAR', dr: 15, cr: 0 },
    ]);
    const print = await request(
      'GET',
      '/finance/receipt-voucher?coBook=RCT&vchNo=00001&format=html',
    );
    expect(print.statusCode, print.body).toBe(200);
    expect(print.body).toContain('1,000');
  });

  it('D1-2: a cash payment is saved in the PAY book', async () => {
    const saved = await request('POST', '/payments', {
      coBook: 'PAY',
      partyAc: 'CUST01',
      amount: 750,
      mode: 'cash',
    });
    expect(saved.statusCode, saved.body).toBe(201);
    const pay = await query<Array<Record<string, unknown>>>(
      `SELECT "CO_BOOK","VCH_NO","NET_AMT"::float net,"CASH_AMT"::float cash FROM "PAY_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(pay).toEqual([{ CO_BOOK: 'PAY', VCH_NO: '00001', net: 750, cash: 750 }]);
  });

  it('D1-5 over HTTP: a receipt into the SALES book is refused and writes nothing', async () => {
    const before = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    const refused = await request('POST', '/receipts', {
      coBook: 'SL',
      partyAc: 'CUST01',
      amount: 10,
      mode: 'cash',
    });
    expect(refused.statusCode).toBe(400);
    expect(refused.json()).toMatchObject({ error: 'FinanceValidationError' });
    const after = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(after).toEqual(before);
  });

  it('contra is saved in the provisioned CONTRA book', async () => {
    const saved = await request('POST', '/contra', {
      coBook: 'CON',
      fromAc: 'CASH',
      toAc: 'BANK',
      amount: 500,
      vchDate: DAY,
    });
    expect(saved.statusCode, saved.body).toBe(201);
    const legs = await query<Array<{ ac: string; dr: number; cr: number }>>(
      `SELECT "AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='CON' ORDER BY "DR_AMT" DESC`,
      tenantId,
    );
    expect(legs).toEqual([
      { ac: 'BANK', dr: 500, cr: 0 },
      { ac: 'CASH', dr: 0, cr: 500 },
    ]);
  });
});
