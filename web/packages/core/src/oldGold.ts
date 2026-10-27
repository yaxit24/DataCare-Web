import { round, roundHalfEven } from './money.js';

/**
 * Old-metal (exchange) line valuation, `TR_SALE.cs` `CommPassTotal_Old` (the `mSG_OLD` grid) → `SL_PR_DETL`.
 *
 * It lives in the kernel because the server writer AND every screen that previews an exchange line (sale,
 * sales quotation, hallmark sale) must produce the same figure; a screen that re-derives it shows one amount and
 * saves another (G83). Grid columns, from the behaviour catalog:
 *
 *   4 = gross   5 = less   6 = cUrNetWt   7 = cUrTouch   8 = cUrFine   9 = cUrConTouch ("Con%")
 *   10 = cUrConWt   11 = cUrRate   12 = cUrRateType   13 = cUrNetAmt
 *
 * **Fine** — `[8] = Strings.Format(Val([6]) * Val([7]) / 100, "0.000")` when touch and net are both non-zero
 * (:7905), otherwise `[8] = Strings.Format(Val([6]), "0.000")` (:7903, :7907-7910): three decimals, format-string
 * rounding, therefore half-up.
 *
 * **Amount from rate** — `if Val([11]) <> 0`:
 *   • rate type `N` (net-wise):  `[13] = Math.Round(Val([6]) * Val([11]), 0)`  (:7959)
 *   • otherwise  (fine-wise):    `[13] = Math.Round(Val([8]) * Val([11]), 0)`  (:7963)
 *   • with a conversion weight:  `[13] = Math.Round(Val([10]) * Val([11]), 0)` (:7921, :7944)
 *   `Math.Round` at 0 decimal places, so whole rupees, half to even.
 *
 * **Rate from amount** — when the operator types into the amount cell (`TEXT_OLD`), the desktop keeps the amount
 * and back-calculates the rate: `[11] = Strings.Format(Val(TEXT_OLD) / basis, "0.00")` (:7930, :7983-7988), two
 * decimals, half-up.
 *
 * NOT implemented, deliberately: a `cUrConWt` branch gated on `DC_Main.SSRegSrNo = "KJ001NEKJ"` (:7923-7933), a
 * per-installation customisation recorded in WAIVERS.md. The conversion weight itself (`[10]`, derived from Con%
 * at :7914-7942) is taken as supplied; deriving it on the server is gap G89.
 */
export type OldGoldRateType = 'N' | 'F' | string;

export interface OldGoldValuationInput {
  /** cUrNetWt — net weight after the "less" deduction. */
  netWt?: number;
  /** cUrFine — fine weight, `oldGoldFine` of the net weight and touch. */
  fineWt?: number;
  /** cUrConTouch (`[9]`, "Con%") — the conversion purity. When non-zero the writer DERIVES the conversion
   * weight from it and the fine weight (G89); the client's `conversionWt` is not trusted. */
  conversionPct?: number;
  /** cUrConWt — conversion weight. Used only as a fallback when no `conversionPct` is given (a legacy row
   * that carried the weight but not the percentage). */
  conversionWt?: number;
  /** cUrRate — rate per gram of whichever basis the rate type selects. */
  rate?: number;
  /** cUrNetAmt — the amount, when the operator typed it instead of a rate. */
  amount?: number;
  /** cUrRateType — `N` values on net weight, anything else on fine weight. */
  rateType?: OldGoldRateType;
}

/** One exchange line as a screen or the writer holds it: weights, touch, and a rate or a typed amount. */
export interface OldGoldLineInput extends Omit<OldGoldValuationInput, 'fineWt'> {
  /** cUrTouch — purity percentage. */
  touch?: number;
}

const n = (v: unknown): number => {
  const x = Number(v ?? 0);
  return Number.isFinite(x) ? x : 0;
};

/** cUrFine (`[8]`): net × touch / 100 at three decimals, or the net weight when there is no touch. */
export function oldGoldFine(input: { netWt?: number; touch?: number }): number {
  const net = n(input.netWt);
  const touch = n(input.touch);
  const fine = touch !== 0 && net !== 0 ? round((net * touch) / 100, 3) : 0;
  return fine !== 0 ? fine : round(net, 3);
}

/**
 * cUrConWt (`[10]`): the conversion weight the rate applies to, DERIVED from the fine weight and Con% exactly
 * as the desktop does (`TR_SALE.cs:7919-7942`, the normal non-`KJ001NEKJ` paths), so the server never trusts a
 * client-posted weight (G89):
 *   • Con% > 100 (an uplift): `round(fine * Con% / 100, 3)`.
 *   • 0 < Con% ≤ 100 (the usual lower purity): `round(fine / Con% * 100 − fine, 3) + fine`.
 *   • Con% == 0: no conversion; fall back to the supplied `conversionWt` (a legacy row), else 0.
 * The `KJ001NEKJ` per-installation branch (:7923-7933) is deliberately not implemented (WAIVERS.md).
 */
export function oldGoldConversionWeight(input: {
  fineWt?: number;
  conversionPct?: number;
  conversionWt?: number;
}): number {
  const fine = n(input.fineWt);
  const conPct = n(input.conversionPct);
  if (conPct === 0) return n(input.conversionWt);
  if (fine === 0) return 0;
  if (conPct > 100) return round((fine * conPct) / 100, 3);
  return round((fine / conPct) * 100 - fine, 3) + fine;
}

/** The weight the rate applies to, following the desktop's branch order. */
export function oldGoldBasisWeight(input: OldGoldValuationInput): number {
  const conversion = oldGoldConversionWeight(input);
  if (conversion !== 0) return conversion;
  if (String(input.rateType ?? '').toUpperCase() === 'N') return n(input.netWt);
  return n(input.fineWt);
}

/**
 * Amount from rate: `Math.Round(basis * rate, 0)` — whole rupees, half to even.
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
  return round(n(input.amount) / basis, 2);
}

/**
 * Resolve the (rate, amount) pair the way the desktop's two entry flows do.
 *
 * A supplied rate wins, because that is the common flow and it is what the desktop recomputes the amount from.
 * Only when no rate is given but an amount is does the rate get back-calculated.
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

/** Value one exchange line exactly as the writer stores it: its fine weight, rate, whole-rupee amount, and the
 * conversion weight DERIVED from Con% (G89) — the server stores this derived `CON_WT`, never the client's. */
export function valueOldGoldLine(input: OldGoldLineInput): {
  fine: number;
  rate: number;
  amount: number;
  conversionWt: number;
} {
  const fine = oldGoldFine(input);
  const conversionWt = oldGoldConversionWeight({ ...input, fineWt: fine });
  const valued = resolveOldGoldValuation({ ...input, fineWt: fine, conversionWt });
  return { fine, rate: valued.rate, amount: valued.amount, conversionWt };
}
