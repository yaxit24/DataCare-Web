import { roundHalfEven } from '@datacare/core';

/**
 * Old-gold (exchange) line valuation, `TR_SALE.cs` `mSG_OLD` grid → `SL_PR_DETL`.
 *
 * The desktop does NOT have a single formula here; it has a branch set, and reading only one branch
 * gives an economically absurd answer (valuing 4.3 g of 90% gold at ₹8 instead of ₹387). The branches,
 * with their grid indices resolved from the behaviour catalog:
 *
 *   6 = cUrNetWt   7 = cUrTouch   8 = cUrFine   9 = cUrConTouch ("Con%")
 *   10 = cUrConWt  11 = cUrRate   12 = cUrRateType   13 = cUrNetAmt
 *
 * **Amount from rate** — `if Val([11]) <> 0`:
 *   • rate type `N` (net-wise):  `[13] = Math.Round(Val([6]) * Val([11]), 0)`
 *   • otherwise  (fine-wise):    `[13] = Math.Round(Val([8]) * Val([11]), 0)`
 *   • with a conversion weight:  `[13] = Math.Round(Val([10]) * Val([11]), 0)`
 *   `Math.Round` at 0 decimal places, so whole rupees, half-to-even.
 *
 * **Rate from amount** — when the operator types into the amount cell (`TEXT_OLD`), the desktop keeps
 * the amount and back-calculates the rate instead:
 *   • rate type `N`: `[11] = Val(TEXT_OLD) / Val([6])`
 *   • conversion:    `[11] = Val(TEXT_OLD) / Val([10])`
 *   • otherwise:     `[11] = Val(TEXT_OLD) / Val([8])`
 *   at two decimals (format-string rounding, therefore half-up).
 *
 * Both directions are implemented because both are real operator flows; which one applies is decided by
 * whether a rate or an amount was supplied, exactly as the desktop decides by which cell was edited.
 *
 * NOT implemented, deliberately: a `cUrConWt` branch gated on `DC_Main.SSRegSrNo = "KJ001NEKJ"`, which
 * is a per-installation customisation (the fifth licence-serial gated rule found). Recorded in WAIVERS.md.
 */
export type OldGoldRateType = 'N' | 'F' | string;

export interface OldGoldValuationInput {
  /** cUrNetWt — net weight after the "less" deduction. */
  netWt?: number;
  /** cUrFine — fine weight, itself `(netWt) * touch / 100` at three decimals. */
  fineWt?: number;
  /** cUrConWt — conversion weight, used in preference to fine when a Con% conversion applies. */
  conversionWt?: number;
  /** cUrRate — rate per gram of whichever basis the rate type selects. */
  rate?: number;
  /** cUrNetAmt — the amount, when the operator typed it instead of a rate. */
  amount?: number;
  /** cUrRateType — `N` values on net weight, anything else on fine weight. */
  rateType?: OldGoldRateType;
}

const n = (v: unknown): number => (v == null ? 0 : Number(v) || 0);

/** The weight the rate applies to, following the desktop's branch order. */
export function oldGoldBasisWeight(input: OldGoldValuationInput): number {
  const conversion = n(input.conversionWt);
  if (conversion !== 0) return conversion;
  if (String(input.rateType ?? '').toUpperCase() === 'N') return n(input.netWt);
  return n(input.fineWt);
}

/**
 * Amount from rate: `Math.Round(basis * rate, 0)` — whole rupees, half-to-even.
 * Returns 0 when there is no rate, matching the desktop's `if Val([11]) <> 0` gate.
 */
export function oldGoldAmountFromRate(input: OldGoldValuationInput): number {
  const rate = n(input.rate);
  if (rate === 0) return 0;
  return roundHalfEven(oldGoldBasisWeight(input) * rate, 0);
}

/**
 * Rate from amount: `amount / basis` at two decimals (format-string rounding, half-up).
 * Returns 0 when the basis weight is zero, since the desktop would divide by zero there.
 */
export function oldGoldRateFromAmount(input: OldGoldValuationInput): number {
  const basis = oldGoldBasisWeight(input);
  if (basis === 0) return 0;
  return Math.round((n(input.amount) / basis) * 100) / 100;
}

/**
 * Resolve the (rate, amount) pair the way the desktop's two entry flows do.
 *
 * A supplied rate wins, because that is the common flow and it is what the desktop recomputes the amount
 * from. Only when no rate is given but an amount is does the rate get back-calculated.
 */
export function resolveOldGoldValuation(input: OldGoldValuationInput): {
  rate: number;
  amount: number;
} {
  if (n(input.rate) !== 0) {
    return { rate: n(input.rate), amount: oldGoldAmountFromRate(input) };
  }
  if (n(input.amount) !== 0) {
    return { rate: oldGoldRateFromAmount(input), amount: n(input.amount) };
  }
  return { rate: 0, amount: 0 };
}
