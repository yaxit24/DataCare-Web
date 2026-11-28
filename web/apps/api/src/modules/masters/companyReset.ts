import { createHash, randomUUID } from 'node:crypto';
import { withTxBudget } from '../shared/txBudget.js';
import {
  loadBackupSchemaManifest,
  orderedCompanyTables,
  type BackupTableManifest,
} from '../ops/backupManifest.js';
import { provisionCompanyTx } from '../ops/seedCompany.js';
import { companyWriteLockKey } from '../shared/companyWriteScope.js';
import {
  REPAIR_REASON_MIN_LENGTH,
  RepairError,
  requireReason,
  requireReauthentication,
} from '../utilities/dataRepair.js';

/**
 * Company → Company, Ctrl+R "Reset Compnay" (MS_COMPANY.cs:6477-6480, the box at :5318).
 *
 * Desktop: the box is visible only where `MsMasterResetAllData='Y'` (six registration serials). Ticked and saved it
 * stores `CO_MAST.RTGS_TYPE='Y'` (:6116, :6162). After the next login `MS_OPNCOMP.cs:1513,2010-2013` runs
 * `Module_Schm.CompnyRest` (Module_Schm.cs:873-1060, the same statements as :60-230): it deletes the company's
 * vouchers, stock and masters table by table (:83-222) but keeps the default rows (account codes up to 99 :90,
 * balance groups up to 7 :100, location 00 :84,160, login and user set ABC :85-86,162, employee 001 :136, table 001
 * :207, the current year :222), clears LOCT_MAST.TRY_DATE (:161) and puts AC_GROUP, BOOK_DETL, CO_SET and CONV_MAST
 * back to defaults (:89,109,116,118).
 *
 * Web (owner decisions 2026-11-28, docs/handbook/web/desktop-adaptations.md "Company reset"): CLEAR THE DATA, KEEP
 * THE COMPANY, at once and in ONE transaction.
 *  * Kept as they are (`KEPT_TABLES`): identity and settings, books, users and rights, locations (TRY_DATE cleared as
 *    :161 does, for this company only). Kept in part: the one year that stays (the caller's session year, else the
 *    company's latest); the accounts the desktop keeps (numeric code up to 99, :90) plus every account a kept book,
 *    location names (`accountKept`), so no kept book posts to a missing account (the desktop instead moves
 *    some book legs to 00075, :109); the account groups those accounts sit in; employee 001 (:136) and every
 *    employee a kept book names (BOOK_DATA.USER_EMP_CODE).
 *  * Every other company-scoped row (tenant_id + CO_CODE, the company backup's scope) is deleted, and
 *    `provisionCompanyTx(templatesOnly)` puts back the default masters a new company gets; it inserts only absent rows
 *    and never creates identity, settings, books, a location or a year.
 *  * Every deleted row is copied, in the statement that deletes it, into the tenant-level `company_reset_archive`
 *    (the web has no operator backup), tied to the run's `data_repair_run` row (who, when, why, counts).
 *  * Writers are held off: the company's write key is taken EXCLUSIVE (every write transaction of a request in the
 *    company takes it SHARED, companyWriteScope.ts) before anything is read for the delete,
 *    the apply is refused unless the data still matches the preview the admin confirmed (`fingerprint`), and the
 *    rows left after the deletes and the seed are checked before commit.
 *  * The desktop's unscoped statements (Module_Schm.cs:110,161,188,208,210,215-216) are not ported.
 *  * Guarded like a Data Repair danger operation: admin only (route policy), typed code and name, password re-entry,
 *    a written reason; one reset per company at a time. Every other session on the company is ended.
 */
export const COMPANY_RESET_OPERATION = 'company-reset';

export class CompanyResetError extends Error {
  constructor(
    readonly code: string,
    message: string,
    readonly statusCode = 400,
  ) {
    super(message);
    this.name = 'CompanyResetError';
  }
}

