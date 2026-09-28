"""Self-test for the depth analyzer's write-set parser.

Every idiom here was a real blind spot that silently under-reported column coverage:
the first audit pass read 32.7% and only reached 52.2% once each was handled. A gate built on
an under-reporting parser is worse than no gate, so these fixtures are mandatory.

Run: python3 project-memory/parity/test_depth_metrics.py
"""

from __future__ import annotations

import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))

import deep_column_audit as dca  # noqa: E402


def columns(body: str, table: str) -> set[str]:
    body = dca.mask_probes(dca.strip_comments(body))
    variables = dca.collect_variables(body)
    dca.apply_object_assign(body, variables)
    factories = dca.collect_factories(body, variables)
    dca.bind_factory_calls(body, variables, factories)
    for _n, _c in factories.items():
        _k, _s = variables.get(_n, (set(), set()))
        variables[_n] = (set(_k) | _c, set(_s))
    found: set[str] = set()
    for m in dca.TABLE_ROWS.finditer(body):
        if m.group(1) != table:
            continue
        tail = body[m.end() :]
        pos = m.end() + len(tail) - len(tail.lstrip())
        expr = dca.balanced(body, pos, "[", "]")[0] if body[pos : pos + 1] == "[" else body[pos : pos + 400]
        found |= dca.expression_columns(expr, variables, factories)
    for m in dca.INSERT_ROW.finditer(body):
        if m.group(1) != table:
            continue
        expr = body[m.end() : m.end() + 400]
        found |= dca.expression_columns(expr, variables, factories)
    for m in dca.RAW_INSERT.finditer(body):
        if m.group(1) == table:
            found |= {c.strip().strip('"') for c in m.group(2).split(",")}
    arrays = dca.string_array_constants(body)
    for alias in dca.ARRAY_ALIAS.finditer(body):
        src = arrays.get(alias.group(2))
        if src:
            arrays.setdefault(alias.group(1), set()).update(src)
    for m in dca.DYNAMIC_INSERT.finditer(body):
        if m.group(1) == table:
            dca.DYNAMIC_TABLES.add(table)
            found |= dca.nearest_column_array(body, m.start())
            for ref in dca.INTERPOLATED.finditer(m.group(2) or ''):
                found |= arrays.get(ref.group(1), set())
    return {c for c in found if c.isupper()}


