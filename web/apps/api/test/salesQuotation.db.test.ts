import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createSalesQuotation,
  deleteSalesQuotation,
  editSalesQuotation,
  getSalesQuotation,
  type SaleInput,
  type SaleLineInput,
} from '../src/modules/sales/sales.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'sales-quotation-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = '099';
const DAY = '2024-04-12';

const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

let owner: PrismaClient;
let runtime: PrismaClient;

const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
const query = <T = Record<string, unknown>>(sql: string, ...params: unknown[]): Promise<T[]> =>
  owner.$queryRawUnsafe(sql, ...params) as Promise<T[]>;

async function wipe() {
  for (const table of [
    'DELETE_DATA',
    'USER_DATA',
    'SL_ORD_ADJ',
    'AD_ADJ',
    'REMARK_DATA',
    'LOT_DETL',
    'ROJ_MEL_DATA',
    'CRNT_DATA',
    'DM_DATA',
    'CARD_DATA',
    'UPI_DATA',
    'POINT_DATA',
    'BILL_OS_DATA',
    'TAX_DATA',
    'AC_DATA',
    'SL_IDTL',
    'SL_PR_DETL',
    'SL_DETL',
    'SL_DATA',
    'TEMP_BOOK_DATA',
    'MAIN_STOCK',
    'TAG_STOCK',
    'BAR_DETL',
    'BOOK_DETL',
    'BOOK_DATA',
    'ITEM_MAST',
    'GROUP_MAST',
    'TAX_MAST',
    'AC_MAST',
    'YEAR_MAST',
    'CO_SET_NEW',
    'CO_SET',
  ]) {
    await exec(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seed() {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","CASH_LIMIT","PAN_CARD_VAL")
     VALUES ($1,$2,NULL,1,1)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","NEGATIVE_STK_SALE","SL_TDS_TAX","OS_BILL_ORNA_ISU")
     VALUES ($1,$2,'N','N','N')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31'::timestamp)`,
    TENANT,
    CO,
    YEAR,
  );
  await exec(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_PANNO")
     VALUES ($1,$2,$3,'CUST','Quotation Customer','L','')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME")
     VALUES ($1,$2,'G01','Gold')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
     VALUES ($1,$2,'GOLD','Gold Ornament','G','G01')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "BOOK_DATA"(
       tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
       "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
     VALUES ($1,$2,$3,$4,'Sales Quotation','QTPRN','SL QUOT','O','Y','SL_DATA','SL_DETL')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  await exec(
    `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE")
     VALUES ($1,$2,$3,$4,$5,'00004',$6::date,'CUST')`,
    TENANT,
    CO,
    LC,
    YEAR,
    BOOK,
    DAY,
  );
  await exec(
    `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
     VALUES ($1,$2,$3,$4,'00009','Sales Quotation')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
}

const saleInput = (overrides: Partial<SaleInput> = {}): SaleInput => ({
  scope,
  mainUser: 'creator',
  acCode: 'CUST',
  acName: 'Quotation Customer',
  billNo: 'SQ-1',
  vchDate: DAY,
  taxRatePct: 0,
  interState: false,
  cashAmt: 10,
  discountAmount: 5,
  description: 'sales quotation',
  oldGold: [
    {
      metal: 'G',
      itCode: 'OG',
      description: 'Old Gold Quote',
      pcs: 1,
      grossWt: 2,
      otherWt: 0.1,
      netWt: 1.9,
      touch: 90,
      rate: 100,
      rateType: 'F',
      amount: 171,
    },
  ],
  ...overrides,
});

const line = (overrides: Partial<SaleLineInput> = {}): SaleLineInput => ({
  itCode: 'GOLD',
  tagNo: 'TAG-Q1',
  pcs: 1,
  grossWt: 12,
  netWt: 10,
  touch: 90,
  rate: 100,
  labourType: 'per_gram',
  labourRate: 5,
  otherAmount: 25,
  tblCode: '001',
  designNo: 'DES-Q',
  remark: 'quoted ornament',
  ...overrides,
});

databaseDescribe('database-backed TR_SALE sales quotation mode', () => {
  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  beforeEach(async () => {
    await wipe();
    await seed();
  });

  afterAll(async () => {
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('persists SL QUOT rows without posting stock, ledger, tax, rojmel, bill-OS, or order rows', async () => {
    const created = await createSalesQuotation(runtime, saleInput(), [line()]);
    expect(created.vchNo).toBe(5);

    const opened = await getSalesQuotation(runtime, scope, created.vchNo);
    expect(opened).toMatchObject({
      voucherNo: '00005',
      hiddenVoucherNo: '00010',
      acCode: 'CUST',
      billNo: 'SQ-1',
    });
    expect((opened.lines as any[])[0]).toMatchObject({
      itCode: 'GOLD',
      tagNo: 'TAG-Q1',
      vchSrno: 0,
      tblCode: '001',
      designNo: 'DES-Q',
      remark: 'quoted ornament',
    });
    expect((opened.oldGold as any[])[0]).toMatchObject({
      itCode: 'OG',
      description: 'Old Gold Quote',
    });

    const rows = await query<{
      inout: string;
      book_name: string;
      vch_type: string;
      temp: number;
      sl_idtl: number;
      old_gold: number;
      ac: number;
      stock: number;
      tax: number;
      rojmel: number;
      bill_os: number;
      lot: number;
      order_adj: number;
    }>(
      `SELECT
         (SELECT min("INOUT_TYPE") FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') inout,
         (SELECT min("BOOK_NAME") FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') book_name,
         (SELECT min("VCH_TYPE") FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_type,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00010') temp,
         (SELECT count(*)::int FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sl_idtl,
         (SELECT count(*)::int FROM "SL_PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') old_gold,
         (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ac,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') stock,
         (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
         (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
         (SELECT count(*)::int FROM "BILL_OS_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') bill_os,
         (SELECT count(*)::int FROM "LOT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') lot,
         (SELECT count(*)::int FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "NEW_VCH_NO"='00005') order_adj`,
      TENANT,
      BOOK,
    );
    expect(rows[0]).toMatchObject({
      inout: 'O',
      book_name: 'SL QUOT',
      vch_type: 'QTPRN',
      temp: 1,
      sl_idtl: 1,
      old_gold: 1,
      ac: 0,
      stock: 0,
      tax: 0,
      rojmel: 0,
      bill_os: 0,
      lot: 0,
      order_adj: 0,
    });

    await editSalesQuotation(
      runtime,
      saleInput({ mainUser: 'editor', billNo: 'SQ-1E', cashAmt: 25 }),
      [line({ netWt: 8, grossWt: 9, touch: 91, designNo: 'DES-E' })],
      created.vchNo,
    );
    const edited = await getSalesQuotation(runtime, scope, created.vchNo);
    expect(edited).toMatchObject({ voucherNo: '00005', hiddenVoucherNo: '00010', billNo: 'SQ-1E' });
    expect((edited.lines as any[])[0]).toMatchObject({ grossWt: 9, netWt: 8, designNo: 'DES-E' });

    await deleteSalesQuotation(runtime, { scope, vchNo: created.vchNo, deleteUser: 'deleter' });
    const deleted = await query<{ sl_data: number; sl_detl: number; temp: number; del: number }>(
      `SELECT
         (SELECT count(*)::int FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sl_data,
         (SELECT count(*)::int FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sl_detl,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00010') temp,
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') del`,
      TENANT,
      BOOK,
    );
    expect(deleted[0]).toMatchObject({ sl_data: 0, sl_detl: 0, temp: 0, del: 2 });
  });
});
