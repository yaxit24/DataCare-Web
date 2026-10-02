import { createHash, randomUUID } from 'node:crypto';
import { PrismaClient } from '@datacare/db';
import { SignJWT } from 'jose';
import type { FastifyInstance, InjectOptions, LightMyRequestResponse } from 'fastify';
import { afterAll, afterEach, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { verifyAccessToken, verifyRefreshToken } from '../src/modules/auth/jwt.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'context-http-db';
const foreignTenant = 'context-http-other';
const tenants = [tenantId, foreignTenant];
const password = 'Context-Http-Password!2026';
const secret = 'context-http-test-secret-at-least-thirty-two-characters';
const originalScope = { coCode: '01', lcCode: '01', coYear: '2024-2025' };
const targetScope = { coCode: '02', lcCode: '02', coYear: '2025-2026' };
const unknownLedger = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'vendor-authority-unresolved',
};
type Context = {
  sessionId: string;
  contextEpoch: string;
  coCode: string;
  lcCode: string;
  coYear: string | null;
};
type Jar = Record<string, string>;
type Raw = Record<string, string | null>;
type AuditExpectation = {
  tenantId: string;
  loginName: string;
  coCode: string;
  action: 'POST';
  path: '/context/select';
  status: number;
};
type AuditObservation = AuditExpectation & {
  id: string;
  ts: string;
  raw: string;
  revision: string;
  locator: string;
};
const selectionAudit = (context: Context, status: number): AuditExpectation => ({
  tenantId,
  loginName: 'operator',
  // The existing audit hook records the admitted bearer company, not the newly selected company.
  coCode: context.coCode,
  action: 'POST',
  path: '/context/select',
  status,
});
const setCookies = (response: LightMyRequestResponse): string[] => {
  const value = response.headers['set-cookie'];
  return value === undefined ? [] : Array.isArray(value) ? value : [String(value)];
};
const jarFrom = (response: LightMyRequestResponse, prior: Jar = {}): Jar => {
  const next = { ...prior };
  for (const line of setCookies(response)) {
    const pair = line.split(';')[0]!;
    const equal = pair.indexOf('=');
    next[pair.slice(0, equal)] = decodeURIComponent(pair.slice(equal + 1));
  }
  return next;
};
const cookieHeader = (jar: Jar) =>
  Object.entries(jar)
    .map(([key, value]) => `${key}=${encodeURIComponent(value)}`)
    .join('; ');
const page = (context: Context) => ({
  'x-session-context-id': context.sessionId,
  'x-session-context-epoch': context.contextEpoch,
});
const strictRequest = (context: Context, scope = targetScope, id = randomUUID()) => ({
  ...scope,
  expectedContextEpoch: context.contextEpoch,
  selectionId: id,
});
const assertNoIssuedCookie = (response: LightMyRequestResponse) =>
  expect(setCookies(response)).toEqual([]);
const assertCleared = (response: LightMyRequestResponse) => {
  const cookies = setCookies(response);
  for (const name of ['access', 'refresh']) {
    const line = cookies.find((entry) => entry.startsWith(`${name}=`));
    expect(line).toMatch(new RegExp(`^${name}=;`));
    expect(line).toMatch(/(?:Max-Age=0|Expires=Thu, 01 Jan 1970)/i);
  }
};

