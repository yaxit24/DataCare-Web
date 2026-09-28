import type { SaleReturnBillState, SaleReturnBillTaxPolicyResult } from '@datacare/core';
import {
  savedReturnQuery,
  type SavedIncomingReturn,
  type SavedReturnRaw,
  type SavedReturnScope,
} from './salesReturnForm';
import {
  readReturnReplayState,
  returnReplayBaseline,
  returnReplayFieldId,
  returnReplayFields,
  returnReplayRequest,
  type ReturnReplayDiagnostic,
  type ReturnReplayEvent,
  type ReturnReplayRequest,
  type ReturnReplayRow,
  type ReturnReplaySnapshot,
  type ReturnReplayState,
} from './salesReturnReplay';

export const returnBillReplayContract = 'x13-saved-incoming-bill-replay-v1';
export const returnBillTotalColumns = [
  9, 10, 11, 12, 15, 18, 20, 24, 27, 42, 28, 36, 38, 35,
] as const;
export type ReturnBillPhase = { incomingTotals: Record<string, string>; bill: SaleReturnBillState };
type ReturnBillIdentity = {
  contractVersion: typeof returnBillReplayContract;
  scope: SavedReturnScope;
  voucherNo: string;
  replayVersion: string;
  documentVersion: string;
  configurationVersion: string;
};
export type ReturnBillReplayState = ReturnBillIdentity & {
  profile: 'saved-primary-incoming-bill-preview-v1';
  rowReplay: ReturnReplayState;
  savedHeader: SavedReturnRaw;
  taxPolicy: SaleReturnBillTaxPolicyResult;
  headerProjectionVersion: 'sale-return-bill-projection-v1';
  phases: { loaded: ReturnBillPhase | null; opened: ReturnBillPhase | null };
  diagnostics: ReturnReplayDiagnostic[];
  capabilities: { canPreviewBill: boolean; canPreviewClosing: false; canSaveNumeric: false };
};
export type ReturnBillReplayResult = ReturnBillIdentity & {
  rowIdentity: string;
  baseline: ReturnReplaySnapshot;
  preview: ReturnReplaySnapshot;
  phases: { loaded: ReturnBillPhase; opened: ReturnBillPhase; preview: ReturnBillPhase };
  events: Array<ReturnReplayEvent & { status: 'applied' | 'skipped' }>;
  capabilities: { canPreviewClosing: false; canSaveNumeric: false };
};

