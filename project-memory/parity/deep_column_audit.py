#!/usr/bin/env python3
"""Column-level desktop-vs-web persistence depth.

The desktop catalogs record, per form, the EXACT columns each INSERT/UPDATE touches
(project-memory/catalogs/form-logic/<FORM>.logic.json -> writes.INSERT/UPDATE[table] = [columns]).

This script extracts the equivalent from the web sources by resolving row objects to their table:

  insertRowTx(tx, 'TABLE', tenantId, { COL: ..., COL2: ... })   -> inline object
  { table: 'TABLE', rows: [header] } + const header = { COL: ... }  -> variable resolution
  INSERT INTO "TABLE"(colA,colB,...)                              -> raw SQL column list

It then reports, per table, desktop-written columns vs web-written columns. This is the strongest
available measure of functional depth: a voucher that persists 20 of the desktop's 98 header columns
is not "implemented", however many routes exist.
"""

from __future__ import annotations

import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
LOGIC = ROOT / "project-memory/catalogs/form-logic"
WEB_SRC = ROOT / "web/apps/api/src"
SCHEMA = ROOT / "project-memory/catalogs/realdb-schema-full.json"

IDENT = r"[A-Za-z_$][A-Za-z0-9_$]*"


def balanced(body: str, start: int, open_ch: str = "{", close_ch: str = "}") -> tuple[str, int]:
    """Return the balanced block beginning at body[start] == open_ch."""
    depth = 0
    i = start
    while i < len(body):
        ch = body[i]
        if ch == open_ch:
            depth += 1
        elif ch == close_ch:
            depth -= 1
            if depth == 0:
                return body[start : i + 1], i + 1
        i += 1
    return "", len(body)


# Anchored on `{` or `,` rather than line start: prettier keeps short objects inline
# (`const key = { CO_CODE: co, LC_CODE: lc }`), and a line-anchored pattern misses every
# key after the first, silently under-counting coverage. `(?!:)` avoids `"COL"::text` casts.
KEY = re.compile(r"""[{,]\s*['"]?([A-Z][A-Z0-9_]{1,})['"]?\s*:(?!:)""")
SPREAD_KEY = re.compile(r"\.\.\.(" + IDENT + r")")


def object_keys(block: str) -> tuple[set[str], set[str]]:
    """Columns declared directly, plus spread variable names to resolve later."""
    return {m.group(1) for m in KEY.finditer(block)}, {
        m.group(1) for m in SPREAD_KEY.finditer(block)
    }


def collect_variables(body: str) -> dict[str, tuple[set[str], set[str]]]:
    """Flat name -> (keys, spreads). See collect_variable_defs for position-aware resolution."""
    """const NAME = { ... } and const NAME = xs.map(... => ({ ... })) object literals."""
    out: dict[str, tuple[set[str], set[str]]] = {}
    for m in re.finditer(r"const\s+(" + IDENT + r")\s*(?::[^=]+)?=\s*", body):
        name = m.group(1)
        # Balance on absolute positions. A fixed look-ahead window silently truncated large row
        # objects: adding 50 columns to one builder pushed it past the window and the analyzer
        # then reported ZERO columns for that variable.
        # 400 rather than 200: a destructured parameter list can be long, and `=> ({` must stay in view.
        head = body[m.end() : m.end() + 400]
        # An ARROW-RETURNED object must win over a destructuring parameter. For
        #   const rows = xs.map(({ a, b }, i) => ({ COL: ... }))
        # the bare `({` heuristic balanced the parameter pattern `{ a, b }` and reported its keys as the
        # row's columns — so a builder using destructured parameters silently contributed nothing. Look for
        # `=> ({` first, which is unambiguous.
        returned = head.find("=> ({")
        brace = head.find("{")
        arrow = head.find("({")
        if returned != -1:
            block, _ = balanced(body, m.end() + returned + len("=> ("))
        elif arrow != -1 and (brace == -1 or arrow <= brace):
            block, _ = balanced(body, m.end() + arrow + 1)
        elif brace != -1 and brace < 40:
            block, _ = balanced(body, m.end() + brace)
        else:
            continue
        if block:
            keys, spreads = object_keys(block)
            if keys:
                out.setdefault(name, (set(), set()))
                out[name][0].update(keys)
                out[name][1].update(spreads)

    # `const rows: X[] = []; … rows.push({ COL: … })` — a builder that accumulates instead of mapping.
    # Without this the whole object was invisible: `batchReceipt.ts` builds CASH_DATA this way, so five
    # real columns read as unwritten while a sibling module happened to credit the others.
    for m in re.finditer(r"(" + IDENT + r")\.push\(\s*\{", body):
        name = m.group(1)
        block, _ = balanced(body, m.end() - 1)
        if not block:
            continue
        keys, spreads = object_keys(block)
        if keys:
            out.setdefault(name, (set(), set()))
            out[name][0].update(keys)
            out[name][1].update(spreads)
    return out


