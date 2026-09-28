import { describe, expect, it, vi } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';

const rendererReady = async () => ({
  available: true as const,
  engine: 'playwright-chromium' as const,
});

describe('production application security options', () => {
  it('sets Secure on access and refresh cookies in production mode', async () => {
    const password = 'Local-Test-Password-1';
    const passwordHash = await hashPassword(password);
    const user = {
      CO_CODE: '01',
      LOGIN_NAME: 'admin',
      LOGIN_PWD: passwordHash,
      LOGIN_CATG: 'ADMIN',
      USER_UPDATE: 'Y',
      USER_DELETE: 'Y',
      USER_PRINT: 'Y',
      PASSWORD_RESET_REQUIRED: 'N',
    };
    const tx = {
      $executeRawUnsafe: vi.fn().mockResolvedValue(1),
      $queryRawUnsafe: vi.fn(async (sql: string) => {
        if (sql.includes('FROM "CO_MAST"'))
          return [{ CO_CODE: '01', CO_NAME: 'Test', LC_CODE: '01', allowed: true }];
        if (sql.includes('FROM "LOCT_MAST"')) return [{ LC_CODE: '01', LC_NAME: 'Main' }];
        if (sql.includes('FROM "YEAR_MAST"')) return [{ year: '2024' }];
        if (sql.includes('FROM "LOGIN_MAST"')) return [user];
        return [];
      }),
    };
    const prisma = {
      $transaction: (fn: (value: typeof tx) => unknown) => fn(tx),
    };
    const app = await buildApp({
      prisma,
      secret: 'test-random-signing-key-with-more-than-thirty-two-characters',
      secureCookies: true,
      rendererProbe: rendererReady,
      defaultTenantId: 'tenant-a',
      allowTenantHeader: false,
    });

    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': 'attacker-tenant' },
      payload: {
        coCode: '01',
        loginName: 'admin',
        password,
      },
    });

    expect(response.statusCode).toBe(200);
    const setCookie = response.headers['set-cookie'];
    const cookies = Array.isArray(setCookie) ? setCookie : [setCookie ?? ''];
    expect(cookies).toHaveLength(2);
    for (const value of cookies) {
      expect(value).toContain('HttpOnly');
      expect(value).toContain('SameSite=Strict');
      expect(value).toContain('Secure');
      expect(value).toContain('Path=/');
    }

    expect(tx.$executeRawUnsafe).toHaveBeenCalledWith(
      "SELECT set_config('app.tenant_id', $1, true)",
      'tenant-a',
    );

    await app.close();
  });
});
