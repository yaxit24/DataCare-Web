import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N218 / G231: Auto Item (desktop MS_AUTO_ITEM with CurMast 'AutoItem', opened by MDI_FORM.cs:7640-7649) through the
 * real Fastify routes on a forced-RLS database. Expected values come from the desktop source:
 *
 * - DISPLAY_DATA (MS_AUTO_ITEM.cs:2614-2650) lists the company's products except HM, DM, OG, OS, SN, FN, RD, EM and OT by
 *   code, Y when an item of the group has the product, else N. The group help lists GROUP_MAST by name with its type,
 *   trade type and HSN code (:3432-3493).
 * - BtnSave_Click (:2876-2923) makes, for each row with a product code and Y, the item PR_CODE + GR_CODE unless the group
 *   has it: IT_NAME = product name + " " + group code, IT_TYPE = TAG_TYPE = the group type, TRAD_TYPE, SAFE_NAME MAIN,
 *   the HSN code, UNIT_NAME GMS, RATE_TYPE G, MIN_STK = Val of the MinStk cell, MAIN_USER = the row's hidden user cell
 *   (blank for a listed product, the user for an added row), STK_DISPLAY Y, DATA_TRFR N, the flags N. The save needs the
 *   edit right once a group is shown (:2648, :2668-2672).
 * Web rules on purpose (gap G231): one transaction; a code another group's item has is refused; an added row's product
 * must be in the product master.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'auto-item-db';
const otherTenant = 'auto-item-db-other';
const PASSWORD = 'Auto-Item-Routes!2026';
const SECRET = 'auto-item-routes-test-signing-secret-over-thirty';
const ADMIN = 'aiadmin';
const CLERK = 'aiclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const RIGHTS_SUB_MENU = 'AutoItem';

type Cookie = string;

