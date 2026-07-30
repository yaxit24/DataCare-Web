import { describe, expect, it, vi } from 'vitest';
import {
  authorizeForm,
  canonicalAllowedForms,
  FormForbiddenError,
  type Principal,
} from '../src/modules/rbac/authorization.js';

const user: Principal = {
  loginName: 'USER1',
  loginCoCode: '01',
  role: 'USER',
  isAdmin: false,
  rights: { userUpdate: false, userDelete: false, userPrint: false },
  passwordResetRequired: false,
};
const admin: Principal = {
  ...user,
  loginName: 'ABC',
  role: 'ADMIN',
  isAdmin: true,
  rights: { userUpdate: true, userDelete: true, userPrint: true },
};

function db(rows: unknown[]) {
  const tx = {
    $executeRawUnsafe: vi.fn().mockResolvedValue(1),
    $queryRawUnsafe: vi.fn().mockResolvedValue(rows),
  };
  return { prisma: { $transaction: (fn: (arg: typeof tx) => unknown) => fn(tx) }, tx };
}

describe('per-form authorization', () => {
  it('fails closed for a non-admin with no USER_SET row', async () => {
    const { prisma } = db([]);
    await expect(
      authorizeForm(prisma, {
        tenantId: 't1',
        lcCode: '02',
        principal: user,
        form: 'Sales/Sales Invoice',
        action: 'read',
      }),
    ).rejects.toBeInstanceOf(FormForbiddenError);
  });

  it('allows only an explicit administrator to bootstrap without USER_SET rows', async () => {
    const { prisma, tx } = db([]);
    await expect(
      authorizeForm(prisma, {
        tenantId: 't1',
        lcCode: '02',
        principal: admin,
        form: 'Utilities/Users & Rights',
        action: 'update',
        adminOnly: true,
      }),
    ).resolves.toMatchObject({ form: 'Utilities/Users & Rights', action: 'update' });
    expect(tx.$queryRawUnsafe).not.toHaveBeenCalled();
  });

  it('uses View for new entry but requires Edit for modification, as desktop does', async () => {
    const { prisma, tx } = db([{ FRM_VIEW: 'Y', FRM_EDIT: 'N', FRM_DELETE: 'N', FRM_PRINT: 'Y' }]);
    await expect(
      authorizeForm(prisma, {
        tenantId: 't1',
        lcCode: '02',
        principal: user,
        form: 'Sales/Sales Invoice',
        action: 'create',
      }),
    ).resolves.toBeDefined();
    await expect(
      authorizeForm(prisma, {
        tenantId: 't1',
        lcCode: '02',
        principal: user,
        form: 'Sales/Sales Invoice',
        action: 'update',
      }),
    ).rejects.toBeInstanceOf(FormForbiddenError);
    const authCall = tx.$queryRawUnsafe.mock.calls.find((call) =>
      String(call[0]).includes('FROM "USER_SET"'),
    );
    expect(authCall?.[1]).toBe('02');
    expect(authCall?.[2]).toBe('USER1');
    expect(authCall).toContain('SALES'); // desktop alias for canonical Sales Invoice
  });

  it('requires admin role independently of a permissive row on admin-only routes', async () => {
    const { prisma } = db([{ FRM_VIEW: 'Y', FRM_EDIT: 'Y', FRM_DELETE: 'Y', FRM_PRINT: 'Y' }]);
    await expect(
      authorizeForm(prisma, {
        tenantId: 't1',
        lcCode: '01',
        principal: user,
        form: 'Utilities/Users & Rights',
        action: 'read',
        adminOnly: true,
      }),
    ).rejects.toBeInstanceOf(FormForbiddenError);
  });

  it('canonicalizes desktop SUB_MENU aliases for navigation', () => {
    expect(canonicalAllowedForms([{ subMenu: 'Sales', view: true }])).toContain(
      'Sales/Sales Invoice',
    );
    expect(canonicalAllowedForms([{ subMenu: 'Sales', view: false }])).toEqual([]);
  });
});
