import assert from 'node:assert/strict';
import {
  FIXTURE_MANIFEST,
  ITEMS,
  PARTIES,
  USERS,
  sentinelSnapshot,
} from '../fixtures/catalogue.mjs';
import { rollbackMatrix } from '../faults.mjs';

/**
 * Feature: Other → Order Cancel (desktop TR_SL_ORD_ADJ, opened with CurBookHelp('ORDER CANCEL'), MDI_FORM.cs:8628-8639;
 * web /txn/order-cancel).
 *
 * Expected values come from the desktop source, not from the web:
 * - Grid MSG (MSG_CLEAR, TR_SL_ORD_ADJ.cs:2140-2218): Sr, OrdNo, AcCode, Ac Name, It Desc, OrdAmt, AdjAmt, KsarAmt,
 *   PaidAmt, PaiidAc, Paid Ac Name; a new row's PaiidAc is the cash account (CommPassAdd :2255-2263).
 * - The OrdNo help lists the orders whose advance is not used up (:2499-2526); picking one puts the open advance in
 *   OrdAmt and AdjAmt (:2542-2560). PaidAmt = AdjAmt - KsarAmt (CommPassTotal :2447). Totals per column (:2220-2253).
 * - Save (:3410-3680): one SL_ORD_ADJ row per grid row with ENTRY_TYPE 'C', ORD_SIGN '-', ORD_AMT = AdjAmt,
 *   ORD_BAL_AMT = OrdAmt, PAID_AC/PAID_AMT/KASAR_AMT and the order key; TEMP_BOOK_DATA; Order_Adj_Ledr legs
 *   STR(SR_NO)+'01'/'02' for the refund and '03'/'04' for the kasar (Ac_Ledr.cs:928-937); Order_Adj_Rojmel the same
 *   without the cash account's own row (Ac_Rojmel.cs:392-400).
 * - Delete (:3726-3756): "Are You Sure To Delete This Voucher now?", then "Delete Success."; no DELETE_DATA row.
 * - Print (:3794-3849): OrderCancelVch, one receipt per grid row (report-specs/OrderCancelVch.spec.json).
 * - Year check (:3452-3457): "You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...".
 * The web refuses what the desktop does not check but would refund twice (more than the open advance, a kasar above
 * the adjusted amount); those texts are the web's own and the cases say so.
 */
const BOOK = 'ORC';
const ORDER_BOOK = 'SOR';
const CASH = 'CASH';
const KASAR = 'KASAR';
const BANK = PARTIES.bank;
const CUSTOMER = PARTIES.local;
const OTHER = PARTIES.interState;
const WRITE_SET = ['AC_DATA', 'ROJ_MEL_DATA', 'SL_ORD_ADJ', 'TEMP_BOOK_DATA'];
const OUT_OF_YEAR =
  'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const pad2 = (n) => String(n).padStart(2, '0');
const todayLocal = () => `${now.getFullYear()}-${pad2(now.getMonth() + 1)}-${pad2(now.getDate())}`;
const STR = (n) => String(n).padStart(10, ' ');
const RUN = Date.now().toString(36).slice(-6).toUpperCase();
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `order-cancel.${id}`,
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
const blocked = (name, group, source, reason) => ({
  ...C(`${name}.pending`, group, 'read-only', source, async () => ({})),
  blocked: reason,
});
const label = (page, text) => page.getByLabel(text, { exact: true });
const pathOf = (response) => new URL(response.url()).pathname;

// ───────────── the Sales Order screen makes the orders (the thing under test is never seeded) ─────────────
const LINE = {
  item: ITEMS.gold.code,
  pcs: '1',
  gross: '5',
  net: '5',
  touch: '100',
  rate: '1500',
  labour: '40',
};

async function createOrder(page, { customer = CUSTOMER.code, advance = 0, upi } = {}) {
  await page.goto('/txn/sales-order');
  await page.getByRole('heading', { name: 'Sales Order', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
  for (let i = 0; i < 50 && (await book.inputValue()) !== ORDER_BOOK; i++)
    await page.waitForTimeout(100);
  await page.waitForFunction(() => {
    const input = document.querySelector('[aria-label="Labour rate item 1"]');
    return input && !input.matches(':disabled');
  });
  const party = label(page, 'Customer account');
  await party.fill(customer);
  await party.locator('xpath=..').getByText(customer, { exact: true }).first().waitFor();
  await party.press('Enter');
  const item = label(page, 'Item code 1');
  await item.fill(LINE.item);
  await item.press('Escape');
  for (const [name, key] of [
    ['Pieces', 'pcs'],
    ['Gross weight', 'gross'],
    ['Net weight', 'net'],
    ['Touch', 'touch'],
    ['Rate', 'rate'],
    ['Labour rate', 'labour'],
  ])
    await label(page, `${name} item 1`).fill(LINE[key]);
  await label(page, 'Labour rate item 1').press('Tab');
  if (advance) await label(page, 'Advance ₹').fill(String(advance));
  if (upi) {
    const summary = page.getByText('Order details', { exact: true });
    if (!(await summary.locator('..').evaluate((element) => element.open))) await summary.click();
    await label(page, 'Cash A/c').fill(CASH);
    if (!(await label(page, 'UPI AcCode line 1').count()))
      await page.getByRole('button', { name: '+ Add UPI row', exact: true }).click();
    await label(page, 'UPI AcCode line 1').fill(BANK.code);
    await label(page, 'UPI Type line 1').fill('GPAY');
    await label(page, 'UPI Id line 1').fill(`OC${RUN}${Math.random().toString(36).slice(2, 7)}`);
    await label(page, 'UPI Amt line 1').fill(String(upi));
  }
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => pathOf(r) === '/api/sales-orders' && r.request().method() === 'POST',
    ),
    page.getByRole('button', { name: 'Save Sales Order', exact: true }).click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return String((await response.json()).vchNo).padStart(5, '0');
}

// ───────────── the Order Cancel screen ─────────────
async function openCancel(page) {
  await page.goto('/txn/order-cancel');
  await page.getByRole('heading', { name: 'Order Cancel', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned ORDER CANCEL book is selected');
  // A new row's PaiidAc comes from the book (slot 1).
  for (let i = 0; i < 50 && (await label(page, 'PaiidAc row 1').inputValue()) !== CASH; i++)
    await page.waitForTimeout(100);
  return book;
}

/** Enter on the OrdNo cell opens the pending-order help; typing the number and Enter picks it. */
async function pickOrder(page, row, ordNo) {
  const cell = label(page, `OrdNo row ${row}`);
  const [list] = await Promise.all([
    page.waitForResponse((r) => pathOf(r) === '/api/order-cancel/pending-orders'),
    cell.press('Enter'),
  ]);
  assert.equal(list.status(), 200, await list.text());
  const help = page.getByRole('dialog', { name: 'Pending orders' });
  await help.waitFor();
  await label(page, 'Search pending orders').fill(ordNo);
  await help.locator(`tr[data-order="${ordNo}"]`).first().waitFor();
  await label(page, 'Search pending orders').press('Enter');
  await help.waitFor({ state: 'detached' });
  assert.equal(await cell.inputValue(), ordNo);
}

async function setAmount(page, name, row, value) {
  const input = label(page, `${name} row ${row}`);
  await input.fill(String(value));
  await input.press('Tab');
}

async function setPaidAc(page, row, code) {
  const input = label(page, `PaiidAc row ${row}`);
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
  await page.getByLabel(`Paid Ac Name row ${row}`).filter({ hasText: /\S/ }).waitFor();
}

async function addRow(page) {
  await page.getByRole('button', { name: '+ Add line', exact: true }).click();
}

async function fillRow(page, row, { ordNo, desc, adj, kasar, paidAc }) {
  if (row > 1 && !(await label(page, `OrdNo row ${row}`).count())) await addRow(page);
  await pickOrder(page, row, ordNo);
  if (desc !== undefined) await label(page, `It Desc row ${row}`).fill(desc);
  if (adj !== undefined) await setAmount(page, 'AdjAmt', row, adj);
  if (kasar !== undefined) await setAmount(page, 'KsarAmt', row, kasar);
  if (paidAc) await setPaidAc(page, row, paidAc);
}

async function save(page, method = 'POST') {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        r.request().method() === method &&
        (method === 'POST'
          ? pathOf(r) === '/api/order-cancel'
          : /^\/api\/order-cancel\/\d+$/.test(pathOf(r))),
    ),
    page.locator('button[data-save-mnemonic]').click(),
  ]);
  return response;
}

