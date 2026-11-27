import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import { cleanHuid, huidUser, seedHuid } from './huidSeed.mjs';
/**
 * Feature: Report → HuId Report (RP_HUID.cs, /reports/huid), part A: T01, T02, T03, T06. Expected values are the desktop
 * rules applied to huidSeed.mjs, never read back from the app. The page does not exist yet; selectors follow the WP-18 page
 * contract (buttons by name, labelled inputs, role=grid with data-col cells, data-testid=huid-totals, role=alert).
 */

const ROUTE = '/reports/huid';
const ROW = '[role="grid"] [role="row"]:not([data-testid="huid-totals"]):has([data-col="tagNo"])';
const WINDOW = { from: '05/04/2026', to: '30/06/2026' };
const GOLD_WINDOW = [
  'TG-001',
  'TG-002',
  'TG-003',
  'TG-004',
  'TG-005',
  'TG-006',
  'TG-010',
  'TG-012',
  'TG-013',
  'TG-015',
];
const GOLD_STOCK_TO_30_06 = [
  'TG-001',
  'TG-002',
  'TG-003',
  'TG-004',
  'TG-006',
  'TG-011',
  'TG-013',
  'TG-014',
  'TG-015',
  'TG-016',
];

const C = (id, group, source, run) => ({
  id,
  group,
  kind: 'read-only',
  source,
  applicable: true,
  requiredEvidence: ['browser', 'expected'],
  run,
});
const button = (page, name) => page.getByRole('button', { name, exact: true });
const field = (page, name) => page.getByLabel(name, { exact: true });
const selected = (page, name) =>
  field(page, name).evaluate((el) => el.options[el.selectedIndex].text.trim());
const thou = (text) => {
  const t = String(text ?? '')
    .replace(/,/g, '')
    .trim();
  return t === '' ? NaN : Math.round(Number(t) * 1000);
};

async function withCase(ctx, fn) {
  await seedHuid(ctx);
  try {
    return await fn();
  } finally {
    await cleanHuid(ctx);
  }
}

async function open(page) {
  await page.goto(ROUTE);
  await button(page, 'Stock Tag').waitFor();
}

async function setFilters(page, f = {}) {
  if (f.from) await field(page, 'From').fill(f.from);
  if (f.to) await field(page, 'To').fill(f.to);
  if (f.item) await field(page, 'Item Type').selectOption(f.item);
  if (f.hm) await field(page, 'HuId Type').selectOption(f.hm);
  if (f.product) await field(page, 'Product').fill(f.product);
  if (f.group) await field(page, 'Group').fill(f.group);
  if (f.tag) await field(page, 'Tag No').fill(f.tag);
}

/** Clicks a view and waits for its API response, so the case reads the result and not the page before it. */
async function runView(page, name) {
  const isReport = (r) =>
    new URL(r.url()).pathname === '/api/reports/huid' && r.request().method() === 'GET';
  const [res] = await Promise.all([page.waitForResponse(isReport), button(page, name).click()]);
  assert.equal(res.status(), 200, `${name}: report request status`);
}

const readTags = (page) =>
  page.evaluate(
    (sel) =>
      [...document.querySelectorAll(sel)].map((r) =>
        r.querySelector('[data-col="tagNo"]').textContent.trim(),
      ),
    ROW,
  );

/** Waits for the grid to show the exact tag list, in order, then asserts it. */
async function expectTags(page, want) {
  const same = ([sel, w]) =>
    JSON.stringify(
      [...document.querySelectorAll(sel)].map((r) =>
        r.querySelector('[data-col="tagNo"]').textContent.trim(),
      ),
    ) === JSON.stringify(w);
  await page.waitForFunction(same, [ROW, want], { timeout: 15000 }).catch(() => {});
  assert.deepEqual(await readTags(page), want);
}

