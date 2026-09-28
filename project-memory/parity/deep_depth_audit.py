#!/usr/bin/env python3
"""Deep desktop-vs-web DEPTH audit (not breadth).

The parity matrix answers "does a surface exist?". This script answers a harder question:
"for each desktop form, how much of its actual behaviour does the web implement?" — measured from
artefacts on disk only, with no human judgement:

  desktop facts   project-memory/catalogs/form-behavior/<FORM>.behavior.json   (grid columns, calc
                  expressions, validations with exact message text, inline SQL, keyboard map)
                  project-memory/catalogs/form-logic/<FORM>.logic.json         (tables, writes,
                  select tables, F-keys, message boxes, timers, serial port, handlers)
                  project-memory/catalogs/layouts/<FORM>.initcomp.json         (control inventory)

  web facts       the modules + pages the parity generator maps to that form, parsed for: tables
                  written, distinct persisted columns, validation throws, UI inputs, grid columns.

Every ratio below is evidence-derived. Where a desktop fact cannot be measured on the web side the
row is reported as UNMEASURABLE rather than assumed complete.
"""

from __future__ import annotations

import json
import re
from collections import Counter
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
MATRIX = json.loads((ROOT / "project-memory/parity/DESKTOP-WEB-PARITY-MATRIX.json").read_text())
BEHAVIOR = ROOT / "project-memory/catalogs/form-behavior"
LOGIC = ROOT / "project-memory/catalogs/form-logic"
LAYOUTS = ROOT / "project-memory/catalogs/layouts"

TEXT_CACHE: dict[Path, str] = {}


def text_of(path: Path) -> str:
    if path not in TEXT_CACHE:
        TEXT_CACHE[path] = path.read_text(encoding="utf-8", errors="ignore") if path.exists() else ""
    return TEXT_CACHE[path]


def load(path: Path) -> dict:
    return json.loads(path.read_text(encoding="utf-8", errors="ignore")) if path.exists() else {}


# --- web-side extraction -----------------------------------------------------------------------
TABLE_PATTERNS = [
    re.compile(r"insertRowTx\(\s*tx\s*,\s*'([A-Z0-9_]+)'"),
    re.compile(r"table:\s*'([A-Z0-9_]+)'"),
    re.compile(r'INSERT\s+INTO\s+"([A-Z0-9_]+)"', re.I),
    re.compile(r'UPDATE\s+"([A-Z0-9_]+)"', re.I),
    re.compile(r"tables:\s*\[([^\]]*)\]"),
]
QUOTED_TABLE = re.compile(r"'([A-Z0-9_]{3,})'")
COLUMN = re.compile(r"\b([A-Z][A-Z0-9_]{2,})\s*:")  # object keys like ITM_NWT:
COLUMN_SQL = re.compile(r'"([A-Z][A-Z0-9_]{2,})"')
THROW = re.compile(r"throw new [A-Za-z]*(?:Validation|Config)[A-Za-z]*Error\(")


def web_module_facts(paths: list[Path]) -> dict:
    tables: set[str] = set()
    columns: set[str] = set()
    validations = 0
    loc = 0
    for p in paths:
        body = text_of(p)
        if not body:
            continue
        loc += body.count("\n") + 1
        for pat in TABLE_PATTERNS[:4]:
            tables.update(m.group(1).upper() for m in pat.finditer(body))
        for m in TABLE_PATTERNS[4].finditer(body):
            tables.update(t.upper() for t in QUOTED_TABLE.findall(m.group(1)))
        columns.update(m.group(1) for m in COLUMN.finditer(body))
        columns.update(m.group(1) for m in COLUMN_SQL.finditer(body))
        validations += len(THROW.findall(body))
    return {"tables": tables, "columns": columns, "validations": validations, "loc": loc}


INPUT_TAG = re.compile(r"<(input|select|textarea)\b")
GRID_COL = re.compile(r"data-grid-column=\{?\"?(\d+)")
GRID_CELL = re.compile(r"gridCell\(\s*\w+\s*,\s*(\d+)\s*\)")


def web_page_facts(paths: list[Path]) -> dict:
    inputs = 0
    grid_cols = 0
    loc = 0
    for p in paths:
        body = text_of(p)
        if not body:
            continue
        loc += body.count("\n") + 1
        inputs += len(INPUT_TAG.findall(body))
        cols = [int(m.group(1)) for m in GRID_COL.finditer(body)] + [
            int(m.group(1)) for m in GRID_CELL.finditer(body)
        ]
        if cols:
            grid_cols = max(grid_cols, max(cols) + 1)
    return {"inputs": inputs, "gridColumns": grid_cols, "loc": loc}


