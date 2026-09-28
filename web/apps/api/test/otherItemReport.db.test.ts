import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { otherItemReport } from '../src/modules/reports/otherItemReport.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'oth-item-report';
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
  for (const table of ['DM_DATA', 'ITEM_MAST', 'AC_MAST']) {
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

databaseDescribe('RP_OTH_DETL other item report parity builder', () => {
  beforeEach(async () => {
    await clean();
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
       VALUES ($1,$2,'DMG','Diamond Gold','G','P1','G01'),
              ($1,$2,'DMS','Diamond Silver','S','P2','S01')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "DM_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","MAIN_SRNO","SR_NO","ISR_NO","VCH_DATE","ENTRY_TYPE","BOOK_NAME","AC_CODE","IT_CODE","DM_CODE","DM_ORIGIN","DM_REMARK","DM_SIZE","DM_COLOR","DM_LOT_NO","DM_PCS","DM_WT","DM_SIGN","DM_RATE","DM_AMT","EMP_CODE","TAG_NO","VCH_SRNO","MAIN_IT_CODE")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,1,1,'2024-06-10','S','Sale','C001','DMG','D1','NAT','Stud in','1.00','EF','L1',2,0.55,'+',1000,550,'E01','T1',11,'GOLD'),
              ($1,$2,$3,$4,'SAL','00002',1,1,1,'2024-06-11','S','Sale','C002','DMS','D2','LAB','Stud out','1.20','GH','L2',1,0.25,'-',800,200,'E02','T2',12,'SILV'),
              ($1,$2,$3,$4,'PUR','00003',1,1,1,'2024-06-12','L','Purchase','C001','DMG','D3','NAT','Loose in','1.10','EF','L3',3,0.75,'+',1200,900,'E01',NULL,NULL,'GOLD'),
              ($1,$2,$3,$4,'SAL','00004',1,1,1,'2024-07-01','S','Sale','C001','DMG','D4','NAT','Outside','1.00','EF','L4',9,9,'+',1,9,'E01',NULL,NULL,'GOLD')`,
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

  it('runs stud in/out modes from DM_DATA ENTRY_TYPE=S and DM_SIGN', async () => {
    const studIn = await otherItemReport(
      runtime,
      { ...scope, filters: { city: 'Surat' } },
      { mode: 'stud-in' },
    );
    expect(
      studIn.rows.map((row: any) => [row.vchNo, row.direction, row.itCode, row.weight, row.amount]),
    ).toEqual([['00001', 'In', 'DMG', 0.55, 550]]);

    const studOut = await otherItemReport(runtime, scope, { mode: 'stud-out', itemCode: 'DMS' });
    expect(studOut.rows.map((row: any) => [row.vchNo, row.direction, row.itCode, row.pcs])).toEqual(
      [['00002', 'Out', 'DMS', 1]],
    );
  });

  it('runs loose modes and enforces the exact formula filter surface', async () => {
    const loose = await otherItemReport(
      runtime,
      { ...scope, filters: { prCode: 'P1', bookCode: 'PUR' } },
      { mode: 'loose-inout' },
    );
    expect(
      loose.rows.map((row: any) => [row.entryType, row.vchNo, row.itCode, row.pcs, row.weight]),
    ).toEqual([['Loose', '00003', 'DMG', 3, 0.75]]);
    expect(loose.totals).toMatchObject({ rows: 1, pcs: 3, weight: 0.75, amount: 900 });

    await expect(
      otherItemReport(runtime, { ...scope, filters: { state: 'GJ' } }, { mode: 'stud-inout' }),
    ).rejects.toThrow(/cannot filter by: state/);
  });
});
