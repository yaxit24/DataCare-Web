import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { copyDailyRateDay, saveDailyRate } from '../src/modules/masters/dailyRate.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-33 Daily Rate residuals: the location-00 copy and the MDI main-window rate labels.
 *
 * - MS_RATE.cs:1937-1949: after a location-00 save, for every other location of the company the day is deleted and the
 *   location-00 day is inserted with only LC_CODE replaced (CO_YEAR copied as data, GR_NAME not part of the list). The
 *   desktop gate is a registration literal; the web gate is the company's daily_rate_copy_entitlement (default off).
 * - MS_RATE.cs:1930-1933: location 00 also updates GROUP_MAST.GR_RATE.
 * - MDI_FORM.cs:11421-11500 and MS_RATE.cs:1950: the labels are today's rows of this company and location for the
 *   RATE_DISPLAY = 'Y' groups, ORDER BY SR_NO, at most seven, 'GR_NAME  -  0.00', 'ToDays Rate :' when there is none.
 *
 * Values are Vector A of orchestration/work/WP-33/cases.md (gold 72000, silver 85000), worked by hand there.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'daily-rate-copy-db';
const OTHER_TENANT = 'daily-rate-copy-db2';
const PASSWORD = 'Daily-Rate-Copy!2026';
const SECRET = 'daily-rate-copy-test-signing-secret-over-thirty-two';
const ADMIN = 'dcadmin';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const D = `${startYear}-08-10`;
const H = `${startYear}-08-09`;
const GROUPS = [
  ['R18', 'Rate Gold 18K', 'G', 75, 0, 76, 'Y'],
  ['R22', 'Rate Gold 22K', 'G', 91.6, 3, 92, 'Y'],
  ['RSV', 'Rate Silver 925', 'S', 92.5, 3, 90, 'Y'],
  ['RHD', 'Hidden Group', 'G', 50, 0, 50, 'N'],
] as const;
const gridA = [
  { grCode: 'R18', touch: 75, taxPct: 0, rate: 54000, taxRate: 54000, prRate: 54720 },
  { grCode: 'R22', touch: 91.6, taxPct: 3, rate: 64031, taxRate: 65952, prRate: 66240 },
  { grCode: 'RSV', touch: 92.5, taxPct: 3, rate: 763, taxRate: 786, prRate: 765 },
];
const gridB = [
  { grCode: 'R18', touch: 75, taxPct: 0, rate: 54750, taxRate: 54750, prRate: 55480 },
  { grCode: 'R22', touch: 91.6, taxPct: 3, rate: 64920, taxRate: 66868, prRate: 67160 },
  { grCode: 'RSV', touch: 92.5, taxPct: 3, rate: 773, taxRate: 796, prRate: 774 },
];

