# Menu, report and data coverage registers

> Frozen 10 September inventory. Current implementation/availability and scanner corrections are in [the 11 September review](11-current-completion-review.md); follow [the execution continuation](12-execution-addendum.md). Retain these source identities while revalidating all current web mappings.

These are separate denominators. Menu entries, source forms, report screens, report templates and database tables cannot be added into a single parity percentage. Historical statuses are copied for traceability and require revalidation.

## All 198 retained menu entries

Several absence labels are already stale (for example bill profit and stock-level reports have newer implementations). Even a corrected mapping remains unverified until its mode and workflow pass.

| Menu | Retained state | Desktop candidate | Web candidate |
| --- | --- | --- | --- |
| Analysis/Bill Os Day | implemented-unverified | RP_INOUT | {'kind': 'route', 'surface': 'GET /reports/outstanding'} |
| Analysis/Delete Data | absent | RP_ORDER | unmapped |
| Analysis/Last Visit | absent | RP_CUST | unmapped |
| Analysis/Order Zoom | implemented-unverified | RP_ORDER | {'kind': 'route', 'surface': 'GET /reports/order-lot-zoom'} |
| Analysis/Party InOut | implemented-unverified | RP_INOUT | {'kind': 'route', 'surface': 'GET /reports/party-statement'} |
| Analysis/Stock Ledger | implemented-unverified | RP_INOUT | {'kind': 'route', 'surface': 'GET /reports/item-stock-ledger'} |
| Analysis/Stock Move | absent | RP_STK_MOVE | unmapped |
| Analysis/Tag Detail | implemented-unverified | RP_TAG | {'kind': 'route', 'surface': 'GET /reports/tag-stock'} |
| Company/Account Group | implemented-unverified | MS_AC_GROUP | {'kind': 'master', 'surface': 'ac-groups'} |
| Company/Admin Setting | implemented-unverified | UT_SET_ADMIN | {'kind': 'route', 'surface': 'GET /settings'} |
| Company/Balance TrFr | absent | MS_BOOK | unmapped |
| Company/Books | implemented-unverified | MS_BOOK | {'kind': 'master', 'surface': 'books'} |
| Company/Company | implemented-unverified | MS_COMPANY | {'kind': 'master', 'surface': 'companies'} |
| Company/Data Backup | implemented-unverified | UT_BKP | {'kind': 'route', 'surface': 'GET /backup'} |
| Company/Data Refresh | implemented-unverified | MS_UPDATE | {'kind': 'route', 'surface': 'GET /utilities/data-repair/operations'} |
| Company/Location | implemented-unverified | MS_LOCT | {'kind': 'master', 'surface': 'locations'} |
| Company/Main Menu | implemented-unverified |  | {'kind': 'page', 'surface': 'web/apps/web/app/(app)/dashboard/page.tsx'} |
| Company/Menu Set | implemented-unverified | MS_WINDOW_SET | {'kind': 'route', 'surface': 'GET /utilities/window-tiles'} |
| Company/Setting | implemented-unverified | UT_SETTING | {'kind': 'route', 'surface': 'GET /settings'} |
| Company/Setting Main | implemented-unverified | UT_SETTING_MAIN | {'kind': 'route', 'surface': 'GET /settings'} |
| Company/Trade Master | implemented-unverified | MS_TRADE | {'kind': 'master', 'surface': 'trade'} |
| Company/User Create | implemented-unverified | MS_USER | {'kind': 'route', 'surface': 'GET /admin/users'} |
| Company/Year Create | implemented-unverified | MS_YEAR | {'kind': 'route', 'surface': 'POST /years'} |
| Company/Year Select | implemented-unverified |  | {'kind': 'route', 'surface': 'POST /context/select'} |
| Crm/Cust Entry | implemented-unverified | RP_CUST_CRM | {'kind': 'route', 'surface': 'GET /reports/customer-crm'} |
| Crm/Cust Report | implemented-unverified | RP_CUST_CRM | {'kind': 'route', 'surface': 'GET /reports/customer-crm'} |
| Dhiran/Dhiran Report | absent | RP_DHRN_LOAN | unmapped |
| Dhiran/Dhrn Due | implemented-unverified | RP_DHRN_OS | {'kind': 'route', 'surface': 'GET /reports/dhrn-outstanding'} |
| Dhiran/Dhrn Issue | implemented-unverified | TR_DHRN_ISU | {'kind': 'route', 'surface': 'POST /dhrn/issue'} |
| Dhiran/Dhrn Os Letter | implemented-unverified | TR_DHRN_INTREC | {'kind': 'route', 'surface': 'GET /dhrn/khata'} |
| Dhiran/Dhrn Rec | implemented-unverified | TR_DHRN_REC | {'kind': 'route', 'surface': 'POST /dhrn/receipt'} |
| Dhiran/Intrest All | implemented-unverified | RP_DHRN_OS | {'kind': 'route', 'surface': 'GET /reports/dhrn-outstanding'} |
| Dhiran/Intrest Isu All | implemented-unverified | RP_DHRN_OS | {'kind': 'route', 'surface': 'GET /reports/dhrn-outstanding'} |
| Dhiran/Intrest Rec | implemented-unverified | TR_DHRN_INTREC | {'kind': 'route', 'surface': 'POST /dhrn/interest'} |
| Dhiran/Loan Intrest | implemented-unverified | TR_DHRN_INTREC | {'kind': 'route', 'surface': 'POST /dhrn/interest'} |
| Dhiran/Loan Issue | absent | TR_DHRN_REC | unmapped |
| Dhiran/Loan Received | absent | TR_DHRN_ISU | unmapped |
| Dhiran/Loan Report | absent | RP_DHRN_LOAN | unmapped |
| ExtraTran/Amt In | implemented-unverified | TR_LOCT_AMT | {'kind': 'route', 'surface': 'POST /finance/location-amount'} |
| ExtraTran/Amt Out | implemented-unverified | TR_LOCT_AMT | {'kind': 'route', 'surface': 'POST /finance/location-amount'} |
| ExtraTran/Approval Isu | implemented-unverified | TR_APR_ISU | {'kind': 'route', 'surface': 'POST /tour/issue'} |
| ExtraTran/Approval Rtn | implemented-unverified | TR_APR_ISU | {'kind': 'route', 'surface': 'POST /tour/return'} |
| ExtraTran/Bill Wise Rec | implemented-unverified | TR_BILL_TO | {'kind': 'route', 'surface': 'POST /bill-to-bill/settle'} |
| ExtraTran/Card Rec | implemented-unverified | TR_CARD_REC | {'kind': 'route', 'surface': 'POST /receipts'} |
| ExtraTran/Consi Isu | implemented-unverified | TR_APR_ISU | {'kind': 'route', 'surface': 'POST /tour/issue'} |
| ExtraTran/Consi Purc | absent | TR_PR_SL_UAE | unmapped |
| ExtraTran/Consi Rec | implemented-unverified | TR_APR_ISU | {'kind': 'route', 'surface': 'POST /tour/return'} |
| ExtraTran/Employee Jv | implemented-unverified | TR_EMP_JV | {'kind': 'route', 'surface': 'POST /employee-jv'} |
| ExtraTran/Fine Jv Entry | implemented-unverified | TR_CONTRA | {'kind': 'route', 'surface': 'POST /fine-jv'} |
| ExtraTran/Fine Purc | implemented-unverified | TR_FINE_SL_PR | {'kind': 'route', 'surface': 'POST /fine-sale'} |
| ExtraTran/Fine Sales | implemented-unverified | TR_FINE_SL_PR | {'kind': 'route', 'surface': 'POST /fine-sale'} |
| ExtraTran/Labour Work | implemented-unverified | TR_SALE_LBR | {'kind': 'route', 'surface': 'POST /labour-invoice'} |
| ExtraTran/Old Item Sales | absent | TR_PURC | unmapped |
| ExtraTran/Other Expenses | implemented-unverified | TR_OTH_PURC | {'kind': 'route', 'surface': 'POST /other-purchase'} |
| ExtraTran/Other Income | absent | TR_OTH_PURC | unmapped |
| ExtraTran/Service Comm | implemented-unverified | TR_OTH_COMM | {'kind': 'route', 'surface': 'POST /other-commission'} |
| ExtraTran/Tag Wise Purc | implemented-unverified | TR_PURC_HM | {'kind': 'page', 'surface': 'web/apps/web/app/(app)/txn/purchase-hm/page.tsx'} |
| ExtraTran/Vp Adjust | implemented-unverified | TR_VP_ADJ | {'kind': 'route', 'surface': 'POST /finance/vp-adjustment'} |
| ExtraTran/Vp Parcel | implemented-unverified | TR_VP | {'kind': 'route', 'surface': 'POST /sales/vp-parcel'} |
| Karigar/Cust Repar Isu | implemented-unverified | TR_REP_REC | {'kind': 'route', 'surface': 'POST /repair-customer-issues'} |
| Karigar/Cust Repar Rec | implemented-unverified | TR_REP_REC | {'kind': 'route', 'surface': 'POST /repair-receipts'} |
| Karigar/Kr Design Isu | implemented-unverified | TR_APR_ISU | {'kind': 'route', 'surface': 'POST /mfg/order-issue'} |
| Karigar/Kr Issue | implemented-unverified | TR_KR_ISU | {'kind': 'route', 'surface': 'POST /karigar/issue'} |
| Karigar/Kr Received | implemented-unverified | TR_PURC | {'kind': 'route', 'surface': 'POST /karigar/receive'} |
| Karigar/Kr Repar Isu | implemented-unverified | TR_REP_REC | {'kind': 'route', 'surface': 'POST /repair-karigar-issues'} |
| Karigar/Kr Repar Rec | implemented-unverified | TR_REP_REC | {'kind': 'route', 'surface': 'POST /repair-karigar-receipts'} |
| Karigar/Kr Report | absent | RP_ALL | unmapped |
| Karigar/Reparing Rpt | absent | RP_ALL | unmapped |
| Karigar/Stock Isu | implemented-unverified | TR_TOUR | {'kind': 'route', 'surface': 'POST /tour/issue'} |
| Karigar/Stock Rec | implemented-unverified | TR_TOUR | {'kind': 'route', 'surface': 'POST /tour/return'} |
| Karigar/Tour Order | absent |  | unmapped |
| Karigar/Tour Report | absent | RP_TOUR_ZOOM | unmapped |
| Karigar/Tour Sales | implemented-unverified | TR_TOUR | {'kind': 'route', 'surface': 'POST /tour/:vchNo/bill'} |
| Karigar/Tour Tag | absent | RP_TOUR_ZOOM | unmapped |
| Master/Address | implemented-unverified | MS_ADD_MAST | {'kind': 'master', 'surface': 'addresses'} |
| Master/AutoItem | implemented-unverified | MS_AUTO_ITEM | {'kind': 'route', 'surface': 'POST /masters/auto-item'} |
| Master/Counter | implemented-unverified | MS_PRODUCT | {'kind': 'master', 'surface': 'counters'} |
| Master/Design Book | implemented-unverified | MS_PRODUCT | {'kind': 'route', 'surface': 'GET /masters/design-book'} |
| Master/Diamond | implemented-unverified | MS_DM | {'kind': 'master', 'surface': 'diamonds'} |
| Master/Dm Size | absent | MS_STK_LIMIT | unmapped |
| Master/Employee | implemented-unverified | MS_EMP | {'kind': 'master', 'surface': 'employees'} |
| Master/Group | implemented-unverified | MS_GROUP | {'kind': 'master', 'surface': 'groups'} |
| Master/Item | implemented-unverified | MS_ITEM | {'kind': 'master', 'surface': 'items'} |
| Master/Item Opening | implemented-unverified | TR_ITM_OPBL | {'kind': 'route', 'surface': 'POST /stock/item-opening'} |
| Master/Item Touch | implemented-unverified | MS_AUTO_ITEM | {'kind': 'master', 'surface': 'touch'} |
| Master/ItStk Limit | absent | MS_STK_LIMIT | unmapped |
| Master/Labour | implemented-unverified | MS_AUTO_ITEM | {'kind': 'route', 'surface': 'GET /labour-update'} |
| Master/Labour Disc | implemented-unverified | MS_AUTO_ITEM | {'kind': 'route', 'surface': 'GET /labour-update'} |
| Master/Labour Type | implemented-unverified | MS_LBR_TYPE | {'kind': 'master', 'surface': 'labour'} |
| Master/Lot Opening | implemented-unverified | MS_PRODUCT | {'kind': 'route', 'surface': 'POST /stock/item-lot'} |
| Master/Party | implemented-unverified | MS_ACCT | {'kind': 'page', 'surface': 'web/apps/web/app/(app)/masters/party/page.tsx'} |
| Master/Party Opening | implemented-unverified | TR_AC_OPBL | {'kind': 'route', 'surface': 'POST /ac-opbl'} |
| Master/Point Mast | implemented-unverified | MS_POINT | {'kind': 'master', 'surface': 'points'} |
| Master/Product | implemented-unverified | MS_PRODUCT | {'kind': 'master', 'surface': 'products'} |
| Master/Style | implemented-unverified | MS_STYLE | {'kind': 'master', 'surface': 'styles'} |
| Master/Tag Opening | implemented-unverified |  | {'kind': 'route', 'surface': 'POST /stock/tag-opening'} |
| Master/Tax | implemented-unverified | MS_TAX | {'kind': 'master', 'surface': 'taxes'} |
| Mfg/Lot IsuRec | absent | RP_MFG_ZOOM | unmapped |
| Mfg/Mfg InOut | absent | RP_MFG_ZOOM | unmapped |
| Mfg/Mfg Ledger | absent | RP_LEDR, RP_MFG_LEDR | unmapped |
| Mfg/Mfg Mast | implemented-unverified | MS_MFG_MAST | {'kind': 'master', 'surface': 'mfg'} |
| More/Bill Wise Profit | absent | RP_BILL_PROFIT | unmapped |
| More/Deisgn Move | absent | RP_STK_MOVE | unmapped |
| More/Emp Sale | implemented-unverified | RP_EMP | {'kind': 'route', 'surface': 'GET /reports/employee-sales'} |
| More/Entry Check | absent | RP_USER | unmapped |
| More/Graph Report | absent | RP_GRAPH | unmapped |
| More/ItStk Level | absent | RP_STK_LEVEL | unmapped |
| More/Lot Report | implemented-unverified | RP_ORDER | {'kind': 'route', 'surface': 'GET /reports/order-lot-zoom'} |
| More/Movement | implemented-unverified | RP_MOVEMENT | {'kind': 'route', 'surface': 'GET /reports/item-stock-ledger'} |
| More/Order Track | absent | RP_ORD_TRACK | unmapped |
| More/Oth Itm Rpt | absent | RP_OTH_DETL | unmapped |
| More/Point Report | absent | RP_ORDER | unmapped |
| More/User Report | absent | RP_USER | unmapped |
| Other/Bank Reconcile | implemented-unverified | UT_BANK | {'kind': 'route', 'surface': 'GET /bank-recon'} |
| Other/Counter Trfr | implemented-unverified | TR_PHYSTK | {'kind': 'route', 'surface': 'POST /stock/counter-transfer'} |
| Other/Daily Rate | implemented-unverified | MS_RATE | {'kind': 'route', 'surface': 'POST /daily-rate'} |
| Other/Data Export | absent | UT_EXPORT | unmapped |
| Other/Data Import | implemented-unverified | UT_IMPORT | {'kind': 'route', 'surface': 'POST /masters/:name/import'} |
| Other/E-Excel | absent | UT_E_INVOICE | unmapped |
| Other/Estimate Reset | absent | UT_IMPORT | unmapped |
| Other/Labour Update | implemented-unverified | MS_AUTO_ITEM | {'kind': 'route', 'surface': 'GET /labour-update'} |
| Other/Ledger Adjust | implemented-unverified | UT_E_INVOICE | {'kind': 'route', 'surface': 'POST /ledger-adjust'} |
| Other/Only Tag Entry | implemented-unverified |  | {'kind': 'route', 'surface': 'POST /stock/tag-opening'} |
| Other/Order Cancel | implemented-unverified | TR_SL_ORD_ADJ | {'kind': 'route', 'surface': 'POST /sales-orders/:vchNo/cancel-refund'} |
| Other/Physical Stock | implemented-unverified |  | {'kind': 'route', 'surface': 'POST /stock/physical-stock'} |
| Other/Reminder Entry | implemented-unverified | UT_REMINDER | {'kind': 'route', 'surface': 'POST /reminder-entries'} |
| Other/Sms | implemented-unverified | UT_SMS | {'kind': 'route', 'surface': 'POST /integrations/notify'} |
| Other/Stock Adjust | implemented-unverified | TR_TAG_CAN | {'kind': 'route', 'surface': 'POST /stock/adjust'} |
| Other/Stone/Dm-Cf | absent | TR_PHYSTK | unmapped |
| Other/Tag Adjust | absent | TR_TAG_CAN | unmapped |
| Other/Tag Cancel | implemented-unverified | UT_TAG_PRINT | {'kind': 'route', 'surface': 'POST /stock/tag-cancel'} |
| Other/Tag Print | implemented-unverified | UT_TAG_PRINT | {'kind': 'route', 'surface': 'GET /stock/tag-print'} |
| Other/Tag Split | implemented-unverified |  | {'kind': 'route', 'surface': 'POST /stock/tag-split'} |
| Other/Tag Transfer | implemented-unverified | TR_TAG_CAN | {'kind': 'route', 'surface': 'POST /stock/tag-transfer'} |
| Other/Tag Wt Change | implemented-unverified |  | {'kind': 'route', 'surface': 'POST /stock/tag-weight-diff'} |
| Other/Vch ReNumber | implemented-unverified | UT_VCH_RE_NUMBR | {'kind': 'route', 'surface': 'GET /utilities/vch-renumber/preview'} |
| Other/Whatsapp | implemented-unverified |  | {'kind': 'route', 'surface': 'POST /integrations/notify'} |
| Report/Address Print | absent | RP_ADDRESS | unmapped |
| Report/Approval Rpt | absent | RP_ALL | unmapped |
| Report/Bul Report | absent | RP_ALL | unmapped |
| Report/Cash Bank | implemented-unverified | RP_CASH_BANK | {'kind': 'route', 'surface': 'GET /reports/cash-book'} |
| Report/Consi Report | absent | RP_CONSI_APR | unmapped |
| Report/Final Reports | absent | RP_BALANCE | unmapped |
| Report/Gst Report | absent | RP_TAX | unmapped |
| Report/HuId Report | implemented-unverified | RP_HUID | {'kind': 'route', 'surface': 'GET /reports/tag-stock'} |
| Report/Item InOut | implemented-unverified | RP_ALL | {'kind': 'route', 'surface': 'GET /reports/item-stock-ledger'} |
| Report/Ledger Report | implemented-unverified | RP_LEDR | {'kind': 'route', 'surface': 'GET /reports/account-ledger/:acCode'} |
| Report/Old Stock | absent | RP_SLPR_ZOOM | unmapped |
| Report/Order Report | implemented-unverified | RP_ALL | {'kind': 'route', 'surface': 'GET /sales-orders'} |
| Report/Party Os | implemented-unverified | RP_OS | {'kind': 'route', 'surface': 'GET /reports/outstanding'} |
| Report/Purc Zoom | implemented-unverified | RP_SLPR_ZOOM | {'kind': 'route', 'surface': 'GET /reports/purchase-register'} |
| Report/Purchase Rpt | implemented-unverified | RP_ALL | {'kind': 'route', 'surface': 'GET /reports/purchase-register'} |
| Report/Reminder Rpt | implemented-unverified | MS_RATE, RP_REMINDER | {'kind': 'route', 'surface': 'GET /reminders'} |
| Report/Rojmel | implemented-unverified | RP_ROJMEL | {'kind': 'route', 'surface': 'GET /reports/rojmel'} |
| Report/Sale Zoom | implemented-unverified | RP_SLPR_ZOOM | {'kind': 'route', 'surface': 'GET /reports/sales-register'} |
| Report/Sales Report | implemented-unverified | RP_ALL | {'kind': 'route', 'surface': 'GET /reports/sales-register'} |
| Report/Stock Report | implemented-unverified | RP_STOCK | {'kind': 'route', 'surface': 'GET /reports/tag-stock'} |
| Report/Stock With Fine | implemented-unverified | RP_STOCK_FINE | {'kind': 'route', 'surface': 'GET /reports/stock-valuation'} |
| Report/Tag Estmate | implemented-unverified | RP_TAG_ESTMATE | {'kind': 'route', 'surface': 'GET /reports/tag-estimate'} |
| Report/Tag Image | implemented-unverified | RP_TAG_IMAGE | {'kind': 'route', 'surface': 'GET /stock/tag-image'} |
| Report/Tag Stock | implemented-unverified | RP_TAG | {'kind': 'route', 'surface': 'GET /reports/tag-stock'} |
| Report/Trading Report | absent | RP_TRADING | unmapped |
| Report/Vp Report | absent | RP_ALL | unmapped |
| Scheme/Branch InOut | absent | RP_LC_INOUT | unmapped |
| Scheme/Day Sales | implemented-unverified | RP_LC_SALE | {'kind': 'route', 'surface': 'GET /reports/daily-sales'} |
| Scheme/Gold Adjust | absent | TR_MEMB_ADJ | unmapped |
| Scheme/Memb Adjust | implemented-unverified | TR_MEMB_ADJ | {'kind': 'route', 'surface': 'POST /scheme/maturity'} |
| Scheme/Memb Entry | implemented-unverified | TR_MEMB_ENT | {'kind': 'route', 'surface': 'POST /scheme/installment'} |
| Scheme/Memb Opening | implemented-unverified | TR_MEMB_ENT | {'kind': 'route', 'surface': 'POST /scheme/opening'} |
| Scheme/Member Mast | implemented-unverified | MS_MEMB | {'kind': 'route', 'surface': 'POST /members'} |
| Scheme/Monthly Report | absent | RP_STK_LEVEL | unmapped |
| Scheme/Scheme Ledger | implemented-unverified | RP_CASH_BANK | {'kind': 'route', 'surface': 'GET /scheme/passbook'} |
| Scheme/Scheme Mast | implemented-unverified | MS_PRODUCT | {'kind': 'master', 'surface': 'schemes'} |
| Scheme/Scheme Report | implemented-unverified | RP_ALL | {'kind': 'route', 'surface': 'GET /reports/scheme-adjustments'} |
| Transaction/Bank Payment | implemented-unverified | TR_CASH | {'kind': 'route', 'surface': 'POST /payments'} |
| Transaction/Bank Received | implemented-unverified | TR_CASH | {'kind': 'route', 'surface': 'POST /receipts'} |
| Transaction/Bul LcBook | implemented-unverified | TR_BUL_BOOKING | {'kind': 'route', 'surface': 'POST /bullion/booking'} |
| Transaction/Bul Sales | absent | TR_BUL_SALE | unmapped |
| Transaction/Cash Payment | implemented-unverified | TR_CASH | {'kind': 'route', 'surface': 'POST /payments'} |
| Transaction/Cash Received | implemented-unverified | TR_CASH | {'kind': 'route', 'surface': 'POST /receipts'} |
| Transaction/Contra Entry | implemented-unverified | TR_CONTRA | {'kind': 'route', 'surface': 'POST /contra'} |
| Transaction/E CrntNote | absent | TR_SL_EBILL | unmapped |
| Transaction/E Invoice | implemented-unverified | TR_SL_EBILL | {'kind': 'route', 'surface': 'POST /einvoice/irn'} |
| Transaction/Pr Quotation | absent | TR_PURC | unmapped |
| Transaction/Purc Booking | implemented-unverified | TR_BUL_BOOKING | {'kind': 'route', 'surface': 'POST /bullion/booking'} |
| Transaction/Purchase | implemented-unverified | TR_PURC, TR_PURC_HM | {'kind': 'route', 'surface': 'POST /purchases'} |
| Transaction/Purchase Rtn | implemented-unverified | TR_KR_ISU | {'kind': 'route', 'surface': 'POST /purchase-returns'} |
| Transaction/Rate Cut | implemented-unverified | TR_WH_SALE | {'kind': 'route', 'surface': 'POST /rate-cut'} |
| Transaction/Sale Booking | implemented-unverified | TR_BUL_BOOKING | {'kind': 'route', 'surface': 'POST /bullion/booking'} |
| Transaction/Sales | implemented-unverified | TR_SALE_HM | {'kind': 'route', 'surface': 'POST /sales'} |
| Transaction/Sales Order | implemented-unverified | TR_SALE_ORD | {'kind': 'route', 'surface': 'POST /sales-orders'} |
| Transaction/Sales Return | implemented-unverified |  | {'kind': 'route', 'surface': 'POST /sales-returns'} |
| Transaction/Sl Quotation | absent | TR_SALE | unmapped |
| Transaction/Stock In | absent |  | unmapped |
| Transaction/Stock Out | absent |  | unmapped |
| Transaction/Wh Quotation | implemented-unverified | TR_WH_SALE | {'kind': 'page', 'surface': 'web/apps/web/app/(app)/txn/wholesale-sale/page.tsx'} |
| Transaction/Wh Sales | implemented-unverified | TR_WH_SALE | {'kind': 'page', 'surface': 'web/apps/web/app/(app)/txn/wholesale-sale/page.tsx'} |
| Transaction/Wh Sl Return | implemented-unverified | TR_WH_SALE_RTN | {'kind': 'route', 'surface': 'POST /sales/wholesale-sale-return'} |

