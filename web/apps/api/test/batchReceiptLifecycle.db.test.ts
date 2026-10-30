/**
 * Multi-Party (batch) Receipt reopen/edit/delete lifecycle (N154, G162).
 *
 * WHY THIS FILE EXISTS
 * The desktop Multi-Party Receipt (TR_CASH.cs) is fully reopen/edit/delete-capable (BtnF load,
 * BtnSave, BtnDelete; an edit deletes CASH_DATA + AC_DATA by VCH_NO and rebuilds them, writing a
 * DELETE_DATA audit — TR_CASH.cs:2988-3081,3217). The web batch-receipt page could only POST: the
 * backend had `postBatchReceipt`/`deleteBatchReceipt` but no reader or editor, and the single-row
 * `getReceipt` refuses a voucher with more than one CASH_DATA row. This proves the new
 * `getBatchReceipt` reads every collection line back (including the DERIVED pay mode),
 * `editBatchReceipt` reverses-and-re-posts under the same number with a balanced ledger, and
 * `deleteBatchReceipt` audits.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  postBatchReceipt,
  getBatchReceipt,
  editBatchReceipt,
  deleteBatchReceipt,
} from '../src/modules/finance/batchReceipt.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'batch-lifecycle';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '001';
const PARTY_A = '000926';
const PARTY_B = '000927';
const CASH = '00001';
const BANK = '00002';
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
    [PARTY_A, 'CASH PARTY A'],
    [PARTY_B, 'CASH PARTY B'],
    [CASH, 'CASH ON HAND'],
    [BANK, 'HDFC BANK A/C'],
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
  // Slot 1 = cash settlement account; slot 2 = kasar write-off account.
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,$4,1,$5,'Cash Received','CASH REC','I')`,
    TENANT,
    CO,
    LC,
    BOOK,
    CASH,
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
}

const legSums = async () => {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT coalesce(SUM("DR_AMT"),0)::float dr, coalesce(SUM("CR_AMT"),0)::float cr
       FROM "AC_DATA" WHERE tenant_id=$1`,
    TENANT,
  )) as { dr: number; cr: number }[];
  return rows[0]!;
};
const cashRowCount = async () =>
  Number(
    (
      (await owner.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "CASH_DATA" WHERE tenant_id=$1`,
        TENANT,
      )) as { n: number }[]
    )[0]!.n,
  );
const deleteAudits = async () =>
  Number(
    (
      (await owner.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "DELETE_DATA" WHERE tenant_id=$1`,
        TENANT,
      )) as { n: number }[]
    )[0]!.n,
  );

describe.runIf(RUN)('multi-party receipt reopen/edit/delete lifecycle', () => {
  beforeEach(async () => {
    await wipe();
    await seedBase();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('posts a two-party batch, reopens it with the derived mode and every field, edits it in place and deletes it', async () => {
    // Party A pays cash with a kasar write-off; Party B pays by cheque into the bank.
    const created = await postBatchReceipt(runtime, {
      scope,
      vchDate: '2024-04-01',
      lines: [
        { partyAc: PARTY_A, partyName: 'CASH PARTY A', amount: 1000, mode: 'cash', kasarAmt: 15 },
        {
          partyAc: PARTY_B,
          partyName: 'CASH PARTY B',
          amount: 2500,
          mode: 'cheque',
          bankAc: BANK,
          chqNo: 'CHQ-42',
          bankCharges: 20,
          chqPrintName: 'PARTY B',
          clearDate: '2024-04-05',
          itemDescriptionCode: 7,
        },
      ],
    } as never);
    expect(created.vchNo).toBe(1);
    expect(created.total).toBe(3500);

    // Reopen: two lines back in SR_NO order, with the mode DERIVED from REC_AC_CODE.
    const view = await getBatchReceipt(runtime, scope, created.vchNo);
    expect(view.voucherNo).toBe('00001');
    expect(view.vchDate).toBe('2024-04-01');
    expect(view.lines).toHaveLength(2);

    const a = view.lines[0]!;
    expect(a).toMatchObject({
      srNo: 1,
      partyAc: PARTY_A,
      amount: 1000,
      kasarAmt: 15,
      mode: 'cash', // REC_AC_CODE == slot-1 cash account
      bankAc: '', // cash line carries no bank account
    });
    const b = view.lines[1]!;
    expect(b).toMatchObject({
      srNo: 2,
      partyAc: PARTY_B,
      amount: 2500,
      mode: 'cheque', // non-cash REC_AC_CODE + a cheque number
      bankAc: BANK, // the bank ledger that received the money
      chqNo: 'CHQ-42',
      bankCharges: 20,
      chqPrintName: 'PARTY B',
      clearDate: '2024-04-05',
      itemDescriptionCode: 7,
    });

    // The created voucher's ledger is balanced: Dr 1000(cash)+15(kasar)+2500(bank) = Cr 1015+2500.
    let sums = await legSums();
    expect(sums.dr).toBe(sums.cr);
    expect(sums.dr).toBe(3515);
    expect(await cashRowCount()).toBe(2);

    // Edit in place: drop party B, raise party A to 1200 and remove its kasar. Same voucher number.
    const edited = await editBatchReceipt(runtime, {
      scope,
      vchNo: created.vchNo,
      vchDate: '2024-04-02',
      lines: [{ partyAc: PARTY_A, partyName: 'CASH PARTY A', amount: 1200, mode: 'cash' }],
      deleteUser: 'editor1',
    });
    expect(edited.vchNo).toBe(1); // kept its identity
    expect(edited.total).toBe(1200);

    // The delete-then-rebuild left exactly ONE CASH_DATA row and wrote a DELETE_DATA audit.
    expect(await cashRowCount()).toBe(1);
    expect(await deleteAudits()).toBeGreaterThanOrEqual(1);

    const reopened = await getBatchReceipt(runtime, scope, created.vchNo);
    expect(reopened.vchDate).toBe('2024-04-02');
    expect(reopened.lines).toHaveLength(1);
    expect(reopened.lines[0]).toMatchObject({ partyAc: PARTY_A, amount: 1200, kasarAmt: 0 });

    // The edited ledger is still balanced (Dr cash 1200 = Cr party 1200).
    sums = await legSums();
    expect(sums.dr).toBe(sums.cr);
    expect(sums.dr).toBe(1200);

    // Delete removes the voucher entirely.
    await deleteBatchReceipt(runtime, { scope, vchNo: created.vchNo, deleteUser: 'editor1' });
    expect(await cashRowCount()).toBe(0);
    await expect(getBatchReceipt(runtime, scope, created.vchNo)).rejects.toThrow(/not found/);
  });

  it('an unchanged reopen then re-save re-posts the identical balanced ledger', async () => {
    const created = await postBatchReceipt(runtime, {
      scope,
      vchDate: '2024-04-01',
      lines: [
        { partyAc: PARTY_A, amount: 500, mode: 'cash', kasarAmt: 5 },
        { partyAc: PARTY_B, amount: 700, mode: 'cheque', bankAc: BANK, chqNo: 'C1' },
      ],
    } as never);
    const before = await getBatchReceipt(runtime, scope, created.vchNo);
    const beforeSums = await legSums();

    // Feed the reopened view straight back (lines shape matches BatchReceiptLineInput).
    await editBatchReceipt(runtime, {
      scope,
      vchNo: created.vchNo,
      vchDate: before.vchDate,
      lines: before.lines.map((l) => ({
        partyAc: l.partyAc,
        partyName: l.partyName,
        amount: l.amount,
        mode: l.mode,
        bankAc: l.bankAc || undefined,
        chqNo: l.chqNo || undefined,
        kasarAmt: l.kasarAmt,
      })),
      deleteUser: 'editor1',
    });

    const after = await getBatchReceipt(runtime, scope, created.vchNo);
    expect(after.lines).toEqual(before.lines);
    const afterSums = await legSums();
    expect(afterSums).toEqual(beforeSums);
    expect(afterSums.dr).toBe(afterSums.cr);
  });

  it('an edit that fails after the reversal rolls back and leaves the original voucher intact', async () => {
    // A valid two-line batch exists.
    const created = await postBatchReceipt(runtime, {
      scope,
      vchDate: '2024-04-01',
      lines: [
        { partyAc: PARTY_A, amount: 1000, mode: 'cash', kasarAmt: 15 },
        { partyAc: PARTY_B, amount: 2500, mode: 'cheque', bankAc: BANK, chqNo: 'CHQ-9' },
      ],
    } as never);
    const before = await getBatchReceipt(runtime, scope, created.vchNo);
    const beforeSums = await legSums();
    const beforeCash = await cashRowCount();
    const beforeAudits = await deleteAudits();

    // Edit with a BANK-mode line that names NO bank account — postBatchReceipt rejects it
    // (bank-settlement account not configured). The reverse must NOT commit on its own.
    await expect(
      editBatchReceipt(runtime, {
        scope,
        vchNo: created.vchNo,
        vchDate: '2024-04-02',
        lines: [{ partyAc: PARTY_A, amount: 500, mode: 'bank' }],
        deleteUser: 'editor1',
      } as never),
    ).rejects.toThrow();

    // The original voucher, its balanced ledger and the audit count are all unchanged.
    expect(await getBatchReceipt(runtime, scope, created.vchNo)).toEqual(before);
    expect(await cashRowCount()).toBe(beforeCash);
    expect(await deleteAudits()).toBe(beforeAudits);
    const nowSums = await legSums();
    expect(nowSums).toEqual(beforeSums);
    expect(nowSums.dr).toBe(nowSums.cr);
  });
});
