import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Company milestone 1 containment. The desktop saves company identity and then opens Year Create
 * (MS_COMPANY.cs:6042-6224); Year Create copies the 17-family master set
 * (MS_YEAR.cs:1504-1595). Generic CO_MAST-only writes cannot preserve that atomic workflow.
 * The desktop delete is an unsafe unscoped cascade (MS_COMPANY.cs:6254-6418), so it is not ported.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'company-master-containment';
const PASSWORD = 'Company-Containment!2026';
const SECRET = 'company-containment-test-secret-over-thirty-two';
const ADMIN = 'companyadmin';
const MESSAGE =
  'Company uses a dedicated workflow for identity and provisioning; generic create, update, delete, and CSV import are unavailable.';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;

type Cookie = string;

(enabled ? describe : describe.skip)('Company generic-write containment through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie: Cookie;

  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const rows = (table: string) => {
    const order = table === 'CO_MAST' ? '"CO_CODE"' : 'row_id';
    return owner.$queryRawUnsafe(
      `SELECT to_jsonb(t) AS row FROM "${table}" t WHERE tenant_id=$1 ORDER BY ${order}`,
      tenantId,
    );
  };
  const footprint = async () => ({
    company: await rows('CO_MAST'),
    locations: await rows('LOCT_MAST'),
    years: await rows('YEAR_MAST'),
    settings: await rows('CO_SET'),
  });
  const request = (method: string, url: string, payload?: unknown) =>
    app.inject({
      method: method as never,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as never }),
    });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01', { coName: 'CONTAINMENT COMPANY' });
    const passwordHash = await hashPassword(PASSWORD);
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
      tenantId,
      ADMIN,
      passwordHash,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: ADMIN, password: PASSWORD },
    });
    expect(login.statusCode, login.body).toBe(200);
    const setCookie = login.headers['set-cookie'];
    cookie = (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
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
    ['POST', '/masters/companies', { CO_CODE: '02', CO_NAME: 'UNSAFE CREATE' }],
    ['PUT', '/masters/companies', { CO_CODE: '01', CO_NAME: 'UNSAFE UPDATE' }],
    ['DELETE', '/masters/companies', { CO_CODE: '01' }],
  ] as const)(
    '%s %s returns the dedicated-writer contract and changes no company rows',
    async (method, url, payload) => {
      const before = await footprint();
      const response = await request(method, url, payload);
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json()).toEqual({ error: 'dedicated-writer', message: MESSAGE });
      expect(await footprint()).toEqual(before);
    },
  );

  it('CSV import reaches the blocked writer and changes no company or dependent rows', async () => {
    const before = await footprint();
    const response = await request('POST', '/masters/companies/import', {
      rows: [{ CO_CODE: '02', CO_NAME: 'UNSAFE IMPORT' }],
    });
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toEqual({
      created: 0,
      failed: 1,
      errors: [{ row: 1, error: 'error' }],
    });
    expect(await footprint()).toEqual(before);
  });
});
