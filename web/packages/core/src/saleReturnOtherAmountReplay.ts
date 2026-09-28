import { Decimal } from 'decimal.js';
import { projectSavedSaleReturnIncoming } from './saleReturnIncomingProjection.js';
import { projectSavedSaleReturnBill } from './saleReturnBillProjection.js';
import { projectSaleReturnIncomingSave } from './saleReturnIncomingSaveProjection.js';
import { qualifySaleReturnHeaderFloat } from './saleReturnHeaderFloat.js';
import {
  aggregateSaleReturnIncoming,
  calculateSaleReturnBill,
  createSaleReturnIncomingAggregateState,
  reduceSaleReturnIncomingAggregate,
  type SaleReturnBillState,
  type SaleReturnIncomingAggregateState,
  type SaleReturnIncomingTotalsState,
} from './saleReturnIncomingAggregate.js';
import type { SaleReturnIncomingState, SaleReturnIncomingPolicy } from './saleReturnIncoming.js';

/** Pure saved hydration -> open fold/bill -> ordered c27 events -> Save fold.
 * A candidate for a separately observed N-companion numeric profile. It neither
 * consumes nor changes the older API preview capability. Source Save folds the
 * grids again but does not call BILL_TOTAL; preserve that last bill/cache state.
 * No master/configuration/session authenticity, effect ownership or DML here.
 */
