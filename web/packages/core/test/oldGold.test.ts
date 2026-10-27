import { describe, expect, it } from 'vitest';
import {
  oldGoldAmountFromRate,
  oldGoldBasisWeight,
  oldGoldConversionWeight,
  oldGoldFine,
  oldGoldRateFromAmount,
  resolveOldGoldValuation,
  valueOldGoldLine,
} from '../src/oldGold.js';

/**
 * Old-metal (exchange) line valuation, `unified/src/csharp/DataCareNext/TR_SALE.cs` `CommPassTotal_Old`.
 *
 * Expected values are worked by hand from the desktop statements, never read from the web output:
 *
 *   fine  [8]  = Strings.Format(net * touch / 100, "0.000")          :7905 (half-up, 3 decimals)
 *              = Strings.Format(net, "0.000") when touch is 0        :7903, :7907-7910
 *   amount [13] = Strings.Format(Math.Round(basis * rate, 0), "0.00") :7959 (net-wise), :7963 (fine-wise),
 *                                                                     :7921/:7944 (conversion) — half to even
 *   rate  [11] = Strings.Format(TEXT_OLD / basis, "0.00")            :7930, :7983/:7988 — half-up
 */
describe('old-gold fine weight (TR_SALE.cs:7903-7910)', () => {
  it('is net x touch / 100 at THREE decimals, half-up', () => {
    // The N40 round-trip fixture: 5.3 g at 84 touch = 4.452 g fine. Two decimals (the old web) gave 4.45.
    expect(oldGoldFine({ netWt: 5.3, touch: 84 })).toBe(4.452);
    expect(oldGoldFine({ netWt: 10, touch: 90 })).toBe(9);
    // Midpoint at the third decimal: 1.0005 * 100 / 100 rounds half-up to 1.001.
    expect(oldGoldFine({ netWt: 1.0005, touch: 100 })).toBe(1.001);
    // Negative (a reversal row) rounds away from zero, as Strings.Format does.
    expect(oldGoldFine({ netWt: -1.0005, touch: 100 })).toBe(-1.001);
  });

  it('falls back to the net weight when no touch is given (:7907-7910)', () => {
    expect(oldGoldFine({ netWt: 5.3, touch: 0 })).toBe(5.3);
    expect(oldGoldFine({ netWt: 5.3 })).toBe(5.3);
    expect(oldGoldFine({ netWt: 5.3456 })).toBe(5.346);
  });

  it('is zero without a net weight', () => {
    expect(oldGoldFine({ netWt: 0, touch: 84 })).toBe(0);
    expect(oldGoldFine({})).toBe(0);
  });
});

describe('old-gold amount from rate (TR_SALE.cs:7921-7963)', () => {
  it('values the N40 fixture at the desktop figure: Math.Round(4.452 x 5800, 0) = 25822', () => {
    // The old web used fine 4.45 and stored 25810; the screen previewed 25821.60. Desktop: 25821.6 -> 25822.
    expect(valueOldGoldLine({ netWt: 5.3, touch: 84, rate: 5800 })).toEqual({
      fine: 4.452,
      rate: 5800,
      amount: 25822,
      conversionWt: 0,
    });
  });

  it('rounds the amount half to even at zero decimals, both signs', () => {
    // basis 0.5 x rate 5 = 2.5 -> 2 (even); 1.5 -> 2; -2.5 -> -2.
    expect(oldGoldAmountFromRate({ fineWt: 0.5, rate: 5 })).toBe(2);
    expect(oldGoldAmountFromRate({ fineWt: 0.3, rate: 5 })).toBe(2);
    expect(oldGoldAmountFromRate({ fineWt: -0.5, rate: 5 })).toBe(-2);
  });

  it('keeps the existing branch order: conversion, then net-wise, then fine-wise', () => {
    expect(oldGoldBasisWeight({ netWt: 4.3, fineWt: 3.87, conversionWt: 0.1 })).toBe(0.1);
    expect(oldGoldAmountFromRate({ netWt: 4.3, fineWt: 3.87, rate: 100, rateType: 'N' })).toBe(430);
    expect(oldGoldAmountFromRate({ netWt: 4.3, fineWt: 3.87, rate: 100, rateType: 'F' })).toBe(387);
    expect(oldGoldAmountFromRate({ fineWt: 3.87, rate: 0 })).toBe(0);
  });
});

describe('old-gold rate from a typed amount (TR_SALE.cs:7930, :7983-7988)', () => {
  it('back-calculates the rate at two decimals, half-up, through the decimal kernel', () => {
    // 1.005 / 1 is a binary-float midpoint; Strings.Format("0.00") gives 1.01.
    expect(oldGoldRateFromAmount({ fineWt: 1, amount: 1.005 })).toBe(1.01);
    expect(oldGoldRateFromAmount({ fineWt: 1, amount: -1.005 })).toBe(-1.01);
    expect(oldGoldRateFromAmount({ fineWt: 3.87, amount: 387 })).toBe(100);
    expect(oldGoldRateFromAmount({ fineWt: 0, amount: 387 })).toBe(0);
  });

  it('keeps the typed amount when no rate was given', () => {
    expect(resolveOldGoldValuation({ fineWt: 3.87, amount: 387, rateType: 'F' })).toEqual({
      rate: 100,
      amount: 387,
    });
    expect(valueOldGoldLine({ netWt: 4.3, touch: 90, amount: 400 })).toEqual({
      fine: 3.87,
      rate: 103.36,
      amount: 400,
      conversionWt: 0,
    });
  });

  it('values nothing when neither rate nor amount is given', () => {
    expect(valueOldGoldLine({ netWt: 4.3, touch: 90 })).toEqual({
      fine: 3.87,
      rate: 0,
      amount: 0,
      conversionWt: 0,
    });
  });

  it('G89: derives the conversion weight from Con% and the fine, ignoring a posted conversionWt', () => {
    // fine = 10 x 90 / 100 = 9.000. Con% 92 (<=100): round(9/92*100 - 9, 3) + 9 = 9.783.
    expect(oldGoldConversionWeight({ fineWt: 9, conversionPct: 92, conversionWt: 50 })).toBeCloseTo(
      9.783,
      3,
    );
    // Con% 105 (>100, an uplift): round(9 x 105 / 100, 3) = 9.45.
    expect(oldGoldConversionWeight({ fineWt: 9, conversionPct: 105 })).toBe(9.45);
    // Con% 0: no conversion, falls back to the posted conversionWt (a legacy row).
    expect(oldGoldConversionWeight({ fineWt: 9, conversionPct: 0, conversionWt: 0.1 })).toBe(0.1);
    // valueOldGoldLine returns the DERIVED conversion weight, and values the row on it (G89).
    const v = valueOldGoldLine({
      netWt: 10,
      touch: 90,
      conversionPct: 92,
      conversionWt: 50,
      rate: 100,
    });
    expect(v.conversionWt).toBeCloseTo(9.783, 3);
    expect(v.amount).toBe(978); // round(9.783 x 100, 0)
  });
});