INSERT_ROW = re.compile(r"insertRowTx\(\s*tx\s*,\s*'([A-Z0-9_]+)'\s*,\s*[^,]+,\s*")
# The posting API names write-set arrays `rows:` and ledger arrays `lines:`; both carry columns
# for the named table, so both must be attributed.
TABLE_ROWS = re.compile(r"table:\s*'([A-Z0-9_]+)'\s*,\s*(?:rows|lines):\s*")
FACTORY_DECL = re.compile(r"(?:const|let)\s+(" + IDENT + r")\s*=\s*(?:async\s*)?\(")
FACTORY_FUNC = re.compile(r"function\s+(" + IDENT + r")\s*\(")
CALL = re.compile(r"\b(" + IDENT + r")\s*\(")
# `const key = keyOf(scope, vchNo)` -- a variable bound to a factory call. Without this the
# `...key` spread in every voucher header resolves to nothing, so CO_CODE/LC_CODE/CO_YEAR/
# CO_BOOK/VCH_NO read as unwritten on tables that plainly write them.
FACTORY_CALL_BIND = re.compile(r"(?:const|let)\s+(" + IDENT + r")\s*(?::[^=]*)?=\s*(?:await\s+)?(" + IDENT + r")\s*\(")
RAW_INSERT = re.compile(r'INSERT\s+INTO\s+"([A-Z0-9_]+)"\s*\(([^)]*)\)', re.I)
# `INSERT INTO "POINT_DATA"(${colSql}) VALUES (...)` -- the column list is computed at runtime.
DYNAMIC_INSERT = re.compile(r'INSERT\s+INTO\s+"([A-Z0-9_]+)"\s*\(([^)]*\$\{[^)]*)\)', re.I)
# `const TAG_PRINT_STAGING_COLUMNS = ['CO_CODE', ...] as const` interpolated into the column list.
STRING_ARRAY_CONST = re.compile(r"(?:const|let)\s+(" + IDENT + r")\s*(?::[^=]*)?=\s*\[")
INTERPOLATED = re.compile(r"\$\{\s*(" + IDENT + r")")
# `const cols = TAG_PRINT_STAGING_COLUMNS.map(q).join(',')` -- an alias of a column-name array.
ARRAY_ALIAS = re.compile(r"(?:const|let)\s+(" + IDENT + r")\s*(?::[^=]*)?=\s*(?:\[\s*[^\]]*?\]\s*)?(" + IDENT + r")\s*\.\s*map\(")
# `const slotColumns = REPORT_DATA_SLOT_COLUMNS;` -- a plain alias of a column-name array.
ARRAY_PLAIN_ALIAS = re.compile(r"(?:const|let)\s+(" + IDENT + r")\s*(?::[^=]*)?=\s*(" + IDENT + r")\s*;")
COL_ARRAY = re.compile(r"(?:const|let)\s+(?:cols|columns|colNames|fields)\s*(?::[^=]*)?=\s*\[")

# Tables written through a runtime column list (`Object.keys(data)`): the write is real, the
# column set is not statically knowable. Recorded separately so "never written" stays truthful.
DYNAMIC_TABLES: set[str] = set()


def nearest_def(defs: dict, name: str, at: int | None):
    """Definition of `name` closest before `at` -- several functions in one file legitimately
    declare `const details = ...`, and a flat map would attribute one scope's columns to another.
    """
    entries = defs.get(name)
    if not entries:
        return None
    if at is None:
        return entries[-1]
    before = [e for e in entries if e[0] <= at]
    return before[-1] if before else entries[0]


def resolve(name: str, variables: dict, seen: set[str] | None = None) -> set[str]:
    seen = seen or set()
    if name in seen or name not in variables:
        return set()
    seen.add(name)
    keys, spreads = variables[name]
    out = set(keys)
    for s in spreads:
        out |= resolve(s, variables, seen)
    return out


ASSIGN = re.compile(r"Object\.assign\(\s*(" + IDENT + r")\s*,\s*")


