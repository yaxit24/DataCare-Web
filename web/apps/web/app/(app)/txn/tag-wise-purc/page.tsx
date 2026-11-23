'use client';
import HallmarkPurchasePage from '../purchase-hm/page';

/**
 * Tag Wise Purc (WP-28, D1, D3, D8): the desktop opens TR_PURC_HM on the TAG PURCHASE books whatever the
 * PURC_WITH_HMTAX setting (MDI_FORM.cs:8540-8544). The hallmark layout reads this address and lists TAG PURCHASE books
 * only, with the tag band shown. An Enterprise menu (docs/handbook/menu-editions.json), so the Lite menu does not
 * list it; the route stays for data an Enterprise desktop wrote.
 */
export default function TagWisePurchasePage() {
  return <HallmarkPurchasePage />;
}
