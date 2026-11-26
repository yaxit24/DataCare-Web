import assert from 'node:assert/strict';
import * as data from './stockReportData.mjs';

/**
 * Screen flows the Stock Report cases use after the data set is built: reopening, editing and deleting the vouchers
 * the report lists, the Approval Return, and the master edits made through Item Master. Each one drives the real
 * entry screen (the same screens the cases of the other modules use), never the database.
 */
const { isApi, pad5, apLabel, pickApproval, waitBook, chromeDate, lineCell } = data;

/** Open Purchase Invoice on a saved voucher (Voucher No + Load). */
export async function openPurchase(page, vchNo) {
  await page.goto('/txn/purchase');
  await page.getByRole('heading', { name: 'Purchase Invoice', exact: true }).waitFor();
  await waitBook(page, 'PR');
  const save = page.getByRole('button', { name: 'Save Purchase', exact: true });
  for (let i = 0; i < 50 && (await save.isDisabled()); i += 1) await page.waitForTimeout(100);
  await page.getByLabel('Voucher No', { exact: true }).fill(vchNo);
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page
    .getByTestId('purchase-loaded')
    .filter({ hasText: `Loaded #${vchNo}` })
    .waitFor();
}

/** Edit a saved purchase: any of date, pcs, gross, net; Update Purchase answers 200. */
export async function editPurchase(page, vchNo, { date, pcs, gross, net }) {
  await openPurchase(page, vchNo);
  if (date) await chromeDate(page).fill(date);
  for (const [n, value] of [
    [3, pcs],
    [4, gross],
    [5, net],
  ])
    if (value !== undefined) await lineCell(page, 0, n).fill(value);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        /\/api\/purchases(\/|$)/.test(new URL(r.url()).pathname) && r.request().method() === 'PUT',
    ),
    page.getByRole('button', { name: 'Update Purchase', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
}

/** Delete a saved sale from Sales Invoice (Voucher No + Load, then Delete). */
export async function deleteSale(page, vchNo) {
  await page.goto('/txn/sales');
  await page.getByRole('heading', { name: 'Sales Invoice', exact: true }).waitFor();
  await waitBook(page, 'SL');
  await page.getByLabel('Voucher No', { exact: true }).fill(vchNo);
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page
    .getByTestId('sales-loaded')
    .filter({ hasText: `Loaded #${vchNo}` })
    .waitFor();
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => r.request().method() === 'DELETE' && /\/api\/sales\//.test(r.url()),
    ),
    page.getByRole('button', { name: 'Delete', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
}

/** Delete a saved sales return from the Recent vouchers list of Sales Return. */
export async function deleteSalesReturn(page, vchNo) {
  await page.goto('/txn/sale-return');
  await page.getByRole('heading', { name: 'Sales Return', exact: true }).waitFor();
  await waitBook(page, 'SRT');
  await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
  const row = page.locator('tr').filter({ hasText: vchNo }).first();
  await row.waitFor();
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => r.request().method() === 'DELETE' && /\/api\/sales-returns\//.test(r.url()),
    ),
    row.getByRole('button', { name: /Delete/ }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
}

/** Approval Return of an issued tag: the issue voucher's lines are loaded, then saved (book TRR). */
export async function saveApprovalReturn(page, { date, issueVch, party = data.CUS.code }) {
  await page.goto('/txn/tour-return');
  await page.getByRole('heading', { name: 'Approval Return', exact: true }).waitFor();
  await waitBook(page, 'TRR');
  await apLabel(page, 'Vch Date').fill(date);
  await pickApproval(page, 'Party Code', party);
  await pickApproval(page, 'Employee Code', data.EMPLOYEE);
  await apLabel(page, 'Original Issue Vch No').fill(issueVch);
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === `/api/tour/${issueVch}/lines`),
    page.getByTestId('approval-return-load-lines').click(),
  ]);
  await apLabel(page, 'TagNo line 1').waitFor();
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'POST', '/tour/return')),
    page.getByTestId('approval-return-save').click(),
  ]);
  assert.equal(response.status(), 201, await response.text());
  return { book: 'TRR', vchNo: String((await response.json()).voucherNo) };
}

/** Delete a saved Approval Return (reopen by Vch No, Delete, answer Yes). */
export async function deleteApprovalReturn(page, vchNo) {
  await page.goto('/txn/tour-return');
  await page.getByRole('heading', { name: 'Approval Return', exact: true }).waitFor();
  await waitBook(page, 'TRR');
  const box = apLabel(page, 'Vch No');
  await box.fill(vchNo);
  await Promise.all([
    page.waitForResponse((r) => new URL(r.url()).pathname === `/api/tour/return/${vchNo}`),
    box.press('Enter'),
  ]);
  await page.getByText(`Loaded voucher ${vchNo}`, { exact: true }).waitFor();
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'DELETE', `/tour/return/${vchNo}`)),
    page.getByTestId('approval-return-delete').click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
}

/** Rename an item and/or change its safe through Item Master (the opened item keeps its product, group and code). */
export async function editItemMaster(page, code, { name, safe }) {
  const [list] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', '/masters/item-master')),
    page.goto('/masters/items'),
  ]);
  assert.equal(list.status(), 200, await list.text());
  await page.getByRole('heading', { name: 'Item Master', exact: true }).waitFor();
  const row = page.getByTestId('item-list').locator(`tr[data-code="${code}"]`);
  await row.waitFor();
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `/masters/item-master/${code}`)),
    row.dblclick(),
  ]);
  await page.waitForFunction(
    (c) =>
      document.querySelector('#item-code')?.value === c &&
      document.activeElement?.id === 'item-name',
    code,
  );
  if (name !== undefined) await page.getByLabel('Item Name', { exact: true }).fill(name);
  if (safe !== undefined) await page.getByLabel('Safe Name', { exact: true }).fill(safe);
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        ['POST', 'PUT'].includes(r.request().method()) &&
        new URL(r.url()).pathname.startsWith('/api/masters/item-master'),
    ),
    page.getByRole('button', { name: 'Save', exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.getByText('Data Are Saved.', { exact: true }).waitFor();
}

export { pad5 };
