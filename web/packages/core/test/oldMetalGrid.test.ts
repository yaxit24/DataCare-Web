import { describe, expect, it } from 'vitest';
import { oldGoldFine, valueOldGoldLine } from '../src/oldGold.js';
import {
  OLD_METAL_RATE_TYPE_MESSAGE,
  oldMetalHeaderTotals,
  oldMetalRateTypeError,
  oldMetalTodayRates,
  oldMetalTouchFromAmount,
} from '../src/oldMetalGrid.js';

/**
 * WP-26 kernel vectors for the old-metal grid of `TR_SALE.cs` (`CommPassTotal_Old`, `BILL_TOTAL`). Every expected
 * value is worked by hand from the desktop statement quoted next to it (cases.md, `sales-invoice.oldmetal.*`).
 */
describe('sales-invoice.oldmetal.fine-from-touch (TR_SALE.cs:7905, :7909)', () => {
  it('fine = net x touch / 100 at three decimals; no touch gives the net', () => {
    // 10.000 x 91.6 / 100 = 9.160
    expect(oldGoldFine({ netWt: 10, touch: 91.6 })).toBe(9.16);
    expect(oldGoldFine({ netWt: 10 })).toBe(10);
  });
});

describe('sales-invoice.oldmetal.amount-half-to-even (TR_SALE.cs:7959)', () => {
  it('Math.Round(5.000 x 100.5, 0) = Math.Round(502.5) = 502 (banker rounding, not 503)', () => {
    expect(valueOldGoldLine({ netWt: 5, rate: 100.5, rateType: 'N' }).amount).toBe(502);
  });
});

describe('sales-invoice.oldmetal.conversion-weight-above-100 (TR_SALE.cs:7917, :7921)', () => {
  it('fine 9.160, Con% 120: weight Round(10.992, 3) = 10.992, amount Round(65,952.000, 0) = 65,952', () => {
    const v = valueOldGoldLine({
      netWt: 10,
      touch: 91.6,
      conversionPct: 120,
      rate: 6000,
      rateType: 'N',
    });
    expect(v.fine).toBe(9.16);
    expect(v.conversionWt).toBe(10.992);
    expect(v.amount).toBe(65952);
  });
});

describe('sales-invoice.oldmetal.rate-type-refusal-text (TR_SALE.cs:7667-7669)', () => {
  it('refuses anything but N or F, case-sensitive, with the desktop text', () => {
    expect(OLD_METAL_RATE_TYPE_MESSAGE).toBe(
      'Please Slelect Rate type = N - Net Wise Or F - Fine Wise',
    );
    expect(oldMetalRateTypeError('X')).toBe(OLD_METAL_RATE_TYPE_MESSAGE);
    expect(oldMetalRateTypeError('n')).toBe(OLD_METAL_RATE_TYPE_MESSAGE);
    expect(oldMetalRateTypeError('N')).toBeNull();
    expect(oldMetalRateTypeError('F')).toBeNull();
    expect(oldMetalRateTypeError('')).toBeNull();
  });
});

describe("today's per-gram rates (TR_SALE.cs:20833, :20854)", () => {
  it('FINE_GL_RATE 60,000 / 10 = 6,000.00; FINE_SL_RATE 80,000 / 1000 = 80.00; no row = 0', () => {
    expect(oldMetalTodayRates({ fineGoldRate: 60000, fineSilverRate: 80000 })).toEqual({
      gold: 6000,
      silver: 80,
    });
    expect(oldMetalTodayRates(null)).toEqual({ gold: 0, silver: 0 });
  });
});

describe('sales-invoice.oldmetal.touch-from-amount-* (TR_SALE.cs:7970, :7981-7991)', () => {
  it('OG: amount 54,000 typed on net 10.000 -> rate 5,400.00, touch 54,000/6,000/10 x 100 = 90.00, fine 9.000', () => {
    const valued = valueOldGoldLine({ netWt: 10, amount: 54000, rateType: 'N' });
    expect(valued.rate).toBe(5400); // 54,000.00 / 10.000
    expect(
      oldMetalTouchFromAmount({
        itCode: 'OG',
        rateType: 'N',
        netWt: 10,
        amount: valued.amount,
        todayGoldRate: 6000,
      }),
    ).toEqual({ touch: 90, fine: 9 });
  });

  it('OS: amount 7,200 on net 100.000 at 80.00 -> rate 72.00, touch 90.00, fine 90.000', () => {
    const valued = valueOldGoldLine({ netWt: 100, amount: 7200, rateType: 'N' });
    expect(valued.rate).toBe(72);
    expect(
      oldMetalTouchFromAmount({
        itCode: 'OS',
        rateType: 'N',
        netWt: 100,
        amount: 7200,
        todaySilverRate: 80,
      }),
    ).toEqual({ touch: 90, fine: 90 });
  });

  it("needs today's rate: ToDayGlRate = 0 leaves the touch as typed (null)", () => {
    expect(
      oldMetalTouchFromAmount({
        itCode: 'OG',
        rateType: 'N',
        netWt: 10,
        amount: 54000,
        todayGoldRate: 0,
      }),
    ).toBeNull();
  });

  it('applies only to codes OG/OS on a net-wise row', () => {
    expect(
      oldMetalTouchFromAmount({
        itCode: 'OLDG',
        rateType: 'N',
        netWt: 10,
        amount: 54000,
        todayGoldRate: 6000,
      }),
    ).toBeNull();
    expect(
      oldMetalTouchFromAmount({
        itCode: 'OG',
        rateType: 'F',
        netWt: 10,
        amount: 54000,
        todayGoldRate: 6000,
      }),
    ).toBeNull();
  });
});

describe('sales-invoice.oldmetal.header-gold-silver-split (TR_SALE.cs:19343-19351)', () => {
  it('G rows are gold; every other type (S, P) is silver; weights are NET weights', () => {
    // gold: 10.000 / 54,000.00; silver: 100.000 + 5.000 = 105.000 and 7,200.00 + 1,000.00 = 8,200.00
    expect(
      oldMetalHeaderTotals([
        { itType: 'G', netWt: 10, amount: 54000 },
        { itType: 'S', netWt: 100, amount: 7200 },
        { itType: 'P', netWt: 5, amount: 1000 },
      ]),
    ).toEqual({ goldWt: 10, goldAmt: 54000, silverWt: 105, silverAmt: 8200 });
  });
});