async function create(page, rows) {
  await openCancel(page);
  for (const [i, row] of rows.entries()) await fillRow(page, i + 1, row);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  const { vchNo } = await response.json();
  await page.getByText(`Posted — Order Cancel #${vchNo}`).waitFor();
  return String(vchNo).padStart(5, '0');
}

async function load(page, vchNo) {
  const box = page.locator('#order-cancel-vch-no');
  await box.fill(vchNo);
  const [response] = await Promise.all([
    page.waitForResponse((r) => pathOf(r) === `/api/order-cancel/${vchNo}`),
    box.press('Enter'),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.getByRole('button', { name: `Update #${vchNo}`, exact: true }).waitFor();
}

// ───────────── database reads ─────────────
const adjRows = (ctx, vchNo) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"ORD_NO" ord,"AC_CODE" ac,"ENTRY_TYPE" entry,"ORD_SIGN" sign,"VCH_TYPE" vtype,
            "BOOK_NAME" book,"ORD_YRCD" yr,"ORD_DBCD" ordbook,"ORD_LC" lc,"ORD_AC_CODE" ordac,
            "ORD_AMT"::float adj,"ORD_BAL_AMT"::float bal,"KASAR_AMT"::float kasar,"PAID_AMT"::float paid,
            "PAID_AC" paidac,coalesce("IT_DESC",'') "desc",btrim("MAIN_USER") mainuser,"HD_VCH_NO" hidden
       FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    vchNo,
  );
const ledger = (ctx, vchNo) =>
  ctx.rows(
    `SELECT right("LEDR_KEY",12) tail,length("LEDR_KEY")::int len,btrim("AC_CODE") ac,btrim("LD_CODE") ld,
            "DR_AMT"::float dr,"CR_AMT"::float cr,coalesce("IT_DESC",'') "desc",btrim("PARTY_AC_CODE") party
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    vchNo,
  );
const dayBook = (ctx, vchNo) =>
  ctx.rows(
    `SELECT substr("LEDR_KEY",22,2) type,btrim(substr("LEDR_KEY",24)) line,btrim("AC_CODE") ac,
            "DR_AMT"::float dr,"CR_AMT"::float cr,"AC_NAME" name
       FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    vchNo,
  );
const counts = async (ctx) =>
  (
    await ctx.rows(
      `SELECT (SELECT count(*) FROM "SL_ORD_ADJ" WHERE tenant_id=$1)::int adj,
              (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int ledger,
              (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int rojmel,
              (SELECT count(*) FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int hidden`,
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
const pendingOf = (page) =>
  page.evaluate(async () => {
    const r = await fetch('/api/order-cancel/pending-orders?coBook=ORC', {
      credentials: 'include',
    });
    return r.json();
  });
const browserFetch = (page, method, url, body) =>
  page.evaluate(
    async ({ m, u, b }) => {
      const response = await fetch(u, {
        method: m,
        credentials: 'include',
        headers: b ? { 'content-type': 'application/json' } : {},
        body: b ? JSON.stringify(b) : undefined,
      });
      return { status: response.status, body: await response.text() };
    },
    { m: method, u: url, b: body },
  );
const yearOf = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "CO_YEAR" y FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${ORDER_BOOK}' ORDER BY row_id DESC LIMIT 1`,
    )
  )[0]?.y;

export const orderCancel = {
  feature: 'order-cancel',
  title: 'Other → Order Cancel (TR_SL_ORD_ADJ, ORDER CANCEL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/order-cancel/page.tsx',
    'web/apps/web/components/OrderCancelGridRow.tsx',
    'web/apps/web/components/OrderCancelOrderHelp.tsx',
    'web/apps/api/src/modules/sales/orderCancel.ts',
    'web/apps/api/src/modules/sales/orderCancelTags.ts',
    'web/apps/api/src/modules/sales/orderCancelPrint.ts',
    'web/apps/api/src/routes/orderCancel.ts',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
    'web/apps/web/test/features/modules/orderCancel.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.book-grid-and-defaults',
      'T01',
      'read-only',
      "MDI_FORM.cs:8628-8639 opens CurBookHelp('ORDER CANCEL'); MSG_CLEAR (TR_SL_ORD_ADJ.cs:2140-2218) shows Sr, OrdNo, AcCode, Ac Name, It Desc, OrdAmt, AdjAmt, KsarAmt, PaidAmt, PaiidAc, Paid Ac Name; CommPassAdd (:2255-2263) puts the cash account in a new row's PaiidAc; CLEAR_DATA (:3125-3127) shows today's date and its day.",
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/');
        await page.getByRole('link', { name: 'Order Cancel', exact: true }).first().click();
        await page.waitForURL('**/txn/order-cancel');
        const book = await openCancel(page);
        const books = await book
          .locator('option')
          .evaluateAll((options) => options.map((o) => o.getAttribute('value')).filter(Boolean));
        assert.deepEqual(books, [BOOK], 'only the ORDER CANCEL book is offered');
        const headers = await page
          .getByRole('table', { name: 'Orders to cancel' })
          .locator('thead th')
          .allTextContents();
        assert.deepEqual(headers, [
          'Sr',
          'OrdNo',
          'AcCode',
          'Ac Name',
          'It Desc',
          'OrdAmt',
          'AdjAmt',
          'KsarAmt',
          'PaidAmt',
          'PaiidAc',
          'Paid Ac Name',
        ]);
        assert.equal(await label(page, 'PaiidAc row 1').inputValue(), CASH);
        assert.equal(await page.getByLabel('Paid Ac Name row 1').textContent(), 'CASH ON HAND');
        assert.equal(await page.locator('#order-cancel-date').inputValue(), todayLocal());
        const day = new Date(`${todayLocal()}T00:00:00`).toLocaleDateString('en-GB', {
          weekday: 'long',
        });
        assert.equal(await page.locator('#order-cancel-day').inputValue(), day);
        assert.ok(await page.locator('button[data-save-mnemonic]').isDisabled());
        assert.equal(await page.locator('button.primary').count(), 1, 'Save is the only primary');
        await ctx.shot(page, 'entry');
        return {
          observation: `book ${books.join('/')}; columns ${headers.join(', ')}; PaiidAc CASH / CASH ON HAND; ${day}; Save disabled`,
          expected:
            'ORDER CANCEL book only, the desktop grid columns, cash PaiidAc, today, disabled Save',
        };
      },
    ),
    C(
      'route.date-and-description',
      'T02',
      'mutation',
      'mVchDate (:3527 VCH_DATE, VCH_TIME = date + time) and the It Desc cell (:3577 IT_DESC, 150 characters, :2324-2327) reach SL_ORD_ADJ, the day book (Ac_Rojmel.cs:392 A.IT_DESC) and the reopened voucher; AC_DATA keeps IT_DESC blank (Ac_Ledr.cs:928).',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 610 });
        const date = `${startYear}-04-01`;
        await openCancel(page);
        await page.locator('#order-cancel-date').fill(date);
        await pickOrder(page, 1, ordNo);
        const desc = `ROUTE ${RUN} ${'x'.repeat(130)}`.slice(0, 150);
        await label(page, 'It Desc row 1').fill(`${desc}OVERFLOW`);
        assert.equal(
          await label(page, 'It Desc row 1').inputValue(),
          desc,
          'the cell takes 150 characters',
        );
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [row] = await ctx.rows(
          `SELECT "VCH_DATE"::date::text d,"VCH_TIME"::date::text t,"IT_DESC" "desc" FROM "SL_ORD_ADJ"
            WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.deepEqual(row, { d: date, t: date, desc });
        const days = await dayBook(ctx, vchNo);
        const legs = await ledger(ctx, vchNo);
        assert.ok(legs.every((l) => l.desc === ''));
        await load(page, vchNo);
        assert.equal(await page.locator('#order-cancel-date').inputValue(), date);
        assert.equal(await label(page, 'It Desc row 1').inputValue(), desc);
        return {
          observation: `voucher ${vchNo}: date ${date} and a 150-character description saved, shown in the day book and reopened`,
          expected: { date, descLength: 150 },
          database: { row, days: days.length },
          downstream: { reopened: true },
        };
      },
    ),
    C(
      'formula.paid-is-adj-less-kasar',
      'T03',
      'mutation',
      'Picking the order puts the open advance in OrdAmt and AdjAmt (:2542-2560); PaidAmt = AdjAmt - KsarAmt (CommPassTotal :2447); MSG_TOT_FILL sums each amount column (:2220-2253). Order advance 5,000 cash; AdjAmt 4,000, KsarAmt 150 -> PaidAmt 3,850; saved ORD_AMT 4,000, ORD_BAL_AMT 5,000, KASAR 150, PAID 3,850.',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 5000 });
        await openCancel(page);
        await pickOrder(page, 1, ordNo);
        const picked = {
          ac: await page.getByLabel('AcCode row 1').textContent(),
          ord: await page.getByLabel('OrdAmt row 1').textContent(),
          adj: await label(page, 'AdjAmt row 1').inputValue(),
          paid: await page.getByLabel('PaidAmt row 1').textContent(),
        };
        assert.deepEqual(picked, {
          ac: CUSTOMER.code,
          ord: '5000.00',
          adj: '5000.00',
          paid: '5000.00',
        });
        await setAmount(page, 'AdjAmt', 1, 4000);
        await setAmount(page, 'KsarAmt', 1, 150);
        assert.equal(await page.getByLabel('PaidAmt row 1').textContent(), '3850.00');
        const totals = {};
        for (const k of ['OrdAmt', 'AdjAmt', 'KsarAmt', 'PaidAmt'])
          totals[k] = await page.getByLabel(`${k} total`).textContent();
        assert.deepEqual(totals, {
          OrdAmt: '5000.00',
          AdjAmt: '4000.00',
          KsarAmt: '150.00',
          PaidAmt: '3850.00',
        });
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [row] = await adjRows(ctx, vchNo);
        assert.deepEqual(
          [row.adj, row.bal, row.kasar, row.paid, row.paidac],
          [4000, 5000, 150, 3850, CASH],
        );
        const legs = await ledger(ctx, vchNo);
        assert.deepEqual(
          legs.map((l) => [l.tail, l.ac, l.ld, l.dr, l.cr]),
          [
            [`${STR(1)}01`, CUSTOMER.code, CASH, 3850, 0],
            [`${STR(1)}02`, CASH, CUSTOMER.code, 0, 3850],
            [`${STR(1)}03`, CUSTOMER.code, KASAR, 150, 0],
            [`${STR(1)}04`, KASAR, CUSTOMER.code, 0, 150],
          ],
        );
        const open = (await pendingOf(page)).find((o) => o.ordNo === ordNo);
        assert.equal(open?.openAmt, 1000, '1,000 of the advance is still open');
        return {
          observation: `order ${ordNo} -> cancel ${vchNo}: AdjAmt 4000, KsarAmt 150, PaidAmt 3850; ledger ${legs.length} legs; 1000 left open`,
          expected: { paid: 3850, ordBal: 5000, legs: '01/02/03/04', open: 1000 },
          database: { row, legs },
          downstream: { openAdvance: open?.openAmt },
        };
      },
    ),
    C(
      'lookup.pending-orders-help',
      'T04',
      'read-only',
      'The OrdNo help lists PartyName, AcCode, VchNo, OrderDt, Amount (ADV_AMT) and AdjAmt (what is used) for the orders with advance still open, by date and number (:2499-2526); an order with nothing open is not offered; Esc leaves the cell as it was.',
      async (ctx) => {
        const { page } = await ctx.session();
        const open = await createOrder(page, { customer: OTHER.code, advance: 2500 });
        const none = await createOrder(page, { customer: OTHER.code, advance: 0 });
        await openCancel(page);
        await label(page, 'OrdNo row 1').press('F1');
        const help = page.getByRole('dialog', { name: 'Pending orders' });
        await help.waitFor();
        const headers = await help.locator('thead th').allTextContents();
        assert.deepEqual(headers, [
          'Party Name',
          'AcCode',
          'VchNo',
          'Order Dt',
          'Amount',
          'AdjAmt',
        ]);
        await label(page, 'Search pending orders').fill(OTHER.code);
        const listed = await help
          .locator('tbody tr')
          .evaluateAll((rows) => rows.map((r) => r.getAttribute('data-order')));
        assert.ok(listed.includes(open), `order ${open} is offered`);
        assert.ok(!listed.includes(none), `order ${none} without advance is not offered`);
        const cells = await help.locator(`tr[data-order="${open}"] td`).allTextContents();
        assert.deepEqual(
          [cells[0], cells[1], cells[2], cells[4], cells[5]],
          [OTHER.name, OTHER.code, open, '2500.00', '0.00'],
        );
        await label(page, 'Search pending orders').press('Escape');
        await help.waitFor({ state: 'detached' });
        assert.equal(await label(page, 'OrdNo row 1').inputValue(), '');
        assert.equal(await page.getByLabel('AcCode row 1').textContent(), '');
        return {
          observation: `help columns ${headers.join('/')}; ${open} listed with 2500.00/0.00; ${none} not listed; Esc left the row blank`,
          expected: 'desktop help columns, only orders with open advance, Esc cancels',
        };
      },
    ),
    C(
      'children.two-orders-cash-and-bank',
      'T05',
      'mutation',
      'One voucher, two grid rows (:3527-3585): SR_NO 1 and 2, each its own order key; row 1 refunds through cash, row 2 through the bank. Order_Adj_Ledr keys STR(SR_NO)+leg (Ac_Ledr.cs:928); Order_Adj_Rojmel leaves out the cash account row 02 and keeps the bank row 02 (Ac_Rojmel.cs:394). A third row removed with Ctrl+D is not saved.',
      async (ctx) => {
        const { page } = await ctx.session();
        const first = await createOrder(page, { advance: 1200 });
        const second = await createOrder(page, { customer: OTHER.code, advance: 800 });
        const third = await createOrder(page, { advance: 300 });
        await openCancel(page);
        await fillRow(page, 1, { ordNo: first, desc: 'first order' });
        await fillRow(page, 2, { ordNo: second, paidAc: BANK.code, desc: 'second order' });
        await fillRow(page, 3, { ordNo: third });
        page.once('dialog', (dialog) => {
          assert.equal(dialog.message(), 'This Row Record will Removed permantley ?');
          void dialog.accept();
        });
        await label(page, 'OrdNo row 3').press('Control+d');
        await label(page, 'OrdNo row 3').waitFor({ state: 'detached' });
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const rows = await adjRows(ctx, vchNo);
        assert.deepEqual(
          rows.map((r) => [r.sr, r.ord, r.ac, r.adj, r.paid, r.paidac, r.desc]),
          [
            [1, first, CUSTOMER.code, 1200, 1200, CASH, 'first order'],
            [2, second, OTHER.code, 800, 800, BANK.code, 'second order'],
          ],
        );
        assert.equal(rows[0].hidden, rows[1].hidden, 'one hidden number for the voucher');
        const legs = await ledger(ctx, vchNo);
        assert.deepEqual(
          legs.map((l) => [l.tail, l.ac, l.dr, l.cr]),
          [
            [`${STR(1)}01`, CUSTOMER.code, 1200, 0],
            [`${STR(1)}02`, CASH, 0, 1200],
            [`${STR(2)}01`, OTHER.code, 800, 0],
            [`${STR(2)}02`, BANK.code, 0, 800],
          ],
        );
        const days = await dayBook(ctx, vchNo);
        assert.deepEqual(
          days.map((d) => [d.type, d.line, d.ac, d.dr, d.cr]),
          [
            ['01', '1', CUSTOMER.code, 1200, 0],
            ['01', '2', OTHER.code, 800, 0],
            ['02', '2', BANK.code, 0, 800],
          ],
        );
        const third300 = (await pendingOf(page)).find((o) => o.ordNo === third);
        assert.equal(third300?.openAmt, 300, 'the removed row cancelled nothing');
        return {
          observation: `voucher ${vchNo}: rows ${rows.map((r) => r.ord).join(', ')}; ledger ${legs.length} legs; day book ${days.map((d) => d.type).join('/')}`,
          expected:
            'two SL_ORD_ADJ rows, 4 legs, day book 01/01/02 (bank only), third order untouched',
          database: { rows, legs, days },
          downstream: { thirdOrderOpen: third300?.openAmt },
        };
      },
    ),
    C(
      'refusal.more-than-open-advance',
      'T06',
      'refusal',
      'The desktop checks no bound on AdjAmt (TEXT_ENTRY_KeyDown :2729-2736 only refuses 0). Taking more than the open advance would refund money twice, so the web refuses it before any write (web text). Also a zero AdjAmt keeps the focus in the cell (:2733).',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 700 });
        const before = await counts(ctx);
        await openCancel(page);
        await pickOrder(page, 1, ordNo);
        const adj = label(page, 'AdjAmt row 1');
        await adj.fill('0');
        await adj.press('Enter');
        assert.ok(
          await adj.evaluate((el) => el === document.activeElement),
          'Enter on 0 stays in AdjAmt',
        );
        await setAmount(page, 'AdjAmt', 1, 700.01);
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        const message = `Row 1 (order ${ordNo}): 700.01 was asked for but only 700.00 open advance is left on this order.`;
        await page.getByRole('alert').filter({ hasText: message }).waitFor();
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `700.01 against 700.00 refused: "${message}"; nothing written`,
          expected: 'refused, no write',
          database: { before, after: await counts(ctx) },
        };
      },
    ),
    C(
      'refusal.kasar-above-adjusted',
      'T06',
      'refusal',
      'PaidAmt = AdjAmt - KsarAmt (:2447); a KsarAmt above AdjAmt makes PaidAmt negative and Order_Adj_Ledr would post a negative refund. The web refuses it (web text) and writes nothing.',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 600 });
        const before = await counts(ctx);
        await openCancel(page);
        await pickOrder(page, 1, ordNo);
        await setAmount(page, 'KsarAmt', 1, 650);
        assert.equal(await page.getByLabel('PaidAmt row 1').textContent(), '-50.00');
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        const message = `Row 1 (order ${ordNo}): Kasar and Paid amounts cannot be negative.`;
        await page.getByRole('alert').filter({ hasText: message }).waitFor();
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `KsarAmt 650 on AdjAmt 600 refused: "${message}"`,
          expected: 'refused, no write',
          database: { before, after: await counts(ctx) },
        };
      },
    ),
    C(
      'refusal.date-outside-year',
      'T06',
      'refusal',
      `TR_SL_ORD_ADJ.cs:3452-3457: "${OUT_OF_YEAR}" and nothing is saved.`,
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 400 });
        const before = await counts(ctx);
        await openCancel(page);
        await page.locator('#order-cancel-date').fill(`${startYear - 1}-12-31`);
        await pickOrder(page, 1, ordNo);
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        await page.getByRole('alert').filter({ hasText: OUT_OF_YEAR }).waitFor();
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: 'a date before the year refused with the desktop text; nothing written',
          expected: OUT_OF_YEAR,
          database: { before, after: await counts(ctx) },
        };
      },
    ),
    C(
      'refusal.already-cancelled-order',
      'T06',
      'refusal',
      'An order whose advance is fully cancelled is no longer in the help (:2499-2526, HAVING ... > 0). A request that still names it (an old page, a replay) is refused by the server and writes nothing.',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 450 });
        await create(page, [{ ordNo }]);
        assert.equal(
          (await pendingOf(page)).find((o) => o.ordNo === ordNo),
          undefined,
          'not pending any more',
        );
        const before = await counts(ctx);
        const year = await yearOf(ctx);
        const answer = await browserFetch(page, 'POST', '/api/order-cancel', {
          coBook: BOOK,
          vchDate: todayLocal(),
          rows: [{ ordNo, ordYear: year, ordBook: ORDER_BOOK, adjAmt: 450, kasarAmt: 0 }],
        });
        assert.equal(answer.status, 400, answer.body);
        assert.match(JSON.parse(answer.body).message, /only 0\.00 open advance is left/);
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `order ${ordNo} cancelled once; a second cancel of it answered 400 "${JSON.parse(answer.body).message}"`,
          expected: 'not offered, refused, no write',
          database: { before, after: await counts(ctx) },
        };
      },
    ),
    C(
      'create.write-set',
      'T07',
      'mutation',
      'Save (:3527-3585, Ac_Ledr.cs:928-937, Ac_Rojmel.cs:392-400): SL_ORD_ADJ ENTRY_TYPE C, ORD_SIGN -, VCH_TYPE SADJ, BOOK_NAME ORDER CANCEL, the order key (ORD_NO/ORD_LC/ORD_YRCD/ORD_DBCD/ORD_AC_CODE), MAIN_USER the operator; AC_DATA 33-character keys, IT_DESC blank, PARTY_AC_CODE the customer, balanced; ROJ_MEL_DATA: no cash row 02, kasar rows named "KSR - " + party; one TEMP_BOOK_DATA row. Exactly these four tables change.',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 2000 });
        const year = await yearOf(ctx);
        const before = await counts(ctx);
        const vchNo = await create(page, [
          { ordNo, adj: 2000, kasar: 125, desc: 'cancelled at counter' },
        ]);
        const [row] = await adjRows(ctx, vchNo);
        assert.deepEqual(
          { ...row, hidden: undefined },
          {
            sr: 1,
            ord: ordNo,
            ac: CUSTOMER.code,
            entry: 'C',
            sign: '-',
            vtype: 'SADJ',
            book: 'ORDER CANCEL',
            yr: year,
            ordbook: ORDER_BOOK,
            lc: '01',
            ordac: CUSTOMER.code,
            adj: 2000,
            bal: 2000,
            kasar: 125,
            paid: 1875,
            paidac: CASH,
            desc: 'cancelled at counter',
            mainuser: USERS.admin.user,
            hidden: undefined,
          },
        );
        const legs = await ledger(ctx, vchNo);
        assert.ok(legs.every((l) => l.len === 33 && l.desc === '' && l.party === CUSTOMER.code));
        assert.equal(
          legs.reduce((s, l) => s + l.dr - l.cr, 0),
          0,
          'balanced',
        );
        const days = await dayBook(ctx, vchNo);
        assert.deepEqual(
          days.map((d) => [d.type, d.ac, d.dr, d.cr, d.name]),
          [
            ['01', CUSTOMER.code, 1875, 0, CUSTOMER.name],
            ['03', CUSTOMER.code, 125, 0, `KSR - ${CUSTOMER.name}`],
            ['04', KASAR, 0, 125, `KSR - ${CUSTOMER.name}`],
          ],
        );
        const after = await counts(ctx);
        assert.deepEqual(
          {
            adj: after.adj - before.adj,
            ledger: after.ledger - before.ledger,
            rojmel: after.rojmel - before.rojmel,
            hidden: after.hidden - before.hidden,
          },
          { adj: 1, ledger: 4, rojmel: 3, hidden: 1 },
        );
        return {
          observation: `voucher ${vchNo}: SL_ORD_ADJ 1, AC_DATA 4, ROJ_MEL_DATA 3, TEMP_BOOK_DATA 1`,
          expected: 'the desktop write set',
          database: { row, legs, days },
          downstream: { customerBalance: await balance(ctx, CUSTOMER.code) },
        };
      },
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      'DISPLAY_DATA (:3184-3326) shows the saved grid (OrdAmt from ORD_BAL_AMT, AdjAmt from ORD_AMT, KsarAmt, PaidAmt, PaiidAc and its name); saving it unchanged rebuilds the same rows (:3504-3680) and keeps the number and the hidden number.',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 900 });
        const vchNo = await create(page, [
          { ordNo, adj: 900, kasar: 40, paidAc: BANK.code, desc: 'reopen me' },
        ]);
        const strip = (rows) => rows.map(({ hidden, ...r }) => r);
        const before = {
          adj: await adjRows(ctx, vchNo),
          legs: await ledger(ctx, vchNo),
          days: await dayBook(ctx, vchNo),
        };
        await load(page, vchNo);
        const shown = {
          ord: await label(page, 'OrdNo row 1').inputValue(),
          ordAmt: await page.getByLabel('OrdAmt row 1').textContent(),
          adj: await label(page, 'AdjAmt row 1').inputValue(),
          kasar: await label(page, 'KsarAmt row 1').inputValue(),
          paid: await page.getByLabel('PaidAmt row 1').textContent(),
          paidAc: await label(page, 'PaiidAc row 1').inputValue(),
          paidName: await page.getByLabel('Paid Ac Name row 1').textContent(),
          desc: await label(page, 'It Desc row 1').inputValue(),
        };
        assert.deepEqual(shown, {
          ord: ordNo,
          ordAmt: '900.00',
          adj: '900.00',
          kasar: '40.00',
          paid: '860.00',
          paidAc: BANK.code,
          paidName: BANK.name,
          desc: 'reopen me',
        });
        const response = await save(page, 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const after = {
          adj: await adjRows(ctx, vchNo),
          legs: await ledger(ctx, vchNo),
          days: await dayBook(ctx, vchNo),
        };
        assert.deepEqual(strip(after.adj), strip(before.adj));
        assert.equal(after.adj[0].hidden, before.adj[0].hidden, 'hidden number kept');
        assert.deepEqual(after.legs, before.legs);
        assert.deepEqual(after.days, before.days);
        return {
          observation: `voucher ${vchNo} reopened as saved and saved unchanged: rows, legs and day book identical`,
          expected: 'no change',
          database: { before, after },
          downstream: { hidden: after.adj[0].hidden },
        };
      },
    ),
    C(
      'edit.kasar-change',
      'T09',
      'mutation',
      'Edit (:3504-3680 with EntryMode E): the voucher keeps its number, hidden number and MAIN_USER; its rows and legs are rebuilt from the new grid; other vouchers do not change.',
      async (ctx) => {
        const { page } = await ctx.session();
        const a = await createOrder(page, { advance: 1000 });
        const b = await createOrder(page, { advance: 500 });
        const other = await create(page, [{ ordNo: b }]);
        const otherBefore = await ledger(ctx, other);
        const vchNo = await create(page, [{ ordNo: a, kasar: 0 }]);
        await load(page, vchNo);
        await setAmount(page, 'KsarAmt', 1, 75);
        const response = await save(page, 'PUT');
        assert.equal(response.status(), 200, await response.text());
        const [row] = await adjRows(ctx, vchNo);
        assert.deepEqual(
          [row.adj, row.kasar, row.paid, row.mainuser],
          [1000, 75, 925, USERS.admin.user],
        );
        const legs = await ledger(ctx, vchNo);
        assert.deepEqual(
          legs.map((l) => [l.ac, l.dr, l.cr]),
          [
            [CUSTOMER.code, 925, 0],
            [CASH, 0, 925],
            [CUSTOMER.code, 75, 0],
            [KASAR, 0, 75],
          ],
        );
        assert.deepEqual(await ledger(ctx, other), otherBefore, 'the other voucher is untouched');
        return {
          observation: `voucher ${vchNo}: kasar 0 -> 75, paid 1000 -> 925, legs rebuilt; voucher ${other} untouched`,
          expected: { kasar: 75, paid: 925 },
          database: { row, legs },
          downstream: { otherVoucher: otherBefore.length },
        };
      },
    ),
    C(
      'delete.order-pending-again',
      'T10',
      'mutation',
      'BtnDelete_Click (:3726-3756): "Are You Sure To Delete This Voucher now?", then the hidden number, AC_DATA, ROJ_MEL_DATA, MAIN_STOCK, SL_ORD_ADJ, APR_DETL, BAR_DETL, BAR_IDTL rows go and "Delete Success." shows; no DELETE_DATA row. The order is pending again with its whole advance.',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 650 });
        const vchNo = await create(page, [{ ordNo, kasar: 50 }]);
        assert.equal(
          (await pendingOf(page)).find((o) => o.ordNo === ordNo),
          undefined,
        );
        await load(page, vchNo);
        page.once('dialog', (dialog) => {
          assert.equal(dialog.message(), 'Are You Sure To Delete This Voucher now?');
          void dialog.accept();
        });
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'DELETE' && pathOf(r) === `/api/order-cancel/${vchNo}`,
          ),
          page.getByRole('button', { name: 'Delete', exact: true }).click(),
        ]);
        assert.equal(response.status(), 200, await response.text());
        await page.getByRole('status').filter({ hasText: 'Delete Success.' }).waitFor();
        const left = await ctx.rows(
          `SELECT (SELECT count(*) FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2)::int adj,
                  (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2)::int ledger,
                  (SELECT count(*) FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2)::int rojmel,
                  (SELECT count(*) FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int audit`,
          vchNo,
        );
        assert.deepEqual(left, [{ adj: 0, ledger: 0, rojmel: 0, audit: 0 }]);
        const again = (await pendingOf(page)).find((o) => o.ordNo === ordNo);
        assert.equal(again?.openAmt, 650);
        return {
          observation: `voucher ${vchNo} deleted; no rows left, no DELETE_DATA; order ${ordNo} pending with 650 again`,
          expected: 'Delete Success. and the order pending again',
          database: left[0],
          downstream: { openAdvance: again?.openAmt },
        };
      },
    ),
    C(
      'scope.other-family-book-and-tenant',
      'T11',
      'refusal',
      "CurBookHelp('ORDER CANCEL') (MDI_FORM.cs:8629) offers only that family's books: a request on the Sales Order book is refused; the second tenant's same-numbered voucher stays as it was; a user without the Order Cancel right is turned away.",
      async (ctx) => {
        const { page } = await ctx.session();
        const sentinelBefore = await sentinelSnapshot(ctx.owner);
        const before = await counts(ctx);
        const wrongBook = await browserFetch(page, 'POST', '/api/order-cancel', {
          coBook: ORDER_BOOK,
          vchDate: todayLocal(),
          rows: [{ ordNo: '00001', adjAmt: 1, kasarAmt: 0 }],
        });
        assert.equal(wrongBook.status, 400, wrongBook.body);
        assert.match(JSON.parse(wrongBook.body).message, /MAIN_BOOK='ORDER CANCEL'/);
        const clerk = await ctx.session(as(USERS.clerk.user));
        await clerk.page.goto('/');
        const denied = await browserFetch(
          clerk.page,
          'GET',
          `/api/order-cancel/pending-orders?coBook=${BOOK}`,
        );
        assert.equal(denied.status, 403, denied.body);
        assert.deepEqual(await counts(ctx), before);
        assert.deepEqual(await sentinelSnapshot(ctx.owner), sentinelBefore);
        return {
          observation: `SOR book -> 400; clerk -> ${denied.status}; counts and the other tenant unchanged`,
          expected: 'refused, nothing written, nothing leaked',
          database: { before, after: await counts(ctx) },
        };
      },
    ),
    C(
      'concurrency.stale-version',
      'T12',
      'refusal',
      "Two operators open the same voucher; the first saves; the second one's save and delete carry the old version and are refused with 409 before anything changes (N51 version tokens; the desktop has no such guard).",
      async (ctx) => {
        const one = await ctx.session();
        const ordNo = await createOrder(one.page, { advance: 820 });
        const vchNo = await create(one.page, [{ ordNo }]);
        const two = await ctx.session();
        await openCancel(two.page);
        await load(two.page, vchNo);
        await load(one.page, vchNo);
        await setAmount(one.page, 'KsarAmt', 1, 20);
        assert.equal((await save(one.page, 'PUT')).status(), 200);
        const before = await adjRows(ctx, vchNo);
        await setAmount(two.page, 'KsarAmt', 1, 30);
        const stale = await save(two.page, 'PUT');
        assert.equal(stale.status(), 409, await stale.text());
        await two.page
          .getByRole('alert')
          .filter({ hasText: 'This voucher was changed by someone else after you opened it.' })
          .waitFor();
        two.page.once('dialog', (dialog) => void dialog.accept());
        const [gone] = await Promise.all([
          two.page.waitForResponse((r) => r.request().method() === 'DELETE'),
          two.page.getByRole('button', { name: 'Delete', exact: true }).click(),
        ]);
        assert.equal(gone.status(), 409);
        assert.deepEqual(await adjRows(ctx, vchNo), before);
        return {
          observation: `stale save and stale delete of ${vchNo} answered 409; the first save (kasar 20) stands`,
          expected: '409, no change',
          database: { rows: before },
        };
      },
    ),
    C(
      'retry.double-click-one-voucher',
      'T13',
      'mutation',
      'A double click on Save must make one voucher: the button is disabled while the save runs (the desktop disables BtnSave at :3451).',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 330 });
        await openCancel(page);
        await pickOrder(page, 1, ordNo);
        const before = await counts(ctx);
        await page.locator('button[data-save-mnemonic]').dblclick();
        await page.getByText(/Posted — Order Cancel #\d+/).waitFor();
        const after = await counts(ctx);
        assert.equal(after.adj - before.adj, 1, 'one SL_ORD_ADJ row');
        assert.equal(after.hidden - before.hidden, 1, 'one hidden number');
        return {
          observation: 'double click -> one voucher',
          expected: 'one voucher',
          database: { before, after },
          downstream: {
            openAdvance: (await pendingOf(page)).find((o) => o.ordNo === ordNo)?.openAmt ?? 0,
          },
        };
      },
    ),
    blocked(
      'retry.lost-acknowledgement',
      'T13',
      'Playbook T13: a lost acknowledgement after commit must give one durable result',
      'POST /order-cancel has no Idempotency-Key guard yet: the WP-04 mechanism (PR #229) is not on main. The double-click case above passes; a replayed request after a lost answer is a second voucher until the route is guarded (WP-04 follow-up queue).',
    ),
    C(
      'rollback.mid-write',
      'T14',
      'mutation',
      'The desktop writes SL_ORD_ADJ, TEMP_BOOK_DATA, AC_DATA and ROJ_MEL_DATA one by one with no transaction (:3504-3680); the web must leave the tenant exactly as it was after a fault on any one of them, take no number, then save from the same screen.',
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { advance: 1500 });
        await openCancel(page);
        await pickOrder(page, 1, ordNo);
        await setAmount(page, 'KsarAmt', 1, 10);
        const r = await rollbackMatrix(ctx, {
          tables: WRITE_SET,
          book: BOOK,
          headerTable: 'SL_ORD_ADJ',
          submit: () => save(page),
        });
        return {
          observation: `${r.attempts.map((a) => `${a.table} fault -> ${a.status}`).join(', ')}; tenant unchanged after each; then voucher ${r.vchNo} saved with the expected number`,
          expected: { unchangedAfterEachFault: true, nextNo: r.expectedNo },
          database: { attempts: r.attempts, vchNo: r.vchNo },
          downstream: { written: r.written },
        };
      },
    ),
    C(
      'history.reopen-after-party-rename',
      'T15',
      'mutation',
      "DISPLAY_DATA shows SL_ORD_ADJ.AC_NAME as saved (:3216-3217), not the account master's current name; the print uses the same column ({SL_ORD_ADJ.AC_NAME}).",
      async (ctx) => {
        const { page } = await ctx.session();
        const ordNo = await createOrder(page, { customer: OTHER.code, advance: 210 });
        const vchNo = await create(page, [{ ordNo }]);
        await ctx.owner.$executeRawUnsafe(
          `UPDATE "AC_MAST" SET "AC_NAME"='RENAMED AFTER CANCEL' WHERE tenant_id=$1 AND "AC_CODE"=$2`,
          ctx.tenantId,
          OTHER.code,
        );
        try {
          await load(page, vchNo);
          assert.equal(await page.getByLabel('Ac Name row 1').textContent(), OTHER.name);
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "AC_MAST" SET "AC_NAME"=$3 WHERE tenant_id=$1 AND "AC_CODE"=$2`,
            ctx.tenantId,
            OTHER.code,
            OTHER.name,
          );
        }
        return {
          observation: `voucher ${vchNo} reopened with the saved party name after the master was renamed`,
          expected: OTHER.name,
          database: { rows: await adjRows(ctx, vchNo) },
          downstream: { name: OTHER.name },
        };
      },
    ),
    C(
      'output.order-cancel-voucher',
      'T16',
      'output',
      'BtnPrint_Click (:3794-3849) prints OrderCancelVch: one receipt per grid row with the book name, company block, "ORIGINAL", Vch Date, Vch No, Chq No, Party Name, Amt Bal, "Rs :" PAID_AMT, "Ruppes : " + ucase(ToWords(PAID_AMT, 0)), Net Due Amount, Vch Desc, "For : " + CO_NAME, Party signature., signature.',
      async (ctx) => {
        const { page } = await ctx.session();
        const a = await createOrder(page, { advance: 1250 });
        const b = await createOrder(page, { customer: OTHER.code, advance: 300 });
        const vchNo = await create(page, [{ ordNo: a, kasar: 50, desc: 'print me' }, { ordNo: b }]);
        const html = await page.evaluate(
          async (url) => (await fetch(url, { credentials: 'include' })).text(),
          `/api/order-cancel/${vchNo}/print?coBook=${BOOK}&format=html`,
        );
        const text = html.replace(/<[^>]+>/g, ' ').replace(/\s+/g, ' ');
        const receipts = (html.match(/<section class="rcpt"/g) ?? []).length;
        assert.equal(receipts, 2, 'one receipt per grid row');
        for (const part of [
          'Order Cancel',
          'ORIGINAL',
          `Vch No : ${vchNo}`,
          'Chq No :',
          `Party Name : ${CUSTOMER.name}`,
          `Party Name : ${OTHER.name}`,
          'Rs : 1,200.00',
          'Ruppes : ONE THOUSAND TWO HUNDRED',
          'Rs : 300.00',
          'Ruppes : THREE HUNDRED',
          'Net Due Amount :',
          'Vch Desc : print me',
          'For : E2E Jeweller',
          'Party signature.',
          'signature.',
        ])
          assert.ok(text.includes(part), `print shows "${part}"`);
        const printPage = await page.context().newPage();
        await printPage.goto(`/api/order-cancel/${vchNo}/print?coBook=${BOOK}&format=html`);
        await ctx.shot(printPage, 'print');
        await printPage.close();
        return {
          observation: `voucher ${vchNo}: ${receipts} receipts with the template's captions and amounts in words`,
          expected: 'OrderCancelVch regions and captions',
          output: Buffer.from(html),
        };
      },
    ),
    C(
      'keyboard.reference-workflow',
      'T17',
      'mutation',
      'tVchNo Enter -> mVchDate (:3951-3977), mVchDate Enter -> grid OrdNo (:3985-4012); TEXT_ENTRY_KeyDown Enter on a blank OrdNo opens the help (:2499), then It Desc, AdjAmt (0 stays, :2733), KsarAmt, PaiidAc, and the last cell opens the next row (:2808-2826); Alt+S saves. At 1366x768.',
      async (ctx) => {
        const { page } = await ctx.session();
        await page.setViewportSize({ width: 1366, height: 768 });
        const ordNo = await createOrder(page, { advance: 777 });
        await openCancel(page);
        const box = page.locator('#order-cancel-vch-no');
        await box.focus();
        await page.keyboard.press('Enter');
        await page.waitForFunction(() => document.activeElement?.id === 'order-cancel-date');
        await page.keyboard.press('Enter');
        await page.waitForFunction(
          () => document.activeElement?.getAttribute('aria-label') === 'OrdNo row 1',
        );
        await page.keyboard.press('Enter');
        await page.getByRole('dialog', { name: 'Pending orders' }).waitFor();
        await page.keyboard.type(ordNo);
        await page.locator(`tr[data-order="${ordNo}"]`).first().waitFor();
        await page.keyboard.press('Enter');
        await page.waitForFunction(
          () => document.activeElement?.getAttribute('aria-label') === 'It Desc row 1',
        );
        await page.keyboard.type('KEYBOARD CANCEL');
        await page.keyboard.press('Enter');
        await page.waitForFunction(
          () => document.activeElement?.getAttribute('aria-label') === 'AdjAmt row 1',
        );
        await page.keyboard.press('Enter');
        await page.waitForFunction(
          () => document.activeElement?.getAttribute('aria-label') === 'KsarAmt row 1',
        );
        await page.keyboard.type('7');
        await page.keyboard.press('Enter');
        await page.waitForFunction(
          () => document.activeElement?.getAttribute('aria-label') === 'PaiidAc row 1',
        );
        await page.keyboard.press('Enter');
        await page.waitForFunction(
          () => document.activeElement?.getAttribute('aria-label') === 'OrdNo row 2',
        );
        await ctx.shot(page, 'keyboard');
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'POST' && pathOf(r) === '/api/order-cancel',
          ),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [row] = await adjRows(ctx, vchNo);
        assert.deepEqual(
          [row.ord, row.adj, row.kasar, row.paid, row.desc],
          [ordNo, 777, 7, 770, 'KEYBOARD CANCEL'],
        );
        return {
          observation: `keyboard only: voucher ${vchNo} for order ${ordNo}, kasar 7, paid 770`,
          expected: 'the desktop Enter flow and Alt+S',
          database: { row },
          downstream: { focusAfterPaidAc: 'OrdNo row 2' },
        };
      },
    ),
    C(
      'journey.order-advance-refunded',
      'T18',
      'mutation',
      "Sales Order (cash 1,000 + UPI 500 = ADV_AMT 1,500, Order_Ledr credits the customer) -> Order Cancel refunds 1,400 by bank with 100 kasar (Order_Adj_Ledr debits the customer 1,500): the customer's ledger balance returns to what it was before the order, the bank is credited 1,400, the kasar account 100, and the order leaves the help so a sale can no longer use its advance.",
      async (ctx) => {
        const { page } = await ctx.session();
        const before = {
          customer: await balance(ctx, CUSTOMER.code),
          bank: await balance(ctx, BANK.code),
          kasar: await balance(ctx, KASAR),
        };
        const ordNo = await createOrder(page, { advance: 1000, upi: 500 });
        const [{ adv }] = await ctx.rows(
          `SELECT "ADV_AMT"::float adv FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${ORDER_BOOK}' AND "VCH_NO"=$2`,
          ordNo,
        );
        assert.equal(adv, 1500, 'the order took a 1,500 advance (cash + bank)');
        const mid = await balance(ctx, CUSTOMER.code);
        assert.equal(mid, before.customer - 1500);
        const vchNo = await create(page, [{ ordNo, kasar: 100, paidAc: BANK.code }]);
        const after = {
          customer: await balance(ctx, CUSTOMER.code),
          bank: await balance(ctx, BANK.code),
          kasar: await balance(ctx, KASAR),
        };
        assert.equal(after.customer, before.customer, 'customer back to where it was');
        assert.equal(after.bank, before.bank + 500 - 1400, 'bank: +500 UPI advance, -1,400 refund');
        assert.equal(after.kasar, before.kasar - 100, 'kasar account credited 100');
        assert.equal(
          (await pendingOf(page)).find((o) => o.ordNo === ordNo),
          undefined,
        );
        return {
          observation: `order ${ordNo} (advance 1500) cancelled by ${vchNo}: customer ${before.customer} -> ${mid} -> ${after.customer}; bank ${before.bank} -> ${after.bank}; kasar ${before.kasar} -> ${after.kasar}`,
          expected: {
            customer: before.customer,
            bank: before.bank - 900,
            kasar: before.kasar - 100,
          },
          database: { before, after },
          downstream: { pending: false },
        };
      },
    ),
    blocked(
      'stock.held-tag-released',
      'T18',
      'TR_SL_ORD_ADJ.cs:2598-2631 and :3593-3660, Ac_Stock.cs:610-622: a tag the order holds (TAG_STK_LESS Y) comes back to stock',
      'The web Sales Order screen cannot make an order that holds a tag: a new order line is always saved with TAG_NO N (salesOrder.ts, SL_ORD_DETL.TAG_NO "new untagged row sentinel"), so the order under test cannot be created through the screen. The write set is proven by the DB test (orderCancel.db.test.ts "tags the order held come back to stock").',
    ),
    blocked(
      'create.cheque-advance',
      'T02',
      'Prompt 11 case emphasis: orders with advances by cash, bank and cheque',
      'The web Sales Order screen has no cheque tender (TR_SALE_ORD takes one); cash and UPI/bank advances are covered by the other cases.',
    ),
  ],
};
