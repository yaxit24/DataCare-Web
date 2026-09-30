import { describe, expect, it } from 'vitest';
import {
  baselineFromCells,
  tagCancelLineQualifies,
  tagCancelRecompute,
  tagCancelStone,
  tagCancelStoneEffect,
  tagCancelTotals,
  type TagCancelCells,
  type TagCancelStoneCells,
} from '../src/index.js';

/**
 * TR_TAG_CAN `CommPassTotal` / `CommPassTotal_Idtl` / `MSG_TOT_FILL` (TR_TAG_CAN.cs sha256/16 04e7ae5842f63116).
 * Every expected value is worked from the desktop statements quoted in `src/tagCancelLine.ts`, not from web output.
 */

const settings = { labourIncludesGhat: true };

/** RNG00001 as the tag fill loads it (contract vector V1). */
const tagRow = (): TagCancelCells => ({
  tagged: true,
  pcs: 1,
  grossWt: 10.5,
  lessWt: 0.5,
  netWt: 10,
  ghtWt: 0,
  touch: 91.6,
  westPct: 2,
  fine: 9.36,
  lbrType: 'N',
  lbrRate: 150,
  lbrAmt: 1500,
  krOthWt: 0,
  krNetWt: 10,
  krGhtWt: 0,
  krTouch: 90,
  krWestPct: 1.5,
  krFine: 9.15,
  rate: 0,
  amount: 0,
  rateType: '',
});

const looseRow = (patch: Partial<TagCancelCells> = {}): TagCancelCells => ({
  tagged: false,
  pcs: 0,
  grossWt: 0,
  lessWt: 0,
  netWt: 0,
  ghtWt: 0,
  touch: 0,
  westPct: 0,
  fine: 0,
  lbrType: 'G',
  lbrRate: 0,
  lbrAmt: 0,
  krOthWt: 0,
  krNetWt: 0,
  krGhtWt: 0,
  krTouch: 0,
  krWestPct: 0,
  krFine: 0,
  rate: 0,
  amount: 0,
  rateType: '',
  ...patch,
});

describe('baselineFromCells', () => {
  it('records the loaded gross/net/touch/wastage and leaves the karigar block at zero, as no load sets 62-64', () => {
    expect(baselineFromCells(tagRow())).toEqual({
      grossWt: 10.5,
      netWt: 10,
      touch: 91.6,
      westPct: 2,
      krNetWt: 0,
      krTouch: 0,
      krWestPct: 0,
    });
    expect(baselineFromCells(null)).toEqual({
      grossWt: 0,
      netWt: 0,
      touch: 0,
      westPct: 0,
      krNetWt: 0,
      krTouch: 0,
      krWestPct: 0,
    });
  });
});