/** Identity, settings, books, users and rights, and locations: never deleted by a reset. */
export const KEPT_TABLES: ReadonlySet<string> = new Set([
  'CO_MAST',
  'CO_SET',
  'CO_SET_NEW',
  'PRINT_MAST',
  'E_MAST',
  'BOOK_DATA',
  'BOOK_DETL',
  'LOGIN_MAST',
  'USER_SET',
  'LOCT_MAST',
]);
/** Kept tables whose rows name accounts: their accounts stay. (CO_SET.CASH_PURC_AC is a Y/N flag, not an account.) */
const ACCOUNT_REFERENCES: readonly [table: string, column: string][] = [
  ['BOOK_DETL', 'AC_CODE'],
  ['LOCT_MAST', 'AC_CODE'],
];
/** Kept books name their user's employee: that employee stays. */
const EMPLOYEE_REFERENCES: readonly [table: string, column: string][] = [
  ['BOOK_DATA', 'USER_EMP_CODE'],
];
/** Every kept column that decides which rows of a cleared table stay (fingerprinted). */
const KEEP_REFERENCES = [...ACCOUNT_REFERENCES, ...EMPLOYEE_REFERENCES];
const referenced = (refs: readonly (readonly [string, string])[]) =>
  refs
    .map(
      ([table, column]) =>
        `SELECT r.${quote(column)}::text FROM ${quote(table)} r WHERE r.tenant_id=$1 AND r."CO_CODE"::text=$2 AND r.${quote(column)} IS NOT NULL`,
    )
    .join(' UNION ');

export type CompanyResetKind = 'vouchers' | 'masters' | 'years';
const MASTERS = new Set(['AC_GROUP', 'BAL_GR', 'DM_SIZE', 'ITM_CITY', 'USER_DATA', 'USER_REQUEST']);
/** Plain grouping of the deleted rows for the screen. */
export function companyResetKind(table: string): CompanyResetKind {
  if (table === 'YEAR_MAST') return 'years';
  if (MASTERS.has(table) || /_MAST$|_MAST_SRNO$|_IMAGE$|_SET$/.test(table)) return 'masters';
  return 'vouchers';
}

export interface CompanyResetScope {
  tenantId: string;
  sessionId: string;
  sessionCoCode: string;
  sessionCoYear?: string;
  loginCoCode: string;
  operator: string;
}

type TableCount = { table: string; rows: number };
export interface CompanyResetPlan {
  coCode: string;
  coName: string;
  /** The year that stays. */
  keptYear: string | null;
  kept: TableCount[];
  deleted: (TableCount & { kind: CompanyResetKind })[];
  kinds: Record<CompanyResetKind, number>;
  keptTotal: number;
  deletedTotal: number;
  reasonMinLength: number;
  /** Binds an apply to what this preview counted: the rows it clears and the account codes that decide what stays. */
  fingerprint: string;
}
export interface CompanyResetInput {
  coCode?: string;
  coName?: string;
  password?: string;
  reason?: string;
  fingerprint?: string;
}
export interface CompanyResetResult extends CompanyResetPlan {
  runId: string;
  archived: number;
  /** Default master rows put back by seedCompany. */
  restoredDefaults: number;
  revokedSessions: number;
  /** True when the caller reset the company they are working in: the client reloads its context. */
  ownCompany: boolean;
}

const quote = (name: string) => `"${name.replace(/"/g, '""')}"`;
/** Every statement binds $1 tenant, $2 company, $3 the kept year (null when the company has none). */
const scoped = `tenant_id=$1 AND "CO_CODE"::text=$2`;

/** The accounts a reset keeps: numeric code up to 99 (Module_Schm.cs:90) or named by a kept book or location. */
const accountKept = (alias: string) =>
  `((${alias}"AC_CODE" ~ '^[0-9]+$' AND ${alias}"AC_CODE"::numeric <= 99) OR ${alias}"AC_CODE"::text IN (${referenced(ACCOUNT_REFERENCES)}))`;

/**
 * SQL true for a row the reset deletes, or null for a table it keeps whole. A row whose keep test is unknown (a NULL
 * account code) is deleted, so every row is counted as either kept or deleted.
 */
