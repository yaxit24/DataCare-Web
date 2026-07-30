import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { deleteGoldBook, getGoldBook, saveGoldBook } from '../src/modules/finance/goldBook.js';
import {
  deleteLocationAmount,
  getLocationAmount,
  saveLocationAmount,
} from '../src/modules/finance/locationAmount.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'gold-loct-db';
const CO = '01';
const LC = '01';
const DEST_LC = '02';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const NEXT_DAY = '2024-04-11';
const GOLD_BOOK = 'DGB';
const AMOUNT_BOOK = 'AOT';
const goldScope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: GOLD_BOOK,
};
const amountScope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: AMOUNT_BOOK,
};

databaseDescribe('database-backed digital-gold and location-amount vouchers', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    for (const table of [
      'DELETE_DATA',
      'REMARK_DATA',
      'ROJ_MEL_DATA',
      'AC_DATA',
      'DG_GOLD_DATA',
      'LOCT_AMT',
      'TEMP_BOOK_DATA',
      'TAX_MAST',
      'EMP_MAST',
      'LOCT_MAST',
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
         ($1,$2,$3,$4,'Digital Gold Book','DGGLD','DG GOLD','O','Y','DG_GOLD_DATA','A'),
         ($1,$2,$3,$5,'Amount Out','AMTO','AMT OUT','O','Y','LOCT_AMT','A'),
         ($1,$2,$6,'159','Amount In','AMTIN','AMT IN','I','Y','LOCT_AMT','A')`,
      TENANT,
      CO,
      LC,
      GOLD_BOOK,
      AMOUNT_BOOK,
      DEST_LC,
    );
    for (const [code, name, mobile] of [
      ['00003', 'Digital Gold Control', ''],
      ['00010', 'Voucher Party', '9999999999'],
      ['00020', 'Digital Gold Ledger', ''],
      ['00031', 'Main Branch Account', ''],
      ['00032', 'Destination Branch Account', ''],
      ['00040', 'Output Tax', ''],
    ]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MOBILE")
         VALUES ($1,$2,$3,$4,$5,$6)`,
        TENANT,
        CO,
        LC,
        code,
        name,
        mobile,
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'Main Branch','00031','Main Branch Account'),
              ($1,$2,$4,'Destination Branch','00032','Destination Branch Account')`,
      TENANT,
      CO,
      LC,
      DEST_LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'T1',0,'GST 10',10,'00040')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME")
       VALUES ($1,$2,'E01','Employee One')`,
      TENANT,
      CO,
    );
    // Independent MAX+1 evidence: main identities start at different values than TEMP identities.
    await owner.$executeRawUnsafe(
      `INSERT INTO "DG_GOLD_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE")
       VALUES ($1,$2,$3,$4,$5,'00004',1,$6::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      GOLD_BOOK,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_AMT"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE")
       VALUES ($1,$2,$3,$4,$5,'00003',1,$6::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      AMOUNT_BOOK,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
       VALUES ($1,$2,$3,$4,'00007','prior gold'),($1,$2,$3,$5,'00006','prior amount')`,
      TENANT,
      CO,
      LC,
      GOLD_BOOK,
      AMOUNT_BOOK,
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

  it('creates, reads, edits, locks and desktop-deletes digital gold atomically', async () => {
    const created = await saveGoldBook(runtime, {
      scope: goldScope,
      vchDate: DAY,
      employeeCode: 'E01',
      remark: 'Gold booking remark',
      mainUser: 'gold-user',
      lines: [
        {
          acCode: '00010',
          amount: 100,
          rate: 6500,
          fine: 1.25,
          ledgerAccount: '00020',
          taxCode: 'T1',
          description: 'First gold booking',
        },
      ],
    });
    expect(created).toEqual({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: true,
      lines: 1,
    });
    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') remark,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp,
        (SELECT min("HD_VCH_NO") FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') hidden,
        (SELECT min("MAIN_USER") FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT min("VCH_TIME")::text FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_time`,
      TENANT,
      GOLD_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      detail: 1,
      ledger: 5,
      rojmel: 2,
      remark: 1,
      temp: 1,
      hidden: '00008',
      main_user: 'gold-user',
    });
    const originalTime = String(persisted[0]!.vch_time);
    expect(await getGoldBook(runtime, goldScope, '00005')).toMatchObject({
      voucherNo: '00005',
      vchDate: DAY,
      hiddenVoucherNo: '00008',
      mainUser: 'gold-user',
      remark: 'Gold booking remark',
      lines: [
        {
          acCode: '00010',
          acName: 'Voucher Party',
          mobile: '9999999999',
          taxPercent: 10,
          taxAmount: 10,
          total: 110,
        },
      ],
    });

    const edited = await saveGoldBook(
      runtime,
      {
        scope: goldScope,
        vchDate: NEXT_DAY,
        employeeCode: 'E01',
        remark: 'Edited gold booking',
        mainUser: 'ignored-user',
        lines: [
          {
            acCode: '00010',
            amount: 200,
            rate: 6600,
            fine: 2,
            ledgerAccount: '00020',
            description: 'Replacement line',
          },
        ],
      },
      created.voucherNo,
    );
    expect(edited).toMatchObject({ created: false, voucherNo: '00005', hiddenVoucherNo: '00008' });
    const afterEdit = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') deleted,
        (SELECT min("MAIN_USER") FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT min("VCH_TIME")::text FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_time,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr`,
      TENANT,
      GOLD_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(afterEdit[0]).toMatchObject({
      detail: 1,
      ledger: 4,
      deleted: 0,
      main_user: 'gold-user',
      cr: 400,
      dr: 400,
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
      saveGoldBook(
        runtime,
        {
          scope: goldScope,
          vchDate: '2024-04-12',
          lines: [
            {
              acCode: '00010',
              amount: 300,
              rate: 1,
              fine: 1,
              ledgerAccount: '00020',
            },
          ],
        },
        created.voucherNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    await expect(deleteGoldBook(runtime, goldScope, created.voucherNo)).rejects.toBeInstanceOf(
      PeriodLockValidationError,
    );
    const lockedState = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int detail,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') deleted,
        min("MAIN_USER") main_user,
        min("VCH_TIME")::text vch_time,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr
       FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005'`,
      TENANT,
      GOLD_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(JSON.stringify(lockedState[0])).toBe(beforeRejected);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(deleteGoldBook(runtime, goldScope, created.voucherNo, 'deleter')).resolves.toEqual(
      {
        reversed: true,
      },
    );
    const deleted = (await owner.$queryRawUnsafe(
      `SELECT d."VCH_TYPE",d."BOOK_NAME",d."AC_CODE",d."AC_NAME",d."VCH_VAL_DR",d."VCH_VAL_CR",
              d."FINE_TYPE",d."VCH_FINE_DR"::float,d."VCH_FINE_CR"::float,d."VCH_DESC",d."DELETE_USER",
        (SELECT count(*)::int FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') detail,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') remark,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp
       FROM "DELETE_DATA" d WHERE d.tenant_id=$1 AND d."CO_BOOK"=$2 AND d."VCH_NO"='00005'`,
      TENANT,
      GOLD_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(deleted).toHaveLength(1);
    expect(deleted[0]).toMatchObject({
      VCH_TYPE: 'DGGLD',
      BOOK_NAME: 'Digital Gold Book',
      AC_CODE: '00010',
      AC_NAME: '',
      VCH_VAL_DR: 200,
      VCH_VAL_CR: 200,
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      VCH_DESC: 'Replacement line',
      DELETE_USER: 'deleter',
      detail: 0,
      ledger: 0,
      rojmel: 0,
      remark: 0,
      temp: 0,
    });
  }, 30_000);

  it('creates, reads, edits, locks and desktop-deletes location amount plus its mirror atomically', async () => {
    const created = await saveLocationAmount(runtime, {
      scope: amountScope,
      vchDate: DAY,
      employeeCode: 'E01',
      remark: 'Transfer remark',
      toLocation: DEST_LC,
      mainUser: 'amount-user',
      lines: [{ acCode: '00010', chequeNo: '01', amount: 100, description: 'Branch transfer' }],
    });
    expect(created).toMatchObject({
      voucherNo: '00004',
      hiddenVoucherNo: '00007',
      created: true,
      lines: 1,
      transfer: {
        fromLocation: LC,
        fromBook: AMOUNT_BOOK,
        fromVoucherNo: '00004',
        toLocation: DEST_LC,
        toBook: '159',
        toVoucherNo: '00001',
      },
    });
    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') source,
        (SELECT count(*)::int FROM "LOCT_AMT" WHERE tenant_id=$1 AND "LC_CODE"=$3 AND "CO_BOOK"='159' AND "VCH_NO"='00001') mirror,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') ledger,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') rojmel,
        (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') remark,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00007') temp,
        (SELECT min("MAIN_USER") FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') main_user,
        (SELECT min("VCH_TIME")::text FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') vch_time`,
      TENANT,
      AMOUNT_BOOK,
      DEST_LC,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      source: 1,
      mirror: 1,
      ledger: 2,
      rojmel: 2,
      remark: 1,
      temp: 1,
      main_user: 'amount-user',
    });
    const originalTime = String(persisted[0]!.vch_time);
    expect(await getLocationAmount(runtime, amountScope, created.voucherNo)).toMatchObject({
      voucherNo: '00004',
      vchDate: DAY,
      hiddenVoucherNo: '00007',
      mainUser: 'amount-user',
      toLocation: DEST_LC,
      toBook: '159',
      toVoucherNo: '00001',
      lines: [{ acCode: '00010', acName: 'Voucher Party', amount: 100 }],
    });

    await expect(
      saveLocationAmount(
        runtime,
        {
          scope: amountScope,
          vchDate: NEXT_DAY,
          employeeCode: 'E01',
          remark: 'Edited transfer',
          toLocation: DEST_LC,
          mainUser: 'ignored-user',
          lines: [
            { acCode: '00010', chequeNo: '02', amount: 150, description: 'Edited branch transfer' },
          ],
        },
        created.voucherNo,
      ),
    ).resolves.toMatchObject({ created: false, voucherNo: '00004', hiddenVoucherNo: '00007' });
    const afterEdit = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') source,
        (SELECT count(*)::int FROM "LOCT_AMT" WHERE tenant_id=$1 AND "LC_CODE"=$3 AND "CO_BOOK"='159' AND "VCH_NO"='00001') mirror,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') deleted,
        (SELECT min("MAIN_USER") FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') main_user,
        (SELECT min("VCH_TIME")::text FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') vch_time,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') dr`,
      TENANT,
      AMOUNT_BOOK,
      DEST_LC,
    )) as Array<Record<string, unknown>>;
    expect(afterEdit[0]).toMatchObject({
      source: 1,
      mirror: 1,
      deleted: 0,
      main_user: 'amount-user',
      cr: 150,
      dr: 150,
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
      saveLocationAmount(
        runtime,
        {
          scope: amountScope,
          vchDate: '2024-04-12',
          toLocation: DEST_LC,
          lines: [{ acCode: '00010', amount: 175 }],
        },
        created.voucherNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    await expect(
      deleteLocationAmount(runtime, amountScope, created.voucherNo),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    const lockedState = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') source,
        (SELECT count(*)::int FROM "LOCT_AMT" WHERE tenant_id=$1 AND "LC_CODE"=$3 AND "CO_BOOK"='159' AND "VCH_NO"='00001') mirror,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') deleted,
        (SELECT min("MAIN_USER") FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') main_user,
        (SELECT min("VCH_TIME")::text FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') vch_time,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') dr`,
      TENANT,
      AMOUNT_BOOK,
      DEST_LC,
    )) as Array<Record<string, unknown>>;
    expect(JSON.stringify(lockedState[0])).toBe(beforeRejected);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(
      deleteLocationAmount(runtime, amountScope, created.voucherNo, 'deleter'),
    ).resolves.toEqual({ reversed: true });
    const deleted = (await owner.$queryRawUnsafe(
      `SELECT d."VCH_TYPE",d."BOOK_NAME",d."AC_CODE",d."AC_NAME",d."VCH_VAL_DR",d."VCH_VAL_CR",
              d."FINE_TYPE",d."VCH_FINE_DR"::float,d."VCH_FINE_CR"::float,d."VCH_DESC",
        (SELECT count(*)::int FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') source,
        (SELECT count(*)::int FROM "LOCT_AMT" WHERE tenant_id=$1 AND "LC_CODE"=$3 AND "CO_BOOK"='159' AND "VCH_NO"='00001') mirror,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') ledger,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') rojmel,
        (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00004') remark,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00007') temp
       FROM "DELETE_DATA" d WHERE d.tenant_id=$1 AND d."CO_BOOK"=$2 AND d."VCH_NO"='00004'`,
      TENANT,
      AMOUNT_BOOK,
      DEST_LC,
    )) as Array<Record<string, unknown>>;
    expect(deleted).toHaveLength(1);
    expect(deleted[0]).toMatchObject({
      VCH_TYPE: 'AMTO',
      BOOK_NAME: 'Amount Out',
      AC_CODE: '00010',
      AC_NAME: 'Voucher Party',
      VCH_VAL_DR: 150,
      VCH_VAL_CR: 0,
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      VCH_DESC: 'Edited branch transfer',
      source: 0,
      mirror: 0,
      ledger: 0,
      rojmel: 0,
      remark: 0,
      temp: 0,
    });
  }, 30_000);
});
