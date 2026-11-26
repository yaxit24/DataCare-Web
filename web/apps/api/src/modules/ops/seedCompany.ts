import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { type BookWorkflow, workflowPolicy } from '../shared/bookPolicy.js';
import { seedDesktopAccountGroups, seedDesktopCompanyMasters } from './desktopTemplateMasters.js';

/**
 * Company provisioning seed. A brand-new web company needs the system accounts that the posting engine
 * references by LITERAL code (CASH/SALES/PURCHASE/GST/…), plus standard taxes, voucher books, the
 * numbering counter and a settings row, so it can post immediately and show proper ledger names. We
 * seed exactly the literal codes the web posting uses (sales.ts/purchase.ts/finance.ts/… fallbacks) —
 * NOT a numeric chart — so no posting default changes and the existing test suite is untouched.
 * Idempotent: every row is insert-if-absent, so re-provisioning is safe.
 */

/**
 * System accounts keyed by the literal AC_CODE the posting falls back to.
 *
 * WP-36: the sale, purchase and tax ledgers sit in the desktop groups the master helps filter on, so a fresh company's
 * helps list them: Group Sales Ac takes group 25 and Purchase Ac group 30 (MS_GROUP.cs:2204 {{AND AC_GR = '25' AND
 * AC_CODE = '" + tSalesAc.Text}}, :2242; MS_TRADE.cs:1190 {{DC_Main.MsGrCode = "25";}}, :1234 "30"), and the Tax header
 * help lists group 12 (MS_TAX.cs:2039 {{AND (AC_GR = '12' OR  AC_CODE = '00013') ORDER BY AC_NAME}}). Group 20 is a
 * customer group on the desktop (RP_CUST.cs:996 {{AC_GR IN ('04','05','10','15','20','45','19')}}), so a sales ledger
 * there was listed as a customer. A web company provisioned earlier is moved by migration 20261123110000.
 *
 * Every group below is a row of the desktop installer chart (desktopTemplateMasters.ts) and sits where the
 * template puts the same role (AC_MAST.json), so AC_MAIN_GR classifies it as the desktop does: main group < '3' is
 * balance sheet / carried forward, >= '3' is P&L / closed at year end (balanceTransfer.ts isPartySql, yearEnd.ts).
 * CASH 00001 -> 21; BANK 00075 -> 22; CAPITAL 00002 -> 01; LBRINC 00041, INTINC 00061, HMCHRG 00097 and CARDCOMM
 * 00078 -> 41; LBREXP 00056, DISCOUNT 00076, OTHCHRG 00077 -> 46; FINEKSR 00098 -> 45; WALKIN 00045 -> 20.
 * No same-named twin, decided from use:
 *  - OG / OS: bookTemplates.ts DESKTOP_DEFAULT_ACCOUNT_ROLES maps them to 00005 / 00006 SALES OLD GOLD / SILVER
 *    A/C (group 25), the slots of the Old Item Sales books (BOOK_DETL 060-062) and the labour invoice.
 *  - OLDGOLD (old metal taken against a sale, sales.ts addReceipt): the desktop books old metal taken from a customer
 *    in the URD purchase books 037/043 against 00010 PURCHASE OLD GOLD A/C, group 30.
 *  - KASAR: write-off Dr KASAR (sales.ts kasarAc); the desktop slot it fills is 00057 KASAR JAVK A/C, group 45
 *    (bookTemplates.ts :181). ROUNDOFF has no template account; it is a rounding write-off like 00055 CASH ADJUST
 *    A/C (group 45), a P&L account. Group 31 is not in the installer chart.
 *  - DHRN: receivable loan (dhrn.ts Dr loan / Cr cash) -> 15 LOANS AND ADVANCES ASSETS.
 *  - BULLION: bullion-payable, Cr on booking (bullion.ts :125, our obligation to deliver metal) -> 07
 *    DEPOSIT - LIABILITIES, a balance-sheet liability that is not a customer group (group 05 is listed as one).
 *  - BRANCH: stock-in-hand control of a location (stockInout.ts) -> 18 CURRENT ASSETS, where the template keeps
 *    its 00021-00025 CLG.STOCK accounts.
 * Only newly provisioned companies get these groups; an existing company's chart is never rewritten.
 */
