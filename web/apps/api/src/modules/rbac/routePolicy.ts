import { reportFormForSlug } from '../reports/reportAuthorization.js';
import { getFormEntry } from './formCatalog.js';

export type RouteAction = 'read' | 'create' | 'update' | 'delete' | 'print';
export type RoutePolicyKind = 'public' | 'system' | 'form';
export type DynamicPolicyForm = '@master' | '@report';

export interface RoutePolicy {
  kind: RoutePolicyKind;
  action?: RouteAction;
  form?: string | DynamicPolicyForm;
  adminOnly?: boolean;
  /** Whether request company/location/year/book fields must match or validate against the session. */
  businessScope?: boolean;
}

const PUBLIC = new Set([
  'GET /health',
  'GET /ready',
  // Development-only visual test harness registered by server.ts when NODE_ENV !== 'production'.
  // The onRoute hook fails closed on any unmapped route, so without this entry the API cannot boot
  // outside production at all.
  'GET /',
  'POST /auth/login',
  // Refresh/logout must remain callable after an access token expires. Their handlers validate and
  // rotate/revoke the refresh session directly.
  'POST /auth/refresh',
  'POST /auth/logout',
]);

const SYSTEM = new Set([
  'GET /me',
  'POST /auth/password/change',
  'GET /context/companies',
  'GET /context/locations',
  'GET /context/years',
  'GET /context/books',
  'POST /context/select',
  'GET /lookup/:entity',
  'GET /rate',
  'GET /rate-groups',
  'GET /party/:acCode/balance',
  'GET /vouchers/recent',
  'POST /render/pdf',
  'GET /integrations/barcode',
  'GET /integrations/qr',
]);

export const MASTER_FORM_BY_NAME: Readonly<Record<string, string>> = {
  accounts: 'Masters/Accounts',
  customers: 'Masters/Customers',
  items: 'Masters/Items',
  rates: 'Masters/Metal Rates',
  taxes: 'Masters/Taxes',
  groups: 'Masters/Item Groups',
  employees: 'Masters/Employees',
  books: 'Masters/Books / Series',
  products: 'Masters/Products',
  locations: 'Masters/Locations',
  designs: 'Masters/Designs',
  // MS_STYLE's third mode (CurMast='Item City') shares the Designs rights row in the desktop menu.
  'item-cities': 'Masters/Item Cities',
  diamonds: 'Masters/Diamonds',
  models: 'Masters/Models',
  states: 'Masters/States',
  points: 'Masters/Loyalty Points',
  labour: 'Masters/Labour Types',
  touch: 'Masters/Touch / Purity',
  messages: 'Masters/Message Templates',
  conversions: 'Masters/Conversions',
  mfg: 'Masters/Manufacturing',
  companies: 'Masters/Companies',
  years: 'Masters/Financial Years',
  addresses: 'Masters/Addresses',
  'gold-rate': 'Masters/Live Gold Rate Cfg',
  schemes: 'Masters/Schemes',
  counters: 'Masters/Counters',
  'item-weights': 'Masters/Item Weight Slabs',
  styles: 'Masters/Styles / Columns',
  'print-formats': 'Masters/Print Formats',
  'einvoice-gsp': 'Masters/e-Invoice GSP Config',
  'franchise-accounts': 'Masters/Franchise Accounts',
  'ac-groups': 'Masters/Account Group',
  trade: 'Masters/Trade Master',
};

const formRoutes = new Map<string, string>();
const route = (form: string, paths: readonly string[]): void => {
  if (!getFormEntry(form)) throw new Error(`route policy references unknown form: ${form}`);
  for (const path of paths) {
    if (formRoutes.has(path)) throw new Error(`duplicate form route policy: ${path}`);
    formRoutes.set(path, form);
  }
};

