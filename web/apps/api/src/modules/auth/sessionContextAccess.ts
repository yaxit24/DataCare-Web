import { withTenant } from '@datacare/db';
import type { SessionClaims } from './jwt.js';
import { SessionRejectedError } from './session.js';
import {
  parseContextEpoch,
  parseUnknownSessionLedgerContext,
  type ContextEpoch,
  type UnknownSessionLedgerContext,
} from './sessionContextValue.js';

export interface AuthenticatedSessionContext {
  readonly tenantId: string;
  readonly sessionId: string;
  readonly loginName: string;
  readonly loginCoCode: string;
  readonly coCode: string;
  readonly lcCode: string;
  readonly coYear: string | undefined;
  readonly contextEpoch: ContextEpoch;
  readonly ledgerContext: UnknownSessionLedgerContext;
}

/** Request admission only. Financial work still needs its own check inside its write transaction. */
export async function validateAccessSessionContext(
  prisma: Parameters<typeof withTenant>[0],
  claims: SessionClaims,
): Promise<AuthenticatedSessionContext> {
  const rows = await withTenant(prisma, claims.tenantId, (tx) =>
    tx.$queryRawUnsafe<
      Array<{
        tenantId: string;
        sessionId: string;
        loginName: string;
        loginCoCode: string;
        coCode: string;
        lcCode: string;
        coYear: string | null;
        contextEpoch: unknown;
        ledgerContext: unknown;
        revoked: boolean;
        unexpired: boolean;
      }>
    >(
      `SELECT "tenant_id" AS "tenantId","session_id" AS "sessionId","login_name" AS "loginName",
      "login_co_code" AS "loginCoCode","co_code" AS "coCode","lc_code" AS "lcCode","co_year" AS "coYear",
      "context_epoch"::text AS "contextEpoch","ledger_context" AS "ledgerContext",
      "revoked_at" IS NOT NULL AS revoked,"expires_at">clock_timestamp() AS unexpired
     FROM "auth_session" WHERE "tenant_id"=$1 AND "session_id"=$2`,
      claims.tenantId,
      claims.sid,
    ),
  );
  const row = rows[0];
  if (
    rows.length !== 1 ||
    !row ||
    row.tenantId !== claims.tenantId ||
    row.sessionId !== claims.sid ||
    row.loginName !== claims.sub ||
    row.loginCoCode !== claims.loginCoCode ||
    row.coCode !== claims.coCode ||
    row.lcCode !== claims.lcCode ||
    (row.coYear ?? undefined) !== claims.coYear
  )
    throw new SessionRejectedError('session-invalid');
  if (row.revoked !== false) throw new SessionRejectedError('session-revoked');
  if (row.unexpired !== true) throw new SessionRejectedError('session-expired');
  const epoch = parseContextEpoch(row.contextEpoch);
  const claimedEpoch = parseContextEpoch(claims.contextEpoch);
  const ledger = parseUnknownSessionLedgerContext(row.ledgerContext);
  if (
    epoch.status !== 'ready' ||
    claimedEpoch.status !== 'ready' ||
    epoch.value !== claimedEpoch.value ||
    ledger.status !== 'ready'
  ) {
    throw new SessionRejectedError('session-invalid');
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
  });
}
