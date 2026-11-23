/**
 * `DC_Main.SetDate` (DC_Main.cs:1561-1683): what the desktop does when Enter is pressed in a masked `dd/MM/yyyy`
 * date box (`mFromDt`/`mToDt` in RP_GST.cs:3033-3063, and most other forms).
 *
 * The box holds the mask text: typed digits, with `_` where nothing was typed ("12/__/____"). `i` is the 1-based
 * position of the first `_` or space (scanned up to the next-to-last character), and the text is completed by it:
 *   i = 1  (empty)         → today's day and month, financial year
 *   i = 2  (one digit)     → refused SILENTLY: RongDate, no message, text unchanged (:1600-1604)
 *   i = 3..5 (day typed)   → day + today's month + financial year
 *   i = 6  (one month digit) → day + typed month when both month characters are present, else today's month
 *   i = 7..9 (month typed) → day + month + financial year
 *   i = 10 (full date)     → as typed: the year is NOT checked against the session year (:1634-1636)
 * The financial year is the session year's second calendar year for months 1-3 and its first otherwise (:1594-1598;
 * the ALTER_YEAR branch gives the same year for a "YYYY-YYYY" year code). The month used for that choice is the
 * typed one when i > 5, today's otherwise.
 *
 * Then the checks, each with an OK-only message box without caption, the text reset to the empty mask and selected
 * (:1638-1681):
 *   month 2 and the FIRST day character greater than "29" as a string  → "Date Not Valid..."
 *   month 4/6/9/11 and the first day character greater than "30"       → "Date Not Valid..."
 *   otherwise month > 12                                               → "Month Not Valid..."
 *   then day > 31                                                      → "Date Not Valid..."
 * The string comparisons are the desktop's own weakness: a single character compares greater than "29" only when it
 * is "3".."9", so 30/02 and 31/02 are refused but 29/02 in any year passes, and nothing is ever greater than "30"
 * as a single character except "4".."9" (a day already over 31). 31/04 therefore passes SetDate; the desktop then
 * fails converting it when the report runs. The final `Mid(text, 3, 2) > 12` test reads "/M" and cannot fire.
 */
export const DESKTOP_DATE_MASK = '__/__/____';

export type SetDateMessage = 'Date Not Valid...' | 'Month Not Valid...';

export type SetDateResult =
  | { ok: true; text: string }
  | { ok: false; silent: true; text: string }
  | { ok: false; silent: false; message: SetDateMessage; text: typeof DESKTOP_DATE_MASK };

const pad2 = (n: number): string => String(n).padStart(2, '0');

/** VB `Conversion.Val` of a short digit string: leading digits, blank → 0. */
const val = (text: string): number => {
  const match = /^\s*(\d+)/.exec(text);
  return match ? Number(match[1]) : 0;
};

/** VB `Mid(text, start, length)` with a 1-based start. */
const mid = (text: string, start: number, length: number): string =>
  text.substring(start - 1, start - 1 + length);

/** Ordinal string comparison, as `Operators.CompareString(a, b, false)` (binary compare). */
const compare = (a: string, b: string): number => (a < b ? -1 : a > b ? 1 : 0);

/** The mask text for a sequence of typed digits: "3102" → "31/02/____". */
export function desktopDateMaskText(digits: string): string {
  const typed = digits.replace(/\D/g, '').slice(0, 8);
  let out = '';
  let index = 0;
  for (const slot of DESKTOP_DATE_MASK) {
    if (slot === '/') out += '/';
    else out += typed[index++] ?? '_';
  }
  return out;
}

export function desktopSetDate(
  maskText: string,
  context: { coYear: string; today: { day: number; month: number } },
): SetDateResult {
  const text = maskText;
  const todayText = `${pad2(context.today.day)}/${pad2(context.today.month)}/0000`;
  let i = 1;
  while (i <= text.length - 1 && mid(text, i, 1) !== '_' && mid(text, i, 1) !== ' ') i++;
  const year = /^(\d{4})-(\d{4})$/.exec(context.coYear);
  const first = year?.[1] ?? '';
  const second = year?.[2] ?? '';
  const monthForYear = i > 5 ? val(mid(text, 4, 2)) : val(mid(todayText, 4, 2));
  const fnYear = monthForYear < 4 ? second : first;
  if (i === 2) return { ok: false, silent: true, text };
  let completed = text;
  switch (i) {
    case 1:
      completed = `${pad2(context.today.day)}/${pad2(context.today.month)}/${fnYear}`;
      break;
    case 3:
    case 4:
    case 5:
      completed = `${mid(text, 1, 2)}/${mid(todayText, 4, 2)}/${fnYear}`;
      break;
    case 6: {
      const month =
        mid(text, 4, 2) === '  ' || mid(text, 5, 1) === ' '
          ? mid(todayText, 4, 2)
          : mid(text, 4, 2);
      completed = `${mid(text, 1, 2)}/${month}/${fnYear}`;
      break;
    }
    case 7:
    case 8:
    case 9:
      completed = `${mid(text, 1, 2)}/${mid(text, 4, 2)}/${fnYear}`;
      break;
    case 10:
      completed = `${mid(text, 1, 2)}/${mid(text, 4, 2)}/${mid(text, 7, 10)}`;
      break;
  }
  const refuse = (message: SetDateMessage): SetDateResult => ({
    ok: false,
    silent: false,
    message,
    text: DESKTOP_DATE_MASK,
  });
  const month = val(mid(completed, 4, 2));
  const dayFirst = mid(completed, 1, 1);
  if (month === 2) {
    if (compare(dayFirst, '29') > 0) return refuse('Date Not Valid...');
  } else if (month === 4 || month === 6 || month === 9 || month === 11) {
    if (compare(dayFirst, '30') > 0) return refuse('Date Not Valid...');
  } else if (month > 12) {
    return refuse('Month Not Valid...');
  }
  if (val(mid(completed, 1, 2)) > 31) return refuse('Date Not Valid...');
  if (val(mid(completed, 3, 2)) > 12) return refuse('Month Not Valid...');
  return { ok: true, text: completed };
}
