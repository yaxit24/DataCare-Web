/**
 * Order-cancel refund/kasar accounts are configured, not literal (N155, G163).
 *
 * WHY THIS FILE EXISTS
 * `cancelSalesOrderAdjust` used to fall back to the string literals `'CASH'` (refund settlement) and
 * `'KASAR'` (write-off) when the request named neither. Those codes do not exist in a real company's
 * AC_MAST, so a cancel without an explicit account posted the refund/kasar legs to a non-existent
 * ledger. The desktop posts the adjustment through `Ac_Ledr.Order_Adj_Ledr` (TR_SL_ORD_ADJ.cs:3665),
 * which answers both accounts from the cancel book's BOOK_DETL slots (slot 1 = settlement, slot 2 =
 * kasar). This proves the web path now resolves the SAME configured accounts, fails closed when the
 * book is unconfigured (refuses rather than inventing one), and still honours an explicit account.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { cancelSalesOrderAdjust } from '../src/modules/sales/salesOrder.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'ordcancel-acct';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const SOR = 'SOR';
const ORC = 'ORC';
const CUST = '000500';
const CASH_AC = '00001'; // configured slot-1 cash account (NOT the literal 'CASH')
const KASAR_AC = '00057'; // configured slot-2 kasar account

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: SOR };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const r of rows) {
    await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seedBase() {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF","ALL_ROF_REMOVE")
     VALUES ($1,$2,'N',2,2,2,'N')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name] of [
    [CUST, 'ORDER CUSTOMER'],
    [CASH_AC, 'CASH ON HAND'],
    [KASAR_AC, 'KASAR JAVK A/C'],
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
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,'SOR','Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA'),
            ($1,$2,$3,'ORC','Order Cancel','SADJ','ORDER CANCEL','O','Y','SL_ORD_ADJ')`,
    TENANT,
    CO,
    LC,
  );
  // A pending sales order with an advance of 1000 and a total of 2500.
  await exec(
    `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME","ADV_AMT","TOT_AMT")
     VALUES ($1,$2,$3,$4,'SOR','00007',$5,'ORDER CUSTOMER',1000,2500)`,
    TENANT,
    CO,
    LC,
    YEAR,
    CUST,
  );
}

/** Configure the cancel book's slots: slot 1 = cash settlement, slot 2 = kasar write-off. */
async function configureOrcSlots() {
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,'ORC',1,$4,'ORDER CANCEL','O'),
            ($1,$2,$3,'ORC',2,$5,'ORDER CANCEL','O')`,
    TENANT,
    CO,
    LC,
    CASH_AC,
    KASAR_AC,
  );
}

const refundLegs = async () =>
  (await owner.$queryRawUnsafe(
    `SELECT "AC_CODE" ac, "DR_AMT"::float dr, "CR_AMT"::float cr
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ORDER BY "LEDR_KEY"`,
    TENANT,
  )) as { ac: string; dr: number; cr: number }[];

describe.runIf(RUN)('order-cancel refund/kasar accounts are configured, not literal', () => {
  beforeEach(async () => {
    await wipe();
    await seedBase();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('resolves the refund account from the cancel book slot 1 when the request names none', async () => {
    await configureOrcSlots();
    const r = await cancelSalesOrderAdjust(runtime, {
      scope,
      vchNo: 7,
      vchDate: '2024-04-01',
      // No paidAc — the book slot must answer, NOT the literal 'CASH'.
    });
    expect(r.refunded).toBe(1000);
    const legs = await refundLegs();
    // Cr the configured cash account for the refund; Dr the customer to clear the advance.
    const refund = legs.find((l) => l.cr === 1000);
    expect(refund, 'refund leg exists').toBeTruthy();
    expect(refund!.ac).toBe(CASH_AC); // the real account, not 'CASH'
    expect(legs.find((l) => l.ac === 'CASH')).toBeUndefined();
    expect(legs.find((l) => l.ac === CUST)!.dr).toBe(1000);
  });

  it('resolves the kasar account from slot 2 when a write-off is taken without an explicit account', async () => {
    await configureOrcSlots();
    const r = await cancelSalesOrderAdjust(runtime, {
      scope,
      vchNo: 7,
      vchDate: '2024-04-01',
      paidAmt: 800,
      kasarAmt: 200,
    });
    expect(r.refunded).toBe(800);
    expect(r.kasar).toBe(200);
    const legs = await refundLegs();
    expect(legs.find((l) => l.ac === CASH_AC)!.cr).toBe(800);
    expect(legs.find((l) => l.ac === KASAR_AC)!.cr).toBe(200); // slot-2, not 'KASAR'
    expect(legs.find((l) => l.ac === 'KASAR')).toBeUndefined();
    // Dr customer clears advance+kasar = 1000.
    expect(legs.find((l) => l.ac === CUST)!.dr).toBe(1000);
  });

  it('honours an explicit refund account over the configured slot', async () => {
    await configureOrcSlots();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'00002','HDFC BANK','L')`,
      TENANT,
      CO,
      LC,
    );
    const r = await cancelSalesOrderAdjust(runtime, {
      scope,
      vchNo: 7,
      vchDate: '2024-04-01',
      paidAc: '00002',
    });
    expect(r.refunded).toBe(1000);
    const legs = await refundLegs();
    expect(legs.find((l) => l.cr === 1000)!.ac).toBe('00002');
    expect(legs.find((l) => l.ac === CASH_AC && l.cr > 0)).toBeUndefined();
  });

  it('fails closed when the cancel book has no configured settlement account (refuses, does not invent CASH)', async () => {
    // No ORC slots configured and no explicit paidAc — the refund must be refused, not posted to 'CASH'.
    await expect(
      cancelSalesOrderAdjust(runtime, { scope, vchNo: 7, vchDate: '2024-04-01' }),
    ).rejects.toThrow();
    // Nothing was posted (the voucher rolled back).
    expect(await refundLegs()).toHaveLength(0);
  });
});
