/**
 * Dates (N56, decision D19, gap G36).
 *
 * The API carries dates as `YYYY-MM-DD`; screens and printed documents show `dd/MM/yyyy`, the desktop display format
 * (847 `dd/MM/yyyy` literals in the desktop source). `String(date).slice(0, 10)` turned a JavaScript `Date` into
 * "Thu Oct 01", so the printed tax invoice showed no year.
 */
const ISO_DATE = /^(\d{4})-(\d{2})-(\d{2})$/;
const ISO_TIMESTAMP = /^(\d{4})-(\d{2})-(\d{2})[T ]\d{2}:/; // also a timestamp column read as text

const pad = (n: number, width = 2): string => String(n).padStart(width, '0');

function realDate(year: number, month: number, day: number): boolean {
  const date = new Date(Date.UTC(year, month - 1, day));
  return (
    date.getUTCFullYear() === year && date.getUTCMonth() === month - 1 && date.getUTCDate() === day
  );
}

/**
 * `YYYY-MM-DD`, or '' for an empty value. A `Date` read from a date column (`@db.Date`) is midnight UTC, so its UTC
 * parts are the stored day. A string must be a real calendar date or an ISO timestamp; a timestamp keeps the calendar
 * day written in it, with no time-zone shift (2026-10-01T23:30:00+05:30 is 1 October). Anything else throws.
 */
export function toIsoDate(value: unknown): string {
  if (value == null || value === '') return '';
  if (value instanceof Date) {
    if (Number.isNaN(value.getTime())) throw new RangeError('invalid date');
    return `${pad(value.getUTCFullYear(), 4)}-${pad(value.getUTCMonth() + 1)}-${pad(value.getUTCDate())}`;
  }
  const text = String(value).trim();
  const match = ISO_DATE.exec(text) ?? ISO_TIMESTAMP.exec(text);
  if (!match) throw new RangeError(`not a date: ${text.slice(0, 40)}`);
  const [year, month, day] = [Number(match[1]), Number(match[2]), Number(match[3])];
  if (!realDate(year, month, day))
    throw new RangeError(`not a calendar date: ${text.slice(0, 40)}`);
  return `${match[1]}-${match[2]}-${match[3]}`;
}

/** `dd/MM/yyyy` for screens and printed documents, or '' for an empty value. */
export function formatDesktopDate(value: unknown): string {
  const iso = toIsoDate(value);
  if (!iso) return '';
  const [year, month, day] = iso.split('-');
  return `${day}/${month}/${year}`;
}
