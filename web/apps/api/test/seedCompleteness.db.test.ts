import { describe, it, expect, beforeAll, afterAll } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { seedCompany } from '../src/modules/ops/seedCompany.js';

/**
 * The demo/provisioning seed must leave a company able to post its primary transaction.
 *
 * This gate exists because it did not. `SEED_DEMO=1` hand-rolled a thin subset — company, year,
 * location, settings and a single BOOK_DATA row — and stopped. A sale then failed with
 * `book SAL account row 1 is missing`, because `resolveBookAccountTx` reads BOOK_DETL for the control
 * account and fails closed rather than inventing one. Reaching even that error needed a customer
 * inserted by hand.
 *
 * Nothing caught it: every voucher test seeds its own fixtures, so the seed path was exercised by
 * nobody. A demo that cannot demonstrate a sale is an obstacle for evaluation and onboarding, and the
 * gap was found by running the application rather than by any test — the same way the identical bug in
 * `seedCompany` was found (see the comment at seedCompany.ts:54).
 *
 * The assertions below are the preconditions a sale actually has, each traced to what enforces it.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'seed-completeness';
const CO = '01';

databaseDescribe('provisioning leaves a company able to trade', () => {
  let owner: PrismaClient;

  const wipe = async (): Promise<void> => {
    const tables = (await owner.$queryRawUnsafe(
      `SELECT table_name FROM information_schema.columns
        WHERE column_name='tenant_id' AND table_schema='public'`,
    )) as Array<{ table_name: string }>;
    for (const t of tables) {
      await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const count = async (table: string, where = ''): Promise<number> => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 ${where}`,
      TENANT,
    )) as Array<{ n: number }>;
    return rows[0]?.n ?? 0;
  };

  beforeAll(async () => {
    const url = process.env.MIGRATE_DATABASE_URL;
    if (!url) throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL');
    owner = new PrismaClient({ datasources: { db: { url } } });
    await wipe();
    await seedCompany(owner, TENANT, CO, { coName: 'Seed Gate Co', lcCode: '01' });
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
  });

  it('provisions the identity a login and scope need', async () => {
    expect(await count('CO_MAST')).toBeGreaterThan(0);
    // Without a location, resolveLoginScope() throws and the client sees 'invalid-credentials',
    // which looks like a wrong password.
    expect(await count('LOCT_MAST')).toBeGreaterThan(0);
    // businessScope filters YEAR_MAST by company; a company-less row yields 'scope-incomplete'.
    expect(await count('YEAR_MAST', `AND "CO_CODE"='${CO}'`)).toBeGreaterThan(0);
    // settingsBehavior fails closed unless exactly one CO_SET row exists.
    expect(await count('CO_SET')).toBe(1);
  });

  it('provisions a book WITH its BOOK_DETL account row — the defect this gate was written for', async () => {
    const books = await count('BOOK_DATA');
    expect(books).toBeGreaterThan(0);
    // The original bug in one line: books existed, their account rows did not.
    expect(await count('BOOK_DETL')).toBeGreaterThan(0);

    // Every book that can post must have at least one account row. WH QUOT is deliberately document-only:
    // Ac_Ledr/Ac_Rojmel/Ac_Stock exclude it, and its writer has a zero-economic-footprint DB test.
    const orphans = (await owner.$queryRawUnsafe(
      `SELECT d."CO_BOOK" FROM "BOOK_DATA" d
        WHERE d.tenant_id=$1 AND coalesce(d."MAIN_BOOK",'')<>'WH QUOT'
          AND NOT EXISTS (SELECT 1 FROM "BOOK_DETL" t
                           WHERE t.tenant_id=d.tenant_id AND t."CO_CODE"=d."CO_CODE"
                             AND t."CO_BOOK"=d."CO_BOOK")`,
      TENANT,
    )) as Array<{ CO_BOOK: string }>;
    expect(orphans.map((o) => o.CO_BOOK)).toEqual([]);
    const documentOnly = (await owner.$queryRawUnsafe(
      `SELECT d."CO_BOOK" FROM "BOOK_DATA" d WHERE d.tenant_id=$1 AND d."MAIN_BOOK"='WH QUOT'
        AND NOT EXISTS (SELECT 1 FROM "BOOK_DETL" t WHERE t.tenant_id=d.tenant_id
          AND t."CO_CODE"=d."CO_CODE" AND t."CO_BOOK"=d."CO_BOOK")`,
      TENANT,
    )) as Array<{ CO_BOOK: string }>;
    expect(documentOnly.map((o) => o.CO_BOOK)).toEqual(['WHQ']);
  });

  it('provisions the accounts a sale posts to', async () => {
    for (const ac of ['CASH', 'SALES']) {
      expect(await count('AC_MAST', `AND "AC_CODE"='${ac}'`)).toBe(1);
    }
    expect(await count('TAX_MAST')).toBeGreaterThan(0);
    // Voucher numbering reads SRNO_MAST; without it the first voucher cannot be numbered.
    expect(await count('SRNO_MAST')).toBeGreaterThan(0);
  });

  it('is idempotent — running it twice neither duplicates nor throws', async () => {
    const before = await count('AC_MAST');
    await seedCompany(owner, TENANT, CO, { coName: 'Seed Gate Co', lcCode: '01' });
    expect(await count('AC_MAST')).toBe(before);
    expect(await count('CO_SET')).toBe(1); // still exactly one, or settings fail closed
  });

  it('provisions Stock In/Out: INWORD/OUTWORD books and the branch account on the location (N91/G105)', async () => {
    // StockInoutForm filters the book list to MAIN_BOOK INWORD (Stock In) / OUTWORD (Stock Out); without
    // these books the select is empty and Save stays disabled.
    const stockBooks = (await owner.$queryRawUnsafe(
      `SELECT "MAIN_BOOK" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND "MAIN_BOOK" IN ('INWORD','OUTWORD') ORDER BY "MAIN_BOOK"`,
      TENANT,
      CO,
    )) as Array<{ MAIN_BOOK: string }>;
    expect(stockBooks.map((b) => b.MAIN_BOOK)).toEqual(['INWORD', 'OUTWORD']);

    // TR_INOUT posts the signed metal against the branch account the location carries (MS_LOCT.cs:3458);
    // stockInout.ts drops the metal/ledger rows when LOCT_MAST.AC_CODE is blank.
    const loc = (await owner.$queryRawUnsafe(
      `SELECT "AC_CODE" FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    )) as Array<{ AC_CODE: string | null }>;
    expect(loc.length).toBeGreaterThan(0);
    expect(loc[0]?.AC_CODE).toBe('BRANCH');
    expect(await count('AC_MAST', `AND "AC_CODE"='BRANCH'`)).toBe(1);
  });

  it('provisions the Dhiran (pledge) books so Pledge Loan Issue/Receipt can post (N97/G109)', async () => {
    // The Pledge Loan Issue/Receipt screens need a DHIRAN ISSUE / DHIRAN RECEIPT book; without them the book
    // select offers no pledge book and Save is refused (MDI_FORM.cs:9527/9539).
    const dhrnBooks = (await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK","MAIN_BOOK","BOOK_TBL_NAME" FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "MAIN_BOOK" IN ('DHIRAN ISSUE','DHIRAN RECEIPT')
        ORDER BY "MAIN_BOOK"`,
      TENANT,
      CO,
    )) as Array<{ CO_BOOK: string; MAIN_BOOK: string; BOOK_TBL_NAME: string }>;
    expect(dhrnBooks.map((b) => b.MAIN_BOOK)).toEqual(['DHIRAN ISSUE', 'DHIRAN RECEIPT']);
    // The issue writes DHRN_ISU_DATA and the receipt DHRN_REC_DATA (the writer routes by BOOK_TBL_NAME).
    const byMain = Object.fromEntries(dhrnBooks.map((b) => [b.MAIN_BOOK, b.BOOK_TBL_NAME]));
    expect(byMain['DHIRAN ISSUE']).toBe('DHRN_ISU_DATA');
    expect(byMain['DHIRAN RECEIPT']).toBe('DHRN_REC_DATA');
  });
});
