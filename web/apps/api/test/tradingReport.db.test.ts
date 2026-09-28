import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { tradingReport } from '../src/modules/reports/tradingReport.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'trading-rpt';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const SL_AC = '00003';
const PR_AC = '00008';
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...params: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...params));

async function clean(): Promise<void> {
  for (const table of ['AC_DATA', 'MAIN_STOCK', 'ITEM_MAST', 'GROUP_MAST', 'BOOK_DATA', 'AC_MAST']) {
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

databaseDescribe('RP_TRADING Trading Report parity builder', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'C001','Sale Party'),
              ($1,$2,$3,'C002','Purchase Party')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK")
       VALUES ($1,$2,$3,'SAL','Sale Book','SAL','SALES'),
              ($1,$2,$3,'PUR','Purchase Book','PUR','PURCHASE'),
              ($1,$2,$3,'WHS','Wholesale Book','WHS','WH SALES')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,$2,'G01','Gold Group',$3,$4)`,
      TENANT,
      CO,
      SL_AC,
      PR_AC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'RING','Gold Ring','G','G01')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","IT_CODE","AC_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_FINE")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,'2024-06-10','RING','C001','S1',1,'-',5),
              ($1,$2,$3,$4,'PUR','00002',1,'2024-06-11','RING','C002','P1',1,'+',4),
              ($1,$2,$3,$4,'WHS','00003',1,'2024-06-12','RING','C001','R1',1,'-',9)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","AC_CODE","LD_CODE","CR_AMT","DR_AMT","FINE_WT","SIGN","FINE_RATE","PARTY_AC_CODE")
       VALUES ($1,$2,$3,$4,'SAL','00001','SAL','2024-06-10',$5,NULL,500,0,0,'+',0,'C001'),
              ($1,$2,$3,$4,'PUR','00002','PUR','2024-06-11',$6,NULL,0,360,0,'-',0,'C002'),
              ($1,$2,$3,$4,'WHS','00003','WHS','2024-06-12','99999',$5,0,200,2,'+',10,'C001'),
              ($1,$2,$3,$4,'WHS','00003','WHS','2024-06-12','99999',$6,150,0,3,'-',10,'C001'),
              ($1,$2,$3,$4,'SAL','00004','SAL','2024-07-01',$5,NULL,999,0,0,'+',0,'C001')`,
      TENANT,
      CO,
      LC,
      YEAR,
      SL_AC,
      PR_AC,
    );
  });

  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('runs All mode with sale and purchase account rows and stock-fine fallback', async () => {
    const report = await tradingReport(runtime, scope, { mode: 'all', salesAc: SL_AC, purchaseAc: PR_AC });
    expect(report.rows.map((row: any) => [row.vchDate, row.slBookCode, row.slPartyName, row.slWt, row.slRate, row.slAmt, row.prBookCode, row.prPartyName, row.prWt, row.prRate, row.prAmt])).toEqual([
      ['2024-06-10', 'SAL', 'Sale Party', 5, 100, 500, null, null, 0, 0, 0],
      ['2024-06-11', null, null, 0, 0, 0, 'PUR', 'Purchase Party', 4, 90, 360],
    ]);
    expect(report.totals).toMatchObject({ rows: 2, slWt: 5, slAmt: 500, prWt: 4, prAmt: 360, diffFine: -1, diffAmount: -140 });
  });

  it('runs Only RateCut and Without RateCut modes with desktop account/book predicates', async () => {
    const only = await tradingReport(runtime, scope, { mode: 'only-ratecut', salesAc: SL_AC, purchaseAc: PR_AC });
    expect(only.rows.map((row: any) => [row.slBookCode, row.slWt, row.slAmt, row.prBookCode, row.prWt, row.prAmt])).toEqual([
      ['WHS', 2, 200, 'WHS', 3, 150],
    ]);

    const without = await tradingReport(runtime, scope, {
      mode: 'without-ratecut',
      salesAc: SL_AC,
      purchaseAc: PR_AC,
      bookCodes: 'PUR',
    });
    expect(without.rows.map((row: any) => [row.slBookCode, row.prBookCode, row.prAmt])).toEqual([
      [null, 'PUR', 360],
    ]);
  });
});