def apply_object_assign(body: str, variables: dict) -> None:
    """`Object.assign(header, { CASH_AMT: ... })` really does persist those columns."""
    for m in ASSIGN.finditer(body):
        name = m.group(1)
        tail = body[m.end() : m.end() + 20]
        if "{" not in tail:
            continue
        idx = m.end() + tail.index("{")
        block, _ = balanced(body, idx)
        keys, spreads = object_keys(block)
        if keys or spreads:
            variables.setdefault(name, (set(), set()))
            variables[name][0].update(keys)
            variables[name][1].update(spreads)


REGISTRY_TABLE = re.compile(r"(?m)^\s{2}([A-Z][A-Z0-9_]{2,}):\s*\[")
REGISTRY_COL = re.compile(r"col:\s*'([A-Z][A-Z0-9_]*)'")


def skip_params(body: str, open_paren: int) -> int:
    """Index just past a balanced parameter list.

    Required because parameter lists contain `= {}` defaults and inline type literals
    (`identity: { vchDate: Date }`), so naively searching for the next `{` finds a parameter,
    not the function body -- which silently zeroed KR_DATA/KR_DETL in the first audit pass.
    """
    _, end = balanced(body, open_paren, "(", ")")
    return end


def body_brace(body: str, after_params: int) -> int:
    """First `{` that opens the function body, skipping any return-type annotation."""
    i = after_params
    depth = 0
    while i < len(body) and i < after_params + 400:
        ch = body[i]
        if ch in "<([":
            depth += 1
        elif ch in ">)]":
            depth -= 1
        elif ch == "{" and depth <= 0:
            return i
        elif ch == ";":
            return -1
        i += 1
    return -1


def returned_objects(block: str, variables: dict) -> set[str]:
    """Columns from every `return` in a factory body, including `return rows.map(() => ({...}))`."""
    cols: set[str] = set()
    for m in re.finditer(r"\breturn\b", block):
        j = m.end()
        while j < len(block) and block[j] in " \t\n\r":
            j += 1
        if j >= len(block) or block[j] not in "{([":
            ident = re.match(r"(" + IDENT + r")", block[j : j + 60])
            if ident:
                cols |= resolve(ident.group(1), variables)
            # `return lines.map((l, idx) => ({ COL: ... }))` -- the object lives inside the
            # returned expression, so scan to the end of the statement for object literals.
            depth, k = 0, j
            while k < len(block):
                ch = block[k]
                if ch in "([{":
                    depth += 1
                elif ch in ")]}":
                    depth -= 1
                elif ch == ";" and depth <= 0:
                    break
                k += 1
            region = block[j:k]
            q = 0
            while True:
                q = region.find("{", q)
                if q < 0:
                    break
                obj, _ = balanced(region, q)
                keys, spreads = object_keys(obj)
                cols |= keys
                for sp in spreads:
                    cols |= resolve(sp, variables)
                q += 1
            continue
        opener = block[j]
        region, _ = balanced(block, j, opener, {"{": "}", "(": ")", "[": "]"}[opener])
        k = 0
        while True:
            k = region.find("{", k)
            if k < 0:
                break
            obj, _ = balanced(region, k)
            keys, spreads = object_keys(obj)
            cols |= keys
            for sp in spreads:
                cols |= resolve(sp, variables)
            k += 1
    return cols


def collect_factories(body: str, variables: dict) -> dict[str, set[str]]:
    """Row builders are usually local factories (`const header = (...) => ({ COL: ... })`).

    Without this, every voucher whose rows come from a factory reads as zero columns written.
    """
    factories: dict[str, set[str]] = {}
    for m in FACTORY_DECL.finditer(body):
        after = skip_params(body, m.end() - 1)
        arrow = body.find("=>", after)
        if arrow < 0 or arrow - after > 200:
            continue
        j = arrow + 2
        while j < len(body) and body[j] in " \t\n\r":
            j += 1
        if body[j : j + 1] == "(":
            brace = body.find("{", j)
            if brace >= 0:
                obj, _ = balanced(body, brace)
                keys, spreads = object_keys(obj)
                for sp in spreads:
                    keys |= resolve(sp, variables)
                factories.setdefault(m.group(1), set()).update(keys)
        elif body[j : j + 1] == "{":
            blk, _ = balanced(body, j)
            factories.setdefault(m.group(1), set()).update(returned_objects(blk, variables))
    for m in FACTORY_FUNC.finditer(body):
        after = skip_params(body, m.end() - 1)
        brace = body_brace(body, after)
        if brace < 0:
            continue
        blk, _ = balanced(body, brace)
        factories.setdefault(m.group(1), set()).update(returned_objects(blk, variables))
    return {k: v for k, v in factories.items() if v}


