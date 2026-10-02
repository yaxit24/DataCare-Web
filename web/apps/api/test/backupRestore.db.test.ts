import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  COMPANY_BACKUP_KIND,
  COMPANY_BACKUP_VERSION,
  assertCompanyBackupIntegrity,
  backupCompany,
  restoreCompany,
  type CompanyBackup,
} from '../src/modules/ops/backup.js';
import {
  decodeBackupCell,
  encodeBackupCell,
  resealCompanyBackupDocument,
  schemaFingerprint,
  type BackupColumnManifest,
} from '../src/modules/ops/backupManifest.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT_A = 'wp02-backup-a';
const TENANT_B = 'wp02-backup-b';
const COMPANY_A = '01';
const COMPANY_B = '02';
const TEST_TENANTS = [TENANT_A, TENANT_B] as const;
const SOURCE_BYTES = Buffer.from([0x00, 0x01, 0x7f, 0x80, 0xfe, 0xff, 0x42]);

const clone = <T>(value: T): T => structuredClone(value);
const checksums = (document: CompanyBackup): Record<string, string> =>
  Object.fromEntries(
    Object.entries(document.tables).map(([name, table]) => [name, table.checksum]),
  );

const firstRow = (document: CompanyBackup, table: string) => {
  const row = document.tables[table]?.rows[0];
  if (!row) throw new Error(`fixture backup has no ${table} row`);
  return row;
};

