import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import { createPageContextGuard } from '../lib/pageContext';

const A = {
  sessionId: '11111111-1111-4111-8111-111111111111',
  contextEpoch: '7',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
};
const B = { ...A, contextEpoch: '8', coCode: '02' };
const message =
  'The company change needs to be checked. Copy unsaved work, then reload company selection.';
function deferred<T>() {
  let resolve!: (value: T) => void;
  const promise = new Promise<T>((done) => {
    resolve = done;
  });
  return { promise, resolve };
}
const settle = <T>(promise: Promise<T>) =>
  promise.then(
    (value) => ({ value, error: undefined }),
    (error: unknown) => ({ value: undefined, error }),
  );
const json = (body: unknown, status = 200) => new Response(JSON.stringify(body), { status });

describe('explicit uncertain-selection page pause', () => {
  it('retains the old identity, invalidates tickets and publishes a precise uncertainty reason', () => {
    const page = createPageContextGuard();
    page.observe(A);
    const ticket = page.capture();
    const changed = vi.fn();
    page.subscribe(changed);
    expect(page.pauseForSelection()).toBeUndefined();
    expect(page.read()).toStrictEqual({
      status: 'stale',
      revision: 2,
      context: A,
      observed: null,
      reason: 'context-selection-unconfirmed',
      message,
    });
    expect(changed).toHaveBeenCalledTimes(1);
    expect(Object.isFrozen(page.read())).toBe(true);
    expect(() => page.capture()).toThrow(message);
    expect(() => page.assertCurrent(ticket)).toThrow(message);
  });

  it('does not invent an identity on an unbound page', () => {
    const page = createPageContextGuard();
    page.pauseForSelection();
    expect(page.read()).toMatchObject({
      status: 'stale',
      revision: 1,
      context: null,
      observed: null,
      reason: 'context-selection-unconfirmed',
      message,
    });
    expect(() => page.capture()).toThrow(message);
  });

  it('is idempotent and cannot be cleared by a descriptor or an exact receipt without navigation', () => {
    const page = createPageContextGuard();
    page.observe(A);
    page.pauseForSelection();
    const frozen = page.read();
    page.pauseForSelection();
    page.observe(A);
    page.observe(B);
    page.observe(null);
    expect(page.read()).toBe(frozen);
    page.resetForNavigation();
    expect(page.observe(B)).toMatchObject({
      status: 'ready',
      revision: 4,
      context: B,
      reason: null,
    });
  });

  it('preserves a confirmed mismatch and distinguishes successful changed selection from an exact receipt', () => {
    const page = createPageContextGuard();
    page.observe(A);
    const before = page.read();
    expect(page.observe({ ...A })).toBe(before);
    page.observe(B);
    const confirmed = page.read();
    page.pauseForSelection();
    expect(page.read()).toBe(confirmed);
    expect(page.read()).toMatchObject({
      context: A,
      observed: B,
      reason: 'context-changed',
    });
  });
});

describe('selection pause across actual API control flow (fetch doubles)', () => {
  let api: typeof import('../lib/api');
  let fetcher: ReturnType<typeof vi.fn<typeof fetch>>;
  beforeEach(async () => {
    vi.resetModules();
    fetcher = vi.fn<typeof fetch>();
    vi.stubGlobal('fetch', fetcher);
    api = await import('../lib/api');
    api.pinPageContext(A);
  });
  afterEach(() => {
    vi.restoreAllMocks();
    vi.unstubAllGlobals();
  });

  it('rejects a pending JSON response and refuses the next business dispatch', async () => {
    const held = deferred<Response>();
    fetcher.mockReturnValueOnce(held.promise);
    const publish = vi.fn();
    const pending = settle(api.get('/masters/items').then(publish));
    api.pausePageContextForSelection();
    held.resolve(json({ rows: ['old-company'] }));
    expect((await pending).error).toMatchObject({
      code: 'context-stale',
      message,
    });
    await expect(api.post('/sales', { retainedDraft: true })).rejects.toMatchObject({
      code: 'context-stale',
    });
    expect(publish).not.toHaveBeenCalled();
    expect(fetcher).toHaveBeenCalledTimes(1);
  });

  it('rejects bytes that finish decoding after pause without downloading them', async () => {
    const body = deferred<Blob>();
    const reading = deferred<void>();
    const response = new Response('old-company');
    vi.spyOn(response, 'blob').mockImplementation(() => {
      reading.resolve();
      return body.promise;
    });
    fetcher.mockResolvedValueOnce(response);
    const download = vi.fn();
    const pending = settle(api.getBlob('/backup').then(download));
    await reading.promise;
    api.pausePageContextForSelection();
    body.resolve(new Blob(['old-company']));
    expect((await pending).error).toMatchObject({
      code: 'context-stale',
      message,
    });
    expect(download).not.toHaveBeenCalled();
    expect(fetcher).toHaveBeenCalledTimes(1);
  });

  it('does not retry an old draft when an in-flight refresh returns the same descriptor after pause', async () => {
    const refreshing = deferred<void>();
    const refresh = deferred<Response>();
    fetcher.mockImplementation(async (path) => {
      if (path === '/api/auth/refresh') {
        refreshing.resolve();
        return refresh.promise;
      }
      return json({ error: 'unauthorized' }, 401);
    });
    const pending = settle(api.post('/sales', { retainedDraft: 'unchanged' }));
    await refreshing.promise;
    api.pausePageContextForSelection();
    refresh.resolve(json({ context: A }));
    expect((await pending).error).toMatchObject({
      code: 'context-stale',
      message,
    });
    expect(fetcher).toHaveBeenCalledTimes(2);
    expect(api.getPageContextState()).toMatchObject({
      context: A,
      observed: null,
      reason: 'context-selection-unconfirmed',
    });
  });
});
