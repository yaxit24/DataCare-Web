/**
 * D37 (OD-4, D-BKP-3; G64/N80): what the Data Backup archive carries beyond the company tables.
 *
 * The desktop `UT_BKP` Backup button writes two SQL Server backups: the company database and `NextMain`, the
 * master/configuration database (`UT_BKP.cs:1225-1248`). The web keeps one PostgreSQL database keyed by
 * `tenant_id`; the company tables (`tenant_id` + `CO_CODE`) are already in the v2 archive. The NextMain
 * equivalent is this tenant's rows of the tenant-shared configuration tables below, exported column by column
 * from an explicit allowlist. A tenant-shared table or a column that is not listed here is never exported.
 *
 * Secrets are never written to the archive (D37, risk A): sessions, refresh-token hashes, idempotency receipts,
 * the users' password hashes and every integration credential. Secret columns that live on company tables are
 * written as `null`; an administrator re-enters them (and users reset their passwords) after a restore.
 *
 * Note (N237/G249): D37 as recorded in LITE-MASTER-PLAN OD-4 kept the Argon2id hashes (`LOGIN_MAST.LOGIN_PWD`)
 * so that a restored company logs in as before. The WP-08 brief narrows that: no password hash leaves the
 * database in this downloadable archive. Physical disaster recovery (`pg_dump`, DR runbook) is unaffected.
 * Re-adding the hash is a one-line removal below and needs an owner decision.
 *
 * `SECRET_COLUMN_PATTERN` is the guard: every column of the live schema whose name matches it must be listed
 * in `BACKUP_EXCLUDED_SECRETS`, live in an excluded table, or be reviewed as not secret in
 * `REVIEWED_NON_SECRET_COLUMNS` (tests fail otherwise).
 *
 * Bump `TENANT_CONFIG_VERSION` whenever an entry below changes.
 */

export const TENANT_CONFIG_KIND = 'datacare.tenant-config' as const;
export const TENANT_CONFIG_VERSION = 1 as const;

/** Column names that look like a credential, key, token, hash or password (case-insensitive). */
export const SECRET_COLUMN_PATTERN =
  /(PWD|PASSW|PASSCODE|SECRET|TOKEN|API_?KEY|MAIL_API|CREDENTIAL|JTI|HASH|SALT|PRIVATE|OTP)/i;

/** Columns matching the pattern that are reviewed as not secret (flags and timestamps, a preview digest). */
export const REVIEWED_NON_SECRET_COLUMNS: readonly string[] = [
  'LOGIN_MAST.PASSWORD_RESET_REQUIRED',
  'LOGIN_MAST.PASSWORD_CHANGED_AT',
];

export interface TenantConfigAllowlistPolicy {
  readonly table: string;
  readonly columns: readonly string[];
  readonly purpose: string;
}

export interface TenantConfigExcludedTablePolicy {
  readonly table: string;
  readonly reason: string;
}

export interface BackupExcludedSecretPolicy {
  readonly table: string;
  readonly column: string;
  readonly reason: string;
}

export const TENANT_CONFIG_ALLOWLIST: readonly TenantConfigAllowlistPolicy[] = [
  {
    table: 'MENU_DATA',
    columns: [
      'tenant_id',
      'row_id',
      'SM_NAME',
      'SM_VIEW',
      'SM_CODE',
      'SM_MAIN_CODE',
      'MAIN_SRNO',
      'BTN_NAME',
      'SM_MAIN_NAME',
      'SM_TYPE',
      'TILE_ITEM',
    ],
    purpose: 'NextMain menu table loaded by the MDI (MS_COMPANY.cs:6174)',
  },
  {
    table: 'TILE_DATA',
    columns: [
      'tenant_id',
      'SM_MAIN_NAME',
      'SR_NO',
      'DISPLAY_NAME',
      'SHORT_NAME',
      'TILE_NAME',
      'ITM_SHOW',
    ],
    purpose: 'home-screen tiles read at login (MS_LOGIN.cs:525)',
  },
  {
    table: 'USER_MAST',
    columns: ['tenant_id', 'TBL_COL_NAME', 'COL_NAME'],
    purpose: 'user column captions (DC_Main.cs:2145)',
  },
  {
    table: 'APP_USER_DATA',
    columns: ['tenant_id', 'MEMB_NUMBER', 'MEMB_NAME', 'MEMB_EMAIL'],
    purpose: 'application member list (Module_Schm.cs:646)',
  },
  {
    table: 'BOOK_IDTL',
    columns: ['tenant_id', 'row_id', 'AC_CODE', 'MAIN_BOOK', 'SR_NO', 'INOUT_TYPE', 'AC_NAME'],
    purpose: 'book account slots (MDI_FORM.cs:11146); SVR_PWD is an excluded secret',
  },
  {
    table: 'WEIGHT_MAST',
    columns: ['tenant_id', 'row_id', 'SR_NO', 'LOW_WT', 'HIGH_WT', 'COL_NAME'],
    purpose: 'weight-range colour bands (MS_UPDATE.cs:18807)',
  },
  {
    table: 'HDD_MAST',
    columns: ['tenant_id', 'row_id', 'REF_NO'],
    purpose: 'registered reference number (MS_COMPANY.cs:7048, UT_HDD)',
  },
  {
    table: 'STATE_MAST',
    columns: ['tenant_id', 'row_id', 'STATE_CODE', 'STATE_SHORT', 'STATE_NAME'],
    purpose: 'state master used by party and GST forms (MS_ACCT.cs:6988)',
  },
  {
    table: 'COUNTRY_MAST',
    columns: ['tenant_id', 'row_id', 'CON_CODE', 'CON_NAME', 'MAIN_USER'],
    purpose: 'country master',
  },
];

