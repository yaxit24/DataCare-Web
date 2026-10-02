import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { expectRows } from './journeySql.mjs';

const vectorBytes = readFileSync(
  new URL('../../api/test/fixtures/saleReturnBillReplay.independent.json', import.meta.url),
);
const vectorHash = createHash('sha256').update(vectorBytes).digest('hex');
assert.equal(vectorHash, '1d0cecba70ed751c64a14b506f18468a49778987dda285b0a0abbb37b7b48410');
const vector = JSON.parse(vectorBytes);
const required = JSON.parse(
  readFileSync(
    new URL(
      '../../../../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round11/bill-browser-required-checks.json',
      import.meta.url,
    ),
  ),
);
const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R11' };
const voucherNo = '00017';
const loginName = 'r11-bill-view';
const prefix = 'sale-return-bill-replay';
const fieldId = (column) => `x13.primary-incoming.c${String(column).padStart(2, '0')}`;
const columns = [19, 20, 21, 23, 24, 25, 26, 27, 28, 36, 37, 38];
const physicalItem = (logical) => ({ GOLD: 'B11G', SILVER: 'B11S' })[logical];
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
  'TEMP_BOOK_DATA',
  'SRNO_MAST',
  'TAG_SET',
  'CO_SET',
  'CO_SET_NEW',
  'COL_MAST',
  'BOOK_DATA',
  'YEAR_MAST',
  'ITEM_MAST',
  'EMP_MAST',
  'TAX_MAST',
  'AC_MAST',
  'CONV_MAST',
];
export const salesReturnBillReplayFixtureTables = ['SL_DETL_RTN', 'TAX_MAST'];
async function insert(sql, table, values) {
  const names = Object.keys(values)
    .map((key) => `"${key}"`)
    .join(',');
  await sql(
    `INSERT INTO "${table}"(tenant_id,${names}) SELECT $1::text,${names} FROM jsonb_populate_record(NULL::"${table}",$2::jsonb)`,
    JSON.stringify(values),
  );
}
export async function cleanupSalesReturnBillReplay(sql) {
  for (const table of ['SL_DETL_RTN', 'SL_DATA', 'BOOK_DATA'])
    await sql(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK" IN('R11','R12')`,
    );
  await sql(
    `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE" IN('B11G','B11S')`,
  );
  await sql(`DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "TAX_CODE"='10'`);
  await sql(
    `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE" IN('BANK','CARD','CUST')`,
  );
  await sql(`DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='r11-bill-view'`);
  await sql(`DELETE FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "LOGIN_NAME"='r11-bill-view'`);
}
/** Executed only after the existing fifteen journeys; calculation settings are explicit fixture inputs. */
export async function seedSalesReturnBillReplay(sql) {
  await cleanupSalesReturnBillReplay(sql);
  await expectRows(
    1,
    sql(
      `UPDATE "CO_SET" SET "SL_AMT_TYPE"='N',"LBR_ROF"=2,"LBR_RATE_GEN"='N',"ALL_ROF_REMOVE"='N',"LBR_TYPE"='N',"TAX_ROF"=2,"EMP_CODE_MANDATORY"='N',"LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
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
  for (const [logical, type, name] of [
    ['GOLD', 'G', 'Source gold'],
    ['SILVER', 'S', 'Source silver'],
  ])
    await insert(sql, 'ITEM_MAST', {
      CO_CODE: '01',
      IT_CODE: physicalItem(logical),
      IT_TYPE: type,
      RATE_TYPE: 'N',
      IT_NAME: name,
    });
  await insert(sql, 'TAX_MAST', {
    CO_CODE: '01',
    TAX_CODE: '10',
    SR_NO: '0',
    TAX_NAME: 'Current tax label',
    TAX_PRC: '99',
  });
  for (const [code, name] of [
    ['BANK', 'Current bank label'],
    ['CARD', 'Current card label'],
    ['CUST', 'Current customer master'],
  ])
    await insert(sql, 'AC_MAST', { CO_CODE: '01', AC_CODE: code, AC_NAME: name });
  for (const book of ['R11', 'R12']) {
    await insert(sql, 'BOOK_DATA', {
      CO_CODE: '01',
      LC_CODE: '01',
      CO_BOOK: book,
      BOOK_NAME: `${book} Incoming bill preview`,
      BOOK_SNAME: 'SRTN',
      MAIN_BOOK: 'SALES RETURNE',
      BOOK_INOUT: 'I',
      CUR_USE: 'Y',
      BOOK_TBL_NAME: 'SL_DATA',
      BOOK_TBL_DETL: 'SL_DETL_RTN',
      DATA_TYPE: 'B',
    });
    const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024-2025', CO_BOOK: book };
    for (const voucher of book === 'R11' ? [voucherNo, '00018', '00019'] : [voucherNo]) {
      await insert(sql, 'SL_DATA', {
        ...vector.header,
        ...key,
        VCH_NO: voucher,
        AC_NAME: book === 'R12' ? 'Other book saved bill customer' : vector.header.AC_NAME,
      });
      if (voucher === '00019') continue;
      for (const row of vector.rows)
        await insert(sql, 'SL_DETL_RTN', {
          ...row,
          ...key,
          VCH_NO: voucher,
          IT_CODE: physicalItem(row.IT_CODE),
          TAG_NO: voucher === '00018' && row.SR_NO === '42' ? 'B11-TAG' : row.TAG_NO,
        });
    }
  }
  await sql(
    `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") SELECT $1::text,'01','r11-bill-view',"LOGIN_PWD",'USER','N','N','N','N' FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LOGIN_NAME"='browser'`,
  );
  await sql(
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES($1,'01','01','r11-bill-view','Sales','Sales Return','Y','N','N','N')`,
  );
}
export async function snapshotSalesReturnBillReplay(owner, tenantId) {
  return owner.$transaction(async (tx) => {
    const result = {};
    for (const table of businessTables)
      result[table] = await tx.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t WHERE tenant_id=$1 ORDER BY to_jsonb(t)::text`,
        tenantId,
      );
    return result;
  });
}
function expectedMatrix(golden) {
  const matrix = Array.from({ length: 9 }, () => Array(6).fill(''));
  matrix[0][3] = 'Payment    ';
  matrix[0][4] = 'Received    ';
  [
    'Net Amt : ',
    'Sale Tax : ',
    'Total Amt : ',
    'Cheque Amt : ',
    'Card Amt : ',
    'Cash Amt : ',
    'Kasar Amt : ',
    'Os Amt : ',
  ].forEach((label, index) => {
    matrix[index + 1][0] = label;
  });
  matrix[2][1] = 'Current tax label';
  matrix[4][1] = 'Current bank label';
  matrix[5][1] = 'Current card label';
  for (const [key, value] of Object.entries(golden.matrixCells)) {
    const [row, col] = key.split(',').map(Number);
    matrix[row][col] = value;
  }
  return matrix;
}
function assertPhase(phase, golden) {
  assert.deepEqual(phase.bill.matrix, expectedMatrix(golden));
  assert.equal(phase.bill.oldNetAmt, golden.oldNetAmt);
  assert.equal(phase.bill.oldTaxPrc, golden.oldTaxPrc);
  const totals = Object.fromEntries(
    Array.from({ length: 71 }, (_, column) => [String(column), '']),
  );
  // TR_SALE_RTN:5178 assigns this label during the fold; the loaded phase has not folded.
  if (!golden.totalsAllBlank) totals['5'] = 'Total :';
  Object.assign(totals, golden.totals ?? {});
  assert.deepEqual(phase.incomingTotals, totals);
  assert.equal(phase.bill.closing.status, 'unavailable');
  assert.equal(phase.bill.closing.amount, null);
}

/** Real production UI → Fastify → isolated PostgreSQL. No request/response interception. */
export async function exerciseSalesReturnBillReplay(
  page,
  {
    checkpoint,
    snapshot,
    touchTaxSetting,
    holdSalesReturnReads,
    password,
    tenantId = 'browser-parity',
  } = {},
) {
  for (const callback of [snapshot, touchTaxSetting, holdSalesReturnReads])
    assert.equal(typeof callback, 'function');
  const checks = [],
    requests = [],
    errors = [],
    snapshots = [];
  let restricted;
  const onError = (error) => errors.push(error.message);
  const onRequest = (request) => {
    if (new URL(request.url()).pathname.includes('/incoming-bill-replay')) requests.push(request);
  };
  page.on('pageerror', onError);
  page.on('request', onRequest);
  const el = (name, target = page) => target.getByTestId(`${prefix}-${name}`);
  const book = (target = page) =>
    target.getByTestId('sale-return-saved-book').getByLabel('Configured book');
  const settle = (target = page) =>
    target.evaluate(
      () => new Promise((resolve) => requestAnimationFrame(() => requestAnimationFrame(resolve))),
    );
  const responseFor = (method, action, target = page, coBook = 'R11', voucher = voucherNo) =>
    target.waitForResponse(
      (response) =>
        response.request().method() === method &&
        new URL(response.url()).pathname === `/api/sales-returns/${voucher}/${action}` &&
        new URL(response.url()).searchParams.get('coBook') === coBook,
    );
  const confirm = () => checks.push(required.checks[checks.length]);
  const unchanged = async (before, label) => {
    assert.deepEqual(await snapshot(), before, label);
    snapshots.push({ label, tables: businessTables.length, unchanged: true });
  };
  const text = (value) => (value === '' ? '(blank)' : value === null ? 'Not stored' : value);
  const visible = async (name, expected, target = page) => {
    const cell = el(name, target);
    await cell.filter({ hasText: expected }).waitFor();
    assert.equal((await cell.textContent()).trim(), expected);
  };
  const chooseBook = async (value, target = page) => {
    await book(target).selectOption(value);
    await target.getByTestId('sale-return-saved-context').waitFor({ state: 'detached' });
    await settle(target);
    assert.equal(await book(target).inputValue(), value);
    assert.equal(await target.getByTestId('sale-return-saved-voucher').inputValue(), '');
  };
  const load = async (target = page, coBook = 'R11', voucher = voucherNo) => {
    await settle(target);
    assert.equal(await book(target).inputValue(), coBook);
    await target.getByTestId('sale-return-saved-voucher').fill(voucher);
    const [response] = await Promise.all([
      responseFor('GET', 'incoming', target, coBook, voucher),
      target.getByTestId('sale-return-saved-load').click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    await target.getByTestId('sale-return-saved-context').waitFor();
    await settle(target);
    return response.json();
  };
  const open = async (target = page, coBook = 'R11', voucher = voucherNo) => {
    const [response] = await Promise.all([
      responseFor('GET', 'incoming-bill-replay-state', target, coBook, voucher),
      el('open', target).click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    assert.match(response.headers()['cache-control'] ?? '', /no-store/);
    await el('saved-RTN_TOT_AMT', target).waitFor();
    await settle(target);
    return response.json();
  };
  const close = async () => {
    await el('close').click();
    await el('open').waitFor();
    await settle();
  };
  const commit = async (entryText, { column, enter = false, status = 200, target = page } = {}) => {
    if (column !== undefined) await el('field', target).selectOption(fieldId(column));
    await el('entry', target).fill(entryText);
    const [response] = await Promise.all([
      responseFor('POST', 'incoming-bill-replay', target),
      enter ? el('entry', target).press('Enter') : el('commit', target).click(),
    ]);
    assert.equal(response.status(), status, await response.text());
    assert.match(response.headers()['cache-control'] ?? '', /no-store/);
    const data = await response.json();
    if (status === 200)
      await el('status', target)
        .filter({ hasText: `${data.events.length} field change` })
        .waitFor();
    else await el('error', target).waitFor();
    await settle(target);
    return { data, payload: response.request().postDataJSON() };
  };
  const screenPhase = async (phaseName, golden, target = page) => {
    for (const [key, value] of Object.entries(golden.matrixCells)) {
      const [row, col] = key.split(',').map(Number);
      if (col === 3 || col === 4)
        await visible(`matrix-${phaseName}-${row}-${col}`, text(value), target);
    }
    if (phaseName !== 'loaded')
      for (const [column, value] of Object.entries(golden.totals))
        await visible(`total-${column}-${phaseName}`, value, target);
  };
  try {
    await page.goto('/txn/sale-return');
    await page.getByRole('button', { name: 'Saved returns', exact: true }).click();
    await book().locator('option[value="R11"]').waitFor({ state: 'attached' });
    await chooseBook('R11');
    const saved = await load();
    const before = await snapshot();
    assert.deepEqual(
      saved.lines.map((row) => [row.identity.srNo, row.identity.oldSrNo]),
      [
        ['17', '31'],
        ['42', '58'],
      ],
    );
    const state = await open();
    assert.equal(state.documentVersion, saved.version);
    assert.deepEqual(state.savedHeader, saved.header.raw);
    assert.equal(state.savedHeader.VCH_DESC, null);
    assert.equal(state.savedHeader.BILL_NO, '');
    assert.equal(state.savedHeader.DISC_AMT, '9999999999999999.99');
    assert.match(state.savedHeader.VCH_TIME, /12:34:56\.123456/);
    assert.equal(state.rowReplay.rows[0].raw.ITM_REMARK, null);
    assert.equal(state.rowReplay.rows[1].raw.ITM_REMARK, '');
    assert.deepEqual(
      state.rowReplay.rows.map((row) => row.identity),
      saved.lines.map((row) => row.identity),
    );
    confirm();
    assertPhase(state.phases.loaded, vector.expected.loaded);
    assertPhase(state.phases.opened, vector.expected.opened);
    await screenPhase('loaded', vector.expected.loaded);
    await screenPhase('opened', vector.expected.opened);
    await screenPhase('preview', vector.expected.opened);
    for (const [key, expected] of Object.entries({
      RTN_NET_AMT: '160',
      NET_AMT: '0.00',
      TAX_AMT: '7.00',
      RTN_TOT_AMT: '166.75',
      TOT_AMT: '0.00',
      RTN_BILL_OS: null,
      BILL_OS: null,
    })) {
      // SQL numeric(18,2) retains scale; Float return amounts have their own raw representation.
      assert.equal(state.savedHeader[key], expected, `stored SL_DATA.${key}`);
      assert.equal(saved.header.raw[key], expected, `saved read SL_DATA.${key}`);
      await visible(`saved-${key}`, text(saved.header.raw[key]));
    }
    if (checkpoint) {
      await el('totals').scrollIntoViewIfNeeded();
      await checkpoint('sales-return-bill-totals', page);
      await el('matrix').scrollIntoViewIfNeeded();
      await checkpoint('sales-return-bill-opened', page);
    }
    confirm();
    assert.equal(await page.getByTestId('sale-return-replay-open').count(), 0);
    assert.equal(await book().isDisabled(), true);
    assert.equal(await page.getByTestId('sale-return-saved-load').isDisabled(), true);
    assert.equal(await page.getByTestId('sale-return-saved-huid-17').getAttribute('readonly'), '');
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    assert.deepEqual(
      await el('field')
        .locator('option')
        .evaluateAll((options) => options.map((option) => option.value)),
      columns.map(fieldId),
    );
    if (checkpoint) {
      await el('row').scrollIntoViewIfNeeded();
      await checkpoint('sales-return-bill-controls', page);
    }
    confirm();
    for (const golden of vector.expected.prefixes) {
      const last = golden.events.at(-1);
      const actual = await commit(last.editorText, { column: 27 });
      assert.deepEqual(actual.payload, {
        replayVersion: state.replayVersion,
        rowIdentity: state.rowReplay.rows[0].rowIdentity,
        events: golden.events,
      });
      assertPhase(actual.data.phases.loaded, vector.expected.loaded);
      assertPhase(actual.data.phases.opened, vector.expected.opened);
      assertPhase(actual.data.phases.preview, golden);
      for (const [column, value] of Object.entries(golden.selectedRow)) {
        assert.equal(actual.data.preview.visible[column], value);
        assert.equal(
          (await el(`value-${column}`).locator('td').nth(1).textContent()).trim(),
          value,
        );
      }
      await screenPhase('preview', golden);
      await screenPhase('loaded', vector.expected.loaded);
      await screenPhase('opened', vector.expected.opened);
      if (checkpoint) {
        await el('matrix').scrollIntoViewIfNeeded();
        await checkpoint(`sales-return-bill-prefix-${golden.events.length}`, page);
      }
    }
    confirm();
    const repeated = await commit('0');
    assert.deepEqual(repeated.payload.events, [
      ...vector.expected.prefixes[1].events,
      { fieldId: fieldId(27), editorText: '0' },
    ]);
    assertPhase(repeated.data.phases.preview, vector.expected.prefixes[1]);
    const priorPosts = requests.filter((request) => request.method() === 'POST').length;
    await el('entry').fill('bad');
    await el('commit').click();
    await el('error').waitFor();
    assert.equal(await el('entry').inputValue(), 'bad');
    assert.equal(requests.filter((request) => request.method() === 'POST').length, priorPosts);
    await screenPhase('preview', vector.expected.prefixes[1]);
    const blank = await commit('', { enter: true });
    assert.equal(blank.payload.events.at(-1).editorText, '');
    assert.equal(blank.data.events.length, 4);
    assertPhase(blank.data.phases.preview, vector.expected.prefixes[1]);
    await el('entry').press('Tab');
    await settle();
    assert.equal(requests.filter((request) => request.method() === 'POST').length, priorPosts + 1);
    confirm();
    assert.equal(state.capabilities.canPreviewClosing, false);
    assert.equal(state.capabilities.canSaveNumeric, false);
    assert.match(await el('closing').textContent(), /Closing balance unavailable.*ledger mode/s);
    assert.equal(
      await page
        .getByTestId(prefix)
        .getByRole('button', { name: /^(save|apply|update)/i })
        .count(),
      0,
    );
    await unchanged(
      before,
      'initial, ordered, repeated, invalid and blank previews preserve27 business tables',
    );
    confirm();
    await close();
    assert.equal(await el('open').evaluate((button) => document.activeElement === button), true);
    assert.equal(
      await page.getByTestId('sale-return-saved-huid-17').getAttribute('readonly'),
      null,
    );
    const fresh = await open();
    await el('row').selectOption(fresh.rowReplay.rows[1].rowIdentity);
    assert.match(await el('identity').textContent(), /Saved row 42.*Saved old row 58/);
    const sibling = await commit('5', { column: 27 });
    assert.equal(sibling.payload.rowIdentity, fresh.rowReplay.rows[1].rowIdentity);
    assert.equal(sibling.data.baseline.visible['38'], '50.00');
    assert.equal(sibling.data.preview.visible['38'], '55.00');
    assert.equal(sibling.data.phases.preview.incomingTotals['38'], '165.00');
    assert.equal(sibling.data.phases.preview.bill.matrix[2][3], '16.50');
    assert.equal(sibling.data.phases.preview.bill.matrix[3][3], '182.00');
    await close();
    confirm();
    const [rowRead] = await Promise.all([
      responseFor('GET', 'incoming-replay-state'),
      page.getByTestId('sale-return-replay-open').click(),
    ]);
    assert.equal(rowRead.status(), 200);
    await page.getByTestId('sale-return-replay-row').waitFor();
    assert.equal(await el('open').count(), 0);
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    await page.getByTestId('sale-return-replay-close').click();
    await el('open').waitFor();
    await settle();
    confirm();
    const stale = await open();
    await commit('1', { column: 27 });
    await touchTaxSetting();
    const afterExternal = await snapshot();
    await commit('0', { status: 409 });
    await el('conflict').waitFor();
    assert.equal(await el('entry').inputValue(), '0');
    assert.equal(await el('commit').isDisabled(), true);
    await screenPhase('preview', vector.expected.prefixes[0]);
    if (checkpoint) {
      await el('conflict').scrollIntoViewIfNeeded();
      await checkpoint('sales-return-bill-conflict', page);
    }
    const postCount = requests.filter((request) => request.method() === 'POST').length;
    const [reload] = await Promise.all([responseFor('GET', 'incoming'), el('reload').click()]);
    assert.equal(reload.status(), 200);
    await el('open').waitFor();
    const reloaded = await open();
    assert.notEqual(reloaded.replayVersion, stale.replayVersion);
    assert.equal(requests.filter((request) => request.method() === 'POST').length, postCount);
    await screenPhase('preview', vector.expected.opened);
    const retry = await commit('1', { column: 27 });
    assert.equal(retry.payload.events.length, 1);
    assertPhase(retry.data.phases.preview, vector.expected.prefixes[0]);
    await unchanged(
      afterExternal,
      'same-value tax-setting conflict, reload and explicit fresh preview preserve business rows',
    );
    confirm();
    await close();
    const release = await holdSalesReturnReads();
    let late;
    try {
      const sent = page.waitForRequest((request) =>
        new URL(request.url()).pathname.endsWith('/incoming-bill-replay-state'),
      );
      late = responseFor('GET', 'incoming-bill-replay-state');
      void late.catch(() => {});
      await el('open').click();
      await sent;
      await el('close').click();
      await chooseBook('R12');
      await chooseBook('R11');
    } finally {
      await release();
    }
    assert.equal((await late).status(), 200);
    await settle();
    assert.equal(await page.getByTestId('sale-return-saved-context').count(), 0);
    assert.equal(await page.getByTestId(prefix).count(), 0);
    await load();
    await open();
    await el('status')
      .filter({ hasText: /^0 field changes/ })
      .waitFor();
    await close();
    confirm();
    await chooseBook('R12');
    const otherSaved = await load(page, 'R12');
    const otherState = await open(page, 'R12');
    assert.equal(otherState.scope.coBook, 'R12');
    assert.equal(otherState.documentVersion, otherSaved.version);
    assert.equal(otherState.savedHeader.AC_NAME, 'Other book saved bill customer');
    assert.notEqual(otherState.rowReplay.rows[0].rowIdentity, state.rowReplay.rows[0].rowIdentity);
    assertPhase(otherState.phases.opened, vector.expected.opened);
    await close();
    await chooseBook('R11');
    confirm();
    await load(page, 'R11', '00018');
    const tagged = await open(page, 'R11', '00018');
    assert.equal(tagged.rowReplay.rows[0].raw.TAG_NO, 'N');
    assert.equal(tagged.rowReplay.rows[1].raw.TAG_NO, 'B11-TAG');
    assert.equal(tagged.capabilities.canPreviewBill, false);
    assert.equal(tagged.phases.opened, null);
    assert.equal(await el('entry').isDisabled(), true);
    assert.equal(await el('commit').isDisabled(), true);
    await el('readonly').waitFor();
    await close();
    confirm();
    const emptySaved = await load(page, 'R11', '00019');
    assert.deepEqual(emptySaved.lines, []);
    const empty = await open(page, 'R11', '00019');
    assert.deepEqual(empty.rowReplay.rows, []);
    assert.equal(empty.capabilities.canPreviewBill, false);
    await el('empty').waitFor();
    assert.equal(await el('commit').count(), 0);
    assert.equal(await el('row').count(), 0);
    if (checkpoint) {
      await el('empty').scrollIntoViewIfNeeded();
      await checkpoint('sales-return-bill-empty', page);
    }
    confirm();
    restricted = await page
      .context()
      .browser()
      .newContext({ baseURL: new URL(page.url()).origin });
    const login = await restricted.request.post('/api/auth/login', {
      headers: { 'x-tenant-id': tenantId },
      data: { ...scope, loginName, password },
    });
    assert.equal(login.status(), 200, await login.text());
    const viewPage = await restricted.newPage();
    viewPage.on('pageerror', onError);
    viewPage.on('request', onRequest);
    await viewPage.goto('/txn/sale-return');
    await viewPage.getByRole('button', { name: 'Saved returns', exact: true }).click();
    await book(viewPage).locator('option[value="R11"]').waitFor({ state: 'attached' });
    await chooseBook('R11', viewPage);
    const viewSaved = await load(viewPage);
    assert.equal(viewSaved.canUpdate, false);
    await open(viewPage);
    assert.equal(await el('commit', viewPage).isEnabled(), true);
    const viewPreview = await commit('1', { column: 27, target: viewPage });
    assertPhase(viewPreview.data.phases.preview, vector.expected.prefixes[0]);
    await screenPhase('preview', vector.expected.prefixes[0], viewPage);
    assert.equal(await viewPage.getByTestId('sale-return-saved-save').isDisabled(), true);
    if (checkpoint) {
      await el('matrix', viewPage).scrollIntoViewIfNeeded();
      await checkpoint('sales-return-bill-view-only', viewPage);
    }
    confirm();
    await unchanged(
      afterExternal,
      'delayed, duplicate-book, unsupported, empty and View-only previews preserve27 business tables',
    );
    for (const request of requests) {
      const query = new URL(request.url()).searchParams;
      for (const key of ['coCode', 'lcCode', 'coYear']) assert.equal(query.get(key), scope[key]);
      assert(['R11', 'R12'].includes(query.get('coBook')));
      if (request.method() === 'POST') {
        const body = request.postDataJSON();
        assert.deepEqual(Object.keys(body).sort(), ['events', 'replayVersion', 'rowIdentity']);
        for (const event of body.events)
          assert.deepEqual(Object.keys(event).sort(), ['editorText', 'fieldId']);
      }
    }
    assert.deepEqual(errors, []);
    confirm();
    assert.deepEqual(checks, required.checks);
    return {
      status: 'passed',
      checks,
      requests: requests.length,
      mockedRequests: 0,
      snapshots,
      independentVectorSha256: vectorHash,
      requiredChecksVersion: required.version,
    };
  } finally {
    page.off('pageerror', onError);
    page.off('request', onRequest);
    await restricted?.close();
  }
}
