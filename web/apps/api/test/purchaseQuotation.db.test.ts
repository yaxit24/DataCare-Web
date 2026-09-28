import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createPurchaseQuotation,
  deletePurchaseQuotation,
  editPurchaseQuotation,
  getPurchaseQuotation,
  type PurchaseInput,
  type PurchaseLineInput,
} from '../src/modules/purchase/purchase.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'purchase-quotation-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = '235';
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
    'BILL_OS_DATA',
    'TAX_DATA',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'BAR_IDTL',
    'BAR_DETL',
    'BAR_DATA',
    'PR_IDTL',
    'PR_DETL',
    'PR_DATA',
    'LOT_DETL',
    'MAIN_STOCK',
    'TEMP_BOOK_DATA',
    'BOOK_DETL',
    'BOOK_DATA',
    'ITEM_MAST',
    'GROUP_MAST',
    'AC_MAST',
    'YEAR_MAST',
    'CO_SET_NEW',
    'CO_SET',
  ]) {
    await exec(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seed() {
  await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`, TENANT, CO);
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","PR_TDS_TAX") VALUES ($1,$2,'N')`,
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
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
     VALUES ($1,$2,$3,'SUPP','Quotation Supplier','L')`,
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
     VALUES ($1,$2,$3,$4,'Purc Quotation','PRQUT','PR QUOT','O','Y','PR_DATA','PR_DETL')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  await exec(
    `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE")
     VALUES ($1,$2,$3,$4,$5,'00004',$6::date,'SUPP')`,
    TENANT,
    CO,
    LC,
    YEAR,
    BOOK,
    DAY,
  );
  await exec(
    `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
     VALUES ($1,$2,$3,$4,'00009','Purc Quotation')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
}

const purchaseInput = (overrides: Partial<PurchaseInput> = {}): PurchaseInput => ({
  scope,
  mainUser: 'creator',
  acCode: 'SUPP',
  acName: 'Quotation Supplier',
  billNo: 'PQ-1',
  vchDate: DAY,
  taxRatePct: 0,
  interState: false,
  discountAmount: 10,
  ...overrides,
});

const line = (overrides: Partial<PurchaseLineInput> = {}): PurchaseLineInput => ({
  itCode: 'GOLD',
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
  itDesc: 'Quoted ornament',
  rateType: 'G',
  stones: [{ isrNo: 1, itCode: 'DIA', dmCode: 'D1', dmName: 'Diamond', pcs: 2, grossWt: 0.5 }],
  ...overrides,
});

databaseDescribe('database-backed TR_PURC purchase quotation mode', () => {
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

  it('persists PR QUOT rows without posting stock, ledger, tax, rojmel, bill-OS, or lot rows', async () => {
    const created = await createPurchaseQuotation(runtime, purchaseInput(), [line()]);
    expect(created.vchNo).toBe(5);

    const opened = await getPurchaseQuotation(runtime, scope, created.vchNo);
    expect(opened).toMatchObject({
      voucherNo: '00005',
      hiddenVoucherNo: '00010',
      acCode: 'SUPP',
      billNo: 'PQ-1',
    });
    expect((opened.lines as any[])[0]).toMatchObject({
      itCode: 'GOLD',
      tblCode: '001',
      designNo: 'DES-Q',
      itDesc: 'Quoted ornament',
    });
    expect((opened.lines as any[])[0].stones).toHaveLength(1);

    const rows = await query<{
      inout: string;
      book_name: string;
      vch_type: string;
      temp: number;
      pr_idtl: number;
      ac: number;
      stock: number;
      tax: number;
      rojmel: number;
      bill_os: number;
      lot: number;
      bar: number;
    }>(
      `SELECT
         (SELECT min("INOUT_TYPE") FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') inout,
         (SELECT min("BOOK_NAME") FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') book_name,
         (SELECT min("VCH_TYPE") FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_type,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00010') temp,
         (SELECT count(*)::int FROM "PR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pr_idtl,
         (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ac,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') stock,
         (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
         (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
         (SELECT count(*)::int FROM "BILL_OS_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') bill_os,
         (SELECT count(*)::int FROM "LOT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') lot,
         (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') bar`,
      TENANT,
      BOOK,
    );
    expect(rows[0]).toMatchObject({
      inout: 'O',
      book_name: 'PR QUOT',
      vch_type: 'PRQUT',
      temp: 1,
      pr_idtl: 1,
      ac: 0,
      stock: 0,
      tax: 0,
      rojmel: 0,
      bill_os: 0,
      lot: 0,
      bar: 0,
    });

    await editPurchaseQuotation(
      runtime,
      purchaseInput({ mainUser: 'editor', billNo: 'PQ-1E' }),
      [line({ netWt: 8, grossWt: 9, touch: 91, designNo: 'DES-E' })],
      created.vchNo,
    );
    const edited = await getPurchaseQuotation(runtime, scope, created.vchNo);
    expect(edited).toMatchObject({ voucherNo: '00005', hiddenVoucherNo: '00010', billNo: 'PQ-1E' });
    expect((edited.lines as any[])[0]).toMatchObject({ grossWt: 9, netWt: 8, designNo: 'DES-E' });

    await deletePurchaseQuotation(runtime, { scope, vchNo: created.vchNo, deleteUser: 'deleter' });
    const deleted = await query<{ pr_data: number; pr_detl: number; temp: number; del: number }>(
      `SELECT
         (SELECT count(*)::int FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pr_data,
         (SELECT count(*)::int FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pr_detl,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00010') temp,
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') del`,
      TENANT,
      BOOK,
    );
    expect(deleted[0]).toMatchObject({ pr_data: 0, pr_detl: 0, temp: 0, del: 2 });
  });
});
