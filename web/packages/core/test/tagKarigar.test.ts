import { describe, expect, it } from 'vitest';
import { tagKarigarBlock, tagKarigarColumns, tagKarigarStock } from '../src/tagKarigar.js';

// Expected values are worked out by hand from TR_TAG_OPBL.cs CommPassTotal (:6679-6826) and BtnSave_Click
// (:10975-11022), not read back from the implementation.
describe('tag karigar weight block (TR_TAG_OPBL columns 17-23)', () => {
  it('KrNwt is gross − KrOthWt while both are non-zero, even over a typed KrNwt (:6679-6686)', () => {
    expect(
      tagKarigarBlock({ grossWt: '10.5', netWt: '10', karigarOthWt: '0.5', karigarNetWt: '9' })
        .karigarNetWt,
    ).toBe(10);
  });

  it('a blank KrNwt takes the net weight and a typed one stays (:6690-6704)', () => {
    expect(tagKarigarBlock({ grossWt: 10.5, netWt: 9.8 }).karigarNetWt).toBe(9.8);
    expect(tagKarigarBlock({ grossWt: 10.5, netWt: 9.8, karigarNetWt: 9.5 }).karigarNetWt).toBe(
      9.5,
    );
    // KrOthWt without a gross weight does not force the subtraction.
    expect(tagKarigarBlock({ grossWt: 0, netWt: 4, karigarOthWt: 1 }).karigarNetWt).toBe(4);
  });

  it('with no karigar touch or wastage KrFine is KrNwt + KrGht, over a typed KrFine (:6793-6800)', () => {
    expect(tagKarigarBlock({ netWt: 10, karigarGhtWt: 0.25, karigarFine: 9 }).karigarFine).toBe(
      10.25,
    );
  });

  it('with a touch a blank KrFine is (KrNwt + KrGht) × (KrTouch + KrWst%) / 100 (:6804-6811)', () => {
    // (10 + 0.25) × (91.6 + 2) / 100 = 959.4 / 100 = 9.594
    expect(
      tagKarigarBlock({ netWt: 10, karigarGhtWt: 0.25, karigarTouch: 91.6, karigarWestPct: 2 })
        .karigarFine,
    ).toBe(9.594);
    // 9.8 × 91.65 / 100 = 8.9817, shown to 3 decimals
    expect(tagKarigarBlock({ netWt: 9.8, karigarTouch: 91.65 }).karigarFine).toBe(8.982);
  });

  it('with a touch a typed KrFine stays', () => {
    expect(tagKarigarBlock({ netWt: 10, karigarTouch: 91.6, karigarFine: '9.5' }).karigarFine).toBe(
      9.5,
    );
  });

  it('a save without KrTouch takes the tag’s own touch, wastage and fine (:11010-11012)', () => {
    expect(
      tagKarigarColumns({
        grossWt: 10.5,
        netWt: 10,
        karigarOthWt: 0.5,
        karigarGhtPct: 2.5,
        karigarGhtWt: 0.25,
        karigarWestPct: 3,
        karigarFine: 7,
        touch: 91.6,
        westPct: 1,
        fineWt: 9.26,
      }),
    ).toEqual({
      KR_OTH_WT: 0.5,
      KR_NET_WT: 10,
      KR_GHT_PRC: 2.5,
      KR_GHT_WT: 0.25,
      KR_TOUCH: 91.6,
      KR_WEST_PRC: 1,
      KR_FINE: 9.26,
    });
  });

  it('a save with KrTouch keeps the three karigar cells (:11017-11019)', () => {
    expect(
      tagKarigarColumns({
        grossWt: 10.5,
        netWt: 10.5,
        karigarGhtWt: 0.25,
        karigarTouch: 91.6,
        karigarWestPct: 2,
        touch: 75,
        westPct: 0,
        fineWt: 7.875,
      }),
    ).toEqual({
      KR_OTH_WT: 0,
      KR_NET_WT: 10.5,
      KR_GHT_PRC: 0,
      KR_GHT_WT: 0.25,
      KR_TOUCH: 91.6,
      KR_WEST_PRC: 2,
      // (10.5 + 0.25) × 93.6 / 100 = 10.062
      KR_FINE: 10.062,
    });
  });

  it('a blank row saves zeros and the tag fine', () => {
    expect(tagKarigarColumns({ fineWt: '' })).toEqual({
      KR_OTH_WT: 0,
      KR_NET_WT: 0,
      KR_GHT_PRC: 0,
      KR_GHT_WT: 0,
      KR_TOUCH: 0,
      KR_WEST_PRC: 0,
      KR_FINE: 0,
    });
  });

  it('the stock row copies KR_NET_WT, KR_TOUCH, KR_WEST_PRC and KR_FINE (Ac_Stock.cs:28)', () => {
    expect(
      tagKarigarStock({
        KR_OTH_WT: 0.5,
        KR_NET_WT: 10,
        KR_GHT_PRC: 2.5,
        KR_GHT_WT: 0.25,
        KR_TOUCH: 92,
        KR_WEST_PRC: 1.5,
        KR_FINE: 9.584,
      }),
    ).toEqual({ KR_NWT: 10, KR_TOUCH: 92, KR_WEST: 1.5, KR_FINE: 9.584 });
  });
});
