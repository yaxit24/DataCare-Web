import { createHash } from 'node:crypto';
import { withTxBudget, SERIALIZABLE_VOUCHER, type Tx } from '../shared/txBudget.js';
import { hasPostgresErrorCode } from '../shared/prismaError.js';
import type { PrismaClient } from '@datacare/db';
import { loadPrincipalTx, type Principal } from '../rbac/authorization.js';
import { applyLastDayLockTx, type LastDayLockResult } from '../shared/lastDayLock.js';
import { resolveSelectedScopeTx, validateStoredScopeTx, ScopeError } from './businessScope.js';
import {
  nextContextEpoch,
  parseContextEpoch,
  parseContextSelectionId,
  parseUnknownSessionLedgerContext,
  SESSION_LEDGER_CONTEXT_VERSION,
  type ContextEpoch,
  type ContextSelectionId,
  type UnknownSessionLedgerContext,
} from './sessionContextValue.js';

/** Internal coordinator only. No route, JWT verifier, cookie or known ledger-mode authority. */
export interface SelectionAuthenticatedIdentity {
  readonly tenantId: string;
  readonly sessionId: string;
  readonly loginName: string;
  /** Persisted credential company; never substitute Principal.loginCoCode. */
  readonly loginCoCode: string;
  readonly coCode: string;
  readonly lcCode: string;
  readonly coYear?: string;
  readonly contextEpoch: string;
}

export interface ContextSelectionRequest {
  readonly coCode: string;
  readonly lcCode?: string;
  readonly coYear?: string;
  readonly expectedContextEpoch: ContextEpoch;
  readonly selectionId: ContextSelectionId;
}

export interface SelectedSessionContext extends SelectionAuthenticatedIdentity {
  readonly coYear: string;
  readonly contextEpoch: ContextEpoch;
  readonly ledgerContext: UnknownSessionLedgerContext;
  readonly rights: Readonly<Principal['rights']>;
  readonly passwordResetRequired: false;
}

/** Local signer input; scope/epoch come from this transaction, rights from its fresh principal. */
export interface SelectionAccessDescriptor {
  readonly tenantId: string;
  readonly sid: string;
  readonly sub: string;
  readonly loginCoCode: string;
  readonly coCode: string;
  readonly lcCode: string;
  readonly coYear: string;
  readonly contextEpoch: ContextEpoch;
  readonly rights: Readonly<Principal['rights']>;
  readonly passwordResetRequired: false;
}

export interface ContextSelectionResult {
  readonly session: SelectedSessionContext;
  readonly accessToken: string;
  readonly replayed: boolean;
  /** Null means receipt recovery did not invoke the last-lock helper. */
  readonly lastDayLock: Readonly<LastDayLockResult> | null;
}

export type ContextSelectionErrorCode =
  | 'invalid-context-selection-request'
  | 'session-invalid'
  | 'session-context-invalid'
  | 'session-revoked'
  | 'session-expired'
  | 'password-reset-required'
  | 'target-password-reset-required'
  | 'context-stale'
  | 'context-operation-conflict'
  | 'context-epoch-exhausted'
  | 'context-update-conflict'
  | 'context-transaction-conflict'
  | 'context-signing-failed';

export class ContextSelectionError extends Error {
  constructor(public readonly code: ContextSelectionErrorCode) {
    super(code);
    this.name = 'ContextSelectionError';
  }
}

function fail(code: ContextSelectionErrorCode): never {
  throw new ContextSelectionError(code);
}

