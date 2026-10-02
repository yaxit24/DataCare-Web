import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedECreditNoteFixture } from './fixtures/eCreditNoteSeed.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/** X15: the E CRNT lifecycle through real HTTP, session scope and Transaction/E CrntNote rights. */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'e-crnt-route-db';
const PASSWORD = 'E-Crnt-Route-Test!2026';
const SECRET = 'e-crnt-route-test-signing-secret-over-thirty-two-characters';

(enabled ? describe : describe.skip)('X15 E CRNT HTTP lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const roles = [
    ['crn-all', 'Y', 'Y', 'Y', 'Y'],
    ['crn-view', 'Y', 'N', 'N', 'N'],
  ] as const;
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const qs = (book = '146') =>
    new URLSearchParams({
      coCode: '01',
      lcCode: '01',
      coYear: '2024-2025',
      coBook: book,
    }).toString();
  const request = (
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    url: string,
    payload?: unknown,
    role = 'crn-all',
  ) =>
    app.inject({
      method,
      url,
      headers: { cookie: cookies[role]! },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const draft = (overrides: Record<string, unknown> = {}) => ({
    coBook: '146',
    vchDate: '2024-06-10',
    partyCode: 'CUST01',
    billNo: 'HTTP-1',
    employeeCode: 'E01',
    cashAmount: 0,
    lines: [
      {
        itemCode: 'GOLD',
        pcs: 1,
        grossWt: 10,
        lessWt: 0.5,
        rate: 6000,
        rateType: 'G',
        labourType: 'G',
        labourRate: 500,
        otherAmount: 250,
        taxCode: '10',
      },
    ],
    ...overrides,
  });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedECreditNoteFixture(exec, tenantId);
    await exec(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'01','01','Main')`,
      tenantId,
    );
    const hash = await hashPassword(PASSWORD);
    for (const [name, view, edit, remove, print] of roles) {
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        tenantId,
        name,
        hash,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Transaction','E CrntNote',$3,$4,$5,$6)`,
        tenantId,
        name,
        view,
        edit,
        remove,
        print,
      );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const [loginName] of roles) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: '2024-2025', loginName, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const value = response.headers['set-cookie'];
      cookies[loginName] = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('creates, reopens, refuses a stale update, updates, prints and deletes over HTTP', async () => {
    const config = await request('GET', `/e-credit-notes/entry-config?${qs()}`);
    expect(config.statusCode, config.body).toBe(200);
    expect(config.json().taxCodes).toEqual([{ code: '10', name: 'GST 3%', percent: 3 }]);

    const created = await request('POST', `/e-credit-notes?${qs()}`, draft());
    expect(created.statusCode, created.body).toBe(201);
    expect(created.json()).toMatchObject({
      voucherNo: '00001',
      created: true,
      totals: { totalAmount: 64118, outstanding: 64118 },
    });
    const [header]: Array<{ MAIN_USER: string }> = await owner.$queryRawUnsafe(
      `SELECT "MAIN_USER" FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='146' AND "CO_YEAR"='2024-2025'`,
      tenantId,
    );
    expect(header!.MAIN_USER).toBe('crn-all');

    const entry = await request('GET', `/e-credit-notes/00001/entry?${qs()}`);
    expect(entry.statusCode, entry.body).toBe(200);
    const opened = entry.json();
    expect(opened).toMatchObject({ voucherNo: '00001', billNo: 'HTTP-1', irnLocked: false });

    const missing = await request('GET', `/e-credit-notes/00077/entry?${qs()}`);
    expect(missing.statusCode).toBe(404);

    // Another operator changes the voucher; the first operator's revision is now stale.
    const other = await request(
      'PUT',
      `/e-credit-notes/00001?${qs()}`,
      draft({ billNo: 'HTTP-2', expectedRevision: opened.revision }),
    );
    expect(other.statusCode, other.body).toBe(200);
    const stale = await request(
      'PUT',
      `/e-credit-notes/00001?${qs()}`,
      draft({ billNo: 'HTTP-3', expectedRevision: opened.revision }),
    );
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json()).toMatchObject({ error: 'EBillConflictError' });

    const invalid = await request('POST', `/e-credit-notes?${qs()}`, draft({ partyCode: '' }));
    expect(invalid.statusCode).toBe(400);
    expect(invalid.json().message).toBe('Please Insert Party and try');

    const print = await request('GET', `/e-credit-notes/00001/print?${qs()}&format=html`);
    expect(print.statusCode, print.body).toBe(200);
    expect(print.headers['content-type']).toContain('text/html');
    expect(print.body).toContain('Credit Note');
    expect(print.body).toContain('Credit Customer');
    expect(print.body).toContain('HTTP-2');
    // Saved taxable (item + labour + other = 62250), item name and the ISO business date are printed.
    expect(print.body).toContain('62,250.00');
    expect(print.body).toContain('Gold Ring');
    expect(print.body).toContain('2024-06-10');
    const duplicate = await request(
      'GET',
      `/e-credit-notes/00001/print?${qs()}&format=html&copy=D`,
    );
    expect(duplicate.statusCode, duplicate.body).toBe(200);
    expect(duplicate.body).toContain('DUPLICATE FOR SUPPLIER');
    expect(
      (await request('GET', `/e-credit-notes/00001/print?${qs()}&format=html&copy=X`)).statusCode,
    ).toBe(400);
    expect(
      (await request('GET', `/e-credit-notes/00001/print?${qs('147')}&format=html`)).statusCode,
    ).toBe(404);

    const reopened = (await request('GET', `/e-credit-notes/00001/entry?${qs()}`)).json();
    const removed = await request('DELETE', `/e-credit-notes/00001?${qs()}`, {
      expectedRevision: reopened.revision,
    });
    expect(removed.statusCode, removed.body).toBe(200);
    expect(removed.json()).toEqual({ deleted: true, voucherNo: '00001' });
    const [audit]: Array<{ DELETE_USER: string }> = await owner.$queryRawUnsafe(
      `SELECT "DELETE_USER" FROM "DELETE_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(audit!.DELETE_USER).toBe('crn-all');
  });

  it('enforces Transaction/E CrntNote rights for update, delete and print', async () => {
    const created = await request('POST', `/e-credit-notes?${qs()}`, draft());
    expect(created.statusCode, created.body).toBe(201);
    const vch = created.json().voucherNo;
    // TR_SL_EBILL checks rights only for edit, delete and print: adding a voucher needs form access
    // (authorizeForm grants create with FRM_VIEW, like the desktop).
    const viewerCreated = await request('POST', `/e-credit-notes?${qs()}`, draft(), 'crn-view');
    expect(viewerCreated.statusCode, viewerCreated.body).toBe(201);
    expect(
      (await request('PUT', `/e-credit-notes/${vch}?${qs()}`, draft(), 'crn-view')).statusCode,
    ).toBe(403);
    expect(
      (await request('DELETE', `/e-credit-notes/${vch}?${qs()}`, {}, 'crn-view')).statusCode,
    ).toBe(403);
    expect(
      (
        await request(
          'GET',
          `/e-credit-notes/${vch}/print?${qs()}&format=html`,
          undefined,
          'crn-view',
        )
      ).statusCode,
    ).toBe(403);
    const view = await request(
      'GET',
      `/e-credit-notes/${vch}/entry?${qs()}`,
      undefined,
      'crn-view',
    );
    expect(view.statusCode, view.body).toBe(200);
  });
});
