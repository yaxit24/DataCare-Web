import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  deleteBullionSale,
  editBullionSale,
  getBullionSale,
  postBullionSale,
  postRateCut,
} from '../src/modules/sales/rateCut.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

d('bullion sale workflow over RATE_CUT_DATA', () => {
  const prisma = new PrismaClient();
  const tenantId = 'bullion-sale-db';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const saleScope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'BLS' } as any;
  const rateCutScope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'RCT' } as any;

  const TABLES = [
    'RATE_CUT_DATA',
    'RATE_CUT_ISU',
    'RATE_CUT_REC',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'CO_SET',
    'SRNO_MAST',
    'BOOK_DATA',
    'BOOK_DETL',
    'BUL_DATA',
    'DELETE_DATA',
  ];

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const table of TABLES) {
        await tx.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
      }
    });

  beforeEach(async () => {
    await clean();
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","RATE_PAR") VALUES ($1,$2,'G')`,
        tenantId,
        CO,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO")
         VALUES ($1,$2,$3,'0','0')`,
        tenantId,
        CO,
        LC,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
                                  "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
         VALUES ($1,$2,$3,'BLS','Bullion Sale Book','BSALE','BUL WH SALE','O','Y','RATE_CUT_DATA'),
                ($1,$2,$3,'RCT','Rate Cut Book','RCUT','RATE CUT','O','Y','RATE_CUT_DATA')`,
        tenantId,
        CO,
        LC,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE")
         VALUES ($1,$2,$3,'BLS',1,'SALEGOLD'),($1,$2,$3,'BLS',2,'PURCGOLD'),
                ($1,$2,$3,'BLS',3,'CASH'),($1,$2,$3,'BLS',4,'KASAR'),
                ($1,$2,$3,'BLS',6,'LABOUR'),($1,$2,$3,'BLS',11,'OTHER'),
                ($1,$2,$3,'RCT',1,'SALEGOLD'),($1,$2,$3,'RCT',2,'PURCGOLD'),
                ($1,$2,$3,'RCT',3,'CASH'),($1,$2,$3,'RCT',4,'KASAR'),
                ($1,$2,$3,'RCT',6,'LABOUR'),($1,$2,$3,'RCT',11,'OTHER')`,
        tenantId,
        CO,
        LC,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "BUL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
                                "SR_NO","OLD_SRNO","AC_CODE","IT_CODE","IT_TYPE","ITM_GWT",
                                "ADJ_WT","ITM_RATE","MCX_RATE","INOUT_TYPE")
         VALUES ($1,$2,$3,$4,'BUL','00001',1,1,'CUST','GOLD','G',25,0,7100,7200,'I'),
                ($1,$2,$3,$4,'BUL','00002',1,1,'CUST','GOLD','G',25,0,7100,7200,'I')`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });
  });

  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  const adjWt = async (vchNo: string): Promise<number> => {
    const rows = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "ADJ_WT"::float8 AS adj FROM "BUL_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        tenantId,
        vchNo,
      ),
    )) as Array<{ adj: number }>;
    return rows[0]!.adj;
  };

  const header = async (vchNo: number | string): Promise<Record<string, unknown>> => {
    const rows = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "VCH_NO","CO_BOOK","SL_FINE"::float8 AS sl_fine,
                "PR_FINE"::float8 AS pr_fine,"SL_ITM_AMT"::float8 AS sl_amt,
                "PR_ITM_AMT"::float8 AS pr_amt,"BANK_NAME","ADD1","MOBILE"
           FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        tenantId,
        String(vchNo).padStart(5, '0'),
      ),
    )) as Array<Record<string, unknown>>;
    expect(rows).toHaveLength(1);
    return rows[0]!;
  };

  it('posts, reopens, edits and deletes a source-linked bullion sale with issue and receive grids', async () => {
    const created = await postBullionSale(prisma, {
      scope: saleScope,
      vchDate: '2024-06-10',
      acCode: 'CUST',
      acName: 'Bullion Customer',
      add1: 'Line 1',
      mobile: '9876543210',
      bankName: 'Desk Bank',
      convRate: 7100,
      convPct: 91.5,
      lines: [
        {
          itCode: 'GOLD',
          itemName: 'Issue Gold',
          grossWt: 10,
          netWt: 10,
          touch: 100,
          rate: 7000,
          mcxRate: 7200,
          hallmarkFine: 0.5,
          isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '00001', srno: 1 },
        },
      ],
      receivedLines: [
        {
          itCode: 'GOLD',
          itemName: 'Receive Gold',
          grossWt: 4,
          netWt: 4,
          touch: 91,
          rate: 7100,
          adjustWt: 1.5,
          mcxRate: 7150,
          silverFine: 0.25,
          isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '00002', srno: 1 },
        },
      ],
      pay: { cash: 1000 },
      receivedPay: { chq: 500, bankAc: 'CASH' },
    } as any);

    expect(created.vchNo).toBe(1);
    const firstHeader = await header(created.vchNo);
    expect(firstHeader).toMatchObject({
      CO_BOOK: 'BLS',
      BANK_NAME: 'Desk Bank',
      ADD1: 'Line 1',
      MOBILE: '9876543210',
    });
    expect(Number(firstHeader.sl_fine)).toBeCloseTo(10, 3);
    expect(Number(firstHeader.pr_fine)).toBeCloseTo(3.64, 3);
    expect(Number(firstHeader.sl_amt)).toBe(70000);
    expect(Number(firstHeader.pr_amt)).toBe(25844);
    const ledgerRows = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT DISTINCT "VCH_TYPE","BOOK_NAME" FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001'`,
        tenantId,
      ),
    )) as Array<{ VCH_TYPE: string; BOOK_NAME: string }>;
    expect(ledgerRows).toEqual([{ VCH_TYPE: 'BSALE', BOOK_NAME: 'BUL WH SALE' }]);
    expect(await adjWt('00001')).toBeCloseTo(10, 3);
    expect(await adjWt('00002')).toBeCloseTo(5.5, 3);

    const reopened = (await getBullionSale(prisma, saleScope, created.vchNo)) as any;
    expect(reopened.lines).toHaveLength(1);
    expect(reopened.receivedLines).toHaveLength(1);
    expect(reopened.lines[0]).toMatchObject({
      itCode: 'GOLD',
      itemName: 'Issue Gold',
      grossWt: 10,
      netWt: 10,
      mcxRate: 7200,
      hallmarkFine: 0.5,
    });
    expect(reopened.receivedLines[0]).toMatchObject({
      itCode: 'GOLD',
      itemName: 'Receive Gold',
      grossWt: 4,
      netWt: 4,
      adjustWt: 1.5,
      mcxRate: 7150,
      silverFine: 0.25,
    });

    await editBullionSale(
      prisma,
      {
        scope: saleScope,
        vchDate: '2024-06-11',
        acCode: 'CUST',
        acName: 'Bullion Customer',
        lines: [
          {
            itCode: 'GOLD',
            itemName: 'Edited Issue Gold',
            grossWt: 5,
            netWt: 5,
            touch: 100,
            rate: 7000,
            isuRef: { yrcd: YEAR, dbcd: 'BUL', no: '00001', srno: 1 },
          },
        ],
        receivedLines: [],
      } as any,
      created.vchNo,
    );

    expect(await adjWt('00001')).toBeCloseTo(5, 3);
    expect(await adjWt('00002')).toBeCloseTo(0, 3);
    const edited = (await getBullionSale(prisma, saleScope, created.vchNo)) as any;
    expect(edited.lines).toHaveLength(1);
    expect(edited.receivedLines).toHaveLength(0);
    expect(edited.lines[0]).toMatchObject({ itemName: 'Edited Issue Gold', grossWt: 5, netWt: 5 });
    const countsAfterEdit = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT
           (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001') AS headers,
           (SELECT count(*)::int FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "VCH_NO"='00001') AS issue_lines,
           (SELECT count(*)::int FROM "RATE_CUT_REC" WHERE tenant_id=$1 AND "VCH_NO"='00001') AS receive_lines,
           (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001') AS delete_rows`,
        tenantId,
      ),
    )) as Array<{ headers: number; issue_lines: number; receive_lines: number; delete_rows: number }>;
    expect(countsAfterEdit[0]).toEqual({
      headers: 1,
      issue_lines: 1,
      receive_lines: 0,
      delete_rows: 0,
    });

    await deleteBullionSale(prisma, { scope: saleScope, vchNo: created.vchNo, deleteUser: 'deleter' });
    expect(await adjWt('00001')).toBeCloseTo(0, 3);
    expect(await adjWt('00002')).toBeCloseTo(0, 3);
    const finalCounts = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT
           (SELECT count(*)::int FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001') AS headers,
           (SELECT count(*)::int FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "VCH_NO"='00001') AS issue_lines,
           (SELECT count(*)::int FROM "RATE_CUT_REC" WHERE tenant_id=$1 AND "VCH_NO"='00001') AS receive_lines,
           (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001') AS delete_rows`,
        tenantId,
      ),
    )) as Array<{ headers: number; issue_lines: number; receive_lines: number; delete_rows: number }>;
    expect(finalCounts[0]).toEqual({ headers: 0, issue_lines: 0, receive_lines: 0, delete_rows: 1 });
  }, 30_000);

  it('keeps bullion sale books out of the generic rate-cut workflow', async () => {
    await expect(
      postRateCut(prisma, {
        scope: saleScope,
        acCode: 'CUST',
        lines: [{ itCode: 'GOLD', grossWt: 1, netWt: 1, touch: 100, rate: 7000 }],
      } as any),
    ).rejects.toThrow(/use the bullion sale workflow/i);

    await expect(
      postBullionSale(prisma, {
        scope: rateCutScope,
        acCode: 'CUST',
        lines: [{ itCode: 'GOLD', grossWt: 1, netWt: 1, touch: 100, rate: 7000 }],
      } as any),
    ).rejects.toThrow(/use a bullion-sale book/i);
  });
});