describe('tagCancelRecompute (CommPassTotal)', () => {
  it('re-derives net, fine and labour from a changed gross and the karigar fine from its unset baseline', () => {
    const row = { ...tagRow(), grossWt: 10.7 };
    const { cells, baseline } = tagCancelRecompute(row, baselineFromCells(tagRow()), settings);
    // net = 10.700 - 0.500; fine = (10.2 + 0) * (91.6 + 2) / 100 = 9.5472 -> "0.000" 9.547
    expect(cells.netWt).toBe(10.2);
    expect(cells.fine).toBe(9.547);
    // N labour with LBR_WITH_GHT 'Y': Math.Round((10.2 + 0) * 150, 0) = 1530
    expect(cells.lbrAmt).toBe(1530);
    // Karigar: 10.00 differs from the unset baseline 0, so KrFine = (10 + 0) * (90 + 1.5) / 100
    expect(cells.krFine).toBe(9.15);
    expect(baseline).toMatchObject({ grossWt: 10.7, netWt: 10.2, krNetWt: 10, krTouch: 90 });
  });

  it('keeps a typed fine until net, touch or wastage changes again', () => {
    const first = tagCancelRecompute(
      { ...tagRow(), grossWt: 10.7 },
      baselineFromCells(tagRow()),
      settings,
    );
    const typed = { ...first.cells, fine: 9.6 };
    const second = tagCancelRecompute(typed, first.baseline, settings);
    expect(second.cells.fine).toBe(9.6);
    // …and a later touch change does replace it.
    const third = tagCancelRecompute({ ...second.cells, touch: 92 }, second.baseline, settings);
    expect(third.cells.fine).toBe(9.588); // 10.2 * 94 / 100
  });

  it('is event-ordered: touch then a typed fine keeps the fine, one pass from the load would not', () => {
    const load = baselineFromCells(tagRow());
    const touched = tagCancelRecompute({ ...tagRow(), touch: 92 }, load, settings);
    expect(touched.cells.fine).toBe(9.4); // 10 * 94 / 100
    const typed = tagCancelRecompute({ ...touched.cells, fine: 9.5 }, touched.baseline, settings);
    expect(typed.cells.fine).toBe(9.5);
    // The same final cells run once against the LOAD baseline re-derive the fine, because touch differs from it.
    const once = tagCancelRecompute({ ...tagRow(), touch: 92, fine: 9.5 }, load, settings);
    expect(once.cells.fine).toBe(9.4);
  });

  it('is idempotent once the baseline is current', () => {
    const first = tagCancelRecompute(
      { ...tagRow(), grossWt: 11, touch: 92 },
      baselineFromCells(tagRow()),
      settings,
    );
    const again = tagCancelRecompute(first.cells, first.baseline, settings);
    expect(again.cells).toEqual(first.cells);
    expect(again.baseline).toEqual(first.baseline);
  });

  it('prices the ghat weight into the fine with a purity: (net + ghat) × (touch + wastage) / 100', () => {
    // A typed GhtWt of 0.5 on the loose row, then touch 91.6: (10 + 0.5) × 91.6 / 100 = 9.618.
    const { cells } = tagCancelRecompute(
      looseRow({ grossWt: 10, ghtWt: 0.5, touch: 91.6 }),
      baselineFromCells(null),
      settings,
    );
    expect(cells.netWt).toBe(10);
    expect(cells.fine).toBe(9.618);
  });

  it('leaves a typed net alone while the gross is unchanged and there is no less weight (IL_0015 guard)', () => {
    // Loaded gross 10 / net 10; the operator types net 9.5 and leaves it. Gross equals its baseline, so step 1 does
    // not run, and without a less weight nothing forces net = gross: the typed net stands and drives the fine.
    const loaded = looseRow({ grossWt: 10, netWt: 10, touch: 75, fine: 7.5 });
    const { cells } = tagCancelRecompute(
      { ...loaded, netWt: 9.5 },
      baselineFromCells(loaded),
      settings,
    );
    expect(cells.netWt).toBe(9.5);
    expect(cells.fine).toBe(7.125); // 9.5 × 75 / 100
  });

  it('without a purity the fine is net + ghat, and a lost fine with a purity is re-derived', () => {
    const noPurity = tagCancelRecompute(
      looseRow({ grossWt: 4, ghtWt: 0.25 }),
      baselineFromCells(null),
      settings,
    );
    expect(noPurity.cells.netWt).toBe(4);
    expect(noPurity.cells.fine).toBe(4.25);

    const loaded = { ...tagRow(), fine: 0 };
    const rederived = tagCancelRecompute(loaded, baselineFromCells(loaded), settings);
    expect(rederived.cells.fine).toBe(9.36); // (10 + 0) * 93.6 / 100
  });

  it('a loose row copies net, touch, wastage and fine into the karigar block', () => {
    const { cells } = tagCancelRecompute(
      looseRow({ grossWt: 2, touch: 75 }),
      baselineFromCells(null),
      settings,
    );
    expect(cells.netWt).toBe(2);
    expect(cells.fine).toBe(1.5);
    expect([cells.krNetWt, cells.krTouch, cells.krWestPct, cells.krFine]).toEqual([2, 75, 0, 1.5]);
  });

  it('prices the item amount by RATE_TYPE with Math.Round half-to-even', () => {
    const at = (rateType: string, extra: Partial<TagCancelCells> = {}) =>
      tagCancelRecompute(
        looseRow({ grossWt: 2, touch: 75, pcs: 2, rate: 5000, rateType, ...extra }),
        baselineFromCells(null),
        settings,
      ).cells.amount;
    expect(at('')).toBe(7500); // 1.5 * 5000
    expect(at('1')).toBe(750); // 1.5 * (5000 / 10)
    expect(at('K')).toBe(8); // 1.5 * (5000 / 1000) = 7.5 -> 8 (to even)
    expect(at('K', { rate: 3000 })).toBe(4); // 1.5 * 3 = 4.5 -> 4 (to even)
    expect(at('P')).toBe(10000); // 2 pcs * 5000
    // No fine, no item amount: the typed amount stands.
    expect(
      tagCancelRecompute(looseRow({ rate: 5000, amount: 123 }), baselineFromCells(null), settings)
        .cells.amount,
    ).toBe(123);
  });

  it('computes labour by LType and LBR_WITH_GHT', () => {
    const labour = (
      lbrType: string,
      labourIncludesGhat: boolean,
      extra: Partial<TagCancelCells> = {},
    ) =>
      tagCancelRecompute(
        looseRow({ grossWt: 3, lessWt: 0.5, ghtWt: 0.25, pcs: 2, lbrType, lbrRate: 100, ...extra }),
        baselineFromCells(null),
        { labourIncludesGhat },
      ).cells.lbrAmt;
    expect(labour('P', true)).toBe(200); // 2 * 100
    expect(labour('N', true)).toBe(275); // (2.5 + 0.25) * 100
    expect(labour('N', false)).toBe(250); // 2.5 * 100
    expect(labour('K', true, { lbrRate: 1000 })).toBe(3); // (2.5 + 0.25) * (1000 / 1000) = 2.75 -> 3
    expect(labour('K', true, { lbrRate: 200 })).toBe(1); // 2.75 * 0.2 = 0.55 -> 1
    expect(labour('G', true)).toBe(300); // gross 3 * 100
    expect(labour('', true, { lbrRate: 0.5 })).toBe(2); // 3 * 0.5 = 1.5 -> 2 (to even)
    // No labour rate: the typed labour amount stands.
    expect(labour('G', true, { lbrRate: 0, lbrAmt: 77 })).toBe(77);
  });

  it('rounds weights half-up, as Strings.Format does', () => {
    // (1.001 + 0) * 50 / 100 = 0.5005 -> "0.000" 0.501 (a banker's rounding would give 0.500)
    const { cells } = tagCancelRecompute(
      looseRow({ grossWt: 1.001, touch: 50 }),
      baselineFromCells(null),
      settings,
    );
    expect(cells.fine).toBe(0.501);
  });

  it('forces net = gross - less whenever both are set, even over a typed net', () => {
    const first = tagCancelRecompute(
      looseRow({ grossWt: 5, lessWt: 1, touch: 50 }),
      baselineFromCells(null),
      settings,
    );
    const typedNet = tagCancelRecompute({ ...first.cells, netWt: 4.5 }, first.baseline, settings);
    expect(typedNet.cells.netWt).toBe(4);
    expect(typedNet.cells.fine).toBe(2);
  });

  it('derives the karigar net from KrOthWt on a tag row', () => {
    const row = { ...tagRow(), krOthWt: 0.6, grossWt: 10.8 };
    const { cells } = tagCancelRecompute(row, baselineFromCells(tagRow()), settings);
    expect(cells.krNetWt).toBe(10.2); // 10.8 - 0.6
    expect(cells.krFine).toBe(9.333); // 10.2 * 91.5 / 100 = 9.333
  });
});

