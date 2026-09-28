import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  mfgInoutReport,
  mfgLedgerDetailReport,
  mfgLedgerReport,
  mfgLotIsuRecReport,
} from '../src/modules/reports/manufacturingReports.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'mfg-rpt';
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
  for (const table of ['MFG_DETL', 'MFG_ISU_REC', 'MFG_MAST', 'BOOK_DATA', 'AC_MAST']) {
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

databaseDescribe('RP_MFG_ZOOM manufacturing report parity builders', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'K001','Karigar One'),
              ($1,$2,$3,'K002','Karigar Two'),
              ($1,$2,$3,'C001','Customer One')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","DATA_TYPE")
       VALUES ($1,$2,$3,'GHT','Ghat Issue','GHT','R'),
              ($1,$2,$3,'POL','Polish Receive','POL','R'),
              ($1,$2,$3,'LOS','Loss Process','LOS','R')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "MFG_MAST"(tenant_id,"CO_CODE","SM_MAIN_CODE","SM_CODE","CO_BOOK","BOOK_SNAME","CUR_IN_USE","TRAN_NAME")
       VALUES ($1,$2,'01','01','GHT','GHT','Y','Ghat'),
              ($1,$2,'02','02','POL','POL','Y','Polish'),
              ($1,$2,'03','03','LOS','LOS','Y','Loss')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "MFG_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","BOOK_NAME","KR_CODE","IT_CODE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","KR_MINO_WT","DM_PCS","DM_WT","ITM_GHT_WT","RTN_GHIS","RTN_CHOL")
       VALUES ($1,$2,$3,$4,'GHT','M001',1,'2024-06-10','GHT','Ghat Issue','K001','RING',1,100,5,95,1,2,0.5,3,4,5),
              ($1,$2,$3,$4,'GHT','M002',1,'2024-06-11','GHT','Ghat Issue','K001','RING',1,40,2,38,0.5,1,0.2,1,2,3),
              ($1,$2,$3,$4,'POL','M003',1,'2024-06-12','POL','Polish Receive','K002','RING',1,500,10,490,2,5,1.2,4,5,6),
              ($1,$2,$3,$4,'GHT','M004',1,'2024-07-01','GHT','Out Of Range','K001','RING',1,999,0,999,0,0,0,0,0,0)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await exec(
      `INSERT INTO "MFG_ISU_REC"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","VCH_TIME","VCH_TYPE","BOOK_NAME","AC_CODE","KR_AC_CODE","IT_CODE","LOT_NO","ITM_LOT","ITM_SIGN","IR_TYPE","IR_PCS","IR_WT","ITM_GWT","ITM_NWT","RTN_CHOL","RTN_GHIS","ITM_GHAT","ITM_LOSS")
       VALUES ($1,$2,$3,$4,'GHT','L001',1,1,'2024-06-01','2024-06-01 09:00:00','GHT','Ghat Issue','C001','K001','RING','LOT1','ILOT1','-','I',1,100,100,95,1,2,3,4),
              ($1,$2,$3,$4,'POL','L002',1,1,'2024-06-03','2024-06-03 09:00:00','POL','Polish Receive','C001','K001','RING','LOT1','ILOT1','+','R',1,80,80,78,1,1,0,0),
              ($1,$2,$3,$4,'LOS','L003',1,1,'2024-06-04','2024-06-04 09:00:00','LOS','Loss Process','C001','K001','RING','LOT1','ILOT1','-','L',1,5,5,5,0,0,0,0),
              ($1,$2,$3,$4,'GHT','L004',1,1,'2024-06-05','2024-06-05 09:00:00','GHT','Ghat Issue','C001','K002','RING','LOT2','ILOT2','-','I',1,50,50,49,0,0,0,0)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
  });

  const seedMfgLedgerRows = async () => {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_ADD1","AC_MOBILE","AC_REF_NAME","AC_CITY","AC_KHATA_NO","AC_GR","AC_AREA")
       VALUES ($1,$2,$3,'K003','Ledger Three','Street 3','9990000003','Broker 3','Surat','KH3','MFGGR','AREA3'),
              ($1,$2,$3,'K004','Ledger Zero','Street 4','9990000004','Broker 4','Surat','KH4','MFGGR','AREA4')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `UPDATE "BOOK_DATA"
          SET "MAIN_BOOK"='MFG'
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK" IN ('GHT','POL')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "MFG_ISU_REC"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","VCH_TIME","VCH_TYPE","BOOK_NAME","AC_CODE","KR_AC_CODE","IT_CODE","IT_TYPE","ITM_SIGN","IR_TYPE","IR_PCS","IR_WT","RTN_CHOL","RTN_GHIS","ITM_GHAT","ITM_LOSS","DR_AMT","CR_AMT")
       VALUES ($1,$2,$3,$4,'GHT','L100',1,1,'2024-05-15','2024-05-15 09:00:00','GHT','Ghat Issue','C001','K003','RING','G','+', 'I',1,10,1,2,3,4,20,100),
              ($1,$2,$3,$4,'POL','L101',1,1,'2024-06-05','2024-06-05 09:00:00','POL','Polish Receive','C001','K003','RING','G','-', 'R',1,5,0,0,0,0,30,0),
              ($1,$2,$3,$4,'GHT','L102',1,1,'2024-06-07','2024-06-07 09:00:00','GHT','Ghat Issue','C001','K003','RING','S','-', 'I',1,8,0,0,0,0,0,0),
              ($1,$2,$3,$4,'POL','L103',1,1,'2024-06-10','2024-06-10 09:00:00','POL','Polish Receive','C001','K003','RING','S','+', 'R',1,4,1,0,0,0,0,40),
              ($1,$2,'02',$4,'GHT','L104',1,1,'2024-06-11','2024-06-11 09:00:00','GHT','Ghat Issue','C001','K003','RING','G','+', 'I',1,1,0,0,0,0,0,100),
              ($1,$2,$3,$4,'GHT','L110',1,1,'2024-06-12','2024-06-12 09:00:00','GHT','Ghat Issue','C001','K004','RING','G','+', 'I',1,2,0,0,0,0,10,10),
              ($1,$2,$3,$4,'POL','L111',1,1,'2024-06-13','2024-06-13 09:00:00','POL','Polish Receive','C001','K004','RING','G','-', 'R',1,2,0,0,0,0,0,0)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
  };

  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('matches DGV_MFG_INOUT process totals with date and karigar filters', async () => {
    const report = await mfgInoutReport(runtime, scope, { karigarCode: 'K001' });
    expect(report.rows.map((row: any) => [row.name, row.grWt, row.othWt, row.netWt, row.minoWt, row.dmPcs, row.dmWt, row.ghtWt, row.ghis, row.chol])).toEqual([
      ['Ghat', 140, 7, 133, 1.5, 3, 0.7, 4, 6, 8],
    ]);
    expect(report.totals).toMatchObject({ rows: 1, grWt: 140, othWt: 7, netWt: 133, dmPcs: 3, dmWt: 0.7, ghtWt: 4, ghis: 6, chol: 8 });
  });

  it('matches DGV_DESIGN_FILL lot/process pivot and signed diff balances', async () => {
    const report = await mfgLotIsuRecReport(runtime, scope, { partyCode: 'C001', karigarCode: '', lotNo: 'LOT1' });
    expect(report.rows).toHaveLength(1);
    expect(report.rows[0]).toMatchObject({
      srNo: 1,
      lotNo: 'LOT1',
      date: '2024-06-01',
      GHT: 110,
      POL: 82,
      LOS: 5,
      diffWt: 28,
      isPan: 5,
    });
    expect(report.totals).toMatchObject({ rows: 1, GHT: 110, POL: 82, LOS: 5, diffWt: 28, isPan: 5 });
  });

  it('supports the desktop lot-mode variant that keys the report on ITM_LOT', async () => {
    const report = await mfgLotIsuRecReport(runtime, scope, { useItemLot: 'true', lotNo: 'ILOT1', karigarCode: 'K001' });
    expect(report.rows.map((row: any) => [row.lotNo, row.GHT, row.POL, row.diffWt, row.isPan])).toEqual([
      ['ILOT1', 110, 82, 17, 0],
    ]);
  });

  it('matches RP_MFG_LEDR account summary balances and filters zero rows by default', async () => {
    await seedMfgLedgerRows();
    const report = await mfgLedgerReport(
      runtime,
      { ...scope, toDate: '2024-06-30' },
      { lcCode: LC, acGroup: 'MFGGR', khataNo: 'KH3' },
    );
    expect(report.rows).toEqual([
      {
        srNo: 1,
        acCode: 'K003',
        acName: 'Ledger Three',
        acAdd1: 'Street 3',
        acMobile: '9990000003',
        drAmt: 0,
        crAmt: 90,
        drGold: 0,
        crGold: 15,
        drSilver: 3,
        crSilver: 0,
        acRefBy: 'Broker 3',
        acCity: 'Surat',
        acKhataNo: 'KH3',
      },
    ]);
    expect(report.totals).toMatchObject({ rows: 1, drAmt: 0, crAmt: 90, drGold: 0, crGold: 15, drSilver: 3, crSilver: 0 });

    const withZero = await mfgLedgerReport(
      runtime,
      { ...scope, toDate: '2024-06-30' },
      { lcCode: LC, acGroup: 'MFGGR', includeZero: 'true' },
    );
    expect(withZero.rows.map((row: any) => [row.acCode, row.crAmt, row.crGold, row.drSilver])).toEqual([
      ['K003', 90, 15, 3],
      ['K004', 0, 0, 0],
    ]);
  });

  it('matches RP_MFG_LEDR voucher drill-down with opening and running balances', async () => {
    await seedMfgLedgerRows();
    const report = await mfgLedgerDetailReport(
      runtime,
      { ...scope, fromDate: '2024-06-01', toDate: '2024-06-30' },
      { acCode: 'K003', lcCode: LC },
    );
    expect(report.rows.map((row: any) => [row.bookName, row.vchNo, row.drAmt, row.crAmt, row.balAmt, row.amtCrDr, row.drGold, row.crGold, row.balGold, row.goldCrDr, row.drSilver, row.crSilver, row.balSilver, row.silverCrDr])).toEqual([
      ['Op Balance', null, 0, 80, 80, 'Cr', 0, 20, 20, 'Cr', 0, 0, 0, ''],
      ['Polish Receive', 'L101', 30, 0, 50, 'Cr', 5, 0, 15, 'Cr', 0, 0, 0, ''],
      ['Ghat Issue', 'L102', 0, 0, 50, 'Cr', 0, 0, 15, 'Cr', 8, 0, -8, 'Dr'],
      ['Polish Receive', 'L103', 0, 40, 90, 'Cr', 0, 0, 15, 'Cr', 0, 5, -3, 'Dr'],
    ]);
    expect(report.totals).toMatchObject({
      rows: 4,
      drAmt: 30,
      crAmt: 120,
      balAmt: 90,
      drGold: 5,
      crGold: 20,
      balGold: 15,
      drSilver: 8,
      crSilver: 5,
      balSilver: 3,
    });

    const polOnly = await mfgLedgerDetailReport(
      runtime,
      { ...scope, fromDate: '2024-06-01', toDate: '2024-06-30' },
      { acCode: 'K003', lcCode: LC, coBook: 'POL' },
    );
    expect(polOnly.rows.map((row: any) => row.vchNo)).toEqual(['L101', 'L103']);
  });
});
