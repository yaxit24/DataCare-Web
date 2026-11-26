import assert from 'node:assert/strict';
import { USERS } from '../fixtures/catalogue.mjs';
import { TENANT } from '../harness.mjs';

/**
 * Stock Report feature data: the movement table of orchestration/work/WP-16/cases.md section 1, created through the
 * real Item Opening, Tag Opening, Purchase, Sales, Sales Return, Purchase Return, Stock Adjust, Tag Cancel and
 * Approval Issue screens (the counter transfer M12/M13 has no Lite screen and is the one fixture insert).
 *
 * Isolation. The browser runner shares one database across every module, and every other module writes company 01,
 * location 01. The report is scoped to the session's location, so this data lives in a location of its own (LC):
 * the worked figures of cases.md hold exactly, with no group filter and no foreign item in a total. The location is
 * provisioned by the same `seedCompany` routine a new company gets (its books, slots and counters), and `teardown`
 * removes every row it wrote.
 */

export const LC = '07';
const LC_NAME = 'E2E STOCK REPORT LOCATION';

const now = new Date();
export const START_YEAR = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
export const YEAR = `${START_YEAR}-${START_YEAR + 1}`;
const Y0 = Date.UTC(START_YEAR, 3, 1);
/** Dn = the first day of the fiscal year plus n days (cases.md section 0). */
export const D = (n) => new Date(Y0 + n * 86_400_000).toISOString().slice(0, 10);
/** Windows of cases.md: W1 = D10..D40, W2 = D10..D24, W3 = D10..D14. */
export const W1 = [D(10), D(40)];
export const W2 = [D(10), D(24)];
export const W3 = [D(10), D(14)];

