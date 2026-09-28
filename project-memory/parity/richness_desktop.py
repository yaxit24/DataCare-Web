#!/usr/bin/env python3
"""Measure per-form UI/behavioural richness of the DataCareNext desktop application.

This measures the dimensions the existing DEPTH-SCOREBOARD does *not*: visible grid
columns, bound input controls, user-facing validation messages, keyboard affordances,
settings-driven conditional behaviour and lookup pickers.

Ground truth: the decompiled C# in unified/src/csharp_nextdm/DataCareNext, which retains
control declarations and MSFlexGrid column header assignments verbatim.

Run:  python3 richness_desktop.py > DESKTOP-RICHNESS.json
"""
from __future__ import annotations

import json
import os
import re
import sys
from collections import defaultdict

REPO = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", ".."))
# The product ships two executables decompiled to two trees. DataCareNext.exe is the app
# the web replaces (and the tree the existing 204-form parity matrix cites); NextDm.exe is
# a separate binary measured only to size the unaddressed surface.
TREES = {
    "DataCareNext": os.path.join(REPO, "unified", "src", "csharp", "DataCareNext"),
    "NextDm": os.path.join(REPO, "unified", "src", "csharp_nextdm", "DataCareNext"),
}
SRC = TREES["DataCareNext"]

# --- control classification -------------------------------------------------
# Types that accept or present operator data. Labels/buttons/panels are chrome and
# are counted separately so they cannot inflate the field count.
INPUT_TYPES = {
    "TextBox",
    "MaskedTextBox",
    "ComboBox",
    "CheckBox",
    "RadioButton",
    "DateTimePicker",
    "NumericUpDown",
    "ListBox",
    "CheckedListBox",
    "RichTextBox",
    "TextEdit",
    "ComboBoxEdit",
    "DateEdit",
    "CheckEdit",
    "SpinEdit",
    "LookUpEdit",
    "MemoEdit",
    "ToggleSwitch",
}
GRID_TYPES = {"AxMSFlexGrid", "DataGridView", "GridControl", "AxMSHFlexGrid"}
CHROME_TYPES = {
    "Label",
    "SimpleButton",
    "Button",
    "Panel",
    "GroupBox",
    "PictureBox",
    "TabControl",
    "TabPage",
    "GroupControl",
    "PanelControl",
    "LabelControl",
    "Splitter",
    "ToolTip",
    "IContainer",
    "Timer",
    "ImageList",
    "XtraTabControl",
    "XtraTabPage",
}

# `private TextBox _tAcCode;`  /  `private AxMSFlexGrid _MSG;`
DECL = re.compile(r"^\s*(?:private|public|internal|protected)\s+([A-Za-z_][\w.]*)\s+(_?[A-Za-z_]\w*)\s*;\s*$")
# `mSG.Cols = 88;`
GRID_COLS = re.compile(r"\b([A-Za-z_]\w*)\.Cols\s*=\s*(\d+)\s*;")
# `mSG[0, 12] = "NetWt";`  -> header text for column 12
GRID_HDR = re.compile(r"\b([A-Za-z_]\w*)\[0,\s*(\d+)\]\s*=\s*\"([^\"]*)\"")
# user-facing validation / guidance messages.
# Decompiled shape: Interaction.MsgBox((object)"text", (MsgBoxStyle)36, (object)null)
MSGBOX = re.compile(r"(?:Interaction\.)?MsgBox\s*\(")
MSG_TEXT = re.compile(r"(?:Interaction\.)?MsgBox\s*\(\s*(?:\(object\))?\s*\"([^\"]{3,200})\"")
# MsgBoxStyle 4/32/36 carry a Yes/No button set, i.e. an operator decision point rather
# than a notification. Those are branch points in the workflow.
MSG_CONFIRM = re.compile(r"MsgBox\s*\(\s*(?:\(object\))?\s*\"([^\"]{3,200})\"\s*,\s*\(MsgBoxStyle\)(\d+)")
# keyboard affordances
FKEY = re.compile(r"\bKeys\.(F\d{1,2})\b")
KEY_OTHER = re.compile(r"\bKeys\.(Enter|Escape|Tab|Insert|Delete|Up|Down|PageUp|PageDown|Add|Subtract|Multiply)\b")
# settings-driven conditional behaviour: the desktop reads global config off DC_Main
SETTING_READ = re.compile(r"\bDC_Main\.(Ms[A-Za-z0-9_]+|[A-Z][A-Za-z0-9_]*)\b")
# SQL surface
SQL = re.compile(r"\"\s*(SELECT|INSERT\s+INTO|UPDATE|DELETE\s+FROM)\b", re.I)
# event handlers reveal in-form interactive behaviour. Grid cell events (EnterCell,
# LeaveCell, RowColChange) are the desktop's per-cell computation and validation hooks.
HANDLER = re.compile(
    r"^\s*(?:private|public|internal|protected)?\s*(?:virtual\s+)?void\s+"
    r"([A-Za-z_]\w*_(?:KeyDown|KeyPress|KeyUp|Validating|Validated|Leave|Enter|Click|ClickEvent|"
    r"TextChanged|SelectedIndexChanged|CheckedChanged|CellChanged|RowColChange|EnterCell|LeaveCell|"
    r"DblClick|DoubleClick|GotFocus|LostFocus|Load|Closing|Activated|Scroll|MouseDown))\s*\(",
    re.M,
)
CELL_EVENT = re.compile(r"^\s*(?:private\s+)?void\s+([A-Za-z_]\w*_(?:EnterCell|LeaveCell|RowColChange))\s*\(", re.M)
# lookup pickers (F-key masters search) are a hallmark of the desktop UX
LOOKUP = re.compile(r"\b(SearchMast|SrcMast|HelpMast|F1_Help|ShowHelp|MastHelp|SearchForm)\w*")
# report / print entry points
PRINT = re.compile(r"\b(CrystalReport|ReportDocument|PrintDocument|rptPrint|PrintOut|ShowReport)\w*")


