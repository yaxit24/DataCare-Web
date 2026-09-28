#!/usr/bin/env python3
"""
Extract the desktop settings contract: control -> options -> persisted column -> persistence rule.

Why a script rather than hand transcription: there are ~130 settings across three desktop forms, and the
persistence rule differs per control. Getting one wrong stores a LABEL where the application expects a CODE,
which silently changes behaviour. Three rules are in use:

    Strings.Mid(cboX.Text, 1, 1)   -> store the FIRST CHARACTER   ("Net Wise" -> "N")
    cboX.Text                      -> store the FULL TEXT          ("Calibri" -> "Calibri")
    Conversion.Val(cboX.Text)      -> store the NUMBER             ("120"     -> 120)
    chkX.Checked ? "Y" : "N"       -> store a Y/N FLAG

Options are read from `cboX.Items.Add((object)"...")` in declaration order, preserving the desktop's own
misspellings ("Gorss Wise", "Mobile Mathod", "Whout Row Short") because those strings are the contract.

Output is advisory research input for the settings catalog, not a parity metric.
"""
from __future__ import annotations

import json
import re
import sys
from collections import OrderedDict
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
DESKTOP = ROOT / "unified/src/csharp/DataCareNext"
FORMS = ["UT_SETTING", "UT_SETTING_MAIN", "UT_SET_ADMIN"]

# Grid-checkbox settings write IIf(cell.Value == true, 'Y', 'N') instead of using a named control
# (UT_SETTING_MAIN.cs:8843). Matched by locating `SET <COL> =` and looking for `(object)true` nearby,
# because the intervening text contains C#-escaped quotes that a single tight pattern kept missing.
YN_SET = re.compile(r'SET\s+([A-Z][A-Z0-9_]{2,})\s*=')
ITEM = re.compile(r'(cbo[A-Za-z0-9_]+)\.Items\.Add\(\(object\)"([^"]*)"\)')
# UPDATE CO_SET SET COL = '" + Strings.Mid(cboX.Text, 1, 1) + "'   (and the CO_SET_NEW variant)
SET_ASSIGN = re.compile(
    r'([A-Z][A-Z0-9_]{2,})\s*=\s*[\'"]?\s*\"?\s*\+?\s*'
    r'(?:Conversions\.ToString\()?'
    r'(?:(Strings\.Mid|Conversion\.Val)\s*\(\s*)?'
    r'(cbo|chk|t|n)([A-Za-z0-9_]+)\s*\.\s*(Text|Checked)'
)


def read(form: str) -> str:
    p = DESKTOP / f"{form}.cs"
    return p.read_text(encoding="utf-8", errors="ignore") if p.is_file() else ""


def main() -> int:
    if not DESKTOP.is_dir():
        print(f"desktop source missing: {DESKTOP}", file=sys.stderr)
        return 2

    report: dict[str, dict] = {}
    for form in FORMS:
        src = read(form)
        if not src:
            continue
        options: "OrderedDict[str, list[str]]" = OrderedDict()
        for m in ITEM.finditer(src):
            options.setdefault(m.group(1), []).append(m.group(2))

        # column -> how it is persisted, and from which control
        persisted: dict[str, dict] = {}
        # Grid-checkbox settings are written as IIf(cell.Value == true, 'Y', 'N') rather than from a
        # named control (UT_SETTING_MAIN.cs:8843). They are still Y/N flags and must not be missed.
        for m in YN_SET.finditer(src):
            window = src[m.end() : m.end() + 260]
            if "(object)true" in window and "Interaction.IIf" in window:
                persisted.setdefault(
                    m.group(1), {"control": "(checkbox grid)", "rule": "yn-flag"}
                )
        for m in SET_ASSIGN.finditer(src):
            col, fn, prefix, name, prop = m.groups()
            control = f"{prefix}{name}"
            rule = (
                "first-char"
                if fn == "Strings.Mid"
                else "numeric"
                if fn == "Conversion.Val"
                else "yn-flag"
                if prop == "Checked"
                else "full-text"
            )
            persisted.setdefault(col, {"control": control, "rule": rule})

        report[form] = {
            "controlOptions": {k: v for k, v in options.items()},
            "persistedColumns": persisted,
        }
        print(f"{form:18} combos={len(options):3} persisted-columns={len(persisted)}")

    # Join: for each persisted column, attach the option list of its control when it has one.
    joined: dict[str, dict] = {}
    for form, data in report.items():
        for col, info in data["persistedColumns"].items():
            opts = data["controlOptions"].get(info["control"])
            entry = {
                "form": form,
                "control": info["control"],
                "rule": info["rule"],
                "options": opts or None,
            }
            # A column persisted from several forms keeps the richer (option-bearing) reading.
            prev = joined.get(col)
            if prev is None or (prev.get("options") is None and opts):
                joined[col] = entry

    with_opts = sum(1 for v in joined.values() if v["options"])
    print(f"\ncolumns with a persistence rule: {len(joined)}")
    print(f"   of which have a finite option list: {with_opts}")
    out = ROOT / "project-memory/parity/DESKTOP-SETTINGS-CONTRACT.json"
    out.write_text(json.dumps({"forms": report, "columns": joined}, indent=2) + "\n")
    print(f"wrote {out.relative_to(ROOT)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
