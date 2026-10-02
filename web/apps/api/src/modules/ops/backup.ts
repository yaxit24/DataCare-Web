import { Prisma, type PrismaClient } from '@prisma/client';
import { withTenant, type Tx } from '@datacare/db';
import { withTxBudget } from '../shared/txBudget.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import {
  COMPANY_BACKUP_KIND,
  COMPANY_BACKUP_VERSION,
  CompanyBackupValidationError,
  assertCompanyBackupIntegrity,
  checksumBackupRows,
  decodeBackupCell,
  encodeBackupRow,
  loadBackupSchemaManifest,
  orderedCompanyTables,
  resealCompanyBackupDocument,
  stableStringify,
  type BackupColumnManifest,
  type BackupSchemaManifest,
  type BackupTableManifest,
  type CompanyBackupDocument,
  type EncodedBackupRow,
} from './backupManifest.js';

export type { CompanyBackupDocument as CompanyBackup } from './backupManifest.js';
export {
  COMPANY_BACKUP_KIND,
  COMPANY_BACKUP_VERSION,
  CompanyBackupValidationError,
  assertCompanyBackupIntegrity,
  loadBackupSchemaManifest,
  resealCompanyBackupDocument,
} from './backupManifest.js';

const BACKUP_TRANSACTION_TIMEOUT_MS = 120_000;
const RESTORE_TRANSACTION_TIMEOUT_MS = 300_000;

const quoteIdentifier = (identifier: string): string => {
  if (!identifier || identifier.includes('\0'))
    throw new CompanyBackupValidationError('invalid database identifier');
  return `"${identifier.replaceAll('"', '""')}"`;
};

const companyFilter = `"tenant_id"=$1 AND "CO_CODE"::text=$2::text`;

const losslessColumnExpression = (column: BackupColumnManifest): string => {
  const identifier = quoteIdentifier(column.name);
  if (column.dataType === 'bytea') return `encode(${identifier},'base64') AS ${identifier}`;
  if (
    column.dataType === 'bigint' ||
    column.dataType === 'numeric' ||
    column.dataType === 'decimal' ||
    column.dataType === 'money' ||
    column.dataType === 'double precision' ||
    column.dataType === 'real' ||
    column.dataType === 'date' ||
    column.dataType === 'time' ||
    column.dataType.startsWith('timestamp') ||
    column.dataType === 'json' ||
    column.dataType === 'jsonb'
  )
    return `${identifier}::text AS ${identifier}`;
  return identifier;
};

const readEncodedCompanyRows = async (
  tx: Tx,
  table: BackupTableManifest,
  target: RestoreCompanyTarget,
): Promise<EncodedBackupRow[]> => {
  const orderBy = table.primaryKey.length
    ? ` ORDER BY ${table.primaryKey.map(quoteIdentifier).join(',')}`
    : '';
  const rows = await tx.$queryRawUnsafe<Array<Record<string, unknown>>>(
    `SELECT ${table.columns.map(losslessColumnExpression).join(',')}
       FROM ${quoteIdentifier(table.name)}
      WHERE ${companyFilter}${orderBy}`,
    target.tenantId,
    target.companyCode,
  );
  return rows.map((row) => encodeBackupRow(row, table));
};

const assertRestoreDocument = (value: unknown): CompanyBackupDocument => {
  if (!value || typeof value !== 'object' || Array.isArray(value))
    throw new CompanyBackupValidationError('company backup document must be an object');
  const document = value as CompanyBackupDocument;
  try {
    assertCompanyBackupIntegrity(document);
  } catch (error) {
    if (error instanceof CompanyBackupValidationError) throw error;
    throw new CompanyBackupValidationError(
      `malformed company backup: ${error instanceof Error ? error.message : String(error)}`,
    );
  }
  return document;
};

