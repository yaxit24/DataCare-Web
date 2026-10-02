import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N18 data migration 20260929010000_tag_transfer_book, run against real rows.
 *
 * Web provisioning used to create the Tag Transfer book with MAIN_BOOK 'TAG TRANSFER' and its own code as the short
 * name. The desktop opens Tag Transfer only on 'TAG TRFR' books (MDI_FORM.cs:8664) and posts stock only for them
 * (Ac_Stock.cs:54-56), so those books must move — and nothing the desktop wrote may.
 *
 * The statements are the migration file's own, executed one by one (a raw Prisma call takes one statement) and scoped
 * to this test's tenant so a shared database is not touched.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tag-transfer-migration';
const sql = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20260929010000_tag_transfer_book/migration.sql',
    import.meta.url,
  ),
  'utf8',
);
/** The file's statements, split at line-final semicolons outside the dollar-quoted preflight block. */
const statements: string[] = [];
{
  let current: string[] = [];
  let quoted = false;
  for (const line of sql.split('\n')) {
    if (/^\s*--/.test(line)) continue;
    current.push(line);
    if ((line.match(/\$preflight\$/g) ?? []).length % 2 === 1) quoted = !quoted;
    if (!quoted && /;\s*$/.test(line)) {
      statements.push(current.join('\n').trim().replace(/;\s*$/, ''));
      current = [];
    }
  }
}

(enabled ? describe : describe.skip)('N18 Tag Transfer book migration', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const wipe = async () => {
    for (const table of ['BOOK_DETL', 'BOOK_DATA'])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  };
  const books = () =>
    owner.$queryRawUnsafe(
      `SELECT "CO_BOOK","BOOK_SNAME","MAIN_BOOK","BOOK_TBL_NAME" FROM "BOOK_DATA" WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
      TENANT,
    );

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
  });
  afterAll(async () => {
    if (owner) await wipe();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('is one guarded transaction: complete tenant visibility, or it refuses to run', async () => {
    expect(statements[0]).toBe('BEGIN');
    expect(statements[statements.length - 1]).toBe('COMMIT');
    const preflight = statements.find((statement) => statement.startsWith('DO $preflight$'));
    expect(preflight).toBeDefined();
    expect(statements).toContain('SET LOCAL row_security=off');
    // The runtime role is subject to row-level security, so it must be refused rather than update nothing.
    await expect(runtime.$executeRawUnsafe(preflight!)).rejects.toThrow(
      'tag transfer book migration requires a migration role with complete tenant visibility',
    );
    await expect(owner.$executeRawUnsafe(preflight!)).resolves.toBeDefined();
  });

  it('moves web-provisioned TAG TRANSFER books to the desktop TAG TRFR / TAGTR and leaves every other book alone', async () => {
    const insertBook = (row: Record<string, unknown>) => {
      const columns = Object.keys(row);
      return owner.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,${columns.map((c) => `"${c}"`).join(',')})
         VALUES ($1,${columns.map((_, i) => `$${i + 2}`).join(',')})`,
        TENANT,
        ...columns.map((c) => row[c]),
      );
    };
    const common = { CO_CODE: '01', LC_CODE: '01', BOOK_INOUT: 'O', CUR_USE: 'Y' };
    // What the old web provisioning wrote: the code as the short name, no register table.
    await insertBook({
      ...common,
      CO_BOOK: 'TTR',
      BOOK_NAME: 'Tag Transfer',
      BOOK_SNAME: 'TTR',
      MAIN_BOOK: 'TAG TRANSFER',
    });
    // A web book an operator renamed: its short name and table are kept.
    await insertBook({
      ...common,
      CO_BOOK: 'TT2',
      BOOK_NAME: 'Branch Transfer',
      BOOK_SNAME: 'BRTR',
      MAIN_BOOK: 'TAG TRANSFER',
      BOOK_TBL_NAME: 'BAR_CAN_DATA',
    });
    // Desktop books: never touched.
    await insertBook({
      ...common,
      CO_BOOK: '121',
      BOOK_NAME: 'Tag Trfr',
      BOOK_SNAME: 'TAGTR',
      MAIN_BOOK: 'TAG TRFR',
      BOOK_TBL_NAME: 'BAR_CAN_DATA',
    });
    await insertBook({
      ...common,
      CO_BOOK: '016',
      BOOK_NAME: 'Tag Cancel',
      BOOK_SNAME: 'TGCAN',
      MAIN_BOOK: 'TAG CANCEL',
      BOOK_TBL_NAME: 'BAR_CAN_DATA',
    });
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","MAIN_BOOK","BOOK_SNAME")
       VALUES ($1,'01','01','TTR',1,'TAG TRANSFER','TTR'),($1,'01','01','016',1,'TAG CANCEL','TGCAN')`,
      TENANT,
    );

    const updates = statements.filter((statement) => statement.startsWith('UPDATE'));
    expect(updates).toHaveLength(2);
    await owner.$transaction(async (tx) => {
      for (const update of updates) {
        const scoped = update.replace(
          `WHERE "MAIN_BOOK" = 'TAG TRANSFER'`,
          `WHERE "MAIN_BOOK" = 'TAG TRANSFER' AND tenant_id = $1`,
        );
        expect(scoped).not.toBe(update);
        await tx.$executeRawUnsafe(scoped, TENANT);
      }
    });

    expect(await books()).toEqual([
      {
        CO_BOOK: '016',
        BOOK_SNAME: 'TGCAN',
        MAIN_BOOK: 'TAG CANCEL',
        BOOK_TBL_NAME: 'BAR_CAN_DATA',
      },
      { CO_BOOK: '121', BOOK_SNAME: 'TAGTR', MAIN_BOOK: 'TAG TRFR', BOOK_TBL_NAME: 'BAR_CAN_DATA' },
      { CO_BOOK: 'TT2', BOOK_SNAME: 'BRTR', MAIN_BOOK: 'TAG TRFR', BOOK_TBL_NAME: 'BAR_CAN_DATA' },
      { CO_BOOK: 'TTR', BOOK_SNAME: 'TAGTR', MAIN_BOOK: 'TAG TRFR', BOOK_TBL_NAME: 'BAR_CAN_DATA' },
    ]);
    expect(
      await owner.$queryRawUnsafe(
        `SELECT "CO_BOOK","MAIN_BOOK","BOOK_SNAME" FROM "BOOK_DETL" WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
        TENANT,
      ),
    ).toEqual([
      { CO_BOOK: '016', MAIN_BOOK: 'TAG CANCEL', BOOK_SNAME: 'TGCAN' },
      { CO_BOOK: 'TTR', MAIN_BOOK: 'TAG TRFR', BOOK_SNAME: 'TAGTR' },
    ]);
  });
});
