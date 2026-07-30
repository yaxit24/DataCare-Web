import { SignJWT, jwtVerify, type JWTPayload } from 'jose';
import type { UserRights } from '@datacare/types';

const enc = (secret: string) => new TextEncoder().encode(secret);
const ISSUER = 'datacare-api';
const AUDIENCE = 'datacare-web';

export interface SessionClaims extends JWTPayload {
  sub: string;
  tenantId: string;
  /** Company against which credentials were verified. */
  loginCoCode: string;
  /** Current, server-validated business context. */
  coCode: string;
  lcCode: string;
  coYear?: string;
  sid: string;
  rights: UserRights;
  passwordResetRequired?: boolean;
  typ: 'access';
}

export interface RefreshClaims extends JWTPayload {
  sub: string;
  tenantId: string;
  sid: string;
  jti: string;
  typ: 'refresh';
}

export type AccessInput = Omit<SessionClaims, 'iat' | 'exp' | 'iss' | 'aud' | 'typ'>;
export type RefreshInput = Pick<RefreshClaims, 'sub' | 'tenantId' | 'sid' | 'jti'>;

export async function issueAccess(
  claims: AccessInput,
  secret: string,
  ttl: string = '15m',
): Promise<string> {
  return new SignJWT({ ...claims, typ: 'access' })
    .setProtectedHeader({ alg: 'HS256', typ: 'JWT' })
    .setIssuer(ISSUER)
    .setAudience(AUDIENCE)
    .setIssuedAt()
    .setExpirationTime(ttl)
    .sign(enc(secret));
}

export async function issueRefresh(
  claims: RefreshInput,
  secret: string,
  ttl: string = '7d',
): Promise<string> {
  return new SignJWT({ tenantId: claims.tenantId, sid: claims.sid, typ: 'refresh' })
    .setProtectedHeader({ alg: 'HS256', typ: 'JWT' })
    .setIssuer(ISSUER)
    .setAudience(AUDIENCE)
    .setSubject(claims.sub)
    .setJti(claims.jti)
    .setIssuedAt()
    .setExpirationTime(ttl)
    .sign(enc(secret));
}

export async function verifyToken(token: string, secret: string): Promise<JWTPayload> {
  const { payload } = await jwtVerify(token, enc(secret), {
    algorithms: ['HS256'],
    issuer: ISSUER,
    audience: AUDIENCE,
  });
  return payload;
}

const requiredString = (payload: JWTPayload, key: string): string => {
  const value = payload[key];
  if (typeof value !== 'string' || !value) throw new Error(`invalid-token-claim:${key}`);
  return value;
};

export async function verifyAccessToken(token: string, secret: string): Promise<SessionClaims> {
  const payload = await verifyToken(token, secret);
  if (payload.typ !== 'access') throw new Error('wrong-token-type');
  const claims: SessionClaims = {
    ...payload,
    typ: 'access',
    sub: requiredString(payload, 'sub'),
    tenantId: requiredString(payload, 'tenantId'),
    loginCoCode: requiredString(payload, 'loginCoCode'),
    coCode: requiredString(payload, 'coCode'),
    lcCode: requiredString(payload, 'lcCode'),
    sid: requiredString(payload, 'sid'),
    rights: payload.rights as UserRights,
  };
  if (!claims.rights || typeof claims.rights !== 'object')
    throw new Error('invalid-token-claim:rights');
  return claims;
}

export async function verifyRefreshToken(token: string, secret: string): Promise<RefreshClaims> {
  const payload = await verifyToken(token, secret);
  if (payload.typ !== 'refresh') throw new Error('wrong-token-type');
  return {
    ...payload,
    typ: 'refresh',
    sub: requiredString(payload, 'sub'),
    tenantId: requiredString(payload, 'tenantId'),
    sid: requiredString(payload, 'sid'),
    jti: requiredString(payload, 'jti'),
  };
}
