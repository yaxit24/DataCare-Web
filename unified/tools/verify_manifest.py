#!/usr/bin/env python3
"""
verify_manifest.py  —  Phase 0 / Task 5
CI gate: fail (exit 1) if any artifact marked `present` in the Completeness_Manifest is missing
on disk, or if any canonical layout dir is absent. Implements the Task-5 "CI fails if any
present-artifact path is missing" check.
"""
from __future__ import annotations

import argparse
import json
import sys
from pathlib import Path


def verify(unified_root: Path, manifest_path: Path) -> dict:
    manifest = json.loads(Path(manifest_path).read_text())
    missing_present, checked = [], 0
    for a in manifest.get("artifacts", []):
        if a.get("status") == "present" and a.get("location"):
            checked += 1
            if not (unified_root / a["location"]).exists():
                missing_present.append({"id": a["id"], "category": a["category"], "location": a["location"]})
    layout_missing = [sub for sub, ok in manifest.get("layoutCheck", {}).items() if not ok]
    return {
        "checkedPresent": checked,
        "missingPresent": missing_present,
        "layoutMissing": layout_missing,
        "ok": not missing_present and not layout_missing,
    }


def main() -> int:
    here = Path(__file__).resolve()
    unified = here.parents[1]
    repo = here.parents[2]
    ap = argparse.ArgumentParser()
    ap.add_argument("--unified", default=str(unified))
    ap.add_argument("--manifest", default=str(repo / "project-memory" / "catalogs" / "completeness-manifest.json"))
    args = ap.parse_args()
    r = verify(Path(args.unified), Path(args.manifest))
    print(f"verify_manifest: checked {r['checkedPresent']} present artifacts; "
          f"missing={len(r['missingPresent'])} layoutMissing={len(r['layoutMissing'])}")
    for m in r["missingPresent"][:50]:
        print(f"  MISSING {m['category']}: {m['location']}")
    for s in r["layoutMissing"]:
        print(f"  LAYOUT MISSING: {s}")
    if not r["ok"]:
        print("FAIL: present-artifact integrity broken")
        return 1
    print("OK: all present artifacts exist; canonical layout intact")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
