import { Decimal } from 'decimal.js';
import { decimalCellText } from './money.js';
import type {
  SaleReturnIncomingEvent,
  SaleReturnIncomingState,
  SaleReturnIncomingRaw,
} from './saleReturnIncoming.js';

/** Primary TR_SALE_RTN.cs:4248–4380 only, before CommPassTotal_Pr.
 * This mathematical decimal profile is not measured Windows Format/collation
 * parity. Inputs must come from the trusted caller's complete observation;
 * this pure copy does not authenticate a token, admit a source item or write. */
export const SALE_RETURN_INCOMING_LABOUR_VERSION = 'primary-incoming-labour-copy-v1' as const;
export const SALE_RETURN_INCOMING_LABOUR_PROFILE = 'resolved-ascii-code2-decimal-copy-v1' as const;
export const SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION =
  'incoming-labour-master-observation-v1' as const;
export interface SaleReturnIncomingLabourScope {
  readonly tenantId: string;
  readonly coCode: string;
}
export interface SaleReturnIncomingLabourMaster {
  readonly raw: SaleReturnIncomingRaw;
  readonly revision: string;
  readonly locator: string;
}
export interface SaleReturnIncomingLabourObservation {
  readonly version: typeof SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION;
  readonly scope: SaleReturnIncomingLabourScope;
  readonly enteredCode: string;
  readonly complete: true;
  readonly observationVersion: string;
  readonly masters: readonly SaleReturnIncomingLabourMaster[];
}
export interface SaleReturnIncomingLabourCopyInput {
  readonly scope: SaleReturnIncomingLabourScope;
  readonly rowIdentity: string;
  readonly state: SaleReturnIncomingState;
  readonly field: 13 | 29;
  readonly editorText: string;
  readonly expectedObservationVersion: string;
  readonly observation: SaleReturnIncomingLabourObservation;
}
export interface SaleReturnIncomingLabourDiagnostic {
  readonly code:
    | 'invalid-input'
    | 'invalid-row-state'
    | 'row-identity-conflict'
    | 'unsupported-code'
    | 'invalid-observation'
    | 'observation-conflict'
    | 'ambiguous-labour-master'
    | 'labour-lookup-required'
    | 'unsupported-category'
    | 'unsupported-labour-value';
  readonly message: string;
}
export type SaleReturnIncomingLabourNextEvent = Extract<
  SaleReturnIncomingEvent,
  { kind: 'calculateAfterCopy' }
>;
export type SaleReturnIncomingLabourCopyResult =
  | {
      readonly status: 'ready';
      readonly state: SaleReturnIncomingState;
      readonly observation: SaleReturnIncomingLabourObservation;
      readonly visiblePatch: Readonly<Record<number, string>>;
      readonly nextEvent: SaleReturnIncomingLabourNextEvent;
      readonly diagnostics: readonly [];
    }
  | {
      readonly status: 'lookup-required' | 'unsupported';
      readonly state: SaleReturnIncomingState | null;
      readonly observation: SaleReturnIncomingLabourObservation | null;
      readonly visiblePatch: null;
      readonly nextEvent: null;
      readonly diagnostics: readonly SaleReturnIncomingLabourDiagnostic[];
    };

const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
const incomingDestinations: Readonly<Record<string, number | undefined>> = {
  '01': 23,
  '02': 21,
  '03': 24,
  '04': 17,
  '05': 14,
  '06': 23,
  '07': 28,
};
const tagDestinations: Readonly<Record<string, number | undefined>> = {
  '01': 31,
  '02': 30,
  '03': 32,
  '06': 31,
  '07': 35,
};
const caches = ['45', '46', '47', '48', '49', '58', '66', '67'];
const visible = Array.from({ length: 71 }, (_, n) => String(n)).filter(
  (key) => !caches.includes(key),
);
const plain = (value: unknown): value is Record<string, unknown> => {
  if (!value || typeof value !== 'object' || Array.isArray(value)) return false;
  const proto = Object.getPrototypeOf(value);
  return proto === Object.prototype || proto === null;
};
const exact = (value: unknown, keys: readonly string[]): value is Record<string, unknown> =>
  plain(value) &&
  Object.keys(value).length === keys.length &&
  keys.every((key) => Object.hasOwn(value, key));
