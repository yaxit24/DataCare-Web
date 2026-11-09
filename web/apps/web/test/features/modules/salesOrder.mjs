import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import { rollbackMatrix } from '../faults.mjs';

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
/** Measured on the first run: one saved order with an advance changes exactly these tables. */
const ORDER_WRITE_SET = ['AC_DATA', 'ROJ_MEL_DATA', 'SL_ORD_DATA', 'SL_ORD_DETL', 'TEMP_BOOK_DATA'];
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
/** A UPI Id unique to this run (UPI_DATA.UPI_ID is checked company-wide). */
const RUN = Date.now().toString(36).slice(-6).toUpperCase();
const upiId = (tag) => `E2E${RUN}${tag}`;
async function fillUpi(page, n, { ac, type, id, amount }) {
  if (!(await page.getByLabel(`UPI AcCode line ${n}`, { exact: true }).count()))
    await page.getByRole('button', { name: '+ Add UPI row', exact: true }).click();
  await page.getByLabel(`UPI AcCode line ${n}`, { exact: true }).fill(ac);
  await page.getByLabel(`UPI Type line ${n}`, { exact: true }).fill(type);
  await page.getByLabel(`UPI Id line ${n}`, { exact: true }).fill(id);
  await page.getByLabel(`UPI Amt line ${n}`, { exact: true }).fill(amount);
}
const upiInputs = async (page, n) => ({
  ac: await page.getByLabel(`UPI AcCode line ${n}`, { exact: true }).inputValue(),
  name: (await page.getByTestId(`upi-name-${n}`).textContent())?.trim(),
  type: await page.getByLabel(`UPI Type line ${n}`, { exact: true }).inputValue(),
  id: await page.getByLabel(`UPI Id line ${n}`, { exact: true }).inputValue(),
  amount: await page.getByLabel(`UPI Amt line ${n}`, { exact: true }).inputValue(),
});
const tenderTotals = (ctx, v) =>
  ctx.rows(
    `SELECT "CASH_AMT"::float cash,"UPI_AMT"::float upi,"ADV_AMT"::float adv
       FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
    v,
  );
const upiRows = (ctx, v) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,btrim("AC_CODE") ac,btrim("UPI_AC_CODE") "upiAc",btrim("UPI_AC_NAME") name,
            btrim("UPI_TYPE") type,btrim("UPI_ID") id,"UPI_AMT"::float amt
       FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    v,
  );
/** Ledger or day-book rows with the leg type (key characters 22-23) and the STR(SR_NO) line after it. */
const keyedLegs = (ctx, table, v) =>
  ctx.rows(
    `SELECT substr("LEDR_KEY",22,2) leg,btrim(substr("LEDR_KEY",24)) line,length("LEDR_KEY")::int len,
            btrim("AC_CODE") ac,"DR_AMT"::float dr,"CR_AMT"::float cr
            ${table === 'AC_DATA' ? `,coalesce(btrim("LDR_NAME"),'') name` : ''}
       FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    v,
  );
/**
 * G206 (old metal): the order's old gold / old silver grid, TR_SALE_ORD MSG_OLD (ItCode, ItName, Pcs, GrWt, OthWt,
 * NetWt, Touch, Fine, RTyp, Rate, NetAmt). Net weight, fine, rate and amount are derived the way CommPassTotal_Old
 * does (:4427-4500); the operator types gross, other, touch, rate type and the amount.
 */