const SYSTEM_ACCOUNTS: { code: string; name: string; gr: string; gstType?: string }[] = [
  // G124 / G100: the sales/hallmark-sale/sales-quotation screens default the party to WALKIN. The
  // desktop's ready-to-trade template carries a cash/walk-in party (00045); without one, the default
  // retail sale fails tax-policy resolution. Seed WALKIN as a local (intra-state) Sundry Debtor in group 20
  // (SUNDRY DEBTORS, the group of the template's 00045 CASH SALES A/C; RP_CUST.cs:996 lists 20 as a customer
  // group). Desktop group 10 is KARIGAR SUNDRY CR, a liability, so it is not used for the customer.
  { code: 'WALKIN', name: 'WALK-IN CUSTOMER', gr: '20', gstType: 'L' },
  { code: 'CASH', name: 'CASH ON HAND', gr: '21' },
  { code: 'BANK', name: 'BANK A/C', gr: '22' },
  { code: 'SALES', name: 'SALES A/C', gr: '25' },
  { code: 'PURCHASE', name: 'PURCHASE A/C', gr: '30' },
  { code: 'GST', name: 'GST OUTPUT (PAYABLE)', gr: '12' },
  { code: 'GSTINPUT', name: 'GST INPUT CREDIT', gr: '12' },
  { code: 'ROUNDOFF', name: 'ROUND OFF', gr: '45' },
  { code: 'KASAR', name: 'KASAR / WRITE-OFF', gr: '45' },
  { code: 'TCS', name: 'TCS PAYABLE', gr: '12' },
  { code: 'HMCHRG', name: 'HALLMARK CHARGES', gr: '41' },
  { code: 'OLDGOLD', name: 'OLD GOLD EXCHANGE', gr: '30' },
  { code: 'OG', name: 'OLD GOLD', gr: '25' },
  { code: 'OS', name: 'OLD SILVER', gr: '25' },
  { code: 'INTINC', name: 'INTEREST INCOME', gr: '41' },
  { code: 'BULLION', name: 'BULLION TRADING', gr: '07' },
  { code: 'FINESALE', name: 'FINE METAL SALE', gr: '25' },
  { code: 'FINEPURC', name: 'FINE METAL PURCHASE', gr: '30' },
  // The installer's sales-other, purchase-old-silver and purchase-other accounts (00007, 00011, 00012; groups 25/30 in
  // AC_MAST.json), which GROUP_MAST/BAL_GR of the seeded groups name (desktopTemplateMasters.ts DESKTOP_ACCOUNT_ROLES).
  // The desktop posts an old-silver purchase, other-type sale and purchase to them (Ac_Ledr.cs:44/50, :308).
  { code: 'OTHSALE', name: 'SALES OTHER A/C', gr: '25' },
  { code: 'OLDSLVPR', name: 'PURCHASE OLD SILVER A/C', gr: '30' },
  { code: 'OTHPURC', name: 'PURCHASE OTHER A/C', gr: '30' },
  { code: 'DHRN', name: 'DHIRAN / LOAN', gr: '15' },
  { code: 'CAPITAL', name: 'CAPITAL A/C', gr: '01' },
  // N198 (G208): the sale books' slot 4 is the order-advance account the sale day book names for an adjusted
  // advance (Sales_Rojmel, Ac_Rojmel.cs:96, `SR_NO = 4`). The real chart carries it as 00020 ORDER ADVANCE (group 04).
  { code: 'ORDADV', name: 'ORDER ADVANCE', gr: '04' },
  // The wholesale / rate-cut slots (`Wh_Sales_Ledr`): labour income and expense, the silver twins of the sale
  // and purchase controls, other charges and fine kasar — the roles of 00041/00056/00004/00009/00077/00098 on
  // the real books 034/064.
  { code: 'LBRINC', name: 'LABOUR INCOME A/C', gr: '41' },
  { code: 'LBREXP', name: 'LABOUR EXPENSE A/C', gr: '46' },
  { code: 'SLVSALE', name: 'SALES SILVER A/C', gr: '25' },
  { code: 'SLVPURC', name: 'PURCHASE SILVER A/C', gr: '30' },
  { code: 'OTHCHRG', name: 'OTHER CHARGES A/C', gr: '46' },
  { code: 'CARDCOMM', name: 'CARD / BANK COMMISSION A/C', gr: '41' },
  { code: 'FINEKSR', name: 'FINE KASAR A/C', gr: '45' },
  // N240 (G252): the discount slot 5 of the purchase books (MS_UPDATE.cs:25022, :30221 template 00076 DISCOUNT A/C).
  { code: 'DISCOUNT', name: 'DISCOUNT A/C', gr: '46' },
  // Stock In/Out (TR_INOUT) posts the signed metal rows against the branch account the location carries
  // (`MS_LOCT.cs:3458` binds `LOCT_MAST.AC_CODE`; `stockInout.ts:344-355` reads it). A current-asset
  // stock-in-hand control holds the branch's inter-location metal (N91/G105).
  { code: 'BRANCH', name: 'BRANCH STOCK IN HAND', gr: '18' },
];

/**
 * BOOK_DETL of a purchase-family book (PURCHASE, TAG PURCHASE): 1 purchase, 2 cash, 3 round-off and 4 labour and
 * other charges. With CO_SET.PURC_WITH_LBR = 'N' the desktop posts a line's labour and other charges to slot 4
 * (Ac_Ledr.cs:419-421); without it the writer's fail-closed slot lookup refused every such purchase (G184).
 * Slot 5 is the template's discount account (MS_UPDATE.cs:25022 PURCHASE, :30221 TAG PURCHASE; N240, G252).
 */
const PURCHASE_BOOK_SLOTS: Array<{ srNo: number; acCode: string }> = [
  { srNo: 1, acCode: 'PURCHASE' },
  { srNo: 2, acCode: 'CASH' },
  { srNo: 3, acCode: 'ROUNDOFF' },
  { srNo: 4, acCode: 'LBREXP' },
  { srNo: 5, acCode: 'DISCOUNT' },
];

/**
 * BOOK_DETL of a TR_WH_SALE book, in the desktop's slot order (Ac_Ledr.cs:613-778 joins `B.SR_NO = n`; the real
 * books 034/064 carry all twelve): 1 sale gold, 2 purchase gold, 3 cash, 4 kasar, 5 purchase kasar, 6 labour
 * income, 7 labour expense, 8 sale silver, 9 purchase silver, 10 interest, 11 other charges, 12 fine kasar.
 */
const WHOLESALE_SLOTS: Array<{ srNo: number; acCode: string }> = [
  { srNo: 1, acCode: 'SALES' },
  { srNo: 2, acCode: 'PURCHASE' },
  { srNo: 3, acCode: 'CASH' },
  { srNo: 4, acCode: 'KASAR' },
  { srNo: 5, acCode: 'KASAR' },
  { srNo: 6, acCode: 'LBRINC' },
  { srNo: 7, acCode: 'LBREXP' },
  { srNo: 8, acCode: 'SLVSALE' },
  { srNo: 9, acCode: 'SLVPURC' },
  { srNo: 10, acCode: 'INTINC' },
  { srNo: 11, acCode: 'OTHCHRG' },
  { srNo: 12, acCode: 'FINEKSR' },
];

/**
 * Standard GST/TCS taxes. `prc` is the TOTAL rate.
 *
 * TAX_MAST is a parent + component shape, exactly as the desktop writes it and as the resolver reads it
 * (G82). The resolver pins the code by its PARENT row `SR_NO = 0` (`shared/taxPolicy.ts`, matching the desktop
 * `AND D.SR_NO = 0`), and the per-component split is read from `SR_NO = 1` SGST, `SR_NO = 2` CGST, `SR_NO = 3`
 * IGST (`Ac_Tax.cs`: `C.SR_NO = 1/2/3`, `TAX_AMT/2`, `TAX_AMT/2`, full). A GST code therefore needs four rows;
 * TAX FREE and TCS are a single parent row. Provisioning a code at `SR_NO = 1` only — as this seed did before
 * G82 — leaves it with no parent, so every save that NAMES the code failed with
 * "tax code is not configured" on every web-provisioned company.
 *
 * `isGst` marks the codes that get the three component rows.
 *
 * `TAX_AC` is deliberately left unset, exactly as this seed always left it. Choosing the tax ledger account is a
 * provisioning-convention question (gaps G38 and G40, decision D15, slices N58 and N59), not part of G82: the
 * desktop posts sale AND purchase tax to the one `TAX_MAST.TAX_AC` of the parent row (`Ac_Ledr.cs` Sales_Ledr and
 * Purc_Ledr join `D.SR_NO = 0` and post `D.TAX_AC`), while the web writers fall back to `'GST'` for sales and
 * `'GSTINPUT'` for purchases when `TAX_AC` is empty (`sales.ts:787`, `purchase.ts:718`). Writing `'GST'` here
 * would silently move every web-provisioned company's purchase input tax onto the output account, so G82 adds
 * the parent and component rows and changes no posted account.
 */
