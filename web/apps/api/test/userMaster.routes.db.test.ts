import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { FORM_CATALOG } from '../src/modules/rbac/formCatalog.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-06 User Create (desktop MS_USER) through the real routes, as the runtime role under forced RLS.
 *
 * Expected values come from the desktop: Save writes LOGIN_MAST (CO_CODE, LOGIN_NAME, LOGIN_PWD, the first letter of the
 * user type, MAIN_USER = operator, MS_USER.cs:1981-1997) and, for a new user, USER_SET for every menu with all four
 * rights 'Y' for location '00' and the operator's location (:2012-2040); texts :1942,1965,2080-2088,2141,2211,2235,2241.
 * Web decisions (document 12 §4): D34 password rule and per-account back-off, D35 delete = deactivate with every
 * session revoked in the same transaction, the last administrator protected.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'wp06-users-db';
const OTHER = 'wp06-users-db-b';
const OWNER_PASSWORD = 'owner-kesar-bagh';
const SECRET = 'wp06-user-master-route-test-signing-secret-32+';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;

type Row = Record<string, any>;

(enabled ? describe : describe.skip)('User Create (MS_USER) routes', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};

  const rows = (sql: string, ...params: unknown[]) =>
    // A tuple type: `[0]` of a query that must return a row reads as a Row (an absent one is asserted by the test).
    owner.$queryRawUnsafe(sql, ...params) as Promise<[Row, ...Row[]]>;
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const t of tables)
      await owner.$executeRawUnsafe(
        `DELETE FROM "${t.table_name}" WHERE tenant_id = ANY($1::text[])`,
        [TENANT, OTHER],
      );
  };
  /** Row count and digest of every tenant table but the audit log: the write-set footprint. */
  const fingerprint = async (tenant = TENANT) => {
    const tables: Array<{ name: string }> = await owner.$queryRawUnsafe(
      `SELECT table_name name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id' AND table_name<>'audit_log'
        GROUP BY table_name ORDER BY table_name`,
    );
    const out: Record<string, string> = {};
    for (const { name } of tables) {
      const [r] = await rows(
        `SELECT count(*)::int n, coalesce(md5(string_agg(t::text, E'\\n' ORDER BY t::text)), '') h
           FROM "${name}" t WHERE t.tenant_id=$1`,
        tenant,
      );
      out[name] = `${r.n}:${r.h}`;
    }
    return out;
  };
  const changed = (a: Record<string, string>, b: Record<string, string>) =>
    Object.keys(b).filter((k) => a[k] !== b[k]);

  const addLogin = async (tenant: string, name: string, catg: string, password: string) =>
    owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,$4,'Y','Y','Y','N')`,
      tenant,
      name,
      await hashPassword(password),
      catg,
    );
  const login = (name: string, password: string, tenant = TENANT, on = app) =>
    on.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenant },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password },
    });
  const cookieOf = (response: { headers: Record<string, any> }) => {
    const value = response.headers['set-cookie'];
    return (Array.isArray(value) ? value : [value ?? ''])
      .map((part: string) => part.split(';', 1)[0])
      .join('; ');
  };
  const signIn = async (name: string, password: string) => {
    const response = await login(name, password);
    expect(response.statusCode, response.body).toBe(200);
    cookies[name] = cookieOf(response);
  };
  const as = (name: string) => ({ cookie: cookies[name] });
  const create = (payload: Record<string, unknown>) =>
    app.inject({ method: 'POST', url: '/admin/users', headers: as('owner'), payload });
  const update = (name: string, payload: Record<string, unknown>) =>
    app.inject({
      method: 'POST',
      url: `/admin/users/${name}/update`,
      headers: as('owner'),
      payload,
    });
  const loginRow = async (name: string, tenant = TENANT) =>
    (
      await rows(
        `SELECT "row_id"::text "rowId","CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","MAIN_USER","USER_UPDATE",
                "USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED","LOGIN_ACTIVE","DEACTIVATED_BY",
                "DEACTIVATED_AT" IS NOT NULL "deactivated","FAILED_LOGIN_COUNT","LOGIN_BLOCKED_UNTIL",
                "PASSWORD_CHANGED_AT"::text "changedAt"
           FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "LOGIN_NAME"=$2`,
        tenant,
        name,
      )
    )[0];

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, TENANT, '01');
    await seedCompany(runtime, OTHER, '01');
    await addLogin(TENANT, 'owner', 'ADMIN', OWNER_PASSWORD);
    // The second tenant has a login of the same name: nothing done in the first may touch it.
    await addLogin(OTHER, 'RAMESH', 'U', 'other-tenant-ramesh');
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    await signIn('owner', OWNER_PASSWORD);
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('T07 Save in add mode writes the desktop LOGIN_MAST row and USER_SET for 00 and the location, all Y', async () => {
    const before = await fingerprint();
    const otherBefore = await fingerprint(OTHER);
    const response = await create({
      loginName: 'RAMESH',
      password: 'tulsibag',
      confirmPassword: 'tulsibag',
      userType: 'User',
    });
    expect(response.statusCode, response.body).toBe(201);
    expect(response.json()).toMatchObject({ message: 'User Are Created.', loginName: 'RAMESH' });

    const row = await loginRow('RAMESH');
    expect(row).toMatchObject({
      CO_CODE: '01',
      LOGIN_NAME: 'RAMESH',
      LOGIN_CATG: 'U',
      MAIN_USER: 'owner',
      USER_UPDATE: 'Y',
      USER_DELETE: 'Y',
      USER_PRINT: 'Y',
      PASSWORD_RESET_REQUIRED: 'N',
      LOGIN_ACTIVE: 'Y',
      DEACTIVATED_BY: null,
      deactivated: false,
      FAILED_LOGIN_COUNT: 0,
      LOGIN_BLOCKED_UNTIL: null,
    });
    // The desktop stores the password in plain text (:1981); the web stores only an Argon2id hash.
    expect(row.LOGIN_PWD).toMatch(/^\$argon2id\$/);
    expect(row.LOGIN_PWD).not.toContain('tulsibag');

    const rights = await rows(
      `SELECT "LC_CODE" lc, count(*)::int n,
              bool_and("FRM_VIEW"='Y' AND "FRM_EDIT"='Y' AND "FRM_DELETE"='Y' AND "FRM_PRINT"='Y') "allY",
              bool_and("CO_CODE"='01') co
         FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='RAMESH' GROUP BY "LC_CODE" ORDER BY "LC_CODE"`,
      TENANT,
    );
    expect(rights).toEqual([
      { lc: '00', n: FORM_CATALOG.length, allY: true, co: true },
      { lc: '01', n: FORM_CATALOG.length, allY: true, co: true },
    ]);
    const after = await fingerprint();
    expect(changed(before, after).sort()).toEqual(['LOGIN_MAST', 'USER_SET']);
    expect(await fingerprint(OTHER)).toEqual(otherBefore);
    // Downstream: the new user signs in with the password the operator typed.
    await signIn('RAMESH', 'tulsibag');
  });

  it('T06 refusals answer with the desktop text and write nothing', async () => {
    const before = await fingerprint();
    const cases: Array<[Record<string, unknown>, number, Record<string, unknown>]> = [
      [
        { loginName: '  ', password: 'tulsibag', confirmPassword: 'tulsibag', userType: 'User' },
        400,
        { message: 'Please Enter User Name.', field: 'loginName' },
      ],
      [
        {
          loginName: 'SURESH',
          password: 'tulsibag',
          confirmPassword: 'tulsibagh',
          userType: 'User',
        },
        400,
        { message: 'Password Not Match', field: 'confirmPassword' },
      ],
      [
        // The desktop's DataView filter does not distinguish case.
        {
          loginName: 'ramesh',
          password: 'kesarbagh',
          confirmPassword: 'kesarbagh',
          userType: 'User',
        },
        409,
        { message: 'This User Name already Exist.Please Change User Name...', field: 'loginName' },
      ],
    ];
    for (const [payload, status, body] of cases) {
      const response = await create(payload);
      expect(response.statusCode, response.body).toBe(status);
      expect(response.json()).toMatchObject(body);
    }
    expect(await fingerprint()).toEqual(before);
  });

  it('T03 D34: one refusal per rule, 8 characters with no composition rule accepted', async () => {
    const before = await fingerprint();
    const refused: Array<[string, string]> = [
      ['tulsiba', 'min-8'],
      ['k'.repeat(129), 'max-128'],
      ['Password123', 'common-password'],
      ['suresh@2026', 'login-name'],
      ['01010101', 'company-code'],
    ];
    for (const [password, reason] of refused) {
      const response = await create({
        loginName: 'SURESH',
        password,
        confirmPassword: password,
        userType: 'User',
      });
      expect(response.statusCode, `${password}: ${response.body}`).toBe(400);
      expect(response.json()).toEqual({ error: 'weak-password', reasons: [reason] });
    }
    expect(await fingerprint()).toEqual(before);
    const accepted = await create({
      loginName: 'SURESH',
      password: 'kesarbagh',
      confirmPassword: 'kesarbagh',
      userType: 'Admin',
    });
    expect(accepted.statusCode, accepted.body).toBe(201);
    expect((await loginRow('SURESH')).LOGIN_CATG).toBe('A');
  });

  it('T09 Save in edit mode checks the old password, then changes it and revokes the other sessions', async () => {
    const before = await fingerprint();
    const blank = await update('RAMESH', {
      oldPassword: '',
      newPassword: 'navratna',
      confirmPassword: 'navratna',
      userType: 'User',
    });
    expect(blank.statusCode).toBe(400);
    expect(blank.json()).toMatchObject({
      message: 'Please Insert Old Password',
      field: 'oldPassword',
    });
    const wrong = await update('RAMESH', {
      oldPassword: 'tulsibah',
      newPassword: 'navratna',
      confirmPassword: 'navratna',
      userType: 'User',
    });
    expect(wrong.statusCode).toBe(400);
    expect(wrong.json()).toMatchObject({
      message: "Old Password Doesn't Match",
      field: 'oldPassword',
    });
    const mismatch = await update('RAMESH', {
      oldPassword: 'tulsibag',
      newPassword: 'navratna',
      confirmPassword: 'navratnam',
      userType: 'User',
    });
    expect(mismatch.json()).toMatchObject({ message: 'Password Not Match' });
    expect(await fingerprint()).toEqual(before);

    const hashBefore = (await loginRow('RAMESH')).LOGIN_PWD;
    const ok = await update('RAMESH', {
      oldPassword: 'tulsibag',
      newPassword: 'navratna',
      confirmPassword: 'navratna',
      userType: 'User',
    });
    expect(ok.statusCode, ok.body).toBe(200);
    expect(ok.json()).toMatchObject({ message: 'User Are Created.' });
    expect((await loginRow('RAMESH')).LOGIN_PWD).not.toBe(hashBefore);
    // RAMESH's own session from T07 was revoked: its next request is refused.
    const me = await app.inject({ method: 'GET', url: '/me', headers: as('RAMESH') });
    expect(me.statusCode).toBe(401);
    expect((await login('RAMESH', 'tulsibag')).statusCode).toBe(401);
    await signIn('RAMESH', 'navratna');
  });

  it('T08 an unchanged edit-mode Save leaves the footprint exactly as it was', async () => {
    const before = await fingerprint();
    const response = await update('RAMESH', { oldPassword: 'navratna', userType: 'User' });
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toMatchObject({ message: 'User Are Created.' });
    expect(await fingerprint()).toEqual(before);
  });

  it('T10 Delete deactivates, keeps the rows, revokes every session; the old session is refused next request', async () => {
    const live = await app.inject({ method: 'GET', url: '/me', headers: as('RAMESH') });
    expect(live.statusCode).toBe(200);
    const userSetBefore = await rows(
      `SELECT count(*)::int n FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='RAMESH'`,
      TENANT,
    );
    const otherBefore = await fingerprint(OTHER);

    const response = await app.inject({
      method: 'DELETE',
      url: '/admin/users/RAMESH',
      headers: as('owner'),
    });
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toMatchObject({ message: 'Delete Success.', loginName: 'RAMESH' });

    const row = await loginRow('RAMESH');
    expect(row).toMatchObject({ LOGIN_ACTIVE: 'N', DEACTIVATED_BY: 'owner', deactivated: true });
    expect(
      await rows(
        `SELECT count(*)::int n FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='RAMESH'`,
        TENANT,
      ),
    ).toEqual(userSetBefore);
    const sessions = await rows(
      `SELECT count(*)::int n, count(*) FILTER (WHERE revoked_at IS NULL)::int open,
              count(*) FILTER (WHERE revoke_reason='user-deleted')::int deleted
         FROM auth_session WHERE tenant_id=$1 AND login_name='RAMESH'`,
      TENANT,
    );
    expect(sessions[0].open).toBe(0);
    expect(sessions[0].deleted).toBeGreaterThanOrEqual(1);

    // The deleted user's existing access cookie is refused on the very next request, and so is its refresh.
    expect(
      (await app.inject({ method: 'GET', url: '/me', headers: as('RAMESH') })).statusCode,
    ).toBe(401);
    expect(
      (await app.inject({ method: 'POST', url: '/auth/refresh', headers: as('RAMESH') }))
        .statusCode,
    ).toBe(401);
    expect((await login('RAMESH', 'navratna')).statusCode).toBe(401);
    // Gone from the list; a second Delete has nothing to select.
    const list = await app.inject({ method: 'GET', url: '/admin/users', headers: as('owner') });
    expect(list.json().map((u: Row) => u.loginName)).not.toContain('RAMESH');
    const again = await app.inject({
      method: 'DELETE',
      url: '/admin/users/RAMESH',
      headers: as('owner'),
    });
    expect(again.statusCode).toBe(404);
    expect(again.json()).toMatchObject({ message: 'Please Select User For Delete.' });
    // The other tenant's RAMESH is untouched.
    expect(await fingerprint(OTHER)).toEqual(otherBefore);
  });

  it('D35 defence in depth: an inactive login is refused even if a session row were left open', async () => {
    await signIn('SURESH', 'kesarbagh');
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "LOGIN_ACTIVE"='N' WHERE tenant_id=$1 AND "LOGIN_NAME"='SURESH'`,
      TENANT,
    );
    const me = await app.inject({ method: 'GET', url: '/me', headers: as('SURESH') });
    expect(me.statusCode).toBe(401);
    expect(me.json()).toEqual({ error: 'session-invalid' });
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "LOGIN_ACTIVE"='Y' WHERE tenant_id=$1 AND "LOGIN_NAME"='SURESH'`,
      TENANT,
    );
  });

  it('D35: a deleted administrator in mid-session is refused on the next request and writes nothing', async () => {
    const created = await create({
      loginName: 'KAMAL',
      password: 'panna-bazaar',
      confirmPassword: 'panna-bazaar',
      userType: 'Admin',
    });
    expect(created.statusCode, created.body).toBe(201);
    await signIn('KAMAL', 'panna-bazaar');
    // The session works on a rights-checked route before the delete.
    const before = await app.inject({ method: 'GET', url: '/admin/users', headers: as('KAMAL') });
    expect(before.statusCode, before.body).toBe(200);

    const deleted = await app.inject({
      method: 'DELETE',
      url: '/admin/users/KAMAL',
      headers: as('owner'),
    });
    expect(deleted.statusCode, deleted.body).toBe(200);
    expect(deleted.json()).toMatchObject({ message: 'Delete Success.' });

    // Same cookie, very next request: refused, on a read and on a write, and the write leaves no trace.
    const footprint = await fingerprint();
    const read = await app.inject({ method: 'GET', url: '/admin/users', headers: as('KAMAL') });
    expect(read.statusCode).toBe(401);
    const write = await app.inject({
      method: 'POST',
      url: '/admin/users',
      headers: as('KAMAL'),
      payload: {
        loginName: 'GHOST',
        password: 'heera-panna',
        confirmPassword: 'heera-panna',
        userType: 'Admin',
      },
    });
    expect(write.statusCode).toBe(401);
    expect(changed(footprint, await fingerprint())).toEqual([]);
    expect(await loginRow('GHOST')).toBeUndefined();
    expect(
      (await app.inject({ method: 'POST', url: '/auth/refresh', headers: as('KAMAL') })).statusCode,
    ).toBe(401);
  });

  it('N169: the last administrator cannot be deleted; with another admin it can', async () => {
    // SURESH is an admin (T03), so first delete SURESH while owner remains, then owner is the last one.
    const first = await app.inject({
      method: 'DELETE',
      url: '/admin/users/SURESH',
      headers: as('owner'),
    });
    expect(first.statusCode, first.body).toBe(200);
    const before = await fingerprint();
    const last = await app.inject({
      method: 'DELETE',
      url: '/admin/users/owner',
      headers: as('owner'),
    });
    expect(last.statusCode, last.body).toBe(400);
    expect(last.json()).toMatchObject({ error: 'LastAdministratorValidationError' });
    expect(await fingerprint()).toEqual(before);
  });

  it('a new user under a deleted name reactivates that login with the new password and fresh rights', async () => {
    const rowBefore = await loginRow('RAMESH');
    await owner.$executeRawUnsafe(
      `UPDATE "USER_SET" SET "FRM_EDIT"='N' WHERE tenant_id=$1 AND "USER_NAME"='RAMESH'`,
      TENANT,
    );
    const response = await create({
      loginName: 'ramesh',
      password: 'pukhraj-ring',
      confirmPassword: 'pukhraj-ring',
      userType: 'User',
    });
    expect(response.statusCode, response.body).toBe(201);
    const row = await loginRow('RAMESH');
    expect(row.rowId).toBe(rowBefore.rowId);
    expect(row).toMatchObject({ LOGIN_ACTIVE: 'Y', DEACTIVATED_BY: null, deactivated: false });
    const notY = await rows(
      `SELECT count(*)::int n FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='RAMESH' AND "FRM_EDIT"<>'Y'`,
      TENANT,
    );
    expect(notY[0].n).toBe(0);
    await signIn('RAMESH', 'pukhraj-ring');
  });

  it('T11 a non-admin is refused every User Create route and nothing is written', async () => {
    await addLogin(TENANT, 'clerk', 'USER', 'clerk-moti-bagh');
    await signIn('clerk', 'clerk-moti-bagh');
    const before = await fingerprint();
    const calls = [
      { method: 'GET' as const, url: '/admin/users' },
      {
        method: 'POST' as const,
        url: '/admin/users',
        payload: {
          loginName: 'X1',
          password: 'kesarbagh',
          confirmPassword: 'kesarbagh',
          userType: 'Admin',
        },
      },
      {
        method: 'POST' as const,
        url: '/admin/users/owner/update',
        payload: { oldPassword: 'x', userType: 'User' },
      },
      { method: 'DELETE' as const, url: '/admin/users/owner' },
    ];
    for (const call of calls) {
      const response = await app.inject({ ...call, headers: as('clerk') });
      expect(response.statusCode, `${call.method} ${call.url}`).toBe(403);
    }
    expect(await fingerprint()).toEqual(before);
  });

  it('T12 two creates of the same name at once make one login', async () => {
    const payload = {
      loginName: 'MANISH',
      password: 'heera-panna',
      confirmPassword: 'heera-panna',
      userType: 'User',
    };
    const results = await Promise.all([create(payload), create(payload)]);
    expect(results.map((r) => r.statusCode).sort()).toEqual([201, 409]);
    const count = await rows(
      `SELECT count(*)::int n FROM "LOGIN_MAST" WHERE tenant_id=$1 AND upper("LOGIN_NAME")='MANISH'`,
      TENANT,
    );
    expect(count[0].n).toBe(1);
    const userSet = await rows(
      `SELECT count(*)::int n FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='MANISH'`,
      TENANT,
    );
    expect(userSet[0].n).toBe(FORM_CATALOG.length * 2);
  });
});

(enabled ? describe : describe.skip)('D34 per-account login back-off', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const T = 'wp06-backoff-db';
  const T2 = 'wp06-backoff-db-b';
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const t of tables)
      await owner.$executeRawUnsafe(
        `DELETE FROM "${t.table_name}" WHERE tenant_id = ANY($1::text[])`,
        [T, T2],
      );
  };
  const login = (tenant: string, password: string) =>
    app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenant },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: 'KAMAL', password },
    });
  const state = async (tenant: string) =>
    (
      (await owner.$queryRawUnsafe(
        `SELECT "FAILED_LOGIN_COUNT" n, "LOGIN_BLOCKED_UNTIL" > clock_timestamp() blocked
           FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "LOGIN_NAME"='KAMAL'`,
        tenant,
      )) as [Row, ...Row[]]
    )[0];

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    for (const tenant of [T, T2]) {
      await seedCompany(runtime, tenant, '01');
      await owner.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01','KAMAL',$2,'U','N')`,
        tenant,
        await hashPassword('kamal-sona-chandi'),
      );
    }
    // A fresh app: the 10-per-minute IP throttle is per instance, so this block has its own budget.
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('five wrong passwords block the account, the right one included, in this tenant only; success resets', async () => {
    for (let i = 1; i <= 5; i += 1) {
      expect((await login(T, `wrong-guess-${i}`)).statusCode).toBe(401);
      expect((await state(T)).n).toBe(i);
    }
    expect((await state(T)).blocked).toBe(true);
    const refused = await login(T, 'kamal-sona-chandi');
    expect(refused.statusCode).toBe(401);
    expect(refused.json()).toEqual({ error: 'invalid-credentials' });
    // While blocked the password is not even tried: the counter does not move.
    expect((await state(T)).n).toBe(5);
    // The other tenant's KAMAL is not affected.
    expect((await login(T2, 'kamal-sona-chandi')).statusCode).toBe(200);
    expect((await state(T2)).n).toBe(0);
    // When the window has passed the right password signs in and the run is reset.
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "LOGIN_BLOCKED_UNTIL"=clock_timestamp() - interval '1 second'
        WHERE tenant_id=$1 AND "LOGIN_NAME"='KAMAL'`,
      T,
    );
    expect((await login(T, 'kamal-sona-chandi')).statusCode).toBe(200);
    expect(await state(T)).toEqual({ n: 0, blocked: null });
  });
});
