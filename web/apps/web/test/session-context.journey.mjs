import {
  observeJsonResponse,
  prepareJsonResponseObservation,
} from './session-context-response-observation.mjs';
import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';

export const sessionContextFixture = Object.freeze({
  tenantId: 'browser-session-context',
  loginName: 'context-browser',
  year: '2024-2025',
  bookName: 'CONTEXT BROWSER',
  product: '01',
  pendingKey: 'datacare.pending-context-selection.v1',
});
export const sessionContextFixtureTables = Object.freeze([
  'audit_log',
  'auth_session',
  'DESIGN_IDTL',
  'DESIGN_DETL',
  'COL_MAST',
  'CO_SET_NEW',
  'PRODUCT_MAST',
  'ITEM_MAST',
  'USER_SET',
  'LOGIN_MAST',
  'CO_SET',
  'YEAR_MAST',
  'LOCT_MAST',
  'CO_MAST',
]);
export const sessionContextRequiredChecks = Object.freeze([
  'real login bootstraps an exact string epoch and immutable login company',
  'same-scope Open persists one original selection ID and expected epoch before dispatch and bumps once',
  'cancelled Shell company confirmation preserves the mounted draft and performs no selection',
  'confirmed Shell company change uses one exact operation and deliberately navigates',
  'a second tab shares the same session and changes its context through the actual selection UI',
  'old-page business action receives context-stale without automatic retry or draft DOM replacement',
  'A to B to A advances epoch while retaining the original page scope values',
  'an actual late component-default response cannot overwrite the stale page draft',
  'an uncertain committed Shell selection retains the exact recovery request and draft',
  'deliberate recovery navigation loads fresh me before retrying the original operation',
  'exact current receipt retry preserves the epoch and database session row without another open',
  'business configuration and design rows remain byte-observation unchanged throughout',
]);
const digest = (value) => createHash('sha256').update(JSON.stringify(value)).digest('hex');
const uuid = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/;
const pathOf = (request) => new URL(request.url()).pathname;
const selectRequest = (request) =>
  pathOf(request) === '/api/context/select' && request.method() === 'POST';
const nextEpoch = (epoch, increment = 1n) => (BigInt(epoch) + increment).toString();

/** sql is the existing harness convention: owner execute(query, tenantId, ...parameters). */
export async function cleanupSessionContext(sql) {
  for (const table of sessionContextFixtureTables)
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`);
}
export async function seedSessionContext(sql, { passwordHash }) {
  assert.equal(typeof passwordHash, 'string');
  await cleanupSessionContext(sql);
  for (const company of ['01', '02']) {
    await sql(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES($1,$2,$3,'01')`,
      company,
      `Context company ${company}`,
    );
    await sql(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES($1,$2,'01','Main')`,
      company,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,$2,'2024-2025','2024-04-01','2025-03-31')`,
      company,
    );
    // N keeps this browser draft-preservation proof independent of the calendar and posting writes.
    await sql(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LAST_DAY_LOCK") VALUES($1,$2,'N')`,
      company,
    );
    await sql(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES($1,$2,'context-browser',$3,'ADMIN','Y','Y','Y','N')`,
      company,
      passwordHash,
    );
    await sql(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES($1,$2,'01','Context jewellery')`,
      company,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","CON_PRC","OTH_RATE_TYPE","OTH_RATE") VALUES($1,$2,'BASE','Saved context stone','S',0.125,'P',20),($1,$2,'NEXT','Delayed context stone','S',0.75,'F',987.65)`,
      company,
    );
    await sql(
      `INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","OLD_SRNO","DESIGN_NO","ITM_STYLE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_TOUCH","ITM_FINE","ITM_RATE","ITM_AMT","LBR_TYPE","DESIGN_IMG_ID") VALUES($1,$2,'CONTEXT BROWSER','01',17,42,$3,'SAVED',1,10,0,10,0,0,0,0,'N','')`,
      company,
      `CONTEXT-${company}`,
    );
    await sql(
      `INSERT INTO "DESIGN_IDTL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","ISR_NO","DESIGN_NO","IT_CODE","IT_TYPE","IT_PCS","IT_PCS_WT","IT_GWT","IT_CON_PRC","IT_CON_WT","IT_RATE_TYPE","IT_RATE","IT_AMT","IT_NET_AMT") VALUES($1,$2,'CONTEXT BROWSER','01',17,3,$3,'BASE','S',1,0.125,0.125,0.125,0.015625,'P',20,20,20)`,
      company,
      `CONTEXT-${company}`,
    );
  }
}

