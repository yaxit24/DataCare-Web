"""Generate per-form Phase E contract drafts from the measured audits.

The plan requires every desktop calculation and validation to resolve to a web implementation or an
explicit waiver. That is a review activity, so this writes the review artifact: one Markdown contract
per form combining

  • Validations — every catalogued rule with its EXACT desktop wording and whether that wording is
    present in the web source (from validation_audit.py);
  • Computed fields — every grid cell the desktop calculates, resolved to a named control and, where
    determinable, its persisted column and whether the web writes it (from calc_audit.py).

Drafts are written with `Status: draft`. The parity generator only credits the `understood` gate on
`Status: approved`, so generating drafts cannot inflate any gate — a human still has to review each row
and either point it at an implementation + test or record a waiver with a reason.

Existing contracts are never overwritten: an approved contract is a reviewed artifact.

Run: python3 project-memory/parity/generate_contracts.py [FORM ...]
"""

from __future__ import annotations

import json
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
PARITY = ROOT / "project-memory/parity"
CONTRACTS = ROOT / "project-memory/contracts"

# Forms worth a contract first: the highest-volume transaction surfaces.
DEFAULT_FORMS = [
    "TR_SALE",
    "TR_PURC",
    "TR_SALE_ORD",
    "TR_SALE_RTN",
    "TR_TAG_OPBL",
    "TR_WH_SALE",
    "TR_TOUR_SALE",
    "TR_DHRN_REC",
    "TR_MEMB_ENT",
    "TR_KR_ISU",
]


# Golden vectors already proven, keyed by the persisted column they pin. Extracted from
# `web/apps/api/test/goldenVectors.test.ts`, which is the single place a formula becomes provable.
# Keyed by (form, column) because the SAME column name has different desktop formulas per family:
# the sale line total is rounded to whole rupees while the purchase line total keeps paise, so a
# column-only registry would attach the wrong proof.
GOLDEN_VECTORS: dict[tuple[str, str], str] = {
    ("TR_SALE", "TOT_AMT"): "GV-SLDETL-001",
    ("TR_SALE", "NET_AMT"): "GV-SLDETL-001",
    ("TR_PURC", "TOT_AMT"): "GV-PRDETL-001",
    ("TR_PURC", "NET_AMT"): "GV-PRDETL-002",
    # The fine formula is shared by every workflow whose finePolicy case is `sale`-shaped.
    ("TR_SALE", "ITM_FINE"): "GV-FINE-001",
    ("TR_PURC", "ITM_FINE"): "GV-FINE-001",
    ("TR_SALE_ORD", "ITM_FINE"): "GV-FINE-001",
    ("TR_TAG_OPBL", "ITM_FINE"): "GV-FINE-001",
    ("TR_SALE", "CGST_TAX"): "GV-GST-001",
    ("TR_SALE", "SGST_TAX"): "GV-GST-001",
    ("TR_SALE", "IGST_TAX"): "GV-GST-002",
    # Exchange (old-gold) line: rate and amount are two directions of the same branch set.
    ("TR_SALE", "ITM_RATE"): "GV-OLDGOLD-001",
    ("TR_SALE", "ITM_NWT"): "GV-LINEWT-001",
    ("TR_SALE", "ITM_TOUCH"): "GV-OLDGOLD-001",
    ("TR_SALE", "CON_WT"): "GV-STONE-001",
    ("TR_SALE", "KR_CON_WT"): "GV-STONE-001",
    ("TR_SALE", "ITM_AMT"): "GV-STONE-001",
    ("TR_SALE", "LBR_AMT"): "GV-STONE-001",
    ("TR_SALE", "KR_NET_WT"): "GV-LINEWT-001",
    # Purchase per-line chain. Weights use format-string rounding (half-up, 3 dp); money uses
    # Math.Round(..., 0) per PIECE (whole rupees, half-to-even).
    ("TR_PURC", "ITM_NWT"): "GV-PRLINE-001",
    ("TR_PURC", "ITM_GWT"): "GV-PRLINE-001",
    ("TR_PURC", "ITM_GHT_WT"): "GV-PRLINE-001",
    ("TR_PURC", "ITM_TOUCH"): "GV-PRLINE-002",
    ("TR_PURC", "ITM_RATE"): "GV-PRLINE-002",
    ("TR_PURC", "LBR_RATE"): "GV-PRLINE-002",
    ("TR_PURC", "IT_AMT"): "GV-PRLINE-003",
    ("TR_PURC", "ITM_AMT"): "GV-PRLINE-003",
    ("TR_PURC", "LBR_AMT"): "GV-PRLINE-003",
    ("TR_PURC", "OTH_FINE"): "GV-PRLINE-003",
    ("TR_PURC", "ITM_FINE"): "GV-PRLINE-004",
    ("TR_PURC", "IT_PCS_WT"): "GV-PRLINE-001",
    ("TR_PURC", "KR_WT"): "GV-PRLINE-001",
    ("TR_PURC", "RATE_TYPE"): "GV-PRLINE-002",
    ("TR_PURC", "KR_CON_PRC"): "GV-PRLINE-001",
    ("TR_PURC", "KR_RATE_TYPE"): "GV-PRLINE-002",
}