function removes(table: string): string | null {
  const rule = removeRule(table);
  return rule === null ? null : `coalesce((${rule}), true)`;
}
function removeRule(table: string): string | null {
  if (KEPT_TABLES.has(table)) return null;
  if (table === 'YEAR_MAST') return `"CO_YEAR" IS DISTINCT FROM $3::text`;
  if (table === 'AC_MAST') return `NOT ${accountKept('')}`;
  // Employee 001 stays as on the desktop (Module_Schm.cs:136), and so does every employee a kept book names.
  if (table === 'EMP_MAST')
    return `NOT ("EMP_CODE"='001' OR "EMP_CODE"::text IN (${referenced(EMPLOYEE_REFERENCES)}))`;
  if (table === 'AC_GROUP')
    return `"AC_GR" IS NULL OR "AC_GR" NOT IN (SELECT a."AC_GR" FROM "AC_MAST" a WHERE a.tenant_id=$1 AND a."CO_CODE"::text=$2 AND a."AC_GR" IS NOT NULL AND ${accountKept('a.')})`;
  return 'true';
}

async function companyRow(tx: any, tenantId: string, coCode: string, lock = false) {
  const [row] = await tx.$queryRawUnsafe(
    `SELECT "CO_CODE","CO_NAME","LC_CODE" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND deleted_at IS NULL${lock ? ' FOR UPDATE' : ''}`,
    tenantId,
    coCode,
  );
  if (!row) throw new CompanyResetError('company-unavailable', 'Company is unavailable', 404);
  return {
    coCode: String(row.CO_CODE),
    coName: String(row.CO_NAME ?? ''),
    lcCode: row.LC_CODE ? String(row.LC_CODE) : null,
  };
}

/** The caller's session year when the company has it, else the company's latest year. */
async function keptYear(tx: any, scope: CompanyResetScope, coCode: string) {
  const rows: { y: string }[] = await tx.$queryRawUnsafe(
    `SELECT DISTINCT "CO_YEAR" y FROM "YEAR_MAST" WHERE ${scoped} AND "CO_YEAR" IS NOT NULL ORDER BY 1 DESC`,
    scope.tenantId,
    coCode,
  );
  const years = rows.map((row) => String(row.y));
  return years.find((year) => year === scope.sessionCoYear) ?? years[0] ?? null;
}

/** The company-scoped tables, children first so a delete never trips a foreign key. */
async function companyTables(tx: any): Promise<string[]> {
  return orderedCompanyTables(await loadBackupSchemaManifest(tx))
    .map((table) => table.name)
    .reverse();
}

/**
 * Rows per table the reset deletes (d) and keeps (k), and a content hash (x) for the fingerprint: every column of the
 * rows of a table the reset clears, only the account codes of a table whose rows decide which accounts stay, and
 * nothing of the other kept tables, so a login (LOGIN_MAST counters) or a settings change does not make a preview
 * stale. A sum of row hashes ignores row order and does not depend on transaction ids.
 */
async function census(
  tx: any,
  tenantId: string,
  coCode: string,
  year: string | null,
  tables: BackupTableManifest[],
) {
  const rows: { t: string; d: number; k: number; x: string | null }[] = await tx.$queryRawUnsafe(
    tables
      .map((manifest, i) => {
        const table = manifest.name;
        // Hash binary content before row text conversion; never expand image bytes into hex.
        const rowText = manifest.columns.some((column) => column.dataType === 'bytea')
          ? `ROW(${manifest.columns
              .map((column) =>
                column.dataType === 'bytea'
                  ? `md5(z.${quote(column.name)})`
                  : `z.${quote(column.name)}`,
              )
              .join(',')})::text`
          : 'z::text';
        const remove = removes(table) ?? 'false';
        const reference = KEEP_REFERENCES.find(([name]) => name === table);
        const hashed = removes(table)
          ? rowText
          : reference
            ? `coalesce(${quote(reference[1])}::text, '')`
            : null;
        const x = hashed ? `coalesce(sum(hashtextextended(${hashed}, 0)), 0)::text` : `''`;
        return `SELECT $${i + 4}::text t, count(*) FILTER (WHERE ${remove})::int d,
                       count(*) FILTER (WHERE NOT (${remove}))::int k, ${x} x
                  FROM ${quote(table)} z WHERE ${scoped}`;
      })
      .join(' UNION ALL '),
    tenantId,
    coCode,
    year,
    ...tables.map((table) => table.name),
  );
  return rows.map((row) => ({ t: row.t, d: Number(row.d), k: Number(row.k), x: row.x ?? '' }));
}

