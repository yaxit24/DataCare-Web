import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';

const fixtureBytes = readFileSync(
  new URL('../../api/test/fixtures/saleReturnLabourReplay.independent.json', import.meta.url),
);
assert.equal(
  createHash('sha256').update(fixtureBytes).digest('hex'),
  '8c2e2ba9a985a1e57e353bcbf742e8b350fac47cd34e6cf96f7cb283adbeb78b',
);
const fixture = JSON.parse(fixtureBytes);
const required = JSON.parse(
  readFileSync(
    new URL(
      '../../../../parity-plan-2026-09-10/evidence/implementation-2026-09-12-round13/return-labour-preview-browser/browser-required-checks.json',
      import.meta.url,
    ),
  ),
);
const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'RLP' };
const voucherNo = '00017';
const loginName = 'r13-labour-view';
const prefix = 'sale-return-labour-replay-';
const field = (column) => 'x13.primary-incoming.c' + String(column).padStart(2, '0');
const routes = {
  state: 'incoming-labour-replay-state',
  check: 'incoming-labour-observation',
  append: 'incoming-labour-replay',
};
const tables = [
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
  'LBR_MAST',
  'auth_session',
];
export const salesReturnLabourReplayFixtureTables = ['SL_DETL_RTN', 'TAX_MAST', 'LBR_MAST'];

async function insert(sql, table, values) {
  const names = Object.keys(values)
    .map((key) => '"' + key + '"')
    .join(',');
  await sql(
    'INSERT INTO "' +
      table +
      '"(tenant_id,' +
      names +
      ') SELECT $1,' +
      names +
      ' FROM jsonb_populate_record(NULL::"' +
      table +
      '",$2::jsonb)',
    JSON.stringify(values),
  );
}
export async function cleanupSalesReturnLabourReplay(sql) {
  for (const table of ['SL_DETL_RTN', 'SL_DATA', 'BOOK_DATA'])
    await sql(
      'DELETE FROM "' +
        table +
        '" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4',
      '01',
      '01',
      'RLP',
    );
  for (const [table, key, codes] of [
    ['LBR_MAST', 'LBR_CODE', fixture.masters.map((master) => master.LBR_CODE)],
    ['TAX_MAST', 'TAX_CODE', ['10']],
    ['AC_MAST', 'AC_CODE', ['BANK', 'CARD', 'CUST']],
  ])
    await sql(
      'DELETE FROM "' +
        table +
        '" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "' +
        key +
        '"=ANY($3::text[])',
      '01',
      codes,
    );
  await sql('DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2', loginName);
  await sql('DELETE FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "LOGIN_NAME"=$2', loginName);
}

/** Runs after all existing journeys, using the runner's disposable tenant and owner only. */
export async function seedSalesReturnLabourReplay(sql) {
  await cleanupSalesReturnLabourReplay(sql);
  await sql(
    'UPDATE "CO_SET" SET "SL_AMT_TYPE"=$2,"LBR_ROF"=2,"LBR_RATE_GEN"=$2,"ALL_ROF_REMOVE"=$2,"LBR_TYPE"=$2,"TAX_ROF"=2,"EMP_CODE_MANDATORY"=$2,"LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$3',
    'N',
    '01',
  );
  await sql(
    'INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") SELECT $1,$2,$3 WHERE NOT EXISTS(SELECT 1 FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2)',
    '01',
    'N',
  );
  await sql(
    'UPDATE "CO_SET_NEW" SET "LBR_WITH_GHT"=$2 WHERE tenant_id=$1 AND "CO_CODE"=$3',
    'N',
    '01',
  );
  // The existing GOLD fixture is reused only after the old journeys finish. Pin all observed
  // fields needed by this independent saved projection, with no duplicate current master.
  await sql(
    'DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3',
    '01',
    'GOLD',
  );
  await insert(sql, 'ITEM_MAST', {
    CO_CODE: '01',
    IT_CODE: 'GOLD',
    IT_TYPE: 'G',
    RATE_TYPE: 'N',
    IT_NAME: 'Source gold',
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
  for (const master of fixture.masters) await insert(sql, 'LBR_MAST', master);
  await insert(sql, 'BOOK_DATA', {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_BOOK: 'RLP',
    BOOK_NAME: 'Incoming labour preview',
    BOOK_SNAME: 'SRTN',
    MAIN_BOOK: 'SALES RETURNE',
    BOOK_INOUT: 'I',
    CUR_USE: 'Y',
    BOOK_TBL_NAME: 'SL_DATA',
    BOOK_TBL_DETL: 'SL_DETL_RTN',
    DATA_TYPE: 'B',
  });
  const key = {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'RLP',
    VCH_NO: voucherNo,
  };
  await insert(sql, 'SL_DATA', { ...fixture.header, ...key });
  for (const row of fixture.rows) await insert(sql, 'SL_DETL_RTN', { ...row, ...key });
  await sql(
    'INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") SELECT $1,$2,$3,"LOGIN_PWD",$4,$5,$5,$5,$5 FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LOGIN_NAME"=$6',
    '01',
    loginName,
    'USER',
    'N',
    'browser',
  );
  await insert(sql, 'USER_SET', {
    CO_CODE: '01',
    LC_CODE: '01',
    USER_NAME: loginName,
    MAIN_MENU: 'Sales',
    SUB_MENU: 'Sales Return',
    FRM_VIEW: 'Y',
    FRM_EDIT: 'N',
    FRM_DELETE: 'N',
    FRM_PRINT: 'N',
  });
}
export async function snapshotSalesReturnLabourReplay(owner, tenantId) {
  return owner.$transaction(
    async (tx) => {
      const result = {};
      for (const table of tables)
        result[table] = await tx.$queryRawUnsafe(
          'SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "' +
            table +
            '" t WHERE tenant_id=$1 ORDER BY to_jsonb(t)::text',
          tenantId,
        );
      return result;
    },
    { isolationLevel: 'RepeatableRead' },
  );
}

/** Production UI -> actual mounted API -> isolated PostgreSQL. No request interception. */
export async function exerciseSalesReturnLabourReplay(
  page,
  { checkpoint, owner, tenantId, password, sql } = {},
) {
  assert(
    owner && typeof owner.$queryRawUnsafe === 'function',
    'existing isolated owner is required',
  );
  assert.equal(tenantId, 'browser-parity');
  assert.equal(typeof sql, 'function');
  assert.equal(typeof password, 'string');
  const checks = [],
    requests = [],
    snapshots = [],
    errors = [];
  const el = (name, target = page) => target.getByTestId(prefix + name);
  const onRequest = (request) => {
    const path = new URL(request.url()).pathname;
    if (Object.values(routes).some((route) => path.endsWith('/' + route))) requests.push(request);
  };
  const onError = (error) => errors.push(error.message);
  page.on('request', onRequest);
  page.on('pageerror', onError);
  let restricted;
  let state, current;
  const confirm = (id) => {
    assert.equal(id, required.checks[checks.length], 'a named required checkpoint must be next');
    checks.push(id);
  };
  const snap = () => snapshotSalesReturnLabourReplay(owner, tenantId);
  const unchanged = async (before, label) => {
    const after = await snap();
    assert.deepEqual(after, before, label);
    snapshots.push({
      label,
      tables: tables.length,
      beforeSha256: createHash('sha256').update(JSON.stringify(before)).digest('hex'),
      afterSha256: createHash('sha256').update(JSON.stringify(after)).digest('hex'),
    });
  };
  const responseFor = (method, route, target = page) =>
    target.waitForResponse((response) => {
      const url = new URL(response.url());
      return (
        response.request().method() === method &&
        url.pathname === '/api/sales-returns/' + voucherNo + '/' + route &&
        url.searchParams.get('coBook') === 'RLP'
      );
    });
  const result = async (response, status = 200) => {
    const body = await response.json();
    assert.equal(response.status(), status, JSON.stringify(body));
    assert((response.headers()['cache-control'] || '').includes('no-store'));
    const query = [...new URL(response.url()).searchParams];
    assert.equal(query.length, 4, 'exact full scope, without duplicate or extra query keys');
    assert.deepEqual(Object.fromEntries(query), scope);
    return body;
  };
  const assertContext = (response, context) => {
    assert.deepEqual(Object.keys(context).sort(), [
      'coCode',
      'coYear',
      'contextEpoch',
      'lcCode',
      'sessionId',
    ]);
    assert.deepEqual(
      { coCode: context.coCode, lcCode: context.lcCode, coYear: context.coYear },
      { coCode: scope.coCode, lcCode: scope.lcCode, coYear: scope.coYear },
    );
    assert.match(
      context.sessionId,
      /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/,
    );
    assert.match(context.contextEpoch, /^[1-9][0-9]*$/);
    const headers = response.request().headers();
    assert.equal(headers['x-session-context-id'], context.sessionId);
    assert.equal(headers['x-session-context-epoch'], context.contextEpoch);
  };
  const assertJournal = async (events, target = page) => {
    await el('status', target)
      .filter({ hasText: new RegExp('^' + events.length + ' field changes previewed in order\\.') })
      .waitFor();
    assert.equal(await el('events', target).locator('li').count(), events.length);
  };
  const display = (value) => (value === '' ? '(blank)' : value === null ? 'Not stored' : value);
  const visible = async (name, value, target = page) => {
    await el(name, target)
      .filter({ hasText: display(value) })
      .waitFor();
    assert.equal((await el(name, target).textContent()).trim(), display(value));
  };
  const screen = async (phase, golden, target = page) => {
    for (let row = 1; row < 9; row++)
      for (const col of [3, 4])
        await visible(
          'matrix-' + phase + '-' + row + '-' + col,
          golden.bill.matrix[row][col],
          target,
        );
    if (phase !== 'loaded')
      for (const col of [9, 10, 11, 12, 15, 18, 20, 24, 27, 42, 28, 36, 38, 35])
        await visible('total-' + col + '-' + phase, golden.incomingTotals[String(col)], target);
  };
  const screenRow = async (golden, target = page) => {
    for (const col of [13, 29, 23, 24, 38])
      await visible('value-' + col + '-preview', golden.visible[String(col)], target);
  };
  const load = async (target = page) => {
    await target.goto('/txn/sale-return');
    await target.getByRole('button', { name: 'Saved returns', exact: true }).click();
    const book = target.getByTestId('sale-return-saved-book').getByLabel('Configured book');
    await book.locator('option[value="RLP"]').waitFor({ state: 'attached' });
    await book.selectOption('RLP');
    await target.getByTestId('sale-return-saved-voucher').fill(voucherNo);
    const [response] = await Promise.all([
      responseFor('GET', 'incoming', target),
      target.getByTestId('sale-return-saved-load').click(),
    ]);
    assert.equal(response.status(), 200, await response.text());
    await target.getByTestId('sale-return-saved-context').waitFor();
    return response.json();
  };
  const open = async (target = page) => {
    const [response] = await Promise.all([
      responseFor('GET', routes.state, target),
      el('open', target).click(),
    ]);
    const data = await result(response);
    assertContext(response, data.context);
    assert.equal(data.rows.length, 1);
    assert.match(data.rows[0].initialPrefixVersion, /^[a-f0-9]{64}$/);
    const initialRow = data.billReplay.rowReplay.rows[0];
    assert.deepEqual(
      {
        visible: initialRow.visible,
        caches: initialRow.caches,
        editorTextByField: initialRow.editorTextByField,
      },
      fixture.expected.initial,
    );
    await el('entry', target).waitFor();
    await assertJournal([], target);
    if (target === page) {
      state = data;
      current = {
        prefixVersion: data.rows[0].initialPrefixVersion,
        events: [],
        preview: fixture.expected.initial,
        phase: fixture.expected.opened,
      };
    }
    return data;
  };
  const close = async (target = page) => {
    await el('close', target).click();
    await el('open', target).waitFor();
  };
  const input = () => ({
    baseVersion: state.baseVersion,
    rowIdentity: state.rows[0].rowIdentity,
    prefixVersion: current.prefixVersion,
    events: current.events,
  });
  const checkCode = async (code, column = 13, status = 200) => {
    await el('field').selectOption(field(column));
    await el('entry').fill(code);
    const old = structuredClone(input());
    const [response] = await Promise.all([responseFor('POST', routes.check), el('check').click()]);
    const data = await result(response, status);
    assertContext(response, state.context);
    if (status === 200) assert.deepEqual(data.context, state.context);
    assert.deepEqual(response.request().postDataJSON(), {
      ...old,
      fieldId: field(column),
      editorText: code,
    });
    if (status === 200) {
      assert.equal(data.prefixVersion, old.prefixVersion);
      assert.equal(data.baseVersion, old.baseVersion);
      assert.equal(data.selection.LBR_CODE, code);
      assert.equal(data.editorText, code);
      for (const absent of ['prefix', 'preview', 'events', 'phase', 'effects'])
        assert.equal(Object.hasOwn(data, absent), false, 'lookup is observation only');
      await el('candidate')
        .filter({ hasText: 'Checked code ' + code + ' ' })
        .waitFor();
    } else await el('error').filter({ hasText: data.message }).waitFor();
    await assertJournal(old.events);
    return data;
  };
  const accept = async (event, golden, trigger) => {
    const old = structuredClone(input());
    const [response] = await Promise.all([responseFor('POST', routes.append), trigger()]);
    const data = await result(response);
    assert.deepEqual(response.request().postDataJSON(), { ...old, event });
    assertContext(response, state.context);
    assert.deepEqual(data.context, state.context);
    assert.equal(data.baseVersion, old.baseVersion);
    assert.equal(data.rowIdentity, old.rowIdentity);
    assert.notEqual(data.prefix.prefixVersion, old.prefixVersion);
    assert.equal(data.effects.aggregateApplied, true);
    assert.equal(data.effects.billApplied, true);
    assert.deepEqual(data.prefix.events, [...old.events, event]);
    assert.deepEqual(data.acceptedEvent, { event, status: 'applied' });
    assert.deepEqual(data.prefix.preview, golden.preview);
    assert.deepEqual(data.prefix.phase, golden.phase);
    for (const capability of ['canSaveNumeric', 'canPreviewClosing', 'canApplySource'])
      assert.equal(data.capabilities[capability], false);
    current = data.prefix;
    await assertJournal(current.events);
    await screen('preview', golden.phase);
    await screenRow(golden.preview);
    return data;
  };
  const code = async (text, golden, column = 13) => {
    const observed = await checkCode(text, column);
    return accept(
      {
        kind: 'labourEnter',
        fieldId: field(column),
        editorText: text,
        observationVersion: observed.observationVersion,
      },
      golden,
      () => el('commit').click(),
    );
  };
  try {
    const saved = await load();
    const before = await snap();
    await open();
    assert.equal(state.contractVersion, 'x13-saved-incoming-labour-bill-replay-v1');
    assert.equal(state.profile, 'saved-primary-incoming-resolved-labour-bill-preview-v1');
    assert.deepEqual(state.scope, scope);
    assert.equal(state.documentVersion, saved.version);
    assert.equal(state.rows.length, 1);
    assert.deepEqual(
      state.billReplay.rowReplay.rows.map((row) => row.identity),
      saved.lines.map((row) => row.identity),
    );
    assert.equal(saved.lines[0].identity.srNo, '17');
    assert.equal(saved.lines[0].identity.oldSrNo, '31');
    assert.equal(state.billReplay.savedHeader.DISC_AMT, '9999999999999999.99');
    assert.equal(state.billReplay.savedHeader.VCH_DESC, null);
    assert.equal(state.billReplay.savedHeader.BILL_NO, '');
    confirm('saved-row-and-new-contract-identity');
    assert.deepEqual(state.billReplay.phases.loaded, fixture.expected.loaded);
    assert.deepEqual(state.billReplay.phases.opened, fixture.expected.opened);
    assert.equal(state.capabilities.canPreview, true);
    assert.equal(state.capabilities.canPreviewClosing, false);
    assert.equal(state.capabilities.canSaveNumeric, false);
    assert.equal(state.capabilities.canApplySource, false);
    await screen('loaded', fixture.expected.loaded);
    await screen('opened', fixture.expected.opened);
    await screen('preview', fixture.expected.opened);
    await screenRow(fixture.expected.initial);
    for (const key of [
      'RTN_NET_AMT',
      'NET_AMT',
      'TAX_AMT',
      'RTN_TOT_AMT',
      'TOT_AMT',
      'RTN_BILL_OS',
      'BILL_OS',
    ])
      await visible('saved-' + key, state.billReplay.savedHeader[key]);
    await el('closing')
      .filter({ hasText: 'Customer balance requires a resolved ledger mode.' })
      .waitFor();
    confirm('loaded-opened-exact-bill-and-unavailable-closing');
    assert.equal(await page.getByTestId('sale-return-replay-open').count(), 0);
    assert.equal(await page.getByTestId('sale-return-bill-replay-open').count(), 0);
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    assert.equal(await page.getByTestId('sale-return-saved-load').isDisabled(), true);
    assert.equal(
      await page.getByTestId('sale-return-saved-book').getByLabel('Configured book').isDisabled(),
      true,
    );
    confirm('exclusive-preview-ownership-and-no-numeric-save');
    const candidate = await checkCode('BB');
    await el('entry').press('Tab');
    assert.equal(current.events.length, 0);
    assert.equal(
      requests.filter(
        (request) =>
          request.method() === 'POST' &&
          new URL(request.url()).pathname.endsWith('/' + routes.append),
      ).length,
      0,
    );
    await screen('preview', fixture.expected.opened);
    await unchanged(before, 'state and lookup do not change saved data');
    confirm('resolved-lookup-does-not-append-or-change-totals');
    await accept(
      {
        kind: 'labourEnter',
        fieldId: field(13),
        editorText: 'BB',
        observationVersion: candidate.observationVersion,
      },
      fixture.expected.prefixes.bb,
      () => el('commit').click(),
    );
    await code('AA', fixture.expected.prefixes['bb-aa']);
    assert.equal(current.events.length, 2);
    await screen('loaded', fixture.expected.loaded);
    await screen('opened', fixture.expected.opened);
    if (checkpoint) await checkpoint('sales-return-labour-history', page);
    confirm('bb-then-aa-complete-prefix-bill-history');
    await close();
    await open();
    await code('BB', fixture.expected.prefixes.bb);
    await el('field').selectOption(field(27));
    await el('entry').fill('1');
    await accept(
      { kind: 'moneyLeave', fieldId: field(27), editorText: '1' },
      fixture.expected.prefixes['bb-other'],
      () => el('commit').click(),
    );
    await code('AA', fixture.expected.prefixes['bb-other-aa']);
    assert.equal(current.events.length, 3);
    confirm('interleaved-money-and-labour-preserve-order');
    await close();
    await open();
    for (let index = 0; index < 2; index++) {
      await el('field').selectOption(field(13));
      await el('entry').fill('AA');
      const old = structuredClone(input());
      const postsBefore = requests.filter(
        (request) =>
          request.method() === 'POST' &&
          new URL(request.url()).pathname.endsWith('/' + routes.append),
      ).length;
      const [response] = await Promise.all([
        responseFor('POST', routes.append),
        el('entry').press('Enter'),
      ]);
      const data = await result(response);
      assertContext(response, state.context);
      assert.deepEqual(data.context, state.context);
      const submitted = response.request().postDataJSON();
      assert.equal(data.baseVersion, old.baseVersion);
      assert.equal(data.rowIdentity, old.rowIdentity);
      assert.notEqual(data.prefix.prefixVersion, old.prefixVersion);
      assert.deepEqual(data.acceptedEvent, { event: submitted.event, status: 'applied' });
      assert.equal(data.effects.billApplied, true);
      for (const capability of ['canSaveNumeric', 'canPreviewClosing', 'canApplySource'])
        assert.equal(data.capabilities[capability], false);
      assert.deepEqual({ ...submitted, event: undefined }, { ...old, event: undefined });
      assert.deepEqual(
        { ...submitted.event, observationVersion: undefined },
        {
          kind: 'labourEnter',
          fieldId: field(13),
          editorText: 'AA',
          observationVersion: undefined,
        },
      );
      assert.deepEqual(data.prefix.events, [...old.events, submitted.event]);
      assert.deepEqual(data.prefix.preview, fixture.expected.prefixes['same-aa'].preview);
      assert.deepEqual(data.prefix.phase, fixture.expected.prefixes['same-aa'].phase);
      current = data.prefix;
      await assertJournal(current.events);
      await screen('preview', fixture.expected.prefixes['same-aa'].phase);
      await screenRow(fixture.expected.prefixes['same-aa'].preview);
      assert.equal(current.events.length, index + 1);
      assert.equal(
        requests.filter(
          (request) =>
            request.method() === 'POST' &&
            new URL(request.url()).pathname.endsWith('/' + routes.append),
        ).length,
        postsBefore + 1,
      );
    }
    confirm('same-code-enter-appends-once-per-intent');
    await close();
    await open();
    await code('TA', fixture.expected.prefixes['same-ta'], 29);
    confirm('tag-category04-keeps-callback-without-copy-destination');
    const retained = structuredClone(current);
    const missing = await checkCode('MX', 13, 422);
    assert.equal(missing.error, 'lookup-required');
    assert.equal(await el('entry').inputValue(), 'MX');
    assert.deepEqual(current, retained);
    await screen('preview', retained.phase);
    await screenRow(retained.preview);
    confirm('missing-code-retains-draft-and-prefix');
    await close();
    await open();
    await code('BB', fixture.expected.prefixes.bb);
    await unchanged(
      before,
      'all successful and refused previews leave complete business/session/config/master rows unchanged',
    );
    await sql(
      'UPDATE "LBR_MAST" SET "LBR_VAL"="LBR_VAL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LBR_CODE"=$3',
      '01',
      'BB',
    );
    const afterMasterChange = await snap();
    const oldPrefix = structuredClone(current);
    const stale = await checkCode('AA', 13, 409);
    assert.equal(stale.error, 'master-version-conflict');
    assert.equal(await el('entry').inputValue(), 'AA');
    await screen('preview', oldPrefix.phase);
    await screenRow(oldPrefix.preview);
    assert.deepEqual(current, oldPrefix);
    confirm('historical-master-change-refuses-next-lookup-without-rebase');
    await unchanged(
      afterMasterChange,
      'historical master conflict cannot edit or rebase any stored state',
    );
    confirm('actual-database-rows-unchanged-apart-from-declared-master-test-change');
    await close();
    const browser = page.context().browser();
    assert(browser);
    restricted = await browser.newContext({ baseURL: new URL(page.url()).origin });
    const limited = await restricted.newPage();
    limited.on('request', onRequest);
    limited.on('pageerror', onError);
    await limited.goto('/login');
    await limited.getByLabel('User', { exact: true }).fill(loginName);
    await limited.getByLabel('Password', { exact: true }).fill(password);
    await limited.getByRole('button', { name: 'Sign In', exact: true }).click();
    await limited.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
    await limited.getByRole('button', { name: 'Open', exact: true }).click();
    await limited.waitForURL('**/dashboard');
    const limitedSaved = await load(limited);
    assert.equal(
      limitedSaved.canUpdate,
      false,
      'actual saved DTO carries no own-form Update right',
    );
    const limitedBefore = await snap();
    const limitedState = await open(limited);
    assert.equal(limitedState.capabilities.canPreview, true);
    assert.notEqual(limitedState.context.sessionId, state.context.sessionId);
    await screen('opened', fixture.expected.opened, limited);
    assert.equal(await limited.getByTestId('sale-return-saved-save').isDisabled(), true);
    await el('field', limited).selectOption(field(13));
    await el('entry', limited).fill('BB');
    const [limitedCheckResponse] = await Promise.all([
      responseFor('POST', routes.check, limited),
      el('check', limited).click(),
    ]);
    const limitedObservation = await result(limitedCheckResponse);
    assertContext(limitedCheckResponse, limitedState.context);
    assert.deepEqual(limitedObservation.context, limitedState.context);
    await assertJournal([], limited);
    const limitedBase = {
      baseVersion: limitedState.baseVersion,
      rowIdentity: limitedState.rows[0].rowIdentity,
      prefixVersion: limitedState.rows[0].initialPrefixVersion,
      events: [],
    };
    assert.deepEqual(limitedCheckResponse.request().postDataJSON(), {
      ...limitedBase,
      fieldId: field(13),
      editorText: 'BB',
    });
    const limitedEvent = {
      kind: 'labourEnter',
      fieldId: field(13),
      editorText: 'BB',
      observationVersion: limitedObservation.observationVersion,
    };
    const [limitedAppendResponse] = await Promise.all([
      responseFor('POST', routes.append, limited),
      el('commit', limited).click(),
    ]);
    const limitedResult = await result(limitedAppendResponse);
    assertContext(limitedAppendResponse, limitedState.context);
    assert.deepEqual(limitedResult.context, limitedState.context);
    assert.deepEqual(limitedResult.acceptedEvent, { event: limitedEvent, status: 'applied' });
    assert.equal(limitedResult.effects.billApplied, true);
    assert.deepEqual(limitedAppendResponse.request().postDataJSON(), {
      ...limitedBase,
      event: limitedEvent,
    });
    assert.deepEqual(limitedResult.prefix.preview, fixture.expected.prefixes.bb.preview);
    assert.deepEqual(limitedResult.prefix.phase, fixture.expected.prefixes.bb.phase);
    assert.deepEqual(limitedResult.prefix.events, [limitedEvent]);
    for (const capability of ['canSaveNumeric', 'canPreviewClosing', 'canApplySource'])
      assert.equal(limitedResult.capabilities[capability], false);
    await assertJournal([limitedEvent], limited);
    await screen('preview', fixture.expected.prefixes.bb.phase, limited);
    await screenRow(fixture.expected.prefixes.bb.preview, limited);
    await close(limited);
    for (const [testId, route] of [
      ['sale-return-replay-open', 'incoming-replay-state'],
      ['sale-return-bill-replay-open', 'incoming-bill-replay-state'],
    ]) {
      const [response] = await Promise.all([
        responseFor('GET', route, limited),
        limited.getByTestId(testId).click(),
      ]);
      assert.equal(response.status(), 200, await response.text());
      assert.equal(await el('open', limited).count(), 0);
      await limited.getByTestId(testId.replace('-open', '-close')).click();
      await el('open', limited).waitFor();
    }
    await unchanged(
      limitedBefore,
      'View-only and original panels leave stored rows unchanged after their own login',
    );
    confirm('view-only-preview-and-old-panels-retained');
    assert.deepEqual(checks, required.checks, 'the exact frozen required check set must execute');
    assert.deepEqual(errors, []);
    const posts = requests.filter((request) => request.method() === 'POST');
    let audit;
    for (let attempt = 0; attempt < 100; attempt++) {
      audit = await owner.$queryRawUnsafe(
        'SELECT action,path,status FROM audit_log WHERE tenant_id=$1 AND path=ANY($2::text[]) ORDER BY id',
        tenantId,
        ['/sales-returns/:vchNo/' + routes.check, '/sales-returns/:vchNo/' + routes.append],
      );
      if (audit.length === posts.length) break;
      await page.waitForTimeout(30);
    }
    assert.equal(
      audit.length,
      posts.length,
      'every actual authenticated preview POST has its own audit row',
    );
    assert(audit.every((row) => row.action === 'POST' && [200, 409, 422].includes(row.status)));
    return {
      checks,
      status: 'passed',
      mockedRequests: 0,
      mockedResponses: 0,
      snapshots,
      auditRows: audit.length,
      acceptedAppends: posts.filter((request) =>
        new URL(request.url()).pathname.endsWith('/' + routes.append),
      ).length,
      limits:
        'This baseline journey does not claim late-response fault or same-session ABA coverage; those are separately required.',
    };
  } finally {
    page.off('request', onRequest);
    page.off('pageerror', onError);
    await restricted?.close();
  }
}
