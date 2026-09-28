#!/usr/bin/env python3
"""Wire the remaining P3 operator fields the API accepts but no screen could send.

One entry per page. `line` fields join the page's row type, blank factory and per-line payload;
`header` fields become page-level state and header payload keys. Every entry carries the desktop
reason, because a field added without one is a guess.

A page whose anchors do not match is reported and left untouched rather than half-wired.
"""
from __future__ import annotations

import os
import re
import sys

WEB = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", "apps", "web"))

# kind: 'num' | 'text'
PAGES: dict[str, dict] = {
    "tour": {
        "rowType": "Line",
        "blank": "blank",
        "setter": "setLine",
        "why": (
            "TR_APR_ISU carries the approval line's adjusted weights and the SOURCE voucher the "
            "consignment came from (issue account, its location and name) plus the metal colour; the "
            "screen posted six numeric fields and nothing else."
        ),
        "line": [
            ("adjustGrossWt", "AdjGwt", "num"),
            ("adjustNetWt", "AdjNwt", "num"),
            ("metalColor", "Color", "text"),
            ("isuAcCode", "IsuAc", "text"),
            ("isuAcName", "IsuAcName", "text"),
            ("isuLcCode", "IsuLc", "text"),
        ],
    },
    "batch-receipt": {
        "rowType": "Line",
        "blank": "blank",
        "setter": "setLine",
        "why": (
            "Cheque clearing needs the bank's charge, the name to print on the instrument, the "
            "clearing date and the item-description code; without them a batch receipt cannot record "
            "what the bank actually did."
        ),
        "line": [
            ("bankCharges", "BankChg", "num"),
            ("chqPrintName", "ChqName", "text"),
            ("clearDate", "ClearDate", "text"),
            ("itemDescriptionCode", "ItDescCode", "text"),
        ],
    },
    "item-opening": {
        "rowType": "Row",
        "blank": "blank",
        "setter": "setRow",
        "why": (
            "An opening stock row for a stone-set ornament carries the diamond weight, its rate and "
            "the resulting amount separately from the metal, so opening valuation is wrong without "
            "them."
        ),
        "line": [
            ("diamondWt", "DmWt", "num"),
            ("diamondRate", "DmRate", "num"),
            ("diamondAmount", "DmAmt", "num"),
        ],
    },
    "tag-cancel": {
        "rowType": "Line",
        "blank": "blank",
        "setter": "setLine",
        "why": "Cancelling a tag can transfer its metal to a different item code (the loose-stock item it returns to).",
        "line": [("transferItCode", "TrfItCode", "text")],
    },
}

HEADER_PAGES: dict[str, dict] = {
    "melting": {
        "why": "A melt loses metal; the desktop records the loss percentage on the voucher header.",
        "fields": [("lossPct", "Loss %", "num")],
    },
    "bullion": {
        "why": "AMT_TYPE selects whether the booking settles against cash or bank (TR_BUL_BOOKING grid column AmtType).",
        "fields": [("amtType", "Amount Type", "text")],
    },
    "tag-opening": {
        "why": "The loose-stock item code the opened tag draws its metal from.",
        "fields": [("stockItCode", "Stock Item Code", "text")],
    },
    "tag-weight-diff": {
        "why": "absorbSign selects whether the weight difference is absorbed as a gain or a loss.",
        "fields": [("absorbSign", "Absorb Sign (+/-)", "text")],
    },
    "wholesale-sale-return": {
        "why": "A non-cash settlement must name the bank account it lands in; the API accepted it and the page never sent it.",
        "fields": [("bankAccount", "Bank A/c", "text")],
    },
}


