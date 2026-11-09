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
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteReceipt,
  deleteReceiptLines,
  editPayment,
  editReceipt,
  getPayment,
  getReceipt,
  postPayment,
  postPaymentLines,
  postReceipt,
  postReceiptLines,
} from '../src/modules/finance/finance.js';
import {
  FINANCE_DATE_OUTSIDE_YEAR_MESSAGE,
  FINANCE_EMPLOYEE_REQUIRED_MESSAGE,
} from '../src/modules/finance/lifecycle.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import { financeVoucherData, financeVoucherHtml } from '../src/modules/finance/financeVoucher.js';
import { recentVouchers } from '../src/modules/vouchers/list.js';

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

async function financeFootprint() {
  const [row] = (await owner.$queryRawUnsafe(
    `SELECT
       (SELECT count(*)::int FROM "CASH_DATA" WHERE tenant_id=$1) cash,
       (SELECT count(*)::int FROM "PAY_DATA" WHERE tenant_id=$1) pay,
       (SELECT count(*)::int FROM "PAY_DETL" WHERE tenant_id=$1) detail,
       (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) ledger,
       (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1) rojmel,
       (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) hidden,
       (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits`,
    TENANT,
  )) as Array<Record<string, number>>;
  return row;
}

/** Every row of the Cash/Bank write set, so a refused edit can be compared column by column. */
async function financeRows() {
  const out: Record<string, unknown[]> = {};
  for (const table of [
    'CASH_DATA',
    'PAY_DATA',
    'PAY_DETL',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'TEMP_BOOK_DATA',
    'DELETE_DATA',
  ]) {
    out[table] = await owner.$queryRawUnsafe(
      `SELECT to_jsonb(t)::text AS row FROM "${table}" t WHERE tenant_id=$1 ORDER BY 1`,
      TENANT,
    );
  }
  return out;
}

async function seedPaymentBook() {
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
}

