import { Decimal } from 'decimal.js';
import { decimalCellText, roundHalfEvenDecimal } from './money.js';
import {
  reduceSaleReturnIncoming,
  type SaleReturnIncomingEvent,
  type SaleReturnIncomingPolicy,
  type SaleReturnIncomingRaw,
  type SaleReturnIncomingState,
} from './saleReturnIncoming.js';

/** Primary TR_SALE_RTN MSG_PR_TOT_FILL5162–5202 and BILL_TOTAL16381–16458.
 * Exact-decimal mathematical preview, not measured Windows Double/Val/Format
 * equivalence. This pure boundary does not resolve settings, load a saved form,
 * calculate outgoing rows, read a ledger, or authorize any business write.
 */
export const SALE_RETURN_INCOMING_AGGREGATE_VERSION = 'primary-incoming-aggregate-decimal-v1';
export const SALE_RETURN_INCOMING_AGGREGATE_COLUMNS = Object.freeze(
  [
    [9, 0],
    [10, 3],
    [11, 3],
    [12, 3],
    [15, 3],
    [18, 3],
    [20, 2],
    [24, 2],
    [27, 2],
    [42, 3],
    [28, 2],
    [36, 2],
    [38, 2],
    [35, 2],
  ].map(([column, places]) => Object.freeze({ column: column!, places: places! })),
);

export interface SaleReturnIncomingAggregateRow {
  readonly ordinal: number;
  readonly state: SaleReturnIncomingState;
}
export interface SaleReturnIncomingTotalsState {
  /** All 71 primary grid columns, including the retained c0 and cleared caches. */
  readonly cells: Readonly<Record<number, string>>;
  readonly totCrFine: string;
  readonly prOthAmtLess: string;
}
export type SaleReturnOpeningBalance =
  | { readonly status: 'resolved'; readonly amount: string; readonly observationIdentity: string }
  | { readonly status: 'unavailable'; readonly reason: string };
export type SaleReturnClosingBalance =
  | {
      readonly status: 'resolved';
      readonly amount: string;
      readonly label: string;
      readonly color: string;
    }
  | {
      readonly status: 'unavailable';
      readonly amount: null;
      readonly label: null;
      readonly color: string;
      readonly reason: string;
    };
export interface SaleReturnBillState {
  /** Exact source nine rows by six columns. Unwritten cells retain their text. */
  readonly matrix: readonly (readonly string[])[];
  /** Numeric source caches use canonical decimal strings after replacement. */
  readonly oldNetAmt: string;
  readonly oldTaxPrc: string;
  readonly outgoingRounded: string;
  readonly incomingRounded: string;
  readonly closing: SaleReturnClosingBalance;
}
export interface SaleReturnBillContext {
  /** Already resolved trusted MS_OPNCOMP setting, never a client override. */
  readonly taxRoundingDecimals: number;
  readonly editOpen: boolean;
  readonly openingBalance: SaleReturnOpeningBalance;
}
export interface SaleReturnIncomingAggregateContext extends SaleReturnBillContext {
  readonly upDown: boolean;
}
export interface SaleReturnAggregateDiagnostic {
  readonly code:
    | 'invalid-state'
    | 'invalid-decimal'
    | 'unsupported-precision'
    | 'invalid-context'
    | 'invalid-row-order'
    | 'row-identity-conflict'
    | 'row-calculation-rejected';
  readonly stage: string;
  readonly message: string;
  readonly rowIdentity?: string;
  readonly column?: number;
}
export type SaleReturnIncomingTotalsResult =
  | { readonly status: 'applied'; readonly state: SaleReturnIncomingTotalsState }
  | {
      readonly status: 'skipped';
      readonly state: SaleReturnIncomingTotalsState;
      readonly reason: string;
    }
  | {
      readonly status: 'rejected';
      readonly state: SaleReturnIncomingTotalsState;
      readonly diagnostic: SaleReturnAggregateDiagnostic;
    };
export type SaleReturnBillResult =
  | {
      readonly status: 'applied';
      readonly state: SaleReturnBillState;
      readonly taxRecalculated: boolean;
    }
  | {
      readonly status: 'rejected';
      readonly state: SaleReturnBillState;
      readonly diagnostic: SaleReturnAggregateDiagnostic;
    };
