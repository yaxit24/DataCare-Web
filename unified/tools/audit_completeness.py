#!/usr/bin/env python3
"""
audit_completeness.py  —  Phase 0 / Task 1
Completeness audit for the DataCareNext `unified/` resource center.

Implements Requirement 1 (Extraction Completeness Inventory):
  - 1.1 enumerate every reachable .rpt referenced by code, record present/missing vs unified/reports
  - 1.2 enumerate form/module source files referenced by the app vs unified/src
  - 1.3 enumerate DB tables (database_tables.txt) vs CREATE TABLE in 01_Schema.sql
  - 1.4 enumerate third-party DLLs, .resx, fonts, config and record presence/absence
  - 1.5 write a Completeness_Manifest: {artifact, category, status: present|missing|external-blocker}
  - 1.6 for missing artifacts, record identifier + Raw_Source location (if any)

Pure-stdlib (works on python3.x). Functions are import-friendly for Tier-1 unit tests.
Targets the CURRENT canonical unified/ layout (src/csharp, reports/, database/schema/...),
NOT the legacy extracted_code/ layout used by audit_next1106_parity.py.
"""
from __future__ import annotations

import argparse
import datetime as _dt
import json
import os
import re
from pathlib import Path

# ----------------------------------------------------------------------------
# Canonical unified/ layout contract (Req 1: "canonical directory contract")
# ----------------------------------------------------------------------------
CANONICAL_LAYOUT = {
    "src/csharp": "Primary decompiled C# (golden master = DataCareNext Jun 2026)",
    "src/csharp_nextdm": "NextDm variant decompiled C#",
    "src/vbnet": "Original VB.NET source",
    "reports": "Crystal .rpt report templates",
    "database/schema": "SQL Server DDL (01_Schema.sql)",
    "database/backups": "SQL Server .bak/.mdf/.ldf",
    "database/csv": "GST export CSVs",
    "libs": "Third-party DLLs (DevExpress, Crystal, DotNetBar, interop, other)",
    "resources": "Embedded .resx (DataCareNext, NextDm)",
    "config": "App/runtime configuration",
    "fonts": "Custom fonts (barcode, locale)",
    "images": "Image assets",
    "templates": "Excel/data templates",
    "extraction_metadata": "Analysis artifacts (categorized, audit, string dumps)",
    "tools": "Build & audit scripts",
    "docs": "Documentation",
}

RPT_RE = re.compile(r'"([^"]+\.rpt)"', re.IGNORECASE)
CREATE_TABLE_RE = re.compile(r"CREATE\s+TABLE\s+([A-Za-z0-9_]+)\s*\(", re.IGNORECASE)

# Raw_Source roots (outside unified/) to search for missing artifacts (Req 1.6 / Req 2).
RAW_SOURCE_SUBDIRS = [
    ".",  # loose .rpt at imodule-extracted/ root
    "Report",
    "DataCareSetup",
    "DataCareSetup_extracted",
    "DataCareNext_Source",
    "new",
    "extracted_code",
]
PRUNE_DIRS = {"unified", ".git", "node_modules", "dist", "build", ".vs", "obj", "bin"}


def _norm_rpt(name: str) -> str:
    """Base filename, lowercased, for case-insensitive .rpt comparison."""
    base = re.split(r"[\\/]", name)[-1]
    return base.lower()


# ----------------------------------------------------------------------------
# Scanners (pure: take roots, return data)
# ----------------------------------------------------------------------------
def rpt_files_present(unified_root: Path) -> dict[str, str]:
    """Map normalized .rpt name -> relative path, for files in unified/reports."""
    out: dict[str, str] = {}
    reports = unified_root / "reports"
    if reports.is_dir():
        for p in reports.glob("*.rpt"):
            out[_norm_rpt(p.name)] = str(p.relative_to(unified_root))
    return out


def rpt_referenced_in_code(unified_root: Path) -> dict[str, list[str]]:
    """Map normalized .rpt name -> list of source files that reference it."""
    refs: dict[str, list[str]] = {}
    src = unified_root / "src" / "csharp"
    if not src.is_dir():
        return refs
    for path in src.rglob("*.cs"):
        try:
            text = path.read_text(errors="ignore")
        except OSError:
            continue
        for m in RPT_RE.finditer(text):
            key = _norm_rpt(m.group(1))
            refs.setdefault(key, [])
            rel = str(path.relative_to(unified_root))
            if rel not in refs[key]:
                refs[key].append(rel)
    return refs


def rpt_referenced_in_audit_lists(unified_root: Path) -> set[str]:
    """Names from the legacy *-missing-rpt.txt lists (extra reachability signal)."""
    names: set[str] = set()
    audit = unified_root / "extraction_metadata" / "audit"
    for fname in ("datacarenext-missing-rpt.txt", "nextdm-missing-rpt.txt"):
        f = audit / fname
        if f.is_file():
            for line in f.read_text(errors="ignore").splitlines():
                line = line.strip()
                if line.lower().endswith(".rpt"):
                    names.add(_norm_rpt(line))
    return names


def schema_tables(schema_path: Path) -> set[str]:
    """Set of UPPER table names defined by CREATE TABLE in the DDL."""
    if not schema_path.is_file():
        return set()
    text = schema_path.read_text(errors="ignore")
    return {m.group(1).upper() for m in CREATE_TABLE_RE.finditer(text)}


def expected_tables(tables_txt: Path) -> list[str]:
    """Table names listed in database_tables.txt (one per line)."""
    if not tables_txt.is_file():
        return []
    out = []
    for line in tables_txt.read_text(errors="ignore").splitlines():
        line = line.strip()
        if line and not line.startswith("#"):
            out.append(line)
    return out


