'use client';

import {
  createPageContextGuard,
  pageContextHeaders,
  PageContextError,
  type PageContextTicket,
} from './pageContext';
export { PageContextError } from './pageContext';
export type { BrowserSessionContext, PageContextState, PageContextTicket } from './pageContext';

export type Json = Record<string, any>;

export class ApiError extends Error {
  status: number;
  body: any;
  constructor(message: string, status: number, body: any) {
    super(message);
    this.status = status;
    this.body = body;
  }
}

const page = createPageContextGuard();
export const getPageContextState = page.read;
export const subscribePageContext = page.subscribe;
export const pinPageContext = page.observe;
/** Freeze retained drafts after an unconfirmed company-selection outcome; never adopt a guess. */
export const pausePageContextForSelection = page.pauseForSelection;
/** Device/result leases share the same page identity without exposing it in BusinessScope. */
export const capturePageContextTicket = page.capture;
export const assertPageContextTicket = page.assertCurrent;
/** Call only when the operator explicitly navigates away/discards the old page. */
export const resetPageContextForNavigation = page.resetForNavigation;

interface RefreshResult {
  ok: boolean;
  /** Only unbound /me bootstrap can use a newly established ticket. */
  bootstrapTicket?: PageContextTicket;
}
interface RefreshFlight {
  ticket: PageContextTicket;
  promise: Promise<RefreshResult>;
}
let refreshInFlight: RefreshFlight | null = null;
const routeOf = (path: string) => path.split('?', 1)[0];
const isExplicitAuthControl = (path: string) =>
  ['/auth/login', '/auth/logout'].includes(routeOf(path) ?? '');
function headersFor(opts: RequestInit, ticket: PageContextTicket | null): Headers {
  const headers = new Headers(opts.headers);
  if (!headers.has('content-type')) headers.set('content-type', 'application/json');
  // Request options cannot override the page's captured authority.
  headers.delete('x-session-context-id');
  headers.delete('x-session-context-epoch');
  if (ticket)
    for (const [key, value] of Object.entries(pageContextHeaders(ticket))) headers.set(key, value);
  return headers;
}
async function readBody(response: Response): Promise<any> {
  const text = await response.text();
  if (!text) return null;
  try {
    return JSON.parse(text);
  } catch {
    return { error: text };
  }
}
function observeContext(body: any): PageContextTicket {
  const state = page.observe(body?.context);
  if (state.status !== 'ready') throw new PageContextError('context-stale');
  return page.capture();
}
async function refreshAccess(ticket: PageContextTicket): Promise<RefreshResult> {
  page.assertCurrent(ticket);
  if (refreshInFlight?.ticket.revision === ticket.revision) return refreshInFlight.promise;
  const promise = (async (): Promise<RefreshResult> => {
    try {
      const response = await fetch('/api/auth/refresh', {
        method: 'POST',
        credentials: 'include',
        headers: headersFor({}, ticket),
        body: '{}',
      });
      const body = await readBody(response);
      page.assertCurrent(ticket);
      if (!response.ok) {
        if (response.status === 409 && body?.error === 'context-stale') page.reject(ticket);
        return { ok: false };
      }
      const next = observeContext(body);
      return { ok: true, ...(ticket.context === null ? { bootstrapTicket: next } : {}) };
    } catch (error) {
      if (error instanceof PageContextError) throw error;
      page.assertCurrent(ticket);
      return { ok: false };
    }
  })();
  const flight = { ticket, promise };
  refreshInFlight = flight;
  const finish = () => {
    if (refreshInFlight === flight) refreshInFlight = null;
  };
  void promise.then(finish, finish);
  return promise;
}

