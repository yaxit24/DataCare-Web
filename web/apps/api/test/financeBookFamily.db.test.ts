/**
 * D1 (PARITY-EVALUATION-2026-09-28): receipts and payments are written to the configured book, the
 * book must belong to the receipt/payment family and match the mode, and kasar posts against
 * BOOK_DETL slot 2.
 *
 * Contract and vectors D1-3..D1-7:
 * parity-plan-2026-09-10/evidence/implementation-2026-09-29-eval-defects/contract.md.
 *
 * Desktop:
 * - Ac_Ledr.cs:571-581 joins `BOOK_DETL ... B.SR_NO = 2 AND A.KASAR_AMT <> 0` for the kasar legs:
 *   03/04 on CASH REC and 07/08 on CASH PAY.
 * - The accounts are the measured ones: book 001 slot 2 is 00057 KASAR JAVK, and book 002 slot 2 is
 *   00042 KASAR AVAK.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  postPayment,
  postPaymentLines,
  postReceipt,
  postReceiptLines,
} from '../src/modules/finance/finance.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'finance-book-family';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const PARTY = '000926';
const CASH = '00001';
const BANK = '000754';
const KASAR_JAVK = '00057';
const KASAR_AVAK = '00042';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scopeFor = (coBook: string) => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});
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

async function book(
  code: string,
  name: string,
  shortName: string,
  mainBook: string,
  inout: string,
  table: string,
  slots: Array<[number, string]>,
) {
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,$5,$6,$7,$8,'Y',$9)`,
    TENANT,
    CO,
    LC,
    code,
    name,
    shortName,
    mainBook,
    inout,
    table,
  );
  for (const [srNo, account] of slots) {
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9)`,
      TENANT,
      CO,
      LC,
      code,
      srNo,
      account,
      name,
      mainBook,
      inout,
    );
  }
}

async function seed() {
  await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
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
    [BANK, 'OLD AXIS BANK'],
    [KASAR_JAVK, 'KASAR JAVK A/C'],
    [KASAR_AVAK, 'KASAR AVAK A/C.'],
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
  await book('001', 'Cash Received', 'CREC', 'CASH REC', 'I', 'CASH_DATA', [
    [1, CASH],
    [2, KASAR_JAVK],
  ]);
  await book('002', 'Cash Payment', 'CPAY', 'CASH PAY', 'O', 'PAY_DATA', [
    [1, CASH],
    [2, KASAR_AVAK],
  ]);
  await book('011', 'Bank Received', 'BREC', 'BANK REC', 'I', 'CASH_DATA', [[1, BANK]]);
  await book('SAL', 'Sales', 'SAL', 'SALES', 'O', 'SL_DATA', [[1, CASH]]);
  // A web-provisioned receipt book from before this change: CASH in both slots.
  await book('RCT', 'Receipt', 'RCT', 'RECEIPT', 'I', 'CASH_DATA', [
    [1, 'CASH'],
    [2, 'CASH'],
  ]);
}

async function legs() {
  return (await owner.$queryRawUnsafe(
    `SELECT "CO_BOOK" book, "LEDR_KEY" k, coalesce("AC_CODE",'-') ac, "DR_AMT"::float dr, "CR_AMT"::float cr
       FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "CO_BOOK","LEDR_KEY"`,
    TENANT,
  )) as { book: string; k: string; ac: string; dr: number; cr: number }[];
}

async function rowCount(): Promise<number> {
  const [row] = (await owner.$queryRawUnsafe(
    `SELECT (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1)
          + (SELECT count(*) FROM "CASH_DATA" WHERE tenant_id=$1)
          + (SELECT count(*) FROM "PAY_DATA" WHERE tenant_id=$1)
          + (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1)
          + (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) AS n`,
    TENANT,
  )) as { n: bigint }[];
  return Number(row!.n);
}

describe.runIf(RUN)('D1 receipt/payment book family and slot-2 kasar', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('D1-3: a receipt write-off with no explicit account posts legs 03/04 to slot 2 (00057)', async () => {
    await postReceipt(runtime, {
      scope: scopeFor('001'),
      partyAc: PARTY,
      amount: 60000,
      kasar: 771,
      mode: 'cash',
      vchDate: '2024-04-01',
    } as never);
    const rows = await legs();
    expect(rows.map((r) => [r.k.slice(21).trim(), r.ac, r.dr, r.cr])).toEqual([
      ['101', PARTY, 0, 60000],
      ['102', CASH, 60000, 0],
      ['103', PARTY, 0, 771],
      ['104', KASAR_JAVK, 771, 0],
    ]);
    const [header] = (await owner.$queryRawUnsafe(
      `SELECT "REC_AMT"::float rec, "KASAR_AMT"::float kasar FROM "CASH_DATA" WHERE tenant_id=$1`,
      TENANT,
    )) as { rec: number; kasar: number }[];
    expect(header).toEqual({ rec: 60000, kasar: 771 });
    // The Rojmel kasar pair (types 02/03) needs the resolved account too; it used to read the request.
    const [rojmel] = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
      TENANT,
      KASAR_JAVK,
    )) as { n: number }[];
    expect(rojmel!.n).toBeGreaterThan(0);
  });

  it('D1-4: a payment write-off with no explicit account posts legs 07/08 to slot 2 (00042)', async () => {
    await postPayment(runtime, {
      scope: scopeFor('002'),
      partyAc: PARTY,
      amount: 5000,
      kasar: 160,
      mode: 'cash',
      vchDate: '2024-04-01',
    } as never);
    const rows = await legs();
    expect(rows.map((r) => [r.k.slice(21).trim(), r.ac, r.dr, r.cr])).toEqual([
      ['105', PARTY, 5000, 0],
      ['106', CASH, 0, 5000],
      ['107', PARTY, 160, 0],
      ['108', KASAR_AVAK, 0, 160],
    ]);
  });

  it('multi-line receipts and payments resolve the same slot-2 account', async () => {
    await postReceiptLines(runtime, {
      scope: scopeFor('001'),
      mode: 'cash',
      vchDate: '2024-04-01',
      lines: [
        { partyAc: PARTY, amount: 100, kasar: 5 },
        { partyAc: PARTY, amount: 200 },
      ],
    });
    await postPaymentLines(runtime, {
      scope: scopeFor('002'),
      mode: 'cash',
      vchDate: '2024-04-01',
      lines: [{ partyAc: PARTY, amount: 300, kasar: 7 }],
    });
    const rows = await legs();
    expect(rows.filter((r) => r.book === '001' && r.ac === KASAR_JAVK).map((r) => r.dr)).toEqual([
      5,
    ]);
    expect(rows.filter((r) => r.book === '002' && r.ac === KASAR_AVAK).map((r) => r.cr)).toEqual([
      7,
    ]);
  });

  it('D1-5: a receipt or payment into a SALES book is refused and writes nothing', async () => {
    const receipt = postReceipt(runtime, {
      scope: scopeFor('SAL'),
      partyAc: PARTY,
      amount: 100,
      mode: 'cash',
      vchDate: '2024-04-01',
    } as never);
    await expect(receipt).rejects.toMatchObject({ name: 'FinanceValidationError' });
    await expect(receipt).rejects.toThrow(
      /SALES book; a receipt needs a CASH REC, BANK REC, RECEIPT book/,
    );
    const payment = postPayment(runtime, {
      scope: scopeFor('SAL'),
      partyAc: PARTY,
      amount: 100,
      mode: 'cash',
    } as never);
    await expect(payment).rejects.toThrow(/a payment needs a CASH PAY, BANK PAY, PAYMENT book/);
    // A payment book cannot take a receipt either.
    await expect(
      postReceipt(runtime, {
        scope: scopeFor('002'),
        partyAc: PARTY,
        amount: 100,
        mode: 'cash',
      } as never),
    ).rejects.toThrow(/CASH PAY book; a receipt needs/);
    expect(await rowCount()).toBe(0);
  });

  it('D1-6: a cash receipt into a BANK REC book is refused, and a bank receipt is accepted', async () => {
    await expect(
      postReceipt(runtime, {
        scope: scopeFor('011'),
        partyAc: PARTY,
        amount: 100,
        mode: 'cash',
      } as never),
    ).rejects.toThrow(/BANK REC book and cannot take a cash receipt/);
    expect(await rowCount()).toBe(0);
    await postReceipt(runtime, {
      scope: scopeFor('011'),
      partyAc: PARTY,
      amount: 100,
      mode: 'cheque',
      chqNo: '000123',
      vchDate: '2024-04-01',
    } as never);
    expect((await legs()).map((r) => r.ac)).toEqual([PARTY, BANK]);
  });

  it('D1-7: a web book with CASH in slots 1 and 2 refuses a write-off instead of posting it to cash', async () => {
    await expect(
      postReceipt(runtime, {
        scope: scopeFor('RCT'),
        partyAc: PARTY,
        amount: 100,
        kasar: 10,
        mode: 'cash',
      } as never),
    ).rejects.toThrow(/slot 2 \(kasar\) names the settlement account CASH/);
    expect(await rowCount()).toBe(0);
    // The generic web RECEIPT book is in the family, so the same receipt without a write-off posts.
    await postReceipt(runtime, {
      scope: scopeFor('RCT'),
      partyAc: PARTY,
      amount: 100,
      mode: 'cash',
      vchDate: '2024-04-01',
    } as never);
    expect((await legs()).map((r) => [r.ac, r.dr, r.cr])).toEqual([
      [PARTY, 0, 100],
      ['CASH', 100, 0],
    ]);
  });

  it('an explicit kasar account still wins over slot 2', async () => {
    await postReceipt(runtime, {
      scope: scopeFor('001'),
      partyAc: PARTY,
      amount: 1000,
      kasar: 3,
      kasarAc: KASAR_AVAK,
      mode: 'cash',
      vchDate: '2024-04-01',
    } as never);
    expect((await legs()).filter((r) => r.k.trim().endsWith('104')).map((r) => r.ac)).toEqual([
      KASAR_AVAK,
    ]);
  });

  // Found in the browser (E2E 2026-10-26): Payment, mode BANK, Bank A/c left blank, in the provisioned generic
  // PAYMENT book — the voucher was saved as BPAY with its money leg on CASH.
  it('a bank payment in the generic PAYMENT book needs a bank account and never settles to cash', async () => {
    await book('PAY', 'Payment', 'PAY', 'PAYMENT', 'O', 'PAY_DATA', [
      [1, 'CASH'],
      [2, 'KASAR'],
    ]);
    for (const bankAc of [undefined, '', 'CASH']) {
      await expect(
        postPayment(runtime, {
          scope: scopeFor('PAY'),
          partyAc: PARTY,
          amount: 50000,
          mode: 'bank',
          bankAc,
          vchDate: '2024-04-01',
        } as never),
      ).rejects.toThrow(
        bankAc === 'CASH' ? /cannot settle to the cash account CASH/ : /needs the bank account/,
      );
    }
    await expect(
      postPaymentLines(runtime, {
        scope: scopeFor('PAY'),
        mode: 'upi',
        vchDate: '2024-04-01',
        lines: [{ partyAc: PARTY, amount: 10 }],
      } as never),
    ).rejects.toThrow(/needs the bank account/);
    expect(await rowCount()).toBe(0);

    await postPayment(runtime, {
      scope: scopeFor('PAY'),
      partyAc: PARTY,
      amount: 50000,
      mode: 'bank',
      bankAc: BANK,
      vchDate: '2024-04-01',
    } as never);
    expect((await legs()).map((r) => [r.ac, r.dr, r.cr])).toEqual([
      [PARTY, 50000, 0],
      [BANK, 0, 50000],
    ]);
  });

  it('a card receipt in the generic RECEIPT book needs a bank account; a cash receipt still uses slot 1', async () => {
    await expect(
      postReceipt(runtime, {
        scope: scopeFor('RCT'),
        partyAc: PARTY,
        amount: 100,
        mode: 'card',
        vchDate: '2024-04-01',
      } as never),
    ).rejects.toThrow(/needs the bank account it is paid into/);
    await expect(
      postReceiptLines(runtime, {
        scope: scopeFor('RCT'),
        mode: 'cheque',
        bankAc: 'CASH',
        vchDate: '2024-04-01',
        lines: [{ partyAc: PARTY, amount: 10 }],
      } as never),
    ).rejects.toThrow(/cannot settle to the cash account CASH/);
    expect(await rowCount()).toBe(0);
    await postReceipt(runtime, {
      scope: scopeFor('RCT'),
      partyAc: PARTY,
      amount: 100,
      mode: 'cash',
      vchDate: '2024-04-01',
    } as never);
    expect((await legs()).map((r) => r.ac)).toEqual([PARTY, 'CASH']);
  });

  it('a bank receipt in a BANK REC book still defaults to the book slot-1 bank account', async () => {
    await postReceipt(runtime, {
      scope: scopeFor('011'),
      partyAc: PARTY,
      amount: 100,
      mode: 'bank',
      vchDate: '2024-04-01',
    } as never);
    expect((await legs()).map((r) => r.ac)).toEqual([PARTY, BANK]);
  });
});