def bind_factory_calls(body: str, variables: dict, factories: dict[str, set[str]]) -> None:
    """Register variables whose value comes from a row factory, so their spreads resolve."""
    for m in FACTORY_CALL_BIND.finditer(body):
        name, callee = m.group(1), m.group(2)
        cols = factories.get(callee)
        if not cols:
            continue
        keys, spreads = variables.get(name, (set(), set()))
        variables[name] = (set(keys) | cols, set(spreads))


def expression_columns(expr: str, variables: dict, factories: dict[str, set[str]]) -> set[str]:
    """Columns contributed by a `rows:` expression: literals, factory calls and call-site overrides."""
    cols: set[str] = set()
    i = 0
    while True:
        i = expr.find("{", i)
        if i < 0:
            break
        block, _ = balanced(expr, i)
        keys, spreads = object_keys(block)
        cols |= keys
        for sp in spreads:
            cols |= resolve(sp, variables)
        i += 1
    for m in CALL.finditer(expr):
        cols |= factories.get(m.group(1), set())
    for m in re.finditer(r"\b(" + IDENT + r")\b", expr):
        cols |= resolve(m.group(1), variables)
    return cols


def string_array_constants(body: str) -> dict[str, set[str]]:
    """Named arrays of column-name literals, so a dynamic column list is still measurable."""
    out: dict[str, set[str]] = {}
    for m in STRING_ARRAY_CONST.finditer(body):
        block, _ = balanced(body, m.end() - 1, "[", "]")
        if not block:
            continue
        cols = {c for c in re.findall(r"['\"]([A-Z][A-Z0-9_]{1,})['\"]", block)}
        if cols:
            out.setdefault(m.group(1), set()).update(cols)
    return out


def nearest_column_array(body: str, before: int) -> set[str]:
    """Uppercase string literals from the closest preceding `const cols = [...]` declaration."""
    best = None
    for m in COL_ARRAY.finditer(body):
        if m.end() <= before:
            best = m
        else:
            break
    if best is None:
        return set()
    block, _ = balanced(body, best.end() - 1, "[", "]")
    return {c for c in re.findall(r"['\"]([A-Z][A-Z0-9_]{1,})['\"]", block)}


def cutover_migrated_columns(schema: dict[str, object]) -> dict[str, set[str]]:
    """Columns written by the cutover/migration path (`apps/api/integration/cutover.mjs`).

    That tool is the web's equivalent of the desktop's `UT_IMPORT` / `BtmSchm` full-table import, and it
    copies **every column present in both source and target**, derived from `information_schema` at run
    time and excluding only `tenant_id`/`row_id`. So for each table in its explicit `DEFAULT_TABLES` list,
    every physical column really is written.

    This matters because a large share of the residual "missing" columns are import-only: `OLD_ISU_NO`,
    `OLD_ITEM_ADJ`, `DHRN_LIC_NO`, `REC_DATE` and `REMARKS`, for instance, are assigned by `UT_IMPORT` and
    `BtmSchm` — never by a transaction form. Attributing them to a voucher writer would have been wrong;
    attributing them to the import path is exactly right.

    Only the declared table list is credited, so a table the tool does not migrate gains nothing.
    """
    tool = ROOT / "web/apps/api/integration/cutover.mjs"
    if not tool.is_file():
        return {}
    body = tool.read_text(encoding="utf-8", errors="ignore")
    match = re.search(r"DEFAULT_TABLES\s*=\s*\[(.*?)\]", body, re.S)
    if not match:
        return {}
    out: dict[str, set[str]] = {}
    for table in re.findall(r"'([A-Z_0-9]+)'", match.group(1)):
        entry = schema.get(table)
        if not isinstance(entry, dict):
            continue
        cols = {
            c["col"] for c in (entry.get("columns") or []) if isinstance(c, dict) and "col" in c
        }
        if cols:
            out[table] = cols
    return out


#: Columns `postVoucherTx` stamps on every row of a voucher write set (see `applyProvenance`).
PROVENANCE_COLUMNS = ("MAIN_USER", "ADD_USER", "DATA_TRFR", "OLD_VCH_NO", "NEW_VCH_NO")


