'use client';
import { WholesaleVoucherForm } from '../../../../components/WholesaleVoucherForm';

// RATE CUT — desktop "Rate Cut" (Ctrl+F6): TR_WH_SALE on a RATE CUT book (book 064, BOOK_SNAME 'RCUT').
// "Cutting the rate" fixes the price of a fine balance: the header rate and the Ac Amt / Ac Fine band settle
// metal against money (BILL_TOTAL), and all 25 real rate cuts on Live24 book 064 are header-only.
//
// Shares the Wholesale Sale form (components/WholesaleVoucherForm.tsx); this page lists only RATE CUT books and
// posts to /rate-cut, which refuses any other book. The settlement band is labelled as the desktop labels it:
// column "Payment" is PR_* (the API's receivedPay) and column "Received" is SL_* (pay) — the old page had the
// two the other way round.
export default function RateCutPage() {
  return <WholesaleVoucherForm workflow="rate-cut" />;
}
