import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  CO_SET_NEW_COLUMNS,
  provisionCompanySettings,
} from '../src/modules/masters/companySettings.js';
import { cloneCompany, COMPANY_CLONE_TABLES } from '../src/modules/masters/companyClone.js';
import { createYear } from '../src/modules/masters/year.js';

/**
 * Desktop company provisioning (MS_YEAR.cs:1530-1531, 1569-1570): CO_SET_NEW is cloned from an
 * existing company, either the copy-source or the '01' template. Asserted over the FULL 68-column
 * copy so a dropped configuration column fails here rather than silently changing shop behaviour.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'company-settings-db';
const TEMPLATE = '01';
const NEW_CO = '42';
const YEAR = '2024-2025';

databaseDescribe('database-backed company settings provisioning', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [...COMPANY_CLONE_TABLES.map((t) => t.table), 'YEAR_MAST']) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  /** Seed the template company with a distinguishable value in every cloned column. */
  const seedTemplate = async (): Promise<Record<string, unknown>> => {
    const values: Record<string, unknown> = {};
    // Numeric columns per the restored desktop schema (realdb-schema-full.json → CO_SET_NEW);
    // seeding text into these would fail the insert and mask a real copy defect.
    const numeric = new Set([
      'FONT_SIZE',
      'FONT_STYLE_TYPE',
      'GRID_ROW_HIGHT',
      'PR_RATE_ROF',
      'TOT_AMT_ROF',
      'VCH_DESC_HELP_LENT',
      'WAPP_DELAY',
      'YEAR_GOLD_SL',
      'YEAR_SILVER_SL',
    ]);
    const dates = new Set(['F_DISC_DATE', 'T_DISC_DATE']);
    for (const column of CO_SET_NEW_COLUMNS) {
      values[column] = dates.has(column)
        ? new Date('2024-04-01T00:00:00')
        : numeric.has(column)
          ? 7
          : 'Y';
    }
    const cols = CO_SET_NEW_COLUMNS.map((c) => `"${c}"`).join(',');
    const ph = CO_SET_NEW_COLUMNS.map((_, i) => `$${i + 3}`).join(',');
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE",${cols}) VALUES ($1,$2,${ph})`,
      TENANT,
      TEMPLATE,
      ...CO_SET_NEW_COLUMNS.map((c) => values[c]),
    );
    return values;
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  beforeEach(cleanup);

  it('clones every desktop configuration column from the template company', async () => {
    const seeded = await seedTemplate();

    const written = await provisionCompanySettings(runtime, TENANT, NEW_CO);
    expect(written).toBe(1);

    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT * FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      NEW_CO,
    );
    expect(rows).toHaveLength(1);
    // Compare dates by LOCAL parts: toISOString() would shift a local midnight back a day and
    // report a copy defect that does not exist.
    const norm = (v: unknown): string =>
      v instanceof Date
        ? `${v.getFullYear()}-${String(v.getMonth() + 1).padStart(2, '0')}-${String(v.getDate()).padStart(2, '0')}`
        : String(v ?? '').trim();
    for (const column of CO_SET_NEW_COLUMNS) {
      expect(norm(rows[0]![column]), `CO_SET_NEW.${column}`).toBe(norm(seeded[column]));
    }
  });

  it('does not overwrite an existing company configuration', async () => {
    await seedTemplate();
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","COUNTER_STK") VALUES ($1,$2,'N')`,
      TENANT,
      NEW_CO,
    );

    const written = await provisionCompanySettings(runtime, TENANT, NEW_CO);
    expect(written).toBe(0);

    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "COUNTER_STK" FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      NEW_CO,
    );
    expect(rows).toHaveLength(1);
    expect(String(rows[0]!.COUNTER_STK).trim()).toBe('N');
  });

  it('replace: true reproduces the desktop copy-company clear-then-clone', async () => {
    await seedTemplate();
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","COUNTER_STK") VALUES ($1,$2,'N')`,
      TENANT,
      NEW_CO,
    );

    const written = await provisionCompanySettings(runtime, TENANT, NEW_CO, { replace: true });
    expect(written).toBe(1);

    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "COUNTER_STK" FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      NEW_CO,
    );
    expect(rows).toHaveLength(1);
    expect(String(rows[0]!.COUNTER_STK).trim()).toBe('Y');
  });

  it('writes nothing when the source company has no configuration row', async () => {
    const written = await provisionCompanySettings(runtime, TENANT, NEW_CO);
    expect(written).toBe(0);
  });

  it('provisions configuration as part of creating a year', async () => {
    await seedTemplate();
    await createYear(runtime, { tenantId: TENANT, coCode: NEW_CO }, { coYear: YEAR });

    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      NEW_CO,
    );
    expect(rows[0]!.n).toBe(1);
  });

  // Phase F: the desktop clones 17 master/configuration tables when a company is provisioned
  // (MS_YEAR.cs:1511-1553), not just CO_SET_NEW.
  it('clones the desktop master set from the template company', async () => {
    // Seed one row per table in the template so each clone has something to copy.
    await seedTemplate();
    await owner.$executeRawUnsafe(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME","MAIN_USER")
       VALUES ($1,$2,'01','Rings','tmpl')`,
      TENANT,
      TEMPLATE,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC")
       VALUES ($1,$2,'G3',1,'GST 3%',3)`,
      TENANT,
      TEMPLATE,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","MAIN_USER")
       VALUES ($1,$2,'20','Gold Group','tmpl')`,
      TENANT,
      TEMPLATE,
    );

    // BOOK_DETL carries the posting account and main book that `bookPolicy` reads to post a voucher.
    // The web read it but never wrote it, so a cloned company had books that could not post.
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME",
         "BOOK_TYPE","ITM_TYPE","BOOK_INOUT","AC_CODE","AC_NAME","MAIN_BOOK","RESET_BOOK","DATA_TYPE")
       VALUES ($1,$2,'01','SAL',1,'SALES','SAL','S','G','O','SALEAC','Sales A/c','SALE','Y','L')`,
      TENANT,
      TEMPLATE,
    );

    const result = await cloneCompany(runtime, TENANT, NEW_CO);

    // Every seeded template table produced rows for the new company.
    expect(result.written.BOOK_DETL).toBe(1);
    expect(result.written.PRODUCT_MAST).toBe(1);
    expect(result.written.TAX_MAST).toBe(1);
    expect(result.written.GROUP_MAST).toBe(1);
    expect(result.written.CO_SET_NEW).toBe(1);

    const product: any[] = await owner.$queryRawUnsafe(
      `SELECT "PR_NAME","MAIN_USER" FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      NEW_CO,
    );
    expect(product).toHaveLength(1);
    expect(String(product[0]!.PR_NAME).trim()).toBe('Rings');
    // MAIN_USER is carried across, which is what the desktop clone does.
    expect(String(product[0]!.MAIN_USER).trim()).toBe('tmpl');

    // Assert the FULL 14-column BOOK_DETL shape the desktop writes, not just that a row exists: a
    // partial clone would leave the posting account or main book blank and break voucher posting.
    const bookDetl: any[] = await owner.$queryRawUnsafe(
      `SELECT "LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","BOOK_TYPE","ITM_TYPE",
              "BOOK_INOUT","AC_CODE","AC_NAME","MAIN_BOOK","RESET_BOOK","DATA_TYPE"
         FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      NEW_CO,
    );
    expect(bookDetl).toHaveLength(1);
    const detl = bookDetl[0]!;
    expect(String(detl.LC_CODE).trim()).toBe('01');
    expect(String(detl.CO_BOOK).trim()).toBe('SAL');
    expect(Number(detl.SR_NO)).toBe(1);
    expect(String(detl.BOOK_NAME).trim()).toBe('SALES');
    expect(String(detl.BOOK_SNAME).trim()).toBe('SAL');
    expect(String(detl.BOOK_TYPE).trim()).toBe('S');
    expect(String(detl.ITM_TYPE).trim()).toBe('G');
    expect(String(detl.BOOK_INOUT).trim()).toBe('O');
    expect(String(detl.AC_CODE).trim()).toBe('SALEAC');
    expect(String(detl.AC_NAME).trim()).toBe('Sales A/c');
    expect(String(detl.MAIN_BOOK).trim()).toBe('SALE');
    expect(String(detl.RESET_BOOK).trim()).toBe('Y');
    expect(String(detl.DATA_TYPE).trim()).toBe('L');

    // Non-destructive by default: re-running skips tables that already have rows.
    const again = await cloneCompany(runtime, TENANT, NEW_CO);
    expect(again.skipped).toContain('PRODUCT_MAST');
    expect(again.written.PRODUCT_MAST).toBeUndefined();
    const still: any[] = await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      NEW_CO,
    );
    expect(still[0]!.n).toBe(1);
  });

  it('refuses to clone a company onto itself', async () => {
    await expect(
      cloneCompany(runtime, TENANT, TEMPLATE, { sourceCoCode: TEMPLATE }),
    ).rejects.toThrow(/must differ/);
  });
});