route('Utilities/Audit Log', ['GET /audit', 'GET /ops/metrics', 'GET /ops/invariants']);
route('Utilities/Backup', ['GET /backup', 'POST /backup/restore']);
route('Utilities/Users & Rights', [
  'GET /admin/users',
  'POST /admin/users',
  'POST /admin/users/:loginName/rights',
  'GET /admin/form-catalog',
  'GET /admin/users/:loginName/form-rights',
  'POST /admin/users/:loginName/form-rights',
  'POST /admin/users/:loginName/password-reset',
]);
route('Utilities/Provision Company', ['POST /admin/companies/:coCode/provision']);
route('Utilities/Voucher Renumber', [
  'GET /utilities/vch-renumber/preview',
  'POST /utilities/vch-renumber/apply',
]);
route('Utilities/Data Refresh', ['POST /utilities/data-refresh']);
// Desktop MS_UPDATE maintenance console. Preview and apply rewrite historical data, so the whole console is
// admin-only in the registry rather than by handler comment, and the actions are classified for what they do:
// preview reads, apply deletes/rewrites. See SCOPED_ADMIN_ONLY — unlike the other admin routes these must
// still validate the requested company/location/year against the session.
route('Utilities/Data Repair', [
  'GET /utilities/data-repair/operations',
  'POST /utilities/data-repair/:id/preview',
  'POST /utilities/data-repair/:id/apply',
  'GET /utilities/data-repair/runs',
]);
route('Utilities/Data Export', [
  'GET /utilities/data-export/preview',
  'GET /utilities/data-export/download',
  'POST /utilities/data-export/mark-exported',
  'POST /utilities/data-export/reset-flags',
]);
route('Utilities/Estimate Reset', [
  'POST /utilities/estimate-reset/preview',
  'POST /utilities/estimate-reset/apply',
]);
route('Utilities/Settings', [
  'GET /settings',
  'POST /settings',
  'GET /integrations/device-settings',
  'POST /integrations/scale-reading',
  'GET /integrations/readiness',
  'POST /integrations/verify-credentials',
]);
route('Utilities/Integrations & Rates', [
  'GET /integrations/live-rates',
  'POST /integrations/notify',
  'GET /integrations/status',
]);
route('Utilities/e-Invoice (IRN)', [
  'GET /einvoice/export.xlsx',
  'POST /einvoice/:vchNo',
  'POST /einvoice/irn',
  'GET /einvoice/gsp-config',
  'POST /einvoice/gsp-test',
  'POST /einvoice/:vchNo/cancel',
]);
route('Utilities/Year-End Close', ['POST /year-end/preview', 'POST /year-end/close']);
route('Company/Balance TrFr', [
  'POST /balance-transfer/preview',
  'POST /balance-transfer/year-close',
  'POST /balance-transfer/openings',
]);
route('Utilities/Reminders', [
  'GET /reminders/overdue',
  'GET /reminders/birthdays',
  'POST /reminders/send',
]);
route('Utilities/Reminder Entry', [
  'GET /reminder-entries',
  'POST /reminder-entries',
  'DELETE /reminder-entries/:vchNo',
]);
route('Utilities/HDD Registry', [
  'GET /utilities/hdd-registry',
  'GET /utilities/hdd-registry/:refNo',
  'POST /utilities/hdd-registry',
  'PUT /utilities/hdd-registry/:refNo',
  'DELETE /utilities/hdd-registry/:refNo',
]);
route('Utilities/User Request', [
  'GET /utilities/user-requests',
  'GET /utilities/user-requests/:coBook/:vchNo',
  'POST /utilities/user-requests',
  'PUT /utilities/user-requests/:coBook/:vchNo',
  'DELETE /utilities/user-requests/:coBook/:vchNo',
]);
route('Utilities/Window Tiles', [
  'GET /utilities/window-tiles',
  'POST /utilities/window-tiles',
  'GET /utilities/window-tiles/:tileName',
]);

route('Sales/Sales Invoice', [
  'POST /sales',
  'GET /sales/:vchNo',
  'PUT /sales/:vchNo',
  'DELETE /sales/:vchNo',
  'GET /sales/invoice',
]);
route('Sales/Sales Quotation', [
  'POST /sales-quotations',
  'GET /sales-quotations/:vchNo',
  'PUT /sales-quotations/:vchNo',
  'DELETE /sales-quotations/:vchNo',
  'GET /sales-quotations/quotation',
]);
route('Sales/Estimate', ['POST /estimate', 'GET /sales/quotation']);
route('Sales/Sales Return', [
  'GET /sales-returns/incoming-recent',
  'GET /sales-returns/source-vouchers',
  'GET /sales-returns/source-items',
  'GET /sales-returns/incoming-calculation-configuration',
  'GET /sales-returns/:vchNo/incoming',
  'GET /sales-returns/:vchNo/incoming-replay-state',
  'POST /sales-returns/:vchNo/incoming-replay',
  'GET /sales-returns/:vchNo/incoming-bill-replay-state',
  'POST /sales-returns/:vchNo/incoming-bill-replay',
  'GET /sales-returns/:vchNo/incoming-labour-replay-state',
  'POST /sales-returns/:vchNo/incoming-labour-observation',
  'POST /sales-returns/:vchNo/incoming-labour-replay',
  'PUT /sales-returns/:vchNo/incoming-metadata',
  'POST /sales-returns',
  'GET /sales-returns/import',
  'GET /sales-returns/:vchNo',
  'DELETE /sales-returns/:vchNo',
  'GET /sales/credit-note',
]);
route('Sales/Sales Order', [
  'GET /sales-orders/configuration',
  'GET /sales-orders/designs',
  'GET /sales-orders/design-image',
  'PUT /sales-orders/:vchNo',
  'GET /sales-orders/:vchNo/image',
  'POST /sales-orders/:vchNo/image',
  'DELETE /sales-orders/:vchNo/image',
  'POST /sales-orders',
  'GET /sales-orders',
  'GET /sales-orders/:vchNo',
  'DELETE /sales-orders/:vchNo',
  'GET /sales/order-confirmation',
]);
route('Karigar/Tour Order', [
  'GET /tour-orders/:vchNo/image',
  'POST /tour-orders/:vchNo/image',
  'DELETE /tour-orders/:vchNo/image',
  'GET /tour-orders/configuration',
  'GET /tour-orders/confirmation',
  'POST /tour-orders',
  'GET /tour-orders',
  'GET /tour-orders/:vchNo',
  'PUT /tour-orders/:vchNo',
  'DELETE /tour-orders/:vchNo',
]);
route('Transaction/E CrntNote', [
  'GET /e-credit-notes',
  'GET /e-credit-notes/provider',
  'GET /e-credit-notes/entry-config',
  'GET /e-credit-notes/:vchNo',
  'GET /e-credit-notes/:vchNo/entry',
  'GET /e-credit-notes/:vchNo/print',
  'POST /e-credit-notes',
  'PUT /e-credit-notes/:vchNo',
  'DELETE /e-credit-notes/:vchNo',
  'POST /einvoice/credit-note/irn',
  'POST /e-credit-notes/:vchNo/irn/cancel',
]);
route('Transaction/E Invoice', [
  'GET /e-invoices',
  'GET /e-invoices/entry-config',
  'GET /e-invoices/tcs-basis',
  'GET /e-invoices/:vchNo',
  'GET /e-invoices/:vchNo/entry',
  'GET /e-invoices/:vchNo/print',
  'POST /e-invoices',
  'PUT /e-invoices/:vchNo',
  'DELETE /e-invoices/:vchNo',
  'POST /e-invoices/:vchNo/irn',
  'POST /e-invoices/:vchNo/irn/cancel',
]);
route('Sales/Order Cancel', [
  'POST /sales-orders/:vchNo/cancel-refund',
  'GET /sales-orders/:vchNo/adjustment',
]);
route('Sales/Labour Sale', [
  'POST /labour-invoice',
  'GET /labour-invoice/:vchNo',
  'DELETE /labour-invoice/:vchNo',
]);
route('Sales/Bullion Booking', ['POST /bullion/booking', 'DELETE /bullion/:vchNo']);
route('Sales/Bul Sales', [
  'POST /bullion-sales',
  'GET /bullion-sales/:vchNo',
  'PUT /bullion-sales/:vchNo',
  'DELETE /bullion-sales/:vchNo',
]);
route('Sales/Tour / Approval Sale', [
  'POST /tour/issue',
  'DELETE /tour/:vchNo',
  'GET /tour/:vchNo/lines',
  'POST /tour/:vchNo/bill',
]);
route('Sales/Approval Return', ['POST /tour/return', 'DELETE /tour/return/:vchNo']);
// Desktop menu "Wh Sales" opens TR_WH_SALE scoped to MAIN_BOOK 'WH SALES' (MDI_FORM.cs:8038-8046), under its
// own right; "Rate Cut" opens the same form scoped to 'RATE CUT' (:8110-8118). One right no longer grants both.
route('Sales/Wholesale Sale', [
  'POST /wholesale-sales',
  'GET /wholesale-sales/:vchNo',
  'PUT /wholesale-sales/:vchNo',
  'DELETE /wholesale-sales/:vchNo',
]);
route('Sales/Wholesale Sale Return', [
  'POST /sales/wholesale-sale-return',
  'GET /sales/wholesale-sale-return/:vchNo',
  'PUT /sales/wholesale-sale-return/:vchNo',
  'DELETE /sales/wholesale-sale-return/:vchNo',
]);
route('Sales/VP Parcel', [
  'POST /sales/vp-parcel',
  'GET /sales/vp-parcel/:vchNo',
  'PUT /sales/vp-parcel/:vchNo',
  'DELETE /sales/vp-parcel/:vchNo',
]);

