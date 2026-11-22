import { Decimal as DecimalJs } from 'decimal.js';

/**
 * Precision policy (ADR-0001). Money/weight columns are NUMERIC, not float.
 * amounts 2dp, weights 3dp, fine 3dp (configurable per-column in the schema later).
 */
export const PRECISION = { amount: 2, weight: 3, fine: 3 } as const;

/**
 * Half-up rounding to `dp` decimal places.
 *
 * NOTE ON DESKTOP EQUIVALENCE: this is NOT universally what the desktop does. `Math.Round(Double,
 * Int32)` in .NET defaults to `MidpointRounding.ToEven` (banker's rounding), and the desktop calls
 * `Math.Round` 10,306 times with zero `MidpointRounding` overrides — so every one of those sites rounds
 * half-to-even. Half-up and half-to-even differ only on exact midpoints, but at 0 decimal places that is
 * a whole rupee (₹10.50 → 10 on the desktop, 11 here).
 *
 * THE RULE, now measured rather than assumed. The desktop rounds through two mechanisms:
 *
 *   • `Strings.Format(x, "0.00" / "0.000")` — 20,575 sites. Rounding is decided by the .NET numeric
 *     format string, which rounds half away from zero, i.e. HALF-UP. `round` is correct for these.
 *   • `Math.Round(x, n)` — 10,306 sites, of which only 1,402 are wrapped in `Strings.Format`. Zero of
 *     them pass a `MidpointRounding` argument, so all use the .NET default, HALF-TO-EVEN. Use
 *     `roundHalfEven` for these.
 *
 * Worked example of why the distinction is not academic: the sale LINE total goes through
 * `Math.Round(sum, 0)`, so ₹10.50 persists as 10; the fine weight goes through
 * `Strings.Format((netWt + ghatWt) * (touch + west) / 100, "0.000")`, so half-up is right there.
 */
export function round(value: DecimalJs.Value, dp: number): number {
  return new DecimalJs(value).toDecimalPlaces(dp, DecimalJs.ROUND_HALF_UP).toNumber();
}

/**
 * Half-to-even ("banker's") rounding — the .NET `Math.Round(value, dp)` default the desktop relies on.
 * Use wherever a persisted value is produced by a desktop `Math.Round` call.
 */
export function roundHalfEven(value: DecimalJs.Value, dp: number): number {
  return new DecimalJs(value).toDecimalPlaces(dp, DecimalJs.ROUND_HALF_EVEN).toNumber();
}

/** Exact decimal cell text, without the Number roundtrip used by the older APIs.
 * Mathematical half-up is the selected port policy; this does not establish
 * all legacy Double/Val/Strings.Format culture and midpoint behavior.
 */
export function decimalCellText(value: DecimalJs.Value, dp: number): string {
  const decimal = new DecimalJs(value);
  if (!decimal.isFinite()) throw new Error('A finite decimal is required');
  return decimal.toFixed(dp, DecimalJs.ROUND_HALF_UP);
}

/** Decimal-valued midpoint-to-even primitive for explicit source Math.Round sites. */
export function roundHalfEvenDecimal(value: DecimalJs.Value, dp: number): DecimalJs {
  const decimal = new DecimalJs(value);
  if (!decimal.isFinite()) throw new Error('A finite decimal is required');
  return decimal.toDecimalPlaces(dp, DecimalJs.ROUND_HALF_EVEN);
}

/** Fine (pure-metal) weight = netWt * touch / 100. (Req 12.1) */
export function fineWeight(
  netWt: DecimalJs.Value,
  touch: DecimalJs.Value,
  dp: number = PRECISION.fine,
): number {
  return round(new DecimalJs(netWt).times(touch).div(100), dp);
}

/**
 * .NET Framework `Math.Round(double, digits)` on an IEEE double, as the desktop's `Conversion.Val` arithmetic runs:
 * the value is multiplied by 10^digits in double precision and that double is rounded half to even, with no
 * tolerance (referencesource mscorlib/system/math.cs `InternalRound`). So 11.25 x 2.8 / 100 = 0.31499999999999995
 * rounds to 0.31, where an exact-decimal rounding of 0.315 gives 0.32.
 */
export function dotNetRoundDouble(value: number, digits: number): number {
  if (!Number.isFinite(value)) throw new Error(`cannot round a non-finite value: ${value}`);
  const power10 = 10 ** digits;
  const scaled = value * power10;
  const floor = Math.floor(scaled);
  const fraction = scaled - floor;
  const rounded =
    fraction > 0.5 ? floor + 1 : fraction < 0.5 ? floor : floor % 2 === 0 ? floor : floor + 1;
  return rounded / power10;
}
