import { describe, expect, it } from 'vitest';
import { billProfit, lineProfit } from '../src/modules/sales/billProfit.js';

/**
 * Bill-profit golden vectors.
 *
 * Every expected figure is derived by hand from `TR_SALE.cs:17009-17045` (per-line cost) and
 * `:19396-19399` (voucher total), and the grid columns were resolved from the load/write path:
 * 30 = ITM_MRP, 38 = TAG_COST, 48 = KR_FINE, 14 = ITM_NWT, 35 = TOT_AMT, 37 = NET_AMT, 1 = TAG_NO.
 *
 * The BRANCH ORDER is the substance of this feature: an MRP line must not be costed from karigar fine, and a
 * tagged line must not fall through to average touch. Each vector therefore fixes which branch ran, not just
 * the number.
 */
describe('bill profit — per line', () => {
  it('GV-PROFIT-MRP-001: an MRP line costs from the tag, using NET_AMT', () => {
    // :17023  profit = NET_AMT − TAG_COST = 5000 − 3800 = 1200
    const r = lineProfit({ itmMrp: 4999, netAmt: 5000, totAmt: 5000, tagCost: 3800 }, 7000);
    expect(r.basis).toBe('mrp');
    expect(r.cost).toBeCloseTo(3800, 2);
    expect(r.profit).toBeCloseTo(1200, 2);
  });

  it('GV-PROFIT-MRP-002: the MRP branch wins even when karigar fine is present', () => {
    // Branch order matters: ITM_MRP is tested first, so the fine must be ignored here.
    const r = lineProfit(
      { itmMrp: 4999, netAmt: 5000, totAmt: 5000, tagCost: 3800, krFine: 9.5, tagNo: 'T1' },
      7000,
    );
    expect(r.basis).toBe('mrp');
    expect(r.profit).toBeCloseTo(1200, 2);
  });

  it('GV-PROFIT-KR-001: a tagged line costs karigar fine at the sale rate plus tag cost', () => {
    // :17028  cost = round(9.5 x 7000 + 500, 2) = 66,500 + 500 = 67,000; profit = 70,000 − 67,000 = 3,000
    const r = lineProfit({ tagNo: 'TAG1', krFine: 9.5, tagCost: 500, totAmt: 70000 }, 7000);
    expect(r.basis).toBe('karigar-fine');
    expect(r.cost).toBeCloseTo(67000, 2);
    expect(r.profit).toBeCloseTo(3000, 2);
  });

  it('GV-PROFIT-KR-002: karigar fine WITHOUT a tag number falls through', () => {
    // The desktop requires both `KR_FINE <> 0` AND a non-blank TAG_NO, so an untagged line with a fine
    // must NOT use this branch.
    const r = lineProfit({ tagNo: '  ', krFine: 9.5, tagCost: 500, totAmt: 70000 }, 7000);
    expect(r.basis).not.toBe('karigar-fine');
  });

  it('GV-PROFIT-TOUCH-001: derives fine from net weight and average touch', () => {
    // :17041  fine = round(10 x 91.6 / 100, 3) = 9.160
    //         cost = round(9.160 x 7000, 2)    = 64,120
    //         profit = 70,000 − 64,120         = 5,880
    const r = lineProfit({ netWt: 10, avgTouch: 91.6, totAmt: 70000 }, 7000);
    expect(r.basis).toBe('average-touch');
    expect(r.fine).toBeCloseTo(9.16, 3);
    expect(r.cost).toBeCloseTo(64120, 2);
    expect(r.profit).toBeCloseTo(5880, 2);
  });

  it('GV-PROFIT-TOUCH-002: fine keeps THREE decimals before costing', () => {
    // 9.163 x 88.7 / 100 = 8.1275... -> 8.128 at three decimals (half-up), then x 7000 = 56,896
    const r = lineProfit({ netWt: 9.163, avgTouch: 88.7, totAmt: 60000 }, 7000);
    expect(r.fine).toBeCloseTo(8.128, 3);
    expect(r.cost).toBeCloseTo(56896, 2);
  });

  it('GV-PROFIT-NONE-001: an unknown cost yields NO profit, not full profit', () => {
    // With no MRP, no fine and no average touch the desktop shows nothing. Reporting TOT_AMT as profit
    // would present an unknown cost as pure margin, which is the dangerous failure here.
    const r = lineProfit({ totAmt: 70000 }, 7000);
    expect(r.basis).toBe('none');
    expect(r.profit).toBe(0);
    expect(r.cost).toBe(0);
  });

  it('GV-PROFIT-NONE-002: a zero average touch disables the derived branch', () => {
    // The desktop's lookup filters `AVG_TOUCH <> 0`, so a zero touch is not a usable cost basis.
    expect(lineProfit({ netWt: 10, avgTouch: 0, totAmt: 70000 }, 7000).basis).toBe('none');
    expect(lineProfit({ netWt: 0, avgTouch: 91.6, totAmt: 70000 }, 7000).basis).toBe('none');
  });

  it('GV-PROFIT-NEG-001: a loss is reported as a negative profit', () => {
    // Selling below cost must show the loss rather than clamping at zero.
    const r = lineProfit({ tagNo: 'T1', krFine: 10, tagCost: 0, totAmt: 60000 }, 7000);
    expect(r.profit).toBeCloseTo(-10000, 2);
  });
});

describe('bill profit — voucher', () => {
  const lines = [
    { itmMrp: 4999, netAmt: 5000, totAmt: 5000, tagCost: 3800 }, // +1200
    { tagNo: 'TAG1', krFine: 9.5, tagCost: 500, totAmt: 70000 }, // +3000
    { netWt: 10, avgTouch: 91.6, totAmt: 70000 }, // +5880
  ];

  it('GV-PROFIT-BILL-001: sums the per-line profits', () => {
    const r = billProfit(lines, 7000, { billProfitEnabled: true });
    expect(r.visible).toBe(true);
    expect(r.total).toBeCloseTo(1200 + 3000 + 5880, 2);
    expect(r.lines.map((l) => l.basis)).toEqual(['mrp', 'karigar-fine', 'average-touch']);
  });

  it('GV-PROFIT-BILL-002: reports nothing when the company setting is off', () => {
    // CO_SET_NEW.BILL_PROFIT governs visibility; a caller must not be able to surface a margin at a shop
    // that has chosen not to show one.
    const r = billProfit(lines, 7000, { billProfitEnabled: false });
    expect(r.visible).toBe(false);
    expect(r.total).toBe(0);
  });

  it('GV-PROFIT-BILL-003: an empty voucher has no profit', () => {
    expect(billProfit([], 7000).total).toBe(0);
  });

  it('GV-PROFIT-BILL-004: lines with an unknown cost contribute nothing', () => {
    const r = billProfit([{ totAmt: 99999 }, lines[0]!], 7000, { billProfitEnabled: true });
    expect(r.total).toBeCloseTo(1200, 2);
  });
});
