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
 * The money rows of a Sales Order and a Tour Order, compared column by column with the desktop's own statements run
 * over the saved header: Order_Ledr legs 01-06 and 12/13 (Ac_Ledr.cs:30-40, :55-57) and Order_Rojmel types 01, 02, 03
 * and 08 (Ac_Rojmel.cs:11-16, :25). Both forms rebuild them on every save (TR_SALE_ORD.cs:9558-9563,
 * TR_TOUR_ORD.cs:7609-7614) and delete removes them (TR_SALE_ORD.cs:9729-9730, TR_TOUR_ORD.cs:7753-7754).
 */
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Order money ledger and day book follow Ac_Ledr.cs:30-40 and Ac_Rojmel.cs:11-25', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });
  const runtime = new PrismaClient({
    datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
  });
  const tenantId = 'order-money-posting';
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
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE")
       VALUES($1,'01','01','SOR',1,'CASH','SORD','SALES ORDER','O','A'),($1,'01','01','510',1,'CASH','TUROD','TOUR ORDER','I','A')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES($1,'01','01','PARTY','Mixed customer'),($1,'01','01','CASH','Cash'),($1,'01','01','BANK1','Bank'),
             ($1,'01','01','CARD1','Card'),($1,'01','01','UPI1','Upi bank')`,
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
    acName: 'Mixed customer',
    vchDesc: 'Mixed tenders',
    billNo: 'B-77',
    taxRatePct: 0,
    cashAc: 'CASH',
    lines: [line],
  };
  const salesInput = (extra: Record<string, unknown> = {}) => ({
    ...common,
    scope: scope('SOR'),
    advanceAmount: 1000,
    chequeAmount: 500,
    bankAc: 'BANK1',
    chequeNo: '000123',
    cardAmount: 300,
    cardAc: 'CARD1',
    cardAdj: 'N',
    upiRows: [{ upiAc: 'UPI1', upiType: 'GPAY', upiId: 'id-1', amount: 200 }],
    ...extra,
  });
  const tourInput = (extra: Record<string, unknown> = {}) => ({
    ...common,
    scope: scope('510'),
    advanceAmount: 1000,
    ...extra,
  });

  const HEAD = `A."CO_CODE"||A."LC_CODE"||A."CO_YEAR"||A."CO_BOOK"||A."VCH_NO"`;
  const FROM_SLOT = `FROM "SL_ORD_DATA" A LEFT JOIN "BOOK_DETL" B ON A.tenant_id=B.tenant_id AND A."CO_CODE"=B."CO_CODE"
       AND A."LC_CODE"=B."LC_CODE" AND A."CO_BOOK"=B."CO_BOOK" WHERE A.tenant_id=$1 AND B."SR_NO"=1`;
  const leg = (
    suffix: string,
    chq: string,
    ac: string,
    ld: string,
    cr: string,
    dr: string,
    ldr: string,
    where: string,
  ) => `
    SELECT A."CO_CODE",A."LC_CODE",A."CO_YEAR",A."CO_BOOK",B."BOOK_SNAME" AS "VCH_TYPE",A."VCH_NO",A."VCH_DATE",
           ${HEAD}||'${suffix}' AS "LEDR_KEY",B."MAIN_BOOK" AS "BOOK_NAME",A."BILL_NO",NULL::date AS "BILL_DATE",
           ${chq} AS "CHQ_NO",${ac} AS "AC_CODE",${ld} AS "LD_CODE",(${cr})::numeric(18,2)::text AS "CR_AMT",
           (${dr})::numeric(18,2)::text AS "DR_AMT",'A' AS "IT_TYPE",'' AS "SIGN",'0.000' AS "FINE_WT",'' AS "IT_DESC",
           A."VCH_TIME" AS "ENTRY_TIME",A."HD_VCH_NO",NULL::date AS "CLR_DATE",B."DATA_TYPE",'N' AS "DATA_TRFR",
           A."MAIN_USER",'0.000' AS "FINE_RATE",A."AC_CODE" AS "PARTY_AC_CODE",${ldr} AS "LDR_NAME"
      ${FROM_SLOT} AND ${where}`;
  // Ac_Ledr.cs:30-40 legs 01-06 and :55-57 legs 12/13.
  const DESKTOP_LEDGER = `
    ${leg('01', "''", 'A."AC_CODE"', 'B."AC_CODE"', 'A."CASH_AMT"', '0', `'CASH - '||A."AC_NAME"`, 'A."CASH_AMT"<>0')}
    UNION ALL ${leg('02', "''", 'B."AC_CODE"', 'A."AC_CODE"', '0', 'A."CASH_AMT"', "''", 'A."CASH_AMT"<>0')}
    UNION ALL ${leg('03', 'A."CHQ_NO"', 'A."AC_CODE"', 'A."BANK_AC"', 'A."CHQ_AMT"', '0', `'BANK - '||A."AC_NAME"`, 'A."CHQ_AMT"<>0')}
    UNION ALL ${leg('04', 'A."CHQ_NO"', 'A."BANK_AC"', 'A."AC_CODE"', '0', 'A."CHQ_AMT"', "''", 'A."CHQ_AMT"<>0')}
    UNION ALL ${leg('05', 'A."CHQ_NO"', 'A."AC_CODE"', 'A."CARD_AC"', 'A."CARD_AMT"', '0', `'CARD - '||A."AC_NAME"`, `A."CARD_AMT"<>0 AND A."CARD_ADJ"<>'Y'`)}
    UNION ALL ${leg('06', 'A."CHQ_NO"', 'A."CARD_AC"', 'A."AC_CODE"', '0', 'A."CARD_AMT"', "''", `A."CARD_AMT"<>0 AND A."CARD_ADJ"<>'Y'`)}
    UNION ALL
    SELECT A."CO_CODE",A."LC_CODE",A."CO_YEAR",A."CO_BOOK",B."BOOK_SNAME",A."VCH_NO",A."VCH_DATE",
           ${HEAD}||'12'||lpad(C."SR_NO"::text,10) ,B."MAIN_BOOK",A."BILL_NO",NULL::date,'',A."AC_CODE",C."UPI_AC_CODE",
           C."UPI_AMT"::numeric(18,2)::text,'0.00','A','','0.000','',A."VCH_TIME",A."HD_VCH_NO",NULL::date,B."DATA_TYPE",'N',
           A."MAIN_USER",'0.000',A."AC_CODE",'UPI - '||A."AC_NAME"
      FROM "SL_ORD_DATA" A JOIN "BOOK_DATA" B ON A.tenant_id=B.tenant_id AND A."CO_CODE"=B."CO_CODE" AND A."LC_CODE"=B."LC_CODE"
       AND A."CO_BOOK"=B."CO_BOOK" JOIN "UPI_DATA" C ON A.tenant_id=C.tenant_id AND A."CO_CODE"=C."CO_CODE"
       AND A."LC_CODE"=C."LC_CODE" AND A."CO_YEAR"=C."CO_YEAR" AND A."CO_BOOK"=C."CO_BOOK" AND A."VCH_NO"=C."VCH_NO"
     WHERE A.tenant_id=$1 AND B."MAIN_BOOK"='SALES ORDER' AND C."UPI_AMT"<>0
    UNION ALL
    SELECT A."CO_CODE",A."LC_CODE",A."CO_YEAR",A."CO_BOOK",B."BOOK_SNAME",A."VCH_NO",A."VCH_DATE",
           ${HEAD}||'13'||lpad(C."SR_NO"::text,10),B."MAIN_BOOK",A."BILL_NO",NULL::date,'',C."UPI_AC_CODE",A."AC_CODE",
           '0.00',C."UPI_AMT"::numeric(18,2)::text,'A','','0.000','',A."VCH_TIME",A."HD_VCH_NO",NULL::date,B."DATA_TYPE",'N',
           A."MAIN_USER",'0.000',A."AC_CODE",''
      FROM "SL_ORD_DATA" A JOIN "BOOK_DATA" B ON A.tenant_id=B.tenant_id AND A."CO_CODE"=B."CO_CODE" AND A."LC_CODE"=B."LC_CODE"
       AND A."CO_BOOK"=B."CO_BOOK" JOIN "UPI_DATA" C ON A.tenant_id=C.tenant_id AND A."CO_CODE"=C."CO_CODE"
       AND A."LC_CODE"=C."LC_CODE" AND A."CO_YEAR"=C."CO_YEAR" AND A."CO_BOOK"=C."CO_BOOK" AND A."VCH_NO"=C."VCH_NO"
     WHERE A.tenant_id=$1 AND B."MAIN_BOOK"='SALES ORDER' AND C."UPI_AMT"<>0
    ORDER BY 8`;
  const WEB_LEDGER = `
    SELECT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_TYPE","VCH_NO","VCH_DATE","LEDR_KEY","BOOK_NAME","BILL_NO",
           "BILL_DATE","CHQ_NO","AC_CODE","LD_CODE","CR_AMT"::text,"DR_AMT"::text,"IT_TYPE","SIGN","FINE_WT"::text,"IT_DESC",
           "ENTRY_TIME","HD_VCH_NO","CLR_DATE","DATA_TYPE","DATA_TRFR","MAIN_USER","FINE_RATE"::text,"PARTY_AC_CODE","LDR_NAME"
      FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`;
  const roj = (
    suffix: string,
    ac: string,
    cr: string,
    dr: string,
    name: string,
    where: string,
    from = FROM_SLOT,
  ) => `
    SELECT A."CO_CODE",A."LC_CODE",A."CO_YEAR",A."CO_BOOK",A."VCH_NO",${HEAD}||${suffix} AS "LEDR_KEY",A."VCH_DATE",
           B."BOOK_SNAME" AS "VCH_TYPE",B."MAIN_BOOK" AS "BOOK_NAME",${ac} AS "AC_CODE",
           ${suffix === "'01'" ? 'B."AC_CODE"' : 'A."AC_CODE"'} AS "LD_CODE",(${cr})::numeric(18,2)::text AS "CR_AMT",
           (${dr})::numeric(18,2)::text AS "DR_AMT",${name} AS "AC_NAME",'A' AS "IT_TYPE",'' AS "SIGN",
           '0.000' AS "ITM_PCS",'0.000' AS "ITM_GWT",'0.000' AS "ITM_NWT",'0.000' AS "ITM_TOUCH",'0.000' AS "ITM_WEST",
           '0.000' AS "ITM_FINE",'0.00' AS "ITM_RATE",'0.00' AS "ITM_AMT",'0.00' AS "LBR_RATE",'0.00' AS "LBR_AMT",
           '0.00' AS "OTH_AMT",'0.00' AS "NET_AMT",A."VCH_DESC" AS "IT_DESC",'' AS "IT_CODE",'' AS "MEMB_CODE",
           '' AS "SCHM_CODE",'' AS "REF_NO",B."DATA_TYPE"
      ${from} AND ${where}`;
  // Ac_Rojmel.cs:11-16 types 01, 02, 03, :19 type 05 and :25 type 08.
  const DESKTOP_DAYBOOK = `
    ${roj("'01'", 'A."AC_CODE"', 'A."ADV_AMT"', '0', 'A."AC_NAME"', 'A."ADV_AMT"<>0')}
    UNION ALL ${roj("'02'", 'A."BANK_AC"', '0', 'A."CHQ_AMT"', "''", 'A."CHQ_AMT"<>0')}
    UNION ALL ${roj("'03'", 'A."CARD_AC"', '0', 'A."CARD_AMT"', "''", `A."CARD_AMT"<>0 AND A."CARD_ADJ"<>'Y'`)}
    UNION ALL ${roj("'05'", "'00079'", '0', 'A."SCHM_AMT"', `'MADJ - '||A."AC_NAME"`, 'A."SCHM_AMT"<>0')}
    UNION ALL ${roj(
      `'08'||lpad(C."SR_NO"::text,10)`,
      'C."UPI_AC_CODE"',
      '0',
      'C."UPI_AMT"',
      "''",
      'C."UPI_AMT"<>0',
      `FROM "SL_ORD_DATA" A JOIN "BOOK_DATA" B ON A.tenant_id=B.tenant_id AND A."CO_CODE"=B."CO_CODE" AND A."LC_CODE"=B."LC_CODE"
       AND A."CO_BOOK"=B."CO_BOOK" JOIN "UPI_DATA" C ON A.tenant_id=C.tenant_id AND A."CO_CODE"=C."CO_CODE"
       AND A."LC_CODE"=C."LC_CODE" AND A."CO_YEAR"=C."CO_YEAR" AND A."CO_BOOK"=C."CO_BOOK" AND A."VCH_NO"=C."VCH_NO"
       WHERE A.tenant_id=$1 AND B."MAIN_BOOK" IN ('SALES ORDER','TOUR ORDER')`,
    )}
    ORDER BY 6`;
  const WEB_DAYBOOK = `
    SELECT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","VCH_TYPE","BOOK_NAME","AC_CODE","LD_CODE",
           "CR_AMT"::text,"DR_AMT"::text,"AC_NAME","IT_TYPE","SIGN","ITM_PCS"::text,"ITM_GWT"::text,"ITM_NWT"::text,
           "ITM_TOUCH"::text,"ITM_WEST"::text,"ITM_FINE"::text,"ITM_RATE"::text,"ITM_AMT"::text,"LBR_RATE"::text,
           "LBR_AMT"::text,"OTH_AMT"::text,"NET_AMT"::text,"IT_DESC","IT_CODE","MEMB_CODE","SCHM_CODE","REF_NO","DATA_TYPE"
      FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`;
  const snapshot = async () => ({
    ledger: await query(WEB_LEDGER, tenantId),
    dayBook: await query(WEB_DAYBOOK, tenantId),
  });
  const expectDesktop = async () => {
    const desktop = {
      ledger: await query(DESKTOP_LEDGER, tenantId),
      dayBook: await query(DESKTOP_DAYBOOK, tenantId),
    };
    expect(await snapshot()).toEqual(desktop);
    return desktop;
  };
  const legs = (rows: any[]) =>
    rows.map((row) => [
      row.LEDR_KEY.slice(21).trim().replace(/\s+/g, ' '),
      row.AC_CODE,
      row.DR_AMT,
      row.CR_AMT,
    ]);

  it('Sales Order with cash, cheque, card and UPI: every ledger and day-book column is the desktop statement', async () => {
    await createSalesOrder(runtime, salesInput() as any);
    const desktop = await expectDesktop();
    expect(legs(desktop.ledger)).toEqual([
      ['01', 'PARTY', '0.00', '1000.00'],
      ['02', 'CASH', '1000.00', '0.00'],
      ['03', 'PARTY', '0.00', '500.00'],
      ['04', 'BANK1', '500.00', '0.00'],
      ['05', 'PARTY', '0.00', '300.00'],
      ['06', 'CARD1', '300.00', '0.00'],
      ['12 1', 'PARTY', '0.00', '200.00'],
      ['13 1', 'UPI1', '200.00', '0.00'],
    ]);
    expect(
      desktop.ledger.map((row: any) => [row.CHQ_NO, row.LDR_NAME, row.HD_VCH_NO, row.MAIN_USER]),
    ).toEqual([
      ['', 'CASH - Mixed customer', '00001', 'clerk'],
      ['', '', '00001', 'clerk'],
      ['000123', 'BANK - Mixed customer', '00001', 'clerk'],
      ['000123', '', '00001', 'clerk'],
      ['000123', 'CARD - Mixed customer', '00001', 'clerk'],
      ['000123', '', '00001', 'clerk'],
      ['', 'UPI - Mixed customer', '00001', 'clerk'],
      ['', '', '00001', 'clerk'],
    ]);
    expect(legs(desktop.dayBook)).toEqual([
      ['01', 'PARTY', '0.00', '2000.00'],
      ['02', 'BANK1', '500.00', '0.00'],
      ['03', 'CARD1', '300.00', '0.00'],
      ['08 1', 'UPI1', '200.00', '0.00'],
    ]);
    expect(desktop.dayBook.map((row: any) => [row.AC_NAME, row.IT_DESC])).toEqual([
      ['Mixed customer', 'Mixed tenders'],
      ['', 'Mixed tenders'],
      ['', 'Mixed tenders'],
      ['', 'Mixed tenders'],
    ]);
  });

  it('Sales Order: an unchanged re-save keeps every row; an edit rebuilds from the header; delete removes them', async () => {
    await createSalesOrder(runtime, salesInput() as any);
    const before = await snapshot();
    let doc = (await getSalesOrder(runtime, scope('SOR'), 1)) as any;
    await editSalesOrder(
      runtime,
      { ...doc, scope: scope('SOR'), expectedVersion: doc.version, mainUser: 'clerk' } as any,
      1,
    );
    expect(await snapshot()).toEqual(before);
    doc = (await getSalesOrder(runtime, scope('SOR'), 1)) as any;
    await editSalesOrder(
      runtime,
      {
        ...doc,
        scope: scope('SOR'),
        expectedVersion: doc.version,
        mainUser: 'clerk',
        advanceAmount: 1500,
        vchDesc: 'Edited',
        dirtyFields: ['advanceAmount', 'vchDesc'],
      } as any,
      1,
    );
    const desktop = await expectDesktop();
    expect(desktop.ledger[0].CR_AMT).toBe('1500.00');
    expect(desktop.dayBook[0]).toMatchObject({ CR_AMT: '2500.00', IT_DESC: 'Edited' });
    doc = (await getSalesOrder(runtime, scope('SOR'), 1)) as any;
    await cancelSalesOrder(runtime, {
      scope: scope('SOR'),
      vchNo: 1,
      deleteUser: 'clerk',
      expectedVersion: doc.version,
    });
    expect(await snapshot()).toEqual({ ledger: [], dayBook: [] });
  });

  it("a card adjusted against commission (CARD_ADJ 'Y') posts no 05/06 and no day-book 03", async () => {
    await createSalesOrder(runtime, salesInput({ cardAdj: 'Y', upiRows: [] }) as any);
    const desktop = await expectDesktop();
    expect(legs(desktop.ledger).map((row) => row[0])).toEqual(['01', '02', '03', '04']);
    expect(legs(desktop.dayBook).map((row) => row[0])).toEqual(['01', '02']);
  });

  it('Tour Order with desktop cash, cheque and card tenders: Order_Ledr legs 01-06 and day book 01-03', async () => {
    await createTourOrder(runtime, tourInput() as any);
    // The tenders as TR_TOUR_ORD saves them (:7297-7311): ADV_AMT the total, CASH/CHQ/CARD each tender.
    await exec(
      `UPDATE "SL_ORD_DATA" SET "CASH_AMT"=1000,"CHQ_AMT"=500,"BANK_AC"='BANK1',"CHQ_NO"='000777',"CARD_AMT"=300,
              "CARD_AC"='CARD1',"CARD_ADJ"='N',"ADV_AMT"=1800 WHERE tenant_id=$1`,
      tenantId,
    );
    let doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    expect([doc.advanceAmount, doc.cashAc]).toEqual([1800, 'CASH']);
    await editTourOrder(
      runtime,
      { ...doc, scope: scope('510'), expectedVersion: doc.version } as any,
      '00001',
    );
    const desktop = await expectDesktop();
    expect(legs(desktop.ledger)).toEqual([
      ['01', 'PARTY', '0.00', '1000.00'],
      ['02', 'CASH', '1000.00', '0.00'],
      ['03', 'PARTY', '0.00', '500.00'],
      ['04', 'BANK1', '500.00', '0.00'],
      ['05', 'PARTY', '0.00', '300.00'],
      ['06', 'CARD1', '300.00', '0.00'],
    ]);
    expect(legs(desktop.dayBook)).toEqual([
      ['01', 'PARTY', '0.00', '1800.00'],
      ['02', 'BANK1', '500.00', '0.00'],
      ['03', 'CARD1', '300.00', '0.00'],
    ]);
    // An unchanged re-save keeps them; delete removes them.
    const before = await snapshot();
    doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    expect([doc.advanceAmount, doc.cashAc]).toEqual([1800, 'CASH']);
    await editTourOrder(
      runtime,
      { ...doc, scope: scope('510'), expectedVersion: doc.version } as any,
      '00001',
    );
    expect(await snapshot()).toEqual(before);
    doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    await cancelTourOrder(runtime, {
      scope: scope('510'),
      vchNo: '00001',
      deleteUser: 'clerk',
      expectedVersion: doc.version,
    });
    expect(await snapshot()).toEqual({ ledger: [], dayBook: [] });
  });

  it('a Tour Order posted by the earlier web writer (cash pair 51/52) reopens and re-saves to legs 01/02', async () => {
    await createTourOrder(runtime, tourInput({ advanceAmount: 25 }) as any);
    // The earlier writer's rows: Dr the cash account (51), Cr the party (52); CASH_AMT not written.
    await exec(`DELETE FROM "AC_DATA" WHERE tenant_id=$1`, tenantId);
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","LEDR_KEY","AC_CODE","DR_AMT","CR_AMT")
       VALUES($1,'01','01',$2,'510','00001','TUROD','2024-07-10','01012024-20255100000151','CASH',25,0),
             ($1,'01','01',$2,'510','00001','TUROD','2024-07-10','01012024-20255100000152','PARTY',0,25)`,
      tenantId,
      YEAR,
    );
    await exec(`UPDATE "SL_ORD_DATA" SET "CASH_AMT"=0 WHERE tenant_id=$1`, tenantId);
    const doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    expect([doc.advanceAmount, doc.cashAc]).toEqual([25, 'CASH']);
    await editTourOrder(
      runtime,
      { ...doc, scope: scope('510'), expectedVersion: doc.version } as any,
      '00001',
    );
    const [header] = await query(
      `SELECT "CASH_AMT"::float cash,"ADV_AMT"::float adv FROM "SL_ORD_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(header).toEqual({ cash: 25, adv: 25 });
    const desktop = await expectDesktop();
    expect(legs(desktop.ledger)).toEqual([
      ['01', 'PARTY', '0.00', '25.00'],
      ['02', 'CASH', '25.00', '0.00'],
    ]);
  });

  it('a desktop cheque-only Tour Order reopens without a cash account and keeps the book slot 1 on save', async () => {
    await createTourOrder(runtime, tourInput({ advanceAmount: 0 }) as any);
    // The imported order (TR_TOUR_ORD.cs:7309-7312): no cash tender, a 100 cheque to BANK1, advance 100;
    // the desktop's ledger holds only the cheque pair 03/04 (Ac_Ledr.cs:34-36), never a leg 02.
    await exec(`DELETE FROM "AC_DATA" WHERE tenant_id=$1`, tenantId);
    await exec(`DELETE FROM "ROJ_MEL_DATA" WHERE tenant_id=$1`, tenantId);
    await exec(
      `UPDATE "SL_ORD_DATA" SET "CASH_AMT"=0,"CHQ_AMT"=100,"BANK_AC"='BANK1',"CHQ_NO"='000777',"ADV_AMT"=100 WHERE tenant_id=$1`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","LEDR_KEY","AC_CODE","LD_CODE","CR_AMT","DR_AMT")
       VALUES($1,'01','01',$2,'510','00001','TUROD','2024-07-10','01012024-20255100000103','PARTY','CASH',100,0),
             ($1,'01','01',$2,'510','00001','TUROD','2024-07-10','01012024-20255100000104','BANK1','PARTY',0,100)`,
      tenantId,
      YEAR,
    );
    const doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    // Reopen must not take the bank's debit leg as the cash account: only legs 01/02 name it
    // (Ac_Ledr.cs:30-36), and day-book 01 always takes the slot-1 account (Ac_Rojmel.cs:11).
    expect(doc.cashAc).toBeUndefined();
    // An unchanged re-save keeps the cheque pair and credits the advance to the book's slot-1 account.
    await editTourOrder(
      runtime,
      { ...doc, scope: scope('510'), expectedVersion: doc.version } as any,
      '00001',
    );
    let desktop = await expectDesktop();
    expect(legs(desktop.ledger)).toEqual([
      ['03', 'PARTY', '0.00', '100.00'],
      ['04', 'BANK1', '100.00', '0.00'],
    ]);
    expect(legs(desktop.dayBook)).toEqual([
      ['01', 'PARTY', '0.00', '100.00'],
      ['02', 'BANK1', '100.00', '0.00'],
    ]);
    // Raising the advance to 150 moves only the cash difference (tourCashColumn), and the new cash
    // leg 02 debits the book's slot-1 account, not the bank (Ac_Ledr.cs:32).
    const raised = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    await editTourOrder(
      runtime,
      {
        ...raised,
        scope: scope('510'),
        expectedVersion: raised.version,
        advanceAmount: 150,
      } as any,
      '00001',
    );
    desktop = await expectDesktop();
    expect(legs(desktop.ledger)).toEqual([
      ['01', 'PARTY', '0.00', '50.00'],
      ['02', 'CASH', '50.00', '0.00'],
      ['03', 'PARTY', '0.00', '100.00'],
      ['04', 'BANK1', '100.00', '0.00'],
    ]);
    expect(legs(desktop.dayBook)).toEqual([
      ['01', 'PARTY', '0.00', '150.00'],
      ['02', 'BANK1', '100.00', '0.00'],
    ]);
  });

  it('a Tour Order with a saved scheme keeps day-book row 05 through an unchanged re-save (Ac_Rojmel.cs:19)', async () => {
    // The scheme account is the MEMB ADJUST book's slot 1, the desktop's 00079 (MS_UPDATE.cs:27378).
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","DATA_TYPE")
       VALUES($1,'01','01','076','Member Adjust','MADJ','MEMB ADJUST','O','Y','AD_ADJ','A')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE")
       VALUES($1,'01','01','076',1,'00079','MADJ','MEMB ADJUST','O','A')`,
      tenantId,
    );
    await createTourOrder(runtime, tourInput({ advanceAmount: 150 }) as any);
    // The desktop's tenders (TR_TOUR_ORD.cs:7309-7312): cash 100, scheme 50, advance 150.
    await exec(
      `UPDATE "SL_ORD_DATA" SET "CASH_AMT"=100,"SCHM_AMT"=50 WHERE tenant_id=$1`,
      tenantId,
    );
    const doc = (await getTourOrder(runtime, scope('510'), '00001')) as any;
    expect([doc.advanceAmount, doc.schemeAmount]).toEqual([150, 50]);
    await editTourOrder(
      runtime,
      { ...doc, scope: scope('510'), expectedVersion: doc.version } as any,
      '00001',
    );
    // Order_Ledr has no scheme leg (Ac_Ledr.cs:28-61); the day book rebuilds rows 01 and 05, exactly
    // as the desktop's own statement over the saved header (SCHM_AMT <> 0 for both forms, :19).
    const desktop = await expectDesktop();
    expect(legs(desktop.ledger)).toEqual([
      ['01', 'PARTY', '0.00', '100.00'],
      ['02', 'CASH', '100.00', '0.00'],
    ]);
    expect(legs(desktop.dayBook)).toEqual([
      ['01', 'PARTY', '0.00', '150.00'],
      ['05', '00079', '50.00', '0.00'],
    ]);
    expect(desktop.dayBook[1]).toMatchObject({
      AC_NAME: 'MADJ - Mixed customer',
      LD_CODE: 'PARTY',
      VCH_TYPE: 'TUROD',
      BOOK_NAME: 'TOUR ORDER',
    });
  });
});
