import { PrismaClient } from '@datacare/db';
import { round } from '@datacare/core';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  cancelSalesOrder,
  createSalesOrder,
  editSalesOrder,
  getSalesOrder,
} from '../src/modules/sales/salesOrder.js';
import { listPendingOrders } from '../src/modules/sales/orderCancel.js';
import { createSale, deleteSale, getSale } from '../src/modules/sales/sales.js';

/**
 * The Sales Order's own '+' SL_ORD_ADJ advance row (TR_SALE_ORD.cs:9475-9516; same shape as the opening carry-forward,
 * Ac_Tax.cs:71). The save deletes the voucher's SL_ORD_ADJ rows and writes SR_NO 1 when
 * `MSG2_TOTAL[9,3] + OrdGold + OrdSilver != 0`: ORD_SIGN '+', ORD_AMT the advance when there is no rate-cut rate
 * (`:9504`), ORD_GOLD the unvalued old gold fine plus the rate-cut fine (`:9509`), ORD_SILVER the unvalued old silver
 * fine. Delete removes it (`:9731`). A sale's use of the advance is a '-' row with the amount in ORD_AMT
 * (TR_SALE.cs:15712-15725), and the desktop's pending test is SUM('+') - SUM(others) over the order key (`:10092`).
 */
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Sales Order advance row in SL_ORD_ADJ', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const tenantId = 'sales-order-advance-adj';
  const YEAR = '2024-2025';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: YEAR, coBook: 'S95' };
  const saleScope = { ...scope, coBook: 'SAL' };
  const tables = [
    'DELETE_DATA',
    'ROJ_MEL_DATA',
    'AC_DATA',
    'SL_ORD_IDTL',
    'SL_ORD_DETL',
    'SL_ORD_DATA',
    'SL_PR_DETL',
    'SL_ORD_ADJ',
    'UPI_DATA',
    'MAIN_STOCK',
    'TAG_STOCK',
    'BAR_DETL',
    'TEMP_BOOK_DATA',
    'REMARK_DATA',
    'LOT_DETL',
    'CRNT_DATA',
    'DM_DATA',
    'CARD_DATA',
    'POINT_DATA',
    'AD_ADJ',
    'BILL_OS_DATA',
    'TAX_DATA',
    'SL_IDTL',
    'SL_DETL',
    'SL_DATA',
    'BOOK_DETL',
    'BOOK_DATA',
    'PRODUCT_MAST',
    'ITEM_MAST',
    'GROUP_MAST',
    'AC_MAST',
    'CO_SET',
    'CO_SET_NEW',
    'YEAR_MAST',
  ];
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const query = (statement: string, ...values: unknown[]) =>
    owner.$queryRawUnsafe<any[]>(statement, ...values);
  const clean = async () => {
    for (const table of tables) await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  };
  beforeEach(async () => {
    await clean();
    await sql(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES($1,'01',NULL)`,
      tenantId,
    );
    await sql(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,'01','N')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01',$2,'2024-04-01','2025-03-31')`,
      tenantId,
      YEAR,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","BOOK_NAME","CUR_USE","BOOK_TBL_NAME")
       VALUES($1,'01','01','S95','SALES ORDER','O','SORD','Sales Order','Y','SL_ORD_DATA'),
             ($1,'01','01','SAL','SALES','O','CSB','Sales Book','Y','SL_DATA'),
             ($1,'01','01','ORA','ORDER ADJUST','O','OADJ','Order Adjust','Y','SL_ORD_ADJ')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES($1,'01','01','S95',1,'CASH','SALES ORDER','O'),
             ($1,'01','01','SAL',1,'CTRL','SALES','O'),($1,'01','01','SAL',2,'CASH','SALES','O'),
             ($1,'01','01','SAL',3,'ROUND','SALES','O'),($1,'01','01','SAL',4,'ADVANCE','SALES','O')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES($1,'01','01','PARTY','Saved customer','L'),($1,'01','01','CASH','Cash','L'),
             ($1,'01','01','PURCHASE','Gold purchase','L'),($1,'01','01','SLVPURC','Silver purchase','L')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC","SALE_AC")
       VALUES($1,'01','E1','Gold','PURCHASE','SALEAC'),($1,'01','E2','Silver','SLVPURC','SALEAC')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","PR_CODE")
       VALUES($1,'01','GL','Gold','G','E1','01'),($1,'01','SV','Silver','S','E2','01'),
             ($1,'01','LOOSE','Loose Gold','G','E1','01')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES($1,'01','01','Gold product')`,
      tenantId,
    );
  });
  afterAll(async () => {
    await clean();
    await runtime.$disconnect();
    await owner.$disconnect();
  });

  // Seeded input. The valued gold row (2,000) joins the advance; the unvalued rows give OrdGold / OrdSilver.
  const CASH = 1000;
  const goldValued = {
    itCode: 'GL',
    pcs: 1,
    grossWt: 10.5,
    otherWt: 0.5,
    touch: 91.6,
    rateType: 'F',
    netAmt: 2000,
  };
  const goldUnvalued = { itCode: 'GL', pcs: 1, grossWt: 4, touch: 75, rateType: 'F' };
  const silverUnvalued = { itCode: 'SV', pcs: 2, grossWt: 20, touch: 100, rateType: 'F' };
  const fineOf = (row: { grossWt: number; otherWt?: number; touch: number }) =>
    round(((row.grossWt - (row.otherWt ?? 0)) * row.touch) / 100, 3);
  const input = (extra: Record<string, unknown> = {}) => ({
    scope,
    vchDate: '2024-07-10',
    vchTime: '11:22:33',
    mainUser: 'clerk',
    acCode: 'PARTY',
    acName: 'Saved customer',
    empCode: 'E1',
    vchDesc: 'Wedding set',
    taxRatePct: 0,
    advanceAmount: CASH,
    cashAc: 'CASH',
    lines: [
      {
        srNo: 1,
        itCode: 'GL',
        designNo: 'D1',
        designImageId: 'N',
        pcs: 1,
        grossWt: 2,
        netWt: 2,
        touch: 100,
        rate: 100,
        labourAmount: 0,
        labourRate: 0,
        labourPct: 0,
        components: [],
      },
    ],
    ...extra,
  });
  const adjRows = () =>
    query(
      `SELECT btrim("CO_BOOK") book,btrim("VCH_NO") vch,"SR_NO"::int sr,"VCH_DATE"::text date,
              to_char("VCH_TIME",'YYYY-MM-DD HH24:MI:SS') time,btrim("HD_VCH_NO") hd,btrim("AC_CODE") ac,
              "AC_NAME" name,btrim("VCH_TYPE") vtype,btrim("INOUT_TYPE") inout,btrim("ENTRY_TYPE") entry,
              btrim("BOOK_NAME") bname,btrim("ORD_HD_VCH_NO") ordhd,btrim("ORD_NO") ordno,btrim("ORD_LC") ordlc,
              btrim("ORD_YRCD") ordyr,btrim("ORD_DBCD") ordbook,btrim("ORD_AC_CODE") ordac,"ORD_SIGN" sign,
              "ORD_AMT"::float amt,"PAID_AC" paidac,"PAID_AMT"::float paid,"KASAR_AMT"::float kasar,
              "ORD_BAL_AMT"::float bal,"ORD_GOLD"::float gold,"ORD_SILVER"::float silver,"DATA_TRFR" trfr,
              "EMP_CODE" emp,"IT_DESC" descr,btrim("MAIN_USER") mu
         FROM "SL_ORD_ADJ" WHERE tenant_id=$1 ORDER BY "CO_BOOK","VCH_NO","SR_NO"`,
      tenantId,
    );
  const expectedPlus = (over: Record<string, unknown> = {}) => ({
    book: 'S95',
    vch: '00001',
    sr: 1,
    date: '2024-07-10',
    time: '2024-07-10 11:22:33',
    hd: '00001',
    ac: 'PARTY',
    name: 'Saved customer',
    vtype: 'SORD',
    inout: 'O',
    entry: 'O',
    bname: 'SALES ORDER',
    ordhd: '00001',
    ordno: '00001',
    ordlc: '01',
    ordyr: YEAR,
    ordbook: 'S95',
    ordac: 'PARTY',
    sign: '+',
    amt: CASH,
    paidac: '',
    paid: 0,
    kasar: 0,
    bal: 0,
    gold: 0,
    silver: 0,
    trfr: 'N',
    emp: 'E1',
    descr: 'Wedding set',
    mu: 'clerk',
    ...over,
  });
  /** TR_SALE_ORD.cs:10092: SUM(+ORD_AMT) - SUM(other ORD_AMT) over the order key; NULL when there is no row. */
  const desktopPending = async () =>
    (
      await query(
        `SELECT sum(CASE WHEN b."ORD_SIGN"='+' THEN b."ORD_AMT" ELSE -b."ORD_AMT" END)::float pending,
                coalesce(sum(CASE WHEN b."ORD_SIGN"='-' THEN b."ORD_AMT" ELSE 0 END),0)::float adjusted
           FROM "SL_ORD_DATA" a LEFT JOIN "SL_ORD_ADJ" b ON a.tenant_id=b.tenant_id AND a."CO_CODE"=b."CO_CODE"
            AND a."LC_CODE"=b."ORD_LC" AND a."CO_YEAR"=b."ORD_YRCD" AND a."CO_BOOK"=b."ORD_DBCD" AND a."VCH_NO"=b."ORD_NO"
          WHERE a.tenant_id=$1 AND a."CO_BOOK"='S95' AND a."VCH_NO"='00001'
          GROUP BY a."VCH_NO"`,
        tenantId,
      )
    )[0];
  const loaded = () => getSalesOrder(runtime, scope, 1) as Promise<any>;

  it('create writes the exact desktop + row: advance, unvalued old gold and silver fine', async () => {
    await createSalesOrder(
      runtime,
      input({ oldMetalRows: [goldValued, goldUnvalued, silverUnvalued] }) as any,
    );
    // MSG2_TOTAL[9,3] is the cash plus the valued old metal (:11368); the unvalued rows count only as fine.
    expect(await adjRows()).toEqual([
      expectedPlus({
        amt: round(CASH + goldValued.netAmt, 2),
        gold: fineOf(goldUnvalued),
        silver: fineOf(silverUnvalued),
      }),
    ]);
    const header = (
      await query(
        `SELECT "ADV_AMT"::float adv FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001'`,
        tenantId,
      )
    )[0];
    expect(header.adv).toBe(round(CASH + goldValued.netAmt, 2));
    // The '+' row alone is not an adjustment: the order still opens for editing.
    expect((await loaded()).editBlockedReason).toBeUndefined();
  });

  it('a rate-cut order writes ORD_AMT 0 and adds the rate-cut fine to ORD_GOLD (:9504, :9509)', async () => {
    const rateCut = { rateCutRate: 6000, rateCutFine: 0.5, rateCutAmount: 3000 };
    await createSalesOrder(runtime, input({ ...rateCut, oldMetalRows: [goldUnvalued] }) as any);
    expect(await adjRows()).toEqual([
      expectedPlus({ amt: 0, gold: round(fineOf(goldUnvalued) + rateCut.rateCutFine, 3) }),
    ]);
  });

  it('a rate-cut order with no typed rate-cut amount still writes the row from the tender total (:9481, :11368)', async () => {
    // The desktop's [9,3] is the tender total whether or not a rate-cut rate is set, so cash alone makes the row.
    const rateCut = { rateCutRate: 6000, rateCutFine: 0.25, rateCutAmount: 0 };
    await createSalesOrder(runtime, input(rateCut) as any);
    expect(await adjRows()).toEqual([expectedPlus({ amt: 0, gold: rateCut.rateCutFine })]);
  });

  it('an order with no advance and no unvalued metal writes no row (:9481)', async () => {
    await createSalesOrder(runtime, input({ advanceAmount: 0 }) as any);
    expect(await adjRows()).toEqual([]);
    expect((await desktopPending()).pending).toBeNull();
  });

  it('edit replaces the + row, an edit to no advance removes it, and delete removes it', async () => {
    await createSalesOrder(runtime, input() as any);
    expect(await adjRows()).toEqual([expectedPlus()]);

    const NEW_CASH = 1500;
    let doc = await loaded();
    await editSalesOrder(
      runtime,
      {
        ...doc,
        scope,
        expectedVersion: doc.version,
        mainUser: 'clerk',
        advanceAmount: NEW_CASH,
        vchDesc: 'Edited',
      } as any,
      1,
    );
    expect(await adjRows()).toEqual([expectedPlus({ amt: NEW_CASH, descr: 'Edited' })]);

    doc = await loaded();
    expect(doc.editBlockedReason).toBeUndefined();
    await editSalesOrder(
      runtime,
      { ...doc, scope, expectedVersion: doc.version, mainUser: 'clerk', advanceAmount: 0 } as any,
      1,
    );
    expect(await adjRows()).toEqual([]);

    doc = await loaded();
    await editSalesOrder(
      runtime,
      {
        ...doc,
        scope,
        expectedVersion: doc.version,
        mainUser: 'clerk',
        advanceAmount: CASH,
      } as any,
      1,
    );
    expect(await adjRows()).toEqual([expectedPlus({ descr: doc.vchDesc })]);

    doc = await loaded();
    await cancelSalesOrder(runtime, { scope, vchNo: 1, expectedVersion: doc.version });
    expect(await adjRows()).toEqual([]);
  });

  it("a sale's - row nets the advance to zero pending; deleting the sale reopens it", async () => {
    await createSalesOrder(runtime, input() as any);
    expect(await desktopPending()).toEqual({ pending: CASH, adjusted: 0 });
    expect((await listPendingOrders(runtime, scope)).map((o) => [o.ordNo, o.openAmt])).toEqual([
      ['00001', CASH],
    ]);

    const sale = await createSale(
      runtime,
      {
        scope: saleScope,
        mainUser: 'clerk',
        acCode: 'PARTY',
        acName: 'Saved customer',
        vchDate: '2024-07-20',
        taxRatePct: 0,
        interState: false,
        orderRef: { ordNo: 1, ordBook: 'S95', adjustAmt: CASH },
      } as any,
      [{ itCode: 'LOOSE', pcs: 1, grossWt: 5, netWt: 5, touch: 91.6, metalAmount: 5000 }] as any,
    );
    const minus = (await adjRows()).filter((row) => row.sign === '-');
    expect(minus).toHaveLength(1);
    // TR_SALE.cs:15695-15727: the '-' row is under the sale's own key, with the order's key in ORD_*.
    expect(minus[0]).toMatchObject({
      book: 'SAL',
      vch: String(sale.vchNo).padStart(5, '0'),
      entry: 'S',
      ordno: '00001',
      ordlc: '01',
      ordyr: YEAR,
      ordbook: 'S95',
      ordhd: '00001',
      ordac: 'PARTY',
      amt: CASH,
      paid: 0,
      kasar: 0,
    });
    // Both the desktop's pending test and the web's open advance (Order Cancel and the sale share it) are zero.
    expect(await desktopPending()).toEqual({ pending: 0, adjusted: CASH });
    expect(await listPendingOrders(runtime, scope)).toEqual([]);
    const saved = (await getSale(runtime, saleScope, sale.vchNo)) as any;
    expect(saved.orderRef).toEqual({ ordNo: '00001', adjustAmt: CASH });
    // The order's own '+' row is untouched by the sale.
    expect((await adjRows()).filter((row) => row.sign === '+')).toEqual([expectedPlus()]);

    await deleteSale(runtime, {
      scope: saleScope,
      vchNo: sale.vchNo,
      expectedVersion: saved.version,
    });
    expect(await desktopPending()).toEqual({ pending: CASH, adjusted: 0 });
    expect((await listPendingOrders(runtime, scope)).map((o) => [o.ordNo, o.openAmt])).toEqual([
      ['00001', CASH],
    ]);
  });
});
