'use client';
import { WholesaleVoucherForm } from '../../../../components/WholesaleVoucherForm';

// TOUR SALES — desktop "Tour Sales" (MDI_FORM.cs:9321): TR_TOUR_SALE posts the SAME TR_WH_SALE engine
// (Ac_Ledr.Wh_Sales_Ledr / Wh_Sales_Rojmel / Wh_Sale_Stk over RATE_CUT_DATA, TR_TOUR_SALE.cs:11252),
// the only difference being the book — it opens on a TOUR SALES book. The web therefore reuses the shared
// wholesale-sale form (components/WholesaleVoucherForm.tsx) with the `tour-sale` workflow, which lists only
// TOUR SALES books and posts to /tour-sales (refuses any other book via the tour-sale book guard, N127).
export default function TourSalesPage() {
  return <WholesaleVoucherForm workflow="tour-sale" />;
}
