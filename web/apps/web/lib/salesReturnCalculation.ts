import {
  billTotals,
  fineFor,
  labourCharge,
  round,
  roundHalfEven,
  saleReturnAmountBasis,
  saleItemAmountWhole,
  salesReturnRoundingPolicy,
  type BillTotals,
  type RoundingPolicy,
} from '@datacare/core';

export interface SaleReturnPreviewLine {
  pcs?: unknown;
  grossWt?: unknown;
  netWt?: unknown;
  touch?: unknown;
  rate?: unknown;
  making?: unknown;
  ghtWt?: unknown;
  westPct?: unknown;
  fineWt?: unknown;
  metalAmount?: unknown;
  otherAmount?: unknown;
  rateType?: unknown;
}

const number = (value: unknown): number => Number(value || 0);

/** TR_SALE_RTN.cs:4928-4952: F and G are explicit; N, blank and P use net + ghat. */
export function saleReturnAmountType(value: unknown): 'N' | 'G' | 'F' {
  const code = String(value ?? '')
    .trim()
    .toUpperCase();
  return code === 'F' || code === 'G' ? code : 'N';
}

/** Desktop Sales Return line preview, shared by every render of the New return grid. */
export function saleReturnLinePreview(
  line: SaleReturnPreviewLine,
  policy: RoundingPolicy,
  amountType: 'N' | 'G' | 'F',
  labourWithGhat: boolean,
): { fine: number; metal: number; mk: number; net: number } {
  const returnPolicy = salesReturnRoundingPolicy(policy);
  const fine = line.fineWt
    ? number(line.fineWt)
    : fineFor('sale', {
        netWt: number(line.netWt),
        touch: number(line.touch),
        ghtWt: number(line.ghtWt),
        westPct: number(line.westPct),
      });
  const rate = policy.roundItemRate(number(line.rate));
  const basis = saleReturnAmountBasis(
    {
      pcs: number(line.pcs),
      grossWt: number(line.grossWt),
      netWt: number(line.netWt),
      ghtWt: number(line.ghtWt),
      fineWt: fine,
    },
    amountType,
    line.rateType,
  );
  const metal = line.metalAmount
    ? returnPolicy.roundBillTotal(number(line.metalAmount))
    : basis.quantity > 0 && rate
      ? saleItemAmountWhole(basis, rate)
      : 0;
  const mk = line.making
    ? labourCharge(
        'per_gram',
        {
          netWt: number(line.netWt),
          ghatWt: number(line.ghtWt),
          withGhat: labourWithGhat,
          rate: number(line.making),
        },
        returnPolicy,
      )
    : 0;
  return {
    fine,
    metal,
    mk,
    // Sales Return keeps a whole-rupee, midpoint-to-even line net (salesReturnRoundingPolicy, TR_SALE_RTN.cs).
    // This is deliberately not `lineTotalDesktop`, which follows the Sale grid and keeps paise.
    net: roundHalfEven(round(metal + mk + number(line.otherAmount), 2), 0),
  };
}

export function saleReturnBillTotals(
  input: {
    lineNetTotal: number;
    discountAmount?: number;
    taxRatePct: number;
    interState: boolean;
  },
  policy: RoundingPolicy,
): BillTotals {
  return billTotals(input, salesReturnRoundingPolicy(policy));
}
