/** Page identity is separate from BusinessScope: do not spread it into business request bodies. */
export interface BrowserSessionContext {
  readonly sessionId: string;
  readonly contextEpoch: string;
  readonly coCode: string;
  readonly lcCode: string;
  readonly coYear: string | null;
}
export type PageContextReason =
  | 'context-changed'
  | 'invalid-context-response'
  | 'server-context-stale'
  | 'context-selection-unconfirmed';
export interface PageContextState {
  readonly status: 'unbound' | 'ready' | 'stale';
  readonly revision: number;
  readonly context: BrowserSessionContext | null;
  readonly observed: BrowserSessionContext | null;
  readonly reason: PageContextReason | null;
  readonly message: string | null;
}
export interface PageContextTicket {
  readonly revision: number;
  readonly context: BrowserSessionContext | null;
}
const staleMessage =
  'This page’s session context changed. Copy any unsaved changes, then reload the page before continuing.';
const selectionMessage =
  'The company change needs to be checked. Copy unsaved work, then reload company selection.';
const obsoleteMessage =
  'The page context changed while this request was running. Its result was discarded; reload the data before continuing.';
export class PageContextError extends Error {
  readonly status = 409;
  readonly body: Readonly<{
    error: 'context-stale' | 'context-response-obsolete';
    message: string;
  }>;
  constructor(
    readonly code: 'context-stale' | 'context-response-obsolete',
    message = code === 'context-stale' ? staleMessage : obsoleteMessage,
  ) {
    super(message);
    this.name = 'PageContextError';
    this.body = Object.freeze({ error: code, message: this.message });
  }
}

const keys = ['sessionId', 'contextEpoch', 'coCode', 'lcCode', 'coYear'] as const;
const maximumEpoch = '9223372036854775807';
const exactCode = (value: unknown, maximum: number): value is string =>
  typeof value === 'string' &&
  value.length <= maximum &&
  value.trim().length > 0 &&
  !/[^\x20-\x7e]/.test(value);

/** Validate a detached server descriptor; keep exact scope values, without choosing defaults. */
export function parseBrowserSessionContext(value: unknown): BrowserSessionContext | null {
  if (typeof value !== 'object' || value === null || Array.isArray(value)) return null;
  try {
    const prototype = Object.getPrototypeOf(value);
    if (prototype !== Object.prototype && prototype !== null) return null;
    const ownKeys = Reflect.ownKeys(value);
    if (
      ownKeys.length !== keys.length ||
      ownKeys.some((key) => typeof key !== 'string' || !keys.includes(key as (typeof keys)[number]))
    )
      return null;
    const descriptors = Object.getOwnPropertyDescriptors(value);
    if (keys.some((key) => !descriptors[key]?.enumerable || !('value' in descriptors[key]!)))
      return null;
    const sessionId: unknown = descriptors.sessionId!.value;
    const contextEpoch: unknown = descriptors.contextEpoch!.value;
    const coCode: unknown = descriptors.coCode!.value;
    const lcCode: unknown = descriptors.lcCode!.value;
    const coYear: unknown = descriptors.coYear!.value;
    if (
      typeof sessionId !== 'string' ||
      sessionId.length !== 36 ||
      !/^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/.test(sessionId)
    )
      return null;
    if (
      typeof contextEpoch !== 'string' ||
      contextEpoch.length === 0 ||
      contextEpoch[0] === '0' ||
      /[^0-9]/.test(contextEpoch) ||
      contextEpoch.length > maximumEpoch.length ||
      (contextEpoch.length === maximumEpoch.length && contextEpoch > maximumEpoch)
    )
      return null;
    if (
      !exactCode(coCode, 2) ||
      !exactCode(lcCode, 2) ||
      (coYear !== null && !exactCode(coYear, 9))
    )
      return null;
    return Object.freeze({ sessionId, contextEpoch, coCode, lcCode, coYear });
  } catch {
    return null;
  }
}
export function sameBrowserSessionContext(
  a: BrowserSessionContext | null,
  b: BrowserSessionContext | null,
): boolean {
  return a === b || (a !== null && b !== null && keys.every((key) => a[key] === b[key]));
}
export function pageContextHeaders(ticket: PageContextTicket): Record<string, string> {
  return ticket.context === null
    ? {}
    : {
        'x-session-context-id': ticket.context.sessionId,
        'x-session-context-epoch': ticket.context.contextEpoch,
      };
}

/** No browser globals, persistence, navigation or React ownership; each instance is one page. */
export function createPageContextGuard() {
  let state: PageContextState = Object.freeze({
    status: 'unbound',
    revision: 0,
    context: null,
    observed: null,
    reason: null,
    message: null,
  });
  const listeners = new Set<(state: PageContextState) => void>();
  const publish = (next: PageContextState) => {
    state = Object.freeze(next);
    for (const listener of [...listeners]) listener(state);
    return state;
  };
  const stale = (
    reason: PageContextReason,
    observed: BrowserSessionContext | null,
    message = staleMessage,
  ) =>
    state.status === 'stale'
      ? state
      : publish({
          status: 'stale',
          revision: state.revision + 1,
          context: state.context,
          observed,
          reason,
          message,
        });
  const assertCurrent = (ticket: PageContextTicket) => {
    if (state.status === 'stale')
      throw new PageContextError('context-stale', state.message ?? undefined);
    if (
      ticket.revision !== state.revision ||
      !sameBrowserSessionContext(ticket.context, state.context)
    ) {
      throw new PageContextError('context-response-obsolete');
    }
  };
  return {
    read: (): PageContextState => state,
    subscribe(listener: (state: PageContextState) => void) {
      listeners.add(listener);
      return () => {
        listeners.delete(listener);
      };
    },
    capture(): PageContextTicket {
      if (state.status === 'stale')
        throw new PageContextError('context-stale', state.message ?? undefined);
      return Object.freeze({ revision: state.revision, context: state.context });
    },
    assertCurrent,
    observe(value: unknown): PageContextState {
      if (state.status === 'stale') return state;
      const context = parseBrowserSessionContext(value);
      if (!context) return stale('invalid-context-response', null);
      if (state.status === 'unbound')
        return publish({
          status: 'ready',
          revision: state.revision + 1,
          context,
          observed: null,
          reason: null,
          message: null,
        });
      return sameBrowserSessionContext(state.context, context)
        ? state
        : stale('context-changed', context);
    },
    reject(ticket: PageContextTicket): never {
      assertCurrent(ticket);
      stale('server-context-stale', null);
      throw new PageContextError('context-stale', state.message ?? undefined);
    },
    /** An uncertain selection freezes this page without claiming a new server identity. */
    pauseForSelection(): void {
      stale('context-selection-unconfirmed', null, selectionMessage);
    },
    /** Only an explicit navigation/discard acknowledgement may reset the page; never refresh. */
    resetForNavigation(): PageContextState {
      return publish({
        status: 'unbound',
        revision: state.revision + 1,
        context: null,
        observed: null,
        reason: null,
        message: null,
      });
    },
  };
}
