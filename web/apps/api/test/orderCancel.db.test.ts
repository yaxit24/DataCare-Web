/**
 * Order Cancel is the desktop multi-order adjustment voucher (TR_SL_ORD_ADJ).
 *
 * The expected rows are derived from the desktop source, not from the web writer:
 *   - TR_SL_ORD_ADJ.cs:3510-3585  one SL_ORD_ADJ row per grid row (ENTRY_TYPE 'C', ORD_SIGN '-', ORD_AMT = AdjAmt,
 *     ORD_BAL_AMT = OrdAmt, PAID_AMT, PAID_AC, KASAR_AMT, the order's own key in ORD_NO/ORD_LC/ORD_YRCD/ORD_DBCD/
 *     ORD_HD_VCH_NO), then Order_Adj_Ledr, Order_Adj_Rojmel;
 *   - Ac_Ledr.cs:928  per row: Dr customer / Cr paid account for PAID_AMT (keys +'01', +'02'), and when KASAR_AMT is
 *     not zero Dr customer / Cr kasar account (keys +'03', +'04');
 *   - Ac_Rojmel.cs:392  the same legs in the day book; the cash account's own row (+'02') is left out;
 *   - TR_SL_ORD_ADJ.cs:2447  PaidAmt = AdjAmt - KasarAmt;  :2523  an order is pending while its advance is not used up.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteOrderCancel,
  editOrderCancel,
  getOrderCancel,
  listPendingOrders,
  postOrderCancel,
} from '../src/modules/sales/orderCancel.js';
import { adjustOrderIntoSaleTx, orderAdvanceAvailableTx } from '../src/modules/sales/salesOrder.js';
import { orderCancelTagSrNo } from '../src/modules/sales/orderCancelTags.js';
import { diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'order-cancel-voucher';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const CUST_A = '000500';
const CUST_B = '000600';
const CASH = '00001';
const BANK = '00002';
const KASAR = '00057';
const OUT_OF_YEAR =
  'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'ORC' };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
const query = <T = Record<string, unknown>>(sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$queryRawUnsafe(sql, ...p)) as Promise<T[]>;

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const r of rows) {
    await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seed() {
  await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name] of [
    [CUST_A, 'ORDER CUSTOMER A'],
    [CUST_B, 'ORDER CUSTOMER B'],
    [CASH, 'CASH ON HAND'],
    [BANK, 'HDFC BANK'],
    [KASAR, 'KASAR JAVK A/C'],
  ]) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES ($1,$2,$3,$4,$5,'L')`,
      TENANT,
      CO,
      LC,
      code,
      name,
    );
  }
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,'SOR','Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA'),
            ($1,$2,$3,'ORC','Order Cancel','SADJ','ORDER CANCEL','O','Y','SL_ORD_ADJ'),
            ($1,$2,$3,'ORA','Order Adjust','OADJ','ORDER ADJUST','O','Y','SL_ORD_ADJ')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,'ORC',1,$4,'ORDER CANCEL','O'), ($1,$2,$3,'ORC',2,$5,'ORDER CANCEL','O')`,
    TENANT,
    CO,
    LC,
    CASH,
    KASAR,
  );
  // 00007: customer A, advance 1000.  00008: customer B, advance 2000 of which 500 went into a sale on the web
  // (ORD_SIGN 'C', PAID_AMT).  00009: customer A, advance 800 as the desktop stores it ('+' row for the advance and a
  // '-' row for 300 used by a sale), so 500 is open.
  for (const [no, ac, name, adv, hd] of [
    ['00007', CUST_A, 'ORDER CUSTOMER A', 1000, '00031'],
    ['00008', CUST_B, 'ORDER CUSTOMER B', 2000, '00032'],
    ['00009', CUST_A, 'ORDER CUSTOMER A', 800, '00033'],
  ] as const) {
    await exec(
      `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","HD_VCH_NO","AC_CODE","AC_NAME","ADV_AMT","TOT_AMT")
       VALUES ($1,$2,$3,$4,'SOR',$5,'2024-04-10',$6,$7,$8,$9,5000)`,
      TENANT,
      CO,
      LC,
      YEAR,
      no,
      hd,
      ac,
      name,
      adv,
    );
  }
  await exec(
    `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","ENTRY_TYPE","AC_CODE","ORD_NO","ORD_LC","ORD_YRCD","ORD_DBCD","ORD_SIGN","ORD_AMT","PAID_AMT")
     VALUES ($1,$2,$3,$4,'ORA','00001',1,'2024-04-12','OADJ','A',$5,'00008',$3,$4,'SOR','C',0,500),
            ($1,$2,$3,$4,'SOR','00009',1,'2024-04-10','SORD','O',$6,'00009',$3,$4,'SOR','+',800,0),
            ($1,$2,$3,$4,'SAL','00004',1,'2024-04-15','SALE','S',$6,'00009',$3,$4,'SOR','-',300,0)`,
    TENANT,
    CO,
    LC,
    YEAR,
    CUST_B,
    CUST_A,
  );
}

const rowA = {
  ordNo: '00007',
  ordYear: YEAR,
  ordBook: 'SOR',
  adjAmt: 1000,
  kasarAmt: 100,
  paidAmt: 900,
  paidAc: CASH,
  itDesc: 'ring order dropped',
};
const rowB = {
  ordNo: '00008',
  ordYear: YEAR,
  ordBook: 'SOR',
  adjAmt: 1500,
  kasarAmt: 0,
  paidAmt: 1500,
  paidAc: BANK,
};
const create = (rows: unknown[], vchDate = '2024-05-01') =>
  postOrderCancel(runtime, { scope, rows: rows as never, vchDate, mainUser: 'clerk', empCode: '' });
const versionOf = async (vchNo: number) => (await getOrderCancel(runtime, scope, vchNo)).version;
const edit = async (
  rows: unknown[],
  vchNo: number,
  vchDate = '2024-05-02',
  extra: Record<string, unknown> = {},
) =>
  editOrderCancel(
    runtime,
    { scope, rows: rows as never, vchDate, expectedVersion: await versionOf(vchNo), ...extra },
    vchNo,
  );
const remove = async (vchNo: number) =>
  deleteOrderCancel(runtime, { scope, vchNo, expectedVersion: await versionOf(vchNo) });
const STALE = '0'.repeat(64);

/** Every table an Order Cancel writes, as comparable plain rows. */
async function writeSet() {
  const q = (table: string, cols: string, extra = '') =>
    query(
      `SELECT ${cols} FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ${extra} ORDER BY 1,2,3,4`,
      TENANT,
    );
  return {
    adj: await q(
      'SL_ORD_ADJ',
      `"VCH_NO","SR_NO","ORD_NO","ORD_AMT"::float,"PAID_AMT"::float,"KASAR_AMT"::float,"PAID_AC"`,
    ),
    ledger: await q('AC_DATA', `"VCH_NO","LEDR_KEY","AC_CODE","DR_AMT"::float,"CR_AMT"::float`),
    rojmel: await q(
      'ROJ_MEL_DATA',
      `"VCH_NO","LEDR_KEY","AC_CODE","DR_AMT"::float,"CR_AMT"::float`,
    ),
    hidden: await q('TEMP_BOOK_DATA', `"VCH_NO","BOOK_NAME","CO_BOOK","LC_CODE"`),
  };
}

