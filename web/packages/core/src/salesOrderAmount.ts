import { Decimal } from 'decimal.js';
import { roundHalfEven } from './money.js';
import { companySaleAmountType } from './saleAmount.js';

/**
 * Sales Order (TR_SALE_ORD) item amount and bill, as the desktop's CommPassTotal and bill total compute them.
 *
 * Item amount, `TR_SALE_ORD.cs:6571-6672`. The weight the rate multiplies follows the company's SL_AMT_TYPE
 * (`DC_Main.MsSlAmtType`, :6571; blank reads as N, MS_OPNCOMP.cs:881-884):
 *
 * | SL_AMT_TYPE | weight                                                                  | source     |
 * |-------------|-------------------------------------------------------------------------|------------|
 * | F           | fine = (net + ghat) × (touch + wastage) / 100, to 3 decimals, when       | 6575-6596  |
 * |             | touch + wastage and net are both non-zero; otherwise net                 | 6608, 6612 |
 * | G           | gross                                                                   | 6616-6623  |
 * | other       | net + ghat                                                              | 6627       |
 *
 * The line's rate type (grid column 48) then decides the multiplication (:6646-6672): P is pieces × rate,
 * 1 is weight × rate / 10, K is weight × rate / 1000, anything else weight × rate. Every branch is
 * `Math.Round(x, 0)`: whole rupees, half to even.
 *
 * Bill, `:11340-11342`: tax = Math.Round(net × tax % / 100, 0) and total = Math.Round(net + tax, 0).
 *
 * Not reproduced, as for the sale (saleAmount.ts): the desktop re-prices the metal only when the rate differs from
 * the last one it priced (column 83). The web prices from the final line.
 */

const D = (value: Decimal.Value | null | undefined): Decimal => new Decimal(value ?? 0);

export interface SalesOrderAmountLine {
  pcs?: Decimal.Value | null;
  grossWt?: Decimal.Value | null;
  netWt?: Decimal.Value | null;
  ghtWt?: Decimal.Value | null;
  touch?: Decimal.Value | null;
  westPct?: Decimal.Value | null;
}

/** The weight a Sales Order line's rate applies to (`TR_SALE_ORD.cs:6571-6627`). */
export function salesOrderItemWeight(line: SalesOrderAmountLine, amountType: unknown): number {
  const type = companySaleAmountType(amountType);
  const net = D(line.netWt);
  const ghat = D(line.ghtWt);
  if (type === 'F') {
    const purity = D(line.touch).plus(D(line.westPct));
    if (!purity.isZero() && !net.isZero())
      return roundHalfEven(net.plus(ghat).times(purity).div(100), 3);
    return net.toNumber();
  }
  if (type === 'G') return D(line.grossWt).toNumber();
  return net.plus(ghat).toNumber();
}

/** A Sales Order line's item amount in whole rupees (`TR_SALE_ORD.cs:6646-6672`). */
export function salesOrderItemAmount(
  line: SalesOrderAmountLine,
  amountType: unknown,
  rate: Decimal.Value | null | undefined,
  rateType?: unknown,
): number {
  const code = String(rateType ?? '')
    .trim()
    .toUpperCase();
  const r = D(rate);
  if (code === 'P') return roundHalfEven(D(line.pcs).times(r), 0);
  const weight = D(salesOrderItemWeight(line, amountType));
  if (code === '1') return roundHalfEven(weight.times(r.div(10)), 0);
  if (code === 'K') return roundHalfEven(weight.times(r.div(1000)), 0);
  return roundHalfEven(weight.times(r), 0);
}

export interface SalesOrderBill {
  net: number;
  tax: number;
  total: number;
}

/** The order's tax and total in whole rupees (`TR_SALE_ORD.cs:11340-11342`). */
export function salesOrderBill(
  lineNetTotal: Decimal.Value,
  taxRatePct: Decimal.Value,
): SalesOrderBill {
  const net = D(lineNetTotal);
  const tax = roundHalfEven(net.times(D(taxRatePct)).div(100), 0);
  return { net: net.toNumber(), tax, total: roundHalfEven(net.plus(tax), 0) };
}