export async function backupCompany(
  prisma: PrismaClient,
  tenantId: string,
  coCode: string,
): Promise<CompanyBackupDocument> {
  if (!tenantId || !coCode)
    throw new CompanyBackupValidationError('tenant and company are required for backup');
  return withTenant(
    prisma,
    tenantId,
    async (tx) => {
      await tx.$executeRawUnsafe(`SET LOCAL TIME ZONE 'UTC'`);
      const settings = await resolveSettingsBehaviorTx(tx, { tenantId, coCode });
      const manifest = await loadBackupSchemaManifest(tx);
      const tables: CompanyBackupDocument['tables'] = {};
      for (const table of orderedCompanyTables(manifest)) {
        const rows = await readEncodedCompanyRows(tx, table, {
          tenantId,
          companyCode: coCode,
        });
        tables[table.name] = {
          rows,
          rowCount: rows.length,
          checksum: '',
        };
      }
      const draft: CompanyBackupDocument = {
        kind: COMPANY_BACKUP_KIND,
        version: COMPANY_BACKUP_VERSION,
        generatedAt: new Date().toISOString(),
        tenant: tenantId,
        company: coCode,
        databaseTarget: settings.exportDatabaseTarget,
        source: { tenantId, companyCode: coCode },
        manifest,
        totals: {
          schemaTables: manifest.tables.length,
          companyTables: Object.keys(tables).length,
          excludedTables: manifest.tables.filter((table) => !table.included).length,
          rows: 0,
        },
        tables,
        checksum: '',
      };
      const document = resealCompanyBackupDocument(draft);
      assertCompanyBackupIntegrity(document);
      return document;
    },
    {
      isolationLevel: Prisma.TransactionIsolationLevel.RepeatableRead,
      timeout: BACKUP_TRANSACTION_TIMEOUT_MS,
    },
  );
}

export interface RestoreCompanyTarget {
  tenantId: string;
  companyCode: string;
}

/**
 * Record that a backup artefact was handed to an operator.
 *
 * Deliberately NOT part of `backupCompany`. That function is also the comparison oracle used by restore
 * verification and by the WP-02A tests, so it must stay side-effect free — a snapshot that writes cannot be
 * used to prove that nothing else changed.
 *
 * What this row buys is the ability to require a REAL backup reference before a destructive data repair
 * (`dataRepair.applyRepair`). Failing to record is fail-safe rather than fail-open: an unrecorded backup
 * simply cannot be named as cover for a repair.
 */
export async function recordCompanyBackup(
  prisma: PrismaClient,
  document: CompanyBackupDocument,
  operator?: string,
): Promise<void> {
  await withTxBudget(prisma, document.tenant, 'voucher', async (tx) => {
    await tx.$executeRawUnsafe(
      `INSERT INTO "company_backup_run"
         (tenant_id,co_code,checksum,document_version,generated_at,table_count,row_count,operator)
       VALUES ($1,$2,$3,$4,$5::timestamptz,$6,$7,$8)
       ON CONFLICT (tenant_id,co_code,checksum) DO NOTHING`,
      document.tenant,
      document.company,
      document.checksum,
      document.version,
      document.generatedAt,
      document.totals.companyTables,
      document.totals.rows,
      operator?.slice(0, 64) ?? null,
    );
  });
}
export interface RestoreCompanyResult {
  mode: 'replace';
  tenant: string;
  company: string;
  schemaFingerprint: string;
  restored: number;
  cleared: number;
  deleted: Record<string, number>;
  inserted: Record<string, number>;
  tableChecksums: Record<string, string>;
}

interface PreparedTable {
  table: BackupTableManifest;
  columns: BackupColumnManifest[];
  rows: unknown[][];
}

