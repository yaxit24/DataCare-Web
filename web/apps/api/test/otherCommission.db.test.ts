import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteOtherCommission,
  getOtherCommission,
  saveOtherCommission,
  type OtherCommissionInput,
} from '../src/modules/purchase/otherCommission.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'other-commission-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = '079';
const DAY = '2024-04-10';
const NEXT_DAY = '2024-04-11';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

const input = (overrides: Partial<OtherCommissionInput> = {}): OtherCommissionInput => ({
  scope,
  vchDate: DAY,
  partyCode: '00200',
  billNo: 'B-100',
  billDate: DAY,
  chequeAmount: 30,
  chequeAccount: '00020',
  chequeNo: 'CHQ1',
  cardAmount: 10,
  cardAccount: '00021',
  cashAmount: 20,
  kasarAmount: 8,
  employeeCode: 'E01',
  bankName: 'Test Bank',
  description: 'Commission voucher remark',
  mainUser: 'creator',
  lines: [
    {
      itemCode: 'I001',
      remark: 'First line',
      saleAmount: 1000,
      commissionPercent: 10,
      taxCode: 'T1',
      taxType: 'F',
    },
  ],
  ...overrides,
});

databaseDescribe('database-backed TR_OTH_COMM voucher', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    for (const table of [
      'DELETE_DATA',
      'REMARK_DATA',
      'ROJ_MEL_DATA',
      'TAX_DATA',
      'AC_DATA',
      'PAY_DETL',
      'PAY_DATA',
      'TEMP_BOOK_DATA',
      'TAX_MAST',
      'EMP_MAST',
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

  const seed = async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","EMP_CODE_MANDATORY","TAX_ROF")
       VALUES ($1,$2,NULL,'N','2')`,
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
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'Service Commission','SVCOM','OTH COMM','O','Y','PAY_DATA','PAY_DETL','A')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    for (const [sr, code, name] of [
      [1, '00001', 'Cash on Hand'],
      [2, '00044', 'Commission Income'],
      [3, '00057', 'Kasar Expense'],
    ] as const) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "BOOK_DETL"(
           tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","AC_NAME",
           "BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE")
         VALUES ($1,$2,$3,$4,$5,$6,$7,'SVCOM','OTH COMM','O','A')`,
        TENANT,
        CO,
        LC,
        BOOK,
        sr,
        code,
        name,
      );
    }
    for (const [code, name, gstType] of [
      ['00001', 'Cash on Hand', 'L'],
      ['00020', 'Cheque Bank', 'L'],
      ['00021', 'Card Bank', 'L'],
      ['00044', 'Commission Income', 'L'],
      ['00057', 'Kasar Expense', 'L'],
      ['00085', 'Output GST', 'L'],
      ['00200', 'Commission Customer', 'L'],
    ]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(
           tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
         VALUES ($1,$2,$3,$4,$5,$6)`,
        TENANT,
        CO,
        LC,
        code,
        name,
        gstType,
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
       VALUES ($1,$2,'I001','Commission Service','A'),($1,$2,'I002','Expense Item','A')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(
         tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES
         ($1,$2,'T1',0,'GST','GST 18',18,'00085'),
         ($1,$2,'T1',1,'SGST','SGST 9',9,'00085'),
         ($1,$2,'T1',2,'CGST','CGST 9',9,'00085'),
         ($1,$2,'T1',3,'IGST','IGST 18',18,'00085')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME")
       VALUES ($1,$2,'E01','Employee One')`,
      TENANT,
      CO,
    );
    // Independent MAX+1 evidence: PAY_DATA and TEMP_BOOK_DATA begin at different identities.
    await owner.$executeRawUnsafe(
      `INSERT INTO "PAY_DATA"(
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
      `INSERT INTO "TEMP_BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
       VALUES ($1,$2,$3,$4,'00007','prior hidden identity')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    if (new URL(ownerUrl).port !== '55433' || new URL(runtimeUrl).port !== '55433') {
      throw new Error('otherCommission.db.test.ts is restricted to database port 55433');
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

  it('creates, reads, rewrites, persisted-date locks and desktop-deletes atomically', async () => {
    const created = await saveOtherCommission(runtime, input());
    expect(created).toEqual({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: true,
      lines: 1,
    });
    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_data,
        (SELECT count(*)::int FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_detl,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') remark,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp,
        (SELECT min("HD_VCH_NO") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') hidden,
        (SELECT min("MAIN_USER") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT min("VCH_TIME")::text FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_time,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      pay_data: 1,
      pay_detl: 1,
      ledger: 11,
      tax: 2,
      rojmel: 5,
      remark: 1,
      temp: 1,
      hidden: '00008',
      main_user: 'creator',
      cr: 186,
      dr: 186,
    });
    const originalTime = String(persisted[0]!.vch_time);

    await expect(getOtherCommission(runtime, scope, created.voucherNo)).resolves.toMatchObject({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      vchDate: DAY,
      partyCode: '00200',
      partyName: 'Commission Customer',
      netAmount: 100,
      cgstAmount: 9,
      sgstAmount: 9,
      totalAmount: 118,
      outstandingAmount: 50,
      lines: [
        {
          itemCode: 'I001',
          itemName: 'Commission Service',
          saleAmount: 1000,
          commissionPercent: 10,
          taxableAmount: 100,
          cgstAmount: 9,
          sgstAmount: 9,
          totalAmount: 118,
        },
      ],
    });

    const edited = await saveOtherCommission(
      runtime,
      input({
        vchDate: NEXT_DAY,
        description: 'Edited commission voucher',
        mainUser: 'ignored-editor',
        chequeAmount: 0,
        chequeAccount: '',
        chequeNo: '',
        cardAmount: 0,
        cardAccount: '',
        cashAmount: 118,
        kasarAmount: 0,
        lines: [
          {
            itemCode: 'I002',
            remark: 'Replacement line',
            saleAmount: 500,
            commissionPercent: 20,
            taxCode: 'T1',
            taxType: 'F',
          },
        ],
      }),
      created.voucherNo,
    );
    expect(edited).toMatchObject({
      voucherNo: '00005',
      hiddenVoucherNo: '00008',
      created: false,
      lines: 1,
    });
    const afterEdit = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_data,
        (SELECT count(*)::int FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_detl,
        (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') deleted,
        (SELECT min("MAIN_USER") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT min("HD_VCH_NO") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') hidden,
        (SELECT min("VCH_TIME")::text FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_time,
        (SELECT min("IT_NAME") FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') item_name,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(afterEdit[0]).toMatchObject({
      pay_data: 1,
      pay_detl: 1,
      tax: 2,
      deleted: 0,
      main_user: 'creator',
      hidden: '00008',
      item_name: 'Expense Item',
      cr: 236,
      dr: 236,
    });
    expect(String(afterEdit[0]!.vch_time).slice(11)).toBe(originalTime.slice(11));

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date::text WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      NEXT_DAY,
      TENANT,
      CO,
    );
    const beforeRejected = JSON.stringify(afterEdit[0]);
    await expect(
      saveOtherCommission(
        runtime,
        input({
          vchDate: '2024-04-12',
          cashAmount: 118,
          chequeAmount: 0,
          chequeAccount: '',
          cardAmount: 0,
          cardAccount: '',
          kasarAmount: 0,
        }),
        created.voucherNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    await expect(
      deleteOtherCommission(runtime, scope, created.voucherNo, 'deleter'),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    const lockedState = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_data,
        (SELECT count(*)::int FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_detl,
        (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') deleted,
        (SELECT min("MAIN_USER") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
        (SELECT min("HD_VCH_NO") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') hidden,
        (SELECT min("VCH_TIME")::text FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') vch_time,
        (SELECT min("IT_NAME") FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') item_name,
        (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
        (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(JSON.stringify(lockedState[0])).toBe(beforeRejected);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(
      deleteOtherCommission(runtime, scope, created.voucherNo, 'deleter'),
    ).resolves.toEqual({ reversed: true, auditedLines: 1 });
    const deleted = (await owner.$queryRawUnsafe(
      `SELECT d."CO_CODE",d."LC_CODE",d."CO_YEAR",d."CO_BOOK",d."VCH_NO",d."SR_NO",
              d."VCH_TYPE",d."BOOK_NAME",d."AC_CODE",d."AC_NAME",d."VCH_VAL_DR",
              d."VCH_VAL_CR",d."FINE_TYPE",d."VCH_FINE_DR"::float,d."VCH_FINE_CR"::float,
              d."HD_VCH_NO",d."MAIN_USER",d."DELETE_USER",d."VCH_DESC",
        (SELECT count(*)::int FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_data,
        (SELECT count(*)::int FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_detl,
        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
        (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
        (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
        (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') remark,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp
       FROM "DELETE_DATA" d
       WHERE d.tenant_id=$1 AND d."CO_BOOK"=$2 AND d."VCH_NO"='00005'`,
      TENANT,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(deleted).toHaveLength(1);
    expect(deleted[0]).toMatchObject({
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: BOOK,
      VCH_NO: '00005',
      SR_NO: 1,
      VCH_TYPE: 'SVCOM',
      BOOK_NAME: 'Service Commission',
      AC_CODE: '00200',
      AC_NAME: 'Commission Customer',
      VCH_VAL_DR: 0,
      VCH_VAL_CR: 118,
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      HD_VCH_NO: '00005',
      MAIN_USER: 'creator',
      DELETE_USER: 'deleter',
      VCH_DESC: 'Expense Item',
      pay_data: 0,
      pay_detl: 0,
      ledger: 0,
      tax: 0,
      rojmel: 0,
      remark: 0,
      temp: 0,
    });
  }, 30_000);
});
