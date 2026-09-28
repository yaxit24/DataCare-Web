"""Phase E metric: which fields does the desktop COMPUTE, and does the web compute them too?

Validations have a stable key (their message text). Calculations do not — a decompiled expression like
`mSG_OLD[Row,7] = Format(Val(TEXT_OLD.Text) / Val(mSG_OLD[Row,11]) ...)` shares no text with any web
implementation, so text matching would be meaningless.

What IS recoverable is the ASSIGNMENT TARGET. Every calculation writes a grid cell, and the
form-behaviour catalog records `gridColumns` as name→index. Resolving the two together turns an opaque
expression into a named computed field (`cUrTouch`, `cFine`, `cItAmt`), which is a real inventory the
web can be measured against.

Two resolution steps, both evidence-based:

1. **Family.** The catalog flattens all of a form's grids into one name→index map, so one index maps to
   several names. The grid VARIABLE disambiguates: `mSG_OLD` assigns the old-gold family (`cUr*`),
   `MSG2_TOTAL` the settlement family (`*2` suffix), `mSG_ORD` the order-pick family (`cOr*`), and so
   on. Families are scored by how well their index set covers the variable's observed indices; the best
   cover wins, and a tie or poor cover is reported as unresolved rather than guessed.

2. **Persisted column.** A desktop control name is normalised (`cItAmt` → `ITM_AMT`) through an alias
   table built from the form's own write set. Where no confident match exists the field is reported
   `unmapped` — the analyzer never invents a mapping.

Output: `CALC-AUDIT.json` — per form, the named computed fields, their resolved persisted column, and
whether the web writes that column. This is the tracing basis Phase E contracts are built from; it is
deliberately not published as a single "calculation coverage %" because writing a column is not proof
that the value was computed the same way. That proof is a golden-vector test per formula.

Run: python3 project-memory/parity/calc_audit.py
"""

from __future__ import annotations

import json
import re
import sys
from collections import Counter
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
BEHAVIOR = ROOT / "project-memory/catalogs/form-behavior"
LOGIC = ROOT / "project-memory/catalogs/form-logic"
DESKTOP_SRC = ROOT / "unified/src/csharp/DataCareNext"
SCHEMA = json.loads(
    (ROOT / "project-memory/catalogs/realdb-schema-full.json").read_text(encoding="utf-8")
).get("tables", {})
ALL_TABLES = frozenset(SCHEMA)

sys.path.insert(0, str(Path(__file__).resolve().parent))
sys.dont_write_bytecode = True
import deep_column_audit as dca  # noqa: E402

# Only real grid variables: the desktop names them mSG*/MSG*/DtIdtl*/dGV*. `val[...]` and other
# locals are not grids and must not be mistaken for computed cells.
ASSIGN_TARGET = re.compile(r"^\s*((?:mSG|MSG|DtIdtl|dGV)[A-Za-z0-9_]*)\s*\[\s*[^,\]]+,\s*(\d+)\s*\]\s*=")

# The desktop names its grids, which is stronger evidence than index scoring. Anything unlisted falls
# back to index-cover scoring and is reported unresolved when the cover is weak.
# NOTE: matched case-INSENSITIVELY. The decompiler emits the same grid as both `mSG2_TOTAL` and
# `MSG2_TOTAL` depending on the call site, and an exact-case map silently missed one spelling.
VARIABLE_FAMILY: dict[str, str] = {
    "mSG": "main",
    "MSG": "main",
    "mSG_TOT": "main",
    "MSG_TOT": "main",
    "mSG_PR": "purchase",
    "mSG_OLD": "oldGold",
    "MSG2_TOTAL": "settlement",
    "mSG_ORD": "orderPick",
    "mSG_IDTL": "stone",
    "mSG1": "stone",
    "DtIdtl": "stone",
    "mSG_UPI": "upi",
    "mSG_CRNT": "credit",
    # Totals grids share the MAIN column naming — they have no distinguishing name prefix — so their
    # name pool is "main". Whether their cells PERSIST is a separate question, tracked below.
    "mSG_TOT": "main",
    "mSG_PR_TOT": "purchase",
    "mSG_BILL_TOT": "main",
    "mSG_ADJ": "main",
    # Third-level sub-detail grids (stone/diamond breakdowns under a line).
    "mSG_IDTL": "stone",
    "mSG_PR_IDTL": "stone",
    "mSG_RTN_IDTL": "stone",
    "mSG_DM": "stone",
}

