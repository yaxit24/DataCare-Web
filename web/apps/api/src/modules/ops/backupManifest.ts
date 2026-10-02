import { createHash } from 'node:crypto';

export const COMPANY_BACKUP_KIND = 'datacare.company-backup' as const;
export const COMPANY_BACKUP_VERSION = 2 as const;
export const BACKUP_SCHEMA_KIND = 'datacare.company-backup-schema' as const;

export type BackupTableScope = 'company' | 'tenant-shared' | 'system';

export interface BackupSequenceManifest {
  name: string;
  dataType: string;
  start: string;
  minimum: string;
  maximum: string;
  increment: string;
  cycle: boolean;
  cache: string;
}

export interface BackupColumnManifest {
  name: string;
  ordinal: number;
  dataType: string;
  udtName: string;
  formattedType: string;
  collation: string | null;
  nullable: boolean;
  defaultExpression: string | null;
  generated: boolean;
  identity: boolean;
  sequence: BackupSequenceManifest | null;
}

export interface BackupConstraintManifest {
  name: string;
  type: string;
  definition: string;
  deferrable: boolean;
  initiallyDeferred: boolean;
  referencedSchema: string | null;
  referencedTable: string | null;
}

export interface BackupIndexManifest {
  name: string;
  definition: string;
}

export interface BackupPolicyManifest {
  name: string;
  command: string;
  permissive: string;
  roles: string[];
  usingExpression: string | null;
  checkExpression: string | null;
}

export interface BackupTriggerManifest {
  enabled: string;
  definition: string;
}

export interface BackupTableManifest {
  name: string;
  scope: BackupTableScope;
  included: boolean;
  exclusionReason: string | null;
  primaryKey: string[];
  dependencies: string[];
  rlsEnabled: boolean;
  rlsForced: boolean;
  constraints: BackupConstraintManifest[];
  indexes: BackupIndexManifest[];
  policies: BackupPolicyManifest[];
  triggers: BackupTriggerManifest[];
  columns: BackupColumnManifest[];
}

export interface BackupSchemaManifest {
  kind: typeof BACKUP_SCHEMA_KIND;
  fingerprint: string;
  tables: BackupTableManifest[];
}

export type EncodedCell =
  | null
  | string
  | number
  | boolean
  | { $dcType: 'bytea'; value: string }
  | { $dcType: 'bigint'; value: string }
  | { $dcType: 'decimal'; value: string }
  | { $dcType: 'float'; value: string }
  | { $dcType: 'date-time'; value: string }
  | { $dcType: 'json'; value: string };

export type EncodedBackupRow = Record<string, EncodedCell>;

export interface BackupTableData {
  rowCount: number;
  checksum: string;
  rows: EncodedBackupRow[];
}

export interface CompanyBackupDocument {
  kind: typeof COMPANY_BACKUP_KIND;
  version: typeof COMPANY_BACKUP_VERSION;
  generatedAt: string;
  tenant: string;
  company: string;
  databaseTarget: string;
  source: {
    tenantId: string;
    companyCode: string;
  };
  manifest: BackupSchemaManifest;
  totals: {
    schemaTables: number;
    companyTables: number;
    excludedTables: number;
    rows: number;
  };
  tables: Record<string, BackupTableData>;
  checksum: string;
}

export class CompanyBackupValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'CompanyBackupValidationError';
  }
}

type Queryable = {
  $queryRawUnsafe<T = unknown>(query: string, ...values: unknown[]): Promise<T>;
};

interface ColumnRow {
  table_name: string;
  column_name: string;
  ordinal_position: number | bigint;
  data_type: string;
  udt_name: string;
  formatted_type: string;
  collation_name: string | null;
  is_nullable: 'YES' | 'NO';
  column_default: string | null;
  is_generated: string;
  is_identity: string;
}

interface KeyRow {
  table_name: string;
  column_name: string;
  ordinal_position: number | bigint;
}

interface TableRow {
  table_name: string;
  column_count: number | bigint;
  rls_enabled: boolean;
  rls_forced: boolean;
}

interface ConstraintRow {
  table_name: string;
  constraint_name: string;
  constraint_type: string;
  definition: string;
  is_deferrable: boolean;
  initially_deferred: boolean;
  referenced_schema: string | null;
  referenced_table: string | null;
}

interface IndexRow {
  table_name: string;
  index_name: string;
  definition: string;
}

interface PolicyRow {
  table_name: string;
  policy_name: string;
  command: string;
  permissive: string;
  roles: string[];
  using_expression: string | null;
  check_expression: string | null;
}

