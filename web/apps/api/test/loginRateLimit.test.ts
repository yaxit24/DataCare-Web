import type { FastifyInstance } from 'fastify';
import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import { buildApp } from '../src/app.js';

const SECRET = 'login-rate-limit-test-secret-with-more-than-thirty-two-characters';

function fakePrisma() {
  const tx = {
    $executeRawUnsafe: vi.fn(async () => 1),
    $queryRawUnsafe: vi.fn(async () => []),
  };
  return { $transaction: vi.fn((fn: (t: typeof tx) => unknown) => fn(tx)) };
}

// WP-51.f04.tests §3 defines this web security contract, not a desktop business rule.
describe('login rate limit client isolation', () => {
  let app: FastifyInstance;

  beforeEach(async () => {
    app = await buildApp({
      prisma: fakePrisma(),
      secret: SECRET,
      secureCookies: false,
      defaultTenantId: 'login-rate-limit',
      allowTenantHeader: false,
    });
  });

  afterEach(async () => {
    await app.close();
  });

  const login = (loginName: string, forwardedFor: string, remoteAddress = '127.0.0.1') =>
    app.inject({
      method: 'POST',
      url: '/auth/login',
      remoteAddress,
      headers: { 'x-forwarded-for': forwardedFor },
      payload: { coCode: '01', loginName, password: 'incorrect-test-password' },
    });

  async function exhaustClient() {
    for (let attempt = 1; attempt <= 10; attempt++) {
      const response = await login('a', '10.0.0.1');
      expect(response.statusCode, `attempt ${attempt} is within the limit`).not.toBe(429);
    }
    const response = await login('a', '10.0.0.1');
    // WP-51.f04.tests §3 case 1: the eleventh attempt is limited.
    expect(response.statusCode).toBe(429);
  }

  it('F04-1 limits the eleventh failed login from one client through the trusted proxy', async () => {
    await exhaustClient();
  });

  it('F04-2 does not lock out another login from another client through the same proxy', async () => {
    await exhaustClient();
    const response = await login('b', '10.0.0.2');
    // WP-51.f04.tests §3 case 2: another client and login retain their own allowance.
    expect(response.statusCode).not.toBe(429);
  });

  it('F04-3 does not lock out the same login from another client through the same proxy', async () => {
    await exhaustClient();
    const response = await login('a', '10.0.0.3');
    // WP-51.f04.tests §3 case 3: another client retains its allowance for login a.
    expect(response.statusCode).not.toBe(429);
  });

  it('F04-4 ignores rotating forged forwarded addresses from an untrusted peer', async () => {
    for (let attempt = 1; attempt <= 10; attempt++) {
      const response = await login('a', `10.0.0.${attempt}`, '203.0.113.9');
      expect(response.statusCode, `attempt ${attempt} is within the limit`).not.toBe(429);
    }
    const response = await login('a', '10.0.0.11', '203.0.113.9');
    // WP-51.f04.tests §3 case 4: untrusted forwarding headers cannot bypass the limit.
    expect(response.statusCode).toBe(429);
  });
});
