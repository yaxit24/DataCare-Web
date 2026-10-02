import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { invoiceData } from '../src/modules/sales/invoice.js';
import { purchaseBillData } from '../src/modules/purchase/purchaseBill.js';
import { financeVoucherData } from '../src/modules/finance/financeVoucher.js';
import { dhrnIssueData } from '../src/modules/dhrn/dhrnReceipt.js';
import { karigarIssueData } from '../src/modules/manufacturing/karigarVoucher.js';
import type { VoucherDocumentScope } from '../src/modules/documents/voucherDocument.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N31 / G01: every printable voucher reads by the COMPLETE desktop key.
 *
 * Desktop prints filter on CO_CODE, LC_CODE, CO_YEAR, CO_BOOK and VCH_NO (TR_SALE.cs:16475/16532,
 * TR_PURC.cs:14007). Voucher numbers restart per location, year and book, so the web readers — which
 * filtered on company, book and number, and read DETAIL rows without the year at all — could print another
 * branch's or another year's voucher, and mix the lines of several vouchers into one document.
 *
 * The fixture gives the SAME book and voucher number to six identities that differ in exactly one key part,
 * each with its own header text and line text, and asks each reader for each identity.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'doc-scope-parity';
const FOREIGN = 'doc-scope-foreign';

type Reader = (prisma: any, scope: VoucherDocumentScope) => Promise<any>;
const families: Array<{
  name: string;
  head: string;
  detl: string;
  detlText: string;
  read: Reader;
}> = [
  { name: 'sale', head: 'SL_DATA', detl: 'SL_DETL', detlText: 'ITM_REMARK', read: invoiceData },
  {
    name: 'purchase',
    head: 'PR_DATA',
    detl: 'PR_DETL',
    detlText: 'IT_DESC',
    read: purchaseBillData,
  },
  {
    name: 'receipt',
    head: 'CASH_DATA',
    detl: 'PAY_DETL',
    detlText: 'IT_REMARK',
    read: (p, s) => financeVoucherData(p, 'receipt', s),
  },
  {
    name: 'payment',
    head: 'PAY_DATA',
    detl: 'PAY_DETL',
    detlText: 'IT_REMARK',
    read: (p, s) => financeVoucherData(p, 'payment', s),
  },
  {
    name: 'dhiran',
    head: 'DHRN_ISU_DATA',
    detl: 'DHRN_ISU_DETL',
    detlText: 'IT_DESC',
    read: dhrnIssueData,
  },
  {
    name: 'karigar',
    head: 'KR_DATA',
    detl: 'KR_DETL',
    detlText: 'IT_DESC',
    read: karigarIssueData,
  },
];

(enabled ? describe : describe.skip)('printable vouchers read by the complete desktop key', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const base: VoucherDocumentScope = {
    tenantId: TENANT,
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: 'D01',
    vchNo: '00001',
  };
  const dimensions: VoucherDocumentScope[] = [
    base,
    { ...base, tenantId: FOREIGN },
    { ...base, coCode: '02' },
    { ...base, lcCode: '02' },
    { ...base, coYear: '2025-2026' },
    { ...base, coBook: 'D02' },
  ];
  const tables = [...new Set(families.flatMap((f) => [f.head, f.detl]))];
  const cleanup = async () => {
    for (const table of [...tables, 'AC_MAST', 'CO_MAST'])
      await owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
        TENANT,
        FOREIGN,
      );
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    await cleanup();
    for (const [index, s] of dimensions.entries()) {
      const key = [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook, s.vchNo];
      for (const f of families) {
        await owner.$executeRawUnsafe(
          `INSERT INTO "${f.head}"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME")
           VALUES ($1,$2,$3,$4,$5,$6,'PARTY',$7)`,
          ...key,
          `${f.name} header ${index}`,
        );
      }
      // PAY_DETL carries the lines of both receipts and payments, so each detail table is seeded once.
      for (const detl of new Set(families.map((f) => f.detl))) {
        const family = families.find((f) => f.detl === detl)!;
        await owner.$executeRawUnsafe(
          `INSERT INTO "${detl}"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","${family.detlText}")
           VALUES ($1,$2,$3,$4,$5,$6,1,$7)`,
          ...key,
          `${detl} line ${index}`,
        );
      }
      await owner.$executeRawUnsafe(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,$3) ON CONFLICT DO NOTHING`,
        s.tenantId,
        s.coCode,
        `Company ${s.tenantId}/${s.coCode}`,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
         VALUES ($1,$2,$3,'PARTY',$4) ON CONFLICT DO NOTHING`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        `Party ${s.tenantId}/${s.coCode}/${s.lcCode}`,
      );
    }
  });
  afterAll(async () => {
    await cleanup();
    await runtime.$disconnect();
    await owner.$disconnect();
  });

  for (const f of families) {
    it(`${f.name}: returns only the requested header, lines, company and location party`, async () => {
      for (const [index, s] of dimensions.entries()) {
        const doc = await f.read(runtime, s);
        expect(doc?.header.AC_NAME, JSON.stringify(s)).toBe(`${f.name} header ${index}`);
        expect(doc?.lines.map((line: any) => line[f.detlText])).toEqual([
          `${f.detl} line ${index}`,
        ]);
        expect(doc?.company.CO_NAME).toBe(`Company ${s.tenantId}/${s.coCode}`);
        expect(doc?.party.AC_NAME).toBe(`Party ${s.tenantId}/${s.coCode}/${s.lcCode}`);
      }
      expect(await f.read(runtime, { ...base, lcCode: '99' })).toBeNull();
      expect(await f.read(runtime, { ...base, vchNo: '00002' })).toBeNull();
    });

    it(`${f.name}: refuses an incomplete key before touching the database`, async () => {
      for (const field of Object.keys(base) as Array<keyof VoucherDocumentScope>) {
        await expect(f.read({}, { ...base, [field]: '' })).rejects.toMatchObject({
          name: 'DocumentScopeError',
          field,
        });
      }
    });
  }
});

