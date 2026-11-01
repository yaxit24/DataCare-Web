import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N218 / G231: the Item master (desktop MS_ITEM, opened by MDI_FORM.cs:7650-7659) through the real Fastify routes on a
 * forced-RLS database. Expected values come from the desktop source:
 *
 * - The list is every ITEM_MAST row of the company ordered by IT_NAME, shown as Code / Name / Safe (MS_ITEM.cs:2548-2843).
 * - BtnSave_Click (:3165-3300) refuses a blank product ("Product Code Is Null Please Create Item Again.."), group and item
 *   code in that order, writes Val of each number box, the first letter of Rate Per, Stk Display and Oth Dtl Rate Type,
 *   MAIN_USER (the user for a new item, the stored one for an opened item). Leaving the code refuses a code another item
 *   has under another name (:3497-3517); leaving the name, a name another code has (:3603-3629). Typed text is
 *   upper-cased and the apostrophe dropped (:3066-3079).
 * - BtnDelete_Click (:3302-3355) refuses an item with stock rows, a default code and a blank code.
 * - btnTagValUpdate_Click (:3969-4015) sets zero labour %, karigar touch and wastage on the item's tags at the location
 *   and recomputes KR_FINE = KR_NET_WT × (KR_TOUCH + KR_WEST_PRC) / 100 for the year.
 * Web rules on purpose (gap G231): the row is updated in place (the desktop's delete and blank insert wipes MIN_STK and
 * the averages); unknown product or group, a blank name and over-long boxes refused; version tokens.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'item-master-db';
const otherTenant = 'item-master-db-other';
const PASSWORD = 'Item-Master-Routes!2026';
const SECRET = 'item-master-routes-test-signing-secret-over-thirty';
const ADMIN = 'itadmin';
const CLERK = 'itclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const RIGHTS_SUB_MENU = 'Item';

type Cookie = string;

