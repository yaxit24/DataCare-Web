import { Decimal } from 'decimal.js';
import { decimalCellText, roundHalfEvenDecimal } from './money.js';

/** Primary TR_SALE_RTN MSG_PR only, immediately before its aggregate callbacks.
 * Source: LeaveCell4592–4664 and CommPassTotal_Pr4866–5160. Mathematical decimal
 * interpretation, not an assertion of unmeasured Double/Format runtime parity.
 * Nothing in this module authorizes a saved numeric, stock or financial write.
 */
const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
const CACHE_SOURCE = { 45: 10, 46: 12, 47: 16, 48: 17, 49: 19, 58: 23, 66: 21, 67: 37 } as const;
export type SaleReturnIncomingCacheColumn = keyof typeof CACHE_SOURCE;
export type SaleReturnIncomingCells = Readonly<Partial<Record<number, string>>>;
export type SaleReturnIncomingRaw = Readonly<Record<string, string | null>>;
export interface SaleReturnIncomingPolicy {
  saleAmountType: string;
  labourRoundingDecimals: number;
  labourIncludesGhat: boolean;
  generateLabourRate: boolean;
  /** Actual configured get_ColWidth(18), proven by original assembly IL0661.
   * Never infer this from the cell value or responsive browser CSS. */
  fineColumnWidth: number | null;
}
export interface SaleReturnIncomingLeaveContext {
  currentRow: number;
  clearing: boolean;
  editorVisible: boolean;
  /** Actual get_ColWidth(activeColumn), original assembly IL0038. */
  committedColumnWidth: number | null;
}
export type SaleReturnIncomingEvent =
  | {
      kind: 'leaveCell';
      rowIdentity: string;
      column: number;
      text: string;
      context: SaleReturnIncomingLeaveContext;
    }
  | {
      kind: 'calculateAfterCopy';
      rowIdentity: string;
      activeColumn: number;
      editorText: string;
      cause: 'sourceSelection' | 'labourCodeSelection' | 'tagLabourCodeSelection';
    };
export interface SaleReturnIncomingJournalEntry {
  readonly event: SaleReturnIncomingEvent;
  readonly calculated: boolean;
  readonly policy: Readonly<SaleReturnIncomingPolicy>;
}
export interface SaleReturnIncomingState {
  /** Opaque complete saved/source identity; never a visual row position. */
  readonly rowIdentity: string;
  readonly raw: SaleReturnIncomingRaw;
  readonly visible: SaleReturnIncomingCells;
  readonly caches: Readonly<Record<SaleReturnIncomingCacheColumn, string>>;
  readonly journal: readonly SaleReturnIncomingJournalEntry[];
}
export type SaleReturnIncomingDiagnosticCode =
  | 'invalid-decimal'
  | 'unsupported-precision'
  | 'zero-denominator'
  | 'invalid-policy'
  | 'missing-column-width'
  | 'invalid-event'
  | 'row-identity-conflict'
  | 'unsupported-item-admission';
export interface SaleReturnIncomingDiagnostic {
  readonly code: SaleReturnIncomingDiagnosticCode;
  readonly message: string;
  readonly stage: string;
  readonly column: number | null;
  readonly recoverable: true;
}
export type SaleReturnIncomingResult =
  | { status: 'applied'; state: SaleReturnIncomingState; aggregateRequired: boolean }
  | { status: 'skipped'; state: SaleReturnIncomingState; aggregateRequired: false; reason: string }
  | {
      status: 'rejected';
      state: SaleReturnIncomingState;
      aggregateRequired: false;
      diagnostic: SaleReturnIncomingDiagnostic;
      attemptedEvent: SaleReturnIncomingEvent;
    };

const TEXT_COLUMNS = new Set([0, 2, 3, 4, 5, 6, 7, 8, 13, 22, 29, 39]);
const TWO_COLUMNS = new Set([
  14, 16, 17, 19, 20, 21, 23, 24, 25, 26, 27, 28, 30, 31, 32, 33, 34, 35, 36, 37, 38, 41,
]);
const THREE_COLUMNS = new Set([10, 11, 12, 15, 18, 42]);
const cacheColumn = (column: number): column is SaleReturnIncomingCacheColumn =>
  Object.hasOwn(CACHE_SOURCE, column);

