import { describe, expect, it } from 'vitest';
import {
  tagSplitBalance,
  tagSplitChild,
  tagSplitConserves,
  tagSplitStone,
  tagSplitStoneEffect,
  tagSplitTotals,
  type TagSplitChildCells,
  type TagSplitStoneCells,
} from '../src/index.js';

/**
 * TR_TAG_SPLIT `CommPassTotal_Pr` / `CommPassTotal_Rtn_Idtl` / `BILL_TOTAL` (TR_TAG_SPLIT.cs sha256/16
 * d43ab71230437abd). Every expected value is worked from the desktop statements quoted in src/tagSplitLine.ts.
 */
const settings = { labourIncludesGhat: true };

const child = (patch: Partial<TagSplitChildCells> = {}): TagSplitChildCells => ({
  pcs: 1,
  grossWt: 0,
  lessWt: 0,
  netWt: 0,
  ghtPct: 0,
  ghtWt: 0,
  touch: 0,
  westPct: 0,
  fine: 0,
  krOthWt: 0,
  krNetWt: 0,
  krGhtWt: 0,
  krTouch: 0,
  krWestPct: 0,
  krFine: 0,
  lbrType: 'G',
  lbrRate: 0,
  lbrAmt: 0,
  othAmt: 0,
  krLbrRate: 0,
  krLbrAmt: 0,
  krOthAmt: 0,
  rateType: '',
  rate: 0,
  amount: 0,
  krCost: 0,
  tagCost: 0,
  margin: 0,
  mrp: 0,
  ...patch,
});

describe('tagSplitChild (CommPassTotal_Pr)', () => {
  it('derives net, ghat and fine from gross, less and touch+wastage', () => {
    // net = 6 - 0 = 6; ghat = 6 * 0 = 0; fine = (6 + 0) * (91.6 + 0) / 100 = 5.496
    const c = tagSplitChild(child({ grossWt: 6, touch: 91.6 }), settings);
    expect([c.netWt, c.ghtWt, c.fine]).toEqual([6, 0, 5.496]);
    expect([c.krNetWt, c.krFine]).toEqual([6, 6]); // no karigar purity -> KrNwt, then KrFine = KrNwt + KrGht
  });

  it('takes fine = net + ghat when there is no purity', () => {
    const c = tagSplitChild(child({ grossWt: 4, ghtPct: 5 }), settings);
    // ghat = 4 * 5 / 100 = 0.2; no touch/wastage -> fine = net(4) + ghat(0.2) = 4.2
    expect([c.ghtWt, c.fine]).toEqual([0.2, 4.2]);
  });

  it('subtracts less weight and folds ghat into the purity fine', () => {
    // net = 10 - 1.5 = 8.5; ghat = 8.5 * 4% = 0.34; fine = (8.5 + 0.34) * 91.6% = 8.097 (rounded 3dp).
    const c = tagSplitChild(child({ grossWt: 10, lessWt: 1.5, ghtPct: 4, touch: 91.6 }), settings);
    expect(c.netWt).toBe(8.5); // less weight is subtracted from gross
    expect(c.ghtWt).toBe(0.34);
    // The ghat weight is part of the purity fine: (8.5 + 0.34) * 0.916 = 8.09744 -> 8.097.
    expect(c.fine).toBe(8.097);
    // Without folding ghat in, net-only fine would be 8.5 * 0.916 = 7.786 — a different number.
    expect(c.fine).not.toBe(7.786);
  });

  it('prices the item amount by RATE_TYPE with half-to-even rounding', () => {
    expect(
      tagSplitChild(child({ grossWt: 6, touch: 90, rateType: '', rate: 5000 }), settings).amount,
    ).toBe(27000); // fine 5.4 x 5000
    expect(
      tagSplitChild(child({ grossWt: 6, touch: 90, rateType: '1', rate: 5000 }), settings).amount,
    ).toBe(2700); // fine 5.4 x 500
    expect(
      tagSplitChild(child({ pcs: 3, grossWt: 6, touch: 90, rateType: 'P', rate: 100 }), settings)
        .amount,
    ).toBe(300);
  });

  it('computes labour by LBR_TYPE and LBR_WITH_GHT', () => {
    // N with ghat: (net 6 + ghat 0.3) x 150 = 945
    const withGht = tagSplitChild(
      child({ grossWt: 6, ghtPct: 5, touch: 90, lbrType: 'N', lbrRate: 150 }),
      settings,
    );
    expect(withGht.lbrAmt).toBe(945);
    // N without ghat: net 6 x 150 = 900
    const noGht = tagSplitChild(
      child({ grossWt: 6, ghtPct: 5, touch: 90, lbrType: 'N', lbrRate: 150 }),
      { labourIncludesGhat: false },
    );
    expect(noGht.lbrAmt).toBe(900);
    // default (gross): gross 6 x 150 = 900
    expect(
      tagSplitChild(child({ grossWt: 6, touch: 90, lbrType: 'G', lbrRate: 150 }), settings).lbrAmt,
    ).toBe(900);
  });

  it('sets tag cost = KrLbr + KrOth + ItAmt and MRP = tagCost x (1 + margin/100)', () => {
    const c = tagSplitChild(
      child({ grossWt: 6, touch: 90, rateType: '', rate: 5000, margin: 10 }),
      settings,
    );
    // ItAmt = 5.4 x 5000 = 27000; tagCost = 0 + 0 + 27000; MRP = round(27000 x 1.1) = 29700
    expect([c.tagCost, c.mrp]).toEqual([27000, 29700]);
  });
});

