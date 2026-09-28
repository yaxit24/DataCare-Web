"""Phase D metric: can an operator actually enter every field the API accepts?

The desktop grid metric (`<th>` count vs desktop gridColumns) is a lower bound because desktop grid
inventories include hidden state columns. This check measures the thing that matters functionally:
for each transaction page, which fields of the API's input types have NO control on the page and are
never transmitted. A field the API accepts but the UI cannot supply is an uncapturable field — the
concrete form of "the operator types 25-40 values per line on the desktop and 10-15 on the web".

Run: python3 project-memory/parity/ui_field_audit.py
"""

from __future__ import annotations

import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
API = ROOT / "web/apps/api/src/modules"
PAGES = ROOT / "web/apps/web/app/(app)/txn"
COMPONENTS = ROOT / "web/apps/web/components"

# page directory -> API interfaces that define what the endpoint accepts
TARGETS: dict[str, list[tuple[str, str]]] = {
    "sales": [("sales/sales.ts", "SaleLineInput"), ("sales/sales.ts", "SaleInput")],
    "purchase": [
        ("purchase/purchase.ts", "PurchaseLineInput"),
        ("purchase/purchase.ts", "PurchaseInput"),
    ],
    "sales-order": [
        ("sales/salesOrder.ts", "SalesOrderLine"),
        ("sales/salesOrder.ts", "SalesOrderInput"),
    ],
    "sales-return": [("sales/salesReturn.ts", "SalesReturnLineInput")],
    "tag-opening": [("stock/stockVoucherLifecycle.ts", "TagOpeningLine")],
    "karigar-issue": [("manufacturing/karigar.ts", "KarigarLine")],
    "tour-issue": [("tour/tour.ts", "TourIssueLine")],
    "dhrn-issue": [("dhrn/dhrn.ts", "DhrnIssueInput")],
    "dhrn-receipt": [("dhrn/dhrn.ts", "DhrnReceiptInput")],
    "vp-parcel": [("sales/vpParcel.ts", "VpParcelLineInput")],
}

# Fields the UI legitimately never supplies: server-derived scope/identity and nested arrays that
# have their own editors. Counting them as gaps would be misleading.
SERVER_OWNED = {
    "scope",
    "mainUser",
    "lines",
    "items",
    "stones",
    "collateral",
    "components",
    "oldGold",
    "interState",
    "taxRatePct",
    "vchDate",
    "isEdit",
}


def interface_fields(source: Path, name: str) -> set[str]:
    body = source.read_text(encoding="utf-8", errors="ignore")
    m = re.search(r"export interface %s [^{]*\{(.*?)\n\}" % re.escape(name), body, re.S)
    if not m:
        return set()
    return {f for f in re.findall(r"\n\s*(\w+)\??:", m.group(1))} - SERVER_OWNED


def page_text(directory: str) -> str:
    """Page source plus any local components it renders (pages often delegate entirely)."""
    page = PAGES / directory / "page.tsx"
    if not page.exists():
        return ""
    text = page.read_text(encoding="utf-8", errors="ignore")
    for component in set(re.findall(r"from\s+'(?:\.\./)+components/([A-Za-z0-9_]+)'", text)):
        for ext in (".tsx", ".ts"):
            candidate = COMPONENTS / f"{component}{ext}"
            if candidate.exists():
                text += candidate.read_text(encoding="utf-8", errors="ignore")
                break
    return text


def main() -> int:
    report: dict[str, dict] = {}
    total_fields = total_gaps = 0
    for directory, interfaces in TARGETS.items():
        text = page_text(directory)
        if not text:
            report[directory] = {"status": "no-page", "fields": 0, "uncapturable": []}
            continue
        fields: set[str] = set()
        for rel, name in interfaces:
            source = API / rel
            if source.exists():
                fields |= interface_fields(source, name)
        # A field counts as capturable when the page names it (state key, control or payload key).
        missing = sorted(f for f in fields if not re.search(rf"\b{re.escape(f)}\b", text))
        report[directory] = {
            "status": "ok" if not missing else "gaps",
            "fields": len(fields),
            "uncapturable": missing,
        }
        total_fields += len(fields)
        total_gaps += len(missing)

    print(f"{'page':16}{'fields':>7}{'gaps':>6}  uncapturable")
    for directory, row in sorted(report.items(), key=lambda kv: -len(kv[1]["uncapturable"])):
        gaps = row["uncapturable"]
        print(f"{directory:16}{row['fields']:7}{len(gaps):6}  {', '.join(gaps[:8])}")
    covered = total_fields - total_gaps
    pct = round(covered * 100 / total_fields, 1) if total_fields else None
    print(f"\nTOTAL api-accepted fields {total_fields}; capturable {covered} ({pct}%); gaps {total_gaps}")

    out = ROOT / "project-memory/parity/UI-FIELD-AUDIT.json"
    out.write_text(
        json.dumps(
            {"pages": report, "totalFields": total_fields, "capturable": covered, "coveragePct": pct},
            indent=2,
        )
        + "\n"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