const TAXES: { code: string; name: string; prc: number; isGst?: boolean }[] = [
  { code: '00', name: 'TAX FREE', prc: 0 },
  { code: '10', name: 'GST 3%', prc: 3, isGst: true },
  { code: '11', name: 'GST 5%', prc: 5, isGst: true },
  { code: '12', name: 'GST 12%', prc: 12, isGst: true },
  { code: '13', name: 'GST 18%', prc: 18, isGst: true },
  { code: '14', name: 'GST 28%', prc: 28, isGst: true },
  { code: '20', name: 'TCS 0.1%', prc: 0.1 },
];

/** The desktop component layout for a GST code: SR_NO 1 SGST (half), 2 CGST (half), 3 IGST (full). */
function gstComponents(prc: number): Array<{ srNo: number; group: string; prc: number }> {
  const half = round(prc / 2, 4);
  return [
    { srNo: 1, group: 'SGST', prc: half },
    { srNo: 2, group: 'CGST', prc: half },
    { srNo: 3, group: 'IGST', prc },
  ];
}

/** Voucher books the web writes (CO_BOOK literals) → friendly names. */
/**
 * Books a new company starts with.
 *
 * Each carries the `MAIN_BOOK`, direction and posting account that `bookPolicy` needs, because a book
 * without them cannot post: `resolveBookAccountTx` reads `BOOK_DETL` for the contra/control account and
 * fails closed rather than inventing one. Provisioning previously created only `BOOK_DATA`, so a freshly
 * provisioned company hit `book <X> account row 1 is missing` on its first voucher — found by running the
 * application, not by any test.
 */
/**
 * N198 (G208): a sale book's BOOK_DETL slots — 1 sale, 2 cash, 3 kasar/round-off, 4 order advance (`sales.ts`). A sale
 * that adjusts an order advance resolves slot 4, so a book without it could not take an advance.
 */
const SALE_BOOK_SLOTS: Array<{ srNo: number; acCode: string }> = [
  { srNo: 1, acCode: 'SALES' },
  { srNo: 2, acCode: 'CASH' },
  { srNo: 3, acCode: 'ROUNDOFF' },
  { srNo: 4, acCode: 'ORDADV' },
];

/**
 * N191 (G201): the desktop's BOOK_TBL_NAME / BOOK_TBL_DETL for each family, as MS_UPDATE writes them on company open
 * (`MS_UPDATE.cs:7829` CONTRA, `:7837` SALES ORDER, `:7841` SALES and SALES RETURNE, `:7849` PURCHASE, PURC RETURN and
 * TAG PURCHASE, `:7897` FINE JV, `:7933` OTH INC and OTH EXP). Reports and numbering route by it; the Purchase
 * Return Register lists nothing for a book without it. Only families whose web writer uses the same header table.
 */
export const DESKTOP_BOOK_TABLES: Record<string, { table: string; detail: string }> = {
  SALES: { table: 'SL_DATA', detail: 'SL_DETL' },
  'SALES RETURNE': { table: 'SL_DATA', detail: 'SL_DETL' },
  PURCHASE: { table: 'PR_DATA', detail: 'PR_DETL' },
  'PURC RETURN': { table: 'PR_DATA', detail: 'PR_DETL' },
  'TAG PURCHASE': { table: 'PR_DATA', detail: 'PR_DETL' },
  'SALES ORDER': { table: 'SL_ORD_DATA', detail: 'SL_ORD_DETL' },
  CONTRA: { table: 'CONTRA_DATA', detail: 'CONTRA_DATA' },
  'FINE JV': { table: 'CONTRA_DATA', detail: 'CONTRA_DATA' },
  'OTH INC': { table: 'PAY_DATA', detail: 'PAY_DETL' },
  'OTH EXP': { table: 'PAY_DATA', detail: 'PAY_DETL' },
  // MS_UPDATE.cs:7825: the TR_TAG_CAN books; the Stock Adjust writer (modules/stock/tagCancel.ts) uses BAR_CAN_DATA.
  'STOCK ADJUST': { table: 'BAR_CAN_DATA', detail: 'BAR_CAN_DETL' },
  'APR ISU': { table: 'APR_DATA', detail: 'APR_DETL' },
  'APR RTN': { table: 'APR_DATA', detail: 'APR_DETL' },
};

