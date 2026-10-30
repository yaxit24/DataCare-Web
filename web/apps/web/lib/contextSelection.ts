'use client';
import {
  getPageContextState,
  post,
  ApiError,
  pinPageContext,
  pausePageContextForSelection,
} from './api';
import { parseBrowserSessionContext, type BrowserSessionContext } from './pageContext';

const storageKey = 'datacare.pending-context-selection.v1';
const maxEpoch = '9223372036854775807';
export interface PendingContextSelection {
  readonly version: 'context-selection-recovery-v1';
  readonly sessionId: string;
  readonly request: Readonly<{
    coCode: string;
    lcCode?: string;
    coYear?: string;
    expectedContextEpoch: string;
    selectionId: string;
  }>;
}
const uuid = (value: unknown): value is string =>
  typeof value === 'string' &&
  value.length === 36 &&
  /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/.test(value);
const code = (value: unknown, length: number): value is string =>
  typeof value === 'string' &&
  value.length > 0 &&
  value.length <= length &&
  value.trim() === value &&
  !/[^\x20-\x7e]/.test(value);
const epoch = (value: unknown): value is string =>
  typeof value === 'string' &&
  value.length > 0 &&
  value[0] !== '0' &&
  !/[^0-9]/.test(value) &&
  (value.length < maxEpoch.length || (value.length === maxEpoch.length && value <= maxEpoch));

/** Persisted data is only a pending request, never authority. The server validates every retry. */
export function parsePendingContextSelection(value: unknown): PendingContextSelection | null {
  const record = ownData(value, ['request', 'sessionId', 'version']);
  if (
    !record ||
    Object.keys(record).sort().join(',') !== 'request,sessionId,version' ||
    record.version !== 'context-selection-recovery-v1' ||
    !uuid(record.sessionId)
  )
    return null;
  const body = ownData(record.request, [
    'coCode',
    'lcCode',
    'coYear',
    'expectedContextEpoch',
    'selectionId',
  ]);
  if (
    !body ||
    !code(body.coCode, 2) ||
    !epoch(body.expectedContextEpoch) ||
    !uuid(body.selectionId) ||
    (Object.hasOwn(body, 'lcCode') && !code(body.lcCode, 2)) ||
    (Object.hasOwn(body, 'coYear') && !code(body.coYear, 9))
  )
    return null;
  return Object.freeze({
    version: 'context-selection-recovery-v1',
    sessionId: record.sessionId,
    request: Object.freeze({
      coCode: body.coCode,
      expectedContextEpoch: body.expectedContextEpoch,
      selectionId: body.selectionId,
      ...(Object.hasOwn(body, 'lcCode') ? { lcCode: body.lcCode as string } : {}),
      ...(Object.hasOwn(body, 'coYear') ? { coYear: body.coYear as string } : {}),
    }),
  });
}

function ownData(value: unknown, allowed: string[]): Record<string, unknown> | null {
  try {
    if (!value || typeof value !== 'object' || Array.isArray(value)) return null;
    const prototype = Object.getPrototypeOf(value);
    if (prototype !== Object.prototype && prototype !== null) return null;
    const result: Record<string, unknown> = Object.create(null);
    for (const key of Reflect.ownKeys(value)) {
      if (typeof key !== 'string' || !allowed.includes(key)) return null;
      const descriptor = Object.getOwnPropertyDescriptor(value, key);
      if (!descriptor?.enumerable || !Object.hasOwn(descriptor, 'value')) return null;
      result[key] = descriptor.value;
    }
    return result;
  } catch {
    return null;
  }
}

export function createPendingContextSelection(
  context: BrowserSessionContext,
  target: { coCode: string; lcCode?: string; coYear?: string },
): PendingContextSelection {
  const pending = parsePendingContextSelection({
    version: 'context-selection-recovery-v1',
    sessionId: context.sessionId,
    request: {
      ...target,
      expectedContextEpoch: context.contextEpoch,
      selectionId: crypto.randomUUID(),
    },
  });
  if (!pending)
    throw new Error('The selected company context is invalid. Reload and select it again.');
  return pending;
}

export function savePendingContextSelection(pending: PendingContextSelection): void {
  // Persist before dispatch. Failure must leave the server unchanged because recovery data was not saved.
  const parsed = parsePendingContextSelection(pending);
  if (!parsed) throw new Error('Invalid company change recovery record.');
  const existing = sessionStorage.getItem(storageKey);
  if (existing && existing !== JSON.stringify(parsed)) {
    throw new Error('Check the previous company change before starting another one.');
  }
  sessionStorage.setItem(storageKey, JSON.stringify(parsed));
}

