import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteTagAdjust,
  getTagAdjust,
  saveTagAdjust,
  TagAdjustError,
} from '../src/modules/stock/tagAdjust.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'tag-adjust-db';
const CO = '91';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'TAD';
const DAY = '2024-04-15';
const TAG = 'TAG001';
const VCH_SRNO = 7;
const SOURCE_BOOK = 'SRC';
const SOURCE_VCH = '00088';

let owner: PrismaClient;
let runtime: PrismaClient;

const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

async function wipe(): Promise<void> {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const row of rows) {
    await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

const exec = (sql: string, ...p: unknown[]): Promise<number> => owner.$executeRawUnsafe(sql, ...p);
const query = <T = Record<string, unknown>>(sql: string, ...p: unknown[]): Promise<T[]> =>
  owner.$queryRawUnsafe(sql, ...p) as Promise<T[]>;

async function seedTagAdjustBook(book = BOOK, mainBook = 'TAG ADJ'): Promise<void> {
  await exec(
    `INSERT INTO "BOOK_DATA"(
       tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
       "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Tag Adjust','TADJ',$5,'T','Y','BAR_CAN_DATA')`,
    TENANT,
    CO,
    LC,
    book,
    mainBook,
  );
}

async function seed(): Promise<void> {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
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
  await seedTagAdjustBook();
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
     VALUES ($1,$2,'ORN','Ornament','G'),($1,$2,'DM','Diamond','D')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME") VALUES ($1,$2,'AC001','Tag Party')`,
    TENANT,
    CO,
  );

  await exec(
    `INSERT INTO "BAR_DETL"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
       "VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO",
       "LOT_NO","DESIGN_NO","TBL_CODE","ITM_SIZE","ITM_PCS","BAG_WT","ITM_GWT",
       "ITM_OTH_WT","ITM_NWT","ITM_GHT_WT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE",
       "LBR_PRC","LBR_TYPE","LBR_RATE","LBR_AMT","OTH_AMT","ITM_RATE","ITM_AMT","ITM_MRP",
       "TAG_COST","KR_NET_WT","KR_TOUCH","KR_WEST_PRC","KR_FINE","KR_NAME","RATE_TYPE","IT_TYPE",
       "PR_CODE","DATA_TYPE","ITM_REMARK","HD_VCH_NO","MAIN_USER","DESIGN_IMG_ID","ITM_STYLE","ITM_COLOR")
     VALUES (
       $1,$2,$3,$4,$5,$6,1,'2024-04-01','OPN','I','T','TAG OPEN','AC001','ORN',$7,$8,
       'LOT-1','DES-1','T01','18',1,0.125,12.5,0.5,12,0,91.6,1.5,11.172,
       0,'G',25,25,50,5000,60000,65000,58000,12,90,1,10.92,'KR01','F','G','P1','O',
       'source remark',$6,'seed-user','IMG-1','CLASSIC','YELLOW')`,
    TENANT,
    CO,
    LC,
    YEAR,
    SOURCE_BOOK,
    SOURCE_VCH,
    TAG,
    VCH_SRNO,
  );

  await exec(
    `INSERT INTO "BAR_IDTL"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
       "VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","AC_CODE","TAG_NO","VCH_SRNO",
       "IT_CODE","IT_TYPE","DM_CODE","DM_SIZE","DM_SFNO","DM_LEB","DM_NAME","DM_ORIGIN",
       "DM_REMARK","DM_COLOR","IT_PCS","IT_PCS_WT","KR_WT","KR_LESS_PRC","IT_GWT",
       "IT_CON_PRC","IT_CON_WT","IT_RATE_TYPE","IT_RATE","IT_AMT","IT_LBR_RATE","IT_LBR_AMT",
       "IT_NET_AMT","KR_CON_PRC","KR_CON_WT","KR_RATE","KR_AMT","KR_LBR_RATE","KR_LBR_AMT",
       "KR_NET_AMT","MAIN_USER")
     VALUES (
       $1,$2,$3,$4,$5,$6,1,1,'2024-04-01','OPN','I','T','TAG OPEN','AC001',$7,$8,
       'DM','D','DMD001','1.5','SF1','LEB','Round','IND','clean','WHITE',2,0.45,0.45,0,
       0.45,100,0.0045,'P',25000,11250,0,0,11250,100,0.0045,25000,11250,0,0,11250,'seed-user')`,
    TENANT,
    CO,
    LC,
    YEAR,
    SOURCE_BOOK,
    SOURCE_VCH,
    TAG,
    VCH_SRNO,
  );

  await exec(
    `INSERT INTO "MAIN_STOCK"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
       "VCH_TYPE","BOOK_NAME","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_PCS",
       "ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE","ITM_RATE","ITM_AMT","MAIN_USER","DATA_TYPE")
     VALUES ($1,$2,$3,$4,$5,$6,1,'2024-04-01','OPN','TAG OPEN','AC001','ORN',$7,$8,'+',1,12.5,12,91.6,11.172,5000,60000,'seed-user','O')`,
    TENANT,
    CO,
    LC,
    YEAR,
    SOURCE_BOOK,
    SOURCE_VCH,
    TAG,
    VCH_SRNO,
  );
}

