import { describe, it, expect } from 'vitest';
import {
  labourCharge,
  metalAmount,
  lineNet,
  gstSplit,
  billTotals,
  percentageLabourRate,
  saleLineLabourAmount,
} from '../src/calc.js';
import { resolveRoundingPolicy } from '../src/roundingPolicy.js';

describe('labourCharge', () => {
  it('per_gram = netWt × rate', () => {
    expect(labourCharge('per_gram', { netWt: 10, rate: 100 })).toBe(1000);
  });
  it('per_piece = pcs × rate', () => {
    expect(labourCharge('per_piece', { pcs: 5, rate: 50 })).toBe(250);
  });
  // TR_SALE.cs:11021 derives LBR_RATE = Math.Round(ITM_RATE x LBR_PRC / 100, LBR_ROF), then the LBR_TYPE basis
  // multiplies it (:11084-11127). Expected values are the desktop oracle's (run 42580947381): item rate 6200,
  // LBR_PRC 12, gross 10.555, net 10.055, ghat 0.120, 3 pcs.
  const pctLine = {
    grossWt: 10.555,
    netWt: 10.055,
    ghatWt: 0.12,
    pcs: 3,
    itemRate: 6200,
    pct: 12,
  };
  it('percentage derives the rate from the item rate, never from the item amount', () => {
    expect(percentageLabourRate(6200, 12)).toBe(744);
    // 10.555 g gross x 744 = 7852.92 (the old rule, 12 % of the item amount, gave 7570 at whole rupees).
    expect(labourCharge('percentage', { ...pctLine, basis: 'G' })).toBe(7852.92);
  });
  it('percentage multiplies the LBR_TYPE basis at the Sale line precision (oracle labour.pct.*)', () => {
    const policy = resolveRoundingPolicy({ LBR_ROF: '2', TOT_AMT_ROF: '2' });
    const amount = (basis: string): number =>
      saleLineLabourAmount('percentage', { ...pctLine, basis }, policy);
    expect(amount('G')).toBe(7853); // 10.555 x 744
    expect(amount('N')).toBe(7570); // (10.055 + 0.120) x 744
    expect(amount('K')).toBe(8); // 10.175 x 744 / 1000 = 7.57
    expect(amount('P')).toBe(2232); // 3 x 744
    expect(amount('')).toBe(7570); // the default branch adds ghat (TR_SALE.cs:11100)
  });
  it('the derived rate is rounded by LBR_ROF (oracle labour.pct.rof0 / rof2)', () => {
    // 5432.10 x 2.5 % = 135.8025
    expect(percentageLabourRate(5432.1, 2.5, resolveRoundingPolicy({ LBR_ROF: '0' }))).toBe(136);
    expect(percentageLabourRate(5432.1, 2.5, resolveRoundingPolicy({ LBR_ROF: '2' }))).toBe(135.8);
    expect(percentageLabourRate(5432.1, 0)).toBe(0);
  });
  it('the Sales Return basis falls back to gross weight (TR_SALE_RTN.cs:4991)', () => {
    expect(labourCharge('percentage', { ...pctLine, basis: '', basisRule: 'saleReturn' })).toBe(
      7852.92,
    );
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

describe('percentage labour rate in .NET double arithmetic (TR_SALE.cs:11021, review of PR #241)', () => {
  // Math.Round(Val(ITM_RATE) * Val(LBR_PRC) / 100.0, MsLbrRof) runs on IEEE doubles; .NET Framework's
  // Math.Round(double, 2) scales by 100 and rounds that double half to even, with no tolerance. Each raw value
  // below is the double the desktop computes, written out.
  const rof2 = resolveRoundingPolicy({ LBR_ROF: '2' });
  it.each([
    [11.25, 2.8, 0.31499999999999995, 0.31],
    [17.4, 22.5, 3.9149999999999996, 3.91],
    [32.2, 22.5, 7.245000000000001, 7.25],
    [17.4, 12.5, 2.175, 2.17],
    [32.2, 12.5, 4.025, 4.03],
    [35.16, 12.5, 4.395, 4.39],
    [76.6, 12.5, 9.575, 9.57],
    [121, 7.5, 9.075, 9.07],
    [147.64, 12.5, 18.455, 18.45],
    [6200, 12, 744, 744],
  ])('%s x %s %% = %s -> %s', (itemRate, pct, raw, rate) => {
    expect((itemRate * pct) / 100).toBe(raw);
    expect(percentageLabourRate(itemRate, pct, rof2)).toBe(rate);
  });
  it('the review vector: 1000 g net at the derived 0.31 is 310, not 320', () => {
    const line = { netWt: 1000, ghatWt: 0, itemRate: 11.25, pct: 2.8, basis: 'N' };
    expect(saleLineLabourAmount('percentage', line, rof2)).toBe(310);
  });
  it('a stored LBR_RATE wins over the percentage (TR_SALE.cs:10999 derives only when LBR_PRC changed)', () => {
    const line = { netWt: 10, ghatWt: 0, itemRate: 100, pct: 10, rate: 50, basis: 'N' };
    expect(saleLineLabourAmount('percentage', line, rof2)).toBe(500);
  });
});
