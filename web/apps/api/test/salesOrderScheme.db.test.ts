import { PrismaClient } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  cancelSalesOrder,
  createSalesOrder,
  editSalesOrder,
  getSalesOrder,
} from '../src/modules/sales/salesOrder.js';

/**
 * G206 (scheme tender), owner decision: follow the desktop source on the Lite edition.
 *
 * - TR_SALE_ORD.cs:11264-11290: on the Lite and Silver editions the operator types the Scheme Amt cell
 *   (MSG2_TOTAL[8,3]); it is stored as SCHM_AMT (:9142) and joins the advance MSG2_TOTAL[9,3] (:11368).
 * - Order_Rojmel type 05 (Ac_Rojmel.cs:19): `AC_CODE '00079', LD_CODE party, CR 0, DR SCHM_AMT,
 *   AC_NAME 'MADJ - ' + party name`, guarded by `SCHM_AMT <> 0`, keyed head + '05' (23 characters). 00079 is the
 *   desktop's SCHEME BONUS A/C, slot 1 of its member-adjust books (MS_UPDATE.cs:27378; Live24 book 076 MEMB ADJUST
 *   names it on every bonus row, Ac_Rojmel.cs:462). The web resolves the MEMB ADJUST book's BOOK_DETL slot 1, so
 *   the fixture uses a non-00079 account to prove no literal is used.
 * - Order_Ledr (Ac_Ledr.cs:28-61) has no scheme leg: the ledger carries the cash tender only.
 */
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Sales Order scheme tender', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const tenantId = 'sales-order-scheme';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'S96' };
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
  const membAdjustBook = (book = 'M76', slotAc: string | null = 'SCHBONUS') =>
    sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","BOOK_NAME","CUR_USE","BOOK_TBL_NAME")
       VALUES($1,'01','01',$2,'MEMB ADJUST','O','MBADJ','Member Adjust','Y','AD_ADJ')`,
      tenantId,
      book,
    ).then(() =>
      slotAc === null
        ? 0
        : sql(
            `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
             VALUES($1,'01','01',$2,1,$3,'MEMB ADJUST','O')`,
            tenantId,
            book,
            slotAc,
          ),
    );
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
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","BOOK_NAME","CUR_USE","BOOK_TBL_NAME") VALUES($1,'01','01','S96','SALES ORDER','O','SORD','Sales Order','Y','SL_ORD_DATA')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT") VALUES($1,'01','01','S96',1,'CASH','SALES ORDER','O')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PARTY','Saved customer'),($1,'01','01','CASH','Cash'),($1,'01','01','SCHBONUS','Scheme bonus')`,
      tenantId,
    );
  });
  afterAll(async () => {
    await clean();
    await runtime.$disconnect();
    await owner.$disconnect();
  });
  const input = (extra: Record<string, unknown> = {}) => ({
    scope,
    vchDate: '2024-07-10',
    mainUser: 'clerk',
    acCode: 'PARTY',
    acName: 'Saved customer',
    vchDesc: 'Ring order',
    taxRatePct: 0,
    advanceAmount: 3000,
    schemeAmount: 1000,
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
        `SELECT "CASH_AMT"::float cash,"SCHM_AMT"::float schm,"ADV_AMT"::float adv
           FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001'`,
        tenantId,
      )
    )[0];
  const keyed = (table: 'AC_DATA' | 'ROJ_MEL_DATA') =>
    query(
      `SELECT substr("LEDR_KEY",22,2) leg,length("LEDR_KEY")::int len,btrim("AC_CODE") ac,btrim("LD_CODE") ld,
              "DR_AMT"::float dr,"CR_AMT"::float cr
              ${table === 'ROJ_MEL_DATA' ? `,btrim("AC_NAME") name,btrim("IT_TYPE") typ,btrim(coalesce("SIGN",'')) sign,btrim("IT_DESC") descr,btrim("VCH_TYPE") vtype,btrim("BOOK_NAME") book` : ''}
         FROM "${table}" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      tenantId,
    );
  const counts = async () =>
    (
      await query(
        `SELECT (SELECT count(*) FROM "SL_ORD_DATA" WHERE tenant_id=$1)::int ord,
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

  it('adds the scheme to the advance and writes day-book type 05 to the MEMB ADJUST slot-1 account', async () => {
    await membAdjustBook();
    await createSalesOrder(runtime, input() as any);

    expect(await header()).toEqual({ cash: 3000, schm: 1000, adv: 4000 });
    // Order_Ledr has no scheme leg: the ledger is the cash tender alone.
    expect((await keyed('AC_DATA')).map((r) => [r.leg, r.ac, r.ld, r.dr, r.cr])).toEqual([
      ['01', 'PARTY', 'CASH', 0, 3000],
      ['02', 'CASH', 'PARTY', 3000, 0],
    ]);
    // Type 05 copies the advance row's columns. Neither carries VCH_DESC yet: the shared builder leaves IT_DESC blank
    // where the desktop selects A.VCH_DESC (Ac_Rojmel.cs:11, :19), an open item outside this slice.
    expect(await keyed('ROJ_MEL_DATA')).toEqual([
      {
        leg: '01',
        len: 23,
        ac: 'PARTY',
        ld: 'CASH',
        dr: 0,
        cr: 4000,
        name: 'Saved customer',
        typ: 'A',
        sign: '',
        descr: '',
        vtype: 'SORD',
        book: 'SALES ORDER',
      },
      {
        leg: '05',
        len: 23,
        ac: 'SCHBONUS',
        ld: 'PARTY',
        dr: 1000,
        cr: 0,
        name: 'MADJ - Saved customer',
        typ: 'A',
        sign: '',
        descr: '',
        vtype: 'SORD',
        book: 'SALES ORDER',
      },
    ]);

    // Reopen: the scheme comes back on its own and the cash advance is CASH_AMT, not ADV_AMT.
    const doc = await loaded();
    expect([doc.advanceAmount, doc.schemeAmount]).toEqual([3000, 1000]);

    // Edit the scheme 1,000 -> 1,500: the advance and the type-05 row follow.
    await editSalesOrder(runtime, replacement(doc, { schemeAmount: 1500 }) as any, 1);
    expect(await header()).toEqual({ cash: 3000, schm: 1500, adv: 4500 });
    expect((await keyed('ROJ_MEL_DATA')).map((r) => [r.leg, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'PARTY', 0, 4500],
      ['05', 'SCHBONUS', 1500, 0],
    ]);

    // Clearing the scheme removes the row (guard SCHM_AMT <> 0).
    await editSalesOrder(runtime, replacement(await loaded(), { schemeAmount: 0 }) as any, 1);
    expect(await header()).toEqual({ cash: 3000, schm: 0, adv: 3000 });
    expect((await keyed('ROJ_MEL_DATA')).map((r) => r.leg)).toEqual(['01']);

    // Back to a scheme, then delete: nothing of the order remains.
    await editSalesOrder(runtime, replacement(await loaded(), { schemeAmount: 700 }) as any, 1);
    expect((await keyed('ROJ_MEL_DATA')).map((r) => [r.leg, r.dr, r.cr])).toEqual([
      ['01', 0, 3700],
      ['05', 700, 0],
    ]);
    await cancelSalesOrder(runtime, { scope, vchNo: 1, expectedVersion: (await loaded()).version });
    expect(await counts()).toEqual({ ord: 0, ac: 0, roj: 0 });
  });

  it('takes the scheme as the only tender: the advance contra is still the order book slot 1', async () => {
    await membAdjustBook();
    await createSalesOrder(runtime, input({ advanceAmount: 0 }) as any);
    expect(await header()).toEqual({ cash: 0, schm: 1000, adv: 1000 });
    expect((await keyed('AC_DATA')).length).toBe(0);
    expect((await keyed('ROJ_MEL_DATA')).map((r) => [r.leg, r.ac, r.ld, r.dr, r.cr])).toEqual([
      ['01', 'PARTY', 'CASH', 0, 1000],
      ['05', 'SCHBONUS', 'PARTY', 1000, 0],
    ]);
    const doc = await loaded();
    expect([doc.advanceAmount, doc.schemeAmount]).toEqual([0, 1000]);
  });

  it('needs no MEMB ADJUST book when there is no scheme', async () => {
    await createSalesOrder(runtime, input({ schemeAmount: 0 }) as any);
    expect(await header()).toEqual({ cash: 3000, schm: 0, adv: 3000 });
    expect((await keyed('ROJ_MEL_DATA')).map((r) => r.leg)).toEqual(['01']);
  });

  it('refuses a scheme it cannot post and leaves nothing behind', async () => {
    const empty = { ord: 0, ac: 0, roj: 0 };
    // No MEMB ADJUST book: the desktop's own text when CurBookHelp finds none (DC_Main.cs:1508).
    await expect(createSalesOrder(runtime, input() as any)).rejects.toThrow(
      'Please Creat Book From MEMB ADJUST....',
    );
    expect(await counts()).toEqual(empty);
    await expect(createSalesOrder(runtime, input({ schemeAmount: -5 }) as any)).rejects.toThrow(
      'schemeAmount must be a non-negative number',
    );
    expect(await counts()).toEqual(empty);
    // A MEMB ADJUST book with no slot-1 account fails closed rather than posting to a blank account.
    await membAdjustBook('M76', null);
    await expect(createSalesOrder(runtime, input() as any)).rejects.toThrow(
      'advance-settlement account is not configured: book M76 slot 1 is missing',
    );
    expect(await counts()).toEqual(empty);
    // Two MEMB ADJUST books: the account is ambiguous, so the order is refused.
    await membAdjustBook('M77');
    await expect(createSalesOrder(runtime, input() as any)).rejects.toThrow(
      'MEMB ADJUST book configuration is ambiguous: M76, M77',
    );
    expect(await counts()).toEqual(empty);
  });

  it('keeps the scheme out of another tenant: a MEMB ADJUST book elsewhere does not count', async () => {
    const other = 'sales-order-scheme-other';
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","BOOK_NAME","CUR_USE")
       VALUES($1,'01','01','M76','MEMB ADJUST','O','MBADJ','Member Adjust','Y')`,
      other,
    );
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES($1,'01','01','M76',1,'SCHBONUS','MEMB ADJUST','O')`,
      other,
    );
    try {
      await expect(createSalesOrder(runtime, input() as any)).rejects.toThrow(
        'Please Creat Book From MEMB ADJUST....',
      );
    } finally {
      await sql(`DELETE FROM "BOOK_DETL" WHERE tenant_id=$1`, other);
      await sql(`DELETE FROM "BOOK_DATA" WHERE tenant_id=$1`, other);
    }
  });
});
