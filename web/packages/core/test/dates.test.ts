import { describe, expect, it } from 'vitest';
import { formatDesktopDate, toIsoDate } from '../src/dates.js';

describe('toIsoDate (N56, D19)', () => {
  it('reads a date column value by its UTC parts', () => {
    expect(toIsoDate(new Date(Date.UTC(2026, 9, 1)))).toBe('2026-10-01');
  });

  it('keeps an ISO date and the calendar day written in an ISO timestamp', () => {
    expect(toIsoDate('2026-10-01')).toBe('2026-10-01');
    expect(toIsoDate('2026-10-01T00:00:00.000Z')).toBe('2026-10-01');
    expect(toIsoDate('2026-10-01T23:30:00+05:30')).toBe('2026-10-01');
    expect(toIsoDate('2026-10-01 00:00:00')).toBe('2026-10-01');
  });

  it('accepts 29 February only in a leap year', () => {
    expect(toIsoDate('2024-02-29')).toBe('2024-02-29');
    expect(() => toIsoDate('2026-02-29')).toThrow(RangeError);
  });

  it('refuses what is not a date, and treats empty as empty', () => {
    for (const bad of ['Thu Oct 01 2026', '01/10/2026', '2026-13-01', 'abc', new Date('x')])
      expect(() => toIsoDate(bad)).toThrow(RangeError);
    expect(toIsoDate(null)).toBe('');
    expect(toIsoDate(undefined)).toBe('');
    expect(toIsoDate('')).toBe('');
  });
});

describe('formatDesktopDate', () => {
  it('shows dd/MM/yyyy, the desktop display format, always with the year', () => {
    expect(formatDesktopDate(new Date(Date.UTC(2026, 9, 1)))).toBe('01/10/2026');
    expect(formatDesktopDate('2026-10-01T23:30:00+05:30')).toBe('01/10/2026');
    expect(formatDesktopDate('2024-02-29')).toBe('29/02/2024');
    expect(formatDesktopDate(null)).toBe('');
  });
});
