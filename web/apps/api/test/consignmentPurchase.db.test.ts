import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createPurchase,
  deletePurchase,
  editPurchase,
  getPurchase,
  listOpenConsignmentPurchaseReceipts,
  type PurchaseInput,
  type PurchaseLineInput,
} from '../src/modules/purchase/purchase.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'consignment-purchase-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DEST_BOOK = '203';
const SOURCE_BOOK = '201';
const SOURCE_VCH = '00003';
const DAY = '2024-04-10';

const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: DEST_BOOK,
};

let owner: PrismaClient;
let runtime: PrismaClient;

const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
const query = <T = Record<string, unknown>>(sql: string, ...params: unknown[]): Promise<T[]> =>
  owner.$queryRawUnsafe(sql, ...params) as Promise<T[]>;

async function wipe() {
  for (const table of [
    'DELETE_DATA',
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
    'APR_IDTL',
    'APR_DETL',
    'APR_DATA',
    'LOT_DETL',
    'MAIN_STOCK',
    'TEMP_BOOK_DATA',
    'SRNO_MAST',
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
     VALUES ($1,$2,$3,'SUPP','Consignment Supplier','L'),
            ($1,$2,$3,'CTRL','Purchase Control','L'),
            ($1,$2,$3,'PURCAC','Purchase Account','L')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC")
     VALUES ($1,$2,'G01','Gold','PURCAC')`,
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
     VALUES ($1,$2,$3,$4,'Consignment Rec','CONRC','CON REC','I','Y','APR_DATA','APR_DETL'),
            ($1,$2,$3,$5,'Consignment Purc','CONPR','CON PUR','I','Y','PR_DATA','PR_DETL')`,
    TENANT,
    CO,
    LC,
    SOURCE_BOOK,
    DEST_BOOK,
  );
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,$4,1,'CTRL','CON PUR','I')`,
    TENANT,
    CO,
    LC,
    DEST_BOOK,
  );
  await exec(
    `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO") VALUES ($1,$2,$3,0,0)`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE")
     VALUES ($1,$2,$3,$4,$5,'00004',$6::date,'SUPP')`,
    TENANT,
    CO,
    LC,
    YEAR,
    DEST_BOOK,
    DAY,
  );
  await exec(
    `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
     VALUES ($1,$2,$3,$4,'00009','Consignment Purc')`,
    TENANT,
    CO,
    LC,
    DEST_BOOK,
  );
  await exec(
    `INSERT INTO "APR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE")
     VALUES ($1,$2,$3,$4,$5,$6,$7::date,'SUPP')`,
    TENANT,
    CO,
    LC,
    YEAR,
    SOURCE_BOOK,
    SOURCE_VCH,
    DAY,
  );
  await exec(
    `INSERT INTO "APR_DETL"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE",
       "VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","SR_NO","OLD_SRNO","VCH_SRNO",
       "IT_CODE","TAG_NO","CON_ISU_REC","ADJ_GWT","ADJ_NWT","ITM_PCS","ITM_GWT","ITM_NWT",
       "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","ITM_RATE","ITM_AMT","LBR_RATE","LBR_AMT","OTH_AMT","NET_AMT",
       "TBL_CODE","DESIGN_NO","LOT_NO","RATE_TYPE","IT_TYPE","PR_CODE")
     VALUES ($1,$2,$3,$4,$5,$6,$7::date,'SUPP','CONRC','I','A','CON REC',1,1,1,
       'GOLD','N','N',0,0,1,12,10,90,0,9,100,1000,5,50,25,1075,
       '001','DES-A','LOT-A','G','G','PR')`,
    TENANT,
    CO,
    LC,
    YEAR,
    SOURCE_BOOK,
    SOURCE_VCH,
    DAY,
  );
  await exec(
    `INSERT INTO "APR_IDTL"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TYPE","INOUT_TYPE","ENTRY_TYPE",
       "BOOK_NAME","AC_CODE","SR_NO","ISR_NO","IT_CODE","DM_CODE","DM_NAME","IT_PCS","IT_GWT",
       "IT_RATE_TYPE","IT_RATE","IT_AMT","IT_LBR_AMT","IT_NET_AMT","IT_TYPE")
     VALUES ($1,$2,$3,$4,$5,$6,$7::date,'CONRC','I','A','CON REC','SUPP',1,1,'DIA','D1','Diamond',2,0.5,'P',200,400,20,420,'G')`,
    TENANT,
    CO,
    LC,
    YEAR,
    SOURCE_BOOK,
    SOURCE_VCH,
    DAY,
  );
}

const purchaseInput = (overrides: Partial<PurchaseInput> = {}): PurchaseInput => ({
  scope,
  mainUser: 'creator',
  acCode: 'SUPP',
  acName: 'Consignment Supplier',
  vchDate: DAY,
  taxRatePct: 0,
  interState: false,
  consiNo: SOURCE_VCH,
  consiYrcd: YEAR,
  consiDbcd: SOURCE_BOOK,
  purchaseAc: 'PURCAC',
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
  designNo: 'DES-A',
  lotNo: 'LOT-A',
  rateType: 'G',
  prCode: 'PR',
  consiNo: SOURCE_VCH,
  consiYrcd: YEAR,
  consiDbcd: SOURCE_BOOK,
  consiSrno: 1,
  stones: [{ isrNo: 1, itCode: 'DIA', dmCode: 'D1', dmName: 'Diamond', pcs: 2, grossWt: 0.5 }],
  ...overrides,
});

databaseDescribe('database-backed TR_PR_SL_UAE consignment purchase mode', () => {
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

  it('imports open CON REC lines, posts CON PUR, preserves references on edit, and reverses source flags on delete', async () => {
    const open = await listOpenConsignmentPurchaseReceipts(runtime, scope);
    expect(open).toMatchObject({
      receipts: [
        expect.objectContaining({
          voucherNo: SOURCE_VCH,
          coBook: SOURCE_BOOK,
          acCode: 'SUPP',
          balanceGrossWt: 12,
          balanceNetWt: 10,
        }),
      ],
    });

    const imported = await listOpenConsignmentPurchaseReceipts(runtime, scope, {
      sourceVchNo: SOURCE_VCH,
      sourceCoYear: YEAR,
      sourceCoBook: SOURCE_BOOK,
    });
    expect(imported).toMatchObject({
      source: expect.objectContaining({ voucherNo: SOURCE_VCH, coBook: SOURCE_BOOK }),
      lines: [
        expect.objectContaining({
          itCode: 'GOLD',
          consiNo: SOURCE_VCH,
          consiYrcd: YEAR,
          consiDbcd: SOURCE_BOOK,
          consiSrno: 1,
          stones: [expect.objectContaining({ dmCode: 'D1', pcs: 2 })],
        }),
      ],
    });

    const created = await createPurchase(runtime, purchaseInput(), [line()]);
    expect(created.vchNo).toBe(5);

    const afterCreate = await query(
      `SELECT
         (SELECT min("SL_BILL_NO") FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sl_bill,
         (SELECT min("SL_BILL_DBCD") FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sl_book,
         (SELECT min("CONSI_NO") FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') consi_no,
         (SELECT min("CONSI_SRNO")::float FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') consi_srno,
         (SELECT min("ADJ_GWT")::float FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) adj_gwt,
         (SELECT min("ADJ_NWT")::float FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) adj_nwt,
         (SELECT min("CON_ISU_REC") FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) source_flag,
         (SELECT count(*)::int FROM "PR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pr_idtl`,
      TENANT,
      DEST_BOOK,
      SOURCE_BOOK,
      SOURCE_VCH,
    );
    expect(afterCreate[0]).toMatchObject({
      sl_bill: SOURCE_VCH,
      sl_book: SOURCE_BOOK,
      consi_no: SOURCE_VCH,
      consi_srno: 1,
      adj_gwt: 12,
      adj_nwt: 10,
      source_flag: 'Y',
      pr_idtl: 1,
    });
    await expect(getPurchase(runtime, scope, created.vchNo)).resolves.toMatchObject({
      voucherNo: '00005',
      consiNo: SOURCE_VCH,
      consiDbcd: SOURCE_BOOK,
      lines: [expect.objectContaining({ consiNo: SOURCE_VCH, consiSrno: 1 })],
    });

    await expect(createPurchase(runtime, purchaseInput(), [line()])).rejects.toThrow(
      /already purchased: 1/,
    );

    await editPurchase(runtime, purchaseInput({ mainUser: 'editor' }), [line({ grossWt: 8, netWt: 7 })], created.vchNo);
    const afterEdit = await query(
      `SELECT "ADJ_GWT"::float adj_gwt,"ADJ_NWT"::float adj_nwt,"CON_ISU_REC" source_flag
         FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      TENANT,
      SOURCE_BOOK,
      SOURCE_VCH,
    );
    expect(afterEdit[0]).toMatchObject({ adj_gwt: 8, adj_nwt: 7, source_flag: 'Y' });

    await expect(deletePurchase(runtime, { scope, vchNo: created.vchNo, deleteUser: 'deleter' })).resolves.toEqual({
      reversed: true,
    });
    const afterDelete = await query(
      `SELECT
         (SELECT count(*)::int FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pr_data,
         (SELECT count(*)::int FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pr_detl,
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') delete_rows,
         (SELECT min("ADJ_GWT")::float FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) adj_gwt,
         (SELECT min("ADJ_NWT")::float FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) adj_nwt,
         (SELECT min("CON_ISU_REC") FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) source_flag`,
      TENANT,
      DEST_BOOK,
      SOURCE_BOOK,
      SOURCE_VCH,
    );
    expect(afterDelete[0]).toMatchObject({
      pr_data: 0,
      pr_detl: 0,
      delete_rows: 2,
      adj_gwt: 0,
      adj_nwt: 0,
      source_flag: 'N',
    });
  }, 30_000);
});
