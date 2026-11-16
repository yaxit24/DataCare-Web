import assert from 'node:assert/strict';

/**
 * Cash Bank report, second half (cases.md drill-down, reset, keyboard, print button; blocked and not-applicable registrations).
 * Rights cases are not here: the kit seeds no user without the print right (MISSING, see the work report).
 * Expected values come from seed A (cashBankReportKit.mjs). The report writes nothing: every case is read-only.
 */
const RO = 'read-only';

/** The voucher number field of the sales and contra screens (both carry aria-label "Voucher No"). */
const VOUCHER_NO = '[aria-label="Voucher No"]';

/** Today in the browser's format dd/MM/yyyy (the same rule as filter.default-dates). */
const today = () => {
  const d = new Date(), p = (n) => String(n).padStart(2, '0');
  return `${p(d.getDate())}/${p(d.getMonth() + 1)}/${d.getFullYear()}`;
};

/** The label of the focused control: its <label> text, else its aria-label or its text. */
const focusedName = (page) => page.evaluate(() => {
  const el = document.activeElement;
  if (!el) return '';
  const label = el.labels && el.labels[0] ? el.labels[0].textContent.trim() : '';
  return label || (el.getAttribute('aria-label') || el.textContent || '').trim();
});

const rowIndexFor = (rows, vch) => {
  const hits = rows.map((r, i) => (r[2] === vch ? i : -1)).filter((i) => i >= 0);
  assert.equal(hits.length, 1, `one row for voucher ${vch}`);
  return hits[0];
};

/** Double-click the detail row of a voucher, then wait for the URL of the target screen and its voucher number. */
async function drillDown(page, kit, vch, routePattern, voucherNumber) {
  const rows = await kit.readGrid(page);
  const index = rowIndexFor(rows, vch);
  await page.locator('table.grid tbody tr').nth(index).dblclick();
  await page.waitForURL(routePattern);
  // Leading zeros are a display choice of the screen, so the number is compared as a number.
  await page.waitForFunction(([sel, n]) => Number(document.querySelector(sel)?.value) === n, [VOUCHER_NO, voucherNumber]);
}

