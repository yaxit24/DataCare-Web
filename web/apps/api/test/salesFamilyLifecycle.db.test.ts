import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import {
  createLabourInvoice,
  editLabourInvoice,
  getLabourInvoice,
} from '../src/modules/sales/labourInvoice.js';
import {
  cancelSalesOrder,
  cancelSalesOrderAdjust,
  createSalesOrder,
  editSalesOrder,
  editSalesOrderAdjustment,
  getSalesOrder,
  getSalesOrderAdjustment,
} from '../src/modules/sales/salesOrder.js';
import {
  createSaleReturn,
  deleteSaleReturn,
  editSaleReturn,
  getSaleReturn,
  saleForReturn,
} from '../src/modules/sales/salesReturn.js';
import {
  deleteSchemeInstallment,
  editSchemeInstallment,
  enrollScheme,
  editSchemeMaturity,
  getSchemeInstallment,
  getSchemeMaturity,
  schemeInstallment,
  schemeMaturity,
  schemeOpening,
} from '../src/modules/membership/scheme.js';
import { schemePassbookData } from '../src/modules/scheme/passbook.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';
import { footprintOf, ledgerLegs, voucherTables } from './support/footprint.js';
import { fineFor } from '@datacare/core';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'sales-family-lifecycle';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
/** Exact write set of a sale return, pinned so an extra or dropped write fails by name. */
const FOOTPRINT_SALE_RETURN: string[] = [
  'AC_DATA',
  'MAIN_STOCK',
  // The day book. A return brings metal BACK IN, so its rows carry SIGN '+' where a sale's carry '-'.
  'ROJ_MEL_DATA',
  'SL_DATA',
  'SL_DETL_RTN',
  'TAX_DATA',
];
const DAY = '2024-04-10';
const EDIT_DAY = '2024-04-11';

const scope = (coBook: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});

const returnInput = (overrides: Record<string, unknown> = {}) => ({
  scope: scope('SRT'),
  mainUser: 'return-owner',
  acCode: 'CUST',
  acName: 'Lifecycle Customer',
  origBook: 'SAL',
  origVchNo: 1,
  vchDate: DAY,
  taxRatePct: 3,
  interState: false,
  ...overrides,
});
const returnLines = [
  {
    itCode: 'GOLD',
    tagNo: 'TAGRT',
    pcs: 1,
    grossWt: 3,
    netWt: 3,
    touch: 100,
    metalAmount: 300,
  },
  { itCode: 'LOOSE', pcs: 1, grossWt: 1, netWt: 1, touch: 90, metalAmount: 100 },
];
const editedReturnLines = [
  {
    itCode: 'GOLD',
    tagNo: 'TAGRT',
    pcs: 1,
    grossWt: 3,
    netWt: 2.5,
    touch: 92,
    metalAmount: 325,
  },
];

const orderInput = (overrides: Record<string, unknown> = {}) => ({
  scope: scope('SOR'),
  mainUser: 'order-owner',
  acCode: 'CUST',
  acName: 'Lifecycle Customer',
  vchDate: DAY,
  taxRatePct: 3,
  advanceAmount: 100,
  lines: [
    {
      itCode: 'GOLD',
      pcs: 1,
      grossWt: 2,
      netWt: 2,
      touch: 100,
      rate: 100,
      making: 10,
      remark: 'first order line',
    },
    { itCode: 'LOOSE', pcs: 1, netWt: 1, touch: 100, rate: 50, making: 5 },
  ],
  ...overrides,
});

const installmentInput = (overrides: Record<string, unknown> = {}) => ({
  scope: scope('074'),
  mainUser: 'scheme-owner',
  schmCode: 'S01',
  membCode: '00001',
  amount: 500,
  vchDate: DAY,
  ...overrides,
});

const asNumber = (value: unknown): number => Number(value ?? 0);

