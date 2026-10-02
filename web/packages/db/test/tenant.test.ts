import { describe, expect, it, vi } from 'vitest';
import type { PrismaClient } from '@prisma/client';
import { withTenant } from '../src/tenant.js';

/** A Prisma double that records what withTenant asks of the transaction and of the client. */
function fakePrisma() {
  const statements: Array<{ sql: string; params: unknown[] }> = [];
  const tx = {
    $executeRawUnsafe: vi.fn(async (sql: string, ...params: unknown[]) => {
      statements.push({ sql, params });
      return 1;
    }),
  };
  const $transaction = vi.fn(
    async (fn: (value: typeof tx) => Promise<unknown>, _options?: unknown) => fn(tx),
  );
  return { prisma: { $transaction } as unknown as PrismaClient, $transaction, statements };
}

describe('withTenant', () => {
  it('binds only the tenant and passes no options when none are given (unchanged behaviour)', async () => {
    const { prisma, $transaction, statements } = fakePrisma();
    expect(await withTenant(prisma, 'tenant-a', async () => 'done')).toBe('done');
    expect(statements).toEqual([
      { sql: "SELECT set_config('app.tenant_id', $1, true)", params: ['tenant-a'] },
    ]);
    expect($transaction.mock.calls[0]?.[1]).toBeUndefined();
  });

  it('binds a transaction-local statement_timeout in the same statement as the tenant', async () => {
    const { prisma, $transaction, statements } = fakePrisma();
    await withTenant(prisma, 'tenant-a', async () => undefined, {
      timeout: 20_000,
      maxWait: 5_000,
      statementTimeoutMs: 20_000,
      isolationLevel: 'Serializable',
    });
    // One round trip: both settings are transaction-local (third argument true).
    expect(statements).toEqual([
      {
        sql: "SELECT set_config('app.tenant_id', $1, true), set_config('statement_timeout', $2, true)",
        params: ['tenant-a', '20000'],
      },
    ]);
    // statementTimeoutMs is ours, not Prisma's: it is not passed on.
    expect($transaction.mock.calls[0]?.[1]).toEqual({
      timeout: 20_000,
      maxWait: 5_000,
      isolationLevel: 'Serializable',
    });
  });

  it('refuses a statement timeout that is not a positive whole number, before starting a transaction', async () => {
    for (const bad of [0, -1, 1.5, Number.NaN, Number.POSITIVE_INFINITY]) {
      const { prisma, $transaction } = fakePrisma();
      await expect(
        withTenant(prisma, 'tenant-a', async () => undefined, { statementTimeoutMs: bad }),
        String(bad),
      ).rejects.toThrow(RangeError);
      expect($transaction).not.toHaveBeenCalled();
    }
  });
});