export interface SaleReturnIncomingAggregateJournalEntry {
  readonly event: SaleReturnIncomingEvent;
  readonly rowPolicy: Readonly<SaleReturnIncomingPolicy>;
  readonly context: SaleReturnIncomingAggregateContext;
  readonly rowCalculated: boolean;
  readonly aggregateApplied: boolean;
  readonly billApplied: boolean;
  readonly taxRecalculated: boolean;
}
export interface SaleReturnIncomingAggregateState {
  readonly version: typeof SALE_RETURN_INCOMING_AGGREGATE_VERSION;
  readonly raw: SaleReturnIncomingRaw;
  readonly rows: readonly SaleReturnIncomingAggregateRow[];
  readonly totals: SaleReturnIncomingTotalsState;
  readonly bill: SaleReturnBillState;
  readonly outgoingTotal24: string;
  readonly journal: readonly SaleReturnIncomingAggregateJournalEntry[];
}
export interface SaleReturnIncomingAggregateInput {
  readonly raw: SaleReturnIncomingRaw;
  readonly rows: readonly SaleReturnIncomingAggregateRow[];
  readonly totals: SaleReturnIncomingTotalsState;
  readonly bill: SaleReturnBillState;
  /** Callback input only. Outgoing projection/admission remains a separate task. */
  readonly outgoingTotal24: string;
}
export type SaleReturnIncomingAggregateCreation =
  | { readonly status: 'ready'; readonly state: SaleReturnIncomingAggregateState }
  | { readonly status: 'unsupported'; readonly diagnostic: SaleReturnAggregateDiagnostic };
export type SaleReturnIncomingAggregateResult =
  | {
      readonly status: 'applied';
      readonly state: SaleReturnIncomingAggregateState;
      readonly aggregateApplied: boolean;
      readonly billApplied: boolean;
    }
  | {
      readonly status: 'skipped';
      readonly state: SaleReturnIncomingAggregateState;
      readonly reason: string;
    }
  | {
      readonly status: 'rejected';
      readonly state: SaleReturnIncomingAggregateState;
      readonly diagnostic: SaleReturnAggregateDiagnostic;
      readonly attemptedEvent: SaleReturnIncomingEvent;
    };

const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
const CACHE_COLUMNS = new Set([45, 46, 47, 48, 49, 58, 66, 67]);
const record = (value: unknown): value is Record<string, unknown> =>
  value !== null &&
  typeof value === 'object' &&
  !Array.isArray(value) &&
  (Object.getPrototypeOf(value) === Object.prototype || Object.getPrototypeOf(value) === null);