describe('tagSplitStone (CommPassTotal_Rtn_Idtl) and its effect', () => {
  const stone = (patch: Partial<TagSplitStoneCells> = {}): TagSplitStoneCells => ({
    pcs: 0,
    pcsWt: 0,
    karigarWt: 0,
    karigarActPct: 0,
    weight: 0,
    karigarLessPct: 0,
    conPct: 0,
    rateType: '',
    rate: 0,
    amount: 0,
    karigarRate: 0,
    karigarAmount: 0,
    lbrRate: 0,
    lbrAmount: 0,
    netAmount: 0,
    conWt: 0,
    karigarConWt: 0,
    ...patch,
  });

  it('computes weight, conversion, amount and net for a stone', () => {
    const s = tagSplitStone(
      stone({ pcs: 10, pcsWt: 0.05, conPct: 1, rateType: 'W', rate: 2000, lbrRate: 20 }),
    );
    // weight = 10 x 0.05 = 0.5; conWt = 0.5 x 1 = 0.5; amount = 2000 x 0.5 = 1000; lbr = 20 x 10 = 200; net = 1200
    expect([s.weight, s.conWt, s.amount, s.lbrAmount, s.netAmount]).toEqual([
      0.5, 0.5, 1000, 200, 1200,
    ]);
  });

  it('moves stone conversion into the child less/net weight and net amount into OthAmt', () => {
    const effect = tagSplitStoneEffect(
      { grossWt: 6, lessWt: 0, netWt: 6, krOthWt: 0, krNetWt: 6, othAmt: 0, krOthAmt: 0 },
      [{ conWt: 0.5, karigarConWt: 0.5, netAmount: 1200, karigarAmount: 0 }],
    );
    expect([effect.lessWt, effect.netWt, effect.krOthWt, effect.krNetWt, effect.othAmt]).toEqual([
      0.5, 5.5, 0.5, 5.5, 1200,
    ]);
  });

  it('leaves the row alone when the stone sums are zero', () => {
    const effect = tagSplitStoneEffect(
      { grossWt: 6, lessWt: 0.1, netWt: 5.9, krOthWt: 0, krNetWt: 6, othAmt: 7, krOthAmt: 0 },
      [{ conWt: 0, karigarConWt: 0, netAmount: 0, karigarAmount: 0 }],
    );
    expect([effect.lessWt, effect.netWt, effect.othAmt]).toEqual([0.1, 5.9, 7]);
  });
});

describe('tagSplitTotals (MSG_PR_TOT_FILL)', () => {
  it('sums the child rows signed by ITM_SIGN', () => {
    const t = tagSplitTotals([
      { sign: '+', grossWt: 6, netWt: 6, fine: 5.496, pcs: 1 },
      { sign: '+', grossWt: 4, netWt: 4, fine: 3.664, pcs: 1 },
    ]);
    expect([t.grossWt, t.netWt, t.fine, t.pcs]).toEqual([10, 10, 9.16, 2]);
  });
});

describe('tagSplitBalance (BILL_TOTAL) and conservation', () => {
  it('shows a debit when the parent net exceeds the child net, with its fine at the touch', () => {
    const b = tagSplitBalance({ parentNet: 10, childNet: 9, drTouch: 91.6, crTouch: 0 });
    expect(b).toEqual({ drWt: 1, crWt: 0, drFine: 0.916, crFine: 0 });
  });

  it('shows a credit when the child net exceeds the parent net', () => {
    const b = tagSplitBalance({ parentNet: 9, childNet: 10, drTouch: 0, crTouch: 90 });
    expect(b).toEqual({ drWt: 0, crWt: 1, drFine: 0, crFine: 0.9 });
  });

  it('conserves within tolerance', () => {
    expect(tagSplitConserves(10, 10)).toBe(true);
    expect(tagSplitConserves(10, 9.9995)).toBe(true);
    expect(tagSplitConserves(10, 9.99)).toBe(false);
  });
});
