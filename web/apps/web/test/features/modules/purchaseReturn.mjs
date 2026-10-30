import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';

/**
 * Feature: Purchase → Purchase Return (desktop TR_KR_ISU in PURC RETURN mode, MDI_FORM.cs:7893-7917).
 *
 * Expected values follow the desktop form, not the web code:
 * - The returned line's metal amount is fine × rate and its per-gram labour is (net + ghat) × rate, each rounded
 *   to whole rupees with Math.Round(x, 0), which is banker's rounding (TR_KR_ISU.cs:4015, :4028).
 * - The bill sums the lines to whole rupees (:6522), takes tax on (net − discount) rounded with TAX_ROF (:6527;
 *   a blank TAX_ROF keeps the web's 2 decimals) and rounds the bill total to whole rupees (:6528).
 * - Metal goes OUT of stock (MAIN_STOCK ITM_SIGN '-'), the supplier is debited with the total, and the tender is
 *   cheque, card, cash and kasar only (:5066-5072): there is no UPI on a purchase return.
 * - Delete removes the voucher rows and writes DELETE_DATA with the deleting user.
 */
const BOOK = 'PRT';
const PURCHASE_BOOK = 'PR';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

// Line P: GLD22 gross 10.25, net 10, touch 91.6, rate 6123.45, making 237.5 /g
//   fine   = 10 × 91.6 / 100 = 9.160
//   metal  = round(9.16 × 6,123.45 = 56,090.802) = 56,091   (TR_KR_ISU.cs:4015)
//   labour = round(10 × 237.5)                    =  2,375   (:4028)
//   net 58,466; tax = round(58,466 × 3%, TAX_ROF) = 1,753.98; total = round(60,219.98, 0) = 60,220 (:6522-6528)
const LINE_P = {
  item: ITEMS.gold.code,
  pcs: '1',
  gross: '10.25',
  net: '10',
  touch: '91.6',
  rate: '6123.45',
  making: '237.5',
};
const EXPECT_P = { fine: 9.16, metal: 56091, labour: 2375, net: 58466, tax: 1753.98, total: 60220 };
// Line W: GLD22 net 5, touch 80, rate 1500, making 40 — whole-rupee amounts, so lifecycle cases do not depend
// on rounding: fine 4, metal 6,000, labour 200, net 6,200, tax 186, total 6,386.
const LINE_W = {
  item: ITEMS.gold.code,
  pcs: '1',
  gross: '5',
  net: '5',
  touch: '80',
  rate: '1500',
  making: '40',
};
const EXPECT_W = { fine: 4, metal: 6000, labour: 200, net: 6200, tax: 186, total: 6386 };
const LINE_SV = {
  item: ITEMS.silver.code,
  pcs: '2',
  gross: '50',
  net: '50',
  touch: '90',
  rate: '80',
};

const field = (page, label) =>
  page
    .locator('.field')
    .filter({
      has: page.locator('label', { hasText: new RegExp(`^${label.replace(/[()]/g, '\\$&')}$`) }),
    })
    .locator('input,select')
    .first();
const grid = (page) =>
  page.locator('table', { has: page.locator('th', { hasText: 'Making/g' }) }).first();
const cell = (page, row, n) =>
  grid(page).locator('tbody tr').nth(row).locator(`td:nth-child(${n}) input`).first();
const cellText = (page, row, n) =>
  grid(page).locator('tbody tr').nth(row).locator(`td:nth-child(${n})`);

