import assert from 'node:assert/strict';
import { request as requestFactory } from 'playwright';

export const salesReturnSavedFixture = {
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook: 'R61',
  otherBook: 'R62',
  voucherNo: '00001',
  taggedVoucherNo: '00002',
  original: { lcCode: '01', coYear: '2022-2023', coBook: 'O61', voucherNo: '00009' },
};

export const salesReturnSavedFixtureTables = [
  'SL_DETL_RTN',
  'BAR_IDTL',
  'BAR_DETL',
  'BAR_DATA',
  'MAIN_STOCK',
  'BILL_OS_DATA',
];
const snapshotTables = [
  ...salesReturnSavedFixtureTables,
  'SL_IDTL',
  'SL_DETL',
  'SL_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'TEMP_BOOK_DATA',
  'BOOK_DATA',
];

/** The runner supplies tenant as $1. Cleanup is restricted to this synthetic fixture. */
export async function cleanupSalesReturnSaved(sql) {
  for (const table of snapshotTables)
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK" IN ('R61','R62','O61')`,
    );
  await sql(`DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"='R6CUS'`);
}

/** Imported saved vectors; this fixture does not exercise or certify return creation/admission. */
export async function seedSalesReturnSaved(sql) {
  await cleanupSalesReturnSaved(sql);
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
    VALUES($1,'01','01','R61','Saved incoming return','SRTN','SALES RETURNE','I','Y','SL_DATA','SL_DETL_RTN'),
          ($1,'01','01','R62','Other saved return book','SRTN','SALES RETURNE','I','Y','SL_DATA','SL_DETL_RTN'),
          ($1,'01','01','O61','Historical source sale','SALE','SALES','O','Y','SL_DATA','SL_DETL')`);
  await sql(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME") VALUES($1,'01','R6CUS','Saved return customer')`,
  );
  await sql(`INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","HD_VCH_NO","AC_CODE","AC_NAME","BILL_NO","ISU_LC_CODE","ISU_YRCD","ISU_DBCD","ISU_NO","RTN_NET_AMT","RTN_TOT_AMT","RTN_BILL_OS","NET_AMT","TOT_AMT","TAX_AMT","CASH_AMT","UPI_AMT","ADD1","ADD2","ADD3","VCH_DESC","MAIN_USER","EMP_CODE")
    VALUES($1,'01','01','2024-2025','R61','00001','2024-07-11','2024-07-11 12:13:14.123456','00061','R6CUS','Saved return snapshot','', '01','2022-2023','O61','00009',1234.56,1250.75,222.25,NULL,0,16.19,0,NULL,NULL,'','  keep spaces  ','Imported return header','legacy-r6',NULL),
          ($1,'01','01','2024-2025','R62','00001','2024-07-12','2024-07-12 14:15:16.654321','00062','R6CUS','Other book return snapshot','OTHER-BOOK','01','2023-2024','O61','00009',321.09,321.09,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,'Other configured book','legacy-r6',NULL),
          ($1,'01','01','2024-2025','R61','00002','2024-07-13','2024-07-13 16:17:18.234567','00063','R6CUS','Historical tagged return','', '01','2022-2023','O61','00009',999.99,999.99,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,'Read-only tagged import','legacy-r6',NULL),
          ($1,'01','01','2022-2023','O61','00009','2022-07-01','2022-07-01 08:09:10.112233','00064','R6CUS','Original historical sale','ORIGINAL-2022',NULL,NULL,NULL,NULL,NULL,NULL,NULL,2000.12,2010.12,10,0,NULL,NULL,NULL,NULL,'Exact source year','source-r6',NULL),
          ($1,'01','01','2023-2024','O61','00009','2023-07-01','2023-07-01 09:10:11.445566','00065','R6CUS','Different original year','OTHER-2023',NULL,NULL,NULL,NULL,NULL,NULL,NULL,3000.34,3010.34,10,0,NULL,NULL,NULL,NULL,'Source-year sentinel','source-r6',NULL)`);
  await sql(`INSERT INTO "SL_DETL_RTN"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_SRNO","TAG_SRNO","VCH_DATE","VCH_TIME","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","HD_VCH_NO","AC_CODE","IT_CODE","TAG_NO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","ITM_RATE","ITM_AMT","LBR_TYPE","LBR_RATE","LBR_PRC","LBR_AMT","NET_AMT","TOT_AMT","HM_ID","HM_ID2","HM_ID3","HM_ID4","HM_ID_WT","HM_ID2_WT","HM_ID3_WT","HM_ID4_WT","ITM_REMARK","DESIGN_IMG_ID","ITM_GHT_PRC","DISC_PRC","ITM_STYLE","ITM_LOT","MAIN_USER","EMP_CODE")
    VALUES($1,'01','01','2024-2025','R61','00001',17,31,417,117,'2024-07-11','2024-07-11 12:13:14.123456','I','P','SALES RETURNE','00061','R6CUS','GOLD','N',0,4.321,3.123,91.600,1.2345,NULL,9999999999999999.99,123.45,'N',77.37,NULL,17.19,140.64,141.64,'R6HM17',NULL,'','R6HM4',0.111,NULL,0,0.444,NULL,'N',2.3456,4.5678,'  STYLE  ','LOT-R6','legacy-r6',NULL),
          ($1,'01','01','2024-2025','R61','00001',42,58,842,158,'2024-07-11','2024-07-11 12:13:14.123456','I','P','SALES RETURNE','00061','R6CUS','GOLD','',2,8.765,7.654,75,0,5.741,7000,200.23,'P',10.25,0,20.50,220.73,221.73,'R6HM42','R6HM2',NULL,'',NULL,0.222,0.333,0,'','R6_IMAGE_HIDDEN',0,0,'','N','legacy-r6',NULL),
          ($1,'01','01','2024-2025','R62','00001',17,31,517,217,'2024-07-12','2024-07-12 14:15:16.654321','I','P','SALES RETURNE','00062','R6CUS','GOLD','N',1,2,2,91.6,0,1.832,7100,100,'N',10,0,10,110,110,'OTHER-HUID',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'Other book incoming row','N',0,0,NULL,NULL,'legacy-r6',NULL),
          ($1,'01','01','2024-2025','R61','00002',17,31,917,317,'2024-07-13','2024-07-13 16:17:18.234567','I','P','SALES RETURNE','00063','R6CUS','GOLD','R6-HIST-TAG',1,4.321,3.123,91.6,0,2.861,7100,990,'N',10,0,9.99,999.99,999.99,'TAGGED-HM',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'Tagged historical incoming','N',0,0,NULL,NULL,'legacy-r6',NULL)`);
  // Incoming source components are BAR_IDTL. SL_IDTL below is deliberately unrelated legacy data.
  await sql(`INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","TAG_NO","VCH_SRNO","IT_CODE","IT_PCS","IT_GWT","IT_LBR_AMT","KR_NET_AMT","DM_NAME","DM_REMARK")
    VALUES($1,'01','01','2024-2025','R61','00001',17,3,'2024-07-11','I','P','SALES RETURNE','N',417,'STONE',0,0.123,NULL,0,'Return ruby','  ruby  '),
          ($1,'01','01','2024-2025','R61','00001',17,9,'2024-07-11','I','P','SALES RETURNE','N',417,'STONE',2,0.234,20,29.17,'Return diamond','')`);
  await sql(`INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","ENTRY_TYPE","INOUT_TYPE","IT_CODE","DM_NAME","IT_PCS","IT_GWT","IT_LBR_AMT")
    VALUES($1,'01','01','2024-2025','R61','00001',99,8,'O','O','STONE','Unrelated legacy component',0,0.456,NULL)`);
  await sql(`INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","VCH_SRNO","VCH_DATE","INOUT_TYPE","ENTRY_TYPE","AC_CODE","IT_CODE","TAG_NO","ITM_GWT","NET_AMT","ITM_REMARK")
    VALUES($1,'01','01','2022-2023','O61','00009',31,31,301,'2022-07-01','O','O','R6CUS','GOLD','R6-HIST-TAG',4.321,2000.12,'Original sold instance301'),
          ($1,'01','01','2023-2024','O61','00009',58,58,580,'2023-07-01','O','O','R6CUS','GOLD','R6-HIST-TAG',8.765,3000.34,'Different original year instance580')`);
  await sql(`INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_SRNO","TAG_SRNO","IT_CODE","TAG_NO","HM_ID","ITM_REMARK","ITM_GWT")
    VALUES($1,'01','01','2022-2023','O61','00009',31,301,31,'GOLD','R6-HIST-TAG','ORIGINAL','Original instance untouched',4.321),
          ($1,'01','01','2024-2025','R61','00002',17,917,317,'GOLD','R6-HIST-TAG','TAGGED-HM','Admitted instance read-only',4.321)`);
  await sql(`INSERT INTO "BAR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","HD_VCH_NO","AC_CODE","VCH_DESC")
    VALUES($1,'01','01','2024-2025','R61','00002','2024-07-13','2024-07-13 16:17:18.234567','00063','R6CUS','Historical admitted header read-only')`);
  await sql(`INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_SRNO","IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","ITM_DESC")
    VALUES($1,'01','01','2024-2025','R61','00001',17,417,'GOLD','N','+',0,4.321,3.123,NULL,123.45,'Stock snapshot'),
          ($1,'01','01','2024-2025','R61','00002',17,917,'GOLD','R6-HIST-TAG','+',1,4.321,3.123,2.861,990,'Tagged stock snapshot')`);
  await sql(`INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","ENTRY_TIME","AC_CODE","LD_CODE","DR_AMT","CR_AMT","SIGN","IT_DESC")
    VALUES($1,'01','01','2024-2025','R61','00001','R6-RETURN-DR','2024-07-11','2024-07-11 12:13:14.123456','CASH','R6CUS',1250.75,0,'D','Ledger sentinel'),
          ($1,'01','01','2024-2025','R61','00001','R6-RETURN-CR','2024-07-11','2024-07-11 12:13:14.123456','R6CUS','CASH',0,1250.75,'C','Ledger sentinel')`);
  await sql(`INSERT INTO "BILL_OS_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TIME","AC_CODE","BILL_AMT","REC_AMT","KASAR_AMT","BILL_LC","BILL_YRCD","BILL_DBCD","BILL_NO")
    VALUES($1,'01','01','2024-2025','R61','00001',7,'2024-07-11','2024-07-11 12:13:14.123456','R6CUS',1250.75,1028.50,NULL,'01','2022-2023','O61','00009')`);
  await sql(`INSERT INTO "ROJ_MEL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","AC_CODE","DR_AMT","CR_AMT","ITM_GWT","ITM_NWT","IT_DESC")
    VALUES($1,'01','01','2024-2025','R61','00001','R6-ROJMEL','R6CUS',0,1250.75,4.321,3.123,'Rojmel sentinel')`);
  await sql(`INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
    VALUES($1,'01','01','R61','00003','SALES RETURNE'),($1,'01','01','R62','00002','SALES RETURNE')`);
}

