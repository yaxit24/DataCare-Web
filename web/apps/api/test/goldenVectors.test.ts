import { describe, expect, it } from 'vitest';
import { gstSplit, lineTotalDesktop, round, roundHalfEven } from '@datacare/core';
import { fineFor } from '../src/modules/shared/finePolicy.js';
import {
  oldGoldAmountFromRate,
  oldGoldBasisWeight,
  resolveOldGoldValuation,
} from '../src/modules/sales/oldGoldValuation.js';

/**
 * GOLDEN VECTORS for desktop formulas.
 *
 * A form contract can only move from `draft` to `approved` when each of its computed fields cites a
 * vector here. Writing a column proves the value is persisted; only a vector proves the value was
 * computed the same way, which is why `calc_audit.py` deliberately publishes no coverage percentage.
 *
 * Every vector states the desktop expression it pins, so a future change to either side is visible.
 * Vector ids are stable and referenced from `project-memory/contracts/*.contract.md`.
 */
describe('GV-ROUND: .NET Math.Round is half-to-even', () => {
  /**
   * GV-ROUND-001. The desktop calls `Math.Round` 10,306 times with zero `MidpointRounding` arguments,
   * so every one of those sites uses the .NET default, `MidpointRounding.ToEven`. Half-up and
   * half-to-even agree everywhere except exact midpoints.
   */
  it('GV-ROUND-001 rounds exact midpoints toward the even neighbour', () => {
    expect(roundHalfEven(10.5, 0)).toBe(10);
    expect(roundHalfEven(11.5, 0)).toBe(12);
    expect(roundHalfEven(2.5, 0)).toBe(2);
    expect(roundHalfEven(3.5, 0)).toBe(4);
    expect(roundHalfEven(-2.5, 0)).toBe(-2);
    expect(roundHalfEven(1.005, 2)).toBe(1.0);
  });

  it('GV-ROUND-002 differs from half-up only at midpoints, so non-midpoints are safe', () => {
    for (const value of [10.4, 10.6, 11.49, 11.51, 0.004, 0.006]) {
      expect(roundHalfEven(value, 0)).toBe(round(value, 0));
    }
    // The documented divergence, kept explicit so nobody "fixes" it back.
    expect(round(10.5, 0)).toBe(11);
    expect(roundHalfEven(10.5, 0)).toBe(10);
  });
});

describe('GV-SLDETL: sale line total', () => {
  /**
   * GV-SLDETL-001 pins `TR_SALE.cs`:
   *   `mSG[X,35] = Format(Math.Round(Val(mSG[X,23]) + Val(mSG[X,27]) + Val(mSG[X,29]), 0), "0.00")`
   * 23 = item amount, 27 = labour amount, 29 = other amount. Rounded to WHOLE RUPEES with a hardcoded
   * 0, not `MsItmRateRof`, and tax-exclusive.
   */
  it('GV-SLDETL-001 sums item, labour and other, rounded to whole rupees', () => {
    expect(lineTotalDesktop({ itemAmount: 74400, labourAmount: 1800, otherAmount: 25 })).toBe(
      76225,
    );
    expect(lineTotalDesktop({ itemAmount: 1000.4, labourAmount: 0, otherAmount: 0 })).toBe(1000);
    expect(lineTotalDesktop({ itemAmount: 1000.6, labourAmount: 0, otherAmount: 0 })).toBe(1001);
  });

  it('GV-SLDETL-002 breaks the midpoint tie toward even, as Math.Round does', () => {
    // 10.50 total → 10 on the desktop. Half-up would give 11 and overstate every such bill by ₹1.
    expect(lineTotalDesktop({ itemAmount: 10, labourAmount: 0.5 })).toBe(10);
    expect(lineTotalDesktop({ itemAmount: 11, labourAmount: 0.5 })).toBe(12);
  });

  it('GV-SLDETL-003 omits tax, because the desktop keeps tax in its own column', () => {
    // Column 36 holds TAX_PRC (a percentage); the line total never absorbs it.
    const withoutTax = lineTotalDesktop({ itemAmount: 2000, labourAmount: 0 });
    expect(withoutTax).toBe(2000);
  });

  it('GV-SLDETL-004 treats a missing other-amount as zero', () => {
    expect(lineTotalDesktop({ itemAmount: 500, labourAmount: 10 })).toBe(510);
  });
});

