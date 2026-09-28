import { withTenant } from '@datacare/db';

export const DATA_EXPORT_KIND = 'datacare.ut-export/1.0' as const;

/**
 * Desktop UT_EXPORT transfers the business tables below between the working company database and the
 * retail/other target database, using DATA_TRFR='N' as the pending marker. In the web application the
 * transfer artifact is an explicit JSON package, but the table family and flag semantics are preserved.
 */
export const DATA_EXPORT_TABLES = [
  'AC_DATA',
  'AC_MAST',
  'AD_ADJ',
  'AD_DATA',
  'AD_MAST',
  'AD_MEMB',
  'BAR_CAN_DATA',
  'BAR_CAN_DETL',
  'BAR_CAN_IDTL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'BOOK_DATA',
  'CARD_DATA',
  'CASH_DATA',
  'CONTRA_DATA',
  'GROUP_MAST',
  'ITEM_MAST',
  'ITM_OPBL',
  'KR_DATA',
  'KR_DETL',
  'KR_IDTL',
  'LBR_DATA',
  'MAIN_STOCK',
  'OP_DATA',
  'PAY_DATA',
  'PRODUCT_MAST',
  'PR_DATA',
  'PR_DETL',
  'PR_IDTL',
  'RATE_CUT_DATA',
  'RATE_CUT_ISU',
  'RATE_CUT_REC',
  'REP_DATA',
  'REP_DETL',
  'ROJ_MEL_DATA',
  'SL_DATA',
  'SL_DETL',
  'SL_DETL_RTN',
  'SL_IDTL',
  'SL_ORD_ADJ',
  'SL_ORD_DATA',
  'SL_ORD_DETL',
  'SL_ORD_IDTL',
  'SL_PR_DETL',
  'TABLE_MAST',
  'UPI_DATA',
] as const;

export interface DataExportScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

export interface DataExportTablePreview {
  table: string;
  columns: number;
  rowCount: number;
  pendingRows: number | null;
  hasDataTransferFlag: boolean;
}

export interface DataExportPreview {
  kind: typeof DATA_EXPORT_KIND;
  generatedAt: string;
  scope: DataExportScope;
  tables: DataExportTablePreview[];
  totals: {
    tables: number;
    rows: number;
    pendingRows: number;
    flaggedTables: number;
  };
}

export interface DataExportPackageTable {
  columns: string[];
  rowCount: number;
  rows: Array<Record<string, unknown>>;
}

export interface DataExportPackage {
  kind: typeof DATA_EXPORT_KIND;
  generatedAt: string;
  scope: DataExportScope;
  pendingOnly: boolean;
  tables: Record<string, DataExportPackageTable>;
  totals: {
    tables: number;
    rows: number;
  };
}

export interface DataTransferFlagResult {
  state: 'Y' | 'N';
  pendingOnly: boolean;
  updated: Record<string, number>;
  total: number;
}

export class DataExportValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'DataExportValidationError';
  }
}

interface ColumnMeta {
  name: string;
  dataType: string;
  ordinal: number;
}

interface TableMeta {
  name: string;
  columns: ColumnMeta[];
  names: Set<string>;
}

const quoteIdentifier = (identifier: string): string => {
  if (!identifier || identifier.includes('\0')) throw new DataExportValidationError('invalid identifier');
  return `"${identifier.replaceAll('"', '""')}"`;
};

const boolFromQuery = (value: unknown, defaultValue: boolean): boolean => {
  if (value === undefined || value === null || value === '') return defaultValue;
  const s = String(value).trim().toLowerCase();
  if (['1', 'true', 'yes', 'y'].includes(s)) return true;
  if (['0', 'false', 'no', 'n'].includes(s)) return false;
  return defaultValue;
};

export function dataExportPendingOnly(value: unknown): boolean {
  return boolFromQuery(value, true);
}

const normalizeScope = (scope: DataExportScope): DataExportScope => {
  const tenantId = String(scope.tenantId ?? '').trim();
  const coCode = String(scope.coCode ?? '').trim();
  const lcCode = scope.lcCode == null ? undefined : String(scope.lcCode).trim();
  const coYear = scope.coYear == null ? undefined : String(scope.coYear).trim();
  if (!tenantId) throw new DataExportValidationError('tenant is required');
  if (!coCode) throw new DataExportValidationError('company is required');
  return { tenantId, coCode, lcCode: lcCode || undefined, coYear: coYear || undefined };
};

