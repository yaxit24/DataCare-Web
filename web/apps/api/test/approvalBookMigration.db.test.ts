import { existsSync, readFileSync } from 'node:fs';
import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N211 / G224 migration contract. The desktop only opens MAIN_BOOK 'APR ISU'/'APR RTN'
 * (MDI_FORM.cs:8300-8317), maps both to APR_DATA/APR_DETL (MS_UPDATE.cs:7833), and stamps the
 * configured BOOK_SNAME plus MAIN_BOOK into APR_DETL/APR_IDTL/MAIN_STOCK (TR_APR_ISU.cs:6166-6169,
 * :6351-6354; Ac_Stock.cs:60-85). Old web provisioning and its writer used the web-only families
 * APPROVAL ISSUE/APPROVAL RETURN and EMP ISU/EMP REC with TOUR/TOURR. This test requires an
 * idempotent, exact-match-only backfill that leaves desktop/custom/unrelated values untouched.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'appr-book-migration';
const migrationUrl = new URL(
  '../../../packages/db/prisma/migrations/20261101090000_approval_book_identity/migration.sql',
  import.meta.url,
);
const sql = existsSync(migrationUrl) ? readFileSync(migrationUrl, 'utf8') : '';
const statements: string[] = [];
if (sql) {
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
const dml = statements.filter((statement) => /^(UPDATE|INSERT)/.test(statement));

(enabled ? describe : describe.skip)('N211 approval book identity migration', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const wipe = async () => {
    for (const table of [
      'MAIN_STOCK',
      'APR_IDTL',
      'APR_DETL',
      'BAR_DETL',
      'BOOK_DETL',
      'BOOK_DATA',
    ])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  };
  const run = () =>
    withTenant(runtime, TENANT, async (tx: any) => {
      for (const statement of dml) await tx.$executeRawUnsafe(statement);
    });
  const snapshot = async () => ({
    books: await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK" book,"BOOK_SNAME" short,"MAIN_BOOK" main,"BOOK_TBL_NAME" header,"BOOK_TBL_DETL" detail
         FROM "BOOK_DATA" WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
      TENANT,
    ),
    slots: await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK" book,"MAIN_BOOK" main,"BOOK_SNAME" short FROM "BOOK_DETL"
        WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
      TENANT,
    ),
    details: await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK" book,"VCH_TYPE" type,"BOOK_NAME" name FROM "APR_DETL"
        WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
      TENANT,
    ),
    subdetails: await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK" book,"VCH_TYPE" type,"BOOK_NAME" name FROM "APR_IDTL"
        WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
      TENANT,
    ),
    stock: await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK" book,"VCH_TYPE" type,"BOOK_NAME" name FROM "MAIN_STOCK"
        WHERE tenant_id=$1 ORDER BY "CO_BOOK"`,
      TENANT,
    ),
  });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL") VALUES
       ($1,'01','01','TUR','Approval Issue','TUR','APPROVAL ISSUE','O','Y',NULL,NULL),
       ($1,'01','01','TRR','Approval Return','TRR','APPROVAL RETURN','I','Y','CUSTOM_HEADER','CUSTOM_DETAIL'),
       ($1,'01','01','028','Desktop Approval','APRI','APR ISU','O','Y','APR_DATA','APR_DETL'),
       ($1,'01','01','ZZZ','Unrelated','TOUR','TOUR SALES','O','Y','RATE_CUT_DATA','RATE_CUT_ISU')`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME",
         "MAIN_BOOK","BOOK_INOUT","AC_CODE") VALUES
       ($1,'01','01','TUR',1,'Approval Issue','TUR','APPROVAL ISSUE','O','OS'),
       ($1,'01','01','TRR',1,'Approval Return','TRR','APPROVAL RETURN','I','OS'),
       ($1,'01','01','028',1,'Desktop Approval','APRI','APR ISU','O','00001')`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_TYPE","BOOK_NAME") VALUES
       ($1,'01','01','2026-2027','TUR','00001',1,'TOUR','EMP ISU'),
       ($1,'01','01','2026-2027','TRR','00001',1,'TOURR','EMP REC'),
       ($1,'01','01','2026-2027','028','00001',1,'APRI','APR ISU'),
       ($1,'01','01','2026-2027','ZZZ','00001',1,'TOUR','EMP ISU')`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "APR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_TYPE","BOOK_NAME") VALUES
       ($1,'01','01','2026-2027','TUR','00001',1,1,'TOUR','EMP ISU'),
       ($1,'01','01','2026-2027','028','00001',1,1,'APRI','APR ISU')`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_TYPE","BOOK_NAME") VALUES
       ($1,'01','01','2026-2027','TUR','00001',1,1,'TOUR','EMP ISU'),
       ($1,'01','01','2026-2027','TRR','00001',1,1,'TOURR','EMP REC'),
       ($1,'01','01','2026-2027','028','00001',1,1,'APRI','APR ISU')`,
      TENANT,
    );
  });

  afterAll(async () => {
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('adds the desktop APR_DETL discount columns with their exact numeric storage', async () => {
    const columns = await owner.$queryRawUnsafe(
      `SELECT column_name,"numeric_precision"::int AS "precision","numeric_scale"::int AS "scale"
         FROM information_schema.columns
        WHERE table_schema='public' AND table_name='APR_DETL'
          AND column_name IN ('DISC_PRC','DISC_AMT') ORDER BY column_name`,
    );
    expect(columns).toEqual([
      { column_name: 'DISC_AMT', precision: 18, scale: 2 },
      { column_name: 'DISC_PRC', precision: 9, scale: 4 },
    ]);
  });

  it('ships as one guarded transaction and refuses an RLS-bound migration role', async () => {
    expect(sql, 'the N211 migration file is missing').not.toBe('');
    expect(statements[0]).toBe('BEGIN');
    expect(statements.at(-1)).toBe('COMMIT');
    expect(statements).toContain('SET LOCAL row_security=off');
    const preflight = statements.find((statement) => statement.startsWith('DO $preflight$'));
    expect(preflight).toBeDefined();
    await expect(runtime.$executeRawUnsafe(preflight!)).rejects.toThrow(
      'approval book identity backfill requires a migration role with complete tenant visibility',
    );
    await expect(owner.$executeRawUnsafe(preflight!)).resolves.toBeDefined();
  });

  it('renames only the old web families and their old web row stamps, preserves custom metadata, and is idempotent', async () => {
    expect(sql, 'the N211 migration file is missing').not.toBe('');
    await run();
    const after = await snapshot();
    expect(after.books).toEqual([
      { book: '028', short: 'APRI', main: 'APR ISU', header: 'APR_DATA', detail: 'APR_DETL' },
      {
        book: 'TRR',
        short: 'TRR',
        main: 'APR RTN',
        header: 'CUSTOM_HEADER',
        detail: 'CUSTOM_DETAIL',
      },
      { book: 'TUR', short: 'TUR', main: 'APR ISU', header: 'APR_DATA', detail: 'APR_DETL' },
      {
        book: 'ZZZ',
        short: 'TOUR',
        main: 'TOUR SALES',
        header: 'RATE_CUT_DATA',
        detail: 'RATE_CUT_ISU',
      },
    ]);
    expect(after.slots).toEqual([
      { book: '028', main: 'APR ISU', short: 'APRI' },
      { book: 'TRR', main: 'APR RTN', short: 'TRR' },
      { book: 'TUR', main: 'APR ISU', short: 'TUR' },
    ]);
    expect(after.details).toEqual([
      { book: '028', type: 'APRI', name: 'APR ISU' },
      { book: 'TRR', type: 'TRR', name: 'APR RTN' },
      { book: 'TUR', type: 'TUR', name: 'APR ISU' },
      { book: 'ZZZ', type: 'TOUR', name: 'EMP ISU' },
    ]);
    expect(after.subdetails).toEqual([
      { book: '028', type: 'APRI', name: 'APR ISU' },
      { book: 'TUR', type: 'TUR', name: 'APR ISU' },
    ]);
    expect(after.stock).toEqual([
      { book: '028', type: 'APRI', name: 'APR ISU' },
      { book: 'TRR', type: 'TRR', name: 'APR RTN' },
      { book: 'TUR', type: 'TUR', name: 'APR ISU' },
    ]);
    await run();
    expect(await snapshot()).toEqual(after);
  });

  it('leaves legacy returns unlinked when the source has zero or two BAR tag instances', async () => {
    // TR_APR_ISU.cs:6414-6417 and :6664-6669 reverse a tag by the real TAG_NO + VCH_SRNO.
    // A legacy line ordinal is therefore not a source identity when no unique BAR instance proves it.
    await owner.$executeRawUnsafe(
      `UPDATE "BOOK_DATA" SET "MAIN_BOOK"=CASE "CO_BOOK"
         WHEN 'TUR' THEN 'APPROVAL ISSUE' WHEN 'TRR' THEN 'APPROVAL RETURN' ELSE "MAIN_BOOK" END
        WHERE tenant_id=$1 AND "CO_BOOK" IN ('TUR','TRR')`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
          "VCH_TYPE","BOOK_NAME","INOUT_TYPE","VCH_SRNO","IT_CODE","TAG_NO","ISU_NO","ISU_SRNO") VALUES
       ($1,'01','01','2026-2027','TUR','00101',1,1,'TOUR','EMP ISU','O',1,'GOLD','NO-BAR',NULL,NULL),
       ($1,'01','01','2026-2027','TRR','00111',1,1,'TOURR','EMP REC','R',1,'GOLD','NO-BAR','00101',1),
       ($1,'01','01','2026-2027','TUR','00102',1,1,'TOUR','EMP ISU','O',1,'GOLD','TWO-BAR',NULL,NULL),
       ($1,'01','01','2026-2027','TRR','00112',1,1,'TOURR','EMP REC','R',1,'GOLD','TWO-BAR','00102',1)`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
          "IT_CODE","TAG_NO","VCH_SRNO") VALUES
       ($1,'01','01','2026-2027','TOP','00901',1,'GOLD','TWO-BAR',81001),
       ($1,'01','01','2026-2027','TOP','00902',1,'GOLD','TWO-BAR',81002)`,
      TENANT,
    );

    await run();

    expect(
      await owner.$queryRawUnsafe(
        `SELECT "VCH_NO" no,"ISU_YRCD" iy,"ISU_DBCD" ib,"ISU_LC_CODE" ilc,
                "VCH_SRNO"::int serial,"INOUT_TYPE" inout
           FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TRR' AND "VCH_NO" IN ('00111','00112')
          ORDER BY "VCH_NO"`,
        TENANT,
      ),
    ).toEqual([
      { no: '00111', iy: null, ib: null, ilc: null, serial: 1, inout: 'R' },
      { no: '00112', iy: null, ib: null, ilc: null, serial: 1, inout: 'R' },
    ]);
  });
});
