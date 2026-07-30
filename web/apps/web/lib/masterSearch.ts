/**
 * Master list search — the desktop's grid type-ahead.
 *
 * The desktop compares each rendered grid cell with
 *
 *     cell.Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower())
 *
 * (`MS_BOOKLIST.cs`, `tSearchText_TextChanged`), so matching is a **case-insensitive PREFIX** over any
 * visible column — not a substring and not fuzzy. Using `includes` instead would match a row whose code
 * merely contains the typed letters, which changes which record an operator lands on.
 *
 * The web master list previously had no search box at all: every apparent "filter" in the page was an
 * `Array.filter` call in the rendering code, so long masters had to be scanned by eye.
 */

/** True when any cell of `row` starts with `query`, case-insensitively. Empty query matches everything. */
export function rowMatchesSearch(
  row: Record<string, unknown>,
  query: string,
  columns?: readonly string[],
): boolean {
  const q = query.trim().toLowerCase();
  if (!q) return true;
  const keys = columns ?? Object.keys(row);
  for (const k of keys) {
    const v = row[k];
    if (v == null) continue; // a null cell has no text to match, as in the desktop grid
    if (String(v).toLowerCase().startsWith(q)) return true;
  }
  return false;
}

/** Filter rows with desktop prefix semantics, preserving order. */
export function filterMasterRows<T extends Record<string, unknown>>(
  rows: readonly T[],
  query: string,
  columns?: readonly string[],
): T[] {
  const q = query.trim();
  if (!q) return [...rows];
  return rows.filter((r) => rowMatchesSearch(r, q, columns));
}