async function exportMetadataTx(tx: any): Promise<TableMeta[]> {
  const placeholders = DATA_EXPORT_TABLES.map((_, index) => `$${index + 1}`).join(',');
  const rows = (await tx.$queryRawUnsafe(
    `SELECT table_name, column_name, data_type, ordinal_position
       FROM information_schema.columns
      WHERE table_schema='public' AND table_name IN (${placeholders})
      ORDER BY table_name, ordinal_position`,
    ...DATA_EXPORT_TABLES,
  )) as Array<{ table_name: string; column_name: string; data_type: string; ordinal_position: number }>;
  const byTable = new Map<string, ColumnMeta[]>();
  for (const row of rows) {
    const name = String(row.table_name);
    byTable.set(name, [
      ...(byTable.get(name) ?? []),
      {
        name: String(row.column_name),
        dataType: String(row.data_type),
        ordinal: Number(row.ordinal_position),
      },
    ]);
  }
  const tables: TableMeta[] = [];
  for (const table of DATA_EXPORT_TABLES) {
    const columns = byTable.get(table) ?? [];
    if (!columns.length) continue;
    const names = new Set(columns.map((column) => column.name));
    if (!names.has('tenant_id') || !names.has('CO_CODE')) continue;
    tables.push({ name: table, columns, names });
  }
  return tables;
}

function scopedWhere(
  table: TableMeta,
  scope: DataExportScope,
  opts: { pendingOnly?: boolean } = {},
): { where: string; params: unknown[] } {
  const clauses: string[] = [];
  const params: unknown[] = [];
  const add = (sql: string, value: unknown) => {
    params.push(value);
    clauses.push(sql.replace('?', `$${params.length}`));
  };
  add('"tenant_id"=?', scope.tenantId);
  add('"CO_CODE"::text=?::text', scope.coCode);
  if (scope.lcCode && table.names.has('LC_CODE')) add('"LC_CODE"::text=?::text', scope.lcCode);
  if (scope.coYear && table.names.has('CO_YEAR')) add('"CO_YEAR"::text=?::text', scope.coYear);
  if (opts.pendingOnly && table.names.has('DATA_TRFR'))
    clauses.push(`coalesce("DATA_TRFR"::text,'')='N'`);
  return { where: `WHERE ${clauses.join(' AND ')}`, params };
}

function orderBy(table: TableMeta): string {
  const preferred = [
    'LC_CODE',
    'CO_YEAR',
    'CO_BOOK',
    'VCH_NO',
    'SR_NO',
    'ISR_NO',
    'AC_CODE',
    'IT_CODE',
    'TAG_NO',
    'MEMB_CODE',
    'SCHM_CODE',
    'row_id',
  ].filter((column) => table.names.has(column));
  return preferred.length
    ? ` ORDER BY ${preferred.map((column) => `${quoteIdentifier(column)} NULLS LAST`).join(',')}`
    : '';
}

async function countRowsTx(
  tx: any,
  table: TableMeta,
  scope: DataExportScope,
  opts: { pendingOnly?: boolean } = {},
): Promise<number> {
  const { where, params } = scopedWhere(table, scope, opts);
  const rows = (await tx.$queryRawUnsafe(
    `SELECT count(*)::int AS n FROM ${quoteIdentifier(table.name)} ${where}`,
    ...params,
  )) as Array<{ n: number }>;
  return Number(rows[0]?.n ?? 0);
}

function encodeCell(value: unknown, column: ColumnMeta): unknown {
  if (value === null || value === undefined) return null;
  if (typeof value === 'bigint') return value.toString();
  if (value instanceof Date) return value.toISOString();
  if (Buffer.isBuffer(value)) return { encoding: 'base64', data: value.toString('base64') };
  if (typeof value === 'object') {
    const maybeJson = value as { toJSON?: () => unknown; toString?: () => string };
    if (typeof maybeJson.toJSON === 'function') return maybeJson.toJSON();
    if (column.dataType === 'numeric' || column.dataType === 'decimal') return maybeJson.toString?.() ?? value;
  }
  return value;
}