def voucher_write_set_tables() -> set[str]:
    """Tables written through a `postVoucherTx` write set.

    Only these receive provenance stamping at runtime, so only these may be credited with those columns.
    Detected from the `writes:`/`table: 'X'` declarations the write sets are built from — the same literals
    the rest of this analyzer already reads — so a table written by a bare `insertRowTx` outside a voucher
    is NOT credited.
    """
    tables: set[str] = set()
    for path in sorted(WEB_SRC.rglob("*.ts")):
        body = strip_comments(path.read_text(encoding="utf-8", errors="ignore"))
        if "postVoucherTx" not in body:
            continue
        for match in re.finditer(r"table:\s*'([A-Z_0-9]+)'", body):
            tables.add(match.group(1))
    return tables


def provenance_columns(schema: dict[str, object]) -> dict[str, set[str]]:
    """Provenance columns, credited only where the table is BOTH voucher-posted and actually has them.

    This is a runtime behaviour a static parser cannot otherwise see: `applyProvenance` fills these on
    every write-set row. The behaviour itself is pinned by `provenance.test.ts` plus a database assertion
    in `sales.lifecycle.db.test.ts`, so this credit reflects a proven write rather than a declaration.
    """
    out: dict[str, set[str]] = {}
    posted = voucher_write_set_tables()
    for table in posted:
        entry = schema.get(table)
        if not isinstance(entry, dict):
            continue
        have = {
            c["col"] for c in (entry.get("columns") or []) if isinstance(c, dict) and "col" in c
        }
        credited = have.intersection(PROVENANCE_COLUMNS)
        if credited:
            out[table] = credited
    return out


def declared_column_set_columns(schema_tables: set[str]) -> dict[str, set[str]]:
    """Columns from `const <TABLE>_COLUMNS = [...] as const` declarations.

    Several writers build their INSERT from an explicitly declared column list rather than an inline
    object literal — `FINE_DATA_COLUMNS`, `LEDR_AC_DATA_COLUMNS`, `TAG_STOCK_COLUMNS` and friends. The
    convention is deliberate: it makes the written set auditable instead of hiding behind an
    `Object.keys(data)` spread, which is exactly how `TAG_STOCK` came to read 0% while being written on
    every tag creation.

    The constant name must resolve to a REAL table in the restored schema, so an unrelated array cannot
    invent a table, and only column names that exist on that table are credited.
    """
    out: dict[str, set[str]] = {}
    for path in sorted(WEB_SRC.rglob("*.ts")):
        body = strip_comments(path.read_text(encoding="utf-8", errors="ignore"))
        for match in re.finditer(
            r"const\s+([A-Z][A-Z0-9_]*)_COLUMNS\s*(?::[^=]+)?=\s*\[(.*?)\]", body, re.S
        ):
            table = match.group(1)
            if table not in schema_tables:
                continue
            cols = set(re.findall(r"'([A-Z_0-9]+)'", match.group(2)))
            if cols:
                out.setdefault(table, set()).update(cols)
    return out


def clone_spec_columns() -> dict[str, set[str]]:
    """Columns written by the company-clone specs in `masters/companyClone.ts`.

    That module performs `INSERT INTO "T"(tenant_id,"CO_CODE",<cols>) SELECT $1,$2,<cols> FROM "T" …`
    where `<cols>` is joined from the spec's own `columns` array. So every listed column really is
    written, plus `CO_CODE`. The idiom was previously invisible to this analyzer, which under-reported
    provisioning tables (`BOOK_DETL` read 0% while the clone was writing all 14 of its columns).
    """
    path = WEB_SRC / "modules/masters/companyClone.ts"
    out: dict[str, set[str]] = {}
    if not path.is_file():
        return out
    body = strip_comments(path.read_text(encoding="utf-8", errors="ignore"))
    # Each spec is `{ table: 'X', … columns: [ 'A', 'B', … ] }`; take the column list that follows a table.
    for match in re.finditer(
        r"table:\s*'([A-Z_0-9]+)'.*?columns:\s*\[(.*?)\]", body, re.S
    ):
        table = match.group(1)
        cols = set(re.findall(r"'([A-Z_0-9]+)'", match.group(2)))
        if not cols:
            continue
        cols.add("CO_CODE")  # supplied by the INSERT itself
        out.setdefault(table, set()).update(cols)
    return out


