import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteOtherIncome,
  getOtherIncome,
  saveOtherIncome,
  type OtherIncomeInput,
} from '../src/modules/purchase/otherIncome.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'other-income-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'OIN';
const DAY = '2024-04-10';
const NEXT_DAY = '2024-04-11';

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
  const rows = await query<{ table_name: string }>(
    `SELECT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
  );
  for (const row of rows) await exec(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seedBook(book = BOOK, mainBook = 'OTH INC', inout = 'I') {
  await exec(
    `INSERT INTO "BOOK_DATA"(
       tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
       "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
     VALUES ($1,$2,$3,$4,'Other Income','OTINC',$5,$6,'Y','PAY_DATA','PAY_DETL','A')`,
    TENANT,
    CO,
    LC,
    book,
    mainBook,
    inout,
  );
}

async function seed() {
  await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`, TENANT, CO);
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31'::timestamp)`,
    TENANT,
    CO,
    YEAR,
  );
  await seedBook();
  for (const [code, name, gstType] of [
    ['CUST01', 'Income Customer', 'L'],
    ['INC001', 'Shop Rent Income', 'L'],
    ['CASH01', 'Cash on Hand', 'L'],
    ['BANK01', 'Cheque Bank', 'L'],
    ['CARD01', 'Card Bank', 'L'],
    ['KSR001', 'Kasar Writeoff', 'L'],
    ['GST001', 'Output GST', 'L'],
    ['TDS001', 'TDS Receivable', 'L'],
  ] as const) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,$4,$5,$6)`,
      TENANT,
      CO,
      LC,
      code,
      name,
      gstType,
    );
  }
  await exec(
    `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
     VALUES
       ($1,$2,'T1',0,'GST','GST 18',18,'GST001'),
       ($1,$2,'T1',1,'SGST','SGST 9',9,'GST001'),
       ($1,$2,'T1',2,'CGST','CGST 9',9,'GST001'),
       ($1,$2,'T1',3,'IGST','IGST 18',18,'GST001'),
       ($1,$2,'TD',0,'TDS','TDS 5',5,'TDS001')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,$2,'E01','Employee One')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "PAY_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE")
     VALUES ($1,$2,$3,$4,$5,'00004',$6::date)`,
    TENANT,
    CO,
    LC,
    YEAR,
    BOOK,
    DAY,
  );
  await exec(
    `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
     VALUES ($1,$2,$3,$4,'00009','prior hidden identity')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
}

const input = (overrides: Partial<OtherIncomeInput> = {}): OtherIncomeInput => ({
  scope,
  vchDate: DAY,
  partyCode: 'CUST01',
  ledgerCode: 'INC001',
  billDate: DAY,
  chequeAmount: 100,
  chequeAccount: 'BANK01',
  chequeNo: 'CHQ99',
  cardAmount: 50,
  cardAccount: 'CARD01',
  cashAmount: 70,
  cashAccount: 'CASH01',
  kasarAmount: 2,
  kasarAccount: 'KSR001',
  tdsCode: 'TD',
  employeeCode: 'E01',
  bankName: 'Test Bank',
  description: 'Income voucher remark',
  lines: [
    {
      hsnCode: '9983',
      itemName: 'Rent income',
      netAmount: 1000,
      discountPercent: 10,
      taxCode: 'T1',
      taxType: 'F',
    },
  ],
  mainUser: 'creator',
  ...overrides,
});

