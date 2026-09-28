import { createHash, randomBytes, timingSafeEqual } from 'node:crypto';
import { withTenant, type Tx } from '@datacare/db';
import { loadPrincipalTx, type Principal } from '../rbac/authorization.js';
import { validateStoredScopeTx } from './businessScope.js';
import type { RefreshClaims } from './jwt.js';
import { SessionRejectedError } from './session.js';
import {
  parseContextEpoch,
  parseContextSelectionId,
  parseUnknownSessionLedgerContext,
  type ContextEpoch,
  type UnknownSessionLedgerContext,
} from './sessionContextValue.js';

/** Private server descriptor. Dates stay text so authority never loses PostgreSQL microseconds. */
export interface RefreshedSessionContext {
  readonly tenantId: string;
  readonly sessionId: string;
  readonly loginName: string;
  readonly loginCoCode: string;
  readonly coCode: string;
  readonly lcCode: string;
  readonly coYear: string | undefined;
  readonly contextEpoch: ContextEpoch;
  readonly ledgerContext: UnknownSessionLedgerContext;
  readonly expiresAt: string;
  readonly lastContextSelectionId: string | null;
  readonly lastContextRequestSha256: string | null;
  readonly lastContextFromEpoch: ContextEpoch | null;
}

interface RefreshSessionRow {
  tenantId: string;
  sessionId: string;
  loginName: string;
  loginCoCode: string;
  coCode: string;
  lcCode: string;
  coYear: string | null;
  contextEpoch: unknown;
  ledgerContext: unknown;
  expiresAt: string;
  revokedAt: string | null;
  refreshJtiHash: string;
  lastContextSelectionId: unknown;
  lastContextRequestSha256: unknown;
  lastContextFromEpoch: unknown;
}

export class RefreshContextError extends Error {
  constructor(public readonly code: string) {
    super(code);
    this.name = 'RefreshContextError';
  }
}

export interface RefreshContextDependencies {
  /** Local signing only. Do not publish cookies or make external calls before transaction commit. */
  issueTokens(input: {
    session: RefreshedSessionContext;
    principal: Principal;
    refreshJti: string;
  }): Promise<{ accessToken: string; refreshToken: string }>;
  /** Trusted server/test seams, never supplied by a request body. Default clock is PostgreSQL. */
  clock?: () => Date;
  newRefreshJti?: () => string;
}

const hashJti = (value: string): string => createHash('sha256').update(value).digest('hex');
const hashEquals = (stored: string, presented: string): boolean =>
  /^[0-9a-f]{64}$/.test(stored) &&
  timingSafeEqual(Buffer.from(stored, 'hex'), Buffer.from(hashJti(presented), 'hex'));

function projectContext(row: RefreshSessionRow): RefreshedSessionContext {
  const epoch = parseContextEpoch(row.contextEpoch);
  if (epoch.status !== 'ready') throw new RefreshContextError(epoch.code);
  const ledger = parseUnknownSessionLedgerContext(row.ledgerContext);
  if (ledger.status !== 'ready') throw new RefreshContextError(ledger.code);
  const receipt = [row.lastContextSelectionId, row.lastContextRequestSha256, row.lastContextFromEpoch];
  let fromEpoch: ContextEpoch | null = null;
  if (!receipt.every((value) => value === null)) {
    const id = parseContextSelectionId(row.lastContextSelectionId);
    const from = parseContextEpoch(row.lastContextFromEpoch);
    if (
      id.status !== 'ready' || from.status !== 'ready' ||
      typeof row.lastContextRequestSha256 !== 'string' ||
      !/^[0-9a-f]{64}$/.test(row.lastContextRequestSha256) ||
      BigInt(from.value) >= BigInt(epoch.value)
    ) throw new RefreshContextError('invalid-context-receipt');
    fromEpoch = from.value;
  }
  return Object.freeze({
    tenantId: row.tenantId,
    sessionId: row.sessionId,
    loginName: row.loginName,
    loginCoCode: row.loginCoCode,
    coCode: row.coCode,
    lcCode: row.lcCode,
    coYear: row.coYear ?? undefined,
    contextEpoch: epoch.value,
    ledgerContext: ledger.value,
    expiresAt: row.expiresAt,
    lastContextSelectionId: row.lastContextSelectionId as string | null,
    lastContextRequestSha256: row.lastContextRequestSha256 as string | null,
    lastContextFromEpoch: fromEpoch,
  });
}

async function sampleTimeTx(tx: Tx, expiresAt: string, clock?: () => Date) {
  const supplied = clock?.();
  if (supplied !== undefined && (!(supplied instanceof Date) || !Number.isFinite(supplied.getTime()))) {
    throw new RefreshContextError('invalid-server-clock');
  }
  const rows = await tx.$queryRawUnsafe<Array<{ now: string; expired: boolean }>>(
    `WITH instant AS MATERIALIZED (
       SELECT COALESCE($1::timestamptz,clock_timestamp()) AS value
     ) SELECT value::text AS "now",$2::timestamptz<=value AS "expired" FROM instant`,
    supplied?.toISOString() ?? null,
    expiresAt,
  );
  const result = rows[0];
  if (!result || typeof result.now !== 'string' || typeof result.expired !== 'boolean') {
    throw new RefreshContextError('invalid-server-clock');
  }
  return result;
}

/**
 * Internal atomic refresh. This is not wired to HTTP until access epochs and the complete
 * context lifecycle are integrated together. READ COMMITTED deliberately lets a waiting second
 * old-JTI request observe the winner and commit the established strict reuse revocation.
 */
