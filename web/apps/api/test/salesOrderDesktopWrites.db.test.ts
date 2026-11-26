import { PrismaClient } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { createSalesOrder } from '../src/modules/sales/salesOrder.js';

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

  it('saves a new line picked from a tag, with the tag on its components, and refuses an unknown tag', async () => {
    await sql(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","TAG_NO","VCH_SRNO","IT_CODE")
       VALUES($1,'01','01',$2,'TGO','00001','T-SYN1',7001,'GL')`,
      tenantId,
      YEAR,
    );
    await createSalesOrder(
      runtime,
      input({
        lines: [
          line({
            tagNo: 'T-SYN1',
            vchSrno: 7001,
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
      `SELECT "SR_NO"::int sr,"TAG_NO" tag,"VCH_SRNO"::float srno,"TAG_STK_LESS" stk FROM "SL_ORD_DETL"
        WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      tenantId,
    );
    expect(d).toEqual([
      { sr: 1, tag: 'T-SYN1', srno: 7001, stk: 'N' },
      { sr: 2, tag: 'N', srno: 0, stk: 'N' },
    ]);
    const i = await query(
      `SELECT "SR_NO"::int sr,"TAG_NO" tag,"VCH_SRNO"::float srno FROM "SL_ORD_IDTL" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      tenantId,
    );
    expect(i).toEqual([
      { sr: 1, tag: 'T-SYN1', srno: 7001 },
      { sr: 2, tag: '', srno: 0 },
    ]);
    await expect(
      createSalesOrder(runtime, input({ lines: [line({ tagNo: 'T-NONE' })] }) as any),
    ).rejects.toThrow(/T-NONE was not found/);
  });
});
