import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteVpParcel,
  getVpParcel,
  saveVpParcel,
  VpParcelValidationError,
} from '../src/modules/sales/vpParcel.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'vp-parcel-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const NEXT_DAY = '2024-04-11';
const BOOK = 'VPI';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

const initialInput = (description: string, mainUser = 'vp-parcel-user') => ({
  scope,
  vchDate: DAY,
  partyCode: 'PARTY',
  angdiyaCode: 'ANGDIYA',
  billNo: 'VP-BILL-1',
  description,
  mainUser,
  lines: [
    {
      itemCode: 'GOLD',
      tableCode: '001',
      designNo: 'INITIAL-DESIGN',
      size: 'M',
      remark: 'Initial loose parcel',
      pcs: 2,
      grossWt: 10,
      otherWt: 1,
      ghatPct: 0,
      touch: 90,
      westPct: 10,
      rateType: 'P',
      rate: 100,
      labourType: 'P',
      labourRate: 10,
      otherAmount: 5,
      components: [
        { dmCode: 'DIA', pcs: 1, weight: 0.5, rateType: 'W', rate: 1000, labourRate: 2 },
      ],
    },
  ],
});

const replacementInput = (description = 'Replacement VP parcel') => ({
  scope,
  vchDate: NEXT_DAY,
  partyCode: 'PARTY',
  angdiyaCode: 'ANGDIYA',
  billNo: 'VP-BILL-EDIT',
  description,
  mainUser: 'ignored-editor',
  lines: [
    {
      itemCode: 'GOLD',
      tableCode: '002',
      designNo: 'EDIT-DESIGN-1',
      size: 'L',
      remark: 'Replacement line one',
      pcs: 3,
      grossWt: 12,
      otherWt: 2,
      ghatPct: 0,
      touch: 90,
      westPct: 10,
      rateType: 'P',
      rate: 120,
      labourType: 'P',
      labourRate: 12,
      otherAmount: 4,
      components: [
        { dmCode: 'DIA', pcs: 2, weight: 0.7, rateType: 'W', rate: 1100, labourRate: 3 },
      ],
    },
    {
      itemCode: 'GOLD',
      tableCode: '003',
      designNo: 'EDIT-DESIGN-2',
      size: 'S',
      remark: 'Replacement line two',
      pcs: 1,
      grossWt: 8,
      otherWt: 0,
      ghatPct: 0,
      touch: 90,
      westPct: 10,
      rateType: 'P',
      rate: 150,
      labourType: 'G',
      labourRate: 5,
      otherAmount: 10,
      components: [
        { dmCode: 'DIA', pcs: 1, weight: 0.3, rateType: 'W', rate: 1200, labourRate: 4 },
      ],
    },
  ],
});

