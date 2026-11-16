import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import { API, COL, HEADERS, ROUTE, as, assertRow, C, field, openAccountHelp, openReport, readGrid, readHeaders, refillBy, withSeed, withoutSeed } from './cashBankReportKit.mjs';

/**
 * Feature: Report → Cash Bank (desktop RP_CASH_BANK; web /reports/cash-bank): grid, filter, account and text cases.
 * Figures are literals from seed A (cases.md 638-673); comments give the arithmetic (opening = CR - DR before From;
 * Bal = |running CR - DR|; totals include the opening). The report writes nothing: every case is read-only.
 */
const RO = 'read-only';
const MONEY = /^\d{1,3}(,\d{3})*\.\d{2}$/;
const rowFor = (rows, vch) => {
  assert.equal(rows.filter((r) => r[COL.vch] === vch).length, 1, `one row for voucher ${vch}`);
  return rows.find((r) => r[COL.vch] === vch);
};
const openA = (page, extra = {}) => openReport(page, { acCode: '00001', ...extra });
const TOTALS_A = { party: 'Total :', dr: '13,500.00', cr: '2,500.00', bal: '11,000.00', side: 'Dr' };
const DATE_FROM = `RP_CASH_BANK.cs:3162 {{VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}`;
const DATE_TO = `RP_CASH_BANK.cs:3162 {{AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")}}`;
const DATE_BEFORE_FROM = `RP_CASH_BANK.cs:3160 {{VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}`;

