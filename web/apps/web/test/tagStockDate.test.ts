import { describe, expect, it } from 'vitest';
import { isoToDesktop, parseDesktopDate } from '../app/(app)/reports/tag-stock/dateText';

/** DC_Main.cs:1641-1690: "Date Not Valid..." above day 31, "Month Not Valid..." above month 12 (impossible dates refused too). */
describe('Tag Stock date mask', () => {
  it('accepts a real date and returns the ISO day', () => {
    expect(parseDesktopDate('31/05/2026')).toEqual({ iso: '2026-05-31' });
    expect(parseDesktopDate('1/4/2026')).toEqual({ iso: '2026-04-01' });
    expect(isoToDesktop('2026-05-31')).toBe('31/05/2026');
  });
  it('refuses a day above 31 and a month above 12 with the desktop texts', () => {
    expect(parseDesktopDate('32/05/2026')).toEqual({ error: 'Date Not Valid...' });
    expect(parseDesktopDate('15/13/2026')).toEqual({ error: 'Month Not Valid...' });
  });
  it('refuses impossible calendar dates and non-dates', () => {
    for (const bad of ['30/02/2026', '31/04/2026', '29/02/2027', '', 'abc', '5/5/26'])
      expect(parseDesktopDate(bad)).toEqual({ error: 'Date Not Valid...' });
    expect(parseDesktopDate('29/02/2028')).toEqual({ iso: '2028-02-29' });
  });
});
