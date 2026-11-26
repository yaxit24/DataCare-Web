import assert from 'node:assert/strict';
import { ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import {
  cancelTag,
  deleteCancel,
  deleteOpening,
  deleteReturn,
  deleteSale,
  hallmarkPurchase,
  deletePurchase,
  openTags,
  returnTag,
  sellTag,
} from './inventoryFlows.mjs';

/**
 * HuId Report T18 journey and voucher zoom (WP-18 cases.md "T18 Full journey", T05 drill): the tags are made by the
 * real screens, then the report's three views are read after every voucher.
 *
 * - JT-1 and JT-2 come from Tag Opening, JT-3 and JT-4 from the hallmarked Purchase (Purchase with
 *   CO_SET_NEW.PURC_WITH_HMTAX = Y opens TR_PURC_HM, MDI_FORM.cs:7866, whose HUID column carries HUJ003 on JT-3). The
 *   desktop Tag Opening has no HuId entry (its HuId column is hidden, TR_TAG_OPBL.cs:5128 width 0), so JT-1 has no
 *   HUID and the first-slot count of stage 1 is one (JT-3), not the two the case text lists.
 * - A dedicated JH item/product narrows every view; Search remains a HUID-only search as on the desktop.
 */
const TENANT = 'feature-e2e';
const RUN = Date.now().toString(36).slice(-4).toUpperCase();
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run) => ({
  id,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : ['browser', 'expected'],
  run,
});
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const pad2 = (n) => String(n).padStart(2, '0');
const ui = (d) => `${pad2(d.getDate())}/${pad2(d.getMonth() + 1)}/${d.getFullYear()}`;
const WINDOW = { from: `01/04/${startYear}`, to: ui(now) };
const TAGS = [1, 2, 3, 4].map((n) => `JT${RUN}${n}`);

const button = (page, name) => page.getByRole('button', { name, exact: true });
const rowsOf = (page) =>
  page.locator(
    '[role="grid"] [role="row"]:not([data-testid="huid-totals"]):has([data-col="tagNo"])',
  );

async function openReport(page) {
  await page.goto('/reports/huid');
  await page.getByRole('heading', { name: 'HuId Report', exact: true }).waitFor();
  await page.getByLabel('From', { exact: true }).fill(WINDOW.from);
  await page.getByLabel('To', { exact: true }).fill(WINDOW.to);
  await page.getByLabel('Product', { exact: true }).fill('JH');
}
/** One view of the report as { tags, totals }. */
async function readView(page, name) {
  await Promise.all([
    page.waitForResponse(
      (r) => new URL(r.url()).pathname === '/api/reports/huid' && r.request().method() === 'GET',
    ),
    button(page, name).click(),
  ]);
  await page
    .getByTestId('huid-totals')
    .waitFor()
    .catch(() => undefined);
  await page.waitForTimeout(300);
  const tags = await rowsOf(page).evaluateAll((rows) =>
    rows.map((row) => row.querySelector('[data-col="tagNo"]').textContent.trim()),
  );
  const totals = await page
    .getByTestId('huid-totals')
    .evaluate((row) =>
      Object.fromEntries(
        [...row.querySelectorAll('[data-col]')].map((td) => [
          td.getAttribute('data-col'),
          td.textContent.trim(),
        ]),
      ),
    )
    .catch(() => ({}));
  return { tags: tags.sort(), totals };
}
const num = (text) => Number(String(text ?? '').replaceAll(',', '') || 0);

/** Creates JT-1..JT-4 and returns the voucher numbers. */
async function makeTags(ctx, page, life) {
  // RP_HUID.cs:1669-1689 searches HUID slots only. Isolate by a dedicated product, not tag-prefix Search.
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME")
     SELECT $1::text,'01','JH','HUID JOURNEY' WHERE NOT EXISTS
     (SELECT 1 FROM "PRODUCT_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "PR_CODE"='JH')`,
    TENANT,
  );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
     SELECT tenant_id,"CO_CODE",'JH','HUID JOURNEY',"IT_TYPE",'JH',"GR_CODE" FROM "ITEM_MAST"
     WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2
       AND NOT EXISTS (SELECT 1 FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"='JH')`,
    TENANT,
    ITEMS.gold.code,
  );
  const opened = await openTags(page, [
    { item: 'JH', tag: TAGS[0], gross: '5', net: '4.8', touch: '91.6' },
    { item: 'JH', tag: TAGS[1], gross: '7', net: '6.7', touch: '91.6' },
  ]);
  life.opening = opened.vchNo;
  life.purchase = await hallmarkPurchase(ctx, page, [
    {
      item: 'JH',
      tag: TAGS[2],
      huid: 'HUJ003',
      pcs: '1',
      gross: '6',
      net: '5.7',
      touch: '91.6',
      rate: '6000',
    },
    { item: 'JH', tag: TAGS[3], pcs: '1', gross: '3', net: '2.9', touch: '91.6', rate: '6000' },
  ]);
}
async function teardown(ctx, page, life) {
  const attempt = async (work) => {
    try {
      await work();
    } catch {
      // not created, or already deleted
    }
  };
  if (life.returned) await attempt(() => deleteReturn(page, life.returned));
  if (life.cancel) await attempt(() => deleteCancel(page, life.cancel));
  if (life.sale) await attempt(() => deleteSale(page, life.sale));
  if (life.purchase) await attempt(() => deletePurchase(ctx, page, life.purchase));
  if (life.opening) await attempt(() => deleteOpening(page, life.opening));
  for (const table of ['MAIN_STOCK', 'BAR_IDTL', 'BAR_DETL'])
    await ctx.owner.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO"=ANY($2::text[])`,
      TENANT,
      TAGS,
    );
}
const sameTags = (actual, wanted, message) => assert.deepEqual(actual, [...wanted].sort(), message);

