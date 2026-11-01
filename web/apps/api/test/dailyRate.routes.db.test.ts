import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { saveDailyRate } from '../src/modules/masters/dailyRate.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N208 / G221: Daily Rate (desktop MS_RATE, "Rate Master", opened by MDI_FORM.cs:8564-8573) through the real Fastify
 * routes on a forced-RLS database. Expected values come from the desktop source:
 *
 * - DISPLAY_DATA (MS_RATE.cs:1752-1832): the header comes from RATE_MAST for CO_CODE, LC_CODE, CO_YEAR and VCH_DATE;
 *   the grid lists GROUP_MAST rows with GR_TOUCH <> 0 ORDER BY GR_TYPE, GR_NAME, showing the group's own touch,
 *   TAX_PRC and GR_PURC_TOUCH, with GR_RATE, GR_TAX_RATE and GR_PR_RATE taken from the saved day by GR_CODE.
 * - BtnSave_Click (:1867-1947): an existing day needs edit rights ("You Have No Rights....."); the day's rows for
 *   CO_CODE, LC_CODE, CO_YEAR and VCH_DATE are deleted, then one RATE_MAST row is written per grid row whose touch and
 *   Rate10gm are non-zero, SR_NO = the grid row, with the header rates, GR_TYPE, EMP_CODE and MainUser (the user who
 *   created the day, CLEAR_DATA :1728-1750); no GR_NAME is written. Location '00' also sets GROUP_MAST.GR_RATE.
 * - BtnDelete_Click (:2095-2109) needs delete rights and deletes CO_CODE, LC_CODE and VCH_DATE.
 * - BtnF1_Click (:2370-2396) lists date, user, gold and silver rate for CO_CODE and LC_CODE, newest first.
 * - BtnPrint_Click (:1834-1866) needs print rights and prints RateRpt titled 'Daily Rate Report dd/MM/yyyy'
 *   (report-specs/RateRpt.spec.json: company, Date / Group Name / Rate 10gm, GROUP_MAST.GR_NAME and GR_RATE).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'daily-rate-routes-db';
const PASSWORD = 'Daily-Rate-Routes!2026';
const SECRET = 'daily-rate-routes-test-signing-secret-over-thirty-two';
const ADMIN = 'dradmin';
const CLERK = 'drclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-07-01`;
const DAY2 = `${startYear}-07-02`;
const DAY3 = `${startYear}-07-03`;
const EMP = 'E01';
const GROUPS = [
  // GR_CODE, GR_NAME, GR_TYPE, GR_TOUCH, TAX_PRC, GR_PURC_TOUCH
  ['G22', 'Gold 22K', 'G', 91.6, 3, 92],
  ['G18', 'Gold 18K', 'G', 75, 0, 76],
  ['SLV', 'Silver 925', 'S', 92.5, 3, 90],
  ['DIA', 'Diamond Rate', 'D', 100, 0, 0],
  ['NIL', 'No Touch', 'G', 0, 0, 0],
] as const;
/** MS_RATE's grid after Gold 72000 / Silver 85000 and Enter, worked by hand (see core dailyRate.test.ts). */
const savedGrid = [
  { grCode: 'DIA', touch: 100, taxPct: 0, rate: 5000, taxRate: 5000, prRate: 0 },
  { grCode: 'G18', touch: 75, taxPct: 0, rate: 54000, taxRate: 54000, prRate: 54720 },
  { grCode: 'G22', touch: 91.6, taxPct: 3, rate: 64031, taxRate: 65952, prRate: 66240 },
  { grCode: 'SLV', touch: 92.5, taxPct: 3, rate: 763, taxRate: 786, prRate: 765 },
];

type Cookie = string;

