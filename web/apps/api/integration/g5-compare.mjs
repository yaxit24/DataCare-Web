#!/usr/bin/env node
import { copyFile, mkdir, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import sql from 'mssql';
import { PrismaClient } from '@prisma/client';
import { billTotals } from '@datacare/core';
import { withTenant } from '@datacare/db';
import { DEFAULT_TABLES } from './cutover.mjs';
import {
  aggregateLiveReport,
  buildDegradedReport,
  buildFormArtifact,
} from '../dist/modules/parity/g5Harness.js';
import { runParity } from '../dist/modules/parity/golden.js';

const REPO_ROOT = resolve(dirname(fileURLToPath(import.meta.url)), '../../../..');
const G5_ROOT = resolve(REPO_ROOT, 'project-memory/parity/g5');
const IDENTIFIER = /^[A-Za-z_][A-Za-z0-9_]*$/;
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
const SKIP_COLUMNS = new Set([
  'TENANT_ID',
  'ROW_ID',
  'VCH_NO',
  'CO_BOOK',
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'HD_VCH_NO',
  'VCH_DATE',
  'VCH_TIME',
  'STK_DATE',
  'ENTRY_TIME',
  'MAIN_USER',
  'USER_UPDATE',
  'BILL_NO',
  'DATA_TRFR',
  'OLD_VCH_NO',
  'NEW_VCH_NO',
  'FUN_DATE',
]);
const requiredSourceVariables = [
  'CUTOVER_SOURCE_HOST',
  'CUTOVER_SOURCE_USER',
  'CUTOVER_SOURCE_PASSWORD',
  'CUTOVER_SOURCE_DATABASE',
];
const safeIdentifier = (value) => {
  if (!IDENTIFIER.test(value)) throw new Error(`Unsafe SQL identifier: ${value}`);
  return value;
};
const qms = (value) => `[${safeIdentifier(value)}]`;
const qpg = (value) => `"${safeIdentifier(value)}"`;
const number = (value) => Number(value ?? 0);
const round = (value, places = 6) => {
  const scale = 10 ** places;
  return Math.round((number(value) + Number.EPSILON) * scale) / scale;
};
const sumsMatch = (left, right) => {
  const scale = Math.max(1, Math.abs(left), Math.abs(right));
  return Math.abs(left - right) <= scale * 1e-9;
};
const messageOf = (error) => (error instanceof Error ? error.message : String(error));
const normalize = (value) => {
  if (value == null || value instanceof Date) return '';
  if (typeof value === 'bigint') return value.toString();
  const text = String(value).trim();
  const numeric = Number(text);
  return Number.isFinite(numeric) && text !== '' ? String(round(numeric, 3)) : text.toUpperCase();
};
const valueOf = (row, column) => {
  const key = Object.keys(row).find(
    (candidate) => candidate.toUpperCase() === column.toUpperCase(),
  );
  return key === undefined ? undefined : row[key];
};
const timestampPath = (iso) => iso.replace(/[:.]/g, '-');
const formFileName = (formId) => `${formId.replace(/[^A-Za-z0-9_-]/g, '_')}.json`;

function sourceOptions(env) {
  const missing = requiredSourceVariables.filter((name) => !String(env[name] ?? '').trim());
  if (missing.length) return { configured: false, missing };
  return {
    configured: true,
    value: {
      host: env.CUTOVER_SOURCE_HOST.trim(),
      port: Number(env.CUTOVER_SOURCE_PORT || 1433),
      user: env.CUTOVER_SOURCE_USER,
      password: env.CUTOVER_SOURCE_PASSWORD,
      database: env.CUTOVER_SOURCE_DATABASE.trim(),
      encrypt: /^(1|true|yes)$/i.test(env.CUTOVER_SOURCE_ENCRYPT || 'false'),
      trustServerCertificate: !/^(0|false|no)$/i.test(
        env.CUTOVER_SOURCE_TRUST_SERVER_CERTIFICATE || 'true',
      ),
      connectTimeoutMs: Number(env.CUTOVER_CONNECT_TIMEOUT_MS || 10000),
      requestTimeoutMs: Number(env.CUTOVER_REQUEST_TIMEOUT_MS || 240000),
    },
  };
}

function parseForms(value) {
  if (!String(value ?? '').trim()) throw new Error('G5_FORMS is not configured.');
  const forms = JSON.parse(value);
  if (!Array.isArray(forms) || forms.length === 0)
    throw new Error('G5_FORMS must be a non-empty JSON array.');
  return forms.map((entry, index) => {
    const formId = String(entry.formId ?? '').trim();
    const desktop = entry.desktop ?? {};
    const web = entry.web ?? {};
    if (!formId || !desktop.book || desktop.voucher == null || !web.book || web.voucher == null) {
      throw new Error(`G5_FORMS[${index}] requires formId and desktop/web book plus voucher.`);
    }
    return {
      formId,
      desktop: { book: String(desktop.book), voucher: String(desktop.voucher) },
      web: { book: String(web.book), voucher: String(web.voucher) },
    };
  });
}

function tableList(value) {
  const tables = String(value ?? '').trim()
    ? value
        .split(',')
        .map((item) => item.trim())
        .filter(Boolean)
    : DEFAULT_TABLES;
  return [...new Set(tables.map(safeIdentifier))];
}

async function writeArtifacts(report, directory) {
  await mkdir(directory, { recursive: true });
  const reportPath = resolve(directory, 'report.json');
  await writeFile(reportPath, `${JSON.stringify(report, null, 2)}\n`, 'utf8');
  for (const form of report.forms) {
    await writeFile(
      resolve(directory, formFileName(form.formId)),
      `${JSON.stringify(form, null, 2)}\n`,
      'utf8',
    );
  }
  await copyFile(reportPath, resolve(G5_ROOT, 'latest.json'));
  return reportPath;
}

async function sourceColumns(pool, database, table) {
  const result = await pool.request().input('table', sql.NVarChar(128), table)
    .query(`SELECT COLUMN_NAME AS name, DATA_TYPE AS type
              FROM ${qms(database)}.INFORMATION_SCHEMA.COLUMNS
             WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@table
             ORDER BY ORDINAL_POSITION`);
  return result.recordset.map((column) => ({
    name: String(column.name),
    type: String(column.type).toLowerCase(),
  }));
}

async function targetColumns(prisma, table) {
  return prisma.$queryRawUnsafe(
    `SELECT column_name AS name, data_type AS type
       FROM information_schema.columns
      WHERE table_schema='public' AND upper(table_name)=upper($1)
      ORDER BY ordinal_position`,
    table,
  );
}

async function sourceVoucherTables(pool, database) {
  const rows = await pool.request().query(`SELECT TABLE_NAME AS name
    FROM ${qms(database)}.INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA='dbo' AND COLUMN_NAME IN ('VCH_NO','CO_BOOK','CO_CODE')
    GROUP BY TABLE_NAME HAVING COUNT(DISTINCT COLUMN_NAME)=3`);
  return rows.recordset.map((row) => String(row.name));
}

async function targetVoucherTables(prisma) {
  const rows = await prisma.$queryRawUnsafe(`SELECT table_name AS name
    FROM information_schema.columns
    WHERE table_schema='public' AND upper(column_name) IN ('VCH_NO','CO_BOOK','CO_CODE')
    GROUP BY table_name HAVING COUNT(DISTINCT upper(column_name))=3`);
  return rows.map((row) => String(row.name));
}

async function sourceVoucherRows(pool, database, table, voucher) {
  const result = await pool
    .request()
    .input('company', sql.NVarChar(50), process.env.G5_COMPANY || '01')
    .input('book', sql.NVarChar(50), voucher.book)
    .input('voucher', sql.NVarChar(100), voucher.voucher)
    .query(`SELECT * FROM ${qms(database)}.dbo.${qms(table)}
             WHERE CO_CODE=@company AND CO_BOOK=@book AND VCH_NO=@voucher`);
  return result.recordset;
}

async function targetVoucherRows(prisma, tenant, table, voucher) {
  return withTenant(prisma, tenant, (tx) =>
    tx.$queryRawUnsafe(
      `SELECT * FROM ${qpg(table)} WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      process.env.G5_COMPANY || '01',
      voucher.book,
      voucher.voucher,
    ),
  );
}

function sortRows(rows, columns) {
  const preferred = ['SR_NO', 'SRNO', 'LINE_NO'].find((column) =>
    columns.some((candidate) => candidate.toUpperCase() === column),
  );
  return [...rows].sort((left, right) => {
    if (preferred)
      return normalize(valueOf(left, preferred)).localeCompare(
        normalize(valueOf(right, preferred)),
      );
    return JSON.stringify(left, (_, value) =>
      typeof value === 'bigint' ? value.toString() : value,
    ).localeCompare(
      JSON.stringify(right, (_, value) => (typeof value === 'bigint' ? value.toString() : value)),
    );
  });
}

async function compareForm(pool, prisma, options, tenant, form, voucherTables) {
  const tablesCompared = [];
  let footprintDiffCount = 0;
  let columnDiffCount = 0;
  let numericSumDiff = 0;
  const tableResults = [];
  for (const table of voucherTables) {
    const [sourceRows, targetRows, sourceMeta, targetMeta] = await Promise.all([
      sourceVoucherRows(pool, options.database, table, form.desktop),
      targetVoucherRows(prisma, tenant, table, form.web),
      sourceColumns(pool, options.database, table),
      targetColumns(prisma, table),
    ]);
    if (!sourceRows.length && !targetRows.length) continue;
    tablesCompared.push(table);
    const sourceByName = new Map(sourceMeta.map((column) => [column.name.toUpperCase(), column]));
    const targetByName = new Map(
      targetMeta.map((column) => [String(column.name).toUpperCase(), column]),
    );
    const comparable = sourceMeta.filter(
      (column) =>
        targetByName.has(column.name.toUpperCase()) && !SKIP_COLUMNS.has(column.name.toUpperCase()),
    );
    const missingColumns = sourceMeta.filter(
      (column) =>
        !targetByName.has(column.name.toUpperCase()) &&
        !SKIP_COLUMNS.has(column.name.toUpperCase()),
    ).length;
    const sourceSorted = sortRows(
      sourceRows,
      comparable.map((column) => column.name),
    );
    const targetSorted = sortRows(
      targetRows,
      comparable.map((column) => column.name),
    );
    const rowDiff = Math.abs(sourceRows.length - targetRows.length);
    footprintDiffCount += rowDiff;
    columnDiffCount += missingColumns;
    for (let index = 0; index < Math.min(sourceSorted.length, targetSorted.length); index += 1) {
      for (const column of comparable) {
        if (
          normalize(valueOf(sourceSorted[index], column.name)) !==
          normalize(valueOf(targetSorted[index], column.name))
        ) {
          columnDiffCount += 1;
        }
      }
    }
    let tableNumericDiff = 0;
    for (const column of comparable.filter((candidate) => {
      const targetType = String(
        targetByName.get(candidate.name.toUpperCase())?.type ?? '',
      ).toLowerCase();
      return NUMERIC_TYPES.has(candidate.type) && NUMERIC_TYPES.has(targetType);
    })) {
      const sourceSum = sourceRows.reduce((sum, row) => sum + number(valueOf(row, column.name)), 0);
      const targetSum = targetRows.reduce((sum, row) => sum + number(valueOf(row, column.name)), 0);
      if (!sumsMatch(sourceSum, targetSum)) tableNumericDiff += 1;
    }
    numericSumDiff += tableNumericDiff;
    tableResults.push({
      table,
      sourceRows: sourceRows.length,
      targetRows: targetRows.length,
      rowCountDiff: rowDiff,
      missingColumnCount: missingColumns,
      numericSumDiff: tableNumericDiff,
    });
  }
  return {
    artifact: buildFormArtifact(new Date().toISOString(), {
      formId: form.formId,
      tablesCompared,
      columnDiffCount,
      numericSumDiff,
      footprintDiffCount,
      completed: true,
    }),
    tableResults,
  };
}

async function tableSigma(pool, prisma, options, tenant, tables) {
  const results = [];
  for (const table of tables) {
    const [sourceMeta, targetMeta] = await Promise.all([
      sourceColumns(pool, options.database, table),
      targetColumns(prisma, table),
    ]);
    if (!sourceMeta.length || !targetMeta.length) {
      results.push({
        table,
        status: 'failed',
        reason: !sourceMeta.length ? 'source table missing' : 'target table missing',
        columnDiffCount: null,
        numericSumDiff: null,
      });
      continue;
    }
    const targetByName = new Map(
      targetMeta.map((column) => [String(column.name).toUpperCase(), column]),
    );
    const missingColumns = sourceMeta.filter(
      (column) =>
        !targetByName.has(column.name.toUpperCase()) &&
        !['TENANT_ID', 'ROW_ID'].includes(column.name.toUpperCase()),
    );
    const numeric = sourceMeta.filter((column) => {
      const targetType = String(
        targetByName.get(column.name.toUpperCase())?.type ?? '',
      ).toLowerCase();
      return NUMERIC_TYPES.has(column.type) && NUMERIC_TYPES.has(targetType);
    });
    const sourceSelect = [
      'COUNT(*) AS row_count',
      ...numeric.map((column, index) => `SUM(CAST(${qms(column.name)} AS float)) AS sum_${index}`),
    ].join(',');
    const sourceRow = (
      await pool
        .request()
        .query(`SELECT ${sourceSelect} FROM ${qms(options.database)}.dbo.${qms(table)}`)
    ).recordset[0];
    const targetRow = await withTenant(prisma, tenant, async (tx) => {
      const targetSelect = [
        'COUNT(*)::bigint AS row_count',
        ...numeric.map(
          (column, index) => `SUM(${qpg(column.name)}::double precision) AS sum_${index}`,
        ),
      ].join(',');
      return (await tx.$queryRawUnsafe(`SELECT ${targetSelect} FROM ${qpg(table)}`))[0];
    });
    let numericSumDiff = 0;
    for (let index = 0; index < numeric.length; index += 1) {
      if (!sumsMatch(number(sourceRow[`sum_${index}`]), number(targetRow[`sum_${index}`])))
        numericSumDiff += 1;
    }
    const rowCountDiff = Math.abs(number(sourceRow.row_count) - number(targetRow.row_count));
    results.push({
      table,
      status:
        missingColumns.length === 0 && numericSumDiff === 0 && rowCountDiff === 0
          ? 'passed'
          : 'failed',
      sourceRows: number(sourceRow.row_count),
      targetRows: number(targetRow.row_count),
      rowCountDiff,
      columnDiffCount: missingColumns.length,
      missingColumns: missingColumns.map((column) => column.name),
      numericColumnsCompared: numeric.length,
      numericSumDiff,
    });
  }
  const failedTables = results.filter((result) => result.status === 'failed').length;
  return {
    status: failedTables === 0 ? 'passed' : 'failed',
    result: {
      tablesCompared: results.length,
      failedTables,
      columnDiffCount: results.reduce((sum, result) => sum + number(result.columnDiffCount), 0),
      numericSumDiff: results.reduce((sum, result) => sum + number(result.numericSumDiff), 0),
      tables: results,
    },
  };
}

async function calcRecomputation(pool, options) {
  const rows = (
    await pool.request().query(`SELECT VCH_NO, NET_AMT, DISC_AMT, TAX_PRC, IGST_TAX,
      CGST_TAX, SGST_TAX, TAX_AMT, TOT_AMT FROM ${qms(options.database)}.dbo.SL_DATA`)
  ).recordset;
  let taxDiffs = 0;
  let totalDiffs = 0;
  let storedTaxDiffs = 0;
  const samples = [];
  for (const row of rows) {
    const computed = billTotals({
      lineNetTotal: number(row.NET_AMT),
      discountAmount: number(row.DISC_AMT),
      taxRatePct: number(row.TAX_PRC),
      interState: number(row.IGST_TAX) > 0,
    });
    const taxDiff = Math.abs(round(computed.tax, 2) - round(row.TAX_AMT, 2));
    const totalDiff = Math.abs(round(computed.total, 2) - round(row.TOT_AMT, 2));
    const storedTaxDiff = Math.abs(
      round(row.TAX_AMT, 2) -
        round(number(row.CGST_TAX) + number(row.SGST_TAX) + number(row.IGST_TAX), 2),
    );
    if (taxDiff > 1) taxDiffs += 1;
    if (totalDiff > 1) totalDiffs += 1;
    if (storedTaxDiff >= 0.05) storedTaxDiffs += 1;
    if (samples.length < 4) {
      samples.push({
        voucher: row.VCH_NO,
        taxDiff: round(taxDiff, 2),
        totalDiff: round(totalDiff, 2),
      });
    }
  }
  const unexplainedDiffCount = taxDiffs + totalDiffs + storedTaxDiffs;
  return {
    status: rows.length > 0 && unexplainedDiffCount === 0 ? 'passed' : 'failed',
    ...(rows.length === 0 ? { reason: 'SL_DATA contains no invoices to recompute.' } : {}),
    result: {
      invoices: rows.length,
      taxDiffs,
      totalDiffs,
      storedTaxDiffs,
      unexplainedDiffCount,
      samples,
    },
  };
}

async function runLive(pool, prisma, options, env, generatedAt) {
  const forms = parseForms(env.G5_FORMS);
  const tenant = String(env.G5_TARGET_TENANT || env.CUTOVER_TENANT_ID || '').trim();
  if (!tenant) throw new Error('G5_TARGET_TENANT is not configured.');
  if (!env.DATABASE_URL) throw new Error('DATABASE_URL is not configured.');
  await prisma.$queryRawUnsafe('SELECT 1');
  const [sourceTables, targetTables] = await Promise.all([
    sourceVoucherTables(pool, options.database),
    targetVoucherTables(prisma),
  ]);
  const targetByUpper = new Map(targetTables.map((table) => [table.toUpperCase(), table]));
  const voucherTables = sourceTables
    .filter((table) => targetByUpper.has(table.toUpperCase()))
    .map((table) => targetByUpper.get(table.toUpperCase()));
  const formArtifacts = [];
  const formResults = [];
  for (const form of forms) {
    try {
      const comparison = await compareForm(pool, prisma, options, tenant, form, voucherTables);
      formArtifacts.push({ ...comparison.artifact, generatedAt });
      formResults.push({ formId: form.formId, tables: comparison.tableResults });
    } catch (error) {
      formArtifacts.push(
        buildFormArtifact(generatedAt, {
          formId: form.formId,
          tablesCompared: [],
          columnDiffCount: null,
          numericSumDiff: null,
          footprintDiffCount: null,
          completed: false,
          error: messageOf(error),
        }),
      );
      formResults.push({ formId: form.formId, error: messageOf(error) });
    }
  }
  const sigma = await tableSigma(pool, prisma, options, tenant, tableList(env.G5_TABLES));
  const footprintDiffCount = formArtifacts.reduce(
    (sum, artifact) => sum + (artifact.footprintDiffCount ?? 1),
    0,
  );
  const columnDiffCount = formArtifacts.reduce(
    (sum, artifact) => sum + (artifact.columnDiffCount ?? 1),
    0,
  );
  const footprint = {
    status: footprintDiffCount === 0 ? 'passed' : 'failed',
    result: { formsCompared: formArtifacts.length, footprintDiffCount, forms: formResults },
  };
  const voucherColumns = {
    status: columnDiffCount === 0 ? 'passed' : 'failed',
    result: { formsCompared: formArtifacts.length, columnDiffCount },
  };
  const calc = await calcRecomputation(pool, options);
  return aggregateLiveReport({
    generatedAt,
    golden: runParity(),
    identity: { host: options.host, port: options.port, database: options.database },
    checks: { sigma, footprint, voucherColumns, calcRecomputation: calc },
    forms: formArtifacts,
  });
}

export async function main(env = process.env) {
  const generatedAt = new Date().toISOString();
  const artifactDirectory = resolve(G5_ROOT, timestampPath(generatedAt));
  const golden = runParity();
  const source = sourceOptions(env);
  let report;
  let pool;
  let prisma;
  if (!source.configured) {
    report = buildDegradedReport({
      generatedAt,
      golden,
      sourceConfigured: false,
      reason: `Desktop source is not configured; missing ${source.missing.join(', ')}.`,
    });
  } else {
    const identity = {
      host: source.value.host,
      port: source.value.port,
      database: source.value.database,
    };
    try {
      pool = await new sql.ConnectionPool({
        server: source.value.host,
        port: source.value.port,
        user: source.value.user,
        password: source.value.password,
        database: source.value.database,
        connectionTimeout: source.value.connectTimeoutMs,
        requestTimeout: source.value.requestTimeoutMs,
        options: {
          encrypt: source.value.encrypt,
          trustServerCertificate: source.value.trustServerCertificate,
        },
      }).connect();
    } catch (error) {
      report = buildDegradedReport({
        generatedAt,
        golden,
        sourceConfigured: true,
        identity,
        reason: `Configured desktop source is unreachable: ${messageOf(error)}`,
      });
    }
    if (pool) {
      try {
        parseForms(env.G5_FORMS);
        if (!String(env.G5_TARGET_TENANT ?? env.CUTOVER_TENANT_ID ?? '').trim()) {
          throw new Error('G5_TARGET_TENANT is not configured.');
        }
      } catch (error) {
        report = buildDegradedReport({
          generatedAt,
          golden,
          sourceConfigured: true,
          sourceReachable: true,
          identity,
          reason: `Live comparison inputs are incomplete: ${messageOf(error)}`,
        });
      }
      if (!report) {
        prisma = new PrismaClient({ datasources: { db: { url: env.DATABASE_URL } } });
        try {
          report = await runLive(pool, prisma, source.value, env, generatedAt);
        } catch (error) {
          report = aggregateLiveReport({
            generatedAt,
            golden,
            identity,
            checks: {
              sigma: { status: 'failed', reason: messageOf(error) },
              footprint: {
                status: 'skipped',
                reason: 'Live orchestration stopped before this check completed.',
              },
              voucherColumns: {
                status: 'skipped',
                reason: 'Live orchestration stopped before this check completed.',
              },
              calcRecomputation: {
                status: 'skipped',
                reason: 'Live orchestration stopped before this check completed.',
              },
            },
            forms: [],
          });
        }
      }
    }
  }
  await Promise.resolve(prisma?.$disconnect()).catch(() => undefined);
  await Promise.resolve(pool?.close()).catch(() => undefined);
  const reportPath = await writeArtifacts(report, artifactDirectory);
  process.stdout.write(
    `[G5] mode=${report.mode} verdict=${report.verdict} golden=${report.goldenVectors.result?.passed}/${report.goldenVectors.result?.total}\n`,
  );
  for (const skipped of report.skippedChecks) {
    process.stdout.write(`[G5] SKIPPED ${skipped.check}: ${skipped.reason}\n`);
  }
  process.stdout.write(`[G5] artifact=${reportPath}\n`);
  if (report.verdict === 'failed') process.exitCode = 1;
  return { report, reportPath };
}

main().catch((error) => {
  console.error('[G5] FATAL', messageOf(error));
  process.exitCode = 1;
});
