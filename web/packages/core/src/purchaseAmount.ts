import { Decimal } from 'decimal.js';
import type { LabourType, MoneyRoundingPolicy } from './calc.js';
import { round, roundHalfEven, PRECISION } from './money.js';
import type { SaleAmountBasis } from './saleAmount.js';

const D = (value: Decimal.Value | null | undefined): Decimal => new Decimal(value ?? 0);

export type PurchaseAmountType = 'N' | 'G' | 'F' | 'P';

export interface PurchaseAmountLine {
  pieces?: Decimal.Value | null;
  grossWt?: Decimal.Value | null;
  netWt?: Decimal.Value | null;
  ghatWt?: Decimal.Value | null;
  fineWt?: Decimal.Value | null;
  rate?: number | null;
  rateType?: unknown;
  urdRateType?: unknown;
  itemAmount?: number | null;
  labourType?: LabourType;
  labourRate?: Decimal.Value | null;
  labourPct?: Decimal.Value | null;
  labourFixed?: Decimal.Value | null;
  labourAmount?: number | null;
  otherAmount?: Decimal.Value | null;
}

export interface PurchaseLineAmounts {
  item: number;
  labour: number;
  net: number;
}

/** CO_SET.PR_AMT_TYPE as ordinary Purchase uses it: blank/unknown means Fine Wise. */
export function purchaseAmountType(value: unknown): PurchaseAmountType {
  const code = String(value ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  return code === 'N' || code === 'G' || code === 'P' ? code : 'F';
}

/**
 * Ordinary Purchase item basis (`TR_PURC.cs:7394-7417`). URD_RATE_TYPE=N forces net + ghat;
 * otherwise PR_AMT_TYPE selects gross, net + ghat, or fine. RATE_TYPE=P selects pieces, while
 * RATE_TYPE=1/K retains the selected weight and changes only the divisor.
 */
export function purchaseAmountBasis(
  line: PurchaseAmountLine,
  companyAmountType: unknown,
): SaleAmountBasis {
  const rateType = String(line.rateType ?? '')
    .trim()
    .toUpperCase();
  if (rateType === 'P') return { quantity: D(line.pieces).toNumber(), rateDivisor: 1 };

  const urdRateType = String(line.urdRateType ?? '')
    .trim()
    .toUpperCase();
  const netWithGhat = D(line.netWt).plus(line.ghatWt ?? 0);
  const amountType = purchaseAmountType(companyAmountType);
  const quantity =
    urdRateType === 'N'
      ? netWithGhat
      : amountType === 'G'
        ? D(line.grossWt)
        : amountType === 'N'
          ? netWithGhat
          : D(line.fineWt);

  return {
    quantity: quantity.toNumber(),
    rateDivisor: rateType === '1' ? 10 : rateType === 'K' ? 1000 : 1,
  };
}

/** Derived ordinary-Purchase item amount, rounded directly to whole rupees, midpoint-to-even. */
export function purchaseItemAmount(
  basis: SaleAmountBasis,
  rate: Decimal.Value | null | undefined,
): number {
  return roundHalfEven(D(basis.quantity).times(D(rate).div(basis.rateDivisor)), 0);
}

/** Derived web labour modes at the ordinary-Purchase whole-rupee stage. */
export function purchaseLabourAmount(
  type: LabourType,
  line: PurchaseAmountLine,
  itemAmount: Decimal.Value,
  labourWithGhat: boolean = true,
): number {
  let raw: Decimal;
  switch (type) {
    case 'per_gram':
      raw = D(line.netWt)
        .plus(labourWithGhat ? D(line.ghatWt) : 0)
        .times(D(line.labourRate));
      break;
    case 'per_piece':
      raw = D(line.pieces).times(D(line.labourRate));
      break;
    case 'percentage':
      raw = D(itemAmount).times(D(line.labourPct)).div(100);
      break;
    case 'fixed':
      raw = D(line.labourFixed);
      break;
  }
  return roundHalfEven(raw, 0);
}

/**
 * Shared ordinary-Purchase component calculation for the writer and browser preview.
 * Explicit item/labour amounts remain untouched. Only derived components become whole rupees;
 * the detail net retains two decimals so a fractional other charge is not lost.
 */
export function purchaseLineAmounts(
  line: PurchaseAmountLine,
  companyAmountType: unknown,
  policy?: MoneyRoundingPolicy,
  labourWithGhat: boolean = true,
): PurchaseLineAmounts {
  const rate =
    line.rate == null
      ? undefined
      : policy
        ? policy.roundPurchaseRate(Number(line.rate))
        : Number(line.rate);
  const item =
    line.itemAmount != null
      ? Number(line.itemAmount)
      : rate == null
        ? 0
        : purchaseItemAmount(purchaseAmountBasis(line, companyAmountType), rate);
  const labour =
    line.labourAmount != null
      ? Number(line.labourAmount)
      : line.labourType
        ? purchaseLabourAmount(line.labourType, line, item, labourWithGhat)
        : 0;
  const net = round(
    D(item)
      .plus(labour)
      .plus(line.otherAmount ?? 0),
    PRECISION.amount,
  );
  return { item, labour, net };
}