const BOOKS: {
  book: string;
  name: string;
  /** When set, MAIN_BOOK and direction come from `workflowPolicy` so they can never drift out of step. */
  workflow?: BookWorkflow;
  mainBook?: string;
  inout?: string;
  acCode: string;
  /** BOOK_DETL slots when they differ from the sale-book layout (1 control, 2 cash, 3 round-off). */
  slots?: Array<{ srNo: number; acCode: string }>;
  /** BOOK_SNAME (the VCH_TYPE) when it is the desktop's, not the book code. */
  shortName?: string;
  /** BOOK_TBL_NAME, for the families that route by it. */
  table?: string;
}[] = [
  { book: 'SL', name: 'Sales', workflow: 'SALES', acCode: 'SALES', slots: SALE_BOOK_SLOTS },
  {
    book: 'PR',
    name: 'Purchase',
    workflow: 'PURCHASE',
    acCode: 'PURCHASE',
    slots: PURCHASE_BOOK_SLOTS,
  },
  // Desktop TR_PURC_HM 'Tag Wise Purc' book (MDI_FORM.cs:8540) — a TAG PURCHASE book posts through the
  // same Purc_* routines as PURCHASE, so a fresh company can use the hallmark-purchase screen (G02).
  {
    book: 'TPR',
    name: 'Hallmark Purchase',
    mainBook: 'TAG PURCHASE',
    inout: 'I',
    acCode: 'PURCHASE',
    slots: PURCHASE_BOOK_SLOTS,
  },
  // Desktop TR_OTH_PURC books: 375 OTINC 'OTH INC' (I) and 355 OTEXP 'OTH EXP' (O). Without them a fresh
  // company opened Other Income / Other Expenses to "No active books" (G03/G17, provisioning gap).
  {
    book: 'OIN',
    name: 'Other Income',
    mainBook: 'OTH INC',
    inout: 'I',
    acCode: 'INTINC',
    shortName: 'OTINC',
    // Slots 2 cash and 3 kasar of the OTH INC template (MS_UPDATE.cs:22884, :22892; N240, G252).
    slots: [
      { srNo: 1, acCode: 'INTINC' },
      { srNo: 2, acCode: 'CASH' },
      { srNo: 3, acCode: 'KASAR' },
    ],
  },
  {
    book: 'OEX',
    name: 'Other Expenses',
    mainBook: 'OTH EXP',
    inout: 'O',
    acCode: 'OTHCHRG',
    shortName: 'OTEXP',
    // Slots 2 cash and 3 kasar of the OTH EXP template (MS_UPDATE.cs:22860, :22868; N240, G252).
    slots: [
      { srNo: 1, acCode: 'OTHCHRG' },
      { srNo: 2, acCode: 'CASH' },
      { srNo: 3, acCode: 'KASAR' },
    ],
  },
  { book: 'SRT', name: 'Sales Return', workflow: 'SALES RETURN', acCode: 'SALES' },
  { book: 'PRT', name: 'Purchase Return', workflow: 'PURCHASE RETURN', acCode: 'PURCHASE' },
  // Cash books: slot 1 is the cash account and slot 2 the kasar write-off account
  // (Ac_Ledr.cs:567-581, legs 01-08 join BOOK_DETL SR_NO 1 and SR_NO 2). The sale-book layout put CASH
  // in slot 2 as well, which would post a write-off to cash.
  {
    book: 'RCT',
    name: 'Receipt',
    mainBook: 'RECEIPT',
    inout: 'I',
    acCode: 'CASH',
    slots: [
      { srNo: 1, acCode: 'CASH' },
      { srNo: 2, acCode: 'KASAR' },
    ],
  },
  {
    book: 'PAY',
    name: 'Payment',
    mainBook: 'PAYMENT',
    inout: 'O',
    acCode: 'CASH',
    slots: [
      { srNo: 1, acCode: 'CASH' },
      { srNo: 2, acCode: 'KASAR' },
    ],
  },
  // N198 (G207): Order_Ledr debits slot 1 with the cash advance (Ac_Ledr.cs:28-35) and Order_Rojmel names it as the
  // advance contra (Ac_Rojmel.cs:11). On the real data every cash leg 02 of book 020 is 00001 CASH ON HAND.
  {
    book: 'SOR',
    name: 'Sales Order',
    mainBook: 'SALES ORDER',
    // Desktop standard Sales Order books are inbound (MS_UPDATE.cs:17799-17831, :31987).
    // This template is inserted only while provisioning a new company; seedCompany never updates existing books.
    inout: 'I',
    acCode: 'CASH',
    slots: [
      { srNo: 1, acCode: 'CASH' },
      { srNo: 2, acCode: 'CASH' },
      { srNo: 3, acCode: 'ROUNDOFF' },
    ],
  },
  // Desktop MDI_FORM.cs:8629 CurBookHelp("ORDER CANCEL"); the Order Cancel screen refunds an order's
  // advance through SL_ORD_ADJ + a balanced AC_DATA refund. Without this book a provisioned company could not
  // cancel/refund an order (N113). Slot 1 is the default refund account, the desktop's PaiidAc 00001 CASH ON HAND
  // (TR_SL_ORD_ADJ.cs:2255-2263), and slot 2 the kasar account, the desktop's fixed 00042 (Ac_Ledr.cs:932-935). The
  // sale-book default would have put SALES in slot 1 and CASH in slot 2, refunding through sales and writing a kasar
  // off to cash.
  {
    book: 'ORC',
    name: 'Order Cancel',
    mainBook: 'ORDER CANCEL',
    inout: 'O',
    acCode: 'CASH',
    shortName: 'SADJ',
    table: 'SL_ORD_ADJ',
    slots: [
      { srNo: 1, acCode: 'CASH' },
      { srNo: 2, acCode: 'KASAR' },
    ],
  },
  // Desktop Approval Isu / Approval Rtn both open TR_APR_ISU through these exact MAIN_BOOK values
  // (MDI_FORM.cs:8300-8317) and route to APR_DATA/APR_DETL (MS_UPDATE.cs:7833).
  { book: 'TUR', name: 'Approval Issue', mainBook: 'APR ISU', inout: 'O', acCode: 'OS' },
  { book: 'TRR', name: 'Approval Return', mainBook: 'APR RTN', inout: 'I', acCode: 'OS' },
  // Desktop TR_TAG_CAN on a STOCK ADJUST book (MDI_FORM.cs:8616-8627): the desktop's own book 163 "Only Stock Adjust"
  // is short name STADJ, an out book (MS_UPDATE.cs:24207, :25049), numbered from BAR_CAN_DATA (DESKTOP_BOOK_TABLES).
  {
    book: 'SAJ',
    name: 'Stock Adjust',
    mainBook: 'STOCK ADJUST',
    inout: 'O',
    acCode: 'KASAR',
    shortName: 'STADJ',
  },
  // Desktop Tag Opening (TR_TAG_OPEN): a pure stock-opening voucher writing BAR_DATA and positive MAIN_STOCK,
  // with no ledger entry (AC_DATA lines are empty). Without this book the Tag Opening screen has no book to
  // select on a provisioned company (N101, same class as Stock In/Out and Dhiran). Empty slots: a stock
  // opening implies no ledger accounts. Book definition mirrors `tagOpeningRoundTrip.db.test.ts`.
  {
    book: 'TOP',
    name: 'Tag Opening',
    mainBook: 'TAG OPENING',
    inout: 'I',
    acCode: 'PURCHASE',
    shortName: 'TAGOP',
    table: 'BAR_DATA',
    slots: [],
  },
  // Desktop Only Tag Entry (TR_TAG_OPBL, MDI_FORM.cs:8574-8584 CurBookHelp("TAG GEN")): makes tags out of a loose
  // stock item — the tags go in and the item goes out (Ac_Stock.Tag_Opbl_Stk, Ac_Stock.cs:22-36). No ledger entry, so
  // the book has no account slots. The desktop's default book is "Only Tag Entry 1" (TGEN1, MS_UPDATE.cs:17020).
  {
    book: 'TGN',
    name: 'Only Tag Entry',
    mainBook: 'TAG GEN',
    inout: 'I',
    acCode: 'PURCHASE',
    shortName: 'TGEN',
    table: 'BAR_DATA',
    slots: [],
  },
  // Web-only numbered Item Opening voucher book. The desktop Item Opening (TR_ITM_OPBL) has no book help
  // (MDI_FORM.cs:7690-7699; the CurBookHelp("OPSTK") at :7701 belongs to Tag Opening) and writes book '000', which
  // the screen now does (N209). Kept for the vouchers the older POST /stock/item-opening route wrote on this book.
  // Empty slots: a stock opening implies no ledger accounts.
  {
    book: 'IOP',
    name: 'Item Opening',
    mainBook: 'OPSTK',
    inout: 'I',
    acCode: 'PURCHASE',
    shortName: 'IOPN',
    table: 'BAR_DATA',
    slots: [],
  },
  // Desktop Fine In/Out (TR_FINE_INOUT): a pure metal movement writing INOUT_DATA + signed MAIN_STOCK with
  // no money ledger (AC_DATA empty), stamped BOOK_NAME 'FINE INOUT'. Without this book the Fine In/Out screen
  // has no book to select on a provisioned company (N102, same class as Tag Opening). Empty slots: a metal
  // movement implies no ledger accounts. Mirrors `fineInoutGrid.db.test.ts`.
  {
    book: 'FIO',
    name: 'Fine In Out',
    mainBook: 'FINE INOUT',
    inout: 'I',
    acCode: 'PURCHASE',
    shortName: 'FINO',
    table: 'INOUT_DATA',
    slots: [],
  },
  // Desktop Bullion Booking (TR_BUL_BOOKING, MDI_FORM.cs:8171 BUL SALE / :8183 BUL PURC): a party books bulk
  // fine metal at a locked rate. The header lands in BUL_DATA and a balanced Dr cash / Cr bullion-payable
  // entry in AC_DATA. Without this book the Bullion Booking screen has no book to select on a provisioned
  // company (N103, same class as Dhiran/Stock In). The writer resolves its accounts from the payload
  // (payableAc 'BULLION', cashAc 'CASH'), so the standard three slots are nominal.
  {
    book: 'BUL',
    name: 'Bullion Booking',
    mainBook: 'BUL SALE',
    inout: 'I',
    acCode: 'BULLION',
    shortName: 'BULBK',
    table: 'BUL_DATA',
  },
  // Desktop TR_INOUT branch transfer: Stock In opens on MAIN_BOOK 'INWORD' and Stock Out on 'OUTWORD'
  // (MDI_FORM.cs:8159/8136; the signed metal posts against the branch account on LOCT_MAST, not a book slot).
  // Without them `StockInoutForm`'s book list is empty and Save stays disabled (N91/G105).
  {
    book: 'SIN',
    name: 'Stock In',
    mainBook: 'INWORD',
    inout: 'I',
    acCode: 'BRANCH',
    shortName: 'STKIN',
  },
  {
    book: 'SOT',
    name: 'Stock Out',
    mainBook: 'OUTWORD',
    inout: 'O',
    acCode: 'BRANCH',
    shortName: 'STKOT',
  },
  // Desktop TR_TAG_CAN serves both menus on its own MAIN_BOOK (MDI_FORM.cs:8586 "TAG CANCEL", :8664 "TAG TRFR"),
  // numbered from BAR_CAN_DATA (MS_UPDATE.cs:7825). The desktop's own short names are TGCAN and TAGTR
  // (`project-memory/parity/verify-stock-tags.md` §0). 'TAG TRANSFER', provisioned before, is no desktop MAIN_BOOK.
  {
    book: 'TGC',
    name: 'Tag Cancel',
    mainBook: 'TAG CANCEL',
    inout: 'O',
    acCode: 'KASAR',
    shortName: 'TGCAN',
    table: 'BAR_CAN_DATA',
  },
  {
    book: 'TTR',
    name: 'Tag Transfer',
    mainBook: 'TAG TRFR',
    inout: 'O',
    acCode: 'KASAR',
    shortName: 'TAGTR',
    table: 'BAR_CAN_DATA',
  },
  // Desktop TR_TAG_SPLIT on a TAG SPLIT book (MDI_FORM.cs:8686 "Tag Split"), short name TGSPL, numbered from
  // LBR_DATA (its header table). Ac_Ledr.Tag_Split_Ledr (Ac_Ledr.cs:1953-1982) posts the absorbing legs from
  // BOOK_DETL slots 5 (labour), 6/7 (gold DR/CR fine) and 8/9 (silver DR/CR fine); provisioning wires them so a
  // split with a difference and an absorbing account can post.
  {
    book: 'TSP',
    name: 'Tag Split',
    mainBook: 'TAG SPLIT',
    inout: 'O',
    acCode: 'KASAR',
    shortName: 'TGSPL',
    table: 'LBR_DATA',
    // N240 (G252): the TAG SPLIT template (MS_UPDATE.cs:32078-32110): 1 cash, 2 kasar javk, 3 kasar avak, 4 labour
    // income, 5 labour expense, 6 sales gold, 7 purchase gold, 8 sales silver, 9 purchase silver. The earlier seed
    // swapped 6/7 and gave the silver slots 8/9 the gold accounts.
    slots: [
      { srNo: 1, acCode: 'CASH' },
      { srNo: 2, acCode: 'KASAR' },
      { srNo: 3, acCode: 'KASAR' },
      { srNo: 4, acCode: 'LBRINC' },
      { srNo: 5, acCode: 'LBREXP' },
      { srNo: 6, acCode: 'SALES' },
      { srNo: 7, acCode: 'PURCHASE' },
      { srNo: 8, acCode: 'SLVSALE' },
      { srNo: 9, acCode: 'SLVPURC' },
    ],
  },
  { book: 'ILT', name: 'Item Lot', mainBook: 'ITEM LOT', inout: 'I', acCode: 'PURCHASE' },
  // Desktop TR_KR_ISU karigar books (MDI_FORM.cs:9153 'KARIGAR ISSUE', :9165 'KARIGAR RECEIPT'), over
  // KR_DATA. Issue sends metal out to the karigar; receipt takes finished metal back in. Without them a
  // fresh company could not open Karigar Issue / Receive at all — the writer refuses a book-less scope
  // ('company year and book are required'). G19.
  {
    book: 'KRI',
    name: 'Karigar Issue',
    mainBook: 'KARIGAR ISSUE',
    inout: 'O',
    acCode: 'PURCHASE',
    shortName: 'KRISU',
    table: 'KR_DATA',
  },
  {
    book: 'KRR',
    name: 'Karigar Receipt',
    mainBook: 'KARIGAR RECEIPT',
    inout: 'I',
    acCode: 'PURCHASE',
    shortName: 'KRREC',
    table: 'KR_DATA',
  },
  // Desktop Job-work/Jadtar dispatch is JDTR ISU / JDTR REC (MDI_FORM.cs:9717/9726), both over
  // MFG_DATA/MFG_DETL (MS_UPDATE.cs:7913). The shared KarigarForm now sends the selected book.
  {
    book: 'JDI',
    name: 'Jadtar Issue',
    mainBook: 'JDTR ISU',
    inout: 'O',
    acCode: 'PURCHASE',
    shortName: 'JDISU',
    table: 'MFG_DATA',
  },
  {
    book: 'JDR',
    name: 'Jadtar Receipt',
    mainBook: 'JDTR REC',
    inout: 'I',
    acCode: 'PURCHASE',
    shortName: 'JDREC',
    table: 'MFG_DATA',
  },
  { book: 'JV', name: 'Journal', mainBook: 'JOURNAL', inout: 'I', acCode: 'KASAR' },
  { book: 'CON', name: 'Contra', mainBook: 'CONTRA', inout: 'I', acCode: 'CASH' },
  // Fine JV (desktop Fine Jv Entry, MDI_FORM.cs:8360 CurBookHelp('FINE JV')): a pure metal-weight transfer
  // between two parties (CONTRA_DATA + balanced AC_DATA fine legs; no money, no book slots). Without this
  // book the Fine JV screen has no book to select on a provisioned company (N138).
  {
    book: 'FJV',
    name: 'Fine JV',
    mainBook: 'FINE JV',
    inout: 'I',
    acCode: 'CASH',
    shortName: 'FJV',
  },
  // Card Receipt / CARD ADJUST (desktop TR_CARD_REC, MDI_FORM.cs:8457 CurBookHelp("CARD ADJUST")).
  // The 8-leg card ledger resolves the commission/charges account from BOOK_DETL slot 1 and the
  // cash/control account (for CASH_PAID cashback) from slot 2 (Ac_Ledr.cs:1792-1804); without this
  // book and its slots the Card Rec screen has no book to select on a provisioned company (N123, G132).
  {
    book: 'CRD',
    name: 'Card Receipt',
    mainBook: 'CARD ADJUST',
    inout: 'I',
    acCode: 'CARDCOMM',
    shortName: 'CARD',
    table: 'CARD_DATA',
    slots: [
      { srNo: 1, acCode: 'CARDCOMM' },
      { srNo: 2, acCode: 'CASH' },
    ],
  },
  // Desktop Labour Sale (TR_LBR, MDI_FORM.cs:8325 CurBookHelp("LABOUR WORK")) and Fine Settlement
  // (TR_FINE_SL_PR, :8505 FINE SALE / :8493 FINE PURC). Without these books the Labour Sale and Fine
  // Settlement screens have no book to select on a provisioned company (N100, G110 — same class as N91/N97).
  // Book definitions mirror the authoritative DB test `labourFineTaxRows.routes.db.test.ts`.
  {
    book: 'LBR',
    name: 'Labour',
    mainBook: 'LABOUR WORK',
    inout: 'O',
    acCode: 'LBRINC',
    shortName: 'LBRI',
    table: 'LBR_DATA',
    // Desktop Ac_Ledr.cs:1203 credits the labour amount to BOOK_DETL SR_NO 6 and the metal to
    // SR_NO 1. We provision both so the labour writer resolves the income account from the book
    // (G115 / P0-04) instead of a literal.
    // Slots 8 to 11 of the LABOUR WORK template (MS_UPDATE.cs:23749-23761; N240, G252): sales silver, purchase
    // silver, sales old gold and sales old silver.
    slots: [
      { srNo: 1, acCode: 'LBRINC' },
      { srNo: 6, acCode: 'LBRINC' },
      { srNo: 8, acCode: 'SLVSALE' },
      { srNo: 9, acCode: 'SLVPURC' },
      { srNo: 10, acCode: 'OG' },
      { srNo: 11, acCode: 'OS' },
    ],
  },
  {
    book: 'FSL',
    name: 'Fine Sale',
    mainBook: 'FINE SALE',
    inout: 'O',
    acCode: 'FINESALE',
    shortName: 'FNSL',
    table: 'CUT_DATA',
    slots: [{ srNo: 1, acCode: 'FINESALE' }],
  },
  {
    book: 'FPR',
    name: 'Fine Purchase',
    mainBook: 'FINE PURC',
    inout: 'I',
    acCode: 'FINEPURC',
    shortName: 'FNPR',
    table: 'CUT_DATA',
    slots: [{ srNo: 1, acCode: 'FINEPURC' }],
  },
  // Desktop Dhiran (pledge loan): the Pledge Loan Issue menu opens on MAIN_BOOK 'DHIRAN ISSUE' and Pledge
  // Receipt on 'DHIRAN RECEIPT' (MDI_FORM.cs:9527/9539, Dhiran_Form). The issue writes DHRN_ISU_DATA and the
  // receipt DHRN_REC_DATA; both post against the DHRN receivable. Without them the Pledge Loan screens have
  // no book to select and Save is refused on a provisioned company (N97, same class as the Stock In/Out gap).
  {
    book: 'DHI',
    name: 'Dhiran Issue',
    mainBook: 'DHIRAN ISSUE',
    inout: 'O',
    acCode: 'DHRN',
    shortName: 'DHIS',
    table: 'DHRN_ISU_DATA',
  },
  {
    book: 'DHR',
    name: 'Dhiran Receipt',
    mainBook: 'DHIRAN RECEIPT',
    inout: 'I',
    acCode: 'DHRN',
    shortName: 'DHRC',
    table: 'DHRN_REC_DATA',
  },
  // Desktop Loan/Dhrn Interest Receipt (TR_DHRN_INTREC, MDI_FORM.cs:9549 CurBookHelp('INTREST RECIVED')).
  // Its own book over DHRN_REC_DATA, inward. The interest ledger resolves the interest-income account
  // from BOOK_DETL slot 2 (Ac_Ledr.cs:1156) and the metal fine link from slot 1; without this book the
  // Loan Interest screen has no book to select on a provisioned company (N125, G134).
  {
    book: 'DIR',
    name: 'Dhiran Interest',
    mainBook: 'INTREST RECIVED',
    inout: 'I',
    acCode: 'INTINC',
    shortName: 'DINT',
    table: 'DHRN_REC_DATA',
    slots: [
      { srNo: 1, acCode: 'INTINC' },
      { srNo: 2, acCode: 'INTINC' },
    ],
  },
  // Desktop TR_WH_SALE serves both: book 034 `WSALE` / `WH SALES` and book 064 `RCUT` / `RATE CUT`, each an OUT
  // book over RATE_CUT_DATA. Without them a new company had no book either screen could post to, and the Rate
  // Cut screen fell back to the cash Receipt book.
  {
    book: 'WHS',
    name: 'Wholesale Sale',
    mainBook: 'WH SALES',
    inout: 'O',
    acCode: 'SALES',
    slots: WHOLESALE_SLOTS,
    shortName: 'WSALE',
    table: 'RATE_CUT_DATA',
  },
  // Desktop Tour Sales (TR_TOUR_SALE, MDI_FORM.cs:9321 CurBookHelp('TOUR SALES')) posts the same
  // TR_WH_SALE engine (Wh_Sales_Ledr/Rojmel/Stk) on a TOUR SALES book over RATE_CUT_DATA. Without it
  // the Tour Sales screen has no book to select on a provisioned company (N127, G136).
  {
    book: 'TSL',
    name: 'Tour Sales',
    mainBook: 'TOUR SALES',
    inout: 'O',
    acCode: 'SALES',
    slots: WHOLESALE_SLOTS,
    shortName: 'TSALE',
    table: 'RATE_CUT_DATA',
  },
  // Desktop book 434 WHQUT / WH QUOT uses TR_WH_SALE's document grids, while its posting routines
  // exclude WH QUOT. Empty slots are deliberate: a quotation must not need or imply ledger accounts.
  {
    book: 'WHQ',
    name: 'Wholesale Quotation',
    mainBook: 'WH QUOT',
    inout: 'O',
    acCode: 'SALES',
    slots: [],
    shortName: 'WHQUT',
    table: 'RATE_CUT_DATA',
  },
  {
    book: 'RTC',
    name: 'Rate Cut',
    mainBook: 'RATE CUT',
    inout: 'O',
    acCode: 'SALES',
    slots: WHOLESALE_SLOTS,
    shortName: 'RCUT',
    table: 'RATE_CUT_DATA',
  },
];