describe.runIf(RUN)('Order Cancel voucher (TR_SL_ORD_ADJ)', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('lists the orders whose advance is not used up, with what is open on each', async () => {
    const pending = await listPendingOrders(runtime, scope);
    expect(
      pending.map((o) => [
        o.ordNo,
        o.acCode,
        o.advAmt,
        o.adjAmt,
        o.openAmt,
        o.ordBook,
        o.ordYear,
        o.hdVchNo,
      ]),
    ).toEqual([
      ['00007', CUST_A, 1000, 0, 1000, 'SOR', YEAR, '00031'],
      ['00008', CUST_B, 2000, 500, 1500, 'SOR', YEAR, '00032'],
      ['00009', CUST_A, 800, 300, 500, 'SOR', YEAR, '00033'],
    ]);
    expect(pending[0]!.acName).toBe('ORDER CUSTOMER A');
  });

  it('saves one SL_ORD_ADJ row per order with the desktop columns, and the cash account and the bank each get their legs', async () => {
    const { vchNo } = await create([rowA, rowB]);
    expect(vchNo).toBe(1);
    const rows = await query<Record<string, any>>(
      `SELECT "SR_NO","VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","AC_CODE","AC_NAME","ORD_NO","ORD_LC","ORD_YRCD","ORD_DBCD",
              "ORD_HD_VCH_NO","ORD_AC_CODE","ORD_SIGN","ORD_AMT"::float,"ORD_BAL_AMT"::float,"PAID_AC","PAID_AMT"::float,
              "KASAR_AMT"::float,"IT_DESC","HD_VCH_NO","MAIN_USER"
         FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' AND "VCH_NO"='00001' ORDER BY "SR_NO"`,
      TENANT,
    );
    expect(rows).toHaveLength(2);
    expect(rows[0]).toMatchObject({
      SR_NO: 1,
      VCH_TYPE: 'SADJ',
      ENTRY_TYPE: 'C',
      BOOK_NAME: 'ORDER CANCEL',
      AC_CODE: CUST_A,
      AC_NAME: 'ORDER CUSTOMER A',
      ORD_NO: '00007',
      ORD_LC: LC,
      ORD_YRCD: YEAR,
      ORD_DBCD: 'SOR',
      ORD_HD_VCH_NO: '00031',
      ORD_AC_CODE: CUST_A,
      ORD_SIGN: '-',
      ORD_AMT: 1000,
      ORD_BAL_AMT: 1000,
      PAID_AC: CASH,
      PAID_AMT: 900,
      KASAR_AMT: 100,
      IT_DESC: 'ring order dropped',
      MAIN_USER: 'clerk',
    });
    expect(rows[1]).toMatchObject({
      SR_NO: 2,
      AC_CODE: CUST_B,
      ORD_NO: '00008',
      ORD_HD_VCH_NO: '00032',
      ORD_AMT: 1500,
      ORD_BAL_AMT: 1500,
      PAID_AC: BANK,
      PAID_AMT: 1500,
      KASAR_AMT: 0,
    });
    expect(rows[0]!.HD_VCH_NO).toBe(rows[1]!.HD_VCH_NO);

    const ledger = await query<Record<string, any>>(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","DR_AMT"::float,"CR_AMT"::float,"VCH_TYPE","BOOK_NAME","PARTY_AC_CODE"
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ORDER BY rtrim("LEDR_KEY")`,
      TENANT,
    );
    const legs = ledger.map((l) => [
      String(l.LEDR_KEY).trimEnd().slice(-3),
      l.AC_CODE,
      l.LD_CODE,
      l.DR_AMT,
      l.CR_AMT,
    ]);
    expect(legs).toEqual([
      ['101', CUST_A, CASH, 900, 0],
      ['102', CASH, CUST_A, 0, 900],
      ['103', CUST_A, KASAR, 100, 0],
      ['104', KASAR, CUST_A, 0, 100],
      ['201', CUST_B, BANK, 1500, 0],
      ['202', BANK, CUST_B, 0, 1500],
    ]);
    expect(ledger.every((l) => l.VCH_TYPE === 'SADJ' && l.BOOK_NAME === 'ORDER CANCEL')).toBe(true);
    expect(ledger.reduce((s, l) => s + l.DR_AMT - l.CR_AMT, 0)).toBe(0);

    // Ac_Rojmel.cs:392: the cash account's own row is left out; a bank account gets one.
    const rojmel = await query<Record<string, any>>(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","DR_AMT"::float,"CR_AMT"::float,"AC_NAME","IT_TYPE"
         FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ORDER BY "LEDR_KEY"`,
      TENANT,
    );
    expect(
      rojmel.map((r) => [
        String(r.LEDR_KEY).slice(21, 23),
        r.AC_CODE,
        r.LD_CODE,
        r.DR_AMT,
        r.CR_AMT,
      ]),
    ).toEqual([
      // LEDR_KEY is the voucher key, the row type, then STR(SR_NO) (Ac_Rojmel.cs:392), so it sorts by type first.
      ['01', CUST_A, CASH, 900, 0],
      ['01', CUST_B, BANK, 1500, 0],
      ['02', BANK, CUST_B, 0, 1500],
      ['03', CUST_A, KASAR, 100, 0],
      ['04', KASAR, CUST_A, 0, 100],
    ]);
    expect(rojmel.find((r) => r.AC_CODE === CUST_A && r.DR_AMT === 100)!.AC_NAME).toBe(
      'KSR - ORDER CUSTOMER A',
    );
    expect(rojmel.every((r) => r.IT_TYPE === 'A')).toBe(true);

    const hidden = await query(
      `SELECT "VCH_NO","BOOK_NAME" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='ORC'`,
      TENANT,
    );
    expect(hidden).toEqual([{ VCH_NO: rows[0]!.HD_VCH_NO, BOOK_NAME: 'Order Cancel' }]);
  });

  it('takes the order off the pending list once its advance is used, and keeps the rest open', async () => {
    await create([{ ...rowA, adjAmt: 400, kasarAmt: 0, paidAmt: 400 }, rowB]);
    const pending = await listPendingOrders(runtime, scope);
    expect(pending.map((o) => [o.ordNo, o.openAmt])).toEqual([
      ['00007', 600],
      ['00009', 500],
    ]);
    await create([{ ...rowA, adjAmt: 600, kasarAmt: 100, paidAmt: 500 }]);
    expect((await listPendingOrders(runtime, scope)).map((o) => o.ordNo)).toEqual(['00009']);
    // The shared "open advance" helper agrees for all three storage shapes (web 'C', desktop '-', new cancel rows).
    const open = await withTenant(runtime, TENANT, async (tx) => {
      const out: number[] = [];
      for (const no of ['00007', '00008', '00009'])
        out.push(
          (await orderAdvanceAvailableTx(tx, { ...scope, coBook: 'SOR' }, no, 'SOR')).available,
        );
      return out;
    });
    expect(open).toEqual([0, 0, 500]);
  });

  it('refuses a grid the desktop rules or the plan bounds forbid, and writes nothing', async () => {
    const before = await writeSet();
    const bad: Array<[string, unknown[], RegExp]> = [
      ['no rows', [], /at least one order/i],
      ['zero adjusted amount', [{ ...rowA, adjAmt: 0, kasarAmt: 0, paidAmt: 0 }], /adjust/i],
      [
        'more than is open',
        [{ ...rowA, adjAmt: 1000.01, paidAmt: 1000.01, kasarAmt: 0 }],
        /open advance/i,
      ],
      [
        'paid + kasar not equal to adjusted',
        [{ ...rowA, paidAmt: 800 }],
        /paid.*kasar|kasar.*paid/i,
      ],
      ['negative kasar', [{ ...rowA, kasarAmt: -50, paidAmt: 1050 }], /negative|kasar/i],
      [
        'the same order twice taking more than is open',
        [
          { ...rowA, adjAmt: 600, kasarAmt: 0, paidAmt: 600 },
          { ...rowA, adjAmt: 600, kasarAmt: 0, paidAmt: 600 },
        ],
        /open advance/i,
      ],
      [
        'an order that does not exist',
        [{ ...rowA, ordNo: '00099' }],
        /order.*not found|not pending/i,
      ],
      ['a refund account that does not exist', [{ ...rowA, paidAc: '99999' }], /account/i],
      [
        'an order with nothing open',
        [{ ...rowB, ordNo: '00009', adjAmt: 501, paidAmt: 501 }],
        /open advance/i,
      ],
    ];
    for (const [label, rows, message] of bad) {
      await expect(create(rows), label).rejects.toThrow(message);
      expect(await writeSet(), `${label}: nothing written`).toEqual(before);
    }
  });

  it('refuses a kasar when the book has no kasar account, instead of inventing one', async () => {
    await exec(
      `DELETE FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' AND "SR_NO"=2`,
      TENANT,
    );
    const before = await writeSet();
    await expect(create([rowA])).rejects.toThrow(/kasar/i);
    expect(await writeSet()).toEqual(before);
    // No kasar: not needed.
    await expect(create([{ ...rowA, kasarAmt: 0, paidAmt: 1000 }])).resolves.toMatchObject({
      vchNo: 1,
    });
  });

  it('refuses a date outside the open year with the desktop text before it takes a number', async () => {
    await expect(create([rowA], '2025-04-02')).rejects.toThrow(OUT_OF_YEAR);
    await expect(create([rowA], '2024-03-31')).rejects.toThrow(OUT_OF_YEAR);
    expect(await writeSet()).toEqual({ adj: [], ledger: [], rojmel: [], hidden: [] });
    await expect(create([rowA], '2024-04-01')).resolves.toMatchObject({ vchNo: 1 });
  });

  it('numbers the vouchers 1, 2, 3 and reads one back as the grid it was saved from', async () => {
    await create([rowA]);
    const { vchNo } = await create([rowB]);
    expect(vchNo).toBe(2);
    const read = await getOrderCancel(runtime, scope, 1);
    expect(read).toMatchObject({ voucherNo: '00001', mainUser: 'clerk', vchDate: '2024-05-01' });
    expect(read.rows).toEqual([
      expect.objectContaining({
        srNo: 1,
        ordNo: '00007',
        acCode: CUST_A,
        acName: 'ORDER CUSTOMER A',
        ordYear: YEAR,
        ordBook: 'SOR',
        ordHdVchNo: '00031',
        ordAmt: 1000,
        adjAmt: 1000,
        kasarAmt: 100,
        paidAmt: 900,
        paidAc: CASH,
        paidAcName: 'CASH ON HAND',
        itDesc: 'ring order dropped',
      }),
    ]);
    await expect(getOrderCancel(runtime, scope, 9)).rejects.toThrow(/not found/i);
  });

  it('edits in place: same number, new rows, the used advance of this voucher counts as open again', async () => {
    await create([rowA, rowB]);
    const hidden = (await writeSet()).hidden;
    // Order 00007 can be taken up to 1000 again although this very voucher already used 1000 of it.
    await edit([{ ...rowA, adjAmt: 1000, kasarAmt: 0, paidAmt: 1000 }], 1, '2024-05-02', {
      mainUser: 'ignored',
    });
    const set = await writeSet();
    expect(
      set.adj.map((r: any) => [r.VCH_NO, r.SR_NO, r.ORD_NO, r.ORD_AMT, r.PAID_AMT, r.KASAR_AMT]),
    ).toEqual([['00001', 1, '00007', 1000, 1000, 0]]);
    expect(set.ledger).toHaveLength(2);
    expect(set.rojmel).toHaveLength(1); // cash: only the customer's row
    expect(set.hidden).toEqual(hidden); // the hidden number is kept
    const read = await getOrderCancel(runtime, scope, 1);
    expect(read).toMatchObject({ mainUser: 'clerk', vchDate: '2024-05-02' }); // the first user stays
    expect((await listPendingOrders(runtime, scope)).map((o) => o.ordNo)).toEqual([
      '00008',
      '00009',
    ]);

    const before = await writeSet();
    await expect(
      edit([{ ...rowA, adjAmt: 1000.01, kasarAmt: 0, paidAmt: 1000.01 }], 1),
    ).rejects.toThrow(/open advance/i);
    expect(await writeSet(), 'a refused edit leaves the saved voucher whole').toEqual(before);
    await expect(edit([rowA], 1, '2025-05-02')).rejects.toThrow(OUT_OF_YEAR);
    expect(await writeSet()).toEqual(before);
    await expect(
      editOrderCancel(
        runtime,
        { scope, rows: [rowA], vchDate: '2024-05-02', expectedVersion: STALE },
        7,
      ),
    ).rejects.toThrow(/not found/i);
  });

  it('an unchanged save changes nothing', async () => {
    await create([rowA, rowB]);
    const before = await writeSet();
    const read = await getOrderCancel(runtime, scope, 1);
    await editOrderCancel(
      runtime,
      { scope, rows: read.rows as never, vchDate: read.vchDate, expectedVersion: read.version },
      1,
    );
    expect(await writeSet()).toEqual(before);
  });

  it('deletes the whole voucher with its hidden number and leaves other vouchers alone; a second delete is refused', async () => {
    await create([rowA]);
    await create([rowB]);
    await remove(1);
    const set = await writeSet();
    expect(new Set(set.adj.map((r: any) => r.VCH_NO))).toEqual(new Set(['00002']));
    expect(new Set(set.ledger.map((r: any) => r.VCH_NO))).toEqual(new Set(['00002']));
    expect(new Set(set.rojmel.map((r: any) => r.VCH_NO))).toEqual(new Set(['00002']));
    expect(set.hidden).toHaveLength(1);
    // The desktop delete writes no DELETE_DATA audit row (TR_SL_ORD_ADJ.cs:3726-3756).
    expect(await query(`SELECT 1 FROM "DELETE_DATA" WHERE tenant_id=$1`, TENANT)).toHaveLength(0);
    await expect(
      deleteOrderCancel(runtime, { scope, vchNo: 1, expectedVersion: STALE }),
    ).rejects.toThrow(/not found/i);
    expect((await listPendingOrders(runtime, scope)).map((o) => o.ordNo)).toEqual([
      '00007',
      '00009',
    ]);
  });

  it('opens and deletes a voucher saved by the earlier single-order writer (ORD_SIGN D, amounts in PAID and KASAR only)', async () => {
    await exec(
      `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","ENTRY_TYPE","AC_CODE","AC_NAME","ORD_NO","ORD_AC_CODE","ORD_SIGN","PAID_AMT","PAID_AC","KASAR_AMT","HD_VCH_NO","MAIN_USER")
       VALUES ($1,$2,$3,$4,'ORC','00005',1,'2024-06-01','SADJ','A',$5,'ORDER CUSTOMER A','00007',$5,'D',700,$6,50,'00009','old')`,
      TENANT,
      CO,
      LC,
      YEAR,
      CUST_A,
      CASH,
    );
    const read = await getOrderCancel(runtime, scope, 5);
    expect(read.rows[0]).toMatchObject({
      ordNo: '00007',
      adjAmt: 750,
      paidAmt: 700,
      kasarAmt: 50,
      paidAc: CASH,
    });
    // and the old row's 750 is used advance (not just the 700 paid)
    expect(
      (await listPendingOrders(runtime, scope)).find((o) => o.ordNo === '00007')!.openAmt,
    ).toBe(250);
    await remove(5);
    expect(
      (await listPendingOrders(runtime, scope)).find((o) => o.ordNo === '00007')!.openAmt,
    ).toBe(1000);
  });

  it('two vouchers cannot both take the same advance', async () => {
    await create([{ ...rowA, adjAmt: 700, kasarAmt: 0, paidAmt: 700 }]);
    await expect(create([{ ...rowA, adjAmt: 400, kasarAmt: 0, paidAmt: 400 }])).rejects.toThrow(
      /open advance/i,
    );
    await expect(
      create([{ ...rowA, adjAmt: 300, kasarAmt: 0, paidAmt: 300 }]),
    ).resolves.toMatchObject({ vchNo: 2 });
  });

  it('a stale or missing version is refused before anything changes (version tokens, N51)', async () => {
    await create([rowA]);
    const before = await writeSet();
    await expect(
      editOrderCancel(
        runtime,
        { scope, rows: [rowA], vchDate: '2024-05-02', expectedVersion: STALE },
        1,
      ),
    ).rejects.toThrow(/changed by someone else/i);
    await expect(
      deleteOrderCancel(runtime, { scope, vchNo: 1, expectedVersion: STALE }),
    ).rejects.toThrow(/changed by someone else/i);
    await expect(
      deleteOrderCancel(runtime, { scope, vchNo: 1, expectedVersion: undefined }),
    ).rejects.toThrow(/expectedVersion/);
    expect(await writeSet()).toEqual(before);
    // A version taken before another save is stale afterwards.
    const old = await versionOf(1);
    await edit([{ ...rowA, itDesc: 'second' }], 1);
    await expect(
      deleteOrderCancel(runtime, { scope, vchNo: 1, expectedVersion: old }),
    ).rejects.toThrow(/changed by someone else/i);
  });

  it('writes the ledger legs with the Order_Adj_Ledr columns (Ac_Ledr.cs:928-937)', async () => {
    await create([rowA]);
    const ledger = await query<Record<string, any>>(
      `SELECT length("LEDR_KEY")::int len,"IT_DESC","PARTY_AC_CODE","HD_VCH_NO","MAIN_USER","IT_TYPE","ENTRY_TIME" IS NOT NULL has_time
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ORDER BY "LEDR_KEY"`,
      TENANT,
    );
    const [adj] = await query<Record<string, any>>(
      `SELECT "HD_VCH_NO" FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "CO_BOOK"='ORC'`,
      TENANT,
    );
    expect(ledger).toHaveLength(4);
    for (const leg of ledger)
      expect(leg).toMatchObject({
        len: 33, // CO+LC+YEAR+BOOK+VCH_NO (21) + STR(SR_NO) (10) + leg (2)
        IT_DESC: '',
        PARTY_AC_CODE: CUST_A,
        HD_VCH_NO: adj!.HD_VCH_NO,
        MAIN_USER: 'clerk',
        IT_TYPE: 'A',
        has_time: true,
      });
  });

  it('refuses a blank employee when the company makes it mandatory, with the desktop text (TR_SL_ORD_ADJ.cs:3440)', async () => {
    await exec(`UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"='Y' WHERE tenant_id=$1`, TENANT);
    const before = await writeSet();
    await expect(create([rowA])).rejects.toThrow('Please Select Employee Code and Try......');
    expect(await writeSet()).toEqual(before);
  });

  describe('tags the order held come back to stock (TR_SL_ORD_ADJ.cs:3593-3660, Ac_Stock.cs:610-622)', () => {
    const TAG = 'OC-T100';
    async function seedTag() {
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES ($1,$2,'GR22','GOLD RING 22K','G')`,
        TENANT,
        CO,
      );
      // The tag as it was generated (book TGN), instance 77, with one stone row.
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","STK_DATE","VCH_TIME",
                                "ENTRY_TYPE","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","TBL_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
                                "ITM_TOUCH","ITM_FINE","ITM_MRP","MAIN_USER","ORD_NO","DATA_TYPE")
         VALUES ($1,$2,$3,$4,'TGN','00003',1,'2024-04-02','2024-04-02','2024-04-02 10:00','T','00500','GR22',$5,77,'T01',1,8.25,8.1,
                 91.6,7.42,45000,'maker','00007','A')`,
        TENANT,
        CO,
        LC,
        YEAR,
        TAG,
      );
      await exec(
        `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","TAG_NO",
                                "VCH_SRNO","IT_CODE","IT_PCS","IT_GWT","IT_RATE","IT_AMT")
         VALUES ($1,$2,$3,$4,'TGN','00003',1,1,'2024-04-02',$5,77,'DIA',3,0.15,40000,1800)`,
        TENANT,
        CO,
        LC,
        YEAR,
        TAG,
      );
      // Order 00007 holds the tag (line 1) and has an untagged line (line 2) that is not held.
      await exec(
        `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","AC_CODE","IT_CODE",
                                   "TAG_NO","VCH_SRNO","TBL_CODE","DESIGN_NO","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_MRP",
                                   "TAG_SALE","TAG_STK_LESS")
         VALUES ($1,$2,$3,$4,'SOR','00007',1,1,$5,'GR22',$6,77,'T01','D-9',1,8.25,0.15,8.1,45000,'N','Y'),
                ($1,$2,$3,$4,'SOR','00007',2,2,$5,'GR22','N',0,'','',1,4,0,4,0,'N','N')`,
        TENANT,
        CO,
        LC,
        YEAR,
        CUST_A,
        TAG,
      );
    }
    const tagRows = async () => ({
      apr: await query(
        `SELECT "VCH_NO","SR_NO","ENTRY_TYPE","ISU_NO","ISU_YRCD","ISU_DBCD","ISU_SRNO"::int,"TAG_NO","VCH_SRNO"::int,"ISU_REC",
                "IT_CODE","ITM_REMARK","ITM_GWT"::float,"ITM_MRP"::float,"AC_CODE"
           FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ORDER BY 1,2`,
        TENANT,
      ),
      bar: await query(
        `SELECT "VCH_NO","SR_NO","ENTRY_TYPE","TAG_NO","VCH_SRNO"::bigint::text vsr,"ORD_NO","ITM_GWT"::float,"ITM_MRP"::float,
                "STK_DATE"::date::text stk,"MAIN_USER","VCH_TYPE","BOOK_NAME"
           FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ORDER BY 1,2`,
        TENANT,
      ),
      stones: await query(
        `SELECT "VCH_NO","SR_NO","ENTRY_TYPE","TAG_NO","VCH_SRNO"::bigint::text vsr,"IT_CODE","IT_AMT"::float
           FROM "BAR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ORDER BY 1,2`,
        TENANT,
      ),
      stock: await query(
        `SELECT "VCH_NO","SR_NO","ISR_NO","TR_TYPE","ITM_SIGN","TAG_NO","VCH_SRNO"::bigint::text vsr,"ITM_GWT"::float,"ITM_QTY"::float
           FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='ORC' ORDER BY 1,2`,
        TENANT,
      ),
      sold: await query(
        `SELECT "SR_NO","TAG_SALE" FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "VCH_NO"='00007' ORDER BY "SR_NO"`,
        TENANT,
      ),
    });

    it('cancelling the order copies the held tag back with a new instance and marks the order line sold', async () => {
      await seedTag();
      await create([rowA]);
      const newSrNo = orderCancelTagSrNo(scope, '00001', 1);
      // Val('01') Val('00') '2' Val('ORC') Val('00001') Val(1) -> '1' '0' '2' '0' '1' '1'
      expect(newSrNo).toBe(102011);
      const rows = await tagRows();
      expect(rows.apr).toEqual([
        {
          VCH_NO: '00001',
          SR_NO: 1,
          ENTRY_TYPE: 'I',
          ISU_NO: '00007',
          ISU_YRCD: YEAR,
          ISU_DBCD: 'SOR',
          ISU_SRNO: 1,
          TAG_NO: TAG,
          VCH_SRNO: 77,
          ISU_REC: 'Y',
          IT_CODE: 'GR22',
          ITM_REMARK: 'GOLD RING 22K',
          ITM_GWT: 8.25,
          ITM_MRP: 45000,
          AC_CODE: CUST_A,
        },
      ]);
      expect(rows.bar).toEqual([
        {
          VCH_NO: '00001',
          SR_NO: 1,
          ENTRY_TYPE: 'D',
          TAG_NO: TAG,
          vsr: String(newSrNo),
          ORD_NO: '',
          ITM_GWT: 8.25,
          ITM_MRP: 45000,
          stk: '2024-04-02',
          MAIN_USER: 'maker', // copied from the tag row, as the desktop's INSERT ... SELECT does
          VCH_TYPE: 'SADJ',
          BOOK_NAME: 'ORDER CANCEL',
        },
      ]);
      expect(rows.stones).toEqual([
        {
          VCH_NO: '00001',
          SR_NO: 1,
          ENTRY_TYPE: 'D',
          TAG_NO: TAG,
          vsr: String(newSrNo),
          IT_CODE: 'DIA',
          IT_AMT: 1800,
        },
      ]);
      expect(rows.stock).toEqual([
        {
          VCH_NO: '00001',
          SR_NO: 2,
          ISR_NO: 1,
          TR_TYPE: 'I',
          ITM_SIGN: '+',
          TAG_NO: TAG,
          vsr: String(newSrNo),
          ITM_GWT: 8.25,
          ITM_QTY: 1,
        },
      ]);
      expect(rows.sold).toEqual([
        { SR_NO: 1, TAG_SALE: 'Y' },
        { SR_NO: 2, TAG_SALE: 'N' },
      ]);
      expect((await getOrderCancel(runtime, scope, 1)).tags).toEqual([
        expect.objectContaining({
          srNo: 1,
          ordNo: '00007',
          tagNo: TAG,
          itName: 'GOLD RING 22K',
          gwt: 8.25,
        }),
      ]);
    });

    it('an edit keeps the tag released once; a delete gives it back to the order and removes every tag row', async () => {
      await seedTag();
      await create([rowA]);
      await edit([{ ...rowA, itDesc: 'edited' }], 1);
      const rows = await tagRows();
      expect([rows.apr.length, rows.bar.length, rows.stones.length, rows.stock.length]).toEqual([
        1, 1, 1, 1,
      ]);
      expect(rows.sold).toEqual([
        { SR_NO: 1, TAG_SALE: 'Y' },
        { SR_NO: 2, TAG_SALE: 'N' },
      ]);
      await remove(1);
      const after = await tagRows();
      expect([after.apr, after.bar, after.stones, after.stock]).toEqual([[], [], [], []]);
      expect(after.sold).toEqual([
        { SR_NO: 1, TAG_SALE: 'N' },
        { SR_NO: 2, TAG_SALE: 'N' },
      ]);
      // A second cancel picks the tag up again (it is held by the order once more).
      await create([rowA]);
      expect((await tagRows()).apr).toHaveLength(1);
    });
  });

  describe('one transaction: a failure after any table leaves nothing behind (T14)', () => {
    const TRIGGER = 'oc_fault';
    const FN = 'oc_fault_fn';
    const TABLES = [
      'TEMP_BOOK_DATA',
      'SL_ORD_ADJ',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'APR_DETL',
      'BAR_DETL',
      'BAR_IDTL',
      'MAIN_STOCK',
      'SL_ORD_DETL',
    ];
    async function clear() {
      for (const t of TABLES)
        await owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS "${TRIGGER}" ON "${t}"`);
      await owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS "${FN}"()`);
    }
    async function install(table: string, op: 'INSERT' | 'DELETE' | 'UPDATE') {
      await owner.$executeRawUnsafe(`CREATE FUNCTION "${FN}"() RETURNS trigger LANGUAGE plpgsql AS $f$
        BEGIN
          IF (CASE WHEN TG_OP='DELETE' THEN OLD.tenant_id ELSE NEW.tenant_id END) = '${TENANT}' THEN
            RAISE EXCEPTION 'order cancel injected fault on %', TG_TABLE_NAME;
          END IF;
          IF TG_OP='DELETE' THEN RETURN OLD; END IF;
          RETURN NEW;
        END $f$`);
      await owner.$executeRawUnsafe(
        `CREATE TRIGGER "${TRIGGER}" AFTER ${op} ON "${table}" FOR EACH ROW EXECUTE FUNCTION "${FN}"()`,
      );
    }
    async function expectRollback(
      table: string,
      op: 'INSERT' | 'DELETE' | 'UPDATE',
      action: () => Promise<unknown>,
    ) {
      const before = await snapshotTenant(owner, TENANT);
      await install(table, op);
      try {
        await expect(action(), `${op} ${table}`).rejects.toThrow(/order cancel injected fault/);
      } finally {
        await clear();
      }
      expect(diffTenant(before, await snapshotTenant(owner, TENANT)), `${op} ${table}`).toEqual({
        added: {},
        removed: {},
      });
    }
    afterAll(clear);
    async function seedTagged() {
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TIME","TAG_NO","VCH_SRNO","IT_CODE","ITM_GWT")
         VALUES ($1,$2,$3,$4,'TGN','00004',1,'2024-04-02','2024-04-02 10:00','OC-F1',5,'GR22',2)`,
        TENANT,
        CO,
        LC,
        YEAR,
      );
      await exec(
        `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE")
         VALUES ($1,$2,$3,$4,'TGN','00004',1,1,'2024-04-02','OC-F1',5,'DIA')`,
        TENANT,
        CO,
        LC,
        YEAR,
      );
      await exec(
        `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","AC_CODE","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_MRP","TAG_SALE","TAG_STK_LESS")
         VALUES ($1,$2,$3,$4,'SOR','00007',1,1,$5,'GR22','OC-F1',5,1,2,900,'N','Y')`,
        TENANT,
        CO,
        LC,
        YEAR,
        CUST_A,
      );
    }

    it('create', async () => {
      await seedTagged();
      for (const table of TABLES.filter((t) => t !== 'SL_ORD_DETL'))
        await expectRollback(table, 'INSERT', () => create([rowA, rowB]));
      await expectRollback('SL_ORD_DETL', 'UPDATE', () => create([rowA, rowB]));
    });

    it('edit and delete', async () => {
      await seedTagged();
      await create([rowA, rowB]);
      for (const table of TABLES.filter((t) => t !== 'SL_ORD_DETL')) {
        await expectRollback(table, 'DELETE', () => edit([rowA], 1));
        await expectRollback(table, 'INSERT', () => edit([rowA], 1));
        await expectRollback(table, 'DELETE', () => remove(1));
      }
      await expectRollback('SL_ORD_DETL', 'UPDATE', () => edit([rowA], 1));
      await expectRollback('SL_ORD_DETL', 'UPDATE', () => remove(1));
    });
  });

  describe('the advance rule is shared with the sale: the same advance is never used twice', () => {
    const saleTakes = (amount: number) =>
      withTenant(runtime, TENANT, async (tx) => {
        const salesScope = { ...scope, coBook: 'SAL' };
        const av = await orderAdvanceAvailableTx(tx, salesScope, '00007', 'SOR');
        const take = Math.min(amount, av.available);
        if (take > 0)
          await adjustOrderIntoSaleTx(tx, TENANT, salesScope, {
            saleVchNo: '00011',
            ordNo: '00007',
            custAc: CUST_A,
            adjustAmt: take,
            vchDate: new Date('2024-05-03'),
          });
        return take;
      });
    const used = async () =>
      (await listPendingOrders(runtime, scope)).find((o) => o.ordNo === '00007')?.adjAmt ?? 1000;

    it('a sale after a cancel sees only what the cancel left, and a cancel after a sale likewise', async () => {
      await create([{ ...rowA, adjAmt: 600, kasarAmt: 0, paidAmt: 600 }]);
      expect(await saleTakes(1000)).toBe(400);
      await expect(create([{ ...rowA, adjAmt: 1, kasarAmt: 0, paidAmt: 1 }])).rejects.toThrow(
        /open advance/i,
      );
      expect(await used()).toBe(1000);
    });

    it('a sale and a cancel racing for the same order never take more than the advance together', async () => {
      for (let round = 0; round < 3; round++) {
        await wipe();
        await seed();
        await exec(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE")
           VALUES ($1,$2,$3,'SAL','Sales','SALE','SALES','O','Y')`,
          TENANT,
          CO,
          LC,
        );
        const results = await Promise.allSettled([
          create([{ ...rowA, adjAmt: 700, kasarAmt: 0, paidAmt: 700 }]),
          saleTakes(700),
        ]);
        const [cancel, sale] = results;
        const cancelled = cancel.status === 'fulfilled' ? 700 : 0;
        const sold = sale.status === 'fulfilled' ? sale.value : 0;
        expect(cancelled + sold, `round ${round}`).toBeLessThanOrEqual(1000);
        expect(cancelled + sold, `round ${round}: one of them got its share`).toBeGreaterThan(0);
        const [{ total }] = await query<{ total: number }>(
          `SELECT coalesce(sum(CASE WHEN "ORD_SIGN"='-' THEN "ORD_AMT" ELSE "PAID_AMT"+coalesce("KASAR_AMT",0) END),0)::float total
             FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "ORD_NO"='00007' AND "ORD_SIGN" IN ('-','C','D')`,
          TENANT,
        );
        expect(total).toBeLessThanOrEqual(1000);
      }
    });
  });
});
