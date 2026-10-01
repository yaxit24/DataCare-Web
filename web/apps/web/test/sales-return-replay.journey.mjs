import assert from 'node:assert/strict';
import { request as requestFactory } from 'playwright';
import { expectRows } from './journeySql.mjs';

const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R91' };
const voucherNo = '00001';
const fieldId = (column) => `x13.primary-incoming.c${String(column).padStart(2, '0')}`;
const columns = [19, 20, 21, 23, 24, 25, 26, 27, 28, 36, 37, 38];
const loginName = 'r9-replay-view';
const businessTables = [
  'SL_DATA',
  'SL_DETL_RTN',
  'SL_DETL',
  'SL_IDTL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'REMARK_DATA',
  'SRNO_MAST',
  'TAG_SET',
  'TEMP_BOOK_DATA',
  'CO_SET',
  'CO_SET_NEW',
  'COL_MAST',
  'BOOK_DATA',
  'YEAR_MAST',
  'ITEM_MAST',
];
export const salesReturnReplayFixtureTables = ['SL_DETL_RTN'];
export async function cleanupSalesReturnReplay(sql) {
  for (const table of ['SL_DETL_RTN', 'SL_DATA', 'BOOK_DATA'])
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK" IN('R91','R92')`,
    );
  await sql(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"='R9G'`);
  await sql(
    `DELETE FROM "COL_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"='SALES RETURNE' AND "COL_NAME"='Rate'`,
  );
  await sql(`DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='r9-replay-view'`);
  await sql(`DELETE FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "LOGIN_NAME"='r9-replay-view'`);
}

