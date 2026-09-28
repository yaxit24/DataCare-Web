#!/usr/bin/env python3
"""Wire MfgLine's operator fields onto the manufacturing pages (parity plan P3-1).

27 of MfgLine's 63 fields were accepted by the server and named by no frontend file, so no screen
could send them. They are the desktop's manufacturing reconciliation set: the issue-versus-receive
difference, the karigar job-work side, process losses, auxiliary material, the stone roll-up and the
order/repair provenance. Without them `mfg-receive` cannot express the desktop's own difference
formula, `DifWt = IsNwt - (NetWt + GhtWt + Chole + Ghis + MtrlWt)` (TR_MFG_ORD_REC.cs:4726).

Rendered through the existing ExtendedGrid so they become real grid CELLS behind a "Full grid"
toggle, matching how purchase and sales already present their extended columns — the desktop keeps
these as columns the operator tabs across, and a per-row disclosure panel would change the
data-entry motion.
"""
from __future__ import annotations

import os
import re
import sys

WEB = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", "apps", "web"))

# field -> (label, desktop column). Labels are the desktop grid headers where one exists.
FIELDS = [
    ("totalGrossWt", "TotGwt"),
    ("totalLessWt", "TotLwt"),
    ("karigarJobworkWt", "KrJdtWt"),
    ("karigarMinorityWt", "KrMinoWt"),
    ("karigarMinorityAmount", "KrMinoAmt"),
    ("oldGrossWt", "OldGwt"),
    ("oldFine", "OldFine"),
    ("oldLabourAmount", "OldLbrAmt"),
    ("oldOther", "OldOth"),
    ("addOtherWt", "AddOthWt"),
    ("lessOtherWt", "LessOthWt"),
    ("rtnChol", "RtnChol"),
    ("rtnGhis", "RtnGhis"),
    ("itmGhat", "ItmGhat"),
    ("mtrlWt", "MtrlWt"),
    ("mtrlItCode", "MtrlItCode"),
    ("fittingItCode", "FtngItCode"),
    ("isuItCode", "IsuItCode"),
    ("dmPcs", "DmPcs"),
    ("dmWt", "DmWt"),
    ("designSrNo", "DesignSrNo"),
    ("adjustDate", "AdjDate"),
    ("repYrcd", "RepYrCd"),
    ("repDbcd", "RepDbCd"),
    ("repNo", "RepNo"),
    ("repSrno", "RepSrNo"),
    ("repAcCode", "RepAcCode"),
]
NUMERIC = {
    "totalGrossWt", "totalLessWt", "karigarJobworkWt", "karigarMinorityWt", "karigarMinorityAmount",
    "oldGrossWt", "oldFine", "oldLabourAmount", "oldOther", "addOtherWt", "lessOtherWt",
    "rtnChol", "rtnGhis", "itmGhat", "mtrlWt", "dmPcs", "dmWt", "designSrNo", "repSrno",
}


