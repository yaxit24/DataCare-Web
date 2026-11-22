import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-29 (N245 / G257): Purchase Rtn residuals over HTTP.
 *
 * G95 print: the desktop prints a tax book's return with PrRtnBillGst.RPT, whose tax fields are the PR_DATA header
 * (TR_KR_ISU.cs:5519 {{PrRtnBillGst.RPT}}); the lines carry no tax (TR_KR_ISU.cs:5206 {{dataRow3["TAX_PRC"] = 0;}}) and
 * print is gated on FRM_PRINT (TR_KR_ISU.cs:5434 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}).
 * Hosted additions (D5): edit and delete carry the version the read returned (purchaseVoucher.ts:45).
 *
 * Expected values: taxable = metal 5 x 80% x 1500 = 6,000 + labour 5 x 40 = 200 = 6,200; tax 3% = 186.00, halves 93.00;
 * total 6,386. Never read back from the web's output.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'prt-wp29-route';
const PASSWORD = 'Purchase-Return-Wp29!2026';
const SECRET = 'purchase-return-wp29-signing-secret-over-thirty-two-chars';
const FULL = 'wp29full';
const NOPRINT = 'wp29noprint';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const BOOK = '348';
const Q = `coBook=${BOOK}&coYear=${YEAR}&lcCode=01`;
const LINE = {
  itCode: 'GOLD',
  pcs: 1,
  grossWt: 5.2,
  netWt: 5,
  touch: 80,
  rate: 1500,
  labourType: 'per_gram',
  labourRate: 40,
};

