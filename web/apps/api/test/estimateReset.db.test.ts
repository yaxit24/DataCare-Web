import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  ESTIMATE_RESET_CONFIRMATION,
  applyEstimateReset,
  estimateResetPreview,
} from '../src/modules/utilities/estimateReset.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'estimate-reset';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const AS_OF = '2024-04-30';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
const query = <T = any>(sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$queryRawUnsafe(sql, ...p)) as Promise<T[]>;

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const row of rows)
    await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seedBook(
  coBook: string,
  values: Partial<{ bookType: string; mainBook: string; reset: string }>,
) {
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","BOOK_TYPE","MAIN_BOOK","RESET_BOOK","DATA_TYPE")
     VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,'O')`,
    TENANT,
    CO,
    LC,
    coBook,
    values.mainBook ?? coBook,
    coBook,
    values.bookType ?? null,
    values.mainBook ?? null,
    values.reset ?? 'N',
  );
}

async function seedSourceTag(tag: string, vchSrno: number, vchNo: string) {
  await exec(
    `INSERT INTO "BAR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_IT_CODE","HD_VCH_NO","DATA_TRFR")
     VALUES ($1,$2,$3,$4,'SRC',$5,'2024-04-01','GLD',$5,'N')`,
    TENANT,
    CO,
    LC,
    YEAR,
    vchNo,
  );
  await exec(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE","ITM_AMT")
     VALUES ($1,$2,$3,$4,'SRC',$5,1,'2024-04-01','ORN',$6,$7,1,10,9,91.6,8.244,50000)`,
    TENANT,
    CO,
    LC,
    YEAR,
    vchNo,
    tag,
    vchSrno,
  );
  await exec(
    `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE")
     VALUES ($1,$2,$3,$4,'SRC',$5,1,1,'2024-04-01',$6,$7,'DM')`,
    TENANT,
    CO,
    LC,
    YEAR,
    vchNo,
    tag,
    vchSrno,
  );
  await exec(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT")
     VALUES ($1,$2,$3,$4,'SRC',$5,1,'2024-04-01','ORN',$6,$7,1,10,9)`,
    TENANT,
    CO,
    LC,
    YEAR,
    vchNo,
    tag,
    vchSrno,
  );
}

async function seed() {
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_NAME","CO_TYPE") VALUES ($1,$2,$3,'Estimate Reset Co','')`,
    TENANT,
    CO,
    LC,
  );
  await seedBook('026', { bookType: 'M', mainBook: 'SALES', reset: 'Y' });
  await seedBook('TGC', { mainBook: 'TAG CANCEL', reset: 'Y' });
  await seedBook('WHS', { mainBook: 'WH SALES', reset: 'Y' });
  await seedBook('NRM', { bookType: 'M', mainBook: 'SALES', reset: 'N' });

  await seedSourceTag('TAG1', 11, 'SRC001');
  await seedSourceTag('TAG2', 22, 'SRC002');
  await seedSourceTag('TAG3', 33, 'SRC003');
  await seedSourceTag('STAY', 44, 'SRC004');

  await exec(
    `INSERT INTO "BAR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_IT_CODE")
     VALUES ($1,$2,$3,$4,'NUL','NULL01','2024-04-01',NULL)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );

  await exec(
    `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","BILL_OS","AC_CODE","NET_AMT","DATA_TRFR")
     VALUES ($1,$2,$3,$4,'026','00001','2024-04-10',0,'AC001',100,'N'),
            ($1,$2,$3,$4,'026','00002','2024-04-10',25,'AC001',200,'N'),
            ($1,$2,$3,$4,'NRM','00003','2024-04-10',0,'AC001',300,'N')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","ITM_REMARK","ITM_PCS","ITM_GWT","ITM_NWT")
     VALUES ($1,$2,$3,$4,'026','00001',1,'2024-04-10','AC001','ORN','TAG1',11,'Sale line',1,10,9),
            ($1,$2,$3,$4,'026','00002',1,'2024-04-10','AC001','ORN','KEEP',99,'Open bill',1,1,1)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE")
     VALUES ($1,$2,$3,$4,'026','00001',1,1,'2024-04-10','TAG1',11,'DM')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "SL_PR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","IT_CODE")
     VALUES ($1,$2,$3,$4,'026','00001',1,'2024-04-10','AC001','OLD')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","LEDR_KEY","BOOK_NAME","AC_CODE","DR_AMT","CR_AMT","IT_TYPE","SIGN","FINE_WT","DATA_TRFR")
     VALUES ($1,$2,$3,$4,'026','00001','2024-04-10','sale-ledger','SALES','AC001',100,0,'A','D',0,'N'),
            ($1,$2,$3,$4,'WHS','WH001','2024-04-12','wh-ledger','WH SALES','AC001',0,100,'A','C',0,'N')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "ROJ_MEL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","BOOK_NAME","AC_CODE")
     VALUES ($1,$2,$3,$4,'026','00001','roj-sale','2024-04-10','SALES','AC001'),
            ($1,$2,$3,$4,'WHS','WH001','roj-wh','2024-04-12','WH SALES','AC001')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "FINE_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","IT_CODE","ITM_FINE")
     VALUES ($1,$2,$3,$4,'026','00001',1,'2024-04-10','AC001','ORN',8.244),
            ($1,$2,$3,$4,'WHS','WH001',1,'2024-04-12','AC001','ORN',8.244)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS")
     VALUES ($1,$2,$3,$4,'026','00001',1,'2024-04-10','ORN','TAG1',11,1),
            ($1,$2,$3,$4,'WHS','WH001',1,'2024-04-12','ORN','TAG3',33,1)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );

  await exec(
    `INSERT INTO "BAR_CAN_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","HD_VCH_NO","DATA_TRFR")
     VALUES ($1,$2,$3,$4,'TGC','TC001','2024-04-11','TC001','N')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "BAR_CAN_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT")
     VALUES ($1,$2,$3,$4,'TGC','TC001',1,'2024-04-11','ORN','TAG2',22,1,10,9)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "BAR_CAN_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE")
     VALUES ($1,$2,$3,$4,'TGC','TC001',1,1,'2024-04-11','TAG2',22,'DM')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );

  await exec(
    `INSERT INTO "RATE_CUT_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_TYPE","AC_CODE","SL_BILL_OS","PR_BILL_OS","TOT_FINE_DR","DATA_TRFR")
     VALUES ($1,$2,$3,$4,'WHS','WH001','2024-04-12','G','AC001',0,0,1,'N')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "RATE_CUT_ISU"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","ITM_REMARK","ITM_PCS","ITM_GWT","ITM_NWT")
     VALUES ($1,$2,$3,$4,'WHS','WH001',1,'2024-04-12','AC001','ORN','TAG3',33,'Wh line',1,10,9)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "RATE_CUT_REC"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO")
     VALUES ($1,$2,$3,$4,'WHS','WH001',1,'2024-04-12','AC001','ORN','TAG3',33)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE")
     VALUES ($1,$2,$3,$4,'WHS','WH001',1,1,'2024-04-12','TAG3',33,'DM')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );

  await exec(
    `INSERT INTO "APR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","HD_VCH_NO","AC_CODE")
     VALUES ($1,$2,$3,$4,'APR','APR001','2024-04-13','APR001','AC001'),
            ($1,$2,$3,$4,'APR','APR002','2024-04-13','APR002','AC001'),
            ($1,$2,$3,$4,'APR','APR003','2024-04-13','APR003','AC001')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
  await exec(
    `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","BOOK_NAME","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS")
     VALUES ($1,$2,$3,$4,'APR','APR001',1,'2024-04-13','AC001','APR ISU','ORN','MISSING',55,1),
            ($1,$2,$3,$4,'APR','APR002',1,'2024-04-13','AC001','APR ISU','ORN','TAG1',11,1),
            ($1,$2,$3,$4,'APR','APR003',1,'2024-04-13','AC001','APR ISU','ORN','STAY',44,1)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
}

