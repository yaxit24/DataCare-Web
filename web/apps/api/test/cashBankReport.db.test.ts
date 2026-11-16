import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { strFromU8, unzipSync } from 'fflate';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import {
  CO_YEAR, SEED_A_LINES, seedA, seedSecondTenant, seedSentinels, seedVariant, unseedSentinels, unseedVariant, wipe,
  type Leg, type SentinelKind, type VariantName,
} from './support/cashBankSeed.js';

/** Cash Bank report (desktop RP_CASH_BANK) over HTTP, isolated database, forced RLS. Expected figures are worked out from
 * seed A with the desktop formula, cited above each assertion, and never read from the response. Until WP-17.api lands,
 * these tests answer 404. */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'cash-bank-report-db';
const OTHER = 'cash-bank-report-other';
const PASSWORD = 'Cash-Bank-Report!2026';
const SECRET = 'cash-bank-report-test-signing-secret-over-32-chars';
const PERIOD = 'fromDate=2026-11-01&toDate=2026-11-30&acCode=00001';
const USERS = { reader: 'cashbank-reader', viewer: 'cashbank-viewer', nobody: 'cashbank-none' };
type Who = keyof typeof USERS;
interface Totals { drAmt: number; crAmt: number; balAmt: number; side: string }
interface Row extends Totals { kind: string; sr: number; book: string; vchNo: string; vchDate: string; party: string }
interface Grid { rows: Row[]; totals: Totals | null; account: { acCode: string; acName: string } | null }

const SEED_A_TOTALS: Totals = { drAmt: 13500, crAmt: 2500, balAmt: 11000, side: 'Dr' };
/** Seed A grid (balance.running-side) as [sr, drAmt, crAmt, balAmt, side]; the opening is sr 1. */
const SEED_A_ROWS = [[1, 7500, 0, 7500, 'Dr'], [2, 4000, 0, 11500, 'Dr'], [3, 0, 1500, 10000, 'Dr'], [4, 0, 1000, 9000, 'Dr'], [5, 0, 0, 9000, 'Dr'], [6, 2000, 0, 11000, 'Dr']];
const rowOf = (g: Grid, vch: string) => g.rows.find((r) => r.vchNo === vch);
const cells = (g: Grid) => g.rows.map((r) => [r.sr, r.drAmt, r.crAmt, r.balAmt, r.side]);