def classify_form(name: str) -> str:
    """Bucket a desktop form into a functional family from its naming convention."""
    n = name.upper()
    if n.startswith("TR_"):
        return "transaction"
    if n.startswith("MS_") or n.startswith("MAST"):
        return "master"
    if n.startswith("RPT") or n.startswith("PR_") or "REPORT" in n:
        return "report"
    if n.startswith("UT_") or n.startswith("UTIL"):
        return "utility"
    if n.startswith("DC_") or n.startswith("FRM"):
        return "shell"
    return "other"


def module_of(name: str) -> str:
    n = name.upper()
    rules = [
        ("sales", ("TR_SALE", "TR_WH_SALE", "TR_BILL_TO", "TR_SALE_ORD", "TR_ORD")),
        ("purchase", ("TR_PURC", "TR_PUR")),
        ("tagStock", ("TR_TAG", "TR_STK", "TR_BAR", "TR_CNTR")),
        ("manufacturing", ("TR_KR", "TR_MFG", "TR_JOB", "TR_APR")),
        ("dhiran", ("TR_DHRN",)),
        ("finance", ("TR_CASH", "TR_BANK", "TR_CONTRA", "TR_JV", "TR_AC", "TR_CARD", "TR_FN")),
        ("bullion", ("TR_BUL", "TR_FINE", "TR_RATE")),
        ("membership", ("TR_SCH", "TR_MEMB", "TR_LOY")),
        ("statutory", ("GST", "TDS", "EINV", "EWAY", "HSN")),
        ("masters", ("MS_", "MAST")),
    ]
    for mod, prefixes in rules:
        for p in prefixes:
            if n.startswith(p) or p in n:
                return mod
    return "other"