route('Purchase/Purchase Invoice', [
  'POST /purchases',
  'GET /purchases/:vchNo',
  'PUT /purchases/:vchNo',
  'DELETE /purchases/:vchNo',
  'GET /purchases/invoice',
]);
route('Purchase/Consignment Purchase', [
  'GET /consignment-purchases/open-receipts',
  'POST /consignment-purchases',
  'GET /consignment-purchases/:vchNo',
  'PUT /consignment-purchases/:vchNo',
  'DELETE /consignment-purchases/:vchNo',
]);
route('Purchase/Purchase Quotation', [
  'POST /purchase-quotations',
  'GET /purchase-quotations/:vchNo',
  'PUT /purchase-quotations/:vchNo',
  'DELETE /purchase-quotations/:vchNo',
  'GET /purchase-quotations/quotation',
]);
route('Purchase/Other Purchase', ['POST /other-purchase', 'DELETE /other-purchase/:vchNo']);
route('Purchase/Other Income', [
  'POST /other-income',
  'GET /other-income/:vchNo',
  'PUT /other-income/:vchNo',
  'DELETE /other-income/:vchNo',
]);
route('Purchase/Other Commission / Expense Voucher', [
  'POST /other-commission',
  'GET /other-commission/:vchNo',
  'PUT /other-commission/:vchNo',
  'DELETE /other-commission/:vchNo',
]);
route('Purchase/Purchase Return', ['POST /purchase-returns', 'DELETE /purchase-returns/:vchNo']);
route('Purchase/Fine Settlement', ['POST /fine-sale', 'DELETE /fine-sale/:vchNo']);
route('ExtraTran/Old Item Sales', [
  'POST /old-item-sales',
  'GET /old-item-sales/:vchNo',
  'PUT /old-item-sales/:vchNo',
  'DELETE /old-item-sales/:vchNo',
]);
route('Transaction/Stock Out', [
  'POST /stock/out',
  'GET /stock/out/:vchNo',
  'PUT /stock/out/:vchNo',
  'DELETE /stock/out/:vchNo',
]);
route('Transaction/Stock In', [
  'POST /stock/in',
  'GET /stock/in/:vchNo',
  'PUT /stock/in/:vchNo',
  'DELETE /stock/in/:vchNo',
]);

route('Cash / Bank/Receipt', [
  'POST /receipts',
  'GET /receipts/:vchNo',
  'DELETE /receipts/:vchNo',
  'GET /finance/receipt-voucher',
]);
route('Cash / Bank/Multi-Party Receipt', [
  'POST /receipts/multi',
  'DELETE /receipts/multi/:vchNo',
  'POST /receipts/batch',
]);
route('Cash / Bank/Payment', [
  'POST /payments',
  'GET /payments/:vchNo',
  'DELETE /payments/:vchNo',
  'POST /payments/multi',
  'DELETE /payments/multi/:vchNo',
  'GET /finance/payment-voucher',
  'GET /finance/cheque-print',
]);
route('Cash / Bank/Contra', [
  'POST /contra',
  'GET /contra/:vchNo',
  'PUT /contra/:vchNo',
  'DELETE /contra/:vchNo',
]);
route('Cash / Bank/Journal Voucher', ['POST /journal', 'DELETE /journal/:vchNo']);
route('Cash / Bank/Account Opening Bal', ['POST /ac-opbl', 'DELETE /ac-opbl/:vchNo']);
route('Cash / Bank/Fine JV (metal transfer)', [
  'POST /fine-jv',
  'GET /fine-jv/:vchNo',
  'DELETE /fine-jv/:vchNo',
]);
route('Cash / Bank/Bill-to-Bill Settle', [
  'GET /bill-to-bill/open',
  'POST /bill-to-bill/settle',
  'DELETE /bill-to-bill/:vchNo',
]);
route('Cash / Bank/Bank Reconciliation', ['GET /bank-recon', 'POST /bank-recon/clear']);
route('Cash / Bank/Daily Rate', ['POST /daily-rate', 'GET /daily-rate', 'GET /daily-rate/dates']);
route('Cash / Bank/Reminders', ['GET /reminders']);
route('Cash / Bank/Rate Cut (price fixing)', [
  'POST /rate-cut',
  'GET /rate-cut/:vchNo',
  'PUT /rate-cut/:vchNo',
  'DELETE /rate-cut/:vchNo',
]);
route('Cash / Bank/Ledger Adjustment', ['POST /ledger-adjust', 'DELETE /ledger-adjust/:vchNo']);
route('Cash / Bank/Employee Salary JV', ['POST /employee-jv', 'DELETE /employee-jv/:vchNo']);

