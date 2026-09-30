import { describe, expect, it } from 'vitest';
import { rateFactor, settleMoneyMetal, settlementBalance } from '../src/settlement.js';

/**
 * Money/metal settlement golden vectors.
 *
 * Every expected value below is derived by hand from `TR_TOUR_SALE.cs:12999-13130` and cited, so a future
 * change to the engine has to disagree with the desktop arithmetic to pass. Vector ids follow the project's
 * existing `GV-` convention.
 */
describe('settlement rate basis', () => {
  it('GV-SETTLE-BASIS-001: maps MsRatePar to its factor', () => {
    // MsRatePar comes from CO_SET.RATE_PAR: G Gram Wise / T 10gm Wise / K Kg Wise (UT_SETTING.cs:4256-4258).
    expect(rateFactor('G')).toBe(1);
    expect(rateFactor('T')).toBe(10);
    expect(rateFactor('K')).toBe(1000);
    // The desktop reads only the first character, and an unset value defaults to per-gram.
    expect(rateFactor('T 10gm Wise')).toBe(10);
    expect(rateFactor(undefined)).toBe(1);
    expect(rateFactor('')).toBe(1);
  });
});

describe('settlement rate derivation', () => {
  it('GV-SETTLE-RATE-001: explicit conversion rate and percentage', () => {
    // :13001  fineRate = Math.Round(convRate / convPct * 100, 2)
    // 6400 / 91.6 * 100 = 6986.899...  -> 6986.9
    const r = settleMoneyMetal({ convRate: 6400, convPct: 91.6 });
    expect(r.fineRate).toBeCloseTo(6986.9, 2);
    expect(r.derived).toContain('fineRate');
  });

  it('GV-SETTLE-RATE-002: conversion rate alone is used as the rate', () => {
    // :13005  fineRate = convRate
    expect(settleMoneyMetal({ convRate: 7000 }).fineRate).toBeCloseTo(7000, 2);
  });

  it('GV-SETTLE-RATE-003: a supplied rate is never overwritten', () => {
    // Every derivation is guarded by `if fineRate == 0`, so an operator-entered rate always wins.
    const r = settleMoneyMetal({ fineRate: 5000, convRate: 6400, convPct: 91.6 });
    expect(r.fineRate).toBe(5000);
    expect(r.derived).not.toContain('fineRate');
  });

  it('GV-SETTLE-RATE-004: back-calculated from a DR amount and CR fine, per-10-gram', () => {
    // :13013  fineRate = drAmt * 10 / crFine  (Format "0.000")
    // 70000 * 10 / 100 = 7000.000
    const r = settleMoneyMetal({ drAmt: 70000, crFine: 100, ratePar: 'T' });
    expect(r.fineRate).toBeCloseTo(7000, 3);
  });

  it('GV-SETTLE-RATE-005: per-kilogram basis multiplies by 1000', () => {
    // :13020  fineRate = drAmt * 1000 / crFine
    // 70000 * 1000 / 100 = 700000
    expect(settleMoneyMetal({ drAmt: 70000, crFine: 100, ratePar: 'K' }).fineRate).toBeCloseTo(
      700000,
      3,
    );
  });

  it('GV-SETTLE-RATE-006: per-gram basis uses no factor', () => {
    // :13025  fineRate = drAmt / crFine
    expect(settleMoneyMetal({ drAmt: 70000, crFine: 100, ratePar: 'G' }).fineRate).toBeCloseTo(
      700,
      3,
    );
  });

  it('GV-SETTLE-RATE-007: back-calculated from a CR amount and DR fine', () => {
    // :13034  the mirrored branch
    const r = settleMoneyMetal({ crAmt: 70000, drFine: 100, ratePar: 'T' });
    expect(r.fineRate).toBeCloseTo(7000, 3);
  });
});