def master_config_columns() -> dict[str, set[str]]:
    """Columns from MasterConfig declarations (`table: 'BAL_GR'` plus its formFields/key columns)."""
    path = WEB_SRC / "modules/masters/configs.ts"
    if not path.exists():
        return {}
    body = path.read_text(encoding="utf-8", errors="ignore")
    out: dict[str, set[str]] = {}
    marks = [m.start() for m in re.finditer(r":\s*MasterConfig\s*=\s*\{", body)]
    marks.append(len(body))
    for i in range(len(marks) - 1):
        block = body[marks[i] : marks[i + 1]]
        table = re.search(r"table:\s*'([A-Z0-9_]+)'", block)
        if not table:
            continue
        cols = {m.group(1) for m in re.finditer(r"col:\s*'([A-Z][A-Z0-9_]*)'", block)}
        for key in ("keyColumns", "requiredColumns"):
            arr = re.search(key + r"\s*:\s*\[([^\]]*)\]", block)
            if arr:
                cols |= {c for c in re.findall(r"'([A-Z][A-Z0-9_]{1,})'", arr.group(1))}
        if cols:
            out.setdefault(table.group(1), set()).update(cols)
    return out


def registry_columns() -> dict[str, set[str]]:
    """Generic master CRUD writes whatever the field registry exposes (master.service.ts builds the
    column list from the request body at runtime), so the registry IS the persisted column set."""
    out: dict[str, set[str]] = {}
    path = WEB_SRC / "modules/masters/generated-formfields.ts"
    body = path.read_text(encoding="utf-8", errors="ignore") if path.exists() else ""
    blocks = list(REGISTRY_TABLE.finditer(body))
    for i, m in enumerate(blocks):
        end = blocks[i + 1].start() if i + 1 < len(blocks) else len(body)
        out.setdefault(m.group(1), set()).update(REGISTRY_COL.findall(body[m.start() : end]))
    return out


WHITELIST_COL = re.compile(r"key:\s*'([A-Z][A-Z0-9_]*)'")


def settings_columns() -> set[str]:
    """settings.ts writes CO_SET with a dynamic UPDATE built from its whitelist registry."""
    path = WEB_SRC / "modules/settings/settings.ts"
    body = path.read_text(encoding="utf-8", errors="ignore") if path.exists() else ""
    return set(WHITELIST_COL.findall(body))


# `assertPeriodOpen(tx, { writes: [{ table: 'BAR_DATA', rows: [{ CO_CODE, VCH_DATE }] }] })` is a
# period-lock PROBE, not a write. Counting it credited columns that are never persisted.
PROBE_CALLS = ("assertPeriodOpen(", "assertFiscalDateTx(", "assertPeriodOpenTx(")

# A trailing `// desktop citation` comment separates a comma from the next key, which broke the
# `{`/`,` anchor and silently dropped every column that followed a commented line.
LINE_COMMENT = re.compile(r"(?m)(?:(?<=\s)|^)//[^\n]*")


def strip_comments(body: str) -> str:
    return LINE_COMMENT.sub("", body)


def mask_probes(body: str) -> str:
    """Blank out probe call arguments so their table/rows shapes are not read as writes."""
    out = body
    for name in PROBE_CALLS:
        idx = 0
        while True:
            idx = out.find(name, idx)
            if idx < 0:
                break
            open_paren = idx + len(name) - 1
            block, end = balanced(out, open_paren, "(", ")")
            if not block:
                idx = open_paren + 1
                continue
            out = out[: open_paren + 1] + (" " * (len(block) - 2)) + out[end - 1 :]
            idx = end
    return out


def global_factories() -> dict[str, set[str]]:
    """Row factories exported from other modules (`voucherKey`, shared row builders).

    Resolved local-first at each call site; this index only covers names a file does not define
    itself, so a shared helper's columns are not lost just because it lives elsewhere.
    """
    index: dict[str, set[str]] = {}
    for path in sorted(WEB_SRC.rglob("*.ts")):
        body = strip_comments(path.read_text(encoding="utf-8", errors="ignore"))
        variables = collect_variables(body)
        for name, cols in collect_factories(body, variables).items():
            index.setdefault(name, set()).update(cols)
    return index