/** Input cells are already projected visible strings. Preserve their exact text,
 * including blank, and preserve the raw SQL snapshot separately. Saved hydration
 * seeds only the source's eight comparison caches: it does not calculate a row.
 * `provided` is required for a new or post-copy grid snapshot with existing caches.
 */
export function createSaleReturnIncomingState(input: {
  rowIdentity: string;
  raw: SaleReturnIncomingRaw;
  cells: SaleReturnIncomingCells;
  cacheMode: 'saved' | 'provided';
}): SaleReturnIncomingState {
  const visible: Partial<Record<number, string>> = {};
  for (const [column, value] of Object.entries(input.cells)) {
    if (!cacheColumn(Number(column))) visible[Number(column)] = value;
  }
  const caches = {} as Record<SaleReturnIncomingCacheColumn, string>;
  for (const key of Object.keys(CACHE_SOURCE)) {
    const column = Number(key) as SaleReturnIncomingCacheColumn;
    caches[column] = input.cells[input.cacheMode === 'saved' ? CACHE_SOURCE[column] : column] ?? '';
  }
  return Object.freeze({
    rowIdentity: input.rowIdentity,
    raw: Object.freeze({ ...input.raw }),
    visible: Object.freeze(visible),
    caches: Object.freeze(caches),
    journal: Object.freeze([]),
  });
}

/** Source-indexed read projection for diagnostics/tests, not a persistence DTO. */
export function saleReturnIncomingCells(state: SaleReturnIncomingState): SaleReturnIncomingCells {
  return Object.freeze({ ...state.visible, ...state.caches });
}

class CalculationFailure extends Error {
  constructor(
    readonly code: SaleReturnIncomingDiagnosticCode,
    message: string,
    readonly stage: string,
    readonly column: number | null = null,
  ) {
    super(message);
  }
}
function readDecimal(
  value: string | undefined,
  stage: string,
  column: number | null = null,
): Decimal {
  const text = value ?? '';
  if (text.trim() === '') return new D(0);
  // Deliberate containment: no prefix Val parsing, culture, hex, NaN or infinity guesses.
  if (text.length > 128 || !/^\s*[+-]?(?:\d+(?:\.\d*)?|\.\d+)\s*$/.test(text)) {
    throw new CalculationFailure(
      'invalid-decimal',
      'Use a finite plain decimal value; the draft was retained.',
      stage,
      column,
    );
  }
  const decimal = new D(text.trim());
  if (decimal.sd() > 36 || decimal.decimalPlaces() > 18 || decimal.abs().gte('1e36')) {
    throw new CalculationFailure(
      'unsupported-precision',
      'This calculation exceeds the supported decimal input range; the draft was retained.',
      stage,
      column,
    );
  }
  return decimal;
}
function formatted(value: Decimal, places: number, stage: string): string {
  if (!value.isFinite() || value.abs().gte('1e60')) {
    throw new CalculationFailure(
      'unsupported-precision',
      'This calculation exceeds the supported decimal result range; the draft was retained.',
      stage,
    );
  }
  return decimalCellText(value, places);
}
function divide(numerator: Decimal, denominator: Decimal, stage: string): Decimal {
  if (denominator.isZero())
    throw new CalculationFailure(
      'zero-denominator',
      'The source expression divides by zero; correct the draft before retrying.',
      stage,
    );
  return numerator.div(denominator);
}
function frozenEvent(event: SaleReturnIncomingEvent): SaleReturnIncomingEvent {
  return Object.freeze(
    event.kind === 'leaveCell'
      ? {
          ...event,
          context:
            event.context && typeof event.context === 'object'
              ? Object.freeze({ ...event.context })
              : event.context,
        }
      : { ...event },
  );
}
function validatePolicy(policy: SaleReturnIncomingPolicy): void {
  if (
    typeof policy.saleAmountType !== 'string' ||
    !Number.isInteger(policy.labourRoundingDecimals) ||
    policy.labourRoundingDecimals < 0 ||
    policy.labourRoundingDecimals > 3 ||
    typeof policy.labourIncludesGhat !== 'boolean' ||
    typeof policy.generateLabourRate !== 'boolean' ||
    (policy.fineColumnWidth !== null &&
      (!Number.isInteger(policy.fineColumnWidth) || policy.fineColumnWidth < 0))
  ) {
    throw new CalculationFailure(
      'invalid-policy',
      'Resolve the source calculation settings before calculating this row.',
      'policy',
    );
  }
  if (policy.saleAmountType === 'F' && policy.fineColumnWidth === null) {
    throw new CalculationFailure(
      'missing-column-width',
      'The configured Fine column width is required for the F amount branch.',
      'metal basis',
      18,
    );
  }
}

