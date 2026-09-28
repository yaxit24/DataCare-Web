import { withTenant, type Tx } from '@datacare/db';
import { ScopeError, validateStoredScopeTx } from './businessScope.js';
import {
  loadPrincipalTx,
  authorizeFormTx,
  FormForbiddenError,
  PrincipalUnavailableError,
  type Principal,
  type FormAuthorization,
} from '../rbac/authorization.js';
import type { RouteAction } from '../rbac/routePolicy.js';
import type { AuthenticatedSessionContext } from './sessionContextAccess.js';
import { parseContextEpoch, parseUnknownSessionLedgerContext } from './sessionContextValue.js';

export interface SessionCommandIdentity {
  readonly tenantId: string;
  readonly sessionId: string;
  readonly loginName: string;
  readonly loginCoCode: string;
  readonly coCode: string;
  readonly lcCode: string;
  readonly coYear: string | undefined;
  readonly contextEpoch: string;
}
export interface SessionCommandPolicy {
  readonly form: string;
  readonly action: RouteAction;
  readonly adminOnly?: boolean;
  readonly scope: Readonly<{
    tenantId: string;
    coCode: string;
    lcCode: string;
    coYear: string;
    coBook: string;
  }>;
}
export class SessionCommandError extends Error {
  constructor(
    public readonly code: string,
    public readonly statusCode: number,
    message: string = code,
    public readonly form?: string,
    public readonly action?: RouteAction,
  ) {
    super(message);
    this.name = 'SessionCommandError';
  }
}
const fail = (code: string, status: 401 | 403 | 409 | 500): never => {
  throw new SessionCommandError(code, status);
};
const identityKeys = [
  'tenantId',
  'sessionId',
  'loginName',
  'loginCoCode',
  'coCode',
  'lcCode',
  'coYear',
  'contextEpoch',
] as const;
function copyIdentity(input: unknown): SessionCommandIdentity {
  if (!input || typeof input !== 'object' || Array.isArray(input))
    return fail('session-invalid', 401);
  const prototype = Object.getPrototypeOf(input);
  if (prototype !== Object.prototype && prototype !== null) return fail('session-invalid', 401);
  const keys = Reflect.ownKeys(input);
  if (
    keys.length !== identityKeys.length ||
    keys.some(
      (key) =>
        typeof key !== 'string' || !identityKeys.includes(key as (typeof identityKeys)[number]),
    )
  ) {
    return fail('session-invalid', 401);
  }
  const descriptors = Object.getOwnPropertyDescriptors(input);
  const out: Record<string, unknown> = {};
  for (const key of identityKeys) {
    const descriptor = descriptors[key];
    if (!descriptor?.enumerable || !('value' in descriptor)) return fail('session-invalid', 401);
    out[key] = descriptor.value;
  }
  for (const [key, max] of [
    ['tenantId', 24],
    ['sessionId', 36],
    ['loginName', 255],
    ['loginCoCode', 2],
    ['coCode', 2],
    ['lcCode', 2],
  ] as const) {
    if (typeof out[key] !== 'string' || !out[key] || out[key].length > max)
      return fail('session-invalid', 401);
  }
  if (
    out.coYear !== undefined &&
    (typeof out.coYear !== 'string' || !out.coYear || out.coYear.length > 9)
  ) {
    return fail('session-invalid', 401);
  }
  const epoch = parseContextEpoch(out.contextEpoch);
  if (epoch.status !== 'ready') return fail('session-invalid', 401);
  return Object.freeze({
    tenantId: out.tenantId as string,
    sessionId: out.sessionId as string,
    loginName: out.loginName as string,
    loginCoCode: out.loginCoCode as string,
    coCode: out.coCode as string,
    lcCode: out.lcCode as string,
    coYear: out.coYear as string | undefined,
    contextEpoch: epoch.value,
  });
}
function ownData(
  input: unknown,
  required: readonly string[],
  optional: readonly string[] = [],
): Record<string, unknown> {
  if (!input || typeof input !== 'object' || Array.isArray(input))
    return fail('invalid-command-policy', 500);
  const prototype = Object.getPrototypeOf(input);
  if (prototype !== Object.prototype && prototype !== null)
    return fail('invalid-command-policy', 500);
  const keys = Reflect.ownKeys(input);
  if (
    keys.some((key) => typeof key !== 'string' || ![...required, ...optional].includes(key)) ||
    required.some((key) => !Object.hasOwn(input, key))
  )
    return fail('invalid-command-policy', 500);
  const out: Record<string, unknown> = {};
  for (const key of keys) {
    const descriptor = Object.getOwnPropertyDescriptor(input, key)!;
    if (!descriptor.enumerable || !('value' in descriptor))
      return fail('invalid-command-policy', 500);
    out[key as string] = descriptor.value;
  }
  return out;
}
function copyPolicy(input: SessionCommandPolicy): SessionCommandPolicy {
  const raw = ownData(input, ['form', 'action', 'scope'], ['adminOnly']);
  const scope = ownData(raw.scope, ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook']);
  if (
    typeof raw.form !== 'string' ||
    !raw.form ||
    typeof raw.action !== 'string' ||
    !['read', 'create', 'update', 'delete', 'print'].includes(raw.action) ||
    (Object.hasOwn(raw, 'adminOnly') && typeof raw.adminOnly !== 'boolean')
  )
    return fail('invalid-command-policy', 500);
  if (Object.values(scope).some((value) => typeof value !== 'string' || !value))
    return fail('scope-incomplete', 409);
  return Object.freeze({
    form: raw.form,
    action: raw.action as RouteAction,
    ...(Object.hasOwn(raw, 'adminOnly') ? { adminOnly: raw.adminOnly as boolean } : {}),
    scope: Object.freeze({
      tenantId: scope.tenantId as string,
      coCode: scope.coCode as string,
      lcCode: scope.lcCode as string,
      coYear: scope.coYear as string,
      coBook: scope.coBook as string,
    }),
  });
}

interface StoredCommandSession {
  tenantId: string;
  sessionId: string;
  loginName: string;
  loginCoCode: string;
  coCode: string;
  lcCode: string;
  coYear: string | null;
  contextEpoch: unknown;
  ledgerContext: unknown;
}
function contextFrom(
  row: StoredCommandSession,
  identity: SessionCommandIdentity,
): AuthenticatedSessionContext {
  if (
    row.tenantId !== identity.tenantId ||
    row.sessionId !== identity.sessionId ||
    row.loginName !== identity.loginName ||
    row.loginCoCode !== identity.loginCoCode
  )
    return fail('session-invalid', 401);
  const epoch = parseContextEpoch(row.contextEpoch);
  const ledger = parseUnknownSessionLedgerContext(row.ledgerContext);
  if (epoch.status !== 'ready' || ledger.status !== 'ready') return fail('session-invalid', 401);
  if (
    epoch.value !== identity.contextEpoch ||
    row.coCode !== identity.coCode ||
    row.lcCode !== identity.lcCode ||
    (row.coYear ?? undefined) !== identity.coYear
  )
    return fail('context-stale', 409);
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
/** Separate from the locking SELECT: clock_timestamp must be sampled after a possible lock wait. */
async function assertLiveTx(tx: Tx, identity: SessionCommandIdentity): Promise<void> {
  const rows = await tx.$queryRawUnsafe<Array<{ revoked: boolean; unexpired: boolean }>>(
    `SELECT "revoked_at" IS NOT NULL AS revoked,"expires_at">clock_timestamp() AS unexpired
       FROM "auth_session" WHERE "tenant_id"=$1 AND "session_id"=$2`,
    identity.tenantId,
    identity.sessionId,
  );
  if (rows.length !== 1) return fail('session-invalid', 401);
  if (rows[0]!.revoked !== false) return fail('session-revoked', 401);
  if (rows[0]!.unexpired !== true) return fail('session-expired', 401);
}
async function assertFinalContextTx(
  tx: Tx,
  identity: SessionCommandIdentity,
  admitted: AuthenticatedSessionContext,
): Promise<void> {
  const rows = await tx.$queryRawUnsafe<
    Array<StoredCommandSession & { revoked: boolean; unexpired: boolean }>
  >(
    `SELECT "tenant_id" AS "tenantId","session_id" AS "sessionId","login_name" AS "loginName",
            "login_co_code" AS "loginCoCode","co_code" AS "coCode","lc_code" AS "lcCode","co_year" AS "coYear",
            "context_epoch"::text AS "contextEpoch","ledger_context" AS "ledgerContext",
            "revoked_at" IS NOT NULL AS revoked,"expires_at">clock_timestamp() AS unexpired
       FROM "auth_session" WHERE "tenant_id"=$1 AND "session_id"=$2`,
    identity.tenantId,
    identity.sessionId,
  );
  if (rows.length !== 1) return fail('session-invalid', 401);
  const row = rows[0]!;
  if (row.revoked !== false) return fail('session-revoked', 401);
  if (row.unexpired !== true) return fail('session-expired', 401);
  const current = contextFrom(row, identity);
  if (JSON.stringify(current.ledgerContext) !== JSON.stringify(admitted.ledgerContext))
    return fail('context-stale', 409);
}

function transactionConflict(error: unknown): boolean {
  if (!error || typeof error !== 'object') return false;
  const detail = error as { code?: unknown; meta?: { code?: unknown } };
  return (
    detail.code === 'P2034' ||
    detail.code === '40001' ||
    detail.code === '40P01' ||
    (detail.code === 'P2010' && (detail.meta?.code === '40001' || detail.meta?.code === '40P01'))
  );
}

/**
 * First lock is one session FOR SHARE, retained through the full callback/commit. No auth writes,
 * nested transaction, external side effects or lock upgrade are permitted inside work.
 * READ COMMITTED is deliberate: after waiting, observe the committed session winner. This is not
 * a snapshot guarantee for independently changed configuration/rights. The final SQL expiry check
 * defines a final-statement boundary, not an assertion about the exact later COMMIT timestamp.
 */
export async function withSessionContextCommand<T>(
  prisma: Parameters<typeof withTenant>[0],
  suppliedIdentity: unknown,
  suppliedPolicy: SessionCommandPolicy,
  work: (
    tx: Tx,
    admitted: Readonly<{
      context: AuthenticatedSessionContext;
      principal: Principal;
      authorization: FormAuthorization;
    }>,
  ) => Promise<T>,
): Promise<T> {
  const identity = copyIdentity(suppliedIdentity);
  const policy = copyPolicy(suppliedPolicy);
  if (!identity.coYear || !policy.scope.coBook || typeof policy.scope.coBook !== 'string') {
    return fail('scope-incomplete', 409);
  }
  if (
    ['tenantId', 'coCode', 'lcCode', 'coYear'].some(
      (key) =>
        policy.scope[key as keyof typeof policy.scope] !==
        identity[key as keyof SessionCommandIdentity],
    )
  ) {
    return fail('scope-mismatch', 409);
  }
  if (!policy.form || !['read', 'create', 'update', 'delete', 'print'].includes(policy.action)) {
    return fail('invalid-command-policy', 500);
  }
  try {
    return await withTenant(
      prisma,
      identity.tenantId,
      async (tx) => {
        const binding = await tx.$queryRawUnsafe<
          Array<{ tenant: string | null; isolation: string }>
        >(
          `SELECT current_setting('app.tenant_id',true) AS tenant,current_setting('transaction_isolation') AS isolation`,
        );
        if (
          binding.length !== 1 ||
          binding[0]!.tenant !== identity.tenantId ||
          binding[0]!.isolation !== 'read committed'
        ) {
          return fail('invalid-transaction-context', 500);
        }
        const rows = await tx.$queryRawUnsafe<StoredCommandSession[]>(
          `SELECT "tenant_id" AS "tenantId","session_id" AS "sessionId","login_name" AS "loginName",
                "login_co_code" AS "loginCoCode","co_code" AS "coCode","lc_code" AS "lcCode","co_year" AS "coYear",
                "context_epoch"::text AS "contextEpoch","ledger_context" AS "ledgerContext"
           FROM "auth_session" WHERE "tenant_id"=$1 AND "session_id"=$2 FOR SHARE`,
          identity.tenantId,
          identity.sessionId,
        );
        if (rows.length !== 1) return fail('session-invalid', 401);
        const row = rows[0]!;
        // Subject identity first, then live state, then changing business context.
        if (
          row.tenantId !== identity.tenantId ||
          row.sessionId !== identity.sessionId ||
          row.loginName !== identity.loginName ||
          row.loginCoCode !== identity.loginCoCode
        )
          return fail('session-invalid', 401);
        await assertLiveTx(tx, identity);
        const context = contextFrom(row, identity);
        // Never lock LOGIN_MAST here: password reset already locks it before auth_session.
        const current = await loadPrincipalTx(tx, {
          tenantId: context.tenantId,
          loginName: context.loginName,
          coCode: context.coCode,
          loginCoCode: context.loginCoCode,
        });
        const principal = Object.freeze({
          ...current,
          rights: Object.freeze({ ...current.rights }),
        });
        if (principal.passwordResetRequired) return fail('password-reset-required', 403);
        await validateStoredScopeTx(tx, {
          tenantId: context.tenantId,
          loginName: context.loginName,
          isAdmin: principal.isAdmin,
          coCode: context.coCode,
          lcCode: context.lcCode,
          coYear: context.coYear,
        });
        const authorization = Object.freeze(
          await authorizeFormTx(tx, {
            tenantId: context.tenantId,
            lcCode: context.lcCode,
            principal,
            form: policy.form,
            action: policy.action,
            adminOnly: policy.adminOnly,
          }),
        );
        const result = await work(tx, Object.freeze({ context, principal, authorization }));
        await assertFinalContextTx(tx, identity, context);
        return result;
      },
      { isolationLevel: 'ReadCommitted' },
    );
  } catch (error) {
    if (error instanceof PrincipalUnavailableError) return fail('session-invalid', 401);
    if (error instanceof ScopeError)
      throw new SessionCommandError(error.code, error.statusCode, error.message);
    if (error instanceof FormForbiddenError)
      throw new SessionCommandError('forbidden', 403, error.message, error.form, error.action);
    if (transactionConflict(error)) return fail('session-command-conflict', 409);
    throw error;
  }
}
