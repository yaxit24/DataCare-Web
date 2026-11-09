#!/usr/bin/env node
// Generates vectors.json for the sales-line desktop oracle (WP-40/WP-41 family 1, LITE-MASTER-PLAN.md §6 O2).
//
// Every input is SYNTHETIC: no value here comes from a desktop customer database.
//
// A vector is one fresh sale-grid row: the cells the operator types, the company settings CommPassTotal reads, and
// the current column (`col`, the cell the operator just left). Shadow columns (66-71, 76, 77, 82-85, 102, 105, 107)
// start blank, as on a new row, so every derived cell is computed on the first pass. `col` is 22 (the rate cell)
// unless a vector says otherwise, because the 13/23/24/25/35/36 columns have their own reverse-calculation branches.
//
// Grid columns (TR_SALE.cs:12100-12175, the reopen bindings):
//   11 ITM_PCS  12 ITM_GWT  13 ITM_OTH_WT  14 ITM_NWT  15 ITM_GHT_PRC  17 ITM_GHT_WT  18 ITM_TOUCH
//   19 ITM_WEST_PRC  20 ITM_FINE  21 RtWith  22 ITM_RATE  23 ITM_AMT  24 LBR_PRC  25 LBR_TYPE  26 LBR_RATE
//   27 LBR_AMT  29 OTH_AMT  30 ITM_MRP  31 disc %  32 disc amt  33 net labour  35 TOT_AMT  36 TAX_PRC
//   37 NET_AMT  58 RATE_TYPE
//
// Run:  node web/scripts/desktop-oracle/sales-line/gen-vectors.mjs   (rewrites vectors.json next to this file)
import { writeFileSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));

/** Weights to 3 dp and money to 2 dp, as the grid cells hold them. */
const w = (x) => x.toFixed(3);
const m = (x) => x.toFixed(2);

const vectors = [];
const ids = new Set();

/**
 * @param {string} id
 * @param {Record<string, string|number>} cells  grid column -> text
 * @param {{settings?: Record<string, string|number>, col?: number, colWidths?: Record<string, number>,
 *          checks?: string[], passes?: number, textEntry?: string}} [opts]
 */
function add(id, cells, opts = {}) {
  if (ids.has(id)) throw new Error(`duplicate vector id ${id}`);
  ids.add(id);
  const text = {};
  for (const [k, v] of Object.entries(cells)) text[k] = String(v);
  vectors.push({
    id,
    col: opts.col ?? 22,
    ...(opts.settings ? { settings: opts.settings } : {}),
    ...(opts.colWidths ? { colWidths: opts.colWidths } : {}),
    ...(opts.passes ? { passes: opts.passes } : {}),
    ...(opts.textEntry != null ? { textEntry: opts.textEntry } : {}),
    // Which web stages the Node test compares on this vector.
    checks: opts.checks ?? [],
    cells: text,
  });
}

// ---- 1. Net weight and fine: every purity, with and without wastage and ghat ------------------------------------
// Gold purities 24K..9K and the silver touches in common use.
const purities = [100, 99.99, 99.9, 99.5, 91.6, 91.7, 84, 75, 58.5, 41.7, 37.5, 92.5, 80, 70, 60];
const fineWeights = [
  { gross: 10, less: 0, ghat: 0 },
  { gross: 7.777, less: 0.25, ghat: 0.333 },
  { gross: 0.005, less: 0, ghat: 0 },
  { gross: 12345.678, less: 1.111, ghat: 2.5 },
];
for (const touch of purities) {
  for (const west of [0, 1.5]) {
    fineWeights.forEach((fw, i) => {
      add(
        `fine.t${touch}.w${west}.g${i}`,
        {
          11: 1,
          12: w(fw.gross),
          13: w(fw.less),
          17: w(fw.ghat),
          18: m(touch),
          19: m(west),
          21: 'N',
        },
        { checks: ['net', 'fine'] },
      );
    });
  }
}
// No touch and no wastage: fine falls back to net + ghat (TR_SALE.cs:10753-10760).
add('fine.zero-touch', { 11: 1, 12: w(5.5), 17: w(0.25), 21: 'N' }, { checks: ['net', 'fine'] });
add(
  'fine.zero-touch.west-only',
  { 11: 1, 12: w(5.5), 17: w(0.25), 19: m(2), 21: 'N' },
  { checks: ['net', 'fine'] },
);
// Third-decimal half cases: (net + ghat) x pct / 100 lands on x.xxx5.
add('fine.half.1', { 11: 1, 12: w(1.001), 18: m(50), 21: 'N' }, { checks: ['net', 'fine'] });
add('fine.half.2', { 11: 1, 12: w(0.003), 18: m(50), 21: 'N' }, { checks: ['net', 'fine'] });
add('fine.half.3', { 11: 1, 12: w(2.345), 18: m(50), 21: 'N' }, { checks: ['net', 'fine'] });
add('fine.half.4', { 11: 1, 12: w(1.235), 18: m(10), 21: 'N' }, { checks: ['net', 'fine'] });
// Ghat from its percentage (column 15) instead of a typed weight.
for (const pct of [1, 2.5, 3.33]) {
  add(
    `ghat.pct${pct}`,
    { 11: 1, 12: w(10.555), 13: w(0.5), 15: m(pct), 18: m(91.6), 21: 'N' },
    { checks: ['net', 'ghat', 'fine'] },
  );
}

