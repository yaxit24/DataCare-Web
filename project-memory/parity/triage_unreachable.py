#!/usr/bin/env python3
"""Classify every API input field no screen can supply, so the P3 target is auditable.

Not all 177 unreachable fields are defects, and treating them as one number would either
overstate the work or invite quietly redefining it. Three classes, with different obligations:

  operator      a field the operator should be able to enter -> BUILD the control
  serverDerived computed or resolved server-side; a request must NOT carry it -> document it
  internal      request/audit/device plumbing that was never operator input -> move out of *Input

The `serverDerived` class matters most for correctness, not convenience. Posting-account fields
(`*Ac`) are the clearest case: WP-02D made account resolution fail closed against configured
`BOOK_DETL` slots precisely so a request could not name its own ledger. Exposing them as operator
inputs would undo that, so they are classified server-resolved and deliberately left unreachable.

Run:  python3 triage_unreachable.py > ../../web/parity/unreachable-triage.json
"""
from __future__ import annotations

import json
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))

# Interfaces that are not operator input at all.
INTERNAL_INTERFACES = {
    "RequestLogInput": "request-scoped logging metadata written by the server",
    "FieldAuditInput": "edit-audit metadata derived from the session and the persisted row",
    "ComputedLine": "a COMPUTED line, by name; its fields are outputs of the calculator",
    "ScaleReadingInput": "supplied by the weighing device over WebSerial, not typed",
    # The Rojmel (day book) is a PROJECTION of a voucher, not something an operator types. These
    # interfaces are the shapes the shared builder accepts, and each module constructs them from its
    # own posted voucher (e.g. karigar.ts:1212 builds KarigarRojmelLine[] itself). A request never
    # carries them, so their unreachability from a screen is correct by design.
    "RojmelLine": "day-book projection row built by the posting module from the voucher",
    "KarigarRojmelLine": "day-book projection row built by karigar.ts from the voucher",
    "FineJvRojmelLine": "day-book projection row built by the fine-JV writer from the voucher",
    "SchemeAdjRojmelLine": "day-book projection row built by the scheme writer from the voucher",
    # A pure calculator input, not a request contract: `settleMoneyMetal` is called with values the
    # module has already derived (rateCut.ts:957), never with values from a request body.
    "SettlementInput": "input to the pure money/metal settlement calculator, derived by the caller",
}

# Fields that are server-derived wherever they appear.
SERVER_DERIVED_FIELDS = {
    "tenantId": "resolved from the authenticated session; a request may never assert it",
    "companyCode": "resolved from the business scope",
    "locationCode": "resolved from the business scope",
    "loginCoCode": "the session's company; a request asserting it could act on another company",
    "deleteUser": "taken from the session so a delete cannot be attributed to someone else",
    "deleteLog": "the reversal audit row is built by the posting engine, not supplied",
    "headerTable": "chosen by the module from the voucher's book classification",
    "lineNo": "assigned by the writer in row order",
    "hdVchNo": "hidden voucher number, allocated by nextHiddenVoucherNoTx",
    "accountGstType": "read from persisted AC_MAST; never authoritative from a request (WP-02)",
    "irType": "resolved from MFG_MAST or the stage default",
    "bookName": "MAIN_BOOK of the configured book",
    "mainName": "window/tile chrome label, not voucher data",
    "postStock": "derived from the stage's STK_ISU flag",
}

# Posting-account slots. Fail-closed resolution against configured BOOK_DETL is deliberate.
ACCOUNT_SUFFIX = "Ac"
ACCOUNT_EXEMPT = {"isuAcCode", "isuAcName"}  # source-voucher references, not posting slots


def classify(interface: str, field: str) -> tuple[str, str]:
    if interface in INTERNAL_INTERFACES:
        return "internal", INTERNAL_INTERFACES[interface]
    if field in SERVER_DERIVED_FIELDS:
        return "serverDerived", SERVER_DERIVED_FIELDS[field]
    if field.endswith(ACCOUNT_SUFFIX) and field not in ACCOUNT_EXEMPT:
        return (
            "serverDerived",
            "posting-account slot; resolved fail-closed from configured BOOK_DETL (WP-02D) so a "
            "request cannot name its own ledger",
        )
    if interface == "IrnItemInput":
        return "serverDerived", "e-invoice item lines are derived from the sale's own lines"
    if interface == "ProfitLineInput":
        return "serverDerived", "profit report rows are computed from the persisted bill"
    return "operator", ""


def main() -> int:
    with open(os.path.join(HERE, "GAP-MANIFEST.json"), encoding="utf-8") as fh:
        manifest = json.load(fh)

    rows = []
    counts = {"operator": 0, "serverDerived": 0, "internal": 0}
    for entry in manifest["interfaces"]:
        for field in entry["apiOnlyFields"]:
            cls, reason = classify(entry["interface"], field)
            counts[cls] += 1
            rows.append(
                {
                    "interface": entry["interface"],
                    "file": entry["file"],
                    "module": entry["module"],
                    "field": field,
                    "class": cls,
                    "reason": reason,
                }
            )

    by_interface: dict[str, dict] = {}
    for row in rows:
        b = by_interface.setdefault(row["interface"], {"module": row["module"], "operator": [], "other": []})
        (b["operator"] if row["class"] == "operator" else b["other"]).append(row["field"])

    operator_backlog = sorted(
        ({"interface": k, "module": v["module"], "fields": v["operator"]} for k, v in by_interface.items() if v["operator"]),
        key=lambda r: -len(r["fields"]),
    )

    json.dump(
        {
            "kind": "unreachable-field-triage",
            "note": (
                "Classifies the fields gap_manifest.py reports as unreachable from any screen. "
                "`operator` is the only class that represents work; the other two are fields a "
                "request should not carry, and their unreachability is correct. The P3 ceiling is "
                "therefore serverDerived + internal, not zero."
            ),
            "totals": {
                "unreachable": len(rows),
                **counts,
                "correctlyUnreachable": counts["serverDerived"] + counts["internal"],
            },
            "operatorBacklog": operator_backlog,
            "fields": rows,
        },
        sys.stdout,
        indent=1,
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
