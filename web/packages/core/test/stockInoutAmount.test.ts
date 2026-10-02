import { describe, expect, it } from 'vitest';
import { stockInoutItemAmount } from '../src/stockInoutAmount.js';

/**
 * G87: TR_INOUT `CommPassTotal` (unified/src/csharp/DataCareNext/TR_INOUT.cs:4085-4117) recomputes ItAmt only
 * when ItRate and Fine are both non-zero, by RATE_TYPE (grid column 50):
 *   'P' Math.Round(Pcs × ItRate, 0), '1' Math.Round(Fine × (ItRate / 10), 0),
 *   'K' Math.Round(Fine × (ItRate / 1000), 0), otherwise Math.Round(Fine × ItRate, 0)
 * — .NET Math.Round(x, 0) rounds half to even. It reads the cells as displayed: Pcs "0", Fine "0.000",
 * ItRate "0.00", each Strings.Format (half away from zero; :3569-3613).
 */
describe('stockInoutItemAmount', () => {
  it('values a rate per gram on the fine weight, to whole rupees', () => {
    expect(stockInoutItemAmount({ rateType: '', pcs: 1, fine: 9.16, rate: 7000 })).toBe(64120);
    expect(stockInoutItemAmount({ rateType: null, pcs: 1, fine: 1.235, rate: 1000.5 })).toBe(1236); // 1235.6175
    expect(stockInoutItemAmount({ rateType: 'G', pcs: 1, fine: 2.2, rate: 6250.45 })).toBe(13751); // 13750.99
  });

  it("values RATE_TYPE '1' per 10 g and 'K' per kg", () => {
    expect(stockInoutItemAmount({ rateType: '1', pcs: 1, fine: 9.16, rate: 65000 })).toBe(59540);
    expect(stockInoutItemAmount({ rateType: '1', pcs: 1, fine: 0.333, rate: 72000 })).toBe(2398); // 2397.6
    expect(stockInoutItemAmount({ rateType: 'K', pcs: 1, fine: 1000, rate: 75000 })).toBe(75000);
    expect(stockInoutItemAmount({ rateType: 'K', pcs: 1, fine: 523.456, rate: 80000 })).toBe(41876); // 41876.48
  });

  it("values RATE_TYPE 'P' on whole pieces, still only when the fine is non-zero", () => {
    expect(stockInoutItemAmount({ rateType: 'P', pcs: 3, fine: 0.5, rate: 1500 })).toBe(4500);
    // Pcs is displayed as "0": 2.5 rounds half away from zero to 3.
    expect(stockInoutItemAmount({ rateType: 'P', pcs: 2.5, fine: 1, rate: 100 })).toBe(300);
    expect(stockInoutItemAmount({ rateType: 'P', pcs: 3, fine: 0, rate: 1500 })).toBeNull();
  });

  it('rounds the amount half to even, as Math.Round(x, 0) does', () => {
    expect(stockInoutItemAmount({ rateType: '', pcs: 1, fine: 0.5, rate: 5 })).toBe(2); // 2.5
    expect(stockInoutItemAmount({ rateType: '', pcs: 1, fine: 1.5, rate: 1 })).toBe(2); // 1.5
    expect(stockInoutItemAmount({ rateType: '', pcs: 1, fine: 0.7, rate: 5 })).toBe(4); // 3.5
    expect(stockInoutItemAmount({ rateType: '1', pcs: 1, fine: 1, rate: 25 })).toBe(2); // 2.5
  });

  it('reads the fine at 3 and the rate at 2 decimals, half away from zero, before multiplying', () => {
    // Fine 1.2345 is displayed 1.235; rate 1000.555 is displayed 1000.56: 1.235 × 1000.56 = 1235.6916.
    expect(stockInoutItemAmount({ rateType: '', pcs: 1, fine: 1.2345, rate: 1000.555 })).toBe(1236);
    // A rate that displays as 0.00 is zero: nothing is recomputed.
    expect(stockInoutItemAmount({ rateType: '', pcs: 1, fine: 5, rate: 0.004 })).toBeNull();
    expect(stockInoutItemAmount({ rateType: '', pcs: 1, fine: 0.0004, rate: 5000 })).toBeNull();
  });

  it('returns null, so the entered amount stands, when the rate or the fine is zero', () => {
    expect(stockInoutItemAmount({ rateType: '', pcs: 1, fine: 9.16, rate: 0 })).toBeNull();
    expect(stockInoutItemAmount({ rateType: 'K', pcs: 1, fine: 0, rate: 75000 })).toBeNull();
  });

  it("matches the rate type case-sensitively, as the desktop's switch does (surrounding spaces ignored)", () => {
    // 'k' is not 'K': it falls to the per-gram branch.
    expect(stockInoutItemAmount({ rateType: 'k', pcs: 1, fine: 2, rate: 1000 })).toBe(2000);
    expect(stockInoutItemAmount({ rateType: ' K ', pcs: 1, fine: 2, rate: 1000 })).toBe(2);
  });
});