class AggregateFailure extends Error {
  constructor(readonly diagnostic: SaleReturnAggregateDiagnostic) {
    super(diagnostic.message);
  }
}
function fail(
  code: SaleReturnAggregateDiagnostic['code'],
  stage: string,
  message: string,
  column?: number,
  rowIdentity?: string,
): never {
  throw new AggregateFailure(
    Object.freeze({
      code,
      stage,
      message,
      ...(column === undefined ? {} : { column }),
      ...(rowIdentity === undefined ? {} : { rowIdentity }),
    }),
  );
}
function snapshot<T>(value: T): T {
  if (Array.isArray(value)) return Object.freeze(value.map(snapshot)) as T;
  if (record(value))
    return Object.freeze(
      Object.fromEntries(Object.entries(value).map(([key, cell]) => [key, snapshot(cell)])),
    ) as T;
  return value;
}
function stringRecord(value: unknown, nullable = false): boolean {
  return (
    record(value) &&
    Object.values(value).every((cell) => typeof cell === 'string' || (nullable && cell === null))
  );
}
function validateTotals(state: SaleReturnIncomingTotalsState): void {
  if (
    !record(state) ||
    !stringRecord(state.cells) ||
    Object.keys(state.cells).length !== 71 ||
    Array.from({ length: 71 }, (_, c) => c).some(
      (c) => !Object.hasOwn(state.cells, c) || typeof state.cells[c] !== 'string',
    ) ||
    typeof state.totCrFine !== 'string' ||
    typeof state.prOthAmtLess !== 'string'
  )
    fail(
      'invalid-state',
      'incoming totals',
      'Complete primary 71-column totals and exact counter strings are required.',
    );
}
function validateRows(rows: readonly SaleReturnIncomingAggregateRow[]): void {
  if (!Array.isArray(rows) || rows.length > 10000)
    fail(
      'invalid-state',
      'incoming rows',
      'An ordered primary grid of at most 10000 rows is required.',
    );
  const identities = new Set<string>();
  for (const [index, row] of rows.entries()) {
    if (!record(row) || !record(row.state))
      fail('invalid-state', 'incoming rows', 'Each row requires its own complete state.');
    const state = row.state as unknown as SaleReturnIncomingState;
    if (
      typeof state.rowIdentity !== 'string' ||
      !state.rowIdentity.trim() ||
      identities.has(state.rowIdentity)
    )
      fail(
        'row-identity-conflict',
        'incoming rows',
        'Incoming row identities must be nonblank and unique.',
      );
    identities.add(state.rowIdentity);
    if (
      row.ordinal !== index + 1 ||
      !record(state.visible) ||
      state.visible[0] !== String(row.ordinal)
    )
      fail(
        'invalid-row-order',
        'incoming rows',
        'Rows must retain their explicit contiguous source grid order.',
        undefined,
        state.rowIdentity,
      );
    if (
      !stringRecord(state.raw, true) ||
      !stringRecord(state.visible) ||
      !stringRecord(state.caches) ||
      Object.keys(state.visible).length !== 63 ||
      Object.keys(state.caches).length !== 8 ||
      Array.from({ length: 71 }, (_, c) => c).some(
        (c) =>
          typeof (CACHE_COLUMNS.has(c)
            ? state.caches[c as keyof typeof state.caches]
            : state.visible[c]) !== 'string',
      ) ||
      !Array.isArray(state.journal)
    )
      fail(
        'invalid-state',
        'incoming rows',
        'A complete projected row with all eight comparison caches is required.',
        undefined,
        state.rowIdentity,
      );
  }
}
function validateBill(state: SaleReturnBillState): void {
  if (
    !record(state) ||
    !Array.isArray(state.matrix) ||
    state.matrix.length !== 9 ||
    Array.from(state.matrix).some(
      (row) =>
        !Array.isArray(row) ||
        row.length !== 6 ||
        Array.from(row).some((cell) => typeof cell !== 'string'),
    ) ||
    typeof state.oldNetAmt !== 'string' ||
    typeof state.oldTaxPrc !== 'string' ||
    typeof state.outgoingRounded !== 'string' ||
    typeof state.incomingRounded !== 'string' ||
    !record(state.closing) ||
    typeof state.closing.color !== 'string' ||
    (state.closing.status === 'resolved'
      ? typeof state.closing.amount !== 'string' || typeof state.closing.label !== 'string'
      : state.closing.status !== 'unavailable' ||
        state.closing.amount !== null ||
        state.closing.label !== null ||
        typeof state.closing.reason !== 'string')
  )
    fail(
      'invalid-state',
      'bill matrix',
      'The complete nine-by-six bill matrix, caches and closing-display state are required.',
    );
}
function validateContext(context: SaleReturnBillContext): void {
  if (
    !record(context) ||
    typeof context.editOpen !== 'boolean' ||
    !Number.isInteger(context.taxRoundingDecimals) ||
    context.taxRoundingDecimals < 0 ||
    context.taxRoundingDecimals > 5 ||
    !record(context.openingBalance)
  )
    fail(
      'invalid-context',
      'bill context',
      'Resolve the source phase and supported tax-rounding setting before calculating.',
    );
  const opening = context.openingBalance;
  if (opening.status === 'resolved') {
    if (
      typeof opening.amount !== 'string' ||
      typeof opening.observationIdentity !== 'string' ||
      !opening.observationIdentity.trim()
    )
      fail(
        'invalid-context',
        'opening balance',
        'A resolved opening amount requires an explicit trusted observation identity.',
      );
  } else if (
    opening.status !== 'unavailable' ||
    typeof opening.reason !== 'string' ||
    !opening.reason.trim()
  )
    fail(
      'invalid-context',
      'opening balance',
      'Opening balance must be explicitly resolved or unavailable with a reason.',
    );
}
function numeric(value: string, stage: string, column?: number, rowIdentity?: string): Decimal {
  // Ordinary spaces/blank are in this declared profile. Val prefix parsing,
  // exponent/culture/hex, numeric NULL and control-character behavior are not.
  if (
    typeof value !== 'string' ||
    value.length > 128 ||
    /[^\x20-\x7e]/.test(value) ||
    !/^ *(?:[+-]?(?:\d+(?:\.\d*)?|\.\d+))? *$/.test(value)
  )
    fail(
      'invalid-decimal',
      stage,
      'A finite plain decimal string is required.',
      column,
      rowIdentity,
    );
  const decimal = new D(value.trim() || '0');
  if (decimal.precision() > 36 || decimal.decimalPlaces() > 18 || decimal.abs().gte('1e36'))
    fail(
      'unsupported-precision',
      stage,
      'The value exceeds the declared 36-significant-digit, 18-place decimal input profile.',
      column,
      rowIdentity,
    );
  return decimal;
}
function formatted(value: Decimal, places: number, stage: string): string {
  const text = decimalCellText(value, places);
  const result = new D(text);
  if (!value.isFinite() || result.abs().gte('1e36') || result.precision() > 36)
    fail('unsupported-precision', stage, 'The calculation exceeds the supported result range.');
  return text;
}
function canonical(value: Decimal, stage: string): string {
  if (
    !value.isFinite() ||
    value.abs().gte('1e36') ||
    value.precision() > 36 ||
    value.decimalPlaces() > 18
  )
    fail('unsupported-precision', stage, 'The calculation exceeds the supported result range.');
  return value.toFixed();
}

