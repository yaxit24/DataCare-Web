import { dotNetRoundDouble } from '@datacare/core';

/** Round to paise, as the sales screen shows money. */
export const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

/**
 * The sales totals grid's bill total, as the server computes it: TOT_AMT = Round(net + tax + TCS + row 4 - discount,
 * TOT_AMT_ROF) with the hallmark charge and its tax (TR_SALE.cs:19039, :19047). Row 4 is the TDS cell under
 * SL_TDS_TAX 'Y', computed, never typed (BILL_TOTAL overwrites it on leaving the cell, :19261-19275):
 * Math.Round((net - discount) x TDS% / 100, 0), taken off. Otherwise it is the round-off the operator types (ROF_AMT,
 * :15051), added; the bill total's own rounding is posted nowhere (owner decision 1B, 2026-11-27).
 */
export function saleBillTotal(
  items: { net: number; tax: number; discount: number; total: number },
  hmAmt: number,
  [tdsPct, taxRatePct, tcsPct, roundOff = 0]: number[],
  tdsOn: boolean,
  roundBillTotal: (value: number) => number,
): { hmTax: number; tcsAmt: number; tdsAmt: number; total: number } {
  const hmTax = r2((hmAmt * taxRatePct) / 100);
  const tcsAmt = r2((items.total * tcsPct) / 100);
  const extras = hmAmt + hmTax + tcsAmt;
  const tdsAmt =
    tdsOn && tdsPct !== 0 && items.net !== 0
      ? dotNetRoundDouble(((items.net - items.discount) * tdsPct) / 100, 0)
      : 0;
  const row4 = tdsOn ? -tdsAmt : roundOff;
  const total = roundBillTotal(items.net + items.tax + extras + row4 - items.discount);
  return { hmTax, tcsAmt, tdsAmt, total };
}
