import { describe, expect, it, vi } from 'vitest';
import {
  BUDGETED_BIND_SQL,
  VOUCHER_BUDGET,
  budgetedBindParams,
} from './support/txBudgetBinding.js';
import { logAudit } from '../src/modules/ops/audit.js';

const prismaWith = (execute: () => Promise<unknown>) => {
  const tx = {
    $executeRawUnsafe: vi.fn(execute),
  };
  return {
    tx,
    prisma: {
      $transaction: (fn: (value: typeof tx) => unknown) => fn(tx),
    },
  };
};

describe('audit persistence', () => {
  it('binds the tenant and reports a successful bounded write', async () => {
    const { prisma, tx } = prismaWith(async () => 1);
    const result = await logAudit(prisma, 'tenant-a', {
      loginName: 'operator',
      coCode: '01',
      action: 'POST',
      path: `/${'x'.repeat(300)}`,
      status: 201,
    });

    expect(result).toEqual({ logged: true });
    expect(tx.$executeRawUnsafe).toHaveBeenNthCalledWith(
      1,
      BUDGETED_BIND_SQL,
      ...budgetedBindParams('tenant-a', VOUCHER_BUDGET),
    );
    // The mock's call tuple is typed `[]`, so indexing it is a type error even though the call really does
    // carry six arguments. Cast at the boundary rather than at each index.
    const insert = tx.$executeRawUnsafe.mock.calls[1] as unknown as unknown[];
    expect(insert![0]).toContain('INSERT INTO "audit_log"');
    expect(insert![4]).toHaveLength(255);
    expect(insert![5]).toBe(201);
  });

  it('returns an observable failure code without masking the completed request', async () => {
    const prisma = {
      $transaction: vi.fn().mockRejectedValue(new Error('audit table unavailable')),
    };
    await expect(
      logAudit(prisma, 'tenant-a', {
        action: 'DELETE',
        path: '/sales/1',
        status: 204,
      }),
    ).resolves.toEqual({ logged: false, error: 'audit-write-failed' });
  });
});
