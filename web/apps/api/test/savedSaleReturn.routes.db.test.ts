import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'r6-return-route';
const otherTenant = 'r6-return-other';
const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R63' };
const password = 'Saved-Return-Route!2026';
type Role = 'edit' | 'view' | 'unrelated' | 'other';
const roles: Array<[Exclude<Role, 'other'>, string, string, string]> = [
  ['edit', 'Sales', 'Sales Return', 'Y'],
  ['view', 'Sales', 'Sales Return', 'N'],
  ['unrelated', 'Sales', 'Sales', 'Y'],
];
const query = (values: Record<string, unknown>) =>
  new URLSearchParams(
    Object.entries(values).map(([k, v]): [string, string] => [k, String(v)]),
  ).toString();

(enabled ? describe : describe.skip)('saved incoming Sale Return HTTP lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Partial<Record<Role, string>> = {};
  const sql = (q: string, ...p: unknown[]) => owner.$executeRawUnsafe(q, ...p);
  const endpoint = (
    suffix = 'incoming',
    override: Record<string, unknown> = {},
    voucher = '00017',
  ) => `/sales-returns/${voucher}/${suffix}?${query({ ...scope, ...override })}`;
  const call = (method: 'GET' | 'PUT', url: string, payload?: unknown, role: Role = 'edit') =>
    app.inject({
      method,
      url,
      headers: { cookie: cookies[role] ?? '' },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const read = async (override: Record<string, unknown> = {}, role: Role = 'edit') => {
    const r = await call('GET', endpoint('incoming', override), undefined, role);
    expect(r.statusCode, r.body).toBe(200);
    expect(r.headers['cache-control']).toBe('no-store');
    return r.json();
  };
  const patch = (version: string, identity: unknown, changes: unknown) => ({
    version,
    lines: [{ identity, changes }],
  });
  async function businessSnapshot() {
    const result: Record<string, unknown> = {};
    for (const table of [
      'SL_DATA',
      'SL_DETL_RTN',
      'SL_DETL',
      'SL_IDTL',
      'BAR_DETL',
      'BAR_IDTL',
      'AC_DATA',
      'BILL_OS_DATA',
    ])
      result[table] = await owner.$queryRawUnsafe(
        `SELECT (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)) e) AS raw
         FROM "${table}" t WHERE tenant_id IN ($1,$2) ORDER BY (to_jsonb(t)-'HM_ID'-'ITM_REMARK'-'EMP_CODE')::text`,
        tenantId,
        otherTenant,
      );
    return result;
  }
  async function clean(all = false) {
    for (const tenant of [tenantId, otherTenant])
      for (const table of all
        ? [
            'audit_log',
            'auth_session',
            'SL_IDTL',
            'SL_DETL',
            'SL_DETL_RTN',
            'SL_DATA',
            'BAR_IDTL',
            'BAR_DETL',
            'AC_DATA',
            'BILL_OS_DATA',
            'EMP_MAST',
            'CO_SET',
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
  async function seed() {
    await clean();
    for (const tenant of [tenantId, otherTenant])
      for (const book of ['R63', 'R64']) {
        await sql(
          `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","AC_CODE","AC_NAME","BILL_NO","HD_VCH_NO","NET_AMT","TOT_AMT","RTN_NET_AMT","RTN_TOT_AMT","ISU_NO","ISU_YRCD","ISU_DBCD","ISU_LC_CODE","EMP_CODE","USER_UPDATE")
        VALUES($1,'01','01','2024-2025',$2,'00017','2024-08-12','2024-08-12 11:12:13.123456','C001',$3,'label-17','H17',0,0,917.13,917.13,'00088','2023-2024','S63','01','001','Y')`,
          tenant,
          book,
          tenant === tenantId ? `Return ${book}` : 'Other tenant',
        );
        await sql(
          `INSERT INTO "SL_DETL_RTN"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_SRNO","TAG_SRNO","IT_CODE","TAG_NO","INOUT_TYPE","ENTRY_TYPE","VCH_DATE","VCH_TIME","ITM_PCS","ITM_RATE","ITM_AMT","LBR_AMT","NET_AMT","HM_ID","HM_ID2","ITM_REMARK","DESIGN_IMG_ID","TAG_LBR_CODE","EMP_CODE")
        VALUES($1,'01','01','2024-2025',$2,'00017',17,31,117,4,'01001','','I','P','2024-08-12','2024-08-12 11:12:13.123456',0,9007199254740993.17,812.12,105.01,917.13,NULL,'HIDDEN2','',NULL,'L001','001'),
        ($1,'01','01','2024-2025',$2,'00017',42,58,142,9,'01001','','I','P','2024-08-12','2024-08-12 11:12:13.654321',1,11.11,11.11,0,11.11,'SIBLING',NULL,'Second','N','','001')`,
          tenant,
          book,
        );
      }
  }
  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('Isolated saved Return database required.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean(true);
    const hashed = await hashPassword(password);
    for (const tenant of [tenantId, otherTenant]) {
      await sql(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES($1,'01','Return Test','01')`,
        tenant,
      );
      await sql(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES($1,'01','01','Main'),($1,'01','02','Other')`,
        tenant,
      );
      await sql(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01','2024-2025','2024-04-01','2025-03-31')`,
        tenant,
      );
      await sql(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES($1,'01')`, tenant);
      await sql(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
        VALUES($1,'01','01','R63','Return A','SALES RETURNE','I','Y','SL_DATA'),($1,'01','01','R64','Return B','SALES RETURNE','I','Y','SL_DATA'),($1,'01','01','S63','Sale','SALES','O','Y','SL_DATA')`,
        tenant,
      );
      await sql(
        `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES($1,'01','001','First'),($1,'01','002','Second')`,
        tenant,
      );
      await sql(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES($1,'01','01001','Saved item')`,
        tenant,
      );
      for (const [role, main, sub, edit] of roles) {
        await sql(
          `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
          tenant,
          role,
          hashed,
        );
        await sql(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES($1,'01','01',$2,$3,$4,'Y',$5,'N','N')`,
          tenant,
          role,
          main,
          sub,
          edit,
        );
      }
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'saved-return-route-signing-secret-over-thirty-two-characters',
      secureCookies: false,
    });
    for (const role of ['edit', 'view', 'unrelated', 'other'] as const) {
      const login = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': role === 'other' ? otherTenant : tenantId },
        payload: {
          coCode: scope.coCode,
          lcCode: scope.lcCode,
          coYear: scope.coYear,
          loginName: role === 'other' ? 'edit' : role,
          password,
        },
      });
      expect(login.statusCode, login.body).toBe(200);
      const values = login.headers['set-cookie'];
      cookies[role] = (Array.isArray(values) ? values : [values ?? ''])
        .map((v) => v.split(';', 1)[0])
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

  it('returns exact saved identities, decimals, nulls, source year and microseconds', async () => {
    const dto = await read();
    expect(dto.version).toMatch(/^[a-f0-9]{64}$/);
    expect(dto.scope).toMatchObject(scope);
    expect(dto.header.raw).toMatchObject({
      ISU_NO: '00088',
      ISU_YRCD: '2023-2024',
      ISU_DBCD: 'S63',
      AC_NAME: 'Return R63',
    });
    expect(dto.header.raw.VCH_TIME).toContain('11:12:13.123456');
    expect(dto.lines.map((line: any) => line.identity.srNo)).toEqual(['17', '42']);
    expect(dto.lines[0].raw).toMatchObject({
      ITM_RATE: '9007199254740993.17',
      ITM_PCS: '0.000',
      HM_ID: null,
      ITM_REMARK: '',
      DESIGN_IMG_ID: null,
      TAG_LBR_CODE: 'L001',
    });
    expect(dto.canUpdate).toBe(true);
  });
  it('separates identical vouchers by return book and tenant in browse and reader', async () => {
    const browse = await call('GET', `/sales-returns/incoming-recent?${query(scope)}`);
    expect(browse.statusCode, browse.body).toBe(200);
    expect(browse.json().rows).toHaveLength(1);
    expect((await read({ coBook: 'R64' })).header.raw.AC_NAME).toBe('Return R64');
    expect((await read({}, 'other')).header.raw.AC_NAME).toBe('Other tenant');
  });
  it('allows View to read but blocks metadata Update and unrelated form rights', async () => {
    const dto = await read({}, 'view');
    expect(dto.canUpdate).toBe(false);
    const before = await businessSnapshot();
    const r = await call(
      'PUT',
      endpoint('incoming-metadata'),
      patch(dto.version, dto.lines[0].identity, { huid: 'NEW' }),
      'view',
    );
    expect(r.statusCode).toBe(403);
    expect((await call('GET', endpoint(), undefined, 'unrelated')).statusCode).toBe(403);
    expect(await businessSnapshot()).toEqual(before);
  });
  it('requires explicit identity and refuses scope substitution, wrong family and missing voucher', async () => {
    expect((await call('GET', '/sales-returns/00017/incoming')).statusCode).toBe(400);
    expect((await call('GET', endpoint('incoming', { lcCode: '02' }))).statusCode).toBe(409);
    expect((await call('GET', endpoint('incoming', { coYear: '2023-2024' }))).statusCode).toBe(409);
    expect((await call('GET', endpoint('incoming', { coBook: 'S63' }))).statusCode).toBe(400);
    expect((await call('GET', endpoint('incoming', {}, '99999'))).statusCode).toBe(404);
  });
  it('patches only explicitly dirty metadata and leaves every other business scalar intact', async () => {
    const dto = await read();
    const before = await businessSnapshot();
    const r = await call(
      'PUT',
      endpoint('incoming-metadata'),
      patch(dto.version, dto.lines[0].identity, { huid: 'HUID17', description: 'Received ring' }),
    );
    expect(r.statusCode, r.body).toBe(200);
    expect(r.headers['cache-control']).toBe('no-store');
    expect(r.json().version).not.toBe(dto.version);
    expect(r.json().lines[0].raw).toMatchObject({ HM_ID: 'HUID17', ITM_REMARK: 'Received ring' });
    const after = (await businessSnapshot()) as any;
    for (const row of after.SL_DETL_RTN)
      if (row.raw.tenant_id === tenantId && row.raw.CO_BOOK === 'R63' && row.raw.SR_NO === '17') {
        row.raw.HM_ID = null;
        row.raw.ITM_REMARK = '';
      }
    expect(after).toEqual(before);
    expect((await read()).version).toBe(r.json().version);
  });
  it('rejects stale and cross-book or cross-tenant versions without losing the winning edit', async () => {
    const dto = await read();
    const winning = await call(
      'PUT',
      endpoint('incoming-metadata'),
      patch(dto.version, dto.lines[0].identity, { huid: 'WINNER' }),
    );
    expect(winning.statusCode, winning.body).toBe(200);
    const before = await businessSnapshot();
    for (const [url, role] of [
      [endpoint('incoming-metadata'), 'edit'],
      [endpoint('incoming-metadata', { coBook: 'R64' }), 'edit'],
      [endpoint('incoming-metadata'), 'other'],
    ] as const) {
      const stale = await call(
        'PUT',
        url,
        patch(dto.version, dto.lines[0].identity, { huid: 'LOSER' }),
        role,
      );
      expect(stale.statusCode, stale.body).toBe(409);
    }
    expect(await businessSnapshot()).toEqual(before);
  });
  it('allows only one winner for two actual equal-token concurrent updates', async () => {
    const dto = await read();
    const responses = await Promise.all(
      ['ONE', 'TWO'].map((huid) =>
        call(
          'PUT',
          endpoint('incoming-metadata'),
          patch(dto.version, dto.lines[0].identity, { huid }),
        ),
      ),
    );
    expect(responses.map((r) => r.statusCode).sort()).toEqual([200, 409]);
    expect(['ONE', 'TWO']).toContain((await read()).lines[0].raw.HM_ID);
  });
  it('rejects missing tokens, unknown/financial/hidden patches, explicit null and forged identity', async () => {
    const dto = await read();
    const before = await businessSnapshot();
    for (const payload of [
      { lines: [] },
      { version: dto.version, discountAmount: 1 },
      patch(dto.version, dto.lines[0].identity, { netAmount: 1 }),
      patch(dto.version, dto.lines[0].identity, { designImageId: 'OTHER' }),
      patch(dto.version, dto.lines[0].identity, { huid: null }),
      patch(dto.version, { ...dto.lines[0].identity, srNo: '999' }, { huid: 'WRONG' }),
    ]) {
      const r = await call('PUT', endpoint('incoming-metadata'), payload);
      expect([400, 409, 422], r.body).toContain(r.statusCode);
    }
    expect(await businessSnapshot()).toEqual(before);
  });
  it('distinguishes an explicit clear from an omitted field', async () => {
    const dto = await read();
    const r = await call(
      'PUT',
      endpoint('incoming-metadata'),
      patch(dto.version, dto.lines[1].identity, { huid: '' }),
    );
    expect(r.statusCode, r.body).toBe(200);
    expect(r.json().lines[1].raw).toMatchObject({
      HM_ID: '',
      ITM_REMARK: 'Second',
      DESIGN_IMG_ID: 'N',
    });
    expect(r.json().lines[0].raw.HM_ID).toBeNull();
  });
});
