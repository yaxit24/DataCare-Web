import { ApiError } from './api';
import {
  savedReturnLineKey,
  savedReturnQuery,
  savedReturnScopeKey,
  type SavedIncomingReturn,
  type SavedReturnIdentity,
  type SavedReturnRaw,
  type SavedReturnScope,
} from './salesReturnForm';

export const returnReplayFields = [19, 20, 21, 23, 24, 25, 26, 27, 28, 36, 37, 38] as const;
export const returnReplayFieldId = (column: number) =>
  `x13.primary-incoming.c${String(column).padStart(2, '0')}`;
const fieldIds = returnReplayFields.map(returnReplayFieldId);
const caches = ['45', '46', '47', '48', '49', '58', '66', '67'];
const hash = /^[a-f0-9]{64}$/;
export type ReturnReplayEvent = { fieldId: string; editorText: string };
export type ReturnReplayCells = Record<string, string>;
export type ReturnReplaySnapshot = {
  visible: ReturnReplayCells;
  caches: ReturnReplayCells;
  editorTextByField: Record<string, string>;
};
export type ReturnReplayDiagnostic = { code: string; fieldId?: string; message: string };
export type ReturnReplayColumn = {
  id: string;
  sourceColumn: number;
  label: string | null;
  originalLabel: string | null;
  widthState: 'zero' | 'nonzero' | 'unresolved';
};
export type ReturnReplayRow = {
  identity: SavedReturnIdentity;
  rowIdentity: string;
  raw: SavedReturnRaw;
  visible: ReturnReplayCells | null;
  caches: ReturnReplayCells | null;
  editorTextByField: Record<string, string> | null;
  fieldCapabilities: Array<{
    fieldId: string;
    allowed: boolean;
    reason: string | null;
    maxLength: 10;
    editorDecimals: 2;
  }>;
  diagnostics: ReturnReplayDiagnostic[];
};
export type ReturnReplayState = {
  contractVersion: 'x13-saved-incoming-replay-v1';
  profile: 'saved-primary-incoming-money-preview-v1';
  scope: SavedReturnScope;
  voucherNo: string;
  replayVersion: string;
  documentVersion: string;
  configurationVersion: string;
  configuration: {
    version: string;
    scope: SavedReturnScope;
    columns: ReturnReplayColumn[];
    capabilities: { canCalculate: boolean; canSaveNumeric: false };
    diagnostics: ReturnReplayDiagnostic[];
    [key: string]: unknown;
  };
  rows: ReturnReplayRow[];
  capabilities: { canPreview: boolean; canSaveNumeric: false };
};
export type ReturnReplayResult = Omit<
  ReturnReplayState,
  'profile' | 'configuration' | 'rows' | 'capabilities'
> & {
  rowIdentity: string;
  baseline: ReturnReplaySnapshot;
  preview: ReturnReplaySnapshot;
  events: Array<ReturnReplayEvent & { status: 'applied' | 'skipped' }>;
  aggregateRequired: boolean;
  capabilities: { canSaveNumeric: false };
};
export type ReturnReplayRequest = {
  replayVersion: string;
  rowIdentity: string;
  events: ReturnReplayEvent[];
};

function record(value: unknown): value is Record<string, unknown> {
  return value !== null && typeof value === 'object' && !Array.isArray(value);
}
function textMap(value: unknown): value is Record<string, string> {
  return record(value) && Object.values(value).every((cell) => typeof cell === 'string');
}
function nullableText(value: unknown): value is string | null {
  return value === null || typeof value === 'string';
}
function diagnostics(value: unknown): value is ReturnReplayDiagnostic[] {
  return (
    Array.isArray(value) &&
    value.every(
      (item) =>
        record(item) &&
        typeof item.code === 'string' &&
        typeof item.message === 'string' &&
        (item.fieldId === undefined || typeof item.fieldId === 'string'),
    )
  );
}
function sameScope(value: unknown, scope: SavedReturnScope): boolean {
  return (
    record(value) &&
    ['coCode', 'lcCode', 'coYear', 'coBook'].every(
      (key) => value[key] === scope[key as keyof SavedReturnScope],
    )
  );
}
function snapshot(value: unknown): value is ReturnReplaySnapshot {
  if (
    !record(value) ||
    !textMap(value.visible) ||
    !textMap(value.caches) ||
    !textMap(value.editorTextByField)
  )
    return false;
  const observedCaches = value.caches;
  const editors = value.editorTextByField;
  return (
    Object.keys(value.visible).length === 63 &&
    Object.keys(value.visible).every(
      (column) => /^(0|[1-6]?\d|70)$/.test(column) && !caches.includes(column),
    ) &&
    Object.keys(observedCaches).length === 8 &&
    caches.every((key) => key in observedCaches) &&
    Object.keys(editors).length === 12 &&
    fieldIds.every((id) => id in editors)
  );
}
function fail(): never {
  throw new Error(
    'The calculation observation is incomplete or does not match this saved return. Reload the saved return.',
  );
}
function equalMap(a: Record<string, string | null>, b: Record<string, string | null>): boolean {
  const keys = Object.keys(a);
  return keys.length === Object.keys(b).length && keys.every((key) => a[key] === b[key]);
}
function sameSnapshot(a: ReturnReplaySnapshot, b: ReturnReplaySnapshot): boolean {
  return (
    equalMap(a.visible, b.visible) &&
    equalMap(a.caches, b.caches) &&
    equalMap(a.editorTextByField, b.editorTextByField)
  );
}

