import { PrismaClient } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createSalesOrder,
  editSalesOrder,
  getSalesOrder,
  cancelSalesOrder,
} from '../src/modules/sales/salesOrder.js';

/**
 * G206 (old metal): TR_SALE_ORD's MSG_OLD rows. SL_PR_DETL is one row per saved grid row (:9421-9475); OLD_GL_AMT,
 * OLD_SL_AMT, OLD_GL and OLD_SL are the grid totals and ADV_AMT includes both amounts (:11345-11368); Order_Rojmel
 * keys a valued row 04 + STR(SR_NO) and fine with no amount 06 + STR(SR_NO) (Ac_Rojmel.cs:17-21). Order_Ledr legs
 * 07-10 join BOOK_INOUT = 'I' (Ac_Ledr.cs:42-50), and a Sales Order book is 'O', so the ledger carries the cash legs.
 */
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Sales Order old gold and old silver', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const tenantId = 'sales-order-old-metal';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'S95' };
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
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01','2024-2025','2024-04-01','2025-03-31')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","BOOK_NAME","CUR_USE","BOOK_TBL_NAME") VALUES($1,'01','01','S95','SALES ORDER','O','SORD','Sales Order','Y','SL_ORD_DATA')`,
      tenantId,
    );
    // A provisioned Sales Order book holds the cash account in slot 1 (seedCompany, N198).
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT") VALUES($1,'01','01','S95',1,'CASH','SALES ORDER','O')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PARTY','Saved customer'),($1,'01','01','CASH','Cash'),($1,'01','01','PURCHASE','Gold purchase'),($1,'01','01','SLVPURC','Silver purchase')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC") VALUES($1,'01','E1','Gold','PURCHASE'),($1,'01','E2','Silver','SLVPURC'),($1,'01','E3','No purchase account',NULL)`,
      tenantId,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","PR_CODE") VALUES($1,'01','GL','Gold','G','E1','01'),($1,'01','SV','Silver','S','E2','01'),($1,'01','NP','No account','G','E3','01')`,
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
  const gold = {
    itCode: 'GL',
    pcs: 1,
    grossWt: 10.5,
    otherWt: 0.5,
    touch: 91.6,
    rateType: 'F',
    netAmt: 2000,
  };
  const silverUnvalued = { itCode: 'SV', pcs: 2, grossWt: 20, touch: 100, rateType: 'F' };
  const input = (extra: Record<string, unknown> = {}) => ({
    scope,
    vchDate: '2024-07-10',
    mainUser: 'clerk',
    acCode: 'PARTY',
    acName: 'Saved customer',
    taxRatePct: 0,
    advanceAmount: 1000,
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
  const header = async () =>
    (
      await query(
        `SELECT "CASH_AMT"::float cash,"ADV_AMT"::float adv,"OLD_GL_AMT"::float "glAmt","OLD_SL_AMT"::float "slAmt",
                "OLD_GL"::float gl,"OLD_SL"::float sl
           FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001'`,
        tenantId,
      )
    )[0];
  const detail = () =>
    query(
      `SELECT "SR_NO"::int sr,btrim("IT_CODE") it,btrim("IT_TYPE") typ,btrim("IT_DESC") descr,"ITM_PCS"::float pcs,
              "ITM_GWT"::float gwt,"ITM_OTH"::float oth,"ITM_NWT"::float nwt,"ITM_TOUCH"::float touch,
              "ITM_FINE"::float fine,btrim("ITM_RATE_TYPE") rtype,"ITM_RATE"::float rate,"NET_AMT"::float net,
              btrim("ENTRY_TYPE") entry,btrim("VCH_TYPE") vtype,btrim("INOUT_TYPE") inout,btrim("BOOK_NAME") book,
              btrim("AC_CODE") ac,btrim("HD_VCH_NO") hd,btrim("MAIN_USER") mu
         FROM "SL_PR_DETL" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      tenantId,
    );
  const keyed = (table: 'AC_DATA' | 'ROJ_MEL_DATA') =>
    query(
      `SELECT substr("LEDR_KEY",22,2) leg,btrim(substr("LEDR_KEY",24)) line,length("LEDR_KEY")::int len,
              btrim("AC_CODE") ac,btrim("LD_CODE") ld,"DR_AMT"::float dr,"CR_AMT"::float cr,btrim("IT_TYPE") typ,
              btrim(coalesce("SIGN",'')) sign,
              ${table === 'ROJ_MEL_DATA' ? `"ITM_FINE"::float fine,btrim("IT_CODE") it` : `0::float fine,''::text it`}
         FROM "${table}" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      tenantId,
    );
  const counts = async () =>
    (
      await query(
        `SELECT (SELECT count(*) FROM "SL_ORD_DATA" WHERE tenant_id=$1)::int ord,
                (SELECT count(*) FROM "SL_PR_DETL" WHERE tenant_id=$1)::int detl,
                (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1)::int ac,
                (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1)::int roj`,
        tenantId,
      )
    )[0];
  const loaded = () => getSalesOrder(runtime, scope, 1) as Promise<any>;
  const replacement = (doc: any, extra: Record<string, unknown> = {}) => ({
    ...doc,
    scope,
    expectedVersion: doc.version,
    mainUser: 'clerk',
    ...extra,
  });

  it('refuses a bad row and leaves nothing behind', async () => {
    const empty = { ord: 0, detl: 0, ac: 0, roj: 0 };
    await expect(
      createSalesOrder(runtime, input({ oldMetalRows: [{ ...gold, itCode: 'NOPE' }] }) as any),
    ).rejects.toThrow('Item NOPE on old metal line 1 is not in the item master');
    await expect(
      createSalesOrder(runtime, input({ oldMetalRows: [{ ...gold, itCode: 'NP' }] }) as any),
    ).rejects.toThrow('The item group of NP on old metal line 1 has no purchase account');
    await expect(
      createSalesOrder(runtime, input({ oldMetalRows: [{ ...gold, rateType: 'X' }] }) as any),
    ).rejects.toThrow('Please Slelect Rate type = N - Net Wise Or F - Fine Wise');
    await expect(
      createSalesOrder(runtime, input({ oldMetalRows: [{ ...gold, grossWt: -1 }] }) as any),
    ).rejects.toThrow('GrWt on old metal line 1 must be a non-negative number');
    expect(await counts()).toEqual(empty);
  });

  it('stores the rows, totals, advance and day book; edits, reopens and deletes them', async () => {
    const rows = [gold, { itCode: '', grossWt: 9 }, silverUnvalued];
    await createSalesOrder(runtime, input({ oldMetalRows: rows }) as any);

    expect(await header()).toEqual({
      cash: 1000,
      adv: 3000,
      glAmt: 2000,
      slAmt: 0,
      gl: 9.16,
      sl: 20,
    });
    expect(await detail()).toEqual([
      {
        sr: 1,
        it: 'GL',
        typ: 'G',
        descr: 'Gold',
        pcs: 1,
        gwt: 10.5,
        oth: 0.5,
        nwt: 10,
        touch: 91.6,
        fine: 9.16,
        rtype: 'F',
        rate: 218,
        net: 2000,
        entry: 'A',
        vtype: 'SORD',
        inout: 'O',
        book: 'SALES ORDER',
        ac: 'PARTY',
        hd: '00001',
        mu: 'clerk',
      },
      {
        sr: 3,
        it: 'SV',
        typ: 'S',
        descr: 'Silver',
        pcs: 2,
        gwt: 20,
        oth: 0,
        nwt: 20,
        touch: 100,
        fine: 20,
        rtype: 'F',
        rate: 0,
        net: 0,
        entry: 'A',
        vtype: 'SORD',
        inout: 'O',
        book: 'SALES ORDER',
        ac: 'PARTY',
        hd: '00001',
        mu: 'clerk',
      },
    ]);
    // A Sales Order book is 'O': legs 07-10 are not posted (Ac_Ledr.cs:42-50 needs BOOK_INOUT = 'I').
    expect((await keyed('AC_DATA')).map((r) => [r.leg, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'PARTY', 0, 1000],
      ['02', 'CASH', 1000, 0],
    ]);
    const day = await keyed('ROJ_MEL_DATA');
    expect(
      day.map((r) => [r.leg, r.line, r.len, r.ac, r.ld, r.dr, r.cr, r.typ, r.sign, r.fine, r.it]),
    ).toEqual([
      ['01', '', 23, 'PARTY', 'CASH', 0, 3000, 'A', '', 0, ''],
      ['04', '1', 33, 'PURCHASE', 'PARTY', 2000, 0, 'A', '', 9.16, 'GL'],
      ['06', '3', 33, 'PARTY', 'SLVPURC', 0, 0, 'S', '+', 20, 'SV'],
    ]);

    // Reopen: the grid rows come back, and an order with old metal can be edited.
    const doc = await loaded();
    expect(doc.editBlockedReason).toBeUndefined();
    expect(doc.oldMetalRows).toEqual([
      {
        srNo: 1,
        itCode: 'GL',
        itName: 'Gold',
        itType: 'G',
        pcs: 1,
        grossWt: 10.5,
        otherWt: 0.5,
        netWt: 10,
        touch: 91.6,
        fine: 9.16,
        rateType: 'F',
        rate: 218,
        netAmt: 2000,
      },
      {
        srNo: 3,
        itCode: 'SV',
        itName: 'Silver',
        itType: 'S',
        pcs: 2,
        grossWt: 20,
        otherWt: 0,
        netWt: 20,
        touch: 100,
        fine: 20,
        rateType: 'F',
        rate: 0,
        netAmt: 0,
      },
    ]);
    expect([doc.advanceAmount, doc.oldGoldAmount, doc.oldSilverFine]).toEqual([1000, 2000, 20]);

    // An edit that omits the rows would delete them silently, so it is refused and nothing changes.
    const before = await counts();
    await expect(
      editSalesOrder(runtime, replacement(doc, { oldMetalRows: undefined }) as any, 1),
    ).rejects.toThrow(
      'This order has old metal rows. Reload it and submit its old metal rows before editing.',
    );
    expect(await counts()).toEqual(before);

    // Edit: the gold amount 2,000 -> 2,500 (rate 218 no longer makes it, so the rate follows) and the silver gets 800.
    await editSalesOrder(
      runtime,
      replacement(doc, {
        oldMetalRows: [
          { ...doc.oldMetalRows[0], netAmt: 2500 },
          { itCode: '', grossWt: 0 },
          { ...doc.oldMetalRows[1], netAmt: 800 },
        ],
      }) as any,
      1,
    );
    expect(await header()).toEqual({
      cash: 1000,
      adv: 4300,
      glAmt: 2500,
      slAmt: 800,
      gl: 9.16,
      sl: 20,
    });
    expect((await detail()).map((r) => [r.sr, r.net, r.rate])).toEqual([
      [1, 2500, 273],
      [3, 800, 40],
    ]);
    expect((await keyed('ROJ_MEL_DATA')).map((r) => [r.leg, r.line, r.dr, r.cr])).toEqual([
      ['01', '', 0, 4300],
      ['04', '1', 2500, 0],
      ['04', '3', 800, 0],
    ]);

    // Delete leaves nothing: no header, rows, ledger or day book.
    await cancelSalesOrder(runtime, { scope, vchNo: 1, expectedVersion: (await loaded()).version });
    expect(await counts()).toEqual({ ord: 0, detl: 0, ac: 0, roj: 0 });
  });

  it('keeps old metal as the only tender: cash 0, advance is the metal, the day book contra is the cash account', async () => {
    await createSalesOrder(
      runtime,
      input({ advanceAmount: 0, cashAc: 'CASH', oldMetalRows: [gold] }) as any,
    );
    expect(await header()).toEqual({ cash: 0, adv: 2000, glAmt: 2000, slAmt: 0, gl: 9.16, sl: 0 });
    expect((await keyed('AC_DATA')).length).toBe(0);
    expect((await keyed('ROJ_MEL_DATA')).map((r) => [r.leg, r.ac, r.ld, r.dr, r.cr])).toEqual([
      ['01', 'PARTY', 'CASH', 0, 2000],
      ['04', 'PURCHASE', 'PARTY', 2000, 0],
    ]);
    // Reopening must not read the 2,000 advance back as a cash advance.
    const doc = await loaded();
    expect(doc.advanceAmount).toBe(0);
    await editSalesOrder(runtime, replacement(doc, { oldMetalRows: doc.oldMetalRows }) as any, 1);
    expect(await header()).toEqual({ cash: 0, adv: 2000, glAmt: 2000, slAmt: 0, gl: 9.16, sl: 0 });
  });

  it('blocks the edit of an order that carries old metal amounts but no rows (the desktop T book path)', async () => {
    await createSalesOrder(runtime, input() as any);
    await sql(`UPDATE "SL_ORD_DATA" SET "OLD_GL_AMT"=1500,"OLD_GL"=5 WHERE tenant_id=$1`, tenantId);
    const doc = await loaded();
    expect(doc.editBlockedReason).toMatch(/metal, settlement or stock allocations/);
    await expect(editSalesOrder(runtime, replacement(doc) as any, 1)).rejects.toThrow(
      /metal, settlement or stock allocations/,
    );
    expect((await header()).glAmt).toBe(1500);
  });

  it('ignores old metal totals typed into the request: the grid decides', async () => {
    await createSalesOrder(
      runtime,
      input({
        oldGoldAmount: 999,
        oldGoldFine: 99,
        oldSilverAmount: 888,
        oldSilverFine: 88,
        oldMetalRows: [gold],
      }) as any,
    );
    expect(await header()).toEqual({
      cash: 1000,
      adv: 3000,
      glAmt: 2000,
      slAmt: 0,
      gl: 9.16,
      sl: 0,
    });
  });
});
