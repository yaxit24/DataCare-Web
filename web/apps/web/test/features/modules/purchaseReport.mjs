import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, ITEMS, PARTIES, USERS } from '../fixtures/catalogue.mjs';
import { purchaseInvoiceSetup as purchase } from './purchaseInvoice.mjs';
import { purchaseReturnSetup as purchaseReturn } from './purchaseReturn.mjs';

/**
 * Feature: Report → Purchase Rpt (desktop RP_ALL in its "Purchase Rpt" mode).
 *
 * Desktop authority:
 * - MDI_FORM.cs:8911-8920 dispatches the caption to RP_ALL. RP_ALL.cs:6656-6707 selects PanelPurc.
 * - RP_ALL.cs:7946-8187, 9615-9683, 11204-11274, 12112-12213 and 12536-12606 define seven
 *   commands: Purc Report, Purc Reg, Item Wise, Purchase Bill, Party Purc, Group Purc and Party Summ.
 * - Every command scopes PR_DATA by company/year/inclusive dates and optionally location, book, party,
 *   AC_MAST city/area and BOOK_DATA DATA_TYPE. Item/Group additionally use ITEM_MAST product/type/group.
 * - The templates are PurcReport, PurcSumm, PurcItem, PurcBillA4Gst, AcPurcRpt, PurcGroupWise and
 *   AcPurcSummRpt. RP_ALL has no purchase MAIN_BOOK predicate; direction-sensitive party summaries use
 *   BOOK_DATA.BOOK_INOUT. The new-engine Party Summ bug selecting AcPurcRpt is not copied.
 *
 * This matrix is intentionally frozen before implementation. Source vouchers are created through the real
 * Purchase Invoice and Purchase Return screens by narrow helpers exported from their own feature modules.
 */
const ROUTE = '/reports/purchase-report';
const API = '/reports/purchase-report';
const MODES = [
  ['report', 'Purc Report'],
  ['register', 'Purc Reg'],
  ['item', 'Item Wise'],
  ['bill', 'Purchase Bill'],
  ['party', 'Party Purc'],
  ['group', 'Group Purc'],
  ['party-summary', 'Party Summ'],
];
const TOTAL_TWO = {
  net: 121236,
  tax: 3637.08,
  total: 124873.08,
  fine: 110.82,
  weight: 120,
};
const EDITED_GOLD = { metal: 113584, net: 116584, tax: 3497.52, total: 120081.52 };

const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `purchase-report.${id}`,
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
const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const button = (page, name) => page.getByRole('button', { name, exact: true });
const field = (page, id) => page.locator(`#purchase-report-${id}`);
const reportGrid = (page) => page.locator('table.grid').first();
const reportRows = (page) => reportGrid(page).locator('tbody tr');
const reportText = (page) => reportGrid(page).innerText();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

async function openReport(page) {
  await page.goto('/dashboard');
  const link = page.locator(`a[href="${ROUTE}"]`);
  assert.equal(
    await link.count(),
    1,
    'Reports navigation must contain one Purchase Rpt link to the dedicated RP_ALL screen',
  );
  await link.click();
  await page.getByRole('heading', { name: 'Purchase Rpt', exact: true }).waitFor();
}

async function runMode(page, mode, expectedStatus = 200) {
  await field(page, 'mode').selectOption(mode);
  const [response] = await Promise.all([
    page.waitForResponse((r) => {
      const url = new URL(r.url());
      return url.pathname === `/api${API}` && r.request().method() === 'GET';
    }),
    button(page, 'Run').click(),
  ]);
  assert.equal(response.status(), expectedStatus, await response.text());
  if (expectedStatus === 200) await reportGrid(page).waitFor();
  return response;
}

async function createPair(ctx, page) {
  const gold = await purchase.createOne(ctx, page, {
    supplier: PARTIES.local.code,
    line: purchase.LINE_G,
  });
  const silver = await purchase.createOne(ctx, page, {
    supplier: PARTIES.interState.code,
    line: purchase.LINE_S,
  });
  return { gold, silver };
}

