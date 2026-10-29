/**
 * Batch receipt kasar write-off account — slot-2 fallback (G151).
 *
 * WHY THIS FILE EXISTS
 * `postBatchReceipt` was the one receipt path that still REQUIRED the caller to name the kasar
 * (write-off) account: `requirePostingAccount('kasar', l.kasarAc ?? input.kasarAc, ...)` threw when
 * neither was supplied. The batch grid has no kasar-account column and the route
 * (`POST /batch-receipt`) forwards only { scope, vchDate, lines }, so EVERY on-screen write-off
 * entered on a batch collection was refused — the exact defect the single-row form fixed by
 * resolving BOOK_DETL slot 2 (desktop Ac_Ledr.cs:571-581). This proves the batch path now resolves
 * the same slot-2 account, and still refuses a book whose slot 2 collides with the slot-1 settlement.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { postBatchReceipt } from '../src/modules/finance/batchReceipt.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'batch-kasar';
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
  // Slot 1 = the cash settlement account.
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

async function slot2(acCode: string) {
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,$4,2,$5,'Cash Received','CASH REC','I')`,
    TENANT,
    CO,
    LC,
    BOOK,
    acCode,
  );
}

async function legs() {
  return (await owner.$queryRawUnsafe(
    `SELECT coalesce("AC_CODE",'-') ac, "DR_AMT"::float dr, "CR_AMT"::float cr
       FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
    TENANT,
  )) as { ac: string; dr: number; cr: number }[];
}

describe.runIf(RUN)('batch receipt kasar write-off account', () => {
  beforeEach(async () => {
    await wipe();
    await seedBase();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('a kasar line with NO explicit account posts the write-off to BOOK_DETL slot 2', async () => {
    await slot2(KASAR);
    // The route forwards only { scope, vchDate, lines } — no voucher-level kasarAc — and the line
    // carries no kasarAc either, exactly as the grid sends it.
    await postBatchReceipt(runtime, {
      scope,
      vchDate: '2024-04-01',
      lines: [{ partyAc: PARTY, amount: 1000, mode: 'cash', kasarAmt: 15 }],
    } as never);

    const rows = await legs();
    // Dr cash 1000, Dr kasar 15, Cr party 1015 — three legs, balanced.
    expect(rows).toHaveLength(3);
    const kasarLeg = rows.find((r) => r.ac === KASAR);
    expect(kasarLeg, 'write-off posted to the slot-2 kasar account').toBeTruthy();
    expect(kasarLeg!.dr).toBe(15);
    expect(rows.find((r) => r.ac === CASH)!.dr).toBe(1000);
    expect(rows.find((r) => r.ac === PARTY)!.cr).toBe(1015);
  });

  it('an explicit per-line kasarAc still wins over the slot-2 default', async () => {
    await slot2(KASAR);
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'00099','SPECIAL WRITE OFF','L')`,
      TENANT,
      CO,
      LC,
    );
    await postBatchReceipt(runtime, {
      scope,
      vchDate: '2024-04-01',
      lines: [{ partyAc: PARTY, amount: 1000, mode: 'cash', kasarAmt: 15, kasarAc: '00099' }],
    } as never);
    const rows = await legs();
    expect(rows.find((r) => r.ac === '00099')!.dr).toBe(15);
    expect(rows.find((r) => r.ac === KASAR)).toBeUndefined();
  });

  it('a book whose slot 2 collides with the slot-1 settlement is refused', async () => {
    await slot2(CASH); // slot 2 names the cash account — posting the write-off there overstates cash
    await expect(
      postBatchReceipt(runtime, {
        scope,
        vchDate: '2024-04-01',
        lines: [{ partyAc: PARTY, amount: 1000, mode: 'cash', kasarAmt: 15 }],
      } as never),
    ).rejects.toThrow();
    // The voucher rolled back — no partial ledger.
    expect(await legs()).toHaveLength(0);
  });

  it('a line with no kasar needs no slot-2 account at all', async () => {
    // No slot 2 configured; a plain collection must still post cleanly.
    await postBatchReceipt(runtime, {
      scope,
      vchDate: '2024-04-01',
      lines: [{ partyAc: PARTY, amount: 1000, mode: 'cash' }],
    } as never);
    const rows = await legs();
    expect(rows).toHaveLength(2);
    expect(rows.find((r) => r.ac === CASH)!.dr).toBe(1000);
    expect(rows.find((r) => r.ac === PARTY)!.cr).toBe(1000);
  });
});