interface TriggerRow {
  table_name: string;
  enabled: string;
  definition: string;
}

interface SequenceRow {
  table_name: string;
  column_name: string;
  sequence_name: string;
  data_type: string;
  start_value: bigint;
  minimum_value: bigint;
  maximum_value: bigint;
  increment_by: bigint;
  cycle: boolean;
  cache_size: bigint;
}

const sha256 = (value: string): string => createHash('sha256').update(value, 'utf8').digest('hex');

export function stableStringify(value: unknown): string {
  if (value === null) return 'null';
  if (typeof value === 'string' || typeof value === 'boolean') return JSON.stringify(value);
  if (typeof value === 'number') {
    if (!Number.isFinite(value))
      throw new CompanyBackupValidationError('non-finite number in backup');
    return JSON.stringify(value);
  }
  if (Array.isArray(value)) return `[${value.map(stableStringify).join(',')}]`;
  if (typeof value === 'object') {
    const record = value as Record<string, unknown>;
    return `{${Object.keys(record)
      .sort()
      .map((key) => {
        if (record[key] === undefined)
          throw new CompanyBackupValidationError(`undefined value at ${key}`);
        return `${JSON.stringify(key)}:${stableStringify(record[key])}`;
      })
      .join(',')}}`;
  }
  throw new CompanyBackupValidationError(`unsupported backup value type: ${typeof value}`);
}

export function checksumBackupRows(rows: readonly EncodedBackupRow[]): string {
  return sha256(rows.map(stableStringify).sort().join('\n'));
}

export function schemaFingerprint(tables: readonly BackupTableManifest[]): string {
  return sha256(
    stableStringify(
      [...tables]
        .sort((left, right) => left.name.localeCompare(right.name))
        .map((table) => ({
          name: table.name,
          scope: table.scope,
          included: table.included,
          exclusionReason: table.exclusionReason,
          primaryKey: table.primaryKey,
          dependencies: table.dependencies,
          rlsEnabled: table.rlsEnabled,
          rlsForced: table.rlsForced,
          constraints: table.constraints,
          indexes: table.indexes,
          policies: table.policies,
          triggers: table.triggers,
          columns: table.columns,
        })),
    ),
  );
}

export function documentChecksum(document: CompanyBackupDocument): string {
  const { checksum: _checksum, ...payload } = document;
  return sha256(stableStringify(payload));
}

const tableScope = (
  name: string,
  columns: readonly BackupColumnManifest[],
): Pick<BackupTableManifest, 'scope' | 'included' | 'exclusionReason'> => {
  const names = new Set(columns.map((column) => column.name));
  if (names.has('tenant_id') && names.has('CO_CODE')) {
    return { scope: 'company', included: true, exclusionReason: null };
  }
  if (names.has('tenant_id')) {
    return {
      scope: 'tenant-shared',
      included: false,
      exclusionReason: 'tenant-shared table has no CO_CODE and cannot be isolated by company',
    };
  }
  return {
    scope: 'system',
    included: false,
    exclusionReason: 'system/global table is outside a company-scoped logical restore',
  };
};

