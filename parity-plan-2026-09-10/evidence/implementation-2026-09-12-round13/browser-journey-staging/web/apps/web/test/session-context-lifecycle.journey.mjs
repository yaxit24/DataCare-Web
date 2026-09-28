import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import {
  observeSessionContext,
  snapshotSessionContextBusiness,
  sessionContextFixture,
} from './session-context.journey.mjs';

export const sessionContextLifecycleRequiredChecks = Object.freeze([
  'late successful selection after client-side Back pauses the document without navigation, draft replacement or recovery erasure',
  'late dropped selection after client-side Back pauses the document and preserves the draft and exact receipt recovery',
]);
const pathOf = (request) => new URL(request.url()).pathname;
const isSelection = (request) =>
  pathOf(request) === '/api/context/select' && request.method() === 'POST';
const sha256 = (value) => createHash('sha256').update(JSON.stringify(value)).digest('hex');
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
async function holdSelection(page, mode, faults) {
  const upstream = gate(),
    released = gate(),
    finished = gate();
  let used = false;
  const handler = async (route) => {
    if (used || !isSelection(route.request())) return route.fallback();
    used = true;
    try {
      const response = await route.fetch({ maxRetries: 0, timeout: 15_000 });
      const body = await response.json();
      assert.equal(
        response.status(),
        200,
        'Only an actual successful upstream selection may enter the transport hold',
      );
      const record = {
        name: `selection-departure-${mode}`,
        kind: 'real-upstream-response-hold',
        upstreamStatus: 200,
        upstreamBodySha256: sha256(body),
        resolution: 'pending',
      };
      faults.push(record);
      upstream.resolve({ request: route.request(), body });
      await released.promise;
      record.resolution = mode === 'success' ? 'deliver-unchanged' : 'abort-after-commit';
      if (mode === 'success') await route.fulfill({ response });
      else await route.abort('failed');
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
      const value = await bounded(upstream.promise, `${mode} real upstream`);
      if (value.error) throw value.error;
      return value;
    },
    async release() {
      released.resolve();
      const value = await bounded(finished.promise, `${mode} transport completion`);
      await page.unroute('**/api/**', handler);
      if (value?.error) throw value.error;
    },
    async cleanup() {
      released.resolve();
      try {
        if (used) {
          const value = await bounded(finished.promise, `${mode} handler drain`);
          if (value?.error) throw value.error;
        }
      } finally {
        await page.unroute('**/api/**', handler);
      }
    },
  };
}

/** Additive only: call after the frozen12-check journey on its still-authenticated page/fixture.
 * Browser Back follows an actual clicked Next Link. No history mutation/router injection is used.
 * Each case has one additional actual response transport fault; no fabricated business response. */
