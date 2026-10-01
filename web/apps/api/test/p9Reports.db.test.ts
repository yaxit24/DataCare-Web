import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { huidReport } from '../src/modules/reports/huid.js';
import { stockLevelReport } from '../src/modules/reports/stockLevel.js';
import { billProfitReport } from '../src/modules/reports/billProfitReport.js';
import { physicalStockReport } from '../src/modules/reports/physicalStock.js';
import { movementReport } from '../src/modules/reports/movement.js';

/**
 * P9 — the three new desktop report workflows, locked in.
 *
 * WHY THESE NEED TESTS AND NOT JUST A LIVE LOOK
 * All three were verified by calling the live stack and reading the CSV, and that is how the
 * bill-profit defect was found: my filter used `ITM_SIGN = '-'` alone where the desktop uses
 * `ITM_SIGN = '-' AND TR_TYPE = 'S' AND TAG_NO <> 'N'`, so tag-generation movements appeared as large
 * NEGATIVE profits. The HTTP status was 200 and the CSV looked plausible. Nothing would have caught a
 * regression, so the filter and the cost basis are asserted here.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'p9-reports';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-06-01';
const DAY_DATE = new Date(`${DAY}T00:00:00Z`);

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
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

/** A tag with its karigar cost basis, which is what the profit report prices against. */
async function tag(tagNo: string, vchSrno: number, huid: string | null): Promise<void> {
  await exec(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
      "TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE",
      "KR_NET_WT","KR_TOUCH","KR_FINE","TAG_COST","HM_ID","HM_ID_WT")
     VALUES ($1,$2,$3,$4,'TOP','00001',$5,$6,$5,'GOLD',1,10.2,10,91.6,9.16,10,90,9,100,$7,5)`,
    TENANT,
    CO,
    LC,
    YEAR,
    vchSrno,
    tagNo,
    huid,
  );
}

/** A stock movement. `trType` and `sign` decide whether the profit report counts it. */
async function movement(
  tagNo: string,
  vchSrno: number,
  vchType: string,
  trType: string,
  sign: string,
): Promise<void> {
  await exec(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
      "VCH_DATE","VCH_TYPE","BOOK_NAME","AC_CODE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN",
      "ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","LBR_AMT","OTH_AMT","NET_AMT")
     VALUES ($1,$2,$3,$4,'SAL','00001',$5,$6,$7,'SALES','CUST',$8,$5,'GOLD',$9,$10,
             1,1,10.2,10,9.16,60000,4000,0,64000)`,
    TENANT,
    CO,
    LC,
    YEAR,
    vchSrno,
    DAY_DATE,
    vchType,
    tagNo,
    trType,
    sign,
  );
}

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('P9 report workflows', () => {
  beforeEach(async () => {
    await wipe();
    await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","AVG_TOUCH")
       VALUES ($1,$2,'GOLD','Gold 22K','G',90)`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'CUST','Test Customer')`,
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

  it('defaults to desktop All and keeps alphanumeric HUIDs as text', async () => {
    await tag('TAG-H1', 1, 'HUID7AB');
    await tag('TAG-H2', 2, null); // not hallmarked
    const report = await huidReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    expect(report.rows.map((r) => r.tagNo)).toEqual(['TAG-H1', 'TAG-H2']);
    // A HUID contains letters; reading it as a number would have destroyed it.
    expect(report.rows[0]!.huid).toBe('HUID7AB');
    expect(typeof report.rows[0]!.huid).toBe('string');
    expect(report.totals.hallmarkedTags).toBe(1);
    expect(report.totals.slots).toBe(1);
  });

  it('supports explicit With HUID and Without HUID modes', async () => {
    await tag('TAG-H1', 1, 'HUID7AB');
    await tag('TAG-H2', 2, null);
    const withHuid = await huidReport(
      runtime,
      TENANT,
      { CO_CODE: CO, LC_CODE: LC },
      { hallmark: 'with' },
    );
    const withoutHuid = await huidReport(
      runtime,
      TENANT,
      { CO_CODE: CO, LC_CODE: LC },
      { hallmark: 'without' },
    );
    expect(withHuid.rows.map((r) => r.tagNo)).toEqual(['TAG-H1']);
    expect(withoutHuid.rows.map((r) => r.tagNo)).toEqual(['TAG-H2']);
  });

  it('reports item labour bands, which is what ItStk Level actually holds', async () => {
    // Not a reorder level: ITM_WT_MAST bands LABOUR RATES by weight.
    await exec(
      `INSERT INTO "ITM_WT_MAST"(tenant_id,"CO_CODE","IT_CODE","SR_NO","FROM_WT","TO_WT","MIN_PCS",
        "LBR_TYPE","LBR_RATE","GHT_PRC","IT_DESIGN")
       VALUES ($1,$2,'GOLD',1,0,10,1,'G',45,1.5,NULL),
              ($1,$2,'GOLD',2,10.001,25,1,'G',40,1.5,'D-101')`,
      TENANT,
      CO,
    );
    const report = await stockLevelReport(runtime, TENANT, { CO_CODE: CO });
    expect(report.rows).toHaveLength(2);
    expect(report.rows[0]!.fromWt).toBe(0);
    expect(report.rows[0]!.toWt).toBe(10);
    expect(report.rows[0]!.labourRate).toBe(45);
    expect(report.rows[0]!.itName).toBe('Gold 22K');
    // An item with more than one band charges differently at different weights.
    expect(report.totals.bandedItems).toBe(1);
    expect(report.totals.designSpecific).toBe(1);
  });

  it('prices bill profit against the TAG karigar basis', async () => {
    await tag('TAG-P1', 1, null);
    await movement('TAG-P1', 1, 'MIXSL', 'S', '-');
    const report = await billProfitReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    expect(report.rows).toHaveLength(1);
    const row = report.rows[0]!;
    // The karigar basis comes from BAR_DETL, not the movement — this is the column set karigar.ts
    // failed to write, which would have reported zero cost and therefore pure profit.
    expect(row.karigarNetWt).toBe(10);
    expect(row.karigarFine).toBe(9);
    expect(row.basis).toBe('karigar-fine');
    // cost = KR_FINE x saleRate + TAG_COST; with no RATE_MAST row the rate is 0, so cost is TAG_COST.
    expect(row.cost).toBe(100);
    expect(row.profit).toBe(64000 - 100);
  });

  it('excludes non-sale movements and untagged lines, as the desktop WHERE does', async () => {
    // THE DEFECT THIS LOCKS OUT. Filtering on ITM_SIGN='-' alone pulled in tag-generation movements,
    // which have no realisation, so they showed large NEGATIVE profits and dragged the total down.
    // The desktop clause is ITM_SIGN='-' AND TR_TYPE='S' AND TAG_NO <> 'N'.
    await tag('TAG-P1', 1, null);
    await movement('TAG-P1', 1, 'MIXSL', 'S', '-'); // a real sale — counted
    await movement('TAG-P1', 2, 'TGEN', 'O', '-'); // tag generation — must NOT count
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
       VALUES ($1,$2,$3,$4,'SAL','00002',9,$5,'MIXSL','N',0,'GOLD','S','-',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY_DATE,
    ); // untagged sale — must NOT count

    const report = await billProfitReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    expect(report.rows).toHaveLength(1);
    expect(report.rows[0]!.vchType).toBe('MIXSL');
    expect(report.rows[0]!.tagNo).toBe('TAG-P1');
    // No negative-profit row can reach the total.
    expect(report.totals.profit).toBeGreaterThan(0);
  });
  it('computes physical-stock variance per TAG INSTANCE, not per tag number', async () => {
    // The desktop nets MAIN_STOCK signs per instance (TAG_NO + VCH_SRNO). Netting by tag NUMBER instead
    // would let one instance's shortage cancel another's surplus and hide a real discrepancy.
    await tag('TAG-V', 1, null);
    await tag('TAG-V', 2, null); // same number, second instance
    await movement('TAG-V', 1, 'TAGOP', 'I', '+'); // instance 1 in
    await movement('TAG-V', 2, 'TAGOP', 'I', '+'); // instance 2 in
    await movement('TAG-V', 2, 'MIXSL', 'S', '-'); // instance 2 sold again -> net 0

    const report = await physicalStockReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    const byInstance = new Map(report.rows.map((r) => [r.tagId, r]));
    expect(byInstance.get(1)!.bookPcs).toBe(1);
    expect(byInstance.get(2)!.bookPcs).toBe(0);
    // Two instances are reported separately rather than collapsed into one net row.
    expect(report.rows).toHaveLength(2);
  });

  it('reports approval and employee issue, so an off-shelf tag is not a phantom shortage', async () => {
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_NWT","APR_ISU","EMP_ISU")
       VALUES ($1,$2,$3,$4,'TOP','00002',1,'TAG-A',1,'GOLD',1,5,'Y','N')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await movement('TAG-A', 1, 'TAGOP', 'I', '+');
    const report = await physicalStockReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    const row = report.rows.find((r) => r.tagNo === 'TAG-A')!;
    expect(row.approvalIssued).toBe(true);
    expect(row.employeeIssued).toBe(false);
    expect(report.totals.onApproval).toBe(1);
  });
  it('nets stock movement by SIZE, which no other report groups by', async () => {
    // The merchandising question: a range can look healthy in total while every saleable size is gone.
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "TAG_NO","VCH_SRNO","IT_CODE","ITM_SIZE","DESIGN_NO","ITM_PCS","ITM_NWT")
       VALUES ($1,$2,$3,$4,'TOP','00003',1,'RING-14',1,'GOLD','14','D-R1',1,5),
              -- SAME tag number, two INSTANCES, and deliberately DIFFERENT sizes. If the join drops
              -- VCH_SRNO, instance 2's movement matches both rows and the sizes cross-contaminate.
              ($1,$2,$3,$4,'TOP','00003',2,'RING-16',2,'GOLD','16','D-R1',1,5),
              ($1,$2,$3,$4,'TOP','00003',3,'RING-16',3,'GOLD','18','D-R1',1,5)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await movement('RING-14', 1, 'TAGOP', 'I', '+'); // size 14: in, stays
    await movement('RING-16', 2, 'TAGOP', 'I', '+'); // instance 2 (size 16): in
    await movement('RING-16', 3, 'TAGOP', 'I', '+'); // instance 3 (size 18): in

    const byItem = await movementReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC });
    // One piece per size. Each movement must attach to ITS OWN instance's size: without the VCH_SRNO
    // join condition, instance 2's and 3's movements each match both BAR_DETL rows and every size
    // doubles.
    expect(byItem.rows.find((r) => r.size === '14')!.pcs).toBe(1);
    expect(byItem.rows.find((r) => r.size === '16')!.pcs).toBe(1);
    expect(byItem.rows.find((r) => r.size === '18')!.pcs).toBe(1);
    expect(byItem.totals.sizes).toBe(3);
    expect(byItem.rows[0]!.name).toBe('Gold 22K');

    // Design mode reports DESIGN_NO in both key and name, as the desktop does.
    const byDesign = await movementReport(
      runtime,
      TENANT,
      { CO_CODE: CO, LC_CODE: LC },
      { mode: 'design' },
    );
    expect(byDesign.rows.every((r) => r.key === 'D-R1' && r.name === 'D-R1')).toBe(true);
  });
});
