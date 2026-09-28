import { createHash } from 'node:crypto';
import {
  composeSaleReturnIncomingLabour,
  copySaleReturnIncomingLabour,
  projectSaleReturnIncomingEditorText,
  reduceSaleReturnIncomingAggregate,
  SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS,
  SALE_RETURN_INCOMING_PROJECTION_VERSION,
  SALE_RETURN_BILL_PROJECTION_VERSION,
  SALE_RETURN_INCOMING_AGGREGATE_VERSION,
  SALE_RETURN_BILL_TAX_POLICY_VERSION,
  SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION,
  SALE_RETURN_INCOMING_LABOUR_VERSION,
  SALE_RETURN_INCOMING_LABOUR_COMPOSE_VERSION,
  type SaleReturnIncomingAggregateState,
  type SaleReturnIncomingLabourObservation,
} from '@datacare/core';
import type { Tx } from '@datacare/db';
import { BookPolicyValidationError } from '../shared/bookPolicy.js';
import {
  withSessionContextReadSnapshot,
  SESSION_CONTEXT_READ_SNAPSHOT_VERSION,
} from '../auth/sessionContextReadSnapshot.js';
import type { AuthenticatedSessionContext } from '../auth/sessionContextAccess.js';
import { SavedSaleReturnError, type SavedSaleReturnScope } from './savedSaleReturn.js';
import { SaleReturnIncomingConfigurationError } from './saleReturnIncomingConfiguration.js';
import {
  SaleReturnIncomingReplayError,
  type SaleReturnIncomingReplayCellSnapshot,
} from './saleReturnIncomingReplay.js';
import {
  observeSaleReturnBillReplayTx,
  SaleReturnBillReplayError,
  type SaleReturnBillReplayObservation,
  type SaleReturnBillReplayState,
  type SaleReturnBillReplayPhase,
} from './saleReturnBillReplay.js';
import {
  readSaleReturnIncomingLabourTx,
  SaleReturnIncomingLabourReadError,
} from './saleReturnIncomingLabour.js';

export const SALE_RETURN_LABOUR_REPLAY_CONTRACT =
  'x13-saved-incoming-labour-bill-replay-v1' as const;
export const SALE_RETURN_LABOUR_REPLAY_PROFILE =
  'saved-primary-incoming-resolved-labour-bill-preview-v1' as const;
const semanticVersions = Object.freeze({
  adapter: 'saved-labour-bill-server-adapter-v1',
  rowProjection: SALE_RETURN_INCOMING_PROJECTION_VERSION,
  billProjection: SALE_RETURN_BILL_PROJECTION_VERSION,
  aggregate: SALE_RETURN_INCOMING_AGGREGATE_VERSION,
  taxPolicy: SALE_RETURN_BILL_TAX_POLICY_VERSION,
  labourObservation: SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION,
  labourCopy: SALE_RETURN_INCOMING_LABOUR_VERSION,
  labourCompose: SALE_RETURN_INCOMING_LABOUR_COMPOSE_VERSION,
  sessionRead: SESSION_CONTEXT_READ_SNAPSHOT_VERSION,
});
export type SaleReturnLabourField = 'x13.primary-incoming.c13' | 'x13.primary-incoming.c29';
export type SaleReturnLabourReplayEvent =
  | { kind: 'moneyLeave'; fieldId: string; editorText: string }
  | {
      kind: 'labourEnter';
      fieldId: SaleReturnLabourField;
      editorText: string;
      observationVersion: string;
    };
