import assert from 'node:assert/strict';

/**
 * X14 real-stack journey. The caller owns server startup, real login and disposable DB seeding.
 * No request interception or canned API responses are used here. See fixture defaults below.
 */
export async function exerciseTourOrder(page, options = {}) {
  const fixture = {
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: 'Z09',
    acCode: 'TOURAC',
    itemCode: 'GOLD',
    componentCode: 'STONE',
    ...options.fixture,
  };
  const query = new URLSearchParams({
    coCode: fixture.coCode,
    lcCode: fixture.lcCode,
    coYear: fixture.coYear,
    coBook: fixture.coBook,
  }).toString();
  const requests = [];
  const collect = (request) => {
    const url = new URL(request.url());
    if (!/^\/api\/tour-orders(?:\/\d+)?$/.test(url.pathname)) return;
    requests.push({
      method: request.method(),
      pathname: url.pathname,
      scope: Object.fromEntries(url.searchParams),
    });
  };
  page.on('request', collect);
  const assertValue = async (locator, value, label) => {
    for (let attempt = 0; attempt < 50; attempt++) {
      if ((await locator.inputValue()) === value) return;
      await page.waitForTimeout(100);
    }
    assert.equal(await locator.inputValue(), value, label);
  };
  const responseFor = (method) =>
    page.waitForResponse(
      (response) =>
        new URL(response.url()).pathname.startsWith('/api/tour-orders') &&
        response.request().method() === method,
    );
  const save = async (name, method, expectedStatus) => {
    const [response] = await Promise.all([
      responseFor(method),
      page.getByRole('button', { name, exact: true }).click(),
    ]);
    const body = await response.json();
    assert.equal(response.status(), expectedStatus, JSON.stringify(body));
    if (method === 'POST') {
      const submitted = response.request().postDataJSON();
      assert.equal(
        submitted.lines[0].labourAmount,
        117,
        'submitted committed amount precedes ghat',
      );
      assert.deepEqual(
        submitted.lines[0].labourEdits.map(({ action, value, basis }) => ({
          action,
          value,
          ghatWt: basis.ghatWt,
        })),
        [{ action: 'rate', value: 37.32, ghatWt: 0 }],
        'the POST must carry the actual rate-before-ghat edit journal',
      );
    }
    return body;
  };
  const load = async (voucherNo) => {
    await page.getByLabel('Order number', { exact: true }).fill(voucherNo);
    const [response] = await Promise.all([
      page.waitForResponse(
        (response) =>
          new URL(response.url()).pathname === `/api/tour-orders/${voucherNo}` &&
          response.request().method() === 'GET',
      ),
      page.getByRole('button', { name: 'Load order', exact: true }).click(),
    ]);
    assert.equal(response.status(), 200);
    await page.getByText(`Editing order #${voucherNo}`, { exact: true }).waitFor();
    return response.json();
  };
  const specs = () =>
    page.locator('details').filter({
      has: page.locator('summary', { hasText: 'Item 1 specifications and components' }),
    });
  const openDetails = async () => {
    for (const summary of [
      page.getByText('Order details', { exact: true }),
      page.getByText('Item 1 specifications and components', { exact: true }),
    ]) {
      if (!(await summary.locator('..').evaluate((element) => element.open))) await summary.click();
    }
  };
  let voucherNo;
  try {
    await page.goto('/txn/tour-order');
    await page.getByRole('heading', { name: 'Tour Order', exact: true }).waitFor();
    const book = page.getByLabel('Configured book', { exact: true });
    await book.locator(`option[value="${fixture.coBook}"]`).waitFor({ state: 'attached' });
    // A single active book may be selected automatically; reset the selection so the next
    // user selection always starts a fresh scoped configuration request.
    await book.selectOption('');
    await page.waitForFunction(() => {
      const input = document.querySelector('[aria-label="Labour rate item 1"]');
      return input && input.matches(':disabled');
    });
    // Exercise a real unavailable/slow configuration request. No response is intercepted or
    // replaced; Chromium's network conditions are restored before the remaining journey.
    const network = await page.context().newCDPSession(page);
    try {
      await network.send('Network.enable');
      await network.send('Network.emulateNetworkConditions', {
        offline: true,
        latency: 0,
        downloadThroughput: -1,
        uploadThroughput: -1,
      });
      await book.selectOption(fixture.coBook);
      await page
        .getByRole('alert')
        .filter({ hasText: 'Could not load order calculation settings' })
        .waitFor();
      assert(
        await page.getByLabel('Labour rate item 1', { exact: true }).isDisabled(),
        'failed scoped configuration blocks editing',
      );
      assert(
        await page.getByRole('button', { name: 'Save Tour Order', exact: true }).isDisabled(),
        'failed scoped configuration blocks save',
      );
      await network.send('Network.emulateNetworkConditions', {
        offline: false,
        latency: 600,
        downloadThroughput: -1,
        uploadThroughput: -1,
      });
      const configuration = page.waitForResponse(
        (response) =>
          new URL(response.url()).pathname === '/api/tour-orders/configuration' &&
          new URL(response.url()).searchParams.get('coBook') === fixture.coBook,
      );
      await page.getByRole('button', { name: 'Retry order settings', exact: true }).click();
      await page
        .getByRole('status')
        .filter({ hasText: 'Loading order calculation settings' })
        .waitFor();
      assert(
        await page.getByLabel('Labour rate item 1', { exact: true }).isDisabled(),
        'pending scoped configuration blocks fast operator input',
      );
      assert(
        await page.getByRole('button', { name: 'Save Tour Order', exact: true }).isDisabled(),
        'pending scoped configuration blocks save',
      );
      assert.equal(
        (await configuration).status(),
        200,
        'retry uses the real configured-book endpoint',
      );
      await page.waitForFunction(() => {
        const input = document.querySelector('[aria-label="Labour rate item 1"]');
        return input && !input.matches(':disabled');
      });
    } finally {
      await network.send('Network.emulateNetworkConditions', {
        offline: false,
        latency: 0,
        downloadThroughput: -1,
        uploadThroughput: -1,
      });
      await network.detach();
    }
    await assertValue(book, fixture.coBook, 'configured Tour Order book');
    await page.getByLabel('Order date', { exact: true }).fill('2024-07-10');
    await page.getByLabel('Customer account', { exact: true }).fill(fixture.acCode);
    await page.getByLabel('Customer Name', { exact: true }).fill('Real browser tour customer');
    await page.getByLabel('Tax %', { exact: true }).fill('0');
    await page.getByLabel('Advance ₹', { exact: true }).fill('123.45');
    await page.getByLabel('Item code 1', { exact: true }).fill(fixture.itemCode);
    for (const [label, value] of Object.entries({
      Design: 'WEB-TOUR',
      Pieces: '2',
      'Gross weight': '3.5',
      'Net weight': '3.123',
      Touch: '91.6',
      Rate: '7000',
      'Labour rate': '37.321',
      Remark: 'Keep both components',
    })) {
      await page.getByLabel(`${label} item 1`, { exact: true }).fill(value);
    }
    await openDetails();
    await assertValue(
      specs().getByLabel('Labour amount', { exact: true }),
      '117',
      'rate commit is recorded before any later ghat input',
    );
    for (const [label, value] of Object.entries({
      'Bill No': 'WEB-TOUR/01',
      Description: 'Tour order with two stones',
      'Cash A/c': 'CASH',
      'Order time': '15:42:31.123',
      'Address 3': 'Browser third road',
      Mobile: '09876543210',
      Employee: 'EMP1',
      'Delivery Date': '2024-07-20',
      'Function Date': '2024-07-22',
    })) {
      await page.getByLabel(label, { exact: true }).fill(value);
    }
    for (const [label, value] of Object.entries({
      Counter: '002',
      Colour: 'ROSE',
      Size: '17.5',
      'Ghat Wt': '0.103',
      'Wastage %': '1.11',
      'Design Image': 'WEB-TOUR-SIDE',
      HUID: 'AB0123',
      'HM4 Wt': '1.004',
      'Old SrNo': '19',
    })) {
      await specs().getByLabel(label, { exact: true }).fill(value);
    }
    await assertValue(
      specs().getByLabel('Labour amount', { exact: true }),
      '117',
      'later ghat leaves the earlier committed labour unchanged',
    );
    await specs()
      .getByPlaceholder('search items… (F1)', { exact: true })
      .nth(0)
      .fill(fixture.componentCode);
    for (const [label, value] of Object.entries({
      DmCode: '00001',
      DmName: 'Round',
      Pcs: '3',
      Weight: '0.123',
      Rate: '30000',
      ItAmt: '3690',
      LbrRate: '15',
      LbrAmt: '45',
      NetAmt: '3735',
      KrNetAmt: '2530',
    })) {
      if (label === 'DmCode')
        await specs().getByPlaceholder('search diamonds… (F1)', { exact: true }).nth(0).fill(value);
      else await specs().getByLabel(`${label} row 1`, { exact: true }).fill(value);
    }
    await specs().getByRole('button', { name: 'Add stone row', exact: true }).click();
    await specs()
      .getByPlaceholder('search items… (F1)', { exact: true })
      .nth(1)
      .fill(fixture.componentCode);
    for (const [label, value] of Object.entries({
      DmName: 'Pear',
      Pcs: '1',
      Weight: '0.222',
      Rate: '1000',
      ItAmt: '1000',
      LbrRate: '0',
      LbrAmt: '0',
      NetAmt: '1000',
    })) {
      await specs().getByLabel(`${label} row 2`, { exact: true }).fill(value);
    }
    const created = await save('Save Tour Order', 'POST', 201);
    voucherNo = String(created.vchNo).padStart(5, '0');
    await assertValue(
      page.getByLabel('Customer account', { exact: true }),
      '',
      'new form clears after save',
    );
    // Close and select a saved voucher through the same controls used by the operator.
    await page.getByRole('button', { name: 'New order', exact: true }).click();
    const persisted = await load(voucherNo);
    assert.equal(persisted.coBook, fixture.coBook);
    assert.equal(persisted.advanceAmount, 123.45);
    assert.equal(persisted.lines[0].components.length, 2);
    assert.equal(persisted.lines[0].components[0].karigarNetAmount, 2530);
    const legacyUpdate = await page.request.put(`/api/tour-orders/${voucherNo}?${query}`, {
      data: {
        ...persisted,
        expectedVersion: persisted.version,
        lines: persisted.lines.map(({ components, ...line }) => line),
      },
    });
    assert.equal(legacyUpdate.status(), 400, await legacyUpdate.text());
    assert.match(await legacyUpdate.text(), /submit complete component lists/);
    const afterRefusedLegacy = await (
      await page.request.get(`/api/tour-orders/${voucherNo}?${query}`)
    ).json();
    assert.equal(afterRefusedLegacy.version, persisted.version);
    assert.deepEqual(
      afterRefusedLegacy.lines,
      persisted.lines,
      'refused legacy PUT preserves every child',
    );

    await openDetails();
    for (const [label, value] of [
      ['Bill No', 'WEB-TOUR/01'],
      ['Cash A/c', 'CASH'],
      ['Address 3', 'Browser third road'],
      ['Delivery Date', '2024-07-20'],
      ['Advance ₹', '123.45'],
    ]) {
      await assertValue(page.getByLabel(label, { exact: true }), value, label);
    }
    await assertValue(
      specs().getByLabel('Design Image', { exact: true }),
      'WEB-TOUR-SIDE',
      'design image identity survives hydration',
    );
    await assertValue(
      specs().getByLabel('DmName row 1', { exact: true }),
      'Round',
      'first component',
    );
    await assertValue(
      specs().getByLabel('LbrRate row 2', { exact: true }),
      '0',
      'explicit zero component rate',
    );
    await options.checkpoint?.('tour-order-loaded', page);
    await specs()
      .getByRole('heading', { name: 'Stones / components — item 1', exact: true })
      .scrollIntoViewIfNeeded();
    await options.checkpoint?.('tour-order-components', page);
    await save('Update Tour Order', 'PUT', 200);
    const unchanged = await load(voucherNo);
    assert.equal(unchanged.total, persisted.total);
    assert.deepEqual(
      unchanged.lines,
      persisted.lines,
      'unchanged browser edit preserves complete read-back line and child values',
    );
    assert.notEqual(unchanged.version, persisted.version);
    assert.equal(unchanged.vchTime, '15:42:31.123');
    assert.equal(unchanged.lines[0].labourAmount, 117, 'rate was entered before later ghat change');
    await openDetails();
    await specs().getByLabel('Labour Type', { exact: true }).selectOption('P');
    const rateInput = page.getByLabel('Labour rate item 1', { exact: true });
    await rateInput.fill('12.25');
    await rateInput.press('Tab');
    await assertValue(
      specs().getByLabel('Labour amount', { exact: true }),
      '24',
      'whole-rupee pieces midpoint preview',
    );
    await save('Update Tour Order', 'PUT', 200);
    const pieceOrder = await load(voucherNo);
    assert.equal(pieceOrder.lines[0].labourAmount, 24);
    assert.equal(pieceOrder.lines[0].components.length, 2);
    await openDetails();
    await specs().getByLabel('Labour %', { exact: true }).fill('1.25');
    await specs().getByLabel('Labour %', { exact: true }).press('Tab');
    await assertValue(rateInput, '87.5', 'percentage derives labour rate');
    await assertValue(
      specs().getByLabel('Labour amount', { exact: true }),
      '175',
      'percentage uses chosen pieces basis',
    );
    await specs().getByLabel('Labour amount', { exact: true }).fill('150.75');
    await specs().getByLabel('Labour amount', { exact: true }).press('Tab');
    await assertValue(rateInput, '75.38', 'manual amount derives source inverse rate');
    await save('Update Tour Order', 'PUT', 200);
    const manualOrder = await load(voucherNo);
    assert.equal(manualOrder.lines[0].labourAmount, 150.75);
    assert.equal(manualOrder.lines[0].labourRate, 75.38);
    await save('Update Tour Order', 'PUT', 200);
    const unchangedManual = await load(voucherNo);
    assert.deepEqual(
      unchangedManual.lines,
      manualOrder.lines,
      'manual paise and both children survive unchanged save',
    );
    await options.checkpoint?.('tour-order-labour', page);
    await openDetails();
    await specs().getByLabel('DmName row 2', { exact: true }).fill('Oval');
    await save('Update Tour Order', 'PUT', 200);
    const changed = await load(voucherNo);
    assert.deepEqual(
      changed.lines[0].components.map((row) => row.dmName),
      ['Round', 'Oval'],
    );
    // Simulate a second authenticated operator writing after this screen loaded, using the real API.
    const concurrent = await page.request.put(`/api/tour-orders/${voucherNo}?${query}`, {
      data: { ...changed, expectedVersion: changed.version, vchDesc: 'Updated in another session' },
    });
    assert.equal(concurrent.status(), 200, await concurrent.text());
    await openDetails();
    await page.getByLabel('Description', { exact: true }).fill('Local unsaved description');
    await save('Update Tour Order', 'PUT', 409);
    await page
      .getByText('Order changed since it was loaded; reload before saving or deleting.', {
        exact: true,
      })
      .waitFor();
    await assertValue(
      page.getByLabel('Description', { exact: true }),
      'Local unsaved description',
      'conflict keeps local edits',
    );
    await load(voucherNo);
    const href = await page
      .getByRole('link', { name: 'Print order', exact: true })
      .getAttribute('href');
    const printUrl = new URL(href, page.url());
    assert.equal(printUrl.pathname, '/api/tour-orders/confirmation', 'Tour-owned print route');
    for (const key of ['coCode', 'lcCode', 'coYear', 'coBook'])
      assert.equal(printUrl.searchParams.get(key), fixture[key], `print ${key}`);
    const printed = await page.request.get(href);
    assert.equal(printed.status(), 200, await printed.text());
    const printedHtml = await printed.text();
    assert.match(printedHtml, /Real browser tour customer/);
    assert.match(printedHtml, /Tour Order/);
    assert(printedHtml.includes(voucherNo), 'printed voucher identity');
    assert.match(printedHtml, /0\.123/);
    assert.match(printedHtml, /0\.222/); // Actual TourOrdVch child bands show weight/pieces, not DM shape names.
    page.once('dialog', (dialog) => dialog.accept());
    await save('Delete order', 'DELETE', 200);
    const remaining = await page.request.get(`/api/tour-orders?${query}`);
    assert.equal(remaining.status(), 200);
    assert.equal(
      (await remaining.json()).some((row) => row.vchNo === voucherNo),
      false,
    );
    const relevant = requests.filter((request) => request.scope.coBook === fixture.coBook);
    for (const request of relevant) {
      for (const key of ['coCode', 'lcCode', 'coYear', 'coBook'])
        assert.equal(
          request.scope[key],
          fixture[key],
          `${request.method} ${request.pathname}: ${key}`,
        );
    }
    assert(relevant.some((request) => request.method === 'POST'));
    assert(relevant.some((request) => request.method === 'PUT'));
    assert(relevant.some((request) => request.method === 'DELETE'));
    return {
      voucherNo,
      scope: fixture,
      requests: relevant,
      checks: [
        'configured book',
        'real offline configuration failure blocks editing and save',
        'real delayed configuration retry blocks editing and save until ready',
        'POST preserves rate-before-ghat journal and amount117',
        'browser create/reopen',
        'two component rows',
        'legacy flattened update400 preserves children',
        'unchanged edit',
        'changed child',
        'whole-rupee pieces and percentage labour',
        'manual paise unchanged edit',
        'rate-before-ghat ordered commits',
        'voucher time preservation',
        'stale edit409 retains form',
        'scoped print',
        'browser deletion',
      ],
    };
  } finally {
    page.off('request', collect);
  }
}
