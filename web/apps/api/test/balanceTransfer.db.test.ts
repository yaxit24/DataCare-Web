/**
 * Balance TrFr (desktop BtmSchm, Company → Balance TrFr): closing(year N) = opening(year N+1), database layer.
 *
 * Case ids are those of orchestration/work/WP-23/cases.md; every expected figure is worked out by hand from the seeded
 * vouchers with the desktop formulas, never read back from the web:
 *   - Ac Balance, Rtl_AcOpbl (BtmSchm.cs:2759-2812): parties only (`B.AC_MAIN_GR < '3'`), the company and location, to
 *     the closing date (`VCH_DATE <= MCl_dt`); one row per AC_CODE and DATA_TYPE; money Σ(CR − DR) Cr-positive; gold
 *     and silver Σ ±FINE_WT of IT_TYPE 'G' / 'S' ('+' adds); each sum formatted 0.00 / 0.000 after grouping; skipped
 *     when |amount| + |gold| + |silver| = 0; magnitude written with sign 'C' when above 0, else 'D'; OP_DATA book '000',
 *     voucher '00000', DATA_TRFR 'Y', ADD_USER '', ADD_DATE NULL (:2801).
 *   - Item Stock, BtnItmStk (BtmSchm.cs:2921-3002): untagged MAIN_STOCK of the year to the closing date, per item;
 *     fine = Format(net × AVG_TOUCH / 100, "0.000"); ITM_OPBL book '000', VCH_NO = item type, SR_NO = row + 1.
 * The web differs on purpose (cases.md D4, D5): a run replaces the target year only, in one transaction.
 *
 * Column scale: AC_DATA.CR_AMT/DR_AMT keep 2 places and FINE_WT 3, so the x.xx5 half-cases of a single voucher are
 * rounded by the column on insert; the rounding rule itself is pinned by balanceTransferRules.test.ts.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { carryAcBalance, carryItemStock } from '../src/modules/ops/balanceTransfer.js';
import { getPartyOpening, savePartyOpening } from '../src/modules/finance/partyOpening.js';
import { onHandNet } from '../src/modules/stock/stock.js';
import { diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'wp23-balance-trfr';
const OTHER_TENANT = 'wp23-balance-trfr-2';
const CO = '01';
const LC = '01';
const FROM = '2025-2026';
const TO = '2026-2027';
const LATER = '2027-2028';
const USER = 'TESTER';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: FROM };
type Scope = typeof scope;

/** The writers under test (modules/ops/balanceTransfer.ts), called with the session year being closed. */
const carry = {
  ac: (toYear: string, s: Scope = scope) =>
    carryAcBalance(runtime, s, { toYear, mainUser: USER }) as Promise<unknown>,
  item: (toYear: string, s: Scope = scope) =>
    carryItemStock(runtime, s, { toYear, mainUser: USER }) as Promise<unknown>,
};

const exec = (tenant: string, sql: string, ...p: unknown[]) =>
  withTenant(owner, tenant, (tx) => tx.$executeRawUnsafe(sql, ...p));
const query = <T = Record<string, any>>(sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$queryRawUnsafe(sql, ...p)) as Promise<T[]>;

async function wipe(tenant: string) {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const r of rows)
    await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, tenant);
}

async function seedCompany(tenant: string, co = CO) {
  await exec(tenant, `INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, tenant, co);
  for (const [year, op, cl] of [
    [FROM, '2025-04-01', '2026-03-31'],
    [TO, '2026-04-01', '2027-03-31'],
    [LATER, '2027-04-01', '2028-03-31'],
  ])
    await exec(
      tenant,
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,$4,$5::timestamp)`,
      tenant,
      co,
      year,
      op,
      cl,
    );
}

/** A party (AC_MAIN_GR '1' or '2') or another head ('3' and above). */
async function account(code: string, mainGr: string, tenant = TENANT, co = CO) {
  await exec(
    tenant,
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MAIN_GR") VALUES ($1,$2,$3,$4,$5,$6)`,
    tenant,
    co,
    LC,
    code,
    `ACCOUNT ${code}`,
    mainGr,
  );
}

let legNo = 0;
interface LegOpts {
  date?: string;
  year?: string;
  lc?: string;
  co?: string;
  dataType?: string;
  itType?: string;
  sign?: string;
  fine?: number;
  tenant?: string;
}
/** One AC_DATA leg: money Cr and Dr, or a metal line (IT_TYPE, SIGN, FINE_WT). */
async function leg(ac: string, cr: number, dr: number, o: LegOpts = {}) {
  legNo += 1;
  await exec(
    o.tenant ?? TENANT,
    `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE",
        "CR_AMT","DR_AMT","IT_TYPE","SIGN","FINE_WT","DATA_TYPE","VCH_TYPE","LEDR_KEY")
     VALUES ($1,$2,$3,$4,'SAL',$5,$6::date,$7,$8,$9,$10,$11,$12,$13,'JV',$14)`,
    o.tenant ?? TENANT,
    o.co ?? CO,
    o.lc ?? LC,
    o.year ?? FROM,
    String(legNo).padStart(5, '0'),
    o.date ?? '2025-10-01',
    ac,
    cr,
    dr,
    o.itType ?? 'A',
    o.sign ?? '',
    o.fine ?? 0,
    o.dataType ?? 'A',
    `WP23-${legNo}`,
  );
}
const metal = (ac: string, itType: string, sign: '+' | '-', fine: number, o: LegOpts = {}) =>
  leg(ac, 0, 0, { ...o, itType, sign, fine });

