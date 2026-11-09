import { decimalCellText, round } from './money.js';
import { vbVal } from './vbVal.js';

/**
 * TR_CASH totals row (Cash/Bank Received and Payment), shared by the screen and its tests.
 *
 * Desktop source: TR_CASH.cs `MSG_LeaveCell` 1962-1988 and `MSG_TOT_FILL` 1832-1859.
 * - Leaving an Amount (col 5), Charges (col 6) or Kasar (col 7) cell stores `Strings.Format(Val(text), "0.00")`
 *   (:1978-1982), so each cell is rounded half-up to two places before it is summed.
 * - The totals row writes "Total :" under Ac Name (:1846), Σ Amount as `Strings.Format(..., "0.00")` (:1852) and
 *   Σ Kasar as `Strings.Format(..., "0.000")` (:1853): three places, as the desktop prints it.
 * - `NewValTot` = Σ Amount + Σ Kasar (:1856) is what Esc compares with the loaded value to decide whether the form
 *   may close unasked (TR_CASH_KeyDown, :3235).
 * - Save skips a row with no account or with Amount + Kasar = 0 (:3002).
 */
export interface CashGridRow {
  account?: string;
  amount?: unknown;
  kasar?: unknown;
}

export interface CashGridTotals {
  /** Σ Amount, "0.00". */
  amount: string;
  /** Σ Kasar, "0.000". */
  kasar: string;
  /** Σ Amount + Σ Kasar (`NewValTot`). */
  value: number;
  /** Rows the save would write (account present, Amount + Kasar ≠ 0). */
  savedRows: number;
}

export function cashGridTotals(rows: readonly CashGridRow[]): CashGridTotals {
  let amount = 0;
  let kasar = 0;
  let savedRows = 0;
  for (const row of rows) {
    const a = round(vbVal(row.amount), 2);
    const k = round(vbVal(row.kasar), 2);
    amount = round(amount + a, 2);
    kasar = round(kasar + k, 2);
    if (String(row.account ?? '').trim() && a + k !== 0) savedRows += 1;
  }
  return {
    amount: decimalCellText(amount, 2),
    kasar: decimalCellText(kasar, 3),
    value: round(amount + kasar, 2),
    savedRows,
  };
}