#: Rules with a recorded disposition in WAIVERS.md. Keeping them here means a contract states WHY a rule
#: is not enforced instead of leaving a blank, which is the difference between a reviewed decision and an
#: oversight. Every entry must have a matching, dated section in WAIVERS.md.
RULE_DISPOSITIONS: dict[str, tuple[str, str]] = {
    "Please Insert Cr Days And Try...": (
        "WAIVED",
        "gated on DC_Main.SSRegSrNo = 'VK217NEVK'/'VS233NEBU' — fires for two named installations only",
    ),
    "This Function Not Working in Your Software Virson Please Upgrad Advance or Enterprise Then Try": (
        "WAIVED",
        "desktop edition/licence tier gate; the web deployment has no edition tiering",
    ),
    "New Report is Insert ok...Please This Form Close And Reopen...": (
        "WAIVED",
        "report-designer notice telling the operator to reopen the MDI form; no MDI lifecycle in the web",
    ),
    "Please Check Len Connection...You Cant Save Image...": (
        "WAIVED",
        "error handler around saving a JPEG to the LAN share; the web stores images in AC_IMAGE (bytea)",
    ),
    "Please check your internet connection": (
        "WAIVED",
        "network error handler; notifyWithAttemptLog records provider failures per attempt instead",
    ),
    "Please Insert Ref No Then Try....": (
        "WAIVED",
        "gated on DC_Main.SSRegSrNo = 'HM037NEKU' — one named installation",
    ),
    "Please Select Delevery Date and Try......": (
        "WAIVED",
        "gated on DC_Main.SSRegSrNo = 'VK115NEVK' — one named installation",
    ),
    "Please Insert City and Mobile no Then Try....": (
        "WAIVED",
        "gated on DC_Main.SSRegSrNo — per-installation customisation",
    ),
    "Please First Save Voucher and Reopen Voucher and try...": (
        "UI-LEVEL",
        "fires when an action needing a persisted voucher is pressed; belongs on the page, not the API",
    ),
    "Please Save This Voucher Then Effect....": (
        "NOTICE",
        "post-action notice shown AFTER a row is cleared; execution continues, nothing is blocked",
    ),
    "Please First Save Voucher And Try Because Tag Row Is Delete But Vch Not Save...": (
        "UI-LEVEL",
        "fires after a tag row is removed on screen but before the voucher is saved; the API only ever "
        "sees a complete write set, so there is no equivalent intermediate state",
    ),
    "Please Insert Party Entry And Try.....": (
        "IMPLEMENTED",
        "purchase.ts rejects a voucher whose labour/pieces/gross-weight/net-amount totals are all zero",
    ),
    "ThenPlease Insert Fine In Party Fine.....": (
        "WAIVED",
        "gated on FormMainBook = 'OLD ITEM SALES' AND DC_Main.SSRegSrNo = 'HM285NEKU' — one installation",
    ),
    "Please Select Group First And try...": (
        "UI-LEVEL",
        "fires inside the F1-help picker flow in MS_ACCT, not a save path",
    ),
}

#: Cells with no persisted column that are still derived, keyed by (form, control name).
GOLDEN_VECTORS_BY_CONTROL: dict[tuple[str, str], str] = {
    # Same fine-wise formula as the exchange net amount; SL_PR_DETL has no cost column, so it resolves
    # to no column while still being a real derived value.
    ("TR_SALE", "cUrPrCost"): "GV-OLDGOLD-001",
    ("TR_SALE", "cOldSrNo"): "GV-SEQ-001",
    ("TR_PURC", "cPrOldSrNo"): "GV-PRLINE-005",
    ("TR_PURC", "cPrBagTot"): "GV-PRLINE-001",
    ("TR_PURC", "cPrKundanFine"): "GV-PRLINE-001",
    ("TR_PURC", "cPrNetFine"): "GV-PRLINE-004",
    ("TR_PURC", "cPrComAmt"): "GV-PRLINE-003",
}


def vector_for(form: str, column: str | None) -> str:
    """Vector id pinning this form's formula for the column, or blank when none exists yet."""
    return GOLDEN_VECTORS.get((form, column or ""), "")


