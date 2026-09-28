#!/usr/bin/env python3
"""
build_form_specs.py  —  Phase 0 / Task 4
Per-form business-logic & workflow catalog. Implements Requirement 4.

For each decompiled form in `src/csharp/DataCareNext/*.cs`, mine the actual SQL operations
(filtered to REAL catalog tables from data-model.json) to derive:
  - tables WRITTEN on save (INSERT INTO / UPDATE ... SET)        [Req 4.1, 4.2]
  - tables DELETED / reversed (DELETE FROM)                      [Req 4.4]
  - tables READ (FROM)
  - an ordered save/operation sequence (header->detail->ledger->stock->tax visible) [Req 4.2]
  - a heuristic list of validation guards (MsgBox/return before save)               [Req 4.3]
  - module classification by prefix (master|transaction|report|utility|other)        [Req 4.5]

Outputs:
  - project-memory/catalogs/forms/<FORM>.md   (one per form)
  - project-memory/catalogs/module-map.json
"""
from __future__ import annotations

import argparse
import collections
import datetime as _dt
import json
import re
from pathlib import Path

INSERT_RE = re.compile(r"INSERT\s+INTO\s+([A-Za-z_][A-Za-z0-9_]*)", re.I)
UPDATE_RE = re.compile(r"UPDATE\s+([A-Za-z_][A-Za-z0-9_]*)\s+SET", re.I)
DELETE_RE = re.compile(r"DELETE\s+(?:FROM\s+)?([A-Za-z_][A-Za-z0-9_]*)", re.I)
FROM_RE = re.compile(r"\bFROM\s+([A-Za-z_][A-Za-z0-9_]*)", re.I)
# validation heuristic: a user-facing message + a return (decompiled VB MsgBox/Interaction)
MSG_RE = re.compile(r'(MsgBox|Interaction\.MsgBox|MessageBox\.Show)\s*\(\s*"([^"]{4,120})"', re.I)

PREFIX_MODULE = {"MS": "master", "TR": "transaction", "RP": "report", "UT": "utility"}


def classify_module(form: str) -> str:
    pfx = form.split("_", 1)[0].upper()
    return PREFIX_MODULE.get(pfx, "other")


def extract_ops(text: str, known: set[str]) -> dict:
    """Return write/delete/read tables + ordered op sequence, filtered to known tables."""
    ordered = []  # (line, kind, table)
    counts = collections.Counter()
    for i, line in enumerate(text.splitlines(), 1):
        for kind, rx in (("INSERT", INSERT_RE), ("UPDATE", UPDATE_RE), ("DELETE", DELETE_RE)):
            for m in rx.finditer(line):
                t = m.group(1).upper()
                if t in known:
                    ordered.append((i, kind, t))
                    counts[(kind, t)] += 1
    reads = collections.Counter()
    for m in FROM_RE.finditer(text):
        t = m.group(1).upper()
        if t in known:
            reads[t] += 1
    # collapse consecutive duplicate (kind,table) for a readable sequence
    seq = []
    for line, kind, t in ordered:
        if seq and seq[-1][1] == kind and seq[-1][2] == t:
            continue
        seq.append((line, kind, t))
    writes_insert = sorted({t for (k, t) in counts if k == "INSERT"})
    writes_update = sorted({t for (k, t) in counts if k == "UPDATE"})
    deletes = sorted({t for (k, t) in counts if k == "DELETE"})
    return {
        "tablesInserted": writes_insert,
        "tablesUpdated": writes_update,
        "tablesDeleted": deletes,
        "tablesRead": [t for t, _ in reads.most_common(40)],
        "opCounts": {f"{k} {t}": c for (k, t), c in sorted(counts.items())},
        "sequence": seq,
    }


def extract_validations(text: str, limit: int = 25) -> list[str]:
    seen, out = set(), []
    for m in MSG_RE.finditer(text):
        msg = m.group(2).strip()
        if msg.lower() not in seen:
            seen.add(msg.lower())
            out.append(msg)
        if len(out) >= limit:
            break
    return out


def render_md(form: str, module: str, ops: dict, validations: list[str]) -> str:
    L = [f"# {form}", "", f"- **Module:** {module}",
         f"- **Source:** `src/csharp/DataCareNext/{form}.cs`",
         "- _Auto-extracted baseline (Task 4). Flagship transaction forms are enriched with curated narrative._",
         "", "## Tables written on save"]
    L.append(f"- **INSERT:** {', '.join(ops['tablesInserted']) or '—'}")
    L.append(f"- **UPDATE:** {', '.join(ops['tablesUpdated']) or '—'}")
    L.append("")
    L.append("## Tables deleted / reversed")
    L.append(f"- **DELETE:** {', '.join(ops['tablesDeleted']) or '—'}")
    L.append("")
    L.append("## Tables read")
    L.append(f"- {', '.join(ops['tablesRead']) or '—'}")
    L.append("")
    L.append("## Save / operation sequence (ordered; consecutive dups collapsed)")
    if ops["sequence"]:
        for line, kind, t in ops["sequence"][:80]:
            L.append(f"- L{line}: {kind} {t}")
    else:
        L.append("- (no write ops detected)")
    L.append("")
    L.append("## Validation guards (heuristic, user-facing messages)")
    if validations:
        for v in validations:
            L.append(f"- {v}")
    else:
        L.append("- (none detected)")
    L.append("")
    return "\n".join(L)


def build(unified_root: Path, data_model: Path, out_dir: Path) -> dict:
    known = set(json.loads(Path(data_model).read_text())["tables"].keys())
    src = unified_root / "src" / "csharp" / "DataCareNext"
    out_dir.mkdir(parents=True, exist_ok=True)
    module_map = {}
    mod_counts = collections.Counter()
    for path in sorted(src.glob("*.cs")):
        form = path.stem
        text = path.read_text(errors="ignore")
        module = classify_module(form)
        ops = extract_ops(text, known)
        vals = extract_validations(text)
        (out_dir / f"{form}.md").write_text(render_md(form, module, ops, vals), encoding="utf-8")
        module_map[form] = {
            "module": module, "file": f"src/csharp/DataCareNext/{form}.cs",
            "tablesInserted": ops["tablesInserted"], "tablesUpdated": ops["tablesUpdated"],
            "tablesDeleted": ops["tablesDeleted"],
            "writeOps": len(ops["sequence"]), "validations": len(vals),
        }
        mod_counts[module] += 1
    summary = {
        "generatedAt": _dt.datetime.now().isoformat(timespec="seconds"),
        "formsCataloged": len(module_map),
        "byModule": dict(mod_counts),
        "transactionFormsWithPosting": sorted(
            f for f, v in module_map.items()
            if v["module"] == "transaction" and (v["tablesInserted"] or v["tablesUpdated"])),
    }
    payload = {"summary": summary, "forms": module_map}
    (out_dir.parent / "module-map.json").write_text(json.dumps(payload, indent=2), encoding="utf-8")
    return summary


def main() -> int:
    here = Path(__file__).resolve()
    unified = here.parents[1]
    repo = here.parents[2]
    ap = argparse.ArgumentParser()
    ap.add_argument("--unified", default=str(unified))
    ap.add_argument("--data-model", default=str(repo / "project-memory" / "catalogs" / "data-model.json"))
    ap.add_argument("--out", default=str(repo / "project-memory" / "catalogs" / "forms"))
    args = ap.parse_args()
    s = build(Path(args.unified), Path(args.data_model), Path(args.out))
    print(f"forms cataloged: {s['formsCataloged']}  byModule={s['byModule']}")
    print(f"transaction forms with posting: {len(s['transactionFormsWithPosting'])}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
