import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  dataExportPackage,
  dataExportPreview,
  markDataTransferFlags,
  resetDataTransferFlags,
} from '../src/modules/utilities/dataExport.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'data-export';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const row of rows)
    await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seed() {
  await exec(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","DATA_TRFR","MAIN_USER")
     VALUES ($1,$2,$3,'EX001','Export Customer','L','N','tester')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","LEDR_KEY","BOOK_NAME","AC_CODE","DR_AMT","CR_AMT","IT_TYPE","SIGN","FINE_WT","DATA_TYPE","DATA_TRFR","MAIN_USER")
     VALUES ($1,$2,$3,$4,'026','00001','GST','2024-04-10',$5,'SALES','EX001',100,0,'A','D',0,'A','N','tester')`,
    TENANT,
    CO,
    LC,
    YEAR,
    `${CO}${LC}${YEAR}02600000101`,
  );
}

function rowFor(preview: Awaited<ReturnType<typeof dataExportPreview>>, table: string) {
  const row = preview.tables.find((entry) => entry.table === table);
  if (!row) throw new Error(`${table} missing from preview`);
  return row;
}

describe.runIf(RUN)('UT_EXPORT data export utility', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('previews scoped DATA_TRFR rows, packages them, marks exported, and resets flags', async () => {
    const preview = await dataExportPreview(runtime, scope);
    expect(preview.kind).toBe('datacare.ut-export/1.0');
    expect(rowFor(preview, 'AC_MAST')).toMatchObject({
      rowCount: 1,
      pendingRows: 1,
      hasDataTransferFlag: true,
    });
    expect(rowFor(preview, 'AC_DATA')).toMatchObject({
      rowCount: 1,
      pendingRows: 1,
      hasDataTransferFlag: true,
    });
    expect(preview.totals.pendingRows).toBeGreaterThanOrEqual(2);

    const pkg = await dataExportPackage(runtime, scope, { pendingOnly: true });
    expect(pkg.pendingOnly).toBe(true);
    const accountMaster = pkg.tables.AC_MAST;
    const accountEntries = pkg.tables.AC_DATA;
    if (!accountMaster || !accountEntries)
      throw new Error('Expected AC_MAST and AC_DATA export tables');
    expect(accountMaster.rows).toHaveLength(1);
    expect(accountMaster.rows[0]).toMatchObject({ AC_CODE: 'EX001', DATA_TRFR: 'N' });
    expect(accountEntries.rows).toHaveLength(1);
    expect(accountEntries.rows[0]).toMatchObject({ AC_CODE: 'EX001', DATA_TRFR: 'N' });

    const marked = await markDataTransferFlags(runtime, scope, { state: 'Y', pendingOnly: true });
    expect(marked.updated.AC_MAST).toBe(1);
    expect(marked.updated.AC_DATA).toBe(1);

    const afterMark = await dataExportPreview(runtime, scope);
    expect(rowFor(afterMark, 'AC_MAST').pendingRows).toBe(0);
    expect(rowFor(afterMark, 'AC_DATA').pendingRows).toBe(0);

    const reset = await resetDataTransferFlags(runtime, scope);
    expect(reset.updated.AC_MAST).toBe(1);
    expect(reset.updated.AC_DATA).toBe(1);

    const afterReset = await dataExportPreview(runtime, scope);
    expect(rowFor(afterReset, 'AC_MAST').pendingRows).toBe(1);
    expect(rowFor(afterReset, 'AC_DATA').pendingRows).toBe(1);
  });
});
