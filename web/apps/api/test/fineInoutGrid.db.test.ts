import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { fineInout } from '../src/modules/inout/fineInout.js';

/**
 * P7 — the Fine In/Out detail grid is persisted.
 *
 * WHY THIS FILE EXISTS AT ALL
 * `fineInout` had NO test coverage. It also had a 6-field line contract writing 16 of `INOUT_DETL`'s
 * 96 columns, while the desktop's `TR_FN_INOUT` MSG grid has 42 named columns and `TR_INOUT` has 47.
 * An operator could move fine metal, but the tag identity, labour block, karigar block and
 * transfer-target columns the desktop records had nowhere to go.
 *
 * WHY IT ASSERTS THE DATABASE AND NOT THE RETURN VALUE
 * A field on the contract that the writer ignores is a DEAD CELL: the operator types a value and it is
 * silently discarded. That defect nearly shipped as 12 fake columns on hallmark-sale, and it is only
 * detectable by reading back the persisted row.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'fine-inout-grid';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'FIO';
const DAY = '2024-06-01';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('fine in/out persists the desktop detail grid', () => {
  beforeEach(async () => {
    await wipe();
    // settingsBehavior requires EXACTLY ONE CO_SET row per company.
    await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
    await exec(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
      TENANT,
      CO,
      YEAR,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,'Fine In Out','FIO','FINE INOUT','I','Y','INOUT_DATA')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
       VALUES ($1,$2,'GOLD','Gold','G')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'REFINE','Refinery')`,
      TENANT,
      CO,
      LC,
    );
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('stores every desktop grid column the contract accepts', async () => {
    const result = await fineInout(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      direction: 'IN',
      partyAc: 'REFINE',
      lines: [
        {
          itCode: 'GOLD',
          pcs: 3,
          grossWt: 20.5,
          netWt: 20,
          touch: 91.6,
          tagNo: 'TG-1',
          lotNo: 'LOT-9',
          itemLot: 'IL-2',
          designNo: 'D-FIO',
          tblCode: '005',
          itmSize: '18',
          itmStyle: 'ST-1',
          itmColor: 'RG',
          // Alphanumeric on purpose: a HUID with letters must survive unchanged.
          hallmarkId: 'HUID42QQ',
          remark: 'refinery in',
          bagWt: 0.11,
          lessWt: 0.5,
          ghtWt: 0.75,
          westPct: 1.25,
          rate: 6100,
          amount: 122000,
          labourPct: 2,
          labourType: 'G',
          labourRate: 45,
          labourAmount: 900,
          otherAmount: 30,
          tagCost: 140,
          mrp: 150000,
          margin: 7,
          rateType: 'F',
          karigarName: 'KR-9',
          karigarOtherWt: 0.2,
          karigarNetWt: 19.5,
          karigarGhtPct: 1.5,
          karigarGhtWt: 0.3,
          karigarTouch: 90,
          karigarWestPct: 0.75,
          karigarFine: 17.6,
          karigarLbrRate: 38,
          karigarLbrAmt: 741,
          toLcCode: '02',
          prCode: 'P3',
          lbrCode: 'LC-4',
          designImageId: 'IMG-FIO-1',
          empIsu: 'E',
        },
      ],
    });
    expect(result.vchNo).toBe(1);

    const row = (
      (await owner.$queryRawUnsafe(
        `SELECT * FROM "INOUT_DETL" WHERE tenant_id=$1 AND "SR_NO"=1`,
        TENANT,
      )) as Array<Record<string, unknown>>
    )[0]!;

    // Text columns, including the alphanumeric HUID that a Number() coercion would destroy.
    expect(String(row.TAG_NO)).toBe('TG-1');
    expect(String(row.HM_ID)).toBe('HUID42QQ');
    expect(String(row.LOT_NO)).toBe('LOT-9');
    expect(String(row.ITM_LOT)).toBe('IL-2');
    expect(String(row.DESIGN_NO)).toBe('D-FIO');
    expect(String(row.TBL_CODE)).toBe('005');
    expect(String(row.ITM_SIZE)).toBe('18');
    expect(String(row.ITM_STYLE)).toBe('ST-1');
    expect(String(row.ITM_COLOR)).toBe('RG');
    expect(String(row.ITM_REMARK)).toBe('refinery in');
    expect(String(row.KR_NAME)).toBe('KR-9');
    expect(String(row.TO_LC_CODE)).toBe('02');
    expect(String(row.PR_CODE)).toBe('P3');
    expect(String(row.LBR_CODE)).toBe('LC-4');
    expect(String(row.DESIGN_IMG_ID)).toBe('IMG-FIO-1');
    expect(String(row.EMP_ISU)).toBe('E');
    expect(String(row.RATE_TYPE)).toBe('F');
    expect(String(row.LBR_TYPE)).toBe('G');

    // Numeric columns.
    expect(Number(row.BAG_WT)).toBe(0.11);
    expect(Number(row.ITM_OTH_WT)).toBe(0.5);
    expect(Number(row.ITM_GHT_WT)).toBe(0.75);
    expect(Number(row.ITM_WEST_PRC)).toBe(1.25);
    expect(Number(row.ITM_RATE)).toBe(6100);
    expect(Number(row.ITM_AMT)).toBe(122000);
    expect(Number(row.LBR_PRC)).toBe(2);
    expect(Number(row.LBR_RATE)).toBe(45);
    expect(Number(row.LBR_AMT)).toBe(900);
    expect(Number(row.OTH_AMT)).toBe(30);
    expect(Number(row.TAG_COST)).toBe(140);
    expect(Number(row.ITM_MRP)).toBe(150000);
    expect(Number(row.ITM_MARGIN)).toBe(7);
    expect(Number(row.KR_OTH_WT)).toBe(0.2);
    expect(Number(row.KR_NET_WT)).toBe(19.5);
    expect(Number(row.KR_GHT_PRC)).toBe(1.5);
    expect(Number(row.KR_GHT_WT)).toBe(0.3);
    expect(Number(row.KR_TOUCH)).toBe(90);
    expect(Number(row.KR_WEST_PRC)).toBe(0.75);
    expect(Number(row.KR_FINE)).toBe(17.6);
    expect(Number(row.KR_LBR_RATE)).toBe(38);
    expect(Number(row.KR_LBR_AMT)).toBe(741);
  });

  it("keeps 'N' as the no-tag sentinel when a line carries no tag", async () => {
    // MAIN_STOCK filters loose stock on TAG_NO='N', so a blank here would silently drop the line out
    // of loose-stock balances.
    await fineInout(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      direction: 'IN',
      partyAc: 'REFINE',
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 5, netWt: 5, touch: 90 }],
    });
    const row = (
      (await owner.$queryRawUnsafe(
        `SELECT "TAG_NO" FROM "INOUT_DETL" WHERE tenant_id=$1 AND "SR_NO"=1`,
        TENANT,
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(String(row.TAG_NO)).toBe('N');
  });
  it('records the acting user and a hidden voucher identity on both header and detail', async () => {
    // Verified before implementing, not inferred: INOUT_DATA and INOUT_DETL both carry MAIN_USER,
    // HD_VCH_NO and VCH_TIME, and this module assigned ZERO of them. A Fine In/Out moves metal between
    // the company and a refinery, so an unattributed one is a metal movement nobody owns. HD_VCH_NO is
    // the hidden identity TEMP_BOOK_DATA and the day book join on.
    const result = await fineInout(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      direction: 'IN',
      partyAc: 'REFINE',
      mainUser: 'fio-user',
      lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 4, netWt: 4, touch: 90 }],
    });

    const header = (
      (await owner.$queryRawUnsafe(
        `SELECT "MAIN_USER","HD_VCH_NO","VCH_TIME" FROM "INOUT_DATA"
          WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        TENANT,
        String(result.vchNo).padStart(5, '0'),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(String(header.MAIN_USER)).toBe('fio-user');
    expect(String(header.HD_VCH_NO ?? '')).not.toBe('');
    expect(header.VCH_TIME).toBeTruthy();

    const detail = (
      (await owner.$queryRawUnsafe(
        `SELECT "MAIN_USER","HD_VCH_NO" FROM "INOUT_DETL"
          WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "SR_NO"=1`,
        TENANT,
        String(result.vchNo).padStart(5, '0'),
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(String(detail.MAIN_USER)).toBe('fio-user');
    // The detail must share the header's hidden identity, or a line cannot be traced to its voucher.
    expect(String(detail.HD_VCH_NO)).toBe(String(header.HD_VCH_NO));
  });
});
