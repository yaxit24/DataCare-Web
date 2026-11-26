import assert from 'node:assert/strict';
import { W1 } from './stockReportData.mjs';

/** Browser helpers for Report -> Stock Report (/reports/stock-report), shared by the stock-report case files. */

export const ROUTE = '/reports/stock-report';
/** The screen shows dates as dd/mm/yyyy in a desktop masked box (DesktopDateInput, DC_Main.SetDate). */
export const dmy = (iso) => iso.split('-').reverse().join('/');
export const setDate = (page, selector, iso) => page.locator(selector).fill(dmy(iso));
/** The form is ready when its defaults have landed: the dimension buttons are enabled and the dates are real dates. */
export const ready = (page) =>
  page.waitForFunction(
    () =>
      [...document.querySelectorAll('main button')].find((b) => b.textContent?.trim() === 'Item')
        ?.disabled === false &&
      /^\d{2}\/\d{2}\/\d{4}$/.test(document.querySelector('#sr-to')?.value ?? ''),
  );
export const button = (page, name) => page.getByRole('button', { name, exact: true });
export const gridOf = (page) => page.locator('[data-testid="stock-grid"]');
export const movementsOf = (page) => page.locator('[data-testid="stock-movements"]');

/** Input ids of the filter boxes (page.tsx). */
export const FIELD = {
  from: '#sr-from',
  to: '#sr-to',
  type: '#sr-ittype',
  stock: '#sr-stype',
  search: '#sr-search',
  group: '#sr-gr',
  product: '#sr-pr',
  item: '#sr-it',
  design: '#sr-design',
  safe: '#sr-safe',
  counter: '#sr-counter',
  tag: '#sr-tag',
  account: '#sr-ac',
};

/**
 * Open the screen and set the window and filters. `from`/`to` default to W1 (D10..D40), the Item Type to blank
 * (every metal) so the worked totals of cases.md hold; `filters` maps a FIELD key to a value.
 */
export async function openScreen(
  page,
  { from = W1[0], to = W1[1], itemType = '', stockType, filters = {} } = {},
) {
  await page.goto(ROUTE);
  await page.getByRole('heading', { name: 'Stock Report', exact: true }).waitFor();
  await button(page, 'Item').waitFor();
  await ready(page);
  await setDate(page, FIELD.from, from);
  await setDate(page, FIELD.to, to);
  if (itemType !== undefined) await page.locator(FIELD.type).selectOption(itemType);
  if (stockType !== undefined) await page.locator(FIELD.stock).selectOption(stockType);
  for (const [key, value] of Object.entries(filters)) await page.locator(FIELD[key]).fill(value);
}

/** Press a dimension button and wait until the run's answer is on screen (a grid from an earlier run does not count). */
export async function run(page, dimension = 'Item') {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        new URL(r.url()).pathname === '/api/reports/stock-report' && r.request().method() === 'GET',
    ),
    button(page, dimension).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await gridOf(page).waitFor();
  // The dimension buttons are disabled while a run is in flight; enabled again means the grid is the new answer.
  await page.waitForFunction(() => document.querySelector('main button.ghost')?.disabled === false);
}

export const gridRow = (page, name) =>
  gridOf(page).locator('tbody tr[data-row]', { hasText: name }).first();
export const totalRow = (page) => gridOf(page).locator('tbody tr[data-total]');
export const cellsOf = async (row) =>
  (await row.locator('td').allInnerTexts()).map((t) => t.trim());
/** SrNo and Name are the first two cells, then Op, Pr, In, Ou, Sl, Cl as (pcs, weight) pairs. */
export const figs = (cells) => cells.slice(2);

/** Names of the data rows currently in the summary grid, in order. */
export const rowNames = async (page) =>
  (await gridOf(page).locator('tbody tr[data-row] td:nth-child(2)').allInnerTexts()).map((t) =>
    t.trim(),
  );

const wtText = (n) =>
  Number(n).toLocaleString('en-IN', { minimumFractionDigits: 3, maximumFractionDigits: 3 });
const pcsText = (n) => Number(n).toLocaleString('en-IN', { maximumFractionDigits: 3 });
/** The twelve visible figure cells for numbers [opP, opW, prP, prW, inP, inW, ouP, ouW, slP, slW, clP, clW]; zero is blank. */
export const fig = (numbers) =>
  numbers.map((n, i) => (Number(n) === 0 ? '' : i % 2 === 0 ? pcsText(n) : wtText(n)));
/** The same for a signed figure, which the grid shows with its sign (a negative closing). */
export const text3 = wtText;
export const textPcs = pcsText;

// Worked figures of cases.md section 1 (W1 = D10..D40, net basis). Items: A ring, B chain, S silver bowl.
export const WORKED = {
  A: [13, 126, 5, 43, 2, 17, 5, 36, 1, 12, 14, 138],
  B: [5, 50, 1, 20, 0, 0, 0, 0, 0, 0, 6, 70],
  S: [100, 950, 10, 95, 0, 0, 0, 0, 0, 0, 110, 1045],
  /** Gold only (A + B). */
  GOLD: [18, 176, 6, 63, 2, 17, 5, 36, 1, 12, 20, 208],
  /** Every item (A + B + S): the visible columns; the hidden transfer pair is 1 / 10 in and out. */
  ALL: [118, 1126, 16, 158, 2, 17, 5, 36, 1, 12, 130, 1253],
};

/** Rows of the movement grid (drill-down) as text cells, and its Total row. */
export async function movements(page) {
  const table = movementsOf(page);
  await table.waitFor();
  const rows = [];
  for (const row of await table.locator('tbody tr:not([data-total])').all())
    rows.push(await cellsOf(row));
  const total = table.locator('tbody tr[data-total]');
  return { rows, total: (await total.count()) ? await cellsOf(total) : null };
}
/** Movement cell indexes: SrNo, Vchtype, Party, VchNo, VchDate, TagNo, ItName, Pcs, GrWt, NetWt, Fine, Sign. */
export const M = {
  sr: 0,
  type: 1,
  party: 2,
  vch: 3,
  date: 4,
  tag: 5,
  item: 6,
  pcs: 7,
  gwt: 8,
  nwt: 9,
  fine: 10,
  sign: 11,
};

/** Double-click a figure cell ("opening-pcs", "sale-wt" ...) of a summary row and wait for the movement grid. */
export async function drill(page, rowName, column) {
  await gridRow(page, rowName).locator(`td[data-col="${column}"]`).dblclick();
  await button(page, 'Back').waitFor();
  return movements(page);
}

/** The Total row of a movement grid is its last row: pcs, gross, net, fine. */
export const totals4 = (m) => m.total.slice(2 + 5, 2 + 5 + 4).map((t) => t);

/** Compare a grid row's figure cells with numeric expectations; the message carries both sides. */
export function assertFig(actual, expected, what) {
  eq(figs(actual), fig(expected), what);
}
export function eq(actual, expected, what) {
  assert.deepEqual(
    actual,
    expected,
    `${what}: got ${JSON.stringify(actual)}, want ${JSON.stringify(expected)}`,
  );
}
