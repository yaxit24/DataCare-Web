import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { fineFor } from '@datacare/core';
import {
  createOldItemSale,
  deleteOldItemSale,
  editOldItemSale,
  getOldItemSale,
  receiveKarigar,
} from '../src/modules/manufacturing/karigar.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

d('old item sales workflow over KR_DATA/KR_DETL', () => {
  const owner = new PrismaClient({
    datasources: {
      db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' },
    },
  });
  const runtime = new PrismaClient({
    datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
  });
  const tenantId = 'old-item-sales-db';
  const CO = '01';
  const LC = '00';
  const YEAR = '2024-2025';
  const OLD_BOOK = 'OIS';
  const KR_BOOK = '052';
  const PARTY = 'CUST001';
  const PURC_AC = '00008';
  const scope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook: OLD_BOOK } as any;
  const karigarScope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook: KR_BOOK } as any;

  const TABLES = [
    'ROJ_MEL_DATA',
    'AC_DATA',
    'MAIN_STOCK',
    'BAR_DETL',
    'KR_IDTL',
    'KR_DETL',
    'KR_DATA',
    'TEMP_BOOK_DATA',
    'DELETE_DATA',
    'BOOK_DETL',
    'BOOK_DATA',
    'ITEM_MAST',
    'GROUP_MAST',
    'AC_MAST',
    'CO_SET_NEW',
    'CO_SET',
    'YEAR_MAST',
    'LOCT_MAST',
    'CO_MAST',
  ];

  const exec = (sql: string, ...p: unknown[]) =>
    withTenant(owner, tenantId, (tx: any) => tx.$executeRawUnsafe(sql, ...p));

  async function clean() {
    for (const table of TABLES) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
    }
  }

  async function seed() {
    await exec(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Old Item Co')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,$3,'Main')`,
      tenantId,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
      tenantId,
      CO,
      YEAR,
    );
    await exec(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","FINE_STK_TYPE") VALUES ($1,$2,'F')`,
      tenantId,
      CO,
    );
    await exec(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE") VALUES ($1,$2)`, tenantId, CO);
    for (const [code, name] of [
      [PARTY, 'OLD ITEM CUSTOMER'],
      [PURC_AC, 'PURCHASE GOLD A/C'],
      ['LABOUR', 'LABOUR A/C'],
      ['GST', 'GST A/C'],
    ]) {
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
         VALUES ($1,$2,$3,$4,$5,'L')`,
        tenantId,
        CO,
        LC,
        code,
        name,
      );
    }
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC") VALUES ($1,$2,'GO','GOLD',$3)`,
      tenantId,
      CO,
      PURC_AC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'OLDG','OLD GOLD','G','GO')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
                                "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,'OLD ITEM SALES','OIS','OLD ITEM SALES','O','Y','KR_DATA'),
              ($1,$2,$3,$5,'Karigar Receipt','KREC','KARIGAR RECEIPT','I','Y','KR_DATA')`,
      tenantId,
      CO,
      LC,
      OLD_BOOK,
      KR_BOOK,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,1,$6,'OLD ITEM SALES','OLD ITEM SALES','O'),
              ($1,$2,$3,$5,1,$6,'Karigar Receipt','KARIGAR RECEIPT','I')`,
      tenantId,
      CO,
      LC,
      OLD_BOOK,
      KR_BOOK,
      PURC_AC,
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

  const line = (overrides: Record<string, unknown> = {}) => ({
    itCode: 'OLDG',
    itDesc: 'Old chain',
    tblCode: '001',
    pcs: 1,
    grossWt: 12,
    othWt: 1,
    netWt: 10,
    ghtWt: 1,
    touch: 91,
    westPct: 1,
    lessTouch: 2,
    kunFine: 0.5,
    silverFine: 0.25,
    ghtPct: 1.25,
    rate: 7100,
    amount: 71000,
    totalAmount: 71025,
    urdRateType: 'G',
    commissionPct: 1.5,
    commissionAmount: 1050,
    stones: [
      {
        isrNo: 1,
        itCode: 'DM',
        dmCode: 'D1',
        dmName: 'Diamond',
        pcs: 2,
        grossWt: 0.25,
        rate: 5000,
        amount: 1250,
        netAmount: 1250,
      },
    ],
    ...overrides,
  });

  const header = async (vchNo: string) => {
    const rows = (await withTenant(owner, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "VCH_NO","CO_BOOK","AC_CODE","PARTY_FINE"::float8 AS party_fine,
                "LBR_AMT"::float8 AS lbr,"TAX_AMT"::float8 AS tax,"BILL_OS"::float8 AS bill_os
           FROM "KR_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
        tenantId,
        CO,
        OLD_BOOK,
        vchNo,
      ),
    )) as Array<Record<string, unknown>>;
    expect(rows).toHaveLength(1);
    return rows[0]!;
  };

  it('creates, reads, edits, and deletes OLD ITEM SALES as KR-family rows with old-gold fine', async () => {
    const created = await createOldItemSale(runtime, {
      scope,
      karigarAc: PARTY,
      karigarName: 'OLD ITEM CUSTOMER',
      vchDate: '2024-06-10',
      mainUser: 'old-user',
      billOutstanding: 321.25,
      partyFine: 7.25,
      lines: [line()],
    } as any);
    expect(created.vchNo).toBe(1);
    expect(created.fineReceived).toBe(7.25);
    expect(created.labourAmt).toBe(0);
    const vchNo = '00001';

    const expectedLineFine = fineFor('purchaseOldGold', {
      netWt: 10,
      ghtWt: 1,
      touch: 91,
      westPct: 1,
      lesTouch: 2,
      kunFine: 0.5,
    });
    expect(expectedLineFine).toBe(10.4);
    expect(await header(vchNo)).toMatchObject({
      CO_BOOK: OLD_BOOK,
      AC_CODE: PARTY,
      party_fine: 7.25,
      lbr: 0,
      tax: 0,
      bill_os: 321.25,
    });

    const details = (await withTenant(owner, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "BOOK_NAME","INOUT_TYPE","ENTRY_TYPE","IT_CODE","ITM_FINE"::float8 AS fine,
                "ITM_LESS_TCH"::float8 AS less_touch,"SILVER_FINE"::float8 AS silver,
                "ITM_GHT_PRC"::float8 AS ght_prc,"URD_RATE_TYPE","COMM_PRC"::float8 AS comm_prc,
                "COMM_AMT"::float8 AS comm_amt,"ITM_AMT"::float8 AS amount,"TOT_AMT"::float8 AS total
           FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        tenantId,
        OLD_BOOK,
        vchNo,
      ),
    )) as Array<Record<string, unknown>>;
    expect(details).toHaveLength(1);
    expect(details[0]).toMatchObject({
      BOOK_NAME: 'OLD ITEM SALES',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'P',
      IT_CODE: 'OLDG',
      less_touch: 2,
      silver: 0.25,
      ght_prc: 1.25,
      URD_RATE_TYPE: 'G',
      comm_prc: 1.5,
      comm_amt: 1050,
      amount: 71000,
      total: 71025,
    });
    expect(Number(details[0]!.fine)).toBeCloseTo(expectedLineFine, 3);

    const stock = (await withTenant(owner, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "BOOK_NAME","TR_TYPE","ITM_SIGN","ITM_FINE"::float8 AS fine
           FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        tenantId,
        OLD_BOOK,
        vchNo,
      ),
    )) as Array<Record<string, unknown>>;
    expect(stock).toEqual([
      { BOOK_NAME: 'OLD ITEM SALES', TR_TYPE: 'O', ITM_SIGN: '-', fine: expectedLineFine },
    ]);

    const ledger = (await withTenant(owner, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "BOOK_NAME","VCH_TYPE","SIGN","FINE_WT"::float8 AS fine_wt,"DR_AMT"::float8 AS dr,"CR_AMT"::float8 AS cr
           FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY row_id`,
        tenantId,
        OLD_BOOK,
        vchNo,
      ),
    )) as Array<Record<string, unknown>>;
    expect(ledger).toEqual([
      { BOOK_NAME: 'OLD ITEM SALES', VCH_TYPE: 'OIS', SIGN: '-', fine_wt: 7.25, dr: 0, cr: 0 },
    ]);

    const reopened = (await getOldItemSale(runtime, scope, created.vchNo)) as any;
    expect(reopened.partyFine).toBe(7.25);
    expect(reopened.billOutstanding).toBe(321.25);
    expect(reopened.lines[0]).toMatchObject({
      itCode: 'OLDG',
      lessTouch: 2,
      silverFine: 0.25,
      ghtPct: 1.25,
      urdRateType: 'G',
      commissionPct: 1.5,
      commissionAmount: 1050,
      amount: 71000,
      totalAmount: 71025,
    });
    expect(reopened.lines[0].stones).toHaveLength(1);

    await editOldItemSale(runtime, {
      scope,
      vchNo: created.vchNo,
      karigarAc: PARTY,
      karigarName: 'OLD ITEM CUSTOMER EDIT',
      vchDate: '2024-06-11',
      mainUser: 'old-edit',
      partyFine: 8.5,
      lines: [
        line({
          netWt: 8,
          ghtWt: 0.5,
          touch: 90,
          westPct: 0,
          lessTouch: 1,
          kunFine: 0.25,
          amount: 50000,
          totalAmount: 50000,
        }),
      ],
    } as any);
    const editedFine = fineFor('purchaseOldGold', {
      netWt: 8,
      ghtWt: 0.5,
      touch: 90,
      westPct: 0,
      lesTouch: 1,
      kunFine: 0.25,
    });
    expect((await header(vchNo)).party_fine).toBe(8.5);
    const afterEdit = (await withTenant(owner, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT
           (SELECT count(*)::int FROM "KR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS headers,
           (SELECT count(*)::int FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS lines,
           (SELECT count(*)::int FROM "KR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS stones,
           (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS delete_rows,
           (SELECT "ITM_FINE"::float8 FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1) AS line_fine`,
        tenantId,
        OLD_BOOK,
        vchNo,
      ),
    )) as Array<{
      headers: number;
      lines: number;
      stones: number;
      delete_rows: number;
      line_fine: number;
    }>;
    expect(afterEdit[0]).toMatchObject({ headers: 1, lines: 1, stones: 1, delete_rows: 0 });
    expect(afterEdit[0]!.line_fine).toBeCloseTo(editedFine, 3);

    await deleteOldItemSale(runtime, { scope, vchNo: created.vchNo, deleteUser: 'old-delete' });
    const afterDelete = (await withTenant(owner, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT
           (SELECT count(*)::int FROM "KR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS headers,
           (SELECT count(*)::int FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS lines,
           (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS stock_rows,
           (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS ledger_rows,
           (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) AS delete_rows,
           (SELECT "BOOK_NAME" FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1) AS delete_book`,
        tenantId,
        OLD_BOOK,
        vchNo,
      ),
    )) as Array<Record<string, unknown>>;
    expect(afterDelete[0]).toMatchObject({
      headers: 0,
      lines: 0,
      stock_rows: 0,
      ledger_rows: 0,
      delete_rows: 1,
      delete_book: 'OLD ITEM SALES',
    });
  });

  it('keeps OLD ITEM SALES out of generic karigar receipt and rejects non-old books on the old endpoint', async () => {
    await expect(
      receiveKarigar(runtime, {
        scope,
        karigarAc: PARTY,
        lines: [line()],
      } as any),
    ).rejects.toThrow(/old item sales workflow/i);

    await expect(
      createOldItemSale(runtime, {
        scope: karigarScope,
        karigarAc: PARTY,
        partyFine: 1,
        lines: [line()],
      } as any),
    ).rejects.toThrow(/expected OLD ITEM SALES/i);
  });
});
