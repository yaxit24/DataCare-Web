/**
 * Balance TrFr through the web's real readers (WP-23 review findings 1-3; the opening model decided 2026-11-22 by the
 * architect, owner may override): every reader shows each money, fine and stock balance exactly once, in both years,
 * whatever order Year-End Close, Balance TrFr and Item Opening Save run in, and on every re-run.
 *
 * Seed (Cr-positive): party P1 Cr 5000.00 (2025-06-01) and Dr 1500.75 (2026-03-31), closing 3499.25 Cr; cash X5 the
 * other side (Dr 5000.00, Cr 1500.75), closing 3499.25 Dr; in the next year P1 Dr 1000.00 / X5 Cr 1000.00 on
 * 2026-05-01. Item I1 untagged: IN 10 pcs 100.500 / 98.250, OUT 4 pcs 40.200 / 39.300, closing 6 / 60.300 / 58.950.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { carryAcBalance, carryItemStock } from '../src/modules/ops/balanceTransfer.js';
import { yearEndClose } from '../src/modules/ops/yearEnd.js';
import { accountLedgerReport } from '../src/modules/reports/accountLedgerReport.js';
import { trialBalanceFull } from '../src/modules/reports/reports8.js';
import {
  deletePartyOpening,
  getPartyOpening,
  savePartyOpening,
} from '../src/modules/finance/partyOpening.js';
import { partyBalance } from '../src/modules/finance/partyBalance.js';
import { onHandNet } from '../src/modules/stock/stock.js';
import {
  deleteItemOpening,
  getItemOpening,
  saveItemOpening,
} from '../src/modules/stock/itemOpening.js';
import { readFileSync } from 'node:fs';
import { carryForwardOpenings } from '../src/modules/masters/year.js';
import { groupSummary } from '../src/modules/reports/reports3.js';
import { voucherRegister } from '../src/modules/reports/voucherRegister.js';
import { dataRefresh } from '../src/modules/utilities/dataRefresh.js';
import { snapshotTenant } from './support/tenantSnapshot.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'wp23-balance-trfr-read';
const CO = '01';
const LC = '01';
const FROM = '2025-2026';
const TO = '2026-2027';
const USER = 'TESTER';
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scopeN = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: FROM };
const scopeN1 = { ...scopeN, coYear: TO };
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
async function leg(ac: string, cr: number, dr: number, date: string, year = FROM) {
  n += 1;
  await exec(
    `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","CR_AMT","DR_AMT","IT_TYPE","DATA_TYPE","VCH_TYPE","LEDR_KEY")
     VALUES ($1,$2,$3,$4,'JV',$5,$6::date,$7,$8,$9,'A','A','JV',$10)`,
    TENANT,
    CO,
    LC,
    year,
    String(n).padStart(5, '0'),
    date,
    ac,
    cr,
    dr,
    `WP23R-${n}`,
  );
}
async function stock(sign: '+' | '-', pcs: number, gross: number, net: number, date: string) {
  n += 1;
  await exec(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
     VALUES ($1,$2,$3,$4,'PUR',$5,$6::date,'I1','N',$7,$8,$9,$10)`,
    TENANT,
    CO,
    LC,
    FROM,
    String(n).padStart(5, '0'),
    date,
    sign,
    pcs,
    gross,
    net,
  );
}

/** The Account Ledger of P1 for a date range: opening and closing (Cr-positive), the cross-year reader. */
const ledger = async (fromDate: string, toDate: string, acCode = 'P1') => {
  const r: any = await accountLedgerReport(
    runtime,
    { tenantId: TENANT, coCode: CO, lcCode: LC },
    { view: 'detail', acCode, fromDate, toDate },
  );
  return { opening: r.opening.amount, closing: r.closing.amount };
};
/** Trial balance (Dr − Cr per account) for one year, or across years when `year` is undefined. */
const trial = async (year?: string) => {
  const r = await trialBalanceFull(runtime, { tenantId: TENANT, coCode: CO, coYear: year } as any);
  return Object.fromEntries(r.rows.map((x: any) => [x.acCode, x.balance]));
};
/** The opening rows of the next year, for order and re-run comparisons (no row ids, users or keys). */
const openings = async () => {
  const snap = await snapshotTenant(owner, TENANT, ['OP_DATA', 'AC_DATA']);
  const keep = (table: string, cols: string[]) =>
    (snap.get(table) ?? [])
      .map((r) => JSON.parse(r) as Record<string, unknown>)
      .filter((r) => r.CO_YEAR === TO && r.CO_BOOK === '000')
      .map((r) => JSON.stringify(cols.map((c) => r[c])))
      .sort();
  return {
    op: keep('OP_DATA', ['AC_CODE', 'DATA_TYPE', 'OP_AMT', 'OP_SIGN', 'FINE_BAL', 'SL_FINE_BAL']),
    legs: keep('AC_DATA', [
      'AC_CODE',
      'CR_AMT',
      'DR_AMT',
      'IT_TYPE',
      'FINE_WT',
      'BOOK_NAME',
      'LC_CODE',
    ]),
  };
};
const yearEnd = () => yearEndClose(runtime, { scope: scopeN as any, fromYear: FROM, toYear: TO });
const balanceTrfr = () => carryAcBalance(runtime, scopeN, { toYear: TO, mainUser: USER });