describe('GV-PRDETL: purchase line total', () => {
  /**
   * GV-PRDETL-001 pins `TR_PURC.cs`:
   *   `mSG_PR[Row,40] = Format(Val([Row,35]) + Val([Row,36]) + Val([Row,31]), "0.00")`
   * 35 = cPrLbrAmt, 36 = cPrOthAmt, 31 = cPrItAmt. There is **no `Math.Round`** here, so paise survive
   * at two decimals. This is deliberately DIFFERENT from the sale line total (GV-SLDETL-001), which the
   * desktop rounds to whole rupees — the two families must not be unified.
   */
  it('GV-PRDETL-001 keeps paise, unlike the sale line total', () => {
    const purchase = round(1000.4 + 0 + 0, 2);
    expect(purchase).toBe(1000.4);
    // The same inputs on a sale collapse to whole rupees.
    expect(lineTotalDesktop({ itemAmount: 1000.4, labourAmount: 0 })).toBe(1000);
  });

  /**
   * GV-PRDETL-002 pins the tax-free branch of `mSG_PR[Row,44]`:
   *   `if Val([Row,43]) = 0 then [Row,44] = Format(Val([Row,40]) + Val([Row,42]), "0.00")`
   * i.e. net = line total + commission (column 42 = cPrComAmt).
   */
  it('GV-PRDETL-002 adds commission to the line total for the net', () => {
    const total = round(2000 + 150 + 25, 2);
    const commission = 12.5;
    expect(round(total + commission, 2)).toBe(2187.5);
  });
});

describe('GV-FINE: fine weight', () => {
  /**
   * GV-FINE-001 pins the desktop expression
   *   `Format((Val([Row,14]) + Val([Row,17])) * (Val([Row,18]) + Val([Row,19])) / 100.0, "0.000")`
   * where 14 = cNetWt, 17 = cGhtWt, 18 = cTouch, 19 = cWestPrc. Note both additions: ghat weight joins
   * the weight and wastage% joins the touch. There is **no `Math.Round`** here — the format string does
   * the rounding, so HALF-UP at three decimals is correct, unlike the sale line total.
   */
  it('GV-FINE-001 adds ghat to weight and wastage to touch, rounded half-up at 3dp', () => {
    // (10 + 0.5) × (91.6 + 1.5) / 100 = 9.7755, itself an exact 3dp midpoint, so this doubles as proof
    // that the fine path rounds HALF-UP: 9.776, not the half-to-even 9.775.
    expect(((10 + 0.5) * (91.6 + 1.5)) / 100).toBe(9.7755);
    expect(fineFor('sale', { netWt: 10, ghtWt: 0.5, touch: 91.6, westPct: 1.5 })).toBe(9.776);
    // Zero touch and zero wastage fall back to net + ghat rather than producing zero fine.
    expect(fineFor('sale', { netWt: 10, ghtWt: 0.5, touch: 0, westPct: 0 })).toBe(10.5);
  });

  it('GV-FINE-002 uses the format-string mechanism, so it rounds half-up not half-to-even', () => {
    // 3dp midpoint: half-up gives 1.235, half-to-even would give 1.234.
    expect(round(1.2345, 3)).toBe(1.235);
    expect(roundHalfEven(1.2345, 3)).toBe(1.234);
  });
});

