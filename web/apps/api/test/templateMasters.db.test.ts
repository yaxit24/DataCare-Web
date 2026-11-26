import { readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'template-masters';
const CO = '01';
const fixtureDir = resolve(dirname(fileURLToPath(import.meta.url)), 'fixtures/desktop-template');

const TABLES = [
  'AC_GROUP',
  'AC_MAST',
  'BOOK_DATA',
  'BOOK_DETL',
  'BOOK_IDTL',
  'GROUP_MAST',
  'ITEM_MAST',
  'PRODUCT_MAST',
  'TAX_MAST',
  'WEIGHT_MAST',
  'MFG_MAST',
  'PRINT_MAST',
  'BAL_GR',
  'CO_SET',
  'CO_SET_NEW',
  'EMP_MAST',
  'TABLE_MAST',
  'STATE_MAST',
  'COUNTRY_MAST',
  'COL_MAST',
  'YEAR_MAST',
  'LOCT_MAST',
] as const;

/**
 * Deliberate provisioning adaptations already documented in seedCompany.ts or the parity plan. Each
 * exception is table-scoped so an unreviewed exception cannot hide AC_GROUP (the defect fixed here).
 * The comparison still runs for every table and proves that every exception remains an actual delta.
 */
const EXCEPTIONS: Partial<Record<(typeof TABLES)[number], string>> = {
  AC_MAST:
    'Web posting resolves named role accounts (CASH/SALES/GST/...) rather than the installer numeric chart; seedCompany.ts SYSTEM_ACCOUNTS documents the adaptation.',
  BOOK_DATA:
    'Web provisions the supported workflow books and web role codes; seedCompany.ts BOOKS documents the mapping and web-only IOP compatibility book.',
  BOOK_DETL:
    'Web book slots refer to named role accounts and include fail-closed posting slots added by parity slices N198/N240.',
  BOOK_IDTL: 'No web writer consumes this legacy password-bearing installer detail table.',
  TAX_MAST:
    'G82 rows are retained: adding installer TDS code 25 at 0.1% conflicts with TCS code 20 in the percentage-only tax resolver.',
  WEIGHT_MAST: 'MS_YEAR.cs:1504-1595 never copies WEIGHT_MAST; it has no CO_CODE.',
  MFG_MAST: 'MS_YEAR.cs:1504-1595 never copies MFG_MAST, even though its schema has CO_CODE.',
  PRINT_MAST:
    'Crystal Reports print-file defaults are desktop-only; web reports use web renderers.',
  CO_SET:
    'Web stores one company settings row with source-backed SL_AMT_TYPE/PR_AMT_TYPE defaults; installer fixtures include two edition rows.',
  STATE_MAST: 'MS_YEAR.cs:1504-1595 never copies this shared geography table; it has no CO_CODE.',
  COUNTRY_MAST: 'MS_YEAR.cs:1504-1595 never copies this shared geography table; it has no CO_CODE.',
  COL_MAST: 'Desktop grid-caption overrides are not currently copied into a web company.',
  YEAR_MAST:
    'Web creates the current April-to-March year dynamically; the captured installer contains its three historical template years.',
  LOCT_MAST:
    'Web creates Main Counter with the BRANCH posting account required by Stock In/Out (N91/G105), rather than the installer location text.',
};

type Row = Record<string, unknown>;

function fixture(table: (typeof TABLES)[number]): Row[] {
  return JSON.parse(readFileSync(resolve(fixtureDir, `${table}.json`), 'utf8')) as Row[];
}

// New-company projection, independently derived from MS_YEAR.cs:1562-1590.
// Fixture company 00 is not the source. Columns absent from the desktop INSERT stay NULL in SQL.
const COPIED_COLUMNS: Partial<Record<(typeof TABLES)[number], string[]>> = {
  BAL_GR: [
    'CO_CODE',
    'TRAD_TYPE',
    'TRAD_NAME',
    'SALE_AC',
    'PURC_AC',
    'CLOSING_AC',
    'OP_AC',
    'TRAD_AMT',
    'TRAD_WT',
    'CLG_AC',
  ],
  CO_SET_NEW: [
    'CO_CODE',
    'COUNTER_STK',
    'ESTMATE_BANK_LOCK',
    'OLD_PURC_TOUCH',
    'NEGATIVE_STK_SALE',
    'SL_NWT_LOCK',
    'WH_BILL_IMG',
    'PROFIT_RPT_TYPE',
    'WEB_IMAGE',
    'WEB_PATH',
    'QR_CODE_GEN',
    'OS_BILL_SMS',
    'SL_BILL_IMG',
    'TOT_FINE_STK_TYPE',
    'OPBL_TRFR_BTN',
    'TAG_VCH_AUTO_SAVE',
    'DESIGN_HELP',
    'SALES_WITH_HMTAX',
    'TILE_MENU',
    'PR_RATE_ROF',
    'LEN_IMG_PATH',
    'SL_TDS_TAX',
    'PR_TDS_TAX',
    'OS_FINE_INT',
    'PURC_WITH_HMTAX',
    'SL_TAG_WT_DIFF',
    'WAPP_DELAY',
    'COUNTRY_ID',
    'WAPP_SL_PRINT',
    'BILL_PROFIT',
    'OLD_GOLD_TYPE',
    'TAG_ENTRY_DESIGN_GEN',
    'ORD_IMG_PRINT',
    'OS_BILL_ORNA_ISU',
    'PURC_LOT',
    'MOBILE_HELP',
    'PRINT_FORM_BTN',
    'FONT_CHANGE',
    'FONT_SIZE',
    'FONT_NAME',
    'FONT_STYLE_TYPE',
    'GRID_ROW_HIGHT',
    'TOT_AMT_ROF',
    'ESTMATE_TAX',
    'TAG_AUTO_PRINT',
    'RPT_TOT_SHOW',
    'DEFAULT_REMINDER',
    'VCH_DESC_HELP_LENT',
    'ORD_TAG_STK_LESS',
    'BRANCH_ALL_AC_SHOW',
    'SL_MRP_TAX_REVERC',
    'EMP_AS_USER',
    'WAPP_IMG_GWT',
    'YEAR_GOLD_SL',
    'YEAR_SILVER_SL',
    'F_DISC_DATE',
    'T_DISC_DATE',
    'DHRN_IMG_PRINT',
    'LBR_WITH_GHT',
    'APR_IMG_PRINT',
    'OTH_ITM_WT_REMOVE',
    'SILVER_THREE_DIGIT',
    'KR_DESIGN_IMG_PRINT',
    'ITM_WITH_LOT_STK',
    'USER_KR_TOUCH_HIDE',
    'CUR_DAY_POSTING',
    'MAIN_FONT_CHANGE',
    'STK_LMIT_WITH_DESIGN',
    'ITM_FINE_LOCK',
  ],
  EMP_MAST: [
    'CO_CODE',
    'EMP_CODE',
    'EMP_NAME',
    'USER_NAME',
    'EMP_TYPE',
    'EMP_AC',
    'EMP_AMT',
    'MAIN_USER',
  ],
  GROUP_MAST: [
    'CO_CODE',
    'GR_CODE',
    'GR_NAME',
    'GR_TYPE',
    'TRAD_TYPE',
    'GR_TOUCH',
    'GR_PURC_TOUCH',
    'MELTING_PRC',
    'GR_RATE',
    'WEST_PRC',
    'SALE_AC',
    'PURC_AC',
    'HSN_CODE',
    'MAIN_USER',
    'TAX_PRC',
    'AVG_TOUCH',
    'AVG_FINE',
    'AVG_NWT',
    'DAY_OP_PCS',
    'DAY_OP_WT',
    'DAY_CL_PCS',
    'DAY_CL_WT',
  ],
  ITEM_MAST: [
    'CO_CODE',
    'IT_CODE',
    'IT_NAME',
    'IT_TYPE',
    'TAG_TYPE',
    'PR_CODE',
    'GR_CODE',
    'TRAD_TYPE',
    'UNIT_NAME',
    'RATE_TYPE',
    'HSN_CODE',
    'ITEM_RATE',
    'LBR_PRC',
    'CON_PRC',
    'DISC_PRC',
    'IT_TOUCH',
    'IT_WEST',
    'OTHER_RATE',
    'MIN_STK',
    'MAIN_USER',
    'AVG_TOUCH',
    'AVG_FINE',
    'AVG_NWT',
    'AC_ITEM',
    'STK_DISPLAY',
    'OTH_RATE',
    'AVG_RATE',
    'SAFE_NAME',
    'DATA_TRFR',
    'IT_BAG_WT',
    'IT_LBR_RATE',
    'UNICODE_NAME',
    'TAG_IDTL_COL',
  ],
  PRODUCT_MAST: ['CO_CODE', 'PR_CODE', 'PR_NAME', 'MAIN_USER'],
  TABLE_MAST: ['CO_CODE', 'LC_CODE', 'TABLE_CODE', 'TABLE_NAME'],
};
const NOT_COPIED = ['WEIGHT_MAST', 'MFG_MAST', 'STATE_MAST', 'COUNTRY_MAST'];

function companyFixture(table: (typeof TABLES)[number], coCode: string): Row[] {
  const columns = COPIED_COLUMNS[table];
  if (!columns) return fixture(table);
  return fixture(table)
    .filter((row) => row.CO_CODE === '01')
    .map((row) =>
      Object.fromEntries(
        Object.keys(row).map((column) => [
          column,
          column === 'CO_CODE' ? coCode : columns.includes(column) ? row[column] : null,
        ]),
      ),
    );
}

function scalar(value: unknown): string | null {
  if (value === null || value === undefined) return null;
  if (value instanceof Date) return value.toISOString().slice(0, 10);
  if (typeof value === 'object' && value && 'toString' in value) return String(value);
  return typeof value === 'string' && /^\d{4}-\d{2}-\d{2}T/.test(value)
    ? value.slice(0, 10)
    : String(value);
}

function canonical(rows: Row[], columns: string[]): string[] {
  return rows
    .map((row) =>
      JSON.stringify(Object.fromEntries(columns.map((column) => [column, scalar(row[column])]))),
    )
    .sort();
}

databaseDescribe('new-company desktop template masters', () => {
  let owner: PrismaClient;

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
    });
    const tables = (await owner.$queryRawUnsafe(
      `SELECT table_name FROM information_schema.columns
       WHERE table_schema='public' AND column_name='tenant_id'`,
    )) as Array<{ table_name: string }>;
    for (const { table_name: table } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    await seedCompany(owner, TENANT, CO, { coName: 'Template Comparison', lcCode: '01' });
  });

  afterAll(async () => {
    if (!owner) return;
    const tables = (await owner.$queryRawUnsafe(
      `SELECT table_name FROM information_schema.columns
       WHERE table_schema='public' AND column_name='tenant_id'`,
    )) as Array<{ table_name: string }>;
    for (const { table_name: table } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    await owner.$disconnect();
  });

  for (const table of TABLES) {
    it(`${table} matches the installer template or its reviewed exception`, async () => {
      const expected = companyFixture(table, CO);
      const columns = Object.keys(expected[0] ?? {});
      expect(columns.length, `${table} fixture must have business columns`).toBeGreaterThan(0);
      const select = columns.map((column) => `"${column}"`).join(',');
      const actual = (await owner.$queryRawUnsafe(
        `SELECT ${select} FROM "${table}" WHERE tenant_id=$1`,
        TENANT,
      )) as Row[];
      const expectedRows = canonical(expected, columns);
      const actualRows = canonical(actual, columns);
      const reason = EXCEPTIONS[table];

      if (reason) {
        // A stale exception is a defect too: remove it once provisioning reaches exact parity.
        expect(actualRows, `${table} exception is stale: ${reason}`).not.toEqual(expectedRows);
      } else {
        expect(actualRows, `${table} has no approved provisioning exception`).toEqual(expectedRows);
      }
    });
  }

  it('leaves masters absent when the desktop does not copy them', async () => {
    for (const table of NOT_COPIED) {
      const rows = await owner.$queryRawUnsafe<Row[]>(
        `SELECT * FROM "${table}" WHERE tenant_id=$1`,
        TENANT,
      );
      expect(rows, table).toEqual([]);
    }
  });

  it('rewrites only company identity for another fresh company, and preserves retries and edits', async () => {
    await seedCompany(owner, TENANT, '02');
    for (const table of Object.keys(COPIED_COLUMNS) as (typeof TABLES)[number][]) {
      const expected = companyFixture(table, '02');
      const columns = Object.keys(expected[0]!);
      const rows = await owner.$queryRawUnsafe<Row[]>(
        `SELECT * FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='02'`,
        TENANT,
      );
      expect(canonical(rows, columns), table).toEqual(canonical(expected, columns));
    }
    await owner.$executeRawUnsafe(
      `UPDATE "ITEM_MAST" SET "IT_NAME"='Edited' WHERE tenant_id=$1 AND "CO_CODE"='02' AND "IT_CODE"='999'`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='02' AND "PR_CODE"='FN'`,
      TENANT,
    );
    const snapshot = async () => {
      const result: Record<string, string[]> = {};
      for (const table of Object.keys(COPIED_COLUMNS)) {
        const rows = await owner.$queryRawUnsafe<Row[]>(
          `SELECT * FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='02'`,
          TENANT,
        );
        result[table] = canonical(rows, Object.keys(rows[0] ?? {}).sort());
      }
      return result;
    };
    const before = await snapshot();
    await seedCompany(owner, TENANT, '02');
    expect(await snapshot()).toEqual(before);
  });

  it('does not backfill an established company that has no template masters', async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,'03','Existing')`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME") VALUES ($1,'03','CASH','Existing cash')`,
      TENANT,
    );
    await seedCompany(owner, TENANT, '03');
    for (const table of Object.keys(COPIED_COLUMNS)) {
      const rows = await owner.$queryRawUnsafe<Row[]>(
        `SELECT * FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='03'`,
        TENANT,
      );
      expect(rows, table).toEqual([]);
    }
  });

  it('retains all 22 G82 tax keys and their posting-account fallback', async () => {
    const rows = await owner.$queryRawUnsafe<Row[]>(
      `SELECT * FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    expect(rows).toHaveLength(22);
    expect(rows.every((row) => row.TAX_AC === null)).toBe(true);
    const parents = rows.filter((row) => Number(row.SR_NO) === 0);
    expect(parents.map((row) => [row.TAX_CODE, Number(row.TAX_PRC)]).sort()).toEqual([
      ['00', 0],
      ['10', 3],
      ['11', 5],
      ['12', 12],
      ['13', 18],
      ['14', 28],
      ['20', 0.1],
    ]);
    for (const code of ['10', '11', '12', '13', '14']) {
      expect(
        rows
          .filter((row) => row.TAX_CODE === code)
          .map((row) => Number(row.SR_NO))
          .sort(),
      ).toEqual([0, 1, 2, 3]);
    }
  });

  it('keeps the exception register exact and documented', () => {
    expect(Object.keys(EXCEPTIONS).sort()).toEqual(
      TABLES.filter((table) => table !== 'AC_GROUP' && !COPIED_COLUMNS[table]).sort(),
    );
    for (const reason of Object.values(EXCEPTIONS))
      expect(reason?.trim().length).toBeGreaterThan(20);
  });
});