function dataEnvelope(
  value: unknown,
  allowed: readonly string[],
  required: readonly string[],
): Record<string, unknown> {
  try {
    if (!value || typeof value !== 'object') return fail('invalid-context-selection-request');
    const proto = Object.getPrototypeOf(value);
    if (proto !== Object.prototype && proto !== null)
      return fail('invalid-context-selection-request');
    const out: Record<string, unknown> = Object.create(null);
    for (const key of Reflect.ownKeys(value)) {
      if (typeof key !== 'string' || !allowed.includes(key))
        return fail('invalid-context-selection-request');
      const descriptor = Object.getOwnPropertyDescriptor(value, key);
      if (!descriptor?.enumerable || !Object.hasOwn(descriptor, 'value'))
        return fail('invalid-context-selection-request');
      out[key] = descriptor.value;
    }
    if (required.some((key) => !Object.hasOwn(out, key)))
      return fail('invalid-context-selection-request');
    return out;
  } catch (error) {
    if (error instanceof ContextSelectionError) throw error;
    return fail('invalid-context-selection-request');
  }
}

function scopeText(value: unknown, max: number, code: ContextSelectionErrorCode): string {
  if (
    typeof value !== 'string' ||
    !value ||
    value.length > max ||
    value.trim() !== value ||
    /[^\x20-\x7e]/.test(value)
  ) {
    return fail(code);
  }
  return value;
}

/** Exact JSON-body profile; optional omissions stay omitted and never become defaults here. */
export function parseContextSelectionRequest(value: unknown): ContextSelectionRequest {
  const body = dataEnvelope(
    value,
    ['coCode', 'lcCode', 'coYear', 'expectedContextEpoch', 'selectionId'],
    ['coCode', 'expectedContextEpoch', 'selectionId'],
  );
  const epoch = parseContextEpoch(body.expectedContextEpoch);
  const selection = parseContextSelectionId(body.selectionId);
  if (epoch.status !== 'ready' || selection.status !== 'ready')
    return fail('invalid-context-selection-request');
  return Object.freeze({
    coCode: scopeText(body.coCode, 2, 'invalid-context-selection-request'),
    ...(Object.hasOwn(body, 'lcCode')
      ? { lcCode: scopeText(body.lcCode, 2, 'invalid-context-selection-request') }
      : {}),
    ...(Object.hasOwn(body, 'coYear')
      ? { coYear: scopeText(body.coYear, 9, 'invalid-context-selection-request') }
      : {}),
    expectedContextEpoch: epoch.value,
    selectionId: selection.value,
  });
}

/** Versioned fixed tuple: input key order is irrelevant; omission differs from an explicit value. */
export function contextSelectionRequestSha256(value: ContextSelectionRequest): string {
  const body = parseContextSelectionRequest(value);
  return createHash('sha256')
    .update(
      JSON.stringify([
        'session-context-selection-v1',
        body.coCode,
        Object.hasOwn(body, 'lcCode') ? [1, body.lcCode] : [0],
        Object.hasOwn(body, 'coYear') ? [1, body.coYear] : [0],
        body.expectedContextEpoch,
        body.selectionId,
      ]),
      'utf8',
    )
    .digest('hex');
}

interface SessionRow {
  tenantId: string;
  sessionId: string;
  loginName: string;
  loginCoCode: string;
  coCode: string;
  lcCode: string;
  coYear: string | null;
  contextEpoch: string;
  ledgerContext: unknown;
  selectionId: string | null;
  requestSha256: string | null;
  fromEpoch: string | null;
}

interface ParsedSession {
  readonly row: SessionRow;
  readonly epoch: ContextEpoch;
  readonly ledgerContext: UnknownSessionLedgerContext;
  readonly receipt: Readonly<{
    selectionId: ContextSelectionId;
    requestSha256: string;
    fromEpoch: ContextEpoch;
  }> | null;
}

