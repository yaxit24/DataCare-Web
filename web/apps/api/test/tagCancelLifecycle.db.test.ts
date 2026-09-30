import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  deleteTagCancel,
  getTagCancel,
  listTagCancel,
  saveTagCancel,
  tagCancelSource,
} from '../src/modules/stock/tagCancel.js';
import { issueTagTx } from '../src/modules/stock/stock.js';
import { DESKTOP_COLUMN_DEFAULTS } from '../src/modules/posting/desktopColumnDefaults.js';
import { countsOf, diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

/**
 * N18 — Tag Cancel (X19) and Tag Transfer (X18), desktop TR_TAG_CAN, against a real database.
 *
 * Every expected value is taken from the desktop source, clause by clause, in
 * `parity-plan-2026-09-10/evidence/implementation-2026-09-29-n18/contract.md`; the vector ids (V1…, T1…) are the
 * contract's. Two kinds of assertion:
 *
 *   - ROW assertions compare EVERY column of each written row. A column the expectation does not name must be NULL
 *     or its measured desktop default (`desktopColumnDefaults.ts`), so a web-only column cannot slip in unnoticed.
 *   - WHOLE-DATABASE assertions snapshot every tenant table before and after and require the exact set of rows
 *     added and removed. That is what proves the source tag (BAR_DETL, BAR_IDTL, TAG_IMAGE_DATA) is never touched,
 *     and that a delete returns the database to its prior state apart from the desktop's DELETE_DATA audit.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tag-cancel-lifecycle';
const CO = '01';
const LC = '01';
const LC2 = '02';
const YEAR = '2024-2025';
const DAY = '2024-06-10';
const USER = 'operator';
const D = (iso: string) => new Date(`${iso}T00:00:00.000Z`);

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });

const exec = (sql: string, ...params: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...params));
const query = <T = Array<Record<string, unknown>>>(sql: string, ...params: unknown[]) =>
  owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
const insert = async (table: string, row: Record<string, unknown>) => {
  const columns = Object.keys(row);
  await exec(
    `INSERT INTO "${table}"(tenant_id,${columns.map((c) => `"${c}"`).join(',')})
     VALUES ($1,${columns.map((_, i) => `$${i + 2}`).join(',')})`,
    TENANT,
    ...columns.map((c) => row[c]),
  );
};
const scope = (coBook: string, lcCode = LC) => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode,
  coYear: YEAR,
  coBook,
});
const snapshot = () => snapshotTenant(owner, TENANT);
const sleep = (ms: number) => new Promise((resolve) => setTimeout(resolve, ms));

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT DISTINCT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

// ---- fixture ---------------------------------------------------------------------------------------

const bar = (over: Record<string, unknown>) => ({
  CO_CODE: CO,
  LC_CODE: LC,
  CO_YEAR: YEAR,
  CO_BOOK: 'TOP',
  VCH_NO: '00001',
  SR_NO: 1,
  OLD_SRNO: 1,
  VCH_DATE: D('2024-04-05'),
  VCH_TYPE: 'TGEN',
  BOOK_NAME: 'TAG GEN',
  INOUT_TYPE: 'I',
  ENTRY_TYPE: 'O',
  IT_CODE: 'RNG',
  TBL_CODE: '001',
  DESIGN_NO: '',
  ITM_SIZE: '',
  ITM_PCS: 1,
  BAG_WT: 0,
  ITM_GWT: 5,
  ITM_OTH_WT: 0,
  ITM_NWT: 5,
  ITM_GHT_PRC: 0,
  ITM_GHT_WT: 0,
  ITM_TOUCH: 91.6,
  ITM_WEST_PRC: 0,
  ITM_FINE: 4.58,
  LBR_PRC: 0,
  LBR_TYPE: 'G',
  LBR_RATE: 0,
  LBR_AMT: 0,
  OTH_AMT: 0,
  ITM_RATE: 0,
  ITM_AMT: 0,
  ITM_MRP: 0,
  KR_NAME: '',
  KR_NET_WT: 5,
  KR_TOUCH: 91.6,
  KR_WEST_PRC: 0,
  KR_FINE: 4.58,
  RATE_TYPE: '',
  IT_TYPE: 'G',
  PR_CODE: 'RG',
  DESIGN_IMG_ID: '',
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

const barStone = (b: Record<string, unknown>, over: Record<string, unknown> = {}) => ({
  CO_CODE: b.CO_CODE,
  LC_CODE: b.LC_CODE,
  CO_YEAR: YEAR,
  CO_BOOK: b.CO_BOOK,
  VCH_NO: b.VCH_NO,
  SR_NO: b.OLD_SRNO,
  ISR_NO: 1,
  VCH_DATE: b.VCH_DATE,
  VCH_TYPE: 'TGEN',
  BOOK_NAME: 'TAG GEN',
  INOUT_TYPE: 'I',
  ENTRY_TYPE: 'O',
  TAG_NO: b.TAG_NO,
  VCH_SRNO: b.VCH_SRNO,
  IT_CODE: 'DIA',
  IT_TYPE: 'D',
  IT_PCS: 10,
  IT_GWT: 0.5,
  KR_WT: 0.5,
  IT_CON_PRC: 1,
  IT_CON_WT: 0.5,
  IT_RATE_TYPE: 'W',
  IT_RATE: 2000,
  IT_AMT: 1000,
  IT_LBR_RATE: 20,
  IT_LBR_AMT: 200,
  IT_NET_AMT: 1200,
  KR_CON_WT: 0.5,
  DM_CODE: 'RD01',
  ...over,
});

/** RNG00001: the rich tag of vector V1 (stones, image, karigar block, labour, a HUID the register must not copy). */
const RNG1 = bar({
  TAG_NO: 'RNG00001',
  VCH_SRNO: 100100000001,
  DESIGN_NO: 'D-101',
  ITM_SIZE: '12',
  BAG_WT: 0.05,
  ITM_GWT: 10.5,
  ITM_OTH_WT: 0.5,
  ITM_NWT: 10,
  ITM_WEST_PRC: 2,
  ITM_FINE: 9.36,
  LBR_TYPE: 'N',
  LBR_RATE: 150,
  LBR_AMT: 1500,
  OTH_AMT: 1200,
  KR_NAME: 'KJ',
  // Three decimals on purpose: the tag fill formats KrNwt to TWO (TR_TAG_CAN.cs:4053), so 9.91 is saved.
  KR_NET_WT: 9.905,
  KR_TOUCH: 90,
  KR_WEST_PRC: 1.5,
  KR_FINE: 9.15,
  DESIGN_IMG_ID: 'IMG-101',
  HM_ID: 'HUID5CD',
  TAG_COST: 7000,
});
const RNG2_OLD = bar({ TAG_NO: 'RNG00002', VCH_SRNO: 100100000002, SR_NO: 2, OLD_SRNO: 2 });
const RNG2 = bar({
  TAG_NO: 'RNG00002',
  VCH_SRNO: 100100000009,
  VCH_NO: '00002',
  TBL_CODE: '002',
  DESIGN_NO: 'D-202',
  ITM_GWT: 6.2,
  ITM_NWT: 6.2,
  ITM_TOUCH: 75,
  ITM_FINE: 4.65,
  KR_NET_WT: 6.2,
  KR_TOUCH: 75,
  KR_FINE: 4.65,
  KR_NAME: 'AB',
});
const RNG3A = bar({ TAG_NO: 'RNG00003', VCH_SRNO: 100100000003, SR_NO: 3, OLD_SRNO: 3 });
const RNG3B = bar({
  TAG_NO: 'RNG00003',
  VCH_SRNO: 100100000004,
  VCH_NO: '00003',
  ITM_GWT: 7,
  ITM_NWT: 7,
  ITM_FINE: 6.412,
});
const RNG4 = bar({ TAG_NO: 'RNG00004', VCH_SRNO: 100100000005, LC_CODE: LC2 });
const RNG5 = bar({ TAG_NO: 'RNG00005', VCH_SRNO: 100100000006, SR_NO: 5, OLD_SRNO: 5 });
const RNG5_RETURN = bar({
  TAG_NO: 'RNG00005',
  VCH_SRNO: 100100000006,
  CO_BOOK: 'WRT',
  VCH_NO: '00001',
  SR_NO: 1,
  OLD_SRNO: 1,
});

async function seed(): Promise<void> {
  await wipe();
  await insert('CO_SET', { CO_CODE: CO });
  await insert('YEAR_MAST', {
    CO_CODE: CO,
    CO_YEAR: YEAR,
    OP_DATE: D('2024-04-01'),
    CL_DATE: D('2025-03-31'),
  });
  for (const [lc, book, name, sname, main, use] of [
    [LC, 'TGC', 'Tag Cancel', 'TGCAN', 'TAG CANCEL', 'Y'],
    [LC2, 'TGC', 'Tag Cancel', 'TGCAN', 'TAG CANCEL', 'Y'],
    [LC, 'TTR', 'Tag Transfer', 'TAGTR', 'TAG TRFR', 'Y'],
    [LC, 'TGX', 'Old Tag Cancel', 'TGCX', 'TAG CANCEL', 'N'],
  ] as const) {
    await insert('BOOK_DATA', {
      CO_CODE: CO,
      LC_CODE: lc,
      CO_BOOK: book,
      BOOK_NAME: name,
      BOOK_SNAME: sname,
      MAIN_BOOK: main,
      BOOK_INOUT: 'O',
      CUR_USE: use,
      BOOK_TBL_NAME: 'BAR_CAN_DATA',
    });
  }
  await insert('EMP_MAST', { CO_CODE: CO, EMP_CODE: '001', EMP_NAME: 'Ramesh' });
  for (const [code, name, type, pr, rate, dm] of [
    ['RNG', 'Ring 22K', 'G', 'RG', '', 'N'],
    ['OG', 'Old Gold', 'G', 'OG', '', 'N'],
    ['OS', 'Old Silver', 'S', 'OS', '', 'N'],
    ['DIA', 'Diamond', 'D', 'DM', 'W', 'Y'],
    ['CZ', 'CZ Stone', 'D', 'CZ', 'P', 'N'],
  ] as const) {
    await insert('ITEM_MAST', {
      CO_CODE: CO,
      IT_CODE: code,
      IT_NAME: name,
      IT_TYPE: type,
      PR_CODE: pr,
      RATE_TYPE: rate,
      OTH_DETL_POSTING: dm,
    });
  }
  for (const b of [RNG1, RNG2_OLD, RNG2, RNG3A, RNG3B, RNG4, RNG5, RNG5_RETURN])
    await insert('BAR_DETL', b);
  for (const b of [RNG1, RNG2_OLD, RNG2, RNG3A, RNG3B, RNG4, RNG5])
    await insert('MAIN_STOCK', stockRow(b, '+'));
  // RNG00002's first instance was sold; the number was re-used for 100100000009.
  await insert(
    'MAIN_STOCK',
    stockRow(RNG2_OLD, '-', { CO_BOOK: 'SL', VCH_NO: '00007', STK_DATE: '2024-05-01' }),
  );
  await insert('BAR_IDTL', barStone(RNG1));
  await insert(
    'BAR_IDTL',
    barStone(RNG2, {
      IT_CODE: 'CZ',
      IT_PCS: 2,
      IT_GWT: 0.04,
      KR_WT: 0.04,
      IT_CON_PRC: 0,
      IT_CON_WT: 0,
      IT_RATE_TYPE: '',
      IT_RATE: 0,
      IT_AMT: 50,
      IT_LBR_RATE: 0,
      IT_LBR_AMT: 0,
      IT_NET_AMT: 50,
      KR_CON_WT: 0,
      DM_CODE: null,
    }),
  );
  await insert(
    'BAR_IDTL',
    barStone(RNG5, {
      IT_PCS: 1,
      IT_GWT: 0.1,
      KR_WT: 0.1,
      IT_CON_WT: 0.1,
      IT_AMT: 200,
      IT_NET_AMT: 220,
    }),
  );
  await insert(
    'BAR_IDTL',
    barStone(RNG5_RETURN, {
      IT_PCS: 1,
      IT_GWT: 0.1,
      KR_WT: 0.1,
      IT_CON_WT: 0.1,
      IT_AMT: 200,
      IT_NET_AMT: 220,
    }),
  );
  await insert('TAG_IMAGE_DATA', {
    CO_CODE: CO,
    LC_CODE: LC,
    TAG_NO: 'RNG00001',
    VCH_SRNO: 100100000001,
    IMAGE_TYPE: 'D',
  });
  await insert('TAG_STOCK', {
    CO_CODE: CO,
    LC_CODE: LC,
    TAG_NO: 'TS00001',
    VCH_SRNO: 1,
    IT_TYPE: 'G',
    DESIGN_NO: 'TS-D',
    ITM_SIZE: '7',
    ITM_PCS: 1,
    ITM_GWT: 5.2,
    ITM_NWT: 5,
    ITM_MRP: 25000,
    LBR_TYPE: 'G',
    STK_TYPE: 'R',
  });
}

// ---- assertions -------------------------------------------------------------------------------------

const norm = (value: unknown): unknown => {
  if (value == null) return null;
  if (value instanceof Date) return value.toISOString();
  if (typeof value === 'bigint') return Number(value);
  if (typeof value === 'object' && typeof (value as { toFixed?: unknown }).toFixed === 'function') {
    return Number(String(value));
  }
  return value;
};

/**
 * Every column of `actual` must equal `expected`, or — when the expectation does not name it — be NULL or the
 * measured desktop default. VCH_TIME / ENTRY_TIME are checked separately (they carry the wall clock).
 */
function expectRow(
  table: string,
  actual: Record<string, unknown>,
  expected: Record<string, unknown>,
) {
  const defaults =
    (DESKTOP_COLUMN_DEFAULTS as Record<string, Record<string, unknown>>)[table] ?? {};
  for (const [column, value] of Object.entries(actual)) {
    if (['tenant_id', 'row_id', 'VCH_TIME', 'ENTRY_TIME'].includes(column)) continue;
    const want =
      column in expected ? expected[column] : column in defaults ? defaults[column] : null;
    expect(norm(value), `${table}.${column}`).toEqual(norm(want));
  }
  for (const column of Object.keys(expected)) {
    expect(Object.keys(actual), `${table} has ${column}`).toContain(column);
  }
}

const rowsOf = (table: string, book: string, vchNo: string, order = '"SR_NO", row_id') =>
  query(
    `SELECT * FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY ${order}`,
    TENANT,
    book,
    vchNo,
  );

/** Is this instance issuable now? The resolver's own answer, without consuming it. */
async function live(tagNo: string, vchSrno: number): Promise<boolean> {
  try {
    await tagCancelSource(runtime, scope('TGC'), { tagNo, vchSrno });
    return true;
  } catch (error) {
    if (error instanceof Error && error.name === 'TagNotAvailableError') return false;
    throw error;
  }
}

const V1_LINES = [
  { tagNo: 'RNG00001' },
  { tagNo: 'rng00002', vchSrno: 100100000009 },
  { itCode: 'OG', grossWt: 2, touch: 75 },
];

const header = (over: Record<string, unknown> = {}) => ({
  CO_CODE: CO,
  LC_CODE: LC,
  CO_YEAR: YEAR,
  CO_BOOK: 'TGC',
  VCH_NO: '00001',
  VCH_DATE: D(DAY),
  AC_CODE: '',
  VCH_DESC: 'DAMAGED',
  EMP_CODE: '001',
  HD_VCH_NO: '00001',
  MAIN_USER: USER,
  DATA_TRFR: 'N',
  USER_UPDATE: 'N',
  USER_DELETE: 'N',
  ...over,
});

const detailBase = (book: 'TGC' | 'TTR', over: Record<string, unknown>) => ({
  CO_CODE: CO,
  LC_CODE: LC,
  CO_YEAR: YEAR,
  CO_BOOK: book,
  VCH_NO: '00001',
  VCH_DATE: D(DAY),
  VCH_TYPE: book === 'TGC' ? 'TGCAN' : 'TAGTR',
  INOUT_TYPE: 'O',
  ENTRY_TYPE: 'T',
  BOOK_NAME: book === 'TGC' ? 'TAG CANCEL' : 'TAG TRFR',
  AC_CODE: '',
  LOT_NO: '',
  ITM_LOT: '',
  ITM_SIGN: '-',
  HD_VCH_NO: '00001',
  MAIN_USER: USER,
  DATA_TRFR: 'N',
  ...over,
});

/** RNG00001 exactly as the tag fill puts it on the grid (contract K3). */
const RNG1_CELLS = {
  VCH_SRNO: 100100000001,
  IT_CODE: 'RNG',
  TAG_NO: 'RNG00001',
  TBL_CODE: '001',
  DESIGN_NO: 'D-101',
  ITM_SIZE: '12',
  ITM_PCS: 1,
  BAG_WT: 0.05,
  ITM_GWT: 10.5,
  ITM_OTH_WT: 0.5,
  ITM_NWT: 10,
  ITM_GHT_WT: 0,
  ITM_TOUCH: 91.6,
  ITM_WEST_PRC: 2,
  ITM_FINE: 9.36,
  LBR_PRC: 0,
  LBR_TYPE: 'N',
  LBR_RATE: 150,
  LBR_AMT: 1500,
  OTH_AMT: 1200,
  ITM_RATE: 0,
  ITM_AMT: 0,
  ITM_MRP: 0,
  KR_NET_WT: 9.91,
  KR_TOUCH: 90,
  KR_WEST_PRC: 1.5,
  KR_FINE: 9.15,
  KR_NAME: 'KJ',
  RATE_TYPE: '',
  IT_TYPE: 'G',
  PR_CODE: 'RG',
  DESIGN_IMG_ID: 'IMG-101',
};

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('N18 tag cancel and tag transfer (TR_TAG_CAN) — contract vectors', () => {
  beforeEach(seed);

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('V1: writes exactly the desktop rows, and nothing else in the database changes', async () => {
    const before = await snapshot();
    const result = await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      empCode: '001',
      vchDesc: "Damaged'",
      mainUser: USER,
      lines: V1_LINES,
    });
    expect(result).toMatchObject({
      vchNo: 1,
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      lines: 3,
      stones: 2,
      stockRows: 3,
      diamondRows: 1,
    });

    const diff = diffTenant(before, await snapshot());
    expect(diff.removed).toEqual({});
    expect(countsOf(diff.added)).toEqual({
      TEMP_BOOK_DATA: 1,
      BAR_CAN_DATA: 1,
      BAR_CAN_DETL: 3,
      BAR_CAN_IDTL: 2,
      MAIN_STOCK: 3,
      DM_DATA: 1,
    });

    const [temp] = await query(`SELECT * FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, TENANT);
    expectRow('TEMP_BOOK_DATA', temp!, {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_BOOK: 'TGC',
      VCH_NO: '00001',
      BOOK_NAME: 'Tag Cancel',
    });
    const [head] = await rowsOf('BAR_CAN_DATA', 'TGC', '00001', 'row_id');
    // The form upper-cases every key and swallows the apostrophe (KeyPreview, TR_TAG_CAN_KeyPress).
    expectRow('BAR_CAN_DATA', head!, header());

    const details = await rowsOf('BAR_CAN_DETL', 'TGC', '00001');
    expect(details).toHaveLength(3);
    // The rich tag: HM_ID, TAG_COST and the other web-only columns are NOT copied; TRFR_IT_CODE is not written.
    expectRow(
      'BAR_CAN_DETL',
      details[0]!,
      detailBase('TGC', { SR_NO: 1, OLD_SRNO: 1, ...RNG1_CELLS }),
    );
    expectRow(
      'BAR_CAN_DETL',
      details[1]!,
      detailBase('TGC', {
        SR_NO: 2,
        OLD_SRNO: 2,
        VCH_SRNO: 100100000009,
        IT_CODE: 'RNG',
        TAG_NO: 'RNG00002',
        TBL_CODE: '002',
        DESIGN_NO: 'D-202',
        ITM_SIZE: '',
        ITM_PCS: 1,
        BAG_WT: 0,
        ITM_GWT: 6.2,
        ITM_OTH_WT: 0,
        ITM_NWT: 6.2,
        ITM_GHT_WT: 0,
        ITM_TOUCH: 75,
        ITM_WEST_PRC: 0,
        ITM_FINE: 4.65,
        LBR_PRC: 0,
        LBR_TYPE: 'G',
        LBR_RATE: 0,
        LBR_AMT: 0,
        OTH_AMT: 0,
        ITM_RATE: 0,
        ITM_AMT: 0,
        ITM_MRP: 0,
        KR_NET_WT: 6.2,
        KR_TOUCH: 75,
        KR_WEST_PRC: 0,
        KR_FINE: 4.65,
        KR_NAME: 'AB',
        RATE_TYPE: '',
        IT_TYPE: 'G',
        PR_CODE: 'RG',
        DESIGN_IMG_ID: '',
      }),
    );
    // The loose line: CommPassAdd defaults (company labour basis, Image 'N') and the item's codes.
    expectRow(
      'BAR_CAN_DETL',
      details[2]!,
      detailBase('TGC', {
        SR_NO: 3,
        OLD_SRNO: 3,
        VCH_SRNO: 0,
        IT_CODE: 'OG',
        TAG_NO: 'N',
        TBL_CODE: '',
        DESIGN_NO: '',
        ITM_SIZE: '',
        ITM_PCS: 0,
        BAG_WT: 0,
        ITM_GWT: 2,
        ITM_OTH_WT: 0,
        ITM_NWT: 2,
        ITM_GHT_WT: 0,
        ITM_TOUCH: 75,
        ITM_WEST_PRC: 0,
        ITM_FINE: 1.5,
        LBR_PRC: 0,
        LBR_TYPE: 'G',
        LBR_RATE: 0,
        LBR_AMT: 0,
        OTH_AMT: 0,
        ITM_RATE: 0,
        ITM_AMT: 0,
        ITM_MRP: 0,
        KR_NET_WT: 2,
        KR_TOUCH: 75,
        KR_WEST_PRC: 0,
        KR_FINE: 1.5,
        KR_NAME: '',
        RATE_TYPE: '',
        IT_TYPE: 'G',
        PR_CODE: 'OG',
        DESIGN_IMG_ID: 'N',
      }),
    );

    const stones = await rowsOf('BAR_CAN_IDTL', 'TGC', '00001', '"SR_NO", "ISR_NO"');
    const stoneBase = {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'TGC',
      VCH_NO: '00001',
      VCH_DATE: D(DAY),
      VCH_TYPE: 'TGCAN',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'T',
      BOOK_NAME: 'TAG CANCEL',
      AC_CODE: '',
      HD_VCH_NO: '00001',
      MAIN_USER: USER,
    };
    // DM_CODE is on the tag's stone but TR_TAG_CAN does not carry it (:5215-5242), so it stays NULL.
    expectRow('BAR_CAN_IDTL', stones[0]!, {
      ...stoneBase,
      SR_NO: 1,
      ISR_NO: 1,
      TAG_NO: 'RNG00001',
      VCH_SRNO: 100100000001,
      IT_CODE: 'DIA',
      IT_TYPE: 'D',
      IT_PCS: 10,
      IT_GWT: 0.5,
      KR_WT: 0.5,
      IT_CON_PRC: 1,
      IT_CON_WT: 0.5,
      IT_RATE_TYPE: 'W',
      IT_RATE: 2000,
      IT_AMT: 1000,
      IT_LBR_RATE: 20,
      IT_LBR_AMT: 200,
      IT_NET_AMT: 1200,
    });
    expectRow('BAR_CAN_IDTL', stones[1]!, {
      ...stoneBase,
      SR_NO: 2,
      ISR_NO: 1,
      TAG_NO: 'RNG00002',
      VCH_SRNO: 100100000009,
      IT_CODE: 'CZ',
      IT_TYPE: 'D',
      IT_PCS: 2,
      IT_GWT: 0.04,
      KR_WT: 0.04,
      IT_CON_PRC: 0,
      IT_CON_WT: 0,
      IT_RATE_TYPE: '',
      IT_RATE: 0,
      IT_AMT: 50,
      IT_LBR_RATE: 0,
      IT_LBR_AMT: 0,
      IT_NET_AMT: 50,
    });

    const stock = await rowsOf('MAIN_STOCK', 'TGC', '00001', '"SR_NO", "ISR_NO"');
    const stockBase = {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'TGC',
      VCH_NO: '00001',
      ISR_NO: 1,
      VCH_DATE: D(DAY),
      STK_DATE: DAY,
      VCH_TYPE: 'TGCAN',
      BOOK_NAME: 'TAG CANCEL',
      AC_CODE: '',
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      ITM_QTY: 1,
      NET_AMT: 0,
      KR_LBR_AMT: 0,
      KR_OTH_AMT: 0,
      KR_COST: 0,
      EMP_CODE: '',
      MAIN_USER: USER,
      DATA_TYPE: 'A',
      ITM_DESC: '',
      GHT_PRC: 0,
      ITM_LOT: '',
      ITM_DISC: '0',
    };
    expectRow('MAIN_STOCK', stock[0]!, {
      ...stockBase,
      SR_NO: 1,
      IT_CODE: 'RNG',
      TAG_NO: 'RNG00001',
      VCH_SRNO: 100100000001,
      TBL_CODE: '001',
      ITM_PCS: 1,
      ITM_GWT: 10.5,
      ITM_NWT: 10,
      ITM_TOUCH: 91.6,
      ITM_WEST: 2,
      ITM_FINE: 9.36,
      ITM_RATE: 0,
      ITM_AMT: 0,
      LBR_RATE: 150,
      LBR_AMT: 1500,
      OTH_AMT: 1200,
      ITM_MRP: 0,
      KR_NWT: 9.91,
      KR_TOUCH: 90,
      KR_WEST: 1.5,
      KR_FINE: 9.15,
      DESIGN_NO: 'D-101',
      ITM_SIZE: '12',
    });
    expect(stock.map((row) => [row.TAG_NO, row.VCH_SRNO, row.ITM_SIGN, row.IT_CODE])).toEqual([
      ['RNG00001', 100100000001, '-', 'RNG'],
      ['RNG00002', 100100000009, '-', 'RNG'],
      ['N', 0, '-', 'OG'],
    ]);

    const [diamond] = await rowsOf('DM_DATA', 'TGC', '00001', '"SR_NO"');
    expectRow('DM_DATA', diamond!, {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'TGC',
      VCH_NO: '00001',
      MAIN_SRNO: 1,
      SR_NO: 1,
      ISR_NO: 1,
      VCH_DATE: D(DAY),
      ENTRY_TYPE: 'S',
      BOOK_NAME: 'TGCAN',
      AC_CODE: '',
      IT_CODE: 'DIA',
      DM_LOT_NO: '',
      DM_PCS: 10,
      DM_WT: 0.5,
      DM_SIGN: '-',
      DM_RATE: 2000,
      DM_AMT: 1000,
      EMP_CODE: '',
      TAG_NO: 'RNG00001',
      VCH_SRNO: 100100000001,
      MAIN_IT_CODE: 'RNG',
      INOUT_TYPE: 'O',
    });

    // One clock for the voucher: header and lines share VCH_TIME, dated the voucher day. MAIN_STOCK.ENTRY_TIME
    // is a DATE column, so Tag_Can_Stk's `A.VCH_TIME` keeps only the day there.
    const clocks = await query<Array<{ t: string }>>(
      `SELECT DISTINCT to_char(t,'YYYY-MM-DD HH24:MI:SS.MS') AS t FROM (
         SELECT "VCH_TIME" t FROM "BAR_CAN_DATA" WHERE tenant_id=$1
         UNION ALL SELECT "VCH_TIME" FROM "BAR_CAN_DETL" WHERE tenant_id=$1) x`,
      TENANT,
    );
    expect(clocks, JSON.stringify(clocks)).toHaveLength(1);
    expect(clocks[0]!.t.slice(0, 10)).toBe(DAY);
    const entryDays = await query<Array<{ d: string }>>(
      `SELECT DISTINCT "ENTRY_TIME"::text AS d FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TGC'`,
      TENANT,
    );
    expect(entryDays).toEqual([{ d: DAY }]);

    // The tags are gone from stock; the other instances of the same numbers are not touched.
    expect(await live('RNG00001', 100100000001)).toBe(false);
    expect(await live('RNG00002', 100100000009)).toBe(false);
    expect(await live('RNG00003', 100100000003)).toBe(true);
  });

  it('V2: edit keeps the hidden number, clock, user and kept lines; releases a dropped tag, reserves an added one', async () => {
    await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      empCode: '001',
      vchDesc: 'Damaged',
      mainUser: USER,
      lines: V1_LINES,
    });
    const [clockBefore] = await query<Array<{ t: string }>>(
      `SELECT to_char("VCH_TIME",'HH24:MI:SS.MS') t FROM "BAR_CAN_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    const before = await snapshot();
    await sleep(20);
    const edited = await saveTagCancel(
      runtime,
      'cancel',
      {
        scope: scope('TGC'),
        vchDate: '2024-06-11',
        empCode: '001',
        vchDesc: 'Damaged, recounted',
        mainUser: 'someone-else',
        lines: [
          { tagNo: 'RNG00001', oldSrNo: 1 },
          { itCode: 'OG', oldSrNo: 3, grossWt: 2, touch: 80 },
          { tagNo: 'RNG00003', vchSrno: 100100000004 },
        ],
      },
      '00001',
    );
    expect(edited).toMatchObject({ vchNo: 1, hiddenVoucherNo: '00001', lines: 3 });

    const [head] = await rowsOf('BAR_CAN_DATA', 'TGC', '00001', 'row_id');
    expectRow(
      'BAR_CAN_DATA',
      head!,
      header({ VCH_DATE: D('2024-06-11'), VCH_DESC: 'DAMAGED, RECOUNTED', MAIN_USER: USER }),
    );
    const [clockAfter] = await query<Array<{ t: string; d: string }>>(
      `SELECT to_char("VCH_TIME",'HH24:MI:SS.MS') t, to_char("VCH_TIME",'YYYY-MM-DD') d
         FROM "BAR_CAN_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(clockAfter).toEqual({ t: clockBefore!.t, d: '2024-06-11' });

    const details = await rowsOf('BAR_CAN_DETL', 'TGC', '00001');
    expect(
      details.map((d) => [d.SR_NO, d.OLD_SRNO, d.TAG_NO, d.VCH_SRNO, Number(d.ITM_FINE)]),
    ).toEqual([
      [1, 1, 'RNG00001', 100100000001, 9.36],
      // touch 75 -> 80 recomputes the fine: 2 x 80 / 100 (CommPassTotal, touch changed)
      [2, 3, 'N', 0, 1.6],
      // a new line on an edited voucher takes the next OLD_SRNO (CommPassAdd, edit mode)
      [3, 4, 'RNG00003', 100100000004, 6.412],
    ]);
    expect(Number(details[1]!.KR_FINE)).toBe(1.6);
    expect(Number(details[1]!.KR_TOUCH)).toBe(80);
    // The kept tag line keeps its saved stones; its stone SR_NO is still its OLD_SRNO.
    const stones = await rowsOf('BAR_CAN_IDTL', 'TGC', '00001', '"SR_NO", "ISR_NO"');
    expect(stones.map((s) => [s.SR_NO, s.TAG_NO, s.IT_CODE])).toEqual([[1, 'RNG00001', 'DIA']]);

    const diff = diffTenant(before, await snapshot());
    // Rows are rewritten, never an audit row on edit, and nothing outside the voucher's write set moves.
    expect(Object.keys(diff.added).sort()).toEqual(
      [
        'BAR_CAN_DATA',
        'BAR_CAN_DETL',
        'BAR_CAN_IDTL',
        'DM_DATA',
        'MAIN_STOCK',
        'TEMP_BOOK_DATA',
      ].sort(),
    );
    expect(Object.keys(diff.removed).sort()).toEqual(Object.keys(diff.added).sort());
    expect(diff.added.DELETE_DATA).toBeUndefined();

    expect(await live('RNG00002', 100100000009)).toBe(true);
    expect(await live('RNG00003', 100100000004)).toBe(false);
    expect(await live('RNG00003', 100100000003)).toBe(true);
    expect(await live('RNG00001', 100100000001)).toBe(false);
  });

  it('V3: delete writes the desktop DELETE_DATA rows and returns every other table to its prior state', async () => {
    const before = await snapshot();
    await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      empCode: '001',
      vchDesc: 'Damaged',
      mainUser: USER,
      lines: V1_LINES,
    });
    const reversed = await deleteTagCancel(runtime, 'cancel', scope('TGC'), '1', 'supervisor');
    expect(reversed).toMatchObject({ reversed: true, vchNo: 1, lines: 3, restoredTags: 0 });

    const diff = diffTenant(before, await snapshot());
    expect(diff.removed).toEqual({});
    expect(countsOf(diff.added)).toEqual({ DELETE_DATA: 3 });
    const audit = await query(
      `SELECT * FROM "DELETE_DATA" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      TENANT,
    );
    const auditBase = {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'TGC',
      VCH_NO: '00001',
      VCH_DATE: D(DAY),
      VCH_TYPE: 'TGCAN',
      BOOK_NAME: 'Tag Cancel',
      AC_CODE: '',
      AC_NAME: '',
      VCH_VAL_DR: 0,
      VCH_VAL_CR: 0,
      VCH_FINE_DR: 0,
      HD_VCH_NO: '00001',
      MAIN_USER: USER,
      DELETE_USER: 'supervisor',
    };
    for (const row of audit) {
      // DELETE_DATE and DELETE_TIME are the moment of deletion.
      expect(row.DELETE_DATE).toBeInstanceOf(Date);
      expect(row.DELETE_TIME).toBeInstanceOf(Date);
      delete row.DELETE_DATE;
      delete row.DELETE_TIME;
    }
    expectRow('DELETE_DATA', audit[0]!, {
      ...auditBase,
      SR_NO: 1,
      FINE_TYPE: 'G',
      VCH_FINE_CR: 10,
      VCH_DESC: 'ItCode/RNG TagNo/RNG00001',
    });
    expectRow('DELETE_DATA', audit[1]!, {
      ...auditBase,
      SR_NO: 2,
      FINE_TYPE: 'G',
      VCH_FINE_CR: 6.2,
      VCH_DESC: 'ItCode/RNG TagNo/RNG00002',
    });
    expectRow('DELETE_DATA', audit[2]!, {
      ...auditBase,
      SR_NO: 3,
      FINE_TYPE: 'G',
      VCH_FINE_CR: 2,
      VCH_DESC: 'ItCode/OG TagNo/N',
    });
    expect(await live('RNG00001', 100100000001)).toBe(true);
    expect(await live('RNG00002', 100100000009)).toBe(true);
  });

  it('V4: refuses an ambiguous tag number without a serial, writing nothing and using no number', async () => {
    const before = await snapshot();
    await expect(
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC'),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00003' }],
      }),
    ).rejects.toMatchObject({ name: 'TagIdentityAmbiguousValidationError' });
    expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
    const ok = await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      mainUser: USER,
      lines: [{ tagNo: 'RNG00003', vchSrno: 100100000003 }],
    });
    expect(ok.voucherNo).toBe('00001');
    // Exactly that instance moved.
    expect(await live('RNG00003', 100100000003)).toBe(false);
    expect(await live('RNG00003', 100100000004)).toBe(true);
  });

  it('V5: refuses the same tag number twice with the desktop message', async () => {
    await expect(
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC'),
        vchDate: DAY,
        mainUser: USER,
        lines: [
          { tagNo: 'RNG00003', vchSrno: 100100000003 },
          { tagNo: 'RNG00003', vchSrno: 100100000004 },
        ],
      }),
    ).rejects.toThrow('Duplicate Tag No: RNG00003');
  });

  it("V6: another location's tag and a sold instance are not available", async () => {
    await expect(
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC'),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00004' }],
      }),
    ).rejects.toMatchObject({ name: 'TagNotAvailableError' });
    await expect(
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC'),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00002', vchSrno: 100100000002 }],
      }),
    ).rejects.toMatchObject({ name: 'TagNotAvailableError' });
    // From its own location the tag cancels.
    await expect(
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC', LC2),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00004' }],
      }),
    ).resolves.toMatchObject({ lines: 1 });
  });

  it('V7: a cancel waits for a sale holding the same tag, then loses cleanly', async () => {
    let releaseSale!: () => void;
    const saleMayCommit = new Promise<void>((resolve) => (releaseSale = resolve));
    let signalReserved!: () => void;
    const saleReserved = new Promise<void>((resolve) => (signalReserved = resolve));
    // The sale's own reservation path: issueTagTx under the identity lock, then its '-' row.
    const sale = withTenant(
      runtime,
      TENANT,
      async (tx: any) => {
        await issueTagTx(tx, { CO_CODE: CO, LC_CODE: LC, TAG_NO: 'RNG00001' });
        await tx.$executeRawUnsafe(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
             "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
           VALUES ($1,$2,$3,$4,'SL','00020',1,1,$5,'RNG','RNG00001',100100000001,'S','-',1,1)`,
          TENANT,
          CO,
          LC,
          YEAR,
          D(DAY),
        );
        signalReserved();
        await saleMayCommit;
      },
      { timeout: 20_000 },
    );
    await saleReserved;
    const cancel = saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      mainUser: USER,
      lines: [{ tagNo: 'RNG00001' }],
    });
    const outcome = cancel.then(
      () => 'saved',
      (error: Error) => error.name,
    );
    await sleep(400);
    // Still waiting on the tag lock: nothing of the cancel exists yet.
    expect(await query(`SELECT 1 FROM "BAR_CAN_DATA" WHERE tenant_id=$1`, TENANT)).toEqual([]);
    releaseSale();
    await sale;
    expect(await outcome).toBe('TagNotAvailableError');
    expect(await query(`SELECT 1 FROM "BAR_CAN_DATA" WHERE tenant_id=$1`, TENANT)).toEqual([]);
    expect(await query(`SELECT 1 FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, TENANT)).toEqual([]);
  });

  it('V7: two writers racing for one tag — exactly one voucher holds it', async () => {
    const attempts = await Promise.allSettled([
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC'),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00001' }, { tagNo: 'RNG00002', vchSrno: 100100000009 }],
      }),
      saveTagCancel(runtime, 'transfer', {
        scope: scope('TTR'),
        vchDate: DAY,
        mainUser: USER,
        lines: [
          { tagNo: 'RNG00002', vchSrno: 100100000009, trfrItCode: 'OG' },
          { tagNo: 'RNG00001', trfrItCode: 'OG' },
        ],
      }),
    ]);
    const won = attempts.filter((a) => a.status === 'fulfilled');
    const lost = attempts.filter((a) => a.status === 'rejected') as PromiseRejectedResult[];
    expect(won).toHaveLength(1);
    expect(lost).toHaveLength(1);
    // The two vouchers name the tags in opposite orders. Because every save locks its tags SORTED before resolving
    // any (K2.6), the second simply waits and then finds its tags gone — a clean "not available", never a deadlock
    // (which PostgreSQL would break by aborting one side, reported as a 409 TagCancelConflictError).
    expect(lost[0]!.reason.name).toBe('TagNotAvailableError');
    const holders = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO" IN ('RNG00001','RNG00002')
          AND "ITM_SIGN"='-' AND "CO_BOOK" IN ('TGC','TTR')`,
      TENANT,
    );
    expect(holders[0]!.n).toBe(2);
    expect(
      await query(`SELECT count(*)::int n FROM "BAR_CAN_DATA" WHERE tenant_id=$1`, TENANT),
    ).toEqual([{ n: 1 }]);
  });

  it('K2.6: locks every tag in sorted order before resolving any, whatever the line order', async () => {
    const key = (tagNo: string) => `tag-issue|${CO}|${LC}|${tagNo}`;
    const advisory = async (tagNo: string, granted: boolean) =>
      Number(
        (
          await query<Array<{ n: number }>>(
            `SELECT count(*)::int AS n FROM pg_locks
              WHERE locktype='advisory' AND granted=$2 AND objsubid=1
                AND objid::bigint = (hashtext($1)::bigint & 4294967295)`,
            key(tagNo),
            granted,
          )
        )[0]!.n,
      );
    let release!: () => void;
    const mayRelease = new Promise<void>((resolve) => (release = resolve));
    let holding!: () => void;
    const held = new Promise<void>((resolve) => (holding = resolve));
    // Another writer holds the LOWER number …
    const other = owner.$transaction(
      async (tx) => {
        await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', key('RNG00001'));
        holding();
        await mayRelease;
      },
      { timeout: 30_000 },
    );
    await held;
    // … and the voucher names the HIGHER number first.
    const save = saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      mainUser: USER,
      lines: [{ tagNo: 'RNG00002', vchSrno: 100100000009 }, { tagNo: 'RNG00001' }],
    });
    for (let i = 0; i < 400 && (await advisory('RNG00001', false)) === 0; i++) await sleep(25);
    // It waits for the lower number while holding nothing; locking in line order it would hold RNG00002 now, the
    // half of a cycle a writer naming them the other way round would close.
    expect(await advisory('RNG00001', false)).toBe(1);
    expect(await advisory('RNG00002', true)).toBe(0);
    release();
    await other;
    await expect(save).resolves.toMatchObject({ voucherNo: '00001', lines: 2 });
  });

  it('K9.2: an edit keeps its hidden number while later vouchers hold higher ones', async () => {
    const save = (lines: Array<Record<string, unknown>>, voucherNo?: string) =>
      saveTagCancel(
        runtime,
        'cancel',
        { scope: scope('TGC'), vchDate: DAY, mainUser: USER, lines },
        voucherNo,
      );
    const first = await save([{ tagNo: 'RNG00001' }]);
    const second = await save([{ tagNo: 'RNG00002', vchSrno: 100100000009 }]);
    expect([first.hiddenVoucherNo, second.hiddenVoucherNo]).toEqual(['00001', '00002']);
    await save(
      [
        { tagNo: 'RNG00001', oldSrNo: 1 },
        { itCode: 'OG', grossWt: 1 },
      ],
      first.voucherNo,
    );
    expect(
      await query(
        `SELECT "VCH_NO","HD_VCH_NO" FROM "BAR_CAN_DATA" WHERE tenant_id=$1 ORDER BY "VCH_NO"`,
        TENANT,
      ),
    ).toEqual([
      { VCH_NO: '00001', HD_VCH_NO: '00001' },
      { VCH_NO: '00002', HD_VCH_NO: '00002' },
    ]);
    expect(
      await query(
        `SELECT "VCH_NO" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 ORDER BY "VCH_NO"`,
        TENANT,
      ),
    ).toEqual([{ VCH_NO: '00001' }, { VCH_NO: '00002' }]);
  });

  it('V8: a failure part-way through leaves nothing — the consumed web tag is back and no number is used', async () => {
    const before = await snapshot();
    await expect(
      saveTagCancel(runtime, 'transfer', {
        scope: scope('TTR'),
        vchDate: DAY,
        mainUser: USER,
        lines: [
          { tagNo: 'TS00001', itCode: 'RNG', trfrItCode: 'OG' },
          { tagNo: 'RNG00001', trfrItCode: 'XX' },
        ],
      }),
    ).rejects.toThrow('row 2: transfer item XX not found');
    expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
  });

  it('V9: the lock date refuses a save, an edit and a delete', async () => {
    await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      mainUser: USER,
      lines: [{ tagNo: 'RNG00001' }],
    });
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"='2024-06-30' WHERE tenant_id=$1`, TENANT);
    const before = await snapshot();
    await expect(
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC'),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00002', vchSrno: 100100000009 }],
      }),
    ).rejects.toMatchObject({ name: 'PeriodLockValidationError' });
    await expect(
      saveTagCancel(
        runtime,
        'cancel',
        {
          scope: scope('TGC'),
          vchDate: '2024-07-05',
          mainUser: USER,
          lines: [{ tagNo: 'RNG00001', oldSrNo: 1 }],
        },
        '00001',
      ),
    ).rejects.toMatchObject({ name: 'PeriodLockValidationError' });
    await expect(
      deleteTagCancel(runtime, 'cancel', scope('TGC'), '00001', USER),
    ).rejects.toMatchObject({
      name: 'PeriodLockValidationError',
    });
    expect(diffTenant(before, await snapshot())).toEqual({ added: {}, removed: {} });
  });

  it('V10: a web TAG_STOCK tag is consumed by the cancel and restored by the delete', async () => {
    await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      mainUser: USER,
      lines: [{ tagNo: 'TS00001', itCode: 'RNG' }],
    });
    expect(await query(`SELECT 1 FROM "TAG_STOCK" WHERE tenant_id=$1`, TENANT)).toEqual([]);
    const [line] = await rowsOf('BAR_CAN_DETL', 'TGC', '00001');
    expect([
      line!.IT_CODE,
      Number(line!.ITM_GWT),
      Number(line!.ITM_NWT),
      Number(line!.ITM_MRP),
      line!.DESIGN_NO,
    ]).toEqual(['RNG', 5.2, 5, 25000, 'TS-D']);
    const result = await deleteTagCancel(runtime, 'cancel', scope('TGC'), '00001', USER);
    expect(result.restoredTags).toBe(1);
    const restored = await query(
      `SELECT "TAG_NO","VCH_SRNO","IT_TYPE","DESIGN_NO","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_MRP","STK_TYPE"
         FROM "TAG_STOCK" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(
      restored.map((row) => Object.fromEntries(Object.entries(row).map(([k, v]) => [k, norm(v)]))),
    ).toEqual([
      {
        TAG_NO: 'TS00001',
        VCH_SRNO: 1,
        IT_TYPE: 'G',
        DESIGN_NO: 'TS-D',
        ITM_SIZE: '7',
        ITM_PCS: 1,
        ITM_GWT: 5.2,
        ITM_NWT: 5,
        ITM_MRP: 25000,
        STK_TYPE: 'R',
      },
    ]);
  });

  it('V11: copies the stones of the instance’s first BAR_DETL row only', async () => {
    const result = await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      mainUser: USER,
      lines: [{ tagNo: 'RNG00005' }],
    });
    expect(result.stones).toBe(1);
  });

  it('V12: each menu accepts only its own in-use book', async () => {
    const attempt = (mode: 'cancel' | 'transfer', book: string) =>
      saveTagCancel(runtime, mode, {
        scope: scope(book),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00001', trfrItCode: mode === 'transfer' ? 'OG' : undefined }],
      });
    await expect(attempt('cancel', 'TTR')).rejects.toThrow(
      'book TTR is TAG TRFR, not TAG CANCEL — use Tag Transfer',
    );
    await expect(attempt('transfer', 'TGC')).rejects.toThrow(
      'book TGC is TAG CANCEL, not TAG TRFR — use Tag Cancel',
    );
    await expect(attempt('cancel', 'TGX')).rejects.toThrow('book TGX is not in use');
    await expect(attempt('cancel', 'ZZZ')).rejects.toThrow('book ZZZ is not configured');
  });

  it('T1: a transfer moves the tag to the loose item with the same pieces, weights and fine', async () => {
    const before = await snapshot();
    await saveTagCancel(runtime, 'transfer', {
      scope: scope('TTR'),
      vchDate: DAY,
      empCode: '001',
      mainUser: USER,
      lines: [{ tagNo: 'RNG00001', trfrItCode: 'og' }],
    });
    const diff = diffTenant(before, await snapshot());
    expect(diff.removed).toEqual({});
    // No DM_DATA: Dm_Tag_Cancel_Detl is TAG CANCEL only.
    expect(countsOf(diff.added)).toEqual({
      TEMP_BOOK_DATA: 1,
      BAR_CAN_DATA: 1,
      BAR_CAN_DETL: 1,
      BAR_CAN_IDTL: 1,
      MAIN_STOCK: 2,
    });
    const [detail] = await rowsOf('BAR_CAN_DETL', 'TTR', '00001');
    expectRow(
      'BAR_CAN_DETL',
      detail!,
      detailBase('TTR', { SR_NO: 1, OLD_SRNO: 1, ...RNG1_CELLS, TRFR_IT_CODE: 'OG' }),
    );
    const stock = await rowsOf('MAIN_STOCK', 'TTR', '00001', '"SR_NO", "ISR_NO"');
    expect(stock).toHaveLength(2);
    const common = {
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'TTR',
      VCH_NO: '00001',
      SR_NO: 1,
      VCH_DATE: D(DAY),
      STK_DATE: DAY,
      VCH_TYPE: 'TAGTR',
      BOOK_NAME: 'TAG TRFR',
      AC_CODE: '',
      ITM_QTY: 1,
      ITM_PCS: 1,
      ITM_GWT: 10.5,
      ITM_NWT: 10,
      ITM_TOUCH: 91.6,
      ITM_WEST: 2,
      ITM_FINE: 9.36,
      NET_AMT: 0,
      KR_NWT: 9.91,
      KR_TOUCH: 90,
      KR_WEST: 1.5,
      KR_FINE: 9.15,
      KR_LBR_AMT: 0,
      KR_OTH_AMT: 0,
      KR_COST: 0,
      EMP_CODE: '',
      MAIN_USER: USER,
      DATA_TYPE: 'A',
      DESIGN_NO: 'D-101',
      ITM_SIZE: '12',
      ITM_DESC: '',
      GHT_PRC: 0,
      ITM_DISC: '0',
    };
    expectRow('MAIN_STOCK', stock[0]!, {
      ...common,
      ISR_NO: 1,
      IT_CODE: 'RNG',
      TAG_NO: 'RNG00001',
      VCH_SRNO: 100100000001,
      TBL_CODE: '001',
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      ITM_RATE: 0,
      ITM_AMT: 0,
      LBR_RATE: 150,
      LBR_AMT: 1500,
      OTH_AMT: 1200,
      ITM_MRP: 0,
      ITM_LOT: '',
    });
    expectRow('MAIN_STOCK', stock[1]!, {
      ...common,
      ISR_NO: 2,
      IT_CODE: 'OG',
      TAG_NO: 'N',
      VCH_SRNO: 0,
      TBL_CODE: '001',
      TR_TYPE: 'I',
      ITM_SIGN: '+',
      ITM_RATE: 0,
      ITM_AMT: 0,
      LBR_RATE: 0,
      LBR_AMT: 0,
      OTH_AMT: 0,
      ITM_MRP: 0,
      ITM_LOT: '',
    });
    expect(await live('RNG00001', 100100000001)).toBe(false);
  });

  it('T2: a transfer line needs a transfer item that exists', async () => {
    const attempt = (trfrItCode?: string) =>
      saveTagCancel(runtime, 'transfer', {
        scope: scope('TTR'),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00001', trfrItCode }],
      });
    await expect(attempt()).rejects.toThrow('row 1: enter the transfer item (TrfrItm)');
    await expect(attempt('ZZ')).rejects.toThrow('row 1: transfer item ZZ not found');
  });

  it('T3/T4: an edited transfer moves the + row to the new item; delete writes the TAGTR audit', async () => {
    await saveTagCancel(runtime, 'transfer', {
      scope: scope('TTR'),
      vchDate: DAY,
      mainUser: USER,
      lines: [{ tagNo: 'RNG00001', trfrItCode: 'OG' }],
    });
    await saveTagCancel(
      runtime,
      'transfer',
      {
        scope: scope('TTR'),
        vchDate: DAY,
        mainUser: USER,
        lines: [{ tagNo: 'RNG00001', oldSrNo: 1, trfrItCode: 'OS' }],
      },
      1,
    );
    const stock = await rowsOf('MAIN_STOCK', 'TTR', '00001', '"SR_NO", "ISR_NO"');
    expect(
      stock.map((row) => [row.ISR_NO, row.IT_CODE, row.ITM_SIGN, Number(row.ITM_FINE)]),
    ).toEqual([
      [1, 'RNG', '-', 9.36],
      [2, 'OS', '+', 9.36],
    ]);
    const view = await getTagCancel(runtime, 'transfer', scope('TTR'), '00001');
    expect(view.lines[0]).toMatchObject({
      trfrItCode: 'OS',
      trfrItName: 'Old Silver',
      itName: 'Ring 22K',
    });

    await deleteTagCancel(runtime, 'transfer', scope('TTR'), '00001', USER);
    const [audit] = await query(`SELECT * FROM "DELETE_DATA" WHERE tenant_id=$1`, TENANT);
    expect([audit!.VCH_TYPE, audit!.BOOK_NAME, audit!.VCH_DESC]).toEqual([
      'TAGTR',
      'Tag Transfer',
      'ItCode/RNG TagNo/RNG00001',
    ]);
    expect(
      await query(`SELECT 1 FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TTR'`, TENANT),
    ).toEqual([]);
    expect(await live('RNG00001', 100100000001)).toBe(true);
  });

  it('replays an API caller’s edits through the desktop grid arithmetic (K4)', async () => {
    await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      mainUser: USER,
      lines: [{ tagNo: 'RNG00001', grossWt: 10.7 }],
    });
    const [line] = await rowsOf('BAR_CAN_DETL', 'TGC', '00001');
    // net = 10.7 - 0.5; fine = 10.2 x 93.6 / 100 = 9.5472; labour N = Math.Round(10.2 x 150) = 1530.
    // The karigar block recomputes from its never-set baseline: 9.91 x 91.5 / 100 = 9.06765 -> 9.068.
    expect(
      ['ITM_GWT', 'ITM_NWT', 'ITM_FINE', 'LBR_AMT', 'KR_NET_WT', 'KR_FINE'].map((c) =>
        Number(line![c]),
      ),
    ).toEqual([10.7, 10.2, 9.547, 1530, 9.91, 9.068]);
  });

  it('applies edited stones to the row and posts only OTH_DETL_POSTING items to DM_DATA', async () => {
    await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      mainUser: USER,
      lines: [
        {
          tagNo: 'RNG00001',
          stones: [
            {
              itCode: 'DIA',
              pcs: 5,
              grossWt: 0.25,
              conPct: 1,
              rateType: 'W',
              rate: 2000,
              lbrRate: 20,
            },
            { itCode: 'CZ', pcs: 4, rate: 10 },
          ],
        },
      ],
    });
    const stones = await rowsOf('BAR_CAN_IDTL', 'TGC', '00001', '"ISR_NO"');
    expect(
      stones.map((s) => [
        s.ISR_NO,
        s.IT_CODE,
        Number(s.IT_AMT),
        Number(s.IT_LBR_AMT),
        Number(s.IT_NET_AMT),
        Number(s.IT_CON_WT),
        Number(s.KR_WT),
      ]),
    ).toEqual([
      [1, 'DIA', 500, 100, 600, 0.25, 0.25],
      [2, 'CZ', 40, 0, 40, 0, 0],
    ]);
    const [line] = await rowsOf('BAR_CAN_DETL', 'TGC', '00001');
    // Σ ConWt 0.25 becomes LsWt and net = 10.5 - 0.25; Σ NetAmt 640 becomes OthAmt; the row then recomputes:
    // fine = 10.25 x 93.6 / 100 = 9.594; labour N = Math.Round(10.25 x 150) = 1537.5 -> 1538.
    expect(
      ['ITM_OTH_WT', 'ITM_NWT', 'OTH_AMT', 'ITM_FINE', 'LBR_AMT'].map((c) => Number(line![c])),
    ).toEqual([0.25, 10.25, 640, 9.594, 1538]);
    const diamonds = await rowsOf('DM_DATA', 'TGC', '00001', '"ISR_NO"');
    expect(diamonds.map((d) => [d.IT_CODE, Number(d.DM_PCS), Number(d.DM_AMT)])).toEqual([
      ['DIA', 5, 500],
    ]);
  });

  it('refuses what the desktop grid would not accept', async () => {
    const attempt = (mode: 'cancel' | 'transfer', lines: Array<Record<string, unknown>>) =>
      saveTagCancel(runtime, mode, {
        scope: scope(mode === 'cancel' ? 'TGC' : 'TTR'),
        vchDate: DAY,
        mainUser: USER,
        lines,
      });
    await expect(attempt('cancel', [{ grossWt: 2 }])).rejects.toThrow(
      'Please Select Item Code In Row 1 and Try......',
    );
    await expect(attempt('cancel', [{ tagNo: 'RNG00001', pcs: 2 }])).rejects.toThrow(
      'row 1: Pcs comes from the tag',
    );
    await expect(attempt('cancel', [{ tagNo: 'RNG00001', itCode: 'OG' }])).rejects.toMatchObject({
      name: 'TagNotAvailableError',
    });
    await expect(
      attempt('transfer', [{ tagNo: 'RNG00001', trfrItCode: 'OG', lbrRate: 20 }]),
    ).rejects.toThrow('row 1: LbrRate is not a Tag Transfer column');
    await expect(attempt('cancel', [{ tagNo: 'RNG00001', trfrItCode: 'OG' }])).rejects.toThrow(
      'row 1: TrfrItm is a Tag Transfer column',
    );
    await expect(
      attempt('cancel', [{ itCode: 'OG', grossWt: 1, stones: [{ itCode: 'DIA', pcs: 1 }] }]),
    ).rejects.toThrow('row 1: stones belong to a tag line');
    await expect(attempt('cancel', [{ tagNo: 'TS00001' }])).rejects.toThrow(
      "row 1: tag TS00001 has no item; enter the line's item code",
    );
    await expect(attempt('cancel', [{}, { itCode: '' }])).rejects.toThrow(
      'enter at least one tag or item line',
    );
    // Web adaptation A2: a live tag with no pieces, weight or amount fails the save filter (:5099); the desktop would
    // skip the row and leave the tag in stock without saying so.
    const empty = bar({
      TAG_NO: 'RNG00006',
      VCH_SRNO: 100100000010,
      SR_NO: 6,
      OLD_SRNO: 6,
      ITM_PCS: 0,
      ITM_GWT: 0,
      ITM_NWT: 0,
      ITM_FINE: 0,
      KR_NET_WT: 0,
      KR_FINE: 0,
    });
    await insert('BAR_DETL', empty);
    await insert('MAIN_STOCK', stockRow(empty, '+', { ITM_PCS: 0 }));
    await expect(attempt('cancel', [{ tagNo: 'RNG00006' }])).rejects.toThrow(
      'row 1: tag RNG00006 has no pieces, weight or amount to cancel',
    );
    expect(await live('RNG00006', 100100000010)).toBe(true);
    await expect(
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC'),
        vchDate: '2025-04-02',
        mainUser: USER,
        lines: [{ tagNo: 'RNG00001' }],
      }),
    ).rejects.toMatchObject({ name: 'FiscalDateValidationError' });
    await expect(
      saveTagCancel(runtime, 'cancel', {
        scope: scope('TGC'),
        vchDate: DAY,
        empCode: '999',
        mainUser: USER,
        lines: [{ tagNo: 'RNG00001' }],
      }),
    ).rejects.toThrow('employee 999 not found');
  });

  it('reads a voucher back as DISPLAY_DATA shows it, lists the book, and previews a tag without taking it', async () => {
    const preview = await tagCancelSource(runtime, scope('TGC'), { tagNo: 'RNG00001' });
    expect(preview).toMatchObject({
      tagNo: 'RNG00001',
      vchSrno: 100100000001,
      source: 'BAR_DETL',
      itName: 'Ring 22K',
      line: { netWt: 10, fine: 9.36, krNetWt: 9.91, designImageId: 'IMG-101', ghtPct: 0 },
    });
    expect(preview.stones).toHaveLength(1);
    expect(await live('RNG00001', 100100000001)).toBe(true);

    await saveTagCancel(runtime, 'cancel', {
      scope: scope('TGC'),
      vchDate: DAY,
      empCode: '001',
      vchDesc: 'Damaged',
      mainUser: USER,
      lines: V1_LINES,
    });
    const view = await getTagCancel(runtime, 'cancel', scope('TGC'), '1');
    expect(view).toMatchObject({
      voucherNo: '00001',
      vchDate: DAY,
      hiddenVoucherNo: '00001',
      mainUser: USER,
      empCode: '001',
      empName: 'Ramesh',
      vchDesc: 'DAMAGED',
      book: { code: 'TGC', name: 'Tag Cancel', shortName: 'TGCAN', mainBook: 'TAG CANCEL' },
    });
    expect(view.voucherTime).toMatch(/^\d{2}:\d{2}:\d{2}$/);
    expect(view.lines.map((l) => [l.srNo, l.oldSrNo, l.tagNo, l.itName, l.stones.length])).toEqual([
      [1, 1, 'RNG00001', 'Ring 22K', 1],
      [2, 2, 'RNG00002', 'Ring 22K', 1],
      [3, 3, '', 'Old Gold', 0],
    ]);
    expect(view.totals).toMatchObject({
      pcs: 2,
      grossWt: 18.7,
      netWt: 18.2,
      fine: 15.51,
      lbrAmt: 1500,
      othAmt: 1200,
    });

    const list = await listTagCancel(runtime, 'cancel', scope('TGC'));
    expect(list.nextVoucherNo).toBe('00002');
    expect(list.vouchers).toEqual([
      { vchNo: '00001', vchDate: DAY, partyName: '', vchDesc: 'DAMAGED', mainUser: USER, lines: 3 },
    ]);
    await expect(getTagCancel(runtime, 'transfer', scope('TGC'), '1')).rejects.toThrow(
      'book TGC is TAG CANCEL, not TAG TRFR',
    );
    await expect(getTagCancel(runtime, 'cancel', scope('TGC'), '2')).rejects.toThrow(
      'voucher not found: 00002',
    );
  });
});
