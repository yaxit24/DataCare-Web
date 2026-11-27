import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import {
  getCompanyIdentity,
  saveCompanyIdentity,
  deleteCompanyIdentity,
} from '../src/modules/masters/companyIdentity.js';
import { purgeDeletedCompanies } from '../src/modules/ops/companyPurge.js';
import { snapshotTenant, diffTenant, tenantTables } from './support/tenantSnapshot.js';
import { createYear } from '../src/modules/masters/year.js';
const tenant = 'wp07-identity-test';
const foreignTenant = 'wp07-identity-foreign';
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
(enabled ? describe : describe.skip)('Company identity and Year Create desktop write sets', () => {
  let db: PrismaClient;
  let runtime: PrismaClient;
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    runtime = new PrismaClient();
    db = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    for (const table of await tenantTables(db))
      await db.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
        tenant,
        foreignTenant,
      );
    await db.$executeRawUnsafe(
      'INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,\'01\',\'SOURCE\')',
      tenant,
    );
    await db.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME",deleted_at) VALUES ($1,'02','FOREIGN SENTINEL',clock_timestamp()-interval '40 days')`,
      foreignTenant,
    );
    await db.$executeRawUnsafe(
      'INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,\'01\',\'00\',\'MAIN\')',
      tenant,
    );
  });
  afterAll(async () => {
    if (!db) return;
    for (const table of await tenantTables(db))
      await db.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
        tenant,
        foreignTenant,
      );
    await runtime.$disconnect();
    await db.$disconnect();
  });
  it('round trips identity, copies the selected master set and refuses stale edits', async () => {
    const saved = await saveCompanyIdentity(
      runtime,
      tenant,
      'TEST',
      {
        CO_CODE: '02',
        CO_NAME: 'SECOND',
        CO_ADD1: 'ROAD',
        BANK_NAME: 'BANK',
        sourceCoCode: '01',
        firstYear: { coYear: '2026-2027' },
      },
      false,
    );
    expect(saved.CO_ADD1).toBe('ROAD');
    expect(saved.BANK_NAME).toBe('BANK');
    const locations = await db.$queryRawUnsafe<any[]>(
      'SELECT "LC_CODE","LC_NAME" FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=\'02\'',
      tenant,
    );
    expect(locations).toEqual([{ LC_CODE: '00', LC_NAME: 'MAIN' }]);
    const years = await db.$queryRawUnsafe<any[]>(
      'SELECT "CO_YEAR","YEAR_MONTH","OLD_METHOD" FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=\'02\'',
      tenant,
    );
    expect(years).toEqual([{ CO_YEAR: '2026-2027', YEAR_MONTH: '04', OLD_METHOD: 'Y' }]);
    const beforeNoOp = await snapshotTenant(db, tenant);
    await saveCompanyIdentity(
      runtime,
      tenant,
      'TEST',
      { ...saved, expectedVersion: saved.version },
      true,
    );
    expect(diffTenant(beforeNoOp, await snapshotTenant(db, tenant))).toEqual({
      added: {},
      removed: {},
    });
    const changed = await saveCompanyIdentity(
      runtime,
      tenant,
      'TEST',
      { ...saved, CO_NAME: 'CHANGED', expectedVersion: saved.version },
      true,
    );
    expect(changed.CO_NAME).toBe('CHANGED');
    await expect(
      saveCompanyIdentity(
        runtime,
        tenant,
        'TEST',
        { ...saved, expectedVersion: saved.version },
        true,
      ),
    ).rejects.toThrow('Company changed');
    expect(await getCompanyIdentity(runtime, 'wp07-foreign', '02')).toBeNull();
  });
  it('rolls back identity when a copy source is unavailable', async () => {
    const before = await snapshotTenant(db, tenant);
    await expect(
      saveCompanyIdentity(
        runtime,
        tenant,
        'TEST',
        {
          CO_CODE: '03',
          CO_NAME: 'ROLLBACK',
          sourceCoCode: '99',
          firstYear: { coYear: '2028-2029' },
        },
        false,
      ),
    ).rejects.toThrow('Source company is unavailable');
    expect(diffTenant(before, await snapshotTenant(db, tenant))).toEqual({
      added: {},
      removed: {},
    });
  });
  it('applies Lite and default deletion refusals', async () => {
    await expect(
      saveCompanyIdentity(runtime, tenant, 'TEST', { CO_CODE: '03', CO_NAME: 'THIRD' }, false, 'L'),
    ).rejects.toThrow('You Cant Creat New Company');
    // MS_COMPANY.cs:6054-6057 runs before the blank check (:6069-6072): a blank code in Lite gets the Lite text.
    await expect(
      saveCompanyIdentity(runtime, tenant, 'TEST', { CO_CODE: '', CO_NAME: '' }, false, 'L'),
    ).rejects.toThrow('You Cant Creat New Company For DataCare Next Lite Version');
    // MS_COMPANY.cs:6059-6067: Basic refuses an add once two companies exist, before the blank check.
    const counted = await db.$queryRawUnsafe<{ n: number }[]>(
      'SELECT count(*)::int n FROM "CO_MAST" WHERE tenant_id=$1 AND deleted_at IS NULL',
      tenant,
    );
    expect(counted[0]?.n).toBeGreaterThanOrEqual(2);
    await expect(
      saveCompanyIdentity(runtime, tenant, 'TEST', { CO_CODE: '', CO_NAME: '' }, false, 'B'),
    ).rejects.toThrow('You Cant Creat More Then 2 New Company For DataCare Next Basic Version...');
    expect(() => deleteCompanyIdentity(runtime, tenant, '01', '')).toThrow(
      'You cant Delete Defoult company...',
    );
  });
  it('derives alternate year from company settings and refuses duplicates', async () => {
    await db.$executeRawUnsafe(
      'UPDATE "CO_MAST" SET "ALTER_YEAR"=\'Y\' WHERE tenant_id=$1 AND "CO_CODE"=\'01\'',
      tenant,
    );
    const result = await createYear(
      runtime,
      { tenantId: tenant, coCode: '01' },
      { coYear: '2027-2028', yearMonth: '07' },
    );
    expect(result.coYear).toBe('202707');
    await expect(
      createYear(
        runtime,
        { tenantId: tenant, coCode: '01' },
        { coYear: '2027-2028', yearMonth: '07' },
      ),
    ).rejects.toThrow('Year Is Already Exist');
  });
  it('applies A/B book effects only to the edited company and preserves unrelated reset flags', async () => {
    await db.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","OPBL_TRFR_BTN") VALUES ($1,'02','N')`,
      tenant,
    );
    await db.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","CO_BOOK","MAIN_BOOK","BOOK_TYPE","RESET_BOOK","TRFR_BOOK")
       VALUES ($1,'02','001','000','R','Y','N'),($1,'02','002','999','T','Y','N'),
              ($1,'02','003','999','R','Y','N'),($1,'01','001','000','R','Y','N')`,
      tenant,
    );
    const current = await getCompanyIdentity(runtime, tenant, '02');
    await saveCompanyIdentity(
      runtime,
      tenant,
      'TEST',
      {
        ...current,
        CO_TYPE: 'A',
        expectedVersion: current.version,
      },
      true,
    );
    const books = await db.$queryRawUnsafe(
      `SELECT "CO_CODE","CO_BOOK","RESET_BOOK","TRFR_BOOK" FROM "BOOK_DATA" WHERE tenant_id=$1 ORDER BY "CO_CODE","CO_BOOK"`,
      tenant,
    );
    expect(books).toEqual([
      { CO_CODE: '01', CO_BOOK: '001', RESET_BOOK: 'Y', TRFR_BOOK: 'N' },
      { CO_CODE: '02', CO_BOOK: '001', RESET_BOOK: 'N', TRFR_BOOK: 'Y' },
      { CO_CODE: '02', CO_BOOK: '002', RESET_BOOK: 'N', TRFR_BOOK: 'Y' },
      { CO_CODE: '02', CO_BOOK: '003', RESET_BOOK: 'Y', TRFR_BOOK: 'Y' },
    ]);
  });
  it('copies default accounts without party identity and never carries balances on Year Create', async () => {
    await db.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_PERSON","DATA_TRFR")
       VALUES ($1,'01','00','00001','CASH','PRIVATE DEFAULT','Y'),
              ($1,'01','00','00101','PARTY','PRIVATE PARTY','Y'),
              ($1,'01','01','00002','BRANCH','PRIVATE BRANCH','Y')`,
      tenant,
    );
    await saveCompanyIdentity(
      runtime,
      tenant,
      'TEST',
      {
        CO_CODE: '04',
        CO_NAME: 'DEFAULT COPY',
        firstYear: { coYear: '2029-2030' },
      },
      false,
    );
    expect(
      await db.$queryRawUnsafe(
        `SELECT "AC_CODE","AC_PERSON","DATA_TRFR" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='04'`,
        tenant,
      ),
    ).toEqual([{ AC_CODE: '00001', AC_PERSON: null, DATA_TRFR: 'N' }]);
    const before = await snapshotTenant(db, tenant);
    await createYear(runtime, { tenantId: tenant, coCode: '04' }, { coYear: '2030-2031' });
    const diff = diffTenant(before, await snapshotTenant(db, tenant));
    expect(Object.keys(diff.added)).toEqual(['YEAR_MAST']);
    expect(diff.removed).toEqual({});
  });
  it('retains rows until thirty days then purges only the deleted company', async () => {
    const row = await getCompanyIdentity(runtime, tenant, '02');
    await deleteCompanyIdentity(runtime, tenant, '02', row.version);
    expect(await getCompanyIdentity(runtime, tenant, '02')).toBeNull();
    expect(await purgeDeletedCompanies(runtime, tenant)).toEqual({ purged: [] });
    await db.$executeRawUnsafe(
      'UPDATE "CO_MAST" SET deleted_at=clock_timestamp()-interval \'31 days\' WHERE tenant_id=$1 AND "CO_CODE"=\'02\'',
      tenant,
    );
    expect(await purgeDeletedCompanies(runtime, tenant)).toEqual({ purged: ['02'] });
    for (const table of ['CO_MAST', 'YEAR_MAST', 'LOCT_MAST'])
      expect(
        await db.$queryRawUnsafe(
          `SELECT 1 FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='02'`,
          tenant,
        ),
      ).toEqual([]);
    expect(await getCompanyIdentity(runtime, tenant, '01')).not.toBeNull();
    expect(
      await db.$queryRawUnsafe(
        `SELECT "CO_NAME" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='02'`,
        foreignTenant,
      ),
    ).toEqual([{ CO_NAME: 'FOREIGN SENTINEL' }]);
  });
});
