import { describe, expect, it } from 'vitest';
import { billTotals } from '@datacare/core';
import {
  resolveRoundingPolicy,
  RoundingPolicyValidationError,
} from '../src/modules/shared/roundingPolicy.js';

describe('company monetary rounding policy', () => {
  it('defaults every absent or blank flag to the current 2dp half-up behavior', () => {
    const policy = resolveRoundingPolicy({ TAX_ROF: '', LBR_ROF: null });
    expect(policy).toMatchObject({
      taxDecimals: 2,
      labourDecimals: 2,
      itemRateDecimals: 2,
      billTotalDecimals: 2,
      purchaseRateDecimals: 2,
    });
    expect(policy.roundTaxAmount(1.005)).toBe(1.01);
    expect(policy.roundLabourAmount(10.555)).toBe(10.56);
    expect(policy.roundItemRate(7000.125)).toBe(7000.13);
    expect(policy.roundBillTotal(1030.575)).toBe(1030.58);
    expect(policy.roundPurchaseRate(6500.125)).toBe(6500.13);
  });

  it.each([
    ['TAX_ROF', { TAX_ROF: 0 }, 'roundTaxAmount', 12.5, 12],
    ['LBR_ROF', { LBR_ROF: 1 }, 'roundLabourAmount', 12.35, 12.4],
    ['ITM_RATE_ROF', { ITM_RATE_ROF: 2 }, 'roundItemRate', 12.345, 12.34],
    ['TOT_AMT_ROF', { TOT_AMT_ROF: 0 }, 'roundBillTotal', 1030.5, 1030],
    ['PR_RATE_ROF', { PR_RATE_ROF: '3.00' }, 'roundPurchaseRate', 12.3455, 12.346],
  ] as const)(
    '%s controls its money path with desktop midpoint-to-even rounding',
    (_name, flags, fn, value, expected) => {
      const policy = resolveRoundingPolicy(flags);
      expect(policy[fn](value)).toBe(expected);
    },
  );

  it('applies separate total and tax precision to bill totals', () => {
    const defaultTotals = billTotals(
      { lineNetTotal: 1000.55, taxRatePct: 3, interState: false },
      resolveRoundingPolicy(),
    );
    expect(defaultTotals).toMatchObject({ taxable: 1000.55, tax: 30.02, total: 1030.57 });

    const wholeTotals = billTotals(
      { lineNetTotal: 1000.55, taxRatePct: 3, interState: false },
      resolveRoundingPolicy({ TOT_AMT_ROF: 0 }),
    );
    expect(wholeTotals).toMatchObject({ taxable: 1001, tax: 30.03, total: 1031 });
  });

  it.each([
    { TAX_ROF: 6 },
    { LBR_ROF: -1 },
    { ITM_RATE_ROF: 'two' },
    { TOT_AMT_ROF: 1.5 },
    { PR_RATE_ROF: 4 },
  ])('fails closed for unreadable or out-of-range configured values: %o', (flags) => {
    expect(() => resolveRoundingPolicy(flags)).toThrow(RoundingPolicyValidationError);
  });
});

it('ALL_ROF_REMOVE=Y forces four precisions to 2 but not purchase-rate precision', () => {
  const policy = resolveRoundingPolicy({
    ALL_ROF_REMOVE: 'Y',
    TAX_ROF: 0,
    LBR_ROF: 0,
    ITM_RATE_ROF: 0,
    TOT_AMT_ROF: 0,
    PR_RATE_ROF: 3,
  });
  expect(policy).toMatchObject({
    taxDecimals: 2,
    labourDecimals: 2,
    itemRateDecimals: 2,
    billTotalDecimals: 2,
    purchaseRateDecimals: 3,
  });
  expect(policy.roundTaxAmount(12.345)).toBe(12.34);
  expect(policy.roundPurchaseRate(12.3455)).toBe(12.346);
});

it('ALL_ROF_REMOVE blank preserves old policy and invalid configured values fail closed', () => {
  expect(resolveRoundingPolicy({ ALL_ROF_REMOVE: '', TAX_ROF: 0 }).taxDecimals).toBe(0);
  expect(() => resolveRoundingPolicy({ ALL_ROF_REMOVE: 'X' })).toThrow(
    RoundingPolicyValidationError,
  );
});
