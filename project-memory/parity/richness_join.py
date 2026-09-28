#!/usr/bin/env python3
"""Join desktop and web richness per form and compute an operator-visible depth ratio.

The join key is DESKTOP-WEB-PARITY-MATRIX.json, which already maps each of the 204 desktop
forms to the web files that replace it. This script does not re-derive that mapping; it only
attaches the freshly measured richness to both ends of it.

Attribution rule: when several desktop forms map to the same web page, that page's fields are
NOT counted once per form. Each shared page is attributed to the desktop form with the largest
declared surface and the sharing is recorded, so the ratios cannot be inflated by double
counting.

Run:  python3 richness_join.py > RICHNESS-JOIN.json
"""
from __future__ import annotations

import json
import os
import sys
from collections import defaultdict

HERE = os.path.dirname(os.path.abspath(__file__))
REPO = os.path.normpath(os.path.join(HERE, "..", ".."))


def load(name: str) -> dict:
    with open(os.path.join(HERE, name), "r", encoding="utf-8") as fh:
        return json.load(fh)


def main() -> int:
    desktop = load("DESKTOP-RICHNESS.json")
    web = load("WEB-RICHNESS.json")
    matrix = load("DESKTOP-WEB-PARITY-MATRIX.json")

    dforms = {f["form"]: f for f in desktop["forms"]}
    # web pages keyed by repo-relative file path for matching against the matrix
    wpages = {p["file"].replace(os.sep, "/"): p for p in web["pages"]}

    # desktop form -> web files, from the existing mapping
    mapped: dict[str, list[str]] = {}
    for entry in matrix["forms"]:
        files = [f.replace(os.sep, "/") for f in (entry.get("web", {}).get("frontendFiles") or [])]
        mapped[entry["id"]] = files

    # how many desktop forms claim each web file
    claims: dict[str, list[str]] = defaultdict(list)
    for form, files in mapped.items():
        for f in files:
            claims[f].append(form)

    # attribute a shared page to the desktop form with the largest declared surface
    def surface(form: str) -> int:
        d = dforms.get(form)
        if not d:
            return 0
        return d["inputControls"] + d["gridNamedColsTotal"]

    owner: dict[str, str] = {}
    for f, forms in claims.items():
        owner[f] = max(forms, key=surface)

    rows = []
    for entry in matrix["forms"]:
        form = entry["id"]
        d = dforms.get(form)
        files = mapped.get(form, [])
        resolved = [f for f in files if f in wpages]
        owned = [f for f in resolved if owner.get(f) == form]
        w_inputs = sum(wpages[f]["inputControls"] for f in owned)
        w_cols = sum(wpages[f]["gridColumns"] for f in owned)
        d_inputs = d["inputControls"] if d else 0
        d_cols = d["gridNamedColsTotal"] if d else 0
        d_total = d_inputs + d_cols
        w_total = w_inputs + w_cols
        rows.append(
            {
                "form": form,
                "module": d["module"] if d else "unknown",
                "kind": d["kind"] if d else "unknown",
                "severity": entry.get("severity"),
                "mappingClassification": entry.get("mappingClassification"),
                "desktop": {
                    "loc": d["loc"] if d else 0,
                    "inputControls": d_inputs,
                    "gridNamedCols": d_cols,
                    "gridDeclaredCols": d["gridDeclaredColsTotal"] if d else 0,
                    "grids": len(d["grids"]) if d else 0,
                    "validationMessages": d["validationMessages"] if d else 0,
                    "confirmationPrompts": d["confirmationPrompts"] if d else 0,
                    "eventHandlers": d["eventHandlers"] if d else 0,
                    "gridCellEvents": d["gridCellEvents"] if d else 0,
                    "functionKeys": d["functionKeys"] if d else [],
                    "settingsReadCount": d["settingsReadCount"] if d else 0,
                    "surface": d_total,
                },
                "web": {
                    "mappedFiles": files,
                    "unresolvedFiles": [f for f in files if f not in wpages],
                    "ownedFiles": owned,
                    "sharedFiles": [f for f in resolved if owner.get(f) != form],
                    "inputControls": w_inputs,
                    "gridColumns": w_cols,
                    "functionKeys": sorted(
                        {k for f in owned for k in wpages[f]["functionKeys"]},
                        key=lambda s: int(s[1:]),
                    ),
                    "surface": w_total,
                },
                "depthRatioPct": round(100.0 * w_total / d_total, 1) if d_total else None,
                "hasWebSurface": bool(resolved),
            }
        )

    with_surface = [r for r in rows if r["desktop"]["surface"] > 0]
    no_web = [r for r in with_surface if not r["hasWebSurface"]]
    scored = [r for r in with_surface if r["depthRatioPct"] is not None]

    by_module: dict[str, dict] = defaultdict(
        lambda: {
            "forms": 0,
            "desktopSurface": 0,
            "webSurface": 0,
            "desktopGridCols": 0,
            "webGridCols": 0,
            "desktopInputs": 0,
            "webInputs": 0,
        }
    )
    for r in with_surface:
        b = by_module[r["module"]]
        b["forms"] += 1
        b["desktopSurface"] += r["desktop"]["surface"]
        b["webSurface"] += r["web"]["surface"]
        b["desktopGridCols"] += r["desktop"]["gridNamedCols"]
        b["webGridCols"] += r["web"]["gridColumns"]
        b["desktopInputs"] += r["desktop"]["inputControls"]
        b["webInputs"] += r["web"]["inputControls"]
    for b in by_module.values():
        b["depthRatioPct"] = round(100.0 * b["webSurface"] / b["desktopSurface"], 1) if b["desktopSurface"] else None

    # The structural question: does the desktop form get its own web screen, or is it folded
    # into a shared variant / generic scaffold / a headless engine with no screen at all?
    by_class: dict[str, dict] = defaultdict(
        lambda: {"forms": 0, "desktopSurface": 0, "webSurface": 0, "desktopGridCols": 0, "webGridCols": 0}
    )
    for r in with_surface:
        c = r["mappingClassification"] or "unclassified"
        b = by_class[c]
        b["forms"] += 1
        b["desktopSurface"] += r["desktop"]["surface"]
        b["webSurface"] += r["web"]["surface"]
        b["desktopGridCols"] += r["desktop"]["gridNamedCols"]
        b["webGridCols"] += r["web"]["gridColumns"]
    for b in by_class.values():
        b["depthRatioPct"] = round(100.0 * b["webSurface"] / b["desktopSurface"], 1) if b["desktopSurface"] else None

    dsurf = sum(r["desktop"]["surface"] for r in with_surface)
    wsurf = sum(r["web"]["surface"] for r in with_surface)
    json.dump(
        {
            "kind": "richness-join",
            "note": (
                "surface = inputControls + visible grid columns. Desktop grid columns are the "
                "named headers the operator sees; declared Cols is higher because hidden state "
                "columns are included there."
            ),
            "totals": {
                "desktopFormsMeasured": len(with_surface),
                "desktopSurface": dsurf,
                "webSurface": wsurf,
                "overallDepthRatioPct": round(100.0 * wsurf / dsurf, 1) if dsurf else None,
                "formsWithNoWebSurface": len(no_web),
            },
            "byModule": dict(sorted(by_module.items(), key=lambda kv: -kv[1]["desktopSurface"])),
            "byMappingClassification": dict(sorted(by_class.items(), key=lambda kv: -kv[1]["desktopSurface"])),
            "worstByAbsoluteGap": sorted(
                scored, key=lambda r: (r["web"]["surface"] - r["desktop"]["surface"])
            )[:40],
            "formsWithNoWebSurface": sorted(
                ({"form": r["form"], "module": r["module"], "desktopSurface": r["desktop"]["surface"]} for r in no_web),
                key=lambda r: -r["desktopSurface"],
            ),
            "forms": rows,
        },
        sys.stdout,
        indent=1,
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
