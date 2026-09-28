"""Phase E metric: are the desktop's validations enforced by the web?

The desktop's validation identity is its MESSAGE TEXT — operators recognise the wording, and it is
the only stable key between a decompiled `MsgBox` and a web guard. This tool loads every validation
from the form-behaviour catalogs, classifies it, and reports whether the web source carries the same
message.

Classification matters for honesty. Not every `MsgBox` is a business rule:
  • prompt        — a confirmation question ("... ?"). UI chrome; the web uses its own confirm.
  • notice        — a post-action information message ("Record Is Deleted....").
  • rule          — a guard that blocks or corrects an entry ("Please select...", "not allowed",
                    "Invalid...", "already exists"). These are the ones the API must enforce.
Only `rule` entries are counted in the coverage denominator; prompts and notices are reported
separately so the split is visible rather than hidden.

Run: python3 project-memory/parity/validation_audit.py
"""

from __future__ import annotations

import json
import re
from collections import Counter
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
BEHAVIOR = ROOT / "project-memory/catalogs/form-behavior"
API_SRC = ROOT / "web/apps/api/src"
WEB_SRC = ROOT / "web/apps/web"

RULE_MARKERS = (
    "please",
    "not allow",
    "not allowed",
    "invalid",
    "already exist",
    "duplicate",
    "cannot",
    "can not",
    "must",
    "required",
    "enter ",
    "select ",
    "greater",
    "less than",
    "not found",
    "no record",
    "not match",
    "mismatch",
    "exceed",
    "locked",
    "first",
    "wrong",
)


DESKTOP_SRC = ROOT / "unified/src/csharp/DataCareNext"

# Messages proven to be post-action NOTICES by reading the desktop control flow, despite wording that
# reads like an instruction. Each entry names the forms checked and what the desktop does next.
#
# A structural classifier was attempted (treat a message as a guard when its MsgBox is followed by
# `return;` or a `.Focus()` that blocks progression) and REJECTED: this codebase has a third guard shape
# that is textually identical to a notice — a bare message inside a validation branch whose else-branch
# handles the valid case (TR_PURC's "Please Insert HmId2 Weight and try..." is one). Because the shapes
# cannot be separated mechanically, the denominator stays conservative: it still counts some notices as
# rules, so the published coverage is UNDER-reported rather than flattered.
PROVEN_NOTICES: dict[str, str] = {
    # Shown AFTER Ctrl+D clears a settlement/UPI row; execution continues, nothing is blocked. Verified
    # in TR_SALE, TR_TAG_OPBL, TR_TAG_WT_DIFF, TR_MFG_WITH_LOT, TR_SALE_HM, TR_SL_ORD_ADJ, TR_MFG_ORD_REC.
    "Please Save This Voucher Then Effect....": (
        "post-action notice: the desktop has already cleared the row and only tells the operator the "
        "change persists on save"
    ),
}


def classify(message: str) -> str:
    text = message.strip()
    if not text:
        return "empty"
    lowered = text.lower()
    if text.endswith("?"):
        return "prompt"
    if text in PROVEN_NOTICES:
        return "notice"
    if any(marker in lowered for marker in RULE_MARKERS):
        return "rule"
    # Past-tense/aftermath notices: "Record Is Deleted....", "Data Saved", "... Completed"
    if re.search(r"\b(deleted|saved|updated|completed|successful|transferr?ed|printed)\b", lowered):
        return "notice"
    return "notice"


def normalise(message: str) -> str:
    """Comparable form: collapse whitespace/punctuation noise that decompilation and UI copy differ on."""
    return re.sub(r"[^a-z0-9]+", " ", message.lower()).strip()


def source_corpus() -> str:
    parts: list[str] = []
    for base in (API_SRC, WEB_SRC):
        for path in base.rglob("*.ts"):
            parts.append(path.read_text(encoding="utf-8", errors="ignore"))
        for path in base.rglob("*.tsx"):
            parts.append(path.read_text(encoding="utf-8", errors="ignore"))
    return normalise(" ".join(parts))


def main() -> int:
    corpus = source_corpus()
    per_form: dict[str, dict] = {}
    totals = Counter()
    unmatched_rules: list[tuple[str, str]] = []

    for path in sorted(BEHAVIOR.glob("*.behavior.json")):
        data = json.loads(path.read_text(encoding="utf-8", errors="ignore"))
        form = data.get("form") or path.name.split(".")[0]
        validations = data.get("validations") or []
        if not isinstance(validations, list) or not validations:
            continue

        kinds = Counter()
        matched = 0
        rules = 0
        form_unmatched: list[str] = []
        seen: set[str] = set()
        for entry in validations:
            message = (entry or {}).get("message") if isinstance(entry, dict) else None
            if not message:
                continue
            key = normalise(message)
            if not key or key in seen:
                continue
            seen.add(key)
            kind = classify(message)
            kinds[kind] += 1
            totals[kind] += 1
            if kind != "rule":
                continue
            rules += 1
            # A rule counts as enforced when its wording appears in the web source.
            if key in corpus:
                matched += 1
            else:
                form_unmatched.append(message)
                unmatched_rules.append((form, message))

        per_form[form] = {
            "validations": sum(kinds.values()),
            "rules": rules,
            "rulesMatched": matched,
            "byKind": dict(sorted(kinds.items())),
            "unmatchedRules": form_unmatched,
        }
        totals["rulesMatched"] += matched

    total_rules = totals["rule"]
    matched_rules = totals["rulesMatched"]
    pct = round(matched_rules * 100 / total_rules, 1) if total_rules else None

    print(f"{'form':22}{'rules':>6}{'matched':>8}  top unmatched")
    ranked = sorted(per_form.items(), key=lambda kv: -(kv[1]["rules"] - kv[1]["rulesMatched"]))
    for form, row in ranked[:20]:
        if row["rules"] == 0:
            continue
        sample = "; ".join(m[:38] for m in row["unmatchedRules"][:2])
        print(f"{form:22}{row['rules']:6}{row['rulesMatched']:8}  {sample}")

    print(
        f"\nDistinct validations {sum(v for k, v in totals.items() if k != 'rulesMatched')}: "
        f"rules {total_rules}, prompts {totals['prompt']}, notices {totals['notice']}"
    )
    print(f"Business rules carrying desktop wording in web source: {matched_rules}/{total_rules} ({pct}%)")

    out = ROOT / "project-memory/parity/VALIDATION-AUDIT.json"
    out.write_text(
        json.dumps(
            {
                "totals": {
                    "rules": total_rules,
                    "rulesMatched": matched_rules,
                    "coveragePct": pct,
                    "prompts": totals["prompt"],
                    "notices": totals["notice"],
                },
                "forms": per_form,
            },
            indent=2,
        )
        + "\n"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
