import { describe, expect, it, vi } from 'vitest';
import { BUDGETED_BIND_SQL, READ_BUDGET, budgetedBindParams } from './support/txBudgetBinding.js';
import { buildApp } from '../src/app.js';
import { healthPayload, readiness } from '../src/modules/ops/health.js';

const rendererReady = async () => ({
  available: true as const,
  engine: 'playwright-chromium' as const,
});

const prismaWith = (...queryResults: unknown[]) => {
  const tx = {
    $executeRawUnsafe: vi.fn().mockResolvedValue(1),
    $queryRawUnsafe: vi.fn(),
  };
  for (const result of queryResults) tx.$queryRawUnsafe.mockResolvedValueOnce(result);
  return {
    tx,
    prisma: { $transaction: (fn: (value: typeof tx) => unknown) => fn(tx) },
  };
};

describe('ops health', () => {
  it('healthPayload is ok with computed uptime', () => {
    const payload = healthPayload(10_000, 4_000, '1.2.3');
    expect(payload.status).toBe('ok');
    expect(payload.service).toBe('datacare-api');
    expect(payload.version).toBe('1.2.3');
    expect(payload.uptimeSec).toBe(6);
    expect(typeof payload.ts).toBe('string');
  });

  it('uptime is zero when no start time is supplied', () => {
    expect(healthPayload(10_000, 0).uptimeSec).toBe(0);
  });

  it('is ready only for a non-bypass role with FORCE RLS on every tenant table', async () => {
    const { prisma, tx } = prismaWith(
      [{ ok: 1 }],
      [{ name: 'app_user', rolsuper: false, rolbypassrls: false }],
      [{ tenant_tables: 167, protected_tables: 167 }],
    );
    const result = await readiness(prisma, 'tenant-a', rendererReady);
    expect(result).toEqual({
      ready: true,
      db: 'up',
      role: {
        name: 'app_user',
        superuser: false,
        bypassRls: false,
        safe: true,
      },
      rls: { tenantTables: 167, protectedTables: 167, safe: true },
      renderer: { available: true, engine: 'playwright-chromium' },
    });
    expect(tx.$executeRawUnsafe).toHaveBeenCalledWith(
      BUDGETED_BIND_SQL,
      ...budgetedBindParams('tenant-a', READ_BUDGET),
    );
  });

  it('rejects superuser and incomplete FORCE RLS coverage', async () => {
    const { prisma } = prismaWith(
      [{ ok: 1 }],
      [{ name: 'postgres', rolsuper: true, rolbypassrls: true }],
      [{ tenant_tables: 167, protected_tables: 162 }],
    );
    const result = await readiness(prisma, 'readiness', rendererReady);
    expect(result.ready).toBe(false);
    expect(result.db).toBe('up');
    expect(result.role.safe).toBe(false);
    expect(result.rls.safe).toBe(false);
  });

  it('rejects an unavailable mandatory PDF renderer', async () => {
    const { prisma } = prismaWith(
      [{ ok: 1 }],
      [{ name: 'app_user', rolsuper: false, rolbypassrls: false }],
      [{ tenant_tables: 167, protected_tables: 167 }],
    );
    const result = await readiness(prisma, 'readiness', async () => ({
      available: false,
      engine: 'playwright-chromium',
      error: 'chromium-unavailable',
    }));
    expect(result.ready).toBe(false);
    expect(result.renderer).toEqual({
      available: false,
      engine: 'playwright-chromium',
      error: 'chromium-unavailable',
    });
  });

  it('returns a non-ready payload instead of throwing on database failure', async () => {
    const prisma = {
      $transaction: vi.fn().mockRejectedValue(new Error('database unavailable')),
    };
    const result = await readiness(prisma, 'readiness', rendererReady);
    expect(result.ready).toBe(false);
    expect(result.db).toBe('down');
    expect(result.error).toBe('database-readiness-check-failed');
  });
});

describe('GET /ready', () => {
  it('returns HTTP 503 when the runtime database is not security-ready', async () => {
    const { prisma } = prismaWith(
      [{ ok: 1 }],
      [{ name: 'postgres', rolsuper: true, rolbypassrls: false }],
      [{ tenant_tables: 167, protected_tables: 167 }],
    );
    const app = await buildApp({
      prisma,
      secret: 'test-secret',
      rendererProbe: rendererReady,
    });
    const response = await app.inject({ method: 'GET', url: '/ready' });
    expect(response.statusCode).toBe(503);
    expect(response.json()).toMatchObject({
      ready: false,
      db: 'up',
      role: { name: 'postgres', safe: false },
    });
    await app.close();
  });
});