(enabled ? describe : describe.skip)(
  'print routes refuse a missing book instead of defaulting',
  () => {
    const tenantId = 'doc-scope-route';
    const PASSWORD = 'Doc-Scope-Route!2026';
    const now = new Date();
    const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
    const YEAR = `${startYear}-${startYear + 1}`;
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let cookie = '';
    const wipe = async () => {
      const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const row of rows)
        await owner.$executeRawUnsafe(
          `DELETE FROM "${row.table_name}" WHERE tenant_id=$1`,
          tenantId,
        );
    };
    const get = (url: string) => app.inject({ method: 'GET', url, headers: { cookie } });

    beforeAll(async () => {
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      // The same voucher number in the session's location and in another location of the same book. The
      // party code has no AC_MAST row, so the document prints the header's own name for each voucher.
      for (const [lc, name] of [
        ['01', 'Branch one sale'],
        ['02', 'Branch two sale'],
      ]) {
        await owner.$executeRawUnsafe(
          `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME","NET_AMT")
         VALUES ($1,'01',$2,$3,'SL','00001','NOPARTY9',$4,100)`,
          tenantId,
          lc,
          YEAR,
          name,
        );
      }
      await owner.$executeRawUnsafe(
        `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME","NET_AMT","TOT_AMT")
         VALUES ($1,'01','01',$2,'PR','00001','SUPP','Purchase supplier',100,100),
                ($1,'01','01',$2,'PRT','00001','SUPP','Return supplier',50,50)`,
        tenantId,
        YEAR,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "KR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME","NET_AMT")
         VALUES ($1,'01','01',$2,'KRI','00001','KAR','Karigar party',25)`,
        tenantId,
        YEAR,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01','printer',$2,'ADMIN','Y','Y','Y','N')`,
        tenantId,
        await hashPassword(PASSWORD),
      );
      app = await buildApp({
        prisma: runtime,
        secret: 'doc-scope-route-test-signing-secret-over-thirty-two-chars',
        secureCookies: false,
      });
      const login = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: {
          coCode: '01',
          lcCode: '01',
          coYear: YEAR,
          loginName: 'printer',
          password: PASSWORD,
        },
      });
      expect(login.statusCode, login.body).toBe(200);
      const value = login.headers['set-cookie'];
      cookie = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    });
    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('a print request without a book is a 400 that names the missing field', async () => {
      for (const url of [
        '/sales/invoice?vchNo=1&format=html',
        '/sales/credit-note?vchNo=1&format=html',
        '/sales/quotation?vchNo=1&format=html',
        '/purchases/invoice?vchNo=1&format=html',
        '/finance/receipt-voucher?vchNo=1&format=html',
        '/finance/payment-voucher?vchNo=1&format=html',
        '/dhrn/issue-receipt?vchNo=1&format=html',
        '/karigar/issue-voucher?vchNo=1&format=html',
      ]) {
        const response = await get(url);
        expect(response.statusCode, url).toBe(400);
        expect(response.json(), url).toMatchObject({
          error: 'DocumentScopeError',
          field: 'coBook',
        });
      }
    });

    it('prints the session location voucher, never another location with the same number', async () => {
      const response = await get('/sales/invoice?coBook=SL&vchNo=1&format=html');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.body).toContain('Branch one sale');
      expect(response.body).not.toContain('Branch two sale');
    });

    it('uses the canonical desktop O/D/T copy labels on every core voucher document', async () => {
      const cases = [
        ['/sales/invoice?coBook=SL&vchNo=1&format=html&copy=D', 'DUPLICATE FOR SUPPLIER'],
        ['/purchases/invoice?coBook=PR&vchNo=1&format=html&copy=T', 'TRIPLICATE FOR TRANSPORTER'],
        [
          '/purchase-returns/1/print?coBook=PRT&coYear=' + YEAR + '&lcCode=01&format=html&copy=O',
          'ORIGINAL FOR RECIPIENT',
        ],
        ['/karigar/issue-voucher?coBook=KRI&vchNo=1&format=html&copy=D', 'DUPLICATE FOR SUPPLIER'],
      ] as const;
      for (const [url, label] of cases) {
        const response = await get(url);
        expect(response.statusCode, `${url}: ${response.body}`).toBe(200);
        expect(response.body, url).toContain(label);
      }
      const invalid = await get('/sales/invoice?coBook=SL&vchNo=1&format=html&copy=OTHER');
      expect(invalid.statusCode).toBe(400);
      expect(invalid.json()).toMatchObject({ error: 'DocumentCopyError' });
    });
  },
);
