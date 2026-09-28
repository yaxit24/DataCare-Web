#!/usr/bin/env python3
"""
Wire writer-verified API line fields onto a page as extended grid columns.

This is the fifth application of a pattern done by hand four times (mfg-issue/receive, hallmark-sale,
purchase-return, wholesale-sale, sale-return), so it is generalised here rather than repeated again.

WHAT IT DOES, in the order the page needs it:
  1. extends the `Line` interface with each field as a string
  2. extends `blank()` with '' for each
  3. emits an `extendedLineFields` registry (label per field) and a `NUMERIC_EXTENDED` set
  4. imports ExtendedHeaderCells/ExtendedBodyCells/GridModeToggle and adds `fullGrid` state
  5. renders the header cells, body cells and the mode toggle

WHAT IT DELIBERATELY DOES NOT DO:
  * It never invents the field list. Input comes from writer_verified_fields.py, which checks the
    WRITER rather than the interface — wiring from the interface produced 12 dead cells on
    hallmark-sale, five of which had no database column at all.
  * On submit, a blank cell is OMITTED, never coerced to 0. An explicit zero is an override at the
    writer and would defeat the server's own derivation; that suppression bug has been fixed twice
    already in this project (dhiran interest, karigar labour).

Usage: wire_extended_columns.py <slug> <baseColumns> <field:Label> [field:Label ...]
"""
import re
import sys
from pathlib import Path

WEB = Path(__file__).resolve().parents[1] / 'apps' / 'web'

# Fields whose values are numeric at the API. Anything else is sent as a string, because coercing a
# code like a design number or a book code to Number would corrupt it.
NUMERIC_HINT = re.compile(
    r'(Wt|Pct|Amt|Amount|Rate|Fine|Cost|Pcs|Qty|Mrp|Srno|SrNo|Touch|Ghat|Ght|Loss|Weight)$'
)


def numeric(field: str) -> bool:
    return bool(NUMERIC_HINT.search(field))


