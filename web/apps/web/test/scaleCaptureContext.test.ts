import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';

const A = {
  sessionId: '11111111-1111-4111-8111-111111111111',
  contextEpoch: '7',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
};
const B = { ...A, contextEpoch: '8', coCode: '02' };
const settings = {
  enabled: true,
  weightPort: 'COM3',
  scale: {
    friendlyNameFragment: 'CH340',
    profiles: {
      primary: { baudRate: 9600, dataBits: 8, parity: 'none', stopBits: 1 },
      fallback: { baudRate: 2400, dataBits: 7, parity: 'none', stopBits: 1 },
    },
    decimalPlaces: 3,
    frameScanLimit: 20,
    excludedCharacters: [' ', 'S', 'T', 'k', 'g', ',', '\r', '\n'],
    targetGridColumn: 14,
    signIsDropped: true,
  },
};
function deferred<T>() {
  let resolve!: (value: T) => void;
  const promise = new Promise<T>((done) => {
    resolve = done;
  });
  return { promise, resolve };
}
const bytes = (value: string) => new TextEncoder().encode(value);

/** Minimal retained-state/ref and mount-cleanup hook double. No DOM, React scheduling or device acceptance. */
function hookHarness() {
  const states: unknown[] = [];
  const refs: Array<{ current: unknown }> = [];
  const effects: Array<() => void | (() => void)> = [];
  const cleanups: Array<() => void> = [];
  let stateIndex = 0;
  let refIndex = 0;
  let effectIndex = 0;
  return {
    react: {
      useState(initial: unknown) {
        const index = stateIndex++;
        if (!(index in states)) states[index] = initial;
        return [
          states[index],
          (value: unknown) => {
            states[index] =
              typeof value === 'function'
                ? (value as (old: unknown) => unknown)(states[index])
                : value;
          },
        ];
      },
      useRef(initial: unknown) {
        const index = refIndex++;
        if (!refs[index]) refs[index] = { current: initial };
        return refs[index];
      },
      useCallback<T>(fn: T) {
        return fn;
      },
      useEffect(effect: () => void | (() => void)) {
        const index = effectIndex++;
        if (!effects[index]) effects[index] = effect;
      },
    },
    render<T>(fn: () => T): T {
      stateIndex = 0;
      refIndex = 0;
      effectIndex = 0;
      return fn();
    },
    mount() {
      for (const effect of effects) {
        const cleanup = effect();
        if (cleanup) cleanups.push(cleanup);
      }
    },
    unmount() {
      for (const cleanup of cleanups.splice(0)) cleanup();
    },
  };
}
function portWithPendingRead(cancelDeliversDone = true) {
  const data = deferred<{ value?: Uint8Array; done: boolean }>();
  const started = deferred<void>();
  const reader = {
    read: vi.fn(async () => {
      started.resolve();
      return data.promise;
    }),
    releaseLock: vi.fn(),
    cancel: vi.fn(async () => {
      if (cancelDeliversDone) data.resolve({ done: true });
    }),
  };
  const port = {
    open: vi.fn(async () => {}),
    close: vi.fn(async () => {}),
    readable: { getReader: vi.fn(() => reader) },
  };
  return { port, reader, data, started };
}

