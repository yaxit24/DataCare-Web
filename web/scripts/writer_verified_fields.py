#!/usr/bin/env python3
"""
Report which API line fields a page could expose, filtered to the ones the WRITER actually consumes.

WHY THIS EXISTS
Wiring a grid column from the API interface alone produces DEAD CELLS: the operator types a value and
it is silently discarded. Proven twice on this codebase —
  * hallmark-sale: 12 of 61 fields I first exposed were dead. Five (ITM_MARGIN, TAG_LBR_PRC,
    TAG_LBR_RATE, TAG_LBR_AMT, TAG_OTH_AMT) have no column in SL_DETL at all despite the interface
    carrying a column comment; four were declared but never read; three are server-assigned serials.
  * purchase: purchase.ts:979 hard-codes ITM_SIZE: '' citing TR_PURC.cs:13106, noting the desktop
    writes blank on 77/77 sampled vouchers. A live post of itmSize="16" read back as null.

So the question is never "is the field on the interface" but "does the writer read it". A field counts
as live when the writer references it as `<obj>.<field>` somewhere, which covers both direct column
assignment and use as an override in the line calculator.

Usage: writer_verified_fields.py <page-slug> <api-module-path>
"""
import re
import sys
from pathlib import Path

WEB = Path(__file__).resolve().parents[1] / 'apps' / 'web'
API = Path(__file__).resolve().parents[1] / 'apps' / 'api'


def contract_fields(module: Path, interface_hint: str = 'Line') -> tuple[str, list[str]]:
    """
    Fields of the page's line interface.

    `interface_hint` may name the interface EXACTLY, and for multi-interface modules it must. Picking
    the largest match is a poor default: stockVoucherLifecycle.ts holds TagOpeningLine (65 fields),
    ItemOpeningLine and ItemLotLine (18), so an item-lot audit reported 55 fields to wire that belong
    to a different voucher entirely. Wiring those would have produced a grid of columns the item-lot
    writer never reads.
    """
    src = module.read_text()
    best: tuple[str, list[str]] = ('', [])
    for name, body in re.findall(r'export interface (\w+) \{(.*?)\n\}', src, re.S):
        exact = name == interface_hint
        if not exact and (interface_hint not in name or 'Result' in name or 'Computed' in name):
            continue
        if exact:
            return (name, re.findall(r'^\s+([a-z]\w*)\??:', body, re.M))
        fields = re.findall(r'^\s+([a-z]\w*)\??:', body, re.M)
        if len(fields) > len(best[1]):
            best = (name, fields)
    return best


def composed_source(page: Path, depth: int = 3) -> str:
    """
    Page source PLUS the source of the relative components it imports.

    Some pages are 5-line shells that delegate everything to a shared component — karigar-issue
    renders its whole grid through components/KarigarForm.tsx. Reading page.tsx alone reported 35
    fields as unwired when every one of them was already on screen, which would have produced a
    duplicate wiring. richness_web.py already follows composition to depth 3 for the same reason.
    """
    seen: set[Path] = set()

    def walk(file: Path, level: int) -> str:
        if level < 0 or file in seen or not file.exists():
            return ''
        seen.add(file)
        text = file.read_text()
        out = [text]
        for rel in re.findall(r"from '(\.[^']+)'", text):
            target = (file.parent / rel).resolve()
            for cand in (
                target.with_suffix('.tsx'),
                target.with_suffix('.ts'),
                target / 'index.tsx',
            ):
                if cand.exists():
                    out.append(walk(cand, level - 1))
                    break
        return '\n'.join(out)

    return walk(page, depth)


def writer_consumes(module: Path, field: str) -> bool:
    """A field is live when the writer dereferences it off any object."""
    src = module.read_text()
    return bool(re.search(r'\.' + re.escape(field) + r'\b', src))


# Fields the writer DOES read but which must still not become operator cells.
#
# The mechanical check answers "does the writer read it", which is necessary but not sufficient. Two
# ways it over-reports, both found by checking its output against the source:
#   1. Wrong row type. `otherWt` is read at sales.ts:1512 as `g.otherWt`, where `g` is an OLD GOLD row,
#      not a sale line. Exposing it on the item grid would send it where nothing consumes it.
#   2. Server-assigned identity. `vchSrno` is genuinely read (sales.ts:913 `VCH_SRNO: line.vchSrno`)
#      but is the persisted BAR_DETL tag-instance identity; letting an operator type it would let a
#      request claim another line's tag identity.
# So the script is a FILTER, not an oracle: it reliably eliminates dead fields, and the survivors still
# need eyes. Anything added here needs a reason recorded beside it.
NOT_OPERATOR_INPUT = {
    'otherWt': 'read as g.otherWt (old-gold row), not a sale line field — sales.ts:1512',
    'vchSrno': 'server-assigned BAR_DETL tag-instance identity — sales.ts:913',
    'oldSrNo': 'server-assigned source-row serial',
    'tagSrNo': 'server-assigned tag serial',
    'lineNo': 'server-assigned line ordinal',
    'srNo': 'server-assigned row ordinal',
}


def main() -> int:
    if len(sys.argv) < 3:
        print(__doc__)
        return 2
    slug, module_path = sys.argv[1], sys.argv[2]
    interface = sys.argv[3] if len(sys.argv) > 3 else 'Line'
    module = API / module_path if not module_path.startswith('/') else Path(module_path)
    page = WEB / 'app' / '(app)' / 'txn' / slug / 'page.tsx'
    if not module.exists() or not page.exists():
        print(f'missing: {module if not module.exists() else page}')
        return 1

    name, fields = contract_fields(module, interface)
    page_src = composed_source(page)
    live, dead, already, excluded = [], [], [], []
    for f in fields:
        on_page = re.search(r'(?<![A-Za-z0-9_])' + re.escape(f) + r'(?![A-Za-z0-9_])', page_src)
        if on_page:
            already.append(f)
        elif f in NOT_OPERATOR_INPUT:
            excluded.append(f)
        elif writer_consumes(module, f):
            live.append(f)
        else:
            dead.append(f)

    print(f'{slug}  <-  {module.name} :: {name}  ({len(fields)} contract fields)')
    print(f'  already on page : {len(already)}')
    print(f'  LIVE to wire    : {len(live)}')
    print('    ' + ', '.join(live))
    print(f'  dead (writer never reads them; do NOT expose): {len(dead)}')
    print('    ' + ', '.join(dead))
    if excluded:
        print(f'  read but NOT operator input: {len(excluded)}')
        for f in excluded:
            print(f'    {f}: {NOT_OPERATOR_INPUT[f]}')
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
