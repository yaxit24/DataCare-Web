import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  BACKUP_SCHEMA_KIND,
  COMPANY_BACKUP_KIND,
  COMPANY_BACKUP_VERSION,
  assertCompanyBackupIntegrity,
  resealCompanyBackupDocument,
  schemaFingerprint,
  tenantConfigDescriptor,
  type BackupColumnManifest,
  type BackupTableManifest,
  type CompanyBackupDocument,
  type TenantConfigSection,
} from '../src/modules/ops/backupManifest.js';
import {
  BACKUP_EXCLUDED_SECRETS,
  TENANT_CONFIG_ALLOWLIST,
  TENANT_CONFIG_EXCLUDED_TABLES,
  TENANT_CONFIG_KIND,
  TENANT_CONFIG_VERSION,
  isExcludedSecretColumn,
} from '../src/modules/ops/backupTenantConfigPolicy.js';

/** D37 (OD-4, D-BKP-3; G64/N80) policy and validator, without a database. */

const column = (name: string, ordinal: number): BackupColumnManifest => ({
  name,
  ordinal,
  dataType: 'character varying',
  udtName: 'varchar',
  formattedType: 'character varying(255)',
  collation: null,
  nullable: name !== 'tenant_id' && name !== 'CO_CODE',
  defaultExpression: null,
  generated: false,
  identity: false,
  sequence: null,
});

const table = (
  name: string,
  scope: BackupTableManifest['scope'],
  names: string[],
): BackupTableManifest => ({
  name,
  scope,
  included: scope === 'company',
  exclusionReason: scope === 'company' ? null : 'tenant-shared',
  primaryKey: names.slice(0, scope === 'company' ? 2 : 1),
  dependencies: [],
  rlsEnabled: true,
  rlsForced: true,
  constraints: [],
  indexes: [],
  policies: [],
  triggers: [],
  columns: names.map(column),
});

const TENANT = 'unit-tenant';

const fixture = (): CompanyBackupDocument => {
  const tables = [
    table('CO_MAST', 'company', ['tenant_id', 'CO_CODE', 'CO_NAME', 'URL_PWD', 'MAIL_API']),
    table('USER_MAST', 'tenant-shared', ['tenant_id', 'TBL_COL_NAME', 'COL_NAME']),
    table('auth_session', 'tenant-shared', ['tenant_id', 'session_id', 'refresh_jti_hash']),
  ];
  const section: TenantConfigSection = {
    kind: TENANT_CONFIG_KIND,
    version: TENANT_CONFIG_VERSION,
    allowlist: [{ table: 'USER_MAST', columns: ['tenant_id', 'TBL_COL_NAME', 'COL_NAME'] }],
    excludedTables: [{ table: 'auth_session', reason: 'sessions' }],
    excludedSecrets: BACKUP_EXCLUDED_SECRETS.map((entry) => ({ ...entry })),
    totals: { tables: 0, rows: 0 },
    tables: {
      USER_MAST: {
        rows: [{ tenant_id: TENANT, TBL_COL_NAME: 'AC_MAST.AC_NAME', COL_NAME: 'Name' }],
        rowCount: 0,
        checksum: '',
      },
    },
  };
  return resealCompanyBackupDocument({
    kind: COMPANY_BACKUP_KIND,
    version: COMPANY_BACKUP_VERSION,
    generatedAt: '2026-11-09T00:00:00.000Z',
    tenant: TENANT,
    company: '01',
    databaseTarget: 'postgres',
    source: { tenantId: TENANT, companyCode: '01' },
    manifest: {
      kind: BACKUP_SCHEMA_KIND,
      fingerprint: schemaFingerprint(tables),
      tables,
      tenantConfig: tenantConfigDescriptor(section),
    },
    totals: { schemaTables: 0, companyTables: 0, excludedTables: 0, rows: 0 },
    tables: {
      CO_MAST: {
        rows: [
          { tenant_id: TENANT, CO_CODE: '01', CO_NAME: 'Unit', URL_PWD: null, MAIL_API: null },
        ],
        rowCount: 0,
        checksum: '',
      },
    },
    tenantConfig: section,
    checksum: '',
  });
};

