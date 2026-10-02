import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { graphReport } from '../src/modules/reports/graphReport.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'graph-report-rpt';
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
    'MAIN_STOCK',
    'BAR_DETL',
    'AC_DATA',
    'AC_MAST',
    'ITEM_MAST',
    'BOOK_DATA',
    'CO_MAST',
  ]) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

databaseDescribe('RP_GRAPH report parity builder', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE","WORK_TYPE","METAL_TYPE")
       VALUES ($1,$2,'Graph Test Co',$3,'R','G')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","DATA_TYPE")
       VALUES ($1,$2,$3,'S01','Sales','SALE','SALES','R'),
              ($1,$2,$3,'SR1','Sales Return','SRTN','SALES RETURNE','R'),
              ($1,$2,$3,'W01','Wh Sale','WSAL','WH SALES','R'),
              ($1,$2,$3,'P01','Purchase','PURC','PURCHASE','R')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'G001','Gold Ring','G','01','001'),
              ($1,$2,'G002','Gold Chain','G','02','001'),
              ($1,$2,'S001','Silver Ring','S','03','002')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_SRNO","VCH_DATE","IT_CODE","TAG_NO","TR_TYPE","ITM_SIGN","ITM_NWT","NET_AMT","EMP_CODE")
       VALUES ($1,$2,$3,$4,'S01','S001',1,'2024-06-01','G001','T001','S','-',10,1000,'E01'),
              ($1,$2,$3,$4,'SR1','R001',2,'2024-06-02','G001','T002','S','+',2,200,'E01'),
              ($1,$2,$3,$4,'W01','W001',3,'2024-06-15','G001','T003','S','-',5,500,'E02'),
              ($1,$2,$3,$4,'S01','S002',4,'2024-07-01','G002','T004','S','-',3,300,'E02'),
              ($1,$2,$3,$4,'S01','S003',5,'2024-06-03','S001','T005','S','-',7,700,'E03'),
              ($1,$2,'02',$4,'S01','S004',6,'2024-06-04','G001','T006','S','-',9,900,'E04')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_SRNO","VCH_DATE","IT_CODE","TAG_NO","KR_NAME","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'S01','S001',1,'2024-06-01','G001','T001','K01','R'),
              ($1,$2,$3,$4,'W01','W001',3,'2024-06-15','G001','T003','K02','R')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
       VALUES ($1,$2,$3,'E045','Rent','45'),
              ($1,$2,$3,'E046','Salary','46'),
              ($1,$2,$3,'A001','Customer','10')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","AC_CODE","DR_AMT","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'JV','J001','graph-exp-1','2024-06-10','E045',100,'R'),
              ($1,$2,$3,$4,'JV','J002','graph-exp-2','2024-06-11','E046',50,'R'),
              ($1,$2,$3,$4,'JV','J003','graph-exp-3','2024-06-12','A001',999,'R')`,
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

  it('matches Last 30 Day SL desktop defaults from CO_MAST', async () => {
    const report = await graphReport(runtime, scope, { mode: 'last-30-day-sales' });

    expect(report.rows).toEqual([
      { mode: 'last-30-day-sales', code: null, name: '2024-06-01', value: 1000, totAmt: 1000 },
      { mode: 'last-30-day-sales', code: null, name: '2024-06-02', value: -200, totAmt: -200 },
    ]);
    expect(report.totals).toEqual({ rows: 2, value: 800, totAmt: 800 });
  });

  it('matches Product SL weight mode with retail sales less returns', async () => {
    const report = await graphReport(runtime, scope, { mode: 'product-sales', metric: 'weight' });

    expect(report.rows).toEqual([
      { mode: 'product-sales', code: null, name: '01', value: 8, totAmt: 800 },
    ]);
    expect(report.totals).toEqual({ rows: 1, value: 8, totAmt: 800 });
  });

  it('matches Month SL, Employee SL, book type and transaction selectors', async () => {
    const month = await graphReport(runtime, scope, {
      mode: 'month-sales',
      transactionType: 'sales',
    });
    expect(month.rows).toEqual([
      { mode: 'month-sales', code: 6, name: 'Jun', value: 1000, totAmt: 1000 },
    ]);

    const employee = await graphReport(runtime, scope, {
      mode: 'employee-sales',
      bookType: 'all',
      transactionType: 'sales',
    });
    expect(employee.rows).toEqual([
      { mode: 'employee-sales', code: null, name: 'E01', value: 1000, totAmt: 1000 },
      { mode: 'employee-sales', code: null, name: 'E02', value: 500, totAmt: 500 },
    ]);
  });

  it('matches expense day/type chart branches for account groups 45-47', async () => {
    const byDay = await graphReport(runtime, scope, { mode: 'expense-by-day' });
    expect(byDay.rows).toEqual([
      { mode: 'expense-by-day', code: null, name: '6', value: 100, totAmt: 10 },
      { mode: 'expense-by-day', code: null, name: '6', value: 50, totAmt: 11 },
    ]);

    const byType = await graphReport(runtime, scope, { mode: 'expense-by-type' });
    expect(byType.rows).toEqual([
      { mode: 'expense-by-type', code: null, name: '6', value: 100, totAmt: 'Rent' },
      { mode: 'expense-by-type', code: null, name: '6', value: 50, totAmt: 'Salary' },
    ]);
  });

  it('matches Karigar SL for sold tagged stock', async () => {
    const report = await graphReport(runtime, scope, { mode: 'karigar-sales' });

    expect(report.rows).toEqual([
      { mode: 'karigar-sales', code: null, name: 'K01', value: 1000, totAmt: 'Gold Ring' },
      { mode: 'karigar-sales', code: null, name: 'K02', value: 500, totAmt: 'Gold Ring' },
    ]);
    expect(report.totals).toEqual({ rows: 2, value: 1500 });
  });
});
