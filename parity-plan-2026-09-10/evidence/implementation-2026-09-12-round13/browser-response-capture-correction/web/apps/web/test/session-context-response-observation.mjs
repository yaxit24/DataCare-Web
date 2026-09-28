/**
 * Test-only real response observation. Start body acquisition in Playwright's response event,
 * before the triggering click/navigation resolves and before the application can intentionally
 * replace its document. Later assertions use the acquired bytes rather than asking Chromium
 * for a response resource after that full navigation discarded it.
 *
 * This registers no route, changes no navigation, performs no additional HTTP request and
 * synthesizes no response bytes/status/headers. A failed real read remains a test failure.
 */
export function observeJsonResponse(page, predicate, { timeout = 20_000 } = {}) {
  let timer;
  const observation = new Promise((resolve, reject) => {
    let matched = false;
    let settled = false;
    const dispose = () => {
      clearTimeout(timer);
      page.off('response', onResponse);
      page.off('close', onClose);
    };
    const fail = (error) => {
      if (settled) return;
      settled = true;
      dispose();
      reject(error);
    };
    const onClose = () => fail(new Error('Page closed before its real JSON response was observed'));
    const onResponse = (response) => {
      if (matched || settled) return;
      let matches;
      try {
        matches = predicate(response);
      } catch (error) {
        fail(error);
        return;
      }
      if (!matches) return;
      matched = true;
      page.off('response', onResponse);
      // Do this FIRST, synchronously in the event callback. Waiting for click(), goto(),
      // a dialog handler, or even an outer promise before starting the read reopens the race.
      let bytesPromise;
      try {
        bytesPromise = response.body();
      } catch (error) {
        fail(error);
        return;
      }
      const status = response.status();
      const headers = Object.freeze({ ...response.headers() });
      const request = response.request();
      const url = response.url();
      Promise.resolve(bytesPromise).then(
        (bytes) => {
          if (settled) return;
          const text = bytes.toString('utf8');
          let json;
          try {
            json = JSON.parse(text);
          } catch {
            fail(
              new Error(
                `Actual response from ${new URL(url).pathname} was not JSON (HTTP ${status})`,
              ),
            );
            return;
          }
          settled = true;
          dispose();
          resolve(
            Object.freeze({
              // Deliberately preserve the small Response interface already used by the fixed
              // assertions. These methods read captured values only; none calls CDP again.
              status: () => status,
              headers: () => headers,
              request: () => request,
              url: () => url,
              text: async () => text,
              json: async () => json,
            }),
          );
        },
        (error) => {
          fail(
            new Error(
              `Could not acquire the actual response from ${new URL(url).pathname} at its response event: ${error instanceof Error ? error.message : String(error)}`,
            ),
          );
        },
      );
    };
    timer = setTimeout(
      () => fail(new Error('Timed out observing the actual JSON response')),
      timeout,
    );
    page.on('response', onResponse);
    page.once('close', onClose);
  });
  // A triggering UI action can itself fail before its caller awaits this promise. Retain the
  // rejection for the eventual assertion while avoiding an unrelated unhandled rejection.
  void observation.catch(() => {});
  return observation;
}
