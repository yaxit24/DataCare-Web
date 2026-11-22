/**
 * Balance TrFr: which tags, orders and approval lines the desktop carries (database layer; selections only, the
 * writes wait on cases.md Q1/Q8). Expected sets are worked from the desktop queries:
 *   tags        BtmSchm.cs:2362  HAVING SUM(±VCH_SRNO) > 0, VCH_DATE <= closing date, TAG_NO <> 'N'
 *   orders      BtmSchm.cs:3024  HAVING Σ('+' − others) of amount + gold + silver > 0, VCH_DATE <= closing date
 *   approvals   BtmSchm.cs:4123-4125, :4142  APR ISU lines not named by an APR RTN, SALES or WH SALES/RATE CUT line
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  openApprovalLines,
  openOrders,
  tagsInStock,
} from '../src/modules/ops/balanceTransferSelect.js';
import { confirmImplicitCarry } from '../src/modules/ops/balanceTransfer.js';
import { barTagAvailableSql } from '../src/modules/shared/stockSql.js';
import { diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'wp23-balance-trfr-sel';
const CO = '01';
const LC = '01';
const FROM = '2025-2026';
const TO = '2026-2027';
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: FROM, clDate: '2026-03-31' };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const r of rows)
    await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, TENANT);
}

let n = 0;
async function tagMove(tag: string, sign: '+' | '-', srno: number, date = '2025-10-01', it = 'I4') {
  n += 1;
  await exec(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","VCH_SRNO")
     VALUES ($1,$2,$3,$4,'TGO',$5,$6::date,$7,$8,$9,1,$10)`,
    TENANT,
    CO,
    LC,
    FROM,
    String(n).padStart(5, '0'),
    date,
    it,
    tag,
    sign,
    srno,
  );
}
async function barDetl(tag: string, srno: number, it = 'I4') {
  await exec(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO","ITM_GWT")
     VALUES ($1,$2,$3,$4,'TGO','00001',1,$5,$6,$7,5)`,
    TENANT,
    CO,
    LC,
    FROM,
    it,
    tag,
    srno,
  );
}

/**
 * The implicit carry (Q1/Q8, decided 2026-11-22 by the architect, owner may override): the button checks the Transfer
 * Year, counts what stays open, writes nothing; pressing it twice changes nothing.
 */
