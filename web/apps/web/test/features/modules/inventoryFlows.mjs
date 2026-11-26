import assert from 'node:assert/strict';
import { ITEMS, PARTIES } from '../fixtures/catalogue.mjs';
import { createIssue } from './approvalHelpers.mjs';

/**
 * Voucher flows through the real screens, shared by the inventory feature modules (Tag Stock, HuId Report): a Tag
 * Opening, a Sale of one tag, a Tag Cancel, a Sale Return of one tag and an Approval Issue, each with its Delete. They
 * are the steps of the playbook journeys (WP-15 tag-stock.journey.*, WP-18 huid-report.journey.*): every tag is
 * created by Tag Opening, so the stock rows are the ones the desktop writes, not seeded rows.
 */
export const pad = (n) => String(n).padStart(5, '0');
const isApi = (r, method, test) =>
  r.request().method() === method && test(new URL(r.url()).pathname);

/** Desktop dd/mm/yyyy of today, the date the Tag Opening, Sale and Tag Cancel screens start on. */
export const today = () => {
  const d = new Date();
  const p = (n) => String(n).padStart(2, '0');
  return { iso: `${d.getFullYear()}-${p(d.getMonth() + 1)}-${p(d.getDate())}` };
};

// ───────────── Tag Opening (TR_TAG_OPBL) ─────────────
async function openOpeningScreen(page, book = 'TOP') {
  await page.goto('/txn/tag-opening');
  await page.getByRole('heading', { name: /^Tag Opening Balance/ }).waitFor();
  const box = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 60 && (await box.inputValue()) !== book; i++) await page.waitForTimeout(100);
  assert.equal(await box.inputValue(), book, `the provisioned ${book} book is selected`);
}
async function pickCode(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}
/** Open tags through Tag Opening. Each tag is { tag (typed number, else generated), gross, net, touch, item, counter, pcs }. */
export async function openTags(page, tags) {
  await openOpeningScreen(page);
  for (const [i, t] of tags.entries()) {
    const row = i + 1;
    if (row > 1) {
      await page.getByRole('button', { name: '+ Add tag', exact: true }).click();
      await page.getByLabel(`Tag no row ${row}`, { exact: true }).waitFor();
    }
    if (t.tag) await page.getByLabel(`Tag no row ${row}`, { exact: true }).fill(t.tag);
    await pickCode(page, `Item code row ${row}`, t.item ?? ITEMS.gold.code);
    const fields = {
      tblCode: t.counter,
      pcs: t.pcs ?? '1',
      grossWt: t.gross,
      netWt: t.net,
      touch: t.touch,
    };
    for (const [field, value] of Object.entries(fields))
      if (value !== undefined)
        await page.getByLabel(`Tag opening ${field} row ${row}`, { exact: true }).fill(value);
  }
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        r.request().method() === 'POST' && new URL(r.url()).pathname === '/api/stock/tag-opening',
    ),
    page.getByRole('button', { name: 'Load Opening Stock', exact: true }).click(),
  ]);
  const body = await response.json();
  assert.equal(response.status(), 201, JSON.stringify(body));
  await page
    .getByText(/Saved — voucher #/)
    .first()
    .waitFor();
  return { vchNo: pad(body.vchNo), tagNos: body.tagNos };
}
export async function deleteOpening(page, vchNo) {
  await openOpeningScreen(page);
  const box = page.getByLabel('Voucher No', { exact: true });
  await box.fill(vchNo);
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', (p) => p === `/api/stock/tag-opening/${vchNo}`)),
    box.press('Enter'),
  ]);
  await page.getByTestId('tag-opening-loaded').waitFor();
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'DELETE', (p) => p === `/api/stock/tag-opening/${vchNo}`)),
    page
      .locator('button.danger')
      .filter({ hasText: /^Delete$/ })
      .click(),
  ]);
  return response;
}

