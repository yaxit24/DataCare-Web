import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import { createPageContextGuard } from '../lib/pageContext';
import { DeviceContextGuard } from '../lib/deviceContextLease';

const A = {
  sessionId: '11111111-1111-4111-8111-111111111111',
  contextEpoch: '7',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
};
const B = { ...A, contextEpoch: '8', coCode: '02' };
const json = (value: unknown, status = 200) => new Response(JSON.stringify(value), { status });
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

describe('guarded direct server reads (fetch doubles only)', () => {
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

  it('keeps exact backup bytes and sends both captured context headers', async () => {
    const raw = '{"raw":9007199254740993,"decimal":"9999999999999999.99","null":null}\n';
    fetcher.mockResolvedValueOnce(new Response(raw));
    const blob = await api.getBlob('/backup');
    expect(await blob.text()).toBe(raw);
    expect(fetcher.mock.calls[0]?.[0]).toBe('/api/backup');
    const headers = new Headers(fetcher.mock.calls[0]?.[1]?.headers);
    expect(headers.get('x-session-context-id')).toBe(A.sessionId);
    expect(headers.get('x-session-context-epoch')).toBe('7');
    expect(fetcher.mock.calls[0]?.[1]?.body).toBeUndefined();
  });

  it('rejects a late blob before the caller can download it', async () => {
    const data = deferred<Blob>();
    const started = deferred<void>();
    const res = new Response('ignored');
    vi.spyOn(res, 'blob').mockImplementation(() => {
      started.resolve();
      return data.promise;
    });
    fetcher.mockResolvedValueOnce(res);
    const download = vi.fn();
    const pending = settle(api.getBlob('/backup').then(download));
    await started.promise;
    api.resetPageContextForNavigation();
    api.pinPageContext(B);
    data.resolve(new Blob(['old-company']));
    expect((await pending).error).toMatchObject({ code: 'context-response-obsolete' });
    expect(download).not.toHaveBeenCalled();
  });

  it('does not turn a401 error body into a backup or automatically retry', async () => {
    const res = json({ error: 'unauthorized' }, 401);
    const read = vi.spyOn(res, 'blob');
    fetcher.mockResolvedValueOnce(res);
    await expect(api.getBlob('/backup')).rejects.toMatchObject({ status: 401 });
    expect(read).not.toHaveBeenCalled();
    expect(fetcher).toHaveBeenCalledTimes(1);
  });

  it('409 context-stale blocks later binary requests without a second dispatch', async () => {
    fetcher.mockResolvedValueOnce(json({ error: 'context-stale' }, 409));
    await expect(api.getBlob('/backup')).rejects.toMatchObject({ code: 'context-stale' });
    await expect(api.getBlob('/backup')).rejects.toMatchObject({ code: 'context-stale' });
    expect(fetcher).toHaveBeenCalledTimes(1);
  });

  it('exports exact tickets that remain invalid through an explicit A→A page reset', () => {
    const ticket = api.capturePageContextTicket();
    api.resetPageContextForNavigation();
    api.pinPageContext(A);
    let error: unknown;
    try {
      api.assertPageContextTicket(ticket);
    } catch (caught) {
      error = caught;
    }
    expect(error).toMatchObject({ code: 'context-response-obsolete' });
  });

  it('data refresh uses the same guarded post and cannot publish a late old-company result', async () => {
    const held = deferred<Response>();
    fetcher.mockReturnValueOnce(held.promise);
    const publish = vi.fn();
    const pending = settle(api.post('/utilities/data-refresh').then(publish));
    expect(fetcher.mock.calls[0]?.[1]?.body).toBe('{}');
    const headers = new Headers(fetcher.mock.calls[0]?.[1]?.headers);
    expect(headers.get('x-session-context-epoch')).toBe('7');
    api.resetPageContextForNavigation();
    api.pinPageContext(B);
    held.resolve(json({ counts: { SL_DATA: 3 } }));
    expect((await pending).error).toMatchObject({ code: 'context-response-obsolete' });
    expect(publish).not.toHaveBeenCalled();
  });
});

describe('device operation and page ownership', () => {
  it('keeps the newer capture active when an older chooser completes', () => {
    const page = createPageContextGuard();
    page.observe(A);
    const device = new DeviceContextGuard(page.assertCurrent);
    const old = device.begin(page.capture());
    const latest = device.begin(page.capture());
    const publish = vi.fn();
    expect(() => device.publish(old, publish)).toThrow('device-capture-cancelled');
    device.publish(latest, publish);
    expect(publish).toHaveBeenCalledTimes(1);
  });
  it('refuses old settings before chooser admission and old readings before draft delivery', () => {
    const page = createPageContextGuard();
    page.observe(A);
    const ticket = page.capture();
    const device = new DeviceContextGuard(page.assertCurrent);
    const lease = device.begin(ticket);
    page.observe(B);
    const publish = vi.fn();
    let admissionError: unknown;
    try {
      device.begin(ticket);
    } catch (caught) {
      admissionError = caught;
    }
    expect(admissionError).toMatchObject({ code: 'context-stale' });
    let deliveryError: unknown;
    try {
      device.publish(lease, publish);
    } catch (caught) {
      deliveryError = caught;
    }
    expect(deliveryError).toMatchObject({ code: 'context-stale' });
    expect(publish).not.toHaveBeenCalled();
  });
});
