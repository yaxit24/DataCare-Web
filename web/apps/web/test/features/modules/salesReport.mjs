import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';

import assert from 'node:assert/strict';
import { inflateRawSync } from 'node:zlib';
import { randomUUID } from 'node:crypto';
import { salesScreen } from './salesInvoice.mjs';

/** Frozen WP-11 browser contracts. No application report implementation is imported.
 * Template expectations: docs/parity/rpall-sales-inventory.md §4 and §6.2.
 * Accessible labels below are the dedicated-screen contract, not selectors for the generic launcher.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, expected, extra = {}) => ({
  id: `sales-report.${id}`,
  group,
  kind,
  source,
  expected,
  applicable: true,
  requiredEvidence: kind === 'output' ? ['browser', 'expected', 'output'] : ['browser', 'expected'],
  run: async (ctx) => {
    const result = await exercises[id](ctx);
    return { expected, ...result };
  },
  ...extra,
});

const writesNothing = (group) => ({
  id: `sales-report.${group.toLowerCase()}.not-applicable`,
  group,
  kind: 'read-only',
  source: 'docs/agent-prompts/lite/00b-REPORT-ADDENDUM.md (report version of the voucher matrix)',
  applicable: false,
  reason:
    'RP_ALL Sales Report writes nothing (every button only builds a selection formula and opens a template, ' +
    'RP_ALL.cs:7572-7678); the addendum turns the voucher groups into filters, totals, drill-down and output, ' +
    'covered by the T02, T03, T05 and T16 cases',
  requiredEvidence: ['browser', 'expected'],
  run: async () => ({}),
});

const ROUTE = '/reports/sales-report';
const button = (page, name) => page.getByRole('button', { name, exact: true });
const field = (page, name) => page.getByLabel(name, { exact: true });
const MODES = [
  ['Sales Report', 'SaleReport'],
  ['Sales Reg', 'SalesSumm'],
  ['Item Wise', 'SalesItem'],
  ['Group Sales', 'SalesGroupWise'],
  ['Employ  Sales', 'EmpSaleReport'],
  ['Sale With Order', 'SalesWithOrder'],
];
// RP_ALL.cs:4723 {{BtnSlRpt.Text = "&Sales Report";}}
// RP_ALL.cs:4749 {{BtnSalesReg.Text = "&Sales Reg";}}
// RP_ALL.cs:4775 {{BtnSalesItem.Text = "&Item Wise";}}
const BUTTONS = [
  'Sales Report',
  'Sales Reg',
  'Item Wise',
  'Sales Bill',
  'Wh Sales',
  'Employ  Sales',
  'Cash/Bank Bill',
  'Wh Summ',
  'Emp  WhSales',
  'Counter Sales',
  'Sale With Order',
  'Group Sales',
  'Labour Work',
];
const pending = {
  return:
    'G246: Sales Return writer leaves RTN_NET_AMT zero; inventory §6.9. T07/T18 return variants remain blocked.',
  print: 'MISSING: SalesRtnA4Print template; return-bill output remains blocked (inventory §5).',
};
const today = () => {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
};
// RP_ALL.cs:5619 {{mFromDt.Mask = "00/00/0000";}}: the date boxes are dd/MM/yyyy masks, not ISO inputs.
const display = (iso) => iso.replace(/^(\d{4})-(\d{2})-(\d{2})$/, '$3/$2/$1');
async function openReport(page) {
  await page.goto('/dashboard');
  const link = page.getByRole('link', { name: 'Sales Report', exact: true });
  // The sidebar is drawn after /me answers (gstReport.mjs waits the same way); count() alone races the render.
  await link.waitFor();
  assert.equal(await link.count(), 1, 'Reports navigation must expose Sales Report');
  assert.equal(
    await link.getAttribute('href'),
    ROUTE,
    'Sales Report must open its dedicated route',
  );
  await link.click();
  await page.waitForURL(`**${ROUTE}`);
  await page.getByRole('heading', { name: 'Sales Report', exact: true }).waitFor();
}
async function setField(page, label, value) {
  const input = field(page, label);
  if (label === 'From Date' || label === 'To Date') value = display(value);
  if (await input.evaluate((el) => el.tagName === 'SELECT')) await input.selectOption(value);
  else {
    await input.fill(value);
    await input.press('Tab');
  }
}
async function runReport(page, caption = 'Sales Report', answer = false) {
  // RP_ALL.cs:7584 {{if ((int)Interaction.MsgBox((object)"Sales Return (Creditnote) Report", (MsgBoxStyle)260, (object)DC_Main.MsgTitle) == 6)}}
  // RP_ALL.cs:11749 {{if ((int)Interaction.MsgBox((object)"Only Item Sales With Order", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)}}
  const prompt =
    caption === 'Sale With Order'
      ? 'Only Item Sales With Order'
      : 'Sales Return (Creditnote) Report';
  const needsPrompt = ['Sales Report', 'Sales Reg', 'Item Wise', 'Sale With Order'].includes(
    caption,
  );
  let message;
  const onDialog = async (dialog) => {
    message = dialog.message();
    await (answer ? dialog.accept() : dialog.dismiss());
  };
  if (needsPrompt) page.once('dialog', onDialog);
  try {
    const responsePromise = page.waitForResponse(
      (r) => new URL(r.url()).pathname === `/api${ROUTE}` && r.request().method() === 'GET',
    );
    await button(page, caption).click();
    // Either an accessible web dialog or a native confirm implements the same desktop prompt.
    const dialog = page.getByRole('dialog').filter({ hasText: prompt });
    if (await dialog.count()) {
      message = await dialog.innerText();
      await dialog.getByRole('button', { name: answer ? 'Yes' : 'No', exact: true }).click();
    }
    const response = await responsePromise;
    assert.equal(response.status(), 200, 'report request succeeds');
    if (needsPrompt) assert.ok(message?.includes(prompt), `expected prompt: ${prompt}`);
    const result = await response.json();
    assert.equal(result.template, MODES.find(([name]) => name === caption)[1]);
    await page.locator('table').first().waitFor();
    return { result, query: new URL(response.url()).search };
  } finally {
    page.removeListener('dialog', onDialog);
  }
}
function ids(result) {
  return [...new Set(result.rows.map((row) => row.voucherKey))].sort();
}
function assertIds(result, vouchers) {
  assert.deepEqual(ids(result), vouchers.map((v) => `01|${v.book}|${v.no}`).sort());
}
async function visibleVouchers(page, vouchers) {
  for (const v of vouchers)
    await page.getByRole('cell', { name: v.no, exact: true }).first().waitFor();
}
function near(actual, expected, label) {
  assert.ok(
    Number.isFinite(actual) && Math.abs(actual - expected) < 0.005,
    `${label}: expected ${expected}, received ${actual}`,
  );
}
// SaleReport.xml Section10; SalesSumm.xml Sections7/8; inventory §6.2 explicitly counts bills once.
// Integer-priced fixtures avoid coupling the report oracle to the Sale writer's rounding implementation.
const LINES = [
  {
    itCode: 'GLD22',
    pcs: 1,
    grossWt: 2.2,
    netWt: 2,
    touch: 91.6,
    rate: 6000,
    labourType: 'fixed',
    labourFixed: 100,
  },
  {
    itCode: 'SLV92',
    pcs: 2,
    grossWt: 3.3,
    netWt: 3,
    touch: 92.5,
    rate: 80,
    labourType: 'fixed',
    labourFixed: 20,
  },
];
function sums(vouchers) {
  const out = { net: 0, tax: 0, total: 0, pcs: 0, gwt: 0, nwt: 0, labour: 0 };
  for (const v of vouchers) {
    let net = 0;
    for (const l of v.lines) {
      net += l.netWt * l.rate + (l.labourFixed ?? 0);
      out.pcs += l.pcs;
      out.gwt += l.grossWt;
      out.nwt += l.netWt;
      out.labour += l.labourFixed ?? 0;
    }
    out.net += net;
    out.tax += net * 0.03;
    out.total += net * 1.03;
  }
  return out;
}
function assertTotals(result, vouchers, register = false) {
  const e = sums(vouchers);
  const totals = register
    ? {
        netAmt: e.net,
        cgstTax: e.tax / 2,
        sgstTax: e.tax / 2,
        totAmt: e.total,
        cashAmt: 0,
        chqAmt: 0,
        advAmt: 0,
        oldGlAmt: 0,
        oldSlAmt: 0,
        kasarAmt: 0,
        billOs: e.total,
        nwt: e.nwt,
      }
    : {
        itmAmt: e.net,
        discAmt: 0,
        taxAmt: e.tax,
        vchAmt: e.total,
        pcs: e.pcs,
        gwt: e.gwt,
        nwt: e.nwt,
        lbrAmt: e.labour,
      };
  for (const [key, value] of Object.entries(totals)) near(result.totals[key], value, key);
  assert.equal(result.voucherCount, vouchers.length);
  return totals;
}
async function removeSale(page, voucher) {
  const base = `/api/sales/${voucher.no}?coBook=${voucher.book}`;
  const read = await page.request.get(base);
  if (read.status() === 404) return;
  assert.equal(read.status(), 200, 'cleanup reads current version');
  const body = await read.json();
  const deleted = await page.request.delete(
    `${base}&expectedVersion=${encodeURIComponent(body.version)}`,
  );
  assert.equal(deleted.status(), 200, 'cleanup deletes only its own voucher');
}
async function fixture(ctx, page, work) {
  // AC_MAST.AC_CODE is varchar(8): 'W11' + 5 hex digits is the longest unique code that fits.
  const code = `W11${randomUUID().replaceAll('-', '').slice(0, 5).toUpperCase()}`;
  const vouchers = [];
  await ctx.rows(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE","AC_CITY","AC_AREA")
    VALUES ($1,'01','01',$2,'WP11 SNAPSHOT','10','L','WP11 CITY','WP11 AREA') RETURNING 1`,
    code,
  );
  const create = async ({ date = today(), book = 'SL', lines = LINES } = {}) => {
    const payload = {
      acCode: code,
      acName: 'WP11 SNAPSHOT',
      vchDate: date,
      taxRatePct: 3,
      interState: false,
      lines,
    };
    const response = await page.request.post(`/api/sales?coBook=${book}`, { data: payload });
    assert.equal(response.status(), 201, 'Sales Invoice API seeds source voucher');
    const body = await response.json();
    const v = { no: String(body.vchNo).padStart(5, '0'), book, date, lines, payload };
    vouchers.push(v);
    return v;
  };
  try {
    return await work({ code, vouchers, create });
  } finally {
    for (const v of [...vouchers].reverse()) await removeSale(page, v);
    await ctx.rows(
      `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$2 RETURNING 1`,
      code,
    );
  }
}
async function scoped(page, code, from = today(), to = from) {
  await setField(page, 'From Date', from);
  await setField(page, 'To Date', to);
  await setField(page, 'Party Code', code);
}
async function withFixture(ctx, work) {
  const { page } = await ctx.session();
  await openReport(page);
  return fixture(ctx, page, async (f) => {
    const evidence = await work(page, f);
    await ctx.shot(page, 'sales-report');
    return evidence;
  });
}
async function footprint(ctx) {
  return ctx.rows(`SELECT (SELECT count(*) FROM "SL_DATA" WHERE tenant_id=$1)::int sales,
    (SELECT count(*) FROM "SL_DETL" WHERE tenant_id=$1)::int lines,
    (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1)::int ledger,
    (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1)::int stock`);
}
const exercises = {
  async 'entry.defaults-and-thirteen-buttons'(ctx) {
    const { page } = await ctx.session();
    await openReport(page);
    // RP_ALL.cs:7197 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}
    // RP_ALL.cs:7203 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}
    assert.equal(await field(page, 'From Date').inputValue(), display(today()));
    assert.equal(await field(page, 'To Date').inputValue(), display(today()));
    // RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}}
    assert.equal(await field(page, 'lc Code').inputValue(), '01');
    assert.equal(await field(page, 'lc Code').isDisabled(), true);
    // RP_ALL.cs:6680 {{((Control)cboEmploy).Visible = true;}}
    // RP_ALL.cs:6681 {{((Control)chkBookSelect).Visible = true;}}
    assert.equal(await field(page, 'Employ').isVisible(), true);
    assert.equal(await field(page, 'Select Book').isVisible(), true);
    assert.equal(await field(page, 'State').isVisible(), false);
    for (const caption of BUTTONS)
      assert.equal(await button(page, caption).isVisible(), true, caption);
    for (const caption of ['Item Bill', 'B2B Bill'])
      assert.equal(await button(page, caption).isVisible(), false);
    const { page: denied } = await ctx.session(as(USERS.printViewer.user));
    assert.equal(
      (await denied.request.get(`/api${ROUTE}?fromDate=${today()}&toDate=${today()}`)).status(),
      403,
    );
    await ctx.shot(page, 'defaults');
    return { observation: 'Dedicated navigation, defaults, Lite actions and API right checked' };
  },
  async 'filters.one-at-a-time'(ctx) {
    return withFixture(ctx, async (page, { code, create }) => {
      const a = await create({ lines: [LINES[0]] });
      const b = await create({ lines: [LINES[1]] });
      await scoped(page, code);
      // RP_ALL.cs:7631 {{CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";}}
      const selectors = [
        ['Book', 'SL', [a, b]],
        ['City', 'WP11 CITY', [a, b]],
        ['Area', 'WP11 AREA', [a, b]],
        ['Item Type', 'Gold', [a]],
        ['Item Type', 'Silver', [b]],
        ['Employ', 'WP11-NONE', []],
      ];
      for (const [label, value, expected] of selectors) {
        await setField(page, label, value);
        const { result } = await runReport(page);
        assertIds(result, expected);
        await visibleVouchers(page, expected);
        await setField(page, label, '');
      }
      await setField(page, 'Gr Code', 'E1');
      const item = await runReport(page, 'Item Wise');
      assertIds(item.result, [a]);
      const register = await runReport(page, 'Sales Reg');
      assertIds(register.result, [a, b]);
      assert.ok(register.result.ignoredFilters.includes('grCode'));
      await page
        .getByText(/ignored/i)
        .first()
        .waitFor();
      await setField(page, 'Gr Code', '');
      // RP_ALL.cs:11398 {{Interaction.MsgBox((object)"Book Selection is Ok...", (MsgBoxStyle)0, (object)null);}}
      await field(page, 'Select Book').check();
      // FSL Fine Sale, SL Sales and TSL Tour Sales all contain "SL": pick the book whose code is SL.
      await page.getByRole('checkbox', { name: /^SL / }).check();
      await button(page, 'Ok').click();
      await page.getByText('Book Selection is Ok...', { exact: true }).waitFor();
      assertIds((await runReport(page)).result, [a, b]);
      return {
        observation: 'Independent selector results and ignored group selector checked',
        expected: { gold: 1, silver: 1, book: 2, employee: 0 },
      };
    });
  },
  async 'filters.combined-and-year-boundary'(ctx) {
    return withFixture(ctx, async (page, { code, create }) => {
      const year = Number(today().slice(0, 4)) - (Number(today().slice(5, 7)) < 4 ? 1 : 0);
      const from = `${year}-04-01`,
        to = `${year + 1}-03-31`;
      const a = await create({ date: from });
      const b = await create({ date: to });
      await scoped(page, code, from, to);
      await setField(page, 'Book', 'SL');
      await setField(page, 'City', 'WP11 CITY');
      assertIds((await runReport(page)).result, [a, b]);
      await setField(page, 'City', 'WP11 OTHER');
      assertIds((await runReport(page)).result, []);
      await setField(page, 'City', 'WP11 CITY');
      await setField(page, 'From Date', `${year}-04-02`);
      assertIds((await runReport(page)).result, [b]);
      await setField(page, 'To Date', `${year + 1}-03-30`);
      assertIds((await runReport(page)).result, []);
      return {
        observation: 'Fiscal endpoints are inclusive; conjunction and excluded endpoints checked',
      };
    });
  },
  async 'formula.register-report-totals'(ctx) {
    return withFixture(ctx, async (page, { code, create }) => {
      const vouchers = [await create(), await create({ lines: [LINES[1]] })];
      await scoped(page, code);
      const report = await runReport(page);
      assertIds(report.result, vouchers);
      const expected = assertTotals(report.result, vouchers);
      await visibleVouchers(page, vouchers);
      const register = await runReport(page, 'Sales Reg');
      const reg = assertTotals(register.result, vouchers, true);
      assert.equal(register.result.groups.length, 1);
      for (const [key, value] of Object.entries(reg))
        near(register.result.groups[0].totals[key], value, key);
      await page.getByRole('cell', { name: 'DATE TOTAL :', exact: true }).waitFor();
      return {
        observation: 'Multi-line bills counted once in both templates and date subtotal',
        expected: { report: expected, register: reg },
      };
    });
  },
  async 'formula.item-group-employee-order'(ctx) {
    return withFixture(ctx, async (page, { code, create }) => {
      const v = await create();
      await scoped(page, code);
      for (const mode of ['Item Wise', 'Group Sales']) {
        const { result } = await runReport(page, mode);
        near(result.totals.lineNetAmt, sums([v]).net, 'line net');
        near(result.totals.nwt, 5, 'weight');
        const groups = result.groups.filter((g) => g.depth === 0);
        assert.deepEqual(groups.map((g) => g.key).sort(), ['G', 'S']);
        near(groups.find((g) => g.key === 'G').totals.lineNetAmt, 12100, 'gold subtotal');
        near(groups.find((g) => g.key === 'S').totals.lineNetAmt, 260, 'silver subtotal');
        if (mode === 'Group Sales') {
          assert.deepEqual(result.rows, []);
          near(result.totals.itmTotAmt, 12360 * 1.03, 'group total incl tax');
        }
      }
      const employee = (await runReport(page, 'Employ  Sales')).result;
      assert.equal(employee.grandTotal, false);
      near(employee.groups[0].totals.vchAmt, 12360 * 1.03, 'employee total');
      await page.getByRole('cell', { name: 'Total :', exact: true }).first().waitFor();
      const order = (await runReport(page, 'Sale With Order')).result;
      near(order.totals.lineNetAmt, 12360, 'order detail total');
      near(order.totals.pcs, 3, 'order pcs');
      assert.equal((await runReport(page, 'Sale With Order', true)).result.rows.length, 0);
      return {
        observation: 'Item/group header sums, employee footer and order prompt checked',
        expected: sums([v]),
      };
    });
  },
  async 'lookup.party-book-product-group'(ctx) {
    return withFixture(ctx, async (page, { code }) => {
      for (const [label, value] of [
        ['Party Code', code],
        ['Book', 'SL'],
        ['Gr Code', 'E1'],
      ]) {
        await field(page, label).fill('WP11 UNKNOWN');
        await field(page, label).press('Enter');
        const dialog = page.getByRole('dialog');
        await dialog.waitFor();
        await page.keyboard.press('Escape');
        assert.equal(await dialog.isVisible(), false);
        await field(page, label).fill(value);
        await field(page, label).press('Enter');
        if (await dialog.isVisible()) await dialog.getByText(value, { exact: true }).click();
        assert.equal(await field(page, label).inputValue(), value);
      }
      await field(page, 'Pr Code').fill('WP11 UNKNOWN');
      await field(page, 'Pr Code').press('Enter');
      await page.getByRole('dialog').waitFor();
      await page.keyboard.press('Escape');
      // Exercise real overlapping lookups without mocking either business response.
      await field(page, 'Party Code').fill('WP11 UNKNOWN');
      await field(page, 'Party Code').press('Enter');
      await page.keyboard.press('Escape');
      await field(page, 'Party Code').fill(code);
      await field(page, 'Party Code').press('Tab');
      await page.waitForLoadState('networkidle');
      assert.equal(await field(page, 'Party Code').inputValue(), code);
      return {
        observation: 'Enter/help, selection, cancellation and overlapping party lookup checked',
      };
    });
  },
  async 'grouping.templates-and-zoom'(ctx) {
    return withFixture(ctx, async (page, { code, create }) => {
      const v = await create();
      await scoped(page, code);
      const expected = [
        ['coBook'],
        ['vchDate'],
        ['itType', 'prCode'],
        ['itType', 'grCode'],
        ['empCode'],
        [],
      ];
      for (let i = 0; i < MODES.length; i++) {
        const { result } = await runReport(page, MODES[i][0]);
        assert.deepEqual(
          result.groupLevels.map((g) => g.key),
          expected[i],
        );
      }
      await runReport(page);
      await page.getByRole('cell', { name: v.no, exact: true }).first().dblclick();
      await page.waitForURL('**/txn/sales**');
      // The Sales Invoice screen loads the voucher after the route opens (GET /sales/:no).
      const voucherNo = page.getByLabel('Voucher No', { exact: true });
      for (let i = 0; i < 50 && (await voucherNo.inputValue()) !== v.no; i++)
        await page.waitForTimeout(100);
      assert.equal(await page.getByLabel('Voucher No', { exact: true }).inputValue(), v.no);
      // The number box alone proves the route opened, not that the sale loaded: the party the GET
      // returned must also render (page.tsx setAcName), so a zoom that loaded nothing cannot pass.
      const customer = salesScreen.field(page, 'Customer Name');
      for (let i = 0; i < 50 && (await customer.inputValue()) !== v.payload.acName; i++)
        await page.waitForTimeout(100);
      assert.equal(await customer.inputValue(), v.payload.acName);
      await page.goBack();
      await page.waitForURL(`**${ROUTE}`);
      await visibleVouchers(page, [v]);
      return {
        observation: 'Six template group hierarchies and voucher zoom/back checked',
        expected: { party: v.payload.acName },
      };
    });
  },
  async 'invalid.dates-and-empty'(ctx) {
    const { page } = await ctx.session();
    await openReport(page);
    const before = await footprint(ctx);
    const requests = [];
    const listener = (r) => {
      if (new URL(r.url()).pathname === `/api${ROUTE}`) requests.push(r.url());
    };
    page.on('request', listener);
    // RP_ALL.cs:7510-7524 mFromDt_KeyDown runs DC_Main.SetDate (DC_Main.cs:1561-1683): an impossible day is refused with
    // "Date Not Valid..." and nothing runs. (An empty box is not invalid: SetDate completes it to today.)
    await field(page, 'From Date').fill('32/01/2026');
    await button(page, 'Sales Report').click();
    await page.getByRole('alertdialog', { name: 'Date Not Valid...' }).waitFor();
    assert.deepEqual(requests, []);
    page.removeListener('request', listener);
    await page.getByRole('alertdialog').getByRole('button', { name: 'OK', exact: true }).click();
    await scoped(page, 'WP11-NONE', '2026-04-02', '2026-04-01');
    const { result } = await runReport(page);
    assert.deepEqual(result.rows, []);
    assert.ok(Object.values(result.totals).every((n) => n === 0));
    await scoped(page, 'WP11-NONE');
    assertIds((await runReport(page)).result, []);
    const after = await footprint(ctx);
    assert.deepEqual(after, before);
    return {
      observation: 'Invalid date refused before request; reversed and empty ranges are empty',
      database: { before, after },
    };
  },
  async 'source.create-edit-delete-return'(ctx) {
    return lifecycle(ctx, false);
  },
  async 'scope.tenant-company-location-year-book-rights'(ctx) {
    return withFixture(ctx, async (page, { code, create }) => {
      const v = await create();
      await scoped(page, code);
      const before = await footprint(ctx);
      const { result, query } = await runReport(page);
      assertIds(result, [v]);
      assertTotals(result, [v]);
      await setField(page, 'Book', 'WP11-NONE');
      assertIds((await runReport(page)).result, []);
      const { page: denied } = await ctx.session(as(USERS.printViewer.user));
      for (const suffix of ['', '/export.csv', '/export.xlsx'])
        assert.equal((await denied.request.get(`/api${ROUTE}${suffix}${query}`)).status(), 403);
      // RP_ALL.cs:6660-6665: outside head office the report location is locked; naming one (even repeated)
      // is refused rather than widening or switching the branch.
      for (const extra of ['&reportLcCode=02', '&reportLcCode=01&reportLcCode=02']) {
        const locked = await page.request.get(`/api${ROUTE}${query}${extra}`);
        assert.equal(locked.status(), 400);
        assert.equal((await locked.json()).error, 'location-locked');
      }
      const after = await footprint(ctx);
      assert.deepEqual(after, before);
      return {
        observation:
          'Exact own voucher set, book narrowing and unauthorized report/exports checked',
        database: { before, after },
      };
    });
  },
  async 'history.live-master-and-snapshot'(ctx) {
    return withFixture(ctx, async (page, { code, create }) => {
      const v = await create();
      await ctx.rows(
        `UPDATE "AC_MAST" SET "AC_NAME"='WP11 RENAMED' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$2 RETURNING 1`,
        code,
      );
      await scoped(page, code);
      // SaleReport.xml Section4 binds SL_DATA.AC_NAME; SalesSumm.xml binds AC_MAST.AC_NAME (inventory §4).
      const report = (await runReport(page)).result;
      assertIds(report, [v]);
      assert.equal(report.rows.find((r) => r.level === 'voucher').cells.acName, 'WP11 SNAPSHOT');
      await page.getByRole('cell', { name: 'WP11 SNAPSHOT', exact: true }).waitFor();
      const register = (await runReport(page, 'Sales Reg')).result;
      assert.equal(
        register.rows.find((r) => r.level === 'voucher').cells.partyName,
        'WP11 RENAMED',
      );
      await page.getByRole('cell', { name: 'WP11 RENAMED', exact: true }).waitFor();
      return { observation: 'Bill snapshot and live party name remain distinct after master edit' };
    });
  },
  async 'output.grid-pdf-xlsx-csv-match'(ctx) {
    return outputs(ctx);
  },
  async 'keyboard.selector-run-flow'(ctx) {
    const { page } = await ctx.session();
    await openReport(page);
    // Enter on an empty Pr Code jumps straight to City (RP_ALL.cs:7505 {{((Control)cboCity).Focus();}}); Gr Code and Party
    // Code send {tab} (:9291, :7427), so they are walked from their own boxes. lc Code is disabled for a location user.
    const walk = async (flow) => {
      await field(page, flow[0]).focus();
      for (let i = 1; i < flow.length; i++) {
        await page.keyboard.press('Enter');
        assert.equal(
          await field(page, flow[i]).evaluate((el) => el === document.activeElement),
          true,
          flow[i],
        );
      }
    };
    await walk(['From Date', 'To Date', 'Book', 'Pr Code', 'City', 'Area', 'Item Type']);
    await walk(['Gr Code', 'Party Code', 'City']);
    const accesskey = await button(page, 'Sales Report').getAttribute('accesskey');
    assert.ok(accesskey, 'Sales Report access key');
    const response = page.waitForResponse((r) => new URL(r.url()).pathname === `/api${ROUTE}`);
    page.once('dialog', (d) => d.dismiss());
    await page.keyboard.press(`Alt+${accesskey}`);
    const dialog = page.getByRole('dialog').filter({ hasText: 'Sales Return (Creditnote) Report' });
    if (await dialog.isVisible()) {
      await dialog.getByRole('button', { name: 'No', exact: true }).focus();
      await page.keyboard.press('Enter');
    }
    assert.equal((await response).status(), 200);
    // RP_ALL.cs:7261-7263 {{((Form)this).Close();}}
    await page.keyboard.press('Escape');
    await page.waitForURL((url) => url.pathname !== ROUTE);
    return { observation: 'Keyboard selector traversal, access key, No and Escape checked' };
  },
  async 'journey.create-edit-delete-return-reconcile'(ctx) {
    return lifecycle(ctx, true);
  },
};