export async function loadBackupSchemaManifest(tx: Queryable): Promise<BackupSchemaManifest> {
  const tableRows = await tx.$queryRawUnsafe<TableRow[]>(
    `SELECT cl.relname AS table_name,
            count(a.attnum) FILTER (WHERE a.attnum > 0 AND NOT a.attisdropped)::int AS column_count,
            cl.relrowsecurity AS rls_enabled,
            cl.relforcerowsecurity AS rls_forced
       FROM pg_catalog.pg_class cl
       JOIN pg_catalog.pg_namespace n ON n.oid=cl.relnamespace
       LEFT JOIN pg_catalog.pg_attribute a ON a.attrelid=cl.oid
      WHERE n.nspname='public' AND cl.relkind IN ('r','p')
      GROUP BY cl.oid,cl.relname,cl.relrowsecurity,cl.relforcerowsecurity
      ORDER BY cl.relname`,
  );
  const columns = await tx.$queryRawUnsafe<ColumnRow[]>(
    `SELECT c.table_name,
            c.column_name,
            c.ordinal_position,
            c.data_type,
            c.udt_name,
            pg_catalog.format_type(a.atttypid,a.atttypmod) AS formatted_type,
            c.collation_name,
            c.is_nullable,
            c.column_default,
            c.is_generated,
            c.is_identity
       FROM information_schema.columns c
       JOIN pg_catalog.pg_namespace n ON n.nspname=c.table_schema
       JOIN pg_catalog.pg_class cl ON cl.relnamespace=n.oid AND cl.relname=c.table_name
       JOIN pg_catalog.pg_attribute a ON a.attrelid=cl.oid AND a.attname=c.column_name
      WHERE c.table_schema='public'
        AND cl.relkind IN ('r','p')
        AND a.attnum > 0
        AND NOT a.attisdropped
      ORDER BY c.table_name,c.ordinal_position`,
  );
  const primaryKeys = await tx.$queryRawUnsafe<KeyRow[]>(
    `SELECT rel.relname AS table_name,att.attname AS column_name,key.ordinality AS ordinal_position
       FROM pg_catalog.pg_constraint con
       JOIN pg_catalog.pg_class rel ON rel.oid=con.conrelid
       JOIN pg_catalog.pg_namespace n ON n.oid=rel.relnamespace
       CROSS JOIN LATERAL unnest(con.conkey) WITH ORDINALITY AS key(attnum,ordinality)
       JOIN pg_catalog.pg_attribute att ON att.attrelid=rel.oid AND att.attnum=key.attnum
      WHERE n.nspname='public' AND con.contype='p'
      ORDER BY rel.relname,key.ordinality`,
  );
  const constraintRows = await tx.$queryRawUnsafe<ConstraintRow[]>(
    `SELECT rel.relname AS table_name,
            con.conname AS constraint_name,
            con.contype::text AS constraint_type,
            pg_catalog.pg_get_constraintdef(con.oid,true) AS definition,
            con.condeferrable AS is_deferrable,
            con.condeferred AS initially_deferred,
            refn.nspname AS referenced_schema,
            refrel.relname AS referenced_table
       FROM pg_catalog.pg_constraint con
       JOIN pg_catalog.pg_class rel ON rel.oid=con.conrelid
       JOIN pg_catalog.pg_namespace n ON n.oid=rel.relnamespace
       LEFT JOIN pg_catalog.pg_class refrel ON refrel.oid=con.confrelid
       LEFT JOIN pg_catalog.pg_namespace refn ON refn.oid=refrel.relnamespace
      WHERE n.nspname='public'
      ORDER BY rel.relname,con.conname`,
  );
  const indexRows = await tx.$queryRawUnsafe<IndexRow[]>(
    `SELECT tablename AS table_name,indexname AS index_name,indexdef AS definition
       FROM pg_catalog.pg_indexes
      WHERE schemaname='public'
      ORDER BY tablename,indexname`,
  );
  const policyRows = await tx.$queryRawUnsafe<PolicyRow[]>(
    `SELECT tablename AS table_name,
            policyname AS policy_name,
            cmd AS command,
            permissive,
            roles::text[] AS roles,
            qual AS using_expression,
            with_check AS check_expression
       FROM pg_catalog.pg_policies
      WHERE schemaname='public'
      ORDER BY tablename,policyname`,
  );
  const triggerRows = await tx.$queryRawUnsafe<TriggerRow[]>(
    `SELECT rel.relname AS table_name,
            tr.tgenabled::text AS enabled,
            pg_catalog.pg_get_triggerdef(tr.oid,true) AS definition
       FROM pg_catalog.pg_trigger tr
       JOIN pg_catalog.pg_class rel ON rel.oid=tr.tgrelid
       JOIN pg_catalog.pg_namespace n ON n.oid=rel.relnamespace
      WHERE n.nspname='public' AND NOT tr.tgisinternal
      ORDER BY rel.relname,tr.tgname`,
  );
  const sequenceRows = await tx.$queryRawUnsafe<SequenceRow[]>(
    `SELECT rel.relname AS table_name,
            att.attname AS column_name,
            seqrel.relname AS sequence_name,
            pg_catalog.format_type(seq.seqtypid,NULL) AS data_type,
            seq.seqstart AS start_value,
            seq.seqmin AS minimum_value,
            seq.seqmax AS maximum_value,
            seq.seqincrement AS increment_by,
            seq.seqcycle AS cycle,
            seq.seqcache AS cache_size
       FROM pg_catalog.pg_class seqrel
       JOIN pg_catalog.pg_namespace seqn ON seqn.oid=seqrel.relnamespace
       JOIN pg_catalog.pg_sequence seq ON seq.seqrelid=seqrel.oid
       JOIN pg_catalog.pg_depend dep
         ON dep.classid='pg_catalog.pg_class'::regclass
        AND dep.objid=seqrel.oid
        AND dep.deptype IN ('a','i')
       JOIN pg_catalog.pg_class rel ON rel.oid=dep.refobjid
       JOIN pg_catalog.pg_namespace n ON n.oid=rel.relnamespace
       JOIN pg_catalog.pg_attribute att
         ON att.attrelid=rel.oid AND att.attnum=dep.refobjsubid
      WHERE n.nspname='public' AND seqn.nspname='public'
      ORDER BY rel.relname,att.attnum`,
  );

  const sequenceByColumn = new Map<string, BackupSequenceManifest>();
  for (const sequence of sequenceRows) {
    sequenceByColumn.set(`${sequence.table_name}\0${sequence.column_name}`, {
      name: sequence.sequence_name,
      dataType: sequence.data_type,
      start: String(sequence.start_value),
      minimum: String(sequence.minimum_value),
      maximum: String(sequence.maximum_value),
      increment: String(sequence.increment_by),
      cycle: sequence.cycle,
      cache: String(sequence.cache_size),
    });
  }
  const byTable = new Map<string, BackupColumnManifest[]>();
  for (const column of columns) {
    const list = byTable.get(column.table_name) ?? [];
    list.push({
      name: column.column_name,
      ordinal: Number(column.ordinal_position),
      dataType: column.data_type,
      udtName: column.udt_name,
      formattedType: column.formatted_type,
      collation: column.collation_name,
      nullable: column.is_nullable === 'YES',
      defaultExpression: column.column_default,
      generated: column.is_generated !== 'NEVER',
      identity: column.is_identity === 'YES',
      sequence: sequenceByColumn.get(`${column.table_name}\0${column.column_name}`) ?? null,
    });
    byTable.set(column.table_name, list);
  }
  const pkByTable = new Map<string, string[]>();
  for (const key of primaryKeys) {
    const list = pkByTable.get(key.table_name) ?? [];
    list.push(key.column_name);
    pkByTable.set(key.table_name, list);
  }
  const constraintsByTable = new Map<string, BackupConstraintManifest[]>();
  const dependencyByTable = new Map<string, Set<string>>();
  for (const constraint of constraintRows) {
    const list = constraintsByTable.get(constraint.table_name) ?? [];
    list.push({
      name: constraint.constraint_name,
      type: constraint.constraint_type,
      definition: constraint.definition,
      deferrable: constraint.is_deferrable,
      initiallyDeferred: constraint.initially_deferred,
      referencedSchema: constraint.referenced_schema,
      referencedTable: constraint.referenced_table,
    });
    constraintsByTable.set(constraint.table_name, list);
    if (constraint.constraint_type === 'f' && constraint.referenced_schema === 'public') {
      const set = dependencyByTable.get(constraint.table_name) ?? new Set<string>();
      if (constraint.referenced_table) set.add(constraint.referenced_table);
      dependencyByTable.set(constraint.table_name, set);
    }
  }
  const indexesByTable = new Map<string, BackupIndexManifest[]>();
  for (const index of indexRows) {
    const list = indexesByTable.get(index.table_name) ?? [];
    list.push({ name: index.index_name, definition: index.definition });
    indexesByTable.set(index.table_name, list);
  }
  const policiesByTable = new Map<string, BackupPolicyManifest[]>();
  for (const policy of policyRows) {
    const list = policiesByTable.get(policy.table_name) ?? [];
    list.push({
      name: policy.policy_name,
      command: policy.command,
      permissive: policy.permissive,
      roles: [...policy.roles].sort(),
      usingExpression: policy.using_expression,
      checkExpression: policy.check_expression,
    });
    policiesByTable.set(policy.table_name, list);
  }
  const triggersByTable = new Map<string, BackupTriggerManifest[]>();
  for (const trigger of triggerRows) {
    const list = triggersByTable.get(trigger.table_name) ?? [];
    list.push({ enabled: trigger.enabled, definition: trigger.definition });
    triggersByTable.set(trigger.table_name, list);
  }

  if (!tableRows.length)
    throw new CompanyBackupValidationError('database schema has no public tables');
  const tables = tableRows.map((table): BackupTableManifest => {
    const tableColumns = byTable.get(table.table_name) ?? [];
    if (tableColumns.length !== Number(table.column_count))
      throw new CompanyBackupValidationError(
        `catalog visibility mismatch for ${table.table_name}: expected ${Number(table.column_count)} columns, found ${tableColumns.length}`,
      );
    const scope = tableScope(table.table_name, tableColumns);
    return {
      name: table.table_name,
      ...scope,
      primaryKey: pkByTable.get(table.table_name) ?? [],
      dependencies: [...(dependencyByTable.get(table.table_name) ?? [])].sort(),
      rlsEnabled: table.rls_enabled,
      rlsForced: table.rls_forced,
      constraints: constraintsByTable.get(table.table_name) ?? [],
      indexes: indexesByTable.get(table.table_name) ?? [],
      policies: policiesByTable.get(table.table_name) ?? [],
      triggers: triggersByTable.get(table.table_name) ?? [],
      columns: tableColumns,
    };
  });
  return { kind: BACKUP_SCHEMA_KIND, fingerprint: schemaFingerprint(tables), tables };
}

