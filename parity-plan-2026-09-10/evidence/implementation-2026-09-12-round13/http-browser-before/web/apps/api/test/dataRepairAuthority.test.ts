import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it, vi } from 'vitest';
import { buildApp } from '../src/app.js';
import { issueAccess } from '../src/modules/auth/jwt.js';
import { rightNamesForForm } from '../src/modules/rbac/formCatalog.js';
import { routePolicyFor } from '../src/modules/rbac/routePolicy.js';

/**
 * P0-03 — Data Repair authority.
 *
 * The defect this closes was not a missing check but a MISLEADING one. The handlers carried
 * `guard(req, reply, 'delete')  // admin-gate`, yet `guard` only asserts that the central hook authorized the
 * request; the routes were absent from `ADMIN_ONLY`, and a POST classified as `create` needs only `FRM_VIEW`.
 * A delegate holding View on `Utilities/Data Repair` could therefore preview AND apply repairs that rewrite
 * historical ledger, stock and serial rows — while the code claimed to be admin-only.
 *
 * The policy is now: the whole console is admin-only, business scope is still validated (a repair rewrites
 * one company's data, so the requested company/location/year must match the session), preview is classified
 * `read` and apply `delete`. These tests hold the policy and the code to the same wording.
 *
 * No repair runs here: the fixture throws if a handler reaches the database beyond authentication, which is
 * how "denied requests never touch business data" is proved rather than asserted.
 */

const SECRET = 'data-repair-authority-test-secret-with-more-than-thirty-two-chars';
const TENANT_ID = 'repair-authority';
const LOGIN_NAME = 'REPAIR_USER';
const COMPANY = '01';
const LOCATION = '01';
const YEAR = '2024-2025';
const SESSION_ID = 'repair-authority-session';

const CONSOLE_ROUTES = [
  { method: 'GET', path: '/utilities/data-repair/operations', action: 'read' },
  { method: 'POST', path: '/utilities/data-repair/:id/preview', action: 'read' },
  { method: 'POST', path: '/utilities/data-repair/:id/apply', action: 'delete' },
  { method: 'GET', path: '/utilities/data-repair/runs', action: 'read' },
] as const;

describe('data repair route policy', () => {
  it('classifies the whole console as admin-only, business-scoped, on the Data Repair form', () => {
    for (const { method, path, action } of CONSOLE_ROUTES) {
      expect(routePolicyFor(method, path), `${method} ${path}`).toEqual({
        kind: 'form',
        form: 'Utilities/Data Repair',
        action,
        adminOnly: true,
        businessScope: true,
      });
    }
  });

  it('keeps preview a read and apply a delete, so a delegated grant could never apply on View alone', () => {
    expect(routePolicyFor('POST', '/utilities/data-repair/:id/preview')?.action).toBe('read');
    expect(routePolicyFor('POST', '/utilities/data-repair/:id/apply')?.action).toBe('delete');
  });

  it('does not drop business scope for admin-only maintenance the way scope-free admin routes do', () => {
    // A user list belongs to no company; a data repair belongs to exactly one. The distinction has to survive
    // in the registry, or an administrator's request could name a company the session never selected.
    expect(routePolicyFor('GET', '/admin/users')).toMatchObject({
      adminOnly: true,
      businessScope: false,
    });
    expect(routePolicyFor('POST', '/utilities/data-repair/:id/apply')).toMatchObject({
      adminOnly: true,
      businessScope: true,
    });
  });
});

type Role = 'USER' | 'ADMIN';

function harness() {
  const state = { role: 'USER' as Role, view: false, edit: false, del: false, print: false };
  const businessQueries: string[] = [];

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
            USER_UPDATE: 'Y',
            USER_DELETE: 'Y',
            USER_PRINT: 'Y',
            PASSWORD_RESET_REQUIRED: 'N',
          },
        ];
      }
      if (sql.includes('FROM "USER_SET"')) {
        const requested = new Set(params.slice(2).map((v) => String(v).toUpperCase()));
        const ownsForm = rightNamesForForm('Utilities/Data Repair').some((name) =>
          requested.has(name.toUpperCase()),
        );
        return ownsForm
          ? [
              {
                FRM_VIEW: state.view ? 'Y' : 'N',
                FRM_EDIT: state.edit ? 'Y' : 'N',
                FRM_DELETE: state.del ? 'Y' : 'N',
                FRM_PRINT: state.print ? 'Y' : 'N',
              },
            ]
          : [];
      }
      // Anything else means a handler got past authorization and started working.
      businessQueries.push(sql);
      return [];
    }),
  };
  const prisma = { $transaction: vi.fn((fn: (t: typeof tx) => unknown) => fn(tx)) };
  return { state, prisma, businessQueries };
}