const keyText = (value: unknown, max: number): value is string =>
  typeof value === 'string' &&
  value.length > 0 &&
  value.length <= max &&
  !/[^\x20-\x7e]/.test(value) &&
  value.trim() === value;
const hashText = (value: unknown): value is string =>
  typeof value === 'string' && value.length === 64 && !/[^a-f0-9]/.test(value);
const scopeValue = (value: unknown): value is SaleReturnIncomingLabourScope =>
  exact(value, ['tenantId', 'coCode']) && keyText(value.tenantId, 24) && keyText(value.coCode, 2);
const rawValue = (value: unknown): value is SaleReturnIncomingRaw =>
  plain(value) && Object.values(value).every((cell) => cell === null || typeof cell === 'string');

/** Detach plain data without calling accessors. Limits are an internal transport
 * containment profile, not desktop row limits. Caller objects are never frozen. */
function detach(value: unknown): unknown {
  const seen = new Set<object>();
  let nodes = 0;
  let textSize = 0;
  const visit = (item: unknown, depth: number): unknown => {
    if (depth > 24 || ++nodes > 100000) throw new Error('input-limit');
    if (typeof item === 'string') {
      textSize += item.length;
      if (textSize > 1000000) throw new Error('input-limit');
      return item;
    }
    if (item === null || typeof item === 'boolean') return item;
    if (typeof item === 'number' && Number.isFinite(item)) return item;
    if ((!plain(item) && !Array.isArray(item)) || seen.has(item as object))
      throw new Error('plain-data-required');
    seen.add(item as object);
    const array = Array.isArray(item);
    const keys = Reflect.ownKeys(item as object);
    const entries = array ? keys.filter((key) => key !== 'length') : keys;
    if (array && (entries.length !== item.length || entries.some((key, i) => key !== String(i))))
      throw new Error('dense-array-required');
    const out: Record<string, unknown> | unknown[] = array ? [] : {};
    for (const key of entries) {
      if (typeof key !== 'string') throw new Error('plain-data-required');
      const descriptor = Object.getOwnPropertyDescriptor(item as object, key)!;
      if (!Object.hasOwn(descriptor, 'value') || !descriptor.enumerable)
        throw new Error('plain-data-required');
      Object.defineProperty(out, key, {
        value: visit(descriptor.value, depth + 1),
        enumerable: true,
        configurable: true,
        writable: true,
      });
    }
    seen.delete(item as object);
    return out;
  };
  return visit(value, 0);
}
function freeze<T>(value: T): T {
  if (value && typeof value === 'object') {
    Object.values(value).forEach(freeze);
    Object.freeze(value);
  }
  return value;
}
function journalValue(value: unknown): boolean {
  if (!Array.isArray(value)) return false;
  return value.every((entry) => {
    if (!exact(entry, ['event', 'calculated', 'policy']) || typeof entry.calculated !== 'boolean')
      return false;
    const e = entry.event;
    if (!plain(e) || typeof e.rowIdentity !== 'string') return false;
    if (e.kind === 'leaveCell') {
      if (
        !exact(e, ['kind', 'rowIdentity', 'column', 'text', 'context']) ||
        !Number.isInteger(e.column) ||
        typeof e.text !== 'string' ||
        !exact(e.context, ['currentRow', 'clearing', 'editorVisible', 'committedColumnWidth']) ||
        !Number.isInteger(e.context.currentRow) ||
        typeof e.context.clearing !== 'boolean' ||
        typeof e.context.editorVisible !== 'boolean' ||
        (e.context.committedColumnWidth !== null &&
          !Number.isInteger(e.context.committedColumnWidth))
      )
        return false;
    } else if (e.kind === 'calculateAfterCopy') {
      if (
        !exact(e, ['kind', 'rowIdentity', 'activeColumn', 'editorText', 'cause']) ||
        !Number.isInteger(e.activeColumn) ||
        typeof e.editorText !== 'string' ||
        typeof e.cause !== 'string' ||
        !['sourceSelection', 'labourCodeSelection', 'tagLabourCodeSelection'].includes(e.cause)
      )
        return false;
    } else return false;
    const p = entry.policy;
    return (
      exact(p, [
        'saleAmountType',
        'labourRoundingDecimals',
        'labourIncludesGhat',
        'generateLabourRate',
        'fineColumnWidth',
      ]) &&
      typeof p.saleAmountType === 'string' &&
      Number.isInteger(p.labourRoundingDecimals) &&
      typeof p.labourIncludesGhat === 'boolean' &&
      typeof p.generateLabourRate === 'boolean' &&
      (p.fineColumnWidth === null || Number.isInteger(p.fineColumnWidth))
    );
  });
}
function stateValue(value: unknown): value is SaleReturnIncomingState {
  return (
    exact(value, ['rowIdentity', 'raw', 'visible', 'caches', 'journal']) &&
    keyText(value.rowIdentity, 256) &&
    rawValue(value.raw) &&
    exact(value.visible, visible) &&
    Object.values(value.visible).every((cell) => typeof cell === 'string') &&
    exact(value.caches, caches) &&
    Object.values(value.caches).every((cell) => typeof cell === 'string') &&
    journalValue(value.journal)
  );
}
function observationValue(value: unknown): value is SaleReturnIncomingLabourObservation {
  return (
    exact(value, [
      'version',
      'scope',
      'enteredCode',
      'complete',
      'observationVersion',
      'masters',
    ]) &&
    value.version === SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION &&
    scopeValue(value.scope) &&
    keyText(value.enteredCode, 2) &&
    value.complete === true &&
    hashText(value.observationVersion) &&
    Array.isArray(value.masters) &&
    value.masters.every((row) => {
      if (!exact(row, ['raw', 'revision', 'locator']) || !rawValue(row.raw)) return false;
      const raw = row.raw;
      return (
        typeof row.revision === 'string' &&
        row.revision.length > 0 &&
        !/[^0-9]/.test(row.revision) &&
        typeof row.locator === 'string' &&
        /^\([0-9]+,[0-9]+\)$/.test(row.locator) &&
        !/[^\x20-\x7e]/.test(row.locator) &&
        ['tenant_id', 'CO_CODE', 'LBR_CODE', 'LBR_CATG', 'LBR_VAL'].every((key) =>
          Object.hasOwn(raw, key),
        )
      );
    })
  );
}
const normalized = (value: string | null | undefined) =>
  value?.replace(/^ +| +$/g, '').toUpperCase();
