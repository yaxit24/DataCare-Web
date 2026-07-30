import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  BOOK_IDTL_COLUMNS,
  OP_LDR_COLUMNS,
  setBookAccountDetails,
  setColumnLabels,
  setOpeningLedger,
  setRojmelClosingCash,
  setWeightSlabs,
  stageTagSummaryTx,
  TAG_SUM_DATA_COLUMNS,
} from '../src/modules/masters/configTables.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * The last group of previously-never-written desktop tables. Full column sets are asserted, because a
 * partially written configuration or staging row produces a report that looks populated but is wrong.
 */
d('configuration and staging tables', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const TENANT = 'config-tables-db';
  const scope = {
    tenantId: TENANT,
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: 'LDR',
  };

  const clean = async (): Promise<void> => {
    for (const table of [
      'WEIGHT_MAST',
      'USER_MAST',
      'BOOK_IDTL',
      'ROJMEL_BAL',
      'TAG_SUM_DATA',
      'OP_LDR',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
    await clean();
  });
  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('writes weight slabs and rejects an inverted band', async () => {
    const written = await setWeightSlabs(runtime, TENANT, [
      { lowWt: 0, highWt: 5, colName: 'UPTO_5G' },
      { lowWt: 5.001, highWt: 10, colName: 'UPTO_10G' },
    ]);
    expect(written).toBe(2);
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "SR_NO","LOW_WT","HIGH_WT","COL_NAME" FROM "WEIGHT_MAST"
        WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      TENANT,
    );
    expect(rows).toHaveLength(2);
    expect(Number(rows[0]!.SR_NO)).toBe(1);
    expect(Number(rows[0]!.HIGH_WT)).toBeCloseTo(5, 3);
    expect(String(rows[1]!.COL_NAME).trim()).toBe('UPTO_10G');
    // An inverted band would put the same weight in two columns.
    await expect(
      setWeightSlabs(runtime, TENANT, [{ lowWt: 10, highWt: 5, colName: 'BAD' }]),
    ).rejects.toThrow(/HIGH_WT below LOW_WT/);
  }, 30_000);

  it('writes column labels, which are captions and not user accounts', async () => {
    const written = await setColumnLabels(runtime, TENANT, [
      { tableColumn: 'ITM_GWT', label: 'Gross Wt' },
      { tableColumn: '  ', label: 'ignored' },
    ]);
    // The blank column name is skipped rather than written as null.
    expect(written).toBe(1);
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "TBL_COL_NAME","COL_NAME" FROM "USER_MAST" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    expect(String(rows[0]!.TBL_COL_NAME).trim()).toBe('ITM_GWT');
    expect(String(rows[0]!.COL_NAME).trim()).toBe('Gross Wt');
  }, 30_000);

  it('writes book account detail with its numeric key columns', async () => {
    const written = await setBookAccountDetails(runtime, TENANT, [
      { acCode: 1001, mainBook: 3, srNo: 1, inoutType: 'O', acName: 'Sales A/c' },
    ]);
    expect(written).toBe(1);
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT ${BOOK_IDTL_COLUMNS.map((c) => `"${c}"`).join(',')} FROM "BOOK_IDTL" WHERE tenant_id=$1`,
      TENANT,
    );
    // AC_CODE / MAIN_BOOK / SR_NO are NUMERIC here, unlike BOOK_DETL where the same names are text.
    expect(Number(rows[0]!.AC_CODE)).toBe(1001);
    expect(Number(rows[0]!.MAIN_BOOK)).toBe(3);
    expect(String(rows[0]!.INOUT_TYPE).trim()).toBe('O');
    expect(String(rows[0]!.AC_NAME).trim()).toBe('Sales A/c');
  }, 30_000);

  it('keeps one closing-cash row per day, replacing on a re-run', async () => {
    await setRojmelClosingCash(runtime, scope, '2024-04-05', 12_500, 'admin');
    await setRojmelClosingCash(runtime, scope, '2024-04-05', 13_000, 'admin');
    await setRojmelClosingCash(runtime, scope, '2024-04-06', 9_000, 'admin');
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "VCH_DATE","CLOSING_CASH","MAIN_USER" FROM "ROJMEL_BAL"
        WHERE tenant_id=$1 ORDER BY "VCH_DATE"`,
      TENANT,
    );
    expect(rows).toHaveLength(2);
    // The same day was closed twice; the later value wins rather than a second row appearing.
    expect(Number(rows[0]!.CLOSING_CASH)).toBeCloseTo(13_000, 2);
    expect(Number(rows[1]!.CLOSING_CASH)).toBeCloseTo(9_000, 2);
    expect(String(rows[0]!.MAIN_USER).trim()).toBe('admin');
  }, 30_000);

  it('stages every TAG_SUM_DATA column and clears the previous run', async () => {
    await withTenant(runtime, TENANT, (tx: any) =>
      stageTagSummaryTx(tx, scope, [
        {
          vchNo: '00008',
          srNo: 1,
          iSrNo: 2,
          vchDate: '2024-04-05',
          itCode: 'GOLD',
          tagNo: 'TAG001',
          vchSrno: 3,
          itType: 'G',
          dataType: 'A',
          qty: 1,
          pcs: 2,
          grossWt: 12.5,
          netWt: 12,
          fineWt: 11.172,
          designNo: 'D-1',
          itemLot: 'LOT-1',
          sign: '+',
          itmSize: '14',
          tblCode: 'C1',
          trType: 'S',
        },
      ]),
    );
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT ${TAG_SUM_DATA_COLUMNS.map((c) => `"${c}"`).join(',')}
         FROM "TAG_SUM_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    const row = rows[0]!;
    expect(String(row.TAG_NO).trim()).toBe('TAG001');
    expect(Number(row.ITM_FINE)).toBeCloseTo(11.172, 3);
    expect(String(row.ITM_SIGN).trim()).toBe('+');
    expect(String(row.TBL_CODE).trim()).toBe('C1');
    expect(String(row.TR_TYPE).trim()).toBe('S');
    expect(Number(row.VCH_SRNO)).toBe(3);

    await withTenant(runtime, TENANT, (tx: any) =>
      stageTagSummaryTx(tx, scope, [{ vchNo: '00009' }]),
    );
    const after: any[] = await owner.$queryRawUnsafe(
      `SELECT "VCH_NO" FROM "TAG_SUM_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(after).toHaveLength(1);
    expect(String(after[0]!.VCH_NO).trim()).toBe('00009');
  }, 30_000);

  it('writes opening ledger rows with both the money and the metal side', async () => {
    const written = await setOpeningLedger(runtime, scope, [
      {
        vchNo: '00001',
        vchDate: '2024-04-01',
        vchType: 'OPBAL',
        inoutType: 'I',
        entryType: 'O',
        bookName: 'OPENING',
        acCode: 'CUST',
        drAmt: 50_000,
        crAmt: 0,
        drGoldFine: 25.5,
        crGoldFine: 0,
        drSilverFine: 100.25,
        crSilverFine: 0,
        dataType: 'L',
      },
    ]);
    expect(written).toBe(1);
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT ${OP_LDR_COLUMNS.map((c) => `"${c}"`).join(',')} FROM "OP_LDR" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    const row = rows[0]!;
    expect(Number(row.DR_AMT)).toBeCloseTo(50_000, 2);
    // A jewellery opening balance has a metal side as well as a money side — that is why OP_LDR exists
    // separately from OP_DATA.
    expect(Number(row.DR_GL_FINE)).toBeCloseTo(25.5, 3);
    expect(Number(row.DR_SL_FINE)).toBeCloseTo(100.25, 3);
    expect(String(row.BOOK_NAME).trim()).toBe('OPENING');
    expect(String(row.AC_CODE).trim()).toBe('CUST');
  }, 30_000);
});