const isDateType = (dataType: string): boolean =>
  dataType === 'date' || dataType === 'time' || dataType.startsWith('timestamp');

const isFloatType = (dataType: string): boolean =>
  dataType === 'double precision' || dataType === 'real';

export function encodeBackupCell(value: unknown, column: BackupColumnManifest): EncodedCell {
  if (value === null || value === undefined) return null;
  if (column.dataType === 'bytea') {
    if (typeof value === 'string') {
      if (!validBase64(value))
        throw new CompanyBackupValidationError(`${column.name} has invalid database bytea text`);
      return { $dcType: 'bytea', value };
    }
    if (!Buffer.isBuffer(value) && !(value instanceof Uint8Array))
      throw new CompanyBackupValidationError(`${column.name} is bytea but did not return bytes`);
    return { $dcType: 'bytea', value: Buffer.from(value).toString('base64') };
  }
  if (column.dataType === 'bigint') return { $dcType: 'bigint', value: String(value) };
  if (column.dataType === 'numeric' || column.dataType === 'decimal' || column.dataType === 'money')
    return { $dcType: 'decimal', value: String(value) };
  if (isFloatType(column.dataType)) return { $dcType: 'float', value: String(value) };
  if (isDateType(column.dataType)) {
    if (typeof value !== 'string')
      throw new CompanyBackupValidationError(
        `${column.name} must be read as PostgreSQL date/time text`,
      );
    return { $dcType: 'date-time', value };
  }
  if (column.dataType === 'json' || column.dataType === 'jsonb') {
    if (typeof value !== 'string')
      throw new CompanyBackupValidationError(`${column.name} must be read as PostgreSQL json text`);
    try {
      JSON.parse(value);
    } catch {
      throw new CompanyBackupValidationError(
        `${column.name} contains invalid PostgreSQL json text`,
      );
    }
    return { $dcType: 'json', value };
  }
  if (typeof value === 'bigint') return { $dcType: 'bigint', value: value.toString() };
  if (Buffer.isBuffer(value)) return { $dcType: 'bytea', value: value.toString('base64') };
  if (typeof value === 'string' || typeof value === 'boolean') return value;
  if (typeof value === 'number') {
    if (!Number.isFinite(value))
      throw new CompanyBackupValidationError(`${column.name} contains a non-finite number`);
    return value;
  }
  throw new CompanyBackupValidationError(
    `${column.name} (${column.dataType}) returned unsupported ${typeof value}`,
  );
}

