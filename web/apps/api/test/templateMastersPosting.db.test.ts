import { PrismaClient, withTenant } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { createPurchase } from '../src/modules/purchase/purchase.js';
import { createSale } from '../src/modules/sales/sales.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * A fresh company is seeded with the installer masters (MS_YEAR.cs:1555-1592). Their account columns name installer
 * AC_MAST codes (00003-00035) that a web company does not have, so seedCompany maps them to the web role accounts
 * (desktopTemplateMasters.ts DESKTOP_ACCOUNT_ROLES). These tests prove the result on a company that nothing else
 * touched: every account the seeded rows name exists in AC_MAST, and a sale and a purchase of a seeded gold ornament
 * (ORG, group GO) post only to accounts that exist. A fresh company also rounds bills like the desktop installer
 * (CO_SET_NEW.TOT_AMT_ROF 0): the whole-rupee total with the web's own balancing round-off leg.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;
const TENANT = 'template-masters-posting';
const CO = '01';
const LC = '01';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

d('fresh company: seeded masters name accounts the company has', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });
  const runtime = new PrismaClient();
  let app: FastifyInstance;
  let cookie = '';
  const rows = <T = Record<string, any>>(sql: string, ...p: unknown[]): Promise<T[]> =>
    withTenant(runtime, TENANT, (tx: any) => tx.$queryRawUnsafe(sql, ...p));
  const wipe = async () => {
    const tables = (await owner.$queryRawUnsafe(
      `SELECT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    )) as Array<{ table_name: string }>;
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, TENANT);
  };
  const missingAccounts = async (ledgers: Array<{ ac: string }>) => {
    const have = new Set(
      (await rows(`SELECT "AC_CODE" c FROM "AC_MAST" WHERE "CO_CODE"=$1`, CO)).map((r) => r.c),
    );
    return [...new Set(ledgers.map((l) => l.ac))].filter((code) => !have.has(code));
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    await wipe();
    await seedCompany(runtime, TENANT, CO, { coName: 'Fresh Masters', lcCode: LC });
    await withTenant(runtime, TENANT, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE")
         VALUES ($1,$2,$3,'FCUST','FRESH CUSTOMER','20','L'),($1,$2,$3,'FSUPL','FRESH SUPPLIER','05','L')`,
        TENANT,
        CO,
        LC,
      ),
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,$2,'freshadm',$3,'ADMIN','Y','Y','Y','N')`,
      TENANT,
      CO,
      await hashPassword('Fresh-Masters!2026'),
    );
    app = await buildApp({
      prisma: runtime,
      secret: 'fresh-masters-posting-test-signing-secret-32',
      secureCookies: false,
    });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': TENANT },
      payload: {
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        loginName: 'freshadm',
        password: 'Fresh-Masters!2026',
      },
    });
    expect(login.statusCode, login.body).toBe(200);
    const setCookie = login.headers['set-cookie'];
    cookie = (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });
  afterAll(async () => {
    await app?.close();
    await wipe();
    await runtime.$disconnect();
    await owner.$disconnect();
  });

  it('every account code the seeded GROUP_MAST and BAL_GR rows name is in the seeded AC_MAST', async () => {
    const named = await rows<{ ac: string }>(
      `SELECT "SALE_AC" ac FROM "GROUP_MAST" WHERE "CO_CODE"=$1 AND "SALE_AC" IS NOT NULL
       UNION SELECT "PURC_AC" FROM "GROUP_MAST" WHERE "CO_CODE"=$1 AND "PURC_AC" IS NOT NULL
       UNION SELECT "SALE_AC" FROM "BAL_GR" WHERE "CO_CODE"=$1 AND "SALE_AC" IS NOT NULL
       UNION SELECT "PURC_AC" FROM "BAL_GR" WHERE "CO_CODE"=$1 AND "PURC_AC" IS NOT NULL
       UNION SELECT "CLOSING_AC" FROM "BAL_GR" WHERE "CO_CODE"=$1 AND "CLOSING_AC" IS NOT NULL
       UNION SELECT "OP_AC" FROM "BAL_GR" WHERE "CO_CODE"=$1 AND "OP_AC" IS NOT NULL
       UNION SELECT "CLG_AC" FROM "BAL_GR" WHERE "CO_CODE"=$1 AND "CLG_AC" IS NOT NULL`,
      CO,
    );
    expect(named.length).toBeGreaterThan(0);
    expect(await missingAccounts(named)).toEqual([]);
    // The gold group posts to the gold sale and purchase controls.
    expect(
      await rows(
        `SELECT "SALE_AC","PURC_AC" FROM "GROUP_MAST" WHERE "CO_CODE"=$1 AND "GR_CODE"='GO'`,
        CO,
      ),
    ).toEqual([{ SALE_AC: 'SALES', PURC_AC: 'PURCHASE' }]);
  });

  const legsOf = (book: string, vchNo: number) =>
    rows<{ ac: string; dr: number; cr: number }>(
      `SELECT "AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA"
        WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "AC_CODE"`,
      CO,
      book,
      String(vchNo).padStart(5, '0'),
    );
  const sell = (itCode: string, rate: number) =>
    createSale(
      runtime,
      {
        scope: { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'SL' },
        mainUser: 'fresh',
        acCode: 'FCUST',
        acName: 'FRESH CUSTOMER',
        vchDate: DAY,
        taxRatePct: 3,
        taxCode: '10',
        interState: false,
        cashAmt: 63067,
      } as any,
      [{ itCode, pcs: 1, grossWt: 10, netWt: 10, touch: 91.6, rate }] as any,
    );
  const buy = (itCode: string, rate: number) =>
    createPurchase(
      runtime,
      {
        scope: { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'PR' },
        mainUser: 'fresh',
        acCode: 'FSUPL',
        acName: 'FRESH SUPPLIER',
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
      } as any,
      [{ itCode, pcs: 1, grossWt: 10, netWt: 10, touch: 91.6, rate }] as any,
    );

  it('a sale of a seeded gold ornament posts only to accounts in AC_MAST, whole-rupee without a round-off leg', async () => {
    // CO_SET.ITM_RATE_ROF 0 rounds the rate 6123.45 to 6123 (MS_YEAR.cs:1568): line 10 g x 6,123 = 61,230.00; GST 3% =
    // 1,836.90; total 63,066.90; TOT_AMT_ROF 0 makes the bill 63,067. No round-off was typed, so the 0.10 is posted
    // nowhere, as on the desktop (owner decision 1B, web/docs/FIRST-REAL-COMPARISON.md section 3.4).
    const sold = await sell('ORG', 6123.45);
    const legs = await legsOf('SL', sold.vchNo);
    expect(await missingAccounts(legs)).toEqual([]);
    const byAc = Object.fromEntries(legs.map((l) => [l.ac, l]));
    expect(byAc.SALES).toMatchObject({ cr: 61230, dr: 0 });
    expect(byAc.GST).toMatchObject({ cr: 1836.9, dr: 0 });
    expect(byAc.ROUNDOFF).toBeUndefined();
    // The party leg carries the whole-rupee total.
    expect(legs.find((l) => l.ac === 'FCUST' && l.dr > 0)).toMatchObject({ dr: 63067 });
    expect(legs.reduce((sum, l) => sum + l.dr - l.cr, 0)).toBeCloseTo(0.1, 2);
  });

  it('a sale of the old-gold group posts to the OG account', async () => {
    const sold = await sell('OG', 6000);
    const legs = await legsOf('SL', sold.vchNo);
    expect(await missingAccounts(legs)).toEqual([]);
    expect(legs.find((l) => l.ac === 'OG')).toMatchObject({ cr: 60000 });
  });

  it('a purchase of a seeded gold ornament posts only to accounts in AC_MAST', async () => {
    const bought = await buy('ORG', 6050);
    const legs = await legsOf('PR', bought.vchNo);
    expect(await missingAccounts(legs)).toEqual([]);
    // The purchase amount is on fine: 10 g x 91.6 % x 6,050 = 55,418 (TR_PURC rate-per-fine basis).
    expect(legs.find((l) => l.ac === 'PURCHASE')).toMatchObject({ dr: 55418 });
  });

  it('a purchase of the old-gold group posts to OLDGOLD and of the old-silver group to the old-silver purchase account', async () => {
    const gold = await legsOf('PR', (await buy('OG', 5500)).vchNo);
    expect(await missingAccounts(gold)).toEqual([]);
    expect(gold.find((l) => l.ac === 'OLDGOLD')).toMatchObject({ dr: 50380 });
    const silver = await legsOf('PR', (await buy('OS', 80)).vchNo);
    expect(await missingAccounts(silver)).toEqual([]);
    expect(silver.find((l) => l.ac === 'OLDSLVPR')).toMatchObject({ dr: 733 }); // 10 g x 91.6 % x 80 = 732.8, whole rupee;
  });

  it('every other-type installer account the seeded groups name is a web account of the same group', async () => {
    expect(
      await rows(
        `SELECT "AC_CODE","AC_NAME","AC_GR" FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE" IN ('OTHSALE','OLDSLVPR','OTHPURC') ORDER BY 1`,
        CO,
      ),
    ).toEqual([
      { AC_CODE: 'OLDSLVPR', AC_NAME: 'PURCHASE OLD SILVER A/C', AC_GR: '30' },
      { AC_CODE: 'OTHPURC', AC_NAME: 'PURCHASE OTHER A/C', AC_GR: '30' },
      { AC_CODE: 'OTHSALE', AC_NAME: 'SALES OTHER A/C', AC_GR: '25' },
    ]);
    expect(
      await rows(
        `SELECT "GR_CODE","SALE_AC","PURC_AC" FROM "GROUP_MAST" WHERE "CO_CODE"=$1 AND "GR_CODE" IN ('OS','OT') ORDER BY 1`,
        CO,
      ),
    ).toEqual([
      { GR_CODE: 'OS', SALE_AC: 'OS', PURC_AC: 'OLDSLVPR' },
      { GR_CODE: 'OT', SALE_AC: 'OTHSALE', PURC_AC: 'OTHPURC' },
    ]);
  });

  it('the generic Accounts master creates an account and edits CASH on a fresh company (AC_LC_CODE_LEN is a numbering mode, not a length)', async () => {
    expect(await rows(`SELECT "AC_LC_CODE_LEN" FROM "CO_SET" WHERE "CO_CODE"=$1`, CO)).toEqual([
      { AC_LC_CODE_LEN: '1' },
    ]);
    const post = (method: 'POST' | 'PUT', payload: Record<string, unknown>) =>
      app.inject({
        method,
        url: '/masters/accounts',
        headers: { cookie },
        payload: payload as never,
      });
    const created = await post('POST', {
      AC_CODE: 'NEWACC1',
      AC_NAME: 'NEW ACCOUNT',
      AC_GR: '20',
    });
    expect(created.statusCode, created.body).toBe(201);
    const edited = await post('PUT', { AC_CODE: 'CASH', AC_NAME: 'CASH ON HAND EDITED' });
    expect(edited.statusCode, edited.body).toBe(200);
    expect(
      await rows(`SELECT "AC_NAME" FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"='CASH'`, CO),
    ).toEqual([{ AC_NAME: 'CASH ON HAND EDITED' }]);
  });

  it('seeds the desktop CO_SET rounding (TAX_ROF 2, LBR_ROF 0, ITM_RATE_ROF 0), CONV_MAST and the counter at the location', async () => {
    expect(
      await rows(
        `SELECT "TAX_ROF","LBR_ROF","ITM_RATE_ROF","PURC_WITH_LBR" FROM "CO_SET" WHERE "CO_CODE"=$1`,
        CO,
      ),
    ).toEqual([{ TAX_ROF: 2, LBR_ROF: 0, ITM_RATE_ROF: 0, PURC_WITH_LBR: 'Y' }]);
    expect(await rows(`SELECT "CON_CODE" FROM "CONV_MAST" WHERE "CO_CODE"=$1`, CO)).toEqual([
      { CON_CODE: 'INR' },
    ]);
    expect(
      await rows(`SELECT "LC_CODE","TABLE_CODE" FROM "TABLE_MAST" WHERE "CO_CODE"=$1`, CO),
    ).toEqual([{ LC_CODE: LC, TABLE_CODE: '001' }]);
  });
});
