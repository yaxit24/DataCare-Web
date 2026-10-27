/**
 * The operator's calendar day as `yyyy-mm-dd`.
 *
 * `toISOString().slice(0, 10)` on the current time is the UTC day: between 00:00 and 05:30 in India it is still
 * yesterday, so a voucher opened after midnight defaulted to the previous date (found in the 2026-10-26 E2E run,
 * 02:07 IST, when new vouchers defaulted to 26 October). The desktop fills its date masks from the workstation's
 * local `DateAndTime.Today`. Use this for every "today" default.
 */
export function todayLocal(now: Date = new Date()): string {
  const pad = (value: number): string => String(value).padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}`;
}

/** The first day of the operator's current month as `yyyy-mm-dd`. */
export function monthStartLocal(now: Date = new Date()): string {
  return todayLocal(new Date(now.getFullYear(), now.getMonth(), 1));
}
