/**
 * Canonical form catalog for server-side USER_SET enforcement.
 *
 * `mainMenu/subMenu` are the web labels shown in the rights editor and returned by `/me`.
 * `aliases` preserve desktop MENU_DATA/SUB_MENU names. Desktop authorization is keyed by current
 * location + user + SUB_MENU (MDI_FORM/MS_USER); MAIN_MENU is descriptive and is not relied on as a
 * security key.
 */
export interface FormCatalogEntry {
  mainMenu: string;
  subMenu: string;
  aliases?: readonly string[];
}

const groups: Record<string, readonly string[]> = {
  Masters: [
    'Accounts',
    'Customers',
    'Party (rich)',
    'Items',
    'Auto Item',
    'Item Groups',
    'Taxes',
    'Metal Rates',
    'Opening Balance',
    'Labour Update',
    'Employees',
    'Books / Series',
    'Products',
    'Locations',
    'Designs',
    'Design Book',
    'Item Cities',
    'Diamonds',
    'Models',
    'States',
    'Loyalty Points',
    'Labour Types',
    'Touch / Purity',
    'Manufacturing',
    'Conversions',
    'Message Templates',
    'Companies',
    'Financial Years',
    'Year Create',
    'Addresses',
    'Live Gold Rate Cfg',
    'Schemes',
    'Counters',
    'Item Weight Slabs',
    'Styles / Columns',
    'Print Formats',
    'e-Invoice GSP Config',
    'Franchise Accounts',
    'Account Group',
    'Trade Master',
  ],
  Sales: [
    'Sales Invoice',
    'Hallmark Sale',
    'Wholesale Sale',
    'Wholesale Sale Return',
    'Sales Return',
    'Labour Sale',
    'Sales Order',
    'Order Cancel',
    'Estimate',
    'Bullion Booking',
    'Tour / Approval Sale',
    'Approval Return',
    'VP Parcel',
  ],
  Purchase: [
    'Purchase Invoice',
    'Purchase Return',
    'Hallmark Purchase',
    'Other Purchase',
    'Other Commission / Expense Voucher',
    'Fine Settlement',
  ],
  'Cash / Bank': [
    'Receipt',
    'Multi-Party Receipt',
    'Payment',
    'Contra',
    'Journal Voucher',
    'Account Opening Bal',
    'Fine JV (metal transfer)',
    'Bill-to-Bill Settle',
    'Bank Reconciliation',
    'Daily Rate',
    'Reminders',
    'Rate Cut (price fixing)',
    'Ledger Adjustment',
    'Employee Salary JV',
    'Card / UPI Receipt',
    'Digital Gold Book',
    'VP Adjustment',
    'Location Amount Transfer',
  ],
  Inventory: [
    'Stock / Tags',
    'Tag Opening',
    'Tag Print',
    'Item Opening (non-tag)',
    'Tag Cancel',
    'Tag Weight Diff',
    'Tag Split',
    'Physical Stock',
    'Stock Adjust',
    'Tag Transfer',
    'Counter Transfer',
    'Lot Management',
    'Fine In / Out',
  ],
  Manufacturing: [
    'Karigar Issue',
    'Karigar Receive',
    'Repair Receipt',
    'MFG Issue',
    'MFG Receive',
    'Job-work Issue',
    'Job-work Receive',
    'Order Issue',
    'Melting',
  ],
  'Loans (Dhrn)': ['Pledge Issue', 'Pledge Receipt', 'Interest Receipt'],
  Membership: ['Members & Loyalty', 'Saving Schemes'],
  Reports: [
    'Sales Register',
    'Purchase Register',
    'Day Book',
    'Trial Balance',
    'Balance Sheet',
    'Account Ledger',
    'Account Balances',
    'Outstanding (Debtors/Creditors)',
    'Bill-wise Outstanding',
    'Cash / Bank Book',
    'Party Statement',
    'HSN Tax Summary',
    'Scheme / Member Adjustments',
    'Item Stock Ledger',
    'Monthly Purchase',
    'Purchase by Party',
    'Group Trial Balance',
    'GSTR-2 (Purchase)',
    'Sales Return Register',
    'Karigar Statement',
    'Rate List',
    'Daily Sales Summary',
    'Top Items',
    'Employee Sales',
    'Purchase Return Register',
    'Contra Register',
    'Area-wise Outstanding',
    'Item-Group Stock',
    'Sales GST (Monthly)',
    'Bill Aging',
    'Stock by Location',
    'Purchase by Item',
    'Voucher Register',
    'Trial Balance (Full)',
    'Sales by Group',
    'Cash Day Summary',
    'Customer CRM',
    'Area-wise Sales',
    'Location-wise Sales',
    'GST Input Register',
    'Pledge Outstanding',
    'Karigar Balances',
    'Stock Valuation',
    'Tag-Stock Report',
    'Tag Estimate',
    'Order Zoom',
    'Karigar Ledger',
    'Old Gold / Exchange',
    'Sales by Party',
    'Sales by Item',
    'Monthly Sales',
    'GSTR-1',
    'GSTR-3B',
    'Report Layouts (Crystal)',
    'Form Layouts (Desktop)',
  ],
  Utilities: [
    'Utilities Home',
    'Integrations & Rates',
    'Settings',
    'Audit Log',
    'Import / Export',
    'Backup',
    'Data Refresh',
    'Data Repair',
    'Users & Rights',
    'Provision Company',
    'e-Invoice (IRN)',
    'Year-End Close',
    'Voucher Renumber',
    'Reminders',
    'Reminder Entry',
    'HDD Registry',
    'User Request',
    'Window Tiles',
  ],
};