describe('actual ScaleCapture async code with controlled hooks and WebSerial doubles', () => {
  let api: typeof import('../lib/api');
  let module: typeof import('../components/ScaleCapture');
  let hooks: ReturnType<typeof hookHarness>;
  let fetcher: ReturnType<typeof vi.fn<typeof fetch>>;
  let reading: ReturnType<typeof vi.fn<(text: string) => void>>;
  let requestPort: ReturnType<
    typeof vi.fn<() => Promise<ReturnType<typeof portWithPendingRead>['port']>>
  >;
  const render = (callback = reading) => hooks.render(() => module.useScaleCapture(callback));
  const mount = async () => {
    render();
    hooks.mount();
    await vi.waitFor(() => expect(render().settings).toEqual(settings));
  };
  beforeEach(async () => {
    vi.resetModules();
    hooks = hookHarness();
    vi.doMock('react', () => hooks.react);
    fetcher = vi.fn<typeof fetch>(async () => new Response(JSON.stringify(settings)));
    vi.stubGlobal('fetch', fetcher);
    requestPort = vi.fn();
    vi.stubGlobal('navigator', { serial: { requestPort } });
    api = await import('../lib/api');
    api.pinPageContext(A);
    module = await import('../components/ScaleCapture');
    reading = vi.fn();
  });
  afterEach(() => {
    hooks.unmount();
    vi.doUnmock('react');
    vi.restoreAllMocks();
    vi.unstubAllGlobals();
  });

  it('loads settings through guarded API and preserves exact primary/frame behavior', async () => {
    await mount();
    const headers = new Headers(fetcher.mock.calls[0]?.[1]?.headers);
    expect(fetcher.mock.calls[0]?.[0]).toBe('/api/integrations/device-settings');
    expect(headers.get('x-session-context-id')).toBe(A.sessionId);
    expect(headers.get('x-session-context-epoch')).toBe('7');
    const value = portWithPendingRead();
    value.reader.read
      .mockReset()
      .mockResolvedValueOnce({ value: bytes('ST--kg'), done: false })
      .mockResolvedValueOnce({ value: bytes(' -0012.345 kg'), done: false })
      .mockResolvedValueOnce({ done: true });
    requestPort.mockResolvedValueOnce(value.port);
    await render().connect();
    expect(value.port.open).toHaveBeenCalledTimes(1);
    expect(value.port.open).toHaveBeenCalledWith(settings.scale.profiles.primary);
    expect(reading).toHaveBeenCalledTimes(1);
    expect(reading).toHaveBeenCalledWith('12.345');
    expect(value.reader.releaseLock).toHaveBeenCalledOnce();
    expect(value.port.close).toHaveBeenCalledOnce();
  });

  it('keeps the configured fallback options after a primary open failure', async () => {
    await mount();
    const value = portWithPendingRead();
    value.port.open
      .mockRejectedValueOnce(new Error('primary unavailable'))
      .mockResolvedValueOnce(undefined);
    value.reader.read.mockResolvedValueOnce({ done: true });
    requestPort.mockResolvedValueOnce(value.port);
    await render().connect();
    expect(value.port.open.mock.calls).toEqual([
      [settings.scale.profiles.primary],
      [settings.scale.profiles.fallback],
    ]);
  });

  it('a chooser resolving after page mismatch cannot open a port or publish a reading', async () => {
    await mount();
    const chooser = deferred<ReturnType<typeof portWithPendingRead>['port']>();
    const value = portWithPendingRead();
    requestPort.mockReturnValueOnce(chooser.promise);
    const pending = render().connect();
    api.pinPageContext(B);
    chooser.resolve(value.port);
    await pending;
    expect(value.port.open).not.toHaveBeenCalled();
    expect(reading).not.toHaveBeenCalled();
    expect(render().message).toContain('session context changed');
  });

  it('page mismatch during open closes that port without acquiring a reader', async () => {
    await mount();
    const value = portWithPendingRead();
    const opening = deferred<void>();
    const started = deferred<void>();
    value.port.open.mockImplementationOnce(async () => {
      started.resolve();
      return opening.promise;
    });
    requestPort.mockResolvedValueOnce(value.port);
    const pending = render().connect();
    await started.promise;
    api.pinPageContext(B);
    opening.resolve();
    await pending;
    expect(value.port.readable.getReader).not.toHaveBeenCalled();
    expect(value.port.close).toHaveBeenCalledOnce();
    expect(reading).not.toHaveBeenCalled();
  });

  it('page mismatch during a pending read cancels and rejects a late frame', async () => {
    await mount();
    const value = portWithPendingRead(false);
    requestPort.mockResolvedValueOnce(value.port);
    const pending = render().connect();
    await value.started.promise;
    api.pinPageContext(B);
    value.data.resolve({ done: false, value: bytes('123.456') });
    await pending;
    expect(value.reader.cancel).toHaveBeenCalledOnce();
    expect(reading).not.toHaveBeenCalled();
    expect(value.reader.releaseLock).toHaveBeenCalledOnce();
    expect(value.port.close).toHaveBeenCalledOnce();
  });

  it('unmount invalidates a pending chooser even when the page context itself is unchanged', async () => {
    await mount();
    const chooser = deferred<ReturnType<typeof portWithPendingRead>['port']>();
    const value = portWithPendingRead();
    requestPort.mockReturnValueOnce(chooser.promise);
    const pending = render().connect();
    hooks.unmount();
    chooser.resolve(value.port);
    await pending;
    expect(value.port.open).not.toHaveBeenCalled();
    expect(reading).not.toHaveBeenCalled();
  });

  it('disconnect invalidates a pending frame and closes its own reader/port', async () => {
    await mount();
    const value = portWithPendingRead(false);
    requestPort.mockResolvedValueOnce(value.port);
    const pending = render().connect();
    await value.started.promise;
    await render().disconnect();
    value.data.resolve({ done: false, value: bytes('123.456') });
    await pending;
    expect(reading).not.toHaveBeenCalled();
    expect(value.reader.cancel).toHaveBeenCalledOnce();
    expect(value.port.close).toHaveBeenCalledOnce();
  });

  it('current callback ownership preserves the newly focused row, not the Connect-time callback', async () => {
    await mount();
    const value = portWithPendingRead();
    requestPort.mockResolvedValueOnce(value.port);
    const pending = render().connect();
    await value.started.promise;
    const latest = vi.fn();
    render(latest);
    value.reader.read.mockResolvedValueOnce({ done: true });
    value.data.resolve({ done: false, value: bytes('12.345') });
    await pending;
    expect(reading).not.toHaveBeenCalled();
    expect(latest).toHaveBeenCalledTimes(1);
    expect(latest).toHaveBeenCalledWith('12.345');
  });

  it('obsolete settings refuse reconnect before another chooser is shown', async () => {
    await mount();
    api.pinPageContext(B);
    await render().connect();
    expect(requestPort).not.toHaveBeenCalled();
    expect(reading).not.toHaveBeenCalled();
  });
});
