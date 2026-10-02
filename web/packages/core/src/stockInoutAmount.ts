import { Decimal as DecimalJs } from 'decimal.js';
import { round, roundHalfEven } from './money.js';

export interface StockInoutAmountInput {
  /** TR_INOUT grid column 50: the tag's BAR_DETL.RATE_TYPE, the item's ITEM_MAST.RATE_TYPE, or the saved row's. */
  rateType?: string | null;
  pcs: number;
  fine: number;
  rate: number;
}

/**
 * The Stock In/Out item amount, as TR_INOUT `CommPassTotal` computes it
 * (unified/src/csharp/DataCareNext/TR_INOUT.cs:4085-4117, gap G87).
 *
 * The desktop recomputes the ItAmt cell only when both ItRate and Fine are non-zero, then by the line's rate type:
 * 'P' pieces × rate, '1' fine × rate / 10 (rate per 10 g), 'K' fine × rate / 1000 (rate per kg), anything else
 * fine × rate (rate per gram), each through Math.Round(x, 0), which rounds half to even. It reads the cells as
 * displayed: pieces "0", fine "0.000" and rate "0.00", each Strings.Format, half away from zero (:3569-3613).
 * Editing ItAmt itself re-runs the calculation, so an entered amount survives only on a line it skips.
 *
 * Returns null when the desktop does not recompute, so the entered or loaded amount stands.
 */
export function stockInoutItemAmount(input: StockInoutAmountInput): number | null {
  const rate = round(input.rate, 2);
  const fine = round(input.fine, 3);
  if (rate === 0 || fine === 0) return null;
  const type = (input.rateType ?? '').trim();
  const basis =
    type === 'P'
      ? new DecimalJs(round(input.pcs, 0)).times(rate)
      : type === '1'
        ? new DecimalJs(fine).times(new DecimalJs(rate).div(10))
        : type === 'K'
          ? new DecimalJs(fine).times(new DecimalJs(rate).div(1000))
          : new DecimalJs(fine).times(rate);
  return roundHalfEven(basis, 0);
}
