import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteStoneDmCf,
  getStoneDmCf,
  listStoneDmCfSources,
  saveStoneDmCf,
  StoneDmCfValidationError,
} from '../src/modules/stock/stoneDmCf.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'stone-dm-cf-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'SFP';
const DAY = '2024-04-16';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

let owner: PrismaClient;
let runtime: PrismaClient;

const exec = (sql: string, ...params: unknown[]): Promise<number> =>
  owner.$executeRawUnsafe(sql, ...params);
const query = <T = Record<string, unknown>>(sql: string, ...params: unknown[]): Promise<T[]> =>
  owner.$queryRawUnsafe(sql, ...params) as Promise<T[]>;

async function cleanup(): Promise<void> {
  for (const table of [
    'REMARK_DATA',
    'BAR_CAN_DETL',
    'BAR_CAN_DATA',
    'TEMP_BOOK_DATA',
    'MAIN_STOCK',
    'BAR_DETL',
    'ITEM_MAST',
    'BOOK_DATA',
    'YEAR_MAST',
    'CO_SET',
  ]) {
    await exec(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seedBook(book = BOOK, mainBook = 'SF PRINT'): Promise<void> {
  await exec(
    `INSERT INTO "BOOK_DATA"(
       tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
       "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Stone/Dm-Cf','SFPR',$5,'O','Y','BAR_CAN_DATA')`,
    TENANT,
    CO,
    LC,
    book,
    mainBook,
  );
}

async function seedTag(tagNo: string, vchSrno: number, netWt: number): Promise<void> {
  await exec(
    `INSERT INTO "BAR_DETL"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
       "VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","IT_CODE","TAG_NO","VCH_SRNO",
       "DESIGN_NO","TBL_CODE","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT",
       "ITM_TOUCH","ITM_FINE","LBR_RATE","LBR_TYPE","LBR_AMT","OTH_AMT","TAG_COST",
       "ITM_MRP","KR_NAME","KR_COST","EMP_ISU","MAIN_USER","DESIGN_IMG_ID","ITM_REMARK")
     VALUES ($1,$2,$3,$4,'TOP',$5,$6,$7::date,'TGEN','I','O','TAG GEN','GOLD',$8,$9,
             'D1','001','M',1,$10,0,$10,100,$10,50,'P',50,10,1000,1500,'K1',1200,'N','seed','IMG1','source remark')`,
    TENANT,
    CO,
    LC,
    YEAR,
    `O${vchSrno}`,
    vchSrno,
    DAY,
    tagNo,
    vchSrno,
    netWt,
  );
  await exec(
    `INSERT INTO "MAIN_STOCK"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
       "VCH_DATE","VCH_TYPE","BOOK_NAME","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE",
       "ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","DATA_TYPE")
     VALUES ($1,$2,$3,$4,'TOP',$5,$6,1,$7::date,'TAGOP','TAG OPBL','GOLD',$8,$9,'P','+',1,$10,$10,$10,'O')`,
    TENANT,
    CO,
    LC,
    YEAR,
    `O${vchSrno}`,
    vchSrno,
    DAY,
    tagNo,
    vchSrno,
    netWt,
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
  await seedBook();
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
     VALUES ($1,$2,'GOLD','Gold Ornament','G'),($1,$2,'DM','Diamond','D')`,
    TENANT,
    CO,
  );
  await seedTag('TAG001', 1, 10);
  await seedTag('TAG002', 2, 12);
}

async function state(): Promise<Record<string, unknown>> {
  const rows = await query(
    `SELECT
       (SELECT count(*)::int FROM "BAR_CAN_DATA" WHERE tenant_id=$1) headers,
       (SELECT count(*)::int FROM "BAR_CAN_DETL" WHERE tenant_id=$1) details,
       (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_rows,
       (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1) remarks,
       (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) stock_rows,
       (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1) tag_rows,
       (SELECT min("BOOK_NAME") FROM "BAR_CAN_DETL" WHERE tenant_id=$1) book_name,
       (SELECT min("DATA_TRFR") FROM "BAR_CAN_DATA" WHERE tenant_id=$1) header_transfer,
       (SELECT "ITM_COLOUR" FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001' LIMIT 1) tag_colour,
       (SELECT "ITM_POLISH" FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001' LIMIT 1) tag_purity,
       (SELECT "ITM_CF_NO" FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001' LIMIT 1) tag_cf,
       (SELECT "ITM_MRP"::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001' LIMIT 1) tag_mrp,
       (SELECT "TAG_COST"::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001' LIMIT 1) tag_cost,
       (SELECT "OLD_SRNO"::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001' LIMIT 1) old_srno,
       (SELECT "TAG_NO" FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "IT_CODE"='DM' LIMIT 1) manual_tag,
       (SELECT "ITM_CF_NO" FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "IT_CODE"='DM' LIMIT 1) manual_cf`,
    TENANT,
  );
  return rows[0] ?? {};
}

databaseDescribe('TR_PHYSTK Stone/Dm-Cf SF PRINT mode', () => {
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
    await cleanup();
    await seed();
  });

  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('saves, reads, edits and deletes SF PRINT certificate rows without moving stock', async () => {
    const available = await listStoneDmCfSources(
      runtime,
      TENANT,
      { CO_CODE: CO, LC_CODE: LC },
      { tagNo: 'TAG001' },
    );
    expect(available).toMatchObject([
      { tagNo: 'TAG001', vchSrno: 1, itCode: 'GOLD', designNo: 'D1', grossWt: 10, tagCost: 1200 },
    ]);

    const created = await saveStoneDmCf(runtime, {
      scope,
      vchDate: DAY,
      employeeCode: 'E1',
      description: 'Certificate print',
      mainUser: 'sf-user',
      lines: [
        {
          tagNo: 'TAG001',
          vchSrno: 1,
          color: 'WHITE',
          purity: 'VVS',
          size: '1.5',
          certificateNo: 'CF-001',
          remark: 'laser cert',
          mrp: 2500,
        },
        {
          itCode: 'DM',
          designNo: 'LOOSE-1',
          color: 'BLUE',
          purity: 'VS',
          size: '2.0',
          certificateNo: 'CF-MAN',
          pieces: 1,
          grossWt: 2.2,
          netWt: 2.2,
          fineWt: 2.2,
          labourAmount: 25,
          otherAmount: 10,
          mrp: 5000,
          karigarName: 'K2',
        },
      ],
    });
    expect(created).toEqual({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      created: true,
      lines: 2,
    });
    expect(await state()).toMatchObject({
      headers: 1,
      details: 2,
      temp_rows: 1,
      remarks: 1,
      stock_rows: 2,
      tag_rows: 2,
      book_name: 'SF PRINT',
      header_transfer: 'Y',
      tag_colour: 'WHITE',
      tag_purity: 'VVS',
      tag_cf: 'CF-001',
      tag_mrp: 2500,
      tag_cost: 1200,
      old_srno: 1,
      manual_tag: '',
      manual_cf: 'CF-MAN',
    });

    await expect(
      saveStoneDmCf(runtime, {
        scope,
        vchDate: DAY,
        mainUser: 'sf-user',
        lines: [{ tagNo: 'TAG001', vchSrno: 1, color: 'DUP', pieces: 1, grossWt: 1 }],
      }),
    ).rejects.toThrow(/already present/);

    const loaded = await getStoneDmCf(runtime, scope, created.voucherNo);
    expect(loaded).toMatchObject({
      voucherNo: '00001',
      vchDate: DAY,
      employeeCode: 'E1',
      description: 'Certificate print',
      hiddenVoucherNo: '00001',
      mainUser: 'sf-user',
      lines: [
        {
          tagNo: 'TAG001',
          vchSrno: 1,
          color: 'WHITE',
          purity: 'VVS',
          certificateNo: 'CF-001',
          mrp: 2500,
        },
        {
          tagNo: '',
          vchSrno: 0,
          itCode: 'DM',
          designNo: 'LOOSE-1',
          certificateNo: 'CF-MAN',
          grossWt: 2.2,
        },
      ],
    });

    await exec(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_NWT")
       VALUES ($1,$2,$3,$4,'SAL','00044',1,1,$5::date,'GOLD','TAG001',1,'-',10)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );

    const edited = await saveStoneDmCf(
      runtime,
      {
        scope,
        vchDate: DAY,
        employeeCode: 'E2',
        description: '',
        mainUser: 'other-user',
        lines: [
          {
            tagNo: 'TAG001',
            vchSrno: 1,
            color: 'YELLOW',
            purity: 'IF',
            certificateNo: 'CF-001-R',
            pieces: 1,
            grossWt: 10,
          },
        ],
      },
      created.voucherNo,
    );
    expect(edited).toEqual({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      created: false,
      lines: 1,
    });
    expect(await state()).toMatchObject({
      headers: 1,
      details: 1,
      temp_rows: 1,
      remarks: 0,
      stock_rows: 3,
      tag_rows: 2,
      tag_colour: 'YELLOW',
      tag_purity: 'IF',
      tag_cf: 'CF-001-R',
      old_srno: 1,
      manual_tag: null,
      manual_cf: null,
    });

    await expect(deleteStoneDmCf(runtime, scope, '00001')).resolves.toEqual({ reversed: true });
    expect(await state()).toMatchObject({
      headers: 0,
      details: 0,
      temp_rows: 0,
      remarks: 0,
      stock_rows: 3,
      tag_rows: 2,
      tag_colour: null,
      tag_purity: null,
      tag_cf: null,
    });
  });

  it('rejects non-SF PRINT books and unavailable/manual-empty rows', async () => {
    await seedBook('PHS', 'PHY STOCK');
    await expect(
      saveStoneDmCf(runtime, {
        scope: { ...scope, coBook: 'PHS' },
        vchDate: DAY,
        lines: [{ tagNo: 'TAG001', vchSrno: 1, color: 'WHITE' }],
      }),
    ).rejects.toBeInstanceOf(StoneDmCfValidationError);

    await expect(
      saveStoneDmCf(runtime, {
        scope,
        vchDate: DAY,
        lines: [{ tagNo: 'SOLD', vchSrno: 99, color: 'WHITE' }],
      }),
    ).rejects.toThrow(/unavailable/);

    await expect(
      saveStoneDmCf(runtime, {
        scope,
        vchDate: DAY,
        lines: [{ designNo: 'NO-WEIGHT', certificateNo: 'CF-EMPTY' }],
      }),
    ).rejects.toThrow(/pieces or gross weight/);
  });
});
