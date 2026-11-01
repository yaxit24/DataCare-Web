import { describe, expect, it } from 'vitest';
import {
  purchaseReturnAmountBasis,
  purchaseReturnRoundingPolicy,
  resolveRoundingPolicy,
  saleItemAmountWhole,
} from '../src/index.js';

describe('TR_KR_ISU Purchase Return amount policy (G198/N188)', () => {
  it('uses fine for weight rates and pieces only for RATE_TYPE P', () => {
    const line = { pieces: 3, fineWt: 9.16 };
    expect(purchaseReturnAmountBasis(line)).toEqual({ quantity: 9.16, rateDivisor: 1 });
    expect(purchaseReturnAmountBasis(line, 'G')).toEqual({ quantity: 9.16, rateDivisor: 1 });
    expect(purchaseReturnAmountBasis(line, '1')).toEqual({ quantity: 9.16, rateDivisor: 10 });
    expect(purchaseReturnAmountBasis(line, 'K')).toEqual({ quantity: 9.16, rateDivisor: 1000 });
    expect(purchaseReturnAmountBasis(line, 'P')).toEqual({ quantity: 3, rateDivisor: 1 });
  });

  it('rounds the exact item product directly to a whole rupee', () => {
    expect(saleItemAmountWhole(purchaseReturnAmountBasis({ fineWt: 9.16 }), 6123.45)).toBe(56091);
    expect(saleItemAmountWhole(purchaseReturnAmountBasis({ fineWt: 1 }), 1.499)).toBe(1);
  });

  it('keeps tax and purchase-rate precision while making labour and bill totals whole', () => {
    const policy = purchaseReturnRoundingPolicy(
      resolveRoundingPolicy({ TAX_ROF: '2', LBR_ROF: '2', PR_RATE_ROF: '2', TOT_AMT_ROF: '2' }),
    );
    expect(policy.roundPurchaseRate(6123.456)).toBe(6123.46);
    expect(policy.roundTaxAmount(1753.985)).toBe(1753.98);
    expect(policy.roundLabourAmount(2374.5)).toBe(2374);
    expect(policy.roundBillTotal(60219.98)).toBe(60220);
  });
});