// ───────────── Sales Invoice (TR_SALE) ─────────────
async function openSales(page) {
  await page.goto('/txn/sales');
  await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && !(await book.inputValue()); i++) await page.waitForTimeout(100);
}
/** Sell one tag (the Tag cell of the first line, qty 1, rate as given). Returns the voucher number. */
export async function sellTag(page, tag, { rate = '6000', party = PARTIES.local.code } = {}) {
  await openSales(page);
  const input = page.getByPlaceholder('search accounts… (F1)').first();
  await input.fill(party);
  await input.locator('xpath=..').getByText(party, { exact: true }).first().waitFor();
  await input.press('Enter');
  const tagCell = page.locator('[data-grid-row="0"][data-grid-column="1"] input').first();
  await tagCell.fill(tag);
  await tagCell.locator('xpath=..').getByText(tag, { exact: true }).first().waitFor();
  await tagCell.press('Enter');
  await page.locator('[data-grid-row="0"][data-grid-column="2"] input').first().fill('1');
  await page.locator('[data-grid-row="0"][data-grid-column="6"] input').first().fill(rate);
  const [sale] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'POST', (p) => p === '/api/sales')),
    page.getByRole('button', { name: 'Save Invoice', exact: true }).click(),
  ]);
  assert.equal(sale.status(), 201, await sale.text());
  return pad((await sale.json()).vchNo);
}
export async function deleteSale(page, vchNo) {
  await openSales(page);
  await page.getByLabel('Voucher No', { exact: true }).fill(vchNo);
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page
    .getByTestId('sales-loaded')
    .filter({ hasText: `Loaded #${vchNo}` })
    .waitFor();
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'DELETE', (p) => /^\/api\/sales\//.test(p))),
    page.getByRole('button', { name: 'Delete', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
}

// ───────────── Tag Cancel (TR_TAG_CAN) ─────────────
async function openCancel(page) {
  await page.goto('/txn/tag-cancel');
  await page.getByRole('heading', { name: 'Tag Cancel', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== 'TGC'; i++)
    await page.waitForTimeout(100);
  const vchNo = page.getByLabel('Vch No', { exact: true });
  for (let i = 0; i < 100 && !(await vchNo.inputValue()); i++) await page.waitForTimeout(100);
}
export async function cancelTag(page, tag) {
  await openCancel(page);
  const input = page.getByLabel('TagNo line 1', { exact: true });
  await input.fill(tag);
  await input.locator('xpath=..').getByText(tag, { exact: true }).first().waitFor();
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', (p) => p === '/api/stock/tag-cancel/source')),
    input.press('Enter'),
  ]);
  await page.waitForFunction(
    () => document.querySelector('input[aria-label="ItCode line 1"]')?.value,
  );
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'POST', (p) => p === '/api/stock/tag-cancel')),
    page.getByTestId('tag-cancel-save').click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return String((await response.json()).voucherNo);
}
export async function deleteCancel(page, voucherNo) {
  await openCancel(page);
  const box = page.getByLabel('Vch No', { exact: true });
  await box.fill(voucherNo);
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', (p) => p === `/api/stock/tag-cancel/${voucherNo}`)),
    box.press('Enter'),
  ]);
  await page
    .getByTestId('tag-cancel-status')
    .filter({ hasText: `Loaded voucher ${voucherNo}` })
    .waitFor();
  const [response] = await Promise.all([
    page.waitForResponse((r) =>
      isApi(r, 'DELETE', (p) => p === `/api/stock/tag-cancel/${voucherNo}`),
    ),
    page.getByTestId('tag-cancel-delete').click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
}

// ───────────── Sales Return (TR_SALE_RTN) ─────────────
async function openReturn(page) {
  await page.goto('/txn/sale-return');
  await page.getByRole('heading', { name: 'Sales Return', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
  for (let i = 0; i < 50 && (await book.inputValue()) !== 'SRT'; i++)
    await page.waitForTimeout(100);
}
/**
 * Return a sold tag: the sale's bill is imported (Orig Book, Orig Bill No, Import: TR_SALE_RTN.cs:3917 copies the sold
 * line with its tag number), which fills the customer and the line.
 */
export async function returnTag(page, saleVchNo, { book = 'SL' } = {}) {
  await openReturn(page);
  await page
    .getByRole('combobox', { name: 'Configured book', exact: true })
    .nth(1)
    .selectOption(book);
  await page
    .locator('.field')
    .filter({ has: page.locator('label', { hasText: /^Orig Bill No$/ }) })
    .locator('input')
    .first()
    .fill(saleVchNo);
  await page.getByRole('button', { name: 'Import', exact: true }).click();
  try {
    await page.waitForFunction(
      () => {
        const box = [...document.querySelectorAll('table')]
          .find((t) => t.textContent.includes('Making/g'))
          ?.querySelector('tbody tr td:nth-child(2) input');
        return box && box.value;
      },
      undefined,
      { timeout: 15000 },
    );
  } catch (error) {
    const notes = await page.locator('.msg').allInnerTexts();
    throw new Error(`import of sale ${saleVchNo} filled no tag: ${notes.join(' | ')}`, {
      cause: error,
    });
  }
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'POST', (p) => p === '/api/sales-returns')),
    page.getByRole('button', { name: 'Save Return', exact: true }).click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return pad((await response.json()).vchNo);
}
export async function deleteReturn(page, vchNo) {
  await openReturn(page);
  await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
  const row = page.locator('tr').filter({ hasText: vchNo }).first();
  await row.waitFor();
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'DELETE', (p) => p.startsWith('/api/sales-returns/'))),
    row.getByRole('button', { name: /Delete/ }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
}

