import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * G03/G17 over HTTP: the Other Expenses (TR_OTH_PURC / OTH EXP) screen saves, reads and PRINTS on a
 * company created by web provisioning (`seedCompany`), which now provisions the OEX book.
 *
 * The print route takes its voucher number from the PATH (/other-purchase/:vchNo/print). A regression
 * had the handler read it from the query string instead, so every print returned
 * `400 DocumentScopeError vchNo required` even though the voucher existed — invisible to the module-level
 * DB test, visible only when the route is exercised. This test drives the real route.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'oth-exp-print-route';
const PASSWORD = 'Other-Expenses-Print!2026';
const SECRET = 'other-expenses-print-test-signing-secret-over-thirty-two-chars';
const LOGIN = 'clerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('Other Expenses save, read and print over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const request = (method: 'GET' | 'POST' | 'DELETE', url: string, payload?: unknown) =>
    app.inject({
      method,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','SUPP01','Courier Vendor','40')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Purchase','Other Purchase','Y','Y','Y','Y')`,
      tenantId,
      LOGIN,
    );
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

  it('saves an Other Expenses voucher, reads it back and prints it from the path voucher number', async () => {
    const saved = await request('POST', '/other-purchase', {
      coBook: 'OEX',
      vchDate: DAY,
      partyCode: 'SUPP01',
      ledgerCode: 'OTHCHRG',
      billNo: 'EXP-77',
      billDate: DAY,
      cashAmount: 500,
      cashAccount: 'CASH',
      description: 'Courier charges',
      lines: [
        { hsnCode: '', itemName: 'Courier', netAmount: 500, discountPercent: 0, taxType: 'F' },
      ],
    });
    expect(saved.statusCode, saved.body).toBe(201);
    const vchNo = saved.json().voucherNo as string;
    expect(vchNo).toMatch(/^\d{5}$/);

    const q = `coBook=OEX&coYear=${YEAR}&lcCode=01`;
    const read = await request('GET', `/other-purchase/${vchNo}?${q}`);
    expect(read.statusCode, read.body).toBe(200);
    expect(read.json()).toMatchObject({ ledgerCode: 'OTHCHRG', partyCode: 'SUPP01' });

    // The regression this guards: the print route must read vchNo from the PATH, not the query string.
    const print = await request('GET', `/other-purchase/${vchNo}/print?${q}&format=html`);
    expect(print.statusCode, print.body).toBe(200);
    expect(print.headers['content-type']).toMatch(/text\/html/);
    expect(print.body).toMatch(/<html/i);

    const removed = await request('DELETE', `/other-purchase/${vchNo}?${q}`);
    expect(removed.statusCode, removed.body).toBe(200);
    // The reader rejects a voucher that no longer exists; run() maps the writer's validation error to 400.
    const readAfter = await request('GET', `/other-purchase/${vchNo}?${q}`);
    expect(readAfter.statusCode).toBe(400);
  });
});
