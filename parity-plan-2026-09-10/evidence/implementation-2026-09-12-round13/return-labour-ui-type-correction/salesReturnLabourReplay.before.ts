import { ApiError } from './api';
import {
  parseBrowserSessionContext,
  sameBrowserSessionContext,
  type BrowserSessionContext,
  type PageContextState,
} from './pageContext';
import {
  savedReturnQuery,
  type SavedIncomingReturn,
  type SavedReturnScope,
} from './salesReturnForm';
import {
  readReturnBillReplayState,
  type ReturnBillReplayState,
  type ReturnBillPhase,
} from './salesReturnBillReplay';
import {
  returnReplayBaseline,
  returnReplayFields,
  returnReplayFieldId,
  type ReturnReplaySnapshot,
} from './salesReturnReplay';

export const returnLabourReplayContract = 'x13-saved-incoming-labour-bill-replay-v1';
export const returnLabourReplayProfile = 'saved-primary-incoming-resolved-labour-bill-preview-v1';
export const returnLabourFields = ['x13.primary-incoming.c13', 'x13.primary-incoming.c29'] as const;
export type ReturnLabourField = (typeof returnLabourFields)[number];
export const returnLabourSemanticVersions = Object.freeze({
  adapter: 'saved-labour-bill-server-adapter-v1',
  rowProjection: 'saved-primary-incoming-projection-v1',
  billProjection: 'sale-return-bill-projection-v1',
  aggregate: 'primary-incoming-aggregate-decimal-v1',
  taxPolicy: 'sale-return-company-open-tax-policy-v1',
  labourObservation: 'incoming-labour-master-observation-v1',
  labourCopy: 'primary-incoming-labour-copy-v1',
  labourCompose: 'primary-incoming-labour-compose-v1',
  sessionRead: 'session-read-repeatable-snapshot-v1',
});
export type ReturnLabourEvent =
  | { kind: 'moneyLeave'; fieldId: string; editorText: string }
  | {
      kind: 'labourEnter';
      fieldId: ReturnLabourField;
      editorText: string;
      observationVersion: string;
    };
export type ReturnLabourPrefixInput = {
  baseVersion: string;
  rowIdentity: string;
  prefixVersion: string;
  events: ReturnLabourEvent[];
};
export type ReturnLabourObserveInput = ReturnLabourPrefixInput & {
  fieldId: ReturnLabourField;
  editorText: string;
};
export type ReturnLabourAppendInput = ReturnLabourPrefixInput & { event: ReturnLabourEvent };
type Identity = {
  contractVersion: typeof returnLabourReplayContract;
  profile: typeof returnLabourReplayProfile;
  context: BrowserSessionContext & { coYear: string };
  scope: SavedReturnScope;
  voucherNo: string;
  baseVersion: string;
  documentVersion: string;
  configurationVersion: string;
};
type NoAuthority = { canPreviewClosing: false; canSaveNumeric: false; canApplySource: false };
export type ReturnLabourRow = {
  rowIdentity: string;
  initialPrefixVersion: string;
  labourFields: Array<{
    fieldId: ReturnLabourField;
    allowed: boolean;
    reason: string | null;
    maxLength: 2;
    commit: 'resolved-enter';
  }>;
};
export type ReturnLabourReplayState = Identity & {
  billReplay: ReturnBillReplayState;
  semanticVersions: typeof returnLabourSemanticVersions;
  rows: ReturnLabourRow[];
  capabilities: NoAuthority & { canPreview: boolean };
};
export type ReturnLabourPrefix = {
  prefixVersion: string;
  events: ReturnLabourEvent[];
  preview: ReturnReplaySnapshot;
  phase: ReturnBillPhase;
};
export type ReturnLabourObservation = Identity & {
  rowIdentity: string;
  prefixVersion: string;
  fieldId: ReturnLabourField;
  editorText: string;
  observationVersion: string;
  selection: { CO_CODE: string; LBR_CODE: string; LBR_CATG: string; LBR_VAL: string };
};
export type ReturnLabourReplayResult = Identity & {
  rowIdentity: string;
  prefix: ReturnLabourPrefix;
  acceptedEvent: { event: ReturnLabourEvent; status: 'applied' | 'skipped' };
  effects: { aggregateApplied: boolean; billApplied: boolean; taxRecalculated: boolean };
  capabilities: NoAuthority;
};
const identityKeys = [
  'contractVersion',
  'profile',
  'context',
  'scope',
  'voucherNo',
  'baseVersion',
  'documentVersion',
  'configurationVersion',
];
const noAuthorityKeys = ['canPreviewClosing', 'canSaveNumeric', 'canApplySource'];
const cacheKeys = ['45', '46', '47', '48', '49', '58', '66', '67'];
const columns = Array.from({ length: 71 }, (_, i) => String(i));
const moneyFields = returnReplayFields.map(returnReplayFieldId);
function fail(
  message = 'The labour preview response does not match this saved return and accepted history. Reload the saved return.',
): never {
  throw new Error(message);
}
function record(v: unknown): v is Record<string, unknown> {
  return v !== null && typeof v === 'object' && !Array.isArray(v);
}
function keys(v: unknown, expected: readonly string[]): v is Record<string, unknown> {
  return (
    record(v) &&
    Object.keys(v).length === expected.length &&
    expected.every((k) => Object.hasOwn(v, k))
  );
}
const hash = (v: unknown): v is string =>
  typeof v === 'string' && v.length === 64 && !/[^a-f0-9]/.test(v);
