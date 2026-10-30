import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * G178 over HTTP: Users & Rights may not leave the company without an administrator.
 * Observed on the live demo: `POST /admin/users/admin/rights {catg:'USER'}` demoted the only admin, after which every
 * admin request answered 403. The change is refused while it would remove the last admin; with a second admin the
 * same change succeeds, and the second admin then becomes the last one.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'last-admin-db';
const PASSWORD = 'Last-Admin-Guard!2026';
const SECRET = 'last-admin-route-test-signing-secret-with-32-plus';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;

(enabled ? describe : describe.skip)('G178 last administrator guard over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const addLogin = async (name: string, catg: string) =>
    exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,$4,'Y','Y','Y','N')`,
      tenantId,
      name,
      await hashPassword(PASSWORD),
      catg,
    );
  const login = async (name: string) => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    cookies[name] = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };
  const setRights = (as: string, target: string, catg: string) =>
    app.inject({
      method: 'POST',
      url: `/admin/users/${target}/rights`,
      headers: { cookie: cookies[as] },
      payload: { catg, userUpdate: true, userDelete: true, userPrint: true },
    });
  const category = async (name: string) =>
    (
      (await owner.$queryRawUnsafe(
        `SELECT "LOGIN_CATG" c FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LOGIN_NAME"=$2`,
        tenantId,
        name,
      )) as Array<{ c: string }>
    )[0]?.c;

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await addLogin('owner', 'ADMIN');
    await addLogin('clerk', 'USER');
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    await login('owner');
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('refuses to demote the only administrator, including oneself, and changes nothing', async () => {
    const refused = await setRights('owner', 'owner', 'USER');
    expect(refused.statusCode, refused.body).toBe(400);
    expect(refused.json()).toMatchObject({
      error: 'LastAdministratorValidationError',
      message: expect.stringContaining('at least one administrator'),
    });
    expect(await category('owner')).toBe('ADMIN');
    // The owner can still use an admin route afterwards.
    expect(
      (await app.inject({ method: 'GET', url: '/admin/users', headers: { cookie: cookies.owner } }))
        .statusCode,
    ).toBe(200);
  });

  it('allows the change once another administrator exists; the remaining one is then protected', async () => {
    expect((await setRights('owner', 'clerk', 'ADMIN')).statusCode).toBe(200);
    expect(await category('clerk')).toBe('ADMIN');
    expect((await setRights('owner', 'owner', 'USER')).statusCode).toBe(200);
    expect(await category('owner')).toBe('USER');
    await login('clerk');
    const refused = await setRights('clerk', 'clerk', 'USER');
    expect(refused.statusCode, refused.body).toBe(400);
    expect(await category('clerk')).toBe('ADMIN');
  });

  it('changing an ordinary user, or keeping an admin an admin, is not affected', async () => {
    expect((await setRights('clerk', 'owner', 'USER')).statusCode).toBe(200);
    expect((await setRights('clerk', 'clerk', 'ADMIN')).statusCode).toBe(200);
  });
});
