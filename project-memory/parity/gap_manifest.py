#!/usr/bin/env python3
"""Find API input fields no frontend file can supply, and desktop columns nothing accepts.

Three states matter when closing the depth gap, and they need different work:

  reachable    the API accepts the field AND some frontend file names it   -> nothing to do
  api-only     the API accepts it, no frontend file names it               -> WIRING work only
  absent       neither side has it                                         -> FULL-STACK work

The api-only set is the cheapest depth available: the persistence, validation and posting
already exist and are already tested; only the screen is missing. This script computes it
without needing a page->module mapping, by asking whether ANY frontend file mentions the
field name at all. A field no frontend file names cannot possibly be sent.

Run:  python3 gap_manifest.py > GAP-MANIFEST.json
"""
from __future__ import annotations

import json
import os
import re
import sys
from collections import defaultdict

HERE = os.path.dirname(os.path.abspath(__file__))
REPO = os.path.normpath(os.path.join(HERE, "..", ".."))
API = os.path.join(REPO, "web", "apps", "api", "src")
WEBAPP = os.path.join(REPO, "web", "apps", "web")

# `export interface PurchaseLineInput {` ... `}` — input contracts only. Output/row types are
# excluded because the operator never supplies them.
IFACE = re.compile(r"export\s+interface\s+([A-Za-z]\w*)\s*\{(.*?)\n\}", re.S)
FIELD = re.compile(r"^\s{2}(?:readonly\s+)?([a-z]\w*)\??\s*:", re.M)
# Desktop provenance the codebase already records in comments, e.g. `mSG_PR[i,4]  :13103`
PROVENANCE = re.compile(r"(mSG\w*)\[i,\s*(\d+)\]|:(\d{3,6})\b")

INPUT_NAME = re.compile(r"(Input|Line)$")
# Names that are responses/rows rather than operator input.
NOT_INPUT = re.compile(r"(Result|Row|Response|Report|Summary|View|Doc|Record|Totals|Balance)$")


def load_frontend_corpus() -> str:
    """Every frontend source file concatenated. A field name absent here is unsendable."""
    parts = []
    for base in (os.path.join(WEBAPP, "app"), os.path.join(WEBAPP, "components"), os.path.join(WEBAPP, "lib")):
        if not os.path.isdir(base):
            continue
        for root, _dirs, names in os.walk(base):
            for n in names:
                if n.endswith((".tsx", ".ts")):
                    with open(os.path.join(root, n), "r", encoding="utf-8", errors="replace") as fh:
                        parts.append(fh.read())
    return "\n".join(parts)


def api_interfaces() -> dict[str, dict]:
    out: dict[str, dict] = {}
    for root, _dirs, names in os.walk(API):
        for n in names:
            if not n.endswith(".ts"):
                continue
            p = os.path.join(root, n)
            rel = os.path.relpath(p, REPO).replace(os.sep, "/")
            if "/routes/" in rel or "/test" in rel:
                continue
            with open(p, "r", encoding="utf-8", errors="replace") as fh:
                text = fh.read()
            for m in IFACE.finditer(text):
                name, body = m.group(1), m.group(2)
                if not INPUT_NAME.search(name) or NOT_INPUT.search(name):
                    continue
                fields = FIELD.findall(body)
                if not fields:
                    continue
                prov = {}
                for line in body.splitlines():
                    fm = re.match(r"\s{2}(?:readonly\s+)?([a-z]\w*)\??\s*:", line)
                    if not fm:
                        continue
                    pm = PROVENANCE.search(line)
                    if pm:
                        prov[fm.group(1)] = line.split("//")[-1].strip() if "//" in line else pm.group(0)
                out[name] = {
                    "file": rel,
                    "module": rel.split("/modules/")[-1].split("/")[0] if "/modules/" in rel else "other",
                    "fields": fields,
                    "desktopProvenance": prov,
                }
    return out


def main() -> int:
    corpus = load_frontend_corpus()
    ifaces = api_interfaces()

    mentioned: dict[str, bool] = {}

    def is_mentioned(field: str) -> bool:
        if field in mentioned:
            return mentioned[field]
        # whole-identifier match so `rate` does not match `rateType`
        hit = re.search(r"(?<![A-Za-z0-9_])" + re.escape(field) + r"(?![A-Za-z0-9_])", corpus) is not None
        mentioned[field] = hit
        return hit

    rows = []
    by_module: dict[str, dict] = defaultdict(lambda: {"interfaces": 0, "fields": 0, "apiOnly": 0, "reachable": 0})
    for name, meta in sorted(ifaces.items()):
        api_only = [f for f in meta["fields"] if not is_mentioned(f)]
        reachable = [f for f in meta["fields"] if is_mentioned(f)]
        rows.append(
            {
                "interface": name,
                "file": meta["file"],
                "module": meta["module"],
                "fieldCount": len(meta["fields"]),
                "reachableCount": len(reachable),
                "apiOnlyCount": len(api_only),
                "apiOnlyFields": api_only,
                "desktopProvenance": {k: v for k, v in meta["desktopProvenance"].items() if k in api_only},
            }
        )
        b = by_module[meta["module"]]
        b["interfaces"] += 1
        b["fields"] += len(meta["fields"])
        b["apiOnly"] += len(api_only)
        b["reachable"] += len(reachable)

    for b in by_module.values():
        b["reachablePct"] = round(100.0 * b["reachable"] / b["fields"], 1) if b["fields"] else None

    total_fields = sum(r["fieldCount"] for r in rows)
    total_api_only = sum(r["apiOnlyCount"] for r in rows)
    json.dump(
        {
            "kind": "gap-manifest",
            "note": (
                "apiOnlyFields are accepted by a server input contract but named by no frontend "
                "file, so no screen can supply them. Closing these is wiring, not new engine work. "
                "A field may be legitimately server-derived; each entry must be triaged, not "
                "assumed to be a defect."
            ),
            "totals": {
                "inputInterfaces": len(rows),
                "inputFields": total_fields,
                "reachableFromUi": total_fields - total_api_only,
                "apiOnlyUnreachable": total_api_only,
                "reachablePct": round(100.0 * (total_fields - total_api_only) / total_fields, 1)
                if total_fields
                else None,
            },
            "byModule": dict(sorted(by_module.items(), key=lambda kv: -kv[1]["apiOnly"])),
            "worstInterfaces": sorted(rows, key=lambda r: -r["apiOnlyCount"])[:60],
            "interfaces": rows,
        },
        sys.stdout,
        indent=1,
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
