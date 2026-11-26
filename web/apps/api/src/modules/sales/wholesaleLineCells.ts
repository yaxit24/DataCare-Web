import { DESKTOP_COLUMN_DEFAULTS } from '../posting/desktopColumnDefaults.js';

/**
 * Two TR_WH_SALE cells the wholesale / rate-cut writer (rateCut.ts) stores as the desktop does, kept here so that
 * file stays under its size ceiling.
 */

const isTagged = (tagNo: unknown): boolean => {
  const t = String(tagNo ?? '').trim();
  return t !== '' && t.toUpperCase() !== 'N';
};

/**
 * Col 47 KrNwt of a loose line: the GROSS weight less the rolled-up karigar stone weight, set whenever the gross
 * cell changes (TR_WH_SALE.cs:9194, :14085) and saved as KR_NET_WT (:13128). A net weight typed afterwards does not
 * move it (Next24M 034/7: net typed above gross, KR_NET_WT the gross). KR_FINE (col 52, saved at :13131) carries the
 * same figure on every captured row. A tag line keeps the earlier rule (the net weight) until its tag figures are
 * replayed.
 */
export function krNet(
  line: { krNetWt?: number; tagNo?: string; grossWt?: number },
  netWt: number,
): number {
  if (line.krNetWt != null) return line.krNetWt;
  if (isTagged(line.tagNo)) return netWt;
  return Math.round((Number(line.grossWt ?? 0) + Number.EPSILON) * 1000) / 1000;
}

/**
 * A line row as the table stores it: insertRowTx fills a null column the desktop never leaves NULL with its default
 * (posting.ts), and Wh_Sale_Stk's `INSERT … SELECT` copies the STORED cells (Ac_Stock.cs:153, :155), so the stock
 * row must see the same.
 */
export function asStored(table: string, row: Record<string, unknown>): Record<string, unknown> {
  const defaults = DESKTOP_COLUMN_DEFAULTS[table] ?? {};
  const out = { ...row };
  for (const [col, fallback] of Object.entries(defaults)) if (out[col] == null) out[col] = fallback;
  return out;
}