describe('settlement money from metal', () => {
  it('GV-SETTLE-AMT-001: DR amount from CR fine at a per-10-gram rate', () => {
    // :13055  drAmt = Math.Round(crFine * (fineRate / 10), 0)
    // 100 x (7000 / 10) = 70,000
    const r = settleMoneyMetal({ fineRate: 7000, crFine: 100, ratePar: 'T' });
    expect(r.drAmt).toBe(70000);
    expect(r.derived).toContain('drAmt');
  });

  it('GV-SETTLE-AMT-002: money is rounded to WHOLE rupees', () => {
    // Math.Round(x, 0): 9.16 g x (7000/10) = 6412.0 exactly; use a rate that produces a fraction.
    // 9.163 x 700.05 = 6414.55... -> 6415 (nearest whole rupee)
    const r = settleMoneyMetal({ fineRate: 7000.5, crFine: 9.163, ratePar: 'T' });
    expect(Number.isInteger(r.drAmt)).toBe(true);
    expect(r.drAmt).toBe(6415);
  });

  it('GV-SETTLE-AMT-003: money uses BANKER rounding at the midpoint', () => {
    // 0.5 exactly: banker's rounds to the even integer, so 2.5 -> 2 (JavaScript Math.round gives 3).
    // crFine 0.5 at rate 10 per gram -> 5. Use 2.5 directly: fine 2.5 x rate 1 = 2.5 -> 2.
    const r = settleMoneyMetal({ fineRate: 1, crFine: 2.5, ratePar: 'G' });
    expect(r.drAmt).toBe(2);
    // And 3.5 -> 4, which is what distinguishes banker's from truncation.
    expect(settleMoneyMetal({ fineRate: 1, crFine: 3.5, ratePar: 'G' }).drAmt).toBe(4);
  });

  it('GV-SETTLE-AMT-004: CR amount from DR fine (mirrored branch)', () => {
    // :13076
    const r = settleMoneyMetal({ fineRate: 7000, drFine: 50, ratePar: 'T' });
    expect(r.crAmt).toBe(35000);
  });

  it('GV-SETTLE-AMT-005: a supplied amount is never overwritten', () => {
    const r = settleMoneyMetal({ fineRate: 7000, crFine: 100, drAmt: 12345, ratePar: 'T' });
    expect(r.drAmt).toBe(12345);
    expect(r.derived).not.toContain('drAmt');
  });
});

describe('settlement metal from money', () => {
  it('GV-SETTLE-FINE-001: CR fine from a DR amount at a per-10-gram rate', () => {
    // :13097  crFine = drAmt * 10 / fineRate  (Format "0.000")
    // 70000 x 10 / 7000 = 100.000
    const r = settleMoneyMetal({ fineRate: 7000, drAmt: 70000, ratePar: 'T' });
    expect(r.crFine).toBeCloseTo(100, 3);
    expect(r.derived).toContain('crFine');
  });

  it('GV-SETTLE-FINE-002: fine keeps THREE decimals', () => {
    // 10000 x 10 / 7000 = 14.2857... -> 14.286 at three decimals, half-up.
    const r = settleMoneyMetal({ fineRate: 7000, drAmt: 10000, ratePar: 'T' });
    expect(r.crFine).toBeCloseTo(14.286, 3);
  });

  it('GV-SETTLE-FINE-003: DR fine from a CR amount (mirrored branch)', () => {
    // :13118
    const r = settleMoneyMetal({ fineRate: 7000, crAmt: 35000, ratePar: 'T' });
    expect(r.drFine).toBeCloseTo(50, 3);
  });

  it('GV-SETTLE-FINE-004: the two directions are inverses', () => {
    // Deriving money from metal and then metal from that money must return the original weight.
    const a = settleMoneyMetal({ fineRate: 7000, crFine: 100, ratePar: 'T' });
    const b = settleMoneyMetal({ fineRate: 7000, drAmt: a.drAmt, ratePar: 'T' });
    expect(b.crFine).toBeCloseTo(100, 3);
  });
});

describe('settlement balance', () => {
  it('GV-SETTLE-BAL-001: money and metal are reported separately', () => {
    // A party can owe rupees while the shop owes them gold, so the two sides are never netted together.
    const r = settleMoneyMetal({
      fineRate: 7000,
      drAmt: 70000,
      crAmt: 25000,
      drFine: 12,
      crFine: 4,
    });
    const b = settlementBalance(r);
    expect(b.amountDue).toBeCloseTo(45000, 2);
    expect(b.fineDue).toBeCloseTo(8, 3);
  });

  it('GV-SETTLE-BAL-002: an empty settlement derives nothing', () => {
    const r = settleMoneyMetal({});
    expect(r).toMatchObject({ fineRate: 0, drAmt: 0, crAmt: 0, drFine: 0, crFine: 0 });
    expect(r.derived).toEqual([]);
  });

  it('GV-SETTLE-BAL-003: a non-finite input is treated as zero, not NaN', () => {
    const r = settleMoneyMetal({ fineRate: Number.NaN, drAmt: Number.POSITIVE_INFINITY });
    expect(r.fineRate).toBe(0);
    expect(r.drAmt).toBe(0);
  });
});
