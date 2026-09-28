import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'r7-source-http';
const otherTenant = 'r7-source-http-other';
const target = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R73' };
const original = { sourceYear: '2023-2024', sourceBook: 'S73', sourceVchNo: '00017' };
const password = 'Return-Source-Route!2026';
type Role = 'view' | 'unrelated' | 'other';
const businessTables = [
  'SL_IDTL',
  'SL_DETL',
  'SL_DETL_RTN',
  'SL_DATA',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'REMARK_DATA',
  'SRNO_MAST',
];
const query = (values: Record<string, unknown>) =>
  new URLSearchParams(
    Object.entries(values)
      .filter(([, value]) => value !== undefined)
      .map(([key, value]): [string, string] => [key, String(value)]),
  ).toString();

(enabled ? describe : describe.skip)('original Sales source read HTTP boundary', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Partial<Record<Role, string>> = {};
  const sql = (q: string, ...p: unknown[]) => owner.$executeRawUnsafe(q, ...p);
  const endpoint = (suffix: 'source-items' | 'source-vouchers', values: Record<string, unknown>) =>
    `/sales-returns/${suffix}?${query(values)}`;
  const call = (url: string, role: Role | 'anonymous' = 'view') =>
    app.inject({
      method: 'GET',
      url,
      headers: role === 'anonymous' ? {} : { cookie: cookies[role] ?? '' },
    });
  const read = async (overrides: Record<string, unknown> = {}, role: Role = 'view') => {
    const response = await call(
      endpoint('source-items', { ...target, ...original, ...overrides }),
      role,
    );
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    return response.json();
  };
  async function clean(all = false) {
    for (const tenant of [tenantId, otherTenant])
      for (const table of all
        ? [
            'audit_log',
            'auth_session',
            ...businessTables,
            'ITEM_MAST',
            'BOOK_DATA',
            'USER_SET',
            'LOGIN_MAST',
            'YEAR_MAST',
            'LOCT_MAST',
            'CO_MAST',
          ]
        : ['SL_IDTL', 'SL_DETL', 'SL_DETL_RTN', 'SL_DATA'])
        await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
  }
  async function snapshot() {
    const rows: Record<string, unknown> = {};
    for (const table of businessTables)
      rows[table] = await owner.$queryRawUnsafe(
        `SELECT (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)) e) raw
         FROM "${table}" t WHERE tenant_id IN ($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        otherTenant,
      );
    return rows;
  }
  async function seed() {
    await clean();
    for (const tenant of [tenantId, otherTenant])
      for (const book of ['S73', 'S74']) {
        await sql(
          `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK",
          "VCH_NO","VCH_DATE","VCH_TIME","AC_CODE","AC_NAME","BILL_NO","NET_AMT","TOT_AMT")
          VALUES($1,'01','01','2023-2024',$2,'00017','2023-08-12',
          '2023-08-12 11:12:13.123456','C001',$3,'Invoice 17',9007199254740993.17,9007199254740993.17)`,
          tenant,
          book,
          tenant === tenantId ? `Source ${book}` : `Other tenant ${book}`,
        );
        await sql(
          `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
          "SR_NO","OLD_SRNO","VCH_SRNO","IT_CODE","TAG_NO","INOUT_TYPE","ENTRY_TYPE",
          "VCH_DATE","VCH_TIME","ITM_PCS","ITM_GWT","ITM_NWT","ITM_RATE","ITM_AMT","HM_ID",
          "HM_ID2","ITM_REMARK","DESIGN_IMG_ID")
          VALUES($1,'01','01','2023-2024',$2,'00017',17,31,117,'01001','SOURCE-TAG','O','S',
          '2023-08-12','2023-08-12 11:12:13.123456',0,12.345,10.123,9007199254740993.17,81.17,NULL,
          'HIDDEN2','',NULL),
          ($1,'01','01','2023-2024',$2,'00017',42,58,142,'01001','SECOND-TAG','O','S',
          '2023-08-12','2023-08-12 11:12:13.654321',1,1.123,1.001,17.17,17.17,'SECOND',
          NULL,'Second','N')`,
          tenant,
          book,
        );
        // Desktop child ownership follows parent OLD_SRNO31, not displayed SR_NO17.
        await sql(
          `INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
          "SR_NO","ISR_NO","VCH_SRNO","TAG_NO","IT_CODE","IT_GWT","IT_AMT")
          VALUES($1,'01','01','2023-2024',$2,'00017',31,3,117,'SOURCE-TAG','DIA',0.123,7.13),
          ($1,'01','01','2023-2024',$2,'00017',31,9,117,'SOURCE-TAG','STN',0.007,3.11)`,
          tenant,
          book,
        );
      }
  }
  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('Isolated source database required.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean(true);
    const hashed = await hashPassword(password);
    for (const tenant of [tenantId, otherTenant]) {
      await sql(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE")
        VALUES($1,'01','Source test','01')`,
        tenant,
      );
      await sql(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME")
        VALUES($1,'01','01','Main'),($1,'01','02','Other')`,
        tenant,
      );
      await sql(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
        VALUES($1,'01','2024-2025','2024-04-01','2025-03-31'),
        ($1,'01','2023-2024','2023-04-01','2024-03-31')`,
        tenant,
      );
      await sql(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME") VALUES
        ($1,'01','01','R73','Return','SALES RETURNE','I','Y','SL_DATA'),
        ($1,'01','01','S73','Original sale A','SALES','O','Y','SL_DATA'),
        ($1,'01','01','S74','Original sale B','SALES','O','Y','SL_DATA'),
        ($1,'01','01','S75','Inactive sale','SALES','O','N','SL_DATA')`,
        tenant,
      );
      await sql(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","RATE_TYPE","PR_CODE")
        VALUES($1,'01','01001','Gold ring','G','G','P1')`,
        tenant,
      );
      for (const [name, form] of [
        ['view', 'Sales Return'],
        ['unrelated', 'Sales'],
      ] as const) {
        await sql(
          `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG",
          "USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
          VALUES($1,'01',$2,$3,'USER','N','N','N','N')`,
          tenant,
          name,
          hashed,
        );
        await sql(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU",
          "FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
          VALUES($1,'01','01',$2,'Sales',$3,'Y','N','N','N')`,
          tenant,
          name,
          form,
        );
      }
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'source-return-route-signing-secret-over-thirty-two-characters',
      secureCookies: false,
    });
    for (const role of ['view', 'unrelated', 'other'] as const) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': role === 'other' ? otherTenant : tenantId },
        payload: {
          coCode: target.coCode,
          lcCode: target.lcCode,
          coYear: target.coYear,
          loginName: role === 'other' ? 'view' : role,
          password,
        },
      });
      expect(response.statusCode, response.body).toBe(200);
      const values = response.headers['set-cookie'];
      cookies[role] = (Array.isArray(values) ? values : [values ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    }
  });
  beforeEach(seed);
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await clean(true);
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('reads an explicit historical source without replacing the target Return scope', async () => {
    const dto = await read();
    expect(dto.scope).toMatchObject(target);
    expect(dto.source).toMatchObject({
      coCode: '01',
      lcCode: '01',
      coYear: '2023-2024',
      coBook: 'S73',
      voucherNo: '00017',
    });
    expect(dto.version).toMatch(/^[a-f0-9]{64}$/);
    expect(dto.header.raw).toMatchObject({ AC_NAME: 'Source S73', TOT_AMT: '9007199254740993.17' });
    expect(dto.header.raw.VCH_TIME).toContain('11:12:13.123456');
    const row = dto.lines.find((value: any) => value.raw.SR_NO === '17');
    expect(row.raw).toMatchObject({
      OLD_SRNO: '31',
      VCH_SRNO: '117',
      ITM_RATE: '9007199254740993.17',
      HM_ID: null,
      HM_ID2: 'HIDDEN2',
      ITM_REMARK: '',
      DESIGN_IMG_ID: null,
    });
    expect(row.sourceRef).toMatchObject({ srNo: '17', oldSrNo: '31', vchSrno: '117' });
    expect(row.components.map((value: any) => value.raw.ISR_NO)).toEqual(['3', '9']);
    expect(row.components.every((value: any) => value.raw.SR_NO === '31')).toBe(true);
    expect(dto.capabilities.canApplyIncoming).toBe(false);
    expect(dto.capabilities.reason).toBeTruthy();
  });
  it('keeps same-number sources separate by configured original book and authenticated tenant', async () => {
    expect((await read({ sourceBook: 'S74' })).header.raw.AC_NAME).toBe('Source S74');
    expect((await read({}, 'other')).header.raw.AC_NAME).toBe('Other tenant S73');
    const first = await read();
    expect((await read({ sourceBook: 'S74' })).version).not.toBe(first.version);
    expect((await read({}, 'other')).version).not.toBe(first.version);
  });
  it('browses scoped original invoices with bounded search and pagination', async () => {
    const response = await call(
      endpoint('source-vouchers', {
        ...target,
        sourceYear: original.sourceYear,
        search: 'Invoice 17',
        limit: 1,
        offset: 0,
      }),
    );
    expect(response.statusCode, response.body).toBe(200);
    expect(response.headers['cache-control']).toBe('no-store');
    expect(response.json().rows).toHaveLength(1);
    expect(response.json().hasMore).toBe(true);
    const filtered = await call(
      endpoint('source-vouchers', {
        ...target,
        sourceYear: original.sourceYear,
        sourceBook: 'S74',
      }),
    );
    expect(filtered.statusCode, filtered.body).toBe(200);
    expect(filtered.json().rows.map((row: any) => row.raw.AC_NAME)).toEqual(['Source S74']);
  });
  it('requires own-form read rights and protects the selected company, branch and target year', async () => {
    const url = endpoint('source-items', { ...target, ...original });
    expect((await call(url, 'anonymous')).statusCode).toBe(401);
    expect((await call(url, 'unrelated')).statusCode).toBe(403);
    expect((await call(endpoint('source-vouchers', target), 'unrelated')).statusCode).toBe(403);
    for (const override of [{ coCode: '02' }, { lcCode: '02' }, { coYear: '2023-2024' }]) {
      const response = await call(
        endpoint('source-items', { ...target, ...original, ...override }),
      );
      expect(response.statusCode, response.body).toBe(409);
    }
  });
  it('rejects incomplete identities, ambiguous query values and hidden source scope overrides', async () => {
    for (const key of [...Object.keys(target), ...Object.keys(original)]) {
      const response = await call(
        endpoint('source-items', { ...target, ...original, [key]: undefined }),
      );
      expect(response.statusCode, `${key}: ${response.body}`).toBe(400);
    }
    for (const extra of [
      { tenantId: otherTenant },
      { sourceCoCode: '02' },
      { sourceLcCode: '02' },
      { sourceVchNo: '1e2' },
      { sourceVchNo: '00017 OR 1=1' },
    ]) {
      const response = await call(endpoint('source-items', { ...target, ...original, ...extra }));
      expect(response.statusCode, response.body).toBe(400);
    }
    const duplicate = await call(
      endpoint('source-items', { ...target, ...original }) + '&sourceBook=S74',
    );
    expect(duplicate.statusCode, duplicate.body).toBe(400);
    for (const bad of [{ offset: '-1' }, { limit: '101' }, { offset: '0.5' }, { limit: '1e2' }]) {
      const response = await call(endpoint('source-vouchers', { ...target, ...bad }));
      expect(response.statusCode, response.body).toBe(400);
    }
  });
  it('refuses the wrong source family, inactive book, unknown year and missing original voucher', async () => {
    for (const override of [
      { sourceBook: 'R73' },
      { sourceBook: 'S75' },
      { sourceYear: '1999-2000' },
    ]) {
      const response = await call(
        endpoint('source-items', { ...target, ...original, ...override }),
      );
      expect([400, 422], response.body).toContain(response.statusCode);
    }
    const missing = await call(
      endpoint('source-items', { ...target, ...original, sourceVchNo: '99999' }),
    );
    expect(missing.statusCode, missing.body).toBe(404);
  });
  it('observes changed source generations without mutating any voucher or business companion', async () => {
    const before = await snapshot();
    const first = await read();
    await read({ sourceBook: 'S74' });
    const list = await call(endpoint('source-vouchers', target));
    expect(list.statusCode, list.body).toBe(200);
    expect(await snapshot()).toEqual(before);
    await sql(
      `UPDATE "SL_DETL" SET "HM_ID2"='REVISED' WHERE tenant_id=$1 AND "CO_BOOK"='S73' AND "SR_NO"=17`,
      tenantId,
    );
    const second = await read();
    expect(second.version).not.toBe(first.version);
    expect(second.lines.find((row: any) => row.raw.SR_NO === '17').raw.HM_ID2).toBe('REVISED');
    const afterChange = await snapshot();
    await read();
    expect(await snapshot()).toEqual(afterChange);
  });
});
