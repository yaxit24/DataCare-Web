import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { snapshotTenant } from './support/tenantSnapshot.js';

/** N52 / G29 / D18, WP-04 batch B: retries are transport assertions over each real voucher writer. */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'idem-lite-b-db';
const OTHER = 'idem-lite-b-other';
const LOGIN = 'clerk';
const PASSWORD = 'Idem-Lite-B-Test!2026';
const SECRET = 'idempotency-lite-b-test-signing-secret-over-thirty-two';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

const fineBody = () => ({
  coBook: 'FJV',
  lcCode: '01',
  coYear: YEAR,
  vchDate: DAY,
  metal: 'G',
  lines: [
    { crdr: 'DR', acCode: 'PARTY', fine: 1.25, itDesc: 'Idempotency fine debit' },
    { crdr: 'CR', acCode: 'BANK', fine: 1.25, itDesc: 'Idempotency fine credit' },
  ],
});
const openingBody = () => ({
  acCode: 'PARTY',
  amount: 777,
  sign: 'D',
  gold: 0,
  goldSign: 'C',
  silver: 0,
  silverSign: 'C',
  bills: [],
});
const tagBody = (tagNo = 'IDEMB-TAG') => ({
  coBook: 'TOP',
  lcCode: '01',
  coYear: YEAR,
  vchDate: DAY,
  lines: [{ tagNo, itCode: 'GL', pcs: 1, grossWt: 10, netWt: 10, touch: 90 }],
});

type Case = {
  name: string;
  slug: string;
  route: string;
  status: number;
  body: (tagNo?: string) => Record<string, unknown>;
  changed: (body: Record<string, unknown>) => Record<string, unknown>;
  count: () => Promise<number>;
  writesOnce: (before: number, after: number) => void;
  tags?: () => Promise<string[]>;
};

(enabled ? describe : describe.skip)('N52 Lite batch B idempotency through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async (tenant: string) => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await exec(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenant);
  };
  const snapshot = async (tenant = TENANT) => {
    const result = await snapshotTenant(owner, tenant);
    result.delete('audit_log');
    return result;
  };
  const post = (url: string, body: unknown, key: string, tenant = TENANT) =>
    app.inject({
      method: 'POST',
      url,
      headers: { cookie: cookies[tenant] ?? '', 'idempotency-key': key },
      payload: body as never,
    });
  const count = async (table: string, where: string, params: unknown[] = []) => {
    const rows: Array<{ n: number }> = await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND ${where}`,
      TENANT,
      ...params,
    );
    return rows[0]!.n;
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    for (const tenant of [TENANT, OTHER]) {
      await wipe(tenant);
      await seedCompany(runtime, tenant, '01');
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','PARTY','Idempotency Party','10'),($1,'01','01','BANK','Idempotency Bank','10')`,
        tenant,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES ($1,'01','GL','Idempotency Gold','G')`,
        tenant,
      );
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES ($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
        tenant,
        LOGIN,
        await hashPassword(PASSWORD),
      );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const tenant of [TENANT, OTHER]) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenant },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const header = response.headers['set-cookie'];
      cookies[tenant] = (Array.isArray(header) ? header : [header ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) for (const tenant of [TENANT, OTHER]) await wipe(tenant);
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  const cases: Case[] = [
    {
      name: 'Fine Jv',
      slug: 'fjv',
      route: '/fine-jv',
      status: 201,
      body: fineBody,
      changed: (body) => ({ ...body, metal: 'S' }),
      count: () => count('CONTRA_DATA', `"CO_BOOK"='FJV'`),
      writesOnce: (before, after) => expect(after).toBe(before + 2),
    },
    {
      name: 'Party Opening',
      slug: 'pty',
      route: '/ac-opbl',
      status: 200,
      body: openingBody,
      changed: (body) => ({ ...body, amount: 778 }),
      count: async () =>
        (await count('OP_DATA', `"CO_BOOK"='000' AND "AC_CODE"='PARTY'`)) +
        (await count('AC_DATA', `"CO_BOOK"='000' AND "AC_CODE"='PARTY'`)),
      // Save replaces the party's rows, so the count alone cannot see a second execution. The replay case's
      // whole-tenant snapshot (SELECT *, including row_id) and the race case's single replayed response can.
      writesOnce: (_before, after) => expect(after).toBe(2),
    },
    {
      name: 'Tag Opening',
      slug: 'top',
      route: '/stock/tag-opening',
      status: 201,
      body: tagBody,
      changed: (body) => ({ ...body, vchDate: `${startYear}-06-16` }),
      count: () => count('BAR_DATA', `"CO_BOOK"='TOP'`),
      writesOnce: (before, after) => expect(after).toBe(before + 1),
      tags: async () =>
        (
          await owner.$queryRawUnsafe<Array<{ tag: string }>>(
            `SELECT "TAG_NO" tag FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TOP' ORDER BY "TAG_NO"`,
            TENANT,
          )
        ).map((row) => row.tag),
    },
  ];
  for (const entry of cases) {
    it(`${entry.name}: a replayed create answers the first response byte for byte and writes once`, async () => {
      const key = `${entry.slug}-replay`;
      const body = entry.body(key);
      const before = await entry.count();
      const other = await snapshot(OTHER);
      const first = await post(entry.route, body, key);
      expect(first.statusCode, first.body).toBe(entry.status);
      const saved = await snapshot();
      const replay = await post(entry.route, body, key);
      expect.soft(replay.statusCode).toBe(first.statusCode);
      expect.soft(replay.body).toBe(first.body);
      expect.soft(replay.headers['idempotency-replayed']).toBe('true');
      entry.writesOnce(before, await entry.count());
      if (entry.tags) expect.soft(await entry.tags()).toContain(key);
      expect.soft(await snapshot()).toEqual(saved);
      expect(await snapshot(OTHER)).toEqual(other);
    });
    it(`${entry.name}: the same key with a different body is 409 idempotency-key-reused and writes nothing`, async () => {
      const key = `${entry.slug}-changed`;
      const body = entry.body(key);
      expect((await post(entry.route, body, key)).statusCode).toBe(entry.status);
      const before = await entry.count();
      const saved = await snapshot();
      const changed = await post(entry.route, entry.changed(body), key);
      expect.soft(changed.statusCode).toBe(409);
      expect.soft(changed.json()).toMatchObject({ error: 'idempotency-key-reused' });
      expect.soft(await entry.count()).toBe(before);
      expect(await snapshot()).toEqual(saved);
    });
    it(`${entry.name}: two identical requests racing with one key write once`, async () => {
      const key = `${entry.slug}-race`;
      const body = entry.body(key);
      const before = await entry.count();
      const [a, b] = await Promise.all([
        post(entry.route, body, key),
        post(entry.route, body, key),
      ]);
      expect.soft([a.statusCode, b.statusCode]).toEqual([entry.status, entry.status]);
      expect.soft(a.body).toBe(b.body);
      expect
        .soft(
          [a.headers['idempotency-replayed'], b.headers['idempotency-replayed']].filter(Boolean),
        )
        .toEqual(['true']);
      entry.writesOnce(before, await entry.count());
      if (entry.tags) expect.soft(await entry.tags()).toContain(key);
    });
  }
});
