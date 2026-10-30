import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N172 (G179) over HTTP: the voucher number box's Up and Down keys walk like the desktop BtnLast_Click and
 * BtnFirst_Click (TR_SALE.cs:17164-17222). Up steps to the next saved voucher and Down to the previous one, trying at
 * most 10 numbers and then showing the number reached; Up past the last saved voucher is the next new number, and Up
 * at it says "Last Record...". Only the session's company, location and year and the requested book count.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'vch-neighbour-db';
const PASSWORD = 'Voucher-Neighbour!2026';
const SECRET = 'voucher-neighbour-route-test-signing-secret-32+';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const OTHER_YEAR = `${startYear - 1}-${startYear}`;

(enabled ? describe : describe.skip)('N172 voucher number Up/Down walk over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const sale = (book: string, vchNo: string, year = YEAR) =>
    owner.$executeRawUnsafe(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME")
       VALUES($1,'01','01',$2,$3,$4,'00001','WALK TEST')`,
      tenantId,
      year,
      book,
      vchNo,
    );
  const walk = async (book: string, from: string, direction: string, table = 'SL_DATA') => {
    const response = await app.inject({
      method: 'GET',
      url: `/vouchers/neighbour?table=${table}&book=${book}&from=${from}&direction=${direction}`,
      headers: { cookie },
    });
    return { status: response.statusCode, body: response.json() };
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01','walker',$2,'ADMIN','Y','Y','Y','N')`,
      tenantId,
      await hashPassword(PASSWORD),
    );
    // Book SL: 1, 2, 3, 5 and 20 (6-19 deleted). Voucher 4 exists only in another book and another year.
    for (const vchNo of ['00001', '00002', '00003', '00005', '00020']) await sale('SL', vchNo);
    await sale('SX', '00004');
    await sale('SL', '00004', OTHER_YEAR);
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: {
        coCode: '01',
        lcCode: '01',
        coYear: YEAR,
        loginName: 'walker',
        password: PASSWORD,
      },
    });
    expect(login.statusCode, login.body).toBe(200);
    const value = login.headers['set-cookie'];
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

  it('from the new-entry state, Down opens the last saved voucher and Up says Last Record', async () => {
    expect(await walk('SL', '', 'previous')).toEqual({
      status: 200,
      body: { action: 'open', vchNo: '00020' },
    });
    expect(await walk('SL', '', 'next')).toEqual({ status: 200, body: { action: 'last' } });
  });

  it('Up and Down step to the next and previous saved voucher of this book and year only', async () => {
    expect((await walk('SL', '00003', 'next')).body).toEqual({ action: 'open', vchNo: '00005' });
    expect((await walk('SL', '00005', 'previous')).body).toEqual({
      action: 'open',
      vchNo: '00003',
    });
    expect((await walk('SL', '00002', 'previous')).body).toEqual({
      action: 'open',
      vchNo: '00001',
    });
    expect((await walk('SL', '2', 'next')).body).toEqual({ action: 'open', vchNo: '00003' });
    expect((await walk('SX', '', 'previous')).body).toEqual({ action: 'open', vchNo: '00004' });
  });

  it('Up from the last saved voucher is the next new number; Up there says Last Record', async () => {
    expect((await walk('SL', '00020', 'next')).body).toEqual({ action: 'new' });
    expect((await walk('SL', '00021', 'next')).body).toEqual({ action: 'last' });
    expect((await walk('SL', '00030', 'next')).body).toEqual({ action: 'last' });
  });

  it('Down at voucher 1 does nothing', async () => {
    expect((await walk('SL', '00001', 'previous')).body).toEqual({ action: 'none' });
    expect((await walk('SL', '1', 'previous')).body).toEqual({ action: 'none' });
  });

  it('after 10 missing numbers the walk stops on the number it reached, as the desktop loop does', async () => {
    // Up from 5 tries 6-15, then shows 16 (no voucher); Down from 20 tries 19-10, then shows 9.
    expect((await walk('SL', '00005', 'next')).body).toEqual({ action: 'missing', vchNo: '00016' });
    expect((await walk('SL', '00020', 'previous')).body).toEqual({
      action: 'missing',
      vchNo: '00009',
    });
    // A typed number that has no voucher still walks from it.
    expect((await walk('SL', '00018', 'next')).body).toEqual({ action: 'open', vchNo: '00020' });
    // Down stops at 1 even when voucher 1 does not exist in the book.
    expect((await walk('SX', '00004', 'previous')).body).toEqual({
      action: 'missing',
      vchNo: '00001',
    });
  });

  it('an empty book: Up says Last Record and Down does nothing', async () => {
    expect((await walk('SZ', '', 'next')).body).toEqual({ action: 'last' });
    expect((await walk('SZ', '', 'previous')).body).toEqual({ action: 'none' });
  });

  it('refuses an unknown table or direction, and answers 401 without a session', async () => {
    const table = await walk('SL', '', 'next', 'LOGIN_MAST');
    expect(table.status).toBe(400);
    expect(table.body.error).toBe('VoucherNeighbourValidationError');
    expect((await walk('SL', '', 'sideways')).status).toBe(400);
    const anonymous = await app.inject({
      method: 'GET',
      url: '/vouchers/neighbour?table=SL_DATA&book=SL&direction=next',
    });
    expect(anonymous.statusCode).toBe(401);
  });

  it('the recent-voucher list still answers from its new route file', async () => {
    const response = await app.inject({
      method: 'GET',
      url: '/vouchers/recent?table=SL_DATA&book=SL',
      headers: { cookie },
    });
    expect(response.statusCode).toBe(200);
    expect(
      response
        .json()
        .map((row: { vchNo: string }) => row.vchNo)
        .sort(),
    ).toEqual(['00001', '00002', '00003', '00005', '00020']);
  });
});