route('Inventory/Stock / Tags', ['POST /stock/tags', 'GET /stock/tags', 'GET /stock/on-hand']);
route('Inventory/Tag Opening', [
  'POST /stock/tag-opening',
  'GET /stock/tag-opening/:vchNo',
  'PUT /stock/tag-opening/:vchNo',
  'DELETE /stock/tag-opening/:vchNo',
]);
route('Masters/Design Book', [
  'GET /masters/design-book/calculation-config',
  'GET /masters/design-book/component-defaults',
  'GET /masters/design-book',
  'POST /masters/design-book',
  'PUT /masters/design-book',
  'DELETE /masters/design-book',
  'GET /masters/design-book/image',
  'GET /masters/design-book/image/state',
  'POST /masters/design-book/image',
  'DELETE /masters/design-book/image',
]);
route('Inventory/Tag Print', [
  'GET /stock/tag-print',
  'GET /stock/tag-print/label',
  'POST /stock/tag-print/stage',
  // Tag photographs belong to the same surface: the right that shows a tag governs its image.
  'GET /stock/tag-image',
  'GET /stock/tag-image/state',
  'GET /stock/tag-image/list',
  'POST /stock/tag-image',
  'DELETE /stock/tag-image',
]);
route('Inventory/Item Opening (non-tag)', [
  'POST /stock/item-opening',
  'GET /stock/item-opening/:vchNo',
  'PUT /stock/item-opening/:vchNo',
  'DELETE /stock/item-opening/:vchNo',
]);
route('Inventory/Lot Management', [
  'POST /stock/item-lot',
  'GET /stock/item-lot/:vchNo',
  'PUT /stock/item-lot/:vchNo',
  'DELETE /stock/item-lot/:vchNo',
]);
route('Inventory/Stock Adjust', ['POST /stock/adjust', 'DELETE /stock/adjust/:vchNo']);
route('Inventory/Tag Transfer', ['POST /stock/tag-transfer', 'DELETE /stock/tag-transfer/:vchNo']);
route('Inventory/Counter Transfer', [
  'POST /stock/counter-transfer',
  'DELETE /stock/counter-transfer/:vchNo',
]);
route('Inventory/Tag Cancel', ['POST /stock/tag-cancel', 'DELETE /stock/tag-cancel/:vchNo']);
route('Inventory/Tag Adjust', [
  'POST /stock/tag-adjust',
  'GET /stock/tag-adjust/:vchNo',
  'PUT /stock/tag-adjust/:vchNo',
  'DELETE /stock/tag-adjust/:vchNo',
]);
route('Inventory/Tag Weight Diff', [
  'POST /stock/tag-weight-diff',
  'DELETE /stock/tag-weight-diff/:vchNo',
]);
route('Inventory/Tag Split', ['POST /stock/tag-split', 'DELETE /stock/tag-split/:vchNo']);
route('Cash / Bank/Digital Gold Book', [
  'POST /finance/gold-book',
  'GET /finance/gold-book/:vchNo',
  'PUT /finance/gold-book/:vchNo',
  'DELETE /finance/gold-book/:vchNo',
]);
route('Cash / Bank/VP Adjustment', [
  'POST /finance/vp-adjustment',
  'GET /finance/vp-adjustment/:vchNo',
  'PUT /finance/vp-adjustment/:vchNo',
  'DELETE /finance/vp-adjustment/:vchNo',
]);
route('Cash / Bank/Location Amount Transfer', [
  'POST /finance/location-amount',
  'GET /finance/location-amount/:vchNo',
  'PUT /finance/location-amount/:vchNo',
  'DELETE /finance/location-amount/:vchNo',
]);

route('Inventory/Physical Stock', [
  'POST /stock/physical-stock',
  'GET /stock/physical-stock/:vchNo',
  'PUT /stock/physical-stock/:vchNo',
  'DELETE /stock/physical-stock/:vchNo',
  'POST /stock/physical-reconcile',
  'GET /stock/physical-list',
]);
route('Inventory/Stone/Dm-Cf', [
  'POST /stock/stone-dm-cf',
  'GET /stock/stone-dm-cf/source-list',
  'GET /stock/stone-dm-cf/:vchNo',
  'PUT /stock/stone-dm-cf/:vchNo',
  'DELETE /stock/stone-dm-cf/:vchNo',
]);
route('Inventory/Fine In / Out', ['POST /inout/fine', 'DELETE /inout/fine/:vchNo']);

