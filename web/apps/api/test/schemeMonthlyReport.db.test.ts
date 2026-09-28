import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { schemeMonthlyReport } from '../src/modules/reports/stockLevel.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'scheme-monthly-rpt';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...params: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...params));

const scope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  toDate: '2024-03-31',
};

async function clean(): Promise<void> {
  for (const table of ['AD_DATA', 'AD_OS', 'AD_MEMB']) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

databaseDescribe('RP_STK_LEVEL scheme monthly report parity builder', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "AD_MEMB"(tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME","AC_MOBILE")
       VALUES ($1,$2,$3,'S01','M001','Member One','9000000001'),
              ($1,$2,$3,'S01','M002','Member Two','9000000002'),
              ($1,$2,'02','S01','M003','Other Location','9000000003')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","SCHM_CODE","SCHM_DATE","MEMB_CODE","MEMB_AMT")
       VALUES ($1,$2,$3,$4,'SCH','A001',1,'2024-01-05','S01','2024-01-05','M001',100),
              ($1,$2,$3,$4,'SCH','A002',1,'2024-02-05','S01','2024-02-05','M001',200),
              ($1,$2,$3,$4,'SCH','A003',1,'2024-04-05','S01','2024-04-05','M001',999),
              ($1,$2,$3,$4,'SCH','A004',1,'2024-02-10','S01','2024-02-10','M002',50),
              ($1,$2,$3,$4,'SCH','A005',1,'2024-03-10','S01','2024-03-10','M002',75),
              ($1,$2,'02',$4,'SCH','A006',1,'2024-01-10','S01','2024-01-10','M003',500)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "AD_OS"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","SCHM_CODE","MEMB_CODE","ADJ_AMT","SIGN","OS_TYPE")
       VALUES ($1,$2,$3,$4,'SCH','O001',1,'2024-03-01','S01','M002',100,'+','A'),
              ($1,$2,$3,$4,'SCH','O002',1,'2024-03-02','S01','M002',150,'-','D')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
  });

  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('builds dynamic month columns and excludes closed adjusted members by default', async () => {
    const report = await schemeMonthlyReport(runtime, scope, { schemeCode: 'S01' });
    expect(report.rows).toEqual([
      {
        srNo: 1,
        membCode: 'M001',
        membName: 'Member One',
        mobile: '9000000001',
        '24/01': 100,
        '24/02': 200,
        '24/03': 0,
        total: 300,
        lMonth: '24/02',
      },
    ]);
    expect(report.totals).toEqual({ rows: 1, '24/01': 100, '24/02': 200, '24/03': 0, total: 300 });
  });

  it('includes adjusted/closed members when With Adj Scheme is selected', async () => {
    const report = await schemeMonthlyReport(runtime, scope, {
      schemeCode: 'S01',
      withAdjScheme: 'true',
    });
    expect(
      report.rows.map((row: any) => [
        row.membCode,
        row['24/01'],
        row['24/02'],
        row['24/03'],
        row.total,
        row.lMonth,
      ]),
    ).toEqual([
      ['M001', 100, 200, 0, 300, '24/02'],
      ['M002', 0, 50, 75, 125, '24/03'],
    ]);
    expect(report.totals).toEqual({ rows: 2, '24/01': 100, '24/02': 250, '24/03': 75, total: 425 });
  });
});