CASES: list[tuple[str, str, str, set[str]]] = [
    (
        # `const rows = []; rows.push({ … })` — an accumulating builder, as `batchReceipt.ts` uses for
        # CASH_DATA.
        #
        # HONEST NOTE ON THIS CASE: disabling the dedicated push idiom does NOT make this fixture fail,
        # because the generic `const NAME = …` nearby-brace fallback also matches a small synthetic input.
        # The evidence that the idiom is load-bearing is the real codebase, where enabling it moved
        # coverage 97.1% -> 97.2% (five columns that no other mechanism reached). The fixture's value here
        # is regression protection for the shape, not isolation of the mechanism.
        "array-push row builder",
        """
const cashRows: Record<string, unknown>[] = [];
const total = computeRunningTotal(rawLines, settlementAccounts, roundingPolicy, taxPolicy);
const ledger = buildLedgerLines(rawLines, base, kasarAccount, partyAccount, clearedAmount);
assertBalanced(ledger);
cashRows.push({
  SR_NO: 1,
  REC_AMT: amount,
  BANK_CHARGES: String(bankCharges),
  MOB_ENTRY_SAVE: 'N',
});
await postVoucherTx(tx, tenantId, { writes: [{ table: 'CASH_DATA', rows: cashRows }] });
""",
        "CASH_DATA",
        {"SR_NO", "REC_AMT", "BANK_CHARGES", "MOB_ENTRY_SAVE"},
    ),
    (
        # An arrow-returned object behind a DESTRUCTURED parameter list. The bare `({` heuristic used to
        # balance the parameter pattern and report ITS names as the row's columns, so a builder written
        # this way contributed nothing — REP_DETL sat at 85% with eleven real writes invisible.
        "destructured-parameter map builder",
        """
const detailRows = prepared.map(({ input: line, item, totals: lineTotals }, index) => ({
  SR_NO: index + 1,
  HM_ID: txt(line.huid, 10),
  ITM_COLOR: txt(line.itmColor, 15),
  MAIN_USER: mainUser,
}));
await postVoucherTx(tx, tenantId, { writes: [{ table: 'REP_DETL', rows: detailRows }] });
""",
        "REP_DETL",
        {"SR_NO", "HM_ID", "ITM_COLOR", "MAIN_USER"},
    ),
    (
        "inline object literal",
        """const w = [{ table: 'SL_DATA', rows: [{ CO_CODE: a, VCH_NO: b }] }];""",
        "SL_DATA",
        {"CO_CODE", "VCH_NO"},
    ),
    (
        "variable reference with spread",
        """const key = { CO_CODE: c, LC_CODE: l };
           const header = { ...key, VCH_NO: n, TOT_AMT: t };
           const w = [{ table: 'SL_DATA', rows: [header] }];""",
        "SL_DATA",
        {"CO_CODE", "LC_CODE", "VCH_NO", "TOT_AMT"},
    ),
    (
        "Object.assign settlement fields",
        """const header = { VCH_NO: n };
           Object.assign(header, { CASH_AMT: x, CARD_AMT: y, KASAR_AMT: z });
           const w = [{ table: 'SL_DATA', rows: [header] }];""",
        "SL_DATA",
        {"VCH_NO", "CASH_AMT", "CARD_AMT", "KASAR_AMT"},
    ),
    (
        "arrow factory returning an object",
        """const build = (a: string) => ({ VCH_NO: a, FINE_WT: 1 });
           const w = [{ table: 'KR_DATA', rows: [build(x)] }];""",
        "KR_DATA",
        {"VCH_NO", "FINE_WT"},
    ),
    (
        "function factory whose params contain a default {} and a type literal",
        """function header(
             key: VoucherKey,
             identity: { vchDate: Date; mainUser?: string },
             extra: Record<string, unknown> = {},
           ) {
             return { ...key, VCH_DATE: identity.vchDate, PARTY_FINE: f, ...extra };
           }
           const key = { CO_CODE: c };
           const w = [{ table: 'KR_DATA', rows: [header(key, id, { HD_VCH_NO: h })] }];""",
        "KR_DATA",
        {"CO_CODE", "VCH_DATE", "PARTY_FINE", "HD_VCH_NO"},
    ),
    (
        "function factory returning lines.map(() => ({...}))",
        """function detlRows(lines: L[]) {
             return lines.map((l, idx) => ({ SR_NO: idx + 1, IT_CODE: l.itCode, ITM_GWT: l.gwt }));
           }
           const w = [{ table: 'KR_DETL', rows: detlRows(lines) }];""",
        "KR_DETL",
        {"SR_NO", "IT_CODE", "ITM_GWT"},
    ),
    (
        "insertRowTx with a variable row",
        """const row = { TAG_NO: t, MAIN_GWT: g };
           await insertRowTx(tx, 'BAR_DETL', tenantId, row);""",
        "BAR_DETL",
        {"TAG_NO", "MAIN_GWT"},
    ),
    (
        "keys followed by trailing line comments",
        """const row = {
             TAG_NO: t, // mSG[L,1] :9301
             MAIN_MRP: m, // mSG[i,48] :11061
             KR_COST: k, // mSG[L,45] :9344
           };
           const w = [{ table: 'BAR_DETL', rows: [row] }];""",
        "BAR_DETL",
        {"TAG_NO", "MAIN_MRP", "KR_COST"},
    ),
    (
        "spread of a factory CALL",
        """const voucherKey = (s: Scope, no: string) => ({ CO_CODE: s.co, LC_CODE: s.lc, VCH_NO: no });
           await insertRowTx(tx, 'BAR_DATA', tenantId, {
             ...voucherKey(scope, no),
             HD_VCH_NO: h,
           });""",
        "BAR_DATA",
        {"CO_CODE", "LC_CODE", "VCH_NO", "HD_VCH_NO"},
    ),
    (
        "variable bound to a factory call, then spread",
        """function keyOf(s: Scope, vchNo: number): VoucherKey {
             return { CO_CODE: s.coCode, LC_CODE: s.lcCode, CO_YEAR: s.coYear, VCH_NO: vchNo };
           }
           const key = keyOf(scope, no);
           const header = { ...key, TOT_AMT: t };
           const w = [{ table: 'SL_DATA', rows: [header] }];""",
        "SL_DATA",
        {"CO_CODE", "LC_CODE", "CO_YEAR", "VCH_NO", "TOT_AMT"},
    ),
    (
        "dynamic INSERT with a literal column array",
        """const cols = ['CO_CODE', 'MEMB_CODE', 'POINT_AMT'];
           const colSql = cols.map((c) => `"${c}"`).join(',');
           await tx.$executeRawUnsafe(`INSERT INTO "POINT_DATA"(${colSql}) VALUES (${ph})`, ...vals);""",
        "POINT_DATA",
        {"CO_CODE", "MEMB_CODE", "POINT_AMT"},
    ),
    (
        "INSERT..SELECT with an interpolated column-array constant",
        """const TAG_PRINT_STAGING_COLUMNS = ['CO_CODE', 'TAG_NO', 'ITM_MRP'] as const;
           const cols = TAG_PRINT_STAGING_COLUMNS.map(q).join(',');
           await tx.$executeRawUnsafe(
             `INSERT INTO "TAG_PRINT_DATA"(tenant_id,${cols}) SELECT $1,${cols} FROM "BAR_DETL"`,
           );""",
        "TAG_PRINT_DATA",
        {"CO_CODE", "TAG_NO", "ITM_MRP"},
    ),
    (
        "raw INSERT INTO",
        """await tx.$executeRawUnsafe(`INSERT INTO "TAX_DATA"("CO_CODE","TAX_AMT") VALUES ($1,$2)`);""",
        "TAX_DATA",
        {"CO_CODE", "TAX_AMT"},
    ),
]


