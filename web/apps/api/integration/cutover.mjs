#!/usr/bin/env node
import { mkdir, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { pathToFileURL } from 'node:url';
import sql from 'mssql';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';

export const DEFAULT_TABLES = [
  'CO_MAST',
  'GROUP_MAST',
  'AC_MAST',
  'ITEM_MAST',
  'EMP_MAST',
  'PRODUCT_MAST',
  'RATE_MAST',
  'TAX_MAST',
  'BOOK_DATA',
  'LOCT_MAST',
  'DESIGN_MAST',
  'DM_MAST',
  'MODEL_MAST',
  'STATE_MAST',
  'POINT_MAST',
  'LBR_MAST',
  'TOUCH_MAST',
  'SL_DATA',
  'SL_DETL',
  'SL_IDTL',
  'PR_DATA',
  'PR_DETL',
  'AC_DATA',
  'TAX_DATA',
  'TAG_STOCK',
  'KR_DATA',
  'KR_DETL',
  'DHRN_ISU_DATA',
  'DHRN_REC_DATA',
  'SL_ORD_DATA',
  'BILL_OS_DATA',
  'MAIN_STOCK',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'SL_ORD_DETL',
  'SL_ORD_IDTL',
  'AD_ADJ',
  'SL_PR_DETL',
  'CARD_DATA',
  'UPI_DATA',
  'MFG_ISU_REC',
];

const NUMERIC_TYPES = new Set([
  'bigint',
  'decimal',
  'double precision',
  'float',
  'int',
  'integer',
  'money',
  'numeric',
  'real',
  'smallint',
  'smallmoney',
  'tinyint',
]);
const IDENTIFIER = /^[A-Za-z_][A-Za-z0-9_]*$/;
const qpg = (value) => `"${value.replace(/"/g, '""')}"`;
const qms = (value) => `[${value.replace(/]/g, ']]')}]`;
const elapsedMs = (started) => Math.round((performance.now() - started) * 1000) / 1000;
const errorMessage = (error) => (error instanceof Error ? error.message : String(error));

function required(env, name) {
  const value = String(env[name] ?? '').trim();
  if (!value) throw new Error(`${name} is required`);
  return value;
}

function positiveInteger(value, fallback, name) {
  if (value == null || value === '') return fallback;
  const parsed = Number(value);
  if (!Number.isInteger(parsed) || parsed <= 0)
    throw new Error(`${name} must be a positive integer`);
  return parsed;
}

function bool(value, fallback) {
  if (value == null || value === '') return fallback;
  if (/^(1|true|yes)$/i.test(String(value))) return true;
  if (/^(0|false|no)$/i.test(String(value))) return false;
  throw new Error(`invalid boolean value: ${value}`);
}

function tableList(value) {
  const tables = value
    ? String(value)
        .split(',')
        .map((entry) => entry.trim())
        .filter(Boolean)
    : DEFAULT_TABLES;
  if (!tables.length) throw new Error('at least one cutover table is required');
  for (const table of tables) {
    if (!IDENTIFIER.test(table)) throw new Error(`unsafe table name: ${table}`);
  }
  return [...new Set(tables)];
}

export function parseCutoverOptions(args = process.argv.slice(2), env = process.env) {
  let dryRun = false;
  let tablesArg;
  let resumeFrom;
  let reportPath;
  for (const arg of args) {
    if (arg === '--dry-run') dryRun = true;
    else if (arg.startsWith('--tables=')) tablesArg = arg.slice('--tables='.length);
    else if (arg.startsWith('--resume-from='))
      resumeFrom = arg.slice('--resume-from='.length).trim();
    else if (arg.startsWith('--report=')) reportPath = arg.slice('--report='.length).trim();
    else throw new Error(`unknown argument: ${arg}`);
  }

  const tables = tableList(tablesArg ?? env.CUTOVER_TABLES);
  if (resumeFrom && !tables.includes(resumeFrom)) {
    throw new Error(`--resume-from table is not in the cutover table list: ${resumeFrom}`);
  }
  const sourceHost = required(env, 'CUTOVER_SOURCE_HOST');
  const sourceDatabase = required(env, 'CUTOVER_SOURCE_DATABASE');
  const targetUrl = required(env, 'DATABASE_URL');
  const targetTenant = required(env, 'CUTOVER_TENANT_ID');
  const target = new URL(targetUrl);
  const yearFrom = String(env.CUTOVER_YEAR_FROM ?? '').trim();
  const yearTo = String(env.CUTOVER_YEAR_TO ?? '').trim();
  if (Boolean(yearFrom) !== Boolean(yearTo)) {
    throw new Error('CUTOVER_YEAR_FROM and CUTOVER_YEAR_TO must be provided together');
  }

  return {
    dryRun,
    tables,
    resumeFrom,
    reportPath: reportPath || String(env.CUTOVER_REPORT_PATH ?? '').trim() || undefined,
    yearFrom: yearFrom || undefined,
    yearTo: yearTo || undefined,
    source: {
      host: sourceHost,
      port: positiveInteger(env.CUTOVER_SOURCE_PORT, 1433, 'CUTOVER_SOURCE_PORT'),
      user: required(env, 'CUTOVER_SOURCE_USER'),
      password: required(env, 'CUTOVER_SOURCE_PASSWORD'),
      database: sourceDatabase,
      encrypt: bool(env.CUTOVER_SOURCE_ENCRYPT, true),
      trustServerCertificate: bool(env.CUTOVER_SOURCE_TRUST_SERVER_CERTIFICATE, false),
      connectTimeoutMs: positiveInteger(
        env.CUTOVER_CONNECT_TIMEOUT_MS,
        10000,
        'CUTOVER_CONNECT_TIMEOUT_MS',
      ),
      requestTimeoutMs: positiveInteger(
        env.CUTOVER_REQUEST_TIMEOUT_MS,
        240000,
        'CUTOVER_REQUEST_TIMEOUT_MS',
      ),
    },
    target: {
      url: targetUrl,
      database: target.pathname.slice(1),
      host: target.hostname,
      port: target.port ? Number(target.port) : 5432,
      tenant: targetTenant,
    },
  };
}

function normalizedColumns(columns) {
  return columns.map((column) => ({
    name: String(column.name ?? column.column_name),
    type: String(column.type ?? column.data_type ?? '').toLowerCase(),
    numeric: NUMERIC_TYPES.has(String(column.type ?? column.data_type ?? '').toLowerCase()),
  }));
}

function valueOf(row, column) {
  if (Object.prototype.hasOwnProperty.call(row, column)) return row[column];
  const key = Object.keys(row).find(
    (candidate) => candidate.toUpperCase() === column.toUpperCase(),
  );
  return key == null ? undefined : row[key];
}

function sumsFor(rows, columns) {
  return Object.fromEntries(
    columns.map((column) => {
      let sum = 0;
      for (const row of rows) {
        const value = valueOf(row, column);
        if (value == null || value === '') continue;
        const number = Number(value);
        if (!Number.isFinite(number)) throw new Error(`non-numeric value in ${column}`);
        sum += number;
      }
      return [column, Number(sum.toPrecision(15))];
    }),
  );
}

function sumsMatch(source, target) {
  const scale = Math.max(1, Math.abs(source), Math.abs(target));
  return Math.abs(source - target) <= scale * 1e-9;
}

function transformRows(rows, columns, options) {
  return rows.map((row) =>
    Object.fromEntries(
      columns.map((column) => {
        let value = valueOf(row, column.sourceName);
        if (
          column.targetName.toUpperCase() === 'CO_YEAR' &&
          options.yearFrom &&
          value === options.yearFrom
        ) {
          value = options.yearTo;
        }
        return [column.targetName, value === undefined ? null : value];
      }),
    ),
  );
}

export async function runCutover(options, adapters) {
  const started = performance.now();
  const tables = [];
  let resumeReached = !options.resumeFrom;

  for (const table of options.tables) {
    const tableStarted = performance.now();
    if (!resumeReached && table !== options.resumeFrom) {
      tables.push({
        table,
        status: 'resume-skipped',
        sourceRows: 0,
        loadedRows: 0,
        skippedRows: 0,
        numericColumns: {},
        durationMs: elapsedMs(tableStarted),
      });
      continue;
    }
    resumeReached = true;

    let sourceRows = [];
    try {
      const [sourceMetaRaw, targetMetaRaw] = await Promise.all([
        adapters.source.columns(table),
        adapters.target.columns(table),
      ]);
      const sourceMeta = normalizedColumns(sourceMetaRaw);
      const targetMeta = normalizedColumns(targetMetaRaw);
      if (!sourceMeta.length || !targetMeta.length) {
        tables.push({
          table,
          status: !sourceMeta.length ? 'source-table-missing' : 'target-table-missing',
          sourceRows: 0,
          loadedRows: 0,
          skippedRows: 0,
          numericColumns: {},
          durationMs: elapsedMs(tableStarted),
        });
        continue;
      }

      const sourceByUpper = new Map(
        sourceMeta.map((column) => [column.name.toUpperCase(), column]),
      );
      const columns = targetMeta
        .filter((column) => !['TENANT_ID', 'ROW_ID'].includes(column.name.toUpperCase()))
        .flatMap((targetColumn) => {
          const sourceColumn = sourceByUpper.get(targetColumn.name.toUpperCase());
          return sourceColumn
            ? [{ sourceName: sourceColumn.name, targetName: targetColumn.name }]
            : [];
        });
      if (!columns.length) {
        tables.push({
          table,
          status: 'no-common-columns',
          sourceRows: 0,
          loadedRows: 0,
          skippedRows: 0,
          numericColumns: {},
          durationMs: elapsedMs(tableStarted),
        });
        continue;
      }

      sourceRows = await adapters.source.rows(
        table,
        columns.map((column) => column.sourceName),
      );
      const transformed = transformRows(sourceRows, columns, options);
      const targetByUpper = new Map(
        targetMeta.map((column) => [column.name.toUpperCase(), column]),
      );
      const numericColumns = columns
        .filter((column) => {
          const sourceColumn = sourceByUpper.get(column.sourceName.toUpperCase());
          const targetColumn = targetByUpper.get(column.targetName.toUpperCase());
          return sourceColumn?.numeric && targetColumn?.numeric;
        })
        .map((column) => column.targetName);
      const sourceSums = sumsFor(transformed, numericColumns);

      let loadedRows = 0;
      if (!options.dryRun) {
        loadedRows = await adapters.target.replace(
          table,
          options.target.tenant,
          transformed,
          columns.map((column) => column.targetName),
        );
      }
      const targetSums = await adapters.target.sums(table, options.target.tenant, numericColumns);
      const comparisons = Object.fromEntries(
        numericColumns.map((column) => [
          column,
          {
            source: sourceSums[column],
            target: targetSums[column] ?? 0,
            matches: sumsMatch(sourceSums[column], targetSums[column] ?? 0),
          },
        ]),
      );
      const numericMismatch = Object.values(comparisons).some((comparison) => !comparison.matches);
      tables.push({
        table,
        status: options.dryRun ? 'dry-run' : numericMismatch ? 'sum-mismatch' : 'loaded',
        sourceRows: sourceRows.length,
        loadedRows,
        skippedRows: options.dryRun ? sourceRows.length : sourceRows.length - loadedRows,
        numericColumns: comparisons,
        durationMs: elapsedMs(tableStarted),
      });
    } catch (error) {
      tables.push({
        table,
        status: 'failed',
        sourceRows: sourceRows.length,
        loadedRows: 0,
        skippedRows: sourceRows.length,
        numericColumns: {},
        error: errorMessage(error),
        durationMs: elapsedMs(tableStarted),
      });
    }
  }

  const failures = tables.filter((table) =>
    ['failed', 'sum-mismatch'].includes(table.status),
  ).length;
  return {
    schemaVersion: 1,
    mode: options.dryRun ? 'dry-run' : 'load',
    status: failures ? 'partial' : 'passed',
    source: {
      host: options.source.host,
      port: options.source.port,
      database: options.source.database,
    },
    target: {
      host: options.target.host,
      port: options.target.port,
      database: options.target.database,
      tenant: options.target.tenant,
    },
    tables,
    totals: {
      tables: tables.length,
      failedTables: failures,
      sourceRows: tables.reduce((sum, table) => sum + table.sourceRows, 0),
      loadedRows: tables.reduce((sum, table) => sum + table.loadedRows, 0),
      skippedRows: tables.reduce((sum, table) => sum + table.skippedRows, 0),
    },
    durationMs: elapsedMs(started),
  };
}

export async function connectSqlServer(options) {
  const pool = await new sql.ConnectionPool({
    server: options.host,
    port: options.port,
    user: options.user,
    password: options.password,
    database: options.database,
    connectionTimeout: options.connectTimeoutMs,
    requestTimeout: options.requestTimeoutMs,
    options: {
      encrypt: options.encrypt,
      trustServerCertificate: options.trustServerCertificate,
    },
  }).connect();

  return {
    async columns(table) {
      const result = await pool.request().input('table', sql.NVarChar(128), table)
        .query(`SELECT COLUMN_NAME AS name, DATA_TYPE AS type
                  FROM INFORMATION_SCHEMA.COLUMNS
                 WHERE TABLE_NAME=@table
                 ORDER BY ORDINAL_POSITION`);
      return result.recordset;
    },
    async rows(table, columns) {
      if (!IDENTIFIER.test(table) || columns.some((column) => !IDENTIFIER.test(column))) {
        throw new Error(`unsafe SQL Server identifier for ${table}`);
      }
      const result = await pool
        .request()
        .query(
          `SELECT ${columns.map(qms).join(',')} FROM ${qms(options.database)}.dbo.${qms(table)}`,
        );
      return result.recordset;
    },
    close: () => pool.close(),
  };
}

export async function connectPostgres(options) {
  const prisma = new PrismaClient({ datasources: { db: { url: options.url } } });
  await prisma.$queryRawUnsafe('SELECT 1');
  return {
    async columns(table) {
      return prisma.$queryRawUnsafe(
        `SELECT column_name AS name, data_type AS type
           FROM information_schema.columns
          WHERE table_schema='public' AND table_name=$1
          ORDER BY ordinal_position`,
        table,
      );
    },
    async sums(table, tenant, columns) {
      if (!columns.length) return {};
      return withTenant(prisma, tenant, async (tx) => {
        const rows = await tx.$queryRawUnsafe(
          `SELECT ${columns.map(qpg).join(',')} FROM ${qpg(table)}`,
        );
        return sumsFor(rows, columns);
      });
    },
    async replace(table, tenant, rows, columns) {
      return withTenant(prisma, tenant, async (tx) => {
        await tx.$executeRawUnsafe(`DELETE FROM ${qpg(table)} WHERE tenant_id=$1`, tenant);
        let loaded = 0;
        const insertColumns = ['tenant_id', ...columns];
        const placeholders = insertColumns.map((_, index) => `$${index + 1}`).join(',');
        for (const row of rows) {
          loaded += await tx.$executeRawUnsafe(
            `INSERT INTO ${qpg(table)}(${insertColumns.map(qpg).join(',')}) VALUES (${placeholders})`,
            tenant,
            ...columns.map((column) => row[column]),
          );
        }
        return loaded;
      });
    },
    close: () => prisma.$disconnect(),
  };
}

function failedConnectionReport(options, error) {
  return {
    schemaVersion: 1,
    mode: options?.dryRun ? 'dry-run' : 'load',
    status: 'failed',
    source: options
      ? { host: options.source.host, port: options.source.port, database: options.source.database }
      : undefined,
    target: options
      ? {
          host: options.target.host,
          port: options.target.port,
          database: options.target.database,
          tenant: options.target.tenant,
        }
      : undefined,
    tables: [],
    totals: { tables: 0, failedTables: 0, sourceRows: 0, loadedRows: 0, skippedRows: 0 },
    error: {
      code: 'SOURCE_UNREACHABLE',
      message: `Source SQL Server is unreachable: ${errorMessage(error)}`,
      action:
        'Verify CUTOVER_SOURCE_HOST/PORT, network access, SQL Server availability, and CUTOVER_SOURCE_USER credentials; then rerun --dry-run.',
    },
  };
}

export async function executeCutover({
  args = process.argv.slice(2),
  env = process.env,
  dependencies = {},
} = {}) {
  let options;
  try {
    options = parseCutoverOptions(args, env);
  } catch (error) {
    return {
      schemaVersion: 1,
      mode: args.includes('--dry-run') ? 'dry-run' : 'load',
      status: 'failed',
      tables: [],
      totals: { tables: 0, failedTables: 0, sourceRows: 0, loadedRows: 0, skippedRows: 0 },
      error: { code: 'CONFIGURATION_ERROR', message: errorMessage(error) },
    };
  }

  let source;
  let target;
  try {
    try {
      source = await (dependencies.connectSource ?? connectSqlServer)(options.source);
    } catch (error) {
      return failedConnectionReport(options, error);
    }
    try {
      target = await (dependencies.connectTarget ?? connectPostgres)(options.target);
    } catch (error) {
      return {
        ...failedConnectionReport(options, error),
        error: {
          code: 'TARGET_UNREACHABLE',
          message: `Target PostgreSQL is unreachable: ${errorMessage(error)}`,
          action: 'Verify DATABASE_URL and PostgreSQL availability, then rerun --dry-run.',
        },
      };
    }
    return await runCutover(options, { source, target });
  } finally {
    await Promise.resolve(target?.close?.()).catch(() => undefined);
    await Promise.resolve(source?.close?.()).catch(() => undefined);
  }
}

export async function main(args = process.argv.slice(2), env = process.env) {
  const report = await executeCutover({ args, env });
  const json = `${JSON.stringify(report, null, 2)}\n`;
  const reportArg = args.find((arg) => arg.startsWith('--report='));
  const reportPath = reportArg?.slice('--report='.length) || env.CUTOVER_REPORT_PATH;
  if (reportPath) {
    const absolute = resolve(reportPath);
    await mkdir(dirname(absolute), { recursive: true });
    await writeFile(absolute, json, 'utf8');
  }
  process.stdout.write(json);
  if (report.status !== 'passed') process.exitCode = 1;
  return report;
}

const invokedPath = process.argv[1] ? pathToFileURL(resolve(process.argv[1])).href : '';
if (import.meta.url === invokedPath) {
  main().catch((error) => {
    process.stdout.write(
      `${JSON.stringify({ schemaVersion: 1, status: 'failed', error: { code: 'UNEXPECTED_ERROR', message: errorMessage(error) } }, null, 2)}\n`,
    );
    process.exitCode = 1;
  });
}
