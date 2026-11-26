import assert from 'node:assert/strict';
import { mkdtemp, readFile, rm } from 'node:fs/promises';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { inflateRawSync } from 'node:zlib';
import * as data from './stockReportData.mjs';
import * as flows from './stockReportFlows.mjs';
import { C, onData } from './stockReportCases.mjs';
import { entryCases, keyboardCases } from './stockReportEntryCases.mjs';
import { inOutCases, printCases, zoomCases } from './stockReportZoomCases.mjs';
import { mustSet } from './settingsEffects.mjs';
import {
  FIELD,
  M,
  WORKED,
  assertFig,
  button,
  cellsOf,
  drill,
  fig,
  figs,
  gridOf,
  gridRow,
  movementsOf,
  openScreen,
  rowNames,
  run,
  totalRow,
} from './stockReportScreen.mjs';

/**
 * Stock Report cases that CREATE, EDIT or DELETE vouchers through the real entry screens and read what the report
 * shows afterwards (T07 create, T09 edit, T10 delete, T15 config, T16 output, T18 journeys). They follow the
 * worked table of orchestration/work/WP-16/cases.md section 1. A case that changes the data set puts it back, so the
 * cases after it still read the worked figures; the approval round trip is last and leaves the set altered (it is
 * torn down after it).
 */
const A = data.ITEMS.A;
const B = data.ITEMS.B;
const S = data.ITEMS.S;
const KEYS = [
  'opPcs',
  'opWt',
  'prPcs',
  'prWt',
  'inPcs',
  'inWt',
  'outPcs',
  'outWt',
  'slPcs',
  'slWt',
  'clPcs',
  'clWt',
];
const r3 = (n) => Math.round(n * 1000) / 1000;

/** The non-zero change of one item's report row across a data step (net or gross). */
const moved = (step, code, gross = false) => {
  const s = data.stepOf(step);
  const before = (gross ? s.before.gross : s.before.net).byItem[code] ?? {};
  const after = (gross ? s.after.gross : s.after.net).byItem[code] ?? {};
  const out = {};
  for (const k of KEYS) {
    const d = r3((after[k] ?? 0) - (before[k] ?? 0));
    if (d !== 0) out[k] = d;
  }
  return out;
};
/** One item's row of the Item dimension (W1 by default) as numbers. */
const rowFigures = async (page, code, opts) => {
  const { byItem } = await data.snapshot(page, opts);
  const row = byItem[code] ?? {};
  return Object.fromEntries(KEYS.map((k) => [k, r3(row[k] ?? 0)]));
};
const strip = (v) => String(v ?? '').replace(/^0+/, '');
const vch = (step, i = 0) => data.stepOf(step).vouchers[i];

/** Open the report for item A (W1), run Item, drill into `column` and return the movement grid. */
async function drillA(page, column, code = A.code) {
  await openScreen(page, { filters: { item: code } });
  await run(page);
  return drill(page, ITEM_NAME[code], column);
}
const ITEM_NAME = { [A.code]: A.name, [B.code]: B.name, [S.code]: S.name };
const pick = (m, test) => {
  const row = m.rows.find(test);
  assert.ok(row, `no movement row matched in ${JSON.stringify(m.rows)}`);
  return row;
};
const tail = (row) => [row[M.tag], row[M.pcs], row[M.gwt], row[M.nwt], row[M.fine], row[M.sign]];

/** A create case: the item-A delta of the step (net and gross) and the voucher's own drill-down row. */
const createCase = (id, step, source, steps) =>
  C(id, 'T07', 'mutation', source, async (ctx) =>
    onData(ctx, async () => {
      const { page } = await ctx.session();
      assert.deepEqual(
        moved(step, A.code),
        steps.net,
        `item A net delta ${JSON.stringify(moved(step, A.code))}`,
      );
      assert.deepEqual(
        moved(step, A.code, true),
        steps.gross,
        `item A gross delta ${JSON.stringify(moved(step, A.code, true))}`,
      );
      if (steps.others !== false) {
        assert.deepEqual(moved(step, B.code), {}, 'item B did not move');
        assert.deepEqual(moved(step, S.code), {}, 'item S did not move');
      }
      if (steps.drill) await steps.drill(page);
      return {
        observation: `${step}: item A net ${JSON.stringify(steps.net)}; gross ${JSON.stringify(steps.gross)}`,
        expected: { net: steps.net, gross: steps.gross },
      };
    }),
  );

