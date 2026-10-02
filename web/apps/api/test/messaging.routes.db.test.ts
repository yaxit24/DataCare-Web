import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, afterEach, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';

/**
 * N54 step 4 / G33 over HTTP and the real database: messaging never reports a delivery that did not happen.
 *
 *  - No provider configured: `POST /integrations/notify` and `POST /reminders/send` answer 503
 *    `messaging-unconfigured` BEFORE an attempt is recorded, so `message_attempt_log` stays empty.
 *  - `MESSAGING_FAKE_MODE=1` outside production gives a SIMULATED send: recorded as `simulated`, reported with
 *    `ok:false`, never `sent`.
 *  - In production the fake flag is ignored, so the same request is refused.
 * Before this change an unconfigured server answered `{ok:true, mode:'fake'}` and logged the attempt as `sent`.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'messaging-route-db';
const PASSWORD = 'Messaging-Route!2026';
const SECRET = 'messaging-route-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const PROVIDER_ENV = [
  'WA_PHONE_ID',
  'WA_TOKEN',
  'SMS_URL_TEMPLATE',
  'SMS_KEY',
  'MESSAGING_FAKE_MODE',
  'NODE_ENV',
] as const;

(enabled ? describe : describe.skip)('N54 messaging fails closed', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const saved: Record<string, string | undefined> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const attempts = async () =>
    (await owner.$queryRawUnsafe(
      `SELECT "status","template_kind" FROM "message_attempt_log" WHERE tenant_id=$1 ORDER BY "id"`,
      tenantId,
    )) as Array<{ status: string; template_kind: string }>;
  /** Provider configuration is read per request from the process environment, as in production. */
  const providerEnv = (values: Partial<Record<(typeof PROVIDER_ENV)[number], string>>) => {
    for (const name of PROVIDER_ENV) delete process.env[name];
    Object.assign(process.env, values);
  };
  const post = (url: string, payload: unknown) =>
    app.inject({
      method: 'POST',
      url,
      headers: { cookie, 'content-type': 'application/json' },
      payload: JSON.stringify(payload),
    });
  const notify = (key: string) =>
    post('/integrations/notify', {
      to: '919812345670',
      channel: 'whatsapp',
      body: 'Your bill is ready',
      templateKind: 'manual-test',
      idempotencyKey: key,
    });
  const remind = (key: string) =>
    post('/reminders/send', {
      mobile: '919812345670',
      message: 'Payment reminder',
      channel: 'whatsapp',
      templateKind: 'overdue',
      idempotencyKey: key,
    });

  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('messaging route fixtures require isolated database 55433');
    for (const name of PROVIDER_ENV) saved[name] = process.env[name];
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01','messenger',$2,'ADMIN','Y','Y','Y','N')`,
      tenantId,
      await hashPassword(PASSWORD),
    );
    app = await buildApp({
      prisma: runtime,
      secret: SECRET,
      secureCookies: false,
      defaultTenantId: tenantId,
      allowTenantHeader: true,
    });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: {
        coCode: '01',
        lcCode: '01',
        coYear: YEAR,
        loginName: 'messenger',
        password: PASSWORD,
      },
    });
    expect(login.statusCode, login.body).toBe(200);
    const value = login.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });

  afterEach(async () => {
    await exec(`DELETE FROM "message_attempt_log" WHERE tenant_id=$1`, tenantId);
  });

  afterAll(async () => {
    for (const name of PROVIDER_ENV) {
      if (saved[name] === undefined) delete process.env[name];
      else process.env[name] = saved[name];
    }
    if (app) await app.close();
    if (owner) {
      await wipe();
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('refuses both send routes with 503 when no provider is configured, and records nothing', async () => {
    providerEnv({});
    const notified = await notify('unconfigured-notify');
    expect(notified.statusCode, notified.body).toBe(503);
    expect(notified.json()).toMatchObject({ error: 'messaging-unconfigured' });
    const reminded = await remind('unconfigured-remind');
    expect(reminded.statusCode, reminded.body).toBe(503);
    expect(reminded.json()).toMatchObject({ error: 'messaging-unconfigured' });
    expect(await attempts()).toEqual([]);
  });

  it('reports a test-mode send as simulated, never as sent', async () => {
    providerEnv({ MESSAGING_FAKE_MODE: '1' });
    const notified = await notify('simulated-notify');
    expect(notified.statusCode, notified.body).toBe(200);
    expect(notified.json()).toMatchObject({ ok: false, status: 'simulated', mode: 'simulated' });
    const reminded = await remind('simulated-remind');
    expect(reminded.statusCode, reminded.body).toBe(200);
    expect(reminded.json()).toMatchObject({ ok: false, status: 'simulated', mode: 'simulated' });
    expect(await attempts()).toEqual([
      { status: 'simulated', template_kind: 'manual-test' },
      { status: 'simulated', template_kind: 'overdue' },
    ]);
  });

  it('ignores the fake flag in production, so the send is refused and nothing is recorded', async () => {
    providerEnv({ MESSAGING_FAKE_MODE: '1', NODE_ENV: 'production' });
    const notified = await notify('production-notify');
    expect(notified.statusCode, notified.body).toBe(503);
    expect(notified.json()).toMatchObject({ error: 'messaging-unconfigured' });
    expect(await attempts()).toEqual([]);
  });

  it('says on the status endpoint that sends are refused, not "wired"', async () => {
    providerEnv({});
    const response = await app.inject({
      method: 'GET',
      url: '/integrations/status',
      headers: { cookie },
    });
    expect(response.statusCode, response.body).toBe(200);
    const messaging = response.json().messaging;
    expect(messaging.provider).toBe('unconfigured');
    expect(messaging.status).toMatch(/refused/i);
  });
});