async function call<T = any>(
  path: string,
  opts: RequestInit = {},
  retry = true,
  captured?: PageContextTicket | null,
): Promise<T> {
  const ticket =
    captured === undefined ? (isExplicitAuthControl(path) ? null : page.capture()) : captured;
  if (ticket) page.assertCurrent(ticket);
  let res: Response;
  let body: any;
  try {
    res = await fetch('/api' + path, {
      ...opts,
      credentials: 'include',
      headers: headersFor(opts, ticket),
    });
    body = await readBody(res);
  } catch (error) {
    if (ticket) page.assertCurrent(ticket);
    throw error;
  }
  if (ticket) page.assertCurrent(ticket);
  if (!res.ok) {
    if (ticket && res.status === 409 && body?.error === 'context-stale') page.reject(ticket);
    const refreshable =
      retry &&
      ticket !== null &&
      res.status === 401 &&
      !['/auth/login', '/auth/refresh', '/auth/logout'].includes(routeOf(path) ?? '');
    if (refreshable && ticket) {
      const refreshed = await refreshAccess(ticket);
      if (refreshed.ok) {
        // The only new-identity retry is a still-unbound, read-only /me bootstrap.
        // Other requests retain their original ticket and exact body bytes.
        const next =
          ticket.context === null && routeOf(path) === '/me' && refreshed.bootstrapTicket
            ? refreshed.bootstrapTicket
            : ticket;
        page.assertCurrent(next);
        return call<T>(path, opts, false, next);
      }
    }
    throw new ApiError(body?.error || res.statusText, res.status, body);
  }
  if (ticket && ['/me', '/auth/refresh'].includes(routeOf(path) ?? '')) observeContext(body);
  // /context/select is an intentional transition; its caller owns explicit navigation.
  return body as T;
}

export const get = <T = any>(p: string) => call<T>(p);
/** Bootstrap-only retry for overlapping /me loads; never retries a business draft. */
export async function loadPageSession<T = any>(): Promise<T> {
  try {
    return await get<T>('/me');
  } catch (error) {
    if (
      !(error instanceof PageContextError) ||
      error.code !== 'context-response-obsolete' ||
      page.read().status !== 'ready'
    )
      throw error;
    return get<T>('/me');
  }
}

export const post = <T = any>(p: string, b?: Json) =>
  call<T>(p, { method: 'POST', body: JSON.stringify(b ?? {}) });
export const put = <T = any>(p: string, b?: Json) =>
  call<T>(p, { method: 'PUT', body: JSON.stringify(b ?? {}) });
export const del = <T = any>(p: string, b?: Json) =>
  call<T>(p, { method: 'DELETE', body: JSON.stringify(b ?? {}) });

/** Read exact binary bytes with page guards; no automatic retry or error-body download. */
export async function getBlob(path: string): Promise<Blob> {
  const ticket = page.capture();
  try {
    const response = await fetch('/api' + path, {
      credentials: 'include',
      headers: headersFor({}, ticket),
    });
    page.assertCurrent(ticket);
    if (!response.ok) {
      const body = await readBody(response);
      page.assertCurrent(ticket);
      if (response.status === 409 && body?.error === 'context-stale') page.reject(ticket);
      throw new ApiError(body?.error || response.statusText, response.status, body);
    }
    const blob = await response.blob();
    page.assertCurrent(ticket);
    return blob;
  } catch (error) {
    page.assertCurrent(ticket);
    throw error;
  }
}

/** Export an array of row objects to a downloaded CSV (client-side, no server). */
export function downloadCsv(rows: Record<string, any>[], filename: string): void {
  if (!rows || !rows.length) return;
  const cols = Object.keys(rows[0]);
  const esc = (v: any): string => `"${String(v ?? '').replace(/"/g, '""')}"`;
  const csv = [cols.join(','), ...rows.map((r) => cols.map((c) => esc(r[c])).join(','))].join('\n');
  const blob = new Blob([csv], { type: 'text/csv;charset=utf-8' });
  const url = URL.createObjectURL(blob);
  const a = document.createElement('a');
  a.href = url;
  a.download = `${filename}.csv`;
  document.body.appendChild(a);
  a.click();
  a.remove();
  setTimeout(() => URL.revokeObjectURL(url), 1000);
}

/** POST HTML and download only while the captured page context remains current. */
export async function downloadPdf(html: string, filename: string): Promise<void> {
  const ticket = page.capture();
  let res: Response;
  try {
    res = await fetch('/api/render/pdf', {
      method: 'POST',
      credentials: 'include',
      headers: headersFor({}, ticket),
      body: JSON.stringify({ html, filename }),
    });
    page.assertCurrent(ticket);
    if (!res.ok) {
      const body = await readBody(res);
      page.assertCurrent(ticket);
      if (res.status === 409 && body?.error === 'context-stale') page.reject(ticket);
      throw new ApiError('pdf failed', res.status, body);
    }
    const blob = await res.blob();
    page.assertCurrent(ticket);
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = `${filename}.pdf`;
    document.body.appendChild(a);
    a.click();
    a.remove();
    setTimeout(() => URL.revokeObjectURL(url), 1000);
  } catch (error) {
    page.assertCurrent(ticket);
    throw error;
  }
}
