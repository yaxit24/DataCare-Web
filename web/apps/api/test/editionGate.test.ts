import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it, vi } from 'vitest';
import { buildApp } from '../src/app.js';
import { issueAccess } from '../src/modules/auth/jwt.js';
import { editionDescriptor, editionRefusal } from '../src/modules/rbac/editionGate.js';
import { FORM_CATALOG, formKey, getFormCatalog } from '../src/modules/rbac/formCatalog.js';
import { formTier } from '@datacare/core';

/**
 * N171: the API edition gate. A route whose rights form belongs to a higher desktop edition is refused with
 * `403 edition-unavailable` before any rights or scope check (MDI_FORM.cs:11249-11322 shows a menu only in its edition
 * and above). Without a configured edition nothing changes; with Beta the higher editions pass to the normal checks.
 */
const SECRET = 'edition-gate-test-secret-with-more-than-thirty-two-characters';
const TENANT = 'edition-gate';

function fakePrisma() {
  const tx = {
    $executeRawUnsafe: vi.fn(async () => 1),
    $queryRawUnsafe: vi.fn(async (sqlValue: unknown) => {
      const sql = String(sqlValue);
      if (sql.includes('FROM "auth_session"'))
        return [
          {
            tenantId: TENANT,
            sessionId: 'sid',
            loginName: 'CLERK',
            loginCoCode: '01',
            coCode: '01',
            lcCode: '01',
            coYear: '2026-2027',
            contextEpoch: '1',
            revoked: false,
            unexpired: true,
            ledgerContext: {
              version: 'server-session-ledger-context-v1',
              status: 'unknown',
              mode: null,
              reason: 'vendor-authority-unresolved',
            },
            refreshJtiHash: '0'.repeat(64),
            expiresAt: new Date(Date.now() + 60_000),
            revokedAt: null,
            revokeReason: null,
          },
        ];
      if (sql.includes('FROM "LOGIN_MAST"'))
        return [
          {
            CO_CODE: '01',
            LOGIN_NAME: 'CLERK',
            LOGIN_PWD: 'unused',
            LOGIN_CATG: 'USER',
            USER_UPDATE: 'N',
            USER_DELETE: 'N',
            USER_PRINT: 'N',
            PASSWORD_RESET_REQUIRED: 'N',
          },
        ];
      // No USER_SET rights: a request that passes the edition gate stops at the rights check (403 forbidden).
      return [];
    }),
  };
  return { $transaction: vi.fn((fn: (t: typeof tx) => unknown) => fn(tx)) };
}

async function appWith(edition: { code: 'L' | 'S' | 'E'; beta: boolean } | undefined) {
  return buildApp({
    prisma: fakePrisma(),
    secret: SECRET,
    secureCookies: false,
    defaultTenantId: TENANT,
    allowTenantHeader: false,
    edition,
  });
}

