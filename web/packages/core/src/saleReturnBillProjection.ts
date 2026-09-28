import { Decimal } from 'decimal.js';
import type { SaleReturnIncomingRaw } from './saleReturnIncoming.js';
import type { SaleReturnBillState } from './saleReturnIncomingAggregate.js';

/** Saved header projection only. This version names an exact-decimal Format
 * profile, not measured VB Double/locale behavior or a completed saved-open. */
export const SALE_RETURN_BILL_PROJECTION_VERSION = 'sale-return-bill-projection-v1';

export interface SavedSaleReturnBillProjectionInput {
  readonly raw: SaleReturnIncomingRaw;
  readonly labels: {
    readonly taxName: string | null;
    readonly bankAccountName: string | null;
    readonly cardAccountName: string | null;
  };
}

export interface SaleReturnBillProjectionDiagnostic {
  readonly code:
    | 'invalid-projection-input'
    | 'missing-saved-column'
    | 'unsupported-numeric-null'
    | 'invalid-saved-decimal'
    | 'unsupported-saved-precision';
  readonly sourceField?: string;
  readonly message: string;
}

export type SaleReturnBillProjectionResult =
  | {
      readonly status: 'ready';
      readonly state: SaleReturnBillState;
      readonly raw: SaleReturnIncomingRaw;
    }
  | {
      readonly status: 'unsupported';
      readonly diagnostics: readonly SaleReturnBillProjectionDiagnostic[];
    };

// Local precision avoids changing, or depending on, the application's Decimal
// configuration. Raw decimal text never passes through a JavaScript Number.
const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
const numericColumns = [
  'NET_AMT',
  'TOT_AMT',
  'CHQ_AMT',
  'CARD_AMT',
  'CASH_AMT',
  'KASAR_AMT',
  'BILL_OS',
  'RTN_NET_AMT',
  'TAX_PRC',
  'TAX_AMT',
  'RTN_TOT_AMT',
  'RTN_CHQ_AMT',
  'RTN_CARD_AMT',
  'RTN_CASH_AMT',
  'RTN_KASAR_AMT',
  'RTN_BILL_OS',
] as const;
const fnvColumns: ReadonlySet<string> = new Set([
  'KASAR_AMT',
  'BILL_OS',
  'RTN_KASAR_AMT',
  'RTN_BILL_OS',
]);
const textColumns = ['TAX_CODE', 'BANK_AC', 'CHQ_NO', 'CARD_AC'] as const;

function object(value: unknown): value is Record<string, unknown> {
  return value !== null && typeof value === 'object' && !Array.isArray(value);
}

/** TR_SALE_RTN:10112–10169 fills a cleared MSG2_TOTAL, whose labels are
 * assigned at15917–15929. There is no row, aggregate or BILL_TOTAL callback
 * here. In particular, the net matrix cells remain blank and the cache is
 * the formatted full RTN_NET_AMT, not the difference between the two legs. */