route('Manufacturing/Repair Receipt', [
  'POST /repair-receipts',
  'GET /repair-receipts',
  'GET /repair-receipts/:vchNo',
  'GET /repair-receipts/:vchNo/print',
  'PUT /repair-receipts/:vchNo',
  'DELETE /repair-receipts/:vchNo',
  'POST /repair-karigar-issues',
  'GET /repair-karigar-issues',
  'GET /repair-karigar-issues/open-lines',
  'GET /repair-karigar-issues/:vchNo',
  'GET /repair-karigar-issues/:vchNo/print',
  'PUT /repair-karigar-issues/:vchNo',
  'DELETE /repair-karigar-issues/:vchNo',
  'POST /repair-karigar-receipts',
  'GET /repair-karigar-receipts',
  'GET /repair-karigar-receipts/open-lines',
  'GET /repair-karigar-receipts/:vchNo',
  'GET /repair-karigar-receipts/:vchNo/print',
  'PUT /repair-karigar-receipts/:vchNo',
  'DELETE /repair-karigar-receipts/:vchNo',
  'POST /repair-customer-issues',
  'GET /repair-customer-issues',
  'GET /repair-customer-issues/open-lines',
  'GET /repair-customer-issues/:vchNo',
  'GET /repair-customer-issues/:vchNo/print',
  'PUT /repair-customer-issues/:vchNo',
  'DELETE /repair-customer-issues/:vchNo',
  'GET /repair-images',
  'GET /repair-images/line',
  'GET /repair-images/state',
  'POST /repair-images',
  'DELETE /repair-images',
]);
route('Manufacturing/Karigar Issue', [
  'POST /karigar/issue',
  'GET /karigar/issue-voucher',
  'GET /karigar/issue/:vchNo',
  'PUT /karigar/issue/:vchNo',
  'DELETE /karigar/issue/:vchNo',
]);
route('Manufacturing/Karigar Receive', [
  'POST /karigar/receive',
  'GET /karigar/:ac/balance',
  'GET /karigar/receive/:vchNo',
  'PUT /karigar/receive/:vchNo',
  'DELETE /karigar/receive/:vchNo',
]);
route('Manufacturing/MFG Issue', [
  'POST /mfg/issue',
  'GET /mfg/issue/:vchNo',
  'PUT /mfg/issue/:vchNo',
  'DELETE /mfg/issue/:vchNo',
]);
route('Manufacturing/Setting Isu', [
  'GET /mfg/lot/issue/settings',
  'GET /mfg/lot/issue/list',
  'GET /mfg/lot/issue/sources',
  'GET /mfg/lot/issue/:vchNo',
]);
route('Manufacturing/Setting Rec', [
  'GET /mfg/lot/receive/settings',
  'GET /mfg/lot/receive/list',
  'GET /mfg/lot/receive/sources',
  'GET /mfg/lot/receive/:vchNo',
]);
route('Manufacturing/MFG Receive', [
  'POST /mfg/receive',
  'GET /mfg/receive/:vchNo',
  'PUT /mfg/receive/:vchNo',
  'DELETE /mfg/receive/:vchNo',
]);
route('Manufacturing/Order Issue', [
  'POST /mfg/order-issue',
  'GET /mfg/order-issue/:vchNo',
  'PUT /mfg/order-issue/:vchNo',
  'DELETE /mfg/order-issue/:vchNo',
]);
route('Manufacturing/Job-work Issue', [
  'POST /mfg/jobwork-issue',
  'GET /mfg/jobwork-issue/:vchNo',
  'PUT /mfg/jobwork-issue/:vchNo',
  'DELETE /mfg/jobwork-issue/:vchNo',
]);
route('Manufacturing/Job-work Receive', [
  'POST /mfg/jobwork-receive',
  'GET /mfg/jobwork-receive/:vchNo',
  'PUT /mfg/jobwork-receive/:vchNo',
  'DELETE /mfg/jobwork-receive/:vchNo',
]);
route('Manufacturing/Melting', [
  'POST /melting',
  'GET /melting/:vchNo',
  'PUT /melting/:vchNo',
  'DELETE /melting/:vchNo',
]);
// Shared desktop manufacturing reversal endpoint; conservative mapping requires MFG Issue rights.
route('Manufacturing/MFG Issue', ['DELETE /mfg/:vchNo']);

route('Loans (Dhrn)/Pledge Issue', [
  'POST /dhrn/issue',
  'GET /dhrn/issue-receipt',
  'GET /dhrn/:isuNo/outstanding',
]);
route('Loans (Dhrn)/Pledge Receipt', ['POST /dhrn/receipt', 'GET /dhrn/khata']);
route('Loans (Dhrn)/Interest Receipt', ['POST /dhrn/interest']);
route('Loans (Dhrn)/Loan Received', ['POST /loan/received']);
route('Loans (Dhrn)/Loan Issue', ['POST /loan/issue', 'GET /loan/:isuNo/outstanding']);

route('Membership/Members & Loyalty', ['POST /members', 'POST /members/points', 'GET /members']);
route('Membership/Saving Schemes', [
  'GET /scheme/passbook',
  'POST /scheme/enroll',
  'DELETE /scheme/enroll',
  'POST /scheme/installment',
  'GET /scheme/installment/:vchNo',
  'DELETE /scheme/installment/:vchNo',
  'POST /scheme/opening',
  'DELETE /scheme/opening/:vchNo',
  'POST /scheme/maturity',
  'GET /scheme/maturity/:vchNo',
  'DELETE /scheme/maturity/:vchNo',
]);
route('Membership/Gold Adjust', [
  'POST /scheme/gold-adjust',
  'GET /scheme/gold-adjust/:vchNo',
  'DELETE /scheme/gold-adjust/:vchNo',
]);

