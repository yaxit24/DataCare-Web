import { dotNetRoundDouble, round } from '@datacare/core';

/**
 * What the sale writer takes from its linked old-gold (URD) purchases (owner decision 2B). Kept apart from
 * linkedOldPurchaseSale.ts, which imports the sale and purchase writers, so sales.ts can import it without a cycle.
 */
export interface LinkedOldPurchaseSummary {
  metal: 'G' | 'S';
  coBook: string;
  vchNo: string;
  /** PR_DATA.BILL_OS, or TOT_AMT when the purchase party is 00050 (TR_PURC.cs:13283-13312). */
  amount: number;
  /** Net weight total of the purchase lines (MSG_PR_TOT[0,15]). */
  netWt: number;
  created: boolean;
  version: string;
}

/** SL_DATA OLD_GL_AMT / OLD_GL and OLD_SL_AMT / OLD_SL from the stored purchases (TR_SALE.cs:15064-15065, :15090-15091). */
export interface LinkedOldMetal {
  goldAmt: number;
  goldWt: number;
  silverAmt: number;
  silverWt: number;
  purchases: LinkedOldPurchaseSummary[];
  /** CO_SET.ALL_ROF_REMOVE 'Y' → 2, else 0: the rounding of the 00045 cash (TR_SALE.cs:19125-19150). */
  cashDigits: 0 | 2;
}

/**
 * Runs inside the sale's transaction once the sale number is known (create) or after the header lock and version
 * check (edit). Returns undefined when the sale has no linked purchase.
 */
export type LinkedSaleHook = (
  tx: any,
  saleVoucherNo: string,
  isEdit: boolean,
) => Promise<LinkedOldMetal | undefined>;

/**
 * SL_DATA.CASH_AMT on a sale with linked old metal (TR_SALE.cs:15067-15084). A non-T book, or a T book with a
 * named party, stores the typed cash. A T book with the cash party 00045 stores the cash grossed up by the old
 * amounts, rounded to the rupee (.NET Math.Round, half to even), when the old amounts are below the cash; otherwise
 * the bill total less the order advance and kasar. Sales_Ledr's cash pair posts this CASH_AMT (Ac_Ledr.cs cash legs
 * `A.CASH_AMT <> 0`), so the party's credit covers the old metal the purchase books against 00050.
 */
export function linkedSaleCashAmount(p: {
  bookType: string;
  acCode: string;
  cashAmt: number;
  oldAmt: number;
  total: number;
  advance: number;
  kasar: number;
}): number {
  if (p.bookType !== 'T' || String(p.acCode).trim() !== '00045') return p.cashAmt;
  if (p.oldAmt < p.cashAmt) return dotNetRoundDouble(p.cashAmt + p.oldAmt, 0);
  return round(p.total - p.advance - p.kasar, 2);
}

/**
 * A T-book sale on the cash party 00045 with linked old metal: the desktop computes the cash itself
 * (TR_SALE.cs:19125-19150). Old above the bill: no cash, cash paid back = Round(old − TOT). Otherwise cash =
 * Round(TOT − old − advance − kasar − UPI) and nothing paid back. The web refuses any other figure, naming the
 * expected one, so the gross-up never amplifies a client error. Returns the refusal, or null.
 */
export function linkedCashPartyRefusal(p: {
  bookType: string;
  acCode: string;
  cashAmt: number;
  cashPaid: number;
  oldAmt: number;
  total: number;
  advance: number;
  kasar: number;
  upi: number;
  digits: 0 | 2;
}): string | null {
  if (p.bookType !== 'T' || String(p.acCode).trim() !== '00045') return null;
  const r = (v: number) => (p.digits === 2 ? round(v, 2) : dotNetRoundDouble(v, 0));
  const over = p.oldAmt > p.total;
  const cash = over ? 0 : r(p.total - p.oldAmt - p.advance - p.kasar - p.upi);
  const paid = over ? r(p.oldAmt - p.total) : 0;
  if (round(p.cashAmt, 2) === cash && round(p.cashPaid, 2) === paid) return null;
  return over
    ? `On a cash sale (00045) the old metal ${p.oldAmt.toFixed(2)} is above the bill ${p.total.toFixed(2)}: cash must be 0.00 and cash paid ${paid.toFixed(2)}`
    : `On a cash sale (00045) with old metal ${p.oldAmt.toFixed(2)} the cash must be ${cash.toFixed(2)} and cash paid 0.00`;
}