async function openReturn(page, { original = true } = {}) {
  await page.goto('/txn/purchase-return');
  await page.getByRole('heading', { name: 'Purchase Return', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned PURC RETURN book is selected');
  // The web makes Orig Purchase Book a required select and the company has two purchase books, so nothing is
  // preselected and the browser blocks Save until one is chosen (G198, its own case). Lifecycle cases pick PR.
  if (original) await chooseOriginalBook(page);
  return book;
}
/** BookSelect resets its value when its book list (re)loads, so select PR and wait until the choice sticks. */
async function chooseOriginalBook(page) {
  const orig = field(page, 'Orig Purchase Book');
  await orig.locator(`option[value="${PURCHASE_BOOK}"]`).waitFor({ state: 'attached' });
  for (let i = 0; i < 20; i++) {
    if ((await orig.inputValue()) !== PURCHASE_BOOK) await orig.selectOption(PURCHASE_BOOK);
    await page.waitForTimeout(150);
    if ((await orig.inputValue()) === PURCHASE_BOOK && i >= 2) return;
  }
  assert.equal(await orig.inputValue(), PURCHASE_BOOK, 'Orig Purchase Book could not be chosen');
}
/** Clicks a save button and reports either the response or the browser's own form-validation block. */
async function submit(page, label = 'Save Return') {
  const response = page
    .waitForResponse(
      (r) =>
        /^\/api\/purchase-returns(\/\d+)?$/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
      { timeout: 4000 },
    )
    .catch(() => null);
  await page.getByRole('button', { name: label, exact: true }).click();
  const got = await response;
  if (got) return { response: got };
  const blocked = await page.evaluate(() => {
    const el = document.querySelector('form :invalid');
    const label = el?.closest('.field')?.querySelector('label')?.textContent?.trim();
    return el ? `${label || el.tagName}: ${el.validationMessage}` : null;
  });
  return { blocked: blocked ?? 'no request and no invalid field' };
}
async function pickSupplier(page, code) {
  const input = page.getByLabel('Supplier account', { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}
async function fillLine(page, row, line) {
  // Columns: 1 item, 2 tag, 3 pcs, 4 gross, 5 net, 6 touch, 7 rate, 8 making/g, 9 fine, 10 amount.
  await cell(page, row, 1).fill(line.item);
  await cell(page, row, 1).press('Escape');
  for (const [n, value] of [
    [3, line.pcs],
    [4, line.gross],
    [5, line.net],
    [6, line.touch],
    [7, line.rate],
    [8, line.making],
  ])
    if (value !== undefined) await cell(page, row, n).fill(value);
}
async function save(page, label = 'Save Return') {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /^\/api\/purchase-returns(\/\d+)?$/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    page.getByRole('button', { name: label, exact: true }).click(),
  ]);
  return response;
}
async function createReturn(ctx, page, { supplier = PARTIES.local.code, lines = [LINE_W] } = {}) {
  await openReturn(page);
  await pickSupplier(page, supplier);
  for (const [i, line] of lines.entries()) {
    if (i) await page.getByRole('button', { name: '+ Add line', exact: true }).click();
    await fillLine(page, i, line);
  }
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  const vchNo = String((await response.json()).vchNo).padStart(5, '0');
  await page.getByText(`Return saved — Voucher #${Number(vchNo)}`, { exact: false }).waitFor();
  return vchNo;
}
async function loadReturn(page, vchNo) {
  await page.getByLabel('Voucher No', { exact: true }).fill(vchNo);
  await page.getByRole('button', { name: 'Load', exact: true }).first().click();
  await page.getByTestId('purchase-return-loaded').getByText(`Loaded #${vchNo}`).waitFor();
}
/** A purchase through the Purchase screen, to return against. */
async function purchaseOne(page, line = LINE_W) {
  await page.goto('/txn/purchase');
  await page.getByRole('heading', { name: 'Purchase Invoice', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== PURCHASE_BOOK; i++)
    await page.waitForTimeout(100);
  const supplier = page.getByPlaceholder('search accounts… (F1)').first();
  await supplier.fill(PARTIES.local.code);
  await supplier
    .locator('xpath=..')
    .getByText(PARTIES.local.code, { exact: true })
    .first()
    .waitFor();
  await supplier.press('Enter');
  await fillLine(page, 0, line);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => new URL(r.url()).pathname === '/api/purchases' && r.request().method() === 'POST',
    ),
    page.getByRole('button', { name: 'Save Purchase', exact: true }).click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return String((await response.json()).vchNo).padStart(5, '0');
}

const header = (ctx, v) =>
  ctx.rows(
    `SELECT "VCH_NO","HD_VCH_NO","AC_CODE","MAIN_USER"::text mu,"NET_AMT"::float net,"TAX_AMT"::float tax,
            "CGST_TAX"::float cgst,"IGST_TAX"::float igst,"TOT_AMT"::float tot
       FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
    v,
  );
const lines = (ctx, v) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"IT_CODE" it,"TAG_NO"::text tag,"ITM_NWT"::float nwt,"ITM_FINE"::float fine,
            "ITM_AMT"::float amt,"LBR_AMT"::float lbr,"NET_AMT"::float net
       FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    v,
  );
const ledger = (ctx, v) =>
  ctx.rows(
    `SELECT "AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    v,
  );
const stock = (ctx, v) =>
  ctx.rows(
    `SELECT "IT_CODE" it,"ITM_SIGN" sign,"ITM_NWT"::float nwt FROM "MAIN_STOCK"
      WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "IT_CODE"`,
    v,
  );
const counts = async (ctx) =>
  (
    await ctx.rows(
      `SELECT (SELECT count(*) FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int pr,
              (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int ac,
              (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int stk`,
    )
  )[0];
const goldStock = async (ctx) =>
  (
    await ctx.rows(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='-' THEN -"ITM_NWT" ELSE "ITM_NWT" END),0)::float n
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
      ITEMS.gold.code,
    )
  )[0].n;
