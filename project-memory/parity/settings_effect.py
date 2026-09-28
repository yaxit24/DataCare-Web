#!/usr/bin/env python3
"""For each web setting, resolve the desktop global it maps to and count real desktop reads.

Answers the only question that matters about an inert web setting: does the desktop
actually branch on it? A setting the desktop also ignores is dead config on both sides and
must not be reported as a gap. A setting the desktop reads in N forms while the web reads it
nowhere is a behavioural gap of known size.

Method: the desktop loader assigns config columns into `DC_Main.Ms*` globals. Find the
assignment whose right-hand side names the column, take the global, then count reads of that
global across form code excluding the loader itself.

Run:  python3 settings_effect.py > SETTINGS-EFFECT.json
"""
from __future__ import annotations

import json
import os
import re
import sys
from collections import defaultdict

REPO = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", ".."))
DESKTOP = os.path.join(REPO, "unified", "src", "csharp", "DataCareNext")
INVENTORY = os.path.join(
    REPO, "web", "apps", "api", "src", "modules", "settings", "settingsInventory.ts"
)
PARITY = os.path.join(os.path.dirname(os.path.abspath(__file__)), "SETTINGS-PARITY.json")

INV_KEY = re.compile(r"^\s*\{\s*key:\s*'([A-Z0-9_]+)'\s*,\s*table:\s*'(CO_SET|CO_SET_NEW)'", re.M)
# Loader lines look like: DC_Main.MsNegativeStkSale = Conversions.ToString(reader["NEGATIVE_STK_SALE"])
ASSIGN_WITH_COL = re.compile(r"DC_Main\.(Ms[A-Za-z0-9_]+)\s*=[^;\n]*?\b([A-Z][A-Z0-9_]{2,})\b")
READ = re.compile(r"\bDC_Main\.(Ms[A-Za-z0-9_]+)\b")
LOADERS = {"DC_Main", "MS_OPNCOMP", "MDI_FORM", "MS_YEAR"}


def load_sources() -> dict[str, str]:
    out = {}
    for fn in sorted(os.listdir(DESKTOP)):
        if fn.endswith(".cs"):
            with open(os.path.join(DESKTOP, fn), "r", encoding="utf-8", errors="replace") as fh:
                out[os.path.splitext(fn)[0]] = fh.read()
    return out


def main() -> int:
    src = load_sources()

    # column -> candidate globals, harvested from every assignment that mentions the column
    col_to_global: dict[str, set[str]] = defaultdict(set)
    for _form, text in src.items():
        for m in ASSIGN_WITH_COL.finditer(text):
            col_to_global[m.group(2)].add(m.group(1))

    # global -> forms that read it, excluding the loader forms
    reads: dict[str, set[str]] = defaultdict(set)
    for form, text in src.items():
        if form in LOADERS:
            continue
        for m in READ.finditer(text):
            reads[m.group(1)].add(form)

    with open(INVENTORY, "r", encoding="utf-8", errors="replace") as fh:
        keys = [m.group(1) for m in INV_KEY.finditer(fh.read())]
    with open(PARITY, "r", encoding="utf-8", errors="replace") as fh:
        parity = json.load(fh)
    inert = set(parity["webInertKeys"])
    honoured = set(parity["webHonouredKeys"])

    rows = []
    for key in keys:
        globals_ = sorted(col_to_global.get(key, set()))
        readers: set[str] = set()
        for g in globals_:
            readers |= reads.get(g, set())
        rows.append(
            {
                "key": key,
                "webStatus": "inert" if key in inert else ("honoured" if key in honoured else "unknown"),
                "desktopGlobals": globals_,
                "desktopReaderForms": sorted(readers),
                "desktopReaderCount": len(readers),
            }
        )

    inert_rows = [r for r in rows if r["webStatus"] == "inert"]
    real_gaps = [r for r in inert_rows if r["desktopReaderCount"] > 0]
    dead_both = [r for r in inert_rows if r["desktopReaderCount"] == 0]
    unresolved = [r for r in inert_rows if not r["desktopGlobals"]]

    json.dump(
        {
            "kind": "settings-effect",
            "note": (
                "desktopReaderCount is the number of desktop FORMS that read the global the setting "
                "loads into, excluding the loader forms. 0 with a resolved global means the desktop "
                "ignores it too; unresolved means the loader assignment could not be located and the "
                "row is inconclusive rather than clean."
            ),
            "summary": {
                "webInventory": len(keys),
                "webInert": len(inert_rows),
                "inertButDesktopHonours": len(real_gaps),
                "inertAndDesktopIgnoresToo": len(dead_both),
                "inertUnresolvedMapping": len(unresolved),
            },
            "realGaps": sorted(real_gaps, key=lambda r: -r["desktopReaderCount"]),
            "deadOnBothSides": [r["key"] for r in dead_both],
            "rows": rows,
        },
        sys.stdout,
        indent=1,
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
