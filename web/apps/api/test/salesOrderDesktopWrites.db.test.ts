import { PrismaClient } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createSalesOrder,
  editSalesOrder,
  getSalesOrder,
} from '../src/modules/sales/salesOrder.js';

/**
 * What a Sales Order save writes, found by the desktop replay oracle (integration/replay-desktop.mjs) and pinned here
 * on SYNTHETIC rows:
 *  - the save does not refuse an order without an amount (TR_SALE_ORD.cs:8925-9047 checks no amount);
 *  - BILL_NO is the typed box, blank by default (:9115);
 *  - SL_ORD_DATA DATA_TRFR, USER_UPDATE, USER_DELETE 'N' (:9163-9174); the SL_ORD_ADJ row's USER_UPDATE and
 *    USER_DELETE take their NOT NULL DEFAULT 'N' (MS_UPDATE.cs:26133);
 *  - SL_ORD_DETL TAG_STK_LESS 'N' unless 'Y' (:9268-9286) and DATA_TRFR left NULL (not set at :9193-9309);
 *  - a new line's Tag cell is saved as TAG_NO (:9208-9215) and repeated on its SL_ORD_IDTL rows (:9393), blank there
 *    for an untagged line; an unknown tag is refused.
 */
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Sales Order desktop writes', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const tenantId = 'so-desktop-writes';
  const YEAR = '2024-2025';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: YEAR, coBook: 'S95' };
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

  const line = (extra: Record<string, unknown> = {}) => ({
    itCode: 'GL',
    designImageId: 'N',
    pcs: 1,
    grossWt: 2,
    netWt: 2,
    touch: 100,
    rate: 0,
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
    acName: 'Saved customer',
    taxRatePct: 0,
    advanceAmount: 500,
    lines: [line()],
    ...extra,
  });

  it('saves an order taken by weight with only its advance, flags and bill number as the desktop writes them', async () => {
    const r = await createSalesOrder(runtime, input() as any);
    expect(r.vchNo).toBe(1);
    const [h] = await query(
      `SELECT "BILL_NO" bill,"NET_AMT"::float net,"ADV_AMT"::float adv,"DATA_TRFR" trfr,"USER_UPDATE" uu,
              "USER_DELETE" ud FROM "SL_ORD_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(h).toEqual({ bill: '', net: 0, adv: 500, trfr: 'N', uu: 'N', ud: 'N' });
    const [adj] = await query(
      `SELECT "USER_UPDATE" uu,"USER_DELETE" ud FROM "SL_ORD_ADJ" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(adj).toEqual({ uu: 'N', ud: 'N' });
    const [d] = await query(
      `SELECT "TAG_NO" tag,"TAG_STK_LESS" stk,"DATA_TRFR" trfr FROM "SL_ORD_DETL" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(d).toEqual({ tag: 'N', stk: 'N', trfr: null });
    const ac = await query(
      `SELECT DISTINCT "BILL_NO" bill FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='S95'`,
      tenantId,
    );
    expect(ac.map((x) => x.bill ?? '')).toEqual(['']);
  });

  it('saves a typed bill number', async () => {
    await createSalesOrder(runtime, input({ billNo: 'B-7' }) as any);
    const [h] = await query(
      `SELECT "BILL_NO" bill FROM "SL_ORD_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(h.bill).toBe('B-7');
  });

  /** A tag at the order's location: BAR_DETL plus its '+' stock row, and optionally its sale ('-'). */
  const seedTag = async (
    tagNo: string,
    srno: number,
    opts: { tbl?: string; empIsu?: string; sold?: boolean } = {},
  ) => {
    await sql(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","TAG_NO","VCH_SRNO","IT_CODE",
         "TBL_CODE","EMP_ISU","VCH_DATE") VALUES($1,'01','01',$2,'TGO','00001',$3,$4,'GL',$5,$6,'2024-04-02')`,
      tenantId,
      YEAR,
      tagNo,
      srno,
      opts.tbl ?? 'C01',
      opts.empIsu ?? 'N',
    );
    for (const sign of opts.sold ? ['+', '-'] : ['+'])
      await sql(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
           "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","TBL_CODE")
         VALUES($1,'01','01',$2,$3,'00001',1,1,'2024-04-02','GL',$4,$5,'P',$6,1,1,2,2,$7)`,
        tenantId,
        YEAR,
        sign === '+' ? 'TGO' : 'SLX',
        tagNo,
        srno,
        sign,
        opts.tbl ?? 'C01',
      );
  };

  it('takes a tag in stock from BAR_DETL, not from the request, with its components; refuses one out of stock', async () => {
    await seedTag('T-SYN1', 7001);
    await createSalesOrder(
      runtime,
      input({
        lines: [
          line({
            tagNo: 'T-SYN1',
            // A request's instance and counters are not trusted: the stock row's are saved.
            oldTblCode: 'ZZZ',
            tagStockLess: 'Y',
            components: [
              {
                isrNo: 1,
                itCode: 'GL',
                itType: 'O',
                pcs: 1,
                rate: 100,
                amount: 100,
                netAmount: 100,
              },
            ],
          }),
          line({ components: [{ isrNo: 1, itCode: 'GL', pcs: 1 }] }),
        ],
      }) as any,
    );
    const d = await query(
      `SELECT "SR_NO"::int sr,"TAG_NO" tag,"VCH_SRNO"::float srno,"TBL_CODE" tbl,"OLD_TBL_CODE" old,
              "TAG_STK_LESS" stk FROM "SL_ORD_DETL" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      tenantId,
    );
    // ORD_TAG_STK_LESS is not 'Y' for this company, so the line does not hold the tag (:5557, :9268-9286).
    expect(d).toEqual([
      { sr: 1, tag: 'T-SYN1', srno: 7001, tbl: 'C01', old: 'C01', stk: 'N' },
      { sr: 2, tag: 'N', srno: 0, tbl: '', old: '', stk: 'N' },
    ]);
    const i = await query(
      `SELECT "SR_NO"::int sr,"TAG_NO" tag,"VCH_SRNO"::float srno FROM "SL_ORD_IDTL" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      tenantId,
    );
    expect(i).toEqual([
      { sr: 1, tag: 'T-SYN1', srno: 7001 },
      { sr: 2, tag: '', srno: 0 },
    ]);
    await seedTag('T-SOLD', 7002, { sold: true });
    await seedTag('T-EMP', 7003, { empIsu: 'Y' });
    for (const tagNo of ['T-NONE', 'T-SOLD', 'T-EMP'])
      await expect(
        createSalesOrder(runtime, input({ lines: [line({ tagNo })] }) as any),
      ).rejects.toThrow(new RegExp(`${tagNo} is not in stock`));
    await seedTag('T-TWO', 7004);
    await expect(
      createSalesOrder(
        runtime,
        input({ lines: [line({ tagNo: 'T-TWO' }), line({ tagNo: 'T-TWO' })] }) as any,
      ),
    ).rejects.toThrow('Duplicate Tag No');
  });

  it("holds the tag when the company's ORD_TAG_STK_LESS is 'Y', and keeps the tag's counter when the line has none", async () => {
    await sql(`UPDATE "CO_SET_NEW" SET "ORD_TAG_STK_LESS"='Y' WHERE tenant_id=$1`, tenantId);
    await seedTag('T-HOLD', 7010, { tbl: '' });
    await seedTag('T-HOLD2', 7011, { tbl: 'C02' });
    await createSalesOrder(
      runtime,
      input({
        lines: [line({ tagNo: 'T-HOLD' }), line({ tagNo: 'T-HOLD2', tblCode: 'C09' })],
      }) as any,
    );
    const d = await query(
      `SELECT "TAG_NO" tag,"TBL_CODE" tbl,"OLD_TBL_CODE" old,"TAG_STK_LESS" stk FROM "SL_ORD_DETL"
        WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      tenantId,
    );
    expect(d).toEqual([
      { tag: 'T-HOLD', tbl: '', old: '', stk: 'Y' },
      { tag: 'T-HOLD2', tbl: 'C09', old: 'C02', stk: 'Y' },
    ]);
    const bar = await query(
      `SELECT btrim("TAG_NO") tag,btrim("ORD_NO") ord,"TBL_CODE" tbl FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
      tenantId,
    );
    // The typed counter moves the tag there (:9554); a line without one leaves the tag's counter alone.
    expect(bar).toEqual([
      { tag: 'T-HOLD', ord: '00001', tbl: '' },
      { tag: 'T-HOLD2', ord: '00001', tbl: 'C09' },
    ]);
  });

  it('keeps a saved bill number when an edit does not send the box, clears it when sent blank', async () => {
    await createSalesOrder(runtime, input({ billNo: 'B-9' }) as any);
    const bill = async () =>
      (await query(`SELECT "BILL_NO" bill FROM "SL_ORD_DATA" WHERE tenant_id=$1`, tenantId))[0]
        .bill;
    const edit = async (extra: Record<string, unknown>) => {
      const doc: any = await getSalesOrder(runtime, scope as any, 1);
      const { billNo: _omit, ...rest } = doc;
      await editSalesOrder(
        runtime,
        { ...rest, ...extra, scope, expectedVersion: doc.version, mainUser: 'clerk' } as any,
        1,
      );
    };
    await edit({ vchDesc: 'changed' });
    expect(await bill()).toBe('B-9');
    await edit({ billNo: '' });
    expect(await bill()).toBe('');
  });

  it('refuses a negative order amount and saves a zero one', async () => {
    await expect(
      createSalesOrder(runtime, input({ lines: [], netAmount: -5 }) as any),
    ).rejects.toThrow('cannot be negative');
    await expect(
      createSalesOrder(runtime, input({ lines: [line({ rate: -10 })] }) as any),
    ).rejects.toThrow('cannot be negative');
    const r = await createSalesOrder(runtime, input({ lines: [], netAmount: 0 }) as any);
    expect(r.total).toBe(0);
  });
});