const balanced = (rows) => {
  const dr = rows.reduce((s, r) => s + r.dr, 0);
  const cr = rows.reduce((s, r) => s + r.cr, 0);
  return dr > 0 && Math.abs(dr - cr) < 0.005;
};
const debit = (rows, ac) =>
  Math.round(rows.filter((r) => r.ac === ac).reduce((s, r) => s + r.dr - r.cr, 0) * 100) / 100;
const latest = (ctx) =>
  ctx.rows(
    `SELECT "VCH_NO","TOT_AMT"::float tot FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO" DESC LIMIT 1`,
  );

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `purchase-return.${id}`,
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

export const purchaseReturn = {
  feature: 'purchase-return',
  title: 'Purchase → Purchase Return (TR_KR_ISU, PURC RETURN mode)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/purchase-return/page.tsx',
    'web/apps/web/lib/purchaseReturnForm.ts',
    'web/apps/api/src/modules/purchase/purchaseReturn.ts',
    'web/apps/api/src/modules/purchase/purchaseReturnLifecycle.ts',
    'web/apps/web/test/features/modules/purchaseReturn.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { TOT_AMT_ROF: 'blank', TAX_ROF: 'blank → 2dp', ALL_ROF_REMOVE: 'blank (N)' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'CurBookHelp("PURC RETURN"): the provisioned return book is selected; tax defaults to 3; a new line is empty',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReturn(page);
        const tax = await field(page, 'Tax %').inputValue();
        const item = await cell(page, 0, 1).inputValue();
        assert.deepEqual([tax, item], ['3', '']);
        return {
          observation: `book ${BOOK}, tax ${tax}, first line empty`,
          expected: { book: BOOK, tax: '3', item: '' },
        };
      },
    ),

    C(
      'formula.whole-rupees',
      'T03',
      'read-only',
      'TR_KR_ISU.cs:4015, 4028, 6522-6528: 9.16 g fine at 6,123.45 previews 56,091 + 2,375 = 58,466 and a total of 60,220',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReturn(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_P);
        await page.waitForTimeout(400);
        const amount = (await cellText(page, 0, 10).innerText()).trim();
        const total = await page
          .getByText(/^Total ₹/)
          .first()
          .innerText();
        assert.equal(amount, '58,466', `line amount shows ${amount}`);
        assert.match(total, /Total ₹60,220$/, `bill shows ${total}`);
        return { observation: `line ${amount}; ${total}`, expected: EXPECT_P };
      },
      { expected: EXPECT_P },
    ),

    C(
      'create.amounts',
      'T07',
      'mutation',
      'TR_KR_ISU.cs:4015, 4028, 6522-6528: the saved return stores 56,091 + 2,375 = 58,466, tax 1,753.98 and total 60,220',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page, { lines: [LINE_P] });
        const [h] = await header(ctx, vchNo);
        const [l] = await lines(ctx, vchNo);
        assert.deepEqual(
          [l.fine, l.amt, l.lbr, l.net, h.net, h.tax, h.tot],
          [
            EXPECT_P.fine,
            EXPECT_P.metal,
            EXPECT_P.labour,
            EXPECT_P.net,
            EXPECT_P.net,
            EXPECT_P.tax,
            EXPECT_P.total,
          ],
        );
        return {
          observation: `voucher ${vchNo}: ITM_AMT ${l.amt}, NET ${h.net}, TOT ${h.tot}`,
          expected: EXPECT_P,
          database: { header: h, line: l },
          downstream: { total: h.tot },
        };
      },
      {
        expected: EXPECT_P,
        observe: async (ctx) => ({
          returns: await latest(ctx),
          lines: await ctx.rows(
            `SELECT "VCH_NO","ITM_AMT"::float amt,"LBR_AMT"::float lbr,"NET_AMT"::float net FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO" DESC LIMIT 1`,
          ),
        }),
      },
    ),

    C(
      'create.effects',
      'T07',
      'mutation',
      'A return sends the metal out of stock (−), debits the supplier with the total, balances, and keeps the creator',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        const [h] = await header(ctx, vchNo);
        const g = await ledger(ctx, vchNo);
        const s = await stock(ctx, vchNo);
        assert(balanced(g), `ledger must balance: ${JSON.stringify(g)}`);
        assert.equal(
          debit(g, PARTIES.local.code),
          h.tot,
          'the supplier is debited with the bill total',
        );
        assert.deepEqual(s, [{ it: ITEMS.gold.code, sign: '-', nwt: 5 }]);
        assert.deepEqual([h.tot, h.mu.trim()], [EXPECT_W.total, USERS.admin.user]);
        return {
          observation: `voucher ${vchNo}: stock −5, supplier debited ${h.tot}, ${g.length} balanced legs, creator ${h.mu}`,
          expected: { stock: '-5', supplierDebit: EXPECT_W.total, mainUser: USERS.admin.user },
          database: { header: h, ledger: g, stock: s },
          downstream: { balanced: true },
        };
      },
    ),

    C(
      'create.without-original',
      'T04',
      'mutation',
      'TR_KR_ISU.cs:4956-4999: the save checks need a party and a voucher number, not an original purchase, so a free-standing return saves',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReturn(page, { original: false });
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_W);
        const { response, blocked } = await submit(page);
        assert(response, `Save sent no request; the browser blocked it (${blocked})`);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        return {
          observation: `voucher ${vchNo} saved without an original purchase, total ${h.tot}`,
          expected: { saved: 201, original: 'none' },
          database: { header: h },
          downstream: { created: 1 },
        };
      },
      {
        expected: { saved: 201, original: 'none' },
        observe: async (ctx) => ({ returns: await counts(ctx), latest: await latest(ctx) }),
      },
    ),

    C(
      'create.against-purchase',
      'T04',
      'mutation',
      'Return against a purchase: Orig Purchase Book + Orig Voucher + Import fill the supplier and the purchased line, and the return saves',
      async (ctx) => {
        const { page } = await ctx.session();
        const purchase = await purchaseOne(page);
        await openReturn(page);
        await field(page, 'Orig Purchase Book').selectOption(PURCHASE_BOOK);
        await page.getByLabel('Original purchase voucher', { exact: true }).fill(purchase);
        await page
          .locator('.field', { has: page.getByLabel('Original purchase voucher', { exact: true }) })
          .getByRole('button', { name: 'Import', exact: true })
          .click();
        await page.waitForTimeout(1500);
        const supplier = await page.getByLabel('Supplier account', { exact: true }).inputValue();
        const item = await cell(page, 0, 1).inputValue();
        const net = await cell(page, 0, 5).inputValue();
        assert.deepEqual([supplier, item, net], [PARTIES.local.code, ITEMS.gold.code, '5']);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [l] = await lines(ctx, vchNo);
        return {
          observation: `purchase ${purchase} imported (supplier ${supplier}, item ${item}, net ${net}); return ${vchNo} saved, tag ${l.tag}`,
          expected: { supplier: PARTIES.local.code, item: ITEMS.gold.code, net: '5', saved: 201 },
          database: { line: l },
          downstream: { imported: true },
        };
      },
      {
        expected: { supplier: PARTIES.local.code, item: ITEMS.gold.code, net: '5', saved: 201 },
        observe: async (ctx) => ({
          purchases: await ctx.rows(
            `SELECT "VCH_NO","IT_CODE","TAG_NO"::text tag FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${PURCHASE_BOOK}' ORDER BY "VCH_NO" DESC LIMIT 1`,
          ),
          returns: await counts(ctx),
        }),
      },
    ),

    C(
      'create.two-groups',
      'T05',
      'mutation',
      'Gold and silver lines on one return keep their own values and the ledger balances (the return twin of G176)',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page, { lines: [LINE_W, LINE_SV] });
        const l = await lines(ctx, vchNo);
        const g = await ledger(ctx, vchNo);
        assert.equal(l.length, 2);
        assert(balanced(g), `ledger must balance: ${JSON.stringify(g)}`);
        return {
          observation: `voucher ${vchNo}: ${l.length} lines, ${g.length} balanced legs`,
          expected: { lines: 2, balanced: true },
          database: { lines: l, ledger: g },
          downstream: { balanced: true },
        };
      },
      {
        expected: { lines: 2, balanced: true },
        observe: async (ctx) => ({ counts: await counts(ctx) }),
      },
    ),

    C(
      'create.interstate-igst',
      'T02',
      'mutation',
      'An inter-state supplier (AC_GST_TYPE I) takes IGST for the whole tax, with no CGST/SGST',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page, { supplier: PARTIES.interState.code });
        const [h] = await header(ctx, vchNo);
        assert.deepEqual([h.igst, h.cgst], [h.tax, 0]);
        return {
          observation: `voucher ${vchNo}: IGST ${h.igst}, CGST ${h.cgst}`,
          expected: { igst: 'tax', cgst: 0 },
          database: { header: h },
          downstream: { tax: h.tax },
        };
      },
      {
        expected: { igst: 'tax', cgst: 0 },
        observe: async (ctx) => ({ returns: await latest(ctx) }),
      },
    ),

    C(
      'refusal.no-lines',
      'T06',
      'refusal',
      'A return without lines is refused and writes nothing',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openReturn(page);
        await pickSupplier(page, PARTIES.local.code);
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `answered ${response.status()}`,
          expected: 'refused, no write',
          database: { before },
        };
      },
    ),

    C(
      'refusal.no-upi',
      'T06',
      'refusal',
      'TR_KR_ISU.cs:5066-5072: the return tender has no UPI, so a UPI amount is refused with its reason and writes nothing',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openReturn(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_W);
        await page.locator('.field', { hasText: 'UPI Amt' }).locator('input').fill('100');
        const response = await save(page);
        assert.equal(response.status(), 400, await response.text());
        await page.getByText('a purchase return has no UPI tender', { exact: false }).waitFor();
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: 'UPI refused with its reason',
          expected: 'refused, no write',
          database: { before },
        };
      },
    ),

    C(
      'reopen.load',
      'T08',
      'read-only',
      'Load by voucher number hydrates the supplier and the line',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadReturn(page, vchNo);
        const supplier = await page.getByLabel('Supplier account', { exact: true }).inputValue();
        const net = await cell(page, 0, 5).inputValue();
        const making = await cell(page, 0, 8).inputValue();
        assert.deepEqual([supplier, net, making], [PARTIES.local.code, '5', '40']);
        return {
          observation: `voucher ${vchNo} reloaded: ${supplier}, net ${net}, making ${making}`,
          expected: 'hydrated',
        };
      },
    ),

    C(
      'edit.unchanged-and-reprice',
      'T09',
      'mutation',
      'An unchanged save changes nothing; a new weight re-derives the line and keeps the number, hidden number and creator',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        const [before] = await header(ctx, vchNo);
        await loadReturn(page, vchNo);
        // A free-standing return reopens with Orig Purchase Book empty, and that select is required (G198), so
        // an operator has to choose a book before saving. Record it, then choose PR and test the edit itself.
        const reopenBlocked = await page.evaluate(() => {
          const el = document.querySelector('form :invalid');
          return el
            ? el.closest('.field')?.querySelector('label')?.textContent?.trim() || el.tagName
            : null;
        });
        await page.waitForLoadState('networkidle');
        await chooseOriginalBook(page);
        const picked = await field(page, 'Orig Purchase Book').inputValue();
        await page.waitForTimeout(1000);
        const later = await field(page, 'Orig Purchase Book').inputValue();
        const { response: unchanged, blocked } = await submit(page, `Save Return #${vchNo}`);
        assert(
          unchanged,
          `reopened return not saved: picked ${picked}, 1 s later ${later || 'blank'}; ${blocked}`,
        );
        assert.equal(unchanged.status(), 200, await unchanged.text());
        assert.deepEqual(
          (await header(ctx, vchNo))[0],
          before,
          'an unchanged save changes no header value',
        );
        await page
          .getByText(`Return saved — Voucher #${Number(vchNo)}`, { exact: false })
          .waitFor();
        await page.waitForLoadState('networkidle');
        // After a save the screen reloads the voucher, and Orig Purchase Book comes back blank again (G198).
        const afterSave = await field(page, 'Orig Purchase Book').inputValue();
        await chooseOriginalBook(page);
        await cell(page, 0, 4).fill('10');
        await cell(page, 0, 5).fill('10');
        const edited = await save(page, `Save Return #${vchNo}`);
        assert.equal(edited.status(), 200, await edited.text());
        const [after] = await header(ctx, vchNo);
        const [l] = await lines(ctx, vchNo);
        // fine 8, metal 12,000, labour 400 -> 12,400; 3% 372 -> 12,772 (whole rupees either way).
        assert.deepEqual([l.fine, l.amt, l.lbr, after.tot], [8, 12000, 400, 12772]);
        assert.deepEqual(
          [after.VCH_NO, after.HD_VCH_NO, after.mu],
          [before.VCH_NO, before.HD_VCH_NO, before.mu],
        );
        assert(balanced(await ledger(ctx, vchNo)));
        return {
          observation: `voucher ${vchNo}: reopened with required field blank: ${reopenBlocked ?? 'none'}; after the unchanged save Orig Purchase Book was '${afterSave}'; edit → total ${after.tot}`,
          expected: { total: 12772, identityKept: true },
          database: { before, after, line: l },
          downstream: { balanced: true },
        };
      },
    ),

    C(
      'delete.reverses',
      'T10',
      'mutation',
      'Delete of the loaded return removes every voucher row and writes one DELETE_DATA row naming the user',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadReturn(page, vchNo);
        const [removed] = await Promise.all([
          page.waitForResponse(
            (r) =>
              new URL(r.url()).pathname === `/api/purchase-returns/${vchNo}` &&
              r.request().method() === 'DELETE',
          ),
          page
            .locator('.panel', { has: page.getByLabel('Voucher No', { exact: true }) })
            .getByRole('button', { name: 'Delete', exact: true })
            .click(),
        ]);
        assert.equal(removed.status(), 200, await removed.text());
        assert.deepEqual(
          [await header(ctx, vchNo), await ledger(ctx, vchNo), await stock(ctx, vchNo)],
          [[], [], []],
        );
        const audit = await ctx.rows(
          `SELECT "DELETE_USER"::text du FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY row_id DESC LIMIT 1`,
          vchNo,
        );
        assert.deepEqual(
          audit.map((a) => a.du.trim()),
          [USERS.admin.user],
        );
        return {
          observation: `voucher ${vchNo} deleted; DELETE_USER ${audit[0].du}`,
          expected: { remaining: 0, deleteUser: USERS.admin.user },
          database: { audit },
          downstream: { remaining: 0 },
        };
      },
    ),

    C(
      'print.debit-note',
      'T16',
      'output',
      'The saved return prints from the recent list with its total',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        const row = page.locator('table.grid tr', { hasText: vchNo }).last();
        const [printed] = await Promise.all([
          page.waitForEvent('popup'),
          row.getByRole('link', { name: 'Print', exact: true }).click(),
        ]);
        // N173: the print window refreshes the session first, then opens the document.
        await printed.waitForURL(new RegExp(`coBook=${BOOK}`));
        await printed.waitForLoadState();
        const html = await printed.content();
        await printed.close();
        assert.match(html, /Purchase Return/);
        assert.match(html, /6,386/);
        return {
          observation: `print of ${vchNo} shows the total`,
          expected: 'Purchase Return with 6,386',
          output: { bytes: html.length },
        };
      },
    ),

    C(
      'rights.clerk-no-return',
      'T11',
      'refusal',
      'USER_SET grants the clerk Sales Invoice only: no purchase return can be created',
      async (ctx) => {
        const clerk = await ctx.session(as(USERS.clerk.user));
        const before = await counts(ctx);
        await clerk.page.goto('/txn/purchase-return');
        await clerk.page.waitForTimeout(1500);
        const visible = await clerk.page
          .getByRole('button', { name: 'Save Return', exact: true })
          .isVisible()
          .catch(() => false);
        let status = null;
        if (visible) {
          await pickSupplier(clerk.page, PARTIES.local.code).catch(() => {});
          await fillLine(clerk.page, 0, LINE_W).catch(() => {});
          status = (await save(clerk.page).catch(() => null))?.status() ?? null;
          assert.notEqual(status, 201);
        }
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: visible ? `save answered ${status}` : 'no Save Return button for the clerk',
          expected: 'no write',
          database: { before },
        };
      },
    ),

    C(
      'concurrency.double-delete',
      'T12',
      'refusal',
      'Two operators deleting the same return: the second is refused and the stock is reversed only once',
      async (ctx) => {
        const first = await ctx.session(as(USERS.admin.user, 'operator-1'));
        const vchNo = await createReturn(ctx, first.page);
        const second = await ctx.session(as(USERS.admin.user, 'operator-2'));
        const before = await goldStock(ctx);
        const del = async (s) => {
          await openReturn(s.page);
          await loadReturn(s.page, vchNo);
          const [r] = await Promise.all([
            s.page.waitForResponse(
              (x) =>
                new URL(x.url()).pathname === `/api/purchase-returns/${vchNo}` &&
                x.request().method() === 'DELETE',
            ),
            s.page
              .locator('.panel', { has: s.page.getByLabel('Voucher No', { exact: true }) })
              .getByRole('button', { name: 'Delete', exact: true })
              .click(),
          ]);
          return r.status();
        };
        // Both operators have the voucher open before either deletes it.
        await openReturn(second.page);
        await loadReturn(second.page, vchNo);
        const one = await del(first);
        const [r2] = await Promise.all([
          second.page.waitForResponse(
            (x) =>
              new URL(x.url()).pathname === `/api/purchase-returns/${vchNo}` &&
              x.request().method() === 'DELETE',
          ),
          second.page
            .locator('.panel', { has: second.page.getByLabel('Voucher No', { exact: true }) })
            .getByRole('button', { name: 'Delete', exact: true })
            .click(),
        ]);
        const two = r2.status();
        const after = await goldStock(ctx);
        assert.equal(one, 200);
        assert.equal(
          Math.round((after - before) * 1000) / 1000,
          5,
          `stock moved by ${after - before}, expected exactly +5`,
        );
        assert(two >= 400 && two < 500, `second delete answered ${two}`);
        return {
          observation: `first delete ${one}, second ${two}; stock ${before} → ${after}`,
          expected: 'second refused; stock restored once',
          database: { before, after },
        };
      },
      {
        expected: { first: 200, second: '4xx (the voucher is gone)', stockRestored: 5 },
        observe: async (ctx) => ({
          audit: await ctx.rows(
            `SELECT "VCH_NO",count(*)::int n FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' GROUP BY "VCH_NO" ORDER BY "VCH_NO" DESC LIMIT 3`,
          ),
        }),
      },
    ),

    C(
      'retry.double-click',
      'T13',
      'mutation',
      'A double-click on Save creates one return',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openReturn(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_W);
        await page.getByRole('button', { name: 'Save Return', exact: true }).dblclick();
        await page.waitForTimeout(2500);
        const after = await counts(ctx);
        assert.equal(after.pr - before.pr, 1);
        return {
          observation: `${after.pr - before.pr} return created`,
          expected: 1,
          database: { before, after },
          downstream: { created: after.pr - before.pr },
        };
      },
    ),

    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'The desktop &Save mnemonic: Alt+S saves the return',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openReturn(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_W);
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) =>
              new URL(r.url()).pathname === '/api/purchase-returns' &&
              r.request().method() === 'POST',
          ),
          page.keyboard.press('Alt+s'),
        ]);
        assert.equal(response.status(), 201, await response.text());
        const after = await counts(ctx);
        assert.equal(after.pr - before.pr, 1);
        return {
          observation: 'Alt+S saved the return',
          expected: 'save',
          database: { before, after },
          downstream: { created: 1 },
        };
      },
    ),

    C(
      'journey.purchase-then-return',
      'T18',
      'mutation',
      'A purchase and its full return put the stock back and move the supplier by the return total less the purchase total',
      async (ctx) => {
        const { page } = await ctx.session();
        const balance = async () =>
          (
            await ctx.rows(
              `SELECT coalesce(sum("DR_AMT"-"CR_AMT"),0)::float n FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
              PARTIES.local.code,
            )
          )[0].n;
        const [stock0, bal0] = [await goldStock(ctx), await balance()];
        const purchase = await purchaseOne(page);
        const ret = await createReturn(ctx, page);
        const [stock1, bal1] = [await goldStock(ctx), await balance()];
        const total = async (book, vch) =>
          (
            await ctx.rows(
              `SELECT "TOT_AMT"::float n FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
              book,
              vch,
            )
          )[0]?.n;
        const [purchaseTot, returnTot] = [
          await total(PURCHASE_BOOK, purchase),
          await total(BOOK, ret),
        ];
        assert.equal(Math.round((stock1 - stock0) * 1000) / 1000, 0, 'stock back where it was');
        assert.equal(
          Math.round((bal1 - bal0) * 100) / 100,
          Math.round((returnTot - purchaseTot) * 100) / 100,
          `supplier moved by ${bal1 - bal0}; return ${returnTot} − purchase ${purchaseTot}`,
        );
        return {
          observation: `purchase ${purchase} + return ${ret}: stock Δ ${stock1 - stock0}, supplier Δ ${bal1 - bal0}`,
          expected: { stockDelta: 0, supplierDelta: 'return total − purchase total' },
          database: { stock0, stock1, bal0, bal1, purchaseTot, returnTot },
          downstream: { supplierDelta: bal1 - bal0 },
        };
      },
    ),

    C(
      'report.register-lists-return',
      'T16',
      'read-only',
      'The Purchase Return Register lists a saved return (desktop books of MAIN_BOOK PURC RETURN carry BOOK_TBL_NAME PR_DATA, MS_UPDATE.cs:7849)',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        await page.goto('/reports/purchase-return-register');
        await page.getByRole('button', { name: 'Run', exact: true }).click();
        const row = page.locator('table.grid tr', { hasText: `${BOOK}/${vchNo}` }).first();
        const found = await row
          .waitFor({ timeout: 8000 })
          .then(() => true)
          .catch(() => false);
        const text = found ? await row.innerText() : await page.locator('main').innerText();
        assert(
          found,
          `the register does not list ${BOOK}/${vchNo}: ${text.replace(/\s+/g, ' ').slice(0, 160)}`,
        );
        assert.match(text, /6,?386/);
        return {
          observation: `register row: ${text.replace(/\s+/g, ' ')}`,
          expected: `${BOOK}/${vchNo} with 6,386`,
          output: { row: text },
        };
      },
      { expected: 'the saved return is listed with its total' },
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
        'Playbook T15: a company with other rounding settings',
        async () => ({}),
      ),
      blocked: 'No settings-variant company in the catalogue yet (G174 / N166).',
    },
  ],
};