export function projectSavedSaleReturnBill(
  input: SavedSaleReturnBillProjectionInput,
): SaleReturnBillProjectionResult {
  const diagnostics: SaleReturnBillProjectionDiagnostic[] = [];
  const add = (
    code: SaleReturnBillProjectionDiagnostic['code'],
    message: string,
    sourceField?: string,
  ) => {
    diagnostics.push(
      Object.freeze({ code, message, ...(sourceField === undefined ? {} : { sourceField }) }),
    );
  };
  const unsupported = (): SaleReturnBillProjectionResult =>
    Object.freeze({ status: 'unsupported', diagnostics: Object.freeze(diagnostics) });
  if (
    !object(input) ||
    !object(input.raw) ||
    !Object.values(input.raw).every((value) => value === null || typeof value === 'string') ||
    !object(input.labels) ||
    !(['taxName', 'bankAccountName', 'cardAccountName'] as const).every(
      (key) =>
        Object.hasOwn(input.labels, key) &&
        (input.labels[key] === null || typeof input.labels[key] === 'string'),
    )
  ) {
    add(
      'invalid-projection-input',
      'Exact raw string/NULL values and three label observations are required.',
    );
    return unsupported();
  }
  const raw = input.raw;
  const formatted: Record<string, string> = {};
  const text: Record<string, string> = {};
  for (const key of [...numericColumns, ...textColumns]) {
    if (!Object.hasOwn(raw, key))
      add('missing-saved-column', 'The saved ' + key + ' observation is missing.', key);
  }
  for (const key of numericColumns) {
    if (!Object.hasOwn(raw, key)) continue;
    const value = raw[key]!;
    const fnv = fnvColumns.has(key);
    if (value === null && !fnv) {
      add(
        'unsupported-numeric-null',
        'The saved ' + key + ' has an unresolved boxed numeric NULL conversion.',
        key,
      );
      continue;
    }
    // Fnv: DC_Main2088–2104 establishes NULL/empty ->0 for these four fields.
    // ASCII blank is an admitted mathematical profile; other Val prefixes and
    // boxed-NULL behavior are deliberately not guessed. Check controls before
    // trim/regex so JavaScript's terminal-newline $ match cannot admit them.
    if (
      value !== null &&
      (value.length > 128 ||
        /[^\x20-\x7e]/.test(value) ||
        (!(fnv && /^[ ]*$/.test(value)) && !/^[ ]*[+-]?(?:\d+(?:\.\d*)?|\.\d+)[ ]*$/.test(value)))
    ) {
      add(
        'invalid-saved-decimal',
        'The saved ' + key + ' requires a finite plain decimal observation.',
        key,
      );
      continue;
    }
    const decimal = new D(value === null || value.trim() === '' ? '0' : value.trim());
    if (decimal.sd() > 36 || decimal.dp() > 18 || decimal.abs().gte('1e36')) {
      add(
        'unsupported-saved-precision',
        'The saved ' + key + ' exceeds the declared exact-decimal profile.',
        key,
      );
      continue;
    }
    const display = decimal.toFixed(2, D.ROUND_HALF_UP);
    const rounded = new D(display);
    if (rounded.sd() > 36 || rounded.abs().gte('1e36')) {
      add(
        'unsupported-saved-precision',
        'The formatted ' + key + ' exceeds the declared exact-decimal profile.',
        key,
      );
      continue;
    }
    formatted[key] = display;
  }
  for (const key of textColumns) {
    if (Object.hasOwn(raw, key)) text[key] = raw[key] ?? '';
  }
  if (diagnostics.length) return unsupported();

  // Literal source labels include their trailing spaces. All unassigned cells
  // remain blank; no tax/tender consistency calculation belongs to projection.
  const matrix = [
    ['', '', '', 'Payment    ', 'Received    ', ''],
    ['Net Amt : ', '', '', '', '', ''],
    [
      'Sale Tax : ',
      input.labels.taxName ?? '',
      formatted.TAX_PRC!,
      formatted.TAX_AMT!,
      '',
      text.TAX_CODE!,
    ],
    ['Total Amt : ', '', '', formatted.RTN_TOT_AMT!, formatted.TOT_AMT!, ''],
    [
      'Cheque Amt : ',
      input.labels.bankAccountName ?? '',
      text.CHQ_NO!,
      formatted.RTN_CHQ_AMT!,
      formatted.CHQ_AMT!,
      text.BANK_AC!,
    ],
    [
      'Card Amt : ',
      input.labels.cardAccountName ?? '',
      '',
      formatted.RTN_CARD_AMT!,
      formatted.CARD_AMT!,
      text.CARD_AC!,
    ],
    ['Cash Amt : ', '', '', formatted.RTN_CASH_AMT!, formatted.CASH_AMT!, ''],
    ['Kasar Amt : ', '', '', formatted.RTN_KASAR_AMT!, formatted.KASAR_AMT!, ''],
    ['Os Amt : ', '', '', formatted.RTN_BILL_OS!, formatted.BILL_OS!, ''],
  ];
  return Object.freeze({
    status: 'ready',
    raw: Object.freeze({ ...raw }),
    state: Object.freeze({
      matrix: Object.freeze(matrix.map((row) => Object.freeze(row))),
      oldNetAmt: new D(formatted.RTN_NET_AMT!).toFixed(),
      oldTaxPrc: new D(formatted.TAX_PRC!).toFixed(),
      outgoingRounded: formatted.NET_AMT!,
      incomingRounded: formatted.RTN_NET_AMT!,
      closing: Object.freeze({
        status: 'unavailable',
        amount: null,
        label: null,
        color: 'unknown',
        reason: 'Customer balance requires a resolved ledger mode.',
      }),
    }),
  });
}