/** Run after the fourteen earlier journeys. Explicit company settings are part of this synthetic preview fixture. */
export async function seedSalesReturnReplay(sql) {
  await cleanupSalesReturnReplay(sql);
  await expectRows(
    1,
    sql(
      `UPDATE "CO_SET" SET "SL_AMT_TYPE"='N',"LBR_ROF"=2,"LBR_RATE_GEN"='N',"ALL_ROF_REMOVE"='N',"LBR_TYPE"='N',"EMP_CODE_MANDATORY"='N',"LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    ),
    'company 01 CO_SET row',
  );
  await expectRows(
    1,
    sql(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,'01','N')
       ON CONFLICT (tenant_id,"CO_CODE") DO UPDATE SET "LBR_WITH_GHT"=EXCLUDED."LBR_WITH_GHT"`,
    ),
    'company 01 CO_SET_NEW row',
  );
  await sql(
    `INSERT INTO "COL_MAST"(tenant_id,"CO_CODE","BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO") VALUES($1,'01','SALES RETURNE','Rate','Preview rate','Y')`,
  );
  await sql(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","RATE_TYPE") VALUES($1,'01','R9G','Replay gold item','G','N')`,
  );
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL") VALUES
    ($1,'01','01','R91','Return preview book','SRTN','SALES RETURNE','I','Y','SL_DATA','SL_DETL_RTN'),
    ($1,'01','01','R92','Other return preview book','SRTN','SALES RETURNE','I','Y','SL_DATA','SL_DETL_RTN')`);
  await sql(`INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","USER_UPDATE","EMP_CODE","AC_CODE","AC_NAME","NET_AMT","TOT_AMT","RTN_NET_AMT","RTN_TOT_AMT") VALUES
    ($1,'01','01','2024-2025','R91','00001','2024-07-10','2024-07-10 12:34:56.123456','Y','','CASH','Preview customer',0,0,1100,1100),
    ($1,'01','01','2024-2025','R92','00001','2024-07-10','2024-07-10 12:34:56.123456','Y','','CASH','Other preview book',0,0,1100,1100),
    ($1,'01','01','2024-2025','R91','00002','2024-07-10','2024-07-10 12:34:56.123456','Y','','CASH','Tagged read-only preview',0,0,1000,1000),
    ($1,'01','01','2024-2025','R91','00003','2024-07-10','2024-07-10 12:34:56.123456','Y','','CASH','Large saved amount preview',0,0,1000,1000),
    ($1,'01','01','2024-2025','R91','00004','2024-07-10','2024-07-10 12:34:56.123456','Y','','CASH','Saved empty return',0,0,0,0)`);
  const numeric = [
    'ITM_PCS',
    'ITM_GWT',
    'ITM_OTH_WT',
    'ITM_NWT',
    'ITM_GHT_PRC',
    'ITM_GHT_WT',
    'ITM_TOUCH',
    'ITM_WEST_PRC',
    'ITM_FINE',
    'ITM_RATE',
    'ITM_AMT',
    'LBR_PRC',
    'LBR_RATE',
    'LBR_AMT',
    'DISC_PRC',
    'DISC_AMT',
    'OTH_AMT',
    'ITM_MRP',
    'TAG_LBR_PRC',
    'TAG_LBR_RATE',
    'TAG_LBR_AMT',
    'TAG_OTH_AMT',
    'TAG_COST',
    'TAG_MRP',
    'TOT_AMT',
    'TAX_PRC',
    'NET_AMT',
    'HM_ID_WT',
    'HM_ID2_WT',
    'HM_ID3_WT',
    'HM_ID4_WT',
  ];
  const zeroes = Object.fromEntries(numeric.map((key) => [key, '0']));
  for (const book of ['R91', 'R92'])
    for (const srNo of [17, 42]) {
      const values = {
        ...zeroes,
        CO_CODE: '01',
        LC_CODE: '01',
        CO_YEAR: '2024-2025',
        CO_BOOK: book,
        VCH_NO: '00001',
        SR_NO: String(srNo),
        OLD_SRNO: srNo === 17 ? '31' : '58',
        VCH_SRNO: String(500000 + srNo),
        TAG_SRNO: String(100 + srNo),
        VCH_DATE: '2024-07-10',
        VCH_TIME: '2024-07-10 12:34:56.123456',
        ENTRY_TYPE: 'P',
        INOUT_TYPE: 'I',
        IT_CODE: 'R9G',
        TAG_NO: 'N',
        RATE_TYPE: 'N',
        IT_TYPE: 'G',
        PR_CODE: '01',
        LBR_TYPE: 'N',
        LBR_CODE: '',
        TAG_LBR_CODE: '',
        APR_ISU: 'N',
        EMP_ISU: 'N',
        ITM_PCS: srNo === 17 ? '1' : '2',
        ITM_GWT: srNo === 17 ? '10' : '1',
        ITM_NWT: srNo === 17 ? '10' : '1',
        ITM_TOUCH: '100',
        ITM_FINE: srNo === 17 ? '10' : '1',
        ITM_RATE: '100',
        ITM_AMT: srNo === 17 ? '1000' : '100',
        TOT_AMT: srNo === 17 ? '1000' : '100',
        NET_AMT: srNo === 17 ? '1000' : '100',
        HM_ID: `R9-${srNo}`,
        ITM_REMARK: null,
        ITM_STYLE: '',
        ITM_SIZE: '',
        TBL_CODE: '',
        DESIGN_NO: '',
        KR_NAME: '',
        TAG_TYPE: '',
        HM_ID2: '',
        HM_ID3: '',
        HM_ID4: '',
        DESIGN_IMG_ID: '',
        DATA_TYPE: '',
      };
      const names = Object.keys(values)
        .map((key) => `"${key}"`)
        .join(',');
      await sql(
        `INSERT INTO "SL_DETL_RTN"(tenant_id,${names}) SELECT $1,${names} FROM jsonb_populate_record(NULL::"SL_DETL_RTN",$2::jsonb)`,
        JSON.stringify(values),
      );
      if (book === 'R91' && srNo === 17) {
        values.VCH_NO = '00002';
        values.TAG_NO = 'R9-TAG';
        await sql(
          `INSERT INTO "SL_DETL_RTN"(tenant_id,${names}) SELECT $1,${names} FROM jsonb_populate_record(NULL::"SL_DETL_RTN",$2::jsonb)`,
          JSON.stringify(values),
        );
        values.VCH_NO = '00003';
        values.TAG_NO = 'N';
        values.ITM_AMT = '9999999999999999.99';
        await sql(
          `INSERT INTO "SL_DETL_RTN"(tenant_id,${names}) SELECT $1,${names} FROM jsonb_populate_record(NULL::"SL_DETL_RTN",$2::jsonb)`,
          JSON.stringify(values),
        );
      }
    }
  await sql(`INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
    SELECT $1,'01','r9-replay-view',"LOGIN_PWD",'USER','N','N','N','N' FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LOGIN_NAME"='browser'`);
  await sql(
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES($1,'01','01','r9-replay-view','Sales','Sales Return','Y','N','N','N')`,
  );
}

/** Exact business values plus physical observations across both document and calculation dependencies. */
export async function snapshotSalesReturnReplay(owner, tenantId) {
  return owner.$transaction(async (tx) => {
    const snapshot = {};
    for (const table of businessTables)
      snapshot[table] = await tx.$queryRawUnsafe(
        `SELECT (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)) e) raw,t.xmin::text generation,t.ctid::text tuple
         FROM "${table}" t WHERE tenant_id=$1 ORDER BY to_jsonb(t)::text`,
        tenantId,
      );
    return snapshot;
  });
}

/** Real Next/Fastify/PostgreSQL; source metadata/configuration conflict actors are deliberate separate clients. */
export async function exerciseSalesReturnReplay(
  page,
  { checkpoint, snapshot, holdSalesReturnReads, password, tenantId = 'browser-parity' } = {},
) {
  assert.equal(typeof snapshot, 'function');
  assert.equal(typeof holdSalesReturnReads, 'function');
  assert.equal(typeof password, 'string');
  const checks = [],
    requests = [],
    errors = [],
    snapshotChecks = [];
  const origin = new URL(page.url()).origin;
  const other = await requestFactory.newContext({
    baseURL: origin,
    storageState: await page.context().storageState(),
  });
  let restricted;
  const onError = (error) => errors.push(error.message);
  const onRequest = (request) => {
    if (new URL(request.url()).pathname.includes('/incoming-replay')) requests.push(request);
  };
  page.on('pageerror', onError);
  page.on('request', onRequest);
  const path = (action = 'incoming', book = scope.coBook, voucher = voucherNo) =>
    `/api/sales-returns/${voucher}/${action}?${new URLSearchParams({ ...scope, coBook: book })}`;
  const responseFor = (method, action, target = page, book = scope.coBook, voucher = voucherNo) =>
    target.waitForResponse(
      (response) =>
        response.request().method() === method &&
        new URL(response.url()).pathname === `/api/sales-returns/${voucher}/${action}` &&
        new URL(response.url()).searchParams.get('coBook') === book,
    );
  const panel = (target = page) => target.getByTestId('sale-return-replay');
  const book = (target = page) =>
    target.getByTestId('sale-return-saved-book').getByLabel('Configured book');
  const field = () => page.getByTestId('sale-return-replay-field');
  const entry = () => page.getByTestId('sale-return-replay-entry');
  const commitButton = () => page.getByTestId('sale-return-replay-commit');
  const settle = (target = page) =>
    target.evaluate(
      () => new Promise((resolve) => requestAnimationFrame(() => requestAnimationFrame(resolve))),
    );
  const read = async (bookName = scope.coBook) => {
    const response = await other.get(path('incoming', bookName));
    assert.equal(response.status(), 200, await response.text());
    return response.json();
  };
  const load = async (target = page, bookName = scope.coBook, voucher = voucherNo) => {
    assert.equal(await book(target).inputValue(), bookName);
    await target.getByTestId('sale-return-saved-voucher').fill(voucher);
    const [response] = await Promise.all([
      responseFor('GET', 'incoming', target, bookName, voucher),
      target.getByTestId('sale-return-saved-load').click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    await target.getByTestId('sale-return-saved-context').waitFor();
    await settle(target);
    return response.json();
  };
  const open = async (target = page, bookName = scope.coBook, voucher = voucherNo) => {
    const [response] = await Promise.all([
      responseFor('GET', 'incoming-replay-state', target, bookName, voucher),
      target.getByTestId('sale-return-replay-open').click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    await target.getByTestId('sale-return-replay-row').waitFor();
    await settle(target);
    return response.json();
  };
  const commit = async (
    text,
    { column, enter = false, status = 200, voucher = voucherNo } = {},
  ) => {
    if (column !== undefined) await field().selectOption(fieldId(column));
    await entry().fill(text);
    const [response] = await Promise.all([
      responseFor('POST', 'incoming-replay', page, scope.coBook, voucher),
      enter ? entry().press('Enter') : commitButton().click(),
    ]);
    assert.equal(response.status(), status, await response.text());
    await settle();
    return { payload: response.request().postDataJSON(), data: await response.json() };
  };
  const chooseBook = async (value) => {
    await book().selectOption(value);
    await page.getByTestId('sale-return-saved-context').waitFor({ state: 'detached' });
    await settle();
    assert.equal(await book().inputValue(), value);
    assert.equal(await page.getByTestId('sale-return-saved-voucher').inputValue(), '');
  };
  const assertUnchanged = async (before, label) => {
    const after = await snapshot();
    assert.deepEqual(after, before, label);
    snapshotChecks.push({ label, tables: businessTables.length, unchanged: true });
  };
  try {
    await page.goto('/txn/sale-return');
    await page.getByRole('button', { name: 'Saved returns', exact: true }).click();
    await book().locator('option[value="R91"]').waitFor({ state: 'attached' });
    await chooseBook('R91');
    const saved = await load();
    const before = await snapshot();
    assert.deepEqual(
      saved.lines.map((line) => line.identity.srNo),
      ['17', '42'],
    );
    assert.deepEqual(
      saved.lines.map((line) => line.identity.oldSrNo),
      ['31', '58'],
    );
    const state = await open();
    assert.equal(state.documentVersion, saved.version);
    assert.equal(state.configurationVersion, state.configuration.version);
    assert.equal(state.capabilities.canSaveNumeric, false);
    assert.equal(state.rows[0].visible['19'], '100.00');
    assert.equal(state.rows[0].visible['20'], '1000.00');
    assert.deepEqual(state.rows[0].identity, saved.lines[0].identity);
    assert.equal(state.rows[0].raw.ITM_REMARK, null);
    assert.equal(state.rows[0].visible['3'], 'Replay gold item');
    checks.push(
      'trusted bootstrap matches full saved identity/version, exact raw fallback and unchanged no-event values',
    );

    assert.equal(await field().locator('option').count(), 12);
    assert.equal(
      await field()
        .locator(`option[value="${fieldId(19)}"]`)
        .textContent(),
      'Preview rate',
    );
    assert.deepEqual(
      await field()
        .locator('option')
        .evaluateAll((options) => options.map((option) => option.value)),
      columns.map(fieldId),
    );
    assert.equal(await book().isDisabled(), true);
    assert.equal(await page.getByTestId('sale-return-saved-load').isDisabled(), true);
    assert.equal(await page.getByTestId('sale-return-saved-huid-17').getAttribute('readonly'), '');
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    checks.push(
      'all12 stable field IDs use server captions while metadata, local book and document replacement are frozen',
    );

    const first = await commit('200', { column: 19 });
    assert.deepEqual(first.payload, {
      replayVersion: state.replayVersion,
      rowIdentity: state.rows[0].rowIdentity,
      events: [{ fieldId: fieldId(19), editorText: '200' }],
    });
    assert.equal(first.data.preview.visible['19'], '200.00');
    assert.equal(first.data.preview.visible['20'], '2000.00');
    assert.equal(first.data.preview.visible['38'], '2000.00');
    const second = await commit('200.00');
    assert.deepEqual(second.payload.events, [
      ...first.payload.events,
      { fieldId: fieldId(19), editorText: '200.00' },
    ]);
    assert.equal(second.data.events.length, 2);
    assert.equal(second.data.events[1].status, 'applied');
    checks.push(
      'each explicit completed field replays the entire ordered journal, retaining a repeated same-value event',
    );

    const requestCount = requests.filter((request) => request.method() === 'POST').length;
    await field().selectOption(fieldId(27));
    await entry().fill('bad');
    await commitButton().click();
    await page.getByTestId('sale-return-replay-error').waitFor();
    assert.equal(await entry().inputValue(), 'bad');
    assert.equal(requests.filter((request) => request.method() === 'POST').length, requestCount);
    assert.match(
      await page.getByTestId('sale-return-replay-status').textContent(),
      /^2 field changes/,
    );
    assert.equal(
      await page.getByTestId('sale-return-replay-value-38').locator('td').nth(1).textContent(),
      '2000.00',
    );
    checks.push(
      'invalid numeric draft is retained without dispatch, journal mutation or destruction of the prior preview',
    );

    const corrected = await commit('5', { enter: true });
    assert.equal(corrected.payload.events.length, 3);
    assert.equal(corrected.data.preview.visible['38'], '2005.00');
    await entry().press('Tab');
    await settle();
    assert.equal(
      requests.filter((request) => request.method() === 'POST').length,
      requestCount + 1,
    );
    const blank = await commit('', { column: 27 });
    assert.equal(blank.payload.events.at(-1).editorText, '');
    assert.equal(blank.data.preview.visible['27'], '0.00');
    assert.equal(blank.data.preview.visible['38'], '2000.00');
    assert.equal(blank.data.events.length, 4);
    checks.push(
      'Enter appends once, Tab/blur does not submit, and a deliberate blank commit retains original text with source zero semantics',
    );

    assert.match(
      await page.getByTestId('sale-return-replay-status').textContent(),
      /voucher, refund and accounting totals have not been recalculated/,
    );
    assert.equal(
      await panel()
        .getByRole('button', { name: /^(save|update|apply)/i })
        .count(),
      0,
    );
    assert.equal(
      (await page.getByTestId('sale-return-saved-amounts').textContent())
        .replace(/\s+/g, ' ')
        .trim(),
      `Saved incoming amount ${saved.header.raw.RTN_NET_AMT} · Saved outgoing amount ${saved.header.raw.NET_AMT}`,
    );
    await assertUnchanged(
      before,
      'initial, repeated, invalid, corrected and blank preview operations do not write any observed business/dependency table',
    );
    await page.getByTestId('sale-return-replay-value-38').scrollIntoViewIfNeeded();
    if (checkpoint) await checkpoint('sales-return-replay-ordered', page);
    checks.push(
      'row-only outputs and saved voucher amounts remain separate, with exact unchanged business-table snapshots',
    );

    await page.getByTestId('sale-return-replay-close').click();
    await settle();
    assert.equal(
      await page
        .getByTestId('sale-return-replay-open')
        .evaluate((button) => document.activeElement === button),
      true,
    );
    assert.equal(
      await page.getByTestId('sale-return-saved-huid-17').getAttribute('readonly'),
      null,
    );
    const secondState = await open();
    await page.getByTestId('sale-return-replay-row').selectOption(secondState.rows[1].rowIdentity);
    assert.match(
      await page.getByTestId('sale-return-replay-identity').textContent(),
      /Saved row 42.*Saved old row 58/,
    );
    assert.equal(
      await page.getByTestId('sale-return-replay-value-20').locator('td').nth(0).textContent(),
      '100.00',
    );
    await page.getByTestId('sale-return-replay-close').click();
    checks.push(
      'explicit close discards transient values and returns focus; selecting SR42 uses its own saved baseline and OLD58',
    );

    await open();
    await entry().fill('333');
    const current = await read();
    const changed = await other.put(path('incoming-metadata'), {
      data: {
        version: current.version,
        lines: [{ identity: current.lines[0].identity, changes: { huid: 'R9-OTHER' } }],
      },
    });
    assert.equal(changed.status(), 200, await changed.text());
    const afterExternalMetadata = await snapshot();
    await commit('333', { status: 409 });
    await page.getByTestId('sale-return-replay-conflict').waitFor();
    assert.equal(await entry().inputValue(), '333');
    assert.equal(await commitButton().isDisabled(), true);
    if (checkpoint) await checkpoint('sales-return-replay-conflict', page);
    const reload = responseFor('GET', 'incoming');
    await page.getByTestId('sale-return-replay-reload').click();
    assert.equal((await reload).status(), 200);
    await page.getByTestId('sale-return-replay-open').waitFor();
    await settle();
    assert.equal(await page.getByTestId('sale-return-saved-huid-17').inputValue(), 'R9-OTHER');
    const replayCount = requests.filter((request) => request.method() === 'POST').length;
    const fresh = await open();
    assert.equal(requests.filter((request) => request.method() === 'POST').length, replayCount);
    assert.notEqual(fresh.replayVersion, state.replayVersion);
    const explicitRetry = await commit('333');
    assert.equal(explicitRetry.payload.events.length, 1);
    await assertUnchanged(
      afterExternalMetadata,
      'stale document rejection, deliberate saved reload and explicit fresh preview make no business writes',
    );
    checks.push(
      'a real second-client saved change causes409, retains the draft and requires deliberate reload and explicit fresh replay',
    );

    await page.getByTestId('sale-return-replay-close').click();
    await open();
    const stylesScope = { coCode: scope.coCode, lcCode: scope.lcCode, coYear: scope.coYear };
    const stylesPath = `/api/masters/styles?${new URLSearchParams(stylesScope)}`;
    const settings = await other.get(`${stylesPath}&family=SALES%20RETURNE`);
    assert.equal(settings.status(), 200);
    const rate = (await settings.json()).find((row) => row.COL_NAME === 'Rate');
    assert(rate);
    const settingsWrite = await other.put(stylesPath, {
      data: {
        CO_CODE: '01',
        BOOK_NAME: 'SALES RETURNE',
        COL_NAME: 'Rate',
        version: rate._columnVersion,
        COL_NEW_NAME: 'Fresh preview rate',
      },
    });
    assert.equal(settingsWrite.status(), 200, await settingsWrite.text());
    const afterExternalConfiguration = await snapshot();
    await commit('222', { status: 409 });
    assert.equal(await entry().inputValue(), '222');
    const reloadConfig = responseFor('GET', 'incoming');
    await page.getByTestId('sale-return-replay-reload').click();
    assert.equal((await reloadConfig).status(), 200);
    await page.getByTestId('sale-return-replay-open').waitFor();
    await open();
    assert.equal(
      await field()
        .locator(`option[value="${fieldId(19)}"]`)
        .textContent(),
      'Fresh preview rate',
    );
    await assertUnchanged(
      afterExternalConfiguration,
      'stale configuration rejection and explicit observation refresh make no business writes',
    );
    checks.push(
      'a real second-client configuration change invalidates the composite token and refreshes captions only after explicit reload',
    );

    await page.getByTestId('sale-return-replay-close').click();
    const release = await holdSalesReturnReads();
    let late;
    try {
      const sent = page.waitForRequest((request) =>
        new URL(request.url()).pathname.endsWith('/incoming-replay-state'),
      );
      late = responseFor('GET', 'incoming-replay-state');
      await page.getByTestId('sale-return-replay-open').click();
      await sent;
      await page.getByTestId('sale-return-replay-close').click();
      await chooseBook('R92');
      await chooseBook('R91');
    } finally {
      await release();
    }
    assert.equal((await late).status(), 200);
    await settle();
    assert.equal(await page.getByTestId('sale-return-saved-context').count(), 0);
    assert.equal(await panel().count(), 0);
    await load();
    await open();
    assert.match(
      await page.getByTestId('sale-return-replay-status').textContent(),
      /^0 field changes/,
    );
    checks.push(
      'a real delayed state read cannot restore closed context through configured-book A→B→A; fresh load has an empty journal',
    );

    await page.getByTestId('sale-return-replay-close').click();
    await chooseBook('R92');
    const otherBook = await load(page, 'R92');
    const otherState = await open(page, 'R92');
    assert.equal(otherState.documentVersion, otherBook.version);
    assert.notEqual(otherState.rows[0].rowIdentity, state.rows[0].rowIdentity);
    assert.equal(otherState.scope.coBook, 'R92');
    await page.getByTestId('sale-return-replay-close').click();
    await chooseBook('R91');
    await load(page, 'R91', '00003');
    await open(page, 'R91', '00003');
    await field().selectOption(fieldId(20));
    const longText = '9999999999999999.99';
    assert.equal(await entry().inputValue(), longText);
    const countBeforeLong = requests.filter((request) => request.method() === 'POST').length;
    await commitButton().click();
    await page.getByTestId('sale-return-replay-error').waitFor();
    assert.equal(await entry().inputValue(), longText);
    assert.equal(requests.filter((request) => request.method() === 'POST').length, countBeforeLong);
    const shorter = await commit('1200', { voucher: '00003' });
    assert.deepEqual(shorter.payload.events, [{ fieldId: fieldId(20), editorText: '1200' }]);
    assert.deepEqual(shorter.data.events, [
      { fieldId: fieldId(20), editorText: '1200', status: 'applied' },
    ]);
    // TR_SALE_RTN:4941–4956 recalculates ItAmt for nonzero rate/basis on every numeric
    // LeaveCell, including a direct ItAmt commit: N basis10 × unchanged rate100 =1000.
    assert.equal(shorter.data.preview.visible['20'], '1000.00');
    assert.equal(shorter.data.baseline.visible['20'], longText);
    await page.getByTestId('sale-return-replay-close').click();
    checks.push(
      'oversized saved editor text remains exact, unchanged commit is refused, and a deliberate shorter preview replacement preserves the saved baseline',
    );

    await load(page, 'R91', '00002');
    const unsupported = await open(page, 'R91', '00002');
    assert.equal(unsupported.capabilities.canPreview, false);
    assert.equal(await commitButton().isDisabled(), true);
    assert.match(await panel().textContent(), /untagged/);
    assert.equal(await entry().isDisabled(), true);
    checks.push(
      'same voucher in another configured book keeps a distinct row identity; tagged history remains inspectable without numeric preview',
    );

    await page.getByTestId('sale-return-replay-close').click();
    const emptySaved = await load(page, 'R91', '00004');
    assert.deepEqual(emptySaved.lines, []);
    const emptyResponse = responseFor('GET', 'incoming-replay-state', page, 'R91', '00004');
    await page.getByTestId('sale-return-replay-open').click();
    const empty = await emptyResponse;
    assert.equal(empty.status(), 200, await empty.text());
    assert.deepEqual((await empty.json()).rows, []);
    await page.getByTestId('sale-return-replay-empty').waitFor();
    assert.equal(await page.getByTestId('sale-return-replay-row').count(), 0);
    assert.equal(await commitButton().count(), 0);
    checks.push(
      'a valid saved header without incoming rows renders a clear empty message without undefined identity or editable controls',
    );

    restricted = await page.context().browser().newContext({ baseURL: origin });
    const login = await restricted.request.post('/api/auth/login', {
      headers: { 'x-tenant-id': tenantId },
      data: { ...scope, loginName, password },
    });
    assert.equal(login.status(), 200, await login.text());
    const viewPage = await restricted.newPage();
    viewPage.on('pageerror', onError);
    await viewPage.goto('/txn/sale-return');
    await viewPage.getByRole('button', { name: 'Saved returns', exact: true }).click();
    await book(viewPage).locator('option[value="R91"]').waitFor({ state: 'attached' });
    await book(viewPage).selectOption('R91');
    const readonly = await load(viewPage);
    assert.equal(readonly.canUpdate, false);
    await open(viewPage);
    assert.equal(await viewPage.getByTestId('sale-return-replay-commit').isEnabled(), true);
    const viewResponse = responseFor('POST', 'incoming-replay', viewPage);
    await viewPage.getByTestId('sale-return-replay-entry').fill('120');
    await viewPage.getByTestId('sale-return-replay-commit').click();
    assert.equal((await viewResponse).status(), 200);
    assert.equal(await viewPage.getByTestId('sale-return-saved-save').isDisabled(), true);
    if (checkpoint) await checkpoint('sales-return-replay-view-only', viewPage);
    checks.push(
      'fresh owning View permission permits a real nonpersisting preview while metadata and numeric save remain unavailable',
    );

    await assertUnchanged(
      afterExternalConfiguration,
      'remaining delayed, sibling-book, unsupported and view-only operations make no business writes',
    );
    for (const request of requests) {
      const query = new URL(request.url()).searchParams;
      for (const key of ['coCode', 'lcCode', 'coYear']) assert.equal(query.get(key), scope[key]);
      assert(['R91', 'R92'].includes(query.get('coBook')));
      if (request.method() === 'POST') {
        const body = request.postDataJSON();
        assert.deepEqual(Object.keys(body).sort(), ['events', 'replayVersion', 'rowIdentity']);
        for (const event of body.events)
          assert.deepEqual(Object.keys(event).sort(), ['editorText', 'fieldId']);
      }
    }
    assert.deepEqual(errors, []);
    checks.push(
      'all real replay requests carry exact query scope and strict event-only bodies, with no browser exceptions',
    );
    return { status: 'passed', checks, snapshots: snapshotChecks, mockedRequests: 0 };
  } finally {
    page.off('pageerror', onError);
    page.off('request', onRequest);
    await other.dispose();
    if (restricted) await restricted.close();
  }
}
