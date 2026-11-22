import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { hashPassword } from '../src/modules/auth/password.js';
import { assertCompanyBackupIntegrity, backupCompany } from '../src/modules/ops/backup.js';
import { loadBackupSchemaManifest } from '../src/modules/ops/backupManifest.js';
import {
  BACKUP_EXCLUDED_SECRETS,
  TENANT_CONFIG_ALLOWLIST,
  TENANT_CONFIG_EXCLUDED_TABLES,
  TENANT_CONFIG_KIND,
  TENANT_CONFIG_VERSION,
  findSecretValuesInArchive,
  isExcludedSecretColumn,
  looksSecret,
} from '../src/modules/ops/backupTenantConfigPolicy.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * D37 (OD-4, D-BKP-3; G64/N80, N237/G249): the real v2 archive carries the versioned NextMain-equivalent
 * tenantConfig section and never carries a secret, the users' password hashes included (risk A).
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT_A = 'wp08-tenant-config-a';
const TENANT_B = 'wp08-tenant-config-b';
const COMPANY = '01';

/** One distinct sentinel per excluded secret column; none may appear anywhere in the archive. */
const SECRET_VALUES: Record<string, string> = {
  'LOGIN_MAST.LOGIN_PWD': 'unused: the seeded value is the Argon2id hash',
  'BOOK_IDTL.SVR_PWD': 'WP08-SVR-PWD',
  'CO_MAST.URL_PWD': 'WP08-URL-PWD',
  'CO_MAST.MAIL_API': 'WP08-MAIL-API',
  'DG_GOLD_MAST.API_KEY': 'WP08-API-KEY',
  'E_MAST.ASP_PWD': 'WP08-ASP-PWD',
  'E_MAST.E_LOGIN_PWD': 'WP08-ELOGIN',
};
const SESSION_HASH = 'a1'.repeat(32);
const RECEIPT_KEY = 'WP08-IDEMPOTENCY-RECEIPT-KEY';
const RECEIPT_BODY = 'WP08-RECEIPT-BODY';

