import assert from 'node:assert/strict';

/** sql(query,...values) is the runner's owner fixture helper with tenant bound as$1. */
export async function seedSalesOrder(sql) {
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
    VALUES($1,'01','01','S41','Browser Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL'),
          ($1,'01','01','S42','Imported Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA','SL_ORD_DETL')`);
  await sql(`INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","HD_VCH_NO","AC_CODE","AC_NAME","NET_AMT","TOT_AMT","TAX_PRC","TAX_AMT","ADV_AMT","ADD3","BILL_NO")
    VALUES($1,'01','01','2024-2025','S42','00001','2024-07-01','2024-07-01 12:13:14.123456','00041','TOURAC','Imported Sales customer',177.37,177.37,0,0,0,NULL,'IMPORTED-41')`);
  await sql(`INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","SR_NO","OLD_SRNO","VCH_SRNO","IT_CODE","TAG_NO","DESIGN_IMG_ID","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_RATE","LBR_TYPE","LBR_RATE","LBR_PRC","LBR_AMT","ITM_AMT","NET_AMT","TOT_AMT","BAG_WT","ITM_REMARK")
    VALUES($1,'01','01','2024-2025','S42','00001','2024-07-01',17,42,0,'GOLD','N','N',3,4,3.123,91.6,7000,'P',10.25,0,77.37,100,177.37,177.37,NULL,'Imported manual amount')`);
  await sql(`INSERT INTO "SL_ORD_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","DM_NAME","IT_PCS","IT_GWT","IT_LBR_AMT","KR_NET_AMT")
    VALUES($1,'01','01','2024-2025','S42','00001',17,3,'STONE','Imported ruby',0,0.123,NULL,0),
          ($1,'01','01','2024-2025','S42','00001',17,9,'STONE','Imported diamond',2,0.234,20,29.17)`);
}

/** Production browser journey: real requests and disposable app_user DB, no route mocking. */
export async function exerciseSalesOrder(page, { checkpoint } = {}) {
  const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025' };
  const query = (book) => new URLSearchParams({ ...scope, coBook: book }).toString();
  const records = [];
  const assertReplacementSnapshot = (after, before, message) => {
    const { version: nextVersion, ...nextBusiness } = after;
    const { version: oldVersion, ...previousBusiness } = before;
    assert.deepEqual(nextBusiness, previousBusiness, message);
    assert.equal(typeof nextVersion, 'string');
    assert(nextVersion.length > 0);
    // The API deliberately versions replacement row identities even for a no-op PUT.
    assert.notEqual(nextVersion, oldVersion, 'replacement must invalidate the old edit token');
  };
  const collect = (request) => {
    const url = new URL(request.url());
    if (/^\/api\/sales-orders(?:\/[^/]+)?$/.test(url.pathname))
      records.push({
        method: request.method(),
        path: url.pathname,
        query: Object.fromEntries(url.searchParams),
      });
  };
  page.on('request', collect);
  const responseFor = (method, path) =>
    page.waitForResponse(
      (response) =>
        response.request().method() === method &&
        new URL(response.url()).pathname === `/api${path}`,
    );
  const specs = () =>
    page.locator('details').filter({
      has: page.locator('summary', { hasText: 'Item 1 specifications and components' }),
    });
  const details = async () => {
    for (const label of ['Order details', 'Item 1 specifications and components']) {
      const summary = page.getByText(label, { exact: true });
      if (!(await summary.locator('..').evaluate((element) => element.open))) await summary.click();
    }
  };
  const save = async (method, expectedStatus = 200) => {
    const [response] = await Promise.all([
      page.waitForResponse(
        (response) =>
          response.request().method() === method &&
          /^\/api\/sales-orders(?:\/[^/]+)?$/.test(new URL(response.url()).pathname),
      ),
      page
        .getByRole('button', {
          name: method === 'POST' ? 'Save Sales Order' : 'Update Sales Order',
          exact: true,
        })
        .click(),
    ]);
    const body = await response.json();
    assert.equal(response.status(), expectedStatus, JSON.stringify(body));
    return { body, submitted: response.request().postDataJSON() };
  };
  const load = async (no) => {
    await page.getByLabel('Order number', { exact: true }).fill(no);
    const [response] = await Promise.all([
      responseFor('GET', `/sales-orders/${no}`),
      page.getByRole('button', { name: 'Load order', exact: true }).click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    await page.getByText(`Editing order #${no}`, { exact: true }).waitFor();
    return response.json();
  };
  const chooseBook = async (book) => {
    const select = page.getByLabel('Configured book', { exact: true });
    await select.locator(`option[value="${book}"]`).waitFor({ state: 'attached' });
    const [response] = await Promise.all([
      responseFor('GET', '/sales-orders/configuration'),
      select.selectOption(book),
    ]);
    assert.equal(response.status(), 200, await response.text());
    await page.waitForFunction(() => {
      const input = document.querySelector('[aria-label="Labour rate item 1"]');
      return input && !input.matches(':disabled');
    });
  };
  let voucherNo;
  try {
    await page.goto('/txn/sales-order');
    await page.getByRole('heading', { name: 'Sales Order', exact: true }).waitFor();
    await chooseBook('S41');
    await page.getByLabel('Order date', { exact: true }).fill('2024-07-10');
    await page.getByLabel('Customer account', { exact: true }).fill('TOURAC');
    await page.getByLabel('Customer Name', { exact: true }).fill('Real browser tour customer');
    await page.getByLabel('Tax %', { exact: true }).fill('0');
    await page.getByLabel('Advance ₹', { exact: true }).fill('12.34');
    await page.getByLabel('Item code 1', { exact: true }).fill('GOLD');
    for (const [label, val] of Object.entries({
      Design: 'WEB-SALES',
      Pieces: '2',
      'Gross weight': '3.5',
      'Net weight': '3.123',
      Touch: '91.6',
      Rate: '7000',
      'Labour rate': '37.32',
      Remark: 'Keep both Sales components',
    }))
      await page.getByLabel(`${label} item 1`, { exact: true }).fill(val);
    await details();
    for (const [label, val] of Object.entries({
      'Bill No': 'WEB-SALES/41',
      'Order time': '15:42:31.123456',
      'Cash A/c': 'CASH',
      'Address 3': 'Sales third road',
      'Delivery Date': '2024-07-20',
    }))
      await page.getByLabel(label, { exact: true }).fill(val);
    await specs().getByLabel('Ghat Wt', { exact: true }).fill('0.1');
    await specs().getByLabel('HUID', { exact: true }).fill('SA0123');
    assert.equal(await specs().getByLabel('Labour amount', { exact: true }).inputValue(), '117');
    await specs().getByPlaceholder('search items… (F1)', { exact: true }).nth(0).fill('STONE');
    await specs().getByLabel('DmName row 1', { exact: true }).fill('Sales Ruby');
    await specs().getByLabel('Weight row 1', { exact: true }).fill('0.123');
    await specs().getByRole('button', { name: 'Add stone row', exact: true }).click();
    await specs().getByPlaceholder('search items… (F1)', { exact: true }).nth(1).fill('STONE');
    await specs().getByLabel('DmName row 2', { exact: true }).fill('Sales Diamond');
    await specs().getByLabel('Weight row 2', { exact: true }).fill('0.234');
    const created = await save('POST', 201);
    voucherNo = String(created.body.vchNo).padStart(5, '0');
    assert(created.submitted.lines[0].orderEdits.some((event) => event.kind === 'labour'));
    assert.equal(created.submitted.vchDate, '2024-07-10');
    await page.getByRole('button', { name: 'Save Sales Order', exact: true }).waitFor();
    await page.waitForFunction(() => {
      const bill = document.querySelector('#sales-header-billNo');
      const clock = document.querySelector('#sales-header-vchTime');
      return bill && clock && bill.value === '' && clock.value === '';
    });
    assert.equal(await page.getByLabel('Bill No', { exact: true }).inputValue(), '');
    assert.equal(await page.getByLabel('Order time', { exact: true }).inputValue(), '');
    let loaded = await load(voucherNo);
    assert.equal(loaded.coBook, 'S41');
    assert.equal(loaded.vchTime, '15:42:31.123456');
    assert.equal(Number(loaded.lines[0].labourAmount), 117);
    assert.deepEqual(
      loaded.lines[0].components.map((child) => child.dmName),
      ['Sales Ruby', 'Sales Diamond'],
    );
    await details();
    assert(await page.locator('#sales-header-netAmount').evaluate((input) => input.readOnly));
    assert.equal(
      Number(await page.locator('#sales-header-netAmount').inputValue()),
      Number(loaded.netAmount),
    );
    await save('PUT');
    const unchanged = await load(voucherNo);
    assertReplacementSnapshot(
      unchanged,
      loaded,
      'unchanged UI replacement must retain the complete input-shaped business snapshot',
    );
    await details();
    await specs().getByLabel('Weight row 2', { exact: true }).fill('0.345');
    await save('PUT');
    loaded = await load(voucherNo);
    assert.equal(Number(loaded.lines[0].components[1].grossWt), 0.345);
    const concurrent = await page.request.put(`/api/sales-orders/${voucherNo}?${query('S41')}`, {
      data: {
        ...loaded,
        expectedVersion: loaded.version,
        dirtyFields: ['billNo'],
        billNo: 'Other operator bill',
      },
    });
    assert.equal(concurrent.status(), 200, await concurrent.text());
    await page.getByLabel('Remark item 1', { exact: true }).fill('Keep my stale draft');
    await save('PUT', 409);
    assert.equal(
      await page.getByLabel('Remark item 1', { exact: true }).inputValue(),
      'Keep my stale draft',
    );
    loaded = await load(voucherNo);
    const print = page.getByRole('link', { name: 'Print order', exact: true });
    const href = await print.getAttribute('href');
    assert.equal(new URL(href, 'http://fixture').searchParams.get('coBook'), 'S41');
    const printed = await page.request.get(href);
    assert.equal(printed.status(), 200);
    const printHtml = await printed.text();
    // The runner seeds the image-print configuration only after this Sales lifecycle.
    assert.match(printHtml, /<title>OrderBill<\/title>/);
    assert(printHtml.includes(voucherNo));
    assert(printHtml.includes('Real browser tour customer'));
    // OrderBill Section5 prints item name, pieces and weight, not DM_NAME.
    assert(printHtml.includes('0.123'));
    assert(printHtml.includes('0.345'));
    assert.equal((printHtml.match(/data-section="Section5"/g) ?? []).length, 2);
    await checkpoint?.('sales-order-loaded-components', page);
    await chooseBook('S42');
    assert.equal(await page.getByText(`Editing order #${voucherNo}`, { exact: true }).count(), 0);
    const imported = await load('00001');
    assert.equal(imported.lines[0].srNo, 17);
    assert.deepEqual(
      imported.lines[0].components.map((child) => child.isrNo),
      [3, 9],
    );
    await details();
    assert.equal(await specs().getByLabel('Labour amount', { exact: true }).inputValue(), '77.37');
    await save('PUT');
    const retained = await load('00001');
    assertReplacementSnapshot(
      retained,
      imported,
      'imported manual amounts, nulls and noncontiguous identity survive an unchanged edit',
    );
    await details();
    await specs().getByLabel('Other Amt', { exact: true }).fill('10');
    await specs().getByLabel('HUID', { exact: true }).focus();
    await page.waitForFunction(
      () =>
        document.querySelector(
          'form[aria-label="Sales Order editor"] table.grid tbody tr td:nth-child(9)',
        )?.textContent === '187.37',
    );
    await save('PUT');
    const adjusted = await load('00001');
    assert.equal(
      adjusted.lines[0].fineWeight,
      null,
      'unrelated amount edit retains imported NULL fine',
    );
    assert.equal(Number(adjusted.lines[0].itemAmount), 100);
    assert.equal(Number(adjusted.lines[0].labourAmount), 77.37);
    assert.equal(Number(adjusted.lines[0].lineNetAmount), 187.37);
    await details();
    await checkpoint?.('sales-order-imported-manual', page);
    await page.getByLabel('Order number', { exact: true }).fill('99999');
    const [missing] = await Promise.all([
      responseFor('GET', '/sales-orders/99999'),
      page.getByRole('button', { name: 'Load order', exact: true }).click(),
    ]);
    assert.equal(missing.status(), 400, await missing.text());
    assert.equal(await page.getByText('Editing order #00001', { exact: true }).count(), 0);
    await chooseBook('S41');
    await load(voucherNo);
    page.once('dialog', (dialog) => dialog.accept());
    const [deleted] = await Promise.all([
      responseFor('DELETE', `/sales-orders/${voucherNo}`),
      page.getByRole('button', { name: 'Delete order', exact: true }).click(),
    ]);
    assert.equal(deleted.status(), 200, await deleted.text());
    await page.getByRole('button', { name: 'Save Sales Order', exact: true }).waitFor();
    assert.equal(await page.getByLabel('Customer account', { exact: true }).inputValue(), '');
    for (const record of records) {
      assert.equal(record.query.coCode, '01');
      assert.equal(record.query.lcCode, '01');
      assert.equal(record.query.coYear, '2024-2025');
      assert(['S41', 'S42'].includes(record.query.coBook));
    }
    return {
      voucherNo,
      checks: [
        'configured non-SOR book',
        'explicit historical date and microsecond time',
        'source labour commit sequence',
        'two components',
        'complete reset after save',
        'unchanged and changed child edit',
        'stale409 retains draft',
        'full-scope print',
        'imported manual/null/noncontiguous identity retention',
        'unrelated amount edit preserves imported metal calculation',
        'scope change and failed load clear saved state',
        'versioned deletion',
      ],
      mockedRequests: 0,
    };
  } finally {
    page.off('request', collect);
  }
}
