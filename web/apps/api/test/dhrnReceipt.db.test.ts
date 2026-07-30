import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { deleteDhrn, issueDhrn, receiveDhrn } from '../src/modules/dhrn/dhrn.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * Dhiran (pledge) receipt depth (Phase B). Desktop TR_DHRN_REC.cs:6142-6205 writes the receipt
 * header and 6212-6272 the released-item detail (DHRN_REC_DETL), which the web never wrote.
 * Asserted over the full desktop column set, plus reversal on delete.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'dhrn-receipt-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const ISSUE_BOOK = 'DHI';
const REC_BOOK = 'DHR';
const DAY = '2024-04-10';

const scope = (coBook: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});

databaseDescribe('database-backed dhiran receipt', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'DHRN_REC_DETL',
      'DHRN_REC_DATA',
      'DHRN_ISU_DETL',
      'DHRN_ISU_DATA',
      'DHRN_DATA',
      'AC_DATA',
      'TEMP_BOOK_DATA',
      'SRNO_MAST',
      'BOOK_DATA',
      'AC_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","DHRN_PRC") VALUES ($1,$2,NULL,12)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'DHI','Dhiran Issue','DHIS','DHIRAN ISSUE','O','Y','DHRN_ISU_DATA'),
              ($1,$2,$3,'DHR','Dhiran Receipt','DHRC','DHIRAN RECEIPT','I','Y','DHRN_REC_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'BORR','Pledge Borrower')`,
      TENANT,
      CO,
      LC,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  beforeEach(async () => {
    await cleanup();
    await seed();
  });

  it('persists the desktop receipt header and released-item detail, and reverses both', async () => {
    const issued = await issueDhrn(runtime, {
      scope: scope(ISSUE_BOOK),
      borrowerAc: 'BORR',
      borrowerName: 'Pledge Borrower',
      principal: 50_000,
      intPrc: 12,
      intMonths: 6,
      loanType: 'G',
      vchDate: DAY,
      mainUser: 'dhrn-user',
    } as never);

    const received = await receiveDhrn(runtime, {
      scope: scope(REC_BOOK),
      isuNo: issued.vchNo,
      isuBook: ISSUE_BOOK,
      isuYear: YEAR,
      borrowerAc: 'BORR',
      borrowerName: 'Pledge Borrower',
      principalRepaid: 20_000,
      interest: 3_000,
      intPrc: 12,
      vchDate: DAY,
      mainUser: 'dhrn-user',
      billNo: 'RB-3',
      fromDate: '2024-04-01',
      toDate: '2024-04-10',
      packetNo: 'PKT-1',
      dhrnDate: '2024-04-01',
      loanType: 'G',
      dhrnAdjustAmount: 100,
      advanceDhiranReceipt: 250,
      dhrnMonths: 6,
      interestKasar: 5,
      interestDays: 9,
      interestMonths: 1,
      empCode: 'E01',
      goldAmount: 48_000,
      goldWeight: 7.5,
      vchDesc: 'part release',
      panAdjustAmount: 60,
      adjustInterest: 40,
      adjustDhiran: 30,
      rateCutRate: 6_300,
      rateCutAmount: 12_600,
      rateCutPayAmount: 12_000,
      rateCutOsAmount: 600,
      items: [
        {
          packetNo: 'PKT-1',
          custName: 'Pledge Borrower',
          itCode: 'GOLD1',
          itName: 'Gold Chain',
          pcs: 1,
          grossWt: 8.5,
          otherWt: 0.5,
          netWt: 8,
          touch: 91.6,
          westPct: 1.5,
          fineWt: 7.45,
          rate: 6_300,
          amount: 46_935,
          netAmount: 46_935,
          itType: 'G',
          rateType: 'R',
          itDesc: '22kt gold chain, 8 grams',
          isuSrno: 1,
        },
        { srNo: 2, packetNo: 'PKT-2', itCode: 'GOLD2', pcs: 1, grossWt: 2, netWt: 2 },
      ],
    } as never);

    const vchNo = String(received.vchNo).padStart(5, '0');

    const heads = (await owner.$queryRawUnsafe(
      `SELECT "DHRN_BILL","PACKET_NO","LOAN_TYPE","EMP_CODE","VCH_DESC","DHRN_LIC_NO",
              "USER_UPDATE","USER_DELETE","FROM_DATE"::text from_date,"TO_DATE"::text to_date,
              "DHRN_DATE"::text dhrn_date,"DHRN_ADJ_AMT"::float dhrn_adj,
              "UNCHAK_DHRN_REC"::float unchak,"DHRN_MONTH"::float dhrn_month,
              "KASAR_AMT"::float kasar,"INT_DAY"::float int_day,"INT_MONTH"::float int_month,
              "GOLD_AMT"::float gold_amt,"GOLD_WT"::float gold_wt,"PAN_ADJ_AMT"::float pan_adj,
              "ADJ_INT"::float adj_int,"ADJ_DHRN"::float adj_dhrn,"RCUT_RATE"::float rcut_rate,
              "RCUT_AMT"::float rcut_amt,"RCUT_PAY_AMT"::float rcut_pay,"RCUT_OS_AMT"::float rcut_os
         FROM "DHRN_REC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(heads).toHaveLength(1);
    const h = heads[0]!;
    expect(String(h.DHRN_BILL).trim()).toBe('RB-3');
    expect(String(h.PACKET_NO).trim()).toBe('PKT-1');
    expect(String(h.LOAN_TYPE).trim()).toBe('G');
    expect(String(h.EMP_CODE).trim()).toBe('E01');
    expect(String(h.VCH_DESC).trim()).toBe('part release');
    expect(String(h.DHRN_LIC_NO ?? '').trim()).toBe(''); // desktop literal
    expect(String(h.USER_UPDATE).trim()).toBe('N');
    expect(String(h.USER_DELETE).trim()).toBe('N');
    expect(String(h.from_date)).toContain('2024-04-01');
    expect(String(h.to_date)).toContain('2024-04-10');
    expect(String(h.dhrn_date)).toContain('2024-04-01');
    expect(h.dhrn_adj).toBeCloseTo(100, 2);
    expect(h.unchak).toBeCloseTo(250, 2);
    expect(h.dhrn_month).toBeCloseTo(6, 2);
    expect(h.kasar).toBeCloseTo(5, 2);
    expect(h.int_day).toBeCloseTo(9, 2);
    expect(h.int_month).toBeCloseTo(1, 2);
    expect(h.gold_amt).toBeCloseTo(48_000, 2);
    expect(h.gold_wt).toBeCloseTo(7.5, 2);
    expect(h.pan_adj).toBeCloseTo(60, 2);
    expect(h.adj_int).toBeCloseTo(40, 2);
    expect(h.adj_dhrn).toBeCloseTo(30, 2);
    expect(h.rcut_rate).toBeCloseTo(6_300, 2);
    expect(h.rcut_amt).toBeCloseTo(12_600, 2);
    expect(h.rcut_pay).toBeCloseTo(12_000, 2);
    expect(h.rcut_os).toBeCloseTo(600, 2);

    const dets = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr_no,"OLD_SRNO"::int old_srno,"PACKET_NO","CUST_NAME","IT_CODE",
              "IT_NAME","IT_DESC","IT_TYPE","RATE_TYPE","AC_CODE","ENTRY_TYPE","INOUT_TYPE",
              "ISU_NO","ISU_LC","ISU_DBCD","ISU_SRNO"::int isu_srno,
              "ITM_PCS"::float pcs,"ITM_GWT"::float gwt,"ITM_OTH_WT"::float oth_wt,
              "ITM_NWT"::float nwt,"ITM_TOUCH"::float touch,"ITM_WEST_PRC"::float west,
              "ITM_FINE"::float fine,"ITM_RATE"::float rate,"ITM_AMT"::float amt,
              "NET_AMT"::float net_amt
         FROM "DHRN_REC_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(dets).toHaveLength(2);
    const d = dets[0]!;
    expect(d.sr_no).toBe(1);
    expect(d.old_srno).toBe(1);
    expect(String(d.PACKET_NO).trim()).toBe('PKT-1');
    expect(String(d.CUST_NAME).trim()).toBe('Pledge Borrower');
    expect(String(d.IT_CODE).trim()).toBe('GOLD1');
    expect(String(d.IT_NAME).trim()).toBe('Gold Chain');
    expect(String(d.IT_DESC).trim()).toBe('22kt gold chain, 8 grams');
    expect(String(d.IT_TYPE).trim()).toBe('G');
    expect(String(d.RATE_TYPE).trim()).toBe('R');
    expect(d.pcs).toBe(1);
    expect(d.gwt).toBeCloseTo(8.5, 3);
    expect(d.oth_wt).toBeCloseTo(0.5, 3);
    expect(d.nwt).toBeCloseTo(8, 3);
    expect(d.touch).toBeCloseTo(91.6, 2);
    expect(d.west).toBeCloseTo(1.5, 2);
    expect(d.fine).toBeCloseTo(7.45, 2);
    expect(d.rate).toBeCloseTo(6_300, 2);
    expect(d.amt).toBeCloseTo(46_935, 2);
    expect(d.net_amt).toBeCloseTo(46_935, 2);
    // Header-derived columns come from book/scope, never the request body.
    expect(String(d.AC_CODE).trim()).toBe('BORR');
    expect(String(d.ENTRY_TYPE).trim()).toBe('L');
    expect(String(d.INOUT_TYPE).trim()).toBe('I');
    expect(String(d.ISU_LC).trim()).toBe(LC);
    // ISU_NO defaults to the issue voucher being repaid when the grid does not carry one.
    expect(String(d.ISU_NO).trim()).toBe(String(issued.vchNo).padStart(5, '0'));
    expect(d.isu_srno).toBe(1);
    // An explicit grid serial is honoured rather than renumbered.
    expect(dets[1]!.sr_no).toBe(2);
    expect(String(dets[1]!.IT_CODE).trim()).toBe('GOLD2');

    await deleteDhrn(runtime, {
      scope: scope(REC_BOOK),
      vchNo: received.vchNo,
      book: REC_BOOK,
      headerTable: 'DHRN_REC_DATA',
      vchType: 'DHRC',
      deleteUser: 'deleter',
    });
    const gone = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "DHRN_REC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2) heads,
         (SELECT count(*)::int FROM "DHRN_REC_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2) dets`,
      TENANT,
      vchNo,
    )) as Array<{ heads: number; dets: number }>;
    expect(gone[0]).toEqual({ heads: 0, dets: 0 });
  }, 30_000);

  it('writes no released-item detail when no items are supplied', async () => {
    const issued = await issueDhrn(runtime, {
      scope: scope(ISSUE_BOOK),
      borrowerAc: 'BORR',
      principal: 10_000,
      intPrc: 12,
      vchDate: DAY,
    } as never);
    const received = await receiveDhrn(runtime, {
      scope: scope(REC_BOOK),
      isuNo: issued.vchNo,
      isuBook: ISSUE_BOOK,
      borrowerAc: 'BORR',
      principalRepaid: 1_000,
      interest: 100,
      vchDate: DAY,
    } as never);
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "DHRN_REC_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      String(received.vchNo).padStart(5, '0'),
    )) as Array<{ n: number }>;
    expect(rows[0]!.n).toBe(0);
  }, 30_000);
});