def measure(path: str) -> dict:
    with open(path, "r", encoding="utf-8", errors="replace") as fh:
        text = fh.read()
    lines = text.splitlines()
    name = os.path.splitext(os.path.basename(path))[0]

    controls: dict[str, int] = defaultdict(int)
    grid_names: set[str] = set()
    for ln in lines:
        m = DECL.match(ln)
        if not m:
            continue
        ctype, cname = m.group(1), m.group(2)
        short = ctype.split(".")[-1]
        controls[short] += 1
        if short in GRID_TYPES:
            grid_names.add(cname.lstrip("_"))

    inputs = sum(c for t, c in controls.items() if t in INPUT_TYPES)
    chrome = sum(c for t, c in controls.items() if t in CHROME_TYPES)
    unknown = {t: c for t, c in controls.items() if t not in INPUT_TYPES and t not in CHROME_TYPES and t not in GRID_TYPES}

    # grid column declarations: keep the largest declared Cols per grid variable
    declared: dict[str, int] = {}
    for m in GRID_COLS.finditer(text):
        var, cols = m.group(1), int(m.group(2))
        key = var.lstrip("_").upper()
        declared[key] = max(declared.get(key, 0), cols)

    # grid headers: named, visible columns per grid variable
    headers: dict[str, dict[int, str]] = defaultdict(dict)
    for m in GRID_HDR.finditer(text):
        var, idx, txt = m.group(1), int(m.group(2)), m.group(3)
        key = var.lstrip("_").upper()
        if txt.strip():
            headers[key][idx] = txt.strip()

    grids = []
    for key in sorted(set(declared) | set(headers)):
        hdr = headers.get(key, {})
        grids.append(
            {
                "grid": key,
                "declaredCols": declared.get(key),
                "namedCols": len(hdr),
                "columns": [hdr[i] for i in sorted(hdr)],
            }
        )

    fkeys = sorted(set(FKEY.findall(text)), key=lambda s: int(s[1:]))
    handlers = sorted({m.group(1) for m in HANDLER.finditer(text)})
    cell_events = sorted({m.group(1) for m in CELL_EVENT.finditer(text)})
    settings = sorted(set(SETTING_READ.findall(text)))
    msg_texts = sorted({t.strip() for t in MSG_TEXT.findall(text) if t.strip()})
    confirms = sorted({m.group(1).strip() for m in MSG_CONFIRM.finditer(text) if int(m.group(2)) in (4, 32, 36, 292, 308)})

    return {
        "form": name,
        "kind": classify_form(name),
        "module": module_of(name),
        "loc": len(lines),
        "inputControls": inputs,
        "chromeControls": chrome,
        "gridControls": sum(c for t, c in controls.items() if t in GRID_TYPES),
        "otherControls": unknown,
        "controlBreakdown": dict(sorted(controls.items(), key=lambda kv: -kv[1])),
        "grids": grids,
        "gridDeclaredColsTotal": sum(v for v in declared.values()),
        "gridNamedColsTotal": sum(len(h) for h in headers.values()),
        "validationMessages": MSGBOX_count(text),
        "validationMessageSamples": msg_texts[:400],
        "distinctValidationMessages": len(msg_texts),
        "confirmationPrompts": len(confirms),
        "confirmationPromptSamples": confirms[:60],
        "functionKeys": fkeys,
        "otherKeys": sorted(set(KEY_OTHER.findall(text))),
        "eventHandlers": len(handlers),
        "eventHandlerNames": handlers,
        "gridCellEvents": len(cell_events),
        "gridCellEventNames": cell_events,
        "settingsRead": settings,
        "settingsReadCount": len(settings),
        "sqlStatements": len(SQL.findall(text)),
        "lookupPickers": len(set(LOOKUP.findall(text))),
        "printPaths": len(set(PRINT.findall(text))),
    }


def MSGBOX_count(text: str) -> int:
    return len(MSGBOX.findall(text))


def main() -> int:
    tree = sys.argv[1] if len(sys.argv) > 1 else "DataCareNext"
    src = TREES.get(tree, tree)
    if not os.path.isdir(src):
        print(f"desktop source not found: {src}", file=sys.stderr)
        return 2
    forms = []
    for fn in sorted(os.listdir(src)):
        if not fn.endswith(".cs"):
            continue
        forms.append(measure(os.path.join(src, fn)))

    totals = {
        "forms": len(forms),
        "loc": sum(f["loc"] for f in forms),
        "inputControls": sum(f["inputControls"] for f in forms),
        "gridDeclaredCols": sum(f["gridDeclaredColsTotal"] for f in forms),
        "gridNamedCols": sum(f["gridNamedColsTotal"] for f in forms),
        "validationMessages": sum(f["validationMessages"] for f in forms),
        "distinctValidationMessages": len({m for f in forms for m in f["validationMessageSamples"]}),
        "confirmationPrompts": sum(f["confirmationPrompts"] for f in forms),
        "eventHandlers": sum(f["eventHandlers"] for f in forms),
        "gridCellEvents": sum(f["gridCellEvents"] for f in forms),
        "sqlStatements": sum(f["sqlStatements"] for f in forms),
        "grids": sum(len(f["grids"]) for f in forms),
    }
    by_module: dict[str, dict] = defaultdict(
        lambda: {"forms": 0, "inputControls": 0, "gridNamedCols": 0, "validationMessages": 0, "eventHandlers": 0}
    )
    for f in forms:
        b = by_module[f["module"]]
        b["forms"] += 1
        b["inputControls"] += f["inputControls"]
        b["gridNamedCols"] += f["gridNamedColsTotal"]
        b["validationMessages"] += f["validationMessages"]
        b["eventHandlers"] += f["eventHandlers"]

    all_settings = sorted({s for f in forms for s in f["settingsRead"]})
    json.dump(
        {
            "kind": "desktop-ui-richness",
            "tree": tree,
            "source": src,
            "totals": totals,
            "byModule": dict(sorted(by_module.items())),
            "distinctSettingsRead": len(all_settings),
            "settings": all_settings,
            "forms": forms,
        },
        sys.stdout,
        indent=1,
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