export function returnReplayPath(
  document: Pick<SavedIncomingReturn, 'scope' | 'voucherNo'>,
  action: 'state' | 'preview' = 'state',
): string {
  if (!/^\d{5}$/.test(document.voucherNo))
    throw new Error(
      'Calculation preview currently requires an exact five-digit saved return voucher.',
    );
  return `/sales-returns/${document.voucherNo}/incoming-replay${action === 'state' ? '-state' : ''}?${savedReturnQuery(document.scope)}`;
}

/** A version is insufficient if a malformed response carries mismatched saved identity/raw. */
export function readReturnReplayState(
  value: unknown,
  document: SavedIncomingReturn,
): ReturnReplayState {
  if (
    !record(value) ||
    value.contractVersion !== 'x13-saved-incoming-replay-v1' ||
    value.profile !== 'saved-primary-incoming-money-preview-v1' ||
    !sameScope(value.scope, document.scope) ||
    value.voucherNo !== document.voucherNo ||
    value.documentVersion !== document.version ||
    ![value.replayVersion, value.documentVersion, value.configurationVersion].every(
      (token) => typeof token === 'string' && hash.test(token),
    ) ||
    !record(value.capabilities) ||
    typeof value.capabilities.canPreview !== 'boolean' ||
    value.capabilities.canSaveNumeric !== false
  )
    fail();
  const config = value.configuration;
  if (
    !record(config) ||
    config.version !== value.configurationVersion ||
    !sameScope(config.scope, document.scope) ||
    !Array.isArray(config.columns) ||
    config.columns.length !== 71 ||
    !record(config.capabilities) ||
    typeof config.capabilities.canCalculate !== 'boolean' ||
    config.capabilities.canSaveNumeric !== false ||
    !diagnostics(config.diagnostics)
  )
    fail();
  const columns = new Map<number, ReturnReplayColumn>();
  for (const column of config.columns) {
    if (
      !record(column) ||
      !Number.isInteger(column.sourceColumn) ||
      typeof column.sourceColumn !== 'number' ||
      column.sourceColumn < 0 ||
      column.sourceColumn > 70 ||
      column.id !== returnReplayFieldId(column.sourceColumn) ||
      columns.has(column.sourceColumn) ||
      !nullableText(column.label) ||
      !nullableText(column.originalLabel) ||
      !['zero', 'nonzero', 'unresolved'].includes(String(column.widthState))
    )
      fail();
    columns.set(column.sourceColumn, column as ReturnReplayColumn);
  }
  if (
    !Array.isArray(value.rows) ||
    value.rows.length !== document.lines.length ||
    (value.rows.length === 0 && value.capabilities.canPreview)
  )
    fail();
  const seen = new Set<string>();
  const identities = new Set<string>();
  for (const row of value.rows) {
    if (
      !record(row) ||
      typeof row.rowIdentity !== 'string' ||
      !hash.test(row.rowIdentity) ||
      seen.has(row.rowIdentity) ||
      !record(row.identity) ||
      !record(row.raw) ||
      !Object.values(row.raw).every(nullableText) ||
      !diagnostics(row.diagnostics)
    )
      fail();
    const source = document.lines.find((line) =>
      Object.keys(line.identity).every(
        (key) =>
          line.identity[key as keyof SavedReturnIdentity] ===
          (row.identity as Record<string, unknown>)[key],
      ),
    );
    if (
      !source ||
      !equalMap(source.raw, row.raw as SavedReturnRaw) ||
      identities.has(savedReturnLineKey(source.identity))
    )
      fail();
    seen.add(row.rowIdentity);
    identities.add(savedReturnLineKey(source.identity));
    const ready = row.visible !== null || row.caches !== null || row.editorTextByField !== null;
    if (
      ready &&
      !snapshot({
        visible: row.visible,
        caches: row.caches,
        editorTextByField: row.editorTextByField,
      })
    )
      fail();
    if (!Array.isArray(row.fieldCapabilities) || row.fieldCapabilities.length !== 12) fail();
    const fields = new Set<string>();
    for (const cap of row.fieldCapabilities) {
      if (
        !record(cap) ||
        typeof cap.fieldId !== 'string' ||
        !fieldIds.includes(cap.fieldId) ||
        fields.has(cap.fieldId) ||
        typeof cap.allowed !== 'boolean' ||
        !nullableText(cap.reason) ||
        cap.maxLength !== 10 ||
        cap.editorDecimals !== 2
      )
        fail();
      const column = columns.get(Number(cap.fieldId.slice(-2)));
      if (
        cap.allowed &&
        (!ready ||
          !value.capabilities.canPreview ||
          !config.capabilities.canCalculate ||
          column?.widthState !== 'nonzero')
      )
        fail();
      fields.add(cap.fieldId);
    }
  }
  return value as ReturnReplayState;
}

