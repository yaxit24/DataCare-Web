import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteCustomerRepairReceipt,
  saveCustomerRepairReceipt,
} from '../src/modules/repair/repairReceipt.js';
import {
  deleteKarigarRepairIssue,
  getKarigarRepairIssue,
  listOpenCustomerRepairLines,
  saveKarigarRepairIssue,
} from '../src/modules/repair/repairKarigarIssue.js';
import {
  deleteKarigarRepairReceipt,
  getKarigarRepairReceipt,
  listOpenKarigarRepairIssueLines,
  saveKarigarRepairReceipt,
} from '../src/modules/repair/repairKarigarReceipt.js';
import {
  deleteCustomerRepairIssue,
  getCustomerRepairIssue,
  listOpenCustomerRepairDeliveries,
  saveCustomerRepairIssue,
} from '../src/modules/repair/repairCustomerIssue.js';
import {
  deleteRepairImage,
  getRepairImage,
  listRepairImageKeys,
  saveRepairImage,
} from '../src/modules/repair/repairImage.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'task7-repair-receipt';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'RCR';
const ISSUE_BOOK = 'RKI';
const RECEIPT_BOOK = 'RKR';
const DELIVERY_BOOK = 'RCI';
const DAY = '2024-04-10';

const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

const issueScope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: ISSUE_BOOK,
};

const receiptScope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: RECEIPT_BOOK,
};

const deliveryScope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: DELIVERY_BOOK,
};

