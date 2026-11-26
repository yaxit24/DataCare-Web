import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
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
  });
  afterAll(async () => {
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

  it('a sale of a seeded gold ornament posts only to accounts in AC_MAST, whole-rupee with a round-off leg', async () => {
    const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'SL' };
    const sold = await createSale(
      runtime,
      {
        scope,
        mainUser: 'fresh',
        acCode: 'FCUST',
        acName: 'FRESH CUSTOMER',
        vchDate: DAY,
        taxRatePct: 3,
        taxCode: '10',
        interState: false,
        cashAmt: 66000,
      } as any,
      [{ itCode: 'ORG', pcs: 1, grossWt: 10, netWt: 10, touch: 91.6, rate: 6123.45 }] as any,
    );
    const legs = await rows<{ ac: string; dr: number; cr: number }>(
      `SELECT "AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA"
        WHERE "CO_CODE"=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
      CO,
      String(sold.vchNo).padStart(5, '0'),
    );
    expect(legs.length).toBeGreaterThan(2);
    expect(await missingAccounts(legs)).toEqual([]);
    // 61,234.50 + GST 3% 1,837.035 = 63,071.535: whole rupee 63,072 (TOT_AMT_ROF 0), and the web's ROUNDOFF leg
    // carries the difference (web/docs/FIRST-REAL-COMPARISON.md section 3.4; the desktop does not write that leg).
    const head = await rows<{ net: number }>(
      `SELECT "NET_AMT"::float net FROM "SL_DATA" WHERE "CO_CODE"=$1 AND "VCH_NO"=$2`,
      CO,
      String(sold.vchNo).padStart(5, '0'),
    );
    expect(Number.isInteger(head[0]!.net)).toBe(true);
    expect(legs.map((l) => l.ac)).toContain('ROUNDOFF');
    expect(legs.map((l) => l.ac)).toContain('SALES');
  });

  it('a purchase of a seeded gold ornament posts only to accounts in AC_MAST', async () => {
    const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'PR' };
    const bought = await createPurchase(
      runtime,
      {
        scope,
        mainUser: 'fresh',
        acCode: 'FSUPL',
        acName: 'FRESH SUPPLIER',
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
      } as any,
      [{ itCode: 'ORG', pcs: 1, grossWt: 10, netWt: 10, touch: 91.6, rate: 6050 }] as any,
    );
    const legs = await rows<{ ac: string }>(
      `SELECT "AC_CODE" ac FROM "AC_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"='PR' AND "VCH_NO"=$2`,
      CO,
      String(bought.vchNo).padStart(5, '0'),
    );
    expect(legs.length).toBeGreaterThan(1);
    expect(await missingAccounts(legs)).toEqual([]);
    expect(legs.map((l) => l.ac)).toContain('PURCHASE');
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