const aliases: Record<string, readonly string[]> = {
  'Masters/Accounts': ['Party', 'Party Master', 'Account', 'Account Master'],
  'Masters/Customers': ['Party', 'Party Master', 'Customer'],
  'Masters/Party (rich)': ['Party', 'Party Master'],
  'Masters/Items': ['Item', 'Item Master'],
  'Masters/Item Groups': ['Item Group', 'Group Master'],
  'Masters/Metal Rates': ['Daily Rate', 'Rate Master'],
  'Masters/Books / Series': ['Book', 'Book Master', 'Books'],
  'Masters/Companies': ['Company', 'Company Create'],
  'Masters/Financial Years': ['Year Select', 'Financial Year'],
  'Masters/Year Create': ['Year Create'],
  'Sales/Sales Invoice': ['Sales', 'Sale', 'Gold Tax Invoice'],
  'Sales/Wholesale Sale': ['Wh Sales', 'Wholesale Sales'],
  'Sales/Wholesale Sale Return': ['WH RTN', 'Wholesale Sales Return', 'TR_WH_SALE_RTN'],
  'Sales/Labour Sale': ['Labour Invoice'],
  'Sales/Tour / Approval Sale': ['Tour', 'Approval Sale'],
  'Sales/Approval Return': ['Tour Return', 'Approval Return'],
  'Sales/VP Parcel': ['VP Parcel', 'TR_VP'],
  'Purchase/Purchase Invoice': ['Purchase'],
  'Purchase/Hallmark Purchase': ['Purchase HM'],
  'Purchase/Other Commission / Expense Voucher': ['Other Commission', 'Service Comm', 'OTH COMM'],
  'Cash / Bank/Receipt': ['Cash Received', 'Bank Received'],
  'Cash / Bank/Payment': ['Cash Payment', 'Bank Payment'],
  'Cash / Bank/Card / UPI Receipt': ['Card Received', 'UPI Received'],
  'Cash / Bank/Journal Voucher': ['Journal', 'JV Entry'],
  'Cash / Bank/Rate Cut (price fixing)': ['Rate Cut'],
  'Cash / Bank/VP Adjustment': ['VP Adjust', 'VP Adjustment'],
  'Inventory/Stock / Tags': ['Stock', 'Tag Stock'],
  'Inventory/Tag Opening': ['Tag Opening Balance', 'Only Tag Entry'],
  'Inventory/Item Opening (non-tag)': ['Item Opening'],
  'Manufacturing/Karigar Issue': ['Karigar Isu'],
  'Manufacturing/Karigar Receive': ['Karigar Rec'],
  'Manufacturing/Repair Receipt': [
    'Repairing Received',
    'Reparing Received',
    'Repairing Issue',
    'Reparing Issue',
  ],
  'Manufacturing/Job-work Issue': ['Jobwork Issue'],
  'Manufacturing/Job-work Receive': ['Jobwork Receive'],
  'Loans (Dhrn)/Pledge Issue': ['Dhiran Issue', 'Dhrn Issue'],
  'Loans (Dhrn)/Pledge Receipt': ['Dhiran Receipt', 'Dhrn Receipt'],
  'Loans (Dhrn)/Interest Receipt': ['Dhiran Interest', 'Dhrn Interest'],
  'Reports/Account Ledger': ['Ledger Report'],
  'Reports/Outstanding (Debtors/Creditors)': ['Outstanding', 'Bill Os Day'],
  'Reports/Tag-Stock Report': ['Stock Report', 'Tag Stock Report'],
  // Desktop MDI menu names, verbatim: 'Tag Estmate' is the desktop's own misspelling (MDI_FORM.cs:8994)
  // and 'Order Zoom' opens RP_ORDER (MDI_FORM.cs:7147). Both are bound to Ctrl chords in the shell.
  'Reports/Tag Estimate': ['Tag Estmate'],
  'Reports/Order Zoom': ['Order Zoom'],
  'Reports/Pledge Outstanding': ['Dhiran Outstanding', 'Dhrn Outstanding'],
  'Utilities/Settings': ['Admin Setting', 'Setting Main'],
  'Utilities/Backup': ['Data Backup'],
  'Utilities/Data Refresh': ['Data Refresh'],
  'Utilities/Data Repair': ['Data Repair'],
  'Utilities/Users & Rights': ['User Create', 'Users'],
  'Utilities/Provision Company': ['Company Create'],
  'Utilities/e-Invoice (IRN)': ['E Invoice', 'e-Invoice'],
  'Utilities/Reminder Entry': ['Reminder Entry'],
  'Utilities/HDD Registry': ['Hdd Update', 'Pc Registrar No', 'UT_HDD'],
  'Utilities/User Request': ['User Request', 'UT_USER_REQUEST'],
  'Utilities/Window Tiles': ['Window', 'Tile Menu', 'UT_WINDOW'],
};

