export type CanonicalReportForm = `Reports/${string}`;

/**
 * Authorization source of truth for slug-selected report routes.
 *
 * Every key is implemented by REPORT_BUILDERS and every value is a canonical form-catalog key.
 * Unknown values deliberately return no form so central route authorization fails closed before a
 * report handler, builder, renderer, or Prisma query can run.
 */
export const REPORT_FORM_BY_SLUG = Object.freeze({
  'last-visit': 'Reports/Last Visit',
  'address-print': 'Reports/Address Print',
  'entry-check': 'Reports/Entry Check',
  'user-report': 'Reports/User Report',
  'dhiran-report': 'Reports/Dhiran Report',
  'loan-report': 'Reports/Loan Report',
  'gst-report': 'Reports/GST Report',
  'delete-data': 'Reports/Delete Data',
  'point-report': 'Reports/Point Report',
  'approval-report': 'Reports/Approval Report',
  'vp-report': 'Reports/VP Report',
  'bullion-report': 'Reports/Bullion Report',
  'karigar-report': 'Reports/Karigar Report',
  'repair-report': 'Reports/Repair Report',
  huid: 'Reports/HuId Report',
  'item-weight-levels': 'Reports/ItStk Level',
  'bill-profit': 'Reports/Bill Wise Profit',
  'physical-stock-verify': 'Reports/Physical Stock',
  'size-movement': 'Reports/Movement',
  'branch-inout': 'Reports/Branch InOut',
  'other-item-report': 'Reports/Other Item Report',
  'design-move': 'Reports/Design Move',
  'consi-report': 'Reports/Consi Report',
  'old-stock': 'Reports/Old Stock',
  'trading-report': 'Reports/Trading Report',
  'tour-report': 'Reports/Tour Report',
  'tour-tag': 'Reports/Tour Tag',
  'order-track': 'Reports/Order Track',
  'graph-report': 'Reports/Graph Report',
  'profit-loss': 'Reports/Final Reports',
  'final-reports': 'Reports/Final Reports',
  'mfg-inout': 'Reports/Mfg InOut',
  'mfg-lot-isurec': 'Reports/Mfg Lot IsuRec',
  'mfg-ledger': 'Reports/Mfg Ledger',
  'tag-estimate': 'Reports/Tag Estimate',
  'order-lot-zoom': 'Reports/Order Zoom',
  'account-balances': 'Reports/Account Balances',
  'area-outstanding': 'Reports/Area-wise Outstanding',
  'area-wise-sales': 'Reports/Area-wise Sales',
  'bill-aging': 'Reports/Bill Aging',
  'bill-outstanding': 'Reports/Bill-wise Outstanding',
  'cash-book': 'Reports/Cash / Bank Book',
  'cash-day-summary': 'Reports/Cash Day Summary',
  'contra-register': 'Reports/Contra Register',
  'customer-crm': 'Reports/Customer CRM',
  'daily-sales': 'Reports/Daily Sales Summary',
  'day-book': 'Reports/Day Book',
  'dhrn-outstanding': 'Reports/Pledge Outstanding',
  rojmel: 'Reports/Rojmel',
  'employee-sales': 'Reports/Employee Sales',
  'group-summary': 'Reports/Group Trial Balance',
  'gst-input-register': 'Reports/GST Input Register',
  gstr2: 'Reports/GSTR-2 (Purchase)',
  gstr3b: 'Reports/GSTR-3B',
  'hsn-summary': 'Reports/HSN Tax Summary',
  'item-group-stock': 'Reports/Item-Group Stock',
  'item-stock-ledger': 'Reports/Item Stock Ledger',
  'scheme-monthly': 'Reports/Scheme Monthly Report',
  'karigar-balances': 'Reports/Karigar Balances',
  'karigar-statement': 'Reports/Karigar Statement',
  'location-wise-sales': 'Reports/Location-wise Sales',
  'monthly-purchase': 'Reports/Monthly Purchase',
  'monthly-sales': 'Reports/Monthly Sales',
  'old-gold-register': 'Reports/Old Gold / Exchange',
  outstanding: 'Reports/Outstanding (Debtors/Creditors)',
  'party-statement': 'Reports/Party Statement',
  'purchase-by-item': 'Reports/Purchase by Item',
  'purchase-by-party': 'Reports/Purchase by Party',
  'purchase-register': 'Reports/Purchase Register',
  'purchase-return-register': 'Reports/Purchase Return Register',
  'rate-list': 'Reports/Rate List',
  'sales-by-group': 'Reports/Sales by Group',
  'sales-by-item': 'Reports/Sales by Item',
  'sales-by-party': 'Reports/Sales by Party',
  'sales-gst-monthly': 'Reports/Sales GST (Monthly)',
  'sales-register': 'Reports/Sales Register',
  'sales-return-register': 'Reports/Sales Return Register',
  'scheme-adjustments': 'Reports/Scheme / Member Adjustments',
  'stock-by-location': 'Reports/Stock by Location',
  'stock-valuation': 'Reports/Stock Valuation',
  'top-items': 'Reports/Top Items',
  'trial-balance': 'Reports/Trial Balance',
  'trial-balance-full': 'Reports/Trial Balance (Full)',
} as const satisfies Readonly<Record<string, CanonicalReportForm>>);

export type ReportSlug = keyof typeof REPORT_FORM_BY_SLUG;

export const REPORT_SLUGS: readonly ReportSlug[] = Object.freeze(
  Object.keys(REPORT_FORM_BY_SLUG) as ReportSlug[],
);

export function isReportSlug(value: unknown): value is ReportSlug {
  return (
    typeof value === 'string' && Object.prototype.hasOwnProperty.call(REPORT_FORM_BY_SLUG, value)
  );
}

export function reportFormForSlug(value: unknown): CanonicalReportForm | undefined {
  return isReportSlug(value) ? REPORT_FORM_BY_SLUG[value] : undefined;
}
