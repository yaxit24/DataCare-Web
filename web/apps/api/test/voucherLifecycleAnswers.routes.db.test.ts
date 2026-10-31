import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { readFileSync } from 'node:fs';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N183 (G193, G194) over HTTP, on a company created by web provisioning.
 *
 * - The desktop stores the logged-in user on a sales return (`DC_Main.MCo_User`, TR_SALE_RTN.cs:9966, :12908) and on
 *   its DELETE_DATA row (:15076). The web stored a blank MAIN_USER and the tenant id as DELETE_USER.
 * - Deleting a voucher that another operator has already deleted answered 500, because
 *   `PersistedVoucherNotFoundError` was not mapped; it is a stale document and answers 404 `voucher-not-found`.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'voucher-answers-route-db';
const PASSWORD = 'Voucher-Answers-Route!2026';
const SECRET = 'voucher-answers-route-test-signing-secret-over-thirty-two';
const LOGIN = 'counter1';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('N183 voucher answers and audit users through HTTP', () => {
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
  const request = (method: 'POST' | 'DELETE', url: string, payload?: unknown) =>
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
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC") VALUES ($1,'01','G1','GOLD','SALES','PURCHASE')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES ($1,'01','GLD','GOLD ORNAMENT','G','G1')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE") VALUES ($1,'01','01','CUST1','LOCAL CUSTOMER','10','L')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
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

  it('records the logged-in user on a sales return and its delete, and refuses a second delete with 404', async () => {
    const created = await request('POST', '/sales-returns?coBook=SRT', {
      acCode: 'CUST1',
      acName: 'LOCAL CUSTOMER',
      vchDate: DAY,
      taxRatePct: 3,
      lines: [{ itCode: 'GLD', tagNo: 'N', pcs: 1, grossWt: 5, netWt: 5, touch: 100, rate: 1500 }],
    });
    expect(created.statusCode, created.body).toBe(201);
    const vchNo = String(created.json().vchNo).padStart(5, '0');
    const [header] = await query<Array<{ mu: string }>>(
      `SELECT btrim("MAIN_USER"::text) mu FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"=$2`,
      tenantId,
      vchNo,
    );
    expect(header?.mu).toBe(LOGIN);

    const first = await request('DELETE', `/sales-returns/${vchNo}?coBook=SRT`);
    expect(first.statusCode, first.body).toBe(200);
    const audit = await query<Array<{ du: string }>>(
      `SELECT btrim("DELETE_USER"::text) du FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"=$2`,
      tenantId,
      vchNo,
    );
    expect(audit.map((row) => row.du)).toEqual([LOGIN]);

    const second = await request('DELETE', `/sales-returns/${vchNo}?coBook=SRT`);
    expect(second.statusCode, second.body).toBe(404);
    expect(second.json()).toMatchObject({ error: 'voucher-not-found' });
    const counted = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT'`,
      tenantId,
    );
    expect(counted[0]?.n).toBe(1);
  });

  it('passes the login name, never the tenant id, as the delete user on every voucher route', () => {
    const routes = readFileSync(new URL('../src/routes/txn.ts', import.meta.url), 'utf8');
    expect(routes).not.toMatch(/deleteUser:\s*sess\(req\)\.tenantId/);
    expect(routes.match(/deleteUser:\s*sess\(req\)\.sub/g)?.length ?? 0).toBeGreaterThanOrEqual(40);
  });
});
