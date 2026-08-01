import type { MoneyRoundingPolicy } from '@datacare/core';

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
  roundTaxAmount(value: number): number;
  roundLabourAmount(value: number): number;
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
function roundNearest(value: number, decimals: number, tiesToEven: boolean): number {
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

  // PARITY_STRICT turns an ABSENT setting from a silent default into a failure.
  //
  // An absent setting is indistinguishable from a product defect in a comparison. The replay harness seeded
  // CO_SET but not CO_SET_NEW, so TOT_AMT_ROF was missing and this function kept its documented 2dp default.
  // The web produced 1515.21 against the desktop's 1515.00, and that was written up as a MISSING whole-rupee
  // rounding mode - across two commits - before the cause was found. The mode was implemented correctly the
  // whole time.
  //
  // Off by default, because production genuinely wants a sane default when a customer has not set a flag. On
  // under PARITY_STRICT=1, where the entire point is that nothing may be assumed.
  if (process.env.PARITY_STRICT === '1') {
    const unset = (
      [
        ['TAX_ROF', tax],
        ['LBR_ROF', labour],
        ['ITM_RATE_ROF', itemRate],
        ['TOT_AMT_ROF', billTotal],
        ['PR_RATE_ROF', purchaseRate],
      ] as const
    )
      .filter(([, flag]) => !flag.configured)
      .map(([name]) => name);
    if (unset.length) {
      throw new RoundingPolicyValidationError(
        `PARITY_STRICT: ${unset.length} rounding setting(s) are not configured and would silently take a ` +
          `default, which is indistinguishable from a defect in a comparison: ${unset.join(', ')}`,
      );
    }
  }

  return {
    taxDecimals,
    labourDecimals,
    itemRateDecimals,
    billTotalDecimals,
    purchaseRateDecimals,
    roundTaxAmount: (value) => roundNearest(value, taxDecimals, tax.configured),
    roundLabourAmount: (value) => roundNearest(value, labourDecimals, labour.configured),
    roundItemRate: (value) => roundNearest(value, itemRateDecimals, itemRate.configured),
    roundBillTotal: (value) => roundNearest(value, billTotalDecimals, billTotal.configured),
    roundPurchaseRate: (value) =>
      roundNearest(value, purchaseRateDecimals, purchaseRate.configured),
  };
}
