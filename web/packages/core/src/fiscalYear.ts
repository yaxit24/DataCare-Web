/**
 * Financial-year dates (desktop Year Create, `MS_YEAR`).
 *
 * `MS_YEAR.cs:1035-1043` fills the dates from the year code: a `yyyy-yyyy` code with start month 04 opens
 * 01/04 of the first year and closes 31/03 of the second, and `:1196`/`:1224` save them as entered. Other start
 * months open on the 1st of that month and close the day before the same month a year later. Explicit dates
 * win, but must be real days with the closing date after the opening date.
 *
 * Shared by the API writer (`masters/year.ts`) and the Year Create screen's preview, so the date an operator
 * is shown is the date that is stored.
 */
export interface FiscalYearInput {
  coYear: string;
  opDate?: string | null;
  clDate?: string | null;
  yearMonth?: string | null;
}

export type FiscalYearDates =
  | { opDate: string; clDate: string; yearMonth: string; error?: undefined }
  | { error: string; opDate?: undefined; clDate?: undefined; yearMonth?: undefined };

const ISO_DATE = /^\d{4}-\d{2}-\d{2}$/;

/** True for a real calendar day in `yyyy-mm-dd` form (rejects 2026-02-30). */
export function isIsoDay(value: string): boolean {
  if (!ISO_DATE.test(value)) return false;
  const date = new Date(`${value}T00:00:00Z`);
  return !Number.isNaN(date.getTime()) && date.toISOString().slice(0, 10) === value;
}

export function fiscalYearDates(input: FiscalYearInput): FiscalYearDates {
  const coYear = String(input.coYear ?? '').trim();
  if (!coYear) return { error: 'year code is required' };
  const code = /^(\d{4})-(\d{4})$/.exec(coYear);
  if (code && Number(code[2]) !== Number(code[1]) + 1)
    return { error: `year code ${coYear} must span consecutive years, e.g. 2026-2027` };
  const monthText = String(input.yearMonth ?? '').trim() || '4';
  const month = /^\d{1,2}$/.test(monthText) ? Number(monthText) : NaN;
  if (!Number.isInteger(month) || month < 1 || month > 12)
    return { error: 'start month must be 1 to 12' };
  const yearMonth = String(month).padStart(2, '0');

  let opDate = String(input.opDate ?? '').trim();
  if (!opDate) {
    if (!code)
      return {
        error: `year code ${coYear} is not yyyy-yyyy (e.g. 2026-2027); enter the opening date`,
      };
    opDate = `${code[1]}-${yearMonth}-01`;
  }
  if (!isIsoDay(opDate)) return { error: `opening date ${opDate} is not a valid date` };

  let clDate = String(input.clDate ?? '').trim();
  if (!clDate) {
    const opening = new Date(`${opDate}T00:00:00Z`);
    clDate = new Date(
      Date.UTC(opening.getUTCFullYear() + 1, opening.getUTCMonth(), opening.getUTCDate() - 1),
    )
      .toISOString()
      .slice(0, 10);
  }
  if (!isIsoDay(clDate)) return { error: `closing date ${clDate} is not a valid date` };
  if (clDate <= opDate)
    return { error: `closing date ${clDate} must be after opening date ${opDate}` };
  return { opDate, clDate, yearMonth };
}
