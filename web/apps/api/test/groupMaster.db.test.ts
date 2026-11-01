import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N214 / G227: the Item Group master (desktop MS_GROUP, opened by MDI_FORM.cs:7630-7636) through the real Fastify
 * routes on a forced-RLS database. Expected values come from the desktop source:
 *
 * - The list is every GROUP_MAST row of the company ordered by GR_CODE (CLEAR_DATA, MS_GROUP.cs:1732).
 * - BtnSave_Click (:1825-1919) needs the edit right only for an opened group, refuses a blank sales or purchase account
 *   first ("Please Select Sales and Purchase Account And Try") and then a blank code or name ("Enter Group Detail"),
 *   writes Val of each number box, GR_TYPE = the item type's first letter, RATE_DISPLAY Y/N, MAIN_USER = the user for a
 *   new group and the stored one for an opened group (:1725, :1802), and sets TRAD_TYPE, IT_TYPE and HSN_CODE on every
 *   item of the group (:1887).
 * - Leaving the code refuses a code another group has; leaving the name, a name another code has (:2006-2048). Typed
 *   text is upper-cased and the apostrophe dropped (:1975-1988).
 * - BtnDelete_Click (:1921-1954) refuses a blank code and a group an item uses. The sales help lists group 25 by name
 *   without 00099 and takes a typed group-25 code (:2204-2208); the purchase help, group 30 (:2242-2246); the trade
 *   type help, BAL_GR by name (:2280-2284). BtnPrint_Click needs the print right (:1813-1817).
 * Web rules on purpose (gap G227): the row is updated in place in one transaction (the desktop's delete and blank
 * insert wipes GR_RATE and the day-close fields), version tokens, unknown accounts and a trade type over 2 refused.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'group-master-db';
const otherTenant = 'group-master-db-other';
const PASSWORD = 'Group-Master-Routes!2026';
const SECRET = 'group-master-routes-test-signing-secret-over-thirty';
const ADMIN = 'grpadmin';
const CLERK = 'grpclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
/** Sales accounts (group 25) and purchase accounts (group 30) as the desktop chart holds them. */
const ACCOUNTS = [
  ['00025', 'SALES GOLD', '25'],
  ['00026', 'SALES SILVER', '25'],
  ['00099', 'SALES SUSPENSE', '25'],
  ['00030', 'PURCHASE GOLD', '30'],
  ['00031', 'PURCHASE SILVER', '30'],
] as const;
/** The rights SUB_MENU the clerk's row names: the desktop menu caption 'Group' (MDI_FORM.cs:7630, alias N212). */
const RIGHTS_SUB_MENU = 'Group';

type Cookie = string;
type GroupRow = {
  code: string;
  name: string;
  type: string | null;
  trade: string | null;
  touch: number | null;
  purc: number | null;
  melting: number | null;
  west: number | null;
  tax: number | null;
  sale: string | null;
  purcac: string | null;
  hsn: string | null;
  display: string | null;
  main: string | null;
  rate: number | null;
  avg: number | null;
};