describe('tagCancelStone (CommPassTotal_Idtl, one row)', () => {
  const stone = (patch: Partial<TagCancelStoneCells>): TagCancelStoneCells => ({
    pcs: 0,
    grossWt: 0,
    karigarWt: 0,
    conPct: 0,
    rateType: '',
    rate: 0,
    amount: 0,
    lbrRate: 0,
    lbrAmount: 0,
    netAmount: 0,
    conWt: 0,
    karigarConWt: 0,
    ...patch,
  });

  it('computes the DIA stone of vector V1', () => {
    const out = tagCancelStone(
      stone({ pcs: 10, grossWt: 0.5, conPct: 1, rateType: 'W', rate: 2000, lbrRate: 20 }),
    );
    expect(out.karigarWt).toBe(0.5); // filled from the weight
    expect(out.conWt).toBe(0.5);
    expect(out.karigarConWt).toBe(0.5);
    expect(out.amount).toBe(1000); // weight-wise 0.5 * 2000
    expect(out.lbrAmount).toBe(200); // 10 pcs * 20
    expect(out.netAmount).toBe(1200);
  });

  it('prices a blank P/W by pieces when there is no weight, and by weight otherwise', () => {
    expect(tagCancelStone(stone({ pcs: 3, rate: 50 })).amount).toBe(150);
    expect(tagCancelStone(stone({ pcs: 3, grossWt: 0.2, rate: 50 })).amount).toBe(10);
  });

  it('prices P by pieces only when the rate rounds to a whole non-zero number', () => {
    expect(tagCancelStone(stone({ pcs: 4, grossWt: 0.5, rateType: 'P', rate: 25 })).amount).toBe(
      100,
    );
    // Math.Round(0.4) = 0, so the desktop falls through to weight x rate.
    expect(tagCancelStone(stone({ pcs: 4, grossWt: 0.5, rateType: 'P', rate: 0.4 })).amount).toBe(
      0.2,
    );
  });

  it('fills the weight from the karigar weight and keeps the conversion at zero without a Con%', () => {
    const out = tagCancelStone(stone({ karigarWt: 0.3, pcs: 1 }));
    expect(out.grossWt).toBe(0.3);
    expect(out.conWt).toBe(0);
    expect(out.karigarConWt).toBe(0);
  });
});

