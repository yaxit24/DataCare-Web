#!/usr/bin/env python3
"""Measure per-page UI richness of the DataCareNext web implementation.

Counts the same dimensions as richness_desktop.py so the two are directly comparable:
visible grid columns, bound input controls, keyboard affordances and validation messages.

Frontend: web/apps/web/app/**/page.tsx (plus shared components they compose).
Backend:  web/apps/api/src/modules/**.ts for enforced validation messages.

Run:  python3 richness_web.py > WEB-RICHNESS.json
"""
from __future__ import annotations

import json
import os
import re
import sys
from collections import defaultdict

REPO = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", ".."))
WEB = os.path.join(REPO, "web", "apps", "web")
API = os.path.join(REPO, "web", "apps", "api", "src")

# A bound input is any control an operator types into or selects from. LookupPicker and
# BookSelect are the project's own master-picker components and count as one field each.
INPUT_TAG = re.compile(r"<(input|select|textarea|LookupPicker|BookSelect|CameraCapture|ScaleCapture)\b")
# Visible grid/table columns.
TH = re.compile(r"<th\b")
# Header cells that carry no label are spacers (action columns), not data columns.
TH_EMPTY = re.compile(r"<th[^>]*>\s*</th>")
# Declaratively-specified columns: `field: { label: 'NetWt', numeric: true }`.
#
# Counting only literal `<th>` understated any grid that renders its header row from a column
# registry — SubDetailGrid declares 35 columns and emits them in a `.map`, so a literal count saw 2.
# A declared column with a label is a rendered column; excluding it would make the shared-component
# approach look like it removed depth.
COLUMN_SPEC = re.compile(r"\{\s*label:\s*'[^']+'")
# The project's other column-declaration idiom: an extended-field tuple list consumed by
# `ExtendedHeaderCells` / `ExtendedBodyCells`, which emit a real `<th>` and `<input>` per entry.
#
#     const extendedLineFields: Array<[keyof Line, string]> = [['bagWt', 'Bag Wt'], ...]
#
# Used by purchase, sales and the manufacturing pages. Matched separately from COLUMN_SPEC because
# the shape is a tuple rather than an object, and missing it made 27 wired fields register as zero
# added depth.
EXTENDED_FIELD_TUPLE = re.compile(r"\[\s*'[A-Za-z_]\w*'\s*,\s*'[^']+'\s*\]")
FKEY = re.compile(r"['\"](F\d{1,2})['\"]")
KEYDOWN = re.compile(r"onKeyDown")
# Client-side messages shown to the operator.
CLIENT_MSG = re.compile(r"(?:setError|setMessage|setStatus|toast(?:\.\w+)?)\s*\(\s*['\"]([^'\"]{3,200})['\"]")


def route_of(path: str) -> str:
    """Turn a page.tsx path into its URL route."""
    rel = os.path.relpath(os.path.dirname(path), os.path.join(WEB, "app"))
    parts = [p for p in rel.split(os.sep) if p and not (p.startswith("(") and p.endswith(")"))]
    return "/" + "/".join(parts)


IMPORT = re.compile(r"^\s*import\s+(?:[\w{},*\s]+?)\s+from\s+['\"](\.[^'\"]+)['\"]", re.M)


def resolve_import(spec: str, from_file: str) -> str | None:
    """Resolve a relative import to a .tsx/.ts file on disk."""
    base = os.path.normpath(os.path.join(os.path.dirname(from_file), spec))
    for cand in (base, base + ".tsx", base + ".ts", os.path.join(base, "index.tsx")):
        if os.path.isfile(cand):
            return cand
    return None


def composed_files(entry: str, seen: set[str] | None = None, depth: int = 0) -> list[str]:
    """Every local file a page renders through, transitively.

    Six txn pages are 5-line wrappers around a shared component (KarigarForm, PaymentForm).
    Measuring only page.tsx would score them at zero fields, which is wrong: the fields exist,
    they just live one import away. Depth is capped so a cycle cannot loop.
    """
    if seen is None:
        seen = set()
    if entry in seen or depth > 3:
        return []
    seen.add(entry)
    out = [entry]
    try:
        with open(entry, "r", encoding="utf-8", errors="replace") as fh:
            text = fh.read()
    except OSError:
        return out
    for m in IMPORT.finditer(text):
        target = resolve_import(m.group(1), entry)
        # only follow component-like modules, not hooks/utils that hold no fields
        if target and target.endswith(".tsx"):
            out.extend(composed_files(target, seen, depth + 1))
    return out