(enabled ? describe : describe.skip)(
  'N214 Item Group master is the desktop MS_GROUP through HTTP',
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
    const groupRows = (code: string) =>
      query<GroupRow[]>(
        `SELECT "GR_CODE" code,"GR_NAME" name,"GR_TYPE" type,"TRAD_TYPE" trade,"GR_TOUCH" touch,"GR_PURC_TOUCH" purc,
              "MELTING_PRC" melting,"WEST_PRC" west,"TAX_PRC"::float tax,"SALE_AC" sale,"PURC_AC" purcac,
              "HSN_CODE" hsn,"RATE_DISPLAY" display,"MAIN_USER" main,"GR_RATE"::float rate,"AVG_TOUCH" avg
         FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "GR_CODE"=$2 ORDER BY row_id`,
        tenantId,
        code,
      );
    const allGroups = () =>
      query<unknown[]>(
        `SELECT to_jsonb(g) - 'row_id' AS r FROM "GROUP_MAST" g WHERE tenant_id=$1 ORDER BY "GR_CODE",row_id`,
        tenantId,
      );
    const itemRows = () =>
      query<Array<{ code: string; type: string | null; trade: string | null; hsn: string | null }>>(
        `SELECT "IT_CODE" code,"IT_TYPE" type,"TRAD_TYPE" trade,"HSN_CODE" hsn FROM "ITEM_MAST"
        WHERE tenant_id=$1 AND "IT_CODE" IN ('GI1','GI2','SI1') ORDER BY "IT_CODE"`,
        tenantId,
      );
    const VERSION = /^[0-9a-f]{64}$/;
    const versionOf = async (code: string): Promise<string> => {
      const response = await request(adminCookie, 'GET', `/masters/group-master/${code}`);
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
    const gold = (extra: Record<string, unknown> = {}) => ({
      code: 'GLD',
      name: 'GOLD ORNAMENT',
      itemType: 'G',
      tradeType: 'GO',
      rateTouch: '91.60',
      purcTouch: '92.00',
      melting: '0.00',
      west: '0.00',
      saleAc: '00025',
      purcAc: '00030',
      hsn: '7113',
      taxPct: '3',
      rateDisplay: true,
      ...extra,
    });

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(`DELETE FROM "GROUP_MAST" WHERE tenant_id=$1`, tenantId);
      for (const [code, name, group] of ACCOUNTS)
        await exec(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01',$2,$3,$4)`,
          tenantId,
          code,
          name,
          group,
        );
      await exec(
        `INSERT INTO "BAL_GR"(tenant_id,"CO_CODE","TRAD_TYPE","TRAD_NAME") VALUES ($1,'01','SL','SILVER'),($1,'01','GO','GOLD ORNAMENT')`,
        tenantId,
      );
      // Another tenant's group GLD must never be listed or changed.
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC") VALUES ($1,'01','GLD','OTHER TENANT','X','Y')`,
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

    it("saves a new group with Val of the boxes, upper-cased, the item type's letter and the user", async () => {
      const response = await request(
        adminCookie,
        'POST',
        '/masters/group-master',
        gold({
          code: 'gld',
          name: "gold o'rnament",
          tradeType: 'go',
          rateTouch: ' 91.6',
          purcTouch: '92 %',
          melting: '',
          west: 'abc',
          hsn: '7113',
        }),
      );
      expect(response.statusCode, response.body).toBe(201);
      expect(response.json()).toEqual({ code: 'GLD', items: 0 });
      expect(await groupRows('GLD')).toEqual([
        {
          code: 'GLD',
          name: 'GOLD ORNAMENT',
          type: 'G',
          trade: 'GO',
          touch: 91.6,
          purc: 92,
          melting: 0,
          west: 0,
          tax: 3,
          sale: '00025',
          purcac: '00030',
          hsn: '7113',
          display: 'Y',
          main: ADMIN,
          rate: null,
          avg: null,
        },
      ]);
      const silver = await request(adminCookie, 'POST', '/masters/group-master', {
        ...gold(),
        code: 'SLV',
        name: 'SILVER ORNAMENT',
        itemType: 'S',
        tradeType: 'SL',
        saleAc: '00026',
        purcAc: '00031',
        hsn: '7114',
        rateDisplay: false,
      });
      expect(silver.statusCode, silver.body).toBe(201);
      expect((await groupRows('SLV'))[0]).toMatchObject({ type: 'S', display: 'N' });
    });

    it("lists the company's groups by code with the rights, and reads one with its account names", async () => {
      let response = await request(adminCookie, 'GET', '/masters/group-master');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({
        rows: [
          { code: 'GLD', name: 'GOLD ORNAMENT' },
          { code: 'SLV', name: 'SILVER ORNAMENT' },
        ],
        rights: { canUpdate: true, canDelete: true, canPrint: true },
      });
      response = await request(adminCookie, 'GET', '/masters/group-master/gld');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({
        code: 'GLD',
        name: 'GOLD ORNAMENT',
        itemType: 'G',
        tradeType: 'GO',
        rateTouch: 91.6,
        purcTouch: 92,
        melting: 0,
        west: 0,
        taxPct: 3,
        saleAc: '00025',
        saleAcName: 'SALES GOLD',
        purcAc: '00030',
        purcAcName: 'PURCHASE GOLD',
        hsn: '7113',
        rateDisplay: true,
        items: 0,
        version: expect.stringMatching(VERSION),
      });
      response = await request(adminCookie, 'GET', '/masters/group-master/ZZZ');
      expect(response.statusCode).toBe(404);
    });

    it("an edit keeps the day's rate, the day-close fields and MAIN_USER, and sets type, trade and HSN on the group's items", async () => {
      await exec(
        `UPDATE "GROUP_MAST" SET "GR_RATE"=7250,"AVG_TOUCH"=90.5 WHERE tenant_id=$1 AND "GR_CODE"='GLD'`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","GR_CODE","IT_TYPE","TRAD_TYPE","HSN_CODE")
       VALUES ($1,'01','GI1','GOLD RING','GLD','G','GO','7113'),($1,'01','GI2','GOLD CHAIN','GLD','G','GO','7113'),
              ($1,'01','SI1','SILVER ANKLET','SLV','S','SL','7114')`,
        tenantId,
      );
      const opened = await versionOf('GLD');
      // The Daily Rate screen writes GR_RATE (dailyRate.ts) without making the open group stale.
      await exec(
        `UPDATE "GROUP_MAST" SET "GR_RATE"=7300 WHERE tenant_id=$1 AND "GR_CODE"='GLD'`,
        tenantId,
      );
      const response = await request(adminCookie, 'PUT', '/masters/group-master/GLD', {
        ...gold({ itemType: 'P', tradeType: 'sl', hsn: '7115', name: 'GOLD ORNAMENT' }),
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ code: 'GLD', items: 2 });
      expect((await groupRows('GLD'))[0]).toMatchObject({
        type: 'P',
        trade: 'SL',
        hsn: '7115',
        main: ADMIN,
        rate: 7300,
        avg: 90.5,
      });
      expect(await itemRows()).toEqual([
        { code: 'GI1', type: 'P', trade: 'SL', hsn: '7115' },
        { code: 'GI2', type: 'P', trade: 'SL', hsn: '7115' },
        { code: 'SI1', type: 'S', trade: 'SL', hsn: '7114' },
      ]);
      expect((await request(adminCookie, 'GET', '/masters/group-master/GLD')).json().items).toBe(2);
    });

    it('refuses what MS_GROUP refuses, in its order and with its texts, and writes nothing', async () => {
      const before = await allGroups();
      const items = await itemRows();
      const cases: Array<[Record<string, unknown>, string]> = [
        [
          { code: '', name: '', saleAc: '', purcAc: '00030' },
          'Please Select Sales and Purchase Account And Try',
        ],
        [
          { code: 'NEW', name: 'NEW', saleAc: '00025', purcAc: ' ' },
          'Please Select Sales and Purchase Account And Try',
        ],
        [{ code: '', name: 'NEW GROUP' }, 'Enter Group Detail'],
        [{ code: 'NEW', name: '' }, 'Enter Group Detail'],
        [
          { code: 'SLV', name: 'SILVER JEWELLERY' },
          "This Group Code already Exist in  'SILVER ORNAMENT'  Group Name... Please Change Group Code...",
        ],
        [
          { code: 'NEW', name: 'silver ornament' },
          "This Group Name already Exist in  'SLV'  Group Code... Please Change Group Name...",
        ],
        [
          { code: 'NEW', name: 'NEW GROUP', saleAc: 'ZZZ' },
          'sales account ZZZ is not in the account master',
        ],
        [
          { code: 'NEW', name: 'NEW GROUP', tradeType: 'GOLD' },
          'trade type must be at most 2 characters (the items of the group keep it in ITEM_MAST.TRAD_TYPE)',
        ],
        [
          { code: 'NEW', name: 'NEW GROUP', itemType: 'X' },
          "item type X is not one of the screen's types",
        ],
        [{ code: 'NEWG', name: 'NEW GROUP' }, 'group code must be 1 to 3 characters'],
      ];
      for (const [change, message] of cases) {
        const response = await request(adminCookie, 'POST', '/masters/group-master', gold(change));
        expect(response.statusCode, JSON.stringify(change)).toBe(400);
        expect(response.json().message, JSON.stringify(change)).toBe(message);
      }
      expect(await allGroups()).toEqual(before);
      expect(await itemRows()).toEqual(items);
    });

    it('saves an opened group only with its current version, and does not bring back a deleted one', async () => {
      const opened = await versionOf('SLV');
      const edit = {
        ...gold(),
        code: 'SLV',
        name: 'SILVER ORNAMENT',
        itemType: 'S',
        tradeType: 'SL',
        saleAc: '00026',
        purcAc: '00031',
        hsn: '7114',
      };
      let response = await request(adminCookie, 'PUT', '/masters/group-master/SLV', {
        ...edit,
        rateTouch: '70',
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(200);
      const saved = await allGroups();
      response = await request(adminCookie, 'PUT', '/masters/group-master/SLV', {
        ...edit,
        rateTouch: '75',
        expectedVersion: opened,
      });
      expect(response.statusCode, response.body).toBe(409);
      expect(response.json().error).toBe('group-version-conflict');
      response = await request(
        adminCookie,
        'DELETE',
        `/masters/group-master/SLV?expectedVersion=${opened}`,
      );
      expect(response.statusCode).toBe(409);
      response = await request(adminCookie, 'PUT', '/masters/group-master/SLV', edit);
      expect(response.statusCode).toBe(400);
      expect(await allGroups()).toEqual(saved);
      // A group another operator deleted is not brought back by the first operator's save.
      response = await request(
        adminCookie,
        'POST',
        '/masters/group-master',
        gold({ code: 'TMP', name: 'TEMPORARY' }),
      );
      expect(response.statusCode, response.body).toBe(201);
      const tmp = await versionOf('TMP');
      response = await request(
        adminCookie,
        'DELETE',
        `/masters/group-master/TMP?expectedVersion=${tmp}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ code: 'TMP', deleted: 1 });
      response = await request(adminCookie, 'PUT', '/masters/group-master/TMP', {
        ...gold({ code: 'TMP', name: 'TEMPORARY' }),
        expectedVersion: tmp,
      });
      expect(response.statusCode).toBe(409);
      expect(await groupRows('TMP')).toEqual([]);
    });

    it('a new entry with the code and name of a group replaces it as the desktop does, under the signed-in user', async () => {
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC","MAIN_USER","GR_RATE")
       VALUES ($1,'01','DIA','DIAMOND','00025','00030','OLDUSER',55000),($1,'01','DIA','DIAMOND','00025','00030','OLDUSER',55000)`,
        tenantId,
      );
      const response = await request(clerkCookie, 'POST', '/masters/group-master', {
        ...gold({ code: 'dia', name: 'diamond', itemType: 'D', tradeType: '', hsn: '7102' }),
      });
      expect(response.statusCode, response.body).toBe(201);
      // One row stays (the desktop's delete leaves one), with the clerk as MAIN_USER and the day's rate kept.
      expect(await groupRows('DIA')).toEqual([
        expect.objectContaining({ type: 'D', trade: '', hsn: '7102', main: CLERK, rate: 55000 }),
      ]);
    });

    it("follows the clerk's view-only rights row: list and add, but no edit, delete or print", async () => {
      let response = await request(clerkCookie, 'GET', '/masters/group-master');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().rights).toEqual({
        canUpdate: false,
        canDelete: false,
        canPrint: false,
      });
      response = await request(
        clerkCookie,
        'POST',
        '/masters/group-master',
        gold({ code: 'CLK', name: 'CLERK GROUP' }),
      );
      expect(response.statusCode, response.body).toBe(201);
      response = await request(clerkCookie, 'PUT', '/masters/group-master/CLK', {
        ...gold({ code: 'CLK', name: 'CLERK EDIT' }),
        expectedVersion: await versionOf('CLK'),
      });
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'DELETE', '/masters/group-master/CLK');
      expect(response.statusCode).toBe(403);
      response = await request(clerkCookie, 'GET', '/masters/group-master/print');
      expect(response.statusCode).toBe(403);
      expect((await groupRows('CLK')).map((r) => [r.name, r.main])).toEqual([
        ['CLERK GROUP', CLERK],
      ]);
    });

    it('lists the sales help of group 25 without 00099, the purchase help of group 30, and the trade types by name', async () => {
      let response = await request(
        adminCookie,
        'GET',
        '/masters/group-master/accounts?kind=sale&q=',
      );
      expect(response.statusCode, response.body).toBe(200);
      // The web chart keeps CAPITAL A/C in group 25 (seedCompany.ts), the desktop's sales group, so the desktop's list
      // shows it on a web-provisioned company (desktop-equivalent provisioning, N58).
      expect(response.json()).toEqual([
        { code: 'CAPITAL', name: 'CAPITAL A/C', group: '25' },
        { code: '00025', name: 'SALES GOLD', group: '25' },
        { code: '00026', name: 'SALES SILVER', group: '25' },
      ]);
      // A typed 00099 is found in group 25 (:2204) although the help does not list it (:2208).
      response = await request(
        adminCookie,
        'GET',
        '/masters/group-master/accounts?kind=sale&q=00099',
      );
      expect(response.json()).toEqual([{ code: '00099', name: 'SALES SUSPENSE', group: '25' }]);
      // A purchase account is not a sales account, nor is the web chart's SALES (group 20).
      response = await request(
        adminCookie,
        'GET',
        '/masters/group-master/accounts?kind=sale&q=00030',
      );
      expect(response.json()).toEqual([]);
      response = await request(
        adminCookie,
        'GET',
        '/masters/group-master/accounts?kind=sale&q=SALES',
      );
      expect(response.json().map((r: { code: string }) => r.code)).toEqual(['00025', '00026']);
      response = await request(
        adminCookie,
        'GET',
        '/masters/group-master/accounts?kind=purchase&q=',
      );
      // The web chart's GST and TCS accounts sit in group 30, the desktop's purchase group (N58).
      expect(response.json().map((r: { code: string }) => r.code)).toEqual([
        'GSTINPUT',
        'GST',
        '00030',
        '00031',
        'TCS',
      ]);
      response = await request(adminCookie, 'GET', '/masters/group-master/trade-types?q=');
      expect(response.json()).toEqual([
        { code: 'GO', name: 'GOLD ORNAMENT' },
        { code: 'SL', name: 'SILVER' },
      ]);
      response = await request(adminCookie, 'GET', '/masters/group-master/trade-types?q=sl');
      expect(response.json()[0]).toEqual({ code: 'SL', name: 'SILVER' });
    });

    it('prints every group of the company by code', async () => {
      const response = await request(adminCookie, 'GET', '/masters/group-master/print');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json().rows.map((r: { code: string }) => r.code)).toEqual([
        'CLK',
        'DIA',
        'GLD',
        'SLV',
      ]);
      expect(response.json().rows[2]).toEqual({
        code: 'GLD',
        name: 'GOLD ORNAMENT',
        itemType: 'P',
        tradeType: 'SL',
        rateTouch: 91.6,
        purcTouch: 92,
        melting: 0,
        west: 0,
        saleAc: '00025',
        purcAc: '00030',
        hsn: '7115',
        taxPct: 3,
      });
    });

    it('deletes an unused group, refuses a blank code and a group an item uses, and leaves another tenant alone', async () => {
      let response = await request(adminCookie, 'DELETE', '/masters/group-master/%20');
      expect(response.statusCode).toBe(400);
      expect(response.json().message).toBe('Please Select Group For Delete.');
      response = await request(adminCookie, 'DELETE', '/masters/group-master/GLD');
      expect(response.statusCode).toBe(400);
      expect(response.json().message).toBe(
        'You Cant Delete Record This Group Code Use in Item Master....',
      );
      expect(await groupRows('GLD')).toHaveLength(1);
      response = await request(adminCookie, 'DELETE', '/masters/group-master/CLK');
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({ code: 'CLK', deleted: 1 });
      expect(await groupRows('CLK')).toEqual([]);
      const other = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_NAME"='OTHER TENANT'`,
        otherTenant,
      );
      expect(other[0]!.n).toBe(1);
    });
  },
);