function parsedSession(row: SessionRow): ParsedSession {
  const epoch = parseContextEpoch(row.contextEpoch);
  const ledger = parseUnknownSessionLedgerContext(row.ledgerContext);
  if (epoch.status !== 'ready' || ledger.status !== 'ready') return fail('session-context-invalid');
  scopeText(row.coCode, 2, 'session-context-invalid');
  scopeText(row.lcCode, 2, 'session-context-invalid');
  if (row.coYear !== null) scopeText(row.coYear, 9, 'session-context-invalid');
  const missing = [row.selectionId, row.requestSha256, row.fromEpoch].filter(
    (value) => value === null,
  ).length;
  if (missing === 3) return { row, epoch: epoch.value, ledgerContext: ledger.value, receipt: null };
  if (missing !== 0) return fail('session-context-invalid');
  const id = parseContextSelectionId(row.selectionId);
  const from = parseContextEpoch(row.fromEpoch);
  if (
    id.status !== 'ready' ||
    from.status !== 'ready' ||
    typeof row.requestSha256 !== 'string' ||
    !/^[0-9a-f]{64}$/.test(row.requestSha256) ||
    row.requestSha256.length !== 64 ||
    BigInt(from.value) + 1n !== BigInt(epoch.value) ||
    row.coYear === null
  ) {
    return fail('session-context-invalid');
  }
  return {
    row,
    epoch: epoch.value,
    ledgerContext: ledger.value,
    receipt: Object.freeze({
      selectionId: id.value,
      requestSha256: row.requestSha256,
      fromEpoch: from.value,
    }),
  };
}

function copyIdentity(value: SelectionAuthenticatedIdentity): SelectionAuthenticatedIdentity {
  const data = dataEnvelope(
    value,
    [
      'tenantId',
      'sessionId',
      'loginName',
      'loginCoCode',
      'coCode',
      'lcCode',
      'coYear',
      'contextEpoch',
    ],
    ['tenantId', 'sessionId', 'loginName', 'loginCoCode', 'coCode', 'lcCode', 'contextEpoch'],
  );
  const epoch = parseContextEpoch(data.contextEpoch);
  if (epoch.status !== 'ready') return fail('session-invalid');
  if (
    typeof data.tenantId !== 'string' ||
    !data.tenantId ||
    data.tenantId.length > 24 ||
    typeof data.sessionId !== 'string' ||
    !data.sessionId ||
    data.sessionId.length > 36 ||
    typeof data.loginName !== 'string' ||
    !data.loginName ||
    data.loginName.length > 255
  )
    return fail('session-invalid');
  return Object.freeze({
    tenantId: data.tenantId,
    sessionId: data.sessionId,
    loginName: data.loginName,
    loginCoCode: scopeText(data.loginCoCode, 2, 'session-invalid'),
    coCode: scopeText(data.coCode, 2, 'session-invalid'),
    lcCode: scopeText(data.lcCode, 2, 'session-invalid'),
    ...(data.coYear !== undefined ? { coYear: scopeText(data.coYear, 9, 'session-invalid') } : {}),
    contextEpoch: epoch.value,
  });
}

function assertIdentity(current: ParsedSession, identity: SelectionAuthenticatedIdentity): void {
  const row = current.row;
  if (
    row.tenantId !== identity.tenantId ||
    row.sessionId !== identity.sessionId ||
    row.loginName !== identity.loginName ||
    row.loginCoCode !== identity.loginCoCode ||
    row.coCode !== identity.coCode ||
    row.lcCode !== identity.lcCode ||
    (row.coYear ?? undefined) !== identity.coYear ||
    current.epoch !== identity.contextEpoch
  )
    return fail('session-invalid');
}

/** A separate query is deliberate: a SELECT target expression may be evaluated before its row-lock wait. */
async function assertLiveAfterLock(
  tx: Tx,
  identity: SelectionAuthenticatedIdentity,
): Promise<void> {
  const rows = await tx.$queryRawUnsafe<Array<{ revoked: boolean; unexpired: boolean }>>(
    `SELECT "revoked_at" IS NOT NULL AS revoked, "expires_at" > clock_timestamp() AS unexpired
       FROM "auth_session" WHERE "tenant_id"=$1 AND "session_id"=$2`,
    identity.tenantId,
    identity.sessionId,
  );
  if (rows.length !== 1) return fail('session-invalid');
  const row = rows[0]!;
  if (row.revoked === true) return fail('session-revoked');
  if (row.revoked !== false || row.unexpired !== true) return fail('session-expired');
}