describe('tagCancelStoneEffect', () => {
  it('moves the conversion weight into LsWt / NetWt and the stones net amount into OthAmt', () => {
    const effect = tagCancelStoneEffect(
      { grossWt: 10.5, lessWt: 0, netWt: 10.5, krOthWt: 0, krNetWt: 10.5, othAmt: 0 },
      [
        { conWt: 0.3, karigarConWt: 0.3, netAmount: 700 },
        { conWt: 0.2, karigarConWt: 0.25, netAmount: 500 },
      ],
    );
    expect(effect).toEqual({ lessWt: 0.5, netWt: 10, krOthWt: 0.55, krNetWt: 9.95, othAmt: 1200 });
  });

  it('leaves the row alone when the sums are zero', () => {
    const row = { grossWt: 5, lessWt: 0.4, netWt: 4.6, krOthWt: 0, krNetWt: 4.6, othAmt: 90 };
    expect(tagCancelStoneEffect(row, [{ conWt: 0, karigarConWt: 0, netAmount: 0 }])).toEqual({
      lessWt: 0.4,
      netWt: 4.6,
      krOthWt: 0,
      krNetWt: 4.6,
      othAmt: 90,
    });
  });
});

describe('tagCancelTotals (MSG_TOT_FILL)', () => {
  it('sums every column with the desktop formats', () => {
    const totals = tagCancelTotals([
      {
        pcs: 1,
        bagWt: 0.05,
        grossWt: 10.5,
        lessWt: 0.5,
        netWt: 10,
        fine: 9.36,
        lbrAmt: 1500,
        othAmt: 1200,
      },
      { pcs: 1, grossWt: 5.2, netWt: 5.2, fine: 4.763, othAmt: 50, mrp: 25000.5 },
      { grossWt: 2, netWt: 2, fine: 1.5 },
    ]);
    expect(totals).toMatchObject({
      pcs: 2,
      bagWt: 0.05,
      grossWt: 17.7,
      lessWt: 0.5,
      netWt: 17.2,
      fine: 15.623,
      lbrAmt: 1500,
      othAmt: 1250,
      mrp: 25000.5,
    });
  });
});

describe('tagCancelLineQualifies (the save filter, :5099)', () => {
  it('writes a named tag with an MRP even when it has no weight', () => {
    expect(tagCancelLineQualifies({ itCode: 'RNG', tagNo: 'T1', mrp: 100 })).toBe(true);
    expect(tagCancelLineQualifies({ itCode: 'RNG', tagNo: 'T1' })).toBe(false);
    expect(tagCancelLineQualifies({ itCode: '', tagNo: '', mrp: 100 })).toBe(false);
  });

  it('writes any row with pieces, weight, labour or other amount', () => {
    expect(tagCancelLineQualifies({ grossWt: 2 })).toBe(true);
    expect(tagCancelLineQualifies({ othAmt: 5 })).toBe(true);
    expect(tagCancelLineQualifies({ pcs: 1, grossWt: -1 })).toBe(false);
  });
});