export async function exerciseSessionContextLifecycle(
  page,
  {
    owner,
    tenantId = sessionContextFixture.tenantId,
    checkpoint = async () => {},
    onProgress = () => {},
  } = {},
) {
  assert(owner);
  assert.equal(tenantId, sessionContextFixture.tenantId);
  const checks = [],
    faults = [],
    observations = [],
    cleanupErrors = [],
    holds = [],
    requests = [],
    pageErrors = [];
  let primaryFailure = false;
  const onRequest = (request) => {
    if (pathOf(request).startsWith('/api/')) requests.push(request);
  };
  const onError = (error) => pageErrors.push(error.message);
  page.on('request', onRequest);
  page.on('pageerror', onError);
  onProgress({
    status: 'running',
    checks,
    transportFaultInjections: faults,
    observations,
    cleanupErrors,
  });
  const pending = () =>
    page.evaluate((key) => {
      const value = sessionStorage.getItem(key);
      return value === null ? null : JSON.parse(value);
    }, sessionContextFixture.pendingKey);
  const session = (id) => observeSessionContext(owner, tenantId, id);
  const posts = () => requests.filter(isSelection);
  const confirmNext = () => {
    const handled = gate();
    page.once('dialog', async (dialog) => {
      try {
        assert.equal(dialog.type(), 'confirm');
        assert.match(dialog.message(), /unsaved work/i);
        await dialog.accept();
        handled.resolve();
      } catch (error) {
        await dialog.dismiss().catch(() => {});
        handled.resolve({ error });
      }
    });
    return async () => {
      const value = await bounded(handled.promise, 'explicit company confirmation');
      if (value?.error) throw value.error;
    };
  };
  const waitEnabled = (name) =>
    page.waitForFunction((label) => {
      const element = [...document.querySelectorAll('button')].find(
        (node) => node.textContent.trim() === label,
      );
      return element && !element.disabled;
    }, name);
  const baselineBusiness = await snapshotSessionContextBusiness(owner, tenantId);
  try {
    for (const mode of ['success', 'drop']) {
      // New document and deliberate normal open restore company01; this is not recovery replay.
      const mePromise = page.waitForResponse(
        (response) => pathOf(response.request()) === '/api/me' && response.status() === 200,
      );
      await page.goto('/select');
      const me = await (await mePromise).json();
      await waitEnabled('Open');
      assert.equal(await pending(), null);
      await page.getByLabel('Company', { exact: true }).selectOption('01');
      const normalResponse = page.waitForResponse((response) => isSelection(response.request()));
      await page.getByRole('button', { name: 'Open', exact: true }).click();
      const normal = await normalResponse;
      assert.equal(normal.status(), 200);
      assert.equal((await normal.json()).replayed, false);
      await page.waitForURL('**/dashboard');
      const sessionId = me.context.sessionId;

      // A real Next Link creates a client-side history entry. Browser Back leaves the source
      // route but keeps the document and Shell mounted. No synthetic popstate/history calls.
      await page.goto('/masters/design-book');
      await page.getByLabel('Book Name', { exact: true }).waitFor();
      await page.waitForFunction(() => {
        const element = document.querySelector('select[aria-label="Company"]');
        return element && !element.disabled;
      });
      const documentNode = await page.locator('html').elementHandle();
      const productReads = ['/api/masters/products', '/api/masters/products/meta'].map((path) =>
        page.waitForResponse(
          (response) => pathOf(response.request()) === path && response.status() === 200,
        ),
      );
      await page.getByRole('link', { name: 'Products', exact: true }).click();
      await page.waitForURL('**/masters/products');
      await Promise.all(productReads);
      assert.equal(
        await documentNode.evaluate((node) => node.isConnected),
        true,
        'The actual Next Link kept the document',
      );
      await page.getByLabel('Search records', { exact: true }).fill(`SOURCE ${mode}`);
      const before = await session(sessionId);
      const held = await holdSelection(page, mode, faults);
      holds.push(held);
      const confirmed = confirmNext();
      await page.getByLabel('Company', { exact: true }).selectOption('02');
      await confirmed();
      const committed = await held.upstream();
      const body = committed.request.postDataJSON();
      assert.equal(body.expectedContextEpoch, before.epoch);
      assert.equal(committed.request.headers()['x-session-context-epoch'], before.epoch);
      assert.equal(committed.body.replayed, false);
      assert.equal(committed.body.context.contextEpoch, (BigInt(before.epoch) + 1n).toString());
      const saved = await pending();
      assert.deepEqual(saved.request, body);
      assert.equal(
        await page.getByLabel('Search records', { exact: true }).inputValue(),
        `SOURCE ${mode}`,
      );
      const countAfterDispatch = posts().length;

      await page.goBack();
      await page.waitForURL('**/masters/design-book');
      assert.equal(
        await documentNode.evaluate((node) => node.isConnected),
        true,
        'Browser Back remained in the same document',
      );
      const destination = page.getByLabel('Book Name', { exact: true });
      await destination.waitFor();
      await page.waitForFunction(() => {
        const input = document.querySelector('#design-book-name');
        return input && !input.disabled && !input.closest('fieldset[disabled]');
      });
      await waitEnabled('Check company change');
      assert.equal(
        await page.getByTestId('context-stale-banner').count(),
        0,
        'No prior observation may stand in for the late completion guard',
      );
      const draft = `LATE ${mode.toUpperCase()} DRAFT`;
      await destination.fill(draft);
      const draftNode = await destination.elementHandle();
      assert.deepEqual(await pending(), saved);
      await held.release();
      await page.getByTestId('context-stale-banner').waitFor();
      assert.equal(
        new URL(page.url()).pathname,
        '/masters/design-book',
        'An obsolete origin must not navigate to dashboard',
      );
      assert.equal(
        await documentNode.evaluate((node) => node.isConnected),
        true,
        'No late full navigation occurred',
      );
      assert.equal(
        await draftNode.evaluate((node) => node.isConnected),
        true,
        'The destination draft DOM node remains mounted',
      );
      assert.equal(await destination.inputValue(), draft);
      assert.deepEqual(
        await pending(),
        saved,
        'Late completion must not erase the exact recovery operation',
      );
      assert.equal(
        posts().length,
        countAfterDispatch,
        'Neither departure nor late completion automatically retries selection',
      );
      await waitEnabled('Check company change');
      const beforeBlockedRead = requests.filter(
        (request) => pathOf(request) === '/api/masters/design-book',
      ).length;
      // Supply valid ordinary form inputs, then use its real Load button. The paused API guard
      // must refuse locally before dispatch, rather than letting a local required-field error
      // masquerade as context protection. The base journey separately observes actual server409.
      await page.getByPlaceholder('search products… (F1)', { exact: true }).fill('01');
      await page.getByRole('button', { name: 'Load', exact: true }).click();
      await page
        .getByRole('status')
        .filter({ hasText: /context|reload|company/i })
        .waitFor();
      assert.equal(
        requests.filter((request) => pathOf(request) === '/api/masters/design-book').length,
        beforeBlockedRead,
      );
      assert.equal(await destination.inputValue(), draft);
      assert.deepEqual(await pending(), saved);
      await checkpoint(page, `session-context-departed-${mode}-draft`);

      // Deliberate recovery remains usable despite origin lease loss; exact current receipt only.
      const latestMe = page.waitForResponse(
        (response) => pathOf(response.request()) === '/api/me' && response.status() === 200,
      );
      const leave = confirmNext();
      await page.getByRole('button', { name: 'Check company change', exact: true }).click();
      await leave();
      await page.waitForURL('**/select');
      const current = await (await latestMe).json();
      assert.equal(current.context.contextEpoch, committed.body.context.contextEpoch);
      await waitEnabled('Retry saved company change');
      assert.deepEqual(await pending(), saved);
      assert.equal(posts().length, countAfterDispatch);
      const beforeRetry = await session(sessionId);
      const retryPromise = page.waitForResponse((response) => isSelection(response.request()));
      await page.getByRole('button', { name: 'Retry saved company change', exact: true }).click();
      const retry = await retryPromise;
      assert.equal(retry.status(), 200);
      assert.deepEqual(retry.request().postDataJSON(), body);
      assert.equal(retry.request().headers()['x-session-context-epoch'], beforeRetry.epoch);
      assert.equal((await retry.json()).replayed, true);
      await page.waitForURL('**/dashboard');
      assert.deepEqual(
        await session(sessionId),
        beforeRetry,
        'Recovery does not mutate epoch or the observed session row/xmin/ctid',
      );
      assert.equal(await pending(), null);
      observations.push({
        mode,
        originalEpoch: before.epoch,
        observedEpoch: beforeRetry.epoch,
        originalSelectionId: body.selectionId,
        sameDocumentDeparture: true,
        destinationDraftPreserved: true,
        exactRecovery: true,
      });
      checks.push(sessionContextLifecycleRequiredChecks[mode === 'success' ? 0 : 1]);
    }
    assert.deepEqual(checks, sessionContextLifecycleRequiredChecks);
    assert.deepEqual(pageErrors, []);
    assert.deepEqual(await snapshotSessionContextBusiness(owner, tenantId), baselineBusiness);
    assert.equal(faults.length, 2);
    return {
      status: 'passed',
      checks,
      observations,
      transportFaultInjections: faults,
      syntheticBusinessResponses: 0,
      interceptionRegistrations: 2,
      cleanupErrors,
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
    page.off('request', onRequest);
    page.off('pageerror', onError);
    if (!primaryFailure && cleanupErrors.length)
      throw new Error(`Lifecycle transport cleanup failed: ${cleanupErrors.join('; ')}`);
  }
}