export function encodeBackupRow(
  row: Record<string, unknown>,
  table: BackupTableManifest,
): EncodedBackupRow {
  return Object.fromEntries(
    table.columns.map((column) => [column.name, encodeBackupCell(row[column.name], column)]),
  );
}

const tagged = (
  value: EncodedCell,
): value is Exclude<EncodedCell, null | string | number | boolean> =>
  typeof value === 'object' && value !== null && '$dcType' in value;

const validBase64 = (value: string): boolean => {
  if (value.length % 4 !== 0 || !/^[A-Za-z0-9+/]*={0,2}$/.test(value)) return false;
  return Buffer.from(value, 'base64').toString('base64') === value;
};

export function decodeBackupCell(value: EncodedCell, column: BackupColumnManifest): unknown {
  if (value === null) {
    if (!column.nullable && !column.generated)
      throw new CompanyBackupValidationError(`${column.name} cannot be null`);
    return null;
  }
  if (column.dataType === 'bytea') {
    if (!tagged(value) || value.$dcType !== 'bytea' || !validBase64(value.value))
      throw new CompanyBackupValidationError(`${column.name} has invalid bytea encoding`);
    return Buffer.from(value.value, 'base64');
  }
  if (column.dataType === 'bigint') {
    if (!tagged(value) || value.$dcType !== 'bigint' || !/^-?\d+$/.test(value.value))
      throw new CompanyBackupValidationError(`${column.name} has invalid bigint encoding`);
    return BigInt(value.value);
  }
  if (
    column.dataType === 'numeric' ||
    column.dataType === 'decimal' ||
    column.dataType === 'money'
  ) {
    if (
      !tagged(value) ||
      value.$dcType !== 'decimal' ||
      !/^(?:NaN|-?Infinity|-?(?:\d+(?:\.\d*)?|\.\d+)(?:e[+-]?\d+)?)$/i.test(value.value)
    )
      throw new CompanyBackupValidationError(`${column.name} has invalid decimal encoding`);
    return value.value;
  }
  if (isFloatType(column.dataType)) {
    if (
      !tagged(value) ||
      value.$dcType !== 'float' ||
      !/^(?:NaN|-?Infinity|-?(?:\d+(?:\.\d*)?|\.\d+)(?:e[+-]?\d+)?)$/i.test(value.value)
    )
      throw new CompanyBackupValidationError(`${column.name} has invalid float encoding`);
    return value.value;
  }
  if (isDateType(column.dataType)) {
    if (!tagged(value) || value.$dcType !== 'date-time' || !value.value)
      throw new CompanyBackupValidationError(`${column.name} has invalid date/time encoding`);
    return value.value;
  }
  if (column.dataType === 'json' || column.dataType === 'jsonb') {
    if (!tagged(value) || value.$dcType !== 'json' || typeof value.value !== 'string')
      throw new CompanyBackupValidationError(`${column.name} has invalid json encoding`);
    try {
      JSON.parse(value.value);
    } catch {
      throw new CompanyBackupValidationError(`${column.name} contains invalid json text`);
    }
    return value.value;
  }
  if (tagged(value))
    throw new CompanyBackupValidationError(
      `${column.name} has ${value.$dcType} encoding for ${column.dataType}`,
    );
  if (typeof value === 'string') {
    const width = /^character(?: varying)?\((\d+)\)$/.exec(column.formattedType)?.[1];
    if (width && Array.from(value).length > Number(width))
      throw new CompanyBackupValidationError(
        `${column.name} exceeds ${column.formattedType} width`,
      );
    return value;
  }
  if (typeof value === 'boolean') return value;
  if (typeof value === 'number' && Number.isFinite(value)) {
    if (column.dataType === 'integer' && !Number.isInteger(value))
      throw new CompanyBackupValidationError(`${column.name} has invalid integer value`);
    return value;
  }
  throw new CompanyBackupValidationError(`${column.name} has invalid ${column.dataType} value`);
}

