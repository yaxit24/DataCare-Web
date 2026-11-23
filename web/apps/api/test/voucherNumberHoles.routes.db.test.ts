import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-10 F2: a PUT edits a saved voucher; it never creates one. The rate-cut family writes RATE_CUT_DATA, which has no
 * unique key on the voucher number, so a PUT that created at the typed URL number (outside the `nextVoucherNoTx`
 * advisory lock) could give two vouchers one number. The desktop opens a typed number and, when no voucher has it,
 * stays in add mode (TR_SALE.cs:14851 {{EntryMode = "A";}}); the number of a new voucher is taken at save. Here: a PUT
 * of an unused number answers 404 `voucher-not-found` and writes nothing, and two concurrent creates of one book get
 * two different numbers from the allocator.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'wp10-number-holes';
const PASSWORD = 'Wp10-Number-Holes!2026';
const SECRET = 'wp10-number-holes-route-signing-secret-over-thirty-two';
const LOGIN = 'numberclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('WP-10 PUT edits only saved rate-cut family vouchers', () => {
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
  const req = (method: 'GET' | 'POST' | 'PUT', url: string, payload?: unknown) =>
    app.inject({ method, url, headers: { cookie }, payload: payload as any });
  const rowsOf = async (book: string, vchNo: string) => {
    const [row] = await query<Array<{ n: number }>>(
      `SELECT ((SELECT count(*) FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3)
             + (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3))::int n`,
      tenantId,
      book,
      vchNo,
    );
    return Number(row?.n ?? 0);
  };
  /** A header-only voucher: it settles fine against money, so it needs no tag or item. */
  const voucher = (coBook: string) => ({
    coBook,
    vchDate: DAY,
    acCode: 'NUMCUST',
    itType: 'G',
    lines: [],
    receivedLines: [],
    fineRate: 7300,
    settleDrFine: 1,
    receivedPay: { cash: 7300 },
  });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','NUMCUST','Number Customer','10')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of ['Wh Sales', 'Rate Cut', 'Wh Quotation', 'Tour'])
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Transaction',$3,'Y','Y','Y','Y')`,
        tenantId,
        LOGIN,
        subMenu,
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

  it.each([
    ['/wholesale-sales', 'WHS'],
    ['/rate-cut', 'RTC'],
    ['/wholesale-quotations', 'WHQ'],
    ['/tour-sales', 'TSL'],
  ])(
    'PUT %s/<unused number> answers 404 voucher-not-found and writes nothing',
    async (path, book) => {
      const put = await req('PUT', `${path}/500`, voucher(book));
      expect(put.statusCode, put.body).toBe(404);
      expect(put.json()).toMatchObject({ error: 'voucher-not-found' });
      expect(await rowsOf(book, '00500')).toBe(0);
      // The next POST is still the book's next number, not one past the typed number.
      const created = await req('POST', path, voucher(book));
      expect(created.statusCode, created.body).toBe(201);
      expect(created.json()).toMatchObject({ vchNo: 1 });
      // And a PUT of that saved number edits it.
      const edited = await req('PUT', `${path}/1`, { ...voucher(book), fineRate: 7400 });
      expect(edited.statusCode, edited.body).toBe(200);
      expect(edited.json()).toMatchObject({ vchNo: 1 });
    },
  );

  it('two concurrent creates of one book get two different numbers', async () => {
    const results = await Promise.all([
      req('POST', '/rate-cut', voucher('RTC')),
      req('POST', '/rate-cut', voucher('RTC')),
      req('POST', '/rate-cut', voucher('RTC')),
    ]);
    for (const res of results) expect(res.statusCode, res.body).toBe(201);
    const numbers = results.map((res) => Number(res.json().vchNo)).sort((a, b) => a - b);
    // Voucher 1 of RTC was created by the previous case.
    expect(numbers).toEqual([2, 3, 4]);
    const headers = await query<Array<{ vch: string; n: number }>>(
      `SELECT "VCH_NO" vch,count(*)::int n FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='RTC'
        GROUP BY "VCH_NO" ORDER BY "VCH_NO"`,
      tenantId,
    );
    expect(headers).toEqual([
      { vch: '00001', n: 1 },
      { vch: '00002', n: 1 },
      { vch: '00003', n: 1 },
      { vch: '00004', n: 1 },
    ]);
  });
});