/** Every failing event returns the very same prior state, including its journal.
 * The attempted text remains available for an explicit correction/retry. There
 * is no partial calculation, auto-replay, state mutation or aggregate callback.
 * calculateAfterCopy consumes an already resolved copied snapshot; it performs
 * no master/source selection and is not complete F1 or LCode acceptance.
 */
export function reduceSaleReturnIncoming(
  state: SaleReturnIncomingState,
  event: SaleReturnIncomingEvent,
  policy: SaleReturnIncomingPolicy,
): SaleReturnIncomingResult {
  try {
    if (event.rowIdentity !== state.rowIdentity)
      throw new CalculationFailure(
        'row-identity-conflict',
        'The event belongs to a different row.',
        'event',
      );
    const column = event.kind === 'leaveCell' ? event.column : event.activeColumn;
    const text = event.kind === 'leaveCell' ? event.text : event.editorText;
    if (!Number.isInteger(column) || column < 0 || column > 70 || typeof text !== 'string') {
      throw new CalculationFailure(
        'invalid-event',
        'A known source column and original editor text are required.',
        'event',
      );
    }
    const cells: Partial<Record<number, string>> = { ...state.visible, ...state.caches };
    let calculated = event.kind === 'calculateAfterCopy';
    if (event.kind === 'leaveCell') {
      const c = event.context;
      if (
        !c ||
        typeof c !== 'object' ||
        !Number.isInteger(c.currentRow) ||
        c.currentRow < 0 ||
        typeof c.clearing !== 'boolean' ||
        typeof c.editorVisible !== 'boolean'
      ) {
        throw new CalculationFailure(
          'invalid-event',
          'The original leave-cell context is required.',
          'leave guard',
        );
      }
      if (c.clearing || c.currentRow === 0 || !c.editorVisible || c.committedColumnWidth === 0) {
        return {
          status: 'skipped',
          state,
          aggregateRequired: false,
          reason: 'The source leave-cell guard suppresses this event.',
        };
      }
      if (c.committedColumnWidth === null)
        throw new CalculationFailure(
          'missing-column-width',
          'The configured committed-column width is required.',
          'leave guard',
          column,
        );
      if (!Number.isInteger(c.committedColumnWidth) || c.committedColumnWidth < 0)
        throw new CalculationFailure(
          'invalid-policy',
          'The configured column width is unsupported.',
          'leave guard',
          column,
        );
      if (column === 1)
        throw new CalculationFailure(
          'unsupported-item-admission',
          'Item/tag admission requires its separate source workflow.',
          'leave item',
          column,
        );
      if (TEXT_COLUMNS.has(column)) cells[column] = text;
      else if (column === 9 || TWO_COLUMNS.has(column) || THREE_COLUMNS.has(column)) {
        cells[column] = formatted(
          readDecimal(text, 'numeric commit', column),
          column === 9 ? 0 : THREE_COLUMNS.has(column) ? 3 : 2,
          'numeric commit',
        );
        calculated = true;
      } else
        return {
          status: 'skipped',
          state,
          aggregateRequired: false,
          reason: 'The source handler has no case for this column.',
        };
    } else if (
      event.kind !== 'calculateAfterCopy' ||
      !['sourceSelection', 'labourCodeSelection', 'tagLabourCodeSelection'].includes(event.cause)
    ) {
      throw new CalculationFailure(
        'invalid-event',
        'A supported post-copy calculation cause is required.',
        'event',
      );
    }
    if (calculated) {
      validatePolicy(policy);
      calculate(cells, column, text, policy);
    }
    const visible: Partial<Record<number, string>> = {};
    const caches = {} as Record<SaleReturnIncomingCacheColumn, string>;
    for (const [key, value] of Object.entries(cells)) {
      const c = Number(key);
      if (cacheColumn(c)) caches[c] = value ?? '';
      else visible[c] = value;
    }
    const next = Object.freeze({
      rowIdentity: state.rowIdentity,
      raw: state.raw,
      visible: Object.freeze(visible),
      caches: Object.freeze(caches),
      journal: Object.freeze([
        ...state.journal,
        Object.freeze({
          event: frozenEvent(event),
          calculated,
          policy: Object.freeze({ ...policy }),
        }),
      ]),
    });
    return { status: 'applied', state: next, aggregateRequired: calculated };
  } catch (error) {
    if (!(error instanceof CalculationFailure)) throw error;
    return {
      status: 'rejected',
      state,
      aggregateRequired: false,
      attemptedEvent: frozenEvent(event),
      diagnostic: Object.freeze({
        code: error.code,
        message: error.message,
        stage: error.stage,
        column: error.column,
        recoverable: true,
      }),
    };
  }
}