function diff(preview: Awaited<ReturnType<typeof estimateResetPreview>>, table: string) {
  const row = preview.diffs.find((entry) => entry.table === table);
  if (!row) throw new Error(`${table} missing from diff`);
  return row;
}

async function count(table: string, extra = ''): Promise<number> {
  const rows = await query<{ n: number }>(
    `SELECT count(*)::int AS n FROM "${table}" WHERE tenant_id=$1 ${extra}`,
    TENANT,
  );
  return Number(rows[0]?.n ?? 0);
}

describe.runIf(RUN)('UT_IMPORT Estimate Reset utility', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('previews and applies reset-book estimate, tag-cancel and wholesale cleanup', async () => {
    const preview = await estimateResetPreview(runtime, scope, AS_OF);
    expect(preview.kind).toBe('datacare.ut-import-estimate-reset/1.0');
    expect(preview.totals.selectedVouchers).toBe(3);
    expect(preview.totals.stockAdjustmentDetails).toBe(3);
    expect(diff(preview, 'SL_DATA').delete).toBe(1);
    expect(diff(preview, 'BAR_CAN_DATA')).toMatchObject({ insert: 3, delete: 1 });
    expect(diff(preview, 'BAR_CAN_DETL')).toMatchObject({ insert: 3, delete: 1 });
    expect(diff(preview, 'RATE_CUT_DATA').delete).toBe(1);
    expect(diff(preview, 'APR_DETL').delete).toBe(2);
    expect(diff(preview, 'APR_DATA').delete).toBe(2);

    await expect(
      applyEstimateReset(runtime, scope, { asOfDate: AS_OF, confirmation: 'wrong' }),
    ).rejects.toThrow(/RESET ESTIMATE/);

    const applied = await applyEstimateReset(runtime, scope, {
      asOfDate: AS_OF,
      confirmation: ESTIMATE_RESET_CONFIRMATION,
    });
    expect(applied.applied).toBe(true);
    expect(applied.totals.selectedVouchers).toBe(3);
    expect(diff(applied, 'BAR_CAN_DETL')).toMatchObject({ insert: 3, delete: 1 });

    expect(await count('SL_DATA', `AND "CO_BOOK"='026' AND "VCH_NO"='00001'`)).toBe(0);
    expect(await count('SL_DATA', `AND "CO_BOOK"='026' AND "VCH_NO"='00002'`)).toBe(1);
    expect(await count('SL_DATA', `AND "CO_BOOK"='NRM' AND "VCH_NO"='00003'`)).toBe(1);
    expect(await count('RATE_CUT_DATA', `AND "CO_BOOK"='WHS' AND "VCH_NO"='WH001'`)).toBe(0);
    expect(await count('BAR_CAN_DATA', `AND "CO_BOOK"='TGC' AND "VCH_NO"='TC001'`)).toBe(0);
    expect(await count('BAR_DETL', `AND "TAG_NO" IN ('TAG1','TAG2','TAG3')`)).toBe(0);
    expect(await count('BAR_DETL', `AND "TAG_NO"='STAY'`)).toBe(1);
    expect(await count('APR_DETL')).toBe(1);
    expect(await count('APR_DATA')).toBe(1);
    expect(await count('APR_DETL', `AND "TAG_NO"='STAY'`)).toBe(1);

    const adjust = await query<{
      headers: number;
      details: number;
      temp_rows: number;
      sign: string | null;
      transfer: string | null;
    }>(
      `SELECT
         (SELECT count(*)::int FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='163') AS headers,
         (SELECT count(*)::int FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='163') AS details,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='163') AS temp_rows,
         (SELECT min("ITM_SIGN") FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='163') AS sign,
         (SELECT min("DATA_TRFR") FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='163') AS transfer`,
      TENANT,
    );
    expect(adjust[0]).toMatchObject({
      headers: 3,
      details: 3,
      temp_rows: 3,
      sign: '-',
      transfer: 'N',
    });

    const barData = await query<{ stk: string | null }>(
      `SELECT "STK_IT_CODE" AS stk FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='NUL'`,
      TENANT,
    );
    expect(barData[0]?.stk).toBe('');
  });
});
