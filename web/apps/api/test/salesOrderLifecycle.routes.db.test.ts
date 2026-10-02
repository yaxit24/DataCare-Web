import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
db('ordinary Sales Order configured HTTP lifecycle', () => {
  const tenantId = 'sales-order-http-r4';
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const roles = [
    ['all', 'Sales', 'Sales Order', 'Y', 'Y', 'Y', 'Y'],
    ['view', 'Sales', 'Sales Order', 'Y', 'N', 'N', 'N'],
    ['edit', 'Sales', 'Sales Order', 'Y', 'Y', 'N', 'Y'],
    ['delete', 'Sales', 'Sales Order', 'Y', 'N', 'Y', 'Y'],
    ['tour', 'Karigar', 'Tour Order', 'Y', 'Y', 'Y', 'Y'],
  ];
  const sql = (query: string, ...args: unknown[]) =>
    owner.$executeRawUnsafe(query, tenantId, ...args);
  const scope = (book = 'S51') =>
    new URLSearchParams({
      coCode: '01',
      lcCode: '01',
      coYear: '2024-2025',
      coBook: book,
    }).toString();
  const path = (suffix = '', book = 'S51') => `/sales-orders${suffix}?${scope(book)}`;
  const request = (
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    url: string,
    payload?: any,
    role = 'all',
  ) =>
    app.inject({
      method,
      url,
      headers: { cookie: cookies[role] },
      ...(payload === undefined ? {} : { payload }),
    });
  const draft = (label = 'HTTP Customer') => ({
    acCode: 'PARTY',
    acName: label,
    billNo: 'HTTP-01',
    vchDate: '2024-07-10',
    vchTime: '12:34:56.123456',
    advanceAmount: 0,
    taxRatePct: 0,
    lines: [
      {
        itCode: 'GL',
        designNo: 'HTTP-D1',
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
  const clean = async () => {
    for (const table of [
      'audit_log',
      'auth_session',
      'DELETE_DATA',
      'ROJ_MEL_DATA',
      'AC_DATA',
      'SL_ORD_ADJ',
      'SL_ORD_IDTL',
      'SL_ORD_DETL',
      'SL_ORD_DATA',
      'SL_PR_DETL',
      'MAIN_STOCK',
      'UPI_DATA',
      'TEMP_BOOK_DATA',
      'CO_SET_NEW',
      'CO_SET',
      'ITEM_MAST',
      'AC_MAST',
      'USER_SET',
      'LOGIN_MAST',
      'BOOK_DATA',
      'YEAR_MAST',
      'LOCT_MAST',
      'CO_MAST',
    ])
      await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`);
  };
  const snapshot = async () => {
    const result: Record<string, string> = {};
    for (const table of [
      'SL_ORD_DATA',
      'SL_ORD_DETL',
      'SL_ORD_IDTL',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'TEMP_BOOK_DATA',
      'DELETE_DATA',
    ]) {
      const rows: any[] = await owner.$queryRawUnsafe(
        `SELECT COALESCE(jsonb_agg(to_jsonb(t) ORDER BY to_jsonb(t)::text),'[]'::jsonb)::text AS data FROM "${table}" t WHERE tenant_id=$1`,
        tenantId,
      );
      result[table] = rows[0].data;
    }
    return result;
  };
  const read = async (book = 'S51') => {
    const response = await request('GET', path('/00001', book));
    expect(response.statusCode, response.body).toBe(200);
    return response.json();
  };
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean();
    await sql(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES($1,'01','Sales HTTP','01')`,
    );
    await sql(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES($1,'01','01','Main')`,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01','2024-2025','2024-04-01','2025-03-31')`,
    );
    await sql(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_ROF") VALUES($1,'01',2)`);
    await sql(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,'01','N')`);
    await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
      VALUES($1,'01','01','S51','Sales HTTP One','SORD','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL'),
      ($1,'01','01','S52','Sales HTTP Two','SORD','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL'),
      ($1,'01','01','T51','Tour HTTP','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA','SL_ORD_DETL')`);
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PARTY','HTTP Customer'),($1,'01','01','CASH','Cash')`,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES($1,'01','GL','Gold','G')`,
    );
    const password = 'Sales-HTTP-Test!2026';
    const hash = await hashPassword(password);
    for (const [name, main, sub, view, edit, remove, globalUpdate] of roles) {
      await sql(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES($1,'01',$2,$3,'USER',$4,'Y','Y','N')`,
        name,
        hash,
        globalUpdate,
      );
      await sql(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES($1,'01','01',$2,$3,$4,$5,$6,$7,'Y')`,
        name,
        main,
        sub,
        view,
        edit,
        remove,
      );
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'sales-order-http-test-secret-longer-than-thirty-two-characters',
      secureCookies: false,
    });
    for (const [loginName] of roles) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: '2024-2025', loginName, password },
      });
      expect(response.statusCode, response.body).toBe(200);
      const header = response.headers['set-cookie'];
      cookies[loginName!] = (Array.isArray(header) ? header : [header ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }
    for (const book of ['S51', 'S52']) {
      const created = await request('POST', path('', book), draft(`Customer ${book}`));
      expect(created.statusCode, created.body).toBe(201);
      expect(created.json().vchNo).toBe(1);
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await clean();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('reads configuration with Sales rights and the selected historical financial year', async () => {
    for (const role of ['all', 'view', 'edit', 'delete']) {
      const response = await request('GET', path('/configuration'), undefined, role);
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toMatchObject({
        fiscalOpeningDate: '2024-04-01',
        fiscalClosingDate: '2025-03-31',
        priorYearConfirmationSupported: false,
        labourIncludesGhat: false,
        labourRateDecimals: 2,
      });
    }
    expect((await request('GET', path('/configuration'), undefined, 'tour')).statusCode).toBe(403);
  });
  it('isolates identical voucher numbers in two explicitly configured non-SOR books', async () => {
    const a = await read(),
      b = await read('S52');
    expect(a).toMatchObject({
      coBook: 'S51',
      coYear: '2024-2025',
      acName: 'Customer S51',
      vchDate: '2024-07-10',
    });
    expect(b).toMatchObject({ coBook: 'S52', acName: 'Customer S52' });
    const list = await request('GET', path());
    expect(list.statusCode, list.body).toBe(200);
    expect(list.json()).toHaveLength(1);
    expect(list.json()[0]).toMatchObject({ book: 'S51', acName: 'Customer S51' });
  });
  it('requires owning Sales update/delete rights and preserves data after denied requests', async () => {
    const original = await snapshot(),
      saved = await read();
    const payload = { ...saved, expectedVersion: saved.version };
    for (const role of ['view', 'delete', 'tour'])
      expect((await request('PUT', path('/00001'), payload, role)).statusCode).toBe(403);
    for (const role of ['view', 'edit', 'tour'])
      expect(
        (await request('DELETE', path('/00001'), { expectedVersion: saved.version }, role))
          .statusCode,
      ).toBe(403);
    for (const role of ['tour'])
      expect((await request('POST', path(), draft(), role)).statusCode).toBe(403);
    expect(await snapshot()).toEqual(original);
  });
  it('refuses missing or malformed expected versions before editing or deleting', async () => {
    const original = await snapshot(),
      saved = await read();
    for (const expectedVersion of [undefined, '', 'old', 'g'.repeat(64)]) {
      for (const method of ['PUT', 'DELETE'] as const) {
        const response = await request(
          method,
          path('/00001'),
          method === 'PUT' ? { ...saved, expectedVersion } : { expectedVersion },
        );
        expect(response.statusCode, response.body).toBe(400);
        expect(response.json().message).toContain('version');
      }
    }
    expect(await snapshot()).toEqual(original);
  });
  it('rejects incomplete parent/component arrays without dropping saved data', async () => {
    const original = await snapshot(),
      saved = await read();
    for (const method of ['POST', 'PUT'] as const) {
      for (const shape of ['missing-lines', 'missing-components']) {
        const payload: any = { ...draft(), expectedVersion: saved.version };
        if (shape === 'missing-lines') delete payload.lines;
        else delete payload.lines[0].components;
        const response = await request(method, path(method === 'PUT' ? '/00001' : ''), payload);
        expect(response.statusCode, response.body).toBe(400);
      }
    }
    expect(await snapshot()).toEqual(original);
  });
  it('rejects stale versions without changing any order, ledger or numbering row', async () => {
    const original = await snapshot(),
      saved = await read();
    for (const method of ['PUT', 'DELETE'] as const) {
      const response = await request(
        method,
        path('/00001'),
        method === 'PUT'
          ? { ...saved, expectedVersion: '0'.repeat(64) }
          : { expectedVersion: '0'.repeat(64) },
      );
      expect(response.statusCode, response.body).toBe(409);
      expect(response.json().error).toBe('SalesOrderConflictError');
    }
    expect(await snapshot()).toEqual(original);
  });
  it('rejects missing, malformed and impossible dates without allocating or posting anything', async () => {
    const original = await snapshot();
    for (const vchDate of [undefined, '', 'invalid', '2024-02-30', '2024-07-10T00:00:00Z']) {
      const response = await request('POST', path(), { ...draft(), vchDate });
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json().message).toContain('vchDate');
    }
    expect(await snapshot()).toEqual(original);
  });
  it('separates the unavailable desktop prior-year exception from invalid after-close dates', async () => {
    const original = await snapshot();
    const before = await request('POST', path(), { ...draft(), vchDate: '2024-03-31' });
    expect(before.statusCode, before.body).toBe(422);
    expect(before.json().code).toBe('prior-year-confirmation-unavailable');
    const after = await request('POST', path(), { ...draft(), vchDate: '2025-04-01' });
    expect(after.statusCode, after.body).toBe(400);
    expect(after.json().message).toContain('closing date');
    expect(await snapshot()).toEqual(original);
  });
  it('rejects a different book family and an unknown book instead of falling back to SOR', async () => {
    const original = await snapshot();
    for (const suffix of ['/configuration', '/00001', '']) {
      const wrong = await request('GET', path(suffix, 'T51'));
      expect(wrong.statusCode, wrong.body).toBe(400);
    }
    const create = await request('POST', path('', 'T51'), draft());
    expect(create.statusCode, create.body).toBe(400);
    const unknown = await request('GET', path('/configuration', 'M00'));
    expect(unknown.statusCode, unknown.body).toBe(409);
    expect(await snapshot()).toEqual(original);
  });
  it('does not let caller JSON bypass the Design Book source-selection contract', async () => {
    const original = await snapshot();
    const payload = draft();
    payload.lines[0]!.designImageId = 'UNPROVEN_MASTER';
    const response = await request('POST', path(), {
      ...payload,
      requireDesignSelection: false,
    });
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json().message).toMatch(/design/i);
    expect(await snapshot()).toEqual(original);
  });
  it('updates through PUT under Sales edit rights and rejects the previous version afterward', async () => {
    const saved = await read(),
      other = await read('S52');
    const updated = await request(
      'PUT',
      path('/00001'),
      { ...saved, expectedVersion: saved.version, billNo: 'HTTP-EDIT', dirtyFields: ['billNo'] },
      'edit',
    );
    expect(updated.statusCode, updated.body).toBe(200);
    const reopened = await read();
    expect(reopened.billNo).toBe('HTTP-EDIT');
    expect(reopened.vchTime).toBe(saved.vchTime);
    expect(reopened.version).not.toBe(saved.version);
    expect(await read('S52')).toEqual(other);
    expect(
      (await request('DELETE', path('/00001'), { expectedVersion: saved.version }, 'delete'))
        .statusCode,
    ).toBe(409);
  });
  it('deletes only the selected saved order with Sales delete rights and its current version', async () => {
    const saved = await read(),
      other = await read('S52');
    const removed = await request(
      'DELETE',
      path('/00001'),
      { expectedVersion: saved.version },
      'delete',
    );
    expect(removed.statusCode, removed.body).toBe(200);
    const list = await request('GET', path());
    expect(list.json()).toEqual([]);
    expect(await read('S52')).toEqual(other);
  });
  it('retains the desktop View permission to create while refusing later edit and delete', async () => {
    const created = await request('POST', path(), draft('View-created order'), 'view');
    expect(created.statusCode, created.body).toBe(201);
    const voucher = String(created.json().vchNo).padStart(5, '0');
    const loaded = await request('GET', path(`/${voucher}`), undefined, 'view');
    expect(loaded.statusCode, loaded.body).toBe(200);
    const saved = loaded.json();
    const before = await snapshot();
    expect(
      (
        await request(
          'PUT',
          path(`/${voucher}`),
          { ...saved, expectedVersion: saved.version },
          'view',
        )
      ).statusCode,
    ).toBe(403);
    expect(
      (await request('DELETE', path(`/${voucher}`), { expectedVersion: saved.version }, 'view'))
        .statusCode,
    ).toBe(403);
    expect(await snapshot()).toEqual(before);
  });
});
