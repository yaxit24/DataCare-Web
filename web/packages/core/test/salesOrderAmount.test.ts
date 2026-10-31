import { describe, expect, it } from 'vitest';
import { salesOrderBill, salesOrderItemAmount, salesOrderItemWeight } from '../src/index.js';

// TR_SALE_ORD.cs:6571-6672 (item amount) and :11340-11342 (bill); see src/salesOrderAmount.ts.
describe('Sales Order item amount (TR_SALE_ORD CommPassTotal)', () => {
  const line = { pcs: 1, grossWt: 10.25, netWt: 10, ghtWt: 0, touch: 91.6, westPct: 0 };

  it('prices SL_AMT_TYPE N (and blank) on net + ghat in whole rupees, half to even', () => {
    // 10 × 6,123.45 = 61,234.5 → 61,234 (Math.Round is banker's rounding).
    expect(salesOrderItemAmount(line, 'N', 6123.45)).toBe(61234);
    expect(salesOrderItemAmount(line, '', 6123.45)).toBe(61234);
    expect(salesOrderItemAmount({ ...line, ghtWt: 0.5 }, 'N', 1000)).toBe(10500);
    expect(salesOrderItemAmount({ ...line, netWt: 3.5 }, 'N', 1)).toBe(4);
  });

  it('prices SL_AMT_TYPE F on the fine weight, and on net when touch and wastage are blank', () => {
    expect(salesOrderItemWeight(line, 'F')).toBe(9.16);
    // 9.16 × 6,123.45 = 56,090.802 → 56,091.
    expect(salesOrderItemAmount(line, 'F', 6123.45)).toBe(56091);
    expect(salesOrderItemAmount({ ...line, touch: 0 }, 'F', 1000)).toBe(10000);
    // (net + ghat) × (touch + wastage) / 100 = 10.5 × 92 / 100 = 9.66.
    expect(salesOrderItemWeight({ ...line, ghtWt: 0.5, westPct: 0.4 }, 'F')).toBe(9.66);
  });

  it('prices SL_AMT_TYPE G on the gross weight', () => {
    expect(salesOrderItemAmount(line, 'G', 1000)).toBe(10250);
  });

  it('applies the line rate type: pieces, per 10 g and per kg', () => {
    expect(salesOrderItemAmount({ ...line, pcs: 2 }, 'N', 1500, 'P')).toBe(3000);
    expect(salesOrderItemAmount(line, 'N', 6000, '1')).toBe(6000);
    expect(salesOrderItemAmount({ ...line, netWt: 50 }, 'N', 80000, 'K')).toBe(4000);
  });
});

describe('Sales Order bill (TR_SALE_ORD.cs:11340-11342)', () => {
  it('rounds the tax and the total to whole rupees', () => {
    expect(salesOrderBill(63609, 3)).toEqual({ net: 63609, tax: 1908, total: 65517 });
    expect(salesOrderBill(7700, 3)).toEqual({ net: 7700, tax: 231, total: 7931 });
  });

  it('rounds a half rupee of tax to even', () => {
    expect(salesOrderBill(50, 3).tax).toBe(2); // 1.5 → 2
    expect(salesOrderBill(150, 3).tax).toBe(4); // 4.5 → 4
  });
});