#: On-screen SUMMARY grids. Their cells feed header fields or are display-only, so a cell that does not
#: map to a detail column is EXPECTED here rather than a tool failure. Kept separate from the name-pool
#: family above: conflating the two starved the name pool and cut resolution by half when first tried.
NON_PERSISTING_VARIABLES = {"mSG_TOT", "mSG_PR_TOT", "mSG_BILL_TOT", "mSG_ADJ", "mSG2_TOTAL"}

# Column-name families within a form's flattened gridColumns map.
FAMILIES: tuple[tuple[str, re.Pattern[str]], ...] = (
    ("purchase", re.compile(r"^cPr")),
    ("stone", re.compile(r"^c1")),
    ("oldGold", re.compile(r"^cUr")),
    ("orderPick", re.compile(r"^cOr(?!d)")),
    ("upi", re.compile(r"^cUp")),
    ("credit", re.compile(r"^cCr")),
    ("settlement", re.compile(r"2$")),
)


def family_of(name: str) -> str:
    for label, pattern in FAMILIES:
        if pattern.search(name):
            return label
    return "main"


def camel_variants(name: str) -> list[str]:
    """Candidate column names for a control, most specific first.

    Family prefixes (`Ur`/`Or`/`Up`/`Cr`/`Pr`) usually encode WHICH grid a cell belongs to rather than
    part of the field name — `cPrTotAmt` is the purchase grid's total, persisted as `TOT_AMT`. But not
    always: `cPrCode` really is `PR_CODE`. So both forms are offered and the caller keeps whichever
    exists in the table's physical schema, preferring the unstripped (more specific) reading.
    """
    core = re.sub(r"^c1|^c", "", name)
    core = re.sub(r"2$", "", core)
    out = [re.sub(r"(?<!^)(?=[A-Z])", "_", core).upper()]
    stripped = re.sub(r"^(Ur|Or|Up|Cr|Pr)(?=[A-Z])", "", core)
    if stripped != core:
        out.append(re.sub(r"(?<!^)(?=[A-Z])", "_", stripped).upper())
    return out


def camel_to_upper(name: str) -> str:
    """`cUrTouch` → `TOUCH`. Strips the `c`/`c1` control prefix, the family prefix (Ur/Or/Up/Cr for
    old-gold/order/UPI/credit grids) and the settlement `2` suffix, because those encode WHICH grid the
    cell belongs to, not the field. Every candidate is still checked against the form's own write set
    before it is accepted, so a wrong strip cannot invent a mapping."""
    core = re.sub(r"^c1|^c", "", name)
    core = re.sub(r"^(Ur|Or|Up|Cr)(?=[A-Z])", "", core)
    core = re.sub(r"2$", "", core)
    return re.sub(r"(?<!^)(?=[A-Z])", "_", core).upper()


#: Desktop weight/measure abbreviations used in column names (`NET_WT` is stored as `NWT`).
ABBREVIATIONS: tuple[tuple[str, str], ...] = (
    ("NET_WT", "NWT"),
    ("GR_WT", "GWT"),
    ("GROSS_WT", "GWT"),
)

#: Column prefixes, MOST SPECIFIC FIRST. `ITM_` must be tried before `KR_`/`HM_`/`OLD_`, otherwise a
#: plain `cNetWt` resolves to `KR_NET_WT` (the karigar weight) instead of `ITM_NWT` — a wrong mapping
#: that would send a contract reviewer to the wrong formula. Family-specific prefixes are only reached
#: when the control name itself did not already produce a match.
COLUMN_PREFIXES: tuple[str, ...] = ("ITM_", "IT_", "LBR_", "TAG_", "HM_", "KR_", "OLD_")


