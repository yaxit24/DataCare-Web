import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N215 / G228: the Product master (desktop MS_PRODUCT with CurMast 'Product', opened by MDI_FORM.cs:7620-7628) through
 * the real Fastify routes on a forced-RLS database. Expected values come from the desktop source:
 *
 * - The list is every PRODUCT_MAST row of the company ordered by PR_CODE (MS_PRODUCT.cs:2142).
 * - BtnSave_Click (:2570-2665) needs the edit right only for an opened product, refuses a blank code ("Enter Product
 *   Code."), a blank name ("Enter Product Name.") and a one-character code ("Please Insert Product Code 2 Digit..."),
 *   then replaces the code's row with CO_CODE, PR_CODE, PR_NAME, MAIN_USER = the signed-in user (CLEAR_DATA :2230; no
 *   product read sets it back) and DATA_TRFR 'N'.
 * - Leaving the code refuses a code another product has; leaving the name, a name another code has (:2395-2504).
 *   Typed text is upper-cased and the apostrophe dropped (:2361-2377).
 * - BtnDelete_Click (:2706-2804) refuses a blank code, then (after its question) a product an item uses and the default
 *   products DM, EM, FN, HM, OG, OR, OS, OT, RD and SN.
 * Web rules on purpose (gap G228): one transaction, version tokens, a name over 40 refused.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'product-master-db';
const otherTenant = 'product-master-db-other';
const PASSWORD = 'Product-Master-Routes!2026';
const SECRET = 'product-master-routes-test-signing-secret-over-thirty';
const ADMIN = 'pradmin';
const CLERK = 'prclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
/** The rights SUB_MENU the clerk's row names: the desktop menu caption 'Product' (MDI_FORM.cs:7620, alias N212). */
const RIGHTS_SUB_MENU = 'Product';

type Cookie = string;
type ProductRow = {
  code: string;
  name: string;
  main: string | null;
  trfr: string | null;
  rid: string;
};