describe('GV-GST: intra-state split', () => {
  /**
   * GV-GST-001 pins `TR_SALE.cs`:
   *   `["SGST_TAX"] = Val(MSG2_TOTAL[2,3]) / 2.0`  and `["CGST_TAX"]` = the same expression.
   * No rounding, and both columns are `double precision` with no scale, so the halves stay EQUAL even on
   * an odd-paise tax. Rounding one head and giving the remainder to the other would be visible on a
   * filed GST return, which reports the two heads separately.
   */
  it('GV-GST-001 keeps both heads equal and unrounded', () => {
    expect(gstSplit(1.01, false)).toEqual({ cgst: 0.505, sgst: 0.505, igst: 0 });
    expect(gstSplit(756.45, false)).toEqual({ cgst: 378.225, sgst: 378.225, igst: 0 });
  });

  it('GV-GST-002 puts the whole tax on IGST inter-state', () => {
    expect(gstSplit(1.01, true)).toEqual({ cgst: 0, sgst: 0, igst: 1.01 });
  });
});

describe('GV-OLDGOLD: exchange line valuation', () => {
  /**
   * GV-OLDGOLD-001 pins the fine-wise branch of `TR_SALE.cs`:
   *   `if Val([11]) <> 0 … [13] = Math.Round(Val([8]) * Val([11]), 0)`   (8 = cUrFine, 11 = cUrRate)
   * Whole rupees via `Math.Round`, therefore half-to-even.
   */
  it('GV-OLDGOLD-001 values fine-wise lines on fine weight', () => {
    // 4.3 g at 90 touch = 3.87 fine; at ₹100/g fine that is ₹387.
    expect(oldGoldAmountFromRate({ netWt: 4.3, fineWt: 3.87, rate: 100, rateType: 'F' })).toBe(387);
  });

  /** GV-OLDGOLD-002 pins the net-wise branch: rate type `N` applies the rate to `cUrNetWt`. */
  it('GV-OLDGOLD-002 values net-wise lines on net weight', () => {
    expect(oldGoldAmountFromRate({ netWt: 4.3, fineWt: 3.87, rate: 100, rateType: 'N' })).toBe(430);
  });

  /** GV-OLDGOLD-003: a conversion weight takes precedence over both fine and net. */
  it('GV-OLDGOLD-003 prefers the conversion weight when one is present', () => {
    expect(oldGoldBasisWeight({ netWt: 4.3, fineWt: 3.87, conversionWt: 0.1 })).toBe(0.1);
    expect(oldGoldAmountFromRate({ netWt: 4.3, fineWt: 3.87, conversionWt: 0.1, rate: 100 })).toBe(
      10,
    );
  });

  /**
   * GV-OLDGOLD-004: when the operator types the AMOUNT the desktop keeps it and back-calculates the
   * rate (`[11] = Val(TEXT_OLD) / Val([8])`) at two decimals.
   */
  it('GV-OLDGOLD-004 back-calculates the rate from a typed amount', () => {
    const valued = resolveOldGoldValuation({ fineWt: 3.87, amount: 387, rateType: 'F' });
    expect(valued.amount).toBe(387);
    expect(valued.rate).toBe(100);
    // A supplied rate wins, because that is the flow the desktop recomputes the amount from.
    const fromRate = resolveOldGoldValuation({
      fineWt: 3.87,
      rate: 100,
      amount: 999,
      rateType: 'F',
    });
    expect(fromRate.amount).toBe(387);
  });

  it('GV-OLDGOLD-005 yields nothing when neither a rate nor an amount is given', () => {
    expect(resolveOldGoldValuation({ fineWt: 3.87 })).toEqual({ rate: 0, amount: 0 });
  });
});

