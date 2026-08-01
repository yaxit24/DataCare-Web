/**
 * Cash receipt ledger shape — family 3.
 *
 * WHY THIS FILE EXISTS
 * `postReceipt`'s ledger was **completely untested**. One test file referenced the function and made no
 * assertion about the rows it writes, which is how a netted three-leg shape survived against a desktop that
 * writes four.
 *
 * MEASURED on book 001 (`CASH REC`), all 162 legs:
 *
 *   01  party  Cr amount    02  cash   Dr amount     56 each
 *   03  party  Cr kasar     04  kasar  Dr kasar      25 each
 *
 * Real voucher 001/00001 is ONE `CASH_DATA` line — `REC_AMT` 60000.00, `KASAR_AMT` 771.00 — and it writes FOUR
 * legs. The party is credited TWICE: once against cash, once against kasar.
 *
 * The web wrote three, crediting the party once for `amount + kasar`. **Both balance**, so no balance assertion
 * could see it — but the leg count differs, so a per-account ledger report showed one line where the desktop
 * shows two.
 *
 * KEY LAYOUT. The tail is `<line><leg>` as one field right-aligned in 12, giving 33 characters:
 * `01002024-202500100001         101`. Nothing sits at positions 22-23, which is why reading
 * `SUBSTRING(LEDR_KEY,22,2)` there returns spaces — the signal that led to decoding it. Three families now use
 * three different layouts and no two agree.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { postReceipt } from '../src/modules/finance/finance.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'cash-legs';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '001';
const PARTY = '000926';
const CASH = '00001';
const KASAR = '00057';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
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

async function seed() {
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
    [PARTY, 'CASH PARTY'],
    [CASH, 'CASH ON HAND'],
    [KASAR, 'KASAR JAVK A/C'],
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
     VALUES ($1,$2,$3,$4,'Cash Received','CREC','CASH REC','I','Y','CASH_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,$4,1,$5,'Cash Received','CASH REC','I')`,
    TENANT,
    CO,
    LC,
    BOOK,
    CASH,
  );
}

async function legs() {
  return (await owner.$queryRawUnsafe(
    `SELECT "LEDR_KEY" k, coalesce("AC_CODE",'-') ac, coalesce("LD_CODE",'-') ld,
            "DR_AMT"::float dr, "CR_AMT"::float cr
       FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
    TENANT,
  )) as { k: string; ac: string; ld: string; dr: number; cr: number }[];
}

describe.runIf(RUN)('cash receipt ledger legs', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('writes a pair per movement, so a receipt with a discount has FOUR legs', async () => {
    // The real voucher's figures: one line, 60000.00 received against a 771.00 write-off.
    await postReceipt(runtime, {
      scope,
      partyAc: PARTY,
      amount: 60000,
      kasar: 771,
      kasarAc: KASAR,
      mode: 'cash',
      bankAc: CASH,
      vchDate: '2024-04-01',
    } as never);

    const rows = await legs();
    // FOUR, not three. This is the assertion the netted shape fails.
    expect(rows).toHaveLength(4);
    for (const r of rows) expect(r.k).toHaveLength(33);

    const [l1, l2, l3, l4] = rows;
    // 01 party Cr amount / 02 cash Dr amount
    expect(l1!.k.slice(21).trim()).toBe('101');
    expect(l1!.ac).toBe(PARTY);
    expect(l1!.cr).toBe(60000);
    expect(l2!.k.slice(21).trim()).toBe('102');
    expect(l2!.ac).toBe(CASH);
    expect(l2!.dr).toBe(60000);
    // 03 party Cr kasar / 04 kasar Dr kasar — the party credited a SECOND time.
    expect(l3!.k.slice(21).trim()).toBe('103');
    expect(l3!.ac).toBe(PARTY);
    expect(l3!.cr).toBe(771);
    expect(l4!.k.slice(21).trim()).toBe('104');
    expect(l4!.ac).toBe(KASAR);
    expect(l4!.dr).toBe(771);
    // Every leg carries its contra; the old kasar leg had none.
    for (const r of rows) expect(r.ld).not.toBe('-');
  });

  it('writes only the amount pair when there is no discount', async () => {
    // 56 of book 001's 162 legs are the amount pair and only 25 vouchers carry a kasar, so the two-leg case is
    // the common one and must not gain empty kasar legs.
    await postReceipt(runtime, {
      scope,
      partyAc: PARTY,
      amount: 3000,
      mode: 'cash',
      bankAc: CASH,
      vchDate: '2024-04-01',
    } as never);
    const rows = await legs();
    expect(rows).toHaveLength(2);
    expect(rows.map((r) => r.k.slice(21).trim())).toEqual(['101', '102']);
  });
});