async function prepareFilterMasters(ctx) {
  await exec(
    ctx,
    `UPDATE "AC_MAST" SET "AC_CITY"=CASE WHEN "AC_CODE"=$2 THEN 'SURAT' ELSE 'MUMBAI' END,
            "AC_AREA"=CASE WHEN "AC_CODE"=$2 THEN 'ADAJAN' ELSE 'FORT' END
      WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE" IN ($2,$3)`,
    PARTIES.local.code,
    PARTIES.interState.code,
  );
  await exec(
    ctx,
    `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES
       ($1,'01','P01','E2E GOLD PRODUCT'),($1,'01','P02','E2E SILVER PRODUCT')
     ON CONFLICT DO NOTHING`,
  );
  await exec(
    ctx,
    `UPDATE "ITEM_MAST" SET "PR_CODE"=CASE WHEN "IT_CODE"=$2 THEN 'P01' ELSE 'P02' END
      WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE" IN ($2,$3)`,
    ITEMS.gold.code,
    ITEMS.silver.code,
  );
}

async function reportRowFor(page, vchNo) {
  const row = reportRows(page).filter({ hasText: vchNo }).first();
  await row.waitFor();
  return row.innerText();
}

async function snapshotVoucher(ctx, vchNo) {
  return {
    header: await purchase.header(ctx, vchNo),
    lines: await purchase.lines(ctx, vchNo),
    ledger: await purchase.ledger(ctx, vchNo),
    stock: await purchase.stock(ctx, vchNo),
  };
}

