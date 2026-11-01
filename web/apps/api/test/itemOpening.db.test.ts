import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteItemOpening,
  getItemOpening,
  saveItemOpening,
  type ItemOpeningSaveLine,
} from '../src/modules/stock/itemOpening.js';
import { onHandNet } from '../src/modules/stock/stock.js';

/**
 * N209 / G222: Item Opening is the desktop TR_ITM_OPBL grid, one opening per metal type in book '000'.
 *
 * Expected values come from the desktop, not from the web:
 * - DISPLAY_DATA (TR_ITM_OPBL.cs:1269-1370) lists every item of the type, ordered IT_TYPE, GR_CODE, IT_NAME.
 * - BtnSave_Click (:1414-1441) writes ITM_OPBL rows in book '000' with VCH_NO = the type letter, only for rows whose
 *   gross weight plus pieces is not zero, SR_NO = the grid row (gaps kept), and the cells as the grid holds them.
 * - Ac_Stock.Itm_Opbl_Stk (Ac_Stock.cs:11-21): one purchase-in stock row per opening row, dated the day before the
 *   year opens: VCH_TYPE 'ITOBL', BOOK_NAME 'ITM OPBL', AC_CODE '00000', TAG_NO 'N', ITM_QTY = pieces, the karigar
 *   columns copied from the item columns. The migrated desktop data has 72 such rows, all SR_NO = the opening row and
 *   ISR_NO 1, with ITM_LOT and ITM_DISC left NULL.
 * - Ac_Stock.Dm_Itm_Opbl_Detl (:734-741): a DM_DATA row only for items with OTH_DETL_POSTING 'Y'.
 * - BtnDelete_Click (:1492-1517) removes the type's stock, other-detail and opening rows.
 * The main branch had none of this: the screen wrote a numbered BAR_DATA voucher in book IOP dated on the voucher date.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'item-opening';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const STOCK_DATE = '2024-03-31';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
/** Reads bind $1 to this file's tenant: the owner connection bypasses RLS, and other test files share the database. */
const rows = <T = any>(sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$queryRawUnsafe(sql, TENANT, ...p)) as Promise<T[]>;

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const t of tables)
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seed(): Promise<void> {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF") VALUES ($1,$2,'N',2,2,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  // Grid order is IT_TYPE, GR_CODE, IT_NAME: CHAIN (group A) before BANGLE and RING (group B, by name).
  for (const [code, name, type, group, rateType, oth] of [
    ['RING', 'RING', 'G', 'B', 'G', 'N'],
    ['BANG', 'BANGLE', 'G', 'B', 'G', 'Y'],
    ['CHAIN', 'CHAIN', 'G', 'A', 'P', 'N'],
    ['SLV', 'SILVER BAR', 'S', 'A', 'G', 'N'],
  ])
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","RATE_TYPE","OTH_DETL_POSTING")
       VALUES ($1,$2,$3,$4,$5,$6,$7,$8)`,
      TENANT,
      CO,
      code,
      name,
      type,
      group,
      rateType,
      oth,
    );
  // A Tag Opening row in book '000' (numeric voucher): Item Opening must never touch it.
  await exec(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_TYPE","BOOK_NAME",
       "IT_CODE","TAG_NO","TR_TYPE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
     VALUES ($1,$2,$3,$4,'000','00001',1,'TAGOP','TAG OPBL','RING','G1','P','+',1,5,5,4.58)`,
    TENANT,
    CO,
    LC,
    YEAR,
  );
}

/** The grid as the screen sends it: CHAIN (row 1), BANGLE (row 2) and RING (row 3). */
const GOLD_GRID: ItemOpeningSaveLine[] = [
  // Piece-rated chain: 3 pcs × 250 = 750, no weight.
  { itCode: 'CHAIN', pcs: 3, rate: 250, amount: 750, netAmt: 750 },
  // Bangle untouched: gross + pcs = 0, so the desktop saves no row and row 2 is a gap.
  { itCode: 'BANG' },
  // Ring: 10.5 g at 91.6 + 2 → fine 9.828 × 6000 = 58,968; labour G 10.5 × 13 = 136.5 → 136 (half to even); other 100.
  {
    itCode: 'RING',
    pcs: 2,
    grossWt: 10.5,
    netWt: 10.5,
    touch: 91.6,
    westPct: 2,
    fineWt: 9.828,
    rate: 6000,
    amount: 58968,
    lbrType: 'G',
    lbrRate: 13,
    lbrAmt: 136,
    othAmt: 100,
    netAmt: 59204,
  },
];