async function lifecycle(ctx, reconcile) {
  return withFixture(ctx, async (page, { code, vouchers }) => {
    await salesScreen.openSales(page);
    await salesScreen.pickParty(page, code);
    await salesScreen.fillLine(page, 0, {
      item: 'GLD22',
      pcs: '1',
      gross: '2.2',
      net: '2',
      touch: '91.6',
      rate: '6000',
      making: '50',
    });
    await button(page, '+ Add line').click();
    await salesScreen.fillLine(page, 1, {
      item: 'SLV92',
      pcs: '2',
      gross: '3.3',
      net: '3',
      touch: '92.5',
      rate: '80',
      making: '0',
    });
    const saved = await salesScreen.save(page);
    assert.equal(saved.status(), 201);
    const no = String((await saved.json()).vchNo).padStart(5, '0');
    const v = { no, book: 'SL', lines: [LINES[0], { ...LINES[1], labourFixed: 0 }] };
    vouchers.push(v);
    const observations = [];
    const check = async () => {
      await openReport(page);
      await scoped(page, code);
      const { result } = await runReport(page);
      assertIds(result, [v]);
      assertTotals(result, [v]);
      await visibleVouchers(page, [v]);
      const h = await salesScreen.header(ctx, no);
      const ledger = await salesScreen.ledger(ctx, no);
      const expected = sums([v]);
      near(h[0].net, expected.net, 'persisted net');
      near(h[0].tax, expected.tax, 'persisted tax');
      near(h[0].tot, expected.total, 'persisted bill total');
      if (reconcile) {
        near(
          ledger.reduce((sum, r) => sum + r.dr - r.cr, 0),
          0,
          'balanced ledger',
        );
        near(
          ledger.filter((r) => r.ac === code).reduce((sum, r) => sum + r.dr - r.cr, 0),
          expected.total,
          'party ledger reconciles',
        );
      }
      observations.push({ expected, header: h, ledger });
    };
    await check();
    const load = async () => {
      await salesScreen.openSales(page);
      await page.getByLabel('Voucher No', { exact: true }).fill(no);
      await button(page, 'Load').click();
      await page
        .getByTestId('sales-loaded')
        .filter({ hasText: `Loaded #${no}` })
        .waitFor();
    };
    await load();
    await salesScreen.cell(page, 0, 6).fill('6100');
    assert.equal((await salesScreen.save(page, 'Update Invoice')).status(), 200);
    v.lines = [{ ...v.lines[0], rate: 6100 }, v.lines[1]];
    await check();
    await load();
    const [deleted] = await Promise.all([
      page.waitForResponse(
        (r) => r.request().method() === 'DELETE' && /\/api\/sales\//.test(r.url()),
      ),
      button(page, 'Delete').click(),
    ]);
    assert.equal(deleted.status(), 200);
    vouchers.splice(vouchers.indexOf(v), 1);
    await openReport(page);
    await scoped(page, code);
    const empty = (await runReport(page)).result;
    assertIds(empty, []);
    assertTotals(empty, []);
    const remaining = {
      header: await salesScreen.header(ctx, no),
      lines: await salesScreen.lines(ctx, no),
      ledger: await salesScreen.ledger(ctx, no),
    };
    assert.deepEqual(remaining, { header: [], lines: [], ledger: [] });
    // Preserve the unresolved branch in coverage without preventing the sale lifecycle from running.
    return {
      status: 'blocked',
      observation: `Sale create/edit/delete executed. ${pending.return}`,
      expected: { sale: 'create/edit/delete reconcile', return: pending.return },
      database: { observations, remaining },
      downstream: { empty },
    };
  });
}
function parseCsv(text) {
  const rows = [];
  let row = [],
    cell = '',
    quoted = false;
  for (let i = 0; i < text.length; i++) {
    const ch = text[i];
    if (ch === '"') {
      if (quoted && text[i + 1] === '"') {
        cell += '"';
        i++;
      } else quoted = !quoted;
    } else if (ch === ',' && !quoted) {
      row.push(cell);
      cell = '';
    } else if (ch === '\n' && !quoted) {
      row.push(cell.replace(/\r$/, ''));
      rows.push(row);
      row = [];
      cell = '';
    } else cell += ch;
  }
  if (cell || row.length) {
    row.push(cell);
    rows.push(row);
  }
  return rows;
}
async function outputs(ctx) {
  return withFixture(ctx, async (page, { code, create }) => {
    const vouchers = [];
    for (let i = 0; i < 55; i++) vouchers.push(await create({ lines: [LINES[i % 2]] }));
    await scoped(page, code);
    const captures = [];
    for (const [caption] of MODES) {
      const { result } = await runReport(page, caption);
      if (caption === 'Sales Report') assertTotals(result, vouchers);
      if (caption === 'Sales Reg') assertTotals(result, vouchers, true);
      const exports = {};
      for (const [label, suffix] of [
        ['CSV', 'csv'],
        ['Excel', 'xlsx'],
      ]) {
        const [download] = await Promise.all([
          page.waitForEvent('download'),
          button(page, label).click(),
        ]);
        assert.equal(await download.failure(), null);
        const stream = await download.createReadStream();
        const chunks = [];
        for await (const chunk of stream) chunks.push(chunk);
        exports[suffix] = Buffer.concat(chunks);
      }
      const csv = parseCsv(exports.csv.toString('utf8'));
      const sheets = readXlsx(exports.xlsx);
      assert.equal(sheets.length, 1);
      const width = csv[0].length;
      const normalized = sheets[0].rows.map((row) =>
        Array.from({ length: width }, (_, i) => row[i] ?? ''),
      );
      assert.deepEqual(normalized, csv, 'CSV and XLSX preserve every band and cell');
      const headers = await page.locator('table thead tr').last().locator('th').allTextContents();
      assert.deepEqual(headers, csv[0], 'grid and export column order');
      // The frozen case requires every page, not only the first visible page.
      const gridRows = [];
      for (let n = 0; n < 100; n++) {
        gridRows.push(
          ...(await page
            .locator('table tbody tr')
            .evaluateAll((rows) =>
              rows.map((row) =>
                [...row.querySelectorAll('td')].map((cell) => cell.textContent.trim()),
              ),
            )),
        );
        const next = button(page, 'Next');
        if (!(await next.count()) || (await next.isDisabled())) break;
        await next.click();
      }
      const footer = await page
        .locator('table tfoot tr')
        .evaluateAll((rows) =>
          rows.map((row) => [...row.querySelectorAll('td')].map((cell) => cell.textContent.trim())),
        );
      // The export indents a nested band label with spaces (exportRows.ts); a table cell's text is trimmed, so only that
      // leading indent of the Band column is ignored in this comparison. Everything else is compared exactly.
      const unindent = (rows) => rows.map(([band, ...rest]) => [band.trimStart(), ...rest]);
      assert.deepEqual(
        [...gridRows, ...footer],
        unindent(csv.slice(1)),
        'grid pages and output rows match',
      );
      const [popup] = await Promise.all([
        page.waitForEvent('popup'),
        button(page, 'Print').click(),
      ]);
      await popup.waitForLoadState();
      const printRows = await popup
        .locator('table tr')
        .evaluateAll((rows) =>
          rows.map((row) =>
            [...row.querySelectorAll('th,td')].map((cell) => cell.textContent.trim()),
          ),
        );
      assert.deepEqual(
        printRows,
        [csv[0], ...unindent(csv.slice(1))],
        'print includes the complete report',
      );
      const pdf = await popup.pdf({ format: 'A4' });
      assert.ok(pdf.subarray(0, 5).equals(Buffer.from('%PDF-')));
      captures.push({
        caption,
        csv: exports.csv.toString('base64'),
        xlsx: exports.xlsx.toString('base64'),
        pdf: pdf.toString('base64'),
      });
      await popup.close();
    }
    return {
      status: 'blocked',
      observation: `Six sale templates checked over 55 vouchers. ${pending.print}`,
      expected: { vouchers: 55, returnBill: pending.print },
      output: Buffer.from(JSON.stringify(captures)),
    };
  });
}