def table(rows: list[list[str]], headers: list[str]) -> list[str]:
    out = ["| " + " | ".join(headers) + " |", "|" + "|".join(["---"] * len(headers)) + "|"]
    out += ["| " + " | ".join(cell.replace("|", "\\|") for cell in row) + " |" for row in rows]
    return out


def main(argv: list[str]) -> int:
    validations = json.loads((PARITY / "VALIDATION-AUDIT.json").read_text())["forms"]
    calcs = json.loads((PARITY / "CALC-AUDIT.json").read_text())["forms"]
    forms = argv or DEFAULT_FORMS
    CONTRACTS.mkdir(parents=True, exist_ok=True)

    written, skipped = [], []
    for form in forms:
        path = CONTRACTS / f"{form}.contract.md"
        if path.exists():
            skipped.append(form)
            continue

        v = validations.get(form, {})
        c = calcs.get(form, {})
        unmatched = set(v.get("unmatchedRules") or [])
        rules = v.get("rules", 0)
        matched = v.get("rulesMatched", 0)

        lines: list[str] = [
            f"# {form} — behaviour contract",
            "",
            "Status: draft",
            "",
            "Generated by `project-memory/parity/generate_contracts.py` from the measured audits.",
            "Every row must end as **implemented + test** or **waived with a reason**. Desktop wording is",
            "reproduced verbatim, typos included: operators match on that text.",
            "",
            "## Validations",
            "",
            f"Catalogued business rules: **{rules}**, of which **{matched}** already carry the desktop",
            f"wording in the web source. Prompts (confirmation questions) and post-action notices are",
            "excluded by `validation_audit.py` and are not the API's responsibility.",
            "",
        ]
        rule_rows: list[list[str]] = []
        for message in sorted(unmatched):
            status, reason = RULE_DISPOSITIONS.get(message, ("NOT ENFORCED", ""))
            rule_rows.append([f"`{message}`", status, reason, ""])
        if rule_rows:
            lines += table(
                rule_rows,
                ["Desktop message (verbatim)", "Status", "Disposition / web implementation", "Test"],
            )
        else:
            lines.append("_No unmatched business rules for this form._")

        lines += [
            "",
            "## Computed fields",
            "",
            f"Desktop calculation expressions catalogued: **{c.get('calcExpressions', 0)}** "
            "(the extractor caps each form at 70, so treat this as a lower bound).",
            f"Distinct computed grid cells: **{c.get('computedFields', 0)}**.",
            "",
            "`web writes column` means the value is persisted — it is **not** proof the formula matches.",
            "Formula equality needs a golden-vector test in `apps/api/test/goldenVectors.test.ts`;",
            "its id appears in the Vector column. A blank Vector is an open item, not a pass.",
            "",
        ]
        field_rows: list[list[str]] = []
        seen: set[tuple[str, str]] = set()
        for field in c.get("fields") or []:
            key = (field.get("control") or "", field.get("column") or "")
            if key in seen:
                continue
            seen.add(key)
            field_rows.append(
                [
                    f"`{field.get('variable')}[{field.get('index')}]`",
                    field.get("family") or "unresolved",
                    f"`{field.get('control')}`" if field.get("control") else "unresolved",
                    f"`{field.get('column')}`" if field.get("column") else "unmapped",
                    "yes" if field.get("webWritesColumn") else "no",
                    # Screen-summary cells all share one accumulation vector: the operation is
                    # identical per column, only the summed column differs.
                    (
                        "GV-TOTALS-001"
                        if field.get("screenSummary")
                        else vector_for(form, field.get("column"))
                        or GOLDEN_VECTORS_BY_CONTROL.get((form, field.get("control") or ""), "")
                    ),
                ]
            )
        if field_rows:
            lines += table(
                field_rows,
                ["Desktop cell", "Grid", "Control", "Persisted column", "Web writes column", "Vector"],
            )
        else:
            lines.append("_No computed grid cells catalogued for this form._")

        lines += [
            "",
            "## Review checklist",
            "",
            "- [ ] every NOT ENFORCED rule is implemented with the verbatim message, or waived with a reason",
            "- [ ] every computed cell maps to a web calculation, or is waived as display-only/UI state",
            "- [ ] each implemented formula has a golden-vector test id recorded above",
            "- [ ] unresolved controls and unmapped columns are explained, not left blank",
            "- [ ] `Status:` changed to `approved` only when the four boxes above are true",
            "",
        ]
        path.write_text("\n".join(lines) + "\n")
        written.append(form)

    print(f"contracts written: {len(written)} -> {', '.join(written) if written else '(none)'}")
    if skipped:
        print(f"left untouched (already exist): {', '.join(skipped)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