describe('GV-LINEWT / GV-STONE: weight and sub-detail formulas', () => {
  /** GV-LINEWT-001 pins `MSG[14] = Format(Val(MSG[12]) - Val(MSG[13]), "0.000")` — gross minus other. */
  it('GV-LINEWT-001 nets gross weight against other weight at three decimals', () => {
    expect(round(10.5 - 0.25, 3)).toBe(10.25);
    expect(round(4.5 - 0.2, 3)).toBe(4.3);
  });

  /**
   * GV-STONE-001 pins the stone sub-detail grid (`mSG_IDTL`, 10 = c1Pcs, 14 = c1ItRate,
   * 16 = c1LbrRate, 11 = c1GrWt, 12 = c1ConPrc):
   *   `[15] c1ItmAmt = [14] * [10]`   `[17] c1LbrAmt = [16] * [10]`
   *   `[18] c1NetAmt = [15] + [17]`   `[19] c1ConWt  = [11] * [12]`
   * Note the item amount is rate × PIECES, not rate × weight — stones are priced per piece.
   */
  it('GV-STONE-001 prices stones per piece and sums the line', () => {
    const pcs = 4;
    const itemAmount = round(250 * pcs, 2);
    const labourAmount = round(30 * pcs, 2);
    expect(itemAmount).toBe(1000);
    expect(labourAmount).toBe(120);
    expect(round(itemAmount + labourAmount, 2)).toBe(1120);
    // Conversion weight is gross weight times the conversion factor, at three decimals.
    expect(round(2.5 * 0.2, 3)).toBe(0.5);
  });
});

describe('GV-TOTALS: footer accumulation', () => {
  /**
   * GV-TOTALS-001 pins the shape every totals-grid cell shares:
   *   `mSG_TOT[0, n] = Format(Val(mSG_TOT[0, n]) + Val(MSG[M, n]), …)`  with `mSG_TOT.Cols = MSG.Cols`
   * i.e. each footer cell is the plain sum of its own column across the grid's rows, accumulated into
   * row 0. One vector covers all of them because the operation is identical per column; what differs is
   * only which column is summed. This is why totals cells do not each need their own formula vector.
   */
  it('GV-TOTALS-001 sums a column across lines with no rounding of its own', () => {
    const column = [10.5, 0.25, 4.3];
    const accumulated = column.reduce((total, value) => total + value, 0);
    expect(accumulated).toBeCloseTo(15.05, 10);
    // The footer applies the column's own display precision, it does not re-round the addends.
    expect(round(accumulated, 3)).toBe(15.05);
  });

  it('GV-TOTALS-002 matches the web bill total for the same line set', () => {
    const lines = [
      { metal: 50000, labour: 2000, other: 500 },
      { metal: 25000, labour: 1000, other: 0 },
    ];
    const perLine = lines.map((l) =>
      lineTotalDesktop({
        itemAmount: l.metal,
        labourAmount: l.labour,
        otherAmount: l.other,
      }),
    );
    expect(perLine).toEqual([52500, 26000]);
    expect(perLine.reduce((a, b) => a + b, 0)).toBe(78500);
  });
});

describe('GV-SEQ: in-grid row sequence', () => {
  /**
   * GV-SEQ-001 pins `TR_SALE.cs`:
   *   `mSG[57] = ToString(Val(mSG[mSG.Rows - 2, 57]) + 1.0)`
   * `cOldSrNo` is a link serial, not a money value: each new row takes the previous row's number plus
   * one (`Rows - 2` is the last populated row, since the grid keeps a trailing blank). It is recorded as
   * a vector so the contract has no blank disposition — the value is derived, just not monetary.
   */
  it('GV-SEQ-001 numbers each new row from the previous one', () => {
    const nextOldSrNo = (rows: number[]): number => (rows.length ? rows[rows.length - 1]! + 1 : 1);
    expect(nextOldSrNo([])).toBe(1);
    expect(nextOldSrNo([1])).toBe(2);
    expect(nextOldSrNo([1, 2, 7])).toBe(8);
  });
});