export const TENANT_CONFIG_EXCLUDED_TABLES: readonly TenantConfigExcludedTablePolicy[] = [
  { table: 'auth_session', reason: 'D37 secret: login sessions and refresh-token hashes' },
  { table: 'api_command_receipt', reason: 'D37 secret: idempotency receipts' },
  {
    table: 'message_attempt_log',
    reason: 'transient outbound-message provider log with idempotency keys, not configuration',
  },
  { table: 'audit_log', reason: 'platform request audit trail, kept by the platform' },
  { table: 'company_backup_run', reason: 'backup handoff ledger, written after the archive' },
  { table: 'data_repair_run', reason: 'data-repair operation ledger, kept by the platform' },
];

export const UNREVIEWED_TENANT_TABLE_REASON =
  'tenant-shared table not reviewed for the tenant-config allowlist; never exported';

export const BACKUP_EXCLUDED_SECRETS: readonly BackupExcludedSecretPolicy[] = [
  { table: 'BOOK_IDTL', column: 'SVR_PWD', reason: 'D37 integration secret: server password' },
  { table: 'LOGIN_MAST', column: 'LOGIN_PWD', reason: 'D37 secret: user password hash (Argon2id)' },
  { table: 'CO_MAST', column: 'URL_PWD', reason: 'D37 integration secret: web URL password' },
  { table: 'CO_MAST', column: 'MAIL_API', reason: 'D37 integration secret: SMTP mail key' },
  { table: 'DG_GOLD_MAST', column: 'API_KEY', reason: 'D37 integration secret: rate API key' },
  { table: 'E_MAST', column: 'ASP_PWD', reason: 'D37 integration secret: GSP/ASP password' },
  {
    table: 'E_MAST',
    column: 'E_LOGIN_PWD',
    reason: 'D37 integration secret: e-invoice login password',
  },
];

export const isExcludedSecretColumn = (table: string, column: string): boolean =>
  BACKUP_EXCLUDED_SECRETS.some((entry) => entry.table === table && entry.column === column);

export const isReviewedNonSecretColumn = (table: string, column: string): boolean =>
  REVIEWED_NON_SECRET_COLUMNS.includes(`${table}.${column}`);

/** A column whose name looks secret and that nobody reviewed as harmless. */
export const looksSecret = (table: string, column: string): boolean =>
  SECRET_COLUMN_PATTERN.test(column) && !isReviewedNonSecretColumn(table, column);

type ScannedTables = Record<string, { rows: ReadonlyArray<Record<string, unknown>> }>;

/**
 * Risk A guard (N237/G249): every `table.column` of an archive whose name looks secret and that carries a value.
 * A correct archive returns `[]`; tests fail on anything else.
 */
export const findSecretValuesInArchive = (document: {
  tables: ScannedTables;
  tenantConfig?: { tables: ScannedTables };
}): string[] => {
  const leaks = new Set<string>();
  const scan = (tables: ScannedTables): void => {
    for (const [table, data] of Object.entries(tables))
      for (const row of data.rows)
        for (const [column, value] of Object.entries(row))
          if (value !== null && value !== undefined && looksSecret(table, column))
            leaks.add(`${table}.${column}`);
  };
  scan(document.tables);
  if (document.tenantConfig) scan(document.tenantConfig.tables);
  return [...leaks].sort();
};
