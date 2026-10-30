import { get } from './api';

/**
 * Open a server-built document (a print, PDF or export under /api) in a new window (N173, G180).
 *
 * The window's own request carries only the cookies. When the 15-minute access cookie has expired, that request
 * cannot refresh it and the window shows `{"error":"unauthenticated"}`, while the screen's API calls refresh the cookie
 * themselves (`lib/api.ts`). So the window opens at once, inside the click (popup blockers require that), and is pointed
 * at the document only after an API call has made the session fresh.
 */
export function openDocument(url: string, opener: Pick<Window, 'open'> = window): void {
  const target = opener.open('', '_blank');
  void (async () => {
    try {
      await get('/me');
    } catch {
      // A failed check still opens the document: its own response then explains the problem.
    }
    // A blocked window falls back to a plain one; a window the operator already closed stays closed.
    if (!target) opener.open(url, '_blank');
    else if (!target.closed) target.location.href = url;
  })();
}

type ClickLike = {
  defaultPrevented: boolean;
  button: number;
  altKey: boolean;
  ctrlKey: boolean;
  metaKey: boolean;
  shiftKey: boolean;
  target: EventTarget | null;
};

/**
 * The document a plain left click on a new-tab /api link opens, or null for every other click. Links such as the
 * recent-voucher list's Print go through `openDocument` too; a modified click (new tab, download) is left alone.
 */
export function documentLinkFrom(event: ClickLike): string | null {
  if (event.defaultPrevented || event.button !== 0) return null;
  if (event.altKey || event.ctrlKey || event.metaKey || event.shiftKey) return null;
  const target = event.target as { closest?: (selector: string) => Element | null } | null;
  const link = target?.closest?.('a[target="_blank"][href]');
  const href = link?.getAttribute('href') ?? '';
  return href.startsWith('/api/') ? href : null;
}
