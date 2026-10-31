import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N51 (D17) over HTTP for a sale: GET returns `version`, PUT and DELETE require it as `expectedVersion`, and a stale
 * one is `409 voucher-version-conflict` with nothing written (G170: two operators on one voucher, the second save
 * silently overwrote the first).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'sale-version-db';
const LOGIN = 'counter';
const PASSWORD = 'Sale-Version-Token!2026';
const SECRET = 'sale-version-route-test-signing-secret-with-32+';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const BOOK = 'SL';
const LINE = { itCode: 'GLD01', pcs: 1, grossWt: 10.25, netWt: 10, touch: 91.6, rate: 6000 };

(enabled ? describe : describe.skip)('N51 sale version token over HTTP', () => {
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
  const call = (method: 'POST' | 'PUT' | 'GET' | 'DELETE', url: string, payload?: unknown) =>
    app.inject({ method, url, headers: { cookie }, payload: payload as any });
  const sale = (rate: number) => ({
    coBook: BOOK,
    acCode: 'CUST01',
    vchDate: DAY,
    taxRatePct: 3,
    interState: false,
    lines: [{ ...LINE, rate }],
  });
  const create = async () => {
    const saved = await call('POST', '/sales', sale(6000));
    expect(saved.statusCode, saved.body).toBe(201);
    return String(saved.json().vchNo).padStart(5, '0');
  };
  const read = async (vchNo: string) => {
    const response = await call('GET', `/sales/${vchNo}?coBook=${BOOK}`);
    expect(response.statusCode, response.body).toBe(200);
    return response.json();
  };
  const lineRate = async (vchNo: string) =>
    (
      (await owner.$queryRawUnsafe(
        `SELECT "ITM_RATE"::float rate FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        tenantId,
        BOOK,
        vchNo,
      )) as Array<{ rate: number }>
    ).map((row) => row.rate);

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC") VALUES ($1,'01','E1','E2E GOLD','SALES','PURCHASE')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES ($1,'01','GLD01','GOLD 22K ORNAMENT','G','E1')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR") VALUES ($1,'01','01','CUST01','LOCAL CUSTOMER','L','10')`,
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
       VALUES($1,'01','01',$2,'Transaction','Sales Invoice','Y','Y','Y','Y')`,
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

  it('the read returns a 64-hex version; an update without one, or with a malformed one, is a 400', async () => {
    const vchNo = await create();
    const { version } = await read(vchNo);
    expect(version).toMatch(/^[0-9a-f]{64}$/);
    for (const expectedVersion of [undefined, '', 'abc', version.toUpperCase()]) {
      const refused = await call('PUT', `/sales/${vchNo}`, { ...sale(6100), expectedVersion });
      expect(refused.statusCode, refused.body).toBe(400);
      expect(refused.json().error).toBe('VoucherVersionValidationError');
    }
    const noToken = await call('DELETE', `/sales/${vchNo}?coBook=${BOOK}`);
    expect(noToken.statusCode, noToken.body).toBe(400);
    expect(await lineRate(vchNo)).toEqual([6000]);
  });

  it('G170: the stale second save is refused with 409 and the first save survives', async () => {
    const vchNo = await create();
    const first = (await read(vchNo)).version;
    const second = (await read(vchNo)).version;
    expect(second).toBe(first);
    const one = await call('PUT', `/sales/${vchNo}`, { ...sale(6500), expectedVersion: first });
    expect(one.statusCode, one.body).toBe(200);
    expect(one.json().version).toMatch(/^[0-9a-f]{64}$/);
    expect(one.json().version).not.toBe(first);
    const two = await call('PUT', `/sales/${vchNo}`, { ...sale(7000), expectedVersion: second });
    expect(two.statusCode, two.body).toBe(409);
    expect(two.json()).toMatchObject({ error: 'voucher-version-conflict' });
    expect(await lineRate(vchNo)).toEqual([6500]);
    // The version the update returned is the current one: a further save with it succeeds.
    const three = await call('PUT', `/sales/${vchNo}`, {
      ...sale(6600),
      expectedVersion: one.json().version,
    });
    expect(three.statusCode, three.body).toBe(200);
    expect((await read(vchNo)).version).toBe(three.json().version);
  });

  it('a delete from a stale copy is refused and deletes nothing; with the current version it deletes', async () => {
    const vchNo = await create();
    const stale = (await read(vchNo)).version;
    const edited = await call('PUT', `/sales/${vchNo}`, { ...sale(6200), expectedVersion: stale });
    expect(edited.statusCode, edited.body).toBe(200);
    const refused = await call('DELETE', `/sales/${vchNo}?coBook=${BOOK}&expectedVersion=${stale}`);
    expect(refused.statusCode, refused.body).toBe(409);
    expect(await lineRate(vchNo)).toEqual([6200]);
    const { version } = await read(vchNo);
    const deleted = await call(
      'DELETE',
      `/sales/${vchNo}?coBook=${BOOK}&expectedVersion=${version}`,
    );
    expect(deleted.statusCode, deleted.body).toBe(200);
    expect(await lineRate(vchNo)).toEqual([]);
  });

  it('an unchanged save still issues a new version, so the old copy is stale afterwards', async () => {
    const vchNo = await create();
    const { version } = await read(vchNo);
    const same = await call('PUT', `/sales/${vchNo}`, { ...sale(6000), expectedVersion: version });
    expect(same.statusCode, same.body).toBe(200);
    expect(same.json().version).not.toBe(version);
    const again = await call('PUT', `/sales/${vchNo}`, { ...sale(6000), expectedVersion: version });
    expect(again.statusCode, again.body).toBe(409);
  });
});