async function item(code: string, itType: string, rate: number, touch: number, grCode = 'GR1') {
  await exec(
    TENANT,
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","ITEM_RATE","AVG_TOUCH")
     VALUES ($1,$2,$3,$4,$5,$6,$7,$8)`,
    TENANT,
    CO,
    code,
    `ITEM ${code}`,
    itType,
    grCode,
    rate,
    touch,
  );
}
let stockNo = 0;
async function stock(
  it: string,
  sign: '+' | '-',
  pcs: number,
  gross: number,
  net: number,
  o: { date?: string; year?: string; tag?: string; srno?: number } = {},
) {
  stockNo += 1;
  await exec(
    TENANT,
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","TAG_NO",
        "ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","VCH_SRNO")
     VALUES ($1,$2,$3,$4,'PUR',$5,$6::date,$7,$8,$9,$10,$11,$12,$13)`,
    TENANT,
    CO,
    LC,
    o.year ?? FROM,
    String(stockNo).padStart(5, '0'),
    o.date ?? '2025-10-01',
    it,
    o.tag ?? 'N',
    sign,
    pcs,
    gross,
    net,
    o.srno ?? 1,
  );
}

interface OpRow {
  AC_CODE: string;
  DATA_TYPE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
  OP_AMT: number;
  OP_SIGN: string;
  FINE_BAL: number;
  FINE_SIGN: string;
  SL_FINE_BAL: number;
  SL_FINE_SIGN: string;
  MAIN_USER: string;
  ADD_USER: string | null;
  ADD_DATE: string | null;
  DATA_TRFR: string;
  LC_CODE: string;
}
const opData = (year = TO, lc = LC) =>
  query<OpRow>(
    `SELECT "AC_CODE","DATA_TYPE","CO_YEAR","CO_BOOK","VCH_NO","OP_AMT"::float "OP_AMT","OP_SIGN",
            "FINE_BAL"::float "FINE_BAL","FINE_SIGN","SL_FINE_BAL"::float "SL_FINE_BAL","SL_FINE_SIGN",
            "MAIN_USER","ADD_USER","ADD_DATE","DATA_TRFR","LC_CODE"
       FROM "OP_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "LC_CODE"=$3 ORDER BY "AC_CODE","DATA_TYPE"`,
    TENANT,
    year,
    lc,
  );
/** The compact form the expectations are written in. */
const heads = (rows: OpRow[]) =>
  rows.map((r) => ({
    ac: r.AC_CODE,
    dt: r.DATA_TYPE,
    amt: r.OP_AMT,
    sg: r.OP_SIGN,
    gold: r.FINE_BAL,
    gsg: r.FINE_SIGN,
    silver: r.SL_FINE_BAL,
    ssg: r.SL_FINE_SIGN,
  }));
const row = (
  ac: string,
  amt: number,
  sg: string,
  extra: Partial<{ dt: string; gold: number; gsg: string; silver: number; ssg: string }> = {},
) => ({ ac, dt: 'A', amt, sg, gold: 0, gsg: 'D', silver: 0, ssg: 'D', ...extra });

/** The opening-day ledger legs of year N+1 (book '000'), per account: net money Cr-positive and net fine. */
const openingLegs = (acCode: string, year = TO) =>
  query<{ n: number; money: number; gold: number; silver: number }>(
    `SELECT count(*)::int n, coalesce(sum(coalesce("CR_AMT",0)-coalesce("DR_AMT",0)),0)::float money,
            coalesce(sum(CASE WHEN "IT_TYPE"='G' THEN (CASE WHEN "SIGN"='+' THEN 1 ELSE -1 END)*coalesce("FINE_WT",0) ELSE 0 END),0)::float gold,
            coalesce(sum(CASE WHEN "IT_TYPE"='S' THEN (CASE WHEN "SIGN"='+' THEN 1 ELSE -1 END)*coalesce("FINE_WT",0) ELSE 0 END),0)::float silver
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "AC_CODE"=$3 AND "CO_BOOK"='000'`,
    TENANT,
    year,
    acCode,
  ).then((r) => r[0]!);

