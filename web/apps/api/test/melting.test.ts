import { describe, it, expect } from 'vitest';
import { meltLine } from '../src/modules/manufacturing/melting.js';

describe('melting line math', () => {
  it('input fine = nwt × touch/100; loss% reduces recovered', () => {
    const r = meltLine({ netWt: 100, touch: 85 }, 2);
    expect(r.partyFine).toBe(85); // 100 × 85%
    expect(r.netFine).toBe(83.3); // 85 × (1 − 2%)
    expect(r.lossWt).toBeCloseTo(1.7, 3);
  });
  it('explicit assay (recoveredFine) overrides loss%', () => {
    const r = meltLine({ netWt: 100, touch: 90, recoveredFine: 88 }, 5);
    expect(r.partyFine).toBe(90);
    expect(r.netFine).toBe(88);
    expect(r.lossWt).toBeCloseTo(2, 3);
  });
  it('zero loss → recovered == input', () => {
    const r = meltLine({ netWt: 50, touch: 91.6 }, 0);
    expect(r.netFine).toBe(r.partyFine);
    expect(r.lossWt).toBe(0);
  });
});
