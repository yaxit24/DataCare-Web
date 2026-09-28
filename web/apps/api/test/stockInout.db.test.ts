import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { fineFor } from '@datacare/core';
import {
  createStockIn,
  createStockOut,
  deleteStockIn,
  deleteStockOut,
  editStockOut,
  getStockIn,
  getStockOut,
} from '../src/modules/stock/stockInout.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

d('TR_INOUT Stock In/Stock Out lifecycle parity', () => {
  const owner = new PrismaClient({
    datasources: {
      db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' },
    },
  });
  const runtime = new PrismaClient({
    datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
  });
  const tenantId = 'stock-inout-db';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const OUT_BOOK = 'SOU';
  const IN_BOOK = 'SIN';
  const DAY = '2024-06-10';
  const outScope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook: OUT_BOOK } as any;
  const inScope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook: IN_BOOK } as any;

  const TABLES = [
    'ROJ_MEL_DATA',
    'AC_DATA',
    'MAIN_STOCK',
    'BAR_DETL',
    'INOUT_IDTL',
    'INOUT_DETL',
    'INOUT_DATA',
    'TEMP_BOOK_DATA',
    'DELETE_DATA',
    'TAG_STOCK',
    'BOOK_DATA',
    'ITEM_MAST',
    'AC_MAST',
    'CO_SET',
    'YEAR_MAST',
    'LOCT_MAST',
  ];

  const exec = (sql: string, ...p: unknown[]) =>
    withTenant(owner, tenantId, (tx: any) => tx.$executeRawUnsafe(sql, ...p));

  async function clean() {
    for (const table of TABLES) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
    }
  }

  async function seed() {
    await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, tenantId, CO);
    await exec(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
      tenantId,
      CO,
      YEAR,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
                                "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
       VALUES ($1,$2,$3,$4,'Stock Out','OUT','OUTWORD','O','Y','INOUT_DATA','INOUT_DETL'),
              ($1,$2,$3,$5,'Stock In','SIN','INWORD','I','Y','INOUT_DATA','INOUT_DETL')`,
      tenantId,
      CO,
      LC,
      OUT_BOOK,
      IN_BOOK,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold item','G','P1','G01')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE","AC_NAME")
       VALUES ($1,$2,'01','Main','MAINAC','Main Location A/c'),
              ($1,$2,'02','Ring Road','DSTAC','Destination Location A/c'),
              ($1,$2,'03','Workshop','SRCAC','Source Location A/c')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'MAINAC','Main Location A/c'),
              ($1,$2,$3,'DSTAC','Destination Location A/c'),
              ($1,$2,$3,'SRCAC','Source Location A/c')`,
      tenantId,
      CO,
      LC,
    );
  }

  beforeEach(async () => {
    await clean();
    await seed();
  });

  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  const stockOutLine = (overrides: Record<string, unknown> = {}) => ({
    itCode: 'GOLD',
    tagNo: 'N',
    itemLot: 'LOT1',
    designNo: 'D-OUT',
    tblCode: '002',
    itmSize: '22',
    itmStyle: 'ROUND',
    itmColor: 'Y',
    pcs: 2,
    bagWt: 0.1,
    grossWt: 12,
    otherWt: 1,
    netWt: 10,
    ghtWt: 1,
    touch: 91,
    westPct: 1,
    labourPct: 2,
    labourType: 'G',
    labourRate: 50,
    labourAmount: 500,
    otherAmount: 25,
    rate: 7000,
    tagCost: 20,
    mrp: 80000,
    remark: 'branch transfer out',
    karigarName: 'KR01',
    prCode: 'P1',
    rateType: 'F',
    lbrCode: 'LB1',
    designImageId: 'IMG-OUT',
    empIsu: 'N',
    ...overrides,
  });

  it('posts, reads, edits, and deletes Stock Out as OUTWORD rows', async () => {
    const expectedFine = fineFor('sale', { netWt: 10, ghtWt: 1, touch: 91, westPct: 1 });
    expect(expectedFine).toBe(10.12);

    const created = await createStockOut(runtime, {
      scope: outScope,
      vchDate: DAY,
      mainUser: 'stock-user',
      employeeCode: 'E01',
      description: 'transfer to ring road',
      toLcCode: '02',
      lines: [stockOutLine()],
    } as any);
    expect(created).toMatchObject({ vchNo: 1, lines: 1, fine: expectedFine });

    const vchNo = '00001';
    const header = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "BOOK_NAME","VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","TO_LC_CODE","FROM_LC_CODE",
                  "STK_TRFR","TOT_GWT"::float8 AS gwt,"TOT_NWT"::float8 AS nwt,
                  "TOT_FINE"::float8 AS fine,"TOT_LBR"::float8 AS lbr,"TOT_OTH"::float8 AS oth,
                  "TOT_NET_AMT"::float8 AS net,"HD_VCH_NO","MAIN_USER"
             FROM "INOUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          OUT_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(header).toMatchObject({
      BOOK_NAME: 'OUTWORD',
      VCH_TYPE: 'OUT',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'O',
      TO_LC_CODE: '02',
      FROM_LC_CODE: '01',
      STK_TRFR: 'N',
      gwt: 12,
      nwt: 10,
      fine: expectedFine,
      lbr: 500,
      oth: 25,
      MAIN_USER: 'stock-user',
    });
    expect(String(header.HD_VCH_NO)).toBe('00001');

    const detail = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "BOOK_NAME","AC_CODE","TO_LC_CODE","FROM_LC_CODE","ENTRY_TYPE","TAG_NO","ITM_LOT",
                  "DESIGN_NO","TBL_CODE","ITM_SIZE","ITM_STYLE","ITM_COLOR","ITM_FINE"::float8 AS fine,
                  "LBR_AMT"::float8 AS lbr,"OTH_AMT"::float8 AS oth,"ITM_AMT"::float8 AS amount,
                  "KR_NET_WT"::float8 AS kr_nwt,"KR_TOUCH"::float8 AS kr_touch,"KR_FINE"::float8 AS kr_fine,
                  "RATE_TYPE","PR_CODE","LBR_CODE","DESIGN_IMG_ID","EMP_ISU"
             FROM "INOUT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          OUT_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(detail).toMatchObject({
      BOOK_NAME: 'OUTWORD',
      AC_CODE: '02',
      TO_LC_CODE: '02',
      FROM_LC_CODE: '01',
      ENTRY_TYPE: 'O',
      TAG_NO: 'N',
      ITM_LOT: 'LOT1',
      DESIGN_NO: 'D-OUT',
      TBL_CODE: '002',
      ITM_SIZE: '22',
      ITM_STYLE: 'ROUND',
      ITM_COLOR: 'Y',
      fine: expectedFine,
      lbr: 500,
      oth: 25,
      amount: 70840,
      kr_nwt: 10,
      kr_touch: 91,
      kr_fine: expectedFine,
      RATE_TYPE: 'F',
      PR_CODE: 'P1',
      LBR_CODE: 'LB1',
      DESIGN_IMG_ID: 'IMG-OUT',
      EMP_ISU: 'N',
    });

    const stock = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "BOOK_NAME","TR_TYPE","ITM_SIGN","TAG_NO","ITM_LOT","ITM_FINE"::float8 AS fine,
                  "NET_AMT"::float8 AS net
             FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          OUT_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(stock).toMatchObject({
      BOOK_NAME: 'OUTWORD',
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      TAG_NO: 'N',
      ITM_LOT: 'LOT1',
      fine: expectedFine,
      net: 71365,
    });

    const ledger = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "LEDR_KEY","BOOK_NAME","AC_CODE","LD_CODE","SIGN","FINE_WT"::float8 AS fine,"PARTY_AC_CODE"
             FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          OUT_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(ledger).toMatchObject({
      BOOK_NAME: 'OUTWORD',
      AC_CODE: 'DSTAC',
      LD_CODE: '00003',
      SIGN: '-',
      fine: expectedFine,
      PARTY_AC_CODE: 'DSTAC',
    });
    expect(String(ledger.LEDR_KEY)).toMatch(/         101$/);

    const rojmel = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "LEDR_KEY","BOOK_NAME","AC_CODE","LD_CODE","SIGN","ITM_FINE"::float8 AS fine,"IT_CODE"
             FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          OUT_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(rojmel).toMatchObject({
      BOOK_NAME: 'OUTWORD',
      AC_CODE: 'DSTAC',
      LD_CODE: '00003',
      SIGN: '-',
      fine: expectedFine,
      IT_CODE: '',
    });
    expect(String(rojmel.LEDR_KEY)).toMatch(/01         1$/);

    const reopened = (await getStockOut(runtime, outScope, vchNo)) as any;
    expect(reopened).toMatchObject({
      voucherNo: vchNo,
      toLcCode: '02',
      fromLcCode: '01',
      mainUser: 'stock-user',
    });
    expect(reopened.lines[0]).toMatchObject({
      itCode: 'GOLD',
      itemLot: 'LOT1',
      fineWt: expectedFine,
      lbrCode: 'LB1',
      designImageId: 'IMG-OUT',
    });

    await editStockOut(
      runtime,
      {
        scope: outScope,
        vchDate: '2024-06-11',
        mainUser: 'stock-edit',
        toLcCode: '02',
        lines: [
          stockOutLine({ netWt: 8, grossWt: 9, ghtWt: 0, fineWt: 7.5, remark: 'edited out' }),
        ],
      } as any,
      vchNo,
    );
    const afterEdit = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "VCH_DATE"::text AS d,"TOT_FINE"::float8 AS fine,"MAIN_USER" FROM "INOUT_DATA"
             WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          OUT_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(afterEdit).toMatchObject({ d: '2024-06-11', fine: 7.5, MAIN_USER: 'stock-edit' });
    const deleteBefore = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "DELETE_DATA" WHERE tenant_id=$1`,
      tenantId,
    )) as Array<{ n: number }>;
    expect(deleteBefore[0]!.n).toBe(0);

    await deleteStockOut(runtime, { scope: outScope, vchNo, deleteUser: 'deleter' });
    for (const table of [
      'INOUT_DATA',
      'INOUT_DETL',
      'MAIN_STOCK',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'TEMP_BOOK_DATA',
    ]) {
      const rows = (await owner.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "${table}" WHERE tenant_id=$1`,
        tenantId,
      )) as Array<{ n: number }>;
      expect(rows[0]!.n).toBe(0);
    }
    const deleted = (
      (await owner.$queryRawUnsafe(
        `SELECT "VCH_TYPE","BOOK_NAME","VCH_FINE_CR"::float8 AS fine,"DELETE_USER","VCH_DESC"
           FROM "DELETE_DATA" WHERE tenant_id=$1`,
        tenantId,
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(deleted).toMatchObject({
      VCH_TYPE: 'OUT',
      BOOK_NAME: 'OUTWORD',
      fine: 8,
      DELETE_USER: 'deleter',
      VCH_DESC: 'ItCode/GOLD TagNo/N',
    });
  });

  it('posts tagged Stock In as INWORD rows plus BAR_DETL and positive stock', async () => {
    const created = await createStockIn(runtime, {
      scope: inScope,
      vchDate: DAY,
      mainUser: 'stock-in-user',
      employeeCode: 'E02',
      description: 'received from workshop',
      fromLcCode: '03',
      lines: [
        {
          itCode: 'GOLD',
          tagNo: 'TAG-IN-1',
          vchSrno: 77,
          designNo: 'D-IN',
          tblCode: '003',
          itmSize: '18',
          hallmarkId: 'HUIDIN1',
          pcs: 1,
          grossWt: 6,
          netWt: 5,
          touch: 90,
          fineWt: 4.5,
          rate: 6500,
          amount: 29250,
          remark: 'branch transfer in',
          prCode: 'P1',
        },
      ],
    } as any);
    expect(created).toMatchObject({ vchNo: 1, lines: 1, fine: 4.5 });

    const vchNo = '00001';
    const header = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "BOOK_NAME","VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","FROM_LC_CODE","TO_LC_CODE","STK_TRFR"
             FROM "INOUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          IN_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(header).toMatchObject({
      BOOK_NAME: 'INWORD',
      VCH_TYPE: 'SIN',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'I',
      FROM_LC_CODE: '03',
      TO_LC_CODE: '01',
      STK_TRFR: 'Y',
    });

    const bar = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "BOOK_NAME","TAG_NO","VCH_SRNO"::float8 AS vch_srno,"HM_ID","ITM_FINE"::float8 AS fine
             FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          IN_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(bar).toMatchObject({
      BOOK_NAME: 'INWORD',
      TAG_NO: 'TAG-IN-1',
      vch_srno: 77,
      HM_ID: 'HUIDIN1',
      fine: 4.5,
    });

    const stock = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "BOOK_NAME","TR_TYPE","ITM_SIGN","ISR_NO","TAG_NO","VCH_SRNO"::float8 AS vch_srno,
                  "ITM_FINE"::float8 AS fine
             FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          IN_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(stock).toMatchObject({
      BOOK_NAME: 'INWORD',
      TR_TYPE: 'I',
      ITM_SIGN: '+',
      ISR_NO: 2,
      TAG_NO: 'TAG-IN-1',
      vch_srno: 77,
      fine: 4.5,
    });

    const ledger = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "LEDR_KEY","BOOK_NAME","AC_CODE","LD_CODE","SIGN","FINE_WT"::float8 AS fine
             FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          IN_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(ledger).toMatchObject({
      BOOK_NAME: 'INWORD',
      AC_CODE: 'SRCAC',
      LD_CODE: '00008',
      SIGN: '+',
      fine: 4.5,
    });
    expect(String(ledger.LEDR_KEY)).toMatch(/         102$/);

    const rojmel = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "LEDR_KEY","BOOK_NAME","AC_CODE","LD_CODE","SIGN","ITM_FINE"::float8 AS fine
             FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          tenantId,
          IN_BOOK,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(rojmel).toMatchObject({
      BOOK_NAME: 'INWORD',
      AC_CODE: 'SRCAC',
      LD_CODE: '00008',
      SIGN: '+',
      fine: 4.5,
    });
    expect(String(rojmel.LEDR_KEY)).toMatch(/02         1$/);

    const reopened = (await getStockIn(runtime, inScope, vchNo)) as any;
    expect(reopened).toMatchObject({ fromLcCode: '03', toLcCode: '01', stockTransferred: true });
    expect(reopened.lines[0]).toMatchObject({
      tagNo: 'TAG-IN-1',
      vchSrno: 77,
      hallmarkId: 'HUIDIN1',
    });

    await deleteStockIn(runtime, { scope: inScope, vchNo, deleteUser: 'in-delete' });
    const deleted = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
      tenantId,
      IN_BOOK,
    )) as Array<{ n: number }>;
    expect(deleted[0]!.n).toBe(1);
  });

  it('rejects books whose MAIN_BOOK does not match the requested direction', async () => {
    await expect(
      createStockOut(runtime, {
        scope: inScope,
        vchDate: DAY,
        toLcCode: '02',
        lines: [stockOutLine()],
      } as any),
    ).rejects.toThrow(/expected OUTWORD/);
    await expect(
      createStockIn(runtime, {
        scope: outScope,
        vchDate: DAY,
        fromLcCode: '03',
        lines: [stockOutLine()],
      } as any),
    ).rejects.toThrow(/expected INWORD/);
  });
});