def run_cases(verbose: bool = False) -> list[str]:
    """Failure descriptions; empty means the parser handles every known write idiom."""
    failures: list[str] = []
    for name, body, table, expected in CASES:
        found = columns(body, table)
        missing = expected - found
        if missing:
            failures.append(f"{name}: missing {sorted(missing)}")
            if verbose:
                print(f"FAIL  {name}: missing {sorted(missing)} (found {sorted(found)})")
        elif verbose:
            print(f"ok    {name}: {len(expected)} columns detected")

    configs = dca.master_config_columns()
    if not configs:
        failures.append("master config registry (configs.ts) produced no columns")
    elif verbose:
        print(f"ok    master config registry: {len(configs)} tables")

    dynamic_body = """await tx.$executeRawUnsafe(`INSERT INTO "TAG_STOCK"(${colSql}) VALUES ($1,${ph})`);"""
    if not list(dca.DYNAMIC_INSERT.finditer(dynamic_body)):
        failures.append("dynamic INSERT with an unmeasurable column list is not detected as a write")
    elif verbose:
        print("ok    dynamic INSERT marks the table as written even when columns are unmeasurable")

    probe_body = """await assertPeriodOpen(tx, {
        writes: [{ table: 'BAR_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: d }] }],
        ledger: { table: 'AC_DATA', lines: [] },
      });"""
    leaked = columns(probe_body, "BAR_DATA")
    if leaked:
        failures.append(f"period-lock probe wrongly credited columns: {sorted(leaked)}")
    elif verbose:
        print("ok    period-lock probe credits no columns (it is not a write)")

    registry = dca.registry_columns()
    if not registry:
        failures.append("master field registry produced no columns")
    elif verbose:
        print(f"ok    master field registry: {len(registry)} tables")

    settings = dca.settings_columns()
    if len(settings) < 20:
        failures.append(f"settings whitelist produced only {len(settings)} columns")
    elif verbose:
        print(f"ok    settings whitelist: {len(settings)} columns")
    return failures


def main() -> int:
    failures = run_cases(verbose=True)
    print("DEPTH_PARSER_OK" if not failures else f"DEPTH_PARSER_FAILURES {failures}")
    return 1 if failures else 0


if __name__ == "__main__":
    raise SystemExit(main())
