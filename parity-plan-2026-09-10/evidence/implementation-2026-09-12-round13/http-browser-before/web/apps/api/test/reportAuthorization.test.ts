import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it, vi } from 'vitest';
import { buildApp } from '../src/app.js';
import { issueAccess } from '../src/modules/auth/jwt.js';
import { getFormEntry, rightNamesForForm } from '../src/modules/rbac/formCatalog.js';
import {
  resolvePolicyForm,
  routePolicyFor,
  type RoutePolicy,
} from '../src/modules/rbac/routePolicy.js';
import {
  REPORT_FORM_BY_SLUG,
  REPORT_SLUGS,
  reportFormForSlug,
  type CanonicalReportForm,
} from '../src/modules/reports/reportAuthorization.js';
import { REPORT_FILTER_BINDINGS } from '../src/modules/reports/reportFilters.js';

const SECRET = 'report-authorization-test-secret-with-more-than-thirty-two-characters';
const TENANT_ID = 'report-auth-tenant';
const LOGIN_NAME = 'REPORT_USER';
const COMPANY = '01';
const LOCATION = '01';
const YEAR = '2024-2025';
const SESSION_ID = 'report-auth-session';

const genericPolicies = () => {
  const filters = routePolicyFor('GET', '/reports/:report/filters')!;
  const csv = routePolicyFor('GET', '/reports/:report/export.csv')!;
  const xlsx = routePolicyFor('GET', '/reports/:report/export.xlsx')!;
  return { filters, csv, xlsx };
};