function projectSelected(
  identity: SelectionAuthenticatedIdentity,
  scope: { coCode: string; lcCode: string; coYear?: string },
  epoch: ContextEpoch,
  ledger: UnknownSessionLedgerContext,
  principal: Principal,
): SelectedSessionContext {
  if (!scope.coYear) throw new ScopeError('year-unavailable');
  return Object.freeze({
    ...identity,
    coCode: scopeText(scope.coCode, 2, 'session-context-invalid'),
    lcCode: scopeText(scope.lcCode, 2, 'session-context-invalid'),
    coYear: scopeText(scope.coYear, 9, 'session-context-invalid'),
    contextEpoch: epoch,
    ledgerContext: ledger,
    rights: Object.freeze({ ...principal.rights }),
    passwordResetRequired: false,
  });
}

async function signSelected(
  session: SelectedSessionContext,
  signAccess: (input: SelectionAccessDescriptor) => Promise<string>,
): Promise<string> {
  const token = await signAccess(
    Object.freeze({
      tenantId: session.tenantId,
      sid: session.sessionId,
      sub: session.loginName,
      loginCoCode: session.loginCoCode,
      coCode: session.coCode,
      lcCode: session.lcCode,
      coYear: session.coYear,
      contextEpoch: session.contextEpoch,
      rights: session.rights,
      passwordResetRequired: false,
    }),
  );
  if (typeof token !== 'string' || token.length === 0) return fail('context-signing-failed');
  return token;
}

function isTransactionConflict(error: unknown): boolean {
  if (!error || typeof error !== 'object') return false;
  return hasPostgresErrorCode(error, 'P2034', '40001', '40P01');
}

/**
 * Same transaction: lock/current authority -> receipt/CAS -> target authority -> settings -> local signer -> guarded update.
 * The signer must be local cryptographic work; it must never publish cookies, perform network I/O or mutate authority.
 * Returning from withTenant proves commit. A thrown post-write error rolls back settings and context together.
 * No internal retry, refresh rotation, known mode or universal in-flight financial-request guarantee is introduced.
 */