export const createCases = [
  createCase(
    'create.item-opening',
    'item-opening',
    'Ac_Stock.cs:15 opening dated day before the year opens',
    {
      net: { opPcs: 10, opWt: 100, clPcs: 10, clWt: 100 },
      gross: { opPcs: 10, opWt: 105, clPcs: 10, clWt: 105 },
      others: false,
    },
  ),
  createCase(
    'create.tag-opening',
    'tag-opening',
    'Ac_Stock.cs:28 OPSTK; T1 before FROM, T4 inside the window is Purchase',
    {
      net: { opPcs: 1, opWt: 12, prPcs: 1, prWt: 3, clPcs: 2, clWt: 15 },
      gross: { opPcs: 1, opWt: 12.5, prPcs: 1, prWt: 3.15, clPcs: 2, clWt: 15.65 },
      drill: async (page) => {
        const o = await drillA(page, 'opening-pcs');
        assert.deepEqual(tail(pick(o, (r) => r[M.tag] === data.TAG.T1)), [
          data.TAG.T1,
          '1',
          '12.500',
          '12.000',
          '10.800',
          '+',
        ]);
        const p = await drillA(page, 'purchase-pcs');
        assert.deepEqual(tail(pick(p, (r) => r[M.tag] === data.TAG.T4)), [
          data.TAG.T4,
          '1',
          '3.150',
          '3.000',
          '2.700',
          '+',
        ]);
      },
    },
  ),
  createCase(
    'create.purchase',
    'purchase',
    'Ac_Stock.cs purchase posts + and TR_TYPE P; the supplier is the party',
    {
      net: { prPcs: 4, prWt: 40, clPcs: 4, clWt: 40 },
      gross: { prPcs: 4, prWt: 42, clPcs: 4, clWt: 42 },
      drill: async (page) => {
        const m = await drillA(page, 'purchase-pcs');
        assert.deepEqual(tail(pick(m, (r) => r[M.party] === data.SUP.name)), [
          'N',
          '4',
          '42.000',
          '40.000',
          '36.800',
          '+',
        ]);
      },
    },
  ),
  createCase('create.sale', 'sale', 'RP_STOCK.cs:2896 a - row shows ITM_FINE', {
    net: { slPcs: 1, slWt: 12, clPcs: -1, clWt: -12 },
    gross: { slPcs: 1, slWt: 12.5, clPcs: -1, clWt: -12.5 },
    drill: async (page) => {
      const m = await drillA(page, 'sale-wt');
      const row = pick(m, (r) => r[M.tag] === data.TAG.T1);
      assert.equal(row[M.party], data.CUS.name);
      assert.deepEqual(tail(row), [data.TAG.T1, '1', '12.500', '12.000', '11.040', '-']);
    },
  }),
  createCase(
    'create.sales-return',
    'sales-return',
    'Ac_Stock.cs:247 the return line carries its fine into KR_FINE',
    {
      net: { inPcs: 1, inWt: 12, clPcs: 1, clWt: 12 },
      gross: { inPcs: 1, inWt: 12.5, clPcs: 1, clWt: 12.5 },
      drill: async (page) => {
        const m = await drillA(page, 'inward-pcs');
        const row = pick(m, (r) => r[M.tag] === data.TAG.T1);
        assert.equal(row[M.party], data.CUS.name);
        assert.deepEqual(tail(row), [data.TAG.T1, '1', '12.500', '12.000', '11.040', '+']);
      },
    },
  ),
  createCase(
    'create.purchase-return',
    'purchase-return',
    'Ac_Stock.cs:331 PR_DETL posts - and TR_TYPE O',
    {
      net: { outPcs: 2, outWt: 20, clPcs: -2, clWt: -20 },
      gross: { outPcs: 2, outWt: 21, clPcs: -2, clWt: -21 },
      drill: async (page) => {
        const m = await drillA(page, 'outward-pcs');
        assert.deepEqual(tail(pick(m, (r) => r[M.party] === data.SUP.name)), [
          'N',
          '2',
          '21.000',
          '20.000',
          '18.400',
          '-',
        ]);
      },
    },
  ),
  createCase(
    'create.stock-adjust',
    'stock-adjust',
    'Ac_Stock.cs:54 CASE WHEN ITM_SIGN = + THEN I ELSE O',
    {
      net: { inPcs: 1, inWt: 5, outPcs: 1, outWt: 2, clWt: 3 },
      gross: { inPcs: 1, inWt: 5.25, outPcs: 1, outWt: 2.1, clWt: 3.15 },
      drill: async (page) => {
        const i = await drillA(page, 'inward-pcs');
        assert.deepEqual(tail(pick(i, (r) => r[M.tag] === 'N' && r[M.party] === '')), [
          'N',
          '1',
          '5.250',
          '5.000',
          '4.580',
          '+',
        ]);
        const o = await drillA(page, 'outward-pcs');
        assert.deepEqual(tail(pick(o, (r) => r[M.gwt] === '2.100')), [
          'N',
          '1',
          '2.100',
          '2.000',
          '1.832',
          '-',
        ]);
      },
    },
  ),
  createCase(
    'create.tag-cancel',
    'tag-cancel',
    'Tag Cancel takes the tag out of stock (a - row, ITM_FINE)',
    {
      net: { outPcs: 1, outWt: 6, clPcs: -1, clWt: -6 },
      gross: { outPcs: 1, outWt: 6.3, clPcs: -1, clWt: -6.3 },
      drill: async (page) => {
        const m = await drillA(page, 'outward-pcs');
        assert.deepEqual(tail(pick(m, (r) => r[M.tag] === data.TAG.T2)), [
          data.TAG.T2,
          '1',
          '6.300',
          '6.000',
          '5.496',
          '-',
        ]);
      },
    },
  ),
  createCase(
    'create.approval-issue',
    'approval-issue',
    'Ac_Stock.cs:68 APR ISU posts - with TR_TYPE O',
    {
      net: { outPcs: 1, outWt: 8, clPcs: -1, clWt: -8 },
      gross: { outPcs: 1, outWt: 8.4, clPcs: -1, clWt: -8.4 },
      drill: async (page) => {
        const m = await drillA(page, 'outward-pcs');
        const row = pick(m, (r) => r[M.tag] === data.TAG.T3);
        assert.equal(row[M.party], data.CUS.name);
        assert.deepEqual(tail(row), [data.TAG.T3, '1', '8.400', '8.000', '7.328', '-']);
      },
    },
  ),
];

