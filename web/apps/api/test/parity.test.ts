import { describe, it, expect } from 'vitest';
import { runParity } from '../src/modules/parity/golden.js';

describe('parity golden vectors', () => {
  it('all desktop-derived golden vectors pass', () => {
    const r = runParity();
    const failures = r.results
      .filter((x) => !x.ok)
      .map((x) => `${x.name}: got ${JSON.stringify(x.actual)} want ${JSON.stringify(x.expected)}`);
    expect(failures).toEqual([]);
    expect(r.failed).toBe(0);
    expect(r.total).toBeGreaterThanOrEqual(12);
  });
});