run('mounted HTTP session context lifecycle with signed cookies and PostgreSQL authority', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let hashed: string;
  let requestAddress = 0;
  let requestNumber = 0;
  const responseCompleted = new Map<string, () => void>();
  let ledgerBefore: unknown;
  const tables = [
    'auth_session',
    'audit_log',
    'USER_SET',
    'CO_SET',
    'AC_DATA',
    'SL_DATA',
    'SL_DETL_RTN',
    'LOGIN_MAST',
    'YEAR_MAST',
    'LOCT_MAST',
    'CO_MAST',
  ];
  const sql = (query: string, ...values: unknown[]) => owner.$executeRawUnsafe(query, ...values);
  const cleanup = async () => {
    for (const table of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id=ANY($1::text[])`, tenants);
  };
  const ledgerSnapshot = async () => {
    const result: Record<string, unknown> = {};
    for (const table of ['AC_DATA', 'SL_DATA', 'SL_DETL_RTN'])
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,xmin::text revision,ctid::text locator FROM "${table}" t
       WHERE tenant_id=ANY($1::text[]) ORDER BY to_jsonb(t)::text`,
        tenants,
      );
    return result;
  };
  const exactSnapshot = async () => {
    const result: Record<string, unknown> = {};
    // Audit has a separate exact append assertion for every request, including refusals.
    for (const table of ['auth_session', 'CO_SET', 'LOGIN_MAST'])
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,xmin::text revision,ctid::text locator FROM "${table}" t
       WHERE tenant_id=ANY($1::text[]) ORDER BY to_jsonb(t)::text`,
        tenants,
      );
    return result;
  };
  const rawSession = async (context: Context) => {
    const rows = await owner.$queryRawUnsafe<Array<{ raw: Raw }>>(
      `SELECT (SELECT jsonb_object_agg(j.key,j.value) FROM jsonb_each_text(to_jsonb(t)) j) AS raw
       FROM auth_session t WHERE tenant_id=$1 AND session_id=$2`,
      tenantId,
      context.sessionId,
    );
    expect(rows).toHaveLength(1);
    return rows[0]!.raw;
  };
  const auditSnapshot = () =>
    owner.$queryRawUnsafe<AuditObservation[]>(
      `SELECT id::text id,ts::text ts,tenant_id AS "tenantId",login_name AS "loginName",
         co_code AS "coCode",action,path,status,to_jsonb(t)::text raw,
         xmin::text revision,ctid::text locator
       FROM audit_log t WHERE tenant_id=ANY($1::text[]) ORDER BY t.id`,
      tenants,
    );
  const assertAuditAppend = async (
    before: AuditObservation[],
    expected: readonly AuditExpectation[],
  ) => {
    const after = await auditSnapshot();
    expect(after.slice(0, before.length), 'existing audit rows and physical identities').toEqual(
      before,
    );
    const added = after.slice(before.length);
    expect(added).toHaveLength(expected.length);
    for (const [index, entry] of added.entries()) {
      const { id, ts, raw, revision, locator, ...facts } = entry;
      expect(facts).toEqual(expected[index]);
      expect(id).toMatch(/^[1-9][0-9]*$/);
      expect(before.some((old) => old.id === id)).toBe(false);
      expect(ts).toMatch(/^\d{4}-\d{2}-\d{2} /);
      expect(revision).toMatch(/^[0-9]+$/);
      expect(locator).toMatch(/^\([0-9]+,[0-9]+\)$/);
      expect(typeof raw).toBe('string');
    }
  };
  const request = async (
    method: 'GET' | 'POST',
    url: string,
    jar: Jar = {},
    payload?: unknown,
    headers: Record<string, string> = {},
    expectedAudit: readonly AuditExpectation[] = [],
  ) => {
    const beforeAudit = await auditSnapshot();
    const requestId = String(++requestNumber);
    let complete!: () => void;
    const completed = new Promise<void>((resolve) => {
      complete = resolve;
    });
    responseCompleted.set(requestId, complete);
    let timer: ReturnType<typeof setTimeout> | undefined;
    try {
      const response = await app.inject({
        method,
        url,
        remoteAddress: `127.0.0.${requestAddress}`,
        headers: { cookie: cookieHeader(jar), ...headers, 'x-context-test-request': requestId },
        ...(payload === undefined ? {} : { payload: payload as InjectOptions['payload'] }),
      });
      // inject can resolve before the async onResponse audit insert commits. This final
      // test-only observer awaits that real hook; it does not replace any audit or DB work.
      await Promise.race([
        completed,
        new Promise<never>((_, reject) => {
          timer = setTimeout(
            () => reject(new Error(`onResponse did not finish for ${method} ${url}`)),
            5000,
          );
        }),
      ]);
      await assertAuditAppend(beforeAudit, expectedAudit);
      return response;
    } finally {
      if (timer !== undefined) clearTimeout(timer);
      responseCompleted.delete(requestId);
    }
  };
  const login = async (payload: Record<string, unknown> = originalScope, tenant = tenantId) => {
    const response = await request(
      'POST',
      '/auth/login',
      {},
      { ...payload, loginName: 'operator', password },
      { 'x-tenant-id': tenant },
    );
    expect(response.statusCode, response.body).toBe(200);
    const body = response.json<{ context: Context; ledgerContext: unknown }>();
    const jar = jarFrom(response);
    expect(jar.access).toBeTruthy();
    expect(jar.refresh).toBeTruthy();
    return { response, body, jar, context: body.context };
  };
  const select = async (jar: Jar, context: Context, payload = strictRequest(context)) => {
    const response = await request('POST', '/context/select', jar, payload, page(context), [
      selectionAudit(context, 200),
    ]);
    expect(response.statusCode, response.body).toBe(200);
    const body = response.json<{ context: Context; ledgerContext: unknown; replayed: boolean }>();
    return { response, body, jar: jarFrom(response, jar), context: body.context, payload };
  };
  const assertDescriptor = (
    response: LightMyRequestResponse,
    context: Context,
    scope: typeof originalScope | { coCode: string; lcCode: string; coYear: null },
    epoch: string,
  ) => {
    expect(context).toEqual({ sessionId: context.sessionId, contextEpoch: epoch, ...scope });
    expect(context.sessionId).toMatch(
      /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/,
    );
    expect(response.headers['cache-control']).toMatch(/no-store/);
  };
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    if (new URL(process.env.DATABASE_URL!).username !== 'app_user')
      throw new Error('app_user runtime required.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    hashed = await hashPassword(password);
    app = await buildApp({ prisma: runtime, secret, secureCookies: false });
    // Registered after the application's audit hook and before the first request.
    app.addHook('onResponse', async (req) => {
      const id = req.headers['x-context-test-request'];
      if (typeof id === 'string') responseCompleted.get(id)?.();
    });
  });
  beforeEach(async () => {
    requestAddress++;
    await cleanup();
    for (const tenant of tenants) {
      for (const company of ['01', '02']) {
        await sql(
          'INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","LC_CODE") VALUES($1,$2,$2)',
          tenant,
          company,
        );
        await sql(
          'INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE") VALUES($1,$2,$2)',
          tenant,
          company,
        );
        for (const year of ['2024-2025', '2025-2026'])
          await sql(
            'INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR") VALUES($1,$2,$3)',
            tenant,
            company,
            year,
          );
        await sql(
          `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
          VALUES($1,$2,'operator',$3,'USER',$4,'N',$5,'N')`,
          tenant,
          company,
          hashed,
          company === '01' ? 'Y' : 'N',
          company === '01' ? 'N' : 'Y',
        );
        await sql(
          'INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LAST_DAY_LOCK","LOCK_DATE") VALUES($1,$2,\'N\',\'2000-01-01\')',
          tenant,
          company,
        );
      }
      await sql(
        `INSERT INTO "AC_DATA"(tenant_id,"LEDR_KEY","CO_CODE","CO_BOOK","CR_AMT","DR_AMT","ENTRY_TIME")
        VALUES($1,'context-no-financial-write','01','R01',90071992547409.91,NULL,'2024-04-03 12:34:56.123456')`,
        tenant,
      );
    }
    ledgerBefore = await ledgerSnapshot();
  });
  afterEach(async () => {
    expect(await ledgerSnapshot()).toEqual(ledgerBefore);
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await cleanup();
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('login and /me expose the exact epoch1 context, unknown ledger, no-store and verifiable HttpOnly cookie attributes', async () => {
    const signed = await login();
    assertDescriptor(signed.response, signed.context, originalScope, '1');
    expect(signed.body.ledgerContext).toEqual(unknownLedger);
    for (const cookie of setCookies(signed.response)) {
      expect(cookie).toMatch(/HttpOnly/i);
      expect(cookie).toMatch(/SameSite=Strict/i);
      expect(cookie).toMatch(/Path=\//i);
    }
    const access = await verifyAccessToken(signed.jar.access!, secret);
    const refresh = await verifyRefreshToken(signed.jar.refresh!, secret);
    expect(access).toMatchObject({
      contextEpoch: '1',
      loginCoCode: '01',
      ...originalScope,
      sid: signed.context.sessionId,
      rights: { userUpdate: true, userDelete: false, userPrint: false },
    });
    expect(refresh).toMatchObject({ sub: 'operator', tenantId, sid: signed.context.sessionId });
    expect(refresh).not.toHaveProperty('contextEpoch');
    expect((await rawSession(signed.context)).refresh_jti_hash).toBe(
      createHash('sha256').update(refresh.jti).digest('hex'),
    );
    const me = await request('GET', '/me', signed.jar, undefined, page(signed.context));
    expect(me.statusCode, me.body).toBe(200);
    expect(me.json()).toMatchObject({ context: signed.context, ledgerContext: unknownLedger });
    expect(me.headers['cache-control']).toMatch(/no-store/);
  });

  it('a no-year login and refresh preserve SQL NULL, JSON null and unknown scope-incomplete without choosing defaults', async () => {
    await sql('DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=\'01\'', tenantId);
    const signed = await login({ coCode: '01', lcCode: '01' });
    assertDescriptor(
      signed.response,
      signed.context,
      { coCode: '01', lcCode: '01', coYear: null },
      '1',
    );
    expect(signed.body.ledgerContext).toEqual({ ...unknownLedger, reason: 'scope-incomplete' });
    await sql(
      'INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR") VALUES($1,\'01\',\'2025-2026\')',
      tenantId,
    );
    const refreshed = await request('POST', '/auth/refresh', signed.jar);
    expect(refreshed.statusCode, refreshed.body).toBe(200);
    expect(refreshed.json()).toMatchObject({
      context: signed.context,
      ledgerContext: signed.body.ledgerContext,
    });
    const jar = jarFrom(refreshed, signed.jar);
    const access = await verifyAccessToken(jar.access!, secret);
    expect(access.coYear).toBeUndefined();
    expect((await rawSession(signed.context)).co_year).toBeNull();
    const selected = await select(jar, signed.context);
    expect(selected.context).toMatchObject({ ...targetScope, contextEpoch: '2' });
  });

  it('selection signs fresh target rights and immutable login company; refresh preserves the exact new context and receipt', async () => {
    const signed = await login();
    const firstRefresh = await verifyRefreshToken(signed.jar.refresh!, secret);
    const selected = await select(signed.jar, signed.context);
    assertDescriptor(selected.response, selected.context, targetScope, '2');
    expect(selected.body.ledgerContext).toEqual(unknownLedger);
    expect(selected.body.replayed).toBe(false);
    expect(setCookies(selected.response).map((value) => value.split('=')[0])).toEqual(['access']);
    const access = await verifyAccessToken(selected.jar.access!, secret);
    expect(access).toMatchObject({
      loginCoCode: '01',
      coCode: '02',
      contextEpoch: '2',
      rights: { userUpdate: false, userDelete: false, userPrint: true },
    });
    const before = await rawSession(selected.context);
    expect(before.refresh_jti_hash).toBe(
      createHash('sha256').update(firstRefresh.jti).digest('hex'),
    );
    const refreshed = await request('POST', '/auth/refresh', selected.jar);
    expect(refreshed.statusCode, refreshed.body).toBe(200);
    expect(refreshed.json()).toMatchObject({
      refreshed: true,
      context: selected.context,
      ledgerContext: unknownLedger,
    });
    const after = await rawSession(selected.context);
    for (const key of Object.keys(before).filter(
      (key) => !['refresh_jti_hash', 'last_used_at'].includes(key),
    ))
      expect(after[key], key).toBe(before[key]);
    expect(after.refresh_jti_hash).not.toBe(before.refresh_jti_hash);
    const freshJar = jarFrom(refreshed, selected.jar);
    const me = await request('GET', '/me', freshJar);
    expect(me.statusCode, me.body).toBe(200);
    expect(me.json()).toMatchObject({ context: selected.context, rights: access.rights });
  });

  it('exact receipt recovery requires the current bearer plus the original body, preserves state, and appends only the expected audit row', async () => {
    const signed = await login();
    const selected = await select(signed.jar, signed.context);
    const old = await request('POST', '/context/select', signed.jar, selected.payload);
    expect(old.statusCode, old.body).toBe(401);
    assertNoIssuedCookie(old);
    const refreshed = await request('POST', '/auth/refresh', selected.jar);
    expect(refreshed.statusCode, refreshed.body).toBe(200);
    const jar = jarFrom(refreshed, selected.jar);
    const before = await exactSnapshot();
    const repeated = await request(
      'POST',
      '/context/select',
      jar,
      selected.payload,
      page(selected.context),
      [selectionAudit(selected.context, 200)],
    );
    expect(repeated.statusCode, repeated.body).toBe(200);
    expect(repeated.json()).toMatchObject({
      context: selected.context,
      replayed: true,
      ledgerContext: unknownLedger,
    });
    expect(await exactSnapshot()).toEqual(before);
    const changed = await request(
      'POST',
      '/context/select',
      jar,
      { ...selected.payload, coYear: '2024-2025' },
      page(selected.context),
      [selectionAudit(selected.context, 409)],
    );
    expect(changed.statusCode, changed.body).toBe(409);
    expect(changed.json()).toEqual({ error: 'context-operation-conflict' });
    assertNoIssuedCookie(changed);
    expect(await exactSnapshot()).toEqual(before);
  });

  it('A→B→A never re-admits the original bearer and rejects an old page even with the newest same-scope cookie', async () => {
    const first = await login();
    const second = await select(first.jar, first.context);
    const third = await select(
      second.jar,
      second.context,
      strictRequest(second.context, originalScope),
    );
    expect(third.context).toEqual({ ...first.context, contextEpoch: '3' });
    const before = await exactSnapshot();
    const oldBearer = await request('GET', '/me', first.jar);
    expect(oldBearer.statusCode, oldBearer.body).toBe(401);
    const oldPage = await request('GET', '/me', third.jar, undefined, page(first.context));
    expect(oldPage.statusCode, oldPage.body).toBe(409);
    expect(oldPage.json()).toEqual({ error: 'context-stale' });
    const latest = await request('GET', '/me', third.jar, undefined, page(third.context));
    expect(latest.statusCode, latest.body).toBe(200);
    expect(latest.json().context).toEqual(third.context);
    expect(await exactSnapshot()).toEqual(before);
  });

  it('same-scope selection increments once, while stale body epoch cannot create another receipt', async () => {
    const first = await login();
    const second = await select(
      first.jar,
      first.context,
      strictRequest(first.context, originalScope),
    );
    expect(second.context).toEqual({ ...first.context, contextEpoch: '2' });
    const before = await exactSnapshot();
    const stale = await request(
      'POST',
      '/context/select',
      second.jar,
      strictRequest(first.context, originalScope),
      page(second.context),
      [selectionAudit(second.context, 409)],
    );
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json()).toEqual({ error: 'context-stale' });
    assertNoIssuedCookie(stale);
    expect(await exactSnapshot()).toEqual(before);
  });

  it.each(['only-id', 'only-epoch', 'different-id', 'noncanonical-epoch'] as const)(
    'supplied page headers refuse %s; the absent pair remains bootstrap-compatible',
    async (kind) => {
      const signed = await login();
      const headers: Record<string, string> =
        kind === 'only-id'
          ? { 'x-session-context-id': signed.context.sessionId }
          : kind === 'only-epoch'
            ? { 'x-session-context-epoch': '1' }
            : kind === 'different-id'
              ? { ...page(signed.context), 'x-session-context-id': randomUUID() }
              : { ...page(signed.context), 'x-session-context-epoch': '01' };
      const before = await exactSnapshot();
      const refused = await request('GET', '/me', signed.jar, undefined, headers);
      expect(refused.statusCode, refused.body).toBe(409);
      expect(refused.json()).toEqual({ error: 'context-stale' });
      const bootstrap = await request('GET', '/me', signed.jar);
      expect(bootstrap.statusCode, bootstrap.body).toBe(200);
      expect(await exactSnapshot()).toEqual(before);
    },
  );

  it('page session identity distinguishes another login at the same epoch and same scope', async () => {
    const first = await login();
    const second = await login();
    expect(second.context.contextEpoch).toBe('1');
    expect(second.context.sessionId).not.toBe(first.context.sessionId);
    const before = await exactSnapshot();
    const response = await request('GET', '/me', second.jar, undefined, page(first.context));
    expect(response.statusCode, response.body).toBe(409);
    expect(response.json()).toEqual({ error: 'context-stale' });
    expect(await exactSnapshot()).toEqual(before);
  });

  it('old or malformed epoch access claims are rejected even when correctly signed; there is no default1', async () => {
    const signed = await login();
    const decoded = await verifyAccessToken(signed.jar.access!, secret);
    const before = await exactSnapshot();
    for (const epoch of [undefined, 1, '01', '0', '9223372036854775808']) {
      const value: Record<string, unknown> = { ...decoded };
      delete value.iat;
      delete value.exp;
      if (epoch === undefined) delete value.contextEpoch;
      else value.contextEpoch = epoch;
      // Real signature using the local fixture secret; intentionally bypass issueAccess's input validator.
      const token = await new SignJWT(value)
        .setProtectedHeader({ alg: 'HS256', typ: 'JWT' })
        .setIssuer('datacare-api')
        .setAudience('datacare-web')
        .setIssuedAt()
        .setExpirationTime('15m')
        .sign(new TextEncoder().encode(secret));
      const response = await request('GET', '/me', { ...signed.jar, access: token });
      expect(response.statusCode, response.body).toBe(401);
      expect(response.json()).toEqual({ error: 'invalid-token' });
      assertNoIssuedCookie(response);
    }
    expect(await exactSnapshot()).toEqual(before);
  });

  it.each([
    'missing-epoch',
    'numeric-epoch',
    'leading-zero',
    'uuid-version1',
    'unknown-key',
    'blank-location',
    'null-year',
  ] as const)(
    'strict selection body refuses %s without scope/lock/session writes or cookies',
    async (kind) => {
      const signed = await login();
      const payload: Record<string, unknown> = strictRequest(signed.context);
      if (kind === 'missing-epoch') delete payload.expectedContextEpoch;
      if (kind === 'numeric-epoch') payload.expectedContextEpoch = 1;
      if (kind === 'leading-zero') payload.expectedContextEpoch = '01';
      if (kind === 'uuid-version1') payload.selectionId = '11111111-1111-1111-8111-111111111111';
      if (kind === 'unknown-key') payload.ledgerMode = 'C';
      if (kind === 'blank-location') payload.lcCode = '';
      if (kind === 'null-year') payload.coYear = null;
      const before = await exactSnapshot();
      const response = await request(
        'POST',
        '/context/select',
        signed.jar,
        payload,
        page(signed.context),
        [selectionAudit(signed.context, 400)],
      );
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json()).toEqual({ error: 'invalid-context-selection-request' });
      assertNoIssuedCookie(response);
      expect(await exactSnapshot()).toEqual(before);
    },
  );

  it('target forced-reset refuses selection before applying an enabled last-day lock and retains current cookies/context', async () => {
    const signed = await login();
    await sql(
      'UPDATE "LOGIN_MAST" SET "PASSWORD_RESET_REQUIRED"=\'Y\' WHERE tenant_id=$1 AND "CO_CODE"=\'02\'',
      tenantId,
    );
    await sql(
      'UPDATE "CO_SET" SET "LAST_DAY_LOCK"=\'Y\' WHERE tenant_id=$1 AND "CO_CODE"=\'02\'',
      tenantId,
    );
    const before = await exactSnapshot();
    const response = await request(
      'POST',
      '/context/select',
      signed.jar,
      strictRequest(signed.context),
      page(signed.context),
      [selectionAudit(signed.context, 403)],
    );
    expect(response.statusCode, response.body).toBe(403);
    expect(response.json()).toEqual({ error: 'target-password-reset-required' });
    assertNoIssuedCookie(response);
    expect(await exactSnapshot()).toEqual(before);
    const me = await request('GET', '/me', signed.jar);
    expect(me.statusCode, me.body).toBe(200);
    expect(me.json().context).toEqual(signed.context);
  });

  it('invalid last-day-lock configuration refuses selection without issuing any access cookie or changing scope', async () => {
    const signed = await login();
    await sql(
      'UPDATE "CO_SET" SET "LAST_DAY_LOCK"=\'X\' WHERE tenant_id=$1 AND "CO_CODE"=\'02\'',
      tenantId,
    );
    const before = await exactSnapshot();
    const response = await request(
      'POST',
      '/context/select',
      signed.jar,
      strictRequest(signed.context),
      page(signed.context),
      [selectionAudit(signed.context, 409)],
    );
    expect(response.statusCode, response.body).toBe(409);
    expect(response.json()).toEqual({ error: 'last-day-lock-invalid' });
    assertNoIssuedCookie(response);
    expect(await exactSnapshot()).toEqual(before);
  });

  it('refresh reuse commits revocation even after the principal disappears and clears both response cookies', async () => {
    const signed = await login();
    const rotated = await request('POST', '/auth/refresh', signed.jar);
    expect(rotated.statusCode, rotated.body).toBe(200);
    const fresh = jarFrom(rotated, signed.jar);
    await sql('DELETE FROM "LOGIN_MAST" WHERE tenant_id=$1', tenantId);
    const before = await rawSession(signed.context);
    const response = await request('POST', '/auth/refresh', signed.jar);
    expect(response.statusCode, response.body).toBe(401);
    expect(response.json()).toEqual({ error: 'invalid-refresh' });
    assertCleared(response);
    const after = await rawSession(signed.context);
    expect(after).toEqual({
      ...before,
      revoked_at: after.revoked_at,
      revoke_reason: 'refresh-reuse',
    });
    expect(after.revoked_at).not.toBeNull();
    const denied = await request('GET', '/me', fresh);
    expect(denied.statusCode, denied.body).toBe(401);
  });

  it('valid current refresh with missing principal clears cookies but rolls back the complete session row', async () => {
    const signed = await login();
    await sql('DELETE FROM "LOGIN_MAST" WHERE tenant_id=$1', tenantId);
    const before = await exactSnapshot();
    const response = await request('POST', '/auth/refresh', signed.jar);
    expect(response.statusCode, response.body).toBe(401);
    expect(response.json()).toEqual({ error: 'invalid-refresh' });
    assertCleared(response);
    expect(await exactSnapshot()).toEqual(before);
  });

  it('foreign tenant header cannot retarget an authenticated context selection', async () => {
    const signed = await login();
    const foreign = await login(originalScope, foreignTenant);
    const before = await owner.$queryRawUnsafe(
      'SELECT to_jsonb(t)::text raw,xmin::text revision,ctid::text locator FROM auth_session t WHERE tenant_id=$1',
      foreignTenant,
    );
    const response = await request(
      'POST',
      '/context/select',
      signed.jar,
      strictRequest(signed.context),
      { ...page(signed.context), 'x-tenant-id': foreignTenant },
      [selectionAudit(signed.context, 200)],
    );
    expect(response.statusCode, response.body).toBe(200);
    expect((await verifyAccessToken(jarFrom(response, signed.jar).access!, secret)).tenantId).toBe(
      tenantId,
    );
    expect(
      await owner.$queryRawUnsafe(
        'SELECT to_jsonb(t)::text raw,xmin::text revision,ctid::text locator FROM auth_session t WHERE tenant_id=$1',
        foreignTenant,
      ),
    ).toEqual(before);
    const me = await request('GET', '/me', foreign.jar);
    expect(me.statusCode, me.body).toBe(200);
    expect(me.json().context).toEqual(foreign.context);
  });
});