(enabled ? describe : describe.skip)('Cash Bank report (RP_CASH_BANK)', () => {
  let owner: PrismaClient, runtime: PrismaClient, app: FastifyInstance;
  const cookies: Record<Who, string> = { reader: '', viewer: '', nobody: '' };
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const get = (url: string, who: Who = 'reader') => app.inject({ method: 'GET', url, headers: { cookie: cookies[who] } });
  const grid = async (query: string, who: Who = 'reader') => {
    const res = await get(`/reports/cash-bank?${query}`, who);
    expect(res.statusCode, res.body).toBe(200);
    return res.json() as Grid;
  };
  const withSentinel = async (kind: SentinelKind, check: (g: Grid) => void) => {
    await seedSentinels(owner, TENANT, kind);
    try { check(await grid(PERIOD)); } finally { await unseedSentinels(owner, TENANT, kind); }
  };
  const withVariant = async (name: VariantName, run: () => Promise<void>) => {
    await seedVariant(owner, TENANT, name);
    try { await run(); } finally { await unseedVariant(owner, TENANT, name); }
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    for (const t of [TENANT, OTHER]) await wipe(owner, t);
    await seedCompany(runtime, TENANT, '01');
    await seedA(owner, TENANT);
    await seedCompany(runtime, OTHER, '01');
    await seedSecondTenant(owner, OTHER);
    // reader: view and print; viewer: view only; nobody: no USER_SET row for the form.
    const print: Record<Who, string> = { reader: 'Y', viewer: 'N', nobody: 'N' };
    const hash = await hashPassword(PASSWORD);
    for (const who of Object.keys(USERS) as Who[]) {
      await exec(`INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES($1,'01',$2,$3,'USER','N','N',$4,'N')`, TENANT, USERS[who], hash, print[who]);
      if (who !== 'nobody') await exec(`INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES($1,'01','01',$2,'Report','Reports/Cash / Bank Book','Y','N','N',$3)`, TENANT, USERS[who], print[who]);
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const who of Object.keys(USERS) as Who[]) {
      const res = await app.inject({ method: 'POST', url: '/auth/login', headers: { 'x-tenant-id': TENANT }, payload: { coCode: '01', lcCode: '01', coYear: CO_YEAR, loginName: USERS[who], password: PASSWORD } });
      expect(res.statusCode, res.body).toBe(200);
      cookies[who] = [res.headers['set-cookie'] ?? ''].flat().map((part) => part.split(';', 1)[0]).join('; ');
    }
  });

  afterAll(async () => {
    await app?.close();
    if (owner) for (const t of [TENANT, OTHER]) await wipe(owner, t);
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('cash-bank-report.balance.opening-row: the opening row is Op Balance with Dr 7500.00', async () => {
    // RP_CASH_BANK.cs:3222 {{Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0}} L1 DR 10000 and L2 CR 2500: CR - DR = -7500.
    // RP_CASH_BANK.cs:3226 {{[1, num7].Value = "Op Balance";}}
    expect((await grid(PERIOD)).rows[0]).toMatchObject({ kind: 'opening', sr: 1, book: 'Op Balance', drAmt: 7500, crAmt: 0, balAmt: 7500, side: 'Dr' });
  });

  it('cash-bank-report.balance.opening-zero-no-row: no Op Balance row when the opening is zero', async () => {
    // RP_CASH_BANK.cs:3222 {{Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0}} Account 00010 has no line before 01/11; its only line is L5b (20/11/2026, DR 1000).
    const g = await grid('fromDate=2026-11-01&toDate=2026-11-30&acCode=00010');
    expect(g.rows).toEqual([expect.objectContaining({ kind: 'detail', sr: 1, vchDate: '2026-11-20', drAmt: 1000, crAmt: 0, balAmt: 1000, side: 'Dr' })]);
  });

  it('cash-bank-report.balance.opening-cr-side: the opening is Cr 12500.00 and the running side follows it', async () => {
    // RP_CASH_BANK.cs:3228 {{[7, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);}} Seed A plus L10 (CR 20000): 20000 + 2500 - 10000 = 12500 Cr.
    await withVariant('cr-side', async () => {
      const g = await grid(PERIOD);
      expect(g.rows.map((r) => [r.balAmt, r.side])).toEqual([[12500, 'Cr'], [8500, 'Cr'], [10000, 'Cr'], [11000, 'Cr'], [11000, 'Cr'], [9000, 'Cr']]);
      expect(g.totals).toEqual({ drAmt: 6000, crAmt: 15000, balAmt: 9000, side: 'Cr' });
    });
  });

  it('cash-bank-report.balance.running-side: every row carries its running balance and side', async () => {
    // RP_CASH_BANK.cs:3296 {{((DataGridView)dGV_DETL2)[8, num7].Value = Math.Abs(num2 - num);}} RP_CASH_BANK.cs:3297 {{if (num2 - num > 0.0)}}
    expect(cells(await grid(PERIOD))).toEqual(SEED_A_ROWS);
  });

  it('cash-bank-report.balance.zero-net-row-blank: voucher 7 is one row with both amounts zero', async () => {
    // RP_CASH_BANK.cs:3360 {{Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0}} CR 500 and DR 500 net to 0: both cells blank, balance stays 9000.00 Dr.
    const v7 = (await grid(PERIOD)).rows.filter((r) => r.vchNo === '7');
    expect(v7).toEqual([expect.objectContaining({ sr: 5, drAmt: 0, crAmt: 0, balAmt: 9000, side: 'Dr' })]);
  });

  it('cash-bank-report.balance.totals-row: the Total row is Dr 13500.00, Cr 2500.00, Bal 11000.00 Dr', async () => {
    // RP_CASH_BANK.cs:3321 {{Rows[num9].Cells[4].Value = "Total :";}} RP_CASH_BANK.cs:3324 {{Cells[8].Value = Math.Abs(num2 - num);}} Dr = 7500 + 4000 + 2000; Cr = 1500 + 1000; Bal = |2500 - 13500|.
    expect((await grid(PERIOD)).totals).toEqual(SEED_A_TOTALS);
  });

  it('cash-bank-report.balance.totals-include-opening: the totals include the opening, and 0.10 + 0.20 is 0.30', async () => {
    // RP_CASH_BANK.cs:3229 {{num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));}} Dr total = 7500 + 6000 = 13500, not the period-only 6000.
    expect((await grid(PERIOD)).totals?.drAmt).toBe(13500);
    // Vector: DR 0.10 and DR 0.20 on 03/11/2026 (account 00030) total 0.30, not 0.30000000000000004.
    await withVariant('paise', async () => {
      expect((await grid('fromDate=2026-11-01&toDate=2026-11-30&acCode=00030')).totals).toEqual({ drAmt: 0.3, crAmt: 0, balAmt: 0.3, side: 'Dr' });
    });
  });

  it('cash-bank-report.balance.seed-a-hand-totals: every figure matches a hand sum of the seeded lines', async () => {
    // RP_CASH_BANK.cs:3160 {{and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}} Hand sums of CR - DR in paise: before 01/11 -750000; period -350000; closing -1100000.
    const net = (legs: Leg[]) => legs.reduce((p, l) => p + Math.round(((l.cr ?? 0) - (l.dr ?? 0)) * 100), 0);
    const mine = SEED_A_LINES.filter((l) => l.account === '00001');
    const opening = net(mine.filter((l) => l.date < '2026-11-01'));
    const period = net(mine.filter((l) => l.date >= '2026-11-01' && l.date <= '2026-11-30'));
    expect([opening, period, opening + period]).toEqual([-750000, -350000, -1100000]);
    const g = await grid(PERIOD);
    expect(cells(g)).toEqual(SEED_A_ROWS);
    expect(g.totals).toEqual(SEED_A_TOTALS);
  });

  it('cash-bank-report.balance.date-boundary-from-inclusive: a line dated on From is a detail row', async () => {
    // RP_CASH_BANK.cs:3160 {{and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}} RP_CASH_BANK.cs:3162 {{and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}
    // Seed A plus L9 (01/11/2026, DR 100): the opening stays Dr 7500 and L9 is the first detail row.
    await withVariant('date-boundary', async () => {
      const g = await grid(PERIOD);
      expect(g.rows[0]).toMatchObject({ kind: 'opening', drAmt: 7500, side: 'Dr' });
      expect(g.rows.slice(1).map((r) => [r.vchNo, r.balAmt, r.side])).toEqual([['9', 7600, 'Dr'], ['3', 11600, 'Dr'], ['4', 10100, 'Dr'], ['5', 9100, 'Dr'], ['7', 9100, 'Dr'], ['6', 11100, 'Dr']]);
      expect(g.totals).toEqual({ drAmt: 13600, crAmt: 2500, balAmt: 11100, side: 'Dr' });
    });
  });

  it('cash-bank-report.filter.date-window-from: From 05/11/2026 puts voucher 3 in the rows, not the opening', async () => {
    // RP_CASH_BANK.cs:3162 {{and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}} Opening = L1 and L2 only, Dr 7500; voucher 3 (DR 4000) is a detail row.
    const g = await grid('fromDate=2026-11-05&toDate=2026-11-30&acCode=00001');
    expect(g.rows[0]).toMatchObject({ kind: 'opening', drAmt: 7500, balAmt: 7500, side: 'Dr' });
    expect(g.rows.slice(1).map((r) => r.vchNo)).toEqual(['3', '4', '5', '7', '6']);
    expect(g.totals).toEqual(SEED_A_TOTALS);
  });

  it('cash-bank-report.filter.date-window-to: L8 (02/12/2026) is in neither the rows nor the opening', async () => {
    // RP_CASH_BANK.cs:3162 {{AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")}} L8 (DR 999) is after To and must not change the totals.
    const g = await grid(PERIOD);
    expect(g.rows.some((r) => r.vchNo === '8')).toBe(false);
    expect(g.totals).toEqual(SEED_A_TOTALS);
  });

  it('cash-bank-report.filter.from-after-to: From after To is not refused and gives the opening only', async () => {
    // RP_CASH_BANK.cs:3160 {{and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}} No desktop check exists. Lines before 15/11: -10000 + 2500 - 4000 + 1500 = -10000, so Dr 10000.
    const g = await grid('fromDate=2026-11-15&toDate=2026-11-10&acCode=00001');
    expect(g.rows).toEqual([expect.objectContaining({ kind: 'opening', drAmt: 10000, side: 'Dr' })]);
  });

  it('cash-bank-report.filter.empty-period: no detail row, and the opening is Dr 11999.00', async () => {
    // RP_CASH_BANK.cs:3160 {{and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}} RP_CASH_BANK.cs:3222 {{Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0}} Lines before 03/12 net -11999.
    expect((await grid('fromDate=2026-12-03&toDate=2026-12-05&acCode=00001')).rows).toEqual([expect.objectContaining({ kind: 'opening', drAmt: 11999, side: 'Dr' })]);
  });

  it('cash-bank-report.filter.one-account-only: no line of account 00010 is in the grid or the opening', async () => {
    // RP_CASH_BANK.cs:3162 {{AND A.AC_CODE = '" + tAcCode.Text + "'}} RP_CASH_BANK.cs:3160 {{AND A.AC_CODE = '" + tAcCode.Text + "'}} L5b (DR 1000) would show as a row if it leaked in.
    const g = await grid(PERIOD);
    expect(g.account).toEqual({ acCode: '00001', acName: 'CASH ON HAND' });
    expect(g.rows.some((r) => r.drAmt === 1000)).toBe(false);
    expect(g.totals).toEqual(SEED_A_TOTALS);
  });

  it('cash-bank-report.filter.book-filter: Book 001 keeps CASH REC only, and the opening follows it', async () => {
    // RP_CASH_BANK.cs:3162 {{AND A.CO_BOOK = '" + tBookCode.Text + "'}} RP_CASH_BANK.cs:3160 {{Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0}}
    // Opening L1 only: Dr 10000. Voucher 3 (Dr 4000, bal 14000 Dr) and voucher 7 (zero, bal 14000 Dr).
    const g = await grid(`${PERIOD}&bookCode=001`);
    expect(g.rows[0]).toMatchObject({ kind: 'opening', sr: 1, drAmt: 10000, balAmt: 10000, side: 'Dr' });
    expect(g.rows.slice(1).map((r) => [r.vchNo, r.drAmt, r.balAmt])).toEqual([['3', 4000, 14000], ['7', 0, 14000]]);
    expect(g.totals).toEqual({ drAmt: 14000, crAmt: 0, balAmt: 14000, side: 'Dr' });
  });

  it('cash-bank-report.filter.book-empty-all: an empty Book returns every book, as seed A', async () => {
    // RP_CASH_BANK.cs:3162 {{Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0}} RP_CASH_BANK.cs:4728 {{tBookName.Text = "";}}
    expect((await grid(`${PERIOD}&bookCode=`)).totals).toEqual(SEED_A_TOTALS);
    expect((await grid(PERIOD)).totals).toEqual(SEED_A_TOTALS);
  });

  it('cash-bank-report.filter.book-unknown-code: a Book with no lines gives an empty grid, with no refusal', async () => {
    // RP_CASH_BANK.cs:3315 {{if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(}} No line has book ZZZ.
    expect(await grid(`${PERIOD}&bookCode=ZZZ`)).toMatchObject({ rows: [], totals: null });
  });

  it('cash-bank-report.account.enter-found: account 00010 resolves to TEST BANK with its one line', async () => {
    // RP_CASH_BANK.cs:3691 {{tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));}} The only line: CONTRA, 20/11/2026, DR 1000, counter-party CASH ON HAND.
    const g = await grid('fromDate=2026-11-01&toDate=2026-11-30&acCode=00010');
    expect(g.account).toEqual({ acCode: '00010', acName: 'TEST BANK' });
    expect(g.rows).toEqual([expect.objectContaining({ vchDate: '2026-11-20', book: 'CONTRA', party: 'CASH ON HAND', drAmt: 1000, balAmt: 1000, side: 'Dr' })]);
  });

  it('cash-bank-report.row.voucher-book-and-number: the 05/11 row is book CASH REC, voucher 3', async () => {
    // RP_CASH_BANK.cs:3257 {{dataTable2.Rows[DC_Main.M]["BOOK_NAME"]}} RP_CASH_BANK.cs:3258 {{dataTable2.Rows[DC_Main.M]["VCH_NO"]}}
    expect(rowOf(await grid(PERIOD), '3')).toMatchObject({ book: 'CASH REC', vchNo: '3', vchDate: '2026-11-05' });
  });

  it('cash-bank-report.row.party-name-counter-party: vouchers 3, 4 and 5 show their counter-party names', async () => {
    // RP_CASH_BANK.cs:3162 {{LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE}} RP_CASH_BANK.cs:3289 {{dataTable2.Rows[DC_Main.M]["AC_NAME"]}}
    const g = await grid(PERIOD);
    expect(['3', '4', '5'].map((v) => rowOf(g, v)?.party)).toEqual(['PARTY ALPHA', 'PARTY BETA', 'TEST BANK']);
  });

  it('cash-bank-report.row.party-name-sales: a SALES row takes its name from SL_DATA, not the counter-party', async () => {
    // RP_CASH_BANK.cs:3261 {{(object)"SALES", false))}} RP_CASH_BANK.cs:3154 {{SELECT CO_BOOK,VCH_NO,AC_NAME FROM SL_DATA}} Voucher 6: counter-party PARTY BETA, SL_DATA says PARTY ALPHA.
    expect(rowOf(await grid(PERIOD), '6')).toMatchObject({ book: 'SALES', party: 'PARTY ALPHA' });
  });

  it('cash-bank-report.row.grouping-one-row-per-voucher: five detail rows, voucher 7 once', async () => {
    // RP_CASH_BANK.cs:3162 {{GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.LEDR_KEY,A.LD_CODE}}
    expect((await grid(PERIOD)).rows.slice(1).map((r) => r.vchNo)).toEqual(['3', '4', '5', '7', '6']);
  });

  it('cash-bank-report.history.live-party-name: a renamed party shows its new name; the SALES row keeps SL_DATA', async () => {
    // RP_CASH_BANK.cs:3162 {{LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE}} RP_CASH_BANK.cs:3154 {{SELECT CO_BOOK,VCH_NO,AC_NAME FROM SL_DATA}}
    await exec(`UPDATE "AC_MAST" SET "AC_NAME"='PARTY ALPHA RENAMED' WHERE tenant_id=$1 AND "AC_CODE"='00101'`, TENANT);
    try {
      const g = await grid(PERIOD);
      expect([rowOf(g, '3')?.party, rowOf(g, '6')?.party]).toEqual(['PARTY ALPHA RENAMED', 'PARTY ALPHA']);
    } finally {
      await exec(`UPDATE "AC_MAST" SET "AC_NAME"='PARTY ALPHA' WHERE tenant_id=$1 AND "AC_CODE"='00101'`, TENANT);
    }
  });

  it('cash-bank-report.scope.company-sentinel: a line of company 02 reaches neither the grid nor the totals', async () => {
    // RP_CASH_BANK.cs:3162 {{WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'}} Sentinel DR 888 on voucher 3, the visible number of the real voucher 3.
    await withSentinel('company', (g) => {
      expect(g.rows.filter((r) => r.vchNo === '3')).toHaveLength(1);
      expect(g.rows[0]?.drAmt).toBe(7500);
      expect(g.totals).toEqual(SEED_A_TOTALS);
    });
  });

  it('cash-bank-report.scope.location-sentinel: a line of location 02 and a line of the other tenant never appear', async () => {
    // RP_CASH_BANK.cs:3162 {{AND A.LC_CODE = '" + DC_Main.MLc_code + "'}} Location sentinel DR 777; the other tenant's DR 4444 must not appear either.
    await withSentinel('location', (g) => {
      expect(g.rows.filter((r) => r.vchNo === '3')).toHaveLength(1);
      expect(g.rows.some((r) => r.drAmt === 777 || r.drAmt === 4444)).toBe(false);
      expect(g.totals).toEqual(SEED_A_TOTALS);
    });
  });

  it('cash-bank-report.scope.year-sentinel: a line of year 2025-26 is in neither the grid, the opening nor the totals', async () => {
    // Supervisor decision, 16 November 2026: the session's company year is applied (design.md section 1).
    // RP_CASH_BANK.cs:3547 {{{AC_DATA.CO_YEAR} = '}} Sentinel DR 333 on 06/11: the figures must be exactly seed A's.
    await withSentinel('year', (g) => {
      expect(g.rows).toHaveLength(6);
      expect(g.rows.some((r) => r.drAmt === 333)).toBe(false);
      expect(g.rows[0]?.drAmt).toBe(7500);
      expect(g.totals).toEqual(SEED_A_TOTALS);
    });
  });

  it('cash-bank-report.rights.menu-no-right: a user with no right on the form is refused the screen', async () => {
    // MDI_FORM.cs:7041 {{AND FRM_VIEW = 'Y'}} MDI_FORM.cs:7047 {{Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);}}
    const res = await get(`/reports/cash-bank?${PERIOD}`, 'nobody');
    expect(res.statusCode).toBe(403);
    expect(res.body).not.toContain('"rows"');
  });

  it('cash-bank-report.rights.excel-no-print: the viewer sees the grid; every export is refused with the desktop text', async () => {
    // RP_CASH_BANK.cs:2389 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}} RP_CASH_BANK.cs:2540 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}
    expect((await grid(PERIOD, 'viewer')).rows).toHaveLength(6);
    for (const ext of ['xlsx', 'csv', 'pdf']) {
      const res = await get(`/reports/cash-bank/export.${ext}?${PERIOD}`, 'viewer');
      expect(res.statusCode, ext).toBe(403);
      expect(res.body).toContain('You Have No Print Rights.....');
    }
  });

  it('cash-bank-report.print.excel-rows-and-totals: the workbook holds the grid rows and the Total row', async () => {
    // RP_CASH_BANK.cs:2656 {{num13 = ((DataGridView)DGV_DETL).RowCount - 1;}} RP_CASH_BANK.cs:2660 {{if (DC_Main.i <= num13)}} Header + 6 grid rows + Total row = 8; the last row holds Dr 13500 and Cr 2500.
    const res = await get(`/reports/cash-bank/export.xlsx?${PERIOD}`);
    expect(res.statusCode, res.body).toBe(200);
    const sheet = Object.entries(unzipSync(new Uint8Array(res.rawPayload))).find(([k]) => /worksheets\/sheet1\.xml$/.test(k))?.[1] ?? new Uint8Array();
    const rows = strFromU8(sheet).match(/<row [\s\S]*?<\/row>/g) ?? [];
    expect(rows).toHaveLength(8);
    expect(rows[7]).toContain('<v>13500</v>');
    expect(rows[7]).toContain('<v>2500</v>');
  });

  it('cash-bank-report.print.excel-bold-and-autofit: the header row is bold and the column widths are set', async () => {
    // RP_CASH_BANK.cs:2671 {{"FontStyle", new object[1] { "Bold" }}} RP_CASH_BANK.cs:2687 {{"AutoFit", new object[0]}}
    const res = await get(`/reports/cash-bank/export.xlsx?${PERIOD}`);
    expect(res.statusCode, res.body).toBe(200);
    const parts = Object.fromEntries(Object.entries(unzipSync(new Uint8Array(res.rawPayload))).map(([k, v]) => [k, strFromU8(v)]));
    const sheet = Object.entries(parts).find(([k]) => /worksheets\/sheet1\.xml$/.test(k))?.[1] ?? '';
    const styles = parts['xl/styles.xml'] ?? '';
    const xfs = [...(styles.match(/<cellXfs[\s\S]*?<\/cellXfs>/)?.[0] ?? '').matchAll(/<xf\b[^>]*>/g)];
    const fonts = [...(styles.match(/<fonts[\s\S]*?<\/fonts>/)?.[0] ?? '').matchAll(/<font\b[\s\S]*?<\/font>/g)];
    const xf = Number(sheet.match(/<c r="A1"[^>]*?\bs="(\d+)"/)?.[1] ?? -1);
    const fontId = Number(xfs[xf]?.[0].match(/fontId="(\d+)"/)?.[1] ?? -1);
    expect(/<b\/>|<b \/>|<b>/.test(fonts[fontId]?.[0] ?? '')).toBe(true);
    expect(sheet).toMatch(/<cols>[\s\S]*<col [^>]*width="[\d.]+"/);
  });
});
