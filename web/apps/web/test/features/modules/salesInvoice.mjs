import assert from 'node:assert/strict';
import {
  FIXTURE_MANIFEST,
  ITEMS,
  PARTIES,
  USERS,
  sentinelSnapshot,
} from '../fixtures/catalogue.mjs';

/**
 * Feature: Sales → Sales Invoice (desktop TR_SALE, opened by MDI_FORM.cs:7918-7919 CurBookHelp("SALES")).
 *
 * Expected values are computed here from the desktop rules, not read from the web code:
 * - TR_SALE.cs CommPassTotal (10716-10936): with CO_SET.SL_AMT_TYPE='N' (what seedCompany provisions) a line is
 *   priced on net weight: ITM_AMT = netWt × rate; labour per gram LBR_AMT = netWt × making; fine =
 *   round(netWt × touch / 100, 3). Each component is rounded to TOT_AMT_ROF decimals (TR_SALE.cs:19192). A
 *   web-provisioned company leaves TOT_AMT_ROF and TAX_ROF blank, which the web resolves to 2 decimals
 *   (packages/core/src/roundingPolicy.ts; the desktop itself always stores the flag, MS_OPNCOMP.cs:991).
 * - GST on (Σ line net − discount); intra-state splits into CGST = SGST = tax / 2, inter-state is IGST.
 * - Delete writes DELETE_DATA (TR_SALE.cs:16316-16322) and reverses stock and ledger.
 * Every amount below is a hand calculation; the comment beside it shows the arithmetic.
 */

const BOOK = 'SL';
/** Read at use time: the runner sets the per-run password after this module is imported. */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

// --- independent expectations ---------------------------------------------------------------------------------
// Amounts at 2 decimals (blank TOT_AMT_ROF / TAX_ROF on a web-provisioned company).
// Line A: GLD22, 10.000 g, touch 91.6, rate 6123.45, making 237.5 /g
//   metal  = 10 × 6123.45             = 61,234.50
//   labour = 10 × 237.5               =  2,375.00
//   net    = 63,609.50;  fine = 9.160
// Line B: SLV92, 50.000 g, touch 92.5, rate 85.5, no making
//   metal  = 50 × 85.5                =  4,275.00;  fine = 46.250
const LINE_A = {
  item: ITEMS.gold.code,
  pcs: '1',
  gross: '10.25',
  net: '10',
  touch: '91.6',
  rate: '6123.45',
  making: '237.5',
};
const LINE_B = {
  item: ITEMS.silver.code,
  pcs: '2',
  gross: '50.4',
  net: '50',
  touch: '92.5',
  rate: '85.5',
};
const EXPECT_A = { metal: 61234.5, labour: 2375, net: 63609.5, fine: 9.16 };
const EXPECT_B = { metal: 4275, labour: 0, net: 4275, fine: 46.25 };

/** Single line A, 3% GST intra-state: tax = 63,609.50 × 3% = 1,908.285 → 1,908.29 (half-up).
 *  TR_SALE.cs stores SGST_TAX = CGST_TAX = Val(tax) / 2.0 WITHOUT rounding: 954.145 each.
 *  total = 63,609.50 + 1,908.29 = 65,517.79. */
const ONE_LINE = {
  net: 63609.5,
  taxable: 63609.5,
  tax: 1908.29,
  cgst: 954.145,
  sgst: 954.145,
  igst: 0,
  total: 65517.79,
};
/** Lines A + B: net 67,884.50; tax 3% = 2,036.535 → 2,036.54. */
const TWO_LINES = { net: 67884.5, taxable: 67884.5, tax: 2036.54 };

// --- screen helpers -----------------------------------------------------------------------------------------
const cell = (page, row, column) =>
  page.locator(`[data-grid-row="${row}"][data-grid-column="${column}"] input`).first();
const field = (page, label) =>
  page
    .locator('.field')
    .filter({ has: page.locator('label', { hasText: new RegExp(`^${label}$`) }) })
    .locator('input,select')
    .first();

async function openSales(page) {
  await page.goto('/txn/sales');
  await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned SALES book is selected');
  return book;
}

async function pickParty(page, code) {
  const party = page.getByPlaceholder('search accounts… (F1)').first();
  await party.fill(code);
  await party.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await party.press('Enter');
}

async function fillLine(page, row, line) {
  // Grid columns (sales/page.tsx gridCell): 0 item, 2 pcs, 3 gross, 4 net, 5 touch, 6 rate, 7 making/g.
  await cell(page, row, 0).fill(line.item);
  await cell(page, row, 0).press('Escape');
  const values = {
    2: line.pcs,
    3: line.gross,
    4: line.net,
    5: line.touch,
    6: line.rate,
    7: line.making,
  };
  for (const [column, value] of Object.entries(values))
    if (value !== undefined) await cell(page, row, Number(column)).fill(value);
}