const opbl = () =>
  rows(
    `SELECT "CO_BOOK" book, "VCH_NO" vch, "SR_NO"::int sr, "IT_CODE" it, "ITM_PCS"::float pcs, "ITM_GWT"::float gwt,
            "ITM_NWT"::float nwt, "ITM_TOUCH"::float touch, "ITM_WEST_PRC"::float west, "ITM_FINE"::float fine,
            "ITM_RATE"::float rate, "ITM_AMT"::float amt, "LBR_TYPE" lt, "LBR_RATE"::float lr, "LBR_AMT"::float la,
            "OTH_AMT"::float oa, "NET_AMT"::float na, "DATA_TYPE" dt, "DATA_TRFR" trfr, "MAIN_USER" mu
       FROM "ITM_OPBL" WHERE tenant_id=$1 ORDER BY "VCH_NO", "SR_NO"`,
  );
const stock = () =>
  rows(
    `SELECT "CO_BOOK" book, "VCH_NO" vch, "SR_NO"::int sr, "ISR_NO"::int isr, "VCH_DATE"::text dt, "STK_DATE" sd,
            "ENTRY_TIME"::text et, "VCH_TYPE" vt, "BOOK_NAME" bn, "AC_CODE" ac, "IT_CODE" it, "TAG_NO" tag,
            "VCH_SRNO"::int vs, "TBL_CODE" ctr, "TR_TYPE" tr, "ITM_SIGN" sg, "ITM_QTY"::float qty, "ITM_PCS"::float pcs,
            "ITM_GWT"::float gwt, "ITM_NWT"::float nwt, "ITM_TOUCH"::float touch, "ITM_WEST"::float west,
            "ITM_FINE"::float fine, "ITM_RATE"::float rate, "ITM_AMT"::float amt, "LBR_RATE"::float lr,
            "LBR_AMT"::float la, "OTH_AMT"::float oa, "NET_AMT"::float na, "KR_NWT"::float krn,
            "KR_TOUCH"::float krt, "KR_WEST"::float krw, "KR_FINE"::float krf, "KR_LBR_AMT"::float krl,
            "KR_OTH_AMT"::float kro, "KR_COST"::float krc, "ITM_LOT" lot, "ITM_DISC" disc
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "VCH_TYPE"='ITOBL' ORDER BY "VCH_NO", "SR_NO"`,
  );
/** The type's current version token, as the screen reads it before a save or delete. */
const ver = async (type: string) =>
  type.trim() ? (await getItemOpening(runtime, scope, type)).version : '0'.repeat(64);
const count = async (table: string, where = 'true') =>
  Number(
    (
      await rows<{ n: number }>(
        `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND ${where}`,
      )
    )[0]!.n,
  );