def web_columns_by_table() -> dict[str, set[str]]:
    result: dict[str, set[str]] = {}
    shared = global_factories()
    shared_arrays: dict[str, set[str]] = {}
    for _path in sorted(WEB_SRC.rglob("*.ts")):
        for _name, _cols in string_array_constants(
            strip_comments(_path.read_text(encoding="utf-8", errors="ignore"))
        ).items():
            shared_arrays.setdefault(_name, set()).update(_cols)
    for path in sorted(WEB_SRC.rglob("*.ts")):
        body = mask_probes(strip_comments(path.read_text(encoding="utf-8", errors="ignore")))
        variables = collect_variables(body)
        apply_object_assign(body, variables)
        factories = collect_factories(body, variables)
        for _name, _cols in shared.items():
            factories.setdefault(_name, _cols)
        bind_factory_calls(body, variables, factories)
        # `...voucherKey(scope, no)` spreads a factory CALL, not a variable. Registering each
        # factory name as a resolvable variable makes every spread site resolve it.
        for _name, _cols in factories.items():
            _keys, _spreads = variables.get(_name, (set(), set()))
            variables[_name] = (set(_keys) | _cols, set(_spreads))

        for m in INSERT_ROW.finditer(body):
            table = m.group(1)
            tail = body[m.end() : m.end() + 60]
            if tail.lstrip().startswith("{"):
                idx = m.end() + tail.index("{")
                block, _ = balanced(body, idx)
                keys, spreads = object_keys(block)
                cols = set(keys)
                for s in spreads:
                    cols |= resolve(s, variables)
            else:
                expr, _ = balanced(body, m.end() - 1, "(", ")") if body[m.end() - 1] == "(" else (tail, 0)
                cols = expression_columns(expr[:400], variables, factories)
            result.setdefault(table, set()).update(cols)

        for m in TABLE_ROWS.finditer(body):
            table = m.group(1)
            tail = body[m.end() :]
            lead = len(tail) - len(tail.lstrip())
            pos = m.end() + lead
            if body[pos : pos + 1] == "[":
                expr, _ = balanced(body, pos, "[", "]")
            else:
                expr = body[pos : pos + 400]
            result.setdefault(table, set()).update(expression_columns(expr, variables, factories))

        arrays = string_array_constants(body)
        arrays.update({k: v for k, v in shared_arrays.items() if k not in arrays})
        # Resolve alias chains (plain first, then .map()) so an interpolated name reaches its array.
        for _pattern in (ARRAY_PLAIN_ALIAS, ARRAY_ALIAS, ARRAY_PLAIN_ALIAS, ARRAY_ALIAS):
            for _alias in _pattern.finditer(body):
                _src = arrays.get(_alias.group(2))
                if _src:
                    arrays.setdefault(_alias.group(1), set()).update(_src)
        for m in DYNAMIC_INSERT.finditer(body):
            table = m.group(1)
            for ref in INTERPOLATED.finditer(m.group(2) if m.lastindex and m.lastindex >= 2 else ""):
                result.setdefault(table, set()).update(arrays.get(ref.group(1), set()))
            # Mark the table as written even when the column list is computed from a caller
            # object (`Object.keys(data)`); the write is real, only its columns are unmeasurable.
            DYNAMIC_TABLES.add(table)
            result.setdefault(table, set()).update(nearest_column_array(body, m.start()))

        for m in RAW_INSERT.finditer(body):
            table = m.group(1)
            cols = {c.strip().strip('"') for c in m.group(2).split(",")}
            cols = {c for c in cols if re.fullmatch(r"[A-Z][A-Z0-9_]{1,}", c)}
            result.setdefault(table, set()).update(cols)

    for table, cols in registry_columns().items():
        result.setdefault(table, set()).update(cols)
    for table, cols in clone_spec_columns().items():
        result.setdefault(table, set()).update(cols)
    _schema_tables = set(
        json.loads(SCHEMA.read_text(encoding="utf-8", errors="ignore")).get("tables", {})
    )
    for table, cols in declared_column_set_columns(_schema_tables).items():
        result.setdefault(table, set()).update(cols)
    _schema = json.loads(SCHEMA.read_text(encoding="utf-8", errors="ignore")).get("tables", {})
    for table, cols in provenance_columns(_schema).items():
        result.setdefault(table, set()).update(cols)
    for table, cols in cutover_migrated_columns(_schema).items():
        result.setdefault(table, set()).update(cols)

    for table, cols in master_config_columns().items():
        result.setdefault(table, set()).update(cols)
    result.setdefault("CO_SET", set()).update(settings_columns())
    return result


def desktop_columns_by_table() -> tuple[dict[str, set[str]], dict[str, dict[str, set[str]]]]:
    per_table: dict[str, set[str]] = {}
    per_form: dict[str, dict[str, set[str]]] = {}
    for path in sorted(LOGIC.glob("*.logic.json")):
        data = json.loads(path.read_text(encoding="utf-8", errors="ignore"))
        form = data.get("form") or path.name.split(".")[0]
        writes = data.get("writes") or {}
        if not isinstance(writes, dict):
            continue
        for kind in ("INSERT", "UPDATE"):
            block = writes.get(kind) or {}
            if not isinstance(block, dict):
                continue
            for table, cols in block.items():
                if not isinstance(cols, list):
                    continue
                clean = {c for c in cols if isinstance(c, str) and re.fullmatch(r"[A-Z][A-Z0-9_]+", c)}
                per_table.setdefault(table.upper(), set()).update(clean)
                per_form.setdefault(form, {}).setdefault(table.upper(), set()).update(clean)
    return per_table, per_form


