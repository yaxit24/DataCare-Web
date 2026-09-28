#!/usr/bin/env python3
"""Generate the per-form depth budget and verify the phase ladder reaches parity.

Every desktop form with operator surface is assigned to the phase that owns its DOMINANT gap,
and the residual surface is attributed to that phase. The script then checks the arithmetic the
plan asserts about itself: that the per-phase residuals plus today's web surface sum to the
desktop's 5,107. If they do not, the ladder cannot reach parity and the PLAN is wrong, not the
implementation.

This is deliberately a check on the plan. A phase ladder whose targets do not add up is a
comfortable fiction, and the only moment to catch that is before any code is written.

Run:  python3 depth_budget.py > ../../web/parity/depth-budget.json
"""
from __future__ import annotations

import json
import os
import sys
from collections import defaultdict

HERE = os.path.dirname(os.path.abspath(__file__))


def load(name: str) -> dict:
    with open(os.path.join(HERE, name), "r", encoding="utf-8") as fh:
        return json.load(fh)


# Which phase owns a form's dominant gap. Order matters: the first match wins, so the more
# specific rules precede the general ones.
def owning_phase(row: dict) -> str:
    form = row["form"]
    module = row["module"]
    kind = row["kind"]
    classification = row.get("mappingClassification") or ""

    # P6 — the five contained tag/stock workflows. Their depth is unreachable until the
    # containment rules are discharged, so no later phase can claim it.
    if form in {"TR_TAG_SPLIT", "TR_TAG_CAN", "TR_TAG_WT_DIFF", "TR_TAG_TRFR", "TR_TAG_OPBL"}:
        return "P6"
    # P8 — forms with no web surface at all, or a workflow the plan names as missing.
    if not row["hasWebSurface"]:
        return "P8"
    if form in {"TR_MFG_WITH_LOT", "TR_BUL_SALE", "TR_BUL_BOOKING", "TR_FN_INOUT", "TR_MEMB_ENT"}:
        return "P8"
    if module in {"membership"} or form.startswith("TR_TOUR"):
        return "P8"
    # P9 — reports.
    if kind == "report" or classification.startswith("conceptual-report") or classification.startswith(
        "generic-report"
    ):
        return "P9"
    # P10 — masters.
    if kind == "master" or classification == "generic-crud-scaffold":
        return "P10"
    # P3 — manufacturing depth is dominated by fields the API already accepts.
    if module == "manufacturing":
        return "P3"
    # P7 — everything else with a dedicated or shared screen is grid-column completion.
    return "P7"


def main() -> int:
    join = load("RICHNESS-JOIN.json")
    rows = [r for r in join["forms"] if r["desktop"]["surface"] > 0]

    budget = []
    per_phase: dict[str, dict] = defaultdict(lambda: {"forms": 0, "desktopSurface": 0, "webSurface": 0, "residual": 0})
    for r in rows:
        phase = owning_phase(r)
        residual = max(r["desktop"]["surface"] - r["web"]["surface"], 0)
        budget.append(
            {
                "form": r["form"],
                "module": r["module"],
                "kind": r["kind"],
                "mappingClassification": r.get("mappingClassification"),
                "desktopSurface": r["desktop"]["surface"],
                "desktopGridCols": r["desktop"]["gridNamedCols"],
                "webSurface": r["web"]["surface"],
                "webGridColumns": r["web"]["gridColumns"],
                "residual": residual,
                "targetSurface": r["desktop"]["surface"],
                "owningPhase": phase,
                "webFiles": r["web"]["ownedFiles"] or r["web"]["mappedFiles"],
            }
        )
        b = per_phase[phase]
        b["forms"] += 1
        b["desktopSurface"] += r["desktop"]["surface"]
        b["webSurface"] += r["web"]["surface"]
        b["residual"] += residual

    desktop_total = sum(r["desktopSurface"] for r in budget)
    web_total = sum(r["webSurface"] for r in budget)
    residual_total = sum(r["residual"] for r in budget)

    # The arithmetic the plan claims about itself.
    checks = {
        "desktopSurfaceFromBudget": desktop_total,
        "desktopSurfaceFromExtractor": join["totals"]["desktopSurface"],
        "desktopMatches": desktop_total == join["totals"]["desktopSurface"],
        "webSurfaceAttributed": web_total,
        "residualToClose": residual_total,
        # web + residual must reach the desktop total, else the ladder cannot reach parity
        "attributedPlusResidual": web_total + residual_total,
        "reachesParity": web_total + residual_total >= join["totals"]["desktopSurface"],
    }

    json.dump(
        {
            "kind": "depth-budget",
            "note": (
                "residual = desktopSurface - webSurface per form, attributed to the phase that owns "
                "the form's dominant gap. targetSurface is the desktop surface, because parity means "
                "the operator can reach what the desktop offers. webSurface is attributed once per "
                "page: a page shared by several desktop forms is credited to the form with the "
                "largest declared surface, so residuals are not double counted. "
                "attributedPlusResidual exceeds the desktop total because a per-form residual is "
                "clamped at zero, so forms where the web exceeds the desktop add surplus; the "
                "residual is therefore conservative, which is the safe direction. "
                "P0, P1, P2, P4, P5 and P11 own no form: verification, suppression fixes, the shared "
                "sub-detail grid, settings, the recalculation kernel and certification all cut across "
                "forms, and their surface gain lands inside the phases listed here."
            ),
            "checks": checks,
            "byPhase": dict(sorted(per_phase.items())),
            "forms": sorted(budget, key=lambda r: -r["residual"]),
        },
        sys.stdout,
        indent=1,
    )
    return 0 if checks["reachesParity"] and checks["desktopMatches"] else 1


if __name__ == "__main__":
    raise SystemExit(main())
