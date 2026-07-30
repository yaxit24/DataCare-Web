import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteWholesaleSaleReturn,
  getWholesaleSaleReturn,
  saveWholesaleSaleReturn,
  WholesaleSaleReturnValidationError,
} from '../src/modules/sales/wholesaleSaleReturn.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'wh-sale-rtn-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'WRT';
const DAY = '2024-04-10';
const NEXT_DAY = '2024-04-11';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

const input = (date = DAY, description = 'Wholesale return', mainUser = 'return-user') => ({
  scope,
  vchDate: date,
  partyCode: 'PARTY',
  billNo: 'RTN-1',
  description,
  mainUser,
  cashAmount: 10,
  chequeAmount: 20,
  cardAmount: 30,
  kasarAmount: 5,
  bankAccount: 'BANK',
  cardAccount: 'CARD',
  chequeNo: 'CHQ-101',
  lines: [
    {
      tagNo: 'TAG001',
      tagVoucherSrNo: 101,
      sourceYear: YEAR,
      sourceBook: 'WHS',
      sourceVoucherNo: '00020',
      rateType: 'P',
      rate: 100,
      labourType: 'P',
      labourRate: 10,
      otherAmount: 5,
      remark: 'Returned tagged ornament',
    },
    {
      tagNo: 'N',
      itemCode: 'GOLD',
      tableCode: '001',
      designNo: 'LOOSE',
      size: 'M',
      pcs: 2,
      grossWt: 10,
      otherWt: 1,
      ghatPct: 0,
      touch: 90,
      westPct: 10,
      lessTouch: 2,
      rateType: 'P',
      rate: 50,
      labourType: 'P',
      labourRate: 5,
      otherAmount: 3,
      remark: 'Returned loose ornament',
      components: [{ dmCode: 'DIA', pcs: 1, weight: 0.5, rateType: 'W', rate: 100 }],
    },
  ],
});