describe('edition gate over HTTP', () => {
  let access = '';
  const apps: Record<string, FastifyInstance> = {};
  const get = (name: string, url: string) =>
    apps[name]!.inject({ method: 'GET', url, headers: { cookie: `access=${access}` } });
  const post = (name: string, url: string) =>
    apps[name]!.inject({
      method: 'POST',
      url,
      headers: { cookie: `access=${access}` },
      payload: {},
    });

  beforeAll(async () => {
    access = await issueAccess(
      {
        sub: 'CLERK',
        tenantId: TENANT,
        loginCoCode: '01',
        coCode: '01',
        lcCode: '01',
        coYear: '2026-2027',
        sid: 'sid',
        contextEpoch: '1',
        rights: { userUpdate: false, userDelete: false, userPrint: false },
      },
      SECRET,
    );
    // Building with an edition is itself the coverage proof: every route's static rights form must be classified,
    // or buildApp throws edition-table-missing-form at boot.
    apps.lite = await appWith({ code: 'L', beta: false });
    apps.standard = await appWith({ code: 'S', beta: false });
    apps.beta = await appWith({ code: 'S', beta: true });
    apps.ungated = await appWith(undefined);
  });
  afterAll(async () => {
    for (const app of Object.values(apps)) await app.close();
  });

  it('refuses a Pro, Advance or Enterprise route in Standard with 403 edition-unavailable', async () => {
    const cases: Array<[string, () => Promise<{ statusCode: number; json(): any }>, string]> = [
      ['POST /dhrn/issue', () => post('standard', '/dhrn/issue'), 'Loans (Dhrn)/Pledge Issue'],
      ['POST /stock/in', () => post('standard', '/stock/in'), 'Transaction/Stock In'],
      [
        'GET /masters/diamonds (@master)',
        () => get('standard', '/masters/diamonds'),
        'Masters/Diamonds',
      ],
      [
        'GET /reports/dhiran-report (@report)',
        () => get('standard', '/reports/dhiran-report'),
        'Reports/Dhiran Report',
      ],
    ];
    for (const [label, send, form] of cases) {
      const response = await send();
      expect(response.statusCode, label).toBe(403);
      expect(response.json(), label).toEqual({ error: 'edition-unavailable', form, edition: 'S' });
    }
  });

  it('passes a Standard route on to the rights check (forbidden for a user without rights, not edition)', async () => {
    for (const url of ['/masters/items', '/reports/sales-register']) {
      const response = await get('standard', url);
      expect(response.statusCode, url).toBe(403);
      expect(response.json().error, url).toBe('forbidden');
    }
  });

  it('with Beta on, and without a configured edition, a deferred route reaches the rights check', async () => {
    for (const name of ['beta', 'ungated']) {
      const response = await post(name, '/dhrn/issue');
      expect(response.statusCode, name).toBe(403);
      expect(response.json().error, name).toBe('forbidden');
    }
  });

  it('refuses a Basic route in Lite (the default edition, D33) and passes a Lite route on to the rights check', async () => {
    const refused = await get('lite', '/reports/rojmel');
    expect(refused.statusCode).toBe(403);
    expect(refused.json()).toEqual({
      error: 'edition-unavailable',
      form: 'Reports/Rojmel',
      edition: 'L',
    });
    const save = await post('lite', '/settings');
    expect(save.statusCode).toBe(403);
    expect(save.json()).toEqual({
      error: 'edition-unavailable',
      form: 'Utilities/Settings',
      edition: 'L',
    });
    const lite = await get('lite', '/masters/items');
    expect(lite.statusCode).toBe(403);
    expect(lite.json().error).toBe('forbidden');
  });

  it('never refuses the configuration reads every edition needs (MS_OPNCOMP loads CO_SET in every edition)', async () => {
    for (const url of ['/settings', '/integrations/device-settings']) {
      const response = await get('lite', url);
      expect(response.json().error, url).not.toBe('edition-unavailable');
    }
  });

  it('answers 401 before the edition check for an unauthenticated request', async () => {
    const response = await apps.standard!.inject({
      method: 'POST',
      url: '/dhrn/issue',
      payload: {},
    });
    expect(response.statusCode).toBe(401);
  });
});

describe('edition gate helpers', () => {
  it('editionRefusal is null without a policy and for available forms', () => {
    expect(editionRefusal('Loans (Dhrn)/Pledge Issue', null)).toBeNull();
    expect(editionRefusal('Sales/Sales Invoice', { code: 'S', beta: false })).toBeNull();
    expect(editionRefusal('Loans (Dhrn)/Pledge Issue', { code: 'P', beta: false })).toBeNull();
    expect(editionRefusal('Loans (Dhrn)/Pledge Issue', { code: 'S', beta: false })).toEqual({
      error: 'edition-unavailable',
      form: 'Loans (Dhrn)/Pledge Issue',
      edition: 'S',
    });
  });
  it('editionDescriptor names the edition for /me', () => {
    expect(editionDescriptor({ code: 'S', beta: false })).toEqual({
      code: 'S',
      name: 'Standard',
      beta: false,
    });
    expect(editionDescriptor(undefined)).toBeNull();
  });
  it('every rights-catalog form has an edition, and the rights editor lists only Standard forms in Standard', () => {
    const missing = FORM_CATALOG.map((e) => formKey(e.mainMenu, e.subMenu)).filter(
      (form) => formTier(form) === undefined,
    );
    expect(missing).toEqual([]);
    const all = getFormCatalog().map((e) => formKey(e.mainMenu, e.subMenu));
    const standard = getFormCatalog({ code: 'S', beta: false }).map((e) =>
      formKey(e.mainMenu, e.subMenu),
    );
    const beta = getFormCatalog({ code: 'S', beta: true }).map((e) =>
      formKey(e.mainMenu, e.subMenu),
    );
    expect(standard).toContain('Sales/Sales Invoice');
    expect(standard).not.toContain('Loans (Dhrn)/Pledge Issue');
    expect(standard.length).toBeLessThan(all.length);
    expect(beta).toEqual(all);
  });
});
