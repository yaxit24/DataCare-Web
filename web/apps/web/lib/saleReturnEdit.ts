/**
 * Sales Return "New return" form: reopen a saved return into the form and save it back as an edit (WP-27, N242,
 * G254; desktop TR_SALE_RTN in mode `E`, which reloads the stored rows and rewrites them under the same number).
 *
 * The API returns every stored input of a line (`GET /sales-returns/:vchNo`). The grid edits only some of them, so a
 * line keeps the rest in `saved` and the payload is the saved input overlaid with what the grid shows. That is what
 * makes "open, change nothing, save" rewrite identical rows.
 */
type Saved = Record<string, unknown>;

const text = (value: unknown): string => (value == null ? '' : String(value));

/** The grid's string cells for one saved line: `making` is the per-gram labour rate, as the grid enters it. */
export function savedLineCells(saved: Saved, cellKeys: readonly string[]): Record<string, string> {
  const cells: Record<string, string> = {};
  for (const key of cellKeys) cells[key] = text(saved[key]);
  cells.making = saved.labourType === 'per_gram' ? text(saved.labourRate) : '';
  return cells;
}

/**
 * The request line for an edited row: the saved input without the keys the grid owns, then the grid's values.
 * Labour: a `making` value is per-gram labour; without one, a saved non-per-gram labour (fixed, percentage, per
 * piece) is kept with its own fields.
 */
export function editedLinePayload(
  saved: Saved | undefined,
  gridValues: Saved,
  gridKeys: readonly string[],
): Saved {
  if (!saved) return gridValues;
  const kept: Saved = {};
  for (const [key, value] of Object.entries(saved))
    if (!gridKeys.includes(key) && key !== 'labourType' && key !== 'labourRate') kept[key] = value;
  const labour =
    'labourType' in gridValues
      ? {}
      : saved.labourType && saved.labourType !== 'per_gram'
        ? { labourType: saved.labourType, labourRate: saved.labourRate }
        : {};
  return { ...kept, ...labour, ...gridValues };
}

/** An edit keeps the stored BILL_NO (the bill box shows the padded original number, which is ISU_NO, not BILL_NO). */
export function billNoForSave(storedBillNo: string | undefined, typed: string): string | undefined {
  if (storedBillNo !== undefined) return storedBillNo;
  return typed.trim() || undefined;
}

const PRICE_KEYS = ['pcs', 'grossWt', 'netWt', 'touch', 'rate', 'ghtWt', 'westPct', 'otherWt'];
const FINE_KEYS = ['netWt', 'touch', 'ghtWt', 'westPct'];

/**
 * The reopened cells a grid edit invalidates: a changed weight, touch or rate re-prices the line (the desktop recomputes
 * column 20 from column 19, TR_SALE_RTN.cs:4955), and a changed weight, touch or wastage re-derives its fine.
 */
export function derivedCellsToClear(key: string): string[] {
  return [
    ...(PRICE_KEYS.includes(key) ? ['metalAmount'] : []),
    ...(FINE_KEYS.includes(key) ? ['fineWt'] : []),
  ];
}
