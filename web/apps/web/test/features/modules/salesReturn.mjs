import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import { salesScreen as S } from './salesInvoice.mjs';

/**
 * Feature: Sales → Sales Return, "New return" form (desktop TR_SALE_RTN, CurBookHelp("SALES RETURNE")).
 *
 * Expected values come from the desktop rules:
 * - TR_SALE_RTN.cs:4915-4931 prices a returned line by CO_SET.SL_AMT_TYPE, like the sale: 'N' (what seedCompany
 *   provisions) is (net + ghat) × rate, 'G' gross × rate, 'F' fine × rate. Making per gram is net × making.
 * - A return brings metal back IN (MAIN_STOCK '+'), credits the customer and debits sales returns; a cash refund
 *   pays the customer from the book's cash account. Delete reverses everything once.
 * - Amounts at 2 decimals (blank TOT_AMT_ROF on a web-provisioned company).
 */

const BOOK = 'SRT';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

// Returned line R: GLD22 gross 10.25, net 10, touch 91.6, rate 6123.45, making 237.5 /g
//   TR_SALE_RTN prices on CO_SET.SL_AMT_TYPE (N: net + ghat, TR_SALE_RTN.cs:4914-4931) and rounds each line
//   amount to whole rupees with Math.Round(x, 0), which is banker's rounding, whatever the rounding settings:
//   metal  = round(10 × 6,123.45 = 61,234.5) = 61,234   (:4955)
//   making = round(10 × 237.5)               =  2,375   (:4985)
//   net 63,609; tax = round(63,609 × 3%, TAX_ROF) = 1,908.27 (:16402; a blank TAX_ROF keeps the web's 2dp)
//   total = round(63,609 + 1,908.27, 0) = 65,517 (:16405, always whole rupees on a return)
const LINE_R = {
  item: ITEMS.gold.code,
  pcs: '1',
  gross: '10.25',
  net: '10',
  touch: '91.6',
  rate: '6123.45',
  making: '237.5',
};
const LINE_SV = {
  item: ITEMS.silver.code,
  pcs: '2',
  gross: '50.4',
  net: '50',
  touch: '92.5',
  rate: '85.5',
};
const EXPECT_R = { metal: 61234, labour: 2375, net: 63609, tax: 1908.27, total: 65517 };

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

async function openReturn(page) {
  await page.goto('/txn/sale-return');
  await page.getByRole('heading', { name: 'Sales Return', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned SALES RETURNE book is selected');
  return book;
}
async function pickParty(page, code) {
  const input = page.getByPlaceholder('search accounts… (F1)').first();
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}
async function fillLine(page, row, line) {
  // Columns: 1 item, 2 tag, 3 pcs, 4 gross, 5 net, 6 touch, 7 rate, 8 making/g.
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
async function saveReturn(page) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => new URL(r.url()).pathname === '/api/sales-returns' && r.request().method() === 'POST',
    ),
    page.getByRole('button', { name: 'Save Return', exact: true }).click(),
  ]);
  return response;
}
async function createReturn(
  ctx,
  page,
  { party = PARTIES.local.code, lines = [LINE_R], cash } = {},
) {
  await openReturn(page);
  await pickParty(page, party);
  for (const [i, line] of lines.entries()) {
    if (i) await page.getByRole('button', { name: '+ Add line', exact: true }).click();
    await fillLine(page, i, line);
  }
  if (cash) await field(page, 'Cash Amt').fill(cash);
  const response = await saveReturn(page);
  assert.equal(response.status(), 201, await response.text());
  const vchNo = String((await response.json()).vchNo).padStart(5, '0');
  await page.getByText(`Return saved — Voucher #${Number(vchNo)}`, { exact: false }).waitFor();
  return vchNo;
}
/** A sale through the Sales screen, to return against. */
async function sellOne(page) {
  await S.openSales(page);
  await S.pickParty(page, PARTIES.local.code);
  await S.fillLine(page, 0, S.LINE_A);
  const response = await S.save(page);
  assert.equal(response.status(), 201, await response.text());
  return String((await response.json()).vchNo).padStart(5, '0');
}