export const SALE_RETURN_OTHER_AMOUNT_REPLAY_VERSION = 'saved-other-amount-replay-v1';
export const SALE_RETURN_OTHER_AMOUNT_REPLAY_PROFILE = 'single-n-primary-positive-c27-candidate-v1';
type Raw = Readonly<Record<string, string | null>>;
export interface SaleReturnOtherAmountReplayInput {
  readonly observationIdentity: string;
  readonly rowIdentity: string;
  readonly rawHeader: Raw;
  readonly rawIncoming: Raw;
  readonly itemMasters: readonly Raw[];
  readonly labels: Readonly<{
    taxName: string | null;
    bankAccountName: string | null;
    cardAccountName: string | null;
  }>;
  readonly rowPolicy: SaleReturnIncomingPolicy;
  readonly taxRoundingDecimals: number;
  readonly c27ColumnWidth: number;
  readonly events: readonly string[];
}
export interface SaleReturnOtherAmountPhase {
  readonly row: SaleReturnIncomingState;
  readonly incomingTotals: SaleReturnIncomingTotalsState;
  readonly bill: SaleReturnBillState;
}
export interface SaleReturnOtherAmountReplayResult {
  readonly version: typeof SALE_RETURN_OTHER_AMOUNT_REPLAY_VERSION;
  readonly profile: typeof SALE_RETURN_OTHER_AMOUNT_REPLAY_PROFILE;
  readonly canCommit: false;
  readonly status: 'ready' | 'unsupported';
  readonly observation: SaleReturnOtherAmountReplayInput | null;
  readonly loaded: SaleReturnOtherAmountPhase | null;
  readonly opened: SaleReturnOtherAmountPhase | null;
  readonly prefixes: readonly SaleReturnOtherAmountPhase[];
  readonly final: SaleReturnOtherAmountPhase | null;
  readonly saveFold: SaleReturnIncomingTotalsState | null;
  readonly candidate: null | Readonly<{
    linePatch: Readonly<Partial<Record<'OTH_AMT' | 'TOT_AMT' | 'NET_AMT', string>>>;
    headerPatch: Readonly<Partial<Record<'RTN_NET_AMT' | 'RTN_TOT_AMT' | 'RTN_BILL_OS', string>>>;
    afterIncoming: Raw;
    afterHeader: Raw;
    /** Only these two raw records; not a whole-document no-op certification. */
    hasLineOrHeaderChanges: boolean;
  }>;
  readonly diagnostics: readonly Readonly<{ code: string; message: string; eventIndex?: number }>[];
  readonly requirements: readonly string[];
}
const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
const REQUIREMENTS = [
  'fresh-server-observation-and-fixed-update-session-authority',
  'complete-source-configuration-master-and-save-guard-admission',
  'actual-n-bar-and-all-financial-companion-membership-ownership',
  'edition-audit-external-reference-and-storage-qualification',
  'single-serializable-write-and-complete-postconditions',
] as const;
class Refusal extends Error {
  constructor(
    readonly code: string,
    message: string,
  ) {
    super(message);
  }
}
function fail(code: string, message: string): never {
  throw new Refusal(code, message);
}
function freeze<T>(value: T): T {
  if (value && typeof value === 'object' && !Object.isFrozen(value)) {
    Object.values(value).forEach(freeze);
    Object.freeze(value);
  }
  return value;
}
/** Detach bounded own plain data before passing observations to older kernels. */
function detach(value: unknown): unknown {
  let nodes = 0;
  const path = new Set<object>();
  const visit = (v: unknown, depth: number): unknown => {
    if (++nodes > 20000 || depth > 8) fail('invalid-input', 'The observation is too large.');
    if (v === null || typeof v === 'boolean') return v;
    if (typeof v === 'string' && v.length <= 4096) return v;
    if (typeof v === 'number' && Number.isSafeInteger(v)) return v;
    if (!v || typeof v !== 'object' || path.has(v))
      fail('invalid-input', 'Use bounded plain data.');
    const array = Array.isArray(v);
    if (!array && ![Object.prototype, null].includes(Object.getPrototypeOf(v)))
      fail('invalid-input', 'Use own plain records.');
    const keys = Reflect.ownKeys(v);
    if (keys.length > 1024 || (array && v.length > 100))
      fail('invalid-input', 'The observation is too large.');
    if (
      array &&
      (keys.length !== v.length + 1 ||
        keys.some(
          (k) =>
            k !== 'length' &&
            (typeof k !== 'string' || !/^(?:0|[1-9]\d*)$/.test(k) || Number(k) >= v.length),
        ))
    )
      fail('invalid-input', 'Use dense plain arrays.');
    path.add(v);
    const out: Record<string, unknown> | unknown[] = array ? [] : {};
    for (const key of keys) {
      if (array && key === 'length') continue;
      const descriptor = Object.getOwnPropertyDescriptor(v, key);
      if (typeof key !== 'string' || !descriptor?.enumerable || !Object.hasOwn(descriptor, 'value'))
        fail('invalid-input', 'Use owned enumerable data properties.');
      Object.defineProperty(out, key, {
        value: visit(descriptor.value, depth + 1),
        enumerable: true,
        writable: true,
        configurable: true,
      });
    }
    path.delete(v);
    return out;
  };
  return visit(value, 0);
}
function exact(value: unknown, keys: string[]): asserts value is Record<string, unknown> {
  if (
    !value ||
    typeof value !== 'object' ||
    Array.isArray(value) ||
    Object.keys(value).length !== keys.length ||
    keys.some((k) => !Object.hasOwn(value, k))
  )
    fail('invalid-input', 'The exact observation envelope is required.');
}
function raw(value: unknown): asserts value is Raw {
  if (
    !value ||
    typeof value !== 'object' ||
    Array.isArray(value) ||
    Object.values(value).some((v) => v !== null && typeof v !== 'string')
  )
    fail('invalid-input', 'Raw values must be strings or SQL NULL.');
}
const token = (v: unknown) => typeof v === 'string' && v.length === 64 && /^[a-f0-9]{64}$/.test(v);
function numeric(v: string | null | undefined): Decimal {
  if (
    typeof v !== 'string' ||
    v.length > 128 ||
    /[^\x20-\x7e]/.test(v) ||
    !/^[ ]*[+-]?(?:\d+(?:\.\d*)?|\.\d+)[ ]*$/.test(v)
  )
    fail('unsupported-decimal', 'A bounded exact plain decimal observation is required.');
  const n = new D(v.trim());
  if (n.sd() > 36 || n.dp() > 18 || n.abs().gte('1e36'))
    fail('unsupported-decimal', 'The decimal exceeds this calculation profile.');
  return n;
}
const blankTotals = (): SaleReturnIncomingTotalsState => ({
  cells: Object.fromEntries(Array.from({ length: 71 }, (_, i) => [i, ''])),
  totCrFine: '0',
  prOthAmtLess: '0',
});
const phase = (state: SaleReturnIncomingAggregateState): SaleReturnOtherAmountPhase => ({
  row: state.rows[0]!.state,
  incomingTotals: state.totals,
  bill: state.bill,
});
function input(value: unknown): SaleReturnOtherAmountReplayInput {
  const x = detach(value);
  exact(x, [
    'observationIdentity',
    'rowIdentity',
    'rawHeader',
    'rawIncoming',
    'itemMasters',
    'labels',
    'rowPolicy',
    'taxRoundingDecimals',
    'c27ColumnWidth',
    'events',
  ]);
  if (!token(x.observationIdentity) || !token(x.rowIdentity))
    fail('invalid-input', 'Exact opaque observation and row identities are required.');
  raw(x.rawHeader);
  raw(x.rawIncoming);
  if (!Array.isArray(x.itemMasters) || x.itemMasters.length > 8)
    fail('invalid-input', 'Supply the bounded item observations.');
  x.itemMasters.forEach(raw);
  exact(x.labels, ['taxName', 'bankAccountName', 'cardAccountName']);
  raw(x.labels);
  exact(x.rowPolicy, [
    'saleAmountType',
    'labourRoundingDecimals',
    'labourIncludesGhat',
    'generateLabourRate',
    'fineColumnWidth',
  ]);
  if (
    typeof x.rowPolicy.saleAmountType !== 'string' ||
    !['N', 'G', 'F'].includes(x.rowPolicy.saleAmountType) ||
    typeof x.rowPolicy.labourIncludesGhat !== 'boolean' ||
    typeof x.rowPolicy.generateLabourRate !== 'boolean' ||
    typeof x.rowPolicy.labourRoundingDecimals !== 'number' ||
    x.rowPolicy.labourRoundingDecimals < 0 ||
    x.rowPolicy.labourRoundingDecimals > 15 ||
    typeof x.rowPolicy.fineColumnWidth !== 'number' ||
    x.rowPolicy.fineColumnWidth < 0 ||
    x.rowPolicy.fineColumnWidth > 32767 ||
    typeof x.taxRoundingDecimals !== 'number' ||
    x.taxRoundingDecimals < 0 ||
    x.taxRoundingDecimals > 15 ||
    typeof x.c27ColumnWidth !== 'number' ||
    x.c27ColumnWidth <= 0 ||
    x.c27ColumnWidth > 32767
  )
    fail('unsupported-policy', 'Resolved calculation policy and a visible c27 width are required.');
  if (
    !Array.isArray(x.events) ||
    x.events.some((v) => typeof v !== 'string' || v.length > 10 || /[^\x20-\x7e]/.test(v))
  )
    fail(
      'invalid-input',
      'Use at most100 ordered original c27 editor strings of at most10 ASCII characters.',
    );
  return x as unknown as SaleReturnOtherAmountReplayInput;
}
export function replaySaleReturnOtherAmount(value: unknown): SaleReturnOtherAmountReplayResult {
  let observation: SaleReturnOtherAmountReplayInput | null = null;
  let loaded: SaleReturnOtherAmountPhase | null = null;
  let opened: SaleReturnOtherAmountPhase | null = null;
  let current: SaleReturnOtherAmountPhase | null = null;
  let saveFold: SaleReturnIncomingTotalsState | null = null;
  let eventIndex: number | undefined;
  const prefixes: SaleReturnOtherAmountPhase[] = [];
  const result = (
    status: 'ready' | 'unsupported',
    candidate: SaleReturnOtherAmountReplayResult['candidate'],
    diagnostics: SaleReturnOtherAmountReplayResult['diagnostics'],
  ): SaleReturnOtherAmountReplayResult =>
    freeze({
      version: SALE_RETURN_OTHER_AMOUNT_REPLAY_VERSION,
      profile: SALE_RETURN_OTHER_AMOUNT_REPLAY_PROFILE,
      canCommit: false,
      status,
      observation,
      loaded,
      opened,
      prefixes,
      final: current,
      saveFold,
      candidate,
      diagnostics,
      requirements: REQUIREMENTS,
    });
  try {
    observation = input(value);
    const o = observation,
      h = o.rawHeader,
      r = o.rawIncoming;
    for (const k of ['CO_CODE', 'LC_CODE', 'CO_YEAR', 'CO_BOOK', 'VCH_NO', 'AC_CODE', 'HD_VCH_NO'])
      if (typeof h[k] !== 'string' || !h[k] || h[k] !== h[k]!.trim() || h[k] !== r[k])
        fail(
          'scope-conflict',
          'Header and row require the same explicit saved scope and account identity.',
        );
    if (
      h.USER_UPDATE !== 'N' ||
      r.TAG_NO !== 'N' ||
      r.ENTRY_TYPE !== 'P' ||
      r.INOUT_TYPE !== 'I' ||
      numeric(r.SR_NO).toFixed() !== '1' ||
      numeric(r.OLD_SRNO).toFixed() !== '1' ||
      r.RATE_TYPE !== 'N' ||
      r.LBR_TYPE !== 'N' ||
      !numeric(r.ITM_MRP).isZero() ||
      !numeric(r.TAX_PRC).isZero() ||
      ![null, '', 'N'].includes(r.APR_ISU === undefined ? 'missing' : r.APR_ISU) ||
      ![null, '', 'N'].includes(r.EMP_ISU === undefined ? 'missing' : r.EMP_ISU)
    )
      fail(
        'unsupported-profile',
        'This separate candidate requires the saved N, P/I, SR1/OLD1, ordinary no-MRP/no-tax incoming profile.',
      );
    for (const k of [
      'NET_AMT',
      'TOT_AMT',
      'CHQ_AMT',
      'CARD_AMT',
      'CASH_AMT',
      'KASAR_AMT',
      'BILL_OS',
      'RTN_CHQ_AMT',
      'RTN_CARD_AMT',
      'RTN_CASH_AMT',
      'RTN_KASAR_AMT',
      'TAX_PRC',
      'TAX_AMT',
      'IGST_TAX',
      'CGST_TAX',
      'SGST_TAX',
    ])
      if (!numeric(h[k]).isZero())
        fail(
          'unsupported-header-profile',
          'Received amounts, all tenders, kasar and header tax must be explicitly zero.',
        );
    const oldFloat = qualifySaleReturnHeaderFloat({
      RTN_NET_AMT: h.RTN_NET_AMT,
      RTN_TOT_AMT: h.RTN_TOT_AMT,
      RTN_BILL_OS: h.RTN_BILL_OS,
    });
    if (oldFloat.status !== 'ready')
      fail(
        'header-storage',
        'The three saved Return amounts require the exact binary64 storage profile.',
      );
    const projected = projectSavedSaleReturnIncoming({
      rowIdentity: o.rowIdentity,
      ordinal: 1,
      raw: r,
      itemMasters: o.itemMasters,
    });
    if (projected.status !== 'ready')
      fail('saved-row-projection', projected.diagnostics[0]!.message);
    const header = projectSavedSaleReturnBill({ raw: h, labels: o.labels });
    if (header.status !== 'ready') fail('saved-header-projection', header.diagnostics[0]!.message);
    loaded = { row: projected.state, incomingTotals: blankTotals(), bill: header.state };
    const rows = [{ ordinal: 1, state: projected.state }];
    const folded = aggregateSaleReturnIncoming(rows, loaded.incomingTotals, false);
    if (folded.status !== 'applied') fail('open-fold', 'The complete incoming grid did not fold.');
    const context = {
      taxRoundingDecimals: o.taxRoundingDecimals,
      editOpen: false,
      upDown: false,
      openingBalance: {
        status: 'unavailable' as const,
        reason: 'Customer balance requires a resolved ledger mode.',
      },
    };
    const billed = calculateSaleReturnBill(header.state, folded.state.cells[38]!, '0.00', context);
    if (billed.status !== 'applied') fail('open-bill', billed.diagnostic.message);
    const created = createSaleReturnIncomingAggregateState({
      raw: h,
      rows,
      totals: folded.state,
      bill: billed.state,
      outgoingTotal24: '0.00',
    });
    if (created.status !== 'ready') fail('open-state', created.diagnostic.message);
    let state = created.state;
    current = opened = phase(state);
    const candidateFor = (p: SaleReturnOtherAmountPhase) => {
      if (numeric(p.bill.incomingRounded).isZero())
        fail('nonpositive-return', 'The rounded return amount is zero at this prefix.');
      const mapped = projectSaleReturnIncomingSave({
        rowIdentity: o.rowIdentity,
        ordinal: 1,
        raw: r,
        visible: p.row.visible as Record<string, string>,
      });
      if (mapped.status !== 'ready') fail('row-save-projection', mapped.diagnostics[0]!.message);
      if (
        !numeric(p.bill.incomingRounded).gt(0) ||
        numeric(p.bill.matrix[1]![4] || '0').gt(0) ||
        !numeric(p.bill.matrix[3]![3]).gt(0) ||
        !numeric(p.bill.matrix[8]![3]).gt(0)
      )
        fail(
          'nonpositive-return',
          'Every admitted prefix must retain a positive return-only bill.',
        );
      const c = p.incomingTotals.cells;
      if (
        numeric(c[28]).isZero() &&
        numeric(c[9]).plus(numeric(c[12])).plus(numeric(c[27])).isZero()
      )
        fail('bar-header-membership', 'This edit would remove the source BAR header.');
      const projectedHeader = {
        RTN_NET_AMT: p.bill.incomingRounded,
        RTN_TOT_AMT: p.bill.matrix[3]![3]!,
        RTN_BILL_OS: p.bill.matrix[8]![3]!,
      };
      const stored = qualifySaleReturnHeaderFloat(projectedHeader);
      if (stored.status !== 'ready')
        fail(
          'header-storage',
          'The three candidate Return amounts require exact binary64 storage.',
        );
      const headerPatch: Partial<Record<keyof typeof projectedHeader, string>> = {};
      for (const k of Object.keys(projectedHeader) as Array<keyof typeof projectedHeader>)
        if (!numeric(h[k]).eq(numeric(projectedHeader[k])))
          headerPatch[k] = numeric(projectedHeader[k]).toFixed();
      return {
        linePatch: mapped.candidatePatch,
        headerPatch,
        afterIncoming: { ...r, ...mapped.candidatePatch },
        afterHeader: { ...h, ...headerPatch },
        hasLineOrHeaderChanges:
          Object.keys(mapped.candidatePatch).length + Object.keys(headerPatch).length > 0,
      };
    };
    if (candidateFor(opened).hasLineOrHeaderChanges)
      fail('saved-open-drift', 'Opening the saved row already changes an owned numeric value.');
    for (const [i, text] of o.events.entries()) {
      eventIndex = i;
      const replayed = reduceSaleReturnIncomingAggregate(
        state,
        {
          kind: 'leaveCell',
          rowIdentity: o.rowIdentity,
          column: 27,
          text,
          context: {
            currentRow: 1,
            clearing: false,
            editorVisible: true,
            committedColumnWidth: o.c27ColumnWidth,
          },
        },
        o.rowPolicy,
        context,
      );
      if (replayed.status !== 'applied')
        fail(
          'event-calculation',
          replayed.status === 'rejected' ? replayed.diagnostic.message : replayed.reason,
        );
      state = replayed.state;
      current = phase(state);
      prefixes.push(current);
      candidateFor(current);
    }
    eventIndex = undefined;
    // BtnSave12375–12379: refresh incoming totals only. No second BILL_TOTAL.
    const finalFold = aggregateSaleReturnIncoming(state.rows, state.totals, false);
    if (finalFold.status !== 'applied') fail('save-fold', 'The final Save fold failed.');
    saveFold = finalFold.state;
    current = { ...current, incomingTotals: saveFold };
    return result('ready', candidateFor(current), []);
  } catch (error) {
    if (!(error instanceof Refusal)) throw error;
    return result('unsupported', null, [
      {
        code: error.code,
        message: error.message,
        ...(eventIndex === undefined ? {} : { eventIndex }),
      },
    ]);
  }
}
