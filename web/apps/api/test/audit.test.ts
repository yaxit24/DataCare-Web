import { describe, expect, it, vi } from 'vitest';
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
      "SELECT set_config('app.tenant_id', $1, true)",
      'tenant-a',
    );
    const insert = tx.$executeRawUnsafe.mock.calls[1];
    expect(insert[0]).toContain('INSERT INTO "audit_log"');
    expect(insert[4]).toHaveLength(255);
    expect(insert[5]).toBe(201);
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
