import { describe, expect, it } from 'vitest';
import {
  recalcLine,
  recalcSaleGridRow,
  saleGridRowLabour,
  saleLineLabourMode,
} from '../lib/lineRecalc';
import { fineFor, labourCharge, metalAmount, resolveRoundingPolicy, round } from '@datacare/core';

/**
 * The client kernel must agree with the server's arithmetic.
 *
 * The risk being tested is not "is the formula pretty" but "does the operator see the total that will
 * actually post". Because `lineRecalc` delegates to the same `@datacare/core` primitives the API
 * uses, agreement is structural — these tests exist to prove the DELEGATION is real and that the
 * chain wiring (which value feeds which) matches, since that is the part a second implementation
 * gets wrong.
 */
describe('lineRecalc agrees with the core primitives the server uses', () => {
  it('derives net, fine, metal and total through the same core functions', () => {
    const line = {
      grossWt: '10.500',
      lessWt: '0.500',
      touch: '91.60',
      rate: '6000',
      rateWith: 'F',
      labourType: 'G',
      labourRate: '50',
    };
    const r = recalcLine(line);

    const expectedNet = round(10.5 - 0.5, 3);
    const expectedFine = fineFor('sale', { netWt: expectedNet, touch: 91.6 });
    const expectedMetal = metalAmount(expectedFine, 6000);

    expect(r.netWt).toBe(expectedNet);
    expect(r.fineWt).toBe(expectedFine);
    expect(r.metalAmount).toBe(expectedMetal);
    expect(r.totalAmount).toBe(round(expectedMetal + r.netLabourAmount, 2));
  });

  it('includes ghat in per-gram labour by default, matching LBR_WITH_GHT blank = Y', () => {
    // The desktop's blank default is PERMISSIVE ('Y'), and the server-side equivalent of this was a
    // live money defect: per-gram labour was understated by ghat x rate on every line with ghat.
    const line = { grossWt: '10', netWt: '10', ghtWt: '2', labourType: 'G', labourRate: '50' };
    const withGhat = recalcLine(line);
    const withoutGhat = recalcLine(line, 'sale', { labourIncludesGhat: false });

    expect(withGhat.labourAmount).toBe(
      labourCharge('per_gram', { netWt: 10, ghatWt: 2, rate: 50 }),
    );
    expect(withGhat.labourAmount).toBe(600);
    expect(withoutGhat.labourAmount).toBe(500);
    expect(withGhat.labourAmount).toBeGreaterThan(withoutGhat.labourAmount);
  });

  it('uses the desktop policy per workflow, which genuinely differ', () => {
    // These are the SERVER's policies (finePolicy.ts in @datacare/core), each desktop-cited:
    //   sale          : ((net + ghat) x (touch + west)) / 100          — ghat IS in the base
    //   karigarIssue  : ((net + ghat) x pct) / 100 - lesWt             — TR_KR_ISU.cs:3938-3944
    //   karigarReceipt: (net x pct) / 100                              — MS_UPDATE.cs:2691, net only
    //   itemOpening   : (net x pct) / 100, ghat ignored                — TR_ITM_OPBL.cs:949-955
    // An earlier version of this kernel invented a two-value policy and had `sale` wrong: it dropped
    // ghat and lost the pct === 0 fallback. A live sale return posted 5.065 where it predicted 4.605.
    const line = { netWt: '10.000', ghtWt: '1.000', touch: '90', westPct: '2', lesWt: '0.500' };

    expect(recalcLine(line, 'sale').fineWt).toBe(
      fineFor('sale', {
        netWt: 10,
        ghtWt: 1,
        touch: 90,
        westPct: 2,
      }),
    );
    expect(recalcLine(line, 'karigarIssue').fineWt).toBe(
      fineFor('karigarIssue', {
        netWt: 10,
        ghtWt: 1,
        touch: 90,
        westPct: 2,
        lesWt: 0.5,
      }),
    );
    // The three must not coincide, or the distinction is not being honoured.
    const sale = recalcLine(line, 'sale').fineWt;
    const issue = recalcLine(line, 'karigarIssue').fineWt;
    const receipt = recalcLine(line, 'karigarReceipt').fineWt;
    expect(new Set([sale, issue, receipt]).size).toBe(3);
    // ghat belongs to the sale base: 11 x 92% = 10.12, not 10 x 92% = 9.2
    expect(sale).toBe(10.12);
    expect(receipt).toBe(9.2);
  });

  it('treats a blank cell as absent, not as an explicit zero', () => {
    // This is the suppression-bug class already fixed twice on the server: sending Number(x || 0)
    // turns an untouched field into an override that defeats the derivation.
    const derived = recalcLine({ grossWt: '10', lessWt: '1', touch: '90' });
    const overridden = recalcLine({ grossWt: '10', lessWt: '1', touch: '90', netWt: '5' });

    expect(derived.netWt).toBe(9);
    expect(overridden.netWt).toBe(5);
    expect(recalcLine({ grossWt: '10', lessWt: '1', touch: '90', netWt: '' }).netWt).toBe(9);
  });

  it('prices fine weight or net weight according to RtWith', () => {
    const base = { grossWt: '10', netWt: '10', touch: '90', rate: '100' };
    expect(recalcLine({ ...base, rateWith: 'F' }).metalAmount).toBe(
      metalAmount(fineFor('sale', { netWt: 10, touch: 90 }), 100),
    );
    expect(recalcLine({ ...base, rateWith: 'N' }).metalAmount).toBe(metalAmount(10, 100));
  });

  // Vectors D6-1..D6-8 (contract in parity-plan-2026-09-10/evidence/implementation-2026-09-29-eval-defects).
  // Literal figures worked by hand from TR_SALE.cs CommPassTotal, so the preview is checked against the
  // desktop rather than against the server code it shares.
  it('D6-1: a blank line on a blank company previews net, the 60,000 the desktop bills', () => {
    const line = { pcs: '1', grossWt: '10', netWt: '10', touch: '91.6', rate: '6000' };
    expect(recalcLine(line, 'sale', { saleAmountType: '' }).metalAmount).toBe(60000);
  });

  it.each([
    ['', 10000],
    ['F', 9160],
    ['G', 12000],
    ['N', 10000],
    ['P', 1000],
  ])('D6-2: company SL_AMT_TYPE %s previews %d', (company, expected) => {
    const line = { pcs: '1', grossWt: '12', netWt: '10', touch: '91.6', rate: '1000' };
    expect(recalcLine(line, 'sale', { saleAmountType: company }).metalAmount).toBe(expected);
  });

  it('D6-3/D6-4: the line RtWith overrides the company type and ghat joins net and gross', () => {
    const line = {
      pcs: '2',
      grossWt: '12',
      netWt: '10',
      ghtWt: '0.5',
      touch: '91.6',
      rate: '1000',
    };
    expect(
      recalcLine({ ...line, rateWith: 'G' }, 'sale', { saleAmountType: 'N' }).metalAmount,
    ).toBe(12500);
    expect(
      recalcLine({ ...line, rateWith: 'P' }, 'sale', { saleAmountType: 'N' }).metalAmount,
    ).toBe(2000);
    expect(recalcLine(line, 'sale', { saleAmountType: 'N' }).metalAmount).toBe(10500);
    expect(recalcLine(line, 'sale', { saleAmountType: 'F' }).metalAmount).toBe(9618);
  });

  it('D6-5/D6-6: the item RATE_TYPE divides a per-kg or per-10 g rate', () => {
    expect(
      recalcLine({ grossWt: '250', netWt: '250', rate: '70000', rateType: 'K' }, 'sale', {
        saleAmountType: 'N',
      }).metalAmount,
    ).toBe(17500);
    expect(
      recalcLine({ grossWt: '10', netWt: '10', rate: '60000', rateType: '1' }, 'sale', {
        saleAmountType: 'N',
      }).metalAmount,
    ).toBe(60000);
  });

  it('routes rounding through the kernel, including the negative midpoint WP-06 caught', () => {
    // A local Math.round would give -1 here; the kernel's policy is what the server uses.
    expect(recalcLine({ grossWt: '-1.005', netWt: '-1.005', touch: '100' }).fineWt).toBe(
      fineFor('sale', { netWt: -1.005, touch: 100 }),
    );
  });
});

