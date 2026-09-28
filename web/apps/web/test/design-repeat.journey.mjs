import assert from 'node:assert/strict';

/** Run only after existing Design journeys, then cleanup immediately: COL_MAST belongs to the
 * synthetic company, and its temporary labels/repeat flags must not affect other workflows. */
export async function seedDesignRepeat(sql) {
  await cleanupDesignRepeat(sql);
  await sql(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","CON_PRC","OTH_RATE_TYPE","OTH_RATE") VALUES($1,'01','REPF','Repeat fixed amount stone','S',0.2,'F',77.25)`,
  );
  for (const [book, name, label, visible, repeat] of [
    ['DESIGN DETL', 'Style', 'Style', 'Y', 'Y'],
    ['DESIGN DETL', 'GrWt', 'Gross', 'Y', 'Y'],
    ['DESIGN DETL', 'TagCost', 'Tag Cost', 'N', 'Y'],
    ['TAG_IDTL', 'ItCode', 'Item', 'Y', 'Y'],
    ['TAG_IDTL', 'PcsWt', 'Piece Weight', 'Y', 'Y'],
    ['TAG_IDTL', 'ItAmt', 'Item Amount', 'Y', 'Y'],
    ['TAG_IDTL', 'KrLs%', 'Karigar Less %', 'N', 'N'],
  ])
    await sql(
      `INSERT INTO "COL_MAST"(tenant_id,"CO_CODE","BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO","COL_RPT") VALUES($1,'01',$2,$3,$4,$5,$6)`,
      book,
      name,
      label,
      visible,
      repeat,
    );
  await sql(
    `INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","OLD_SRNO","DESIGN_NO","ITM_STYLE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_TOUCH","ITM_FINE","ITM_RATE","ITM_AMT","LBR_TYPE","TAG_COST","DESIGN_IMG_ID") VALUES($1,'01','REPEAT WEB','01',17,42,'IMPORTED','WIRE',1,10,0,7,0,3.333,0,91.17,'N',71.23,'repeat-saved-image')`,
  );
  await sql(
    `INSERT INTO "DESIGN_IDTL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","ISR_NO","DESIGN_NO","IT_CODE","IT_PCS","IT_PCS_WT","IT_GWT","IT_RATE","IT_AMT","IT_NET_AMT") VALUES($1,'01','REPEAT WEB','01',17,3,'IMPORTED','STONE',1,0.125,0,0,3,3),($1,'01','REPEAT WEB','01',17,9,'IMPORTED','STONE',0,0.251,0,0,17.29,55.37)`,
  );
}
export async function cleanupDesignRepeat(sql) {
  await sql(
    `DELETE FROM "COL_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND (("BOOK_NAME"='DESIGN DETL' AND "COL_NAME" IN ('Style','GrWt','TagCost')) OR ("BOOK_NAME"='TAG_IDTL' AND "COL_NAME" IN ('ItCode','PcsWt','ItAmt','KrLs%')))`,
  );
  for (const table of ['DESIGN_IDTL', 'DESIGN_DETL'])
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME" IN ('REPEAT WEB','REPEAT FIX')`,
    );
  await sql(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"='REPF'`);
}

