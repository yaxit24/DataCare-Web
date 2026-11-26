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
  GROUP_MAST:
    'Product groups are user masters; the current provisioner does not create installer product groups.',
  ITEM_MAST: 'Items are user masters; the current provisioner does not create installer items.',
  PRODUCT_MAST:
    'Products are user masters; the current provisioner does not create installer products.',
  TAX_MAST:
    'Web seeds the supported GST/TCS policy, including explicit parent and component rows (G82), rather than every installer tax row.',
  WEIGHT_MAST: 'The current provisioner does not create the desktop report weight-band defaults.',
  MFG_MAST: 'Manufacturing workflow defaults remain outside current web provisioning.',
  PRINT_MAST:
    'Crystal Reports print-file defaults are desktop-only; web reports use web renderers.',
  BAL_GR: 'The current provisioner does not create desktop trading-account balance groups.',
  CO_SET:
    'Web stores one company settings row with source-backed SL_AMT_TYPE/PR_AMT_TYPE defaults; installer fixtures include two edition rows.',
  CO_SET_NEW:
    'The current provisioner has no CO_SET_NEW row; web settings loaders retain their documented defaults.',
  EMP_MAST: 'Authentication users are tenant identities, not the installer employee placeholder.',
  TABLE_MAST: 'The current provisioner does not create the desktop table/counter placeholder.',
  STATE_MAST: 'Reference geography is not currently copied into each provisioned tenant.',
  COUNTRY_MAST: 'Reference geography is not currently copied into each provisioned tenant.',
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

function scalar(value: unknown): string | null {
  if (value === null || value === undefined) return null;
  if (value instanceof Date) return value.toISOString().slice(0, 10);
  if (typeof value === 'object' && value && 'toString' in value) return String(value);
  return String(value);
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
      const expected = fixture(table);
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

  it('keeps the exception register exact and documented', () => {
    expect(Object.keys(EXCEPTIONS).sort()).toEqual(
      TABLES.filter((table) => table !== 'AC_GROUP').sort(),
    );
    for (const reason of Object.values(EXCEPTIONS))
      expect(reason?.trim().length).toBeGreaterThan(20);
  });
});
