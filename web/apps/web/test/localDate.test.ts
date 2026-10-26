import { describe, expect, it } from 'vitest';
import { monthStartLocal, todayLocal } from '../lib/localDate';

describe('local calendar date defaults', () => {
  it('uses the local day, not the UTC day', () => {
    // 27 Oct 2026 02:07 local is still 26 Oct in UTC (the E2E run that found this was at 02:07 IST).
    const afterMidnight = new Date(2026, 9, 27, 2, 7, 56);
    expect(todayLocal(afterMidnight)).toBe('2026-10-27');
    expect(todayLocal(new Date(2026, 0, 5, 23, 59))).toBe('2026-01-05');
  });

  it('gives the first day of the local month', () => {
    expect(monthStartLocal(new Date(2026, 9, 1, 0, 30))).toBe('2026-10-01');
    expect(monthStartLocal(new Date(2027, 1, 28, 12))).toBe('2027-02-01');
  });
});