async function readRowsTx(
  tx: any,
  table: TableMeta,
  scope: DataExportScope,
  opts: { pendingOnly: boolean },
): Promise<Array<Record<string, unknown>>> {
  const { where, params } = scopedWhere(table, scope, { pendingOnly: opts.pendingOnly });
  const select = table.columns.map((column) => quoteIdentifier(column.name)).join(',');
  const rawRows = (await tx.$queryRawUnsafe(
    `SELECT ${select} FROM ${quoteIdentifier(table.name)} ${where}${orderBy(table)}`,
    ...params,
  )) as Array<Record<string, unknown>>;
  return rawRows.map((row) => {
    const out: Record<string, unknown> = {};
    for (const column of table.columns) out[column.name] = encodeCell(row[column.name], column);
    return out;
  });
}

export async function dataExportPreview(prisma: any, inputScope: DataExportScope): Promise<DataExportPreview> {
  const scope = normalizeScope(inputScope);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const metadata = await exportMetadataTx(tx);
    const tables: DataExportTablePreview[] = [];
    for (const table of metadata) {
      const rowCount = await countRowsTx(tx, table, scope);
      const hasDataTransferFlag = table.names.has('DATA_TRFR');
      const pendingRows = hasDataTransferFlag
        ? await countRowsTx(tx, table, scope, { pendingOnly: true })
        : null;
      tables.push({
        table: table.name,
        columns: table.columns.length,
        rowCount,
        pendingRows,
        hasDataTransferFlag,
      });
    }
    return {
      kind: DATA_EXPORT_KIND,
      generatedAt: new Date().toISOString(),
      scope,
      tables,
      totals: {
        tables: tables.length,
        rows: tables.reduce((sum, table) => sum + table.rowCount, 0),
        pendingRows: tables.reduce((sum, table) => sum + (table.pendingRows ?? 0), 0),
        flaggedTables: tables.filter((table) => table.hasDataTransferFlag).length,
      },
    };
  });
}

export async function dataExportPackage(
  prisma: any,
  inputScope: DataExportScope,
  options: { pendingOnly?: boolean } = {},
): Promise<DataExportPackage> {
  const scope = normalizeScope(inputScope);
  const pendingOnly = options.pendingOnly ?? true;
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const metadata = await exportMetadataTx(tx);
    const tables: Record<string, DataExportPackageTable> = {};
    for (const table of metadata) {
      const rows = await readRowsTx(tx, table, scope, {
        pendingOnly: pendingOnly && table.names.has('DATA_TRFR'),
      });
      tables[table.name] = {
        columns: table.columns.map((column) => column.name),
        rowCount: rows.length,
        rows,
      };
    }
    return {
      kind: DATA_EXPORT_KIND,
      generatedAt: new Date().toISOString(),
      scope,
      pendingOnly,
      tables,
      totals: {
        tables: Object.keys(tables).length,
        rows: Object.values(tables).reduce((sum, table) => sum + table.rowCount, 0),
      },
    };
  });
}

export async function markDataTransferFlags(
  prisma: any,
  inputScope: DataExportScope,
  options: { state: 'Y' | 'N'; pendingOnly?: boolean },
): Promise<DataTransferFlagResult> {
  const scope = normalizeScope(inputScope);
  const state = String(options.state ?? '').toUpperCase();
  if (state !== 'Y' && state !== 'N')
    throw new DataExportValidationError('DATA_TRFR state must be Y or N');
  const pendingOnly = options.pendingOnly ?? false;
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const metadata = (await exportMetadataTx(tx)).filter((table) => table.names.has('DATA_TRFR'));
    const updated: Record<string, number> = {};
    for (const table of metadata) {
      const { where, params } = scopedWhere(table, scope, { pendingOnly });
      const count = Number(
        await tx.$executeRawUnsafe(
          `UPDATE ${quoteIdentifier(table.name)} SET "DATA_TRFR"=$${params.length + 1} ${where}`,
          ...params,
          state,
        ),
      );
      updated[table.name] = count;
    }
    return {
      state,
      pendingOnly,
      updated,
      total: Object.values(updated).reduce((sum, count) => sum + count, 0),
    };
  });
}

export async function resetDataTransferFlags(
  prisma: any,
  scope: DataExportScope,
): Promise<DataTransferFlagResult> {
  return markDataTransferFlags(prisma, scope, { state: 'N', pendingOnly: false });
}
