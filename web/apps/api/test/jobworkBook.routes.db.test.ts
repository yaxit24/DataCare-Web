import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'jobwork-book-route';
const PASSWORD = 'Jobwork-Book-Route!2026';
const SECRET = 'jobwork-book-route-test-signing-secret-over-thirty-two-chars';
const LOGIN = 'jobworker';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('configured JDTR Job-work books over HTTP', () => {
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
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of ['Job-work Issue', 'Job-work Receive']) {
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Manufacturing',$3,'Y','Y','Y','Y')`,
        tenantId,
        LOGIN,
        subMenu,
      );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
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

  it('accepts only JDTR ISU on issue and JDTR REC on receipt, with zero wrong-family writes', async () => {
    const issuePayload = {
      coBook: 'JDI',
      vchDate: DAY,
      karigarAc: 'PURCHASE',
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 2, netWt: 2, touch: 90 }],
    };
    const issue = await request('POST', '/mfg/jobwork-issue', issuePayload);
    expect(issue.statusCode, issue.body).toBe(201);
    const issueNo = String(issue.json().vchNo).padStart(5, '0');

    const wrongIssue = await request('POST', '/mfg/jobwork-issue', {
      ...issuePayload,
      coBook: 'JDR',
    });
    expect(wrongIssue.statusCode).toBe(400);
    expect(wrongIssue.body).toMatch(/expected JDTR ISU/);

    const receivePayload = {
      coBook: 'JDR',
      vchDate: DAY,
      karigarAc: 'PURCHASE',
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 1.5, netWt: 1.5, touch: 90 }],
    };
    const received = await request('POST', '/mfg/jobwork-receive', receivePayload);
    expect(received.statusCode, received.body).toBe(201);
    const receiveNo = String(received.json().vchNo).padStart(5, '0');

    const wrongReceive = await request('POST', '/mfg/jobwork-receive', {
      ...receivePayload,
      coBook: 'JDI',
    });
    expect(wrongReceive.statusCode).toBe(400);
    expect(wrongReceive.body).toMatch(/expected JDTR REC/);
    const missingBook = await request('POST', '/mfg/jobwork-issue', {
      ...issuePayload,
      coBook: undefined,
    });
    expect(missingBook.statusCode).toBe(400);

    const rows = await query<Array<Record<string, unknown>>>(
      `SELECT "CO_BOOK","BOOK_NAME","VCH_TYPE","INOUT_TYPE","MAIN_USER" FROM "MFG_DATA"
        WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
      tenantId,
    );
    expect(rows).toEqual([
      {
        CO_BOOK: 'JDI',
        BOOK_NAME: 'Jadtar Issue',
        VCH_TYPE: 'JDISU',
        INOUT_TYPE: 'O',
        MAIN_USER: LOGIN,
      },
      {
        CO_BOOK: 'JDR',
        BOOK_NAME: 'Jadtar Receipt',
        VCH_TYPE: 'JDREC',
        INOUT_TYPE: 'I',
        MAIN_USER: LOGIN,
      },
    ]);

    const opened = await request(
      'GET',
      `/mfg/jobwork-issue/${issueNo}?coBook=JDI&coYear=${YEAR}&lcCode=01`,
    );
    expect(opened.statusCode, opened.body).toBe(200);
    expect(opened.json()).toMatchObject({ voucherNo: issueNo, mainUser: LOGIN, mode: 'issue' });
    const openedReceipt = await request(
      'GET',
      `/mfg/jobwork-receive/${receiveNo}?coBook=JDR&coYear=${YEAR}&lcCode=01`,
    );
    expect(openedReceipt.statusCode, openedReceipt.body).toBe(200);
    expect(openedReceipt.json()).toMatchObject({
      voucherNo: receiveNo,
      mainUser: LOGIN,
      mode: 'receive',
    });

    const deletedIssue = await request(
      'DELETE',
      `/mfg/jobwork-issue/${issueNo}?coBook=JDI&coYear=${YEAR}&lcCode=01`,
    );
    const deletedReceipt = await request(
      'DELETE',
      `/mfg/jobwork-receive/${receiveNo}?coBook=JDR&coYear=${YEAR}&lcCode=01`,
    );
    expect(deletedIssue.statusCode, deletedIssue.body).toBe(200);
    expect(deletedReceipt.statusCode, deletedReceipt.body).toBe(200);
  });
});