def main() -> int:
    if len(sys.argv) < 4:
        print(__doc__)
        return 2
    slug, base_columns, specs = sys.argv[1], sys.argv[2], sys.argv[3:]
    fields = []
    for spec in specs:
        name, _, label = spec.partition(':')
        fields.append((name, label or name))

    page = WEB / 'app' / '(app)' / 'txn' / slug / 'page.tsx'
    src = page.read_text()
    if 'extendedLineFields' in src:
        print(f'{slug}: already has an extended registry; skipping')
        return 0

    # 1 + 2: the row interface and blank(). Pages use either `Line`/`lines` or `Row`/`rows`;
    # both conventions are in the tree, so detect rather than assume.
    # Pages declare the row shape as `interface Line`, `interface Row`, or a `type X = {` alias
    # (wholesale-sale-return uses `type ReturnLine = {`). Detect all three rather than assume.
    row_type = None
    m = None
    for pattern, name in (
        (r'(interface Line \{)(.*?)(\n\})', 'Line'),
        (r'(interface Row \{)(.*?)(\n\})', 'Row'),
        (r'type (\w*(?:Line|Row))\s*=\s*\{(.*?)(\n\};?)', None),
    ):
        found = re.search(pattern, src, re.S)
        if found:
            m = found
            row_type = name or found.group(1)
            break
    if not m:
        print(f'{slug}: no row interface or type alias found')
        return 1
    src = src[: m.end(2)] + ''.join(f'\n  {f}: string;' for f, _ in fields) + src[m.end(2) :]

    # blank() appears both multi-line and as a SINGLE-LINE literal
    # (`const blank = (): Line => ({ itCode: '', pcs: '1' });`). A multi-line regex silently misses the
    # single-line form and earlier produced missing-comma syntax errors on three pages, so handle both.
    m = re.search(r'(const blank[^=]*=[^{]*\{)(.*?)(\n\}\);)', src, re.S)
    if m and '\n' in m.group(2):
        src = src[: m.end(2)] + ''.join(f"\n  {f}: ''," for f, _ in fields) + src[m.end(2) :]
    else:
        one = re.search(r'(const blank[^=]*=[^{]*\(\{)(.*?)(\}\);)', src)
        if not one:
            print(f'{slug}: no `blank()` found in either form')
            return 1
        existing = one.group(2).rstrip().rstrip(',')
        added = ''.join(f", {f}: ''" for f, _ in fields)
        src = src[: one.start(2)] + existing + added + ' ' + src[one.end(2) :]

    # 3: registry + numeric set
    registry = (
        '/**\n'
        ' * P7 extended grid columns: desktop columns this form has and the web did not.\n'
        ' *\n'
        ' * Every entry was verified against the WRITER, not the API interface — a field present on the\n'
        ' * interface is not necessarily persisted (purchase hard-codes ITM_SIZE to blank, and five\n'
        ' * SaleLineInput fields have no SL_DETL column at all), and such a cell would silently discard\n'
        ' * what the operator types.\n'
        ' */\n'
        'const extendedLineFields: Array<[keyof ' + row_type + ', string]> = [\n'
        + ''.join(f"  ['{f}', '{lbl}'],\n" for f, lbl in fields)
        + '];\n\n'
        '/** Fields the API takes as numbers; everything else stays a string so codes are not mangled. */\n'
        'const NUMERIC_EXTENDED = new Set<string>([\n'
        + ''.join(f"  '{f}',\n" for f, _ in fields if numeric(f))
        + ']);\n\n'
    )
    anchor = re.search(r'\nconst blank', src)
    src = src[: anchor.start() + 1] + registry + src[anchor.start() + 1 :]

    # 4: imports + state
    if 'ExtendedHeaderCells' not in src:
        last = list(re.finditer(r'^import .*?;\n', src, re.M))[-1]
        src = (
            src[: last.end()]
            + 'import {\n  ExtendedBodyCells,\n  ExtendedHeaderCells,\n'
            '  GridModeToggle,\n} from \'../../../../components/ExtendedGrid\';\n'
            + src[last.end() :]
        )
    m = re.search(r'const \[(?:lines|rows), set(?:Lines|Rows)\][^\n]*\n', src)
    if m and 'fullGrid' not in src:
        src = src[: m.end()] + '  const [fullGrid, setFullGrid] = useState(false);\n' + src[m.end() :]

    # 5: header, body, toggle
    h = re.search(r'(\n\s+)<th></th>\n(\s+</tr>)', src) or re.search(
        r'(\n\s+)(</tr>\n\s+</thead>)', src
    )
    if h:
        src = (
            src[: h.start()]
            + f'{h.group(1)}<ExtendedHeaderCells full={{fullGrid}} fields={{extendedLineFields}} />'
            + src[h.start() :]
        )
    # The row variable and setter names vary across pages (`l`/`setLine`, `r`/`setRow`), so read them
    # from the file instead of assuming; guessing produced TS2304 "cannot find name 'l'".
    setter = 'setLine' if re.search(r'const setLine\b', src) else 'setRow'
    row_var = 'l'
    rv = re.search(r'\{(?:lines|rows)\.map\(\((\w+), (\w+)\)', src)
    if rv:
        row_var = rv.group(1)
    b = re.search(r'(\n\s+)(<td>\s*\n\s+<button)', src)
    if b:
        i = b.group(1)
        src = (
            src[: b.start()]
            + f'{i}<ExtendedBodyCells{i}  full={{fullGrid}}{i}  fields={{extendedLineFields}}'
            f'{i}  line={{{row_var}}}{i}  row={{i}}{i}  baseColumns={{{base_columns}}}'
            f'{i}  setValue={{(row, key, value) => {setter}(row, key, value)}}{i}/>'
            + src[b.start() :]
        )
    t = re.search(r'(\n\s+)<table', src)
    if t:
        src = (
            src[: t.start()]
            + f'{t.group(1)}<GridModeToggle full={{fullGrid}} setFull={{setFullGrid}} '
            f'extendedCount={{extendedLineFields.length}} testId="{slug}-grid-mode" />'
            + src[t.start() :]
        )

    page.write_text(src)
    print(f'{slug}: wired {len(fields)} writer-verified columns')
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
