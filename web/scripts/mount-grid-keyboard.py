#!/usr/bin/env python3
"""Mount the shared grid-keyboard contract on transaction pages that have a line grid.

Only touches a page when all three anchors can be identified unambiguously:
  1. the rows state pair            `const [<rows>, set<Rows>] = useState<...>([...])`
  2. a blank-row factory            `blank(` / `blankLine(` / `emptyLine(`
  3. exactly one grid table         `<table className="grid">`

Anything else is left alone and reported, because a half-wired grid is worse than an unwired one:
the operator would get arrow navigation that silently stops working on some columns.

Idempotent: a page that already imports useGridKeyboard is skipped.
"""
from __future__ import annotations

import os
import re
import sys

WEB = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", "apps", "web"))
TXN = os.path.join(WEB, "app", "(app)", "txn")

ROWS_STATE = re.compile(r"const \[(\w+), (set\w+)\] = useState<[^>]*\[\]>\(")
BLANK_FN = re.compile(r"\b(blank|blankLine|emptyLine|newLine)\s*\(")
GRID_TABLE = re.compile(r'<table className="grid">')
HAS_HOOK = re.compile(r"useGridKeyboard")


def relative_components(page: str) -> str:
    depth = os.path.relpath(page, WEB).count(os.sep)
    return "../" * depth + "components/GridKeyboard"


def mount(page: str) -> tuple[str, str]:
    with open(page, "r", encoding="utf-8") as fh:
        src = fh.read()
    name = os.path.basename(os.path.dirname(page))

    if HAS_HOOK.search(src):
        return "already", name
    tables = GRID_TABLE.findall(src)
    if len(tables) != 1:
        return f"skip:{len(tables)}-grid-tables", name
    rows = ROWS_STATE.search(src)
    if not rows:
        return "skip:no-rows-state", name
    blank = BLANK_FN.search(src)
    if not blank:
        return "skip:no-blank-factory", name

    rows_var, setter = rows.group(1), rows.group(2)
    blank_fn = blank.group(1)

    # 1. import
    import_line = f"import {{ useGridKeyboard }} from '{relative_components(page)}';\n"
    last_import = max(
        (m.end() for m in re.finditer(r"^import .*?;\n", src, re.M)),
        default=None,
    )
    if last_import is None:
        return "skip:no-imports", name
    src = src[:last_import] + import_line + src[last_import:]

    # 2. hook, inserted immediately after the rows state declaration line
    rows = ROWS_STATE.search(src)
    assert rows is not None
    line_end = src.index("\n", rows.end()) + 1
    hook = (
        f"  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and\n"
        f"  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).\n"
        f"  const handleGridKey = useGridKeyboard({{\n"
        f"    rowCount: {rows_var}.length,\n"
        f"    onAppendRow: () => {setter}((rows) => [...rows, {blank_fn}()]),\n"
        f"    onRemoveRow: (row) => {{\n"
        f"      {setter}((rows) =>\n"
        f"        rows.length === 1 ? [{blank_fn}()] : rows.filter((_, index) => index !== row),\n"
        f"      );\n"
        f"      return true;\n"
        f"    }},\n"
        f"    onEscape: () => {{}},\n"
        f"  }});\n"
    )
    src = src[:line_end] + hook + src[line_end:]

    # 3. attach to the grid table
    src = src.replace('<table className="grid">', '<table className="grid" onKeyDown={handleGridKey}>', 1)

    with open(page, "w", encoding="utf-8") as fh:
        fh.write(src)
    return "mounted", name


def main() -> int:
    results: dict[str, list[str]] = {}
    for slug in sorted(os.listdir(TXN)):
        page = os.path.join(TXN, slug, "page.tsx")
        if not os.path.isfile(page):
            continue
        status, name = mount(page)
        results.setdefault(status.split(":")[0] if status.startswith("skip") else status, []).append(
            f"{name}({status.split(':', 1)[1]})" if status.startswith("skip:") else name
        )
    for status in sorted(results):
        items = results[status]
        print(f"{status} ({len(items)}): {', '.join(items)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
