import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { dhrnOutstandingList } from '../src/modules/reports/reports.js';
import {
  REPORT_DATA_SLOT_COLUMNS,
  stageReportGrid,
} from '../src/modules/reports/reportGridStaging.js';

/**
 * Phase G — REPORT_DATA staging. Six supplied Crystal specs (UserDtlRpt, ReminderAll, DharnDue,
 * ItmStkBalance, ItmStkWithGrid, ItmStkWithOthWt) bind REPORT_DATA.COL_n rather than a typed table,
 * because the desktop uses it to print whatever its on-screen grid holds:
 *   RP_USER.cs:3534  → one row with SR_NO '0' carrying the grid COLUMN HEADERS
 *   RP_USER.cs:3542  → one row per grid row carrying that row's cell values
 * Without population those six reports render blank.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'report-grid-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';

databaseDescribe('database-backed report grid staging', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of ['REPORT_DATA', 'DHRN_REC_DATA', 'DHRN_ISU_DATA']) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
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

  it('writes the desktop header row plus one row per grid row', async () => {
    const written = await stageReportGrid(
      runtime,
      TENANT,
      { coCode: CO, lcCode: LC },
      {
        headers: ['Vch No', 'Party', 'Amount'],
        rows: [
          ['00001', 'Alpha', 1234.5],
          ['00002', 'Beta', null],
        ],
      },
    );
    expect(written).toBe(3); // header + 2 data rows

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO","COL_1","COL_2","COL_3","COL_4","LC_CODE"
         FROM "REPORT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "SR_NO"::int`,
      TENANT,
      CO,
    )) as Array<Record<string, any>>;
    expect(rows).toHaveLength(3);

    // SR_NO '0' carries the captions, exactly as RP_USER.cs:3534 writes them.
    expect(String(rows[0]!.SR_NO).trim()).toBe('0');
    expect(String(rows[0]!.COL_1).trim()).toBe('Vch No');
    expect(String(rows[0]!.COL_2).trim()).toBe('Party');
    expect(String(rows[0]!.COL_3).trim()).toBe('Amount');
    // Unused slots are blank, not null, so Crystal renders empty rather than failing.
    expect(String(rows[0]!.COL_4 ?? '')).toBe('');
    expect(String(rows[0]!.LC_CODE).trim()).toBe(LC);

    expect(String(rows[1]!.COL_1).trim()).toBe('00001');
    expect(String(rows[1]!.COL_2).trim()).toBe('Alpha');
    expect(String(rows[1]!.COL_3).trim()).toBe('1234.5');
    // A null cell stages as blank.
    expect(String(rows[2]!.COL_3 ?? '')).toBe('');
  });

  it('clears the company rows before repopulating, so re-running does not accumulate', async () => {
    const snapshot = { headers: ['A'], rows: [['1'], ['2']] } as const;
    await stageReportGrid(runtime, TENANT, { coCode: CO, lcCode: LC }, snapshot);
    await stageReportGrid(runtime, TENANT, { coCode: CO, lcCode: LC }, snapshot);
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "REPORT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    )) as Array<{ n: number }>;
    expect(rows[0]!.n).toBe(3);
  });

  it('drops values beyond the 33 desktop slots rather than failing', async () => {
    const headers = Array.from({ length: 40 }, (_, i) => `H${i + 1}`);
    await stageReportGrid(runtime, TENANT, { coCode: CO, lcCode: LC }, { headers, rows: [] });
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "COL_33" FROM "REPORT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    )) as Array<Record<string, any>>;
    expect(REPORT_DATA_SLOT_COLUMNS).toHaveLength(33);
    expect(String(rows[0]!.COL_33).trim()).toBe('H33');
  });

  it('stages the pledge-dues grid when the report runs', async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "DHRN_ISU_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME",
         "DHRN_AMT","INT_PRC")
       VALUES ($1,$2,$3,$4,'DHI','00001','BORR','Pledge Borrower',50000,12)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );

    const report = await dhrnOutstandingList(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
    });
    expect(report.rows.length).toBeGreaterThan(0);

    const staged = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO","COL_1","COL_2","COL_3","COL_6"
         FROM "REPORT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "SR_NO"::int`,
      TENANT,
      CO,
    )) as Array<Record<string, any>>;
    // Header row carries the supplied captions, then one row per displayed pledge.
    expect(staged.length).toBe(report.rows.length + 1);
    expect(String(staged[0]!.COL_1).trim()).toBe('Vch No');
    expect(String(staged[0]!.COL_3).trim()).toBe('Party');
    expect(String(staged[0]!.COL_6).trim()).toBe('Outstanding');
    expect(String(staged[1]!.COL_3).trim()).toBe('Pledge Borrower');
    expect(Number(staged[1]!.COL_6)).toBeCloseTo(50_000, 2);
  });
});