(enabled ? describe : describe.skip)(
  'N218 Auto Item is the desktop MS_AUTO_ITEM through HTTP',
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
    const items = () =>
      query<any[]>(
        `SELECT "IT_CODE" code,"IT_NAME" name,"IT_TYPE" type,"TAG_TYPE" tag,"TRAD_TYPE" trade,"PR_CODE" pr,"GR_CODE" gr,
              "SAFE_NAME" safe,"HSN_CODE" hsn,"UNIT_NAME" unit,"RATE_TYPE" rate,"MIN_STK" minstk,"MAIN_USER" main,
              "STK_DISPLAY" stk,"DATA_TRFR" trfr,"TAG_IDTL_COL" tagcol,"OTH_DETL_POSTING" othpost,"OTH_ITM_WT_REMOVE" wtremove
         FROM "ITEM_MAST" WHERE tenant_id=$1 ORDER BY "IT_CODE"`,
        tenantId,
      );
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
    const save = (cookie: Cookie, rows: unknown[], extra: Record<string, unknown> = {}) =>
      request(cookie, 'POST', '/masters/auto-item', {
        grCode: 'G22',
        grType: 'G',
        tradeType: 'GO',
        hsnCode: '7113',
        rows,
        ...extra,
      });

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1`, tenantId);
      await exec(`DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1`, tenantId);
      await exec(
        `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME")
       VALUES ($1,'01','RG','RING'),($1,'01','CH','CHAIN'),($1,'01','BG','BANGLE'),($1,'01','OG','OLD GOLD'),($1,'01','DM','DIAMOND')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE","HSN_CODE","SALE_AC","PURC_AC")
       VALUES ($1,'01','G22','GOLD 22K','G','GO','7113','SALES','PURCHASE'),($1,'01','S92','SILVER 925','S','SL','7114','SALES','PURCHASE')`,
        tenantId,
      );
      // RG already has its G22 item; BGS92 belongs to the silver group.
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE","MIN_STK") VALUES
       ($1,'01','RGG22','RING G22 OLD','RG','G22',7),($1,'01','BGS92','BANGLE S92','BG','S92',0)`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES ($1,'01','CHG22','OTHER TENANT')`,
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

    it('lists the products but the default ones by code, Y for those the group already has, with the rights', async () => {
      let response = await request(adminCookie, 'GET', '/masters/auto-item?grCode=g22');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({
        rows: [
          { prCode: 'BG', prName: 'BANGLE', yn: 'N', made: false },
          { prCode: 'CH', prName: 'CHAIN', yn: 'N', made: false },
          { prCode: 'RG', prName: 'RING', yn: 'Y', made: true },
        ],
        rights: { canUpdate: true, canDelete: true, canPrint: true },
      });
      response = await request(adminCookie, 'GET', '/masters/auto-item?grCode=S92');
      expect(
        response.json().rows.map((r: { prCode: string; yn: string }) => `${r.prCode}${r.yn}`),
      ).toEqual(['BGY', 'CHN', 'RGN']);
      response = await request(adminCookie, 'GET', '/masters/auto-item/groups?q=gold');
      expect(response.json()).toEqual([
        { code: 'G22', name: 'GOLD 22K', type: 'G', trade: 'GO', hsn: '7113' },
      ]);
    });

    it('makes the Y rows the group lacks as the desktop writes them, and leaves the rest', async () => {
      const response = await save(adminCookie, [
        { prCode: 'BG', prName: 'BANGLE', minStk: '5', yn: 'y' },
        { prCode: 'CH', prName: 'CHAIN', minStk: '2.6x', yn: 'N' },
        { prCode: 'RG', prName: 'RING', minStk: '9', yn: 'Y' },
        { prCode: 'ch', prName: "ch'ain", minStk: '3', yn: 'Y', added: true },
        { prCode: '', prName: '', yn: 'Y', added: true },
      ]);
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ created: ['BGG22', 'CHG22'], existing: ['RGG22'] });
      const rows = await items();
      const base = {
        type: 'G',
        tag: 'G',
        trade: 'GO',
        gr: 'G22',
        safe: 'MAIN',
        hsn: '7113',
        unit: 'GMS',
        rate: 'G',
        stk: 'Y',
        trfr: 'N',
        tagcol: 'N',
        othpost: 'N',
        wtremove: 'N',
      };
      expect(rows).toEqual([
        { ...base, code: 'BGG22', name: 'BANGLE G22', pr: 'BG', minstk: 5, main: '' },
        expect.objectContaining({ code: 'BGS92', gr: 'S92' }),
        { ...base, code: 'CHG22', name: 'CHAIN G22', pr: 'CH', minstk: 3, main: ADMIN },
        expect.objectContaining({ code: 'RGG22', name: 'RING G22 OLD', minstk: 7 }),
      ]);
    });

    it('refuses a code another group has, an added unknown product and an unknown group, writing nothing', async () => {
      const before = await items();
      const cases: Array<[unknown[], Record<string, unknown>, string]> = [
        [
          [{ prCode: 'BG', prName: 'BANGLE', yn: 'Y' }],
          { grCode: 'S9' },
          'group S9 is not in the group master',
        ],
        [
          [{ prCode: 'ZZ', prName: 'NOTHING', yn: 'Y', added: true }],
          {},
          'product ZZ is not in the product master',
        ],
        [
          [{ prCode: 'BG', prName: 'BANGLE', yn: 'Y' }],
          { grCode: 'S92', tradeType: 'SLV' },
          'trade type must be at most 2 characters',
        ],
      ];
      for (const [rows, extra, message] of cases) {
        const response = await save(adminCookie, rows, extra);
        expect(response.statusCode, message).toBe(400);
        expect(response.json().message).toBe(message);
      }
      // A one-character group '2': a product code longer than the grid's two characters is refused, and RG + 2 = RG2,
      // a code an item of another group (G22) already has, is refused rather than made twice.
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC") VALUES ($1,'01','2','TWO','SALES','PURCHASE')`,
        tenantId,
      );
      const taken = await save(adminCookie, [{ prCode: 'BGS9', prName: 'X', yn: 'Y' }], {
        grCode: '2',
      });
      expect(taken.statusCode).toBe(400);
      expect(taken.json().message).toBe('product code BGS9 must be at most 2 characters');
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE") VALUES ($1,'01','RG2','RING IN ANOTHER GROUP','RG','G22')`,
        tenantId,
      );
      const other = await save(adminCookie, [{ prCode: 'RG', prName: 'RING', yn: 'Y' }], {
        grCode: '2',
      });
      expect(other.statusCode).toBe(400);
      expect(other.json().message).toBe(
        'item RG2 already exists in group G22; it is not made again for 2',
      );
      await exec(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='RG2'`, tenantId);
      expect(await items()).toEqual(before);
    });

    it('writes nothing for a blank group or no Y row, and answers as saved', async () => {
      const before = await items();
      for (const [rows, extra] of [
        [[{ prCode: 'CH', prName: 'CHAIN', yn: 'Y' }], { grCode: '' }],
        [[{ prCode: 'CH', prName: 'CHAIN', yn: 'N' }], {}],
      ] as const) {
        const response = await save(adminCookie, [...rows], extra);
        expect(response.statusCode, response.body).toBe(200);
        expect(response.json()).toEqual({ created: [], existing: [] });
      }
      expect(await items()).toEqual(before);
    });

    it("follows the clerk's view-only rights row: the grid and help, but no save", async () => {
      let response = await request(clerkCookie, 'GET', '/masters/auto-item?grCode=S92');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().rights).toEqual({
        canUpdate: false,
        canDelete: false,
        canPrint: false,
      });
      response = await request(clerkCookie, 'GET', '/masters/auto-item/groups?q=');
      expect(response.statusCode).toBe(200);
      const before = await items();
      response = await save(clerkCookie, [{ prCode: 'CH', prName: 'CHAIN', yn: 'Y' }], {
        grCode: 'S92',
      });
      expect(response.statusCode).toBe(403);
      expect(await items()).toEqual(before);
      const other = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1`,
        otherTenant,
      );
      expect(other[0]!.n).toBe(1);
    });
  },
);