describe('sale ghat percentage (desktop oracle, family 1)', () => {
  // desktop-oracle.yml run 42580947381, vectors ghat.pct1 / ghat.pct2.5 / ghat.pct3.33: TR_SALE.cs:10581 takes
  // the percentage of NET weight (gross 10.555 - less 0.500 = 10.055).
  it.each([
    ['1.00', 0.101],
    ['2.50', 0.251],
    ['3.33', 0.335],
  ])('ITM_GHT_PRC %s gives the desktop ghat weight', (pct, ghat) => {
    const r = recalcLine(
      { grossWt: '10.555', lessWt: '0.500', ghtPct: pct, touch: '91.60' },
      'sale',
    );
    expect(r.netWt).toBe(10.055);
    expect(r.ghtWt).toBe(ghat);
  });
});

describe('sale percentage labour and line precision (desktop oracle, N235/G247)', () => {
  // Desktop oracle vector labour.pct.G.rtN (run 42580947381): 3 pcs, gross 10.555, less 0.500, ghat 0.120, touch
  // 91.6, RtWith N, item rate 6200, LBR_PRC 12, LBR_TYPE G -> LBR_RATE 744.00, LBR_AMT 7853.00.
  const line = {
    pcs: '3',
    grossWt: '10.555',
    lessWt: '0.500',
    ghtWt: '0.120',
    touch: '91.6',
    rateWith: 'N',
    rate: '6200',
    labourPct: '12',
    labourType: '%',
  };
  const policy = resolveRoundingPolicy({ LBR_ROF: '2', TOT_AMT_ROF: '2' });

  it('derives the labour rate from the item rate and multiplies the LBR_TYPE basis', () => {
    // The desktop formula, worked here: rate = round(6200 x 12 / 100, 2) = 744; amount = round(basis x 744, 0).
    const rate = Math.round(((6200 * 12) / 100) * 100) / 100;
    const r = (basis: string) =>
      recalcLine(line, 'sale', { roundingPolicy: policy, labourBasis: basis });
    expect(r('G').labourRate).toBe(744);
    expect(r('G').labourAmount).toBe(Math.round(10.555 * rate)); // 7853
    expect(r('N').labourAmount).toBe(Math.round((10.055 + 0.12) * rate)); // 7570
    expect(r('P').labourAmount).toBe(3 * rate); // 2232
  });

  it('rounds ITM_AMT to whole rupees whatever TOT_AMT_ROF says (TR_SALE.cs:10343-10362)', () => {
    const plain = { netWt: '10', touch: '91.6', rateWith: 'N', rate: '6123.45' };
    expect(recalcLine(plain, 'sale', { roundingPolicy: policy }).metalAmount).toBe(61234);
    expect(
      recalcLine(plain, 'sale', { roundingPolicy: resolveRoundingPolicy({ ALL_ROF_REMOVE: 'Y' }) })
        .metalAmount,
    ).toBe(61234.5);
  });

  it('a Lbr% row with an item rate is a percentage line; otherwise Making/g is per gram', () => {
    expect(saleLineLabourMode({ lbrPct: '12', rate: '6200', making: '50' })).toBe('percentage');
    expect(saleLineLabourMode({ lbrPct: '12', rate: '', making: '50' })).toBe('per_gram');
    expect(saleLineLabourMode({ lbrPct: '', rate: '6200', making: '' })).toBeUndefined();
  });

  it('the Sale grid row previews and posts a Lbr% row as a percentage line', () => {
    const row = { ...line, labourType: undefined, making: '50', lbrPct: '12' };
    const preview = recalcSaleGridRow(row, { roundingPolicy: policy, labourBasis: 'G' });
    expect(preview.labourRate).toBe(744);
    expect(preview.labourAmount).toBe(7853);
    expect(saleGridRowLabour(row)).toEqual({ labourType: 'percentage' });
    expect(saleGridRowLabour({ making: '50', rate: '6200' })).toEqual({
      labourType: 'per_gram',
      labourRate: 50,
    });
    expect(recalcSaleGridRow({ netWt: '10', making: '50' }).labourAmount).toBe(500);
  });
});
