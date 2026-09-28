import { describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { issueAccess } from '../src/modules/auth/jwt.js';
import {
  REPORT_FILTER_BINDINGS,
  REPORT_FILTER_KEYS,
  supportedFilters,
} from '../src/modules/reports/reportFilters.js';

const SECRET = 'test-random-signing-key-with-more-than-thirty-two-characters';
const SESSION_ID = 'report-filter-session';

/**
 * The global report-filter guard.
 *
 * This exists because of a defect live verification exposed: only the five BOUND report builders called
 * `applyFilters`, so `GET /reports/day-book?city=Surat` returned **200 with an unfiltered result set**. An
 * operator would have read a whole-year day book as though it were narrowed to one city — the precise failure
 * the "refuse, never drop" design is meant to prevent.
 *
 * The guard runs after central authentication and per-form authorization but before route handlers, so
 * coverage does not depend on a builder remembering to opt in and invalid filters cannot preempt 401/403.
 */
describe('global report filter guard', () => {
  const app = async () =>
    buildApp({
      prisma: {
        $transaction: (fn: (tx: unknown) => unknown) =>
          fn({
            $executeRawUnsafe: async () => 1,
            $queryRawUnsafe: async (sqlValue: unknown) => {
              const sql = String(sqlValue);
              if (sql.includes('FROM "auth_session"')) {
                return [
                  {
                    tenantId: 'tenant-a',
                    sessionId: SESSION_ID,
                    loginName: 'ADMIN',
                    loginCoCode: '01',
                    coCode: '01',
                    lcCode: '01',
                    coYear: '2024-2025',
                    contextEpoch: '1', revoked: false, unexpired: true,
            ledgerContext: { version: 'server-session-ledger-context-v1', status: 'unknown', mode: null, reason: 'vendor-authority-unresolved' },
            refreshJtiHash: '0'.repeat(64),
                    expiresAt: new Date(Date.now() + 60_000),
                    revokedAt: null,
                    revokeReason: null,
                  },
                ];
              }
              if (sql.includes('FROM "LOGIN_MAST"')) {
                return [
                  {
                    CO_CODE: '01',
                    LOGIN_NAME: 'ADMIN',
                    LOGIN_PWD: 'unused',
                    LOGIN_CATG: 'ADMIN',
                    USER_UPDATE: 'Y',
                    USER_DELETE: 'Y',
                    USER_PRINT: 'Y',
                    PASSWORD_RESET_REQUIRED: 'N',
                  },
                ];
              }
              // Authorized report builders reached by supported/blank/no-filter cases see an empty fixture.
              return [];
            },
          }),
      },
      secret: SECRET,
      secureCookies: true,
      defaultTenantId: 'tenant-a',
      allowTenantHeader: false,
    });

  const ask = async (url: string) => {
    const access = await issueAccess(
      {
        sub: 'ADMIN',
        tenantId: 'tenant-a',
        loginCoCode: '01',
        coCode: '01',
        lcCode: '01',
        coYear: '2024-2025',
        sid: SESSION_ID,
        contextEpoch: '1',
        rights: { userUpdate: true, userDelete: true, userPrint: true },
      },
      SECRET,
    );
    const a = await app();
    const r = await a.inject({ method: 'GET', url, headers: { cookie: `access=${access}` } });
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
    // Without a filter the guard must be transparent, so the authorized report proceeds rather than being
    // rejected as a filter error.
    const r = await ask('/reports/day-book');
    expect(r.statusCode).not.toBe(400);
    if (r.statusCode >= 400) {
      expect(JSON.stringify(r.json())).not.toContain('ReportFilterError');
    }
  });

  it('lets a supported dimension through the guard', async () => {
    // grCode is honoured by stock-valuation, so the guard must not reject it and the authorized request
    // proceeds to its report builder.
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
