import { roundHalfEven } from './money.js';

/**
 * Daily Rate (desktop MS_RATE, "Rate Master") grid recalculation.
 *
 * The operator types the day's Gold Rate 10gm and Silver Rate 1Kg; pressing Enter on the silver rate
 * (`nSilverRate_KeyDown`, MS_RATE.cs:2314-2368) recomputes every gold or silver group whose metal rate is non-zero
 * and differs from the rate the day was opened with:
 *
 *   TaxRate = Round(Touch × Rate / divisor)        divisor 100 for gold (per 10 g), 10000 for silver (1 kg -> 10 g)
 *   Rate10gm = TaxRate, or Round(TaxRate / (Tax% + 100) × 100, 0) when the group has a Tax%
 *   PrRate  = Round(PrTouch × Rate / divisor)
 *
 * A UAE company also has purchase rates (`nPrGoldRate` / `nPrSilverRate`, visible only when CO_SNAME is 'UAE',
 * MS_RATE.cs:1705-1715); there the Enter on Silver USD Pr Oz (`nSilverOzRate_KeyDown`, :2397-2458) additionally
 * recomputes PrRate from a changed purchase rate. Groups of any other type are left as typed.
 *
 * VB `Math.Round(x)` and `Math.Round(x, 0)` are .NET banker's rounding (MidpointRounding.ToEven) to a whole number.
 */
export interface DailyRateGridRow {
  /** GROUP_MAST.GR_TYPE: 'G' gold, 'S' silver, anything else is not derived. */
  grType: string;
  touch: number;
  taxPct: number;
  prTouch: number;
  /** Rate10gm (RATE_MAST.GR_RATE). */
  rate: number;
  /** TaxRate (RATE_MAST.GR_TAX_RATE). */
  taxRate: number;
  /** PrRate (RATE_MAST.GR_PR_RATE). */
  prRate: number;
}

export interface DailyRateHeaderRates {
  goldRate: number;
  silverRate: number;
  prGoldRate?: number;
  prSilverRate?: number;
}

const whole = (value: number): number => roundHalfEven(value, 0);

export function recalcDailyRateGrid<T extends DailyRateGridRow>(
  rows: readonly T[],
  now: DailyRateHeaderRates,
  loaded: DailyRateHeaderRates,
  options: { foreignRates?: boolean } = {},
): T[] {
  const changed = (value: number | undefined, before: number | undefined) =>
    Number(value ?? 0) !== 0 && Number(before ?? 0) !== Number(value ?? 0);
  return rows.map((row) => {
    const type = String(row.grType ?? '')
      .trim()
      .toUpperCase();
    const metal =
      type === 'G'
        ? {
            rate: now.goldRate,
            before: loaded.goldRate,
            pr: now.prGoldRate,
            prBefore: loaded.prGoldRate,
            divisor: 100,
          }
        : type === 'S'
          ? {
              rate: now.silverRate,
              before: loaded.silverRate,
              pr: now.prSilverRate,
              prBefore: loaded.prSilverRate,
              divisor: 10000,
            }
          : null;
    if (!metal) return row;
    let next = row;
    if (changed(metal.rate, metal.before)) {
      const rate = Number(metal.rate);
      const taxRate = whole((Number(row.touch) * rate) / metal.divisor);
      next = {
        ...next,
        taxRate,
        rate:
          Number(row.taxPct) !== 0 ? whole((taxRate / (Number(row.taxPct) + 100)) * 100) : taxRate,
        prRate: whole((Number(row.prTouch) * rate) / metal.divisor),
      };
    }
    if (options.foreignRates && changed(metal.pr, metal.prBefore))
      next = { ...next, prRate: whole((Number(row.prTouch) * Number(metal.pr)) / metal.divisor) };
    return next;
  });
}