/** Owner-only observation: no session secrets, cookie values, password hashes or JTI values returned. */
export async function observeSessionContext(owner, tenantId, sessionId) {
  const rows = await owner.$queryRawUnsafe(
    `SELECT session_id AS sid,login_name,login_co_code,co_code,lc_code,co_year,
    context_epoch::text AS epoch,ledger_context,last_context_selection_id,
    last_context_from_epoch::text AS from_epoch,last_context_request_sha256,
    xmin::text AS xmin,ctid::text AS ctid FROM auth_session WHERE tenant_id=$1 AND session_id=$2`,
    tenantId,
    sessionId,
  );
  assert.equal(rows.length, 1);
  return rows[0];
}
export async function snapshotSessionContextBusiness(owner, tenantId) {
  const result = {};
  for (const table of sessionContextFixtureTables.filter(
    (name) => !['auth_session', 'audit_log'].includes(name),
  )) {
    const rows = await owner.$queryRawUnsafe(
      `SELECT to_jsonb(t)::text AS raw,t.xmin::text AS xmin,t.ctid::text AS ctid FROM "${table}" t WHERE tenant_id=$1 ORDER BY to_jsonb(t)::text,t.ctid`,
      tenantId,
    );
    // Complete values and physical-write markers participate; only fingerprints leave this function.
    result[table] = { rows: rows.length, sha256: digest(rows) };
  }
  return result;
}

function gate() {
  let resolve;
  const promise = new Promise((done) => {
    resolve = done;
  });
  return { promise, resolve };
}
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
/** Transport fault only. The entire response is fetched from the real API before it is held.
 * No body/status/header is synthesized. Select response cookies may reach the shared browser
 * context during route.fetch; fresh /select bootstrap also supports refreshing an older bearer. */