export interface SeedResult {
  coCode: string;
  created: {
    coMast: boolean;
    accounts: number;
    taxes: number;
    books: number;
    srno: boolean;
    coSet: boolean;
    /** The location and fiscal year without which the company cannot be entered at all. */
    locality: boolean;
    year: boolean;
  };
}

export async function seedCompany(
  prisma: any,
  tenantId: string,
  coCode: string,
  opts?: { coName?: string; lcCode?: string },
): Promise<SeedResult> {
  if (!coCode) throw new Error('coCode is required');
  const lcCode = opts?.lcCode ?? '01';
  // The fiscal year the desktop would open: April-to-March around today.
  const y = new Date().getFullYear();
  return withTxBudget(prisma, tenantId, 'heavy', async (tx: any) => {
    /**
     * Does this company lack the row we are about to create?
     *
     * The tenant predicate is written into every query explicitly rather than left to RLS. Relying on
     * RLS made this function silently do nothing when handed an owner connection: the owner bypasses
     * row-level security, so `WHERE "CO_CODE"='01'` matched some OTHER tenant's company, every check
     * reported "already present", nothing was inserted, and the result came back
     * `created: {…all false}` — indistinguishable from a company that was genuinely already
     * provisioned. It worked in the running application only because the app connects as a non-owner.
     *
     * Same defect class as the message-log isolation bug: a query that filters on a business key and
     * leans on RLS for the tenant is correct under one connection type only. An explicit predicate is
     * correct under both.
     */
    const absent = async (table: string, where: string, ...p: unknown[]): Promise<boolean> => {
      const sql = `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND ${where}`;
      return Number((await tx.$queryRawUnsafe(sql, tenantId, ...p))[0]?.n ?? 0) === 0;
    };
    let coMast = false,
      accounts = 0,
      taxes = 0,
      books = 0,
      srno = false,
      coSet = false,
      locality = false,
      year = false;

    if (await absent('CO_MAST', '"CO_CODE"=$2', coCode)) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,$2,$3,$4)`,
        tenantId,
        coCode,
        opts?.coName ?? `Company ${coCode}`,
        lcCode,
      );
      coMast = true;
    }
    // Only a chart being created now: a company created by this call, or one whose CO_MAST came first (Company
    // master, companyIdentity.ts) and has neither groups nor system accounts yet. Boot (server.ts) and
    // /admin/companies/:coCode/provision re-run this for established companies, whose charts must not gain groups.
    const freshChart =
      coMast ||
      ((await absent('AC_GROUP', '"CO_CODE"=$2', coCode)) &&
        (await absent('AC_MAST', '"CO_CODE"=$2 AND "AC_CODE"=$3', coCode, 'CASH')));
    if (freshChart) {
      await seedDesktopAccountGroups(tx, absent, tenantId, coCode);
      const coSetMissing = await absent('CO_SET', '"CO_CODE"=$2', coCode);
      await seedDesktopCompanyMasters(tx, absent, tenantId, coCode, lcCode);
      // The desktop copies company 01's whole CO_SET row (MS_YEAR.cs:1568), so a fresh company's row comes from there.
      if (coSetMissing && !(await absent('CO_SET', '"CO_CODE"=$2', coCode))) coSet = true;
    }
    for (const a of SYSTEM_ACCOUNTS) {
      if (await absent('AC_MAST', '"CO_CODE"=$2 AND "AC_CODE"=$3', coCode, a.code)) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE") VALUES ($1,$2,$3,$4,$5,$6,$7)`,
          tenantId,
          coCode,
          lcCode,
          a.code,
          a.name,
          a.gr,
          a.gstType ?? null,
        );
        accounts += 1;
      }
    }
    for (const t of TAXES) {
      // Parent row at SR_NO 0 — the row the resolver pins a named code to (G82).
      if (
        await absent(
          'TAX_MAST',
          '"CO_CODE"=$2 AND "TAX_CODE"=$3 AND coalesce("SR_NO",0)=0',
          coCode,
          t.code,
        )
      ) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP") VALUES ($1,$2,$3,0,$4,$5,'N')`,
          tenantId,
          coCode,
          t.code,
          t.name,
          t.prc,
        );
        taxes += 1;
      }
      // SGST / CGST / IGST component rows at SR_NO 1..3 for a GST code.
      if (t.isGst) {
        for (const c of gstComponents(t.prc)) {
          if (
            await absent(
              'TAX_MAST',
              '"CO_CODE"=$2 AND "TAX_CODE"=$3 AND coalesce("SR_NO",0)=$4',
              coCode,
              t.code,
              c.srNo,
            )
          ) {
            await tx.$executeRawUnsafe(
              `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP") VALUES ($1,$2,$3,$4,$5,$6,$7)`,
              tenantId,
              coCode,
              t.code,
              c.srNo,
              `${t.name} ${c.group}`,
              c.prc,
              c.group,
            );
            taxes += 1;
          }
        }
      }
    }
    for (const b of BOOKS) {
      // MAIN_BOOK / direction come from workflowPolicy when the book backs a workflow, so provisioning
      // cannot spell them differently from the resolver that validates them.
      const wf = b.workflow ? workflowPolicy[b.workflow] : undefined;
      const mainBook = wf?.mainBook ?? b.mainBook ?? b.name.toUpperCase();
      const inout = wf?.inout ?? b.inout ?? 'I';
      const desktopTables = DESKTOP_BOOK_TABLES[mainBook];
      if (
        await absent(
          'BOOK_DATA',
          '"CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4',
          coCode,
          lcCode,
          b.book,
        )
      ) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
             "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","DATA_TYPE")
           VALUES ($1,$2,$3,$4,$5,$6,$7,$8,'Y',$9,$10,'A')`,
          tenantId,
          coCode,
          lcCode,
          b.book,
          b.name,
          b.shortName ?? b.book,
          mainBook,
          inout,
          b.table ?? desktopTables?.table ?? null,
          b.table ? null : (desktopTables?.detail ?? null),
        );
        // BOOK_DETL carries ONE ROW PER POSTING LEG, and `bookPolicy.resolveBookAccountTx` asks for a
        // specific SR_NO. The sale path alone resolves three: 1 = the control/sales account, 2 = the
        // cash/bank account a settlement lands in, 3 = the round-off / kasar account. Creating only row 1
        // produced `book SL account row 2 is missing` on the first cash sale.
        const legs: Array<{ srNo: number; acCode: string }> = b.slots ?? [
          { srNo: 1, acCode: b.acCode },
          { srNo: 2, acCode: 'CASH' },
          { srNo: 3, acCode: 'ROUNDOFF' },
        ];
        // N240 (G252): Data Type 'A' and the account's name, as MS_BOOK's save writes them (MS_BOOK.cs:2663, :2667).
        for (const leg of legs) {
          await tx.$executeRawUnsafe(
            `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME",
               "BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
             VALUES ($1::text,$2::text,$3,$4,$5,$6,$7,$8,$9,$10::text,
                     coalesce((SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1::text AND "CO_CODE"=$2::text
                                 AND "AC_CODE"=$10::text ORDER BY row_id LIMIT 1),''),'A')`,
            tenantId,
            coCode,
            lcCode,
            b.book,
            leg.srNo,
            b.name,
            b.shortName ?? b.book,
            mainBook,
            inout,
            leg.acCode,
          );
        }
        books += 1;
      }
    }
    if (await absent('SRNO_MAST', '"CO_CODE"=$2 AND "LC_CODE"=$3', coCode, lcCode)) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO") VALUES ($1,$2,$3,0,0)`,
        tenantId,
        coCode,
        lcCode,
      );
      srno = true;
    }
    // A company with no LOCATION cannot be selected: resolveLoginScope() cannot build a scope without
    // one, and /context/select answers `location-unavailable`. Provisioning previously created the books
    // and accounts but not the location, so a provisioned company was unreachable through the UI.
    if (await absent('LOCT_MAST', '"CO_CODE"=$2 AND "LC_CODE"=$3', coCode, lcCode)) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE") VALUES ($1,$2,$3,$4,$5)`,
        tenantId,
        coCode,
        lcCode,
        'Main Counter',
        // The branch account TR_INOUT posts stock in/out against (MS_LOCT.cs:3458; N91/G105).
        'BRANCH',
      );
      locality = true;
    }
    // Likewise a fiscal year: businessScope.year() filters by company, and without a row every business
    // endpoint answers `scope-incomplete`.
    if (await absent('YEAR_MAST', '"CO_CODE"=$2', coCode)) {
      const startYear = new Date().getMonth() + 1 >= 4 ? y : y - 1;
      await tx.$executeRawUnsafe(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,$4,$5)`,
        tenantId,
        coCode,
        `${startYear}-${startYear + 1}`,
        new Date(Date.UTC(startYear, 3, 1)),
        new Date(Date.UTC(startYear + 1, 2, 31)),
      );
      year = true;
    }
    if (await absent('CO_SET', '"CO_CODE"=$2', coCode)) {
      // The desktop never leaves the amount types NULL. The schema upgrade backfills them
      // (Ac_Image.cs:6221 `SL_AMT_TYPE = 'N'`, :7101 `PR_AMT_TYPE = 'F'`) and company open repeats
      // it in memory (MS_OPNCOMP.cs:881-888). The loader applies the same defaults to a blank
      // value, but storing them here makes a web company's CO_SET read like a desktop one.
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","SL_AMT_TYPE","PR_AMT_TYPE") VALUES ($1,$2,'N','F')`,
        tenantId,
        coCode,
      );
      coSet = true;
    }
    return { coCode, created: { coMast, accounts, taxes, books, srno, coSet, locality, year } };
  });
}
