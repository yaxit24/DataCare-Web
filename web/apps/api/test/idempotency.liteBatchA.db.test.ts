import type { FastifyInstance } from 'fastify';
import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { snapshotTenant } from './support/tenantSnapshot.js';

/**
 * N52 / G29 / D18, WP-04 batch A: HTTP retry expectations come from the frozen packet's
 * idempotency contract. These are transport assertions, not new business calculations.
 * Fixtures follow salesOrderLifecycle.routes.db.test.ts and approvalLifecycle.routes.db.test.ts.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'idem-lite-a-db';
const OTHER = 'idem-lite-a-other';
const PASSWORD = 'Idem-Lite-A-Test!2026';
const SECRET = 'idempotency-lite-a-test-signing-secret-over-thirty-two-chars';
const LOGIN = 'clerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const salesBody = () => ({
  acCode: 'PARTY',
  acName: 'Idempotency Fixture',
  billNo: 'IDEM-A',
  vchDate: DAY,
  vchTime: '12:34:56.123456',
  advanceAmount: 0,
  taxRatePct: 0,
  lines: [
    {
      itCode: 'GL',
      designNo: 'IDEM-D1',
      designImageId: 'N',
      pcs: 1,
      grossWt: 10,
      netWt: 10,
      touch: 90,
      rate: 100,
      labourType: 'G',
      labourRate: 2,
      labourAmount: 20,
      components: [],
    },
  ],
});
const issueBody = () => ({
  coBook: 'TUR',
  vchDate: DAY,
  partyAc: 'PARTY',
  empCode: 'E01',
  vchDesc: 'IDEM ISSUE',
  lines: [{ itCode: 'GL', tagNo: 'N', vchSrno: 0, pcs: 1, grossWt: 10, netWt: 10, touch: 90 }],
});

(enabled ? describe : describe.skip)('N52 Lite batch A idempotency through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async (tenant: string) => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await exec(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
  };
  const post = (url: string, payload: unknown, key: string, tenant = TENANT) =>
    app.inject({
      method: 'POST',
      url,
      headers: { cookie: cookies[tenant] ?? '', 'idempotency-key': key },
      payload: payload as any,
    });
  const count = async (table: string, book: string) => {
    const rows: Array<{ n: number }> = await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01'
        AND "LC_CODE"='01' AND "CO_YEAR"=$2 AND "CO_BOOK"=$3`,
      TENANT,
      YEAR,
      book,
    );
    return rows[0]!.n;
  };
  // Every request (replay and 409 included) is audited by design; the write set under test is the business tables.
  const snapshot = async (tenant = TENANT) => {
    const all = await snapshotTenant(owner, tenant);
    all.delete('audit_log');
    return all;
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    for (const tenant of [TENANT, OTHER]) {
      await wipe(tenant);
      await seedCompany(runtime, tenant, '01');
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
         VALUES ($1,'01','01','PARTY','Idempotency Fixture','10')`,
        tenant,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
         VALUES ($1,'01','GL','Fixture Gold','G')`,
        tenant,
      );
      await exec(
        `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME")
         VALUES ($1,'01','E01','Fixture Employee')`,
        tenant,
      );
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
          "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
         VALUES ($1,'01','01','S51','Fixture Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL')`,
        tenant,
      );
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG",
          "USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES ($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        tenant,
        LOGIN,
        await hashPassword(PASSWORD),
      );
      for (const subMenu of ['Sales Order', 'Approval Isu', 'Approval Rtn'])
        await exec(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU",
            "FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES ($1,'01','01',$2,'Sales',$3,'Y','Y','Y','Y')`,
          tenant,
          LOGIN,
          subMenu,
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
      const value = response.headers['set-cookie'];
      cookies[tenant] = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await wipe(TENANT);
      await wipe(OTHER);
    }
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  const routes = [
    { name: 'Sales Order', route: '/sales-orders', table: 'SL_ORD_DATA', book: 'S51' },
    { name: 'Approval Isu', route: '/tour/issue', table: 'APR_DATA', book: 'TUR' },
    { name: 'Approval Rtn', route: '/tour/return', table: 'APR_DATA', book: 'TRR' },
  ];
  for (const { name, route, table, book } of routes) {
    const url = `${route}?${new URLSearchParams({ coCode: '01', lcCode: '01', coYear: YEAR, coBook: book })}`;
    const draft = async (key: string) => {
      if (route === '/sales-orders') return salesBody();
      if (route === '/tour/issue') return issueBody();
      // Each return case gets its own original issue, created through HTTP, not inserted as a voucher seed.
      const issue = await post('/tour/issue', issueBody(), `${key}-source`);
      expect(issue.statusCode, issue.body).toBe(201);
      return {
        coBook: 'TRR',
        origBook: 'TUR',
        origYear: YEAR,
        origVchNo: issue.json().voucherNo,
        vchDate: DAY,
        partyAc: 'PARTY',
        empCode: 'E01',
        vchDesc: 'IDEM RETURN',
        lines: [{ origSrNo: 1, itCode: 'GL', tagNo: 'N', vchSrno: 0 }],
      };
    };

    it(`${name} (${route}): a replayed create answers the first response byte for byte and posts one voucher`, async () => {
      const key = `${book}-replay`;
      const body = await draft(key);
      const before = await count(table, book);
      const other = await snapshot(OTHER);
      const first = await post(url, body, key);
      expect(first.statusCode, first.body).toBe(201);
      const saved = await snapshot();
      const replay = await post(url, body, key);
      // D18 / packet section 3: replay preserves status, response bytes and the complete write set.
      expect.soft(replay.statusCode).toBe(first.statusCode);
      expect.soft(replay.body).toBe(first.body);
      expect.soft(replay.headers['idempotency-replayed']).toBe('true');
      expect.soft(await count(table, book)).toBe(before + 1);
      expect.soft(await snapshot()).toEqual(saved);
      expect(await snapshot(OTHER)).toEqual(other);
    });

    it(`${name} (${route}): the same key with a different body is 409 idempotency-key-reused and writes nothing`, async () => {
      const key = `${book}-changed`;
      const body = await draft(key);
      const first = await post(url, body, key);
      expect(first.statusCode, first.body).toBe(201);
      const before = await count(table, book);
      const saved = await snapshot();
      const other = await snapshot(OTHER);
      const changedBody =
        route === '/sales-orders'
          ? { ...body, billNo: 'IDEM-CHANGED' }
          : { ...body, vchDesc: 'IDEM CHANGED' };
      const changed = await post(url, changedBody, key);
      // D18 / packet section 3: changed-body reuse is a conflict before any posting.
      expect.soft(changed.statusCode).toBe(409);
      expect.soft(changed.json()).toMatchObject({ error: 'idempotency-key-reused' });
      expect.soft(await count(table, book)).toBe(before);
      expect.soft(await snapshot()).toEqual(saved);
      expect(await snapshot(OTHER)).toEqual(other);
    });

    it(`${name} (${route}): two identical requests racing with one key post one voucher`, async () => {
      const key = `${book}-race`;
      const body = await draft(key);
      const before = await count(table, book);
      const other = await snapshot(OTHER);
      const [a, b] = await Promise.all([post(url, body, key), post(url, body, key)]);
      // D18 / packet section 3: both callers receive the one committed voucher's answer.
      expect.soft([a.statusCode, b.statusCode]).toEqual([201, 201]);
      expect.soft(a.body).toBe(b.body);
      expect
        .soft(
          [a.headers['idempotency-replayed'], b.headers['idempotency-replayed']].filter(Boolean),
        )
        .toEqual(['true']);
      expect.soft(await count(table, book)).toBe(before + 1);
      expect(await snapshot(OTHER)).toEqual(other);
    });
  }
});
