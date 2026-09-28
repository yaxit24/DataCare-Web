import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { SignJWT } from 'jose';
import { buildApp } from '../src/app.js';
import { issueAccess, verifyAccessToken, type AccessInput } from '../src/modules/auth/jwt.js';
import { validateAccessSessionContext } from '../src/modules/auth/sessionContextAccess.js';

const databaseDescribe = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenant = 'context-access-db';
const foreignTenant = 'context-access-other';
const sid = '11111111-1111-4111-8111-111111111111';
const secret = 'session-context-access-tests-only-local-signing-material';
const unknownLedger = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'legacy-session-uninitialized',
};
const accessInput = () => ({
  tenantId: tenant,
  sub: 'operator',
  sid,
  loginCoCode: '01',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  contextEpoch: '9',
  // Intentionally stale granted rights. Admission must use the fresh principal instead.
  rights: { userUpdate: true, userDelete: true, userPrint: true },
  passwordResetRequired: false,
});
const token = (patch: Record<string, unknown> = {}) =>
  issueAccess({ ...accessInput(), ...patch } as AccessInput, secret);

databaseDescribe('read-only epoch-bearing access admission on real PostgreSQL', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cleanup = async () => {
    for (const table of ['auth_session', 'LOGIN_MAST']) {
      await owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE "tenant_id" IN ($1,$2)`,
        tenant,
        foreignTenant,
      );
    }
  };
  const sessionSnapshot = () =>
    owner.$queryRawUnsafe(
      `SELECT to_jsonb(s)::text AS raw,s.xmin::text AS xmin,s.ctid::text AS ctid
       FROM "auth_session" s WHERE "tenant_id" IN ($1,$2) ORDER BY "tenant_id","session_id"`,
      tenant,
      foreignTenant,
    );
  const validate = async (patch: Record<string, unknown> = {}) =>
    validateAccessSessionContext(runtime, await verifyAccessToken(await token(patch), secret));

  beforeAll(async () => {
    if (!process.env.MIGRATE_DATABASE_URL || !process.env.DATABASE_URL)
      throw new Error('isolated database wrapper required');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL } } });
    app = await buildApp({
      prisma: runtime,
      secret,
      defaultTenantId: tenant,
      allowTenantHeader: false,
      logger: false,
    });
  });
  beforeEach(async () => {
    await cleanup();
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"("tenant_id","CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01','operator','fixture','USER','N','N','N','N'),
              ($1,'02','operator','fixture','USER','N','N','Y','N')`,
      tenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "auth_session"("tenant_id","session_id","login_name","login_co_code","co_code","lc_code","co_year",
          "refresh_jti_hash","created_at","last_used_at","expires_at","context_epoch","ledger_context")
       VALUES ($1,$3,'operator','01','01','01','2024-2025',repeat('a',64),clock_timestamp(),clock_timestamp(),clock_timestamp()+interval '1 hour',9,$4::jsonb),
              ($2,$3,'foreign-operator','02','02','02','2025-2026',repeat('b',64),clock_timestamp(),clock_timestamp(),clock_timestamp()+interval '1 hour',11,$4::jsonb)`,
      tenant,
      foreignTenant,
      sid,
      JSON.stringify(unknownLedger),
    );
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('returns detached immutable exact context while leaving both full session rows and physical identities unchanged', async () => {
    const before = await sessionSnapshot();
    const result = await validate();
    expect(result).toEqual({
      tenantId: tenant,
      sessionId: sid,
      loginName: 'operator',
      loginCoCode: '01',
      coCode: '01',
      lcCode: '01',
      coYear: '2024-2025',
      contextEpoch: '9',
      ledgerContext: unknownLedger,
    });
    expect(Object.isFrozen(result)).toBe(true);
    expect(Object.isFrozen(result.ledgerContext)).toBe(true);
    expect(Object.hasOwn(result, 'rights')).toBe(false);
    expect(await sessionSnapshot()).toEqual(before);
  });
  it.each(['1', '9007199254740993', '9223372036854775807'])(
    'matches canonical stored epoch %s without Number conversion',
    async (contextEpoch) => {
      await owner.$executeRawUnsafe(
        `UPDATE "auth_session" SET "context_epoch"=$3::bigint WHERE "tenant_id"=$1 AND "session_id"=$2`,
        tenant,
        sid,
        contextEpoch,
      );
      const before = await sessionSnapshot();
      expect((await validate({ contextEpoch })).contextEpoch).toBe(contextEpoch);
      expect(await sessionSnapshot()).toEqual(before);
    },
  );
  it('preserves incomplete stored year as undefined without inventing an epoch or mode', async () => {
    const ledger = { ...unknownLedger, reason: 'scope-incomplete' };
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "co_year"=NULL,"ledger_context"=$3::jsonb WHERE "tenant_id"=$1 AND "session_id"=$2`,
      tenant,
      sid,
      JSON.stringify(ledger),
    );
    const before = await sessionSnapshot();
    expect(await validate({ coYear: undefined })).toMatchObject({
      coYear: undefined,
      contextEpoch: '9',
      ledgerContext: ledger,
    });
    expect(await sessionSnapshot()).toEqual(before);
  });
  it.each([
    { label: 'subject', patch: { sub: 'another-user' } },
    { label: 'sid', patch: { sid: '22222222-2222-4222-8222-222222222222' } },
    { label: 'immutable login company', patch: { loginCoCode: '02' } },
    { label: 'selected company', patch: { coCode: '02' } },
    { label: 'selected branch', patch: { lcCode: '02' } },
    { label: 'selected year', patch: { coYear: '2025-2026' } },
    { label: 'epoch', patch: { contextEpoch: '10' } },
    { label: 'other tenant same sid', patch: { tenantId: foreignTenant } },
  ])('refuses $label mismatch without auth-session writes', async ({ patch }) => {
    const before = await sessionSnapshot();
    await expect(validate(patch)).rejects.toMatchObject({ code: 'session-invalid' });
    expect(await sessionSnapshot()).toEqual(before);
  });
  it.each(['expired', 'revoked'] as const)(
    'refuses %s persisted authority without extending expiry or changing revocation',
    async (kind) => {
      if (kind === 'expired')
        await owner.$executeRawUnsafe(
          `UPDATE "auth_session" SET "expires_at"=clock_timestamp()-interval '1 second' WHERE "tenant_id"=$1 AND "session_id"=$2`,
          tenant,
          sid,
        );
      else
        await owner.$executeRawUnsafe(
          `UPDATE "auth_session" SET "revoked_at"=clock_timestamp(),"revoke_reason"='fixture-revoked' WHERE "tenant_id"=$1 AND "session_id"=$2`,
          tenant,
          sid,
        );
      const before = await sessionSnapshot();
      await expect(validate()).rejects.toMatchObject({
        code: kind === 'expired' ? 'session-expired' : 'session-revoked',
      });
      expect(await sessionSnapshot()).toEqual(before);
    },
  );
  it('rejects the original signed A token after A to B to A even when the visible scope tuple matches again', async () => {
    const original = await verifyAccessToken(await token(), secret);
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "co_code"='02',"lc_code"='02',"co_year"='2025-2026',"context_epoch"=10 WHERE "tenant_id"=$1 AND "session_id"=$2`,
      tenant,
      sid,
    );
    const middle = await sessionSnapshot();
    await expect(validateAccessSessionContext(runtime, original)).rejects.toMatchObject({
      code: 'session-invalid',
    });
    expect(await sessionSnapshot()).toEqual(middle);
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "co_code"='01',"lc_code"='01',"co_year"='2024-2025',"context_epoch"=11 WHERE "tenant_id"=$1 AND "session_id"=$2`,
      tenant,
      sid,
    );
    const after = await sessionSnapshot();
    await expect(validateAccessSessionContext(runtime, original)).rejects.toMatchObject({
      code: 'session-invalid',
    });
    expect((await validate({ contextEpoch: '11' })).contextEpoch).toBe('11');
    expect(await sessionSnapshot()).toEqual(after);
  });
  it('reader itself rejects a missing or malformed epoch even if a typed caller bypassed JWT verification', async () => {
    const claims = await verifyAccessToken(await token(), secret);
    const before = await sessionSnapshot();
    for (const epoch of [undefined, 9, '09', '9223372036854775808']) {
      await expect(
        validateAccessSessionContext(runtime, {
          ...claims,
          contextEpoch: epoch,
        } as unknown as typeof claims),
      ).rejects.toMatchObject({ code: 'session-invalid' });
    }
    expect(await sessionSnapshot()).toEqual(before);
  });

  it('GET /me allows absent page headers for bootstrap, returns exact context plus unknown diagnostics and fresh rights, and is no-store', async () => {
    const before = await sessionSnapshot();
    const response = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: `access=${await token()}`, 'x-tenant-id': foreignTenant },
    });
    expect(response.statusCode).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    const body = response.json();
    expect(body.context).toEqual({
      sessionId: sid,
      contextEpoch: '9',
      coCode: '01',
      lcCode: '01',
      coYear: '2024-2025',
    });
    expect(Object.keys(body.context).sort()).toEqual([
      'coCode',
      'coYear',
      'contextEpoch',
      'lcCode',
      'sessionId',
    ]);
    expect(body.ledgerContext).toEqual(unknownLedger);
    expect(body.rights).toEqual({ userUpdate: false, userDelete: false, userPrint: false });
    expect(response.headers['set-cookie']).toBeUndefined();
    expect(await sessionSnapshot()).toEqual(before);
  });
  it.each([
    { label: 'id only', headers: { 'x-session-context-id': sid } },
    { label: 'epoch only', headers: { 'x-session-context-epoch': '9' } },
    {
      label: 'wrong id',
      headers: { 'x-session-context-id': 'other', 'x-session-context-epoch': '9' },
    },
    {
      label: 'wrong epoch',
      headers: { 'x-session-context-id': sid, 'x-session-context-epoch': '10' },
    },
    {
      label: 'noncanonical epoch',
      headers: { 'x-session-context-id': sid, 'x-session-context-epoch': '09' },
    },
  ])(
    'GET /me refuses supplied $label page identity without changing session authority',
    async ({ headers }) => {
      const before = await sessionSnapshot();
      const response = await app.inject({
        method: 'GET',
        url: '/me',
        headers: { cookie: `access=${await token()}`, ...headers },
      });
      expect(response.statusCode).toBe(409);
      expect(response.json()).toEqual({ error: 'context-stale' });
      expect(response.headers['cache-control']).toBe('no-store');
      expect(response.headers['set-cookie']).toBeUndefined();
      expect(await sessionSnapshot()).toEqual(before);
    },
  );
  it('GET /me accepts a complete matching page identity and serializes absent year as null', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "co_year"=NULL WHERE "tenant_id"=$1 AND "session_id"=$2`,
      tenant,
      sid,
    );
    const before = await sessionSnapshot();
    const response = await app.inject({
      method: 'GET',
      url: '/me',
      headers: {
        cookie: `access=${await token({ coYear: undefined })}`,
        'x-session-context-id': sid,
        'x-session-context-epoch': '9',
      },
    });
    expect(response.statusCode).toBe(200);
    expect(response.json().context.coYear).toBeNull();
    expect(await sessionSnapshot()).toEqual(before);
  });
  it('fresh principal reset state restricts context operations while /me remains available', async () => {
    const oldToken = await token();
    await owner.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST" SET "USER_PRINT"='Y',"PASSWORD_RESET_REQUIRED"='Y' WHERE "tenant_id"=$1 AND "CO_CODE"='01'`,
      tenant,
    );
    const before = await sessionSnapshot();
    const me = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: `access=${oldToken}` },
    });
    expect(me.statusCode).toBe(200);
    expect(me.json()).toMatchObject({
      passwordResetRequired: true,
      rights: { userUpdate: false, userDelete: false, userPrint: true },
    });
    const blocked = await app.inject({
      method: 'GET',
      url: '/context/companies',
      headers: { cookie: `access=${oldToken}` },
    });
    expect(blocked.statusCode).toBe(403);
    expect(blocked.json()).toEqual({ error: 'password-reset-required' });
    expect(await sessionSnapshot()).toEqual(before);
  });
  it('selected-company principal does not replace immutable stored login company', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "co_code"='02',"lc_code"='02',"co_year"='2025-2026',"context_epoch"=10 WHERE "tenant_id"=$1 AND "session_id"=$2`,
      tenant,
      sid,
    );
    const patch = { coCode: '02', lcCode: '02', coYear: '2025-2026', contextEpoch: '10' };
    const before = await sessionSnapshot();
    expect(await validate(patch)).toMatchObject({
      loginCoCode: '01',
      coCode: '02',
      contextEpoch: '10',
    });
    const response = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: `access=${await token(patch)}` },
    });
    expect(response.statusCode).toBe(200);
    expect(response.json().rights).toEqual({
      userUpdate: false,
      userDelete: false,
      userPrint: true,
    });
    expect(await sessionSnapshot()).toEqual(before);
  });
  it('rejects a correctly signed old epoch-less access token through the actual authentication hook', async () => {
    const old: Record<string, unknown> = { ...accessInput(), typ: 'access' };
    delete old.contextEpoch;
    const oldToken = await new SignJWT(old)
      .setProtectedHeader({ alg: 'HS256', typ: 'JWT' })
      .setIssuer('datacare-api')
      .setAudience('datacare-web')
      .setIssuedAt()
      .setExpirationTime('15m')
      .sign(new TextEncoder().encode(secret));
    const before = await sessionSnapshot();
    const response = await app.inject({
      method: 'GET',
      url: '/me',
      headers: { cookie: `access=${oldToken}` },
    });
    expect(response.statusCode).toBe(401);
    expect(response.headers['cache-control']).toBe('no-store');
    expect(response.headers['set-cookie']).toBeUndefined();
    expect(await sessionSnapshot()).toEqual(before);
  });
});
