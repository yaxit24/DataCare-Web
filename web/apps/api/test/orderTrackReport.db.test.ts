import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { orderTrackReport } from '../src/modules/reports/orderTagReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'order-track-rpt';
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
  fromDate: '2024-06-01',
  toDate: '2024-06-30',
};

async function clean(): Promise<void> {
  for (const table of [
    'SL_ORD_DETL',
    'SL_ORD_DATA',
    'APR_DETL',
    'BAR_DETL',
    'ITEM_MAST',
    'BOOK_DATA',
    'AC_MAST',
    'EMP_MAST',
  ]) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

databaseDescribe('RP_ORD_TRACK order tracking report parity builder', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MOBILE")
       VALUES ($1,$2,$3,'C001','Customer One','9898000001'),
              ($1,$2,$3,'K001','Karigar One','9898000002')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'RING','Gold Ring','G','01','001')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME")
       VALUES ($1,$2,'E01','Employee One'),($1,$2,'E02','Employee Two')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","DATA_TYPE")
       VALUES ($1,$2,$3,'ORD','Sales Order','SORD','SL ORDER','R')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","EMP_CODE","ADV_AMT","OLD_GL","OLD_SL","FUN_DATE")
       VALUES ($1,$2,$3,$4,'ORD','ORD001','2024-06-10','C001','E01',100,1.25,0.50,'2024-07-01'),
              ($1,$2,$3,$4,'ORD','ORD002','2024-06-11','C001','E02',50,0,0,'2024-07-02'),
              ($1,$2,$3,$4,'ORD','ORD003','2024-06-12','C001','E01',25,0,0,'2024-07-03'),
              ($1,$2,'02',$4,'ORD','ORD004','2024-06-13','C001','E01',10,0,0,'2024-07-04')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_DATE","AC_CODE","IT_CODE","TAG_NO","DESIGN_NO","ITM_SIZE","ITM_REMARK","ITM_GWT","ITM_PCS","DESIGN_ISU","TAG_GEN","TAG_SALE","NET_AMT","ORD_REC_AMT","ITM_TOUCH","ITM_FINE","ITM_COLOR","EMP_CODE","ORD_DEL_DATE","TAG_STK_LESS")
       VALUES ($1,$2,$3,$4,'ORD','ORD001',1,11,'2024-06-10','C001','RING','ORDTAG1','D1','18','Make round',10.5,1,'Y','Y','N',1000,200,92,9.66,'RED','E01','2024-06-20','Y'),
              ($1,$2,$3,$4,'ORD','ORD002',1,21,'2024-06-11','C001','RING','','D2','20','Issue pending',20,2,'N','N','N',2000,0,91,18.2,'BLUE','E02','2024-06-21','N'),
              ($1,$2,$3,$4,'ORD','ORD003',1,31,'2024-06-12','C001','RING','','D3','22','Receive pending',30,3,'Y','N','N',3000,150,90,27,'GREEN','E01','2024-06-22','N'),
              ($1,$2,'02',$4,'ORD','ORD004',1,41,'2024-06-13','C001','RING','ORDTAG4','D4','24','Other location',40,4,'Y','Y','N',4000,0,90,36,'BLACK','E01','2024-06-23','Y')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO","ORNA_REC_DATE")
       VALUES ($1,$2,$3,$4,'APR','APR001',1,'2024-06-14','K001',$4,'ORD','ORD001',1,'2024-06-16')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","TAG_NO","ITM_GWT","ITM_NWT","ORD_YRCD","ORD_DBCD","ORD_NO","ORD_SRNO")
       VALUES ($1,$2,$3,$4,'TAG','TAG001',1,'2024-06-17','TAG001',9.75,9.20,$4,'ORD','ORD001',11)`,
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

  it('matches the desktop sales-pending order tracking grid and joined columns', async () => {
    const report = await orderTrackReport(runtime, scope, {
      status: 'sales-pending',
      onlyOrderTagStock: 'true',
    });
    expect(report.rows).toHaveLength(1);
    expect(report.rows[0]).toMatchObject({
      srNo: 1,
      acCode: 'C001',
      acName: 'Customer One',
      acMobile: '9898000001',
      ordNo: 'ORD001',
      ordDate: '2024-06-10',
      delDate: '2024-06-20',
      itName: 'Gold Ring',
      designNo: 'D1',
      size: '18',
      remark: 'Make round',
      gwt: 10.5,
      pcs: 1,
      designIsu: 'Y',
      karigarName: 'Karigar One',
      karigarIssueDate: '2024-06-14',
      tagGen: 'Y',
      karigarReceiveDate: '2024-06-17',
      tagNo: 'TAG001',
      tagSale: 'N',
      tagGwt: 9.75,
      tagNwt: 9.2,
      ornaReceiveDate: '2024-06-16',
      employeeName: 'Employee One',
      netAmt: 1000,
      ordRecAmt: 200,
      touch: 92,
      fine: 9.66,
      color: 'RED',
      functionDate: '2024-07-01',
      coBook: 'ORD',
      coYear: YEAR,
      lineNo: 1,
      advAmt: 100,
      oldGold: 1.25,
      oldSilver: 0.5,
    });
    expect(report.totals).toMatchObject({ rows: 1, gwt: 10.5, netAmt: 1000, ordRecAmt: 200 });
  });

  it('matches desktop issue/receive/all status filters and header employee filtering', async () => {
    const issue = await orderTrackReport(runtime, scope, { status: 'issue-pending' });
    expect(issue.rows.map((row: any) => row.ordNo)).toEqual(['ORD002']);

    const receive = await orderTrackReport(runtime, scope, { status: 'receive-pending' });
    expect(receive.rows.map((row: any) => row.ordNo)).toEqual(['ORD003']);

    const employee = await orderTrackReport(runtime, scope, { status: 'all', employeeCode: 'E01' });
    expect(employee.rows.map((row: any) => row.ordNo)).toEqual(['ORD001', 'ORD003']);

    const exactOrder = await orderTrackReport(runtime, scope, {
      status: 'all',
      orderNo: 'ORD002',
      designNo: 'D2',
    });
    expect(exactOrder.rows.map((row: any) => row.ordNo)).toEqual(['ORD002']);
  });
});
