import type { MoneyRoundingPolicy } from './calc.js';
import { dotNetRoundDouble } from './money.js';

/**
 * The company money-rounding rule, shared by the server (which reads the flags from CO_SET inside the
 * voucher transaction) and the web (which builds the identical policy to preview a document's totals, so a
 * screen never shows a different total from the one the server posts — G102/G84).
 *
 * The desktop rounds with `Math.Round(value, digits)` (banker's rounding) when a company has configured the
 * flag, and keeps a 2dp half-up default when it has not (`MS_OPNCOMP.cs:1297-1303`). Both halves of that rule
 * live here so there is exactly one source of truth.
 */

export type TaxRoundingDecimals = 0 | 1 | 2 | 3 | 4 | 5;
export type StandardRoundingDecimals = 0 | 1 | 2 | 3;

export interface RoundingFlagValues {
  TAX_ROF?: unknown;
  LBR_ROF?: unknown;
  ITM_RATE_ROF?: unknown;
  TOT_AMT_ROF?: unknown;
  PR_RATE_ROF?: unknown;
  ALL_ROF_REMOVE?: unknown;
}

export interface RoundingPolicy extends MoneyRoundingPolicy {
  taxDecimals: TaxRoundingDecimals;
  labourDecimals: StandardRoundingDecimals;
  itemRateDecimals: StandardRoundingDecimals;
  billTotalDecimals: StandardRoundingDecimals;
  purchaseRateDecimals: StandardRoundingDecimals;
  /**
   * `CO_SET.ALL_ROF_REMOVE = 'Y'` (`DC_Main.MsAllRofRemove`). Besides forcing the four flags above to 2, it is the
   * only company setting the Sale line reads for its own precision (`saleLineDecimals`, TR_SALE.cs:10343-10362).
   * Optional so that a hand-built policy (tests, a return form's hardcoded policy) reads as "not set".
   */
  allRoundingRemoved?: boolean;
  /** Which flags the company actually configured (the server's PARITY_STRICT gate needs this). */
  configured: {
    tax: boolean;
    labour: boolean;
    itemRate: boolean;
    billTotal: boolean;
    purchaseRate: boolean;
  };
  roundTaxAmount(value: number): number;
  roundLabourAmount(value: number): number;
  roundLabourRate(value: number): number;
  roundItemRate(value: number): number;
  roundBillTotal(value: number): number;
  roundPurchaseRate(value: number): number;
}

export class RoundingPolicyValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'RoundingPolicyValidationError';
  }
}

const DEFAULT_DECIMALS = 2 as const;

/** Mirrors Math.Round(value, digits): nearest value, with configurable midpoint behavior. */
export function roundNearest(value: number, decimals: number, tiesToEven: boolean): number {
  if (!Number.isFinite(value)) {
    throw new RoundingPolicyValidationError(`cannot round a non-finite monetary value: ${value}`);
  }
  const factor = 10 ** decimals;
  const scaled = Math.abs(value) * factor;
  const lower = Math.floor(scaled);
  const fraction = scaled - lower;
  const tolerance = Number.EPSILON * Math.max(1, scaled) * 4;
  const rounded =
    fraction > 0.5 + tolerance
      ? lower + 1
      : fraction < 0.5 - tolerance
        ? lower
        : tiesToEven && lower % 2 === 0
          ? lower
          : lower + 1;
  const result = (Math.sign(value) * rounded) / factor;
  return Object.is(result, -0) ? 0 : result;
}

interface ParsedDecimals {
  value: number;
  configured: boolean;
}

function parseDecimals(
  name: keyof RoundingFlagValues,
  raw: unknown,
  maximum: number,
): ParsedDecimals {
  if (raw == null || String(raw).trim() === '') {
    return { value: DEFAULT_DECIMALS, configured: false };
  }
  const text = String(raw).trim();
  if (!/^\d+(?:\.0+)?$/.test(text)) {
    throw new RoundingPolicyValidationError(
      `${name} must be a whole-number decimal count: ${text}`,
    );
  }
  const value = Number(text);
  if (!Number.isSafeInteger(value) || value < 0 || value > maximum) {
    throw new RoundingPolicyValidationError(`${name} must be between 0 and ${maximum}: ${text}`);
  }
  return { value, configured: true };
}