function calculate(
  c: Partial<Record<number, string>>,
  activeColumn: number,
  editorText: string,
  p: SaleReturnIncomingPolicy,
): void {
  let stage = 'ghat and net';
  const v = (column: number) => readDecimal(c[column], stage, column);
  const nz = (column: number) => !v(column).isZero();
  const changed = (a: number, b: number) => !v(a).eq(v(b));
  const f = (column: number, value: Decimal, places = 2) => {
    c[column] = formatted(value, places, stage);
  };
  const e = (column: number, value: Decimal, places: number) =>
    f(column, new D(roundHalfEvenDecimal(value, places)));
  const ng = () => v(12).plus(v(15));
  const tw = () => v(16).plus(v(17));
  const fine = () => ng().times(tw()).div(100);
  const labourBasis = () =>
    c[22] === 'P'
      ? v(9)
      : c[22] === 'N'
        ? p.labourIncludesGhat
          ? ng()
          : v(12)
        : c[22] === 'K'
          ? ng()
          : v(10);
  const forward = (rate: number) =>
    labourBasis().times(c[22] === 'K' ? v(rate).div(1000) : v(rate));
  const inverse = (manual: boolean) => {
    const quotient = divide(v(24), labourBasis(), stage);
    return c[22] === 'K' ? (manual ? quotient.div(1000) : quotient.times(1000)) : quotient;
  };
  //4869–4881: percentage sees the old net, before gross recomputes it.
  if (nz(14) && nz(12)) f(15, v(12).times(v(14)).div(100), 3);
  if (changed(10, 45)) {
    f(45, v(10), 3);
    f(12, v(10).minus(v(11)), 3);
  }
  if (nz(11) && nz(10)) f(12, v(10).minus(v(11)), 3);
  stage = 'fine caches';
  if (changed(12, 46)) {
    f(46, v(12), 3);
    f(18, nz(12) && !tw().isZero() ? fine() : v(12), 3);
  }
  if (changed(16, 47)) {
    f(47, v(16));
    if (nz(12) && !tw().isZero()) f(18, fine(), 3);
  }
  if (changed(17, 48)) {
    f(48, v(17));
    if (nz(12) && !tw().isZero()) f(18, fine(), 3);
  }
  if (tw().isZero()) f(18, ng(), 3);
  stage = 'metal basis';
  let basis = p.saleAmountType === 'G' ? v(10) : ng();
  if (p.saleAmountType === 'F') {
    basis = v(12);
    if (p.fineColumnWidth !== 0 && nz(12) && !tw().isZero()) {
      f(18, fine(), 3);
      basis = v(18);
    }
  }
  if (changed(19, 49)) {
    f(49, v(19));
    c[66] = '0';
    c[67] = '0';
  }
  stage = 'metal amount';
  if (nz(19) && !basis.plus(v(9)).isZero()) {
    const amount =
      c[44] === 'P'
        ? v(9).times(v(19))
        : c[44] === '1'
          ? basis.times(v(19).div(10))
          : c[44] === 'K'
            ? basis.times(v(19).div(1000))
            : basis.times(v(19));
    e(20, amount, 0);
  }
  stage = 'percentage rates';
  if (changed(21, 66) && nz(19)) {
    f(66, v(21));
    c[67] = '0';
    e(23, v(19).times(v(21)).div(100), p.labourRoundingDecimals);
  }
  if (nz(30) && nz(19)) e(31, v(19).times(v(30)).div(100), p.labourRoundingDecimals);
  stage = 'labour rate or amount';
  if (changed(23, 58)) {
    f(58, v(23));
    c[67] = '0';
    e(24, forward(23), 0);
  } else if (nz(24) && p.generateLabourRate) {
    e(23, inverse(false), p.labourRoundingDecimals);
    f(58, v(23));
  }
  stage = 'discount and tag labour';
  if (nz(25) && nz(24)) e(26, v(24).times(v(25)).div(100), p.labourRoundingDecimals);
  if (nz(31)) e(32, forward(31), p.labourRoundingDecimals);
  stage = 'MRP';
  if (nz(28)) {
    if (nz(25)) {
      e(26, v(28).times(v(25)).div(100), p.labourRoundingDecimals);
      f(36, v(23).minus(v(26)));
    }
    if (nz(37)) {
      e(38, divide(v(28).minus(v(26)), v(37).plus(100), stage).times(100), 0);
      f(36, v(38).minus(v(26)));
    } else {
      f(36, v(28));
      f(38, v(36));
    }
  } else {
    stage = 'total';
    f(36, v(24).plus(v(27)).plus(v(20)).minus(v(26)));
    if (!nz(37)) {
      f(38, v(36));
      if (activeColumn === 36) {
        stage = 'manual total';
        const editor = readDecimal(editorText, stage, 36);
        if (!editor.eq(v(36))) {
          f(24, editor.minus(v(27)).minus(v(20)).plus(v(26)));
          // Source5080 compares Val(amount) < 0. Decimal's isNegative also
          // includes signed zero, which must not trigger the source blanking.
          if (v(24).lt(0)) c[24] = '';
          if (nz(24) && nz(23)) {
            e(23, inverse(true), p.labourRoundingDecimals);
            c[58] = v(23).toFixed();
          }
        }
        f(36, editor);
        f(38, v(36));
        //5111–5115 runs even when original editor equals the computed total.
        if (nz(21) && nz(19)) f(21, divide(v(23).times(100), v(19), stage), 3);
      }
    }
  }
  stage = 'final tax cache';
  if (changed(37, 67) && !nz(28)) {
    f(67, v(37));
    e(38, divide(v(36), v(37).plus(100), stage).times(100), 0);
    e(24, v(38).minus(v(20)).minus(v(27)), 0);
    if (nz(24)) {
      if (c[22] === 'P' && nz(9)) f(23, divide(v(24), v(9), stage));
      else if (c[22] === 'N' && nz(12))
        f(23, divide(v(24), p.labourIncludesGhat ? ng() : v(12), stage));
      else if (c[22] === 'K' && nz(10)) f(23, divide(v(24), v(10), stage).times(1000));
      else if (c[22] === 'G' && nz(10)) f(23, divide(v(24), v(10), stage));
      f(58, v(23));
    }
  } else f(38, v(36));
}
