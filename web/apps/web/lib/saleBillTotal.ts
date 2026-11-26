import { dotNetRoundDouble } from '@datacare/core';

const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

/**
 * The sales totals grid's bill total. With SL_TDS_TAX 'Y' the TDS cell is computed, never typed (BILL_TOTAL overwrites
 * it on leaving the cell, TR_SALE.cs:19261-19275): Math.Round((net - discount) x TDS% / 100, 0), and the total takes it
 * off before its TOT_AMT_ROF rounding, as the server does.
 */
export function saleBillTotal(
  items: { net: number; tax: number; discount: number; total: number },
  hmAmt: number,
  [tdsPct, taxRatePct, tcsPct]: number[],
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
  const total = tdsOn
    ? roundBillTotal(items.net + items.tax + extras - tdsAmt - items.discount)
    : r2(items.total + extras);
  return { hmTax, tcsAmt, tdsAmt, total };
}