export async function exerciseDesignRepeat(page, { checkpoint } = {}) {
  const pageErrors = [];
  const onError = (error) => pageErrors.push(error.message);
  page.on('pageerror', onError);
  const field = (label, index = 1, child = false) =>
    page.getByLabel(`${label} ${child ? 'component' : 'design'} ${index}`, { exact: true });
  const eventually = async (fn, message) => {
    for (let attempt = 0; attempt < 80; attempt++) {
      if (await fn()) return;
      await page.waitForTimeout(50);
    }
    assert(await fn(), message);
  };
  const value = (label, expected, index = 1, child = false) =>
    eventually(
      async () => (await field(label, index, child).inputValue()) === expected,
      `${label} expected ${expected}`,
    );
  const focused = (locator) =>
    eventually(
      () => locator.evaluate((element) => document.activeElement === element),
      'Expected source-defined focus',
    );
  const visibleToolbars = async () => {
    for (const kind of ['parent', 'component']) {
      const toolbar = page.locator(`[data-design-toolbar="${kind}"]`);
      const bounds = await toolbar.evaluate((element) => {
        const panel = element.parentElement.getBoundingClientRect();
        return {
          panelLeft: panel.left,
          panelRight: panel.right,
          children: [...element.children]
            .filter((child) => child.textContent.trim())
            .map((child) => {
              const rect = child.getBoundingClientRect();
              return { left: rect.left, right: rect.right };
            }),
        };
      });
      assert(
        bounds.children.every(
          (child) => child.left >= bounds.panelLeft && child.right <= bounds.panelRight,
        ),
        `${kind} context and actions remain visible after grid focus scroll`,
      );
    }
  };
  const commit = async (label, entered, index = 1, child = false) => {
    await field(label, index, child).fill(entered);
    await field(label, index, child).press('Tab');
  };
  const read = async (bookName) => {
    const response = await page.request.get(
      `/api/masters/design-book?bookName=${encodeURIComponent(bookName)}&prCode=01`,
    );
    assert.equal(response.status(), 200, await response.text());
    return response.json();
  };
  const load = async (bookName) => {
    await page.goto('/masters/design-book');
    await page.getByLabel('Book Name', { exact: true }).fill(bookName);
    await page.getByPlaceholder('search products… (F1)', { exact: true }).fill('01');
    await page.getByRole('button', { name: 'Load', exact: true }).click();
    await page
      .getByRole('status')
      .filter({ hasText: /Loaded 1 designs|This book is empty/ })
      .waitFor();
  };
  const save = async (method, count) => {
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
      .filter({ hasText: `Saved and reopened ${count} designs with their components.` })
      .waitFor();
    return response.request().postDataJSON();
  };
  const removeBook = async () => {
    await page.getByRole('button', { name: 'Delete Book', exact: true }).click();
    const [response] = await Promise.all([
      page.waitForResponse(
        (response) =>
          new URL(response.url()).pathname === '/api/masters/design-book' &&
          response.request().method() === 'DELETE',
      ),
      page.getByRole('button', { name: 'Confirm Delete Book', exact: true }).click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
  };

  await load('REPEAT WEB');
  const imported = await read('REPEAT WEB');
  await value('Sr', '17');
  await value('Original Sr', '42');
  assert.equal(await field('Tag Cost').count(), 0, 'Configured hidden field');
  await field('Gross').press('Enter');
  await focused(field('Item', 2, true));
  await value('Sr', '9', 2, true);
  await field('Net Amount', 2, true).press('Enter');
  await focused(field('Item', 3, true));
  await value('Sr', '10', 3, true);
  await value('Item', 'STONE', 3, true);
  await value('Piece Weight', '0.251', 3, true);
  await value('Item Amount', '17.29', 3, true);
  await value('Net Amount', '', 3, true);
  const parentAggregate = await field('Other Amount').inputValue();
  await field('Item', 3, true).press('Control+d');
  await page.getByRole('alertdialog', { name: 'Remove design row' }).waitFor();
  await page.getByRole('button', { name: 'Keep Row', exact: true }).click();
  await value('Sr', '10', 3, true);
  await field('Item', 3, true).press('Control+d');
  await page.getByRole('button', { name: 'Confirm Remove Row', exact: true }).click();
  await eventually(
    async () => (await field('Sr', 3, true).count()) === 0,
    'Removed only the confirmed child',
  );
  await page.getByRole('button', { name: '+ Add Component', exact: true }).click();
  await value('Sr', '11', 3, true);
  await value('Piece Weight', '0.251', 3, true);
  await value('Other Amount', parentAggregate);

  await page.getByRole('button', { name: '+ Add Design', exact: true }).click();
  await focused(field('Page No', 2));
  await value('Sr', '18', 2);
  await value('Original Sr', '18', 2);
  await value('Style', 'WIRE', 2);
  await value('Gross', '10', 2);
  await value('Net', '', 2);
  await commit('Design No', 'REPEATED', 2);
  await field('Gross', 2).fill('invalid');
  await field('Gross', 2).press('Enter');
  await focused(field('Gross', 2));
  await value('Gross', 'invalid', 2);
  await page.getByRole('status').filter({ hasText: 'finite' }).waitFor();
  await page.getByRole('button', { name: '+ Add Component', exact: true }).click();
  await value('Gross', 'invalid', 2);
  assert.equal(await field('Item', 1, true).count(), 0, 'Invalid draft must not allocate a child');
  await field('Gross', 2).fill('10');
  await field('Gross', 2).press('Enter');
  await focused(field('Item', 1, true));
  await field('Item', 1, true).press('Enter');
  await focused(field('Other Wt', 2));
  assert.equal(
    await field('Item', 1, true).count(),
    0,
    'Blank temporary item exits without a saved child',
  );
  await save('PUT', 2);
  const saved = await read('REPEAT WEB');
  assert.deepEqual(
    saved.map((row) => row.SR_NO),
    [17, 18],
  );
  assert.equal(saved[0].OLD_SRNO, 42);
  assert.equal(saved[0].DESIGN_IMG_ID, imported[0].DESIGN_IMG_ID);
  assert.deepEqual(
    saved[0].components.map((row) => row.ISR_NO),
    [3, 9, 11],
  );
  assert.equal(Number(saved[1].TAG_COST), 71.23, 'Hidden configured repeat is persisted');
  assert.deepEqual(saved[1].components, []);
  assert.notEqual(saved[1].DESIGN_IMG_ID, saved[0].DESIGN_IMG_ID);
  await field('Page No', 2).focus();
  await field('Page No', 1).focus();
  const unchanged = await save('PUT', 2);
  assert(
    unchanged.lines.every((line) => !line.calculationEvents),
    'Focus/unchanged save must not create calculation events',
  );
  assert.deepEqual(await read('REPEAT WEB'), saved);
  await visibleToolbars();
  if (checkpoint) await checkpoint('design-repeat-identities-round3', page);
  await removeBook();

  await load('REPEAT FIX');
  await commit('Design No', 'FIXED');
  await field('Gross').fill('1');
  await field('Gross').press('Enter');
  await focused(field('Item', 1, true));
  await field('Item', 1, true).fill('REPF');
  await field('Item', 1, true).press('Enter');
  await focused(field('Pcs', 1, true));
  await value('Net Amount', '77.25', 1, true);
  await commit('Pcs', '0', 1, true);
  await commit('Customer Weight', '0', 1, true);
  await commit('Net Amount', '0', 1, true);
  await field('Customer Weight', 1, true).fill('2');
  await field('Customer Weight', 1, true).press('Enter');
  await focused(field('Conversion', 1, true));
  await value('Customer Weight', '2', 1, true);
  await value('Rate', '', 1, true);
  await value('Net Amount', '77.25', 1, true);
  await save('POST', 1);
  const fixed = await read('REPEAT FIX');
  assert.equal(Number(fixed[0].components[0].IT_RATE), 0);
  assert.equal(Number(fixed[0].components[0].IT_NET_AMT), 77.25);
  await field('Net Amount', 1, true).focus();
  await visibleToolbars();
  if (checkpoint) await checkpoint('design-weight-enter-round3', page);
  await removeBook();
  assert.deepEqual(pageErrors, []);
  page.off('pageerror', onError);
  return {
    checks: [
      'configured parent and component repeat without calculation',
      'hidden repeated cost and independent parent image identity',
      'Gross Enter focuses the active parent last component',
      'Net Amount Enter appends with stable noncontiguous IDs',
      'Ctrl+D confirm/cancel and no deleted ID reuse',
      'invalid Enter retains focus/draft and blocks child allocation',
      'blank Item Enter returns to the invoking parent and discards only an untouched placeholder',
      'parent focus updates component context without mutating saved data',
      'complete unchanged save after focus preserves the saved snapshot',
      'item Enter waits for scoped defaults before moving focus',
      'Weight Enter uses prior zero weight and current scoped fixed amount',
      'cleared rate persists as source Conversion.Val zero',
      'real save/reopen/delete and no unhandled page errors',
      'parent and component context/actions remain visible when their grids scroll',
    ],
  };
}
