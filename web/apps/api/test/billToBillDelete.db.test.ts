/**
 * Reversing a bill-to-bill settlement — plan item F1.4, previously blocked as decision D-4.
 *
 * WHY IT WAS BLOCKED, AND WHY MEASUREMENT UNBLOCKED IT
 * ===================================================
 * `settleBills` INCREMENTS each targeted bill's `REC_AMT`/`KASAR_AMT` in place and records no per-bill
 * allocation, so subtracting the right amount back is impossible once two vouchers have touched the same
 * bill. That looked like a design decision the owner had to make.
 *
 * Reading the desktop dissolved it: **`UPDATE BILL_OS_DATA` appears ZERO times in `TR_BILL_TO.cs`'s delete
 * path.** The desktop deletes rows keyed to the SETTLING voucher's own `VCH_NO` (`:4746`) plus `CASH_DATA`,
 * `AC_DATA`, `ROJ_MEL_DATA`, `REMARK_DATA`, `TEMP_BOOK_DATA` and `SL_PR_DETL`, writes a `DELETE_DATA` row —
 * and leaves the increments it applied to the bills it paid exactly where they are.
 *
 * The two models already agreed: `BILL_OS_DATA` rows belong to the voucher that CREATED the outstanding.
 * Measured on the real database — 363 of 365 rows on sales books, 1 on labour work, and 1 on book 210
 * `BILL REC` itself, for the case where a settlement leaves its own balance. `REC_AMT` non-zero on 222 of
 * 365, `KASAR_AMT` on 121, so in-place accumulation is the desktop's convention too.
 *
 * ## THE LAST TEST HERE PINS A FLAW ON PURPOSE
 * Deleting a settlement does NOT restore the bills it paid. That is the desktop's behaviour and arguably a
 * defect in it. Replicating it is deliberate: the point of the migration is that the web agrees with the
 * system the business reconciles against, and a more correct reversal here would make the web's outstanding
 * balances differ from the desktop's — worse than sharing the flaw. Changing it means changing both systems
 * and persisting the per-bill allocation first.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import {
  listOpenBills,
  settleBills,
  deleteBillSettlement,
} from '../src/modules/finance/billToBill.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'bill-to-bill-del';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
/** Real book 210 `BILILRC` MAIN_BOOK 'BILL REC', BOOK_TBL_NAME CASH_DATA. */
const BOOK = '210';
/** The bill being settled sits on a SALES book, which is where BILL_OS_DATA rows live. */
const SALE_BOOK = '032';
const PARTY = '00050';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx: any) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  );
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seed() {
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'B2B Co')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,$3,'Main')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","CASH_LIMIT","FINE_STK_TYPE") VALUES ($1,$2,0,'F')`,
    TENANT,
    CO,
  );
  await exec(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
  for (const [code, name] of [
    [PARTY, 'CUSTOMER A'],
    ['CASH', 'CASH ON HAND'],
    ['KASAR', 'KASAR A/C'],
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
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Bill Receipt','BILRC','BILL REC','I','Y','CASH_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  // Two open bills on the sale book, which is where BILL_OS_DATA rows live in the real data.
  for (const [vch, amt] of [
    ['00001', 5000],
    ['00002', 3000],
  ] as Array<[string, number]>) {
    await exec(
      `INSERT INTO "BILL_OS_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
          "AC_CODE","BILL_AMT","REC_AMT","KASAR_AMT","VCH_DATE")
       VALUES ($1,$2,$3,$4,$5,$6,1,$7,$8,0,0,'2024-04-05')`,
      TENANT,
      CO,
      LC,
      YEAR,
      SALE_BOOK,
      vch,
      PARTY,
      amt,
    );
  }
}

const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };

async function rowCount(table: string, vchNo: string) {
  const rows: Array<{ n: number }> = await owner.$queryRawUnsafe(
    `SELECT count(*)::int AS n FROM "${table}"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
    TENANT,
    CO,
    BOOK,
    vchNo,
  );
  return Number(rows[0]?.n ?? 0);
}

/** The receipt applied to a specific bill on the sale book. */
async function billRec(vch: string) {
  const rows: Array<{ rec: number }> = await owner.$queryRawUnsafe(
    `SELECT COALESCE("REC_AMT",0)::float8 AS rec FROM "BILL_OS_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
    TENANT,
    CO,
    SALE_BOOK,
    vch,
  );
  return Number(rows[0]?.rec ?? 0);
}

const settle = () =>
  settleBills(runtime, {
    scope,
    acCode: PARTY,
    mode: 'cash',
    cashAc: 'CASH',
    vchDate: '2024-05-20',
    allocations: [{ coBook: SALE_BOOK, vchNo: '00001', recAmt: 2000 }],
  } as never);

describe.runIf(RUN)('bill-to-bill reversal (plan F1.4)', () => {
  beforeAll(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('removes the settlement voucher and audits the deletion', async () => {
    const created = await settle();
    const vchNo = String(created.vchNo).padStart(5, '0');
    expect(created.settled).toBe(1);
    expect(await rowCount('CASH_DATA', vchNo)).toBeGreaterThan(0);
    expect(await rowCount('AC_DATA', vchNo)).toBeGreaterThanOrEqual(2);

    await deleteBillSettlement(runtime, { scope, vchNo, deleteUser: 'b2b-del' });

    expect(await rowCount('CASH_DATA', vchNo), 'header gone').toBe(0);
    expect(await rowCount('AC_DATA', vchNo), 'ledger legs gone').toBe(0);
    // The desktop writes a DELETE_DATA row classified by the book's BOOK_SNAME (TR_BILL_TO.cs:5027).
    expect(await rowCount('DELETE_DATA', vchNo), 'deletion is audited').toBeGreaterThan(0);
  });

  it('refuses to reverse a voucher that does not exist', async () => {
    await expect(
      deleteBillSettlement(runtime, { scope, vchNo: '99999', deleteUser: 'b2b-del' }),
    ).rejects.toThrow(/not found/i);
  });

  it('PINS THE DESKTOP FLAW: the settled bill stays partly paid after the reversal', async () => {
    /**
     * `UPDATE BILL_OS_DATA` appears zero times in the desktop's delete path, so the receipt it applied to the
     * bill survives the deletion. Replicated deliberately — see the file header. If this assertion is ever
     * changed to expect 0, BOTH systems must change together and the per-bill allocation must be persisted
     * first, or the web's outstanding balances will diverge from the desktop the business reconciles against.
     */
    const before = await billRec('00001');
    const created = await settle();
    const vchNo = String(created.vchNo).padStart(5, '0');
    const afterSettle = await billRec('00001');
    // The settlement really did move the bill, so the assertion below is not vacuous.
    expect(afterSettle).toBeCloseTo(before + 2000, 2);

    await deleteBillSettlement(runtime, { scope, vchNo, deleteUser: 'b2b-del' });

    expect(
      await billRec('00001'),
      'desktop parity: the receipt applied to the bill is NOT restored',
    ).toBeCloseTo(afterSettle, 2);
    // And the bill therefore does not reappear as fully open.
    const open = await listOpenBills(runtime, { tenantId: TENANT, coCode: CO, lcCode: LC }, PARTY);
    const bill = (open as unknown as Array<Record<string, unknown>>).find(
      (b) => String(b.vchNo ?? b.VCH_NO ?? '').trim() === '00001',
    );
    if (bill) {
      const bal = Number(bill.openBalance ?? bill.balance ?? 0);
      expect(bal).toBeLessThan(5000);
    }
  });

  it('leaves an untargeted bill completely untouched', async () => {
    /**
     * Targets bill 00002 and asserts 00001 is unaffected. Earlier tests in this file have already consumed
     * most of 00001's balance — the module's own overpay guard fires if a settlement exceeds the open
     * balance, which is why each test must pick a bill with room rather than reusing one.
     */
    const untargetedBefore = await billRec('00001');
    const created = await settleBills(runtime, {
      scope,
      acCode: PARTY,
      mode: 'cash',
      cashAc: 'CASH',
      vchDate: '2024-05-21',
      allocations: [{ coBook: SALE_BOOK, vchNo: '00002', recAmt: 500 }],
    } as never);
    expect(created.settled).toBe(1);

    await deleteBillSettlement(runtime, {
      scope,
      vchNo: String(created.vchNo).padStart(5, '0'),
      deleteUser: 'b2b-del',
    });
    expect(await billRec('00001')).toBeCloseTo(untargetedBefore, 2);
  });
});