export async function selectSessionContext(
  prisma: PrismaClient,
  input: { identity: SelectionAuthenticatedIdentity; request: unknown },
  dependencies: { signAccess: (input: SelectionAccessDescriptor) => Promise<string> },
): Promise<ContextSelectionResult> {
  const request = parseContextSelectionRequest(input.request);
  const identity = copyIdentity(input.identity);
  const requestSha256 = contextSelectionRequestSha256(request);
  try {
    return await withTxBudget(prisma, identity.tenantId, SERIALIZABLE_VOUCHER, async (tx) => {
      const rows = await tx.$queryRawUnsafe<SessionRow[]>(
        `SELECT "tenant_id" AS "tenantId", "session_id" AS "sessionId", "login_name" AS "loginName",
                "login_co_code" AS "loginCoCode", "co_code" AS "coCode", "lc_code" AS "lcCode", "co_year" AS "coYear",
                "context_epoch"::text AS "contextEpoch", "ledger_context" AS "ledgerContext",
                "last_context_selection_id" AS "selectionId", "last_context_request_sha256" AS "requestSha256",
                "last_context_from_epoch"::text AS "fromEpoch"
           FROM "auth_session" WHERE "tenant_id"=$1 AND "session_id"=$2 FOR UPDATE`,
        identity.tenantId,
        identity.sessionId,
      );
      if (rows.length !== 1) return fail('session-invalid');
      const current = parsedSession(rows[0]!);
      assertIdentity(current, identity);
      await assertLiveAfterLock(tx, identity);
      // Plain transactional reads only: password reset already locks LOGIN_MAST before auth_session.
      const principal = await loadPrincipalTx(tx, {
        tenantId: identity.tenantId,
        loginName: identity.loginName,
        coCode: current.row.coCode,
        loginCoCode: current.row.loginCoCode,
      });
      if (principal.passwordResetRequired) return fail('password-reset-required');

      if (current.receipt?.selectionId === request.selectionId) {
        if (
          current.receipt.requestSha256 !== requestSha256 ||
          current.receipt.fromEpoch !== request.expectedContextEpoch
        ) {
          return fail('context-operation-conflict');
        }
        // Recovery validates the exact committed scope; it never resolves new defaults or applies last-lock.
        await validateStoredScopeTx(tx, {
          tenantId: identity.tenantId,
          loginName: identity.loginName,
          isAdmin: principal.isAdmin,
          coCode: current.row.coCode,
          lcCode: current.row.lcCode,
          ...(current.row.coYear === null ? {} : { coYear: current.row.coYear }),
        });
        const session = projectSelected(
          identity,
          {
            coCode: current.row.coCode,
            lcCode: current.row.lcCode,
            ...(current.row.coYear === null ? {} : { coYear: current.row.coYear }),
          },
          current.epoch,
          current.ledgerContext,
          principal,
        );
        const accessToken = await signSelected(session, dependencies.signAccess);
        await assertLiveAfterLock(tx, identity);
        return Object.freeze({ session, accessToken, replayed: true, lastDayLock: null });
      }
      if (request.expectedContextEpoch !== current.epoch) return fail('context-stale');
      const next = nextContextEpoch(current.epoch);
      if (next.status !== 'ready') return fail('context-epoch-exhausted');
      const scope = await resolveSelectedScopeTx(tx, {
        tenantId: identity.tenantId,
        loginName: identity.loginName,
        isAdmin: principal.isAdmin,
        coCode: request.coCode,
        ...(Object.hasOwn(request, 'lcCode') ? { lcCode: request.lcCode } : {}),
        ...(Object.hasOwn(request, 'coYear') ? { coYear: request.coYear } : {}),
      });
      const target = await loadPrincipalTx(tx, {
        tenantId: identity.tenantId,
        loginName: identity.loginName,
        coCode: scope.coCode,
        loginCoCode: current.row.loginCoCode,
      });
      // Explicit new web policy: another company's required credential reset cannot safely use this login identity.
      if (target.passwordResetRequired) return fail('target-password-reset-required');
      const ledgerContext: UnknownSessionLedgerContext = Object.freeze({
        version: SESSION_LEDGER_CONTEXT_VERSION,
        status: 'unknown',
        mode: null,
        reason: 'vendor-authority-unresolved',
      });
      const session = projectSelected(identity, scope, next.value, ledgerContext, target);
      // Integration requires the accompanying lastDayLock.ts FOR UPDATE change; no wrapper/nested transaction.
      const lock = await applyLastDayLockTx(tx, identity.tenantId, scope.coCode);
      const accessToken = await signSelected(session, dependencies.signAccess);
      const updated = await tx.$queryRawUnsafe<Array<{ contextEpoch: string }>>(
        `UPDATE "auth_session"
            SET "co_code"=$3, "lc_code"=$4, "co_year"=$5, "context_epoch"=$6::bigint,
                "ledger_context"=$7::jsonb, "last_context_selection_id"=$8,
                "last_context_request_sha256"=$9, "last_context_from_epoch"=$10::bigint
          WHERE "tenant_id"=$1 AND "session_id"=$2 AND "context_epoch"=$10::bigint
            AND "revoked_at" IS NULL AND "expires_at" > clock_timestamp()
          RETURNING "context_epoch"::text AS "contextEpoch"`,
        identity.tenantId,
        identity.sessionId,
        session.coCode,
        session.lcCode,
        session.coYear,
        session.contextEpoch,
        JSON.stringify(ledgerContext),
        request.selectionId,
        requestSha256,
        current.epoch,
      );
      if (updated.length !== 1 || updated[0]?.contextEpoch !== session.contextEpoch) {
        await assertLiveAfterLock(tx, identity);
        return fail('context-update-conflict');
      }
      return Object.freeze({
        session,
        accessToken,
        replayed: false,
        lastDayLock: Object.freeze({ ...lock }),
      });
    });
  } catch (error) {
    if (isTransactionConflict(error)) return fail('context-transaction-conflict');
    throw error;
  }
}