// ---------------------------------------------------------------------------------------------------------------
// Settings and master edits that change what the report shows. Each puts the value back.
// ---------------------------------------------------------------------------------------------------------------
const rawSetting = async (ctx, key) =>
  (
    await data.rows(
      ctx,
      `SELECT "${key}"::text v FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    )
  )[0]?.v ?? null;
const putSetting = (ctx, key, value) =>
  data.exec(ctx, `UPDATE "CO_SET" SET "${key}"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`, value);

export const configCases = [
  C(
    'entry.default-gross-from-setting',
    'T01',
    'read-only',
    'RP_STOCK.cs:3647 STK_RPT_TYPE = G ticks Gross Wise Weight on open',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const original = await rawSetting(ctx, 'STK_RPT_TYPE');
        try {
          await mustSet(page, 'CO_SET.STK_RPT_TYPE', 'G');
          await openScreen(page, { filters: { item: A.code } });
          assert.equal(await page.getByLabel('Gross Wise Weight').isChecked(), true);
          await run(page);
          assertFig(
            await cellsOf(gridRow(page, A.name)),
            [13, 132.2, 5, 45.15, 2, 17.75, 5, 37.8, 1, 12.5, 14, 144.8],
            'gross W1 item A',
          );
        } finally {
          await putSetting(ctx, 'STK_RPT_TYPE', original);
        }
        return {
          observation:
            'STK_RPT_TYPE = G: the box is ticked on open and item A closing gross is 144.800',
          expected: { gross: true, closing: '14 / 144.800' },
        };
      }),
  ),
  C(
    'config.gross-setting-changes-default-only',
    'T15',
    'read-only',
    'RP_STOCK.cs:3647 the default is read at load; an open screen keeps its box until reopened',
    async (ctx) =>
      onData(ctx, async () => {
        const { page, context } = await ctx.session();
        const original = await rawSetting(ctx, 'STK_RPT_TYPE');
        const other = await context.newPage();
        try {
          await openScreen(page, { filters: { item: A.code } });
          assert.equal(await page.getByLabel('Gross Wise Weight').isChecked(), false);
          await mustSet(other, 'CO_SET.STK_RPT_TYPE', 'G');
          await run(page);
          assert.equal(
            await page.getByLabel('Gross Wise Weight').isChecked(),
            false,
            'the open screen keeps its box',
          );
          assert.deepEqual(
            figs(await cellsOf(gridRow(page, A.name))).slice(10),
            ['14', '138.000'],
            'still net',
          );
          await openScreen(page, { filters: { item: A.code } });
          assert.equal(
            await page.getByLabel('Gross Wise Weight').isChecked(),
            true,
            'reopened: ticked',
          );
          await run(page);
          assert.deepEqual(
            figs(await cellsOf(gridRow(page, A.name))).slice(10),
            ['14', '144.800'],
            'gross after reopen',
          );
        } finally {
          await putSetting(ctx, 'STK_RPT_TYPE', original);
          await other.close();
        }
        return {
          observation:
            'screen open before the change stayed net (138.000); reopened it was ticked and showed 144.800',
          expected: { open: '138.000', reopened: '144.800' },
        };
      }),
  ),
  C(
    'formula.rows-split-by-metal',
    'T03',
    'mutation',
    'RP_STOCK.cs:4329 GROUP BY B.GR_CODE,C.GR_NAME,B.IT_TYPE: the live item master decides the group',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        // The Item Master keeps product and group read-only once an item is opened (TR_ITM_MAST tPrCode), so the later
        // master change of the case is applied to the stored row, exactly as a legacy import or a data fix would.
        await data.exec(
          ctx,
          `UPDATE "ITEM_MAST" SET "GR_CODE"='ZGA' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
          S.code,
        );
        try {
          await openScreen(page);
          await run(page, 'Group');
          assert.deepEqual(await rowNames(page), ['ZR GOLD ORNAMENTS', 'ZR GOLD ORNAMENTS']);
          const rows = await gridOf(page).locator('tbody tr[data-row]').all();
          const got = [];
          for (const r of rows) got.push(figs(await cellsOf(r)).slice(10));
          assert.deepEqual(got.sort(), [
            ['110', '1,045.000'],
            ['20', '208.000'],
          ]);
          assert.equal(await gridRow(page, 'ZR SILVER ARTICLES').count(), 0);
        } finally {
          await data.exec(
            ctx,
            `UPDATE "ITEM_MAST" SET "GR_CODE"='ZGS' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
            S.code,
          );
        }
        return {
          observation:
            'GOLD ORNAMENTS yields a Gold row 20/208 and a Silver row 110/1045; SILVER ARTICLES has no row',
          expected: { gold: '20 / 208.000', silver: '110 / 1,045.000' },
        };
      }),
  ),
  C(
    'config.master-edit-after-voucher',
    'T15',
    'mutation',
    'the report reads the live item master: a renamed item and a changed safe move the rows, not the vouchers',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const renamed = 'ZR GOLD RING 24K';
        try {
          await flows.editItemMaster(page, A.code, { name: renamed, safe: 'VAULT' });
          await openScreen(page, { filters: { item: A.code } });
          await run(page);
          assert.deepEqual(await rowNames(page), [renamed]);
          assert.deepEqual(figs(await cellsOf(gridRow(page, renamed))), fig(WORKED.A));
          await openScreen(page, { itemType: 'G' });
          await run(page, 'Safe');
          const names = await rowNames(page);
          assert.deepEqual(names, ['VAULT'], `Safe rows ${names}`);
          assert.deepEqual(figs(await cellsOf(gridRow(page, 'VAULT'))).slice(10), [
            '20',
            '208.000',
          ]);
        } finally {
          await flows.editItemMaster(page, A.code, { name: A.name, safe: A.safe });
        }
        return {
          observation:
            'renamed item A shows under its new name with unchanged figures; its safe VAULT now holds all gold (20 / 208.000)',
          expected: { name: renamed, vault: '20 / 208.000' },
        };
      }),
  ),
  C(
    'config.cancelled-tag-and-previous-year',
    'T15',
    'read-only',
    'a cancelled tag stays in Opening and leaves stock only in windows that include the cancel date (D30)',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: A.code } });
        const closing = async (to) => {
          const snap = await data.snapshot(page, { to });
          return [snap.byItem[A.code].clPcs, snap.byItem[A.code].clWt];
        };
        const w2 = await data.snapshot(page, { from: data.W2[0], to: data.W2[1] });
        assert.equal(w2.byItem[A.code].opPcs, 13);
        assert.deepEqual(
          await closing(data.D(29)),
          [16, 152],
          'to D29 T2 (6.000) and T3 are still in stock',
        );
        assert.deepEqual(
          await closing(data.D(30)),
          [15, 146],
          'to D30 T2 has left (T3 goes on D33)',
        );
        const w1 = await data.snapshot(page);
        assert.equal(w1.byItem[A.code].opPcs, 13, 'T2 is in Opening of W1');
        return {
          observation:
            'closing to D29 = 16 / 152.000 (includes T2); to D30 = 15 / 146.000 (T2 gone)',
          expected: { d29: '16 / 152.000', d30: '15 / 146.000' },
        };
      }),
  ),
];

// ---------------------------------------------------------------------------------------------------------------
// Journey and output cases that read the whole worked table.
// ---------------------------------------------------------------------------------------------------------------
const signedSums = async (ctx, to) => {
  const [r] = await data.rows(
    ctx,
    `SELECT sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_PCS" ELSE -"ITM_PCS" END)::float p,
            sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_NWT" ELSE -"ITM_NWT" END)::float n,
            sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_GWT" ELSE -"ITM_GWT" END)::float g
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "LC_CODE"='${data.LC}' AND "CO_YEAR"='${data.YEAR}' AND "VCH_DATE"<='${to}'`,
  );
  return [r3(r.p), r3(r.n), r3(r.g)];
};

export const journeyCases = [
  C(
    'journey.build-and-reconcile',
    'T18',
    'read-only',
    'RP_STOCK.cs:4284 every figure is a signed MAIN_STOCK sum; every dimension reaches the same closing total',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        // Each step's "after" is the next step's "before": nothing moved between two saves.
        const ids = data.STEP_IDS.filter((id) => data.stepOf(id));
        for (let i = 1; i < ids.length; i += 1)
          assert.deepEqual(
            data.stepOf(ids[i]).before.net.totals,
            data.stepOf(ids[i - 1]).after.net.totals,
            `${ids[i - 1]} -> ${ids[i]}`,
          );
        await openScreen(page);
        await run(page, 'Item');
        assertFig(await cellsOf(gridRow(page, A.name)), WORKED.A, 'item A');
        assertFig(await cellsOf(gridRow(page, B.name)), WORKED.B, 'item B');
        assertFig(await cellsOf(gridRow(page, S.name)), WORKED.S, 'item S');
        for (const dim of [
          'Item',
          'Product',
          'Group',
          'Design',
          'Safe',
          'Counter',
          'Trading',
          'Size',
        ]) {
          await run(page, dim);
          assert.deepEqual(
            figs(await cellsOf(totalRow(page))).slice(0, 12),
            fig(WORKED.ALL),
            `Total row of ${dim}`,
          );
        }
        const [pcs, net, gross] = await signedSums(ctx, data.W1[1]);
        assert.deepEqual(
          [pcs, net, gross],
          [130, 1253, 1318.3],
          'independent signed MAIN_STOCK sums',
        );
        const api = await data.snapshot(page, { gross: true });
        assert.equal(r3(api.totals.clWt), 1318.3, 'gross total');
        return {
          observation:
            'A, B and S rows equal the worked table; all eight dimensions total closing 130 / 1253.000; signed sums 130 / 1253 / 1318.300',
          expected: { total: '130 / 1,253.000', gross: 1318.3 },
        };
      }),
  ),
];

// ---------------------------------------------------------------------------------------------------------------
// Edit, delete and the approval round trip. Edits and the delete case restore the data set.
// ---------------------------------------------------------------------------------------------------------------
const purchaseNo = () => vch('purchase').vchNo;

export const changeCases = [
  C(
    'edit.purchase-quantity',
    'T09',
    'mutation',
    'an edited purchase moves the Purchase and Closing columns of its item and nothing else',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const before = await rowFigures(page, A.code);
        const beforeGross = await rowFigures(page, A.code, { gross: true });
        const others = [await rowFigures(page, B.code), await rowFigures(page, S.code)];
        await flows.editPurchase(page, purchaseNo(), { pcs: '3', gross: '31.5', net: '30' });
        const net = await rowFigures(page, A.code);
        const gross = await rowFigures(page, A.code, { gross: true });
        try {
          assert.deepEqual([net.prPcs, net.prWt, net.clPcs, net.clWt], [4, 33, 13, 128]);
          assert.equal(gross.prWt, 34.65);
          assert.deepEqual(
            [await rowFigures(page, B.code), await rowFigures(page, S.code)],
            others,
          );
        } finally {
          await flows.editPurchase(page, purchaseNo(), { pcs: '4', gross: '42', net: '40' });
        }
        assert.deepEqual(await rowFigures(page, A.code), before, 'restored (net)');
        assert.deepEqual(
          await rowFigures(page, A.code, { gross: true }),
          beforeGross,
          'restored (gross)',
        );
        return {
          observation:
            'purchase 4 -> 3 pcs: A Purchase 4 / 33.000 (gross 34.650), Closing 13 / 128.000; B and S unchanged; restored',
          expected: { purchase: '4 / 33.000', closing: '13 / 128.000', grossPurchase: 34.65 },
        };
      }),
  ),
  C(
    'edit.voucher-date-moves-column',
    'T09',
    'mutation',
    'RP_STOCK.cs:4284 Opening = VCH_DATE < FROM: moving a purchase before FROM moves it from Purchase to Opening',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const before = await rowFigures(page, A.code);
        await flows.editPurchase(page, purchaseNo(), { date: data.D(8) });
        const moved8 = await rowFigures(page, A.code);
        try {
          assert.deepEqual(
            [moved8.prPcs, moved8.prWt, moved8.opPcs, moved8.opWt, moved8.clPcs, moved8.clWt],
            [1, 3, 17, 166, 14, 138],
          );
        } finally {
          await flows.editPurchase(page, purchaseNo(), { date: data.D(12) });
        }
        assert.deepEqual(await rowFigures(page, A.code), before, 'restored');
        return {
          observation:
            'purchase D12 -> D8: Purchase 1 / 3.000, Opening 17 / 166.000, Closing unchanged 14 / 138.000; restored',
          expected: { purchase: '1 / 3.000', opening: '17 / 166.000', closing: '14 / 138.000' },
        };
      }),
  ),
  C(
    'delete.sale-restores-stock',
    'T10',
    'mutation',
    'a deleted sale and its return leave no row in any column; the closing is unchanged because they cancelled',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const before = await rowFigures(page, A.code);
        const sale = vch('sale');
        const ret = vch('sales-return');
        await flows.deleteSalesReturn(page, ret.vchNo);
        await flows.deleteSale(page, sale.vchNo);
        const gone = await data.rows(
          ctx,
          `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "LC_CODE"='${data.LC}' AND "CO_BOOK" IN ('SL','SRT')`,
        );
        assert.equal(gone[0].n, 0, 'no sale or return stock row is left');
        const after = await rowFigures(page, A.code);
        assert.deepEqual(
          [
            after.slPcs,
            after.inPcs,
            after.inWt,
            after.outPcs,
            after.outWt,
            after.clPcs,
            after.clWt,
          ],
          [0, 1, 5, 5, 36, 14, 138],
        );
        await openScreen(page, { filters: { item: A.code } });
        await run(page);
        const cells = figs(await cellsOf(gridRow(page, A.name)));
        assert.deepEqual([cells[8], cells[9]], ['', ''], 'the Sale cells are blank');
        // Put the data set back: sell T1 again and take it back.
        const resold = await data.saveSale(page, {
          date: data.D(15),
          tag: data.TAG.T1,
          touch: '92',
        });
        await data.saveSalesReturn(page, { date: data.D(20), sale: resold });
        assert.deepEqual(await rowFigures(page, A.code), before, 'restored');
        return {
          observation:
            'after deleting M14 then M10: Sale blank, Inward 1 / 5.000, Outward 5 / 36.000, Closing 14 / 138.000; sale and return re-saved',
          expected: { inward: '1 / 5.000', outward: '5 / 36.000', closing: '14 / 138.000' },
        };
      }),
  ),
  C(
    'delete.tag-cancel-and-approval-return',
    'T10',
    'mutation',
    'APR RTN posts I + : an Approval Return of T3 puts it back in Inward and Closing; deleting it restores both',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const before = await rowFigures(page, A.code);
        const issue = vch('approval-issue');
        const back = await flows.saveApprovalReturn(page, {
          date: data.D(35),
          issueVch: issue.vchNo,
        });
        const during = await rowFigures(page, A.code);
        assert.deepEqual([during.inPcs, during.inWt, during.clPcs, during.clWt], [3, 25, 15, 146]);
        const m = await drillA(page, 'inward-pcs');
        const row = pick(m, (r) => r[M.tag] === data.TAG.T3);
        assert.equal(row[M.sign], '+');
        await flows.deleteApprovalReturn(page, back.vchNo);
        const after = await rowFigures(page, A.code);
        assert.deepEqual([after.inPcs, after.inWt, after.clPcs, after.clWt], [2, 17, 14, 138]);
        assert.deepEqual(after, before);
        return {
          observation:
            'return of T3 on D35: Inward 3 / 25.000, Closing 15 / 146.000, drill row Sign +; deleted: 2 / 17.000 and 14 / 138.000',
          expected: { with: '15 / 146.000', without: '14 / 138.000' },
        };
      }),
  ),
  C(
    'journey.approval-round-trip',
    'T18',
    'mutation',
    'issue T3 (D33), return it (D35), sell it (D36): the report follows each step',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        const d33 = await rowFigures(page, A.code, { to: data.D(33) });
        assert.deepEqual(
          [d33.outPcs, d33.outWt, d33.clPcs, d33.clWt],
          [5, 36, 14, 138],
          'window to D33',
        );
        const issue = vch('approval-issue');
        await flows.saveApprovalReturn(page, { date: data.D(35), issueVch: issue.vchNo });
        const returned = await rowFigures(page, A.code);
        assert.deepEqual(
          [returned.inPcs, returned.inWt, returned.clPcs, returned.clWt],
          [3, 25, 15, 146],
        );
        await data.saveSale(page, { date: data.D(36), tag: data.TAG.T3, touch: '92' });
        const sold = await rowFigures(page, A.code);
        assert.deepEqual(
          [
            sold.slPcs,
            sold.slWt,
            sold.inPcs,
            sold.inWt,
            sold.outPcs,
            sold.outWt,
            sold.clPcs,
            sold.clWt,
          ],
          [2, 20, 3, 25, 5, 36, 14, 138],
        );
        assert.deepEqual(
          await rowFigures(page, A.code, { to: data.D(33) }),
          d33,
          'the window to D33 is unchanged',
        );
        return {
          observation:
            'to D33 closing 14 / 138; after return 15 / 146; after sale Sale 2 / 20, Inward 3 / 25, Outward 5 / 36, Closing 14 / 138',
          expected: { sale: '2 / 20.000', closing: '14 / 138.000' },
        };
      }),
  ),
];

// ---------------------------------------------------------------------------------------------------------------
// Output: the Excel file and the large-result totals.
// ---------------------------------------------------------------------------------------------------------------
function zipEntries(buf) {
  let end = buf.length - 22;
  while (end >= 0 && buf.readUInt32LE(end) !== 0x06054b50) end -= 1;
  let p = buf.readUInt32LE(end + 16);
  const out = {};
  for (let i = 0; i < buf.readUInt16LE(end + 10); i += 1) {
    const nameLen = buf.readUInt16LE(p + 28);
    const at = buf.readUInt32LE(p + 42);
    const start = at + 30 + buf.readUInt16LE(at + 26) + buf.readUInt16LE(at + 28);
    const chunk = buf.subarray(start, start + buf.readUInt32LE(p + 20));
    const body = buf.readUInt16LE(p + 10) === 8 ? inflateRawSync(chunk) : chunk;
    out[buf.toString('utf8', p + 46, p + 46 + nameLen)] = body.toString('utf8');
    p += 46 + nameLen + buf.readUInt16LE(p + 30) + buf.readUInt16LE(p + 32);
  }
  return out;
}
const unxml = (s) =>
  s
    .replace(/&lt;/g, '<')
    .replace(/&gt;/g, '>')
    .replace(/&quot;/g, '"')
    .replace(/&apos;/g, "'")
    .replace(/&amp;/g, '&');
/** Rows of the first worksheet as arrays of { t: 'n' | 's', v } cells (blank cells are skipped). */
function xlsxRows(buf) {
  const files = zipEntries(buf);
  const shared = [...(files['xl/sharedStrings.xml'] ?? '').matchAll(/<si>([\s\S]*?)<\/si>/g)].map(
    (m) => unxml([...m[1].matchAll(/<t[^>]*>([\s\S]*?)<\/t>/g)].map((t) => t[1]).join('')),
  );
  const sheet =
    files['xl/worksheets/sheet1.xml'] ??
    Object.entries(files).find(([n]) => n.startsWith('xl/worksheets/'))?.[1] ??
    '';
  return [...sheet.matchAll(/<row[^>]*>([\s\S]*?)<\/row>/g)].map((row) =>
    [...row[1].matchAll(/<c ([^>]*?)(?:\/>|>([\s\S]*?)<\/c>)/g)]
      .map((c) => {
        const type = /t="(\w+)"/.exec(c[1])?.[1];
        const inner = c[2] ?? '';
        const v = /<v>([\s\S]*?)<\/v>/.exec(inner)?.[1];
        const inline = /<is>[\s\S]*?<t[^>]*>([\s\S]*?)<\/t>/.exec(inner)?.[1];
        if (type === 's') return { t: 's', v: shared[Number(v)] };
        if (type === 'inlineStr') return { t: 's', v: unxml(inline ?? '') };
        return v === undefined ? null : { t: 'n', v: Number(v) };
      })
      .filter(Boolean),
  );
}
const downloadOf = async (page, name) => {
  const [file] = await Promise.all([page.waitForEvent('download'), button(page, name).click()]);
  // saveAs works for a local and for a remote browser; path() does not (CI is local, the Docker run is remote).
  const dir = await mkdtemp(join(tmpdir(), 'stk-dl-'));
  try {
    const target = join(dir, 'download.bin');
    await file.saveAs(target);
    return await readFile(target);
  } finally {
    await rm(dir, { recursive: true, force: true });
  }
};

export const outputCases = [
  C(
    'output.excel-export',
    'T16',
    'output',
    'RP_STOCK.cs:3306 numeric cells are written as numbers rounded to three decimals; the Total row is written',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page);
        await run(page, 'Item');
        const heads = (await gridOf(page).locator('thead th').allInnerTexts()).map((t) => t.trim());
        const grid = [];
        for (const r of await gridOf(page).locator('tbody tr').all()) grid.push(await cellsOf(r));
        const rows = xlsxRows(await downloadOf(page, 'Excel'));
        assert.equal(
          rows.length,
          grid.length + 1,
          'header + the grid rows (the Total row included)',
        );
        const names = rows[0].map((c) => c.v);
        assert.deepEqual(
          [names[0], names[1], ...names.slice(3)],
          heads,
          'header row = the visible captions',
        );
        const a = rows.find((r) => r.some((c) => c.v === A.name));
        assert.ok(a, 'item A row');
        const nums = a.filter((c) => c.t === 'n').map((c) => c.v);
        assert.deepEqual(nums.slice(-2), [14, 138], 'closing is numeric 14 / 138');
        assert.ok(
          rows.at(-1).some((c) => c.v === 'Total :'),
          'the Total row is present',
        );
        assert.deepEqual(
          rows
            .at(-1)
            .filter((c) => c.t === 'n')
            .map((c) => c.v)
            .slice(-2),
          [130, 1253],
        );
        return {
          observation: `${rows.length} rows; header = captions; A closing numeric 14 / 138; Total row 130 / 1253`,
          expected: { total: '130 / 1253' },
          output: { rows: rows.length },
        };
      }),
  ),
  C(
    'drill.excel-uses-visible-grid',
    'T05',
    'output',
    'RP_STOCK.cs:3232-3340 with Back showing the Excel button writes the movement grid, Total row included',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        await openScreen(page, { filters: { item: A.code } });
        await run(page);
        const m = await drill(page, A.name, 'inward-pcs');
        const csv = (await downloadOf(page, 'Excel')).toString('utf8').replace(/^\uFEFF/, '');
        const lines = csv
          .split(/\r?\n/)
          .map((l, i) =>
            i === 0 ? l.split(',') : l.split('","').map((c) => c.replace(/^"|"$/g, '')),
          );
        assert.equal(lines[0][1], 'Vchtype', JSON.stringify(lines));
        assert.equal(
          lines.length,
          m.rows.length + 2,
          `header + rows + Total ${JSON.stringify(lines)}`,
        );
        const total = lines.at(-1);
        assert.deepEqual(total.slice(7, 11), m.total.slice(2, 6));
        assert.deepEqual(
          lines.slice(1, -1).map((l) => [l[3], l[5], l[9]]),
          m.rows.map((r) => [r[M.vch], r[M.tag], r[M.nwt]]),
        );
        assert.equal(
          await gridOf(page).count(),
          0,
          'the movement grid, not the summary, is on screen',
        );
        return {
          observation: `movement file: ${m.rows.length} rows + Total ${total.slice(7, 11)} equal the grid`,
          expected: { total: m.total.slice(2, 6) },
          output: csv,
        };
      }),
  ),
  C(
    'output.large-result-totals',
    'T16',
    'output',
    'RP_STOCK.cs:3837 the Total row sums the whole result, not a page; the export carries every row',
    async (ctx) =>
      onData(ctx, async () => {
        const { page } = await ctx.session();
        // 600 one-piece openings: Item Opening cannot take 600 rows by hand, so they are written as the screen writes
        // them (book 000, TR_TYPE P, dated the day before the year opens).
        const codes = Array.from({ length: 600 }, (_, i) => `ZX${String(i + 1).padStart(3, '0')}`);
        try {
          await data.exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE","SAFE_NAME","STK_DISPLAY","TRAD_TYPE")
             SELECT $1,'01',c,'ZR BULK '||c,'G','ZA','ZGA','MAIN','Y','Z1' FROM unnest($2::text[]) c`,
            codes,
          );
          await data.exec(
            ctx,
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","IT_CODE","TAG_NO",
               "TBL_CODE","TR_TYPE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","KR_FINE","DATA_TYPE")
             SELECT $1,'01','${data.LC}','${data.YEAR}','ZXB','ZXB01',(row_number() over ())::int,$3::date,'ITOBL',c,'N','001','P','+',1,1,1,0.916,0.916,'A'
               FROM unnest($2::text[]) c`,
            codes,
            data.D(-1),
          );
          await openScreen(page);
          await run(page, 'Item');
          const total = figs(await cellsOf(totalRow(page))).slice(0, 12);
          assert.deepEqual(
            [total[0], total[1]],
            ['718', '1,726.000'],
            'Opening covers the whole result',
          );
          assert.equal(await gridOf(page).locator('tbody tr[data-row]').count(), 603);
          const rows = xlsxRows(await downloadOf(page, 'Excel'));
          assert.equal(rows.length, 1 + 603 + 1, 'every row is exported');
          assert.deepEqual(
            rows
              .at(-1)
              .filter((c) => c.t === 'n')
              .map((c) => c.v)
              .slice(0, 2),
            [718, 1726],
          );
        } finally {
          await data.exec(
            ctx,
            `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='ZXB' AND "LC_CODE"='${data.LC}'`,
          );
          await data.exec(
            ctx,
            `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`,
            codes,
          );
        }
        return {
          observation: '603 item rows: Total Opening 718 / 1,726.000 on screen and in the file',
          expected: { opening: '718 / 1,726.000' },
          output: { rows: 603 },
        };
      }),
  ),
];

/**
 * Mutation cases carry database and downstream proof: the stored movement rows of the location (an independent signed
 * sum) and the report's own closing total, read after the case body, so both sides of the claim are on record.
 */
const withProof = (list) =>
  list.map((c) => {
    if (c.kind !== 'mutation') return c;
    const body = c.run;
    return {
      ...c,
      run: async (ctx) => {
        const result = await body(ctx);
        const [stored] = await data.rows(
          ctx,
          `SELECT count(*)::int rows,
                  sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_NWT" ELSE -"ITM_NWT" END)::float net
             FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "LC_CODE"='${data.LC}' AND "CO_YEAR"='${data.YEAR}'`,
        );
        const { page } = await ctx.session();
        const report = await data.snapshot(page);
        return {
          ...result,
          database: {
            ...(result.database ?? {}),
            mainStock: { rows: stored.rows, signedNet: r3(stored.net) },
          },
          downstream: {
            ...(result.downstream ?? {}),
            reportClosingNet: r3(report.totals.clWt),
            reportClosingPcs: report.totals.clPcs,
          },
        };
      },
    };
  });

export const moreCases = withProof([
  ...createCases,
  ...configCases,
  ...entryCases,
  ...keyboardCases,
  ...journeyCases,
  ...outputCases,
  ...inOutCases,
  ...printCases,
  ...zoomCases,
  ...changeCases,
]);
// FIELD, button, movementsOf are re-exported for the feature cases that follow.
export { FIELD, button, movementsOf };
