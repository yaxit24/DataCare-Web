import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  deleteDataReport,
  pointReport,
  pointReportDetail,
} from '../src/modules/reports/orderTagReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'rp-order-parity';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, toDate: '2024-06-30' };
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...params: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...params));

async function clean(): Promise<void> {
  for (const table of [
    'DELETE_DATA',
    'POINT_DATA',
    'POINT_MEMB',
    'POINT_MAST',
    'BOOK_DATA',
    'AC_MAST',
  ]) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

databaseDescribe('RP_ORDER report parity builders', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","DATA_TYPE")
       VALUES ($1,$2,$3,'SAL','Sales Book','SAL','SALES','A'),
              ($1,$2,$3,'PAY','Payment Book','PAY','PAYMENT','A')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_ADD1","AC_CITY")
       VALUES ($1,$2,$3,'M001','Member One','Ring Road','Surat'),
              ($1,$2,$3,'M002','Member Two','Kalawad','Rajkot')`,
      TENANT,
      CO,
      LC,
    );
  });

  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('runs Delete Data by delete-date range with desktop columns', async () => {
    await exec(
      `INSERT INTO "DELETE_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","DELETE_DATE","BOOK_NAME","AC_CODE","AC_NAME","VCH_VAL_DR","VCH_VAL_CR","FINE_TYPE","VCH_FINE_DR","VCH_FINE_CR","MAIN_USER","DELETE_USER","VCH_DESC")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,'2024-06-05','2024-06-10','Sales','M001','Member One',100,0,'G',1.25,0,'ENTRY','DELETE','Deleted line'),
              ($1,$2,$3,$4,'PAY','00002',1,'2024-07-05','2024-07-10','Payment','M002','Member Two',0,200,'S',0,2.5,'ENTRY','DELETE','Outside range')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );

    const report = await deleteDataReport(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      fromDate: '2024-06-01',
      toDate: '2024-06-30',
    });
    expect(report.rows).toEqual([
      {
        srNo: 1,
        book: 'Sales',
        vchNo: '00001',
        lineSrNo: 1,
        deleteDate: '2024-06-10',
        vchDate: '2024-06-05',
        acName: 'Member One',
        acCode: 'M001',
        drAmt: 100,
        crAmt: 0,
        fineType: 'G',
        drFine: 1.25,
        crFine: 0,
        entryUser: 'ENTRY',
        deleteUser: 'DELETE',
        itemRemark: 'Deleted line',
      },
    ]);
  });

  it('runs Point Report summary and member detail with desktop point arithmetic', async () => {
    await exec(
      `INSERT INTO "POINT_MAST"(tenant_id,"CO_CODE","POINT_CODE","SR_NO","POINT_NAME","POINT_AMT","CUR_IN_USE")
       VALUES ($1,$2,'01',1,'Default',2,'Y')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "POINT_MEMB"(tenant_id,"CO_CODE","POINT_CODE","MEMB_CODE","MEMB_NAME","CARD_NO","MOBILE_NO")
       VALUES ($1,$2,'01','M001','Member One','C001','999'),
              ($1,$2,'01','M002','Member Two','C002','888')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "POINT_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME","POINT_CODE","POINT_TYPE","MEMB_CODE","TOT_AMT","POINT_VAL","TOT_POINT","ITM_SIGN")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,'2024-06-01','Sales','01','S','M001',1000,1,10,'+'),
              ($1,$2,$3,$4,'SAL','00002',1,'2024-06-05','Sales','01','S','M001',500,1,3,'-'),
              ($1,$2,$3,$4,'PAY','00003',1,'2024-06-07','Payment','01','A','M002',100,1,4,'+')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );

    const summary = await pointReport(runtime, scope);
    expect(
      summary.rows.map((row: any) => [
        row.memberCode,
        row.totalPoint,
        row.adjustedPoint,
        row.balancePoint,
      ]),
    ).toEqual([
      ['M001', 10, 3, 7],
      ['M002', 4, 0, 4],
    ]);

    const detail = await pointReportDetail(runtime, scope, 'M001');
    expect(
      detail.rows.map((row: any) => [
        row.book,
        row.vchNo,
        row.totalPoint,
        row.adjustedPoint,
        row.balancePoint,
        row.onePointValue,
        row.pointValue,
      ]),
    ).toEqual([
      ['SAL', '00001', 10, 0, 10, 2, 20],
      ['SAL', '00002', 0, 3, -3, 2, -6],
    ]);
  });
});
