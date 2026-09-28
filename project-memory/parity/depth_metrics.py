"""Depth metrics for the parity generator.

Breadth ("does a surface exist?") was already gated. This module supplies the missing dimension:
does the web persist what the desktop persists, and can an operator capture every grid column?

Single source of truth: `deep_column_audit` does the write-set parsing; nothing is duplicated here.
Guarded by `test_depth_metrics.py`, which pins every parser idiom that once under-reported coverage.
"""

from __future__ import annotations

import json
import re
import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))

import deep_column_audit as dca  # noqa: E402

ROOT = Path(__file__).resolve().parents[2]
BEHAVIOR = ROOT / "project-memory/catalogs/form-behavior"
LAYOUTS = ROOT / "project-memory/catalogs/layouts"
WEB_APP = ROOT / "web/apps/web"

TH = re.compile(r"<th\b")
FIELD = re.compile(r"<(input|select|textarea|LookupPicker|BookSelect|DatePicker)\b")
LOCAL_COMPONENT = re.compile(r"from\s+'(?:\.\./)+components/([A-Za-z0-9_]+)'")

# Desktop grid inventories include hidden bookkeeping columns, so raw grid ratios understate
# real parity. Column-level persistence has no such distortion and is the metric that gates.
GRID_CAVEAT = (
    "Desktop gridColumns includes hidden state columns; treat grid coverage as a lower bound "
    "and columnCoveragePct as authoritative."
)


def _catalog(directory: Path, form: str) -> dict:
    path = directory / f"{form}.behavior.json" if directory is BEHAVIOR else directory / f"{form}.initcomp.json"
    if not path.exists():
        return {}
    try:
        return json.loads(path.read_text(encoding="utf-8", errors="ignore"))
    except json.JSONDecodeError:
        return {}


def _count(value: object) -> int:
    if isinstance(value, (int, float)):
        return int(value)
    try:
        return len(value or [])  # type: ignore[arg-type]
    except TypeError:
        return 0


def _walk_frontend(path: Path, pattern: re.Pattern[str], depth: int = 0, seen: set[Path] | None = None) -> int:
    """Count matches in a page and the local components it renders.

    Pages such as `/txn/karigar-issue` are five lines that delegate to a shared component, so a
    page-only count reports zero fields for a complete screen.
    """
    seen = seen if seen is not None else set()
    if not path.exists() or path in seen or depth > 2:
        return 0
    seen.add(path)
    body = path.read_text(encoding="utf-8", errors="ignore")
    total = len(pattern.findall(body))
    for component in set(LOCAL_COMPONENT.findall(body)):
        for ext in (".tsx", ".ts"):
            candidate = WEB_APP / "components" / f"{component}{ext}"
            if candidate.exists():
                total += _walk_frontend(candidate, pattern, depth + 1, seen)
                break
    return total


def compute(form_frontend: dict[str, list[str]]) -> dict:
    """Depth metrics keyed by form id, plus per-table column coverage and totals."""
    audit = dca.compute()
    tables = {row["table"]: row for row in audit["tables"]}
    forms_columns = {row["form"]: row for row in audit["forms"]}

    forms: dict[str, dict] = {}
    for form, files in form_frontend.items():
        behavior = _catalog(BEHAVIOR, form)
        layout = _catalog(LAYOUTS, form)
        by_kind = layout.get("byKind") or {}

        desktop_grid = _count(behavior.get("gridColumns"))
        desktop_fields = sum(int(by_kind.get(k, 0)) for k in ("textbox", "combo", "check", "masked"))
        web_grid = 0
        web_fields = 0
        for rel_path in files:
            page = ROOT / rel_path
            web_grid += _walk_frontend(page, TH)
            web_fields += _walk_frontend(page, FIELD)

        columns = forms_columns.get(form)
        missing_tables = sorted(
            table
            for table, row in tables.items()
            if not row["webWritesTableAtAll"] and table in (columns or {}).get("perTable", {})
        )
        forms[form] = {
            "desktopWrittenColumns": (columns or {}).get("desktopWrittenColumns", 0),
            "webWrittenColumns": (columns or {}).get("webWrittenColumns", 0),
            "columnCoveragePct": (columns or {}).get("coveragePct"),
            "perTable": (columns or {}).get("perTable", {}),
            "missingTables": missing_tables,
            "desktopGridColumns": desktop_grid,
            "webGridColumns": web_grid,
            "gridCoveragePct": round(min(100.0, web_grid * 100 / desktop_grid), 1) if desktop_grid else None,
            "desktopInputFields": desktop_fields,
            "webInputFields": web_fields,
            "fieldCoveragePct": round(min(100.0, web_fields * 100 / desktop_fields), 1) if desktop_fields else None,
        }

    return {
        "forms": forms,
        "tables": tables,
        "summary": audit["summary"],
        "gridCaveat": GRID_CAVEAT,
    }


def gate_status(metrics: dict | None, *, contract_approved: bool) -> tuple[str, str]:
    """Depth verdict for one form.

    `passed` demands what the plan demands: >=99% of the desktop write set, no missing table,
    >=95% grid coverage and an approved contract. Anything else is honest partial progress.
    """
    if not metrics or not metrics.get("desktopWrittenColumns"):
        return (
            "not_started",
            "No desktop write set is catalogued for this unit, so persistence depth is unmeasurable.",
        )

    column_pct = metrics.get("columnCoveragePct") or 0.0
    grid_pct = metrics.get("gridCoveragePct")
    missing_tables = metrics.get("missingTables") or []
    missing_columns = metrics["desktopWrittenColumns"] - metrics["webWrittenColumns"]

    if column_pct >= 99 and not missing_tables and (grid_pct is None or grid_pct >= 95) and contract_approved:
        return ("passed", f"Persists {column_pct}% of the desktop write set with no missing table.")

    reasons = [f"{missing_columns} of {metrics['desktopWrittenColumns']} desktop columns are not persisted ({column_pct}%)"]
    if missing_tables:
        reasons.append(f"{len(missing_tables)} desktop table(s) never written: {', '.join(missing_tables[:6])}")
    if grid_pct is not None and grid_pct < 95:
        reasons.append(f"grid exposes {grid_pct}% of desktop columns ({GRID_CAVEAT})")
    if not contract_approved:
        reasons.append("no approved per-form contract")
    status = "not_started" if column_pct <= 0 else "in_progress"
    return (status, "; ".join(reasons) + ".")