export interface SaleReturnLabourPrefixInput {
  baseVersion: string;
  rowIdentity: string;
  prefixVersion: string;
  events: SaleReturnLabourReplayEvent[];
}
export type SaleReturnLabourObserveInput = SaleReturnLabourPrefixInput & {
  fieldId: SaleReturnLabourField;
  editorText: string;
};
export type SaleReturnLabourAppendInput = SaleReturnLabourPrefixInput & {
  event: SaleReturnLabourReplayEvent;
};
export interface SaleReturnLabourDiagnostic {
  code: string;
  message: string;
  fieldId?: string;
  stage?: string;
  column?: number;
}
export class SaleReturnLabourReplayError extends Error {
  constructor(
    readonly statusCode: 400 | 404 | 409 | 413 | 422 | 500,
    readonly code: string,
    message: string,
    readonly details?: {
      eventIndex?: number;
      event?: SaleReturnLabourReplayEvent;
      diagnostics?: readonly SaleReturnLabourDiagnostic[];
      recovery?: SaleReturnLabourPrefix;
    },
  ) {
    super(message);
    this.name = 'SaleReturnLabourReplayError';
    // Bound the actual route envelope, including a recovered prefix, not merely
    // its individual pieces. Never truncate a recovery into a different prefix.
    if (
      Buffer.byteLength(
        JSON.stringify({
          error: code,
          message,
          ...(details === undefined ? {} : { details }),
        }),
        'utf8',
      ) > 2097152
    ) {
      this.statusCode = 422;
      this.code = 'unsupported-output';
      this.message =
        'The complete preview error exceeds the response bound. Retain the local prefix and reload.';
      this.details = undefined;
    }
  }
}
interface Identity {
  contractVersion: typeof SALE_RETURN_LABOUR_REPLAY_CONTRACT;
  profile: typeof SALE_RETURN_LABOUR_REPLAY_PROFILE;
  context: {
    sessionId: string;
    contextEpoch: string;
    coCode: string;
    lcCode: string;
    coYear: string;
  };
  scope: Omit<SavedSaleReturnScope, 'tenantId'>;
  voucherNo: string;
  baseVersion: string;
  documentVersion: string;
  configurationVersion: string;
}
interface Field {
  fieldId: SaleReturnLabourField;
  allowed: boolean;
  reason: string | null;
  maxLength: 2;
  commit: 'resolved-enter';
}
const noAuthority = Object.freeze({
  canPreviewClosing: false,
  canSaveNumeric: false,
  canApplySource: false,
} as const);
export interface SaleReturnLabourReplayState extends Identity {
  billReplay: SaleReturnBillReplayState;
  semanticVersions: typeof semanticVersions;
  rows: Array<{
    rowIdentity: string;
    initialPrefixVersion: string;
    labourFields: Field[];
  }>;
  capabilities: { canPreview: boolean } & typeof noAuthority;
}
export interface SaleReturnLabourPrefix {
  prefixVersion: string;
  events: SaleReturnLabourReplayEvent[];
  preview: SaleReturnIncomingReplayCellSnapshot;
  phase: SaleReturnBillReplayPhase;
}
export interface SaleReturnLabourObservationResult extends Identity {
  rowIdentity: string;
  prefixVersion: string;
  fieldId: SaleReturnLabourField;
  editorText: string;
  observationVersion: string;
  selection: {
    CO_CODE: string;
    LBR_CODE: string;
    LBR_CATG: string;
    LBR_VAL: string;
  };
}
export interface SaleReturnLabourReplayResult extends Identity {
  rowIdentity: string;
  prefix: SaleReturnLabourPrefix;
  acceptedEvent: {
    event: SaleReturnLabourReplayEvent;
    status: 'applied' | 'skipped';
  };
  effects: {
    aggregateApplied: boolean;
    billApplied: boolean;
    taxRecalculated: boolean;
  };
  capabilities: typeof noAuthority;
}
const money = new Map<string, number>(
  SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS.map((c) => [`x13.primary-incoming.c${c}`, c] as const),
);
const labourFields: readonly SaleReturnLabourField[] = [
  'x13.primary-incoming.c13',
  'x13.primary-incoming.c29',
];
const prefixKeys = ['baseVersion', 'rowIdentity', 'prefixVersion', 'events'] as const;
const reject = (
  code: string,
  message: string,
  status: 400 | 404 | 409 | 413 | 422 | 500 = 400,
): never => {
  throw new SaleReturnLabourReplayError(status, code, message);
};
function own(value: unknown, keys: readonly string[]): Record<string, unknown> {
  if (!value || typeof value !== 'object' || Array.isArray(value))
    return reject('invalid-replay-request', 'Use an exact plain replay request.');
  const proto = Object.getPrototypeOf(value);
  const desc = Object.getOwnPropertyDescriptors(value),
    found = Reflect.ownKeys(value);
  if (
    (proto !== Object.prototype && proto !== null) ||
    found.length !== keys.length ||
    found.some((k) => typeof k !== 'string' || !keys.includes(k)) ||
    keys.some((k) => !desc[k]?.enumerable || !('value' in desc[k]!))
  )
    return reject(
      'invalid-replay-request',
      'Unknown, missing or accessor request fields are unsupported.',
    );
  return Object.fromEntries(keys.map((k) => [k, desc[k]!.value]));
}
const hashText = (v: unknown): v is string =>
  typeof v === 'string' && v.length === 64 && !/[^a-f0-9]/.test(v);
