import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  receiveLoan,
  issueLoan,
  getDhrnIssue,
  getDhrnReceipt,
  editLoanReceived,
  editLoanIssue,
} from '../src/modules/dhrn/dhrn.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * Loan Received / Loan Issue reopen + edit lifecycle (N145, G154, Stage D).
 *
 * `receiveLoan` wraps `issueDhrn` (writes DHRN_ISU_DATA, ENTRY_TYPE 'L') and `issueLoan` wraps
 * `receiveDhrn` (writes DHRN_REC_DATA). Both were create-only. This proves the loan vouchers reopen
 * through the shared dhrn readers and edit through editLoanReceived/editLoanIssue, which inject the
 * loan flags so the repost stays a loan (ENTRY_TYPE 'L', LOAN REC / LOAN ISSUE books).
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'loan-lifecycle';
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

databaseDescribe('database-backed loan received/issue lifecycle', () => {
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
       VALUES ($1,$2,$3,'LEND','Loan Lender'),($1,$2,$3,'CASH','Cash Account'),($1,$2,$3,'INTINC','Interest Income')`,
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

  const entryType = async (table: string, book: string, vchNo: string): Promise<string> => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "ENTRY_TYPE" e FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1`,
      TENANT,
      book,
      vchNo,
    )) as { e: string }[];
    return String(rows[0]?.e ?? '');
  };

  it('reopens a Loan Received and edits it, keeping ENTRY_TYPE=L', async () => {
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
    } as never);
    const no = String(received.vchNo).padStart(5, '0');
    // The header row (SR_NO absent on DHRN_ISU_DATA) carries ENTRY_TYPE 'L' on the movement.
    expect(await entryType('DHRN_DATA', LOAN_REC_BOOK, no)).toBe('L');

    const reopened = await getDhrnIssue(runtime, scope(LOAN_REC_BOOK), no);
    expect(reopened.borrowerAc).toBe('LEND');
    expect(reopened.principal).toBe(25_000);

    await editLoanReceived(
      runtime,
      { ...reopened, scope: scope(LOAN_REC_BOOK), principal: 30_000, cashAc: 'CASH' } as never,
      no,
    );
    const after = await getDhrnIssue(runtime, scope(LOAN_REC_BOOK), no);
    expect(after.principal).toBe(30_000);
    // The edit reposted through issueDhrn as a loan, not a pledge.
    expect(await entryType('DHRN_DATA', LOAN_REC_BOOK, no)).toBe('L');
  });

  it('reopens a Loan Issue and edits it, keeping ENTRY_TYPE=L', async () => {
    const received = await receiveLoan(runtime, {
      scope: scope(LOAN_REC_BOOK),
      borrowerAc: 'LEND',
      principal: 25_000,
      intPrc: 12,
      intMonths: 3,
      loanType: 'A',
      cashAc: 'CASH',
      vchDate: DAY,
    } as never);
    const recNo = String(received.vchNo).padStart(5, '0');

    const issued = await issueLoan(runtime, {
      scope: scope(LOAN_ISU_BOOK),
      isuNo: recNo,
      isuBook: LOAN_REC_BOOK,
      isuYear: YEAR,
      borrowerAc: 'LEND',
      principalRepaid: 10_000,
      interest: 500,
      intPrc: 12,
      cashAc: 'CASH',
      intIncAc: 'INTINC',
      vchDate: DAY,
    } as never);
    const isuNo = String(issued.vchNo).padStart(5, '0');
    expect(await entryType('DHRN_REC_DATA', LOAN_ISU_BOOK, isuNo)).toBe('L');

    const reopened = await getDhrnReceipt(runtime, scope(LOAN_ISU_BOOK), isuNo);
    expect(reopened.principalRepaid).toBe(10_000);

    await editLoanIssue(
      runtime,
      {
        ...reopened,
        scope: scope(LOAN_ISU_BOOK),
        isuBook: LOAN_REC_BOOK,
        isuYear: YEAR,
        principalRepaid: 15_000,
        interest: 500,
        cashAc: 'CASH',
        intIncAc: 'INTINC',
      } as never,
      isuNo,
    );
    const after = await getDhrnReceipt(runtime, scope(LOAN_ISU_BOOK), isuNo);
    expect(after.principalRepaid).toBe(15_000);
    expect(await entryType('DHRN_REC_DATA', LOAN_ISU_BOOK, isuNo)).toBe('L');
  });
});