const prepareRestoreRows = (
  document: CompanyBackupDocument,
  target: RestoreCompanyTarget,
): PreparedTable[] =>
  orderedCompanyTables(document.manifest).map((table) => {
    if (
      table.columns.some(
        (column) =>
          column.sequence !== null &&
          (column.sequence.cycle ||
            !/^\d+$/.test(column.sequence.increment) ||
            BigInt(column.sequence.increment) <= 0n),
      )
    )
      throw new CompanyBackupValidationError(
        `${table.name} contains an unsupported cycling or non-positive owned sequence`,
      );
    if (table.triggers.length)
      throw new CompanyBackupValidationError(
        `${table.name} contains restore-side-effect triggers, which are not supported`,
      );
    if (table.columns.some((column) => column.generated))
      throw new CompanyBackupValidationError(
        `${table.name} contains generated columns, which this restore version cannot preserve`,
      );
    const columns = table.columns;
    const rows = document.tables[table.name]!.rows.map((row) =>
      columns.map((column) => {
        if (column.name === 'tenant_id') return target.tenantId;
        if (column.name === 'CO_CODE') return target.companyCode;
        return decodeBackupCell(row[column.name] ?? null, column);
      }),
    );
    return { table, columns, rows };
  });

const parameterCast = (column: BackupColumnManifest): string =>
  column.dataType === 'character varying' ||
  column.dataType === 'character' ||
  column.dataType === 'text'
    ? 'text'
    : column.formattedType;

const insertRows = async (
  tx: Tx,
  prepared: PreparedTable,
  destinationName = prepared.table.name,
  destinationSchema?: string,
): Promise<number> => {
  if (!prepared.rows.length) return 0;
  const qTable = destinationSchema
    ? `${quoteIdentifier(destinationSchema)}.${quoteIdentifier(destinationName)}`
    : quoteIdentifier(destinationName);
  const qColumns = prepared.columns.map((column) => quoteIdentifier(column.name)).join(',');
  const overrideIdentity = prepared.columns.some((column) => column.identity)
    ? ' OVERRIDING SYSTEM VALUE'
    : '';
  const rowsPerBatch = Math.max(
    1,
    Math.min(250, Math.floor(30_000 / Math.max(prepared.columns.length, 1))),
  );
  let inserted = 0;
  for (let start = 0; start < prepared.rows.length; start += rowsPerBatch) {
    const batch = prepared.rows.slice(start, start + rowsPerBatch);
    const values: unknown[] = [];
    const tuples = batch.map((row) => {
      const placeholders = row.map((value, columnIndex) => {
        values.push(value);
        const column = prepared.columns[columnIndex]!;
        return `$${values.length}::${parameterCast(column)}`;
      });
      return `(${placeholders.join(',')})`;
    });
    const count = await tx.$executeRawUnsafe(
      `INSERT INTO ${qTable} (${qColumns})${overrideIdentity} VALUES ${tuples.join(',')}`,
      ...values,
    );
    inserted += count;
  }
  return inserted;
};

const advanceOwnedSequences = async (tx: Tx, table: BackupTableManifest): Promise<void> => {
  for (const column of table.columns.filter((entry) => entry.sequence !== null)) {
    await tx.$executeRawUnsafe(
      `SELECT public.datacare_advance_owned_sequence($1::regclass,$2::name)`,
      `public.${quoteIdentifier(table.name)}`,
      column.name,
    );
  }
};

