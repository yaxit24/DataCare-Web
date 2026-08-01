/**
 * PARITY_STRICT: an absent setting must fail, not silently take a default.
 *
 * WHY THIS EXISTS
 * An absent setting is indistinguishable from a product defect in a comparison, and that is not a theoretical
 * risk — it has happened, and it cost two commits.
 *
 * The replay harness seeded `CO_SET` but not `CO_SET_NEW`, so `TOT_AMT_ROF` was missing and
 * `resolveRoundingPolicy` kept its documented 2dp default. The web then produced a bill total of 1515.21
 * against the desktop's 1515.00, and that was written up as the web LACKING a whole-rupee rounding mode. It
 * was not: the mode was implemented correctly the whole time, and `roundingPolicy.ts` even cited the same
 * desktop source lines that were later rediscovered while chasing the phantom.
 *
 * On its first run, strict mode found a third omission nobody had noticed: `ITM_RATE_ROF` had never been
 * seeded either, so the harness had been taking a default for item-rate precision as well.
 *
 * The flag is OFF by default. Production genuinely wants a sane default when a customer has not set a flag.
 * It is ON for parity work, where the entire point is that nothing may be assumed.
 */
import { afterEach, describe, expect, it } from 'vitest';
import {
  resolveRoundingPolicy,
  RoundingPolicyValidationError,
} from '../src/modules/shared/roundingPolicy.js';

/** Every rounding flag the resolver knows about, set explicitly. */
const ALL_SET = {
  TAX_ROF: 2,
  LBR_ROF: 2,
  ITM_RATE_ROF: 2,
  TOT_AMT_ROF: 0,
  PR_RATE_ROF: 2,
} as const;

describe('PARITY_STRICT rounding settings', () => {
  afterEach(() => {
    delete process.env.PARITY_STRICT;
  });

  it('permits absent settings by default, so production keeps its defaults', () => {
    // No PARITY_STRICT. This is the behaviour a real deployment relies on.
    const policy = resolveRoundingPolicy({});
    expect(policy.roundBillTotal(1560.45)).toBe(1560.45);
  });

  it('throws under strict mode when a setting is absent', () => {
    process.env.PARITY_STRICT = '1';
    expect(() => resolveRoundingPolicy({})).toThrow(RoundingPolicyValidationError);
  });

  it('names every unset flag, so the omission is fixable without guessing', () => {
    process.env.PARITY_STRICT = '1';
    // Exactly the shape of the real harness bug: CO_SET seeded, CO_SET_NEW not.
    let message = '';
    try {
      resolveRoundingPolicy({ TAX_ROF: 2, LBR_ROF: 2, ITM_RATE_ROF: 2 });
    } catch (e) {
      message = e instanceof Error ? e.message : String(e);
    }
    expect(message).toContain('TOT_AMT_ROF');
    expect(message).toContain('PR_RATE_ROF');
    // The ones that WERE configured must not be blamed.
    expect(message).not.toContain('TAX_ROF');
    expect(message).not.toContain('LBR_ROF');
  });

  it('passes under strict mode when every setting is present', () => {
    process.env.PARITY_STRICT = '1';
    const policy = resolveRoundingPolicy(ALL_SET);
    // TOT_AMT_ROF 0 is the real customer's value: whole rupees.
    expect(policy.roundBillTotal(1560.45)).toBe(1560);
  });

  it('a configured zero is not treated as absent', () => {
    process.env.PARITY_STRICT = '1';
    // 0 is a real, meaningful value here - it is what makes the desktop round to whole rupees - so a falsy
    // check would reject the very configuration this project spent two commits failing to reproduce.
    expect(() => resolveRoundingPolicy({ ...ALL_SET, TOT_AMT_ROF: 0 })).not.toThrow();
  });
});

describe('line components follow the bill-amount precision', () => {
  // Measured on the real customer database: every money column in all 245 SL_DETL rows is a whole rupee, and
  // NET_AMT = ITM_AMT + LBR_AMT + OTH_AMT holds on 244 of them. 4.600 x 77 = 354.20 is stored as 354.00 and
  // 4.600 x 16.09 = 74.014 as 74.00, so components are rounded individually rather than only at the total.
  //
  // Not asserted: a derivation. ITM_AMT equals ROUND(nwt x rate, 0) on only 134 of 220 candidate rows, because
  // the desktop grid lets the operator overtype an amount. The rule that survives the data is "whatever the
  // component is, it is rounded".
  it('rounds to whole rupees when TOT_AMT_ROF is 0', () => {
    const policy = resolveRoundingPolicy({ ...ALL_SET, TOT_AMT_ROF: 0 });
    expect(policy.roundBillTotal(354.2)).toBe(354);
    expect(policy.roundBillTotal(74.014)).toBe(74);
    expect(policy.roundBillTotal(7436.8)).toBe(7437);
  });

  it('leaves paise alone when the same setting is 2, so the behaviour is configured not hardcoded', () => {
    const policy = resolveRoundingPolicy({ ...ALL_SET, TOT_AMT_ROF: 2 });
    expect(policy.roundBillTotal(354.2)).toBeCloseTo(354.2, 2);
    expect(policy.roundBillTotal(74.014)).toBeCloseTo(74.01, 2);
  });
});