describe('Data Backup tenantConfig policy (D37, G64/N80)', () => {
  it('lists the D37 exclusions by name and never allowlists a secret column', () => {
    expect(TENANT_CONFIG_KIND).toBe('datacare.tenant-config');
    expect(Number.isInteger(TENANT_CONFIG_VERSION) && TENANT_CONFIG_VERSION > 0).toBe(true);
    expect(TENANT_CONFIG_ALLOWLIST.length).toBeGreaterThan(0);
    const excluded = TENANT_CONFIG_EXCLUDED_TABLES.map((entry) => entry.table);
    expect(excluded).toEqual(expect.arrayContaining(['auth_session', 'api_command_receipt']));
    for (const entry of TENANT_CONFIG_ALLOWLIST) {
      expect(excluded).not.toContain(entry.table);
      expect(entry.columns).toContain('tenant_id');
      for (const name of entry.columns)
        expect(isExcludedSecretColumn(entry.table, name), `${entry.table}.${name}`).toBe(false);
    }
  });

  it('covers every credential-like column in the Prisma schema except the kept password hash', () => {
    const schema = readFileSync(
      new URL('../../../packages/db/prisma/schema.prisma', import.meta.url),
      'utf8',
    );
    const credentialLike = /(PWD|PASSWORD$|API_KEY|MAIL_API|SECRET|TOKEN)/i;
    const found: string[] = [];
    for (const model of schema.matchAll(/^model (\w+) \{([\s\S]*?)^\}/gm)) {
      const body = model[2]!;
      const name = /@@map\("([^"]+)"\)/.exec(body)?.[1] ?? model[1]!;
      for (const line of body.split('\n')) {
        const field = line.trim();
        if (!field || field.startsWith('//') || field.startsWith('@@')) continue;
        const columnName = /@map\("([^"]+)"\)/.exec(field)?.[1] ?? field.split(/\s+/)[0]!;
        if (credentialLike.test(columnName)) found.push(`${name}.${columnName}`);
      }
    }
    // D37 keeps the users' Argon2id hashes so that a restored company logs in as before.
    const kept = ['LOGIN_MAST.LOGIN_PWD'];
    const listed = BACKUP_EXCLUDED_SECRETS.map((entry) => `${entry.table}.${entry.column}`);
    expect(found.filter((entry) => !kept.includes(entry)).sort()).toEqual([...listed].sort());
  });

  it('accepts a sealed archive whose secrets are null and whose envelope matches its manifest', () => {
    expect(() => assertCompanyBackupIntegrity(fixture())).not.toThrow();
  });

  it.each(BACKUP_EXCLUDED_SECRETS.filter((entry) => entry.table === 'CO_MAST'))(
    'refuses an archive carrying $table.$column',
    ({ column: name }) => {
      const document = fixture();
      document.tables.CO_MAST!.rows[0]![name] = 'leaked';
      expect(() => assertCompanyBackupIntegrity(resealCompanyBackupDocument(document))).toThrow(
        /excluded secret/,
      );
    },
  );

  it('refuses a tenantConfig row with an unlisted column or another tenant', () => {
    const extra = fixture();
    extra.tenantConfig!.tables.USER_MAST!.rows[0]!.SVR_PWD = 'leaked';
    expect(() => assertCompanyBackupIntegrity(resealCompanyBackupDocument(extra))).toThrow(
      /row columns do not match/,
    );
    const foreign = fixture();
    foreign.tenantConfig!.tables.USER_MAST!.rows[0]!.tenant_id = 'other-tenant';
    expect(() => assertCompanyBackupIntegrity(resealCompanyBackupDocument(foreign))).toThrow(
      /row tenant/,
    );
  });

  it('refuses an envelope that drifts from its manifest or exports an excluded table', () => {
    const drift = fixture();
    drift.manifest.tenantConfig!.excludedSecrets = [];
    expect(() => assertCompanyBackupIntegrity(resealCompanyBackupDocument(drift))).toThrow(
      /does not match its manifest/,
    );
    const sessions = fixture();
    const entry = { table: 'auth_session', columns: ['tenant_id', 'refresh_jti_hash'] };
    sessions.tenantConfig!.allowlist.push(entry);
    sessions.manifest.tenantConfig!.allowlist = sessions.tenantConfig!.allowlist;
    sessions.tenantConfig!.tables.auth_session = { rows: [], rowCount: 0, checksum: '' };
    expect(() => assertCompanyBackupIntegrity(resealCompanyBackupDocument(sessions))).toThrow(
      /not an allowlisted entry/,
    );
  });

  it('refuses a section without its manifest descriptor', () => {
    const document = fixture();
    delete document.manifest.tenantConfig;
    expect(() => assertCompanyBackupIntegrity(resealCompanyBackupDocument(document))).toThrow(
      /must both be present/,
    );
  });
});