const ascii = (v: unknown, max: number): v is string =>
  typeof v === 'string' && v.length <= max && !/[^\x20-\x7e]/.test(v);
const code = (v: unknown): v is string => ascii(v, 2) && v.length > 0 && v.trim() === v;
function field(v: unknown): SaleReturnLabourField {
  if (typeof v !== 'string' || !labourFields.includes(v as SaleReturnLabourField))
    return reject('invalid-replay-request', 'Use a supported labour field.');
  return v as SaleReturnLabourField;
}
function event(value: unknown): SaleReturnLabourReplayEvent {
  // Inspect kind only through an own data descriptor; never invoke a getter to choose the schema.
  if (!value || typeof value !== 'object')
    return reject('invalid-replay-request', 'A committed event is required.');
  const d = Object.getOwnPropertyDescriptor(value, 'kind');
  if (!d || !('value' in d))
    return reject('invalid-replay-request', 'A plain event kind is required.');
  if (d.value === 'moneyLeave') {
    const r = own(value, ['kind', 'fieldId', 'editorText']);
    if (typeof r.fieldId !== 'string' || !money.has(r.fieldId) || !ascii(r.editorText, 10))
      return reject(
        'invalid-replay-request',
        'Use one supported money field and at most ten ASCII editor characters.',
      );
    return { kind: 'moneyLeave', fieldId: r.fieldId, editorText: r.editorText };
  }
  if (d.value === 'labourEnter') {
    const r = own(value, ['kind', 'fieldId', 'editorText', 'observationVersion']);
    if (!code(r.editorText) || !hashText(r.observationVersion))
      return reject(
        'invalid-replay-request',
        'A qualified exact one/two-character code and observation version are required.',
      );
    return {
      kind: 'labourEnter',
      fieldId: field(r.fieldId),
      editorText: r.editorText,
      observationVersion: r.observationVersion,
    };
  }
  return reject('invalid-replay-request', 'Unsupported committed event kind.');
}
function prefix(r: Record<string, unknown>): SaleReturnLabourPrefixInput {
  if (
    !hashText(r.baseVersion) ||
    !hashText(r.rowIdentity) ||
    !hashText(r.prefixVersion) ||
    !Array.isArray(r.events) ||
    Object.getPrototypeOf(r.events) !== Array.prototype ||
    r.events.length > 100 ||
    Object.keys(r.events).length !== r.events.length
  )
    return reject(
      'invalid-replay-request',
      'Exact versions, saved identity and a dense journal of at most100 events are required.',
    );
  const events: SaleReturnLabourReplayEvent[] = [];
  for (let i = 0; i < r.events.length; i++) {
    const d = Object.getOwnPropertyDescriptor(r.events, String(i));
    if (!d || !d.enumerable || !('value' in d))
      return reject('invalid-replay-request', 'Sparse or accessor events are unsupported.');
    events.push(event(d.value));
  }
  if (Reflect.ownKeys(r.events).length !== r.events.length + 1)
    return reject('invalid-replay-request', 'Extra event-array fields are unsupported.');
  return {
    baseVersion: r.baseVersion,
    rowIdentity: r.rowIdentity,
    prefixVersion: r.prefixVersion,
    events,
  };
}
function parsed<T>(fn: () => T): T {
  try {
    const r = fn();
    if (Buffer.byteLength(JSON.stringify(r), 'utf8') > 65536)
      return reject('invalid-replay-request', 'Replay request exceeds the transport bound.', 413);
    return r;
  } catch (e) {
    if (e instanceof SaleReturnLabourReplayError) throw e;
    return reject('invalid-replay-request', 'A plain replay request is required.');
  }
}
export const saleReturnLabourObserveInput = (value: unknown): SaleReturnLabourObserveInput =>
  parsed(() => {
    const r = own(value, [...prefixKeys, 'fieldId', 'editorText']);
    if (!code(r.editorText))
      return reject('invalid-replay-request', 'Enter an exact one/two-character ASCII code.');
    return {
      ...prefix(r),
      fieldId: field(r.fieldId),
      editorText: r.editorText,
    };
  });
