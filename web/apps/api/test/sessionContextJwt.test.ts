import { describe, expect, it } from 'vitest';
import { SignJWT, type JWTPayload } from 'jose';
import {
  issueAccess,
  issueRefresh,
  verifyAccessToken,
  verifyRefreshToken,
  type AccessInput,
} from '../src/modules/auth/jwt.js';

// Disposable test signing material only, never a production or registration value.
const secret = 'session-context-jwt-tests-only-local-signing-material';
const key = new TextEncoder().encode(secret);
const validClaims = () => ({
  sub: 'operator',
  tenantId: 'context-jwt-test',
  loginCoCode: '01',
  coCode: '02',
  lcCode: '03',
  coYear: '2024-2025',
  sid: '11111111-1111-4111-8111-111111111111',
  contextEpoch: '9',
  rights: { userUpdate: false, userDelete: false, userPrint: true },
  passwordResetRequired: false,
});
async function rawAccess(
  patch: Record<string, unknown> = {},
  options: {
    missingEpoch?: boolean;
    issuer?: string;
    audience?: string;
    algorithm?: string;
    expires?: number;
  } = {},
) {
  const payload: JWTPayload = { ...validClaims(), typ: 'access', ...patch };
  if (options.missingEpoch) delete payload.contextEpoch;
  return new SignJWT(payload)
    .setProtectedHeader({ alg: options.algorithm ?? 'HS256', typ: 'JWT' })
    .setIssuer(options.issuer ?? 'datacare-api')
    .setAudience(options.audience ?? 'datacare-web')
    .setIssuedAt()
    .setExpirationTime(options.expires ?? '15m')
    .sign(key);
}

const invalidEpochs: Array<{ label: string; value: unknown }> = [
  { label: 'numeric one', value: 1 },
  { label: 'numeric zero', value: 0 },
  { label: 'numeric beyond safe integer', value: 9007199254740992 },
  { label: 'null', value: null },
  { label: 'undefined', value: undefined },
  { label: 'boolean', value: true },
  { label: 'array', value: ['1'] },
  { label: 'object', value: { epoch: '1' } },
  { label: 'empty', value: '' },
  { label: 'zero', value: '0' },
  { label: 'negative', value: '-1' },
  { label: 'negative zero', value: '-0' },
  { label: 'plus prefix', value: '+1' },
  { label: 'leading zero', value: '01' },
  { label: 'all zeros', value: '000' },
  { label: 'decimal', value: '1.0' },
  { label: 'exponent', value: '1e3' },
  { label: 'leading space', value: ' 1' },
  { label: 'trailing space', value: '1 ' },
  { label: 'terminal newline', value: '1\n' },
  { label: 'embedded nul', value: '1\u0000' },
  { label: 'nonbreaking space', value: '\u00a01' },
  { label: 'non ASCII digit', value: '\u0661' },
  { label: 'NaN text', value: 'NaN' },
  { label: 'Infinity text', value: 'Infinity' },
  { label: 'BIGINT overflow', value: '9223372036854775808' },
  { label: 'too many digits', value: '1000000000000000000000000000000' },
];

describe('real signed session epoch JWT boundary', () => {
  it.each(['1', '9', '9007199254740993', '9223372036854775806', '9223372036854775807'])(
    'roundtrips exact canonical epoch %s as a string',
    async (contextEpoch) => {
      const token = await issueAccess({ ...validClaims(), contextEpoch }, secret);
      const claims = await verifyAccessToken(token, secret);
      expect(claims.contextEpoch).toBe(contextEpoch);
      expect(typeof claims.contextEpoch).toBe('string');
      expect(claims.loginCoCode).toBe('01');
      expect(claims.coCode).toBe('02');
    },
  );
  it('rejects old access lacking epoch, with no implicit epoch1', async () => {
    const token = await rawAccess({}, { missingEpoch: true });
    await expect(verifyAccessToken(token, secret)).rejects.toThrow(
      'invalid-token-claim:contextEpoch',
    );
    const old: Record<string, unknown> = { ...validClaims() };
    delete old.contextEpoch;
    await expect(issueAccess(old as AccessInput, secret)).rejects.toThrow(
      'invalid-token-claim:contextEpoch',
    );
  });
  it.each(invalidEpochs)('rejects real signed malformed epoch: $label', async ({ value }) => {
    const token = await rawAccess({ contextEpoch: value });
    await expect(verifyAccessToken(token, secret)).rejects.toThrow(
      'invalid-token-claim:contextEpoch',
    );
  });
  it.each(invalidEpochs)('refuses issuance of malformed epoch: $label', async ({ value }) => {
    await expect(
      issueAccess({ ...validClaims(), contextEpoch: value } as AccessInput, secret),
    ).rejects.toThrow('invalid-token-claim:contextEpoch');
  });
  it('refresh remains session/JTI authority without an epoch requirement; it is not accepted as access', async () => {
    const token = await issueRefresh(
      {
        sub: 'operator',
        tenantId: 'context-jwt-test',
        sid: validClaims().sid,
        jti: 'test-refresh-jti',
      },
      secret,
    );
    const claims = await verifyRefreshToken(token, secret);
    expect(claims).toMatchObject({
      sub: 'operator',
      sid: validClaims().sid,
      jti: 'test-refresh-jti',
    });
    expect(Object.hasOwn(claims, 'contextEpoch')).toBe(false);
    await expect(verifyAccessToken(token, secret)).rejects.toThrow('wrong-token-type');
    const access = await issueAccess(validClaims(), secret);
    await expect(verifyRefreshToken(access, secret)).rejects.toThrow('wrong-token-type');
  });
  it('accepts an incomplete login without inventing a year or changing its epoch', async () => {
    const token = await issueAccess(
      { ...validClaims(), coYear: undefined, contextEpoch: '1' },
      secret,
    );
    const claims = await verifyAccessToken(token, secret);
    expect(claims.contextEpoch).toBe('1');
    expect(Object.hasOwn(claims, 'coYear')).toBe(false);
  });
  it('does not weaken signature, algorithm, issuer, audience or expiration validation', async () => {
    for (const options of [
      { issuer: 'different-issuer' },
      { audience: 'different-audience' },
      { algorithm: 'HS384' },
    ]) {
      await expect(verifyAccessToken(await rawAccess({}, options), secret)).rejects.toThrow();
    }
    await expect(
      verifyAccessToken(await rawAccess({}, { expires: 1 }), secret),
    ).rejects.toMatchObject({ code: 'ERR_JWT_EXPIRED' });
    const token = await rawAccess();
    const parts = token.split('.');
    const signature = parts[2]!;
    parts[2] = (signature[0] === 'a' ? 'b' : 'a') + signature.slice(1);
    await expect(verifyAccessToken(parts.join('.'), secret)).rejects.toThrow();
    await expect(verifyAccessToken(token, secret + '-wrong')).rejects.toThrow();
  });
});