// Copied unchanged from gstReport.mjs: private XLSX reader (not exported by that module).
function readXlsx(buffer) {
  const eocd = buffer.lastIndexOf(Buffer.from([0x50, 0x4b, 0x05, 0x06]));
  assert(eocd >= 0, 'xlsx end of central directory');
  const count = buffer.readUInt16LE(eocd + 10);
  let offset = buffer.readUInt32LE(eocd + 16);
  const files = {};
  for (let n = 0; n < count; n++) {
    const method = buffer.readUInt16LE(offset + 10);
    const size = buffer.readUInt32LE(offset + 20);
    const nameLength = buffer.readUInt16LE(offset + 28);
    const extra = buffer.readUInt16LE(offset + 30);
    const comment = buffer.readUInt16LE(offset + 32);
    const local = buffer.readUInt32LE(offset + 42);
    const name = buffer.toString('utf8', offset + 46, offset + 46 + nameLength);
    const start = local + 30 + buffer.readUInt16LE(local + 26) + buffer.readUInt16LE(local + 28);
    const data = buffer.subarray(start, start + size);
    files[name] = (method === 8 ? inflateRawSync(data) : data).toString('utf8');
    offset += 46 + nameLength + extra + comment;
  }
  const decode = (s) =>
    s
      .replace(/&lt;/g, '<')
      .replace(/&gt;/g, '>')
      .replace(/&quot;/g, '"')
      .replace(/&apos;/g, "'")
      .replace(/&amp;/g, '&');
  const shared = [...(files['xl/sharedStrings.xml'] ?? '').matchAll(/<si>([\s\S]*?)<\/si>/g)].map(
    (m) => decode([...m[1].matchAll(/<t[^>]*>([\s\S]*?)<\/t>/g)].map((t) => t[1]).join('')),
  );
  const rels = Object.fromEntries(
    [...(files['xl/_rels/workbook.xml.rels'] ?? '').matchAll(/<Relationship [^>]*>/g)].map((m) => [
      /Id="([^"]+)"/.exec(m[0])[1],
      /Target="([^"]+)"/.exec(m[0])[1].replace(/^\/?(xl\/)?/, 'xl/'),
    ]),
  );
  const sheets = [];
  for (const m of (files['xl/workbook.xml'] ?? '').matchAll(/<sheet [^>]*\/>/g)) {
    const name = decode(/name="([^"]*)"/.exec(m[0])[1]);
    const xml = files[rels[/r:id="([^"]+)"/.exec(m[0])[1]]] ?? '';
    const rows = [...xml.matchAll(/<row[^>]*>([\s\S]*?)<\/row>/g)].map((row) => {
      const cells = [];
      for (const c of row[1].matchAll(/<c ([^>]*?)(?:\/>|>([\s\S]*?)<\/c>)/g)) {
        const column = /r="([A-Z]+)\d+"/.exec(c[1])[1];
        const index = [...column].reduce((sum, ch) => sum * 26 + ch.charCodeAt(0) - 64, 0) - 1;
        const v = /<v>([\s\S]*?)<\/v>/.exec(c[2] ?? '')?.[1];
        const inline = /<t[^>]*>([\s\S]*?)<\/t>/.exec(c[2] ?? '')?.[1];
        cells[index] = / t="s"/.test(c[1]) ? shared[Number(v)] : decode(inline ?? v ?? '');
      }
      return Array.from(cells, (cell) => cell ?? '');
    });
    sheets.push({ name, rows });
  }
  return sheets;
}

