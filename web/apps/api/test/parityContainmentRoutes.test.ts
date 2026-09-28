import Fastify from 'fastify';
import { describe, expect, it, vi } from 'vitest';
import { registerTxnRoutes } from '../src/routes/txn.js';

const containedRoutes = [
  ['POST', '/backup/restore', 'logical-restore'],
  ['POST', '/stock/tag-transfer', 'tag-transfer'],
  ['DELETE', '/stock/tag-transfer/00001', 'tag-transfer'],
  ['POST', '/stock/tag-cancel', 'tag-cancel'],
  ['DELETE', '/stock/tag-cancel/00001', 'tag-cancel'],
  ['POST', '/stock/tag-weight-diff', 'tag-weight-difference'],
  ['DELETE', '/stock/tag-weight-diff/00001', 'tag-weight-difference'],
  ['POST', '/stock/tag-split', 'tag-split'],
  ['DELETE', '/stock/tag-split/00001', 'tag-split'],
] as const;

async function containmentApp({
  authorized = true,
  authenticated = true,
}: { authorized?: boolean; authenticated?: boolean } = {}) {
  const prismaAccess = vi.fn();
  const prisma = new Proxy(
    {},
    {
      get(_target, property) {
        prismaAccess(String(property));
        throw new Error(`Prisma must not be touched by a contained route (${String(property)})`);
      },
    },
  );
  const app = Fastify({ logger: false });
  const routeAuthorized = vi.fn(() => authorized);
  registerTxnRoutes(app, {
    prisma,
    requireAuth: async (_req, reply) => {
      if (!authenticated) void reply.code(401).send({ error: 'unauthorized' });
    },
    sess: () => ({
      tenantId: 'tenant-test',
      sub: 'operator',
      coCode: '01',
      lcCode: '01',
      coYear: '2025',
      loginCoCode: '01',
      rights: {},
    }),
    scopeOfRequest: () => ({
      tenantId: 'tenant-test',
      coCode: '01',
      lcCode: '01',
      coYear: '2025',
    }),
    routeAuthorized,
    metrics: { recordPeriodLockRejection: vi.fn() } as never,
  });
  await app.ready();
  return { app, prismaAccess, routeAuthorized };
}

describe('WP-01 contained transaction routes', () => {
  it('returns the shared 503 problem for every unsafe mutation before database access', async () => {
    const { app, prismaAccess } = await containmentApp();
    try {
      for (const [method, url, operation] of containedRoutes) {
        const response = await app.inject({ method, url, payload: {} });
        expect(response.statusCode, `${method} ${url}`).toBe(503);
        expect(response.json(), `${method} ${url}`).toMatchObject({
          error: 'parity-containment',
          code: 'PARITY_CONTAINMENT',
          operation,
          workPackage: 'WP-01',
          retryable: false,
        });
      }
      expect(prismaAccess).not.toHaveBeenCalled();
    } finally {
      await app.close();
    }
  });

  it('keeps authentication ahead of RBAC and containment', async () => {
    const { app, prismaAccess, routeAuthorized } = await containmentApp({ authenticated: false });
    try {
      const response = await app.inject({
        method: 'POST',
        url: '/stock/tag-split',
        payload: {},
      });
      expect(response.statusCode).toBe(401);
      expect(response.json()).toEqual({ error: 'unauthorized' });
      expect(routeAuthorized).not.toHaveBeenCalled();
      expect(prismaAccess).not.toHaveBeenCalled();
    } finally {
      await app.close();
    }
  });

  it('keeps authorization ahead of containment so unauthorized users receive 403', async () => {
    const { app, prismaAccess } = await containmentApp({ authorized: false });
    try {
      const response = await app.inject({
        method: 'POST',
        url: '/stock/tag-split',
        payload: {},
      });
      expect(response.statusCode).toBe(403);
      expect(response.json()).toEqual({ error: 'forbidden', action: 'create' });
      expect(prismaAccess).not.toHaveBeenCalled();
    } finally {
      await app.close();
    }
  });
});