export const huidJourneyCases = [
  C(
    'huid-report.journey.stage-1-tags-and-purchase-in-view',
    'T18',
    'mutation',
    'WP-18 cases.md T18 stage 1: JT-1 and JT-2 through Tag Opening, JT-3 and JT-4 through the hallmarked Purchase (TR_PURC_HM, HUID column); In lists the four tags, Out none, Stock the four',
    async (ctx) => {
      const { page } = await ctx.session(as(USERS.admin.user, 'huid-journey'));
      const life = {};
      try {
        await makeTags(ctx, page, life);
        await openReport(page);
        const inView = await readView(page, 'In Tag');
        sameTags(inView.tags, TAGS, 'In: the four tags');
        const out = await readView(page, 'Out Tag');
        assert.deepEqual(out.tags, [], 'Out: none');
        const stock = await readView(page, 'Stock Tag');
        sameTags(stock.tags, TAGS, 'Stock: the four tags');
        const stored = await ctx.rows(
          `SELECT "TAG_NO" tag, coalesce("HM_ID",'') hm, "ITM_GWT"::float g, "ITM_NWT"::float n FROM "BAR_DETL"
            WHERE tenant_id=$1 AND "TAG_NO"=ANY($2::text[]) ORDER BY "TAG_NO"`,
          TAGS,
        );
        assert.deepEqual(
          stored.map((r) => [r.tag, r.hm.trim(), r.g, r.n]),
          [
            [TAGS[0], '', 5, 4.8],
            [TAGS[1], '', 7, 6.7],
            [TAGS[2], 'HUJ003', 6, 5.7],
            [TAGS[3], '', 3, 2.9],
          ],
        );
        assert.equal(num(inView.totals.grwt), 21);
        assert.ok(Math.abs(num(inView.totals.netWt) - 20.1) < 1e-6);
        return {
          observation: `In ${inView.tags.length}, Out ${out.tags.length}, Stock ${stock.tags.length}; gross ${inView.totals.grwt}, net ${inView.totals.netWt}; HUID ${stored.filter((r) => r.hm.trim()).length}`,
          expected: 'In 4 (Grwt 21.000, NetWt 20.100), Out 0, Stock 4',
          database: { tags: stored },
          downstream: { in: inView.tags.length, out: out.tags.length, stock: stock.tags.length },
        };
      } finally {
        await teardown(ctx, page, life);
      }
    },
  ),
  C(
    'huid-report.journey.stage-2-sale-out-and-stock',
    'T18',
    'mutation',
    'WP-18 cases.md T18 stage 2: JT-1 sold through the Sales screen (tag pick): In stays 4, Out 1 (JT-1), Stock 3; In = Stock + sold and not returned',
    async (ctx) => {
      const { page } = await ctx.session(as(USERS.admin.user, 'huid-journey'));
      const life = {};
      try {
        await makeTags(ctx, page, life);
        life.sale = await sellTag(page, TAGS[0]);
        await openReport(page);
        const inView = await readView(page, 'In Tag');
        const out = await readView(page, 'Out Tag');
        const stock = await readView(page, 'Stock Tag');
        sameTags(inView.tags, TAGS, 'In unchanged');
        sameTags(out.tags, [TAGS[0]], 'Out: the sold tag');
        sameTags(stock.tags, TAGS.slice(1), 'Stock: the other three');
        assert.equal(num(out.totals.grwt), 5);
        assert.equal(inView.tags.length, stock.tags.length + out.tags.length);
        return {
          observation: `In ${inView.tags.length} = Stock ${stock.tags.length} + sold ${out.tags.length}`,
          expected: 'In 4, Out 1 (JT-1 5.000 / 4.800), Stock 3',
          database: { sale: life.sale },
          downstream: { in: inView.tags.length, out: out.tags.length, stock: stock.tags.length },
        };
      } finally {
        await teardown(ctx, page, life);
      }
    },
  ),
  C(
    'huid-report.journey.stage-3-return-views-agree',
    'T18',
    'mutation',
    'WP-18 cases.md T18 stage 3: JT-1 returned through the Sales Return screen: In 4, Out still 1 (a return is a "+" movement), Stock 4, and In = Stock',
    async (ctx) => {
      const { page } = await ctx.session(as(USERS.admin.user, 'huid-journey'));
      const life = {};
      try {
        await makeTags(ctx, page, life);
        life.sale = await sellTag(page, TAGS[0]);
        life.returned = await returnTag(page, life.sale);
        await openReport(page);
        const inView = await readView(page, 'In Tag');
        const out = await readView(page, 'Out Tag');
        const stock = await readView(page, 'Stock Tag');
        sameTags(inView.tags, TAGS, 'In: 4');
        sameTags(out.tags, [TAGS[0]], 'Out: still the sale');
        sameTags(stock.tags, TAGS, 'Stock: JT-1 back');
        return {
          observation: `In ${inView.tags.length}, Out ${out.tags.length}, Stock ${stock.tags.length}`,
          expected: 'In 4, Out 1, Stock 4',
          database: { sale: life.sale, returned: life.returned },
          downstream: { in: inView.tags.length, out: out.tags.length, stock: stock.tags.length },
        };
      } finally {
        await teardown(ctx, page, life);
      }
    },
  ),
  C(
    'huid-report.journey.stage-4-cancel-views-agree',
    'T18',
    'mutation',
    'WP-18 cases.md T18 stage 4: JT-2 cancelled through Tag Cancel (TR_TAG_CAN.cs:5144 writes a "-" movement): it leaves Stock and joins Out, and In = Stock + sold-and-not-returned + cancelled',
    async (ctx) => {
      const { page } = await ctx.session(as(USERS.admin.user, 'huid-journey'));
      const life = {};
      try {
        await makeTags(ctx, page, life);
        life.cancel = await cancelTag(page, TAGS[1]);
        await openReport(page);
        const inView = await readView(page, 'In Tag');
        const out = await readView(page, 'Out Tag');
        const stock = await readView(page, 'Stock Tag');
        sameTags(inView.tags, TAGS, 'In: 4');
        sameTags(stock.tags, [TAGS[0], TAGS[2], TAGS[3]], 'Stock: JT-2 left');
        sameTags(out.tags, [TAGS[1]], 'Out: cancelled tag');
        assert.equal(inView.tags.length, stock.tags.length + 1, 'In = Stock + cancelled');
        return {
          observation: `In ${inView.tags.length}, Stock ${stock.tags.length}, Out ${out.tags.length}`,
          expected: 'JT-2 not in Stock; In = Stock + 1',
          database: { cancel: life.cancel },
          downstream: { in: inView.tags.length, stock: stock.tags.length, out: out.tags.length },
        };
      } finally {
        await teardown(ctx, page, life);
      }
    },
  ),
  C(
    'huid-report.drill.double-click-opens-source-voucher',
    'T05',
    'read-only',
    'RP_HUID.cs DGV_DoubleClick (as RP_TAG.cs:8917-9140): a double click on a row opens the voucher the row came from in its own screen, on the row VchNo; a target without the View right answers "You Have No Rights..."',
    async (ctx) => {
      const { page } = await ctx.session(as(USERS.admin.user, 'huid-journey'));
      const life = {};
      try {
        await makeTags(ctx, page, life);
        life.sale = await sellTag(page, TAGS[0]);
        await openReport(page);
        await readView(page, 'Out Tag');
        const row = rowsOf(page).filter({ hasText: TAGS[0] }).first();
        const voucher = (await row.locator('[data-col="vchNo"]').innerText()).trim();
        await row.dblclick();
        await page.waitForURL(/\/txn\/sales/, { timeout: 15000 });
        await page
          .getByTestId('sales-loaded')
          .filter({ hasText: `Loaded #${voucher}` })
          .waitFor();
        assert.equal(Number(voucher), Number(life.sale));
        // In view: the origin voucher (Tag Opening) of JT-2.
        await openReport(page);
        await readView(page, 'In Tag');
        const origin = rowsOf(page).filter({ hasText: TAGS[1] }).first();
        const originNo = (await origin.locator('[data-col="vchNo"]').innerText()).trim();
        await origin.dblclick();
        await page.waitForURL(/\/txn\/tag-opening/, { timeout: 15000 });
        await page.getByTestId('tag-opening-loaded').waitFor();
        assert.equal(Number(originNo), Number(life.opening));
        await openReport(page);
        await readView(page, 'In Tag');
        const bought = rowsOf(page).filter({ hasText: TAGS[2] }).first();
        await bought.dblclick();
        await page.waitForURL(/\/txn\/purchase/, { timeout: 15000 });
        await page.getByTestId('purchase-loaded').waitFor();
        assert.match(
          await page.getByTestId('purchase-loaded').innerText(),
          new RegExp(life.purchase),
        );
        return {
          observation: `Out row of ${TAGS[0]} opened sale ${voucher}; In row of ${TAGS[1]} opened opening ${originNo}`,
          expected: 'the voucher screens open on the row voucher numbers',
        };
      } finally {
        await teardown(ctx, page, life);
      }
    },
  ),
];
void ITEMS;
void PARTIES;

// Exercise each of the journey's three source families through its actual report row.
huidJourneyCases.push({
  ...huidJourneyCases.find((c) => c.id === 'huid-report.drill.double-click-opens-source-voucher'),
  id: 'huid-report.drill.target-form-per-main-book',
  source: 'RP_HUID.cs:2274-2359 OPSTK, SALES and PURCHASE source-voucher dispatch',
});