async function expectTotals(page, want) {
  const got = await page
    .getByTestId('huid-totals')
    .evaluate((el) =>
      Object.fromEntries(
        [...el.querySelectorAll('[data-col]')].map((c) => [c.dataset.col, c.textContent]),
      ),
    );
  for (const [key, value] of Object.entries(want)) {
    assert.equal(
      thou(got[key]),
      thou(value),
      `total ${key} (grid shows ${JSON.stringify(got[key])})`,
    );
  }
}

const noMessage = async (page) =>
  assert.equal(
    await page.locator('[role="alert"]:not(#__next-route-announcer__)').count(),
    0,
    'no message is shown',
  );

/** Open, set the filters, run one view and assert the exact tag list. */
const showing = (ctx, filters, view, tags) =>
  withCase(ctx, async () => {
    const { page } = await ctx.session();
    await open(page);
    await setFilters(page, filters);
    await runView(page, view);
    await expectTags(page, tags);
    return { observation: `${view}: ${tags.join(', ') || 'no rows'}`, expected: { tags } };
  });

/** Stock ignores From and uses To only (RP_HUID.cs:1838), so this sets To and runs Stock. */
const stockTo = (ctx, to, check) =>
  withCase(ctx, async () => {
    const { page } = await ctx.session();
    await open(page);
    await setFilters(page, { to });
    await runView(page, 'Stock Tag');
    return check(page);
  });

