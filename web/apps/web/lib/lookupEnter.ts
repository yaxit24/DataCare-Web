/**
 * What Enter does in a lookup box (G185).
 *
 * The desktop looks the typed code up exactly on Enter: `tAcCode_KeyDown` reads `AC_MAST WHERE AC_CODE = <typed>` and
 * fills the party, opening the help list only when nothing matches (`TR_PURC.cs:14619-14628`; `TR_SALE.cs` does the
 * same). The web list is fetched 180 ms after the last keystroke, so an operator (or a barcode scanner) who types a
 * code and presses Enter at once used to get the first row of the PREVIOUS list: in the 30 October browser run the
 * supplier `SUPL` became `BANK`. A list fetched for different text is never picked from.
 */
export type LookupEnterAction =
  /** The open list belongs to the typed text: pick the highlighted row (arrow keys move it). */
  | 'pick-highlighted'
  /** The list is for older text, or not there yet: look the typed code up exactly before picking anything. */
  | 'resolve-typed'
  /** Nothing typed and no list: let Enter do what it does in the form. */
  | 'none';

export function lookupEnterAction(state: {
  open: boolean;
  rowCount: number;
  /** The text the shown rows were fetched for; null before any list arrived. */
  rowsFor: string | null;
  value: string;
}): LookupEnterAction {
  const typed = state.value.trim();
  if (state.open && state.rowCount > 0 && state.rowsFor !== null && state.rowsFor === state.value)
    return 'pick-highlighted';
  return typed ? 'resolve-typed' : 'none';
}

/** The row whose code is exactly the typed text (case-insensitive, trimmed), as the desktop's `AC_CODE = ` lookup. */
export function exactCodeRow<T extends { code: unknown }>(
  rows: readonly T[],
  typed: string,
): T | undefined {
  const wanted = typed.trim().toUpperCase();
  if (!wanted) return undefined;
  return rows.find(
    (row) =>
      String(row.code ?? '')
        .trim()
        .toUpperCase() === wanted,
  );
}

/** A search answer that arrives after the operator typed more must not replace the list for the current text. */
export function isCurrentAnswer(requestedFor: string, currentValue: string): boolean {
  return requestedFor === currentValue;
}