databaseDescribe('database-backed TR_OTH_PURC Other Income mode', () => {
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

  it('creates, reads, edits and desktop-deletes an OTH INC PAY voucher', async () => {
    const created = await saveOtherIncome(runtime, input());
    expect(created).toEqual({ voucherNo: '00005', hiddenVoucherNo: '00010', created: true, lines: 1 });

    const persisted = await query(
      `SELECT
         (SELECT count(*)::int FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_data,
         (SELECT count(*)::int FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_detl,
         (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
         (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
         (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
         (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') remark,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00010') temp,
         (SELECT min("BOOK_NAME") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') book_name,
         (SELECT min("BILL_NO") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') bill_no,
         (SELECT min("NET_AMT")::float FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') net_amt,
         (SELECT min("DISC_AMT")::float FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') disc_amt,
         (SELECT min("CGST_TAX")::float FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cgst,
         (SELECT min("SGST_TAX")::float FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') sgst,
         (SELECT min("TDS_AMT")::float FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tds,
         (SELECT min("TOT_AMT")::float FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') total,
         (SELECT min("BILL_OS")::float FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') os,
         (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
         (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr`,
      TENANT,
      BOOK,
    );
    expect(persisted[0]).toMatchObject({
      pay_data: 1,
      pay_detl: 1,
      ledger: 13,
      tax: 2,
      rojmel: 6,
      remark: 1,
      temp: 1,
      book_name: 'OTH INC',
      bill_no: '00005',
      net_amt: 900,
      disc_amt: 100,
      cgst: 81,
      sgst: 81,
      tds: 40,
      total: 1022,
      os: 800,
      cr: 1324,
      dr: 1324,
    });
    await expect(getOtherIncome(runtime, scope, created.voucherNo)).resolves.toMatchObject({
      voucherNo: '00005',
      hiddenVoucherNo: '00010',
      partyCode: 'CUST01',
      partyName: 'Income Customer',
      ledgerCode: 'INC001',
      ledgerName: 'Shop Rent Income',
      netAmount: 900,
      discountAmount: 100,
      cgstAmount: 81,
      sgstAmount: 81,
      tdsAmount: 40,
      totalAmount: 1022,
      outstandingAmount: 800,
      lines: [
        expect.objectContaining({
          hsnCode: '9983',
          itemName: 'Rent income',
          taxableAmount: 900,
          totalAmount: 1062,
        }),
      ],
    });

    const edited = await saveOtherIncome(
      runtime,
      input({
        vchDate: NEXT_DAY,
        mainUser: 'editor',
        description: 'Edited income voucher',
        lines: [{ hsnCode: '9984', itemName: 'Consulting income', netAmount: 500, taxCode: 'T1', taxType: 'R' }],
        chequeAmount: 0,
        cardAmount: 0,
        cashAmount: 0,
        kasarAmount: 0,
        tdsCode: '',
      }),
      created.voucherNo,
    );
    expect(edited).toEqual({ voucherNo: '00005', hiddenVoucherNo: '00010', created: false, lines: 1 });
    const afterEdit = await query(
      `SELECT
         (SELECT min("MAIN_USER") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') main_user,
         (SELECT min("HD_VCH_NO") FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') hidden,
         (SELECT min("IT_NAME") FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') item_name,
         (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
         (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
         (SELECT coalesce(sum("CR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') cr,
         (SELECT coalesce(sum("DR_AMT"),0)::float FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') dr`,
      TENANT,
      BOOK,
    );
    expect(afterEdit[0]).toMatchObject({
      main_user: 'creator',
      hidden: '00010',
      item_name: 'Consulting income',
      ledger: 3,
      tax: 2,
      cr: 500,
      dr: 500,
    });

    await expect(deleteOtherIncome(runtime, scope, created.voucherNo, 'deleter')).resolves.toEqual({
      reversed: true,
      auditedLines: 1,
    });
    const afterDelete = await query(
      `SELECT
         (SELECT count(*)::int FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_data,
         (SELECT count(*)::int FROM "PAY_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') pay_detl,
         (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') ledger,
         (SELECT count(*)::int FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') tax,
         (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') rojmel,
         (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') remark,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00010') temp,
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') delete_rows,
         (SELECT min("VCH_DESC") FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005') delete_desc`,
      TENANT,
      BOOK,
    );
    expect(afterDelete[0]).toMatchObject({
      pay_data: 0,
      pay_detl: 0,
      ledger: 0,
      tax: 0,
      rojmel: 0,
      remark: 0,
      temp: 0,
      delete_rows: 1,
      delete_desc: 'Consulting income',
    });
  });

  it('rejects non-OTH INC books and incomplete settlement accounts before writing', async () => {
    await seedBook('BAD', 'OTH EXP', 'O');
    await expect(
      saveOtherIncome(runtime, input({ scope: { ...scope, coBook: 'BAD' } })),
    ).rejects.toThrow(/OTH INC/);
    await expect(saveOtherIncome(runtime, input({ cashAmount: 1, cashAccount: '' }))).rejects.toThrow(
      /cash account is required/,
    );
    const rows = await query(
      `SELECT count(*)::int AS n FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00005'`,
      TENANT,
      BOOK,
    );
    expect(rows[0]).toMatchObject({ n: 0 });
  });
});