/** The Totals panel values as numbers, keyed by their caption. */
async function screenTotals(page) {
  const panel = page.locator('.panel', {
    has: page.getByRole('heading', { name: 'Totals', exact: true }),
  });
  const text = await panel.innerText();
  const read = (caption) => {
    const match = text.match(new RegExp(`${caption}\\s*\\n?\\s*([-0-9,\\.]+)`));
    return match ? Number(match[1].replace(/,/g, '')) : null;
  };
  return { net: read('Net'), taxable: read('Taxable'), tax: read('Tax 3%'), total: read('Total') };
}

async function save(page, label = 'Save Invoice') {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/sales(\/|$)/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    page.getByRole('button', { name: label, exact: true }).click(),
  ]);
  return response;
}

async function loadVoucher(page, vchNo) {
  await page.getByLabel('Voucher No', { exact: true }).fill(vchNo);
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page
    .getByTestId('sales-loaded')
    .filter({ hasText: `Loaded #${vchNo}` })
    .waitFor();
}

// --- database observers ---------------------------------------------------------------------------------------
const header = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "VCH_NO","AC_CODE","NET_AMT"::float net,"DISC_AMT"::float disc,"TAX_AMT"::float tax,"CGST_TAX"::float cgst,
            "SGST_TAX"::float sgst,"IGST_TAX"::float igst,"TOT_AMT"::float tot,"CASH_AMT"::float cash,"CHQ_AMT"::float chq,
            "BANK_AC","BILL_NO","VCH_TIME"
       FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
    vchNo,
  );
const lines = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"IT_CODE" it,"ITM_NWT"::float nwt,"ITM_FINE"::float fine,"ITM_AMT"::float amt,
            "LBR_AMT"::float lbr,"NET_AMT"::float net,"ITM_RATE"::float rate
       FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const ledger = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    vchNo,
  );