export function assertEncodedRow(
  row: EncodedBackupRow,
  table: BackupTableManifest,
  expected: { tenantId: string; companyCode: string },
): void {
  if (!row || typeof row !== 'object' || Array.isArray(row))
    throw new CompanyBackupValidationError(`${table.name} contains a non-object row`);
  const expectedColumns = table.columns.map((column) => column.name).sort();
  const actualColumns = Object.keys(row).sort();
  if (stableStringify(actualColumns) !== stableStringify(expectedColumns))
    throw new CompanyBackupValidationError(`${table.name} row columns do not match the manifest`);
  if (row.tenant_id !== expected.tenantId)
    throw new CompanyBackupValidationError(`${table.name} row tenant does not match the document`);
  if (row.CO_CODE !== expected.companyCode)
    throw new CompanyBackupValidationError(`${table.name} row company does not match the document`);
  for (const column of table.columns) decodeBackupCell(row[column.name] ?? null, column);
}

const tableNames = (document: CompanyBackupDocument): string[] =>
  document.manifest.tables.filter((table) => table.included).map((table) => table.name);

export function resealCompanyBackupDocument(
  document: CompanyBackupDocument,
): CompanyBackupDocument {
  const tables: Record<string, BackupTableData> = {};
  for (const name of tableNames(document).sort()) {
    const rows = document.tables[name]?.rows ?? [];
    tables[name] = { rows, rowCount: rows.length, checksum: checksumBackupRows(rows) };
  }
  const totals = {
    schemaTables: document.manifest.tables.length,
    companyTables: tableNames(document).length,
    excludedTables: document.manifest.tables.filter((table) => !table.included).length,
    rows: Object.values(tables).reduce((sum, table) => sum + table.rowCount, 0),
  };
  const unsigned: CompanyBackupDocument = { ...document, tables, totals, checksum: '' };
  return { ...unsigned, checksum: documentChecksum(unsigned) };
}

const isRecord = (value: unknown): value is Record<string, unknown> =>
  typeof value === 'object' && value !== null && !Array.isArray(value);
const isStringArray = (value: unknown): value is string[] =>
  Array.isArray(value) && value.every((entry) => typeof entry === 'string');
const isNullableString = (value: unknown): value is string | null =>
  value === null || typeof value === 'string';

