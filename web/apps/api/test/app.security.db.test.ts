import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';

const RUN_DATABASE_TESTS = process.env.RUN_DB_SECURITY_TESTS === '1';
const databaseDescribe = RUN_DATABASE_TESTS ? describe : describe.skip;

const TENANT_ID = 'task4-http-security';
const COMPANY = '01';
const YEAR = '2024-2025';
const PASSWORD = 'Task4-Test-Password!1';
const SELF_CHANGED_PASSWORD = 'Task4-Self-Changed!2';
const ADMIN_RESET_PASSWORD = 'Task4-Admin-Reset!3';
const SECRET = 'task4-http-security-signing-secret-over-thirty-two-characters';

type CookieJar = Map<string, string>;

function setCookies(response: { headers: Record<string, unknown> }, jar: CookieJar): void {
  const header = response.headers['set-cookie'];
  const values = Array.isArray(header) ? header : header ? [String(header)] : [];
  for (const value of values) {
    const pair = String(value).split(';', 1)[0] ?? '';
    const separator = pair.indexOf('=');
    if (separator < 1) continue;
    const name = pair.slice(0, separator);
    const cookieValue = pair.slice(separator + 1);
    if (cookieValue) jar.set(name, cookieValue);
    else jar.delete(name);
  }
}

function cookieHeader(jar: CookieJar, names: string[] = [...jar.keys()]): string {
  return names
    .map((name) => [name, jar.get(name)] as const)
    .filter((entry): entry is readonly [string, string] => Boolean(entry[1]))
    .map(([name, value]) => `${name}=${value}`)
    .join('; ');
}

