import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';

/**
 * D3 and D4 (PARITY-EVALUATION-2026-09-28), over HTTP with a non-administrator holding the report rights.
 *
 * - D3: five report screens were registered only for export, so their screens answered 404.
 * - D4: the balance-sheet and gstr1 slugs were missing from the report-form map. Their filter request
 *   and their exports failed with 403 `form: unresolved` before any rights check ran.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'report-screens-route-db';
const PASSWORD = 'Report-Screens-Route!2026';
const SECRET = 'report-screens-route-test-signing-secret-over-32-chars';
const LOGIN = 'reporter';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const RIGHTS = [
  'HuId Report',
  'ItStk Level',
  'Bill Wise Profit',
  'Physical Stock',
  'Movement',
  'Balance Sheet',
  'GSTR-1',
];
const D3_SCREENS = [
  'huid',
  'item-weight-levels',
  'bill-profit',
  'physical-stock-verify',
  'size-movement',
];

(enabled ? describe : describe.skip)('D3/D4 report screens and slug exports', () => {
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
  const get = (url: string) => app.inject({ method: 'GET', url, headers: { cookie } });

  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('report route fixtures require isolated database 55433');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','N','N','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of RIGHTS) {
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Report',$3,'Y','N','N','Y')`,
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

  it.each(D3_SCREENS)('D3: /reports/%s has a screen, built by the export builder', async (slug) => {
    const screen = await get(`/reports/${slug}?coYear=${YEAR}`);
    expect(screen.statusCode, screen.body).toBe(200);
    const body = screen.json();
    expect(Array.isArray(body.rows), `${slug} screen returns rows`).toBe(true);
    expect(body.totals, `${slug} screen returns totals`).toBeTypeOf('object');
    const csv = await get(`/reports/${slug}/export.csv?coYear=${YEAR}`);
    expect(csv.statusCode, csv.body).toBe(200);
  });

  it('D3: a screen without the right is still refused (the new routes carry their policies)', async () => {
    await exec(
      `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='HuId Report'`,
      tenantId,
      LOGIN,
    );
    const refused = await get(`/reports/huid?coYear=${YEAR}`);
    expect(refused.statusCode).toBe(403);
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Report','HuId Report','Y','N','N','Y')`,
      tenantId,
      LOGIN,
    );
  });

  it.each(['balance-sheet', 'gstr1'])(
    'D4: %s filters resolve to their form (benign 404, not 403) and its exports work',
    async (slug) => {
      const filters = await get(`/reports/${slug}/filters?coYear=${YEAR}`);
      expect(filters.statusCode, filters.body).toBe(404);
      expect(filters.json()).toEqual({ error: 'unknown-report', report: slug });
      for (const format of ['csv', 'xlsx']) {
        const exported = await get(`/reports/${slug}/export.${format}?coYear=${YEAR}`);
        expect(exported.statusCode, `${slug} ${format}: ${exported.body.slice(0, 200)}`).toBe(200);
      }
    },
  );

  it('D4: /reports/gstr1 answers the same GSTR-1 datasets as /gst/gstr1', async () => {
    const legacy = await get(`/gst/gstr1?coYear=${YEAR}`);
    const slugged = await get(`/reports/gstr1?coYear=${YEAR}`);
    expect(legacy.statusCode, legacy.body).toBe(200);
    expect(slugged.statusCode, slugged.body).toBe(200);
    expect(slugged.json()).toEqual(legacy.json());
    expect(Object.keys(slugged.json()).sort()).toEqual(['b2b', 'b2cl', 'b2cs', 'hsn']);
  });
});