(enabled ? describe : describe.skip)('N208 Daily Rate is the desktop MS_RATE through HTTP', () => {
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
  const save = (cookie: Cookie, date: string, rows = savedGrid, extra = {}) =>
    request(cookie, 'POST', '/daily-rate', {
      date,
      goldRate: 72000,
      silverRate: 85000,
      empCode: EMP,
      rows,
      ...extra,
    });
  const rateRows = (lc: string, date: string) =>
    query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO"::int sr,"GR_CODE" gr,"GR_NAME" name,"GR_TYPE" type,"CO_YEAR" "year",
              "FINE_GL_RATE"::float gold,"FINE_SL_RATE"::float silver,
              coalesce("FINE_GL_PR_RATE",0)::float prgold,coalesce("FINE_SL_PR_RATE",0)::float prsilver,
              coalesce("DOLLAR_GL_RATE",0)::float usdgold,coalesce("DOLLAR_SL_RATE",0)::float usdsilver,
              "GR_TOUCH"::float touch,"GR_TAX_PRC"::float tax,"GR_RATE"::float rate,"GR_TAX_RATE"::float taxrate,
              "GR_PR_TOUCH"::float prtouch,"GR_PR_RATE"::float prrate,coalesce("EMP_CODE",'') emp,
              coalesce("MAIN_USER",'') "user"
         FROM "RATE_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$2 AND "VCH_DATE"=$3::date
        ORDER BY "SR_NO"`,
      tenantId,
      lc,
      date,
    );
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenantId);
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
    await exec(`UPDATE "CO_MAST" SET "CO_NAME"='Rate Jewellers' WHERE tenant_id=$1`, tenantId);
    for (const [code, name, type, touch, tax, prTouch] of GROUPS)
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","GR_TOUCH","TAX_PRC","GR_PURC_TOUCH","GR_RATE")
         VALUES ($1,'01',$2,$3,$4,$5,$6,$7,11)`,
        tenantId,
        code,
        name,
        type,
        touch,
        tax,
        prTouch,
      );
    await exec(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,'01',$2,'Rate Clerk')`,
      tenantId,
      EMP,
    );
    // Another location's rate for the same day must survive this location's save and delete.
    await exec(
      `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_RATE","FINE_GL_RATE","MAIN_USER")
       VALUES ($1,'01','02',$2,$3::date,1,'G22',1234,70000,'otherlc')`,
      tenantId,
      YEAR,
      DAY,
    );
    const passwordHash = await hashPassword(PASSWORD);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$3,'ADMIN','Y','Y','Y','N'),($1,'01',$4,$3,'USER','Y','N','N','N')`,
      tenantId,
      ADMIN,
      passwordHash,
      CLERK,
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES ($1,'01','01',$2,'Cash / Bank','Daily Rate','Y','N','N','N')`,
      tenantId,
      CLERK,
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

  it('opens a new day with the GROUP_MAST groups that have a touch, in GR_TYPE then GR_NAME order', async () => {
    const response = await request(adminCookie, 'GET', `/daily-rate?date=${DAY}`);
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toMatchObject({
      date: DAY,
      exists: false,
      goldRate: 0,
      silverRate: 0,
      empCode: '',
      foreignRates: false,
      groups: [
        {
          grCode: 'DIA',
          grName: 'Diamond Rate',
          grType: 'D',
          touch: 100,
          taxPct: 0,
          prTouch: 0,
          rate: 0,
        },
        {
          grCode: 'G18',
          grName: 'Gold 18K',
          grType: 'G',
          touch: 75,
          taxPct: 0,
          prTouch: 76,
          rate: 0,
        },
        {
          grCode: 'G22',
          grName: 'Gold 22K',
          grType: 'G',
          touch: 91.6,
          taxPct: 3,
          prTouch: 92,
          rate: 0,
        },
        {
          grCode: 'SLV',
          grName: 'Silver 925',
          grType: 'S',
          touch: 92.5,
          taxPct: 3,
          prTouch: 90,
          rate: 0,
        },
      ],
    });
    expect(response.json().groups).toHaveLength(4);
  });

  it('saves one row per priced group with the desktop columns, scoped to this location and year', async () => {
    const saved = await save(adminCookie, DAY);
    expect(saved.statusCode, saved.body).toBe(201);
    const row = (
      sr: number,
      gr: string,
      type: string,
      prtouch: number,
      values: Record<string, number>,
    ) => ({
      sr,
      gr,
      name: null,
      type,
      year: YEAR,
      gold: 72000,
      silver: 85000,
      prgold: 0,
      prsilver: 0,
      usdgold: 0,
      usdsilver: 0,
      prtouch,
      emp: EMP,
      user: ADMIN,
      ...values,
    });
    expect(await rateRows('01', DAY)).toEqual([
      row(1, 'DIA', 'D', 0, { touch: 100, tax: 0, rate: 5000, taxrate: 5000, prrate: 0 }),
      row(2, 'G18', 'G', 76, { touch: 75, tax: 0, rate: 54000, taxrate: 54000, prrate: 54720 }),
      row(3, 'G22', 'G', 92, { touch: 91.6, tax: 3, rate: 64031, taxrate: 65952, prrate: 66240 }),
      row(4, 'SLV', 'S', 90, { touch: 92.5, tax: 3, rate: 763, taxrate: 786, prrate: 765 }),
    ]);
    // The other location's day is untouched, and GROUP_MAST.GR_RATE changes only at location '00'.
    expect((await rateRows('02', DAY)).map((r) => [r.gr, r.rate, r.user])).toEqual([
      ['G22', 1234, 'otherlc'],
    ]);
    const groupRates = await query<Array<{ gr: string; rate: number }>>(
      `SELECT "GR_CODE" gr,"GR_RATE"::float rate FROM "GROUP_MAST" WHERE tenant_id=$1 ORDER BY "GR_CODE"`,
      tenantId,
    );
    expect(groupRates.every((g) => g.rate === 11)).toBe(true);

    const reopened = await request(adminCookie, 'GET', `/daily-rate?date=${DAY}`);
    expect(reopened.json()).toMatchObject({
      exists: true,
      goldRate: 72000,
      silverRate: 85000,
      empCode: EMP,
      empName: 'Rate Clerk',
      mainUser: ADMIN,
      groups: [
        { grCode: 'DIA', rate: 5000, taxRate: 5000, prRate: 0 },
        { grCode: 'G18', rate: 54000, taxRate: 54000, prRate: 54720 },
        { grCode: 'G22', rate: 64031, taxRate: 65952, prRate: 66240 },
        { grCode: 'SLV', rate: 763, taxRate: 786, prRate: 765 },
      ],
    });
  });

  it('skips an unpriced group, keeps the creator on a re-save, and needs edit rights only for an existing day', async () => {
    // A view-only user may enter a new day (EntryMode 'A' has no rights check) …
    const created = await save(clerkCookie, DAY2);
    expect(created.statusCode, created.body).toBe(201);
    expect((await rateRows('01', DAY2)).map((r) => r.user)).toEqual([CLERK, CLERK, CLERK, CLERK]);
    // … but not change a saved one (MS_RATE.cs:1882-1886).
    const refused = await save(clerkCookie, DAY2, savedGrid.slice(0, 2));
    expect(refused.statusCode, refused.body).toBe(403);
    expect(refused.json()).toMatchObject({ error: 'forbidden', action: 'update' });
    expect(await rateRows('01', DAY2)).toHaveLength(4);
    // The admin re-saves with DG18 unpriced: its row is skipped, SR_NO stays the grid row, the creator stays.
    const resaved = await save(adminCookie, DAY2, [
      savedGrid[0]!,
      { ...savedGrid[1]!, rate: 0, taxRate: 0 },
      savedGrid[2]!,
      savedGrid[3]!,
    ]);
    expect(resaved.statusCode, resaved.body).toBe(201);
    expect((await rateRows('01', DAY2)).map((r) => [r.sr, r.gr, r.user])).toEqual([
      [1, 'DIA', CLERK],
      [3, 'G22', CLERK],
      [4, 'SLV', CLERK],
    ]);
  });

  it('refuses unknown groups or employees, bad dates, negative values and extra fields without writing', async () => {
    const before = await rateRows('01', DAY3);
    for (const payload of [
      { date: DAY3, goldRate: 72000, silverRate: 0, rows: [{ ...savedGrid[1]!, grCode: 'NOPE' }] },
      { date: DAY3, goldRate: 72000, silverRate: 0, rows: [{ ...savedGrid[1]!, grCode: 'NIL' }] },
      { date: DAY3, goldRate: 72000, silverRate: 0, empCode: 'E99', rows: [savedGrid[1]!] },
      { date: '2026-13-45', goldRate: 72000, silverRate: 0, rows: [savedGrid[1]!] },
      { date: DAY3, goldRate: -1, silverRate: 0, rows: [savedGrid[1]!] },
      { date: DAY3, goldRate: 72000, silverRate: 0, rows: [{ ...savedGrid[1]!, rate: -5 }] },
      { date: DAY3, goldRate: 72000, silverRate: 0, rows: [savedGrid[1]!, savedGrid[1]!] },
      { date: DAY3, goldRate: 72000, silverRate: 0, taxPct: 3, rows: [savedGrid[1]!] },
      { date: DAY3, goldRate: 72000, silverRate: 0, rows: [{ ...savedGrid[1]!, grName: 'x' }] },
    ]) {
      const response = await request(adminCookie, 'POST', '/daily-rate', payload);
      expect(response.statusCode, `${JSON.stringify(payload)} => ${response.body}`).toBe(400);
    }
    expect(await rateRows('01', DAY3)).toEqual(before);
  });

  it('lists the saved days of this location newest first, as the F1 help does', async () => {
    const response = await request(adminCookie, 'GET', '/daily-rate/dates');
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toEqual([
      { date: DAY2, mainUser: CLERK, goldRate: 72000, silverRate: 85000 },
      { date: DAY, mainUser: ADMIN, goldRate: 72000, silverRate: 85000 },
    ]);
  });

  it('prints RateRpt behind print rights', async () => {
    const denied = await request(clerkCookie, 'GET', `/daily-rate/print?date=${DAY}&format=html`);
    expect(denied.statusCode, denied.body).toBe(403);
    expect(denied.json()).toMatchObject({ error: 'forbidden', action: 'print' });
    const printed = await request(adminCookie, 'GET', `/daily-rate/print?date=${DAY}&format=html`);
    expect(printed.statusCode, printed.body).toBe(200);
    const [y, m, d] = DAY.split('-');
    for (const text of [
      'Rate Jewellers',
      `Daily Rate Report ${d}/${m}/${y}`,
      'Group Name',
      'Rate 10gm',
      `${d}/${m}/${y}`,
      'Diamond Rate',
      'Gold 18K',
      'Gold 22K',
      'Silver 925',
      '64,031.00',
      '763.00',
    ])
      expect(printed.body).toContain(text);
    expect(printed.body).not.toContain('1,234.00');
  });

  it('deletes only this location’s day behind delete rights, then answers 404', async () => {
    const denied = await request(clerkCookie, 'DELETE', `/daily-rate?date=${DAY}`);
    expect(denied.statusCode, denied.body).toBe(403);
    const deleted = await request(adminCookie, 'DELETE', `/daily-rate?date=${DAY}`);
    expect(deleted.statusCode, deleted.body).toBe(200);
    expect(deleted.json()).toEqual({ deleted: 4 });
    expect(await rateRows('01', DAY)).toEqual([]);
    expect(await rateRows('02', DAY)).toHaveLength(1);
    const again = await request(adminCookie, 'DELETE', `/daily-rate?date=${DAY}`);
    expect(again.statusCode, again.body).toBe(404);
  });

  it('sets GROUP_MAST.GR_RATE when the rate is saved at location 00', async () => {
    await saveDailyRate(runtime, {
      scope: { tenantId, coCode: '01', lcCode: '00', coYear: YEAR },
      date: DAY3,
      goldRate: 72000,
      silverRate: 85000,
      rows: savedGrid,
      mainUser: ADMIN,
    });
    const groupRates = await query<Array<{ gr: string; rate: number }>>(
      `SELECT "GR_CODE" gr,"GR_RATE"::float rate FROM "GROUP_MAST" WHERE tenant_id=$1 ORDER BY "GR_CODE"`,
      tenantId,
    );
    expect(groupRates).toEqual([
      { gr: 'DIA', rate: 5000 },
      { gr: 'G18', rate: 54000 },
      { gr: 'G22', rate: 64031 },
      { gr: 'NIL', rate: 11 },
      { gr: 'SLV', rate: 763 },
    ]);
  });
});
