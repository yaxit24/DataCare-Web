import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { buildBackupFilename } from '../src/modules/ops/backupFilename.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'data-backup-route-db';
const companyCode = '01';
const loginName = 'backup-admin';
const password = 'Data-Backup-Route!2026';
const secret = 'data-backup-route-test-signing-secret-over-thirty-two-chars';
const yearStart =
  new Date().getMonth() + 1 >= 4 ? new Date().getFullYear() : new Date().getFullYear() - 1;
const fiscalYear = `${yearStart}-${yearStart + 1}`;

(enabled ? describe : describe.skip)('Data Backup authenticated download route', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';

  const wipe = async () => {
    await owner.$executeRawUnsafe(`
      DO $backup_route_cleanup$
      DECLARE candidate record;
      BEGIN
        PERFORM set_config('app.allow_repair_purge', 'on', true);
        FOR candidate IN
          SELECT DISTINCT table_name FROM information_schema.columns
           WHERE table_schema='public' AND column_name='tenant_id'
        LOOP
          EXECUTE format('DELETE FROM public.%I WHERE tenant_id=$1', candidate.table_name)
            USING 'data-backup-route-db'::text;
        END LOOP;
      END
      $backup_route_cleanup$;
    `);
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    if (!ownerUrl) throw new Error('MIGRATE_DATABASE_URL is required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, companyCode, { coName: 'Backup Route', lcCode: '01' });
    await owner.$executeRawUnsafe(
      `UPDATE "CO_MAST" SET "CO_TYPE"='R' WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      tenantId,
      companyCode,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(
         tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","PASSWORD_RESET_REQUIRED"
       ) VALUES ($1,$2,$3,$4,'ADMIN','N')`,
      tenantId,
      companyCode,
      loginName,
      await hashPassword(password),
    );
    app = await buildApp({ prisma: runtime, secret, secureCookies: false });
    const login = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: companyCode, lcCode: '01', coYear: fiscalYear, loginName, password },
    });
    expect(login.statusCode, login.body).toBe(200);
    const values = Array.isArray(login.headers['set-cookie'])
      ? login.headers['set-cookie']
      : [login.headers['set-cookie'] ?? ''];
    cookie = values.map((value) => value.split(';', 1)[0]).join('; ');
  }, 60_000);

  afterAll(async () => {
    await app?.close();
    if (owner) await wipe();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('uses session year and persisted type, returns v2 JSON, then records one audit row', async () => {
    const response = await app.inject({ method: 'GET', url: '/backup', headers: { cookie } });
    expect(response.statusCode, response.body).toBe(200);
    const document = response.json();
    expect(document).toMatchObject({
      kind: 'datacare.company-backup',
      version: 2,
      tenant: tenantId,
      company: companyCode,
      source: { tenantId, companyCode },
    });
    const expected = buildBackupFilename({
      fiscalYear,
      companyType: 'R',
      now: new Date(document.generatedAt),
    });
    expect(response.headers['content-disposition']).toBe(`attachment; filename="${expected}"`);

    const rows = await owner.$queryRawUnsafe<
      Array<{ checksum: string; operator: string; count: bigint }>
    >(
      `SELECT min(checksum) checksum,min(operator) operator,count(*)::bigint count
         FROM "company_backup_run" WHERE tenant_id=$1 AND co_code=$2`,
      tenantId,
      companyCode,
    );
    expect(rows).toEqual([{ checksum: document.checksum, operator: loginName, count: 1n }]);
  }, 180_000);
});
