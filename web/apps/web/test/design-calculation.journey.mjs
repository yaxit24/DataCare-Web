import assert from 'node:assert/strict';

/** Source/IL vectors through actual Next -> Fastify -> PostgreSQL. Caller seeds ITEM_MAST
 * CALCS in company01 with CON_PRC=.2, OTH_RATE_TYPE=P, OTH_RATE=50 and product01. */
export async function exerciseDesignCalculation(page, { checkpoint } = {}) {
  const pageErrors = [];
  const onPageError = (error) => pageErrors.push(error.message);
  page.on('pageerror', onPageError);
  const bookName = 'CALC WEB';
  const endpoint = `/api/masters/design-book?bookName=${encodeURIComponent(bookName)}&prCode=01`;
  const field = (label, child = false) =>
    page.getByLabel(`${label} ${child ? 'component' : 'design'} 1`, { exact: true });
  const expectValue = async (label, value, child = false) => {
    const locator = field(label, child);
    for (let count = 0; count < 60; count++) {
      if ((await locator.inputValue()) === value) return;
      await page.waitForTimeout(100);
    }
    assert.equal(await locator.inputValue(), value, `${label} ${child ? 'component' : 'design'}`);
  };
  const commit = async (label, value, child = false) => {
    await field(label, child).fill(value);
    await field(label, child).press('Tab');
  };
  const save = async (method) => {
    const [response] = await Promise.all([
      page.waitForResponse(
        (response) =>
          new URL(response.url()).pathname === '/api/masters/design-book' &&
          response.request().method() === method,
      ),
      page.getByRole('button', { name: 'Save Design Book', exact: true }).click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    await page
      .getByRole('status')
      .filter({ hasText: 'Saved and reopened 1 designs with their components.' })
      .waitFor();
    return response.request().postDataJSON();
  };
  await page.goto('/masters/design-book');
  await page.getByRole('heading', { name: 'Design Book', exact: true }).waitFor();
  await page.getByLabel('Book Name', { exact: true }).fill(bookName);
  await page.getByPlaceholder('search products… (F1)', { exact: true }).fill('01');
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await page.getByRole('status').filter({ hasText: 'This book is empty' }).waitFor();
  await expectValue('Pcs', '1');
  await commit('Design No', 'CALC-1');
  await commit('Gross', 'invalid');
  await page.getByRole('button', { name: 'Recalculate design totals', exact: true }).click();
  await page.getByRole('status').filter({ hasText: 'Design Gross:' }).waitFor();
  await expectValue('Gross', 'invalid');
  assert.deepEqual(pageErrors, [], 'Invalid editor text must not cause an unhandled React error');
  await commit('Gross', '10');
  await commit('Touch', '90');
  await page.getByRole('button', { name: '+ Add Component', exact: true }).click();
  await commit('Item', 'CALCS', true);
  await expectValue('Conversion', '0.2', true);
  await expectValue('Rate', '50', true);
  await expectValue('Rate Basis', 'P', true);
  await commit('Pcs', '4', true);
  await commit('Piece Weight', '2', true);
  await commit('Karigar Less %', '10', true);
  await commit('Labour Rate', '2', true);
  await expectValue('Karigar Weight', '8', true);
  await expectValue('Customer Weight', '0.8', true);
  await expectValue('Converted Weight', '0.16', true);
  await expectValue('Item Amount', '200', true);
  await expectValue('Labour Amount', '8', true);
  await expectValue('Net Amount', '208', true);
  await expectValue('Other Wt', '0.16');
  await expectValue('Net', '9.84');
  await expectValue('Fine', '9'); // component leave alone does not call parent fine calculation
  await page.getByRole('button', { name: 'Recalculate design totals', exact: true }).click();
  await expectValue('Fine', '8.856');
  await commit('Rate', '100');
  await expectValue('Amount', '886');
  await commit('Labour Type', 'N');
  await commit('Labour Rate', '3.5');
  await expectValue('Labour Amount', '34');
  await commit('Tag Cost', '100');
  await commit('Margin %', '5');
  await expectValue('MRP', '105');
  const create = await save('POST');
  assert(create.lines[0].calculationEvents.length > 10);
  assert(
    create.lines[0].calculationEvents.some(
      (event) => event.kind === 'item' && event.itCode === 'CALCS' && !('defaults' in event),
    ),
  );
  const saved = await (await page.request.get(endpoint)).json();
  assert.equal(Number(saved[0].ITM_FINE), 8.856);
  assert.equal(Number(saved[0].ITM_AMT), 886);
  assert.equal(Number(saved[0].components[0].IT_PCS_WT), 2);
  assert.equal(Number(saved[0].components[0].IT_NET_AMT), 208);
  const unchanged = await save('PUT');
  assert.equal(unchanged.lines[0].calculationEvents, undefined);
  assert.deepEqual(await (await page.request.get(endpoint)).json(), saved);
  await commit('Rate', '0');
  await commit('Labour Rate', '0');
  await expectValue('Amount', '886');
  await expectValue('Labour Amount', '34');
  await commit('Rate', '0.5', true);
  await expectValue('Item Amount', '0.4', true);
  await commit('Rate', '0.51', true);
  await expectValue('Item Amount', '2.04', true);
  await save('PUT');
  const updated = await (await page.request.get(endpoint)).json();
  assert.equal(Number(updated[0].ITM_AMT), 886);
  assert.equal(Number(updated[0].components[0].IT_AMT), 2.04);
  assert.equal(Number(updated[0].components[0].IT_NET_AMT), 10.04);
  const content = await page.locator('.content').evaluate((element) => ({
    scrollLeft: element.scrollLeft,
    clientWidth: element.clientWidth,
    scrollWidth: element.scrollWidth,
  }));
  assert.equal(content.scrollLeft, 0, 'Only the grid panels should scroll horizontally');
  assert(
    content.scrollWidth <= content.clientWidth + 1,
    'Wide design/component grids must not expand the page',
  );
  if (checkpoint) await checkpoint('design-book-calculations-round2', page);
  await page.getByRole('button', { name: 'Delete Book', exact: true }).click();
  await page.getByRole('button', { name: 'Confirm Delete Book', exact: true }).click();
  await page
    .getByRole('status')
    .filter({ hasText: 'Deleted the selected book and its components.' })
    .waitFor();
  assert.deepEqual(await (await page.request.get(endpoint)).json(), []);
  assert.deepEqual(pageErrors, []);
  page.off('pageerror', onPageError);
  return {
    checks: [
      'new-book configured item defaults',
      'ordered cell leaves',
      'invalid numeric refresh retains draft with field validation and no page error',
      'customer/karigar conversion and labour',
      'component-only aggregate trigger',
      'explicit parent refresh',
      'whole-amount bankers rounding',
      'transient margin and saved MRP',
      'server replay save/reopen',
      'unchanged snapshot without replay',
      'zero-rate manual amount retention',
      'IL P-basis 0.50/0.51 boundary',
      'wide grids scroll inside their panels while heading and book controls stay visible',
      'delete calculated design',
    ],
  };
}
