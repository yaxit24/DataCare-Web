import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * D6 and the §5c 500 probes of PARITY-EVALUATION-2026-09-28, over HTTP on a web-provisioned company.
 * This is the setup of the evaluation's browser journey, where 10 g at touch 91.6 and 6,000/g billed
 * 54,960 instead of the desktop's 60,000.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'sale-basis-route-db';
const PASSWORD = 'Sale-Amount-Basis!2026';
const SECRET = 'sale-amount-basis-route-test-signing-secret-32-chars';
const LOGIN = 'counter';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)('D6 sale amount basis and 400-not-500 over HTTP', () => {
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
  const post = (url: string, payload: unknown) =>
    app.inject({ method: 'POST', url, headers: { cookie }, payload: payload as any });
  const line = (overrides: Record<string, unknown> = {}) => ({
    itCode: 'GOLD',
    pcs: 1,
    grossWt: 10,
    netWt: 10,
    touch: 91.6,
    rate: 6000,
    ...overrides,
  });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    // The demo seed's item master (server.ts), so the company matches the evaluated one.
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC") VALUES ($1,'01','01','GOLD JEWELLERY','SALES','PURCHASE')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES ($1,'01','GOLD','GOLD ORNAMENT','G','01')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR") VALUES ($1,'01','01','CUST01','DEMO CUSTOMER','L','30')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of ['Sales Invoice', 'Sales Return']) {
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

  it('D6-1: the evaluated sale bills 60,000 on net and stores RtWith N', async () => {
    const saved = await post('/sales', {
      coBook: 'SL',
      acCode: 'CUST01',
      vchDate: DAY,
      // No tax code, as the sales form sends by default: the web-provisioned TAX_MAST rows sit at
      // SR_NO 1, so a code lookup (which pins the SR_NO 0 parent) does not find them. That provisioning
      // gap is recorded in the contract.
      taxRatePct: 3,
      interState: false,
      lines: [line()],
    });
    expect(saved.statusCode, saved.body).toBe(201);
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "ITM_AMT"::float amt, "RATE_WITH" rw, "ITM_FINE"::float fine FROM "SL_DETL" WHERE tenant_id=$1`,
      tenantId,
    )) as Array<{ amt: number; rw: string; fine: number }>;
    // The fine is still computed and stored (9.160); it is no longer what the rate multiplies.
    expect(rows).toEqual([{ amt: 60000, rw: 'N', fine: 9.16 }]);
  });

  it('an unknown labour type is a 400 validation error, not a 500 TypeError', async () => {
    const refused = await post('/sales', {
      coBook: 'SL',
      acCode: 'CUST01',
      vchDate: DAY,
      // No tax code, as the sales form sends by default: the web-provisioned TAX_MAST rows sit at
      // SR_NO 1, so a code lookup (which pins the SR_NO 0 parent) does not find them. That provisioning
      // gap is recorded in the contract.
      taxRatePct: 3,
      interState: false,
      lines: [line({ labourType: 'per_ounce', labourRate: 10 })],
    });
    expect(refused.statusCode, refused.body).toBe(400);
    expect(refused.json()).toMatchObject({
      error: 'SaleValidationError',
      message: expect.stringContaining('labourType must be one of'),
    });
  });

  it('a sale return without a tax rate is a 400 validation error, not a 500 DecimalError', async () => {
    // The evaluation's exact probe (containment.mjs:18).
    const refused = await post('/sales-returns', {
      coBook: 'SRT',
      acCode: 'CUST01',
      lines: [{ itCode: 'GOLD', netWt: 1, rate: 6000 }],
    });
    expect(refused.statusCode, refused.body).toBe(400);
    expect(refused.json()).toMatchObject({
      error: 'SaleValidationError',
      message: expect.stringContaining('taxRatePct must be a non-negative number'),
    });
    const [written] = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT'`,
      tenantId,
    )) as Array<{ n: number }>;
    expect(written!.n).toBe(0);
  });
});