describe.skipIf(!RUN)('Item Opening = desktop TR_ITM_OPBL (N209, G222)', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('lists every item of the type in the desktop order, with no opening yet', async () => {
    const grid = await getItemOpening(runtime, scope, 'G');
    expect(grid.type).toBe('G');
    expect(grid.stockDate).toBe(STOCK_DATE);
    expect(grid.rows.map((r) => [r.srNo, r.itCode, r.itName, r.rateType, r.saved])).toEqual([
      [1, 'CHAIN', 'CHAIN', 'P', false],
      [2, 'BANG', 'BANGLE', 'G', false],
      [3, 'RING', 'RING', 'G', false],
    ]);
    expect(grid.rows.every((r) => r.pcs === 0 && r.grossWt === 0 && r.netAmt === 0)).toBe(true);
  });

  it('saves the grid as ITM_OPBL rows in book 000 and ITOBL stock rows dated the day before the year', async () => {
    const grid = await saveItemOpening(runtime, {
      scope,
      type: 'G',
      expectedVersion: await ver('G'),
      rows: GOLD_GRID,
      mainUser: 'ADMIN',
    });

    expect(await opbl()).toEqual([
      expect.objectContaining({
        book: '000',
        vch: 'G',
        sr: 1,
        it: 'CHAIN',
        pcs: 3,
        gwt: 0,
        rate: 250,
        amt: 750,
        na: 750,
        dt: 'A',
        trfr: 'Y',
        mu: 'ADMIN',
      }),
      // Row 2 (the bangle) is not saved, and the ring keeps SR_NO 3.
      expect.objectContaining({
        sr: 3,
        it: 'RING',
        pcs: 2,
        gwt: 10.5,
        nwt: 10.5,
        touch: 91.6,
        west: 2,
        fine: 9.828,
        rate: 6000,
        amt: 58968,
        lt: 'G',
        lr: 13,
        la: 136,
        oa: 100,
        na: 59204,
      }),
    ]);

    const ring = (await stock()).find((r) => r.it === 'RING');
    expect(ring).toEqual({
      book: '000',
      vch: 'G',
      sr: 3,
      isr: 1,
      dt: STOCK_DATE,
      sd: STOCK_DATE,
      et: STOCK_DATE,
      vt: 'ITOBL',
      bn: 'ITM OPBL',
      ac: '00000',
      it: 'RING',
      tag: 'N',
      vs: 0,
      ctr: '',
      tr: 'P',
      sg: '+',
      qty: 2,
      pcs: 2,
      gwt: 10.5,
      nwt: 10.5,
      touch: 91.6,
      west: 0,
      fine: 9.828,
      rate: 6000,
      amt: 58968,
      lr: 0,
      la: 136,
      oa: 100,
      na: 59204,
      krn: 10.5,
      krt: 91.6,
      krw: 0,
      krf: 9.828,
      krl: 136,
      kro: 100,
      krc: 59204,
      lot: null,
      disc: null,
    });
    expect((await stock()).map((r) => [r.it, r.sr])).toEqual([
      ['CHAIN', 1],
      ['RING', 3],
    ]);
    // No voucher header and no ledger: the opening is stock only.
    expect(await count('BAR_DATA')).toBe(0);
    expect(await count('AC_DATA')).toBe(0);
    // The reloaded grid shows the saved rows.
    expect(grid.rows.map((r) => [r.itCode, r.saved, r.pcs, r.grossWt, r.fineWt, r.netAmt])).toEqual(
      [
        ['CHAIN', true, 3, 0, 0, 750],
        ['BANG', false, 0, 0, 0, 0],
        ['RING', true, 2, 10.5, 9.828, 59204],
      ],
    );
  });

  it('writes the other-detail row only for an item that posts other details', async () => {
    await saveItemOpening(runtime, {
      scope,
      type: 'G',
      expectedVersion: await ver('G'),
      rows: [
        { itCode: 'CHAIN', pcs: 1 },
        { itCode: 'BANG', pcs: 2, grossWt: 20, netWt: 20, rate: 10, amount: 200 },
      ],
    });
    const dm = await rows(
      `SELECT "CO_BOOK" book, "VCH_NO" vch, "MAIN_SRNO"::int m, "SR_NO"::int sr, "ISR_NO"::int isr, "VCH_DATE"::text dt,
              "ENTRY_TYPE" et, "BOOK_NAME" bn, "AC_CODE" ac, "IT_CODE" it, "DM_CODE" dc, "DM_PCS"::float pcs,
              "DM_WT"::float wt, "DM_SIGN" sg, "DM_RATE"::float rate, "DM_AMT"::float amt, "TAG_NO" tag,
              "INOUT_TYPE" io
         FROM "DM_DATA" WHERE tenant_id=$1`,
    );
    expect(dm).toEqual([
      {
        book: '000',
        vch: 'G',
        m: 1,
        sr: 2,
        isr: 1,
        dt: STOCK_DATE,
        et: 'L',
        bn: 'ITOBL',
        ac: '00000',
        it: 'BANG',
        dc: 'BANG',
        pcs: 2,
        wt: 20,
        sg: '+',
        rate: 10,
        amt: 200,
        tag: 'N',
        io: 'P',
      },
    ]);
  });

  it('keeps stored cells on an unchanged save, and replaces the type without duplicating it', async () => {
    // A stored fine that is not the formula's (touch 0 would give fine = net), as 18 of the migrated rows hold.
    const kept = { itCode: 'RING', pcs: 1, grossWt: 5, netWt: 5, fineWt: 4.5, rate: 0, netAmt: 0 };
    await saveItemOpening(runtime, {
      scope,
      type: 'G',
      expectedVersion: await ver('G'),
      rows: [{}, {}, kept],
    });
    const reloaded = await getItemOpening(runtime, scope, 'G');
    const again = reloaded.rows.map((r) => ({ ...r }));
    await saveItemOpening(runtime, {
      scope,
      type: 'G',
      expectedVersion: await ver('G'),
      rows: again,
    });
    const saved = await opbl();
    expect(saved).toHaveLength(1);
    expect(saved[0]).toMatchObject({ sr: 3, it: 'RING', fine: 4.5 });
    expect((await stock()).map((r) => [r.it, r.fine])).toEqual([['RING', 4.5]]);
  });

  it('drops a row cleared to zero and leaves other types and Tag Opening rows alone', async () => {
    await saveItemOpening(runtime, {
      scope,
      type: 'G',
      expectedVersion: await ver('G'),
      rows: GOLD_GRID,
    });
    await saveItemOpening(runtime, {
      scope,
      type: 'S',
      expectedVersion: await ver('S'),
      rows: [{ itCode: 'SLV', grossWt: 1000, netWt: 1000 }],
    });
    // Clear the chain: only the ring stays.
    await saveItemOpening(runtime, {
      scope,
      type: 'G',
      expectedVersion: await ver('G'),
      rows: [{ itCode: 'CHAIN' }, { itCode: 'BANG' }, GOLD_GRID[2]!],
    });
    expect((await opbl()).map((r) => [r.vch, r.sr, r.it])).toEqual([
      ['G', 3, 'RING'],
      ['S', 1, 'SLV'],
    ]);
    expect(await count('MAIN_STOCK', `"VCH_TYPE"='TAGOP'`)).toBe(1);
  });

  it('reaches stock on hand, and a delete takes it back out', async () => {
    const before = await onHandNet(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    await saveItemOpening(runtime, {
      scope,
      type: 'G',
      expectedVersion: await ver('G'),
      rows: GOLD_GRID,
    });
    const after = await onHandNet(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    expect(after.pcs - before.pcs).toBe(5);
    expect(Math.round((after.gwt - before.gwt) * 1000) / 1000).toBe(10.5);
    expect(Math.round((after.fine - before.fine) * 1000) / 1000).toBe(9.828);

    await saveItemOpening(runtime, {
      scope,
      type: 'S',
      expectedVersion: await ver('S'),
      rows: [{ itCode: 'SLV', grossWt: 1000, netWt: 1000 }],
    });
    expect(await deleteItemOpening(runtime, scope, 'G', await ver('G'))).toEqual({
      type: 'G',
      deleted: 2,
    });
    expect((await opbl()).map((r) => r.vch)).toEqual(['S']);
    expect((await stock()).map((r) => r.vch)).toEqual(['S']);
    expect(await count('MAIN_STOCK', `"VCH_TYPE"='TAGOP'`)).toBe(1);
    const gone = await onHandNet(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    expect(Math.round((gone.gwt - before.gwt) * 1000) / 1000).toBe(1000);
  });

  it('refuses a save or delete from a stale read (N51)', async () => {
    const stale = await ver('G');
    await saveItemOpening(runtime, {
      scope,
      type: 'G',
      expectedVersion: stale,
      rows: GOLD_GRID,
    });
    // A second operator who read the grid before that save cannot overwrite it or delete it.
    await expect(
      saveItemOpening(runtime, {
        scope,
        type: 'G',
        expectedVersion: stale,
        rows: [{ itCode: 'RING', grossWt: 1, netWt: 1 }],
      }),
    ).rejects.toThrow('This voucher was changed by someone else after you opened it.');
    await expect(deleteItemOpening(runtime, scope, 'G', stale)).rejects.toThrow(
      'This voucher was changed by someone else after you opened it.',
    );
    expect((await opbl()).map((r) => [r.it, r.gwt])).toEqual([
      ['CHAIN', 0],
      ['RING', 10.5],
    ]);
  });

  it('refuses with the desktop messages', async () => {
    await expect(
      saveItemOpening(runtime, {
        scope,
        type: '',
        expectedVersion: await ver(''),
        rows: [],
      }),
    ).rejects.toThrow('Please Select Metaltype....');
    await expect(
      saveItemOpening(runtime, {
        scope,
        type: ' ',
        expectedVersion: await ver(' '),
        rows: [],
      }),
    ).rejects.toThrow('Please Select Metaltype....');
    await expect(deleteItemOpening(runtime, scope, '', '0'.repeat(64))).rejects.toThrow(
      'Please Select Item For Delete.',
    );
    // A silver item cannot be saved into the gold opening.
    await expect(
      saveItemOpening(runtime, {
        scope,
        type: 'G',
        expectedVersion: await ver('G'),
        rows: [{ itCode: 'SLV', grossWt: 1 }],
      }),
    ).rejects.toThrow('item SLV is not a G item in this company');
    // A row with weight but no item code (the desktop would save it with a blank IT_CODE).
    await expect(
      saveItemOpening(runtime, {
        scope,
        type: 'G',
        expectedVersion: await ver('G'),
        rows: [{}, { grossWt: 2 }],
      }),
    ).rejects.toThrow('row 2: item code is required');
    expect(await count('ITM_OPBL')).toBe(0);
  });
});
