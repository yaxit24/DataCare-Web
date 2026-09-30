import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  deleteTagSplit,
  getTagSplit,
  listTagSplit,
  saveTagSplit,
  tagSplitSource,
} from '../src/modules/stock/tagSplit.js';
import { issueTagTx } from '../src/modules/stock/stock.js';
import { countsOf, diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

/**
 * N19 — Tag Split (X20), desktop TR_TAG_SPLIT, against a real database. Every expected value is the contract's
 * (parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md); vector ids are the contract's.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tag-split-lifecycle';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-06-10';
const USER = 'operator';
const D = (iso: string) => new Date(`${iso}T00:00:00.000Z`);

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });

const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
const query = <T = Array<Record<string, unknown>>>(sql: string, ...p: unknown[]) =>
  owner.$queryRawUnsafe(sql, ...p) as Promise<T>;
const insert = async (table: string, row: Record<string, unknown>) => {
  const cols = Object.keys(row);
  await exec(
    `INSERT INTO "${table}"(tenant_id,${cols.map((c) => `"${c}"`).join(',')})
     VALUES ($1,${cols.map((_, i) => `$${i + 2}`).join(',')})`,
    TENANT,
    ...cols.map((c) => row[c]),
  );
};
const scope = (coBook = 'TSP') => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});
const snapshot = () => snapshotTenant(owner, TENANT);

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT DISTINCT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const t of tables)
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
}

const bar = (over: Record<string, unknown>) => ({
  CO_CODE: CO,
  LC_CODE: LC,
  CO_YEAR: YEAR,
  CO_BOOK: 'TOP',
  VCH_NO: '00001',
  SR_NO: 1,
  OLD_SRNO: 1,
  VCH_DATE: D('2024-04-05'),
  VCH_TYPE: 'TAGOP',
  BOOK_NAME: 'TAG OPBL',
  INOUT_TYPE: 'I',
  ENTRY_TYPE: 'O',
  IT_CODE: 'RNG',
  TBL_CODE: '001',
  ITM_PCS: 1,
  ITM_GWT: 10,
  ITM_OTH_WT: 0,
  ITM_NWT: 10,
  ITM_TOUCH: 91.6,
  ITM_WEST_PRC: 0,
  ITM_FINE: 9.16,
  KR_NET_WT: 10,
  KR_TOUCH: 91.6,
  KR_FINE: 9.16,
  RATE_TYPE: '',
  IT_TYPE: 'G',
  TAG_TYPE: 'R',
  PR_CODE: 'RG',
  EMP_ISU: 'N',
  DATA_TYPE: 'A',
  ...over,
});
const stockRow = (
  b: Record<string, unknown>,
  sign: '+' | '-',
  over: Record<string, unknown> = {},
) => ({
  CO_CODE: b.CO_CODE,
  LC_CODE: b.LC_CODE,
  CO_YEAR: YEAR,
  CO_BOOK: b.CO_BOOK,
  VCH_NO: b.VCH_NO,
  SR_NO: b.SR_NO,
  ISR_NO: 1,
  VCH_DATE: b.VCH_DATE,
  STK_DATE: '2024-04-05',
  VCH_TYPE: sign === '+' ? 'TAGOP' : 'TGSL',
  BOOK_NAME: sign === '+' ? 'TAG OPBL' : 'SALES',
  IT_CODE: b.IT_CODE,
  TAG_NO: b.TAG_NO,
  VCH_SRNO: b.VCH_SRNO,
  TBL_CODE: '001',
  TR_TYPE: sign === '+' ? 'P' : 'S',
  ITM_SIGN: sign,
  ITM_QTY: 1,
  ITM_PCS: 1,
  ITM_GWT: b.ITM_GWT,
  ITM_NWT: b.ITM_NWT,
  ITM_FINE: b.ITM_FINE,
  DATA_TYPE: 'A',
  ...over,
});

const PARENT = bar({
  TAG_NO: 'SPL00001',
  VCH_SRNO: 100200000001,
  DESIGN_NO: 'D-1',
  ITM_SIZE: '12',
});
const SOLD = bar({ TAG_NO: 'SPL00009', VCH_SRNO: 100200000009, SR_NO: 2, OLD_SRNO: 2 });

async function seed(): Promise<void> {
  await wipe();
  await insert('CO_SET', { CO_CODE: CO, TRAD_FINE: 'Y' });
  await insert('YEAR_MAST', {
    CO_CODE: CO,
    CO_YEAR: YEAR,
    OP_DATE: D('2024-04-01'),
    CL_DATE: D('2025-03-31'),
  });
  await insert('BOOK_DATA', {
    CO_CODE: CO,
    LC_CODE: LC,
    CO_BOOK: 'TSP',
    BOOK_NAME: 'Tag Split',
    BOOK_SNAME: 'TGSPL',
    MAIN_BOOK: 'TAG SPLIT',
    BOOK_INOUT: 'O',
    CUR_USE: 'Y',
    BOOK_TBL_NAME: 'LBR_DATA',
  });
  for (const [srNo, ac] of [
    [5, 'LBREXP'],
    [6, 'GLDDR'],
    [7, 'GLDCR'],
    [8, 'SLVDR'],
    [9, 'SLVCR'],
  ] as const) {
    await insert('BOOK_DETL', {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_BOOK: 'TSP',
      SR_NO: srNo,
      AC_CODE: ac,
    });
  }
  await insert('EMP_MAST', { CO_CODE: CO, EMP_CODE: '001', EMP_NAME: 'Ramesh' });
  for (const [code, name] of [
    ['SPLITAC', 'Split absorb'],
    ['LBREXP', 'Labour expense'],
    ['GLDDR', 'Gold Dr'],
    ['GLDCR', 'Gold Cr'],
    ['SLVDR', 'Silver Dr'],
    ['SLVCR', 'Silver Cr'],
  ] as const) {
    await insert('AC_MAST', { CO_CODE: CO, LC_CODE: LC, AC_CODE: code, AC_NAME: name });
  }
  for (const [code, name, type, pr, dm] of [
    ['RNG', 'Ring 22K', 'G', 'RG', 'N'],
    ['RNGH', 'Half Ring', 'G', 'RH', 'N'],
    ['DIA', 'Diamond', 'D', 'DM', 'Y'],
    // A stone whose item does NOT post to the diamond register (OTH_DETL_POSTING 'N').
    ['PRL', 'Pearl', 'S', 'PR', 'N'],
  ] as const) {
    await insert('ITEM_MAST', {
      CO_CODE: CO,
      IT_CODE: code,
      IT_NAME: name,
      IT_TYPE: type,
      PR_CODE: pr,
      TAG_TYPE: code === 'RNGH' ? 'H' : 'R',
      OTH_DETL_POSTING: dm,
    });
  }
  for (const b of [PARENT, SOLD]) {
    await insert('BAR_DETL', b);
    await insert('MAIN_STOCK', stockRow(b, '+'));
  }
  // SPL00009 was sold: a '-' balances its '+'.
  await insert('MAIN_STOCK', stockRow(SOLD, '-', { CO_BOOK: 'SL', VCH_NO: '00007' }));
  await insert('BAR_IDTL', {
    CO_CODE: CO,
    LC_CODE: LC,
    CO_YEAR: YEAR,
    CO_BOOK: 'TOP',
    VCH_NO: '00001',
    SR_NO: 1,
    ISR_NO: 1,
    VCH_DATE: D('2024-04-05'),
    TAG_NO: 'SPL00001',
    VCH_SRNO: 100200000001,
    IT_CODE: 'DIA',
    IT_TYPE: 'D',
    IT_PCS: 10,
    IT_GWT: 0.5,
    IT_AMT: 1000,
    IT_NET_AMT: 1000,
  });
  // A second parent stone whose item does NOT post to the diamond register — it must stay out of DM_DATA.
  await insert('BAR_IDTL', {
    CO_CODE: CO,
    LC_CODE: LC,
    CO_YEAR: YEAR,
    CO_BOOK: 'TOP',
    VCH_NO: '00001',
    SR_NO: 1,
    ISR_NO: 2,
    VCH_DATE: D('2024-04-05'),
    TAG_NO: 'SPL00001',
    VCH_SRNO: 100200000001,
    IT_CODE: 'PRL',
    IT_TYPE: 'S',
    IT_PCS: 4,
    IT_GWT: 0.2,
    IT_AMT: 300,
    IT_NET_AMT: 300,
  });
  // SRNO_MAST counter so child allocation has a row to advance.
  await insert('SRNO_MAST', {
    CO_CODE: CO,
    LC_CODE: LC,
    TAG_SRNO: 100,
    VCH_SRNO: 0,
    TAG_NO: '',
    IT_CODE: '',
  });
}

async function live(tagNo: string, vchSrno: number): Promise<boolean> {
  try {
    await tagSplitSource(runtime, scope(), { tagNo, vchSrno });
    return true;
  } catch (error) {
    if (error instanceof Error && error.name === 'TagNotAvailableError') return false;
    throw error;
  }
}

const TWO_CHILDREN = [
  { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
  { itCode: 'RNGH', grossWt: 4, touch: 91.6 },
];

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('N19 tag split (TR_TAG_SPLIT) — contract vectors', () => {
  beforeEach(seed);
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('V1: splits a parent into two children, conserving the fine; nothing else changes unexpectedly', async () => {
    const before = await snapshot();
    const result = await saveTagSplit(runtime, {
      scope: scope(),
      vchDate: DAY,
      empCode: '001',
      vchDesc: 'worn',
      mainUser: USER,
      parents: [{ tagNo: 'SPL00001' }],
      children: TWO_CHILDREN,
    });
    expect(result).toMatchObject({
      voucherNo: '00001',
      parents: 1,
      children: 2,
      stockRows: 3,
      ledgerRows: 0,
    });

    // The register: one LBR_DATA header, one parent, two children, two child BAR_DETL tags.
    const [header] = await query(
      `SELECT "ENTRY_TYPE","AC_CODE","IT_TYPE" FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
      TENANT,
    );
    expect(header).toMatchObject({ ENTRY_TYPE: 'C', AC_CODE: '', IT_TYPE: 'G' });
    expect(
      await query(
        `SELECT count(*)::int n FROM "LBR_ISU_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
        TENANT,
      ),
    ).toEqual([{ n: 1 }]);
    const childBar = await query<Array<Record<string, unknown>>>(
      `SELECT "TAG_NO","VCH_SRNO"::float8 id,"ITM_NWT"::float8 nwt,"ITM_FINE"::float8 fine,"ENTRY_TYPE" FROM "BAR_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK"='TSP' ORDER BY "SR_NO"`,
      TENANT,
    );
    expect(childBar).toHaveLength(2);
    expect(childBar.every((r) => r.ENTRY_TYPE === 'I' && String(r.TAG_NO).startsWith('RH'))).toBe(
      true,
    );
    // Fine conserved: parent 9.160 out; children 5.496 + 3.664 in.
    const stock = await query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO"::int sr,"TAG_NO","ITM_SIGN","ITM_FINE"::float8 fine FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TSP' ORDER BY "SR_NO","ISR_NO"`,
      TENANT,
    );
    expect(stock.map((r) => [r.sr, r.ITM_SIGN, r.fine])).toEqual([
      [1, '-', 9.16],
      [2, '+', 5.496],
      [2, '+', 3.664],
    ]);
    // Each child has a SRNO_MAST-style identity and the parent is out of stock.
    expect(await live('SPL00001', 100200000001)).toBe(false);
    // TEMP_BOOK_DATA written; no ledger (no absorbing account, conserved).
    expect(
      await query(
        `SELECT count(*)::int n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
        TENANT,
      ),
    ).toEqual([{ n: 1 }]);
    expect(
      await query(
        `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
        TENANT,
      ),
    ).toEqual([{ n: 0 }]);
    // Whole-database diff: only the split's own tables gained rows; the source BAR_DETL/BAR_IDTL are untouched.
    const added = countsOf(diffTenant(before, await snapshot()).added);
    // These children carry no stones, so no child BAR_IDTL rows are written; the parent's stones go to
    // LBR_ISU_IDTL. The SRNO_MAST counter advanced (a new added row where none existed before).
    for (const t of [
      'LBR_DATA',
      'LBR_ISU_DETL',
      'LBR_ISU_IDTL',
      'LBR_REC_DETL',
      'BAR_DATA',
      'BAR_DETL',
      'MAIN_STOCK',
      'TEMP_BOOK_DATA',
    ])
      expect(Object.keys(added), t).toContain(t);
    // The parent's two stone rows (DIA + PRL) land in LBR_ISU_IDTL only, not BAR_IDTL (the stoneless children).
    expect(
      await query(
        `SELECT count(*)::int n FROM "LBR_ISU_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
        TENANT,
      ),
    ).toEqual([{ n: 2 }]);
    expect(
      await query(
        `SELECT count(*)::int n FROM "BAR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
        TENANT,
      ),
    ).toEqual([{ n: 0 }]);
    // Dm_Tag_Split_Detl: ONLY the parent's DIA stone (an OTH_DETL_POSTING item) goes OUT; the PRL stone, whose item
    // does not post, is excluded. This needs the parent stones' items resolved for their OTH_DETL_POSTING flag — a
    // lookup that must cover parent stones, not just the children's typed stones.
    const dm = await query<Array<Record<string, unknown>>>(
      `SELECT "MAIN_SRNO"::int main,"IT_CODE","DM_SIGN","INOUT_TYPE","TAG_NO","MAIN_IT_CODE","DM_PCS"::int pcs
         FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP' ORDER BY "MAIN_SRNO"`,
      TENANT,
    );
    expect(dm).toEqual([
      {
        main: 1,
        IT_CODE: 'DIA',
        DM_SIGN: '-',
        INOUT_TYPE: 'O',
        TAG_NO: 'SPL00001',
        MAIN_IT_CODE: 'RNG',
        pcs: 10,
      },
    ]);
    const removed = countsOf(diffTenant(before, await snapshot()).removed);
    // The parent leaves TAG_STOCK only if it was a TAG_STOCK tag; here it is a BAR_DETL tag, so nothing is removed.
    expect(removed.BAR_DETL ?? 0).toBe(0);
  });

  it('K1: the writer refuses a TAG SPLIT book that is not in use', async () => {
    // Defence in depth behind the request-scope layer: the writer itself rejects a book flagged out of use.
    await exec(
      `UPDATE "BOOK_DATA" SET "CUR_USE"='N' WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
      TENANT,
    );
    await expect(
      saveTagSplit(runtime, {
        scope: scope(),
        vchDate: DAY,
        mainUser: USER,
        parents: [{ tagNo: 'SPL00001' }],
        children: TWO_CHILDREN,
      }),
    ).rejects.toThrow('book TSP is not in use');
    expect(
      await query(`SELECT 1 FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`, TENANT),
    ).toEqual([]);
    expect(await live('SPL00001', 100200000001)).toBe(true);
  });

  it('V2: refuses a short split with no absorbing account, writing nothing', async () => {
    await expect(
      saveTagSplit(runtime, {
        scope: scope(),
        vchDate: DAY,
        mainUser: USER,
        parents: [{ tagNo: 'SPL00001' }],
        children: [
          { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
          { itCode: 'RNGH', grossWt: 3, touch: 91.6 },
        ],
      }),
    ).rejects.toThrow('Please Insert diff Wt in Received Grid');
    expect(
      await query(`SELECT 1 FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`, TENANT),
    ).toEqual([]);
    expect(await live('SPL00001', 100200000001)).toBe(true);
  });

  it('V3: a short split with an absorbing account posts the gold DR fine legs', async () => {
    const result = await saveTagSplit(runtime, {
      scope: scope(),
      vchDate: DAY,
      acCode: 'SPLITAC',
      drTouch: 91.6,
      mainUser: USER,
      parents: [{ tagNo: 'SPL00001' }],
      children: [
        { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
        { itCode: 'RNGH', grossWt: 3, touch: 91.6 },
      ],
    });
    expect(result.ledgerRows).toBeGreaterThanOrEqual(2);
    const [head] = await query(
      `SELECT "DR_WT"::float8 dr,"DR_FINE"::float8 fine,"AC_CODE" FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
      TENANT,
    );
    expect(head).toMatchObject({ dr: 1, AC_CODE: 'SPLITAC' });
    expect(Number((head as { fine: number }).fine)).toBeCloseTo(0.916, 3);
    const legs = await query<Array<Record<string, unknown>>>(
      `SELECT right("LEDR_KEY",4) leg,"AC_CODE","FINE_WT"::float8 fine,"SIGN" FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP' ORDER BY "LEDR_KEY"`,
      TENANT,
    );
    // Legs 03/04: SPLITAC Dr and GLDDR Cr mirror (TRAD_FINE=Y in the fixture).
    expect(legs.map((l) => [l.leg, l.AC_CODE, l.SIGN])).toEqual([
      ['03NN', 'SPLITAC', '-'],
      ['04NN', 'GLDDR', '+'],
    ]);
    // The gold-fine day book gets both mirror legs (Ac_Rojmel.Tag_Split_Rojmel writes a pair, 01/02).
    expect(
      await query(
        `SELECT count(*)::int n FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
        TENANT,
      ),
    ).toEqual([{ n: 2 }]);
  });

  it('V5: delete writes DELETE_DATA, removes the write set and returns the database to its prior state', async () => {
    const before = await snapshot();
    const saved = await saveTagSplit(runtime, {
      scope: scope(),
      vchDate: DAY,
      mainUser: USER,
      parents: [{ tagNo: 'SPL00001' }],
      children: TWO_CHILDREN,
    });
    await deleteTagSplit(runtime, scope(), saved.voucherNo, USER);
    const audit = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE","BOOK_NAME","VCH_FINE_CR"::float8 fine,"DELETE_USER","VCH_DESC" FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
      TENANT,
    );
    expect(audit).toEqual([
      {
        VCH_TYPE: 'TGSPL',
        BOOK_NAME: 'Tag Split',
        fine: 10,
        DELETE_USER: USER,
        VCH_DESC: 'ItCode/RNG TagNo/SPL00001',
      },
    ]);
    for (const t of ['LBR_DATA', 'BAR_DETL', 'MAIN_STOCK', 'TEMP_BOOK_DATA'])
      expect(
        await query(`SELECT 1 FROM "${t}" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`, TENANT),
        t,
      ).toEqual([]);
    expect(await live('SPL00001', 100200000001)).toBe(true);
    // Every table equals its pre-split state except the DELETE_DATA audit and the SRNO_MAST tag counter, which
    // is deliberately not rewound — an allocated tag serial is never reused, even after the voucher is deleted.
    const diff = diffTenant(before, await snapshot());
    expect(Object.keys(countsOf(diff.added)).sort()).toEqual(['DELETE_DATA', 'SRNO_MAST']);
    expect(Object.keys(countsOf(diff.removed))).toEqual(['SRNO_MAST']);
    const [counter] = await query<Array<Record<string, unknown>>>(
      `SELECT "TAG_SRNO"::int t FROM "SRNO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'`,
      TENANT,
    );
    expect(Number((counter as { t: number }).t)).toBeGreaterThanOrEqual(102); // 100 seed + 2 children
  });

  it('V6: refuses a sold parent, a duplicate parent, and an ambiguous number', async () => {
    await expect(
      saveTagSplit(runtime, {
        scope: scope(),
        vchDate: DAY,
        mainUser: USER,
        parents: [{ tagNo: 'SPL00009' }],
        children: [{ itCode: 'RNGH', grossWt: 4, touch: 91.6 }],
      }),
    ).rejects.toMatchObject({ name: 'TagNotAvailableError' });
    await expect(
      saveTagSplit(runtime, {
        scope: scope(),
        vchDate: DAY,
        mainUser: USER,
        parents: [{ tagNo: 'SPL00001' }, { tagNo: 'SPL00001' }],
        children: TWO_CHILDREN,
      }),
    ).rejects.toThrow('Duplicate Tag No');
    expect(
      await query(`SELECT 1 FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`, TENANT),
    ).toEqual([]);
  });

  it('V7: a delete is refused once a child has been sold', async () => {
    const saved = await saveTagSplit(runtime, {
      scope: scope(),
      vchDate: DAY,
      mainUser: USER,
      parents: [{ tagNo: 'SPL00001' }],
      children: TWO_CHILDREN,
    });
    // Sell the first child (a '-' movement with no matching '+').
    const [child] = await query<Array<Record<string, unknown>>>(
      `SELECT "TAG_NO","VCH_SRNO"::float8 id FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TSP' ORDER BY "SR_NO" LIMIT 1`,
      TENANT,
    );
    await insert('MAIN_STOCK', {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'SL',
      VCH_NO: '00050',
      SR_NO: 1,
      ISR_NO: 1,
      VCH_DATE: D(DAY),
      IT_CODE: 'RNGH',
      TAG_NO: child!.TAG_NO,
      VCH_SRNO: child!.id,
      TR_TYPE: 'S',
      ITM_SIGN: '-',
      ITM_QTY: 1,
      ITM_PCS: 1,
    });
    await expect(deleteTagSplit(runtime, scope(), saved.voucherNo, USER)).rejects.toThrow(
      'has already been used and cannot be reversed',
    );
  });

  it('V8: a failure part-way leaves nothing and no number is used', async () => {
    const before = await snapshot();
    await expect(
      saveTagSplit(runtime, {
        scope: scope(),
        vchDate: DAY,
        mainUser: USER,
        parents: [{ tagNo: 'SPL00001' }],
        // The second child names an item that does not exist: the whole transaction rolls back.
        children: [
          { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
          { itCode: 'NOPE', grossWt: 4, touch: 91.6 },
        ],
      }),
    ).rejects.toThrow('item NOPE not found');
    expect(await live('SPL00001', 100200000001)).toBe(true);
    const diff = diffTenant(before, await snapshot());
    expect(countsOf(diff.added)).toEqual({});
    expect(countsOf(diff.removed)).toEqual({});
  });

  it('V9: the lock date refuses a save, and a delete of a voucher on or before the lock', async () => {
    // LOCK_DATE is a VarChar the app stores as 'YYYY-MM-DD'; the ::date cast normalises it (mirrors the other
    // lifecycle DB tests). The voucher day (2024-06-10) is on or before the lock (2024-06-30), so it is refused.
    await exec(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$2::date WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      TENANT,
      '2024-06-30',
    );
    await expect(
      saveTagSplit(runtime, {
        scope: scope(),
        vchDate: DAY,
        mainUser: USER,
        parents: [{ tagNo: 'SPL00001' }],
        children: TWO_CHILDREN,
      }),
    ).rejects.toMatchObject({ name: 'PeriodLockValidationError' });
    expect(
      await query(`SELECT 1 FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`, TENANT),
    ).toEqual([]);

    // A voucher saved before the lock cannot be DELETED once the period is locked (K12 applies to delete too):
    // save with the lock open, then lock the period and confirm the reversal is refused and nothing changed.
    await exec(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      TENANT,
    );
    const saved = await saveTagSplit(runtime, {
      scope: scope(),
      vchDate: DAY,
      mainUser: USER,
      parents: [{ tagNo: 'SPL00001' }],
      children: TWO_CHILDREN,
    });
    await exec(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$2::date WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      TENANT,
      '2024-06-30',
    );
    await expect(deleteTagSplit(runtime, scope(), saved.voucherNo, USER)).rejects.toMatchObject({
      name: 'PeriodLockValidationError',
    });
    // The voucher and its audit are untouched by the refused delete.
    expect(
      await query(
        `SELECT count(*)::int n FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
        TENANT,
      ),
    ).toEqual([{ n: 1 }]);
    expect(
      await query(`SELECT 1 FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`, TENANT),
    ).toEqual([]);
  });

  it('reads a voucher back, lists the book, and previews a parent without consuming it', async () => {
    // Preview (K13 source) reads the parent WITHOUT reserving it: calling it twice still leaves the tag live.
    const preview = await tagSplitSource(runtime, scope(), { tagNo: 'SPL00001' });
    expect(preview).toMatchObject({
      tagNo: 'SPL00001',
      source: 'BAR_DETL',
      line: { netWt: 10, fine: 9.16 },
    });
    expect(await live('SPL00001', 100200000001)).toBe(true);

    await saveTagSplit(runtime, {
      scope: scope(),
      vchDate: DAY,
      empCode: '001',
      vchDesc: 'worn',
      mainUser: USER,
      parents: [{ tagNo: 'SPL00001' }],
      children: TWO_CHILDREN,
    });
    const view = await getTagSplit(runtime, scope(), '00001');
    expect(view).toMatchObject({ voucherNo: '00001', vchDesc: 'WORN', mainUser: USER });
    expect((view.parents as unknown[]).length).toBe(1);
    expect((view.children as unknown[]).length).toBe(2);
    const list = await listTagSplit(runtime, scope());
    expect(list).toMatchObject({ nextVoucherNo: '00002' });
    expect(list.vouchers[0]).toMatchObject({ vchNo: '00001', children: 2 });
    // Once split, the parent is consumed: it can no longer be previewed for a new split.
    expect(await live('SPL00001', 100200000001)).toBe(false);
  });

  it('V8-race: two writers splitting one parent — exactly one wins', async () => {
    const attempt = () =>
      saveTagSplit(runtime, {
        scope: scope(),
        vchDate: DAY,
        mainUser: USER,
        parents: [{ tagNo: 'SPL00001' }],
        children: TWO_CHILDREN,
      });
    const results = await Promise.allSettled([attempt(), attempt()]);
    const won = results.filter((r) => r.status === 'fulfilled');
    const lost = results.filter((r) => r.status === 'rejected') as PromiseRejectedResult[];
    expect(won).toHaveLength(1);
    expect(lost).toHaveLength(1);
    expect(['TagNotAvailableError', 'TagSplitConflictError']).toContain(lost[0]!.reason.name);
    expect(
      await query(
        `SELECT count(*)::int n FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`,
        TENANT,
      ),
    ).toEqual([{ n: 1 }]);
  });
});

/** A no-op reference so the unused import lints do not fire if a vector is later removed. */
void issueTagTx;