export function returnReplayBaseline(row: ReturnReplayRow): ReturnReplaySnapshot | null {
  return row.visible && row.caches && row.editorTextByField
    ? { visible: row.visible, caches: row.caches, editorTextByField: row.editorTextByField }
    : null;
}

/** Each call is one deliberate completed-cell event, including repeated identical text. */
export function returnReplayRequest(
  state: ReturnReplayState,
  row: ReturnReplayRow,
  accepted: readonly ReturnReplayEvent[],
  event: ReturnReplayEvent,
): ReturnReplayRequest {
  if (
    !state.capabilities.canPreview ||
    !state.rows.includes(row) ||
    !returnReplayBaseline(row) ||
    !row.fieldCapabilities.some((cap) => cap.fieldId === event.fieldId && cap.allowed)
  )
    throw new Error('This saved item or field cannot be previewed.');
  if (accepted.length >= 100)
    throw new Error(
      'The preview has reached 100 field changes. Discard it and start another preview.',
    );
  if (
    event.editorText.length > 10 ||
    /[\u0000-\u001f\u007f]/.test(event.editorText) ||
    (event.editorText.trim() !== '' &&
      !/^\s*[+-]?(?:\d+(?:\.\d*)?|\.\d+)\s*$/.test(event.editorText))
  )
    throw new Error(
      'Enter a plain decimal number of at most 10 characters. Your entry is retained.',
    );
  return {
    replayVersion: state.replayVersion,
    rowIdentity: row.rowIdentity,
    events: [...accepted, event].map(({ fieldId, editorText }) => ({ fieldId, editorText })),
  };
}

export function readReturnReplayResult(
  value: unknown,
  state: ReturnReplayState,
  row: ReturnReplayRow,
  request: ReturnReplayRequest,
): ReturnReplayResult {
  if (
    !record(value) ||
    value.contractVersion !== state.contractVersion ||
    !sameScope(value.scope, state.scope) ||
    value.voucherNo !== state.voucherNo ||
    value.replayVersion !== state.replayVersion ||
    value.documentVersion !== state.documentVersion ||
    value.configurationVersion !== state.configurationVersion ||
    value.rowIdentity !== row.rowIdentity ||
    !snapshot(value.baseline) ||
    !snapshot(value.preview) ||
    !sameSnapshot(value.baseline, returnReplayBaseline(row)!) ||
    typeof value.aggregateRequired !== 'boolean' ||
    !record(value.capabilities) ||
    value.capabilities.canSaveNumeric !== false ||
    !Array.isArray(value.events) ||
    value.events.length !== request.events.length
  )
    fail();
  value.events.forEach((event: unknown, index: number) => {
    const expected = request.events[index];
    if (
      !record(event) ||
      event.fieldId !== expected?.fieldId ||
      event.editorText !== expected.editorText ||
      !['applied', 'skipped'].includes(String(event.status))
    )
      fail();
  });
  return value as ReturnReplayResult;
}

export function returnReplayFailure(error: unknown, reading = false) {
  const api = error instanceof ApiError;
  const needsReload =
    reading || !api || error.status >= 500 || [401, 403, 404, 409].includes(error.status);
  return {
    needsReload,
    conflict: api && error.status === 409,
    message: api
      ? String(error.body?.message || error.body?.error || error.message)
      : error instanceof Error
        ? error.message
        : 'The calculation request failed.',
  };
}

export class ReturnReplayGuard {
  private key = '';
  private generation = 0;
  private request = 0;
  observe(document: Pick<SavedIncomingReturn, 'scope' | 'voucherNo' | 'version'>): number {
    const key = JSON.stringify([
      savedReturnScopeKey(document.scope),
      document.voucherNo,
      document.version,
    ]);
    if (key !== this.key) {
      this.key = key;
      this.generation++;
      this.request++;
    }
    return this.generation;
  }
  invalidate(): void {
    this.generation++;
    this.request++;
  }
  begin(): { generation: number; request: number } {
    return { generation: this.generation, request: ++this.request };
  }
  current(token: { generation: number; request: number }): boolean {
    return token.generation === this.generation && token.request === this.request;
  }
}