const itmOpbl = (year = TO) =>
  query<Record<string, any>>(
    `SELECT "IT_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO"::int "SR_NO","ITM_PCS"::float "ITM_PCS",
            "ITM_GWT"::float "ITM_GWT","ITM_NWT"::float "ITM_NWT","ITM_TOUCH"::float "ITM_TOUCH",
            "ITM_FINE"::float "ITM_FINE","ITM_RATE"::float "ITM_RATE","ITM_AMT"::float "ITM_AMT",
            "LBR_AMT"::float "LBR_AMT","OTH_AMT"::float "OTH_AMT","NET_AMT"::float "NET_AMT",
            "DM_WT"::float "DM_WT","DM_RATE"::float "DM_RATE","DM_AMT"::float "DM_AMT","LBR_RATE"::float "LBR_RATE",
            "MAIN_USER","DATA_TRFR","DATA_TYPE","LC_CODE"
       FROM "ITM_OPBL" WHERE tenant_id=$1 AND "CO_YEAR"=$2 ORDER BY "IT_CODE"`,
    TENANT,
    year,
  );

/** Every row of a table for one year, for "nothing else changed" checks. */
const yearRows = (year: string) =>
  snapshotTenant(owner, TENANT).then((snap) => {
    const out = new Map<string, string[]>();
    for (const [table, rows] of snap)
      out.set(
        table,
        rows.filter((r) => (JSON.parse(r) as Record<string, unknown>).CO_YEAR === year),
      );
    return out;
  });

/** A trigger that fails the INSERT of one row, to prove the run is one transaction (T14). */
async function failInsertOf(table: string, column: string, value: string) {
  await owner.$executeRawUnsafe(`CREATE OR REPLACE FUNCTION wp23_fail() RETURNS trigger LANGUAGE plpgsql AS $f$
    BEGIN
      IF NEW.tenant_id = '${TENANT}' AND NEW."${column}"::text = '${value}' THEN
        RAISE EXCEPTION 'wp23 injected failure';
      END IF;
      RETURN NEW;
    END $f$`);
  await owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS wp23_fail ON "${table}"`);
  await owner.$executeRawUnsafe(
    `CREATE TRIGGER wp23_fail BEFORE INSERT ON "${table}" FOR EACH ROW EXECUTE FUNCTION wp23_fail()`,
  );
  return async () => {
    await owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS wp23_fail ON "${table}"`);
  };
}

