import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  designMoveDetailReport,
  designMoveReport,
} from '../src/modules/reports/designMoveReport.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'design-move-rpt';
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
  for (const table of ['MAIN_STOCK', 'BAR_DETL', 'ITEM_MAST', 'BOOK_DATA', 'AC_MAST']) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, toDate: '2024-06-30' };

databaseDescribe('RP_STK_MOVE Design Move parity builder', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'RING','Gold Ring','G','P1','G01'),
              ($1,$2,'CHN','Silver Chain','S','P2','S01')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK")
       VALUES ($1,$2,$3,'SAL','Sale','SAL','SALE')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'C001','Customer One')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","DESIGN_NO","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_NWT","KR_FINE","AC_CODE")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,'2024-06-10','T1',1,'RING','D100','10',1,5,4.5,4.1,'C001'),
              ($1,$2,$3,$4,'SAL','00002',1,'2024-06-10','T2',1,'RING','D100','11',1,6,5.5,5.1,'C001'),
              ($1,$2,$3,$4,'SAL','00003',1,'2024-06-10','T3',1,'CHN','D200','10',1,7,6.5,6.1,'C001')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,'2024-06-10','T1',1,'RING','+',1,5,4.5,'A'),
              ($1,$2,$3,$4,'SAL','00002',1,'2024-06-10','T2',1,'RING','+',1,6,5.5,'A'),
              ($1,$2,$3,$4,'SAL','00003',1,'2024-06-10','T3',1,'CHN','+',1,7,6.5,'A'),
              ($1,$2,$3,$4,'SAL','00004',1,'2024-06-11','T3',1,'CHN','-',1,7,6.5,'A'),
              ($1,$2,$3,$4,'SAL','00005',1,'2024-07-01','T4',1,'RING','+',1,9,8.5,'A')`,
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

  it('runs Design / Size mode with positive signed tag counts and filters', async () => {
    const report = await designMoveReport(
      runtime,
      { ...scope, filters: { grCode: 'G01' } },
      { mode: 'design' },
    );
    expect(report.rows.map((row: any) => [row.key, row.name, row.size, row.pcs])).toEqual([
      ['D100', 'D100', '10', 1],
      ['D100', 'D100', '11', 1],
    ]);
    expect(report.totals).toMatchObject({ rows: 2, sizes: 2, pcs: 2 });
  });

  it('runs Item / Size mode and the desktop double-click detail query', async () => {
    const item = await designMoveReport(
      runtime,
      { ...scope, filters: { itType: 'G' } },
      { mode: 'item', designNo: 'D100' },
    );
    expect(item.rows.map((row: any) => [row.key, row.name, row.size, row.pcs])).toEqual([
      ['RING', 'Gold Ring', '10', 1],
      ['RING', 'Gold Ring', '11', 1],
    ]);

    const detail = await designMoveDetailReport(
      runtime,
      { ...scope, filters: { itType: 'G' } },
      { mode: 'item', key: 'RING', size: '10', designNo: 'D100' },
    );
    expect(
      detail.rows.map((row: any) => [
        row.book,
        row.vchNo,
        row.tagNo,
        row.itemName,
        row.designNo,
        row.size,
        row.gwt,
      ]),
    ).toEqual([['SAL', '00001', 'T1', 'Gold Ring', 'D100', '10', 5]]);
  });
});
