#!/usr/bin/env python3
"""
build_data_model.py  —  Phase 0 / Task 3
Build a structured data-model catalog for the web rebuild. Implements Requirement 3.

Sources, in order of authority:
  1. DDL  — `database/schema/01_Schema.sql` (100 tables): authoritative columns/types/PK.
  2. CODE — decompiled C# in `src/csharp/DataCareNext/*.cs`: recover columns for tables MISSING
            from the DDL via `INSERT INTO <T> (col, col, ...)` column lists (very reliable here).
  3. Type inference — apply a global column->type map learned from the DDL tables to code-recovered
            columns (column names are consistent across this denormalized schema).

Outputs:
  - project-memory/catalogs/data-model.json
Excludes string-dump noise names. Flags tables referenced but unrecoverable.
Authoritative types for code-recovered tables can later be confirmed via Docker mssql (backups).
"""
from __future__ import annotations

import argparse
import collections
import datetime as _dt
import json
import re
from pathlib import Path

TENANT_KEYS = ["CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK"]
NOISE = {"PLEASE", "THIS", "USER", "SYS", "WIN32_PROCESS", "APP_CHATMESSAGES", "WEBHOOKINBOX",
         "ROWLIMIT", "GROUPCOUNT", "DETAIL", "STOCKDATA", "DISTINCTTAGS", "BAR_IDTL_NOISE",
         "PERMANTLEY"}
# NOTE: BAR_IDTL is REAL (kept); only the lowercase 'Bar_Idtl' string-dump dup is noise, which
# collapses into BAR_IDTL after upper-casing, so it is harmless.

CREATE_TABLE_RE = re.compile(r"CREATE\s+TABLE\s+([A-Za-z0-9_]+)\s*\(", re.I)
INSERT_RE = re.compile(r"INSERT\s+INTO\s+([A-Za-z_][A-Za-z0-9_]*)\s*\(([^)]*)\)", re.I)
UPDATE_RE = re.compile(r"UPDATE\s+([A-Za-z_][A-Za-z0-9_]*)\s+SET\s+([^\"]{0,4000})", re.I)
SETCOL_RE = re.compile(r"([A-Za-z_][A-Za-z0-9_]*)\s*=")
_SQL_KW = {"AND", "OR", "SET", "WHERE", "FROM", "CASE", "WHEN", "THEN", "ELSE", "END", "NULL"}
PK_RE = re.compile(r"PRIMARY\s+KEY\s*\(([^)]*)\)", re.I)
DEFAULT_RE = re.compile(r"DEFAULT\s+('[^']*'|\"[^\"]*\"|[^\s,]+)", re.I)
NOTNULL_RE = re.compile(r"NOT\s+NULL", re.I)
IDENT_RE = re.compile(r"^[A-Za-z_][A-Za-z0-9_]*$")


def _balanced_body(text: str, open_idx: int) -> str:
    """Return substring inside the parens starting at text[open_idx]=='('."""
    depth = 0
    out = []
    for ch in text[open_idx:]:
        if ch == "(":
            depth += 1
            if depth == 1:
                continue
        elif ch == ")":
            depth -= 1
            if depth == 0:
                break
        out.append(ch)
    return "".join(out)


def _split_top_level(body: str) -> list[str]:
    parts, depth, cur = [], 0, []
    for ch in body:
        if ch == "(":
            depth += 1; cur.append(ch)
        elif ch == ")":
            depth -= 1; cur.append(ch)
        elif ch == "," and depth == 0:
            parts.append("".join(cur)); cur = []
        else:
            cur.append(ch)
    if "".join(cur).strip():
        parts.append("".join(cur))
    return parts


def _parse_type(remainder: str) -> tuple[str, int | None]:
    toks = remainder.split()
    if not toks:
        return "unknown", None
    t = toks[0]
    m = re.match(r"([A-Za-z]+)\s*\((\d+)", t)
    if m:
        return m.group(1).upper(), int(m.group(2))
    return re.sub(r"[^A-Za-z]", "", t).upper() or "unknown", None


def parse_ddl(schema_text: str) -> dict:
    """Parse CREATE TABLE defs -> {TABLE: {columns, primaryKey, tenantKeys, source}}."""
    tables: dict[str, dict] = {}
    for m in CREATE_TABLE_RE.finditer(schema_text):
        name = m.group(1).upper()
        body = _balanced_body(schema_text, schema_text.index("(", m.end() - 1))
        columns, pk = [], []
        for part in _split_top_level(body):
            part = part.strip()
            if not part:
                continue
            pkm = PK_RE.search(part)
            if pkm:
                pk = [c.strip().upper() for c in pkm.group(1).split(",") if c.strip()]
                part = part[:pkm.start()].strip()
                if not part:
                    continue
            toks = part.split()
            if not toks or not IDENT_RE.match(toks[0]):
                continue
            if toks[0].upper() in ("PRIMARY", "CONSTRAINT", "FOREIGN", "UNIQUE", "CHECK", "KEY"):
                continue
            col = toks[0].upper()
            typ, length = _parse_type(" ".join(toks[1:]))
            dm = DEFAULT_RE.search(part)
            columns.append({
                "name": col, "type": typ, "length": length,
                "nullable": not bool(NOTNULL_RE.search(part)),
                "default": dm.group(1) if dm else None, "source": "ddl",
            })
        tables[name] = {
            "columns": columns, "primaryKey": pk,
            "tenantKeys": [k for k in TENANT_KEYS if any(c["name"] == k for c in columns)],
            "source": "ddl",
        }
    return tables


