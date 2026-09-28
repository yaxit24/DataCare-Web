#!/usr/bin/env python3
"""Adopt the shared SubDetailGrid on the transaction pages whose API already persists `*_IDTL` rows.

Each entry names, per page, the exact anchors this page uses — its rows state, its blank-row
factory, the submit filter/map it feeds, and which server array it fills. Nothing is inferred:
a page whose anchor does not match is reported and left untouched, because a half-wired sub-detail
grid would silently attach stones to the wrong ornament.

`stones` vs `components`:
  stones      modules extending StoneSubDetailInput (purchase, karigar, tour, tagOps) - lbrAmount/netAmount
  components  MfgComponent (mfg, vpParcel, wholesaleSaleReturn)     - lbrAmt/netAmt, plus return/breakage
"""
from __future__ import annotations

import os
import re
import sys

WEB = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", "apps", "web"))

# slug -> rows, setter, blank, array, columns, desktopSource, filter-line, map-line
PAGES = {
    "purchase-hm": dict(
        rows="rows", setter="setRows", blank="blank", array="stones", columns=None,
        source="TR_PURC_HM / MSG_PR_IDTL (23 cols)",
    ),
    "mfg-issue": dict(
        rows="lines", setter="setLines", blank="blank", array="components", columns="SUB_DETAIL_COMPONENT",
        source="TR_MFG_ISU_REC / MSG_IDTL (22 cols)",
    ),
    "mfg-receive": dict(
        rows="lines", setter="setLines", blank="blank", array="components", columns="SUB_DETAIL_COMPONENT",
        source="TR_MFG_ORD_REC / MSG_IDTL (28 cols)",
    ),
    "tour": dict(
        rows="lines", setter="setLines", blank="blank", array="stones", columns=None,
        source="TR_APR_ISU / MSG_IDTL (21 cols)",
    ),
    "tag-cancel": dict(
        rows="lines", setter="setLines", blank="blank", array="stones", columns=None,
        source="TR_TAG_CAN sub-detail (17 cols)",
    ),
}


def adopt(slug: str, cfg: dict) -> str:
    path = os.path.join(WEB, "app", "(app)", "txn", slug, "page.tsx")
    if not os.path.isfile(path):
        return "missing-file"
    src = open(path, encoding="utf-8").read()
    if "SubDetailGrid" in src:
        return "already"

    rows, setter, blank = cfg["rows"], cfg["setter"], cfg["blank"]
    array, columns, source = cfg["array"], cfg["columns"], cfg["source"]
    getter = "componentsFor" if array == "components" else "inputsFor"

    # import
    imports = f"SubDetailGrid, {{{' ' + columns + ',' if columns else ''} useSubDetail }}"
    last = list(re.finditer(r"^import .*?;\n", src, re.M))
    if not last:
        return "no-imports"
    src = (
        src[: last[-1].end()]
        + f"import {imports} from '../../../../components/SubDetailGrid';\n"
        + src[last[-1].end() :]
    )

    # hook after the rows state
    state = re.search(rf"const \[{rows}, {setter}\] = useState<[^>]*\[\]>\([^\n]*\n", src)
    if not state:
        return "no-rows-state"
    hook = (
        f"  // Desktop {source.split(' /')[0]} hangs a sub-detail row set under each item line; the server\n"
        f"  // already persists it and this page sent nothing.\n"
        f"  const sub = useSubDetail({rows}.length);\n"
    )
    src = src[: state.end()] + hook + src[state.end() :]

    # cascade through the grid keyboard, which every page now has (P1-5)
    src = src.replace(
        f"    onAppendRow: () => {setter}((current) => [...current, {blank}()]),",
        f"    onAppendRow: () => {{\n      {setter}((current) => [...current, {blank}()]);\n      sub.appendLine();\n    }},",
        1,
    )
    src = src.replace(
        f"    onAppendRow: () => {setter}((rows) => [...rows, {blank}()]),",
        f"    onAppendRow: () => {{\n      {setter}((rows) => [...rows, {blank}()]);\n      sub.appendLine();\n    }},",
        1,
    )
    src = re.sub(
        r"(\n      \);\n)(      return true;\n    \},\n    onEscape)",
        r"\1      sub.removeLine(row);\n\2",
        src,
        count=1,
    )

    # payload: carry the source index through the filter
    payload = re.search(
        rf"(\s+)lines: {rows}\n(\s+)\.filter\(\(l\) => ([^\n]+)\)\n(\s+)\.map\(\(l\) => \(\{{\n",
        src,
    )
    if not payload:
        return "no-payload-shape"
    indent, pred = payload.group(1), payload.group(3)
    replacement = (
        f"{indent}lines: {rows}\n"
        f"{indent}  // Original index carried through the filter: empty lines are dropped, so a\n"
        f"{indent}  // filtered position would attach a sub-detail block to a different item.\n"
        f"{indent}  .map((l, sourceIndex) => ({{ l, sourceIndex }}))\n"
        f"{indent}  .filter(({{ l }}) => {pred})\n"
        f"{indent}  .map(({{ l, sourceIndex }}) => ({{\n"
        f"{indent}    {array}: sub.{getter}(sourceIndex),\n"
    )
    src = src[: payload.start()] + replacement + src[payload.end() :]

    # render after the last grid table
    close = src.rfind("</table>")
    if close < 0:
        return "no-table"
    label = "Components" if array == "components" else "Stones"
    render = (
        "</table>\n"
        "          <div className=\"row\" style={{ marginTop: 8, alignItems: 'flex-end' }}>\n"
        "            <div className=\"field\">\n"
        f"              <label>{label} for line</label>\n"
        "              <select\n"
        "                value={sub.activeLine}\n"
        "                onChange={(e) => sub.setActiveLine(Number(e.target.value))}\n"
        "              >\n"
        f"                {{{rows}.map((l, i) => (\n"
        "                  <option key={i} value={i}>\n"
        "                    {i + 1}\n"
        "                    {l.itCode ? ` — ${l.itCode}` : ''}\n"
        "                  </option>\n"
        "                ))}\n"
        "              </select>\n"
        "            </div>\n"
        "            <div className=\"field\">\n"
        "              <span className=\"muted\">{sub.totalRows} row(s) on this voucher</span>\n"
        "            </div>\n"
        "          </div>\n"
        "          <SubDetailGrid\n"
        "            rows={sub.rowsFor(sub.activeLine)}\n"
        "            onRowsChange={(r) => sub.setRowsFor(sub.activeLine, r)}\n"
        + (f"            columns={{{columns}}}\n" if columns else "")
        + "            parentLabel={`line ${sub.activeLine + 1}`}\n"
        f'            desktopSource="{source}"\n'
        "          />"
    )
    src = src[:close] + render + src[close + len("</table>") :]

    open(path, "w", encoding="utf-8").write(src)
    return "adopted"


def main() -> int:
    for slug, cfg in PAGES.items():
        print(f"  {slug}: {adopt(slug, cfg)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