describe('data repair console authority', () => {
  let app: FastifyInstance;
  let access: string;
  const h = harness();

  const call = (method: 'GET' | 'POST', url: string, payload?: unknown) =>
    app.inject({
      method,
      url,
      headers: { cookie: `access=${access}` },
      ...(payload === undefined ? {} : { payload: payload as object }),
    });

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
        rights: { userUpdate: true, userDelete: true, userPrint: true },
      },
      SECRET,
    );
    app = await buildApp({
      prisma: h.prisma,
      secret: SECRET,
      secureCookies: false,
      defaultTenantId: TENANT_ID,
      allowTenantHeader: false,
    });
  });

  afterAll(async () => {
    if (app) await app.close();
  });

  it('refuses every console route to an unauthenticated caller', async () => {
    const anonymous = await app.inject({
      method: 'POST',
      url: '/utilities/data-repair/karigar-fine/apply',
      payload: {},
    });
    expect(anonymous.statusCode).toBe(401);
    expect(anonymous.json()).toEqual({ error: 'unauthenticated' });
  });

  it('refuses a delegate holding every Data Repair right, because the console is admin-only', async () => {
    // This is the escalation the previous policy allowed: View alone reached apply, since a POST classified
    // `create` needs only View. Now even a full View+Edit+Delete+Print delegation is refused.
    for (const rights of [
      { view: true, edit: false, del: false, print: false },
      { view: true, edit: true, del: true, print: true },
    ]) {
      Object.assign(h.state, { role: 'USER' as Role, ...rights });
      for (const { method, path } of CONSOLE_ROUTES) {
        const url = path.replace(':id', 'karigar-fine');
        const response = await call(method, url, method === 'POST' ? {} : undefined);
        expect(response.statusCode, `${method} ${url} with ${JSON.stringify(rights)}`).toBe(403);
        expect(response.json()).toMatchObject({
          error: 'forbidden',
          form: 'Utilities/Data Repair',
        });
      }
    }
    expect(h.businessQueries, 'a refused request must not query business data').toEqual([]);
  });

  it('lets an administrator in and still enforces the destructive-apply requirements', async () => {
    Object.assign(h.state, { role: 'ADMIN' as Role, view: false, edit: false, del: false });

    const operations = await call('GET', '/utilities/data-repair/operations');
    expect(operations.statusCode).toBe(200);
    expect(Array.isArray(operations.json().operations)).toBe(true);

    // `opening-balance` is high risk. An administrator supplying nothing must still be refused, and the
    // refusal must name the requirement rather than failing anonymously.
    const noConfirmation = await call('POST', '/utilities/data-repair/opening-balance/apply', {
      previewHash: '0'.repeat(64),
    });
    expect(noConfirmation.statusCode).toBe(400);
    expect(noConfirmation.json()).toMatchObject({
      error: 'RepairError',
      code: 'confirmation-required',
    });

    const noReason = await call('POST', '/utilities/data-repair/opening-balance/apply', {
      previewHash: '0'.repeat(64),
      confirmation: `opening-balance ${COMPANY}`,
    });
    expect(noReason.statusCode).toBe(400);
    expect(noReason.json()).toMatchObject({ error: 'RepairError', code: 'reason-required' });

    // A missing re-authentication is an authorization outcome, so it must not read as a bad payload.
    const noPassword = await call('POST', '/utilities/data-repair/opening-balance/apply', {
      previewHash: '0'.repeat(64),
      confirmation: `opening-balance ${COMPANY}`,
      reason: 'rebuild opening balances after migration',
    });
    expect(noPassword.statusCode).toBe(403);
    expect(noPassword.json()).toMatchObject({
      error: 'RepairError',
      code: 'reauthentication-required',
    });

    expect(
      h.businessQueries,
      'no repair may touch business data before its requirements are met',
    ).toEqual([]);
  });

  it('refuses an unknown operation id without disclosing anything else', async () => {
    Object.assign(h.state, { role: 'ADMIN' as Role });
    const response = await call('POST', '/utilities/data-repair/not-an-operation/apply', {
      previewHash: '0'.repeat(64),
    });
    expect(response.statusCode).toBe(400);
    expect(response.json()).toMatchObject({ error: 'RepairError', code: 'unknown-operation' });
  });
});
