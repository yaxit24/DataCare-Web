/**
 * The desktop voucher number box (`tVchNo_KeyDown`, TR_SALE.cs:17068-17096, TR_PURC.cs:14407-14432):
 * F1 opens the voucher list (BtnF1_Click), Up steps to the next saved voucher (BtnLast_Click), Down to the previous
 * one (BtnFirst_Click), and Enter opens the typed number (DISPLAY_DATA). The walk itself runs on the server
 * (`GET /vouchers/neighbour`), so it sees every saved number of the book.
 */
export type VoucherNumberKey = 'list' | 'next' | 'previous' | 'open';

/** What `GET /vouchers/neighbour` answers (web/apps/api/src/modules/vouchers/list.ts). */
export type NeighbourVoucher =
  | { action: 'open'; vchNo: string }
  | { action: 'new' }
  | { action: 'last' }
  | { action: 'none' }
  | { action: 'missing'; vchNo: string };

/** The desktop's message when Up is pressed at the next new number (TR_SALE.cs:17197). */
export const LAST_RECORD_MESSAGE = 'Last Record...';

type KeyLike = { key: string; altKey?: boolean; ctrlKey?: boolean; metaKey?: boolean };

/** The voucher number box action for a key press, or null for every other key (typing stays untouched). */
export function voucherNumberKey(event: KeyLike): VoucherNumberKey | null {
  // Chords belong to the shell (Alt+S save, Ctrl+F1 and the other global keys in FormKeys).
  if (event.altKey || event.ctrlKey || event.metaKey) return null;
  switch (event.key) {
    case 'F1':
      return 'list';
    case 'ArrowUp':
      return 'next';
    case 'ArrowDown':
      return 'previous';
    case 'Enter':
      return 'open';
    default:
      return null;
  }
}

/** The request for one Up or Down step from the number in the box (empty = the new-entry state). */
export function neighbourPath(
  table: string,
  book: string,
  from: string,
  direction: 'next' | 'previous',
): string {
  const query = new URLSearchParams({ table, book, from: from.trim(), direction });
  return `/vouchers/neighbour?${query.toString()}`;
}
