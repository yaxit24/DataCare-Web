import { describe, expect, it } from 'vitest';
import { DESKTOP_DATE_MASK, desktopDateMaskText, desktopSetDate } from '../src/setDate.js';

/** DC_Main.SetDate (DC_Main.cs:1561-1683), case by case. Session year 2025-2026, "today" 22/11. */
const ctx = { coYear: '2025-2026', today: { day: 22, month: 11 } };
const run = (digits: string) => desktopSetDate(desktopDateMaskText(digits), ctx);

describe('desktopSetDate (DC_Main.SetDate)', () => {
  it('builds the mask text from typed digits', () => {
    expect(desktopDateMaskText('')).toBe(DESKTOP_DATE_MASK);
    expect(desktopDateMaskText('3102')).toBe('31/02/____');
    expect(desktopDateMaskText('31/02/2026')).toBe('31/02/2026');
  });

  it('completes partial dates with today and the financial year (month < 4 → second year)', () => {
    expect(run('')).toEqual({ ok: true, text: '22/11/2025' });
    expect(run('05')).toEqual({ ok: true, text: '05/11/2025' });
    expect(run('0503')).toEqual({ ok: true, text: '05/03/2026' });
    expect(run('0504')).toEqual({ ok: true, text: '05/04/2025' });
    expect(run('050420')).toEqual({ ok: true, text: '05/04/2025' });
  });

  it('keeps a full date as typed, even outside the session year (no out-of-year message)', () => {
    expect(run('15082031')).toEqual({ ok: true, text: '15/08/2031' });
  });

  it('refuses one digit silently', () => {
    expect(run('3')).toEqual({ ok: false, silent: true, text: '3_/__/____' });
  });

  it('says "Date Not Valid..." for day 30/31 in February and day > 31, and clears to the mask', () => {
    for (const digits of ['30022026', '31022026', '3002', '32012026', '45052025'])
      expect(run(digits)).toEqual({
        ok: false,
        silent: false,
        message: 'Date Not Valid...',
        text: DESKTOP_DATE_MASK,
      });
  });

  it('says "Month Not Valid..." for a month over 12', () => {
    expect(run('01132025')).toEqual({
      ok: false,
      silent: false,
      message: 'Month Not Valid...',
      text: DESKTOP_DATE_MASK,
    });
    // The month test runs before the day test: 32/13 is a month message.
    expect(run('32132025')).toMatchObject({ message: 'Month Not Valid...' });
  });

  it('keeps the desktop weak checks: 31/04 and 29/02 of a non-leap year pass', () => {
    expect(run('31042025')).toEqual({ ok: true, text: '31/04/2025' });
    expect(run('29022025')).toEqual({ ok: true, text: '29/02/2025' });
  });
});