def wire_lines(slug: str, cfg: dict) -> str:
    path = os.path.join(WEB, "app", "(app)", "txn", slug, "page.tsx")
    if not os.path.isfile(path):
        return "missing"
    src = open(path, encoding="utf-8").read()
    fields = cfg["line"]
    if fields[0][0] in src:
        return "already"

    row, blank, setter = cfg["rowType"], cfg["blank"], cfg["setter"]

    # row type
    m = re.search(rf"(interface {row} \{{\n)", src) or re.search(rf"(type {row} = \{{\n)", src)
    if not m:
        return "no-row-type"
    src = src[: m.end()] + "".join(f"  {f}: string;\n" for f, _, _ in fields) + src[m.end() :]

    # blank factory, both single-line and multi-line forms
    single = re.search(rf"const {blank} = \(\): {row} => \(\{{([^\n]*)\}}\);", src)
    if single:
        src = src.replace(
            single.group(0),
            f"const {blank} = (): {row} => ({{{single.group(1)}"
            + "".join(f" {f}: '', " for f, _, _ in fields)
            + "});",
            1,
        )
    else:
        multi = re.search(rf"(const {blank} = \(\): {row} => \(\{{\n)", src)
        if not multi:
            return "no-blank"
        src = src[: multi.end()] + "".join(f"  {f}: '',\n" for f, _, _ in fields) + src[multi.end() :]

    # extended grid columns
    last = list(re.finditer(r"^import .*?;\n", src, re.M))[-1]
    if "ExtendedHeaderCells" not in src:
        src = (
            src[: last.end()]
            + "import {\n  ExtendedBodyCells,\n  ExtendedHeaderCells,\n  GridModeToggle,\n} from '../../../../components/ExtendedGrid';\n"
            + src[last.end() :]
        )
    decl = (
        f"/**\n * P3: {row} fields the server accepted that no screen could send.\n *\n * {cfg['why']}\n */\n"
        f"const extendedP3Fields: Array<[keyof {row}, string]> = [\n"
        + "".join(f"  ['{f}', '{label}'],\n" for f, label, _ in fields)
        + "];\n\n"
    )
    src = re.sub(r"(\nexport default function )", "\n" + decl + r"\1", src, count=1)

    state = re.search(r"const \[\w+, set\w+\] = useState<\w+\[\]>\([^\n]*\n", src)
    if not state:
        return "no-rows-state"
    src = src[: state.end()] + "  const [fullGrid, setFullGrid] = useState(false);\n" + src[state.end() :]

    src = src.replace(
        "                <th></th>\n",
        "                <ExtendedHeaderCells full={fullGrid} fields={extendedP3Fields} />\n                <th></th>\n",
        1,
    )
    src = re.sub(
        r"(\n(\s+)<td>\s*\n\s+<button\s*\n\s+type=\"button\"\s*\n\s+className=\"ghost\")",
        lambda mm: (
            "\n" + mm.group(2) + "<ExtendedBodyCells\n"
            + mm.group(2) + "  full={fullGrid}\n"
            + mm.group(2) + "  fields={extendedP3Fields}\n"
            + mm.group(2) + "  line={l}\n"
            + mm.group(2) + "  row={i}\n"
            + mm.group(2) + "  baseColumns={0}\n"
            + mm.group(2) + f"  setValue={{(r, k, v) => {setter}(r, k, v)}}\n"
            + mm.group(2) + "/>" + mm.group(1)
        ),
        src,
        count=1,
    )
    src = src.replace(
        '<table className="grid"',
        '<GridModeToggle\n'
        '            full={fullGrid}\n'
        '            setFull={setFullGrid}\n'
        '            extendedCount={extendedP3Fields.length}\n'
        f'            testId="{slug}-p3-mode"\n'
        '          />\n'
        '          <table className="grid"',
        1,
    )

    # payload: append to the per-line object literal opened by `.map(`
    payload = "".join(
        f"            {f}: {'n(l.' + f + ')' if k == 'num' else 'l.' + f + ' || undefined'},\n"
        for f, _, k in fields
    )
    hit = re.search(r"\.map\(\(\{ l, sourceIndex \}\) => \(\{\n", src) or re.search(
        r"\.map\(\(l\) => \(\{\n", src
    )
    if not hit:
        return "no-payload"
    src = src[: hit.end()] + payload + src[hit.end() :]

    open(path, "w", encoding="utf-8").write(src)
    return "wired"


def wire_header(slug: str, cfg: dict) -> str:
    path = os.path.join(WEB, "app", "(app)", "txn", slug, "page.tsx")
    if not os.path.isfile(path):
        return "missing"
    src = open(path, encoding="utf-8").read()
    fields = cfg["fields"]
    if fields[0][0] in src:
        return "already"

    anchor = re.search(r"(  const \[busy, setBusy\] = useState\(false\);\n)", src) or re.search(
        r"(  const \[err, setErr\] = useState\(''\);\n)", src
    )
    if not anchor:
        return "no-state-anchor"
    decl = f"  // P3: {cfg['why']}\n" + "".join(
        f"  const [{f}, set{f[0].upper() + f[1:]}] = useState('');\n" for f, _, _ in fields
    )
    src = src[: anchor.end()] + decl + src[anchor.end() :]

    body = re.search(r"(      const body(?::\s*\w+)? = \{\n)", src) or re.search(
        r"(    const body(?::\s*\w+)? = \{\n)", src
    )
    if not body:
        return "no-body"
    payload = "".join(
        f"        {f}: {f}.trim() ? Number({f}) : undefined,\n"
        if k == "num"
        else f"        {f}: {f}.trim() || undefined,\n"
        for f, _, k in fields
    )
    src = src[: body.end()] + payload + src[body.end() :]

    controls = (
        '        <div className="row">\n'
        + "".join(
            '          <div className="field">\n'
            f"            <label>{label}</label>\n"
            f"            <input value={{{f}}} onChange={{(e) => set{f[0].upper() + f[1:]}(e.target.value)}} />\n"
            "          </div>\n"
            for f, label, _ in fields
        )
        + "        </div>\n"
    )
    panel = re.search(r"(\n\s+<div className=\"panel\">\n)", src)
    if not panel:
        return "no-panel"
    src = src[: panel.end()] + controls + src[panel.end() :]

    open(path, "w", encoding="utf-8").write(src)
    return "wired"


def main() -> int:
    for slug, cfg in PAGES.items():
        print(f"  line  {slug}: {wire_lines(slug, cfg)}")
    for slug, cfg in HEADER_PAGES.items():
        print(f"  hdr   {slug}: {wire_header(slug, cfg)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
