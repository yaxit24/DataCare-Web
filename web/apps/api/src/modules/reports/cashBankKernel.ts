/**
 * Cash Bank report kernel (desktop RP_CASH_BANK): pure paise arithmetic, no database import.
 * Amounts are converted to integer paise before any addition, so 0.10 + 0.20 is exactly 0.30.
 */

export type CashBankSide = 'Cr' | 'Dr' | '';

export interface CashBankLine {
  vchNo: string;
  vchDate: string;
  book: string;
  coBook: string;
  mainBook: string;
  party: string;
  area: string;
  /** Signed net of the group, Cr positive (SUM(CR_AMT - DR_AMT)), in rupees as read from the database. */
  net: number;
}

export interface CashBankRow {
  kind: 'opening' | 'detail';
  sr: number;
  book: string;
  vchNo: string;
  vchDate: string;
  party: string;
  area: string;
  drAmt: number;
  crAmt: number;
  balAmt: number;
  side: CashBankSide;
  coBook: string | null;
  mainBook: string | null;
}

export interface CashBankTotals {
  drAmt: number;
  crAmt: number;
  balAmt: number;
  side: CashBankSide;
}

/** Rupees to integer paise. */
export const toPaise = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? Math.round(n * 100) : 0;
};
/** Integer paise to rupees with two decimals. */
export const fromPaise = (p: number): number => p / 100;

/** Dr is the negative net, Cr the positive net, as the desktop's `Case When SUM(CR-DR) < 0 Then abs(...)`. */
export function splitNet(netPaise: number): { dr: number; cr: number } {
  if (netPaise < 0) return { dr: -netPaise, cr: 0 };
  if (netPaise > 0) return { dr: 0, cr: netPaise };
  return { dr: 0, cr: 0 };
}

/** Side from Cr minus Dr: Cr when positive, Dr when negative, empty at zero. */
export function sideOfPaise(crMinusDr: number): CashBankSide {
  if (crMinusDr > 0) return 'Cr';
  if (crMinusDr < 0) return 'Dr';
  return '';
}

export function buildCashBank(
  openingNet: unknown,
  lines: CashBankLine[],
): { rows: CashBankRow[]; totals: CashBankTotals | null } {
  const rows: CashBankRow[] = [];
  const open = splitNet(toPaise(openingNet));
  // RP_CASH_BANK.cs:3222 {{Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0}}
  // The running sums start at the opening (RP_CASH_BANK.cs:3229) so the totals include it.
  let dr = open.dr;
  let cr = open.cr;
  const balanceOf = (): { bal: number; side: CashBankSide } => ({
    // RP_CASH_BANK.cs:3296 {{((DataGridView)dGV_DETL2)[8, num7].Value = Math.Abs(num2 - num);}}
    bal: Math.abs(cr - dr),
    // RP_CASH_BANK.cs:3297 {{if (num2 - num > 0.0)}}
    side: sideOfPaise(cr - dr),
  });
  if (open.dr + open.cr !== 0) {
    const { bal, side } = balanceOf();
    rows.push({
      kind: 'opening',
      sr: 1,
      book: 'Op Balance',
      vchNo: '',
      vchDate: '',
      party: '',
      area: '',
      drAmt: fromPaise(open.dr),
      crAmt: fromPaise(open.cr),
      balAmt: fromPaise(bal),
      side,
      coBook: null,
      mainBook: null,
    });
  }
  for (const line of lines) {
    const part = splitNet(toPaise(line.net));
    dr += part.dr;
    cr += part.cr;
    const { bal, side } = balanceOf();
    rows.push({
      kind: 'detail',
      sr: rows.length + 1,
      book: line.book,
      vchNo: line.vchNo,
      vchDate: line.vchDate,
      party: line.party,
      area: line.area,
      drAmt: fromPaise(part.dr),
      crAmt: fromPaise(part.cr),
      balAmt: fromPaise(bal),
      side,
      coBook: line.coBook,
      mainBook: line.mainBook,
    });
  }
  if (rows.length === 0) return { rows, totals: null };
  // RP_CASH_BANK.cs:3322 {{Rows[num9].Cells[6].Value = num;}} (Dr and Cr totals are the running sums, opening included)
  const { bal, side } = balanceOf();
  return {
    rows,
    totals: { drAmt: fromPaise(dr), crAmt: fromPaise(cr), balAmt: fromPaise(bal), side },
  };
}