const header = (ctx, v) =>
  ctx.rows(
    `SELECT "VCH_NO","AC_CODE","NET_AMT"::float net,"TAX_AMT"::float tax,"IGST_TAX"::float igst,"CGST_TAX"::float cgst,"TOT_AMT"::float tot
       FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
    v,
  );
const lines = (ctx, v) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"IT_CODE" it,"ITM_NWT"::float nwt,"ITM_AMT"::float amt,"LBR_AMT"::float lbr,"NET_AMT"::float net
       FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
    v,
  );
const ledger = (ctx, v) =>
  ctx.rows(
    `SELECT "AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
    v,
  );
const stock = (ctx, v) =>
  ctx.rows(
    `SELECT "IT_CODE" it,"ITM_SIGN" sign,"ITM_NWT"::float nwt FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "IT_CODE"`,
    v,
  );
const counts = async (ctx) =>
  (
    await ctx.rows(
      `SELECT (SELECT count(*) FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int sl,
              (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int ac,
              (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int stk`,
    )
  )[0];
const balanced = (rows) => {
  const dr = rows.reduce((s, r) => s + r.dr, 0);
  const cr = rows.reduce((s, r) => s + r.cr, 0);
  return dr > 0 && Math.abs(dr - cr) < 0.005;
};
const credit = (rows, ac) =>
  Math.round(rows.filter((r) => r.ac === ac).reduce((s, r) => s + r.cr - r.dr, 0) * 100) / 100;

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `sales-return.${id}`,
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

