import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { issueLoan, receiveLoan } from '../src/modules/dhrn/dhrn.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'dhrn-loan-lifecycle-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const LOAN_REC_BOOK = 'LRC';
const LOAN_ISU_BOOK = 'LIS';
const DAY = '2024-04-10';

const scope = (coBook: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});

databaseDescribe('database-backed loan received / loan issue', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'DHRN_REC_DETL',
      'DHRN_REC_DATA',
      'DHRN_ISU_DETL',
      'DHRN_ISU_DATA',
      'DHRN_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'TEMP_BOOK_DATA',
      'SRNO_MAST',
      'BOOK_DETL',
      'BOOK_DATA',
      'AC_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","DHRN_PRC","LOAN_INT_TYPE") VALUES ($1,$2,NULL,12,'M')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
       VALUES ($1,$2,$3,$4,'Loan Received','LRC','LOAN REC','I','Y','DHRN_ISU_DATA','DHRN_ISU_DETL'),
              ($1,$2,$3,$5,'Loan Issue','LIS','LOAN ISSUE','O','Y','DHRN_REC_DATA','DHRN_REC_DETL')`,
      TENANT,
      CO,
      LC,
      LOAN_REC_BOOK,
      LOAN_ISU_BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'LEND','Loan Lender'),($1,$2,$3,'CASH','Cash Account'),($1,$2,$3,'INTEXP','Interest Expense')`,
      TENANT,
      CO,
      LC,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  beforeEach(async () => {
    await cleanup();
    await seed();
  });

  it('receives an amount loan into DHRN_ISU_DATA with ENTRY_TYPE L and reversed principal ledger', async () => {
    const received = await receiveLoan(runtime, {
      scope: scope(LOAN_REC_BOOK),
      borrowerAc: 'LEND',
      borrowerName: 'Loan Lender',
      principal: 25_000,
      intPrc: 12,
      intMonths: 3,
      loanType: 'A',
      cashAc: 'CASH',
      vchDate: DAY,
      fromDate: DAY,
      toDate: '2024-07-10',
    });
    const vchNo = String(received.vchNo).padStart(5, '0');

    const header = (await owner.$queryRawUnsafe(
      `SELECT "ENTRY_TYPE","INOUT_TYPE","BOOK_NAME","AC_CODE","LEDR_ACCD","DHRN_AMT"::float8 amt,
              "INT_PRC"::float8 int_prc,"INT_MONTH"::float8 int_month,"ISU_REC"
         FROM "DHRN_ISU_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      TENANT,
      LOAN_REC_BOOK,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(header).toHaveLength(1);
    expect(String(header[0]!.ENTRY_TYPE).trim()).toBe('L');
    expect(String(header[0]!.INOUT_TYPE).trim()).toBe('I');
    expect(String(header[0]!.BOOK_NAME).trim()).toBe('LOAN REC');
    expect(String(header[0]!.AC_CODE).trim()).toBe('LEND');
    expect(String(header[0]!.LEDR_ACCD).trim()).toBe('LEND');
    expect(header[0]!.amt).toBeCloseTo(25_000, 2);
    expect(header[0]!.int_prc).toBeCloseTo(12, 2);
    expect(header[0]!.int_month).toBeCloseTo(3, 2);
    expect(String(header[0]!.ISU_REC).trim()).toBe('N');

    const ledger = (await owner.$queryRawUnsafe(
      `SELECT "AC_CODE","LD_CODE","DR_AMT"::float8 dr,"CR_AMT"::float8 cr,"BOOK_NAME"
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "LEDR_KEY"`,
      TENANT,
      LOAN_REC_BOOK,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(
      ledger.map((row) => ({
        ac: String(row.AC_CODE).trim(),
        ld: String(row.LD_CODE).trim(),
        dr: row.dr,
        cr: row.cr,
      })),
    ).toEqual([
      { ac: 'LEND', ld: 'CASH', dr: 0, cr: 25_000 },
      { ac: 'CASH', ld: 'LEND', dr: 25_000, cr: 0 },
    ]);
    expect(ledger.every((row) => String(row.BOOK_NAME).trim() === 'LOAN REC')).toBe(true);
  }, 30_000);

  it('issues a received loan through DHRN_REC_DATA with ENTRY_TYPE L and marks outstanding closed', async () => {
    const received = await receiveLoan(runtime, {
      scope: scope(LOAN_REC_BOOK),
      borrowerAc: 'LEND',
      borrowerName: 'Loan Lender',
      principal: 25_000,
      intPrc: 12,
      intMonths: 3,
      loanType: 'A',
      cashAc: 'CASH',
      vchDate: DAY,
      fromDate: DAY,
      toDate: '2024-07-10',
    });

    const issued = await issueLoan(runtime, {
      scope: scope(LOAN_ISU_BOOK),
      isuNo: received.vchNo,
      isuBook: LOAN_REC_BOOK,
      isuYear: YEAR,
      borrowerAc: 'LEND',
      borrowerName: 'Loan Lender',
      principalRepaid: 25_000,
      interest: 1_250,
      intPrc: 12,
      cashAc: 'CASH',
      intIncAc: 'INTEXP',
      loanType: 'A',
      vchDate: '2024-07-10',
      fromDate: DAY,
      toDate: '2024-07-10',
      vchDesc: 'loan closed',
    });
    const issueVchNo = String(issued.vchNo).padStart(5, '0');
    expect(issued.outstanding).toBe(0);

    const header = (await owner.$queryRawUnsafe(
      `SELECT "ENTRY_TYPE","INOUT_TYPE","BOOK_NAME","ISU_DBCD","ISU_YRCD","ISU_NO",
              "DHRN_REC_AMT"::float8 rec_amt,"INT_AMT"::float8 int_amt,"DHRN_OS_AMT"::float8 os_amt,
              "VCH_DESC"
         FROM "DHRN_REC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      TENANT,
      LOAN_ISU_BOOK,
      issueVchNo,
    )) as Array<Record<string, any>>;
    expect(header).toHaveLength(1);
    expect(String(header[0]!.ENTRY_TYPE).trim()).toBe('L');
    expect(String(header[0]!.INOUT_TYPE).trim()).toBe('O');
    expect(String(header[0]!.BOOK_NAME).trim()).toBe('LOAN ISSUE');
    expect(String(header[0]!.ISU_DBCD).trim()).toBe(LOAN_REC_BOOK);
    expect(String(header[0]!.ISU_YRCD).trim()).toBe(YEAR);
    expect(String(header[0]!.ISU_NO).trim()).toBe(String(received.vchNo).padStart(5, '0'));
    expect(header[0]!.rec_amt).toBeCloseTo(25_000, 2);
    expect(header[0]!.int_amt).toBeCloseTo(1_250, 2);
    expect(header[0]!.os_amt).toBe(0);
    expect(String(header[0]!.VCH_DESC).trim()).toBe('loan closed');

    const source = (await owner.$queryRawUnsafe(
      `SELECT "ISU_REC" FROM "DHRN_ISU_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      TENANT,
      LOAN_REC_BOOK,
      String(received.vchNo).padStart(5, '0'),
    )) as Array<Record<string, any>>;
    expect(String(source[0]!.ISU_REC).trim()).toBe('Y');

    const ledger = (await owner.$queryRawUnsafe(
      `SELECT "AC_CODE","LD_CODE","DR_AMT"::float8 dr,"CR_AMT"::float8 cr,"BOOK_NAME"
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "LEDR_KEY"`,
      TENANT,
      LOAN_ISU_BOOK,
      issueVchNo,
    )) as Array<Record<string, any>>;
    expect(
      ledger.map((row) => ({
        ac: String(row.AC_CODE).trim(),
        ld: String(row.LD_CODE).trim(),
        dr: row.dr,
        cr: row.cr,
      })),
    ).toEqual([
      { ac: 'LEND', ld: 'CASH', dr: 25_000, cr: 0 },
      { ac: 'INTEXP', ld: 'CASH', dr: 1_250, cr: 0 },
      { ac: 'CASH', ld: 'LEND', dr: 0, cr: 26_250 },
    ]);
    expect(ledger.every((row) => String(row.BOOK_NAME).trim() === 'LOAN ISSUE')).toBe(true);
  }, 30_000);
});