/** Source5162–5202. Fold in source row order, formatting after EVERY addition.
 * UpDown skips all numeric reads/resetting. No source item/tag/sign filter exists.
 * Structural validation prevents an incomplete or ambiguously ordered grid from
 * acquiring preview authority, including on the skipped path.
 */
export function aggregateSaleReturnIncoming(
  rows: readonly SaleReturnIncomingAggregateRow[],
  previous: SaleReturnIncomingTotalsState,
  upDown: boolean,
): SaleReturnIncomingTotalsResult {
  try {
    validateTotals(previous);
    validateRows(rows);
    if (typeof upDown !== 'boolean')
      fail('invalid-context', 'aggregate guard', 'The source UpDown phase is required.');
    if (upDown)
      return {
        status: 'skipped',
        state: previous,
        reason: 'The source UpDown guard retains all previous totals and counters.',
      };
    const cells: Record<number, string> = Object.fromEntries(
      Array.from({ length: 71 }, (_, c) => [c, c === 0 ? previous.cells[0]! : '']),
    );
    cells[5] = 'Total :';
    for (const row of rows) {
      for (const { column, places } of SALE_RETURN_INCOMING_AGGREGATE_COLUMNS) {
        cells[column] = formatted(
          numeric(cells[column]!, 'running incoming total', column).plus(
            numeric(row.state.visible[column]!, 'incoming row', column, row.state.rowIdentity),
          ),
          places,
          'running incoming total',
        );
      }
    }
    return { status: 'applied', state: snapshot({ cells, totCrFine: '0', prOthAmtLess: '0' }) };
  } catch (error) {
    if (!(error instanceof AggregateFailure)) throw error;
    return { status: 'rejected', state: previous, diagnostic: error.diagnostic };
  }
}

/** Source16381–16458. This is a callback simulation from trusted phase inputs.
 * It never derives a ledger opening, tender permission, tax master or save DTO.
 * Missing opening information only makes closing unavailable; it is not zero.
 */