(enabled ? describe : describe.skip)('N218 Item master is the desktop MS_ITEM through HTTP', () => {
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
  const itemRow = async (code: string) =>
    (
      await query<any[]>(
        `SELECT "PR_CODE" pr,"GR_CODE" gr,"IT_CODE" code,"IT_NAME" name,"IT_TYPE" type,"TAG_TYPE" tag,"TRAD_TYPE" trade,
                "SAFE_NAME" safe,"HSN_CODE" hsn,"UNIT_NAME" unit,"RATE_TYPE" rate,"STK_DISPLAY" stk,"LBR_PRC"::float lbr,
                "IT_LBR_RATE"::float lbrrate,"IT_GHT_PRC"::float ght,"CON_PRC"::float con,"DISC_PRC"::float disc,
                "ITEM_RATE"::float itemrate,"OTH_RATE"::float oth,"OTH_RATE_TYPE" othtype,"IT_BAG_WT"::float bag,
                "OTH_ITM_WT_REMOVE" wtremove,"ITM_WITH_LOT_STK" lot,"TAG_IDTL_COL" tagcol,"MAIN_USER" main,"MIN_STK" minstk,
                "AVG_TOUCH"::float avg
           FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
        tenantId,
        code,
      )
    )[0];
  const allItems = () =>
    query<unknown[]>(
      `SELECT to_jsonb(i) AS r FROM "ITEM_MAST" i WHERE tenant_id=$1 ORDER BY "IT_CODE"`,
      tenantId,
    );
  const VERSION = /^[0-9a-f]{64}$/;
  const versionOf = async (code: string): Promise<string> => {
    const response = await request(adminCookie, 'GET', `/masters/item-master/${code}`);
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
  const ring = (extra: Record<string, unknown> = {}) => ({
    code: 'RGGLD',
    productCode: 'RG',
    groupCode: 'GLD',
    name: 'RING GLD',
    itType: 'G',
    tagType: 'G',
    tradeType: 'GO',
    safe: 'main',
    hsn: '7113',
    unit: 'gm',
    rateType: '1',
    stockDisplay: 'N',
    othRateType: 'P',
    lbrRate: '350',
    lbrPrc: '12.5',
    ghtPrc: '0.75',
    conPrc: '1.2',
    discPrc: '2',
    itemRate: '6123.45',
    othRate: '150 x',
    bagWt: '0.0125',
    othItmWtRemove: true,
    lotStock: true,
    ...extra,
  });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1`, tenantId);
    await exec(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','RG','RING'),($1,'01','CH','CHAIN')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE","SALE_AC","PURC_AC")
       VALUES ($1,'01','GLD','GOLD 22K','G','GO','SALES','PURCHASE'),($1,'01','SLV','SILVER','S','SL','SALES','PURCHASE')`,
      tenantId,
    );
    // OTH_ITM_WT_REMOVE shows its box; ITM_WITH_LOT_STK does not.
    await exec(`DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1`, tenantId);
    await exec(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","OTH_ITM_WT_REMOVE","ITM_WITH_LOT_STK") VALUES ($1,'01','Y','N')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES ($1,'01','RGGLD','OTHER TENANT')`,
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

  it('saves a new item with Val of the boxes, the combos letters, the shown flag and the user', async () => {
    const response = await request(
      adminCookie,
      'POST',
      '/masters/item-master',
      ring({ name: "r'ing gld" }),
    );
    expect(response.statusCode, response.body).toBe(201);
    expect(response.json()).toEqual({ code: 'RGGLD' });
    expect(await itemRow('RGGLD')).toEqual({
      pr: 'RG',
      gr: 'GLD',
      code: 'RGGLD',
      name: 'RING GLD',
      type: 'G',
      tag: 'G',
      trade: 'GO',
      safe: 'MAIN',
      hsn: '7113',
      unit: 'GM',
      rate: '1',
      stk: 'N',
      lbr: 12.5,
      lbrrate: 350,
      ght: 0.75,
      con: 1.2,
      disc: 2,
      itemrate: 6123.45,
      oth: 150,
      othtype: 'P',
      // IT_BAG_WT is numeric(14,3) in the desktop schema too, so 0.0125 is kept as 0.013.
      bag: 0.013,
      // The setting shows the wastage box only; the hidden lot-stock box writes N on a new item.
      wtremove: 'Y',
      lot: 'N',
      tagcol: 'N',
      main: ADMIN,
      minstk: null,
      avg: null,
    });
  });

  it("lists the company's items by name with the rights, combos and settings, and reads one", async () => {
    let response = await request(adminCookie, 'GET', '/masters/item-master');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toEqual({
      rows: [{ code: 'RGGLD', name: 'RING GLD', safe: 'MAIN' }],
      combos: { units: ['GM'], safes: ['MAIN'] },
      settings: { othItmWtRemove: true, lotStock: false },
      rights: { canUpdate: true, canDelete: true, canPrint: true },
    });
    response = await request(adminCookie, 'GET', '/masters/item-master/rggld');
    expect(response.json()).toMatchObject({
      code: 'RGGLD',
      productCode: 'RG',
      productName: 'RING',
      groupCode: 'GLD',
      groupName: 'GOLD 22K',
      rateType: '1',
      stockDisplay: 'N',
      othRateType: 'P',
      bagWt: 0.013,
      othItmWtRemove: true,
      inStock: false,
      version: expect.stringMatching(VERSION),
    });
    response = await request(adminCookie, 'GET', '/masters/item-master/ZZZ');
    expect(response.statusCode).toBe(404);
  });

  it('lists the product help by name and the group help with its type and trade type', async () => {
    let response = await request(adminCookie, 'GET', '/masters/item-master/products?q=');
    expect(response.json()).toEqual([
      { code: 'CH', name: 'CHAIN' },
      { code: 'RG', name: 'RING' },
    ]);
    response = await request(adminCookie, 'GET', '/masters/item-master/groups?q=s');
    expect(response.json()[0]).toEqual({ code: 'SLV', name: 'SILVER', type: 'S', trade: 'SL' });
  });

  it('refuses what MS_ITEM refuses, in its order and with its texts, and writes nothing', async () => {
    const before = await allItems();
    const cases: Array<[Record<string, unknown>, string]> = [
      [
        { code: '', productCode: '', groupCode: '', name: '' },
        'Product Code Is Null Please Create Item Again..',
      ],
      [{ code: '', groupCode: '', name: '' }, 'Group Code Is Null Please Create Item Again..'],
      [{ code: '', name: '' }, 'Item Code Is Null Please Create Item Again..'],
      [{ code: 'CHGLD', name: ' ' }, 'Please Insert Item Name'],
      [
        { code: 'RGGLD', name: 'RING OTHER' },
        "This Item Code already Exist in  'RING GLD'  Item Name...Please Change It Code...",
      ],
      [
        { code: 'CHGLD', productCode: 'CH', name: 'ring gld' },
        "This Item Code already Exist in  'RGGLD'  Item Name...Please Change It Name...",
      ],
      [
        { code: 'CHGLD', productCode: 'ZZ', name: 'CHAIN GLD' },
        'product ZZ is not in the product master',
      ],
      [
        { code: 'CHGLD', productCode: 'CH', groupCode: 'ZZZ', name: 'CHAIN ZZZ' },
        'group ZZZ is not in the group master',
      ],
      [
        { code: 'CHGLD1', productCode: 'CH', name: 'CHAIN GLD' },
        'item code must be at most 5 characters',
      ],
      [
        { code: 'CHGLD', productCode: 'CH', name: 'CHAIN GLD', unit: 'GRAMSS' },
        'UNIT_NAME must be at most 5 characters',
      ],
      [
        { code: 'CHGLD', productCode: 'CH', name: 'CHAIN GLD', rateType: 'X' },
        "rate type X is not one of the screen's types",
      ],
    ];
    for (const [change, message] of cases) {
      const response = await request(adminCookie, 'POST', '/masters/item-master', ring(change));
      expect(response.statusCode, JSON.stringify(change)).toBe(400);
      expect(response.json().message, JSON.stringify(change)).toBe(message);
    }
    expect(await allItems()).toEqual(before);
  });

  it('an edit keeps MIN_STK, the averages and the stored user, and needs the current version', async () => {
    await exec(
      `UPDATE "ITEM_MAST" SET "MIN_STK"=25,"AVG_TOUCH"=91.6,"MAIN_USER"='DESKUSER' WHERE tenant_id=$1 AND "IT_CODE"='RGGLD'`,
      tenantId,
    );
    const opened = await versionOf('RGGLD');
    // A posting that moves the averages does not make the open item stale.
    await exec(
      `UPDATE "ITEM_MAST" SET "AVG_TOUCH"=91.75 WHERE tenant_id=$1 AND "IT_CODE"='RGGLD'`,
      tenantId,
    );
    let response = await request(adminCookie, 'PUT', '/masters/item-master/RGGLD', {
      ...ring({ lbrPrc: '14', othItmWtRemove: false, lotStock: true }),
      expectedVersion: opened,
    });
    expect(response.statusCode, response.body).toBe(200);
    expect(await itemRow('RGGLD')).toMatchObject({
      lbr: 14,
      wtremove: 'N',
      lot: 'N',
      main: 'DESKUSER',
      minstk: 25,
      avg: 91.75,
    });
    const saved = await allItems();
    response = await request(adminCookie, 'PUT', '/masters/item-master/RGGLD', {
      ...ring({ lbrPrc: '15' }),
      expectedVersion: opened,
    });
    expect(response.statusCode).toBe(409);
    expect(response.json().error).toBe('item-version-conflict');
    response = await request(adminCookie, 'PUT', '/masters/item-master/RGGLD', ring());
    expect(response.statusCode).toBe(400);
    expect(await allItems()).toEqual(saved);
  });

  it("follows the clerk's view-only rights row: list and add, but no edit, delete or tag update", async () => {
    let response = await request(clerkCookie, 'GET', '/masters/item-master');
    expect(response.json().rights).toEqual({ canUpdate: false, canDelete: false, canPrint: false });
    response = await request(
      clerkCookie,
      'POST',
      '/masters/item-master',
      ring({ code: 'CHSLV', productCode: 'CH', groupCode: 'SLV', name: 'CHAIN SLV' }),
    );
    expect(response.statusCode, response.body).toBe(201);
    response = await request(clerkCookie, 'PUT', '/masters/item-master/CHSLV', {
      ...ring({ code: 'CHSLV', productCode: 'CH', groupCode: 'SLV', name: 'CHAIN SLV' }),
      expectedVersion: await versionOf('CHSLV'),
    });
    expect(response.statusCode).toBe(403);
    response = await request(clerkCookie, 'DELETE', '/masters/item-master/CHSLV');
    expect(response.statusCode).toBe(403);
    response = await request(clerkCookie, 'POST', '/masters/item-master/CHSLV/tag-values', {
      lbrPrc: '5',
    });
    expect(response.statusCode).toBe(403);
    expect((await itemRow('CHSLV')).main).toBe(CLERK);
  });

  it('updates the zero karigar values of the tags at the location and recomputes their fine for the year', async () => {
    const tag = (no: string, extra: Record<string, unknown>) =>
      exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","TAG_NO","IT_CODE","VCH_SRNO","LBR_PRC","KR_TOUCH","KR_WEST_PRC","KR_NET_WT","KR_FINE")
         VALUES ($1,'01',$2,$3,$4,'RGGLD',1,$5,$6,$7,$8,0)`,
        tenantId,
        extra.lc ?? '01',
        extra.year ?? YEAR,
        no,
        extra.lbr ?? 0,
        extra.touch ?? 0,
        extra.west ?? 0,
        extra.net ?? 10,
      );
    await tag('T1', {});
    await tag('T2', { lbr: 8, touch: 91.6 });
    await tag('T3', { lc: '02' });
    await tag('T4', { year: '2024-2025' });
    const response = await request(adminCookie, 'POST', '/masters/item-master/RGGLD/tag-values', {
      lbrPrc: '12',
      krTouch: '92',
      krWestPrc: '1.5',
    });
    expect(response.statusCode, response.body).toBe(200);
    // T1 and T4 take all three (T4 is another year, but the column updates are not year-scoped); T2 keeps its labour
    // and touch and takes the wastage; T3 is another location.
    expect(response.json()).toEqual({ code: 'RGGLD', labour: 2, touch: 2, wastage: 3, fine: 2 });
    const tags = await query<any[]>(
      `SELECT "TAG_NO" t,"LBR_PRC"::float l,"KR_TOUCH"::float k,"KR_WEST_PRC"::float w,"KR_FINE"::float f
         FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
      tenantId,
    );
    expect(tags).toEqual([
      { t: 'T1', l: 12, k: 92, w: 1.5, f: 9.35 },
      { t: 'T2', l: 8, k: 91.6, w: 1.5, f: 9.31 },
      { t: 'T3', l: 0, k: 0, w: 0, f: 0 },
      { t: 'T4', l: 12, k: 92, w: 1.5, f: 0 },
    ]);
  });

  it('deletes an unused item, and refuses an item with stock, a default code and a blank code', async () => {
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","GR_CODE") VALUES ($1,'01','OG','OLD GOLD','RG','GLD')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","ITM_SIGN","ITM_GWT","ITM_NWT","TAG_NO")
       VALUES ($1,'01','01',$2,'OPN','00001','2026-04-01','RGGLD','+',10,10,'N')`,
      tenantId,
      YEAR,
    );
    const answers: Array<[string, number, string | undefined]> = [];
    for (const code of ['%20', 'RGGLD', 'OG', 'CHSLV']) {
      const response = await request(adminCookie, 'DELETE', `/masters/item-master/${code}`);
      answers.push([code, response.statusCode, response.json().message]);
    }
    expect(answers).toEqual([
      ['%20', 400, 'Please Select Item For Delete.'],
      ['RGGLD', 400, "You Can't Delete Record This Item Use in Transaction...."],
      ['OG', 400, 'You Cant Delete Record This Item Code Is Default Code....'],
      ['CHSLV', 200, undefined],
    ]);
    expect(await itemRow('CHSLV')).toBeUndefined();
    const other = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1`,
      otherTenant,
    );
    expect(other[0]!.n).toBe(1);
  });
});
