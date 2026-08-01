/**
 * Line components are PERSISTED at the bill-amount precision.
 *
 * WHY A DATABASE TEST AND NOT A UNIT TEST
 * A unit test on `roundBillTotal` passes whether or not the sale path calls it — which is exactly what
 * happened: removing the rounding from `sales.ts` left 43 lifecycle tests green and a unit test on the policy
 * green too. The control failing to fail is what forced this test into existence. The assertion has to be on
 * the row that reaches the database.
 *
 * WHAT THE DESKTOP DOES, measured on the real customer database:
 *   * every money column in all 245 SL_DETL rows is a whole rupee
 *   * NET_AMT = ITM_AMT + LBR_AMT + OTH_AMT on 244 of 245
 *   * 4.600 x 77 = 354.20 is stored as 354.00; 4.600 x 16.09 = 74.014 as 74.00
 *
 * NOT asserted: a derivation. ITM_AMT equals ROUND(nwt x rate, 0) on only 134 of 220 candidate rows and
 * LBR_AMT on 84 of 166, because the desktop grid lets the operator overtype an amount. The rule that survives
 * the data is "whatever the component is, it is rounded", so this test pins the rounding and not the formula.
 *
 * Precision comes from `CO_SET_NEW.TOT_AMT_ROF`, which is 0 for this customer. The second test sets it to 2 to
 * prove the behaviour is configured rather than hardcoded — a whole-rupee assertion alone could be satisfied by
 * a hardcoded `Math.round`.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { createSale } from '../src/modules/sales/sales.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'line-rounding';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '027';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({
  datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
});

const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const r of rows) {
    await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

/** Seed exactly what a sale on book 027 needs, with the amount precision under the caller's control. */
async function seed(totAmtRof: number) {
  const exec = (sql: string, ...p: unknown[]) =>
    withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","SL_AMT_TYPE","TAX_ROF","ALL_ROF_REMOVE","ITM_RATE_ROF")
     VALUES ($1,$2,'N',2,'N',2,'N',2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,$3,2)`,
    TENANT,
    CO,
    totAmtRof,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name] of [
    ['000888', 'ROUNDING PARTY'],
    ['00004', 'SALES SILVER A/C'],
    ['00085', 'GST TAX'],
    ['00001', 'CASH ON HAND'],
    ['00057', 'KASAR A/C'],
  ]) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,$4,$5,'L')`,
      TENANT,
      CO,
      LC,
      code,
      name,
    );
  }
  // A zero-rate tax row: this test is about amount rounding, so tax is kept out of it, but the resolver still
  // requires a configured rate rather than assuming one.
  await exec(
    `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
     VALUES ($1,$2,'00',0,'N','NO TAX',0,'00085')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC") VALUES ($1,$2,'01','SILVER','00004')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
     VALUES ($1,$2,'ORS','SILVER ORNAMENT','S','01')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Silver Tax Invoice','TSSL','SALES','O','Y','SL_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  for (const [sr, ac] of [
    [1, '00004'],
    [2, '00001'],
    [3, '00057'],
  ] as const) {
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,$5,$6,'Silver Tax Invoice','SALES','O')`,
      TENANT,
      CO,
      LC,
      BOOK,
      sr,
      ac,
    );
  }
}

/** 4.600 g at 77.00 with per-gram labour 16.09 — the real voucher's second line. */
const line = {
  itCode: 'ORS',
  metal: 'S' as const,
  pcs: 1,
  grossWt: 4.6,
  netWt: 4.6,
  touch: 0,
  rate: 77,
  labourRate: 16.09,
  labourType: 'per_gram' as const,
};

/** The zero-rate seed plus the real GST code 10, for the tax allocation case. */
async function seedTaxed() {
  await seed(0);
  const exec = (sql: string, ...p: unknown[]) =>
    withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
  for (const [sr, group, name, prc, ac] of [
    [0, 'N', 'GST 3%', 3.0, '00085'],
    [1, 'SGST', 'SGST 1.5%', 1.5, '00085'],
    [2, 'CGST', 'CGST 1.5%', 1.5, '00085'],
  ] as const) {
    await exec(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'10',$3,$4,$5,$6,$7)`,
      TENANT,
      CO,
      sr,
      group,
      name,
      prc,
      ac,
    );
  }
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
     VALUES ($1,$2,'MA925','SILVER PAYAL','S','01')`,
    TENANT,
    CO,
  );
}

