import assert from 'node:assert/strict';
import {
  FIXTURE_MANIFEST,
  ITEMS,
  PARTIES,
  USERS,
  sentinelSnapshot,
} from '../fixtures/catalogue.mjs';

/**
 * Feature: Purchase → Purchase Invoice (desktop TR_PURC, CurBookHelp("PURCHASE")).
 *
 * Expected values are hand-computed from the desktop rules:
 * - TR_PURC.cs:7396 prices a line on the base CO_SET.PR_AMT_TYPE selects; seedCompany provisions 'F', so
 *   ITM_AMT = fine × rate with fine = round(net × touch / 100, 3); per-gram making LBR_AMT = net × making.
 * - Components and totals at 2 decimals (blank TOT_AMT_ROF / TAX_ROF on a web-provisioned company).
 * - GST on (Σ line net − discount); intra-state SGST = CGST = tax / 2; an inter-state supplier
 *   (AC_MAST.AC_GST_TYPE = 'I') is IGST — Ac_Tax derives geography from the party, the operator does not choose it.
 * - Purchase brings metal IN: MAIN_STOCK ITM_SIGN '+'. Delete removes it and writes DELETE_DATA.
 */

const BOOK = 'PR';
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

// Line G: GLD22 gross 20.5, net 20.000, touch 91.6, rate 6050, making 150 /g
//   fine   = 20 × 91.6 / 100 = 18.320;  metal = 18.32 × 6050 = 110,836.00;  labour = 20 × 150 = 3,000.00
//   net    = 113,836.00
// Line S: SLV92 gross 100.4, net 100.000, touch 92.5, rate 80, no making
//   fine   = 92.500;  metal = 92.5 × 80 = 7,400.00
const LINE_G = {
  item: ITEMS.gold.code,
  pcs: '1',
  gross: '20.5',
  net: '20',
  touch: '91.6',
  rate: '6050',
  making: '150',
};
const LINE_S = {
  item: ITEMS.silver.code,
  pcs: '3',
  gross: '100.4',
  net: '100',
  touch: '92.5',
  rate: '80',
};
const EXPECT_G = { fine: 18.32, metal: 110836, labour: 3000, net: 113836 };
const EXPECT_S = { fine: 92.5, metal: 7400, labour: 0, net: 7400 };
/** Line G alone, 3% GST: tax = 113,836 × 3% = 3,415.08; halves 1,707.54; total 117,251.08. */
const ONE = { net: 113836, tax: 3415.08, cgst: 1707.54, sgst: 1707.54, total: 117251.08 };

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