databaseDescribe('database-backed sales-family voucher lifecycles', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'REMARK_DATA',
      'DM_DATA',
      'TAX_DATA',
      'BILL_OS_DATA',
      'UPI_DATA',
      'CARD_DATA',
      'ROJ_MEL_DATA',
      'AC_DATA',
      'AD_OS',
      'AD_ADJ',
      'AD_DATA',
      'TEMP_AD_DATA',
      'AD_MEMB',
      'AD_MAST',
      'SL_ORD_ADJ',
      'SL_ORD_IDTL',
      'SL_ORD_DETL',
      'SL_ORD_DATA',
      'LBR_REC_DETL',
      'LBR_ISU_IDTL',
      'LBR_ISU_DETL',
      'LBR_DATA',
      'SL_DETL_RTN',
      'SL_DETL',
      'SL_DATA',
      'MAIN_STOCK',
      'BAR_DETL',
      'TEMP_BOOK_DATA',
      'BOOK_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'GROUP_MAST',
      'TAX_MAST',
      'AC_MAST',
      'YEAR_MAST',
      'CO_SET_NEW',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,$2,$3,'2024-04-01','2025-03-31')`,
      TENANT,
      CO,
      YEAR,
    );
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
       VALUES ($1,$2,'10',1,'GST','GST 3%',3,'GSTLED'),
              -- The labour invoice's labour part defaults to 5%, which needs a configured code (G92).
              ($1,$2,'11',1,'GST','GST 5%',5,'GSTLED')`,
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
       VALUES
         ($1,$2,$3,'SAL','Sales','SALE','SALES','O','Y','SL_DATA'),
         ($1,$2,$3,'SQT','Sales Quotation','SQTN','SALES QUOTATION','O','Y','SL_DATA'),
         ($1,$2,$3,'SRT','Sales Return','SRTN','SALES RETURNE','I','Y','SL_DATA'),
         ($1,$2,$3,'SOR','Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA'),
         ($1,$2,$3,'ORC','Order Cancel','SADJ','ORDER CANCEL','O','Y','SL_ORD_ADJ'),
         ($1,$2,$3,'LBR','Labour','LBRI','LABOUR WORK','O','Y','LBR_DATA'),
         ($1,$2,$3,'074','Member Entry','MBENT','MEMB ENTRY','I','Y','AD_DATA'),
         ($1,$2,$3,'076','Member Adjust','MBADJ','MEMB ADJUST','O','Y','AD_ADJ')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'SRT',1,'CTRL','SALES RETURNE','I'),
              ($1,$2,$3,'SRT',2,'CASH','SALES RETURNE','I'),
              ($1,$2,$3,'SRT',3,'ROUND','SALES RETURNE','I'),
              -- N59/G164: the order advance debits the order book's slot-1 account (desktop
              -- salesOrder.ts:1197), so the SOR book must carry that slot — the writer no longer
              -- falls back to the literal 'CASH'.
              ($1,$2,$3,'SOR',1,'CTRL','SALES ORDER','O'),
              -- G115 / P0-04: the labour writer resolves its income account from BOOK_DETL SR_NO 6
              -- (desktop Ac_Ledr.cs:1203), so the LBR book must carry that slot.
              ($1,$2,$3,'LBR',6,'CTRL','LABOUR WORK','O'),
              -- P0-04: the scheme/member books settle to their configured slot 1. Real book 074's leg-02 rows
              -- name 00001, so the slot has to exist here too — the module no longer falls back to a literal.
              ($1,$2,$3,'074',1,'CASHAC','MEMB ENTRY','I'),
              ($1,$2,$3,'075',1,'CASHAC','MEMB MATURITY','O'),
              ($1,$2,$3,'076',1,'CASHAC','MEMB ADJUST','O')`,
      TENANT,
      CO,
      LC,
    );

    await owner.$executeRawUnsafe(
      `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
       SELECT $1,$2,$3,b,'00040','seed' FROM unnest(ARRAY['SRT','SOR','ORC','LBR','074','076']) b`,
      TENANT,
      CO,
      LC,
    );

    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","AC_CODE")
       VALUES
         ($1,$2,$3,$4,'SAL','00001',$5::date,$5::timestamp,'CUST'),
         ($1,$2,$3,$4,'SQT','00001',$5::date,$5::timestamp,'CUST'),
         ($1,$2,$3,$4,'SRT','00007',$5::date,$5::timestamp,'CUST')`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","NET_AMT")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,$5::date,'CUST','GOLD','TAGRT',1,1,3,3,100,300)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BAR_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","EMP_ISU")
       VALUES ($1,$2,$3,$4,'TOP','00001',1,$5::date,'GOLD','TAGRT',1,1,3,3,3,'N')`,
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
       VALUES
         ($1,$2,$3,$4,'TOP','00001',1,$5::date,'GOLD','TAGRT',1,'+',1,3,3),
         ($1,$2,$3,$4,'SAL','00001',1,$5::date,'GOLD','TAGRT',1,'-',1,3,3)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );

    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_ORD_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","AC_CODE")
       VALUES ($1,$2,$3,$4,'SOR','00007',$5::date,$5::timestamp,'CUST')`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_ORD_ADJ"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TIME")
       VALUES ($1,$2,$3,$4,'ORC','00007',1,$5::date,$5::timestamp)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LBR_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","AC_CODE")
       VALUES ($1,$2,$3,$4,'LBR','00007',$5::date,$5::timestamp,'CUST')`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );

    await owner.$executeRawUnsafe(
      `INSERT INTO "AD_MAST"(tenant_id,"CO_CODE","SCHM_CODE","SCHM_NAME","SCHM_AC")
       VALUES ($1,$2,'S01','Lifecycle Scheme','SCHEME')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AD_MEMB"(tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME","MEMB_AMT")
       VALUES ($1,$2,$3,'S01','00001','Lifecycle Member',500)`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AD_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TIME")
       VALUES ($1,$2,$3,$4,'074','00007',1,$5::date,$5::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AD_ADJ"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TIME")
       VALUES ($1,$2,$3,$4,'076','00007',1,$5::date,$5::timestamp)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
  };

  const clock = async (table: string, book: string, voucherNo = '00008'): Promise<string> => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT to_char("VCH_TIME",'HH24:MI:SS.MS') clock FROM "${table}"
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1`,
      TENANT,
      book,
      voucherNo,
    )) as Array<{ clock: string }>;
    return rows[0]!.clock;
  };

  const ledgerBalance = async (book: string, voucherNo = '00008'): Promise<[number, number]> => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT coalesce(sum("DR_AMT"),0)::float dr,coalesce(sum("CR_AMT"),0)::float cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      TENANT,
      book,
      voucherNo,
    )) as Array<{ dr: number; cr: number }>;
    return [asNumber(rows[0]?.dr), asNumber(rows[0]?.cr)];
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

  /**
   * G05 / N35. Sales Return imports the original bill from the book the operator chose, resolved as a
   * SALES book. The route used to read a literal 'SAL' and the writer defaulted origBook to 'SAL', so a
   * company whose sales book is not named SAL could never import, and a quotation book that shares
   * SL_DATA could be mistaken for a sale.
   */
  it('imports a return source from the chosen SALES book and refuses a non-SALES book', async () => {
    const imported = await saleForReturn(runtime, {
      scope: scope('SAL'),
      origVchNo: 1,
      origBook: 'SAL',
    });
    expect(imported).toMatchObject({ acCode: 'CUST' });
    expect(imported.lines.length).toBeGreaterThan(0);

    // The quotation book shares SL_DATA and the same voucher number, but it is not a sale.
    await expect(
      saleForReturn(runtime, { scope: scope('SQT'), origVchNo: 1, origBook: 'SQT' }),
    ).rejects.toThrow(/SALES/i);
  });

  it('creates, gets and replaces a sales return while preserving identity and balance', async () => {
    const created = await createSaleReturn(runtime, returnInput(), returnLines);
    expect(created.vchNo).toBe(8);

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT h."VCH_NO",h."HD_VCH_NO",h."MAIN_USER",h."VCH_TIME"::date::text time_date,
              to_char(h."VCH_TIME",'HH24:MI:SS.MS') clock,t."BOOK_NAME"
         FROM "SL_DATA" h JOIN "TEMP_BOOK_DATA" t
           ON t.tenant_id=h.tenant_id AND t."CO_CODE"=h."CO_CODE" AND t."LC_CODE"=h."LC_CODE"
          AND t."CO_BOOK"=h."CO_BOOK" AND t."VCH_NO"=h."HD_VCH_NO"
        WHERE h.tenant_id=$1 AND h."CO_BOOK"='SRT' AND h."VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      VCH_NO: '00008',
      HD_VCH_NO: '00041',
      MAIN_USER: 'return-owner',
      time_date: DAY,
      BOOK_NAME: 'SALES RETURNE',
    });
    const originalClock = String(persisted[0]?.clock);

    await expect(getSaleReturn(runtime, scope('SRT'), 8)).resolves.toMatchObject({
      voucherNo: '00008',
      hiddenVoucherNo: '00041',
      mainUser: 'return-owner',
      vchDate: DAY,
      lines: [{ itCode: 'GOLD', tagNo: 'TAGRT', vchSrno: 1 }, { itCode: 'LOOSE' }],
    });

    await editSaleReturn(
      runtime,
      returnInput({ mainUser: 'ignored-editor', vchDate: EDIT_DAY }),
      editedReturnLines,
      8,
    );
    const edited = (await owner.$queryRawUnsafe(
      `SELECT h."HD_VCH_NO",h."MAIN_USER",h."VCH_TIME"::date::text time_date,
              to_char(h."VCH_TIME",'HH24:MI:SS.MS') clock,
              (SELECT count(*)::int FROM "SL_DETL_RTN" d WHERE d.tenant_id=$1 AND d."CO_BOOK"='SRT' AND d."VCH_NO"='00008') details,
              (SELECT count(*)::int FROM "TAX_DATA" x WHERE x.tenant_id=$1 AND x."CO_BOOK"='SRT' AND x."VCH_NO"='00008') taxes,
              (SELECT count(*)::int FROM "DELETE_DATA" x WHERE x.tenant_id=$1) audits
         FROM "SL_DATA" h WHERE h.tenant_id=$1 AND h."CO_BOOK"='SRT' AND h."VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(edited[0]).toMatchObject({
      HD_VCH_NO: '00041',
      MAIN_USER: 'return-owner',
      time_date: EDIT_DAY,
      clock: originalClock,
      details: 1,
      taxes: 2,
      audits: 0,
    });
    const [dr, cr] = await ledgerBalance('SRT');
    expect(dr).toBeCloseTo(cr, 6);
  });

  it('persists every return-grid column the form offers instead of discarding it', async () => {
    const created = await createSaleReturn(runtime, returnInput(), [
      {
        itCode: 'GOLD',
        tagNo: 'TAGRT',
        pcs: 1,
        grossWt: 3,
        netWt: 3,
        touch: 100,
        metalAmount: 300,
        huid: 'HUID01',
        hallmarkId2: 'HUID02',
        hallmarkIdWt: 1.25,
        ghtPct: 2.5,
        itemLot: 'LOT7',
        remark: 'returned ring',
        discountPct: 1.5,
        employeeCode: 'E1',
        designImageId: 'IMG-9',
        tagLabourPct: 4,
        tagLabourRate: 120,
        tagLabourAmount: 360,
        tagOtherAmount: 15,
      },
    ] as any);
    const [row] = (await owner.$queryRawUnsafe(
      `SELECT "HM_ID","HM_ID2","HM_ID_WT"::text hm_wt,"ITM_GHT_PRC"::text ght,"ITM_LOT","ITM_REMARK",
              "DISC_PRC"::text disc,"EMP_CODE","DESIGN_IMG_ID","TAG_LBR_PRC"::text tag_pct,
              "TAG_LBR_RATE"::text tag_rate,"TAG_LBR_AMT"::text tag_amt,"TAG_OTH_AMT"::text tag_oth
         FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"=$2`,
      TENANT,
      String(created.vchNo).padStart(5, '0'),
    )) as Array<Record<string, string | null>>;
    expect(row).toMatchObject({
      HM_ID: 'HUID01',
      HM_ID2: 'HUID02',
      ITM_LOT: 'LOT7',
      ITM_REMARK: 'returned ring',
      EMP_CODE: 'E1',
      DESIGN_IMG_ID: 'IMG-9',
    });
    expect(Number(row!.hm_wt)).toBe(1.25);
    expect(Number(row!.ght)).toBe(2.5);
    expect(Number(row!.disc)).toBe(1.5);
    expect([row!.tag_pct, row!.tag_rate, row!.tag_amt, row!.tag_oth].map(Number)).toEqual([
      4, 120, 360, 15,
    ]);
  });

  it('rejects a persisted-date-locked sales-return edit without changing its write set', async () => {
    const created = await createSaleReturn(runtime, returnInput(), returnLines);
    const before = await getSaleReturn(runtime, scope('SRT'), created.vchNo);
    const balanceBefore = await ledgerBalance('SRT');
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      editSaleReturn(
        runtime,
        returnInput({ vchDate: '2024-04-20' }),
        editedReturnLines,
        created.vchNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await getSaleReturn(runtime, scope('SRT'), created.vchNo)).toEqual(before);
    expect(await ledgerBalance('SRT')).toEqual(balanceBefore);
    const audits = await owner.$queryRawUnsafe(
      `SELECT 1 FROM "DELETE_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(audits).toHaveLength(0);
  });

  it('rejects atomically when editing a return whose admitted tag was resold', async () => {
    const created = await createSaleReturn(runtime, returnInput(), returnLines);
    const before = await getSaleReturn(runtime, scope('SRT'), created.vchNo);
    const balanceBefore = await ledgerBalance('SRT');
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE")
       VALUES ($1,$2,$3,$4,'SAL','00002',$5::date,'CUST')`,
      TENANT,
      CO,
      LC,
      YEAR,
      EDIT_DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_NWT")
       VALUES ($1,$2,$3,$4,'SAL','00002',1,$5::date,'CUST','GOLD','TAGRT',1,1,2.5)`,
      TENANT,
      CO,
      LC,
      YEAR,
      EDIT_DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_PCS","ITM_NWT")
       VALUES ($1,$2,$3,$4,'SAL','00002',1,$5::date,'GOLD','TAGRT',1,'-',1,2.5)`,
      TENANT,
      CO,
      LC,
      YEAR,
      EDIT_DAY,
    );

    await expect(
      editSaleReturn(runtime, returnInput({ vchDate: EDIT_DAY }), editedReturnLines, created.vchNo),
    ).rejects.toThrow(/returned tag TAGRT was sold again/);
    expect(await getSaleReturn(runtime, scope('SRT'), created.vchNo)).toEqual(before);
    expect(await ledgerBalance('SRT')).toEqual(balanceBefore);
    const state = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"='00008') details,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_NO"='00008' AND "ITM_SIGN"='+') returns,
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(state[0]).toEqual({ details: 2, returns: 2, audits: 0 });
  });

  it('creates, gets and replaces a sales order and its adjustment with balanced ledgers', async () => {
    const created = await createSalesOrder(runtime, orderInput());
    expect(created.vchNo).toBe(8);
    const originalClock = await clock('SL_ORD_DATA', 'SOR');
    await expect(getSalesOrder(runtime, scope('SOR'), 8)).resolves.toMatchObject({
      voucherNo: '00008',
      hiddenVoucherNo: '00041',
      mainUser: 'order-owner',
      vchDate: DAY,
      lines: [{ itCode: 'GOLD' }, { itCode: 'LOOSE' }],
    });

    await editSalesOrder(
      runtime,
      orderInput({
        mainUser: 'ignored-editor',
        vchDate: EDIT_DAY,
        advanceAmount: 80,
        lines: [{ itCode: 'GOLD', pcs: 1, netWt: 4, touch: 100, rate: 90, making: 12 }],
      }),
      8,
    );
    const order = (await owner.$queryRawUnsafe(
      `SELECT h."HD_VCH_NO",h."MAIN_USER",h."VCH_TIME"::date::text time_date,
              to_char(h."VCH_TIME",'HH24:MI:SS.MS') clock,
              (SELECT count(*)::int FROM "SL_ORD_DETL" d WHERE d.tenant_id=$1 AND d."CO_BOOK"='SOR' AND d."VCH_NO"='00008') details,
              (SELECT count(*)::int FROM "DELETE_DATA" x WHERE x.tenant_id=$1) audits
         FROM "SL_ORD_DATA" h WHERE h.tenant_id=$1 AND h."CO_BOOK"='SOR' AND h."VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(order[0]).toMatchObject({
      HD_VCH_NO: '00041',
      MAIN_USER: 'order-owner',
      time_date: EDIT_DAY,
      clock: originalClock,
      details: 1,
      audits: 0,
    });
    let [dr, cr] = await ledgerBalance('SOR');
    expect(dr).toBeCloseTo(cr, 6);

    const adjustment = await cancelSalesOrderAdjust(runtime, {
      scope: scope('SOR'),
      vchNo: 8,
      paidAmt: 60,
      paidAc: 'CASH',
      vchDate: EDIT_DAY,
      mainUser: 'adjust-owner',
    });
    expect(adjustment.vchNo).toBe(8);
    await expect(getSalesOrderAdjustment(runtime, scope('SOR'), 8)).resolves.toMatchObject({
      hiddenVoucherNo: '00041',
      mainUser: 'adjust-owner',
      paidAmt: 60,
    });
    const adjustmentClock = await clock('SL_ORD_ADJ', 'ORC');
    await editSalesOrderAdjustment(
      runtime,
      {
        scope: scope('SOR'),
        vchNo: 8,
        paidAmt: 50,
        paidAc: 'BANK',
        vchDate: '2024-04-12',
        mainUser: 'ignored-editor',
      },
      8,
    );
    await expect(getSalesOrderAdjustment(runtime, scope('SOR'), 8)).resolves.toMatchObject({
      hiddenVoucherNo: '00041',
      mainUser: 'adjust-owner',
      vchDate: '2024-04-12',
      paidAmt: 50,
      paidAc: 'BANK',
    });
    expect(await clock('SL_ORD_ADJ', 'ORC')).toBe(adjustmentClock);
    [dr, cr] = await ledgerBalance('ORC');
    expect(dr).toBeCloseTo(cr, 6);
  });

  it('rejects a persisted-date-locked sales-order edit without changing it', async () => {
    const created = await createSalesOrder(runtime, orderInput());
    const before = await getSalesOrder(runtime, scope('SOR'), created.vchNo);
    const balanceBefore = await ledgerBalance('SOR');
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      editSalesOrder(runtime, orderInput({ vchDate: '2024-04-20', advanceAmount: 10 }), 8),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await getSalesOrder(runtime, scope('SOR'), 8)).toEqual(before);
    expect(await ledgerBalance('SOR')).toEqual(balanceBefore);
  });

  // ---------------------------------------------------------------------------------------------
  // Desktop row shapes, measured against the real DataCareNext database (Live24, 8160 AD_DATA rows
  // and 8194 AD_OS rows). Each assertion below records the count it was verified against, because
  // a shape guessed from a handful of sampled rows is how three of these fields came to be wrong.
  // ---------------------------------------------------------------------------------------------
  it('a cash instalment writes ONE Rojmel row per line; a banked one writes TWO', async () => {
    // Book 074 carries 1635 real day-book rows against 1311 instalment lines. The extra rows are the
    // receipt leg, written only when the money lands in a bank: of the bank-receipt vouchers, 216 have
    // a type-02 row and 0 do not, and all four accounts involved are banks. A cash receipt gets no
    // second row — the Rojmel IS the cash book, so cash movement is implicit and a bank movement is a
    // contra that has to be stated.
    const rojmel = async (vch: string): Promise<Array<Record<string, unknown>>> =>
      (await owner.$queryRawUnsafe(
        `SELECT "AC_CODE","LD_CODE","IT_TYPE","LEDR_KEY",
                "DR_AMT"::float dr,"CR_AMT"::float cr
           FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"=$2
          ORDER BY "LEDR_KEY"`,
        TENANT,
        vch,
      )) as Array<Record<string, unknown>>;

    // Cash: one row, the liability credited, contra = the receipt account.
    const cash = await schemeInstallment(runtime, installmentInput());
    const cashRows = await rojmel(String(cash.vchNo).padStart(5, '0'));
    expect(cashRows).toHaveLength(1);
    expect(cashRows[0]!.IT_TYPE).toBe('A'); // money row, never a metal letter
    expect(Number(cashRows[0]!.cr ?? 0)).toBe(500);
    expect(Number(cashRows[0]!.dr ?? 0)).toBe(0);
    expect(String(cashRows[0]!.LEDR_KEY).slice(21, 23)).toBe('01');

    // Banked: two rows — the liability credit plus the bank debit, keyed 01 and 02 on the same line.
    const bank = await schemeInstallment(
      runtime,
      installmentInput({ mode: 'bank', bankAc: 'BANK' }),
    );
    const bankRows = await rojmel(String(bank.vchNo).padStart(5, '0'));
    expect(bankRows).toHaveLength(2);
    expect(bankRows.map((r) => String(r.LEDR_KEY).slice(21, 23))).toEqual(['01', '02']);
    // The receipt leg is a DEBIT on the bank, mirroring the ledger rather than inverting it.
    const receipt = bankRows[1]!;
    expect(receipt.AC_CODE).toBe('BANK');
    expect(Number(receipt.dr ?? 0)).toBe(500);
    expect(Number(receipt.cr ?? 0)).toBe(0);
  });

  it('an opening entry writes no Rojmel row at all (no money moves)', async () => {
    const open = await schemeOpening(runtime, installmentInput({ scope: scope('075') }));
    const [n] = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='075' AND "VCH_NO"=$2`,
      TENANT,
      String(open.vchNo).padStart(5, '0'),
    )) as Array<{ n: number }>;
    expect(n!.n).toBe(0);
  });

  it('AD_DATA matches the desktop instalment shape (TOT_AMT is 0 on all 8160 real rows)', async () => {
    await schemeInstallment(runtime, installmentInput());
    const [row] = (await owner.$queryRawUnsafe(
      `SELECT "ENT_TYPE","INOUT_TYPE","MEMB_AMT"::float memb,"TOT_AMT"::float tot,"REC_AC","SCHM_CODE"
         FROM "AD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(row).toBeDefined();
    expect(row!.ENT_TYPE).toBe('E'); // 'E' monthly entry; 'O' is the 075 opening
    expect(row!.INOUT_TYPE).toBe('I'); // 'I' on all 8160 real rows — money in
    expect(asNumber(row!.memb)).toBe(500);
    // The instalment value lives in MEMB_AMT alone. TOT_AMT is 0 on every real row; writing the
    // amount here as well double-counts in any report that sums it.
    expect(asNumber(row!.tot)).toBe(0);
  });

  it('AD_OS is a signed movement row: amount in ADJ_AMT, MEMB_AMT 0 on all 8194 real rows', async () => {
    await schemeInstallment(runtime, installmentInput());
    const [row] = (await owner.$queryRawUnsafe(
      `SELECT "OS_TYPE","SIGN","DATA_TYPE","LD_CODE","ADJ_AMT"::float adj,"MEMB_AMT"::float memb
         FROM "AD_OS" WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(row).toBeDefined();
    expect(row!.OS_TYPE).toBe('A'); // A accrual (+), D principal adjusted (-), B bonus (-)
    expect(row!.SIGN).toBe('+');
    expect(row!.DATA_TYPE).toBe('A'); // 'A' on all 8194 real rows
    // A member's balance is SUM(A '+') - SUM(D '-') - SUM(B '-') over ADJ_AMT. MEMB_AMT is 0 on
    // every real AD_OS row regardless of movement type.
    expect(asNumber(row!.adj)).toBe(500);
    expect(asNumber(row!.memb)).toBe(0);
    // LD_CODE is the account the money ARRIVED IN, not the scheme liability. Verified across the
    // real rows: 00001 CASH ON HAND 7162, 000754 OLD AXIS BANK 714, 000418 OLD HDFC 163.
    //
    // P0-04: this used to read the literal 'CASH' because the module fell back to it. It now reads the
    // book's CONFIGURED slot-1 account, which is what those real rows actually contain — the fixture seeds
    // 'CASHAC' as book 074 slot 1 above, and that is what arrives here.
    expect(row!.LD_CODE).toBe('CASHAC');
  });

  it('forwards the desktop grid inputs the route used to drop (BANK_NAME/EMP_CODE/MONTH_CODE/WITH_UPI)', async () => {
    await schemeInstallment(
      runtime,
      installmentInput({
        bankName: 'AXIS BANK',
        empCode: 'E7',
        monthCode: '03',
        withUpi: true,
      }),
    );
    const [row] = (await owner.$queryRawUnsafe(
      `SELECT "BANK_NAME","EMP_CODE","MONTH_CODE","WITH_UPI" FROM "AD_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(row!.BANK_NAME).toBe('AXIS BANK');
    expect(row!.EMP_CODE).toBe('E7');
    expect(row!.MONTH_CODE).toBe('03');
    expect(row!.WITH_UPI).toBe('Y');
  });

  it('writes desktop UPI_DATA split rows and UPI-specific ledger/day-book rows', async () => {
    await schemeInstallment(
      runtime,
      installmentInput({
        mode: 'upi',
        bankAc: 'UPI1',
        bankName: 'PhonePe Settlement',
        empCode: 'E7',
        monthCode: '04',
        chqNo: 'UPI-REF',
        withUpi: true,
        upiLines: [
          {
            srNo: 1,
            upiAcCode: 'UPI1',
            upiAcName: 'PhonePe Settlement',
            upiType: 'PHONEPE',
            upiId: 'TXN-1',
            amount: 200,
          },
          {
            srNo: 2,
            upiAcCode: 'UPI2',
            upiAcName: 'GPay Settlement',
            upiType: 'GPAY',
            upiId: 'TXN-2',
            amount: 300,
          },
        ],
      }),
    );

    const [detail] = (await owner.$queryRawUnsafe(
      `SELECT "REC_AC","WITH_UPI","UPI_NAME","MEMB_AMT"::float amount FROM "AD_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(detail).toMatchObject({
      REC_AC: 'UPI1',
      WITH_UPI: 'Y',
      UPI_NAME: 'PhonePe Settlement / PHONEPE / TXN-1',
      amount: 500,
    });

    const upiRows = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr,"ISR_NO"::int isr,"SCHM_CODE","AC_CODE","UPI_AC_CODE",
              "UPI_AC_NAME","UPI_TYPE","UPI_ID","UPI_AMT"::float amt,"HD_VCH_NO","MAIN_USER"
         FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'
        ORDER BY "SR_NO","ISR_NO"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(upiRows).toEqual([
      {
        sr: 1,
        isr: 1,
        SCHM_CODE: 'S01',
        AC_CODE: '00001',
        UPI_AC_CODE: 'UPI1',
        UPI_AC_NAME: 'PhonePe Settlement',
        UPI_TYPE: 'PHONEPE',
        UPI_ID: 'TXN-1',
        amt: 200,
        HD_VCH_NO: '00041',
        MAIN_USER: 'scheme-owner',
      },
      {
        sr: 1,
        isr: 2,
        SCHM_CODE: 'S01',
        AC_CODE: '00001',
        UPI_AC_CODE: 'UPI2',
        UPI_AC_NAME: 'GPay Settlement',
        UPI_TYPE: 'GPAY',
        UPI_ID: 'TXN-2',
        amt: 300,
        HD_VCH_NO: '00041',
        MAIN_USER: 'scheme-owner',
      },
    ]);

    const ledger = (await owner.$queryRawUnsafe(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","DR_AMT"::float dr,"CR_AMT"::float cr,"CHQ_NO"
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'
        ORDER BY "LEDR_KEY"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(ledger).toHaveLength(4);
    expect(ledger.map((r) => String(r.LEDR_KEY).slice(21))).toEqual([
      '01         1         1',
      '01         1         2',
      '02         1         1',
      '02         1         2',
    ]);
    expect(
      ledger.map((r) => [r.AC_CODE, r.LD_CODE, asNumber(r.dr), asNumber(r.cr), r.CHQ_NO]),
    ).toEqual([
      ['SCHEME', 'UPI1', 0, 200, 'TXN-1'],
      ['SCHEME', 'UPI2', 0, 300, 'TXN-2'],
      ['UPI1', 'SCHEME', 200, 0, 'TXN-1'],
      ['UPI2', 'SCHEME', 300, 0, 'TXN-2'],
    ]);
    expect(await ledgerBalance('074')).toEqual([500, 500]);

    const rojmel = (await owner.$queryRawUnsafe(
      `SELECT "LEDR_KEY","AC_CODE","AC_NAME","LD_CODE","DR_AMT"::float dr,"CR_AMT"::float cr,
              "SCHM_CODE","MEMB_CODE","REF_NO"
         FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'
        ORDER BY "LEDR_KEY"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(rojmel.map((r) => String(r.LEDR_KEY).slice(21))).toEqual([
      '01         1',
      '02         1         1',
      '02         1         2',
    ]);
    expect(
      rojmel.map((r) => [
        r.AC_CODE,
        r.AC_NAME,
        r.LD_CODE,
        asNumber(r.dr),
        asNumber(r.cr),
        r.REF_NO,
      ]),
    ).toEqual([
      ['SCHEME', '', '9999', 0, 500, ''],
      ['UPI1', 'PhonePe Settlement', 'SCHEME', 200, 0, 'TXN-1'],
      ['UPI2', 'GPay Settlement', 'SCHEME', 300, 0, 'TXN-2'],
    ]);

    await expect(getSchemeInstallment(runtime, scope('074'), 8)).resolves.toMatchObject({
      voucherNo: '00008',
      bankAc: 'UPI1',
      monthCode: '04',
      withUpi: true,
      upiName: 'PhonePe Settlement / PHONEPE / TXN-1',
      upiLines: [
        {
          srNo: 1,
          upiAcCode: 'UPI1',
          upiAcName: 'PhonePe Settlement',
          upiType: 'PHONEPE',
          upiId: 'TXN-1',
          amount: 200,
        },
        {
          srNo: 2,
          upiAcCode: 'UPI2',
          upiAcName: 'GPay Settlement',
          upiType: 'GPAY',
          upiId: 'TXN-2',
          amount: 300,
        },
      ],
    });
  });

  it('rejects UPI split totals that do not match the member installment amount', async () => {
    await expect(
      schemeInstallment(
        runtime,
        installmentInput({
          mode: 'upi',
          bankAc: 'UPI1',
          withUpi: true,
          upiLines: [
            { srNo: 1, upiAcCode: 'UPI1', upiType: 'PHONEPE', upiId: 'SHORT', amount: 499 },
          ],
        }),
      ),
    ).rejects.toThrow(/UPI split total 499 must equal member amount 500/);

    const [row] = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(row!.n).toBe(0);
  });

  it('posts a whole collection round as ONE voucher with a ledger pair per line', async () => {
    // The desktop's TR_MEMB_ENT is a grid: 812 of 1428 real member-entry vouchers carry more than one
    // member, and one opening voucher carries 175. Verified leg counts on real 074 vouchers:
    // 11 members → 22 legs, 7 → 14, 6 → 12. So the ledger is a Dr/Cr PAIR PER LINE.
    await schemeInstallment(
      runtime,
      installmentInput({
        schmCode: undefined,
        membCode: undefined,
        amount: undefined,
        lines: [
          { schmCode: 'S01', membCode: '00001', amount: 500 },
          { schmCode: 'S01', membCode: '00002', amount: 700 },
          { schmCode: 'S01', membCode: '00003', amount: 300 },
        ],
      }),
    );
    const detail = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr,"MEMB_CODE","MEMB_AMT"::float amt FROM "AD_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008' ORDER BY "SR_NO"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(detail.map((r) => [r.sr, r.MEMB_CODE, asNumber(r.amt)])).toEqual([
      [1, '00001', 500],
      [2, '00002', 700],
      [3, '00003', 300],
    ]);
    // AD_OS mirrors it line for line.
    const os = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr,"ADJ_AMT"::float adj FROM "AD_OS"
        WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008' ORDER BY "SR_NO"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(os.map((r) => [r.sr, asNumber(r.adj)])).toEqual([
      [1, 500],
      [2, 700],
      [3, 300],
    ]);
    // Two legs per line, not one aggregate pair. An aggregate pair balances just as well, so the
    // count is the only thing that distinguishes them — a balance assertion alone cannot.
    const [legs] = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='074' AND "VCH_NO"='00008'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(legs!.n).toBe(6);
    expect(await ledgerBalance('074')).toEqual([1500, 1500]);
  });

  it('rejects a bad grid line naming its index, and writes nothing', async () => {
    // The seed already carries one AD_DATA row (an instalment the passbook/maturity tests redeem),
    // so the invariant is that the rejected call leaves the count UNCHANGED — not that it is zero.
    const count = async (): Promise<number> => {
      const [r] = (await owner.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "AD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='074'`,
        TENANT,
      )) as Array<{ n: number }>;
      return r!.n;
    };
    const before = await count();
    await expect(
      schemeInstallment(
        runtime,
        installmentInput({
          schmCode: undefined,
          membCode: undefined,
          amount: undefined,
          lines: [
            { schmCode: 'S01', membCode: '00001', amount: 500 },
            { schmCode: 'S01', membCode: '00002', amount: 0 },
          ],
        }),
      ),
    ).rejects.toThrow(/line 2/);
    expect(await count()).toBe(before);
  });

  it('creates, gets and replaces a scheme installment while preserving identity and balance', async () => {
    const created = await schemeInstallment(runtime, installmentInput());
    expect(created.vchNo).toBe(8);
    const originalClock = await clock('AD_DATA', '074');
    await expect(getSchemeInstallment(runtime, scope('074'), 8)).resolves.toMatchObject({
      voucherNo: '00008',
      hiddenVoucherNo: '00041',
      mainUser: 'scheme-owner',
      vchDate: DAY,
      schmCode: 'S01',
      membCode: '00001',
      amount: 500,
    });

    await editSchemeInstallment(
      runtime,
      installmentInput({ amount: 650, vchDate: EDIT_DAY, mainUser: 'ignored-editor' }),
      8,
    );
    const edited = (await owner.$queryRawUnsafe(
      `SELECT d."HD_VCH_NO",d."MAIN_USER",d."VCH_DATE"::text time_date,
              to_char(d."VCH_TIME",'HH24:MI:SS.MS') clock,d."MEMB_AMT"::float amount,
              (SELECT count(*)::int FROM "AD_OS" o WHERE o.tenant_id=$1 AND o."CO_BOOK"='074' AND o."VCH_NO"='00008') os_rows,
              (SELECT count(*)::int FROM "DELETE_DATA" x WHERE x.tenant_id=$1) audits
         FROM "AD_DATA" d WHERE d.tenant_id=$1 AND d."CO_BOOK"='074' AND d."VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(edited[0]).toMatchObject({
      HD_VCH_NO: '00041',
      MAIN_USER: 'scheme-owner',
      time_date: EDIT_DAY,
      clock: originalClock,
      amount: 650,
      os_rows: 1,
      audits: 0,
    });
    const [dr, cr] = await ledgerBalance('074');
    expect(dr).toBeCloseTo(cr, 6);
  });

  it('rejects a persisted-date-locked scheme-installment edit without changing it', async () => {
    const created = await schemeInstallment(runtime, installmentInput());
    const before = await getSchemeInstallment(runtime, scope('074'), created.vchNo);
    const balanceBefore = await ledgerBalance('074');
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1 WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      editSchemeInstallment(runtime, installmentInput({ amount: 700, vchDate: '2024-04-20' }), 8),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await getSchemeInstallment(runtime, scope('074'), 8)).toEqual(before);
    expect(await ledgerBalance('074')).toEqual(balanceBefore);
  });

  // Desktop grep -c 'INSERT INTO DELETE_DATA': TR_SALE_RTN.cs=1, TR_SALE_ORD.cs=1,
  // TR_MEMB_ENT.cs=1. Each statement is one header/member-detail SELECT, so these fixtures emit one row.
  it('deletes with exactly the desktop-shaped sales return, order and member-entry audit rows', async () => {
    const saleReturn = await createSaleReturn(runtime, returnInput(), returnLines);
    const order = await createSalesOrder(runtime, orderInput());
    const installment = await schemeInstallment(runtime, installmentInput());

    await deleteSaleReturn(runtime, {
      scope: scope('SRT'),
      vchNo: saleReturn.vchNo,
      deleteUser: 'return-deleter',
    });
    await cancelSalesOrder(runtime, {
      scope: scope('SOR'),
      vchNo: order.vchNo,
      deleteUser: 'order-deleter',
    });
    await deleteSchemeInstallment(runtime, {
      scope: scope('074'),
      vchNo: installment.vchNo,
      deleteUser: 'scheme-deleter',
    });

    const audits = (await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK" book,"VCH_NO" voucher,"SR_NO"::int sr,"VCH_TYPE" type,
              "BOOK_NAME" book_name,"AC_CODE" ac,"AC_NAME" name,
              "VCH_VAL_DR"::float dr,"VCH_VAL_CR"::float cr,"FINE_TYPE" fine_type,
              "VCH_FINE_DR"::float fine_dr,"VCH_FINE_CR"::float fine_cr,
              "HD_VCH_NO" hidden,"MAIN_USER" main_user,"DELETE_USER" delete_user,"VCH_DESC" description
         FROM "DELETE_DATA" WHERE tenant_id=$1 ORDER BY "CO_BOOK","SR_NO"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(audits).toHaveLength(3);
    expect(audits.find((row) => row.book === 'SRT')).toMatchObject({
      voucher: '00008',
      sr: 0,
      type: 'SRTN',
      book_name: 'Sales Return',
      ac: 'CUST',
      name: 'Lifecycle Customer',
      fine_type: 'A',
      fine_dr: 0,
      fine_cr: 0,
      hidden: '00041',
      main_user: 'return-owner',
      delete_user: 'return-deleter',
    });
    expect(audits.find((row) => row.book === 'SOR')).toMatchObject({
      voucher: '00008',
      sr: 0,
      type: 'SORD',
      book_name: 'Sales Order',
      ac: 'CUST',
      name: 'Lifecycle Customer',
      dr: 0,
      cr: 100,
      fine_type: 'A',
      hidden: '00041',
      main_user: 'order-owner',
      delete_user: 'order-deleter',
    });
    expect(audits.find((row) => row.book === '074')).toMatchObject({
      voucher: '00008',
      sr: 1,
      type: 'MBENT',
      book_name: 'Member Entry',
      ac: '00001',
      name: 'Lifecycle Member',
      dr: 0,
      cr: 500,
      fine_type: 'A',
      fine_dr: 0,
      fine_cr: 0,
      hidden: '00041',
      main_user: 'scheme-owner',
      delete_user: 'scheme-deleter',
    });
  });

  it('round-trips labour-invoice and scheme-maturity edits with preserved identity', async () => {
    const labour = await createLabourInvoice(runtime, {
      scope: scope('LBR'),
      acCode: 'CUST',
      acName: 'Lifecycle Customer',
      vchDate: DAY,
      mainUser: 'labour-owner',
      lines: [
        { itCode: 'GOLD', pcs: 1, netWt: 2, metalAmount: 200, labourAmount: 40 },
        { itCode: 'LOOSE', pcs: 1, netWt: 1, metalAmount: 50, labourAmount: 10 },
      ],
    });
    expect(labour.vchNo).toBe(8);
    const labourClock = await clock('LBR_DATA', 'LBR');
    await expect(getLabourInvoice(runtime, scope('LBR'), 8)).resolves.toMatchObject({
      hiddenVoucherNo: '00041',
      mainUser: 'labour-owner',
      lines: [{ itCode: 'GOLD' }, { itCode: 'LOOSE' }],
    });
    await editLabourInvoice(
      runtime,
      {
        scope: scope('LBR'),
        acCode: 'CUST',
        vchDate: EDIT_DAY,
        mainUser: 'ignored-editor',
        lines: [{ itCode: 'GOLD', pcs: 1, netWt: 3, metalAmount: 330, labourAmount: 75 }],
      },
      8,
    );
    await expect(getLabourInvoice(runtime, scope('LBR'), 8)).resolves.toMatchObject({
      hiddenVoucherNo: '00041',
      mainUser: 'labour-owner',
      vchDate: EDIT_DAY,
      lines: [{ itCode: 'GOLD', netWt: 3, metalAmount: 330, labourAmount: 75 }],
    });
    expect(await clock('LBR_DATA', 'LBR')).toBe(labourClock);
    let [dr, cr] = await ledgerBalance('LBR');
    expect(dr).toBeCloseTo(cr, 6);

    const maturity = await schemeMaturity(runtime, {
      scope: scope('076'),
      schmCode: 'S01',
      membCode: '00001',
      amount: 500,
      bonus: 20,
      less: 5,
      vchDate: DAY,
      mainUser: 'maturity-owner',
    });
    expect(maturity).toEqual({ vchNo: 8, payout: 515 });
    const maturityClock = await clock('AD_ADJ', '076');
    await expect(getSchemeMaturity(runtime, scope('076'), 8)).resolves.toMatchObject({
      hiddenVoucherNo: '00041',
      mainUser: 'maturity-owner',
      payout: 515,
    });
    await editSchemeMaturity(
      runtime,
      {
        scope: scope('076'),
        schmCode: 'S01',
        membCode: '00001',
        amount: 600,
        bonus: 25,
        less: 10,
        vchDate: EDIT_DAY,
        mainUser: 'ignored-editor',
      },
      8,
    );
    await expect(getSchemeMaturity(runtime, scope('076'), 8)).resolves.toMatchObject({
      hiddenVoucherNo: '00041',
      mainUser: 'maturity-owner',
      vchDate: EDIT_DAY,
      amount: 600,
      bonus: 25,
      less: 10,
      payout: 615,
    });
    expect(await clock('AD_ADJ', '076')).toBe(maturityClock);
    [dr, cr] = await ledgerBalance('076');
    expect(dr).toBeCloseTo(cr, 6);
  });

  // Depth gate (Phase B): the desktop sales order persists tender rows, old-metal and rate-cut
  // adjustment, delivery/function dates, the party address block and 40 further grid columns on the
  // line (TR_SALE_ORD.cs:9120-9161 header, 9205-9306 detail).
  it('persists every desktop sales-order header and line column', async () => {
    const created = await createSalesOrder(
      runtime,
      orderInput({
        taxCode: 'G3',
        upiAmount: 250.5,
        bankAc: 'BANKAC',
        chequeNo: 'CHQ-42',
        bankName: 'Union Bank',
        cardAc: 'CARDAC',
        cardAdj: 'Y',
        oldGoldFine: 3.25,
        oldGoldAmount: 19_500,
        oldSilverFine: 12.5,
        oldSilverAmount: 900,
        schemeAmount: 1_000,
        rateCutRate: 6_400,
        rateCutFine: 2.5,
        rateCutAmount: 16_000,
        adjustGold: 1.75,
        adjustSilver: 4.5,
        orderAdjustAmount: 500,
        deliveryDate: '2024-05-01',
        functionDate: '2024-05-15',
        address1: 'Plot 8',
        address2: 'Jewel Street',
        address3: 'Opp Bank',
        city: 'Surat',
        mobile: '9812345670',
        empCode: 'E07',
        lines: [
          {
            itCode: 'GOLD',
            pcs: 1,
            grossWt: 2,
            netWt: 2,
            touch: 100,
            rate: 100,
            making: 10,
            tblCode: '001',
            itmColor: 'YELLOW',
            itmSize: 'L',
            bagWt: 0.2,
            lessWt: 0.1,
            ghtPct: 1.5,
            ghtWt: 0.05,
            westPct: 2,
            rateFix: 'Y',
            labourPct: 5,
            labourType: 'G',
            labourRate: 45,
            otherAmount: 30,
            mrp: 12_500,
            orderDeliveryDate: '2024-05-02',
            karigarNetWt: 1.9,
            karigarTouch: 91.5,
            karigarWestPct: 1.5,
            karigarFine: 1.78,
            karigarName: 'KARY',
            tagCost: 900,
            vchSrno: 4,
            oldSrNo: 7,
            rateType: 'R',
            itType: 'G',
            prCode: 'PR',
            oldTblCode: '002',
            tagStockLess: 'N',
            designImageId: 'IMG-9',
            huid: 'HUID999',
            hallmarkId2: 'H2',
            hallmarkId3: 'H3',
            hallmarkId4: 'H4',
            hallmarkIdWt: 1.1,
            hallmarkId2Wt: 2.2,
            hallmarkId3Wt: 3.3,
            hallmarkId4Wt: 4.4,
          },
        ],
      }),
    );
    const vchNo = String(created.vchNo).padStart(5, '0');

    const heads = (await owner.$queryRawUnsafe(
      `SELECT "TAX_CODE","BANK_AC","CHQ_NO","BANK_NAME","CARD_AC","CARD_ADJ","ADD1","ADD2","ADD3",
              "CITY","MOBILE","UPI_AMT"::float upi,"OLD_GL"::float old_gl,
              "OLD_GL_AMT"::float old_gl_amt,"OLD_SL"::float old_sl,"OLD_SL_AMT"::float old_sl_amt,
              "SCHM_AMT"::float schm,"RCUT_RATE"::float rc_rate,"RCUT_FINE"::float rc_fine,
              "RCUT_AMT"::float rc_amt,"ADJ_GOLD"::float adj_gold,"ADJ_SILVER"::float adj_silver,
              "ORD_ADJ_AMT"::float ord_adj,"DEL_DATE"::text del_date,"FUN_DATE"::text fun_date
         FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(heads).toHaveLength(1);
    const h = heads[0]!;
    expect(String(h.TAX_CODE).trim()).toBe('G3');
    expect(String(h.BANK_AC).trim()).toBe('BANKAC');
    expect(String(h.CHQ_NO).trim()).toBe('CHQ-42');
    expect(String(h.BANK_NAME).trim()).toBe('Union Bank');
    expect(String(h.CARD_AC).trim()).toBe('CARDAC');
    expect(String(h.CARD_ADJ).trim()).toBe('Y');
    expect(String(h.ADD1).trim()).toBe('Plot 8');
    expect(String(h.ADD2).trim()).toBe('Jewel Street');
    expect(String(h.ADD3).trim()).toBe('Opp Bank');
    expect(String(h.CITY).trim()).toBe('Surat');
    expect(String(h.MOBILE).trim()).toBe('9812345670');
    expect(h.upi).toBeCloseTo(250.5, 2);
    expect(h.old_gl).toBeCloseTo(3.25, 2);
    expect(h.old_gl_amt).toBeCloseTo(19_500, 2);
    expect(h.old_sl).toBeCloseTo(12.5, 2);
    expect(h.old_sl_amt).toBeCloseTo(900, 2);
    expect(h.schm).toBeCloseTo(1_000, 2);
    expect(h.rc_rate).toBeCloseTo(6_400, 2);
    expect(h.rc_fine).toBeCloseTo(2.5, 2);
    expect(h.rc_amt).toBeCloseTo(16_000, 2);
    expect(h.adj_gold).toBeCloseTo(1.75, 2);
    expect(h.adj_silver).toBeCloseTo(4.5, 2);
    expect(h.ord_adj).toBeCloseTo(500, 2);
    expect(String(h.del_date)).toContain('2024-05-01');
    expect(String(h.fun_date)).toContain('2024-05-15');

    const dets = (await owner.$queryRawUnsafe(
      `SELECT "TBL_CODE","ITM_COLOR","ITM_SIZE","RATE_FIX","LBR_TYPE","KR_NAME","RATE_TYPE",
              "IT_TYPE","PR_CODE","OLD_TBL_CODE","TAG_STK_LESS","DESIGN_IMG_ID","HM_ID","HM_ID2",
              "TAG_NO","EMP_CODE","BAG_WT"::float bag_wt,"ITM_OTH_WT"::float oth_wt,
              "ITM_GHT_PRC"::float ght_prc,"ITM_WEST_PRC"::float west,"LBR_PRC"::float lbr_prc,
              "LBR_RATE"::float lbr_rate,"OTH_AMT"::float oth_amt,"ITM_MRP"::float mrp,
              "KR_NET_WT"::float kr_nwt,"KR_TOUCH"::float kr_touch,"KR_FINE"::float kr_fine,
              "TAG_COST"::float tag_cost,"VCH_SRNO"::int vch_srno,"OLD_SRNO"::int old_srno,
              "HM_ID_WT"::float hm_wt,"ORD_REC_AMT"::float ord_rec,"ORD_DEL_DATE"::text ord_del
         FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(dets).toHaveLength(1);
    const d = dets[0]!;
    expect(String(d.TBL_CODE).trim()).toBe('001');
    expect(String(d.ITM_COLOR).trim()).toBe('YELLOW');
    expect(String(d.ITM_SIZE).trim()).toBe('L');
    expect(String(d.RATE_FIX).trim()).toBe('Y');
    expect(String(d.LBR_TYPE).trim()).toBe('G');
    expect(String(d.KR_NAME).trim()).toBe('KARY');
    expect(String(d.RATE_TYPE).trim()).toBe('R');
    expect(String(d.IT_TYPE).trim()).toBe('G');
    expect(String(d.PR_CODE).trim()).toBe('PR');
    expect(String(d.OLD_TBL_CODE).trim()).toBe('002');
    expect(String(d.TAG_STK_LESS).trim()).toBe('N');
    expect(String(d.DESIGN_IMG_ID).trim()).toBe('IMG-9');

    expect(String(d.HM_ID).trim()).toBe('HUID999');
    expect(String(d.HM_ID2).trim()).toBe('H2');
    expect(String(d.EMP_CODE).trim()).toBe('E07');
    expect(String(d.TAG_NO).trim()).toBe('N'); // desktop literal
    expect(d.bag_wt).toBeCloseTo(0.2, 3);
    expect(d.oth_wt).toBeCloseTo(0.1, 3);
    expect(d.ght_prc).toBeCloseTo(1.5, 2);
    expect(d.west).toBeCloseTo(2, 2);
    expect(d.lbr_prc).toBeCloseTo(5, 2);
    expect(d.lbr_rate).toBeCloseTo(45, 2);
    expect(d.oth_amt).toBeCloseTo(30, 2);
    expect(d.mrp).toBeCloseTo(12_500, 2);
    expect(d.kr_nwt).toBeCloseTo(1.9, 2);
    expect(d.kr_touch).toBeCloseTo(91.5, 2);
    expect(d.kr_fine).toBeCloseTo(1.78, 2);
    expect(d.tag_cost).toBeCloseTo(900, 2);
    expect(d.vch_srno).toBe(4);
    expect(d.old_srno).toBe(7); // explicit OLD_SRNO honoured
    expect(d.hm_wt).toBeCloseTo(1.1, 2);
    expect(d.ord_rec).toBe(0); // desktop literal
    expect(String(d.ord_del)).toContain('2024-05-02');
  }, 30_000);

  // Depth gate (Phase B): AD_MEMB is the scheme member record — identity, contact, KYC, key dates,
  // bank details and scheme linkage (Module_Schm.cs:489, the shared writer TR_MEMB_ENT calls). The
  // web previously wrote 9 of its 36 columns, so an enrolled member carried almost no detail.
  it('persists the full desktop scheme member record on enrolment', async () => {
    const enrolled = await enrollScheme(runtime, {
      scope: scope('074'),
      schmCode: 'S01',
      membCode: '00777',
      membName: 'Depth Member',
      monthlyAmt: 1_500,
      itemGrossWt: 12.5,
      empCode: 'E01',
      phone: '0281-111111',
      phone2: '0281-222222',
      mobile: '9811122233',
      mobile2: '9822233344',
      address1: 'House 21',
      address2: 'Gold Lane',
      address3: 'Near Temple',
      city: 'Rajkot',
      district: 'Rajkot',
      area: 'Kalawad Road',
      pin: '360005',
      email: 'member@example.com',
      idProof: 'AADHAAR-XXXX-1234',
      nomineeName: 'Nominee One',
      birthDate: '1985-06-15',
      anniversaryDate: '2010-11-20',
      lastBrokenDate: '2023-03-01',
      joinDate: '2024-04-01',
      expiryDate: '2025-03-31',
      bankName: 'State Bank',
      bankArea: 'Main Branch',
      bankAcNo: '1234567890',
      bankRtgsNo: 'SBIN0001234',
      refCode: 'REF01',
      schemeShort: 'LS',
      membBonus: 250,
      mainUser: 'memb-user',
    });
    expect(enrolled.membNo).toBe('00777');

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "MEMB_NAME","EMP_CODE","AC_PHONE","AC_PHONE2","AC_MOBILE","AC_MOBILE2","AC_ADD1",
              "AC_ADD2","AC_ADD3","AC_CITY","AC_DISTRICT","AC_AREA","AC_PIN","AC_EMAIL","ID_PROF",
              "NOMINEE_NAME","BANK_NAME","BANK_AREA","BANK_AC_NO","BANK_RTGS_NO","AC_REF_CODE",
              "SCHM_SHORT","DATA_TRFR","MAIN_USER",
              "MEMB_AMT"::float memb_amt,"ITM_GWT"::float itm_gwt,"MEMB_BONUS"::float bonus,
              "BIRTH_DATE"::text birth,"ANV_DATE"::text anv,"L_BR_DATE"::text lbr,
              "JOIN_DATE"::text join_date,"EXP_DATE"::text exp_date
         FROM "AD_MEMB" WHERE tenant_id=$1 AND "SCHM_CODE"='S01' AND "MEMB_CODE"='00777'`,
      TENANT,
    )) as Array<Record<string, any>>;
    expect(rows).toHaveLength(1);
    const m = rows[0]!;
    expect(String(m.MEMB_NAME).trim()).toBe('Depth Member');
    expect(String(m.EMP_CODE).trim()).toBe('E01');
    expect(String(m.AC_PHONE).trim()).toBe('0281-111111');
    expect(String(m.AC_PHONE2).trim()).toBe('0281-222222');
    expect(String(m.AC_MOBILE).trim()).toBe('9811122233');
    expect(String(m.AC_MOBILE2).trim()).toBe('9822233344');
    expect(String(m.AC_ADD1).trim()).toBe('House 21');
    expect(String(m.AC_ADD2).trim()).toBe('Gold Lane');
    expect(String(m.AC_ADD3).trim()).toBe('Near Temple');
    expect(String(m.AC_CITY).trim()).toBe('Rajkot');
    expect(String(m.AC_DISTRICT).trim()).toBe('Rajkot');
    expect(String(m.AC_AREA).trim()).toBe('Kalawad Road');
    expect(String(m.AC_PIN).trim()).toBe('360005');
    expect(String(m.AC_EMAIL).trim()).toBe('member@example.com');
    expect(String(m.ID_PROF).trim()).toBe('AADHAAR-XXXX-1234');
    expect(String(m.NOMINEE_NAME).trim()).toBe('Nominee One');
    expect(String(m.BANK_NAME).trim()).toBe('State Bank');
    expect(String(m.BANK_AREA).trim()).toBe('Main Branch');
    expect(String(m.BANK_AC_NO).trim()).toBe('1234567890');
    expect(String(m.BANK_RTGS_NO).trim()).toBe('SBIN0001234');
    expect(String(m.AC_REF_CODE).trim()).toBe('REF01');
    expect(String(m.SCHM_SHORT).trim()).toBe('LS');
    expect(String(m.DATA_TRFR).trim()).toBe('N'); // desktop literal
    expect(String(m.MAIN_USER).trim()).toBe('memb-user');
    expect(m.memb_amt).toBeCloseTo(1_500, 2);
    expect(m.itm_gwt).toBeCloseTo(12.5, 2);
    expect(m.bonus).toBeCloseTo(250, 2);
    expect(String(m.birth)).toContain('1985-06-15');
    expect(String(m.anv)).toContain('2010-11-20');
    expect(String(m.lbr)).toContain('2023-03-01');
    expect(String(m.join_date)).toContain('2024-04-01');
    expect(String(m.exp_date)).toContain('2025-03-31');
  }, 30_000);

  // Depth gate (Phase B): TEMP_AD_DATA is the scheme-passbook report staging table. Desktop clears
  // it by company and repopulates it from the member's installments before Crystal reads it
  // (TR_MEMB_ENT.cs:5381,5402); SchmPassBook.spec.json binds 11 of its columns, so the report
  // renders blank unless it is populated.
  it('stages the scheme passbook report rows from the member installments', async () => {
    // Create a real installment so AD_DATA carries the scheme/member keys the staging copies.
    await schemeInstallment(runtime, installmentInput());
    const staged = await schemePassbookData(runtime, {
      tenantId: TENANT,
      coCode: CO,
      schmCode: 'S01',
      membCode: '00001',
    });
    expect(staged).not.toBeNull();

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "SCHM_CODE","MEMB_CODE","CHQ_NO","REC_AC","CO_BOOK","VCH_NO",
              "REC_AMT"::float rec_amt,"ITM_GWT"::float itm_gwt,"ITM_RATE"::float itm_rate,
              "VCH_DATE"::text vch_date,"SCHM_DATE"::text schm_date
         FROM "TEMP_AD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "SR_NO"`,
      TENANT,
      CO,
    )) as Array<Record<string, any>>;
    // One staged row per seeded installment of this member.
    expect(rows.length).toBeGreaterThan(0);
    for (const row of rows) {
      expect(String(row.SCHM_CODE).trim()).toBe('S01');
      expect(String(row.MEMB_CODE).trim()).toBe('00001');
      // SCHM_DATE mirrors the installment date, as the desktop staging does.
      expect(String(row.schm_date ?? '')).toBe(String(row.vch_date ?? ''));
    }

    // Re-staging clears first: the row count must not grow on a second report run.
    const before = rows.length;
    await schemePassbookData(runtime, {
      tenantId: TENANT,
      coCode: CO,
      schmCode: 'S01',
      membCode: '00001',
    });
    const again = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "TEMP_AD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    )) as Array<{ n: number }>;
    expect(again[0]!.n).toBe(before);
  }, 30_000);

  it('a sale return writes exactly its declared set of tables', async () => {
    // Established empirically. A return is the family member most likely to lose a write silently, because it
    // reverses stock and ledger rather than creating them, so an absent table looks like "nothing to reverse".
    const created = await createSaleReturn(runtime, returnInput(), returnLines);
    // `voucherNo` does not exist on these result types, so the `??` first operand was dead and the fallback
    // was always the real path. Three sites here, three more in sales.lifecycle. Surfaced by typechecking
    // the test project, which nothing had ever done.
    const vch = String(created.vchNo).padStart(5, '0');
    const tables = await voucherTables(owner);
    expect(tables.length).toBeGreaterThan(30);
    const touched = await footprintOf(owner, tables, TENANT, vch);
    expect(touched.length, 'a return must write something').toBeGreaterThan(0);
    // Asserted as an exact SET, not a subset. This used to be a `toContain` loop over two tables,
    // which is why adding the Rojmel write here failed nothing - a subset assertion cannot see an
    // unexpected EXTRA write, and an extra write is how a duplicate ledger posting appears.
    expect(touched).toEqual(FOOTPRINT_SALE_RETURN);
    const legs = await ledgerLegs(owner, TENANT, vch);
    expect(legs.dr, 'the reversal must be posted').toBeGreaterThan(0);
    expect(legs.dr, 'and it must balance').toBeCloseTo(legs.cr, 2);
  });

  it('a return’s Rojmel reverses direction: metal comes back IN', async () => {
    const created = await createSaleReturn(runtime, returnInput(), returnLines);
    const vch = String(created.vchNo).padStart(5, '0');
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "IT_TYPE","SIGN","DR_AMT"::float dr,"CR_AMT"::float cr,"ITM_GWT"::float gwt
         FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vch,
    )) as Array<Record<string, unknown>>;
    const metal = rows.filter((r) => r.IT_TYPE !== 'A');
    expect(metal.length).toBeGreaterThan(0);
    // '+' not '-': the shop's metal position goes UP on a return. Inverting this would make a return
    // look like another sale in the day book and double the metal sold.
    expect(metal.every((r) => r.SIGN === '+')).toBe(true);
    expect(metal.every((r) => Number(r.gwt ?? 0) > 0)).toBe(true);
  });

  it('an order with an advance writes a type-01 Rojmel CREDIT; one without writes none', async () => {
    // Book 020 carries 41 real type-01 rows, all credits, with LD_CODE = the book's slot-1 account (00001
    // on the desktop). The row exists only when there is an advance - the same conditionality the ledger
    // already has, since an order is a commitment and only the advance is real money.
    const rojmelFor = async (vch: string): Promise<Array<Record<string, unknown>>> =>
      (await owner.$queryRawUnsafe(
        `SELECT "LEDR_KEY","AC_CODE","LD_CODE","IT_TYPE","SIGN",
                "DR_AMT"::float dr,"CR_AMT"::float cr
           FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SOR' AND "VCH_NO"=$2
          ORDER BY "LEDR_KEY"`,
        TENANT,
        vch,
      )) as Array<Record<string, unknown>>;

    const withAdv = await createSalesOrder(runtime, orderInput());
    const vchA = String(withAdv.vchNo).padStart(5, '0');
    const rowsA = await rojmelFor(vchA);
    expect(rowsA).toHaveLength(1);
    expect(String(rowsA[0]!.LEDR_KEY).slice(21, 23)).toBe('01');
    expect(rowsA[0]!.AC_CODE).toBe('CUST'); // the party
    expect(Number(rowsA[0]!.cr)).toBe(100); // the fixture's advance
    expect(Number(rowsA[0]!.dr)).toBe(0);
    expect(rowsA[0]!.IT_TYPE).toBe('A'); // money row, no metal
    // Header rows carry no line number: all real type-01 keys are 23 characters.
    expect(String(rowsA[0]!.LEDR_KEY)).toHaveLength(23);

    const noAdv = await createSalesOrder(runtime, orderInput({ advanceAmount: 0 }));
    expect(await rojmelFor(String(noAdv.vchNo).padStart(5, '0'))).toEqual([]);
  });

  it('the order footprint is an exact SET, so an extra write cannot pass unnoticed', async () => {
    // Asserted with toEqual, not toContain. A subset assertion cannot see an unexpected EXTRA write, and
    // an extra write is how a duplicate ledger posting appears - the weakness found in the sales-return
    // test and fixed there for the same reason.
    const created = await createSalesOrder(runtime, orderInput());
    const vch = String(created.vchNo).padStart(5, '0');
    const tables = await voucherTables(owner);
    const touched = await footprintOf(owner, tables, TENANT, vch);
    expect(touched).toEqual([
      'AC_DATA',
      // The day book. Added when the order projection was implemented from the real book-020 rows.
      'ROJ_MEL_DATA',
      'SL_ORD_DATA',
      'SL_ORD_DETL',
      // The fixture's line carries a stone sub-detail, so the order writes SL_ORD_IDTL too. Pinned
      // because the set is what the assertion is for - discovering it by failing is the intended loop.
      'SL_ORD_IDTL',
    ]);
  });

  it('re-posting an order does not collide on LEDR_KEY', async () => {
    // ROJ_MEL_DATA's primary key is LEDR_KEY alone. Two orders must produce distinct keys, and an edit
    // must delete before rewriting - 23505 is the failure mode, and it has bitten four times elsewhere.
    const a = await createSalesOrder(runtime, orderInput());
    const b = await createSalesOrder(runtime, orderInput());
    expect(b.vchNo).not.toBe(a.vchNo);
    const [n] = (await owner.$queryRawUnsafe(
      `SELECT count(DISTINCT "LEDR_KEY")::int n FROM "ROJ_MEL_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='SOR'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(n!.n).toBe(2);
  });

  it('a sales order posts the ledger only when it carries an advance', async () => {
    // My first version of this asserted an order NEVER posts to AC_DATA. That was wrong, and the source says
    // so: TR_SALE_ORD.cs:9558,9729 delete and rewrite AC_DATA rows, and the form carries ADV_AMT. An advance
    // is real money received, so it belongs in the ledger.
    //
    // The distinction that matters is therefore conditional, and testing it both ways is what makes it
    // meaningful: with an advance the ledger is posted and balanced; with none it is not touched at all. An
    // order that posted without an advance would inflate the books with work not yet done.
    const withAdvance = await createSalesOrder(runtime, orderInput());
    const vchA = String(withAdvance.vchNo).padStart(5, '0');
    const tables = await voucherTables(owner);
    expect(tables.length).toBeGreaterThan(30);

    const touchedA = await footprintOf(owner, tables, TENANT, vchA);
    expect(touchedA, 'an order must record itself').toContain('SL_ORD_DATA');
    expect(touchedA, 'the advance is real money and belongs in the ledger').toContain('AC_DATA');
    // An order is a commitment, not a taxable supply: no tax rows until it becomes a bill.
    expect(touchedA, 'an order must NOT write tax rows').not.toContain('TAX_DATA');

    const legsA = await ledgerLegs(owner, TENANT, vchA);
    expect(legsA.dr, 'the advance posting must balance').toBeCloseTo(legsA.cr, 2);
    expect(legsA.dr, 'and it must be non-zero when an advance was taken').toBeGreaterThan(0);

    const noAdvance = await createSalesOrder(runtime, orderInput({ advanceAmount: 0 }));
    const vchB = String(noAdvance.vchNo).padStart(5, '0');
    const touchedB = await footprintOf(owner, tables, TENANT, vchB);
    expect(touchedB, 'an order without an advance must still record itself').toContain(
      'SL_ORD_DATA',
    );
    expect(
      touchedB,
      'but with no money received there is nothing to post, so the ledger must be untouched',
    ).not.toContain('AC_DATA');
  });
  it('persists the desktop TR_SALE_LBR grid on a labour invoice line', async () => {
    // P7: LabourLine carried 6 fields while LBR_ISU_DETL has 113 columns and the desktop MSG grid has
    // 30. The operator could bill labour but none of the weight, touch, karigar or tag detail was
    // stored. This asserts the WRITER, because a field on the contract that the writer ignores is a
    // dead cell — the defect that put 12 fake columns on hallmark-sale before it was caught.
    const created = await createLabourInvoice(runtime, {
      scope: scope('LBR'),
      acCode: 'CUST',
      vchDate: DAY,
      mainUser: 'grid-owner',
      lines: [
        {
          itCode: 'GOLD',
          pcs: 2,
          grossWt: 12.5,
          otherWt: 0.5,
          netWt: 12,
          ghtWt: 1,
          touch: 91.6,
          westPct: 0.5,
          rate: 6000,
          labourType: 'G',
          labourRate: 50,
          labourPct: 3,
          otherAmount: 25,
          mrp: 90000,
          tagCost: 120,
          designNo: 'D-LBR-1',
          // Alphanumeric on purpose: a HUID with letters must survive.
          hallmarkId: 'HUID77XZ',
          tblCode: '007',
          itmSize: '16',
          itmColor: 'YG',
          bagWt: 0.08,
          karigarName: 'KR-1',
          karigarNetWt: 11.8,
          karigarTouch: 90,
          karigarWestPct: 1,
          karigarFine: 10.7,
          karigarLbrRate: 40,
          karigarLbrAmt: 472,
          employeeCode: 'E9',
          metalAmount: 1000,
          labourAmount: 600,
        },
      ],
    });
    const row = (
      (await owner.$queryRawUnsafe(
        `SELECT * FROM "LBR_ISU_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "SR_NO"=1`,
        TENANT,
        String(created.vchNo).padStart(5, '0'),
      )) as Array<Record<string, unknown>>
    )[0]!;

    expect(String(row.HM_ID)).toBe('HUID77XZ');
    expect(String(row.DESIGN_NO)).toBe('D-LBR-1');
    expect(String(row.TBL_CODE)).toBe('007');
    expect(String(row.ITM_COLOR)).toBe('YG');
    expect(String(row.KR_NAME)).toBe('KR-1');
    expect(String(row.EMP_CODE)).toBe('E9');
    expect(Number(row.ITM_GWT)).toBe(12.5);
    expect(Number(row.ITM_OTH_WT)).toBe(0.5);
    expect(Number(row.ITM_GHT_WT)).toBe(1);
    expect(Number(row.ITM_TOUCH)).toBe(91.6);
    expect(Number(row.ITM_WEST_PRC)).toBe(0.5);
    expect(Number(row.BAG_WT)).toBe(0.08);
    expect(Number(row.ITM_RATE)).toBe(6000);
    expect(Number(row.LBR_RATE)).toBe(50);
    expect(Number(row.LBR_PRC)).toBe(3);
    expect(Number(row.OTH_AMT)).toBe(25);
    expect(Number(row.ITM_MRP)).toBe(90000);
    expect(Number(row.TAG_COST)).toBe(120);
    expect(Number(row.KR_NET_WT)).toBe(11.8);
    expect(Number(row.KR_LBR_AMT)).toBe(472);
    // Fine follows the SHARED desktop policy, (net + ghat) x (touch + wastage) / 100, so a labour
    // bill agrees with every other voucher family rather than using a local formula.
    expect(Number(row.ITM_FINE)).toBe(
      fineFor('sale', { netWt: 12, ghtWt: 1, touch: 91.6, westPct: 0.5 }),
    );
  });
  it('writes the labour-invoice RECEIVE side, which had no writer at all', async () => {
    // P8: TR_SALE_LBR has TWO item grids — mSG (labour billed -> LBR_ISU_DETL) and mSG_PR (metal
    // received -> LBR_REC_DETL, 95 columns). The web wrote only the first. LBR_REC_DETL was already
    // listed in LABOUR_WRITE_TABLES, so deletes cleaned up a table nothing ever populated: the mirror
    // image of the write-without-read defect, declared-but-never-written.
    const created = await createLabourInvoice(runtime, {
      scope: scope('LBR'),
      acCode: 'CUST',
      vchDate: DAY,
      mainUser: 'receive-owner',
      lines: [{ itCode: 'GOLD', pcs: 1, netWt: 5, metalAmount: 500, labourAmount: 100 }],
      receiveLines: [
        {
          itCode: 'GOLD',
          sign: '+',
          pcs: 1,
          grossWt: 8.2,
          netWt: 8,
          otherWt: 0.2,
          bagWt: 0.05,
          ghtWt: 0.4,
          touch: 88,
          westPct: 1,
          lessTouch: 2,
          rate: 5900,
          amount: 47200,
          labourPct: 1.5,
          labourType: 'G',
          labourRate: 30,
          labourAmount: 240,
          otherAmount: 15,
          otherRate: 12,
          otherFine: 0.3,
          mrp: 60000,
          netAmount: 47455,
          totalAmount: 47455,
          taxPct: 3,
          tblCode: '004',
          designNo: 'D-REC-1',
          remark: 'old chain in',
        },
      ],
    });

    const rows = (await owner.$queryRawUnsafe(
      `SELECT * FROM "LBR_REC_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      TENANT,
      String(created.vchNo).padStart(5, '0'),
    )) as Array<Record<string, unknown>>;
    expect(rows.length).toBe(1);
    const row = rows[0]!;
    expect(String(row.ITM_SIGN)).toBe('+');
    expect(String(row.DESIGN_NO)).toBe('D-REC-1');
    expect(String(row.TBL_CODE)).toBe('004');
    expect(String(row.ITM_REMARK)).toBe('old chain in');
    expect(Number(row.ITM_GWT)).toBe(8.2);
    expect(Number(row.ITM_OTH_WT)).toBe(0.2);
    expect(Number(row.BAG_WT)).toBe(0.05);
    expect(Number(row.LESS_TOUCH)).toBe(2);
    expect(Number(row.ITM_OTH_RATE)).toBe(12);
    expect(Number(row.ITM_OTH_FINE)).toBe(0.3);
    expect(Number(row.LBR_AMT)).toBe(240);
    expect(Number(row.TOT_AMT)).toBe(47455);
    expect(Number(row.TAX_PRC)).toBe(3);
    // Metal coming in uses the desktop OLD-GOLD policy, which subtracts less-touch from
    // (touch + wastage) — so this agrees with the purchase screen instead of a second local formula.
    expect(Number(row.ITM_FINE)).toBe(
      fineFor('purchaseOldGold', {
        netWt: 8,
        ghtWt: 0.4,
        touch: 88,
        westPct: 1,
        lesTouch: 2,
      }),
    );

    // A cash-settled bill must NOT create receive rows, so the footprint stays honest.
    const cashOnly = await createLabourInvoice(runtime, {
      scope: scope('LBR'),
      acCode: 'CUST',
      vchDate: DAY,
      mainUser: 'receive-owner',
      lines: [{ itCode: 'GOLD', pcs: 1, netWt: 1, metalAmount: 100, labourAmount: 20 }],
    });
    const none = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "LBR_REC_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      String(cashOnly.vchNo).padStart(5, '0'),
    )) as Array<{ n: number }>;
    expect(none[0]!.n).toBe(0);
  });
});
