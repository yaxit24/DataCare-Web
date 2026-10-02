import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { userWorkReport } from '../src/modules/reports/userAuditReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'user-work-report';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const table of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('RP_USER User Report parity', () => {
  beforeEach(async () => {
    await wipe();
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","DATA_TYPE")
       VALUES ($1,$2,$3,'SAL','Sales Book','SAL','SALES','S'),($1,$2,$3,'MEM','Scheme Book','MEM','MEMB ENTRY','S')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MOBILE","AC_CITY")
       VALUES ($1,$2,$3,'C001','Alpha Buyer','9000000001','Surat')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TYPE","AC_CODE","PARTY_AC_CODE","DR_AMT","CR_AMT","IT_TYPE","SIGN","FINE_WT","MAIN_USER")
       VALUES ($1,$2,$3,$4,'SAL','00001','2024-06-10','SAL','C001','C001',500,0,'G','-',1.250,'CLERK'),
              ($1,$2,$3,$4,'SAL','00001','2024-06-10','SAL','C001','C001',0,100,'S','+',2.500,'CLERK')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","BOOK_NAME","AC_CODE","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","GHT_PRC","ITM_FINE","ITM_RATE","ITM_AMT","LBR_RATE","LBR_AMT","OTH_AMT","MAIN_USER")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,'2024-06-10','SAL','SALES','C001','G001',2,10.500,9.750,91.6,8.925,6000,1200,250,50,5,'CLERK')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","TAX_AMT","CASH_AMT","CHQ_AMT","UPI_AMT","CARD_AMT","ADV_AMT","OLD_GL_AMT","OLD_SL_AMT","SCHM_AMT","KASAR_AMT","DISC_AMT","CASH_PAID")
       VALUES ($1,$2,$3,$4,'SAL','00001','2024-06-10','C001',36,400,250,150,75,20,30,40,50,3,2,10)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('builds the desktop user transaction grid from voucher, stock, ledger and payment sources', async () => {
    const report = await userWorkReport(
      runtime,
      {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        fromDate: '2024-06-01',
        toDate: '2024-06-30',
        filters: { acCode: 'C001', bookCode: 'SAL' },
      },
      { userName: 'CLERK', itemCodes: 'G001' },
    );

    expect(report.rows).toHaveLength(1);
    expect(report.rows[0]).toMatchObject({
      user: 'CLERK',
      book: 'SAL',
      vchDate: '2024-06-10',
      vchNo: '00001',
      acName: 'Alpha Buyer',
      itCode: 'G001',
      pcs: 2,
      gWt: 10.5,
      nWt: 9.75,
      ghtPercent: 91.6,
      fine: 8.925,
      rate: 6000,
      itemAmount: 1200,
      labourRate: 250,
      labourAmount: 50,
      otherAmount: 5,
      drAmount: 500,
      crAmount: 100,
      drFine: 1.25,
      crSilver: 2.5,
      tax: 36,
      cash: 400,
      bank: 250,
      upiAmount: 150,
      card: 75,
      orderAdjust: 20,
      oldGoldAmount: 30,
      oldSilverAmount: 40,
      schemeAdjust: 50,
      kasar: 5,
      cashPaid: 10,
      mobile: '9000000001',
      acCode: 'C001',
      coBook: 'SAL',
      mainBook: 'SALES',
    });
  });

  it('uses the desktop item checklist semantics when item codes are supplied', async () => {
    const report = await userWorkReport(
      runtime,
      {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        fromDate: '2024-06-01',
        toDate: '2024-06-30',
      },
      { itemCodes: 'NOPE' },
    );

    expect(report.rows).toEqual([]);
  });
});
