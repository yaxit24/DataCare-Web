import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';

/** sql(query,...values) injects the real-stack synthetic tenant as $1. No shared registration mutation. */
export async function seedSalesOrderDesign(sql) {
  await cleanupSalesOrderDesign(sql);
  await sql(`INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE","IT_TYPE") VALUES
    ($1,'01','SDF1','Sales F1 ring','F4','G'),($1,'01','STF1','Sales F1 component','F5','S'),($1,'02','SDF1','Foreign Sales F1 ring','F4','G')`);
  await sql(
    `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES ($1,'01','F4','Sales F1 product'),($1,'01','F5','Other F1 product')`,
  );
  await sql(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','SDF1CUS','Design selection customer')`,
  );
  await sql(`INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","OLD_SRNO","DESIGN_NO","ITM_SIZE","DIE_NO","KR_NAME","ITM_GWT","ITM_TOUCH","ITM_WEST_PRC","LBR_PRC","LBR_RATE","DESIGN_IMG_ID") VALUES
    ($1,'01','F1 ALBUM A','F4',17,42,'SAME-F1','12','REMARK A','K01',999.999,91.625,2.3456,5.5555,77.25,'F1-A-IMAGE'),
    ($1,'01','F1 ALBUM B','F4',23,NULL,'SAME-F1','14','REMARK B','K02',777.777,0,0,0,55.50,NULL),
    ($1,'01','F1 EXCLUDED','F5',81,90,'WRONG-PRODUCT','18','OTHER','K03',8.888,92,2,0,50,'F1-X-IMAGE'),
    ($1,'02','F1 ALBUM A','F4',17,42,'WRONG-COMPANY','99','FOREIGN','K09',123.456,99,9,9,999,'F1-A-IMAGE')`);
  const bytes = readFileSync(
    new URL('../../api/test/fixtures/order-design-portrait.png', import.meta.url),
  );
  await sql(
    `INSERT INTO "ENTITY_IMAGE"(tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES")
    VALUES($1,'01','','DESIGN','F1-A-IMAGE',0,'D','image/png',$2,$3)`,
    bytes.length,
    bytes,
  );
}
export async function cleanupSalesOrderDesign(sql) {
  for (const table of ['ENTITY_IMAGE', 'ENTITY_IMAGE_REVISION'])
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "ENTITY_TYPE"='DESIGN' AND "ENTITY_KEY" IN ('F1-A-IMAGE','F1-B-IMAGE','F1-X-IMAGE')`,
    );
  for (const table of ['DESIGN_IDTL', 'DESIGN_DETL'])
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "BOOK_NAME" IN ('F1 ALBUM A','F1 ALBUM B','F1 EXCLUDED')`,
    );
  await sql(`DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "PR_CODE" IN ('F4','F5')`);
  await sql(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" IN ('SDF1','STF1')`);
  await sql(`DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"='SDF1CUS'`);
}