async function currentState(): Promise<Record<string, unknown>> {
  const rows = await query(
    `SELECT
       (SELECT count(*)::int FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') AS headers,
       (SELECT count(*)::int FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') AS details,
       (SELECT count(*)::int FROM "BAR_CAN_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') AS stones,
       (SELECT min("DATA_TYPE") FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') AS audit_type,
       (SELECT min("ITM_REMARK") FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') AS audit_remark,
       (SELECT min("DM_CODE") FROM "BAR_CAN_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001') AS stone_code,
       (SELECT min("DATA_TYPE") FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"=$3 AND "VCH_SRNO"=$4) AS bar_type,
       (SELECT min("DATA_TYPE") FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$3 AND "VCH_SRNO"=$4) AS stock_type`,
    TENANT,
    BOOK,
    TAG,
    VCH_SRNO,
  );
  return rows[0] ?? {};
}

databaseDescribe('TR_TAG_CAN Tag Adjust mode', () => {
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

  it('records a BAR_CAN voucher and updates live tag data type on save, edit and delete', async () => {
    const created = await saveTagAdjust(runtime, {
      scope,
      vchDate: DAY,
      acCode: 'AC001',
      vchDesc: 'Change data type',
      mainUser: 'web-user',
      lines: [{ tagNo: TAG, itCode: 'ORN', vchSrno: VCH_SRNO, dataType: 'N', remark: 'new type' }],
    });

    expect(created).toEqual({
      vchNo: 1,
      lines: 1,
      stones: 1,
      barDetlUpdated: 1,
      mainStockUpdated: 1,
    });
    expect(await currentState()).toMatchObject({
      headers: 1,
      details: 1,
      stones: 1,
      audit_type: 'N',
      audit_remark: 'new type',
      stone_code: 'DMD001',
      bar_type: 'N',
      stock_type: 'N',
    });

    const loaded = await getTagAdjust(runtime, scope, 1);
    expect(loaded?.header).toMatchObject({ CO_BOOK: BOOK, VCH_NO: '00001', AC_CODE: 'AC001' });
    expect(loaded?.lines).toHaveLength(1);
    expect(loaded?.lines[0]).toMatchObject({
      TAG_NO: TAG,
      VCH_SRNO,
      IT_CODE: 'ORN',
      DATA_TYPE: 'N',
    });
    expect(loaded?.stones).toHaveLength(1);
    expect(loaded?.stones[0]).toMatchObject({ TAG_NO: TAG, VCH_SRNO, DM_CODE: 'DMD001' });

    const edited = await saveTagAdjust(runtime, {
      scope,
      vchNo: 1,
      vchDate: DAY,
      acCode: 'AC001',
      vchDesc: 'Change data type again',
      mainUser: 'web-user',
      lines: [{ tagNo: TAG, itCode: 'ORN', vchSrno: VCH_SRNO, dataType: 'R', remark: 'retagged' }],
    });
    expect(edited).toEqual({
      vchNo: 1,
      lines: 1,
      stones: 1,
      barDetlUpdated: 1,
      mainStockUpdated: 1,
    });
    expect(await currentState()).toMatchObject({
      headers: 1,
      details: 1,
      stones: 1,
      audit_type: 'R',
      audit_remark: 'retagged',
      stone_code: 'DMD001',
      bar_type: 'R',
      stock_type: 'R',
    });

    await expect(deleteTagAdjust(runtime, scope, '00001')).resolves.toEqual({ deleted: true });
    expect(await currentState()).toMatchObject({
      headers: 0,
      details: 0,
      stones: 0,
      audit_type: null,
      audit_remark: null,
      stone_code: null,
      bar_type: 'R',
      stock_type: 'R',
    });
  });

  it('rejects non-TAG ADJ books that share the TR_TAG_CAN form', async () => {
    await seedTagAdjustBook('TGC', 'TAG CANCEL');
    await expect(
      saveTagAdjust(runtime, {
        scope: { ...scope, coBook: 'TGC' },
        vchDate: DAY,
        mainUser: 'web-user',
        lines: [{ tagNo: TAG, itCode: 'ORN', vchSrno: VCH_SRNO, dataType: 'N' }],
      }),
    ).rejects.toThrow(TagAdjustError);
  });
});
