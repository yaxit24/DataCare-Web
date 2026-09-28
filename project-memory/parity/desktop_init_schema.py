#!/usr/bin/env python3
"""Extract the schema the desktop's initialisation buttons declare.

WHY THIS EXISTS
---------------
`MS_UPDATE` has six buttons whose whole job is to CREATE or ALTER tables at runtime:
`btnFildUpdate`, `btnFildUpdate2`, `BtnImgData`, `BtnCrmData`, `btnSchmData` and the image-database
initialiser. They are SQL Server DDL executed from the UI.

The web cannot reproduce that literally and should not try: schema is owned by migrations, and a server that
runs DDL on a button press is a server whose schema nobody can reason about. Under the behavioural-adaptation
decision the faithful translation is a READINESS CHECK — assert that every table and column the desktop's
initialiser would create actually exists, and report anything absent.

That is genuinely useful rather than a formality: it catches a partially migrated database, which is exactly
the failure the desktop buttons existed to repair.

Output: DESKTOP-INIT-SCHEMA.json — {"tables": {TABLE: [COLUMN, ...]}, "sources": [...]}
"""

from __future__ import annotations

import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
DESKTOP = ROOT / "unified" / "src" / "csharp" / "DataCareNext"
OUT = Path(__file__).resolve().parent / "DESKTOP-INIT-SCHEMA.json"

# Every string literal that is a CREATE TABLE or an ALTER TABLE ... ADD.
CREATE_RE = re.compile(r'"\s*(CREATE TABLE\s+(\w+)\s*\((.*?)\))\s*"', re.S | re.I)
ALTER_RE = re.compile(r'"\s*ALTER TABLE\s+(\w+)\s+ADD\s+([A-Z_0-9]+)\s', re.I)

# A column definition starts with the name; the rest is its type, which the web does not need because the
# real types live in the Prisma schema. Only presence is being checked.
COL_RE = re.compile(r"(?:^|,)\s*([A-Z][A-Z_0-9]{1,})\s+(?:VARCHAR|NVARCHAR|FLOAT|INT|DATETIME|DATE|BIT|MONEY|DECIMAL|NUMERIC|TEXT|IMAGE|REAL|SMALLINT|BIGINT|CHAR)", re.I)

# Words that are SQL syntax rather than columns, in case a definition is malformed.
NOT_COLUMNS = {"PRIMARY", "KEY", "CONSTRAINT", "FOREIGN", "REFERENCES", "DEFAULT", "NOT", "NULL", "IDENTITY"}


def split_columns(body: str) -> list[str]:
    """Column names from a CREATE TABLE body, ignoring the trailing PRIMARY KEY clause."""
    # Cut everything from the first PRIMARY KEY, which lists columns again and would double-count.
    cut = re.split(r"\bPRIMARY\s+KEY\b", body, maxsplit=1, flags=re.I)[0]
    out: list[str] = []
    for m in COL_RE.finditer(cut):
        name = m.group(1).upper()
        if name in NOT_COLUMNS or name in out:
            continue
        out.append(name)
    return out


def main() -> int:
    if not DESKTOP.is_dir():
        print(f"desktop source missing: {DESKTOP}", file=sys.stderr)
        return 2

    tables: dict[str, list[str]] = {}
    sources: list[str] = []

    for path in sorted(DESKTOP.glob("*.cs")):
        src = path.read_text(encoding="utf-8", errors="ignore")
        if "CREATE TABLE" not in src.upper() and "ALTER TABLE" not in src.upper():
            continue
        found = False

        for m in CREATE_RE.finditer(src):
            table = m.group(2).upper()
            cols = split_columns(m.group(3))
            if not cols:
                continue
            found = True
            existing = tables.setdefault(table, [])
            for c in cols:
                if c not in existing:
                    existing.append(c)

        for m in ALTER_RE.finditer(src):
            table, col = m.group(1).upper(), m.group(2).upper()
            if col in NOT_COLUMNS:
                continue
            found = True
            existing = tables.setdefault(table, [])
            if col not in existing:
                existing.append(col)

        if found:
            sources.append(path.name)

    payload = {
        "generatedBy": "project-memory/parity/desktop_init_schema.py",
        "note": (
            "Tables and columns the desktop's initialisation buttons create at runtime. The web owns schema "
            "through migrations, so this is used as a READINESS CHECK rather than executed."
        ),
        "tableCount": len(tables),
        "columnCount": sum(len(v) for v in tables.values()),
        "sources": sources,
        "tables": {k: sorted(v) for k, v in sorted(tables.items())},
    }
    OUT.write_text(json.dumps(payload, indent=1) + "\n")
    print(f"tables {len(tables)}  columns {payload['columnCount']}  from {len(sources)} source files")
    print(f"wrote {OUT.relative_to(ROOT)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