export async function exerciseSalesOrderDesign(page, { checkpoint, coBook = 'S41' } = {}) {
  const checks = [];
  const errors = [];
  const onError = (error) => errors.push(error.message);
  page.on('pageerror', onError);
  const eventually = async (fn, message) => {
    for (let i = 0; i < 100; i++) {
      if (await fn()) return;
      await page.waitForTimeout(50);
    }
    assert(await fn(), message);
  };
  const value = (label, expected) =>
    eventually(
      async () => (await page.getByLabel(label, { exact: true }).inputValue()) === expected,
      `${label} expected ${expected}`,
    );
  const focusDesign = () =>
    eventually(
      () =>
        page
          .getByLabel('Design item 1', { exact: true })
          .evaluate((el) => document.activeElement === el),
      'Design focus restored',
    );
  const dialog = () => page.getByRole('dialog', { name: 'Choose Design Book design' });
  const use = (album, serial) =>
    dialog().getByRole('button', {
      name: `Use SAME-F1 from F1 ALBUM ${album}, serial ${serial}`,
      exact: true,
    });
  const open = async () => {
    await page.getByLabel('Design item 1', { exact: true }).focus();
    await page.getByLabel('Design item 1', { exact: true }).press('F1');
    await dialog().waitFor({ state: 'visible' });
    await use('A', 17).waitFor({ state: 'visible' });
  };
  const details = () =>
    page
      .locator('details')
      .filter({ has: page.getByText('Item 1 specifications and components', { exact: true }) });
  const openDetails = async () => {
    if (!(await details().getAttribute('open'))) {
      const isOpen = await details().evaluate((el) => el.open);
      if (!isOpen) await details().locator('summary').click();
    }
  };
  const writeResponse = (method) =>
    page.waitForResponse(
      (response) =>
        response.request().method() === method &&
        /\/api\/sales-orders(?:\?|\/\d)/.test(response.url()),
    );
  const noSelectedPhoto = async () => {
    await page
      .getByRole('figure', { name: 'Selected Design Book image', exact: true })
      .getByText('No image is stored for this design.', { exact: true })
      .waitFor();
    assert.equal(
      await page.getByRole('img', { name: 'Design SAME-F1 from F1 ALBUM A', exact: true }).count(),
      0,
      'Source A photo must disappear immediately after selecting blank source B',
    );
    assert.equal(await page.getByTestId('sales-order-image-preview').count(), 0);
  };
  const assertBlankSourceEvent = (line) => {
    assert.equal(line.designImageId, '', 'Source blank image must remain explicit in the request');
    const selected = line.orderEdits.filter((event) => event.kind === 'design').at(-1)?.source;
    assert.deepEqual(
      { ...selected, version: undefined },
      { prCode: 'F4', bookName: 'F1 ALBUM B', srNo: 23, oldSrNo: null, version: undefined },
    );
    assert.match(selected.version, /^[a-f\d]{64}$/);
  };
  const load = async (no) => {
    await page.getByLabel('Order number', { exact: true }).fill(no);
    const response = page.waitForResponse(
      (value) =>
        value.request().method() === 'GET' && value.url().includes(`/api/sales-orders/${no}?`),
    );
    await page.getByRole('button', { name: 'Load order', exact: true }).click();
    const fetched = await response;
    assert.equal(fetched.status(), 200, await fetched.text());
    const body = await fetched.json();
    await page.getByText(`Editing order #${body.voucherNo}`, { exact: true }).waitFor();
    return body;
  };
  try {
    await page.goto('/txn/sales-order');
    await page.getByLabel('Configured book', { exact: true }).selectOption(coBook);
    await page.getByRole('button', { name: 'New order', exact: true }).click();
    await page.getByLabel('Item code 1', { exact: true }).fill('SDF1');
    await page.getByLabel('Design item 1', { exact: true }).fill('MANUAL');
    await page.getByLabel('Gross weight item 1', { exact: true }).fill('10');
    await page.getByLabel('Net weight item 1', { exact: true }).fill('9');
    await page.getByLabel('Touch item 1', { exact: true }).fill('80');
    await page.getByLabel('Rate item 1', { exact: true }).fill('100');
    await page.getByLabel('Labour rate item 1', { exact: true }).fill('10');
    await page.getByLabel('Remark item 1', { exact: true }).click();
    await openDetails();
    await details().getByLabel('Size', { exact: true }).fill('MANUAL SIZE');
    await details().getByLabel('Karigar', { exact: true }).fill('K00');
    await details().getByLabel('Wastage %', { exact: true }).fill('1');
    await details().locator('table tbody tr').first().locator('input').first().fill('STF1');
    await details().getByLabel('Pcs row 1', { exact: true }).fill('2');
    await details().getByLabel('PcsWt row 1', { exact: true }).fill('0.125');
    await details().getByLabel('Weight row 1', { exact: true }).fill('0.25');
    await details().getByLabel('ItAmt row 1', { exact: true }).fill('3.25');
    await open();
    assert.equal(await dialog().locator('tbody tr').count(), 2);
    assert.equal(await dialog().getByText('WRONG-PRODUCT', { exact: true }).count(), 0);
    assert.equal(await dialog().getByText('WRONG-COMPANY', { exact: true }).count(), 0);
    assert.equal(
      await dialog().getByRole('columnheader', { name: 'Product', exact: true }).count(),
      1,
    );
    checks.push(
      'F1 lists exact item-product/company sources with duplicate labels and full desktop display columns',
    );
    for (let i = 0; i < 20; i++) {
      await page.keyboard.press('Tab');
      assert(await dialog().evaluate((el) => el.contains(document.activeElement)));
    }
    for (let i = 0; i < 20; i++) {
      await page.keyboard.press('Shift+Tab');
      assert(await dialog().evaluate((el) => el.contains(document.activeElement)));
    }
    await page.keyboard.press('Escape');
    await focusDesign();
    await value('Design item 1', 'MANUAL');
    await value('Touch item 1', '80');
    checks.push(
      'Native modal contains keyboard focus; Escape cancels without changing the draft and restores Design focus',
    );
    await open();
    await dialog().getByLabel('Search designs', { exact: true }).fill('F1 ALBUM B');
    await dialog().getByRole('button', { name: 'Search', exact: true }).click();
    await use('B', 23).waitFor();
    await eventually(
      async () => (await dialog().locator('tbody tr').count()) === 1,
      'Search selects exact album',
    );
    await dialog()
      .getByRole('button', { name: 'Close Design Book selection', exact: true })
      .click();
    await focusDesign();
    checks.push(
      'Search distinguishes duplicate design numbers by album and cancellation remains lossless',
    );
    await page.getByLabel('Gross weight item 1', { exact: true }).fill('invalid weight');
    await open();
    await dialog()
      .getByRole('button', { name: 'Preview SAME-F1 from F1 ALBUM A, serial 17', exact: true })
      .click();
    await dialog()
      .getByRole('img', { name: 'Design SAME-F1 from F1 ALBUM A', exact: true })
      .waitFor();
    if (checkpoint) await checkpoint('sales-design-picker-round4', page);
    await use('A', 17).click();
    await focusDesign();
    await value('Design item 1', 'SAME-F1');
    await value('Gross weight item 1', 'invalid weight');
    await value('Net weight item 1', '9');
    await value('Touch item 1', '91.63');
    await value('Labour rate item 1', '10');
    await openDetails();
    await value('Wastage %', '2.35');
    await value('Labour %', '5.56');
    await value('Size', '12');
    await value('Karigar', 'K01');
    await value('PcsWt row 1', '0.125');
    await value('ItAmt row 1', '3.25');
    assert.equal(errors.length, 0, errors.join('\n'));
    checks.push(
      'Selection preserves invalid unrelated draft and components while copying only source-defined new-row cells',
    );
    await page.getByRole('img', { name: 'Design SAME-F1 from F1 ALBUM A', exact: true }).waitFor();
    checks.push(
      'Validated Design photo previews both inside picker and immediately on the unsaved order row',
    );
    await page.getByLabel('Gross weight item 1', { exact: true }).fill('10');
    await open();
    await use('B', 23).click();
    await value('Touch item 1', '91.63');
    await value('Wastage %', '2.35');
    await value('Labour %', '5.56');
    await value('Labour rate item 1', '55.50');
    await value('Design Image', '');
    await noSelectedPhoto();
    checks.push(
      'Zero source defaults retain manual numerics; source percentage zero permits rate copy and NULL source image clears the immediate preview',
    );
    await open();
    await use('A', 17).click();
    await page.getByLabel('Touch item 1', { exact: true }).fill('88.88');
    await page.getByLabel('Order date', { exact: true }).fill('2024-07-10');
    await page.getByLabel('Customer account', { exact: true }).fill('SDF1CUS');
    const post = writeResponse('POST');
    await page.getByRole('button', { name: 'Save Sales Order', exact: true }).click();
    const created = await post;
    assert.equal(created.status(), 201, await created.text());
    const posted = created.request().postDataJSON();
    assert(
      posted.lines[0].orderEdits.some(
        (event) =>
          event.kind === 'design' && event.source.srNo === 17 && event.source.oldSrNo === 42,
      ),
    );
    const voucherNo = String((await created.json()).vchNo);
    const saved = await load(voucherNo);
    assert.equal(Number(saved.lines[0].touch), 88.88);
    assert.equal(Number(saved.lines[0].grossWt), 10);
    assert.equal(saved.lines[0].designImageId, 'F1-A-IMAGE');
    assert.equal(saved.lines[0].components.length, 1);
    assert.equal(Number(saved.lines[0].components[0].pcsWt), 0.125);
    await page.getByTestId('sales-order-image-preview').waitFor();
    checks.push(
      'Actual POST replays selected saved sources and later manual edit; reopening preserves parent/components and linked image',
    );
    await openDetails();
    const numericLabels = ['Touch item 1', 'Labour rate item 1', 'Wastage %', 'Labour %'];
    const priorValues = await Promise.all(
      numericLabels.map((label) => page.getByLabel(label, { exact: true }).inputValue()),
    );
    await open();
    await use('B', 23).click();
    assert.deepEqual(
      await Promise.all(
        numericLabels.map((label) => page.getByLabel(label, { exact: true }).inputValue()),
      ),
      priorValues,
    );
    await value('Size', '14');
    await value('Karigar', 'K02');
    await value('PcsWt row 1', '0.125');
    await value('Design Image', '');
    await noSelectedPhoto();
    const put = writeResponse('PUT');
    await page.getByRole('button', { name: 'Update Sales Order', exact: true }).click();
    const updated = await put;
    assert.equal(updated.status(), 200, await updated.text());
    assertBlankSourceEvent(updated.request().postDataJSON().lines[0]);
    const reopened = await load(voucherNo);
    for (const field of [
      'srNo',
      'oldSrNo',
      'grossWt',
      'netWt',
      'touch',
      'westPct',
      'labourPct',
      'labourRate',
      'labourAmount',
      'itemAmount',
      'lineNetAmount',
      'lineTotalAmount',
      'fineWeight',
      'pcs',
      'rate',
      'otherAmount',
      'mrp',
      'tagCost',
    ])
      assert.deepEqual(
        reopened.lines[0][field],
        saved.lines[0][field],
        `Saved E selection preserves ${field}`,
      );
    assert.deepEqual(reopened.lines[0].components, saved.lines[0].components);
    assert.equal(reopened.lines[0].designImageId, '');
    await page.getByTestId('sales-order-image-empty').waitFor();
    assert.equal(await page.getByTestId('sales-order-image-preview').count(), 0);
    if (checkpoint) await checkpoint('sales-design-blank-existing-round4', page);
    checks.push(
      'Actual PUT treats loaded parent as E: source NULL image persists as empty string, old photo disappears, numeric caches and parent/component identities stay unchanged',
    );
    await openDetails();
    await page.getByLabel('Design item 1', { exact: true }).fill('');
    await value('Design Image', 'N');
    await value('Size', '14');
    await value('Karigar', 'K02');
    assert.deepEqual(
      await Promise.all(
        numericLabels.map((label) => page.getByLabel(label, { exact: true }).inputValue()),
      ),
      priorValues,
    );
    checks.push(
      'Explicit clear resets only Design and image N while retaining size, karigar and numerics',
    );
    if (checkpoint) await checkpoint('sales-design-loaded-round4', page);
    await page.getByRole('button', { name: 'New order', exact: true }).click();
    await page.getByLabel('Order date', { exact: true }).fill('2024-07-10');
    await page.getByLabel('Customer account', { exact: true }).fill('SDF1CUS');
    await page.getByLabel('Item code 1', { exact: true }).fill('SDF1');
    await page.getByLabel('Gross weight item 1', { exact: true }).fill('4');
    await page.getByLabel('Net weight item 1', { exact: true }).fill('3');
    await page.getByLabel('Touch item 1', { exact: true }).fill('80');
    await page.getByLabel('Rate item 1', { exact: true }).fill('100');
    await page.getByLabel('Labour rate item 1', { exact: true }).fill('10');
    await page.getByLabel('Remark item 1', { exact: true }).click();
    await openDetails();
    await details().locator('table tbody tr').first().locator('input').first().fill('STF1');
    await details().getByLabel('Pcs row 1', { exact: true }).fill('2');
    await details().getByLabel('PcsWt row 1', { exact: true }).fill('0.125');
    await details().getByLabel('Weight row 1', { exact: true }).fill('0.25');
    await details().getByLabel('ItAmt row 1', { exact: true }).fill('3.25');
    await open();
    await use('A', 17).click();
    await page.getByRole('img', { name: 'Design SAME-F1 from F1 ALBUM A', exact: true }).waitFor();
    await open();
    await use('B', 23).click();
    await value('Design Image', '');
    await noSelectedPhoto();
    const blankPost = writeResponse('POST');
    await page.getByRole('button', { name: 'Save Sales Order', exact: true }).click();
    const blankCreated = await blankPost;
    assert.equal(blankCreated.status(), 201, await blankCreated.text());
    const blankRequest = blankCreated.request().postDataJSON().lines[0];
    assertBlankSourceEvent(blankRequest);
    const blankVoucherNo = String((await blankCreated.json()).vchNo);
    const blankSaved = await load(blankVoucherNo);
    const blankLine = blankSaved.lines[0];
    assert.equal(blankLine.designImageId, '', 'Persisted source blank must not become NULL or N');
    assert.equal(blankLine.designNo, 'SAME-F1');
    assert.equal(blankLine.itmSize, '14');
    assert.equal(blankLine.karigarName, 'K02');
    assert.equal(String(blankLine.srNo), String(blankRequest.srNo));
    assert.equal(Number(blankLine.grossWt), 4, 'Source gross777.777 is never copied');
    assert.equal(Number(blankLine.netWt), 3);
    assert.equal(blankLine.components.length, 1);
    for (const field of ['isrNo', 'itCode', 'pcs', 'pcsWt', 'grossWt', 'amount']) {
      assert.deepEqual(
        String(blankLine.components[0][field] ?? ''),
        String(blankRequest.components[0][field] ?? ''),
        `New blank-source selection preserves component ${field}`,
      );
    }
    await page.getByTestId('sales-order-image-empty').waitFor();
    assert.equal(await page.getByTestId('sales-order-image-preview').count(), 0);
    if (checkpoint) await checkpoint('sales-design-blank-new-round4', page);
    checks.push(
      'Actual new-row POST replaces selected photo with explicit source blank, reopens as empty string without fallback, and preserves parent/component identities and entered weights',
    );
    await page.getByRole('button', { name: 'New order', exact: true }).click();
    assert.equal(errors.length, 0, errors.join('\n'));
    checks.push('Complete picker/create/edit/clear workflow has no unhandled browser errors');
    return { voucherNo, blankVoucherNo, checks };
  } finally {
    page.off('pageerror', onError);
  }
}
