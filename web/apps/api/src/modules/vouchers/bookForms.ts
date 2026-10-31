/**
 * N207 (G220): which web forms own each BOOK_DATA.MAIN_BOOK.
 *
 * The desktop opens a voucher list only from the menu whose CurBookHelp(MAIN_BOOK) chose the book
 * (e.g. MDI_FORM.cs:8100-8111 'CONTRA', :8360-8365 'FINE JV'); MS_UPDATE.cs names each family's menu in
 * BOOK_DATA.MENU_NAME. Built from those MENU_NAME values resolved through the rights catalogue, the
 * pages' BookSelect mainBooks, and the web-only books' screens. Generated; keep sorted.
 */
export const MAIN_BOOK_FORMS: Readonly<Record<string, readonly string[]>> = {
  'AMT IN': ['Cash / Bank/Location Amount Transfer'],
  'AMT OUT': ['Cash / Bank/Location Amount Transfer'],
  'APPROVAL ISSUE': ['Sales/Tour / Approval Sale'],
  'APPROVAL RETURN': ['Sales/Approval Return'],
  'BANK PAY': ['Cash / Bank/Payment'],
  'BANK REC': ['Cash / Bank/Receipt'],
  'BUL SALE': ['Sales/Bul Sales', 'Sales/Bullion Booking'],
  'BUL WH SALE': ['Sales/Bul Sales'],
  'CARD ADJUST': ['Cash / Bank/Card / UPI Receipt'],
  'CASH PAY': ['Cash / Bank/Payment'],
  'CASH REC': ['Cash / Bank/Receipt'],
  'CON PUR': ['Purchase/Consignment Purchase'],
  CONTRA: ['Cash / Bank/Contra'],
  'CUSTREP RECEIPT': ['Manufacturing/Repair Receipt'],
  'DG GOLD': ['Cash / Bank/Digital Gold Book'],
  'DHIRAN ISSUE': ['Loans (Dhrn)/Pledge Issue'],
  'DHIRAN RECEIPT': ['Loans (Dhrn)/Pledge Receipt'],
  'E CRNT': ['Transaction/E CrntNote'],
  'E INVOICE': ['Transaction/E Invoice', 'Utilities/e-Invoice (IRN)'],
  'FINE INOUT': ['Inventory/Fine In / Out'],
  'FINE JV': ['Cash / Bank/Fine JV (metal transfer)'],
  'FINE PURC': ['Purchase/Fine Settlement'],
  'FINE SALE': ['Purchase/Fine Settlement'],
  'INTREST RECIVED': ['Loans (Dhrn)/Interest Receipt'],
  INWORD: ['Transaction/Stock In'],
  'ITEM LOT': ['Inventory/Lot Management'],
  'JDTR ISU': ['Manufacturing/Job-work Issue'],
  'JDTR REC': ['Manufacturing/Job-work Receive'],
  JOURNAL: [
    'Cash / Bank/Employee Salary JV',
    'Cash / Bank/Journal Voucher',
    'Cash / Bank/Ledger Adjustment',
  ],
  'KARIGAR ISSUE': ['Manufacturing/Karigar Issue'],
  'KARIGAR RECEIPT': ['Manufacturing/Karigar Receive'],
  'LABOUR WORK': ['Sales/Labour Sale'],
  'LOAN ISSUE': ['Loans (Dhrn)/Loan Issue'],
  'LOAN REC': ['Loans (Dhrn)/Loan Received'],
  'MEMB GOLD ADJ': ['Membership/Gold Adjust'],
  'MFG STNG ISU': ['Manufacturing/Setting Isu'],
  'MFG STNG REC': ['Manufacturing/Setting Rec'],
  'MLT PRO': ['Manufacturing/Melting'],
  'OLD ITEM SALES': ['ExtraTran/Old Item Sales'],
  OPSTK: ['Inventory/Item Opening (non-tag)', 'Inventory/Tag Opening'],
  'ORDER CANCEL': ['Sales/Order Cancel'],
  'OTH COMM': ['Purchase/Other Commission / Expense Voucher'],
  'OTH EXP': ['Purchase/Other Purchase'],
  'OTH INC': ['Purchase/Other Income'],
  OUTWORD: ['Transaction/Stock Out'],
  PAYMENT: ['Cash / Bank/Payment'],
  'PHY STOCK': ['Inventory/Physical Stock', 'Reports/Physical Stock'],
  'PR QUOT': ['Purchase/Purchase Quotation'],
  'PURC RETURN': ['Purchase/Purchase Return'],
  PURCHASE: ['Purchase/Hallmark Purchase', 'Purchase/Purchase Invoice', 'Purchase/Purchase Return'],
  'RATE CUT': ['Cash / Bank/Rate Cut (price fixing)'],
  RECEIPT: ['Cash / Bank/Multi-Party Receipt', 'Cash / Bank/Receipt'],
  'REM ENTRY': ['Utilities/Reminder Entry'],
  SALES: ['Sales/Sales Invoice', 'Sales/Sales Return'],
  'SALES ORDER': ['Sales/Order Cancel', 'Sales/Sales Order'],
  'SALES RETURNE': ['Sales/Sales Return'],
  'SF PRINT': ['Inventory/Stone/Dm-Cf'],
  'SL QUOT': ['Sales/Sales Quotation'],
  'STOCK ADJUST': ['Inventory/Stock Adjust'],
  'TAG ADJ': ['Inventory/Tag Adjust'],
  'TAG CANCEL': ['Inventory/Tag Cancel'],
  'TAG GEN': ['Inventory/Tag Opening'],
  'TAG OPENING': ['Inventory/Tag Opening'],
  'TAG PURCHASE': ['Purchase/Hallmark Purchase', 'Purchase/Purchase Return'],
  'TAG SPLIT': ['Inventory/Tag Split'],
  'TAG TRFR': ['Inventory/Tag Transfer'],
  'TOUR ORDER': ['Karigar/Tour Order'],
  'TOUR SALES': ['Sales/Tour / Approval Sale'],
  'VP PARCEL': ['Sales/VP Parcel'],
  'VP REC': ['Cash / Bank/VP Adjustment'],
  'WH QUOT': ['Sales/Wholesale Quotation'],
  'WH SALES': ['Sales/Wholesale Sale'],
};

/** The forms that may list or step through vouchers of a book with this MAIN_BOOK. */
export function formsForMainBook(mainBook: string): readonly string[] {
  return (
    MAIN_BOOK_FORMS[
      String(mainBook ?? '')
        .trim()
        .toUpperCase()
    ] ?? []
  );
}