describe.runIf(RUN)('cash and bank voucher fiscal-year boundary', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
  });

  it('refuses every receipt/payment writer outside the open year without changing any voucher table', async () => {
    const outside = '2024-03-31';
    const attempts: Array<[string, () => Promise<unknown>]> = [
      [
        'single receipt',
        () =>
          postReceipt(runtime, {
            scope,
            partyAc: PARTY,
            amount: 900,
            mode: 'cash',
            vchDate: outside,
          } as never),
      ],
      [
        'single payment',
        () =>
          postPayment(runtime, {
            scope: { ...scope, coBook: '002' },
            partyAc: PARTY,
            amount: 900,
            mode: 'cash',
            vchDate: outside,
          } as never),
      ],
      [
        'multi-line receipt',
        () =>
          postReceiptLines(runtime, {
            scope,
            mode: 'cash',
            vchDate: outside,
            lines: [{ partyAc: PARTY, amount: 900 }],
          } as never),
      ],
      [
        'multi-line payment',
        () =>
          postPaymentLines(runtime, {
            scope: { ...scope, coBook: '002' },
            mode: 'cash',
            vchDate: outside,
            lines: [{ partyAc: PARTY, amount: 900 }],
          } as never),
      ],
    ];

    const before = await financeFootprint();
    for (const [name, attempt] of attempts) {
      await expect(attempt(), name).rejects.toThrow(FINANCE_DATE_OUTSIDE_YEAR_MESSAGE);
      expect(await financeFootprint(), name).toEqual(before);
    }
  });

  it('refuses an out-of-year receipt or payment edit with the year text before the lock date, changing no row', async () => {
    await seedPaymentBook();
    const receipt = await postReceipt(runtime, {
      scope,
      partyAc: PARTY,
      amount: 900,
      mode: 'cash',
      vchDate: '2024-04-10',
    } as never);
    const payment = await postPayment(runtime, {
      scope: { ...scope, coBook: '002' },
      partyAc: PARTY,
      amount: 400,
      mode: 'cash',
      vchDate: '2024-04-10',
    } as never);
    // 2024-03-31 is both outside the year and on or before the lock date. TR_CASH.cs:2937-2947 checks the year
    // first, so the operator must see the year text, not the lock text.
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2`, '2024-04-05', TENANT);
    const before = await financeRows();

    await expect(
      editReceipt(
        runtime,
        { scope, partyAc: PARTY, amount: 950, mode: 'cash', vchDate: '2024-03-31' } as never,
        receipt.vchNo,
      ),
    ).rejects.toThrow(FINANCE_DATE_OUTSIDE_YEAR_MESSAGE);
    await expect(
      editPayment(
        runtime,
        {
          scope: { ...scope, coBook: '002' },
          partyAc: PARTY,
          amount: 450,
          mode: 'cash',
          vchDate: '2024-03-31',
        } as never,
        payment.vchNo,
      ),
    ).rejects.toThrow(FINANCE_DATE_OUTSIDE_YEAR_MESSAGE);
    // Control: an in-year date on or before the lock date is still refused by the lock.
    await expect(
      editReceipt(
        runtime,
        { scope, partyAc: PARTY, amount: 950, mode: 'cash', vchDate: '2024-04-03' } as never,
        receipt.vchNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await financeRows()).toEqual(before);
  });
});

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

  it('a multi-line RECEIPT writes one CASH_DATA row per grid line, numbered by SR_NO, and no PAY_DETL', async () => {
    // TR_CASH.cs:2995-3060 walks the grid and adds ONE CASH_DATA row per line that has an account and a
    // non-zero amount + kasar: SR_NO = the grid's Sr column (:3027), AC_CODE/AC_NAME (:3032-3033), REC_AMT
    // (:3034), KASAR_AMT (:3036), IT_DESC from the Remark column (:3037). Cash_Ledr then keys each line's legs
    // STR(SR_NO)+code (Ac_Ledr.cs:567). TR_CASH writes no PAY_DETL. The web wrote one aggregate row carrying the
    // first party and the summed amount, plus a PAY_DETL row per line.
    const lines = [
      { partyAc: PARTY, partyName: 'CASH PARTY', amount: 1250.5, kasar: 10.5, itDesc: 'first' },
      { partyAc: PARTY, partyName: 'CASH PARTY', amount: 749.25, kasar: 0.25, itDesc: 'second' },
    ];
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,2,$5,'Cash Received','CASH REC','I')`,
      TENANT,
      CO,
      LC,
      BOOK,
      KASAR,
    );
    const before = await financeFootprint();
    const result = await postReceiptLines(runtime, {
      scope,
      mode: 'cash',
      vchDate: '2024-04-03',
      lines,
    } as never);
    // MSG_TOT_FILL (TR_CASH.cs:1848-1855): the Amount total is Σ column 5.
    expect(result.total).toBe(1999.75);
    const heads = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr, "AC_CODE" ac, "AC_NAME" name, "REC_AMT"::float amt, "KASAR_AMT"::float kasar,
              "IT_DESC" descr, "REC_AC_CODE" rec, "VCH_NO" vch
         FROM "CASH_DATA" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(heads).toEqual(
      lines.map((l, i) => ({
        sr: i + 1,
        ac: l.partyAc,
        name: l.partyName,
        amt: l.amount,
        kasar: l.kasar,
        descr: l.itDesc,
        rec: CASH,
        vch: '00001',
      })),
    );
    const after = await financeFootprint();
    expect(after!.detail! - before!.detail!).toBe(0);
    expect(after!.cash! - before!.cash!).toBe(2);
    // Per line: 01 party Cr amount / 02 cash Dr amount / 03 party Cr kasar / 04 kasar Dr kasar.
    expect((await legs()).map((r) => [r.k.slice(21).trim(), r.ac, r.dr, r.cr])).toEqual([
      ['101', PARTY, 0, 1250.5],
      ['102', CASH, 1250.5, 0],
      ['103', PARTY, 0, 10.5],
      ['104', KASAR, 10.5, 0],
      ['201', PARTY, 0, 749.25],
      ['202', CASH, 749.25, 0],
      ['203', PARTY, 0, 0.25],
      ['204', KASAR, 0.25, 0],
    ]);
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

describe.runIf(RUN)('a multi-line receipt is read back as one voucher of N rows', () => {
  const lines = [
    { partyAc: PARTY, partyName: 'CASH PARTY', amount: 1250.5, kasar: 10.5, itDesc: 'first' },
    { partyAc: '000927', partyName: 'SECOND PARTY', amount: 749.25, kasar: 0.25, itDesc: 'second' },
  ];
  beforeEach(async () => {
    await wipe();
    await seed();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'000927','SECOND PARTY','L')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,2,$5,'Cash Received','CASH REC','I')`,
      TENANT,
      CO,
      LC,
      BOOK,
      KASAR,
    );
  });
  afterAll(async () => {
    await wipe();
  });
  const post = () =>
    postReceiptLines(runtime, {
      scope,
      mode: 'cash',
      vchDate: '2024-04-03',
      mainUser: 'ADMIN',
      lines,
    } as never);

  it('shares one voucher identity, prints every line and reopens every line', async () => {
    const { vchNo } = await post();
    // Every row carries the same hidden number, time and user (the single receipt's identity) and one
    // TEMP_BOOK_DATA row holds the hidden number.
    const ids = (await owner.$queryRawUnsafe(
      `SELECT DISTINCT "HD_VCH_NO" hd, "VCH_TIME"::text t, "MAIN_USER" u FROM "CASH_DATA" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ hd: string; t: string; u: string }>;
    expect(ids).toHaveLength(1);
    expect(ids[0]!.hd).toMatch(/^\d{5}$/);
    expect(ids[0]!.u).toBe('ADMIN');
    expect((await financeFootprint())!.hidden).toBe(1);

    // TR_CASH prints all CASH_DATA rows in SR_NO order (TR_CASH.cs:3151, :3288, :3333).
    const doc = await financeVoucherData(runtime, 'receipt', { ...scope, vchNo });
    expect(doc).not.toBeNull();
    expect(doc!.header.REC_AMT).toBe(1999.75);
    expect(doc!.header.KASAR_AMT).toBe(10.75);
    expect(doc!.lines.map((l) => [l.AC_CODE, l.IT_REMARK, l.NET_AMT])).toEqual([
      [PARTY, 'first', 1250.5],
      ['000927', 'second', 749.25],
    ]);
    const html = financeVoucherHtml('receipt', doc!.header, doc!.lines, { party: doc!.party });
    expect(html).toContain('CASH PARTY, SECOND PARTY');
    expect(html).toContain('1,250.50');
    expect(html).toContain('749.25');
    // Net received = Σ amount + Σ kasar = 1999.75 + 10.75.
    expect(html).toContain('2,010.50');

    // DISPLAY_DATA refills the grid from every row (TR_CASH.cs:2742-2834).
    const opened = await getReceipt(runtime, scope, vchNo);
    expect(opened.amount).toBe(1999.75);
    expect(opened.kasar).toBe(10.75);
    expect(opened.lines).toEqual(
      lines.map((l) => ({
        partyAc: l.partyAc,
        partyName: l.partyName,
        amount: l.amount,
        kasar: l.kasar,
        itDesc: l.itDesc,
      })),
    );

    // The voucher list shows the voucher once with its whole amount.
    const listed = await recentVouchers(runtime, scope, 'CASH_DATA', BOOK);
    expect(listed.map((r) => r.total)).toEqual([1999.75]);
  });

  it('refuses a single-line edit of a grid voucher and changes no row', async () => {
    const { vchNo } = await post();
    const before = await financeRows();
    await expect(
      editReceipt(
        runtime,
        { scope, partyAc: PARTY, amount: 10, mode: 'cash', vchDate: '2024-04-03' } as never,
        vchNo,
      ),
    ).rejects.toThrow('voucher is ambiguous');
    expect(await financeRows()).toEqual(before);
  });

  it('deletes the whole grid voucher with one DELETE_DATA row per line (TR_CASH.cs:3209), by either route', async () => {
    for (const remove of [deleteReceipt, deleteReceiptLines]) {
      const { vchNo } = await post();
      await remove(runtime, { scope, vchNo, deleteUser: 'ADMIN' });
      const left = await financeFootprint();
      expect([left!.cash, left!.ledger, left!.rojmel, left!.hidden]).toEqual([0, 0, 0, 0]);
      const audit = (await owner.$queryRawUnsafe(
        `SELECT "SR_NO"::int sr, "AC_CODE" ac, "VCH_VAL_CR"::float cr FROM "DELETE_DATA"
          WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
        TENANT,
        String(vchNo).padStart(5, '0'),
      )) as Array<Record<string, unknown>>;
      expect(audit).toEqual([
        { sr: 1, ac: PARTY, cr: 1250.5 },
        { sr: 2, ac: '000927', cr: 749.25 },
      ]);
      await owner.$executeRawUnsafe(`DELETE FROM "DELETE_DATA" WHERE tenant_id=$1`, TENANT);
    }
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

  it('a BANK payment writes its kasar on 09/10, not on its own amount legs 07/08', async () => {
    // Bank_Ledr (Ac_Ledr.cs:585-610): BANK PAY 07 party Dr REC_AMT / 08 bank Cr REC_AMT, then 09 party Dr
    // KASAR_AMT / 10 kasar (BOOK_DETL slot 2) Cr KASAR_AMT. The cash payment's kasar codes 07/08 (Cash_Ledr,
    // :581-583) are the bank payment's amount codes, so reusing them wrote two legs under each key.
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'012',2,$4,'Bank Payment','BANK PAY','O')`,
      TENANT,
      CO,
      LC,
      KASAR,
    );
    // The web writes payments to PAY_DATA, so number this book from it (otherwise the second voucher re-draws 00001).
    await exec(
      `UPDATE "BOOK_DATA" SET "BOOK_TBL_NAME"='PAY_DATA' WHERE tenant_id=$1 AND "CO_BOOK"='012'`,
      TENANT,
    );
    const amount = 3000;
    const kasar = 25.5;
    await postPayment(runtime, {
      scope: { ...scope, coBook: '012' },
      partyAc: PARTY,
      amount,
      kasar,
      mode: 'cheque',
      bankAc: '000754',
      vchDate: '2024-04-01',
    } as never);
    await postPaymentLines(runtime, {
      scope: { ...scope, coBook: '012' },
      mode: 'cheque',
      bankAc: '000754',
      vchDate: '2024-04-02',
      lines: [{ partyAc: PARTY, amount, kasar }],
    } as never);
    const rows = await legs();
    const shape = (vch: string) =>
      rows
        .filter((r) => r.k.slice(16, 21) === vch)
        .map((r) => [r.k.slice(21).trim(), r.ac, r.dr, r.cr]);
    const expected = [
      ['107', PARTY, amount, 0],
      ['108', '000754', 0, amount],
      ['109', PARTY, kasar, 0],
      ['110', KASAR, 0, kasar],
    ];
    expect(shape('00001')).toEqual(expected);
    expect(shape('00002')).toEqual(expected);
  });
  /**
   * TR_CASH's employee box (tEmpCode): EMP_CODE_MANDATORY = 'Y' refuses a blank (TR_CASH.cs:2907-2911, before the
   * year and lock checks), the code is stored on the CASH_DATA / PAY_DATA row (:3050) and shown again when the
   * voucher is opened (:2753-2754).
   */
  describe('employee code', () => {
    const rec = (empCode?: string) =>
      postReceipt(runtime, {
        scope,
        partyAc: PARTY,
        amount: 1000,
        mode: 'cash',
        vchDate: '2024-04-01',
        empCode,
      } as never);
    const pay = (empCode?: string) =>
      postPayment(runtime, {
        scope: { ...scope, coBook: '002' },
        partyAc: PARTY,
        amount: 1000,
        mode: 'cash',
        vchDate: '2024-04-01',
        empCode,
      } as never);
    const setMandatory = (v: string) =>
      exec(
        `UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"=$3 WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        TENANT,
        CO,
        v,
      );

    beforeEach(async () => {
      await seedPaymentBook();
      await exec(
        `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,$2,'E01','RAJU')`,
        TENANT,
        CO,
      );
    });

    it('refuses a blank employee when it is mandatory, before anything is written', async () => {
      await setMandatory('Y');
      const before = await financeFootprint();
      await expect(rec()).rejects.toThrow(FINANCE_EMPLOYEE_REQUIRED_MESSAGE);
      await expect(pay('  ')).rejects.toThrow(FINANCE_EMPLOYEE_REQUIRED_MESSAGE);
      expect(await financeFootprint()).toEqual(before);
    });

    it('refuses an employee who is not in the company', async () => {
      const before = await financeFootprint();
      await expect(rec('E99')).rejects.toThrow('Employee E99 is not in this company');
      expect(await financeFootprint()).toEqual(before);
    });

    it('stores the employee on the receipt and payment header, reads it back, and keeps it through an edit', async () => {
      await setMandatory('Y');
      const r = await rec('E01');
      const p = await pay('E01');
      const heads = (await owner.$queryRawUnsafe(
        `SELECT 'R' k, "EMP_CODE" e FROM "CASH_DATA" WHERE tenant_id=$1
         UNION ALL SELECT 'P', "EMP_CODE" FROM "PAY_DATA" WHERE tenant_id=$1 ORDER BY 1`,
        TENANT,
      )) as Array<{ k: string; e: string }>;
      expect(heads).toEqual([
        { k: 'P', e: 'E01' },
        { k: 'R', e: 'E01' },
      ]);
      expect((await getReceipt(runtime, scope, r.vchNo)).empCode).toBe('E01');
      expect((await getPayment(runtime, { ...scope, coBook: '002' }, p.vchNo)).empCode).toBe('E01');
      await editReceipt(
        runtime,
        {
          scope,
          partyAc: PARTY,
          amount: 1200,
          mode: 'cash',
          vchDate: '2024-04-01',
          empCode: 'E01',
        } as never,
        r.vchNo,
      );
      expect((await getReceipt(runtime, scope, r.vchNo)).empCode).toBe('E01');
    });

    it('leaves the employee empty when it is not mandatory and none is given', async () => {
      const r = await rec();
      expect((await getReceipt(runtime, scope, r.vchNo)).empCode).toBe('');
    });
  });
});