export const saleReturnLabourAppendInput = (value: unknown): SaleReturnLabourAppendInput =>
  parsed(() => {
    const r = own(value, [...prefixKeys, 'event']);
    const p = prefix(r);
    if (p.events.length === 100)
      return reject(
        'invalid-replay-request',
        'Discard/reopen the preview after100 committed events.',
      );
    return { ...p, event: event(r.event) };
  });
function copyScope(value: SavedSaleReturnScope, voucherNo: string): SavedSaleReturnScope {
  return parsed(() => {
    const r = own(value, ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook']);
    for (const [key, max] of [
      ['tenantId', 24],
      ['coCode', 2],
      ['lcCode', 2],
      ['coYear', 9],
      ['coBook', 4],
    ] as const)
      if (!ascii(r[key], max) || !r[key] || (r[key] as string).trim() !== r[key])
        return reject('invalid-replay-request', 'A complete canonical Return scope is required.');
    if (
      typeof voucherNo !== 'string' ||
      voucherNo.length !== 5 ||
      !/^[0-9]{5}$/.test(voucherNo) ||
      voucherNo === '00000'
    )
      return reject(
        'invalid-replay-request',
        'Use the exact saved positive five-digit voucher key.',
      );
    return r as unknown as SavedSaleReturnScope;
  });
}
function canonical(v: unknown): string {
  if (Array.isArray(v)) return '[' + v.map(canonical).join(',') + ']';
  if (v && typeof v === 'object')
    return (
      '{' +
      Object.keys(v)
        .sort()
        .map((k) => JSON.stringify(k) + ':' + canonical((v as Record<string, unknown>)[k]))
        .join(',') +
      '}'
    );
  return JSON.stringify(v) ?? 'null';
}
const digest = (v: unknown) => createHash('sha256').update(canonical(v)).digest('hex');
function detached<T>(v: T): T {
  const text = JSON.stringify(v);
  if (Buffer.byteLength(text, 'utf8') > 2097152)
    return reject('unsupported-output', 'The preview exceeds the bounded response profile.', 422);
  const out: T = JSON.parse(text);
  const freeze = (x: unknown): void => {
    if (x && typeof x === 'object') {
      Object.values(x).forEach(freeze);
      Object.freeze(x);
    }
  };
  freeze(out);
  return out;
}
function prefixVersion(
  baseVersion: string,
  rowIdentity: string,
  events: readonly SaleReturnLabourReplayEvent[],
): string {
  const dependencies = new Map<string, string>();
  for (const e of events)
    if (e.kind === 'labourEnter') dependencies.set(e.editorText, e.observationVersion);
  return digest({
    baseVersion,
    rowIdentity,
    events,
    dependencies: [...dependencies]
      .sort(([a], [b]) => (a < b ? -1 : a > b ? 1 : 0))
      .map(([enteredCode, observationVersion]) => ({
        enteredCode,
        observationVersion,
      })),
  });
}
function identity(dto: SaleReturnLabourReplayState): Identity {
  const {
    contractVersion,
    profile,
    context,
    scope,
    voucherNo,
    baseVersion,
    documentVersion,
    configurationVersion,
  } = dto;
  return {
    contractVersion,
    profile,
    context,
    scope,
    voucherNo,
    baseVersion,
    documentVersion,
    configurationVersion,
  };
}
function snapshot(
  state: SaleReturnIncomingAggregateState,
  index: number,
): SaleReturnIncomingReplayCellSnapshot {
  const row = state.rows[index]!.state,
    editor = projectSaleReturnIncomingEditorText(row);
  if (editor.status !== 'ready')
    throw new SaleReturnLabourReplayError(
      422,
      'unsupported-editor',
      'The result cannot be represented in the supported editors.',
      { diagnostics: editor.diagnostics },
    );
  return {
    visible: Object.fromEntries(
      Object.entries(row.visible).filter((p): p is [string, string] => typeof p[1] === 'string'),
    ),
    caches: { ...row.caches },
    editorTextByField: { ...editor.editorTextByField },
  };
}
function currentPrefix(
  dto: SaleReturnLabourReplayState,
  state: SaleReturnIncomingAggregateState,
  index: number,
  events: SaleReturnLabourReplayEvent[],
): SaleReturnLabourPrefix {
  return {
    prefixVersion: prefixVersion(dto.baseVersion, state.rows[index]!.state.rowIdentity, events),
    events,
    preview: snapshot(state, index),
    phase: { incomingTotals: { ...state.totals.cells }, bill: state.bill },
  };
}
interface Observed {
  dto: SaleReturnLabourReplayState;
  bill: SaleReturnBillReplayObservation;
  masters: Map<string, SaleReturnIncomingLabourObservation>;
}
async function observe(
  tx: Tx,
  context: AuthenticatedSessionContext,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  input?: SaleReturnLabourPrefixInput,
  candidate?: string,
): Promise<Observed> {
  let baseVersion = '';
  const masters = new Map<string, SaleReturnIncomingLabourObservation>();
  const bill = await observeSaleReturnBillReplayTx(
    tx,
    scope,
    voucherNo,
    undefined,
    async (observed) => {
      baseVersion = digest({
        newContract: SALE_RETURN_LABOUR_REPLAY_CONTRACT,
        newProfile: SALE_RETURN_LABOUR_REPLAY_PROFILE,
        semanticVersions,
        scope,
        voucherNo,
        sessionBinding: context,
        billReplayVersion: observed.billReplayVersion,
      });
      if (input && baseVersion !== input.baseVersion)
        return reject(
          'version-conflict',
          'Saved Return or calculation inputs changed. Reload before previewing.',
          409,
        );
      const codes = new Set(
        input?.events.filter((e) => e.kind === 'labourEnter').map((e) => e.editorText) ?? [],
      );
      if (candidate !== undefined) codes.add(candidate);
      for (const enteredCode of [...codes].sort())
        masters.set(
          enteredCode,
          await readSaleReturnIncomingLabourTx(tx, {
            scope: { tenantId: scope.tenantId, coCode: scope.coCode },
            enteredCode,
          }),
        );
      for (const e of input?.events ?? [])
        if (
          e.kind === 'labourEnter' &&
          masters.get(e.editorText)!.observationVersion !== e.observationVersion
        )
          return reject(
            'master-version-conflict',
            'A previously selected labour master changed. Reload before another selection.',
            409,
          );
      if (
        input &&
        input.prefixVersion !== prefixVersion(baseVersion, input.rowIdentity, input.events)
      )
        return reject('prefix-conflict', 'The committed prefix does not match its version.', 409);
    },
  );
  if (!context.coYear) return reject('context-stale', 'The selected year is unavailable.', 409);
  const rows = bill.dto.rowReplay.rows.map((row) => ({
    rowIdentity: row.rowIdentity,
    initialPrefixVersion: prefixVersion(baseVersion, row.rowIdentity, []),
    labourFields: labourFields.map((fieldId): Field => {
      const col = bill.dto.rowReplay.configuration.columns.find((c) => c.id === fieldId);
      const reason = !bill.dto.capabilities.canPreviewBill
        ? 'This saved Return is outside the supported whole-grid bill preview.'
        : col?.widthState !== 'nonzero'
          ? 'The labour field is hidden or its configured width is unresolved.'
          : null;
      return {
        fieldId,
        allowed: reason === null,
        reason,
        maxLength: 2,
        commit: 'resolved-enter',
      };
    }),
  }));
  return {
    bill,
    masters,
    dto: {
      contractVersion: SALE_RETURN_LABOUR_REPLAY_CONTRACT,
      profile: SALE_RETURN_LABOUR_REPLAY_PROFILE,
      context: {
        sessionId: context.sessionId,
        contextEpoch: context.contextEpoch,
        coCode: context.coCode,
        lcCode: context.lcCode,
        coYear: context.coYear,
      },
      scope: { ...bill.dto.scope },
      voucherNo,
      baseVersion,
      documentVersion: bill.dto.documentVersion,
      configurationVersion: bill.dto.configurationVersion,
      billReplay: bill.dto,
      semanticVersions,
      rows,
      capabilities: {
        canPreview: bill.dto.capabilities.canPreviewBill,
        ...noAuthority,
      },
    },
  };
}
function supported(observed: Observed, input: SaleReturnLabourPrefixInput) {
  const { dto, bill } = observed;
  const index = bill.state?.rows.findIndex((r) => r.state.rowIdentity === input.rowIdentity) ?? -1;
  if (!dto.rows.some((r) => r.rowIdentity === input.rowIdentity))
    return reject('identity-conflict', 'The saved row identity is missing.', 409);
  if (
    !bill.state ||
    !bill.context ||
    !bill.dto.rowReplay.configuration.policy ||
    !dto.capabilities.canPreview
  )
    throw new SaleReturnLabourReplayError(
      422,
      'unsupported-state',
      'This saved Return is available for inspection only.',
      { diagnostics: bill.dto.diagnostics },
    );
  if (index < 0)
    return reject('identity-conflict', 'The projected saved row identity is missing.', 409);
  return {
    state: bill.state,
    context: bill.context,
    policy: bill.dto.rowReplay.configuration.policy,
    index,
  };
}
function checkField(
  observed: Observed,
  rowIdentity: string,
  e: SaleReturnLabourReplayEvent | { fieldId: SaleReturnLabourField },
): void {
  const row = observed.dto.billReplay.rowReplay.rows.find((r) => r.rowIdentity === rowIdentity)!;
  const cap = labourFields.includes(e.fieldId as SaleReturnLabourField)
    ? observed.dto.rows
        .find((r) => r.rowIdentity === rowIdentity)!
        .labourFields.find((f) => f.fieldId === e.fieldId)
    : row.fieldCapabilities.find((f) => f.fieldId === e.fieldId);
  if (!cap?.allowed)
    return reject(
      'unsupported-field',
      cap?.reason ?? 'This field has no supported preview action.',
      422,
    );
}
function apply(
  observed: Observed,
  state: SaleReturnIncomingAggregateState,
  index: number,
  e: SaleReturnLabourReplayEvent,
) {
  const rowIdentity = state.rows[index]!.state.rowIdentity;
  checkField(observed, rowIdentity, e);
  const context = observed.bill.context!,
    policy = observed.bill.dto.rowReplay.configuration.policy!;
  if (e.kind === 'labourEnter') {
    const observation = observed.masters.get(e.editorText)!;
    if (observation.observationVersion !== e.observationVersion)
      return reject(
        'master-version-conflict',
        'The checked labour code changed before commitment.',
        409,
      );
    const result = composeSaleReturnIncomingLabour({
      state,
      scope: {
        tenantId: observation.scope.tenantId,
        coCode: observation.scope.coCode,
      },
      rowIdentity,
      field: e.fieldId === 'x13.primary-incoming.c13' ? 13 : 29,
      editorText: e.editorText,
      expectedObservationVersion: e.observationVersion,
      observation,
      rowPolicy: policy,
      context,
    });
    if (result.status !== 'applied')
      throw new SaleReturnLabourReplayError(
        422,
        result.status === 'lookup-required'
          ? 'lookup-required'
          : result.diagnostics.some((d) => d.origin === 'calculation')
            ? 'calculation-rejected'
            : 'unsupported-master',
        result.diagnostics[0]?.message ?? 'The labour selection is unsupported.',
        { diagnostics: result.diagnostics },
      );
    return {
      state: result.state,
      status: 'applied' as const,
      effects: {
        aggregateApplied: result.aggregateApplied,
        billApplied: result.billApplied,
        taxRecalculated: result.taxRecalculated,
      },
    };
  }
  const configured = observed.bill.dto.rowReplay.configuration.columns.find(
    (c) => c.id === e.fieldId,
  )!;
  const result = reduceSaleReturnIncomingAggregate(
    state,
    {
      kind: 'leaveCell',
      rowIdentity,
      column: money.get(e.fieldId)!,
      text: e.editorText,
      context: {
        currentRow: index + 1,
        clearing: false,
        editorVisible: true,
        committedColumnWidth: configured.nominalWidth,
      },
    },
    policy,
    context,
  );
  if (result.status === 'rejected')
    throw new SaleReturnLabourReplayError(422, 'calculation-rejected', result.diagnostic.message, {
      diagnostics: [result.diagnostic],
    });
  return {
    state: result.state,
    status: result.status,
    effects: {
      aggregateApplied: result.status === 'applied' && result.aggregateApplied,
      billApplied: result.status === 'applied' && result.billApplied,
      taxRecalculated:
        result.status === 'applied' && (result.state.journal.at(-1)?.taxRecalculated ?? false),
    },
  };
}
function reconstruct(observed: Observed, input: SaleReturnLabourPrefixInput) {
  const initial = supported(observed, input);
  let state = initial.state;
  try {
    for (const e of input.events) {
      const next = apply(observed, state, initial.index, e);
      snapshot(next.state, initial.index);
      state = next.state;
    }
    const recovered = detached(currentPrefix(observed.dto, state, initial.index, input.events));
    if (recovered.prefixVersion !== input.prefixVersion)
      return reject('prefix-conflict', 'The committed prefix no longer matches.', 409);
    return { state, index: initial.index, recovered };
  } catch (error) {
    if (error instanceof SaleReturnLabourReplayError && error.statusCode === 422)
      return reject(
        'prefix-conflict',
        'A previously accepted operation cannot be reconstructed. Reload before previewing.',
        409,
      );
    throw error;
  }
}
async function boundary<T>(fn: () => Promise<T>): Promise<T> {
  try {
    return await fn();
  } catch (e) {
    if (
      e instanceof SavedSaleReturnError ||
      e instanceof SaleReturnIncomingReplayError ||
      e instanceof SaleReturnIncomingConfigurationError ||
      e instanceof SaleReturnBillReplayError
    )
      throw new SaleReturnLabourReplayError(e.statusCode, e.code, e.message);
    if (e instanceof BookPolicyValidationError)
      throw new SaleReturnLabourReplayError(422, 'configuration', e.message);
    if (e instanceof SaleReturnIncomingLabourReadError)
      throw new SaleReturnLabourReplayError(500, e.code, e.message);
    throw e;
  }
}
export async function getSaleReturnLabourReplayState(
  prisma: any,
  identityValue: unknown,
  suppliedScope: SavedSaleReturnScope,
  voucherNo: string,
): Promise<SaleReturnLabourReplayState> {
  const scope = copyScope(suppliedScope, voucherNo);
  return boundary(() =>
    withSessionContextReadSnapshot(
      prisma,
      identityValue,
      { form: 'Sales/Sales Return', scope },
      async (tx, admitted) => detached((await observe(tx, admitted.context, scope, voucherNo)).dto),
    ),
  );
}
export async function observeSaleReturnLabourReplayCode(
  prisma: any,
  identityValue: unknown,
  suppliedScope: SavedSaleReturnScope,
  voucherNo: string,
  value: unknown,
): Promise<SaleReturnLabourObservationResult> {
  const scope = copyScope(suppliedScope, voucherNo),
    input = saleReturnLabourObserveInput(value);
  return boundary(() =>
    withSessionContextReadSnapshot(
      prisma,
      identityValue,
      { form: 'Sales/Sales Return', scope },
      async (tx, admitted) => {
        const observed = await observe(
          tx,
          admitted.context,
          scope,
          voucherNo,
          input,
          input.editorText,
        );
        const prior = reconstruct(observed, input);
        checkField(observed, input.rowIdentity, input);
        const observation = observed.masters.get(input.editorText)!;
        const copied = copySaleReturnIncomingLabour({
          scope: { tenantId: scope.tenantId, coCode: scope.coCode },
          rowIdentity: input.rowIdentity,
          state: prior.state.rows[prior.index]!.state,
          field: input.fieldId === 'x13.primary-incoming.c13' ? 13 : 29,
          editorText: input.editorText,
          expectedObservationVersion: observation.observationVersion,
          observation,
        });
        if (copied.status !== 'ready')
          throw new SaleReturnLabourReplayError(
            422,
            copied.status === 'lookup-required' ? 'lookup-required' : 'unsupported-master',
            copied.diagnostics[0]?.message ?? 'The labour code is unsupported.',
            { diagnostics: copied.diagnostics },
          );
        const raw = observation.masters[0]!.raw;
        return detached({
          ...identity(observed.dto),
          rowIdentity: input.rowIdentity,
          prefixVersion: input.prefixVersion,
          fieldId: input.fieldId,
          editorText: input.editorText,
          observationVersion: observation.observationVersion,
          selection: {
            CO_CODE: raw.CO_CODE!,
            LBR_CODE: raw.LBR_CODE!,
            LBR_CATG: raw.LBR_CATG!,
            LBR_VAL: raw.LBR_VAL!,
          },
        });
      },
    ),
  );
}
export async function previewSaleReturnLabourReplay(
  prisma: any,
  identityValue: unknown,
  suppliedScope: SavedSaleReturnScope,
  voucherNo: string,
  value: unknown,
): Promise<SaleReturnLabourReplayResult> {
  const scope = copyScope(suppliedScope, voucherNo),
    input = saleReturnLabourAppendInput(value);
  return boundary(async () => {
    const outcome = await withSessionContextReadSnapshot(
      prisma,
      identityValue,
      { form: 'Sales/Sales Return', scope },
      async (tx, admitted) => {
        const observed = await observe(
          tx,
          admitted.context,
          scope,
          voucherNo,
          input,
          input.event.kind === 'labourEnter' ? input.event.editorText : undefined,
        );
        const prior = reconstruct(observed, input);
        try {
          const next = apply(observed, prior.state, prior.index, input.event);
          return detached({
            ...identity(observed.dto),
            rowIdentity: input.rowIdentity,
            prefix: currentPrefix(observed.dto, next.state, prior.index, [
              ...input.events,
              input.event,
            ]),
            acceptedEvent: { event: input.event, status: next.status },
            effects: next.effects,
            capabilities: noAuthority,
          });
        } catch (e) {
          if (e instanceof SaleReturnLabourReplayError && e.statusCode === 422)
            return {
              rejection: new SaleReturnLabourReplayError(422, e.code, e.message, {
                eventIndex: input.events.length,
                event: input.event,
                diagnostics: e.details?.diagnostics ?? [{ code: e.code, message: e.message }],
                recovery: prior.recovered,
              }),
            };
          throw e;
        }
      },
    );
    // Recovery is published only after the read coordinator's final live/context check.
    if ('rejection' in outcome) throw outcome.rejection;
    return outcome;
  });
}