def wire(slug: str, base_columns: int) -> str:
    path = os.path.join(WEB, "app", "(app)", "txn", slug, "page.tsx")
    src = open(path, encoding="utf-8").read()
    if "extendedMfgFields" in src:
        return "already"

    # 1. imports
    last = list(re.finditer(r"^import .*?;\n", src, re.M))[-1]
    src = (
        src[: last.end()]
        + "import {\n"
        "  ExtendedBodyCells,\n"
        "  ExtendedHeaderCells,\n"
        "  extendedGridColumnCount,\n"
        "  GridModeToggle,\n"
        "} from '../../../../components/ExtendedGrid';\n"
        + src[last.end() :]
    )

    # 2. Line type gains the fields
    src = re.sub(
        r"(interface Line \{\n)",
        r"\1" + "".join(f"  {f}: string;\n" for f, _ in FIELDS),
        src,
        count=1,
    )
    # 3. blank() initialises them
    src = re.sub(
        r"(const blank = \(\): Line => \(\{\n)",
        r"\1" + "".join(f"  {f}: '',\n" for f, _ in FIELDS),
        src,
        count=1,
    )

    # 4. the field table + full-grid state, placed before the component's return
    decl = (
        "/**\n"
        " * MfgLine fields the server accepted that no screen could send (parity plan P3-1).\n"
        " *\n"
        " * The desktop keeps these as grid columns the operator tabs across:\n"
        " * reconciliation (TotGwt/TotLwt and the issue-side comparison), the karigar job-work side\n"
        " * (KrJdtWt/KrMinoWt/KrMinoAmt), old-metal (OldGwt/OldFine/OldLbrAmt/OldOth), process losses\n"
        " * (RtnChol filings, RtnGhis polishing dust, ItmGhat), auxiliary material (MtrlWt/MtrlItCode,\n"
        " * FtngItCode), the stone roll-up (DmPcs/DmWt) and order/repair provenance.\n"
        " *\n"
        " * Chole and Ghis are not decoration: TR_MFG_ORD_REC.cs:4726 computes the accountable\n"
        " * difference as `IsNwt - (NetWt + GhtWt + Chole + Ghis + MtrlWt)`, so without them the screen\n"
        " * cannot state what the karigar owes.\n"
        " */\n"
        "const extendedMfgFields: Array<[keyof Line, string]> = [\n"
        + "".join(f"  ['{f}', '{label}'],\n" for f, label in FIELDS)
        + "];\n\n"
    )
    src = re.sub(r"(\nexport default function )", "\n" + decl + r"\1", src, count=1)

    # 5. full-grid state next to the lines state
    state = re.search(r"const \[lines, setLines\] = useState<Line\[\]>\([^\n]*\n", src)
    src = (
        src[: state.end()]
        + "  const [fullGrid, setFullGrid] = useState(false);\n"
        + src[state.end() :]
    )

    # 6. keyboard column count follows the mode
    src = src.replace(
        "  const handleGridKey = useGridKeyboard({\n    rowCount: lines.length,",
        f"  const handleGridKey = useGridKeyboard({{\n    rowCount: lines.length,\n"
        f"    columnCount: extendedGridColumnCount(fullGrid, {base_columns}, extendedMfgFields.length),",
        1,
    )

    # 7. header + body cells, and the toggle above the table
    src = src.replace("                <th></th>\n", "                <ExtendedHeaderCells full={fullGrid} fields={extendedMfgFields} />\n                <th></th>\n", 1)
    src = re.sub(
        r"(\n\s+)(<td>\s*\n\s+<button\s*\n\s+type=\"button\"\s*\n\s+className=\"ghost\")",
        r"\1<ExtendedBodyCells\1  full={fullGrid}\1  fields={extendedMfgFields}\1  line={l}\1  row={i}\1  baseColumns={"
        + str(base_columns)
        + r"}\1  setValue={(row, key, value) => setLine(row, key, value)}\1/>\1\2",
        src,
        count=1,
    )
    src = src.replace(
        '          <table className="grid" onKeyDown={handleGridKey}>',
        '          <GridModeToggle\n'
        '            full={fullGrid}\n'
        '            setFull={setFullGrid}\n'
        '            extendedCount={extendedMfgFields.length}\n'
        f"            testId=\"{slug}-grid-mode\"\n"
        '          />\n'
        '          <table className="grid" onKeyDown={handleGridKey}>',
        1,
    )

    # 8. payload
    payload = "".join(
        f"            {f}: {'n(l.' + f + ')' if f in NUMERIC else 'l.' + f + ' || undefined'},\n"
        for f, _ in FIELDS
    )
    src = src.replace(
        "            components: sub.componentsFor(sourceIndex),\n",
        "            components: sub.componentsFor(sourceIndex),\n" + payload,
        1,
    )

    open(path, "w", encoding="utf-8").write(src)
    return "wired"


def main() -> int:
    for slug, base in (("mfg-receive", 7), ("mfg-issue", 5)):
        print(f"  {slug}: {wire(slug, base)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
