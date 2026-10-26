import { describe, expect, it } from 'vitest';
import { fiscalYearDates, isIsoDay } from '../src/fiscalYear.js';

// MS_YEAR.cs:1035-1043: a yyyy-yyyy code with start month 04 opens 01/04 and closes 31/03 of the next year.
describe('fiscalYearDates (desktop MS_YEAR date fill)', () => {
  it('derives the Indian April–March year from the code', () => {
    expect(fiscalYearDates({ coYear: '2026-2027' })).toEqual({
      opDate: '2026-04-01',
      clDate: '2027-03-31',
      yearMonth: '04',
    });
    expect(fiscalYearDates({ coYear: ' 2027-2028 ', yearMonth: '4' })).toEqual({
      opDate: '2027-04-01',
      clDate: '2028-03-31',
      yearMonth: '04',
    });
  });

  it('closes the day before the start month a year later, including leap Februaries', () => {
    expect(fiscalYearDates({ coYear: '2026-2027', yearMonth: '1' })).toEqual({
      opDate: '2026-01-01',
      clDate: '2026-12-31',
      yearMonth: '01',
    });
    expect(fiscalYearDates({ coYear: '2027-2028', yearMonth: '03' })).toEqual({
      opDate: '2027-03-01',
      clDate: '2028-02-29',
      yearMonth: '03',
    });
  });

  it('keeps explicit dates and only derives what is missing', () => {
    expect(fiscalYearDates({ coYear: '2026-2027', opDate: '2026-04-15' })).toEqual({
      opDate: '2026-04-15',
      clDate: '2027-04-14',
      yearMonth: '04',
    });
    expect(fiscalYearDates({ coYear: 'FY26', opDate: '2026-04-01', clDate: '2027-03-31' })).toEqual(
      { opDate: '2026-04-01', clDate: '2027-03-31', yearMonth: '04' },
    );
  });

  it('refuses codes and dates the desktop could not store or post against', () => {
    expect(fiscalYearDates({ coYear: '' }).error).toBe('year code is required');
    expect(fiscalYearDates({ coYear: '2026-2028' }).error).toMatch(/consecutive years/);
    expect(fiscalYearDates({ coYear: '2026' }).error).toMatch(/not yyyy-yyyy/);
    expect(fiscalYearDates({ coYear: '2026-2027', yearMonth: '13' }).error).toMatch(/1 to 12/);
    expect(fiscalYearDates({ coYear: '2026-2027', yearMonth: 'x' }).error).toMatch(/1 to 12/);
    expect(fiscalYearDates({ coYear: '2026-2027', opDate: '2026-02-30' }).error).toMatch(
      /opening date 2026-02-30 is not a valid date/,
    );
    expect(
      fiscalYearDates({ coYear: '2026-2027', opDate: '2026-04-01', clDate: '2026-04-01' }).error,
    ).toMatch(/must be after opening date/);
  });

  it('recognises only real calendar days', () => {
    expect(isIsoDay('2028-02-29')).toBe(true);
    expect(isIsoDay('2027-02-29')).toBe(false);
    expect(isIsoDay('2026-4-01')).toBe(false);
    expect(isIsoDay('')).toBe(false);
  });
});