/** Resolve persisted company flags. Blank/absent flags intentionally retain the web's 2dp policy. */
export function resolveRoundingPolicy(flags: RoundingFlagValues = {}): RoundingPolicy {
  const allText = String(flags.ALL_ROF_REMOVE ?? '')
    .trim()
    .toUpperCase();
  if (allText && allText !== 'Y' && allText !== 'N') {
    throw new RoundingPolicyValidationError(`ALL_ROF_REMOVE must be Y or N: ${allText}`);
  }
  const allRoundingRemoved = allText === 'Y';
  // MS_OPNCOMP.cs:1297-1303 forces item-rate, labour, total and tax precision to 2. It does not
  // assign MsPrRateRof, so CO_SET_NEW.PR_RATE_ROF remains independent.
  const forced = { value: 2, configured: true } as const;
  const tax = allRoundingRemoved ? forced : parseDecimals('TAX_ROF', flags.TAX_ROF, 5);
  const labour = allRoundingRemoved ? forced : parseDecimals('LBR_ROF', flags.LBR_ROF, 3);
  const itemRate = allRoundingRemoved
    ? forced
    : parseDecimals('ITM_RATE_ROF', flags.ITM_RATE_ROF, 3);
  const billTotal = allRoundingRemoved
    ? forced
    : parseDecimals('TOT_AMT_ROF', flags.TOT_AMT_ROF, 3);
  const purchaseRate = parseDecimals('PR_RATE_ROF', flags.PR_RATE_ROF, 3);
  const taxDecimals = tax.value as TaxRoundingDecimals;
  const labourDecimals = labour.value as StandardRoundingDecimals;
  const itemRateDecimals = itemRate.value as StandardRoundingDecimals;
  const billTotalDecimals = billTotal.value as StandardRoundingDecimals;
  const purchaseRateDecimals = purchaseRate.value as StandardRoundingDecimals;

  return {
    taxDecimals,
    labourDecimals,
    itemRateDecimals,
    billTotalDecimals,
    purchaseRateDecimals,
    allRoundingRemoved,
    configured: {
      tax: tax.configured,
      labour: labour.configured,
      itemRate: itemRate.configured,
      billTotal: billTotal.configured,
      purchaseRate: purchaseRate.configured,
    },
    roundTaxAmount: (value) => roundNearest(value, taxDecimals, tax.configured),
    roundLabourAmount: (value) => roundNearest(value, labourDecimals, labour.configured),
    // A derived LBR_RATE is Math.Round on the desktop's double (TR_SALE.cs:11021), not a decimal rounding.
    roundLabourRate: (value) => dotNetRoundDouble(value, labourDecimals),
    roundItemRate: (value) => roundNearest(value, itemRateDecimals, itemRate.configured),
    roundBillTotal: (value) => roundNearest(value, billTotalDecimals, billTotal.configured),
    roundPurchaseRate: (value) =>
      roundNearest(value, purchaseRateDecimals, purchaseRate.configured),
  };
}

/**
 * Decimal places of the Sale grid's ITM_AMT and LBR_AMT.
 *
 * `CommPassTotal` hardcodes them and never reads TOT_AMT_ROF for a line (TR_SALE.cs:10343-10362):
 *
 *     digits = 0; digits2 = 0;
 *     if (SSRegSrNo == "DM035NPDM" | MsAllRofRemove == "Y") { digits = 2; digits2 = 2; }
 *
 * `digits` rounds the item amount (:10905-10932) and `digits2` the labour amount (:11100-11127). The registration
 * serial is one customer's licence and is not modelled. TR_SALE_HM.cs:7344-7359 (Hallmark Sale) has the same rule.
 *
 * TOT_AMT_ROF keeps the role the desktop gives it: the BILL totals (TR_SALE.cs:19192 the totals grid's net,
 * :19274/:19282 the bill total), which the web applies through `roundBillTotal` in `billTotals`.
 */
export function saleLineDecimals(policy: Pick<RoundingPolicy, 'allRoundingRemoved'>): 0 | 2 {
  return policy.allRoundingRemoved ? 2 : 0;
}

/** `Math.Round(value, digits)` at the Sale line precision: .NET's default midpoint rule, to even. */
export function roundSaleLineAmount(
  value: number,
  policy: Pick<RoundingPolicy, 'allRoundingRemoved'>,
): number {
  return roundNearest(value, saleLineDecimals(policy), true);
}
