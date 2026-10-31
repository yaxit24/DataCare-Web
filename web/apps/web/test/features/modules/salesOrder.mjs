import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Transaction → Sales Order (desktop TR_SALE_ORD, opened with CurBookHelp("SALES ORDER"),
 * MDI_FORM.cs:7992-8003).
 *
 * Expected values follow the desktop form, not the web code:
 * - A line's metal amount is weight × rate rounded to whole rupees, where the weight follows the company's
 *   SL_AMT_TYPE: fine for F, gross for G, otherwise net + ghat (TR_SALE_ORD.cs:6560-6672). The catalogue company
 *   has SL_AMT_TYPE N (seedCompany, Ac_Image.cs:6221), so the basis is net + ghat.
 * - Per-gram labour is net × labour rate rounded to whole rupees (:6858-6862); the line total is metal + labour +
 *   other (:6878) and the line net equals it (:7164).
 * - The bill sums the line nets, takes tax as round(net × tax %, 0) and the total as round(net + tax, 0)
 *   (:11340-11342).
 * - The advance is the sum of the tender rows: cash, UPI, cheque, card, old gold, old silver and scheme (:11368).
 *   The header stores CASH_AMT and ADV_AMT (:9126-9142). Order_Ledr credits the customer and debits the order
 *   book's slot-1 account with the cash (legs 01/02), and posts cheque, card and UPI legs of their own
 *   (Ac_Ledr.cs:28-61). An order moves no stock.
 * - Save refuses a missing party ("Please Insert Party and try", :9040) and a date after the year closes (:9012-9015).
 */
const BOOK = 'SOR';
const CASH = 'CASH';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

// Line O: GLD22 gross 10.25, net 10, touch 91.6, rate 6123.45, labour 237.5 /g, no ghat.
//   metal  = round((10 + 0) × 6,123.45 = 61,234.5, 0) = 61,234   (banker's rounding, TR_SALE_ORD.cs:6672)
//   labour = round(10 × 237.5, 0)                     =  2,375   (:6858)
//   line 63,609; tax = round(63,609 × 3% = 1,908.27, 0) = 1,908; total = round(65,517, 0) = 65,517 (:11340-11342)
const LINE_O = {
  item: ITEMS.gold.code,
  pcs: '1',
  gross: '10.25',
  net: '10',
  touch: '91.6',
  rate: '6123.45',
  labour: '237.5',
};
const EXPECT_O = { metal: 61234, labour: 2375, line: 63609, tax: 1908, total: 65517 };
// Line W: touch 100 makes the fine and net bases the same, so lifecycle cases do not depend on the basis:
//   metal 5 × 1,500 = 7,500; labour 5 × 40 = 200; line 7,700; tax 231; total 7,931.
const LINE_W = {
  item: ITEMS.gold.code,
  pcs: '1',
  gross: '5',
  net: '5',
  touch: '100',
  rate: '1500',
  labour: '40',
};
const EXPECT_W = { metal: 7500, labour: 200, line: 7700, tax: 231, total: 7931 };
const LINE_S = {
  item: ITEMS.silver.code,
  pcs: '2',
  gross: '50',
  net: '50',
  touch: '100',
  rate: '80',
  labour: '0',
};
const ADVANCE = 5000;

const editor = (page) => page.getByRole('form', { name: 'Sales Order editor' });
const lineRow = (page, n) =>
  editor(page)
    .locator('table.grid tbody tr')
    .nth(n - 1);