export const salesReturn = {
  feature: 'sales-return',
  title: 'Sales → Sales Return, New return (TR_SALE_RTN)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/sale-return/page.tsx',
    'web/apps/api/src/modules/sales/salesReturn.ts',
    'web/apps/web/test/features/modules/salesReturn.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { SL_AMT_TYPE: 'N (seedCompany)', TOT_AMT_ROF: 'blank → 2dp' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'CurBookHelp("SALES RETURNE"): only Sales Return books; New and Saved modes; tax 3',
      async (ctx) => {
        const { page } = await ctx.session();
        const book = await openReturn(page);
        const offered = (await book.locator('option').allTextContents()).filter((t) =>
          t.includes('—'),
        );
        assert.deepEqual(offered, ['SRT — Sales Return']);
        await page.getByRole('button', { name: 'New return', exact: true }).waitFor();
        await page.getByRole('button', { name: 'Saved returns', exact: true }).waitFor();
        assert.equal(await field(page, 'Tax %').inputValue(), '3');
        return {
          observation: `books ${JSON.stringify(offered)}; New/Saved modes; tax 3`,
          expected: { offered: ['SRT — Sales Return'] },
        };
      },
    ),

    C(
      'formula.net-basis',
      'T03',
      'read-only',
      'TR_SALE_RTN.cs:4914-4931, 4955, 4985: SL_AMT_TYPE=N prices the returned line on (net + ghat) × rate in whole rupees — 61,234 + making 2,375 = 63,609',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReturn(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_R);
        const row = grid(page).locator('tbody tr').first();
        await page.waitForTimeout(500);
        const text = await row.innerText();
        assert.match(
          text,
          /63,609(\.00)?(?![.\d])/,
          `returned line shows ${text.replace(/\s+/g, ' ')}`,
        );
        return { observation: `preview row: ${text.replace(/\s+/g, ' ')}`, expected: EXPECT_R };
      },
      { expected: EXPECT_R },
    ),

    C(
      'create.amount-net-basis',
      'T07',
      'mutation',
      'TR_SALE_RTN.cs:4914-4931, 4955, 4985, 16402-16405: the saved return stores 61,234 + 2,375, tax 1,908.27 and credits 65,517 for a 10 g line at 6,123.45 with 237.5 making',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        const [h] = await header(ctx, vchNo);
        const [l] = await lines(ctx, vchNo);
        assert.deepEqual(
          [l.amt, l.lbr, l.net, h.net, h.tax, h.tot],
          [
            EXPECT_R.metal,
            EXPECT_R.labour,
            EXPECT_R.net,
            EXPECT_R.net,
            EXPECT_R.tax,
            EXPECT_R.total,
          ],
        );
        return {
          observation: `voucher ${vchNo}: ITM_AMT ${l.amt}, total ${h.tot}`,
          expected: EXPECT_R,
          database: { header: h, line: l },
          downstream: { total: h.tot },
        };
      },
      {
        expected: EXPECT_R,
        observe: async (ctx) => ({
          returns: await ctx.rows(
            `SELECT "VCH_NO","TOT_AMT"::float tot FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO" DESC LIMIT 1`,
          ),
          lines: await ctx.rows(
            `SELECT "VCH_NO","ITM_AMT"::float amt,"NET_AMT"::float net FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO" DESC LIMIT 2`,
          ),
        }),
      },
    ),

    C(
      'create.effects',
      'T07',
      'mutation',
      'A return brings the metal back into stock (+), credits the customer with the bill total and balances',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        const [h] = await header(ctx, vchNo);
        const g = await ledger(ctx, vchNo);
        const s = await stock(ctx, vchNo);
        assert(balanced(g), `ledger must balance: ${JSON.stringify(g)}`);
        assert.equal(
          credit(g, PARTIES.local.code),
          h.tot,
          'customer credited with the return total',
        );
        assert.deepEqual(s, [{ it: ITEMS.gold.code, sign: '+', nwt: 10 }]);
        return {
          observation: `voucher ${vchNo}: stock +10, customer credited ${h.tot}, ${g.length} balanced legs`,
          expected: { stock: '+10', customerCredit: 'bill total' },
          database: { header: h, ledger: g, stock: s },
          downstream: { customerCredit: credit(g, PARTIES.local.code) },
        };
      },
    ),

    C(
      'create.from-bill-import',
      'T04',
      'mutation',
      'Return against a bill: Orig Book + Orig Bill No + Import fill the customer and the sold items',
      async (ctx) => {
        const { page } = await ctx.session();
        const sale = await sellOne(page);
        await openReturn(page);
        await page
          .getByRole('combobox', { name: 'Configured book', exact: true })
          .nth(1)
          .selectOption('SL');
        await field(page, 'Orig Bill No').fill(sale);
        await page.getByRole('button', { name: 'Import', exact: true }).click();
        await page.waitForTimeout(1500);
        const party = await page.getByPlaceholder('search accounts… (F1)').first().inputValue();
        const item = await cell(page, 0, 1).inputValue();
        const net = await cell(page, 0, 5).inputValue();
        assert.deepEqual([party, item, net], [PARTIES.local.code, ITEMS.gold.code, '10']);
        const response = await saveReturn(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        // The sold line is loose stock, so the returned line keeps the desktop's no-tag marker 'N'
        // (TR_SALE_RTN.cs:14326-14334 stores 'N' for a line without a tag).
        const tags = await ctx.rows(
          `SELECT "TAG_NO"::text tag FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
          vchNo,
        );
        assert.deepEqual(
          tags.map((t) => t.tag.trim()),
          ['N'],
        );
        return {
          observation: `sale ${sale} imported (party ${party}, item ${item}, net ${net}); return ${vchNo} saved, total ${h.tot}, tag ${tags[0].tag}`,
          expected: {
            party: PARTIES.local.code,
            item: ITEMS.gold.code,
            net: '10',
            saved: 201,
            tag: 'N',
          },
          database: { header: h, tags },
          downstream: { imported: true },
        };
      },
      {
        // TR_SALE_RTN.cs:3917 copies the sold line's TAG_NO into the grid as it is, and 'N' is the loose-stock
        // sentinel that every later step skips (`TAG_NO <> 'N'`, :4773, :8585, :13387, :13395).
        expected: {
          party: PARTIES.local.code,
          item: ITEMS.gold.code,
          net: '10',
          saved: 201,
          tagOfLooseLine: 'N (no tag)',
        },
        observe: async (ctx) => ({
          soldLines: await ctx.rows(
            `SELECT "VCH_NO","IT_CODE","TAG_NO" FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SL' ORDER BY row_id DESC LIMIT 2`,
          ),
          returns: await counts(ctx),
        }),
      },
    ),

    C(
      'create.two-groups',
      'T05',
      'mutation',
      'Gold and silver lines on one return keep their own values and the ledger balances (the return twin of G169)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReturn(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_R);
        await page.getByRole('button', { name: '+ Add line', exact: true }).click();
        await fillLine(page, 1, LINE_SV);
        const response = await saveReturn(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const l = await lines(ctx, vchNo);
        const g = await ledger(ctx, vchNo);
        assert.deepEqual(
          l.map((x) => x.it),
          [ITEMS.gold.code, ITEMS.silver.code],
        );
        assert(balanced(g));
        return {
          observation: `voucher ${vchNo}: ${l.length} lines, ${g.length} balanced legs`,
          expected: 'two lines, balanced',
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
      'Ac_Tax: an inter-state customer (AC_GST_TYPE=I) is IGST',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReturn(page);
        await pickParty(page, PARTIES.interState.code);
        await field(page, 'Inter-state').selectOption({ index: 1 });
        await fillLine(page, 0, LINE_R);
        const response = await saveReturn(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        assert(h.igst > 0 && h.cgst === 0, `IGST ${h.igst}, CGST ${h.cgst}`);
        return {
          observation: `voucher ${vchNo}: IGST ${h.igst}`,
          expected: { igst: 'tax', cgst: 0 },
          database: { header: h },
          downstream: { igst: h.igst },
        };
      },
    ),

    C(
      'create.cash-refund',
      'T02',
      'mutation',
      'Refunding 1,000 in cash now: the cash account pays out 1,000 and the customer is credited only the rest',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page, { cash: '1000' });
        const g = await ledger(ctx, vchNo);
        const cashOut =
          Math.round(g.filter((r) => r.ac === 'CASH').reduce((s, r) => s + r.cr - r.dr, 0) * 100) /
          100;
        assert(balanced(g));
        assert.equal(cashOut, 1000, `cash paid out ${cashOut}`);
        return {
          observation: `voucher ${vchNo}: cash out ${cashOut}`,
          expected: { cashOut: 1000 },
          database: { ledger: g },
          downstream: { cashOut },
        };
      },
    ),

    C(
      'refusal.no-lines',
      'T06',
      'refusal',
      'A return needs at least one item line; nothing is written',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openReturn(page);
        await pickParty(page, PARTIES.local.code);
        const response = await saveReturn(page);
        assert(response.status() >= 400 && response.status() < 500, `status ${response.status()}`);
        await page.locator('.msg.err').waitFor();
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `refused ${response.status()}: ${await page.locator('.msg.err').innerText()}`,
          expected: '4xx + message + no write',
          database: { before, after: before },
        };
      },
    ),

    C(
      'refusal.import-missing-bill',
      'T04',
      'refusal',
      'Importing a bill number that does not exist shows a message and fills nothing',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openReturn(page);
        await page
          .getByRole('combobox', { name: 'Configured book', exact: true })
          .nth(1)
          .selectOption('SL');
        await field(page, 'Orig Bill No').fill('99999');
        await page.getByRole('button', { name: 'Import', exact: true }).click();
        await page.locator('.msg.err').waitFor();
        const item = await cell(page, 0, 1).inputValue();
        assert.equal(item, '');
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `message: ${await page.locator('.msg.err').innerText()}`,
          expected: 'message, nothing filled, no write',
          database: { before, after: before },
        };
      },
    ),

    C(
      'ui.import-button-clickable',
      'T17',
      'read-only',
      'Import beside Orig Bill No must be reachable with the mouse at a normal desktop width (1600 px)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReturn(page);
        const button = page.getByRole('button', { name: 'Import', exact: true });
        const box = await button.boundingBox();
        const onTop = await page.evaluate(
          ({ x, y }) => document.elementFromPoint(x, y)?.textContent?.trim() ?? '',
          { x: box.x + box.width / 2, y: box.y + box.height / 2 },
        );
        await ctx.shot(page, 'import-button');
        assert.equal(onTop, 'Import', `the element on top of the Import button is "${onTop}"`);
        await button.click({ timeout: 3000 });
        return { observation: 'Import is on top and clickable', expected: 'clickable' };
      },
      { expected: { clickable: true } },
    ),

    C(
      'delete.reverses-once',
      'T10',
      'mutation',
      'Delete from the recent list reverses the stock and ledger and writes DELETE_DATA',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        const row = page.locator('tr').filter({ hasText: vchNo }).first();
        await row.waitFor();
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'DELETE' && /\/api\/sales-returns\//.test(r.url()),
          ),
          row.getByRole('button', { name: /Delete/ }).click(),
        ]);
        assert.equal(response.status(), 200, await response.text());
        assert.deepEqual(
          [await header(ctx, vchNo), await ledger(ctx, vchNo), await stock(ctx, vchNo)],
          [[], [], []],
        );
        const audit = await ctx.rows(
          `SELECT count(*)::int n FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert(audit[0].n >= 1);
        return {
          observation: `voucher ${vchNo} deleted; DELETE_DATA ${audit[0].n}`,
          expected: 'removed + DELETE_DATA',
          database: { deleteData: audit[0].n },
          downstream: { remaining: 0 },
        };
      },
    ),

    C(
      'create.records-user',
      'T07',
      'mutation',
      'TR_SALE_RTN.cs:9966, 12908: a new return stores the logged-in user (DC_Main.MCo_User) as SL_DATA.MAIN_USER',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        const rows = await ctx.rows(
          `SELECT "MAIN_USER"::text mu FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert.deepEqual(
          rows.map((r) => String(r.mu ?? '').trim()),
          [USERS.admin.user],
          `MAIN_USER ${JSON.stringify(rows)}`,
        );
        return {
          observation: `voucher ${vchNo}: MAIN_USER ${rows[0].mu}`,
          expected: { mainUser: USERS.admin.user },
          database: { header: rows },
          downstream: { created: 1 },
        };
      },
      {
        expected: { mainUser: USERS.admin.user },
        observe: async (ctx) => ({
          header: await ctx.rows(
            `SELECT "VCH_NO","MAIN_USER"::text mu FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "VCH_NO" DESC LIMIT 1`,
          ),
        }),
      },
    ),

    C(
      'delete.audit-user',
      'T10',
      'mutation',
      'TR_SALE_RTN.cs:15076: the DELETE_DATA row records the logged-in user (DC_Main.MCo_User) as DELETE_USER',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        const row = page.locator('tr').filter({ hasText: vchNo }).first();
        await row.waitFor();
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'DELETE' && /\/api\/sales-returns\//.test(r.url()),
          ),
          row.getByRole('button', { name: /Delete/ }).click(),
        ]);
        assert.equal(response.status(), 200, await response.text());
        // A deleted number is reused by the next return, so read the newest audit row for it.
        const audit = await ctx.rows(
          `SELECT "DELETE_USER"::text du,"MAIN_USER"::text mu FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY row_id DESC LIMIT 1`,
          vchNo,
        );
        assert.deepEqual(
          audit.map((a) => a.du.trim()),
          [USERS.admin.user],
          `DELETE_USER ${JSON.stringify(audit)}`,
        );
        return {
          observation: `voucher ${vchNo}: DELETE_USER ${audit[0].du}`,
          expected: { deleteUser: USERS.admin.user },
          database: { audit },
          downstream: { deleted: true },
        };
      },
      {
        expected: { deleteUser: USERS.admin.user },
        observe: async (ctx) => ({
          audit: await ctx.rows(
            `SELECT "VCH_NO","DELETE_USER"::text du,"MAIN_USER"::text mu FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY row_id DESC LIMIT 2`,
          ),
        }),
      },
    ),

    C(
      'print.credit-note',
      'T16',
      'output',
      'The saved return prints as a credit note with its total',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        const documentRequest = page
          .context()
          .waitForEvent('request', (r) => /\/api\/sales\/credit-note\?/.test(r.url()), {
            timeout: 15_000,
          });
        await page.getByRole('button', { name: 'View Credit Note', exact: true }).click();
        const response = await page.request.get((await documentRequest).url());
        assert.equal(response.status(), 200, await response.text());
        const bytes = await response.body();
        const [h] = await header(ctx, vchNo);
        const shown = Number(h.tot).toLocaleString('en-IN', { minimumFractionDigits: 2 });
        assert(
          bytes.toString('utf8').includes(shown) || bytes.toString('utf8').includes(String(h.tot)),
          `credit note shows ${shown}`,
        );
        return {
          observation: `voucher ${vchNo}: credit note ${bytes.length} bytes with total ${shown}`,
          expected: 'credit note with total',
          output: bytes,
        };
      },
    ),

    C(
      'reopen.saved-panel',
      'T08',
      'read-only',
      'TR_SALE_RTN reopen: the saved return opens again with its customer and lines (Saved returns mode)',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createReturn(ctx, page);
        await page.getByRole('button', { name: 'Saved returns', exact: true }).click();
        // The panel clears the voucher box when its book settles (scope change), so pick the book first.
        const book = page.getByTestId('sale-return-saved-book').getByLabel('Configured book');
        await book.locator('option[value="SRT"]').waitFor({ state: 'attached' });
        await book.selectOption('SRT');
        await page.getByTestId('sale-return-saved-voucher').fill(vchNo);
        await page.waitForFunction(
          () => !document.querySelector('[data-testid="sale-return-saved-load"]')?.disabled,
          null,
          { timeout: 10_000 },
        );
        await page.getByTestId('sale-return-saved-load').click();
        await page
          .getByRole('heading', { name: new RegExp(`^Saved return #0*${Number(vchNo)}$`) })
          .waitFor();
        const panel = await page.locator('main.content').innerText();
        assert.match(panel, new RegExp(ITEMS.gold.code));
        return {
          observation: `saved return ${vchNo} reopened with ${ITEMS.gold.code}`,
          expected: 'reopens with its lines',
        };
      },
    ),

    {
      ...C(
        'edit.numeric',
        'T09',
        'mutation',
        "TR_SALE_RTN edits a saved return's weights and amounts and re-posts it",
        async () => ({}),
      ),
      blocked:
        'Numeric edit of a saved return is not exposed in the web yet; it is planned in the Return programme (N10 atomic numeric update, N11 saved-return Save/reopen). The Saved returns panel edits metadata only.',
    },

    C(
      'rights.clerk-no-return',
      'T11',
      'refusal',
      'USER_SET grants the clerk Sales Invoice only: no return can be created',
      async (ctx) => {
        const clerk = await ctx.session(as(USERS.clerk.user));
        const before = await counts(ctx);
        await clerk.page.goto('/txn/sale-return');
        await clerk.page.waitForTimeout(1500);
        const visible = await clerk.page
          .getByRole('button', { name: 'Save Return', exact: true })
          .isVisible()
          .catch(() => false);
        let status = null;
        if (visible) {
          await pickParty(clerk.page, PARTIES.local.code).catch(() => {});
          await fillLine(clerk.page, 0, LINE_R).catch(() => {});
          status = (await saveReturn(clerk.page).catch(() => null))?.status() ?? null;
          assert.notEqual(status, 201);
        }
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `clerk: form ${visible ? 'shown' : 'not shown'}, save ${status ?? 'not attempted'}; nothing written`,
          expected: 'no write',
          database: { before, after: before },
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
        const goldStock = async () =>
          (
            await ctx.rows(
              `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='-' THEN -"ITM_NWT" ELSE "ITM_NWT" END),0)::float n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
              ITEMS.gold.code,
            )
          )[0].n;
        const before = await goldStock();
        for (const s of [first, second]) {
          await openReturn(s.page);
          await s.page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
          await s.page.locator('tr').filter({ hasText: vchNo }).first().waitFor();
        }
        const del = async (s) => {
          const [r] = await Promise.all([
            s.page.waitForResponse(
              (x) => x.request().method() === 'DELETE' && /\/api\/sales-returns\//.test(x.url()),
            ),
            s.page
              .locator('tr')
              .filter({ hasText: vchNo })
              .first()
              .getByRole('button', { name: /Delete/ })
              .click(),
          ]);
          return r.status();
        };
        const one = await del(first);
        const two = await del(second);
        const after = await goldStock();
        assert.equal(one, 200);
        assert.equal(
          Math.round((before - after) * 1000) / 1000,
          10,
          `stock fell by ${before - after}, expected exactly 10`,
        );
        assert(
          two >= 400 && two < 500,
          `second delete answered ${two} (stock reversed once: ${before} → ${after})`,
        );
        return {
          observation: `first delete ${one}, second ${two}; stock ${before} → ${after}`,
          expected: 'second refused; stock reversed once',
          database: { before, after },
        };
      },
      {
        expected: { first: 200, second: '4xx (the voucher is gone)', stockReversed: 10 },
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
      'Duplicate submission creates one return',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openReturn(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_R);
        await page.getByRole('button', { name: 'Save Return', exact: true }).dblclick();
        await page.getByText('Return saved — Voucher #', { exact: false }).waitFor();
        await page.waitForTimeout(1500);
        const after = await counts(ctx);
        assert.equal(after.sl - before.sl, 1);
        return {
          observation: `created ${after.sl - before.sl}`,
          expected: 1,
          database: { before, after },
          downstream: { created: after.sl - before.sl },
        };
      },
    ),

    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'TR_SALE_RTN &Save mnemonic: Alt+S saves',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openReturn(page);
        await pickParty(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_R);
        await cell(page, 0, 7).press('Alt+s');
        await page
          .getByText('Return saved — Voucher #', { exact: false })
          .waitFor({ timeout: 5000 });
        const after = await counts(ctx);
        assert.equal(after.sl - before.sl, 1);
        return {
          observation: 'Alt+S saved the return',
          expected: 'save',
          database: { before, after },
          downstream: { created: 1 },
        };
      },
    ),

    C(
      'journey.sale-then-return',
      'T18',
      'mutation',
      'J07: a sale and its full return put the stock back, move the customer by the sale total less the return total, and the return reaches the sales-return register',
      async (ctx) => {
        const { page } = await ctx.session();
        const goldStock = async () =>
          (
            await ctx.rows(
              `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='-' THEN -"ITM_NWT" ELSE "ITM_NWT" END),0)::float n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
              ITEMS.gold.code,
            )
          )[0].n;
        const balance = async () =>
          (
            await ctx.rows(
              `SELECT coalesce(sum("DR_AMT"-"CR_AMT"),0)::float n FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
              PARTIES.local.code,
            )
          )[0].n;
        const [stock0, bal0] = [await goldStock(), await balance()];
        const sale = await sellOne(page);
        const ret = await createReturn(ctx, page);
        const [stock1, bal1] = [await goldStock(), await balance()];
        // The customer is debited the sale total and credited the return total. The two can differ by paise on
        // the desktop too (TR_SALE rounds its total with TOT_AMT_ROF, TR_SALE_RTN.cs:16405 always to whole rupees),
        // so the journey checks the ledger against the two stored documents; the amounts are checked in T03/T07.
        const total = async (book, vch) =>
          (
            await ctx.rows(
              `SELECT "TOT_AMT"::float n FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
              book,
              vch,
            )
          )[0]?.n;
        const [saleTot, retTot] = [await total('SL', sale), await total(BOOK, ret)];
        assert.equal(Math.round((stock1 - stock0) * 1000) / 1000, 0, 'stock back where it was');
        assert.equal(
          Math.round((bal1 - bal0) * 100) / 100,
          Math.round((saleTot - retTot) * 100) / 100,
          `customer moved by ${bal1 - bal0}; sale ${saleTot} − return ${retTot}`,
        );
        await page.goto('/reports/sales-return-register');
        await page.getByRole('button', { name: 'Run', exact: true }).click();
        await page.locator('table.grid tbody tr').filter({ hasText: ret }).first().waitFor();
        return {
          observation: `sale ${sale} + return ${ret}: stock Δ ${stock1 - stock0}, customer Δ ${bal1 - bal0}; return in the register`,
          expected: { stockDelta: 0, customerDelta: 'sale total − return total' },
          database: { stock0, stock1, bal0, bal1, saleTot, retTot },
          downstream: { register: true },
        };
      },
      {
        expected: { stockDelta: 0, customerDelta: 'sale total − return total' },
        observe: async (ctx) => ({
          customer: await ctx.rows(
            `SELECT "CO_BOOK","VCH_NO","DR_AMT"::float dr,"CR_AMT"::float cr FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2 ORDER BY row_id DESC LIMIT 8`,
            PARTIES.local.code,
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
        'config.amount-type',
        'T15',
        'mutation',
        'Playbook T15: SL_AMT_TYPE=F company prices a return on fine',
        async () => ({}),
      ),
      blocked: 'No settings-variant company in the catalogue yet (G174 / N166).',
    },
  ],
};