describe('generic report authorization contract', () => {
  it('maps exactly 83 immutable report slugs to canonical form-catalog entries', () => {
    expect(REPORT_SLUGS).toHaveLength(83);
    expect(new Set(REPORT_SLUGS).size).toBe(83);
    expect(Object.isFrozen(REPORT_FORM_BY_SLUG)).toBe(true);
    expect(Object.isFrozen(REPORT_SLUGS)).toBe(true);

    for (const [slug, form] of Object.entries(REPORT_FORM_BY_SLUG)) {
      expect(slug).toMatch(/^[a-z0-9]+(?:-[a-z0-9]+)*$/);
      expect(form).toMatch(/^Reports\//);
      expect(getFormEntry(form), `${slug} must reference a canonical form`).toBeDefined();
    }
  });

  it('matches every generic slug to the same form as its fixed report screen', () => {
    for (const [slug, form] of Object.entries(REPORT_FORM_BY_SLUG)) {
      expect(routePolicyFor('GET', `/reports/${slug}`), slug).toMatchObject({
        kind: 'form',
        form,
        action: 'read',
      });
    }
  });

  it('resolves every filter to view and every CSV/XLSX export to print on its own form', () => {
    const { filters, csv, xlsx } = genericPolicies();
    expect(filters).toMatchObject({ kind: 'form', form: '@report', action: 'read' });
    expect(csv).toMatchObject({ kind: 'form', form: '@report', action: 'print' });
    expect(xlsx).toMatchObject({ kind: 'form', form: '@report', action: 'print' });

    for (const [slug, form] of Object.entries(REPORT_FORM_BY_SLUG)) {
      for (const policy of [filters, csv, xlsx]) {
        expect(resolvePolicyForm(policy, { report: slug }), slug).toBe(form);
      }
    }
  });

  it('fails closed for unknown, malformed, case-shifted, and inherited-property slugs', () => {
    const { filters, csv, xlsx } = genericPolicies();
    for (const slug of [
      '',
      'unknown-report',
      'Sales-Register',
      'sales-register/../tag-estimate',
      '__proto__',
      'constructor',
      null,
      undefined,
      42,
    ]) {
      expect(reportFormForSlug(slug), String(slug)).toBeUndefined();
      for (const policy of [filters, csv, xlsx]) {
        expect(resolvePolicyForm(policy, { report: slug }), String(slug)).toBeUndefined();
      }
    }
  });

  it('keeps PDF/HTML document and Crystal-layout routes on explicit print/view policies', () => {
    const documents = [
      ['/reports/gstr1-doc', 'Reports/GSTR-1'],
      ['/reports/gstr2-doc', 'Reports/GSTR-2 (Purchase)'],
      ['/reports/gstr3b-doc', 'Reports/GSTR-3B'],
      ['/reports/trial-balance-doc', 'Reports/Trial Balance'],
      ['/reports/balance-sheet-doc', 'Reports/Balance Sheet'],
    ] as const;
    for (const [path, form] of documents) {
      expect(routePolicyFor('GET', path)).toMatchObject({ form, action: 'print' });
    }
    expect(routePolicyFor('GET', '/reports/layouts')).toMatchObject({
      form: 'Reports/Report Layouts (Crystal)',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/layout')).toMatchObject({
      form: 'Reports/Report Layouts (Crystal)',
      action: 'read',
    });
    expect(routePolicyFor('GET', '/reports/render')).toMatchObject({
      form: 'Reports/Report Layouts (Crystal)',
      action: 'print',
    });
  });
});

type HarnessState = {
  allowedForm?: CanonicalReportForm;
  view: boolean;
  print: boolean;
  role: 'USER' | 'ADMIN';
  allowReportQueries: boolean;
};

function authorizationHarness() {
  const state: HarnessState = {
    view: false,
    print: false,
    role: 'USER',
    allowReportQueries: false,
  };
  const reportQueries: string[] = [];
  const unexpectedQueries: string[] = [];

  const tx = {
    $executeRawUnsafe: vi.fn(async () => 1),
    $queryRawUnsafe: vi.fn(async (sqlValue: unknown, ...params: unknown[]) => {
      const sql = String(sqlValue);
      if (sql.includes('FROM "auth_session"')) {
        return [
          {
            tenantId: TENANT_ID,
            sessionId: SESSION_ID,
            loginName: LOGIN_NAME,
            loginCoCode: COMPANY,
            coCode: COMPANY,
            lcCode: LOCATION,
            coYear: YEAR,
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
            CO_CODE: COMPANY,
            LOGIN_NAME,
            LOGIN_PWD: 'unused',
            LOGIN_CATG: state.role,
            USER_UPDATE: 'N',
            USER_DELETE: 'N',
            USER_PRINT: 'Y',
            PASSWORD_RESET_REQUIRED: 'N',
          },
        ];
      }
      if (sql.includes('FROM "USER_SET"')) {
        const requestedNames = new Set(params.slice(2).map((value) => String(value).toUpperCase()));
        const ownsRequestedForm =
          state.allowedForm != null &&
          rightNamesForForm(state.allowedForm).some((name) =>
            requestedNames.has(name.toUpperCase()),
          );
        return ownsRequestedForm
          ? [
              {
                FRM_VIEW: state.view ? 'Y' : 'N',
                FRM_EDIT: 'N',
                FRM_DELETE: 'N',
                FRM_PRINT: state.print ? 'Y' : 'N',
              },
            ]
          : [];
      }
      if (state.allowReportQueries) {
        reportQueries.push(sql);
        return [];
      }
      unexpectedQueries.push(sql);
      throw new Error(`report builder unexpectedly reached database: ${sql.slice(0, 120)}`);
    }),
  };
  const prisma = {
    $transaction: vi.fn((fn: (transaction: typeof tx) => unknown) => fn(tx)),
  };
  return { state, prisma, reportQueries, unexpectedQueries };
}

describe('authenticated generic report routes', () => {
  let app: FastifyInstance;
  let access: string;
  const harness = authorizationHarness();

  const setRights = (
    form: CanonicalReportForm | undefined,
    rights: { view?: boolean; print?: boolean } = {},
  ) => {
    harness.state.allowedForm = form;
    harness.state.view = rights.view ?? false;
    harness.state.print = rights.print ?? false;
    harness.state.role = 'USER';
    harness.state.allowReportQueries = false;
  };

  const get = (url: string) =>
    app.inject({ method: 'GET', url, headers: { cookie: `access=${access}` } });
  const getUnauthenticated = (url: string) => app.inject({ method: 'GET', url });

  beforeAll(async () => {
    access = await issueAccess(
      {
        sub: LOGIN_NAME,
        tenantId: TENANT_ID,
        loginCoCode: COMPANY,
        coCode: COMPANY,
        lcCode: LOCATION,
        coYear: YEAR,
        sid: SESSION_ID,
        rights: { userUpdate: false, userDelete: false, userPrint: true },
      },
      SECRET,
    );
    app = await buildApp({
      prisma: harness.prisma,
      secret: SECRET,
      secureCookies: false,
      defaultTenantId: TENANT_ID,
      allowTenantHeader: false,
    });
  });

  afterAll(async () => {
    if (app) await app.close();
  });

  it('enforces the requested form view/print matrix for every report slug and both export formats', async () => {
    for (const slug of REPORT_SLUGS) {
      const form = REPORT_FORM_BY_SLUG[slug];

      setRights(form, { view: true, print: false });
      const filters = await get(`/reports/${slug}/filters`);
      const expectedFilterStatus = REPORT_FILTER_BINDINGS[slug] ? 200 : 404;
      expect(filters.statusCode, `${slug} filter with own View right`).toBe(expectedFilterStatus);

      for (const format of ['csv', 'xlsx']) {
        const denied = await get(`/reports/${slug}/export.${format}`);
        expect(denied.statusCode, `${slug} ${format} must require Print`).toBe(403);
        expect(denied.json()).toMatchObject({ error: 'forbidden', form, action: 'print' });
      }

      setRights(form, { view: false, print: true });
      const viewDenied = await get(`/reports/${slug}/filters`);
      expect(viewDenied.statusCode, `${slug} filters must require View`).toBe(403);
      expect(viewDenied.json()).toMatchObject({ error: 'forbidden', form, action: 'read' });
    }
    expect(harness.unexpectedQueries).toEqual([]);
  }, 30_000);

  it('allows an export only when the requested report has both View and Print', async () => {
    setRights('Reports/Tag Estimate', { view: true, print: true });
    harness.state.allowReportQueries = true;
    try {
      const response = await get('/reports/tag-estimate/export.csv');
      expect(response.statusCode).toBe(200);
      expect(response.headers['content-type']).toContain('text/csv');
      expect(harness.reportQueries.length).toBeGreaterThan(0);
    } finally {
      harness.state.allowReportQueries = false;
    }
  });

  it('authenticates and authorizes before validating report filter capabilities', async () => {
    const paths = [
      '/reports/sales-register/filters?city=Surat',
      '/reports/sales-register/export.csv?city=Surat',
      '/reports/sales-register/export.xlsx?city=Surat',
    ];

    for (const path of paths) {
      const unauthenticated = await getUnauthenticated(path);
      expect(unauthenticated.statusCode, path).toBe(401);
      expect(unauthenticated.json()).toEqual({ error: 'unauthenticated' });
    }

    setRights('Reports/Tag Estimate', { view: true, print: true });
    for (const path of paths) {
      const wrongReportRight = await get(path);
      expect(wrongReportRight.statusCode, path).toBe(403);
      expect(wrongReportRight.json()).toMatchObject({
        error: 'forbidden',
        form: 'Reports/Sales Register',
      });
    }

    setRights('Reports/Sales Register', { view: true, print: true });
    for (const path of paths) {
      const authorizedInvalidFilter = await get(path);
      expect(authorizedInvalidFilter.statusCode, path).toBe(400);
      expect(authorizedInvalidFilter.json()).toMatchObject({ error: 'ReportFilterError' });
    }
    expect(harness.unexpectedQueries).toEqual([]);
  });

  it('returns 403 when Sales Register rights are used against Tag Estimate', async () => {
    setRights('Reports/Sales Register', { view: true, print: true });
    for (const path of [
      '/reports/tag-estimate/filters',
      '/reports/tag-estimate/export.csv',
      '/reports/tag-estimate/export.xlsx',
    ]) {
      const response = await get(path);
      expect(response.statusCode, path).toBe(403);
      expect(response.json()).toMatchObject({
        error: 'forbidden',
        form: 'Reports/Tag Estimate',
      });
    }
    expect(harness.unexpectedQueries).toEqual([]);
  });

  it('returns 403 when Tag Estimate rights are used against Sales Register', async () => {
    setRights('Reports/Tag Estimate', { view: true, print: true });
    for (const path of [
      '/reports/sales-register/filters',
      '/reports/sales-register/export.csv',
      '/reports/sales-register/export.xlsx',
    ]) {
      const response = await get(path);
      expect(response.statusCode, path).toBe(403);
      expect(response.json()).toMatchObject({
        error: 'forbidden',
        form: 'Reports/Sales Register',
      });
    }
    expect(harness.unexpectedQueries).toEqual([]);
  });

  it('returns unresolved-form 403 for every unknown generic endpoint before report data access', async () => {
    setRights('Reports/Sales Register', { view: true, print: true });
    const cases = [
      ['/reports/not-a-report/filters', 'read'],
      ['/reports/not-a-report/export.csv?city=Surat', 'print'],
      ['/reports/not-a-report/export.xlsx', 'print'],
    ] as const;
    for (const [path, action] of cases) {
      const response = await get(path);
      expect(response.statusCode, path).toBe(403);
      expect(response.json()).toEqual({ error: 'forbidden', form: 'unresolved', action });
    }
    expect(harness.unexpectedQueries).toEqual([]);
  });

  it('preserves the administrator bypass only for recognized report slugs', async () => {
    setRights(undefined);
    harness.state.role = 'ADMIN';
    const recognized = await get('/reports/tag-estimate/filters');
    expect(recognized.statusCode).toBe(200);

    const unknown = await get('/reports/not-a-report/filters');
    expect(unknown.statusCode).toBe(403);
    expect(unknown.json()).toEqual({
      error: 'forbidden',
      form: 'unresolved',
      action: 'read',
    });
    expect(harness.unexpectedQueries).toEqual([]);
  });
});