const assertManifestShape = (manifest: BackupSchemaManifest): void => {
  for (const rawTable of manifest.tables as unknown[]) {
    if (!isRecord(rawTable))
      throw new CompanyBackupValidationError('backup manifest contains a non-object table');
    if (
      typeof rawTable.name !== 'string' ||
      !rawTable.name ||
      !['company', 'tenant-shared', 'system'].includes(String(rawTable.scope)) ||
      typeof rawTable.included !== 'boolean' ||
      !isNullableString(rawTable.exclusionReason) ||
      !isStringArray(rawTable.primaryKey) ||
      !isStringArray(rawTable.dependencies) ||
      typeof rawTable.rlsEnabled !== 'boolean' ||
      typeof rawTable.rlsForced !== 'boolean' ||
      !Array.isArray(rawTable.columns) ||
      !Array.isArray(rawTable.constraints) ||
      !Array.isArray(rawTable.indexes) ||
      !Array.isArray(rawTable.policies) ||
      !Array.isArray(rawTable.triggers)
    )
      throw new CompanyBackupValidationError(`${String(rawTable.name)} manifest shape is invalid`);

    for (const rawColumn of rawTable.columns) {
      if (
        !isRecord(rawColumn) ||
        typeof rawColumn.name !== 'string' ||
        !rawColumn.name ||
        typeof rawColumn.ordinal !== 'number' ||
        !Number.isInteger(rawColumn.ordinal) ||
        typeof rawColumn.dataType !== 'string' ||
        typeof rawColumn.udtName !== 'string' ||
        typeof rawColumn.formattedType !== 'string' ||
        !isNullableString(rawColumn.collation) ||
        typeof rawColumn.nullable !== 'boolean' ||
        !isNullableString(rawColumn.defaultExpression) ||
        typeof rawColumn.generated !== 'boolean' ||
        typeof rawColumn.identity !== 'boolean' ||
        !(
          rawColumn.sequence === null ||
          (isRecord(rawColumn.sequence) &&
            typeof rawColumn.sequence.name === 'string' &&
            typeof rawColumn.sequence.dataType === 'string' &&
            typeof rawColumn.sequence.start === 'string' &&
            typeof rawColumn.sequence.minimum === 'string' &&
            typeof rawColumn.sequence.maximum === 'string' &&
            typeof rawColumn.sequence.increment === 'string' &&
            typeof rawColumn.sequence.cycle === 'boolean' &&
            typeof rawColumn.sequence.cache === 'string')
        )
      )
        throw new CompanyBackupValidationError(
          `${String(rawTable.name)} contains invalid column metadata`,
        );
    }
    for (const constraint of rawTable.constraints) {
      if (
        !isRecord(constraint) ||
        typeof constraint.name !== 'string' ||
        typeof constraint.type !== 'string' ||
        typeof constraint.definition !== 'string' ||
        typeof constraint.deferrable !== 'boolean' ||
        typeof constraint.initiallyDeferred !== 'boolean' ||
        !isNullableString(constraint.referencedSchema) ||
        !isNullableString(constraint.referencedTable)
      )
        throw new CompanyBackupValidationError(
          `${String(rawTable.name)} contains invalid constraint metadata`,
        );
    }
    for (const index of rawTable.indexes) {
      if (
        !isRecord(index) ||
        typeof index.name !== 'string' ||
        typeof index.definition !== 'string'
      )
        throw new CompanyBackupValidationError(
          `${String(rawTable.name)} contains invalid index metadata`,
        );
    }
    for (const policy of rawTable.policies) {
      if (
        !isRecord(policy) ||
        typeof policy.name !== 'string' ||
        typeof policy.command !== 'string' ||
        typeof policy.permissive !== 'string' ||
        !isStringArray(policy.roles) ||
        !isNullableString(policy.usingExpression) ||
        !isNullableString(policy.checkExpression)
      )
        throw new CompanyBackupValidationError(
          `${String(rawTable.name)} contains invalid policy metadata`,
        );
    }
    for (const trigger of rawTable.triggers) {
      if (
        !isRecord(trigger) ||
        typeof trigger.enabled !== 'string' ||
        typeof trigger.definition !== 'string'
      )
        throw new CompanyBackupValidationError(
          `${String(rawTable.name)} contains invalid trigger metadata`,
        );
    }
  }
};

