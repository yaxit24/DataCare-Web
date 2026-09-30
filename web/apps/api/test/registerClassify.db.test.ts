import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { salesRegister, purchaseRegister } from '../src/modules/reports/reports.js';

/**
 * G06 / N36. The sales and purchase registers must classify vouchers by their book's MAIN_BOOK, not by
 * a hard-coded CO_BOOK literal. The old code excluded only `CO_BOOK='SRT'` / `'PRT'`, so:
 *   - a company whose return book is not literally named SRT had its returns counted as sales;
 *   - a quotation or credit-note book that shares SL_DATA was counted as a sale.
 *
 * This seeds one company with three SALES-family books that all write to SL_DATA — a SALES book, a
 * SALES RETURNE book (named RETX, not SRT) and a SALES QUOTATION book — and asserts the register returns
 * only the SALES-book voucher.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'register-classify-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-05-10';
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR };

databaseDescribe('registers classify by MAIN_BOOK, not literal book codes', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    for (const t of ['SL_DATA', 'PR_DATA', 'BOOK_DATA', 'CO_SET'])
      await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, TENANT);
  };

  const seed = async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    // Three SALES-family books on SL_DATA; note the return book is RETX, not the literal SRT.
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'SL','Sales','SALE','SALES','O','Y','SL_DATA'),
              ($1,$2,$3,'RTX','Sales Return','SRTN','SALES RETURNE','I','Y','SL_DATA'),
              ($1,$2,$3,'SQT','Sales Quotation','SQTN','SALES QUOTATION','O','Y','SL_DATA'),
              ($1,$2,$3,'PR','Purchase','PURC','PURCHASE','I','Y','PR_DATA'),
              ($1,$2,$3,'PTX','Purchase Return','PRTN','PURC RETURN','O','Y','PR_DATA')`,
      TENANT,
      CO,
      LC,
    );
    const sl = async (book: string, vch: string, amt: number) =>
      owner.$executeRawUnsafe(
        `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","NET_AMT","TOT_AMT")
         VALUES ($1,$2,$3,$4,$5,$6,$7::date,'CUST','Customer',$8,$8)`,
        TENANT,
        CO,
        LC,
        YEAR,
        book,
        vch,
        DAY,
        amt,
      );
    await sl('SL', '00001', 1000);
    await sl('RTX', '00001', 200);
    await sl('SQT', '00001', 500);
    const pr = async (book: string, vch: string, amt: number) =>
      owner.$executeRawUnsafe(
        `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","NET_AMT","TOT_AMT")
         VALUES ($1,$2,$3,$4,$5,$6,$7::date,'SUPP','Supplier',$8,$8)`,
        TENANT,
        CO,
        LC,
        YEAR,
        book,
        vch,
        DAY,
        amt,
      );
    await pr('PR', '00001', 3000);
    await pr('PTX', '00001', 400);
  };

  beforeAll(async () => {
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await cleanup();
    await seed();
  });
  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('sales register counts only SALES-book vouchers, excluding a RETX return and a quotation', async () => {
    const reg = await salesRegister(runtime, scope);
    expect(reg.rows.map((r) => `${r.coBook}/${r.vchNo}`)).toEqual(['SL/00001']);
    expect(reg.totals.netAmt).toBe(1000);
  });

  it('purchase register counts only PURCHASE-book vouchers, excluding a PRTX return', async () => {
    const reg = await purchaseRegister(runtime, scope);
    expect(reg.rows.map((r) => `${r.coBook}/${r.vchNo}`)).toEqual(['PR/00001']);
    expect(reg.totals.netAmt).toBe(3000);
  });
});
