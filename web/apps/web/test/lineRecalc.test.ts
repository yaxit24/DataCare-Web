import { describe, expect, it } from 'vitest';
import { recalcLine } from '../lib/lineRecalc';
import { fineFor, labourCharge, metalAmount, round } from '@datacare/core';

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

  it('routes rounding through the kernel, including the negative midpoint WP-06 caught', () => {
    // A local Math.round would give -1 here; the kernel's policy is what the server uses.
    expect(recalcLine({ grossWt: '-1.005', netWt: '-1.005', touch: '100' }).fineWt).toBe(
      fineFor('sale', { netWt: -1.005, touch: 100 }),
    );
  });
});
