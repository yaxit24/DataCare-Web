import type { NavGroup } from './nav';

/**
 * The Lite navigation (WP-55, D33): exactly the 49 desktop `MENU_DATA` rows with `SM_TYPE` `L` and `SM_VIEW` `Y`,
 * under the desktop tab (`BTN_NAME`) and caption (`SM_NAME`) the desktop shows (`MDI_FORM.cs:11249-11322`; the rows
 * are in `docs/handbook/menu-editions.json`). Each row is tab, caption, the web route that serves the menu
 * (`docs/handbook/menu-catalog.jsonl`) and the rights form of that route, so `USER_SET` rows still apply.
 * `editionNavLite.test.ts` checks this list against the desktop data.
 */
const LITE_MENUS: ReadonlyArray<
  readonly [tab: string, caption: string, href: string, form: string]
> = [
  ['Company', 'Company', '/masters/companies', 'Masters/Companies'],
  ['Company', 'Year Create', '/masters/year-create', 'Masters/Year Create'],
  ['Company', 'Balance TrFr', '/company/balance-transfer', 'Company/Balance TrFr'],
  ['Company', 'Books', '/masters/books', 'Masters/Books / Series'],
  ['Company', 'User Create', '/admin/users', 'Utilities/Users & Rights'],
  ['Company', 'Data Refresh', '/utilities/data-refresh', 'Utilities/Data Refresh'],
  ['Company', 'Data Backup', '/backup', 'Company/Data Backup'],
  ['ExtraTran', 'Approval Isu', '/txn/tour', 'Sales/Tour / Approval Sale'],
  ['ExtraTran', 'Approval Rtn', '/txn/tour-return', 'Sales/Approval Return'],
  ['ExtraTran', 'Fine Jv Entry', '/txn/fine-jv', 'Cash / Bank/Fine JV (metal transfer)'],
  ['Master', 'Party', '/masters/party', 'Masters/Party (rich)'],
  ['Master', 'Address', '/masters/addresses', 'Masters/Addresses'],
  ['Master', 'Product', '/masters/products', 'Masters/Products'],
  ['Master', 'Group', '/masters/groups', 'Masters/Item Groups'],
  ['Master', 'Item', '/masters/items', 'Masters/Items'],
  ['Master', 'AutoItem', '/masters/auto-item', 'Masters/Auto Item'],
  ['Master', 'Employee', '/masters/employees', 'Masters/Employees'],
  ['Master', 'Tax', '/masters/taxes', 'Masters/Taxes'],
  ['Master', 'Party Opening', '/txn/ac-opbl', 'Cash / Bank/Account Opening Bal'],
  ['Master', 'Item Opening', '/txn/item-opening', 'Inventory/Item Opening (non-tag)'],
  ['Master', 'Tag Opening', '/txn/tag-opening', 'Inventory/Tag Opening'],
  ['Other', 'Daily Rate', '/txn/daily-rate', 'Cash / Bank/Daily Rate'],
  ['Other', 'Only Tag Entry', '/txn/tag-opening?mode=TAG%20GEN', 'Inventory/Tag Opening'],
  ['Other', 'Tag Cancel', '/txn/tag-cancel', 'Inventory/Tag Cancel'],
  ['Other', 'Tag Print', '/txn/tag-print', 'Inventory/Tag Print'],
  ['Other', 'Stock Adjust', '/txn/stock-adjust', 'Inventory/Stock Adjust'],
  ['Other', 'Order Cancel', '/txn/order-cancel', 'Sales/Order Cancel'],
  ['Other', 'Data Import', '/masters/accounts', 'Utilities/Import / Export'],
  ['Report', 'Ledger Report', '/reports/account-ledger', 'Reports/Account Ledger'],
  ['Report', 'Stock Report', '/reports/stock-report', 'Reports/Stock Report'],
  ['Report', 'Tag Stock', '/reports/tag-stock', 'Reports/Tag-Stock Report'],
  ['Report', 'Sales Report', '/reports/sales-register', 'Reports/Sales Register'],
  ['Report', 'Purchase Rpt', '/reports/purchase-register', 'Reports/Purchase Register'],
  ['Report', 'Approval Rpt', '/reports/approval-report', 'Reports/Approval Report'],
  ['Report', 'Order Report', '/reports/order-report', 'Reports/Order Report'],
  ['Report', 'Cash Bank', '/reports/cash-book', 'Reports/Cash / Bank Book'],
  ['Report', 'Gst Report', '/reports/gst-report', 'Reports/GST Report'],
  ['Report', 'HuId Report', '/reports/huid', 'Reports/HUID Report'],
  ['Transaction', 'Purchase', '/txn/purchase', 'Purchase/Purchase Invoice'],
  ['Transaction', 'Purchase Rtn', '/txn/purchase-return', 'Purchase/Purchase Return'],
  ['Transaction', 'Sales Order', '/txn/sales-order', 'Sales/Sales Order'],
  ['Transaction', 'Sales', '/txn/sales', 'Sales/Sales Invoice'],
  ['Transaction', 'Sales Return', '/txn/sale-return', 'Sales/Sales Return'],
  ['Transaction', 'Wh Sales', '/txn/wholesale-sale', 'Sales/Wholesale Sale'],
  ['Transaction', 'Cash Received', '/txn/receipt', 'Cash / Bank/Receipt'],
  ['Transaction', 'Cash Payment', '/txn/payment', 'Cash / Bank/Payment'],
  ['Transaction', 'Bank Received', '/txn/receipt?mode=BANK', 'Cash / Bank/Receipt'],
  ['Transaction', 'Bank Payment', '/txn/payment?mode=BANK', 'Cash / Bank/Payment'],
  ['Transaction', 'Contra Entry', '/txn/contra', 'Cash / Bank/Contra'],
];

export const LITE_NAV: NavGroup[] = LITE_MENUS.reduce<NavGroup[]>(
  (groups, [tab, label, href, form]) => {
    let group = groups.find((candidate) => candidate.label === tab);
    if (!group) groups.push((group = { label: tab, items: [] }));
    group.items.push({ label, href, ready: true, form });
    return groups;
  },
  [],
);
