#!/usr/bin/env python3
"""
reconcile_reports.py  —  Phase 0 / Task 2
Reconcile code-referenced .rpt that are missing from unified/reports against a WIDE
Raw_Source search, collect (copy) any found, checksum, log conflicts, and flag the
remainder as external-blockers.  Implements Requirement 2.

Default is DRY-RUN (no copying). Pass --apply to actually copy.
Verification = re-run audit_completeness.py and confirm report external-blocker count drops
(or is documented as truly unreachable).
"""
from __future__ import annotations

import argparse
import datetime as _dt
import hashlib
import json
import os
import shutil
from pathlib import Path

PRUNE = {".git", "node_modules", "dist", "build", ".vs", "obj", "bin", "__pycache__"}


def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1 << 20), b""):
            h.update(chunk)
    return h.hexdigest()


def norm(name: str) -> str:
    return name.split("/")[-1].split("\\")[-1].lower()


def index_rpt(search_roots: list[Path], exclude: Path) -> dict[str, list[str]]:
    """name(lower) -> [absolute paths] for every .rpt under search_roots, excluding `exclude`."""
    exclude = exclude.resolve()
    idx: dict[str, list[str]] = {}
    for root in search_roots:
        root = root.resolve()
        if not root.is_dir():
            continue
        for dirpath, dirnames, filenames in os.walk(root):
            dirnames[:] = [d for d in dirnames if d not in PRUNE]
            # never index inside the unified/ tree (that's the destination, not Raw_Source)
            if str(Path(dirpath).resolve()).startswith(str(exclude)):
                dirnames[:] = []
                continue
            for fn in filenames:
                if fn.lower().endswith(".rpt"):
                    idx.setdefault(norm(fn), []).append(str(Path(dirpath, fn)))
    return idx


def missing_reports(manifest_path: Path) -> list[str]:
    m = json.loads(Path(manifest_path).read_text())
    return [a["id"] for a in m["artifacts"]
            if a["category"] == "report" and a["status"] in ("missing", "external-blocker")]


def reconcile(unified_root: Path, manifest_path: Path, search_roots: list[Path], apply: bool) -> dict:
    reports_dir = unified_root / "reports"
    idx = index_rpt(search_roots, exclude=unified_root)
    copied, conflicts, still_missing = [], [], []

    for name in sorted(missing_reports(manifest_path)):
        candidates = idx.get(name, [])
        if not candidates:
            still_missing.append({"report": name, "reason": "not found in any Raw_Source root"})
            continue
        src = Path(candidates[0])
        src_hash = sha256(src)
        # find current dest (case-insensitive) if already present
        dest_existing = next((p for p in reports_dir.glob("*.rpt") if p.name.lower() == name), None)
        if dest_existing is None:
            dest = reports_dir / src.name
            if apply:
                shutil.copy2(src, dest)
            copied.append({"report": name, "src": str(src), "dest": str(dest),
                           "sha256": src_hash, "applied": apply, "alsoFoundAt": candidates[1:]})
        else:
            dest_hash = sha256(dest_existing)
            if dest_hash == src_hash:
                # already present & identical -> nothing to do (shouldn't be in missing list, but safe)
                copied.append({"report": name, "src": str(src), "dest": str(dest_existing),
                               "sha256": src_hash, "applied": False, "note": "already identical"})
            else:
                conflicts.append({"report": name, "src": str(src), "srcSha256": src_hash,
                                  "dest": str(dest_existing), "destSha256": dest_hash,
                                  "resolution": "kept both; unified version unchanged"})

    return {
        "generatedAt": _dt.datetime.now().isoformat(timespec="seconds"),
        "mode": "apply" if apply else "dry-run",
        "searchRoots": [str(r) for r in search_roots],
        "summary": {"copied": len(copied), "conflicts": len(conflicts), "stillMissing": len(still_missing)},
        "copied": copied, "conflicts": conflicts, "stillMissing": still_missing,
    }


def main() -> int:
    here = Path(__file__).resolve()
    unified = here.parents[1]
    repo = here.parents[2]                 # imodule-extracted/
    desktop = repo.parent                  # ~/Desktop
    ap = argparse.ArgumentParser()
    ap.add_argument("--unified", default=str(unified))
    ap.add_argument("--manifest", default=str(repo / "project-memory" / "catalogs" / "completeness-manifest.json"))
    ap.add_argument("--out", default=str(repo / "project-memory" / "catalogs" / "report-reconciliation.json"))
    ap.add_argument("--apply", action="store_true", help="actually copy found reports (default dry-run)")
    ap.add_argument("--roots", nargs="*", default=[
        str(repo), str(desktop / "next"),
    ], help="Raw_Source roots to search")
    args = ap.parse_args()

    result = reconcile(Path(args.unified), Path(args.manifest),
                       [Path(r) for r in args.roots], apply=args.apply)
    Path(args.out).write_text(json.dumps(result, indent=2), encoding="utf-8")
    s = result["summary"]
    print(f"[{result['mode']}] reconciliation -> {args.out}")
    print(f"  copied={s['copied']} conflicts={s['conflicts']} stillMissing={s['stillMissing']}")
    for c in result["copied"]:
        print(f"  + {c['report']:24s} <- {c['src']}")
    for c in result["stillMissing"]:
        print(f"  ? {c['report']:24s} ({c['reason']})")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
