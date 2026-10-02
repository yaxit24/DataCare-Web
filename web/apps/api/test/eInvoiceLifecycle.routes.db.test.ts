import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { E_INVOICE_BOOK, seedEInvoiceFixture } from './fixtures/eCreditNoteSeed.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/** X15 continuation: E INVOICE over HTTP — rights, IRN lock, duplicate-IRN refusal and cancel. */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'e-invoice-route-db';
const PASSWORD = 'E-Invoice-Route-Test!2026';
const SECRET = 'e-invoice-route-test-signing-secret-over-thirty-two-characters';
const GSP_KEYS = [
  'GSP_ASPID',
  'GSP_PASSWORD',
  'GSP_GSTIN',
  'GSP_USER',
  'GSP_EINV_PWD',
  'GSP_SANDBOX',
];

(enabled ? describe : describe.skip)('X15 E INVOICE HTTP lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const saved = Object.fromEntries(['NODE_ENV', ...GSP_KEYS].map((k) => [k, process.env[k]]));
  const roles = [
    ['inv-all', 'Y', 'Y', 'Y', 'Y'],
    ['inv-view', 'Y', 'N', 'N', 'N'],
  ] as const;
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const qs = new URLSearchParams({
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: E_INVOICE_BOOK,
  }).toString();
  const request = (
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    url: string,
    payload?: unknown,
    role = 'inv-all',
  ) =>
    app.inject({
      method,
      url,
      headers: { cookie: cookies[role]! },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const draft = (overrides: Record<string, unknown> = {}) => ({
    vchDate: '2024-06-10',
    partyCode: 'CUST01',
    billNo: 'HTTP-INV',
    employeeCode: 'E01',
    tdsCode: '25',
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
    process.env.NODE_ENV = 'test';
    for (const key of GSP_KEYS) delete process.env[key];
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedEInvoiceFixture(exec, tenantId);
    // IRN payload identities (seller/buyer GSTIN, address, HSN).
    await exec(
      `UPDATE "CO_MAST" SET "CO_SNAME"='CJ',"CO_ADD1"='Ring Road',"CO_CITY"='Surat',"CO_PIN"='395003',
              "CO_STATE_CODE"='24',"CO_GST_NO"='24ABCDE1234F1Z5' WHERE tenant_id=$1`,
      tenantId,
    );
    await exec(
      `UPDATE "AC_MAST" SET "AC_GSTNO"='24AAAAA0000A1Z5',"AC_STATE"='24',"AC_CITY"='Surat',"AC_PIN"='395007',"AC_ADD1"='Buyer Lane'
        WHERE tenant_id=$1 AND "AC_CODE"='CUST01'`,
      tenantId,
    );
    await exec(
      `UPDATE "ITEM_MAST" SET "HSN_CODE"='711319',"UNIT_NAME"='GMS' WHERE tenant_id=$1`,
      tenantId,
    );
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
         VALUES($1,'01','01',$2,'Transaction','E Invoice',$3,$4,$5,$6)`,
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
    for (const [key, value] of Object.entries(saved)) {
      if (value === undefined) delete process.env[key];
      else process.env[key] = value;
    }
  });

  it('creates, registers an IRN, locks edit/delete, refuses a second IRN and unlocks after cancel', async () => {
    const created = await request('POST', `/e-invoices?${qs}`, draft());
    expect(created.statusCode, created.body).toBe(201);
    expect(created.json()).toMatchObject({
      voucherNo: '00001',
      // TDS round(62,250 x 1%) = round(622.5) = 622 (half-to-even); outstanding 64,118 - 622.
      totals: { totalAmount: 64118, tdsAmount: 622, outstanding: 63496 },
    });
    const browse = await request('GET', `/e-invoices?${qs}`);
    expect(browse.statusCode, browse.body).toBe(200);
    expect(browse.json().rows.map((r: any) => r.VCH_NO)).toEqual(['00001']);
    const print = await request('GET', `/e-invoices/00001/print?${qs}&format=html&copy=O`);
    expect(print.statusCode, print.body).toBe(200);
    expect(print.body).toContain('Tax Invoice');
    expect(print.body).toContain('ORIGINAL FOR RECIPIENT');

    const irn = await request('POST', `/e-invoices/00001/irn?${qs}`, {});
    expect(irn.statusCode, irn.body).toBe(201);
    expect(irn.json()).toMatchObject({ mode: 'fake-development' });
    const entry = (await request('GET', `/e-invoices/00001/entry?${qs}`)).json();
    expect(entry).toMatchObject({ irnLocked: true, registration: { irn: irn.json().irn } });

    const again = await request('POST', `/e-invoices/00001/irn?${qs}`, {});
    expect(again.statusCode).toBe(400);
    expect(again.json().message).toContain('Alrady Exciest');
    const blockedEdit = await request('PUT', `/e-invoices/00001?${qs}`, draft());
    expect(blockedEdit.statusCode).toBe(400);
    expect(blockedEdit.json().message).toContain('Irn No Is Genrate');
    const blockedDelete = await request('DELETE', `/e-invoices/00001?${qs}`, {});
    expect(blockedDelete.statusCode).toBe(400);

    const cancelled = await request('POST', `/e-invoices/00001/irn/cancel?${qs}`, {
      reason: '2',
      remark: 'test',
    });
    expect(cancelled.statusCode, cancelled.body).toBe(200);
    const reopened = (await request('GET', `/e-invoices/00001/entry?${qs}`)).json();
    expect(reopened.irnLocked).toBe(false);
    const edited = await request(
      'PUT',
      `/e-invoices/00001?${qs}`,
      draft({ billNo: 'HTTP-INV-2', expectedRevision: reopened.revision }),
    );
    expect(edited.statusCode, edited.body).toBe(200);
  });

  it('enforces Transaction/E Invoice rights and refuses credit-note routes on an invoice book', async () => {
    const created = await request('POST', `/e-invoices?${qs}`, draft({ billNo: 'RIGHTS' }));
    expect(created.statusCode, created.body).toBe(201);
    const vch = created.json().voucherNo;
    expect((await request('PUT', `/e-invoices/${vch}?${qs}`, draft(), 'inv-view')).statusCode).toBe(
      403,
    );
    expect((await request('DELETE', `/e-invoices/${vch}?${qs}`, {}, 'inv-view')).statusCode).toBe(
      403,
    );
    expect((await request('POST', `/e-invoices/${vch}/irn?${qs}`, {}, 'inv-view')).statusCode).toBe(
      403,
    );
    const wrongFamily = await request('GET', `/e-credit-notes/${vch}/entry?${qs}`);
    expect([400, 403]).toContain(wrongFamily.statusCode);
  });
});
