import { lineTotalDesktop } from '@datacare/core';
import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import { createSale, deleteSale, editSale, getSale } from '../src/modules/sales/sales.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';
import { rojmel } from '../src/modules/reports/rojmelReport.js';
import { footprintOf, ledgerLegs, voucherTables } from './support/footprint.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'sales-lifecycle-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'SAL';
const DAY = '2024-04-10';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

const saleInput = (overrides: Record<string, unknown> = {}) => ({
  scope,
  mainUser: 'original-user',
  acCode: 'CUST',
  acName: 'Lifecycle Customer',
  vchDate: DAY,
  taxRatePct: 3,
  interState: false,
  ...overrides,
});

const firstLines = [
  {
    itCode: 'GOLD',
    tagNo: 'TAG001',
    vchSrno: 1,
    pcs: 1,
    grossWt: 10,
    netWt: 10,
    touch: 91.6,
    metalAmount: 1000,
  },
  {
    itCode: 'LOOSE',
    pcs: 1,
    grossWt: 2,
    netWt: 2,
    touch: 90,
    metalAmount: 200,
  },
];

const SALE_HEADER_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'AC_CODE',
  'VCH_DATE',
  'BILL_NO',
  'HD_VCH_NO',
  'AC_NAME',
  'NET_AMT',
  'DISC_PRC',
  'DISC_AMT',
  'TAX_CODE',
  'TAX_PRC',
  'TAX_AMT',
  'TCS_CODE',
  'TCS_PRC',
  'TCS_AMT',
  'ROF_AMT',
  'TDS_CODE',
  'TDS_PRC',
  'TDS_AMT',
  'LBR_AMT',
  'OTH_AMT',
  'TOT_AMT',
  'CHQ_AMT',
  'CARD_AMT',
  'CARD_COM_AMT',
  'ADV_AMT',
  'CRNT_ADJ_AMT',
  'OLD_GL_AMT',
  'OLD_SL_AMT',
  'SCHM_AMT',
  'CASH_AMT',
  'UPI_AMT',
  'CASH_PAID',
  'KASAR_AMT',
  'BILL_OS',
  'OLD_GL',
  'OLD_SL',
  'CARD_AC',
  'BANK_AC',
  'CHQ_NO',
  'SCHM_AC',
  'POINT_VAL',
  'BANK_NAME',
  'CARD_ADJ',
  'CR_DAYS',
  'ADD1',
  'ADD2',
  'ADD3',
  'CITY',
  'MOBILE',
  'AC_GST_TYPE',
  'IGST_TAX',
  'SGST_TAX',
  'CGST_TAX',
  'HM_AMT',
  'HM_TAX_CODE',
  'HM_TAX_PRC',
  'HM_TAX_AMT',
  'RTN_TOT_AMT',
  'RTN_CHQ_AMT',
  'RTN_CARD_AMT',
  'RTN_CASH_AMT',
  'RTN_KASAR_AMT',
  'RTN_BILL_OS',
  'ISU_NO',
  'ISU_LC_CODE',
  'ISU_YRCD',
  'ISU_DBCD',
  'EMP_CODE',
  'VCH_DESC',
  'ORNA_ISU',
  'VCH_TIME',
  'DATA_TRFR',
  'MAIN_USER',
  'USER_UPDATE',
  'USER_DELETE',
  'MOB_ENTRY_SAVE',
  'RATE_UNFIX',
  'OZ_RATE',
  'OZ_CONV',
  'FX_RATE',
  'FX_CODE',
  'MTL_RATE',
] as const;

const SALE_DETAIL_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'VCH_DATE',
  'HD_VCH_NO',
  'AC_CODE',
  'VCH_TYPE',
  'INOUT_TYPE',
  'ENTRY_TYPE',
  'BOOK_NAME',
  'SR_NO',
  'OLD_SRNO',
  'IT_CODE',
  'TAG_NO',
  'TBL_CODE',
  'ORD_NO',
  'DESIGN_NO',
  'ITM_STYLE',
  'ITM_SIZE',
  'HM_ID',
  'BAG_WT',
  'ITM_PCS',
  'ITM_GWT',
  'TAG_GWT',
  'ITM_OTH_WT',
  'ITM_NWT',
  'TAG_NWT',
  'ITM_GHT_PRC',
  'ITM_GHT_WT',
  'ITM_TOUCH',
  'ITM_WEST_PRC',
  'ITM_FINE',
  'LBR_PRC',
  'LBR_TYPE',
  'LBR_RATE',
  'LBR_AMT',
  'DISC_PRC',
  'DISC_AMT',
  'GHT_AMT',
  'OTH_AMT',
  'RATE_WITH',
  'ITM_RATE',
  'ITM_AMT',
  'ITM_MRP',
  'TOT_AMT',
  'TAX_PRC',
  'NET_AMT',
  'HM_AMT',
  'KR_NET_WT',
  'KR_TOUCH',
  'KR_WEST_PRC',
  'KR_FINE',
  'TAG_COST',
  'KR_NAME',
  'RATE_TYPE',
  'IT_TYPE',
  'PR_CODE',
  'ITM_REMARK',
  'VCH_SRNO',
  'ISU_NO',
  'ISU_LC_CODE',
  'ISU_YRCD',
  'ISU_DBCD',
  'ISU_SRNO',
  'HM_ID2',
  'HM_ID3',
  'HM_ID4',
  'HM_ID_WT',
  'HM_ID2_WT',
  'HM_ID3_WT',
  'HM_ID4_WT',
  'ORD_LC_CODE',
  'ORD_YRCD',
  'ORD_DBCD',
  'ORD_SRNO',
  'ORD_TAG_STK_ADD',
  'DESIGN_IMG_ID',
  'ITM_LOT',
  'VCH_TIME',
  'EMP_CODE',
  'MAIN_USER',
] as const;

const SALE_OLD_METAL_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'VCH_DATE',
  'HD_VCH_NO',
  'AC_CODE',
  'VCH_TYPE',
  'INOUT_TYPE',
  'ENTRY_TYPE',
  'BOOK_NAME',
  'SR_NO',
  'IT_CODE',
  'IT_TYPE',
  'IT_DESC',
  'ITM_PCS',
  'ITM_GWT',
  'ITM_OTH_WT',
  'ITM_NWT',
  'ITM_TOUCH',
  'ITM_FINE',
  'CON_PRC',
  'CON_WT',
  'ITM_RATE',
  'ITM_RATE_TYPE',
  'NET_AMT',
  'VCH_TIME',
  'MAIN_USER',
  'HM_ID_WT',
  'HM_ID2_WT',
  'HM_ID3_WT',
  'HM_ID4_WT',
  'ITM_OTH',
] as const;

