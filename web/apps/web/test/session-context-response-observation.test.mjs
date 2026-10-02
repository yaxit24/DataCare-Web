import test from 'node:test';
import assert from 'node:assert/strict';
import { EventEmitter } from 'node:events';
import {
  observeJsonResponse,
  prepareJsonResponseObservation,
  requestDocumentPath,
} from './session-context-response-observation.mjs';

/**
 * Replays the Chromium event order that failed the session-context suite on a CI runner: the journey arms a
 * `/me` waiter and navigates from /dashboard to /select, while the dashboard's own `/me` has already received
 * its headers. The navigation cancels that request (net::ERR_ABORTED), then /select fetches its own `/me`.
 */
const origin = 'http://127.0.0.1:4411';
function fakePage(bodies) {
  const session = new EventEmitter();
  session.send = async (method, params) =>
    method === 'Network.getResponseBody'
      ? { body: bodies[params.requestId], base64Encoded: false }
      : {};
  const page = new EventEmitter();
  page.context = () => ({ newCDPSession: async () => session });
  return { page, session };
}
function requestFrom(session, requestId, documentPath) {
  session.emit('Network.requestWillBeSent', {
    requestId,
    documentURL: `${origin}${documentPath}`,
    request: { url: `${origin}/api/me`, method: 'GET', headers: {} },
  });
  session.emit('Network.responseReceived', {
    requestId,
    response: { status: 200, headers: { 'cache-control': 'no-store' }, url: `${origin}/api/me` },
  });
}
const isMe = (response) => new URL(response.request().url()).pathname === '/api/me';

test('a waiter that ignores the issuing document fails on the cancelled /me of the page being left', async () => {
  const { page, session } = fakePage({});
  await prepareJsonResponseObservation(page);
  const observed = observeJsonResponse(
    page,
    (response) => isMe(response) && response.status() === 200,
  );
  requestFrom(session, 'dashboard-me', '/dashboard');
  session.emit('Network.loadingFailed', {
    requestId: 'dashboard-me',
    errorText: 'net::ERR_ABORTED',
  });
  await assert.rejects(observed, /failed before its body completed/);
});

test("a waiter scoped to the new document skips the cancelled request and reads the new page's /me", async () => {
  const { page, session } = fakePage({ 'select-me': '{"context":{"contextEpoch":"3"}}' });
  await prepareJsonResponseObservation(page);
  const observed = observeJsonResponse(
    page,
    (response) =>
      isMe(response) &&
      requestDocumentPath(response.request()) === '/select' &&
      response.status() === 200,
  );
  requestFrom(session, 'dashboard-me', '/dashboard');
  session.emit('Network.loadingFailed', {
    requestId: 'dashboard-me',
    errorText: 'net::ERR_ABORTED',
  });
  requestFrom(session, 'select-me', '/select');
  session.emit('Network.loadingFinished', { requestId: 'select-me' });
  const response = await observed;
  assert.equal(requestDocumentPath(response.request()), '/select');
  assert.equal(response.headers()['cache-control'], 'no-store');
  assert.deepEqual(await response.json(), { context: { contextEpoch: '3' } });
});

test('requestDocumentPath is null when no usable document URL was reported', () => {
  assert.equal(requestDocumentPath({}), null);
  assert.equal(requestDocumentPath({ documentURL: () => undefined }), null);
  assert.equal(requestDocumentPath({ documentURL: () => 'not a url' }), null);
  assert.equal(requestDocumentPath({ documentURL: () => `${origin}/select?x=1` }), '/select');
  // A plain Playwright request has no documentURL; Chromium's Referer names the issuing page.
  assert.equal(
    requestDocumentPath({ headers: () => ({ referer: `${origin}/select` }) }),
    '/select',
  );
  assert.equal(
    requestDocumentPath({
      documentURL: () => `${origin}/dashboard`,
      headers: () => ({ referer: `${origin}/select` }),
    }),
    '/dashboard',
  );
  assert.equal(requestDocumentPath({ headers: () => ({}) }), null);
});
