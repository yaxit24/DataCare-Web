import Fastify, { type FastifyInstance } from 'fastify';
import { afterEach, describe, expect, it, vi } from 'vitest';

/**
 * D36: in the Lite edition the rights grid is hidden and every right is seeded Y (MS_USER.cs:1489-1495), so the API
 * refuses the four rights routes there with the edition gate's `403 edition-unavailable`. The other User Create routes
 * (create, delete, ...) keep working. The modules that write are mocked: a refusal must reach none of them.
 */
const mocks = vi.hoisted(() => ({
  setUserRights: vi.fn(async () => ({ saved: true })),
  listUsers: vi.fn(async () => []),
  getFormCatalog: vi.fn(() => []),
  getUserFormRights: vi.fn(async () => []),
  setUserFormRights: vi.fn(async () => ({ saved: true })),
  createDesktopUser: vi.fn(async () => ({ loginName: 'NEWUSER' })),
  deactivateDesktopUser: vi.fn(async () => ({ deleted: true })),
  updateDesktopUser: vi.fn(async () => ({ updated: true })),
}));

vi.mock('../src/modules/rbac/users.js', () => ({
  listUsers: mocks.listUsers,
  setUserRights: mocks.setUserRights,
}));
vi.mock('../src/modules/rbac/formCatalog.js', () => ({ getFormCatalog: mocks.getFormCatalog }));
vi.mock('../src/modules/rbac/formRights.js', () => ({
  getUserFormRights: mocks.getUserFormRights,
  setUserFormRights: mocks.setUserFormRights,
}));
vi.mock('../src/modules/rbac/userMaster.js', () => ({
  createDesktopUser: mocks.createDesktopUser,
  deactivateDesktopUser: mocks.deactivateDesktopUser,
  updateDesktopUser: mocks.updateDesktopUser,
  UserMasterNotFoundError: class UserMasterNotFoundError extends Error {},
  UserMasterValidationError: class UserMasterValidationError extends Error {},
}));

const { registerUserMasterRoutes } = await import('../src/routes/userMaster.js');

async function appWith(code: 'L' | 'S' | null): Promise<FastifyInstance> {
  const app = Fastify();
  app.decorate('editionPolicy', code ? { code, beta: false } : null);
  app.addHook('onRequest', async (req) => {
    (req as any).session = {
      tenantId: 't',
      sub: 'ADMIN',
      sid: 's',
      coCode: '01',
      lcCode: '01',
      loginCoCode: '01',
    };
  });
  registerUserMasterRoutes(app, {
    prisma: {},
    auth: {},
    guard: () => true,
    run: async (reply, okCode, fn) => reply.code(okCode).send((await fn()) as any),
    body: (req) => ((req.body as Record<string, any>) ?? {}) as Record<string, any>,
  });
  await app.ready();
  return app;
}

const RIGHTS_ROUTES: Array<[string, 'GET' | 'POST', string]> = [
  ['rights', 'POST', '/admin/users/CLERK/rights'],
  ['form-catalog', 'GET', '/admin/form-catalog'],
  ['form-rights read', 'GET', '/admin/users/CLERK/form-rights'],
  ['form-rights write', 'POST', '/admin/users/CLERK/form-rights'],
];

describe('User Create rights routes by edition (D36)', () => {
  const apps: FastifyInstance[] = [];
  afterEach(async () => {
    for (const app of apps.splice(0)) await app.close();
    vi.clearAllMocks();
  });

  it('refuses each of the four rights routes in Lite and writes nothing', async () => {
    const app = await appWith('L');
    apps.push(app);
    for (const [label, method, url] of RIGHTS_ROUTES) {
      const response = await app.inject({
        method,
        url,
        payload: method === 'POST' ? {} : undefined,
      });
      expect(response.statusCode, label).toBe(403);
      expect(response.json(), label).toEqual({
        error: 'edition-unavailable',
        form: 'Utilities/Users & Rights',
        edition: 'L',
      });
    }
    expect(mocks.setUserRights).not.toHaveBeenCalled();
    expect(mocks.getFormCatalog).not.toHaveBeenCalled();
    expect(mocks.getUserFormRights).not.toHaveBeenCalled();
    expect(mocks.setUserFormRights).not.toHaveBeenCalled();
  });

  it('still serves the four rights routes in Standard', async () => {
    const app = await appWith('S');
    apps.push(app);
    for (const [label, method, url] of RIGHTS_ROUTES) {
      const response = await app.inject({
        method,
        url,
        payload: method === 'POST' ? {} : undefined,
      });
      expect(response.statusCode, label).toBe(200);
    }
    expect(mocks.setUserRights).toHaveBeenCalledOnce();
    expect(mocks.getFormCatalog).toHaveBeenCalledOnce();
    expect(mocks.getUserFormRights).toHaveBeenCalledOnce();
    expect(mocks.setUserFormRights).toHaveBeenCalledOnce();
  });

  it('still serves rights routes when no edition is configured', async () => {
    const app = await appWith(null);
    apps.push(app);
    const response = await app.inject({ method: 'GET', url: '/admin/form-catalog' });
    expect(response.statusCode).toBe(200);
  });

  it('still lists, creates and deletes users in Lite', async () => {
    const app = await appWith('L');
    apps.push(app);
    expect((await app.inject({ method: 'GET', url: '/admin/users' })).statusCode).toBe(200);
    const created = await app.inject({
      method: 'POST',
      url: '/admin/users',
      payload: { loginName: 'NEWUSER', password: 'x', confirmPassword: 'x', userType: 'USER' },
    });
    expect(created.statusCode).toBe(201);
    const deleted = await app.inject({ method: 'DELETE', url: '/admin/users/NEWUSER' });
    expect(deleted.statusCode).toBe(200);
    expect(mocks.createDesktopUser).toHaveBeenCalledOnce();
    expect(mocks.deactivateDesktopUser).toHaveBeenCalledOnce();
  });
});