def size(value) -> int:
    """Catalog fields are sometimes a list/dict and sometimes already a count."""
    if value is None:
        return 0
    if isinstance(value, (int, float)):
        return int(value)
    try:
        return len(value)
    except TypeError:
        return 0


def pct(part: float, whole: float) -> float | None:
    if not whole:
        return None
    return round(min(100.0, part * 100.0 / whole), 1)


rows: list[dict] = []
for form in MATRIX["forms"]:
    fid = form["id"]
    behavior = load(BEHAVIOR / f"{fid}.behavior.json")
    logic = load(LOGIC / f"{fid}.logic.json")
    layout = load(LAYOUTS / f"{fid}.initcomp.json")

    desk_writes = sorted({t.upper() for t in (form["desktop"].get("writeTables") or [])})
    desk_grid = behavior.get("gridColumns") or {}
    desk_grid_count = size(desk_grid)
    desk_calc = size(behavior.get("calc"))
    desk_valid = size(behavior.get("validations"))
    desk_sql = size(behavior.get("inlineSql"))
    desk_keys = size(behavior.get("keyboard"))
    desk_handlers = size(logic.get("handlers"))
    desk_controls = layout.get("controlCount") or 0
    desk_loc = form["desktop"].get("loc") or behavior.get("loc") or 0

    modules = [ROOT / m for m in (form["web"].get("apiModules") or [])]
    pages = [ROOT / p for p in (form["web"].get("frontendFiles") or [])]
    mf = web_module_facts(modules)
    pf = web_page_facts(pages)

    covered = [t for t in desk_writes if t in mf["tables"]]
    missing = [t for t in desk_writes if t not in mf["tables"]]

    rows.append(
        {
            "form": fid,
            "category": form["category"],
            "severity": form["severity"],
            "mapping": form["mappingClassification"],
            "desktopLoc": desk_loc,
            "desktopWriteTables": len(desk_writes),
            "webWriteTablesCovered": len(covered),
            "writeTableCoveragePct": pct(len(covered), len(desk_writes)),
            "missingWriteTables": missing,
            "desktopValidations": desk_valid,
            "webValidationThrows": mf["validations"],
            "validationRatioPct": pct(mf["validations"], desk_valid),
            "desktopCalcExpressions": desk_calc,
            "desktopInlineSql": desk_sql,
            "desktopGridColumns": desk_grid_count,
            "webGridColumns": pf["gridColumns"],
            "gridColumnRatioPct": pct(pf["gridColumns"], desk_grid_count),
            "desktopControls": desk_controls,
            "webInputs": pf["inputs"],
            "controlRatioPct": pct(pf["inputs"], desk_controls),
            "desktopHandlers": desk_handlers,
            "desktopKeyboardKeys": desk_keys,
            "webModuleLoc": mf["loc"],
            "webPageLoc": pf["loc"],
        }
    )

out_dir = ROOT / "project-memory/parity"
(out_dir / "DEEP-DEPTH-AUDIT.json").write_text(json.dumps(rows, indent=2) + "\n")

txn = [r for r in rows if r["category"] == "transaction"]


def avg(values: list[float | None]) -> float | None:
    real = [v for v in values if v is not None]
    return round(sum(real) / len(real), 1) if real else None


summary = {
    "forms": len(rows),
    "transactionForms": len(txn),
    "writeTableCoverage": {
        "allFormsAvgPct": avg([r["writeTableCoveragePct"] for r in rows]),
        "transactionAvgPct": avg([r["writeTableCoveragePct"] for r in txn]),
        "transactionFormsFullyCovered": sum(1 for r in txn if r["writeTableCoveragePct"] == 100.0),
        "transactionFormsZeroCovered": sum(
            1 for r in txn if (r["writeTableCoveragePct"] or 0) == 0 and r["desktopWriteTables"]
        ),
    },
    "gridColumnCoverage": {"transactionAvgPct": avg([r["gridColumnRatioPct"] for r in txn])},
    "controlCoverage": {"transactionAvgPct": avg([r["controlRatioPct"] for r in txn])},
    "validationCoverage": {"transactionAvgPct": avg([r["validationRatioPct"] for r in txn])},
    "desktopTotals": {
        "calcExpressions": sum(r["desktopCalcExpressions"] for r in rows),
        "validations": sum(r["desktopValidations"] for r in rows),
        "inlineSql": sum(r["desktopInlineSql"] for r in rows),
        "handlers": sum(r["desktopHandlers"] for r in rows),
    },
    "mostMissingWriteTables": Counter(
        t for r in rows for t in r["missingWriteTables"]
    ).most_common(25),
}
(out_dir / "DEEP-DEPTH-AUDIT-SUMMARY.json").write_text(json.dumps(summary, indent=2) + "\n")
print(json.dumps(summary, indent=2))
