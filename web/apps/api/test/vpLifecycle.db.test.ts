import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteVpAdjustment,
  getVpAdjustment,
  saveVpAdjustment,
} from '../src/modules/finance/vpAdjustment.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'vp-lifecycle-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const NEXT_DAY = '2024-04-11';
const VP_REC_BOOK = 'VRA';
const VP_SOURCE_BOOK = 'VPI';
const VP_SOURCE_NO = '00012';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: VP_REC_BOOK,
};

const input = (receiptAmount: number, kasarAmount: number, description: string) => ({
  scope,
  vchDate: DAY,
  mainUser: 'vp-user',
  lines: [
    {
      vpYear: YEAR,
      vpBook: VP_SOURCE_BOOK,
      vpNo: VP_SOURCE_NO,
      receiptAmount,
      kasarAmount,
      description,
    },
  ],
});

databaseDescribe('database-backed VP adjustment lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    for (const table of [
      'DELETE_DATA',
      'ROJ_MEL_DATA',
      'AC_DATA',
      'VP_ADJ_DATA',
      'TEMP_BOOK_DATA',
      'RATE_CUT_DATA',
      'AC_MAST',
      'BOOK_DETL',
      'BOOK_DATA',
      'YEAR_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async () => {
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
       VALUES
         ($1,$2,$3,$4,'VP Receipt','VPR','VP REC','I','Y','VP_ADJ_DATA','A'),
         ($1,$2,$3,$5,'VP Parcel Issue','VPI','VP PARCEL','O','Y','RATE_CUT_DATA','A')`,
      TENANT,
      CO,
      LC,
      VP_REC_BOOK,
      VP_SOURCE_BOOK,
    );
    for (const [code, name] of [
      ['00010', 'VP Party'],
      ['00020', 'VP Angdiya'],
      ['00030', 'VP Receipt Control'],
      ['00040', 'VP Kasar Control'],
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
      `INSERT INTO "BOOK_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT","DATA_TYPE")
       VALUES
         ($1,$2,$3,$4,1,'00030','VP REC','I','A'),
         ($1,$2,$3,$4,2,'00040','VP REC','I','A')`,
      TENANT,
      CO,
      LC,
      VP_REC_BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "RATE_CUT_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME",
         "HD_VCH_NO","IT_TYPE","AC_CODE","AC_NAME","SL_FINE","SL_ITM_AMT","VP_AMT",
         "VP_ADJ_AMT","AC_ANGDIYA","MAIN_USER")
       VALUES ($1,$2,$3,$4,$5,$6,$7::date,$7::date + time '09:08:07','00022','G',
               '00010','VP Party','2.5','0','500','20','00020','source-user')`,
      TENANT,
      CO,
      LC,
      YEAR,
      VP_SOURCE_BOOK,
      VP_SOURCE_NO,
      DAY,
    );
    // Independent numbering: detail max 00004 while hidden TEMP max is 00007.
    await owner.$executeRawUnsafe(
      `INSERT INTO "VP_ADJ_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE")
       VALUES ($1,$2,$3,$4,$5,'00004',1,$6::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      VP_REC_BOOK,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
       VALUES ($1,$2,$3,$4,'00007','prior VP receipt')`,
      TENANT,
      CO,
      LC,
      VP_REC_BOOK,
    );
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

  it('creates, reads, replaces, locks and desktop-deletes VP adjustment atomically', async () => {
    const created = await saveVpAdjustment(runtime, input(100, 10, 'Initial VP adjustment'));
    expect(created).toEqual({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: true,
      lines: 1,
    });

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp,
        (SELECT min("BOOK_NAME") FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp_name,
        (SELECT min("HD_VCH_NO") FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') hidden,
        (SELECT min("MAIN_USER") FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT min("VCH_TIME")::text FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_time,
        (SELECT "VP_ADJ_AMT" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) source_adj,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005' AND "IT_TYPE"='G' AND "FINE_WT"=2.5) metal_leg`,
      TENANT,
      VP_REC_BOOK,
      VP_SOURCE_BOOK,
      VP_SOURCE_NO,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      detail: 1,
      ledger: 7,
      rojmel: 3,
      temp: 1,
      temp_name: 'VP Receipt',
      hidden: '00008',
      main_user: 'vp-user',
      // VP_ADJ_AMT is double precision after the column-type correction, so this comes back as a number.
      source_adj: 130,
      cr: 210,
      dr: 210,
      metal_leg: 1,
    });
    const originalTime = String(persisted[0]!.vch_time);

    expect(await getVpAdjustment(runtime, scope, created.voucherNo)).toMatchObject({
      voucherNo: '00005',
      vchDate: DAY,
      hiddenVoucherNo: '00008',
      mainUser: 'vp-user',
      lines: [
        {
          vpYear: YEAR,
          vpBook: VP_SOURCE_BOOK,
          vpNo: VP_SOURCE_NO,
          partyCode: '00010',
          partyName: 'VP Party',
          angdiyaCode: '00020',
          angdiyaName: 'VP Angdiya',
          receiptAmount: 100,
          kasarAmount: 10,
        },
      ],
    });

    const edited = await saveVpAdjustment(
      runtime,
      {
        ...input(50, 5, 'Replacement VP adjustment'),
        vchDate: NEXT_DAY,
        mainUser: 'ignored-user',
      },
      created.voucherNo,
    );
    expect(edited).toMatchObject({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: false,
    });
    const afterEdit = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') deleted,
        (SELECT min("MAIN_USER") FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT min("VCH_TIME")::text FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_time,
        (SELECT "VP_ADJ_AMT" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) source_adj,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr`,
      TENANT,
      VP_REC_BOOK,
      VP_SOURCE_BOOK,
      VP_SOURCE_NO,
    )) as Array<Record<string, unknown>>;
    expect(afterEdit[0]).toMatchObject({
      detail: 1,
      ledger: 7,
      rojmel: 3,
      deleted: 0,
      main_user: 'vp-user',
      source_adj: 75,
      cr: 105,
      dr: 105,
    });
    expect(String(afterEdit[0]!.vch_time).slice(11)).toBe(originalTime.slice(11));

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      NEXT_DAY,
      TENANT,
      CO,
    );
    const beforeRejected = JSON.stringify(afterEdit[0]);
    await expect(
      saveVpAdjustment(
        runtime,
        { ...input(25, 0, 'Rejected edit'), vchDate: '2024-04-12' },
        created.voucherNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    await expect(deleteVpAdjustment(runtime, scope, created.voucherNo)).rejects.toBeInstanceOf(
      PeriodLockValidationError,
    );
    const lockedState = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') deleted,
        (SELECT min("MAIN_USER") FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT min("VCH_TIME")::text FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_time,
        (SELECT "VP_ADJ_AMT" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) source_adj,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr`,
      TENANT,
      VP_REC_BOOK,
      VP_SOURCE_BOOK,
      VP_SOURCE_NO,
    )) as Array<Record<string, unknown>>;
    expect(JSON.stringify(lockedState[0])).toBe(beforeRejected);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(
      deleteVpAdjustment(runtime, scope, created.voucherNo, 'vp-deleter'),
    ).resolves.toEqual({ reversed: true, auditedLines: 1 });

    const deleted = (await owner.$queryRawUnsafe(
      `SELECT d."VCH_TYPE",d."BOOK_NAME",d."AC_CODE",d."AC_NAME",
              d."VCH_VAL_DR",d."VCH_VAL_CR",d."FINE_TYPE",
              d."VCH_FINE_DR"::float,d."VCH_FINE_CR"::float,d."VCH_DESC",
              d."HD_VCH_NO",d."MAIN_USER",d."DELETE_USER",
        (SELECT count(*)::int FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp,
        (SELECT "VP_ADJ_AMT" FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$3 AND "VCH_NO"=$4) source_adj
       FROM "DELETE_DATA" d WHERE d.tenant_id=$1 AND d."CO_BOOK"=$2 AND d."VCH_NO"='00005'`,
      TENANT,
      VP_REC_BOOK,
      VP_SOURCE_BOOK,
      VP_SOURCE_NO,
    )) as Array<Record<string, unknown>>;
    expect(deleted).toHaveLength(1);
    expect(deleted[0]).toMatchObject({
      VCH_TYPE: 'VPR',
      BOOK_NAME: 'VP Receipt',
      AC_CODE: '00010',
      AC_NAME: 'VP Party',
      VCH_VAL_DR: 0,
      VCH_VAL_CR: 50,
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      VCH_DESC: 'Replacement VP adjustment',
      HD_VCH_NO: '00008',
      MAIN_USER: 'vp-user',
      DELETE_USER: 'vp-deleter',
      detail: 0,
      ledger: 0,
      rojmel: 0,
      temp: 0,
      source_adj: 20,
    });
  }, 30_000);
});