async function plan(tx: any, scope: CompanyResetScope, coCode: string) {
  const company = await companyRow(tx, scope.tenantId, coCode);
  const year = await keptYear(tx, scope, coCode);
  const manifests = orderedCompanyTables(await loadBackupSchemaManifest(tx)).reverse();
  const tables = manifests.map((table) => table.name);
  const counted = await census(tx, scope.tenantId, coCode, year, manifests);
  const kept = counted
    .filter((row) => row.k > 0)
    .map((row) => ({ table: row.t, rows: row.k }))
    .sort((a, b) => a.table.localeCompare(b.table));
  const deleted = counted
    .filter((row) => row.d > 0)
    .map((row) => ({ table: row.t, rows: row.d, kind: companyResetKind(row.t) }))
    .sort((a, b) => a.table.localeCompare(b.table));
  const kinds: Record<CompanyResetKind, number> = { vouchers: 0, masters: 0, years: 0 };
  for (const entry of deleted) kinds[entry.kind] += entry.rows;
  const fingerprint = createHash('sha256')
    .update(
      JSON.stringify({
        co: [company.coCode, company.coName, year],
        // Kept tables' counts are left out too: a new login or user must not make the preview stale.
        rows: [...counted]
          .sort((a, b) => a.t.localeCompare(b.t))
          .map((r) =>
            removes(r.t) || KEEP_REFERENCES.some(([n]) => n === r.t) ? [r.t, r.d, r.k, r.x] : [r.t],
          ),
      }),
    )
    .digest('hex');
  const summary: CompanyResetPlan = {
    coCode: company.coCode,
    coName: company.coName,
    keptYear: year,
    kept,
    deleted,
    kinds,
    keptTotal: kept.reduce((sum, entry) => sum + entry.rows, 0),
    deletedTotal: deleted.reduce((sum, entry) => sum + entry.rows, 0),
    reasonMinLength: REPAIR_REASON_MIN_LENGTH,
    fingerprint,
  };
  return { company, year, tables, summary };
}

/** What a reset of `coCode` keeps and deletes; reads only. */
export function previewCompanyReset(
  prisma: any,
  scope: CompanyResetScope,
  coCode: string,
): Promise<CompanyResetPlan> {
  return withTxBudget(
    prisma,
    scope.tenantId,
    'maintenance',
    async (tx: any) => (await plan(tx, scope, coCode)).summary,
  );
}

const RESET_TEXT: Record<string, string> = {
  'reason-required': `Write why this company is being reset (at least ${REPAIR_REASON_MIN_LENGTH} characters).`,
  'reauthentication-required': 'Enter your password.',
  'reauthentication-failed': 'The password is not correct.',
};
const asResetError = (error: unknown): never => {
  if (error instanceof RepairError) {
    const status = error.code.startsWith('reauthentication') ? 403 : 400;
    throw new CompanyResetError(error.code, RESET_TEXT[error.code] ?? error.message, status);
  }
  throw error;
};

/** The company's location for the default masters: its own default if it exists, else its first. Never a new one. */
async function seedLocation(tx: any, tenantId: string, coCode: string, preferred: string | null) {
  const [row] = await tx.$queryRawUnsafe(
    `SELECT "LC_CODE" lc FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE" IS NOT NULL
      ORDER BY ("LC_CODE"=$3) DESC, "LC_CODE" LIMIT 1`,
    tenantId,
    coCode,
    preferred ?? '',
  );
  return row ? String(row.lc) : (preferred ?? '01');
}

const tableCounts = async (tx: any, tenantId: string, coCode: string, tables: string[]) =>
  new Map(
    (
      (await tx.$queryRawUnsafe(
        tables
          .map(
            (table, i) =>
              `SELECT $${i + 3}::text t, count(*)::int n FROM ${quote(table)} WHERE ${scoped}`,
          )
          .join(' UNION ALL '),
        tenantId,
        coCode,
        ...tables,
      )) as { t: string; n: number }[]
    ).map((row) => [row.t, Number(row.n)]),
  );

