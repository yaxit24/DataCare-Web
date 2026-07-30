import { describe, it, expect } from 'vitest';
import { labourCharge, metalAmount, lineNet, gstSplit, billTotals } from '../src/calc.js';

describe('labourCharge', () => {
  it('per_gram = netWt × rate', () => {
    expect(labourCharge('per_gram', { netWt: 10, rate: 100 })).toBe(1000);
  });
  it('per_piece = pcs × rate', () => {
    expect(labourCharge('per_piece', { pcs: 5, rate: 50 })).toBe(250);
  });
  it('percentage = metalAmount × pct / 100', () => {
    expect(labourCharge('percentage', { metalAmount: 1000, pct: 8 })).toBe(80);
  });
  it('fixed = fixed amount', () => {
    expect(labourCharge('fixed', { fixed: 500 })).toBe(500);
  });
});

describe('metalAmount + lineNet', () => {
  it('metal = fine × rate', () => {
    expect(metalAmount(9.16, 6000)).toBe(54960);
  });
  it('line net = metal + labour + other', () => {
    expect(lineNet({ metal: 54960, labour: 1000, other: 40 })).toBe(56000);
  });
});

describe('gstSplit', () => {
  it('intra-state splits equally into CGST/SGST', () => {
    expect(gstSplit(300, false)).toEqual({ cgst: 150, sgst: 150, igst: 0 });
  });
  it('inter-state goes entirely to IGST', () => {
    expect(gstSplit(300, true)).toEqual({ cgst: 0, sgst: 0, igst: 300 });
  });
});

describe('billTotals', () => {
  it('computes taxable/tax/total with no round-off (intra)', () => {
    const t = billTotals({
      lineNetTotal: 1000,
      discountAmount: 100,
      taxRatePct: 3,
      interState: false,
    });
    expect(t.taxable).toBe(900);
    expect(t.tax).toBe(27);
    expect(t.cgst).toBe(13.5);
    expect(t.sgst).toBe(13.5);
    expect(t.total).toBe(927);
    expect(t.roundOff).toBe(0);
  });
  it('applies round-off to nearest unit', () => {
    const t = billTotals({
      lineNetTotal: 1000,
      discountAmount: 0,
      taxRatePct: 3.33,
      interState: true,
    });
    expect(t.tax).toBe(33.3);
    expect(t.igst).toBe(33.3);
    expect(t.total).toBe(1033); // 1033.30 -> 1033
    expect(t.roundOff).toBe(-0.3);
  });
});