databaseDescribe('database-backed customer repair receipt integrity', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    for (const table of [
      'DELETE_DATA',
      'REMARK_DATA',
      'TAX_DATA',
      'ROJ_MEL_DATA',
      'AC_DATA',
      'REP_IMAGE',
      'REP_DETL',
      'REP_DATA',
      'TEMP_BOOK_DATA',
      'BOOK_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'GROUP_MAST',
      'TAX_MAST',
      'AC_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","TAX_ROF","TRAD_FINE") VALUES ($1,$2,NULL,'2','Y')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'CUST','Repair Customer','L'),
              ($1,$2,$3,'KAR','Repair Karigar','L'),
              ($1,$2,$3,'KAR2','Other Karigar','L'),
              ($1,$2,$3,'BANK','Cheque Bank','L'),
              ($1,$2,$3,'CARD','Card Bank','L'),
              ($1,$2,$3,'CASH','Cash Account','L'),
              ($1,$2,$3,'PURC','Repair Purchase','L'),
              ($1,$2,$3,'SALEAC','Repair Sale','L'),
              ($1,$2,$3,'KRCTL','Karigar Control','L'),
              ($1,$2,$3,'CSCTL','Customer Control','L'),
              ($1,$2,$3,'LBRAC','Repair Labour','L'),
              ($1,$2,$3,'KASAR','Kasar Account','L'),
              ($1,$2,$3,'GSTAC','GST Account','L')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC","SALE_AC")
       VALUES ($1,$2,'GLD','Gold Group','PURC','SALEAC')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'03',0,'GST 3%',3,'GSTAC')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","RATE_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold Ring','G','G','GLD')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"
         (tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","DATA_TYPE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,'Repair Received','RPR','CUSTREP RECEIPT','I','Y','A','REP_DATA'),
              ($1,$2,$3,$5,'Repair Karigar Issue','RKI','KRREP ISSUE','O','Y','A','REP_DATA'),
              ($1,$2,$3,$6,'Repair Karigar Receipt','RKR','KRREP RECEIPT','I','Y','A','REP_DATA'),
              ($1,$2,$3,$7,'Repair Customer Issue','RCI','CUSTREP ISSUE','O','Y','A','REP_DATA')`,
      TENANT,
      CO,
      LC,
      BOOK,
      ISSUE_BOOK,
      RECEIPT_BOOK,
      DELIVERY_BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"
         (tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE")
       VALUES ($1,$2,$3,$4,1,'CASH','RPR','CUSTREP RECEIPT','I','A'),
              ($1,$2,$3,$5,1,'CASH','RKI','KRREP ISSUE','O','A'),
              ($1,$2,$3,$6,1,'CASH','RKR','KRREP RECEIPT','I','A'),
              ($1,$2,$3,$6,2,'KRCTL','RKR','KRREP RECEIPT','I','A'),
              ($1,$2,$3,$6,3,'LBRAC','RKR','KRREP RECEIPT','I','A'),
              ($1,$2,$3,$6,5,'KASAR','RKR','KRREP RECEIPT','I','A'),
              ($1,$2,$3,$7,1,'CASH','RCI','CUSTREP ISSUE','O','A'),
              ($1,$2,$3,$7,2,'CSCTL','RCI','CUSTREP ISSUE','O','A'),
              ($1,$2,$3,$7,3,'LBRAC','RCI','CUSTREP ISSUE','O','A'),
              ($1,$2,$3,$7,5,'KASAR','RCI','CUSTREP ISSUE','O','A')`,
      TENANT,
      CO,
      LC,
      BOOK,
      ISSUE_BOOK,
      RECEIPT_BOOK,
      DELIVERY_BOOK,
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

  it('persists, edits, and reverses the source write-set using configured accounts and persisted lock date', async () => {
    const created = await saveCustomerRepairReceipt(runtime, {
      scope,
      acCode: 'CUST',
      vchDate: DAY,
      billNo: 'C-101',
      employeeCode: 'E01',
      bankName: 'Main Bank',
      description: 'Resize ring',
      chequeAmount: 20,
      chequeAccount: 'BANK',
      chequeNo: 'CHQ1',
      cardAmount: 10,
      cardAccount: 'CARD',
      cashAmount: 15,
      mainUser: 'repair-user',
      lines: [
        {
          itCode: 'GOLD',
          itmSize: '12',
          description: 'Resize by one size',
          pcs: 1,
          grossWt: 10,
          otherWt: 1,
          touch: 91.6,
          labourType: 'N',
          labourRate: 10,
          otherAmount: 5,
        },
      ],
    });
    expect(created).toMatchObject({
      vchNo: 1,
      voucherNo: '00001',
      headerVoucherNo: '00001',
      created: true,
      totals: { netAmount: 95, totalAmount: 95, outstandingAmount: 50 },
    });

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1) header_count,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1) detail_count,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_count,
         (SELECT count(*) FROM "REMARK_DATA" WHERE tenant_id=$1) remark_count,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1) ledger_count,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1) roj_count,
         (SELECT coalesce(sum("CR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1) ledger_cr,
         (SELECT coalesce(sum("DR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1) ledger_dr,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"='CASH' AND "LD_CODE"='CUST' AND "DR_AMT"=15) configured_cash,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "AC_CODE"='CASH' AND "LD_CODE"='CUST' AND "CR_AMT"=15) roj_cash,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "BOOK_NAME"='CUSTREP RECEIPT'
            AND "REP_NO"='00001' AND "REP_ADJ"='N' AND "ISU_ADJ"='N'
            AND "IT_NAME"='Gold Ring' AND "ITM_NWT"=9 AND "LBR_AMT"=90 AND "NET_AMT"=95) exact_detail`,
      TENANT,
    )) as Array<Record<string, bigint>>;
    expect(Number(persisted[0]?.header_count)).toBe(1);
    expect(Number(persisted[0]?.detail_count)).toBe(1);
    expect(Number(persisted[0]?.temp_count)).toBe(1);
    expect(Number(persisted[0]?.remark_count)).toBe(1);
    expect(Number(persisted[0]?.ledger_count)).toBe(6);
    expect(Number(persisted[0]?.roj_count)).toBe(5);
    expect(Number(persisted[0]?.ledger_cr)).toBe(45);
    expect(Number(persisted[0]?.ledger_dr)).toBe(45);
    expect(Number(persisted[0]?.configured_cash)).toBe(1);
    expect(Number(persisted[0]?.roj_cash)).toBe(1);
    expect(Number(persisted[0]?.exact_detail)).toBe(1);

    const updated = await saveCustomerRepairReceipt(runtime, {
      scope,
      vchNo: created.voucherNo,
      acCode: 'CUST',
      vchDate: DAY,
      description: 'Resize ring — revised',
      cashAmount: 5,
      mainUser: 'repair-user',
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 8, labourType: 'N', labourRate: 5 }],
    });
    expect(updated).toMatchObject({
      voucherNo: '00001',
      headerVoucherNo: '00001',
      created: false,
      totals: { netAmount: 40, outstandingAmount: 35 },
    });
    const edited = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1) details,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_rows,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1) roj_rows,
         (SELECT "VCH_DESC" FROM "REP_DATA" WHERE tenant_id=$1 LIMIT 1) description`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(Number(edited[0]?.headers)).toBe(1);
    expect(Number(edited[0]?.details)).toBe(1);
    expect(Number(edited[0]?.temp_rows)).toBe(1);
    expect(Number(edited[0]?.ledger_rows)).toBe(2);
    expect(Number(edited[0]?.roj_rows)).toBe(1);
    expect(edited[0]?.description).toBe('Resize ring — revised');

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      deleteCustomerRepairReceipt(runtime, {
        scope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(
      Number(
        (
          (await owner.$queryRawUnsafe(
            `SELECT count(*) AS n FROM "REP_DATA" WHERE tenant_id=$1`,
            TENANT,
          )) as Array<{ n: bigint }>
        )[0]?.n,
      ),
    ).toBe(1);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(
      deleteCustomerRepairReceipt(runtime, {
        scope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).resolves.toEqual({ reversed: true });
    const reversed = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1) details,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_rows,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1) roj_rows,
         (SELECT count(*) FROM "REMARK_DATA" WHERE tenant_id=$1) remarks,
         (SELECT count(*) FROM "DELETE_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001') delete_rows`,
      TENANT,
    )) as Array<Record<string, bigint>>;
    for (const key of ['headers', 'details', 'temp_rows', 'ledger_rows', 'roj_rows', 'remarks']) {
      expect(Number(reversed[0]?.[key])).toBe(0);
    }
    expect(Number(reversed[0]?.delete_rows)).toBe(1);

    const reused = await saveCustomerRepairReceipt(runtime, {
      scope,
      acCode: 'CUST',
      vchDate: DAY,
      lines: [{ itCode: 'GOLD', pcs: 1, description: 'New repair' }],
    });
    expect(reused).toMatchObject({ voucherNo: '00001', headerVoucherNo: '00001' });
  }, 30_000);

  it('links open customer repairs, posts issue-side tender, edits atomically, and releases the source on reversal', async () => {
    const receipt = await saveCustomerRepairReceipt(runtime, {
      scope,
      acCode: 'CUST',
      vchDate: DAY,
      description: 'Customer resize',
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 10, otherWt: 1, touch: 91.6 }],
    });
    const source = {
      coYear: YEAR,
      coBook: BOOK,
      voucherNo: receipt.voucherNo,
      srNo: 1,
    };

    const openBefore = await listOpenCustomerRepairLines(runtime, issueScope);
    expect(openBefore).toHaveLength(1);
    expect(openBefore[0]).toMatchObject({
      voucherNo: '00001',
      srNo: 1,
      customerCode: 'CUST',
      customerName: 'Repair Customer',
      itCode: 'GOLD',
      netWt: 9,
    });

    const created = await saveKarigarRepairIssue(runtime, {
      scope: issueScope,
      acCode: 'KAR',
      vchDate: DAY,
      billNo: 'K-101',
      description: 'Issue ring to karigar',
      chequeAmount: 20,
      chequeAccount: 'BANK',
      chequeNo: 'KCH1',
      cardAmount: 10,
      cardAccount: 'CARD',
      cashAmount: 15,
      mainUser: 'repair-user',
      lines: [source],
    });
    expect(created).toMatchObject({
      voucherNo: '00001',
      headerVoucherNo: '00001',
      created: true,
      totals: {
        netAmount: 0,
        totalAmount: 0,
        outstandingAmount: 0,
      },
    });
    const loaded = await getKarigarRepairIssue(runtime, issueScope, created.voucherNo);
    expect(loaded).toMatchObject({
      voucherNo: '00001',
      headerVoucherNo: '00001',
      acCode: 'KAR',
      lines: [
        {
          coYear: YEAR,
          coBook: BOOK,
          voucherNo: '00001',
          srNo: 1,
          customerCode: 'CUST',
          customerName: 'Repair Customer',
          netWt: 9,
        },
      ],
    });
    expect(await listOpenCustomerRepairLines(runtime, issueScope)).toEqual([]);

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) issue_headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) issue_details,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) issue_temp,
         (SELECT count(*) FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) issue_remarks,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT coalesce(sum("CR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_cr,
         (SELECT coalesce(sum("DR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_dr,
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "CHQ_NO"='KCH1') header_cheque_no,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND coalesce("CHQ_NO",'')='') blank_ledger_cheque_no,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='KAR' AND "DR_AMT">0) party_debits,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CASH' AND "LD_CODE"='KAR' AND "CR_AMT"=15) cash_credit,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CASH' AND "LD_CODE"='KAR' AND "DR_AMT"=15) roj_cash_debit,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "BOOK_NAME"='KRREP ISSUE' AND "REP_YRCD"=$3 AND "REP_DBCD"=$4
            AND "REP_NO"='00001' AND "REP_SRNO"=1 AND "REP_AC_CODE"='CUST'
            AND "ISU_NO"='00001' AND "ISU_AC_CODE"='KAR' AND "ITM_NWT"=9
            AND "ITM_AMT"=0 AND "LBR_AMT"=0 AND "NET_AMT"=0) exact_issue_detail,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$4
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='Y') source_marked,
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "VCH_NO"='00001' AND "BILL_OS"=0 AND "TOT_AMT"=0) zero_bill_totals`,
      TENANT,
      ISSUE_BOOK,
      YEAR,
      BOOK,
    )) as Array<Record<string, bigint>>;
    expect(Number(persisted[0]?.issue_headers)).toBe(1);
    expect(Number(persisted[0]?.issue_details)).toBe(1);
    expect(Number(persisted[0]?.issue_temp)).toBe(1);
    expect(Number(persisted[0]?.issue_remarks)).toBe(1);
    expect(Number(persisted[0]?.ledger_rows)).toBe(6);
    expect(Number(persisted[0]?.roj_rows)).toBe(5);
    expect(Number(persisted[0]?.ledger_cr)).toBe(45);
    expect(Number(persisted[0]?.ledger_dr)).toBe(45);
    expect(Number(persisted[0]?.header_cheque_no)).toBe(1);
    expect(Number(persisted[0]?.blank_ledger_cheque_no)).toBe(6);
    expect(Number(persisted[0]?.party_debits)).toBe(3);
    expect(Number(persisted[0]?.cash_credit)).toBe(1);
    expect(Number(persisted[0]?.roj_cash_debit)).toBe(1);
    expect(Number(persisted[0]?.exact_issue_detail)).toBe(1);
    expect(Number(persisted[0]?.source_marked)).toBe(1);
    expect(Number(persisted[0]?.zero_bill_totals)).toBe(1);

    const updated = await saveKarigarRepairIssue(runtime, {
      scope: issueScope,
      vchNo: created.voucherNo,
      acCode: 'KAR',
      vchDate: DAY,
      description: 'Issue ring — revised',
      cashAmount: 5,
      mainUser: 'repair-user',
      lines: [source],
    });
    expect(updated).toMatchObject({
      voucherNo: '00001',
      headerVoucherNo: '00001',
      created: false,
    });
    const edited = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) temp_rows,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='Y') source_still_marked,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='KAR' AND "DR_AMT"=5) party_cash_debit,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CASH' AND "DR_AMT"=5) roj_cash_debit`,
      TENANT,
      ISSUE_BOOK,
      BOOK,
    )) as Array<Record<string, bigint>>;
    expect(Number(edited[0]?.headers)).toBe(1);
    expect(Number(edited[0]?.details)).toBe(1);
    expect(Number(edited[0]?.temp_rows)).toBe(1);
    expect(Number(edited[0]?.ledger_rows)).toBe(2);
    expect(Number(edited[0]?.roj_rows)).toBe(1);
    expect(Number(edited[0]?.source_still_marked)).toBe(1);
    expect(Number(edited[0]?.party_cash_debit)).toBe(1);
    expect(Number(edited[0]?.roj_cash_debit)).toBe(1);

    await owner.$executeRawUnsafe(
      `UPDATE "REP_DETL" SET "ISU_ADJ"='Y'
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'`,
      TENANT,
      ISSUE_BOOK,
    );
    await expect(
      deleteKarigarRepairIssue(runtime, {
        scope: issueScope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).rejects.toThrow(/linked to a later workflow stage/);
    await owner.$executeRawUnsafe(
      `UPDATE "REP_DETL" SET "ISU_ADJ"='N'
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'`,
      TENANT,
      ISSUE_BOOK,
    );

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      deleteKarigarRepairIssue(runtime, {
        scope: issueScope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    const preserved = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) issue_rows,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"='00001' AND "ISU_ADJ"='Y') source_rows`,
      TENANT,
      ISSUE_BOOK,
      BOOK,
    )) as Array<Record<string, bigint>>;
    expect(Number(preserved[0]?.issue_rows)).toBe(1);
    expect(Number(preserved[0]?.source_rows)).toBe(1);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(
      deleteKarigarRepairIssue(runtime, {
        scope: issueScope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).resolves.toEqual({ reversed: true });
    const reversed = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) temp_rows,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"='00001' AND "ISU_ADJ"='N') source_released,
         (SELECT count(*) FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "VCH_NO"='00001' AND "BOOK_NAME"='KRREP ISSUE') delete_rows`,
      TENANT,
      ISSUE_BOOK,
      BOOK,
    )) as Array<Record<string, bigint>>;
    for (const key of ['headers', 'details', 'temp_rows', 'ledger_rows', 'roj_rows']) {
      expect(Number(reversed[0]?.[key])).toBe(0);
    }
    expect(Number(reversed[0]?.source_released)).toBe(1);
    expect(Number(reversed[0]?.delete_rows)).toBe(1);

    const reused = await saveKarigarRepairIssue(runtime, {
      scope: issueScope,
      acCode: 'KAR',
      vchDate: DAY,
      lines: [source],
    });
    expect(reused).toMatchObject({ voucherNo: '00001', headerVoucherNo: '00001' });
  }, 30_000);

  it('serializes concurrent KRREP ISSUE claims so one open customer row cannot be issued twice', async () => {
    const receipt = await saveCustomerRepairReceipt(runtime, {
      scope,
      acCode: 'CUST',
      vchDate: DAY,
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 8 }],
    });
    const input = {
      scope: issueScope,
      acCode: 'KAR',
      vchDate: DAY,
      lines: [{ coYear: YEAR, coBook: BOOK, voucherNo: receipt.voucherNo, srNo: 1 }],
    };
    const results = await Promise.allSettled([
      saveKarigarRepairIssue(runtime, input),
      saveKarigarRepairIssue(runtime, input),
    ]);
    expect(results.filter((result) => result.status === 'fulfilled')).toHaveLength(1);
    expect(results.filter((result) => result.status === 'rejected')).toHaveLength(1);
    const exact = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='Y') source_claimed`,
      TENANT,
      ISSUE_BOOK,
      BOOK,
    )) as Array<Record<string, bigint>>;
    expect(Number(exact[0]?.headers)).toBe(1);
    expect(Number(exact[0]?.details)).toBe(1);
    expect(Number(exact[0]?.source_claimed)).toBe(1);
  }, 30_000);

  const issueChain = async (): Promise<{
    coYear: string;
    coBook: string;
    voucherNo: string;
    srNo: number;
  }> => {
    const receipt = await saveCustomerRepairReceipt(runtime, {
      scope,
      acCode: 'CUST',
      vchDate: DAY,
      description: 'Customer resize',
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 10, otherWt: 1, touch: 91.6 }],
    });
    const issue = await saveKarigarRepairIssue(runtime, {
      scope: issueScope,
      acCode: 'KAR',
      vchDate: DAY,
      description: 'Issue ring to karigar',
      lines: [{ coYear: YEAR, coBook: BOOK, voucherNo: receipt.voucherNo, srNo: 1 }],
    });
    return { coYear: YEAR, coBook: ISSUE_BOOK, voucherNo: issue.voucherNo, srNo: 1 };
  };

  it('receives an open karigar issue with configured accounts, balanced ledger, and desktop Rojmel asymmetries', async () => {
    const source = await issueChain();

    const openBefore = await listOpenKarigarRepairIssueLines(runtime, receiptScope, 'KAR');
    expect(openBefore).toHaveLength(1);
    expect(openBefore[0]).toMatchObject({
      coBook: ISSUE_BOOK,
      voucherNo: '00001',
      srNo: 1,
      karigarCode: 'KAR',
      customerCode: 'CUST',
      customerName: 'Repair Customer',
      itCode: 'GOLD',
      netWt: 9,
    });
    expect(await listOpenKarigarRepairIssueLines(runtime, receiptScope, 'KAR2')).toEqual([]);

    const created = await saveKarigarRepairReceipt(runtime, {
      scope: receiptScope,
      acCode: 'KAR',
      vchDate: DAY,
      billNo: 'KR-101',
      description: 'Repaired ring received',
      discountPct: 10,
      taxCode: '03',
      chequeAmount: 20,
      chequeAccount: 'BANK',
      chequeNo: 'KRC1',
      cardAmount: 10,
      cardAccount: 'CARD',
      cashAmount: 15,
      kasarAmount: 1,
      mainUser: 'repair-user',
      lines: [
        {
          ...source,
          addWt: 10,
          touch: 90,
          wastagePct: 0,
          rate: 100,
          labourType: 'N',
          labourRate: 10,
          otherAmount: 5,
        },
      ],
    });
    expect(created).toMatchObject({
      voucherNo: '00001',
      headerVoucherNo: '00001',
      created: true,
      totals: {
        netAmount: 995,
        discountAmount: 9,
        taxAmount: 29.58,
        totalAmount: 1016,
        outstandingAmount: 970,
      },
    });
    expect(await listOpenKarigarRepairIssueLines(runtime, receiptScope, 'KAR')).toEqual([]);

    const loaded = await getKarigarRepairReceipt(runtime, receiptScope, created.voucherNo);
    expect(loaded).toMatchObject({
      voucherNo: '00001',
      acCode: 'KAR',
      taxCode: '03',
      discountPct: 10,
      kasarAmount: 1,
      lines: [
        {
          receiptSrNo: 1,
          coYear: YEAR,
          coBook: ISSUE_BOOK,
          voucherNo: '00001',
          srNo: 1,
          karigarCode: 'KAR',
          customerCode: 'CUST',
          customerName: 'Repair Customer',
          itCode: 'GOLD',
          addWt: 10,
          fineWt: 9,
          itemAmount: 900,
          labourAmount: 90,
          otherAmount: 5,
          netAmount: 995,
        },
      ],
    });

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) temp_rows,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT coalesce(sum("CR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_cr,
         (SELECT coalesce(sum("DR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_dr,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='KAR' AND "LD_CODE"='KRCTL' AND "CR_AMT"=1016) party_total,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='PURC' AND "LD_CODE"='KAR' AND "DR_AMT"=900) item_debit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='LBRAC' AND "LD_CODE"='KAR' AND "DR_AMT"=86.42) labour_debit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='GSTAC' AND "LD_CODE"='KAR' AND "DR_AMT"=29.58) tax_debit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='KASAR' AND "LD_CODE"='KAR' AND "CR_AMT"=1) kasar_credit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CASH' AND "LD_CODE"='KAR' AND "CR_AMT"=15) cash_credit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND coalesce("CHQ_NO",'')='') blank_ledger_cheque_no,
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "CHQ_NO"='KRC1' AND "ROF_AMT"=0 AND "KASAR_AMT"=1
            AND "TAX_CODE"='03' AND "TAX_PRC"=3 AND "CGST_TAX"=14.79 AND "SGST_TAX"=14.79
            AND "IGST_TAX"=0 AND "BILL_OS"=970) header_shape,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CASH') roj_cash_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='LBRAC' AND "CR_AMT"=1) roj_kasar_row3,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='KAR' AND "CR_AMT"=970) roj_outstanding,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='PURC' AND "DR_AMT"=900 AND "IT_CODE"='GOLD' AND "NET_AMT"=995) roj_item,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "BOOK_NAME"='KRREP RECEIPT' AND "REP_YRCD"=$3 AND "REP_DBCD"=$4
            AND "REP_NO"='00001' AND "REP_SRNO"=1 AND "REP_AC_CODE"='CUST' AND "REP_ADJ"='N'
            AND "ISU_YRCD"=$3 AND "ISU_DBCD"=$5 AND "ISU_NO"='00001' AND "ISU_SRNO"=1
            AND "ISU_AC_CODE"='KAR' AND "ISU_ADJ"='N'
            AND "IT_CODE"='GOLD' AND "IT_NAME"='Gold Ring' AND "RATE_TYPE"='G' AND "IT_TYPE"='G'
            AND "ADD_WT"=10 AND "ITM_NWT"=9 AND "ITM_FINE"=9 AND "ITM_AMT"=900
            AND "LBR_AMT"=90 AND "OTH_AMT"=5 AND "NET_AMT"=995) exact_detail,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$5
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='Y') source_marked`,
      TENANT,
      RECEIPT_BOOK,
      YEAR,
      BOOK,
      ISSUE_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(Number(persisted[0]?.headers)).toBe(1);
    expect(Number(persisted[0]?.details)).toBe(1);
    expect(Number(persisted[0]?.temp_rows)).toBe(1);
    expect(Number(persisted[0]?.ledger_rows)).toBe(12);
    expect(Number(persisted[0]?.roj_rows)).toBe(7);
    expect(Number(persisted[0]?.ledger_cr)).toBe(1062);
    expect(Number(persisted[0]?.ledger_dr)).toBe(1062);
    expect(Number(persisted[0]?.party_total)).toBe(1);
    expect(Number(persisted[0]?.item_debit)).toBe(1);
    expect(Number(persisted[0]?.labour_debit)).toBe(1);
    expect(Number(persisted[0]?.tax_debit)).toBe(1);
    expect(Number(persisted[0]?.kasar_credit)).toBe(1);
    expect(Number(persisted[0]?.cash_credit)).toBe(1);
    expect(Number(persisted[0]?.blank_ledger_cheque_no)).toBe(12);
    expect(Number(persisted[0]?.header_shape)).toBe(1);
    // Desktop Rep_KrRec_CustIsu_Rojmel books no cash row and puts kasar on BOOK_DETL row 3.
    expect(Number(persisted[0]?.roj_cash_rows)).toBe(0);
    expect(Number(persisted[0]?.roj_kasar_row3)).toBe(1);
    expect(Number(persisted[0]?.roj_outstanding)).toBe(1);
    expect(Number(persisted[0]?.roj_item)).toBe(1);
    expect(Number(persisted[0]?.exact_detail)).toBe(1);
    expect(Number(persisted[0]?.source_marked)).toBe(1);

    // Edit to a labour-only row: item amount becomes zero, so the fine and configured trade-fine
    // metal legs appear and the Rojmel fine row is emitted while less-fine stays absent.
    const updated = await saveKarigarRepairReceipt(runtime, {
      scope: receiptScope,
      vchNo: created.voucherNo,
      acCode: 'KAR',
      vchDate: DAY,
      description: 'Repaired ring received — revised',
      cashAmount: 5,
      mainUser: 'repair-user',
      lines: [
        {
          ...source,
          addWt: 10,
          touch: 90,
          wastagePct: 0,
          rate: 0,
          labourType: 'N',
          labourRate: 10,
        },
      ],
    });
    expect(updated).toMatchObject({
      voucherNo: '00001',
      headerVoucherNo: '00001',
      created: false,
      totals: { netAmount: 90, taxAmount: 0, totalAmount: 90, outstandingAmount: 85 },
    });
    const edited = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) temp_rows,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT coalesce(sum("CR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_cr,
         (SELECT coalesce(sum("DR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_dr,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='KAR' AND "LD_CODE"='PURC' AND "SIGN"='+' AND "FINE_WT"=9
            AND coalesce("CR_AMT",0)=0 AND coalesce("DR_AMT",0)=0) fine_leg,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='PURC' AND "LD_CODE"='KAR' AND "SIGN"='-' AND "FINE_WT"=9) trade_fine_leg,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "SIGN"='-' AND "AC_CODE"='KAR') less_fine_leg,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='KAR' AND "SIGN"='+' AND "ITM_FINE"=9) roj_fine_row,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='PURC' AND coalesce("DR_AMT",0)=0 AND "NET_AMT"=90) roj_zero_item_row,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='Y') source_still_marked`,
      TENANT,
      RECEIPT_BOOK,
      ISSUE_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(Number(edited[0]?.headers)).toBe(1);
    expect(Number(edited[0]?.details)).toBe(1);
    expect(Number(edited[0]?.temp_rows)).toBe(1);
    expect(Number(edited[0]?.ledger_rows)).toBe(6);
    expect(Number(edited[0]?.roj_rows)).toBe(4);
    expect(Number(edited[0]?.ledger_cr)).toBe(95);
    expect(Number(edited[0]?.ledger_dr)).toBe(95);
    expect(Number(edited[0]?.fine_leg)).toBe(1);
    expect(Number(edited[0]?.trade_fine_leg)).toBe(1);
    expect(Number(edited[0]?.less_fine_leg)).toBe(0);
    expect(Number(edited[0]?.roj_fine_row)).toBe(1);
    expect(Number(edited[0]?.roj_zero_item_row)).toBe(1);
    expect(Number(edited[0]?.source_still_marked)).toBe(1);

    // A downstream CUSTREP ISSUE link (ISU_ADJ on the receipt row) blocks reversal.
    await owner.$executeRawUnsafe(
      `UPDATE "REP_DETL" SET "ISU_ADJ"='Y' WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'`,
      TENANT,
      RECEIPT_BOOK,
    );
    await expect(
      deleteKarigarRepairReceipt(runtime, {
        scope: receiptScope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).rejects.toThrow(/linked to a later workflow stage/);
    await owner.$executeRawUnsafe(
      `UPDATE "REP_DETL" SET "ISU_ADJ"='N' WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'`,
      TENANT,
      RECEIPT_BOOK,
    );

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      deleteKarigarRepairReceipt(runtime, {
        scope: receiptScope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );

    await expect(
      deleteKarigarRepairReceipt(runtime, {
        scope: receiptScope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).resolves.toEqual({ reversed: true });
    const reversed = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) temp_rows,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='N') source_released,
         (SELECT count(*) FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "VCH_NO"='00001' AND "BOOK_NAME"='KRREP RECEIPT') delete_rows`,
      TENANT,
      RECEIPT_BOOK,
      ISSUE_BOOK,
    )) as Array<Record<string, unknown>>;
    for (const key of ['headers', 'details', 'temp_rows', 'ledger_rows', 'roj_rows']) {
      expect(Number(reversed[0]?.[key])).toBe(0);
    }
    expect(Number(reversed[0]?.source_released)).toBe(1);
    expect(Number(reversed[0]?.delete_rows)).toBe(1);

    const reused = await saveKarigarRepairReceipt(runtime, {
      scope: receiptScope,
      acCode: 'KAR',
      vchDate: DAY,
      lines: [{ ...source, addWt: 10, touch: 90, labourType: 'N', labourRate: 10 }],
    });
    expect(reused).toMatchObject({ voucherNo: '00001', headerVoucherNo: '00001' });
  }, 40_000);

  it('rejects another karigar and serializes concurrent KRREP RECEIPT claims', async () => {
    const source = await issueChain();
    await expect(
      saveKarigarRepairReceipt(runtime, {
        scope: receiptScope,
        acCode: 'KAR2',
        vchDate: DAY,
        lines: [{ ...source, addWt: 5, touch: 90, labourType: 'N', labourRate: 10 }],
      }),
    ).rejects.toThrow(/belongs to another karigar/);

    const input = {
      scope: receiptScope,
      acCode: 'KAR',
      vchDate: DAY,
      lines: [{ ...source, addWt: 5, touch: 90, labourType: 'N', labourRate: 10 }],
    };
    const results = await Promise.allSettled([
      saveKarigarRepairReceipt(runtime, input),
      saveKarigarRepairReceipt(runtime, input),
    ]);
    expect(results.filter((result) => result.status === 'fulfilled')).toHaveLength(1);
    expect(results.filter((result) => result.status === 'rejected')).toHaveLength(1);
    const exact = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='Y') source_claimed`,
      TENANT,
      RECEIPT_BOOK,
      ISSUE_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(Number(exact[0]?.headers)).toBe(1);
    expect(Number(exact[0]?.details)).toBe(1);
    expect(Number(exact[0]?.source_claimed)).toBe(1);

    await expect(
      saveKarigarRepairReceipt(runtime, {
        scope: receiptScope,
        acCode: 'KAR',
        vchDate: DAY,
        lines: [{ ...source, addWt: 5, touch: 90, labourType: 'N', labourRate: 10 }],
      }),
    ).rejects.toThrow(/already received/);
  }, 40_000);

  const karigarReceiptChain = async (): Promise<{
    coYear: string;
    coBook: string;
    voucherNo: string;
    srNo: number;
  }> => {
    const source = await issueChain();
    await saveKarigarRepairReceipt(runtime, {
      scope: receiptScope,
      acCode: 'KAR',
      vchDate: DAY,
      lines: [
        {
          ...source,
          addWt: 10,
          touch: 90,
          wastagePct: 0,
          rate: 0,
          labourType: 'N',
          labourRate: 10,
        },
      ],
    });
    return { coYear: YEAR, coBook: BOOK, voucherNo: '00001', srNo: 1 };
  };

  it('delivers a karigar-completed repair with mirrored ledger directions and reopens both sources on reversal', async () => {
    const source = await karigarReceiptChain();

    const openBefore = await listOpenCustomerRepairDeliveries(runtime, deliveryScope, 'CUST');
    expect(openBefore).toHaveLength(1);
    expect(openBefore[0]).toMatchObject({
      coBook: BOOK,
      voucherNo: '00001',
      srNo: 1,
      customerCode: 'CUST',
      karigarReceiptNo: '00001',
      karigarCode: 'KAR',
      itCode: 'GOLD',
      addWt: 10,
      labourAmount: 90,
    });
    expect(await listOpenCustomerRepairDeliveries(runtime, deliveryScope, 'KAR')).toEqual([]);

    const created = await saveCustomerRepairIssue(runtime, {
      scope: deliveryScope,
      acCode: 'CUST',
      vchDate: DAY,
      billNo: 'CI-101',
      description: 'Repaired ring delivered',
      taxCode: '03',
      cashAmount: 500,
      mainUser: 'repair-user',
      lines: [{ ...source, addWt: 10, touch: 90, wastagePct: 0, rate: 100 }],
    });
    expect(created).toMatchObject({
      voucherNo: '00001',
      headerVoucherNo: '00001',
      created: true,
      totals: {
        netAmount: 1090,
        discountAmount: 0,
        taxAmount: 32.7,
        totalAmount: 1123,
        outstandingAmount: 623,
      },
    });
    expect(await listOpenCustomerRepairDeliveries(runtime, deliveryScope, 'CUST')).toEqual([]);

    const loaded = await getCustomerRepairIssue(runtime, deliveryScope, created.voucherNo);
    expect(loaded).toMatchObject({
      voucherNo: '00001',
      acCode: 'CUST',
      taxCode: '03',
      lines: [
        {
          issueSrNo: 1,
          coBook: BOOK,
          voucherNo: '00001',
          srNo: 1,
          customerCode: 'CUST',
          karigarReceiptNo: '00001',
          karigarCode: 'KAR',
          addWt: 10,
          itemAmount: 1000,
          labourAmount: 90,
          netAmount: 1090,
        },
      ],
    });

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT coalesce(sum("CR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_cr,
         (SELECT coalesce(sum("DR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_dr,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CUST' AND "LD_CODE"='CSCTL' AND "DR_AMT"=1123) party_total_debit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='SALEAC' AND "LD_CODE"='CUST' AND "CR_AMT"=1000) sale_credit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='PURC') purchase_rows,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='LBRAC' AND "CR_AMT"=90.3) labour_credit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='GSTAC' AND "CR_AMT"=32.7) tax_credit,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CASH' AND "LD_CODE"='CUST' AND "DR_AMT"=500) cash_debit,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CUST' AND "DR_AMT"=623) roj_outstanding_debit,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CASH') roj_cash_rows,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "BOOK_NAME"='CUSTREP ISSUE'
            AND "REP_YRCD"=$3 AND "REP_DBCD"=$4 AND "REP_NO"='00001' AND "REP_SRNO"=1
            AND "REP_AC_CODE"='CUST' AND "REP_ADJ"='N'
            AND "ISU_YRCD"=$3 AND "ISU_DBCD"=$5 AND "ISU_NO"='00001' AND "ISU_SRNO"=1
            AND "ISU_AC_CODE"='KAR' AND "ISU_ADJ"='N'
            AND "ADD_WT"=10 AND "ITM_FINE"=9 AND "ITM_AMT"=1000
            AND "LBR_AMT"=90 AND "NET_AMT"=1090) exact_detail,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$4
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "REP_ADJ"='Y' AND "ISU_ADJ"='Y') receipt_marked,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$5
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='Y') karigar_marked`,
      TENANT,
      DELIVERY_BOOK,
      YEAR,
      BOOK,
      RECEIPT_BOOK,
    )) as Array<Record<string, unknown>>;
    expect(Number(persisted[0]?.headers)).toBe(1);
    expect(Number(persisted[0]?.details)).toBe(1);
    expect(Number(persisted[0]?.ledger_rows)).toBe(6);
    expect(Number(persisted[0]?.roj_rows)).toBe(4);
    expect(Number(persisted[0]?.ledger_cr)).toBe(1623);
    expect(Number(persisted[0]?.ledger_dr)).toBe(1623);
    expect(Number(persisted[0]?.party_total_debit)).toBe(1);
    expect(Number(persisted[0]?.sale_credit)).toBe(1);
    // The item leg uses GROUP_MAST.SALE_AC on this stage; PURC_AC appears only on metal legs.
    expect(Number(persisted[0]?.purchase_rows)).toBe(0);
    expect(Number(persisted[0]?.labour_credit)).toBe(1);
    expect(Number(persisted[0]?.tax_credit)).toBe(1);
    expect(Number(persisted[0]?.cash_debit)).toBe(1);
    expect(Number(persisted[0]?.roj_outstanding_debit)).toBe(1);
    expect(Number(persisted[0]?.roj_cash_rows)).toBe(0);
    expect(Number(persisted[0]?.exact_detail)).toBe(1);
    expect(Number(persisted[0]?.receipt_marked)).toBe(1);
    expect(Number(persisted[0]?.karigar_marked)).toBe(1);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      deleteCustomerRepairIssue(runtime, {
        scope: deliveryScope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );

    await expect(
      deleteCustomerRepairIssue(runtime, {
        scope: deliveryScope,
        vchNo: created.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).resolves.toEqual({ reversed: true });
    const reversed = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) headers,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "REP_ADJ"='N' AND "ISU_ADJ"='N') receipt_released,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$4
            AND "VCH_NO"='00001' AND "SR_NO"=1 AND "ISU_ADJ"='N') karigar_released,
         (SELECT count(*) FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "VCH_NO"='00001' AND "BOOK_NAME"='CUSTREP ISSUE') delete_rows`,
      TENANT,
      DELIVERY_BOOK,
      BOOK,
      RECEIPT_BOOK,
    )) as Array<Record<string, unknown>>;
    for (const key of ['headers', 'details', 'ledger_rows', 'roj_rows']) {
      expect(Number(reversed[0]?.[key])).toBe(0);
    }
    // Desktop only resets REP_ADJ here; the web also clears ISU_ADJ so the repair fully reopens.
    expect(Number(reversed[0]?.receipt_released)).toBe(1);
    expect(Number(reversed[0]?.karigar_released)).toBe(1);
    expect(Number(reversed[0]?.delete_rows)).toBe(1);
    expect(await listOpenCustomerRepairDeliveries(runtime, deliveryScope, 'CUST')).toHaveLength(1);
  }, 40_000);

  it('delivers open customer repairs without a karigar leg, posts zero-money metal legs, and rejects re-delivery', async () => {
    const first = await saveCustomerRepairReceipt(runtime, {
      scope,
      acCode: 'CUST',
      vchDate: DAY,
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 10, otherWt: 1, touch: 90 }],
    });
    const second = await saveCustomerRepairReceipt(runtime, {
      scope,
      acCode: 'CUST',
      vchDate: DAY,
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 8, touch: 90 }],
    });
    expect(await listOpenCustomerRepairDeliveries(runtime, deliveryScope, 'CUST')).toHaveLength(2);

    const created = await saveCustomerRepairIssue(runtime, {
      scope: deliveryScope,
      acCode: 'CUST',
      vchDate: DAY,
      mainUser: 'repair-user',
      lines: [
        {
          coYear: YEAR,
          coBook: BOOK,
          voucherNo: first.voucherNo,
          srNo: 1,
          addWt: 5,
          touch: 90,
          wastagePct: 0,
          rate: 100,
        },
        {
          coYear: YEAR,
          coBook: BOOK,
          voucherNo: second.voucherNo,
          srNo: 1,
          addWt: 5,
          touch: 90,
          wastagePct: 0,
          rate: 0,
          lessWt: 2,
          lessTouch: 50,
        },
      ],
    });
    expect(created.totals).toMatchObject({
      netAmount: 500,
      taxAmount: 0,
      totalAmount: 500,
      outstandingAmount: 500,
    });

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2) details,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_rows,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) roj_rows,
         (SELECT coalesce(sum("CR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_cr,
         (SELECT coalesce(sum("DR_AMT"),0) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger_dr,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CUST' AND "LD_CODE"='PURC' AND "SIGN"='-' AND "FINE_WT"=4.5
            AND coalesce("CR_AMT",0)=0 AND coalesce("DR_AMT",0)=0) issue_fine_leg,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "AC_CODE"='CUST' AND "LD_CODE"='PURC' AND "SIGN"='+' AND "FINE_WT"=1) less_fine_leg,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "SIGN"='+' AND "FINE_WT"=4.5) trade_fine_leg,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "SIGN"='-' AND "ITM_FINE"=4.5) roj_fine_row,
         (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "SIGN"='-' AND "ITM_FINE"=1 AND "ITM_TOUCH"=50) roj_less_fine_row,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "REP_ADJ"='Y' AND "ISU_ADJ"='Y') receipts_marked,
         (SELECT count(*) FROM "REP_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND coalesce("ISU_NO",'')='') no_karigar_link`,
      TENANT,
      DELIVERY_BOOK,
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(Number(persisted[0]?.details)).toBe(2);
    expect(Number(persisted[0]?.ledger_rows)).toBe(4);
    expect(Number(persisted[0]?.roj_rows)).toBe(4);
    expect(Number(persisted[0]?.ledger_cr)).toBe(500);
    expect(Number(persisted[0]?.ledger_dr)).toBe(500);
    expect(Number(persisted[0]?.issue_fine_leg)).toBe(1);
    expect(Number(persisted[0]?.less_fine_leg)).toBe(1);
    // CUSTREP ISSUE has no trade-fine mirror row; that leg belongs to KRREP RECEIPT only.
    expect(Number(persisted[0]?.trade_fine_leg)).toBe(0);
    expect(Number(persisted[0]?.roj_fine_row)).toBe(1);
    expect(Number(persisted[0]?.roj_less_fine_row)).toBe(1);
    expect(Number(persisted[0]?.receipts_marked)).toBe(2);
    expect(Number(persisted[0]?.no_karigar_link)).toBe(2);

    await expect(
      saveCustomerRepairIssue(runtime, {
        scope: deliveryScope,
        acCode: 'CUST',
        vchDate: DAY,
        lines: [
          {
            coYear: YEAR,
            coBook: BOOK,
            voucherNo: first.voucherNo,
            srNo: 1,
            addWt: 5,
            touch: 90,
            rate: 100,
          },
        ],
      }),
    ).rejects.toThrow(/already delivered/);
  }, 40_000);

  it('stores one repair-line image per desktop image key, replaces it, and deletes it', async () => {
    const receipt = await saveCustomerRepairReceipt(runtime, {
      scope,
      acCode: 'CUST',
      vchDate: DAY,
      lines: [
        { itCode: 'GOLD', pcs: 1, grossWt: 10, otherWt: 1, touch: 90 },
        { itCode: 'GOLD', pcs: 1, grossWt: 5, description: 'Second repair' },
      ],
    });
    const key = { coBook: BOOK, vchNo: receipt.voucherNo, srNo: 1 };
    const jpeg = Buffer.concat([Buffer.from([0xff, 0xd8, 0xff]), Buffer.alloc(16, 5)]);
    const png = Buffer.concat([
      Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]),
      Buffer.alloc(32, 9),
    ]);

    expect(await getRepairImage(runtime, scope, key)).toBeNull();
    const saved = await saveRepairImage(runtime, {
      scope,
      key,
      data: jpeg.toString('base64'),
      mainUser: 'repair-user',
    });
    expect(saved).toMatchObject({
      coYear: YEAR,
      coBook: BOOK,
      voucherNo: '00001',
      srNo: 1,
      imageNo: `01${LC}2024${BOOK}000011`,
      mimeType: 'image/jpeg',
      size: jpeg.length,
      replaced: false,
    });

    const loaded = await getRepairImage(runtime, scope, key);
    expect(loaded?.mimeType).toBe('image/jpeg');
    expect(loaded?.imageType).toBe('ReparingImage');
    expect(loaded?.data.equals(jpeg)).toBe(true);
    expect(await getRepairImage(runtime, { ...scope, tenantId: 'other-tenant' }, key)).toBeNull();

    const replaced = await saveRepairImage(runtime, {
      scope,
      key,
      data: png.toString('base64'),
      mimeType: 'image/png',
      mainUser: 'repair-user',
    });
    expect(replaced).toMatchObject({ replaced: true, mimeType: 'image/png', size: png.length });
    const rowCount = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "REP_IMAGE" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(Number(rowCount[0]?.n)).toBe(1);

    await saveRepairImage(runtime, {
      scope,
      key: { coBook: BOOK, vchNo: receipt.voucherNo, srNo: 2 },
      data: jpeg.toString('base64'),
    });
    expect(
      await listRepairImageKeys(runtime, scope, { coBook: BOOK, vchNo: receipt.voucherNo }),
    ).toMatchObject([
      { srNo: 1, mimeType: 'image/png' },
      { srNo: 2, mimeType: 'image/jpeg' },
    ]);

    await expect(
      saveRepairImage(runtime, {
        scope,
        key: { coBook: BOOK, vchNo: receipt.voucherNo, srNo: 9 },
        data: jpeg.toString('base64'),
      }),
    ).rejects.toThrow(/repair line not found/);
    await expect(
      saveRepairImage(runtime, {
        scope,
        key,
        data: Buffer.from('plain text').toString('base64'),
      }),
    ).rejects.toThrow(/JPEG or PNG/);

    expect(await deleteRepairImage(runtime, { scope, key })).toEqual({ deleted: true });
    expect(await deleteRepairImage(runtime, { scope, key })).toEqual({ deleted: false });
    expect(await getRepairImage(runtime, scope, key)).toBeNull();
    expect(
      await listRepairImageKeys(runtime, scope, { coBook: BOOK, vchNo: receipt.voucherNo }),
    ).toHaveLength(1);

    // Match the desktop's unmanaged-file lifecycle: deleting a voucher does not erase its image.
    await expect(
      deleteCustomerRepairReceipt(runtime, {
        scope,
        vchNo: receipt.voucherNo,
        deleteUser: 'repair-user',
      }),
    ).resolves.toEqual({ reversed: true });
    const surviving = await getRepairImage(runtime, scope, {
      coBook: BOOK,
      vchNo: receipt.voucherNo,
      srNo: 2,
    });
    expect(surviving?.data.equals(jpeg)).toBe(true);
  }, 30_000);

  it('serializes REP_DATA and TEMP_BOOK_DATA MAX+1 numbering under concurrent restricted writers', async () => {
    const results = await Promise.all(
      Array.from({ length: 4 }, (_, index) =>
        saveCustomerRepairReceipt(runtime, {
          scope,
          acCode: 'CUST',
          vchDate: DAY,
          lines: [{ itCode: 'GOLD', pcs: 1, description: `Repair ${index + 1}` }],
        }),
      ),
    );
    expect(results.map((row) => row.vchNo).sort((a, b) => a - b)).toEqual([1, 2, 3, 4]);
    expect(results.map((row) => Number(row.headerVoucherNo)).sort((a, b) => a - b)).toEqual([
      1, 2, 3, 4,
    ]);
  }, 30_000);
});
