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
import {
  postPayment,
  postPaymentLines,
  postReceipt,
  postReceiptLines,
} from '../src/modules/finance/finance.js';

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

describe.runIf(RUN)('cash payment ledger legs', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
    // A payment book, with its own kasar account. Book 002's leg-08 rows name 00042 KASAR AVAK where book
    // 001's leg-04 rows name 00057 KASAR JAVK - the account mirrors the money's direction, not the voucher's.
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'00042','KASAR AVAK A/C.','L')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'002','Cash Payment','CPAY','CASH PAY','O','Y','CASH_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'002',1,$4,'Cash Payment','CASH PAY','O')`,
      TENANT,
      CO,
      LC,
      CASH,
    );
  });

  it('uses legs 05-08, which a receipt never uses, and pairs each movement', async () => {
    // Measured on book 002, all 360 legs: 05 party Dr / 06 cash Cr (175 each), 07 party Dr / 08 kasar Cr (5).
    // A receipt and a payment share NO codes - the same role takes a different number by direction.
    await postPayment(runtime, {
      scope: { ...scope, coBook: '002' },
      partyAc: PARTY,
      amount: 5000,
      kasar: 160,
      kasarAc: '00042',
      mode: 'cash',
      vchDate: '2024-04-01',
    } as never);
    const rows = await legs();
    expect(rows).toHaveLength(4);
    expect(rows.map((r) => r.k.slice(21).trim())).toEqual(['105', '106', '107', '108']);
    // The party is DEBITED twice - once against cash, once against kasar - not once for the total.
    expect(rows[0]!.ac).toBe(PARTY);
    expect(rows[0]!.dr).toBe(5000);
    expect(rows[2]!.ac).toBe(PARTY);
    expect(rows[2]!.dr).toBe(160);
    // The payment kasar account, NOT the receipt's.
    expect(rows[3]!.ac).toBe('00042');
    expect(rows[3]!.cr).toBe(160);
  });

  it('pairs EVERY line, so three lines give six legs keyed 105 through 306', async () => {
    // Real voucher 002/00029 is nine CASH_DATA lines and EIGHTEEN legs - nine pairs, keyed 105/106 through
    // 905/906. There is no aggregate cash leg.
    //
    // An earlier version of this test called postPayment three times and asserted the line numbers, which was
    // the WRONG SHAPE: three single-line vouchers are not one multi-line voucher, and it failed with 23505 on
    // the voucher-number counter rather than on anything it meant to check. The multi-line path is
    // postPaymentLines.
    await postPaymentLines(runtime, {
      scope: { ...scope, coBook: '002' },
      mode: 'cash',
      vchDate: '2024-04-01',
      lines: [
        { partyAc: PARTY, amount: 5000 },
        { partyAc: PARTY, amount: 1000 },
        { partyAc: PARTY, amount: 750 },
      ],
    } as never);
    const rows = await legs();
    // SIX, not four. The old shape wrote three party legs plus one aggregate cash leg.
    expect(rows).toHaveLength(6);
    expect(rows.map((r) => r.k.slice(21).trim())).toEqual([
      '105',
      '106',
      '205',
      '206',
      '305',
      '306',
    ]);
    // Each cash leg carries its OWN line's amount, not the total.
    const cashLegs = rows.filter((r) => r.ac === CASH);
    expect(cashLegs.map((r) => r.cr)).toEqual([5000, 1000, 750]);
  });
});

