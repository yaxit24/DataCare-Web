import { PrismaClient } from '@datacare/db';
import { round } from '@datacare/core';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createSalesOrder,
  editSalesOrder,
  getSalesOrder,
} from '../src/modules/sales/salesOrder.js';
import { listPendingOrders, postOrderCancel } from '../src/modules/sales/orderCancel.js';
import { createSale } from '../src/modules/sales/sales.js';
import { openOrders } from '../src/modules/ops/balanceTransferSelect.js';

/**
 * A rate-cut Sales Order's advance is metal, not money.
 * - TR_SALE_ORD.cs:9124-9133: with a rate-cut rate (MSG2_TOTAL[9,1] != 0) the tender total MSG2_TOTAL[9,3] (:11368) is
 *   saved as RCUT_AMT and ADV_AMT is 0; without one it is ADV_AMT and RCUT_AMT is 0.
 * - :9481-9514: the order's '+' SL_ORD_ADJ row has ORD_AMT 0 and ORD_GOLD = unvalued old gold fine + RCUT_FINE.
 * - TR_SALE.cs:7299 (the sale's order help) and TR_SL_ORD_ADJ.cs:2526 (Order Cancel's) read ADV_AMT and keep only
 *   orders with SUM('+' ORD_AMT) - SUM(other ORD_AMT) > 0, so neither can spend a rate-cut advance as money; the sale
 *   writes ORD_GOLD 0 on its '-' row (TR_SALE.cs:15720), so it never touches the order's fine either.
 * - BtmSchm.cs:3024: the balance transfer keeps an order while '+' less '-' over ORD_AMT + ORD_GOLD + ORD_SILVER > 0.
 */
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Rate-cut Sales Order advance is metal, not money', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const tenantId = 'so-ratecut-advance';
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
             ($1,'01','01','ORA','ORDER ADJUST','O','OADJ','Order Adjust','Y','SL_ORD_ADJ'),
             ($1,'01','01','ORC','ORDER CANCEL','O','SADJ','Order Cancel','Y','SL_ORD_ADJ')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES($1,'01','01','S95',1,'CASH','SALES ORDER','O'),
             ($1,'01','01','SAL',1,'CTRL','SALES','O'),($1,'01','01','SAL',2,'CASH','SALES','O'),
             ($1,'01','01','SAL',3,'ROUND','SALES','O'),($1,'01','01','SAL',4,'ADVANCE','SALES','O'),
             ($1,'01','01','ORC',1,'CASH','ORDER CANCEL','O'),($1,'01','01','ORC',2,'KASAR','ORDER CANCEL','O')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES($1,'01','01','PARTY','Saved customer','L'),($1,'01','01','CASH','Cash','L'),
             ($1,'01','01','PURCHASE','Gold purchase','L'),($1,'01','01','KASAR','Kasar','L'),($1,'01','01','SLVPURC','Silver purchase','L')`,
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

  // Seeded input: cash plus a valued old gold row make the tender total; an unvalued gold row adds OrdGold.
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
  const fineOf = (row: { grossWt: number; otherWt?: number; touch: number }) =>
    round(((row.grossWt - (row.otherWt ?? 0)) * row.touch) / 100, 3);
  const RATE = 6000;
  /** MSG2_TOTAL[9,3] (:11368): every tender, the valued old metal included. */
  const TOTAL = round(CASH + goldValued.netAmt, 2);
  /** MSG2_TOTAL[9,2] = [9,3] / [9,1] to 3 decimals (TR_SALE_ORD.cs:10952). */
  const RCUT_FINE = round(TOTAL / RATE, 3);
  const input = (extra: Record<string, unknown> = {}) => ({
    scope,
    vchDate: '2024-07-10',
    vchTime: '11:22:33',
    mainUser: 'clerk',
    acCode: 'PARTY',
    acName: 'Saved customer',
    empCode: 'E1',
    vchDesc: 'Rate-cut order',
    taxRatePct: 0,
    advanceAmount: CASH,
    cashAc: 'CASH',
    oldMetalRows: [goldValued, goldUnvalued],
    rateCutRate: RATE,
    rateCutFine: RCUT_FINE,
    // A typed rate-cut amount is not stored: RCUT_AMT is the tender total.
    rateCutAmount: 1,
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
  const header = async () =>
    (
      await query(
        `SELECT "ADV_AMT"::float adv,"RCUT_AMT"::float rcut,"RCUT_RATE"::float rate,"RCUT_FINE"::float fine,
                "CASH_AMT"::float cash,"OLD_GL"::float gl
           FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='S95' AND "VCH_NO"='00001'`,
        tenantId,
      )
    )[0];
  const adjRows = () =>
    query(
      `SELECT btrim("CO_BOOK") book,"ORD_SIGN" sign,"ORD_AMT"::float amt,"ORD_GOLD"::float gold,
              "ORD_SILVER"::float silver,"PAID_AMT"::float paid
         FROM "SL_ORD_ADJ" WHERE tenant_id=$1 ORDER BY "CO_BOOK","VCH_NO","SR_NO"`,
      tenantId,
    );
  /** TR_SALE_ORD.cs:10092 / BtmSchm.cs:3024: '+' less the other signs over the order key. */
  const desktopPending = async () =>
    (
      await query(
        `SELECT sum(CASE WHEN b."ORD_SIGN"='+' THEN b."ORD_AMT" ELSE -b."ORD_AMT" END)::float amt,
                sum(CASE WHEN b."ORD_SIGN"='+' THEN b."ORD_GOLD" ELSE -b."ORD_GOLD" END)::float gold
           FROM "SL_ORD_DATA" a LEFT JOIN "SL_ORD_ADJ" b ON a.tenant_id=b.tenant_id AND a."CO_CODE"=b."CO_CODE"
            AND a."LC_CODE"=b."ORD_LC" AND a."CO_YEAR"=b."ORD_YRCD" AND a."CO_BOOK"=b."ORD_DBCD" AND a."VCH_NO"=b."ORD_NO"
          WHERE a.tenant_id=$1 AND a."CO_BOOK"='S95' AND a."VCH_NO"='00001'
          GROUP BY a."VCH_NO"`,
        tenantId,
      )
    )[0];
  const plusRow = {
    book: 'S95',
    sign: '+',
    amt: 0,
    gold: round(fineOf(goldUnvalued) + RCUT_FINE, 3),
    silver: 0,
    paid: 0,
  };
  /** MSG2_TOTAL[6,2] (:11345-11364): the grid's old gold fine. */
  const GRID_GOLD_FINE = round(fineOf(goldValued) + fineOf(goldUnvalued), 3);
  /** The saved OLD_GL is the [6,2] cell plus MSG2_TOTAL[9,2] (TR_SALE_ORD.cs:9143). */
  const SAVED_OLD_GL = GRID_GOLD_FINE + RCUT_FINE;
  const sale = (orderRef: Record<string, unknown>) =>
    createSale(
      runtime,
      {
        scope: saleScope,
        mainUser: 'clerk',
        acCode: 'PARTY',
        acName: 'Saved customer',
        vchDate: '2024-07-20',
        taxRatePct: 0,
        interState: false,
        orderRef,
      } as any,
      [{ itCode: 'LOOSE', pcs: 1, grossWt: 5, netWt: 5, touch: 91.6, metalAmount: 5000 }] as any,
    );

  it('files the tender total as RCUT_AMT with ADV_AMT 0, and the + row as metal (:9124-9133, :9504, :9509)', async () => {
    await createSalesOrder(runtime, input() as any);
    expect(await header()).toEqual({
      adv: 0,
      rcut: TOTAL,
      rate: RATE,
      fine: RCUT_FINE,
      cash: CASH,
      gl: SAVED_OLD_GL,
    });
    expect(await adjRows()).toEqual([plusRow]);
    expect(await desktopPending()).toEqual({ amt: 0, gold: plusRow.gold });
    expect(await listPendingOrders(runtime, scope)).toEqual([]);
  });

  it('OLD_GL is the old gold fine plus RCUT_FINE (:9143); a typed rate-cut-only order re-saves it unchanged', async () => {
    // Without the old-metal grid the typed rate cut is the only metal, so the saved OLD_GL is RCUT_FINE alone.
    await createSalesOrder(runtime, input({ oldMetalRows: undefined, advanceAmount: 0 }) as any);
    expect(await header()).toEqual({
      adv: 0,
      rcut: 0,
      rate: RATE,
      fine: RCUT_FINE,
      cash: 0,
      gl: RCUT_FINE,
    });
    // The typed rate cut is echoed by an edit, so it is not old metal an edit would zero.
    const doc = (await getSalesOrder(runtime, scope, 1)) as any;
    expect(doc.editBlockedReason).toBeUndefined();
    expect(doc.oldGoldFine).toBeCloseTo(RCUT_FINE, 6);
    await editSalesOrder(
      runtime,
      {
        ...doc,
        oldMetalRows: undefined,
        scope,
        expectedVersion: doc.version,
        mainUser: 'clerk',
      } as any,
      1,
    );
    expect(await header()).toEqual({
      adv: 0,
      rcut: 0,
      rate: RATE,
      fine: RCUT_FINE,
      cash: 0,
      gl: RCUT_FINE,
    });
  });

  it('a changed RCUT_FINE moves the saved OLD_GL with it while the request echoes the old OLD_GL (:9143)', async () => {
    await createSalesOrder(runtime, input({ oldMetalRows: undefined, advanceAmount: 0 }) as any);
    const doc = (await getSalesOrder(runtime, scope, 1)) as any;
    const fine = RCUT_FINE + 1;
    await editSalesOrder(
      runtime,
      {
        ...doc,
        oldMetalRows: undefined,
        rateCutFine: fine,
        dirtyFields: ['rateCutFine'],
        scope,
        expectedVersion: doc.version,
        mainUser: 'clerk',
      } as any,
      1,
    );
    expect(await header()).toMatchObject({ fine, gl: fine });
  });

  it('a sale cannot spend the rate-cut advance as money and leaves the fine on the order', async () => {
    await createSalesOrder(runtime, input() as any);
    await expect(sale({ ordNo: 1, ordBook: 'S95', adjustAmt: TOTAL })).rejects.toThrow(
      /0\.00 advance open/,
    );
    await expect(sale({ ordNo: 1, ordBook: 'S95', adjustAmt: 0.01 })).rejects.toThrow(
      /0\.00 advance open/,
    );
    expect(await adjRows()).toEqual([plusRow]);
    // An order reference without an amount takes the open money advance, which is 0: no '-' row, nothing taken off
    // the bill, and the order's fine stays where the desktop leaves it (TR_SALE.cs:15720 writes ORD_GOLD 0).
    const made = await sale({ ordNo: 1, ordBook: 'S95' });
    const saleHead = (
      await query(
        `SELECT "ADV_AMT"::float adv FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SAL' AND "VCH_NO"=$2`,
        tenantId,
        String(made.vchNo).padStart(5, '0'),
      )
    )[0];
    expect(saleHead.adv).toBe(0);
    expect(await adjRows()).toEqual([plusRow]);
    expect(await desktopPending()).toEqual({ amt: 0, gold: plusRow.gold });
  });

  it('Order Cancel cannot refund a rate-cut advance (TR_SL_ORD_ADJ.cs:2526)', async () => {
    await createSalesOrder(runtime, input() as any);
    await expect(
      postOrderCancel(runtime, {
        scope: { ...scope, coBook: 'ORC' },
        rows: [
          {
            ordNo: '00001',
            ordYear: YEAR,
            ordBook: 'S95',
            adjAmt: TOTAL,
            kasarAmt: 0,
            paidAmt: TOTAL,
          },
        ],
        vchDate: '2024-07-20',
        mainUser: 'clerk',
      }),
    ).rejects.toThrow(/only 0\.00 open advance/);
    expect(await adjRows()).toEqual([plusRow]);
  });

  it('balance transfer keeps the order on its fine with no negative money pending (BtmSchm.cs:3024)', async () => {
    await createSalesOrder(runtime, input() as any);
    await sale({ ordNo: 1, ordBook: 'S95' });
    const open = await openOrders(runtime, {
      tenantId,
      coCode: '01',
      lcCode: '01',
      coYear: YEAR,
      clDate: '2025-03-31',
    });
    expect(open).toEqual([
      {
        coYear: YEAR,
        coBook: 'S95',
        vchNo: '00001',
        acCode: 'PARTY',
        advAmt: 0,
        adjAmount: 0,
        adjGold: 0,
        adjSilver: 0,
      },
    ]);
    const pending = await desktopPending();
    expect(pending.amt).toBe(0);
    expect(pending.gold).toBe(plusRow.gold);
  });

  it('an order saved before the split, with the total still in ADV_AMT, opens no money either', async () => {
    await createSalesOrder(runtime, input() as any);
    await sql(
      `UPDATE "SL_ORD_DATA" SET "ADV_AMT"=$2 WHERE tenant_id=$1 AND "VCH_NO"='00001'`,
      tenantId,
      TOTAL,
    );
    expect(await listPendingOrders(runtime, scope)).toEqual([]);
    await expect(sale({ ordNo: 1, ordBook: 'S95', adjustAmt: CASH })).rejects.toThrow(
      /0\.00 advance open/,
    );
  });

  it('edit reloads the cash tender, keeps the split, and dropping the rate makes it a money advance again', async () => {
    await createSalesOrder(runtime, input() as any);
    let doc = (await getSalesOrder(runtime, scope, 1)) as any;
    expect([doc.advanceAmount, doc.rateCutRate, doc.rateCutFine, doc.rateCutAmount]).toEqual([
      CASH,
      RATE,
      RCUT_FINE,
      TOTAL,
    ]);
    await editSalesOrder(
      runtime,
      { ...doc, scope, expectedVersion: doc.version, mainUser: 'clerk', vchDesc: 'Edited' } as any,
      1,
    );
    expect(await header()).toEqual({
      adv: 0,
      rcut: TOTAL,
      rate: RATE,
      fine: RCUT_FINE,
      cash: CASH,
      gl: SAVED_OLD_GL,
    });
    expect(await adjRows()).toEqual([plusRow]);

    doc = (await getSalesOrder(runtime, scope, 1)) as any;
    await editSalesOrder(
      runtime,
      {
        ...doc,
        scope,
        expectedVersion: doc.version,
        mainUser: 'clerk',
        rateCutRate: 0,
        rateCutFine: 0,
      } as any,
      1,
    );
    expect(await header()).toEqual({
      adv: TOTAL,
      rcut: 0,
      rate: 0,
      fine: 0,
      cash: CASH,
      gl: GRID_GOLD_FINE,
    });
    expect(await adjRows()).toEqual([{ ...plusRow, amt: TOTAL, gold: fineOf(goldUnvalued) }]);
    expect((await listPendingOrders(runtime, scope)).map((o) => [o.ordNo, o.openAmt])).toEqual([
      ['00001', TOTAL],
    ]);
  });
});
