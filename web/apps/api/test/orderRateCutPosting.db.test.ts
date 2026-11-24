import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  cancelSalesOrder,
  cancelTourOrder,
  createSalesOrder,
  createTourOrder,
  editSalesOrder,
  editTourOrder,
  getSalesOrder,
  getTourOrder,
} from '../src/modules/sales/salesOrder.js';

/**
 * The rate-cut rows of a Sales Order and a Tour Order, compared column by column with the desktop's own statements
 * run against the saved SL_ORD_DATA row. This is an INTENTIONAL one-sided entry copied from the desktop.
 *
 * - Ac_Ledr.cs:53 (Order_Ledr): AC_DATA key 11, party Dr CASH+CARD+CHQ+OLD_GL_AMT+OLD_SL_AMT+SCHM_AMT against
 *   '00008', IT_TYPE 'G', SIGN '+', FINE_WT RCUT_FINE, only for BOOK_INOUT 'I' and RCUT_FINE <> 0. No counter-leg.
 * - Ac_Rojmel.cs:23 (Order_Rojmel type 07): the same amount and the fine, RCUT_RATE as ITM_RATE, VCH_DESC as IT_DESC,
 *   for RCUT_FINE <> 0 (no BOOK_INOUT filter). Type 01 reads ADV_AMT (:11), 0 on a rate-cut order.
 * - TR_SALE_ORD.cs:9558-9563 / TR_TOUR_ORD.cs:7609-7614: every save deletes and rebuilds both; delete removes them
 *   (TR_SALE_ORD.cs:9729-9730, TR_TOUR_ORD.cs:7753-7754).
 */
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Order rate-cut ledger and day-book rows follow Ac_Ledr.cs:53 and Ac_Rojmel.cs:23', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });
  const runtime = new PrismaClient({
    datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
  });
  const tenantId = 'order-ratecut-posting';
  const YEAR = '2024-2025';
  const scope = (coBook: string) => ({
    tenantId,
    coCode: '01',
    lcCode: '01',
    coYear: YEAR,
    coBook,
  });
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
    'ITEM_MAST',
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
       VALUES($1,'01','01','510','Tour Order','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA','A'),
             ($1,'01','01','SOR','Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA','A')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES($1,'01','01','SOR',1,'CASH','SALES ORDER','O'),($1,'01','01','510',1,'CASH','TOUR ORDER','I')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES($1,'01','01','PARTY','Rate customer'),($1,'01','01','CASH','Cash'),
             ($1,'01','01','BANK1','Bank'),($1,'01','01','CARD1','Card')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","PR_CODE") VALUES($1,'01','GL','Gold','G','E1','01')`,
      tenantId,
    );
  });
  afterAll(async () => {
    await clean();
    await runtime.$disconnect();
    await owner.$disconnect();
  });

  const line = {
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
  };
  const common = {
    vchDate: '2024-07-10',
    vchTime: '11:22:33',
    mainUser: 'clerk',
    acCode: 'PARTY',
    acName: 'Rate customer',
    vchDesc: 'Rate-cut order',
    taxRatePct: 0,
    cashAc: 'CASH',
    lines: [line],
  };
  // Tour: the cash advance plus the typed old gold, old silver and scheme amounts.
  const tourInput = (extra: Record<string, unknown> = {}) => ({
    ...common,
    scope: scope('510'),
    advanceAmount: 2500,
    oldGoldAmount: 100,
    oldSilverAmount: 50,
    schemeAmount: 20,
    rateCutRate: 6500,
    rateCutFine: 0.412,
    ...extra,
  });
  // Sales Order: cash, cheque and card tenders.
  const salesInput = (extra: Record<string, unknown> = {}) => ({
    ...common,
    scope: scope('SOR'),
    advanceAmount: 1000,
    chequeAmount: 500,
    bankAc: 'BANK1',
    chequeNo: '000123',
    cardAmount: 300,
    cardAc: 'CARD1',
    rateCutRate: 6000,
    rateCutFine: 0.3,
    ...extra,
  });

  // The desktop's INSERT ... SELECT (Ac_Ledr.cs:53), run over the saved header, with the AC_DATA column types.
  const DESKTOP_LEDGER = `
    SELECT A."CO_CODE",A."LC_CODE",A."CO_YEAR",A."CO_BOOK",B."BOOK_SNAME" AS "VCH_TYPE",A."VCH_NO",A."VCH_DATE",
           A."CO_CODE"||A."LC_CODE"||A."CO_YEAR"||A."CO_BOOK"||A."VCH_NO"||'11' AS "LEDR_KEY",B."MAIN_BOOK" AS "BOOK_NAME",
           ''::text AS "BILL_NO",NULL::date AS "BILL_DATE",''::text AS "CHQ_NO",A."AC_CODE",'00008'::text AS "LD_CODE",
           0::numeric(18,2)::text AS "CR_AMT",
           (A."CASH_AMT"+A."CARD_AMT"+A."CHQ_AMT"+A."OLD_GL_AMT"::numeric+A."OLD_SL_AMT"::numeric+A."SCHM_AMT")::numeric(18,2)::text AS "DR_AMT",
           'G'::text AS "IT_TYPE",'+'::text AS "SIGN",A."RCUT_FINE"::numeric(14,3)::text AS "FINE_WT",''::text AS "IT_DESC",
           A."VCH_TIME" AS "ENTRY_TIME",A."HD_VCH_NO",NULL::date AS "CLR_DATE",B."DATA_TYPE",'N'::text AS "DATA_TRFR",
           A."MAIN_USER",0::numeric(14,3)::text AS "FINE_RATE",A."AC_CODE" AS "PARTY_AC_CODE",''::text AS "LDR_NAME"
      FROM "SL_ORD_DATA" A LEFT JOIN "BOOK_DATA" B ON A.tenant_id=B.tenant_id AND A."CO_CODE"=B."CO_CODE"
       AND A."LC_CODE"=B."LC_CODE" AND A."CO_BOOK"=B."CO_BOOK"
     WHERE A.tenant_id=$1 AND B."MAIN_BOOK" IN ('SALES ORDER','TOUR ORDER') AND B."BOOK_INOUT"='I' AND A."RCUT_FINE"<>0`;
  const WEB_LEDGER = `
    SELECT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_TYPE","VCH_NO","VCH_DATE","LEDR_KEY","BOOK_NAME","BILL_NO",
           "BILL_DATE","CHQ_NO","AC_CODE","LD_CODE","CR_AMT"::text AS "CR_AMT","DR_AMT"::text AS "DR_AMT","IT_TYPE","SIGN",
           "FINE_WT"::text AS "FINE_WT","IT_DESC","ENTRY_TIME","HD_VCH_NO","CLR_DATE","DATA_TYPE","DATA_TRFR","MAIN_USER",
           "FINE_RATE"::text AS "FINE_RATE","PARTY_AC_CODE","LDR_NAME"
      FROM "AC_DATA" WHERE tenant_id=$1 AND "LEDR_KEY" ~ '^.{21}11$' AND "LD_CODE"='00008'`;
  // The desktop's Order_Rojmel type 07 (Ac_Rojmel.cs:23), with the ROJ_MEL_DATA column types.
  const DESKTOP_DAYBOOK = `
    SELECT A."CO_CODE",A."LC_CODE",A."CO_YEAR",A."CO_BOOK",A."VCH_NO",
           A."CO_CODE"||A."LC_CODE"||A."CO_YEAR"||A."CO_BOOK"||A."VCH_NO"||'07' AS "LEDR_KEY",A."VCH_DATE",
           B."BOOK_SNAME" AS "VCH_TYPE",B."MAIN_BOOK" AS "BOOK_NAME",A."AC_CODE",'00008'::text AS "LD_CODE",
           0::numeric(18,2)::text AS "CR_AMT",
           (A."CASH_AMT"+A."CARD_AMT"+A."CHQ_AMT"+A."OLD_GL_AMT"::numeric+A."OLD_SL_AMT"::numeric+A."SCHM_AMT")::numeric(18,2)::text AS "DR_AMT",
           A."AC_NAME",'G'::text AS "IT_TYPE",'+'::text AS "SIGN",0::numeric(12,3)::text AS "ITM_PCS",
           A."RCUT_FINE"::numeric(14,3)::text AS "ITM_GWT",A."RCUT_FINE"::numeric(14,3)::text AS "ITM_NWT",
           0::numeric(14,3)::text AS "ITM_TOUCH",0::numeric(14,3)::text AS "ITM_WEST",
           A."RCUT_FINE"::numeric(14,3)::text AS "ITM_FINE",A."RCUT_RATE"::numeric(18,2)::text AS "ITM_RATE",
           0::numeric(18,2)::text AS "ITM_AMT",0::numeric(18,2)::text AS "LBR_RATE",0::numeric(18,2)::text AS "LBR_AMT",
           0::numeric(18,2)::text AS "OTH_AMT",0::numeric(18,2)::text AS "NET_AMT",A."VCH_DESC" AS "IT_DESC",
           ''::text AS "IT_CODE",''::text AS "MEMB_CODE",''::text AS "SCHM_CODE",''::text AS "REF_NO",B."DATA_TYPE"
      FROM "SL_ORD_DATA" A LEFT JOIN "BOOK_DATA" B ON A.tenant_id=B.tenant_id AND A."CO_CODE"=B."CO_CODE"
       AND A."LC_CODE"=B."LC_CODE" AND A."CO_BOOK"=B."CO_BOOK"
     WHERE A.tenant_id=$1 AND B."MAIN_BOOK" IN ('SALES ORDER','TOUR ORDER') AND A."RCUT_FINE"<>0`;
  const WEB_DAYBOOK = `
    SELECT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","VCH_TYPE","BOOK_NAME","AC_CODE",
           "LD_CODE","CR_AMT"::text AS "CR_AMT","DR_AMT"::text AS "DR_AMT","AC_NAME","IT_TYPE","SIGN",
           "ITM_PCS"::text AS "ITM_PCS","ITM_GWT"::text AS "ITM_GWT","ITM_NWT"::text AS "ITM_NWT",
           "ITM_TOUCH"::text AS "ITM_TOUCH","ITM_WEST"::text AS "ITM_WEST","ITM_FINE"::text AS "ITM_FINE",
           "ITM_RATE"::text AS "ITM_RATE","ITM_AMT"::text AS "ITM_AMT","LBR_RATE"::text AS "LBR_RATE",
           "LBR_AMT"::text AS "LBR_AMT","OTH_AMT"::text AS "OTH_AMT","NET_AMT"::text AS "NET_AMT","IT_DESC","IT_CODE",
           "MEMB_CODE","SCHM_CODE","REF_NO","DATA_TYPE"
      FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "LEDR_KEY" ~ '^.{21}07$'`;
  const ledgerRows = () => query(WEB_LEDGER, tenantId);
  const dayBookRows = () => query(WEB_DAYBOOK, tenantId);
  const dayBookKeys = async () =>
    (
      await query(
        `SELECT right("LEDR_KEY",2) t,"CR_AMT"::float cr,"DR_AMT"::float dr FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND length("LEDR_KEY")=23 ORDER BY "LEDR_KEY"`,
        tenantId,
      )
    ).map((row) => `${row.t}:${row.cr}/${row.dr}`);
  const voucherBalance = async () =>
    (
      await query(
        `SELECT coalesce(sum("DR_AMT"),0)::float dr,coalesce(sum("CR_AMT"),0)::float cr FROM "AC_DATA" WHERE tenant_id=$1`,
        tenantId,
      )
    )[0];

  it('Tour Order: AC_DATA key 11 and day book 07 equal the desktop statements; no day-book 01; one-sided by the debit', async () => {
    await createTourOrder(runtime, tourInput() as any);
    const desktopLedger = await query(DESKTOP_LEDGER, tenantId);
    expect(desktopLedger).toHaveLength(1);
    expect(await ledgerRows()).toEqual(desktopLedger);
    // The literal values, so the comparison above cannot pass on two identical mistakes.
    expect(desktopLedger[0]).toMatchObject({
      LEDR_KEY: '01012024-202551000001' + '11',
      VCH_TYPE: 'TUROD',
      BOOK_NAME: 'TOUR ORDER',
      AC_CODE: 'PARTY',
      LD_CODE: '00008',
      CR_AMT: '0.00',
      DR_AMT: '2670.00', // 2500 cash + 100 old gold + 50 old silver + 20 scheme
      IT_TYPE: 'G',
      SIGN: '+',
      FINE_WT: '0.412',
      HD_VCH_NO: '00001',
      MAIN_USER: 'clerk',
      PARTY_AC_CODE: 'PARTY',
      DATA_TYPE: 'A',
    });
    const desktopDayBook = await query(DESKTOP_DAYBOOK, tenantId);
    expect(desktopDayBook).toHaveLength(1);
    expect(await dayBookRows()).toEqual(desktopDayBook);
    expect(desktopDayBook[0]).toMatchObject({
      LEDR_KEY: '01012024-202551000001' + '07',
      DR_AMT: '2670.00',
      ITM_FINE: '0.412',
      ITM_GWT: '0.412',
      ITM_NWT: '0.412',
      ITM_RATE: '6500.00',
      AC_NAME: 'Rate customer',
      IT_DESC: 'Rate-cut order',
    });
    // Type 01 reads ADV_AMT, which a rate-cut order saves as 0 (Ac_Rojmel.cs:11).
    expect(await dayBookKeys()).toEqual(['07:0/2670']);
    // The cash pair still balances; the ledger is out by exactly the one-sided debit.
    expect(await voucherBalance()).toEqual({ dr: 2500 + 2670, cr: 2500 });
    // The rate-cut leg is not read back as the cash account or the advance.
    const doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    expect(doc.cashAc).toBe('CASH');
    expect(doc.advanceAmount).toBe(2500);
  });

  it('Sales Order on its O book: day book 07 as the desktop writes it, no key 11 (BOOK_INOUT filter, Ac_Ledr.cs:53)', async () => {
    await createSalesOrder(runtime, salesInput() as any);
    expect(await query(DESKTOP_LEDGER, tenantId)).toEqual([]);
    expect(await ledgerRows()).toEqual([]);
    const desktopDayBook = await query(DESKTOP_DAYBOOK, tenantId);
    expect(desktopDayBook).toHaveLength(1);
    expect(await dayBookRows()).toEqual(desktopDayBook);
    expect(desktopDayBook[0]).toMatchObject({
      VCH_TYPE: 'SORD',
      BOOK_NAME: 'SALES ORDER',
      DR_AMT: '1800.00', // 1000 cash + 500 cheque + 300 card
      ITM_FINE: '0.300',
      ITM_RATE: '6000.00',
    });
    // Cheque 02 and card 03 stay; type 01 does not (ADV_AMT is 0).
    expect(await dayBookKeys()).toEqual(['02:0/500', '03:0/300', '07:0/1800']);
    expect(await voucherBalance()).toEqual({ dr: 1800, cr: 1800 });
    const doc = (await getSalesOrder(runtime, scope('SOR'), 1)) as any;
    expect([doc.advanceAmount, doc.cashAc]).toEqual([1000, 'CASH']);
  });

  it('an edit replaces the rows from the new header; removing the rate cut removes them and brings back type 01', async () => {
    await createTourOrder(runtime, tourInput() as any);
    let doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    await editTourOrder(
      runtime,
      {
        ...doc,
        scope: scope('510'),
        expectedVersion: doc.version,
        advanceAmount: 3000,
        rateCutFine: 0.5,
        dirtyFields: ['advanceAmount', 'rateCutFine'],
      } as any,
      '00001',
    );
    const desktopLedger = await query(DESKTOP_LEDGER, tenantId);
    expect(desktopLedger).toHaveLength(1);
    expect(desktopLedger[0]).toMatchObject({ DR_AMT: '3170.00', FINE_WT: '0.500' });
    expect(await ledgerRows()).toEqual(desktopLedger);
    expect(await dayBookRows()).toEqual(await query(DESKTOP_DAYBOOK, tenantId));
    expect(await dayBookKeys()).toEqual(['07:0/3170']);

    doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    await editTourOrder(
      runtime,
      {
        ...doc,
        scope: scope('510'),
        expectedVersion: doc.version,
        rateCutRate: 0,
        rateCutFine: 0,
        dirtyFields: ['rateCutRate', 'rateCutFine'],
      } as any,
      '00001',
    );
    expect(await ledgerRows()).toEqual([]);
    expect(await dayBookRows()).toEqual([]);
    expect(await dayBookKeys()).toEqual(['01:3000/0']);
    expect(await voucherBalance()).toEqual({ dr: 3000, cr: 3000 });
  });

  it('a Sales Order edit keeps day book 07 in step with the header', async () => {
    await createSalesOrder(runtime, salesInput() as any);
    const doc = (await getSalesOrder(runtime, scope('SOR'), 1)) as any;
    await editSalesOrder(
      runtime,
      {
        ...doc,
        scope: scope('SOR'),
        expectedVersion: doc.version,
        mainUser: 'clerk',
        advanceAmount: 1200,
        dirtyFields: ['advanceAmount'],
      } as any,
      1,
    );
    expect(await dayBookRows()).toEqual(await query(DESKTOP_DAYBOOK, tenantId));
    expect(await dayBookKeys()).toEqual(['02:0/500', '03:0/300', '07:0/2000']);
  });

  it('delete removes the rate-cut rows with the rest of the voucher', async () => {
    await createTourOrder(runtime, tourInput() as any);
    await createSalesOrder(runtime, salesInput() as any);
    await cancelTourOrder(runtime, { scope: scope('510'), vchNo: '00001', deleteUser: 'clerk' });
    await cancelSalesOrder(runtime, {
      scope: scope('SOR'),
      vchNo: '00001',
      deleteUser: 'clerk',
    } as any);
    expect(
      await query(`SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1`, tenantId),
    ).toEqual([{ n: 0 }]);
    expect(
      await query(`SELECT count(*)::int n FROM "ROJ_MEL_DATA" WHERE tenant_id=$1`, tenantId),
    ).toEqual([{ n: 0 }]);
  });

  it('an order without a rate cut writes no key 11 and no type 07', async () => {
    await createTourOrder(runtime, tourInput({ rateCutRate: 0, rateCutFine: 0 }) as any);
    await createSalesOrder(runtime, salesInput({ rateCutRate: 0, rateCutFine: 0 }) as any);
    expect(await ledgerRows()).toEqual([]);
    expect(await dayBookRows()).toEqual([]);
    expect(await dayBookKeys()).toEqual(['01:2500/0', '01:1800/0', '02:0/500', '03:0/300']);
  });
});