def measure_page(path: str) -> dict:
    files = composed_files(path)
    text = ""
    for f in files:
        with open(f, "r", encoding="utf-8", errors="replace") as fh:
            text += fh.read() + "\n"
    with open(path, "r", encoding="utf-8", errors="replace") as fh:
        own = fh.read()
    th_total = len(TH.findall(text))
    th_empty = len(TH_EMPTY.findall(text))
    return {
        "route": route_of(path),
        "file": os.path.relpath(path, REPO),
        "composedFrom": [os.path.relpath(f, REPO) for f in files[1:]],
        "loc": len(own.splitlines()),
        "composedLoc": len(text.splitlines()),
        "inputControls": len(INPUT_TAG.findall(text)),
        "gridColumns": th_total - th_empty + len(COLUMN_SPEC.findall(text)) + len(EXTENDED_FIELD_TUPLE.findall(text)),
        "gridColumnsRaw": th_total,
        "declaredColumnSpecs": len(COLUMN_SPEC.findall(text)) + len(EXTENDED_FIELD_TUPLE.findall(text)),
        "functionKeys": sorted(set(FKEY.findall(text)), key=lambda s: int(s[1:])),
        "keyDownHandlers": len(KEYDOWN.findall(text)),
        "clientMessages": len(set(CLIENT_MSG.findall(text))),
        # Adoption must mean a CALL, not a mention. `"GridKeyboard" in text` counted any page that
        # composed ExtendedGrid, whose doc comment names the hook — so pages with no keyboard
        # handling at all were scored as having it. Matching the invocation removes that.
        "usesGridKeyboard": bool(re.search(r"useGridKeyboard\s*\(", text)),
        "usesFormKeys": "FormKeys" in text,
        "usesLookupPicker": bool(re.search(r"<LookupPicker\b", text)),
        "usesLineRecalc": bool(re.search(r"useLineRecalc\s*\(|lineRecalc\s*\(", text)),
        "usesSubDetailGrid": bool(re.search(r"<SubDetailGrid\b", text)),
        "usesVoucherTotals": bool(re.search(r"<VoucherTotals\b", text)),
        # Does this page present an EDITABLE line grid — one the operator authors rows into?
        #
        # This distinction was learned the hard way, twice. "Has a <tbody> with a .map" also matches
        # read-only tables: fetched reconciliation rows, a rate matrix, a scanned-tag list, a
        # reminder list. The grid keyboard contract is about AUTHORING rows (arrow movement,
        # Enter-to-append, Ctrl+D-to-remove), so it only applies where the page holds an array in
        # state AND has a factory for a fresh blank row. Measuring the cruder property produced a
        # target that could only be satisfied by adding dead handlers to report screens.
        "hasLineGrid": bool(
            re.search(r"<tbody", text) and re.search(r"\.map\(\(", text) and re.search(r"<tr\b", text)
        ),
        "hasEditableLineGrid": bool(
            re.search(r"<tbody", text)
            and re.search(r"\.map\(\(", text)
            and re.search(r"useState<[^>]*\[\]>", text)
            and re.search(r"\b(blank|blankLine|blankOut|blankResult|blankChild|mblank|emptyLine|newLine)\w*\s*(=|\()", text)
        ),
    }


# API-side enforced validation. The project has no zod; every refusal is a thrown
# domain error carrying an operator-facing message, in either quote form or a template
# literal. These are the web equivalent of a desktop MsgBox that blocks the save.
API_MSG = re.compile(r"throw\s+new\s+\w*(?:Error|Exception)\s*\(\s*(['\"`])((?:(?!\1).){3,220})\1", re.S)
# Named guard helpers are reusable enforced rules invoked from many call sites.
API_GUARD = re.compile(r"\b(assert[A-Z]\w*|require[A-Z]\w*)\s*\(")
SQL_STMT = re.compile(r"\b(SELECT|INSERT\s+INTO|UPDATE|DELETE\s+FROM)\b", re.I)


def measure_api() -> dict:
    msgs: set[str] = set()
    guards: set[str] = set()
    sql = 0
    files = 0
    per_module: dict[str, dict] = defaultdict(lambda: {"messages": 0, "guards": 0, "files": 0, "sql": 0})
    for root, _dirs, names in os.walk(API):
        for n in names:
            if not n.endswith(".ts"):
                continue
            p = os.path.join(root, n)
            with open(p, "r", encoding="utf-8", errors="replace") as fh:
                t = fh.read()
            files += 1
            found = {m.group(2).strip() for m in API_MSG.finditer(t)}
            msgs |= found
            g = set(API_GUARD.findall(t))
            guards |= g
            s = len(SQL_STMT.findall(t))
            sql += s
            rel = os.path.relpath(p, API)
            mod = rel.split(os.sep)[1] if rel.startswith("modules" + os.sep) else rel.split(os.sep)[0]
            per_module[mod]["messages"] += len(found)
            per_module[mod]["guards"] += len(g)
            per_module[mod]["files"] += 1
            per_module[mod]["sql"] += s
    return {
        "files": files,
        "distinctValidationMessages": len(msgs),
        "distinctGuardHelpers": len(guards),
        "sqlStatements": sql,
        "byModule": dict(sorted(per_module.items())),
    }