databaseDescribe('Balance TrFr: Ac Balance (Rtl_AcOpbl)', () => {
  beforeAll(async () => {
    await wipe(TENANT);
    await wipe(OTHER_TENANT);
  });
  afterAll(async () => {
    await wipe(TENANT);
    await wipe(OTHER_TENANT);
  });
  beforeEach(async () => {
    await wipe(TENANT);
    await wipe(OTHER_TENANT);
    await seedCompany(TENANT);
    for (const [code, gr] of [
      ['P1', '1'],
      ['P2', '2'],
      ['P3', '1'],
      ['P4', '1'],
      ['P5', '1'],
      ['P6', '1'],
      ['P7', '2'],
      ['P8', '1'],
      ['X3', '3'],
      ['X5', '5'],
    ] as const)
      await account(code, gr);
  });

  it('balance-transfer.identity.party-closing-equals-opening: every (account, DATA_TYPE) opens at its closing', async () => {
    await leg('P1', 5000, 0, { date: '2025-06-01' });
    await leg('P1', 0, 1200.5, { date: '2025-07-10' });
    await leg('P1', 0, 300.25, { date: '2026-03-31' });
    await leg('P2', 700, 0);
    await leg('P2', 0, 200, { dataType: 'B' });
    await leg('P3', 1000, 0);
    await leg('P3', 0, 1000);
    await metal('P3', 'G', '+', 10.5);
    await metal('P3', 'G', '-', 2.25);
    await metal('P3', 'S', '-', 100);
    await leg('P6', 10, 0);
    await leg('P6', 0.01, 0); // the 0.005 of the case, as the 2-place column keeps it (rounded half away from zero)
    await leg('P7', 0, 20);
    await leg('P7', 0, 0.01);

    await carry.ac(TO);

    // P1 5000.00 − 1200.50 − 300.25 = 3499.25 Cr; P2/A 700.00 Cr, P2/B 200.00 Dr; P3 money 0.00 (D), gold
    // 10.500 − 2.250 = 8.250 Cr, silver 100.000 Dr; P6 10.01 Cr; P7 20.01 Dr.
    expect(heads(await opData())).toEqual([
      row('P1', 3499.25, 'C'),
      row('P2', 700, 'C'),
      row('P2', 200, 'D', { dt: 'B' }),
      row('P3', 0, 'D', { gold: 8.25, gsg: 'C', silver: 100, ssg: 'D' }),
      row('P6', 10.01, 'C'),
      row('P7', 20.01, 'D'),
    ]);
    // Σ carried Cr − Dr = 3499.25 + 700.00 − 200.00 + 0.00 + 10.01 − 20.01 = 3989.25 Cr, over 5 accounts and 6 rows.
    const net = (await opData()).reduce(
      (t, r) => t + (r.OP_SIGN === 'C' ? 1 : -1) * Math.round(r.OP_AMT * 100),
      0,
    );
    expect(net).toBe(398925);
    // The ledger of N+1 opens at the same figure, counted once.
    expect(await openingLegs('P1')).toMatchObject({ money: 3499.25, gold: 0, silver: 0 });
    expect(await openingLegs('P3')).toMatchObject({ money: 0, gold: 8.25, silver: -100 });
  });

  it('balance-transfer.ac.rule.party-only: only AC_MAIN_GR below 3 is carried', async () => {
    await leg('P1', 100, 0);
    await leg('P2', 200, 0);
    await leg('X3', 300, 0);
    await leg('X5', 0, 400);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 100, 'C'), row('P2', 200, 'C')]);
  });

  it('balance-transfer.ac.rule.party-only: the main group comes from AC_GROUP when the account has a group', async () => {
    // BtmSchm.cs:2733 copies AC_GROUP.AC_MAIN_GR into AC_MAST before reading; the web reads it without writing.
    await exec(
      TENANT,
      `INSERT INTO "AC_GROUP"(tenant_id,"CO_CODE","AC_GR","AC_MAIN_GR") VALUES ($1,$2,'99','4')`,
      TENANT,
      CO,
    );
    await exec(
      TENANT,
      `UPDATE "AC_MAST" SET "AC_GR"='99' WHERE tenant_id=$1 AND "AC_CODE"='P2'`,
      TENANT,
    );
    await leg('P1', 100, 0);
    await leg('P2', 200, 0);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 100, 'C')]);
  });

  it('balance-transfer.ac.rule.closing-date-bound: vouchers after the closing date and of N+1 are left out', async () => {
    await leg('P1', 1000, 0, { date: '2026-03-31' });
    await leg('P1', 0, 400, { date: '2026-03-30' });
    await leg('P1', 0, 999, { date: '2026-04-01' });
    await leg('P1', 0, 77, { date: '2026-04-05', year: TO });
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 600, 'C')]);
  });

  it('balance-transfer.ac.rule.location-scope: only the session location is read and written', async () => {
    await leg('P1', 500, 0);
    await leg('P1', 70, 0, { lc: '02' });
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 500, 'C')]);
    expect(await opData(TO, '02')).toEqual([]);
  });

  it('balance-transfer.ac.rule.one-row-per-data-type: ledgers A and B open separately', async () => {
    await leg('P2', 700, 0, { dataType: 'A' });
    await leg('P2', 0, 200, { dataType: 'B' });
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P2', 700, 'C'), row('P2', 200, 'D', { dt: 'B' })]);
  });

  it('balance-transfer.ac.rule.sign-cr-positive: a credit balance opens Cr and a debit balance Dr', async () => {
    await leg('P1', 80, 0);
    await leg('P2', 0, 80);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 80, 'C'), row('P2', 80, 'D')]);
  });

  it('balance-transfer.ac.rule.gold-by-it-type and zero-value-sign-d: both metals on one row, a zero head is D', async () => {
    await leg('P3', 1000, 0);
    await leg('P3', 0, 1000);
    await metal('P3', 'G', '+', 10.5);
    await metal('P3', 'G', '-', 2.25);
    await metal('P3', 'S', '-', 100);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([
      row('P3', 0, 'D', { gold: 8.25, gsg: 'C', silver: 100, ssg: 'D' }),
    ]);
  });

  it('balance-transfer.ac.rule.non-party-metal-ignored and skip-diamond-only: other metals carry nothing', async () => {
    await metal('P1', 'X', '+', 5);
    await metal('P4', 'D', '+', 3);
    await carry.ac(TO);
    expect(await opData()).toEqual([]);
  });

  it('balance-transfer.ac.rule.having-offset-money-vs-gold: 50.00 Cr and 50.000 gold Dr are both carried (Q2, deliberate difference)', async () => {
    // The desktop HAVING (BtmSchm.cs:2786) adds them to 0 and drops the party; decided 2026-11-22 by the architect,
    // owner may override: the web carries both balances.
    await leg('P5', 50, 0);
    await metal('P5', 'G', '-', 50);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P5', 50, 'C', { gold: 50, gsg: 'D' })]);
  });

  it('balance-transfer.ac.rule.skip-true-zero: a settled party has no row, summed in decimals', async () => {
    await leg('P1', 70, 0);
    await leg('P1', 0, 70);
    for (let i = 0; i < 3; i += 1) await leg('P2', 0, 0.1);
    await leg('P2', 0.3, 0);
    await carry.ac(TO);
    expect(await opData()).toEqual([]);
  });

  it('balance-transfer.ac.rule.skip-no-tolerance: a 0.01 balance is carried; 0.0004 gold rounds to 0 and is not', async () => {
    await metal('P1', 'G', '+', 0.0004); // the 3-place column keeps 0.000
    await leg('P2', 0.01, 0);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P2', 0.01, 'C')]);
  });

  it('balance-transfer.ac.round.money-half-up-positive and -negative: 10.005 and −20.005 round away from zero', async () => {
    await leg('P1', 10, 0);
    await leg('P1', 0.005, 0);
    await leg('P2', 0, 20);
    await leg('P2', 0, 0.005);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 10.01, 'C'), row('P2', 20.01, 'D')]);
  });

  it('balance-transfer.identity.gold-fine-closing-equals-opening: Σ gold and Σ silver carry over', async () => {
    await metal('P3', 'G', '+', 10.5);
    await metal('P3', 'G', '-', 2.25);
    await metal('P3', 'S', '-', 100);
    await metal('P8', 'G', '+', 4.321);
    await metal('P8', 'S', '+', 12);
    await carry.ac(TO);
    const rows = await opData();
    const signed = (v: number, s: string) => (s === 'C' ? 1 : -1) * Math.round(v * 1000);
    expect(rows.reduce((t, r) => t + signed(r.FINE_BAL, r.FINE_SIGN), 0)).toBe(12571);
    expect(rows.reduce((t, r) => t + signed(r.SL_FINE_BAL, r.SL_FINE_SIGN), 0)).toBe(-88000);
  });

  it('balance-transfer.ac.create.footprint: one OP_DATA row with the desktop constants and its ledger legs, nothing in year N', async () => {
    await leg('P1', 5000, 0, { date: '2025-06-01' });
    await leg('P1', 0, 1200.5, { date: '2025-07-10' });
    await leg('P1', 0, 300.25, { date: '2026-03-31' });
    await leg('P1', 999, 0, { date: '2026-04-01' });
    const before = await snapshotTenant(owner, TENANT);
    const yearNBefore = await yearRows(FROM);
    await carry.ac(TO);
    expect(await opData()).toEqual([
      {
        AC_CODE: 'P1',
        DATA_TYPE: 'A',
        CO_YEAR: TO,
        CO_BOOK: '000',
        VCH_NO: '00000',
        OP_AMT: 3499.25,
        OP_SIGN: 'C',
        FINE_BAL: 0,
        FINE_SIGN: 'D',
        SL_FINE_BAL: 0,
        SL_FINE_SIGN: 'D',
        MAIN_USER: USER,
        ADD_USER: '',
        ADD_DATE: null,
        DATA_TRFR: 'Y',
        LC_CODE: LC,
      },
    ]);
    const diff = diffTenant(before, await snapshotTenant(owner, TENANT));
    expect(Object.keys(diff.removed)).toEqual([]);
    expect(Object.keys(diff.added).sort()).toEqual(['AC_DATA', 'OP_DATA']);
    // One leg: the amount Cr (Ac_Ledr.cs:9-28 leg 01), dated the day before N+1 opens.
    expect(
      diff.added.AC_DATA!.map((r) => ({
        ac: r.AC_CODE,
        yr: r.CO_YEAR,
        book: r.CO_BOOK,
        cr: Number(r.CR_AMT),
        dr: Number(r.DR_AMT),
        date: String(r.VCH_DATE).slice(0, 10),
      })),
    ).toEqual([{ ac: 'P1', yr: TO, book: '000', cr: 3499.25, dr: 0, date: '2026-03-31' }]);
    expect(await yearRows(FROM)).toEqual(yearNBefore);
  });

  it('balance-transfer.field.target-year-route: the run writes the first later year only', async () => {
    await leg('P1', 100, 0);
    await carry.ac(TO);
    expect((await opData()).map((r) => r.CO_YEAR)).toEqual([TO]);
    expect(await opData(LATER)).toEqual([]);
  });

  it('balance-transfer.invalid.server-refuses-no-year: empty, current, unknown, later-than-next and earlier years are refused, nothing written', async () => {
    await leg('P1', 100, 0);
    const before = await snapshotTenant(owner, TENANT);
    for (const bad of ['', FROM, '2099-2100', LATER, '2024-2025'])
      await expect(carry.ac(bad), `target ${bad || '(empty)'}`).rejects.toThrow();
    expect(diffTenant(before, await snapshotTenant(owner, TENANT))).toEqual({
      added: {},
      removed: {},
    });
  });

  it('balance-transfer.invalid.no-next-year-message: with no later year the run is refused with the desktop text', async () => {
    await exec(
      TENANT,
      `DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_YEAR" > $2`,
      TENANT,
      FROM,
    );
    await leg('P1', 100, 0);
    await expect(carry.ac(TO)).rejects.toThrow(
      'There Are Not Found New Year Please Creat New Year And Try....',
    );
    expect(await opData()).toEqual([]);
  });

  it('balance-transfer.scope.reused-ids: a year that exists only for another company is refused', async () => {
    await exec(TENANT, `DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_YEAR"=$2`, TENANT, TO);
    await exec(
      TENANT,
      `DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_YEAR"=$2`,
      TENANT,
      LATER,
    );
    await seedCompany(TENANT, '02');
    await leg('P1', 100, 0);
    await expect(carry.ac(TO)).rejects.toThrow();
    expect(await opData()).toEqual([]);
  });

  it('balance-transfer.rerun.ac-balance-replaces: a second run after a change replaces, never doubles', async () => {
    await leg('P1', 5000, 0);
    await leg('P1', 0, 1200.5);
    await leg('P1', 0, 300.25);
    await carry.ac(TO);
    await leg('P1', 0, 249.25, { date: '2026-03-20' });
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 3250, 'C')]);
    expect(await openingLegs('P1')).toMatchObject({ n: 1, money: 3250 });
  });

  it('balance-transfer.rerun.ac-balance-removes-party-gone-to-zero', async () => {
    await leg('P1', 3499.25, 0);
    await carry.ac(TO);
    await leg('P1', 0, 3499.25);
    await carry.ac(TO);
    expect(await opData()).toEqual([]);
    expect(await openingLegs('P1')).toMatchObject({ n: 0 });
  });

  it('balance-transfer.rerun.manual-opening-edit-is-replaced: the carry overwrites a hand edit of N+1', async () => {
    await leg('P1', 3499.25, 0);
    await carry.ac(TO);
    await savePartyOpening(runtime, {
      scope: { ...scope, coYear: TO },
      acCode: 'P1',
      amount: 1,
      sign: 'D',
      mainUser: USER,
    });
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 3499.25, 'C')]);
    expect(await openingLegs('P1')).toMatchObject({ n: 1, money: 3499.25 });
  });

  it('balance-transfer.rerun.no-double-ledger-legs: two runs leave one set of opening legs', async () => {
    await leg('P1', 3499.25, 0);
    await carry.ac(TO);
    await carry.ac(TO);
    expect(await openingLegs('P1')).toMatchObject({ n: 1, money: 3499.25 });
  });

  it('balance-transfer.reopen.rerun-unchanged-is-identical and retry.duplicate-request: run 2 equals run 1, column for column', async () => {
    await leg('P1', 3499.25, 0);
    await leg('P2', 0, 200, { dataType: 'B' });
    await metal('P3', 'G', '+', 8.25);
    await carry.ac(TO);
    const strip = (s: Map<string, string[]>) =>
      new Map(
        [...s].map(([t, rows]) => [
          t,
          rows
            .map((r) => {
              const o = JSON.parse(r) as Record<string, unknown>;
              delete o.row_id;
              return JSON.stringify(o);
            })
            .sort(),
        ]),
      );
    const first = strip(await snapshotTenant(owner, TENANT));
    await carry.ac(TO);
    expect(strip(await snapshotTenant(owner, TENANT))).toEqual(first);
  });

  it('balance-transfer.reopen.party-opening-screen-shows-carry (database layer): Party Opening of N+1 reads the carry', async () => {
    await leg('P1', 3499.25, 0);
    await carry.ac(TO);
    const shown = await getPartyOpening(runtime, { ...scope, coYear: TO }, 'P1');
    expect(shown).toMatchObject({ amount: 3499.25, sign: 'C' });
  });

  it('balance-transfer.delete.target-year-only: openings of other years survive', async () => {
    await exec(
      TENANT,
      `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","SL_FINE_BAL","SL_FINE_SIGN","DATA_TYPE")
       VALUES ($1,$2,$3,$4,'000','00000','P1',123,'C',0,'D',0,'D','A'), ($1,$2,$3,$5,'000','00000','P1',456,'D',0,'D',0,'D','A')`,
      TENANT,
      CO,
      LC,
      FROM,
      TO,
    );
    await leg('P1', 600, 0);
    await carry.ac(TO);
    expect(heads(await opData(FROM))).toEqual([row('P1', 123, 'C')]);
    expect(heads(await opData())).toEqual([row('P1', 600, 'C')]);
  });

  it('balance-transfer.rollback.ac-balance-after-first-table: a failure mid-run leaves the previous carry intact', async () => {
    await leg('P1', 3499.25, 0);
    await leg('P2', 50, 0);
    await carry.ac(TO);
    const before = await snapshotTenant(owner, TENANT);
    await leg('P1', 0, 100, { date: '2026-03-01' });
    const afterSeed = await snapshotTenant(owner, TENANT);
    const drop = await failInsertOf('OP_DATA', 'AC_CODE', 'P2');
    try {
      await expect(carry.ac(TO)).rejects.toThrow();
    } finally {
      await drop();
    }
    const diff = diffTenant(afterSeed, await snapshotTenant(owner, TENANT));
    expect(diff).toEqual({ added: {}, removed: {} });
    expect(heads(await opData())).toEqual([row('P1', 3499.25, 'C'), row('P2', 50, 'C')]);
    expect(before.size).toBeGreaterThan(0);
  });

  it('balance-transfer.rollback.closing-year-untouched: year N rows are identical after a run and after a failed run', async () => {
    await leg('P1', 100, 0, { dataType: '' });
    const yearN = await yearRows(FROM);
    await carry.ac(TO);
    expect(await yearRows(FROM)).toEqual(yearN);
  });

  it('balance-transfer.concurrency.same-button-twice: two runs at once still give one row per account and type', async () => {
    await leg('P1', 3499.25, 0);
    await leg('P2', 0, 200, { dataType: 'B' });
    for (let i = 0; i < 20; i += 1) {
      const results = await Promise.allSettled([carry.ac(TO), carry.ac(TO)]);
      expect(results.map((r) => r.status)).toEqual(['fulfilled', 'fulfilled']);
      expect(heads(await opData())).toEqual([
        row('P1', 3499.25, 'C'),
        row('P2', 200, 'D', { dt: 'B' }),
      ]);
      expect(await openingLegs('P1')).toMatchObject({ n: 1 });
    }
  });

  it('balance-transfer.scope.other-tenant-sentinel and other-company-and-location: nothing outside the scope is read or written', async () => {
    await seedCompany(OTHER_TENANT);
    await account('P1', '1', OTHER_TENANT);
    await leg('P1', 777, 0, { tenant: OTHER_TENANT });
    await seedCompany(TENANT, '02');
    await account('P1', '1', TENANT, '02');
    await leg('P1', 888, 0, { co: '02' });
    await leg('P1', 99, 0, { lc: '02' });
    await leg('P1', 100, 0);
    const other = await snapshotTenant(owner, OTHER_TENANT);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 100, 'C')]);
    expect(
      await query(
        `SELECT "CO_CODE","LC_CODE" FROM "OP_DATA" WHERE tenant_id=$1 AND ("CO_CODE"<>$2 OR "LC_CODE"<>$3)`,
        TENANT,
        CO,
        LC,
      ),
    ).toEqual([]);
    expect(diffTenant(other, await snapshotTenant(owner, OTHER_TENANT))).toEqual({
      added: {},
      removed: {},
    });
  });

  it('balance-transfer.config.carry-after-closing-year-correction: a carry is a snapshot until it is run again', async () => {
    await leg('P1', 1000, 0);
    await carry.ac(TO);
    await leg('P1', 0, 250, { date: '2026-02-01' });
    expect(heads(await opData())).toEqual([row('P1', 1000, 'C')]);
    await carry.ac(TO);
    expect(heads(await opData())).toEqual([row('P1', 750, 'C')]);
  });
});