/** Exact database strings including physical row IDs; JSON numbers never pass through JavaScript. */
export async function snapshotSalesReturnSaved(owner, tenantId) {
  return owner.$transaction(async (tx) => {
    const snapshot = {};
    for (const table of snapshotTables) {
      const rows = await tx.$queryRawUnsafe(
        `SELECT (SELECT jsonb_object_agg(key,value) FROM jsonb_each_text(to_jsonb(t))) raw
           FROM "${table}" t WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
            AND "CO_BOOK" IN ('R61','R62','O61') ORDER BY to_jsonb(t)::text`,
        tenantId,
      );
      snapshot[table] = rows.map((row) => row.raw);
    }
    return snapshot;
  });
}

function assertOnlyMetadataChanged(after, before, expectedChanges) {
  const expected = structuredClone(before);
  for (const change of expectedChanges) {
    const row = expected.SL_DETL_RTN.find(
      (candidate) =>
        candidate.CO_BOOK === 'R61' &&
        candidate.VCH_NO === '00001' &&
        candidate.SR_NO === change.srNo,
    );
    assert(row, `Expected exact incoming row ${change.srNo}`);
    Object.assign(row, change.raw);
  }
  // Sort by immutable row content apart from the two permitted text columns.
  const canonical = (value) =>
    Object.fromEntries(
      Object.entries(value).map(([table, rows]) => [
        table,
        [...rows].sort((a, b) =>
          JSON.stringify({ ...a, HM_ID: null, ITM_REMARK: null }).localeCompare(
            JSON.stringify({ ...b, HM_ID: null, ITM_REMARK: null }),
          ),
        ),
      ]),
    );
  assert.deepEqual(
    canonical(after),
    canonical(expected),
    'Metadata changes preserve exact numeric, hidden, source, child, stock, ledger, outstanding, counter and physical row identity values',
  );
}

