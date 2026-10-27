import { valueOldGoldLine } from '@datacare/core';

/** The editable cells of one old-metal (exchange) row on the sale and sales-quotation screens. */
export interface OldGoldCells {
  netWt: string;
  touch: string;
  rate: string;
  conversionPct: string;
  conversionWt: string;
  rateType: string;
}

/**
 * The amount the server will store for this exchange row (G83).
 *
 * The screen previews exactly what the writer saves by calling the same kernel function, `valueOldGoldLine`:
 * fine at three decimals or the net weight when no touch is given, then `Math.Round(basis x rate, 0)` on the
 * net, fine or conversion weight the rate type selects (`TR_SALE.cs` `CommPassTotal_Old`). The old screen
 * multiplied net x touch x rate to the paisa, so it showed 25,821.60 for a row the desktop and server value
 * at 25,822.
 */
export function oldGoldRowAmount(row: OldGoldCells): number {
  return valueOldGoldLine({
    netWt: Number(row.netWt || 0),
    touch: Number(row.touch || 0),
    rate: Number(row.rate || 0),
    conversionPct: Number(row.conversionPct || 0),
    conversionWt: Number(row.conversionWt || 0),
    rateType: row.rateType || undefined,
  }).amount;
}