(RUN ? describe : describe.skip)('Data Backup tenantConfig envelope (D37, G64/N80)', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let passwordHash = '';

  const cleanup = async (): Promise<void> => {
    await owner.$executeRawUnsafe(`
      DO $wp08_cleanup$
      DECLARE candidate record;
      BEGIN
        PERFORM set_config('app.allow_repair_purge', 'on', true);
        FOR candidate IN
          SELECT DISTINCT table_name FROM information_schema.columns
           WHERE table_schema='public' AND column_name='tenant_id'
        LOOP
          EXECUTE format('DELETE FROM public.%I WHERE tenant_id = ANY ($1)', candidate.table_name)
            USING ARRAY['${TENANT_A}','${TENANT_B}']::text[];
        END LOOP;
      END
      $wp08_cleanup$;
    `);
  };

  const seed = async (tenantId: string, label: string): Promise<void> => {
    const secret = (key: string): string => `${SECRET_VALUES[key]}-${label}`;
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE","CO_TYPE","URL_PWD","MAIL_API")
       VALUES ($1,$2,$3,'00','A',$4,$5)`,
      tenantId,
      COMPANY,
      `Company ${label}`,
      secret('CO_MAST.URL_PWD'),
      secret('CO_MAST.MAIL_API'),
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","FINE_STK_TYPE","IP_WITH_PC","THEME")
       VALUES ($1,$2,'F','A',1)`,
      tenantId,
      COMPANY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "E_MAST"(tenant_id,"CO_CODE","ASP_ID","ASP_PWD","E_LOGIN_USER","E_LOGIN_PWD")
       VALUES ($1,$2,'asp-user',$3,'einv-user',$4)`,
      tenantId,
      COMPANY,
      secret('E_MAST.ASP_PWD'),
      secret('E_MAST.E_LOGIN_PWD'),
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "DG_GOLD_MAST"(tenant_id,"CO_CODE","COUNTRY_CODE","API_KEY")
       VALUES ($1,$2,'IN',$3)`,
      tenantId,
      COMPANY,
      secret('DG_GOLD_MAST.API_KEY'),
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_IDTL"(tenant_id,"AC_CODE","MAIN_BOOK","SR_NO","AC_NAME","SVR_PWD")
       VALUES ($1,'00001','CASH',1,$2,$3)`,
      tenantId,
      `Book slot ${label}`,
      secret('BOOK_IDTL.SVR_PWD'),
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "MENU_DATA"(tenant_id,"SM_NAME","SM_CODE","SM_MAIN_NAME")
       VALUES ($1,$2,'1','Company')`,
      tenantId,
      `Menu ${label}`,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(
         tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","PASSWORD_RESET_REQUIRED"
       ) VALUES ($1,$2,$3,$4,'ADMIN','N')`,
      tenantId,
      COMPANY,
      `admin-${label}`,
      passwordHash,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "auth_session"(
         tenant_id,session_id,login_name,login_co_code,co_code,lc_code,refresh_jti_hash,expires_at
       ) VALUES ($1,$2,$3,$4,$4,'00',$5,now()+interval '1 day')`,
      tenantId,
      `wp08-session-${label}`.slice(0, 36),
      `admin-${label}`,
      COMPANY,
      SESSION_HASH,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "api_command_receipt"(
         tenant_id,idempotency_key,route,request_sha256,actor,response_status,response_body,expires_at
       ) VALUES ($1,$2,'/vouchers/test',$3,'wp08',200,$4::json,now()+interval '1 day')`,
      tenantId,
      `${RECEIPT_KEY}-${label}`,
      'b2'.repeat(32),
      JSON.stringify({ note: `${RECEIPT_BODY}-${label}` }),
    );
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl)
      throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL are required for WP-08 tests');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
    passwordHash = await hashPassword('Wp08-Backup-Password!2026');
  });

  beforeEach(cleanup);

  afterAll(async () => {
    if (owner) await cleanup();
    await owner?.$disconnect();
    await runtime?.$disconnect();
  });

  it('classifies every live tenant-shared table and column against the reviewed policy', async () => {
    const manifest = await loadBackupSchemaManifest(owner);
    const shared = manifest.tables.filter((table) => table.scope === 'tenant-shared');
    const allowlisted = new Set(TENANT_CONFIG_ALLOWLIST.map((entry) => entry.table));
    const excluded = new Set(TENANT_CONFIG_EXCLUDED_TABLES.map((entry) => entry.table));
    expect(
      shared
        .map((table) => table.name)
        .filter((name) => !allowlisted.has(name) && !excluded.has(name)),
    ).toEqual([]);
    for (const entry of TENANT_CONFIG_ALLOWLIST) {
      const table = manifest.tables.find((candidate) => candidate.name === entry.table);
      expect(table?.scope, entry.table).toBe('tenant-shared');
      const secrets = BACKUP_EXCLUDED_SECRETS.filter((secret) => secret.table === entry.table).map(
        (secret) => secret.column,
      );
      expect(table!.columns.map((column) => column.name).sort(), entry.table).toEqual(
        [...entry.columns, ...secrets].sort(),
      );
    }
    for (const secret of BACKUP_EXCLUDED_SECRETS) {
      const table = manifest.tables.find((candidate) => candidate.name === secret.table);
      expect(
        table?.columns.some((column) => column.name === secret.column),
        `${secret.table}.${secret.column}`,
      ).toBe(true);
    }
  });

  it('writes the versioned allowlisted tenantConfig of this tenant only, with its manifest', async () => {
    await seed(TENANT_A, 'A');
    await seed(TENANT_B, 'B');
    const document = await backupCompany(runtime, TENANT_A, COMPANY);
    const section = document.tenantConfig!;

    expect(section).toMatchObject({ kind: TENANT_CONFIG_KIND, version: TENANT_CONFIG_VERSION });
    expect(section.allowlist.map((entry) => entry.table)).toEqual(
      TENANT_CONFIG_ALLOWLIST.map((entry) => entry.table),
    );
    expect(document.manifest.tenantConfig).toEqual({
      kind: section.kind,
      version: section.version,
      allowlist: section.allowlist,
      excludedTables: section.excludedTables,
      excludedSecrets: section.excludedSecrets,
    });
    expect(section.excludedTables.map((entry) => entry.table)).toEqual(
      expect.arrayContaining(['auth_session', 'api_command_receipt']),
    );
    expect(section.tables.MENU_DATA?.rows.map((row) => row.SM_NAME)).toEqual(['Menu A']);
    expect(section.tables.BOOK_IDTL?.rows.map((row) => row.AC_NAME)).toEqual(['Book slot A']);
    expect(section.totals.rows).toBeGreaterThanOrEqual(2);
    const serialized = JSON.stringify(document);
    expect(serialized).not.toContain('Menu B');
    expect(serialized).not.toContain('Book slot B');
    expect(() => assertCompanyBackupIntegrity(document)).not.toThrow();
  });

  it('leaves out the Argon2id password hash and every other excluded secret', async () => {
    await seed(TENANT_A, 'A');
    const document = await backupCompany(runtime, TENANT_A, COMPANY);
    const serialized = JSON.stringify(document);

    expect(passwordHash).toMatch(/^\$argon2id\$/);
    expect(document.tables.LOGIN_MAST?.rows.map((row) => row.LOGIN_NAME)).toEqual(['admin-A']);
    expect(document.tables.LOGIN_MAST?.rows.map((row) => row.LOGIN_PWD)).toEqual([null]);
    expect(serialized).not.toContain(passwordHash);
    expect(serialized).not.toContain('$argon2');

    expect(document.tenantConfig!.excludedSecrets).toEqual(
      BACKUP_EXCLUDED_SECRETS.map((entry) => ({ ...entry })),
    );
    for (const secret of BACKUP_EXCLUDED_SECRETS) {
      const key = `${secret.table}.${secret.column}`;
      const value = key === 'LOGIN_MAST.LOGIN_PWD' ? passwordHash : `${SECRET_VALUES[key]}-A`;
      expect(SECRET_VALUES[key], `${key} has a seeded sentinel`).toBeTruthy();
      const [stored] = await owner.$queryRawUnsafe<Array<{ value: string | null }>>(
        `SELECT "${secret.column}" AS value FROM "${secret.table}" WHERE tenant_id=$1`,
        TENANT_A,
      );
      expect(stored?.value, `${key} was seeded`).toBe(value);
      expect(serialized, `${key} must not be in the archive`).not.toContain(value);
      const companyRows = document.tables[secret.table]?.rows;
      const configRows = document.tenantConfig!.tables[secret.table]?.rows;
      expect(companyRows ?? configRows, `${key} table is exported`).toHaveLength(1);
      for (const row of companyRows ?? []) expect(row[secret.column], key).toBeNull();
      for (const row of configRows ?? [])
        expect(Object.keys(row), key).not.toContain(secret.column);
    }
    expect(serialized).not.toContain(SESSION_HASH);
    expect(serialized).not.toContain('wp08-session-A');
    expect(serialized).not.toContain(RECEIPT_KEY);
    expect(serialized).not.toContain(RECEIPT_BODY);
    expect(document.tenantConfig!.tables.auth_session).toBeUndefined();
    expect(document.tenantConfig!.tables.api_command_receipt).toBeUndefined();
    // Risk A guard: no secret-looking column carries a value anywhere in the archive.
    expect(findSecretValuesInArchive(document)).toEqual([]);
  });

  it('lists every secret-looking exported column of the live schema as an excluded secret', async () => {
    const manifest = await loadBackupSchemaManifest(owner);
    const allowlisted = new Map(
      TENANT_CONFIG_ALLOWLIST.map((entry) => [entry.table, entry.columns]),
    );
    const exported: string[] = [];
    for (const table of manifest.tables) {
      const columns =
        table.scope === 'company' && table.included
          ? table.columns.map((column) => column.name)
          : (allowlisted.get(table.name) ?? []);
      for (const name of columns)
        if (looksSecret(table.name, name) && !isExcludedSecretColumn(table.name, name))
          exported.push(`${table.name}.${name}`);
    }
    expect(exported).toEqual([]);
  });

  it('excludes a configuration column added after the review, and the guard catches a new secret', async () => {
    await seed(TENANT_A, 'A');
    try {
      await owner.$executeRawUnsafe(`ALTER TABLE "MENU_DATA" ADD COLUMN "WP08_NEW_SETTING" text`);
      await owner.$executeRawUnsafe(`ALTER TABLE "CO_MAST" ADD COLUMN "WP08_WEBHOOK_TOKEN" text`);
      await owner.$executeRawUnsafe(
        `UPDATE "MENU_DATA" SET "WP08_NEW_SETTING"='WP08-UNREVIEWED-VALUE' WHERE tenant_id=$1`,
        TENANT_A,
      );
      await owner.$executeRawUnsafe(
        `UPDATE "CO_MAST" SET "WP08_WEBHOOK_TOKEN"='WP08-NEW-TOKEN' WHERE tenant_id=$1`,
        TENANT_A,
      );
      // Company tables are copied whole, so a new secret-looking company column refuses the backup at runtime.
      await expect(backupCompany(runtime, TENANT_A, COMPANY)).rejects.toThrow(
        /CO_MAST\.WP08_WEBHOOK_TOKEN/,
      );
      // Without that column the unreviewed configuration column is still not exported (allowlist, not denylist).
      await owner.$executeRawUnsafe(`ALTER TABLE "CO_MAST" DROP COLUMN "WP08_WEBHOOK_TOKEN"`);
      const document = await backupCompany(runtime, TENANT_A, COMPANY);
      expect(document.tenantConfig!.tables.MENU_DATA?.rows).toHaveLength(1);
      expect(Object.keys(document.tenantConfig!.tables.MENU_DATA!.rows[0]!)).not.toContain(
        'WP08_NEW_SETTING',
      );
      expect(JSON.stringify(document)).not.toContain('WP08-UNREVIEWED-VALUE');
      expect(findSecretValuesInArchive(document)).toEqual([]);
    } finally {
      await owner.$executeRawUnsafe(
        `ALTER TABLE "MENU_DATA" DROP COLUMN IF EXISTS "WP08_NEW_SETTING"`,
      );
      await owner.$executeRawUnsafe(
        `ALTER TABLE "CO_MAST" DROP COLUMN IF EXISTS "WP08_WEBHOOK_TOKEN"`,
      );
    }
  });
});