/** Clear the company's data, archive every deleted row, put the default masters back, and record the run. */
export async function resetCompany(
  prisma: any,
  scope: CompanyResetScope,
  coCode: string,
  input: CompanyResetInput,
): Promise<CompanyResetResult> {
  let reason = '';
  try {
    reason = requireReason(input.reason);
  } catch (error) {
    asResetError(error);
  }
  // Its own budget class: one transaction for the whole company, never a half reset (txBudget.ts maintenance).
  return withTxBudget(prisma, scope.tenantId, 'maintenance', async (tx: any) => {
    const company = await companyRow(tx, scope.tenantId, coCode);
    if (input.coCode !== company.coCode || input.coName !== company.coName)
      throw new CompanyResetError(
        'confirmation-mismatch',
        'Type the company code and the company name exactly as shown.',
      );
    // Authority before the lock, as applyRepair does: an unauthorised caller must not hold it.
    try {
      await requireReauthentication(
        tx,
        { tenantId: scope.tenantId, coCode: scope.loginCoCode },
        {
          previewHash: '',
          operator: scope.operator,
          loginCoCode: scope.loginCoCode,
          operatorPassword: input.password,
        },
      );
    } catch (error) {
      asResetError(error);
    }
    const reauthenticatedAt = new Date();

    // One reset of a company at a time: a second request is refused rather than queued behind the first.
    const [{ locked }] = await tx.$queryRawUnsafe(
      'SELECT pg_try_advisory_xact_lock(hashtext($1)) AS locked',
      `company-reset:${scope.tenantId}:${coCode}`,
    );
    if (!locked)
      throw new CompanyResetError(
        'reset-in-progress',
        'This company is already being reset. Wait for it to finish.',
        409,
      );
    // Hold off this company's writers, and only them: every write transaction of a request in this company takes
    // the company's write key SHARED (withTxBudget, companyWriteScope.ts); the reset takes it EXCLUSIVE. In-flight
    // writes may finish (10 s, then a retryable 503); new ones are refused until the reset commits. Other companies
    // and tenants never touch this key. Taken before the company-identity lock, in the same order a writer takes
    // them, so the two cannot deadlock.
    await tx.$executeRawUnsafe(`SELECT set_config('lock_timeout', '10s', true)`);
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtextextended($1, 0))',
      companyWriteLockKey(scope.tenantId, coCode),
    );
    await tx.$executeRawUnsafe(`SELECT set_config('lock_timeout', '0', true)`);
    // The lock Company create, edit, delete and the purge worker take (companyIdentity.ts, companyPurge.ts).
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `company-identity:${scope.tenantId}`,
    );
    await companyRow(tx, scope.tenantId, coCode, true);
    const tables = await companyTables(tx);

    const { year, summary } = await plan(tx, scope, coCode);
    if (!input.fingerprint || input.fingerprint !== summary.fingerprint)
      throw new CompanyResetError(
        'stale-preview',
        'The data of this company changed since you previewed it. Preview again.',
        409,
      );

    // The run row is written last with the final counts (it is immutable once applied); the archive's foreign key
    // to it is deferred to commit.
    const [{ id: runId }] = await tx.$queryRawUnsafe(
      `SELECT nextval(pg_get_serial_sequence('"data_repair_run"','row_id'))::text AS id`,
    );
    const deleted: TableCount[] = [];
    let archived = 0;
    for (const table of tables) {
      const remove = removes(table);
      if (!remove) continue;
      // Set-based and atomic: the rows archived are exactly the rows deleted.
      const [{ n }] = await tx.$queryRawUnsafe(
        // `$3::text IS NULL OR TRUE` only types the year parameter for the tables that do not compare it.
        `WITH gone AS (DELETE FROM ${quote(table)} WHERE ${scoped} AND (${remove}) AND ($3::text IS NULL OR TRUE) RETURNING *),
              kept AS (INSERT INTO "company_reset_archive"(tenant_id,run_id,co_code,table_name,row_data)
                       SELECT $1,$4::bigint,$2,$5,to_jsonb(gone) FROM gone RETURNING 1)
         SELECT count(*)::int n FROM kept`,
        scope.tenantId,
        coCode,
        year,
        runId,
        table,
      );
      if (Number(n)) deleted.push({ table, rows: Number(n) });
      archived += Number(n);
    }
    const signature = (entries: TableCount[]) =>
      [...entries]
        .sort((a, b) => a.table.localeCompare(b.table))
        .map((entry) => `${entry.table}:${entry.rows}`)
        .join(',');
    if (signature(summary.deleted) !== signature(deleted))
      throw new Error('company reset deleted other rows than it planned; rolled back');
    // Exactly the planned kept rows remain in every table the reset touches.
    const touched = tables.filter((table) => removes(table));
    const keptPlan = new Map(summary.kept.map((entry) => [entry.table, entry.rows]));
    const remaining = await tableCounts(tx, scope.tenantId, coCode, touched);
    for (const table of touched)
      if ((remaining.get(table) ?? 0) !== (keptPlan.get(table) ?? 0))
        throw new Error(`company reset left unexpected rows in ${table}; rolled back`);

    // Module_Schm.cs:161 clears every location's try date; the web clears this company's.
    await tx.$executeRawUnsafe(
      `UPDATE "LOCT_MAST" SET "TRY_DATE"=NULL WHERE ${scoped} AND "TRY_DATE" IS NOT NULL`,
      scope.tenantId,
      coCode,
    );
    await provisionCompanyTx(tx, scope.tenantId, coCode, {
      lcCode: await seedLocation(tx, scope.tenantId, coCode, company.lcCode),
      templatesOnly: true,
    });
    // The seed added rows only to the cleared tables, and never touched a kept table.
    const after = await tableCounts(tx, scope.tenantId, coCode, tables);
    let restoredDefaults = 0;
    for (const table of tables) {
      if (KEPT_TABLES.has(table)) {
        if ((after.get(table) ?? 0) !== (keptPlan.get(table) ?? 0))
          throw new Error(`company reset changed the kept table ${table}; rolled back`);
      } else restoredDefaults += (after.get(table) ?? 0) - (remaining.get(table) ?? 0);
    }

    // End every other sign-in on the company; the caller's own session stays and reloads its context.
    const revokedSessions = Number(
      await tx.$executeRawUnsafe(
        `UPDATE "auth_session" SET "revoked_at"=clock_timestamp(),"revoke_reason"='company-reset'
          WHERE tenant_id=$1 AND (co_code=$2 OR login_co_code=$2) AND session_id<>$3 AND "revoked_at" IS NULL`,
        scope.tenantId,
        coCode,
        scope.sessionId,
      ),
    );
    const diffs = deleted.map((entry) => ({
      table: entry.table,
      insert: 0,
      update: 0,
      delete: entry.rows,
    }));
    // preview_hash is unique per applied operation; bind it to this run and the confirmed preview.
    const runHash = createHash('sha256')
      .update(JSON.stringify({ fingerprint: summary.fingerprint, run: randomUUID() }))
      .digest('hex');
    await tx.$executeRawUnsafe(
      `INSERT INTO "data_repair_run"
         (row_id,tenant_id,operation_id,co_code,co_year,state,preview_hash,counts,applied_counts,samples,operator,
          reason,reauthenticated_at,applied_at)
       VALUES ($1::bigint,$2,$3,$4,$5,'applied',$6,$7::jsonb,$7::jsonb,$8::jsonb,$9,$10,$11,now())`,
      runId,
      scope.tenantId,
      COMPANY_RESET_OPERATION,
      coCode,
      year,
      runHash,
      JSON.stringify(diffs),
      JSON.stringify([
        `${company.coCode} ${company.coName}`,
        `preview ${summary.fingerprint}`,
        `archived ${archived} rows to company_reset_archive`,
        `kept year ${year ?? 'none'}`,
        `default master rows restored ${restoredDefaults}`,
        `revoked sessions ${revokedSessions}`,
      ]),
      scope.operator.slice(0, 64),
      reason,
      reauthenticatedAt,
    );
    return {
      ...summary,
      runId: String(runId),
      archived,
      restoredDefaults,
      revokedSessions,
      ownCompany: coCode === scope.sessionCoCode,
    };
  });
}
