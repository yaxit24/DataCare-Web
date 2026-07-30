import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  DM_KR_DATA_COLUMNS,
  FINE_DATA_COLUMNS,
  LEDR_AC_DATA_COLUMNS,
  stageAddressLabelsTx,
  stageDiamondKarigarTx,
  stageFineDataTx,
  stageLedgerAcDataTx,
  TEMP_ADD_COLUMNS,
} from '../src/modules/reports/ledgerStaging.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Typed report staging: `FINE_DATA` (9 Crystal layouts) and `LEDR_AC_DATA` (8 layouts).
 *
 * Both were never written by the web, so every one of those seventeen layouts rendered blank. The full
 * column set is asserted rather than sampled, because a partially staged row is worse than none: the
 * report renders with plausible-looking gaps instead of failing visibly.
 */
d('typed ledger report staging', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const TENANT = 'ledger-staging-db';
  const scope = {
    tenantId: TENANT,
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: 'LDR',
  };

  const clean = async (): Promise<void> => {
    for (const table of ['FINE_DATA', 'LEDR_AC_DATA', 'DM_KR_DATA', 'TEMP_ADD']) {
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

  it('stages every FINE_DATA column the desktop writes', async () => {
    const written = await withTenant(runtime, TENANT, (tx: any) =>
      stageFineDataTx(tx, scope, [
        {
          vchNo: '00008',
          srNo: 1,
          iSrNo: 2,
          vchDate: '2024-04-05',
          vchType: 'SAL',
          bookName: 'SALES',
          acCode: 'CUST',
          acName: 'Retail Customer',
          ldCode: 'SALEAC',
          itCode: 'GOLD',
          itDesc: 'Gold Ornament 22K',
          tagNo: 'TAG001',
          pcs: 2,
          grossWt: 12.5,
          netWt: 12,
          touch: 91.6,
          westPct: 1.5,
          fineWt: 11.172,
          rate: 6200,
          amount: 69266.4,
          labourRate: 150,
          labourAmount: 1800,
          otherAmount: 25,
          netAmount: 71091,
          crAmt: 0,
          drAmt: 71091,
          trType: 'S',
          itmSign: '-',
          entryType: 'A',
          dataType: 'L',
        },
      ]),
    );
    expect(written).toBe(1);

    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT ${FINE_DATA_COLUMNS.map((c) => `"${c}"`).join(',')}
         FROM "FINE_DATA" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    const row = rows[0]!;

    // Identity and scope
    expect(String(row.CO_CODE).trim()).toBe('01');
    expect(String(row.LC_CODE).trim()).toBe('01');
    expect(String(row.CO_YEAR).trim()).toBe('2024-2025');
    expect(String(row.CO_BOOK).trim()).toBe('LDR');
    expect(String(row.VCH_NO).trim()).toBe('00008');
    expect(Number(row.SR_NO)).toBe(1);
    expect(Number(row.ISR_NO)).toBe(2);
    expect(new Date(row.VCH_DATE).toISOString().slice(0, 10)).toBe('2024-04-05');

    // Descriptive columns, each sliced to its REAL width (AC_NAME 50, IT_DESC 50, TAG_NO 15)
    expect(String(row.VCH_TYPE).trim()).toBe('SAL');
    expect(String(row.BOOK_NAME).trim()).toBe('SALES');
    expect(String(row.AC_CODE).trim()).toBe('CUST');
    expect(String(row.AC_NAME).trim()).toBe('Retail Customer');
    expect(String(row.LD_CODE).trim()).toBe('SALEAC');
    expect(String(row.IT_CODE).trim()).toBe('GOLD');
    expect(String(row.IT_DESC).trim()).toBe('Gold Ornament 22K');
    expect(String(row.TAG_NO).trim()).toBe('TAG001');

    // Weights and money — the columns the fine-ledger reports actually print
    expect(Number(row.ITM_PCS)).toBe(2);
    expect(Number(row.ITM_GWT)).toBeCloseTo(12.5, 3);
    expect(Number(row.ITM_NWT)).toBeCloseTo(12, 3);
    expect(Number(row.ITM_TOUCH)).toBeCloseTo(91.6, 2);
    expect(Number(row.ITM_WEST)).toBeCloseTo(1.5, 2);
    expect(Number(row.ITM_FINE)).toBeCloseTo(11.172, 3);
    expect(Number(row.ITM_RATE)).toBeCloseTo(6200, 2);
    expect(Number(row.ITM_AMT)).toBeCloseTo(69266.4, 2);
    expect(Number(row.LBR_RATE)).toBeCloseTo(150, 2);
    expect(Number(row.LBR_AMT)).toBeCloseTo(1800, 2);
    expect(Number(row.OTH_AMT)).toBeCloseTo(25, 2);
    expect(Number(row.NET_AMT)).toBeCloseTo(71091, 2);
    expect(Number(row.CR_AMT)).toBe(0);
    expect(Number(row.DR_AMT)).toBeCloseTo(71091, 2);

    // Classification flags
    expect(String(row.TR_TYPE).trim()).toBe('S');
    expect(String(row.ITM_SIGN).trim()).toBe('-');
    expect(String(row.ENTRY_TYPE).trim()).toBe('A');
    expect(String(row.DATA_TYPE).trim()).toBe('L');
  }, 30_000);

  it('stages every LEDR_AC_DATA column, writing the text date and weight columns as text', async () => {
    const written = await withTenant(runtime, TENANT, (tx: any) =>
      stageLedgerAcDataTx(tx, scope, [
        {
          acCode: 'CUST',
          vchDate: '2024-04-05',
          drAmt: 71091,
          crAmt: 0,
          drFineWt: 11.172,
          crFineWt: 0,
          drSilverFine: 2.5,
          crSilverFine: 0,
          dataType: 'L',
          mainUser: 'admin',
        },
      ]),
    );
    expect(written).toBe(1);

    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT ${LEDR_AC_DATA_COLUMNS.map((c) => `"${c}"`).join(',')}
         FROM "LEDR_AC_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    const row = rows[0]!;
    expect(String(row.AC_CODE).trim()).toBe('CUST');
    // VCH_DT is varchar in the restored schema; ISO text is written so it sorts correctly.
    expect(String(row.VCH_DT).trim()).toBe('2024-04-05');
    expect(Number(row.DR_AMT)).toBeCloseTo(71091, 2);
    expect(Number(row.CR_AMT)).toBe(0);
    // Fine-weight columns are varchar too, carrying three decimals rather than a coerced number.
    expect(String(row.DR_FINE_WT).trim()).toBe('11.172');
    expect(String(row.CR_FINE_WT).trim()).toBe('0.000');
    // The silver pair is numeric, unlike the gold pair — an asymmetry in the restored schema.
    expect(Number(row.DR_SL_FINE)).toBeCloseTo(2.5, 3);
    expect(Number(row.CR_SL_FINE)).toBe(0);
    expect(String(row.DATA_TYPE).trim()).toBe('L');
    expect(String(row.MAIN_USER).trim()).toBe('admin');
  }, 30_000);

  it('clears the previous materialisation instead of accumulating rows', async () => {
    await withTenant(runtime, TENANT, (tx: any) =>
      stageFineDataTx(tx, scope, [{ vchNo: '00001' }, { vchNo: '00002' }]),
    );
    await withTenant(runtime, TENANT, (tx: any) =>
      stageFineDataTx(tx, scope, [{ vchNo: '00003' }]),
    );
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "VCH_NO" FROM "FINE_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    // A re-run replaces, matching the desktop's delete-by-company before every report materialisation.
    expect(rows).toHaveLength(1);
    expect(String(rows[0]!.VCH_NO).trim()).toBe('00003');
  }, 30_000);

  it('truncates over-long text to the real column widths rather than failing', async () => {
    await withTenant(runtime, TENANT, (tx: any) =>
      stageFineDataTx(tx, scope, [
        { vchNo: '00009', acName: 'X'.repeat(120), itDesc: 'Y'.repeat(120), tagNo: 'Z'.repeat(40) },
      ]),
    );
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "AC_NAME","IT_DESC","TAG_NO" FROM "FINE_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(String(rows[0]!.AC_NAME).length).toBeLessThanOrEqual(50);
    expect(String(rows[0]!.IT_DESC).length).toBeLessThanOrEqual(50);
    expect(String(rows[0]!.TAG_NO).length).toBeLessThanOrEqual(15);
  }, 30_000);

  it('stages every DM_KR_DATA column for the karigar diamond layouts', async () => {
    const written = await withTenant(runtime, TENANT, (tx: any) =>
      stageDiamondKarigarTx(tx, scope, [
        {
          vchNo: '00012',
          mainSrNo: 1,
          srNo: 1,
          iSrNo: 2,
          vchDate: '2024-04-07',
          entryType: 'I',
          bookName: 'KR ISSUE',
          acCode: 'KR01',
          dmLot: 'LOT-9',
          itCode: 'DIAM',
          dmCode: 'VVS1',
          dmSize: '0.10-0.15',
          pcs: 12,
          weight: 1.44,
          sign: '+',
          rate: 45000,
          amount: 64800,
          empCode: 'E01',
          mainUser: 'admin',
        },
      ]),
    );
    expect(written).toBe(1);
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT ${DM_KR_DATA_COLUMNS.map((c) => `"${c}"`).join(',')}
         FROM "DM_KR_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    const row = rows[0]!;
    expect(String(row.VCH_NO).trim()).toBe('00012');
    expect(Number(row.MAIN_SRNO)).toBe(1);
    expect(Number(row.ISR_NO)).toBe(2);
    expect(String(row.ENTRY_TYPE).trim()).toBe('I');
    expect(String(row.BOOK_NAME).trim()).toBe('KR ISSUE');
    expect(String(row.AC_CODE).trim()).toBe('KR01');
    expect(String(row.DM_LOT).trim()).toBe('LOT-9');
    expect(String(row.IT_CODE).trim()).toBe('DIAM');
    expect(String(row.DM_CODE).trim()).toBe('VVS1');
    expect(String(row.DM_SIZE).trim()).toBe('0.10-0.15');
    expect(Number(row.DM_PCS)).toBe(12);
    expect(Number(row.DM_WT)).toBeCloseTo(1.44, 3);
    expect(String(row.DM_SIGN).trim()).toBe('+');
    expect(Number(row.DM_RATE)).toBeCloseTo(45000, 2);
    expect(Number(row.DM_AMT)).toBeCloseTo(64800, 2);
    expect(String(row.EMP_CODE).trim()).toBe('E01');
    expect(String(row.MAIN_USER).trim()).toBe('admin');
  }, 30_000);

  it('stages every TEMP_ADD column, keeping the desktop AC_PARSON spelling', async () => {
    const written = await withTenant(runtime, TENANT, (tx: any) =>
      stageAddressLabelsTx(tx, scope, [
        {
          acCode: 'CUST',
          acName: 'Retail Customer',
          add1: 'Plot 8',
          add2: 'Jewel Street',
          add3: 'Opp Bank',
          city: 'Surat',
          pin: '395003',
          phone: '0261-1234567',
          mobile: '9812345670',
          mobile2: '9812345671',
          email: 'cust@example.com',
          person: 'Contact Person',
          area: 'Ring Road',
        },
      ]),
    );
    expect(written).toBe(1);
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT ${TEMP_ADD_COLUMNS.map((c) => `"${c}"`).join(',')}
         FROM "TEMP_ADD" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    const row = rows[0]!;
    expect(String(row.AC_NAME).trim()).toBe('Retail Customer');
    expect(String(row.AC_ADD1).trim()).toBe('Plot 8');
    expect(String(row.AC_ADD3).trim()).toBe('Opp Bank');
    expect(String(row.AC_CITY).trim()).toBe('Surat');
    expect(String(row.AC_MOBILE2).trim()).toBe('9812345671');
    expect(String(row.AC_EMAIL).trim()).toBe('cust@example.com');
    // The desktop column is AC_PARSON (its own spelling); renaming it would break the Crystal binding.
    expect(String(row.AC_PARSON).trim()).toBe('Contact Person');
    expect(String(row.AC_AREA).trim()).toBe('Ring Road');
  }, 30_000);
});