async function fillOldMetal(page, n, row) {
  const label = (name) => `Old metal ${name} line ${n}`;
  if (!(await page.getByLabel(label('item'), { exact: true }).count()))
    await page.getByRole('button', { name: '+ Add old metal row', exact: true }).click();
  const item = page.getByLabel(label('item'), { exact: true });
  await item.fill(row.item);
  await item.press('Enter');
  // The picked item fills ItName and its type, which decides gold or silver in the totals.
  await page.waitForFunction(
    (testId) => !!document.querySelector(`[data-testid="${testId}"]`)?.textContent?.trim(),
    `old-metal-name-${n}`,
  );
  for (const [name, key] of [
    ['pcs', 'pcs'],
    ['gross', 'gross'],
    ['other', 'other'],
    ['touch', 'touch'],
    ['amount', 'amount'],
  ])
    if (row[key] !== undefined) await page.getByLabel(label(name), { exact: true }).fill(row[key]);
  if (row.rateType)
    await page.getByLabel(label('rate type'), { exact: true }).selectOption(row.rateType);
}
const oldMetalInputs = async (page, n) => {
  const read = (name) =>
    page.getByLabel(`Old metal ${name} line ${n}`, { exact: true }).inputValue();
  return {
    item: await read('item'),
    pcs: await read('pcs'),
    gross: await read('gross'),
    other: await read('other'),
    net: await read('net'),
    touch: await read('touch'),
    fine: await read('fine'),
    rateType: await read('rate type'),
    rate: await read('rate'),
    amount: await read('amount'),
  };
};
const oldMetalHeader = (ctx, v) =>
  ctx.rows(
    `SELECT "CASH_AMT"::float cash,"ADV_AMT"::float adv,"OLD_GL_AMT"::float "glAmt","OLD_SL_AMT"::float "slAmt",
            "OLD_GL"::float gl,"OLD_SL"::float sl
       FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
    v,
  );
const oldMetalDetail = (ctx, v) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,btrim("IT_CODE") it,btrim("IT_TYPE") typ,btrim("IT_DESC") descr,"ITM_PCS"::float pcs,
            "ITM_GWT"::float gwt,"ITM_OTH"::float oth,"ITM_NWT"::float nwt,"ITM_TOUCH"::float touch,
            "ITM_FINE"::float fine,btrim("ITM_RATE_TYPE") rtype,"ITM_RATE"::float rate,"NET_AMT"::float net,
            btrim("ENTRY_TYPE") entry,btrim("VCH_TYPE") vtype,btrim("AC_CODE") ac,btrim("MAIN_USER") mu
       FROM "SL_PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    v,
  );
/** Day-book rows with the metal columns Order_Rojmel keeps on types 04 and 06. */
const metalDayBook = (ctx, v) =>
  ctx.rows(
    `SELECT substr("LEDR_KEY",22,2) leg,btrim(substr("LEDR_KEY",24)) line,length("LEDR_KEY")::int len,
            btrim("AC_CODE") ac,btrim("LD_CODE") ld,"DR_AMT"::float dr,"CR_AMT"::float cr,
            btrim("IT_TYPE") typ,btrim(coalesce("SIGN",'')) sign,"ITM_FINE"::float fine,"ITM_NWT"::float nwt
       FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    v,
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
    'web/apps/web/test/features/faults.mjs',
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
      'create.upi-tender',
      'T02',
      'mutation',
      'TR_SALE_ORD MSG_UPI (:3698-3711, :9520-9556), :11368, Order_Ledr legs 12/13 (Ac_Ledr.cs:55-57) and Order_Rojmel type 08 (Ac_Rojmel.cs:25): cash 3,000 and a UPI row of 2,000 make ADV_AMT 5,000; the row is stored in UPI_DATA and posted to its UPI account',
      async (ctx) => {
        const { page } = await ctx.session();
        const id = upiId('A');
        await enterOrder(page, { advance: 3000 });
        await openDetails(page);
        await page.getByLabel('Cash A/c', { exact: true }).fill(CASH);
        await fillUpi(page, 1, { ac: PARTIES.bank.code, type: 'GPAY', id, amount: '2000' });
        assert.equal(
          await page.locator('#sales-header-upiAmount').inputValue(),
          '2000',
          'UPI Amt is the total of the UPI rows (TotAmt)',
        );
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const party = PARTIES.local.code;
        const bank = PARTIES.bank.code;
        const [h] = await tenderTotals(ctx, vchNo);
        const u = await upiRows(ctx, vchNo);
        const g = await keyedLegs(ctx, 'AC_DATA', vchNo);
        const r = await keyedLegs(ctx, 'ROJ_MEL_DATA', vchNo);
        assert.deepEqual(h, { cash: 3000, upi: 2000, adv: 5000 });
        assert.deepEqual(u, [
          { sr: 1, ac: party, upiAc: bank, name: PARTIES.bank.name, type: 'GPAY', id, amt: 2000 },
        ]);
        assert.deepEqual(
          g.map((x) => [x.leg, x.line, x.len, x.ac, x.dr, x.cr]),
          [
            ['01', '', 23, party, 0, 3000],
            ['02', '', 23, CASH, 3000, 0],
            ['12', '1', 33, party, 0, 2000],
            ['13', '1', 33, bank, 2000, 0],
          ],
        );
        assert.equal(g[2].name, `UPI - ${PARTIES.local.name}`, 'leg 12 names the tender');
        assert.deepEqual(
          r.map((x) => [x.leg, x.line, x.ac, x.dr, x.cr]),
          [
            ['01', '', party, 0, 5000],
            ['08', '1', bank, 2000, 0],
          ],
        );
        await loadOrder(page, vchNo);
        await openDetails(page);
        const reopened = {
          cash: await page.getByLabel('Advance ₹', { exact: true }).inputValue(),
          upi: await page.locator('#sales-header-upiAmount').inputValue(),
          row: await upiInputs(page, 1),
        };
        assert.deepEqual(reopened, {
          cash: '3000',
          upi: '2000',
          row: { ac: bank, name: PARTIES.bank.name, type: 'GPAY', id, amount: '2000' },
        });
        return {
          observation: `order ${vchNo}: ${JSON.stringify(h)}; UPI_DATA ${u.length} row; legs ${g.map((x) => x.leg).join('/')}; day book ${r.map((x) => x.leg).join('/')}`,
          expected: { cash: 3000, upi: 2000, advance: 5000, legs: '01/02/12/13', dayBook: '01/08' },
          database: { header: h, upi: u, ledger: g, dayBook: r },
          downstream: { reopened },
        };
      },
    ),

    C(
      'edit.upi-amount-then-delete',
      'T09',
      'mutation',
      'TR_SALE_ORD rewrites UPI_DATA on every save (:9520-9556) and deletes it with the order (:9732): a UPI order can be edited (2,000 to 2,500 moves UPI_DATA, legs 12/13 and ADV_AMT together) and deleting it leaves no UPI row or leg',
      async (ctx) => {
        const { page } = await ctx.session();
        const bank = PARTIES.bank.code;
        const bankBefore = await balance(ctx, bank);
        await enterOrder(page, { advance: 1000 });
        await openDetails(page);
        await page.getByLabel('Cash A/c', { exact: true }).fill(CASH);
        await fillUpi(page, 1, { ac: bank, type: 'PHONEPE', id: upiId('B'), amount: '2000' });
        const created = await save(page);
        assert.equal(created.status(), 201, await created.text());
        const vchNo = String((await created.json()).vchNo).padStart(5, '0');
        await loadOrder(page, vchNo);
        await openDetails(page);
        await page.getByLabel('UPI Amt line 1', { exact: true }).fill('2500');
        const edited = await save(page, 'Update Sales Order');
        assert.equal(edited.status(), 200, await edited.text());
        const [h] = await tenderTotals(ctx, vchNo);
        assert.deepEqual(h, { cash: 1000, upi: 2500, adv: 3500 });
        assert.deepEqual(
          (await upiRows(ctx, vchNo)).map((x) => x.amt),
          [2500],
        );
        const upiLegs = (await keyedLegs(ctx, 'AC_DATA', vchNo)).filter((x) =>
          ['12', '13'].includes(x.leg),
        );
        assert.deepEqual(
          upiLegs.map((x) => [x.leg, x.dr, x.cr]),
          [
            ['12', 0, 2500],
            ['13', 2500, 0],
          ],
        );
        const bankAfterEdit = await balance(ctx, bank);
        assert.equal(
          Math.round((bankAfterEdit - bankBefore) * 100) / 100,
          2500,
          'the UPI account is debited the edited 2,500',
        );
        await loadOrder(page, vchNo);
        const removed = await deleteLoaded(page, vchNo);
        assert.equal(removed.status(), 200, await removed.text());
        const after = {
          upi: (await upiRows(ctx, vchNo)).length,
          legs: (await keyedLegs(ctx, 'AC_DATA', vchNo)).length,
          dayBook: (await keyedLegs(ctx, 'ROJ_MEL_DATA', vchNo)).length,
        };
        assert.deepEqual(after, { upi: 0, legs: 0, dayBook: 0 });
        const bankAfterDelete = await balance(ctx, bank);
        assert.equal(bankAfterDelete, bankBefore, 'the delete takes the UPI debit back');
        return {
          observation: `order ${vchNo}: edited to ${JSON.stringify(h)}; deleted, ${JSON.stringify(after)}`,
          expected: { edited: { upi: 2500, adv: 3500 }, deleted: { upi: 0, legs: 0, dayBook: 0 } },
          database: { header: h, after },
          downstream: {
            upiAccountBalance: {
              before: bankBefore,
              afterEdit: bankAfterEdit,
              afterDelete: bankAfterDelete,
            },
          },
        };
      },
    ),

    C(
      'refusal.duplicate-upi-id',
      'T06',
      'refusal',
      'TR_SALE_ORD.cs:3913-3925: on a new order a UPI Id already in UPI_DATA is refused with "This UpiId already Exist In Book No =  <book> AND VchNo = <no> Please Change Upi Id ..." and nothing is written',
      async (ctx) => {
        const { page } = await ctx.session();
        const bank = PARTIES.bank.code;
        const id = upiId('C');
        await enterOrder(page, { advance: 500 });
        await openDetails(page);
        await page.getByLabel('Cash A/c', { exact: true }).fill(CASH);
        await fillUpi(page, 1, { ac: bank, type: 'GPAY', id, amount: '700' });
        const first = await save(page);
        assert.equal(first.status(), 201, await first.text());
        const firstNo = String((await first.json()).vchNo).padStart(5, '0');
        const before = await counts(ctx);
        await enterOrder(page, { advance: 500 });
        await openDetails(page);
        await page.getByLabel('Cash A/c', { exact: true }).fill(CASH);
        await fillUpi(page, 1, { ac: bank, type: 'GPAY', id, amount: '900' });
        const { response, blocked } = await trySave(page);
        assert.equal(response?.status(), 400, `answered ${response?.status()} ${blocked ?? ''}`);
        const message = `This UpiId already Exist In Book No =  ${BOOK} AND VchNo = ${firstNo} Please Change Upi Id ...`;
        const body = await response.text();
        assert(body.includes(message), `the API answers with the desktop text, got ${body}`);
        await page.getByText(message, { exact: false }).waitFor();
        assert.deepEqual(await counts(ctx), before, 'nothing written');
        return {
          observation: `refused: ${message}`,
          expected: { status: 400, message, written: 0 },
          database: { before },
        };
      },
    ),

    C(
      'create.old-metal-tenders',
      'T02',
      'mutation',
      'TR_SALE_ORD MSG_OLD (:3957-4020, :4427-4500), :9421-9475, :11345-11368, Order_Rojmel types 01/04 (Ac_Rojmel.cs:11, :17): old gold and old silver taken in are stored in SL_PR_DETL (net weight = gross - other, fine = net x touch / 100, rate back-calculated from the typed amount), summed into OLD_GL_AMT / OLD_SL_AMT / OLD_GL / OLD_SL and into ADV_AMT with the cash, and each valued row is a day-book debit keyed 04 + STR(SR_NO)',
      async (ctx) => {
        const { page } = await ctx.session();
        const party = PARTIES.local.code;
        await enterOrder(page, { advance: 3000 });
        await openDetails(page);
        await page.getByLabel('Cash A/c', { exact: true }).fill(CASH);
        await fillOldMetal(page, 1, {
          item: ITEMS.gold.code,
          pcs: '1',
          gross: '10.5',
          other: '0.5',
          touch: '91.6',
          rateType: 'F',
          amount: '2000',
        });
        await fillOldMetal(page, 2, {
          item: ITEMS.silver.code,
          pcs: '3',
          gross: '50',
          touch: '80',
          rateType: 'N',
          amount: '3000',
        });
        const shown = [await oldMetalInputs(page, 1), await oldMetalInputs(page, 2)];
        assert.deepEqual(
          shown.map((r) => [r.net, r.fine, r.rate, r.amount]),
          [
            ['10.000', '9.160', '218.00', '2000'],
            ['50.000', '40.000', '60.00', '3000'],
          ],
          'the grid derives net, fine and rate as CommPassTotal_Old does (the typed amount stays as typed)',
        );
        assert.deepEqual(
          [
            await page.locator('#sales-header-oldGoldAmount').inputValue(),
            await page.locator('#sales-header-oldSilverAmount').inputValue(),
          ],
          ['2000', '3000'],
          'Old Gold Amt and Old Silver Amt are the grid totals',
        );
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await oldMetalHeader(ctx, vchNo);
        const d = await oldMetalDetail(ctx, vchNo);
        const day = await metalDayBook(ctx, vchNo);
        const g = await keyedLegs(ctx, 'AC_DATA', vchNo);
        assert.deepEqual(h, { cash: 3000, adv: 8000, glAmt: 2000, slAmt: 3000, gl: 9.16, sl: 40 });
        assert.deepEqual(
          d.map((r) => [
            r.sr,
            r.it,
            r.typ,
            r.pcs,
            r.gwt,
            r.oth,
            r.nwt,
            r.touch,
            r.fine,
            r.rtype,
            r.rate,
            r.net,
          ]),
          [
            [1, ITEMS.gold.code, 'G', 1, 10.5, 0.5, 10, 91.6, 9.16, 'F', 218, 2000],
            [2, ITEMS.silver.code, 'S', 3, 50, 0, 50, 80, 40, 'N', 60, 3000],
          ],
        );
        assert.deepEqual(
          d.map((r) => [r.entry, r.ac]),
          [
            ['A', party],
            ['A', party],
          ],
          'SL_PR_DETL rows are ENTRY_TYPE A for the order customer',
        );
        assert.deepEqual(
          day.map((r) => [r.leg, r.line, r.len, r.ac, r.dr, r.cr, r.fine]),
          [
            ['01', '', 23, party, 0, 8000, 0],
            ['04', '1', 33, 'PURCHASE', 2000, 0, 9.16],
            ['04', '2', 33, 'SLVPURC', 3000, 0, 40],
          ],
          'the day book credits the 8,000 advance and debits each purchase account (Ac_Rojmel.cs:17)',
        );
        // Order_Ledr posts legs 07-10 only for a book whose BOOK_INOUT is 'I' (Ac_Ledr.cs:42-50); the provisioned
        // SALES ORDER book is 'O', so the ledger carries the cash legs alone.
        assert.deepEqual(
          g.map((x) => x.leg),
          ['01', '02'],
        );
        await loadOrder(page, vchNo);
        await openDetails(page);
        const reopened = [await oldMetalInputs(page, 1), await oldMetalInputs(page, 2)];
        assert.deepEqual(
          reopened.map((r) => [
            r.item,
            r.gross,
            r.other,
            r.net,
            r.touch,
            r.fine,
            r.rateType,
            r.rate,
            r.amount,
          ]),
          [
            [
              ITEMS.gold.code,
              '10.500',
              '0.500',
              '10.000',
              '91.60',
              '9.160',
              'F',
              '218.00',
              '2000.00',
            ],
            [ITEMS.silver.code, '50.000', '', '50.000', '80.00', '40.000', 'N', '60.00', '3000.00'],
          ],
        );
        return {
          observation: `order ${vchNo}: ${JSON.stringify(h)}; SL_PR_DETL ${d.length} rows; day book ${day.map((x) => x.leg).join('/')}`,
          expected: {
            cash: 3000,
            oldGold: 2000,
            oldSilver: 3000,
            advance: 8000,
            dayBook: '01/04/04',
          },
          database: { header: h, detail: d, dayBook: day, ledger: g },
          downstream: { reopened },
        };
      },
    ),

    C(
      'create.old-metal-unvalued-fine',
      'T02',
      'mutation',
      'Order_Rojmel type 06 (Ac_Rojmel.cs:21) and TR_SALE_ORD.cs:9421-9475: old silver taken in with no amount (NET_AMT 0, ITM_FINE <> 0) is a money-free fine row: the advance stays the cash, OLD_SL holds the fine, OLD_SL_AMT is 0, and the day book keeps a type 06 row keyed 06 + STR(SR_NO) with SIGN + and the metal letter',
      async (ctx) => {
        const { page } = await ctx.session();
        const party = PARTIES.local.code;
        await enterOrder(page, { advance: 1000 });
        await openDetails(page);
        await page.getByLabel('Cash A/c', { exact: true }).fill(CASH);
        await fillOldMetal(page, 1, {
          item: ITEMS.silver.code,
          pcs: '2',
          gross: '20',
          touch: '100',
        });
        assert.equal(
          (await oldMetalInputs(page, 1)).fine,
          '20.000',
          'touch 100 makes the fine the net weight',
        );
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await oldMetalHeader(ctx, vchNo);
        const [row] = await oldMetalDetail(ctx, vchNo);
        const day = await metalDayBook(ctx, vchNo);
        assert.deepEqual(h, { cash: 1000, adv: 1000, glAmt: 0, slAmt: 0, gl: 0, sl: 20 });
        assert.deepEqual(
          [row.it, row.typ, row.nwt, row.fine, row.rate, row.net],
          [ITEMS.silver.code, 'S', 20, 20, 0, 0],
        );
        assert.deepEqual(
          day.map((r) => [r.leg, r.line, r.ac, r.ld, r.dr, r.cr, r.typ, r.sign, r.fine]),
          [
            ['01', '', party, CASH, 0, 1000, 'A', '', 0],
            ['06', '1', party, 'SLVPURC', 0, 0, 'S', '+', 20],
          ],
        );
        return {
          observation: `order ${vchNo}: ${JSON.stringify(h)}; day book ${day.map((x) => x.leg).join('/')}`,
          expected: { advance: 1000, oldSilverFine: 20, dayBook: '01/06' },
          database: { header: h, detail: row, dayBook: day },
          downstream: { advance: h.adv },
        };
      },
    ),

    C(
      'edit.old-metal-then-delete',
      'T09',
      'mutation',
      'TR_SALE_ORD rewrites SL_PR_DETL on every save (:9421-9475) and deletes it with the order: an order with old metal can be edited (the old gold amount 2,000 to 2,500 moves SL_PR_DETL, OLD_GL_AMT, ADV_AMT and the day book together) and deleting it leaves no old-metal row or day-book row',
      async (ctx) => {
        const { page } = await ctx.session();
        await enterOrder(page, { advance: 1000 });
        await openDetails(page);
        await page.getByLabel('Cash A/c', { exact: true }).fill(CASH);
        await fillOldMetal(page, 1, {
          item: ITEMS.gold.code,
          pcs: '1',
          gross: '5',
          touch: '100',
          rateType: 'F',
          amount: '2000',
        });
        const created = await save(page);
        assert.equal(created.status(), 201, await created.text());
        const vchNo = String((await created.json()).vchNo).padStart(5, '0');
        await loadOrder(page, vchNo);
        await openDetails(page);
        await page.getByLabel('Old metal amount line 1', { exact: true }).fill('2500');
        const edited = await save(page, 'Update Sales Order');
        assert.equal(edited.status(), 200, await edited.text());
        const [h] = await oldMetalHeader(ctx, vchNo);
        const [row] = await oldMetalDetail(ctx, vchNo);
        const day = await metalDayBook(ctx, vchNo);
        assert.deepEqual([h.cash, h.glAmt, h.adv], [1000, 2500, 3500]);
        assert.deepEqual([row.net, row.rate], [2500, 500]);
        assert.deepEqual(
          day.map((r) => [r.leg, r.dr, r.cr]),
          [
            ['01', 0, 3500],
            ['04', 2500, 0],
          ],
        );
        await loadOrder(page, vchNo);
        const removed = await deleteLoaded(page, vchNo);
        assert.equal(removed.status(), 200, await removed.text());
        const after = {
          detail: (await oldMetalDetail(ctx, vchNo)).length,
          dayBook: (await metalDayBook(ctx, vchNo)).length,
          legs: (await keyedLegs(ctx, 'AC_DATA', vchNo)).length,
        };
        assert.deepEqual(after, { detail: 0, dayBook: 0, legs: 0 });
        return {
          observation: `order ${vchNo}: edited to ${JSON.stringify(h)}; deleted, ${JSON.stringify(after)}`,
          expected: {
            edited: { glAmt: 2500, adv: 3500 },
            deleted: { detail: 0, dayBook: 0, legs: 0 },
          },
          database: { header: h, detail: row, after },
          downstream: { advance: h.adv },
        };
      },
    ),

    C(
      'create.scheme-tender',
      'T02',
      'mutation',
      'TR_SALE_ORD.cs:9142, :10006, :11264-11290 and Order_Rojmel type 05 (Ac_Rojmel.cs:19): the Scheme Amt cell is typed on the Lite edition and joins the advance; the desktop day book posts it to the fixed account 00079, but the real data holds no type 05 row for the 7 of 76 orders that carry a scheme amount (PLAN-SALESORDER-ROJMEL.md section 2.4), so the web leaves it open',
      async (ctx) => {
        const { page } = await ctx.session();
        await enterOrder(page, { advance: 3000 });
        await openDetails(page);
        const editable = await page
          .locator('#sales-header-schemeAmount')
          .evaluate((input) => !input.readOnly && !input.disabled);
        assert(
          editable,
          'the scheme amount is read-only on the order, so an advance cannot include it',
        );
        return {
          observation: 'scheme amount editable',
          expected: 'cash 3,000 and scheme 1,000',
          database: {},
          downstream: {},
        };
      },
      {
        expected: { cash: 3000, scheme: 1000 },
        observe: async (ctx) => ({ orders: await latest(ctx) }),
      },
    ),

    C(
      'create.cheque-card-advance',
      'T02',
      'mutation',
      'TR_SALE_ORD.cs:9131-9150, :11368 and Order_Ledr (Ac_Ledr.cs:28-47): cash 3,000, cheque 2,000 and card 1,000 are stored per tender, ADV_AMT 6,000, and post legs 01-06; the day book credits 6,000 and debits the bank and card (Ac_Rojmel.cs:11-16)',
      async (ctx) => {
        const { page } = await ctx.session();
        await enterOrder(page, { advance: 3000 });
        await openDetails(page);
        for (const [label, value] of [
          ['Cash A/c', CASH],
          ['Cheque Amt', '2000'],
          ['Bank A/c', PARTIES.bank.code],
          ['Cheque No', '123456'],
          ['Card Amt', '1000'],
          ['Card A/c', PARTIES.bank.code],
        ])
          await page.getByLabel(label, { exact: true }).fill(value);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await ctx.rows(
          `SELECT "CASH_AMT"::float cash,"CHQ_AMT"::float chq,"CARD_AMT"::float card,"ADV_AMT"::float adv
             FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        const g = await ctx.rows(
          `SELECT right("LEDR_KEY",2) leg,btrim("AC_CODE") ac,"DR_AMT"::float dr,"CR_AMT"::float cr,btrim("CHQ_NO"::text) chq
             FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
          vchNo,
        );
        const r = await ctx.rows(
          `SELECT right("LEDR_KEY",2) leg,btrim("AC_CODE") ac,"DR_AMT"::float dr,"CR_AMT"::float cr
             FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
          vchNo,
        );
        const party = PARTIES.local.code;
        const bank = PARTIES.bank.code;
        assert.deepEqual(h, { cash: 3000, chq: 2000, card: 1000, adv: 6000 });
        assert.deepEqual(
          g.map((x) => [x.leg, x.ac, x.dr, x.cr, x.chq || '']),
          [
            ['01', party, 0, 3000, ''],
            ['02', CASH, 3000, 0, ''],
            ['03', party, 0, 2000, '123456'],
            ['04', bank, 2000, 0, '123456'],
            ['05', party, 0, 1000, '123456'],
            ['06', bank, 1000, 0, '123456'],
          ],
        );
        assert.deepEqual(
          r.map((x) => [x.leg, x.ac, x.dr, x.cr]),
          [
            ['01', party, 0, 6000],
            ['02', bank, 2000, 0],
            ['03', bank, 1000, 0],
          ],
        );
        await loadOrder(page, vchNo);
        await openDetails(page);
        const reopened = [
          await page.getByLabel('Advance ₹', { exact: true }).inputValue(),
          await page.getByLabel('Cheque Amt', { exact: true }).inputValue(),
          await page.getByLabel('Card Amt', { exact: true }).inputValue(),
        ].map(Number);
        assert.deepEqual(reopened, [3000, 2000, 1000]);
        return {
          observation: `order ${vchNo}: tenders ${JSON.stringify(h)}, ${g.length} legs, ${r.length} day-book rows; reopened ${reopened.join('/')}`,
          expected: { cash: 3000, cheque: 2000, card: 1000, advance: 6000, legs: '01-06' },
          database: { header: h, ledger: g, dayBook: r },
          downstream: { reopened },
        };
      },
    ),

    C(
      'refusal.cheque-needs-bank',
      'T06',
      'refusal',
      'TR_SALE_ORD.cs:8988-8991: a cheque amount without a bank account is refused ("Please Select Bank Account And Try Because Chq Rec Amt <> 0") and writes nothing',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await enterOrder(page);
        await openDetails(page);
        await page.getByLabel('Cheque Amt', { exact: true }).fill('2000');
        const { response } = await trySave(page);
        assert.equal(response?.status(), 400, `answered ${response?.status()}`);
        await page.getByText('Please Select Bank Account', { exact: false }).waitFor();
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: 'refused with the desktop message',
          expected: 'refused, no write',
          database: { before },
        };
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

    C(
      'rollback.mid-write',
      'T14',
      'mutation',
      'TR_SALE_ORD writes the order header and lines, and with an advance its ledger and day-book legs. The desktop writes table by table with no transaction, so a fault leaves the earlier tables behind; the web must leave the whole tenant byte-for-byte as it was after a fault on any one write, take no order number, and then save normally from the same screen. The faulted tables must be exactly the tables a real save writes',
      async (ctx) => {
        const { page } = await ctx.session();
        await enterOrder(page, { advance: ADVANCE });
        const r = await rollbackMatrix(ctx, {
          tables: ORDER_WRITE_SET,
          book: BOOK,
          headerTable: 'SL_ORD_DATA',
          submit: () => save(page),
        });
        return {
          observation: `${r.attempts.map((a) => `${a.table} fault -> ${a.status}`).join(', ')}; every table of the tenant unchanged after each; then order ${r.vchNo} saved (201) with the expected number`,
          expected: { unchangedAfterEachFault: true, nextOrderNo: r.expectedNo },
          database: { attempts: r.attempts, orderNo: r.vchNo },
          downstream: {
            tablesWrittenBySuccessfulSave: r.written,
            pendingWhenTheFaultFired: Object.fromEntries(
              r.attempts.map((x) => [x.table, x.pendingElsewhere]),
            ),
          },
        };
      },
    ),
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
