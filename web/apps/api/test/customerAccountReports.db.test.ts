import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  addressPrintReport,
  lastVisitReport,
} from '../src/modules/reports/customerAccountReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'customer-account-reports';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const table of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('customer/account desktop report ports', () => {
  beforeEach(async () => {
    await wipe();
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","DATA_TYPE")
       VALUES ($1,$2,$3,'SAL','Sales Book','S'),($1,$2,$3,'REC','Receipt Book','S')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_MOBILE","LAST_VISIT","VISIT_TRAN","AC_CITY","AC_ADD1","AC_ADD2","AC_ADD3","AC_AREA","AC_PIN","AC_PHONE","AC_MOBILE2","AC_EMAIL","AC_PERSON","AC_STATE")
       VALUES ($1,$2,$3,'C001','Alpha Buyer','04','9000000001','06/15/2024','SAL','Surat','A1','A2','A3','Ring Road','395001','0261','9000000002','a@example.test','Owner','24'),
              ($1,$2,$3,'C002','Beta Buyer','05','9000000003','','','Rajkot','B1','','','Kalawad','360001','','','b@example.test','Manager','24'),
              ($1,$2,$3,'V001','Vendor Outside','01','9000000004','06/18/2024','REC','Surat','V1','','','Ring Road','395002','','','','','24')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","DR_AMT","CR_AMT")
       VALUES ($1,$2,$3,$4,'REC','00002','2024-06-20','C002',0,100)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('reports Last Visit from stored AC_MAST fields with latest AC_DATA fallback', async () => {
    const report = await lastVisitReport(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
      fromDate: '2024-06-01',
      toDate: '2024-06-30',
    });

    expect(report.rows.map((r) => r.acCode)).toEqual(['C002', 'C001']);
    expect(report.rows[0]).toMatchObject({
      acName: 'Beta Buyer',
      lastVisit: '2024-06-20',
      lastTran: 'Receipt Book',
      city: 'Rajkot',
      area: 'Kalawad',
    });
    expect(report.rows[1]).toMatchObject({
      acName: 'Alpha Buyer',
      lastVisit: '2024-06-15',
      lastTran: 'Sales Book',
      acGroup: '04',
    });
    expect(report.rows.some((r) => r.acCode === 'V001')).toBe(false);
  });

  it('reports address labels from AC_MAST with city/area filters honoured', async () => {
    const report = await addressPrintReport(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      filters: { city: 'Surat', area: 'Ring Road' },
    });

    expect(report.rows.map((r) => r.acCode)).toEqual(['C001', 'V001']);
    expect(report.rows[0]).toMatchObject({
      acName: 'Alpha Buyer',
      address1: 'A1',
      address2: 'A2',
      address3: 'A3',
      pin: '395001',
      mobile: '9000000001',
      contactPerson: 'Owner',
      state: '24',
    });
  });
});
