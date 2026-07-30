import { describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import {
  REPORT_FILTER_BINDINGS,
  REPORT_FILTER_KEYS,
  supportedFilters,
} from '../src/modules/reports/reportFilters.js';

/**
 * The global report-filter guard.
 *
 * This exists because of a defect live verification exposed: only the five BOUND report builders called
 * `applyFilters`, so `GET /reports/day-book?city=Surat` returned **200 with an unfiltered result set**. An
 * operator would have read a whole-year day book as though it were narrowed to one city — the precise failure
 * the "refuse, never drop" design is meant to prevent.
 *
 * The guard is a `preHandler` on every `/reports/*` route, so coverage does not depend on a builder
 * remembering to opt in. These tests run before authentication succeeds, which is fine: the assertion is that
 * the request is rejected with a FILTER error rather than reaching a builder that would ignore the filter.
 */
describe('global report filter guard', () => {
  const app = async () =>
    buildApp({
      // No query ever runs: the guard rejects first, or auth does. Neither path touches the database.
      prisma: { $transaction: (fn: (t: unknown) => unknown) => fn({}) },
      secret: 'test-random-signing-key-with-more-than-thirty-two-characters',
      secureCookies: true,
      defaultTenantId: 'tenant-a',
      allowTenantHeader: false,
    });

  const ask = async (url: string) => {
    const a = await app();
    const r = await a.inject({ method: 'GET', url });
    await a.close();
    return r;
  };

  it('refuses a shared filter on a report that does not apply it', async () => {
    const r = await ask('/reports/day-book?city=Surat');
    expect(r.statusCode, 'must be a client error, not a silent 200').toBe(400);
    expect(r.json()).toMatchObject({
      error: 'ReportFilterError',
      message: expect.stringContaining('city'),
    });
  });

  it('refuses a dimension a BOUND report cannot honour', async () => {
    // BAR_DETL has no EMP_CODE, so stock-valuation genuinely cannot filter by employee.
    const r = await ask('/reports/stock-valuation?empCode=E1');
    expect(r.statusCode).toBe(400);
    expect(r.json().message).toContain('empCode');
  });

  it('names every offending dimension, not just the first', async () => {
    const r = await ask('/reports/day-book?city=Surat&state=GJ&grCode=GO');
    expect(r.statusCode).toBe(400);
    const msg = r.json().message as string;
    for (const k of ['city', 'state', 'grCode']) expect(msg).toContain(k);
  });

  it('guards the export and csv variants too', async () => {
    // A workbook must not be able to bypass the guard and export unfiltered rows.
    for (const url of [
      '/reports/day-book/export.xlsx?city=Surat',
      '/reports/day-book.csv?city=Surat',
    ]) {
      const r = await ask(url);
      // 400 when the route exists; 404 when that variant is not registered. Never 200.
      expect([400, 404], `${url} must not succeed`).toContain(r.statusCode);
    }
  });

  it('does not interfere when no shared filter is supplied', async () => {
    // Without a filter the guard must be transparent, so an unauthenticated request fails on AUTH (401/403)
    // rather than being rejected as a filter error.
    const r = await ask('/reports/day-book');
    expect(r.statusCode).not.toBe(400);
    if (r.statusCode >= 400) {
      expect(JSON.stringify(r.json())).not.toContain('ReportFilterError');
    }
  });

  it('lets a supported dimension through the guard', async () => {
    // grCode is honoured by stock-valuation, so the guard must not reject it; the request then proceeds to
    // authentication.
    const r = await ask('/reports/stock-valuation?grCode=GO');
    expect(r.statusCode).not.toBe(400);
  });

  it('treats a blank filter value as absent', async () => {
    const r = await ask('/reports/day-book?city=&state=%20%20');
    expect(r.statusCode).not.toBe(400);
  });

  it('keeps the guard and the advertised capability in one source of truth', () => {
    // The hook and GET /reports/:report/filters both read REPORT_FILTER_BINDINGS, so what is advertised and
    // what is accepted cannot drift.
    for (const [slug, binding] of Object.entries(REPORT_FILTER_BINDINGS)) {
      const allowed = supportedFilters(binding);
      expect(allowed.length, `${slug} must honour at least one dimension`).toBeGreaterThan(0);
      for (const k of allowed) expect(REPORT_FILTER_KEYS).toContain(k);
    }
  });

  it('returns 404 for an unknown path, not a 500', async () => {
    // Found while testing the guard: every unmatched URL previously returned 500 `route-policy-missing`,
    // because the auth preHandler runs for unmatched requests and found no policy. Ordinary 404 noise would
    // have been indistinguishable from real server faults in production alerting.
    for (const url of ['/reports/day-book.csv', '/reports/nonexistent', '/totally/unknown']) {
      const r = await ask(url);
      expect(r.statusCode, `${url} must be 404`).toBe(404);
      expect(r.json()).toEqual({ error: 'not-found' });
    }
  });
});
