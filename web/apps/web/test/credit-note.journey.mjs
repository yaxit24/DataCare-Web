import assert from 'node:assert/strict';

/** Read/browse a synthetic imported document. This does not claim credit-note creation parity. */
export async function exerciseCreditNote(page, { checkpoint }) {
  await page.goto('/txn/e-crnt-note');
  await page.getByRole('heading', { name: 'E CrntNote', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  await book.selectOption('146');
  await page.getByRole('button', { name: 'Browse credit notes', exact: true }).click();
  await page.getByRole('cell', { name: 'Imported credit-note customer', exact: true }).waitFor();
  await page.getByRole('button', { name: 'Open 00001', exact: true }).click();
  await page.getByRole('heading', { name: 'Credit note 00001', exact: true }).waitFor();
  await page.getByText('Component 3 · Ruby', { exact: true }).waitFor();
  await page.getByText('Component 9 · Diamond', { exact: true }).waitFor();
  assert(
    await page.getByRole('button', { name: 'IRN already generated', exact: true }).isDisabled(),
  );
  assert.equal(await page.getByText('Second credit-note book', { exact: true }).count(), 0);
  await checkpoint('credit-note-imported-components', page);
  for (const [name, weight] of [
    ['Component 3 · Ruby', '0'],
    ['Component 9 · Diamond', '0.123'],
  ]) {
    const summary = page.getByText(name, { exact: true });
    await summary.click();
    const detail = summary.locator('..');
    assert.match(
      await detail.innerText(),
      new RegExp(`Stone weight\\s+${weight.replace('.', '\\.')}(?:\\s|$)`),
    );
    await detail.evaluate((element) => element.scrollIntoView({ block: 'start' }));
    await checkpoint(`credit-note-${name.includes('Ruby') ? 'ruby' : 'diamond'}-detail`, page);
    await summary.click();
  }
  await book.selectOption('147');
  await page.getByRole('region', { name: 'Saved credit note' }).waitFor({ state: 'detached' });
  assert.equal(await page.getByRole('region', { name: 'Saved credit note' }).count(), 0);
  await page.getByLabel('Voucher number', { exact: true }).fill('00001');
  await page.getByRole('button', { name: 'Open credit note', exact: true }).click();
  await page.getByText('Second credit-note book', { exact: true }).waitFor();
  assert.equal(await page.getByText('Imported credit-note customer', { exact: true }).count(), 0);
  assert.equal(await page.getByText('Component 3 · Ruby', { exact: true }).count(), 0);
  await page.getByLabel('Voucher number', { exact: true }).fill('999');
  await page.getByRole('button', { name: 'Open credit note', exact: true }).click();
  await page.getByRole('status').filter({ hasText: 'credit-note-not-found' }).waitFor();
  assert.equal(await page.getByRole('region', { name: 'Saved credit note' }).count(), 0);
  return {
    checks: [
      'scoped browse',
      'persisted item and two components',
      'saved registration state',
      'same number in another credit book',
      'scope change and failed lookup clear prior document',
    ],
    boundary:
      'Read/browse imported fixture only; no create/edit/delete or live provider acceptance',
  };
}