export function assertCompanyBackupIntegrity(document: CompanyBackupDocument): void {
  if (!document || typeof document !== 'object' || Array.isArray(document))
    throw new CompanyBackupValidationError('company backup document must be an object');
  if (
    typeof document.tenant !== 'string' ||
    !document.tenant ||
    typeof document.company !== 'string' ||
    !document.company ||
    typeof document.generatedAt !== 'string' ||
    !Number.isFinite(Date.parse(document.generatedAt)) ||
    typeof document.databaseTarget !== 'string' ||
    typeof document.checksum !== 'string' ||
    !isRecord(document.totals) ||
    !['schemaTables', 'companyTables', 'excludedTables', 'rows'].every(
      (key) => typeof (document.totals as unknown as Record<string, unknown>)[key] === 'number',
    ) ||
    typeof document.source !== 'object' ||
    document.source === null ||
    typeof document.source.tenantId !== 'string' ||
    !document.source.tenantId ||
    typeof document.source.companyCode !== 'string' ||
    !document.source.companyCode ||
    typeof document.tables !== 'object' ||
    document.tables === null ||
    Array.isArray(document.tables) ||
    !document.manifest ||
    typeof document.manifest !== 'object' ||
    !Array.isArray(document.manifest.tables)
  )
    throw new CompanyBackupValidationError('company backup document shape is invalid');
  if (document.kind !== COMPANY_BACKUP_KIND || document.version !== COMPANY_BACKUP_VERSION)
    throw new CompanyBackupValidationError('unsupported company backup kind or version');
  if (document.manifest?.kind !== BACKUP_SCHEMA_KIND)
    throw new CompanyBackupValidationError('invalid backup schema manifest');
  assertManifestShape(document.manifest);
  const manifestNames = document.manifest.tables.map((table) => table?.name);
  if (
    manifestNames.some((name) => typeof name !== 'string' || !name) ||
    new Set(manifestNames).size !== manifestNames.length
  )
    throw new CompanyBackupValidationError('backup manifest table names are invalid or duplicated');
  for (const table of document.manifest.tables) {
    if (!Array.isArray(table.columns) || !Array.isArray(table.primaryKey))
      throw new CompanyBackupValidationError(`${table.name} manifest shape is invalid`);
    const columns = new Set(table.columns.map((column) => column.name));
    if (
      table.included !== (table.scope === 'company') ||
      (table.included && (!columns.has('tenant_id') || !columns.has('CO_CODE')))
    )
      throw new CompanyBackupValidationError(`${table.name} manifest scope is invalid`);
  }
  const expectedFingerprint = schemaFingerprint(document.manifest.tables);
  if (document.manifest.fingerprint !== expectedFingerprint)
    throw new CompanyBackupValidationError('backup schema fingerprint is invalid');
  if (
    document.tenant !== document.source?.tenantId ||
    document.company !== document.source?.companyCode
  )
    throw new CompanyBackupValidationError('backup source aliases do not match');

  const included = tableNames(document).sort();
  const actual = Object.keys(document.tables ?? {}).sort();
  if (stableStringify(actual) !== stableStringify(included))
    throw new CompanyBackupValidationError('backup table data set does not match the manifest');
  for (const table of document.manifest.tables.filter((entry) => entry.included)) {
    const data = document.tables[table.name];
    if (!data || !Array.isArray(data.rows))
      throw new CompanyBackupValidationError(`backup table ${table.name} has no rows array`);
    if (data.rowCount !== data.rows.length)
      throw new CompanyBackupValidationError(`backup table ${table.name} row count is invalid`);
    if (data.checksum !== checksumBackupRows(data.rows))
      throw new CompanyBackupValidationError(`backup table ${table.name} checksum is invalid`);
    for (const row of data.rows)
      assertEncodedRow(row, table, {
        tenantId: document.source.tenantId,
        companyCode: document.source.companyCode,
      });
  }
  const sealed = resealCompanyBackupDocument(document);
  if (stableStringify(document.totals) !== stableStringify(sealed.totals))
    throw new CompanyBackupValidationError('backup totals are invalid');
  if (document.checksum !== documentChecksum(document))
    throw new CompanyBackupValidationError('backup document checksum is invalid');
}

export function orderedCompanyTables(manifest: BackupSchemaManifest): BackupTableManifest[] {
  const included = manifest.tables.filter((table) => table.included);
  const byName = new Map(included.map((table) => [table.name, table]));
  const remaining = new Set(byName.keys());
  const ordered: BackupTableManifest[] = [];
  while (remaining.size) {
    const ready = [...remaining]
      .filter((name) =>
        (byName.get(name)?.dependencies ?? []).every(
          (dependency) => !byName.has(dependency) || !remaining.has(dependency),
        ),
      )
      .sort();
    if (!ready.length)
      throw new CompanyBackupValidationError('company table foreign-key dependency cycle detected');
    for (const name of ready) {
      ordered.push(byName.get(name)!);
      remaining.delete(name);
    }
  }
  return ordered;
}