/** Credentials of a session at the stock-report location (the real Open Company selector picks it). */
export const at = (user = USERS.admin.user, slot) => ({
  user,
  slot: slot ?? `${user}@${LC}`,
  location: LC,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

/** Masters (cases.md section 1). Codes carry a Z so the shared company's other masters are never touched. */
export const ITEMS = {
  A: {
    code: 'ZRNG',
    name: 'ZR GOLD RING 22K',
    type: 'G',
    gr: 'ZGA',
    pr: 'ZA',
    safe: 'MAIN',
    trad: 'Z1',
  },
  B: {
    code: 'ZCHN',
    name: 'ZR GOLD CHAIN 22K',
    type: 'G',
    gr: 'ZGA',
    pr: 'ZB',
    safe: 'VAULT',
    trad: '',
  },
  S: {
    code: 'ZBWL',
    name: 'ZR SILVER BOWL',
    type: 'S',
    gr: 'ZGS',
    pr: 'ZS',
    safe: 'MAIN',
    trad: 'Z2',
  },
};
export const GROUPS = [
  ['ZGA', 'ZR GOLD ORNAMENTS', 'SALES', 'PURCHASE', 'Z1'],
  ['ZGS', 'ZR SILVER ARTICLES', 'SLVSALE', 'SLVPURC', 'Z2'],
];
export const PRODUCTS = [
  ['ZA', 'ZR RING'],
  ['ZB', 'ZR CHAIN'],
  ['ZS', 'ZR BOWL'],
];
export const COUNTERS = [
  ['001', 'CNT-ONE'],
  ['002', 'CNT-TWO'],
];
export const TRADING = [
  ['Z1', 'ZR GOLD TRADE'],
  ['Z2', 'ZR SILVER TRADE'],
];
export const SUP = { code: 'ZSUP1', name: 'ZR SUPPLIER' };
export const CUS = { code: 'ZCUS1', name: 'ZR CUSTOMER' };
export const EMPLOYEE = 'E01';
/** Tag numbers of cases.md T1 .. T5 (prefixed so no other module's tag can collide). */
export const TAG = { T1: 'ZT1', T2: 'ZT2', T3: 'ZT3', T4: 'ZT4', T5: 'ZT5' };

export const exec = (ctx, sql, ...params) =>
  ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);
export const rows = (ctx, sql, ...params) =>
  ctx.owner.$queryRawUnsafe(sql, ctx.tenantId, ...params);

/** The location, its books, the masters and the two parties. */
export async function provision(ctx) {
  const seeded = await ctx.stack.seedCompany(ctx.stack.runtime, TENANT, '01', { lcCode: LC });
  assert(
    seeded.created.books > 0,
    'seedCompany must provision the books of the stock-report location',
  );
  await exec(
    ctx,
    `UPDATE "LOCT_MAST" SET "LC_NAME"=$3 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$2`,
    LC,
    LC_NAME,
  );
  for (const [code, name, sale, purc, trad] of GROUPS)
    await exec(
      ctx,
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC","TRAD_TYPE") VALUES($1,'01',$2,$3,$4,$5,$6)`,
      code,
      name,
      sale,
      purc,
      trad,
    );
  for (const [code, name] of PRODUCTS)
    await exec(
      ctx,
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES($1,'01',$2,$3)`,
      code,
      name,
    );
  for (const it of Object.values(ITEMS))
    await exec(
      ctx,
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE","SAFE_NAME","STK_DISPLAY","TRAD_TYPE")
       VALUES($1,'01',$2,$3,$4,$5,$6,$7,'Y',$8)`,
      it.code,
      it.name,
      it.type,
      it.pr,
      it.gr,
      it.safe,
      it.trad,
    );
  for (const [code, name] of COUNTERS)
    await exec(
      ctx,
      `INSERT INTO "TABLE_MAST"(tenant_id,"CO_CODE","LC_CODE","TABLE_CODE","TABLE_NAME") VALUES($1,'01',$2,$3,$4)`,
      LC,
      code,
      name,
    );
  for (const [code, name] of TRADING)
    await exec(
      ctx,
      `INSERT INTO "BAL_GR"(tenant_id,"CO_CODE","TRAD_TYPE","TRAD_NAME") VALUES($1,'01',$2,$3)`,
      code,
      name,
    );
  for (const d of ['D1', 'D2'])
    await exec(
      ctx,
      `INSERT INTO "DESIGN_MAST"(tenant_id,"CO_CODE","DESIGN_NO") VALUES($1,'01',$2)`,
      d,
    );
  for (const p of [SUP, CUS])
    await exec(
      ctx,
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE") VALUES($1,'01',$2,$3,$4,'10','L')`,
      LC,
      p.code,
      p.name,
    );
  // The approval screens need an employee; the other approval modules add the same row when it is absent.
  dataSet.employeeAdded =
    (await exec(
      ctx,
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME")
       SELECT $1::text,'01',$2::text,'APPROVAL EMPLOYEE'
        WHERE NOT EXISTS (SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "EMP_CODE"=$2::text)`,
      EMPLOYEE,
    )) > 0;
}

// ---------------------------------------------------------------------------------------------------------------
// The report, read through the real API with the browser session (for step deltas; the cases read the grid).
// ---------------------------------------------------------------------------------------------------------------

/** One Item-dimension run of the report at the session's location, keyed by item code. */
export async function snapshot(page, { from = W1[0], to = W1[1], gross = false, extra = {} } = {}) {
  const q = new URLSearchParams({
    dimension: 'item',
    fromDate: from,
    toDate: to,
    weight: gross ? 'gross' : 'net',
    ...extra,
  });
  const response = await page.request.get(`/api/reports/stock-report?${q}`);
  assert.equal(response.status(), 200, await response.text());
  const body = await response.json();
  const byItem = {};
  for (const r of body.rows) byItem[r.code] = r;
  return { byItem, totals: body.totals, rows: body.rows };
}

// ---------------------------------------------------------------------------------------------------------------
// Screen drivers.
// ---------------------------------------------------------------------------------------------------------------

export const isApi = (response, method, path) =>
  response.request().method() === method && new URL(response.url()).pathname === `/api${path}`;

/** Wait for a lookup list to show `text`, then press Enter on the input. */
export async function pickFromList(input, text) {
  await input.locator('xpath=..').getByText(text, { exact: false }).first().waitFor();
  await input.press('Enter');
}

// --- Item Opening (TR_ITM_OPBL) -----------------------------------------------------------------------------------
const NAMES = { G: 'Gold', S: 'Silver' };
const ioCell = (page, header, row) => page.getByLabel(`${header} row ${row}`, { exact: true });

/** Open Item Opening, list the items of a metal type, type the rows of `byCode` and save ("Data Are Saved."). */
export async function saveItemOpening(page, type, byCode) {
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', '/stock/item-opening/rights')),
    page.goto('/txn/item-opening'),
  ]);
  await page.getByRole('heading', { name: 'Item Opening', exact: true }).waitFor();
  const typeBox = page.getByLabel('Item Type', { exact: true });
  await typeBox.selectOption(type);
  const [loaded] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `/stock/item-opening/type/${type}`)),
    typeBox.press('Enter'),
  ]);
  assert.equal(loaded.status(), 200, await loaded.text());
  await page.getByTestId('item-opening-loaded').filter({ hasText: NAMES[type] }).waitFor();
  const wanted = new Map(Object.entries(byCode));
  // The grid lists every item of the metal type of the company: find this module's rows by their code.
  for (let row = 1; wanted.size && (await ioCell(page, 'ItCode', row).count()); row += 1) {
    const code = await ioCell(page, 'ItCode', row).inputValue();
    const values = wanted.get(code);
    if (!values) continue;
    wanted.delete(code);
    for (const [header, value] of Object.entries(values)) {
      await ioCell(page, header, row).fill(value);
      await ioCell(page, header, row).press('Enter');
    }
  }
  assert.equal(wanted.size, 0, `Item Opening grid did not list ${[...wanted.keys()].join(', ')}`);
  const [saved] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'PUT', `/stock/item-opening/type/${type}`)),
    page.getByRole('button', { name: 'Save', exact: true }).click(),
  ]);
  assert.equal(saved.status(), 200, await saved.text());
  await page.getByText('Data Are Saved.', { exact: true }).waitFor();
}

/** Delete a metal type's opening through the screen; harmless when it has none. */
export async function deleteItemOpening(page, type) {
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', '/stock/item-opening/rights')),
    page.goto('/txn/item-opening'),
  ]);
  await page.getByRole('heading', { name: 'Item Opening', exact: true }).waitFor();
  const typeBox = page.getByLabel('Item Type', { exact: true });
  await typeBox.selectOption(type);
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `/stock/item-opening/type/${type}`)),
    typeBox.press('Enter'),
  ]);
  await page.getByTestId('item-opening-loaded').filter({ hasText: NAMES[type] }).waitFor();
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'DELETE', `/stock/item-opening/type/${type}`)),
    page.getByRole('button', { name: 'Delete', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
}

// --- Tag Opening (TR_TAG_OPBL) ------------------------------------------------------------------------------------
const toCell = (page, field, row) =>
  page.getByLabel(`Tag opening ${field} row ${row}`, { exact: true });

/**
 * One Tag Opening voucher (book TOP) with the given tags on `date`. Each tag: { tag, item, counter, design, size,
 * pcs, gross, net, touch, krTouch }. The karigar block takes KrOthWt = gross - net so the karigar net weight equals
 * the tag's net weight; its fine is net x KrTouch / 100 (TR_TAG_OPBL.cs:6679-6826).
 */
export async function saveTagOpening(page, date, tags) {
  await page.goto('/txn/tag-opening');
  await page.getByRole('heading', { name: /^Tag Opening Balance/ }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 60 && (await book.inputValue()) !== 'TOP'; i += 1)
    await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), 'TOP', 'the provisioned TOP book is selected');
  await page.getByLabel('Date', { exact: true }).fill(date);
  for (const [i, t] of tags.entries()) {
    const row = i + 1;
    if (row > 1) {
      await page.getByRole('button', { name: '+ Add tag', exact: true }).click();
      await page.getByLabel(`Tag no row ${row}`, { exact: true }).waitFor();
    }
    await page.getByLabel(`Tag no row ${row}`, { exact: true }).fill(t.tag);
    const item = page.getByLabel(`Item code row ${row}`, { exact: true });
    await item.fill(t.item);
    await pickFromList(item, t.item);
    const fields = {
      tblCode: t.counter,
      designNo: t.design,
      itmSize: t.size,
      pcs: t.pcs ?? '1',
      grossWt: t.gross,
      netWt: t.net,
      touch: t.touch ?? '91.6',
    };
    for (const [field, value] of Object.entries(fields))
      if (value !== undefined) await toCell(page, field, row).fill(value);
    await page.getByText(`Tag row ${row} desktop fields`, { exact: true }).click();
    const other = (Number(t.gross) - Number(t.net)).toFixed(3);
    await page.getByLabel(`KrOthWt row ${row}`, { exact: true }).fill(other);
    await page.getByLabel(`KrTouch row ${row}`, { exact: true }).fill(t.krTouch ?? '90');
    // Leaving the cell runs CommPassTotal, which fills KrNwt and KrFine.
    await page.getByLabel(`KrTouch row ${row}`, { exact: true }).press('Tab');
  }
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        ['POST', 'PUT'].includes(r.request().method()) &&
        /\/api\/stock\/tag-opening(\/|$)/.test(new URL(r.url()).pathname),
    ),
    page.getByRole('button', { name: /^(Load Opening Stock|Update Opening)$/ }).click(),
  ]);
  const body = await response.json();
  assert.equal(response.status(), 201, JSON.stringify(body));
  await page
    .getByText(/Saved — voucher #/)
    .first()
    .waitFor();
  return { book: 'TOP', vchNo: String(body.vchNo).padStart(5, '0'), tagNos: body.tagNos };
}

// --- Purchase (TR_PURC), Sales (TR_SALE), Sales Return (TR_SALE_RTN), Purchase Return (TR_KR_ISU) -----------------
const ACCOUNT_BOX = 'search accounts… (F1)';
export const chromeDate = (page) => page.locator('.voucher-chrome input[type="date"]').first();
export const field = (page, label) =>
  page
    .locator('.field')
    .filter({ has: page.locator('label', { hasText: new RegExp(`^${label}$`) }) })
    .locator('input,select')
    .first();
export const pad5 = (n) => String(n).padStart(5, '0');

export async function pickAccount(page, code, input = page.getByPlaceholder(ACCOUNT_BOX).first()) {
  await input.fill(code);
  await pickFromList(input, code);
}
export async function waitBook(page, book) {
  const select = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
  for (let i = 0; i < 60 && (await select.inputValue()) !== book; i += 1)
    await page.waitForTimeout(100);
  assert.equal(await select.inputValue(), book, `the provisioned ${book} book is selected`);
}
/** Type an item code in a purchase-style grid cell, closing its list. */
async function typeItem(cell, code) {
  await cell.fill(code);
  await cell.press('Escape');
}
export const lineCell = (page, row, n) =>
  page
    .locator('table', { has: page.locator('th', { hasText: 'Making/g' }) })
    .first()
    .locator('tbody tr')
    .nth(row)
    .locator(`td:nth-child(${n}) input`)
    .first();
export const fillLine = async (page, row, l) => {
  // Columns: 1 item, 2 tag, 3 pcs, 4 gross, 5 net, 6 touch, 7 rate, 8 making/g.
  await typeItem(lineCell(page, row, 1), l.item);
  if (l.tag) {
    await lineCell(page, row, 2).fill(l.tag);
    await lineCell(page, row, 2).press('Escape');
  }
  for (const [n, value] of [
    [3, l.pcs],
    [4, l.gross],
    [5, l.net],
    [6, l.touch],
    [7, l.rate],
  ])
    if (value !== undefined) await lineCell(page, row, n).fill(value);
};

/** Purchase of loose stock (Purchase Invoice, book PR). */
export async function savePurchase(page, { date, supplier = SUP.code, line }) {
  await page.goto('/txn/purchase');
  await page.getByRole('heading', { name: 'Purchase Invoice', exact: true }).waitFor();
  await waitBook(page, 'PR');
  const save = page.getByRole('button', { name: 'Save Purchase', exact: true });
  for (let i = 0; i < 50 && (await save.isDisabled()); i += 1) await page.waitForTimeout(100);
  await pickAccount(page, supplier);
  await chromeDate(page).fill(date);
  await fillLine(page, 0, line);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/purchases(\/|$)/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    save.click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return { book: 'PR', vchNo: pad5((await response.json()).vchNo) };
}

/** Sale of a tag (Sales Invoice, book SL): the tag fills item and weights, the touch is the sale touch. */
export async function saveSale(page, { date, party = CUS.code, tag, touch }) {
  await page.goto('/txn/sales');
  await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
  await waitBook(page, 'SL');
  await pickAccount(page, party);
  await chromeDate(page).fill(date);
  const cell = (n) => page.locator(`[data-grid-row="0"][data-grid-column="${n}"] input`).first();
  await cell(1).fill(tag);
  await pickFromList(cell(1), tag);
  await page.waitForFunction(
    () => document.querySelector('[data-grid-row="0"][data-grid-column="0"] input')?.value,
  );
  await cell(5).fill(touch);
  // The desktop refuses a sale with no item value ("Please Insert Item Value and try"); the rate leaves stock alone.
  await cell(6).fill('6000');
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/sales(\/|$)/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    page.getByRole('button', { name: 'Save Invoice', exact: true }).click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return { book: 'SL', vchNo: pad5((await response.json()).vchNo) };
}

/**
 * Sales Return of a sold tag (book SRT). A tagged return must name its original sale (TR_SALE_RTN.cs), so the bill is
 * imported: the party and the sold line (tag, item, weights, touch) come from the sale.
 */
export async function saveSalesReturn(page, { date, sale }) {
  await page.goto('/txn/sale-return');
  await page.getByRole('heading', { name: 'Sales Return', exact: true }).waitFor();
  await waitBook(page, 'SRT');
  await page
    .getByRole('combobox', { name: 'Configured book', exact: true })
    .nth(1)
    .selectOption(sale.book);
  await field(page, 'Orig Bill No').fill(sale.vchNo);
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === '/api/sales-returns/import'),
    page.getByRole('button', { name: 'Import', exact: true }).click(),
  ]);
  await page.waitForFunction(
    () => document.querySelector('table.grid tbody tr td:nth-child(2) input')?.value,
  );
  await field(page, 'Vch Date').fill(date);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => new URL(r.url()).pathname === '/api/sales-returns' && r.request().method() === 'POST',
    ),
    page.getByRole('button', { name: 'Save Return', exact: true }).click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return { book: 'SRT', vchNo: pad5((await response.json()).vchNo) };
}

/** Purchase Return of loose stock (book PRT). */
export async function savePurchaseReturn(page, { date, supplier = SUP.code, line }) {
  await page.goto('/txn/purchase-return');
  await page.getByRole('heading', { name: 'Purchase Return', exact: true }).waitFor();
  await waitBook(page, 'PRT');
  await pickAccount(page, supplier, page.getByLabel('Supplier account', { exact: true }));
  await field(page, 'Date').fill(date);
  await fillLine(page, 0, line);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /^\/api\/purchase-returns(\/\d+)?$/.test(new URL(r.url()).pathname) &&
        ['POST', 'PUT'].includes(r.request().method()),
    ),
    page.getByRole('button', { name: 'Save Return', exact: true }).click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return { book: 'PRT', vchNo: pad5((await response.json()).vchNo) };
}

// --- Tag Cancel / Stock Adjust (TR_TAG_CAN) and Approval Issue (TR_APR_ISU) --------------------------------------
const tcCell = (page, label, line) => page.getByLabel(`${label} line ${line}`, { exact: true });
const waitFocus = (page, label) =>
  page.waitForFunction(
    (want) => document.activeElement?.getAttribute('aria-label') === want,
    label,
  );

async function openTagForm(page, path, heading, book) {
  await page.goto(path);
  await page.getByRole('heading', { name: heading, exact: true }).waitFor();
  await waitBook(page, book);
  const vchNo = page.getByLabel('Vch No', { exact: true });
  for (let i = 0; i < 100 && !(await vchNo.inputValue()); i += 1) await page.waitForTimeout(100);
  assert.ok(await vchNo.inputValue(), 'the next voucher number is shown');
}
async function pickCancelTag(page, line, tag, sourcePath) {
  const input = tcCell(page, 'TagNo', line);
  await input.fill(tag);
  await input.locator('xpath=..').getByText(tag, { exact: true }).first().waitFor();
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === sourcePath),
    input.press('Enter'),
  ]);
  await page.waitForFunction(
    (n) => document.querySelector(`input[aria-label="ItCode line ${n}"]`)?.value,
    line,
  );
}

/** Cancel tags (book TGC): each is taken out of stock. */
export async function saveTagCancel(page, { date, tags }) {
  await openTagForm(page, '/txn/tag-cancel', 'Tag Cancel', 'TGC');
  await page.getByLabel('Vch Date', { exact: true }).fill(date);
  for (const [i, tag] of tags.entries())
    await pickCancelTag(page, i + 1, tag, '/api/stock/tag-cancel/source');
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        r.request().method() === 'POST' &&
        /^\/api\/stock\/tag-cancel(\/\d+)?$/.test(new URL(r.url()).pathname),
    ),
    page.getByTestId('tag-cancel-save').click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return { book: 'TGC', vchNo: pad5((await response.json()).voucherNo) };
}

/** A loose line of Stock Adjust: Enter on the blank TagNo goes to ItCode, the item list picks it. */
async function looseAdjustLine(page, line, { item, gross, less, touch, sign }) {
  const tagBox = tcCell(page, 'TagNo', line);
  await tagBox.focus();
  await tagBox.press('Enter');
  await waitFocus(page, `ItCode line ${line}`);
  const itemBox = tcCell(page, 'ItCode', line);
  await itemBox.fill(item);
  await pickFromList(itemBox, item);
  await waitFocus(page, `Counter line ${line}`);
  await tcCell(page, 'Sign', line).fill(sign);
  await tcCell(page, 'Pcs', line).fill('1');
  await tcCell(page, 'GrWt', line).fill(String(gross));
  await tcCell(page, 'GrWt', line).press('Enter');
  if (less) {
    await tcCell(page, 'LsWt', line).fill(String(less));
    await tcCell(page, 'LsWt', line).press('Enter');
  }
  await tcCell(page, 'Touch', line).fill(String(touch));
  await tcCell(page, 'Touch', line).press('Enter');
}

/** Stock Adjust (book SAJ) with loose lines. */
export async function saveStockAdjust(page, { date, lines }) {
  await openTagForm(page, '/txn/stock-adjust', 'Stock Adjust', 'SAJ');
  await page.getByLabel('Vch Date', { exact: true }).fill(date);
  for (const [i, l] of lines.entries()) await looseAdjustLine(page, i + 1, l);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        r.request().method() === 'POST' &&
        /^\/api\/stock\/stock-adjust(\/\d+)?$/.test(new URL(r.url()).pathname),
    ),
    page.getByTestId('stock-adjust-save').click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return { book: 'SAJ', vchNo: pad5((await response.json()).voucherNo) };
}

export const apLabel = (page, name) => page.getByLabel(name, { exact: true });
export async function pickApproval(page, name, code) {
  const input = apLabel(page, name);
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: false }).first().waitFor();
  await input.press('Enter');
}

/** Approval Issue of a tag to a party (book TUR). */
export async function saveApprovalIssue(page, { date, party = CUS.code, tag }) {
  await page.goto('/txn/tour');
  await page.getByRole('heading', { name: 'Approval Issue', exact: true }).waitFor();
  await waitBook(page, 'TUR');
  await apLabel(page, 'Vch Date').fill(date);
  await pickApproval(page, 'Party Code', party);
  await pickApproval(page, 'Employee Code', EMPLOYEE);
  const tagBox = apLabel(page, 'TagNo line 1');
  await tagBox.fill(tag);
  await pickFromList(tagBox, tag);
  await page.waitForFunction(
    () => document.querySelector('input[aria-label="ItCode line 1"]')?.value,
  );
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => r.request().method() === 'POST' && new URL(r.url()).pathname === '/api/tour/issue',
    ),
    page.getByTestId('approval-issue-save').click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return { book: 'TUR', vchNo: String((await response.json()).voucherNo) };
}

/**
 * The counter transfer of cases.md M12/M13. Tag Transfer is not a Lite menu, so these two rows (one out of counter
 * 001, one into counter 002, TR_TYPE T) are the only fixture insert of the data set (Ac_Stock.cs:543).
 */
export async function insertCounterTransfer(ctx, date) {
  const vchNo = 'ZTF01';
  let sr = 0;
  for (const [sign, counter] of [
    ['-', '001'],
    ['+', '002'],
  ]) {
    sr += 1;
    await exec(
      ctx,
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","IT_CODE","TAG_NO",
         "TBL_CODE","TR_TYPE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","KR_FINE","DATA_TYPE")
       VALUES($1,'01',$2,$3,'TTR',$4,$5,$6::date,'TAGTR',$7,'N',$8,'T',$9,1,10.5,10,9.16,9.16,'A')`,
      LC,
      YEAR,
      vchNo,
      sr,
      date,
      ITEMS.B.code,
      counter,
      sign,
    );
  }
  return { book: 'TTR', vchNo };
}

// ---------------------------------------------------------------------------------------------------------------
// The data set: one real-screen save per step, in the order of cases.md (T18 journey). Every step records the
// report (Item dimension, W1, net and gross) before and after it, so the create cases assert their deltas.
// ---------------------------------------------------------------------------------------------------------------

const LINE = (item, pcs, gross, net, touch, tag) => ({
  item,
  pcs,
  gross,
  net,
  touch,
  rate: '6000',
  ...(tag ? { tag } : {}),
});
const A = ITEMS.A.code;
const B = ITEMS.B.code;
const S = ITEMS.S.code;
const TAGS = {
  // tag, item, day, counter, design, size, gross, net (cases.md M4 .. M8)
  T1: { tag: TAG.T1, item: A, day: 5, counter: '001', design: 'D1', gross: '12.5', net: '12' },
  T2: { tag: TAG.T2, item: A, day: 6, counter: '001', gross: '6.3', net: '6' },
  T3: { tag: TAG.T3, item: A, day: 7, counter: '001', gross: '8.4', net: '8' },
  T4: { tag: TAG.T4, item: A, day: 11, counter: '002', design: 'D1', gross: '3.15', net: '3' },
  T5: {
    tag: TAG.T5,
    item: B,
    day: 12,
    counter: '001',
    design: 'D2',
    size: '7',
    gross: '21',
    net: '20',
  },
};
const tagVoucher = (page, key) => saveTagOpening(page, D(TAGS[key].day), [TAGS[key]]);

export const STEPS = [
  [
    'item-opening',
    async (page) => {
      await saveItemOpening(page, 'G', {
        [A]: { Pcs: '10', GrWt: '105', NetWt: '100', Touch: '91.6' },
        [B]: { Pcs: '5', GrWt: '52.5', NetWt: '50', Touch: '91.6' },
      });
      await saveItemOpening(page, 'S', {
        [S]: { Pcs: '100', GrWt: '1000', NetWt: '950', Touch: '91.6' },
      });
      return [
        { book: '000', vchNo: 'G' },
        { book: '000', vchNo: 'S' },
      ];
    },
  ],
  ['tag-opening', async (page) => [await tagVoucher(page, 'T1'), await tagVoucher(page, 'T4')]],
  [
    'tag-opening-rest',
    async (page) => [
      await tagVoucher(page, 'T2'),
      await tagVoucher(page, 'T3'),
      await tagVoucher(page, 'T5'),
    ],
  ],
  [
    'purchase',
    async (page) => [
      await savePurchase(page, { date: D(12), line: LINE(A, '4', '42', '40', '92') }),
    ],
  ],
  [
    'purchase-silver',
    async (page) => [
      await savePurchase(page, { date: D(18), line: LINE(S, '10', '100', '95', '92') }),
    ],
  ],
  ['sale', async (page) => [await saveSale(page, { date: D(15), tag: TAG.T1, touch: '92' })]],
  [
    'sales-return',
    async (page, done) => [
      await saveSalesReturn(page, { date: D(20), sale: done.get('sale').vouchers[0] }),
    ],
  ],
  [
    'purchase-return',
    async (page) => [
      await savePurchaseReturn(page, { date: D(25), line: LINE(A, '2', '21', '20', '92') }),
    ],
  ],
  [
    'stock-adjust',
    async (page) => [
      await saveStockAdjust(page, {
        date: D(28),
        lines: [
          { item: A, gross: '5.25', less: '0.25', touch: '91.6', sign: '+' },
          { item: A, gross: '2.1', less: '0.1', touch: '91.6', sign: '-' },
        ],
      }),
    ],
  ],
  ['tag-cancel', async (page) => [await saveTagCancel(page, { date: D(30), tags: [TAG.T2] })]],
  ['approval-issue', async (page) => [await saveApprovalIssue(page, { date: D(33), tag: TAG.T3 })]],
];
export const STEP_IDS = [...STEPS.map(([id]) => id), 'transfer'];

/** The shared state of this process: which steps ran, what they saved and what the report showed around each. */
const dataSet = { baseline: null, done: new Map(), provisioned: false, employeeAdded: false };

const reportPair = async (page) => ({
  net: await snapshot(page),
  gross: await snapshot(page, { gross: true }),
});

/** Row counts of every tenant table, to prove the teardown leaves the shared database as it found it. */
async function tableCounts(ctx) {
  const tables = await ctx.owner.$queryRawUnsafe(
    `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id' ORDER BY 1`,
  );
  const counts = {};
  for (const { table_name } of tables) {
    const [{ n }] = await ctx.owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "${table_name}" WHERE tenant_id=$1`,
      ctx.tenantId,
    );
    counts[table_name] = n;
  }
  return counts;
}

/**
 * Make sure the data set exists up to (and including) step `upTo`; steps run once per process, in order, with the
 * calling case's session. Returns the recorded steps.
 */
export async function ensureProvisioned(ctx) {
  if (dataSet.provisioned) return;
  dataSet.baseline = await tableCounts(ctx);
  await provision(ctx);
  dataSet.provisioned = true;
}

export async function ensureBuilt(ctx, upTo = 'transfer') {
  await ensureProvisioned(ctx);
  const last = STEP_IDS.indexOf(upTo);
  assert(last >= 0, `unknown data step ${upTo}`);
  for (const id of STEP_IDS.slice(0, last + 1)) {
    if (dataSet.done.has(id)) continue;
    const { page } = await ctx.session(at());
    const before = await reportPair(page);
    let vouchers;
    if (id === 'transfer') vouchers = [await insertCounterTransfer(ctx, D(20))];
    else vouchers = await STEPS.find(([step]) => step === id)[1](page, dataSet.done);
    const after = await reportPair(page);
    dataSet.done.set(id, { id, vouchers, before, after });
  }
  return dataSet.done;
}

export const stepOf = (id) => dataSet.done.get(id);
export const builtSteps = () => dataSet.done;

/** Remove the location, its vouchers and the masters; fail if anything else in the tenant changed. */
export async function teardown(ctx) {
  if (!dataSet.provisioned) return { removed: false };
  const owned = await ctx.owner.$queryRawUnsafe(
    `SELECT DISTINCT a.table_name FROM information_schema.columns a
       JOIN information_schema.columns b ON b.table_schema='public' AND b.table_name=a.table_name AND b.column_name='tenant_id'
      WHERE a.table_schema='public' AND a.column_name='LC_CODE'`,
  );
  for (const { table_name } of owned)
    await exec(ctx, `DELETE FROM "${table_name}" WHERE tenant_id=$1 AND "LC_CODE"=$2`, LC);
  await exec(
    ctx,
    `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" = ANY($2::text[])`,
    Object.values(ITEMS).map((i) => i.code),
  );
  await exec(
    ctx,
    `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE" = ANY($2::text[])`,
    GROUPS.map(([c]) => c),
  );
  await exec(
    ctx,
    `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE" = ANY($2::text[])`,
    PRODUCTS.map(([c]) => c),
  );
  await exec(
    ctx,
    `DELETE FROM "BAL_GR" WHERE tenant_id=$1 AND "TRAD_TYPE" = ANY($2::text[])`,
    TRADING.map(([c]) => c),
  );
  await exec(
    ctx,
    `DELETE FROM "DESIGN_MAST" WHERE tenant_id=$1 AND "DESIGN_NO" = ANY($2::text[])`,
    ['D1', 'D2'],
  );
  if (dataSet.employeeAdded)
    await exec(
      ctx,
      `DELETE FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "EMP_CODE"=$2`,
      EMPLOYEE,
    );
  const after = await tableCounts(ctx);
  // Session, audit and idempotency bookkeeping grows with every sign-in or save; business tables must not.
  const bookkeeping =
    /SESSION|AUDIT|IDEMPOT|RECEIPT|REFRESH|TOKEN|LOGIN_ATTEMPT|MESSAGE|OUTBOX|EVENT|JOB|LOCK|LEASE|VERSION/i;
  const leaked = Object.entries(after)
    .filter(([table, n]) => n !== dataSet.baseline[table] && !bookkeeping.test(table))
    .map(([table, n]) => `${table}: ${dataSet.baseline[table]} -> ${n}`);
  dataSet.done.clear();
  dataSet.provisioned = false;
  dataSet.employeeAdded = false;
  dataSet.baseline = null;
  return { removed: true, leaked };
}
