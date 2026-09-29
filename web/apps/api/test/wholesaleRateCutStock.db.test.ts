import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteWholesaleSale,
  editWholesaleSale,
  getRateCut,
  getWholesaleSale,
  postRateCut,
  postWholesaleSale,
} from '../src/modules/sales/rateCut.js';
import { tagAvailable } from '../src/modules/stock/stock.js';
import { lookup } from '../src/modules/masters/lookup.js';
import { saveWholesaleSaleReturn } from '../src/modules/sales/wholesaleSaleReturn.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * X16 — wholesale sale and rate cut write the desktop's stock movement and money legs.
 *
 * Every expected value comes from the desktop: the rows the 28 September evaluation captured from Next23
 * vouchers 034/4-6 and Next25 034/1, and the Live24 rate cut 064/00004 (spec-rate-cut.md §4.1). The books,
 * slots and account codes are the real ones (LC 00, BOOK_DETL 00003/00008/00001/00057/…). Contract:
 * parity-plan-2026-09-10/evidence/implementation-2026-09-29-x16/contract.md.
 */
d('wholesale sale / rate cut: stock movement and desktop ledger legs (X16)', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const TENANT = 'wh-rcut-stock-db';
  const CO = '01';
  const LC = '00';
  const YEAR = '2023-2024';
  const DAY = '2023-06-01';
  const USER = 'desk-user';
  const scopeFor = (coBook: string): VoucherScope => ({
    tenantId: TENANT,
    coCode: CO,
    lcCode: LC,
    coYear: YEAR,
    coBook,
  });
  const WH = scopeFor('034');
  const RC = scopeFor('064');

  const tables = [
    'DELETE_DATA',
    'ROJ_MEL_DATA',
    'AC_DATA',
    'DM_DATA',
    'SL_IDTL',
    'RATE_CUT_REC',
    'RATE_CUT_ISU',
    'RATE_CUT_DATA',
    'TEMP_BOOK_DATA',
    'MAIN_STOCK',
    'TAG_STOCK',
    'BAR_DETL',
    'ITEM_MAST',
    'AC_MAST',
    'BOOK_DETL',
    'BOOK_DATA',
    'SRNO_MAST',
    'YEAR_MAST',
    'CO_SET_NEW',
    'CO_SET',
  ];
  const sql = (query: string, ...params: unknown[]) =>
    owner.$executeRawUnsafe(query, TENANT, ...params);
  const rows = async (query: string, ...params: unknown[]): Promise<any[]> =>
    (await owner.$queryRawUnsafe(query, TENANT, ...params)) as any[];
  const cleanup = async () => {
    for (const table of tables) await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`);
  };

  /** A purchased tag: its BAR_DETL row and the '+' stock row that makes it available. */
  const tag = async (t: {
    tagNo: string;
    vchSrno: number;
    itCode: string;
    gwt: number;
    touch: number;
    west: number;
    krName: string;
    prCode: string;
    size?: string;
    hmId?: string;
    hmWt?: number;
    lbrType?: string;
    /** A stored fine that differs from the formula, to prove the tag's own figure is kept. */
    fine?: number;
    lbrRate?: number;
    othAmt?: number;
    mrp?: number;
    krCost?: number;
  }) => {
    await sql(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT",
         "ITM_OTH_WT","ITM_NWT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","TBL_CODE","KR_NET_WT",
         "KR_TOUCH","KR_FINE","KR_NAME","PR_CODE","ITM_SIZE","HM_ID","HM_ID_WT","LBR_TYPE",
         "RATE_TYPE","EMP_ISU","LBR_RATE","OTH_AMT","ITM_MRP","KR_COST")
       VALUES ($1,$2,$3,$4,'P01','00001',1,'2023-05-01','PURCHASE','I',$5,$6,$7,1,$8,0,$8,$9,$10,
               -- Numeric arithmetic: integer parameters would divide as integers (13 × 97 / 100 = 12).
               coalesce($17::numeric,round($8::numeric*($9::numeric+$10::numeric)/100,3)),'001',$8,0,$8,
               $11,$12,$13,$14,$15,$16,'G','N',$18,$19,$20,$21)`,
      CO,
      LC,
      YEAR,
      t.tagNo,
      t.vchSrno,
      t.itCode,
      t.gwt,
      t.touch,
      t.west,
      t.krName,
      t.prCode,
      t.size ?? '',
      t.hmId ?? '',
      t.hmWt ?? 0,
      t.lbrType ?? '',
      t.fine ?? null,
      t.lbrRate ?? 0,
      t.othAmt ?? 0,
      t.mrp ?? 0,
      t.krCost ?? 0,
    );
    await sql(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
         "ISR_NO","VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS",
         "ITM_GWT","ITM_NWT")
       VALUES ($1,$2,$3,$4,'P01','00001',2,1,'2023-05-01',$5,$6,$7,'P','+',1,1,$8,$8)`,
      CO,
      LC,
      YEAR,
      t.itCode,
      t.tagNo,
      t.vchSrno,
      t.gwt,
    );
  };

  const seed = async (tradeFine = '') => {
    await sql(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","RATE_PAR","LBR_TYPE","TRAD_FINE","LOCK_DATE",
         "EMP_CODE_MANDATORY","TAX_ROF","LBR_ROF","ITM_RATE_ROF")
       VALUES ($1,$2,'G','G',$3,NULL,'N',2,2,2)`,
      CO,
      tradeFine,
    );
    await sql(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,2,2)`,
      CO,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2023-04-01','2024-03-31'::timestamp)`,
      CO,
      YEAR,
    );
    await sql(
      `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO") VALUES ($1,$2,$3,'0','0')`,
      CO,
      LC,
    );
    // Books 034 WSALE / WH SALES and 064 RCUT / RATE CUT as the desktop stores them, plus a wholesale return.
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","DATA_TYPE")
       VALUES ($1,$2,$3,'034','Wh Sales','WSALE','WH SALES','O','Y','RATE_CUT_DATA','A'),
              ($1,$2,$3,'064','Rate Cut','RCUT','RATE CUT','O','Y','RATE_CUT_DATA','A'),
              ($1,$2,$3,'WRT','Wholesale Return','WRT','WH RTN','I','Y','RATE_CUT_DATA','A'),
              ($1,$2,$3,'RCT','Cash Receipt','CREC','CASH REC','I','Y','CASH_DATA','A')`,
      CO,
      LC,
    );
    // The real BOOK_DETL of 034/064 (rateCut.ts documents it): twelve slots.
    for (const book of ['034', '064'])
      for (const [srNo, account] of [
        [1, '00003'],
        [2, '00008'],
        [3, '00001'],
        [4, '00057'],
        [5, '00042'],
        [6, '00041'],
        [7, '00056'],
        [8, '00004'],
        [9, '00009'],
        [10, '00061'],
        [11, '00077'],
        [12, '00098'],
      ] as const)
        await sql(
          `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","DATA_TYPE")
           VALUES ($1,$2,$3,$4,$5,$6,'A')`,
          CO,
          LC,
          book,
          srNo,
          account,
        );
    for (const [srNo, account] of [
      [1, '00003'],
      [3, '00001'],
      [4, '00041'],
      [5, '00057'],
      [6, '00077'],
    ] as const)
      await sql(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK",
           "BOOK_INOUT","DATA_TYPE") VALUES ($1,$2,$3,'WRT',$4,$5,'WH RTN','I','A')`,
        CO,
        LC,
        srNo,
        account,
      );
    // 000209's mobile is the 9856525 the desktop copied onto all three Next23 vouchers.
    for (const [code, name, mobile] of [
      ['000209', 'SS', '9856525'],
      ['000202', 'SS', ''],
      ['000286', 'DEV JEWELLERS', ''],
      ['00001', 'CASH ON HAND', ''],
      ['00003', 'SALES GOLD A/C', ''],
      ['00008', 'PURCHASE GOLD A/C', ''],
      ['00057', 'KASAR JAVK A/C', ''],
      ['00077', 'OTHER CHARGES', ''],
    ])
      await sql(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MOBILE")
         VALUES ($1,$2,$3,$4,$5,$6)`,
        CO,
        LC,
        code,
        name,
        mobile,
      );
    for (const [code, name, prCode] of [
      ['LR916', 'L RING 916', 'LR'],
      ['CH916', 'CHAIN 916', 'CH'],
      ['GR18K', 'GENTS RING 18K', 'GR'],
      ['999', '999 GOLD', 'FN'],
    ])
      await sql(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE")
         VALUES ($1,$2,$3,$4,'G',$5,'G')`,
        CO,
        code,
        name,
        prCode,
      );
    // The tags of Next23 034/4 and 034/6 and Next25 034/1, with the attributes the desktop copied.
    await tag({
      tagNo: 'LRG00001',
      vchSrno: 100312000009,
      itCode: 'LR916',
      gwt: 12.3,
      touch: 92,
      west: 5,
      krName: 'KJ',
      prCode: 'LR',
    });
    await tag({
      tagNo: 'LRG00002',
      vchSrno: 100312000010,
      itCode: 'LR916',
      gwt: 13,
      touch: 92,
      west: 5,
      krName: 'AB',
      prCode: 'LR',
    });
    await tag({
      tagNo: 'CHG00002',
      vchSrno: 100312000004,
      itCode: 'CH916',
      gwt: 12,
      touch: 92,
      west: 4,
      krName: 'SJ',
      prCode: 'CH',
      size: '3',
      hmId: 'UY76UY',
      hmWt: 12,
    });
    await tag({
      tagNo: 'CHG00003',
      vchSrno: 100312000005,
      itCode: 'CH916',
      gwt: 14,
      touch: 92,
      west: 4,
      krName: 'KJ',
      prCode: 'CH',
      size: '3',
    });
    // Next25's GR18K tag; weights are synthetic (the harness recorded its fine only): 11.9 × 90.7% = 10.793.
    await tag({
      tagNo: 'GRG00001',
      vchSrno: 100512000001,
      itCode: 'GR18K',
      gwt: 11.9,
      touch: 75,
      west: 15.7,
      krName: 'YT',
      prCode: 'GR',
      lbrType: 'N',
    });
    // A tag carrying its own labour rate, other charges, MRP and cost, and a stored fine (9.500) that is not the
    // formula's 10 × 92 / 100 = 9.200 — the desktop copies the tag's figures and keeps its fine (:10641-10736).
    await tag({
      tagNo: 'MKG00001',
      vchSrno: 100312000077,
      itCode: 'LR916',
      gwt: 10,
      touch: 92,
      west: 0,
      krName: 'KJ',
      prCode: 'LR',
      lbrType: 'N',
      fine: 9.5,
      lbrRate: 150,
      othAmt: 300,
      mrp: 25000,
      krCost: 18000,
    });
    // A web-created tag that lives only in TAG_STOCK, reserved by removing its row.
    await sql(
      `INSERT INTO "TAG_STOCK"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IT_TYPE","PR_CODE",
         "DESIGN_NO","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_NWT","STK_TYPE")
       VALUES ($1,$2,$3,'WEB0001',7,'G','LR','D-7','5',1,8,8,'R')`,
      CO,
      LC,
    );
  };

  const base = (scope: VoucherScope, acCode = '000209') => ({
    scope,
    mainUser: USER,
    vchDate: DAY,
    acCode,
    acName: 'SS',
    empCode: '001',
    itType: 'G' as const,
  });
  const available = (tagNo: string) =>
    tagAvailable(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC, TAG_NO: tagNo });
  const ledger = (book: string, vchNo: string) =>
    rows(
      `SELECT right("LEDR_KEY",2) AS leg,"LEDR_KEY","AC_CODE" AS ac,"LD_CODE" AS ld,"DR_AMT"::float8 AS dr,
              "CR_AMT"::float8 AS cr,"IT_TYPE" AS it,"SIGN" AS sign,"FINE_WT"::float8 AS fine,
              "FINE_RATE"::float8 AS rate,"PARTY_AC_CODE" AS party,"VCH_TYPE","BOOK_NAME"
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "LEDR_KEY"`,
      book,
      vchNo,
    );
  const legs = async (book: string, vchNo: string) =>
    (await ledger(book, vchNo)).map(({ leg, ac, ld, dr, cr, it, sign, fine, rate, party }) => ({
      leg,
      ac,
      ld,
      dr,
      cr,
      it,
      sign,
      fine,
      rate,
      party,
    }));
  const stock = (book: string, vchNo: string) =>
    rows(
      `SELECT "SR_NO"::int AS sr,"ISR_NO"::int AS isr,"TR_TYPE" AS tr,"ITM_SIGN" AS sign,"IT_CODE" AS it,
              "TAG_NO" AS tag,"VCH_SRNO"::float8 AS id,"TBL_CODE" AS tbl,"ITM_QTY"::float8 AS qty,
              "ITM_GWT"::float8 AS gwt,"ITM_NWT"::float8 AS nwt,"ITM_TOUCH"::float8 AS touch,
              "ITM_WEST"::float8 AS west,"ITM_FINE"::float8 AS fine,"ITM_MRP"::float8 AS mrp,
              "NET_AMT"::float8 AS net,"KR_NWT"::float8 AS kr_nwt,"KR_TOUCH"::float8 AS kr_touch,
              "KR_FINE"::float8 AS kr_fine,"KR_COST"::float8 AS kr_cost,"VCH_TYPE","BOOK_NAME",
              "AC_CODE","ITM_DESC","EMP_CODE","MAIN_USER","DATA_TYPE","ITM_LOT","STK_DATE"
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO","ISR_NO"`,
      book,
      vchNo,
    );
  const head = async (book: string, vchNo: string) =>
    (
      await rows(
        `SELECT "DR_AMT"::float8 AS dr_amt,"CR_AMT"::float8 AS cr_amt,"DR_FINE"::float8 AS dr_fine,
                "CR_FINE"::float8 AS cr_fine,"FINE_RATE"::float8 AS fine_rate,"SL_FINE"::float8 AS sl_fine,
                "PR_FINE"::float8 AS pr_fine,"TOT_FINE_DR"::float8 AS tot_dr,"TOT_FINE_CR"::float8 AS tot_cr,
                "SL_NET_AMT"::float8 AS sl_net,"SL_TOT_AMT"::float8 AS sl_tot,"PR_NET_AMT"::float8 AS pr_net,
                "SL_BILL_OS"::float8 AS sl_os,"PR_BILL_OS"::float8 AS pr_os,"SL_OTH_AMT"::float8 AS sl_oth,
                "SL_TAX_AMT"::float8 AS sl_tax,"TAX_PRC"::float8 AS tax_prc,"MAIN_USER",
                to_char("VCH_TIME",'YYYY-MM-DD') AS vch_day,to_char("VCH_TIME",'HH24:MI:SS.MS') AS clock
           FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        book,
        vchNo,
      )
    )[0];

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
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('V1 034/4 — tags sold by number move out of stock with their identity, and post leg 23 alone', async () => {
    const created = await postWholesaleSale(runtime, {
      ...base(WH),
      lines: [{ tagNo: 'LRG00001' }, { tagNo: 'LRG00002' }],
    });
    expect(created).toMatchObject({ vchNo: 1, fine: 24.541, netAmt: 0 });

    // The tag fills the line as the desktop grid does: item, weights, touch, wastage, counter, karigar.
    const isu = await rows(
      `SELECT "SR_NO"::int AS sr,"TAG_NO","VCH_SRNO"::float8 AS id,"IT_CODE","TBL_CODE","KR_NAME","PR_CODE",
              "ITM_REMARK","ITM_GWT"::float8 AS gwt,"ITM_FINE"::float8 AS fine,"TAG_GWT"::float8 AS tag_gwt,
              "TOT_AMT"::float8 AS tot,"FINE_CUT_PCS"::float8 AS cut_pcs,"EMP_CODE","MAIN_USER",
              "RATE_TYPE","ENTRY_TYPE"
         FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_BOOK"='034' ORDER BY "SR_NO"`,
    );
    const shared = {
      IT_CODE: 'LR916',
      TBL_CODE: '001',
      PR_CODE: 'LR',
      ITM_REMARK: 'L RING 916',
      tot: 0,
      cut_pcs: 0,
      EMP_CODE: '001',
      MAIN_USER: USER,
      RATE_TYPE: 'G',
      ENTRY_TYPE: 'W',
    };
    expect(isu).toEqual([
      {
        sr: 1,
        TAG_NO: 'LRG00001',
        id: 100312000009,
        KR_NAME: 'KJ',
        gwt: 12.3,
        fine: 11.931,
        tag_gwt: 12.3,
        ...shared,
      },
      {
        sr: 2,
        TAG_NO: 'LRG00002',
        id: 100312000010,
        KR_NAME: 'AB',
        gwt: 13,
        fine: 12.61,
        tag_gwt: 13,
        ...shared,
      },
    ]);

    expect(await head('034', '00001')).toMatchObject({
      dr_amt: 0,
      cr_fine: 0,
      sl_fine: 24.541,
      tot_dr: 24.541,
      tot_cr: 0,
      sl_net: 0,
      sl_os: 0,
      MAIN_USER: USER,
      vch_day: DAY,
    });
    // Desktop: exactly one AC_DATA row, 01002023-20240340000423 (voucher 4 there, 1 here).
    const ac = await ledger('034', '00001');
    expect(ac.map((row) => row.LEDR_KEY)).toEqual(['01002023-20240340000123']);
    expect(await legs('034', '00001')).toEqual([
      {
        leg: '23',
        ac: '000209',
        ld: '00003',
        dr: 0,
        cr: 0,
        it: 'G',
        sign: '-',
        fine: 24.541,
        rate: 0,
        party: '000209',
      },
    ]);
    expect(ac[0]).toMatchObject({ VCH_TYPE: 'WSALE', BOOK_NAME: 'WH SALES' });

    const common = {
      sr: 1,
      tr: 'S',
      sign: '-',
      it: 'LR916',
      tbl: '001',
      qty: 1,
      touch: 92,
      west: 5,
      mrp: 0,
      net: 0,
      kr_touch: 0,
      kr_cost: 0,
      VCH_TYPE: 'WSALE',
      BOOK_NAME: 'WH SALES',
      AC_CODE: '000209',
      ITM_DESC: 'L RING 916',
      EMP_CODE: '001',
      MAIN_USER: USER,
      DATA_TYPE: 'A',
      STK_DATE: DAY,
    };
    expect((await stock('034', '00001')).map(({ ITM_LOT: _lot, ...row }) => row)).toEqual([
      {
        ...common,
        isr: 1,
        tag: 'LRG00001',
        id: 100312000009,
        gwt: 12.3,
        nwt: 12.3,
        fine: 11.931,
        kr_nwt: 12.3,
        kr_fine: 12.3,
      },
      {
        ...common,
        isr: 2,
        tag: 'LRG00002',
        id: 100312000010,
        gwt: 13,
        nwt: 13,
        fine: 12.61,
        kr_nwt: 13,
        kr_fine: 13,
      },
    ]);
    expect(await available('LRG00001')).toBe(false);
    expect(await available('LRG00002')).toBe(false);
  });

  it('a tag brings its labour, other charges, MRP, cost and stored fine; a priced line is settled in rupees', async () => {
    await postWholesaleSale(runtime, {
      ...base(WH),
      lines: [
        { tagNo: 'MKG00001' },
        // A loose priced line: 10 × 91.6 % = 9.160 at 6000 = Math.Round(54960) = 54960.
        { itCode: 'LR916', netWt: 10, touch: 91.6, rate: 6000 },
      ],
    });
    const isu = await rows(
      `SELECT "SR_NO"::int AS sr,"ITM_FINE"::float8 AS fine,"LBR_TYPE","LBR_RATE"::float8 AS lbr_rate,
              "LBR_AMT"::float8 AS lbr,"OTH_AMT"::float8 AS oth,"ITM_AMT"::float8 AS amt,"ITM_MRP"::float8 AS mrp,
              "TAG_COST"::float8 AS cost,"NET_AMT"::float8 AS net,"TOT_AMT"::float8 AS tot
         FROM "RATE_CUT_ISU" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
    );
    expect(isu).toEqual([
      // Stored fine 9.500 kept; net-wise labour (LBR_WITH_GHT blank = Y) Math.Round((10 + 0) × 150) = 1500;
      // net = 1500 + 300 + 0 (col 41); MRP is informational on a gold voucher.
      {
        sr: 1,
        fine: 9.5,
        LBR_TYPE: 'N',
        lbr_rate: 150,
        lbr: 1500,
        oth: 300,
        amt: 0,
        mrp: 25000,
        cost: 18000,
        net: 1800,
        tot: 0,
      },
      // A loose row starts with the company labour basis (CommPassAdd col 34 = MsLbrType 'G').
      {
        sr: 2,
        fine: 9.16,
        LBR_TYPE: 'G',
        lbr_rate: 0,
        lbr: 0,
        oth: 0,
        amt: 54960,
        mrp: 0,
        cost: 0,
        net: 54960,
        tot: 0,
      },
    ]);
    // SL_FINE counts only the unpriced line (TR_WH_SALE.cs:8344-8346); the priced 9.160 is sold for 54960.
    expect(await head('034', '00001')).toMatchObject({
      sl_fine: 9.5,
      tot_dr: 9.5,
      sl_net: 56760,
      sl_os: 56760,
    });
    expect(
      (await legs('034', '00001')).map((l) => [l.leg, l.ac, l.ld, l.dr, l.cr, l.fine]),
    ).toEqual([
      ['01', '000209', '00003', 54960, 0, 0],
      ['02', '00003', '000209', 0, 54960, 0],
      ['15', '000209', '00041', 1500, 0, 0],
      ['16', '00041', '000209', 0, 1500, 0],
      ['17', '000209', '00077', 300, 0, 0],
      ['18', '00077', '000209', 0, 300, 0],
      ['23', '000209', '00003', 0, 0, 9.5],
    ]);
    // Both pieces leave stock with their own fine, priced or not.
    expect(
      (await stock('034', '00001')).map((s) => [s.tag, s.fine, s.mrp, s.kr_cost, s.net]),
    ).toEqual([
      ['MKG00001', 9.5, 25000, 18000, 1800],
      ['N', 9.16, 0, 0, 54960],
    ]);
    // Choosing the party fills its mobile from the account master (TR_WH_SALE.cs:14623).
    expect(await rows(`SELECT "AC_NAME","MOBILE" FROM "RATE_CUT_DATA" WHERE tenant_id=$1`)).toEqual(
      [{ AC_NAME: 'SS', MOBILE: '9856525' }],
    );
  });

  it('the tag picker offers only tags that can be issued, with the figures the grid fills', async () => {
    const find = (term: string, lcCode = LC) =>
      lookup(runtime, TENANT, 'available-tags', term, CO, 20, { lcCode });
    const before = await find('LRG');
    expect(before.map((row) => row.code)).toEqual(['LRG00001', 'LRG00002']);
    expect(before[0]).toMatchObject({
      name: 'LR916 · L RING 916',
      IT_CODE: 'LR916',
      VCH_SRNO: 100312000009,
      ITM_GWT: 12.3,
      ITM_TOUCH: 92,
      ITM_WEST_PRC: 5,
      ITM_FINE: 11.931,
      TBL_CODE: '001',
      KR_NAME: 'KJ',
      source: 'BAR_DETL',
    });
    await postWholesaleSale(runtime, { ...base(WH), lines: [{ tagNo: 'LRG00001' }] });
    // The sold tag drops out, as the desktop's HAVING SUM(...) > 0 help drops it (TR_WH_SALE.cs:10601).
    expect((await find('LRG')).map((row) => row.code)).toEqual(['LRG00002']);
    // A tag created on the web lives only in TAG_STOCK and is offered too.
    expect((await find('WEB')).map((row) => [row.code, row.source, row.ITM_GWT])).toEqual([
      ['WEB0001', 'TAG_STOCK', 8],
    ]);
    // Another location's stock is not offered.
    expect(await find('LRG', '99')).toEqual([]);
  });

  it('W1 a sold tag cannot be sold again, and one voucher cannot carry the same tag twice', async () => {
    await postWholesaleSale(runtime, { ...base(WH), lines: [{ tagNo: 'LRG00001' }] });
    await expect(
      postWholesaleSale(runtime, { ...base(WH), lines: [{ tagNo: 'LRG00001' }] }),
    ).rejects.toMatchObject({ name: 'TagNotAvailableError' });
    await expect(
      postWholesaleSale(runtime, {
        ...base(WH),
        lines: [{ tagNo: 'LRG00002' }, { tagNo: 'LRG00002' }],
      }),
    ).rejects.toThrow(/more than once/);
    // The same instance named two ways — once by number, once with its VCH_SRNO — is still one tag. A BAR_DETL
    // tag would otherwise pass the second reservation, because the first line's '-' row is written only at the end.
    await expect(
      postWholesaleSale(runtime, {
        ...base(WH),
        lines: [{ tagNo: 'LRG00002' }, { tagNo: 'LRG00002', vchSrno: 100312000010 }],
      }),
    ).rejects.toThrow(/more than once/);
    // Nothing of the refused vouchers survived, and LRG00002 is still in stock.
    expect(await rows(`SELECT "VCH_NO" FROM "RATE_CUT_DATA" WHERE tenant_id=$1`)).toEqual([
      { VCH_NO: '00001' },
    ]);
    expect(await available('LRG00002')).toBe(true);
  });

  it('W3/W2 an edit gives back a dropped tag and keeps the clock and user; delete gives back the rest and audits', async () => {
    await postWholesaleSale(runtime, {
      ...base(WH),
      lines: [{ tagNo: 'LRG00001' }, { tagNo: 'LRG00002' }],
    });
    const before = await head('034', '00001');
    await editWholesaleSale(
      runtime,
      { ...base(WH), mainUser: 'other-user', lines: [{ tagNo: 'LRG00002' }] },
      1,
    );
    expect(await available('LRG00001')).toBe(true);
    expect(await available('LRG00002')).toBe(false);
    expect((await stock('034', '00001')).map((row) => [row.tag, row.sign])).toEqual([
      ['LRG00002', '-'],
    ]);
    // A reopened voucher keeps its own time and MAIN_USER (TR_WH_SALE.cs:12196, :12325).
    expect(await head('034', '00001')).toMatchObject({
      sl_fine: 12.61,
      MAIN_USER: USER,
      clock: before.clock,
    });
    expect(await rows(`SELECT count(*)::int AS n FROM "DELETE_DATA" WHERE tenant_id=$1`)).toEqual([
      { n: 0 },
    ]);

    await deleteWholesaleSale(runtime, { scope: WH, vchNo: 1, deleteUser: 'deleter' });
    expect(await available('LRG00002')).toBe(true);
    expect(await stock('034', '00001')).toEqual([]);
    const audit = await rows(
      `SELECT "SR_NO"::int AS sr,"VCH_TYPE","BOOK_NAME","AC_CODE","AC_NAME","VCH_VAL_DR"::float8 AS val_dr,
              "VCH_VAL_CR"::float8 AS val_cr,"FINE_TYPE","VCH_FINE_DR"::float8 AS fine_dr,
              "VCH_FINE_CR"::float8 AS fine_cr,"MAIN_USER","DELETE_USER",left("VCH_DATE"::text,10) AS day
         FROM "DELETE_DATA" WHERE tenant_id=$1`,
    );
    // TR_WH_SALE.cs:13569 — BOOK_NAME is the book's display name; the fines are TOT_FINE_DR / TOT_FINE_CR.
    expect(audit).toEqual([
      {
        sr: 0,
        VCH_TYPE: 'WSALE',
        BOOK_NAME: 'Wh Sales',
        AC_CODE: '000209',
        AC_NAME: 'SS',
        val_dr: 0,
        val_cr: 0,
        FINE_TYPE: 'G',
        fine_dr: 12.61,
        fine_cr: 0,
        MAIN_USER: USER,
        DELETE_USER: 'deleter',
        day: DAY,
      },
    ]);
  });

  it('a TAG_STOCK-only tag is removed on sale and re-inserted with its weights on delete', async () => {
    await postWholesaleSale(runtime, {
      ...base(WH),
      lines: [{ tagNo: 'WEB0001', itCode: 'LR916' }],
    });
    expect(await rows(`SELECT count(*)::int AS n FROM "TAG_STOCK" WHERE tenant_id=$1`)).toEqual([
      { n: 0 },
    ]);
    const [line] = await rows(
      `SELECT "VCH_SRNO"::float8 AS id,"DESIGN_NO","ITM_SIZE","PR_CODE","ITM_GWT"::float8 AS gwt
         FROM "RATE_CUT_ISU" WHERE tenant_id=$1`,
    );
    expect(line).toEqual({ id: 7, DESIGN_NO: 'D-7', ITM_SIZE: '5', PR_CODE: 'LR', gwt: 8 });
    await deleteWholesaleSale(runtime, { scope: WH, vchNo: 1 });
    expect(
      await rows(
        `SELECT "TAG_NO","VCH_SRNO"::float8 AS id,"ITM_GWT"::float8 AS gwt,"ITM_NWT"::float8 AS nwt,
                "DESIGN_NO","STK_TYPE" FROM "TAG_STOCK" WHERE tenant_id=$1`,
      ),
    ).toEqual([{ TAG_NO: 'WEB0001', id: 7, gwt: 8, nwt: 8, DESIGN_NO: 'D-7', STK_TYPE: 'R' }]);
  });

  it('V2 034/5 — received 24.000 and 0.541 cut at 6500: DR_AMT 3517 and legs 01/02/29/43/44', async () => {
    const created = await postWholesaleSale(runtime, {
      ...base(WH),
      lines: [],
      receivedLines: [{ itCode: '999', grossWt: 24, netWt: 24, touch: 100 }],
      fineRate: 6500,
      settleCrFine: 0.541,
      pay: { cash: 3517 },
    });
    // 0.541 × 6500 is 3516.5000000000005 in double arithmetic; Math.Round gives 3517, as the desktop stores.
    expect(created.settlement).toMatchObject({ drAmt: 3517, crFine: 0.541, fineRate: 6500 });
    expect(await head('034', '00001')).toMatchObject({
      dr_amt: 3517,
      cr_fine: 0.541,
      fine_rate: 6500,
      sl_fine: 0,
      pr_fine: 24,
      tot_dr: 0,
      tot_cr: 24.541,
      sl_net: 3517,
      sl_tot: 3517,
      sl_os: 0,
      pr_net: 0,
      sl_tax: 0,
      tax_prc: 0,
    });
    expect(await legs('034', '00001')).toEqual([
      {
        leg: '01',
        ac: '000209',
        ld: '00003',
        dr: 3517,
        cr: 0,
        it: 'G',
        sign: '+',
        fine: 0.541,
        rate: 6500,
        party: '000209',
      },
      {
        leg: '02',
        ac: '00003',
        ld: '000209',
        dr: 0,
        cr: 3517,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 6500,
        party: '',
      },
      {
        leg: '29',
        ac: '000209',
        ld: '00008',
        dr: 0,
        cr: 0,
        it: 'G',
        sign: '+',
        fine: 24,
        rate: 0,
        party: '000209',
      },
      {
        leg: '43',
        ac: '000209',
        ld: '00001',
        dr: 0,
        cr: 3517,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '000209',
      },
      {
        leg: '44',
        ac: '00001',
        ld: '000209',
        dr: 3517,
        cr: 0,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '',
      },
    ]);
    const [received] = await stock('034', '00001');
    expect(received).toMatchObject({
      sr: 2,
      isr: 1,
      tr: 'P',
      sign: '+',
      it: '999',
      tag: 'N',
      id: 0,
      qty: 1,
      gwt: 24,
      nwt: 24,
      touch: 100,
      fine: 24,
      mrp: 0,
      kr_nwt: 24,
      kr_touch: 100,
      kr_fine: 24,
      kr_cost: 0,
      ITM_LOT: '',
      ITM_DESC: '999 GOLD',
    });
    // The receive row as TR_WH_SALE writes it (Next23 034/5 differences, all closed).
    const [rec] = await rows(
      `SELECT "LBR_TYPE","ITM_REMARK","HM_ID_WT"::float8 AS hm_wt,"HM_ID2","ISU_LC_CODE","EMP_CODE",
              "TAG_NWT"::float8 AS tag_nwt,"OLD_VCH_SRNO"::float8 AS old_srno,"APR_ISU","EMP_ISU",
              "FINE_CUT_PCS"::float8 AS cut_pcs,"MAIN_USER"
         FROM "RATE_CUT_REC" WHERE tenant_id=$1`,
    );
    expect(rec).toEqual({
      LBR_TYPE: 'G',
      ITM_REMARK: '999 GOLD',
      hm_wt: 0,
      HM_ID2: null,
      ISU_LC_CODE: null,
      EMP_CODE: '001',
      tag_nwt: 0,
      old_srno: 0,
      APR_ISU: 'N',
      EMP_ISU: 'N',
      cut_pcs: 0,
      MAIN_USER: USER,
    });
    // The reopened voucher returns the settlement it stored.
    expect(await getWholesaleSale(runtime, WH, 1)).toMatchObject({
      fineRate: 6500,
      settleDrAmt: 3517,
      settleCrFine: 0.541,
      fineCr: 24.541,
    });
  });

  it('V3 034/6 — two tags, 20.000 received, 4.960 cut at 6500: legs 01/02/23/29 and three stock rows', async () => {
    await postWholesaleSale(runtime, {
      ...base(WH),
      lines: [{ tagNo: 'CHG00002' }, { tagNo: 'CHG00003' }],
      receivedLines: [{ itCode: '999', grossWt: 20, netWt: 20, touch: 100 }],
      fineRate: 6500,
      settleCrFine: 4.96,
    });
    expect(await head('034', '00001')).toMatchObject({
      dr_amt: 32240,
      sl_fine: 24.96,
      pr_fine: 20,
      tot_dr: 24.96,
      tot_cr: 24.96,
      sl_net: 32240,
      sl_os: 32240,
    });
    expect(
      (await legs('034', '00001')).map((row) => [
        row.leg,
        row.ac,
        row.dr,
        row.cr,
        row.sign,
        row.fine,
        row.rate,
      ]),
    ).toEqual([
      ['01', '000209', 32240, 0, '+', 4.96, 6500],
      ['02', '00003', 0, 32240, '', 0, 6500],
      ['23', '000209', 0, 0, '-', 24.96, 0],
      ['29', '000209', 0, 0, '+', 20, 0],
    ]);
    expect(
      (await stock('034', '00001')).map((row) => [row.sr, row.it, row.tag, row.sign, row.fine]),
    ).toEqual([
      [1, 'CH916', 'CHG00002', '-', 11.52],
      [1, 'CH916', 'CHG00003', '-', 13.44],
      [2, '999', 'N', '+', 20],
    ]);
    // CHG00002 carries its size and hallmark from the tag: ITM_SIZE 3, HM_ID UY76UY, HM_ID_WT 12.000.
    expect(
      await rows(
        `SELECT "TAG_NO","ITM_SIZE","HM_ID","HM_ID_WT"::float8 AS hm_wt,"KR_NAME","PR_CODE","ITM_REMARK"
           FROM "RATE_CUT_ISU" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      ),
    ).toEqual([
      {
        TAG_NO: 'CHG00002',
        ITM_SIZE: '3',
        HM_ID: 'UY76UY',
        hm_wt: 12,
        KR_NAME: 'SJ',
        PR_CODE: 'CH',
        ITM_REMARK: 'CHAIN 916',
      },
      {
        TAG_NO: 'CHG00003',
        ITM_SIZE: '3',
        HM_ID: '',
        hm_wt: 0,
        KR_NAME: 'KJ',
        PR_CODE: 'CH',
        ITM_REMARK: 'CHAIN 916',
      },
    ]);
  });

  it('V4 Next25 034/1 — other charges on a tag: legs 17/18 on slot 11, NET_AMT 500 with TOT_AMT 0', async () => {
    await postWholesaleSale(runtime, {
      ...base(WH, '000202'),
      lines: [{ tagNo: 'GRG00001', othAmt: 500 }],
    });
    expect(await legs('034', '00001')).toEqual([
      {
        leg: '17',
        ac: '000202',
        ld: '00077',
        dr: 500,
        cr: 0,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '000202',
      },
      {
        leg: '18',
        ac: '00077',
        ld: '000202',
        dr: 0,
        cr: 500,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '',
      },
      {
        leg: '23',
        ac: '000202',
        ld: '00003',
        dr: 0,
        cr: 0,
        it: 'G',
        sign: '-',
        fine: 10.793,
        rate: 0,
        party: '000202',
      },
    ]);
    expect(
      (
        await rows(
          `SELECT "VCH_SRNO"::float8 AS id,"TBL_CODE","LBR_TYPE","KR_NAME","PR_CODE","ITM_REMARK",
                  "NET_AMT"::float8 AS net,"TOT_AMT"::float8 AS tot,"FINE_CUT_PCS"::float8 AS cut_pcs
             FROM "RATE_CUT_ISU" WHERE tenant_id=$1`,
        )
      )[0],
    ).toEqual({
      id: 100512000001,
      TBL_CODE: '001',
      LBR_TYPE: 'N',
      KR_NAME: 'YT',
      PR_CODE: 'GR',
      ITM_REMARK: 'GENTS RING 18K',
      net: 500,
      tot: 0,
      cut_pcs: 0,
    });
    expect(await head('034', '00001')).toMatchObject({ sl_oth: 500, sl_net: 500, sl_tot: 500 });
    expect((await stock('034', '00001')).map((row) => [row.it, row.sign, row.net])).toEqual([
      ['GR18K', '-', 500],
    ]);
  });

  it('V6 Live24 064/00004 — a header-only purchase-side cut posts the six real legs and four real Rojmel rows', async () => {
    const created = await postRateCut(runtime, {
      ...base(RC, '000286'),
      acName: 'DEV JEWELLERS',
      lines: [],
      receivedLines: [],
      fineRate: 7300,
      settleDrFine: 2.05,
      receivedPay: { cash: 15800, kasar: 15 },
    });
    expect(created.settlement).toMatchObject({ crAmt: 14965, drFine: 2.05 });
    expect(await head('064', '00001')).toMatchObject({
      cr_amt: 14965,
      dr_fine: 2.05,
      fine_rate: 7300,
      pr_net: 14965,
      pr_os: -850,
      tot_dr: 2.05,
      tot_cr: 0,
    });
    expect(await legs('064', '00001')).toEqual([
      {
        leg: '08',
        ac: '000286',
        ld: '00008',
        dr: 0,
        cr: 14965,
        it: 'G',
        sign: '-',
        fine: 2.05,
        rate: 7300,
        party: '000286',
      },
      {
        leg: '09',
        ac: '00008',
        ld: '000286',
        dr: 14965,
        cr: 0,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '',
      },
      {
        leg: '45',
        ac: '000286',
        ld: '00001',
        dr: 15800,
        cr: 0,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '000286',
      },
      {
        leg: '46',
        ac: '00001',
        ld: '000286',
        dr: 0,
        cr: 15800,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '',
      },
      {
        leg: '51',
        ac: '000286',
        ld: '00057',
        dr: 15,
        cr: 0,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '000286',
      },
      {
        leg: '52',
        ac: '00057',
        ld: '000286',
        dr: 0,
        cr: 15,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 0,
        party: '',
      },
    ]);
    // rojmel.ts samples these real rows of 064/00004: t13 party/00008 G '-' dr 850 fine 2.050 rate 7300 and
    // t26 00042/party cr 15; t01 carries the fine at the rate and t02 the purchase amount.
    expect(
      await rows(
        `SELECT right("LEDR_KEY",2) AS t,"AC_CODE" AS ac,"LD_CODE" AS ld,"DR_AMT"::float8 AS dr,
                "CR_AMT"::float8 AS cr,"SIGN" AS sign,"ITM_FINE"::float8 AS fine,"ITM_RATE"::float8 AS rate
           FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='064' ORDER BY "LEDR_KEY"`,
      ),
    ).toEqual([
      { t: '01', ac: '000286', ld: '00008', dr: 0, cr: 0, sign: '-', fine: 2.05, rate: 7300 },
      { t: '02', ac: '00008', ld: '000286', dr: 14965, cr: 0, sign: '', fine: 0, rate: 0 },
      { t: '13', ac: '000286', ld: '00008', dr: 850, cr: 0, sign: '-', fine: 2.05, rate: 7300 },
      { t: '26', ac: '00042', ld: '000286', dr: 0, cr: 15, sign: '', fine: 0, rate: 0 },
    ]);
    expect(await stock('064', '00001')).toEqual([]);
  });

  it('W5 CO_SET.TRAD_FINE = Y adds the mirrored fine legs', async () => {
    await cleanup();
    await seed('Y');
    await postRateCut(runtime, {
      ...base(RC, '000286'),
      lines: [],
      fineRate: 7300,
      settleDrFine: 2.05,
    });
    expect(
      (await legs('064', '00001')).map((row) => [row.leg, row.ac, row.sign, row.fine]),
    ).toEqual([
      ['08', '000286', '-', 2.05],
      ['09', '00008', '', 0],
      ['10', '00003', '+', 2.05],
    ]);
  });

  it('W9 each menu posts only to its own book, as CurBookHelp scopes it (MDI_FORM.cs:8038-8118)', async () => {
    const line = [{ itCode: '999', netWt: 1, touch: 100, rate: 1 }];
    // The cash Receipt book, which the Rate Cut screen used to preselect.
    await expect(postRateCut(runtime, { ...base(scopeFor('RCT')), lines: line })).rejects.toThrow(
      /use a rate cut book/,
    );
    await expect(
      postWholesaleSale(runtime, { ...base(scopeFor('RCT')), lines: line }),
    ).rejects.toThrow(/use a wholesale sale book/);
    // And each other's book.
    await expect(postRateCut(runtime, { ...base(WH), lines: line })).rejects.toThrow(
      /use the wholesale sale workflow/,
    );
    await expect(postWholesaleSale(runtime, { ...base(RC), lines: line })).rejects.toThrow(
      /use the rate cut workflow/,
    );
    expect(await rows(`SELECT count(*)::int AS n FROM "RATE_CUT_DATA" WHERE tenant_id=$1`)).toEqual(
      [{ n: 0 }],
    );
  });

  it('W8 a tag sold wholesale can be returned once, and is back in stock after the return', async () => {
    await postWholesaleSale(runtime, { ...base(WH), lines: [{ tagNo: 'LRG00001' }] });
    const returnInput = {
      scope: scopeFor('WRT'),
      vchDate: '2023-06-02',
      partyCode: '000209',
      mainUser: USER,
      lines: [
        {
          tagNo: 'LRG00001',
          tagVoucherSrNo: 100312000009,
          sourceYear: YEAR,
          sourceBook: '034',
          sourceVoucherNo: '00001',
        },
      ],
    };
    await saveWholesaleSaleReturn(runtime, returnInput as never);
    expect(await available('LRG00001')).toBe(true);
    await expect(saveWholesaleSaleReturn(runtime, returnInput as never)).rejects.toThrow(
      /not currently sold or was already returned/,
    );
    // The return re-records the tag in BAR_DETL under the same instance; the picker still lists ONE tag…
    const picked = await lookup(runtime, TENANT, 'available-tags', 'LRG00001', CO, 20, {
      lcCode: LC,
    });
    expect(picked.map((row) => [row.code, row.VCH_SRNO, row.ambiguous])).toEqual([
      ['LRG00001', 100312000009, false],
    ]);
    // …and it sells again.
    const resold = await postWholesaleSale(runtime, {
      ...base(WH),
      lines: [{ tagNo: 'LRG00001' }],
    });
    expect(resold.vchNo).toBe(2);
    expect((await stock('034', '00002')).map((row) => [row.tag, row.id, row.sign])).toEqual([
      ['LRG00001', 100312000009, '-'],
    ]);
    expect(await available('LRG00001')).toBe(false);
  });

  it('a new row computes labour on the company basis, and a typed ghat weight survives reopen and edit', async () => {
    // CommPassAdd col 34 / CommPassAdd_Pr col 23 = MsLbrType (TR_WH_SALE.cs:8362, :6324): here net-wise.
    await sql(`UPDATE "CO_SET" SET "LBR_TYPE"='N' WHERE tenant_id=$1`);
    const created = await postWholesaleSale(runtime, {
      ...base(WH),
      // gross 10.5 − other 0.5 = net 10; net-wise labour Math.Round((10 + 0) × 100) = 1000 (gross-wise: 1050).
      lines: [{ itCode: 'LR916', grossWt: 10.5, othWt: 0.5, touch: 91.6, lbrRate: 100 }],
      // net 5 − 1 = 4 with a typed ghat 0.800 g (the receive grid has no ghat %): fine (4 + 0.8) × 100 / 100 = 4.8;
      // net-wise labour with ghat (LBR_WITH_GHT blank = Y) Math.Round(4.8 × 50) = 240 (gross-wise: 250).
      receivedLines: [{ itCode: '999', grossWt: 5, othWt: 1, ghtWt: 0.8, touch: 100, lbrRate: 50 }],
    });
    const lineRows = async () => [
      ...(await rows(
        `SELECT 'I' AS side,"LBR_TYPE","LBR_AMT"::float8 AS lbr,"ITM_GHT_WT"::float8 AS ght,
                "ITM_FINE"::float8 AS fine,"NET_AMT"::float8 AS net FROM "RATE_CUT_ISU" WHERE tenant_id=$1`,
      )),
      ...(await rows(
        `SELECT 'R' AS side,"LBR_TYPE","LBR_AMT"::float8 AS lbr,"ITM_GHT_WT"::float8 AS ght,
                "ITM_FINE"::float8 AS fine,"NET_AMT"::float8 AS net FROM "RATE_CUT_REC" WHERE tenant_id=$1`,
      )),
    ];
    const expected = [
      { side: 'I', LBR_TYPE: 'N', lbr: 1000, ght: 0, fine: 9.16, net: 1000 },
      { side: 'R', LBR_TYPE: 'N', lbr: 240, ght: 0.8, fine: 4.8, net: 240 },
    ];
    expect(await lineRows()).toEqual(expected);
    expect(await head('034', '00001')).toMatchObject({
      sl_fine: 9.16,
      pr_fine: 4.8,
      sl_net: 1000,
      pr_net: 240,
    });

    // Reopen gives the ghat back as a weight; saving it again must not lose it.
    const reopened = (await getWholesaleSale(runtime, WH, created.vchNo)) as any;
    expect(reopened.receivedLines[0]).toMatchObject({ ghtWt: 0.8, fine: 4.8, lbrType: 'N' });
    const back = ({ srNo: _sr, vchSrno: _id, isuRef: _ref, ...line }: any) => line;
    await editWholesaleSale(
      runtime,
      {
        ...base(WH),
        lines: reopened.lines.map(back),
        receivedLines: reopened.receivedLines.map(back),
      },
      created.vchNo,
    );
    expect(await lineRows()).toEqual(expected);
  });

  it('tender keeps its paise: cash 1000.50 and kasar 0.25 post exactly, and the outstanding follows', async () => {
    await postWholesaleSale(runtime, {
      ...base(WH),
      // 10 × 91.6 % = 9.160 at 6000: Math.Round(54960) = 54960, sold for money.
      lines: [{ itCode: 'LR916', netWt: 10, touch: 91.6, rate: 6000 }],
      pay: { cash: 1000.5, kasar: 0.25 },
    });
    // Band cells hold Strings.Format(Val, "0.00") (TR_WH_SALE.cs:15041-15047): Os = 54960 − 1000.50 − 0.25.
    expect(
      await rows(
        `SELECT "SL_CASH_AMT" AS cash,"SL_KASAR_AMT" AS kasar,"SL_NET_AMT" AS net,"SL_BILL_OS" AS os
           FROM "RATE_CUT_DATA" WHERE tenant_id=$1`,
      ),
    ).toEqual([{ cash: 1000.5, kasar: 0.25, net: 54960, os: 53959.25 }]);
    expect((await legs('034', '00001')).map((l) => [l.leg, l.ac, l.ld, l.dr, l.cr])).toEqual([
      ['01', '000209', '00003', 54960, 0],
      ['02', '00003', '000209', 0, 54960],
      ['43', '000209', '00001', 0, 1000.5],
      ['44', '00001', '000209', 1000.5, 0],
      ['47', '000209', '00057', 0, 0.25],
      ['48', '00057', '000209', 0.25, 0],
    ]);
  });

  it('lists each live instance of a shared tag number with its serial, and sells exactly the one picked', async () => {
    await tag({
      tagNo: 'LRG00002',
      vchSrno: 100312000099,
      itCode: 'LR916',
      gwt: 5,
      touch: 92,
      west: 0,
      krName: 'AB',
      prCode: 'LR',
    });
    const find = async () =>
      (await lookup(runtime, TENANT, 'available-tags', 'LRG00002', CO, 20, { lcCode: LC })).map(
        (row) => [row.code, row.VCH_SRNO, row.ambiguous, row.name],
      );
    expect(await find()).toEqual([
      ['LRG00002', 100312000010, true, 'LR916 · L RING 916 · #100312000010'],
      ['LRG00002', 100312000099, true, 'LR916 · L RING 916 · #100312000099'],
    ]);
    // Without the serial the save refuses to guess.
    await expect(
      postWholesaleSale(runtime, { ...base(WH), lines: [{ tagNo: 'LRG00002' }] }),
    ).rejects.toThrow(/ambiguous/);
    await postWholesaleSale(runtime, {
      ...base(WH),
      lines: [{ tagNo: 'LRG00002', vchSrno: 100312000099 }],
    });
    expect((await stock('034', '00001')).map((row) => [row.tag, row.id, row.sign])).toEqual([
      ['LRG00002', 100312000099, '-'],
    ]);
    expect(await find()).toEqual([['LRG00002', 100312000010, false, 'LR916 · L RING 916']]);
  });
});
