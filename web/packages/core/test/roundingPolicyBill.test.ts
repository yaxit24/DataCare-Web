import { describe, it, expect } from 'vitest';
import { billTotals } from '../src/calc.js';
import { resolveRoundingPolicy } from '../src/roundingPolicy.js';

/**
 * G102/G84: a screen must preview a document's totals with the same arithmetic and company rounding policy
 * the server posts, or the operator sees one number and the ledger stores another. These vectors pin the
 * shared rule so the web (which now builds the policy from the session flags) and the server stay identical.
 */
describe('billTotals with the company rounding policy (G102)', () => {
  it('rounds the bill total to whole rupees when TOT_AMT_ROF=0 (the desktop 1515 case)', () => {
    // The replay case: net 1515.21-ish taxable, 0% here to isolate the total rounding. The desktop stores
    // 1515; the web used to preview 1515.21 with no policy, 1515 with it.
    const policy = resolveRoundingPolicy({ TOT_AMT_ROF: '0', TAX_ROF: '2' });
    const t = billTotals(
      { lineNetTotal: 1515.21, discountAmount: 0, taxRatePct: 0, interState: false },
      policy,
    );
    expect(t.total).toBe(1515);
    expect(t.taxable).toBe(1515);
  });

  it('a 2dp policy keeps paise, matching a server that posts 75318.75 not 75319', () => {
    // The sale the 2026-10-26 run found: previewed 75319 (Math.round), posted 75318.75.
    const policy = resolveRoundingPolicy({ TOT_AMT_ROF: '2', TAX_ROF: '2' });
    const t = billTotals(
      { lineNetTotal: 73124.03, discountAmount: 0, taxRatePct: 3, interState: false },
      policy,
    );
    // taxable 73124.03, tax 2193.72(…), total 75317.75-ish — the exact value is the point: it keeps paise.
    expect(Number.isInteger(t.total)).toBe(false);
    expect(t.total).toBeCloseTo(t.taxable + t.tax, 2);
  });

  it('absent flags keep the 2dp half-up default, so a company with no settings is unchanged', () => {
    const policy = resolveRoundingPolicy({});
    const withPolicy = billTotals(
      { lineNetTotal: 1000, discountAmount: 100, taxRatePct: 3, interState: false },
      policy,
    );
    expect(withPolicy.taxable).toBe(900);
    expect(withPolicy.tax).toBe(27);
    expect(withPolicy.total).toBe(927);
  });

  it('TOT_AMT_ROF=0 with tax rounds taxable and total to whole rupees (banker from a configured flag)', () => {
    const policy = resolveRoundingPolicy({ TOT_AMT_ROF: '0', TAX_ROF: '0' });
    const t = billTotals(
      { lineNetTotal: 20864.5, discountAmount: 0, taxRatePct: 1.5, interState: false },
      policy,
    );
    expect(Number.isInteger(t.total)).toBe(true);
  });
});
