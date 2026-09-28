import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { tourReport, tourTagReport } from '../src/modules/reports/tourReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'tour-rpt';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...params: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...params));

async function clean(): Promise<void> {
  for (const table of [
    'APR_DETL',
    'RATE_CUT_ISU',
    'ITEM_MAST',
    'EMP_MAST',
    'AC_MAST',
    'BOOK_DATA',
  ]) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

const scope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  fromDate: '2024-06-01',
  toDate: '2024-06-30',
};

databaseDescribe('RP_TOUR_ZOOM Tour Report and Tour Tag parity builders', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME")
       VALUES ($1,$2,'E01','Employee One'),
              ($1,$2,'E02','Employee Two')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'C001','Retail Customer')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK")
       VALUES ($1,$2,$3,'SL1','Tour Sale Book','TSL','TOUR SALES'),
              ($1,$2,$3,'505','Employee Return','RET','EMP REC')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'RING','Tour Ring','G','P1','G01'),
              ($1,$2,'BANG','Tour Bangle','G','P2','G02')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","BOOK_NAME","AC_CODE","EMP_CODE","IT_CODE","TAG_NO","ITM_PCS","ITM_GWT","ITM_NWT","ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO","OLD_SRNO","EMP_SALE","ISU_REC")
       VALUES
       ($1,$2,$3,$4,'ISU','I001',1,'2024-06-10','EIS','EMP ISU','E01','E01','RING','T001',10,100,95,$4,'SL1','S001',1,NULL,'N','N'),
       ($1,$2,$3,$4,'SL1','S001',1,'2024-06-12','ERC','EMP REC','E01','E01','RING','R001',2,20,19,NULL,NULL,NULL,NULL,1,'N','N'),
       ($1,$2,$3,$4,'ISU','I002',1,'2024-06-13','EIS','EMP ISU','E01','E01','RING','T002',4,40,38,$4,'SL1','S002',1,NULL,'Y','N'),
       ($1,$2,$3,$4,'ISU','I003',1,'2024-06-14','EIS','EMP ISU','E01','E01','RING','T003',3,30,29,$4,'505','R003',1,NULL,'N','Y'),
       ($1,$2,$3,$4,'505','R003',1,'2024-06-15','ERC','EMP REC','E01','E01','RING','RT003',1,10,9,NULL,NULL,NULL,NULL,1,'N','N'),
       ($1,$2,$3,$4,'ISU','I004',1,'2024-06-16','EIS','EMP ISU','E02','E02','BANG','T004',9,90,88,$4,'SL1','S004',1,NULL,'N','N'),
       ($1,$2,$3,$4,'ISU','I005',1,'2024-07-02','EIS','EMP ISU','E01','E01','RING','T005',99,990,980,$4,'SL1','S005',1,NULL,'N','N'),
       ($1,$2,$3,$4,'ISU','N001',1,'2024-05-20','EIS','EMP ISU','E01','E01','RING','N',10,100,95,NULL,NULL,NULL,NULL,NULL,'N','N'),
       ($1,$2,$3,$4,'SL1','N002',1,'2024-05-22','TSL','TOUR SALES','E01','E01','RING','N',2,20,19,NULL,NULL,NULL,NULL,NULL,'N','N'),
       ($1,$2,$3,$4,'505','N003',1,'2024-05-23','ERC','EMP REC','E01','E01','RING','N',1,10,9,NULL,NULL,NULL,NULL,NULL,'N','N'),
       ($1,$2,$3,$4,'ISU','N004',1,'2024-06-04','EIS','EMP ISU','E01','E01','RING','N',5,50,48,NULL,NULL,NULL,NULL,NULL,'N','N'),
       ($1,$2,$3,$4,'SL1','N005',1,'2024-06-05','TSL','TOUR SALES','E01','E01','RING','N',3,30,28,NULL,NULL,NULL,NULL,NULL,'N','N'),
       ($1,$2,$3,$4,'505','N006',1,'2024-06-06','ERC','EMP REC','E01','E01','RING','N',2,20,18,NULL,NULL,NULL,NULL,NULL,'N','N')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "RATE_CUT_ISU"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_DATE","VCH_TYPE","BOOK_NAME","AC_CODE","IT_CODE","TAG_NO","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,$2,$3,$4,'SL1','S001',1,1,'2024-06-11','TSL','TOUR SALES','C001','RING','T001',3,30,28),
              ($1,$2,$3,$4,'SL1','S002',1,1,'2024-06-13','TSL','TOUR SALES','C001','RING','T002',4,40,38),
              ($1,$2,$3,$4,'SL1','S004',1,1,'2024-06-16','TSL','TOUR SALES','C001','BANG','T004',1,10,9)`,
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

  it('matches DGV_TOUR_FILL voucher-wise issue/sale/return/pending totals and filters', async () => {
    const report = await tourReport(
      runtime,
      { ...scope, filters: { prCode: 'P1', grCode: 'G01' } },
      { employeeCode: 'E01' },
    );
    expect(
      report.rows.map((row: any) => [
        row.vchNo,
        row.empCode,
        row.isuPcs,
        row.isuWt,
        row.salePcs,
        row.recPcs,
        row.panPcs,
        row.panWt,
      ]),
    ).toEqual([['I001', 'E01', 10, 100, 3, 2, 5, 50]]);
    expect(report.totals).toMatchObject({
      rows: 1,
      isuPcs: 10,
      isuWt: 100,
      salePcs: 3,
      recPcs: 2,
      panPcs: 5,
      panWt: 50,
    });

    const sales = await tourReport(runtime, scope, { status: 'sales' });
    expect(sales.rows.map((row: any) => [row.vchNo, row.salePcs, row.panPcs])).toEqual([
      ['I002', 4, 0],
    ]);

    const all = await tourReport(
      runtime,
      { ...scope, filters: { prCode: 'P2' } },
      { status: 'all' },
    );
    expect(all.rows.map((row: any) => [row.vchNo, row.empCode])).toEqual([['I004', 'E02']]);
  });

  it('matches Item_Wise_Tour_Stk employee non-tag opening, movement and pending stock', async () => {
    const report = await tourReport(runtime, scope, { mode: 'item-wise', employeeCode: 'E01' });
    expect(
      report.rows.map((row: any) => [
        row.code,
        row.name,
        row.opPcs,
        row.opWt,
        row.isuPcs,
        row.isuWt,
        row.salePcs,
        row.saleWt,
        row.recPcs,
        row.recWt,
        row.panPcs,
        row.panWt,
      ]),
    ).toEqual([['E01', 'Employee One', 7, 70, 5, 50, 3, 30, 2, 20, 7, 70]]);
    expect(report.totals).toMatchObject({
      rows: 1,
      opPcs: 7,
      opWt: 70,
      isuPcs: 5,
      salePcs: 3,
      recPcs: 2,
      panPcs: 7,
      panWt: 70,
    });
  });

  it('matches Tour_Tag_Detl sale and return mapping with pending columns', async () => {
    const sale = await tourTagReport(runtime, scope, { status: 'all', tagNo: 'T001' });
    expect(
      sale.rows.map((row: any) => [
        row.tagNo,
        row.isuNo,
        row.empName,
        row.iPcs,
        row.sPcs,
        row.rPcs,
        row.pPcs,
        row.slParty,
        row.slType,
        row.slVch,
        row.rcVch,
      ]),
    ).toEqual([
      [
        'T001',
        'I001',
        'Employee One',
        10,
        3,
        0,
        7,
        'Retail Customer',
        'Tour Sale Book',
        'S001',
        null,
      ],
    ]);

    const receipt = await tourTagReport(runtime, scope, {
      status: 'return',
      issueYear: YEAR,
      issueBook: 'ISU',
      issueNo: 'I003',
    });
    expect(
      receipt.rows.map((row: any) => [
        row.tagNo,
        row.isuNo,
        row.iPcs,
        row.sPcs,
        row.rPcs,
        row.pPcs,
        row.rcVch,
        row.slVch,
      ]),
    ).toEqual([['T003', 'I003', 3, 0, 1, 2, 'R003', null]]);
  });
});
