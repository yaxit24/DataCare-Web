import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, afterEach, beforeAll, describe, expect, it, vi } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { enrollMember, listMembers, postPoints } from '../src/modules/membership/membership.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { warmPostingMetadata } from '../src/modules/posting/posting.js';
import { resetSchemaCatalog } from '../src/modules/shared/schemaCatalog.js';
import { scopeKey } from '../src/modules/vouchers/numbering.js';

/**
 * N53 (G30, G31) over HTTP and the real database:
 *  - once the catalog is warm, a voucher save issues no information_schema query, and a cold process
 *    loads the catalog in exactly one query rather than once per table;
 *  - a voucher whose transaction waits past its budget fails as a retryable 503 and writes nothing;
 *  - two sessions redeeming 80 of 100 points at once produce one redemption and a balance of 20.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'tx-budget-route-db';
const PASSWORD = 'Tx-Budget-Route!2026';
const SECRET = 'tx-budget-route-test-signing-secret-over-thirty-two-chars';
const LOGIN = 'cashier';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const sleep = (ms: number) => new Promise((resolve) => setTimeout(resolve, ms));

(enabled ? describe : describe.skip)('N53 transaction budgets and loyalty locking', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const statements: string[] = [];
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const receipt = (amount: number) =>
    app.inject({
      method: 'POST',
      url: '/receipts',
      headers: { cookie },
      payload: { coBook: 'RCT', partyAc: 'CUST01', amount, mode: 'cash' },
    });
  const written = async () =>
    query<Array<{ cash: number; legs: number }>>(
      `SELECT (SELECT count(*)::int FROM "CASH_DATA" WHERE tenant_id=$1) cash,
              (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) legs`,
      tenantId,
    ).then((rows) => rows[0]);
  const catalogQueries = () => statements.filter((sql) => /information_schema/i.test(sql));

  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('transaction budget fixtures require isolated database 55433');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient({ log: [{ emit: 'event', level: 'query' }] });
    (runtime as any).$on('query', (event: { query: string }) => statements.push(event.query));
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','CUST01','Walk-in Customer','10')`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Transaction','Cash Received','Y','Y','Y','Y')`,
      tenantId,
      LOGIN,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
    });
    expect(login.statusCode, login.body).toBe(200);
    const value = login.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });
  afterEach(() => {
    vi.unstubAllEnvs();
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('a cold process loads the catalog once; after warming, a voucher save issues no catalog query', async () => {
    resetSchemaCatalog();
    statements.length = 0;
    const cold = await receipt(100);
    expect(cold.statusCode, cold.body).toBe(201);
    // One bulk load for the whole schema, not one query per table or per number allocation.
    expect(catalogQueries()).toHaveLength(1);

    statements.length = 0;
    const warmAgain = await receipt(110);
    expect(warmAgain.statusCode, warmAgain.body).toBe(201);
    expect(catalogQueries()).toEqual([]);

    // The start-up path: warm explicitly (as server.ts does before listen), then serve.
    resetSchemaCatalog();
    expect(await warmPostingMetadata(runtime)).toBeGreaterThan(100);
    statements.length = 0;
    const served = await receipt(120);
    expect(served.statusCode, served.body).toBe(201);
    expect(catalogQueries()).toEqual([]);
  });

  it('a voucher held past its budget fails as a retryable 503 and writes nothing', async () => {
    vi.stubEnv('DATACARE_TX_BUDGET_VOUCHER_MS', '1500');
    const before = await written();
    const key = `voucher|${scopeKey({ tenantId, coCode: '01', lcCode: '01', coYear: YEAR, coBook: 'RCT' })}`;
    let release!: () => void;
    const released = new Promise<void>((resolve) => (release = resolve));
    // Another cashier's save in the same book holds the numbering lock for longer than the budget.
    const holder = owner.$transaction(
      async (tx) => {
        await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', key);
        await released;
      },
      { timeout: 20_000 },
    );
    // Safety net: if the save were not bounded it would wait for this lock; release it eventually so a
    // regression fails on the status below instead of hanging the suite.
    const safety = setTimeout(() => release(), 10_000);
    try {
      await sleep(200);
      const started = Date.now();
      const blocked = await receipt(130);
      expect(blocked.statusCode, blocked.body).toBe(503);
      expect(blocked.headers['retry-after']).toBe('1');
      expect(blocked.json()).toEqual({ error: 'transaction-timeout', retryable: true });
      // Bounded by the 1.5 s budget, not by how long the other session holds its lock (10 s here).
      expect(Date.now() - started).toBeLessThan(5_000);
    } finally {
      clearTimeout(safety);
      release();
      await holder;
    }
    expect(await written()).toEqual(before);

    // Nothing is left half-done: once the lock is free the same save succeeds.
    const retried = await receipt(130);
    expect(retried.statusCode, retried.body).toBe(201);
  }, 30_000);

  it('two sessions redeeming 80 of 100 points at once leave one redemption and a balance of 20', async () => {
    const scope = { tenantId, coCode: '01', lcCode: '01', coYear: YEAR };
    await enrollMember(runtime, scope, { membCode: 'M53', membName: 'Race member' });
    await postPoints(runtime, scope, { membCode: 'M53', points: 100, type: 'earn' });
    let release!: () => void;
    const released = new Promise<void>((resolve) => (release = resolve));
    // Hold the member row so both redemptions are in flight together before either can read the balance.
    const holder = withTenant(
      runtime,
      tenantId,
      async (tx: any) => {
        await tx.$queryRawUnsafe(
          `SELECT 1 FROM "POINT_MEMB" WHERE "CO_CODE"='01' AND "POINT_CODE"='L1' AND "MEMB_CODE"='M53' FOR UPDATE`,
        );
        await released;
      },
      { timeout: 20_000 },
    );
    await sleep(100);
    const redemptions = Promise.allSettled([
      postPoints(runtime, scope, { membCode: 'M53', points: 80, type: 'redeem' }),
      postPoints(runtime, scope, { membCode: 'M53', points: 80, type: 'redeem' }),
    ]);
    // Wait until both are queued behind the held row lock (an unlocked implementation never queues).
    for (let i = 0; i < 30; i++) {
      const [row] = await query<Array<{ waiting: number }>>(
        `SELECT count(*)::int waiting FROM pg_stat_activity
          WHERE datname=current_database() AND wait_event_type='Lock' AND query ILIKE '%POINT_MEMB%FOR UPDATE%'`,
      );
      if ((row?.waiting ?? 0) >= 2) break;
      await sleep(100);
    }
    release();
    await holder;
    const outcomes = await redemptions;
    expect(outcomes.map((o) => o.status).sort()).toEqual(['fulfilled', 'rejected']);
    const failure = outcomes.find((o) => o.status === 'rejected') as PromiseRejectedResult;
    expect(String(failure.reason?.message)).toMatch(/redeem 80 exceeds balance 20/);
    const [member] = (await listMembers(runtime, scope)).filter((m) => m.membCode === 'M53');
    expect(member?.points).toBe(20);
    const [redemptionCount] = await query<Array<{ redeemed: number }>>(
      `SELECT count(*)::int redeemed FROM "POINT_DATA" WHERE tenant_id=$1 AND "MEMB_CODE"='M53' AND "INOUT_TYPE"='O'`,
      tenantId,
    );
    expect(redemptionCount?.redeemed).toBe(1);
  }, 30_000);
});
