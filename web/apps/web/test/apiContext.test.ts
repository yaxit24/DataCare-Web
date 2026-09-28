import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import independent from './fixtures/pageContext.independent.json';

const A = independent.contexts.A;
const B = independent.contexts.B;
const response = (body: unknown, status = 200) =>
  new Response(JSON.stringify(body), { status, headers: { 'content-type': 'application/json' } });
function deferred<T>() {
  let resolve!: (value: T) => void;
  let reject!: (reason?: unknown) => void;
  const promise = new Promise<T>((yes, no) => {
    resolve = yes;
    reject = no;
  });
  return { promise, resolve, reject };
}
const settle = <T>(promise: Promise<T>) =>
  promise.then(
    (value) => ({ value, error: undefined }),
    (error: unknown) => ({ value: undefined, error }),
  );

describe('page-pinned API transport (controlled fetch; no real HTTP/browser acceptance)', () => {
  let api: typeof import('../lib/api');
  let fetcher: ReturnType<typeof vi.fn<typeof fetch>>;
  beforeEach(async () => {
    vi.resetModules();
    fetcher = vi.fn<typeof fetch>();
    vi.stubGlobal('fetch', fetcher);
    api = await import('../lib/api');
  });
  afterEach(() => {
    vi.restoreAllMocks();
    vi.unstubAllGlobals();
  });
  const headersAt = (index: number) => new Headers(fetcher.mock.calls[index]?.[1]?.headers);
  const headersMatch = (index: number, context = A) => {
    expect(headersAt(index).get('x-session-context-id')).toBe(context.sessionId);
    expect(headersAt(index).get('x-session-context-epoch')).toBe(context.contextEpoch);
  };

  it('A01 GET/POST/PUT/DELETE carry page headers while complete business payload bytes stay unchanged', async () => {
    api.pinPageContext(A);
    fetcher.mockImplementation(async () => response({ ok: true }));
    const body = {
      coCode: '01',
      lcCode: '01',
      coYear: '2024-2025',
      raw: null,
      amount: '9999999999999999.99',
    };
    await api.get('/orders');
    await api.post('/orders', body);
    await api.put('/orders/00001', body);
    await api.del('/orders/00001', body);
    expect(fetcher).toHaveBeenCalledTimes(4);
    for (let i = 0; i < 4; i++) headersMatch(i);
    for (let i = 1; i < 4; i++) expect(fetcher.mock.calls[i]?.[1]?.body).toBe(JSON.stringify(body));
    expect(fetcher.mock.calls[0]?.[1]?.body).toBeUndefined();
  });

  it('A02 same-context refresh retries exactly the original POST once', async () => {
    api.pinPageContext(A);
    fetcher
      .mockResolvedValueOnce(response({ error: 'unauthorized' }, 401))
      .mockResolvedValueOnce(response({ context: A }))
      .mockResolvedValueOnce(response({ saved: true }));
    const body = { version: 'original-version', lines: [{ oldSrNo: '31', amount: '120.00' }] };
    await expect(api.post('/orders', body)).resolves.toEqual({ saved: true });
    expect(fetcher).toHaveBeenCalledTimes(3);
    expect(fetcher.mock.calls[1]?.[0]).toBe('/api/auth/refresh');
    expect(fetcher.mock.calls[0]?.[1]?.body).toBe(fetcher.mock.calls[2]?.[1]?.body);
    for (let i = 0; i < 3; i++) headersMatch(i);
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: A, revision: 1 });
  });

  it('A03 a different refreshed context refuses the old draft without an automatic retry', async () => {
    api.pinPageContext(A);
    fetcher
      .mockResolvedValueOnce(response({ error: 'unauthorized' }, 401))
      .mockResolvedValueOnce(response({ context: B }));
    await expect(
      api.post('/orders', { originalDraft: 'retained', coCode: '01' }),
    ).rejects.toMatchObject({ code: 'context-stale' });
    expect(fetcher).toHaveBeenCalledTimes(2);
    expect(api.getPageContextState()).toMatchObject({
      status: 'stale',
      context: A,
      observed: B,
      reason: 'context-changed',
    });
  });

  it('A04 malformed successful refresh context is contained without an old-draft retry', async () => {
    api.pinPageContext(A);
    fetcher
      .mockResolvedValueOnce(response({ error: 'unauthorized' }, 401))
      .mockResolvedValueOnce(response({ context: { ...A, contextEpoch: 7 } }));
    await expect(api.put('/orders/00001', { amount: '2.00' })).rejects.toMatchObject({
      code: 'context-stale',
    });
    expect(fetcher).toHaveBeenCalledTimes(2);
    expect(api.getPageContextState()).toMatchObject({
      status: 'stale',
      context: A,
      reason: 'invalid-context-response',
    });
  });

  it('A05 concurrent401 requests share one refresh and each retries its original bytes', async () => {
    api.pinPageContext(A);
    const refresh = deferred<Response>();
    const started = deferred<void>();
    const count = new Map<string, number>();
    fetcher.mockImplementation(async (url) => {
      const key = String(url);
      if (key === '/api/auth/refresh') {
        started.resolve();
        return refresh.promise;
      }
      const n = (count.get(key) ?? 0) + 1;
      count.set(key, n);
      return n === 1 ? response({ error: 'unauthorized' }, 401) : response({ path: key });
    });
    const first = settle(api.post('/one', { draft: 'one' }));
    const second = settle(api.post('/two', { draft: 'two' }));
    await started.promise;
    await new Promise<void>((resolve) => setTimeout(resolve, 0));
    refresh.resolve(response({ context: A }));
    expect((await first).value).toEqual({ path: '/api/one' });
    expect((await second).value).toEqual({ path: '/api/two' });
    expect(fetcher.mock.calls.filter(([url]) => url === '/api/auth/refresh')).toHaveLength(1);
    for (const path of ['/api/one', '/api/two']) {
      const calls = fetcher.mock.calls.filter(([url]) => url === path);
      expect(calls).toHaveLength(2);
      expect(calls[0]?.[1]?.body).toBe(calls[1]?.[1]?.body);
    }
  });

  it('A06 a retried401 does not rotate refresh again', async () => {
    api.pinPageContext(A);
    fetcher
      .mockResolvedValueOnce(response({ error: 'unauthorized' }, 401))
      .mockResolvedValueOnce(response({ context: A }))
      .mockResolvedValueOnce(response({ error: 'still-unauthorized' }, 401));
    await expect(api.get('/orders')).rejects.toMatchObject({
      status: 401,
      body: { error: 'still-unauthorized' },
    });
    expect(fetcher).toHaveBeenCalledTimes(3);
  });

  it.each([200, 409])(
    'A07/A08 late%s from old ticket cannot populate or poison the new ready page',
    async (status) => {
      api.pinPageContext(A);
      const held = deferred<Response>();
      fetcher.mockReturnValueOnce(held.promise);
      const pending = settle(api.get('/orders'));
      api.resetPageContextForNavigation();
      api.pinPageContext(B);
      held.resolve(
        response(status === 200 ? { rows: ['old-company'] } : { error: 'context-stale' }, status),
      );
      expect((await pending).error).toMatchObject({ code: 'context-response-obsolete' });
      expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: B });
    },
  );

  it('A09 /me bootstrap pins identity and discards previously unbound list results', async () => {
    const held = deferred<Response>();
    fetcher.mockImplementation(async (url) =>
      url === '/api/me' ? response({ user: 'operator', context: A }) : held.promise,
    );
    const list = settle(api.get('/context/companies'));
    await expect(api.get('/me')).resolves.toMatchObject({ context: A });
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: A });
    held.resolve(response([{ CO_CODE: '01' }]));
    expect((await list).error).toMatchObject({ code: 'context-response-obsolete' });
  });

  it('A10 an unbound/me401 can establish the descriptor through refresh and retry only/me', async () => {
    fetcher
      .mockResolvedValueOnce(response({ error: 'unauthorized' }, 401))
      .mockResolvedValueOnce(response({ context: A }))
      .mockResolvedValueOnce(response({ user: 'operator', context: A }));
    await expect(api.get('/me')).resolves.toMatchObject({ context: A });
    expect(headersAt(0).has('x-session-context-id')).toBe(false);
    expect(headersAt(1).has('x-session-context-id')).toBe(false);
    headersMatch(2);
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: A, revision: 1 });
  });

  it('A11 current server context-stale marks the page stale and blocks further dispatch', async () => {
    api.pinPageContext(A);
    fetcher.mockResolvedValueOnce(response({ error: 'context-stale' }, 409));
    await expect(api.get('/orders')).rejects.toMatchObject({ code: 'context-stale' });
    await expect(api.post('/orders', { amount: '5.00' })).rejects.toMatchObject({
      code: 'context-stale',
    });
    expect(fetcher).toHaveBeenCalledTimes(1);
    expect(api.getPageContextState()).toMatchObject({
      status: 'stale',
      context: A,
      reason: 'server-context-stale',
    });
  });

  it('A12 explicit login/logout are unpinned controls and never adopt a new page identity', async () => {
    api.pinPageContext(A);
    api.pinPageContext(B);
    fetcher.mockImplementation(async () => response({ context: B }));
    await api.post('/auth/login', { user: 'new-login' });
    await api.post('/auth/logout');
    for (let i = 0; i < 2; i++) {
      expect(headersAt(i).has('x-session-context-id')).toBe(false);
      expect(headersAt(i).has('x-session-context-epoch')).toBe(false);
    }
    expect(api.getPageContextState()).toMatchObject({ status: 'stale', context: A });
  });

  it('A13 successful selection leaves deliberate navigation and descriptor adoption to its owner', async () => {
    api.pinPageContext(A);
    fetcher.mockResolvedValueOnce(response({ context: B }));
    const original = {
      expectedContextEpoch: '7',
      selectionId: '33333333-3333-4333-8333-333333333333',
      coCode: '02',
    };
    await expect(api.post('/context/select', original)).resolves.toEqual({ context: B });
    expect(fetcher.mock.calls[0]?.[1]?.body).toBe(JSON.stringify(original));
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: A });
  });

  it('A14 context change during PDF body loading prevents a download', async () => {
    api.pinPageContext(A);
    const held = deferred<Blob>();
    const reading = deferred<void>();
    const pdf = new Response('pdf');
    vi.spyOn(pdf, 'blob').mockImplementation(() => {
      reading.resolve();
      return held.promise;
    });
    fetcher.mockResolvedValueOnce(pdf);
    const createElement = vi.fn();
    vi.stubGlobal('document', { createElement });
    const pending = settle(api.downloadPdf('<p>private old report</p>', 'order'));
    await reading.promise;
    api.resetPageContextForNavigation();
    api.pinPageContext(B);
    held.resolve(new Blob(['old-pdf']));
    expect((await pending).error).toMatchObject({ code: 'context-response-obsolete' });
    expect(createElement).not.toHaveBeenCalled();
    headersMatch(0);
  });

  it('A15 response descriptor mutation cannot change the pinned header authority', async () => {
    fetcher
      .mockResolvedValueOnce(response({ context: A }))
      .mockResolvedValueOnce(response({ ok: true }));
    const me = await api.get<{ context: { coCode: string; contextEpoch: string } }>('/me');
    me.context.coCode = '09';
    me.context.contextEpoch = '99';
    await api.get('/orders');
    headersMatch(1);
    expect(api.getPageContextState().context).toEqual(A);
  });

  it('A16 a new page owns a separate refresh flight and an old completion cannot clear it', async () => {
    api.pinPageContext(A);
    const oldRefresh = deferred<Response>();
    const newRefresh = deferred<Response>();
    const oldStarted = deferred<void>();
    const newStarted = deferred<void>();
    let refreshCount = 0;
    const counts = new Map<string, number>();
    fetcher.mockImplementation(async (url) => {
      if (url === '/api/auth/refresh') {
        refreshCount++;
        if (refreshCount === 1) {
          oldStarted.resolve();
          return oldRefresh.promise;
        }
        newStarted.resolve();
        return newRefresh.promise;
      }
      const key = String(url);
      const n = (counts.get(key) ?? 0) + 1;
      counts.set(key, n);
      return n === 1 ? response({ error: 'unauthorized' }, 401) : response({ ok: key });
    });
    const old = settle(api.post('/old', { draft: 'A' }));
    await oldStarted.promise;
    api.resetPageContextForNavigation();
    api.pinPageContext(B);
    const next = settle(api.post('/next', { draft: 'B' }));
    await newStarted.promise;
    oldRefresh.resolve(response({ context: A }));
    expect((await old).error).toMatchObject({ code: 'context-response-obsolete' });
    const third = settle(api.post('/third', { draft: 'B-other' }));
    // The pending new flight remains active while this independent401 joins it.
    await new Promise<void>((resolve) => setTimeout(resolve, 0));
    newRefresh.resolve(response({ context: B }));
    expect((await next).value).toEqual({ ok: '/api/next' });
    expect((await third).value).toEqual({ ok: '/api/third' });
    expect(refreshCount).toBe(2);
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: B });
  });

  it('A17 duplicate bootstrap/me loads get one bounded obsolete retry', async () => {
    const firstResponse = deferred<Response>();
    const secondResponse = deferred<Response>();
    fetcher
      .mockReturnValueOnce(firstResponse.promise)
      .mockReturnValueOnce(secondResponse.promise)
      .mockResolvedValueOnce(response({ user: 'operator', context: A }));
    const first = settle(api.loadPageSession());
    const second = settle(api.loadPageSession());
    firstResponse.resolve(response({ user: 'operator', context: A }));
    expect((await first).value).toMatchObject({ context: A });
    secondResponse.resolve(response({ user: 'operator', context: A }));
    expect((await second).value).toMatchObject({ context: A });
    expect(fetcher).toHaveBeenCalledTimes(3);
    headersMatch(2);
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: A });
  });

  it('A18 stale bootstrap never performs the obsolete-only retry', async () => {
    const held = deferred<Response>();
    fetcher.mockReturnValueOnce(held.promise);
    const pending = settle(api.loadPageSession());
    api.pinPageContext(A);
    api.pinPageContext(B);
    held.resolve(response({ context: A }));
    expect((await pending).error).toMatchObject({ code: 'context-stale' });
    expect(fetcher).toHaveBeenCalledTimes(1);
  });

  it('A19 bootstrap retries only once if context changes again during its retry', async () => {
    const first = deferred<Response>();
    const second = deferred<Response>();
    const retried = deferred<void>();
    fetcher.mockReturnValueOnce(first.promise).mockImplementationOnce(async () => {
      retried.resolve();
      return second.promise;
    });
    const pending = settle(api.loadPageSession());
    api.pinPageContext(A);
    first.resolve(response({ context: A }));
    await retried.promise;
    api.resetPageContextForNavigation();
    api.pinPageContext(B);
    second.resolve(response({ context: A }));
    expect((await pending).error).toMatchObject({ code: 'context-response-obsolete' });
    expect(fetcher).toHaveBeenCalledTimes(2);
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: B });
  });

  it('pins the additive bootstrap-only qualification without changing original vectors', () => {
    const bytes = readFileSync(
      new URL('./fixtures/pageContext.bootstrap-qualification.json', import.meta.url),
    );
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'fb377ea6aafd5df6effb49d2022fa26a28a53d1320f38c636dc3d768c043b23e',
    );
  });
});
