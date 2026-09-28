import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { branchInoutReport } from '../src/modules/reports/branchInoutReport.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'branch-inout-rpt';
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
  for (const table of ['INOUT_DETL', 'ITEM_MAST', 'LOCT_MAST']) {
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

databaseDescribe('RP_LC_INOUT branch in-out report parity builder', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME")
       VALUES ($1,$2,'01','Main'),($1,$2,'02','Ring Road'),($1,$2,'03','Varachha')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold Ring','G','P1','G01'),
              ($1,$2,'SILV','Silver Chain','S','P2','S01')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "INOUT_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME","IT_CODE","TO_LC_CODE","FROM_LC_CODE","ITM_PCS","ITM_GWT")
       VALUES ($1,$2,$3,$4,'OUT','00001',1,'2024-06-10','OUTWORD','GOLD','02',NULL,2,15.5),
              ($1,$2,$3,$4,'OUT','00002',1,'2024-06-10','OUTWORD','SILV','03',NULL,1,5.25),
              ($1,$2,$3,$4,'INW','00003',1,'2024-06-11','INWORD','GOLD',NULL,'02',1,7.75),
              ($1,$2,$3,$4,'OUT','00004',1,'2024-07-01','OUTWORD','GOLD','02',NULL,9,99)`,
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

  it('runs the Outword branch report with desktop grouping and item filters', async () => {
    const report = await branchInoutReport(
      runtime,
      { ...scope, filters: { prCode: 'P1' } },
      { mode: 'out' },
    );
    expect(report.rows).toEqual([
      {
        srNo: 1,
        direction: 'Outword',
        vchDate: '2024-06-10',
        transferLocation: '02',
        transferLocationName: 'Ring Road',
        itemType: 'G',
        pcs: 2,
        gwt: 15.5,
      },
    ]);
    expect(report.totals).toMatchObject({ rows: 1, locations: 1, pcs: 2, gwt: 15.5 });
  });

  it('runs the Inword branch report from FROM_LC_CODE and refuses unsupported party filters', async () => {
    const report = await branchInoutReport(runtime, scope, { mode: 'in' });
    expect(
      report.rows.map((row: any) => [row.direction, row.transferLocation, row.pcs, row.gwt]),
    ).toEqual([['Inword', '02', 1, 7.75]]);
    await expect(
      branchInoutReport(runtime, { ...scope, filters: { acCode: 'C001' } }, { mode: 'in' }),
    ).rejects.toThrow(/cannot filter by: acCode/);
  });
});