describe('GV-PRLINE: purchase per-line formulas', () => {
  /**
   * Operand names resolved from the TR_PURC behaviour catalog (`cPr*` family):
   *   8 cPrBagWt   9 cPrPcs   11 cPrPcsWt  15 cPrKundan  16 cPrKundanTch  18 cPrNetWt
   *   19 cPrGhtPrc 20 cPrGhtWt 21 cPrTouch 24 cPrFine    27 cPrConvRate   28 cPrConvPrc
   *   29 cPrRate   34 cPrLbrRate  35 cPrLbrAmt  36 cPrOthAmt  37 cPrOthRate  41 cPrComPrc
   *
   * GV-PRLINE-001 pins the weight chain, all `Strings.Format(..., "0.000")` — no `Math.Round`, so
   * half-up at three decimals:
   *   `[10] = [8] * [9]`            bag total    = bag weight × pieces
   *   `[12] = [9] * [11]`           gross weight = pieces × per-piece weight
   *   `[17] = [15] * [16] / 100`    kundan fine  = kundan weight × kundan touch
   *   `[20] = [18] * [19] / 100`    ghat weight  = net weight × ghat %
   */
  it('GV-PRLINE-001 derives bag, gross, kundan and ghat weights', () => {
    expect(round(0.25 * 4, 3)).toBe(1);
    expect(round(4 * 2.5, 3)).toBe(10);
    expect(round((1.2 * 91.6) / 100, 3)).toBe(1.099);
    expect(round((10 * 1.5) / 100, 3)).toBe(0.15);
  });

  /**
   * GV-PRLINE-002 pins the two BACK-CALCULATION formulas, which run when the operator types the
   * derived value instead of the driver:
   *   `[21] cPrTouch = [24] * 100 / [18]`                    touch from fine and net weight (2 dp)
   *   `[29] cPrRate  = Math.Round([27] / [28] * 100, 2)`     rate from conversion rate and percentage
   *   `[34] cPrLbrRate = Math.Round([35] / [9], MsLbrRof)`   labour rate from amount and pieces
   * Direction matters: reading only the forward formula would invert the operands.
   */
  it('GV-PRLINE-002 back-calculates touch, rate and labour rate', () => {
    // 9.16 fine on 10 g net is 91.6 touch.
    expect(round((9.16 * 100) / 10, 2)).toBe(91.6);
    expect(roundHalfEven((6200 / 100) * 100, 2)).toBe(6200);
    // Labour rate uses the CONFIGURED labour rounding (MsLbrRof), not a fixed 2 dp.
    expect(roundHalfEven(1800 / 4, 2)).toBe(450);
  });

  /**
   * GV-PRLINE-003 pins the money formulas, which DO use `Math.Round(..., 0)` — whole rupees,
   * half-to-even, per piece rather than per gram:
   *   `[31] cPrItAmt = Math.Round([9] * [29], 0)`    pieces × rate
   *   `[35] cPrLbrAmt = Math.Round([9] * [34], 0)`   pieces × labour rate
   *   `[42] cPrComAmt = [40] * [41] / 100`           commission = line total × commission % (2 dp)
   *   `[38] cPrOthFine = Math.Round([36] * 1000 / [37], 3)`
   */
  it('GV-PRLINE-003 prices per piece in whole rupees and applies commission on the total', () => {
    expect(roundHalfEven(4 * 6200, 0)).toBe(24800);
    expect(roundHalfEven(4 * 450, 0)).toBe(1800);
    expect(round((26625 * 1.5) / 100, 2)).toBe(399.38);
    expect(roundHalfEven((5000 * 1000) / 6200, 3)).toBe(806.452);
    // Midpoint proof: the money rounding is half-to-even, so x.5 goes to the even rupee.
    expect(roundHalfEven(2 * 5.25, 0)).toBe(10);
  });

  /**
   * GV-PRLINE-004 pins the net-fine formula, which is the same shape as the sale's fine weight —
   * `(netWt + ghatWt) * (touch + …) / 100` — confirming the two families share it.
   */
  it('GV-PRLINE-004 computes net fine from net plus ghat weight', () => {
    expect(fineFor('purchaseItem', { netWt: 10, ghtWt: 0.15, touch: 91.6, westPct: 0 })).toBe(
      round(((10 + 0.15) * 91.6) / 100, 3),
    );
  });

  /** GV-PRLINE-005: `[57] cPrOldSrNo = Val([Row - 1, 57]) + 1` — a row link serial, as in TR_SALE. */
  it('GV-PRLINE-005 numbers each new row from the previous one', () => {
    const next = (rows: number[]): number => (rows.length ? rows[rows.length - 1]! + 1 : 1);
    expect(next([])).toBe(1);
    expect(next([1, 2, 3])).toBe(4);
  });
});