## All 275 retained report references

255 supplied Crystal names plus 20 absent referenced names. Validate the absent names against the original installation; they may be dynamic names, edition variants, missing files, or obsolete references. An absent reference is unresolved scope, not automatically a supported screen. Binary/spec presence below is checked now; semantic binding and desktop comparison remain unverified.

| Report | Kind | Binary present | Web spec present | Retained binder candidate |
| --- | --- | --- | --- | --- |
| AcCrList | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcDrList | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcFineGold | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcFineSilver | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcGroupRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcLastVisit | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcLedger | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcLedgerSelected | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcOsArea | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcOsWithAdd | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcPurcRpt | supplied-crystal | True | True | PR_DATA |
| AcPurcSummRpt | supplied-crystal | True | True | PR_DATA |
| AcPurcWhRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcSaleWhRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcSummLdr | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcWithWt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcWithWtGold | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AcWithWtSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AngdiyaIsuRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AprBill | supplied-crystal | True | True | PR_DATA |
| AprInOut | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AprPan | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| AprPartyWise | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| B2BPurcBillA4Tax | supplied-crystal | True | True | PR_DATA |
| B2BPurcImgVch | supplied-crystal | True | True | PR_DATA |
| B2BSaleBillA4Tax | supplied-crystal | True | True | SL_DATA |
| B2BSaleImgVch | supplied-crystal | True | True | SL_DATA |
| BalanceHz | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| BarPrint10 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| BarPrint13 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| BillRecVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| BillWiseOrderAdjust | supplied-crystal | True | True | SL_DATA |
| BulCustAdjust | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| BulCustBooking | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| BullBookBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CashBankBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CashBankBillAc | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ChqPrint010 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ChqPrint011 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ChqPrint012 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ChqPrint013 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ChqPrint014 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ChqPrint135 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CntrTagStkRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CntrTagSumRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| Company | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ConsiBill | supplied-crystal | True | True | PR_DATA |
| ContraBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CounterSale | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CounterTrfr | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CustRepIsu | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CustRepRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| CustRepRecBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DharnDue | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhiranIssuRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhiranitemRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhiranReg | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhiranStock | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhrnIntRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhrnIssue | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhrnIssueImg | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhrnKhataVahi | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhrnKhataVahiSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhrnOsLetter | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DhrnReceivedSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| DiamondSf | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| EInvoice | supplied-crystal | True | True | SL_DATA |
| EInvOthIncom | supplied-crystal | True | True | SL_DATA |
| EmpIsuRecVch | supplied-crystal | True | True | PR_DATA |
| EmpSaleReport | supplied-crystal | True | True | SL_DATA |
| FineJvBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| FineSalesGstBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| Form12 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| Form8 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| GhatDesignIsu | supplied-crystal | True | True | PR_DATA |
| GhatTagPrnt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| GoldInterest | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| GroupStkRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| Gstr_1 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| Gstr_2 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| Gstr_3 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| HedgingFixVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| InTax_PurcRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItemInOut | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItemInOutSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItemInword | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItemLedger | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItemOutword | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItemPurcVch | supplied-crystal | True | True | PR_DATA |
| ItemSalesVch | supplied-crystal | True | True | SL_DATA |
| ItemSalesVchWithQr | supplied-crystal | True | True | SL_DATA |
| ItemStkRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItmLotPrint | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItmStkBalance | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItmStkWithGrid | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ItmStkWithOthWt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JadtarInOut | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JadtarIssue | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JadtarRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JdtProcessRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JmUdAmt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JmUdFine | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JmUdFineHz | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JmUdFineHzSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JmUdFineHzSummVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JmUdFineSl | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JmUdFineSlHz | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| JmUdFineSlSum | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| KrDesignIsuImg | supplied-crystal | True | True | PR_DATA |
| KrDesignIsuVch | supplied-crystal | True | True | PR_DATA |
| KrDmIsuRec | supplied-crystal | True | True | KR_DATA |
| KrDmWtInOut | supplied-crystal | True | True | KR_DATA |
| KrIsuBill | supplied-crystal | True | True | KR_DATA |
| KrIsuBillGst | supplied-crystal | True | True | KR_DATA |
| KrRecVch | supplied-crystal | True | True | KR_DATA |
| KrRecVchGst | supplied-crystal | True | True | KR_DATA |
| KrRepRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LabourBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LabourBillGst | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LabourWorkVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LbrWorkRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LedrAdjVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LedrInOut | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LedrInOutWh | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LoanStock | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| LoanWisePacket | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembBonus | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembCommRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembDailyRecRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembGoldRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembOpenNew | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembQr | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembRptAdd | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MembVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MfgGhatIsu | supplied-crystal | True | True | PR_DATA |
| MfgGhatRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MfgLedger | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MfgMinoIsuRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MfgVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| MtlIsu | supplied-crystal | True | True | KR_DATA |
| OldItmSaleVch | supplied-crystal | True | True | KR_DATA |
| OrdAdjBillWise | supplied-crystal | True | True | SL_DATA |
| OrdAdvAdj | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OrdAdvRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OrdDesignSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OrdDetlPanding | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OrdDetlRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OrderBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OrderCancelVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OrderVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OrdVchImg | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OthCommVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OthExpUae | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OthItmLoose | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OthItmStud | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| OutTax_SaleRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| PartyInterest | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| PartyIntSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| PaymentVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ProdStkRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ProfitLossHz | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| PrRtnBill | supplied-crystal | True | True | PR_DATA |
| PrRtnBillGst | supplied-crystal | True | True | PR_DATA |
| PrTaxRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| PurcBillA4 | supplied-crystal | True | True | PR_DATA |
| PurcBillA4Gst | supplied-crystal | True | True | PR_DATA |
| PurcBillHalfGst | supplied-crystal | True | True | PR_DATA |
| PurcGroupWise | supplied-crystal | True | True | PR_DATA |
| PurcItem | supplied-crystal | True | True | PR_DATA |
| PurcReport | supplied-crystal | True | True | PR_DATA |
| PurcSumm | supplied-crystal | True | True | PR_DATA |
| PurcToSalesFixingVch | supplied-crystal | True | True | PR_DATA |
| QrPrint10 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RateCutBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RateCutItmBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RateRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ReminderAll | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ReparingCustIsu | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ReparingKrRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| ReparingRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RojMel | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RojMelCash | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RojMelCrDr | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RojMelEstmat | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RojMelGr | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RojMelItem | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RojMelJmaUdhar | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| RtlHuidPrint | supplied-crystal | True | True | SL_DATA |
| SafeStkSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| SalarySlip | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| SaleOrnaIsu | supplied-crystal | True | True | SL_DATA |
| SaleReport | supplied-crystal | True | True | SL_DATA |
| SaleRtnReport | supplied-crystal | True | True | SL_DATA |
| SalesBillA4 | supplied-crystal | True | True | SL_DATA |
| SalesBillA4_WithImage | supplied-crystal | True | True | SL_DATA |
| SalesBillA4Gst | supplied-crystal | True | True | SL_DATA |
| SalesBillHz | supplied-crystal | True | True | SL_DATA |
| SalesBillHzGst | supplied-crystal | True | True | SL_DATA |
| SalesBillOrgDup | supplied-crystal | True | True | SL_DATA |
| SalesBillOs | supplied-crystal | True | True | SL_DATA |
| SalesBillVr | supplied-crystal | True | True | SL_DATA |
| SalesGroupWise | supplied-crystal | True | True | SL_DATA |
| SalesItem | supplied-crystal | True | True | SL_DATA |
| SalesQuotation | supplied-crystal | True | True | SL_DATA |
| SalesRtnA4 | supplied-crystal | True | True | SL_DATA |
| SalesRtnA4Gst | supplied-crystal | True | True | SL_DATA |
| SalesRtnBillUae | supplied-crystal | True | True | SL_DATA |
| SalesRtnItem | supplied-crystal | True | True | SL_DATA |
| SalesRtnSumm | supplied-crystal | True | True | SL_DATA |
| SalesSumm | supplied-crystal | True | True | SL_DATA |
| SalesToPurcFixingVch | supplied-crystal | True | True | SL_DATA |
| SalesWithOrder | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| SchmAdj | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| SchmMonthRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| SchmPassBook | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| SchmRecVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| SlBillWapp | supplied-crystal | True | True | SL_DATA |
| SlTaxRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| StkInOutVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| StngIsuRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TableStkGwtRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagCanBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagHuIdRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagItmSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagReNumberVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagSplitVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagStkIdtlRpt | supplied-crystal | True | False | SL_DATA_DEFAULT_UNSAFE |
| TagStkItemSumRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagStkRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagStkRptDmSum | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagStkSummRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagWtChangeVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TagWtChangSplit | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TaxInOutRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TaxSummUae | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TempAdd2 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TempAdd3 | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TempPhone | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TourOrdImg | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TourOrdVch | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| TRialBalHz | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| UserDtlRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| VpAdjustBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| VpIsuRpt | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| WhHuidPrint | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| WhSalesBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| WhSalesBillSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| WhSalesEmp | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| WhSalesImage | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| WhSalesIsuRec | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| WhSalesRtnBill | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| WhSalesSumm | supplied-crystal | True | True | SL_DATA_DEFAULT_UNSAFE |
| aprbillimg | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| balzoom | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| bankadj | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| billwiseos | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| empdaysumm | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| empsumm | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| franchisebill | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| jdterskt | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| jdtvch | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| krisureport | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| krrecreport | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| loctamtvch | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| mainacsumm | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| mltingisu | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| purcquot | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| reminderschm | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| remindervch | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| salesrtna4print | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| vpparcelbill | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |
| whquotation | absent-referenced | False | False | SL_DATA_DEFAULT_UNSAFE |