const SALE_BILL_OS_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'SR_NO',
  'VCH_DATE',
  'HD_VCH_NO',
  'AC_CODE',
  'VCH_TYPE',
  'INOUT_TYPE',
  'ENTRY_TYPE',
  'BOOK_NAME',
  'BILL_AMT',
  'OLD_ADJ_AMT',
  'REC_AMT',
  'KASAR_AMT',
  'BILL_GOLD',
  'OLD_ADJ_GOLD',
  'REC_GOLD',
  'KASAR_GOLD',
  'BILL_SILVER',
  'OLD_ADJ_SILVER',
  'REC_SILVER',
  'KASAR_SILVER',
  'BILL_LC',
  'BILL_YRCD',
  'BILL_DBCD',
  'BILL_NO',
  'BILL_HD_VCH_NO',
  'BILL_SRNO',
  'VCH_TIME',
  'MAIN_USER',
  'DATA_TRFR',
  'DATA_TYPE',
] as const;

const expectPersistedColumns = (row: Record<string, unknown>, columns: readonly string[]): void => {
  expect(columns.filter((column) => !(column in row))).toEqual([]);
  expect(columns.filter((column) => row[column] == null)).toEqual([]);
};

const replacementLines = [
  {
    itCode: 'GOLD',
    tagNo: 'TAG001',
    vchSrno: 1,
    pcs: 1,
    grossWt: 10,
    netWt: 9.5,
    touch: 92,
    metalAmount: 1100,
  },
  {
    itCode: 'LOOSE',
    pcs: 2,
    grossWt: 3,
    netWt: 3,
    touch: 88,
    metalAmount: 300,
  },
];

