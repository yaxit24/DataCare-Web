import { describe, it, expect } from 'vitest';
import { round, fineWeight, PRECISION } from '../src/money.js';

describe('round (half-up)', () => {
  it('rounds money to 2dp half-up', () => {
    expect(round(1.005, 2)).toBe(1.01);
    expect(round(2.344, 2)).toBe(2.34);
    expect(round(2.345, 2)).toBe(2.35);
  });
});

describe('fineWeight = netWt * touch / 100', () => {
  it('computes fine weight to 3dp', () => {
    expect(fineWeight(10, 91.6)).toBe(9.16);
    expect(fineWeight(12.5, 75)).toBe(9.375);
  });
  it('uses fine precision by default', () => {
    expect(PRECISION.fine).toBe(3);
    expect(fineWeight(1, 33.3333)).toBe(0.333);
  });
});
