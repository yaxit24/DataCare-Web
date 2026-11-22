import { afterAll, afterEach, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { tagStockReport } from '../src/modules/reports/tagStock.js';

/**
 * WP-15 Tag Stock (desktop RP_TAG, RP_TAG.cs:3977-4325): the per-mode selections, the stock state and the totals.
 *
 * Every expected value below is computed from the seeded movements with the desktop rule, never read back from the
 * report: a tag instance (company, location, tag no, tag id, item) is in stock when
 * `sum(+id for '+', -id for '-') > 0` over its movements of the session year dated up to `To`
 * (RP_TAG.cs:4187 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}). `inStockOracle`
 * below is that rule applied to the seed arrays; the cases of orchestration/work/WP-15/cases.md quote the same
 * sums by hand and the arithmetic is repeated next to each assertion.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

const TENANT = 'tag-stock-db';
const OTHER_TENANT = 'tag-stock-oth';
const CO = '01';
const LC = '01';
const YEAR = '2026-27';
const SYS = '2026-05-31';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });

interface TagSeed {
  tag: string;
  id: number;
  it: string;
  pcs: number;
  gwt: number;
  nwt: number;
  mrp: number;
  cost: number;
  lbr: number;
  oth: number;
  size: string;
  ctr: string;
  stk: string;
  design?: string;
}
interface MoveSeed {
  tag: string;
  sign: '+' | '-';
  date: string;
  type: string;
  book: string;
  vchNo: string;
  bookName?: string;
}

const T = (
  tag: string,
  id: number,
  it: string,
  pcs: number,
  gwt: number,
  nwt: number,
  mrp: number,
  cost: number,
  lbr: number,
  oth: number,
  size: string,
  ctr: string,
  stk: string,
  design = 'D' + tag.slice(-1),
): TagSeed => ({ tag, id, it, pcs, gwt, nwt, mrp, cost, lbr, oth, size, ctr, stk, design });

/** Seed B: the seven tags of cases.md (id = VCH_SRNO). */
const TAGS: TagSeed[] = [
  T('A001', 101, 'GR', 1, 5, 4.8, 30000, 25000, 500, 100, '7', 'C1', '2026-04-05'),
  T('A002', 102, 'GR', 2, 3, 2.9, 20000, 16000, 300, 50, '8', 'C1', '2026-04-10'),
  T('A003', 103, 'GR', 1, 4, 3.8, 25000, 20000, 400, 80, '7', 'C1', '2026-04-05'),
  T('A004', 104, 'GR', 1, 1, 0.95, 8000, 6000, 100, 10, '7', 'C1', '2026-04-05'),
  T('A005', 105, 'GR', 1, 2, 1.9, 12000, 9000, 200, 20, '7', 'C1', '2026-04-05'),
  T('A006', 106, 'GR', 1, 6, 5.8, 40000, 33000, 600, 120, '7', 'C1', '2026-04-05'),
  T('A007', 107, 'SC', 1, 10, 10, 0, 4000, 100, 0, '18', 'C2', '2026-04-05'),
];
const opening = (t: TagSeed): MoveSeed => ({
  tag: t.tag,
  sign: '+',
  date: t.stk,
  type: 'TO',
  book: 'TOP',
  vchNo: '00' + t.id,
});
const MOVES: MoveSeed[] = [
  ...TAGS.map(opening),
  { tag: 'A003', sign: '-', date: '2026-04-20', type: 'SL', book: 'SAL', vchNo: '0001' },
  { tag: 'A005', sign: '-', date: '2026-04-20', type: 'SL', book: 'SAL', vchNo: '0002' },
  { tag: 'A004', sign: '-', date: '2026-04-25', type: 'TC', book: 'TGC', vchNo: '0001' },
  { tag: 'A005', sign: '+', date: '2026-05-10', type: 'SR', book: 'SRT', vchNo: '0001' },
  {
    tag: 'A006',
    sign: '-',
    date: '2026-05-15',
    type: 'AI',
    book: 'AIS',
    vchNo: '0001',
    bookName: 'APR ISU',
  },
];

/** The desktop stock rule applied to the seed arrays (the oracle for every stock-state expectation). */
function inStockOracle(asOf: string, tags = TAGS, moves = MOVES): string[] {
  return tags
    .filter((t) => {
      const sum = moves
        .filter((m) => m.tag === t.tag && m.date <= asOf)
        .reduce((a, m) => a + (m.sign === '+' ? t.id : -t.id), 0);
      return sum > 0;
    })
    .map((t) => t.tag)
    .sort();
}
const sum = (rows: any[], k: string) => rows.reduce((a, r) => a + Number(r[k] ?? 0), 0);
const near = (a: number, b: number, digits = 6) =>
  expect(Math.abs(a - b)).toBeLessThan(10 ** -digits);

const scope = { CO_CODE: CO, LC_CODE: LC, CO_YEAR: YEAR };
const run = (
  tab: string,
  f: Record<string, unknown> = {},
  s: Record<string, unknown> = scope,
): Promise<any> =>
  tagStockReport(
    runtime,
    TENANT,
    s as any,
    tab as any,
    { toDate: SYS, sysDate: SYS, ...f } as any,
  ) as Promise<any>;
const tagsOf = (rep: any) => rep.rows.map((r: any) => r.tagNo);

async function ins(tenant: string, table: string, row: Record<string, unknown>): Promise<void> {
  const cols = Object.keys(row);
  const sql = `INSERT INTO "${table}"(tenant_id,${cols.map((c) => `"${c}"`).join(',')})
               VALUES ($1,${cols.map((_, i) => `$${i + 2}`).join(',')})`;
  await withTenant(owner, tenant, (tx: any) =>
    tx.$executeRawUnsafe(
      sql,
      tenant,
      ...cols.map((c) => {
        const v = row[c];
        return v;
      }),
    ),
  );
}
const iso = (s: string) => new Date(s + 'T00:00:00Z');

interface Where {
  tenant?: string;
  co?: string;
  lc?: string;
  year?: string;
  dataType?: string;
}
async function seedTag(t: TagSeed, w: Where = {}, extra: Record<string, unknown> = {}) {
  const tenant = w.tenant ?? TENANT;
  await ins(tenant, 'BAR_DETL', {
    CO_CODE: w.co ?? CO,
    LC_CODE: w.lc ?? LC,
    CO_YEAR: w.year ?? YEAR,
    CO_BOOK: 'TOP',
    VCH_NO: '00' + t.id,
    VCH_DATE: iso(t.stk),
    STK_DATE: t.stk,
    VCH_TYPE: 'TO',
    BOOK_NAME: 'TAG OPENING',
    AC_CODE: 'OPN',
    IT_CODE: t.it,
    TAG_NO: t.tag,
    DESIGN_NO: t.design,
    TBL_CODE: t.ctr,
    ITM_SIZE: t.size,
    ITM_PCS: t.pcs,
    ITM_GWT: t.gwt,
    ITM_NWT: t.nwt,
    ITM_FINE: t.nwt * 0.9,
    LBR_RATE: 10,
    LBR_PRC: 2,
    LBR_AMT: t.lbr,
    OTH_AMT: t.oth,
    KR_COST: t.cost,
    ITM_MRP: t.mrp,
    KR_NAME: 'K1',
    ITM_STYLE: 'S1',
    ITM_REMARK: 'r-' + t.tag,
    VCH_SRNO: t.id,
    DATA_TYPE: w.dataType ?? 'A',
    ...extra,
  });
}
async function seedMove(
  t: TagSeed,
  m: MoveSeed,
  w: Where = {},
  extra: Record<string, unknown> = {},
) {
  await ins(w.tenant ?? TENANT, 'MAIN_STOCK', {
    CO_CODE: w.co ?? CO,
    LC_CODE: w.lc ?? LC,
    CO_YEAR: w.year ?? YEAR,
    CO_BOOK: m.book,
    VCH_NO: m.vchNo,
    VCH_DATE: iso(m.date),
    STK_DATE: t.stk,
    VCH_TYPE: m.type,
    BOOK_NAME: m.bookName ?? m.book,
    AC_CODE: 'P001',
    IT_CODE: t.it,
    TAG_NO: t.tag,
    TBL_CODE: t.ctr,
    ITM_SIGN: m.sign,
    ITM_PCS: t.pcs,
    ITM_GWT: t.gwt,
    ITM_NWT: t.nwt,
    LBR_RATE: 10,
    LBR_AMT: t.lbr,
    OTH_AMT: t.oth,
    ITM_MRP: t.mrp,
    DESIGN_NO: t.design,
    ITM_SIZE: t.size,
    VCH_SRNO: t.id,
    DATA_TYPE: w.dataType ?? 'A',
    ...extra,
  });
}
async function seedWith(
  t: TagSeed,
  moves: Array<Omit<MoveSeed, 'tag'>>,
  w: Where = {},
  tagExtra = {},
) {
  await seedTag(t, w, tagExtra);
  for (const m of moves) await seedMove(t, { ...m, tag: t.tag }, w);
}
const open = (t: TagSeed): Omit<MoveSeed, 'tag'> => {
  const { tag: _tag, ...rest } = opening(t);
  return rest;
};

const TABLES = ['MAIN_STOCK', 'BAR_DETL', 'APR_DETL', 'BAR_IDTL'];
let marks: Record<string, Record<string, bigint>> = {};
async function snapshotMarks(): Promise<void> {
  marks = {};
  for (const tenant of [TENANT, OTHER_TENANT]) {
    marks[tenant] = {};
    for (const t of TABLES) {
      const r: any[] = await withTenant(owner, tenant, (tx: any) =>
        tx.$queryRawUnsafe(`SELECT coalesce(max(row_id),0)::bigint m FROM "${t}"`),
      );
      marks[tenant]![t] = BigInt(r[0].m);
    }
  }
}
async function rollbackToMarks(): Promise<void> {
  for (const tenant of [TENANT, OTHER_TENANT])
    for (const t of TABLES)
      await withTenant(owner, tenant, (tx: any) =>
        tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE row_id > $1`, marks[tenant]![t]),
      );
}

async function cleanAll(): Promise<void> {
  for (const tenant of [TENANT, OTHER_TENANT]) {
    for (const t of [...TABLES, 'ITEM_MAST', 'PRODUCT_MAST', 'AC_MAST', 'EMP_MAST'])
      await withTenant(owner, tenant, (tx: any) =>
        tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenant),
      );
  }
}

d('Tag Stock report (RP_TAG) selections, stock state and totals', () => {
  beforeAll(async () => {
    await cleanAll();
    await ins(TENANT, 'ITEM_MAST', {
      CO_CODE: CO,
      IT_CODE: 'GR',
      IT_NAME: 'Gold Ring',
      IT_TYPE: 'G',
      PR_CODE: 'P1',
      GR_CODE: 'G1',
      SAFE_NAME: 'GRSAFE',
    });
    await ins(TENANT, 'ITEM_MAST', {
      CO_CODE: CO,
      IT_CODE: 'SC',
      IT_NAME: 'Silver Chain',
      IT_TYPE: 'S',
      PR_CODE: 'P2',
      GR_CODE: 'G2',
      SAFE_NAME: 'SCSAFE',
    });
    await ins(TENANT, 'PRODUCT_MAST', { CO_CODE: CO, PR_CODE: 'P1', PR_NAME: 'Rings' });
    await ins(TENANT, 'PRODUCT_MAST', { CO_CODE: CO, PR_CODE: 'P2', PR_NAME: 'Chains' });
    await ins(TENANT, 'AC_MAST', { CO_CODE: CO, AC_CODE: 'P001', AC_NAME: 'Approval Party' });
    await ins(TENANT, 'EMP_MAST', { CO_CODE: CO, EMP_CODE: 'E01', EMP_NAME: 'Tour Employee' });
    for (const t of TAGS) await seedTag(t);
    for (const m of MOVES)
      await seedMove(
        TAGS.find((t) => t.tag === m.tag)!,
        m,
      );
    // The pending approval of A006: APR_DETL carries its own (different) weights and MRP 0 on purpose, so a
    // report that reads APR_DETL instead of the joined BAR_DETL instance fails on every figure.
    await ins(TENANT, 'APR_DETL', {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'AIS',
      VCH_NO: '0001',
      VCH_DATE: iso('2026-05-15'),
      VCH_TYPE: 'AI',
      BOOK_NAME: 'APR ISU',
      AC_CODE: 'P001',
      IT_CODE: 'GR',
      TAG_NO: 'A006',
      VCH_SRNO: 106,
      ISU_REC: 'N',
      ITM_PCS: 9,
      ITM_GWT: 9.999,
      ITM_NWT: 9.5,
      ITM_MRP: 0,
    });
  });
  beforeEach(snapshotMarks);
  afterEach(rollbackToMarks);
  afterAll(async () => {
    await cleanAll();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  // ---------------------------------------------------------------- stock state (decision 2)
  it('Stock: cancelled, sold, returned-sale and approval-pending tags follow the signed sum', async () => {
    // A004 +104 -104 = 0 (cancel 25/04); A003 +103 -103 = 0; A005 +105 -105 +105 = 105; A006 +106 -106 = 0.
    expect(tagsOf(await run('stock', { toDate: '2026-05-31' }))).toEqual([
      'A001',
      'A002',
      'A005',
      'A007',
    ]);
    expect(inStockOracle('2026-05-31')).toEqual(['A001', 'A002', 'A005', 'A007']);
    // To 19/04: the sales (20/04), the cancel (25/04) and the approval (15/05) are not yet dated: all seven tags +id.
    expect(tagsOf(await run('stock', { toDate: '2026-04-19' }))).toEqual(
      inStockOracle('2026-04-19'),
    );
    expect(inStockOracle('2026-04-19')).toEqual([
      'A001',
      'A002',
      'A003',
      'A004',
      'A005',
      'A006',
      'A007',
    ]);
    // To 30/04: A003 0, A004 0, A005 0 (+105 -105), A006 +106 -> present.
    expect(tagsOf(await run('stock', { toDate: '2026-04-30' }))).toEqual([
      'A001',
      'A002',
      'A006',
      'A007',
    ]);
    expect(inStockOracle('2026-04-30')).toEqual(['A001', 'A002', 'A006', 'A007']);
    // To 14/05: still +106 for A006.
    expect(tagsOf(await run('stock', { toDate: '2026-05-14' }))).toEqual(
      inStockOracle('2026-05-14'),
    );
  });

  it('Stock ignores From and balances by the signed id, one row per tag instance', async () => {
    const a = await run('stock', { fromDate: '2026-05-01' });
    const b = await run('stock', { fromDate: '2020-01-01' });
    expect(tagsOf(a)).toEqual(tagsOf(b));
    expect(tagsOf(a)).toEqual(['A001', 'A002', 'A005', 'A007']);
    // A005 appears once (not three times), Qty 1.
    expect(a.rows.filter((r: any) => r.tagNo === 'A005')).toHaveLength(1);
  });

  it('Stock totals (every column) equal the hand sums of the four tags', async () => {
    const rep = await run('stock');
    // A001, A002, A005, A007.
    expect(rep.totals).toMatchObject({
      qty: 4,
      pcs: 1 + 2 + 1 + 1,
      grossWt: 5 + 3 + 2 + 10,
      mrp: 30000 + 20000 + 12000 + 0,
      prCost: 25000 + 16000 + 9000 + 4000,
      lbrAmt: 500 + 300 + 200 + 100,
      othAmt: 100 + 50 + 20 + 0,
    });
    near(rep.totals.netWt, 4.8 + 2.9 + 1.9 + 10);
    const a1 = rep.rows.find((r: any) => r.tagNo === 'A001');
    expect(a1).toMatchObject({
      tagId: 101,
      itCode: 'GR',
      counter: 'C1',
      size: '7',
      qty: 1,
      safeName: 'GRSAFE',
    });
    // Day = system date 31/05 minus stock date 05/04 = 56 (cases.md total.day-column).
    expect(a1.day).toBe(56);
    expect(rep.rows.find((r: any) => r.tagNo === 'A002').day).toBe(51);
  });

  it('a sale against an approval (sale -id plus compensating +id) leaves the tag out once', async () => {
    const aa1 = T('AA1', 201, 'GR', 1, 1, 1, 100, 80, 5, 1, '7', 'C1', '2026-04-05');
    await seedWith(aa1, [
      open(aa1),
      {
        sign: '-',
        date: '2026-05-01',
        type: 'AI',
        book: 'AIS',
        vchNo: '0009',
        bookName: 'APR ISU',
      },
      { sign: '-', date: '2026-05-02', type: 'SL', book: 'SAL', vchNo: '0009' },
      { sign: '+', date: '2026-05-02', type: 'SL', book: 'SAL', vchNo: '0009' },
    ]);
    // +201 -201 -201 +201 = 0: absent.
    expect(tagsOf(await run('stock'))).not.toContain('AA1');
  });

  it('zero id, missing BAR_DETL and an item mismatch never appear in Stock', async () => {
    const az0 = T('AZ0', 0, 'GR', 1, 1, 1, 100, 80, 5, 1, '7', 'C1', '2026-04-05');
    await seedWith(az0, [open(az0)]);
    // A movement with no BAR_DETL row.
    await seedMove(T('AM1', 301, 'GR', 1, 1, 1, 1, 1, 1, 1, '7', 'C1', '2026-04-05'), {
      tag: 'AM1',
      sign: '+',
      date: '2026-04-05',
      type: 'TO',
      book: 'TOP',
      vchNo: '00301',
    });
    // MAIN_STOCK item differs from the BAR_DETL item.
    const ai1 = T('AI1', 302, 'GR', 1, 1, 1, 1, 1, 1, 1, '7', 'C1', '2026-04-05');
    await seedTag(ai1);
    await seedMove({ ...ai1, it: 'SC' }, { ...open(ai1), tag: 'AI1' });
    const tags = tagsOf(await run('stock'));
    for (const t of ['AZ0', 'AM1', 'AI1']) expect(tags).not.toContain(t);
  });

  it('two instances of one tag number are separate rows keyed by (TagNo, TagId)', async () => {
    const a = T('A100', 301, 'GR', 1, 1, 1, 100, 80, 5, 1, '7', 'C1', '2026-04-05');
    const b = T('A100', 302, 'GR', 1, 1, 1, 100, 80, 5, 1, '7', 'C1', '2026-04-05');
    await seedWith(a, [
      open(a),
      { sign: '-', date: '2026-04-20', type: 'SL', book: 'SAL', vchNo: '0020' },
    ]);
    await seedWith(b, [open(b)]);
    const rows = (await run('stock')).rows.filter((r: any) => r.tagNo === 'A100');
    expect(rows.map((r: any) => r.tagId)).toEqual([302]);
  });

  // ---------------------------------------------------------------- In (BAR_DETL creation rows)
  it('In reads the BAR_DETL creation rows of the date range, not every positive movement', async () => {
    const first = await run('in', { fromDate: '2026-04-01', toDate: '2026-04-07' });
    expect(tagsOf(first)).toEqual(['A001', 'A003', 'A004', 'A005', 'A006', 'A007']);
    const second = await run('in', { fromDate: '2026-04-08', toDate: '2026-04-30' });
    expect(tagsOf(second)).toEqual(['A002']);
    // The return of A005 (+ movement on 10/05) is not an In row.
    const may = await run('in', { fromDate: '2026-05-01', toDate: '2026-05-31' });
    expect(may.rows).toHaveLength(0);
    // Totals of the first range (cases.md total.in-mode).
    expect(first.totals).toMatchObject({
      qty: 6,
      pcs: 6,
      grossWt: 5 + 4 + 1 + 2 + 6 + 10,
      mrp: 30000 + 25000 + 8000 + 12000 + 40000 + 0,
      prCost: 25000 + 20000 + 6000 + 9000 + 33000 + 4000,
      lbrAmt: 500 + 400 + 100 + 200 + 600 + 100,
      othAmt: 100 + 80 + 10 + 20 + 120 + 0,
    });
    near(first.totals.netWt, 4.8 + 3.8 + 0.95 + 1.9 + 5.8 + 10);
    // From > To: no rows, no error.
    expect((await run('in', { fromDate: '2026-06-01', toDate: '2026-05-31' })).rows).toHaveLength(
      0,
    );
  });

  it('In with a Book filter applies the intended book (deliberate difference from the RP_TAG.cs:4013 alias defect)', async () => {
    const top = await run('in', { fromDate: '2026-04-01', toDate: '2026-04-07', bookCode: 'TOP' });
    expect(tagsOf(top)).toEqual(['A001', 'A003', 'A004', 'A005', 'A006', 'A007']);
    const none = await run('in', { fromDate: '2026-04-01', toDate: '2026-04-07', bookCode: 'ZZZ' });
    expect(none.rows).toHaveLength(0);
  });

  // ---------------------------------------------------------------- Out (negative movements)
  it('Out lists the negative movements of the date range sorted by voucher type then number', async () => {
    const all = await run('out', { fromDate: '2026-04-01', toDate: '2026-05-31' });
    const expected = MOVES.filter((m) => m.sign === '-')
      .map((m) => ({ ...m, k: m.type + '|' + m.vchNo }))
      .sort((a, b) => (a.k < b.k ? -1 : 1))
      .map((m) => m.tag + '@' + m.type + m.vchNo);
    expect(all.rows.map((r: any) => r.tagNo + '@' + r.vchType + r.vchNo)).toEqual(expected);
    expect(all.totals).toMatchObject({
      qty: 4,
      pcs: 4,
      grossWt: 4 + 2 + 1 + 6,
      mrp: 25000 + 12000 + 8000 + 40000,
      lbrAmt: 400 + 200 + 100 + 600,
      othAmt: 80 + 20 + 10 + 120,
    });
    near(all.totals.netWt, 3.8 + 1.9 + 0.95 + 5.8);
    const april = await run('out', { fromDate: '2026-04-01', toDate: '2026-04-30' });
    expect(tagsOf(april).sort()).toEqual(['A003', 'A004', 'A005']);
    const may = await run('out', { fromDate: '2026-05-01', toDate: '2026-05-31' });
    expect(tagsOf(may)).toEqual(['A006']);
    // Day = movement date minus stock date: sale of A003 20/04 - 05/04 = 15; cancel of A004 25/04 - 05/04 = 20.
    expect(all.rows.find((r: any) => r.tagNo === 'A003').day).toBe(15);
    expect(all.rows.find((r: any) => r.tagNo === 'A004').day).toBe(20);
    // Book filter names the movement book.
    const sale = await run('out', {
      fromDate: '2026-04-01',
      toDate: '2026-05-31',
      bookCode: 'SAL',
    });
    expect(tagsOf(sale)).toEqual(['A003', 'A005']);
  });

  // ---------------------------------------------------------------- All (signed movement history)
  it('All is the movement history with signs, ordered by date then tag', async () => {
    const rep = await run('all', { fromDate: '2026-04-01', toDate: '2026-05-31' });
    expect(rep.rows).toHaveLength(MOVES.length);
    expect(rep.rows).toHaveLength(12);
    const expectedOrder = [...MOVES]
      .sort((a, b) =>
        a.date + a.tag < b.date + b.tag ? -1 : a.date + a.tag > b.date + b.tag ? 1 : 0,
      )
      .map((m) => m.date + m.tag + m.sign);
    expect(rep.rows.map((r: any) => r.vchDate + r.tagNo + r.sign)).toEqual(expectedOrder);
    // cases.md total.all-mode: 12 movements; Pcs 13; Grwt 46; Mrp 232000; LbrAmt 3700; OthAmt 630.
    expect(rep.totals).toMatchObject({
      qty: 12,
      pcs: 13,
      grossWt: 46,
      mrp: 232000,
      lbrAmt: 3700,
      othAmt: 630,
    });
    near(rep.totals.netWt, 44.5);
    expect(rep.rows.filter((r: any) => r.tagNo === 'A005').map((r: any) => r.sign)).toEqual([
      '+',
      '-',
      '+',
    ]);
  });

  it('All with a TagNo ignores the date range', async () => {
    const may = await run('all', { fromDate: '2026-05-01', toDate: '2026-05-31' });
    expect(may.rows.map((r: any) => r.tagNo + r.sign)).toEqual(['A005+', 'A006-']);
    const one = await run('all', { fromDate: '2026-05-01', toDate: '2026-05-31', tagNo: 'A005' });
    expect(one.rows.map((r: any) => r.vchDate)).toEqual(['2026-04-05', '2026-04-20', '2026-05-10']);
  });

  it('All size filters the movement size', async () => {
    const rep = await run('all', { fromDate: '2026-04-01', toDate: '2026-05-31', size: '8' });
    expect(tagsOf(rep)).toEqual(['A002']);
  });

  // ---------------------------------------------------------------- Mrp, sentinel, year, data type
  it('Mrp keeps any non-zero MRP (including negative) and drops zero', async () => {
    const a8 = T('A008', 108, 'GR', 1, 1, 1, -100, 50, 1, 1, '7', 'C1', '2026-04-05');
    await seedWith(a8, [open(a8)]);
    const rep = await run('mrp');
    expect(tagsOf(rep)).toEqual(['A001', 'A002', 'A005', 'A008']);
    expect(rep.totals.qty).toBe(4);
    expect(rep.totals.mrp).toBe(30000 + 20000 + 12000 - 100);
  });

  it('the sentinel tag no N never appears in any mode', async () => {
    const n = T('N', 401, 'GR', 1, 1, 1, 100, 80, 5, 1, '7', 'C1', '2026-04-05');
    await seedWith(n, [open(n)]);
    await ins(TENANT, 'APR_DETL', {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'AIS',
      VCH_NO: '0008',
      VCH_DATE: iso('2026-05-15'),
      BOOK_NAME: 'APR ISU',
      IT_CODE: 'GR',
      TAG_NO: 'N',
      VCH_SRNO: 401,
      ISU_REC: 'N',
    });
    for (const tab of ['in', 'out', 'stock', 'mrp', 'apr', 'all'])
      expect(
        tagsOf(await run(tab, { fromDate: '2026-04-01', toDate: '2026-05-31' })),
        tab,
      ).not.toContain('N');
  });

  it('only the session year and data type count (movements of another year or type never balance a tag)', async () => {
    const ay1 = T('AY1', 501, 'GR', 1, 1, 1, 100, 80, 5, 1, '7', 'C1', '2025-06-05');
    await seedWith(ay1, [{ ...open(ay1) }], { year: '2025-26' });
    const ad1 = T('AD1', 502, 'GR', 1, 1, 1, 100, 80, 5, 1, '7', 'C1', '2026-04-05');
    await seedWith(ad1, [open(ad1)], { dataType: 'B' });
    for (const tab of ['stock', 'out', 'all'])
      for (const t of tagsOf(await run(tab, { fromDate: '2026-04-01', dataType: 'A' })))
        expect(['AY1', 'AD1']).not.toContain(t);
    // Without a data type (type 'C' = all) the type-B tag is visible again; the other year still is not.
    const c = tagsOf(await run('stock', { dataType: 'C' }));
    expect(c).toContain('AD1');
    expect(c).not.toContain('AY1');
  });

  // ---------------------------------------------------------------- Apr (approval pending)
  it('Apr joins the exact BAR_DETL instance and uses its amounts', async () => {
    const rep = await run('apr');
    expect(tagsOf(rep)).toEqual(['A006']);
    expect(rep.rows[0]).toMatchObject({
      pcs: 1,
      grossWt: 6,
      netWt: 5.8,
      mrp: 40000,
      prCost: 33000,
      lbrAmt: 600,
      othAmt: 120,
      partyName: 'Approval Party',
      qty: 1,
    });
    expect(rep.totals).toMatchObject({
      qty: 1,
      pcs: 1,
      grossWt: 6,
      mrp: 40000,
      prCost: 33000,
      lbrAmt: 600,
      othAmt: 120,
    });
  });

  it('Apr needs ISU_REC = N exactly and the APR ISU book; EMP ISU is its own choice', async () => {
    const mk = async (
      tag: string,
      id: number,
      isuRec: string | null,
      bookName: string,
      acCode: string,
    ) => {
      const t = T(tag, id, 'GR', 1, 1, 1, 10, 5, 1, 1, '7', 'C1', '2026-04-05');
      await seedWith(t, [open(t)]);
      await ins(TENANT, 'APR_DETL', {
        CO_CODE: CO,
        LC_CODE: LC,
        CO_YEAR: YEAR,
        CO_BOOK: 'AIS',
        VCH_NO: '00' + id,
        VCH_DATE: iso('2026-05-16'),
        BOOK_NAME: bookName,
        AC_CODE: acCode,
        IT_CODE: 'GR',
        TAG_NO: tag,
        VCH_SRNO: id,
        ISU_REC: isuRec,
      });
    };
    await mk('AP1', 601, 'Y', 'APR ISU', 'P001'); // returned: never pending
    await mk('AP2', 602, null, 'APR ISU', 'P001'); // NULL: SQL NULL = 'N' is not true
    await mk('AE1', 603, 'N', 'EMP ISU', 'E01'); // tour employee issue
    await mk('AP3', 604, 'N', 'OTH ISU', 'P001'); // another book
    expect(tagsOf(await run('apr'))).toEqual(['A006']);
    const emp = await run('apr', { aprKind: 'employee' });
    expect(tagsOf(emp)).toEqual(['AE1']);
    expect(emp.rows[0].empName).toBe('Tour Employee');
  });

  it('Apr is ordered by year, voucher number, tag number', async () => {
    const mk = async (tag: string, id: number, vch: string) => {
      const t = T(tag, id, 'GR', 1, 1, 1, 10, 5, 1, 1, '7', 'C1', '2026-04-05');
      await seedWith(t, [open(t)]);
      await ins(TENANT, 'APR_DETL', {
        CO_CODE: CO,
        LC_CODE: LC,
        CO_YEAR: YEAR,
        CO_BOOK: 'AIS',
        VCH_NO: vch,
        VCH_DATE: iso('2026-05-16'),
        BOOK_NAME: 'APR ISU',
        AC_CODE: 'P001',
        IT_CODE: 'GR',
        TAG_NO: tag,
        VCH_SRNO: id,
        ISU_REC: 'N',
      });
    };
    await mk('AP2', 702, '0002');
    await mk('AP1', 701, '0002');
    expect(tagsOf(await run('apr'))).toEqual(['A006', 'AP1', 'AP2']);
  });

  // ---------------------------------------------------------------- filters
  it('item, product, group, item type, tag no, size and counter select exact rows', async () => {
    const ids = async (f: Record<string, unknown>, tab = 'stock') => tagsOf(await run(tab, f));
    expect(await ids({ itCode: 'GR' })).toEqual(['A001', 'A002', 'A005']);
    expect(await ids({ itCode: 'SC' })).toEqual(['A007']);
    expect(await ids({ prCode: 'P1' })).toEqual(['A001', 'A002', 'A005']);
    expect(await ids({ prCode: 'P2' })).toEqual(['A007']);
    expect(await ids({ grCode: 'G1' })).toEqual(['A001', 'A002', 'A005']);
    expect(await ids({ grCode: 'G2' })).toEqual(['A007']);
    expect(await ids({ itType: 'G' })).toEqual(['A001', 'A002', 'A005']);
    expect(await ids({ itType: 'S' })).toEqual(['A007']);
    expect(await ids({ tagNo: 'A002' })).toEqual(['A002']);
    expect(await ids({ size: '8' })).toEqual(['A002']);
    expect(await ids({ size: '18' })).toEqual(['A007']);
    expect(await ids({ tblCode: 'C2' })).toEqual(['A007']);
    expect(await ids({ search: 'A00' })).toEqual(['A001', 'A002', 'A005', 'A007']);
    expect(await ids({ search: 'a002' })).toEqual(['A002']);
    expect(await ids({ search: 'ZZ' })).toEqual([]);
    // The search narrows the totals too (the footer sums the visible rows).
    expect((await run('stock', { search: 'A002' })).totals).toMatchObject({
      qty: 1,
      pcs: 2,
      grossWt: 3,
      mrp: 20000,
    });
  });

  it('location selects one location, blank selects all of the company', async () => {
    const al1 = T('AL1', 801, 'GR', 1, 1, 1, 10, 5, 1, 1, '7', 'C1', '2026-04-05');
    await seedWith(al1, [open(al1)], { lc: '02' });
    expect(tagsOf(await run('stock'))).toEqual(['A001', 'A002', 'A005', 'A007']);
    expect(tagsOf(await run('stock', { lcCode: '02' }))).toEqual(['AL1']);
    expect(tagsOf(await run('stock', { lcCode: '' }))).toEqual([
      'A001',
      'A002',
      'A005',
      'A007',
      'AL1',
    ]);
  });

  // ---------------------------------------------------------------- sort orders
  it('Stock, In and Mrp order by tag text; design help orders by design prefix, length, design', async () => {
    const a10 = T('A010', 901, 'GR', 1, 1, 1, 10, 5, 1, 1, '7', 'C1', '2026-04-05', 'X1');
    const a09 = T('A009', 902, 'GR', 1, 1, 1, 10, 5, 1, 1, '7', 'C1', '2026-04-05', 'X2');
    await seedWith(a10, [open(a10)]);
    await seedWith(a09, [open(a09)]);
    expect(tagsOf(await run('stock'))).toEqual(['A001', 'A002', 'A005', 'A007', 'A009', 'A010']);
    expect(tagsOf(await run('mrp'))).toEqual(['A001', 'A002', 'A005', 'A009', 'A010']);
    expect(tagsOf(await run('in', { fromDate: '2026-04-01', toDate: '2026-04-07' }))).toEqual([
      'A001',
      'A003',
      'A004',
      'A005',
      'A006',
      'A007',
      'A009',
      'A010',
    ]);
  });

  it('design help ordering: first two characters, then length, then design', async () => {
    const designs: Record<string, string> = {
      A001: 'RG-10',
      A002: 'RG-9',
      A005: 'RG-9',
      A007: 'SC-1',
    };
    for (const [tag, dsg] of Object.entries(designs))
      await withTenant(owner, TENANT, (tx: any) =>
        tx.$executeRawUnsafe(
          `UPDATE "BAR_DETL" SET "DESIGN_NO"=$1 WHERE tenant_id=$2 AND "TAG_NO"=$3`,
          dsg,
          TENANT,
          tag,
        ),
      );
    const rep = await run('stock', { designHelp: true });
    const tags = tagsOf(rep);
    expect(tags.slice(0, 2).sort()).toEqual(['A002', 'A005']);
    expect(tags.slice(2)).toEqual(['A001', 'A007']);
  });

  it('All with design help sorts by date then design', async () => {
    const rep = await run('all', {
      fromDate: '2026-04-01',
      toDate: '2026-04-07',
      designHelp: true,
    });
    const designs = rep.rows.map((r: any) => r.design);
    // The 05/04 openings, ordered by the design column (D1..D7 here, one character each).
    expect([...designs].sort()).toEqual(designs);
  });

  // ---------------------------------------------------------------- no row cap
  it('totals and rows cover every selected row (no 5000-row cap)', async () => {
    await withTenant(owner, TENANT, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","STK_DATE","VCH_TYPE",
           "IT_CODE","TAG_NO","TBL_CODE","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_NWT","LBR_AMT","OTH_AMT","KR_COST","ITM_MRP","VCH_SRNO","DATA_TYPE")
         SELECT $1,$2,$3,$4,'TOP','B'||g,'2026-04-05','2026-04-05','TO','GR','B'||lpad(g::text,5,'0'),'C1','7',1,1.000,0.900,5,1,80,100,1000+g,'A'
           FROM generate_series(1,5200) g`,
        TENANT,
        CO,
        LC,
        YEAR,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TYPE",
           "IT_CODE","TAG_NO","TBL_CODE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","VCH_SRNO","DATA_TYPE")
         SELECT $1,$2,$3,$4,'TOP','B'||g,'2026-04-05','TO','GR','B'||lpad(g::text,5,'0'),'C1','+',1,1.000,0.900,1000+g,'A'
           FROM generate_series(1,5200) g`,
        TENANT,
        CO,
        LC,
        YEAR,
      );
    });
    const rep = await run('stock');
    expect(rep.rows).toHaveLength(5204);
    expect(rep.totals).toMatchObject({
      qty: 5204,
      pcs: 5 + 5200,
      grossWt: 20 + 5200,
      mrp: 62000 + 520000,
      prCost: 54000 + 416000,
      lbrAmt: 1100 + 26000,
      othAmt: 170 + 5200,
    });
    near(rep.totals.netWt, 19.6 + 5200 * 0.9, 3);
    const inRep = await run('in', { fromDate: '2026-04-01', toDate: '2026-04-30' });
    expect(inRep.rows).toHaveLength(5207);
    const all = await run('all', { fromDate: '2026-04-01', toDate: '2026-05-31' });
    expect(all.totals.qty).toBe(12 + 5200);
  });

  // ---------------------------------------------------------------- summaries
  it('Tag Summ groups by item (name order) and Product Stk by product (name order)', async () => {
    const stock = await run('stock', { view: 'item' });
    expect(stock.rows.map((r: any) => [r.name, r.qty, r.pcs, r.grossWt])).toEqual([
      ['Gold Ring', 3, 4, 10],
      ['Silver Chain', 1, 1, 10],
    ]);
    near(stock.rows[0].netWt, 9.6);
    expect(stock.totals).toMatchObject({ qty: 4, pcs: 5, grossWt: 20 });
    const inb = await run('in', { view: 'item', fromDate: '2026-04-01', toDate: '2026-04-07' });
    expect(inb.rows.map((r: any) => [r.name, r.qty, r.pcs, r.grossWt])).toEqual([
      ['Gold Ring', 5, 5, 18],
      ['Silver Chain', 1, 1, 10],
    ]);
    const out = await run('out', { view: 'item', fromDate: '2026-04-01', toDate: '2026-05-31' });
    expect(out.rows.map((r: any) => [r.name, r.qty, r.grossWt])).toEqual([['Gold Ring', 4, 13]]);
    const apr = await run('apr', { view: 'item' });
    expect(apr.rows.map((r: any) => [r.name, r.qty, r.grossWt])).toEqual([['Gold Ring', 1, 6]]);
    const prod = await run('stock', { view: 'product' });
    expect(prod.rows.map((r: any) => [r.name, r.qty, r.pcs, r.grossWt])).toEqual([
      ['Chains', 1, 1, 10],
      ['Rings', 3, 4, 10],
    ]);
  });

  // ---------------------------------------------------------------- scope
  it('another tenant, company, location, year and reused tag numbers never appear', async () => {
    // Same tag numbers and ids as Seed B in a sentinel tenant, and in another company of the tenant.
    await withTenant(owner, OTHER_TENANT, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES ($1,$2,'GR','Sentinel Ring')
         ON CONFLICT DO NOTHING`,
        OTHER_TENANT,
        CO,
      );
    });
    for (const t of TAGS) {
      await seedWith(t, [open(t)], { tenant: OTHER_TENANT });
      await seedWith(t, [open(t)], { co: '02' });
    }
    const rep = await run('stock');
    expect(tagsOf(rep)).toEqual(['A001', 'A002', 'A005', 'A007']);
    expect(rep.totals.qty).toBe(4);
    expect(rep.totals.mrp).toBe(62000);
    expect((await run('all', { fromDate: '2026-04-01', toDate: '2026-05-31' })).rows).toHaveLength(
      12,
    );
    // A tag that exists only in another company returns nothing and no error.
    await seedWith(T('ZC1', 951, 'GR', 1, 1, 1, 1, 1, 1, 1, '7', 'C1', '2026-04-05'), [], {
      co: '02',
    });
    expect((await run('stock', { tagNo: 'ZC1' })).rows).toHaveLength(0);
  });

  // ---------------------------------------------------------------- invalid input
  it('hostile text is a value, never SQL; an unknown mode is refused', async () => {
    for (const tab of ['in', 'out', 'stock', 'mrp', 'apr', 'all']) {
      const rep = await run(tab, {
        tagNo: "A'00",
        itCode: "X' OR '1'='1",
        search: "%'",
        fromDate: '2026-04-01',
      });
      expect(rep.rows, tab).toHaveLength(0);
    }
    await expect(run('bogus')).rejects.toMatchObject({ name: 'TagStockValidationError' });
    await expect(run('STOCK ; DROP')).rejects.toMatchObject({ name: 'TagStockValidationError' });
    await expect(run('stock', { view: 'sideways' })).rejects.toMatchObject({
      name: 'TagStockValidationError',
    });
  });

  it('totals never disagree with the rows (one consistent snapshot)', async () => {
    const rep = await run('stock');
    expect(rep.totals.qty).toBe(rep.rows.length);
    expect(rep.totals.mrp).toBe(sum(rep.rows, 'mrp'));
  });
});