databaseDescribe('Balance TrFr through the real readers', () => {
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });
  beforeEach(async () => {
    await wipe();
    await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
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
    for (const [code, gr] of [
      ['P1', '1'],
      ['X5', '5'],
    ] as const)
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MAIN_GR") VALUES ($1,$2,$3,$4,$5,$6)`,
        TENANT,
        CO,
        LC,
        code,
        `ACCOUNT ${code}`,
        gr,
      );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","ITEM_RATE","AVG_TOUCH")
       VALUES ($1,$2,'I1','ITEM I1','G','GR1',50,91.6)`,
      TENANT,
      CO,
    );
    await leg('P1', 5000, 0, '2025-06-01');
    await leg('X5', 0, 5000, '2025-06-01');
    await leg('P1', 0, 1500.75, '2026-03-31');
    await leg('X5', 1500.75, 0, '2026-03-31');
    await leg('P1', 0, 1000, '2026-05-01', TO);
    await leg('X5', 1000, 0, '2026-05-01', TO);
    await stock('+', 10, 100.5, 98.25, '2025-10-01');
    await stock('-', 4, 40.2, 39.3, '2026-03-31');
  });

  /** What every reader must show, carried or not, after any order of the writers. */
  async function expectEachBalanceOnce() {
    // Account Ledger (cross-year): year N closes at 3499.25 Cr, year N+1 opens at 3499.25 Cr and closes at 2499.25 Cr.
    expect(await ledger('2025-04-01', '2026-03-31')).toEqual({ opening: 0, closing: 3499.25 });
    expect(await ledger('2026-04-01', '2027-03-31')).toEqual({
      opening: 3499.25,
      closing: 2499.25,
    });
    // Trial balance, year N: the year's own vouchers only.
    expect(await trial(FROM)).toMatchObject({ P1: -3499.25, X5: 3499.25 });
    // Trial balance, year N+1 (year-scoped): the carried opening plus the year's vouchers.
    expect(await trial(TO)).toMatchObject({ P1: -2499.25, X5: 2499.25 });
    // Trial balance across years: history only, nothing carried counted again.
    expect(await trial()).toMatchObject({ P1: -2499.25, X5: 2499.25 });
    // Party Opening of N+1 and the cross-year party balance.
    expect(await getPartyOpening(runtime, scopeN1, 'P1')).toMatchObject({
      amount: 3499.25,
      sign: 'C',
    });
    expect(await partyBalance(runtime, scopeN, 'P1')).toMatchObject({
      amount: 2499.25,
      sign: 'Cr',
    });
  }

  it('finding 1: after Balance TrFr every reader shows the party balance once, in both years', async () => {
    await balanceTrfr();
    await yearEnd(); // the cash account's opening comes from Year-End Close
    await expectEachBalanceOnce();
  });

  it('finding 3: Year-End Close then Balance TrFr equals Balance TrFr then Year-End Close; re-runs change nothing', async () => {
    await yearEnd();
    await balanceTrfr();
    const yeFirst = await openings();
    // Start the next year again and run the two menus the other way round.
    await exec(`DELETE FROM "OP_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2`, TENANT, TO);
    await exec(
      `DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"='000'`,
      TENANT,
      TO,
    );
    await balanceTrfr();
    await yearEnd();
    expect(await openings()).toEqual(yeFirst);
    await balanceTrfr();
    await yearEnd();
    await balanceTrfr();
    expect(await openings()).toEqual(yeFirst);
    // One party row, one party leg, one cash leg.
    expect(yeFirst.op).toHaveLength(1);
    expect(yeFirst.legs).toHaveLength(2);
    await expectEachBalanceOnce();
  });

  it('finding 3 (decision 3): a carried opening cannot be edited or deleted on Party Opening; the balances stay once', async () => {
    await balanceTrfr();
    await yearEnd();
    const message = `This opening was carried from ${FROM}; correct the closing year and run Balance TrFr again`;
    await expect(
      savePartyOpening(runtime, {
        scope: scopeN1,
        acCode: 'P1',
        amount: 10,
        sign: 'C',
        mainUser: USER,
      }),
    ).rejects.toThrow(message);
    await expect(deletePartyOpening(runtime, scopeN1, 'P1', USER)).rejects.toThrow(message);
    await expectEachBalanceOnce();
  });

  it('decision 1: Year Create Carry Forward is the same single writer, in any order with the other two menus', async () => {
    await carryForwardOpenings(runtime, scopeN, FROM, TO, USER);
    const viaYearCreate = await openings();
    await expectEachBalanceOnce();
    await balanceTrfr();
    await yearEnd();
    await carryForwardOpenings(runtime, scopeN, FROM, TO, USER);
    expect(await openings()).toEqual(viaYearCreate);
    await expectEachBalanceOnce();
  });

  it('finding 4 (decision 4): group summary, voucher register and Data Refresh totals across years ignore carried openings', async () => {
    await balanceTrfr();
    await yearEnd();
    // History: Dr 5000.00 + 1500.75 + 1000.00 = 7500.75, Cr the same.
    const groups = await groupSummary(runtime, { tenantId: TENANT, coCode: CO } as any);
    expect(Math.round(groups.rows.reduce((t: number, r: any) => t + Number(r.dr), 0) * 100)).toBe(
      750075,
    );
    const register = await voucherRegister(runtime, { tenantId: TENANT, coCode: CO } as any);
    expect(register.rows.filter((r: any) => r.book === '000')).toEqual([]);
    const refresh = await dataRefresh(runtime, { tenantId: TENANT, coCode: CO });
    expect(refresh.ledger).toMatchObject({ dr: 7500.75, cr: 7500.75, diff: 0 });
  });

  it('decision 2: the migration relabels a legacy Year-End Close leg as carried, so no reader adds it', async () => {
    for (const [ac, cr, dr] of [
      ['P1', 3499.25, 0],
      ['X5', 0, 3499.25],
    ] as const)
      await exec(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","BOOK_NAME","AC_CODE","CR_AMT","DR_AMT","IT_TYPE","LEDR_KEY")
         VALUES ($1,$2,$3,$4,'000','1','ACOP','OPENING',$5,$6,$7,'A',$8)`,
        TENANT,
        CO,
        LC,
        TO,
        ac,
        cr,
        dr,
        `LEGACY-${ac}`,
      );
    const sql = readFileSync(
      new URL(
        '../../../packages/db/prisma/migrations/20261122100000_legacy_year_end_openings_carried/migration.sql',
        import.meta.url,
      ),
      'utf8',
    );
    await owner.$executeRawUnsafe(sql);
    await owner.$executeRawUnsafe(sql); // idempotent
    const relabelled = await withTenant(owner, TENANT, (tx) =>
      tx.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "BOOK_NAME"='BAL TRFR'`,
        TENANT,
      ),
    );
    expect(relabelled).toEqual([{ n: 2 }]);
    // Before any new carry the ledger already shows the opening once (the relabelled leg is excluded).
    expect(await ledger('2026-04-01', '2027-03-31')).toEqual({
      opening: 3499.25,
      closing: 2499.25,
    });
    await balanceTrfr();
    await yearEnd();
    await expectEachBalanceOnce();
  });

  it('finding 2: Item Stock carry, then Item Opening Save in N+1, change no stock balance; re-runs too', async () => {
    const stockScope = { CO_CODE: CO, LC_CODE: LC };
    const before = await onHandNet(runtime, TENANT, stockScope);
    expect(before).toMatchObject({ pcs: 6, gwt: 60.3, nwt: 58.95 });
    await carryItemStock(runtime, scopeN, { toYear: TO, mainUser: USER });
    const grid = await getItemOpening(runtime, scopeN1, 'G');
    expect(grid.rows.find((r) => r.itCode === 'I1')).toMatchObject({ pcs: 6, netWt: 58.95 });
    await saveItemOpening(runtime, {
      scope: scopeN1,
      type: 'G',
      rows: grid.rows,
      expectedVersion: grid.version,
      mainUser: USER,
    });
    expect(await onHandNet(runtime, TENANT, stockScope)).toEqual(before);
    // The carried row keeps its marker through the save, so the next carry and save stay exact.
    await carryItemStock(runtime, scopeN, { toYear: TO, mainUser: USER });
    const again = await getItemOpening(runtime, scopeN1, 'G');
    await saveItemOpening(runtime, {
      scope: scopeN1,
      type: 'G',
      rows: again.rows,
      expectedVersion: again.version,
      mainUser: USER,
    });
    expect(await onHandNet(runtime, TENANT, stockScope)).toEqual(before);
    // Decision 3: a change or removal of the carried row, and a delete of the type, are refused.
    const message = `This opening was carried from ${FROM}; correct the closing year and run Balance TrFr again`;
    const latest = await getItemOpening(runtime, scopeN1, 'G');
    await expect(
      saveItemOpening(runtime, {
        scope: scopeN1,
        type: 'G',
        rows: latest.rows.map((r) => (r.itCode === 'I1' ? { ...r, pcs: 7 } : r)),
        expectedVersion: latest.version,
        mainUser: USER,
      }),
    ).rejects.toThrow(message);
    await expect(deleteItemOpening(runtime, scopeN1, 'G', latest.version)).rejects.toThrow(message);
    expect(await onHandNet(runtime, TENANT, stockScope)).toEqual(before);
  });

  it('decision 5: a hand-keyed N+1 Item Opening of an item with no closing-year stock stays through the carry', async () => {
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","ITEM_RATE") VALUES ($1,$2,'I9','ITEM I9','G','GR1',0)`,
      TENANT,
      CO,
    );
    const stockScope = { CO_CODE: CO, LC_CODE: LC };
    const grid = await getItemOpening(runtime, scopeN1, 'G');
    await saveItemOpening(runtime, {
      scope: scopeN1,
      type: 'G',
      rows: grid.rows.map((r) => (r.itCode === 'I9' ? { ...r, pcs: 2, grossWt: 8, netWt: 8 } : r)),
      expectedVersion: grid.version,
      mainUser: USER,
    });
    const withHandKeyed = await onHandNet(runtime, TENANT, stockScope);
    await carryItemStock(runtime, scopeN, { toYear: TO, mainUser: USER });
    await carryItemStock(runtime, scopeN, { toYear: TO, mainUser: USER });
    expect(await onHandNet(runtime, TENANT, stockScope)).toEqual(withHandKeyed);
    const after = await getItemOpening(runtime, scopeN1, 'G');
    expect(after.rows.filter((r) => r.saved).map((r) => [r.itCode, r.pcs])).toEqual([
      ['I1', 6],
      ['I9', 2],
    ]);
  });

  it('finding 2: a hand-keyed N+1 Item Opening is replaced by the carry with its stock legs (none left behind)', async () => {
    const stockScope = { CO_CODE: CO, LC_CODE: LC };
    const before = await onHandNet(runtime, TENANT, stockScope);
    const grid = await getItemOpening(runtime, scopeN1, 'G');
    await saveItemOpening(runtime, {
      scope: scopeN1,
      type: 'G',
      rows: grid.rows.map((r) =>
        r.itCode === 'I1' ? { ...r, pcs: 3, grossWt: 30, netWt: 29 } : r,
      ),
      expectedVersion: grid.version,
      mainUser: USER,
    });
    // A hand-keyed opening of a later year posts stock, as the Item Opening screen does today.
    expect((await onHandNet(runtime, TENANT, stockScope)).pcs).toBe(before.pcs + 3);
    await carryItemStock(runtime, scopeN, { toYear: TO, mainUser: USER });
    expect(await onHandNet(runtime, TENANT, stockScope)).toEqual(before);
  });
});