databaseDescribe('database-backed HTTP authorization and session boundary', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'audit_log',
      'auth_session',
      'USER_SET',
      'ITEM_MAST',
      'BOOK_DATA',
      'LOGIN_MAST',
      'YEAR_MAST',
      'LOCT_MAST',
      'CO_MAST',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE "tenant_id"=$1`, TENANT_ID);
    }
  };

  const login = async (
    loginName: string,
    password = PASSWORD,
    scope: { lcCode?: string; coYear?: string } = {},
  ): Promise<{ jar: CookieJar; body: Record<string, unknown> }> => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': TENANT_ID },
      payload: {
        coCode: COMPANY,
        loginName,
        password,
        lcCode: scope.lcCode,
        coYear: scope.coYear,
      },
    });
    expect(response.statusCode).toBe(200);
    const jar: CookieJar = new Map();
    setCookies(response as any, jar);
    expect(jar.has('access')).toBe(true);
    expect(jar.has('refresh')).toBe(true);
    return { jar, body: response.json() as Record<string, unknown> };
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_SECURITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
    await cleanup();

    const passwordHash = await hashPassword(PASSWORD);
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST" ("tenant_id","CO_CODE","CO_NAME","LC_CODE")
       VALUES ($1,$2,'Task 4 HTTP Company','01')`,
      TENANT_ID,
      COMPANY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST" ("tenant_id","CO_CODE","LC_CODE","LC_NAME")
       VALUES ($1,$2,'01','Main'),($1,$2,'02','Branch')`,
      TENANT_ID,
      COMPANY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST" ("tenant_id","CO_CODE","CO_YEAR") VALUES ($1,$2,$3)`,
      TENANT_ID,
      COMPANY,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"
         ("tenant_id","CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","CUR_USE")
       VALUES ($1,$2,'01','001','Sales','SALE','Y')`,
      TENANT_ID,
      COMPANY,
    );

    const users = [
      ['no-rights', 'USER', 'N'],
      ['view-user', 'USER', 'N'],
      ['reset-user', 'USER', 'Y'],
      ['rotate-user', 'USER', 'N'],
      ['logout-user', 'USER', 'N'],
      ['reset-target', 'USER', 'N'],
      ['admin', 'ADMIN', 'N'],
    ];
    for (const [loginName, category, resetRequired] of users) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST" (
           "tenant_id","CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG",
           "USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED"
         ) VALUES ($1,$2,$3,$4,$5,'Y','Y','Y',$6)`,
        TENANT_ID,
        COMPANY,
        loginName,
        passwordHash,
        category,
        resetRequired,
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "USER_SET" (
         "tenant_id","CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU",
         "FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT"
       ) VALUES ($1,$2,'01','view-user','Masters','Items','Y','N','N','N')`,
      TENANT_ID,
      COMPANY,
    );

    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
  }, 30_000);

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  }, 30_000);

  it('denies missing rights, honors View-only create, and isolates rights by current location', async () => {
    const noRights = await login('no-rights', PASSWORD, { lcCode: '01', coYear: YEAR });
    const denied = await app.inject({
      method: 'GET',
      url: '/masters/items/meta',
      headers: { cookie: cookieHeader(noRights.jar) },
    });
    expect(denied.statusCode).toBe(403);
    expect(denied.json()).toMatchObject({
      error: 'forbidden',
      form: 'Masters/Items',
      action: 'read',
    });

    const viewer = await login('view-user', PASSWORD, { lcCode: '01', coYear: YEAR });
    const readable = await app.inject({
      method: 'GET',
      url: '/masters/items/meta',
      headers: { cookie: cookieHeader(viewer.jar) },
    });
    expect(readable.statusCode).toBe(200);

    const validBook = await app.inject({
      method: 'GET',
      url: '/masters/items/meta?coBook=001',
      headers: { cookie: cookieHeader(viewer.jar) },
    });
    expect(validBook.statusCode).toBe(200);
    const invalidBook = await app.inject({
      method: 'GET',
      url: '/masters/items/meta?coBook=999',
      headers: { cookie: cookieHeader(viewer.jar) },
    });
    expect(invalidBook.statusCode).toBe(409);
    expect(invalidBook.json()).toEqual({ error: 'book-unavailable' });

    const created = await app.inject({
      method: 'POST',
      url: '/masters/items',
      headers: { cookie: cookieHeader(viewer.jar) },
      payload: {
        tenant_id: 'attacker-tenant',
        CO_CODE: COMPANY,
        IT_CODE: 'T4IT',
        IT_NAME: 'Task 4 Item',
      },
    });
    expect(created.statusCode).toBe(201);
    const persisted = (await owner.$queryRawUnsafe(
      `SELECT "tenant_id","CO_CODE","IT_CODE" FROM "ITEM_MAST"
        WHERE "tenant_id"=$1 AND "IT_CODE"='T4IT'`,
      TENANT_ID,
    )) as Array<Record<string, string>>;
    expect(persisted).toEqual([{ tenant_id: TENANT_ID, CO_CODE: COMPANY, IT_CODE: 'T4IT' }]);

    for (const method of ['PUT', 'DELETE'] as const) {
      const response = await app.inject({
        method,
        url: '/masters/items',
        headers: { cookie: cookieHeader(viewer.jar) },
        payload: { CO_CODE: COMPANY, IT_CODE: 'T4IT', IT_NAME: 'Changed' },
      });
      expect(response.statusCode).toBe(403);
      expect(response.json()).toMatchObject({ error: 'forbidden' });
    }

    const mismatch = await app.inject({
      method: 'POST',
      url: '/masters/items',
      headers: { cookie: cookieHeader(viewer.jar) },
      payload: { LC_CODE: '02', IT_CODE: 'BAD', IT_NAME: 'Wrong scope' },
    });
    expect(mismatch.statusCode).toBe(409);
    expect(mismatch.json()).toEqual({ error: 'scope-mismatch' });

    const oldAccess = viewer.jar.get('access')!;
    const selected = await app.inject({
      method: 'POST',
      url: '/context/select',
      headers: { cookie: cookieHeader(viewer.jar) },
      payload: {
        coCode: COMPANY,
        lcCode: '02',
        coYear: YEAR,
        expectedContextEpoch: (viewer.body.context as { contextEpoch: string }).contextEpoch,
        selectionId: '44444444-4444-4444-8444-444444444444',
      },
    });
    expect(selected.statusCode).toBe(200);
    setCookies(selected as any, viewer.jar);

    const staleAccess = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: `access=${oldAccess}` },
    });
    expect(staleAccess.statusCode).toBe(401);

    const branchDenied = await app.inject({
      method: 'GET',
      url: '/masters/items/meta',
      headers: { cookie: cookieHeader(viewer.jar) },
    });
    expect(branchDenied.statusCode).toBe(403);
    expect(branchDenied.json()).toMatchObject({ form: 'Masters/Items', action: 'read' });
  }, 30_000);

  it('restricts reset-required sessions until a successful self-service password change', async () => {
    const resetUser = await login('reset-user', PASSWORD, { lcCode: '01', coYear: YEAR });
    expect(resetUser.body.forcedReset).toBe(true);

    const meBefore = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: cookieHeader(resetUser.jar) },
    });
    expect(meBefore.statusCode).toBe(200);
    expect(meBefore.json()).toMatchObject({ passwordResetRequired: true });

    const blocked = await app.inject({
      method: 'GET',
      url: '/masters/items/meta',
      headers: { cookie: cookieHeader(resetUser.jar) },
    });
    expect(blocked.statusCode).toBe(403);
    expect(blocked.json()).toEqual({ error: 'password-reset-required' });

    const changed = await app.inject({
      method: 'POST',
      url: '/auth/password/change',
      headers: { cookie: cookieHeader(resetUser.jar) },
      payload: {
        currentPassword: PASSWORD,
        newPassword: SELF_CHANGED_PASSWORD,
        confirmPassword: SELF_CHANGED_PASSWORD,
      },
    });
    expect(changed.statusCode).toBe(200);
    expect(changed.json()).toEqual({ changed: true });

    const meAfter = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: cookieHeader(resetUser.jar) },
    });
    expect(meAfter.statusCode).toBe(200);
    expect(meAfter.json()).toMatchObject({ passwordResetRequired: false });

    const rightsStillApply = await app.inject({
      method: 'GET',
      url: '/masters/items/meta',
      headers: { cookie: cookieHeader(resetUser.jar) },
    });
    expect(rightsStillApply.statusCode).toBe(403);
    expect(rightsStillApply.json()).toMatchObject({ error: 'forbidden' });
  }, 30_000);

  it('rotates refresh tokens and revokes the session when an old token is replayed', async () => {
    const loggedIn = await login('rotate-user', PASSWORD, { lcCode: '01', coYear: YEAR });
    const oldRefresh = loggedIn.jar.get('refresh')!;

    const refreshed = await app.inject({
      method: 'POST',
      url: '/auth/refresh',
      headers: { cookie: `refresh=${oldRefresh}` },
    });
    expect(refreshed.statusCode).toBe(200);
    setCookies(refreshed as any, loggedIn.jar);
    const rotatedAccess = loggedIn.jar.get('access')!;
    expect(loggedIn.jar.get('refresh')).not.toBe(oldRefresh);

    const replayed = await app.inject({
      method: 'POST',
      url: '/auth/refresh',
      headers: { cookie: `refresh=${oldRefresh}` },
    });
    expect(replayed.statusCode).toBe(401);

    const accessAfterReplay = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: `access=${rotatedAccess}` },
    });
    expect(accessAfterReplay.statusCode).toBe(401);
    const sessions = (await owner.$queryRawUnsafe(
      `SELECT "revoke_reason" FROM "auth_session"
        WHERE "tenant_id"=$1 AND "login_name"='rotate-user'`,
      TENANT_ID,
    )) as Array<{ revoke_reason: string | null }>;
    expect(sessions).toEqual([{ revoke_reason: 'refresh-reuse' }]);
  }, 30_000);

  it('invalidates an access token immediately when its refresh session logs out', async () => {
    const loggedIn = await login('logout-user', PASSWORD, { lcCode: '01', coYear: YEAR });
    const oldAccess = loggedIn.jar.get('access')!;
    const loggedOut = await app.inject({
      method: 'POST',
      url: '/auth/logout',
      headers: { cookie: cookieHeader(loggedIn.jar) },
    });
    expect(loggedOut.statusCode).toBe(200);

    const afterLogout = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: `access=${oldAccess}` },
    });
    expect(afterLogout.statusCode).toBe(401);
  }, 30_000);

  it('lets only the administrator reset a password and revokes the target sessions', async () => {
    const target = await login('reset-target', PASSWORD, { lcCode: '01', coYear: YEAR });
    const targetAccess = target.jar.get('access')!;

    const nonAdminReset = await app.inject({
      method: 'POST',
      url: '/admin/users/reset-target/password-reset',
      headers: { cookie: cookieHeader(target.jar) },
      payload: { newPassword: ADMIN_RESET_PASSWORD },
    });
    expect(nonAdminReset.statusCode).toBe(403);
    expect(nonAdminReset.json()).toMatchObject({ error: 'forbidden' });

    const administrator = await login('admin', PASSWORD, { lcCode: '01', coYear: YEAR });

    const missingTarget = await app.inject({
      method: 'POST',
      url: '/admin/users/missing-user/password-reset',
      headers: { cookie: cookieHeader(administrator.jar) },
      payload: { newPassword: ADMIN_RESET_PASSWORD },
    });
    expect(missingTarget.statusCode).toBe(404);
    expect(missingTarget.json()).toEqual({ error: 'user-not-found' });

    const reset = await app.inject({
      method: 'POST',
      url: '/admin/users/reset-target/password-reset',
      headers: { cookie: cookieHeader(administrator.jar) },
      payload: { newPassword: ADMIN_RESET_PASSWORD },
    });
    expect(reset.statusCode).toBe(200);
    expect(reset.json()).toEqual({ reset: true, forcedChange: true });

    const oldSession = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: `access=${targetAccess}` },
    });
    expect(oldSession.statusCode).toBe(401);

    const forcedLogin = await login('reset-target', ADMIN_RESET_PASSWORD, {
      lcCode: '01',
      coYear: YEAR,
    });
    expect(forcedLogin.body.forcedReset).toBe(true);
  }, 30_000);
});