function record(value: unknown): value is Record<string, unknown> {
  if (value === null || typeof value !== 'object' || Array.isArray(value)) return false;
  const prototype = Object.getPrototypeOf(value);
  return prototype === Object.prototype || prototype === null;
}
function exactKeys(value: Record<string, unknown>, keys: readonly string[]): boolean {
  return (
    Object.keys(value).length === keys.length && keys.every((key) => Object.hasOwn(value, key))
  );
}
function textMap(value: unknown, keys: readonly string[]): value is Record<string, string> {
  return (
    record(value) &&
    exactKeys(value, keys) &&
    Object.values(value).every((cell) => typeof cell === 'string')
  );
}
function diagnosticList(value: unknown): boolean {
  return (
    Array.isArray(value) &&
    value.every(
      (d) =>
        record(d) &&
        typeof d.code === 'string' &&
        typeof d.message === 'string' &&
        (d.fieldId === undefined || typeof d.fieldId === 'string'),
    )
  );
}
/** Structural equality preserves blanks, raw NULL, exact decimals and source labels. */
function equal(a: unknown, b: unknown): boolean {
  if (a === b) return true;
  if (Array.isArray(a))
    return Array.isArray(b) && a.length === b.length && a.every((v, i) => equal(v, b[i]));
  if (!record(a) || !record(b) || !exactKeys(b, Object.keys(a))) return false;
  return Object.keys(a).every((key) => equal(a[key], b[key]));
}
function fail(): never {
  throw new Error(
    'The totals and bill observation is incomplete or does not match this saved return. Reload the saved return.',
  );
}
const cacheKeys = ['45', '46', '47', '48', '49', '58', '66', '67'];
const allColumns = Array.from({ length: 71 }, (_, i) => String(i));
function snapshot(value: unknown): value is ReturnReplaySnapshot {
  return (
    record(value) &&
    exactKeys(value, ['visible', 'caches', 'editorTextByField']) &&
    textMap(
      value.visible,
      allColumns.filter((key) => !cacheKeys.includes(key)),
    ) &&
    textMap(value.caches, cacheKeys) &&
    textMap(value.editorTextByField, returnReplayFields.map(returnReplayFieldId))
  );
}
function phase(value: unknown): value is ReturnBillPhase {
  if (
    !record(value) ||
    !exactKeys(value, ['incomingTotals', 'bill']) ||
    !textMap(value.incomingTotals, allColumns) ||
    !record(value.bill)
  )
    return false;
  const bill = value.bill;
  if (
    !exactKeys(bill, [
      'matrix',
      'oldNetAmt',
      'oldTaxPrc',
      'outgoingRounded',
      'incomingRounded',
      'closing',
    ]) ||
    !['oldNetAmt', 'oldTaxPrc', 'outgoingRounded', 'incomingRounded'].every(
      (key) => typeof bill[key] === 'string',
    ) ||
    !Array.isArray(bill.matrix) ||
    bill.matrix.length !== 9 ||
    !bill.matrix.every(
      (row) =>
        Array.isArray(row) && row.length === 6 && row.every((cell) => typeof cell === 'string'),
    )
  )
    return false;
  const closing = bill.closing;
  return (
    record(closing) &&
    exactKeys(closing, ['status', 'amount', 'label', 'color', 'reason']) &&
    closing.status === 'unavailable' &&
    closing.amount === null &&
    closing.label === null &&
    typeof closing.color === 'string' &&
    typeof closing.reason === 'string' &&
    closing.reason.trim().length > 0
  );
}
const taxVersion = 'sale-return-company-open-tax-policy-v1';
const taxRawKeys = ['CO_SET.TAX_ROF', 'CO_SET.ALL_ROF_REMOVE'];
/** Validate the published policy result, without resolving settings or calculating tax in the browser. */
function taxPolicy(value: unknown): value is SaleReturnBillTaxPolicyResult {
  if (
    !record(value) ||
    !exactKeys(value, [
      'version',
      'profile',
      'raw',
      'provenance',
      'status',
      'policy',
      'diagnostics',
    ]) ||
    value.version !== taxVersion ||
    value.profile !== 'sql-int32-text-and-null-v1' ||
    !Array.isArray(value.provenance) ||
    !Array.isArray(value.diagnostics)
  )
    return false;
  if (
    value.raw !== null &&
    (!record(value.raw) ||
      !exactKeys(value.raw, taxRawKeys) ||
      !Object.values(value.raw).every((cell) => cell === null || typeof cell === 'string'))
  )
    return false;
  const stages = [
    'int32-conversion',
    'greater-than-five-fallback',
    'all-rounding-flag',
    'all-rounding-override',
  ];
  if (
    value.provenance.length > 4 ||
    !value.provenance.every((step, index) => {
      if (!record(step) || step.stage !== stages[index]) return false;
      if (index === 0)
        return (
          exactKeys(step, ['stage', 'inputKind', 'value']) &&
          ['sql-null-via-fnv', 'canonical-sql-int32-text'].includes(String(step.inputKind)) &&
          typeof step.value === 'string'
        );
      if (index === 2)
        return (
          exactKeys(step, ['stage', 'inputKind', 'value']) &&
          ['blank-default', 'canonical-flag'].includes(String(step.inputKind)) &&
          ['N', 'Y'].includes(String(step.value))
        );
      return (
        exactKeys(step, ['stage', 'applied', 'before', 'after']) &&
        typeof step.applied === 'boolean' &&
        typeof step.before === 'string' &&
        typeof step.after === 'string'
      );
    })
  )
    return false;
  if (value.status === 'ready')
    return (
      value.raw !== null &&
      value.provenance.length === 4 &&
      value.diagnostics.length === 0 &&
      record(value.policy) &&
      exactKeys(value.policy, ['version', 'taxRoundingDecimals']) &&
      value.policy.version === taxVersion &&
      typeof value.policy.taxRoundingDecimals === 'number' &&
      Number.isInteger(value.policy.taxRoundingDecimals) &&
      value.policy.taxRoundingDecimals >= 0 &&
      value.policy.taxRoundingDecimals <= 5
    );
  return (
    value.status === 'unsupported' &&
    value.policy === null &&
    value.diagnostics.length > 0 &&
    value.diagnostics.every(
      (d) =>
        record(d) &&
        [
          'invalid-tax-policy-input',
          'unsupported-tax-precision-text',
          'tax-precision-int32-overflow',
          'unsupported-all-rounding-flag',
          'negative-tax-precision',
        ].includes(String(d.code)) &&
        typeof d.message === 'string' &&
        (d.key === undefined || taxRawKeys.includes(String(d.key))),
    )
  );
}
function identity(
  value: unknown,
  expected: Omit<ReturnBillIdentity, 'contractVersion' | 'replayVersion'>,
): value is ReturnBillIdentity & Record<string, unknown> {
  return (
    record(value) &&
    value.contractVersion === returnBillReplayContract &&
    equal(value.scope, expected.scope) &&
    value.voucherNo === expected.voucherNo &&
    value.documentVersion === expected.documentVersion &&
    value.configurationVersion === expected.configurationVersion &&
    ['replayVersion', 'documentVersion', 'configurationVersion'].every(
      (key) =>
        typeof value[key] === 'string' &&
        /^[a-f0-9]{64}$/.test(value[key] as string) &&
        (value[key] as string).length === 64,
    )
  );
}
export function returnBillReplayPath(
  document: Pick<SavedIncomingReturn, 'scope' | 'voucherNo'>,
  action: 'state' | 'preview' = 'state',
): string {
  if (document.voucherNo.length !== 5 || !/^(?!00000)\d{5}$/.test(document.voucherNo))
    throw new Error('Totals and bill preview requires an exact five-digit saved return voucher.');
  return `/sales-returns/${document.voucherNo}/incoming-bill-replay${action === 'state' ? '-state' : ''}?${savedReturnQuery(document.scope)}`;
}
export function readReturnBillReplayState(
  value: unknown,
  document: SavedIncomingReturn,
): ReturnBillReplayState {
  if (!record(value)) fail();
  const rowReplay = readReturnReplayState(value.rowReplay, document);
  if (
    !identity(value, rowReplay) ||
    value.profile !== 'saved-primary-incoming-bill-preview-v1' ||
    value.headerProjectionVersion !== 'sale-return-bill-projection-v1' ||
    !equal(value.savedHeader, document.header.raw) ||
    !taxPolicy(value.taxPolicy) ||
    !diagnosticList(value.diagnostics) ||
    !record(value.phases) ||
    !exactKeys(value.phases, ['loaded', 'opened']) ||
    !record(value.capabilities) ||
    !exactKeys(value.capabilities, ['canPreviewBill', 'canPreviewClosing', 'canSaveNumeric']) ||
    typeof value.capabilities.canPreviewBill !== 'boolean' ||
    value.capabilities.canPreviewClosing !== false ||
    value.capabilities.canSaveNumeric !== false
  )
    fail();
  const { loaded, opened } = value.phases;
  if ((loaded !== null && !phase(loaded)) || (opened !== null && (!loaded || !phase(opened))))
    fail();
  if (
    value.capabilities.canPreviewBill &&
    (!loaded ||
      !opened ||
      value.taxPolicy.status !== 'ready' ||
      !rowReplay.capabilities.canPreview ||
      rowReplay.rows.length === 0 ||
      rowReplay.rows.some((row) => !returnReplayBaseline(row)))
  )
    fail();
  return value as ReturnBillReplayState;
}
export function returnBillReplayRequest(
  state: ReturnBillReplayState,
  row: ReturnReplayRow,
  accepted: readonly ReturnReplayEvent[],
  event: ReturnReplayEvent,
): ReturnReplayRequest {
  if (!state.capabilities.canPreviewBill || !state.phases.opened)
    throw new Error('This saved return cannot preview totals and bill amounts.');
  if ([...accepted, event].some((entry) => /[^\x20-\x7e]/.test(entry.editorText)))
    throw new Error(
      'Enter a plain decimal using ordinary spaces and at most 10 characters. Your entry is retained.',
    );
  // Replay the whole explicit journal, preserving repeated events and original text.
  for (const prior of accepted) returnReplayRequest(state.rowReplay, row, [], prior);
  return {
    ...returnReplayRequest(state.rowReplay, row, accepted, event),
    replayVersion: state.replayVersion,
  };
}
export function readReturnBillReplayResult(
  value: unknown,
  state: ReturnBillReplayState,
  row: ReturnReplayRow,
  request: ReturnReplayRequest,
): ReturnBillReplayResult {
  if (
    !state.capabilities.canPreviewBill ||
    !state.rowReplay.rows.includes(row) ||
    request.replayVersion !== state.replayVersion ||
    request.rowIdentity !== row.rowIdentity ||
    !identity(value, state) ||
    value.replayVersion !== state.replayVersion ||
    !record(value)
  )
    fail();
  if (
    value.rowIdentity !== row.rowIdentity ||
    !snapshot(value.baseline) ||
    !snapshot(value.preview) ||
    !equal(value.baseline, returnReplayBaseline(row)) ||
    !record(value.phases) ||
    !exactKeys(value.phases, ['loaded', 'opened', 'preview']) ||
    !equal(value.phases.loaded, state.phases.loaded) ||
    !equal(value.phases.opened, state.phases.opened) ||
    !phase(value.phases.loaded) ||
    !phase(value.phases.opened) ||
    !phase(value.phases.preview) ||
    !record(value.capabilities) ||
    !exactKeys(value.capabilities, ['canPreviewClosing', 'canSaveNumeric']) ||
    value.capabilities.canPreviewClosing !== false ||
    value.capabilities.canSaveNumeric !== false ||
    !Array.isArray(value.events) ||
    value.events.length !== request.events.length
  )
    fail();
  value.events.forEach((event: unknown, index: number) => {
    const expected = request.events[index];
    if (
      !expected ||
      !record(event) ||
      !exactKeys(event, ['fieldId', 'editorText', 'status']) ||
      event.fieldId !== expected?.fieldId ||
      event.editorText !== expected.editorText ||
      !['applied', 'skipped'].includes(String(event.status))
    )
      fail();
  });
  return value as ReturnBillReplayResult;
}

export type SavedReturnPreviewKind = 'row' | 'bill' | 'labour';
type PreviewContext = { context: number; generation: number };
/** Synchronous ownership closes same-render races; an old close cannot release a new preview. */
export class SavedReturnPreviewOwnership {
  private currentContext: PreviewContext | null = null;
  private owner: SavedReturnPreviewKind | null = null;
  observe(context: PreviewContext | null): void {
    if (!context || !this.matches(context)) this.owner = null;
    this.currentContext = context && { context: context.context, generation: context.generation };
  }
  private matches(context: PreviewContext): boolean {
    return (
      context.context === this.currentContext?.context &&
      context.generation === this.currentContext?.generation
    );
  }
  active(context: PreviewContext | null): SavedReturnPreviewKind | null {
    return context && this.matches(context) ? this.owner : null;
  }
  change(
    context: PreviewContext,
    kind: SavedReturnPreviewKind,
    active: boolean,
    eligible = true,
  ): boolean {
    if (
      !this.matches(context) ||
      (active && !eligible) ||
      (this.owner !== null && this.owner !== kind)
    )
      return false;
    this.owner = active ? kind : null;
    return true;
  }
  clear(): void {
    this.currentContext = null;
    this.owner = null;
  }
}