(enabled ? describe : describe.skip)(
  'WP-29 Purchase Return print, tax line and version token',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    const cookies: Record<string, string> = {};
    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
    const query = <T>(sql: string, ...params: unknown[]) =>
      owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
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
    const request = (
      user: string,
      method: 'GET' | 'POST' | 'PUT' | 'DELETE',
      url: string,
      payload?: unknown,
    ) =>
      app.inject({
        method,
        url,
        headers: { cookie: cookies[user] ?? '' },
        ...(payload === undefined ? {} : { payload: payload as any }),
      });
    const create = async (overrides: Record<string, unknown> = {}) => {
      const saved = await request(FULL, 'POST', '/purchase-returns', {
        coBook: BOOK,
        vchDate: DAY,
        acCode: 'SUPP01',
        acName: 'Return Supplier',
        billNo: 'RB-77',
        taxRatePct: 3,
        interState: false,
        lines: [LINE],
        ...overrides,
      });
      expect(saved.statusCode, saved.body).toBe(201);
      return String(saved.json().vchNo).padStart(5, '0');
    };
    const read = async (vchNo: string) => {
      const response = await request(FULL, 'GET', `/purchase-returns/${vchNo}?${Q}`);
      expect(response.statusCode, response.body).toBe(200);
      return response.json() as Record<string, any>;
    };
    const payloadOf = (view: Record<string, any>, overrides: Record<string, unknown> = {}) => ({
      coBook: BOOK,
      vchDate: view.vchDate,
      acCode: view.acCode,
      acName: view.acName || undefined,
      billNo: view.billNo || undefined,
      taxRatePct: view.taxRatePct,
      taxCode: view.taxCode || undefined,
      interState: view.interState,
      discountAmount: view.discountAmount,
      cashAmt: view.cashAmt,
      chequeAmt: view.chequeAmt,
      cardAmt: view.cardAmt,
      kasar: view.kasar,
      lines: view.lines,
      ...overrides,
    });
    const hsnTable = async (vchNo: string, user = FULL) => {
      const printed = await request(
        user,
        'GET',
        `/purchase-returns/${vchNo}/print?${Q}&format=html`,
      );
      expect(printed.statusCode, printed.body).toBe(200);
      return printed.body.slice(
        printed.body.indexOf('class="hsn"'),
        printed.body.indexOf('class="tot"'),
      );
    };
    const footprint = async () =>
      (
        await query<Array<Record<string, unknown>>>(
          `SELECT (SELECT count(*)::int FROM "PR_DATA" WHERE tenant_id=$1) pr,
                (SELECT count(*)::int FROM "PR_DETL" WHERE tenant_id=$1) detl,
                (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) ledger,
                (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audit`,
          tenantId,
        )
      )[0];

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,'01','01','SUPP01','Return Supplier','L','40')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,'01','01','SUPP02','Other State Supplier','I','40')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC","HSN_CODE")
       VALUES ($1,'01','G01','Gold','PURCHASE','7113')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","OTH_DETL_POSTING")
       VALUES ($1,'01','GOLD','Gold Ornament','G','G01','Y')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,'01','01','348','Purchase Return 348','P348','PURC RETURN','O','Y','PR_DATA')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,'01','01','348',1,'PURCHASE','PURC RETURN','O'),
              ($1,'01','01','348',2,'CASH','PURC RETURN','O'),
              ($1,'01','01','348',3,'ROUNDOFF','PURC RETURN','O')`,
        tenantId,
      );
      for (const [login, print] of [
        [FULL, 'Y'],
        [NOPRINT, 'N'],
      ] as const) {
        await exec(
          `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER','Y','Y',$4,'N')`,
          tenantId,
          login,
          await hashPassword(PASSWORD),
          print,
        );
        await exec(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Purchase','Purchase Return','Y','Y','Y',$3)`,
          tenantId,
          login,
          print,
        );
      }
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      for (const login of [FULL, NOPRINT]) {
        const response = await app.inject({
          method: 'POST',
          url: '/auth/login',
          headers: { 'x-tenant-id': tenantId },
          payload: {
            coCode: '01',
            lcCode: '01',
            coYear: YEAR,
            loginName: login,
            password: PASSWORD,
          },
        });
        expect(response.statusCode, response.body).toBe(200);
        const value = response.headers['set-cookie'];
        cookies[login] = (Array.isArray(value) ? value : [value ?? ''])
          .map((part) => part.split(';', 1)[0])
          .join('; ');
      }
    }, 60_000);

    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('print.hsn-tax-intra: the HSN row carries taxable 6,200 and the header halves 93.00 + 93.00', async () => {
      const hsn = await hsnTable(await create());
      expect(hsn).toContain(
        '<td>7113</td><td>6,200.00</td><td>93.00</td><td>93.00</td><td>186.00</td>',
      );
      expect(hsn).not.toContain('<td>0.00</td>');
    });

    it('print.hsn-tax-inter: the whole header tax is IGST 186.00', async () => {
      const hsn = await hsnTable(
        await create({ interState: true, acCode: 'SUPP02', acName: 'Other State Supplier' }),
      );
      expect(hsn).toContain('<td>7113</td><td>6,200.00</td><td>186.00</td><td>186.00</td>');
      expect(hsn).not.toContain('CGST');
    });

    it('print.hsn-tax-zero: a return at 0% stores three zero heads (TR_KR_ISU.cs:5108-5110)', async () => {
      const vchNo = await create({ taxRatePct: 0 });
      const [head] = await query<Array<Record<string, number>>>(
        `SELECT "IGST_TAX"::float8 i,"CGST_TAX"::float8 c,"SGST_TAX"::float8 s,"TAX_AMT"::float8 t
         FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        tenantId,
        BOOK,
        vchNo,
      );
      expect(head).toEqual({ i: 0, c: 0, s: 0, t: 0 });
      expect(await hsnTable(vchNo)).toContain('<td>7113</td><td>6,200.00</td>');
    });

    it('print.rights-denied: FRM_VIEW without FRM_PRINT is refused; FRM_PRINT prints', async () => {
      const vchNo = await create();
      const denied = await request(
        NOPRINT,
        'GET',
        `/purchase-returns/${vchNo}/print?${Q}&format=html`,
      );
      expect(denied.statusCode, denied.body).toBe(403);
      expect(denied.body).not.toContain('<!doctype');
      expect(denied.json()).toMatchObject({ error: 'forbidden', action: 'print' });
      const allowed = await request(
        FULL,
        'GET',
        `/purchase-returns/${vchNo}/print?${Q}&format=html`,
      );
      expect(allowed.statusCode, allowed.body).toBe(200);
      expect(allowed.headers['content-type']).toMatch(/text\/html/);
    });

    it('line.tax-prc-zero: the header keeps rate 3 and amount 186, every line stores 0', async () => {
      const vchNo = await create();
      const [head] = await query<Array<Record<string, number>>>(
        `SELECT "TAX_PRC"::float8 p,"TAX_AMT"::float8 a FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        tenantId,
        BOOK,
        vchNo,
      );
      expect(head).toEqual({ p: 3, a: 186 });
      const lines = await query<Array<{ p: number }>>(
        `SELECT "TAX_PRC"::float8 p FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        tenantId,
        BOOK,
        vchNo,
      );
      expect(lines).toEqual([{ p: 0 }]);
      expect((await read(vchNo)).taxRatePct).toBe(3);
    });

    it('edit.version-required: PUT and DELETE without a token are 400 and change nothing', async () => {
      const vchNo = await create();
      const view = await read(vchNo);
      const before = await footprint();
      const put = await request(
        FULL,
        'PUT',
        `/purchase-returns/${vchNo}`,
        payloadOf(view, { discountAmount: 50 }),
      );
      expect(put.statusCode, put.body).toBe(400);
      expect(put.body).toContain('expectedVersion');
      const del = await request(FULL, 'DELETE', `/purchase-returns/${vchNo}?${Q}`);
      expect(del.statusCode, del.body).toBe(400);
      expect(await footprint()).toEqual(before);
      expect((await read(vchNo)).discountAmount).toBe(view.discountAmount);
    });

    it('edit.stale-version: a second session holding the old token gets 409 on PUT and DELETE', async () => {
      const vchNo = await create();
      const first = await read(vchNo);
      expect(first.version).toMatch(/^[0-9a-f]{64}$/);
      const saved = await request(
        FULL,
        'PUT',
        `/purchase-returns/${vchNo}`,
        payloadOf(first, { expectedVersion: first.version, billNo: 'RB-78' }),
      );
      expect(saved.statusCode, saved.body).toBe(200);
      const second = await read(vchNo);
      expect(saved.json().version).toBe(second.version);
      expect(second.version).not.toBe(first.version);
      const before = await footprint();
      const stalePut = await request(
        FULL,
        'PUT',
        `/purchase-returns/${vchNo}`,
        payloadOf(first, { expectedVersion: first.version, billNo: 'RB-79' }),
      );
      expect(stalePut.statusCode, stalePut.body).toBe(409);
      expect(stalePut.json().error).toBe('voucher-version-conflict');
      const staleDel = await request(
        FULL,
        'DELETE',
        `/purchase-returns/${vchNo}?${Q}&expectedVersion=${first.version}`,
      );
      expect(staleDel.statusCode, staleDel.body).toBe(409);
      expect(await footprint()).toEqual(before);
      expect((await read(vchNo)).billNo).toBe('RB-78');
    });

    it('edit.version-roundtrip: an unchanged save keeps date, bill no, amounts, fine, number and clock', async () => {
      const vchNo = await create({ cashAmt: 1000 });
      const view = await read(vchNo);
      const saved = await request(
        FULL,
        'PUT',
        `/purchase-returns/${vchNo}`,
        payloadOf(view, { expectedVersion: view.version }),
      );
      expect(saved.statusCode, saved.body).toBe(200);
      const after = await read(vchNo);
      const { version: _a, ...was } = view;
      const { version: _b, ...now2 } = after;
      expect(now2).toEqual(was);
      expect(after.billNo).toBe('RB-77');
      expect(String(after.vchDate)).toContain(DAY);
      expect(after.lines[0].fineWt).toBeCloseTo(4, 3);
    });

    it('delete.version-ok: the current token deletes the voucher and writes one audit row', async () => {
      const vchNo = await create();
      const view = await read(vchNo);
      const before = await footprint();
      const removed = await request(
        FULL,
        'DELETE',
        `/purchase-returns/${vchNo}?${Q}&expectedVersion=${view.version}`,
      );
      expect(removed.statusCode, removed.body).toBe(200);
      const after = await footprint();
      expect(after.pr).toBe(Number(before.pr) - 1);
      expect(after.audit).toBe(Number(before.audit) + 1);
      const gone = await request(FULL, 'GET', `/purchase-returns/${vchNo}?${Q}`);
      expect(gone.statusCode).toBeGreaterThanOrEqual(400);
    });
  },
);