route('Masters/Auto Item', ['POST /masters/auto-item']);
route('Masters/Opening Balance', [
  'GET /accounts/:acCode/opening',
  'POST /accounts/:acCode/opening',
]);
route('Masters/Labour Update', ['GET /labour-update', 'POST /labour-update']);
route('Masters/Item Weight Slabs', ['GET /labour-slabs', 'POST /labour-slabs']);
route('Masters/Diamond Sizes', [
  'GET /masters/diamond-sizes',
  'POST /masters/diamond-sizes',
  'DELETE /masters/diamond-sizes',
]);
route('Masters/Item Stock Limits', [
  'GET /masters/item-stock-limits',
  'POST /masters/item-stock-limits',
  'DELETE /masters/item-stock-limits',
]);
route('Masters/Year Create', [
  'GET /years',
  'POST /years',
  'POST /years/:coYear/close',
  'POST /years/:coYear/reopen',
  'POST /years/carry-forward',
]);
route('Masters/Accounts', [
  'GET /party/:acCode/photo',
  'POST /party/:acCode/photo',
  'GET /party/:acCode/family',
]);

route('Reports/Sales Register', ['GET /reports/sales-register']);
route('Reports/Purchase Register', ['GET /reports/purchase-register']);
route('Reports/Day Book', ['GET /reports/day-book']);
route('Reports/Rojmel', ['GET /reports/rojmel']);
route('Reports/Final Reports', ['GET /reports/final-reports', 'GET /reports/profit-loss']);
route('Reports/Trial Balance', ['GET /reports/trial-balance', 'GET /reports/trial-balance-doc']);
route('Reports/Trial Balance (Full)', ['GET /reports/trial-balance-full']);
route('Reports/Balance Sheet', ['GET /reports/balance-sheet', 'GET /reports/balance-sheet-doc']);
route('Reports/Account Ledger', ['GET /reports/account-ledger/:acCode']);
route('Reports/Account Balances', ['GET /reports/account-balances']);
route('Reports/Outstanding (Debtors/Creditors)', ['GET /reports/outstanding']);
route('Reports/Bill-wise Outstanding', ['GET /reports/bill-outstanding']);
route('Reports/Cash / Bank Book', ['GET /reports/cash-book']);
route('Reports/Party Statement', ['GET /reports/party-statement']);
route('Reports/HSN Tax Summary', ['GET /reports/hsn-summary']);
route('Reports/Scheme / Member Adjustments', ['GET /reports/scheme-adjustments']);
route('Reports/Item Stock Ledger', ['GET /reports/item-stock-ledger']);
route('Reports/Monthly Purchase', ['GET /reports/monthly-purchase']);
route('Reports/Purchase by Party', ['GET /reports/purchase-by-party']);
route('Reports/Group Trial Balance', ['GET /reports/group-summary']);
route('Reports/GSTR-2 (Purchase)', ['GET /reports/gstr2', 'GET /reports/gstr2-doc']);
route('Reports/Sales Return Register', ['GET /reports/sales-return-register']);
route('Reports/Karigar Statement', ['GET /reports/karigar-statement']);
route('Reports/Karigar Ledger', [
  'GET /reports/karigar-ledger',
  'GET /reports/karigar-ledger.print',
]);
route('Reports/Rate List', ['GET /reports/rate-list']);
route('Reports/Daily Sales Summary', ['GET /reports/daily-sales']);
route('Reports/Top Items', ['GET /reports/top-items']);
route('Reports/Employee Sales', ['GET /reports/employee-sales']);
route('Reports/Purchase Return Register', ['GET /reports/purchase-return-register']);
route('Reports/Contra Register', ['GET /reports/contra-register']);
route('Reports/Area-wise Outstanding', ['GET /reports/area-outstanding']);
route('Reports/Item-Group Stock', ['GET /reports/item-group-stock']);
route('Reports/Sales GST (Monthly)', ['GET /reports/sales-gst-monthly']);
route('Reports/Bill Aging', ['GET /reports/bill-aging']);
route('Reports/Stock by Location', ['GET /reports/stock-by-location']);
route('Reports/Purchase by Item', ['GET /reports/purchase-by-item']);
route('Reports/Voucher Register', ['GET /reports/voucher-register']);
route('Reports/Sales by Group', ['GET /reports/sales-by-group']);
route('Reports/Cash Day Summary', ['GET /reports/cash-day-summary']);
route('Reports/Customer CRM', ['GET /reports/customer-crm']);
route('Reports/Area-wise Sales', ['GET /reports/area-wise-sales']);
route('Reports/Location-wise Sales', ['GET /reports/location-wise-sales']);
route('Reports/GST Input Register', ['GET /reports/gst-input-register']);
route('Reports/Pledge Outstanding', ['GET /reports/dhrn-outstanding']);
route('Reports/Karigar Balances', ['GET /reports/karigar-balances']);
route('Reports/Stock Valuation', ['GET /reports/stock-valuation']);
route('Reports/Tag-Stock Report', ['GET /reports/tag-stock', 'GET /reports/tag-stock.csv']);
route('Reports/HuId Report', ['GET /reports/huid']);
route('Reports/ItStk Level', ['GET /reports/item-weight-levels']);
route('Reports/Bill Wise Profit', ['GET /reports/bill-profit']);
route('Reports/Physical Stock', ['GET /reports/physical-stock-verify']);
route('Reports/Movement', ['GET /reports/size-movement']);
route('Reports/Tag Estimate', ['GET /reports/tag-estimate']);
route('Reports/Order Zoom', ['GET /reports/order-lot-zoom']);
route('Reports/Old Gold / Exchange', ['GET /reports/old-gold-register']);
route('Reports/Sales by Party', ['GET /reports/sales-by-party']);
route('Reports/Sales by Item', ['GET /reports/sales-by-item']);
route('Reports/Monthly Sales', ['GET /reports/monthly-sales']);
route('Reports/GSTR-1', ['GET /gst/gstr1', 'GET /reports/gstr1', 'GET /reports/gstr1-doc']);
route('Reports/GSTR-3B', ['GET /reports/gstr3b', 'GET /reports/gstr3b-doc']);
route('Reports/Report Layouts (Crystal)', [
  'GET /reports/layouts',
  'GET /reports/layout',
  'GET /reports/render',
]);
route('Reports/Form Layouts (Desktop)', ['GET /forms/layouts', 'GET /forms/layout']);
route('Reports/Last Visit', ['GET /reports/last-visit']);
route('Reports/Address Print', ['GET /reports/address-print']);
route('Reports/Entry Check', [
  'GET /reports/entry-check',
  'GET /reports/entry-check/detail',
  'POST /reports/entry-check/mark-checked',
]);
route('Reports/User Report', ['GET /reports/user-report']);
route('Reports/Dhiran Report', ['GET /reports/dhiran-report']);
route('Reports/Loan Report', ['GET /reports/loan-report']);
route('Reports/GST Report', ['GET /reports/gst-report']);
route('Reports/Delete Data', ['GET /reports/delete-data']);
route('Reports/Point Report', ['GET /reports/point-report', 'GET /reports/point-report/detail']);
route('Reports/Approval Report', ['GET /reports/approval-report']);
route('Reports/VP Report', ['GET /reports/vp-report']);
route('Reports/Bullion Report', ['GET /reports/bullion-report']);
route('Reports/Karigar Report', ['GET /reports/karigar-report']);
route('Reports/Repair Report', ['GET /reports/repair-report']);
route('Reports/Branch InOut', ['GET /reports/branch-inout']);
route('Reports/Other Item Report', ['GET /reports/other-item-report']);
route('Reports/Design Move', ['GET /reports/design-move', 'GET /reports/design-move/detail']);
route('Reports/Consi Report', ['GET /reports/consi-report', 'GET /reports/consi-report/detail']);
route('Reports/Old Stock', ['GET /reports/old-stock']);
route('Reports/Trading Report', ['GET /reports/trading-report']);
route('Reports/Tour Report', ['GET /reports/tour-report']);
route('Reports/Tour Tag', ['GET /reports/tour-tag']);
route('Reports/Order Track', ['GET /reports/order-track']);
route('Reports/Graph Report', ['GET /reports/graph-report']);
route('Reports/Mfg InOut', ['GET /reports/mfg-inout']);
route('Reports/Mfg Lot IsuRec', ['GET /reports/mfg-lot-isurec']);
route('Reports/Mfg Ledger', ['GET /reports/mfg-ledger', 'GET /reports/mfg-ledger/detail']);
route('Reports/Scheme Monthly Report', ['GET /reports/scheme-monthly']);