// ---- 2. Item amount: RtWith x RATE_TYPE, midpoints, large weights ------------------------------------------------
const base = { 11: 2, 12: w(10.555), 13: w(0.5), 17: w(0.12), 18: m(91.6) };
for (const rtWith of ['N', 'G', 'F', 'P']) {
  for (const rateType of ['', 'G', '1', 'K', 'P']) {
    add(
      `amount.rt${rtWith}.type${rateType || 'blank'}`,
      { ...base, 21: rtWith, 22: m(5432.1), 58: rateType },
      { checks: ['net', 'fine', 'amount'] },
    );
  }
}
// Whole-rupee midpoints: Math.Round(x, 0) is half-to-even on the desktop.
const mid = [
  ['n1.5xr5', 1.5, 5], // 7.5 -> 8
  ['n2.5xr1', 2.5, 1], // 2.5 -> 2
  ['n0.5xr1', 0.5, 1], // 0.5 -> 0
  ['n3.5xr1', 3.5, 1], // 3.5 -> 4
  ['n0.125xr4', 0.125, 4], // 0.5 -> 0
  ['n1.005xr100', 1.005, 100], // 100.5 in decimal; the double product decides
  ['n2.675xr2', 2.675, 2], // 5.35
  ['n0.001xr500', 0.001, 500], // 0.5
  ['n3.495xr1', 3.495, 1], // 3.495: one rounding gives 3, a 2 dp stage first gives 3.50 and then 4
  ['n2.495xr1', 2.495, 1], // 2.495
];
for (const [name, net, rate] of mid) {
  add(
    `amount.mid.${name}`,
    { 11: 1, 12: w(net), 21: 'N', 22: m(rate) },
    { checks: ['net', 'fine', 'amount'] },
  );
}
// Fine-wise midpoint: fine 2.500 x 1 = 2.5 -> 2.
add(
  'amount.mid.fine',
  { 11: 1, 12: w(5), 18: m(50), 21: 'F', 22: m(1) },
  { checks: ['net', 'fine', 'amount'] },
);
// Per-10g and per-kg midpoints.
add(
  'amount.mid.per10g',
  { 11: 1, 12: w(0.5), 21: 'N', 22: m(50), 58: '1' },
  { checks: ['net', 'fine', 'amount'] },
);
add(
  'amount.mid.perkg',
  { 11: 1, 12: w(2.5), 21: 'N', 22: m(1000), 58: 'K' },
  { checks: ['net', 'fine', 'amount'] },
);
// Large weights.
add(
  'amount.large.gold',
  { 11: 1, 12: w(99999.999), 18: m(91.6), 21: 'N', 22: m(7999.99) },
  { checks: ['net', 'fine', 'amount'] },
);
add(
  'amount.large.silver-kg',
  { 11: 1, 12: w(54321.987), 18: m(92.5), 21: 'F', 22: m(95000), 58: 'K' },
  { checks: ['net', 'fine', 'amount'] },
);
// ALL_ROF_REMOVE = Y rounds the item amount to 2 dp instead of 0 (TR_SALE.cs:10351-10362).
for (const [name, net, rate] of [
  ['1.005x1', 1.005, 1],
  ['2.675x1', 2.675, 1],
  ['1.2345x10', 1.2345, 10],
  ['10.555x5432.1', 10.555, 5432.1],
]) {
  add(
    `amount.allrof.${name}`,
    { 11: 1, 12: w(net), 21: 'N', 22: m(rate) },
    { settings: { MsAllRofRemove: 'Y' }, checks: ['net', 'fine', 'amount'] },
  );
}

