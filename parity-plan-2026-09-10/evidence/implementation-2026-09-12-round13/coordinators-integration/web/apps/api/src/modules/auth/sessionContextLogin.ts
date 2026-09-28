import { createHash, randomBytes, randomUUID } from 'node:crypto';
import { withTenant } from '@datacare/db';
import { authenticate, AuthError, type AuthInput, type LoginMastRow } from './auth.service.js';
import { resolveLoginScopeTx } from './businessScope.js';
import { hashPassword } from './password.js';
import { loadPrincipalTx, type Principal } from '../rbac/authorization.js';
import { parseContextEpoch, SESSION_LEDGER_CONTEXT_VERSION } from './sessionContextValue.js';
import type { RefreshedSessionContext, RefreshContextDependencies } from './sessionContextRefresh.js';

interface CredentialObservation extends LoginMastRow {
  rowId: string;
  passwordChangedAt: string | null;
}

interface LoginContextDependencies {
  issueTokens: RefreshContextDependencies['issueTokens'];
  clock?: () => Date;
  newSessionId?: () => string;
  newRefreshJti?: () => string;
}

const credentialSql = `SELECT "row_id"::text AS "rowId","CO_CODE","LOGIN_NAME","LOGIN_PWD",
  "LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED",
  "PASSWORD_CHANGED_AT"::text AS "passwordChangedAt"
  FROM "LOGIN_MAST" WHERE "tenant_id"=$1 AND "CO_CODE"=$2 AND "LOGIN_NAME"=$3
  ORDER BY "row_id" LIMIT 2`;

/**
 * Internal login coordinator; HTTP integration follows coherent access-epoch rollout.
 * Password verification/hash work happens before the lock. The private verified credential
 * observation is checked under its row lock before any new session can be committed.
 * LOGIN_MAST is locked before auth_session, matching password reset/change order.
 */
