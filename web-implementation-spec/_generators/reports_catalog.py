#!/usr/bin/env python3
"""Group the 255 unified/reports/*.rpt into the 05_Reports catalog table.

Heuristic, ordered classification (first match wins) into the spec's domains, plus a render-type
(register dataset / bill-voucher print / label-barcode) and a web-status that is BUILT only when the
.rpt traces to a concrete dataset builder in apps/api/src/modules/reports (or accounting/gst/stock/
dhrn). Everything else is a PRINT template, a LABEL job, or 📋 SPEC. Run from repo root:

    python3 web-implementation-spec/_generators/reports_catalog.py
"""
import os, re, subprocess, sys

BASE = os.path.dirname(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))
RPT_DIR = os.path.join(BASE, "unified", "reports")

# --- .rpt → web dataset builder (BUILT). Traceable to a function + route in the web reference. ---
BUILT = {
    "SaleReport": "salesRegister (SL_DATA) · /reports/sales-register",
    "SalesSumm": "salesByParty (SL_DATA) · /reports/sales-by-party",
    "SalesItem": "salesByItem (SL_DETL) · /reports/sales-by-item",
    "SalesGroupWise": "salesByGroup (SL_DETL+ITEM_MAST) · /reports/sales-by-group",
    "SaleRtnReport": "salesReturnRegister (SL_DETL_RTN) · /reports/sales-return-register",
    "SalesRtnSumm": "salesReturnRegister (SL_DETL_RTN) · /reports/sales-return-register",
    "EmpSaleReport": "employeeSales (SL_DATA) · /reports/employee-sales",
    "PurcReport": "purchaseRegister (PR_DATA) · /reports/purchase-register",
    "PurcSumm": "purchaseByParty (PR_DATA) · /reports/purchase-by-party",
    "PurcItem": "purchaseByItem (PR_DETL) · /reports/purchase-by-item",
    "PurcGroupWise": "monthlyPurchase (PR_DATA) · /reports/monthly-purchase",
    "PrRtnBill": "purchaseReturnRegister (PR_DATA+BOOK_DATA) · /reports/purchase-return-register",
    "AcLedger": "accountLedger (AC_DATA) · /reports/account-ledger/:acCode",
    "AcLedgerSelected": "accountLedger (AC_DATA) · /reports/account-ledger/:acCode",
    "AcSumm": "accountBalances (AC_DATA) · /reports/account-balances",
    "AcSummLdr": "accountBalances (AC_DATA) · /reports/account-balances",
    "AcCrList": "outstandingReport (AC_DATA+AC_MAST) · /reports/outstanding",
    "AcDrList": "outstandingReport (AC_DATA+AC_MAST) · /reports/outstanding",
    "AcOsArea": "areaOutstanding (BILL_OS_DATA+AC_MAST) · /reports/area-outstanding",
    "AcOsWithAdd": "billOutstanding (BILL_OS_DATA) · /reports/bill-outstanding",
    "AcGroupRpt": "groupSummary (AC_DATA+AC_MAST+AC_GROUP) · /reports/group-summary",
    "AcLastVisit": "customerCrm (SL_DATA+AC_MAST) · /reports/customer-crm",
    "TRialBalHz": "trialBalance / trialBalanceFull (AC_DATA) · /reports/trial-balance[-full]",
    "BalanceHz": "balanceSheet (AC_DATA) · /reports/balance-sheet",
    "ProfitLossHz": "balanceSheet (AC_DATA, trading figure) · /reports/balance-sheet",
    "RojMel": "dayBook (AC_DATA) · /reports/day-book",
    "RojMelCash": "dayBook + cashDaySummary (AC_DATA) · /reports/day-book,/reports/cash-day-summary",
    "CashBankBill": "cashBook (AC_DATA) · /reports/cash-book",
    "CashBankBillAc": "cashBook (AC_DATA) · /reports/cash-book",
    "ContraBill": "contraRegister (AC_DATA+BOOK_DATA) · /reports/contra-register",
    "Gstr_1": "gstr1 (SL_DATA+SL_DETL+AC_MAST) · gst module",
    "Gstr_2": "gstr2Purchase (PR_DATA) · /reports/gstr2",
    "Gstr_3": "gstr3b (SL_DATA) · gst module",
    "OutTax_SaleRpt": "salesGstMonthly (SL_DATA) · /reports/sales-gst-monthly",
    "SlTaxRpt": "salesGstMonthly (SL_DATA) · /reports/sales-gst-monthly",
    "InTax_PurcRpt": "gstInputRegister (TAX_DATA) · /reports/gst-input-register",
    "PrTaxRpt": "gstInputRegister (TAX_DATA) · /reports/gst-input-register",
    "TaxInOutRpt": "salesGstMonthly + gstInputRegister · /reports/sales-gst-monthly,/reports/gst-input-register",
    "ItmStkBalance": "stockValuation (BAR_DETL) · /reports/stock-valuation",
    "ItemStkRpt": "stockValuation (BAR_DETL) · /reports/stock-valuation",
    "ItmStkWithGrid": "stockByLocation (BAR_DETL) · /reports/stock-by-location",
    "GroupStkRpt": "itemGroupStock (BAR_DETL+ITEM_MAST) · /reports/item-group-stock",
    "ItemLedger": "itemStockLedger (MAIN_STOCK) · /reports/item-stock-ledger",
    "ItemInOut": "itemStockLedger (MAIN_STOCK) · /reports/item-stock-ledger",
    "ItemInOutSumm": "itemStockLedger (MAIN_STOCK) · /reports/item-stock-ledger",
    "TagStkRpt": "stockValuation + listTags (BAR_DETL) · /reports/stock-valuation,/masters tags",
    "TagStkSummRpt": "stockValuation (BAR_DETL) · /reports/stock-valuation",
    "TagItmSumm": "itemGroupStock (BAR_DETL+ITEM_MAST) · /reports/item-group-stock",
    "RateRpt": "rateList (RATE_MAST) · /reports/rate-list",
    "DharnDue": "dhrnOutstandingList (DHRN_ISU_DATA+DHRN_REC_DATA) · /reports/dhrn-outstanding",
    "DhrnOsLetter": "dhrnOutstandingList (DHRN_ISU_DATA+DHRN_REC_DATA) · /reports/dhrn-outstanding",
    "DhrnReceivedSumm": "dhrnOutstandingList (DHRN_*) · /reports/dhrn-outstanding",
    "KrRecVch": "karigarStatement (KR_DETL) · /reports/karigar-statement",
    "KrRepRec": "karigarBalances (KR_DETL) · /reports/karigar-balances",
    "SchmAdj": "schemeAdjustments (AD_ADJ) · /reports/scheme-adjustments",
    "SchmMonthRpt": "schemeAdjustments (AD_ADJ) · /reports/scheme-adjustments",
    "MembCommRpt": "schemeAdjustments (AD_ADJ) · /reports/scheme-adjustments",
}

