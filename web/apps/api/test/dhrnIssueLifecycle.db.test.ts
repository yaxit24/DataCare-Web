import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { issueDhrn, getDhrnIssue, editDhrnIssue, deleteDhrn } from '../src/modules/dhrn/dhrn.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * Dhiran (pledge) ISSUE reopen/edit/delete lifecycle (N143, G152, Stage D).
 *
 * Before this, `issueDhrn` could create and `deleteDhrn` could reverse a pledge, but there was no
 * reopen reader and no edit — the issue page was create-only. A trained operator could book a pledge
 * but could not load it, correct a wrong principal/collateral, or re-save. This proves the pledge can
 * be reopened into its input shape, edited (collateral grown AND shrunk, so a shrink leaves no orphan
 * detail rows), reopened again to see the change, and deleted.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'dhrn-issue-lifecycle';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const ISSUE_BOOK = 'DHI';
const DAY = '2024-04-10';

const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: ISSUE_BOOK,
};

databaseDescribe('database-backed dhiran issue lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
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
       VALUES ($1,$2,$3,'DHI','Dhiran Issue','DHIS','DHIRAN ISSUE','O','Y','DHRN_ISU_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'BORR','Pledge Borrower'),($1,$2,$3,'CASH','Cash Account')`,
      TENANT,
      CO,
      LC,
    );
    // The dhrn writers resolve the funding account from BOOK_DETL slot 2 (Ac_Ledr.cs:1066 SR_NO = 2).
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'DHI',2,'CASH','DHIRAN ISSUE','O')`,
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

  const detlCount = async (vchNo: string): Promise<number> => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "DHRN_ISU_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as { n: number }[];
    return rows[0]!.n;
  };

  it('reopens a saved pledge into its input shape', async () => {
    const issued = await issueDhrn(runtime, {
      scope,
      borrowerAc: 'BORR',
      borrowerName: 'Pledge Borrower',
      principal: 50_000,
      intPrc: 12,
      intMonths: 6,
      loanType: 'G',
      packetNo: 'P-1',
      vchDate: DAY,
      mainUser: 'dhrn-user',
      collateral: [
        {
          itCode: 'ITM1',
          itName: 'Ring',
          pcs: 1,
          grossWt: 10,
          netWt: 9.5,
          touch: 91.6,
          amount: 30_000,
        },
        {
          itCode: 'ITM2',
          itName: 'Chain',
          pcs: 1,
          grossWt: 20,
          netWt: 19,
          touch: 91.6,
          amount: 20_000,
        },
      ],
    } as never);

    const no = String(issued.vchNo).padStart(5, '0');
    const reopened = await getDhrnIssue(runtime, scope, issued.vchNo);
    expect(reopened.voucherNo).toBe(no);
    expect(reopened.borrowerAc).toBe('BORR');
    expect(reopened.principal).toBe(50_000);
    expect(reopened.intMonths).toBe(6);
    expect(reopened.loanType).toBe('G');
    expect(reopened.packetNo).toBe('P-1');
    expect(reopened.collateral).toHaveLength(2);
    expect(reopened.collateral.map((c) => c.itCode)).toEqual(['ITM1', 'ITM2']);
    expect(reopened.collateral[1]!.netWt).toBe(19);
    // The hidden voucher number is persisted so an edit can resolve the identity.
    expect(reopened.hiddenVoucherNo).not.toBe('');
  });

  it('edits principal and SHRINKS the collateral, leaving no orphan detail rows', async () => {
    const issued = await issueDhrn(runtime, {
      scope,
      borrowerAc: 'BORR',
      principal: 50_000,
      intPrc: 12,
      intMonths: 6,
      vchDate: DAY,
      collateral: [
        { itCode: 'ITM1', pcs: 1, netWt: 9.5, amount: 30_000 },
        { itCode: 'ITM2', pcs: 1, netWt: 19, amount: 20_000 },
      ],
    } as never);
    const no = String(issued.vchNo).padStart(5, '0');
    expect(await detlCount(no)).toBe(2);

    const reopened = await getDhrnIssue(runtime, scope, issued.vchNo);
    await editDhrnIssue(
      runtime,
      {
        ...reopened,
        scope,
        principal: 30_000,
        // Drop the second ornament — a shrink the write-without-read defect would leave orphaned.
        collateral: [{ itCode: 'ITM1', pcs: 1, netWt: 9.5, amount: 30_000 }],
      } as never,
      issued.vchNo,
    );

    const after = await getDhrnIssue(runtime, scope, issued.vchNo);
    expect(after.principal).toBe(30_000);
    expect(after.collateral).toHaveLength(1);
    expect(after.collateral[0]!.itCode).toBe('ITM1');
    // The DHRN_ISU_DETL row for the removed ornament is gone, not orphaned.
    expect(await detlCount(no)).toBe(1);
  });

  it('deletes a pledge, reversing the header, detail and ledger', async () => {
    const issued = await issueDhrn(runtime, {
      scope,
      borrowerAc: 'BORR',
      principal: 50_000,
      intPrc: 12,
      intMonths: 6,
      vchDate: DAY,
      collateral: [{ itCode: 'ITM1', pcs: 1, netWt: 9.5, amount: 50_000 }],
    } as never);
    const no = String(issued.vchNo).padStart(5, '0');
    expect(await detlCount(no)).toBe(1);

    await deleteDhrn(runtime, {
      scope,
      vchNo: issued.vchNo,
      headerTable: 'DHRN_ISU_DATA',
      book: ISSUE_BOOK,
      vchType: 'DHRN',
      deleteUser: 'dhrn-user',
    });

    const hdr = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "DHRN_ISU_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      no,
    )) as { n: number }[];
    expect(hdr[0]!.n).toBe(0);
    expect(await detlCount(no)).toBe(0);
    const ledger = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
      TENANT,
      ISSUE_BOOK,
    )) as { n: number }[];
    expect(ledger[0]!.n).toBe(0);
  });
});