export const formKey = (mainMenu: string, subMenu: string): string => `${mainMenu}/${subMenu}`;

export const FORM_CATALOG: FormCatalogEntry[] = Object.entries(groups).flatMap(
  ([mainMenu, subMenus]) =>
    subMenus.map((subMenu) => {
      const key = formKey(mainMenu, subMenu);
      const a = aliases[key];
      return a ? { mainMenu, subMenu, aliases: a } : { mainMenu, subMenu };
    }),
);

const byKey = new Map(FORM_CATALOG.map((entry) => [formKey(entry.mainMenu, entry.subMenu), entry]));

export function getFormCatalog(): FormCatalogEntry[] {
  return FORM_CATALOG.map(({ mainMenu, subMenu }) => ({ mainMenu, subMenu }));
}

export function getFormEntry(key: string): FormCatalogEntry | undefined {
  return byKey.get(key);
}

export function rightNamesForForm(key: string): string[] {
  const entry = getFormEntry(key);
  if (!entry) throw new Error(`unknown form key: ${key}`);
  return [entry.subMenu, ...(entry.aliases ?? [])];
}

export function canonicalFormsForRight(subMenu: string): string[] {
  const wanted = subMenu.trim().toUpperCase();
  if (!wanted) return [];
  return FORM_CATALOG.filter((entry) =>
    [entry.subMenu, ...(entry.aliases ?? [])].some((name) => name.trim().toUpperCase() === wanted),
  ).map((entry) => formKey(entry.mainMenu, entry.subMenu));
}