export async function restoreCompany(
  prisma: PrismaClient,
  target: RestoreCompanyTarget,
  value: unknown,
  options: { mode: 'replace' } = { mode: 'replace' },
): Promise<RestoreCompanyResult> {
  if (options.mode !== 'replace')
    throw new CompanyBackupValidationError('only replace-mode company restore is supported');
  if (!target.tenantId || !target.companyCode)
    throw new CompanyBackupValidationError('authenticated tenant and company are required');
  const document = assertRestoreDocument(value);
  if (document.source.tenantId !== target.tenantId)
    throw new CompanyBackupValidationError('backup tenant does not match the authenticated tenant');
  if (document.source.companyCode !== target.companyCode)
    throw new CompanyBackupValidationError(
      'backup company does not match the authenticated company',
    );
  const prepared = prepareRestoreRows(document, target);

  return withTenant(
    prisma,
    target.tenantId,
    async (tx) => {
      await tx.$executeRawUnsafe(`SET LOCAL TIME ZONE 'UTC'`);
      await lockRestoreTables(tx, target, prepared);
      const liveManifest = await loadBackupSchemaManifest(tx);
      if (
        liveManifest.fingerprint !== document.manifest.fingerprint ||
        stableStringify(liveManifest.tables) !== stableStringify(document.manifest.tables)
      )
        throw new CompanyBackupValidationError(
          'live database schema does not exactly match the backup manifest',
        );
      await preflightRestoreRows(tx, prepared, document.manifest);

      const deleted: Record<string, number> = {};
      const inserted: Record<string, number> = {};
      for (const item of [...prepared].reverse()) {
        deleted[item.table.name] = await tx.$executeRawUnsafe(
          `DELETE FROM ${quoteIdentifier(item.table.name)} WHERE ${companyFilter}`,
          target.tenantId,
          target.companyCode,
        );
      }
      for (const item of prepared) inserted[item.table.name] = await insertRows(tx, item);

      const tableChecksums: Record<string, string> = {};
      for (const item of prepared) {
        const expected = document.tables[item.table.name]!;
        if (inserted[item.table.name] !== expected.rowCount)
          throw new CompanyBackupValidationError(
            `${item.table.name} inserted ${inserted[item.table.name]} rows; expected ${expected.rowCount}`,
          );
        const restoredRows = await readEncodedCompanyRows(tx, item.table, target);
        const restoredChecksum = checksumBackupRows(restoredRows);
        if (restoredRows.length !== expected.rowCount || restoredChecksum !== expected.checksum)
          throw new CompanyBackupValidationError(
            `${item.table.name} restored rows do not match the backup checksum`,
          );
        tableChecksums[item.table.name] = restoredChecksum;
      }
      for (const item of prepared) await advanceOwnedSequences(tx, item.table);
      return {
        mode: 'replace' as const,
        tenant: target.tenantId,
        company: target.companyCode,
        schemaFingerprint: document.manifest.fingerprint,
        restored: Object.values(inserted).reduce((sum, count) => sum + count, 0),
        cleared: Object.values(deleted).reduce((sum, count) => sum + count, 0),
        deleted,
        inserted,
        tableChecksums,
      };
    },
    {
      isolationLevel: Prisma.TransactionIsolationLevel.Serializable,
      timeout: RESTORE_TRANSACTION_TIMEOUT_MS,
    },
  );
}

const lockRestoreTables = async (
  tx: Tx,
  target: RestoreCompanyTarget,
  prepared: readonly PreparedTable[],
): Promise<void> => {
  await tx.$executeRawUnsafe(
    `SELECT pg_advisory_xact_lock(hashtextextended($1,0))`,
    `${target.tenantId.length}:${target.tenantId}${target.companyCode}`,
  );
  const names = new Set(prepared.map((item) => item.table.name));
  for (const item of prepared)
    for (const constraint of item.table.constraints)
      if (constraint.type === 'f' && constraint.referencedSchema === 'public')
        if (constraint.referencedTable) names.add(constraint.referencedTable);
  const tables = [...names]
    .sort()
    .map((name) => `public.${quoteIdentifier(name)}`)
    .join(',');
  if (tables) await tx.$executeRawUnsafe(`LOCK TABLE ${tables} IN SHARE ROW EXCLUSIVE MODE`);
};