def list_present(unified_root: Path, subdir: str, patterns: list[str]) -> dict[str, str]:
    """Map filename -> relative path for files matching patterns under subdir (recursive)."""
    out: dict[str, str] = {}
    base = unified_root / subdir
    if not base.is_dir():
        return out
    for pat in patterns:
        for p in base.rglob(pat):
            if p.is_file():
                out[p.name] = str(p.relative_to(unified_root))
    return out


def index_raw_source_rpt(raw_root: Path) -> dict[str, str]:
    """Index .rpt files under Raw_Source roots (excluding unified/) -> name->path."""
    out: dict[str, str] = {}
    for sub in RAW_SOURCE_SUBDIRS:
        base = (raw_root / sub).resolve()
        if not base.is_dir():
            continue
        for dirpath, dirnames, filenames in os.walk(base):
            dirnames[:] = [d for d in dirnames if d not in PRUNE_DIRS]
            for fn in filenames:
                if fn.lower().endswith(".rpt"):
                    out.setdefault(_norm_rpt(fn), str(Path(dirpath, fn)))
    return out


# ----------------------------------------------------------------------------
# Manifest builder (Req 1.5 / 1.6)
# ----------------------------------------------------------------------------
def build_manifest(unified_root: Path, raw_root: Path) -> dict:
    unified_root = Path(unified_root)
    raw_root = Path(raw_root)
    artifacts: list[dict] = []

    # --- Req 1.1 reports ---
    present_rpt = rpt_files_present(unified_root)
    code_refs = rpt_referenced_in_code(unified_root)
    audit_refs = rpt_referenced_in_audit_lists(unified_root)
    referenced = set(code_refs) | audit_refs
    raw_rpt = index_raw_source_rpt(raw_root)
    for name in sorted(referenced):
        if name in present_rpt:
            artifacts.append({
                "id": name, "category": "report", "status": "present",
                "location": present_rpt[name], "rawSourceLocation": None,
                "referencedBy": code_refs.get(name, []),
            })
        else:
            raw_loc = raw_rpt.get(name)
            artifacts.append({
                "id": name, "category": "report",
                "status": "missing" if raw_loc else "external-blocker",
                "location": None, "rawSourceLocation": raw_loc,
                "referencedBy": code_refs.get(name, []),
            })

    # --- Req 1.3 db tables ---
    defined = schema_tables(unified_root / "database" / "schema" / "01_Schema.sql")
    for tbl in expected_tables(unified_root / "extraction_metadata" / "database_tables.txt"):
        artifacts.append({
            "id": tbl, "category": "db_table",
            "status": "present" if tbl.upper() in defined else "missing",
            "location": "database/schema/01_Schema.sql" if tbl.upper() in defined else None,
            "rawSourceLocation": None, "referencedBy": [],
        })

    # --- Req 1.4 libs / resx / fonts / config (presence inventory) ---
    for cat, sub, pats in [
        ("lib", "libs", ["*.dll"]),
        ("resx", "resources", ["*.resx"]),
        ("font", "fonts", ["*.ttf", "*.TTF", "*.otf"]),
        ("config", "config", ["*"]),
    ]:
        for fname, rel in sorted(list_present(unified_root, sub, pats).items()):
            artifacts.append({
                "id": fname, "category": cat, "status": "present",
                "location": rel, "rawSourceLocation": None, "referencedBy": [],
            })

    # --- Req 1.2 source forms (presence inventory) ---
    for fname, rel in sorted(list_present(unified_root, "src/csharp/DataCareNext", ["*.cs"]).items()):
        artifacts.append({
            "id": fname, "category": "source_form", "status": "present",
            "location": rel, "rawSourceLocation": None, "referencedBy": [],
        })

    # --- layout contract check ---
    layout_check = {
        sub: (unified_root / sub).is_dir() for sub in CANONICAL_LAYOUT
    }

    # --- summary ---
    summary: dict[str, dict[str, int]] = {}
    for a in artifacts:
        c = summary.setdefault(a["category"], {"present": 0, "missing": 0, "external-blocker": 0})
        c[a["status"]] += 1

    return {
        "generatedAt": _dt.datetime.now().isoformat(timespec="seconds"),
        "unifiedRoot": str(unified_root),
        "rawRoot": str(raw_root),
        "canonicalLayout": CANONICAL_LAYOUT,
        "layoutCheck": layout_check,
        "summary": summary,
        "totals": {
            "artifacts": len(artifacts),
            "present": sum(s.get("present", 0) for s in summary.values()),
            "missing": sum(s.get("missing", 0) for s in summary.values()),
            "external_blocker": sum(s.get("external-blocker", 0) for s in summary.values()),
        },
        "artifacts": artifacts,
    }


def main() -> int:
    ap = argparse.ArgumentParser(description="DataCareNext unified/ completeness audit")
    here = Path(__file__).resolve()
    default_unified = here.parents[1]               # unified/
    default_raw = here.parents[2]                   # imodule-extracted/
    ap.add_argument("--unified", default=str(default_unified))
    ap.add_argument("--raw", default=str(default_raw))
    ap.add_argument("--out", default=str(default_raw / "project-memory" / "catalogs" / "completeness-manifest.json"))
    args = ap.parse_args()

    manifest = build_manifest(Path(args.unified), Path(args.raw))
    out = Path(args.out)
    out.parent.mkdir(parents=True, exist_ok=True)
    out.write_text(json.dumps(manifest, indent=2), encoding="utf-8")

    t = manifest["totals"]
    print(f"manifest -> {out}")
    print(f"artifacts={t['artifacts']} present={t['present']} missing={t['missing']} external_blocker={t['external_blocker']}")
    for cat, c in sorted(manifest["summary"].items()):
        print(f"  {cat:12s} present={c['present']:5d} missing={c['missing']:4d} blocker={c['external-blocker']:4d}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