# Partial / aggregate coverage (a web builder covers part of the .rpt's scope).
PARTIAL = {
    "RojMelCrDr","RojMelItem","RojMelGr","RojMelEstmat","RojMelJmaUdhar",
    "SalesBillOs","AcWithWt","AcWithWtSumm","AcWithWtGold","AcFineGold","AcFineSilver",
    "TagStkItemSumRpt","TagStkIdtlRpt","CntrTagStkRpt","SafeStkSumm","ProdStkRpt",
    "ItemInword","ItemOutword","StkInOutVch","TableStkGwtRpt","ItmStkWithOthWt",
    "DhrnReg","DhrnStock","DhiranReg","PartyInterest","PartyIntSumm","GoldInterest",
    "KrDmWtInOut","MfgLedger","LbrWorkRpt","MembRpt","MembSumm","SalesQuotation",
    "JmUdFine","JmUdFineHz","JmUdFineSl","JmUdFineSlSum","JmUdAmt","JmUdFineHzSumm",
    "MonthlySales","SalesRtnItem","PurcToSalesFixingVch","SalesToPurcFixingVch",
}

# Ordered (regex, domain). First match wins. Patterns run on the lowercased base name.
DOMAIN_RULES = [
    (r"gstr|einv|tax|gst", "GST"),
    (r"dhrn|dhiran|dharn|loanstock|loanwisepacket|goldinterest|partyinterest|partyint", "Dhrn (Pledge/Loan)"),
    (r"memb|schm", "Membership/Scheme"),
    (r"tour", "Tour/Bullion"),
    (r"bul|bull|hedging|ratecut|fixing|rateRpt|raterpt|oz", "Tour/Bullion"),
    (r"mfg|ghat|jadtar|jdt|stng|mtlisu|mino|labour|lbr|reparing|custrep|salaryslip", "Manufacturing/Job-work"),
    (r"^kr|krdm|krisu|krrec|krrep|krdesign", "Manufacturing/Job-work"),
    (r"tag|barprint|qrprint|huid|cntr|counter", "Stock/Tag"),
    (r"stk|stock|itemledger|iteminout|iteminword|itemoutword|groupstk|prodstk|safestk|tablestk|diamond|jmud|table", "Stock/Tag"),
    (r"^itm|^item", "Stock/Tag"),
    (r"^ac|ledr|trialbal|balancehz|profitloss|form8|form12|cashbank|contra|payment|billrec|finejv|reminder|os\b|angdiya", "Accounting/Ledger"),
    (r"rojmel|daywork", "Accounting/Ledger"),
    (r"purc|^pr|^b2bpurc|consi|inout|ledrinout", "Purchase"),
    (r"sale|^sl|^b2bsale|^wh|order|^ord|quotation|apr|^vp|consi|orna|emp|oldit", "Sales"),
    (r".*", "Other"),
]