databaseDescribe('database-backed wholesale sale return lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const tables = [
    'DELETE_DATA',
    'ROJ_MEL_DATA',
    'AC_DATA',
    'DM_DATA',
    'BAR_IDTL',
    'BAR_DETL',
    'BAR_DATA',
    'SL_IDTL',
    'RATE_CUT_REC',
    'RATE_CUT_ISU',
    'RATE_CUT_DATA',
    'TEMP_BOOK_DATA',
    'MAIN_STOCK',
    'DM_MAST',
    'ITEM_MAST',
    'AC_MAST',
    'BOOK_DETL',
    'BOOK_DATA',
    'YEAR_MAST',
    'CO_SET_NEW',
    'CO_SET',
  ];

  const cleanup = async () => {
    for (const table of tables) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","EMP_CODE_MANDATORY","TAX_ROF","LBR_ROF","ITM_RATE_ROF")
       VALUES ($1,$2,NULL,'N',2,2,2)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,2,2)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31'::timestamp)`,
      TENANT,
      CO,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
         "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'Configured Wholesale Return','WRT','WH RTN','I','Y','RATE_CUT_DATA','A')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE",
         "MAIN_BOOK","BOOK_INOUT","DATA_TYPE")
       VALUES ($1,$2,$3,$4,1,'ITEMAC','WH RTN','I','A'),
              ($1,$2,$3,$4,3,'CASH','WH RTN','I','A'),
              ($1,$2,$3,$4,4,'LBRAC','WH RTN','I','A'),
              ($1,$2,$3,$4,5,'KASAR','WH RTN','I','A'),
              ($1,$2,$3,$4,6,'OTHAC','WH RTN','I','A')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    for (const [code, name] of [
      ['PARTY', 'Return Party'],
      ['ITEMAC', 'Return Item Control'],
      ['LBRAC', 'Return Labour Control'],
      ['OTHAC', 'Return Other Control'],
      ['CASH', 'Cash Account'],
      ['KASAR', 'Kasar Account'],
      ['BANK', 'Bank Account'],
      ['CARD', 'Card Account'],
    ]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,$2,$3,$4,$5)`,
        TENANT,
        CO,
        LC,
        code,
        name,
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE",
         "RATE_TYPE","IT_TOUCH","IT_WEST","IT_LBR_RATE","IT_GHT_PRC")
       VALUES ($1,$2,'GOLD','Gold Ornament','G','01','P',90,10,0,0)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "DM_MAST"(tenant_id,"CO_CODE","DM_CODE","DM_NAME","DM_SHAPE","DM_COLOR")
       VALUES ($1,$2,'DIA','Diamond','ROUND','WHITE')`,
      TENANT,
      CO,
    );
    // Independent sequence seeds: main voucher 00004 versus hidden voucher 00007.
    await owner.$executeRawUnsafe(
      `INSERT INTO "RATE_CUT_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE")
       VALUES ($1,$2,$3,$4,$5,'00004',$6::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      BOOK,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
       VALUES ($1,$2,$3,$4,'00007','historic hidden seed')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    // Sold tagged source used by desktop's RATE_CUT_ISU lookup.
    await owner.$executeRawUnsafe(
      `INSERT INTO "RATE_CUT_ISU"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
         "OLD_SRNO","VCH_DATE","VCH_TIME","BOOK_NAME","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO",
         "TBL_CODE","DESIGN_NO","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT",
         "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","RATE_TYPE","ITM_RATE","LBR_TYPE","LBR_RATE","PR_CODE")
       VALUES ($1,$2,$3,$4,'WHS','00020',1,1,$5::date,$5::timestamp,'WH SALES','PARTY','GOLD',
         'TAG001',101,'001','TAG-DESIGN','S',1,5,0,5,90,10,5,'P',100,'P',10,'01')`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "IT_CODE","DM_CODE","DM_NAME","DM_ORIGIN","DM_COLOR","IT_PCS","IT_GWT","IT_RATE_TYPE",
         "IT_RATE","IT_AMT","IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT")
       VALUES ($1,$2,$3,$4,'WHS','00020',1,1,'DIA','DIA','Diamond','ROUND','WHITE',1,.25,'W',100,25,0,0,25)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
       VALUES ($1,$2,$3,$4,'WHS','00020',1,$5::date,'GOLD','TAG001',101,'-',1,5,5,5),
              ($1,$2,$3,$4,'OPN','00001',1,$5::date,'GOLD','N',0,'+',100,100,100,100)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
  };

  const digest = async (voucherNo: string, hiddenNo: string) => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT md5(coalesce(string_agg(t || ':' || j,E'\\n' ORDER BY t,j),'')) digest FROM (
       SELECT 'RATE_CUT_DATA' t,to_jsonb(x)::text j FROM "RATE_CUT_DATA" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'RATE_CUT_REC',to_jsonb(x)::text FROM "RATE_CUT_REC" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'SL_IDTL',to_jsonb(x)::text FROM "SL_IDTL" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'BAR_DATA',to_jsonb(x)::text FROM "BAR_DATA" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'BAR_DETL',to_jsonb(x)::text FROM "BAR_DETL" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'BAR_IDTL',to_jsonb(x)::text FROM "BAR_IDTL" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'MAIN_STOCK',to_jsonb(x)::text FROM "MAIN_STOCK" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'AC_DATA',to_jsonb(x)::text FROM "AC_DATA" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'ROJ_MEL_DATA',to_jsonb(x)::text FROM "ROJ_MEL_DATA" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       UNION ALL SELECT 'TEMP_BOOK_DATA',to_jsonb(x)::text FROM "TEMP_BOOK_DATA" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$4
       UNION ALL SELECT 'DELETE_DATA',to_jsonb(x)::text FROM "DELETE_DATA" x WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       ) s`,
      TENANT,
      BOOK,
      voucherNo,
      hiddenNo,
    )) as Array<{ digest: string }>;
    return rows[0]!.digest;
  };

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

  it('creates every desktop family, reads, safely replaces, locks, rejects resold tags and audits delete', async () => {
    const created = await saveWholesaleSaleReturn(runtime, input());
    expect(created).toEqual({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: true,
      lines: 2,
    });

    const counts = (await owner.$queryRawUnsafe(
      `SELECT
       (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') header,
       (SELECT count(*)::int FROM "RATE_CUT_REC" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
       (SELECT count(*)::int FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') idtl,
       (SELECT count(*)::int FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') bar_header,
       (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') bar_detail,
       (SELECT count(*)::int FROM "BAR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') bar_idtl,
       (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') stock,
       (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
       (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
       (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp,
       (SELECT "HD_VCH_NO" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') hidden,
       (SELECT "MAIN_USER" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
       (SELECT to_char("VCH_TIME",'HH24:MI:SS.MS') FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') clock,
       (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr,
       (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(counts[0]).toMatchObject({
      header: 1,
      detail: 2,
      idtl: 2,
      bar_header: 1,
      bar_detail: 1,
      bar_idtl: 1,
      stock: 2,
      temp: 1,
      hidden: '00008',
      main_user: 'return-user',
    });
    expect(Number(counts[0]!.ledger)).toBeGreaterThan(0);
    expect(Number(counts[0]!.rojmel)).toBeGreaterThan(0);
    expect(counts[0]!.dr).toBe(counts[0]!.cr);
    const tenderLedger = (await owner.$queryRawUnsafe(
      `SELECT right("LEDR_KEY",2) key,"AC_CODE","LD_CODE","CR_AMT"::float cr,"DR_AMT"::float dr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005'
          AND right("LEDR_KEY",2) IN ('15','16','17','18','19','20','21','22') ORDER BY key`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(tenderLedger).toEqual([
      { key: '15', AC_CODE: 'PARTY', LD_CODE: 'BANK', cr: 0, dr: 20 },
      { key: '16', AC_CODE: 'BANK', LD_CODE: 'PARTY', cr: 20, dr: 0 },
      { key: '17', AC_CODE: 'PARTY', LD_CODE: 'CARD', cr: 0, dr: 30 },
      { key: '18', AC_CODE: 'CARD', LD_CODE: 'PARTY', cr: 30, dr: 0 },
      { key: '19', AC_CODE: 'PARTY', LD_CODE: 'CASH', cr: 0, dr: 10 },
      { key: '20', AC_CODE: 'CASH', LD_CODE: 'PARTY', cr: 10, dr: 0 },
      { key: '21', AC_CODE: 'PARTY', LD_CODE: 'LBRAC', cr: 5, dr: 0 },
      { key: '22', AC_CODE: 'LBRAC', LD_CODE: 'PARTY', cr: 0, dr: 5 },
    ]);
    const rojmelTender = (await owner.$queryRawUnsafe(
      `SELECT right("LEDR_KEY",2) key,"AC_CODE","LD_CODE","CR_AMT"::float cr,"DR_AMT"::float dr
         FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005'
          AND right("LEDR_KEY",2) IN ('07','08','09','10') ORDER BY key`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(rojmelTender).toEqual([
      { key: '07', AC_CODE: 'BANK', LD_CODE: 'PARTY', cr: 20, dr: 0 },
      { key: '08', AC_CODE: 'CARD', LD_CODE: 'PARTY', cr: 30, dr: 0 },
      { key: '09', AC_CODE: 'KASAR', LD_CODE: 'PARTY', cr: 5, dr: 0 },
      { key: '10', AC_CODE: 'LBRAC', LD_CODE: 'PARTY', cr: 0, dr: 28 },
    ]);
    const clock = String(counts[0]!.clock);

    const stock = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::float sr,"TR_TYPE","ITM_SIGN","VCH_TYPE","BOOK_NAME","TAG_NO"
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005' ORDER BY "ISR_NO"`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(stock).toEqual([
      {
        sr: 2,
        TR_TYPE: 'I',
        ITM_SIGN: '+',
        VCH_TYPE: 'WRT',
        BOOK_NAME: 'WH RTN',
        TAG_NO: 'TAG001',
      },
      { sr: 1, TR_TYPE: 'I', ITM_SIGN: '+', VCH_TYPE: 'WRT', BOOK_NAME: 'WH RTN', TAG_NO: 'N' },
    ]);

    expect(await getWholesaleSaleReturn(runtime, scope, '00005')).toMatchObject({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      partyCode: 'PARTY',
      cashAmount: 10,
      chequeAmount: 20,
      cardAmount: 30,
      kasarAmount: 5,
      bankAccount: 'BANK',
      cardAccount: 'CARD',
      chequeNo: 'CHQ-101',
      lines: [
        { tagNo: 'TAG001', itemCode: 'GOLD' },
        { tagNo: '', itemCode: 'GOLD' },
      ],
    });

    const edited = await saveWholesaleSaleReturn(
      runtime,
      input(NEXT_DAY, 'Edited', 'ignored'),
      '00005',
    );
    expect(edited).toEqual({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: false,
      lines: 2,
    });
    const editState = (await owner.$queryRawUnsafe(
      `SELECT
       (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') deleted,
       (SELECT "MAIN_USER" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
       (SELECT to_char("VCH_TIME",'HH24:MI:SS.MS') FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') clock,
       (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr,
       (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(editState[0]).toMatchObject({ deleted: 0, main_user: 'return-user', clock });
    expect(editState[0]!.dr).toBe(editState[0]!.cr);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      NEXT_DAY,
      TENANT,
      CO,
    );
    const beforeLocked = await digest('00005', '00008');
    await expect(
      saveWholesaleSaleReturn(runtime, input('2024-04-12'), '00005'),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await digest('00005', '00008')).toBe(beforeLocked);
    await expect(deleteWholesaleSaleReturn(runtime, scope, '00005')).rejects.toBeInstanceOf(
      PeriodLockValidationError,
    );
    expect(await digest('00005', '00008')).toBe(beforeLocked);
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );

    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN")
       VALUES ($1,$2,$3,$4,'RES','90001',1,'2024-04-12','GOLD','TAG001',101,'-')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    const beforeResold = await digest('00005', '00008');
    await expect(
      saveWholesaleSaleReturn(runtime, input(NEXT_DAY, 'Unsafe edit'), '00005'),
    ).rejects.toBeInstanceOf(WholesaleSaleReturnValidationError);
    expect(await digest('00005', '00008')).toBe(beforeResold);
    await owner.$executeRawUnsafe(
      `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='RES' AND "VCH_NO"='90001'`,
      TENANT,
    );

    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
       VALUES ($1,$2,$3,$4,'USE','90002',1,'2024-04-12','GOLD','N','-',105,105,105,105)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    const beforeConsumed = await digest('00005', '00008');
    await expect(deleteWholesaleSaleReturn(runtime, scope, '00005')).rejects.toBeInstanceOf(
      WholesaleSaleReturnValidationError,
    );
    expect(await digest('00005', '00008')).toBe(beforeConsumed);
    await owner.$executeRawUnsafe(
      `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='USE' AND "VCH_NO"='90002'`,
      TENANT,
    );

    await expect(
      deleteWholesaleSaleReturn(runtime, scope, '00005', 'return-deleter'),
    ).resolves.toEqual({
      reversed: true,
      auditedRows: 1,
    });
    const deleted = (await owner.$queryRawUnsafe(
      `SELECT "VCH_TYPE","BOOK_NAME","AC_CODE","AC_NAME","VCH_VAL_DR"::float value_dr,
        "VCH_VAL_CR"::float value_cr,"FINE_TYPE","VCH_FINE_DR"::float fine_dr,
        "VCH_FINE_CR"::float fine_cr,"HD_VCH_NO","MAIN_USER","DELETE_USER","VCH_DESC",
       (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') header,
       (SELECT count(*)::int FROM "RATE_CUT_REC" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
       (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') bar_detail,
       (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') stock,
       (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp
       FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005'`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(deleted).toHaveLength(1);
    expect(deleted[0]).toMatchObject({
      VCH_TYPE: 'WRT',
      BOOK_NAME: 'Configured Wholesale',
      AC_CODE: 'PARTY',
      AC_NAME: 'Return Party',
      value_cr: 0,
      FINE_TYPE: 'G',
      fine_cr: 0,
      HD_VCH_NO: '00008',
      MAIN_USER: 'return-user',
      DELETE_USER: 'return-deleter',
      VCH_DESC: 'Edited',
      header: 0,
      detail: 0,
      bar_detail: 0,
      stock: 0,
      temp: 0,
    });
  }, 30_000);

  it.each(['G', 'T', 'K'] as const)(
    'writes RATE_CUT_DATA.RATE_PAR = %s from the company setting, not a constant',
    async (basis) => {
      // This module inserts into RATE_CUT_DATA — the SAME table rateCut.ts writes. Before the fix the two
      // paths disagreed: rate cut derived RATE_PAR from the setting while this one hardcoded 'G', so the same
      // table carried inconsistent rate bases depending on which form created the voucher.
      //
      // TR_WH_SALE_RTN.cs:6604-6612 sets CurRatePar from MsRatePar and :6787 reads it back on reopen, so a
      // constant mislabels every voucher at a shop quoting per-10-gram or per-kilogram rates.
      await owner.$executeRawUnsafe(
        `UPDATE "CO_SET" SET "RATE_PAR"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
        basis,
        TENANT,
        CO,
      );
      const created = await saveWholesaleSaleReturn(runtime, input());
      const rows = (await owner.$queryRawUnsafe(
        `SELECT "RATE_PAR" FROM "RATE_CUT_DATA"
          WHERE tenant_id=$1 AND "VCH_NO"=$2 LIMIT 1`,
        TENANT,
        created.voucherNo,
      )) as { RATE_PAR: string }[];
      expect(rows[0]?.RATE_PAR).toBe(basis);

      // The settlement columns stay zero: TR_WH_SALE_RTN writes them as literal zeros and derives no
      // money/metal settlement, unlike its sibling rate-cut form.
      const settle = (await owner.$queryRawUnsafe(
        // CONV_RATE and CONV_PRC are VARCHAR on this table while DR_AMT/CR_AMT/DR_FINE/CR_FINE are numeric,
        // so they cannot share a coalesce and are normalised as text instead.
        `SELECT coalesce("DR_AMT",0)::float da, coalesce("CR_AMT",0)::float ca,
                coalesce("DR_FINE",0)::float df, coalesce("CR_FINE",0)::float cf,
                coalesce(NULLIF("CONV_RATE",'')::numeric,0)::float cr,
                coalesce(NULLIF("CONV_PRC",'')::numeric,0)::float cp
           FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 LIMIT 1`,
        TENANT,
        created.voucherNo,
      )) as Record<string, number>[];
      expect(Object.values(settle[0]!)).toEqual([0, 0, 0, 0, 0, 0]);
    },
  );
});