databaseDescribe('Balance TrFr: Item Stock (BtnItmStk)', () => {
  afterAll(async () => {
    await wipe(TENANT);
    await owner.$disconnect();
    await runtime.$disconnect();
  });
  beforeEach(async () => {
    await wipe(TENANT);
    await seedCompany(TENANT);
    await item('I1', 'G', 50, 91.6, 'GR1');
    await item('I2', 'G', 10, 75, 'GR1');
    await item('I6', 'S', 12.5, 0, 'GR2');
  });
  /** I1: IN 10 pcs 100.500 / 98.250, OUT 4 pcs 40.200 / 39.300. */
  const seedI1 = async () => {
    await stock('I1', '+', 10, 100.5, 98.25);
    await stock('I1', '-', 4, 40.2, 39.3, { date: '2026-03-31' });
  };

  it('balance-transfer.item.rule.closing-worked, fine-from-touch and item.create.footprint: one ITM_OPBL row', async () => {
    await seedI1();
    const before = await snapshotTenant(owner, TENANT);
    await carry.item(TO);
    // ClPcs 10 − 4 = 6; ClWtGr 100.500 − 40.200 = 60.300; ClWt 98.250 − 39.300 = 58.950; ItAmt 6 × 50.00 = 300.00;
    // fine 58.950 × 91.600 / 100 = 53.9982 → 53.998.
    expect(await itmOpbl()).toEqual([
      {
        IT_CODE: 'I1',
        CO_YEAR: TO,
        CO_BOOK: '000',
        VCH_NO: 'G',
        SR_NO: 1,
        ITM_PCS: 6,
        ITM_GWT: 60.3,
        ITM_NWT: 58.95,
        ITM_TOUCH: 91.6,
        ITM_FINE: 53.998,
        ITM_RATE: 0,
        ITM_AMT: 300,
        LBR_AMT: 0,
        OTH_AMT: 0,
        NET_AMT: 300,
        DM_WT: 0,
        DM_RATE: 0,
        DM_AMT: 0,
        LBR_RATE: 0,
        MAIN_USER: USER,
        DATA_TRFR: 'Y',
        DATA_TYPE: 'A',
        LC_CODE: LC,
      },
    ]);
    const diff = diffTenant(before, await snapshotTenant(owner, TENANT));
    expect(Object.keys(diff.removed)).toEqual([]);
    expect(Object.keys(diff.added)).toEqual(['ITM_OPBL']);
  });

  it('balance-transfer.item.rule.skip-signed-sum-offset: +5 pcs with −2.500 gross and net is carried (Q3, deliberate difference)', async () => {
    // The desktop skips it because 5 − 2.5 − 2.5 = 0 (BtmSchm.cs:2964); decided 2026-11-22 by the architect, owner may
    // override: the web keeps the position.
    await item('I3', 'G', 0, 0);
    await stock('I3', '+', 5, 0, 0);
    await stock('I3', '-', 0, 2.5, 2.5);
    await carry.item(TO);
    expect((await itmOpbl()).map((r) => [r.IT_CODE, r.ITM_PCS, r.ITM_GWT, r.ITM_NWT])).toEqual([
      ['I3', 5, -2.5, -2.5],
    ]);
  });

  it('Q9: the Item Stock carry changes no stock balance (stock reads MAIN_STOCK of every year, never ITM_OPBL)', async () => {
    await seedI1();
    const stockScope = { CO_CODE: CO, LC_CODE: LC };
    const before = await onHandNet(runtime, TENANT, stockScope);
    await carry.item(TO);
    await carry.item(TO);
    expect(await onHandNet(runtime, TENANT, stockScope)).toEqual(before);
    expect(before).toMatchObject({ pcs: 6, gwt: 60.3, nwt: 58.95 });
  });

  it('balance-transfer.item.rule.tagged-excluded: a tagged piece is not item stock', async () => {
    await seedI1();
    await stock('I1', '+', 1, 5, 5, { tag: 'T001' });
    await carry.item(TO);
    expect((await itmOpbl()).map((r) => [r.IT_CODE, r.ITM_PCS, r.ITM_NWT])).toEqual([
      ['I1', 6, 58.95],
    ]);
  });

  it('balance-transfer.item.rule.skip-sold-out: an item with nothing left has no row', async () => {
    await stock('I2', '+', 5, 25, 24);
    await stock('I2', '-', 5, 25, 24);
    await carry.item(TO);
    expect(await itmOpbl()).toEqual([]);
  });

  it('balance-transfer.item.rule.closing-date-and-year: late and next-year movements are left out', async () => {
    await seedI1();
    await stock('I1', '+', 3, 30, 29, { date: '2026-04-02' });
    await stock('I1', '+', 2, 20, 19, { date: '2026-05-01', year: TO });
    await carry.item(TO);
    expect((await itmOpbl()).map((r) => r.ITM_PCS)).toEqual([6]);
  });

  it('balance-transfer.identity.item-closing-equals-opening: per item and in total', async () => {
    await seedI1();
    await stock('I6', '+', 20, 200, 190);
    await stock('I6', '-', 5, 50, 47.5);
    await carry.item(TO);
    // I6: 15 pcs, 150.000 / 142.500, 15 × 12.50 = 187.50, no touch so no fine. Ordered by GR_CODE then IT_CODE,
    // SR_NO = the query row + 1.
    expect(
      (await itmOpbl()).map((r) => [
        r.IT_CODE,
        r.VCH_NO,
        r.SR_NO,
        r.ITM_PCS,
        r.ITM_GWT,
        r.ITM_NWT,
        r.ITM_FINE,
        r.ITM_AMT,
      ]),
    ).toEqual([
      ['I1', 'G', 1, 6, 60.3, 58.95, 53.998, 300],
      ['I6', 'S', 2, 15, 150, 142.5, 0, 187.5],
    ]);
    const rows = await itmOpbl();
    expect(rows.reduce((t, r) => t + r.ITM_PCS, 0)).toBe(21);
    expect(Math.round(rows.reduce((t, r) => t + r.ITM_NWT, 0) * 1000)).toBe(201450);
    expect(Math.round(rows.reduce((t, r) => t + r.ITM_AMT, 0) * 100)).toBe(48750);
  });

  it('balance-transfer.rerun.item-stock-replaces: a change and a second run give one corrected row', async () => {
    await seedI1();
    await carry.item(TO);
    await stock('I1', '-', 1, 10, 9.8, { date: '2026-03-25' });
    await carry.item(TO);
    expect((await itmOpbl()).map((r) => [r.ITM_PCS, r.ITM_GWT, r.ITM_NWT, r.ITM_AMT])).toEqual([
      [5, 50.3, 49.15, 250],
    ]);
  });

  it('balance-transfer.delete.target-year-only (ITM_OPBL): another year keeps its opening', async () => {
    await exec(
      TENANT,
      `INSERT INTO "ITM_OPBL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","IT_CODE","VCH_NO","SR_NO","ITM_PCS")
       VALUES ($1,$2,$3,$4,'000','I1','G',1,9)`,
      TENANT,
      CO,
      LC,
      FROM,
    );
    await seedI1();
    await carry.item(TO);
    expect((await itmOpbl(FROM)).map((r) => r.ITM_PCS)).toEqual([9]);
    expect((await itmOpbl()).map((r) => r.ITM_PCS)).toEqual([6]);
  });

  it('balance-transfer.rollback.item-stock-after-delete: a failure leaves the previous ITM_OPBL rows', async () => {
    await seedI1();
    await stock('I6', '+', 20, 200, 190);
    await carry.item(TO);
    await stock('I1', '-', 1, 10, 9.8, { date: '2026-03-25' });
    const before = await snapshotTenant(owner, TENANT);
    const drop = await failInsertOf('ITM_OPBL', 'IT_CODE', 'I6');
    try {
      await expect(carry.item(TO)).rejects.toThrow();
    } finally {
      await drop();
    }
    expect(diffTenant(before, await snapshotTenant(owner, TENANT))).toEqual({
      added: {},
      removed: {},
    });
  });

  it('balance-transfer.invalid.server-refuses-no-year (Item Stock): bad targets write nothing', async () => {
    await seedI1();
    const before = await snapshotTenant(owner, TENANT);
    for (const bad of ['', FROM, '2099-2100', LATER])
      await expect(carry.item(bad), `target ${bad || '(empty)'}`).rejects.toThrow();
    expect(diffTenant(before, await snapshotTenant(owner, TENANT))).toEqual({
      added: {},
      removed: {},
    });
  });
});