export const filterCases = [
  C(
    'huid-report.config.data-type-filter',
    'T15',
    'RP_HUID.cs:1761 {{Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = \'" + DC_Main.MsDataType + "\'"))}}; MsDataType is the session data type (MDI_FORM.cs:12732-12740; web owner decision 2026-11-25: LOGIN_MAST DATA_TYPE_ALLOW/DEFAULT, Ctrl+B / Ctrl+C / badge switch, bound into every /reports/* query by app.ts sessionReportQuery). A blank row type reads as A (reportDataType.ts)',
    (ctx) =>
      withCase(ctx, async () => {
        const typed = { 'TG-001': '', 'TG-003': 'A', 'TG-002': 'B', 'TG-005': 'B' };
        for (const [tag, type] of Object.entries(typed))
          await ctx.owner.$executeRawUnsafe(
            `UPDATE "BAR_DETL" SET "DATA_TYPE"=$3 WHERE tenant_id=$1 AND "TAG_NO"=$2 AND "LC_CODE"='09'`,
            ctx.tenantId,
            tag,
            type,
          );
        const { page } = await ctx.session({
          ...huidUser(USERS.admin.user),
          slot: 'huid-datatype',
        });
        const badge = page.getByTestId('data-type-badge');
        const inView = async () => {
          await open(page);
          await setFilters(page, WINDOW);
          await runView(page, 'In Tag');
          return readTags(page);
        };
        try {
          // All (C): no data-type condition, the ten Gold tags of the window.
          await page.goto('/dashboard');
          await badge.filter({ hasText: /^All$/ }).waitFor();
          await inView();
          await expectTags(page, GOLD_WINDOW);
          // B: only the B rows.
          await page.goto('/dashboard');
          // The shortcut listens only once /me has loaded (the badge is up), as in usersRights data-type.shell-switch.
          await badge.filter({ hasText: /^All$/ }).waitFor();
          await page.keyboard.press('Control+b');
          await badge.filter({ hasText: /^B$/ }).waitFor();
          await inView();
          await expectTags(page, ['TG-002', 'TG-005']);
          // A (the badge returns to A): the A row and the blank one.
          await badge.click();
          await page.waitForLoadState('load');
          await page.getByTestId('data-type-badge').waitFor({ state: 'detached' });
          await inView();
          await expectTags(page, ['TG-001', 'TG-003']);
          return {
            observation:
              'In view: All → 10 Gold tags; B → TG-002, TG-005; A → TG-001 (blank) and TG-003',
            expected: { all: GOLD_WINDOW, B: ['TG-002', 'TG-005'], A: ['TG-001', 'TG-003'] },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `UPDATE auth_session SET revoked_at=clock_timestamp(),revoke_reason='test-cleanup' WHERE tenant_id=$1 AND session_id IN (SELECT session_id FROM auth_session WHERE tenant_id=$1 AND login_name=$2 AND data_type<>'C')`,
            ctx.tenantId,
            USERS.admin.user,
          );
        }
      }),
  ),
  // T01 Entry and defaults
  C(
    'huid-report.entry.menu-opens-three-views',
    'T01',
    'RP_HUID.cs:1121 {{BtnStock.Text = "&Stock Tag";}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        for (const name of ['Stock Tag', 'In Tag', 'Out Tag']) await button(page, name).waitFor();
        assert.equal(
          await page.getByRole('button', { name: /Tag$/ }).count(),
          3,
          'exactly three view buttons',
        );
        assert.equal(await button(page, 'All history').count(), 0, 'no All history tab');
        return {
          observation: 'three view buttons, no All history',
          expected: { views: ['Stock Tag', 'In Tag', 'Out Tag'] },
        };
      }),
  ),
  C(
    'huid-report.entry.default-dates-today',
    'T01',
    'RP_HUID.cs:1620 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        // The desktop copies the system date into both boxes (RP_HUID.cs:1620-1621). The browser clock is fixed to 05/04/2026.
        await page.clock.setFixedTime(new Date(2026, 3, 5, 10, 0, 0));
        await open(page);
        assert.equal(await field(page, 'From').inputValue(), '05/04/2026');
        assert.equal(await field(page, 'To').inputValue(), '05/04/2026');
        return {
          observation: 'From and To show the system date',
          expected: { from: '05/04/2026', to: '05/04/2026' },
        };
      }),
  ),
  C(
    'huid-report.entry.default-item-type-gold',
    'T01',
    'RP_HUID.cs:1555 {{cboItemTyp.Items.Add((object)"Gold");}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        assert.equal(await selected(page, 'Item Type'), 'Gold');
        await setFilters(page, WINDOW);
        await runView(page, 'In Tag');
        await expectTags(page, GOLD_WINDOW);
        return {
          observation: 'Item Type opens on Gold; In lists the 10 Gold tags',
          expected: { itemType: 'Gold', tags: GOLD_WINDOW },
        };
      }),
  ),
  C(
    'huid-report.entry.default-hallmark-all',
    'T01',
    'RP_HUID.cs:1573 {{cboHuId.SelectedIndex = 0;}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        assert.equal(await selected(page, 'HuId Type'), 'All');
        await setFilters(page, WINDOW);
        await runView(page, 'In Tag');
        await expectTags(page, GOLD_WINDOW);
        return {
          observation: 'HuId Type is All; In lists 10 rows, not only tagged rows',
          expected: { hm: 'All', rows: 10 },
        };
      }),
  ),
  C(
    'huid-report.entry.grid-empty-before-first-view',
    'T01',
    'RP_HUID.cs:1877 {{DGV_FILL();}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        await expectTags(page, []);
        return { observation: 'no rows before a view runs', expected: { rows: 0 } };
      }),
  ),
  C(
    'huid-report.entry.blank-product-group-tag-account',
    'T01',
    'RP_HUID.cs:1202 {{((Control)cboProduct).TabIndex = 4;}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        for (const name of ['Product', 'Group', 'Tag No', 'Ac Code'])
          assert.equal(await field(page, name).inputValue(), '', `${name} starts blank`);
        return {
          observation: 'Product, Group, Tag No and Ac Code start blank',
          expected: { blank: true },
        };
      }),
  ),

  // T02 Field route (each filter changes the row set)
  C('huid-report.filter.in-date-window', 'T02', "RP_HUID.cs:1761 {{AND C.VCH_DATE >= '}}", (ctx) =>
    showing(ctx, WINDOW, 'In Tag', GOLD_WINDOW),
  ),
  C('huid-report.filter.out-date-window', 'T02', "RP_HUID.cs:1795 {{AND A.VCH_DATE >= '}}", (ctx) =>
    showing(ctx, WINDOW, 'Out Tag', ['TG-005', 'TG-006']),
  ),
  C(
    'huid-report.filter.stock-to-date-only',
    'T02',
    "RP_HUID.cs:1838 {{AND C.STK_DATE <= '}}",
    (ctx) =>
      showing(ctx, { from: '20/06/2026', to: '30/06/2026' }, 'Stock Tag', GOLD_STOCK_TO_30_06),
  ),
  C(
    'huid-report.filter.hallmark-with-first-slot',
    'T02',
    `RP_HUID.cs:1764 {{DC_Main.RsQry += " AND C.HM_ID <> ''";}}`,
    (ctx) => showing(ctx, { ...WINDOW, hm: 'With HuId' }, 'In Tag', ['TG-001', 'TG-005', 'TG-006']),
  ),
  C(
    'huid-report.filter.hallmark-without-first-slot',
    'T02',
    `RP_HUID.cs:1768 {{DC_Main.RsQry += "AND C.HM_ID = '' ";}}`,
    (ctx) =>
      showing(ctx, { ...WINDOW, hm: 'Whout HuId' }, 'In Tag', [
        'TG-002',
        'TG-003',
        'TG-004',
        'TG-010',
        'TG-012',
        'TG-013',
        'TG-015',
      ]),
  ),
  C(
    'huid-report.hallmark.whitespace-only-first-slot',
    'T02',
    `RP_HUID.cs:1768 {{DC_Main.RsQry += "AND C.HM_ID = '' ";}} (SQL Server ignores trailing spaces, so three spaces equal '')`,
    (ctx) => showing(ctx, { ...WINDOW, hm: 'With HuId' }, 'In Tag', ['TG-001', 'TG-005', 'TG-006']),
  ),
  C(
    'huid-report.filter.tag-no-exact',
    'T02',
    'RP_HUID.cs:1782 {{if (Operators.CompareString(tTagNo.Text, "", false) != 0)}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        await setFilters(page, { ...WINDOW, tag: 'TG-001' });
        await runView(page, 'In Tag');
        await expectTags(page, ['TG-001']);
        await runView(page, 'Stock Tag');
        await expectTags(page, ['TG-001']);
        await runView(page, 'Out Tag');
        await expectTags(page, []);
        return {
          observation: 'In TG-001, Stock TG-001, Out none',
          expected: { in: ['TG-001'], stock: ['TG-001'], out: [] },
        };
      }),
  ),
  C('huid-report.filter.tag-n-excluded', 'T02', "RP_HUID.cs:1761 {{AND C.TAG_NO <> 'N'}}", (ctx) =>
    withCase(ctx, async () => {
      const { page } = await ctx.session();
      await open(page);
      await setFilters(page, { from: '01/04/2026', to: '30/06/2026' });
      // TG-008 is stored with TAG_NO 'N'. An empty view would pass trivially, so each view must list rows first.
      for (const view of ['In Tag', 'Out Tag', 'Stock Tag']) {
        await runView(page, view);
        const tags = await readTags(page);
        assert.ok(tags.length > 0, `${view} is not empty`);
        assert.ok(!tags.includes('N'), `${view} does not list tag N`);
      }
      return { observation: 'tag N absent from In, Out and Stock', expected: { absent: 'N' } };
    }),
  ),
  C(
    'huid-report.filter.item-type-silver',
    'T02',
    'RP_HUID.cs:1778 {{if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)}}',
    (ctx) => showing(ctx, { ...WINDOW, item: 'Silver' }, 'In Tag', ['TG-007']),
  ),
  C('huid-report.filter.product-ring', 'T02', "RP_HUID.cs:1772 {{AND B.PR_CODE =  '}}", (ctx) =>
    showing(ctx, { ...WINDOW, product: 'PR-RING' }, 'In Tag', [
      'TG-001',
      'TG-003',
      'TG-004',
      'TG-005',
      'TG-006',
      'TG-010',
      'TG-012',
    ]),
  ),
  C('huid-report.filter.group-link', 'T02', "RP_HUID.cs:1815 {{AND B.GR_CODE =  '}}", (ctx) =>
    showing(ctx, { ...WINDOW, group: 'GR-LINK' }, 'In Tag', ['TG-002', 'TG-013', 'TG-015']),
  ),
  C('huid-report.filter.counter-absent', 'T02', 'RP_HUID.cs:1761 {{1 AS Qty}}', (ctx) =>
    withCase(ctx, async () => {
      const { page } = await ctx.session();
      await open(page);
      assert.equal(await field(page, 'Counter').count(), 0, 'no Counter box');
      await setFilters(page, WINDOW);
      await runView(page, 'In Tag');
      await expectTags(page, GOLD_WINDOW);
      return { observation: 'no Counter box; window returns 10 rows', expected: { rows: 10 } };
    }),
  ),
  C('huid-report.filter.item-code-absent', 'T02', "RP_HUID.cs:1761 {{AND C.CO_YEAR = '}}", (ctx) =>
    withCase(ctx, async () => {
      const { page } = await ctx.session();
      await open(page);
      assert.equal(await field(page, 'Item').count(), 0, 'no Item box');
      assert.equal(await field(page, 'Item Code').count(), 0, 'no Item Code box');
      await setFilters(page, WINDOW);
      await runView(page, 'In Tag');
      await expectTags(page, GOLD_WINDOW);
      return { observation: 'no Item box; window returns 10 rows', expected: { rows: 10 } };
    }),
  ),
  C(
    'huid-report.filter.search-first-column-set',
    'T02',
    `RP_HUID.cs:1669 {{dataView.RowFilter = "HuId Like  '%" + ((TextEdit)tSerchAll).Text +}}`,
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        await setFilters(page, WINDOW);
        await runView(page, 'In Tag');
        await field(page, 'Search').fill('HU00');
        await expectTags(page, ['TG-001', 'TG-005', 'TG-006']);
        return {
          observation: 'HU00 matches HuId only: TG-001, TG-005, TG-006',
          expected: { tags: ['TG-001', 'TG-005', 'TG-006'] },
        };
      }),
  ),
  C(
    'huid-report.filter.search-second-column-match',
    'T02',
    `RP_HUID.cs:1675 {{dataView.RowFilter = "HuId2 Like  '%" + ((TextEdit)tSerchAll).Text +}}`,
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        await setFilters(page, WINDOW);
        await runView(page, 'In Tag');
        await field(page, 'Search').fill('HU0003');
        await expectTags(page, ['TG-003']);
        return {
          observation: 'HU0003 has no HuId match, so HuId2 is tried: TG-003',
          expected: { tags: ['TG-003'] },
        };
      }),
  ),
  C(
    'huid-report.order.tag-no-ascending',
    'T02',
    'RP_HUID.cs:1790 {{DC_Main.RsQry += "ORDER BY C.TAG_NO";}}',
    (ctx) => showing(ctx, WINDOW, 'In Tag', GOLD_WINDOW),
  ),

  // T03 Formula sequence (totals and the stock sum)
  C(
    'huid-report.total.in-window-sums',
    'T03',
    'RP_HUID.cs:2068 {{((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        await setFilters(page, WINDOW);
        await runView(page, 'In Tag');
        await expectTags(page, GOLD_WINDOW);
        // Sums of the 10 rows: gross 71.000, net 68.200; HUID slot weights 1.100, 0.400, 0.000, 0.250.
        await expectTotals(page, {
          qty: '10',
          pcs: '11',
          grwt: '71.000',
          netWt: '68.200',
          huWt: '1.100',
          huWt2: '0.400',
          huWt3: '0.000',
          huWt4: '0.250',
        });
        return {
          observation: 'In totals match the desktop sums',
          expected: { qty: 10, grwt: '71.000' },
        };
      }),
  ),
  C('huid-report.total.out-window-sums', 'T03', "RP_HUID.cs:1795 {{AND A.ITM_SIGN = '-'}}", (ctx) =>
    withCase(ctx, async () => {
      const { page } = await ctx.session();
      await open(page);
      await setFilters(page, WINDOW);
      await runView(page, 'Out Tag');
      await expectTags(page, ['TG-005', 'TG-006']);
      await expectTotals(page, {
        qty: '2',
        pcs: '2',
        grwt: '10.000',
        netWt: '9.700',
        huWt: '0.600',
      });
      return {
        observation: 'Out totals: qty 2, grwt 10.000, netWt 9.700',
        expected: { qty: 2, grwt: '10.000' },
      };
    }),
  ),
  C(
    'huid-report.total.stock-rule-srno-zero',
    'T03',
    "RP_HUID.cs:1873 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}",
    (ctx) =>
      stockTo(ctx, '30/06/2026', async (page) => {
        const tags = await readTags(page);
        assert.ok(tags.length > 0, 'stock view is not empty');
        assert.ok(!tags.includes('TG-012'), 'TG-012 (serial 0, sum 0) is absent');
        return { observation: 'TG-012 absent from Stock', expected: { absent: 'TG-012' } };
      }),
  ),
  C(
    'huid-report.total.stock-rule-sold-and-returned',
    'T03',
    "RP_HUID.cs:1873 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}",
    (ctx) =>
      stockTo(ctx, '30/06/2026', async (page) => {
        const tags = await readTags(page);
        assert.ok(!tags.includes('TG-005'), 'TG-005 (5 - 5 = 0) is absent');
        assert.ok(tags.includes('TG-006'), 'TG-006 (6 - 6 + 6 = 6) is present');
        return {
          observation: 'TG-005 absent, TG-006 present in Stock',
          expected: { absent: 'TG-005', present: 'TG-006' },
        };
      }),
  ),

  // T06 Required and invalid
  C(
    'huid-report.invalid.from-after-to-empty',
    'T06',
    "RP_HUID.cs:1761 {{AND C.VCH_DATE >= '}}",
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        await setFilters(page, { from: '30/06/2026', to: '05/04/2026' });
        await runView(page, 'In Tag');
        await expectTags(page, []);
        await runView(page, 'Out Tag');
        await expectTags(page, []);
        await noMessage(page);
        // Stock ignores From and uses To only: TG-011 and TG-014 have stock dates on or before 05/04/2026.
        await runView(page, 'Stock Tag');
        await expectTags(page, ['TG-011', 'TG-014']);
        return {
          observation: 'In and Out empty, no message; Stock lists TG-011, TG-014',
          expected: { in: [], out: [], stock: ['TG-011', 'TG-014'] },
        };
      }),
  ),
  C(
    'huid-report.invalid.empty-result-no-message',
    'T06',
    'RP_HUID.cs:1877 {{DGV_FILL();}}',
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        await setFilters(page, { ...WINDOW, item: 'Silver', product: 'PR-RING' });
        await runView(page, 'In Tag');
        await expectTags(page, []);
        await noMessage(page);
        return { observation: 'empty grid, no message', expected: { rows: 0, message: false } };
      }),
  ),
  C(
    'huid-report.invalid.search-apostrophe-no-error',
    'T06',
    `RP_HUID.cs:1669 {{dataView.RowFilter = "HuId Like  '%" + ((TextEdit)tSerchAll).Text +}}`,
    (ctx) =>
      withCase(ctx, async () => {
        const { page } = await ctx.session();
        await open(page);
        await setFilters(page, WINDOW);
        await runView(page, 'In Tag');
        await field(page, 'Search').fill("O'NEIL");
        await expectTags(page, []);
        await noMessage(page);
        return {
          observation: 'apostrophe in search: no error, empty grid',
          expected: { rows: 0, message: false },
        };
      }),
  ),
];
