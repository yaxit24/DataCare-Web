/**
 * The desktop date mask (DC_Main.cs:1641-1690): a typed dd/mm/yyyy is refused with "Date Not Valid..." for a day
 * above 31 and "Month Not Valid..." for a month above 12. The desktop's one-character substring check also lets
 * impossible calendar dates through (30/02, 31/04); the web refuses those too, with "Date Not Valid...".
 */
export type DateText = { iso: string } | { error: string };

export function parseDesktopDate(text: string): DateText {
  const m = /^\s*(\d{1,2})[/.-](\d{1,2})[/.-](\d{4})\s*$/.exec(text);
  if (!m) return { error: 'Date Not Valid...' };
  const day = Number(m[1]);
  const month = Number(m[2]);
  const year = Number(m[3]);
  if (day < 1 || day > 31) return { error: 'Date Not Valid...' };
  if (month < 1 || month > 12) return { error: 'Month Not Valid...' };
  const d = new Date(Date.UTC(year, month - 1, day));
  if (d.getUTCFullYear() !== year || d.getUTCMonth() !== month - 1 || d.getUTCDate() !== day)
    return { error: 'Date Not Valid...' };
  const p = (n: number) => String(n).padStart(2, '0');
  return { iso: `${year}-${p(month)}-${p(day)}` };
}

/** yyyy-mm-dd -> dd/mm/yyyy. */
export function isoToDesktop(iso: string): string {
  const m = /^(\d{4})-(\d{2})-(\d{2})$/.exec(iso);
  return m ? `${m[3]}/${m[2]}/${m[1]}` : '';
}
