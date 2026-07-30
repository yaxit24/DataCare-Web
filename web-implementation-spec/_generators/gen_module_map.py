#!/usr/bin/env python3
"""
Generate the functional Module Map from module-map.json.

Reads:  ../../project-memory/catalogs/module-map.json
Writes: ../03_Modules/MODULE_MAP.md  (all 204 forms grouped into 14 functional modules)

Run: python3 gen_module_map.py
"""
import json, os, re, datetime

HERE = os.path.dirname(os.path.abspath(__file__))
MM = os.path.normpath(os.path.join(HERE, "..", "..", "project-memory", "catalogs", "module-map.json"))
OUT = os.path.normpath(os.path.join(HERE, "..", "03_Modules", "MODULE_MAP.md"))

# Ordered (regex -> functional module). First match wins. Explicit names beat prefixes.
RULES = [
    (r"^(MS_LOGIN|MS_OPNCOMP|MS_COMPANY|MS_YEAR|MS_USER|MS_SET_ADMIN|MS_UPDATE|AuthClass|MS_DM|MS_HELP|MS_WINDOW_SET)$", "0_Foundation"),
    (r"^(TR_MEMB_|MS_MEMB|MS_POINT)", "10_Membership"),
    (r"^(MS_MFG_MAST|Mfg_Module|TR_MFG_|TR_KR_ISU|TR_MLT_PRO|TR_REP_REC)", "5_Manufacturing"),
    (r"^(MS_GOLD_MAST|TR_BUL_|TR_TOUR|TR_VP|TR_GOLD_BOOK|TR_FINE_SL_PR|TR_FN_INOUT|TR_INOUT|TR_OTH_COMM|TR_PR_SL_HEDG)", "11_Bullion_Tour_VP"),
    (r"^(RP_GST|TR_SL_EBILL|UT_E_INVOICE|IRNClass|IRNData|Ac_Tax)$", "9_GST_EInvoice"),
    (r"^(TR_SALE|TR_WH_SALE|TR_SL_|TR_BILL_TO)", "2_Sales"),
    (r"^(TR_PURC|TR_OTH_PURC|TR_PR_SL_UAE)", "3_Purchase"),
    (r"^(TR_TAG_|TR_ITM_|TR_PHYSTK|Ac_Stock|UT_TAG_PRINT|TagOthDetail|ClassTagList|ClsItemList)", "4_Inventory_Tags"),
    (r"^(TR_DHRN_|RP_DHRN)", "6_Dhrn_Loans"),
    (r"^(TR_CASH|TR_CONTRA|TR_CARD_REC|TR_UPI_REC|TR_LOCT_AMT|UT_BANK)", "7_Finance_CashBank"),
    (r"^(Ac_Ledr|Ac_Final|Ac_Rojmel|Ac_Image|TR_AC_OPBL|TR_LEDR_ADJ|TR_JDT_REC|TR_EMP_JV)$", "8_Accounting"),
    (r"^MS_", "1_Masters"),
    (r"^RP_", "12_Reports"),
    (r"^UT_", "13_Utilities_Settings_Integrations"),
]
# Framework/helper classes that aren't user forms.
FRAMEWORK = re.compile(r"^(Cls|Data$|ErrorResp|AuthError|PolicyModels|Module_Save|Module_Schm|Module_WhatsApp|Translator|DcClass|DcPrintClass|DC_Main|MDI_FORM|BtmSchm|Btm|OlockerService|IRNClass|IRNData)")

MODULE_TITLES = {
    "0_Foundation": "Foundation / Auth / Company-Year",
    "1_Masters": "Masters",
    "2_Sales": "Sales",
    "3_Purchase": "Purchase",
    "4_Inventory_Tags": "Inventory / Tags / Stock",
    "5_Manufacturing": "Manufacturing / Karigar / Job-Work",
    "6_Dhrn_Loans": "Loans / Dhrn (pledge)",
    "7_Finance_CashBank": "Finance / Cash-Bank",
    "8_Accounting": "Accounting / Ledgers / Final Accounts",
    "9_GST_EInvoice": "GST & E-Invoice",
    "10_Membership": "Membership / Loyalty",
    "11_Bullion_Tour_VP": "Bullion / Tour / VP",
    "12_Reports": "Reports",
    "13_Utilities_Settings_Integrations": "Utilities / Settings / Integrations",
    "_framework": "Framework / shared classes (not user forms)",
}

def func_module(name):
    if FRAMEWORK.search(name):
        return "_framework"
    for rx, m in RULES:
        if re.search(rx, name):
            return m
    return "_framework"

def main():
    with open(MM) as f:
        mm = json.load(f)
    forms = mm.get("forms", {})
    posting_forms = set(mm.get("summary", {}).get("transactionFormsWithPosting", []))
    groups = {}
    for name in sorted(forms.keys()):
        groups.setdefault(func_module(name), []).append(name)

    out = []
    out.append("# Module Map — 204 forms → 14 functional modules")
    out.append("")
    out.append(f"_Generated {datetime.date.today().isoformat()} from `module-map.json` "
               f"({len(forms)} forms; {len(posting_forms)} posting transactions). "
               "Functional grouping aligns to `web/apps/api/src/modules`._")
    out.append("")
    out.append("Legend: **Posting** = writes the `AC_DATA` ledger on save. "
               "**Type** = master/transaction/report/utility/other (from auto-extraction).")
    out.append("")
    # summary table
    out.append("## Summary")
    out.append("")
    out.append("| Module | Forms | Posting txns |")
    out.append("|---|---|---|")
    for key in sorted(groups, key=lambda k: (k.startswith("_"), k)):
        gforms = groups[key]
        npost = sum(1 for n in gforms if n in posting_forms)
        out.append(f"| {MODULE_TITLES.get(key, key)} | {len(gforms)} | {npost} |")
    out.append("")
    # per-module form tables
    for key in sorted(groups, key=lambda k: (k.startswith("_"), k)):
        out.append(f"## {MODULE_TITLES.get(key, key)}")
        out.append("")
        out.append("| Form | Type | Posting | Tables written (header/detail/ledger/…) |")
        out.append("|---|---|---|---|")
        for name in sorted(groups[key]):
            fm = forms[name]
            typ = fm.get("module", "")
            ins = fm.get("tablesInserted", []) or []
            upd = fm.get("tablesUpdated", []) or []
            written = sorted(set(ins) | set(upd))
            # keep the row readable
            shown = ", ".join(written[:10]) + (" …" if len(written) > 10 else "")
            post = "✅" if name in posting_forms else ""
            out.append(f"| `{name}` | {typ} | {post} | {shown} |")
        out.append("")
    os.makedirs(os.path.dirname(OUT), exist_ok=True)
    with open(OUT, "w") as f:
        f.write("\n".join(out) + "\n")
    print(f"Wrote {OUT}")
    print("Group counts:", {MODULE_TITLES.get(k,k): len(v) for k,v in sorted(groups.items())})

if __name__ == "__main__":
    main()
