import { createHash, randomUUID } from 'node:crypto';
import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it, vi } from 'vitest';
import { loginSessionContext } from '../src/modules/auth/sessionContextLogin.js';
import { hashPassword, verifyPassword } from '../src/modules/auth/password.js';
import { resetUserPassword } from '../src/modules/auth/passwordAccount.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const databaseDescribe = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenant = 'context-login-db';
const foreignTenant = 'context-login-db-foreign';
const sid = '11111111-1111-4111-8111-111111111111';
const oldSid = '22222222-2222-4222-8222-222222222222';
const otherCompanySid = '33333333-3333-4333-8333-333333333333';
const password = 'Context-Login-Password!1';
const resetPassword = 'Context-Reset-Password!2';
const now = '2026-09-03T12:00:00.000Z';
const jti = 'fixed-test-only-context-login-refresh-jti';
const input = {
  tenantId: tenant,
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  loginName: 'operator',
  password,
};
type Dependencies = Parameters<typeof loginSessionContext>[2];
type SignInput = Parameters<Dependencies['issueTokens']>[0];
const dependencies = (patch: Partial<Dependencies> = {}): Dependencies => ({
  issueTokens: async () => ({
    accessToken: 'local-test-access',
    refreshToken: 'local-test-refresh',
  }),
  clock: () => new Date(now),
  newSessionId: () => sid,
  newRefreshJti: () => jti,
  ...patch,
});
function barrier() {
  let release!: () => void;
  const promise = new Promise<void>((resolve) => {
    release = resolve;
  });
  return { promise, release };
}
function settle<T>(promise: Promise<T>) {
  return promise.then(
    (value) => ({ value, error: undefined }),
    (error: unknown) => ({ value: undefined, error }),
  );
}