databaseDescribe('database-backed VP parcel lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'ROJ_MEL_DATA',
      'AC_DATA',
      'DM_DATA',
      'SL_IDTL',
      'SL_PR_DETL',
      'RATE_CUT_ISU_REC',
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
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","EMP_CODE_MANDATORY")
       VALUES ($1,$2,NULL,'N')`,
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
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'Configured VP Parcel','VPI','VP PARCEL','O','Y','RATE_CUT_DATA','A')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT","DATA_TYPE")
       VALUES ($1,$2,$3,$4,1,'ITEMAC','VP PARCEL','O','A'),
              ($1,$2,$3,$4,6,'LBRAC','VP PARCEL','O','A')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    for (const [code, name] of [
      ['PARTY', 'Parcel Party'],
      ['ANGDIYA', 'Parcel Angdiya'],
      ['ITEMAC', 'Gold Sale Control'],
      ['LBRAC', 'Labour Control'],
    ]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
         VALUES ($1,$2,$3,$4,$5)`,
        TENANT,
        CO,
        LC,
        code,
        name,
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(
         tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE",
         "LBR_PRC","IT_TOUCH","IT_WEST","IT_LBR_RATE","IT_GHT_PRC","OTH_DETL_POSTING")
       VALUES ($1,$2,'GOLD','Gold Ornament','G','01','P',0,90,10,0,0,'Y')`,
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
      `INSERT INTO "RATE_CUT_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE")
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
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
       VALUES ($1,$2,$3,$4,'OPN','00001',1,$5::date,'GOLD','N','+',100,100,100,100)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
  };

  const stateDigest = async (voucherNo: string, hiddenVoucherNo: string): Promise<string> => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT md5(coalesce(string_agg(table_name || ':' || row_json, E'\\n'
                                      ORDER BY table_name,row_json),'')) AS digest
       FROM (
         SELECT 'AC_DATA' table_name,to_jsonb(t)::text row_json FROM "AC_DATA" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'DM_DATA',to_jsonb(t)::text FROM "DM_DATA" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'MAIN_STOCK',to_jsonb(t)::text FROM "MAIN_STOCK" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'RATE_CUT_DATA',to_jsonb(t)::text FROM "RATE_CUT_DATA" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'RATE_CUT_ISU',to_jsonb(t)::text FROM "RATE_CUT_ISU" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'RATE_CUT_ISU_REC',to_jsonb(t)::text FROM "RATE_CUT_ISU_REC" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'SL_IDTL',to_jsonb(t)::text FROM "SL_IDTL" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'SL_PR_DETL',to_jsonb(t)::text FROM "SL_PR_DETL" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'ROJ_MEL_DATA',to_jsonb(t)::text FROM "ROJ_MEL_DATA" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
         UNION ALL SELECT 'TEMP_BOOK_DATA',to_jsonb(t)::text FROM "TEMP_BOOK_DATA" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$4
         UNION ALL SELECT 'DELETE_DATA',to_jsonb(t)::text FROM "DELETE_DATA" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
       ) state_rows`,
      TENANT,
      BOOK,
      voucherNo,
      hiddenVoucherNo,
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

  it('creates, reads, replaces, guards, locks and desktop-deletes a VP parcel atomically', async () => {
    const created = await saveVpParcel(runtime, initialInput('Initial VP parcel'));
    expect(created).toEqual({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: true,
      lines: 1,
    });

    const persisted = (await owner.$queryRawUnsafe(
      `WITH h AS (
         SELECT "HD_VCH_NO" hidden,"MAIN_USER" main_user,"VCH_DATE"::text vch_day,
                to_char("VCH_TIME",'HH24:MI:SS.MS') clock
           FROM "RATE_CUT_DATA"
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005'
       ) SELECT
        (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') header,
        (SELECT count(*)::int FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') issue,
        (SELECT count(*)::int FROM "RATE_CUT_ISU_REC" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') issue_rec,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') stock,
        (SELECT count(*)::int FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dm,
        (SELECT count(*)::int FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sale_component,
        (SELECT count(*)::int FROM "SL_PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sale_projection,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp,
        (SELECT count(*)::int FROM "RATE_CUT_ISU" r,h WHERE r.tenant_id=$1 AND r."CO_BOOK"=$2 AND r."VCH_NO"='00005'
          AND (r."HD_VCH_NO" IS DISTINCT FROM h.hidden OR r."MAIN_USER" IS DISTINCT FROM h.main_user
               OR to_char(r."VCH_TIME",'HH24:MI:SS.MS') IS DISTINCT FROM h.clock)) issue_identity_errors,
        (SELECT count(*)::int FROM "AC_DATA" r,h WHERE r.tenant_id=$1 AND r."CO_BOOK"=$2 AND r."VCH_NO"='00005'
          AND (r."HD_VCH_NO" IS DISTINCT FROM h.hidden OR r."MAIN_USER" IS DISTINCT FROM h.main_user
               OR r."ENTRY_TIME"::date::text IS DISTINCT FROM h.vch_day
               OR to_char(r."ENTRY_TIME",'HH24:MI:SS.MS') IS DISTINCT FROM h.clock)) ledger_identity_errors,
        (SELECT count(*)::int FROM "MAIN_STOCK" r,h WHERE r.tenant_id=$1 AND r."CO_BOOK"=$2 AND r."VCH_NO"='00005'
          AND (r."MAIN_USER" IS DISTINCT FROM h.main_user
               OR r."ENTRY_TIME"::text IS DISTINCT FROM h.vch_day)) stock_identity_errors,
        (SELECT count(*)::int FROM "SL_PR_DETL" r,h WHERE r.tenant_id=$1 AND r."CO_BOOK"=$2 AND r."VCH_NO"='00005'
          AND (r."HD_VCH_NO" IS DISTINCT FROM h.hidden OR r."MAIN_USER" IS DISTINCT FROM h.main_user
               OR to_char(r."VCH_TIME",'HH24:MI:SS.MS') IS DISTINCT FROM h.clock)) projection_identity_errors,
        h.hidden,h.main_user,h.clock
       FROM h`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      header: 1,
      issue: 1,
      issue_rec: 1,
      ledger: 5,
      stock: 1,
      dm: 1,
      sale_component: 1,
      sale_projection: 1,
      rojmel: 4,
      temp: 1,
      issue_identity_errors: 0,
      ledger_identity_errors: 0,
      stock_identity_errors: 0,
      projection_identity_errors: 0,
      hidden: '00008',
      main_user: 'vp-parcel-user',
    });
    const originalClock = String(persisted[0]!.clock);
    expect(originalClock).toMatch(/^\d{2}:\d{2}:\d{2}\.\d{3}$/);

    const stockRows = (await owner.$queryRawUnsafe(
      `SELECT "TR_TYPE","ITM_SIGN","VCH_TYPE","BOOK_NAME","ITM_PCS"::float pcs,
              "ITM_GWT"::float gwt,"ITM_NWT"::float nwt,"ITM_FINE"::float fine
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005'`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(stockRows).toEqual([
      {
        TR_TYPE: 'S',
        ITM_SIGN: '-',
        VCH_TYPE: 'VPI',
        BOOK_NAME: 'VP PARCEL',
        pcs: 2,
        gwt: 10,
        nwt: 9,
        fine: 9,
      },
    ]);

    expect(await getVpParcel(runtime, scope, created.voucherNo)).toMatchObject({
      voucherNo: '00005',
      vchDate: DAY,
      hiddenVoucherNo: '00008',
      mainUser: 'vp-parcel-user',
      partyCode: 'PARTY',
      partyName: 'Parcel Party',
      angdiyaCode: 'ANGDIYA',
      billNo: 'VP-BILL-1',
      description: 'Initial VP parcel',
      lines: [
        {
          srNo: 1,
          tagNo: 'N',
          itemCode: 'GOLD',
          itemName: 'Gold Ornament',
          remark: 'Initial loose parcel',
          pcs: 2,
          grossWt: 10,
          netWt: 9,
          fineWt: 9,
          netAmount: 225,
        },
      ],
    });

    const second = await saveVpParcel(runtime, initialInput('Second VP parcel', 'second-user'));
    expect(second).toEqual({
      voucherNo: '00006',
      hiddenVoucherNo: '00009',
      created: true,
      lines: 1,
    });
    const identities = (await owner.$queryRawUnsafe(
      `SELECT "VCH_NO","HD_VCH_NO","MAIN_USER" FROM "RATE_CUT_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO" IN ('00005','00006') ORDER BY "VCH_NO"`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(identities).toEqual([
      { VCH_NO: '00005', HD_VCH_NO: '00008', MAIN_USER: 'vp-parcel-user' },
      { VCH_NO: '00006', HD_VCH_NO: '00009', MAIN_USER: 'second-user' },
    ]);

    const edited = await saveVpParcel(runtime, replacementInput(), created.voucherNo);
    expect(edited).toEqual({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: false,
      lines: 2,
    });
    const afterEdit = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') header,
        (SELECT count(*)::int FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') issue,
        (SELECT count(*)::int FROM "RATE_CUT_ISU_REC" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') issue_rec,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') stock,
        (SELECT count(*)::int FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dm,
        (SELECT count(*)::int FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sale_component,
        (SELECT count(*)::int FROM "SL_PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sale_projection,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') deleted,
        (SELECT count(*)::int FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005'
          AND "ITM_REMARK"='Initial loose parcel') stale_lines,
        (SELECT "HD_VCH_NO" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') hidden,
        (SELECT "MAIN_USER" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT "VCH_DATE"::text FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') voucher_day,
        (SELECT to_char("VCH_TIME",'HH24:MI:SS.MS') FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') clock,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(afterEdit[0]).toMatchObject({
      header: 1,
      issue: 2,
      issue_rec: 2,
      ledger: 5,
      stock: 2,
      dm: 2,
      sale_component: 2,
      sale_projection: 2,
      rojmel: 5,
      deleted: 0,
      stale_lines: 0,
      hidden: '00008',
      main_user: 'vp-parcel-user',
      voucher_day: NEXT_DAY,
      clock: originalClock,
      dr: 600,
      cr: 600,
    });

    // A downstream loose-stock issue makes replacement unsafe. The module must reject before
    // deleting any existing rows, rather than stranding a negative stock balance.
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
       VALUES ($1,$2,$3,$4,'OTH','90001',1,'2024-04-12'::date,'GOLD','N','-',95,85,80,80)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    const beforeMovedMetalRejection = await stateDigest('00005', '00008');
    await expect(
      saveVpParcel(runtime, replacementInput('Unsafe moved-metal replacement'), created.voucherNo),
    ).rejects.toBeInstanceOf(VpParcelValidationError);
    expect(await stateDigest('00005', '00008')).toBe(beforeMovedMetalRejection);
    await owner.$executeRawUnsafe(
      `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='OTH' AND "VCH_NO"='90001'`,
      TENANT,
    );

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      NEXT_DAY,
      TENANT,
      CO,
    );
    const beforeLockedEdit = await stateDigest('00005', '00008');
    await expect(
      saveVpParcel(
        runtime,
        { ...replacementInput('Locked edit'), vchDate: '2024-04-12' },
        created.voucherNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await stateDigest('00005', '00008')).toBe(beforeLockedEdit);

    const beforeLockedDelete = await stateDigest('00005', '00008');
    await expect(deleteVpParcel(runtime, scope, created.voucherNo)).rejects.toBeInstanceOf(
      PeriodLockValidationError,
    );
    expect(await stateDigest('00005', '00008')).toBe(beforeLockedDelete);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(deleteVpParcel(runtime, scope, created.voucherNo, 'vp-deleter')).resolves.toEqual({
      reversed: true,
      auditedRows: 1,
    });

    // Desktop authority: unified/src/csharp/DataCareNext/TR_VP.cs:5877 has the single
    // INSERT INTO DELETE_DATA ... SELECT header/book/account mapping used by this assertion.
    const deleted = (await owner.$queryRawUnsafe(
      `SELECT d."VCH_DATE"::text voucher_day,to_char(d."VCH_TIME",'HH24:MI:SS.MS') clock,
              d."VCH_TYPE",d."BOOK_NAME",d."AC_CODE",d."AC_NAME",d."VCH_VAL_DR",
              d."VCH_VAL_CR",d."FINE_TYPE",d."VCH_FINE_DR"::float,d."VCH_FINE_CR"::float,
              d."HD_VCH_NO",d."MAIN_USER",d."DELETE_USER",d."VCH_DESC",
        (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') header,
        (SELECT count(*)::int FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') issue,
        (SELECT count(*)::int FROM "RATE_CUT_ISU_REC" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') issue_rec,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') stock,
        (SELECT count(*)::int FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dm,
        (SELECT count(*)::int FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sale_component,
        (SELECT count(*)::int FROM "SL_PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sale_projection,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp
       FROM "DELETE_DATA" d WHERE d.tenant_id=$1 AND d."CO_BOOK"=$2 AND d."VCH_NO"='00005'`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(deleted).toHaveLength(1);
    expect(deleted[0]).toMatchObject({
      voucher_day: NEXT_DAY,
      clock: originalClock,
      VCH_TYPE: 'VPI',
      BOOK_NAME: 'Configured VP Parcel',
      AC_CODE: 'PARTY',
      AC_NAME: 'Parcel Party',
      VCH_VAL_DR: 0,
      VCH_VAL_CR: 0,
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      HD_VCH_NO: '00008',
      MAIN_USER: 'vp-parcel-user',
      DELETE_USER: 'vp-deleter',
      VCH_DESC: '0',
      header: 0,
      issue: 0,
      issue_rec: 0,
      ledger: 0,
      stock: 0,
      dm: 0,
      sale_component: 0,
      sale_projection: 0,
      rojmel: 0,
      temp: 0,
    });
  }, 30_000);
});