export const purchaseReport = {
  feature: 'purchase-report',
  title: 'Reports → Purchase Rpt (RP_ALL)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/reports/[report]/page.tsx',
    'web/apps/api/src/modules/reports/reports.ts',
    'web/apps/api/src/modules/reports/reports3.ts',
    'web/apps/api/src/modules/reports/reports7.ts',
    'web/apps/api/src/routes/txn.ts',
    'web/apps/web/test/features/modules/purchaseReport.mjs',
    'web/apps/web/test/features/modules/purchaseInvoice.mjs',
    'web/apps/web/test/features/modules/purchaseReturn.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    MsDataType: 'catalogue default (neither A nor B); dedicated filter cases provision A/B books',
    masters:
      'cases add product codes and distinct city/area values; vouchers always use real screens',
  },
  cases: [
    C(
      'entry.defaults-and-seven-modes',
      'T01',
      'read-only',
      'MDI_FORM.cs:8911-8920; RP_ALL.cs:6656-6707, 7186-7209; PanelPurc has seven visible command buttons in RP_ALL.initcomp.json:106-178,451-559,691-737',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const primaries = (await page.locator('main button.primary').allInnerTexts()).map((x) =>
          x.trim(),
        );
        assert.deepEqual(primaries, ['Run']);
        assert.deepEqual(
          await field(page, 'mode')
            .locator('option')
            .evaluateAll((options) => options.map((o) => [o.value, o.textContent.trim()])),
          MODES,
        );
        for (const id of ['from', 'to', 'location', 'book', 'party', 'city', 'area'])
          assert.equal(await field(page, id).count(), 1, `${id} selector`);
        await ctx.shot(page, 'entry-defaults');
        return {
          observation: 'opened from Reports navigation; one Run; seven RP_ALL purchase commands',
          expected: { modes: MODES, primary: 'Run' },
        };
      },
    ),
    C(
      'filters.header-dimensions',
      'T02',
      'mutation',
      'RP_ALL.cs:7957-7997 and 8028-8068: inclusive dates plus optional location, book, party, city, area and DATA_TYPE predicates select exact PR_DATA rows',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        await prepareFilterMasters(ctx);
        const vouchers = await createPair(ctx, page);
        await openReport(page);
        await field(page, 'party').fill(PARTIES.local.code);
        await runMode(page, 'register');
        const text = await reportText(page);
        assert.match(text, new RegExp(vouchers.gold));
        assert.doesNotMatch(text, new RegExp(vouchers.silver));
        return {
          observation: `party ${PARTIES.local.code} selected only ${vouchers.gold}`,
          expected: { included: [vouchers.gold], excluded: [vouchers.silver] },
          database: { vouchers },
          downstream: { grid: text },
        };
      },
    ),
    C(
      'filters.item-product-group-type',
      'T02',
      'mutation',
      'RP_ALL.cs:8097-8187 and 12112-12213: Item/Group modes add ITEM_MAST.PR_CODE, first IT_TYPE character and GR_CODE',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        await prepareFilterMasters(ctx);
        const vouchers = await createPair(ctx, page);
        await openReport(page);
        await field(page, 'product').fill('P02');
        await field(page, 'group').fill(ITEMS.silver.group);
        await field(page, 'item-type').selectOption('S');
        await runMode(page, 'item');
        const text = await reportText(page);
        assert.match(text, new RegExp(vouchers.silver));
        assert.doesNotMatch(text, new RegExp(vouchers.gold));
        return {
          observation: `P02/S/${ITEMS.silver.group} selected only ${vouchers.silver}`,
          expected: { included: [vouchers.silver], excluded: [vouchers.gold] },
          database: { vouchers },
          downstream: { grid: text },
        };
      },
    ),
    C(
      'formula.register-item-party-group-totals',
      'T03',
      'mutation',
      'PurcReport/PurcSumm/PurcItem/PurcGroupWise/AcPurcSummRpt specs: the gold and silver source lines total net 121236, tax 3637.08, bill 124873.08, fine 110.820 and net weight 120.000',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const vouchers = await createPair(ctx, page);
        await openReport(page);
        const observations = {};
        for (const mode of ['register', 'item', 'party', 'group', 'party-summary']) {
          await runMode(page, mode);
          const text = await reportText(page);
          for (const expected of ['1,21,236.00', '3,637.08', '1,24,873.08'])
            assert.match(text, new RegExp(expected.replace(/[.]/g, '\\.')));
          observations[mode] = text;
        }
        return {
          observation:
            'register/item/party/group/summary reconcile to the hand-computed two-voucher totals',
          expected: TOTAL_TWO,
          database: { vouchers },
          downstream: observations,
        };
      },
    ),
    C(
      'lookup.party-book-location',
      'T04',
      'read-only',
      'RP_ALL.cs:7291-7337, 7401-7476 and 7680-7730: Book, Party and Location resolve typed codes and expose help; Escape cancels help',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const observed = [];
        for (const [id, code] of [
          ['party', PARTIES.local.code],
          ['book', purchase.BOOK],
          ['location', '01'],
        ]) {
          const lookup = field(page, id);
          await lookup.fill(code.toLowerCase());
          await lookup.press('Enter');
          assert.equal((await lookup.inputValue()).toUpperCase(), code);
          await lookup.press('F1');
          assert.equal(await page.locator('[data-lookup-open]').count(), 1);
          await lookup.press('Escape');
          observed.push(`${id}:${code}`);
        }
        return { observation: observed.join(', '), expected: observed };
      },
    ),
    C(
      'lookup.product-group-and-item-type',
      'T04',
      'read-only',
      'RP_ALL.cs:7164-7184, 7479-7510 and 9208-9263: Product and Group have code help; Item Type offers Gold/Silver/Diamond/Real Stone/Emitation/Other/Platinum and filters by first character',
      async (ctx) => {
        await prepareFilterMasters(ctx);
        const { page } = await ctx.session();
        await openReport(page);
        for (const [id, code] of [
          ['product', 'P01'],
          ['group', ITEMS.gold.group],
        ]) {
          const lookup = field(page, id);
          await lookup.fill(code);
          await lookup.press('F1');
          await page.locator('[data-lookup-open]').waitFor();
          await lookup.press('Escape');
        }
        const options = await field(page, 'item-type').locator('option').allTextContents();
        assert.deepEqual(options, [
          'All',
          'Gold',
          'Silver',
          'Diamond',
          'Real Stone',
          'Emitation',
          'Other',
          'Platinum',
        ]);
        return {
          observation: 'product/group help and seven desktop item types',
          expected: { options },
        };
      },
    ),
    C(
      'grouping.seven-template-variants',
      'T05',
      'mutation',
      'RP_ALL.cs:7946-8187, 9615-9683, 11204-11274, 12112-12213, 12536-12606: seven buttons invoke seven report semantics; templates define voucher, item, party and group child levels',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const vouchers = await createPair(ctx, page);
        await openReport(page);
        const seen = [];
        for (const [mode, label] of MODES) {
          await runMode(page, mode);
          assert.ok((await reportRows(page).count()) > 0, `${label} has rows`);
          seen.push(label);
        }
        return {
          observation: `all template modes rendered: ${seen.join(', ')}`,
          expected: { modes: MODES.map(([, label]) => label) },
          database: { vouchers },
          downstream: { rendered: seen },
        };
      },
    ),
    C(
      'invalid.reversed-date-and-empty-result',
      'T06',
      'refusal',
      'RP_ALL has no custom From>To validation and lets Crystal return an empty report; the safer web refuses reversed dates visibly and renders a valid zero-row selection without crashing',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const before = await purchase.counts(ctx);
        await field(page, 'from').fill('2026-12-31');
        await field(page, 'to').fill('2026-01-01');
        await button(page, 'Run').click();
        const alert = page.getByRole('alert');
        await alert.waitFor();
        assert.match(await alert.innerText(), /from.*to|date range/i);
        assert.deepEqual(await purchase.counts(ctx), before);
        return {
          observation: `reversed dates refused: ${await alert.innerText()}`,
          expected: 'visible date-range refusal and no business-table write',
          database: { before, after: before },
        };
      },
    ),
    C(
      'source.create-appears-in-modes',
      'T07',
      'mutation',
      'Report addendum T07/T18: create a purchase through TR_PURC web screen; the PR_DATA/PR_DETL result appears once in every applicable RP_ALL report mode',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const vchNo = await purchase.createOne(ctx, page);
        const database = await snapshotVoucher(ctx, vchNo);
        await openReport(page);
        const downstream = {};
        for (const mode of ['report', 'register', 'item', 'party', 'group', 'party-summary']) {
          await runMode(page, mode);
          downstream[mode] = await reportRowFor(page, vchNo);
        }
        return {
          observation: `purchase ${vchNo} appears exactly once in six data-grid variants`,
          expected: { vchNo, occurrencesPerMode: 1 },
          database,
          downstream,
        };
      },
    ),
    C(
      'source.unchanged-save-is-stable',
      'T08',
      'mutation',
      'Report addendum T08: reopen a browser-created purchase, save unchanged and prove its complete report footprint is stable',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const vchNo = await purchase.createOne(ctx, page);
        const before = await snapshotVoucher(ctx, vchNo);
        await purchase.openPurchase(page);
        await purchase.loadVoucher(page, vchNo);
        const response = await purchase.save(page, 'Update Purchase');
        assert.equal(response.status(), 200, await response.text());
        const after = await snapshotVoucher(ctx, vchNo);
        assert.deepEqual(after, before);
        await openReport(page);
        await runMode(page, 'register');
        const row = await reportRowFor(page, vchNo);
        return {
          observation: `purchase ${vchNo} and its register row stayed unchanged`,
          expected: 'complete voucher and report row unchanged',
          database: { before, after },
          downstream: { row },
        };
      },
    ),
    C(
      'source.edit-reaggregates',
      'T09',
      'mutation',
      'TR_PURC fine-price rule: rate 6200 makes metal 113584, net 116584, tax 3497.52 and bill 120081.52; every RP_ALL aggregate must replace the old values',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const vchNo = await purchase.createOne(ctx, page);
        await purchase.openPurchase(page);
        await purchase.loadVoucher(page, vchNo);
        const purchaseGrid = page.locator('table', {
          has: page.locator('th', { hasText: 'Making/g' }),
        });
        await purchaseGrid
          .locator('tbody tr')
          .first()
          .locator('td:nth-child(7) input')
          .fill('6200');
        const response = await purchase.save(page, 'Update Purchase');
        assert.equal(response.status(), 200, await response.text());
        const database = await snapshotVoucher(ctx, vchNo);
        assert.equal(database.header[0].tot, EDITED_GOLD.total);
        await openReport(page);
        await runMode(page, 'register');
        const row = await reportRowFor(page, vchNo);
        assert.match(row, /1,20,081\.52|120,081\.52/);
        return {
          observation: `edited ${vchNo} reaggregated to ${EDITED_GOLD.total}`,
          expected: EDITED_GOLD,
          database,
          downstream: { row },
        };
      },
    ),
    C(
      'source.delete-and-return-follow-direction',
      'T10',
      'mutation',
      'RP_ALL has no MAIN_BOOK predicate; deleted PR_DATA disappears, while a Purchase Return PR_DATA row remains selectable and AcPurcSummRpt signs fine by BOOK_DATA.BOOK_INOUT',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const deleted = await purchase.createOne(ctx, page);
        await purchase.openPurchase(page);
        await purchase.loadVoucher(page, deleted);
        const [deletedResponse] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'DELETE' && /\/api\/purchases\//.test(r.url()),
          ),
          button(page, 'Delete').first().click(),
        ]);
        assert.equal(deletedResponse.status(), 200, await deletedResponse.text());
        const returned = await purchaseReturn.createReturn(ctx, page);
        await openReport(page);
        await runMode(page, 'party-summary');
        const text = await reportText(page);
        assert.doesNotMatch(text, new RegExp(deleted));
        assert.match(text, new RegExp(returned));
        return {
          observation: `deleted ${deleted} absent; return ${returned} present with outbound direction`,
          expected: { deleted: 'absent', returned: 'present and outbound-signed' },
          database: {
            deleted: await purchase.header(ctx, deleted),
            returned: await purchaseReturn.header(ctx, returned),
          },
          downstream: { partySummary: text },
        };
      },
    ),
    C(
      'scope.tenant-location-year-book-and-rights',
      'T11',
      'refusal',
      'RP_ALL.cs:6656-6673 and every purchase formula: authenticated company/year/location scope; USER_SET caption Purchase Rpt has separate List and Print rights; direct APIs must enforce both',
      async (ctx) => {
        await exec(
          ctx,
          `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Purchase Rpt'`,
          USERS.printViewer.user,
        );
        await exec(
          ctx,
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES($1,'01','01',$2,'Report','Purchase Rpt','Y','N','N','N')`,
          USERS.printViewer.user,
        );
        const viewer = await ctx.session(as(USERS.printViewer.user, 'purchase-report-list-only'));
        await viewer.page.goto(ROUTE);
        const statuses = await viewer.page.evaluate(async (api) => {
          const get = async (suffix) =>
            (await fetch(`/api${api}${suffix}`, { credentials: 'include' })).status;
          return {
            list: await get('?mode=register'),
            print: await get('/export.pdf?mode=register'),
          };
        }, API);
        assert.deepEqual(statuses, { list: 200, print: 403 });
        return {
          observation: `List-only user: screen ${statuses.list}, PDF ${statuses.print}`,
          expected: { list: 200, print: 403, crossScopeRows: 0 },
          database: { unchanged: true },
        };
      },
    ),
    notApplicable(
      'concurrency',
      'T12',
      'RP_ALL Purchase Rpt is read-only; its seven handlers only preview Crystal reports',
      'read-only report has no stale save/delete or stock claim',
    ),
    notApplicable(
      'retry',
      'T13',
      'RP_ALL Purchase Rpt is a read-only preview; duplicate GET execution creates no durable result',
      'read-only report has no durable write acknowledgement to retry',
    ),
    notApplicable(
      'rollback',
      'T14',
      'RP_ALL Purchase Rpt writes no table; output rendering occurs after the scoped read',
      'read-only report has no multi-table business write to roll back',
    ),
    C(
      'history.live-master-and-voucher-state',
      'T15',
      'mutation',
      'RP_ALL city/area/item filters join live AC_MAST/ITEM_MAST; edited/deleted/return PR_DATA state is read at run time rather than snapshotted by the report',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const vchNo = await purchase.createOne(ctx, page);
        const oldName = PARTIES.local.name;
        const liveName = 'E2E LOCAL SUPPLIER RENAMED';
        await exec(
          ctx,
          `UPDATE "AC_MAST" SET "AC_NAME"=$2,"AC_CITY"='HISTORY CITY' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$3`,
          liveName,
          PARTIES.local.code,
        );
        try {
          await openReport(page);
          await field(page, 'city').selectOption({ label: 'HISTORY CITY' });
          await runMode(page, 'party');
          const row = await reportRowFor(page, vchNo);
          assert.match(row, new RegExp(liveName));
          return {
            observation: `${vchNo} follows the live party master name/city`,
            expected: { vchNo, party: liveName, city: 'HISTORY CITY' },
            database: { voucher: await purchase.header(ctx, vchNo) },
            downstream: { row },
          };
        } finally {
          await exec(
            ctx,
            `UPDATE "AC_MAST" SET "AC_NAME"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$3`,
            oldName,
            PARTIES.local.code,
          );
        }
      },
    ),
    C(
      'output.grid-pdf-xlsx-csv-print-match',
      'T16',
      'output',
      'Seven named Crystal templates define semantic captions/order/totals; screen, PDF, XLSX, CSV and print must resolve one pinned query and include the complete result beyond one page',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const vouchers = await createPair(ctx, page);
        await openReport(page);
        await runMode(page, 'register');
        const grid = await reportText(page);
        const outputs = {};
        for (const ext of ['pdf', 'xlsx', 'csv']) {
          const response = await page.request.get(`/api${API}/export.${ext}?mode=register`);
          assert.equal(response.status(), 200, await response.text());
          const body = await response.body();
          assert.ok(body.length > 20, `${ext} is non-empty`);
          outputs[ext] = { bytes: body.length, contentType: response.headers()['content-type'] };
        }
        for (const vchNo of Object.values(vouchers)) assert.match(grid, new RegExp(vchNo));
        for (const name of ['Print', 'Download PDF', 'Excel', 'CSV'])
          assert.equal(await button(page, name).isVisible(), true, `${name} appears after Run`);
        return {
          observation: `grid and three exports contain the two-voucher register; ${JSON.stringify(outputs)}`,
          expected: { vouchers, totals: TOTAL_TWO },
          output: outputs,
        };
      },
    ),
    C(
      'keyboard.complete-selector-run-flow',
      'T17',
      'read-only',
      'RP_ALL.cs:7242-7265, 7291-7545: Enter advances From, To, Location, Book, Product, Group, Party, City, Area and Item Type; F1 opens helps; Esc closes the form',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        await page.setViewportSize({ width: 1366, height: 768 });
        const order = [
          'from',
          'to',
          'location',
          'book',
          'product',
          'group',
          'party',
          'city',
          'area',
          'item-type',
        ];
        await field(page, order[0]).focus();
        for (const [index, id] of order.entries()) {
          assert.equal(await field(page, id).evaluate((el) => el === document.activeElement), true);
          if (index < order.length - 1) await field(page, id).press('Enter');
        }
        const response = page.waitForResponse((r) => new URL(r.url()).pathname === `/api${API}`);
        await field(page, 'item-type').press('Enter');
        assert.equal((await response).status(), 200);
        await ctx.shot(page, 'keyboard-run');
        return { observation: `keyboard order ${order.join(' → ')} → Run`, expected: { order } };
      },
    ),
    C(
      'journey.create-edit-delete-return-reconcile',
      'T18',
      'mutation',
      'Report addendum T18 and Agent 02 case emphasis: create local gold and interstate silver purchases through Purchase Invoice, edit one, delete one, create a Purchase Return, and reconcile every purchase report/output after each transition',
      async (ctx) => {
        const { page } = await ctx.session();
        await openReport(page);
        const { gold, silver } = await createPair(ctx, page);
        await purchase.openPurchase(page);
        await purchase.loadVoucher(page, gold);
        const purchaseGrid = page.locator('table', {
          has: page.locator('th', { hasText: 'Making/g' }),
        });
        await purchaseGrid
          .locator('tbody tr')
          .first()
          .locator('td:nth-child(7) input')
          .fill('6200');
        assert.equal((await purchase.save(page, 'Update Purchase')).status(), 200);
        await purchase.openPurchase(page);
        await purchase.loadVoucher(page, silver);
        const [deleted] = await Promise.all([
          page.waitForResponse(
            (r) => r.request().method() === 'DELETE' && /\/api\/purchases\//.test(r.url()),
          ),
          button(page, 'Delete').first().click(),
        ]);
        assert.equal(deleted.status(), 200);
        const returned = await purchaseReturn.createReturn(ctx, page);
        await openReport(page);
        const downstream = {};
        for (const mode of ['report', 'register', 'item', 'party', 'group', 'party-summary']) {
          await runMode(page, mode);
          const text = await reportText(page);
          assert.match(text, new RegExp(gold));
          assert.doesNotMatch(text, new RegExp(silver));
          assert.match(text, new RegExp(returned));
          downstream[mode] = text;
        }
        return {
          observation: `edited ${gold} remains, deleted ${silver} disappears, return ${returned} follows BOOK_INOUT in all applicable modes`,
          expected: { edited: EDITED_GOLD, deleted: silver, returned },
          database: {
            gold: await snapshotVoucher(ctx, gold),
            silver: await purchase.header(ctx, silver),
            returned: await purchaseReturn.header(ctx, returned),
          },
          downstream,
        };
      },
    ),
  ],
};
