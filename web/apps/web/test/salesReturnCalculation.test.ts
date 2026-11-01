import { describe, expect, it } from 'vitest';
import { resolveRoundingPolicy } from '@datacare/core';
import {
  saleReturnAmountType,
  saleReturnBillTotals,
  saleReturnLinePreview,
} from '../lib/salesReturnCalculation';

const policy = resolveRoundingPolicy({
  TAX_ROF: '2',
  LBR_ROF: '2',
  ITM_RATE_ROF: '2',
  TOT_AMT_ROF: '2',
});
const line = {
  itemCode: 'GLD22',
  pcs: '1',
  grossWt: '10.25',
  netWt: '10',
  touch: '91.6',
  rate: '6123.45',
  making: '237.5',
};

describe('TR_SALE_RTN New return preview (G190/N181)', () => {
  it('prices an N company on net plus ghat with whole-rupee half-even stages', () => {
    const amountType = saleReturnAmountType('N');
    const result = saleReturnLinePreview(line, policy, amountType, true);
    expect(result).toEqual({ fine: 9.16, metal: 61234, mk: 2375, net: 63609 });
    expect(
      saleReturnBillTotals(
        { lineNetTotal: result.net, taxRatePct: 3, interState: false },
        policy,
      ),
    ).toMatchObject({ net: 63609, tax: 1908.27, total: 65517 });
  });

  it('keeps an F company on fine weight and treats blank/P as the desktop N branch', () => {
    expect(saleReturnAmountType('')).toBe('N');
    expect(saleReturnAmountType('P')).toBe('N');
    const result = saleReturnLinePreview(line, policy, saleReturnAmountType('F'), true);
    expect(result).toEqual({ fine: 9.16, metal: 56091, mk: 2375, net: 58466 });
    expect(
      saleReturnBillTotals(
        { lineNetTotal: result.net, taxRatePct: 3, interState: false },
        policy,
      ),
    ).toMatchObject({ net: 58466, tax: 1753.98, total: 60220 });
  });
});
