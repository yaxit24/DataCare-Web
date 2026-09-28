import { describe, it, expect } from 'vitest';
import { SignJWT } from 'jose';
import {
  issueAccess,
  issueRefresh,
  verifyAccessToken,
  verifyRefreshToken,
  verifyToken,
} from '../src/modules/auth/jwt.js';

const SECRET = 'test-secret-please-change';
const rights = { userUpdate: true, userDelete: false, userPrint: true };
const accessClaims = {
  sub: 'admin',
  tenantId: 't1',
  loginCoCode: '01',
  coCode: '01',
  lcCode: '01',
  coYear: '2024',
  sid: 'session-1',
  rights,
};

describe('jwt', () => {
  it('issues and verifies a session-bound access token', async () => {
    const token = await issueAccess(accessClaims, SECRET);
    const payload = await verifyAccessToken(token, SECRET);
    expect(payload.sub).toBe('admin');
    expect(payload.tenantId).toBe('t1');
    expect(payload.sid).toBe('session-1');
    expect(payload.lcCode).toBe('01');
    expect(payload.rights.userPrint).toBe(true);
  });

  it('rejects a token signed with a different secret', async () => {
    const token = await issueAccess(accessClaims, SECRET);
    await expect(verifyToken(token, 'other-secret')).rejects.toThrow();
  });

  it('rejects an expired token', async () => {
    const enc = new TextEncoder().encode(SECRET);
    const past = Math.floor(Date.now() / 1000) - 10;
    const token = await new SignJWT({ tenantId: 't1' })
      .setProtectedHeader({ alg: 'HS256' })
      .setSubject('a')
      .setExpirationTime(past)
      .sign(enc);
    await expect(verifyToken(token, SECRET)).rejects.toThrow();
  });

  it('issues a refresh token with session and rotation identifiers', async () => {
    const token = await issueRefresh(
      { sub: 'admin', tenantId: 't1', sid: 'session-1', jti: 'refresh-jti-1' },
      SECRET,
    );
    const payload = await verifyRefreshToken(token, SECRET);
    expect(payload.sub).toBe('admin');
    expect(payload.sid).toBe('session-1');
    expect(payload.jti).toBe('refresh-jti-1');
  });

  it('does not accept a refresh token as access or an access token as refresh', async () => {
    const access = await issueAccess(accessClaims, SECRET);
    const refresh = await issueRefresh(
      { sub: 'admin', tenantId: 't1', sid: 'session-1', jti: 'refresh-jti-1' },
      SECRET,
    );
    await expect(verifyAccessToken(refresh, SECRET)).rejects.toThrow('wrong-token-type');
    await expect(verifyRefreshToken(access, SECRET)).rejects.toThrow('wrong-token-type');
  });
});
