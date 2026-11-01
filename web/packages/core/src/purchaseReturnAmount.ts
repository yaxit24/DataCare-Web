import { Decimal } from 'decimal.js';
import { roundHalfEven } from './money.js';
import type { RoundingPolicy } from './roundingPolicy.js';
import type { SaleAmountBasis } from './saleAmount.js';

const D = (value: Decimal.Value | null | undefined): Decimal => new Decimal(value ?? 0);

/**
 * Purchase Return item basis (`TR_KR_ISU.cs:4001-4017`). The form ignores PR_AMT_TYPE: RATE_TYPE=P
 * uses pieces; every weight rate uses the already-formatted fine, with 1 and K changing only the divisor.
 */
export function purchaseReturnAmountBasis(
  line: { pieces?: Decimal.Value; fineWt?: Decimal.Value },
  rateType?: unknown,
): SaleAmountBasis {
  const code = String(rateType ?? '')
    .trim()
    .toUpperCase();
  return {
    quantity: code === 'P' ? D(line.pieces).toNumber() : D(line.fineWt).toNumber(),
    rateDivisor: code === '1' ? 10 : code === 'K' ? 1000 : 1,
  };
}

/**
 * Purchase Return hardcodes whole-rupee midpoint-to-even labour, header-net and final-total stages,
 * while retaining the company's purchase-rate and tax precision (`TR_KR_ISU.cs:4001-4036,6517-6538`).
 */
export function purchaseReturnRoundingPolicy(policy: RoundingPolicy): RoundingPolicy {
  return {
    ...policy,
    labourDecimals: 0,
    billTotalDecimals: 0,
    roundLabourAmount: (value) => roundHalfEven(value, 0),
    roundBillTotal: (value) => roundHalfEven(value, 0),
  };
}