async function postAndRead() {
  await createSale(
    runtime,
    {
      scope,
      acCode: '000888',
      acName: 'ROUNDING PARTY',
      vchDate: '2024-04-06',
      taxCode: '00',
      taxRatePct: 0,
      interState: false,
      mainUser: 'rounding-test',
    },
    [line],
  );
  const rows = (await owner.$queryRawUnsafe(
    `SELECT "ITM_AMT"::float a, "LBR_AMT"::float l, "NET_AMT"::float n
       FROM "SL_DETL" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
    TENANT,
  )) as { a: number; l: number; n: number }[];
  return rows[0]!;
}

/** The reference voucher's two lines: a labour-only line at 1087 and a metal+labour line at 428. */
const twoLines = [
  {
    itCode: 'ORS',
    metal: 'S' as const,
    pcs: 1,
    grossWt: 10.36,
    netWt: 10.36,
    touch: 0,
    rate: 0,
    labourType: 'fixed' as const,
    labourFixed: 1087,
  },
  line,
];

describe.runIf(RUN)('per-line tax allocation', () => {
  beforeEach(wipe);

  it('rounds the line tax ONCE, and the lines sum to the header tax', async () => {
    // Measured on the real customer database: IT_TAX_AMT equals ROUND(NET_AMT x rate, 2) on all 132 taxed rows,
    // and the per-line values sum EXACTLY to the header TAX_AMT on all 91 taxed vouchers.
    //
    // The web reconstructed it as `half * 2`, which rounds twice: 1087 x 3% = 32.61, halved to 16.305, rounded
    // to 16.30, doubled back to 32.60. Each line can lose a paisa independently, so the sum-to-header property
    // cannot hold - which is why that property is asserted here and not just the individual value.
    await seedTaxed();
    await createSale(
      runtime,
      {
        scope,
        acCode: '000888',
        acName: 'ROUNDING PARTY',
        vchDate: '2024-04-06',
        taxCode: '10',
        taxRatePct: 3,
        interState: false,
        mainUser: 'tax-test',
      },
      twoLines,
    );
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "IT_TAX_AMT"::float t FROM "SL_DETL" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      TENANT,
    )) as { t: number }[];
    expect(rows).toHaveLength(2);
    expect(rows[0]!.t).toBeCloseTo(32.61, 2);
    expect(rows[1]!.t).toBeCloseTo(12.84, 2);

    const header = (await owner.$queryRawUnsafe(
      `SELECT "TAX_AMT"::float t FROM "SL_DATA" WHERE tenant_id=$1`,
      TENANT,
    )) as { t: number }[];
    // 32.61 + 12.84 = 45.45 exactly. The double-rounded version gave 32.60 + 12.85, which also sums to 45.45
    // by accident here - so the individual values matter too, and both are asserted.
    expect(rows[0]!.t + rows[1]!.t).toBeCloseTo(header[0]!.t, 2);
  });
});

describe.runIf(RUN)('persisted line component rounding', () => {
  beforeEach(wipe);
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('rounds each component to whole rupees when TOT_AMT_ROF is 0', async () => {
    await seed(0);
    const row = await postAndRead();
    // 4.600 x 77 = 354.20 -> 354, exactly as the desktop stored it.
    expect(row.a).toBe(354);
    // 4.600 x 16.09 = 74.014 -> 74.
    expect(row.l).toBe(74);
    // And the composition holds on the ROUNDED components, which is the 244-of-245 rule.
    expect(row.n).toBe(428);
  });

  it('keeps paise when the same setting is 2, so this is configured and not hardcoded', async () => {
    await seed(2);
    const row = await postAndRead();
    expect(row.a).toBeCloseTo(354.2, 2);
    expect(row.l).toBeCloseTo(74.01, 2);
    expect(row.n).toBeCloseTo(428.21, 2);
  });
});