const PRINT_ROUTES = new Set([
  'GET /tour-orders/confirmation',
  'GET /sales/invoice',
  'GET /sales-quotations/quotation',
  'GET /purchases/invoice',
  'GET /purchase-quotations/quotation',
  'GET /karigar/issue-voucher',
  'GET /repair-receipts/:vchNo/print',
  'GET /repair-karigar-issues/:vchNo/print',
  'GET /repair-karigar-receipts/:vchNo/print',
  'GET /repair-customer-issues/:vchNo/print',
  'GET /sales/credit-note',
  'GET /sales/order-confirmation',
  'GET /sales/quotation',
  'GET /finance/receipt-voucher',
  'GET /finance/payment-voucher',
  'GET /finance/cheque-print',
  'GET /dhrn/issue-receipt',
  'GET /scheme/passbook',
  'GET /dhrn/khata',
  'GET /einvoice/export.xlsx',
  'POST /einvoice/credit-note/irn',
  'POST /e-credit-notes/:vchNo/irn/cancel',
  'GET /e-credit-notes/:vchNo/print',
  'POST /e-invoices/:vchNo/irn',
  'POST /e-invoices/:vchNo/irn/cancel',
  'GET /e-invoices/:vchNo/print',
  'GET /utilities/data-export/download',
  'GET /stock/tag-print/label',
  'POST /integrations/notify',
  'GET /reports/tag-stock.csv',
  'GET /reports/karigar-ledger.print',
  'GET /reports/gstr2-doc',
  'GET /reports/gstr1-doc',
  'GET /reports/gstr3b-doc',
  'GET /reports/trial-balance-doc',
  'GET /reports/balance-sheet-doc',
  'GET /reports/render',
]);

const UPDATE_POST_ROUTES = new Set([
  'POST /stock/tag-image',
  'POST /sales-orders/:vchNo/image',
  'POST /tour-orders/:vchNo/image',
  'POST /masters/design-book/image',
  'POST /repair-images',
  'POST /admin/users/:loginName/rights',
  'POST /admin/users/:loginName/form-rights',
  'POST /admin/users/:loginName/password-reset',
  'POST /backup/restore',
  'POST /utilities/vch-renumber/apply',
  'POST /utilities/data-refresh',
  'POST /utilities/data-export/mark-exported',
  'POST /utilities/data-export/reset-flags',
  'POST /settings',
  'POST /accounts/:acCode/opening',
  'POST /labour-update',
  'POST /labour-slabs',
  'POST /masters/diamond-sizes',
  'POST /masters/item-stock-limits',
  'POST /years/:coYear/close',
  'POST /years/:coYear/reopen',
  'POST /years/carry-forward',
  'POST /party/:acCode/photo',
  'POST /stock/physical-reconcile',
  'POST /bank-recon/clear',
  'POST /einvoice/:vchNo',
  'POST /einvoice/irn',
  'POST /einvoice/gsp-test',
  'POST /einvoice/:vchNo/cancel',
  'POST /year-end/close',
  'POST /balance-transfer/year-close',
  'POST /balance-transfer/openings',
  'POST /tour/:vchNo/bill',
  'POST /reports/entry-check/mark-checked',
]);