const stock = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "IT_CODE" it,"ITM_SIGN" sign,"ITM_NWT"::float nwt FROM "MAIN_STOCK"
      WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "IT_CODE"`,
    vchNo,
  );
const counts = async (ctx) =>
  (
    await ctx.rows(
      `SELECT (SELECT count(*) FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int sl,
              (SELECT count(*) FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int detl,
              (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int ac,
              (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int stk`,
    )
  )[0];
const balanced = (rows) => {
  const dr = rows.reduce((s, r) => s + r.dr, 0);
  const cr = rows.reduce((s, r) => s + r.cr, 0);
  return Math.abs(dr - cr) < 0.005 && dr > 0;
};

/** Create a one-line sale through the screen and return its voucher number. */
async function createOneLine(ctx, page, { party = PARTIES.local.code, cash } = {}) {
  await openSales(page);
  await pickParty(page, party);
  await fillLine(page, 0, LINE_A);
  if (cash) await field(page, 'Cash ₹').fill(cash);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  const body = await response.json();
  await page.getByText(`Saved — Voucher #${body.vchNo}`, { exact: false }).waitFor();
  return String(body.vchNo).padStart(5, '0');
}

async function registerRow(page, vchNo) {
  await page.goto('/reports/sales-register');
  await page.getByRole('button', { name: 'Run', exact: true }).click();
  const row = page.locator('table.grid tbody tr').filter({ hasText: vchNo }).first();
  await row.waitFor();
  return row.innerText();
}

// --- the matrix ----------------------------------------------------------------------------------------------
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `sales-invoice.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});

export const salesInvoice = {
  feature: 'sales-invoice',
  title: 'Sales → Sales Invoice (TR_SALE)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/sales/page.tsx',
    'web/apps/api/src/modules/sales/sales.ts',
    'web/apps/api/src/routes/txn.ts',
    'web/apps/web/test/features/modules/salesInvoice.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    SL_AMT_TYPE: 'N (seedCompany)',
    NEGATIVE_STK_SALE: 'blank → Y',
    TOT_AMT_ROF: 'blank → default',
  },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:7918-7919 CurBookHelp("SALES"): only SALES books; the only one is preselected',
      async (ctx) => {
        const { page } = await ctx.session();
        const book = await openSales(page);
        const offered = (await book.locator('option').allTextContents()).filter((t) =>
          t.includes('—'),
        );
        assert.deepEqual(offered, ['SL — Sales'], 'only SALES-family books are offered');
        assert.equal(await field(page, 'Tax %').inputValue(), '3', 'default tax rate');
        const party = await page.getByPlaceholder('search accounts… (F1)').first().inputValue();
        assert.equal(party, 'WALKIN', 'walk-in party default (G124)');
        await ctx.shot(page, 'defaults');
        return {
          observation: `book list ${JSON.stringify(offered)}, tax 3, party WALKIN`,
          expected: { offered: ['SL — Sales'], tax: '3', party: 'WALKIN' },
        };
      },
    ),

    C(
      'lookup.code-enter-at-once',
      'T17',
      'read-only',
      'TR_SALE.cs:17340 tAcCode_KeyDown: Enter looks the typed code up exactly; a list fetched for older text is never picked (G185)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openSales(page);
        const party = page.getByPlaceholder('search accounts… (F1)').first();
        await party.click();
        await party.fill('');
        // Let the list for the empty box arrive first: that stale list is what Enter used to pick from.
        await page.waitForTimeout(400);
        await party.pressSequentially(PARTIES.local.code);
        await party.press('Enter');
        const name = field(page, 'Customer Name');
        for (let i = 0; i < 40 && (await name.inputValue()) === ''; i++)
          await page.waitForTimeout(100);
        const picked = await party.inputValue();
        const shownName = await name.inputValue();
        assert.equal(
          picked,
          PARTIES.local.code,
          `Enter at once picked ${picked}, not the typed code`,
        );
        assert.equal(shownName, PARTIES.local.name, 'the typed party is filled in');
        return {
          observation: `typed ${PARTIES.local.code} + Enter at once: party ${picked}, name ${shownName}`,
          expected: { party: PARTIES.local.code, name: PARTIES.local.name },
        };
      },
    ),

    C(
      'formula.single-line',
      'T03',
      'read-only',
      'TR_SALE.cs CommPassTotal 10716-10936 (net basis when SL_AMT_TYPE=N)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openSales(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_A);
        const row = page.locator('tr').filter({ has: page.locator('[data-grid-row="0"]') });
        await row.filter({ hasText: '63,609.5' }).waitFor();
        await row.filter({ hasText: '9.16' }).waitFor();
        const totals = await screenTotals(page);
        await ctx.shot(page, 'single-line-preview');
        assert.equal(totals.net, ONE_LINE.net);
        assert.equal(totals.tax, ONE_LINE.tax);
        return {
          observation: `preview line net 63,609.5 fine 9.16; totals ${JSON.stringify(totals)}`,
          expected: { line: EXPECT_A, totals: ONE_LINE },
        };
      },
    ),

    C(
      'create.single-line-cash',
      'T07',
      'mutation',
      'TR_SALE save: SL_DATA + SL_DETL + MAIN_STOCK(-) + AC_DATA balanced',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await sentinelSnapshot(ctx.owner);
        const vchNo = await createOneLine(ctx, page, { cash: '65517.79' });
        await ctx.shot(page, 'saved');
        const [h] = await header(ctx, vchNo);
        const l = await lines(ctx, vchNo);
        const g = await ledger(ctx, vchNo);
        const s = await stock(ctx, vchNo);
        assert.equal(h.net, ONE_LINE.net);
        assert.equal(h.tax, ONE_LINE.tax);
        assert.equal(h.cgst, ONE_LINE.cgst);
        assert.equal(h.sgst, ONE_LINE.sgst);
        assert.equal(h.cash, 65517.79);
        assert.deepEqual(
          l.map((x) => [x.it, x.nwt, x.fine, x.amt, x.lbr, x.net]),
          [[ITEMS.gold.code, 10, EXPECT_A.fine, EXPECT_A.metal, EXPECT_A.labour, EXPECT_A.net]],
        );
        assert(balanced(g), `ledger must balance: ${JSON.stringify(g)}`);
        assert.deepEqual(s, [{ it: ITEMS.gold.code, sign: '-', nwt: 10 }]);
        assert.deepEqual(await sentinelSnapshot(ctx.owner), before, 'other tenant untouched');
        const reg = await registerRow(page, vchNo);
        assert.match(reg, /63609\.5|63,609\.5/);
        return {
          observation: `voucher ${vchNo}: SL_DATA net ${h.net} tax ${h.tax} (CGST ${h.cgst}/SGST ${h.sgst}) total ${h.tot}; 1 SL_DETL; stock -10; ${g.length} balanced ledger legs; register row present`,
          expected: { line: EXPECT_A, totals: ONE_LINE, stock: -10 },
          database: { header: h, lines: l, ledger: g, stock: s },
          downstream: { salesRegisterRow: reg },
        };
      },
    ),

    C(
      'create.two-lines-dissimilar',
      'T05',
      'mutation',
      'TR_SALE grid: dissimilar gold/silver lines keep their own values; Σ lines = header',
      async (ctx) => {
        const { page } = await ctx.session();
        await openSales(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_A);
        await page.getByRole('button', { name: '+ Add line', exact: true }).click();
        await fillLine(page, 1, LINE_B);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        const l = await lines(ctx, vchNo);
        assert.deepEqual(
          l.map((x) => [x.sr, x.it, x.amt, x.fine]),
          [
            [1, ITEMS.gold.code, EXPECT_A.metal, EXPECT_A.fine],
            [2, ITEMS.silver.code, EXPECT_B.metal, EXPECT_B.fine],
          ],
        );
        assert.equal(h.net, TWO_LINES.net);
        assert.equal(h.tax, TWO_LINES.tax);
        const g = await ledger(ctx, vchNo);
        assert(balanced(g));
        // G169: each group's income account is credited with its own line (Ac_Ledr.cs:90 line path).
        assert.deepEqual(
          g
            .filter((x) => x.ac === 'SALES' || x.ac === 'SLVSALE')
            .map((x) => [x.ac, x.cr])
            .sort(),
          [
            ['SALES', EXPECT_A.net],
            ['SLVSALE', EXPECT_B.net],
          ],
        );
        const s = await stock(ctx, vchNo);
        assert.deepEqual(
          s.map((x) => [x.it, x.nwt]),
          [
            [ITEMS.gold.code, 10],
            [ITEMS.silver.code, 50],
          ],
        );
        return {
          observation: `voucher ${vchNo}: lines ${JSON.stringify(l.map((x) => [x.it, x.amt]))}, header net ${h.net} tax ${h.tax}`,
          expected: { a: EXPECT_A, b: EXPECT_B, totals: TWO_LINES },
          database: { header: h, lines: l, ledger: g, stock: s },
          downstream: { stockRows: s.length },
        };
      },
      {
        expected: {
          a: EXPECT_A,
          b: EXPECT_B,
          totals: TWO_LINES,
          ledger:
            'one revenue leg per detail line on its group SALE_AC, keyed VCH_NO+STR(SR_NO)+03 (Ac_Ledr.cs:90 line path, measured revenue code 03)',
        },
        observe: async (ctx) => ({
          countsAfterFailedSave: await counts(ctx),
          salesBookLedgerKeys: await ctx.rows(
            `SELECT "LEDR_KEY","AC_CODE","CR_AMT"::float cr FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "LEDR_KEY"`,
          ),
        }),
      },
    ),

    C(
      'create.interstate-igst',
      'T02',
      'mutation',
      'Ac_Tax.cs: AC_GST_TYPE=I posts IGST (SR_NO 3) instead of CGST/SGST',
      async (ctx) => {
        const { page } = await ctx.session();
        await openSales(page);
        await pickParty(page, PARTIES.interState.code);
        await field(page, 'Inter-state').selectOption('y');
        await fillLine(page, 0, LINE_A);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        assert.equal(h.igst, ONE_LINE.tax);
        assert.equal(h.cgst + h.sgst, 0);
        const tax = await ctx.rows(
          `SELECT count(*)::int n FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        return {
          observation: `voucher ${vchNo}: IGST ${h.igst}, CGST+SGST 0; TAX_DATA rows ${tax[0].n}`,
          expected: { igst: ONE_LINE.tax },
          database: { header: h, taxRows: tax[0].n },
          downstream: { taxRows: tax[0].n },
        };
      },
    ),

    C(
      'create.discount',
      'T02',
      'mutation',
      'TR_SALE totals: GST on (net − discount)',
      async (ctx) => {
        // 63,609.50 − 1,000 = 62,609.50 taxable; tax 3% = 1,878.285 → 1,878.29
        const { page } = await ctx.session();
        await openSales(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_A);
        await field(page, 'Discount ₹').fill('1000');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        assert.equal(h.disc, 1000);
        assert.equal(h.tax, 1878.29);
        const g = await ledger(ctx, vchNo);
        assert(balanced(g));
        return {
          observation: `voucher ${vchNo}: discount ${h.disc}, tax ${h.tax}`,
          expected: { taxable: 62609.5, tax: 1878.29 },
          database: { header: h, ledger: g },
          downstream: { balanced: true },
        };
      },
    ),

    C(
      'reopen.round-trip',
      'T08',
      'read-only',
      'TR_SALE reopen: every saved field returns to the screen',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOneLine(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(page, vchNo);
        assert.equal(await cell(page, 0, 0).inputValue(), ITEMS.gold.code);
        assert.equal(await cell(page, 0, 4).inputValue(), '10');
        assert.equal(await cell(page, 0, 5).inputValue(), '91.6');
        assert.equal(await cell(page, 0, 6).inputValue(), '6123.45');
        assert.equal(await cell(page, 0, 7).inputValue(), '237.5');
        assert.equal(
          await page.getByPlaceholder('search accounts… (F1)').first().inputValue(),
          PARTIES.local.code,
        );
        await ctx.shot(page, 'reopened');
        return {
          observation: `voucher ${vchNo} reopened with item, net, touch, rate, making and party intact`,
          expected: LINE_A,
        };
      },
    ),

    C(
      'edit.unchanged-save-no-op',
      'T08',
      'mutation',
      'Unchanged reopen → save must not change any business value',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOneLine(ctx, page);
        const before = {
          h: await header(ctx, vchNo),
          l: await lines(ctx, vchNo),
          g: await ledger(ctx, vchNo),
        };
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(page, vchNo);
        const response = await save(page, 'Update Invoice');
        assert.equal(response.status(), 200, await response.text());
        const after = {
          h: await header(ctx, vchNo),
          l: await lines(ctx, vchNo),
          g: await ledger(ctx, vchNo),
        };
        const strip = (h) => h.map(({ VCH_TIME, ...rest }) => rest);
        assert.deepEqual(strip(after.h), strip(before.h));
        assert.deepEqual(after.l, before.l);
        assert.deepEqual(after.g, before.g);
        return {
          observation: `voucher ${vchNo}: header/lines/ledger identical after unchanged save`,
          expected: 'no change',
          database: { before, after },
          downstream: { identical: true },
        };
      },
    ),

    C(
      'edit.change-rate',
      'T09',
      'mutation',
      'TR_SALE edit: changed rate re-prices the line; ledger rebuilt and balanced',
      async (ctx) => {
        // new rate 6500: metal = 65,000; net = 67,375; tax = 2,021.25
        const { page } = await ctx.session();
        const vchNo = await createOneLine(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(page, vchNo);
        await cell(page, 0, 6).fill('6500');
        const response = await save(page, 'Update Invoice');
        assert.equal(response.status(), 200, await response.text());
        const [h] = await header(ctx, vchNo);
        const [l] = await lines(ctx, vchNo);
        assert.equal(l.amt, 65000);
        assert.equal(h.net, 67375);
        assert.equal(h.tax, 2021.25);
        const g = await ledger(ctx, vchNo);
        assert(balanced(g));
        const reg = await registerRow(page, vchNo);
        assert.match(reg, /67375|67,375/);
        return {
          observation: `voucher ${vchNo}: rate 6500 → line 65,000, header net 67,375, tax 2,021.25; register updated`,
          expected: { metal: 65000, net: 67375, tax: 2021.25 },
          database: { header: h, line: l, ledger: g },
          downstream: { salesRegisterRow: reg },
        };
      },
    ),

    C(
      'delete.reverses',
      'T10',
      'mutation',
      'TR_SALE.cs:16316-16322: delete writes DELETE_DATA; stock and ledger removed',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOneLine(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(page, vchNo);
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'DELETE' && /\/api\/sales\//.test(r.url()),
          ),
          page.getByRole('button', { name: 'Delete', exact: true }).click(),
        ]);
        assert.equal(response.status(), 200, await response.text());
        assert.deepEqual(await header(ctx, vchNo), []);
        assert.deepEqual(await lines(ctx, vchNo), []);
        assert.deepEqual(await ledger(ctx, vchNo), []);
        assert.deepEqual(await stock(ctx, vchNo), []);
        const audit = await ctx.rows(
          `SELECT count(*)::int n FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert(audit[0].n >= 1, 'DELETE_DATA audit row');
        return {
          observation: `voucher ${vchNo} deleted; header/lines/ledger/stock empty; DELETE_DATA rows ${audit[0].n}`,
          expected: 'all rows removed + DELETE_DATA',
          database: { deleteData: audit[0].n },
          downstream: { remaining: 0 },
        };
      },
    ),

    C(
      'print.pdf',
      'T16',
      'output',
      'TR_SALE print (SaleBillA4Gst.rpt): printable tax invoice for the saved voucher',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOneLine(ctx, page);
        // The button opens the document in a new tab. Headless Chromium hands a PDF to its viewer, so the tab's
        // URL is not reliable; the request the tab made is. Listen on the browser context, which sees requests
        // from every page it owns, then fetch exactly that URL in the same authenticated context.
        const documentRequest = page
          .context()
          .waitForEvent('request', (r) => /\/api\/sales\/invoice\?/.test(r.url()), {
            timeout: 15_000,
          });
        const [popup] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByRole('button', { name: 'View Invoice PDF', exact: true }).click(),
        ]);
        const documentUrl = (await documentRequest).url();
        const response = await page.request.get(documentUrl);
        assert.equal(response.status(), 200, await response.text());
        const bytes = await response.body();
        const type = response.headers()['content-type'] ?? '';
        assert(type.includes('pdf') || type.includes('html'), `document type ${type}`);
        if (type.includes('pdf')) assert.equal(bytes.subarray(0, 4).toString(), '%PDF');
        await popup.close();
        return {
          observation: `voucher ${vchNo}: ${type} document, ${bytes.length} bytes`,
          expected: 'a printable invoice',
          output: bytes,
        };
      },
    ),

    C(
      'print.hsn-agrees-with-summary',
      'T16',
      'output',
      'SalesBillA4Gst.rpt prints SL_DATA.CGST_TAX/SGST_TAX (line halves unused); G181: the HSN table must show the same heads as the summary and total the bill tax',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOneLine(ctx, page); // 1,908.29 tax: two halves of 954.145
        await loadVoucher(page, vchNo);
        const documentRequest = page
          .context()
          .waitForEvent('request', (r) => /\/api\/sales\/invoice\?.*format=html/.test(r.url()), {
            timeout: 15_000,
          });
        const [popup] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByRole('button', { name: 'Print', exact: true }).click(),
        ]);
        const response = await page.request.get((await documentRequest).url());
        assert.equal(response.status(), 200, await response.text());
        const html = await response.text();
        await popup.close();
        const amount = (text) => Number(String(text).replace(/,/g, ''));
        const table = html.slice(html.indexOf('class="hsn"'), html.indexOf('class="tot"'));
        const rows = [
          ...table.matchAll(
            /<tr><td>[^<]*<\/td><td>[^<]*<\/td><td>([^<]*)<\/td><td>([^<]*)<\/td><td>([^<]*)<\/td><\/tr>/g,
          ),
        ];
        const paise = (values) => Math.round(values.reduce((sum, v) => sum + v, 0) * 100);
        const printed = {
          hsnCgst: paise(rows.map((r) => amount(r[1]))) / 100,
          hsnSgst: paise(rows.map((r) => amount(r[2]))) / 100,
          hsnTax: paise(rows.map((r) => amount(r[3]))) / 100,
          summaryCgst: amount(/<td>CGST<\/td><td class="r">([^<]*)<\/td>/.exec(html)?.[1]),
          summarySgst: amount(/<td>SGST<\/td><td class="r">([^<]*)<\/td>/.exec(html)?.[1]),
        };
        const [bill] = await ctx.rows(
          `SELECT "TAX_AMT"::float tax,"CGST_TAX"::float cgst,"SGST_TAX"::float sgst FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.equal(printed.hsnCgst, printed.summaryCgst, 'HSN CGST column = summary CGST');
        assert.equal(printed.hsnSgst, printed.summarySgst, 'HSN SGST column = summary SGST');
        assert.equal(printed.hsnTax, bill.tax, 'HSN Tax column = bill tax');
        return {
          observation: `HSN CGST ${printed.hsnCgst} / SGST ${printed.hsnSgst} / Tax ${printed.hsnTax}; summary CGST ${printed.summaryCgst} / SGST ${printed.summarySgst}; bill tax ${bill.tax}`,
          expected:
            'the HSN columns equal the summary heads and the Tax column equals the bill tax',
          output: Buffer.from(html),
        };
      },
    ),

    C(
      'refusal.cheque-without-bank',
      'T06',
      'refusal',
      'desktopMessages CHEQUE_WITHOUT_BANK: "Please Select Bank Account … Chq Rec Amt <> 0"',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openSales(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_A);
        await field(page, 'Cheque ₹').fill('5000');
        const response = await save(page);
        assert.equal(response.status(), 400);
        await page.locator('.msg.err').filter({ hasText: 'Please Select Bank Account' }).waitFor();
        assert.deepEqual(await counts(ctx), before, 'nothing written');
        return {
          observation: 'refused with the desktop cheque-without-bank message; no rows written',
          expected: '400 + message + no write',
          database: { before, after: before },
        };
      },
    ),

    C(
      'refusal.no-lines',
      'T06',
      'refusal',
      'TR_SALE: a bill needs at least one item line',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openSales(page);
        await pickParty(page, PARTIES.local.code);
        const response = await save(page);
        assert.equal(response.status(), 400);
        await page.locator('.msg.err').waitFor();
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `refused: ${await page.locator('.msg.err').innerText()}`,
          expected: '400 + no write',
          database: { before, after: before },
        };
      },
    ),

    {
      ...C(
        'refusal.negative-weight',
        'T06',
        'refusal',
        'TR_SALE item grid: no numeric validation found; TR_SALE_KeyPress (14870-14883) only uppercases and drops NUL/apostrophe',
        async () => ({}),
      ),
      blocked:
        'Expected behaviour undecided: no desktop source refuses a negative weight, and the web saves it. Needs an original-Windows run to decide refuse vs accept.',
    },

    C(
      'refusal.unknown-item',
      'T04',
      'refusal',
      'Lookup: a typed code that is not in ITEM_MAST must not post',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openSales(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, { ...LINE_A, item: 'ZZZZZ' });
        const response = await save(page);
        assert.notEqual(response.status(), 201);
        assert(response.status() < 500, `must be a client error, got ${response.status()}`);
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `unknown item answered ${response.status()}; no rows written`,
          expected: 'refusal + no write',
          database: { before, after: before },
        };
      },
    ),

    C(
      'rights.clerk-cannot-delete',
      'T11',
      'refusal',
      'USER_SET FRM_DELETE=N: the server refuses delete for that user',
      async (ctx) => {
        const admin = await ctx.session();
        const vchNo = await createOneLine(ctx, admin.page);
        const clerk = await ctx.session(as(USERS.clerk.user));
        await openSales(clerk.page);
        await loadVoucher(clerk.page, vchNo);
        const deleteButton = clerk.page.getByRole('button', { name: 'Delete', exact: true });
        let status = null;
        if (await deleteButton.isEnabled()) {
          const [response] = await Promise.all([
            clerk.page.waitForResponse((r) => r.request().method() === 'DELETE'),
            deleteButton.click(),
          ]);
          status = response.status();
          assert.equal(status, 403);
        }
        const [h] = await header(ctx, vchNo);
        assert(h, 'voucher still exists');
        return {
          observation: `clerk delete ${status === null ? 'not offered' : `answered ${status}`}; voucher ${vchNo} intact`,
          expected: '403 or no delete control; voucher intact',
          database: { header: h },
        };
      },
    ),

    C(
      'concurrency.stale-second-save',
      'T12',
      'refusal',
      'Two operators on one voucher: the stale second save must not silently overwrite the first',
      async (ctx) => {
        // Two independent server sessions (separate logins), as two operators at two counters.
        const first = await ctx.session(as(USERS.admin.user, 'operator-1'));
        const vchNo = await createOneLine(ctx, first.page);
        const second = await ctx.session(as(USERS.admin.user, 'operator-2'));
        await first.page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(first.page, vchNo);
        await openSales(second.page);
        await loadVoucher(second.page, vchNo);
        await cell(first.page, 0, 6).fill('6500');
        const one = await save(first.page, 'Update Invoice');
        assert.equal(one.status(), 200, await one.text());
        await cell(second.page, 0, 6).fill('7000');
        const two = await save(second.page, 'Update Invoice');
        const [l] = await lines(ctx, vchNo);
        assert.equal(
          two.status(),
          409,
          `stale save answered ${two.status()}; line amount now ${l.amt}`,
        );
        assert.equal(l.amt, 65000, 'first save survives');
        return {
          observation: `second save ${two.status()}; line amount ${l.amt}`,
          expected: '409 conflict; first save (65,000) survives',
          database: { line: l },
        };
      },
      {
        expected: { secondSave: 409, survivingLineAmount: 65000 },
        observe: async (ctx) => ({
          salesLines: await ctx.rows(
            `SELECT "VCH_NO","SR_NO"::int sr,"ITM_RATE"::float rate,"ITM_AMT"::float amt FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO","SR_NO"`,
          ),
        }),
      },
    ),

    C(
      'retry.double-click-single-voucher',
      'T13',
      'mutation',
      'Duplicate submission must not create two vouchers',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openSales(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_A);
        const button = page.getByRole('button', { name: 'Save Invoice', exact: true });
        await button.dblclick();
        await page.getByText('Saved — Voucher #', { exact: false }).waitFor();
        await page.waitForTimeout(1500);
        const after = await counts(ctx);
        assert.equal(after.sl - before.sl, 1, 'exactly one voucher');
        return {
          observation: `double-click created ${after.sl - before.sl} voucher(s)`,
          expected: 1,
          database: { before, after },
          downstream: { created: after.sl - before.sl },
        };
      },
    ),

    C(
      'entry.no-request-storm',
      'T01',
      'read-only',
      'G182: opening the screen draws no route prefetches, and typing a party code asks for its balance once',
      async (ctx) => {
        const { page } = await ctx.session();
        const seen = [];
        page.on('request', (r) => seen.push(r.url()));
        await openSales(page);
        await page.waitForTimeout(1500);
        const prefetches = seen.filter((u) => u.includes('_rsc=')).length;
        const party = page.getByPlaceholder('search accounts… (F1)').first();
        await party.fill('');
        await page.waitForTimeout(500);
        const typingFrom = seen.length;
        await party.pressSequentially(PARTIES.local.code, { delay: 60 });
        await page.waitForTimeout(1200);
        const balances = seen
          .slice(typingFrom)
          .filter((u) => /\/api\/party\/[^/]*\/balance/.test(u));
        assert.ok(prefetches <= 2, `${prefetches} route prefetches on opening the screen`);
        assert.equal(balances.length, 1, `balance requests while typing: ${balances.join(', ')}`);
        assert.ok(balances[0].includes(`/party/${PARTIES.local.code}/balance`), balances[0]);
        return {
          observation: `${prefetches} route prefetches on opening; ${balances.length} balance request while typing ${PARTIES.local.code}`,
          expected: 'at most 2 prefetches; 1 balance request, for the typed code',
        };
      },
    ),

    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'TR_SALE.cs:4896 BtnSave.Text = "&Save": the desktop saves with the Alt+S mnemonic (no Ctrl+S binding exists)',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openSales(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_A);
        await cell(page, 0, 6).press('Alt+s');
        await page.getByText('Saved — Voucher #', { exact: false }).waitFor({ timeout: 5000 });
        const after = await counts(ctx);
        assert.equal(after.sl - before.sl, 1);
        return {
          observation: 'Alt+S saved the voucher',
          expected: 'save via the &Save mnemonic',
          database: { before, after },
          downstream: { created: 1 },
        };
      },
      {
        expected: { keyboard: 'Alt+S', vouchersCreated: 1 },
        observe: async (ctx) => ({ countsAfterAltS: await counts(ctx) }),
      },
    ),

    C(
      'output.register-csv',
      'T16',
      'output',
      'Report export (desktop BtnExel / CSV): the sales register exports the rows on screen, including the saved voucher',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOneLine(ctx, page);
        await page.goto('/reports/sales-register');
        await page.getByRole('button', { name: 'Run', exact: true }).click();
        await page.locator('table.grid tbody tr').filter({ hasText: vchNo }).first().waitFor();
        const [download] = await Promise.all([
          page.waitForEvent('download', { timeout: 10_000 }),
          page.getByRole('button', { name: 'CSV', exact: true }).first().click(),
        ]);
        const { readFileSync } = await import('node:fs');
        const text = readFileSync(await download.path(), 'utf8');
        assert.match(text, new RegExp(vchNo));
        return {
          observation: `${download.suggestedFilename()}: ${text.split('\n').length} lines, contains ${vchNo}`,
          expected: 'CSV with the saved voucher',
          output: Buffer.from(text),
        };
      },
      { expected: { download: 'csv containing the voucher' } },
    ),

    C(
      'journey.sale-to-register-and-ledger',
      'T18',
      'mutation',
      'J04: retail sale continues into the sales register, party ledger and day book',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOneLine(ctx, page);
        const reg = await registerRow(page, vchNo);
        await page.goto('/reports/day-book');
        await page.getByRole('button', { name: 'Run', exact: true }).click();
        const day = await page.locator('table.grid').first().innerText();
        assert.match(day, new RegExp(vchNo));
        return {
          observation: `voucher ${vchNo} visible in sales register and day book`,
          expected: 'downstream visibility',
          database: { header: await header(ctx, vchNo) },
          downstream: { register: reg, dayBookContains: true },
        };
      },
    ),

    {
      id: 'sales-invoice.rollback.mid-write',
      group: 'T14',
      kind: 'refusal',
      source: 'Playbook T14: fail after each effect family before commit; complete rollback',
      applicable: true,
      requiredEvidence: ['browser', 'expected', 'database'],
      blocked:
        'Needs declared transport/DB fault injection at each effect boundary; the harness has no fault injector yet (tracked as a framework gap).',
      run: async () => ({}),
    },
    {
      id: 'sales-invoice.config.setting-change',
      group: 'T15',
      kind: 'mutation',
      source:
        'Playbook T15: change SL_AMT_TYPE between preview and save; reopen a historic document',
      applicable: true,
      requiredEvidence: ['browser', 'expected', 'database', 'downstream'],
      blocked: 'Settings-variant fixture pack (SL_AMT_TYPE=F company) not yet in the catalogue.',
      run: async () => ({}),
    },
  ],
};

/** The Sales Invoice screen helpers, for modules that observe a sale (settings effects, journeys). */
export const salesScreen = {
  openSales,
  pickParty,
  fillLine,
  save,
  field,
  cell,
  header,
  lines,
  ledger,
  counts,
  LINE_A,
};