async function holdActualResponse(page, match, name, faults) {
  const upstream = gate(),
    released = gate(),
    finished = gate();
  let used = false,
    response,
    upstreamBody;
  const handler = async (route) => {
    if (used || !match(route.request())) return route.fallback();
    used = true;
    try {
      response = await route.fetch({ maxRetries: 0, timeout: 15_000 });
      upstreamBody = await response.json();
      assert.equal(
        response.status(),
        200,
        `${name}: real upstream must succeed before injecting the transport fault`,
      );
      const record = {
        name,
        kind: 'real-upstream-response-hold',
        method: route.request().method(),
        path: pathOf(route.request()),
        upstreamStatus: response.status(),
        upstreamBodySha256: digest(upstreamBody),
        resolution: 'pending',
      };
      faults.push(record);
      upstream.resolve({ request: route.request(), body: upstreamBody });
      const action = await released.promise;
      record.resolution = action;
      if (action === 'abort-after-commit') await route.abort('failed');
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
    async release(action = 'deliver-unchanged') {
      released.resolve(action);
      const value = await bounded(finished.promise, `${name} completion`);
      await page.unroute('**/api/**', handler);
      if (value?.error) throw value.error;
    },
    async cleanup() {
      released.resolve('deliver-unchanged');
      // Drain an already-dispatched real request before the caller tears down its fixtures.
      // A never-used registration has no pending handler and must not wait on this gate.
      try {
        if (used) {
          const value = await bounded(finished.promise, `${name} cleanup drain`);
          if (value?.error) throw value.error;
        }
      } finally {
        await page.unroute('**/api/**', handler);
      }
    },
  };
}

/** Standalone optional journey; caller owns real stack, disposable tenant and screenshot directory.
 * Route registrations are three explicitly counted transport injections, not zero-interception credit.
 * UI actions always use the actual application: no evaluate(import/fetch), synthetic events or body mocks. */
export async function exerciseSessionContext(
  page,
  {
    owner,
    password,
    checkpoint = async () => {},
    onProgress = () => {},
    tenantId = sessionContextFixture.tenantId,
  } = {},
) {
  assert(owner && typeof password === 'string');
  assert.equal(
    tenantId,
    sessionContextFixture.tenantId,
    'Use the separate disposable context fixture tenant',
  );
  const checks = [],
    faults = [],
    transitions = [],
    requests = [],
    pageErrors = [],
    held = [],
    cleanupErrors = [];
  let primaryFailure = false;
  onProgress({
    status: 'running',
    checks,
    transitions,
    transportFaultInjections: faults,
    syntheticBusinessResponses: 0,
    cleanupErrors,
  });
  const watchedPages = new Set();
  const observe = (target) => {
    watchedPages.add(target);
    target.on('pageerror', (error) => pageErrors.push(error.message));
    target.on('request', (request) => {
      if (!pathOf(request).startsWith('/api/')) return;
      requests.push({ page: target, request });
    });
  };
  await prepareJsonResponseObservation(page);
  observe(page);
  const check = (index) => checks.push(sessionContextRequiredChecks[index]);
  const selectPosts = (target) =>
    requests.filter(({ page: source, request }) => source === target && selectRequest(request));
  const field = (target, label) => target.getByLabel(label, { exact: true });
  const style = (target) => field(target, 'Style design 1');
  const pending = (target) =>
    target.evaluate((key) => {
      const raw = sessionStorage.getItem(key);
      return raw === null ? null : JSON.parse(raw);
    }, sessionContextFixture.pendingKey);
  const expectValue = async (locator, value) => {
    await locator.waitFor();
    const deadline = Date.now() + 10_000;
    while ((await locator.inputValue()) !== value && Date.now() < deadline)
      await page.waitForTimeout(50);
    assert.equal(await locator.inputValue(), value);
  };
  const waitOpen = async (target) => {
    await target.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
    await target.getByRole('button', { name: 'Open', exact: true }).waitFor();
    await target.waitForFunction(() => {
      const element = document.querySelector('#context-company');
      return element && !element.disabled;
    });
  };
  const meOnNavigation = async (target, path) => {
    const result = observeJsonResponse(
      target,
      (response) => pathOf(response.request()) === '/api/me' && response.status() === 200,
    );
    await target.goto(path);
    const response = await result;
    assert.equal(response.headers()['cache-control'], 'no-store');
    return response.json();
  };
  const readSession = (id) => observeSessionContext(owner, tenantId, id);
  const assertSelection = (request, before, targetCo) => {
    const body = request.postDataJSON();
    assert.equal(body.expectedContextEpoch, before.epoch);
    assert.match(body.selectionId, uuid);
    assert.equal(body.coCode, targetCo);
    assert.equal(request.headers()['x-session-context-id'], before.sid);
    assert.equal(request.headers()['x-session-context-epoch'], before.epoch);
    assert.deepEqual(
      Object.keys(body).sort(),
      targetCo === before.co_code
        ? ['coCode', 'coYear', 'expectedContextEpoch', 'lcCode', 'selectionId']
        : ['coCode', 'expectedContextEpoch', 'selectionId'],
    );
    return body;
  };
  const openTarget = async (target, company) => {
    const me = await meOnNavigation(target, '/select');
    await waitOpen(target);
    const before = await readSession(me.context.sessionId);
    await field(target, 'Company').selectOption(company);
    const count = selectPosts(target).length;
    const responsePromise = observeJsonResponse(target, (response) =>
      selectRequest(response.request()),
    );
    await target.getByRole('button', { name: 'Open', exact: true }).click();
    const response = await responsePromise;
    assert.equal(response.status(), 200, await response.text());
    const body = assertSelection(response.request(), before, company);
    const value = await response.json();
    assert.equal(value.replayed, false);
    await target.waitForURL('**/dashboard');
    assert.equal(selectPosts(target).length, count + 1);
    const after = await readSession(before.sid);
    assert.equal(after.epoch, nextEpoch(before.epoch));
    assert.equal(after.co_code, company);
    assert.equal(after.login_co_code, '01');
    assert.equal(after.last_context_selection_id, body.selectionId);
    transitions.push({
      name: 'select-ui',
      before: before.epoch,
      after: after.epoch,
      company,
      selectionId: body.selectionId,
    });
    return { before, after, value };
  };
  const loadDesign = async (target, company = '01') => {
    await target.goto('/masters/design-book');
    await field(target, 'Book Name').fill(sessionContextFixture.bookName);
    // LookupPicker schedules an actual request180ms after editing. Complete this setup lookup
    // before another tab changes context; otherwise that background request can freeze the page
    // before the deliberately tested Load action, which would correctly send no request at all.
    const productLookup = observeJsonResponse(target, (response) => {
      const requestUrl = new URL(response.request().url());
      return (
        requestUrl.pathname === '/api/lookup/products' && requestUrl.searchParams.get('q') === '01'
      );
    });
    await target.getByPlaceholder('search products… (F1)', { exact: true }).fill('01');
    assert.equal((await productLookup).status(), 200, 'Complete the real setup product lookup');
    await target.getByRole('button', { name: 'Load', exact: true }).click();
    await target.getByRole('status').filter({ hasText: 'Loaded 1 designs.' }).waitFor();
    await expectValue(field(target, 'Design No design 1'), `CONTEXT-${company}`);
    await expectValue(style(target), 'SAVED');
    await field(target, 'Company').waitFor();
  };
  const confirmNext = (target, accept) => {
    const handled = gate();
    target.once('dialog', async (dialog) => {
      try {
        assert.equal(dialog.type(), 'confirm');
        assert.match(dialog.message(), /unsaved work/i);
        await (accept ? dialog.accept() : dialog.dismiss());
        handled.resolve();
      } catch (error) {
        await dialog.dismiss().catch(() => {});
        handled.resolve({ error });
      }
    });
    return async () => {
      const result = await bounded(handled.promise, 'explicit company confirmation');
      if (result?.error) throw result.error;
    };
  };
  let other;
  const baselineBusiness = await snapshotSessionContextBusiness(owner, tenantId);
  try {
    await page.goto('/login');
    await field(page, 'Company Code').fill('01');
    await field(page, 'User').fill(sessionContextFixture.loginName);
    await field(page, 'Password').fill(password);
    const login = observeJsonResponse(
      page,
      (response) => pathOf(response.request()) === '/api/auth/login',
    );
    await page.getByRole('button', { name: 'Sign In', exact: true }).click();
    const loginResponse = await login;
    assert.equal(loginResponse.status(), 200);
    const initial = await loginResponse.json();
    assert.equal(initial.context.contextEpoch, '1');
    assert.deepEqual(Object.keys(initial.context).sort(), [
      'coCode',
      'coYear',
      'contextEpoch',
      'lcCode',
      'sessionId',
    ]);
    assert.equal(initial.ledgerContext.status, 'unknown');
    assert.equal(initial.ledgerContext.mode, null);
    await waitOpen(page);
    const sessionId = initial.context.sessionId;
    const first = await readSession(sessionId);
    assert.equal(first.login_co_code, '01');
    assert.equal(first.epoch, '1');
    check(0);

    const opening = await holdActualResponse(page, selectRequest, 'same-scope-open', faults);
    held.push(opening);
    await page.getByRole('button', { name: 'Open', exact: true }).click();
    const upstream = await opening.upstream();
    const original = assertSelection(upstream.request, first, '01');
    assert.deepEqual((await pending(page)).request, original);
    assert.equal((await pending(page)).sessionId, sessionId);
    assert.equal(
      await page.getByRole('button', { name: 'Opening…', exact: true }).isDisabled(),
      true,
    );
    assert.equal(selectPosts(page).length, 1);
    assert.equal((await readSession(sessionId)).epoch, '2');
    await opening.release();
    await page.waitForURL('**/dashboard');
    assert.equal(await pending(page), null);
    // Another deliberate same-scope open is a distinct operation and adds exactly one epoch.
    const reopen = await openTarget(page, '01');
    assert.equal(reopen.after.epoch, '3');
    assert.notEqual(reopen.after.last_context_selection_id, original.selectionId);
    check(1);

    await loadDesign(page);
    await style(page).fill('UNSAVED CANCEL');
    await style(page).press('Tab');
    const draftNode = await style(page).elementHandle();
    const cancelCount = selectPosts(page).length;
    const cancelled = confirmNext(page, false);
    await field(page, 'Company').selectOption('02');
    await cancelled();
    await expectValue(field(page, 'Company'), '01');
    await expectValue(style(page), 'UNSAVED CANCEL');
    assert.equal(selectPosts(page).length, cancelCount);
    assert.equal(await draftNode.evaluate((element) => element.isConnected), true);
    check(2);
    const beforeShell = await readSession(sessionId);
    const confirmed = confirmNext(page, true);
    const shellReload = page.waitForNavigation({
      waitUntil: 'domcontentloaded',
    });
    const shellResponsePromise = observeJsonResponse(page, (response) =>
      selectRequest(response.request()),
    );
    await field(page, 'Company').selectOption('02');
    await confirmed();
    const shellResponse = await shellResponsePromise;
    assert.equal(shellResponse.status(), 200);
    assertSelection(shellResponse.request(), beforeShell, '02');
    assert(await shellReload, 'Confirmed Shell selection must fully reload the current document');
    assert.equal(new URL(page.url()).pathname, '/masters/design-book');
    assert.equal((await readSession(sessionId)).epoch, nextEpoch(beforeShell.epoch));
    await expectValue(style(page), '');
    check(3);

    await openTarget(page, '01');
    await loadDesign(page);
    await style(page).fill('RETAIN STALE');
    await style(page).press('Tab');
    const oldNode = await style(page).elementHandle();
    const pinned = await readSession(sessionId);
    other = await page.context().newPage();
    await prepareJsonResponseObservation(other);
    observe(other);
    const changed = await openTarget(other, '02');
    assert.equal(changed.after.sid, sessionId);
    assert.equal(changed.before.epoch, pinned.epoch);
    check(4);
    const loadRequestsBefore = requests.filter(
      ({ page: source, request }) =>
        source === page && pathOf(request) === '/api/masters/design-book',
    ).length;
    const staleResponse = observeJsonResponse(
      page,
      (response) => pathOf(response.request()) === '/api/masters/design-book',
    );
    await page.getByRole('button', { name: 'Load', exact: true }).click();
    const refused = await staleResponse;
    assert.equal(refused.status(), 409);
    assert.equal((await refused.json()).error, 'context-stale');
    assert.equal(refused.request().headers()['x-session-context-epoch'], pinned.epoch);
    await page.getByTestId('context-stale-banner').waitFor();
    await expectValue(style(page), 'RETAIN STALE');
    assert.equal(await oldNode.evaluate((element) => element.isConnected), true);
    assert.equal(
      requests.filter(
        ({ page: source, request }) =>
          source === page && pathOf(request) === '/api/masters/design-book',
      ).length,
      loadRequestsBefore + 1,
    );
    await checkpoint(page, 'session-context-stale-draft');
    check(5);

    await openTarget(other, '01');
    await loadDesign(page);
    await style(page).fill('RETAIN ABA');
    await style(page).press('Tab');
    const beforeABA = await readSession(sessionId);
    const conversion = await field(page, 'Conversion component 1').inputValue();
    const rate = await field(page, 'Rate component 1').inputValue();
    const late = await holdActualResponse(
      page,
      (request) =>
        pathOf(request) === '/api/masters/design-book/component-defaults' &&
        new URL(request.url()).searchParams.get('itCode') === 'NEXT',
      'late-component-defaults-after-ABA',
      faults,
    );
    held.push(late);
    // Item LookupPicker starts its own debounced /lookup/items request as well as the
    // on-blur component-default request. Settle the independent lookup before changing
    // context so the deliberate later Load is the first stale request in this case.
    const itemLookup = observeJsonResponse(page, (response) => {
      const url = new URL(response.request().url());
      return url.pathname === '/api/lookup/items' && url.searchParams.get('q') === 'NEXT';
    });
    await field(page, 'Item component 1').fill('NEXT');
    await field(page, 'Item component 1').press('Tab');
    const delayed = await late.upstream();
    assert.equal((await itemLookup).status(), 200, 'Complete the actual independent item lookup');
    assert.equal(delayed.body.rate, '987.65');
    assert.notEqual(
      delayed.body.rate,
      rate,
      'The held response contains a discriminating different field value',
    );
    await openTarget(other, '02');
    await openTarget(other, '01');
    const afterABA = await readSession(sessionId);
    assert.equal(afterABA.epoch, nextEpoch(beforeABA.epoch, 2n));
    assert.equal(afterABA.co_code, beforeABA.co_code);
    assert.equal(afterABA.lc_code, beforeABA.lc_code);
    assert.equal(afterABA.co_year, beforeABA.co_year);
    check(6);
    const abaRefusedPromise = observeJsonResponse(
      page,
      (response) => pathOf(response.request()) === '/api/masters/design-book',
    );
    await page.getByRole('button', { name: 'Load', exact: true }).click();
    const abaRefused = await abaRefusedPromise;
    assert.equal(abaRefused.status(), 409);
    assert.equal((await abaRefused.json()).error, 'context-stale');
    await page.getByTestId('context-stale-banner').waitFor();
    await late.release();
    await page
      .getByText('Loading component defaults…', { exact: true })
      .waitFor({ state: 'hidden' });
    await expectValue(style(page), 'RETAIN ABA');
    await expectValue(field(page, 'Item component 1'), 'NEXT');
    await expectValue(field(page, 'Conversion component 1'), conversion);
    await expectValue(field(page, 'Rate component 1'), rate);
    await checkpoint(page, 'session-context-aba-late-response');
    check(7);

    // A real successful selection is lost between server commit and the application receiving it.
    await loadDesign(page);
    await style(page).fill('RETAIN UNCERTAIN');
    await style(page).press('Tab');
    const uncertainBefore = await readSession(sessionId);
    const lost = await holdActualResponse(
      page,
      selectRequest,
      'committed-selection-response-lost',
      faults,
    );
    held.push(lost);
    const acknowledge = confirmNext(page, true);
    await field(page, 'Company').selectOption('02');
    await acknowledge();
    const committed = await lost.upstream();
    const recoveryBody = assertSelection(committed.request, uncertainBefore, '02');
    assert.equal(committed.body.replayed, false);
    assert.equal(committed.body.context.contextEpoch, nextEpoch(uncertainBefore.epoch));
    const recoveryRecord = await pending(page);
    assert.deepEqual(recoveryRecord.request, recoveryBody);
    await lost.release('abort-after-commit');
    await page.getByRole('button', { name: 'Check company change', exact: true }).waitFor();
    await page.waitForFunction(() => {
      const button = [...document.querySelectorAll('button')].find(
        (node) => node.textContent === 'Check company change',
      );
      return button && !button.disabled;
    });
    await expectValue(style(page), 'RETAIN UNCERTAIN');
    assert.deepEqual(await pending(page), recoveryRecord);
    const committedRow = await readSession(sessionId);
    assert.equal(committedRow.epoch, nextEpoch(uncertainBefore.epoch));
    await checkpoint(page, 'session-context-uncertain-draft');
    check(8);
    const countBeforeRecovery = selectPosts(page).length;
    const freshMePromise = observeJsonResponse(
      page,
      (response) => pathOf(response.request()) === '/api/me' && response.status() === 200,
    );
    const leave = confirmNext(page, true);
    await page.getByRole('button', { name: 'Check company change', exact: true }).click();
    await leave();
    await page.waitForURL('**/select');
    const freshMeResponse = await freshMePromise;
    const freshMe = await freshMeResponse.json();
    assert.equal(freshMe.context.sessionId, sessionId);
    assert.equal(freshMe.context.contextEpoch, committedRow.epoch);
    await page.getByRole('button', { name: 'Retry saved company change', exact: true }).waitFor();
    await page.waitForFunction(() => {
      const button = [...document.querySelectorAll('button')].find(
        (node) => node.textContent === 'Retry saved company change',
      );
      return button && !button.disabled;
    });
    assert.equal(
      selectPosts(page).length,
      countBeforeRecovery,
      'Full navigation must not automatically resend the pending operation',
    );
    assert.deepEqual(await pending(page), recoveryRecord);
    assert.equal(await field(page, 'Company').isDisabled(), true);
    check(9);
    const beforeRetry = await readSession(sessionId);
    const retryResponsePromise = observeJsonResponse(page, (response) =>
      selectRequest(response.request()),
    );
    await page.getByRole('button', { name: 'Retry saved company change', exact: true }).click();
    const retryResponse = await retryResponsePromise;
    assert.equal(retryResponse.status(), 200, await retryResponse.text());
    assert.deepEqual(retryResponse.request().postDataJSON(), recoveryBody);
    assert.equal(retryResponse.request().headers()['x-session-context-epoch'], beforeRetry.epoch);
    assert.equal(recoveryBody.expectedContextEpoch, uncertainBefore.epoch);
    assert.equal((await retryResponse.json()).replayed, true);
    await page.waitForURL('**/dashboard');
    assert.equal(selectPosts(page).length, countBeforeRecovery + 1);
    assert.deepEqual(
      await readSession(sessionId),
      beforeRetry,
      'Exact receipt recovery performs no auth_session write, including xmin/ctid',
    );
    assert.equal(await pending(page), null);
    await checkpoint(page, 'session-context-recovered');
    check(10);

    assert.deepEqual(await snapshotSessionContextBusiness(owner, tenantId), baselineBusiness);
    check(11);
    assert.deepEqual(pageErrors, []);
    assert.deepEqual(checks, sessionContextRequiredChecks);
    assert.equal(faults.length, 3);
    assert(faults.every((fault) => fault.upstreamStatus === 200 && fault.resolution !== 'pending'));
    return {
      status: 'passed',
      checks,
      transitions,
      transportFaultInjections: faults,
      syntheticBusinessResponses: 0,
      interceptionRegistrations: 3,
      cleanupErrors,
      businessSnapshot: baselineBusiness,
      limits: [
        'Explicit real-response hold/abort faults; not a zero-interception journey.',
        'No general in-flight business transaction cancellation guarantee.',
        'Cross-tab refresh reuse, browser crash recovery and hardware failures are not claimed.',
      ],
    };
  } catch (error) {
    primaryFailure = true;
    throw error;
  } finally {
    for (const hold of held) {
      try {
        await hold.cleanup();
      } catch (error) {
        cleanupErrors.push(error instanceof Error ? error.message : String(error));
      }
    }
    try {
      await other?.close();
    } catch (error) {
      cleanupErrors.push(error instanceof Error ? error.message : String(error));
    }
    // Keep the original test failure; report any secondary drain problem separately.
    if (!primaryFailure && cleanupErrors.length)
      throw new Error(`Transport cleanup failed: ${cleanupErrors.join('; ')}`);
  }
}