export function readPendingContextSelection(
  context: BrowserSessionContext,
): PendingContextSelection | null {
  const raw = sessionStorage.getItem(storageKey);
  if (!raw) return null;
  let pending: PendingContextSelection | null = null;
  try {
    pending = parsePendingContextSelection(JSON.parse(raw));
  } catch {
    /* invalid local data */
  }
  if (!pending || pending.sessionId !== context.sessionId) {
    sessionStorage.removeItem(storageKey);
    return null;
  }
  return pending;
}

export function clearPendingContextSelection(selectionId: string): void {
  const raw = sessionStorage.getItem(storageKey);
  if (!raw) return;
  let pending: PendingContextSelection | null;
  try {
    pending = parsePendingContextSelection(JSON.parse(raw));
  } catch {
    return;
  }
  // A storage failure is observable; the still-retained exact request can be checked again.
  if (pending?.request.selectionId === selectionId) sessionStorage.removeItem(storageKey);
}

/**
 * Normal page guard remains pinned. After an uncertain result, explicit full navigation to /select
 * bootstraps fresh authority; the exact stored body/operation ID is reused under that new page.
 * No refresh bypass, automatic draft retry, or replacement expected epoch is introduced.
 */
/** Pauses before each retry of a selection that lost a transaction conflict (G172). */
export const CONFLICT_RETRY_DELAYS_MS = [150, 400, 900, 1600] as const;

/**
 * G172: several sessions opening a company at the same moment can make one serializable selection lose with
 * 409 `context-transaction-conflict`. That transaction rolled back, and the same request is safe to send again (the
 * server replays a selection that already committed), so it is retried before the operator ever sees it.
 */
export async function postSelectionRetryingConflicts(
  pending: PendingContextSelection,
  isCurrent: () => boolean,
  wait: (ms: number) => Promise<void> = (ms) => new Promise((resolve) => setTimeout(resolve, ms)),
) {
  for (let attempt = 0; ; attempt++) {
    try {
      return await post<{ context: unknown; scoped: boolean; replayed: boolean }>(
        '/context/select',
        pending.request,
      );
    } catch (error) {
      const conflict =
        error instanceof ApiError &&
        error.status === 409 &&
        error.body?.error === 'context-transaction-conflict';
      const delay = CONFLICT_RETRY_DELAYS_MS[attempt];
      if (!conflict || delay === undefined || !isCurrent()) throw error;
      // A little jitter, so sessions that lost together do not collide again.
      await wait(delay + Math.floor(Math.random() * 100));
    }
  }
}

export async function submitPendingContextSelection(
  pending: PendingContextSelection,
  options: { isCurrent?: () => boolean } = {},
): Promise<BrowserSessionContext> {
  const isCurrent = options.isCurrent ?? (() => true);
  if (!isCurrent()) throw new Error('The company selection page is no longer active.');
  const parsed = parsePendingContextSelection(pending);
  if (!parsed || sessionStorage.getItem(storageKey) !== JSON.stringify(parsed)) {
    throw new Error('Save the company change recovery record before submitting it.');
  }
  pending = parsed;
  const current = getPageContextState();
  if (
    current.status !== 'ready' ||
    !current.context ||
    current.context.sessionId !== pending.sessionId
  ) {
    throw new ApiError('Reload the company selection page before retrying this change.', 409, {
      error: 'context-stale',
    });
  }
  const originalEpoch = BigInt(pending.request.expectedContextEpoch);
  const liveEpoch = BigInt(current.context.contextEpoch);
  if (liveEpoch !== originalEpoch && liveEpoch !== originalEpoch + 1n) {
    throw new ApiError(
      'Another company change has replaced this operation. Check the current company before starting a new change.',
      409,
      { error: 'context-stale' },
    );
  }
  try {
    const response = await postSelectionRetryingConflicts(pending, isCurrent);
    const context = parseBrowserSessionContext(response.context);
    if (
      response.scoped !== true ||
      response.replayed !== (liveEpoch === originalEpoch + 1n) ||
      !context ||
      context.sessionId !== pending.sessionId ||
      BigInt(context.contextEpoch) !== originalEpoch + 1n ||
      context.coCode !== pending.request.coCode ||
      context.coYear === null ||
      (pending.request.lcCode !== undefined && context.lcCode !== pending.request.lcCode) ||
      (pending.request.coYear !== undefined && context.coYear !== pending.request.coYear)
    ) {
      throw new Error(
        'The company change response could not be confirmed. Check the current company before continuing.',
      );
    }
    // Even if this component left the route, this document must stop using its old authority.
    // The shared API has already refused results belonging to a reset/replaced page guard.
    pinPageContext(context);
    if (!isCurrent())
      throw new Error(
        'The company selection page is no longer active. The saved operation can be checked after reloading.',
      );
    clearPendingContextSelection(pending.request.selectionId);
    return context;
  } catch (error) {
    // A dispatched operation may have committed. Freeze its original page, but never poison
    // a later explicitly reset page or replace a more precise confirmed-stale observation.
    if (getPageContextState() === current) pausePageContextForSelection();
    throw error;
  }
}