async function openPurchase(page) {
  await page.goto('/txn/purchase');
  await page.getByRole('heading', { name: 'Purchase Invoice', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK, 'the provisioned PURCHASE book is selected');
  return book;
}
async function pickSupplier(page, code) {
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
async function save(page, label = 'Save Purchase') {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/purchases(\/|$)/.test(new URL(r.url()).pathname) &&
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
    .getByTestId('purchase-loaded')
    .filter({ hasText: `Loaded #${vchNo}` })
    .waitFor();
}
async function createOne(ctx, page, { supplier = PARTIES.local.code, line = LINE_G } = {}) {
  await openPurchase(page);
  await pickSupplier(page, supplier);
  await fillLine(page, 0, line);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  const vchNo = String((await response.json()).vchNo).padStart(5, '0');
  await page.getByText(`Saved — Voucher #${Number(vchNo)}`, { exact: false }).waitFor();
  return vchNo;
}

const header = (ctx, v) =>
  ctx.rows(
    `SELECT "VCH_NO","AC_CODE","NET_AMT"::float net,"DISC_AMT"::float disc,"TAX_AMT"::float tax,"CGST_TAX"::float cgst,
            "SGST_TAX"::float sgst,"IGST_TAX"::float igst,"TOT_AMT"::float tot
       FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
    v,
  );
const lines = (ctx, v) =>
  ctx.rows(
    `SELECT "SR_NO"::int sr,"IT_CODE" it,"ITM_NWT"::float nwt,"ITM_FINE"::float fine,"ITM_AMT"::float amt,"LBR_AMT"::float lbr,"NET_AMT"::float net
       FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
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
      `SELECT (SELECT count(*) FROM "PR_DATA" WHERE tenant_id=$1)::int pr,(SELECT count(*) FROM "PR_DETL" WHERE tenant_id=$1)::int detl,
              (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int ac,
              (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}')::int stk`,
    )
  )[0];
const balanced = (rows) => {
  const dr = rows.reduce((s, r) => s + r.dr, 0);
  const cr = rows.reduce((s, r) => s + r.cr, 0);
  return dr > 0 && Math.abs(dr - cr) < 0.005;
};
const supplierCredit = (rows, ac) =>
  rows.filter((r) => r.ac === ac).reduce((s, r) => s + r.cr - r.dr, 0);
async function registerRow(page, vchNo) {
  await page.goto('/reports/purchase-register');
  await page.getByRole('button', { name: 'Run', exact: true }).click();
  const row = page.locator('table.grid tbody tr').filter({ hasText: vchNo }).first();
  await row.waitFor();
  return row.innerText();
}

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `purchase-invoice.${id}`,
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

export const purchaseInvoice = {
  feature: 'purchase-invoice',
  title: 'Purchase → Purchase Invoice (TR_PURC)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/txn/purchase/page.tsx',
    'web/apps/api/src/modules/purchase/purchase.ts',
    'web/apps/web/test/features/modules/purchaseInvoice.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    PR_AMT_TYPE: 'F (seedCompany)',
    TOT_AMT_ROF: 'blank → 2dp',
    TAX_ROF: 'blank → 2dp',
  },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'CurBookHelp("PURCHASE"): only PURCHASE books; tax default 3',
      async (ctx) => {
        const { page } = await ctx.session();
        const book = await openPurchase(page);
        const offered = (await book.locator('option').allTextContents()).filter((t) =>
          t.includes('—'),
        );
        assert.deepEqual(offered, ['PR — Purchase']);
        assert.equal(await field(page, 'Tax %').inputValue(), '3');
        await ctx.shot(page, 'defaults');
        return {
          observation: `books ${JSON.stringify(offered)}, tax 3`,
          expected: { offered: ['PR — Purchase'], tax: '3' },
        };
      },
    ),

    C(
      'lookup.code-enter-at-once',
      'T17',
      'read-only',
      'TR_PURC.cs:14619-14628 tAcCode_KeyDown: Enter looks the typed code up exactly; a list fetched for older text is never picked (G185)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openPurchase(page);
        const party = page.getByPlaceholder('search accounts… (F1)').first();
        await party.click();
        await party.fill('');
        // Let the list for the empty box arrive first: that stale list is what Enter used to pick from.
        await page.waitForTimeout(400);
        await party.pressSequentially(PARTIES.local.code);
        await party.press('Enter');
        const name = field(page, 'Supplier Name');
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
      'formula.preview',
      'T03',
      'read-only',
      'TR_PURC.cs:7396: fine basis when PR_AMT_TYPE=F',
      async (ctx) => {
        const { page } = await ctx.session();
        await openPurchase(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_G);
        const row = grid(page).locator('tbody tr').first();
        await row.filter({ hasText: '18.32' }).waitFor();
        await row.filter({ hasText: /1,13,836|113,836/ }).waitFor(); // en-IN groups lakhs: 1,13,836
        await ctx.shot(page, 'preview');
        return { observation: 'preview fine 18.32, line 113,836', expected: EXPECT_G };
      },
    ),

    C(
      'create.single-line',
      'T07',
      'mutation',
      'TR_PURC save: PR_DATA + PR_DETL + MAIN_STOCK(+) + AC_DATA balanced; supplier credited',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await sentinelSnapshot(ctx.owner);
        const vchNo = await createOne(ctx, page);
        const [h] = await header(ctx, vchNo);
        const l = await lines(ctx, vchNo);
        const g = await ledger(ctx, vchNo);
        const s = await stock(ctx, vchNo);
        assert.deepEqual(
          [h.net, h.tax, h.cgst, h.sgst, h.tot],
          [ONE.net, ONE.tax, ONE.cgst, ONE.sgst, ONE.total],
        );
        assert.deepEqual(
          l.map((x) => [x.it, x.nwt, x.fine, x.amt, x.lbr, x.net]),
          [[ITEMS.gold.code, 20, EXPECT_G.fine, EXPECT_G.metal, EXPECT_G.labour, EXPECT_G.net]],
        );
        assert(balanced(g), `ledger must balance: ${JSON.stringify(g)}`);
        assert.equal(
          Math.round(supplierCredit(g, PARTIES.local.code) * 100) / 100,
          ONE.total,
          'supplier credited with the bill total',
        );
        assert.deepEqual(s, [{ it: ITEMS.gold.code, sign: '+', nwt: 20 }]);
        assert.deepEqual(await sentinelSnapshot(ctx.owner), before);
        const reg = await registerRow(page, vchNo);
        return {
          observation: `voucher ${vchNo}: net ${h.net} tax ${h.tax} total ${h.tot}; stock +20; ${g.length} balanced legs; register row present`,
          expected: { line: EXPECT_G, totals: ONE },
          database: { header: h, lines: l, ledger: g, stock: s },
          downstream: { register: reg },
        };
      },
    ),

    C(
      'create.two-groups',
      'T05',
      'mutation',
      'Gold (PURC_AC PURCHASE) + silver (SLVPURC) lines on one bill keep their own values; Σ = header',
      async (ctx) => {
        // net = 113,836 + 7,400 = 121,236; tax = 3,637.08
        const { page } = await ctx.session();
        await openPurchase(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_G);
        await page.getByRole('button', { name: '+ Add line', exact: true }).click();
        await fillLine(page, 1, LINE_S);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        const l = await lines(ctx, vchNo);
        assert.deepEqual(
          l.map((x) => [x.it, x.amt, x.fine]),
          [
            [ITEMS.gold.code, EXPECT_G.metal, EXPECT_G.fine],
            [ITEMS.silver.code, EXPECT_S.metal, EXPECT_S.fine],
          ],
        );
        assert.deepEqual([h.net, h.tax], [121236, 3637.08]);
        const g = await ledger(ctx, vchNo);
        assert(balanced(g));
        // G176: each group's expense account is debited with its own line (Ac_Ledr.cs:410 line path).
        assert.deepEqual(
          g
            .filter((x) => x.ac === 'PURCHASE' || x.ac === 'SLVPURC')
            .map((x) => [x.ac, x.dr])
            .sort(),
          [
            ['PURCHASE', EXPECT_G.net],
            ['SLVPURC', EXPECT_S.net],
          ],
        );
        return {
          observation: `voucher ${vchNo}: gold + silver lines, net ${h.net}, tax ${h.tax}`,
          expected: { net: 121236, tax: 3637.08 },
          database: { header: h, lines: l, ledger: g },
          downstream: { balanced: true },
        };
      },
      {
        expected: { net: 121236, tax: 3637.08 },
        observe: async (ctx) => ({ counts: await counts(ctx) }),
      },
    ),

    C(
      'create.interstate-supplier',
      'T02',
      'mutation',
      'Ac_Tax: AC_GST_TYPE=I is IGST; the desktop derives it from the supplier, the operator does not pick it',
      async (ctx) => {
        const { page } = await ctx.session();
        await openPurchase(page);
        await pickSupplier(page, PARTIES.interState.code);
        await fillLine(page, 0, LINE_G);
        const response = await save(page);
        assert.equal(
          response.status(),
          201,
          `inter-state supplier without a manual toggle: ${response.status()} ${await response.text()}`,
        );
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        assert.equal(h.igst, ONE.tax);
        assert.equal(h.cgst + h.sgst, 0);
        return {
          observation: `voucher ${vchNo}: IGST ${h.igst}`,
          expected: { igst: ONE.tax },
          database: { header: h },
          downstream: { igst: h.igst },
        };
      },
      {
        expected: { igst: ONE.tax, operatorToggle: 'not needed' },
        observe: async (ctx) => ({ counts: await counts(ctx) }),
      },
    ),

    C(
      'create.urd-no-gst',
      'T02',
      'mutation',
      'URD purchase (unregistered dealer): no GST',
      async (ctx) => {
        const { page } = await ctx.session();
        await openPurchase(page);
        await pickSupplier(page, PARTIES.local.code);
        await field(page, 'URD (no GST)').selectOption({ index: 1 });
        await fillLine(page, 0, LINE_G);
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        assert.equal(h.tax, 0);
        assert.equal(h.tot, EXPECT_G.net);
        const g = await ledger(ctx, vchNo);
        assert(balanced(g));
        return {
          observation: `voucher ${vchNo}: URD tax ${h.tax}, total ${h.tot}`,
          expected: { tax: 0, total: EXPECT_G.net },
          database: { header: h, ledger: g },
          downstream: { balanced: true },
        };
      },
    ),

    C(
      'create.discount',
      'T02',
      'mutation',
      'GST on (net − discount): 113,836 − 836 = 113,000; tax 3,390',
      async (ctx) => {
        const { page } = await ctx.session();
        await openPurchase(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_G);
        await field(page, 'Discount ₹').fill('836');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        const vchNo = String((await response.json()).vchNo).padStart(5, '0');
        const [h] = await header(ctx, vchNo);
        assert.deepEqual([h.disc, h.tax, h.tot], [836, 3390, 116390]);
        return {
          observation: `voucher ${vchNo}: discount ${h.disc}, tax ${h.tax}, total ${h.tot}`,
          expected: { disc: 836, tax: 3390, total: 116390 },
          database: { header: h },
          downstream: { total: h.tot },
        };
      },
    ),

    C(
      'reopen.round-trip',
      'T08',
      'read-only',
      'Reopen returns every saved field to the screen',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOne(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(page, vchNo);
        const values = await Promise.all(
          [1, 4, 5, 6, 7, 8].map((n) => cell(page, 0, n).inputValue()),
        );
        assert.deepEqual(values, [ITEMS.gold.code, '20.5', '20', '91.6', '6050', '150']);
        return {
          observation: `voucher ${vchNo} reopened: ${values.join(' / ')}`,
          expected: LINE_G,
        };
      },
    ),

    C(
      'edit.unchanged-no-op',
      'T08',
      'mutation',
      'Unchanged reopen → save changes no business value',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOne(ctx, page);
        const before = {
          h: await header(ctx, vchNo),
          l: await lines(ctx, vchNo),
          g: await ledger(ctx, vchNo),
          s: await stock(ctx, vchNo),
        };
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(page, vchNo);
        const response = await save(page, 'Update Purchase');
        assert.equal(response.status(), 200, await response.text());
        const after = {
          h: await header(ctx, vchNo),
          l: await lines(ctx, vchNo),
          g: await ledger(ctx, vchNo),
          s: await stock(ctx, vchNo),
        };
        assert.deepEqual(after, before);
        return {
          observation: `voucher ${vchNo}: identical after unchanged save`,
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
      'Edit re-prices on fine: rate 6200 → metal 18.32 × 6200 = 113,584; net 116,584; tax 3,497.52',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOne(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(page, vchNo);
        await cell(page, 0, 7).fill('6200');
        const response = await save(page, 'Update Purchase');
        assert.equal(response.status(), 200, await response.text());
        const [h] = await header(ctx, vchNo);
        const [l] = await lines(ctx, vchNo);
        assert.deepEqual([l.amt, h.net, h.tax], [113584, 116584, 3497.52]);
        const g = await ledger(ctx, vchNo);
        assert(balanced(g));
        return {
          observation: `voucher ${vchNo}: line ${l.amt}, net ${h.net}, tax ${h.tax}`,
          expected: { metal: 113584, net: 116584, tax: 3497.52 },
          database: { header: h, line: l, ledger: g },
          downstream: { balanced: true },
        };
      },
    ),

    C(
      'delete.reverses',
      'T10',
      'mutation',
      'Delete removes stock (+) and ledger and writes DELETE_DATA',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOne(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(page, vchNo);
        const [response] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'DELETE' && /\/api\/purchases\//.test(r.url()),
          ),
          // The loaded-voucher Delete beside Load; the Recent vouchers list has its own per-row Delete.
          page.getByRole('button', { name: 'Delete', exact: true }).first().click(),
        ]);
        assert.equal(response.status(), 200, await response.text());
        assert.deepEqual(
          [
            await header(ctx, vchNo),
            await lines(ctx, vchNo),
            await ledger(ctx, vchNo),
            await stock(ctx, vchNo),
          ],
          [[], [], [], []],
        );
        const audit = await ctx.rows(
          `SELECT count(*)::int n FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        assert(audit[0].n >= 1);
        return {
          observation: `voucher ${vchNo} deleted; DELETE_DATA ${audit[0].n}`,
          expected: 'all removed + DELETE_DATA',
          database: { deleteData: audit[0].n },
          downstream: { remaining: 0 },
        };
      },
    ),

    C('print.bill', 'T16', 'output', 'TR_PURC print: the saved purchase bill', async (ctx) => {
      const { page } = await ctx.session();
      const vchNo = await createOne(ctx, page);
      const documentRequest = page
        .context()
        .waitForEvent('request', (r) => /\/api\/purchases\/invoice\?/.test(r.url()), {
          timeout: 15_000,
        });
      await page.getByRole('button', { name: 'View Purchase Bill', exact: true }).click();
      const url = (await documentRequest).url();
      const response = await page.request.get(url);
      assert.equal(response.status(), 200, await response.text());
      const bytes = await response.body();
      const text = bytes.toString('utf8');
      assert.match(
        text,
        /113,836|1,13,836|117,251|1,17,251/,
        'the bill shows the line or bill total',
      );
      return {
        observation: `voucher ${vchNo}: ${response.headers()['content-type']} ${bytes.length} bytes`,
        expected: 'bill with totals',
        output: bytes,
      };
    }),

    C(
      'refusal.no-lines',
      'T06',
      'refusal',
      'A purchase needs at least one item line; nothing written',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openPurchase(page);
        await pickSupplier(page, PARTIES.local.code);
        const response = await save(page);
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
      'refusal.unknown-item',
      'T04',
      'refusal',
      'A typed item code not in ITEM_MAST must not post',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openPurchase(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, { ...LINE_G, item: 'ZZZZZ' });
        const response = await save(page);
        assert(response.status() >= 400 && response.status() < 500, `status ${response.status()}`);
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `refused ${response.status()}`,
          expected: '4xx + no write',
          database: { before, after: before },
        };
      },
    ),

    C(
      'rights.clerk-no-purchase',
      'T11',
      'refusal',
      'USER_SET grants the clerk Sales Invoice only: the server refuses a purchase',
      async (ctx) => {
        const clerk = await ctx.session(as(USERS.clerk.user));
        const before = await counts(ctx);
        await clerk.page.goto('/txn/purchase');
        await clerk.page.waitForTimeout(1500);
        const canSave = await clerk.page
          .getByRole('button', { name: 'Save Purchase', exact: true })
          .isVisible()
          .catch(() => false);
        let status = null;
        if (canSave) {
          await pickSupplier(clerk.page, PARTIES.local.code).catch(() => {});
          await fillLine(clerk.page, 0, LINE_G).catch(() => {});
          const response = await save(clerk.page).catch(() => null);
          status = response?.status() ?? null;
          assert.notEqual(
            status,
            201,
            'a clerk without the purchase right must not create a purchase',
          );
        }
        assert.deepEqual(await counts(ctx), before);
        return {
          observation: `clerk: form ${canSave ? 'shown' : 'not shown'}, save ${status ?? 'not attempted'}; nothing written`,
          expected: 'refused, no write',
          database: { before, after: before },
        };
      },
    ),

    C(
      'concurrency.stale-second-save',
      'T12',
      'refusal',
      'Two operators on one purchase: the stale second save must not overwrite the first',
      async (ctx) => {
        const first = await ctx.session(as(USERS.admin.user, 'operator-1'));
        const vchNo = await createOne(ctx, first.page);
        const second = await ctx.session(as(USERS.admin.user, 'operator-2'));
        await first.page.getByRole('button', { name: 'New', exact: true }).click();
        await loadVoucher(first.page, vchNo);
        await openPurchase(second.page);
        await loadVoucher(second.page, vchNo);
        await cell(first.page, 0, 7).fill('6200');
        assert.equal((await save(first.page, 'Update Purchase')).status(), 200);
        await cell(second.page, 0, 7).fill('6400');
        const two = await save(second.page, 'Update Purchase');
        const [l] = await lines(ctx, vchNo);
        assert.equal(two.status(), 409, `stale save answered ${two.status()}; line now ${l.amt}`);
        return {
          observation: `second save ${two.status()}; line ${l.amt}`,
          expected: '409; first save (113,584) survives',
          database: { line: l },
        };
      },
      {
        expected: { secondSave: 409, surviving: 113584 },
        observe: async (ctx) => ({
          lines: await ctx.rows(
            `SELECT "VCH_NO","ITM_AMT"::float amt FROM "PR_DETL" WHERE tenant_id=$1 ORDER BY "VCH_NO"`,
          ),
        }),
      },
    ),

    C(
      'retry.double-click',
      'T13',
      'mutation',
      'Duplicate submission creates one purchase',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openPurchase(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_G);
        await page.getByRole('button', { name: 'Save Purchase', exact: true }).dblclick();
        await page.getByText('Saved — Voucher #', { exact: false }).waitFor();
        await page.waitForTimeout(1500);
        const after = await counts(ctx);
        assert.equal(after.pr - before.pr, 1);
        return {
          observation: `created ${after.pr - before.pr}`,
          expected: 1,
          database: { before, after },
          downstream: { created: after.pr - before.pr },
        };
      },
    ),

    C(
      'keyboard.voucher-number-keys',
      'T17',
      'read-only',
      'TR_PURC.cs:14407-14432 tVchNo_KeyDown: Down and Up step to the previous and next saved voucher (BtnFirst/BtnLast :14476-14534), Up past the last is a new voucher and then Last Record..., Enter opens the typed number and moves to the date, F1 opens the voucher list',
      async (ctx) => {
        const { page } = await ctx.session();
        const first = await createOne(ctx, page);
        const second = await createOne(ctx, page);
        await page.getByRole('button', { name: 'New', exact: true }).click();
        const box = page.getByLabel('Voucher No', { exact: true });
        const loaded = page.getByTestId('purchase-loaded');
        const note = page.getByTestId('voucher-number-note');
        const seen = [];
        const expectLoaded = async (vchNo, step) => {
          await loaded.filter({ hasText: `Loaded #${vchNo}` }).waitFor();
          seen.push(`${step}: #${vchNo}`);
        };
        await box.focus();
        // Down from the new voucher opens the last saved one, then the one before it.
        await page.keyboard.press('ArrowDown');
        await expectLoaded(second, 'Down');
        await page.keyboard.press('ArrowDown');
        await expectLoaded(first, 'Down');
        assert.equal(
          await box.evaluate((el) => el === document.activeElement),
          true,
          'Up/Down keep the focus in the box',
        );
        // Up steps forward; past the last saved voucher it is a new voucher, then "Last Record...".
        await page.keyboard.press('ArrowUp');
        await expectLoaded(second, 'Up');
        await page.keyboard.press('ArrowUp');
        await loaded.waitFor({ state: 'detached' });
        assert.equal(await box.inputValue(), '', 'a blank new voucher');
        seen.push('Up: new voucher');
        await page.keyboard.press('ArrowUp');
        await note.filter({ hasText: 'Last Record...' }).waitFor();
        seen.push('Up: Last Record...');
        // Enter opens the typed number and moves to the voucher date.
        await box.fill(first);
        await page.keyboard.press('Enter');
        await expectLoaded(first, 'Enter');
        await page.waitForFunction(() => document.activeElement?.getAttribute('type') === 'date');
        seen.push('Enter: focus on the date');
        // F1 opens the voucher list on its newest voucher; Down moves to the next row and Enter opens it.
        await box.focus();
        await page.keyboard.press('F1');
        await page.waitForFunction(() => document.activeElement?.hasAttribute('data-voucher-load'));
        await page.keyboard.press('ArrowDown');
        await page.keyboard.press('Enter');
        await expectLoaded(first, 'F1 list');
        return {
          observation: seen.join('; '),
          expected: [
            `Down: #${second}`,
            `Down: #${first}`,
            `Up: #${second}`,
            'Up: new voucher',
            'Up: Last Record...',
            `Enter: #${first}`,
            'Enter: focus on the date',
            `F1 list: #${first}`,
          ].join('; '),
        };
      },
    ),
    C(
      'print.after-access-expiry',
      'T16',
      'output',
      'G180: View Purchase Bill still opens after the 15-minute access cookie has expired (the session refreshes first)',
      async (ctx) => {
        // Its own login slot: the refresh rotates this slot's refresh token, which no other case may reuse.
        const { page } = await ctx.session(as(USERS.admin.user, 'access-expiry-purchase'));
        const vchNo = await createOne(ctx, page);
        // As if the access cookie had expired: the browser drops it and keeps the refresh cookie.
        await page.context().clearCookies({ name: 'access' });
        const refreshed = page.waitForRequest(
          (r) => r.url().endsWith('/api/auth/refresh') && r.method() === 'POST',
          { timeout: 15_000 },
        );
        const [popup] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByRole('button', { name: 'View Purchase Bill', exact: true }).click(),
        ]);
        await refreshed;
        const document = await popup.waitForResponse(
          (r) => /\/api\/purchases\/invoice\?/.test(r.url()),
          { timeout: 15_000 },
        );
        const body = await document.body();
        await popup.close();
        assert.equal(document.status(), 200, body.toString('utf8').slice(0, 200));
        assert.ok(
          !body.toString('utf8').includes('unauthenticated'),
          'the window shows the document',
        );
        return {
          observation: `voucher ${vchNo}: after the access cookie was dropped, View Purchase Bill refreshed the session and the window got ${document.status()} (${body.length} bytes)`,
          expected: 'the document opens (200), not {"error":"unauthenticated"}',
          output: body,
        };
      },
    ),

    C(
      'print.date-with-year',
      'T16',
      'output',
      'G36 (D19): the printed purchase bill and the recent list show the voucher date as dd/MM/yyyy, with its year',
      async (ctx) => {
        const { page } = await ctx.session();
        const vchNo = await createOne(ctx, page);
        const [bill] = await ctx.rows(
          `SELECT to_char("VCH_DATE",'DD/MM/YYYY') shown FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "VCH_NO"=$2`,
          vchNo,
        );
        const documentRequest = page
          .context()
          .waitForEvent('request', (r) => /\/api\/purchases\/invoice\?/.test(r.url()), {
            timeout: 15_000,
          });
        const [popup] = await Promise.all([
          page.waitForEvent('popup'),
          page.getByRole('button', { name: 'View Purchase Bill', exact: true }).click(),
        ]);
        const url = new URL((await documentRequest).url());
        url.searchParams.set('format', 'html');
        const html = await (await page.request.get(url.toString())).text();
        await popup.close();
        assert.ok(html.includes(bill.shown), `the purchase bill shows ${bill.shown}`);
        await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
        const row = page.locator('table.grid tr', { hasText: vchNo }).last();
        await row.waitFor();
        const listed = (await row.locator('td').nth(1).innerText()).trim();
        assert.equal(listed, bill.shown, 'the recent list shows dd/MM/yyyy');
        return {
          observation: `purchase bill and recent list show ${listed}`,
          expected: bill.shown,
          output: Buffer.from(html),
        };
      },
    ),

    C(
      'keyboard.alt-s-saves',
      'T17',
      'mutation',
      'TR_PURC &Save mnemonic: Alt+S saves',
      async (ctx) => {
        const { page } = await ctx.session();
        const before = await counts(ctx);
        await openPurchase(page);
        await pickSupplier(page, PARTIES.local.code);
        await fillLine(page, 0, LINE_G);
        await cell(page, 0, 7).press('Alt+s');
        await page.getByText('Saved — Voucher #', { exact: false }).waitFor({ timeout: 5000 });
        const after = await counts(ctx);
        assert.equal(after.pr - before.pr, 1);
        return {
          observation: 'Alt+S saved',
          expected: 'save',
          database: { before, after },
          downstream: { created: 1 },
        };
      },
      {
        expected: { keyboard: 'Alt+S', created: 1 },
        observe: async (ctx) => ({ counts: await counts(ctx) }),
      },
    ),

    C(
      'journey.stock-and-register',
      'T18',
      'mutation',
      'J02: the purchase raises item stock and appears in the purchase register and day book',
      async (ctx) => {
        const { page } = await ctx.session();
        const stockOf = async () =>
          (
            await ctx.rows(
              `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='-' THEN -"ITM_NWT" ELSE "ITM_NWT" END),0)::float n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
              ITEMS.gold.code,
            )
          )[0].n;
        const before = await stockOf();
        const vchNo = await createOne(ctx, page);
        const after = await stockOf();
        assert.equal(Math.round((after - before) * 1000) / 1000, 20);
        const reg = await registerRow(page, vchNo);
        await page.goto('/reports/day-book');
        await page.getByRole('button', { name: 'Run', exact: true }).click();
        const day = await page.locator('table.grid').first().innerText();
        assert.match(day, new RegExp(vchNo));
        return {
          observation: `stock ${before} → ${after}; register and day book show ${vchNo}`,
          expected: { stockDelta: 20 },
          database: { before, after },
          downstream: { register: reg, dayBook: true },
        };
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
        'Playbook T15: PR_AMT_TYPE=N company prices on net',
        async () => ({}),
      ),
      blocked: 'No settings-variant company in the catalogue yet (G174 / N166).',
    },
  ],
};
