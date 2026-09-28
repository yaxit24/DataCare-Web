import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';

/**
 * X14 real-stack journey. The caller owns server startup, real login and disposable DB seeding.
 * No request interception or canned API responses are used here. See fixture defaults below.
 */
export async function exerciseTourOrder(page, options = {}) {
  assert(
    options.owner && typeof options.owner.$queryRawUnsafe === 'function',
    'Tour exact-value roundtrip requires the existing disposable fixture owner',
  );
  assert.equal(
    typeof options.tenantId,
    'string',
    'Tour exact-value roundtrip requires the runner tenant',
  );
  assert(
    options.tenantId.length > 0,
    'Tour exact-value roundtrip requires a nonempty runner tenant',
  );
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
    const exactValues = await exerciseTourOrderExactValues(page, {
      owner: options.owner,
      tenantId: options.tenantId,
      fixture,
      checkpoint: options.checkpoint,
    });
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
      exactValues,
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
        'exact saved Tour scalars survive API JSON, browser unchanged/advance-only saves and SQL readback',
      ],
    };
  } finally {
    page.off('request', collect);
  }
}

/** Additional real-DB import/roundtrip case; the runner supplies its already isolated owner. */
async function exerciseTourOrderExactValues(page, { owner, tenantId, fixture, checkpoint }) {
  const scope = {
    coCode: fixture.coCode,
    lcCode: fixture.lcCode,
    coYear: fixture.coYear,
    coBook: 'E13',
  };
  const query = new URLSearchParams(scope).toString();
  const fullScope = [tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook];
  const tableNames = ['SL_ORD_DATA', 'SL_ORD_DETL', 'SL_ORD_IDTL', 'AC_DATA', 'ROJ_MEL_DATA'];
  const rawRows = async (table, voucherNo) => {
    assert(tableNames.includes(table));
    return (
      await owner.$queryRawUnsafe(
        `SELECT (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(r)-'row_id') e) AS value
       FROM "${table}" r WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
       ORDER BY (to_jsonb(r)-'row_id')::text`,
        ...fullScope,
        voucherNo,
      )
    ).map((row) => row.value);
  };
  const snapshot = async (voucherNo) =>
    Object.fromEntries(
      await Promise.all(tableNames.map(async (table) => [table, await rawRows(table, voucherNo)])),
    );
  const protectedRows = async () =>
    Object.fromEntries(
      await Promise.all(
        tableNames.map(async (table) => [
          table,
          await owner.$queryRawUnsafe(
            `SELECT to_jsonb(r)::text AS raw,r.xmin::text AS xmin,r.ctid::text AS ctid FROM "${table}" r
       WHERE tenant_id=$1 AND NOT ("CO_CODE" IS NOT DISTINCT FROM $2 AND "LC_CODE" IS NOT DISTINCT FROM $3
       AND "CO_YEAR" IS NOT DISTINCT FROM $4 AND "CO_BOOK" IS NOT DISTINCT FROM $5) ORDER BY to_jsonb(r)::text`,
            ...fullScope,
          ),
        ]),
      ),
    );
  const protectedBefore = await protectedRows();
  const sha = (value) => createHash('sha256').update(JSON.stringify(value)).digest('hex');
  const existing = await owner.$queryRawUnsafe(
    'SELECT "CO_BOOK" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4',
    tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  assert.deepEqual(existing, [], 'exact-value book must be a new isolated fixture');
  await owner.$executeRawUnsafe(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
     VALUES($1,$2,$3,$4,'Tour exact values','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA','SL_ORD_DETL')`,
    tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  // Create ordinary calculable bases through the real API. SQL below represents imported
  // exact auxiliary values; it does not replace or intercept any HTTP response.
  const base = {
    pcs: 1,
    touch: 100,
    making: 0,
    labourRate: 0,
    labourPct: 0,
    labourAmount: 0,
    mrp: 0,
    bagWt: 0,
  };
  const createdResponse = await page.request.post(`/api/tour-orders?${query}`, {
    data: {
      acCode: fixture.acCode,
      acName: 'Exact Tour browser customer',
      vchDate: '2024-07-10',
      vchTime: '09:10:11.123456',
      billNo: 'TOUR-EXACT/17',
      vchDesc: 'Exact imported values',
      taxRatePct: 0,
      advanceAmount: 25,
      cashAc: 'CASH',
      netAmount: 260,
      lines: [
        {
          ...base,
          srNo: 7,
          oldSrNo: 31,
          itCode: fixture.itemCode,
          grossWt: 10,
          netWt: 10,
          rate: 20,
          components: [
            {
              isrNo: 3,
              itCode: fixture.componentCode,
              dmCode: '00012',
              dmName: 'Imported first',
              pcs: 0,
              grossWt: 0.125,
              rate: 0,
              amount: 11,
              lbrRate: 0,
              netAmount: 11,
              karigarRate: 0,
            },
            {
              isrNo: 13,
              itCode: fixture.componentCode,
              dmCode: '00013',
              dmName: 'Imported second',
              pcs: 2,
              grossWt: 0.25,
              rate: 0,
              amount: 13,
              lbrRate: 0,
              netAmount: 13,
              karigarRate: 0,
            },
          ],
        },
        {
          ...base,
          srNo: 19,
          oldSrNo: 58,
          itCode: fixture.itemCode,
          grossWt: 2,
          netWt: 2,
          rate: 30,
          components: [],
        },
      ],
    },
  });
  const created = await createdResponse.json();
  assert.equal(createdResponse.status(), 201, JSON.stringify(created));
  assert.equal(
    created.total,
    260,
    'ordinary calculation bases remain independent of imported auxiliary values',
  );
  const voucherNo = String(created.vchNo).padStart(5, '0');
  const key = [...fullScope, voucherNo];
  assert.equal(
    await owner.$executeRawUnsafe(
      `UPDATE "SL_ORD_DATA" SET "MOBILE"=NULL,"ADD1"='',"SCHM_AMT"=0
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...key,
    ),
    1,
  );
  assert.equal(
    await owner.$executeRawUnsafe(
      `UPDATE "SL_ORD_DETL" SET "ITM_MRP"=999999999999999.99,"BAG_WT"=NULL,"OTH_AMT"=0
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"=7`,
      ...key,
    ),
    1,
  );
  assert.equal(
    await owner.$executeRawUnsafe(
      `UPDATE "SL_ORD_IDTL" SET "DM_NAME"=NULL,"IT_RATE"=NULL,"IT_LBR_RATE"=0,"KR_RATE"=999999999999998.99
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"=7 AND "ISR_NO"=3`,
      ...key,
    ),
    1,
  );
  assert.equal(
    await owner.$executeRawUnsafe(
      `UPDATE "SL_ORD_IDTL" SET "DM_NAME"='',"IT_RATE"=0,"IT_LBR_RATE"=NULL,"KR_RATE"=999999999999997.99
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"=7 AND "ISR_NO"=13`,
      ...key,
    ),
    1,
  );
  const before = await snapshot(voucherNo);
  const parent = (values, srNo) => values.SL_ORD_DETL.find((row) => row.SR_NO === String(srNo));
  const child = (values, srNo, isrNo) =>
    values.SL_ORD_IDTL.find((row) => row.SR_NO === String(srNo) && row.ISR_NO === String(isrNo));
  assert.equal(parent(before, 7).ITM_MRP, '999999999999999.99');
  assert.equal(parent(before, 7).BAG_WT, null);
  assert.equal(child(before, 7, 3).KR_RATE, '999999999999998.99');
  assert.equal(child(before, 7, 13).KR_RATE, '999999999999997.99');
  assert.equal(child(before, 7, 3).IT_RATE, null);
  assert.match(child(before, 7, 13).IT_RATE, /^0(?:\.0+)?$/);
  assert.equal(before.SL_ORD_DATA[0].MOBILE, null);
  assert.equal(before.SL_ORD_DATA[0].ADD1, '');

  await page.goto('/txn/tour-order');
  const book = page.getByLabel('Configured book', { exact: true });
  await book.locator('option[value="E13"]').waitFor({ state: 'attached' });
  await book.selectOption('E13');
  const endpoint = `/api/tour-orders/${voucherNo}`;
  const waitResponse = (method) =>
    page.waitForResponse((response) => {
      const url = new URL(response.url());
      return (
        url.pathname === endpoint &&
        url.searchParams.get('coBook') === 'E13' &&
        response.request().method() === method
      );
    });
  const load = async () => {
    await page.getByLabel('Order number', { exact: true }).fill(voucherNo);
    const [response] = await Promise.all([
      waitResponse('GET'),
      page.getByRole('button', { name: 'Load order', exact: true }).click(),
    ]);
    assert.equal(response.status(), 200);
    const document = await response.json();
    await page.getByText(`Editing order #${voucherNo}`, { exact: true }).waitFor();
    return document;
  };
  const exactDto = (document, advance) => {
    for (const field of ['coCode', 'lcCode', 'coYear', 'coBook'])
      assert.equal(document[field], scope[field]);
    assert.equal(document.voucherNo, voucherNo);
    assert.match(document.version, /^[a-f0-9]{64}$/);
    assert.equal(document.vchTime, '09:10:11.123456');
    assert.equal(document.advanceAmount, advance);
    assert.equal(document.mobile, null);
    assert.equal(document.address1, '');
    assert.equal(document.schemeAmount, 0);
    assert.deepEqual(
      document.lines.map((row) => [row.srNo, row.oldSrNo]),
      [
        [7, 31],
        [19, 58],
      ],
    );
    assert.equal(document.lines[0].mrp, '999999999999999.99');
    assert.equal(document.lines[0].bagWt, null);
    assert.equal(document.lines[1].mrp, 0);
    assert.equal(document.lines[1].bagWt, 0);
    const children = document.lines[0].components;
    assert.deepEqual(
      children.map((row) => row.isrNo),
      [3, 13],
    );
    assert.equal(children[0].dmCode, '00012');
    assert.equal(children[0].dmName, null);
    assert.equal(children[1].dmName, '');
    assert.equal(children[0].rate, null);
    assert.equal(children[1].rate, 0);
    assert.equal(children[0].lbrRate, 0);
    assert.equal(children[1].lbrRate, null);
    assert.equal(children[0].karigarRate, '999999999999998.99');
    assert.equal(children[1].karigarRate, '999999999999997.99');
  };
  const details = (item) =>
    page.locator('details').filter({
      has: page.locator('summary', { hasText: `Item ${item} specifications and components` }),
    });
  const visible = async () => {
    for (const summary of [
      page.getByText('Order details', { exact: true }),
      details(1).locator('summary'),
      details(2).locator('summary'),
    ])
      if (!(await summary.locator('..').evaluate((element) => element.open))) await summary.click();
    for (const [locator, expected] of [
      [page.getByLabel('Mobile', { exact: true }), ''],
      [page.getByLabel('Address 1', { exact: true }), ''],
      [details(1).getByLabel('MRP', { exact: true }), '999999999999999.99'],
      [details(1).getByLabel('Bag Wt', { exact: true }), ''],
      [details(2).getByLabel('MRP', { exact: true }), '0'],
      [details(2).getByLabel('Bag Wt', { exact: true }), '0'],
      [details(1).getByLabel('KrRate row 1', { exact: true }), '999999999999998.99'],
      [details(1).getByLabel('KrRate row 2', { exact: true }), '999999999999997.99'],
      [details(1).getByLabel('Rate row 1', { exact: true }), ''],
      [details(1).getByLabel('Rate row 2', { exact: true }), '0'],
      [details(1).getByLabel('LbrRate row 1', { exact: true }), '0'],
      [details(1).getByLabel('LbrRate row 2', { exact: true }), ''],
    ])
      assert.equal(await locator.inputValue(), expected, 'exact saved editor value');
  };
  const update = async (document, expectedAdvance) => {
    const [response] = await Promise.all([
      waitResponse('PUT'),
      page.getByRole('button', { name: 'Update Tour Order', exact: true }).click(),
    ]);
    const responseBody = await response.json();
    assert.equal(response.status(), 200, JSON.stringify(responseBody));
    const submitted = response.request().postDataJSON();
    assert.equal(
      submitted.expectedVersion,
      document.version,
      'the save uses the exact loaded version',
    );
    assert.equal(submitted.advanceAmount, expectedAdvance);
    assert.equal(submitted.mobile, null);
    assert.equal(submitted.address1, '');
    assert.deepEqual(
      submitted.lines.map((row) => [row.srNo, row.oldSrNo]),
      [
        [7, 31],
        [19, 58],
      ],
    );
    assert.equal(submitted.lines[0].mrp, '999999999999999.99');
    assert.equal(submitted.lines[0].bagWt, null);
    assert.equal(submitted.lines[1].mrp, 0);
    assert.equal(submitted.lines[1].bagWt, 0);
    assert.deepEqual(
      submitted.lines[0].components.map((row) => row.isrNo),
      [3, 13],
    );
    assert.equal(submitted.lines[0].components[0].rate, null);
    assert.equal(submitted.lines[0].components[1].rate, 0);
    assert.equal(submitted.lines[0].components[0].dmCode, '00012');
    assert.equal(submitted.lines[0].components[0].dmName, null);
    assert.equal(submitted.lines[0].components[1].dmName, '');
    assert.equal(submitted.lines[0].components[0].lbrRate, 0);
    assert.equal(submitted.lines[0].components[1].lbrRate, null);
    assert.equal(submitted.lines[0].components[0].karigarRate, '999999999999998.99');
    assert.equal(submitted.lines[0].components[1].karigarRate, '999999999999997.99');
    await page.getByRole('button', { name: 'Save Tour Order', exact: true }).waitFor();
    return load();
  };
  const loaded = await load();
  exactDto(loaded, 25);
  await visible();
  await details(1).getByLabel('MRP', { exact: true }).scrollIntoViewIfNeeded();
  await checkpoint?.('tour-order-exact-values', page);
  const unchanged = await update(loaded, 25);
  exactDto(unchanged, 25);
  assert.notEqual(
    unchanged.version,
    loaded.version,
    'physical replacement invalidates the old saved version',
  );
  const afterUnchanged = await snapshot(voucherNo);
  assert.deepEqual(
    afterUnchanged,
    before,
    'all raw business header/parent/child/ledger/Rojmel scalars survive unchanged browser save',
  );
  await visible();
  await page.getByLabel('Advance ₹', { exact: true }).fill('40');
  const advanced = await update(unchanged, '40');
  exactDto(advanced, 40);
  assert.notEqual(advanced.version, unchanged.version);
  const afterAdvance = await snapshot(voucherNo);
  assert.deepEqual(afterAdvance.SL_ORD_DETL, before.SL_ORD_DETL);
  assert.deepEqual(afterAdvance.SL_ORD_IDTL, before.SL_ORD_IDTL);
  const withoutAdvance = (header) => {
    const { ADV_AMT, ...rest } = header;
    return rest;
  };
  assert.deepEqual(
    afterAdvance.SL_ORD_DATA.map(withoutAdvance),
    before.SL_ORD_DATA.map(withoutAdvance),
  );
  assert.match(afterAdvance.SL_ORD_DATA[0].ADV_AMT, /^40(?:\.0+)?$/);
  assert.equal(afterAdvance.AC_DATA.length, 2);
  const cash = afterAdvance.AC_DATA.find((row) => row.AC_CODE === 'CASH');
  const customer = afterAdvance.AC_DATA.find((row) => row.AC_CODE === fixture.acCode);
  assert.match(cash.DR_AMT, /^40(?:\.0+)?$/);
  assert.match(cash.CR_AMT, /^0(?:\.0+)?$/);
  assert.match(customer.CR_AMT, /^40(?:\.0+)?$/);
  assert.match(customer.DR_AMT, /^0(?:\.0+)?$/);
  assert.equal(afterAdvance.ROJ_MEL_DATA.length, 1);
  assert.match(afterAdvance.ROJ_MEL_DATA[0].CR_AMT, /^40(?:\.0+)?$/);
  await visible();
  const protectedAfter = await protectedRows();
  assert.deepEqual(
    protectedAfter,
    protectedBefore,
    'every other order scope in the disposable tenant retains physical rows',
  );
  return {
    scope,
    voucherNo,
    parentSerials: [7, 19],
    childSerials: [3, 13],
    protectedBeforeSha256: sha(protectedBefore),
    protectedAfterSha256: sha(protectedAfter),
    versions: [loaded.version, unchanged.version, advanced.version],
    beforeSha256: sha(before),
    afterUnchangedSha256: sha(afterUnchanged),
    beforeParentChildrenSha256: sha([before.SL_ORD_DETL, before.SL_ORD_IDTL]),
    afterAdvanceParentChildrenSha256: sha([afterAdvance.SL_ORD_DETL, afterAdvance.SL_ORD_IDTL]),
    changedAdvance: ['25', '40'],
  };
}
