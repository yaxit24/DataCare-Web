import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  approvalReport,
  bullionReport,
  karigarReport,
  repairReport,
  vpReport,
} from '../src/modules/reports/reportFamilyReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'report-family-parity';
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

const baseScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  fromDate: '2024-06-01',
  toDate: '2024-06-30',
};

databaseDescribe('RP_ALL report family parity builders', () => {
  beforeEach(async () => {
    await wipe();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA","AC_STATE")
       VALUES ($1,$2,$3,'C001','Surat Customer','Surat','Ring Road','GJ'),
              ($1,$2,$3,'C002','Rajkot Customer','Rajkot','Kalawad','GJ')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold Ring','G','P1','G01'),
              ($1,$2,'SILV','Silver Chain','S','P2','S01')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","DATA_TYPE")
       VALUES ($1,$2,$3,'APR','Approval Book','APR ISU','A'),
              ($1,$2,$3,'KRI','Karigar Issue Book','KARIGAR','A'),
              ($1,$2,$3,'BLS','Bullion Sale Book','BUL SALE','A')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","BOOK_NAME","IT_CODE","TAG_NO","DESIGN_NO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","LBR_AMT","OTH_AMT","NET_AMT","ISU_REC","EMP_CODE","MAIN_USER")
       VALUES ($1,$2,$3,$4,'APR','00001',1,'2024-06-10','C001','APPROVAL ISSUE','GOLD','TAG1','D1',1,10,9,8.7,1000,100,25,1125,'N','E01','USER1'),
              ($1,$2,$3,$4,'APR','00002',1,'2024-06-11','C002','APPROVAL ISSUE','SILV','TAG2','D2',1,20,19,18.5,2000,150,50,2200,'Y','E02','USER2')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "KR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,$4,'KRI','00001','2024-06-12','C001','Karigar One')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "KR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","BOOK_NAME","IT_CODE","TAG_NO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","LBR_AMT","OTH_AMT","NET_AMT","MAIN_USER")
       VALUES ($1,$2,$3,$4,'KRI','00001',1,'2024-06-12','C001','KARIGAR ISSUE','GOLD','K1',1,7,6.5,6.2,700,70,7,777,'KUSER'),
              ($1,$2,$3,$4,'KRI','00002',1,'2024-06-13','C001','KARIGAR RECEIPT','GOLD','K2',1,8,7.5,7.1,800,80,8,888,'KUSER')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "REP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,$4,'REP','00001','2024-06-14','C001','Repair Customer')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "REP_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","BOOK_NAME","IT_CODE","IT_NAME","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","LBR_AMT","OTH_AMT","NET_AMT","REP_ADJ","ISU_ADJ","EMP_CODE","MAIN_USER")
       VALUES ($1,$2,$3,$4,'REP','00001',1,'2024-06-14','C001','CUSTREP RECEIPT','GOLD','Repair Ring',1,5,4.5,4.1,500,50,5,555,'N','N','E01','RUSER'),
              ($1,$2,$3,$4,'REP','00002',1,'2024-06-15','C001','KRREP ISSUE','GOLD','Repair Ring',1,5,4.5,4.1,500,50,5,555,'N','Y','E01','RUSER'),
              ($1,$2,$3,$4,'REP','00003',1,'2024-06-16','C001','KRREP RECEIPT','GOLD','Repair Ring',1,5,4.5,4.1,500,50,5,555,'N','N','E01','RUSER')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "RATE_CUT_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","SL_FINE","SL_ITM_AMT","SL_NET_AMT","VP_AMT","VP_ADJ_AMT","AC_ANGDIYA","EMP_CODE","MAIN_USER")
       VALUES ($1,$2,$3,$4,'215','00001','2024-06-17','C001','VP Customer',9.5,1000,1050,1200,300,'ANG1','E01','VPUSER'),
              ($1,$2,$3,$4,'215','00002','2024-06-18','C002','VP Closed',2.5,400,425,500,500,'ANG2','E02','VPUSER')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "BUL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","INOUT_TYPE","BOOK_NAME","AC_CODE","IT_CODE","ITM_GWT","ITM_NWT","ADJ_WT","ITM_RATE","ITM_AMT","PRM_AMT","TAX_PRC","TOT_AMT","EMP_CODE","MAIN_USER")
       VALUES ($1,$2,$3,$4,'BLS','00001',1,'2024-06-19','O','BUL SALE','C001','GOLD',10,9.8,4,62000,620000,2000,3,640000,'E01','BUSER'),
              ($1,$2,$3,$4,'BLP','00002',1,'2024-06-20','I','BUL PURCHASE','C002','SILV',20,19.5,20,750,15000,0,3,15450,'E02','BUSER')`,
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

  it('runs the Approval Rpt pending mode with party, product, and geography filters', async () => {
    const report = await approvalReport(
      runtime,
      {
        ...baseScope,
        filters: { acCode: 'C001', prCode: 'P1', city: 'Surat', empCode: 'E01' },
      },
      { mode: 'pending' },
    );

    expect(report.rows).toHaveLength(1);
    expect(report.rows[0]).toMatchObject({
      reportType: 'Pending Approval',
      crystalReport: 'AprPan',
      coBook: 'APR',
      vchNo: '00001',
      acName: 'Surat Customer',
      itemName: 'Gold Ring',
      status: 'N',
      netAmount: 1125,
    });
  });

  it('runs Kr Report issue/receipt modes from KR_DETL book names', async () => {
    const receive = await karigarReport(
      runtime,
      { ...baseScope, filters: { grCode: 'G01' } },
      { mode: 'receive' },
    );
    expect(receive.rows.map((r) => [r.mode, r.bookName, r.vchNo])).toEqual([
      ['receive', 'KARIGAR RECEIPT', '00002'],
    ]);
  });

  it('runs Reparing Rpt pending branches using desktop ISU_ADJ predicates', async () => {
    const issuePending = await repairReport(
      runtime,
      { ...baseScope },
      { mode: 'karigar-issue-pending' },
    );
    expect(issuePending.rows.map((r) => [r.bookName, r.vchNo, r.status])).toEqual([
      ['CUSTREP RECEIPT', '00001', 'REP_ADJ=N ISU_ADJ=N'],
    ]);

    const customerPending = await repairReport(
      runtime,
      { ...baseScope },
      { mode: 'customer-issue-pending' },
    );
    expect(customerPending.rows.map((r) => r.vchNo)).toEqual(['00003']);
  });

  it('runs VP Report pending/adjusted modes from RATE_CUT_DATA book 215', async () => {
    const pending = await vpReport(
      runtime,
      { ...baseScope, filters: { grCode: 'ANG1' } },
      { mode: 'vp-pending' },
    );
    expect(pending.rows).toHaveLength(1);
    expect(pending.rows[0]).toMatchObject({
      reportType: 'VP Pending',
      coBook: '215',
      vchNo: '00001',
      vpAmount: 1200,
      vpAdjustedAmount: 300,
      vpPendingAmount: 900,
      angdiyaCode: 'ANG1',
    });

    const adjusted = await vpReport(runtime, { ...baseScope }, { mode: 'angdiya-adjusted' });
    expect(adjusted.rows.map((r) => [r.mode, r.vchNo, r.vpPendingAmount])).toEqual([
      ['angdiya-adjusted', '00002', 0],
    ]);
  });

  it('runs Bul Report sales/purchase pending modes from BUL_DATA', async () => {
    const pending = await bullionReport(
      runtime,
      { ...baseScope, filters: { prCode: 'P1', city: 'Surat' } },
      { mode: 'sales-pending' },
    );
    expect(pending.rows).toHaveLength(1);
    expect(pending.rows[0]).toMatchObject({
      reportType: 'Sales Booking Pending',
      coBook: 'BLS',
      bookName: 'BUL SALE',
      inoutType: 'O',
      itemName: 'Gold Ring',
      grossWt: 10,
      adjustedWt: 4,
      pendingWt: 6,
      totalAmount: 640000,
    });

    const purchasePending = await bullionReport(
      runtime,
      { ...baseScope },
      { mode: 'purchase-pending' },
    );
    expect(purchasePending.rows).toEqual([]);
  });
});
