#!/usr/bin/env python3
"""
Which master columns does the DESKTOP let an operator edit?

Needed because `app.ts` resolved form fields as `cfg.formFields ?? GENERATED_FORM_FIELDS[table]` — an
explicit list REPLACED the generated set, silently hiding 127 columns across 9 masters. Fixing that safely
requires knowing which of those columns the desktop actually exposes, because a blanket "show everything"
would surface system-maintained running averages (`AVG_TOUCH`, `AVG_FINE`, `TOT_PCS`, …) as if an operator
should type them.

EVIDENCE RULE
-------------
The decompiled masters save through a bound DataRow, not explicit SQL:

    dataRow["UNICODE_NAME"] = tItUniCode.Text;          ' MS_ITEM.cs:3253
    dataRow["IT_GHT_PRC"]   = Conversion.Val(nGhtPrc.Text);

So a column is operator-editable when it is assigned from a CONTROL. A column that never appears on the
left of such an assignment is maintained by posting, not typed. Columns assigned from a constant or a
runtime variable (user name, date) are stamped, not edited, and are reported separately.

Output is advisory input to `nonFormColumns` decisions; it is not a parity metric.
"""
from __future__ import annotations

import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
DESKTOP = ROOT / "unified/src/csharp/DataCareNext"

# master name -> (web table, desktop form). Multi-purpose forms are noted where they apply.
TARGETS: list[tuple[str, str, str]] = [
    ("accounts", "AC_MAST", "MS_ACCT"),
    ("customers", "AC_MAST", "MS_ACCT"),
    ("items", "ITEM_MAST", "MS_ITEM"),
    ("groups", "GROUP_MAST", "MS_GROUP"),
    ("companies", "CO_MAST", "MS_COMPANY"),
    ("addresses", "ADD_MAST", "MS_ADD_MAST"),
    ("gold-rate", "DG_GOLD_MAST", "MS_GOLD_MAST"),
    ("schemes", "AD_MAST", "MS_PRODUCT"),
    ("counters", "TABLE_MAST", "MS_PRODUCT"),
]

# A control-bound right-hand side. `t*`/`n*`/`cbo*`/`chk*`/`dt*` are the desktop's control prefixes.
CONTROL = re.compile(
    r"\b(?:t|n|cbo|chk|opt|dt|msk|lbl)[A-Z][A-Za-z0-9_]*\s*\.\s*(?:Text|Value|Checked|SelectedIndex)"
)
ASSIGN = re.compile(r'dataRow\w*\["([A-Z_0-9]+)"\]\s*=\s*([^\n;]{0,160})')

# Some masters (MS_PRODUCT) build explicit SQL instead of binding a DataRow:
#     "INSERT INTO AD_MAST (CO_CODE,SCHM_CODE,SCHM_NAME,...) VALUES ..."   ' MS_PRODUCT.cs:2637
# Those column lists are the form's persisted set, so they are read too.
INSERT_COLS = re.compile(r'INSERT\s+INTO\s+([A-Z_0-9]+)\s*\(([^)]{0,1200})\)', re.I)
# Columns the desktop stamps rather than accepting from the operator.
STAMP_COLUMNS = {
    "MAIN_USER",
    "ADD_USER",
    "DATA_TRFR",
    "DATA_TYPE",
    "ENTRY_TIME",
    "CO_CODE",
    "LC_CODE",
    "CO_YEAR",
}


def analyse(form: str, table: str) -> dict[str, dict[str, str]]:
    path = DESKTOP / f"{form}.cs"
    if not path.is_file():
        return {}
    src = path.read_text(encoding="utf-8", errors="ignore")
    out: dict[str, dict[str, str]] = {}
    for m in INSERT_COLS.finditer(src):
        if m.group(1).upper() != table.upper():
            continue
        for raw in m.group(2).split(","):
            col = raw.strip().strip('"').upper()
            if not re.fullmatch(r"[A-Z_0-9]+", col or ""):
                continue
            kind = "stamped" if col in STAMP_COLUMNS else "control"
            out.setdefault(col, {"kind": kind, "rhs": f"INSERT INTO {table} column list"})
    for m in ASSIGN.finditer(src):
        col, rhs = m.group(1), m.group(2).strip()
        kind = "control" if CONTROL.search(rhs) else "stamped"
        prev = out.get(col)
        # A control binding anywhere wins over a stamp elsewhere.
        if prev is None or (prev["kind"] == "stamped" and kind == "control"):
            out[col] = {"kind": kind, "rhs": rhs[:70]}
    return out


def main() -> int:
    if not DESKTOP.is_dir():
        print(f"desktop source missing: {DESKTOP}", file=sys.stderr)
        return 2
    report: dict[str, dict] = {}
    for name, table, form in TARGETS:
        bound = analyse(form, table)
        controls = sorted(c for c, v in bound.items() if v["kind"] == "control")
        stamped = sorted(c for c, v in bound.items() if v["kind"] == "stamped")
        report[name] = {
            "table": table,
            "desktopForm": form,
            "editableColumns": controls,
            "stampedColumns": stamped,
            "evidence": {c: bound[c]["rhs"] for c in controls},
        }
        print(f"{name:12} {table:14} {form:14} editable={len(controls):3} stamped={len(stamped)}")
    out = ROOT / "project-memory/parity/DESKTOP-EDITABLE-COLUMNS.json"
    out.write_text(json.dumps(report, indent=2) + "\n")
    print(f"\nwrote {out.relative_to(ROOT)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
