import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { dhrnLoanReport } from '../src/modules/reports/dhrnLoanReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'dhrn-loan-report';
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

databaseDescribe('RP_DHRN_LOAN report family', () => {
  beforeEach(async () => {
    await wipe();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA","AC_REF_CODE")
       VALUES ($1,$2,$3,'C001','Dhiran Customer','Surat','Ring Road','R001'),
              ($1,$2,$3,'C002','Loan Customer','Rajkot','Kalawad','R002')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "DHRN_ISU_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","ENTRY_TYPE","AC_CODE","AC_NAME","DHRN_BILL","DHRN_AMT","DHRN_REC_AMT","INT_AMT","INT_REC_AMT","PACKET_NO","LOAN_TYPE","UNCHAK_DHRN_REC","GOLD_NWT","SILVER_NWT","DHRN_DUE_DATE","MAIN_USER")
       VALUES ($1,$2,$3,$4,'DHI','00001','2024-06-01','D','C001','Dhiran Customer','DB001',1000,0,90,20,'PKT1','A',5,12.500,0,'2024-07-01','CLERK'),
              ($1,$2,$3,$4,'LON','00002','2024-06-05','L','C002','Loan Customer','LB001',2000,0,120,30,'PKT2','A',0,0,3.250,'2024-07-05','OWNER')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "DHRN_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","ENTRY_TYPE","AC_CODE","DHRN_REC_AMT","UNCHAK_DHRN_REC","INT_AMT","INT_REC_AMT","ISU_LC","ISU_YRCD","ISU_DBCD","ISU_NO","LOAN_TYPE")
       VALUES ($1,$2,$3,$4,'REC','90001',1,'2024-06-10','D','C001',250,3,15,5,$3,$4,'DHI','00001','A'),
              ($1,$2,$3,$4,'REC','90002',1,'2024-06-12','L','C002',2000,0,20,10,$3,$4,'LON','00002','A')`,
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

  it('reports Dhiran register rows with computed receipt and outstanding values', async () => {
    const report = await dhrnLoanReport(
      runtime,
      {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        fromDate: '2024-06-01',
        toDate: '2024-06-30',
        filters: { acCode: 'C001', city: 'Surat', area: 'Ring Road' },
      },
      { entryType: 'D', loanType: 'A', mode: 'register', packetNo: 'PKT1', refNo: 'DB001', refAc: 'R001' },
    );

    expect(report.rows).toHaveLength(1);
    expect(report.rows[0]).toMatchObject({
      reportType: 'Dhiran Report',
      mode: 'register',
      coBook: 'DHI',
      vchNo: '00001',
      acName: 'Dhiran Customer',
      packetNo: 'PKT1',
      refNo: 'DB001',
      loanType: 'A',
      principalAmount: 1000,
      receivedAmount: 250,
      uncheckedReceived: 3,
      interestAmount: 15,
      interestReceived: 5,
      outstandingAmount: 750,
      goldWeight: 12.5,
      dueDate: '2024-07-01',
    });
  });

  it('filters pending mode to only rows with remaining principal', async () => {
    const loans = await dhrnLoanReport(
      runtime,
      { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, fromDate: '2024-06-01', toDate: '2024-06-30' },
      { entryType: 'L', loanType: 'A', mode: 'pending' },
    );
    expect(loans.rows).toEqual([]);

    const dhrn = await dhrnLoanReport(
      runtime,
      { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, fromDate: '2024-06-01', toDate: '2024-06-30' },
      { entryType: 'D', loanType: 'A', mode: 'pending' },
    );
    expect(dhrn.rows.map((r) => r.vchNo)).toEqual(['00001']);
  });
});
