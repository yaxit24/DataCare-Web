import { beforeEach, describe, expect, it, vi } from 'vitest';

const get = vi.fn();
vi.mock('../lib/api', () => ({ get: (path: string) => get(path) }));

const { documentLinkFrom, openDocument } = await import('../lib/openDocument');

function fakeOpener() {
  const opened: Array<{ url: string; target?: string }> = [];
  const win = { closed: false, location: { href: 'about:blank' } };
  const opener = {
    open: vi.fn((url: string, target?: string) => {
      opened.push({ url, target });
      return url === '' ? (win as unknown as Window) : null;
    }),
  };
  return { opener, opened, win };
}
const flush = () => new Promise((resolve) => setTimeout(resolve, 0));

describe('openDocument (G180)', () => {
  beforeEach(() => {
    get.mockReset();
  });

  it('opens the window inside the click and points it at the document after the session check', async () => {
    let finish: (value: unknown) => void = () => {};
    get.mockReturnValue(new Promise((resolve) => (finish = resolve)));
    const { opener, opened, win } = fakeOpener();
    openDocument('/api/sales/invoice?vchNo=00001&format=html', opener);
    expect(opened).toEqual([{ url: '', target: '_blank' }]);
    expect(get).toHaveBeenCalledWith('/me');
    expect(win.location.href).toBe('about:blank'); // not before the session is fresh
    finish({});
    await flush();
    expect(win.location.href).toBe('/api/sales/invoice?vchNo=00001&format=html');
  });

  it('still opens the document when the session check fails', async () => {
    get.mockImplementation(async () => {
      throw new Error('unauthenticated');
    });
    const { opener, win } = fakeOpener();
    openDocument('/api/purchases/invoice?vchNo=00002', opener);
    await flush();
    expect(win.location.href).toBe('/api/purchases/invoice?vchNo=00002');
  });

  it('falls back to a plain window when the first one was blocked', async () => {
    get.mockResolvedValue({});
    const opened: Array<{ url: string; target?: string }> = [];
    const opener = {
      open: vi.fn((url: string, target?: string) => {
        opened.push({ url, target });
        return null; // blocked
      }),
    };
    openDocument('/api/reports/x/export.xlsx', opener);
    await flush();
    expect(opened).toEqual([
      { url: '', target: '_blank' },
      { url: '/api/reports/x/export.xlsx', target: '_blank' },
    ]);
  });

  it('does not reopen a window the operator closed before the document loaded', async () => {
    get.mockResolvedValue({});
    const { opener, opened, win } = fakeOpener();
    openDocument('/api/sales/invoice?vchNo=00003', opener);
    win.closed = true;
    await flush();
    expect(opened).toEqual([{ url: '', target: '_blank' }]);
    expect(win.location.href).toBe('about:blank');
  });
});

describe('documentLinkFrom', () => {
  const click = (href: string | null, target = '_blank', extra: Record<string, unknown> = {}) => ({
    defaultPrevented: false,
    button: 0,
    altKey: false,
    ctrlKey: false,
    metaKey: false,
    shiftKey: false,
    target: {
      closest: (selector: string) =>
        href !== null && selector === 'a[target="_blank"][href]' && target === '_blank'
          ? { getAttribute: (name: string) => (name === 'href' ? href : null) }
          : null,
    } as unknown as EventTarget,
    ...extra,
  });

  it('takes a plain left click on a new-tab /api link', () => {
    expect(documentLinkFrom(click('/api/sales/invoice?vchNo=1&format=html'))).toBe(
      '/api/sales/invoice?vchNo=1&format=html',
    );
  });

  it('leaves app links, same-tab links, modified and handled clicks alone', () => {
    expect(documentLinkFrom(click('/txn/sales'))).toBeNull();
    expect(documentLinkFrom(click('https://example.com/api/x'))).toBeNull();
    expect(documentLinkFrom(click('/api/x', '_self'))).toBeNull();
    expect(documentLinkFrom(click(null))).toBeNull();
    for (const key of ['altKey', 'ctrlKey', 'metaKey', 'shiftKey'])
      expect(documentLinkFrom(click('/api/x', '_blank', { [key]: true }))).toBeNull();
    expect(documentLinkFrom(click('/api/x', '_blank', { button: 1 }))).toBeNull();
    expect(documentLinkFrom(click('/api/x', '_blank', { defaultPrevented: true }))).toBeNull();
  });
});