export function ioCases(kit) {
  const { C, blocked, notApplicable, openReport, withSeed, withoutSeed, field, refillBy, readGrid, assertRow, COL } = kit;
  const openA = (page, extra = {}) => openReport(page, { acCode: '00001', ...extra });
  const isFocused = (page, name) => field(page, name).evaluate((el) => el === document.activeElement);

  return [
    // Drill-down (T05). A saved voucher is opened in the page, not by URL; the URL checked is the screen route.
    C('drilldown.sales', 'T05', RO, 'cases.md drilldown.sales; RP_CASH_BANK.cs:3741 {{"SALES", false) == 0)}}; RP_CASH_BANK.cs:3752 {{TR_SALE tR_SALE = new TR_SALE();}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      await drillDown(page, kit, '6', /\/txn\/sales(\?|$)/, 6);
      return { observation: 'sales screen shows voucher 6', expected: { route: '/txn/sales', voucher: 6 } };
    })),
    C('drilldown.contra', 'T05', RO, 'cases.md drilldown.contra; RP_CASH_BANK.cs:3848 {{"CONTRA", false) == 0)}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      await drillDown(page, kit, '5', /\/txn\/contra(\?|$)/, 5);
      return { observation: 'contra screen shows voucher 5', expected: { route: '/txn/contra', voucher: 5 } };
    })),
    blocked('drilldown.cash-rec', 'T05', 'the web screen for the TR_CASH books is not confirmed. RP_CASH_BANK.cs:3813 {{"CASH REC", false) == 0)}} opens TR_CASH, but the web receipt and payment screens (txn/receipt, txn/payment) show no "Voucher No" field, so they cannot be shown to open a saved voucher by number. Confirm the web screen first.'),
    blocked('drilldown.cash-pay', 'T05', 'the web screen for the TR_CASH books is not confirmed (RP_CASH_BANK.cs:3820 {{else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)}}). The txn/receipt and txn/payment screens show no "Voucher No" field. Confirm the web screen first.'),
    blocked('drilldown.bank-rec', 'T05', 'the web screen for the TR_CASH books is not confirmed (RP_CASH_BANK.cs:3827 {{else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)}}). The book code of BANK REC is not in the kit, so the seed line cannot be written. Confirm the book code and the web screen first.'),
    blocked('drilldown.bank-pay', 'T05', 'the web screen for the TR_CASH books is not confirmed (RP_CASH_BANK.cs:3834 {{else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)}}). The book code of BANK PAY is not in the kit, so the seed line cannot be written. Confirm the book code and the web screen first.'),
    blocked('drilldown.sales-order', 'T05', 'the seed line of a SALES ORDER book needs its CO_BOOK code, which the kit does not hold. The web sales-order screen (txn/sales-order) has no "Voucher No" field, so the voucher number cannot be checked there (RP_CASH_BANK.cs:3734 {{if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)}}).'),
    blocked('drilldown.sales-hm-tax', 'T05', 'the Lite web sales screen for the HM-tax setting is not confirmed by this study. The desktop opens the HM-tax form on that branch (RP_CASH_BANK.cs:3743 {{if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)}}). Confirm the web screen first.'),
    blocked('drilldown.purchase', 'T05', 'the desktop branch for PURCHASE opens TR_PURC_HM or TR_PURC (RP_CASH_BANK.cs:3758 {{"PURCHASE", false) == 0)}}). The condition that chooses between them was not read in the study. Read it, then assert the form.'),
    blocked('drilldown.unconfirmed-books', 'T05', 'these books open forms that are not confirmed as Lite screens, or whose forms this study did not read (study open question 2). MEMB OPENING is at RP_CASH_BANK.cs:3890 {{"MEMB OPENING", false) == 0))}}, FINE SALE at RP_CASH_BANK.cs:4117 {{"FINE SALE", false) == 0)}}, and the ITEM branches follow the study Lifecycle list. Decide the Lite scope of each book before this case is run.'),
    blocked('drilldown.opening-row-no-open', 'T05', 'the opening row writes no value to the hidden book column (the opening writes columns 1, 6, 7, 8 and 9 only, RP_CASH_BANK.cs:3226 {{[1, num7].Value = "Op Balance";}}). The drill-down reads column 10 (RP_CASH_BANK.cs:3711 {{.Cells[10].Value}}), and the result of a book lookup with an empty key was not read. Read it, then assert that no form opens.'),

    // Reset (T10)
    C('reset.cancel-clears-all', 'T10', RO, 'cases.md reset.cancel-clears-all; RP_CASH_BANK.cs:3089 {{val.Text = "";}}; RP_CASH_BANK.cs:3103 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}; RP_CASH_BANK.cs:3118 {{tAcCode.Text = "00001";}}; RP_CASH_BANK.cs:3594 {{CLEAR_DATA();}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openReport(page, { acCode: '00001', bookCode: '001', from: '05/11/2026' });
      await page.getByRole('button', { name: 'Cancel', exact: true }).click();
      const now = today();
      assert.equal(await field(page, 'Book').inputValue(), '', 'Book empty');
      assert.deepEqual([await field(page, 'From').inputValue(), await field(page, 'To').inputValue()], [now, now], 'dates are the system date');
      assert.deepEqual([await field(page, 'Party Code').inputValue(), await field(page, 'Account Name').inputValue()], ['00001', 'CASH ON HAND'], 'account reset');
      // The grid refills for 00001 with the default dates: the totals row is always present.
      const rows = await readGrid(page);
      assert.equal(rows.at(-1)[COL.party], 'Total :', 'grid refilled with totals');
      assert.ok(await isFocused(page, 'From'), 'focus in From');
      return { observation: 'Book empty, dates today, 00001 CASH ON HAND, focus in From', expected: { code: '00001', name: 'CASH ON HAND', from: now, to: now } };
    })),
    blocked('reset.delete-button-inert', 'T10', 'owner decision. The desktop shows a Delete button (RP_CASH_BANK.cs:1568 {{BtnDelete.Text = "&Delete";}}) whose click handler is empty (RP_CASH_BANK.cs:2785 {{private void BtnDelete_Click(object sender, EventArgs e)}}). Study weakness 5 says not to port a control that does nothing, so the expected web result is no Delete button. The owner must confirm before the case is run.'),

    // Keyboard (T17)
    C('keyboard.tab-order', 'T17', RO, 'cases.md keyboard.tab-order; RP_CASH_BANK.cs:2023 {{((Control)mFromDt).TabIndex = 0;}}; RP_CASH_BANK.cs:2015 {{((Control)mToDt).TabIndex = 1;}}; RP_CASH_BANK.cs:1675 {{((Control)tAcCode).TabIndex = 2;}}; RP_CASH_BANK.cs:1607 {{((Control)BtnPrint).TabIndex = 3;}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      await field(page, 'From').focus();
      const stops = [await focusedName(page)];
      for (let i = 0; i < 3; i += 1) {
        await page.keyboard.press('Tab');
        stops.push(await focusedName(page));
      }
      assert.deepEqual(stops, ['From', 'To', 'Party Code', 'Print']);
      return { observation: 'From, To, Party Code, Print', expected: { stops: ['From', 'To', 'Party Code', 'Print'] } };
    })),
    C('keyboard.enter-from-moves-on', 'T17', RO, 'cases.md keyboard.enter-from-moves-on; RP_CASH_BANK.cs:4645 {{if ((int)e.KeyCode == 13)}}; RP_CASH_BANK.cs:4648 {{DC_Main.SetDate(ref MsDate);}}; RP_CASH_BANK.cs:4652 {{SendKeys.Send("{tab}");}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      await field(page, 'From').fill('01/11/2026');
      await field(page, 'From').press('Enter');
      assert.ok(await isFocused(page, 'To'), 'focus moves to To');
      return { observation: 'focus on To after Enter in From', expected: { focus: 'To' } };
    })),
    C('keyboard.enter-to-moves-on', 'T17', RO, 'cases.md keyboard.enter-to-moves-on; RP_CASH_BANK.cs:4661 {{if ((int)e.KeyCode == 13)}}; RP_CASH_BANK.cs:4668 {{SendKeys.Send("{tab}");}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      await field(page, 'To').fill('30/11/2026');
      await field(page, 'To').press('Enter');
      assert.ok(await isFocused(page, 'Party Code'), 'focus moves to Party Code');
      return { observation: 'focus on Party Code after Enter in To', expected: { focus: 'Party Code' } };
    })),
    C('keyboard.enter-party-refills', 'T17', RO, 'cases.md keyboard.enter-party-refills; RP_CASH_BANK.cs:3619 {{if ((int)e.KeyCode != 13)}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openReport(page);
      await field(page, 'Party Code').fill('00010');
      await refillBy(page, 'Party Code');
      assert.equal(await field(page, 'Account Name').inputValue(), 'TEST BANK');
      assert.ok(await isFocused(page, 'Party Code'), 'focus stays in Party Code');
      assertRow((await readGrid(page))[0], { vch: '5', book: 'CONTRA', dr: '1,000.00', side: 'Dr', party: 'CASH ON HAND' });
      return { observation: 'TEST BANK, grid refilled, focus in Party Code', expected: { name: 'TEST BANK' } };
    })),
    C('keyboard.enter-book-refills', 'T17', RO, 'cases.md keyboard.enter-book-refills; RP_CASH_BANK.cs:4690 {{if ((int)e.KeyCode != 13)}}; RP_CASH_BANK.cs:4722 {{DGV_DETL_FILL();}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      await field(page, 'Book').fill('001');
      await refillBy(page, 'Book');
      // As filter.book-filter: CASH REC only, four rows, totals 14,000.00 Dr.
      const rows = await readGrid(page);
      assert.equal(rows.length, 4, 'opening, voucher 3, voucher 7, totals');
      assertRow(rows.at(-1), { party: 'Total :', dr: '14,000.00', bal: '14,000.00', side: 'Dr' });
      return { observation: 'CASH REC grid refilled', expected: { totals: '14,000.00 Dr' } };
    })),
    C('keyboard.esc-closes', 'T17', RO, 'cases.md keyboard.esc-closes; RP_CASH_BANK.cs:3442 {{if ((int)e.KeyCode == 27)}}; RP_CASH_BANK.cs:3456 {{((Form)this).Close();}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      await page.keyboard.press('Escape');
      // The report is closed: its Party Code field is gone.
      await field(page, 'Party Code').waitFor({ state: 'detached' });
      return { observation: 'report closed on Esc', expected: { closed: true } };
    })),
    C('keyboard.enter-in-grid-no-action', 'T17', RO, 'cases.md keyboard.enter-in-grid-no-action; RP_CASH_BANK.cs:545 {{((Control)val2).DoubleClick += eventHandler;}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const before = page.url();
      await page.locator('table.grid tbody tr').nth(1).click();
      await page.keyboard.press('Enter');
      await page.keyboard.press('Enter');
      assert.equal(page.url(), before, 'no navigation');
      assert.equal(await page.getByRole('dialog').count(), 0, 'no dialog');
      assert.equal((await readGrid(page)).length, 7, 'grid unchanged');
      return { observation: 'Enter in grid does nothing', expected: { navigation: false } };
    })),
    C('keyboard.upper-case-codes', 'T17', RO, 'cases.md keyboard.upper-case-codes; RP_CASH_BANK.cs:3429 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openReport(page);
      await field(page, 'Party Code').pressSequentially('ab');
      assert.equal(await field(page, 'Party Code').inputValue(), 'AB');
      return { observation: 'typed ab shows AB', expected: { code: 'AB' } };
    })),
    C('keyboard.focus-direct', 'T17', RO, 'cases.md keyboard.focus-direct; RP_CASH_BANK.cs:4652 {{SendKeys.Send("{tab}");}}', async (ctx) => withoutSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      await field(page, 'From').fill('01/11/2026');
      await field(page, 'From').press('Enter');
      assert.ok(await isFocused(page, 'To'), 'focus moves to To directly');
      // Step 2 of the case (repeat while the help list has focus) is not written: the help list is modal and the
      // case does not say how focus is moved into From while it is open. See the work report.
      return { observation: 'focus on To directly', expected: { focus: 'To' } };
    })),

    // Print button (T16). The preview is the GET of the print route; no figure is asserted here.
    C('print.button-opens-preview', 'T16', RO, 'design.md section 5 (GET /reports/cash-bank/print); RP_CASH_BANK.cs:3461 {{private void BtnPrint_Click(object sender, EventArgs e)}}', async (ctx) => withSeed(ctx, async () => {
      const { page } = await ctx.session();
      await openA(page);
      const preview = page.waitForRequest((r) => new URL(r.url()).pathname.endsWith('/reports/cash-bank/print'));
      await page.getByRole('button', { name: 'Print', exact: true }).click();
      await preview;
      return { observation: 'Print requests the preview', expected: { route: '/reports/cash-bank/print' } };
    })),

    // Blocked (taken from the Status line of each entry in cases.md)
    blocked('filter.date-change-no-refresh', 'T02', 'owner decision. Whether the web refreshes on a date change is a desktop-first question. Porting the desktop as is leaves a grid that does not match the dates on screen. Decide before the case is run.'),
    blocked('filter.data-type-rule', 'T02', 'the value of DC_Main.MsDataType for a Lite company is set in MDI_FORM.cs (around lines 12732 to 12790, not read in the study), and the grid and the print rules disagree. The owner must choose one rule for the screen, the totals and the print before this case can be run.'),
    blocked('account.help-location-00', 'T04', 'the group-only query text after RP_CASH_BANK.cs:3659 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}} was not read. Read it in the desktop, then fill the expected rows.'),
    blocked('account.name-readonly', 'T04', 'owner decision. Study open question 3: the designer sets no read-only flag on tAcName (RP_CASH_BANK.cs:1682 {{((Control)tAcName).TabIndex = 1129;}}), so editability is inferred, not confirmed. Confirm in the desktop before choosing the web behaviour.'),
    blocked('rights.ctrl-f11-edition', 'T01', 'study open question 1. The Ctrl+F11 handler does not read the edition (MDI_FORM.cs:14416 {{private void F11CtrlCashBankToolStripMenuItem_Click(object sender, EventArgs e)}}), and whether a Lite operator can reach it depends on a menu item visibility that the study did not read.'),
    blocked('rights.print-no-right-no-desktop-check', 'T11', 'owner decision on the refusal text. The desktop has no message for this case; its only print-right text is RP_CASH_BANK.cs:2540 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}. The desktop Print button has no FRM_PRINT test (RP_CASH_BANK.cs:3461 {{private void BtnPrint_Click(object sender, EventArgs e)}}).'),
    blocked('scope.year-sentinel', 'T11', 'the case list (cases.md scope.year-sentinel) marks this case executable by supervisor decision of 16 November 2026, but its layer is database, not browser, and this packet listed it as blocked. Registered as blocked here until the owner or supervisor settles where its test lives. See the work report.'),
    blocked('print.opening-with-book', 'T16', 'owner decision (study open question 4). The desktop print opening ignores the book filter (RP_CASH_BANK.cs:3541 {{WHERE CO_CODE = \'" + DC_Main.MCo_code + "\' AND LC_CODE = \'" + DC_Main.MLc_code + "\' AND AC_CODE = \'" + tAcCode.Text + "\' and VCH_DATE < \'}} has only company, location, account and date), while the grid opening applies it (RP_CASH_BANK.cs:3160 {{Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0}}). The study records that the source does not say which one the business expects.'),
    blocked('print.balance-zero-side', 'T16', 'owner decision. The template side formula returns Dr below zero and Cr otherwise (extraction_output/rpt_xml/AcLedger.xml:350 {{if {@AcBalance} &lt; 0 then}}), while the grid shows a blank side for zero (RP_CASH_BANK.cs:3297 {{if (num2 - num > 0.0)}}). The desktop disagrees with itself. The owner must choose.'),
    blocked('print.balance-column-format', 'T16', 'the template running balance is signed (extraction_output/rpt_xml/AcLedger.xml:277 {{AcBal := AcBal + {@CrRs} - {@DrRs};}}), while the grid shows the absolute value with a side. The number format of the printed Balance field is not in the read of the template, so the printed form cannot be asserted.'),
    blocked('print.excel-column-set', 'T16', 'the export loop runs over the column indexes from 0 to RP_CASH_BANK.cs:2645 {{num12 = ((DataGridView)DGV_DETL).ColumnCount - 1;}}, but whether hidden columns 10 to 12 are written was not read. Read the loop body that follows line 2645, then assert the column set.'),
    blocked('print.generic-export-layout', 'T16', 'study open question 6. The column layout of the generic CSV, Excel and PDF exports for this report was not read. Read the generic export code, then assert the layout against the desktop grid captions.'),
    blocked('journey.cash-and-bank-entries', 'T18', 'the side of each AC_DATA line that the cash and contra screens write is not in this study. The voucher writer is not in TR_CASH.cs: its only AC_DATA mentions are a balance query (TR_CASH.cs:2702 {{Select AC_CODE,Sum(CR_AMT-DR_AMT) as Amount}}) and a delete (TR_CASH.cs:3071 {{DELETE FROM AC_DATA WHERE CO_CODE}}). Read the save path of TR_CASH and TR_CONTRA, then state the sides and run this case.'),
    blocked('journey.edit-and-cancel-follow', 'T18', 'depends on the edit and cancel rules of TR_CASH and TR_CONTRA, which are not in this study (see journey.cash-and-bank-entries). The report itself writes nothing.'),

    // Not applicable (reasons from the Expected line of each entry in cases.md)
    notApplicable('write.create', 'T07', 'cases.md write.create', 'the report is read-only in cash mode, so there is no voucher to create (study Lifecycle: every query is a SELECT).'),
    notApplicable('write.reopen-no-op', 'T08', 'cases.md write.reopen-no-op', 'nothing is saved, so there is no reopened document to compare. Reopening the report is covered by filter.default-dates.'),
    notApplicable('write.edit', 'T09', 'cases.md write.edit', 'the report has no editable field that writes. The desktop loads the edit right and never reads it again (RP_CASH_BANK.cs:2833 {{UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)"")));}}).'),
    notApplicable('concurrency.two-sessions', 'T12', 'cases.md concurrency.two-sessions', 'a report reads and writes nothing, so there is no state that two sessions can race over.'),
    notApplicable('retry.unknown-ack', 'T13', 'cases.md retry.unknown-ack', 'a read has no financial effect to duplicate.'),
    notApplicable('rollback.partial-write', 'T14', 'cases.md rollback.partial-write', 'there is no write, so there is no rollback path.'),
    notApplicable('lookup.stale-result', 'T04', 'cases.md lookup.stale-result; RP_CASH_BANK.cs:3619 {{if ((int)e.KeyCode != 13)}}', 'the desktop lookup is synchronous: Enter runs the query and fills the box (RP_CASH_BANK.cs:3691 {{tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)"")));}}). No delayed response exists to reject.'),
  ];
}
