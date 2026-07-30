import { describe, it, expect, vi } from 'vitest';
import { authenticate, AuthError, rightsOf } from '../src/modules/auth/auth.service.js';
import { hashPassword } from '../src/modules/auth/password.js';

function deps(user: any) {
  return { loadUser: vi.fn().mockResolvedValue(user), audit: vi.fn().mockResolvedValue(undefined) };
}

describe('authenticate', () => {
  it('succeeds with hashed pwd and audits success', async () => {
    const h = await hashPassword('pw');
    const d = deps({ CO_CODE: '01', LOGIN_NAME: 'admin', LOGIN_PWD: h, LOGIN_CATG: 'ADMIN' });
    const s = await authenticate(d, {
      tenantId: 't1',
      coCode: '01',
      loginName: 'admin',
      password: 'pw',
    });
    expect(s.userId).toBe('admin');
    expect(s.rights.userDelete).toBe(true); // admin category
    expect(s.forcedReset).toBe(false);
    expect(d.audit).toHaveBeenCalledWith(expect.objectContaining({ success: true }));
  });

  it('rejects bad password and audits reason', async () => {
    const h = await hashPassword('pw');
    const d = deps({ CO_CODE: '01', LOGIN_NAME: 'admin', LOGIN_PWD: h });
    await expect(
      authenticate(d, { tenantId: 't1', coCode: '01', loginName: 'admin', password: 'no' }),
    ).rejects.toBeInstanceOf(AuthError);
    expect(d.audit).toHaveBeenCalledWith(
      expect.objectContaining({ success: false, reason: 'bad-password' }),
    );
  });

  it('rejects unknown user', async () => {
    const d = deps(null);
    await expect(
      authenticate(d, { tenantId: 't1', coCode: '01', loginName: 'ghost', password: 'x' }),
    ).rejects.toBeInstanceOf(AuthError);
    expect(d.audit).toHaveBeenCalledWith(expect.objectContaining({ reason: 'unknown-user' }));
  });

  it('flags forcedReset for plaintext legacy login', async () => {
    const d = deps({ CO_CODE: '01', LOGIN_NAME: 'old', LOGIN_PWD: 'legacy' });
    const s = await authenticate(d, {
      tenantId: 't1',
      coCode: '01',
      loginName: 'old',
      password: 'legacy',
    });
    expect(s.forcedReset).toBe(true);
  });

  it('rightsOf: admin category grants all rights', () => {
    expect(rightsOf({ CO_CODE: '01', LOGIN_NAME: 'a', LOGIN_PWD: 'x', LOGIN_CATG: 'A' })).toEqual({
      userUpdate: true,
      userDelete: true,
      userPrint: true,
    });
  });
});
