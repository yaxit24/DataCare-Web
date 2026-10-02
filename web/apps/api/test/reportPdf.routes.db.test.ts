import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { PdfRendererBusyError, type PdfRenderer } from '../src/modules/reports/render.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N54 milestone 1 / G32 over HTTP and the real database.
 *  - `POST /render/pdf` (any signed-in user, arbitrary HTML into Chromium) is gone.
 *  - Report and estimate PDFs are built by the server from its own data. Printing needs the print right on the
 *    report's own form.
 *  - The estimate PDF accepts only the estimate's typed fields; HTML in the body is refused, and the body is capped.
 * A capturing renderer stands in for Chromium here (the real renderer is covered by pdfRenderer.chromium.test.ts)
 * so the test can read exactly what would be printed.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'report-pdf-route-db';
const PASSWORD = 'Report-Pdf-Route!2026';
const SECRET = 'report-pdf-route-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

class CapturingRenderer implements PdfRenderer {
  readonly html: string[] = [];
  async render(html: string): Promise<Buffer> {
    this.html.push(html);
    return Buffer.from('%PDF-1.4\n%captured\n%%EOF');
  }
}

(enabled ? describe : describe.skip)('N54 server-built PDFs', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let busyApp: FastifyInstance;
  const renderer = new CapturingRenderer();
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const login = async (target: FastifyInstance, name: string) => {
    const response = await target.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    return (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };
  const as = (user: string, target = app) => ({
    get: (url: string) =>
      target.inject({ method: 'GET', url, headers: { cookie: cookies[user]! } }),
    post: (url: string, payload: unknown) =>
      target.inject({
        method: 'POST',
        url,
        headers: { cookie: cookies[user]!, 'content-type': 'application/json' },
        payload: typeof payload === 'string' ? payload : JSON.stringify(payload),
      }),
  });
  const estimate = {
    acCode: 'CUST01',
    acName: 'Mrs <Shah>',
    taxRatePct: 3,
    interState: false,
    lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 5, netWt: 5, touch: 91.6, rate: 6000 }],
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `UPDATE "CO_MAST" SET "CO_NAME"='N54 Test Jewellers' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','CUST01','Asha <b>Retail</b>','10')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","TOT_AMT","NET_AMT")
       VALUES ($1,'01','01',$2,'SL','00001',$3::date,'CUST01','Asha <b>Retail</b>',30900,30000)`,
      tenantId,
      YEAR,
      DAY,
    );
    for (const [name, print] of [
      ['printer', 'Y'],
      ['viewer', 'N'],
    ] as const) {
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        tenantId,
        name,
        await hashPassword(PASSWORD),
      );
      for (const [mainMenu, subMenu] of [
        ['Reports', 'Sales Register'],
        ['Reports', 'Account Ledger'],
        ['Sales', 'Estimate'],
      ])
        await exec(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES($1,'01','01',$2,$3,$4,'Y','Y','Y',$5)`,
          tenantId,
          name,
          mainMenu,
          subMenu,
          print,
        );
    }
    app = await buildApp({
      prisma: runtime,
      secret: SECRET,
      secureCookies: false,
      pdfRenderer: renderer,
    });
    busyApp = await buildApp({
      prisma: runtime,
      secret: SECRET,
      secureCookies: false,
      pdfRenderer: {
        render: async () => {
          throw new PdfRendererBusyError();
        },
      },
    });
    cookies.printer = await login(app, 'printer');
    cookies.viewer = await login(app, 'viewer');
    cookies.busy = await login(busyApp, 'printer');
  });
  afterAll(async () => {
    if (app) await app.close();
    if (busyApp) await busyApp.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('no longer renders HTML posted by a client', async () => {
    const response = await as('printer').post('/render/pdf', { html: '<p>anything</p>' });
    expect(response.statusCode).toBe(404);
    expect(renderer.html).toEqual([]);
  });

  it('prints a report PDF only with the print right on that report', async () => {
    const refused = await as('viewer').get(`/reports/sales-register/export.pdf?coYear=${YEAR}`);
    expect(refused.statusCode, refused.body).toBe(403);
    expect(renderer.html).toEqual([]);

    const printed = await as('printer').get(`/reports/sales-register/export.pdf?coYear=${YEAR}`);
    expect(printed.statusCode, printed.body).toBe(200);
    expect(printed.headers['content-type']).toBe('application/pdf');
    expect(printed.headers['content-disposition']).toBe('inline; filename="sales-register.pdf"');
    expect(printed.rawPayload.subarray(0, 5).toString('latin1')).toBe('%PDF-');
    const html = renderer.html.at(-1)!;
    // Built on the server: the session company's own name, the desktop form's title, the stored row - escaped.
    expect(html).toContain('N54 Test Jewellers');
    expect(html).toContain('<h1>Sales Register</h1>');
    expect(html).toContain('00001');
    expect(html).toContain('Asha &lt;b&gt;Retail&lt;/b&gt;');
    expect(html).not.toContain('<b>Retail</b>');
  });

  it('prints the account ledger, whose screen carries the account in the path', async () => {
    const printed = await as('printer').get(
      `/reports/account-ledger/CUST01/export.pdf?coYear=${YEAR}`,
    );
    expect(printed.statusCode, printed.body).toBe(200);
    expect(printed.headers['content-disposition']).toBe('inline; filename="account-ledger.pdf"');
    expect(renderer.html.at(-1)).toContain('<h1>Account Ledger</h1>');
    const refused = await as('viewer').get(
      `/reports/account-ledger/CUST01/export.pdf?coYear=${YEAR}`,
    );
    expect(refused.statusCode).toBe(403);
  });

  it('refuses a report the server does not know', async () => {
    const response = await as('printer').get(`/reports/not-a-report/export.pdf?coYear=${YEAR}`);
    expect(response.statusCode).toBe(403);
    expect(response.json()).toMatchObject({ error: 'forbidden', form: 'unresolved' });
  });

  it('builds the estimate PDF from typed input and refuses HTML or unknown fields', async () => {
    const before = renderer.html.length;
    const printed = await as('printer').post('/estimate/pdf', estimate);
    expect(printed.statusCode, printed.body).toBe(200);
    const html = renderer.html.at(-1)!;
    expect(html).toContain('<h1>N54 Test Jewellers</h1>');
    expect(html).toContain('Mrs &lt;Shah&gt;');
    expect(html).toContain('<td>GOLD</td>');

    for (const [payload, fields] of [
      [{ ...estimate, html: '<script>alert(1)</script>' }, ['html']],
      [{ ...estimate, lines: [{ ...estimate.lines[0], note: '<img>' }] }, ['lines[0].note']],
      [{ ...estimate, lines: [{ ...estimate.lines[0], netWt: 'five' }] }, ['lines[0].netWt']],
      [{ ...estimate, lines: 'GOLD' }, ['lines']],
    ] as const) {
      const refused = await as('printer').post('/estimate/pdf', payload);
      expect(refused.statusCode, JSON.stringify(payload)).toBe(400);
      expect(refused.json()).toEqual({ error: 'invalid-request', fields });
    }
    const viewer = await as('viewer').post('/estimate/pdf', estimate);
    expect(viewer.statusCode).toBe(403);
    expect(renderer.html.length).toBe(before + 1);
  });

  it('caps the estimate PDF request at 64 KB', async () => {
    const big = JSON.stringify({ ...estimate, acName: 'x'.repeat(70 * 1024) });
    const response = await as('printer').post('/estimate/pdf', big);
    expect(response.statusCode).toBe(413);
  });

  it('answers a busy renderer with a retryable 503', async () => {
    const response = await as('busy', busyApp).get(
      `/reports/sales-register/export.pdf?coYear=${YEAR}`,
    );
    expect(response.statusCode).toBe(503);
    expect(response.headers['retry-after']).toBe('2');
    expect(response.json()).toEqual({ error: 'pdf-renderer-busy', retryable: true });
  });
});
