/**
 * Carried openings in the one-database web (WP-23, decided 2026-11-22 by the architect, owner may override).
 *
 * The desktop keeps one database per year, so the next year's opening ledger rows are the only history of that
 * database. The web keeps every year in one database, and its readers come in two kinds:
 *   - year-scoped readers (`CO_YEAR = the year`: trial balance, account balances, balance sheet and outstanding when a
 *     year is selected, the voucher screens' party balance `desktopAccountBalance`) need the year's opening rows;
 *   - cross-year readers (the Account Ledger, `partyBalance`, the accounting ledger, the Wh Sales balance, the bank
 *     book, and the year-optional reports when no year is chosen) already sum the previous years' history.
 *
 * So a carried opening (written by Balance TrFr for parties and by Year-End Close for the other accounts, one writer
 * per account) is an AC_DATA leg in book '000' with BOOK_NAME 'BAL TRFR': year-scoped readers count it, cross-year
 * readers exclude it with `notCarriedOpening`. A hand-keyed opening (Party Opening, BOOK_NAME 'TR_AC_OPBL', or Account
 * Opening, 'OPENING') is real history and stays visible to both.
 */
export const CARRIED_OPENING_BOOK_NAME = 'BAL TRFR';

/** SQL: the row is not a carried opening leg. `alias` is a table alias (no quotes) or empty. */
export function notCarriedOpening(alias = ''): string {
  const a = alias ? `${alias}.` : '';
  return `NOT (coalesce(${a}"CO_BOOK"::text,'')='000' AND coalesce(${a}"BOOK_NAME"::text,'')='${CARRIED_OPENING_BOOK_NAME}')`;
}

/** ` AND <not carried>` for a reader that is not scoped to one year; empty for a year-scoped reader. */
export function carriedOpeningFilter(yearScoped: boolean, alias = ''): string {
  return yearScoped ? '' : ` AND ${notCarriedOpening(alias)}`;
}
