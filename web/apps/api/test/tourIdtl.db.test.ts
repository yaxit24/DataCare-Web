import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { deleteTour, tourIssue } from '../src/modules/tour/tour.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * Approval/tour sub-detail depth (Phase B). Desktop TR_APR_ISU.cs:6324-6377 writes APR_IDTL from the
 * `DtIdtl` stone grid; the web previously reversed that table but never wrote it. Asserted over the
 * full desktop column set, including the header-derived columns that must come from book/scope.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'tour-idtl-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'APR';
const DAY = '2024-04-10';

const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

databaseDescribe('database-backed approval sub-detail', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'APR_IDTL',
      'APR_DETL',
      'APR_DATA',
      'MAIN_STOCK',
      'BAR_DETL',
      'ITEM_MAST',
      'EMP_MAST',
      'AC_MAST',
      'BOOK_DETL',
      'BOOK_DATA',
      'YEAR_MAST',
      'CO_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  /**
   * TR_APR_ISU.cs:6166-6169 and Ac_Stock.cs:60-72 take VCH_TYPE/BOOK_NAME/direction from the
   * configured APR ISU book. Tagged lines retain the BAR_DETL VCH_SRNO, not the grid row number.
   */
  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","LC_CODE") VALUES ($1,$2,$3)`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
      TENANT,
      CO,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
         "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
       VALUES ($1,$2,$3,$4,'Approval Test','AISU','APR ISU','O','Y','APR_DATA','APR_DETL')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","MAIN_BOOK","BOOK_INOUT","AC_CODE")
       VALUES ($1,$2,$3,$4,1,'APR ISU','O','SALES1')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
       VALUES ($1,$2,$3,'SALES1','Approval Party','10')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,$2,'E01','Employee')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
       VALUES ($1,$2,'GOLD1','Gold','G'),($1,$2,'DIA1','Diamond 1','D'),($1,$2,'DIA2','Diamond 2','D')`,
      TENANT,
      CO,
    );
    for (const [tag, serial] of [
      ['TOUR-TAG-1', 881001],
      ['APR-TAG-1', 881002],
    ] as const) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
           "OLD_SRNO","VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH")
         VALUES ($1,$2,$3,$4,'TOP','09001',$5,$5,$6::date,$7,$8,'GOLD1',1,9,8.5,91.6)`,
        TENANT,
        CO,
        LC,
        YEAR,
        serial - 881000,
        DAY,
        tag,
        serial,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
           "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN")
         VALUES ($1,$2,$3,$4,'TOP','09001',$5,1,$6::date,'GOLD1',$7,$8,'+')`,
        TENANT,
        CO,
        LC,
        YEAR,
        serial - 881000,
        DAY,
        tag,
        serial,
      );
    }
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

  it('writes every desktop APR_IDTL column and reverses it on delete', async () => {
    const created = await tourIssue(runtime, {
      scope,
      vchDate: DAY,
      partyAc: 'SALES1',
      empCode: 'E01',
      mainUser: 'tour-user',
      lines: [
        {
          itCode: 'GOLD1',
          tagNo: 'TOUR-TAG-1',
          vchSrno: 881001,
          pcs: 1,
          grossWt: 8,
          netWt: 7.5,
          touch: 91.6,
          stones: [
            {
              isrNo: 1,
              itCode: 'DIA1',
              dmCode: 'DM1',
              dmName: 'Princess Cut',
              dmSize: '3MM',
              dmSfNo: 'SF-11',
              pcs: 2,
              grossWt: 0.35,
              karigarWt: 0.3,
              conPct: 8,
              rateType: 'C',
              rate: 38_000,
              amount: 13_300,
              lbrRate: 90,
              lbrAmount: 180,
              netAmount: 13_480,
              conWt: 0.028,
              itType: 'D',
            },
            { isrNo: 3, itCode: 'DIA2', dmCode: 'DM2', pcs: 1, grossWt: 0.1, amount: 2_500 },
          ],
        },
      ],
    });
    const vchNo = String(created.vchNo).padStart(5, '0');

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr_no,"ISR_NO"::int isr_no,"IT_CODE","DM_CODE","DM_NAME","DM_SIZE",
              "DM_SFNO","IT_PCS"::float it_pcs,"IT_GWT"::float it_gwt,"KR_WT"::float kr_wt,
              "IT_CON_PRC"::float con_prc,"IT_RATE_TYPE","IT_RATE"::float it_rate,
              "IT_AMT"::float it_amt,"IT_LBR_RATE"::float lbr_rate,"IT_LBR_AMT"::float lbr_amt,
              "IT_NET_AMT"::float net_amt,"IT_CON_WT"::float con_wt,"IT_TYPE",
              "AC_CODE","VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","TAG_NO","MAIN_USER"
         FROM "APR_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "ISR_NO"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(rows).toHaveLength(2);

    const first = rows[0]!;
    expect(first.sr_no).toBe(1);
    expect(first.isr_no).toBe(1);
    expect(String(first.IT_CODE).trim()).toBe('DIA1');
    expect(String(first.DM_CODE).trim()).toBe('DM1');
    expect(String(first.DM_NAME).trim()).toBe('Princess Cut');
    expect(String(first.DM_SIZE).trim()).toBe('3MM');
    expect(String(first.DM_SFNO).trim()).toBe('SF-11');
    expect(first.it_pcs).toBe(2);
    expect(first.it_gwt).toBeCloseTo(0.35, 3);
    expect(first.kr_wt).toBeCloseTo(0.3, 3);
    expect(first.con_prc).toBeCloseTo(8, 2);
    expect(String(first.IT_RATE_TYPE).trim()).toBe('C');
    expect(first.it_rate).toBeCloseTo(38_000, 2);
    expect(first.it_amt).toBeCloseTo(13_300, 2);
    expect(first.lbr_rate).toBeCloseTo(90, 2);
    expect(first.lbr_amt).toBeCloseTo(180, 2);
    expect(first.net_amt).toBeCloseTo(13_480, 2);
    expect(first.con_wt).toBeCloseTo(0.028, 3);
    expect(String(first.IT_TYPE).trim()).toBe('D');
    // Header-derived columns: book/scope, never the request body.
    expect(String(first.AC_CODE).trim()).toBe('SALES1');
    expect(String(first.VCH_TYPE).trim()).toBe('AISU');
    expect(String(first.INOUT_TYPE).trim()).toBe('O');
    expect(String(first.ENTRY_TYPE).trim()).toBe('A');
    expect(String(first.BOOK_NAME).trim()).toBe('APR ISU');
    expect(String(first.TAG_NO).trim()).toBe('TOUR-TAG-1');
    expect(String(first.MAIN_USER).trim()).toBe('tour-user');
    expect(rows[1]!.isr_no).toBe(3);

    await deleteTour(runtime, {
      scope,
      vchNo: created.vchNo,
      expectedVersion: created.version,
    });
    const after = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "APR_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as Array<{ n: number }>;
    expect(after[0]!.n).toBe(0);
  }, 30_000);

  it('writes no sub-detail rows when no stones are supplied', async () => {
    const created = await tourIssue(runtime, {
      scope,
      vchDate: DAY,
      partyAc: 'SALES1',
      empCode: 'E01',
      lines: [{ itCode: 'GOLD1', pcs: 1, grossWt: 5, netWt: 5, touch: 91.6 }],
    });
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "APR_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      String(created.vchNo).padStart(5, '0'),
    )) as Array<{ n: number }>;
    expect(rows[0]!.n).toBe(0);
  }, 30_000);

  // Depth gate (Phase B): the desktop approval line carries the full item/labour/karigar/issue-link
  // grid (TR_APR_ISU.cs:6180-6240), of which the web previously persisted less than half.
  it('persists every desktop approval line column', async () => {
    const created = await tourIssue(runtime, {
      scope,
      vchDate: DAY,
      partyAc: 'SALES1',
      empCode: 'E01',
      mainUser: 'tour-user',
      lines: [
        {
          itCode: 'GOLD1',
          tagNo: 'APR-TAG-1',
          vchSrno: 881002,
          pcs: 1,
          grossWt: 9,
          netWt: 8.5,
          touch: 91.6,
          isuAcName: 'Counter Sales',
          isuAcCode: 'ISUAC',
          metalColor: 'YELLOW',
          tblCode: '001',
          designNo: 'D-11',
          itmSize: 'M',
          huid: 'HUID12345',
          bagWt: 0.3,
          lessWt: 0.2,
          ghtWt: 0.1,
          westPct: 2,
          labourPct: 6,
          labourType: 'G',
          labourRate: 50,
          labourAmount: 425,
          otherAmount: 25,
          rate: 6_400,
          amount: 54_400,
          mrp: 61_000,
          karigarNetWt: 8.4,
          karigarTouch: 91,
          karigarWestPct: 1.5,
          karigarFine: 7.72,
          karigarName: 'KARZ',
          rateType: 'R',
          prCode: 'PR',
          isuYrcd: YEAR,
          isuDbcd: 'SAL',
          isuLcCode: LC,
          designImageId: 'IMG-31',
        },
      ],
    });

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "ISU_AC_NAME","ISU_AC_CODE","MTL_COLOR","TBL_CODE","DESIGN_NO","ITM_SIZE","HM_ID",
              "LBR_TYPE","KR_NAME","RATE_TYPE","PR_CODE","ISU_YRCD","ISU_DBCD","ISU_LC_CODE",
              "DESIGN_IMG_ID","BAG_WT"::float bag,"ITM_OTH_WT"::float oth_wt,
              "ITM_GHT_WT"::float ght_wt,"ITM_WEST_PRC"::float west,"LBR_PRC"::float lbr_prc,
              "LBR_RATE"::float lbr_rate,"LBR_AMT"::float lbr_amt,"OTH_AMT"::float oth_amt,
              "ITM_RATE"::float rate,"ITM_AMT"::float amt,"ITM_MRP"::float mrp,
              "KR_NET_WT"::float kr_nwt,"KR_TOUCH"::float kr_touch,"KR_WEST_PRC"::float kr_west,
              "KR_FINE"::float kr_fine
         FROM "APR_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      TENANT,
      String(created.vchNo).padStart(5, '0'),
    )) as Array<Record<string, any>>;
    expect(rows).toHaveLength(1);
    const d = rows[0]!;
    expect(String(d.ISU_AC_NAME).trim()).toBe('Counter Sales');
    expect(String(d.ISU_AC_CODE).trim()).toBe('ISUAC');
    expect(String(d.MTL_COLOR).trim()).toBe('YELLOW');
    expect(String(d.TBL_CODE).trim()).toBe('001');
    expect(String(d.DESIGN_NO).trim()).toBe('D-11');
    expect(String(d.ITM_SIZE).trim()).toBe('M');
    expect(String(d.HM_ID).trim()).toBe('HUID12345');
    expect(String(d.LBR_TYPE).trim()).toBe('G');
    expect(String(d.KR_NAME).trim()).toBe('KARZ');
    expect(String(d.RATE_TYPE).trim()).toBe('R');
    expect(String(d.PR_CODE).trim()).toBe('PR');
    expect(String(d.ISU_YRCD).trim()).toBe(YEAR);
    expect(String(d.ISU_DBCD).trim()).toBe('SAL');
    expect(String(d.ISU_LC_CODE).trim()).toBe(LC);
    expect(String(d.DESIGN_IMG_ID).trim()).toBe('IMG-31');
    expect(d.bag).toBeCloseTo(0.3, 3);
    expect(d.oth_wt).toBeCloseTo(0.2, 3);
    expect(d.ght_wt).toBeCloseTo(0.1, 3);
    expect(d.west).toBeCloseTo(2, 2);
    expect(d.lbr_prc).toBeCloseTo(6, 2);
    expect(d.lbr_rate).toBeCloseTo(50, 2);
    expect(d.lbr_amt).toBeCloseTo(425, 2);
    expect(d.oth_amt).toBeCloseTo(25, 2);
    expect(d.rate).toBeCloseTo(6_400, 2);
    expect(d.amt).toBeCloseTo(54_400, 2);
    expect(d.mrp).toBeCloseTo(61_000, 2);
    expect(d.kr_nwt).toBeCloseTo(8.4, 2);
    expect(d.kr_touch).toBeCloseTo(91, 2);
    expect(d.kr_west).toBeCloseTo(1.5, 2);
    expect(d.kr_fine).toBeCloseTo(7.72, 2);
  }, 30_000);
});
