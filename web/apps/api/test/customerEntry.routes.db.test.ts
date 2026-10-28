import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N124 / G133: the Customer Entry (desktop UT_CUST_ENTRY) CRM workflow through the API.
 *
 * Non-financial: it writes only CUST_DATA (one row per customer/interest line) + a seed CUST_DETL
 * follow-up row (ISR_NO=1) per line, keyed by CO_BOOK = employeeCode with an employee-scoped VCH_NO;
 * no AC_DATA/ROJ_MEL_DATA/DELETE_DATA. A row persists only when it carries a name+remark, a tag, or an
 * item+reminder date (UT_CUST_ENTRY.cs:2503-2509).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'n124-customer-entry';
const PASSWORD = 'N124-Cust-Entry!2026';
const SECRET = 'n124-customer-entry-route-signing-secret-32-chars';
const LOGIN = 'crmclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('N124 customer entry (CRM) lifecycle', () => {
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
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Utilities','Customer Entry','Y','Y','Y','Y')`,
      tenantId,
      LOGIN,
    );
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

  it('posts an employee-scoped CUST_DATA aggregate + seed CUST_DETL, reopens, edits and deletes', async () => {
    const post = await req('POST', '/crm/customer-entries', {
      employeeCode: '001',
      employeeName: 'Sales Rep',
      vchDate: DAY,
      rows: [
        {
          acName: 'Mr. Sharma',
          mobileNo: '9876543210',
          itemRemark: 'Wants a gold chain',
          remDate: DAY,
        },
        {
          itemCode: 'GOLD',
          itemName: 'Gold Ring',
          itemLike: 'Y',
          remDate: DAY,
          pieces: 1,
          grossWeight: 5.5,
        },
        { acName: 'No remark so skipped' }, // does NOT qualify -> not written
      ],
    });
    expect(post.statusCode, post.body).toBe(201);
    expect(post.json()).toMatchObject({ vchNo: 1, voucherNo: '00001', rowCount: 2 });

    // CUST_DATA: 2 rows under CO_BOOK=001, VCH_NO=00001; CUST_DETL: 2 seed rows ISR_NO=1; no AC_DATA.
    const [cd] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "CUST_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='001' AND "VCH_NO"='00001'`,
      tenantId,
    );
    expect(cd?.n).toBe(2);
    const [dt] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "CUST_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='001' AND "VCH_NO"='00001' AND "ISR_NO"=1`,
      tenantId,
    );
    expect(dt?.n).toBe(2);
    const [ac] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='001'`,
      tenantId,
    );
    expect(ac?.n).toBe(0);

    // reopen
    const got = await req('GET', '/crm/customer-entries/001/1');
    expect(got.statusCode, got.body).toBe(200);
    const doc = got.json();
    expect(doc).toMatchObject({ employeeCode: '001', vchDate: DAY });
    expect(doc.rows).toHaveLength(2);
    expect(doc.rows[0]).toMatchObject({
      srNo: 1,
      acName: 'Mr. Sharma',
      itemRemark: 'Wants a gold chain',
    });
    expect(doc.rows[1]).toMatchObject({ srNo: 2, itemCode: 'GOLD', itemLike: 'Y' });

    // edit: replace with a single row
    const put = await req('PUT', '/crm/customer-entries/001/1', {
      employeeCode: '001',
      vchDate: DAY,
      rows: [{ acName: 'Mr. Sharma', itemRemark: 'Called back - interested', remDate: DAY }],
    });
    expect(put.statusCode, put.body).toBe(200);
    expect(put.json()).toMatchObject({ rowCount: 1 });
    const after = await req('GET', '/crm/customer-entries/001/1');
    expect(after.json().rows).toHaveLength(1);
    expect(after.json().rows[0]).toMatchObject({ itemRemark: 'Called back - interested' });
    const [cd2] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "CUST_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='001' AND "VCH_NO"='00001'`,
      tenantId,
    );
    expect(cd2?.n).toBe(1);

    // delete: removes both tables
    const del = await req('DELETE', '/crm/customer-entries/001/1', {});
    expect(del.statusCode, del.body).toBe(200);
    const [cd3] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "CUST_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='001' AND "VCH_NO"='00001'`,
      tenantId,
    );
    expect(cd3?.n).toBe(0);
    const [dt3] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "CUST_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='001' AND "VCH_NO"='00001'`,
      tenantId,
    );
    expect(dt3?.n).toBe(0);
  });

  it('rejects an entry with no qualifying row', async () => {
    const post = await req('POST', '/crm/customer-entries', {
      employeeCode: '002',
      vchDate: DAY,
      rows: [{ acName: 'name only, no remark' }],
    });
    expect(post.statusCode).toBe(400);
  });
});
