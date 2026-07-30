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

/** Fine (pure-metal) weight = netWt * touch / 100. (Req 12.1) */
export function fineWeight(
  netWt: DecimalJs.Value,
  touch: DecimalJs.Value,
  dp: number = PRECISION.fine,
): number {
  return round(new DecimalJs(netWt).times(touch).div(100), dp);
}