databaseDescribe('database-backed sales voucher lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'SL_ORD_ADJ',
      'AD_ADJ',
      'REMARK_DATA',
      'LOT_DETL',
      'ROJ_MEL_DATA',
      'CRNT_DATA',
      'DM_DATA',
      'CARD_DATA',
      'UPI_DATA',
      'POINT_DATA',
      'BILL_OS_DATA',
      'TAX_DATA',
      'AC_DATA',
      'SL_IDTL',
      'SL_PR_DETL',
      'SL_DETL',
      'SL_DATA',
      'TEMP_BOOK_DATA',
      'MAIN_STOCK',
      'TAG_STOCK',
      'BAR_DETL',
      'BOOK_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'GROUP_MAST',
      'TAX_MAST',
      'AC_MAST',
      'CO_SET_NEW',
      'CO_SET',
      // Seeded by the bill-profit test; every table a DB test writes must be cleaned or a rerun conflicts.
      'RATE_MAST',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'CUST','Lifecycle Customer','L')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'10',1,'GST','GST 3%',3,'GSTLED')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC")
       VALUES ($1,$2,'G01','Gold','SALEAC')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold','G','G01'),($1,$2,'LOOSE','Loose Gold','G','G01')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,'Configured Sales Book','CSB','SALES','O','Y','SL_DATA')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,1,'CTRL','SALES','O'),
              ($1,$2,$3,$4,2,'CASH','SALES','O'),
              ($1,$2,$3,$4,3,'ROUND','SALES','O')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE")
       VALUES ($1,$2,$3,$4,$5,'00007',$6::date,'CUST')`,
      TENANT,
      CO,
      LC,
      YEAR,
      BOOK,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
       VALUES ($1,$2,$3,$4,'00040','Configured Sales Book')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BAR_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","EMP_ISU")
       VALUES ($1,$2,$3,$4,'TOP','00001',1,$5::date,'GOLD','TAG001',1,1,10,10,9.16,'N')`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,$2,$3,$4,'TOP','00001',1,$5::date,'GOLD','TAG001',1,'+',1,10,10)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
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

  it('persists the complete desktop Sales-family column sets under the restricted role', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "CARD_COM_ADJ"='Y' WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","SL_TDS_TAX","OS_BILL_ORNA_ISU")
       VALUES ($1,$2,'Y','N')`,
      TENANT,
      CO,
    );
    const created = await createSale(
      runtime,
      saleInput({
        billNo: 'REF-8',
        discountAmount: 10,
        discountPct: 1.25,
        tcsPct: 0.1,
        tcsCode: 'TC',
        tdsCode: 'TD',
        tdsPct: 1,
        tdsAmount: 12.34,
        cashAmt: 100,
        cardAmt: 50,
        upiAmt: 25,
        chequeAmt: 20,
        bankAc: 'BANK',
        cardAc: 'CARD',
        chequeNo: 'CHQ-8',
        bankName: 'Lifecycle Bank',
        cardCommissionAmount: 1.5,
        cashPaid: 2,
        currentAdjustmentAmount: 3,
        schemeAc: 'SCHEME',
        schemeAmount: 4,
        pointValue: 5,
        crDays: 30,
        empCode: 'E01',
        address1: 'Address 1',
        address2: 'Address 2',
        address3: 'Address 3',
        city: 'Surat',
        mobile: '9000000000',
        issueNo: 'ISU-8',
        issueYear: YEAR,
        issueBook: 'APR',
        description: 'full column sale',
        ornamentIssued: false,
        oldGold: [
          {
            metal: 'G',
            itCode: 'OG',
            description: 'Old Gold',
            pcs: 2,
            grossWt: 4.5,
            otherWt: 0.2,
            netWt: 4.3,
            touch: 90,
            conversionPct: 2,
            conversionWt: 0.1,
            rate: 100,
            rateType: 'F',
            amount: 387,
          },
        ],
      }),
      [
        {
          itCode: 'LOOSE',
          pcs: 2,
          grossWt: 5,
          netWt: 4.8,
          touch: 91,
          ghtWt: 0.1,
          westPct: 1,
          rate: 100,
          metalAmount: 500,
          labourType: 'per_gram',
          labourRate: 10,
          labourPct: 2,
          otherAmount: 7,
          huid: 'H1',
          designNo: 'D1',
          itmSize: 'M',
          lessWt: 0.2,
          tblCode: '001',
          mrp: 600,
          bagWt: 0.3,
          tagGrossWt: 5.1,
          tagNetWt: 4.9,
          ghtPct: 2,
          style: 'Classic',
          itemLot: 'LOT-8',
          remark: 'detail remark',
          discountPct: 1,
          discountAmount: 5,
          ghatAmount: 6,
          rateWith: 'N',
          rateType: 'F',
          tagCost: 450,
          karigarNetWt: 4.7,
          karigarTouch: 90,
          karigarWestPct: 1.5,
          karigarFine: 4.3,
          karigarName: 'K01',
          employeeCode: 'E02',
          prCode: 'P1',
          orderTagStockAdd: 'Y',
          designImageId: 'IMG-8',
          hallmarkId2: 'H2',
          hallmarkId3: 'H3',
          hallmarkId4: 'H4',
          hallmarkIdWt: 0.01,
          hallmarkId2Wt: 0.02,
          hallmarkId3Wt: 0.03,
          hallmarkId4Wt: 0.04,
          ordNo: 'ORD-8',
          ordYrcd: YEAR,
          ordDbcd: 'SOR',
          ordSrno: 2,
          isuNo: 'APR-8',
          isuYrcd: YEAR,
          isuDbcd: 'APR',
          isuSrno: 3,
        },
      ],
    );
    expect(created.vchNo).toBe(8);

    const queryOne = async (table: string): Promise<Record<string, unknown>> => {
      const rows = (await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t) AS row FROM "${table}" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008' ORDER BY "SR_NO" NULLS FIRST LIMIT 1`,
        TENANT,
        BOOK,
      )) as Array<{ row: Record<string, unknown> }>;
      expect(rows).toHaveLength(1);
      return rows[0]!.row;
    };
    const headerRows = (await owner.$queryRawUnsafe(
      `SELECT to_jsonb(t) AS row FROM "SL_DATA" t
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008'`,
      TENANT,
      BOOK,
    )) as Array<{ row: Record<string, unknown> }>;
    expect(headerRows).toHaveLength(1);
    const header = headerRows[0]!.row;
    const detail = await queryOne('SL_DETL');
    const oldMetal = await queryOne('SL_PR_DETL');
    const billOs = await queryOne('BILL_OS_DATA');

    expectPersistedColumns(header, SALE_HEADER_COLUMNS);
    expectPersistedColumns(detail, SALE_DETAIL_COLUMNS);
    expectPersistedColumns(oldMetal, SALE_OLD_METAL_COLUMNS);
    expectPersistedColumns(billOs, SALE_BILL_OS_COLUMNS);
    expect(SALE_HEADER_COLUMNS).toHaveLength(87);
    expect(SALE_DETAIL_COLUMNS).toHaveLength(83);
    expect(SALE_OLD_METAL_COLUMNS).toHaveLength(34);
    expect(SALE_BILL_OS_COLUMNS).toHaveLength(35);

    expect(header).toMatchObject({
      ADD1: 'Address 1',
      ADD2: 'Address 2',
      ADD3: 'Address 3',
      CITY: 'Surat',
      MOBILE: '9000000000',
      DISC_PRC: 1.25,
      TCS_CODE: 'TC',
      TDS_CODE: 'TD',
      TDS_PRC: 1,
      TDS_AMT: 12.34,
      BANK_AC: 'BANK',
      CARD_AC: 'CARD',
      CHQ_NO: 'CHQ-8',
      BANK_NAME: 'Lifecycle Bank',
      CARD_COM_AMT: 1.5,
      CASH_PAID: 2,
      CRNT_ADJ_AMT: 3,
      SCHM_AC: 'SCHEME',
      SCHM_AMT: 4,
      POINT_VAL: 5,
      CARD_ADJ: 'Y',
      ORNA_ISU: 'N',
      DATA_TRFR: 'N',
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
      MOB_ENTRY_SAVE: 'Y',
      OZ_RATE: 0,
      OZ_CONV: 0,
      FX_RATE: 0,
      FX_CODE: '',
      MTL_RATE: 0,
      VCH_DESC: 'full column sale',
    });
    expect(detail).toMatchObject({
      BAG_WT: 0.3,
      TAG_GWT: 5.1,
      TAG_NWT: 4.9,
      ITM_GHT_PRC: 2,
      ITM_STYLE: 'Classic',
      ITM_LOT: 'LOT-8',
      ITM_REMARK: 'detail remark',
      DISC_PRC: 1,
      DISC_AMT: 5,
      GHT_AMT: 6,
      RATE_WITH: 'N',
      RATE_TYPE: 'F',
      TAG_COST: 450,
      KR_NAME: 'K01',
      PR_CODE: 'P1',
      ORD_LC_CODE: LC,
      ISU_LC_CODE: LC,
      ORD_TAG_STK_ADD: 'Y',
      DESIGN_IMG_ID: 'IMG-8',
      MAIN_USER: 'original-user',
    });
    expect(oldMetal).toMatchObject({
      ITM_OTH_WT: 0.2,
      CON_PRC: 2,
      CON_WT: 0.1,
      ITM_RATE_TYPE: 'F',
      HM_ID_WT: 0,
      HM_ID2_WT: 0,
      HM_ID3_WT: 0,
      HM_ID4_WT: 0,
      ITM_OTH: 0,
      MAIN_USER: 'original-user',
    });
    expect(billOs).toMatchObject({
      BILL_LC: LC,
      BILL_YRCD: YEAR,
      BILL_DBCD: BOOK,
      BILL_NO: '00008',
      BILL_HD_VCH_NO: '00041',
      BILL_SRNO: 1,
      BILL_GOLD: 0,
      BILL_SILVER: 0,
      OLD_ADJ_AMT: 0,
      OLD_ADJ_GOLD: 0,
      OLD_ADJ_SILVER: 0,
      REC_GOLD: 0,
      REC_SILVER: 0,
      KASAR_GOLD: 0,
      KASAR_SILVER: 0,
      DATA_TRFR: 'N',
      DATA_TYPE: 'A',
      MAIN_USER: 'original-user',
    });
  }, 30_000);

  it('creates, opens, edits and re-consumes its own tag while preserving desktop identity without delete audit', async () => {
    const created = await createSale(runtime, saleInput(), firstLines);
    expect(created.vchNo).toBe(8);

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT s."VCH_NO",s."HD_VCH_NO",s."MAIN_USER",s."VCH_TIME"::date::text time_date,
              to_char(s."VCH_TIME",'HH24:MI:SS.MS') clock,t."BOOK_NAME"
         FROM "SL_DATA" s JOIN "TEMP_BOOK_DATA" t
           ON t.tenant_id=s.tenant_id AND t."CO_CODE"=s."CO_CODE" AND t."LC_CODE"=s."LC_CODE"
          AND t."CO_BOOK"=s."CO_BOOK" AND t."VCH_NO"=s."HD_VCH_NO"
        WHERE s.tenant_id=$1 AND s."VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      VCH_NO: '00008',
      HD_VCH_NO: '00041',
      MAIN_USER: 'original-user',
      time_date: DAY,
      BOOK_NAME: 'Configured Sales Book',
    });
    const originalClock = String(persisted[0]?.clock);

    await expect(getSale(runtime, scope, created.vchNo)).resolves.toMatchObject({
      voucherNo: '00008',
      hiddenVoucherNo: '00041',
      mainUser: 'original-user',
      vchDate: DAY,
      acCode: 'CUST',
      lines: [
        { itCode: 'GOLD', tagNo: 'TAG001', vchSrno: 1 },
        { itCode: 'LOOSE', tagNo: '' },
      ],
    });

    await expect(
      editSale(
        runtime,
        saleInput({ mainUser: 'different-user', vchDate: '2024-04-11' }),
        replacementLines,
        created.vchNo,
      ),
    ).resolves.toMatchObject({ vchNo: 8 });

    const edited = (await owner.$queryRawUnsafe(
      `SELECT s."HD_VCH_NO",s."MAIN_USER",to_char(s."VCH_TIME",'HH24:MI:SS.MS') clock,
              s."VCH_TIME"::date::text time_date,
              (SELECT count(*)::int FROM "SL_DETL" d WHERE d.tenant_id=$1 AND d."VCH_NO"='00008') details,
              (SELECT count(*)::int FROM "DELETE_DATA" x WHERE x.tenant_id=$1) audits,
              (SELECT count(*)::int FROM "MAIN_STOCK" m WHERE m.tenant_id=$1
                AND m."CO_BOOK"='SAL' AND m."VCH_NO"='00008' AND m."TAG_NO"='TAG001'
                AND m."VCH_SRNO"=1 AND m."ITM_SIGN"='-') tag_issues
         FROM "SL_DATA" s WHERE s.tenant_id=$1 AND s."VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(edited[0]).toMatchObject({
      HD_VCH_NO: '00041',
      MAIN_USER: 'original-user',
      clock: originalClock,
      time_date: '2024-04-11',
      details: 2,
      audits: 0,
      tag_issues: 1,
    });
    const replacedLine = (await owner.$queryRawUnsafe(
      `SELECT "ITM_NWT"::float nwt FROM "SL_DETL"
        WHERE tenant_id=$1 AND "VCH_NO"='00008' AND "TAG_NO"='TAG001'`,
      TENANT,
    )) as Array<{ nwt: number }>;
    expect(replacedLine[0]?.nwt).toBe(9.5);

    // GV-SLDETL-001: TR_SALE.cs mSG[X,35] = Round(ITM_AMT + LBR_AMT + OTH_AMT, 0) and
    // mSG[X,37] = mSG[X,35], so the two persisted columns are equal, tax-exclusive and whole-rupee.
    const money = (await owner.$queryRawUnsafe(
      `SELECT "ITM_AMT"::float itm, "LBR_AMT"::float lbr, "OTH_AMT"::float oth,
              "TOT_AMT"::float tot, "NET_AMT"::float net
         FROM "SL_DETL" WHERE tenant_id=$1 AND "VCH_NO"='00008' ORDER BY "SR_NO"`,
      TENANT,
    )) as Array<{ itm: number; lbr: number; oth: number; tot: number; net: number }>;
    expect(money.length).toBeGreaterThan(0);
    for (const row of money) {
      const expected = lineTotalDesktop({
        itemAmount: row.itm,
        labourAmount: row.lbr,
        otherAmount: row.oth,
      });
      expect(row.tot).toBeCloseTo(expected, 2);
      expect(row.net).toBeCloseTo(expected, 2);
      expect(row.tot).toBe(row.net);
      expect(row.tot % 1).toBe(0);
    }

    /**
     * Provenance stamping applied by postVoucherTx. Both expectations here were CORRECTED against the real
     * database: this row is `SL_DETL`, and the desktop leaves BOTH `DATA_TRFR` and `ADD_USER` empty on it.
     *
     *   `DATA_TRFR` — populated on 18691 of 27214 rows across the 37 tables carrying it, but `SL_DETL` is
     *   0 of 245. This test previously required 'N' here, which no real SL_DETL row has.
     *
     *   `ADD_USER` — populated on only 2 of the 19 tables carrying both it and `MAIN_USER`
     *   (`BAR_DETL` 1169/1329, `SL_ORD_DETL` 25/63) and 0 of 245 on `SL_DETL`. The old blanket mirror
     *   stamped it everywhere.
     *
     * The renumbering trail still exists as null so a later renumber updates rather than inserts.
     */
    const provenance = (await owner.$queryRawUnsafe(
      `SELECT "DATA_TRFR","OLD_VCH_NO","NEW_VCH_NO","MAIN_USER","ADD_USER"
         FROM "SL_DETL" WHERE tenant_id=$1 AND "VCH_NO"='00008' LIMIT 1`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(provenance).toHaveLength(1);
    const stamp = provenance[0]!;
    expect(String(stamp.DATA_TRFR ?? '').trim()).toBe('');
    expect(stamp.OLD_VCH_NO).toBeNull();
    expect(stamp.NEW_VCH_NO).toBeNull();
    expect(String(stamp.ADD_USER ?? '').trim()).toBe('');
  }, 30_000);

  it('rejects an edit locked by the persisted date and leaves the voucher unchanged', async () => {
    const created = await createSale(runtime, saleInput(), firstLines);
    const before = await getSale(runtime, scope, created.vchNo);
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      editSale(
        runtime,
        saleInput({ vchDate: '2024-04-20' }),
        [{ ...replacementLines[0]!, netWt: 8 }],
        created.vchNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await getSale(runtime, scope, created.vchNo)).toEqual(before);
    const counts = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAL'
           AND "VCH_NO"='00008' AND "TAG_NO"='TAG001' AND "ITM_SIGN"='-') issues`,
      TENANT,
    )) as Array<{ audits: number; issues: number }>;
    expect(counts[0]).toEqual({ audits: 0, issues: 1 });
  }, 30_000);

  it('rolls back a mid-edit tax-policy failure after release so the voucher and tag stay consumed', async () => {
    const created = await createSale(runtime, saleInput(), firstLines);
    const before = await getSale(runtime, scope, created.vchNo);

    await expect(
      editSale(
        runtime,

        saleInput({ hallmarkAmount: 10, hmTaxPct: 5 }),
        replacementLines,
        created.vchNo,
      ),
    ).rejects.toThrow(/hallmark tax rate does not match/);

    expect(await getSale(runtime, scope, created.vchNo)).toEqual(before);
    const state = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAL'
           AND "VCH_NO"='00008' AND "TAG_NO"='TAG001' AND "VCH_SRNO"=1
           AND "ITM_SIGN"='-') issues,
         (SELECT min("APR_ISU") FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001') apr_isu,
         (SELECT min("APP_TRFR") FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001') app_trfr`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(state[0]).toEqual({ audits: 0, issues: 1, apr_isu: 'N', app_trfr: 'Y' });
  }, 30_000);

  it('persists configured whole-rupee sale totals in both the header and party ledger', async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF") VALUES ($1,$2,0)`,
      TENANT,
      CO,
    );
    const result = await createSale(runtime, saleInput(), [
      { itCode: 'LOOSE', pcs: 1, metalAmount: 1000.55 },
    ]);
    expect(result.totals).toMatchObject({ taxable: 1001, tax: 30.03, total: 1031 });

    const rows = (await owner.$queryRawUnsafe(
      `SELECT s."TOT_AMT"::float total,
              (SELECT a."DR_AMT"::float FROM "AC_DATA" a
                WHERE a.tenant_id=s.tenant_id AND a."CO_CODE"=s."CO_CODE"
                  AND a."LC_CODE"=s."LC_CODE" AND a."CO_YEAR"=s."CO_YEAR"
                  AND a."CO_BOOK"=s."CO_BOOK" AND a."VCH_NO"=s."VCH_NO"
                  AND a."AC_CODE"='CUST' AND coalesce(a."DR_AMT",0)<>0 LIMIT 1) ledger_total
         FROM "SL_DATA" s WHERE s.tenant_id=$1 AND s."VCH_NO"='00008'`,
      TENANT,
    )) as Array<{ total: number; ledger_total: number }>;
    expect(rows[0]).toEqual({ total: 1031, ledger_total: 1031 });
  });

  it("persists unconfigured sale totals with today's 2dp policy in header and ledger", async () => {
    const result = await createSale(runtime, saleInput(), [
      { itCode: 'LOOSE', pcs: 1, metalAmount: 1000.55 },
    ]);
    expect(result.totals).toMatchObject({ taxable: 1000.55, tax: 30.02, total: 1030.57 });

    const rows = (await owner.$queryRawUnsafe(
      `SELECT s."TOT_AMT"::float total,
              (SELECT a."DR_AMT"::float FROM "AC_DATA" a
                WHERE a.tenant_id=s.tenant_id AND a."CO_CODE"=s."CO_CODE"
                  AND a."LC_CODE"=s."LC_CODE" AND a."CO_YEAR"=s."CO_YEAR"
                  AND a."CO_BOOK"=s."CO_BOOK" AND a."VCH_NO"=s."VCH_NO"
                  AND a."AC_CODE"='CUST' AND coalesce(a."DR_AMT",0)<>0 LIMIT 1) ledger_total
         FROM "SL_DATA" s WHERE s.tenant_id=$1 AND s."VCH_NO"='00008'`,
      TENANT,
    )) as Array<{ total: number; ledger_total: number }>;
    expect(rows[0]).toEqual({ total: 1030.57, ledger_total: 1030.57 });
  });

  it('deletes with one configured-book header audit plus one desktop-shaped row per sale line', async () => {
    const created = await createSale(runtime, saleInput(), firstLines);
    await owner.$executeRawUnsafe(
      `UPDATE "SL_DATA" SET "TOT_AMT"=500,"OLD_GL_AMT"='10',"OLD_SL_AMT"='20',
              "CASH_AMT"=5,"CARD_AMT"=4,"CHQ_AMT"=3,"CASH_PAID"=2,"KASAR_AMT"=1,
              "VCH_DESC"=$2
        WHERE tenant_id=$1 AND "VCH_NO"='00008'`,
      TENANT,
      'D'.repeat(170),
    );
    await expect(
      deleteSale(runtime, { scope, vchNo: created.vchNo, deleteUser: 'current-user' }),
    ).resolves.toEqual({ reversed: true });

    const audits = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr,"VCH_TYPE" type,"BOOK_NAME" book,"AC_CODE" ac,"AC_NAME" name,
              "VCH_VAL_DR" dr,"VCH_VAL_CR" cr,"FINE_TYPE" fine_type,
              "VCH_FINE_DR"::float fine_dr,"VCH_FINE_CR"::float fine_cr,
              "HD_VCH_NO" hidden,"MAIN_USER" main_user,"DELETE_USER" delete_user,"VCH_DESC" description
         FROM "DELETE_DATA" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(audits).toHaveLength(3);
    expect(audits[0]).toMatchObject({
      sr: 0,
      type: 'CSB',
      book: 'Configured Sales Book',
      ac: 'CUST',
      name: 'Lifecycle Customer',
      dr: 500,
      cr: 41,
      fine_type: 'A',
      fine_dr: 0,
      fine_cr: 0,
      hidden: '00041',
      main_user: 'original-user',
      delete_user: 'current-user',
      description: 'D'.repeat(150),
    });
    expect(audits[1]).toMatchObject({
      sr: 1,
      type: 'CSB',
      book: 'Configured Sales Book',
      fine_type: 'G',
      fine_cr: 10,
      description: 'ItCode / GOLD   TagNo / TAG001',
    });
    expect(audits[2]).toMatchObject({
      sr: 2,
      fine_type: 'G',
      fine_cr: 2,
      description: 'ItCode / LOOSE   TagNo / N',
    });
    const remaining = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "SL_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00008') headers,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00041') temp_rows`,
      TENANT,
    )) as Array<{ headers: number; temp_rows: number }>;
    expect(remaining[0]).toEqual({ headers: 0, temp_rows: 0 });
  }, 30_000);

  it('reports bill profit against the COMPUTED line total, not a request field', async () => {
    // Regression: the profit block first read `totAmt`/`netAmt` off the request line. Those fields do not
    // exist on the input — the total is derived by `lineTotalDesktop` — so every profit came back as minus
    // the cost (−64,120 instead of −7,328 for the fixture below). Live verification caught it; this pins it.
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","BILL_PROFIT") VALUES ($1,$2,'Y')
       ON CONFLICT (tenant_id,"CO_CODE") DO UPDATE SET "BILL_PROFIT"='Y'`,
      TENANT,
      CO,
    );
    // ToDaySlRate = 7_210_000 / 103 * 100 / 1000 = 7000 per gram.
    await owner.$executeRawUnsafe(
      `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_DATE","SR_NO","FINE_SL_RATE")
       VALUES ($1,$2,'01','2024-04-01'::date,1,7210000)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `UPDATE "ITEM_MAST" SET "AVG_TOUCH"=91.6 WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );

    const result = await createSale(runtime, saleInput(), [
      { itCode: 'GOLD', pcs: 1, grossWt: 10, netWt: 10, touch: 91.6, rate: 6200 },
    ]);
    expect(result.billProfit, 'profit must be present when BILL_PROFIT is on').toBeTruthy();
    const bp = result.billProfit!;
    const line = bp.lines[0]!;
    // Cost = round(10 x 91.6 / 100, 3) x 7000 = 9.160 x 7000 = 64,120 via the average-touch branch.
    expect(line.basis).toBe('average-touch');
    expect(line.cost).toBeCloseTo(64120, 2);
    // The profit must equal (computed line total − cost), which is what the earlier bug got wrong.
    expect(bp.total).toBeCloseTo(Number(result.totals.net) - line.cost, 2);
    // And it must NOT be simply minus the cost.
    expect(bp.total).not.toBeCloseTo(-line.cost, 2);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET_NEW" SET "BILL_PROFIT"='N' WHERE tenant_id=$1`,
      TENANT,
    );
    const hidden = await createSale(runtime, saleInput(), [
      { itCode: 'GOLD', pcs: 1, grossWt: 10, netWt: 10, touch: 91.6, rate: 6200 },
    ]);
    // Absent, not zero: the shop has chosen not to show margins.
    expect(hidden.billProfit).toBeUndefined();
  });

  it('the Rojmel report shows metal beside money, which the AC_DATA day book cannot', async () => {
    // This is the whole reason the report exists. The desktop's RP_ROJMEL reads ROJ_MEL_DATA for its
    // summary sections, keyed on ITM_FINE and split by SIGN and IT_TYPE. The existing dayBook report
    // reads AC_DATA, which has no weight columns at all, so it can never show this.
    await createSale(runtime, saleInput(), firstLines);
    const report = await rojmel(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
    } as any);

    expect(report.rows.length).toBeGreaterThan(0);
    const metal = report.rows.filter((r) => r.itType !== 'A');
    const money = report.rows.filter((r) => r.itType === 'A');
    expect(metal.length).toBe(firstLines.length);
    expect(money.length).toBeGreaterThan(0);

    // Weight only on metal rows — the distinction AC_DATA cannot express.
    expect(metal.every((r) => r.grossWt > 0)).toBe(true);
    expect(money.every((r) => r.grossWt === 0)).toBe(true);

    // The money side must balance, exactly as the ledger does.
    expect(report.totals.dr).toBeCloseTo(report.totals.cr, 2);
    expect(report.totals.balanced).toBe(true);

    // A sale sends metal OUT, so it lands in the outward bucket for its metal.
    const bucket = metal[0]!.itType === 'G' ? report.totals.gold : report.totals.silver;
    expect(bucket.outGrossWt).toBeCloseTo(
      metal.reduce((t, r) => t + r.grossWt, 0),
      3,
    );
    // Sale books populate NO fine: 0 of 115 estimate rows and 0 of 79 gold-invoice rows in the real
    // desktop database. Fine belongs to the settlement families (gold purchase 42/55, rate cut 32/32),
    // so an empty fine total here is correct rather than a missing value.
    expect(bucket.outFine).toBe(0);
  });

  it('projects the sale into a Rojmel that reconciles with the ledger', async () => {
    // The desktop writes 4 Rojmel rows for a 2-line sale: one metal row per line carrying that line's
    // pieces and weight, plus a party row and a tax row. Verified on Live24 book 027 voucher 00001,
    // where the metal rows summed to the sales leg exactly (1087.00 + 428.00 = 1515.00).
    const created = await createSale(runtime, saleInput(), firstLines);
    const vch = String(created.vchNo).padStart(5, '0');
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "AC_CODE","LD_CODE","IT_TYPE","SIGN","LEDR_KEY",
              "DR_AMT"::float dr,"CR_AMT"::float cr,"ITM_PCS"::float pcs,"ITM_GWT"::float gwt
         FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
      TENANT,
      vch,
    )) as Array<Record<string, unknown>>;
    expect(rows.length).toBeGreaterThan(0);

    const metal = rows.filter((r) => r.IT_TYPE !== 'A');
    const money = rows.filter((r) => r.IT_TYPE === 'A');
    // One metal row per sale line, each carrying weight — this is what AC_DATA cannot express and the
    // whole reason the Rojmel exists.
    expect(metal).toHaveLength(firstLines.length);
    expect(metal.every((r) => Number(r.gwt ?? 0) > 0)).toBe(true);
    expect(metal.every((r) => r.SIGN === '-')).toBe(true); // metal out on a sale
    expect(money.every((r) => Number(r.gwt ?? 0) === 0)).toBe(true);

    // The party row's amount must equal the party's ledger debit. Asserting against AC_DATA rather
    // than a hard-coded figure means the two projections cannot silently disagree.
    const [partyLeg] = (await owner.$queryRawUnsafe(
      `SELECT "DR_AMT"::float dr FROM "AC_DATA"
        WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "AC_CODE"=$3 AND "DR_AMT">0`,
      TENANT,
      vch,
      'CUST',
    )) as Array<{ dr: number }>;
    const partyRow = rows.find((r) => r.AC_CODE === 'CUST' && r.IT_TYPE === 'A');
    expect(partyRow).toBeDefined();
    expect(Number(partyRow!.dr ?? 0)).toBeCloseTo(Number(partyLeg?.dr ?? 0), 2);

    // Every row carries the voucher key, and LEDR_KEY encodes the row type at offset 22.
    expect(rows.every((r) => String(r.LEDR_KEY).length >= 23)).toBe(true);
    expect(metal.every((r) => String(r.LEDR_KEY).slice(21, 23) === '01')).toBe(true);
  });

  it('writes exactly the declared set of tables, so a dropped write cannot pass unnoticed', async () => {
    // WHY THIS EXISTS
    // The lifecycle tests assert the CONTENT of rows they look at, but nothing asserted the SET of tables that
    // received rows. Proven by inverting the sale's write set to emit `{ table: 'TAX_DATA', rows: [] }`:
    // 26 tests across three files, INCLUDING the GST suite, all passed with no tax rows written at all.
    //
    // That is the same failure the desktop comparison reports as "WEB NEVER WROTE THIS TABLE" - the most
    // consequential kind of parity defect, because the voucher looks right on screen and in its own detail
    // rows while an entire ledger or tax table is absent.
    //
    // The probe is schema-driven: every table carrying a VCH_NO column is checked, so a table nobody thought
    // to list is still covered.
    const created = await createSale(runtime, saleInput(), firstLines);
    // This read `created.voucherNo ?? ...`, but SaleResult has no such property - so the fallback was always
    // the real path and the first operand was dead. Three sites carried it. Typechecking the test project is
    // what surfaced them; the suite passed either way, which is why nothing had ever flagged it.
    const vch = String(created.vchNo).padStart(5, '0');

    const tables = await voucherTables(owner);
    expect(tables.length, 'the schema must expose voucher tables to probe').toBeGreaterThan(30);
    const touched = await footprintOf(owner, tables, TENANT, vch);

    expect(touched).toEqual(
      [
        'AC_DATA',
        'BILL_OS_DATA',
        'MAIN_STOCK',
        // The day book. The desktop writes it on every sale (3179 real rows); the web did not until
        // the Rojmel projection was added, so an F11 day book had no metal rows to show.
        'ROJ_MEL_DATA',
        'SL_DATA',
        'SL_DETL',
        'SL_IDTL',
        'TAX_DATA',
        'USER_DATA',
      ].sort(),
    );

    // A footprint check alone would pass if AC_DATA received rows that did not balance, so both properties are
    // asserted: the table is present AND the postings are complete.
    const legs = await ledgerLegs(owner, TENANT, vch);
    expect(legs.dr, 'the ledger must actually be posted').toBeGreaterThan(0);
    expect(legs.dr, 'and it must balance').toBeCloseTo(legs.cr, 2);
  });

  // ---------------------------------------------------------------------------------------------------
  // L6 configuration matrix: a setting that changes a PERSISTED value.
  //
  // A suite that only exercises defaults tests one shop. `CO_SET.SL_AMT_TYPE` selects the weight the item rate
  // is multiplied by, so it changes the money on every line:
  //
  //   ''  net + ghat   (blank is N: MS_OPNCOMP.cs:881-884, Ac_Image.cs:6221)
  //   'F' fine, or net+ghat when fine is 0
  //   'G' gross + ghat
  //   'N' net + ghat
  //   'P' pieces      (TR_SALE.cs:10909-10916)
  //
  // TR_SALE.cs CommPassTotal via `saleAmountBasis` (@datacare/core). The fixture line below has one piece,
  // gross 12.000, net 10.000 and touch 91.6, so fine is 9.160 and the four bases give different amounts -
  // which is what makes the matrix able to fail.
  //
  // Blank used to price fine (9160) and P net (10000). That was the web's own sentinel, not the desktop:
  // PARITY-EVALUATION-2026-09-28 D6 and vectors D6-2 in
  // parity-plan-2026-09-10/evidence/implementation-2026-09-29-eval-defects/contract.md.
  // ---------------------------------------------------------------------------------------------------
  it.each([
    ['', 10000],
    ['F', 9160],
    ['G', 12000],
    ['N', 10000],
    ['P', 1000],
  ] as const)(
    'SL_AMT_TYPE=%s prices the line off the declared weight basis',
    async (type, expected) => {
      await owner.$executeRawUnsafe(
        `UPDATE "CO_SET" SET "SL_AMT_TYPE"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
        type,
        TENANT,
        CO,
      );
      const created = await createSale(runtime, saleInput(), [
        {
          itCode: 'GOLD',
          tagNo: 'TAG001',
          vchSrno: 1,
          pcs: 1,
          grossWt: 12,
          netWt: 10,
          touch: 91.6,
          rate: 1000,
        },
      ]);
      const vch = String(created.vchNo).padStart(5, '0');
      const rows = (await owner.$queryRawUnsafe(
        `SELECT coalesce("ITM_AMT",0)::float amt FROM "SL_DETL"
        WHERE tenant_id=$1 AND "VCH_NO"=$2 LIMIT 1`,
        TENANT,
        vch,
      )) as { amt: number }[];
      expect(rows[0]?.amt, `SL_AMT_TYPE=${type} must price off its own basis`).toBeCloseTo(
        expected,
        2,
      );
    },
  );

  // PARITY-EVALUATION-2026-09-28 D6, vectors D6-1/D6-3/D6-5. Each asserts the PERSISTED amount and the
  // persisted RtWith, because the defect was in what reached SL_DETL, not in a helper's return value.
  const pricedLine = async (
    companyType: string | null,
    line: Record<string, unknown>,
  ): Promise<{ amt: number; rateWith: string }> => {
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "SL_AMT_TYPE"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      companyType,
      TENANT,
      CO,
    );
    const created = await createSale(runtime, saleInput(), [
      { itCode: 'GOLD', vchSrno: 1, ...line },
    ] as never);
    const rows = (await owner.$queryRawUnsafe(
      `SELECT coalesce("ITM_AMT",0)::float amt, coalesce("RATE_WITH",'') "rateWith" FROM "SL_DETL"
        WHERE tenant_id=$1 AND "VCH_NO"=$2 LIMIT 1`,
      TENANT,
      String(created.vchNo).padStart(5, '0'),
    )) as { amt: number; rateWith: string }[];
    return rows[0]!;
  };

  it('D6-1: a NULL SL_AMT_TYPE bills net as the desktop does (60,000, not 54,960) and stores RtWith N', async () => {
    const row = await pricedLine(null, {
      tagNo: 'TAG001',
      pcs: 1,
      grossWt: 10,
      netWt: 10,
      touch: 91.6,
      rate: 6000,
    });
    expect(row.amt).toBeCloseTo(60000, 2);
    // TR_SALE.cs:9161 seeds a new row's column 21 from the company type and :15432 saves it.
    expect(row.rateWith).toBe('N');
  });

  it('D6-3: a line RtWith overrides the company type and is stored as given', async () => {
    const row = await pricedLine('N', {
      tagNo: 'TAG001',
      pcs: 2,
      grossWt: 12,
      netWt: 10,
      touch: 91.6,
      rate: 1000,
      rateWith: 'g',
    });
    expect(row.amt).toBeCloseTo(12000, 2);
    expect(row.rateWith).toBe('G');
  });

  it('D6-5: an item RATE_TYPE K divides a per-kilogram rate', async () => {
    const row = await pricedLine('N', {
      tagNo: 'TAG001',
      pcs: 1,
      grossWt: 250,
      netWt: 250,
      touch: 100,
      rate: 70000,
      rateType: 'K',
    });
    expect(row.amt).toBeCloseTo(17500, 2);
  });

  it('the amount bases are genuinely distinct, so the matrix can fail', async () => {
    // Guards the matrix itself. If gross, net and fine ever coincided in the fixture, every row above would
    // pass regardless of whether the setting was read at all - the matrix would be vacuous.
    const gross = 12;
    const net = 10;
    const fine = Number(((net * 91.6) / 100).toFixed(3));
    expect(new Set([gross, net, fine]).size, 'all three bases must differ').toBe(3);
  });

  // ---------------------------------------------------------------------------------------------------
  // L6 continued: a rounding setting must reach the PERSISTED value, not merely the policy object.
  //
  // `resolveRoundingPolicy` is already unit tested, including that ALL_ROF_REMOVE=Y forces four precisions to 2
  // while leaving PR_RATE_ROF independent (MS_OPNCOMP.cs:1297-1303). What was NOT proven is that the resolved
  // policy reaches the database — a policy object with the right number in it is worth nothing if the write
  // path ignores it.
  //
  // Observability matters here: SL_DETL's money columns are numeric(_,2), so a precision finer than two
  // decimals cannot be seen in them at all. SL_DATA.CGST_TAX and SGST_TAX are `double precision` with NO
  // scale, which is where the desktop's unrounded intra-state halves live (gstSplit: the two halves are
  // assigned without rounding, so an odd-paise tax stores as 0.505 twice rather than 0.51 + 0.50). Those
  // columns are therefore the only place a tax-precision change is visible end to end.
  // ---------------------------------------------------------------------------------------------------
  const taxHalvesFor = async (settings: {
    taxRof: string;
    allRofRemove: string;
  }): Promise<{ cgst: number; sgst: number; taxAmt: number }> => {
    await owner.$executeRawUnsafe(
      // TAX_ROF is `integer` after the column-type correction, so the text parameter needs a cast.
      `UPDATE "CO_SET" SET "TAX_ROF"=NULLIF($1::text,'')::integer, "ALL_ROF_REMOVE"=$2
         WHERE tenant_id=$3 AND "CO_CODE"=$4`,
      settings.taxRof,
      settings.allRofRemove,
      TENANT,
      CO,
    );
    // An UNTAGGED loose line: a tag can only be sold once, and this helper posts several vouchers to compare
    // precisions. Tax is computed from the amount either way, so the tag adds nothing to what is being tested
    // while making the helper unusable after its first call.
    const created = await createSale(runtime, saleInput(), [
      {
        itCode: 'GOLD',
        pcs: 1,
        grossWt: 10,
        netWt: 10,
        touch: 91.6,
        // A rate chosen so 3% of the line lands beyond two decimals, which is what makes the precisions
        // distinguishable at all. The blank company prices net (10 x 7131.11 = 71,311.10), so 3% is
        // 2,139.333 and the 2dp tax is an odd 2,139.33. (7131.1 was tuned to the former fine basis; on net
        // it gives 71,311.00 and an exact 2dp tax, which no precision can tell apart.)
        rate: 7131.11,
      },
    ]);
    const vch = String(created.vchNo).padStart(5, '0');
    const rows = (await owner.$queryRawUnsafe(
      `SELECT coalesce("CGST_TAX",0)::float cgst, coalesce("SGST_TAX",0)::float sgst,
              coalesce("TAX_AMT",0)::float "taxAmt"
         FROM "SL_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 LIMIT 1`,
      TENANT,
      vch,
    )) as { cgst: number; sgst: number; taxAmt: number }[];
    return rows[0]!;
  };

  it('TAX_ROF reaches the persisted tax, and ALL_ROF_REMOVE overrides it', async () => {
    const at5 = await taxHalvesFor({ taxRof: '5', allRofRemove: 'N' });
    const at2 = await taxHalvesFor({ taxRof: '2', allRofRemove: 'N' });
    const at0 = await taxHalvesFor({ taxRof: '0', allRofRemove: 'N' });

    // The halves are stored UNROUNDED, so each is exactly half of the rounded total.
    for (const [label, r] of [
      ['5dp', at5],
      ['2dp', at2],
      ['0dp', at0],
    ] as const) {
      expect(r.cgst, `${label} halves must be equal`).toBeCloseTo(r.sgst, 6);
      expect(r.cgst + r.sgst, `${label} halves must sum to the tax`).toBeCloseTo(r.taxAmt, 2);
    }

    // Zero decimals leaves a whole-rupee tax, and that IS visible in TAX_AMT.
    expect(Number.isInteger(at0.taxAmt), 'TAX_ROF=0 must give a whole-rupee tax').toBe(true);
    expect(at5.taxAmt, 'TAX_ROF=5 must differ from 0dp').not.toBeCloseTo(at0.taxAmt, 2);

    // But 5 versus 2 decimals is NOT observable in TAX_AMT: that column is numeric(_,2), so the database
    // truncates the difference away before anyone can read it. The distinction survives only in the
    // double-precision halves. Asserting it on TAX_AMT would have produced a test that can never fail, which
    // is how this assertion was first written.
    expect(at5.cgst, 'the 5dp half must differ from the 2dp half').not.toBeCloseTo(at2.cgst, 6);

    // ALL_ROF_REMOVE=Y forces tax precision to 2 REGARDLESS of TAX_ROF. Asserted against the 2dp case rather
    // than a literal, so the test states the relationship the setting creates rather than a magic number.
    const forced = await taxHalvesFor({ taxRof: '5', allRofRemove: 'Y' });
    expect(forced.cgst, 'ALL_ROF_REMOVE=Y must behave as TAX_ROF=2').toBeCloseTo(at2.cgst, 6);
    // Compared on the halves, for the same reason: TAX_AMT cannot represent the difference being asserted.
    expect(forced.cgst, 'and must NOT behave as the configured 5').not.toBeCloseTo(at5.cgst, 6);

    // The halves reach the database UNROUNDED. GV-TOTALS pins gstSplit(1.01) -> 0.505 twice at unit level;
    // this asserts the same property survives the write path, which is the part a unit test cannot show.
    //
    // The TAX_ROF=2 case is the one that proves it, and the choice of case matters. At 2 decimals the tax is
    // an odd number of paise, so each half gains a THIRD decimal that rounding to paise would destroy.
    // Asserting this at TAX_ROF=5 proves nothing, because rounding a 4-decimal half to 5 decimals is a no-op
    // - which is exactly how the first version of this assertion passed against a deliberately broken build.
    const halfThirdDecimal = Math.round(at2.cgst * 1000) % 10;
    expect(
      halfThirdDecimal,
      'an odd-paise tax must halve to a third decimal, proving the halves were not rounded',
    ).not.toBe(0);
    expect(at2.cgst + at2.sgst, 'and the two halves must still sum to the tax exactly').toBeCloseTo(
      at2.taxAmt,
      6,
    );

    // Restore, so a later test in this file is not run under a forced policy.
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "TAX_ROF"=NULL, "ALL_ROF_REMOVE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
  });
});