// ---- 3. Labour: by gram (N/G), per kg, per piece, by percent ----------------------------------------------------
const lb = { 11: 3, 12: w(10.555), 13: w(0.5), 17: w(0.12), 18: m(91.6), 21: 'N', 22: m(6200) };
for (const type of ['N', 'G', 'K', 'P', '']) {
  for (const ght of ['Y', 'N']) {
    add(
      `labour.rate.${type || 'blank'}.ght${ght}`,
      { ...lb, 25: type, 26: m(type === 'K' ? 12500 : 12.5) },
      {
        settings: { MsLbrWithGht: ght },
        checks: ['net', 'fine', 'amount', 'labour'],
      },
    );
  }
}
// Labour by percent of the item rate: the rate is derived (TR_SALE.cs:11021), then the basis rule applies.
for (const type of ['N', 'G', 'K', 'P']) {
  for (const rtWith of ['N', 'F']) {
    add(
      `labour.pct.${type}.rt${rtWith}`,
      { ...lb, 21: rtWith, 24: m(12), 25: type },
      { checks: ['net', 'fine', 'amount', 'labourRate', 'labour'] },
    );
  }
}
for (const lbrRof of [0, 2]) {
  add(
    `labour.pct.rof${lbrRof}`,
    { ...lb, 22: m(5432.1), 24: m(2.5), 25: 'N' },
    {
      settings: { MsLbrRof: lbrRof },
      checks: ['net', 'fine', 'amount', 'labourRate', 'labour'],
    },
  );
}
// Labour midpoints at the whole rupee, and an amount the web would keep at 2 dp.
const lmid = [
  ['n0.299xr5', 0.299, 5], // 1.495 -> 1
  ['n0.5xr5', 0.5, 5], // 2.5 -> 2
  ['n1.5xr1', 1.5, 1], // 1.5 -> 2
  ['n1.234xr10', 1.234, 10], // 12.34 -> 12
  ['n0.105xr10', 0.105, 10], // 1.05
  ['n3.495xr1', 3.495, 1], // 3.495: one rounding gives 3, LBR_ROF 2 first gives 3.50 and then 4
];
for (const [name, net, rate] of lmid) {
  for (const lbrRof of [0, 2]) {
    add(
      `labour.mid.${name}.rof${lbrRof}`,
      { 11: 1, 12: w(net), 21: 'N', 25: 'N', 26: m(rate) },
      {
        settings: { MsLbrRof: lbrRof },
        checks: ['net', 'fine', 'labour'],
      },
    );
  }
}
add(
  'labour.allrof',
  { 11: 1, 12: w(1.234), 21: 'N', 25: 'N', 26: m(10) },
  { settings: { MsAllRofRemove: 'Y' }, checks: ['net', 'fine', 'labour'] },
);
// Labour discount (columns 31/32/33).
add(
  'labour.discount.10pct',
  { ...lb, 25: 'N', 26: m(125), 31: m(10) },
  { checks: ['net', 'fine', 'amount', 'labour', 'discount'] },
);
add(
  'labour.discount.half',
  { 11: 1, 12: w(1), 21: 'N', 22: m(1000), 25: 'N', 26: m(105), 31: m(5) },
  { checks: ['net', 'fine', 'amount', 'labour', 'discount'] },
);

// ---- 4. Other (stone) amount and the line total -----------------------------------------------------------------
add(
  'total.stone',
  { ...lb, 25: 'N', 26: m(250), 29: m(1234.5) },
  { checks: ['net', 'fine', 'amount', 'labour', 'total'] },
);
// The labour discount (column 32) comes off the line total (TR_SALE.cs:11548); the web line total has no discount.
add(
  'total.stone.discount',
  { ...lb, 25: 'N', 26: m(250), 29: m(999), 31: m(7.5) },
  { checks: ['net', 'fine', 'amount', 'labour', 'discount'] },
);
add(
  'total.plain',
  { ...lb, 25: 'N', 26: m(250) },
  { checks: ['net', 'fine', 'amount', 'labour', 'total'] },
);
// A line TAX_PRC (column 36) makes CommPassTotal treat the line total as tax-inclusive: NET_AMT is backed out of it
// and the labour absorbs the difference (TR_SALE.cs:11596-11688). The web keeps tax at bill level only.
for (const tax of [0.25, 3, 5]) {
  add(
    `total.tax${tax}`,
    { ...lb, 25: 'N', 26: m(250), 29: m(100), 36: m(tax) },
    { checks: ['net', 'fine', 'amount', 'taxInclusive'] },
  );
}

// ---- 5. MRP lines (column 30) -----------------------------------------------------------------------------------
add('mrp.plain', { 11: 1, 12: w(2.5), 21: 'N', 30: m(1500) }, { checks: ['net', 'mrp'] });
for (const tax of [0.25, 3, 5]) {
  add(
    `mrp.tax${tax}`,
    { 11: 1, 12: w(2.5), 21: 'N', 30: m(1500), 36: m(tax) },
    { checks: ['net', 'mrp'] },
  );
}
add(
  'mrp.discount',
  { 11: 1, 12: w(2.5), 21: 'N', 30: m(1500), 31: m(10), 36: m(3) },
  { checks: ['net', 'mrp'] },
);
add(
  'mrp.with-rate',
  { 11: 1, 12: w(2.5), 21: 'N', 22: m(500), 30: m(1999), 36: m(3) },
  { checks: ['net', 'mrp'] },
);

// ---- 6. Path dependence (documentation only, not compared): a second pass over an unchanged G row ---------------
add('path.second-pass.G', { ...base, 21: 'G', 22: m(5432.1) }, { passes: 2 });

const doc = {
  family: 'sales-line',
  generator: 'web/scripts/desktop-oracle/sales-line/gen-vectors.mjs',
  method: 'TR_SALE.cs:9524-11891 CommPassTotal',
  vectors,
};
writeFileSync(join(here, 'vectors.json'), `${JSON.stringify(doc, null, 1)}\n`);
console.log(`vectors=${vectors.length}`);