const ascii = (v: unknown, max: number): v is string =>
  typeof v === 'string' && v.length <= max && !/[^\x20-\x7e]/.test(v);
const code = (v: unknown): v is string => ascii(v, 2) && v.length > 0 && v.trim() === v;
export function sameReturnLabourValue(a: unknown, b: unknown): boolean {
  if (a === b) return true;
  if (Array.isArray(a))
    return (
      Array.isArray(b) && a.length === b.length && a.every((v, i) => sameReturnLabourValue(v, b[i]))
    );
  if (!record(a) || !keys(b, Object.keys(a))) return false;
  return Object.keys(a).every((k) => sameReturnLabourValue(a[k], b[k]));
}
/** Detach exact plain JSON data before any legacy reader can inspect it. Never invokes accessors. */
function plain(value: unknown, maximum = 2097152): any {
  let nodes = 0;
  const visit = (v: unknown, depth: number): unknown => {
    if (++nodes > 150000 || depth > 40) fail();
    if (v === null || typeof v === 'string' || typeof v === 'boolean') return v;
    if (typeof v === 'number' && Number.isFinite(v)) return v;
    if (typeof v !== 'object' || v === null) fail();
    const proto = Object.getPrototypeOf(v),
      descriptors = Object.getOwnPropertyDescriptors(v),
      own = Reflect.ownKeys(v);
    if (Array.isArray(v)) {
      if (proto !== Array.prototype || own.length !== v.length + 1) fail();
      const out: unknown[] = [];
      for (let i = 0; i < v.length; i++) {
        const d = descriptors[String(i)];
        if (!d?.enumerable || !('value' in d)) fail();
        out.push(visit(d.value, depth + 1));
      }
      return out;
    }
    if (proto !== Object.prototype && proto !== null) fail();
    const out: Record<string, unknown> = Object.create(null);
    for (const k of own) {
      if (typeof k !== 'string') fail();
      const d = descriptors[k];
      if (!d?.enumerable || !('value' in d)) fail();
      out[k] = visit(d.value, depth + 1);
    }
    return out;
  };
  try {
    const out = visit(value, 0);
    if (new TextEncoder().encode(JSON.stringify(out)).length > maximum) fail();
    return out;
  } catch (error) {
    if (error instanceof Error && error.message.startsWith('The labour preview')) throw error;
    return fail();
  }
}
function textMap(v: unknown, expected: readonly string[]): boolean {
  return keys(v, expected) && Object.values(v).every((x) => typeof x === 'string');
}
function snapshot(v: unknown): v is ReturnReplaySnapshot {
  return (
    keys(v, ['visible', 'caches', 'editorTextByField']) &&
    textMap(
      v.visible,
      columns.filter((k) => !cacheKeys.includes(k)),
    ) &&
    textMap(v.caches, cacheKeys) &&
    textMap(v.editorTextByField, moneyFields)
  );
}
function phase(v: unknown): v is ReturnBillPhase {
  if (
    !keys(v, ['incomingTotals', 'bill']) ||
    !textMap(v.incomingTotals, columns) ||
    !keys(v.bill, [
      'matrix',
      'oldNetAmt',
      'oldTaxPrc',
      'outgoingRounded',
      'incomingRounded',
      'closing',
    ])
  )
    return false;
  const b = v.bill;
  return (
    ['oldNetAmt', 'oldTaxPrc', 'outgoingRounded', 'incomingRounded'].every(
      (k) => typeof b[k] === 'string',
    ) &&
    Array.isArray(b.matrix) &&
    b.matrix.length === 9 &&
    b.matrix.every(
      (r) => Array.isArray(r) && r.length === 6 && r.every((c) => typeof c === 'string'),
    ) &&
    keys(b.closing, ['status', 'amount', 'label', 'color', 'reason']) &&
    b.closing.status === 'unavailable' &&
    b.closing.amount === null &&
    b.closing.label === null &&
    typeof b.closing.color === 'string' &&
    typeof b.closing.reason === 'string' &&
    b.closing.reason.trim().length > 0
  );
}
function noAuthority(v: unknown, extra: readonly string[] = []): boolean {
  return keys(v, [...noAuthorityKeys, ...extra]) && noAuthorityKeys.every((k) => v[k] === false);
}
function identity(
  v: Record<string, unknown>,
  expected: Pick<Identity, 'context' | 'scope' | 'voucherNo' | 'documentVersion'> &
    Partial<Identity>,
): void {
  if (
    v.contractVersion !== returnLabourReplayContract ||
    v.profile !== returnLabourReplayProfile ||
    !sameBrowserSessionContext(parseBrowserSessionContext(v.context), expected.context) ||
    !sameReturnLabourValue(v.scope, expected.scope) ||
    v.voucherNo !== expected.voucherNo ||
    v.documentVersion !== expected.documentVersion ||
    !['baseVersion', 'documentVersion', 'configurationVersion'].every((k) => hash(v[k])) ||
    (expected.baseVersion !== undefined && v.baseVersion !== expected.baseVersion) ||
    (expected.configurationVersion !== undefined &&
      v.configurationVersion !== expected.configurationVersion)
  )
    fail();
}
export function requireReturnLabourPage(
  page: PageContextState,
  document: SavedIncomingReturn,
): BrowserSessionContext & { coYear: string } {
  const c = page.context;
  if (
    page.status !== 'ready' ||
    !c ||
    !c.coYear ||
    c.coCode !== document.scope.coCode ||
    c.lcCode !== document.scope.lcCode ||
    c.coYear !== document.scope.coYear
  )
    fail(page.message ?? 'Reload the page session before opening this preview.');
  return c as BrowserSessionContext & { coYear: string };
}
export function returnLabourReplayPath(
  document: Pick<SavedIncomingReturn, 'scope' | 'voucherNo'>,
  action: 'state' | 'observe' | 'append' = 'state',
): string {
  if (document.voucherNo.length !== 5 || !/^(?!00000)[0-9]{5}$/.test(document.voucherNo))
    fail('Labour preview requires an exact five-digit saved voucher.');
  const suffix = {
    state: 'incoming-labour-replay-state',
    observe: 'incoming-labour-observation',
    append: 'incoming-labour-replay',
  }[action];
  return `/sales-returns/${document.voucherNo}/${suffix}?${savedReturnQuery(document.scope)}`;
}
export function readReturnLabourReplayState(
  value: unknown,
  document: SavedIncomingReturn,
  context: BrowserSessionContext & { coYear: string },
): ReturnLabourReplayState {
  const v = plain(value);
  if (!keys(v, [...identityKeys, 'billReplay', 'semanticVersions', 'rows', 'capabilities'])) fail();
  identity(v, {
    context,
    scope: document.scope,
    voucherNo: document.voucherNo,
    documentVersion: document.version,
  });
  const bill = readReturnBillReplayState(v.billReplay, document);
  if (
    v.configurationVersion !== bill.configurationVersion ||
    !sameReturnLabourValue(v.semanticVersions, returnLabourSemanticVersions) ||
    !Array.isArray(v.rows) ||
    v.rows.length !== bill.rowReplay.rows.length ||
    !noAuthority(v.capabilities, ['canPreview']) ||
    typeof v.capabilities.canPreview !== 'boolean' ||
    v.capabilities.canPreview !== bill.capabilities.canPreviewBill
  )
    fail();
  v.rows.forEach((r: unknown, i: number) => {
    if (
      !keys(r, ['rowIdentity', 'initialPrefixVersion', 'labourFields']) ||
      r.rowIdentity !== bill.rowReplay.rows[i]?.rowIdentity ||
      !hash(r.initialPrefixVersion) ||
      !Array.isArray(r.labourFields) ||
      r.labourFields.length !== 2
    )
      fail();
    r.labourFields.forEach((f: unknown, j: number) => {
      if (
        !keys(f, ['fieldId', 'allowed', 'reason', 'maxLength', 'commit']) ||
        f.fieldId !== returnLabourFields[j] ||
        typeof f.allowed !== 'boolean' ||
        !(f.reason === null || typeof f.reason === 'string') ||
        f.maxLength !== 2 ||
        f.commit !== 'resolved-enter' ||
        (f.allowed &&
          (f.reason !== null ||
            !bill.capabilities.canPreviewBill ||
            bill.rowReplay.configuration.columns.find((c) => c.id === f.fieldId)?.widthState !==
              'nonzero')) ||
        (!f.allowed && (typeof f.reason !== 'string' || !f.reason.trim()))
      )
        fail();
    });
  });
  return v as ReturnLabourReplayState;
}
export function returnLabourInitialPrefix(
  state: ReturnLabourReplayState,
  rowIdentity: string,
): ReturnLabourPrefix | null {
  const row = state.billReplay.rowReplay.rows.find((r) => r.rowIdentity === rowIdentity),
    meta = state.rows.find((r) => r.rowIdentity === rowIdentity),
    baseline = row && returnReplayBaseline(row);
  return baseline && meta && state.billReplay.phases.opened
    ? {
        prefixVersion: meta.initialPrefixVersion,
        events: [],
        preview: plain(baseline),
        phase: plain(state.billReplay.phases.opened),
      }
    : null;
}
function readEvent(v: unknown): ReturnLabourEvent {
  if (
    record(v) &&
    v.kind === 'moneyLeave' &&
    keys(v, ['kind', 'fieldId', 'editorText']) &&
    moneyFields.includes(String(v.fieldId)) &&
    ascii(v.editorText, 10)
  )
    return v as ReturnLabourEvent;
  if (
    record(v) &&
    v.kind === 'labourEnter' &&
    keys(v, ['kind', 'fieldId', 'editorText', 'observationVersion']) &&
    returnLabourFields.includes(v.fieldId as ReturnLabourField) &&
    code(v.editorText) &&
    hash(v.observationVersion)
  )
    return v as ReturnLabourEvent;
  return fail('Use a supported field and its exact bounded editor text.');
}
function validatePrefix(p: unknown): asserts p is ReturnLabourPrefix {
  if (
    !keys(p, ['prefixVersion', 'events', 'preview', 'phase']) ||
    !hash(p.prefixVersion) ||
    !Array.isArray(p.events) ||
    p.events.length > 100 ||
    !snapshot(p.preview) ||
    !phase(p.phase)
  )
    fail();
  p.events.forEach(readEvent);
}
function requestBase(
  state: ReturnLabourReplayState,
  rowIdentity: string,
  prefix: ReturnLabourPrefix,
): ReturnLabourPrefixInput {
  validatePrefix(plain(prefix));
  if (
    !state.capabilities.canPreview ||
    !state.rows.some((r) => r.rowIdentity === rowIdentity) ||
    !returnLabourInitialPrefix(state, rowIdentity) ||
    prefix.events.length >= 100
  )
    fail('This saved row cannot accept another preview change. Discard and reload the preview.');
  if (
    prefix.events.length === 0 &&
    !sameReturnLabourValue(prefix, returnLabourInitialPrefix(state, rowIdentity))
  )
    fail();
  return {
    baseVersion: state.baseVersion,
    rowIdentity,
    prefixVersion: prefix.prefixVersion,
    events: plain(prefix.events),
  };
}
function checkField(state: ReturnLabourReplayState, rowIdentity: string, fieldId: string): void {
  const allowed = returnLabourFields.includes(fieldId as ReturnLabourField)
    ? state.rows
        .find((r) => r.rowIdentity === rowIdentity)
        ?.labourFields.find((f) => f.fieldId === fieldId)?.allowed
    : state.billReplay.rowReplay.rows
        .find((r) => r.rowIdentity === rowIdentity)
        ?.fieldCapabilities.find((f) => f.fieldId === fieldId)?.allowed;
  if (!state.capabilities.canPreview || !allowed)
    fail('This saved field is available for inspection only.');
}
export function returnLabourObserveRequest(
  state: ReturnLabourReplayState,
  rowIdentity: string,
  prefix: ReturnLabourPrefix,
  fieldId: string,
  editorText: string,
): ReturnLabourObserveInput {
  checkField(state, rowIdentity, fieldId);
  if (!returnLabourFields.includes(fieldId as ReturnLabourField) || !code(editorText))
    fail(
      'Enter an exact labour code of one or two ordinary characters, without surrounding spaces.',
    );
  return plain({ ...requestBase(state, rowIdentity, prefix), fieldId, editorText }, 65536);
}
export function returnLabourAppendRequest(
  state: ReturnLabourReplayState,
  rowIdentity: string,
  prefix: ReturnLabourPrefix,
  event: ReturnLabourEvent,
): ReturnLabourAppendInput {
  const next = readEvent(plain(event));
  checkField(state, rowIdentity, next.fieldId);
  if (
    next.kind === 'moneyLeave' &&
    next.editorText.trim() !== '' &&
    !/^[ ]*[+-]?(?:\d+(?:\.\d*)?|\.\d+)[ ]*$/.test(next.editorText)
  )
    fail('Enter a plain decimal with at most 10 characters. Your entry is retained.');
  return plain({ ...requestBase(state, rowIdentity, prefix), event: next }, 65536);
}
export function readReturnLabourObservation(
  value: unknown,
  state: ReturnLabourReplayState,
  request: ReturnLabourObserveInput,
): ReturnLabourObservation {
  const v = plain(value);
  if (
    !keys(v, [
      ...identityKeys,
      'rowIdentity',
      'prefixVersion',
      'fieldId',
      'editorText',
      'observationVersion',
      'selection',
    ])
  )
    fail();
  identity(v, state);
  if (
    request.baseVersion !== state.baseVersion ||
    v.rowIdentity !== request.rowIdentity ||
    v.prefixVersion !== request.prefixVersion ||
    v.fieldId !== request.fieldId ||
    v.editorText !== request.editorText ||
    !hash(v.observationVersion) ||
    !keys(v.selection, ['CO_CODE', 'LBR_CODE', 'LBR_CATG', 'LBR_VAL']) ||
    !Object.values(v.selection).every((x) => typeof x === 'string') ||
    v.selection.CO_CODE !== state.scope.coCode ||
    v.selection.LBR_CODE !== request.editorText
  )
    fail();
  return v as ReturnLabourObservation;
}
export function readReturnLabourReplayResult(
  value: unknown,
  state: ReturnLabourReplayState,
  request: ReturnLabourAppendInput,
): ReturnLabourReplayResult {
  const v = plain(value);
  if (
    !keys(v, [...identityKeys, 'rowIdentity', 'prefix', 'acceptedEvent', 'effects', 'capabilities'])
  )
    fail();
  identity(v, state);
  validatePrefix(v.prefix);
  if (
    request.baseVersion !== state.baseVersion ||
    v.rowIdentity !== request.rowIdentity ||
    v.prefix.prefixVersion === request.prefixVersion ||
    !sameReturnLabourValue(v.prefix.events, [...request.events, request.event]) ||
    !keys(v.acceptedEvent, ['event', 'status']) ||
    !sameReturnLabourValue(v.acceptedEvent.event, request.event) ||
    !['applied', 'skipped'].includes(String(v.acceptedEvent.status)) ||
    !keys(v.effects, ['aggregateApplied', 'billApplied', 'taxRecalculated']) ||
    !Object.values(v.effects).every((x) => typeof x === 'boolean') ||
    !noAuthority(v.capabilities) ||
    (request.event.kind === 'labourEnter' &&
      (v.acceptedEvent.status !== 'applied' || v.effects.billApplied !== true))
  )
    fail();
  return v as ReturnLabourReplayResult;
}
/** Recovery only confirms the already accepted exact prefix. It never replaces or truncates it. */
export function validateReturnLabourRecovery(
  error: unknown,
  request: ReturnLabourAppendInput,
  prefix: ReturnLabourPrefix,
): void {
  if (!(error instanceof ApiError) || error.status !== 422 || error.body?.details === undefined)
    return;
  const details = plain(error.body.details);
  if (
    !keys(details, ['eventIndex', 'event', 'diagnostics', 'recovery']) ||
    details.eventIndex !== request.events.length ||
    !sameReturnLabourValue(details.event, request.event) ||
    !Array.isArray(details.diagnostics)
  )
    fail();
  validatePrefix(details.recovery);
  if (!sameReturnLabourValue(details.recovery, prefix)) fail();
}
export function returnLabourFailure(error: unknown, reading = false) {
  const status = error instanceof ApiError ? error.status : undefined;
  const omittedRecovery =
    error instanceof ApiError &&
    error.status === 422 &&
    error.body?.error === 'unsupported-output' &&
    error.body?.details?.recovery === undefined;
  return {
    needsReload:
      reading ||
      omittedRecovery ||
      (status !== undefined && ([401, 403, 404, 409].includes(status) || status >= 500)),
    conflict: status === 409,
    message:
      error instanceof ApiError
        ? String(error.body?.message || error.message)
        : error instanceof Error
          ? error.message
          : 'The preview request failed. Your entry is retained.',
  };
}
/** Local generation fences ABA, draft edits and teardown; it does not cancel server work. */
export class ReturnLabourReplayLease {
  private identity = '';
  private revision = 0;
  private request = 0;
  observe(identity: string): void {
    if (identity !== this.identity) {
      this.identity = identity;
      this.invalidate();
    }
  }
  invalidate(): void {
    this.revision++;
    this.request++;
  }
  begin() {
    return { identity: this.identity, revision: this.revision, request: ++this.request };
  }
  current(ticket: { identity: string; revision: number; request: number }): boolean {
    return (
      ticket.identity === this.identity &&
      ticket.revision === this.revision &&
      ticket.request === this.request
    );
  }
}