export function calculateSaleReturnBill(
  previous: SaleReturnBillState,
  incomingTotal38: string,
  outgoingTotal24: string,
  context: SaleReturnBillContext,
): SaleReturnBillResult {
  try {
    validateBill(previous);
    validateContext(context);
    const matrix = previous.matrix.map((row) => [...row]);
    const get = (row: number, column: number) =>
      numeric(matrix[row]![column]!, 'bill matrix r' + row, column);
    const put = (row: number, column: number, value: Decimal) => {
      matrix[row]![column] = formatted(value, 2, 'bill matrix r' + row);
    };
    // Return to local D after each shared Math.Round primitive; subsequent
    // arithmetic must not inherit Decimal's global/default precision20.
    const rounded = (value: Decimal, places: number) => new D(roundHalfEvenDecimal(value, places));
    const outgoingRounded = formatted(
      rounded(numeric(outgoingTotal24, 'outgoing total c24'), 0),
      2,
      'outgoing rounded',
    );
    const incomingRounded = formatted(
      rounded(numeric(incomingTotal38, 'incoming total c38'), 0),
      2,
      'incoming rounded',
    );
    const difference = new D(incomingRounded).minus(outgoingRounded);
    if (difference.lt(0)) {
      put(1, 4, difference.abs());
      matrix[1]![3] = '';
    } else {
      put(1, 3, difference);
      matrix[1]![4] = '';
    }
    const net = get(1, 3);
    const percent = get(2, 2);
    const priorNet = numeric(previous.oldNetAmt, 'old net cache');
    const priorPercent = numeric(previous.oldTaxPrc, 'old tax cache');
    const taxRecalculated = !net.eq(priorNet) || !percent.eq(priorPercent);
    let oldNetAmt = previous.oldNetAmt;
    let oldTaxPrc = previous.oldTaxPrc;
    if (taxRecalculated) {
      oldNetAmt = canonical(new D(formatted(net, 2, 'old net cache')), 'old net cache');
      oldTaxPrc = canonical(new D(formatted(percent, 2, 'old tax cache')), 'old tax cache');
      put(2, 3, rounded(net.times(percent).div(100), context.taxRoundingDecimals));
    }
    put(3, 4, get(1, 4));
    put(3, 3, rounded(get(1, 3).plus(get(2, 3)), 0));
    for (const column of [3, 4])
      put(
        8,
        column,
        get(3, column)
          .minus(get(6, column))
          .minus(get(4, column))
          .minus(get(5, column))
          .minus(get(7, column)),
      );
    if (!context.editOpen) {
      const inactive = difference.lt(0) ? 3 : 4;
      for (let row = 2; row <= 8; row++) matrix[row]![inactive] = '';
    }
    let closing: SaleReturnClosingBalance;
    if (context.openingBalance.status === 'unavailable') {
      closing = {
        status: 'unavailable',
        amount: null,
        label: null,
        color: previous.closing.color,
        reason: context.openingBalance.reason,
      };
    } else {
      const opening = numeric(context.openingBalance.amount, 'opening balance');
      // Source's three explicit branches, after inactive-side clearing.
      const amount = opening.gt(0)
        ? opening.plus(get(8, 3)).minus(get(8, 4))
        : opening.lt(0)
          ? get(8, 3).minus(opening.abs().plus(get(8, 4)))
          : get(8, 3).minus(get(8, 4));
      closing = {
        status: 'resolved',
        amount: canonical(amount, 'closing balance'),
        label: amount.gt(0)
          ? formatted(amount, 2, 'closing label') + ' : Cr Amt'
          : amount.lt(0)
            ? formatted(amount.abs(), 2, 'closing label') + ' : Dr Amt'
            : ': Amt',
        color: amount.gt(0) ? 'blue' : amount.lt(0) ? 'red' : previous.closing.color,
      };
    }
    return {
      status: 'applied',
      taxRecalculated,
      state: snapshot({ matrix, oldNetAmt, oldTaxPrc, outgoingRounded, incomingRounded, closing }),
    };
  } catch (error) {
    if (!(error instanceof AggregateFailure)) throw error;
    return { status: 'rejected', state: previous, diagnostic: error.diagnostic };
  }
}

function validateAggregateInput(input: SaleReturnIncomingAggregateInput): void {
  if (!record(input) || !stringRecord(input.raw, true) || typeof input.outgoingTotal24 !== 'string')
    fail(
      'invalid-state',
      'aggregate state',
      'Exact raw header observations and an explicit outgoing total are required.',
    );
  validateRows(input.rows);
  validateTotals(input.totals);
  validateBill(input.bill);
}

/** Copies a complete caller-observed phase without recalculating any row/header.
 * In particular this does not simulate the desktop saved-open outgoing callback.
 */
export function createSaleReturnIncomingAggregateState(
  input: SaleReturnIncomingAggregateInput,
): SaleReturnIncomingAggregateCreation {
  try {
    validateAggregateInput(input);
    return {
      status: 'ready',
      state: snapshot({
        version: SALE_RETURN_INCOMING_AGGREGATE_VERSION,
        raw: input.raw,
        rows: input.rows,
        totals: input.totals,
        bill: input.bill,
        outgoingTotal24: input.outgoingTotal24,
        journal: [],
      }),
    };
  } catch (error) {
    if (!(error instanceof AggregateFailure)) throw error;
    return { status: 'unsupported', diagnostic: error.diagnostic };
  }
}

