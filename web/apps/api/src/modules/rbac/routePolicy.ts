import { getFormEntry } from './formCatalog.js';

export type RouteAction = 'read' | 'create' | 'update' | 'delete' | 'print';
export type RoutePolicyKind = 'public' | 'system' | 'form';

export interface RoutePolicy {
  kind: RoutePolicyKind;
  action?: RouteAction;
  form?: string | '@master';
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
// Desktop MS_UPDATE maintenance console. Preview and apply rewrite historical data, so they sit behind the
// same form right as the rest of the utility surface and are additionally admin-gated in the handler.
route('Utilities/Data Repair', [
  'GET /utilities/data-repair/operations',
  'POST /utilities/data-repair/:id/preview',
  'POST /utilities/data-repair/:id/apply',
  'GET /utilities/data-repair/runs',
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
  'POST /einvoice/:vchNo',
  'POST /einvoice/irn',
  'GET /einvoice/gsp-config',
  'POST /einvoice/gsp-test',
  'POST /einvoice/:vchNo/cancel',
]);
route('Utilities/Year-End Close', ['POST /year-end/preview', 'POST /year-end/close']);
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
route('Sales/Estimate', ['POST /estimate', 'GET /sales/quotation']);
route('Sales/Sales Return', [
  'POST /sales-returns',
  'GET /sales-returns/import',
  'DELETE /sales-returns/:vchNo',
  'GET /sales/credit-note',
]);
route('Sales/Sales Order', [
  'POST /sales-orders',
  'GET /sales-orders',
  'DELETE /sales-orders/:vchNo',
  'GET /sales/order-confirmation',
]);
route('Sales/Order Cancel', ['POST /sales-orders/:vchNo/cancel-refund']);
route('Sales/Labour Sale', ['POST /labour-invoice', 'DELETE /labour-invoice/:vchNo']);
route('Sales/Bullion Booking', ['POST /bullion/booking', 'DELETE /bullion/:vchNo']);
route('Sales/Tour / Approval Sale', [
  'POST /tour/issue',
  'DELETE /tour/:vchNo',
  'GET /tour/:vchNo/lines',
  'POST /tour/:vchNo/bill',
]);
route('Sales/Approval Return', ['POST /tour/return', 'DELETE /tour/return/:vchNo']);
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
route('Purchase/Other Purchase', ['POST /other-purchase', 'DELETE /other-purchase/:vchNo']);
route('Purchase/Other Commission / Expense Voucher', [
  'POST /other-commission',
  'GET /other-commission/:vchNo',
  'PUT /other-commission/:vchNo',
  'DELETE /other-commission/:vchNo',
]);
route('Purchase/Purchase Return', ['POST /purchase-returns', 'DELETE /purchase-returns/:vchNo']);
route('Purchase/Fine Settlement', ['POST /fine-sale', 'DELETE /fine-sale/:vchNo']);

route('Cash / Bank/Receipt', ['POST /receipts', 'GET /finance/receipt-voucher']);
route('Cash / Bank/Multi-Party Receipt', [
  'POST /receipts/multi',
  'DELETE /receipts/multi/:vchNo',
  'POST /receipts/batch',
]);
route('Cash / Bank/Payment', [
  'POST /payments',
  'POST /payments/multi',
  'DELETE /payments/multi/:vchNo',
  'GET /finance/payment-voucher',
  'GET /finance/cheque-print',
]);
route('Cash / Bank/Contra', ['POST /contra']);
route('Cash / Bank/Journal Voucher', ['POST /journal', 'DELETE /journal/:vchNo']);
route('Cash / Bank/Account Opening Bal', ['POST /ac-opbl', 'DELETE /ac-opbl/:vchNo']);
route('Cash / Bank/Fine JV (metal transfer)', ['POST /fine-jv', 'DELETE /fine-jv/:vchNo']);
route('Cash / Bank/Bill-to-Bill Settle', ['GET /bill-to-bill/open', 'POST /bill-to-bill/settle']);
route('Cash / Bank/Bank Reconciliation', ['GET /bank-recon', 'POST /bank-recon/clear']);
route('Cash / Bank/Daily Rate', ['POST /daily-rate', 'GET /daily-rate', 'GET /daily-rate/dates']);
route('Cash / Bank/Reminders', ['GET /reminders']);
route('Cash / Bank/Rate Cut (price fixing)', ['POST /rate-cut', 'DELETE /rate-cut/:vchNo']);
route('Cash / Bank/Ledger Adjustment', ['POST /ledger-adjust', 'DELETE /ledger-adjust/:vchNo']);
route('Cash / Bank/Employee Salary JV', ['POST /employee-jv', 'DELETE /employee-jv/:vchNo']);

route('Inventory/Stock / Tags', ['POST /stock/tags', 'GET /stock/tags', 'GET /stock/on-hand']);
route('Inventory/Tag Opening', [
  'POST /stock/tag-opening',
  'GET /stock/tag-opening/:vchNo',
  'PUT /stock/tag-opening/:vchNo',
  'DELETE /stock/tag-opening/:vchNo',
]);
route('Masters/Design Book', ['GET /masters/design-book', 'POST /masters/design-book']);
route('Inventory/Tag Print', [
  'GET /stock/tag-print',
  'GET /stock/tag-print/label',
  'POST /stock/tag-print/stage',
  // Tag photographs belong to the same surface: the right that shows a tag governs its image.
  'GET /stock/tag-image',
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

route('Membership/Members & Loyalty', ['POST /members', 'POST /members/points', 'GET /members']);
route('Membership/Saving Schemes', [
  'GET /scheme/passbook',
  'POST /scheme/enroll',
  'POST /scheme/installment',
  'POST /scheme/opening',
  'DELETE /scheme/opening/:vchNo',
  'POST /scheme/maturity',
  'DELETE /scheme/maturity/:vchNo',
]);

route('Masters/Auto Item', ['POST /masters/auto-item']);
route('Masters/Opening Balance', [
  'GET /accounts/:acCode/opening',
  'POST /accounts/:acCode/opening',
]);
route('Masters/Labour Update', ['GET /labour-update', 'POST /labour-update']);
route('Masters/Item Weight Slabs', ['GET /labour-slabs', 'POST /labour-slabs']);
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

// One XLSX export serves every report (desktop BtnExel, present on 38 forms). It is registered alongside
// the sales register because the handler resolves the report itself and is print-gated either way.
route('Reports/Sales Register', [
  'GET /reports/sales-register',
  'GET /reports/:report/export.xlsx',
]);
route('Reports/Purchase Register', ['GET /reports/purchase-register']);
route('Reports/Day Book', ['GET /reports/day-book']);
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
route('Reports/Tag Estimate', ['GET /reports/tag-estimate', 'GET /reports/:report/filters']);
route('Reports/Order Zoom', ['GET /reports/order-lot-zoom']);
route('Reports/Old Gold / Exchange', ['GET /reports/old-gold-register']);
route('Reports/Sales by Party', ['GET /reports/sales-by-party']);
route('Reports/Sales by Item', ['GET /reports/sales-by-item']);
route('Reports/Monthly Sales', ['GET /reports/monthly-sales']);
route('Reports/GSTR-1', ['GET /gst/gstr1', 'GET /reports/gstr1-doc']);
route('Reports/GSTR-3B', ['GET /reports/gstr3b', 'GET /reports/gstr3b-doc']);
route('Reports/Report Layouts (Crystal)', [
  'GET /reports/layouts',
  'GET /reports/layout',
  'GET /reports/render',
]);
route('Reports/Form Layouts (Desktop)', ['GET /forms/layouts', 'GET /forms/layout']);

const PRINT_ROUTES = new Set([
  'GET /sales/invoice',
  'GET /purchases/invoice',
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
  'POST /repair-images',
  'POST /admin/users/:loginName/rights',
  'POST /admin/users/:loginName/form-rights',
  'POST /admin/users/:loginName/password-reset',
  'POST /backup/restore',
  'POST /utilities/vch-renumber/apply',
  'POST /utilities/data-refresh',
  'POST /settings',
  'POST /accounts/:acCode/opening',
  'POST /labour-update',
  'POST /labour-slabs',
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
  'POST /tour/:vchNo/bill',
]);

const READ_POST_ROUTES = new Set(['POST /year-end/preview']);

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
]);

const NO_BUSINESS_SCOPE = new Set([
  'GET /audit',
  'GET /ops/metrics',
  'GET /ops/invariants',
  'GET /backup',
  'POST /backup/restore',
  'POST /years',
  ...ADMIN_ONLY,
]);

const normalizeMethod = (method: string): string =>
  method.toUpperCase() === 'HEAD' ? 'GET' : method.toUpperCase();

function actionFor(key: string, method: string): RouteAction {
  if (PRINT_ROUTES.has(key)) return 'print';
  if (UPDATE_POST_ROUTES.has(key)) return 'update';
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
  if (policy.form !== '@master') return policy.form;
  const name = String(params?.name ?? '');
  return MASTER_FORM_BY_NAME[name];
}

export function isRouteAuthorizedMarker(value: unknown): boolean {
  return value === true;
}