(enabled ? describe : describe.skip)(
  'N215 Product master is the desktop MS_PRODUCT through HTTP',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let adminCookie: Cookie;
    let clerkCookie: Cookie;

    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
    const query = <T>(sql: string, ...params: unknown[]) =>
      owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
    const request = (cookie: Cookie, method: string, url: string, payload?: unknown) =>
      app.inject({
        method: method as never,
        url,
        headers: { cookie },
        ...(payload === undefined ? {} : { payload: payload as never }),
      });
    const productRows = (code: string) =>
      query<ProductRow[]>(
        `SELECT "PR_CODE" code,"PR_NAME" name,"MAIN_USER" main,"DATA_TRFR" trfr,row_id::text rid
         FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "PR_CODE"=$2 ORDER BY row_id`,
        tenantId,
        code,
      );
    const allProducts = () =>
      query<unknown[]>(
        `SELECT to_jsonb(p) AS r FROM "PRODUCT_MAST" p WHERE tenant_id=$1 ORDER BY "PR_CODE",row_id`,
        tenantId,
      );
    const VERSION = /^[0-9a-f]{64}$/;
    const versionOf = async (code: string): Promise<string> => {
      const response = await request(adminCookie, 'GET', `/masters/product-master/${code}`);
      expect(response.statusCode, response.body).toBe(200);
      return response.json().version;
    };
    const wipe = async () => {
      const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const { table_name } of tables)
        await owner.$executeRawUnsafe(
          `DELETE FROM "${table_name}" WHERE tenant_id IN ($1,$2)`,
          tenantId,
          otherTenant,
        );
    };
    const login = async (user: string): Promise<Cookie> => {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const setCookie = response.headers['set-cookie'];
      return (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    };

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(`DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1`, tenantId);
      // Two of the desktop template's default products, as the desktop writes them.
      await exec(
        `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME","MAIN_USER","DATA_TRFR")
       VALUES ($1,'01','OG','OLD GOLD','ADMIN','N'),($1,'01','DM','DIAMOND','ADMIN','N')`,
        tenantId,
      );
      // Another tenant's product RG must never be listed or changed.
      await exec(
        `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','RG','OTHER TENANT')`,
        otherTenant,
      );
      const passwordHash = await hashPassword(PASSWORD);
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$4,'ADMIN','Y','Y','Y','N'),($1,'01',$3,$4,'USER','Y','N','N','N')`,
        tenantId,
        ADMIN,
        CLERK,
        passwordHash,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES ($1,'01','01',$2,'Master',$3,'Y','N','N','N')`,
        tenantId,
        CLERK,
        RIGHTS_SUB_MENU,
      );
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      adminCookie = await login(ADMIN);
      clerkCookie = await login(CLERK);
    });

    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('saves a new product upper-cased, with the signed-in user and DATA_TRFR N', async () => {
      const response = await request(adminCookie, 'POST', '/masters/product-master', {
        code: 'rg',
        name: "r'ing",
      });
      expect(response.statusCode, response.body).toBe(201);
      expect(response.json()).toEqual({ code: 'RG' });
      expect((await productRows('RG')).map(({ rid, ...row }) => row)).toEqual([
        { code: 'RG', name: 'RING', main: ADMIN, trfr: 'N' },
      ]);
    });

    it("lists the company's products by code with the rights, and reads one with its items", async () => {
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE") VALUES ($1,'01','PR1','GOLD RING','RG')`,
        tenantId,
      );
      let response = await request(adminCookie, 'GET', '/masters/product-master');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({
        rows: [
          { code: 'DM', name: 'DIAMOND' },
          { code: 'OG', name: 'OLD GOLD' },
          { code: 'RG', name: 'RING' },
        ],
        rights: { canUpdate: true, canDelete: true, canPrint: true },
      });
      response = await request(adminCookie, 'GET', '/masters/product-master/rg');
      expect(response.json()).toEqual({
        code: 'RG',
        name: 'RING',
        items: 1,
        version: expect.stringMatching(VERSION),
      });
      response = await request(adminCookie, 'GET', '/masters/product-master/ZZ');
      expect(response.statusCode).toBe(404);
    });

    it('refuses what MS_PRODUCT refuses, in its order and with its texts, and writes nothing', async () => {
      const before = await allProducts();
      const cases: Array<[Record<string, unknown>, string]> = [
        [{ code: '', name: '' }, 'Enter Product Code.'],
        [{ code: 'CH', name: ' ' }, 'Enter Product Name.'],
        [{ code: 'C', name: 'CHAIN' }, 'Please Insert Product Code 2 Digit...'],
        [
          { code: 'OG', name: 'OLD SILVER' },
          "This Product Code already Exist in  'OLD GOLD'  Product Name...Please Change Pr Code...",
        ],
        [
          { code: 'CH', name: 'ring' },
          "This Product Name already Exist in  'RG'  Product Code...Please Change Pr Name...",
        ],
        [{ code: 'CHN', name: 'CHAIN' }, 'product code must be 2 characters'],
        [{ code: 'CH', name: 'C'.repeat(41) }, 'product name must be at most 40 characters'],
      ];
      for (const [payload, message] of cases) {
        const response = await request(adminCookie, 'POST', '/masters/product-master', payload);
        expect(response.statusCode, JSON.stringify(payload)).toBe(400);
        expect(response.json().message, JSON.stringify(payload)).toBe(message);
      }
      expect(await allProducts()).toEqual(before);
    });

    it('an edit writes the signed-in user, and needs the current version of an opened product', async () => {
      await exec(
        `UPDATE "PRODUCT_MAST" SET "MAIN_USER"='DESKUSER' WHERE tenant_id=$1 AND "PR_CODE"='OG'`,
        tenantId,
      );
      const opened = await versionOf('OG');
      let response = await request(adminCookie, 'PUT', '/masters/product-master/OG', {
        name: 'old gold 22k',
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(200);
      expect((await productRows('OG')).map(({ rid, ...row }) => row)).toEqual([
        { code: 'OG', name: 'OLD GOLD 22K', main: ADMIN, trfr: 'N' },
      ]);
      const saved = await allProducts();
      response = await request(adminCookie, 'PUT', '/masters/product-master/OG', {
        name: 'OLD GOLD 18K',
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(409);
      expect(response.json().error).toBe('product-version-conflict');
      response = await request(
        adminCookie,
        'DELETE',
        `/masters/product-master/OG?expectedVersion=${opened}`,
      );
      expect(response.statusCode).toBe(409);
      response = await request(adminCookie, 'PUT', '/masters/product-master/OG', {
        name: 'OLD GOLD 18K',
      });
      expect(response.statusCode).toBe(400);
      expect(await allProducts()).toEqual(saved);
      // A product another operator deleted is not brought back by the first operator's save.
      response = await request(adminCookie, 'POST', '/masters/product-master', {
        code: 'TM',
        name: 'TEMPORARY',
      });
      expect(response.statusCode, response.body).toBe(201);
      const tm = await versionOf('TM');
      response = await request(
        adminCookie,
        'DELETE',
        `/masters/product-master/TM?expectedVersion=${tm}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ code: 'TM', deleted: 1 });
      response = await request(adminCookie, 'PUT', '/masters/product-master/TM', {
        name: 'TEMPORARY',
        expectedVersion: tm,
      });
      expect(response.statusCode).toBe(409);
      expect(await productRows('TM')).toEqual([]);
    });

    it('a new entry with the code and name of a product replaces its row, as the desktop does', async () => {
      const [before] = await productRows('RG');
      const response = await request(clerkCookie, 'POST', '/masters/product-master', {
        code: 'RG',
        name: 'RING',
      });
      expect(response.statusCode, response.body).toBe(201);
      const after = await productRows('RG');
      expect(after).toHaveLength(1);
      expect(after[0]!.main).toBe(CLERK);
      expect(after[0]!.rid).not.toBe(before!.rid);
    });

    it("follows the clerk's view-only rights row: list and add, but no edit or delete", async () => {
      let response = await request(clerkCookie, 'GET', '/masters/product-master');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().rights).toEqual({
        canUpdate: false,
        canDelete: false,
        canPrint: false,
      });
      response = await request(clerkCookie, 'POST', '/masters/product-master', {
        code: 'CK',
        name: 'CLERK PRODUCT',
      });
      expect(response.statusCode, response.body).toBe(201);
      response = await request(clerkCookie, 'PUT', '/masters/product-master/CK', {
        name: 'CLERK EDIT',
        expectedVersion: await versionOf('CK'),
      });
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'DELETE', '/masters/product-master/CK');
      expect(response.statusCode).toBe(403);
      expect((await productRows('CK')).map((r) => [r.name, r.main])).toEqual([
        ['CLERK PRODUCT', CLERK],
      ]);
    });

    it('deletes an unused product, refuses a blank code, a product an item uses and a default product', async () => {
      const answers: Array<[string, number, string | undefined]> = [];
      for (const code of ['%20', 'RG', 'OG', 'DM', 'CK']) {
        const response = await request(adminCookie, 'DELETE', `/masters/product-master/${code}`);
        answers.push([code, response.statusCode, response.json().message]);
      }
      expect(answers).toEqual([
        ['%20', 400, 'Please Select Product For Delete.'],
        ['RG', 400, 'You Cant Delete Record This Product Use in Itme Master....'],
        ['OG', 400, 'You Cant Delete Record, This Product Is Default Product....'],
        ['DM', 400, 'You Cant Delete Record, This Product Is Default Product....'],
        ['CK', 200, undefined],
      ]);
      expect(await productRows('CK')).toEqual([]);
      expect(await productRows('RG')).toHaveLength(1);
      const other = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_NAME"='OTHER TENANT'`,
        otherTenant,
      );
      expect(other[0]!.n).toBe(1);
    });
  },
);
