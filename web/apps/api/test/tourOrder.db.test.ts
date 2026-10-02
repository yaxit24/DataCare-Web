import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  cancelTourOrder,
  createTourOrder,
  editTourOrder,
  getTourOrder,
  listTourOrders,
} from '../src/modules/sales/salesOrder.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('TR_SALE_ORD Tour Order lifecycle parity', () => {
  const owner = new PrismaClient({
    datasources: {
      db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' },
    },
  });
  const runtime = new PrismaClient({
    datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
  });
  const tenantId = 'tour-order-db';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const DAY = '2024-07-10';
  const EDIT_DAY = '2024-07-11';
  const scope = (coBook = '510') =>
    ({ tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook }) as any;

  const tables = [
    'DELETE_DATA',
    'ROJ_MEL_DATA',
    'AC_DATA',
    'SL_ORD_IDTL',
    'SL_ORD_DETL',
    'SL_ORD_DATA',
    'TEMP_BOOK_DATA',
    'BOOK_DATA',
    'ITEM_MAST',
    'AC_MAST',
    'CO_SET',
    'YEAR_MAST',
  ];

  const exec = (sql: string, ...params: unknown[]) =>
    withTenant(owner, tenantId, (tx: any) => tx.$executeRawUnsafe(sql, ...params));

  async function clean() {
    for (const table of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  }

  async function seed() {
    await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, tenantId, CO);
    await exec(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
      tenantId,
      CO,
      YEAR,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
       VALUES ($1,$2,$3,'510','Tour Order','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA','SL_ORD_DETL'),
              ($1,$2,$3,'SOR','Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL')`,
      tenantId,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'TOURAC','Tour Customer'),($1,$2,$3,'CASH','Cash Account')`,
      tenantId,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold Ring','G','G01')`,
      tenantId,
      CO,
    );
  }

  const tourInput = (overrides: Record<string, unknown> = {}) => ({
    scope: scope(),
    mainUser: 'tour-owner',
    acCode: 'TOURAC',
    acName: 'Tour Customer',
    vchDate: DAY,
    taxRatePct: 0,
    advanceAmount: 25,
    cashAc: 'CASH',
    city: 'Surat',
    mobile: '9812345670',
    empCode: 'E01',
    lines: [
      {
        itCode: 'GOLD',
        pcs: 1,
        grossWt: 5,
        netWt: 5,
        touch: 92,
        rate: 6000,
        making: 40,
        designNo: 'D-TUR',
        tblCode: '002',
        itmColor: 'YELLOW',
        itmSize: '18',
        ghtWt: 0.2,
        westPct: 1.5,
        dmCode: 'DM1',
        dmName: 'Diamond',
        dmSize: 'S1',
        stonePcsWt: 2,
        stoneConPct: 5,
        stoneConWt: 0.1,
        stoneRateType: 'P',
        stoneRate: 1000,
        stoneLabourAmount: 10,
        stoneKarigarNetAmount: 20,
      },
    ],
    ...overrides,
  });

  beforeEach(async () => {
    await clean();
    await seed();
  });

  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('creates, reads, edits, lists, and deletes TOUR ORDER rows with desktop order stamps', async () => {
    const created = await createTourOrder(runtime, tourInput() as any);
    expect(created).toMatchObject({ vchNo: 1, advance: 25 });
    const vchNo = '00001';

    await expect(getTourOrder(runtime, scope(), vchNo)).resolves.toMatchObject({
      voucherNo: vchNo,
      hiddenVoucherNo: '00001',
      mainUser: 'tour-owner',
      acCode: 'TOURAC',
      lines: [{ itCode: 'GOLD', designNo: 'D-TUR' }],
    });

    const list = await listTourOrders(runtime, scope());
    expect(list).toHaveLength(1);
    expect(list[0]).toMatchObject({ vchNo, book: '510', acCode: 'TOURAC', advance: 25 });

    const detail = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","AC_CODE","TAG_NO","DESIGN_NO","ITM_FINE"::float8 AS fine,"HD_VCH_NO","MAIN_USER"
             FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='510' AND "VCH_NO"=$2`,
          tenantId,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(detail).toMatchObject({
      VCH_TYPE: 'TUROD',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'O',
      BOOK_NAME: 'TOUR ORDER',
      AC_CODE: 'TOURAC',
      TAG_NO: 'N',
      DESIGN_NO: 'D-TUR',
      HD_VCH_NO: '00001',
      MAIN_USER: 'tour-owner',
    });
    expect(Number(detail.fine)).toBeCloseTo(4.862, 3);

    const idtl = (
      (await withTenant(owner, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","AC_CODE","DM_CODE","DM_NAME","IT_PCS_WT"::float8 AS pcs_wt,"IT_NET_AMT"::float8 AS net_amt
             FROM "SL_ORD_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"='510' AND "VCH_NO"=$2`,
          tenantId,
          vchNo,
        ),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(idtl).toMatchObject({
      VCH_TYPE: 'TUROD',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'O',
      BOOK_NAME: 'TOUR ORDER',
      AC_CODE: 'TOURAC',
      DM_CODE: 'DM1',
      DM_NAME: 'Diamond',
      pcs_wt: 2,
    });

    const tempBook = (await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK","VCH_NO","BOOK_NAME" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`,
      tenantId,
    )) as Array<Record<string, unknown>>;
    expect(tempBook).toEqual([{ CO_BOOK: '510', VCH_NO: '00001', BOOK_NAME: 'Tour Order' }]);

    const ledger = (await owner.$queryRawUnsafe(
      `SELECT "VCH_TYPE","AC_CODE","DR_AMT"::float8 AS dr,"CR_AMT"::float8 AS cr FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      tenantId,
    )) as Array<Record<string, unknown>>;
    expect(ledger).toMatchObject([
      { VCH_TYPE: 'TUROD', AC_CODE: 'CASH', dr: 25, cr: 0 },
      { VCH_TYPE: 'TUROD', AC_CODE: 'TOURAC', dr: 0, cr: 25 },
    ]);

    const rojmel = (await owner.$queryRawUnsafe(
      `SELECT "VCH_TYPE","BOOK_NAME","AC_CODE","LD_CODE","CR_AMT"::float8 AS cr FROM "ROJ_MEL_DATA" WHERE tenant_id=$1`,
      tenantId,
    )) as Array<Record<string, unknown>>;
    expect(rojmel).toEqual([
      { VCH_TYPE: 'TUROD', BOOK_NAME: 'TOUR ORDER', AC_CODE: 'TOURAC', LD_CODE: 'CASH', cr: 25 },
    ]);

    await editTourOrder(runtime, tourInput({ vchDate: EDIT_DAY, advanceAmount: 10 }) as any, vchNo);
    const edited = (await getTourOrder(runtime, scope(), vchNo)) as any;
    expect(edited).toMatchObject({
      vchDate: EDIT_DAY,
      advanceAmount: 10,
      hiddenVoucherNo: '00001',
    });

    await cancelTourOrder(runtime, { scope: scope(), vchNo, deleteUser: 'tour-delete' });
    for (const table of [
      'SL_ORD_DATA',
      'SL_ORD_DETL',
      'SL_ORD_IDTL',
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
    const deleted = (await owner.$queryRawUnsafe(
      `SELECT "VCH_TYPE","BOOK_NAME","VCH_VAL_CR"::float8 AS cr,"DELETE_USER" FROM "DELETE_DATA" WHERE tenant_id=$1`,
      tenantId,
    )) as Array<Record<string, unknown>>;
    expect(deleted).toEqual([
      { VCH_TYPE: 'TUROD', BOOK_NAME: 'Tour Order', cr: 10, DELETE_USER: 'tour-delete' },
    ]);
  });

  it('rejects a sales-order book when the Tour Order workflow is requested', async () => {
    await expect(
      createTourOrder(runtime, tourInput({ scope: scope('SOR') }) as any),
    ).rejects.toThrow(/expected TOUR ORDER/);
  });
});