def compute() -> dict:
    """Parsed desktop/web write sets. Importable so the parity generator reuses one implementation."""
    desk_tables, desk_forms = desktop_columns_by_table()
    web_tables = web_columns_by_table()
    schema = json.loads(SCHEMA.read_text(encoding="utf-8", errors="ignore")).get("tables", {})

    table_rows = []
    for table in sorted(desk_tables):
        desk = desk_tables[table]
        web = web_tables.get(table, set())
        physical = {c["col"] for c in (schema.get(table, {}).get("columns") or [])}
        if physical:
            desk = {c for c in desk if c in physical}
            web = {c for c in web if c in physical}
        covered = sorted(desk & web)
        missing = sorted(desk - web)
        table_rows.append(
            {
                "table": table,
                "desktopWrittenColumns": len(desk),
                "webWrittenColumns": len(web & desk),
                "coveragePct": round(len(desk & web) * 100 / len(desk), 1) if desk else None,
                "missingColumnCount": len(missing),
                "missingColumns": missing[:40],
                "webWritesTableAtAll": bool(web) or table in DYNAMIC_TABLES,
            "columnListDynamic": table in DYNAMIC_TABLES,
            }
        )

    form_rows = []
    for form, tables in sorted(desk_forms.items()):
        desk_total = sum(len(c) for c in tables.values())
        web_total = 0
        per = {}
        for table, cols in tables.items():
            physical = {c["col"] for c in (schema.get(table, {}).get("columns") or [])}
            d = {c for c in cols if not physical or c in physical}
            w = web_tables.get(table, set())
            hit = len(d & w)
            web_total += hit
            per[table] = {"desktop": len(d), "web": hit}
        form_rows.append(
            {
                "form": form,
                "desktopWrittenColumns": desk_total,
                "webWrittenColumns": web_total,
                "coveragePct": round(web_total * 100 / desk_total, 1) if desk_total else None,
                "perTable": per,
            }
        )
    written_tables = [r for r in table_rows if r["webWritesTableAtAll"]]
    summary = {
        "desktopTablesWritten": len(table_rows),
        "webWritesAtAll": len(written_tables),
        "tablesNeverWrittenByWeb": len(table_rows) - len(written_tables),
        "totalDesktopWrittenColumns": sum(r["desktopWrittenColumns"] for r in table_rows),
        "totalWebWrittenColumns": sum(r["webWrittenColumns"] for r in table_rows),
        "overallColumnCoveragePct": round(
            sum(r["webWrittenColumns"] for r in table_rows)
            * 100
            / max(1, sum(r["desktopWrittenColumns"] for r in table_rows)),
            1,
        ),
        "avgCoverageOfWrittenTablesPct": round(
            sum(r["coveragePct"] or 0 for r in written_tables) / max(1, len(written_tables)), 1
        ),
        "worstCoveredWrittenTables": sorted(
            (
                {"table": r["table"], "pct": r["coveragePct"], "missing": r["missingColumnCount"]}
                for r in written_tables
                if r["desktopWrittenColumns"] >= 10
            ),
            key=lambda r: (r["pct"] or 0),
        )[:20],
        "largestUnwrittenTables": sorted(
            (
                {"table": r["table"], "desktopColumns": r["desktopWrittenColumns"]}
                for r in table_rows
                if not r["webWritesTableAtAll"]
            ),
            key=lambda r: -r["desktopColumns"],
        )[:20],
    }
    return {"tables": table_rows, "forms": form_rows, "summary": summary}


def main() -> None:
    data = compute()
    out = ROOT / "project-memory/parity"
    (out / "DEEP-COLUMN-AUDIT.json").write_text(
        json.dumps({"tables": data["tables"], "forms": data["forms"]}, indent=2) + "\n"
    )
    (out / "DEEP-COLUMN-AUDIT-SUMMARY.json").write_text(json.dumps(data["summary"], indent=2) + "\n")
    print(json.dumps(data["summary"], indent=2))


if __name__ == "__main__":
    main()