const READ_POST_ROUTES = new Set([
  'POST /sales-returns/:vchNo/incoming-labour-observation',
  'POST /sales-returns/:vchNo/incoming-labour-replay',
  'POST /sales-returns/:vchNo/incoming-bill-replay',
  'POST /sales-returns/:vchNo/incoming-replay',
  'POST /year-end/preview',
  'POST /balance-transfer/preview',
  'POST /utilities/estimate-reset/preview',
  // Reads only: the framework asserts a preview writes nothing, and the diff it returns is what the operator
  // reviews before any apply exists.
  'POST /utilities/data-repair/:id/preview',
]);

// A POST that removes or rewrites historical rows is a delete, not a create. Classifying it honestly means a
// delegated (non-admin) grant of this form could never apply a repair on View alone, which is what the
// previous `create` classification allowed.
const DELETE_POST_ROUTES = new Set([
  'POST /utilities/data-repair/:id/apply',
  'POST /utilities/estimate-reset/apply',
]);

const ADMIN_ONLY = new Set([
  'GET /audit',
  'GET /ops/metrics',
  'GET /ops/invariants',
  'GET /backup',
  'POST /backup/restore',
  'GET /admin/users',
  'POST /admin/users',
  'POST /admin/users/:loginName/rights',
  'GET /admin/form-catalog',
  'GET /admin/users/:loginName/form-rights',
  'POST /admin/users/:loginName/form-rights',
  'POST /admin/users/:loginName/password-reset',
  'POST /admin/companies/:coCode/provision',
  'GET /utilities/vch-renumber/preview',
  'POST /utilities/vch-renumber/apply',
  'POST /utilities/data-refresh',
  'GET /utilities/data-repair/operations',
  'POST /utilities/data-repair/:id/preview',
  'POST /utilities/data-repair/:id/apply',
  'GET /utilities/data-repair/runs',
]);

/**
 * Admin-only routes that must STILL validate the requested business scope.
 *
 * Most admin routes are scope-free by nature: a user list or a metrics scrape belongs to no company. A data
 * repair does the opposite — it rewrites one company's ledger, stock and serials — so dropping scope
 * validation for it would let an administrator's request name a company/location/year the session never
 * selected. `NO_BUSINESS_SCOPE` therefore subtracts these rather than inheriting all of `ADMIN_ONLY`.
 */
const SCOPED_ADMIN_ONLY = new Set([
  'GET /utilities/data-repair/operations',
  'POST /utilities/data-repair/:id/preview',
  'POST /utilities/data-repair/:id/apply',
  'GET /utilities/data-repair/runs',
]);

const NO_BUSINESS_SCOPE = new Set([
  'GET /audit',
  'GET /ops/metrics',
  'GET /ops/invariants',
  'GET /backup',
  'POST /backup/restore',
  'POST /years',
  ...[...ADMIN_ONLY].filter((key) => !SCOPED_ADMIN_ONLY.has(key)),
]);

const normalizeMethod = (method: string): string =>
  method.toUpperCase() === 'HEAD' ? 'GET' : method.toUpperCase();

function actionFor(key: string, method: string): RouteAction {
  if (PRINT_ROUTES.has(key)) return 'print';
  if (UPDATE_POST_ROUTES.has(key)) return 'update';
  if (DELETE_POST_ROUTES.has(key)) return 'delete';
  if (READ_POST_ROUTES.has(key)) return 'read';
  switch (method) {
    case 'GET':
      return 'read';
    case 'POST':
      return 'create';
    case 'PUT':
    case 'PATCH':
      return 'update';
    case 'DELETE':
      return 'delete';
    default:
      throw new Error(`unsupported route method: ${method}`);
  }
}

export function routePolicyFor(methodInput: string, path: string): RoutePolicy | undefined {
  const method = normalizeMethod(methodInput);
  const key = `${method} ${path}`;
  if (PUBLIC.has(key)) return { kind: 'public', businessScope: false };
  if (SYSTEM.has(key)) return { kind: 'system', businessScope: false };

  if (
    path === '/masters/:name' ||
    path === '/masters/:name/meta' ||
    path === '/masters/:name/import'
  ) {
    return {
      kind: 'form',
      form: '@master',
      action: actionFor(key, method),
      businessScope: true,
    };
  }

  if (
    method === 'GET' &&
    (path === '/reports/:report/filters' ||
      path === '/reports/:report/export.csv' ||
      path === '/reports/:report/export.xlsx')
  ) {
    return {
      kind: 'form',
      form: '@report',
      action: path === '/reports/:report/filters' ? 'read' : 'print',
      businessScope: true,
    };
  }

  const form = formRoutes.get(key);
  if (!form) return undefined;
  return {
    kind: 'form',
    form,
    action: actionFor(key, method),
    adminOnly: ADMIN_ONLY.has(key),
    businessScope: !NO_BUSINESS_SCOPE.has(key),
  };
}

export function resolvePolicyForm(
  policy: RoutePolicy,
  params: Record<string, unknown> | undefined,
): string | undefined {
  if (policy.form === '@master') {
    const name = String(params?.name ?? '');
    return MASTER_FORM_BY_NAME[name];
  }
  if (policy.form === '@report') return reportFormForSlug(params?.report);
  return policy.form;
}

export function isRouteAuthorizedMarker(value: unknown): boolean {
  return value === true;
}