## All retained desktop table units

This matrix has 146 table units; other historical schema reports count 145 initialised tables or larger restored schemas. P00/P12 must reconcile these sets against the actual source database, including shared/auxiliary databases, images, staging and audit tables. Every retained table below needs an ownership key, migration rule, comparison rule and disposition.

| Table | Category | Required disposition |
| --- | --- | --- |
| `AC_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `AC_GROUP` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `AC_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `ADD_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `AD_ADJ` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `AD_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `AD_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `AD_MEMB` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `AD_OS` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `APR_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `APR_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `APR_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BAL_GR` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BANK_RECONCILE` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BAR_CAN_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BAR_CAN_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BAR_CAN_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BAR_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BAR_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BAR_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BILL_OS_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BOOK_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BOOK_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BOOK_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `BUL_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CARD_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CASH_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `COL_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CONTRA_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CONV_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `COUNTRY_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CO_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CO_SET` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CO_SET_NEW` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CRNT_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CUT_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CUT_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `CUT_STK_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DELETE_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DESIGN_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DESIGN_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DESIGN_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DHRN_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DHRN_ISU_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DHRN_ISU_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DHRN_REC_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DHRN_REC_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DM_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DM_KR_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DM_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `DM_SIZE` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `EMP_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `EMP_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `E_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `E_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `FINE_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `GROUP_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `HDD_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `IMAGE_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `INOUT_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `INOUT_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `INOUT_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `ITEM_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `ITM_CITY` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `ITM_LOT_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `ITM_OPBL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `ITM_WT_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `KR_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `KR_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `KR_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LBR_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LBR_ISU_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LBR_ISU_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LBR_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LBR_REC_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LDR_ADJ_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LEDR_AC_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LOCT_AMT` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LOCT_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LOGIN_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `LOT_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MAIN_STOCK` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MFG_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MFG_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MFG_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MFG_ISU_REC` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MFG_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MLT_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MLT_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MODEL_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `MSG_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `OP_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `OP_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `OP_LDR` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `PAY_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `PAY_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `POINT_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `POINT_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `POINT_MEMB` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `PRINT_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `PRODUCT_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `PR_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `PR_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `PR_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `RATE_CUT_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `RATE_CUT_ISU` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `RATE_CUT_ISU_REC` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `RATE_CUT_REC` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `RATE_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `REM_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `REPORT_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `REP_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `REP_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `ROJMEL_BAL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `ROJ_MEL_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_DETL_RTN` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_ORD_ADJ` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_ORD_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_ORD_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_ORD_IDTL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SL_PR_DETL` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `SRNO_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `STATE_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TABLE_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TAG_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TAG_PRINT_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TAG_SET` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TAG_STOCK_PRINT` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TAG_SUM_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TAX_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TAX_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TEMP_ADD` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TEMP_AD_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TEMP_BOOK_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `TOUCH_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `UPI_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `USER_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `USER_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `USER_REQUEST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `VP_ADJ_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `WEB_DATA` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `WEIGHT_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
| `YEAR_MAST` | desktop-table | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |
