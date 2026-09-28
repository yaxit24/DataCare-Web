'use client';

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

let refreshInFlight: Promise<boolean> | null = null;

async function refreshAccess(): Promise<boolean> {
  if (!refreshInFlight) {
    refreshInFlight = fetch('/api/auth/refresh', {
      method: 'POST',
      credentials: 'include',
      headers: { 'content-type': 'application/json' },
      body: '{}',
    })
      .then((response) => response.ok)
      .catch(() => false)
      .finally(() => {
        refreshInFlight = null;
      });
  }
  return refreshInFlight;
}

async function call<T = any>(path: string, opts: RequestInit = {}, retry = true): Promise<T> {
  const res = await fetch('/api' + path, {
    ...opts,
    credentials: 'include',
    headers: { 'content-type': 'application/json', ...(opts.headers || {}) },
  });
  const text = await res.text();
  let body: any = null;
  if (text) {
    try {
      body = JSON.parse(text);
    } catch {
      body = { error: text };
    }
  }
  if (!res.ok) {
    const refreshable =
      retry &&
      res.status === 401 &&
      path !== '/auth/login' &&
      path !== '/auth/refresh' &&
      path !== '/auth/logout';
    if (refreshable && (await refreshAccess())) return call<T>(path, opts, false);
    throw new ApiError(body?.error || res.statusText, res.status, body);
  }
  return body as T;
}

export const get = <T = any>(p: string) => call<T>(p);
export const post = <T = any>(p: string, b?: Json) =>
  call<T>(p, { method: 'POST', body: JSON.stringify(b ?? {}) });
export const put = <T = any>(p: string, b?: Json) =>
  call<T>(p, { method: 'PUT', body: JSON.stringify(b ?? {}) });
export const del = <T = any>(p: string, b?: Json) =>
  call<T>(p, { method: 'DELETE', body: JSON.stringify(b ?? {}) });

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

/** POST HTML to the server PDF renderer (Chromium) and trigger a browser download. */
export async function downloadPdf(html: string, filename: string): Promise<void> {
  const res = await fetch('/api/render/pdf', {
    method: 'POST',
    credentials: 'include',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify({ html, filename }),
  });
  if (!res.ok) throw new ApiError('pdf failed', res.status, null);
  const blob = await res.blob();
  const url = URL.createObjectURL(blob);
  const a = document.createElement('a');
  a.href = url;
  a.download = `${filename}.pdf`;
  document.body.appendChild(a);
  a.click();
  a.remove();
  setTimeout(() => URL.revokeObjectURL(url), 1000);
}
