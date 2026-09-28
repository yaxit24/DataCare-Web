import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import type { BrowserSessionContext } from '../lib/pageContext';

const sessionId = '11111111-1111-4111-8111-111111111111';
const otherSessionId = '22222222-2222-4222-8222-222222222222';
const selectionId = '33333333-3333-4333-8333-333333333333';
const nextSelectionId = '44444444-4444-4444-8444-444444444444';
const key = 'datacare.pending-context-selection.v1';
const A: BrowserSessionContext = {
  sessionId,
  contextEpoch: '9',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
};
const B: BrowserSessionContext = {
  sessionId,
  contextEpoch: '10',
  coCode: '02',
  lcCode: '03',
  coYear: '2025-2026',
};
const target = { coCode: '02', lcCode: '03', coYear: '2025-2026' };
const pendingLiteral = () => ({
  version: 'context-selection-recovery-v1' as const,
  sessionId,
  request: {
    coCode: '02',
    expectedContextEpoch: '9',
    selectionId,
    lcCode: '03',
    coYear: '2025-2026',
  },
});
const response = (body: unknown, status = 200) =>
  new Response(JSON.stringify(body), {
    status,
    headers: { 'content-type': 'application/json' },
  });
const validResponse = (replayed = false) => ({ context: B, scoped: true, replayed });
const deferred = <T>() => {
  let resolve!: (value: T) => void;
  const promise = new Promise<T>((done) => {
    resolve = done;
  });
  return { promise, resolve };
};
const settle = <T>(promise: Promise<T>) =>
  promise.then(
    (value) => ({ status: 'fulfilled' as const, value }),
    (reason: unknown) => ({ status: 'rejected' as const, reason }),
  );

