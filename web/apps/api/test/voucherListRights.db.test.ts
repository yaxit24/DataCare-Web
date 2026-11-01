import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { FORM_CATALOG } from '../src/modules/rbac/formCatalog.js';
import { formsForMainBook } from '../src/modules/vouchers/bookForms.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N207 / G220: the recent-voucher list and the voucher number box read only books the user may open.
 *
 * The desktop lists the open menu's own book only (TR_CONTRA.cs:3136-3146) and each menu opens the books of its
 * own family (MDI_FORM.cs:8100-8111 CurBookHelp('CONTRA'), :8360-8365 CurBookHelp('FINE JV')). Both share
 * CONTRA_DATA, so a user with Contra rights alone must not list the Fine JV book through the generic routes.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'voucher-list-rights-db';
const PASSWORD = 'Voucher-List-Rights!2026';
const SECRET = 'voucher-list-rights-test-signing-secret-over-thirty-two';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;

(enabled ? describe : describe.skip)('N207 voucher list rights follow the book family', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...p: unknown[]) => owner.$executeRawUnsafe(sql, ...p);
  const get = (user: string, url: string) =>
    app.inject({ method: 'GET', url, headers: { cookie: cookies[user]! } });
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenantId);
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    const hash = await hashPassword(PASSWORD);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01','vladmin',$2,'ADMIN','Y','Y','Y','N'),($1,'01','vlcontra',$2,'USER','Y','N','N','N')`,
      tenantId,
      hash,
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES ($1,'01','01','vlcontra','Cash / Bank','Contra','Y','N','N','N')`,
      tenantId,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const user of ['vladmin', 'vlcontra']) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const set = response.headers['set-cookie'];
      cookies[user] = (Array.isArray(set) ? set : [set ?? ''])
        .map((c) => c.split(';', 1)[0])
        .join('; ');
    }
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('maps every provisioned book family to at least one existing web form', async () => {
    const forms = new Set(FORM_CATALOG.map((e) => `${e.mainMenu}/${e.subMenu}`));
    const books: Array<{ main: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT coalesce("MAIN_BOOK",'') main FROM "BOOK_DATA" WHERE tenant_id=$1 ORDER BY 1`,
      tenantId,
    );
    const unmapped = books
      .map((b) => b.main)
      .filter((main) => main && !formsForMainBook(main).some((f) => forms.has(f)));
    expect(unmapped).toEqual([]);
  });

  it('lets a Contra user list and step through CON but refuses the FINE JV book; an admin may list both', async () => {
    for (const path of [
      '/vouchers/recent?table=CONTRA_DATA&book=',
      '/vouchers/neighbour?table=CONTRA_DATA&from=&direction=next&book=',
    ]) {
      const own = await get('vlcontra', `${path}CON`);
      expect(own.statusCode, own.body).toBe(200);
      const other = await get('vlcontra', `${path}FJV`);
      expect(other.statusCode, other.body).toBe(403);
      expect(other.json()).toMatchObject({ error: 'forbidden', action: 'view', book: 'FJV' });
      const unknown = await get('vlcontra', `${path}ZZZ`);
      expect(unknown.statusCode, unknown.body).toBe(403);
      const admin = await get('vladmin', `${path}FJV`);
      expect(admin.statusCode, admin.body).toBe(200);
    }
  });
});
