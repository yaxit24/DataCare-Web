import { describe, expect, it } from 'vitest';
import { cashGridTotals } from '../src/cashGridTotals.js';

/**
 * TR_CASH totals row, worked by hand from the desktop lines (TR_CASH.cs):
 * - each Amount/Kasar cell is stored as Strings.Format(Val(text), "0.00") on leaving it (:1978-1982);
 * - MSG_TOT_FILL sums column 5 into "0.00" and column 7 into "0.000" (:1852-1853);
 * - NewValTot = Σ Amount + Σ Kasar (:1856);
 * - the save skips a row with no account or with Amount + Kasar = 0 (:3002).
 */
describe('cashGridTotals (TR_CASH MSG_TOT_FILL)', () => {
  it('sums Amount to two places and Kasar to three, as the desktop totals row prints them', () => {
    // 1250.50 + 749.25 = 1999.75 ; 10.50 + 0.25 = 10.75 -> "10.750" ; NewValTot 2010.50
    expect(
      cashGridTotals([
        { account: 'P1', amount: '1250.50', kasar: '10.50' },
        { account: 'P2', amount: '749.25', kasar: '0.25' },
      ]),
    ).toEqual({ amount: '1999.75', kasar: '10.750', value: 2010.5, savedRows: 2 });
  });

  it('rounds each cell half-up to two places before summing (Strings.Format "0.00" on leaving the cell)', () => {
    // 0.005 -> 0.01 twice = 0.02 (summing first would give 0.01) ; kasar 1.005 -> 1.01
    expect(
      cashGridTotals([
        { account: 'P1', amount: '0.005', kasar: '1.005' },
        { account: 'P1', amount: '0.005' },
      ]),
    ).toEqual({ amount: '0.02', kasar: '1.010', value: 1.03, savedRows: 2 });
  });

  it('reads cells with VB Val and does not count rows the save skips', () => {
    // "12 50" is Val 1250 ; "abc" is 0 ; the third row has no account ; the fourth has Amount + Kasar = 0
    expect(
      cashGridTotals([
        { account: 'P1', amount: '12 50' },
        { account: 'P2', amount: 'abc', kasar: '5' },
        { account: '', amount: '100' },
        { account: 'P3', amount: '', kasar: '' },
      ]),
    ).toEqual({ amount: '1350.00', kasar: '5.000', value: 1355, savedRows: 2 });
  });

  it('prints zero totals for an empty grid', () => {
    expect(cashGridTotals([])).toEqual({ amount: '0.00', kasar: '0.000', value: 0, savedRows: 0 });
  });
});