def main() -> int:
    pages = []
    for root, _dirs, names in os.walk(os.path.join(WEB, "app")):
        for n in names:
            if n == "page.tsx":
                pages.append(measure_page(os.path.join(root, n)))
    pages.sort(key=lambda p: p["route"])

    # shared components contribute fields to the pages that compose them
    comps = []
    cdir = os.path.join(WEB, "components")
    if os.path.isdir(cdir):
        for n in sorted(os.listdir(cdir)):
            if n.endswith(".tsx"):
                p = os.path.join(cdir, n)
                with open(p, "r", encoding="utf-8", errors="replace") as fh:
                    t = fh.read()
                comps.append(
                    {
                        "component": n,
                        "loc": len(t.splitlines()),
                        "inputControls": len(INPUT_TAG.findall(t)),
                        "gridColumns": len(TH.findall(t))
                        - len(TH_EMPTY.findall(t))
                        + len(COLUMN_SPEC.findall(t))
                        + len(EXTENDED_FIELD_TUPLE.findall(t)),
                        "functionKeys": sorted(set(FKEY.findall(t)), key=lambda s: int(s[1:])),
                    }
                )

    # Global totals must count each file once. Per-page numbers deliberately include composed
    # components (the operator sees those fields on that page), so summing pages would count a
    # shared component such as LookupPicker once per consuming page. The union below is the
    # honest denominator-free total for whole-app comparisons.
    union: set[str] = set()
    for root, _dirs, names in os.walk(os.path.join(WEB, "app")):
        for n in names:
            if n.endswith(".tsx"):
                union.add(os.path.join(root, n))
    if os.path.isdir(cdir):
        for n in os.listdir(cdir):
            if n.endswith(".tsx"):
                union.add(os.path.join(cdir, n))
    u_inputs = u_cols = u_loc = 0
    for f in sorted(union):
        with open(f, "r", encoding="utf-8", errors="replace") as fh:
            t = fh.read()
        u_loc += len(t.splitlines())
        u_inputs += len(INPUT_TAG.findall(t))
        u_cols += (
            len(TH.findall(t))
            - len(TH_EMPTY.findall(t))
            + len(COLUMN_SPEC.findall(t))
            + len(EXTENDED_FIELD_TUPLE.findall(t))
        )

    totals = {
        "pages": len(pages),
        "loc": sum(p["loc"] for p in pages),
        "distinctFiles": len(union),
        "unionLoc": u_loc,
        "unionInputControls": u_inputs,
        "unionGridColumns": u_cols,
        "unionSurface": u_inputs + u_cols,
        "pageSumInputControls": sum(p["inputControls"] for p in pages),
        "pageSumGridColumns": sum(p["gridColumns"] for p in pages),
        "clientMessages": sum(p["clientMessages"] for p in pages),
        "pagesWithGridKeyboard": sum(1 for p in pages if p["usesGridKeyboard"]),
        "pagesWithFormKeys": sum(1 for p in pages if p["usesFormKeys"]),
        "pagesWithLookupPicker": sum(1 for p in pages if p["usesLookupPicker"]),
        "pagesWithLineRecalc": sum(1 for p in pages if p["usesLineRecalc"]),
        "pagesWithSubDetailGrid": sum(1 for p in pages if p["usesSubDetailGrid"]),
        "pagesWithVoucherTotals": sum(1 for p in pages if p["usesVoucherTotals"]),
        "txnPages": sum(1 for p in pages if p["route"].startswith("/txn/")),
        "txnPagesWithLineGrid": sum(
            1 for p in pages if p["route"].startswith("/txn/") and p["hasLineGrid"]
        ),
        "txnPagesWithEditableGrid": sum(
            1 for p in pages if p["route"].startswith("/txn/") and p["hasEditableLineGrid"]
        ),
        "txnEditableGridPagesWithKeyboard": sum(
            1
            for p in pages
            if p["route"].startswith("/txn/") and p["hasEditableLineGrid"] and p["usesGridKeyboard"]
        ),
        "txnPagesWithGridKeyboard": sum(
            1 for p in pages if p["route"].startswith("/txn/") and p["usesGridKeyboard"]
        ),
        "txnGridPagesWithKeyboard": sum(
            1
            for p in pages
            if p["route"].startswith("/txn/") and p["hasLineGrid"] and p["usesGridKeyboard"]
        ),
        "zeroFieldPages": [p["route"] for p in pages if p["inputControls"] == 0 and p["gridColumns"] == 0],
    }
    json.dump(
        {
            "kind": "web-ui-richness",
            "webRoot": os.path.relpath(WEB, REPO),
            "totals": totals,
            "api": measure_api(),
            "pages": pages,
            "components": comps,
        },
        sys.stdout,
        indent=1,
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