def recover_columns_from_code(src_dir: Path) -> dict[str, list[str]]:
    """TABLE(upper) -> ordered unique column names seen in INSERT INTO column lists."""
    found: dict[str, "collections.OrderedDict[str, None]"] = {}
    if not src_dir.is_dir():
        return {}
    for path in src_dir.rglob("*.cs"):
        try:
            text = path.read_text(errors="ignore")
        except OSError:
            continue
        for m in INSERT_RE.finditer(text):
            tbl = m.group(1).upper()
            cols_raw = m.group(2)
            od = found.setdefault(tbl, collections.OrderedDict())
            for c in cols_raw.split(","):
                c = c.strip().upper()
                if IDENT_RE.match(c):
                    od.setdefault(c, None)
        for m in UPDATE_RE.finditer(text):
            tbl = m.group(1).upper()
            seg = re.split(r"\bWHERE\b", m.group(2), 1, flags=re.I)[0]
            od = found.setdefault(tbl, collections.OrderedDict())
            for cm in SETCOL_RE.finditer(seg):
                c = cm.group(1).upper()
                if IDENT_RE.match(c) and c not in _SQL_KW:
                    od.setdefault(c, None)
    return {t: list(od.keys()) for t, od in found.items()}


def global_type_map(ddl_tables: dict) -> dict[str, str]:
    counter: dict[str, collections.Counter] = collections.defaultdict(collections.Counter)
    for t in ddl_tables.values():
        for c in t["columns"]:
            counter[c["name"]][(c["type"], c["length"])] += 1
    return {name: cnt.most_common(1)[0][0] for name, cnt in counter.items()}


def build(unified_root: Path, tables_txt: Path) -> dict:
    schema = (unified_root / "database" / "schema" / "01_Schema.sql").read_text(errors="ignore")
    ddl = parse_ddl(schema)
    code = recover_columns_from_code(unified_root / "src" / "csharp" / "DataCareNext")
    tmap = global_type_map(ddl)

    expected = []
    for line in tables_txt.read_text(errors="ignore").splitlines():
        n = line.strip().upper()
        if n and n not in NOISE:
            expected.append(n)
    # union of expected + any DDL table (some DDL tables may not be in list)
    all_tables = sorted(set(expected) | set(ddl))

    catalog: dict[str, dict] = {}
    unresolved = []
    for name in all_tables:
        if name in NOISE:
            continue
        if name in ddl:
            catalog[name] = ddl[name]
        elif name in code and code[name]:
            cols = []
            for cn in code[name]:
                typ, length = tmap.get(cn, ("unknown", None))
                cols.append({
                    "name": cn, "type": typ, "length": length, "nullable": True,
                    "default": None,
                    "source": "code+inferred-type" if typ != "unknown" else "code",
                })
            catalog[name] = {
                "columns": cols, "primaryKey": [],
                "tenantKeys": [k for k in TENANT_KEYS if any(c["name"] == k for c in cols)],
                "source": "code",
            }
        else:
            unresolved.append(name)

    by_source = collections.Counter(t["source"] for t in catalog.values())
    return {
        "generatedAt": _dt.datetime.now().isoformat(timespec="seconds"),
        "summary": {
            "tablesCataloged": len(catalog),
            "fromDDL": by_source.get("ddl", 0),
            "fromCODE": by_source.get("code", 0),
            "unresolved": len(unresolved),
            "noiseExcluded": sorted(NOISE),
            "totalColumns": sum(len(t["columns"]) for t in catalog.values()),
        },
        "unresolvedTables": unresolved,
        "tenantKeyOrder": TENANT_KEYS,
        "tables": catalog,
    }


def main() -> int:
    here = Path(__file__).resolve()
    unified = here.parents[1]
    repo = here.parents[2]
    ap = argparse.ArgumentParser()
    ap.add_argument("--unified", default=str(unified))
    ap.add_argument("--tables", default=str(unified / "extraction_metadata" / "database_tables.txt"))
    ap.add_argument("--out", default=str(repo / "project-memory" / "catalogs" / "data-model.json"))
    args = ap.parse_args()
    model = build(Path(args.unified), Path(args.tables))
    Path(args.out).write_text(json.dumps(model, indent=2), encoding="utf-8")
    s = model["summary"]
    print(f"data-model -> {args.out}")
    print(f"  tables={s['tablesCataloged']} (ddl={s['fromDDL']} code={s['fromCODE']}) "
          f"columns={s['totalColumns']} unresolved={s['unresolved']}")
    if model["unresolvedTables"]:
        print("  unresolved:", ", ".join(model["unresolvedTables"]))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