export async function refreshSessionContext(
  prisma: Parameters<typeof withTenant>[0],
  claims: RefreshClaims,
  dependencies: RefreshContextDependencies,
): Promise<{
  session: RefreshedSessionContext;
  principal: Principal;
  accessToken: string;
  refreshToken: string;
}> {
  // Detach verified identity before awaiting; no scope/epoch/rights claims are refresh authority.
  const identity = { tenantId: claims.tenantId, sid: claims.sid, sub: claims.sub, jti: claims.jti };
  if (Object.values(identity).some((value) => typeof value !== 'string' || value.length === 0)) {
    throw new SessionRejectedError('session-invalid');
  }
  const outcome = await withTenant(prisma, identity.tenantId, async (tx) => {
    const rows = await tx.$queryRawUnsafe<RefreshSessionRow[]>(
      `SELECT "tenant_id" AS "tenantId","session_id" AS "sessionId",
              "login_name" AS "loginName","login_co_code" AS "loginCoCode",
              "co_code" AS "coCode","lc_code" AS "lcCode","co_year" AS "coYear",
              "context_epoch"::text AS "contextEpoch","ledger_context" AS "ledgerContext",
              "expires_at"::text AS "expiresAt","revoked_at"::text AS "revokedAt",
              "refresh_jti_hash" AS "refreshJtiHash",
              "last_context_selection_id" AS "lastContextSelectionId",
              "last_context_request_sha256" AS "lastContextRequestSha256",
              "last_context_from_epoch"::text AS "lastContextFromEpoch"
         FROM "auth_session" WHERE "tenant_id"=$1 AND "session_id"=$2 FOR UPDATE`,
      identity.tenantId, identity.sid,
    );
    const row = rows[0];
    if (!row || row.tenantId !== identity.tenantId || row.sessionId !== identity.sid || row.loginName !== identity.sub) {
      return { status: 'rejected' as const, code: 'session-invalid' as const };
    }
    if (row.revokedAt !== null) return { status: 'rejected' as const, code: 'session-revoked' as const };
    const time = await sampleTimeTx(tx, row.expiresAt, dependencies.clock);
    const rejection = time.expired ? 'session-expired' : !hashEquals(row.refreshJtiHash, identity.jti) ? 'refresh-reused' : null;
    if (rejection) {
      const changed = await tx.$executeRawUnsafe(
        `UPDATE "auth_session" SET "revoked_at"=$1::timestamptz,"revoke_reason"=$2
          WHERE "tenant_id"=$3 AND "session_id"=$4 AND "revoked_at" IS NULL`,
        time.now, rejection === 'session-expired' ? 'expired' : 'refresh-reuse', identity.tenantId, identity.sid,
      );
      if (changed !== 1) throw new RefreshContextError('mutation-count-failure');
      // Throwing here would roll back the required reuse/expiry revocation.
      return { status: 'rejected' as const, code: rejection };
    }
    const session = projectContext(row);
    const currentPrincipal = await loadPrincipalTx(tx, {
      tenantId: session.tenantId, loginName: session.loginName,
      coCode: session.coCode, loginCoCode: session.loginCoCode,
    });
    const principal = Object.freeze({ ...currentPrincipal, rights: Object.freeze({ ...currentPrincipal.rights }) });
    await validateStoredScopeTx(tx, {
      tenantId: session.tenantId, loginName: session.loginName, isAdmin: principal.isAdmin,
      coCode: session.coCode, lcCode: session.lcCode, coYear: session.coYear,
    });
    const refreshJti = dependencies.newRefreshJti?.() ?? randomBytes(32).toString('base64url');
    if (typeof refreshJti !== 'string' || !refreshJti || hashEquals(row.refreshJtiHash, refreshJti)) {
      throw new RefreshContextError('invalid-next-refresh-jti');
    }
    const tokens = await dependencies.issueTokens({ session, principal, refreshJti });
    if (!tokens || typeof tokens.accessToken !== 'string' || !tokens.accessToken ||
        typeof tokens.refreshToken !== 'string' || !tokens.refreshToken) {
      throw new RefreshContextError('invalid-issued-tokens');
    }
    // Copy token bytes before awaiting; a server callback cannot mutate a prospective response.
    const issued = { accessToken: tokens.accessToken, refreshToken: tokens.refreshToken };
    const finalTime = await sampleTimeTx(tx, row.expiresAt, dependencies.clock);
    if (finalTime.expired) throw new SessionRejectedError('session-expired');
    const changed = await tx.$executeRawUnsafe(
      `UPDATE "auth_session" SET "refresh_jti_hash"=$1,"last_used_at"=$2::timestamptz
        WHERE "tenant_id"=$3 AND "session_id"=$4 AND "refresh_jti_hash"=$5
          AND "revoked_at" IS NULL
          AND "expires_at">CASE WHEN $7::boolean THEN $6::timestamptz ELSE clock_timestamp() END`,
      hashJti(refreshJti), time.now, identity.tenantId, identity.sid, row.refreshJtiHash, finalTime.now,
      dependencies.clock !== undefined,
    );
    if (changed !== 1) {
      const rejectedAt = await sampleTimeTx(tx, row.expiresAt, dependencies.clock);
      if (rejectedAt.expired) throw new SessionRejectedError('session-expired');
      throw new RefreshContextError('mutation-count-failure');
    }
    return { status: 'ready' as const, session, principal, ...issued };
  }, { isolationLevel: 'ReadCommitted' });
  if (outcome.status === 'rejected') throw new SessionRejectedError(outcome.code);
  return { session: outcome.session, principal: outcome.principal, accessToken: outcome.accessToken, refreshToken: outcome.refreshToken };
}
