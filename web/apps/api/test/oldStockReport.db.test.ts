import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { oldStockReport } from '../src/modules/reports/oldStockReport.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'old-stock-rpt';
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
  for (const table of ['MAIN_STOCK', 'BAR_DETL', 'ITEM_MAST']) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, toDate: '2024-06-30' };

databaseDescribe('RP_SLPR_ZOOM Old Stock parity builder', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'RING','Gold Ring','G','P1','G01'),
              ($1,$2,'CHN','Gold Chain','G','P1','G01'),
              ($1,$2,'SLV','Silver Item','S','P2','S01')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","STK_DATE","TAG_NO","VCH_SRNO","IT_CODE","KR_NAME")
       VALUES ($1,$2,$3,$4,'OPN','00001',1,'2024-04-10','2024-04-10','T1',1,'RING','K001'),
              ($1,$2,$3,$4,'OPN','00002',1,'2024-05-12','2024-05-12','T2',2,'RING','K001'),
              ($1,$2,$3,$4,'OPN','00003',1,'2024-05-13','2024-05-13','T3',3,'CHN','K002'),
              ($1,$2,$3,$4,'OPN','00004',1,'2024-05-14','2024-05-14','T4',4,'SLV','K001'),
              ($1,$2,'02',$4,'OPN','00005',1,'2024-05-15','2024-05-15','T5',5,'RING','K001'),
              ($1,$2,$3,$4,'OPN','00006',1,'2024-07-01','2024-07-01','T6',6,'RING','K001')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","STK_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_SIGN")
       VALUES ($1,$2,$3,$4,'OPN','00001',1,'2024-04-10','2024-04-10','T1',1,'RING','+'),
              ($1,$2,$3,$4,'OPN','00002',1,'2024-05-12','2024-05-12','T2',2,'RING','+'),
              ($1,$2,$3,$4,'SAL','00007',1,'2024-05-20','2024-05-20','T2',2,'RING','-'),
              ($1,$2,$3,$4,'OPN','00003',1,'2024-05-13','2024-05-13','T3',3,'CHN','+'),
              ($1,$2,$3,$4,'OPN','00004',1,'2024-05-14','2024-05-14','T4',4,'SLV','+'),
              ($1,$2,'02',$4,'OPN','00005',1,'2024-05-15','2024-05-15','T5',5,'RING','+'),
              ($1,$2,$3,$4,'OPN','00006',1,'2024-07-01','2024-07-01','T6',6,'RING','+')`,
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

  it('pivots positive old gold stock by item and stock month like the desktop grid', async () => {
    const report = await oldStockReport(runtime, scope);
    expect(report.rows.map((row: any) => [row.srNo, row.itemCode, row.itemName, row['24/04'], row['24/05'], row.total])).toEqual([
      [1, 'CHN', 'Gold Chain', 0, 1, 1],
      [2, 'RING', 'Gold Ring', 1, 0, 1],
    ]);
    expect(report.totals).toMatchObject({ rows: 2, items: 2, '24/04': 1, '24/05': 1, total: 2 });
  });

  it('honours karigar, location and item-type controls and refuses hidden item dimensions', async () => {
    const byKarigar = await oldStockReport(runtime, scope, { karigarCode: 'K002' });
    expect(byKarigar.rows.map((row: any) => [row.itemCode, row.total])).toEqual([['CHN', 1]]);

    const silver = await oldStockReport(runtime, { ...scope, filters: { itType: 'S' } });
    expect(silver.rows.map((row: any) => [row.itemCode, row.total])).toEqual([['SLV', 1]]);

    await expect(oldStockReport(runtime, { ...scope, filters: { grCode: 'G01' } })).rejects.toThrow(
      /cannot filter by: grCode/,
    );
    await expect(oldStockReport(runtime, { ...scope, filters: { prCode: 'P1' } })).rejects.toThrow(
      /cannot filter by: prCode/,
    );
  });
});