function valueText(value: string | null | undefined): string | null {
  if (
    typeof value !== 'string' ||
    value.length > 128 ||
    /[^\x20-\x7e]/.test(value) ||
    !/^ *[+-]?(?:\d+(?:\.\d*)?|\.\d+) *$/.test(value)
  )
    return null;
  const number = new D(value.trim());
  if (!number.isFinite() || number.sd() > 36 || number.dp() > 18 || number.abs().gte('1e36'))
    return null;
  const text = decimalCellText(number, 2);
  const result = new D(text);
  return result.sd() <= 36 && result.abs().lt('1e36') ? text : null;
}

export function copySaleReturnIncomingLabour(input: unknown): SaleReturnIncomingLabourCopyResult {
  let data: unknown;
  try {
    data = detach(input);
  } catch {
    return freeze({
      status: 'unsupported',
      state: null,
      observation: null,
      visiblePatch: null,
      nextEvent: null,
      diagnostics: [
        {
          code: 'invalid-input',
          message: 'A bounded plain-data internal copy observation is required.',
        },
      ],
    });
  }
  const state = plain(data) && stateValue(data.state) ? data.state : null;
  const observation = plain(data) && observationValue(data.observation) ? data.observation : null;
  const reject = (
    code: SaleReturnIncomingLabourDiagnostic['code'],
    message: string,
    status: 'unsupported' | 'lookup-required' = 'unsupported',
  ): SaleReturnIncomingLabourCopyResult =>
    freeze({
      status,
      state,
      observation,
      visiblePatch: null,
      nextEvent: null,
      diagnostics: [{ code, message }],
    });
  if (
    !exact(data, [
      'scope',
      'rowIdentity',
      'state',
      'field',
      'editorText',
      'expectedObservationVersion',
      'observation',
    ]) ||
    !scopeValue(data.scope) ||
    !keyText(data.rowIdentity, 256) ||
    (data.field !== 13 && data.field !== 29) ||
    typeof data.editorText !== 'string' ||
    !hashText(data.expectedObservationVersion)
  )
    return reject(
      'invalid-input',
      'An exact internal scope, row identity, target field and observation version are required.',
    );
  const scope = data.scope;
  const editorText = data.editorText;
  if (!state)
    return reject(
      'invalid-row-state',
      'Preserve the complete 63 visible cells, eight caches, raw row and prior journal.',
    );
  if (state.rowIdentity !== data.rowIdentity)
    return reject('row-identity-conflict', 'The code selection belongs to another row.');
  if (
    (Object.hasOwn(state.raw, 'CO_CODE') && state.raw.CO_CODE !== scope.coCode) ||
    (Object.hasOwn(state.raw, 'tenant_id') && state.raw.tenant_id !== scope.tenantId)
  )
    return reject('row-identity-conflict', 'The retained raw row belongs to another scope.');
  if (!keyText(data.editorText, 2))
    return reject(
      'unsupported-code',
      'This resolved-code profile requires an unpadded nonblank ASCII master code of at most two characters.',
    );
  if (!observation)
    return reject(
      'invalid-observation',
      'A complete physical labour-master observation is required.',
    );
  if (
    observation.scope.tenantId !== data.scope.tenantId ||
    observation.scope.coCode !== data.scope.coCode ||
    observation.enteredCode !== data.editorText ||
    observation.observationVersion !== data.expectedObservationVersion
  )
    return reject(
      'observation-conflict',
      'Reload the matching scoped master observation before copying.',
    );
  if (observation.masters.some((row) => row.raw.tenant_id !== scope.tenantId))
    return reject('invalid-observation', 'The master observation contains another tenant.');
  const relevant = observation.masters.filter(
    (row) =>
      normalized(row.raw.CO_CODE) === normalized(scope.coCode) &&
      normalized(row.raw.LBR_CODE) === normalized(editorText),
  );
  if (
    relevant.some((row) => row.raw.CO_CODE !== scope.coCode || row.raw.LBR_CODE !== editorText) ||
    relevant.length > 1
  )
    return reject(
      'ambiguous-labour-master',
      'An exact duplicate or case/space alias has unresolved desktop collation semantics.',
    );
  const master = relevant[0];
  if (!master)
    return reject(
      'labour-lookup-required',
      'The source opens help and returns without copying or calculating.',
      'lookup-required',
    );
  const category = master.raw.LBR_CATG?.slice(0, 2);
  if (!category || !['01', '02', '03', '04', '05', '06', '07'].includes(category))
    return reject(
      'unsupported-category',
      'Only the exact first two category characters 01 through 07 are qualified.',
    );
  // The initial profile requires a known numeric value even for c29 categories
  // 04/05, which perform no value assignment in the source. This is containment.
  const formatted = valueText(master.raw.LBR_VAL);
  if (formatted === null)
    return reject(
      'unsupported-labour-value',
      'The raw labour value has no qualified finite plain-decimal Format2 projection.',
    );
  const patch: Record<number, string> = {};
  const changed = state.visible[data.field] !== data.editorText;
  if (data.field === 13) {
    if (changed) for (const column of [23, 24, 21, 14, 17, 28]) patch[column] = '';
    patch[13] = data.editorText;
    if (state.visible[29] === '') patch[29] = data.editorText;
    const destination = incomingDestinations[category];
    if (category === '06') patch[22] = 'K';
    patch[destination!] = formatted;
  } else {
    if (changed) for (const column of [31, 32, 30, 35]) patch[column] = '';
    patch[29] = data.editorText;
    const destination = tagDestinations[category];
    if (destination !== undefined) patch[destination] = formatted;
  }
  return freeze({
    status: 'ready',
    state: { ...state, visible: { ...state.visible, ...patch } },
    observation,
    visiblePatch: patch,
    nextEvent: {
      kind: 'calculateAfterCopy',
      rowIdentity: state.rowIdentity,
      activeColumn: data.field,
      editorText: data.editorText,
      cause: data.field === 13 ? 'labourCodeSelection' : 'tagLabourCodeSelection',
    },
    diagnostics: [],
  });
}
