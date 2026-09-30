'use client';
import { WholesaleVoucherForm } from '../../../../components/WholesaleVoucherForm';

// WHOLESALE SALE — desktop "Wh Sales" (F6): TR_WH_SALE on a WH SALES book (book 034, BOOK_SNAME 'WSALE').
//
// The desktop opens the same form for Rate Cut (Ctrl+F6) on a RATE CUT book; the web shares the form
// (components/WholesaleVoucherForm.tsx) and gives each scope its own page, API resource and user right:
// this page lists only WH SALES books and posts to /wholesale-sales, which refuses any other book.
//
// It used to post /rate-cut — which now refuses a WH SALES book — and computed its own preview
// (net × (touch + west), making × net) that the server did not post. Every figure on the form is now the
// @datacare/core TR_WH_SALE arithmetic the API posts with.
export default function WholesaleSalePage() {
  return <WholesaleVoucherForm workflow="wholesale-sale" />;
}