def resolve_column(control: str, write_columns: set[str]) -> str | None:
    """Best-effort desktop control name → persisted column, or None when not confident.

    Candidates are generated most-specific first and each is checked against the table's real columns,
    so a wrong strip or prefix cannot invent a mapping — it simply fails to match.
    """
    forms: list[str] = []
    for base in camel_variants(control):
        forms.append(base)
        for long, short in ABBREVIATIONS:
            if long in base:
                forms.append(base.replace(long, short))

    # Prefix priority must dominate the abbreviation form: iterating forms outermost tried
    # `KR_NET_WT` before `ITM_NWT` and mis-resolved a plain `cNetWt` to the karigar weight.
    candidates: list[str] = list(forms)
    for prefix in COLUMN_PREFIXES:
        for form in forms:
            if not form.startswith(prefix):
                candidates.append(f"{prefix}{form}")
    for form in forms:
        candidates.append(f"{form}_AMT")
        candidates.append(f"{form}_WT")
    for candidate in candidates:
        if candidate in write_columns:
            return candidate
    return None


def main() -> int:
    web_columns = dca.web_columns_by_table()
    report: dict[str, dict] = {}
    totals = Counter()

    for path in sorted(BEHAVIOR.glob("*.behavior.json")):
        data = json.loads(path.read_text(encoding="utf-8", errors="ignore"))
        form = data.get("form") or path.name.split(".")[0]
        calc = data.get("calc") or []
        grid = data.get("gridColumns") or {}
        if not isinstance(calc, list) or not calc or not isinstance(grid, dict):
            continue

        # index → names, and family → {index: name}
        by_family: dict[str, dict[int, str]] = {}
        for name, index in grid.items():
            if not isinstance(index, int):
                continue
            by_family.setdefault(family_of(name), {}).setdefault(index, name)

        # Tables the form writes. NOTE: the logic catalog's column lists only cover literal
        # `INSERT INTO T(cols)` statements — the sale/purchase family writes through DataTable row
        # assignment, so their column lists are absent. Table NAMES are reliable in both shapes, so
        # candidate columns are checked against the tables' PHYSICAL schema instead.
        logic_path = LOGIC / f"{form}.logic.json"
        tables: set[str] = set()
        if logic_path.exists():
            writes = (json.loads(logic_path.read_text(encoding="utf-8", errors="ignore")).get("writes")
                      or {})
            if isinstance(writes, dict):
                for kind in ("INSERT", "UPDATE"):
                    block = writes.get(kind)
                    if isinstance(block, dict):
                        tables |= {t.upper() for t in block}
                    elif isinstance(block, list):
                        tables |= {str(t).upper() for t in block}
        # Two tiers of evidence, kept apart on purpose.
        #
        # TIER 1 — tables the logic catalog records the form WRITING. Highest confidence, but the
        # catalog only captures literal SQL, so forms that write through DataTable row assignment (the
        # whole sale/purchase family) have incomplete lists.
        #
        # TIER 2 — every known table name appearing as a SQL identifier anywhere in the form's own
        # source. This recovers the missing write targets, but it also picks up tables the form merely
        # SELECTs from, so a Tier-2 match could attach a control to a column the form never writes.
        # Matches are therefore resolved against Tier 1 FIRST and only fall back to Tier 2, with the
        # tier recorded per field so a reviewer can weigh it.
        written_tables = set(tables)
        referenced_tables: set[str] = set()
        source = DESKTOP_SRC / f"{form}.cs"
        if source.exists():
            text = source.read_text(encoding="utf-8", errors="ignore")
            for name in ALL_TABLES:
                if name not in written_tables and re.search(rf"\b{re.escape(name)}\b", text):
                    referenced_tables.add(name)
        tables = written_tables | referenced_tables

        def columns_of(names: set[str]) -> set[str]:
            out: set[str] = set()
            for table in names:
                out |= {
                    c["col"]
                    for c in (SCHEMA.get(table, {}).get("columns") or [])
                    if isinstance(c, dict)
                }
            return out

        written_columns = columns_of(written_tables)
        referenced_columns = columns_of(referenced_tables)
        write_columns = written_columns | referenced_columns

        # Group observed assignments by grid variable.
        per_variable: dict[str, set[int]] = {}
        for entry in calc:
            m = ASSIGN_TARGET.match(str(entry))
            if m:
                per_variable.setdefault(m.group(1), set()).add(int(m.group(2)))

        fields: list[dict] = []
        for variable, indices in sorted(per_variable.items()):
            resolved_family = VARIABLE_FAMILY.get(variable) or VARIABLE_FAMILY.get(
                next((k for k in VARIABLE_FAMILY if k.lower() == variable.lower()), "")
            )
            if resolved_family is None:
                # Unknown grid variable: score families by index cover and require a clear winner.
                scores = sorted(
                    ((sum(1 for i in indices if i in mapping), label) for label, mapping in by_family.items()),
                    reverse=True,
                )
                if scores and scores[0][0] >= max(1, int(len(indices) * 0.6)) and (
                    len(scores) == 1 or scores[0][0] > scores[1][0]
                ):
                    resolved_family = scores[0][1]
            mapping = by_family.get(resolved_family or "", {})
            for index in sorted(indices):
                control = mapping.get(index)
                column = resolve_column(control, written_columns) if control else None
                tier = "written" if column else None
                if control and not column:
                    column = resolve_column(control, referenced_columns)
                    tier = "referenced" if column else None
                written = bool(column) and any(
                    column in web_columns.get(t, set()) for t in tables
                )
                fields.append(
                    {
                        "variable": variable,
                        "index": index,
                        "family": resolved_family,
                        "control": control,
                        "column": column,
                        "webWritesColumn": written,
                        "screenSummary": variable in NON_PERSISTING_VARIABLES,
                        "evidenceTier": tier,
                    }
                )
                totals["fields"] += 1
                if variable in NON_PERSISTING_VARIABLES:
                    totals["screenSummary"] += 1
                if control is None:
                    totals["unresolvedControl"] += 1
                elif column is None:
                    totals["unmappedColumn"] += 1
                elif written:
                    totals["columnWritten"] += 1
                    totals[f"tier_{tier}"] += 1
                else:
                    totals["columnNotWritten"] += 1

        report[form] = {
            "calcExpressions": len(calc),
            "computedFields": len(fields),
            "fields": fields,
        }

    print(f"{'form':22}{'calc':>6}{'computed':>9}{'named':>7}{'mapped':>8}")
    ranked = sorted(report.items(), key=lambda kv: -kv[1]["computedFields"])
    for form, row in ranked[:15]:
        named = sum(1 for f in row["fields"] if f["control"])
        mapped = sum(1 for f in row["fields"] if f["column"])
        print(f"{form:22}{row['calcExpressions']:6}{row['computedFields']:9}{named:7}{mapped:8}")

    summary = totals["screenSummary"]
    persisted = totals["fields"] - summary
    print(
        f"\nComputed grid cells {totals['fields']}:"
        f"\n  {summary} are SCREEN TOTALS — `mSG_TOT[0,n] = Val(mSG_TOT[0,n]) + Val(MSG[M,n])` mirrors the"
        f"\n    main grid's columns (`mSG_TOT.Cols = MSG.Cols`) and accumulates them into row 0. These are"
        f"\n    footer sums, not persisted-value formulas, so the web's bill totals cover them."
        f"\n  {persisted} are per-line formulas — the real contract-review surface."
    )
    print(
        f"Named {totals['fields'] - totals['unresolvedControl']}; "
        f"resolved to a column {totals['columnWritten'] + totals['columnNotWritten']} "
        f"(web writes {totals['columnWritten']}: {totals['tier_written']} from a catalogued write table, "
        f"{totals['tier_referenced']} from a table the form's source references)"
    )
    print(
        f"Unresolved control names {totals['unresolvedControl']}; "
        f"named but unmapped to a column {totals['unmappedColumn']}"
    )
    print(
        "No single coverage % is published: writing a column does not prove the value was computed\n"
        "the same way. Formula equality needs a golden-vector test, tracked per form contract."
    )

    (ROOT / "project-memory/parity/CALC-AUDIT.json").write_text(
        json.dumps({"totals": dict(totals), "forms": report}, indent=2) + "\n"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
