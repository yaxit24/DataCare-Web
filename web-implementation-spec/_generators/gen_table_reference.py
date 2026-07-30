#!/usr/bin/env python3
"""
Generate the per-table data-model reference for the web-implementation-spec.

Reads:  ../../project-memory/catalogs/data-model.json
Writes: ../02_Data_Model/tables/<TABLE>.md   (one per table)
        ../02_Data_Model/tables/INDEX.md      (alphabetical + by-cluster index)

Run:    python3 gen_table_reference.py
Idempotent: regenerates the tables/ folder each run.
"""
import json, os, re, datetime

HERE = os.path.dirname(os.path.abspath(__file__))
DM = os.path.normpath(os.path.join(HERE, "..", "..", "project-memory", "catalogs", "data-model.json"))
OUT = os.path.normpath(os.path.join(HERE, "..", "02_Data_Model", "tables"))

TENANT_KEYS = ["CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK"]

# Ordered (regex -> cluster) rules; first match wins. Purely for navigation grouping.
CLUSTER_RULES = [
    (r"^AC_DATA$|^AC_MAST$|^AC_GROUP$|^LEDR_AC_DATA$|^ROJ_MEL_DATA$|^AC_", "accounting"),
    (r"^SL_", "sales"),
    (r"^PR_", "purchase"),
    (r"^(TAG_|BAR_|MAIN_STOCK$|ITM_|LOT_|TOUCH_MAST$|APR_|OP_DETL$)", "inventory"),
    (r"^(MFG_|KR_|MLT_|REP_)", "manufacturing"),
    (r"^(DHRN_|LOAN_)", "dhrn"),
    (r"^(CASH_|PAY_|CONTRA_|CARD_|UPI_|DM_)", "finance"),
    (r"^(TAX_|E_DATA$|IRN)", "gst_tax"),
    (r"^(POINT_|MEMB_|COMM_)", "membership"),
    (r"^(BUL_|TOUR_|VP_|GOLD_|FN_|FINE_|INOUT$)", "bullion_tour"),
    (r"(_MAST$)|^(CO_|YEAR_MAST$|LOGIN_MAST$|SRNO_MAST$|RATE_MAST$|ITEM_MAST$|EMP_MAST$|MS_)", "masters"),
]

def cluster_of(name):
    for rx, c in CLUSTER_RULES:
        if re.search(rx, name):
            return c
    return "ancillary"

def main():
    with open(DM) as f:
        dm = json.load(f)
    tables = dm.get("tables", {})
    unresolved = set(dm.get("unresolvedTables", []))
    os.makedirs(OUT, exist_ok=True)
    # clear old table md (keep INDEX rewritten)
    for fn in os.listdir(OUT):
        if fn.endswith(".md"):
            os.remove(os.path.join(OUT, fn))

    rows_index = []
    by_cluster = {}
    for name in sorted(tables.keys()):
        t = tables[name]
        cols = t.get("columns", [])
        pk = t.get("primaryKey", []) or []
        colnames = [c.get("name") for c in cols]
        tenant_keyed = all(k in colnames for k in TENANT_KEYS)
        partial_keys = [k for k in TENANT_KEYS if k in colnames]
        src = "unresolved" if name in unresolved else (
            "code-recovered" if cols and all("code" in str(c.get("source", "")) for c in cols) else "DDL")
        cl = cluster_of(name)
        by_cluster.setdefault(cl, []).append(name)
        rows_index.append((name, len(cols), len(pk) > 0, tenant_keyed, src, cl))

        lines = []
        lines.append(f"# {name}")
        lines.append("")
        lines.append(f"- **Cluster:** {cl}")
        lines.append(f"- **Source:** {src}")
        lines.append(f"- **Columns:** {len(cols)}")
        lines.append(f"- **Primary key:** {', '.join(pk) if pk else '(none recovered)'}")
        kd = ", ".join(partial_keys) if partial_keys else "(none)"
        lines.append(f"- **Tenant/scope keys present:** {kd}{'  ·  fully tenant-keyed' if tenant_keyed else ''}")
        lines.append("- **Web mapping:** `tenant_id` + the scope keys above; preserve column names verbatim.")
        lines.append("")
        lines.append("| # | Column | Type | Len | Null | Default | Source |")
        lines.append("|---|--------|------|-----|------|---------|--------|")
        for i, c in enumerate(cols, 1):
            typ = c.get("type", "") or ""
            ln = c.get("length", "")
            ln = "" if ln in (None, "",) else ln
            nl = "Y" if c.get("nullable", True) else "N"
            df = c.get("default", "")
            df = "" if df is None else str(df)
            sr = c.get("source", "")
            star = " 🔑" if c.get("name") in pk else ""
            key_mark = " ⟨scope⟩" if c.get("name") in TENANT_KEYS else ""
            lines.append(f"| {i} | {c.get('name','')}{star}{key_mark} | {typ} | {ln} | {nl} | {df} | {sr} |")
        lines.append("")
        lines.append(f"> 🔑 = primary key · ⟨scope⟩ = tenant/scope key. Regenerated from `data-model.json`.")
        with open(os.path.join(OUT, f"{name}.md"), "w") as out:
            out.write("\n".join(lines) + "\n")

    # INDEX.md
    idx = []
    idx.append("# Table Reference — Index")
    idx.append("")
    idx.append(f"_{len(tables)} tables · generated {datetime.date.today().isoformat()} from `data-model.json`._")
    idx.append("")
    idx.append("## By cluster")
    idx.append("")
    for cl in sorted(by_cluster):
        idx.append(f"### {cl} ({len(by_cluster[cl])})")
        idx.append("")
        idx.append(", ".join(f"[{n}]({n}.md)" for n in sorted(by_cluster[cl])))
        idx.append("")
    idx.append("## Alphabetical")
    idx.append("")
    idx.append("| Table | Cols | PK? | Tenant-keyed | Source | Cluster |")
    idx.append("|---|---|---|---|---|---|")
    for name, ncols, has_pk, tk, src, cl in sorted(rows_index):
        idx.append(f"| [{name}]({name}.md) | {ncols} | {'yes' if has_pk else '—'} | {'yes' if tk else '—'} | {src} | {cl} |")
    idx.append("")
    with open(os.path.join(OUT, "INDEX.md"), "w") as out:
        out.write("\n".join(idx) + "\n")

    print(f"Wrote {len(tables)} table files + INDEX.md to {OUT}")
    print("Cluster counts:", {k: len(v) for k, v in sorted(by_cluster.items())})

if __name__ == "__main__":
    main()
