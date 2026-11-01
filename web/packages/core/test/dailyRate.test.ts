import { describe, expect, it } from 'vitest';
import { recalcDailyRateGrid, type DailyRateGridRow } from '../src/dailyRate.js';

/**
 * MS_RATE's grid recalculation, from the desktop source (MS_RATE.cs:2314-2368, nSilverRate_KeyDown; the UAE
 * variant nSilverOzRate_KeyDown :2397-2458). Every expected value below is worked by hand from those lines:
 *
 *   gold row (GR_TYPE 'G'), when the gold rate is non-zero and differs from the loaded one:
 *     Rate10gm = TaxRate = Round(Touch × Gold / 100)
 *     if Tax% <> 0: Rate10gm = Round(TaxRate / (Tax% + 100) × 100, 0)
 *     PrRate = Round(PrTouch × Gold / 100)
 *   silver row (GR_TYPE 'S'): the same with the silver 1 kg rate and / 10000 (per 10 g).
 *
 * VB `Math.Round(x)` is .NET's banker's rounding (MidpointRounding.ToEven) to a whole number.
 */
const row = (over: Partial<DailyRateGridRow> = {}): DailyRateGridRow => ({
  grType: 'G',
  touch: 0,
  taxPct: 0,
  prTouch: 0,
  rate: 0,
  taxRate: 0,
  prRate: 0,
  ...over,
});
const first = { goldRate: 0, silverRate: 0 };

describe('recalcDailyRateGrid (MS_RATE nSilverRate_KeyDown)', () => {
  it('derives a 22K gold row with tax: TaxRate from touch, Rate10gm net of tax, PrRate from the purchase touch', () => {
    const [g] = recalcDailyRateGrid(
      [row({ touch: 91.6, taxPct: 3, prTouch: 92 })],
      { goldRate: 72000, silverRate: 0 },
      first,
    );
    // Round(91.6 × 72000 / 100) = 65952; Round(65952 / 103 × 100) = Round(64031.07) = 64031; Round(92 × 720) = 66240
    expect(g).toMatchObject({ taxRate: 65952, rate: 64031, prRate: 66240 });
  });

  it('keeps Rate10gm equal to TaxRate for a group without tax', () => {
    const [g] = recalcDailyRateGrid(
      [row({ touch: 75, prTouch: 76 })],
      { goldRate: 72000, silverRate: 0 },
      first,
    );
    expect(g).toMatchObject({ taxRate: 54000, rate: 54000, prRate: 54720 });
  });

  it('prices a silver row per 10 g from the 1 kg rate (/ 10000)', () => {
    const [s] = recalcDailyRateGrid(
      [row({ grType: 'S', touch: 92.5, taxPct: 3, prTouch: 90 })],
      { goldRate: 0, silverRate: 85000 },
      first,
    );
    // Round(92.5 × 85000 / 10000) = Round(786.25) = 786; Round(786 / 103 × 100) = Round(763.11) = 763;
    // Round(90 × 85000 / 10000) = Round(765) = 765
    expect(s).toMatchObject({ taxRate: 786, rate: 763, prRate: 765 });
  });

  it('rounds a midpoint to the even whole number, as .NET Math.Round does', () => {
    const rows = recalcDailyRateGrid(
      [row({ touch: 50 }), row({ touch: 50, prTouch: 50 })],
      { goldRate: 1001, silverRate: 0 },
      first,
    );
    // 50 × 1001 / 100 = 500.5 -> 500 (not 501)
    expect(rows[0]).toMatchObject({ taxRate: 500, rate: 500 });
    const odd = recalcDailyRateGrid([row({ touch: 50 })], { goldRate: 1003, silverRate: 0 }, first);
    // 50 × 1003 / 100 = 501.5 -> 502
    expect(odd[0]).toMatchObject({ taxRate: 502, rate: 502 });
  });

  it('leaves a metal untouched when its rate is zero or unchanged from the loaded day, keeping manual overrides', () => {
    const typed = [
      row({ touch: 91.6, rate: 61000, taxRate: 62830, prRate: 60000 }),
      row({ grType: 'S', touch: 92.5, rate: 700, taxRate: 721, prRate: 690 }),
    ];
    const unchangedGold = recalcDailyRateGrid(
      typed,
      { goldRate: 72000, silverRate: 0 },
      { goldRate: 72000, silverRate: 0 },
    );
    expect(unchangedGold).toEqual(typed);
    const silverOnly = recalcDailyRateGrid(
      typed,
      { goldRate: 72000, silverRate: 90000 },
      { goldRate: 72000, silverRate: 85000 },
    );
    expect(silverOnly[0]).toEqual(typed[0]);
    // Round(92.5 × 90000 / 10000) = Round(832.5) = 832 (even)
    expect(silverOnly[1]).toMatchObject({ taxRate: 832, rate: 832, prRate: 0 });
  });

  it('does not touch a group that is neither gold nor silver', () => {
    const diamond = row({ grType: 'D', touch: 100, rate: 5000, taxRate: 5150 });
    expect(recalcDailyRateGrid([diamond], { goldRate: 72000, silverRate: 85000 }, first)).toEqual([
      diamond,
    ]);
  });

  it('uses the purchase rates for PrRate when the foreign (UAE) purchase fields change (nSilverOzRate_KeyDown)', () => {
    const [g, s] = recalcDailyRateGrid(
      [row({ touch: 91.6, prTouch: 92 }), row({ grType: 'S', touch: 92.5, prTouch: 90 })],
      { goldRate: 72000, silverRate: 85000, prGoldRate: 70000, prSilverRate: 80000 },
      first,
      { foreignRates: true },
    );
    // PrRate = Round(92 × 70000 / 100) = 64400 and Round(90 × 80000 / 10000) = 720
    expect(g).toMatchObject({ taxRate: 65952, rate: 65952, prRate: 64400 });
    expect(s).toMatchObject({ taxRate: 786, rate: 786, prRate: 720 });
  });
});
