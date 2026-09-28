import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'lot-route-round3';
const password = 'Lot-read-fixture!2026';
(enabled ? describe : describe.skip)('lot Setting read HTTP integration', () => {
  let owner: PrismaClient, runtime: PrismaClient, app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const clean = async () => {
    for (const table of [
      'audit_log',
      'auth_session',
      'MFG_IDTL',
      'MFG_DETL',
      'MFG_DATA',
      'MFG_MAST',
      'USER_SET',
      'LOGIN_MAST',
      'BOOK_DATA',
      'AC_MAST',
      'YEAR_MAST',
      'LOCT_MAST',
      'CO_MAST',
    ])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  };
  const request = (user: string, url: string) =>
    app.inject({ method: 'GET', url, headers: { cookie: cookies[user]! } });
  const endpoints = (kind: 'issue' | 'receive') =>
    [
      'settings',
      'list?offset=0&limit=1',
      'sources?offset=0&limit=1&sourceBook=LSI&acCode=TOURAC',
      '1',
    ].map(
      (path) =>
        `/mfg/lot/${kind}/${path}${path.includes('?') ? '&' : '?'}coBook=${kind === 'issue' ? 'LSI' : 'LSR'}`,
    );
  beforeAll(async () => {
    for (const name of ['DATABASE_URL', 'MIGRATE_DATABASE_URL'])
      if (new URL(process.env[name] ?? 'invalid:').port !== '55433')
        throw new Error('Use isolated55433 for lot route fixtures.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean();
    const sql = (query: string, ...values: unknown[]) =>
      owner.$executeRawUnsafe(query, tenantId, ...values);
    await sql(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE")VALUES($1,'01','Lot route fixture','01')`,
    );
    await sql(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME")VALUES($1,'01','01','Main')`,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")VALUES($1,'01','2024-2025','2024-04-01','2025-03-31')`,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")VALUES($1,'01','01','TOURAC','Lot fixture karigar')`,
    );
    for (const [book, family, direction, stage] of [
      ['LSI', 'MFG STNG ISU', 'O', '71'],
      ['LSR', 'MFG STNG REC', 'I', '72'],
      ['LS2', 'MFG STNG ISU', 'O', '73'],
    ] as const) {
      await sql(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_NAME","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")VALUES($1,'01','01',$2,$3,$4,$5,'Y','MFG_DATA')`,
        book,
        family,
        `Custom ${book}`,
        direction,
      );
      await sql(
        `INSERT INTO "MFG_MAST"(tenant_id,"CO_CODE","SM_MAIN_CODE","CO_BOOK","ENTRY_TYPE","LAST_TRAN","IN_OUT")VALUES($1,'01',$2,$3,'S','S',$4)`,
        stage,
        book,
        direction,
      );
      if (book === 'LS2') continue;
      await sql(
        `INSERT INTO "MFG_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","BILL_NO","NET_AMT")VALUES($1,'01','01','2024-2025',$2,'00001','2024-07-01','TOURAC','REF%_1',9999999999999999.99)`,
        book,
      );
      await sql(
        `INSERT INTO "MFG_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","IT_CODE","LOT_NO")VALUES($1,'01','01','2024-2025',$2,'00001',17,42,'GOLD','PARENT')`,
        book,
      );
      await sql(
        `INSERT INTO "MFG_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","ITM_LOT")VALUES($1,'01','01','2024-2025',$2,'00001',17,9,'STONE','CHILD9')`,
        book,
      );
    }
    const hash = await hashPassword(password);
    for (const [user, menus] of [
      ['setting-issue', ['Setting Isu']],
      ['setting-receive', ['Setting Rec']],
      ['generic-mfg', ['MFG Issue', 'MFG Receive']],
    ] as const) {
      await sql(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")VALUES($1,'01',$2,$3,'USER','N','N','N','N')`,
        user,
        hash,
      );
      for (const menu of menus)
        await sql(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")VALUES($1,'01','01',$2,'Manufacturing',$3,'Y','N','N','N')`,
          user,
          menu,
        );
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'lot-route-secret-over-thirty-two-characters-2026',
      secureCookies: false,
    });
    for (const user of ['setting-issue', 'setting-receive', 'generic-mfg']) {
      const login = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: '2024-2025', loginName: user, password },
      });
      expect(login.statusCode, login.body).toBe(200);
      const headers = login.headers['set-cookie'];
      cookies[user] = (Array.isArray(headers) ? headers : [headers ?? ''])
        .map((h) => h.split(';', 1)[0])
        .join('; ');
    }
  });
  afterAll(async () => {
    await app?.close();
    if (owner) await clean();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });
  it('serves all eight GET paths with their exact Setting view permission and canonical HTTP pagination', async () => {
    for (const kind of ['issue', 'receive'] as const) {
      for (const url of endpoints(kind)) {
        const response = await request(`setting-${kind}`, url);
        expect(response.statusCode, `${url}: ${response.body}`).toBe(200);
      }
      const doc = (await request(`setting-${kind}`, endpoints(kind)[3]!)).json();
      expect(doc.header.NET_AMT).toBe('9999999999999999.99');
      expect(doc.components).toMatchObject([{ SR_NO: '17', ISR_NO: '9', ITM_LOT: 'CHILD9' }]);
      expect(doc.settings.writes).toBe(false);
    }
  });
  it('does not grant Setting access through generic MFG permissions or the other Setting operation', async () => {
    for (const kind of ['issue', 'receive'] as const)
      for (const url of endpoints(kind)) {
        expect((await request('generic-mfg', url)).statusCode, url).toBe(403);
        expect(
          (await request(kind === 'issue' ? 'setting-receive' : 'setting-issue', url)).statusCode,
          url,
        ).toBe(403);
      }
  });
  it('rejects wrong families, missing books, foreign scope and malformed pagination; missing exact voucher is404', async () => {
    expect((await request('setting-issue', '/mfg/lot/issue/1?coBook=LS2')).statusCode).toBe(404);
    expect((await request('setting-issue', '/mfg/lot/issue/999?coBook=LSI')).statusCode).toBe(404);
    for (const suffix of ['settings', 'list', 'sources', '1']) {
      expect(
        (await request('setting-issue', `/mfg/lot/issue/${suffix}?coBook=LSR`)).statusCode,
      ).toBe(400);
      // Shared businessScope middleware rejects unavailable books and session-scope changes
      // before the lot handler, using its established 409 ScopeError contract.
      const unavailableBook = await request('setting-issue', `/mfg/lot/issue/${suffix}?coBook=ZZZ`);
      expect(unavailableBook.statusCode).toBe(409);
      expect(unavailableBook.json()).toEqual({ error: 'book-unavailable' });
      for (const foreignScope of ['coCode=02', 'lcCode=02', 'coYear=2023-2024']) {
        const mismatch = await request(
          'setting-issue',
          `/mfg/lot/issue/${suffix}?coBook=LSI&${foreignScope}`,
        );
        expect(mismatch.statusCode).toBe(409);
        expect(mismatch.json()).toEqual({ error: 'scope-mismatch' });
      }
    }
    for (const page of [
      'offset=-1',
      'offset=01',
      'limit=0',
      'limit=101',
      'limit=1.5',
      'limit=abc',
      'limit=',
    ])
      expect(
        (await request('setting-issue', `/mfg/lot/issue/list?coBook=LSI&${page}`)).statusCode,
        page,
      ).toBe(400);
  });
  it('opens exact imported references and maps malformed read identifiers to400', async () => {
    for (const no of ['1', '123456', 'AB123456'])
      await owner.$executeRawUnsafe(
        `INSERT INTO "MFG_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DESC") VALUES($1,'01','01','2024-2025','LSI',$2,$3)`,
        tenantId,
        no,
        `Exact ${no}`,
      );
    try {
      for (const no of ['1', '123456', 'AB123456']) {
        const response = await request('setting-issue', `/mfg/lot/issue/${no}?coBook=LSI`);
        expect(response.statusCode, response.body).toBe(200);
        expect(response.json().header.VCH_NO).toBe(no);
        expect(response.json().components).toEqual([]);
      }
      const padded = await request('setting-issue', '/mfg/lot/issue/00001?coBook=LSI');
      expect(padded.statusCode).toBe(200);
      expect(padded.json().components).toHaveLength(1);
      for (const no of ['123456789', 'A%09B', '%20']) {
        const invalid = await request('setting-issue', `/mfg/lot/issue/${no}?coBook=LSI`);
        expect(invalid.statusCode, invalid.body).toBe(400);
        expect(invalid.json().error).toBe('MfgLotValidationError');
      }
    } finally {
      await owner.$executeRawUnsafe(
        `DELETE FROM "MFG_DATA" WHERE tenant_id=$1 AND "VCH_NO" IN ('1','123456','AB123456')`,
        tenantId,
      );
    }
  });
  it('leaves lot mutation URLs unavailable and saved values intact for view-only users', async () => {
    for (const kind of ['issue', 'receive'] as const)
      for (const method of ['POST', 'PUT', 'DELETE'] as const) {
        const response = await app.inject({
          method,
          url: `/mfg/lot/${kind}/1?coBook=${kind === 'issue' ? 'LSI' : 'LSR'}`,
          headers: { cookie: cookies[`setting-${kind}`]! },
          ...(method === 'DELETE' ? {} : { payload: { lines: [] } }),
        });
        expect(response.statusCode, response.body).toBe(404);
      }
    const response = await request('setting-issue', '/mfg/lot/issue/1?coBook=LSI');
    expect(response.statusCode).toBe(200);
    expect(response.json().components).toHaveLength(1);
  });
});