export async function loginSessionContext(
  prisma: Parameters<typeof withTenant>[0],
  input: AuthInput & { coYear?: string },
  dependencies: LoginContextDependencies,
): Promise<{ session: RefreshedSessionContext; principal: Principal; accessToken: string; refreshToken: string }> {
  const request = {
    tenantId: input.tenantId, coCode: input.coCode, loginName: input.loginName,
    password: input.password, lcCode: input.lcCode, coYear: input.coYear,
  };
  if ([request.tenantId, request.coCode, request.loginName, request.password]
    .some((value) => typeof value !== 'string' || !value)) {
    throw new AuthError('invalid-credentials');
  }
  let observed: CredentialObservation | undefined;
  const authenticated = await authenticate({
    loadUser: async (tenantId, coCode, loginName) => withTenant(prisma, tenantId, async (tx) => {
      const rows = await tx.$queryRawUnsafe<CredentialObservation[]>(credentialSql, tenantId, coCode, loginName);
      // Explicit web admission: duplicate credential identities never select an arbitrary owner.
      if (rows.length !== 1 || !rows[0]?.LOGIN_PWD) return null;
      observed = { ...rows[0] };
      return observed;
    }),
    audit: async () => {},
  }, request);
  const proof = observed;
  if (!proof) throw new AuthError('invalid-credentials');
  const upgradedHash = authenticated.legacyPassword ? await hashPassword(request.password) : null;
  const sessionId = dependencies.newSessionId?.() ?? randomUUID();
  const refreshJti = dependencies.newRefreshJti?.() ?? randomBytes(32).toString('base64url');
  if (!/^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/.test(sessionId) ||
      typeof refreshJti !== 'string' || !refreshJti) throw new Error('invalid-session-nonce');
  const epoch = parseContextEpoch('1');
  if (epoch.status !== 'ready') throw new Error('invalid-initial-context');

  return withTenant(prisma, request.tenantId, async (tx) => {
    const locked = await tx.$queryRawUnsafe<CredentialObservation[]>(
      `${credentialSql} FOR UPDATE`, request.tenantId, request.coCode, request.loginName,
    );
    const current = locked[0];
    if (locked.length !== 1 || !current || current.rowId !== proof.rowId ||
        current.LOGIN_PWD !== proof.LOGIN_PWD ||
        current.passwordChangedAt !== proof.passwordChangedAt ||
        current.PASSWORD_RESET_REQUIRED !== proof.PASSWORD_RESET_REQUIRED) {
      throw new AuthError('invalid-credentials');
    }
    if (upgradedHash !== null) {
      const changed = await tx.$executeRawUnsafe(
        `UPDATE "LOGIN_MAST" SET "LOGIN_PWD"=$1,"PASSWORD_RESET_REQUIRED"='Y',
          "PASSWORD_CHANGED_AT"=clock_timestamp()
         WHERE "tenant_id"=$2 AND "row_id"=$3::bigint AND "LOGIN_PWD"=$4`,
        upgradedHash, request.tenantId, proof.rowId, proof.LOGIN_PWD,
      );
      if (changed !== 1) throw new AuthError('invalid-credentials');
    }
    const scope = await resolveLoginScopeTx(tx, {
      tenantId: request.tenantId, coCode: authenticated.coCode,
      lcCode: request.lcCode, coYear: request.coYear,
    });
    const currentPrincipal = await loadPrincipalTx(tx, {
      tenantId: request.tenantId, loginName: authenticated.userId,
      coCode: scope.coCode, loginCoCode: authenticated.coCode,
    });
    const principal = Object.freeze({ ...currentPrincipal, rights: Object.freeze({ ...currentPrincipal.rights }) });
    const ledgerContext = Object.freeze({
      version: SESSION_LEDGER_CONTEXT_VERSION, status: 'unknown' as const, mode: null,
      reason: scope.coYear ? 'vendor-authority-unresolved' as const : 'scope-incomplete' as const,
    });
    const supplied = dependencies.clock?.();
    if (supplied !== undefined && (!(supplied instanceof Date) || !Number.isFinite(supplied.getTime()))) {
      throw new Error('invalid-server-clock');
    }
    const inserted = await tx.$queryRawUnsafe<Array<{ expiresAt: string }>>(
      `WITH instant AS MATERIALIZED (SELECT COALESCE($1::timestamptz,clock_timestamp()) AS value)
       INSERT INTO "auth_session" (
         "tenant_id","session_id","login_name","login_co_code","co_code","lc_code","co_year",
         "refresh_jti_hash","created_at","last_used_at","expires_at","context_epoch","ledger_context"
       ) SELECT $2,$3,$4,$5,$6,$7,$8,$9,value,value,value+interval '168 hours',1,$10::jsonb FROM instant
       RETURNING "expires_at"::text AS "expiresAt"`,
      supplied?.toISOString() ?? null, request.tenantId, sessionId, authenticated.userId,
      authenticated.coCode, scope.coCode, scope.lcCode, scope.coYear ?? null,
      createHash('sha256').update(refreshJti).digest('hex'), JSON.stringify(ledgerContext),
    );
    const saved = inserted[0];
    if (inserted.length !== 1 || !saved?.expiresAt) throw new Error('session-insert-failure');
    const session: RefreshedSessionContext = Object.freeze({
      tenantId: request.tenantId, sessionId, loginName: authenticated.userId,
      loginCoCode: authenticated.coCode, coCode: scope.coCode, lcCode: scope.lcCode,
      coYear: scope.coYear, contextEpoch: epoch.value, ledgerContext, expiresAt: saved.expiresAt,
      lastContextSelectionId: null, lastContextRequestSha256: null, lastContextFromEpoch: null,
    });
    const tokens = await dependencies.issueTokens({ session, principal, refreshJti });
    if (!tokens || typeof tokens.accessToken !== 'string' || !tokens.accessToken ||
        typeof tokens.refreshToken !== 'string' || !tokens.refreshToken) throw new Error('invalid-issued-tokens');
    const issued = { accessToken: tokens.accessToken, refreshToken: tokens.refreshToken };
    const finalClock = dependencies.clock?.();
    if (finalClock !== undefined && (!(finalClock instanceof Date) || !Number.isFinite(finalClock.getTime()))) {
      throw new Error('invalid-server-clock');
    }
    const currentSession = await tx.$queryRawUnsafe<Array<{ active: boolean }>>(
      `SELECT "expires_at">COALESCE($1::timestamptz,clock_timestamp()) AND "revoked_at" IS NULL AS active
       FROM "auth_session" WHERE "tenant_id"=$2 AND "session_id"=$3`,
      finalClock?.toISOString() ?? null, request.tenantId, sessionId,
    );
    if (currentSession.length !== 1 || currentSession[0]?.active !== true) throw new Error('session-expired');
    return { session, principal, ...issued };
  }, { isolationLevel: 'ReadCommitted' });
}