async function pressTwice(dataset: 'tag-stock' | 'sales-order' | 'approval') {
  const before = await snapshotTenant(owner, TENANT);
  const first = await confirmImplicitCarry(runtime, scope, dataset, {
    toYear: TO,
    mainUser: 'TESTER',
  });
  const second = await confirmImplicitCarry(runtime, scope, dataset, {
    toYear: TO,
    mainUser: 'TESTER',
  });
  expect(second).toEqual(first);
  expect(first).toMatchObject({ rows: 0, toYear: TO, message: 'Process Are Complete....' });
  expect(diffTenant(before, await snapshotTenant(owner, TENANT))).toEqual({
    added: {},
    removed: {},
  });
  return first.open;
}
/** The web's own tag on-hand (every reader of tag stock uses barTagAvailableSql; it has no year filter). */
const tagOnHand = async () =>
  (
    (await withTenant(owner, TENANT, (tx) =>
      tx.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "BAR_DETL" b WHERE b.tenant_id=$1 AND ${barTagAvailableSql('b')}`,
        TENANT,
      ),
    )) as { n: number }[]
  )[0]!.n;

databaseDescribe('Balance TrFr selections (read-only)', () => {
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });
  beforeEach(async () => {
    await wipe();
    for (const [year, op, cl] of [
      [FROM, '2025-04-01', '2026-03-31'],
      [TO, '2026-04-01', '2027-03-31'],
    ] as const)
      await exec(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,$4,$5::timestamp)`,
        TENANT,
        CO,
        year,
        op,
        cl,
      );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES ($1,$2,'I4','RING','G')`,
      TENANT,
      CO,
    );
  });

  it('balance-transfer.tag.rule.carried-when-positive: in stock at the closing date, tagged only', async () => {
    await barDetl('T001', 1);
    await tagMove('T001', '+', 1);
    await barDetl('T002', 1);
    await tagMove('T002', '+', 1);
    await tagMove('T002', '-', 1, '2026-03-28');
    await barDetl('T003', 1);
    await tagMove('T003', '+', 1, '2026-04-02');
    await barDetl('N', 1);
    await tagMove('N', '+', 1);
    const before = await snapshotTenant(owner, TENANT);
    expect(await tagsInStock(runtime, scope)).toEqual([
      { itCode: 'I4', tagNo: 'T001', vchSrNo: 1 },
    ]);
    expect(diffTenant(before, await snapshotTenant(owner, TENANT))).toEqual({
      added: {},
      removed: {},
    });
  });

  it("balance-transfer.identity.tag-closing-equals-opening and rerun (Tag Stock): next year's tag stock is the closing one; two presses write nothing", async () => {
    await barDetl('T001', 1);
    await tagMove('T001', '+', 1);
    await barDetl('T002', 1);
    await tagMove('T002', '+', 1);
    await tagMove('T002', '-', 1, '2026-03-28');
    await barDetl('T003', 1);
    await tagMove('T003', '+', 1, '2026-02-01');
    const onHand = await tagOnHand();
    expect(onHand).toBe(2);
    expect(await pressTwice('tag-stock')).toBe(2);
    expect(await tagOnHand()).toBe(onHand);
  });

  it('balance-transfer.order.rule.open-selection: O1 and O4 are open; O2, O3, O5, O6 are not', async () => {
    const order = async (no: string, date: string) =>
      exec(
        `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","ADV_AMT","HD_VCH_NO")
         VALUES ($1,$2,$3,$4,'SOR',$5,$6::date,'00500',500,$5)`,
        TENANT,
        CO,
        LC,
        FROM,
        no,
        date,
      );
    let adjNo = 0;
    const adj = async (no: string, sign: '+' | '-', amt: number, gold = 0, silver = 0) =>
      exec(
        `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","ORD_LC","ORD_YRCD","ORD_DBCD","ORD_NO","ORD_SIGN","ORD_AMT","ORD_GOLD","ORD_SILVER","SR_NO")
         VALUES ($1,$2,$3,$4,'ORA',$10,$3,$4,'SOR',$5,$6,$7,$8,$9,1)`,
        TENANT,
        CO,
        LC,
        FROM,
        no,
        sign,
        amt,
        gold,
        silver,
        String((adjNo += 1)).padStart(5, '0'),
      );
    await order('00001', '2025-06-01');
    await adj('00001', '+', 10000);
    await adj('00001', '-', 4000);
    await order('00002', '2025-06-02');
    await adj('00002', '+', 8000);
    await adj('00002', '-', 8000);
    await order('00003', '2026-04-02');
    await adj('00003', '+', 5000);
    await order('00004', '2025-06-04');
    await adj('00004', '+', 0, 5);
    await adj('00004', '-', 0, 2);
    await order('00005', '2025-06-05');
    await adj('00005', '+', 0, 0, 1);
    await adj('00005', '-', 0, 0, 1);
    await order('00006', '2025-06-06');
    expect(await openOrders(runtime, scope)).toEqual([
      {
        coYear: FROM,
        coBook: 'SOR',
        vchNo: '00001',
        acCode: '00500',
        advAmt: 500,
        adjAmount: 4000,
        adjGold: 0,
        adjSilver: 0,
      },
      {
        coYear: FROM,
        coBook: 'SOR',
        vchNo: '00004',
        acCode: '00500',
        advAmt: 500,
        adjAmount: 0,
        adjGold: 2,
        adjSilver: 0,
      },
    ]);
    // balance-transfer.identity.order-open-equals-carried and rerun.sales-order-replaces: the button reports the same
    // two open orders, and the open set is the same before and after two presses.
    const open = await openOrders(runtime, scope);
    expect(await pressTwice('sales-order')).toBe(2);
    expect(await openOrders(runtime, scope)).toEqual(open);
  });

  it('balance-transfer.approval.rule.open-selection: A1 open; A2 returned and A3 sold are not; year N unchanged', async () => {
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK")
       VALUES ($1,$2,$3,'AIS','Approval Isu','APR ISU'), ($1,$2,$3,'ARN','Approval Rtn','APR RTN')`,
      TENANT,
      CO,
      LC,
    );
    for (const [sr, tag] of [
      [1, 'A1'],
      [2, 'A2'],
      [3, 'A3'],
    ] as const)
      await exec(
        `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","TAG_NO","BOOK_NAME","ISU_REC","VCH_DATE")
         VALUES ($1,$2,$3,$4,'AIS','00003',$5,$5,$6,'APR ISU','N','2025-11-01')`,
        TENANT,
        CO,
        LC,
        FROM,
        sr,
        tag,
      );
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","TAG_NO","BOOK_NAME","ISU_NO","ISU_YRCD","ISU_DBCD","ISU_SRNO","VCH_DATE")
       VALUES ($1,$2,$3,$4,'ARN','00001',1,1,'A2','APR RTN','00003',$5,'AIS',2,'2025-12-01')`,
      TENANT,
      CO,
      LC,
      FROM,
      FROM,
    );
    await exec(
      `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","TAG_NO","BOOK_NAME","ISU_NO","ISU_YRCD","ISU_DBCD","ISU_SRNO","VCH_DATE")
       VALUES ($1,$2,$3,$4,'SAL','00009',1,'A3','SALES','00003',$5,'AIS',3,'2026-01-15')`,
      TENANT,
      CO,
      LC,
      FROM,
      FROM,
    );
    const before = await snapshotTenant(owner, TENANT);
    expect(await openApprovalLines(runtime, scope)).toEqual([
      { coYear: FROM, coBook: 'AIS', vchNo: '00003', srNo: 1, tagNo: 'A1' },
    ]);
    expect(diffTenant(before, await snapshotTenant(owner, TENANT))).toEqual({
      added: {},
      removed: {},
    });
    // Finding 4: an issue dated after the closing date is not open at the close, and a return dated after the closing
    // date does not close a line that was out at the close.
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","TAG_NO","BOOK_NAME","ISU_REC","VCH_DATE")
       VALUES ($1,$2,$3,$4,'AIS','00004',1,1,'A4','APR ISU','N','2026-04-05')`,
      TENANT,
      CO,
      LC,
      TO,
    );
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","TAG_NO","BOOK_NAME","ISU_NO","ISU_YRCD","ISU_DBCD","ISU_SRNO","VCH_DATE")
       VALUES ($1,$2,$3,$4,'ARN','00002',1,1,'A1','APR RTN','00003',$5,'AIS',1,'2026-04-10')`,
      TENANT,
      CO,
      LC,
      TO,
      FROM,
    );
    expect(await openApprovalLines(runtime, scope)).toEqual([
      { coYear: FROM, coBook: 'AIS', vchNo: '00003', srNo: 1, tagNo: 'A1' },
    ]);
    // balance-transfer.identity.approval-open-equals-carried and rerun.approval-replaces: only A1 stays open, and
    // two presses write nothing.
    expect(await pressTwice('approval')).toBe(1);
    expect(await openApprovalLines(runtime, scope)).toHaveLength(1);
  });
});