/** A genuine calculated row event runs row -> incoming fold -> BILL_TOTAL before
 * the next event. Downstream failures retain the very same entire prior state,
 * including raw data, every row/cache, tenders, totals and both journals.
 * No client-provided state/context is authoritative merely because it is typed.
 */
export function reduceSaleReturnIncomingAggregate(
  state: SaleReturnIncomingAggregateState,
  event: SaleReturnIncomingEvent,
  rowPolicy: SaleReturnIncomingPolicy,
  context: SaleReturnIncomingAggregateContext,
): SaleReturnIncomingAggregateResult {
  try {
    validateAggregateInput(state);
    if (state.version !== SALE_RETURN_INCOMING_AGGREGATE_VERSION || !Array.isArray(state.journal))
      fail(
        'invalid-state',
        'aggregate state',
        'A current versioned aggregate state and journal are required.',
      );
    if (!record(event) || typeof event.rowIdentity !== 'string')
      fail(
        'row-identity-conflict',
        'event',
        'The event must name a complete incoming row identity.',
      );
    const index = state.rows.findIndex((row) => row.state.rowIdentity === event.rowIdentity);
    if (index < 0)
      fail('row-identity-conflict', 'event', 'The event belongs to a different incoming row.');
    const row = state.rows[index]!;
    if (!record(rowPolicy))
      fail(
        'invalid-context',
        'row policy',
        'An explicit resolved row calculation policy is required.',
      );
    const result = reduceSaleReturnIncoming(row.state, event, rowPolicy);
    if (result.status === 'skipped') return { status: 'skipped', state, reason: result.reason };
    if (result.status === 'rejected')
      fail(
        'row-calculation-rejected',
        result.diagnostic.stage,
        result.diagnostic.message,
        result.diagnostic.column ?? undefined,
        row.state.rowIdentity,
      );
    if (event.kind === 'leaveCell' && event.context.currentRow !== row.ordinal)
      fail(
        'invalid-row-order',
        'event',
        'The active source row ordinal does not match the named row.',
        event.column,
        row.state.rowIdentity,
      );
    validateContext(context);
    if (typeof context.upDown !== 'boolean')
      fail('invalid-context', 'aggregate guard', 'The source UpDown phase is required.');
    const rows = state.rows.map((item, i) =>
      i === index ? Object.freeze({ ordinal: item.ordinal, state: result.state }) : item,
    );
    // Even a text-only row edit must preserve this composition's identity/order
    // contract. The row kernel alone also exposes source ordinal c0 as text.
    validateRows(rows);
    let totals = state.totals;
    let bill = state.bill;
    let aggregateApplied = false;
    let taxRecalculated = false;
    if (result.aggregateRequired) {
      const aggregate = aggregateSaleReturnIncoming(rows, state.totals, context.upDown);
      if (aggregate.status === 'rejected') throw new AggregateFailure(aggregate.diagnostic);
      totals = aggregate.state;
      aggregateApplied = aggregate.status === 'applied';
      const calculatedBill = calculateSaleReturnBill(
        state.bill,
        totals.cells[38]!,
        state.outgoingTotal24,
        context,
      );
      if (calculatedBill.status === 'rejected')
        throw new AggregateFailure(calculatedBill.diagnostic);
      bill = calculatedBill.state;
      taxRecalculated = calculatedBill.taxRecalculated;
    }
    return {
      status: 'applied',
      aggregateApplied,
      billApplied: result.aggregateRequired,
      state: Object.freeze({
        ...state,
        rows: Object.freeze(rows),
        totals,
        bill,
        journal: Object.freeze([
          ...state.journal,
          snapshot({
            event,
            rowPolicy,
            context,
            rowCalculated: result.aggregateRequired,
            aggregateApplied,
            billApplied: result.aggregateRequired,
            taxRecalculated,
          }),
        ]),
      }),
    };
  } catch (error) {
    if (!(error instanceof AggregateFailure)) throw error;
    return {
      status: 'rejected',
      state,
      diagnostic: error.diagnostic,
      attemptedEvent: snapshot(event),
    };
  }
}