/** Real Next/Fastify/PostgreSQL journey; independent client and owner snapshots, no HTTP mocks. */
export async function exerciseSalesReturnSaved(
  page,
  { checkpoint, snapshot, holdSalesReturnReads } = {},
) {
  assert.equal(typeof snapshot, 'function', 'Runner must supply the isolated raw DB snapshot');
  assert.equal(typeof holdSalesReturnReads, 'function', 'Runner must supply a real DB read hold');
  const fixture = salesReturnSavedFixture;
  const scope = {
    coCode: fixture.coCode,
    lcCode: fixture.lcCode,
    coYear: fixture.coYear,
    coBook: fixture.coBook,
  };
  const checks = [];
  const requests = [];
  const pageErrors = [];
  const onError = (error) => pageErrors.push(error.message);
  const onRequest = (request) => {
    if (new URL(request.url()).pathname.startsWith('/api/sales-returns/')) requests.push(request);
  };
  page.on('pageerror', onError);
  page.on('request', onRequest);
  const otherClient = await requestFactory.newContext({
    baseURL: new URL(page.url()).origin,
    storageState: await page.context().storageState(),
  });
  const query = (book = scope.coBook) => new URLSearchParams({ ...scope, coBook: book });
  const path = (voucherNo = fixture.voucherNo) => `/api/sales-returns/${voucherNo}/incoming`;
  const updatePath = `${path()}-metadata`;
  const panel = () => page.getByTestId('sale-return-saved');
  const book = () => page.getByTestId('sale-return-saved-book').getByLabel('Configured book');
  const huid = (srNo) => page.getByTestId(`sale-return-saved-huid-${srNo}`);
  const description = (srNo) => page.getByTestId(`sale-return-saved-description-${srNo}`);
  const loadedContext = () => page.getByTestId('sale-return-saved-context');
  const ready = () =>
    page.waitForFunction(() => {
      const field = document.querySelector('[data-testid="sale-return-saved-huid-17"]');
      return field && !field.disabled && !field.readOnly;
    });
  const responseFor = (method, endpoint, selectedBook = scope.coBook) =>
    page.waitForResponse(
      (response) =>
        response.request().method() === method &&
        new URL(response.url()).pathname === endpoint &&
        new URL(response.url()).searchParams.get('coBook') === selectedBook,
    );
  const read = async (selectedBook = scope.coBook, voucherNo = fixture.voucherNo) => {
    const response = await otherClient.get(`${path(voucherNo)}?${query(selectedBook)}`);
    assert.equal(response.status(), 200, await response.text());
    const value = await response.json();
    assert.match(value.version, /^[0-9a-f]{64}$/);
    for (const key of ['coCode', 'lcCode', 'coYear']) assert.equal(value.scope[key], scope[key]);
    assert.equal(value.scope.coBook, selectedBook);
    assert.equal(value.voucherNo, voucherNo);
    return value;
  };
  const chooseBook = async (selectedBook) => {
    await book().locator(`option[value="${selectedBook}"]`).waitFor({ state: 'attached' });
    await book().selectOption(selectedBook);
    // Observe the React scope commit; immediate Playwright counts can precede that commit.
    await loadedContext().waitFor({ state: 'detached' });
  };
  const load = async (selectedBook = scope.coBook, voucherNo = fixture.voucherNo) => {
    await page.getByTestId('sale-return-saved-voucher').fill(voucherNo);
    const [response] = await Promise.all([
      responseFor('GET', path(voucherNo), selectedBook),
      page.getByTestId('sale-return-saved-load').click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    const value = await response.json();
    await loadedContext().waitFor();
    assert((await loadedContext().innerText()).includes(selectedBook));
    assert((await loadedContext().innerText()).includes(voucherNo));
    return value;
  };
  const save = async (status = 200) => {
    const [response] = await Promise.all([
      responseFor('PUT', updatePath),
      page.getByTestId('sale-return-saved-save').click(),
    ]);
    assert.equal(response.status(), status, await response.text());
    const submitted = response.request().postDataJSON();
    assert.deepEqual(Object.keys(submitted).sort(), ['lines', 'version']);
    assert.match(submitted.version, /^[0-9a-f]{64}$/);
    return { submitted, value: await response.json() };
  };
  const settle = () =>
    page.evaluate(
      () => new Promise((resolve) => requestAnimationFrame(() => requestAnimationFrame(resolve))),
    );
  const assertEditableText = async (locator, expected) => {
    assert.equal(await locator.inputValue(), expected);
    assert.equal(await locator.evaluate((field) => field.disabled || field.readOnly), false);
  };
  try {
    await page.goto('/txn/sale-return');
    await page.getByRole('button', { name: 'Saved returns', exact: true }).click();
    await panel().waitFor();
    await chooseBook(scope.coBook);
    const options = await book()
      .locator('option')
      .evaluateAll((items) => items.map((item) => item.value));
    assert(options.includes('R61') && options.includes('R62'));
    assert(!options.includes('O61') && !options.includes('S41') && !options.includes('Z09'));
    const [recentResponse] = await Promise.all([
      responseFor('GET', '/api/sales-returns/incoming-recent'),
      page.getByTestId('sale-return-saved-browse').click(),
    ]);
    assert.equal(recentResponse.status(), 200, await recentResponse.text());
    const recent = await recentResponse.json();
    assert.deepEqual(recent.rows.map((row) => row.voucherNo).sort(), ['00001', '00002']);
    await page.getByTestId('sale-return-saved-recent').waitFor();
    checks.push('Configured SALES RETURNE books and fully scoped saved browse');

    const initial = await load();
    await ready();
    const before = await snapshot();
    for (const table of snapshotTables)
      assert(before[table].length > 0, `Preservation fixture has real ${table} rows`);
    assert.deepEqual(
      initial.lines.map((line) => line.identity.srNo),
      ['17', '42'],
    );
    assert.deepEqual(
      initial.lines.map((line) => line.identity.oldSrNo),
      ['31', '58'],
    );
    assert.deepEqual(
      initial.lines.map((line) => line.identity.vchSrno),
      ['417', '842'],
    );
    assert.deepEqual(
      initial.lines.map((line) => line.identity.tagSrNo),
      ['117', '158'],
    );
    assert.equal(initial.header.raw.ISU_YRCD, fixture.original.coYear);
    assert.equal(initial.header.raw.ISU_DBCD, fixture.original.coBook);
    assert.equal(initial.header.raw.ISU_NO, fixture.original.voucherNo);
    assert.match(initial.header.raw.VCH_TIME, /12:13:14\.123456$/);
    assert.equal(initial.header.raw.ADD1, null);
    assert.equal(initial.header.raw.ADD2, '');
    assert.equal(initial.header.raw.ADD3, '  keep spaces  ');
    assert.equal(initial.lines[0].raw.ITM_RATE, '9999999999999999.99');
    assert.equal(initial.lines[0].raw.ITM_PCS, '0.000');
    assert.equal(initial.lines[0].raw.ITM_REMARK, null);
    assert.equal(initial.lines[1].raw.ITM_REMARK, '');
    for (const line of initial.lines) {
      assert.equal(line.display.itemName, 'Gold Ring');
      assert.equal(line.display.itemNameReason, null);
      assert.equal(line.display.description, 'Gold Ring');
      assert.equal(
        await page.getByTestId(`sale-return-saved-item-name-reason-${line.identity.srNo}`).count(),
        0,
        'A uniquely resolved item must not display a missing/ambiguous master diagnostic',
      );
    }
    assert.equal(initial.header.raw.EMP_CODE, null);
    assert.equal(initial.header.display.employeeName, null);
    assert.equal(initial.header.display.employeeNameReason, null);
    assert.equal(
      await page.getByTestId('sale-return-saved-employee-name-reason').count(),
      0,
      'An absent saved employee code must not be reported as a missing employee master',
    );
    assert.equal(initial.lines[0].raw.HM_ID2, null);
    assert.equal(initial.lines[0].raw.HM_ID3, '');
    assert.equal(initial.lines[0].raw.HM_ID4, 'R6HM4');
    assert.equal(initial.lines[0].raw.HM_ID2_WT, null);
    assert.equal(initial.lines[0].raw.HM_ID3_WT, '0.000');
    assert.equal(initial.lines[1].raw.DESIGN_IMG_ID, 'R6_IMAGE_HIDDEN');
    assert.deepEqual(initial.related.tagComponents.map((child) => child.ISR_NO).sort(), ['3', '9']);
    assert.deepEqual(initial.related.tagComponents.map((child) => child.DM_NAME).sort(), [
      'Return diamond',
      'Return ruby',
    ]);
    await assertEditableText(huid('17'), 'R6HM17');
    await assertEditableText(description('17'), initial.lines[0].display.description);
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    assert.equal(initial.header.capabilities.employeeCode.allowed, false);
    assert.equal(
      await page
        .getByLabel('Saved return employee', { exact: true })
        .evaluate((field) => field.disabled || field.readOnly),
      true,
    );
    assert.equal(
      await panel()
        .getByRole('button', { name: /delete/i })
        .count(),
      0,
    );
    checks.push(
      'Exact saved identities, source year/book/voucher, raw nulls/blanks/decimals/microseconds, known item fallback without false missing-master diagnostics, hidden hallmark/image values and two incoming children',
    );

    await huid('17').fill('R6EDIT17');
    const firstSave = await save();
    assert.deepEqual(firstSave.submitted.lines, [
      { identity: initial.lines[0].identity, changes: { huid: 'R6EDIT17' } },
    ]);
    assert.notEqual(firstSave.value.version, initial.version);
    await ready();
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    const saved = await load();
    assert.equal(saved.lines[0].raw.HM_ID, 'R6EDIT17');
    assert.equal(
      saved.lines[0].raw.ITM_REMARK,
      null,
      'Display fallback must not overwrite raw NULL remark',
    );
    assertOnlyMetadataChanged(await snapshot(), before, [
      { srNo: '17', raw: { HM_ID: 'R6EDIT17' } },
    ]);
    await checkpoint?.('sales-return-saved-loaded-round6', page);
    const rawDetails = page.getByTestId('sale-return-saved-raw-17');
    await page.getByText('Exact saved row 17, image and hallmark details', { exact: true }).click();
    for (const [key, expected] of [
      ['ITM_RATE', '9999999999999999.99'],
      ['HM_ID2', 'NULL'],
      ['HM_ID3', '(empty)'],
      ['HM_ID4_WT', '0.444'],
    ]) {
      const row = rawDetails
        .getByRole('row')
        .filter({ has: page.getByRole('rowheader', { name: key, exact: true }) });
      assert.equal(await row.getByRole('cell').innerText(), expected);
    }
    await rawDetails
      .getByRole('rowheader', { name: 'HM_ID', exact: true })
      .scrollIntoViewIfNeeded();
    await checkpoint?.('sales-return-saved-hallmark-details-round6', page);
    await page.getByText('Exact saved row 17, image and hallmark details', { exact: true }).click();
    const related = page.getByTestId('sale-return-saved-related');
    await related.locator('summary').first().click();
    const components = page.getByTestId('sale-return-saved-related-tagComponents');
    assert.match(await components.innerText(), /saved row 17 \/ component 3/);
    assert.match(await components.innerText(), /saved row 17 \/ component 9/);
    await related.locator('summary').first().click();
    checks.push(
      'HUID-only real PUT and authoritative reopen preserve complete database write-set and unchanged NULL description',
    );

    const remoteBefore = await read();
    const remote = await otherClient.put(`${updatePath}?${query()}`, {
      data: {
        version: remoteBefore.version,
        lines: [{ identity: remoteBefore.lines[1].identity, changes: { huid: 'R6REMOTE' } }],
      },
    });
    assert.equal(remote.status(), 200, await remote.text());
    const remoteAfter = await remote.json();
    assert.notEqual(remoteAfter.version, remoteBefore.version);
    await description('17').fill('Keep my stale return draft');
    const stale = await save(409);
    assert.match(stale.value.error, /version-conflict|identity-conflict/);
    await page.getByTestId('sale-return-saved-conflict').waitFor();
    assert.match(
      await page.getByTestId('sale-return-saved-error').innerText(),
      /chang|reload|conflict|stale/i,
    );
    assert.equal(await description('17').inputValue(), 'Keep my stale return draft');
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    assert.deepEqual(
      await read(),
      remoteAfter,
      'Stale browser metadata cannot alter the other client observation',
    );
    await checkpoint?.('sales-return-saved-conflict-round6', page);
    checks.push(
      'Independent real HTTP edit causes409; readable conflict keeps browser draft and blocks automatic replay',
    );

    const mutationsBeforeReload = requests.filter((request) => request.method() === 'PUT').length;
    const reloadButton = page.getByTestId('sale-return-saved-reload');
    assert.match(
      await reloadButton.innerText(),
      /discard/i,
      'Reload explicitly announces draft discard',
    );
    const [reloadResponse] = await Promise.all([responseFor('GET', path()), reloadButton.click()]);
    assert.equal(reloadResponse.status(), 200, await reloadResponse.text());
    await ready();
    assert.equal(await description('17').inputValue(), initial.lines[0].display.description);
    assert.equal(await huid('42').inputValue(), 'R6REMOTE');
    assert.equal(
      requests.filter((request) => request.method() === 'PUT').length,
      mutationsBeforeReload,
    );
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    await description('17').fill('Browser description after review');
    const reviewed = await save();
    assert.equal(reviewed.submitted.version, remoteAfter.version);
    assert.deepEqual(reviewed.submitted.lines[0].changes, {
      description: 'Browser description after review',
    });
    const finalPrimary = await load();
    assert.equal(finalPrimary.lines[0].raw.ITM_REMARK, 'Browser description after review');
    const acceptedChanges = [
      { srNo: '17', raw: { HM_ID: 'R6EDIT17', ITM_REMARK: 'Browser description after review' } },
      { srNo: '42', raw: { HM_ID: 'R6REMOTE' } },
    ];
    assertOnlyMetadataChanged(await snapshot(), before, acceptedChanges);
    checks.push(
      'Explicit discard/reload only reads; deliberate revised save preserves all other raw rows and values',
    );

    await chooseBook(fixture.otherBook);
    assert.equal(await huid('17').count(), 0, 'Old saved actions are removed after book change');
    const otherBook = await load(fixture.otherBook);
    assert.equal(otherBook.lines[0].raw.HM_ID, 'OTHER-HUID');
    assert.equal(otherBook.header.raw.ISU_YRCD, '2023-2024');
    await chooseBook(scope.coBook);
    const tagged = await load(scope.coBook, fixture.taggedVoucherNo);
    assert.equal(tagged.lines[0].identity.vchSrno, '917');
    assert.equal(tagged.lines[0].identity.tagSrNo, '317');
    assert.equal(tagged.lines[0].identity.tagNo, 'R6-HIST-TAG');
    assert.equal(tagged.lines[0].capabilities.huid.allowed, false);
    assert.equal(tagged.lines[0].capabilities.description.allowed, false);
    assert(tagged.lines[0].capabilities.huid.reason);
    assert.equal(await huid('17').evaluate((field) => field.disabled || field.readOnly), true);
    assert.equal(
      await description('17').evaluate((field) => field.disabled || field.readOnly),
      true,
    );
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    await checkpoint?.('sales-return-saved-tagged-readonly-round6', page);
    checks.push(
      'Same voucher in another configured book stays isolated; historical admitted tag instance is visible with metadata writes explicitly denied',
    );

    await load();
    await ready();
    const delayedLoad = async (cancel) => {
      await page.getByTestId('sale-return-saved-load').scrollIntoViewIfNeeded();
      const release = await holdSalesReturnReads();
      let arrived = false;
      const lateResponse = responseFor('GET', path()).then((response) => {
        arrived = true;
        return response;
      });
      try {
        await Promise.all([
          page.waitForRequest(
            (request) => request.method() === 'GET' && new URL(request.url()).pathname === path(),
            { timeout: 2500 },
          ),
          page.getByTestId('sale-return-saved-load').click({ timeout: 1500 }),
        ]);
        assert.equal(arrived, false, 'Load is blocked by the real database table lock');
        if (cancel) {
          await page.getByTestId('sale-return-saved-discard').click({ timeout: 1500 });
        } else {
          await book().selectOption(fixture.otherBook, { timeout: 1500 });
          await loadedContext().waitFor({ state: 'detached', timeout: 1500 });
          await book().selectOption(scope.coBook, { timeout: 1500 });
        }
      } finally {
        await release();
      }
      const completed = await lateResponse;
      assert.equal(completed.status(), 200, await completed.text());
      await completed.finished();
      await settle();
      assert.equal(
        await loadedContext().count(),
        0,
        'A late observation cannot restore a discarded generation',
      );
      assert.equal(await huid('17').count(), 0);
      assert.equal(await page.getByTestId('sale-return-saved-save').count(), 0);
    };
    await delayedLoad(true);
    await load();
    await ready();
    await delayedLoad(false);
    await checkpoint?.('sales-return-saved-late-load-round6', page);
    checks.push('Real held database reads cannot revive cancelled or A→B→A obsolete observations');
    await load();
    await ready();
    assertOnlyMetadataChanged(await snapshot(), before, acceptedChanges);
    const width = await panel().evaluate((element) => ({
      right: element.getBoundingClientRect().right,
      viewport: innerWidth,
    }));
    assert(width.right <= width.viewport + 1, 'Saved grid stays inside the viewport');
    for (const request of requests) {
      const url = new URL(request.url());
      for (const key of ['coCode', 'lcCode', 'coYear'])
        assert.equal(url.searchParams.get(key), scope[key]);
      assert(['R61', 'R62'].includes(url.searchParams.get('coBook')));
      assert(
        ['GET', 'PUT'].includes(request.method()),
        'Saved slice never invokes legacy create/delete',
      );
      if (request.method() === 'PUT') {
        const body = request.postDataJSON();
        assert(!('tenantId' in body) && !('coBook' in body));
        assert.equal(url.pathname, updatePath);
        for (const line of body.lines) {
          assert.deepEqual(Object.keys(line).sort(), ['changes', 'identity']);
          assert(Object.keys(line.changes).every((key) => ['huid', 'description'].includes(key)));
          assert(['17', '42'].includes(line.identity.srNo));
        }
      }
    }
    assert.deepEqual(pageErrors, []);
    checks.push(
      'Every browser request carries exact scope; metadata bodies exclude numeric/source replacements; no page errors',
    );
    return {
      status: 'passed',
      scope,
      voucherNo: fixture.voucherNo,
      checks,
      browserRequests: requests.length,
      mockedResponses: 0,
      desktopAcceptance: false,
    };
  } finally {
    page.off('request', onRequest);
    page.off('pageerror', onError);
    await otherClient.dispose();
  }
}
