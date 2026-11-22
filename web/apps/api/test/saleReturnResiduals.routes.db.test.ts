import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, afterEach, beforeAll, describe, expect, it, vi } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { scopeKey } from '../src/modules/vouchers/numbering.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-27 (N242, G254): Sales Return edit and the create budget over HTTP (orchestration/work/WP-27/cases.md).
 *  - reopen.lossless-no-op: GET a saved return, PUT it back unchanged, every row of its write set is identical;
 *  - edit.numeric at the API (R -> R'), concurrency.stale-edit (409), rights.edit-needs-update (403);
 *  - budget.timeout-is-retryable and budget.create-p95 (decision D13).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'wp27-sale-return-routes';
const password = 'Wp27-Return-Route!2026';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const WRITE_TABLES = [
  'SL_DATA',
  'SL_DETL_RTN',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'ROJ_MEL_DATA',
  'BILL_OS_DATA',
  'DM_DATA',
  'REMARK_DATA',
  'TEMP_BOOK_DATA',
];
const LINE_R = {
  itCode: 'LOOSE',
  pcs: 1,
  grossWt: 10.25,
  netWt: 10,
  touch: 91.6,
  rate: 6123.45,
  labourType: 'per_gram',
  labourRate: 237.5,
};
const body = (overrides: Record<string, unknown> = {}) => ({
  coBook: 'SRT',
  coYear: YEAR,
  acCode: 'CUST',
  acName: 'Route Customer',
  vchDate: DAY,
  taxRatePct: 3,
  interState: false,
  lines: [LINE_R],
  ...overrides,
});
const sleep = (ms: number) => new Promise((resolve) => setTimeout(resolve, ms));

(enabled ? describe : describe.skip)('WP-27 Sales Return edit and budget over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<'full' | 'viewer', string> = { full: '', viewer: '' };
  const sql = (q: string, ...p: unknown[]) => owner.$executeRawUnsafe(q, ...p);
  const rows = <T = Record<string, unknown>>(q: string, ...p: unknown[]) =>
    owner.$queryRawUnsafe(q, ...p) as Promise<T[]>;
  const call = (
    method: 'GET' | 'POST' | 'PUT',
    url: string,
    payload?: unknown,
    role: 'full' | 'viewer' = 'full',
  ) => app.inject({ method, url, headers: { cookie: cookies[role] }, payload: payload as any });

  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name: table } of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  };
  const writeSet = async (voucherNo: string) => {
    const state: Record<string, unknown[]> = {};
    for (const table of WRITE_TABLES)
      state[table] = await rows(
        `SELECT to_jsonb(t) - 'row_id' AS r FROM "${table}" t WHERE tenant_id=$1 AND "CO_BOOK"='SRT'
           AND ("VCH_NO"=$2 OR $3) ORDER BY (to_jsonb(t) - 'row_id')::text`,
        tenantId,
        voucherNo,
        table === 'TEMP_BOOK_DATA',
      );
    return state;
  };
  const returnCount = async () =>
    Number(
      (
        await rows<{ n: number }>(
          `SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT'`,
          tenantId,
        )
      )[0]?.n ?? 0,
    );
  const create = async (overrides: Record<string, unknown> = {}) => {
    const response = await call('POST', '/sales-returns', body(overrides));
    expect(response.statusCode, response.body).toBe(201);
    return String(response.json().vchNo).padStart(5, '0');
  };
  const reopen = async (voucherNo: string, role: 'full' | 'viewer' = 'full') => {
    const response = await call(
      'GET',
      `/sales-returns/${voucherNo}?coBook=SRT&coYear=${YEAR}`,
      undefined,
      role,
    );
    expect(response.statusCode, response.body).toBe(200);
    return response.json();
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await sql(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE","CO_TYPE") VALUES($1,'01','Route test','01','A')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES($1,'01','01','Main')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01',$2,'2024-04-01','2025-03-31')`,
      tenantId,
      YEAR,
    );
    await sql(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","SL_AMT_TYPE","TAX_ROF") VALUES($1,'01',NULL,'N','2')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES($1,'01','01','CUST','Route Customer','L')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC") VALUES($1,'01','10',0,'GST','GST 3%',3,'GSTLED')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC") VALUES($1,'01','G01','Gold','SALEAC')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES($1,'01','LOOSE','Loose Gold','G','G01')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES($1,'01','01','SRT','Sales Return','SRTN','SALES RETURNE','I','Y','SL_DATA')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES($1,'01','01','SRT',1,'CTRL','SALES RETURNE','I'),($1,'01','01','SRT',2,'CASH','SALES RETURNE','I'),
             ($1,'01','01','SRT',3,'ROUND','SALES RETURNE','I')`,
      tenantId,
    );
    const hashed = await hashPassword(password);
    for (const [name, edit] of [
      ['full', 'Y'],
      ['viewer', 'N'],
    ] as const) {
      await sql(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER',$4,$4,'Y','N')`,
        tenantId,
        name,
        hashed,
        edit,
      );
      await sql(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Sales','Sales Return','Y',$3,$3,'Y')`,
        tenantId,
        name,
        edit,
      );
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'wp27-sale-return-route-signing-secret-over-thirty-two-chars',
      secureCookies: false,
    });
    for (const role of ['full', 'viewer'] as const) {
      const login = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: role, password },
      });
      expect(login.statusCode, login.body).toBe(200);
      const value = login.headers['set-cookie'];
      cookies[role] = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }
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

  it('sales-return.reopen.lossless-no-op: GET then PUT unchanged rewrites identical rows and no USER_DATA', async () => {
    const voucherNo = await create({
      empCode: 'E7',
      chequeAmt: 1000,
      bankAc: 'BANK1',
      lines: [
        LINE_R,
        {
          itCode: 'LOOSE',
          pcs: 2,
          grossWt: 1,
          netWt: 1,
          touch: 90,
          rate: 100,
          labourType: 'fixed',
          labourFixed: 25,
        },
      ],
    });
    const before = await writeSet(voucherNo);
    const saved = await reopen(voucherNo);
    expect(saved.version).toMatch(/^[0-9a-f]{64}$/);
    const put = await call('PUT', `/sales-returns/${voucherNo}`, {
      ...saved,
      coBook: 'SRT',
      coYear: YEAR,
      expectedVersion: saved.version,
    });
    expect(put.statusCode, put.body).toBe(200);
    expect(await writeSet(voucherNo)).toEqual(before);
    expect(await rows(`SELECT 1 FROM "USER_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(0);
  });

  it('sales-return.edit.numeric (API) and concurrency.stale-edit: R -> R9; the stale copy is a 409', async () => {
    const voucherNo = await create();
    const first = await reopen(voucherNo);
    const second = await reopen(voucherNo);
    const edited = await call('PUT', `/sales-returns/${voucherNo}`, {
      ...first,
      coBook: 'SRT',
      coYear: YEAR,
      // As the grid does: changing the weight re-prices the line, so the stored amount and fine are not sent.
      lines: first.lines.map(({ metalAmount: _a, fineWt: _f, ...line }: any) => ({ ...line, netWt: 9 })),
      expectedVersion: first.version,
    });
    expect(edited.statusCode, edited.body).toBe(200);
    const [h] = await rows<Record<string, number>>(
      `SELECT "TOT_AMT"::float tot,"NET_AMT"::float net FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"=$2`,
      tenantId,
      voucherNo,
    );
    expect(h).toEqual({ tot: 58966, net: 57249 });
    const afterEdit = await writeSet(voucherNo);

    const stale = await call('PUT', `/sales-returns/${voucherNo}`, {
      ...second,
      coBook: 'SRT',
      coYear: YEAR,
      expectedVersion: second.version,
    });
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json().error).toBe('voucher-version-conflict');
    expect(await writeSet(voucherNo)).toEqual(afterEdit);
  });

  it('sales-return.concurrency.stale-delete: DELETE needs the current version (N51/D17)', async () => {
    const voucherNo = await create();
    const saved = await reopen(voucherNo);
    const before = await writeSet(voucherNo);
    const url = `/sales-returns/${voucherNo}?coBook=SRT&coYear=${YEAR}`;
    const missing = await app.inject({ method: 'DELETE', url, headers: { cookie: cookies.full } });
    expect(missing.statusCode, missing.body).toBe(400);
    const stale = await app.inject({
      method: 'DELETE',
      url: `${url}&expectedVersion=${'0'.repeat(64)}`,
      headers: { cookie: cookies.full },
    });
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json().error).toBe('voucher-version-conflict');
    expect(await writeSet(voucherNo)).toEqual(before);
    const ok = await app.inject({
      method: 'DELETE',
      url: `${url}&expectedVersion=${saved.version}`,
      headers: { cookie: cookies.full },
    });
    expect(ok.statusCode, ok.body).toBe(200);
  });

  it('sales-return.rights.edit-needs-update: a user without the edit right is refused and nothing changes', async () => {
    const voucherNo = await create();
    const before = await writeSet(voucherNo);
    const saved = await reopen(voucherNo, 'viewer');
    const refused = await call(
      'PUT',
      `/sales-returns/${voucherNo}`,
      { ...saved, coBook: 'SRT', coYear: YEAR, expectedVersion: saved.version },
      'viewer',
    );
    expect(refused.statusCode, refused.body).toBe(403);
    expect(await writeSet(voucherNo)).toEqual(before);
  });

  it('sales-return.budget.timeout-is-retryable: a create held past its budget is a 503 and writes nothing', async () => {
    vi.stubEnv('DATACARE_TX_BUDGET_VOUCHER_MS', '1500');
    const before = await returnCount();
    const key = `voucher|${scopeKey({ tenantId, coCode: '01', lcCode: '01', coYear: YEAR, coBook: 'SRT' })}`;
    let release!: () => void;
    const released = new Promise<void>((resolve) => (release = resolve));
    const holder = owner.$transaction(
      async (tx) => {
        await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', key);
        await released;
      },
      { timeout: 20_000 },
    );
    const safety = setTimeout(() => release(), 10_000);
    try {
      await sleep(200);
      const started = Date.now();
      const blocked = await call('POST', '/sales-returns', body());
      expect(blocked.statusCode, blocked.body).toBe(503);
      expect(blocked.json()).toEqual({ error: 'transaction-timeout', retryable: true });
      expect(Date.now() - started).toBeLessThan(5_000);
    } finally {
      clearTimeout(safety);
      release();
      await holder;
    }
    expect(await returnCount()).toBe(before);
    expect((await call('POST', '/sales-returns', body())).statusCode).toBe(201);
  }, 30_000);

  it('sales-return.budget.create-p95: twenty sequential creates stay under the 5 s p95 target', async () => {
    await create();
    const durations: number[] = [];
    for (let i = 0; i < 20; i++) {
      const started = performance.now();
      const response = await call('POST', '/sales-returns', body());
      durations.push(performance.now() - started);
      expect(response.statusCode, response.body).toBe(201);
    }
    durations.sort((a, b) => a - b);
    const p95 = durations[Math.ceil(0.95 * durations.length) - 1]!;
    expect(p95).toBeLessThan(5_000);
  }, 120_000);
});
