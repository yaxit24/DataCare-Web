/**
 * Scheme instalment ledger shape — family 2.
 *
 * MEASURED on book 074 of the real customer database, across all 2620 AC_DATA legs of length 33:
 *
 *   type 01   the scheme LIABILITY, credited     1311 rows, ONE account (000858)
 *   type 02   the RECEIPT account, debited       1311 rows, five accounts (cash + four banks)
 *
 * Legs come in PAIRS PER MEMBER LINE, and the key carries that line number right-aligned in 10, giving 33
 * characters: 570 vouchers have 2 legs, 172 have 4, 52 have 6, and voucher 00309 has 22 for its 11 members.
 * Real key: `01002024-20250740000101         1`.
 *
 * WHAT THIS TEST EXISTS TO CATCH
 * Five defects were found here, and the first announced itself only because the differ reports when it pairs
 * rows WITHOUT a key match. Before the fix the web wrote 23-character keys with the positional leg codes
 * 51/52, debit-first, no LD_CODE, and the literal 'CASH' instead of the book's slot-1 account. A balance
 * assertion cannot see any of that - the voucher balanced throughout.
 *
 * The multi-line case is the one that matters most: with one member line, a missing line number is invisible
 * because there is nothing to distinguish. Two lines is the smallest fixture that can fail.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { schemeInstallment } from '../src/modules/membership/scheme.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'scheme-legs';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '074';
const LIAB = '000858';
const CASH = '00001';

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
    [LIAB, 'SCHEME LIABILITY'],
    [CASH, 'CASH ON HAND'],
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
    `INSERT INTO "AD_MAST"(tenant_id,"CO_CODE","SCHM_CODE","SCHM_NAME","SCHM_AC") VALUES ($1,$2,'04','SCHEME 04',$3)`,
    TENANT,
    CO,
    LIAB,
  );
  // Three members, mirroring voucher 00309's shape (11 members, all on scheme 04, 2000 each).
  for (const memb of ['0019', '0144', '0183']) {
    await exec(
      `INSERT INTO "AD_MEMB"(tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME")
       VALUES ($1,$2,$3,'04',$4,'MEMBER ' || $4)`,
      TENANT,
      CO,
      LC,
      memb,
    );
  }
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Member Entry','MBENT','MEMB ENTRY','I','Y','AD_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,$4,1,$5,'Member Entry','MEMB ENTRY','I')`,
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

describe.runIf(RUN)('scheme instalment ledger legs', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('writes a 33-character key per member line, liability first, with the contra', async () => {
    await schemeInstallment(runtime, {
      scope,
      schmCode: '04',
      membCode: '0019',
      amount: 2000,
      vchDate: '2024-04-01',
      mainUser: 'legs-test',
    });
    const rows = await legs();
    expect(rows).toHaveLength(2);
    for (const r of rows) expect(r.k).toHaveLength(33);
    // Type 01 is the liability CREDIT and sorts first; 02 is the receipt DEBIT.
    expect(rows[0]!.k.slice(21, 23)).toBe('01');
    expect(rows[0]!.ac).toBe(LIAB);
    expect(rows[0]!.ld).toBe(CASH);
    expect(rows[0]!.cr).toBe(2000);
    expect(rows[1]!.k.slice(21, 23)).toBe('02');
    expect(rows[1]!.ac).toBe(CASH);
    expect(rows[1]!.ld).toBe(LIAB);
    expect(rows[1]!.dr).toBe(2000);
    // The line number is right-aligned in 10, exactly as the real key `...0101         1`.
    expect(rows[0]!.k.slice(23)).toBe('         1');
  });

  it('numbers each member line, so three members give six legs numbered 1..3', async () => {
    // THE CASE THAT MATTERS. With one member line a missing line number is invisible - there is nothing to
    // distinguish. Real voucher 00309 has 11 members and 22 legs; three is the smallest fixture that fails.
    await schemeInstallment(runtime, {
      scope,
      schmCode: '04',
      membCode: '0019',
      amount: 2000,
      vchDate: '2024-04-01',
      mainUser: 'legs-test',
      lines: [
        { schmCode: '04', membCode: '0019', amount: 2000 },
        { schmCode: '04', membCode: '0144', amount: 2000 },
        { schmCode: '04', membCode: '0183', amount: 2000 },
      ],
    });
    const rows = await legs();
    expect(rows).toHaveLength(6);
    // Each line contributes one 01 and one 02, and the line numbers run 1..3 with no duplicates.
    const byType = (t: string) =>
      rows.filter((r) => r.k.slice(21, 23) === t).map((r) => r.k.slice(23).trim());
    expect(byType('01')).toEqual(['1', '2', '3']);
    expect(byType('02')).toEqual(['1', '2', '3']);
    // And every key is distinct, which is what AC_DATA's uniqueness index now enforces at the database.
    expect(new Set(rows.map((r) => r.k)).size).toBe(6);
  });
});