const preflightRestoreRows = async (
  tx: Tx,
  prepared: readonly PreparedTable[],
  manifest: BackupSchemaManifest,
): Promise<void> => {
  if (prepared.some((item) => item.table.columns.some((column) => column.sequence !== null))) {
    const [guard] = await tx.$queryRawUnsafe<Array<{ installed: boolean; executable: boolean }>>(
      `WITH function_oid AS (
         SELECT to_regprocedure('public.datacare_advance_owned_sequence(regclass,name)') AS oid
       )
       SELECT oid IS NOT NULL AS installed,
              CASE WHEN oid IS NULL THEN false
                   ELSE has_function_privilege(current_user,oid,'EXECUTE') END AS executable
         FROM function_oid`,
    );
    if (!guard?.installed || !guard.executable)
      throw new CompanyBackupValidationError(
        'guarded company restore sequence function is unavailable',
      );
  }

  for (const item of prepared) {
    await tx.$executeRawUnsafe(
      `CREATE TEMP TABLE ${quoteIdentifier(item.table.name)}
         (LIKE public.${quoteIdentifier(item.table.name)} INCLUDING ALL)
         ON COMMIT DROP`,
    );
  }

  const companyNames = new Set(prepared.map((item) => item.table.name));
  const externalNames = new Set<string>();
  for (const item of prepared) {
    for (const constraint of item.table.constraints.filter((entry) => entry.type === 'f')) {
      if (constraint.referencedSchema !== 'public' || !constraint.referencedTable)
        throw new CompanyBackupValidationError(
          `${item.table.name} has an unsupported cross-schema foreign key`,
        );
      if (!companyNames.has(constraint.referencedTable))
        externalNames.add(constraint.referencedTable);
    }
  }

  for (const name of [...externalNames].sort()) {
    const table = manifest.tables.find((entry) => entry.name === name);
    if (!table)
      throw new CompanyBackupValidationError(
        `${name} foreign-key parent is absent from the manifest`,
      );
    if (table.columns.some((column) => column.generated))
      throw new CompanyBackupValidationError(`${name} generated FK parent cannot be preflighted`);
    await tx.$executeRawUnsafe(
      `CREATE TEMP TABLE ${quoteIdentifier(name)}
         (LIKE public.${quoteIdentifier(name)} INCLUDING ALL)
         ON COMMIT DROP`,
    );
    const columns = table.columns.map((column) => quoteIdentifier(column.name)).join(',');
    const overrideIdentity = table.columns.some((column) => column.identity)
      ? ' OVERRIDING SYSTEM VALUE'
      : '';
    await tx.$executeRawUnsafe(
      `INSERT INTO pg_temp.${quoteIdentifier(name)} (${columns})${overrideIdentity}
       SELECT ${columns} FROM public.${quoteIdentifier(name)}`,
    );
  }

  const temporaryNames = new Set([...companyNames, ...externalNames]);
  for (const item of prepared) {
    for (const constraint of item.table.constraints.filter((entry) => entry.type === 'f')) {
      const referenced = constraint.referencedTable!;
      if (!temporaryNames.has(referenced))
        throw new CompanyBackupValidationError(
          `${item.table.name} foreign-key parent cannot be preflighted safely`,
        );
      const escaped = referenced.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
      const reference = new RegExp(
        `(REFERENCES\\s+)(?:ONLY\\s+)?(?:(?:"public"|public)\\s*\\.\\s*)?(?:"${escaped}"|${escaped})(?=\\s*\\()`,
        'i',
      );
      const definition = constraint.definition.replace(
        reference,
        `$1pg_temp.${quoteIdentifier(referenced)}`,
      );
      if (definition === constraint.definition)
        throw new CompanyBackupValidationError(
          `${item.table.name} foreign-key definition cannot be preflighted safely`,
        );
      await tx.$executeRawUnsafe(
        `ALTER TABLE pg_temp.${quoteIdentifier(item.table.name)}
           ADD CONSTRAINT ${quoteIdentifier(constraint.name)} ${definition}`,
      );
    }
  }

  for (const item of prepared) {
    const inserted = await insertRows(tx, item, item.table.name, 'pg_temp');
    if (inserted !== item.rows.length)
      throw new CompanyBackupValidationError(
        `${item.table.name} preflight inserted ${inserted} rows; expected ${item.rows.length}`,
      );
  }
  for (const item of [...prepared].reverse())
    await tx.$executeRawUnsafe(`DROP TABLE pg_temp.${quoteIdentifier(item.table.name)}`);
  for (const name of [...externalNames].sort())
    await tx.$executeRawUnsafe(`DROP TABLE pg_temp.${quoteIdentifier(name)}`);
};