(enabled ? describe : describe.skip)('WP-33 Daily Rate copy and main-window labels', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';

  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const save = (lc: string, date: string, rows = gridA, gold = 72000, silver = 85000) =>
    saveDailyRate(runtime, {
      scope: { tenantId, coCode: '01', lcCode: lc, coYear: YEAR },
      date,
      goldRate: gold,
      silverRate: silver,
      rows,
      mainUser: ADMIN,
    });
  const setEntitlement = (value: boolean | null) =>
    value === null
      ? exec(`DELETE FROM "daily_rate_copy_entitlement" WHERE tenant_id=$1`, tenantId)
      : exec(
          `INSERT INTO "daily_rate_copy_entitlement"(tenant_id,co_code,enabled) VALUES ($1,'01',$2)
           ON CONFLICT (tenant_id,co_code) DO UPDATE SET enabled=EXCLUDED.enabled`,
          tenantId,
          value,
        );
  const dayRows = (lc: string, date: string) =>
    query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO"::int sr,"GR_CODE" gr,"GR_NAME" name,"GR_TYPE" type,"CO_YEAR" yr,"EMP_CODE" emp,"MAIN_USER" usr,
              "FINE_GL_RATE"::float gold,"FINE_SL_RATE"::float silver,"GR_TOUCH"::float touch,"GR_TAX_PRC"::float tax,
              "GR_RATE"::float rate,"GR_TAX_RATE"::float taxrate,"GR_PR_TOUCH"::float prtouch,"GR_PR_RATE"::float prrate,
              "CASH_AMT"::float cash,"ADD_USER" au,"ADD_DATE" ad,"OP_GL_RATE"::float op
         FROM "RATE_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$2 AND "VCH_DATE"=$3::date
        ORDER BY "SR_NO"`,
      tenantId,
      lc,
      date,
    );
  const strip = (rows: Array<Record<string, unknown>>) => rows;
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const id of [tenantId, OTHER_TENANT])
      for (const { table_name } of tables)
        await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, id);
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await seedCompany(runtime, OTHER_TENANT, '01');
    for (const lc of ['00', '02', '03'])
      await exec(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,'01',$2,$3)`,
        tenantId,
        lc,
        `Location ${lc}`,
      );
    for (const [code, name, type, touch, tax, prTouch, display] of GROUPS)
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","GR_TOUCH","TAX_PRC","GR_PURC_TOUCH","GR_RATE","RATE_DISPLAY")
         VALUES ($1,'01',$2,$3,$4,$5,$6,$7,11,$8)`,
        tenantId,
        code,
        name,
        type,
        touch,
        tax,
        prTouch,
        display,
      );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
      tenantId,
      ADMIN,
      await hashPassword(PASSWORD),
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '00', coYear: YEAR, loginName: ADMIN, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const setCookie = response.headers['set-cookie'];
    cookie = (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });

  beforeEach(async () => {
    await exec(`DELETE FROM "RATE_MAST" WHERE tenant_id=$1`, tenantId);
    await exec(`UPDATE "GROUP_MAST" SET "GR_RATE"=11 WHERE tenant_id=$1`, tenantId);
    await setEntitlement(null);
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('copies the location-00 day to every other location with only LC_CODE replaced when the company is entitled', async () => {
    await setEntitlement(true);
    const result = await save('00', D);
    expect(result.copiedTo).toEqual(['01', '02', '03']);
    const source = await dayRows('00', D);
    expect(source.map((r) => [r.gr, r.rate, r.taxrate, r.prrate])).toEqual([
      ['R18', 54000, 54000, 54720],
      ['R22', 64031, 65952, 66240],
      ['RSV', 763, 786, 765],
    ]);
    for (const lc of ['01', '02', '03']) expect(await dayRows(lc, D)).toEqual(source);
    // GR_RATE is the net Rate10gm, never GR_TAX_RATE (MS_RATE.cs:1920).
    expect(source[1]).toMatchObject({ rate: 64031, taxrate: 65952, name: null });
  });

  it('projects all 26 columns of an imported source day unchanged, preserving NULL versus zero, with only LC_CODE replaced', async () => {
    await setEntitlement(true);
    // An imported 00 day carries optional rates and metadata that an ordinary web save never writes.
    await exec(
      `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_TYPE","GR_TOUCH",
         "GR_TAX_PRC","GR_RATE","GR_TAX_RATE","GR_PR_TOUCH","GR_PR_RATE","FINE_GL_RATE","FINE_SL_RATE","FINE_GL_PR_RATE",
         "FINE_SL_PR_RATE","DOLLAR_GL_RATE","DOLLAR_SL_RATE","EMP_CODE","MAIN_USER","CASH_AMT","ADD_USER","ADD_DATE",
         "AND_TRFR","OP_GL_RATE")
       VALUES ($1,'01','00',$2,$3::date,1,'R22','G',91.6,3,64031,65952,92,66240,72000,85000,71000,84000,2301.25,27.75,
               'E01','imported',0,'seeder','2026-11-23 10:00:00','Y',123.45),
              ($1,'01','00',$2,$3::date,2,'RSV','S',92.5,3,763,786,90,765,72000,85000,0,0,0,0,
               NULL,NULL,NULL,NULL,NULL,NULL,NULL)`,
      tenantId,
      YEAR,
      D,
    );
    const projection = `"CO_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","FINE_GL_RATE","FINE_SL_RATE","GR_RATE","GR_TOUCH",
      "GR_TYPE","EMP_CODE","CASH_AMT","MAIN_USER","ADD_USER","ADD_DATE","GR_PR_TOUCH","GR_PR_RATE","FINE_GL_PR_RATE",
      "FINE_SL_PR_RATE","DOLLAR_GL_RATE","DOLLAR_SL_RATE","AND_TRFR","GR_TAX_RATE","GR_TAX_PRC","OP_GL_RATE"`;
    // The production copy primitive, on a source day a web save cannot write.
    await copyDailyRateDay(runtime, { tenantId, coCode: '01', lcCode: '00', coYear: YEAR }, D, [
      '01',
      '02',
    ]);
    const cols = projection.replace(/\s+/g, '');
    const [diff] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM (
         SELECT ${cols} FROM "RATE_MAST" WHERE tenant_id=$1 AND "LC_CODE"='00' AND "VCH_DATE"=$2::date
         EXCEPT SELECT ${cols} FROM "RATE_MAST" WHERE tenant_id=$1 AND "LC_CODE"='02' AND "VCH_DATE"=$2::date) d`,
      tenantId,
      D,
    );
    expect(diff?.n).toBe(0);
    const nulls = await query<Array<Record<string, unknown>>>(
      `SELECT "CASH_AMT" cash,"ADD_USER" au,"AND_TRFR" tr,"OP_GL_RATE" op FROM "RATE_MAST"
        WHERE tenant_id=$1 AND "LC_CODE"='02' AND "SR_NO"=2`,
      tenantId,
    );
    expect(nulls[0]).toEqual({ cash: null, au: null, tr: null, op: null });
    const first = await query<Array<Record<string, unknown>>>(
      `SELECT "CASH_AMT"::float cash,"AND_TRFR" tr,"OP_GL_RATE"::float op,"DOLLAR_GL_RATE"::float usd
         FROM "RATE_MAST" WHERE tenant_id=$1 AND "LC_CODE"='01' AND "SR_NO"=1 AND "VCH_DATE"=$2::date`,
      tenantId,
      D,
    );
    expect(first[0]).toEqual({ cash: 0, tr: 'Y', op: 123.45, usd: 2301.25 });
  });
  it('does not copy when the company has no entitlement row, or it is off', async () => {
    await save('00', D);
    for (const lc of ['01', '02', '03']) expect(await dayRows(lc, D)).toEqual([]);
    await setEntitlement(false);
    await save('00', D);
    for (const lc of ['01', '02', '03']) expect(await dayRows(lc, D)).toEqual([]);
    expect(await dayRows('00', D)).toHaveLength(3);
  });

  it('copies only from location 00: a save away from 00 never fans out', async () => {
    await setEntitlement(true);
    const result = await save('02', D);
    expect(result.copiedTo).toEqual([]);
    expect(await dayRows('00', D)).toEqual([]);
    expect(await dayRows('01', D)).toEqual([]);
    expect(await dayRows('03', D)).toEqual([]);
    expect(await dayRows('02', D)).toHaveLength(3);
  });

  it('replaces each destination day, leaves other days alone, and clears the copies when the source day has no priced group', async () => {
    await setEntitlement(true);
    await save('00', H, gridA);
    await save('00', D, gridA);
    await save('00', D, gridB, 73000, 86000);
    for (const lc of ['01', '02', '03']) {
      expect((await dayRows(lc, D)).map((r) => r.rate)).toEqual([54750, 64920, 773]);
      expect((await dayRows(lc, H)).map((r) => r.rate)).toEqual([54000, 64031, 763]);
    }
    await save('00', D, []);
    expect(await dayRows('00', D)).toEqual([]);
    for (const lc of ['01', '02', '03']) {
      expect(await dayRows(lc, D)).toEqual([]);
      expect(await dayRows(lc, H)).toHaveLength(3);
    }
  });

  it('keeps the entitlement, rows and copies of another tenant out of reach', async () => {
    await exec(
      `INSERT INTO "daily_rate_copy_entitlement"(tenant_id,co_code,enabled) VALUES ($1,'01',true)`,
      OTHER_TENANT,
    );
    await save('00', D);
    expect(await dayRows('01', D)).toEqual([]);
    const other = await query<unknown[]>(
      `SELECT 1 FROM "RATE_MAST" WHERE tenant_id=$1`,
      OTHER_TENANT,
    );
    expect(other).toEqual([]);
  });

  it('reads the entitlement at save time: a change committed before the save governs it', async () => {
    await setEntitlement(true);
    await setEntitlement(false);
    await save('00', D);
    expect(await dayRows('02', D)).toEqual([]);
    await setEntitlement(true);
    await save('00', D);
    expect(await dayRows('02', D)).toHaveLength(3);
  });

  it('writes GROUP_MAST.GR_RATE at 00 from the posted net rate and nothing else of the group', async () => {
    const before = await query<Array<Record<string, unknown>>>(
      `SELECT "GR_CODE" gr,"GR_TOUCH"::float touch,"TAX_PRC"::float tax,"RATE_DISPLAY" disp FROM "GROUP_MAST" WHERE tenant_id=$1 ORDER BY 1`,
      tenantId,
    );
    await save('00', H, gridB, 73000, 86000);
    const rates = await query<Array<{ gr: string; rate: number }>>(
      `SELECT "GR_CODE" gr,"GR_RATE"::float rate FROM "GROUP_MAST" WHERE tenant_id=$1 ORDER BY 1`,
      tenantId,
    );
    expect(rates).toEqual([
      { gr: 'R18', rate: 54750 },
      { gr: 'R22', rate: 64920 },
      { gr: 'RHD', rate: 11 },
      { gr: 'RSV', rate: 773 },
    ]);
    const after = await query<Array<Record<string, unknown>>>(
      `SELECT "GR_CODE" gr,"GR_TOUCH"::float touch,"TAX_PRC"::float tax,"RATE_DISPLAY" disp FROM "GROUP_MAST" WHERE tenant_id=$1 ORDER BY 1`,
      tenantId,
    );
    expect(after).toEqual(before);
  });

  it('rolls the whole save back when a destination write faults: no source, group or copy change survives', async () => {
    await setEntitlement(true);
    await save('00', D, gridA);
    const before = {
      source: await dayRows('00', D),
      c3: await dayRows('03', D),
      groups: await query(
        `SELECT "GR_CODE",("GR_RATE")::float FROM "GROUP_MAST" WHERE tenant_id=$1 ORDER BY 1`,
        tenantId,
      ),
    };
    await exec(`CREATE OR REPLACE FUNCTION wp33_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
      BEGIN IF NEW."LC_CODE"='03' AND NEW."GR_RATE"=64920 THEN RAISE EXCEPTION 'wp33 fault'; END IF; RETURN NEW; END $f$`);
    await exec(
      `CREATE TRIGGER wp33_fault BEFORE INSERT ON "RATE_MAST" FOR EACH ROW EXECUTE FUNCTION wp33_fault()`,
    );
    try {
      await expect(save('00', D, gridB, 73000, 86000)).rejects.toThrow();
    } finally {
      await exec(`DROP TRIGGER IF EXISTS wp33_fault ON "RATE_MAST"`);
      await exec(`DROP FUNCTION IF EXISTS wp33_fault()`);
    }
    expect({
      source: await dayRows('00', D),
      c3: await dayRows('03', D),
      groups: await query(
        `SELECT "GR_CODE",("GR_RATE")::float FROM "GROUP_MAST" WHERE tenant_id=$1 ORDER BY 1`,
        tenantId,
      ),
    }).toEqual(before);
    expect((await dayRows('01', D)).map((r) => r.rate)).toEqual([54000, 64031, 763]);
  });

  it('serializes a location-00 copy against a local save of a destination: one complete writer, no mixture', async () => {
    await setEntitlement(true);
    const results = await Promise.allSettled([
      save('00', D, gridA, 72000, 85000),
      save('02', D, gridB, 73000, 86000),
    ]);
    expect(results.map((r) => r.status)).toEqual(['fulfilled', 'fulfilled']);
    const c2 = await dayRows('02', D);
    expect(c2).toHaveLength(3);
    expect(new Set(c2.map((r) => r.gold)).size).toBe(1);
    // Whichever ran last wins: either the copy of A or the local B, never half of each.
    expect([72000, 73000]).toContain(c2[0]!.gold);
    expect((await dayRows('01', D)).map((r) => r.rate)).toEqual([54000, 64031, 763]);
  });

  it('refuses a request that tries to switch the copy on: no body field grants the entitlement', async () => {
    const response = await app.inject({
      method: 'POST',
      url: '/daily-rate',
      headers: { cookie },
      payload: { date: D, goldRate: 72000, silverRate: 85000, rows: gridA, copyToLocations: true },
    });
    expect(response.statusCode).toBe(400);
    expect(await dayRows('00', D)).toEqual([]);
    expect(await dayRows('01', D)).toEqual([]);
  });

  describe('main-window labels (Rate_1 to Rate_7)', () => {
    const labels = async (date: string) => {
      const response = await app.inject({
        method: 'GET',
        url: `/daily-rate/labels?date=${date}`,
        headers: { cookie },
      });
      expect(response.statusCode, response.body).toBe(200);
      return response.json() as { labels: Array<{ text: string; grCode: string }>; empty: string };
    };
    it('shows only the own location, only RATE_DISPLAY = Y, in SR_NO order, with two decimals', async () => {
      await save('00', D);
      await save('02', D, gridB, 73000, 86000);
      const own = await labels(D);
      expect(own.labels.map((l) => l.text)).toEqual([
        'Rate Gold 18K  -  54000.00',
        'Rate Gold 22K  -  64031.00',
        'Rate Silver 925  -  763.00',
      ]);
    });
    it('has no fallback: another day, another location or no row reads ToDays Rate', async () => {
      await save('02', D);
      await save('00', H);
      const none = await labels(D);
      expect(none.labels).toEqual([]);
      expect(none.empty).toBe('ToDays Rate :');
    });
    it('hides a RATE_DISPLAY = N group and caps the list at seven', async () => {
      for (let i = 1; i <= 9; i += 1) {
        const code = `X${i}`;
        await exec(
          `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","GR_TOUCH","TAX_PRC","GR_PURC_TOUCH","RATE_DISPLAY")
           VALUES ($1,'01',$2,$3,'G',90,0,90,'Y')`,
          tenantId,
          code,
          `Extra ${i}`,
        );
      }
      try {
        const rows = [
          ...gridA,
          { grCode: 'RHD', touch: 50, taxPct: 0, rate: 100, taxRate: 100, prRate: 100 },
          ...Array.from({ length: 9 }, (_, i) => ({
            grCode: `X${i + 1}`,
            touch: 90,
            taxPct: 0,
            rate: 1000 + i,
            taxRate: 1000 + i,
            prRate: 0,
          })),
        ];
        await save('00', D, rows);
        const seven = await labels(D);
        expect(seven.labels).toHaveLength(7);
        expect(seven.labels.some((l) => l.grCode === 'RHD')).toBe(false);
      } finally {
        await exec(`DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE" LIKE 'X%'`, tenantId);
      }
    });
  });
  void strip;
});
