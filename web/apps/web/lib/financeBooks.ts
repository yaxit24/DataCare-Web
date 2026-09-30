/**
 * The `BOOK_DATA.MAIN_BOOK` values a cash/bank receipt or payment may use for a given mode.
 *
 * On the desktop each menu fixes the family before the form opens (MDI_FORM.cs:8052-8099):
 * Cash Received → CASH REC, Bank Received → BANK REC, Cash Payment → CASH PAY, Bank Payment → BANK PAY.
 * `RECEIPT` and `PAYMENT` are the generic books that web provisioning creates, and they accept every
 * mode.
 *
 * This must stay in step with `FINANCE_BOOK_FAMILIES` in apps/api/src/modules/finance/finance.ts,
 * which enforces the same pairing on save. test/financeBooks.test.ts pins both tables to the D1
 * contract in parity-plan-2026-09-10/evidence/implementation-2026-09-29-eval-defects/contract.md.
 */
export type FinanceKind = 'receipt' | 'payment';

export function financeMainBooks(kind: FinanceKind, mode: string): string[] {
  const cash = String(mode || 'cash').toLowerCase() === 'cash';
  if (kind === 'receipt') return cash ? ['CASH REC', 'RECEIPT'] : ['BANK REC', 'RECEIPT'];
  return cash ? ['CASH PAY', 'PAYMENT'] : ['BANK PAY', 'PAYMENT'];
}

/** Ctrl+F8 / Ctrl+F9 open `?mode=BANK`, the web's "Bank Received" / "Bank Payment" menu entries. */
export function initialFinanceMode(search: string): 'cash' | 'bank' {
  const mode = new URLSearchParams(search).get('mode');
  return mode && mode.trim().toLowerCase() === 'bank' ? 'bank' : 'cash';
}