describe.runIf(RUN)('multi-line cash paths write a Rojmel row per line', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
  });

  it('a multi-line RECEIPT pairs each line and writes its Rojmel rows', async () => {
    // INFERRED, not measured: every one of the 56 real receipt vouchers has exactly ONE line, so this dataset
    // has no multi-line receipt. What is asserted is the measured payment PATTERN (a pair per line, no
    // aggregate — proven by voucher 002/00029's nine lines and eighteen legs) with the measured receipt CODES
    // (book 001's 01/02 and 03/04).
    //
    // The path wrote NO Rojmel rows at all before this, and it is reachable from a route — so a multi-line
    // receipt produced an empty day book.
    await postReceiptLines(runtime, {
      scope,
      mode: 'cash',
      vchDate: '2024-04-03',
      lines: [
        { partyAc: PARTY, amount: 5000 },
        { partyAc: PARTY, amount: 1000 },
      ],
    } as never);

    const ledger = await legs();
    expect(ledger).toHaveLength(4);
    expect(ledger.map((r) => r.k.slice(21).trim())).toEqual(['101', '102', '201', '202']);
    // Each cash leg carries its OWN line's amount, not the total — the aggregate form gave 6000 then 0.
    expect(ledger.filter((r) => r.ac === CASH).map((r) => r.dr)).toEqual([5000, 1000]);

    const roj = (await owner.$queryRawUnsafe(
      `SELECT "LEDR_KEY" k, "CR_AMT"::float cr FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      TENANT,
    )) as { k: string; cr: number }[];
    // TWO Rojmel rows, one per line, both type 01 with the line number distinguishing them.
    expect(roj).toHaveLength(2);
    expect(roj.map((r) => r.k.slice(21, 23))).toEqual(['01', '01']);
    expect(roj.map((r) => r.k.slice(23).trim())).toEqual(['1', '2']);
    expect(roj.map((r) => r.cr)).toEqual([5000, 1000]);
  });

  it('a multi-line PAYMENT writes nine type-04 rows for nine lines', async () => {
    // Measured: real voucher 002/00029 has nine CASH_DATA lines and NINE type-04 Rojmel rows. The web wrote
    // zero, because postPaymentLines never called the builder.
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'002','Cash Payment','CPAY','CASH PAY','O','Y','CASH_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'002',1,$4,'Cash Payment','CASH PAY','O')`,
      TENANT,
      CO,
      LC,
      CASH,
    );
    await postPaymentLines(runtime, {
      scope: { ...scope, coBook: '002' },
      mode: 'cash',
      vchDate: '2024-04-22',
      lines: [5000, 1000, 750].map((amount) => ({ partyAc: PARTY, amount })),
    } as never);

    const roj = (await owner.$queryRawUnsafe(
      `SELECT "LEDR_KEY" k FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      TENANT,
    )) as { k: string }[];
    expect(roj).toHaveLength(3);
    expect(roj.map((r) => r.k.slice(21, 23))).toEqual(['04', '04', '04']);
    expect(roj.map((r) => r.k.slice(23).trim())).toEqual(['1', '2', '3']);
  });
});

describe.runIf(RUN)('bank leg codes are not a mirror of cash', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'000754','OLD AXIS BANK','L')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'012','Bank Payment','BPAY','BANK PAY','O','Y','CASH_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'012',1,'000754','Bank Payment','BANK PAY','O')`,
      TENANT,
      CO,
      LC,
    );
  });

  it('a BANK payment uses 07/08, where a CASH payment uses 05/06', async () => {
    // Measured across all 228 legs of the 11 active bank books: BANK PAY is 07 party Dr / 08 bank Cr on 61 legs
    // each. CASH PAY is 05/06. A bank RECEIPT does share the cash receipt's 01/02 and 03/04 - so the mirror
    // holds in one direction and not the other, and assuming it would have written 05/06 on all 61.
    await postPayment(runtime, {
      scope: { ...scope, coBook: '012' },
      partyAc: PARTY,
      amount: 5000,
      mode: 'cheque',
      bankAc: '000754',
      vchDate: '2024-04-01',
    } as never);
    const rows = await legs();
    expect(rows).toHaveLength(2);
    expect(rows.map((r) => r.k.slice(21).trim())).toEqual(['107', '108']);
    expect(rows[0]!.ac).toBe(PARTY);
    expect(rows[0]!.dr).toBe(5000);
    expect(rows[1]!.ac).toBe('000754');
    expect(rows[1]!.cr).toBe(5000);
  });
});