databaseDescribe('WP-02A company logical backup/restore', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    await owner.$executeRawUnsafe(`
      DO $wp02_cleanup$
      DECLARE candidate record;
      BEGIN
        -- Append-only ledgers (data_repair_run, company_backup_run) refuse DELETE unless a caller opts in
        -- explicitly. A fixture is entitled to that opt-in; ordinary application code never sets it, so the
        -- immutability guarantee is unaffected by this line.
        PERFORM set_config('app.allow_repair_purge', 'on', true);
        FOR candidate IN
          SELECT DISTINCT table_name
            FROM information_schema.columns
           WHERE table_schema='public' AND column_name='tenant_id'
        LOOP
          EXECUTE format(
            'DELETE FROM public.%I WHERE tenant_id = ANY ($1)',
            candidate.table_name
          ) USING ARRAY['${TENANT_A}','${TENANT_B}']::text[];
        END LOOP;
      END
      $wp02_cleanup$;
    `);
  };

  const seedCompany = async (
    tenantId: string,
    companyCode: string,
    label: string,
    bytes: Buffer,
  ): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE")
       VALUES ($1,$2,$3,'00')`,
      tenantId,
      companyCode,
      `Company ${label}`,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","FINE_STK_TYPE","IP_WITH_PC","THEME")
       VALUES ($1,$2,'F','A',1)`,
      tenantId,
      companyCode,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(
         tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","L_BR_DATE","AMT_LIMIT","AC_CR_DAYS"
       ) VALUES ($1,$2,'00',$3,$4,'2025-08-29',1234567890123456.78,12.5)`,
      tenantId,
      companyCode,
      `A${label}`.slice(0, 8),
      `Account ${label}`,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ENTITY_IMAGE"(
         tenant_id,"CO_CODE","LC_CODE","ENTITY_KEY","INSTANCE","MIME_TYPE","IMAGE_SIZE",
         "IMAGE_BYTES","MAIN_USER","ENTRY_TIME"
       ) VALUES ($1,$2,'00',$3,7,'image/png',$4,$5,$6,'2025-08-29 12:34:56.789123')`,
      tenantId,
      companyCode,
      `TAG-${label}`,
      bytes.length,
      bytes,
      `user-${label}`,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ENTITY_IMAGE_REVISION" (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","REVISION")
       VALUES ($1,$2,'00','TAG',$3,7,9007199254740993)`,
      tenantId,
      companyCode,
      `TAG-${label}`,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "DESIGN_MAST"(tenant_id,"CO_CODE","DESIGN_NO","MAIN_USER")
       VALUES ($1,$2,$3,$4)`,
      tenantId,
      companyCode,
      `DESIGN-${label}`,
      label,
    );
  };

  const seedBase = async (): Promise<void> => {
    await seedCompany(TENANT_A, COMPANY_A, 'A01', SOURCE_BYTES);
    await seedCompany(TENANT_A, COMPANY_B, 'A02', Buffer.from('company-two'));
    await seedCompany(TENANT_B, COMPANY_A, 'B01', Buffer.from('other-tenant'));
    await owner.$executeRawUnsafe(
      `INSERT INTO "COUNTRY_MAST"(tenant_id,"CON_CODE","CON_NAME","MAIN_USER")
       VALUES ($1,'IN','India A','wp02'),($2,'GB','Britain B','wp02')`,
      TENANT_A,
      TENANT_B,
    );
  };

  const digest = async (
    table: string,
    where = '',
    ...values: unknown[]
  ): Promise<{ rows: number; checksum: string }> => {
    const [result] = await owner.$queryRawUnsafe<Array<{ rows: number; checksum: string }>>(
      `SELECT count(*)::int AS rows,
              md5(COALESCE(string_agg(normalized,E'\\n' ORDER BY normalized),'')) AS checksum
         FROM (SELECT to_jsonb(t)::text AS normalized FROM "${table}" t ${where}) rows`,
      ...values,
    );
    return { rows: Number(result?.rows ?? 0), checksum: String(result?.checksum ?? '') };
  };

  const excludedSnapshot = async (
    document: CompanyBackup,
  ): Promise<Record<string, { rows: number; checksum: string }>> => {
    const snapshot: Record<string, { rows: number; checksum: string }> = {};
    for (const table of document.manifest.tables.filter((entry) => !entry.included)) {
      snapshot[table.name] =
        table.scope === 'tenant-shared'
          ? await digest(table.name, 'WHERE tenant_id=$1', TENANT_A)
          : await digest(table.name);
    }
    return snapshot;
  };

  const sourceGuardState = async (): Promise<{ name: string; designs: number }> => {
    const [account] = await owner.$queryRawUnsafe<Array<{ name: string }>>(
      `SELECT "AC_NAME" AS name FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT_A,
      COMPANY_A,
    );
    const [designs] = await owner.$queryRawUnsafe<Array<{ count: number }>>(
      `SELECT count(*)::int AS count FROM "DESIGN_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT_A,
      COMPANY_A,
    );
    return { name: String(account?.name ?? ''), designs: Number(designs?.count ?? 0) };
  };

  const installRollbackGuards = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `UPDATE "AC_MAST" SET "AC_NAME"='ROLLBACK-GUARD'
        WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT_A,
      COMPANY_A,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "DESIGN_MAST"(tenant_id,"CO_CODE","DESIGN_NO","MAIN_USER")
       VALUES ($1,$2,'ROLLBACK-EXTRA','guard')`,
      TENANT_A,
      COMPANY_A,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl)
      throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL are required for WP-02A tests');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  beforeEach(cleanup);

  afterAll(async () => {
    if (owner) await cleanup();
    await owner?.$disconnect();
    await runtime?.$disconnect();
  });

  it('classifies the complete live schema and seals a lossless v2 document', async () => {
    await seedBase();
    const document = await backupCompany(runtime, TENANT_A, COMPANY_A);

    expect(document.kind).toBe(COMPANY_BACKUP_KIND);
    expect(document.version).toBe(COMPANY_BACKUP_VERSION);
    expect(document.manifest.tables).toHaveLength(175);
    expect(document.manifest.tables.filter((table) => table.included)).toHaveLength(160);
    expect(
      document.manifest.tables.filter((table) => table.scope === 'tenant-shared'),
    ).toHaveLength(14);
    expect(document.manifest.tables.filter((table) => table.scope === 'system')).toHaveLength(1);
    expect(document.manifest.tables.every((table) => table.primaryKey.length > 0)).toBe(true);
    expect(document.manifest.fingerprint).toMatch(/^[a-f0-9]{64}$/);
    expect(document.checksum).toMatch(/^[a-f0-9]{64}$/);
    expect(Object.keys(document.tables)).toHaveLength(160);
    const accountManifest = document.manifest.tables.find((table) => table.name === 'AC_MAST')!;
    const imageManifest = document.manifest.tables.find((table) => table.name === 'ENTITY_IMAGE')!;
    expect(accountManifest).toMatchObject({ rlsEnabled: true, rlsForced: true });
    expect(accountManifest.constraints.length).toBeGreaterThan(0);
    expect(accountManifest.indexes.length).toBeGreaterThan(0);
    expect(accountManifest.policies.length).toBeGreaterThan(0);
    expect(
      imageManifest.columns.find((column) => column.name === 'row_id')?.sequence,
    ).toMatchObject({ name: 'TAG_IMAGE_BLOB_row_id_seq', dataType: 'bigint' });
    expect(document.manifest.tables.find((table) => table.name === 'COUNTRY_MAST')).toMatchObject({
      scope: 'tenant-shared',
      included: false,
    });
    expect(
      document.manifest.tables.find((table) => table.name === '_prisma_migrations'),
    ).toMatchObject({ scope: 'system', included: false });

    expect(firstRow(document, 'ENTITY_IMAGE').IMAGE_BYTES).toEqual({
      $dcType: 'bytea',
      value: SOURCE_BYTES.toString('base64'),
    });
    expect(firstRow(document, 'ENTITY_IMAGE').row_id).toMatchObject({ $dcType: 'bigint' });
    expect(
      document.manifest.tables.find((table) => table.name === 'ENTITY_IMAGE_REVISION'),
    ).toMatchObject({
      included: true,
      scope: 'company',
      rlsEnabled: true,
      rlsForced: true,
    });
    expect(firstRow(document, 'ENTITY_IMAGE_REVISION').REVISION).toEqual({
      $dcType: 'bigint',
      value: '9007199254740993',
    });
    expect(firstRow(document, 'AC_MAST').AMT_LIMIT).toEqual({
      $dcType: 'decimal',
      value: '1234567890123456.78',
    });
    expect(firstRow(document, 'AC_MAST').L_BR_DATE).toMatchObject({ $dcType: 'date-time' });
    expect(firstRow(document, 'AC_MAST').AC_CR_DAYS).toEqual({
      $dcType: 'float',
      value: '12.5',
    });
    expect(firstRow(document, 'ENTITY_IMAGE').ENTRY_TIME).toEqual({
      $dcType: 'date-time',
      value: '2025-08-29 12:34:56.789123',
    });
    expect(JSON.stringify(document)).not.toContain('[binary]');
    expect(() => assertCompanyBackupIntegrity(document)).not.toThrow();
  });

  it('preserves exact PostgreSQL JSON text without JavaScript numeric coercion', () => {
    const column: BackupColumnManifest = {
      name: 'payload',
      ordinal: 1,
      dataType: 'json',
      udtName: 'json',
      formattedType: 'json',
      collation: null,
      nullable: false,
      defaultExpression: null,
      generated: false,
      identity: false,
      sequence: null,
    };
    const json = '{"large":123456789012345678901234567890,"duplicate":1,"duplicate":2}';
    const encoded = encodeBackupCell(json, column);
    expect(encoded).toEqual({ $dcType: 'json', value: json });
    expect(decodeBackupCell(encoded, column)).toBe(json);
  });

  it('keeps sequence advancement least-privileged and company-table-only', async () => {
    const [privileges] = await runtime.$queryRawUnsafe<
      Array<{ guarded_execute: boolean; direct_update: boolean }>
    >(
      `SELECT
         has_function_privilege(
           current_user,
           'public.datacare_advance_owned_sequence(regclass,name)',
           'EXECUTE'
         ) AS guarded_execute,
         has_sequence_privilege(current_user,'public."COUNTRY_MAST_row_id_seq"','UPDATE')
           AS direct_update`,
    );
    expect(privileges).toEqual({ guarded_execute: true, direct_update: false });
    await expect(
      runtime.$queryRawUnsafe(
        `SELECT public.datacare_advance_owned_sequence('public."COUNTRY_MAST"'::regclass,'row_id'::name)`,
      ),
    ).rejects.toThrow(/company-scoped/i);
  });

  it('exports every row beyond the former 100000-row ceiling', async () => {
    await seedBase();
    await owner.$executeRawUnsafe(
      `INSERT INTO "DESIGN_MAST"(tenant_id,"CO_CODE","DESIGN_NO","MAIN_USER")
         SELECT $1,$2,'N'||lpad(value::text,6,'0'),'limit'
           FROM generate_series(1,100001) value`,
      TENANT_A,
      COMPANY_A,
    );

    const document = await backupCompany(runtime, TENANT_A, COMPANY_A);
    expect(document.tables.DESIGN_MAST?.rowCount).toBe(100002);
    expect(document.tables.DESIGN_MAST?.rows).toHaveLength(100002);
    expect(document.totals.rows).toBeGreaterThan(100000);
    expect(() => assertCompanyBackupIntegrity(document)).not.toThrow();
  }, 180_000);

  it('round-trips exact rows while preserving the other company, tenant, shared data, and sequences', async () => {
    await seedBase();
    const [priorSequence] = await owner.$queryRawUnsafe<Array<{ last_value: bigint }>>(
      `SELECT last_value FROM "TAG_IMAGE_BLOB_row_id_seq"`,
    );
    const hiddenGlobalRowId = priorSequence!.last_value + 1000n;
    await owner.$executeRawUnsafe(
      `INSERT INTO "ENTITY_IMAGE"(
         row_id,tenant_id,"CO_CODE","LC_CODE","ENTITY_KEY","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES"
       ) VALUES ($1,$2,$3,'00','HIDDEN-GLOBAL-MAX','image/png',1,$4)`,
      hiddenGlobalRowId,
      TENANT_B,
      COMPANY_A,
      Buffer.from([0x77]),
    );
    const source = await backupCompany(runtime, TENANT_A, COMPANY_A);
    const companyTwoBefore = await backupCompany(runtime, TENANT_A, COMPANY_B);
    const otherTenantBefore = await backupCompany(runtime, TENANT_B, COMPANY_A);
    const excludedBefore = await excludedSnapshot(source);
    const originalAccount = firstRow(source, 'AC_MAST');
    const originalImage = firstRow(source, 'ENTITY_IMAGE');

    await owner.$executeRawUnsafe(
      `UPDATE "AC_MAST" SET "AC_NAME"='MUTATED',"AMT_LIMIT"=9
          WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT_A,
      COMPANY_A,
    );
    await owner.$executeRawUnsafe(
      `UPDATE "ENTITY_IMAGE" SET "IMAGE_BYTES"=$3,"IMAGE_SIZE"=1
          WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT_A,
      COMPANY_A,
      Buffer.from([0x99]),
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "DESIGN_MAST"(tenant_id,"CO_CODE","DESIGN_NO","MAIN_USER")
         VALUES ($1,$2,'EXTRA-BEFORE-RESTORE','mutation')`,
      TENANT_A,
      COMPANY_A,
    );
    const beforeRestore = await backupCompany(runtime, TENANT_A, COMPANY_A);

    const result = await restoreCompany(
      runtime,
      { tenantId: TENANT_A, companyCode: COMPANY_A },
      source,
      { mode: 'replace' },
    );
    for (const [name, table] of Object.entries(source.tables)) {
      expect(result.inserted[name], `${name} inserted count`).toBe(table.rowCount);
      expect(result.deleted[name], `${name} deleted count`).toBe(
        beforeRestore.tables[name]?.rowCount,
      );
      expect(result.tableChecksums[name], `${name} result checksum`).toBe(table.checksum);
    }
    expect(result.restored).toBe(source.totals.rows);
    expect(result.cleared).toBe(beforeRestore.totals.rows);

    const restored = await backupCompany(runtime, TENANT_A, COMPANY_A);
    const companyTwoAfter = await backupCompany(runtime, TENANT_A, COMPANY_B);
    const otherTenantAfter = await backupCompany(runtime, TENANT_B, COMPANY_A);
    expect(checksums(restored)).toEqual(checksums(source));
    expect(checksums(companyTwoAfter)).toEqual(checksums(companyTwoBefore));
    expect(checksums(otherTenantAfter)).toEqual(checksums(otherTenantBefore));
    expect(await excludedSnapshot(source)).toEqual(excludedBefore);

    const [account] = await owner.$queryRawUnsafe<
      Array<{ row_id: bigint; name: string; amount: string; business_date: string }>
    >(
      `SELECT row_id,"AC_NAME" AS name,"AMT_LIMIT"::text AS amount,
                "L_BR_DATE"::text AS business_date
           FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT_A,
      COMPANY_A,
    );
    const [image] = await owner.$queryRawUnsafe<
      Array<{ row_id: bigint; bytes: Uint8Array; entry_time: string }>
    >(
      `SELECT row_id,"IMAGE_BYTES" AS bytes,"ENTRY_TIME"::text AS entry_time
         FROM "ENTITY_IMAGE"
        WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT_A,
      COMPANY_A,
    );
    expect(account?.row_id.toString()).toBe((originalAccount.row_id as { value: string }).value);
    expect(account).toMatchObject({
      name: 'Account A01',
      amount: '1234567890123456.78',
      business_date: '2025-08-29',
    });
    expect(image?.row_id.toString()).toBe((originalImage.row_id as { value: string }).value);
    expect(Buffer.from(image?.bytes ?? [])).toEqual(SOURCE_BYTES);
    expect(image?.entry_time).toBe('2025-08-29 12:34:56.789123');

    const [sequenceState] = await owner.$queryRawUnsafe<
      Array<{ maximum: bigint; last_value: bigint; is_called: boolean }>
    >(`SELECT (SELECT COALESCE(MAX(row_id),0)::bigint FROM "ENTITY_IMAGE") AS maximum,
              last_value::bigint AS last_value,
              is_called
         FROM "TAG_IMAGE_BLOB_row_id_seq"`);
    expect(sequenceState!.maximum).toBe(hiddenGlobalRowId);
    expect(sequenceState!.last_value).toBeGreaterThan(sequenceState!.maximum);
    expect(sequenceState!.is_called).toBe(false);
    const [next] = await owner.$queryRawUnsafe<Array<{ row_id: bigint }>>(
      `INSERT INTO "ENTITY_IMAGE"(
           tenant_id,"CO_CODE","LC_CODE","ENTITY_KEY","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES"
         ) VALUES ($1,$2,'00','SEQUENCE-CHECK','image/png',1,$3) RETURNING row_id`,
      TENANT_A,
      COMPANY_A,
      Buffer.from([0x01]),
    );
    expect(next!.row_id).toBeGreaterThan(sequenceState!.maximum);
  }, 180_000);

  it('rejects a tampered checksum before deleting any target row', async () => {
    await seedBase();
    const document = await backupCompany(runtime, TENANT_A, COMPANY_A);
    await installRollbackGuards();
    const tampered = clone(document);
    firstRow(tampered, 'AC_MAST').AC_NAME = 'CHECKSUM-TAMPER';

    await expect(
      restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_A }, tampered),
    ).rejects.toThrow(/checksum/i);
    expect(await sourceGuardState()).toEqual({ name: 'ROLLBACK-GUARD', designs: 2 });
  });

  it('rolls back every delete when a validly sealed row overflows its database type', async () => {
    await seedBase();
    const source = await backupCompany(runtime, TENANT_A, COMPANY_A);
    await installRollbackGuards();
    let invalid = clone(source);
    firstRow(invalid, 'AC_MAST').AMT_LIMIT = {
      $dcType: 'decimal',
      value: '999999999999999999999999999999999999.99',
    };
    invalid = resealCompanyBackupDocument(invalid);
    expect(() => assertCompanyBackupIntegrity(invalid)).not.toThrow();

    await expect(
      restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_A }, invalid),
    ).rejects.toThrow();
    expect(await sourceGuardState()).toEqual({ name: 'ROLLBACK-GUARD', designs: 2 });
  });

  it('rolls back when persisted values do not match the sealed SHA-256 checksum', async () => {
    await seedBase();
    const source = await backupCompany(runtime, TENANT_A, COMPANY_A);
    await installRollbackGuards();
    let normalized = clone(source);
    firstRow(normalized, 'AC_MAST').AMT_LIMIT = {
      $dcType: 'decimal',
      value: '1.230',
    };
    normalized = resealCompanyBackupDocument(normalized);
    expect(() => assertCompanyBackupIntegrity(normalized)).not.toThrow();

    await expect(
      restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_A }, normalized),
    ).rejects.toThrow(/checksum/i);
    expect(await sourceGuardState()).toEqual({ name: 'ROLLBACK-GUARD', designs: 2 });
  });

  it('rolls back the whole replace transaction on a primary-key conflict', async () => {
    await seedBase();
    const source = await backupCompany(runtime, TENANT_A, COMPANY_A);
    const companyTwoBefore = await backupCompany(runtime, TENANT_A, COMPANY_B);
    await installRollbackGuards();
    let conflicting = clone(source);
    const companyTwoRowId = firstRow(companyTwoBefore, 'AC_MAST').row_id;
    if (companyTwoRowId === undefined) throw new Error('company-two AC_MAST row has no row_id');
    firstRow(conflicting, 'AC_MAST').row_id = clone(companyTwoRowId);
    conflicting = resealCompanyBackupDocument(conflicting);
    expect(() => assertCompanyBackupIntegrity(conflicting)).not.toThrow();

    await expect(
      restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_A }, conflicting),
    ).rejects.toThrow(/unique|constraint/i);
    expect(await sourceGuardState()).toEqual({ name: 'ROLLBACK-GUARD', designs: 2 });
    expect(checksums(await backupCompany(runtime, TENANT_A, COMPANY_B))).toEqual(
      checksums(companyTwoBefore),
    );
  });

  it('rejects malformed document shape without a TypeError or database mutation', async () => {
    await seedBase();
    const source = await backupCompany(runtime, TENANT_A, COMPANY_A);
    await installRollbackGuards();

    await expect(
      restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_A }, {}),
    ).rejects.toMatchObject({ name: 'CompanyBackupValidationError' });
    const malformed = clone(source) as unknown as {
      manifest: { tables: Array<{ name: string; triggers: unknown }> };
    };
    malformed.manifest.tables.find((table) => table.name === 'AC_MAST')!.triggers = null;
    await expect(
      restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_A }, malformed),
    ).rejects.toMatchObject({ name: 'CompanyBackupValidationError' });
    expect(await sourceGuardState()).toEqual({ name: 'ROLLBACK-GUARD', designs: 2 });
  });

  it('rejects wrong authenticated tenant or company scope before mutation', async () => {
    await seedBase();
    const source = await backupCompany(runtime, TENANT_A, COMPANY_A);

    await expect(
      restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_B }, source),
    ).rejects.toThrow(/authenticated company/i);
    await expect(
      restoreCompany(runtime, { tenantId: TENANT_B, companyCode: COMPANY_A }, source),
    ).rejects.toThrow(/authenticated tenant/i);
    expect(firstRow(await backupCompany(runtime, TENANT_A, COMPANY_A), 'AC_MAST').AC_NAME).toBe(
      'Account A01',
    );
  });

  it('rejects a self-consistent but non-live schema manifest before deletion', async () => {
    await seedBase();
    const source = await backupCompany(runtime, TENANT_A, COMPANY_A);
    await installRollbackGuards();
    let mismatched = clone(source);
    const account = mismatched.manifest.tables.find((table) => table.name === 'AC_MAST')!;
    const name = account.columns.find((column) => column.name === 'AC_NAME')!;
    name.formattedType = 'character varying(51)';
    mismatched.manifest.fingerprint = schemaFingerprint(mismatched.manifest.tables);
    mismatched = resealCompanyBackupDocument(mismatched);
    expect(() => assertCompanyBackupIntegrity(mismatched)).not.toThrow();

    await expect(
      restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_A }, mismatched),
    ).rejects.toThrow(/live database schema/i);
    expect(await sourceGuardState()).toEqual({ name: 'ROLLBACK-GUARD', designs: 2 });
  });

  it('preflights internal company and external tenant-shared foreign keys before live replacement', async () => {
    const dropFixtures = async (): Promise<void> => {
      await owner.$executeRawUnsafe(`DROP TABLE IF EXISTS "WP02_FK_CHILD" CASCADE`);
      await owner.$executeRawUnsafe(`DROP TABLE IF EXISTS "WP02_FK_PARENT" CASCADE`);
      await owner.$executeRawUnsafe(`DROP TABLE IF EXISTS "WP02_SHARED_PARENT" CASCADE`);
    };
    await dropFixtures();
    try {
      for (const statement of [
        `CREATE TABLE "WP02_FK_PARENT"(
           tenant_id varchar(24) NOT NULL,
           "CO_CODE" varchar(2) NOT NULL,
           id integer NOT NULL,
           payload text,
           PRIMARY KEY(tenant_id,"CO_CODE",id)
         )`,
        `CREATE TABLE "WP02_SHARED_PARENT"(
           tenant_id varchar(24) NOT NULL,
           id integer NOT NULL,
           payload text,
           PRIMARY KEY(tenant_id,id)
         )`,
        `CREATE TABLE "WP02_FK_CHILD"(
           tenant_id varchar(24) NOT NULL,
           "CO_CODE" varchar(2) NOT NULL,
           id integer NOT NULL,
           parent_id integer NOT NULL,
           shared_id integer NOT NULL,
           payload text,
           PRIMARY KEY(tenant_id,"CO_CODE",id),
           CONSTRAINT wp02_internal_fk FOREIGN KEY(tenant_id,"CO_CODE",parent_id)
             REFERENCES "WP02_FK_PARENT"(tenant_id,"CO_CODE",id),
           CONSTRAINT wp02_external_fk FOREIGN KEY(tenant_id,shared_id)
             REFERENCES "WP02_SHARED_PARENT"(tenant_id,id)
         )`,
        `ALTER TABLE "WP02_FK_PARENT" ENABLE ROW LEVEL SECURITY`,
        `ALTER TABLE "WP02_FK_PARENT" FORCE ROW LEVEL SECURITY`,
        `CREATE POLICY tenant_isolation ON "WP02_FK_PARENT"
           USING (tenant_id=current_setting('app.tenant_id',true))
           WITH CHECK (tenant_id=current_setting('app.tenant_id',true))`,
        `ALTER TABLE "WP02_SHARED_PARENT" ENABLE ROW LEVEL SECURITY`,
        `ALTER TABLE "WP02_SHARED_PARENT" FORCE ROW LEVEL SECURITY`,
        `CREATE POLICY tenant_isolation ON "WP02_SHARED_PARENT"
           USING (tenant_id=current_setting('app.tenant_id',true))
           WITH CHECK (tenant_id=current_setting('app.tenant_id',true))`,
        `ALTER TABLE "WP02_FK_CHILD" ENABLE ROW LEVEL SECURITY`,
        `ALTER TABLE "WP02_FK_CHILD" FORCE ROW LEVEL SECURITY`,
        `CREATE POLICY tenant_isolation ON "WP02_FK_CHILD"
           USING (tenant_id=current_setting('app.tenant_id',true))
           WITH CHECK (tenant_id=current_setting('app.tenant_id',true))`,
        `GRANT SELECT,INSERT,UPDATE,DELETE ON
           "WP02_FK_PARENT","WP02_SHARED_PARENT","WP02_FK_CHILD" TO app_user`,
      ])
        await owner.$executeRawUnsafe(statement);
      await seedBase();
      await owner.$executeRawUnsafe(
        `INSERT INTO "WP02_SHARED_PARENT"(tenant_id,id,payload) VALUES ($1,7,'shared')`,
        TENANT_A,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "WP02_FK_PARENT"(tenant_id,"CO_CODE",id,payload)
           VALUES ($1,$2,11,'parent-original')`,
        TENANT_A,
        COMPANY_A,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "WP02_FK_CHILD"(
             tenant_id,"CO_CODE",id,parent_id,shared_id,payload
           ) VALUES ($1,$2,21,11,7,'child-original')`,
        TENANT_A,
        COMPANY_A,
      );
      const source = await backupCompany(runtime, TENANT_A, COMPANY_A);
      expect(
        source.manifest.tables.find((table) => table.name === 'WP02_FK_CHILD')?.dependencies,
      ).toEqual(['WP02_FK_PARENT', 'WP02_SHARED_PARENT']);
      const sharedBefore = await digest('WP02_SHARED_PARENT', 'WHERE tenant_id=$1', TENANT_A);
      await owner.$executeRawUnsafe(
        `UPDATE "WP02_FK_CHILD" SET payload='child-mutated'
            WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        TENANT_A,
        COMPANY_A,
      );

      await restoreCompany(runtime, { tenantId: TENANT_A, companyCode: COMPANY_A }, source);
      const [restored] = await owner.$queryRawUnsafe<Array<{ payload: string }>>(
        `SELECT payload FROM "WP02_FK_CHILD"
            WHERE tenant_id=$1 AND "CO_CODE"=$2 AND id=21`,
        TENANT_A,
        COMPANY_A,
      );
      expect(restored?.payload).toBe('child-original');
      expect(await digest('WP02_SHARED_PARENT', 'WHERE tenant_id=$1', TENANT_A)).toEqual(
        sharedBefore,
      );
    } finally {
      await dropFixtures();
    }
  }, 180_000);
});