async function openOrder(page) {
  await page.goto('/txn/sales-order');
  await page.getByRole('heading', { name: 'Sales Order', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned SALES ORDER book is selected');
  // The editor is disabled until the order's calculation settings load.
  await page.waitForFunction(() => {
    const input = document.querySelector('[aria-label="Labour rate item 1"]');
    return input && !input.matches(':disabled');
  });
}
async function pickCustomer(page, code) {
  const input = page.getByLabel('Customer account', { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}
async function fillLine(page, n, line) {
  const item = page.getByLabel(`Item code ${n}`, { exact: true });
  await item.fill(line.item);
  await item.press('Escape');
  for (const [label, key] of [
    ['Pieces', 'pcs'],
    ['Gross weight', 'gross'],
    ['Net weight', 'net'],
    ['Touch', 'touch'],
    ['Rate', 'rate'],
    ['Labour rate', 'labour'],
  ])
    if (line[key] !== undefined)
      await page.getByLabel(`${label} item ${n}`, { exact: true }).fill(line[key]);
  // Labour is committed when its cell loses focus.
  await page.getByLabel(`Labour rate item ${n}`, { exact: true }).press('Tab');
}
const saveResponse = (page) =>
  page.waitForResponse(
    (r) =>
      /^\/api\/sales-orders(\/\d+)?$/.test(new URL(r.url()).pathname) &&
      ['POST', 'PUT'].includes(r.request().method()),
  );
async function save(page, label = 'Save Sales Order') {
  const [response] = await Promise.all([
    saveResponse(page),
    page.getByRole('button', { name: label, exact: true }).click(),
  ]);
  return response;
}
/** Clicks Save and reports the response, or what the browser blocked. */
async function trySave(page, label = 'Save Sales Order') {
  const response = page
    .waitForResponse(
      (r) =>
        /^\/api\/sales-orders(\/\d+)?$/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
      { timeout: 4000 },
    )
    .catch(() => null);
  await page.getByRole('button', { name: label, exact: true }).click();
  const got = await response;
  if (got) return { response: got };
  const blocked = await page.evaluate(() => {
    const el = document.querySelector('form :invalid');
    return el
      ? `${el.id || el.getAttribute('aria-label') || el.tagName}: ${el.validationMessage}`
      : null;
  });
  return { response: null, blocked };
}
async function enterOrder(
  page,
  { customer = PARTIES.local.code, lines = [LINE_W], advance, date } = {},
) {
  await openOrder(page);
  if (date) await page.getByLabel('Order date', { exact: true }).fill(date);
  if (customer) await pickCustomer(page, customer);
  for (const [i, line] of lines.entries()) {
    if (i) await page.getByRole('button', { name: '+ Add line', exact: true }).click();
    await fillLine(page, i + 1, line);
  }
  if (advance !== undefined)
    await page.getByLabel('Advance ₹', { exact: true }).fill(String(advance));
}
async function createOrder(ctx, page, options = {}) {
  await enterOrder(page, options);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  const body = await response.json();
  await page.getByText(`Sales order #${body.vchNo} saved`, { exact: false }).waitFor();
  return String(body.vchNo).padStart(5, '0');
}
async function loadOrder(page, vchNo) {
  await page.getByLabel('Order number', { exact: true }).fill(vchNo);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        r.request().method() === 'GET' &&
        new URL(r.url()).pathname === `/api/sales-orders/${vchNo}`,
    ),
    page.getByRole('button', { name: 'Load order', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.getByText(`Editing order #${vchNo}`, { exact: true }).waitFor();
}
async function deleteLoaded(page, vchNo) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        r.request().method() === 'DELETE' &&
        new URL(r.url()).pathname === `/api/sales-orders/${vchNo}`,
    ),
    page.getByRole('button', { name: 'Delete order', exact: true }).click(),
  ]);
  return response;
}
async function openDetails(page) {
  const summary = page.getByText('Order details', { exact: true });
  if (!(await summary.locator('..').evaluate((element) => element.open))) await summary.click();
}
const listRow = (page, vchNo) =>
  page
    .locator('.panel', { has: page.getByRole('heading', { name: 'Recent Sales Orders' }) })
    .locator('tbody tr', { hasText: vchNo })
    .first();

const header = (ctx, v) =>
  ctx.rows(
    `SELECT "VCH_NO","HD_VCH_NO","AC_CODE",btrim("MAIN_USER"::text) mu,"NET_AMT"::float net,"TAX_AMT"::float tax,
            "TOT_AMT"::float tot,"ADV_AMT"::float adv,"CASH_AMT"::float cash,"UPI_AMT"::float upi,
            "VCH_DATE"::date::text dt,"DEL_DATE"::date::text del,btrim("MOBILE"::text) mobile
       FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
    v,
  );
const lines = (ctx, v) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"IT_CODE" it,"ITM_NWT"::float nwt,"ITM_FINE"::float fine,"ITM_AMT"::float amt,
            "LBR_AMT"::float lbr,"TOT_AMT"::float tot,"NET_AMT"::float net
       FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    v,
  );
const ledger = (ctx, v) =>
  ctx.rows(
    `SELECT btrim("AC_CODE") ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    v,
  );
const stockRows = async (ctx, v) =>
  (
    await ctx.rows(
      `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
      v,
    )
  )[0].n;
const counts = async (ctx) =>
  (
    await ctx.rows(
      `SELECT (SELECT count(*) FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int ord,
              (SELECT count(*) FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int detl,
              (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int ac`,
    )
  )[0];
const balance = async (ctx, ac) =>
  (
    await ctx.rows(
      `SELECT round(coalesce(sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0)),0)::numeric,2)::float n
         FROM "AC_DATA" WHERE tenant_id=$1 AND btrim("AC_CODE")=$2`,
      ac,
    )
  )[0].n;
const latest = (ctx) =>
  ctx.rows(
    `SELECT "VCH_NO","AC_CODE","NET_AMT"::float net,"TAX_AMT"::float tax,"TOT_AMT"::float tot,
            "ADV_AMT"::float adv,"CASH_AMT"::float cash,btrim("MAIN_USER"::text) mu
       FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO" DESC LIMIT 2`,
  );
const yearOf = async (ctx) =>
  (
    await ctx.rows(
      `SELECT left("OP_DATE"::text,10) op,"CL_DATE"::date::text cl FROM "YEAR_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "OP_DATE" DESC LIMIT 1`,
    )
  )[0];
const dayAfter = (iso) => {
  const d = new Date(`${iso}T00:00:00Z`);
  d.setUTCDate(d.getUTCDate() + 1);
  return d.toISOString().slice(0, 10);
};
const legs = (rows) =>
  rows
    .map((r) => ({ ac: r.ac, dr: r.dr ?? 0, cr: r.cr ?? 0 }))
    .sort((a, b) => a.ac.localeCompare(b.ac) || a.dr - b.dr);
const round2 = (n) => Math.round(n * 100) / 100;

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `sales-order.${id}`,
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

export const salesOrder = {
  feature: 'sales-order',
  title: 'Transaction → Sales Order (TR_SALE_ORD)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/sales-order/page.tsx',
    'web/apps/web/lib/salesOrderForm.ts',
    'web/apps/web/lib/tourOrderForm.ts',
    'web/apps/api/src/modules/sales/salesOrder.ts',
    'web/apps/api/src/modules/sales/orderDoc.ts',
    'web/apps/web/test/features/modules/salesOrder.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { SL_AMT_TYPE: 'N (seedCompany)', TAX: '3% typed on the order' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'CurBookHelp("SALES ORDER") (MDI_FORM.cs:7992-8003) selects the order book; a new order is dated today with one empty line and no advance',
      async (ctx) => {
        const { page } = await ctx.session();
        await openOrder(page);
        const date = await page.getByLabel('Order date', { exact: true }).inputValue();
        const today = await page.evaluate(() => {
          const d = new Date();
          return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
        });
        const item = await page.getByLabel('Item code 1', { exact: true }).inputValue();
        const advance = await page.getByLabel('Advance ₹', { exact: true }).inputValue();
        assert.deepEqual([date, item, advance.replace(/^0$/, '')], [today, '', '']);
        return {
          observation: `book ${BOOK}, date ${date}, first line empty, advance '${advance}'`,
          expected: { book: BOOK, date: 'today', line: 'empty', advance: 'empty' },
        };
      },
    ),

    C(
      'formula.whole-rupees',
      'T03',
      'read-only',
      'TR_SALE_ORD.cs:6672, :6858, :7164 (SL_AMT_TYPE N): net 10 at 6,123.45 with 237.5 /g labour previews a line of 61,234 + 2,375 = 63,609',
      async (ctx) => {
        const { page } = await ctx.session();
        await openOrder(page);
        await pickCustomer(page, PARTIES.local.code);
        await fillLine(page, 1, LINE_O);
        await page.waitForTimeout(400);
        const line = (await lineRow(page, 1).locator('td').nth(8).innerText()).trim();
        const total = (await editor(page).locator('tfoot td.num').first().innerText()).trim();
        assert.deepEqual([line, total], ['63,609', '63,609'], `line ${line}, order total ${total}`);
        return { observation: `line ${line}; order total ${total}`, expected: EXPECT_O };
      },
      {
        expected: { line: '63,609', total: '63,609' },
        observe: async (ctx) => ({ latest: await latest(ctx) }),
      },
    ),

    C(
      'create.amounts',
      'T07',
      'mutation',
      'TR_SALE_ORD.cs:6672, :6858, :11340-11342: the saved order stores 61,234 + 2,375 = 63,609, tax 1,908 and total 65,517',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page, { lines: [LINE_O] });
        const [h] = await header(ctx, vchNo);
        const [l] = await lines(ctx, vchNo);
        assert.deepEqual(
          [l.amt, l.lbr, l.net, h.net, h.tax, h.tot],
          [
            EXPECT_O.metal,
            EXPECT_O.labour,
            EXPECT_O.line,
            EXPECT_O.line,
            EXPECT_O.tax,
            EXPECT_O.total,
          ],
        );
        return {
          observation: `order ${vchNo}: ITM_AMT ${l.amt}, LBR ${l.lbr}, NET ${h.net}, TAX ${h.tax}, TOT ${h.tot}`,
          expected: EXPECT_O,
          database: { header: h, line: l },
          downstream: { total: h.tot },
        };
      },
      {
        expected: EXPECT_O,
        observe: async (ctx) => ({
          orders: await latest(ctx),
          lines: await ctx.rows(
            `SELECT "VCH_NO","ITM_FINE"::float fine,"ITM_AMT"::float amt,"LBR_AMT"::float lbr,"NET_AMT"::float net FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO" DESC LIMIT 1`,
          ),
        }),
      },
    ),

    C(
      'create.advance-ledger',
      'T07',
      'mutation',
      'Order_Ledr (Ac_Ledr.cs:28-35): a 5,000 cash advance credits the customer and debits the cash account (slot 1 of the order book; the real book 020 holds 00001, cash), and no stock moves',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page, { advance: ADVANCE });
        const g = await ledger(ctx, vchNo);
        const stock = await stockRows(ctx, vchNo);
        assert.deepEqual(
          legs(g),
          [
            { ac: CASH, dr: ADVANCE, cr: 0 },
            { ac: PARTIES.local.code, dr: 0, cr: ADVANCE },
          ],
          `ledger ${JSON.stringify(legs(g))}`,
        );
        assert.equal(stock, 0, 'an order moves no stock');
        return {
          observation: `order ${vchNo}: legs ${JSON.stringify(legs(g))}, stock rows ${stock}`,
          expected: { cash: `Dr ${ADVANCE}`, customer: `Cr ${ADVANCE}`, stock: 0 },
          database: { ledger: g, stock },
          downstream: { legs: g.length },
        };
      },
      {
        expected: [
          { ac: CASH, dr: ADVANCE, cr: 0 },
          { ac: PARTIES.local.code, dr: 0, cr: ADVANCE },
        ],
        observe: async (ctx) => ({
          ledger: await ctx.rows(
            `SELECT "VCH_NO",btrim("AC_CODE") ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO" DESC,"LEDR_KEY" LIMIT 4`,
          ),
          slot1: await ctx.rows(
            `SELECT btrim("AC_CODE") ac FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "SR_NO"=1`,
          ),
        }),
      },
    ),

    C(
      'create.header-tender',
      'T07',
      'mutation',
      'TR_SALE_ORD.cs:9126-9142, :11368: a cash advance is stored as CASH_AMT 5,000 and, as the sum of the tenders, ADV_AMT 5,000',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page, { advance: ADVANCE });
        const [h] = await header(ctx, vchNo);
        assert.deepEqual(
          [h.cash ?? 0, h.adv ?? 0],
          [ADVANCE, ADVANCE],
          `CASH_AMT ${h.cash}, ADV_AMT ${h.adv}`,
        );
        return {
          observation: `order ${vchNo}: CASH_AMT ${h.cash}, ADV_AMT ${h.adv}`,
          expected: { CASH_AMT: ADVANCE, ADV_AMT: ADVANCE },
          database: { header: h },
          downstream: { advance: h.adv },
        };
      },
      {
        expected: { CASH_AMT: ADVANCE, ADV_AMT: ADVANCE },
        observe: async (ctx) => ({ orders: await latest(ctx) }),
      },
    ),

    C(
      'create.records-user',
      'T07',
      'mutation',
      'A new order records the logged-in user as MAIN_USER (TR_SALE_ORD.cs SL_ORD_DATA MAIN_USER)',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page);
        const [h] = await header(ctx, vchNo);
        assert.equal(h.mu, USERS.admin.user, `MAIN_USER ${h.mu}`);
        return {
          observation: `order ${vchNo}: MAIN_USER ${h.mu}`,
          expected: { mainUser: USERS.admin.user },
          database: { header: h },
          downstream: { mainUser: h.mu },
        };
      },
      {
        expected: { mainUser: USERS.admin.user },
        observe: async (ctx) => ({ orders: await latest(ctx) }),
      },
    ),

    C(
      'create.no-advance',
      'T07',
      'mutation',
      'Order_Ledr posts only non-zero tenders (Ac_Ledr.cs:28-61 `<> 0`): an order without an advance has no ledger rows',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page);
        const [h] = await header(ctx, vchNo);
        const g = await ledger(ctx, vchNo);
        assert.deepEqual([h.tot, g.length], [EXPECT_W.total, 0]);
        return {
          observation: `order ${vchNo}: total ${h.tot}, ${g.length} ledger rows`,
          expected: { total: EXPECT_W.total, ledgerRows: 0 },
          database: { header: h, ledger: g },
          downstream: { ledgerRows: g.length },
        };
      },
    ),

    C(
      'create.two-groups',
      'T05',
      'mutation',
      'Gold and silver lines on one order keep their own values; the bill nets them: 7,700 + 4,000 = 11,700, tax 351, total 12,051',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page, { lines: [LINE_W, LINE_S] });
        const l = await lines(ctx, vchNo);
        const [h] = await header(ctx, vchNo);
        assert.deepEqual(
          l.map((x) => [x.it.trim(), x.net]),
          [
            [ITEMS.gold.code, 7700],
            [ITEMS.silver.code, 4000],
          ],
        );
        assert.deepEqual([h.net, h.tax, h.tot], [11700, 351, 12051]);
        return {
          observation: `order ${vchNo}: lines ${JSON.stringify(l.map((x) => x.net))}, total ${h.tot}`,
          expected: { lines: [7700, 4000], net: 11700, tax: 351, total: 12051 },
          database: { lines: l, header: h },
          downstream: { total: h.tot },
        };
      },
    ),

    C(
      'create.tender-modes',
      'T02',
      'mutation',
      'TR_SALE_ORD.cs:11368 and Order_Ledr legs 01/02 and 12/13: an advance of 3,000 cash and 2,000 UPI posts each tender to its own account',
      async (ctx) => {
        const { page } = await ctx.session();
        await enterOrder(page, { advance: 3000 });
        await openDetails(page);
        // A locked field's label carries a "· Read only" suffix, so the field is found by its id.
        const upi = page.locator('#sales-header-upiAmount');
        const editable = await upi.evaluate((input) => !input.readOnly && !input.disabled);
        assert(
          editable,
          'the UPI amount on the order is read-only, so an advance can only be cash',
        );
        return {
          observation: 'UPI amount editable',
          expected: 'cash 3,000 and UPI 2,000',
          database: {},
          downstream: {},
        };
      },
      {
        expected: {
          cash: 3000,
          upi: 2000,
          legs: 'customer Cr 5,000; cash Dr 3,000; UPI account Dr 2,000',
        },
        observe: async (ctx) => ({ orders: await latest(ctx) }),
      },
    ),

    C(
      'create.delivery-details',
      'T04',
      'mutation',
      'TR_SALE_ORD.cs:9152, :9161: the delivery date and mobile number typed in the order details are saved',
      async (ctx) => {
        const { page } = await ctx.session();
        const { cl } = await yearOf(ctx);
        await enterOrder(page);
        await openDetails(page);
        await page.getByLabel('Delivery Date', { exact: true }).fill(cl);
        await page.getByLabel('Mobile', { exact: true }).fill('9876501234');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        assert.deepEqual([h.del, h.mobile], [cl, '9876501234']);
        return {
          observation: `order ${vchNo}: DEL_DATE ${h.del}, MOBILE ${h.mobile}`,
          expected: { deliveryDate: cl, mobile: '9876501234' },
          database: { header: h },
          downstream: { deliveryDate: h.del },
        };
      },
    ),

    C(
      'refusal.no-customer',
      'T06',
      'refusal',
      'TR_SALE_ORD.cs:9040: an order without a party is refused ("Please Insert Party and try") and writes nothing',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await enterOrder(page, { customer: '' });
        const { response, blocked } = await trySave(page);
        const status = response?.status() ?? null;
        assert(status === null || status >= 400, `saved without a customer: ${status}`);
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: response ? `answered ${status}` : `blocked by the browser: ${blocked}`,
          expected: 'refused, no write',
          database: { before },
        };
      },
    ),

    C(
      'refusal.date-after-year',
      'T06',
      'refusal',
      'TR_SALE_ORD.cs:9012-9015: an order dated after the year closes is refused ("Voucher Date Not In Current Year") and writes nothing',
      async (ctx) => {
        const { page } = await ctx.session();
        const { cl } = await yearOf(ctx);
        const date = dayAfter(cl);
        const before = await counts(ctx);
        await enterOrder(page, { date });
        const { response, blocked } = await trySave(page);
        const status = response?.status() ?? null;
        assert(status === null || status >= 400, `an order dated ${date} was saved: ${status}`);
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: response
            ? `dated ${date}: ${status}`
            : `dated ${date}: blocked (${blocked})`,
          expected: 'refused, no write',
          database: { before },
        };
      },
    ),

    C(
      'reopen.load',
      'T08',
      'read-only',
      'A saved order reopens by number with its customer, line and advance',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page, { advance: ADVANCE });
        await loadOrder(page, vchNo);
        const got = {
          customer: await page.getByLabel('Customer account', { exact: true }).inputValue(),
          net: await page.getByLabel('Net weight item 1', { exact: true }).inputValue(),
          rate: await page.getByLabel('Rate item 1', { exact: true }).inputValue(),
          advance: await page.getByLabel('Advance ₹', { exact: true }).inputValue(),
        };
        assert.deepEqual(
          [got.customer, Number(got.net), Number(got.rate), Number(got.advance)],
          [PARTIES.local.code, 5, 1500, ADVANCE],
        );
        return { observation: `order ${vchNo} reloaded: ${JSON.stringify(got)}`, expected: got };
      },
    ),

    C(
      'reopen.recent-list',
      'T08',
      'read-only',
      'The recent list shows the order with its total 7,931, advance 5,000 and the date as dd/MM/yyyy (desktop format, D19)',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page, { advance: ADVANCE });
        const row = listRow(page, vchNo);
        await row.waitFor();
        const cells = (await row.locator('td').allInnerTexts()).map((t) => t.trim());
        const [h] = await header(ctx, vchNo);
        const shown = h.dt.split('-').reverse().join('/');
        assert.deepEqual(
          [cells[4], cells[5]],
          ['7,931', '5,000'],
          `total/advance ${cells[4]}/${cells[5]}`,
        );
        assert.equal(cells[1], shown, `the list shows the date as ${cells[1]}`);
        return {
          observation: `list row: ${cells.slice(0, 6).join(' | ')}`,
          expected: { date: shown, total: '7,931', advance: '5,000' },
        };
      },
      {
        expected: { date: 'dd/MM/yyyy', total: '7,931', advance: '5,000' },
        observe: async (ctx) => ({ orders: await latest(ctx) }),
      },
    ),

    C(
      'edit.reprice',
      'T09',
      'mutation',
      'TR_SALE_ORD.cs:6602-6672, :6800-6836: a new rate re-prices the metal (5 × 2,000 = 10,000) and leaves the labour, whose rate is unchanged: 10,200, tax 306, total 10,506; the number, hidden number and creator are kept',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page);
        const [before] = await header(ctx, vchNo);
        await loadOrder(page, vchNo);
        // The desktop re-prices the metal when the rate differs from the last one it priced (column 83) and
        // re-derives labour only when the labour rate or amount changes (columns 84 and 85).
        await page.getByLabel('Rate item 1', { exact: true }).fill('2000');
        await page.getByLabel('Rate item 1', { exact: true }).press('Tab');
        const response = await save(page, 'Update Sales Order');
        assert.equal(response.status(), 200, await response.text());
        const [after] = await header(ctx, vchNo);
        const [l] = await lines(ctx, vchNo);
        assert.deepEqual(
          [l.amt, l.lbr, l.net, after.tax, after.tot],
          [10000, 200, 10200, 306, 10506],
        );
        assert.deepEqual(
          [after.VCH_NO, after.HD_VCH_NO, after.mu],
          [before.VCH_NO, before.HD_VCH_NO, before.mu],
        );
        return {
          observation: `order ${vchNo}: line ${l.net}, total ${after.tot}; identity kept`,
          expected: { line: 10200, total: 10506, identityKept: true },
          database: { before, after, line: l },
          downstream: { total: after.tot },
        };
      },
    ),

    C(
      'delete.reverses',
      'T10',
      'mutation',
      'Delete of a loaded order removes the order, its lines and its advance legs, and writes DELETE_DATA with the user',
      async (ctx) => {
        const { page } = await ctx.session();
        const party0 = await balance(ctx, PARTIES.local.code);
        const vchNo = await createOrder(ctx, page, { advance: ADVANCE });
        await loadOrder(page, vchNo);
        const removed = await deleteLoaded(page, vchNo);
        assert.equal(removed.status(), 200, await removed.text());
        assert.deepEqual(
          [await header(ctx, vchNo), await lines(ctx, vchNo), await ledger(ctx, vchNo)],
          [[], [], []],
        );
        assert.equal(round2((await balance(ctx, PARTIES.local.code)) - party0), 0);
        const audit = await ctx.rows(
          `SELECT btrim("DELETE_USER"::text) du FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY row_id DESC LIMIT 1`,
          vchNo,
        );
        assert.deepEqual(
          audit.map((a) => a.du),
          [USERS.admin.user],
        );
        return {
          observation: `order ${vchNo} deleted; DELETE_USER ${audit[0]?.du}`,
          expected: { remaining: 0, deleteUser: USERS.admin.user },
          database: { audit },
          downstream: { remaining: 0 },
        };
      },
      {
        expected: { remaining: 0, deleteUser: USERS.admin.user },
        observe: async (ctx) => ({
          audit: await ctx.rows(
            `SELECT "VCH_NO",btrim("DELETE_USER"::text) du FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY row_id DESC LIMIT 2`,
          ),
        }),
      },
    ),

    C(
      'rights.clerk-no-order',
      'T11',
      'refusal',
      'USER_SET grants the clerk Sales Invoice only ("You Have No Rights", TR_SALE_ORD.cs:9036): no order can be created',
      async (ctx) => {
        const clerk = await ctx.session(as(USERS.clerk.user));
        const before = await counts(ctx);
        await clerk.page.goto('/txn/sales-order');
        await clerk.page.waitForTimeout(1500);
        let status = null;
        const ready = await clerk.page
          .getByLabel('Customer account', { exact: true })
          .isEnabled()
          .catch(() => false);
        if (ready) {
          await pickCustomer(clerk.page, PARTIES.local.code).catch(() => {});
          await fillLine(clerk.page, 1, LINE_W).catch(() => {});
          status = (await trySave(clerk.page).catch(() => ({ response: null }))).response?.status();
          assert.notEqual(status, 201);
        }
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: ready
            ? `save answered ${status ?? 'nothing'}`
            : 'no order editor for the clerk',
          expected: 'no write',
          database: { before },
        };
      },
    ),

    C(
      'concurrency.double-delete',
      'T12',
      'refusal',
      'Two operators delete the same order: the second is refused and the advance is reversed once',
      async (ctx) => {
        const first = await ctx.session(as(USERS.admin.user, 'operator-1'));
        const vchNo = await createOrder(ctx, first.page, { advance: ADVANCE });
        const second = await ctx.session(as(USERS.admin.user, 'operator-2'));
        await openOrder(second.page);
        await loadOrder(second.page, vchNo);
        await loadOrder(first.page, vchNo);
        const before = await balance(ctx, PARTIES.local.code);
        const one = (await deleteLoaded(first.page, vchNo)).status();
        const two = (await deleteLoaded(second.page, vchNo)).status();
        const after = await balance(ctx, PARTIES.local.code);
        assert.equal(one, 200);
        assert.equal(round2(after - before), ADVANCE, `customer moved by ${after - before}`);
        assert(two >= 400 && two < 500, `second delete answered ${two}`);
        return {
          observation: `first delete ${one}, second ${two}; customer ${before} → ${after}`,
          expected: 'second refused; advance reversed once',
          database: { before, after },
        };
      },
      {
        expected: { first: 200, second: '4xx (the order is gone)', reversed: ADVANCE },
        observe: async (ctx) => ({ orders: await latest(ctx) }),
      },
    ),

    C(
      'retry.double-click',
      'T13',
      'mutation',
      'A double-click on Save creates one order',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await enterOrder(page);
        await page.getByRole('button', { name: 'Save Sales Order', exact: true }).dblclick();
        await page.waitForTimeout(2500);
        const after = await counts(ctx);
        assert.equal(after.ord - before.ord, 1);
        return {
          observation: `${after.ord - before.ord} order created`,
          expected: 1,
          database: { before, after },
          downstream: { created: after.ord - before.ord },
        };
      },
    ),

    C(
      'print.order',
      'T16',
      'output',
      'The order bill prints the customer, the total 7,931 and the advance 5,000, and its date as dd/MM/yyyy (D19)',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOrder(ctx, page, { advance: ADVANCE });
        const row = listRow(page, vchNo);
        await row.waitFor();
        const [printed] = await Promise.all([
          page.waitForEvent('popup'),
          row.getByRole('link', { name: 'Print', exact: true }).click(),
        ]);
        await printed.waitForURL(/order-confirmation/);
        await printed.waitForLoadState();
        const text = (await printed.locator('body').innerText()).replace(/\s+/g, ' ');
        await printed.close();
        const [h] = await header(ctx, vchNo);
        const shown = h.dt.split('-').reverse().join('/');
        assert.match(text, new RegExp(PARTIES.local.name, 'i'));
        assert.match(text, /Total Amount/);
        assert.match(text, /\b7,?931(\.00)?\b/);
        assert.match(text, /\b5,?000(\.00)?\b/);
        assert(
          text.includes(shown),
          `the order prints its date as ${text.match(/\d{4}-\d{2}-\d{2}/)?.[0] ?? 'unknown'}, not ${shown}`,
        );
        return {
          observation: `print of ${vchNo}: ${text.slice(0, 200)}`,
          expected: `customer, total 7,931, advance 5,000, date ${shown}`,
          output: { bytes: text.length },
        };
      },
      {
        expected: {
          customer: PARTIES.local.name,
          total: 7931,
          advance: ADVANCE,
          date: 'dd/MM/yyyy',
        },
      },
    ),

    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'The desktop &Save mnemonic: Alt+S saves the order',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await enterOrder(page);
        const [response] = await Promise.all([saveResponse(page), page.keyboard.press('Alt+s')]);
        assert.equal(response.status(), 201, await response.text());
        const after = await counts(ctx);
        assert.equal(after.ord - before.ord, 1);
        return {
          observation: 'Alt+S saved the order',
          expected: 'save',
          database: { before, after },
          downstream: { created: 1 },
        };
      },
    ),

    C(
      'journey.advance-edit-delete',
      'T18',
      'mutation',
      'An order with a 5,000 advance credits the customer 5,000; editing the advance to 7,000 moves it to 7,000; deleting the order puts it back',
      async (ctx) => {
        const { page } = await ctx.session();
        const party0 = await balance(ctx, PARTIES.local.code);
        const vchNo = await createOrder(ctx, page, { advance: ADVANCE });
        const party1 = await balance(ctx, PARTIES.local.code);
        await loadOrder(page, vchNo);
        await page.getByLabel('Advance ₹', { exact: true }).fill('7000');
        const edited = await save(page, 'Update Sales Order');
        assert.equal(edited.status(), 200, await edited.text());
        const party2 = await balance(ctx, PARTIES.local.code);
        await loadOrder(page, vchNo);
        assert.equal((await deleteLoaded(page, vchNo)).status(), 200);
        const party3 = await balance(ctx, PARTIES.local.code);
        const deltas = [party1 - party0, party2 - party0, party3 - party0].map(round2);
        assert.deepEqual(deltas, [-ADVANCE, -7000, 0]);
        return {
          observation: `customer Δ after save ${deltas[0]}, after edit ${deltas[1]}, after delete ${deltas[2]}`,
          expected: { afterSave: -ADVANCE, afterEdit: -7000, afterDelete: 0 },
          database: { party0, party1, party2, party3 },
          downstream: { deltas },
        };
      },
    ),

    C(
      'journey.order-to-sale',
      'T18',
      'mutation',
      'TR_SALE.cs:7299, :14735: a sale for the customer adjusts the order advance; the bill outstanding and the customer move by the sale total less 5,000, and the order has nothing left',
      async (ctx) => {
        const { page } = await ctx.session();
        const party0 = await balance(ctx, PARTIES.local.code);
        const order = await createOrder(ctx, page, { advance: ADVANCE });
        await page.goto('/txn/sales');
        await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
        const book = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
        for (let i = 0; i < 50 && !(await book.inputValue()); i++) await page.waitForTimeout(100);
        const customer = page.getByPlaceholder('search accounts… (F1)').first();
        await customer.fill(PARTIES.local.code);
        await customer
          .locator('xpath=..')
          .getByText(PARTIES.local.code, { exact: true })
          .first()
          .waitFor();
        await customer.press('Enter');
        const grid = page
          .locator('table', { has: page.locator('th', { hasText: 'Making/g' }) })
          .first();
        const cell = (n) =>
          grid.locator('tbody tr').nth(0).locator(`td:nth-child(${n}) input`).first();
        await cell(1).fill(LINE_W.item);
        await cell(1).press('Escape');
        for (const [n, v] of [
          [3, LINE_W.pcs],
          [4, LINE_W.gross],
          [5, LINE_W.net],
          [6, LINE_W.touch],
          [7, LINE_W.rate],
          [8, LINE_W.labour],
        ])
          await cell(n).fill(v);
        const orderField = (label) =>
          page
            .locator('.field', { has: page.locator('label', { hasText: label }) })
            .locator('input')
            .first();
        await orderField('Ord No (advance)').fill(String(Number(order)));
        await orderField('Order Amt').fill(String(ADVANCE));
        const [sold] = await Promise.all([
          page.waitForResponse(
            (r) => new URL(r.url()).pathname === '/api/sales' && r.request().method() === 'POST',
          ),
          page.getByRole('button', { name: 'Save Invoice', exact: true }).click(),
        ]);
        assert.equal(sold.status(), 201, await sold.text());
        const sale = String((await sold.json()).vchNo).padStart(5, '0');
        const [s] = await ctx.rows(
          `SELECT "TOT_AMT"::float tot,"BILL_OS"::float os,"ADV_AMT"::float adv FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
          sale,
        );
        const adj = await ctx.rows(
          `SELECT "PAID_AMT"::float paid FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "ORD_NO"=$2`,
          order,
        );
        const party1 = await balance(ctx, PARTIES.local.code);
        assert.equal(round2(s.os), round2(s.tot - ADVANCE), `BILL_OS ${s.os} for total ${s.tot}`);
        assert.equal(
          round2(party1 - party0),
          round2(s.tot - ADVANCE),
          `customer moved by ${party1 - party0}`,
        );
        assert.deepEqual(
          adj.map((a) => a.paid),
          [ADVANCE],
        );
        return {
          observation: `order ${order} + sale ${sale}: total ${s.tot}, outstanding ${s.os}, customer Δ ${round2(party1 - party0)}`,
          expected: {
            outstanding: 'total − 5,000',
            customerDelta: 'total − 5,000',
            adjusted: ADVANCE,
          },
          database: { sale: s, adjustments: adj },
          downstream: { customerDelta: round2(party1 - party0) },
        };
      },
      {
        expected: {
          outstanding: 'sale total − 5,000',
          customerDelta: 'sale total − 5,000',
          adjusted: ADVANCE,
        },
        observe: async (ctx) => ({
          sales: await ctx.rows(
            `SELECT "VCH_NO","TOT_AMT"::float tot,"BILL_OS"::float os,"ADV_AMT"::float adv FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' ORDER BY "VCH_NO" DESC LIMIT 1`,
          ),
          adjustments: await ctx.rows(
            `SELECT "ORD_NO","PAID_AMT"::float paid FROM "SL_ORD_ADJ" WHERE tenant_id=$1 ORDER BY row_id DESC LIMIT 2`,
          ),
        }),
      },
    ),

    {
      ...C('rollback.mid-write', 'T14', 'refusal', 'Playbook T14', async () => ({})),
      blocked: 'No fault injector in the harness yet (G173 / N166).',
    },
    {
      ...C(
        'config.setting-variant',
        'T15',
        'mutation',
        'Playbook T15: SL_AMT_TYPE F or G changes the metal basis (TR_SALE_ORD.cs:6560-6672)',
        async () => ({}),
      ),
      blocked: 'No settings-variant company in the catalogue yet (G174 / N166).',
    },
  ],
};