databaseDescribe('atomic login context on real PostgreSQL', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let resetClient: PrismaClient;
  let hashed: string;
  let resetHash: string;
  const loginApp = `context-login-${randomUUID()}`;
  const resetApp = `context-reset-${randomUUID()}`;
  const tables = [
    'auth_session',
    'audit_log',
    'CO_SET',
    'LOGIN_MAST',
    'YEAR_MAST',
    'LOCT_MAST',
    'CO_MAST',
  ];
  const cleanup = async () => {
    for (const table of tables)
      await owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE "tenant_id" IN ($1,$2)`,
        tenant,
        foreignTenant,
      );
  };
  const snapshot = async () => {
    const result: Record<string, unknown> = {};
    for (const table of tables)
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text AS raw,t.xmin::text AS revision,t.ctid::text AS locator
       FROM "${table}" t WHERE "tenant_id" IN ($1,$2) ORDER BY to_jsonb(t)::text`,
        tenant,
        foreignTenant,
      );
    return result;
  };
  const sessions = () =>
    owner.$queryRawUnsafe<Array<{ raw: Record<string, string | null> }>>(
      `SELECT jsonb_object_agg(e.key,e.value) AS raw FROM "auth_session" t,
      LATERAL jsonb_each_text(to_jsonb(t)) e WHERE t."tenant_id"=$1
     GROUP BY t."tenant_id",t."session_id" ORDER BY t."session_id"`,
      tenant,
    );
  const sessionRow = async (sessionId = sid) => {
    const rows = await owner.$queryRawUnsafe<Array<{ raw: Record<string, string | null> }>>(
      `SELECT (SELECT jsonb_object_agg(key,value) FROM jsonb_each_text(to_jsonb(t))) AS raw
       FROM "auth_session" t WHERE "tenant_id"=$1 AND "session_id"=$2`,
      tenant,
      sessionId,
    );
    return rows[0]?.raw;
  };
  const loginRows = () =>
    owner.$queryRawUnsafe<
      Array<{ password: string; reset: string | null; changed: string | null }>
    >(
      `SELECT "LOGIN_PWD" AS password,"PASSWORD_RESET_REQUIRED" AS reset,
     "PASSWORD_CHANGED_AT"::text AS changed FROM "LOGIN_MAST"
     WHERE "tenant_id"=$1 AND "CO_CODE"='01' AND "LOGIN_NAME"='operator' ORDER BY "row_id"`,
      tenant,
    );
  const waitForLock = async (applicationName: string) => {
    const deadline = Date.now() + 3000;
    while (Date.now() < deadline) {
      const rows = await owner.$queryRawUnsafe<Array<{ waiting: boolean }>>(
        `SELECT EXISTS(SELECT 1 FROM pg_stat_activity WHERE application_name=$1 AND wait_event_type='Lock') AS waiting`,
        applicationName,
      );
      if (rows[0]?.waiting) return;
      await new Promise((resolve) => setTimeout(resolve, 10));
    }
    throw new Error('expected real credential-row lock wait was not observed');
  };
  beforeAll(async () => {
    if (!process.env.MIGRATE_DATABASE_URL || !process.env.DATABASE_URL)
      throw new Error('isolated database wrapper required');
    const ownerUrl = new URL(process.env.MIGRATE_DATABASE_URL);
    const runtimeUrl = new URL(process.env.DATABASE_URL);
    assertIsolatedTestDatabase();
    if (ownerUrl.username !== 'datacare' || runtimeUrl.username !== 'app_user')
      throw new Error('isolated owner/runtime roles required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl.toString() } } });
    runtimeUrl.searchParams.set('application_name', loginApp);
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl.toString() } } });
    runtimeUrl.searchParams.set('application_name', resetApp);
    resetClient = new PrismaClient({ datasources: { db: { url: runtimeUrl.toString() } } });
    hashed = await hashPassword(password);
    resetHash = await hashPassword(resetPassword);
  }, 30000);
  beforeEach(async () => {
    await cleanup();
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"("tenant_id","CO_CODE","LC_CODE") VALUES ($1,'01','02'),($2,'01','02')`,
      tenant,
      foreignTenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"("tenant_id","CO_CODE","LC_CODE") VALUES ($1,'01','01'),($1,'01','02'),($2,'01','01')`,
      tenant,
      foreignTenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"("tenant_id","CO_CODE","CO_YEAR") VALUES ($1,'01','2024-2025'),($1,'01','2025-2026'),($2,'01','2024-2025')`,
      tenant,
      foreignTenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"("tenant_id","CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED","PASSWORD_CHANGED_AT")
      VALUES ($1,'01','operator',$3,'USER','Y','N','1','N','2026-09-01 10:11:12.123456+00'),($2,'01','operator',$3,'ADMIN','Y','Y','Y','Y','2026-09-01 10:11:12.654321+00')`,
      tenant,
      foreignTenant,
      hashed,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"("tenant_id","CO_CODE","LAST_DAY_LOCK","LOCK_DATE") VALUES ($1,'01','Y','2000-01-01'),($2,'01','Y','2001-01-01')`,
      tenant,
      foreignTenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "auth_session"("tenant_id","session_id","login_name","login_co_code","co_code","lc_code","co_year","refresh_jti_hash","created_at","last_used_at","expires_at")
      VALUES ($1,$3,'operator','01','01','01','2024-2025',repeat('a',64),'2026-09-01','2026-09-01','2031-09-01'),
       ($1,$4,'operator','02','02','01',NULL,repeat('b',64),'2026-09-01','2026-09-01','2031-09-01'),
       ($2,$3,'operator','01','01','01','2024-2025',repeat('c',64),'2026-09-01','2026-09-01','2031-09-01')`,
      tenant,
      foreignTenant,
      oldSid,
      otherCompanySid,
    );
  });
  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (resetClient) await resetClient.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('creates one context with exact168-hour expiry, fresh rights and immutable login identity, without last-day lock', async () => {
    const before = await snapshot();
    const old = await sessions();
    const signed: SignInput[] = [];
    const result = await loginSessionContext(
      runtime,
      input,
      dependencies({
        issueTokens: async (value) => {
          signed.push(value);
          expect(await sessionRow()).toBeUndefined(); // uncommitted insert is invisible to another client
          return { accessToken: 'local-access', refreshToken: 'local-refresh' };
        },
      }),
    );
    expect(result).toMatchObject({
      accessToken: 'local-access',
      refreshToken: 'local-refresh',
      session: {
        tenantId: tenant,
        sessionId: sid,
        loginName: 'operator',
        loginCoCode: '01',
        coCode: '01',
        lcCode: '01',
        coYear: '2024-2025',
        contextEpoch: '1',
        ledgerContext: {
          version: 'server-session-ledger-context-v1',
          status: 'unknown',
          mode: null,
          reason: 'vendor-authority-unresolved',
        },
        lastContextSelectionId: null,
        lastContextRequestSha256: null,
        lastContextFromEpoch: null,
      },
      principal: {
        loginName: 'operator',
        loginCoCode: '01',
        role: 'USER',
        isAdmin: false,
        rights: { userUpdate: true, userDelete: false, userPrint: true },
        passwordResetRequired: false,
      },
    });
    expect(signed).toHaveLength(1);
    expect(signed[0]?.principal).toEqual(result.principal);
    expect(signed[0]?.refreshJti).toBe(jti);
    expect(Object.keys(result.principal).sort()).toEqual([
      'isAdmin',
      'loginCoCode',
      'loginName',
      'passwordResetRequired',
      'rights',
      'role',
    ]);
    const saved = await sessionRow();
    expect(saved).toMatchObject({
      context_epoch: '1',
      co_year: '2024-2025',
      refresh_jti_hash: createHash('sha256').update(jti).digest('hex'),
      revoked_at: null,
      revoke_reason: null,
    });
    const timing = await owner.$queryRawUnsafe<Array<{ exact: boolean; ttl: boolean }>>(
      `SELECT "created_at"=$3::timestamptz AND "last_used_at"=$3::timestamptz AS exact,extract(epoch FROM("expires_at"-"created_at"))=604800 AS ttl FROM "auth_session" WHERE "tenant_id"=$1 AND "session_id"=$2`,
      tenant,
      sid,
      now,
    );
    expect(timing).toEqual([{ exact: true, ttl: true }]);
    const after = await snapshot();
    for (const table of tables.filter((table) => table !== 'auth_session'))
      expect(after[table]).toEqual(before[table]);
    expect((await sessions()).filter((row) => row.raw.session_id !== sid)).toEqual(old);
  });

  it('preserves a no-year login as own undefined and SQL NULL with unknown incomplete context', async () => {
    await owner.$executeRawUnsafe(`DELETE FROM "YEAR_MAST" WHERE "tenant_id"=$1`, tenant);
    const { coYear: ignored, ...withoutYear } = input;
    void ignored;
    const result = await loginSessionContext(runtime, withoutYear, dependencies());
    expect(result.session).toHaveProperty('coYear', undefined);
    expect(Object.hasOwn(result.session, 'coYear')).toBe(true);
    expect(result.session.ledgerContext).toEqual({
      version: 'server-session-ledger-context-v1',
      status: 'unknown',
      mode: null,
      reason: 'scope-incomplete',
    });
    expect((await sessionRow())?.co_year).toBeNull();
  });

  it('keeps modern forced-reset admission and returns fresh reset/right values', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "PASSWORD_RESET_REQUIRED"='Y',"USER_UPDATE"='N',"USER_PRINT"='N' WHERE "tenant_id"=$1`,
      tenant,
    );
    const result = await loginSessionContext(runtime, input, dependencies());
    expect(result.principal).toMatchObject({
      passwordResetRequired: true,
      rights: { userUpdate: false, userDelete: false, userPrint: false },
    });
  });

  it('upgrades the exact legacy credential inside the committed context and reports forced reset', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "LOGIN_PWD"=$2,"PASSWORD_CHANGED_AT"=NULL WHERE "tenant_id"=$1`,
      tenant,
      password,
    );
    const result = await loginSessionContext(runtime, input, dependencies());
    const rows = await loginRows();
    expect(rows).toHaveLength(1);
    expect(rows[0]?.password).toMatch(/^\$argon2/);
    expect(await verifyPassword(rows[0]!.password, password)).toBe(true);
    expect(rows[0]?.reset).toBe('Y');
    expect(rows[0]?.changed).not.toBeNull();
    expect(result.principal.passwordResetRequired).toBe(true);
    expect(await sessionRow()).toBeDefined();
  });

  it.each(['modern', 'legacy'] as const)(
    'local signer failure restores complete %s credential/session snapshots',
    async (kind) => {
      if (kind === 'legacy')
        await owner.$executeRawUnsafe(
          `UPDATE "LOGIN_MAST" SET "LOGIN_PWD"=$2,"PASSWORD_CHANGED_AT"=NULL WHERE "tenant_id"=$1`,
          tenant,
          password,
        );
      const before = await snapshot();
      const failure = new Error('login-local-sign-failure');
      await expect(
        loginSessionContext(
          runtime,
          input,
          dependencies({
            issueTokens: async () => {
              throw failure;
            },
          }),
        ),
      ).rejects.toBe(failure);
      expect(await snapshot()).toEqual(before);
    },
  );

  it.each(['wrong-password', 'missing-credential', 'duplicate-credential'] as const)(
    'refuses %s before signing/session insertion with no writes',
    async (kind) => {
      if (kind === 'missing-credential')
        await owner.$executeRawUnsafe(`DELETE FROM "LOGIN_MAST" WHERE "tenant_id"=$1`, tenant);
      if (kind === 'duplicate-credential')
        await owner.$executeRawUnsafe(
          `INSERT INTO "LOGIN_MAST"("tenant_id","CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,'01','operator',$2,'ADMIN')`,
          tenant,
          hashed,
        );
      const before = await snapshot();
      const signer = vi.fn(async () => ({ accessToken: 'forbidden', refreshToken: 'forbidden' }));
      await expect(
        loginSessionContext(
          runtime,
          { ...input, password: kind === 'wrong-password' ? 'incorrect' : password },
          dependencies({ issueTokens: signer }),
        ),
      ).rejects.toMatchObject({ name: 'AuthError', reason: 'invalid-credentials' });
      expect(signer).not.toHaveBeenCalled();
      expect(await snapshot()).toEqual(before);
    },
  );

  it('rolls legacy upgrade back if the explicitly requested configured year is missing', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "LOGIN_PWD"=$2,"PASSWORD_CHANGED_AT"=NULL WHERE "tenant_id"=$1`,
      tenant,
      password,
    );
    const before = await snapshot();
    await expect(
      loginSessionContext(runtime, { ...input, coYear: '2099-2100' }, dependencies()),
    ).rejects.toMatchObject({ code: 'year-unavailable' });
    expect(await snapshot()).toEqual(before);
  });

  it('rolls the insertion back if a local signer crosses exact absolute expiry', async () => {
    const before = await snapshot();
    let calls = 0;
    const signer = vi.fn(async () => ({
      accessToken: 'expired-local-access',
      refreshToken: 'expired-local-refresh',
    }));
    await expect(
      loginSessionContext(
        runtime,
        input,
        dependencies({
          clock: () => new Date(calls++ === 0 ? now : '2026-09-10T12:00:00.000Z'),
          issueTokens: signer,
        }),
      ),
    ).rejects.toThrow('session-expired');
    expect(signer).toHaveBeenCalledTimes(1);
    expect(await snapshot()).toEqual(before);
  });

  it('refuses a credential reset committed between private verification and the credential row lock', async () => {
    const held = barrier();
    const release = barrier();
    const blocker = settle(
      owner.$transaction(async (tx) => {
        await tx.$queryRawUnsafe(
          `SELECT "row_id" FROM "LOGIN_MAST" WHERE "tenant_id"=$1 AND "CO_CODE"='01' AND "LOGIN_NAME"='operator' FOR UPDATE`,
          tenant,
        );
        await tx.$executeRawUnsafe(
          `UPDATE "LOGIN_MAST" SET "LOGIN_PWD"=$2,"PASSWORD_RESET_REQUIRED"='Y',"PASSWORD_CHANGED_AT"=clock_timestamp() WHERE "tenant_id"=$1`,
          tenant,
          resetHash,
        );
        held.release();
        await release.promise;
      }),
    );
    await Promise.race([
      held.promise,
      blocker.then((result) => {
        if (result.error) throw result.error;
        throw new Error('credential blocker completed before its hold');
      }),
    ]);
    const signer = vi.fn(async () => ({ accessToken: 'forbidden', refreshToken: 'forbidden' }));
    const login = settle(
      loginSessionContext(runtime, input, dependencies({ issueTokens: signer })),
    );
    let waitError: unknown;
    try {
      await waitForLock(loginApp);
    } catch (error) {
      waitError = error;
    } finally {
      release.release();
    }
    const blockerResult = await blocker;
    const afterReset = await snapshot();
    const loginResult = await login;
    if (waitError) throw waitError;
    expect(blockerResult.error).toBeUndefined();
    expect(loginResult.error).toMatchObject({ name: 'AuthError', reason: 'invalid-credentials' });
    expect(signer).not.toHaveBeenCalled();
    expect(await snapshot()).toEqual(afterReset);
    expect(await sessionRow()).toBeUndefined();
    expect((await loginRows())[0]?.password).toBe(resetHash);
  });

  it('password reset waits behind login credential lock then revokes the newly committed session and target sibling only', async () => {
    const entered = barrier();
    const release = barrier();
    const foreignBefore = await owner.$queryRawUnsafe(
      `SELECT to_jsonb(t)::text AS raw FROM "auth_session" t WHERE "tenant_id"=$1 ORDER BY "session_id"`,
      foreignTenant,
    );
    const otherBefore = await sessionRow(otherCompanySid);
    const login = settle(
      loginSessionContext(
        runtime,
        input,
        dependencies({
          issueTokens: async () => {
            entered.release();
            await release.promise;
            return { accessToken: 'issued-before-reset', refreshToken: 'issued-before-reset' };
          },
        }),
      ),
    );
    await Promise.race([
      entered.promise,
      login.then((result) => {
        if (result.error) throw result.error;
        throw new Error('login completed before the signer hold');
      }),
    ]);
    const reset = settle(
      resetUserPassword(resetClient, {
        tenantId: tenant,
        coCode: '01',
        loginName: 'operator',
        newPassword: resetPassword,
      }),
    );
    let waitError: unknown;
    try {
      await waitForLock(resetApp);
    } catch (error) {
      waitError = error;
    } finally {
      release.release();
    }
    const loginResult = await login;
    const resetResult = await reset;
    if (waitError) throw waitError;
    expect(loginResult.error).toBeUndefined();
    expect(resetResult.error).toBeUndefined();
    for (const key of [sid, oldSid]) {
      const row = await sessionRow(key);
      expect(row?.revoke_reason).toBe('password-reset');
      expect(row?.revoked_at).not.toBeNull();
    }
    expect(await sessionRow(otherCompanySid)).toEqual(otherBefore);
    expect(
      await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text AS raw FROM "auth_session" t WHERE "tenant_id"=$1 ORDER BY "session_id"`,
        foreignTenant,
      ),
    ).toEqual(foreignBefore);
    expect(await verifyPassword((await loginRows())[0]!.password, resetPassword)).toBe(true);
  });
});
