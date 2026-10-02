/** Test-only Chromium observation. This CDP session owns both the durable buffer and reads.
 * No routes, extra HTTP requests, navigation delays or synthetic response bytes are introduced.
 * Raw request/body/header data remains in bounded memory and is never written to artifacts.
 */
const observers = new WeakMap();
const buffers = Object.freeze({
  maxTotalBufferSize: 8 * 1024 * 1024,
  maxResourceBufferSize: 1024 * 1024,
});
const headerMap = (headers) =>
  Object.freeze(
    Object.fromEntries(
      Object.entries(headers).map(([key, value]) => [key.toLowerCase(), String(value)]),
    ),
  );

export async function prepareJsonResponseObservation(page) {
  if (observers.has(page)) return observers.get(page).ready;
  const requests = new Map();
  const waiters = new Set();
  const counts = { requests: 0, responses: 0, finished: 0, failed: 0 };
  const state = { ready: null, waiters, counts };
  observers.set(page, state);
  state.ready = (async () => {
    const session = await page.context().newCDPSession(page);
    const failAll = (message) => {
      for (const waiter of [...waiters]) waiter.fail(new Error(message));
      requests.clear();
    };
    session.on('Network.requestWillBeSent', (event) => {
      if (!new URL(event.request.url).pathname.startsWith('/api/')) return;
      counts.requests++;
      if (requests.size >= 256 && !requests.has(event.requestId)) {
        failAll('Durable JSON observation exceeded its bounded request inventory');
        return;
      }
      const source = event.request;
      const headers = headerMap(source.headers);
      const postData = source.postData;
      const documentURL = event.documentURL;
      const request = Object.freeze({
        url: () => source.url,
        method: () => source.method,
        headers: () => headers,
        /** The document that issued the request (CDP `documentURL`). */
        documentURL: () => documentURL,
        postDataJSON: () => {
          if (typeof postData !== 'string')
            throw new Error('Actual CDP request JSON was not captured');
          return JSON.parse(postData);
        },
      });
      requests.set(event.requestId, { request, matched: [], response: null });
    });
    session.on('Network.responseReceived', (event) => {
      const entry = requests.get(event.requestId);
      if (!entry) return;
      counts.responses++;
      const source = event.response;
      entry.response = Object.freeze({
        status: () => source.status,
        headers: () => headerMap(source.headers),
        request: () => entry.request,
        url: () => source.url,
      });
      for (const waiter of [...waiters]) {
        if (waiter.matched) continue;
        try {
          if (!waiter.predicate(entry.response)) continue;
          waiter.matched = true;
          entry.matched.push(waiter);
        } catch (error) {
          waiter.fail(error);
        }
      }
    });
    session.on('Network.loadingFinished', (event) => {
      const entry = requests.get(event.requestId);
      requests.delete(event.requestId);
      if (entry) counts.finished++;
      if (!entry?.matched.length) return;
      // Chromium retains this resource outside the renderer. Read from the SAME session that
      // configured durable messages, after loadingFinished establishes body completion.
      void session
        .send('Network.getResponseBody', { requestId: event.requestId })
        .then((result) => {
          const text = result.base64Encoded
            ? Buffer.from(result.body, 'base64').toString('utf8')
            : result.body;
          if (Buffer.byteLength(text, 'utf8') > buffers.maxResourceBufferSize)
            throw new Error('Actual JSON response exceeded the observation bound');
          const json = JSON.parse(text);
          const response = Object.freeze({
            ...entry.response,
            text: async () => text,
            json: async () => json,
          });
          for (const waiter of entry.matched) waiter.succeed(response);
        })
        .catch(() => {
          // Never echo an auth body, URL query, request header or protocol trace in failure output.
          for (const waiter of entry.matched)
            waiter.fail(
              new Error(
                'Could not acquire the actual JSON response from the dedicated durable CDP session',
              ),
            );
        });
    });
    session.on('Network.loadingFailed', (event) => {
      const entry = requests.get(event.requestId);
      requests.delete(event.requestId);
      if (entry) counts.failed++;
      for (const waiter of entry?.matched ?? [])
        waiter.fail(new Error('Actual observed JSON request failed before its body completed'));
    });
    page.once('close', () => failAll('Page closed before its durable JSON observation completed'));
    await session.send('Network.enable', {
      ...buffers,
      maxPostDataSize: 64 * 1024,
    });
    // Local Playwright Chromium protocol documents this dedicated command as the current
    // mechanism for response bodies surviving cross-process navigation. No fallback is used.
    await session.send('Network.configureDurableMessages', buffers);
  })();
  return state.ready;
}

/**
 * The path of the document that issued an observed request, or null when it cannot be told.
 *
 * Reads the CDP `documentURL` this observer records, or, for a plain Playwright request, the Referer header
 * Chromium sends with a same-origin fetch (the web app sets no Referrer-Policy, so it names the full page).
 *
 * A waiter for a request that a navigation will issue must not match the same endpoint fetched by the page
 * being left: that request is cancelled by the navigation (net::ERR_ABORTED), and if its response headers
 * arrived first the waiter has already matched it and fails ("failed before its body completed", or
 * "No resource with given identifier" from `response.json()`). On a slow CI runner the dashboard's own `/me`
 * reached that state while a journey navigated to `/select`.
 */
export function requestDocumentPath(request) {
  const url = request.documentURL?.() || request.headers?.()?.referer;
  if (!url) return null;
  try {
    return new URL(url).pathname;
  } catch {
    return null;
  }
}

export function observeJsonResponse(page, predicate, { timeout = 20_000 } = {}) {
  const state = observers.get(page);
  if (!state) throw new Error('Prepare durable JSON observation before issuing page requests');
  const initialCounts = { ...state.counts };
  let timer;
  const observation = new Promise((resolve, reject) => {
    let settled = false;
    const finish = (callback, value) => {
      if (settled) return;
      settled = true;
      clearTimeout(timer);
      state.waiters.delete(waiter);
      callback(value);
    };
    const waiter = {
      predicate,
      matched: false,
      succeed: (value) => finish(resolve, value),
      fail: (error) => finish(reject, error),
    };
    timer = setTimeout(() => {
      const observed = Object.fromEntries(
        Object.entries(state.counts).map(([key, count]) => [key, count - initialCounts[key]]),
      );
      waiter.fail(
        new Error(
          `Timed out observing the actual durable JSON response (matched=${waiter.matched}; API event counts=${JSON.stringify(observed)})`,
        ),
      );
    }, timeout);
    state.waiters.add(waiter);
  });
  void observation.catch(() => {});
  return observation;
}
