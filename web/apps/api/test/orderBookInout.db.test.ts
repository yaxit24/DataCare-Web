import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  cancelSalesOrder,
  createSalesOrder,
  editSalesOrder,
  getSalesOrder,
} from '../src/modules/sales/salesOrder.js';

/**
 * A Sales Order on an 'I' book, as the desktop's own order books are (Order Booking, MS_UPDATE.cs:31987; Mobile Order
 * 1-5, :17799-17831). The desktop opens any SALES ORDER book (CurBookHelp, DC_Main.cs:1495-1536) and stamps its
 * BOOK_INOUT on INOUT_TYPE (TR_SALE_ORD.cs:9201, :9390, :9442, :9494). An 'I' book posts old metal legs 07-10 and the
 * rate-cut leg 11 (Ac_Ledr.cs:42-53) and the Order_Stk stock rows (Ac_Stock.cs, TR_SALE_ORD.cs:9564-9566).
 */
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Sales Order on an I book follows the desktop', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });
  const runtime = new PrismaClient({
    datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
  });
  const tenantId = 'order-book-inout';
  const YEAR = '2024-2025';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: YEAR, coBook: '320' };
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
    'TEMP_BOOK_DATA',
    'BOOK_DETL',
    'BOOK_DATA',
    'PRODUCT_MAST',
    'ITEM_MAST',
    'GROUP_MAST',
    'AC_MAST',
    'CO_SET_NEW',
    'CO_SET',
    'YEAR_MAST',
  ];
  const exec = (sql: string, ...params: unknown[]) =>
    withTenant(owner, tenantId, (tx: any) => tx.$executeRawUnsafe(sql, ...params));
  const query = (sql: string, ...params: unknown[]) => owner.$queryRawUnsafe<any[]>(sql, ...params);
  const clean = async () => {
    for (const table of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  };
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES($1,'01',NULL)`,
      tenantId,
    );
    await exec(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,'01','N')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01',$2,'2024-04-01','2025-03-31')`,
      tenantId,
      YEAR,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","DATA_TYPE")
       VALUES($1,'01','01','320','Order Booking','ORDBK','SALES ORDER','I','Y','SL_ORD_DATA','A')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE")
       VALUES($1,'01','01','320',1,'CASH','ORDBK','SALES ORDER','I','A')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES($1,'01','01','PARTY','Order customer'),($1,'01','01','CASH','Cash'),($1,'01','01','PURCHASE','Gold purchase')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC","SALE_AC") VALUES($1,'01','E1','Gold','PURCHASE','SALEAC')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","PR_CODE") VALUES($1,'01','GL','Gold','G','E1','01')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES($1,'01','01','Gold product')`,
      tenantId,
    );
  });
  afterAll(async () => {
    await clean();
    await runtime.$disconnect();
    await owner.$disconnect();
  });

  const line = (extra: Record<string, unknown> = {}) => ({
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
    ...extra,
  });
  const input = (extra: Record<string, unknown> = {}) => ({
    scope,
    vchDate: '2024-07-10',
    vchTime: '11:22:33',
    mainUser: 'clerk',
    acCode: 'PARTY',
    acName: 'Order customer',
    vchDesc: 'I book order',
    taxRatePct: 0,
    advanceAmount: 1000,
    cashAc: 'CASH',
    oldMetalRows: [
      {
        itCode: 'GL',
        pcs: 1,
        grossWt: 10.5,
        otherWt: 0.5,
        touch: 91.6,
        rateType: 'F',
        netAmt: 2000,
      },
      { itCode: 'GL', pcs: 1, grossWt: 4, touch: 75, rateType: 'F' },
    ],
    lines: [line()],
    ...extra,
  });

  // Ac_Stock.Order_Stk statement 1, run over the saved SL_PR_DETL.
  const DESKTOP_STOCK_IN = `
    SELECT A."CO_CODE",A."LC_CODE",A."CO_YEAR",A."CO_BOOK",A."VCH_NO",1 AS "SR_NO",A."SR_NO" AS "ISR_NO",A."VCH_DATE",
           to_char(A."VCH_DATE",'YYYY-MM-DD') AS "STK_DATE",B."BOOK_SNAME" AS "VCH_TYPE",B."MAIN_BOOK" AS "BOOK_NAME",A."AC_CODE",A."IT_CODE",
           'N' AS "TAG_NO",0 AS "VCH_SRNO",'' AS "TBL_CODE",'P' AS "TR_TYPE",'+' AS "ITM_SIGN",1 AS "ITM_QTY",
           A."ITM_PCS"::float,A."ITM_GWT"::float,A."ITM_NWT"::float,A."ITM_TOUCH"::float,0 AS "ITM_WEST",A."ITM_FINE"::float,
           A."ITM_RATE"::float,A."NET_AMT"::float AS "ITM_AMT",0 AS "LBR_RATE",0 AS "LBR_AMT",0 AS "OTH_AMT",0 AS "ITM_MRP",
           A."NET_AMT"::float,A."ITM_NWT"::float AS "KR_NWT",A."ITM_TOUCH"::float AS "KR_TOUCH",0 AS "KR_WEST",
           A."ITM_FINE"::float AS "KR_FINE",0 AS "KR_LBR_AMT",0 AS "KR_OTH_AMT",0 AS "KR_COST",'' AS "EMP_CODE",
           A."VCH_TIME"::date AS "ENTRY_TIME",A."MAIN_USER",B."DATA_TYPE",'' AS "DESIGN_NO",'' AS "ITM_SIZE",'' AS "ITM_DESC",
           0 AS "GHT_PRC",'' AS "ITM_LOT",0 AS "ITM_DISC"
      FROM "SL_PR_DETL" A LEFT JOIN "BOOK_DATA" B ON A.tenant_id=B.tenant_id AND A."CO_CODE"=B."CO_CODE"
       AND A."LC_CODE"=B."LC_CODE" AND A."CO_BOOK"=B."CO_BOOK"
     WHERE A.tenant_id=$1 AND B."MAIN_BOOK" IN ('SALES ORDER','TOUR ORDER') AND B."BOOK_INOUT"='I' ORDER BY A."SR_NO"`;
  const WEB_STOCK_IN = `
    SELECT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO"::int,"ISR_NO"::int,"VCH_DATE","STK_DATE","VCH_TYPE",
           "BOOK_NAME","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO"::int,"TBL_CODE","TR_TYPE","ITM_SIGN","ITM_QTY"::int,
           "ITM_PCS"::float,"ITM_GWT"::float,"ITM_NWT"::float,"ITM_TOUCH"::float,"ITM_WEST"::int,"ITM_FINE"::float,
           "ITM_RATE"::float,"ITM_AMT"::float,"LBR_RATE"::int,"LBR_AMT"::int,"OTH_AMT"::int,"ITM_MRP"::int,"NET_AMT"::float,
           "KR_NWT"::float,"KR_TOUCH"::float,"KR_WEST"::int,"KR_FINE"::float,"KR_LBR_AMT"::int,"KR_OTH_AMT"::int,
           "KR_COST"::int,"EMP_CODE","ENTRY_TIME","MAIN_USER","DATA_TYPE","DESIGN_NO","ITM_SIZE","ITM_DESC",
           "GHT_PRC"::int,"ITM_LOT","ITM_DISC"::int
      FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "SR_NO"=1 ORDER BY "ISR_NO"`;
  const legs = async () =>
    (
      await query(
        `SELECT btrim(substr("LEDR_KEY",22)) leg FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
        tenantId,
      )
    )
      .map((row) => row.leg)
      .sort();
  const inoutTypes = async () =>
    query(
      `SELECT DISTINCT "INOUT_TYPE" t FROM (SELECT "INOUT_TYPE" FROM "SL_ORD_DETL" WHERE tenant_id=$1
        UNION ALL SELECT "INOUT_TYPE" FROM "SL_PR_DETL" WHERE tenant_id=$1) x`,
      tenantId,
    );

  it("accepts the 'I' book, stamps INOUT_TYPE I and posts legs 07-11 and Order_Stk statement 1", async () => {
    await createSalesOrder(runtime, input({ rateCutRate: 6000, rateCutFine: 0.5 }) as any);
    expect(await inoutTypes()).toEqual([{ t: 'I' }]);
    // 01/02 cash, line 1 valued 07/08, line 2 fine 09/10, rate cut 11 (Ac_Ledr.cs:30-53).
    expect(await legs()).toEqual(['01', '02', '107', '108', '11', '209', '210']);
    const desktop = await query(DESKTOP_STOCK_IN, tenantId);
    expect(desktop).toHaveLength(2);
    expect(await query(WEB_STOCK_IN, tenantId)).toEqual(desktop);
  });

  it('an edit rebuilds the old metal stock rows and delete removes them', async () => {
    await createSalesOrder(runtime, input() as any);
    const doc = (await getSalesOrder(runtime, scope, 1)) as any;
    expect(doc.editBlockedReason).toBeUndefined();
    await editSalesOrder(
      runtime,
      {
        ...doc,
        scope,
        expectedVersion: doc.version,
        mainUser: 'clerk',
        oldMetalRows: [doc.oldMetalRows[0]],
      } as any,
      1,
    );
    const desktop = await query(DESKTOP_STOCK_IN, tenantId);
    expect(desktop).toHaveLength(1);
    expect(await query(WEB_STOCK_IN, tenantId)).toEqual(desktop);
    await cancelSalesOrder(runtime, { scope, vchNo: 1, deleteUser: 'clerk' });
    expect(
      await query(`SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1`, tenantId),
    ).toEqual([{ n: 0 }]);
  });

  it("a TAG_STK_LESS 'Y' line posts Order_Stk statement 2 ('-' row) and then blocks an edit as a stock allocation", async () => {
    await createSalesOrder(
      runtime,
      input({
        oldMetalRows: [],
        advanceAmount: 0,
        lines: [line({ tagStockLess: 'Y', tblCode: '002' })],
      }) as any,
    );
    const [out] = await query(
      `SELECT "SR_NO"::int sr,"ISR_NO"::int isr,"TR_TYPE" tr,"ITM_SIGN" sign,"TAG_NO" tag,"TBL_CODE" tbl,"ITM_NWT"::float nwt,
              "NET_AMT"::float net,"DATA_TYPE" dt,"VCH_TYPE" vt,"BOOK_NAME" bn,"MAIN_USER" mu
         FROM "MAIN_STOCK" WHERE tenant_id=$1`,
      tenantId,
    );
    const [detl] = await query(
      `SELECT "TAG_NO" tag,"TBL_CODE" tbl,"ITM_NWT"::float nwt,"NET_AMT"::float net FROM "SL_ORD_DETL" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(out).toEqual({
      sr: 2,
      isr: 1,
      tr: 'O',
      sign: '-',
      tag: detl.tag,
      tbl: detl.tbl,
      nwt: detl.nwt,
      net: detl.net,
      dt: 'A',
      vt: 'ORDBK',
      bn: 'SALES ORDER',
      mu: 'clerk',
    });
    const doc = (await getSalesOrder(runtime, scope, 1)) as any;
    expect(doc.editBlockedReason).toMatch(/stock allocations/);
  });
});