export const cashBankReport = {
  feature: 'cash-bank-report',
  title: 'Reports → Cash Bank (RP_CASH_BANK, cash-and-bank mode)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/reports/cash-bank/page.tsx', 'web/apps/web/app/(app)/reports/cash-bank/useCashBank.ts',
    'web/apps/web/app/(app)/reports/cash-bank/CashBankGrid.tsx', 'web/apps/web/app/(app)/reports/cash-bank/types.ts',
    'web/apps/api/src/modules/reports/cashBankReport.ts', 'web/apps/api/src/routes/cashBankReport.ts',
    'web/apps/web/test/features/modules/cashBankReport.mjs', 'web/apps/web/test/features/modules/cashBankReportKit.mjs',
  ],
  fixtureManifest: { base: 'seedCompany; cases seed AC_DATA/AC_MAST/BOOK_DATA/SL_DATA directly (codes owned here)' },
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    // Balance and totals (T03)
    C('balance.opening-row', 'T03', RO, 'cases.md balance.opening-row; RP_CASH_BANK.cs:3226 {{((DataGridView)dGV_DETL)[1, num7].Value = "Op Balance";}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      // Opening CR - DR = 2500.00 - 10000.00 = -7500.00: Dr 7,500.00, no Cr.
      assertRow((await readGrid(page))[0], { sr: '1', book: 'Op Balance', dr: '7,500.00', cr: '', bal: '7,500.00', side: 'Dr' });
      return { observation: 'opening Dr 7,500.00', expected: { opening: '7,500.00 Dr' } };
    })),
    C('balance.opening-zero-no-row', 'T03', RO, 'cases.md balance.opening-zero-no-row; RP_CASH_BANK.cs:3222 {{Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page, { acCode: '00010' });
      const rows = await readGrid(page);
      assert.equal(rows.some((r) => r[COL.book] === 'Op Balance'), false, 'no opening row for 00010');
      // The first row is the 20/11/2026 CONTRA line, DR 1000.00.
      assertRow(rows[0], { sr: '1', book: 'CONTRA', dr: '1,000.00', cr: '', bal: '1,000.00', side: 'Dr' });
      return { observation: 'no opening row; CONTRA Dr 1,000.00', expected: { first: 'CONTRA 1,000.00 Dr' } };
    })),
    C('balance.opening-cr-side', 'T03', RO, 'cases.md balance.opening-cr-side; RP_CASH_BANK.cs:3228 {{[7, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const rows = await readGrid(page);
      assert.equal(rows.length, 7, 'opening, five rows, totals');
      // Opening = 20000.00 + 2500.00 - 10000.00 = 12500.00: Cr 12,500.00.
      assertRow(rows[0], { book: 'Op Balance', dr: '', cr: '12,500.00', bal: '12,500.00', side: 'Cr' });
      // Running: 12500 - 4000 = 8500; + 1500 = 10000; + 1000 = 11000; zero = 11000; - 2000 = 9000.
      assert.deepEqual(rows.slice(1, 6).map((r) => [r[COL.bal], r[COL.side]]), [['8,500.00', 'Cr'], ['10,000.00', 'Cr'], ['11,000.00', 'Cr'], ['11,000.00', 'Cr'], ['9,000.00', 'Cr']]);
      // Totals: Dr 4000 + 2000 = 6000; Cr 12500 + 1500 + 1000 = 15000; Bal |15000 - 6000| = 9000, Cr.
      assertRow(rows.at(-1), { party: 'Total :', dr: '6,000.00', cr: '15,000.00', bal: '9,000.00', side: 'Cr' });
      return { observation: 'opening Cr 12,500.00; totals 9,000.00 Cr', expected: { totals: '9,000.00 Cr' } };
    }, 'cr-side')),
    C('balance.running-side', 'T03', RO, 'cases.md balance.running-side; RP_CASH_BANK.cs:3296 {{((DataGridView)dGV_DETL2)[8, num7].Value = Math.Abs(num2 - num);}}; RP_CASH_BANK.cs:3301 {{else if (num2 - num < 0.0)}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const rows = await readGrid(page);
      // Running CR - DR: -7500, -11500, -10000, -9000, -9000, -11000. Bal is |running|; side Dr while negative.
      [
        { sr: '1', book: 'Op Balance', dr: '7,500.00', cr: '', bal: '7,500.00', side: 'Dr' }, { sr: '2', vch: '3', dr: '4,000.00', cr: '', bal: '11,500.00', side: 'Dr' },
        { sr: '3', vch: '4', dr: '', cr: '1,500.00', bal: '10,000.00', side: 'Dr' }, { sr: '4', vch: '5', dr: '', cr: '1,000.00', bal: '9,000.00', side: 'Dr' },
        { sr: '5', vch: '7', dr: '', cr: '', bal: '9,000.00', side: 'Dr' }, { sr: '6', vch: '6', dr: '2,000.00', cr: '', bal: '11,000.00', side: 'Dr' },
      ].forEach((spec, i) => assertRow(rows[i], spec));
      return { observation: 'six rows, running Bal and side', expected: { closing: '11,000.00 Dr' } };
    })),
    C('balance.zero-net-row-blank', 'T03', RO, 'cases.md balance.zero-net-row-blank; RP_CASH_BANK.cs:3360 {{Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      // Voucher 7 is one row: CR 500.00 - DR 500.00 = 0, so Dr and Cr are blank; Bal stays 9,000.00 Dr.
      assertRow(rowFor(await readGrid(page), '7'), { sr: '5', dr: '', cr: '', bal: '9,000.00', side: 'Dr' });
      return { observation: 'voucher 7 one row, blank cells', expected: { bal: '9,000.00 Dr' } };
    })),
    C('balance.totals-row', 'T03', RO, 'cases.md balance.totals-row; RP_CASH_BANK.cs:3321 {{((DataGridView)DGV_DETL).Rows[num9].Cells[4].Value = "Total :";}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      // Dr = 7500 + 4000 + 2000 = 13500; Cr = 1500 + 1000 = 2500; Bal = |2500 - 13500| = 11000, Dr.
      assertRow((await readGrid(page)).at(-1), TOTALS_A);
      return { observation: 'totals 13,500.00 / 2,500.00 / 11,000.00 Dr', expected: TOTALS_A };
    })),
    C('balance.n2-display', 'T03', RO, 'cases.md balance.n2-display; RP_CASH_BANK.cs:3196 {{((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const totals = (await readGrid(page)).at(-1);
      for (const i of [COL.dr, COL.cr, COL.bal]) assert.match(totals[i], MONEY, 'two decimals, thousands separator');
      assertRow(totals, { dr: '13,500.00', cr: '2,500.00', bal: '11,000.00' });
      return { observation: 'N2 display of totals', expected: { dr: '13,500.00', cr: '2,500.00', bal: '11,000.00' } };
    })),
    C('balance.date-boundary-from-inclusive', 'T03', RO, `cases.md balance.date-boundary-from-inclusive; ${DATE_FROM}`, async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const rows = await readGrid(page);
      assert.equal(rows.length, 8, 'opening, six rows (L9 included), totals');
      // L9 (01/11/2026, DR 100) is a detail row; the opening keeps Dr 7,500.00.
      assertRow(rows[0], { book: 'Op Balance', dr: '7,500.00', bal: '7,500.00', side: 'Dr' });
      [
        { date: '01/11/2026', dr: '100.00', bal: '7,600.00', side: 'Dr' }, { vch: '3', dr: '4,000.00', bal: '11,600.00', side: 'Dr' },
        { vch: '4', cr: '1,500.00', bal: '10,100.00', side: 'Dr' }, { vch: '5', cr: '1,000.00', bal: '9,100.00', side: 'Dr' },
        { vch: '7', bal: '9,100.00', side: 'Dr' }, { vch: '6', dr: '2,000.00', bal: '11,100.00', side: 'Dr' },
      ].forEach((spec, i) => assertRow(rows[i + 1], spec));
      // Totals: Dr 7500 + 100 + 4000 + 2000 = 13600; Cr 2500; Bal 11100, Dr.
      assertRow(rows.at(-1), { party: 'Total :', dr: '13,600.00', cr: '2,500.00', bal: '11,100.00', side: 'Dr' });
      return { observation: 'L9 on From is a detail row', expected: { totals: '13,600.00 / 2,500.00 / 11,100.00 Dr' } };
    }, 'date-boundary')),

    // Date window, account and book filters (T01, T02, T06)
    C('filter.default-dates', 'T01', RO, 'cases.md filter.default-dates; RP_CASH_BANK.cs:3103 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}; RP_CASH_BANK.cs:3122 {{((Control)mFromDt).Focus();}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await page.goto(ROUTE);
      await field(page, 'From').waitFor();
      const d = new Date(), p = (n) => String(n).padStart(2, '0');
      const now = `${p(d.getDate())}/${p(d.getMonth() + 1)}/${d.getFullYear()}`;
      assert.deepEqual([await field(page, 'From').inputValue(), await field(page, 'To').inputValue()], [now, now]);
      assert.ok(await field(page, 'From').evaluate((el) => el === document.activeElement), 'cursor in From');
      return { observation: `From and To are ${now}`, expected: { from: now, to: now } };
    })),
    C('filter.date-window-from', 'T02', RO, `cases.md filter.date-window-from; ${DATE_FROM}`, async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page, { from: '05/11/2026' });
      const rows = await readGrid(page);
      // Before 05/11/2026 only L1 and L2: Dr 7,500.00. Voucher 3 (05/11) is a detail row.
      assertRow(rows[0], { book: 'Op Balance', dr: '7,500.00', bal: '7,500.00', side: 'Dr' });
      assertRow(rowFor(rows, '3'), { date: '05/11/2026', dr: '4,000.00' });
      assertRow(rows.at(-1), TOTALS_A);
      return { observation: 'window from 05/11/2026', expected: { totals: '11,000.00 Dr' } };
    })),
    C('filter.date-window-to', 'T02', RO, `cases.md filter.date-window-to; ${DATE_TO}`, async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const rows = await readGrid(page);
      // L8 (02/12/2026, DR 999) is after To: in neither the opening nor the rows.
      assert.equal(rows.some((r) => r[COL.date] === '02/12/2026'), false, 'L8 excluded');
      assertRow(rows.at(-1), TOTALS_A);
      return { observation: 'L8 not shown', expected: { totals: '11,000.00 Dr' } };
    })),
    C('filter.from-after-to', 'T06', RO, `cases.md filter.from-after-to; ${DATE_BEFORE_FROM}`, async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page, { from: '15/11/2026', to: '10/11/2026' });
      assert.equal(await page.getByRole('dialog').count(), 0, 'no message box');
      const rows = await readGrid(page);
      // Before 15/11/2026: -10000 + 2500 - 4000 + 1500 = -10000: one opening row, Dr 10,000.00.
      assertRow(rows[0], { book: 'Op Balance', dr: '10,000.00', bal: '10,000.00', side: 'Dr' });
      assert.ok(rows.slice(1).every((r) => r[COL.party] === 'Total :'), 'no detail row');
      return { observation: 'opening only, no message', expected: { opening: '10,000.00 Dr' } };
    })),
    C('filter.empty-period', 'T06', RO, `cases.md filter.empty-period; ${DATE_BEFORE_FROM}`, async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page, { from: '03/12/2026', to: '05/12/2026' });
      // Every line before 03/12/2026: CR 5000 - DR (10000 + 4000 + 2000 + 999) = -11999: Dr 11,999.00.
      const rows = await readGrid(page);
      assertRow(rows[0], { book: 'Op Balance', dr: '11,999.00', bal: '11,999.00', side: 'Dr' });
      assert.ok(rows.slice(1).every((r) => r[COL.party] === 'Total :'), 'no detail row');
      return { observation: 'opening Dr 11,999.00 only', expected: { opening: '11,999.00 Dr' } };
    })),
    C('filter.one-account-only', 'T02', RO, `cases.md filter.one-account-only; RP_CASH_BANK.cs:3162 {{AND A.AC_CODE = '" + tAcCode.Text}}`, async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const rows = await readGrid(page);
      // The 00010 line (voucher 5, DR 1000.00) is not shown: one voucher 5 row, and totals without its 1000.00.
      assert.equal(rows.filter((r) => r[COL.vch] === '5').length, 1, 'one voucher 5 row');
      assertRow(rows.at(-1), TOTALS_A);
      return { observation: 'only account 00001', expected: { totals: '13,500.00 Dr' } };
    })),
    C('filter.book-filter', 'T02', RO, `cases.md filter.book-filter; RP_CASH_BANK.cs:3162 {{AND A.CO_BOOK = '" + tBookCode.Text + "'}}`, async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page, { bookCode: '001' });
      const rows = await readGrid(page);
      assert.equal(rows.length, 4, 'opening, voucher 3, voucher 7, totals');
      // CASH REC only: opening Dr 10000; voucher 3 Dr 4000 -> 14,000.00; voucher 7 is zero.
      assertRow(rows[0], { sr: '1', book: 'Op Balance', dr: '10,000.00', bal: '10,000.00', side: 'Dr' });
      assertRow(rowFor(rows, '3'), { dr: '4,000.00', bal: '14,000.00', side: 'Dr' });
      assertRow(rowFor(rows, '7'), { bal: '14,000.00', side: 'Dr' });
      // Totals: Dr 14000; Cr zero, so blank; Bal 14000, Dr.
      assertRow(rows.at(-1), { party: 'Total :', dr: '14,000.00', cr: '', bal: '14,000.00', side: 'Dr' });
      return { observation: 'CASH REC only', expected: { totals: '14,000.00 Dr' } };
    })),
    C('filter.book-empty-all', 'T02', RO, 'cases.md filter.book-empty-all; RP_CASH_BANK.cs:4728 {{tBookName.Text = "";}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page, { bookCode: '001' });
      await field(page, 'Book').fill('');
      await refillBy(page, 'Book');
      const rows = await readGrid(page);
      assert.equal(rows.length, 7, 'opening, five rows, totals: seed A again');
      assertRow(rows.at(-1), TOTALS_A);
      return { observation: 'empty Book returns all books', expected: { totals: '11,000.00 Dr' } };
    })),
    C('filter.book-unknown-code', 'T06', RO, 'cases.md filter.book-unknown-code; RP_CASH_BANK.cs:3315 {{if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page, { bookCode: 'ZZZ' });
      // No line of book ZZZ: an empty grid (the totals row needs a row) and no message.
      assert.equal((await readGrid(page)).length, 0, 'empty grid');
      assert.equal(await page.getByRole('dialog').count(), 0, 'no message');
      return { observation: 'empty grid', expected: { rows: 0 } };
    })),

    // Account lookup (T01, T04)
    C('account.default-00001', 'T01', RO, 'cases.md account.default-00001; RP_CASH_BANK.cs:3118 {{tAcCode.Text = "00001";}}; RP_CASH_BANK.cs:3119 {{tAcName.Text = "CASH ON HAND";}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await page.goto(ROUTE);
      await field(page, 'Party Code').waitFor();
      assert.deepEqual([await field(page, 'Party Code').inputValue(), await field(page, 'Account Name').inputValue()], ['00001', 'CASH ON HAND']);
      return { observation: 'Party Code 00001, CASH ON HAND', expected: { code: '00001', name: 'CASH ON HAND' } };
    })),
    C('account.enter-found', 'T04', RO, 'cases.md account.enter-found; RP_CASH_BANK.cs:3691 {{tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openReport(page);
      await field(page, 'Party Code').fill('00010');
      await refillBy(page, 'Party Code');
      assert.equal(await field(page, 'Account Name').inputValue(), 'TEST BANK');
      assert.ok(await field(page, 'Party Code').evaluate((el) => el === document.activeElement), 'focus stays in Party Code');
      // Account 00010 has one line: 20/11/2026 CONTRA, Dr 1000.00; its counter-party 00001 is CASH ON HAND.
      assertRow((await readGrid(page))[0], { vch: '5', date: '20/11/2026', book: 'CONTRA', dr: '1,000.00', bal: '1,000.00', side: 'Dr', party: 'CASH ON HAND' });
      return { observation: 'TEST BANK found, grid refilled', expected: { name: 'TEST BANK' } };
    })),
    C('account.enter-not-found-help', 'T04', RO, 'cases.md account.enter-not-found-help; RP_CASH_BANK.cs:3677 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; RP_CASH_BANK.cs:3661 {{AND CAST(C.AC_CODE AS INT) < 100}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      const text = await (await openAccountHelp(page)).innerText();
      // Codes below 100 are listed (00001, 00010); codes 101 and 102 (00101, 00102) are not.
      for (const shown of ['00001', 'CASH ON HAND', '00010', 'TEST BANK']) assert.ok(text.includes(shown), `${shown} listed`);
      for (const hidden of ['00101', '00102']) assert.ok(!text.includes(hidden), `${hidden} not listed`);
      return { observation: 'help lists 00001 and 00010', expected: { listed: ['00001', '00010'] } };
    })),
    C('account.help-choose-row', 'T04', RO, 'cases.md account.help-choose-row; RP_CASH_BANK.cs:3684 {{DGV_DETL_FILL();}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      const dialog = await openAccountHelp(page);
      await Promise.all([page.waitForResponse((r) => new URL(r.url()).pathname.startsWith(API)), dialog.getByText('00001', { exact: true }).first().click()]);
      assert.deepEqual([await field(page, 'Party Code').inputValue(), await field(page, 'Account Name').inputValue()], ['00001', 'CASH ON HAND']);
      assert.equal((await readGrid(page)).length, 7, 'grid refilled for 00001');
      return { observation: 'choosing 00001 sets code, name and grid', expected: { name: 'CASH ON HAND' } };
    })),

    // Columns, rows and text (T01, T02)
    C('columns.order-and-captions', 'T01', RO, 'cases.md columns.order-and-captions; RP_CASH_BANK.cs:3189 {{((DataGridView)DGV_DETL).Columns.Add("", "Party Name");}}; RP_CASH_BANK.cs:3201 {{((DataGridView)DGV_DETL).Columns.Add("", "Bal Amt");}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      assert.deepEqual(await readHeaders(page), HEADERS);
      return { observation: 'ten captions, desktop order', expected: { headers: HEADERS } };
    })),
    C('row.voucher-book-and-number', 'T02', RO, 'cases.md row.voucher-book-and-number; RP_CASH_BANK.cs:3257 {{dataTable2.Rows[DC_Main.M]["BOOK_NAME"]}}; RP_CASH_BANK.cs:3258 {{dataTable2.Rows[DC_Main.M]["VCH_NO"]}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      // Book and VchNo are two cells: CASH REC and 3.
      assertRow(rowFor(await readGrid(page), '3'), { book: 'CASH REC', vch: '3' });
      return { observation: 'CASH REC and 3 in separate cells', expected: { book: 'CASH REC', vch: '3' } };
    })),
    C('row.date-format', 'T02', RO, 'cases.md row.date-format; RP_CASH_BANK.cs:3259 {{((DataGridView)dGV_DETL2)[3, num7].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      assert.deepEqual((await readGrid(page)).slice(1, -1).map((r) => r[COL.date]), ['05/11/2026', '12/11/2026', '20/11/2026', '22/11/2026', '25/11/2026']);
      return { observation: 'five dates dd/MM/yyyy', expected: { dates: 5 } };
    })),
    C('row.party-name-counter-party', 'T02', RO, 'cases.md row.party-name-counter-party; RP_CASH_BANK.cs:3289 {{dataTable2.Rows[DC_Main.M]["AC_NAME"]}}; RP_CASH_BANK.cs:3162 {{GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.LEDR_KEY,A.LD_CODE}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const rows = await readGrid(page);
      // Counter-parties: 00101 PARTY ALPHA (voucher 3), 00102 PARTY BETA (voucher 4), 00010 TEST BANK (voucher 5).
      assertRow(rowFor(rows, '3'), { party: 'PARTY ALPHA' });
      assertRow(rowFor(rows, '4'), { party: 'PARTY BETA' });
      assertRow(rowFor(rows, '5'), { party: 'TEST BANK' });
      return { observation: 'counter-party names', expected: { 3: 'PARTY ALPHA', 4: 'PARTY BETA', 5: 'TEST BANK' } };
    })),
    C('row.party-name-sales', 'T02', RO, 'cases.md row.party-name-sales; RP_CASH_BANK.cs:3261 {{(object)"SALES", false))}}; RP_CASH_BANK.cs:3154 {{SELECT CO_BOOK,VCH_NO,AC_NAME FROM SL_DATA}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      // Voucher 6 is SALES: the name is the SL_DATA name PARTY ALPHA, not the counter-party PARTY BETA.
      assertRow(rowFor(await readGrid(page), '6'), { party: 'PARTY ALPHA' });
      return { observation: 'SALES row shows SL_DATA name', expected: { party: 'PARTY ALPHA' } };
    })),
    C('row.hidden-codes-not-shown', 'T01', RO, 'cases.md row.hidden-codes-not-shown; RP_CASH_BANK.cs:3208 {{((DataGridView)DGV_DETL).Columns.Add("", "CoBook");}}; RP_CASH_BANK.cs:3210 {{((DataGridView)DGV_DETL).Columns.Add("", "AcCode");}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const headers = await readHeaders(page);
      for (const hidden of ['CoBook', 'AcCode', 'MainBook']) assert.ok(!headers.includes(hidden), `${hidden} not a column`);
      const cells = (await readGrid(page)).flat();
      for (const code of ['00001', '001', '002', 'CON']) assert.ok(!cells.includes(code), `${code} not shown`);
      return { observation: 'no code columns or cells (Excel header not checked here)', expected: { codesShown: 0 } };
    })),

    // Title and menu (T01)
    C('title.banner-caption', 'T01', RO, 'cases.md title.banner-caption; RP_CASH_BANK.cs:2828 {{lblBook.Text = CurRpt;}}; RP_CASH_BANK.cs:1667 {{lblBook.Text = "Cash and Bank Report";}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await page.goto(ROUTE);
      await field(page, 'Party Code').waitFor();
      await page.getByText('Cash Bank', { exact: true }).first().waitFor();
      assert.equal(await page.getByText('Cash and Bank Report', { exact: true }).count() + await page.getByText('Cash / Bank Book', { exact: true }).count(), 0, 'designer and old titles gone');
      return { observation: 'banner reads Cash Bank', expected: { banner: 'Cash Bank' } };
    })),
    C('title.menu-label', 'T01', RO, 'cases.md title.menu-label; MDI_FORM.cs:8941 {{case "Cash Bank":}}; docs/handbook/menu-editions.json:1553 {{"menu": "Cash Bank",}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await page.goto('/');
      await page.getByText('Cash Bank', { exact: true }).first().waitFor();
      assert.equal(await page.getByText('Cash / Bank Book', { exact: true }).count(), 0, 'old menu label gone');
      return { observation: 'menu entry Cash Bank', expected: { label: 'Cash Bank' } };
    })),
  ],
};
