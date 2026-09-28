import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { consiDetailReport, consiReport } from '../src/modules/reports/consiReport.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'consi-report';
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
    'ITEM_MAST',
    'AC_MAST',
    'AC_DATA',
    'BOOK_DATA',
    'SL_DATA',
    'PR_DATA',
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

databaseDescribe('RP_CONSI_APR consignment report parity builder', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_ADD1","AC_MOBILE","AC_CITY","AC_AREA")
       VALUES ($1,$2,$3,'C001','Consignment Customer','Ring Road','999','Surat','North'),
              ($1,$2,$3,'L001','Ledger Party','Market','888','Surat','South')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
       VALUES ($1,$2,'GOLD','Gold','G'),($1,$2,'SILV','Silver','S')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME","AC_CODE","IT_CODE","ITM_NWT","ADJ_NWT")
       VALUES ($1,$2,$3,$4,'CON','00001',1,'2024-06-10','CON REC','C001','GOLD',10,4),
              ($1,$2,$3,$4,'CON','00002',1,'2024-06-11','CON REC','C001','SILV',20,5),
              ($1,$2,$3,$4,'CON','00003',1,'2024-07-01','CON REC','C001','GOLD',99,0),
              ($1,$2,$3,$4,'APR','00004',1,'2024-06-10','APPROVAL ISSUE','C001','GOLD',50,0)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK")
       VALUES ($1,$2,$3,'OPN','Opening','OPEN'),($1,$2,$3,'REC','Receipt','RECEIPT')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","LEDR_KEY","AC_CODE","LD_CODE","CR_AMT","DR_AMT","IT_TYPE","SIGN","FINE_WT")
       VALUES ($1,$2,$3,$4,'OPN','00000','2024-05-10','op','C001','L001',100,0,'G','+',3),
              ($1,$2,$3,$4,'REC','00001','2024-06-15','rec','C001','L001',0,40,'G','-',1),
              ($1,$2,$3,$4,'REC','00002','2024-06-16','rec2','C001','L001',25,0,'S','+',2)`,
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

  it('runs the consignment receipt balance summary from APR_DETL', async () => {
    const report = await consiReport(runtime, scope);
    expect(
      report.rows.map((row: any) => [
        row.acCode,
        row.itemType,
        row.recGold,
        row.adjGold,
        row.balGold,
        row.recSilver,
        row.adjSilver,
        row.balSilver,
      ]),
    ).toEqual([
      ['C001', 'G', 10, 4, 6, 0, 0, 0],
      ['C001', 'S', 0, 0, 0, 20, 5, 15],
    ]);
    expect(report.totals).toMatchObject({ rows: 2, parties: 1, balGold: 6, balSilver: 15 });
  });

  it('runs the desktop account-detail drilldown with opening balance and running amount balance', async () => {
    const detail = await consiDetailReport(runtime, scope, 'C001');
    expect(
      detail.rows.map((row: any) => [
        row.bookName,
        row.vchNo,
        row.drAmt,
        row.crAmt,
        row.balAmt,
        row.crDr,
      ]),
    ).toEqual([
      ['Op Balance', null, 0, 100, 100, 'Cr'],
      ['Receipt', '00001', 40, 0, 60, 'Cr'],
      ['Receipt', '00002', 0, 25, 85, 'Cr'],
    ]);
    expect(detail.totals).toMatchObject({ rows: 3, drAmt: 40, crAmt: 125, balAmt: 85 });
  });
});
