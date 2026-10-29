import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  issueDhrn,
  receiveDhrn,
  getDhrnReceipt,
  editDhrnReceipt,
  deleteDhrn,
} from '../src/modules/dhrn/dhrn.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * Dhiran (pledge) RECEIPT reopen/edit/delete lifecycle (N144, G153, Stage D).
 *
 * Before this, `receiveDhrn` could create a redemption and `deleteDhrn` could reverse its own rows,
 * but there was no reopen reader, no edit, and the delete did NOT restore the pledge's ISU_REC flag
 * — so a reversed receipt left the issue permanently marked redeemed (ISU_REC='Y'), diverging from
 * desktop TR_DHRN_REC.cs:6376 which sets it back to 'N'. This proves: a receipt marks the issue
 * redeemed; the receipt can be reopened and edited; and deleting it restores ISU_REC='N'.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'dhrn-receipt-lifecycle';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const ISSUE_BOOK = 'DHI';
const REC_BOOK = 'DHR';
const DAY = '2024-04-10';

const scope = (coBook: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});

databaseDescribe('database-backed dhiran receipt lifecycle', () => {
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
      'BOOK_DATA',
      'BOOK_DETL',
      'AC_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","DHRN_PRC") VALUES ($1,$2,NULL,12)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'DHI','Dhiran Issue','DHIS','DHIRAN ISSUE','O','Y','DHRN_ISU_DATA'),
              ($1,$2,$3,'DHR','Dhiran Receipt','DHRC','DHIRAN RECEIPT','I','Y','DHRN_REC_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'BORR','Pledge Borrower'),($1,$2,$3,'CASH','Cash Account'),
              ($1,$2,$3,'INTINC','Interest Income')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'DHI',2,'CASH','DHIRAN ISSUE','O'),
              ($1,$2,$3,'DHR',2,'CASH','DHIRAN RECEIPT','I')`,
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

  const isuRec = async (isuNo: string): Promise<string> => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "ISU_REC" r FROM "DHRN_ISU_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      isuNo,
    )) as { r: string }[];
    return String(rows[0]?.r ?? '');
  };

  const issuePledge = async () => {
    const issued = await issueDhrn(runtime, {
      scope: scope(ISSUE_BOOK),
      borrowerAc: 'BORR',
      borrowerName: 'Pledge Borrower',
      principal: 50_000,
      intPrc: 12,
      intMonths: 6,
      loanType: 'G',
      vchDate: DAY,
    } as never);
    return String(issued.vchNo).padStart(5, '0');
  };

  it('a receipt marks the issue redeemed, and deleting it restores ISU_REC=N', async () => {
    const isuNo = await issuePledge();
    expect(await isuRec(isuNo)).toBe('N');

    const received = await receiveDhrn(runtime, {
      scope: scope(REC_BOOK),
      isuNo,
      isuBook: ISSUE_BOOK,
      isuYear: YEAR,
      borrowerAc: 'BORR',
      principalRepaid: 50_000,
      interest: 3_000,
      intPrc: 12,
      vchDate: DAY,
    } as never);
    const recNo = String(received.vchNo).padStart(5, '0');
    // Full repayment marks the pledge redeemed.
    expect(await isuRec(isuNo)).toBe('Y');

    await deleteDhrn(runtime, {
      scope: scope(REC_BOOK),
      vchNo: recNo,
      headerTable: 'DHRN_REC_DATA',
      book: REC_BOOK,
      vchType: 'DHRN',
      deleteUser: 'tester',
    });
    // The pledge is restored to not-redeemed (desktop TR_DHRN_REC.cs:6376).
    expect(await isuRec(isuNo)).toBe('N');
  });

  it('reopens a receipt into its input shape', async () => {
    const isuNo = await issuePledge();
    const received = await receiveDhrn(runtime, {
      scope: scope(REC_BOOK),
      isuNo,
      isuBook: ISSUE_BOOK,
      isuYear: YEAR,
      borrowerAc: 'BORR',
      borrowerName: 'Pledge Borrower',
      principalRepaid: 20_000,
      interest: 3_000,
      intPrc: 12,
      vchDate: DAY,
      items: [{ itCode: 'RING', itName: 'Ring', pcs: 1, netWt: 9.5, amount: 20_000 }],
    } as never);
    const recNo = String(received.vchNo).padStart(5, '0');

    const reopened = await getDhrnReceipt(runtime, scope(REC_BOOK), recNo);
    expect(reopened.voucherNo).toBe(recNo);
    expect(reopened.borrowerAc).toBe('BORR');
    expect(reopened.principalRepaid).toBe(20_000);
    expect(reopened.interest).toBe(3_000);
    expect(reopened.isuNo).toBe(isuNo);
    expect(reopened.items).toHaveLength(1);
    expect(reopened.items[0]!.itCode).toBe('RING');
    expect(reopened.hiddenVoucherNo).not.toBe('');
  });

  it('edits a partial receipt to a larger repayment and re-reads it', async () => {
    const isuNo = await issuePledge();
    const received = await receiveDhrn(runtime, {
      scope: scope(REC_BOOK),
      isuNo,
      isuBook: ISSUE_BOOK,
      isuYear: YEAR,
      borrowerAc: 'BORR',
      principalRepaid: 20_000,
      interest: 3_000,
      intPrc: 12,
      vchDate: DAY,
    } as never);
    const recNo = String(received.vchNo).padStart(5, '0');
    // Partial repayment leaves the pledge open.
    expect(await isuRec(isuNo)).toBe('N');

    const reopened = await getDhrnReceipt(runtime, scope(REC_BOOK), recNo);
    await editDhrnReceipt(
      runtime,
      { ...reopened, scope: scope(REC_BOOK), principalRepaid: 50_000, interest: 3_000 } as never,
      recNo,
    );

    const after = await getDhrnReceipt(runtime, scope(REC_BOOK), recNo);
    expect(after.principalRepaid).toBe(50_000);
    // Full repayment on edit redeems the pledge.
    expect(await isuRec(isuNo)).toBe('Y');
  });
});
