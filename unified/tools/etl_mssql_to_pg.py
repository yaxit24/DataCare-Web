#!/usr/bin/env python3
"""
etl_mssql_to_pg.py  —  Phase 1 / Task 8
SQL Server -> PostgreSQL migration ETL (Req 5 data layer; feeds Tier-4 parity).

This module is the PURE, unit-tested core: per-column type/precision coercion + row mapping
(+ tenant_id injection), driven by project-memory/catalogs/data-model.json and the SAME type
policy as gen_prisma.py. The live EXTRACT (pyodbc/pymssql) and LOAD (psycopg) are thin adapters
documented in run_etl(); they need a restored SQL Server golden master + a Postgres target
(both available now that Docker is up: mssql container + the web docker-compose postgres on :5433).
"""
from __future__ import annotations

import argparse
import datetime as _dt
import json
import re
from decimal import Decimal, ROUND_HALF_UP
from pathlib import Path

import gen_prisma  # same tools dir: reuse the exact type policy


def decimal_scale(dbattr: str) -> int | None:
    m = re.search(r"@db\.Decimal\(\d+,\s*(\d+)\)", dbattr or "")
    return int(m.group(1)) if m else None


def coerce_value(value, col: dict):
    """Coerce a source value to the target Postgres representation per the column's mapped type."""
    if value is None:
        return None
    ptype, dbattr = gen_prisma.map_type(col)
    if ptype == "Decimal":
        scale = decimal_scale(dbattr) or 2
        q = Decimal(10) ** -scale
        return float(Decimal(str(value)).quantize(q, rounding=ROUND_HALF_UP))
    if ptype == "DateTime":
        if isinstance(value, (_dt.date, _dt.datetime)):
            return value.strftime("%Y-%m-%d") if "@db.Date" in dbattr else value.isoformat()
        s = str(value)
        return s[:10] if "@db.Date" in dbattr else s
    if ptype in ("Int", "BigInt"):
        return int(value)
    if ptype == "Boolean":
        return bool(value) if not isinstance(value, str) else value.strip() in ("1", "Y", "T", "true", "True")
    if ptype == "Bytes":
        return value
    return str(value)


def map_row(columns: list[dict], src_row: dict, tenant_id: str) -> dict:
    """Build a target row: tenant_id + coerced values for known columns (source keys upper-cased)."""
    by_name = {c["name"]: c for c in columns}
    upper = {str(k).upper(): v for k, v in src_row.items()}
    out: dict = {"tenant_id": tenant_id}
    for name, col in by_name.items():
        if name in upper:
            out[name] = coerce_value(upper[name], col)
    return out


def load_model(path: Path) -> dict:
    return json.loads(Path(path).read_text())["tables"]


def run_etl(*_args, **_kwargs):  # pragma: no cover - live adapter (needs both DBs)
    """LIVE adapter (documented; not unit-tested):
      1. EXTRACT: connect to restored SQL Server golden master (pyodbc/pymssql), SELECT * per table.
      2. TRANSFORM: map_row(columns, src_row, tenant_id) for each row.
      3. LOAD: psycopg COPY/INSERT into Postgres (:5433), set_config('app.tenant_id', tenant_id) first.
    Run only after restoring a backup in mcr.microsoft.com/mssql/server and installing pyodbc+psycopg.
    """
    raise NotImplementedError("Live ETL adapter: restore SQL Server backup + install pyodbc/psycopg.")


def main() -> int:
    here = Path(__file__).resolve()
    repo = here.parents[2]
    ap = argparse.ArgumentParser()
    ap.add_argument("--data-model", default=str(repo / "project-memory" / "catalogs" / "data-model.json"))
    ap.add_argument("--table", help="show coercion plan for one table")
    args = ap.parse_args()
    tables = load_model(Path(args.data_model))
    if args.table:
        cols = tables[args.table.upper()]["columns"]
        for c in cols[:30]:
            print(f"  {c['name']:24s} {c['type']:10s} -> {gen_prisma.map_type(c)}")
    else:
        print(f"loaded data-model: {len(tables)} tables. Use --table NAME to preview coercion.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
