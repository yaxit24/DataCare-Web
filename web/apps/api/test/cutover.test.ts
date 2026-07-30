import { describe, expect, it, vi } from 'vitest';
// The integration command is JavaScript by design and exports a dependency-injected test surface.
// @ts-expect-error no declaration file is needed for the CLI module
import { executeCutover } from '../integration/cutover.mjs';

const env = {
  CUTOVER_SOURCE_HOST: 'sql-source.internal',
  CUTOVER_SOURCE_PORT: '1433',
  CUTOVER_SOURCE_USER: 'cutover-reader',
  CUTOVER_SOURCE_PASSWORD: 'not-a-real-password',
  CUTOVER_SOURCE_DATABASE: 'DesktopErp',
  DATABASE_URL: 'postgresql://runtime:not-real@127.0.0.1:55433/datacare',
  CUTOVER_TENANT_ID: 'cutover-test',
};

describe('cutover command', () => {
  it('produces a machine-readable dry-run report without mutating the target', async () => {
    const replace = vi.fn();
    const closeSource = vi.fn();
    const closeTarget = vi.fn();
    const report = await executeCutover({
      args: ['--dry-run', '--tables=AC_MAST'],
      env,
      dependencies: {
        connectSource: async () => ({
          columns: async () => [
            { name: 'AC_CODE', type: 'varchar' },
            { name: 'BALANCE', type: 'decimal' },
          ],
          rows: async () => [
            { AC_CODE: 'A1', BALANCE: 10.25 },
            { AC_CODE: 'A2', BALANCE: 2.75 },
          ],
          close: closeSource,
        }),
        connectTarget: async () => ({
          columns: async () => [
            { name: 'tenant_id', type: 'text' },
            { name: 'row_id', type: 'bigint' },
            { name: 'AC_CODE', type: 'character varying' },
            { name: 'BALANCE', type: 'numeric' },
          ],
          sums: async () => ({ BALANCE: 13 }),
          replace,
          close: closeTarget,
        }),
      },
    });

    expect(replace).not.toHaveBeenCalled();
    expect(report).toMatchObject({
      schemaVersion: 1,
      mode: 'dry-run',
      status: 'passed',
      source: { host: 'sql-source.internal', port: 1433, database: 'DesktopErp' },
      target: { host: '127.0.0.1', port: 55433, database: 'datacare', tenant: 'cutover-test' },
      totals: { tables: 1, failedTables: 0, sourceRows: 2, loadedRows: 0, skippedRows: 2 },
      tables: [
        {
          table: 'AC_MAST',
          status: 'dry-run',
          sourceRows: 2,
          loadedRows: 0,
          skippedRows: 2,
          numericColumns: { BALANCE: { source: 13, target: 13, matches: true } },
        },
      ],
    });
    expect(typeof report.durationMs).toBe('number');
    expect(typeof report.tables[0].durationMs).toBe('number');
    expect(closeSource).toHaveBeenCalledOnce();
    expect(closeTarget).toHaveBeenCalledOnce();
  });

  it('copies EVERY column the source and target share, not a curated subset', async () => {
    // This is the proof behind attributing import-only columns to this path. Several desktop columns —
    // OLD_ISU_NO, OLD_ITEM_ADJ, DHRN_LIC_NO, REC_DATE, REMARKS — are assigned by UT_IMPORT and BtmSchm and
    // never by a transaction form, so the migration tool is where they are legitimately written. That is
    // only true if it copies the full shared column set rather than a hand-picked list.
    let replacedColumns: string[] = [];
    const report = await executeCutover({
      args: ['--tables=DHRN_ISU_DATA'],
      env,
      dependencies: {
        connectSource: async () => ({
          columns: async () => [
            { name: 'CO_CODE', type: 'varchar' },
            { name: 'DHRN_LIC_NO', type: 'varchar' },
            { name: 'OLD_ISU_NO', type: 'varchar' },
            { name: 'OLD_ITEM_ADJ', type: 'varchar' },
            { name: 'SOURCE_ONLY', type: 'varchar' },
          ],
          rows: async () => [
            {
              CO_CODE: '01',
              DHRN_LIC_NO: 'LIC-1',
              OLD_ISU_NO: '00007',
              OLD_ITEM_ADJ: 'Y',
              SOURCE_ONLY: 'ignored',
            },
          ],
          close: async () => undefined,
        }),
        connectTarget: async () => ({
          columns: async () => [
            { name: 'tenant_id', type: 'text' },
            { name: 'row_id', type: 'bigint' },
            { name: 'CO_CODE', type: 'character varying' },
            { name: 'DHRN_LIC_NO', type: 'character varying' },
            { name: 'OLD_ISU_NO', type: 'character varying' },
            { name: 'OLD_ITEM_ADJ', type: 'character varying' },
            { name: 'TARGET_ONLY', type: 'character varying' },
          ],
          sums: async () => ({}),
          // Real signature: replace(table, tenant, rows, columns).
          replace: async (_table: string, _tenant: string, rows: unknown[], columns: string[]) => {
            // The tool passes plain target column NAMES here, not column objects.
            replacedColumns = columns;
            return rows.length;
          },
          close: async () => undefined,
        }),
      },
    });

    expect(report.status).toBe('passed');
    // Every shared column travels, including the import-only ones no transaction form ever writes.
    expect(replacedColumns).toContain('DHRN_LIC_NO');
    expect(replacedColumns).toContain('OLD_ISU_NO');
    expect(replacedColumns).toContain('OLD_ITEM_ADJ');
    expect(replacedColumns).toContain('CO_CODE');
    // Bookkeeping columns and columns absent on one side are excluded.
    expect(replacedColumns).not.toContain('tenant_id');
    expect(replacedColumns).not.toContain('row_id');
    expect(replacedColumns).not.toContain('SOURCE_ONLY');
    expect(replacedColumns).not.toContain('TARGET_ONLY');
  });

  it('returns an actionable JSON failure when SQL Server is unreachable', async () => {
    const connectTarget = vi.fn();
    const report = await executeCutover({
      args: ['--dry-run', '--tables=AC_MAST'],
      env,
      dependencies: {
        connectSource: async () => {
          throw new Error('connect ECONNREFUSED');
        },
        connectTarget,
      },
    });

    expect(connectTarget).not.toHaveBeenCalled();
    expect(report).toMatchObject({
      schemaVersion: 1,
      mode: 'dry-run',
      status: 'failed',
      tables: [],
      error: {
        code: 'SOURCE_UNREACHABLE',
        message: expect.stringContaining('ECONNREFUSED'),
        action: expect.stringContaining('CUTOVER_SOURCE_HOST/PORT'),
      },
    });
    expect(JSON.parse(JSON.stringify(report))).toEqual(report);
    expect(JSON.stringify(report)).not.toContain(env.CUTOVER_SOURCE_PASSWORD);
  });
});