// ───────────── Approval Issue (TR_APR_ISU) ─────────────
export const issueApproval = async (ctx, tag, session) =>
  createIssue(ctx, tag, 'journey approval', session);

// ───────────── Hallmarked Purchase (TR_PURC_HM, the Purchase screen with PURC_WITH_HMTAX = Y) ─────────────
/** Run with CO_SET_NEW.PURC_WITH_HMTAX = 'Y' (MDI_FORM.cs:7866 opens TR_PURC_HM), then restore the previous value. */
export async function withHallmarkLayout(ctx, run) {
  const [before] = await ctx.rows(
    `SELECT "PURC_WITH_HMTAX" v FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
  );
  if (before)
    await ctx.owner.$executeRawUnsafe(
      `UPDATE "CO_SET_NEW" SET "PURC_WITH_HMTAX"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      ctx.tenantId,
    );
  else
    await ctx.owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","PURC_WITH_HMTAX") VALUES ($1,'01','Y')`,
      ctx.tenantId,
    );
  try {
    return await run();
  } finally {
    if (before)
      await ctx.owner.$executeRawUnsafe(
        `UPDATE "CO_SET_NEW" SET "PURC_WITH_HMTAX"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        ctx.tenantId,
        before.v,
      );
    else
      await ctx.owner.$executeRawUnsafe(
        `DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        ctx.tenantId,
      );
  }
}
async function openHallmarkPurchase(page) {
  await page.goto('/txn/purchase');
  await page.getByRole('heading', { name: /^Hallmark Purchase/ }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && !(await book.inputValue()); i++) await page.waitForTimeout(100);
}
/**
 * A purchase of tags on the hallmark layout: each line is { tag, huid, pcs, gross, net, touch, rate }; the line's tag
 * number and HUID become the BAR_DETL tag and its HM_ID. Returns the voucher number.
 */
export async function hallmarkPurchase(ctx, page, lines, { party = PARTIES.local.code } = {}) {
  return withHallmarkLayout(ctx, async () => {
    await openHallmarkPurchase(page);
    const supplier = page.getByPlaceholder('search accounts… (F1)').first();
    await supplier.fill(party);
    await supplier.locator('xpath=..').getByText(party, { exact: true }).first().waitFor();
    await supplier.press('Enter');
    for (const [i, line] of lines.entries()) {
      if (i) await page.getByRole('button', { name: '+ Add line', exact: true }).click();
      const row = page.locator('table tbody tr').nth(i);
      const cell = (n) => row.locator(`td:nth-child(${n}) input`).first();
      await cell(1).fill(line.item ?? ITEMS.gold.code);
      await cell(1).press('Escape');
      await cell(2).fill(line.tag);
      await cell(2).press('Escape');
      if (line.huid) await cell(3).fill(line.huid);
      for (const [n, value] of [
        [4, line.pcs],
        [5, line.gross],
        [6, line.net],
        [7, line.touch],
        [8, line.rate],
      ])
        if (value !== undefined) await cell(n).fill(value);
    }
    const [response] = await Promise.all([
      page.waitForResponse((r) => isApi(r, 'POST', (p) => /^\/api\/purchases?$/.test(p))),
      page.getByRole('button', { name: 'Save Hallmark Purchase', exact: true }).click(),
    ]);
    assert.equal(response.status(), 201, await response.text());
    return pad((await response.json()).vchNo);
  });
}
export async function deletePurchase(ctx, page, vchNo) {
  return withHallmarkLayout(ctx, async () => {
    await openHallmarkPurchase(page);
    await page.getByLabel('Voucher No', { exact: true }).fill(vchNo);
    await page.getByRole('button', { name: 'Load', exact: true }).click();
    await page
      .getByTestId('purchase-hm-loaded')
      .filter({ hasText: `Loaded #${vchNo}` })
      .waitFor();
    const [response] = await Promise.all([
      page.waitForResponse((r) => isApi(r, 'DELETE', (p) => p.startsWith('/api/purchases'))),
      page.getByRole('button', { name: 'Delete', exact: true }).click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
  });
}
