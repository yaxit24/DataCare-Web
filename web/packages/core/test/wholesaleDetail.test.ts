import { describe, expect, it } from 'vitest';
import {
  commPassTotalIdtl,
  detailRowIsWritten,
  detailWeightFromKr,
  detailWeightFromPieces,
  rollupWholesaleDetails,
  wholesaleBand,
} from '../src/index.js';

/** Expected values are the desktop expressions of CommPassTotal_Idtl (TR_WH_SALE.cs:7750-7971) worked by hand. */
describe('commPassTotalIdtl', () => {
  const rowA = { pcs: 2, pcsWt: 1.5, conPct: 0.1, krConPct: 0.05, rate: 101, discPct: 5, lbrRate: 237.5 };
  it('worked vector: weight 3, ConWt .3, KrConWt .15, ItAmt 303, Lbr 475, Disc 15, Net 763', () => {
    // 2 x 1.5 = 3.000; 3 x 0.1 = 0.300; 3 x 0.05 = 0.150; 101 x 3 = 303; 237.5 x 2 = 475; round(303 x 5 / 100 = 15.15) = 15;
    // 303 - 15 + 475 = 763.
    expect(commPassTotalIdtl(rowA)).toMatchObject({
      weight: 3, tagWt: 3, conWt: 0.3, krConWt: 0.15, itAmt: 303, lbrAmt: 475, discAmt: 15, netAmt: 763,
    });
  });
  it('KrCon% zero falls back to Con%: tag weight x Con%', () => {
    expect(commPassTotalIdtl({ ...rowA, krConPct: 0 }).krConWt).toBe(0.3);
  });
  it("banker's rounding: 101 x 2.5 = 252.5 rounds to 252, not 253", () => {
    expect(commPassTotalIdtl({ weight: 2.5, rate: 101 }).itAmt).toBe(252);
  });
  it('rate type P prices by piece: 101 x 2 = 202; a P rate that rounds to 0 prices by weight', () => {
    expect(commPassTotalIdtl({ ...rowA, rateType: 'P' }).itAmt).toBe(202);
    expect(commPassTotalIdtl({ pcs: 2, weight: 3, rateType: 'P', rate: 0.4 }).itAmt).toBe(1);
  });
  it('blank type, no weight: rate x pieces', () => {
    expect(commPassTotalIdtl({ pcs: 3, rate: 50 }).itAmt).toBe(150);
  });
  it('a typed net amount stays when item and labour amounts are zero', () => {
    expect(commPassTotalIdtl({ weight: 2, conPct: 0.1, netAmt: 500 })).toMatchObject({ conWt: 0.2, netAmt: 500 });
  });
  it('is idempotent: re-feeding its own result changes nothing (an unchanged reopen+save)', () => {
    const first = commPassTotalIdtl(rowA);
    expect(commPassTotalIdtl({ ...first })).toEqual(first);
  });
  it('Enter helpers and the save filter', () => {
    expect(detailWeightFromPieces(2, 1.5)).toBe(3);
    expect(detailWeightFromPieces(0, 1.5)).toBeNull();
    expect(detailWeightFromKr(10, 25)).toBe(2.5);
    expect(detailRowIsWritten(commPassTotalIdtl({}))).toBe(false);
    expect(detailRowIsWritten(commPassTotalIdtl({ pcs: 1 }))).toBe(true);
  });
});

describe('rollupWholesaleDetails', () => {
  it('sums into the line: col16 .5, col17 4.5, col46 .15, col47 4.85, col37 1263', () => {
    const a = commPassTotalIdtl({ pcs: 2, pcsWt: 1.5, conPct: 0.1, krConPct: 0.05, rate: 101, discPct: 5, lbrRate: 237.5 });
    const b = commPassTotalIdtl({ weight: 2, conPct: 0.1, krConPct: 0.0001, netAmt: 500 });
    const up = rollupWholesaleDetails([a, { ...b, krConWt: 0 }], 5);
    expect(up).toMatchObject({ othWt: 0.5, netWt: 4.5, krOthWt: 0.15, krNwt: 4.85, othAmt: 1263, silverFine: null });
  });
  it('silver rows with no ItAmt roll their weight into SlvrFine', () => {
    const s = commPassTotalIdtl({ weight: 1.25, itType: 'S' });
    expect(rollupWholesaleDetails([s], 2).silverFine).toBe(1.25);
  });
});

describe('wholesaleBand fine kasar', () => {
  it('Tot Fine Dr 9.160+0.500, Cr 9.160+0.250, Os 0.250', () => {
    const band = wholesaleBand({
      settlement: {}, issued: { fine: 9.16, netAmount: 0 }, received: { fine: 9.16, netAmount: 0 },
      ksrFineDr: 0.5, ksrFineCr: 0.25,
    });
    expect(band).toMatchObject({ totFineDr: 9.66, totFineCr: 9.41, osFine: 0.25 });
  });
});