export const salesReport = {
  feature: 'sales-report',
  title: 'Reports → Sales Report (RP_ALL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/api/src/modules/reports/rpAll/engine.ts',
    'web/apps/api/src/modules/reports/rpAll/filters.ts',
    'web/apps/api/src/modules/reports/rpAll/salesLayouts.ts',
    'web/apps/api/src/modules/reports/rpAll/salesQuery.ts',
    'web/apps/api/src/modules/reports/rpAll/index.ts',
    'web/apps/api/src/routes/rpAllReport.ts',
    'web/apps/web/test/features/modules/salesReport.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    MsDataType: 'not ported (no session data type in the web); see inventory §6',
    masters:
      'cases set distinct AC_CITY/AC_AREA, product and group codes; vouchers via real screens',
  },
  cases: [
    C(
      'entry.defaults-and-thirteen-buttons',
      'T01',
      'read-only',
      'MDI_FORM.cs:8901-8910; RP_ALL.cs:6676-6698, 7195-7198 (From = system date), 4364-4378',
      'Reports nav opens the dedicated screen; From and To default to today; lc Code shows the session location and is locked unless it is 00; Employ and Select Book are visible, State is not (Lite); the thirteen Lite buttons in desktop order; refused by the API for a user without the Sales Report right',
    ),
    C(
      'filters.one-at-a-time',
      'T02',
      'read-only',
      'RP_ALL.cs:7620-7665, 7771-7809, 7875-7925, 9147-9185, 11947-11997, 11753-11795',
      'Each selector alone (location, book, Select Book, party, city, area, employee, product, group, item type) yields exactly the voucher ids its button formula selects; a selector the button does not use is listed as ignored',
    ),
    C(
      'filters.combined-and-year-boundary',
      'T02',
      'read-only',
      'RP_ALL.cs:7618 (VCH_DATE >= From and <= To, inclusive)',
      'Combinations narrow as an AND; a voucher on From and on To is included, the day before and after are not; two sale books split exactly',
    ),
    C(
      'formula.register-report-totals',
      'T03',
      'read-only',
      'SaleReport.xml Section10 running totals; SalesSumm.xml Section7/8 (DATE TOTAL, GRAND TOTAL)',
      'Net Amt, Disc, Tax, Bill Tot, Pcs, Gross/Net Wt, LbrAmt and every register column equal the sums of the created vouchers, each bill counted once even with two lines (inventory §6 deliberate difference)',
    ),
    C(
      'formula.item-group-employee-order',
      'T03',
      'read-only',
      'SalesItem.xml, SalesGroupWise.xml (@ItmTotAmt = NET_AMT + IT_TAX_AMT - IT_DISC_AMT), EmpSaleReport.xml (@VchAmt = TOT_AMT - KASAR_AMT), SalesWithOrder.xml',
      'Item-type and product/group header subtotals, the employee "Total :" band and the order-line grand total equal hand sums of the created lines',
    ),
    C(
      'lookup.party-book-product-group',
      'T04',
      'read-only',
      'RP_ALL.cs:7288-7331 (book help), 7336-7430 (party help), 7431-7509 (product help), 9208-9295 (group help)',
      'Enter on an unknown code opens the help, picking fills code and name, Esc cancels, a stale lookup response never overwrites a newer one',
    ),
    C(
      'grouping.templates-and-zoom',
      'T05',
      'read-only',
      'SaleReport.xml groups CO_BOOK/@VchGroup/@SrNo; SalesSumm VCH_DATE; SalesItem IT_TYPE/PR_CODE; EmpSaleReport EMP_CODE',
      'Group bands and nesting match each template; a voucher row zooms to the voucher screen, which renders the loaded sale (number and party name), and back',
    ),
    C(
      'invalid.dates-and-empty',
      'T06',
      'refusal',
      'RP_ALL.cs:7510-7541 (SetDate/RongDate); no From/To comparison in any handler',
      'An impossible date is refused before the run; From after To prints an empty report with zero totals and no crash; an empty period prints an empty report',
      { requiredEvidence: ['browser', 'expected', 'database'] },
    ),
    C(
      'source.create-edit-delete-return',
      'T07',
      'read-only',
      'TR_SALE_RTN.cs:12623 (NET_AMT = sale part), 12707 (RTN_NET_AMT = return part)',
      'A sale created on the Sales Invoice screen appears; editing it re-totals; deleting it removes it; a Sales Return appears only under the return prompt (blocked on G246 until the web return writes RTN_NET_AMT)',
    ),
    ...['T08', 'T09', 'T10'].map(writesNothing),
    C(
      'scope.tenant-company-location-year-book-rights',
      'T11',
      'refusal',
      'RP_ALL.cs:7618 (CO_CODE, CO_YEAR), 6660-6671 (location lock); 00b addendum T11',
      'Sentinel vouchers in another tenant, company, location, year and book never appear in the grid, totals or exports; no List right → 403 from the API; no Print right → export refused',
      { requiredEvidence: ['browser', 'expected', 'database'] },
    ),
    ...['T12', 'T13', 'T14'].map(writesNothing),
    C(
      'history.live-master-and-snapshot',
      'T15',
      'read-only',
      'SaleReport prints SL_DATA.AC_NAME (snapshot); SalesSumm prints AC_MAST.AC_NAME (live)',
      'After renaming the party, Sales Report keeps the bill-time name and Sales Reg shows the new one; an older year is never mixed in',
    ),
    C(
      'output.grid-pdf-xlsx-csv-match',
      'T16',
      'output',
      'SaleReport.xml, SalesSumm.xml, SalesItem.xml, SalesGroupWise.xml, EmpSaleReport.xml, SalesWithOrder.xml',
      'Grid, CSV, Excel and print show the same rows and totals in desktop column order and captions over more rows than one page; SalesRtnA4Print is missing from the repository (blocked with that reason)',
    ),
    C(
      'keyboard.selector-run-flow',
      'T17',
      'read-only',
      'RP_ALL.cs:7257-7265 (Esc closes), 7510-7568 (Enter walks the selectors), tab order :4778-6549',
      'The whole run is done with the keyboard: Enter walks From → To → lc → Book → Pr → Gr → Party → City → Area → Item Type, Alt-key buttons run, Esc closes',
    ),
    C(
      'journey.create-edit-delete-return-reconcile',
      'T18',
      'read-only',
      '00b-REPORT-ADDENDUM.md T18; 01-sales-report.md case emphasis',
      'Two item groups on one bill, local and inter-state GST, old-gold exchange, hallmark, order advance, then a Sales Return, all through their screens; the report reconciles to the hand totals and to the ledger, then follows an edit, a delete and the return',
    ),
  ],
};
