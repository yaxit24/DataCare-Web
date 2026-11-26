import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import * as data from './stockReportData.mjs';
import {
  FIELD,
  M,
  ROUTE,
  WORKED,
  assertFig,
  button,
  cellsOf,
  drill,
  fig,
  figs,
  gridOf,
  gridRow,
  movements,
  movementsOf,
  openScreen,
  ready,
  rowNames,
  run,
  setDate,
  text3,
  textPcs,
  totalRow,
} from './stockReportScreen.mjs';

/**
 * Stock Report cases that read the data set of stockReportData.mjs (entry, filters, formulas, drill-downs, reopen,
 * keyboard). Every figure is the worked table of orchestration/work/WP-16/cases.md section 1, built by the real
 * screens; the cases open the report in the browser and read the grid.
 */
export const C = (id, group, kind, source, run, extra = {}) => ({
  id: `stock-report.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'refusal'
      ? ['browser', 'expected', 'database']
      : kind === 'mutation'
        ? ['browser', 'expected', 'database', 'downstream']
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});

/** Make sure the data set exists (built by the first case that needs it), then run the case body. */
export const onData = async (ctx, fn, upTo) => {
  await data.ensureBuilt(ctx, upTo);
  return fn();
};

const A = data.ITEMS.A.name;
const B = data.ITEMS.B.name;
const S = data.ITEMS.S.name;
const rowOf = async (page, name) => cellsOf(gridRow(page, name));

export const dataCases = [
  C(
    'entry.route-and-caption',
    'T01',
    'read-only',
    'MDI_FORM.cs:8881 case "Stock Report"; MDI_FORM.cs:8883 new RP_STOCK(); Tag Stock is its own case (MDI_FORM.cs:8891, RP_TAG)',
    async (ctx) => {
      const { page } = await ctx.session();
      await page.goto('/dashboard');
      const stock = page.locator('nav.sidebar a[href="/reports/stock-report"]');
      const tag = page.locator('nav.sidebar a[href="/reports/tag-stock"]');
      await stock.first().waitFor();
      await tag.first().waitFor();
      assert.equal(await stock.count(), 1);
      assert.equal(((await stock.first().textContent()) ?? '').trim(), 'Stock Report');
      assert.equal(await tag.count(), 1);
      assert.equal(((await tag.first().textContent()) ?? '').trim(), 'Tag-Stock Report');
      await page.goto(ROUTE);
      await page.getByRole('heading', { name: 'Stock Report', exact: true }).waitFor();
      assert.equal(new URL(page.url()).pathname, ROUTE);
      await page.goto('/reports/tag-stock');
      await page.getByRole('heading', { name: /Tag/ }).first().waitFor();
      assert.equal(
        await page.getByRole('heading', { name: 'Stock Report', exact: true }).count(),
        0,
      );
      return {
        observation:
          'nav shows "Stock Report" -> /reports/stock-report and "Tag-Stock Report" -> /reports/tag-stock',
        expected: { stock: ROUTE, tag: '/reports/tag-stock' },
      };
    },
  ),
  C(
    'entry.tag-stock-stays-separate',
    'T01',
    'read-only',
    'MDI_FORM.cs:8881 (RP_STOCK) and :8891 (RP_TAG) are two cases; the rights string of the Stock Report is its own (----PL)',
    async (ctx) =>
      onData(ctx, async () => {
        const { page, context } = await openBoth(ctx);
        // Tab 1: the Stock Report shows its movement summary; tab 2: Tag Stock lists tags. Neither shares the other's grid.
        await openScreen(page);
        await run(page, 'Item');
        await gridRow(page, A).waitFor();
        const tagPage = await context.newPage();
        await tagPage.goto('/reports/tag-stock');
        await tagPage.getByRole('heading', { name: 'Tag Stock', exact: true }).waitFor();
        await tagPage.getByLabel('From', { exact: true }).fill(`01/04/${data.START_YEAR}`);
        await tagPage.getByLabel('To', { exact: true }).fill(`31/03/${data.START_YEAR + 1}`);
        await tagPage.getByRole('button', { name: 'Stock Tag', exact: true }).click();
        const tagGrid = tagPage.getByTestId('tag-stock-grid');
        await tagGrid.waitFor();
        await tagGrid.locator('tbody tr', { hasText: data.TAG.T4 }).first().waitFor();
        const tagHeads = (await tagGrid.locator('thead th').allInnerTexts()).map((t) => t.trim());
        assert.ok(tagHeads.includes('TagNo'), `Tag Stock lists tags: ${tagHeads}`);
        assert.equal(
          await gridOf(tagPage).count(),
          0,
          'the Stock Report grid is not on the Tag Stock screen',
        );
        const stockHeads = (await gridOf(page).locator('thead th').allInnerTexts()).map((t) =>
          t.trim(),
        );
        assert.deepEqual(stockHeads.slice(0, 4), ['SrNo', 'Item Name', 'OpPcs', 'OpWt']);
        assert.ok(!stockHeads.includes('TagNo'), 'the Stock Report grid has no tag column');
        // Separate rights: a user holding only the Stock Report right may open it and may not open Tag Stock.
        const viewer = await ctx.session(data.at(USERS.printViewer.user));
        await grantOnly(ctx, USERS.printViewer.user, 'Stock Report', 'Y');
        const own = await viewer.page.request.get('/api/reports/stock-report/defaults');
        const other = await viewer.page.request.get('/api/reports/tag-stock?tab=stock');
        assert.equal(own.status(), 200);
        assert.equal(other.status(), 403);
        await viewer.page.goto('/dashboard');
        await viewer.page.locator('nav.sidebar').waitFor();
        assert.equal(
          await viewer.page.locator('nav.sidebar a[href="/reports/tag-stock"]').count(),
          0,
        );
        assert.equal(
          await viewer.page.locator('nav.sidebar a[href="/reports/stock-report"]').count(),
          1,
        );
        await dropRights(ctx, USERS.printViewer.user);
        return {
          observation: `Stock Report grid ${stockHeads.slice(0, 4)} vs Tag Stock ${tagHeads.slice(0, 4)}; own right ${own.status()}, Tag Stock ${other.status()}`,
          expected: { stockRoute: ROUTE, tagRoute: '/reports/tag-stock', rights: [200, 403] },
        };
      }),
  ),
  C(
    'entry.default-fields',
    'T01',
    'read-only',
    'RP_STOCK.cs:3705 From = year opening date; :3706 To = system date; :3628 Item Type Gold; :3636 Stock Type All; :3647 Gross unchecked for STK_RPT_TYPE N; eight dimension buttons',
    async (ctx) => {
      const { page } = await ctx.session();
      await page.goto(ROUTE);
      await button(page, 'Item').waitFor();
      await ready(page);
      const from = await page.locator(FIELD.from).inputValue();
      const to = await page.locator(FIELD.to).inputValue();
      assert.match(from, /^\d{2}\/\d{2}\/\d{4}$/);
      assert.match(to, /^\d{2}\/\d{2}\/\d{4}$/);
      assert.equal(await page.locator(FIELD.type).inputValue(), 'G');
      assert.equal(await page.locator(FIELD.stock).inputValue(), 'all');
      assert.equal(await page.getByLabel('Gross Wise Weight').isChecked(), false);
      assert.equal(await gridOf(page).count(), 0);
      const names = await page.locator('main button.ghost').allInnerTexts();
      assert.deepEqual(
        names.slice(0, 8).map((t) => t.trim()),
        ['Item', 'Product', 'Group', 'Design', 'Safe', 'Counter', 'Trading', 'Size'],
      );
      return {
        observation: `defaults ${from}..${to}, Gold, All, net; empty grid; eight buttons`,
        expected: { itemType: 'G', stockType: 'all', gross: false },
      };
    },
  ),
  C(
    'entry.item-type-list',
    'T01',
    'read-only',
    'RP_STOCK.cs:3620-3627 Item Type list: blank, Gold, Silver, Diamond, Real Stone, Emitation, Other, Platinum',
    async (ctx) => {
      const { page } = await ctx.session();
      await page.goto(ROUTE);
      await page.locator(FIELD.type).waitFor();
      const options = (await page.locator('#sr-ittype option').allInnerTexts()).map((t) =>
        t.trim(),
      );
      assert.deepEqual(options, [
        '',
        'Gold',
        'Silver',
        'Diamond',
        'Real Stone',
        'Emitation',
        'Other',
        'Platinum',
      ]);
      return { observation: 'Item Type list in desktop order', expected: { options } };
    },
  ),

  // ---- T02 filters ---------------------------------------------------------------------------------------------
  C(
    'filter.date-range',
    'T02',
    'read-only',
    'RP_STOCK.cs:4284 FROM <= VCH_DATE <= TO for the middle columns, Opening below FROM, Closing to TO',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: data.ITEMS.A.code } });
        await run(page);
        assertFig(await rowOf(page, A), WORKED.A, 'W1 item A');
        await setDate(page, FIELD.to, data.W2[1]);
        await run(page);
        assertFig(await rowOf(page, A), [13, 126, 5, 43, 1, 12, 0, 0, 1, 12, 18, 169], 'W2 item A');
        return {
          observation:
            'W1 row 13/126 .. 14/138; after To = D24 the row is 13/126, 5/43, 1/12, -, 1/12, 18/169',
          expected: { w1: WORKED.A, w2Closing: '18 / 169.000' },
        };
      }),
  ),
  C(
    'filter.from-after-to',
    'T02',
    'read-only',
    'RP_STOCK.cs:4712 no from/to check and no message; an empty middle range still has rows',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { from: data.D(40), to: data.D(10), itemType: 'G' });
        await run(page);
        // Opening = every movement dated before D40, Closing = every movement up to D10, middle columns blank.
        assertFig(await rowOf(page, A), [14, 138, 0, 0, 0, 0, 0, 0, 0, 0, 13, 126], 'item A');
        assertFig(await rowOf(page, B), [6, 70, 0, 0, 0, 0, 0, 0, 0, 0, 5, 50], 'item B');
        assertFig(
          await cellsOf(totalRow(page)),
          [20, 208, 0, 0, 0, 0, 0, 0, 0, 0, 18, 176],
          'total',
        );
        assert.equal(await page.getByTestId('stock-error').count(), 0);
        assert.equal(await page.getByTestId('stock-message').count(), 0);
        return {
          observation:
            'From D40 > To D10: gold rows A 14/138 -> 13/126, B 6/70 -> 5/50; total 20/208 -> 18/176; no message',
          expected: { total: '20 / 208.000 -> 18 / 176.000' },
        };
      }),
  ),
  C(
    'filter.item-type',
    'T02',
    'read-only',
    'RP_STOCK.cs:4303 Item Type first letter; :4427 GROUP BY item ORDER BY IT_NAME',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { itemType: '' });
        await run(page);
        assert.deepEqual(await rowNames(page), [B, A, S]);
        assertFig(await cellsOf(totalRow(page)), WORKED.ALL, 'every metal');
        await page.locator(FIELD.type).selectOption('G');
        await run(page);
        assert.deepEqual(await rowNames(page), [B, A]);
        assertFig(await cellsOf(totalRow(page)), WORKED.GOLD, 'gold');
        await page.locator(FIELD.type).selectOption('S');
        await run(page);
        assert.deepEqual(await rowNames(page), [S]);
        assertFig(await rowOf(page, S), WORKED.S, 'silver');
        return {
          observation: 'blank: B, A, S (total 130/1253); Gold: B, A (20/208); Silver: S (110/1045)',
          expected: { blank: [B, A, S], gold: '20 / 208.000', silver: '110 / 1,045.000' },
        };
      }),
  ),
  C(
    'filter.stock-type-tag-item',
    'T02',
    'read-only',
    'RP_STOCK.cs:4287 TAG_NO <> N; :4291 TAG_NO = N; cases.md W2 Tag + Item = All',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, {
          from: data.W2[0],
          to: data.W2[1],
          itemType: 'G',
          filters: { item: data.ITEMS.A.code },
        });
        await page.locator(FIELD.stock).selectOption('tag');
        await run(page);
        assertFig(await rowOf(page, A), [3, 26, 1, 3, 1, 12, 0, 0, 1, 12, 4, 29], 'tag');
        await page.locator(FIELD.stock).selectOption('item');
        await run(page);
        assertFig(await rowOf(page, A), [10, 100, 4, 40, 0, 0, 0, 0, 0, 0, 14, 140], 'item');
        await page.locator(FIELD.stock).selectOption('all');
        await run(page);
        assertFig(await rowOf(page, A), [13, 126, 5, 43, 1, 12, 0, 0, 1, 12, 18, 169], 'all');
        return {
          observation: 'Tag closing 4/29.000 + Item closing 14/140.000 = All 18/169.000',
          expected: { tag: '4/29.000', item: '14/140.000', all: '18/169.000' },
        };
      }),
  ),
  C('filter.account', 'T02', 'read-only', 'RP_STOCK.cs:4295 AND A.AC_CODE = AcCode', async (ctx) =>
    onData(ctx, async () => {
      const { page } = await ctx.session();
      await openScreen(page, { filters: { account: data.CUS.code } });
      await run(page);
      assert.deepEqual(await rowNames(page), [A]);
      assertFig(await rowOf(page, A), [0, 0, 0, 0, 1, 12, 1, 8, 1, 12, -1, -8], 'customer');
      await page.locator(FIELD.account).fill(data.SUP.code);
      await run(page);
      assertFig(await rowOf(page, A), [0, 0, 4, 40, 0, 0, 2, 20, 0, 0, 2, 20], 'supplier item A');
      assertFig(await rowOf(page, S), [0, 0, 10, 95, 0, 0, 0, 0, 0, 0, 10, 95], 'supplier item S');
      return {
        observation:
          'CUS1: only A, closing -1 / -8.000; SUP1: A purchase 4/40 outward 2/20 closing 2/20, S 10/95',
        expected: { customer: 'A -1 / -8.000', supplier: 'A 2 / 20.000, S 10 / 95.000' },
      };
    }),
  ),
  C('filter.tag-number', 'T02', 'read-only', 'RP_STOCK.cs:4299 AND A.TAG_NO = TagNo', async (ctx) =>
    onData(ctx, async () => {
      const { page } = await ctx.session();
      await openScreen(page, { filters: { tag: data.TAG.T1 } });
      await run(page);
      assert.deepEqual(await rowNames(page), [A]);
      assertFig(await rowOf(page, A), [1, 12, 0, 0, 1, 12, 0, 0, 1, 12, 1, 12], 'tag T1');
      return {
        observation: 'tag T1: one row, opening 1/12, inward 1/12, sale 1/12, closing 1/12',
        expected: { row: 'A 1/12 .. 1/12' },
      };
    }),
  ),
  C(
    'filter.item-code',
    'T02',
    'read-only',
    'RP_STOCK.cs:4315 AND A.IT_CODE = It Code',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: data.ITEMS.B.code } });
        await run(page, 'Group');
        assert.deepEqual(await rowNames(page), ['ZR GOLD ORNAMENTS']);
        assertFig(
          await rowOf(page, 'ZR GOLD ORNAMENTS'),
          [5, 50, 1, 20, 0, 0, 0, 0, 0, 0, 6, 70],
          'group',
        );
        return {
          observation:
            'It Code ZCHN with the Group dimension: GOLD ORNAMENTS 5/50, 1/20, 6/70 (not 20/208)',
          expected: { group: '5/50 .. 6/70' },
        };
      }),
  ),
  C(
    'filter.product-group',
    'T02',
    'read-only',
    'RP_STOCK.cs:4307 B.PR_CODE; :4311 B.GR_CODE',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { product: 'ZB' } });
        await run(page);
        assert.deepEqual(await rowNames(page), [B]);
        assertFig(await rowOf(page, B), WORKED.B, 'product ZB');
        await page.locator(FIELD.product).fill('');
        await page.locator(FIELD.group).fill('ZGS');
        await run(page);
        assert.deepEqual(await rowNames(page), [S]);
        assertFig(await rowOf(page, S), WORKED.S, 'group ZGS');
        return {
          observation:
            'Pr Code ZB: only B (5/50 -> 6/70); Gr Code ZGS: only S (100/950 -> 110/1045)',
          expected: { product: 'B', group: 'S' },
        };
      }),
  ),
  C('filter.design', 'T02', 'read-only', 'RP_STOCK.cs:4319 AND A.DESIGN_NO = Design', async (ctx) =>
    onData(ctx, async () => {
      const { page } = await ctx.session();
      await openScreen(page, {
        from: data.W3[0],
        to: data.W3[1],
        itemType: 'G',
        filters: { design: 'D1' },
      });
      await run(page);
      assert.deepEqual(await rowNames(page), [A]);
      assertFig(await rowOf(page, A), [1, 12, 1, 3, 0, 0, 0, 0, 0, 0, 2, 15], 'design D1');
      return {
        observation:
          'W3, Gold, design D1: A opening 1/12, purchase 1/3, closing 2/15; B (design D2) absent',
        expected: { row: 'A 1/12, 1/3 .. 2/15' },
      };
    }),
  ),
  C('filter.safe', 'T02', 'read-only', 'RP_STOCK.cs:4323 AND B.SAFE_NAME = Safe', async (ctx) =>
    onData(ctx, async () => {
      const { page } = await ctx.session();
      await openScreen(page, { itemType: 'G', filters: { safe: 'VAULT' } });
      await run(page);
      assert.deepEqual(await rowNames(page), [B]);
      assertFig(await rowOf(page, B), WORKED.B, 'safe VAULT');
      return { observation: 'Safe VAULT: only B 5/50, 1/20, closing 6/70', expected: { row: 'B' } };
    }),
  ),
  C(
    'filter.counter',
    'T02',
    'read-only',
    'RP_STOCK.cs:4327 AND A.TBL_CODE = the chosen counter',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { counter: '002' } });
        await run(page);
        assert.deepEqual(await rowNames(page), [B, A]);
        assertFig(await rowOf(page, A), [0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 1, 3], 'counter two item A');
        assertFig(
          await rowOf(page, B),
          [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 10],
          'counter two item B',
        );
        return {
          observation:
            'counter 002: A purchase 1/3 closing 1/3 (tag T4); B closing 1/10 (transfer in); no other row',
          expected: { rows: [B, A] },
        };
      }),
  ),
  C(
    'filter.gross-check-box',
    'T02',
    'read-only',
    'RP_STOCK.cs:4280 net unchecked / gross checked; :5710 ticking the box does not refresh the grid',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: data.ITEMS.A.code } });
        await run(page);
        assertFig(await rowOf(page, A), WORKED.A, 'net');
        await page.getByLabel('Gross Wise Weight').check();
        assertFig(await rowOf(page, A), WORKED.A, 'ticking does not refresh');
        await run(page);
        await page.waitForFunction(
          () =>
            document
              .querySelector('[data-testid="stock-grid"] tbody tr td:nth-child(4)')
              ?.textContent?.trim() === '132.200',
        );
        assertFig(
          await rowOf(page, A),
          [13, 132.2, 5, 45.15, 2, 17.75, 5, 37.8, 1, 12.5, 14, 144.8],
          'gross',
        );
        return {
          observation: 'net stays after ticking; gross after the second Item press',
          expected: { closingGross: '144.800' },
        };
      }),
  ),
  C(
    'filter.item-name-search',
    'T02',
    'read-only',
    'RP_STOCK.cs:3837 Name Like %text% over the result; empty text refills the grid (with its Total row)',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page);
        const count = () => page.locator('[data-testid="stock-grid"] tbody tr[data-row]').count();
        assert.equal(await count(), 3);
        assert.equal(await totalRow(page).count(), 1, 'the unfiltered grid has its Total row');
        await page.locator(FIELD.search).fill('RING');
        assert.equal(await count(), 1);
        // The desktop binds the filtered view as it is (RP_STOCK.cs:3837-3905): no "Total :" row while searching.
        assert.equal(await totalRow(page).count(), 0);
        await page.locator(FIELD.search).fill('ZZZ');
        assert.equal(await count(), 0);
        await page.locator(FIELD.search).fill("O'BR");
        assert.equal(await count(), 0);
        await page.locator(FIELD.search).fill('');
        assert.equal(await count(), 3);
        assert.equal(
          await totalRow(page).count(),
          1,
          'clearing refills the grid with its Total row',
        );
        return {
          observation:
            'RING -> 1 row (no Total), ZZZ -> 0, apostrophe -> 0, cleared -> 3 rows and the Total row',
          expected: { rows: [1, 0, 0, 3] },
        };
      }),
  ),

  // ---- T03 formulas and dimensions ------------------------------------------------------------------------------
  C(
    'formula.item-dimension-w1',
    'T03',
    'read-only',
    'RP_STOCK.cs:4284 signed sums; :4427 ORDER BY IT_NAME; :3790 zeros blank; cases.md section 1 worked table (W1 = D10..D40)',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page);
        assert.deepEqual(await rowNames(page), [B, A, S]);
        const srs = (
          await gridOf(page).locator('tbody tr[data-row] td:nth-child(1)').allInnerTexts()
        ).map((t) => t.trim());
        assert.deepEqual(srs, ['1', '2', '3']);
        assertFig(await rowOf(page, B), WORKED.B, 'B');
        assertFig(await rowOf(page, A), WORKED.A, 'A');
        assertFig(await rowOf(page, S), WORKED.S, 'S');
        return {
          observation:
            'rows B, A, S with the worked figures; zeros blank (B has no inward/outward/sale)',
          expected: { B: WORKED.B, A: WORKED.A, S: WORKED.S },
        };
      }),
  ),
  C(
    'formula.total-row',
    'T03',
    'read-only',
    'RP_STOCK.cs:5052 "Total :" row = sum of the grid columns, hidden transfer columns included; Closing = Opening + movements',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page);
        const total = totalRow(page);
        assert.equal(((await cellsOf(total))[1] ?? '').trim(), 'Total :');
        assertFig(await cellsOf(total), WORKED.ALL, 'total row');
        // The transfer in/out pair is hidden from the grid and summed in the totals: read it from the same run.
        const api = await data.snapshot(page);
        assert.deepEqual(
          [api.totals.tInPcs, api.totals.tInWt, api.totals.tOutPcs, api.totals.tOutWt],
          [1, 10, 1, 10],
        );
        const t = api.totals;
        assert.equal(
          t.clPcs,
          t.opPcs + t.prPcs + t.inPcs - t.outPcs - t.slPcs + t.tInPcs - t.tOutPcs,
        );
        assert.equal(t.clWt, t.opWt + t.prWt + t.inWt - t.outWt - t.slWt + t.tInWt - t.tOutWt);
        return {
          observation:
            'Total : 118/1126 .. 130/1253; hidden transfer 1/10 in and out; identity holds',
          expected: { closing: '130 / 1,253.000' },
        };
      }),
  ),
  C(
    'formula.dimension-group',
    'T03',
    'read-only',
    'RP_STOCK.cs:4329 GROUP BY B.GR_CODE,C.GR_NAME,B.IT_TYPE ORDER BY C.GR_NAME',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page, 'Group');
        assert.deepEqual(await rowNames(page), ['ZR GOLD ORNAMENTS', 'ZR SILVER ARTICLES']);
        assertFig(await rowOf(page, 'ZR GOLD ORNAMENTS'), WORKED.GOLD, 'gold ornaments');
        assertFig(await rowOf(page, 'ZR SILVER ARTICLES'), WORKED.S, 'silver articles');
        return {
          observation: 'group rows GOLD ORNAMENTS 20/208 and SILVER ARTICLES 110/1045',
          expected: { gold: '20 / 208.000', silver: '110 / 1,045.000' },
        };
      }),
  ),
  C(
    'formula.dimension-product',
    'T03',
    'read-only',
    'RP_STOCK.cs:4378 GROUP BY B.PR_CODE,C.PR_NAME,B.IT_TYPE ORDER BY C.PR_NAME',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page, 'Product');
        assert.deepEqual(await rowNames(page), ['ZR BOWL', 'ZR CHAIN', 'ZR RING']);
        assertFig(await rowOf(page, 'ZR BOWL'), WORKED.S, 'bowl');
        assertFig(await rowOf(page, 'ZR CHAIN'), WORKED.B, 'chain');
        assertFig(await rowOf(page, 'ZR RING'), WORKED.A, 'ring');
        return {
          observation: 'product rows BOWL, CHAIN, RING',
          expected: { names: ['BOWL', 'CHAIN', 'RING'] },
        };
      }),
  ),
  C(
    'formula.dimension-safe',
    'T03',
    'read-only',
    'RP_STOCK.cs:4489 GROUP BY B.SAFE_NAME,B.SAFE_NAME,B.IT_TYPE ORDER BY B.SAFE_NAME',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { itemType: 'G' });
        await run(page, 'Safe');
        assert.deepEqual(await rowNames(page), ['MAIN', 'VAULT']);
        assertFig(await rowOf(page, 'MAIN'), WORKED.A, 'MAIN');
        assertFig(await rowOf(page, 'VAULT'), WORKED.B, 'VAULT');
        // With the Item Type blank MAIN has one row per metal type: Gold 14/138 and Silver 110/1045.
        await page.locator(FIELD.type).selectOption('');
        await run(page, 'Safe');
        const main = (await rowNames(page)).filter((n) => n === 'MAIN').length;
        assert.equal(main, 2, 'MAIN has a gold row and a silver row');
        return {
          observation: 'Gold: MAIN (A) and VAULT (B); blank type: MAIN twice (Gold and Silver)',
          expected: { gold: ['MAIN', 'VAULT'], main: 2 },
        };
      }),
  ),
  C(
    'formula.dimension-design',
    'T03',
    'read-only',
    'RP_STOCK.cs:4588 GROUP BY A.DESIGN_NO,A.DESIGN_NO,B.IT_TYPE ORDER BY A.DESIGN_NO',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { from: data.W3[0], to: data.W3[1], itemType: 'G' });
        await run(page, 'Design');
        assert.deepEqual(await rowNames(page), ['', 'D1', 'D2']);
        const rows = await gridOf(page).locator('tbody tr[data-row]').all();
        assertFig(
          await cellsOf(rows[0]),
          [17, 164, 4, 40, 0, 0, 0, 0, 0, 0, 21, 204],
          'blank design',
        );
        assertFig(await cellsOf(rows[1]), [1, 12, 1, 3, 0, 0, 0, 0, 0, 0, 2, 15], 'D1');
        assertFig(await cellsOf(rows[2]), [0, 0, 1, 20, 0, 0, 0, 0, 0, 0, 1, 20], 'D2');
        assertFig(
          await cellsOf(totalRow(page)),
          [18, 176, 6, 63, 0, 0, 0, 0, 0, 0, 24, 239],
          'total',
        );
        return {
          observation: 'W3 Gold: blank 21/204, D1 2/15, D2 1/20; total closing 24/239',
          expected: { total: '24 / 239.000' },
        };
      }),
  ),
  C(
    'formula.dimension-size',
    'T03',
    'read-only',
    'RP_STOCK.cs:4539 GROUP BY A.ITM_SIZE,A.ITM_SIZE,B.IT_TYPE ORDER BY A.ITM_SIZE',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { from: data.W3[0], to: data.W3[1], itemType: 'G' });
        await run(page, 'Size');
        assert.deepEqual(await rowNames(page), ['', '7']);
        const rows = await gridOf(page).locator('tbody tr[data-row]').all();
        assert.deepEqual(figs(await cellsOf(rows[0])).slice(10), [textPcs(23), text3(219)]);
        assert.deepEqual(
          figs(await cellsOf(rows[1])).slice(2),
          fig([1, 20, 0, 0, 0, 0, 0, 0, 1, 20]),
        );
        return {
          observation: 'W3 Gold: blank size closing 23/219, size 7 purchase 1/20 closing 1/20',
          expected: { blank: '23 / 219.000', seven: '1 / 20.000' },
        };
      }),
  ),
  C(
    'formula.dimension-counter',
    'T03',
    'read-only',
    'RP_STOCK.cs:4637 GROUP BY A.TBL_CODE,C.TABLE_NAME,B.IT_TYPE ORDER BY C.TABLE_NAME; blank counters are 001',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page, 'Counter');
        // GROUP BY TBL_CODE, TABLE_NAME, IT_TYPE: CNT-ONE holds gold and silver, so it is two rows (gold, then silver).
        assert.deepEqual(await rowNames(page), ['CNT-ONE', 'CNT-ONE', 'CNT-TWO']);
        const ones = await gridOf(page).locator('tbody tr[data-row]', { hasText: 'CNT-ONE' }).all();
        const sum = new Array(12).fill(0);
        for (const r of ones)
          (await cellsOf(r))
            .slice(2)
            .forEach((t, i) => (sum[i] += Number(t.replace(/,/g, '')) || 0));
        assert.deepEqual(
          sum,
          [118, 1126, 15, 155, 2, 17, 5, 36, 1, 12, 128, 1240],
          `CNT-ONE gold + silver ${JSON.stringify(sum)}`,
        );
        assertFig(await rowOf(page, 'CNT-TWO'), [0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 2, 13], 'CNT-TWO');
        // The hidden transfer pair sits on the counters: out of 001, into 002 (1 / 10.000 each).
        const api = await data.snapshot(page, { extra: { dimension: 'counter' } });
        const sumOf = (name, key) =>
          api.rows.filter((r) => r.name === name).reduce((n, r) => n + r[key], 0);
        assert.deepEqual([sumOf('CNT-ONE', 'tOutPcs'), sumOf('CNT-ONE', 'tOutWt')], [1, 10]);
        assert.deepEqual([sumOf('CNT-TWO', 'tInPcs'), sumOf('CNT-TWO', 'tInWt')], [1, 10]);
        return {
          observation:
            'CNT-ONE closing 128/1240 (transfer out 1/10), CNT-TWO closing 2/13 (transfer in 1/10); sum 130/1253',
          expected: { one: '128 / 1,240.000', two: '2 / 13.000' },
        };
      }),
  ),
  C(
    'formula.dimension-trading',
    'T03',
    'read-only',
    'RP_STOCK.cs:4688 GROUP BY B.TRAD_TYPE,C.TRAD_NAME,B.IT_TYPE ORDER BY C.TRAD_NAME; a blank item type is taken from its group',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page, 'Trading');
        assert.deepEqual(await rowNames(page), ['ZR GOLD TRADE', 'ZR SILVER TRADE']);
        assertFig(await rowOf(page, 'ZR GOLD TRADE'), WORKED.GOLD, 'gold trade (A + B)');
        assertFig(await rowOf(page, 'ZR SILVER TRADE'), WORKED.S, 'silver trade');
        const [stored] = await data.rows(
          ctx,
          `SELECT coalesce("TRAD_TYPE",'') t FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
          data.ITEMS.B.code,
        );
        assert.equal(stored.t, '', 'the report derives the trading type and does not write it');
        return {
          observation:
            'GOLD TRADE (A+B) 20/208, SILVER TRADE 110/1045; item B TRAD_TYPE stays blank',
          expected: { gold: '20 / 208.000', silver: '110 / 1,045.000' },
        };
      }),
  ),

  // ---- T05 drill-downs ------------------------------------------------------------------------------------------
  C(
    'drill.opening-signed-total',
    'T05',
    'read-only',
    'RP_STOCK.cs:2896 Opening = VCH_DATE < FROM; fine = KR_FINE for + rows; :3175 signed total',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: data.ITEMS.A.code } });
        await run(page);
        const m = await drill(page, A, 'opening-pcs');
        assert.equal(m.rows.length, 4);
        assert.deepEqual(
          m.rows.map((r) => r[M.fine]),
          ['91.600', '10.800', '5.400', '7.200'],
        );
        assert.deepEqual(
          m.rows.map((r) => r[M.pcs]),
          ['10', '1', '1', '1'],
        );
        assert.deepEqual(m.total.slice(2, 6), ['13', '132.200', '126.000', '115.000']);
        return {
          observation:
            'opening movements M1,M4,M5,M6; total 13 / 132.200 / 126.000 / fine 115.000 (KR_FINE)',
          expected: { fine: '115.000' },
        };
      }),
  ),
  C(
    'drill.sale-uses-itm-fine',
    'T05',
    'read-only',
    'RP_STOCK.cs:2896 CASE WHEN ITM_SIGN = + THEN KR_FINE ELSE ITM_FINE END',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: data.ITEMS.A.code } });
        await run(page);
        const m = await drill(page, A, 'sale-wt');
        assert.equal(m.rows.length, 1);
        const cells = m.rows[0];
        assert.equal(cells[M.party], data.CUS.name);
        assert.equal(cells[M.tag], data.TAG.T1);
        assert.deepEqual(cells.slice(M.pcs), ['1', '12.500', '12.000', '11.040', '-']);
        assert.deepEqual(m.total.slice(2, 6), ['1', '12.500', '12.000', '11.040']);
        return {
          observation:
            'sale M10 shows ITM_FINE 11.040 (the sale is saved from the Sales screen with touch 92)',
          expected: { fine: '11.040' },
        };
      }),
  ),
  C(
    'drill.purchase',
    'T05',
    'read-only',
    'RP_STOCK.cs:2900 + and TR_TYPE P, FROM..TO; fine = KR_FINE',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page);
        const a = await drill(page, A, 'purchase-pcs');
        assert.equal(a.rows.length, 2);
        assert.deepEqual(
          [a.rows[0][M.tag], ...a.rows[0].slice(M.pcs)],
          [data.TAG.T4, '1', '3.150', '3.000', '2.700', '+'],
        );
        assert.equal(a.rows[1][M.party], data.SUP.name);
        assert.deepEqual(
          [a.rows[1][M.tag], ...a.rows[1].slice(M.pcs)],
          ['N', '4', '42.000', '40.000', '36.800', '+'],
        );
        assert.deepEqual(a.total.slice(2, 6), ['5', '45.150', '43.000', '39.500']);
        await button(page, 'Back').click();
        const b = await drill(page, B, 'purchase-wt');
        assert.equal(b.rows.length, 1);
        assert.deepEqual(
          [b.rows[0][M.tag], ...b.rows[0].slice(M.pcs)],
          [data.TAG.T5, '1', '21.000', '20.000', '18.000', '+'],
        );
        return {
          observation:
            'A purchase rows M7 (tag) and M9 (supplier, loose) total 5/45.150/43.000/39.500; B row M8',
          expected: { a: '5 / 45.150 / 43.000 / 39.500', b: '1 / 21.000 / 20.000 / 18.000' },
        };
      }),
  ),
  C(
    'drill.inward-and-outward',
    'T05',
    'read-only',
    'RP_STOCK.cs:2904 + and I; :2908 - and O ordered by VCH_DATE; every - row shows ITM_FINE',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: data.ITEMS.A.code } });
        await run(page);
        const inward = await drill(page, A, 'inward-pcs');
        assert.deepEqual(
          inward.rows.map((r) => [r[M.party], r[M.tag], r[M.pcs], r[M.gwt], r[M.nwt], r[M.fine]]),
          [
            [data.CUS.name, data.TAG.T1, '1', '12.500', '12.000', '11.040'],
            ['', 'N', '1', '5.250', '5.000', '4.580'],
          ],
        );
        assert.deepEqual(inward.total.slice(2, 6), ['2', '17.750', '17.000', '15.620']);
        await button(page, 'Back').click();
        const outward = await drill(page, A, 'outward-pcs');
        assert.deepEqual(
          outward.rows.map((r) => [r[M.party], r[M.tag], r[M.pcs], r[M.gwt], r[M.nwt], r[M.fine]]),
          [
            [data.SUP.name, 'N', '2', '21.000', '20.000', '18.400'],
            ['', 'N', '1', '2.100', '2.000', '1.832'],
            ['', data.TAG.T2, '1', '6.300', '6.000', '5.496'],
            [data.CUS.name, data.TAG.T3, '1', '8.400', '8.000', '7.328'],
          ],
        );
        assert.deepEqual(outward.total.slice(2, 6), ['5', '37.800', '36.000', '33.056']);
        return {
          observation:
            'inward M14, M16 total 2/17.750/17.000/15.620; outward M15, M17, M18, M19 total 5/37.800/36.000/33.056',
          expected: { inwardFine: '15.620', outwardFine: '33.056' },
        };
      }),
  ),
  C(
    'drill.closing-signed-total',
    'T05',
    'read-only',
    'RP_STOCK.cs:2916 VCH_DATE <= TO; :3175 + added, - subtracted; :3220 the Total row',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: data.ITEMS.A.code } });
        await run(page);
        const m = await drill(page, A, 'closing-pcs');
        assert.equal(m.rows.length, 13);
        assert.deepEqual(m.total.slice(2, 6), ['14', '144.800', '138.000', '126.024']);
        // The Total row equals the summary's Closing cell.
        await button(page, 'Back').click();
        assert.deepEqual(figs(await rowOf(page, A)).slice(10), ['14', '138.000']);
        return {
          observation:
            '13 movements; signed total 14 / 144.800 / 138.000 / fine 126.024 = the Closing cell 14 / 138.000',
          expected: { total: '14 / 144.800 / 138.000 / 126.024' },
        };
      }),
  ),
  C(
    'drill.tag-filter-fine',
    'T05',
    'read-only',
    'RP_STOCK.cs:2896 fine from KR_FINE (+) or ITM_FINE (-); the shared onHandNet() would give 10.992',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { tag: data.TAG.T1 } });
        await run(page);
        const m = await drill(page, A, 'closing-pcs');
        assert.deepEqual(
          m.rows.map((r) => [r[M.sign], r[M.fine]]),
          [
            ['+', '10.800'],
            ['-', '11.040'],
            ['+', '11.040'],
          ],
        );
        assert.deepEqual(m.total.slice(2, 6), ['1', '12.500', '12.000', '10.800']);
        return {
          observation:
            'tag T1 closing movements M4 +10.800, M10 -11.040, M14 +11.040: fine total 10.800, 1 pcs, net 12.000',
          expected: { fine: '10.800' },
        };
      }),
  ),
  C(
    'drill.non-drill-columns',
    'T05',
    'read-only',
    'RP_STOCK.cs:2892 default: SrNo, name and the Total row open nothing',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page);
        const targets = [
          gridRow(page, A).locator('td').nth(0),
          gridRow(page, A).locator('td').nth(1),
          totalRow(page).locator('td').nth(1),
          totalRow(page).locator('td').nth(2),
        ];
        for (const target of targets) {
          await target.dblclick();
          await page.waitForTimeout(250);
          assert.equal(await movementsOf(page).count(), 0, 'no movement grid opened');
          assert.equal(await gridOf(page).count(), 1, 'the summary stays');
        }
        assert.equal(await button(page, 'Exit').count(), 1);
        return {
          observation: 'SrNo, name and Total cells opened nothing; summary stayed',
          expected: { opened: false },
        };
      }),
  ),
  C(
    'drill.same-filters-as-summary',
    'T05',
    'read-only',
    'the web drill-down repeats the summary filters (the desktop appends its own list, RP_STOCK.cs:2919-2958)',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, {
          from: data.W2[0],
          to: data.W2[1],
          itemType: 'G',
          stockType: 'item',
          filters: { item: data.ITEMS.A.code },
        });
        await run(page);
        const summary = figs(await rowOf(page, A));
        const opening = await drill(page, A, 'opening-pcs');
        assert.equal(opening.rows.length, 1);
        assert.deepEqual([opening.total[2], opening.total[4]], [summary[0], summary[1]]);
        await button(page, 'Back').click();
        const closing = await drill(page, A, 'closing-pcs');
        assert.equal(closing.rows.length, 2);
        assert.deepEqual([closing.total[2], closing.total[4]], [summary[10], summary[11]]);
        assert.deepEqual([summary[10], summary[11]], ['14', '140.000']);
        return {
          observation:
            'Stock Type Item: opening 1 row 10/100, closing 2 rows 14/140 = the summary cells',
          expected: { opening: '10 / 100.000', closing: '14 / 140.000' },
        };
      }),
  ),
  C(
    'drill.back-and-escape',
    'T05',
    'read-only',
    'RP_STOCK.cs:3992 Esc with &Back showing returns to the summary; :4006 otherwise closes the form',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: data.ITEMS.A.code } });
        await run(page);
        await gridRow(page, A).locator('td[data-col="closing-pcs"]').dblclick();
        await button(page, 'Back').waitFor();
        assert.equal(await gridOf(page).count(), 0);
        await page.keyboard.press('Escape');
        await gridOf(page).waitFor();
        await button(page, 'Exit').waitFor();
        assert.equal(await movementsOf(page).count(), 0);
        return {
          observation: 'Esc returned from the drill-down to the summary; button reads Exit again',
          expected: { back: true },
        };
      }),
  ),

  // ---- T06 / T08 / T17 -----------------------------------------------------------------------------------------
  C(
    'invalid.empty-result',
    'T06',
    'refusal',
    'RP_STOCK.cs:4712 an empty result leaves the grid blank: no message, no Total row',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { tag: 'NOSUCH' } });
        await button(page, 'Item').click();
        await gridOf(page).waitFor();
        assert.equal(await gridOf(page).locator('tbody tr').count(), 0);
        assert.equal(await page.getByTestId('stock-error').count(), 0);
        return {
          observation: 'empty grid, no message, no Total row',
          expected: { rows: 0 },
          database: { unchanged: true },
        };
      }),
  ),
  C(
    'reopen.same-result-twice',
    'T08',
    'read-only',
    'a run has no time dependence apart from the To default; the order is stable',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const read = async () => {
          await openScreen(page);
          await run(page);
          const rows = [];
          for (const row of await gridOf(page).locator('tbody tr').all())
            rows.push(await cellsOf(row));
          return rows;
        };
        const first = await read();
        await run(page);
        const again = [];
        for (const row of await gridOf(page).locator('tbody tr').all())
          again.push(await cellsOf(row));
        assert.deepEqual(again, first, 'pressing Item twice');
        assert.deepEqual(await read(), first, 'closing and reopening the screen');
        assert.equal(first.length, 4, 'three rows and the Total row');
        return {
          observation:
            'three runs (twice on one screen, once after reopening) gave identical rows and totals',
          expected: { rows: 4 },
        };
      }),
  ),
  C(
    'reopen.cancel-clears',
    'T08',
    'read-only',
    'RP_STOCK Cancel button runs CLEAR_DATA: the grid and the typed filters are cleared',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { tag: data.TAG.T1 } });
        await run(page);
        await button(page, 'Cancel').click();
        await page.waitForFunction(() => !document.querySelector('[data-testid="stock-grid"]'));
        // CLEAR_DATA (RP_STOCK.cs:3721) resets the filters to the form defaults, which the screen re-reads from
        // /defaults after the grid is gone, so wait for them to land.
        await page.waitForFunction(
          () =>
            document.querySelector('#sr-tag')?.value === '' &&
            document.querySelector('#sr-ittype')?.value === 'G',
        );
        assert.equal(await page.locator(FIELD.tag).inputValue(), '');
        assert.equal(await page.locator(FIELD.type).inputValue(), 'G');
        return {
          observation: 'Cancel cleared the grid and the tag filter',
          expected: { grid: false, tag: '' },
        };
      }),
  ),
  C(
    'keyboard.dimension-letters',
    'T17',
    'read-only',
    'RP_STOCK.cs:3954-3987 G runs Group, I runs Item, P runs Product (no keys for the other dimensions)',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await page.getByRole('heading', { name: 'Stock Report', exact: true }).click();
        await page.keyboard.press('g');
        await gridRow(page, 'ZR GOLD ORNAMENTS').waitFor();
        await page.keyboard.press('p');
        await gridRow(page, 'ZR RING').waitFor();
        await page.keyboard.press('i');
        await gridRow(page, A).waitFor();
        return {
          observation: 'G, P, I ran Group, Product, Item',
          expected: { keys: ['g', 'p', 'i'] },
        };
      }),
  ),
];

// ---- helpers used by the cases above ----------------------------------------------------------------------------
async function openBoth(ctx) {
  const s = await ctx.session();
  return { page: s.page, context: s.context };
}
const execSql = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
/** A rights row at the stock-report location: the user may view `subMenu` (and print when `print` is Y). */
export async function grantOnly(ctx, user, subMenu, print = 'N') {
  await dropRights(ctx, user);
  await execSql(
    ctx,
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     VALUES($1,'01',$2,$3,'Report',$4,'Y','N','N',$5)`,
    data.LC,
    user,
    subMenu,
    print,
  );
}
export const dropRights = (ctx, user) =>
  execSql(
    ctx,
    `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "LC_CODE"=$2 AND "USER_NAME"=$3`,
    data.LC,
    user,
  );