# Render-type rules (regex on lowercased base name), ordered.
TYPE_RULES = [
    (r"barprint|qrprint|huidprint|membqr|ghattagprnt|itmlotprint|barprint|chqprint|tagreNumber", "Label/Barcode"),
    (r"bill|vch|voucher|slip|print|letter|passbook|company|cheque|chq|reminderall|salaryslip|isu$|rec$", "Bill/Voucher print"),
    (r".*", "Register/list dataset"),
]


def split_name(stem: str) -> str:
    s = re.sub(r"_", " ", stem)
    s = re.sub(r"(?<=[a-z0-9])(?=[A-Z])", " ", s)
    s = re.sub(r"(?<=[A-Za-z])(?=[0-9])", " ", s)
    return s.strip()


def classify(stem: str):
    low = stem.lower()
    dom = next(d for rx, d in DOMAIN_RULES if re.search(rx, low))
    typ = next(t for rx, t in TYPE_RULES if re.search(rx, low))
    if stem in BUILT:
        status = "🟩 BUILT — " + BUILT[stem]
    elif stem in PARTIAL:
        status = "🟨 PARTIAL — aggregate covered by an existing builder; add columns for full parity"
    elif typ == "Label/Barcode":
        status = "🏷️ ENGINE — barcode/QR (Code39/QR SVG) + tag print"
    elif typ == "Bill/Voucher print":
        status = "🧾 PRINT — per-module HTML voucher/invoice (renderInvoiceHtml); dataset = the voucher row"
    else:
        status = "📋 SPEC — dataset builder not yet written"
    return dom, typ, status


def main():
    files = sorted(f for f in os.listdir(RPT_DIR) if f.endswith(".rpt"))
    rows = []
    for f in files:
        stem = f[:-4]
        dom, typ, status = classify(stem)
        rows.append((dom, stem, f, split_name(stem), typ, status))

    order = ["Sales", "Purchase", "Accounting/Ledger", "Stock/Tag", "GST",
             "Dhrn (Pledge/Loan)", "Manufacturing/Job-work", "Membership/Scheme",
             "Tour/Bullion", "Other"]

    # Summary
    print("## Catalog summary\n")
    print(f"Total `.rpt`: **{len(files)}**\n")
    print("| Domain | .rpt count | 🟩 built | 🟨 partial | 🧾 print | 🏷️ label | 📋 spec |")
    print("|---|--:|--:|--:|--:|--:|--:|")
    for dom in order:
        d = [r for r in rows if r[0] == dom]
        b = sum(1 for r in d if r[5].startswith("🟩"))
        p = sum(1 for r in d if r[5].startswith("🟨"))
        pr = sum(1 for r in d if r[5].startswith("🧾"))
        la = sum(1 for r in d if r[5].startswith("🏷️"))
        sp = sum(1 for r in d if r[5].startswith("📋"))
        print(f"| {dom} | {len(d)} | {b} | {p} | {pr} | {la} | {sp} |")
    tb = sum(1 for r in rows if r[5].startswith("🟩"))
    tp = sum(1 for r in rows if r[5].startswith("🟨"))
    tpr = sum(1 for r in rows if r[5].startswith("🧾"))
    tla = sum(1 for r in rows if r[5].startswith("🏷️"))
    tsp = sum(1 for r in rows if r[5].startswith("📋"))
    print(f"| **TOTAL** | **{len(files)}** | **{tb}** | **{tp}** | **{tpr}** | **{tla}** | **{tsp}** |")

    # Per-domain detail
    for dom in order:
        d = [r for r in rows if r[0] == dom]
        if not d:
            continue
        print(f"\n### {dom}  ({len(d)})\n")
        print("| Report (.rpt) | Inferred name | Type | Web status / builder |")
        print("|---|---|---|---|")
        for _, stem, f, label, typ, status in d:
            print(f"| `{f}` | {label} | {typ} | {status} |")


if __name__ == "__main__":
    main()
