import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { sessionContextFixtureTables, observeSessionContext } from './session-context.journey.mjs';
import { requestDocumentPath } from './session-context-response-observation.mjs';

const requiredBytes = readFileSync(
  new URL('./fixtures/labour-preview-lifecycle.required.json', import.meta.url),
);
assert.equal(
  createHash('sha256').update(requiredBytes).digest('hex'),
  'ae546150a87578c3937995231e14d3e66f1c2dd0313feb126349f09cb8981795',
);
const required = JSON.parse(requiredBytes);
const fixtureBytes = readFileSync(
  new URL('../../api/test/fixtures/saleReturnLabourReplay.independent.json', import.meta.url),
);
// Qualified storage-shape fixture: source saved-load preserves numeric(12,3) pieces text1.000.
// The original prospective22cdf… fixture and five lifecycle cases remain separately preserved.
assert.equal(
  createHash('sha256').update(fixtureBytes).digest('hex'),
  '8c2e2ba9a985a1e57e353bcbf742e8b350fac47cd34e6cf96f7cb283adbeb78b',
);
const fixture = JSON.parse(fixtureBytes);
export const labourPreviewLifecycleFixture = Object.freeze({
  tenantId: 'browser-labour-faults',
  loginName: 'context-browser',
  voucherNo: '00017',
  coBook: 'RLP',
});
export const labourPreviewLifecycleRequiredChecks = Object.freeze([...required.requiredChecks]);
export const labourPreviewLifecycleTables = Object.freeze([
  ...new Set([
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
    ...sessionContextFixtureTables,
  ]),
]);
const prefix = 'sale-return-labour-replay-';
const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'RLP' };
const paths = {
  state: 'incoming-labour-replay-state',
  check: 'incoming-labour-observation',
  append: 'incoming-labour-replay',
};
const pathname = (request) => new URL(request.url()).pathname;
const matches = (request, route, method = 'POST') =>
  request.method() === method &&
  pathname(request) === `/api/sales-returns/00017/${route}` &&
  new URL(request.url()).searchParams.get('coBook') === 'RLP';
const hash = (value) => createHash('sha256').update(JSON.stringify(value)).digest('hex');
const gate = () => {
  let resolve;
  const promise = new Promise((done) => {
    resolve = done;
  });
  return { promise, resolve };
};
async function bounded(promise, label) {
  let timer;
  try {
    return await Promise.race([
      promise,
      new Promise((_, reject) => {
        timer = setTimeout(() => reject(new Error(`Timed out: ${label}`)), 20_000);
      }),
    ]);
  } finally {
    clearTimeout(timer);
  }
}
/** Actual upstream response only. No response body/status/header is manufactured or edited. */
async function holdActual(page, routeName, name, mode, faults) {
  const upstream = gate(),
    release = gate(),
    finished = gate();
  let used = false;
  const handler = async (route) => {
    if (used || !matches(route.request(), routeName)) return route.fallback();
    used = true;
    try {
      const response = await route.fetch({ maxRetries: 0, timeout: 15_000 });
      const bytes = await response.body();
      const body = JSON.parse(bytes.toString());
      assert.equal(
        response.status(),
        200,
        'Only an actual successful API response can enter this declared transport fault',
      );
      assert((response.headers()['cache-control'] || '').includes('no-store'));
      const record = {
        name,
        kind: 'actual-upstream-response-hold',
        upstreamStatus: response.status(),
        upstreamBodySha256: createHash('sha256').update(bytes).digest('hex'),
        requestBodySha256: hash(route.request().postDataJSON()),
        resolution: 'pending',
      };
      faults.push(record);
      upstream.resolve({ body, request: route.request() });
      await release.promise;
      record.resolution =
        mode === 'drop' ? 'abort-after-successful-upstream-read' : 'deliver-unchanged';
      if (mode === 'drop') await route.abort('failed');
      else await route.fulfill({ response });
      finished.resolve();
    } catch (error) {
      upstream.resolve({ error });
      await route.abort('failed').catch(() => {});
      finished.resolve({ error });
    }
  };
  await page.route('**/api/**', handler);
  return {
    async upstream() {
      const value = await bounded(upstream.promise, `${name} upstream`);
      if (value.error) throw value.error;
      return value;
    },
    async release() {
      release.resolve();
      const value = await bounded(finished.promise, `${name} delivery`);
      await page.unroute('**/api/**', handler);
      if (value?.error) throw value.error;
    },
    async cleanup() {
      release.resolve();
      try {
        if (used) {
          const value = await bounded(finished.promise, `${name} drain`);
          if (value?.error) throw value.error;
        }
      } finally {
        await page.unroute('**/api/**', handler);
      }
    },
  };
}
async function snapshots(owner, tenantId, includeSession) {
  return owner.$transaction(
    async (tx) => {
      const out = {};
      for (const table of labourPreviewLifecycleTables.filter(
        (t) => t !== 'audit_log' && (includeSession || t !== 'auth_session'),
      )) {
        const rows = await tx.$queryRawUnsafe(
          `SELECT to_jsonb(t)::text AS raw,t.xmin::text AS revision,t.ctid::text AS locator FROM "${table}" t WHERE tenant_id=$1 ORDER BY to_jsonb(t)::text,t.ctid`,
          tenantId,
        );
        out[table] = { rows: rows.length, sha256: hash(rows) };
      }
      return out;
    },
    { isolationLevel: 'RepeatableRead' },
  );
}
const flushFrames = (page) =>
  page.evaluate(
    () => new Promise((resolve) => requestAnimationFrame(() => requestAnimationFrame(resolve))),
  );

export async function exerciseLabourPreviewLifecycle(
  page,
  { owner, tenantId, password, checkpoint = async () => {}, onProgress = () => {} } = {},
) {
  assert(owner && typeof owner.$queryRawUnsafe === 'function');
  assert.equal(tenantId, labourPreviewLifecycleFixture.tenantId);
  assert.equal(typeof password, 'string');
  assert(password.length > 0);
  const checks = [],
    faults = [],
    observations = [],
    cleanupErrors = [],
    holds = [],
    requests = [],
    pageErrors = [];
  let peer,
    primaryFailure = false;
  const el = (name, target = page) => target.getByTestId(prefix + name);
  const onRequest = (request) => {
    if (pathname(request).startsWith('/api/')) requests.push(request);
  };
  const onError = (error) => pageErrors.push(error.message);
  page.on('request', onRequest);
  page.on('pageerror', onError);
  const progress = () =>
    onProgress({
      status: 'running',
      checks,
      transportFaultInjections: faults,
      observations,
      cleanupErrors,
    });
  const confirm = (id) => {
    const expectedCase = required.cases[checks.length];
    assert(expectedCase, 'No undeclared lifecycle case can be credited');
    assert.equal(
      expectedCase.id,
      id,
      'Record the explicit frozen case at its own assertion boundary',
    );
    assert.equal(expectedCase.check, labourPreviewLifecycleRequiredChecks[checks.length]);
    checks.push(expectedCase.check);
    progress();
  };
  const posts = (route) => requests.filter((r) => matches(r, route));
  const responseFor = (route, method = 'POST', target = page) =>
    target.waitForResponse((response) => matches(response.request(), route, method));
  const json = async (response, status = 200) => {
    const body = await response.json();
    assert.equal(response.status(), status, JSON.stringify(body));
    assert((response.headers()['cache-control'] || '').includes('no-store'));
    return body;
  };
  const count = async (expected) => {
    await el('status')
      .filter({ hasText: `${expected} field changes previewed in order.` })
      .waitFor();
    assert.match(
      await el('status').textContent(),
      new RegExp(`^${expected} field changes previewed in order\\.`),
    );
    assert.equal(await el('events').locator('li').count(), expected);
  };
  const candidate = async (code) => {
    await el('candidate')
      .filter({ hasText: `Checked code ${code} ·` })
      .waitFor();
    assert.match(await el('candidate').textContent(), new RegExp(`Checked code ${code} ·`));
  };
  const value = async (column, text) => {
    await el(`value-${column}-preview`).filter({ hasText: text }).waitFor();
    assert.equal((await el(`value-${column}-preview`).textContent()).trim(), text);
  };
  const metadataFrozen = async () => {
    assert.equal(await page.getByTestId('sale-return-saved-save').isDisabled(), true);
    assert.equal(
      await page.getByTestId('sale-return-saved-book').getByLabel('Configured book').isDisabled(),
      true,
    );
  };
  const readMe = async (target) => {
    // Only the /me of the /select document: the page being left may still be fetching its own /me,
    // which the navigation cancels (see requestDocumentPath).
    const waiting = target.waitForResponse(
      (r) =>
        pathname(r.request()) === '/api/me' &&
        requestDocumentPath(r.request()) === '/select' &&
        r.status() === 200,
    );
    await target.goto('/select');
    const body = await (await waiting).json();
    await target.getByRole('button', { name: 'Open', exact: true }).waitFor();
    return body;
  };
  const selectCompany = async (target, company) => {
    const me = await readMe(target);
    await target.getByLabel('Company', { exact: true }).selectOption(company);
    const [response] = await Promise.all([
      target.waitForResponse(
        (r) => pathname(r.request()) === '/api/context/select' && r.request().method() === 'POST',
      ),
      target.getByRole('button', { name: 'Open', exact: true }).click(),
    ]);
    assert.equal(response.status(), 200);
    assert.equal(response.request().postDataJSON().expectedContextEpoch, me.context.contextEpoch);
    await target.waitForURL('**/dashboard');
    const persisted = await observeSessionContext(owner, tenantId, me.context.sessionId);
    assert.equal(persisted.epoch, (BigInt(me.context.contextEpoch) + 1n).toString());
    assert.equal(persisted.co_code, company);
    return { me, persisted };
  };
  let state, accepted;
  const open = async () => {
    const [response] = await Promise.all([responseFor(paths.state, 'GET'), el('open').click()]);
    state = await json(response);
    assert.deepEqual(state.scope, scope);
    assert.equal(state.rows.length, 1);
    assert.equal(state.capabilities.canPreview, true);
    assert.equal(state.billReplay.rowReplay.rows[0].identity.srNo, '17');
    accepted = {
      prefixVersion: state.rows[0].initialPrefixVersion,
      events: [],
      preview: fixture.expected.initial,
      phase: fixture.expected.opened,
    };
    await el('entry').waitFor();
    await count(0);
    return state;
  };
  const load = async () => {
    await page.goto('/txn/sale-return');
    await page.getByRole('button', { name: 'Saved returns', exact: true }).click();
    const book = page.getByTestId('sale-return-saved-book').getByLabel('Configured book');
    await book.locator('option[value="RLP"]').waitFor({ state: 'attached' });
    await book.selectOption('RLP');
    await page.getByTestId('sale-return-saved-voucher').fill('00017');
    const [response] = await Promise.all([
      responseFor('incoming', 'GET'),
      page.getByTestId('sale-return-saved-load').click(),
    ]);
    assert.equal(response.status(), 200);
    const saved = await response.json();
    await page.getByTestId('sale-return-saved-context').waitFor();
    await open();
    assert.equal(state.documentVersion, saved.version);
  };
  const reopen = async () => {
    await el('close').click();
    await el('open').waitFor();
    await open();
  };
  const oldInput = () => ({
    baseVersion: state.baseVersion,
    rowIdentity: state.rows[0].rowIdentity,
    prefixVersion: accepted.prefixVersion,
    events: structuredClone(accepted.events),
  });
  const draft = async (text) => {
    if ((await el('field').inputValue()) !== 'x13.primary-incoming.c13')
      await el('field').selectOption('x13.primary-incoming.c13');
    await el('entry').fill(text);
  };
  const check = async (text) => {
    await draft(text);
    const old = oldInput();
    const [response] = await Promise.all([responseFor(paths.check), el('check').click()]);
    const body = await json(response);
    assert.deepEqual(response.request().postDataJSON(), {
      ...old,
      fieldId: 'x13.primary-incoming.c13',
      editorText: text,
    });
    assert.equal(body.editorText, text);
    assert.equal(body.prefixVersion, old.prefixVersion);
    await candidate(text);
    return body;
  };
  const commit = async (observation, golden) => {
    const old = oldInput();
    const event = {
      kind: 'labourEnter',
      fieldId: 'x13.primary-incoming.c13',
      editorText: observation.editorText,
      observationVersion: observation.observationVersion,
    };
    const [response] = await Promise.all([responseFor(paths.append), el('commit').click()]);
    const body = await json(response);
    assert.deepEqual(response.request().postDataJSON(), { ...old, event });
    assert.deepEqual(body.prefix.events, [...old.events, event]);
    assert.deepEqual(body.prefix.preview, golden.preview);
    assert.deepEqual(body.prefix.phase, golden.phase);
    assert.equal(body.capabilities.canSaveNumeric, false);
    accepted = body.prefix;
    await count(accepted.events.length);
    await value(13, event.editorText);
    return body;
  };
  const startHold = async (route, name, mode = 'deliver') => {
    const held = await holdActual(page, route, name, mode, faults);
    holds.push(held);
    return held;
  };
  progress();
  try {
    await page.goto('/login');
    await page.getByLabel('User', { exact: true }).fill(labourPreviewLifecycleFixture.loginName);
    await page.getByLabel('Password', { exact: true }).fill(password);
    await page.getByRole('button', { name: 'Sign In', exact: true }).click();
    await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
    // Wait for initial selection to be genuinely enabled, not merely a visible loading label.
    await page.getByRole('button', { name: 'Open', exact: true }).click();
    await page.waitForURL('**/dashboard');
    await load();
    const originalContext = structuredClone(state.context);
    const originalBusiness = await snapshots(owner, tenantId, false);
    const beforeFaults = await snapshots(owner, tenantId, true);

    // U04: a newer candidate must survive the old response and old finally callback.
    const changing = await startHold(paths.check, 'U04-lookup-draft-replaced');
    await draft('BB');
    await el('check').click();
    const changingUpstream = await changing.upstream();
    assert.equal(changingUpstream.body.editorText, 'BB');
    assert.equal(await el('entry').isDisabled(), false);
    await el('entry').fill('AA');
    const aa = await check('AA');
    const candidateNode = await el('candidate').elementHandle();
    const appendsBeforeDraftDelivery = posts(paths.append).length;
    const oldDelivered = responseFor(paths.check);
    await changing.release();
    const oldReply = await oldDelivered;
    assert.deepEqual(await json(oldReply), changingUpstream.body);
    assert.equal(await oldReply.finished(), null);
    await flushFrames(page);
    assert.equal(await el('entry').inputValue(), 'AA');
    await candidate('AA');
    await count(0);
    await metadataFrozen();
    assert.equal(
      posts(paths.append).length,
      appendsBeforeDraftDelivery,
      'Late BB lookup must not dispatch an append',
    );
    assert.equal(await candidateNode.evaluate((node) => node.isConnected), true);
    await commit(aa, fixture.expected.prefixes['same-aa']);
    confirm('U04');

    // U05: same raw document and base can reopen, but the prior generation is no longer current.
    await reopen();
    const closedOldPrefix = oldInput();
    const closing = await startHold(paths.check, 'U05-lookup-close-reopen');
    await draft('BB');
    await el('check').click();
    const closingUpstream = await closing.upstream();
    await el('close').click();
    await el('open').waitFor();
    await flushFrames(page);
    assert.equal(await el('open').evaluate((node) => node === document.activeElement), true);
    await open();
    const newAA = await check('AA');
    await commit(newAA, fixture.expected.prefixes['same-aa']);
    assert.notEqual(accepted.prefixVersion, closedOldPrefix.prefixVersion);
    await flushFrames(page); // Drain the legitimate current commit's own focus callback.
    await el('check').focus();
    const focusNode = await el('check').elementHandle();
    const appendsBeforeClosedDelivery = posts(paths.append).length;
    const closedDelivery = responseFor(paths.check);
    await closing.release();
    const closedReply = await closedDelivery;
    assert.deepEqual(await json(closedReply), closingUpstream.body);
    assert.equal(await closedReply.finished(), null);
    await flushFrames(page);
    await count(1);
    await value(13, 'AA');
    assert.equal(await el('entry').inputValue(), 'AA');
    assert.equal(await el('candidate').count(), 0);
    await metadataFrozen();
    assert.equal(
      posts(paths.append).length,
      appendsBeforeClosedDelivery,
      'Closed generation must not dispatch an append',
    );
    assert.equal(
      await focusNode.evaluate((node) => node === document.activeElement && node.isConnected),
      true,
    );
    confirm('U05');

    // U06: the real Next Link unmounts the Return panel while retaining the browser document.
    await reopen();
    const leaving = await startHold(paths.check, 'U06-lookup-route-departure');
    await draft('BB');
    await el('check').click();
    const leavingUpstream = await leaving.upstream();
    const documentNode = await page.locator('html').elementHandle();
    const productReads = ['/api/masters/products', '/api/masters/products/meta'].map((path) =>
      page.waitForResponse((r) => pathname(r.request()) === path && r.status() === 200),
    );
    await page.getByRole('link', { name: 'Products', exact: true }).click();
    await page.waitForURL('**/masters/products');
    await Promise.all(productReads);
    assert.equal(await documentNode.evaluate((node) => node.isConnected), true);
    const search = page.getByLabel('Search records', { exact: true });
    await search.fill('LABOUR DEPARTURE DRAFT');
    const destinationNode = await search.elementHandle();
    const appendsBeforeDepartureDelivery = posts(paths.append).length;
    const lateDelivery = responseFor(paths.check);
    await leaving.release();
    const lateReply = await lateDelivery;
    assert.deepEqual(await json(lateReply), leavingUpstream.body);
    assert.equal(await lateReply.finished(), null);
    await flushFrames(page);
    assert.equal(new URL(page.url()).pathname, '/masters/products');
    assert.equal(await search.inputValue(), 'LABOUR DEPARTURE DRAFT');
    assert.equal(
      await destinationNode.evaluate((node) => node.isConnected && node === document.activeElement),
      true,
    );
    assert.equal(
      posts(paths.append).length,
      appendsBeforeDepartureDelivery,
      'Unmounted lookup must not dispatch an append',
    );
    assert.equal(await el('entry').count(), 0);
    assert.equal(await page.getByTestId('context-stale-banner').count(), 0);
    await checkpoint(page, 'labour-lifecycle-departure');
    confirm('U06');

    // U12: server completed a read-only append, but its actual response is lost in transport.
    await load();
    const bb = await check('BB');
    const preLost = oldInput();
    const lookupsBeforeLoss = posts(paths.check).length;
    const lost = await startHold(paths.append, 'U12-append-reply-lost', 'drop');
    const appendsBeforeLoss = posts(paths.append).length;
    await el('commit').click();
    const lostUpstream = await lost.upstream();
    const lostBody = lostUpstream.request.postDataJSON(),
      lostText = lostUpstream.request.postData();
    assert.deepEqual(lostBody, {
      ...preLost,
      event: {
        kind: 'labourEnter',
        fieldId: 'x13.primary-incoming.c13',
        editorText: 'BB',
        observationVersion: bb.observationVersion,
      },
    });
    assert.deepEqual(lostUpstream.body.prefix.preview, fixture.expected.prefixes.bb.preview);
    assert.deepEqual(lostUpstream.body.prefix.phase, fixture.expected.prefixes.bb.phase);
    await lost.release();
    await el('error').waitFor();
    await flushFrames(page);
    await count(0);
    await candidate('BB');
    assert.equal(await el('entry').inputValue(), 'BB');
    assert.equal(posts(paths.append).length, appendsBeforeLoss + 1);
    const [retryResponse] = await Promise.all([responseFor(paths.append), el('commit').click()]);
    const retried = await json(retryResponse);
    assert.equal(retryResponse.request().postData(), lostText);
    assert.deepEqual(retryResponse.request().postDataJSON(), lostBody);
    assert.deepEqual(retried.prefix, lostUpstream.body.prefix);
    assert.equal(posts(paths.check).length, lookupsBeforeLoss);
    assert.equal(posts(paths.append).length, appendsBeforeLoss + 2);
    accepted = retried.prefix;
    await count(1);
    await value(13, 'BB');
    assert.equal(await el('events').locator('li').count(), 1);
    observations.push({
      case: 'U12',
      originalRequestSha256: hash(lostBody),
      retriedRequestSha256: hash(retryResponse.request().postDataJSON()),
      prefixSha256: hash(retried.prefix),
      automaticRetries: 0,
    });
    assert.deepEqual(await snapshots(owner, tenantId, true), beforeFaults);
    await checkpoint(page, 'labour-lifecycle-retry');
    confirm('U12');

    // Cross-tab state has no push channel. Detect the changed epoch using a real subsequent request.
    await el('entry').fill('AA');
    const retainedEntry = await el('entry').elementHandle();
    const retainedStatus = await el('status').elementHandle();
    const beforeContext = await observeSessionContext(owner, tenantId, state.context.sessionId);
    peer = await page.context().newPage();
    peer.on('pageerror', onError);
    const reopened = await selectCompany(peer, '01');
    assert.equal(reopened.me.context.sessionId, originalContext.sessionId);
    await selectCompany(peer, '02');
    const restored = await selectCompany(peer, '01');
    assert.equal(restored.persisted.epoch, (BigInt(beforeContext.epoch) + 3n).toString());
    assert.equal(restored.persisted.co_code, '01');
    assert.equal(
      await page.getByTestId('context-stale-banner').count(),
      0,
      'No background push detection is claimed before a new request',
    );
    assert.equal(await el('entry').inputValue(), 'AA');
    await count(1);
    const oldCount = posts(paths.check).length;
    const [staleResponse] = await Promise.all([responseFor(paths.check), el('check').click()]);
    const stale = await json(staleResponse, 409);
    assert.equal(stale.error, 'context-stale');
    assert.equal(
      staleResponse.request().headers()['x-session-context-epoch'],
      state.context.contextEpoch,
    );
    await page.getByTestId('context-stale-banner').waitFor();
    await flushFrames(page);
    assert.equal(await el('entry').inputValue(), 'AA');
    await count(1);
    await value(13, 'BB');
    assert.equal(await retainedEntry.evaluate((node) => node.isConnected), true);
    assert.equal(await retainedStatus.evaluate((node) => node.isConnected), true);
    assert.equal(await el('check').isDisabled(), true);
    assert.equal(await el('commit').isDisabled(), true);
    assert.equal(posts(paths.check).length, oldCount + 1);
    assert.deepEqual(await snapshots(owner, tenantId, false), originalBusiness);
    observations.push({
      case: 'U_CONTEXT',
      oldContext: state.context,
      finalContext: {
        sessionId: restored.persisted.sid,
        contextEpoch: restored.persisted.epoch,
        coCode: restored.persisted.co_code,
      },
      automaticRetries: 0,
      detection: 'subsequent actual request with retained headers',
    });
    await checkpoint(page, 'labour-lifecycle-stale-prefix');
    confirm('U_CONTEXT');

    const previewPosts = requests.filter(
      (r) => matches(r, paths.check) || matches(r, paths.append),
    );
    let audits = [];
    for (let attempt = 0; attempt < 100; attempt++) {
      audits = await owner.$queryRawUnsafe(
        'SELECT action,path,status FROM audit_log WHERE tenant_id=$1 AND path=ANY($2::text[]) ORDER BY id',
        tenantId,
        [`/sales-returns/:vchNo/${paths.check}`, `/sales-returns/:vchNo/${paths.append}`],
      );
      if (audits.length === previewPosts.length - 1) break;
      await page.waitForTimeout(30);
    }
    // requireAuth refuses the final retained-header request before state.session exists.
    // Every other preview POST reached authenticated request audit, including lost reply + retry.
    assert.equal(audits.length, previewPosts.length - 1);
    assert(audits.every((row) => row.action === 'POST' && row.status === 200));
    assert.equal(
      posts(paths.check).length,
      7,
      'Six explicit lookup checks plus one pre-session stale refusal',
    );
    assert.equal(
      posts(paths.append).length,
      4,
      'Two AA commits plus lost BB append and its one explicit retry',
    );
    assert.equal(
      audits.filter((row) => row.path === `/sales-returns/:vchNo/${paths.check}`).length,
      6,
    );
    assert.equal(
      audits.filter((row) => row.path === `/sales-returns/:vchNo/${paths.append}`).length,
      4,
    );

    assert.deepEqual(checks, labourPreviewLifecycleRequiredChecks);
    assert.equal(faults.length, 4);
    assert.deepEqual(pageErrors, []);
    return {
      status: 'passed',
      checks,
      transportFaultInjections: faults,
      syntheticBusinessResponses: 0,
      observations,
      cleanupErrors,
      previewPosts: previewPosts.length,
      previewAuditRows: audits.length,
      observedPreSessionContextRefusals: 1,
      businessSnapshotTables: Object.keys(originalBusiness).length,
      limitations: required.proofBoundaries,
    };
  } catch (error) {
    primaryFailure = true;
    throw error;
  } finally {
    for (const hold of holds) {
      try {
        await hold.cleanup();
      } catch (error) {
        cleanupErrors.push(error instanceof Error ? error.message : String(error));
      }
    }
    try {
      await peer?.close();
    } catch (error) {
      cleanupErrors.push(error instanceof Error ? error.message : String(error));
    }
    page.off('request', onRequest);
    page.off('pageerror', onError);
    if (!primaryFailure && cleanupErrors.length)
      throw new Error(`Transport cleanup failed: ${cleanupErrors.join('; ')}`);
  }
}