describe('pending company selection recovery (controlled storage/fetch; no real browser or server proof)', () => {
  let api: typeof import('../lib/api');
  let subject: typeof import('../lib/contextSelection');
  let fetcher: ReturnType<typeof vi.fn<typeof fetch>>;
  let storage: Storage;
  let memory: Map<string, string>;
  beforeEach(async () => {
    vi.resetModules();
    memory = new Map();
    storage = {
      get length() {
        return memory.size;
      },
      getItem: vi.fn((name: string) => memory.get(name) ?? null),
      setItem: vi.fn((name: string, value: string) => {
        memory.set(name, value);
      }),
      removeItem: vi.fn((name: string) => {
        memory.delete(name);
      }),
      clear: vi.fn(() => memory.clear()),
      key: vi.fn((index: number) => [...memory.keys()][index] ?? null),
    };
    fetcher = vi.fn<typeof fetch>().mockImplementation(async () => response(validResponse()));
    vi.stubGlobal('sessionStorage', storage);
    vi.stubGlobal('crypto', { randomUUID: vi.fn(() => selectionId) });
    vi.stubGlobal('fetch', fetcher);
    api = await import('../lib/api');
    subject = await import('../lib/contextSelection');
  });
  afterEach(() => {
    vi.restoreAllMocks();
    vi.unstubAllGlobals();
  });
  const saved = () => {
    const pending = subject.parsePendingContextSelection(pendingLiteral());
    expect(pending).not.toBeNull();
    subject.savePendingContextSelection(pending!);
    return pending!;
  };
  const expectBodyAndHeaders = (
    index: number,
    expected: ReturnType<typeof pendingLiteral>,
    context: BrowserSessionContext,
  ) => {
    const call = fetcher.mock.calls[index]!;
    expect(call[0]).toBe('/api/context/select');
    expect(call[1]?.method).toBe('POST');
    expect(call[1]?.body).toBe(JSON.stringify(expected.request));
    const headers = new Headers(call[1]?.headers);
    expect(headers.get('x-session-context-id')).toBe(context.sessionId);
    expect(headers.get('x-session-context-epoch')).toBe(context.contextEpoch);
  };

  it('parses a detached frozen exact request while preserving omitted defaults and immutable original values', () => {
    const original = pendingLiteral();
    const parsed = subject.parsePendingContextSelection(original)!;
    expect(parsed).toEqual(original);
    expect(parsed).not.toBe(original);
    expect(parsed.request).not.toBe(original.request);
    expect(Object.isFrozen(parsed)).toBe(true);
    expect(Object.isFrozen(parsed.request)).toBe(true);
    expect(Object.isFrozen(original)).toBe(false);
    expect(Object.isFrozen(original.request)).toBe(false);
    original.request.coCode = '07';
    expect(parsed.request.coCode).toBe('02');
    const omitted = subject.parsePendingContextSelection({
      version: original.version,
      sessionId,
      request: { coCode: '02', expectedContextEpoch: '9', selectionId },
    });
    expect(omitted?.request).toEqual({ coCode: '02', expectedContextEpoch: '9', selectionId });
    expect(Object.hasOwn(omitted!.request, 'lcCode')).toBe(false);
    expect(Object.hasOwn(omitted!.request, 'coYear')).toBe(false);
  });

  it.each([
    ['numeric epoch', { expectedContextEpoch: 9 }],
    ['zero epoch', { expectedContextEpoch: '0' }],
    ['leading zero', { expectedContextEpoch: '09' }],
    ['overflow', { expectedContextEpoch: '9223372036854775808' }],
    ['epoch LF', { expectedContextEpoch: '9\n' }],
    ['epoch CR', { expectedContextEpoch: '9\r' }],
    ['UUID LF', { selectionId: `${selectionId}\n` }],
    ['UUID version1', { selectionId: '33333333-3333-1333-8333-333333333333' }],
    ['unknown key', { ledgerMode: 'C' }],
    ['own undefined location', { lcCode: undefined }],
    ['NULL year', { coYear: null }],
    ['blank location', { lcCode: '' }],
    ['padded company', { coCode: ' 2' }],
  ] as const)('refuses %s without coercing or normalizing the pending request', (_name, patch) => {
    const value = pendingLiteral();
    expect(
      subject.parsePendingContextSelection({ ...value, request: { ...value.request, ...patch } }),
    ).toBeNull();
  });

  it('rejects a session UUID with terminal newline and extra root keys', () => {
    expect(
      subject.parsePendingContextSelection({ ...pendingLiteral(), sessionId: `${sessionId}\n` }),
    ).toBeNull();
    expect(
      subject.parsePendingContextSelection({ ...pendingLiteral(), contextEpoch: '9' }),
    ).toBeNull();
  });

  it('contains non-data envelopes without invoking getters or accepting inherited/symbol keys', () => {
    const read = vi.fn(() => pendingLiteral().request);
    const getter = { version: 'context-selection-recovery-v1', sessionId };
    Object.defineProperty(getter, 'request', { enumerable: true, get: read });
    expect(subject.parsePendingContextSelection(getter)).toBeNull();
    expect(read).not.toHaveBeenCalled();
    const inherited = Object.assign(Object.create({ unexpected: true }), pendingLiteral());
    expect(subject.parsePendingContextSelection(inherited)).toBeNull();
    expect(
      subject.parsePendingContextSelection({ ...pendingLiteral(), [Symbol('extra')]: true }),
    ).toBeNull();
  });

  it('creates one stable UUID/body and persists it before any selection fetch', async () => {
    api.pinPageContext(A);
    const pending = subject.createPendingContextSelection(A, target);
    expect(pending).toEqual(pendingLiteral());
    subject.savePendingContextSelection(pending);
    expect(memory.get(key)).toBe(JSON.stringify(pending));
    expect(fetcher).not.toHaveBeenCalled();
    fetcher.mockImplementationOnce(async () => {
      expect(memory.get(key)).toBe(JSON.stringify(pending));
      return response(validResponse());
    });
    await expect(subject.submitPendingContextSelection(pending)).resolves.toEqual(B);
    expectBodyAndHeaders(0, pendingLiteral(), A);
    expect(memory.has(key)).toBe(false);
    expect(api.getPageContextState()).toMatchObject({ status: 'stale', context: A, observed: B, reason: 'context-changed' });
  });

  it('a storage write failure prevents dispatch in the required save-then-submit sequence', async () => {
    api.pinPageContext(A);
    const pending = subject.createPendingContextSelection(A, target);
    const quota = new Error('fixture-storage-quota');
    vi.mocked(storage.setItem).mockImplementation(() => {
      throw quota;
    });
    const attempt = async () => {
      subject.savePendingContextSelection(pending);
      return subject.submitPendingContextSelection(pending);
    };
    await expect(attempt()).rejects.toBe(quota);
    expect(fetcher).not.toHaveBeenCalled();
    expect(memory.size).toBe(0);
  });

  it('an inactive component lease refuses before dispatch and leaves the ready page and saved operation intact', async () => {
    api.pinPageContext(A);
    const pending = saved();
    const bytes = memory.get(key);
    await expect(subject.submitPendingContextSelection(pending, { isCurrent: () => false })).rejects.toThrow('no longer active');
    expect(fetcher).not.toHaveBeenCalled();
    expect(memory.get(key)).toBe(bytes);
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: A });
  });

  it('a successful selection invalidates pending ordinary responses and retains the old descriptor until navigation', async () => {
    api.pinPageContext(A);
    const pending = saved();
    const held = deferred<Response>();
    fetcher.mockReturnValueOnce(held.promise);
    const ordinary = settle(api.get('/masters/components'));
    await expect(subject.submitPendingContextSelection(pending)).resolves.toEqual(B);
    expect(api.getPageContextState()).toMatchObject({ status: 'stale', context: A, observed: B, reason: 'context-changed' });
    held.resolve(response([{ rate: 123 }]));
    expect(await ordinary).toMatchObject({ status: 'rejected', reason: { code: 'context-stale' } });
    expect(memory.has(key)).toBe(false);
  });

  it('confirmed receipt recovery leaves the freshly bootstrapped current page ready', async () => {
    api.pinPageContext(B);
    const pending = saved();
    fetcher.mockResolvedValueOnce(response(validResponse(true)));
    await expect(subject.submitPendingContextSelection(pending)).resolves.toEqual(B);
    expect(api.getPageContextState()).toMatchObject({ status: 'ready', context: B, observed: null });
    expect(memory.has(key)).toBe(false);
  });

  it.each(['success', 'network-failure'] as const)('late %s after route departure guards the document but preserves the original recovery operation', async (outcome) => {
    api.pinPageContext(A);
    const pending = saved();
    const bytes = memory.get(key);
    const held = deferred<Response>();
    let live = true;
    fetcher.mockReturnValueOnce(outcome === 'success' ? held.promise : held.promise.then(() => { throw new TypeError('connection-lost'); }));
    const work = settle(subject.submitPendingContextSelection(pending, { isCurrent: () => live }));
    live = false;
    held.resolve(response(validResponse()));
    expect(await work).toMatchObject({ status: 'rejected' });
    expect(memory.get(key)).toBe(bytes);
    expect(api.getPageContextState()).toMatchObject({ status: 'stale', context: A,
      reason: outcome === 'success' ? 'context-changed' : 'context-selection-unconfirmed',
      observed: outcome === 'success' ? B : null });
    await expect(api.post('/sales/orders', { draft: 'unchanged' })).rejects.toMatchObject({ code: 'context-stale' });
    expect(fetcher).toHaveBeenCalledTimes(1);
  });

  it.each(['absent', 'different-body', 'different-operation'] as const)(
    'submit refuses %s persisted recovery before any dispatch',
    async (kind) => {
      api.pinPageContext(A);
      const pending = subject.parsePendingContextSelection(pendingLiteral())!;
      if (kind !== 'absent')
        memory.set(
          key,
          JSON.stringify({
            ...pendingLiteral(),
            request: {
              ...pendingLiteral().request,
              ...(kind === 'different-body' ? { lcCode: '04' } : { selectionId: nextSelectionId }),
            },
          }),
        );
      const before = memory.get(key);
      await expect(subject.submitPendingContextSelection(pending)).rejects.toThrow();
      expect(fetcher).not.toHaveBeenCalled();
      expect(memory.get(key)).toBe(before);
    },
  );

  it('save refuses to replace another pending operation until an explicit matching clear', () => {
    const first = saved();
    const before = memory.get(key);
    const next = subject.parsePendingContextSelection({
      ...pendingLiteral(),
      request: { ...pendingLiteral().request, selectionId: nextSelectionId },
    })!;
    expect(() => subject.savePendingContextSelection(next)).toThrow();
    expect(memory.get(key)).toBe(before);
    subject.savePendingContextSelection(first);
    expect(memory.get(key)).toBe(before);
    subject.clearPendingContextSelection(selectionId);
    subject.savePendingContextSelection(next);
    expect(subject.readPendingContextSelection(A)).toEqual(next);
    expect(fetcher).not.toHaveBeenCalled();
  });

  it('full reload preserves the original UUID/body/epoch and recovery uses fresh page headers, not a refresh bypass', async () => {
    api.pinPageContext(A);
    const pending = saved();
    const bytes = memory.get(key);
    fetcher.mockRejectedValueOnce(new TypeError('uncertain-network-result'));
    await expect(subject.submitPendingContextSelection(pending)).rejects.toThrow(
      'uncertain-network-result',
    );
    expect(memory.get(key)).toBe(bytes);
    expect(fetcher).toHaveBeenCalledTimes(1);
    vi.resetModules();
    api = await import('../lib/api');
    subject = await import('../lib/contextSelection');
    expect(api.getPageContextState().status).toBe('unbound');
    fetcher.mockResolvedValueOnce(response({ context: B }));
    await api.loadPageSession();
    const recovered = subject.readPendingContextSelection(B)!;
    expect(recovered).toEqual(pending);
    expect(memory.get(key)).toBe(bytes);
    fetcher.mockResolvedValueOnce(response(validResponse(true)));
    await expect(subject.submitPendingContextSelection(recovered)).resolves.toEqual(B);
    expect(fetcher.mock.calls.map(([url]) => url)).toEqual([
      '/api/context/select',
      '/api/me',
      '/api/context/select',
    ]);
    expect(fetcher.mock.calls[2]?.[1]?.body).toBe(fetcher.mock.calls[0]?.[1]?.body);
    expectBodyAndHeaders(2, pendingLiteral(), B);
    expect(memory.has(key)).toBe(false);
  });

  it.each([
    ['older epoch', { ...A, contextEpoch: '8' }],
    ['replaced epoch E+2', { ...B, contextEpoch: '11' }],
    ['another SID', { ...B, sessionId: otherSessionId }],
  ] as const)('refuses %s locally while retaining pending recovery bytes', async (_name, live) => {
    api.pinPageContext(live);
    const pending = saved();
    const before = memory.get(key);
    await expect(subject.submitPendingContextSelection(pending)).rejects.toMatchObject({
      status: 409,
      body: { error: 'context-stale' },
    });
    expect(fetcher).not.toHaveBeenCalled();
    expect(memory.get(key)).toBe(before);
  });

  it.each(['unbound', 'stale'] as const)(
    'refuses %s page state without dispatch or pending loss',
    async (kind) => {
      if (kind === 'stale') {
        api.pinPageContext(A);
        api.pinPageContext(B);
      }
      const pending = saved();
      const before = memory.get(key);
      await expect(subject.submitPendingContextSelection(pending)).rejects.toMatchObject({
        status: 409,
      });
      expect(fetcher).not.toHaveBeenCalled();
      expect(memory.get(key)).toBe(before);
    },
  );

  it.each([
    ['missing scoped', { context: B, replayed: false }],
    ['false scoped', { ...validResponse(), scoped: false }],
    ['coerced replay', { ...validResponse(), replayed: 'false' }],
    ['unexpected replay on E', validResponse(true)],
    ['wrong SID', { ...validResponse(), context: { ...B, sessionId: otherSessionId } }],
    ['unchanged epoch', { ...validResponse(), context: { ...B, contextEpoch: '9' } }],
    ['replaced epoch', { ...validResponse(), context: { ...B, contextEpoch: '11' } }],
    ['wrong company', { ...validResponse(), context: { ...B, coCode: '03' } }],
    ['wrong location', { ...validResponse(), context: { ...B, lcCode: '04' } }],
    ['wrong year', { ...validResponse(), context: { ...B, coYear: '2024-2025' } }],
    ['NULL year', { ...validResponse(), context: { ...B, coYear: null } }],
    ['extra context key', { ...validResponse(), context: { ...B, mode: 'C' } }],
  ] as const)(
    'unconfirmed response %s cannot clear or rewrite the pending operation',
    async (_name, body) => {
      api.pinPageContext(A);
      const pending = saved();
      const before = memory.get(key);
      fetcher.mockResolvedValueOnce(response(body));
      await expect(subject.submitPendingContextSelection(pending)).rejects.toThrow();
      expect(fetcher).toHaveBeenCalledTimes(1);
      expect(memory.get(key)).toBe(before);
    },
  );

  it('current E+1 recovery refuses a non-replayed response even if all context fields match', async () => {
    api.pinPageContext(B);
    const pending = saved();
    const before = memory.get(key);
    fetcher.mockResolvedValueOnce(response(validResponse(false)));
    await expect(subject.submitPendingContextSelection(pending)).rejects.toThrow();
    expect(fetcher).toHaveBeenCalledTimes(1);
    expect(memory.get(key)).toBe(before);
  });

  it('allows server-resolved location/year only when those optional request fields were actually omitted', async () => {
    api.pinPageContext(A);
    const pending = subject.createPendingContextSelection(A, { coCode: '02' });
    subject.savePendingContextSelection(pending);
    await expect(subject.submitPendingContextSelection(pending)).resolves.toEqual(B);
    const body = JSON.parse(String(fetcher.mock.calls[0]?.[1]?.body));
    expect(body).toEqual({ coCode: '02', expectedContextEpoch: '9', selectionId });
    expect(memory.has(key)).toBe(false);
  });

  it.each([409, 500] as const)(
    'HTTP%s failure retains the exact pending operation without a second mutation',
    async (status) => {
      api.pinPageContext(A);
      const pending = saved();
      const before = memory.get(key);
      fetcher.mockResolvedValueOnce(response({ error: 'context-operation-conflict' }, status));
      await expect(subject.submitPendingContextSelection(pending)).rejects.toMatchObject({
        status,
      });
      expect(fetcher).toHaveBeenCalledTimes(1);
      expect(memory.get(key)).toBe(before);
    },
  );

  it('an obsolete response cannot clear pending storage or poison a newer page', async () => {
    api.pinPageContext(A);
    const pending = saved();
    const before = memory.get(key);
    const held = deferred<Response>();
    fetcher.mockReturnValueOnce(held.promise);
    const work = settle(subject.submitPendingContextSelection(pending));
    api.resetPageContextForNavigation();
    api.pinPageContext({ ...B, contextEpoch: '11' });
    held.resolve(response(validResponse()));
    expect(await work).toMatchObject({
      status: 'rejected',
      reason: { code: 'context-response-obsolete' },
    });
    expect(memory.get(key)).toBe(before);
    expect(api.getPageContextState()).toMatchObject({
      status: 'ready',
      context: { ...B, contextEpoch: '11' },
    });
  });

  it('completion clears only its own operation ID and preserves a newer stored request', async () => {
    api.pinPageContext(A);
    const pending = saved();
    const replacement = {
      ...pendingLiteral(),
      request: { ...pendingLiteral().request, selectionId: nextSelectionId },
    };
    const held = deferred<Response>();
    fetcher.mockReturnValueOnce(held.promise);
    const work = subject.submitPendingContextSelection(pending);
    memory.set(key, JSON.stringify(replacement));
    held.resolve(response(validResponse()));
    await expect(work).resolves.toEqual(B);
    expect(memory.get(key)).toBe(JSON.stringify(replacement));
    subject.clearPendingContextSelection(selectionId);
    expect(memory.get(key)).toBe(JSON.stringify(replacement));
    subject.clearPendingContextSelection(nextSelectionId);
    expect(memory.has(key)).toBe(false);
  });

  it('a failed storage clear after confirmed response retains the operation for explicit recovery', async () => {
    api.pinPageContext(A);
    const pending = saved();
    const bytes = memory.get(key);
    const failure = new Error('fixture-storage-clear-failure');
    vi.mocked(storage.removeItem).mockImplementation(() => {
      throw failure;
    });
    await expect(subject.submitPendingContextSelection(pending)).rejects.toBe(failure);
    expect(fetcher).toHaveBeenCalledTimes(1);
    expect(memory.get(key)).toBe(bytes);
  });

  it('read removes malformed or foreign-SID recovery records while completion leaves unrelated invalid data untouched', () => {
    memory.set(key, '{invalid');
    subject.clearPendingContextSelection(selectionId);
    expect(memory.get(key)).toBe('{invalid');
    expect(subject.readPendingContextSelection(A)).toBeNull();
    expect(memory.has(key)).toBe(false);
    memory.set(key, JSON.stringify(pendingLiteral()));
    expect(subject.readPendingContextSelection({ ...A, sessionId: otherSessionId })).toBeNull();
    expect(memory.has(key)).toBe(false);
    const own = pendingLiteral();
    memory.set(key, JSON.stringify(own));
    expect(subject.readPendingContextSelection(B)).toEqual(own); // admission to submit remains a separate epoch check
  });
});
