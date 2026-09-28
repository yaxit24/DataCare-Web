#!/usr/bin/env python3
"""Build the authoritative desktop-to-web parity matrix from repository evidence.

This generator deliberately separates engineering breadth from parity. A route, model,
layout preview, or unit test may make a gate `in_progress`; none is sufficient for a
`passed` implementation, desktop-comparison, or production-certification gate.
"""
from __future__ import annotations

import csv
import sys
import json
import re
from collections import Counter, defaultdict
from datetime import datetime, timezone
from pathlib import Path
from typing import Any, Iterable

# Measurement integrity: never import a cached bytecode copy of the depth analyzer. A stale
# __pycache__ once made this generator publish 52.7% when the true figure was 60.7%.
sys.dont_write_bytecode = True
_here = Path(__file__).resolve().parent
for _cache in _here.glob("__pycache__"):
    for _pyc in _cache.glob("*.pyc"):
        _pyc.unlink()
sys.path.insert(0, str(_here))
import depth_metrics  # noqa: E402

ROOT = Path(__file__).resolve().parents[2]
OUT_DIR = ROOT / "project-memory/parity"
GENERATED_AT = datetime.now(timezone.utc).replace(microsecond=0).isoformat()
VERIFY_BY = "project-memory/parity/build_parity_matrix.py"

VALID_STATUSES = {
    "passed", "in_progress", "not_started", "blocked", "evidence_gap", "regressed", "waived"
}
GATE_NAMES = (
    "extracted", "understood", "implemented", "depth", "tested", "desktop_compared", "production_certified"
)
G5_RUNNER_PATH = "web/apps/api/integration/g5-compare.mjs"
G5_ARTIFACT_ROOT = "project-memory/parity/g5"
G5_LATEST_PATH = f"{G5_ARTIFACT_ROOT}/latest.json"
G5_EXTERNAL_INPUTS = [
    "A reachable desktop SQL Server runtime containing sanitized representative shop data.",
    "Read-only desktop source credentials in CUTOVER_SOURCE_* environment variables.",
    "A matching migrated PostgreSQL target tenant in DATABASE_URL and G5_TARGET_TENANT.",
    "G5_FORMS JSON identifying matching desktop and web vouchers for each form.",
]

G6_STATUS_PATH = "project-memory/parity/G6-STATUS.md"
G6_REQUIREMENTS = [
    {
        "id": "load-local", "requirement": "Repeatable load/performance evidence",
        "status": "evidence_produced", "artifactPath": "project-memory/parity/LOAD-PROFILE.md",
        "externalInputRequired": None,
    },
    {
        "id": "load-production", "requirement": "Production-like capacity/soak and approved SLO",
        "status": "blocked", "artifactPath": "project-memory/parity/LOAD-PROFILE.md",
        "externalInputRequired": "Production-like multi-instance deployment/network; representative sanitized shop data volume; approved traffic mix and latency/error/capacity targets; database sizing/pool budget.",
    },
    {
        "id": "security-local", "requirement": "Code/security review and source secret policy",
        "status": "evidence_produced", "artifactPath": "project-memory/parity/SECURITY-REVIEW.md",
        "externalInputRequired": None,
    },
    {
        "id": "security-live", "requirement": "End-to-end deployed security assessment",
        "status": "blocked", "artifactPath": "project-memory/parity/SECURITY-REVIEW.md",
        "externalInputRequired": "Deployed HTTPS origin/proxy/WAF; trusted-proxy and distributed rate-limit design; CSP/HSTS/Permissions-Policy decisions; test roles; authorized independent assessor and window.",
    },
    {
        "id": "observability-local", "requirement": "Readiness, metrics, and structured operational signals",
        "status": "evidence_produced", "artifactPath": "web/apps/api/src/modules/ops/metrics.ts",
        "externalInputRequired": None,
    },
    {
        "id": "observability-live", "requirement": "Production dashboards, alerts, retention, and on-call exercise",
        "status": "blocked", "artifactPath": "web/apps/api/src/modules/ops/metrics.ts",
        "externalInputRequired": "Monitoring/log platform and credentials; alert destinations/escalation roster; retention/SLO policy; deployed endpoints; named on-call participants and exercise window.",
    },
    {
        "id": "backup-restore-local", "requirement": "Repeatable logical backup/restore verification",
        "status": "evidence_produced", "artifactPath": "project-memory/parity/DR-RUNBOOK.md",
        "externalInputRequired": None,
    },
    {
        "id": "dr-production", "requirement": "Offsite backup and production-scale DR/RPO/RTO approval",
        "status": "blocked", "artifactPath": "project-memory/parity/DR-RUNBOOK.md",
        "externalInputRequired": "Backup store/vault and credentials; encryption/KMS and retention policy; secondary topology; production-sized encrypted snapshot; approved RPO/RTO; incident commander and recovery approver.",
    },
    {
        "id": "device-protocol", "requirement": "Device protocol validation and fallback design",
        "status": "evidence_produced", "artifactPath": "project-memory/parity/DEVICE-BRIDGE.md",
        "externalInputRequired": None,
    },
    {
        "id": "device-uat", "requirement": "Physical scale/printer/scanner/camera certification",
        "status": "blocked", "artifactPath": "project-memory/parity/UAT-PLAN.md",
        "externalInputRequired": "Actual manufacturer/model/firmware/driver inventory; scale calibration/capacity/precision and USB/serial identity/settings; printer media/DPI; scanner mode; camera/browser; physical devices/workstation.",
    },
    {
        "id": "site-uat", "requirement": "Customer-site workflow UAT",
        "status": "blocked", "artifactPath": "project-memory/parity/UAT-PLAN.md",
        "externalInputRequired": "Named customer site; approved UAT tenant/build/data/control totals; module operators; supported workstations/browser; execution window.",
    },
    {
        "id": "integrations-live", "requirement": "Live/sandbox external-service acceptance",
        "status": "blocked", "artifactPath": "project-memory/parity/G6-STATUS.md",
        "externalInputRequired": "e-Invoice GSP sandbox credentials/GSTIN; WhatsApp test number/token; SMS account/key/sender; live-rate account/key; approved recipients and reconciliation owner.",
    },
    {
        "id": "business-signoff", "requirement": "Authorized production acceptance and go-live decision",
        "status": "blocked", "artifactPath": "project-memory/parity/G6-STATUS.md",
        "externalInputRequired": "Completed passing G5/G6 evidence and named authorized operations, finance, inventory/manufacturing, and security/deployment signers with dated signatures and authority.",
    },
]


def load_json(path: Path) -> Any:
    return json.loads(path.read_text(encoding="utf-8"))


def rel(path: Path | str) -> str:
    p = Path(path)
    try:
        return p.resolve().relative_to(ROOT.resolve()).as_posix()
    except (ValueError, FileNotFoundError):
        return p.as_posix()


def existing(paths: Iterable[Path | str]) -> list[str]:
    result: list[str] = []
    for value in paths:
        p = Path(value)
        if not p.is_absolute():
            p = ROOT / p
        if p.exists():
            result.append(rel(p))
    return sorted(dict.fromkeys(result))


def evidence(uri: str, kind: str = "source_ref", metric: str = "exists") -> dict[str, str]:
    return {
        "type": kind,
        "uri": uri,
        "resultMetric": metric,
        "verifiedBy": VERIFY_BY,
        "verifiedAt": GENERATED_AT,
    }


def gate(status: str, uris: Iterable[str] = (), note: str = "", kind: str = "source_ref") -> dict[str, Any]:
    if status not in VALID_STATUSES:
        raise ValueError(f"invalid gate status: {status}")
    return {
        "status": status,
        "evidence": [evidence(uri, kind) for uri in dict.fromkeys(uris)],
        "note": note,
    }


def source_files(base: Path) -> list[Path]:
    out: list[Path] = []
    if not base.exists():
        return out
    for suffix in ("*.ts", "*.tsx", "*.js", "*.mjs", "*.sql"):
        out.extend(base.rglob(suffix))
    return sorted(
        p for p in out
        if not any(part in {"node_modules", ".next", "dist", "build", ".turbo"} for part in p.parts)
    )


WEB_SOURCE_FILES = sorted(dict.fromkeys(
    source_files(ROOT / "web/apps/api/src")
    + source_files(ROOT / "web/apps/web/app")
    + source_files(ROOT / "web/apps/web/components")
    + source_files(ROOT / "web/apps/web/lib")
    + source_files(ROOT / "web/packages")
))
TEST_FILES = sorted(dict.fromkeys(
    source_files(ROOT / "web/apps/api/test")
    # Frontend behavior tests (keyboard/grid decision tables, browser workflow) are real evidence and
    # were previously invisible to this generator, which understated shortcut/UI coverage.
    + source_files(ROOT / "web/apps/web/test")
    + source_files(ROOT / "web/packages/core/test")
    + source_files(ROOT / "web/packages/db/test")
    + source_files(ROOT / "web/packages/parity/test")
))
TEXT: dict[Path, str] = {}
for path in WEB_SOURCE_FILES + TEST_FILES:
    try:
        TEXT[path] = path.read_text(encoding="utf-8", errors="ignore")
    except OSError:
        TEXT[path] = ""


def containing(files: Iterable[Path], token: str, *, case_sensitive: bool = True, limit: int = 30) -> list[str]:
    if not token:
        return []
    needle = token if case_sensitive else token.lower()
    matches: list[str] = []
    for path in files:
        hay = TEXT.get(path, "")
        if (needle in hay) if case_sensitive else (needle in hay.lower()):
            matches.append(rel(path))
            if len(matches) >= limit:
                break
    return matches


def quoted_refs(files: Iterable[Path], token: str, limit: int = 30) -> list[str]:
    """Return files containing an exact quoted literal, avoiding substring/common-word false positives."""
    pattern = re.compile(rf"(['\"`]){re.escape(token)}\1", re.I)
    matches: list[str] = []
    for path in files:
        if pattern.search(TEXT.get(path, "")):
            matches.append(rel(path))
            if len(matches) >= limit:
                break
    return matches


def parse_api_routes() -> list[dict[str, str]]:
    rows: list[dict[str, str]] = []
    pattern = re.compile(r"\b(?:app|server)\.(get|post|put|patch|delete)\(\s*(['\"`])([^'\"`]+)\2")
    for path in [ROOT / "web/apps/api/src/app.ts", ROOT / "web/apps/api/src/routes/txn.ts"]:
        text = path.read_text(encoding="utf-8", errors="ignore")
        for match in pattern.finditer(text):
            rows.append({"method": match.group(1).upper(), "path": match.group(3), "source": rel(path)})
    return rows


API_ROUTES = parse_api_routes()
API_ROUTE_KEYS = {(r["method"], r["path"], r["source"]) for r in API_ROUTES}


def select_api(prefixes: Iterable[str]) -> list[dict[str, str]]:
    values = tuple(prefixes)
    if not values:
        return []
    return [r for r in API_ROUTES if any(r["path"].startswith(prefix) for prefix in values)]


def route_file(route: str) -> str | None:
    route = route.split("?", 1)[0].strip("/")
    base = ROOT / "web/apps/web/app/(app)"
    exact = base / route / "page.tsx"
    if exact.exists():
        return rel(exact)
    if route.startswith("masters/"):
        dynamic = base / "masters/[name]/page.tsx"
        return rel(dynamic) if dynamic.exists() else None
    if route.startswith("reports/"):
        dynamic = base / "reports/[report]/page.tsx"
        return rel(dynamic) if dynamic.exists() else None
    return None


# ---------------------------------------------------------------------------
# Conservative desktop-form → current-web map. Classification describes the
# current implementation shape, never desktop parity.
# ---------------------------------------------------------------------------
FORM_MAP: dict[str, dict[str, Any]] = {}

WAIVERS_PATH = "project-memory/parity/WAIVERS.md"
WAIVERS_FILE = ROOT / WAIVERS_PATH
WAIVERS_TEXT = WAIVERS_FILE.read_text(encoding="utf-8")
WAIVED_FORMS: dict[str, dict[str, str]] = {
    "MS_HELP": {"rationale": "Reusable in-memory lookup chooser; web uses embedded lookup controls.", "path": WAIVERS_PATH},
    "MS_TASTING": {"rationale": "Static chart/UI demonstration with no database behavior.", "path": WAIVERS_PATH},
    "UT_WEB_CAM": {"rationale": "Local camera capture belongs to the device-bridge workstream.", "path": WAIVERS_PATH},
    "Data": {"rationale": "Authentication transport DTO, not a user form.", "path": WAIVERS_PATH},
    "DcClass": {"rationale": "e-Invoice request aggregate DTO, not a user form.", "path": WAIVERS_PATH},
    "DcPrintClass": {"rationale": "Tag-print payload DTO, not a user form.", "path": WAIVERS_PATH},
    "ClsItemList": {"rationale": "e-Invoice line DTO/sample defaults, not a user form.", "path": WAIVERS_PATH},
    "Translator": {"rationale": "Outbound translation helper, not a persisted business form.", "path": WAIVERS_PATH},
    "OlockerService": {"rationale": "Read-only sale-to-insurance integration helper, not a data-entry form.", "path": WAIVERS_PATH},
    "TR_PR_SL_UAE": {"rationale": "Owner scope decision 2026-07-28: UAE VAT sale variant is out of scope for this Indian deployment.", "path": WAIVERS_PATH},
    "TR_SALE_RTN_UAE": {"rationale": "Owner scope decision 2026-07-28: UAE VAT sale-return variant is out of scope for this Indian deployment.", "path": WAIVERS_PATH},
}
for _waived_form in WAIVED_FORMS:
    assert f"## {_waived_form} " in WAIVERS_TEXT, f"waiver section missing: {_waived_form}"

WAIVED_SETTINGS: dict[str, dict[str, str]] = {
    "BTN_NAME": {"rationale": "Desktop navigation-shell start group only.", "path": WAIVERS_PATH},
    "THEME": {"rationale": "WinForms colours/styles only.", "path": WAIVERS_PATH},
    "SL_ROW_CHANGE": {"rationale": "Grid focus/navigation only.", "path": WAIVERS_PATH},
    "RATE_MAST_OPEN": {"rationale": "Auto-opens a screen; does not change rates.", "path": WAIVERS_PATH},
    "HELP_SERCH": {"rationale": "Lookup-grid interaction mode only.", "path": WAIVERS_PATH},
    "REMINDER_OPEN": {"rationale": "Auto-opens the reminder screen only.", "path": WAIVERS_PATH},
    "GRID_SCROLL": {"rationale": "WinForms grid scrolling preference only.", "path": WAIVERS_PATH},
    "DUP_PRINT": {"rationale": "Requests an extra printed copy only.", "path": WAIVERS_PATH},
    "LEDR_BILL_COL": {"rationale": "Ledger report column visibility only.", "path": WAIVERS_PATH},
    "STK_RPT_VIEW": {"rationale": "No desktop load site or consumer; STOCK_RPT_TYPE is the real key.", "path": WAIVERS_PATH},
}
for _waived_setting in WAIVED_SETTINGS:
    assert f"## {_waived_setting} " in WAIVERS_TEXT, f"waiver section missing: {_waived_setting}"


WAIVED_REPORTS: dict[str, dict[str, str]] = {
    "SalesQuotation": {
        "rationale": "Exact extraction is waived: the supplied XML truncates at line 2908; the recoverable 30-section prefix is retained as an explicitly partial web spec.",
        "path": WAIVERS_PATH,
    },
    "TagStkIdtlRpt": {
        "rationale": "Exact extraction is waived: the supplied legacy RPT has no XML and requires a compatible Windows Crystal reader/runtime.",
        "path": WAIVERS_PATH,
    },
}
for _waived_report in WAIVED_REPORTS:
    assert f"## {_waived_report} " in WAIVERS_TEXT, f"waiver section missing: {_waived_report}"

WAIVED_INTEGRATIONS: dict[str, dict[str, str]] = {
    "FIREBASE-SYNC": {
        "decision": "waived-evidence-gap",
        "rationale": "FireSharp is bundled but no extracted C# caller or Firebase data contract is evidenced.",
        "path": WAIVERS_PATH,
    },
    "SELENIUM-WHATSAPP": {
        "decision": "replaced-and-fallback-waived",
        "rationale": "Meta Graph Cloud API replaces outbound messaging; local WhatsApp Web automation is waived.",
        "path": WAIVERS_PATH,
    },
}
for _waived_integration in WAIVED_INTEGRATIONS:
    assert f"## {_waived_integration} " in WAIVERS_TEXT, (
        f"waiver section missing: {_waived_integration}"
    )


def map_forms(
    names: str | Iterable[str], classification: str, *, routes: Iterable[str] = (),
    modules: Iterable[str] = (), tests: Iterable[str] = (), api: Iterable[str] = (),
    confidence: str = "high", note: str = ""
) -> None:
    if isinstance(names, str):
        names = names.split()
    for name in names:
        FORM_MAP[name] = {
            "classification": classification,
            "frontendRoutes": list(routes),
            "apiModules": list(modules),
            "testFiles": list(tests),
            "apiPrefixes": list(api),
            "confidence": confidence,
            "mappingNote": note,
        }


# Masters: generic CRUD is explicitly a scaffold; richer/bespoke surfaces are called out.
map_forms("MS_ACCT", "variant-shared", routes=["/masters/accounts", "/masters/customers", "/masters/party"],
          modules=["web/apps/api/src/modules/masters/master.service.ts", "web/apps/api/src/modules/masters/party.ts"],
          tests=["web/apps/api/test/masters.test.ts"], api=["/masters", "/party"],
          note="Generic AC_MAST CRUD plus richer party surface; not the complete desktop account master.")
map_forms("MS_AUTO_ITEM", "dedicated-current-surface", routes=["/masters/auto-item"],
          modules=["web/apps/api/src/modules/masters/autoItem.ts"], tests=["web/apps/api/test/masters.test.ts"], api=["/masters/auto-item"])
map_forms("MS_LOGIN", "conceptual-engine", routes=["/login", "/admin/users"],
          modules=["web/apps/api/src/modules/auth/auth.service.ts", "web/apps/api/src/modules/auth/password.ts", "web/apps/api/src/modules/auth/jwt.ts"],
          tests=["web/apps/api/test/auth.service.test.ts", "web/apps/api/test/auth.password.test.ts", "web/apps/api/test/auth.jwt.test.ts"], api=["/auth"])
map_forms("MS_USER", "dedicated-current-surface", routes=["/admin/users"],
          modules=["web/apps/api/src/modules/rbac/users.ts", "web/apps/api/src/modules/rbac/formRights.ts"],
          tests=["web/apps/api/test/rbac.policy.test.ts"], api=["/admin/users"])
map_forms("MS_YEAR", "variant-shared", routes=["/masters/years", "/masters/year-create", "/utilities/year-end"],
          modules=["web/apps/api/src/modules/masters/year.ts", "web/apps/api/src/modules/ops/yearEnd.ts"], api=["/years", "/year-end"])
map_forms("MS_COMPANY MS_OPNCOMP", "variant-shared", routes=["/masters/companies", "/admin/provision", "/select"],
          modules=["web/apps/api/src/modules/ops/seedCompany.ts", "web/apps/api/src/modules/masters/master.service.ts"], api=["/admin/companies", "/context"])
map_forms("MS_UPDATE", "conceptual-engine", routes=["/utilities/data-refresh", "/masters/labour-update"],
          modules=["web/apps/api/src/modules/utilities/dataRefresh.ts", "web/apps/api/src/modules/masters/labourUpdate.ts"], api=["/utilities/data-refresh", "/labour-update"])
map_forms("MS_MEMB", "variant-shared", routes=["/txn/membership", "/txn/scheme"],
          modules=["web/apps/api/src/modules/membership/membership.ts", "web/apps/api/src/modules/membership/scheme.ts"],
          tests=["web/apps/api/test/salesFamilyLifecycle.db.test.ts", "web/apps/api/test/scheme.test.ts"], api=["/members", "/scheme"])
map_forms("MS_WINDOW_SET", "variant-shared", routes=["/settings", "/masters/styles"],
          modules=["web/apps/api/src/modules/settings/settings.ts"], api=["/settings"], confidence="medium")
map_forms("MS_STYLE MS_DESIGN_BOOK", "variant-shared", routes=["/masters/styles", "/masters/designs", "/masters/models"],
          modules=["web/apps/api/src/modules/masters/master.service.ts"], tests=["web/apps/api/test/masters.test.ts"], api=["/masters"], confidence="medium")
map_forms("MS_STK_LIMIT", "variant-shared", routes=["/masters/item-weights"],
          modules=["web/apps/api/src/modules/masters/master.service.ts"], api=["/masters"], confidence="medium")
MASTER_GENERIC = {
    "MS_AC_GROUP": "ac-groups", "MS_ADD_MAST": "addresses", "MS_BOOK": "books", "MS_DM": "diamonds",
    "MS_EMP": "employees", "MS_GOLD_MAST": "gold-rate", "MS_GROUP": "groups", "MS_ITEM": "items",
    "MS_LBR_TYPE": "labour", "MS_LOCT": "locations", "MS_MFG_MAST": "mfg", "MS_POINT": "points",
    "MS_PRINT": "print-formats", "MS_PRODUCT": "products", "MS_RATE": "rates", "MS_TAX": "taxes",
    "MS_TRADE": "trade",
}
for form_name, slug in MASTER_GENERIC.items():
    map_forms(form_name, "generic-crud-scaffold", routes=[f"/masters/{slug}"],
              modules=["web/apps/api/src/modules/masters/master.service.ts", "web/apps/api/src/modules/masters/configs.ts"],
              tests=["web/apps/api/test/masters.test.ts"], api=["/masters"],
              note="Metadata-driven CRUD exists; desktop-specific composition, focus, validation and side effects are not certified.")
map_forms("MS_RATE", "variant-shared", routes=["/masters/rates", "/txn/daily-rate"],
          modules=["web/apps/api/src/modules/masters/rate.ts", "web/apps/api/src/modules/masters/dailyRate.ts"],
          tests=["web/apps/api/test/rates.test.ts"],
          api=["/masters", "/rates", "/rate", "/rate-groups", "/daily-rate"])
map_forms("MS_LBR_TYPE", "generic-crud-scaffold", routes=["/masters/labour", "/masters/labour-update"],
          modules=["web/apps/api/src/modules/masters/master.service.ts", "web/apps/api/src/modules/masters/labourUpdate.ts"],
          tests=["web/apps/api/test/masters.test.ts"], api=["/masters", "/labour-slabs"],
          note="Metadata-driven labour-type CRUD plus weight-slab endpoints; desktop composition/validation not certified.")
map_forms("MS_BOOKLIST", "generic-scaffold", routes=["/masters/books"],
          modules=["web/apps/api/src/modules/masters/master.service.ts"], api=["/masters"], confidence="medium",
          note="Adjacent book list/CRUD exists; no one-to-one desktop form.")
map_forms("MS_HELP MS_TASTING", "no-current-evidence", confidence="low",
          note="Extracted form/layout evidence exists, but no bespoke current web behavior was found.")

# Transactions.
map_forms("TR_SALE", "dedicated-current-surface", routes=["/txn/sales"],
          modules=["web/apps/api/src/modules/sales/sales.ts", "web/apps/api/src/modules/sales/invoice.ts"],
          tests=["web/apps/api/test/sales.lifecycle.db.test.ts", "web/apps/api/test/sales.test.ts", "web/apps/api/test/workflows.test.ts"], api=["/sales", "/estimate"])
map_forms("TR_SALE_RTN", "dedicated-current-surface", routes=["/txn/sale-return"],
          modules=["web/apps/api/src/modules/sales/salesReturn.ts"], tests=["web/apps/api/test/salesFamilyLifecycle.db.test.ts", "web/apps/api/test/salesReturn.test.ts"], api=["/sales-returns"])
map_forms("TR_SALE_ORD TR_SL_ORD_ADJ", "dedicated-current-surface", routes=["/txn/sales-order", "/txn/order-cancel"],
          modules=["web/apps/api/src/modules/sales/salesOrder.ts"], tests=["web/apps/api/test/workflows.test.ts"], api=["/sales-orders"])
map_forms("TR_SALE_LBR", "dedicated-current-surface", routes=["/txn/labour-sale"],
          modules=["web/apps/api/src/modules/sales/labourInvoice.ts"], tests=["web/apps/api/test/documents.test.ts"], api=["/labour-invoice"])
map_forms("TR_SALE_HM", "variant-shared", routes=["/txn/hallmark-sale"],
          modules=["web/apps/api/src/modules/sales/sales.ts"], tests=["web/apps/api/test/sales.test.ts"], api=["/sales"])
map_forms("TR_WH_SALE", "variant-shared", routes=["/txn/wholesale-sale"],
          modules=["web/apps/api/src/modules/sales/sales.ts", "web/apps/api/src/modules/sales/rateCut.ts"],
          tests=["web/apps/api/test/sales.test.ts", "web/apps/api/test/rateCut.test.ts"], api=["/sales", "/rate-cut"],
          note="Shares sale posting; wholesale rate-cut and book nuances remain partial.")
map_forms("TR_PURC", "dedicated-current-surface", routes=["/txn/purchase", "/txn/purchase-return"],
          modules=["web/apps/api/src/modules/purchase/purchase.ts", "web/apps/api/src/modules/purchase/purchaseBill.ts",
                   "web/apps/api/src/modules/purchase/purchaseReturn.ts"],
          tests=["web/apps/api/test/purchase.lifecycle.db.test.ts", "web/apps/api/test/purchase.test.ts",
                 "web/apps/api/test/purchaseReturn.test.ts"],
          api=["/purchases", "/purchase-returns"],
          note="Purchase and purchase-return are books of the same desktop purchase voucher form.")
map_forms("TR_PURC_HM", "variant-shared", routes=["/txn/purchase-hm"],
          modules=["web/apps/api/src/modules/purchase/purchase.ts"], tests=["web/apps/api/test/purchase.test.ts"], api=["/purchases"])
map_forms("TR_OTH_PURC", "dedicated-current-surface", routes=["/txn/other-purchase"],
          modules=["web/apps/api/src/modules/purchase/purchase.ts"], tests=["web/apps/api/test/purchase.test.ts"], api=["/other-purchase"])
map_forms("TR_FINE_SL_PR", "dedicated-current-surface", routes=["/txn/fine-sale"],
          modules=["web/apps/api/src/modules/bullion/fineSalePurchase.ts"], tests=["web/apps/api/test/rateCut.test.ts"], api=["/fine-sale"])
map_forms("TR_BILL_TO", "dedicated-current-surface", routes=["/txn/bill-to-bill"],
          modules=["web/apps/api/src/modules/finance/billToBill.ts"], tests=["web/apps/api/test/financeLifecycle.db.test.ts", "web/apps/api/test/financeWriters.test.ts"], api=["/bill-to-bill"])
map_forms("TR_CONTRA", "dedicated-current-surface", routes=["/txn/contra", "/txn/journal"],
          modules=["web/apps/api/src/modules/finance/finance.ts", "web/apps/api/src/modules/finance/journal.ts"],
          tests=["web/apps/api/test/financeLifecycle.db.test.ts", "web/apps/api/test/finance.test.ts"], api=["/contra", "/journal"],
          note="Contra and Journal are books of the same desktop AC_DATA-only voucher engine.")
map_forms("TR_LEDR_ADJ", "dedicated-current-surface", routes=["/txn/ledger-adjust", "/txn/fine-jv"],
          modules=["web/apps/api/src/modules/finance/ledgerAdjust.ts", "web/apps/api/src/modules/finance/fineJv.ts"],
          tests=["web/apps/api/test/financeLifecycle.db.test.ts", "web/apps/api/test/financeWriters.test.ts"], api=["/ledger-adjust", "/fine-jv"],
          note="Money ledger adjust and metal (FINE JV) adjust share the desktop ledger-adjust voucher engine.")
map_forms("TR_EMP_JV", "dedicated-current-surface", routes=["/txn/employee-jv"],
          modules=["web/apps/api/src/modules/finance/employeeJv.ts"], tests=["web/apps/api/test/financeLifecycle.db.test.ts", "web/apps/api/test/financeWriters.test.ts"], api=["/employee-jv"])
map_forms("TR_AC_OPBL", "dedicated-current-surface", routes=["/txn/ac-opbl", "/masters/opening-balance"],
          modules=["web/apps/api/src/modules/finance/acOpening.ts", "web/apps/api/src/modules/masters/openingBalance.ts"],
          tests=["web/apps/api/test/accounting.test.ts"], api=["/accounts", "/ac-opbl", "/masters/opening-balance"])
map_forms("TR_CASH TR_CARD_REC TR_UPI_REC", "variant-shared", routes=["/txn/receipt", "/txn/payment", "/txn/batch-receipt"],
          modules=["web/apps/api/src/modules/finance/finance.ts", "web/apps/api/src/modules/finance/tender.ts"],
          tests=["web/apps/api/test/finance.test.ts", "web/apps/api/test/documents.test.ts"],
          api=["/receipts", "/payments", "/finance/receipt-voucher", "/finance/payment-voucher", "/finance/cheque-print"])
map_forms("TR_DHRN_ISU", "dedicated-current-surface", routes=["/txn/dhrn-issue"],
          modules=["web/apps/api/src/modules/dhrn/dhrn.ts"], tests=["web/apps/api/test/dhrn.test.ts"], api=["/dhrn"])
map_forms("TR_DHRN_REC", "dedicated-current-surface", routes=["/txn/dhrn-receipt"],
          modules=["web/apps/api/src/modules/dhrn/dhrn.ts", "web/apps/api/src/modules/dhrn/dhrnReceipt.ts"],
          tests=["web/apps/api/test/dhrn.test.ts"], api=["/dhrn"])
map_forms("TR_DHRN_INTREC", "dedicated-current-surface", routes=["/txn/dhrn-interest"],
          modules=["web/apps/api/src/modules/dhrn/dhrn.ts"], tests=["web/apps/api/test/dhrn.test.ts"], api=["/dhrn"])
map_forms("TR_KR_ISU", "dedicated-current-surface", routes=["/txn/karigar-issue"],
          modules=["web/apps/api/src/modules/manufacturing/karigar.ts"], tests=["web/apps/api/test/mfgLifecycle.db.test.ts", "web/apps/api/test/karigar.test.ts"], api=["/karigar"])
map_forms("TR_MFG_ISU_REC", "dedicated-current-surface", routes=["/txn/mfg-issue", "/txn/mfg-receive"],
          modules=["web/apps/api/src/modules/manufacturing/mfg.ts"], tests=["web/apps/api/test/mfgLifecycle.db.test.ts", "web/apps/api/test/karigar.test.ts"], api=["/mfg"])
map_forms("TR_MFG_ORD_ISU", "dedicated-current-surface", routes=["/txn/mfg-order-issue"],
          modules=["web/apps/api/src/modules/manufacturing/mfg.ts"], tests=["web/apps/api/test/mfgLifecycle.db.test.ts", "web/apps/api/test/karigar.test.ts"], api=["/mfg"])
map_forms("TR_MLT_PRO", "dedicated-current-surface", routes=["/txn/melting"],
          modules=["web/apps/api/src/modules/manufacturing/meltingPro.ts", "web/apps/api/src/modules/manufacturing/meltingParity.ts",
                   "web/apps/api/src/modules/manufacturing/melting.ts"],
          tests=["web/apps/api/test/meltingPro.db.test.ts", "web/apps/api/test/meltingParity.test.ts", "web/apps/api/test/melting.test.ts"],
          api=["/melting"])
map_forms("TR_FN_INOUT", "dedicated-current-surface", routes=["/txn/fine-inout"],
          modules=["web/apps/api/src/modules/inout/fineInout.ts"], tests=["web/apps/api/test/stock.test.ts"], api=["/inout/fine"])
map_forms("TR_ITM_LOT", "dedicated-current-surface", routes=["/txn/item-lot"],
          modules=["web/apps/api/src/modules/stock/stockVoucherLifecycle.ts", "web/apps/api/src/modules/stock/stock.ts"],
          tests=["web/apps/api/test/stockLifecycle.db.test.ts", "web/apps/api/test/stock.test.ts"], api=["/stock/item-lot"])
map_forms("TR_ITM_OPBL", "dedicated-current-surface", routes=["/txn/item-opening"],
          modules=["web/apps/api/src/modules/stock/stockVoucherLifecycle.ts", "web/apps/api/src/modules/stock/stock.ts"],
          tests=["web/apps/api/test/stockLifecycle.db.test.ts", "web/apps/api/test/stock.test.ts"], api=["/stock/item-opening"])
map_forms("TR_TAG_OPBL", "dedicated-current-surface", routes=["/txn/tag-opening"],
          modules=["web/apps/api/src/modules/stock/stockVoucherLifecycle.ts", "web/apps/api/src/modules/stock/stock.ts"],
          tests=["web/apps/api/test/stockLifecycle.db.test.ts", "web/apps/api/test/stock.test.ts"], api=["/stock/tag-opening"])
map_forms("TR_TAG_CAN", "dedicated-current-surface", routes=["/txn/tag-cancel"],
          modules=["web/apps/api/src/modules/stock/tagOps.ts"], tests=["web/apps/api/test/stock.test.ts"], api=["/stock/tag-cancel"])
map_forms("TR_TAG_WT_DIFF", "dedicated-current-surface", routes=["/txn/tag-weight-diff"],
          modules=["web/apps/api/src/modules/stock/tagOps.ts"], tests=["web/apps/api/test/stock.test.ts"], api=["/stock/tag-weight-diff"])
map_forms("TR_TAG_SPLIT", "dedicated-current-surface", routes=["/txn/tag-split"],
          modules=["web/apps/api/src/modules/stock/tagSplit.ts"], tests=["web/apps/api/test/stock.test.ts"], api=["/stock/tag-split"])
map_forms("TR_PHYSTK", "dedicated-current-surface", routes=["/txn/physical-stock"],
          modules=["web/apps/api/src/modules/stock/physicalStock.ts", "web/apps/api/src/modules/stock/stock.ts"],
          tests=["web/apps/api/test/physicalStock.db.test.ts", "web/apps/api/test/stock.test.ts"], api=["/stock/physical"])
map_forms("TR_BUL_BOOKING", "dedicated-current-surface", routes=["/txn/bullion"],
          modules=["web/apps/api/src/modules/bullion/bullion.ts"], tests=["web/apps/api/test/rateCut.test.ts"], api=["/bullion"])
map_forms("TR_BUL_SALE", "variant-shared", routes=["/txn/bullion", "/txn/rate-cut"],
          modules=["web/apps/api/src/modules/bullion/bullion.ts", "web/apps/api/src/modules/sales/rateCut.ts"],
          tests=["web/apps/api/test/rateCut.test.ts"], api=["/bullion", "/rate-cut"])
map_forms("TR_TOUR", "dedicated-current-surface", routes=["/txn/tour"],
          modules=["web/apps/api/src/modules/tour/tour.ts"], tests=["web/apps/api/test/workflows.test.ts"], api=["/tour"])
map_forms("TR_TOUR_SALE TR_TOUR_ORD TR_APR_ISU", "variant-shared", routes=["/txn/tour", "/txn/tour-return", "/txn/sales-order"],
          modules=["web/apps/api/src/modules/tour/tour.ts", "web/apps/api/src/modules/sales/salesOrder.ts"],
          tests=["web/apps/api/test/workflows.test.ts"], api=["/tour", "/sales-orders"])
map_forms("TR_MEMB_ENT", "dedicated-current-surface", routes=["/txn/membership", "/txn/scheme"],
          modules=["web/apps/api/src/modules/membership/membership.ts", "web/apps/api/src/modules/membership/scheme.ts"],
          tests=["web/apps/api/test/salesFamilyLifecycle.db.test.ts", "web/apps/api/test/scheme.test.ts"], api=["/members", "/scheme"])
map_forms("TR_MEMB_ADJ", "variant-shared", routes=["/txn/membership", "/txn/scheme", "/reports/scheme-adjustments"],
          modules=["web/apps/api/src/modules/membership/membership.ts", "web/apps/api/src/modules/membership/scheme.ts"],
          tests=["web/apps/api/test/salesFamilyLifecycle.db.test.ts", "web/apps/api/test/scheme.test.ts"], api=["/members", "/scheme", "/reports/scheme"])
map_forms("TR_MFG_ITEM", "dedicated-current-surface", routes=["/txn/mfg-issue", "/txn/mfg-receive"],
          modules=["web/apps/api/src/modules/manufacturing/mfg.ts"], tests=["web/apps/api/test/mfgLifecycle.db.test.ts", "web/apps/api/test/karigar.test.ts"], api=["/mfg"])
map_forms("TR_MFG_ORD_REC TR_MFG_GHAT_REC TR_MFG_WITH_LOT", "variant-shared", routes=["/txn/mfg-receive"],
          modules=["web/apps/api/src/modules/manufacturing/mfg.ts"], tests=["web/apps/api/test/mfgLifecycle.db.test.ts", "web/apps/api/test/karigar.test.ts"], api=["/mfg"])
map_forms("TR_MFG_KR_ISU_REC", "variant-shared", routes=["/txn/karigar-issue", "/txn/karigar-receive", "/txn/mfg-issue", "/txn/mfg-receive"],
          modules=["web/apps/api/src/modules/manufacturing/karigar.ts", "web/apps/api/src/modules/manufacturing/mfg.ts"],
          tests=["web/apps/api/test/mfgLifecycle.db.test.ts", "web/apps/api/test/karigar.test.ts"], api=["/karigar", "/mfg"])
map_forms("TR_JDT_REC", "variant-shared", routes=["/txn/jobwork-issue", "/txn/jobwork-receive"],
          modules=["web/apps/api/src/modules/manufacturing/karigar.ts", "web/apps/api/src/modules/manufacturing/mfg.ts"],
          tests=["web/apps/api/test/mfgLifecycle.db.test.ts", "web/apps/api/test/karigar.test.ts"], api=["/karigar", "/mfg"], confidence="medium")
map_forms("TR_INOUT", "variant-shared", routes=["/txn/fine-inout"],
          modules=["web/apps/api/src/modules/inout/fineInout.ts"],
          tests=["web/apps/api/test/stock.test.ts"], api=["/inout"], confidence="medium",
          note="Only the pure fine-metal flavour of desktop Branch In/Out exists (INOUT_DATA/INOUT_DETL); tagged/DM/lot legs, INOUT_IDTL and voucher edit are absent.")
map_forms("TR_PR_SL_HEDG TR_SL_PR_ITEM", "conceptual-engine", routes=["/txn/rate-cut"],
          modules=["web/apps/api/src/modules/sales/rateCut.ts", "web/apps/api/src/modules/bullion/fineSalePurchase.ts"],
          tests=["web/apps/api/test/rateCut.test.ts"], api=["/rate-cut"], confidence="medium",
          note="Absorbed into shared rate-cut logic; no one-to-one desktop form surface.")
map_forms("TR_SL_EBILL", "variant-shared", routes=["/utilities/e-invoice"],
          modules=["web/apps/api/src/modules/einvoice/einvoice.ts"], tests=["web/apps/api/test/einvoice.test.ts", "web/apps/api/test/einvoice_gsp.test.ts"], api=["/einvoice"])
map_forms("TR_REP_REC", "dedicated-current-surface",
          routes=["/txn/repair-receipt", "/txn/repair-karigar-issue", "/txn/repair-karigar-receipt", "/txn/repair-customer-issue"],
          modules=["web/apps/api/src/modules/repair/repairReceipt.ts", "web/apps/api/src/modules/repair/repairImage.ts"],
          tests=["web/apps/api/test/repairReceipt.test.ts", "web/apps/api/test/repairReceipt.db.test.ts", "web/apps/api/test/repairImage.test.ts"],
          api=["/repair-receipts", "/repair-karigar-issues", "/repair-karigar-receipts", "/repair-customer-issues", "/repair-images"],
          note="All four desktop repair books (CUSTREP RECEIPT/KRREP ISSUE/KRREP RECEIPT/CUSTREP ISSUE) have create/read/update/delete plus line images.")
map_forms("TR_GOLD_BOOK", "dedicated-current-surface", routes=["/txn/gold-book"],
          modules=["web/apps/api/src/modules/finance/goldBook.ts"],
          tests=["web/apps/api/test/goldBookLoctAmt.db.test.ts"], api=["/finance/gold-book"])
map_forms("TR_LOCT_AMT", "dedicated-current-surface", routes=["/txn/location-amount"],
          modules=["web/apps/api/src/modules/finance/locationAmount.ts"],
          tests=["web/apps/api/test/goldBookLoctAmt.db.test.ts"], api=["/finance/location-amount"])
map_forms("TR_VP_ADJ", "dedicated-current-surface", routes=["/txn/vp-adjustment"],
          modules=["web/apps/api/src/modules/finance/vpAdjustment.ts"],
          tests=["web/apps/api/test/vpLifecycle.db.test.ts"], api=["/finance/vp-adjustment"])
map_forms("TR_OTH_COMM", "dedicated-current-surface", routes=["/txn/other-commission"],
          modules=["web/apps/api/src/modules/purchase/otherCommission.ts"],
          tests=["web/apps/api/test/otherCommission.db.test.ts"], api=["/other-commission"])
map_forms("TR_VP", "dedicated-current-surface", routes=["/txn/vp-parcel"],
          modules=["web/apps/api/src/modules/sales/vpParcel.ts"],
          tests=["web/apps/api/test/vpParcel.db.test.ts"], api=["/sales/vp-parcel"])
map_forms("TR_WH_SALE_RTN", "dedicated-current-surface", routes=["/txn/wholesale-sale-return"],
          modules=["web/apps/api/src/modules/sales/wholesaleSaleReturn.ts"],
          tests=["web/apps/api/test/wholesaleSaleReturn.db.test.ts"], api=["/sales/wholesale-sale-return"])
map_forms("TR_SALE_RTN_UAE TR_PR_SL_UAE", "no-current-evidence",
          confidence="high", note="No dedicated or proven shared current handler was found; adjacent/generic surfaces do not count.")

# Utilities.
map_forms("UT_WHATSAPP UT_SMS UT_WAPP_WITH_API", "variant-shared", routes=["/integrations"],
          modules=["web/apps/api/src/modules/integrations/messaging.ts"], tests=["web/apps/api/test/whatsapp.test.ts", "web/apps/api/test/integrations.test.ts"], api=["/integrations"])
map_forms("UT_E_INVOICE", "dedicated-current-surface", routes=["/utilities/e-invoice"],
          modules=["web/apps/api/src/modules/einvoice/einvoice.ts"], tests=["web/apps/api/test/einvoice.test.ts", "web/apps/api/test/einvoice_gsp.test.ts"], api=["/einvoice"])
map_forms("UT_VCH_RE_NUMBR", "dedicated-current-surface", routes=["/utilities/voucher-renumber"],
          modules=["web/apps/api/src/modules/utilities/voucherRenumber.ts"], api=["/utilities/vch-renumber", "/voucher-renumber"])
map_forms("UT_REMINDER", "variant-shared", routes=["/utilities/reminders", "/utilities/reminder-entry", "/txn/reminders"],
          modules=["web/apps/api/src/modules/utilities/reminderEntry.ts", "web/apps/api/src/modules/finance/reminders.ts"], api=["/reminder"])
map_forms("UT_BKP", "dedicated-current-surface", routes=["/backup"], modules=["web/apps/api/src/modules/ops/backup.ts"], api=["/backup"])
map_forms("UT_IMPORT UT_EXPORT", "variant-shared", routes=["/backup", "/masters/accounts"],
          modules=["web/apps/api/src/modules/masters/master.service.ts", "web/apps/api/src/modules/ops/backup.ts"], api=["/masters", "/backup"], confidence="medium")
map_forms("UT_SETTING UT_SETTING_MAIN UT_SET_ADMIN", "variant-shared", routes=["/settings", "/admin/users"],
          modules=["web/apps/api/src/modules/settings/settings.ts", "web/apps/api/src/modules/rbac/formRights.ts"],
          tests=["web/apps/api/test/rbac.policy.test.ts"], api=["/settings", "/admin/users"])
map_forms("UT_CUST_ENTRY", "variant-shared", routes=["/masters/party"], modules=["web/apps/api/src/modules/masters/party.ts"], api=["/party"], confidence="medium")
map_forms("UT_BANK", "variant-shared", routes=["/txn/bank-recon"], modules=["web/apps/api/src/modules/finance/bankRecon.ts"], tests=["web/apps/api/test/financeLifecycle.db.test.ts", "web/apps/api/test/finance.test.ts"], api=["/bank-recon"])
map_forms("UT_PWD_UPDATE", "conceptual-engine", routes=["/login"], modules=["web/apps/api/src/modules/auth/password.ts"], tests=["web/apps/api/test/auth.password.test.ts"], api=["/auth"],
          note="Password primitive exists, but forced-reset workflow is absent.")
map_forms("UT_AI_TRFR", "variant-shared", routes=["/txn/tag-transfer", "/txn/counter-transfer"], modules=["web/apps/api/src/modules/stock/stock.ts"], tests=["web/apps/api/test/stock.test.ts"], api=["/stock"])
map_forms("UT_TAG_PRINT", "dedicated-current-surface", routes=["/txn/tag-print"], modules=["web/apps/api/src/modules/stock/tagPrint.ts", "web/apps/api/src/modules/integrations/barcode.ts"], tests=["web/apps/api/test/barcode.test.ts"], api=["/stock/tag-print"])
map_forms("UT_REPORT", "generic-report-scaffold", routes=["/reports/report-layouts"], modules=["web/apps/api/src/modules/reports/reportEngine.ts"], tests=["web/apps/api/test/reportEngine.test.ts"], api=["/reports/layout"], confidence="medium")
map_forms("UT_HDD", "dedicated-current-surface", routes=["/utilities/hdd-registry"],
          modules=["web/apps/api/src/modules/utilities/hddRegistry.ts"],
          tests=["web/apps/api/test/utilities.db.test.ts"], api=["/utilities/hdd-registry"])
map_forms("UT_USER_REQUEST", "dedicated-current-surface", routes=["/utilities/user-request"],
          modules=["web/apps/api/src/modules/utilities/userRequest.ts"],
          tests=["web/apps/api/test/utilities.db.test.ts"], api=["/utilities/user-requests"])
map_forms("UT_WINDOW", "dedicated-current-surface", routes=["/utilities/window-tiles"],
          modules=["web/apps/api/src/modules/utilities/windowTiles.ts"],
          tests=["web/apps/api/test/utilities.db.test.ts"], api=["/utilities/window-tiles"],
          note="Source-proven read-only TILE_DATA dashboard with active-user USER_SET view rights.")
map_forms("UT_WEB_CAM", "no-current-evidence", confidence="high",
          note="Local camera capture is documented as a device-bridge waiver.")

# Report launcher forms are conceptual/generic. Specific route concepts are mapped without claiming dialog parity.
REPORT_FORM_ROUTES: dict[str, list[str]] = {
    "RP_ALL": ["/reports/report-layouts"],
    "RP_BALANCE": ["/reports/balance-sheet", "/reports/account-balances"],
    "RP_BAL_ZOOM": ["/reports/account-balances"], "RP_CASH_BANK": ["/reports/cash-book"],
    "RP_CUST": ["/reports/customer-crm"], "RP_CUST_CRM": ["/reports/customer-crm"],
    "RP_DAY_WORK": ["/reports/day-book"], "RP_DHRN_LOAN": ["/reports/dhrn-outstanding"],
    "RP_DHRN_OS": ["/reports/dhrn-outstanding"], "RP_EMP": ["/reports/employee-sales"],
    "RP_GRAPH": ["/reports/daily-sales", "/reports/top-items"],
    "RP_GST": ["/reports/gstr1", "/reports/gstr2", "/reports/gstr3b"],
    "RP_HUID": ["/reports/tag-stock"], "RP_INOUT": ["/reports/item-stock-ledger"],
    "RP_JDTR_ZOOM": ["/reports/karigar-ledger"], "RP_LC_INOUT": ["/reports/stock-by-location"],
    "RP_LC_SALE": ["/reports/location-wise-sales"], "RP_LEDR": ["/reports/account-ledger"],
    "RP_MFG_LEDR": ["/reports/karigar-ledger"], "RP_MOVEMENT": ["/reports/item-stock-ledger"],
    "RP_OS": ["/reports/outstanding", "/reports/bill-outstanding"],
    "RP_PHY_STOCK": ["/txn/physical-stock"], "RP_REMINDER": ["/utilities/reminders"],
    "RP_ROJMEL": ["/reports/day-book"],
    "RP_SLPR_ZOOM": ["/reports/sales-register", "/reports/purchase-register"],
    "RP_STK_LEVEL": ["/reports/item-group-stock"], "RP_STK_MOVE": ["/reports/item-stock-ledger"],
    "RP_STOCK": ["/reports/stock-valuation"], "RP_STOCK_FINE": ["/reports/stock-valuation"],
    "RP_STOCK_VALUE": ["/reports/stock-valuation"], "RP_TAG": ["/reports/tag-stock"],
    "RP_TAG_ESTMATE": ["/reports/report-layouts"], "RP_TAG_IMAGE": ["/reports/report-layouts"],
    "RP_TAX": ["/reports/hsn-summary", "/reports/gst-input-register"],
}

# Other/support classes absorbed by current engines.
map_forms("Ac_Final", "conceptual-engine", routes=["/utilities/year-end", "/reports/balance-sheet"], modules=["web/apps/api/src/modules/ops/yearEnd.ts", "web/apps/api/src/modules/accounting/accounting.ts"], tests=["web/apps/api/test/accounting.test.ts"], api=["/year-end", "/reports/balance"])
map_forms("Ac_Ledr Module_Save", "conceptual-engine", modules=["web/apps/api/src/modules/posting/posting.ts", "web/apps/api/src/modules/accounting/accounting.ts"], tests=["web/apps/api/test/posting.test.ts", "web/apps/api/test/accounting.test.ts"])
map_forms("Ac_Stock ClassTagList TagOthDetail", "conceptual-engine", routes=["/txn/stock", "/reports/tag-stock"], modules=["web/apps/api/src/modules/stock/stock.ts"], tests=["web/apps/api/test/stock.test.ts"], api=["/stock", "/reports/tag-stock"])
map_forms("Ac_Tax", "conceptual-engine", routes=["/reports/gstr1", "/reports/gstr2", "/reports/gstr3b"], modules=["web/apps/api/src/modules/gst/gst.ts"], tests=["web/apps/api/test/gst.test.ts"], api=["/reports/gstr", "/gst"])
map_forms("Ac_Rojmel", "conceptual-engine", routes=["/reports/day-book"], modules=["web/apps/api/src/modules/reports/reports.ts"], tests=["web/apps/api/test/reports.test.ts"], api=["/reports/day-book"])
map_forms("Ac_Image", "variant-shared", routes=["/masters/party", "/txn/tag-print"], modules=["web/apps/api/src/modules/masters/party.ts", "web/apps/api/src/modules/stock/tagPrint.ts"], api=["/party", "/stock/tag-print"], confidence="medium")
map_forms("Mfg_Module", "conceptual-engine", routes=["/txn/mfg-issue", "/txn/mfg-receive"], modules=["web/apps/api/src/modules/manufacturing/mfg.ts"], tests=["web/apps/api/test/mfgLifecycle.db.test.ts", "web/apps/api/test/karigar.test.ts"], api=["/mfg"])
map_forms("BtmSchm Module_Schm", "conceptual-engine", routes=["/txn/scheme"], modules=["web/apps/api/src/modules/membership/scheme.ts"], tests=["web/apps/api/test/salesFamilyLifecycle.db.test.ts", "web/apps/api/test/scheme.test.ts"], api=["/scheme"])
map_forms("MDI_FORM DC_Main", "conceptual-engine", routes=["/dashboard"], modules=["web/apps/web/components/Shell.tsx", "web/apps/web/lib/nav.ts"], tests=[], api=["/me", "/integrations/live-rates"])
map_forms("Module_WhatsApp", "conceptual-engine", routes=["/integrations"], modules=["web/apps/api/src/modules/integrations/messaging.ts"], tests=["web/apps/api/test/whatsapp.test.ts"], api=["/integrations"])
EINVOICE_CLASSES = "ClsAddlDocDtls ClsAttribDtls ClsBchDtls ClsBuyerDtls ClsContrDtls ClsDispDtls ClsDocDtls ClsDocPerdDtls ClsExpDtls ClsPayDtls ClsPrecDocDtls ClsRefDtls ClsSellerDtls ClsShipDtls ClsTranDtls ClsValDtls ErrorResp IRNClass IRNData PolicyModels"
map_forms(EINVOICE_CLASSES, "conceptual-engine", routes=["/utilities/e-invoice"], modules=["web/apps/api/src/modules/einvoice/einvoice.ts"], tests=["web/apps/api/test/einvoice.test.ts"], api=["/einvoice"], confidence="medium")
map_forms("AuthClass AuthError", "conceptual-engine", routes=["/login"], modules=["web/apps/api/src/modules/auth/auth.service.ts", "web/apps/api/src/modules/auth/jwt.ts"], tests=["web/apps/api/test/auth.service.test.ts"], api=["/auth"], confidence="medium")
map_forms("Data DcClass DcPrintClass ClsItemList Translator OlockerService", "no-current-evidence", confidence="medium",
          note="Desktop helper/integration class has no proved one-to-one current web implementation; equivalent behavior must be accepted at engine level if intentional.")

for _waived_form, _waiver in WAIVED_FORMS.items():
    assert _waived_form in FORM_MAP, f"waived form is not mapped: {_waived_form}"
    FORM_MAP[_waived_form]["classification"] = "waived-documented"
    FORM_MAP[_waived_form]["confidence"] = "high"
    FORM_MAP[_waived_form]["mappingNote"] = f"{_waiver['rationale']} See {_waiver['path']}."


FORM_BLOCKERS: dict[str, list[str]] = defaultdict(list)
for name in "TR_SALE TR_PURC TR_SALE_RTN TR_SALE_HM TR_PURC_HM TR_WH_SALE TR_WH_SALE_RTN TR_OTH_PURC".split():
    FORM_BLOCKERS[name] += ["C1-loose-stock", "C2-server-derived-reversal", "C4-workflow-fine-policy"]
for name in "TR_SALE TR_PURC TR_SALE_RTN TR_PURC_HM TR_TAG_OPBL TR_TAG_CAN TR_TAG_SPLIT TR_TAG_WT_DIFF".split():
    FORM_BLOCKERS[name] += ["H3-tag-concurrency"]
for name in "TR_PURC TR_KR_ISU TR_MFG_KR_ISU_REC TR_ITM_OPBL TR_MLT_PRO MS_UPDATE".split():
    FORM_BLOCKERS[name] += ["C4-workflow-fine-policy"]
for name in "MS_LOGIN MS_USER UT_PWD_UPDATE UT_SET_ADMIN UT_SETTING UT_SETTING_MAIN".split():
    FORM_BLOCKERS[name] += ["H1-api-form-rbac", "H6-password-session"]
for name in "UT_BKP".split():
    FORM_BLOCKERS[name] += ["OPS-backup-restore"]

CRITICAL_FORMS = set("TR_SALE TR_PURC TR_SALE_RTN TR_CASH TR_CONTRA TR_BILL_TO TR_AC_OPBL TR_ITM_OPBL TR_TAG_OPBL TR_TAG_CAN TR_TAG_SPLIT TR_KR_ISU TR_MFG_ISU_REC MS_COMPANY MS_YEAR MS_USER MS_LOGIN".split())
SECURITY_FORMS = {"MS_LOGIN", "MS_USER", "UT_PWD_UPDATE", "UT_SET_ADMIN"}


def form_severity(name: str, module: str) -> str:
    if name in CRITICAL_FORMS:
        return "critical"
    if module == "transaction":
        return "high"
    if name in SECURITY_FORMS or name in {"UT_BKP", "UT_SETTING", "UT_SETTING_MAIN", "MS_ACCT", "MS_BOOK"}:
        return "high"
    if module in {"master", "utility", "report"}:
        return "medium"
    return "low"


def form_dependencies(name: str, module: str) -> list[str]:
    deps = ["QA-DESKTOP-HARNESS"]
    if module in {"transaction", "master", "utility", "report"}:
        deps += ["FOUNDATION-SCOPE", "FOUNDATION-RBAC", "FOUNDATION-RLS"]
    if module == "transaction":
        deps += ["ENGINE-NUMBERING", "ENGINE-POSTING", "QA-DB-INTEGRATION"]
    if name.startswith("TR_TAG") or name in {"TR_SALE", "TR_PURC", "TR_SALE_RTN", "TR_ITM_OPBL", "TR_PHYSTK"}:
        deps += ["ENGINE-STOCK-TAGS"]
    if name in {"TR_SALE", "TR_PURC", "TR_KR_ISU", "TR_MFG_ISU_REC", "TR_MLT_PRO", "TR_ITM_OPBL", "MS_UPDATE"}:
        deps += ["ENGINE-FINE-POLICY"]
    if module == "report" or name in {"UT_REPORT", "DcPrintClass"}:
        deps += ["ENGINE-REPORTS-PDF"]
    if name in {"UT_WEB_CAM", "UT_TAG_PRINT", "UT_HDD"}:
        deps += ["DEVICE-BRIDGE"]
    return list(dict.fromkeys(deps))


def form_acceptance(name: str, module: str, tables: list[str], keys: list[str]) -> list[str]:
    base = [
        "Approve a source-linked desktop behavior contract including validation and error paths.",
        "Enforce active scope and per-form action rights on the API, not only in navigation.",
    ]
    if module == "transaction":
        base += [
            "Run real-PostgreSQL create/edit/delete/reversal tests and diff every owned table: " + (", ".join(tables[:12]) or "none cataloged") + ".",
            "Prove balanced money/metal legs, atomic rollback, lock-date rejection and concurrent voucher identity.",
        ]
    elif module == "master":
        base += ["Match field set, auto-code, uniqueness, focus order, delete restrictions and dependent updates."]
    elif module == "report":
        base += ["Match filters, dataset rows, grouping/totals, pagination and PDF image output against desktop."]
    elif module == "utility":
        base += ["Exercise success, cancellation, failure recovery, audit and least-privilege paths."]
    else:
        base += ["Prove equivalent engine behavior or record an approved architecture-level replacement mapping."]
    if keys:
        base.append("Compare desktop keyboard/focus behavior for: " + ", ".join(keys[:12]) + ".")
    base.append("Attach desktop comparison artifacts before G5; attach operational/UAT evidence before G6.")
    return base


# Load authoritative desktop catalogs.
MODULE_MAP = load_json(ROOT / "project-memory/catalogs/module-map.json")
FORM_LOGIC_DIR = ROOT / "project-memory/catalogs/form-logic"
FORM_BEHAVIOR_DIR = ROOT / "project-memory/catalogs/form-behavior"
FORM_LAYOUT_DIR = ROOT / "project-memory/catalogs/layouts"
WEB_FORM_SPEC_DIR = ROOT / "web/apps/api/form-specs"

# Index layout/form preview files by the embedded form name when possible.
def index_form_json(directory: Path) -> dict[str, list[str]]:
    idx: dict[str, list[str]] = defaultdict(list)
    if not directory.exists():
        return idx
    for path in sorted(directory.glob("*.json")):
        try:
            data = load_json(path)
        except Exception:
            data = {}
        if not isinstance(data, dict):
            continue  # initcomp/index manifests are not form assets
        embedded = data.get("form")
        name = str(embedded or path.name.split(".")[0]).split(".")[-1]
        idx[name].append(rel(path))
    return idx


DESKTOP_LAYOUTS = index_form_json(FORM_LAYOUT_DIR)
WEB_FORM_SPECS = index_form_json(WEB_FORM_SPEC_DIR)

# Report launcher default mapping must be applied after the form universe is known.
for form_name, info in MODULE_MAP["forms"].items():
    if info["module"] == "report" and form_name not in FORM_MAP:
        routes = REPORT_FORM_ROUTES.get(form_name, ["/reports/report-layouts"])
        cls = "conceptual-report-engine" if form_name in REPORT_FORM_ROUTES else "generic-report-scaffold"
        map_forms(form_name, cls, routes=routes,
                  modules=["web/apps/api/src/modules/reports/reportEngine.ts", "web/apps/api/src/modules/reports/reports.ts"],
                  tests=["web/apps/api/test/reports.test.ts", "web/apps/api/test/reportEngine.test.ts"], api=["/reports"],
                  confidence="medium" if form_name in REPORT_FORM_ROUTES else "low",
                  note="Desktop report dialog is represented by computed/generic report engines, not a one-to-one ported dialog.")

# Any remaining helper class is explicitly no-current-evidence rather than silently omitted.
for form_name in MODULE_MAP["forms"]:
    if form_name not in FORM_MAP:
        map_forms(form_name, "no-current-evidence", confidence="low", note="No verified current mapping; requires explicit equivalence decision.")


CONTRACT_DIR = ROOT / "project-memory/contracts"


def form_contract(name: str) -> tuple[str | None, bool]:
    """Return (contract path, approved) for a per-form behavior contract.

    A contract only counts toward G2 when it exists AND carries an explicit
    `Status: approved` line, so drafting a file never inflates the gate.
    """
    path = CONTRACT_DIR / f"{name}.contract.md"
    if not path.exists():
        return None, False
    text = path.read_text(encoding="utf-8", errors="ignore")
    approved = re.search(r"^Status:\s*approved\s*$", text, re.I | re.M) is not None
    return rel(path), approved


def csharp_keys(text: str) -> list[str]:
    names = set(re.findall(r"Keys\.(F\d+|Enter|Escape|Tab|Delete|Insert|Space)", text))
    names.update(re.findall(r"KeyCode\s*==\s*Keys\.(F\d+|Enter|Escape|Tab|Delete|Insert|Space)", text))
    return sorted(names, key=lambda x: (not x.startswith("F"), int(x[1:]) if x.startswith("F") and x[1:].isdigit() else 999, x))


def csharp_reports(text: str) -> list[str]:
    return sorted(dict.fromkeys(m.group(1) for m in re.finditer(r"([A-Za-z0-9_ -]+\.rpt)", text, re.I)))


def load_g5_form_artifacts() -> tuple[dict[str, str], str]:
    """Load only complete, retained zero-diff form artifacts; reports never imply form credit."""
    artifact_root = ROOT / G5_ARTIFACT_ROOT
    qualified: dict[str, str] = {}
    if artifact_root.exists():
        for path in sorted(artifact_root.glob("*/*.json")):
            if path.name == "report.json":
                continue
            try:
                item = load_json(path)
            except (OSError, json.JSONDecodeError):
                continue
            if not isinstance(item, dict):
                continue
            form_id = str(item.get("formId", "")).strip()
            zero_diff = (
                item.get("verdict") == "zero-diff"
                and item.get("completed") is True
                and item.get("columnDiffCount") == 0
                and item.get("numericSumDiff") == 0
                and item.get("footprintDiffCount") == 0
            )
            if form_id and zero_diff:
                qualified[form_id] = rel(path)
    current_mode = "NOT_RUN"
    latest = ROOT / G5_LATEST_PATH
    if latest.exists():
        try:
            report = load_json(latest)
            if isinstance(report, dict):
                current_mode = str(report.get("mode") or "UNKNOWN")
        except (OSError, json.JSONDecodeError):
            current_mode = "INVALID_ARTIFACT"
    return qualified, current_mode


G5_FORM_ARTIFACTS, G5_CURRENT_MODE = load_g5_form_artifacts()

forms: list[dict[str, Any]] = []
for name, catalog in sorted(MODULE_MAP["forms"].items()):
    source = ROOT / "unified" / catalog["file"]
    behavior = FORM_BEHAVIOR_DIR / f"{name}.behavior.json"
    logic = FORM_LOGIC_DIR / f"{name}.logic.json"
    source_text = source.read_text(encoding="utf-8", errors="ignore") if source.exists() else ""
    logic_data = load_json(logic) if logic.exists() else {}
    behavior_data = load_json(behavior) if behavior.exists() else {}
    write_tables = sorted(set(catalog.get("tablesInserted", [])) | set(catalog.get("tablesUpdated", [])) | set(catalog.get("tablesDeleted", [])))
    all_tables = sorted(set(write_tables) | set(logic_data.get("tables", [])) | set(logic_data.get("selectTables", [])))
    keys = csharp_keys(source_text)
    reports_ref = csharp_reports(source_text)
    mapping = FORM_MAP[name]
    contract_path, contract_approved = form_contract(name)
    frontend_files = sorted(dict.fromkeys(x for x in (route_file(r) for r in mapping["frontendRoutes"]) if x))
    api_modules = existing(mapping["apiModules"])
    mapped_test_files = existing(mapping["testFiles"])
    direct_name_test_files = containing(TEST_FILES, name)
    if catalog["module"] in {"transaction", "master", "utility"} and mapping["classification"] != "no-current-evidence":
        qualifying_test_files = mapped_test_files
    else:
        qualifying_test_files = []
    api_routes = select_api(mapping["apiPrefixes"])
    desktop_evidence = existing([source, behavior, logic]) + DESKTOP_LAYOUTS.get(name, [])
    waiver = WAIVED_FORMS.get(name)
    implementation_evidence = frontend_files + api_modules + WEB_FORM_SPECS.get(name, [])
    if waiver:
        implementation_evidence.append(waiver["path"])
    impl_status = (
        "waived"
        if waiver
        else ("not_started" if mapping["classification"] == "no-current-evidence" else "in_progress")
    )
    test_status = "in_progress" if qualifying_test_files else "not_started"
    blockers = list(dict.fromkeys(FORM_BLOCKERS.get(name, [])))
    if catalog["module"] in {"transaction", "master", "utility", "report"}:
        blockers += ["C5-authoritative-scope", "H1-api-form-rbac"]
    if catalog["module"] == "transaction":
        blockers += ["C3-numbering-concurrency", "H2-period-lock-reversal", "QA-no-real-posting-tests"]
    if catalog["module"] == "report":
        blockers += ["H7-report-fidelity", "H10-no-desktop-comparison"]
    blockers = list(dict.fromkeys(blockers))
    forms.append({
        "id": name,
        "unitType": "form",
        "category": catalog["module"],
        "severity": form_severity(name, catalog["module"]),
        "mappingClassification": mapping["classification"],
        "mappingConfidence": mapping["confidence"],
        "mappingNote": mapping["mappingNote"],
        "desktop": {
            "source": rel(source), "sourceExists": source.exists(),
            "behaviorSpec": rel(behavior) if behavior.exists() else None,
            "logicSpec": rel(logic) if logic.exists() else None,
            "layoutSpecs": DESKTOP_LAYOUTS.get(name, []),
            "loc": behavior_data.get("loc") or logic_data.get("loc"),
            "gridColumnCount": len(behavior_data.get("gridColumns", {})),
            "calculationCount": len(behavior_data.get("calc", [])),
            "validationCount": len(behavior_data.get("validations", [])),
            "keyboardKeys": keys,
            "tables": all_tables,
            "writeTables": write_tables,
            "reportsReferenced": reports_ref,
        },
        "web": {
            "frontendRoutes": mapping["frontendRoutes"],
            "frontendFiles": frontend_files,
            "apiRoutes": api_routes,
            "apiModules": api_modules,
            "layoutPreviewSpecs": WEB_FORM_SPECS.get(name, []),
            "mappedDomainTests": mapped_test_files,
            "directNameTestMatches": direct_name_test_files,
            "tests": qualifying_test_files,
            "testLimitation": "Mapped unit/builder evidence only; no current default test invokes real DB posting/reversal/tenant transaction functions." if qualifying_test_files else ("Related engine tests exist but do not directly identify this form." if mapped_test_files else "No mapped test evidence."),
        },
        "gates": {
            "extracted": gate("passed", desktop_evidence, "Canonical decompiled source and behavior evidence are present."),
            "understood": gate(
                "passed" if contract_approved else "in_progress",
                existing([behavior, logic]) + DESKTOP_LAYOUTS.get(name, []) + ([contract_path] if contract_path else []),
                "Approved per-form behavior contract cites desktop source for fields, focus, validation, calculations, write set and reversal."
                if contract_approved
                else (
                    "A draft contract exists but is not marked `Status: approved`; automated behavior/logic/layout evidence alone does not prove complete semantics."
                    if contract_path
                    else "Automated behavior/logic/layout evidence exists, but no per-form approved contract and desktop vectors prove complete semantics."
                ),
            ),
            "implemented": gate(
                impl_status,
                implementation_evidence,
                f"Documented architecture waiver: {waiver['rationale']}" if waiver else
                "Current surfaces are evidence of progress only; generic/shared/conceptual mappings are not one-to-one desktop parity.",
            ),
            "tested": gate(test_status, qualifying_test_files,
                           "Qualifying tests are still unit/builder-level; G4 requires real database, authorization, failure, concurrency and invariant coverage.", "test_id"),
            "desktop_compared": (
                gate(
                    "passed",
                    [G5_FORM_ARTIFACTS[name]],
                    "Retained G5 per-form artifact records completed footprint, column, and numeric checks with a zero-diff verdict.",
                    "test_id",
                )
                if name in G5_FORM_ARTIFACTS
                else gate(
                    "not_started",
                    [],
                    "No retained completed zero-diff per-form artifact exists under project-memory/parity/g5/.",
                )
            ),
            "production_certified": gate("not_started", [], "No form-specific load, DR, device/site UAT and production sign-off exists."),
        },
        "blockers": blockers,
        "dependencies": form_dependencies(name, catalog["module"]),
        "acceptanceChecks": form_acceptance(name, catalog["module"], write_tables, keys),
    })


APPROVED_CONTRACTS = sum(1 for f in forms if f["gates"]["understood"]["status"] == "passed")
DRAFT_CONTRACTS = sum(
    1
    for f in forms
    if f["gates"]["understood"]["status"] != "passed"
    and any(str(e.get("uri", "")).startswith("project-memory/contracts/") for e in f["gates"]["understood"]["evidence"])
)

# ---------------------------------------------------------------------------
# Table matrix (146 authoritative desktop tables + separate web-only list).
# ---------------------------------------------------------------------------
SCHEMA = load_json(ROOT / "project-memory/catalogs/realdb-schema-full.json")
PRISMA_PATH = ROOT / "web/packages/db/prisma/schema.prisma"
PRISMA_TEXT = PRISMA_PATH.read_text(encoding="utf-8", errors="ignore")
MODEL_BLOCKS = re.findall(r"(?ms)^model\s+(\w+)\s*\{(.*?)^\}", PRISMA_TEXT)
PRISMA_TABLES: dict[str, str] = {}
for model, body in MODEL_BLOCKS:
    match = re.search(r'@@map\("([^\"]+)"\)', body)
    PRISMA_TABLES[match.group(1) if match else model] = model
MIGRATIONS = sorted((ROOT / "web/packages/db/prisma/migrations").glob("*/migration.sql"))
MIGRATION_TEXT = "\n".join(p.read_text(encoding="utf-8", errors="ignore") for p in MIGRATIONS)
RLS_PATH = ROOT / "web/packages/db/prisma/rls.sql"
RLS_TEXT = RLS_PATH.read_text(encoding="utf-8", errors="ignore")

TABLE_BLOCKERS: dict[str, list[str]] = {
    "MAIN_STOCK": ["C1-loose-stock", "C2-server-derived-reversal", "H3-tag-concurrency"],
    "TAG_STOCK": ["C2-server-derived-reversal", "H3-tag-concurrency"],
    "BAR_DETL": ["C2-server-derived-reversal", "H3-tag-concurrency"],
    "BAR_IDTL": ["C2-server-derived-reversal", "H3-tag-concurrency"],
    "SRNO_MAST": ["C3-numbering-concurrency"],
    "CO_MAST": ["C5-authoritative-scope"], "LOCT_MAST": ["C5-authoritative-scope"],
    "YEAR_MAST": ["C5-authoritative-scope"], "USER_SET": ["H1-api-form-rbac"],
    "CO_SET": ["C4-workflow-fine-policy", "H2-period-lock-reversal", "ROUNDING-policy"],
    "SL_DATA": ["C1-loose-stock", "C2-server-derived-reversal", "C4-workflow-fine-policy"],
    "SL_DETL": ["C1-loose-stock", "C2-server-derived-reversal", "C4-workflow-fine-policy"],
    "PR_DATA": ["C1-loose-stock", "C2-server-derived-reversal", "C4-workflow-fine-policy"],
    "PR_DETL": ["C1-loose-stock", "C2-server-derived-reversal", "C4-workflow-fine-policy"],
    "AC_DATA": ["POSTING-money-metal-balance"], "BILL_OS_DATA": ["POSTING-bill-allocation"],
    "TAX_DATA": ["POSTING-gst-register"],
}
CRITICAL_TABLES = set(TABLE_BLOCKERS) | {"KR_DATA", "KR_DETL", "MFG_DATA", "DHRN_DATA", "DHRN_ISU_DATA", "DHRN_REC_DATA"}

def table_ref_forms(table: str) -> list[str]:
    return [f["id"] for f in forms if table in f["desktop"]["tables"]]


tables: list[dict[str, Any]] = []
for table, schema_info in sorted(SCHEMA["tables"].items()):
    model = PRISMA_TABLES.get(table)
    migration_refs = [rel(p) for p in MIGRATIONS if table in p.read_text(encoding="utf-8", errors="ignore")]
    api_refs = containing(WEB_SOURCE_FILES, table)
    test_refs = containing(TEST_FILES, table)
    rls_enable = bool(re.search(rf'ALTER TABLE\s+"?{re.escape(table)}"?\s+ENABLE ROW LEVEL SECURITY', RLS_TEXT, re.I))
    rls_force = bool(re.search(rf'ALTER TABLE\s+"?{re.escape(table)}"?\s+FORCE ROW LEVEL SECURITY', RLS_TEXT, re.I))
    rls_policy = bool(re.search(rf'ON\s+"?{re.escape(table)}"?', RLS_TEXT, re.I))
    physical = bool(migration_refs)
    implementation_refs = ([rel(PRISMA_PATH)] if model else []) + migration_refs + api_refs
    tables.append({
        "id": table, "unitType": "table", "category": "desktop-table",
        "severity": "critical" if table in CRITICAL_TABLES else ("high" if api_refs else "medium"),
        "desktop": {
            "schema": rel(ROOT / "project-memory/catalogs/realdb-schema-full.json"),
            "columnCount": len(schema_info.get("columns", [])), "primaryKey": schema_info.get("pk"),
            "referencingForms": table_ref_forms(table),
        },
        "web": {
            "prismaModel": model, "prismaMapped": model is not None,
            "migrationRefs": migration_refs, "physicalMigrationEvidence": physical,
            "rawMigrationOnly": physical and model is None,
            "rls": {"enable": rls_enable, "force": rls_force, "policy": rls_policy},
            "sourceRefs": api_refs, "testRefs": test_refs,
            "usageClassification": "runtime-referenced" if api_refs else ("model-or-migration-only" if physical or model else "absent"),
        },
        "gates": {
            "extracted": gate("passed", [rel(ROOT / "project-memory/catalogs/realdb-schema-full.json")], "Authoritative restored schema records columns/defaults/keys."),
            "understood": gate("in_progress", [rel(ROOT / "project-memory/catalogs/realdb-schema-full.json")], "Structure is extracted; full business semantics, lifecycle and ownership still require approved contracts."),
            "implemented": gate("in_progress" if physical or model else "not_started", implementation_refs,
                                "Physical/model presence is schema progress, not behavior or parity."),
            "tested": gate("in_progress" if test_refs else "not_started", test_refs,
                           "Direct source-token test reference only; table lifecycle requires real DB create/reverse/isolation checks.", "test_id"),
            "desktop_compared": gate("not_started", [], "No seeded desktop-to-web per-table row/checksum reconciliation artifact exists."),
            "production_certified": gate("not_started", [], "No migration/restore/load/retention certification for this table exists."),
        },
        "blockers": TABLE_BLOCKERS.get(table, []) + (["SCHEMA-prisma-raw-drift"] if physical and model is None else []),
        "dependencies": ["FOUNDATION-RLS", "SCHEMA-MIGRATION-OWNERSHIP", "QA-DB-INTEGRATION", "QA-DESKTOP-HARNESS"],
        "acceptanceChecks": [
            "Reconcile authoritative columns/types/defaults/business keys with migration and Prisma metadata.",
            "Prove tenant plus active company/location/year scope and least-privilege access.",
            "Exercise create/update/delete/reversal and failure rollback in real PostgreSQL.",
            "Diff seeded desktop/web rows and business-key aggregates; certify backup/restore.",
        ],
    })

DESKTOP_TABLE_SET = set(SCHEMA["tables"])
web_only_tables = [
    {"table": table, "prismaModel": model, "sourceRefs": containing(WEB_SOURCE_FILES, table),
     "note": "Web-only table; requires architecture, retention, RLS and migration justification."}
    for table, model in sorted(PRISMA_TABLES.items()) if table not in DESKTOP_TABLE_SET
]

# ---------------------------------------------------------------------------
# 255 supplied Crystal binaries + 20 source-referenced but absent obligations.
# ---------------------------------------------------------------------------
REPORT_DIR = ROOT / "unified/reports"
PROJECT_REPORT_SPEC_DIR = ROOT / "project-memory/catalogs/report-layouts"
WEB_REPORT_SPEC_DIR = ROOT / "web/apps/api/report-specs"
REPORT_INDEX = {x["report"].lower(): x for x in load_json(PROJECT_REPORT_SPEC_DIR / "report-layouts-index.json")}
WEB_REPORT_INDEX_PATH = WEB_REPORT_SPEC_DIR / "report-layouts-index.json"
WEB_REPORT_INDEX = {x["report"].lower(): x for x in load_json(WEB_REPORT_INDEX_PATH)}
RECON = load_json(ROOT / "project-memory/catalogs/report-reconciliation.json")
MISSING_REPORTS = [x["report"] for x in RECON.get("stillMissing", [])]
PROJECT_SPECS = {p.name[:-10].lower(): p for p in PROJECT_REPORT_SPEC_DIR.glob("*.spec.json")}
WEB_SPECS = {p.name[:-10].lower(): p for p in WEB_REPORT_SPEC_DIR.glob("*.spec.json")}
XML_FILES: dict[str, Path] = {}
for p in (ROOT / "extraction_output").rglob("*.xml"):
    XML_FILES.setdefault(p.stem.lower(), p)

REPORT_TEST_FILES = [p for p in TEST_FILES if any(x in p.name.lower() for x in ("report", "render", "document", "crystal"))]
REPORT_CONTRACT_TEST = ROOT / "web/apps/api/test/reportContract.test.ts"
REPORT_RENDER_TEST = ROOT / "web/apps/api/test/reportRender.db.test.ts"
reports: list[dict[str, Any]] = []


def report_row(name: str, rpt: Path | None, absent: bool = False) -> dict[str, Any]:
    key = name.lower().removesuffix(".rpt")
    display = rpt.stem if rpt else name.removesuffix(".rpt")
    project_spec = PROJECT_SPECS.get(key)
    web_spec = WEB_SPECS.get(key)
    xml = XML_FILES.get(key)
    project_data: dict[str, Any] = {}
    web_data: dict[str, Any] = {}
    if project_spec:
        try: project_data = load_json(project_spec)
        except Exception: project_data = {}
    if web_spec:
        try: web_data = load_json(web_spec)
        except Exception: web_data = {}
    blob = json.dumps(project_data, sort_keys=True)
    families = [family for family in ("SL_DATA", "PR_DATA", "KR_DATA") if family in blob]
    detected = families[0] if families else "SL_DATA_DEFAULT_UNSAFE"
    object_types = Counter()
    for area in project_data.get("areas", []):
        for section in area.get("sections", []):
            for obj in section.get("objects", []):
                object_types[str(obj.get("type", "unknown"))] += 1
    direct_source_refs = quoted_refs(WEB_SOURCE_FILES, display)
    direct_tests = quoted_refs(REPORT_TEST_FILES, display)
    if web_data.get("areas") and REPORT_CONTRACT_TEST.exists():
        direct_tests.append(rel(REPORT_CONTRACT_TEST))
    direct_tests = sorted(dict.fromkeys(direct_tests))
    waiver = WAIVED_REPORTS.get(display)
    if absent:
        extract_status, extract_note = "evidence_gap", "Desktop source references this RPT, but no supplied binary/layout exists in any provided root."
    elif display == "TagStkIdtlRpt":
        extract_status, extract_note = "waived", waiver["rationale"] if waiver else "RPT binary exists, but no XML/layout could be extracted without a compatible Crystal runtime."
    elif display == "SalesQuotation":
        extract_status, extract_note = "in_progress", "Truncated XML was recovered partially: 30 sections, 155 objects, 34 formulas; the exact tail remains explicitly waived."
    else:
        extract_status, extract_note = "passed", "RPT binary and complete extracted layout spec are present."
    web_usable = bool(web_data.get("areas"))
    impl_status = "in_progress" if web_usable or direct_source_refs else ("waived" if waiver else "not_started")
    if absent:
        impl_status = "blocked"
    extraction_uris = existing([p for p in (rpt, xml, project_spec) if p])
    if waiver:
        extraction_uris = sorted(dict.fromkeys(extraction_uris + [waiver["path"]]))
    implementation_uris = existing([p for p in (web_spec,) if p]) + direct_source_refs
    if impl_status == "waived" and waiver:
        implementation_uris.append(waiver["path"])
    implementation_uris = sorted(dict.fromkeys(implementation_uris))
    blockers = ["H7-report-fidelity", "H10-no-desktop-comparison"]
    if absent: blockers.append("EVIDENCE-absent-rpt")
    if display == "SalesQuotation": blockers.append("WAIVER-partial-salesquotation-extraction")
    if display == "TagStkIdtlRpt": blockers.append("WAIVER-crystal-runtime-required")
    if detected == "SL_DATA_DEFAULT_UNSAFE": blockers.append("H7-unknown-report-defaults-to-sales")
    return {
        "id": display, "unitType": "report", "category": "absent-referenced" if absent else "supplied-crystal",
        "severity": "high" if absent or not web_usable or display in {"SalesQuotation", "TagStkIdtlRpt"} else "medium",
        "desktop": {
            "rptBinary": rel(rpt) if rpt else None, "rptPresent": bool(rpt),
            "xml": rel(xml) if xml else None, "layoutSpec": rel(project_spec) if project_spec else None,
            "layoutStatus": "absent" if absent else ("unavailable" if display == "TagStkIdtlRpt" else ("partial" if display == "SalesQuotation" else "complete")),
            "sections": project_data.get("sectionCount") or REPORT_INDEX.get(key, {}).get("sections", 0),
            "objects": project_data.get("objectCount") or REPORT_INDEX.get(key, {}).get("objects", 0),
            "formulas": project_data.get("formulaCount") or REPORT_INDEX.get(key, {}).get("formulas", 0),
            "objectTypes": dict(sorted(object_types.items())),
            "referencedFamilies": families,
        },
        "web": {
            "layoutSpec": rel(web_spec) if web_spec else None, "layoutIndexed": key in WEB_REPORT_INDEX,
            "layoutUsable": web_usable, "layoutPreviewRoute": f"/reports/report-layouts?report={display}",
            "directSourceRefs": direct_source_refs, "directTests": direct_tests,
            "currentBinderFamily": detected,
            "binderRisk": "Unknown families silently use sales tables." if detected == "SL_DATA_DEFAULT_UNSAFE" else "Only header/detail aliases for SL/PR/KR are supported.",
        },
        "gates": {
            "extracted": gate(extract_status, extraction_uris, extract_note),
            "understood": gate("blocked" if absent else "in_progress", extraction_uris,
                               "Geometry/formulas are evidence; dataset semantics, groups, print state and expected output are not fully approved."),
            "implemented": gate(impl_status, implementation_uris,
                                "A layout preview/generic binder is progress only; it lacks full Crystal data/formula/pagination/image behavior."),
            "tested": (
                gate("in_progress", direct_tests,
                     "The all-spec data-contract test proves token classification/schema resolution; named DB smoke cases additionally prove seeded value rendering.", "test_id")
                if direct_tests
                else gate("waived", [waiver["path"]], waiver["rationale"], "test_id")
                if waiver
                else gate("not_started", [], "No report-specific or all-spec contract evidence exists.", "test_id")
            ),
            "desktop_compared": gate("not_started", [], "No desktop PDF/image diff exists for this report."),
            "production_certified": gate("not_started", [], "No real-container Chromium, printer/media, load and business sign-off evidence exists."),
        },
        "blockers": blockers,
        "dependencies": ["ENGINE-REPORTS-PDF", "REPORT-DATA-CONTRACTS", "QA-DESKTOP-HARNESS", "OPS-CHROMIUM-READINESS"],
        "acceptanceChecks": [
            "Approve exact parameters, dataset/query, formula/group/suppression/running-total semantics.",
            "Render with production Chromium and fail loudly when unavailable; never return fake PDF success.",
            "Compare normalized data and desktop/web PDF images over representative pages/copies.",
            "Certify fonts, page setup, barcode/image/subreport behavior and physical printer output where applicable.",
        ],
    }


for rpt in sorted(REPORT_DIR.glob("*.rpt"), key=lambda p: p.name.lower()):
    reports.append(report_row(rpt.stem, rpt))
for missing in sorted(MISSING_REPORTS, key=str.lower):
    reports.append(report_row(missing, None, absent=True))

# ---------------------------------------------------------------------------
# Settings and keyboard contracts.
# ---------------------------------------------------------------------------
SETTINGS_PATH = ROOT / "project-memory/catalogs/settings-catalog.json"
SETTINGS = load_json(SETTINGS_PATH)
settings: list[dict[str, Any]] = []
HIGH_SETTINGS = {"LOCK_DATE", "FINE_STK_TYPE", "DHRN_INT_TYPE", "LOAN_INT_TYPE", "INT_YEAR_DAYS", "INT_DAY", "RATE_PAR", "SL_AMT_TYPE", "TAX_ROF", "LBR_ROF", "ITM_RATE_ROF", "WEIGHT_PORT", "TAG_RPT"}
for item in SETTINGS["settings"]:
    key = item["key"]
    desktop_refs: list[str] = []
    for p in sorted((ROOT / "unified/src/csharp/DataCareNext").glob("*.cs")):
        if key in p.read_text(encoding="utf-8", errors="ignore"):
            desktop_refs.append(rel(p))
            if len(desktop_refs) >= 20: break
    web_refs = containing(WEB_SOURCE_FILES, key)
    registry_ref = "web/apps/api/src/modules/settings/settings.ts"
    consumer_refs = [
        x for x in web_refs
        if x != registry_ref and "/prisma/" not in x and "/migrations/" not in x and not x.endswith(".sql")
    ]
    test_refs = containing(TEST_FILES, key)
    waiver = WAIVED_SETTINGS.get(key)
    settings.append({
        "id": key, "unitType": "setting", "category": "CO_SET", "severity": "high" if key in HIGH_SETTINGS else "medium",
        "desktop": {"type": item.get("type"), "inSettingsForm": item.get("inForm"), "caption": item.get("caption"), "sourceRefs": desktop_refs},
        "web": {"registryRefs": web_refs, "consumerRefs": consumer_refs, "testRefs": test_refs, "genericStorageEndpoint": "/settings"},
        "gates": {
            "extracted": gate("passed", [rel(SETTINGS_PATH)] + desktop_refs, "Setting is cataloged from CO_SET and desktop source."),
            "understood": gate("in_progress", desktop_refs, "Type/reference extraction does not yet prove defaults, scope, precedence and all consumers."),
            # Measurement integrity: appearing in the editable settings registry is NOT an
            # implementation. Only a consumer outside the registry actually forks behavior.
            "implemented": (
                gate("waived", [waiver["path"]], waiver["rationale"])
                if waiver
                else gate("in_progress" if consumer_refs else "not_started", consumer_refs or web_refs,
                          "Editable registry/storage alone is not implementation; only consumerRefs prove workflow code applies the key.")
            ),
            "tested": gate("in_progress" if test_refs else "not_started", test_refs, "Requires behavior vectors for enabled/disabled/default combinations.", "test_id"),
            "desktop_compared": gate("not_started", [], "No desktop scenario comparison for this setting exists."),
            "production_certified": gate("not_started", [], "No configuration migration, validation and operational sign-off exists."),
        },
        "blockers": ["SETTINGS-runtime-policy"] + (["C4-workflow-fine-policy"] if "FINE" in key or "ROF" in key else []) + (["H2-period-lock-reversal"] if key == "LOCK_DATE" else []),
        "dependencies": ["SETTINGS-TYPED-REGISTRY", "QA-DESKTOP-HARNESS"],
        "acceptanceChecks": ["Define typed scope/default/precedence and all consuming workflows.", "Test each branch against desktop vectors and reject invalid production values."],
    })

SHORTCUT_DEFS = {
    "F1": "lookup/help picker", "F2": "form-specific edit/action", "F3": "form-specific action",
    "F4": "form-specific action", "F5": "refresh/search/action", "F7": "form-specific action",
    "F8": "form-specific action", "F9": "form-specific action", "F11": "form-specific action",
    "F12": "form-specific action", "Enter": "advance/commit", "Escape": "close/cancel/tender",
    "Ctrl+Enter": "web save shortcut requiring desktop policy confirmation",
}
CS_FILES = sorted((ROOT / "unified/src/csharp/DataCareNext").glob("*.cs"))
WEB_KEY_FILES = [p for p in WEB_SOURCE_FILES if p.suffix in {".ts", ".tsx"}]
shortcuts: list[dict[str, Any]] = []
for key, action in SHORTCUT_DEFS.items():
    if key == "Ctrl+Enter":
        desktop_refs = []
        web_refs = [rel(p) for p in WEB_KEY_FILES if re.search(r"ctrlKey|metaKey", TEXT.get(p, ""), re.I) and "Enter" in TEXT.get(p, "")]
    else:
        cs_pattern = re.compile(rf"Keys\.{re.escape(key)}\b")
        desktop_refs = [rel(p) for p in CS_FILES if cs_pattern.search(p.read_text(encoding="utf-8", errors="ignore"))]
        web_refs = [rel(p) for p in WEB_KEY_FILES if re.search(rf"['\"]{re.escape(key)}['\"]", TEXT.get(p, ""))]
    # Frontend keyboard evidence: pure decision tables plus the real browser workflow.
    if key == "Ctrl+Enter":
        frontend_test_refs = [
            rel(p) for p in TEST_FILES
            if re.search(r"ctrlKey|metaKey|Control\+Enter", TEXT.get(p, ""), re.I)
        ]
    else:
        # A test may name the key quoted ('F3') or as an object key (F3:) in a decision table.
        frontend_test_refs = [
            rel(p) for p in TEST_FILES
            if re.search(rf"(['\"]{re.escape(key)}['\"]|\b{re.escape(key)}\s*:)", TEXT.get(p, ""))
        ]
    shortcuts.append({
        "id": key, "unitType": "shortcut", "category": "keyboard", "severity": "medium",
        "desktop": {"action": action, "sourceRefs": desktop_refs, "occurrenceFiles": len(desktop_refs)},
        "web": {"sourceRefs": web_refs, "frontendTestRefs": frontend_test_refs},
        "gates": {
            "extracted": gate("passed" if desktop_refs or key == "Ctrl+Enter" else "in_progress", desktop_refs,
                              "Key occurrences are cataloged; action remains form-context dependent."),
            "understood": gate("in_progress", desktop_refs, "Per-form preconditions, focus transitions and conflicts require approved contracts."),
            "implemented": gate("in_progress" if web_refs else "not_started", web_refs, "Source handling exists only for listed web files and is not global parity."),
            "tested": gate(
                "in_progress" if frontend_test_refs else "not_started", frontend_test_refs,
                "Frontend decision-table/browser assertions exist; G4 still needs per-form focus traces.",
                "test_id",
            ),
            "desktop_compared": gate("not_started", [], "No scripted desktop/web focus trace comparison exists."),
            "production_certified": gate("not_started", [], "No supported-browser/site keyboard UAT exists."),
        },
        "blockers": ["UX-keyboard-focus-parity"], "dependencies": ["UI-DESKTOP-SHELL", "QA-BROWSER-E2E", "QA-DESKTOP-HARNESS"],
        "acceptanceChecks": ["Specify action and focus result per form/state.", "Automate browser key/focus traces and compare with desktop recordings."],
    })

# ---------------------------------------------------------------------------
# Cross-cutting invariants: release-blocking regardless of aggregate progress.
# ---------------------------------------------------------------------------
INVARIANT_DEFS = [
    ("scope-tenant", "Tenant isolation", "passed", "passed", [], ["web/packages/db/src/tenant.ts", "web/packages/db/prisma/rls.sql", "web/packages/db/test/verify_runtime.sql", "web/apps/api/src/modules/ops/health.ts", "web/.github/workflows/ci.yml"]),
    ("scope-company-location-year-book", "Authoritative company/location/year/book scope", "passed", "passed", [], ["web/apps/api/src/modules/auth/businessScope.ts", "web/apps/api/src/app.ts", "web/apps/api/src/routes/txn.ts", "web/apps/api/test/businessScope.test.ts", "web/apps/api/test/app.security.db.test.ts", "web/apps/web/components/BusinessScope.tsx", "web/apps/web/components/BookSelect.tsx"]),
    ("rbac-form-action", "USER_SET per-form View/Edit/Delete/Print API enforcement", "passed", "passed", [], ["web/apps/api/src/modules/rbac/authorization.ts", "web/apps/api/src/modules/rbac/formRights.ts", "web/apps/api/src/modules/rbac/routePolicy.ts", "web/apps/api/test/rbac.authorization.test.ts", "web/apps/api/test/routePolicy.test.ts", "web/apps/api/test/app.security.db.test.ts"]),
    ("voucher-numbering", "Per-tenant/company/location/year/book unique numbering under concurrency", "in_progress", "in_progress", ["C3-numbering-concurrency"], ["web/apps/api/src/modules/vouchers/numbering.ts", "web/apps/api/test/numbering.test.ts"]),
    ("period-lock", "Fail-closed lock date for create/edit/delete/reversal", "in_progress", "not_started", ["H2-period-lock-reversal"], ["web/apps/api/src/modules/posting/posting.ts"]),
    ("money-ledger-balance", "ΣDr = ΣCr on every posting and reversal", "in_progress", "in_progress", ["QA-no-real-posting-tests"], ["web/apps/api/src/modules/posting/posting.ts", "web/apps/api/test/posting.test.ts"]),
    ("metal-ledger-balance", "Independent gold/silver/fine ledger balance", "in_progress", "not_started", ["C4-workflow-fine-policy"], ["web/apps/api/src/modules/shared/fine.ts"]),
    ("fine-policy", "Workflow-specific fine formula and rounding policy", "in_progress", "in_progress", ["C4-workflow-fine-policy"], ["web/apps/api/src/modules/shared/fine.ts", "web/packages/core/src/index.ts"]),
    ("stock-signed-movement", "Every tagged and loose line emits correct signed MAIN_STOCK movement", "in_progress", "not_started", ["C1-loose-stock"], ["web/apps/api/src/modules/stock/stock.ts", "web/apps/api/src/modules/sales/sales.ts", "web/apps/api/src/modules/purchase/purchase.ts"]),
    ("tag-single-consumption", "Tag can be consumed once under concurrency", "in_progress", "not_started", ["H3-tag-concurrency"], ["web/apps/api/src/modules/stock/stock.ts"]),
    ("server-reversal", "Server derives complete reversal from persisted voucher state", "in_progress", "not_started", ["C2-server-derived-reversal"], ["web/apps/api/src/modules/sales/sales.ts", "web/apps/api/src/modules/purchase/purchase.ts", "web/apps/web/components/VoucherList.tsx"]),
    ("posting-atomicity", "Voucher, ledgers, tax, bill, stock, tags and audit commit/rollback atomically", "in_progress", "not_started", ["QA-no-real-posting-tests"], ["web/packages/db/src/tenant.ts", "web/apps/api/src/modules/posting/posting.ts"]),
    ("rounding-policy", "Book/company-configured monetary and weight rounding", "in_progress", "in_progress", ["ROUNDING-policy"], ["web/packages/core/src/index.ts"]),
    ("gst-tax", "GST place-of-supply split, registers and statutory reconciliation", "in_progress", "in_progress", ["QA-no-desktop-gst-comparison"], ["web/apps/api/src/modules/gst/gst.ts", "web/apps/api/test/gst.test.ts"]),
    ("bill-outstanding", "Bill allocation/outstanding lifecycle and reversal", "in_progress", "in_progress", ["POSTING-bill-allocation"], ["web/apps/api/src/modules/finance/billToBill.ts"]),
    ("report-fidelity", "Crystal dataset/formula/group/pagination/image/font fidelity", "in_progress", "in_progress", ["H7-report-fidelity", "H10-no-desktop-comparison"], ["web/apps/api/src/modules/reports/reportEngine.ts", "web/apps/api/src/modules/reports/crystalFormula.ts", "web/apps/api/src/modules/reports/reportBind.ts"]),
    ("pdf-runtime", "Real PDF renderer is mandatory and ready in production image", "passed", "passed", [], ["web/apps/api/src/modules/reports/render.ts", "web/apps/api/src/modules/ops/health.ts", "web/apps/api/test/health.test.ts", "web/Dockerfile.api", "web/.github/workflows/ci.yml"]),
    ("password-session", "Password migration/reset, strong JWT secret, refresh/revocation and secure cookies", "passed", "passed", [], ["web/apps/api/src/modules/auth/password.ts", "web/apps/api/src/modules/auth/passwordAccount.ts", "web/apps/api/src/modules/auth/jwt.ts", "web/apps/api/src/modules/auth/session.ts", "web/apps/api/src/modules/ops/runtimeConfig.ts", "web/apps/api/test/auth.jwt.test.ts", "web/apps/api/test/auth.session.test.ts", "web/apps/api/test/app.runtime.test.ts", "web/apps/api/test/app.security.db.test.ts", "web/apps/web/app/login/page.tsx", "web/apps/web/app/password-change/page.tsx"]),
    ("schema-migration-rls", "Schema, audit_log, RLS and roles are migration-owned and startup-verified", "passed", "in_progress", [], ["web/packages/db/prisma/schema.prisma", "web/packages/db/prisma/rls.sql", "web/packages/db/prisma/migrations/20260715010000_runtime_schema_security/migration.sql", "web/packages/db/prisma/migrations/20260715020000_schema_model_convergence/migration.sql", "web/packages/db/prisma/migrations/20260715030000_authoritative_scope_rbac_sessions/migration.sql", "web/packages/db/test/verify_runtime.sql", "web/.github/workflows/ci.yml"]),
    ("audit-durability", "Immutable tenant-isolated audit trail with observable failures", "passed", "passed", [], ["web/apps/api/src/modules/ops/audit.ts", "web/apps/api/test/audit.test.ts", "web/packages/db/setup_roles.sql", "web/packages/db/test/verify_runtime.sql", "web/.github/workflows/ci.yml"]),
    ("hardware-bridge", "Scale, webcam/scanner and printer bridge with site certification", "not_started", "not_started", ["DEVICE-no-bridge"], []),
    ("external-services", "Rates, e-invoice, SMS/WhatsApp certified with idempotency/reconciliation", "in_progress", "in_progress", ["INTEGRATION-live-certification"], ["web/apps/api/src/modules/integrations", "web/apps/api/src/modules/einvoice"]),
    ("observability-readiness", "Structured logs, metrics/traces, readiness and invariant alerts", "in_progress", "in_progress", ["OPS-observability"], ["web/apps/api/src/app.ts", "web/apps/api/src/modules/ops/health.ts", "web/apps/api/test/health.test.ts"]),
    ("backup-dr", "Offsite backup, automated restore drill and approved RPO/RTO", "in_progress", "not_started", ["OPS-backup-restore"], ["web/deploy/backup.sh"]),
    ("qa-concurrency-migration", "CI applies migrations/RLS and runs integration/concurrency/visual/load suites", "in_progress", "in_progress", ["QA-missing-live-suites"], ["web/.github/workflows/ci.yml", "web/packages/db/test/verify_runtime.sql"]),
]
invariants: list[dict[str, Any]] = []
for ident, title, impl, tested, blockers, refs in INVARIANT_DEFS:
    refs_existing = existing(refs)
    invariants.append({
        "id": ident, "unitType": "invariant", "category": "cross-cutting", "title": title, "severity": "critical",
        "gates": {
            "extracted": gate("passed", ["project-memory/parity/DESKTOP-ERP-EVIDENCE-MODEL.md"], "Desktop invariant is recorded in the authoritative evidence model."),
            "understood": gate("passed", ["project-memory/parity/DESKTOP-ERP-EVIDENCE-MODEL.md", "project-memory/parity/WEB-IMPLEMENTATION-AUDIT.md"], "Desktop contract and current web risk are explicitly documented."),
            "implemented": gate(
                impl,
                refs_existing,
                "Implementation and deployment evidence closes the invariant's current web blocker."
                if impl == "passed"
                else "Current implementation evidence is incomplete or contains the linked blocker.",
            ),
            "tested": gate(
                tested,
                [x for x in refs_existing if "/test/" in x],
                "CI-invoked integration evidence exercises the real dependency and failure boundary."
                if tested == "passed"
                else "A passing unit test does not satisfy the remaining integration/concurrency/desktop checks.",
                "test_id",
            ),
            "desktop_compared": gate("not_started", [], "No end-to-end desktop comparison artifact exists."),
            "production_certified": gate("not_started", [], "No production/site/DR sign-off exists."),
        },
        "blockers": blockers,
        "dependencies": ["QA-DB-INTEGRATION", "QA-DESKTOP-HARNESS", "OPS-PRODUCTION-GATES"],
        "acceptanceChecks": ["Close every linked blocker with reproducible test evidence.", "Pass desktop comparison before any financial/inventory pilot.", "Pass operational/security/site certification before production."],
    })


# ---------------------------------------------------------------------------
# Summaries and exports.
# ---------------------------------------------------------------------------
# ---------------------------------------------------------------------------
# Depth: does the web persist what the desktop persists, and can every grid
# column be captured? Breadth gates alone scored a 20-of-97-column voucher the
# same as a complete one, which is how measured coverage drifted to ~52%.
# ---------------------------------------------------------------------------
import test_depth_metrics  # noqa: E402  (fixture guard for the write-set parser)

_parser_failures = test_depth_metrics.run_cases()
assert not _parser_failures, (
    "depth parser self-test failed, so depth numbers would be under-reported: "
    + "; ".join(_parser_failures)
)

DEPTH = depth_metrics.compute({row["id"]: row["web"].get("frontendFiles") or [] for row in forms})

for _row in forms:
    _metrics = DEPTH["forms"].get(_row["id"])
    if _metrics:
        _row["depthMetrics"] = _metrics

DEPTH_BASELINE_PATH = OUT_DIR / "depth-baseline.json"
_previous = load_json(DEPTH_BASELINE_PATH) if DEPTH_BASELINE_PATH.exists() else {}
_regressions = []
for _row in forms:
    _metrics = _row.get("depthMetrics")
    if not _metrics or _metrics.get("columnCoveragePct") is None:
        continue
    _before = (_previous.get("forms") or {}).get(_row["id"])
    if _before is not None and _metrics["columnCoveragePct"] < _before - 0.05:
        _regressions.append(f"{_row['id']}: {_before}% -> {_metrics['columnCoveragePct']}%")
assert not _regressions, "depth ratchet: column coverage may never decrease -> " + "; ".join(_regressions)

DEPTH_BASELINE = {
    "generatedAt": GENERATED_AT,
    "overallColumnCoveragePct": DEPTH["summary"]["overallColumnCoveragePct"],
    "forms": {
        r["id"]: r["depthMetrics"]["columnCoveragePct"]
        for r in forms
        if r.get("depthMetrics") and r["depthMetrics"].get("columnCoveragePct") is not None
    },
}
for _fid, _pct in ((_previous.get("forms") or {}).items()):
    DEPTH_BASELINE["forms"].setdefault(_fid, _pct)
    DEPTH_BASELINE["forms"][_fid] = max(DEPTH_BASELINE["forms"][_fid], _pct)
DEPTH_BASELINE_PATH.write_text(json.dumps(DEPTH_BASELINE, indent=2) + "\n", encoding="utf-8")

ALL_UNITS = forms + tables + reports + settings + shortcuts + invariants

for _row in ALL_UNITS:
    if _row["unitType"] == "form":
        _metrics = _row.get("depthMetrics")
        _approved = _row["gates"]["understood"]["status"] == "passed"
        if _row["gates"]["implemented"]["status"] == "waived":
            _status, _note = "waived", "Unit is a documented architecture waiver; depth is not applicable."
        elif not _metrics or not _metrics.get("desktopWrittenColumns"):
            # No desktop write set: either the desktop form persists nothing (read-only lookup,
            # dialog, engine) or the logic catalog is missing. These are different problems and
            # must not be reported as identical pending work.
            if _row["desktop"].get("logicSpec"):
                _status = "waived"
                _note = "Desktop logic catalog records no INSERT/UPDATE for this form, so there is no write set to match."
            else:
                _status = "evidence_gap"
                _note = "No desktop logic catalog exists for this form, so persistence depth cannot be measured."
        else:
            _status, _note = depth_metrics.gate_status(_metrics, contract_approved=_approved)
        _uris = [p for p in ([_row["desktop"].get("logicSpec")] if _row["desktop"].get("logicSpec") else []) if p]
        _row["gates"]["depth"] = gate(_status, _uris + ["project-memory/parity/DEEP-COLUMN-AUDIT.json"], _note)
    elif _row["unitType"] == "table":
        _t = DEPTH["tables"].get(_row["id"])
        if not _t:
            _row["gates"]["depth"] = gate(
                "not_started",
                ["project-memory/parity/DEEP-COLUMN-AUDIT.json"],
                "No desktop form writes this table, so there is no write set to match.",
            )
        elif not _t["webWritesTableAtAll"]:
            _row["gates"]["depth"] = gate(
                "not_started",
                ["project-memory/parity/DEEP-COLUMN-AUDIT.json"],
                f"Desktop writes {_t['desktopWrittenColumns']} columns here; the web never writes this table.",
            )
        elif (_t["coveragePct"] or 0) >= 99:
            _row["gates"]["depth"] = gate(
                "passed",
                ["project-memory/parity/DEEP-COLUMN-AUDIT.json"],
                f"Web persists {_t['coveragePct']}% of the desktop write set.",
            )
        else:
            _row["gates"]["depth"] = gate(
                "in_progress",
                ["project-memory/parity/DEEP-COLUMN-AUDIT.json"],
                f"Web persists {_t['coveragePct']}% of {_t['desktopWrittenColumns']} desktop columns; "
                f"{_t['missingColumnCount']} missing.",
            )
    else:
        _row["gates"]["depth"] = gate(
            "waived",
            [],
            "Depth is measured as voucher write-set and grid completeness; it does not apply to this unit type.",
        )

    # Implementation cannot be certified complete while depth is incomplete.
    if _row["gates"]["implemented"]["status"] == "passed" and _row["gates"]["depth"]["status"] not in {"passed", "waived"}:
        _row["gates"]["implemented"] = gate(
            "in_progress",
            [e["uri"] for e in _row["gates"]["implemented"].get("evidence", [])],
            _row["gates"]["implemented"]["note"] + " Depth is incomplete, so implementation is not complete.",
        )

    _row["gates"] = {g: _row["gates"][g] for g in GATE_NAMES}

# ---------------------------------------------------------------------------
# Measurement self-check (Workstream A). The matrix is the instrument used to
# certify parity, so it must refuse to silently under- or over-credit work.
#   1. Every declared API route is either claimed by a desktop unit row or is a
#      declared cross-cutting/infrastructure route.
#   2. Every claimed route actually exists in the parsed route universe.
# New business routes therefore fail the generator until they are mapped.
# ---------------------------------------------------------------------------
INFRA_ROUTE_ALLOWLIST: set[tuple[str, str]] = {
    ("GET", "/health"), ("GET", "/ready"),
    ("GET", "/lookup/:entity"), ("GET", "/vouchers/recent"),
    ("POST", "/render/pdf"), ("GET", "/audit"),
    ("GET", "/ops/metrics"), ("GET", "/ops/invariants"),
    ("GET", "/admin/form-catalog"), ("GET", "/forms/layouts"), ("GET", "/forms/layout"),
}
claimed_routes: set[tuple[str, str]] = set()
for _row in ALL_UNITS:
    for _api in (_row.get("web") or {}).get("apiRoutes", []) or []:
        claimed_routes.add((_api["method"], _api["path"]))
declared_routes = {(r["method"], r["path"]) for r in API_ROUTES}
orphan_routes = sorted(declared_routes - claimed_routes - INFRA_ROUTE_ALLOWLIST)
assert not orphan_routes, f"unmapped API routes (map them to a desktop unit or the infra allowlist): {orphan_routes}"
phantom_routes = sorted(claimed_routes - declared_routes)
assert not phantom_routes, f"claimed routes that do not exist: {phantom_routes}"
assert not (INFRA_ROUTE_ALLOWLIST - declared_routes), "infra allowlist references routes that no longer exist"

# Voucher-lifecycle self-measurement: desktop vouchers must support create/read/edit/delete.
LIFECYCLE_SPLIT = {"full": [], "createOnly": [], "noWrite": []}
for _row in forms:
    if _row["category"] != "transaction":
        continue
    _methods = {a["method"] for a in _row["web"]["apiRoutes"]}
    if not _methods & {"POST", "PUT", "PATCH"}:
        LIFECYCLE_SPLIT["noWrite"].append(_row["id"])
    elif {"POST", "PUT", "DELETE"} <= _methods:
        LIFECYCLE_SPLIT["full"].append(_row["id"])
    else:
        LIFECYCLE_SPLIT["createOnly"].append(_row["id"])
assert sum(len(v) for v in LIFECYCLE_SPLIT.values()) == 61

def status_counts(rows: list[dict[str, Any]]) -> dict[str, dict[str, int]]:
    return {g: dict(sorted(Counter(r["gates"][g]["status"] for r in rows).items())) for g in GATE_NAMES}


def surface_summary(rows: list[dict[str, Any]]) -> dict[str, Any]:
    compared = sum(r["gates"]["desktop_compared"]["status"] == "passed" for r in rows)
    certified = sum(r["gates"]["production_certified"]["status"] == "passed" for r in rows)
    return {
        "units": len(rows), "gateStatusCounts": status_counts(rows),
        "desktopParityUnits": compared, "desktopParityPercent": round(compared * 100 / len(rows), 2) if rows else 0,
        "productionCertifiedUnits": certified,
    }

form_categories = Counter(f["category"] for f in forms)
form_mapping = Counter(f["mappingClassification"] for f in forms)
form_mapping_by_category: dict[str, dict[str, int]] = {}
for category in sorted(form_categories):
    form_mapping_by_category[category] = dict(sorted(Counter(
        f["mappingClassification"] for f in forms if f["category"] == category
    ).items()))
report_layouts = Counter(r["desktop"]["layoutStatus"] for r in reports)
report_binders = Counter(r["web"]["currentBinderFamily"] for r in reports if r["category"] == "supplied-crystal")
raw_only = [t["id"] for t in tables if t["web"]["rawMigrationOnly"]]

matrix = {
    "metadata": {
        "title": "DataCareNext desktop-to-web parity matrix",
        "version": "1.0",
        "generatedAt": GENERATED_AT,
        "generator": rel(Path(__file__)),
        "workspaceRoot": str(ROOT),
        "sourceCommit": None,
        "freshnessBasis": "Workspace is not a Git repository; evidence is current file content and generator execution time.",
        "authoritativeDesktopModel": "project-memory/parity/DESKTOP-ERP-EVIDENCE-MODEL.md",
        "currentWebAudit": "project-memory/parity/WEB-IMPLEMENTATION-AUDIT.md",
    },
    "gateModel": {
        "monotonic": True,
        "statuses": sorted(VALID_STATUSES),
        "gates": {
            "extracted": "Canonical source/schema/layout exists, or an explicit evidence gap is recorded.",
            "understood": "Approved fields, focus/keys, validation, calculations, writes, reversal and report semantics exist.",
            "depth": "Persists >=99% of the desktop write set with no unwritten desktop table, >=95% grid-column coverage and an approved contract. Breadth without depth is not parity.",
            "implemented": "Complete reachable UI/API/DB/report/security/integration behavior exists; routes/models/generic renderers alone do not pass.",
            "tested": "CI invokes real functions and dependencies across unit, invariant, integration, authorization, concurrency, migration and failure paths.",
            "desktop_compared": "Scripted desktop and web workflows have zero/approved row, calculation, keyboard and visual/PDF differences.",
            "production_certified": "Load, security, observability, backup/restore, DR, device/site UAT and business sign-off pass.",
        },
        "antiInflationRules": [
            "Headline state is the lowest unmet gate; gates are never averaged.",
            "Parity percentage means only units with desktop_compared=passed.",
            "No artifact means no gate credit.",
            "Routes, pages, models, LOC, nav ready flags, builds and mock/unit tests are engineering progress only.",
            "Critical invariants and financial forms independently block release regardless of aggregate counts.",
            "The terms parity, pixel-exact, verified and certified require G5 artifacts for the relevant unit.",
        ],
    },
    "integrationDecisions": WAIVED_INTEGRATIONS,
    "g5Harness": {
        "runnerPath": G5_RUNNER_PATH,
        "artifactPath": G5_LATEST_PATH,
        "currentMode": G5_CURRENT_MODE,
        "externalInputsRequired": G5_EXTERNAL_INPUTS,
    },
    "g6Status": {
        "certified": False,
        "artifactPath": G6_STATUS_PATH,
        "productionCertifiedUnits": 0,
        "totalUnits": len(ALL_UNITS),
        "requirements": G6_REQUIREMENTS,
    },
    "engineeringProgressNotParity": {
        "frontendPages": len(list((ROOT / "web/apps/web/app").rglob("page.tsx"))),
        "declaredApiRoutes": len(API_ROUTES),
        "apiTestFiles": len(list((ROOT / "web/apps/api/test").glob("*.test.ts"))),
        "prismaModels": len(MODEL_BLOCKS),
        "prismaMappedTables": sum(1 for _, body in MODEL_BLOCKS if "@@map(" in body),
        "webReportSpecs": len(WEB_SPECS),
        "webFormLayoutAssetFiles": sum(len(v) for v in WEB_FORM_SPECS.values()),
        "webFormLayoutDistinctFormIds": len(WEB_FORM_SPECS),
        # Coverage must be measured against forms that actually HAVE a desktop layout. 41 of the 204
        # catalogued units are helper classes, DTOs and engines (Cls*, Module_*, Ac_* engines,
        # DC_Main, Translator, ...) with zero WinForms layout code - verified: no `.Location` calls
        # and no InitializeComponent form body. Counting them made coverage look incomplete.
        "desktopLayoutBearingForms": len([f for f in forms if DESKTOP_LAYOUTS.get(f["id"])]),
        "webFormLayoutCoveragePercent": round(
            len(WEB_FORM_SPECS) * 100 / max(1, len([f for f in forms if DESKTOP_LAYOUTS.get(f["id"])])), 1
        ),
        "webFormLayoutCoveragePercentOfAllUnits": round(len(WEB_FORM_SPECS) * 100 / 204, 1),
        "frontendTestFiles": 0,
        "approvedFormContracts": APPROVED_CONTRACTS,
        "draftFormContracts": DRAFT_CONTRACTS,
        "note": "These counts must never be summed into parity or certification.",
    },
    "integrationReadiness": {
        "question": "Which hardware and third-party integrations work now, and what is each one waiting for?",
        "module": "web/apps/api/src/modules/integrations/readiness.ts",
        "endpoints": [
            "GET /integrations/readiness",
            "POST /integrations/verify-credentials",
        ],
        "onboarding": "project-memory/parity/CREDENTIAL-ONBOARDING.md",
        "tests": [
            "web/apps/api/test/integrationReadiness.test.ts",
            "web/apps/api/test/integrationReadiness.db.test.ts",
            "web/apps/api/test/scaleProtocol.test.ts",
        ],
        "note": (
            "Every desktop device and third-party integration is implemented behind an env-driven "
            "transport, so no code change is needed when a scale, camera or credential arrives. The "
            "weighing-scale serial protocol is a faithful port of TR_TAG_OPBL.cs — CH340 at 9600/8-N-1 "
            "with a 2400/7-N-1 fallback, the 20-character digits-and-dot filter, three-decimal "
            "formatting, and the net-weight-cell focus condition, including the desktop's dropping of a "
            "minus sign. Readiness reports variable PRESENCE only, never values, and never marks an "
            "integration ready while a credential is missing: a fake transport succeeding proves nothing "
            "about a real one."
        ),
    },
    "reportBaselines": {
        "question": "Do the extracted Crystal layouts render reproducibly, and would a change be noticed?",
        "tool": "web/scripts/report-baselines.mjs",
        "artifact": "project-memory/parity/REPORT-BASELINES.json",
        "command": "pnpm report-baselines",
        "note": (
            "Baselines the whole extracted report surface, not the plan's 22 high-severity list: 21 of "
            "those are the .rpt files that were never supplied. Proves reproducible render/bind/"
            "positioning and catches engine or spec drift; does NOT prove pixel equality with desktop "
            "output, which needs the desktop runtime (G5)."
        ),
    },
    "behaviourTracing": {
        "question": "Is every desktop validation enforced and every computed field accounted for?",
        "tools": [
            "project-memory/parity/validation_audit.py",
            "project-memory/parity/calc_audit.py",
            "project-memory/parity/generate_contracts.py",
        ],
        "artifacts": [
            "project-memory/parity/VALIDATION-AUDIT.json",
            "project-memory/parity/CALC-AUDIT.json",
        ],
        "note": (
            "Of the catalogued computed cells, more than half are SCREEN TOTALS: `mSG_TOT` mirrors the "
            "main grid's columns (`mSG_TOT.Cols = MSG.Cols`) and accumulates each column into row 0, so "
            "those cells are footer sums covered by the web's bill totals rather than per-line formulas. "
            "The per-line formulas are the real contract-review surface. "
            "Validations are keyed by their exact desktop message text, which is the only stable key "
            "between a decompiled MsgBox and a web guard; prompts and post-action notices are excluded "
            "from the denominator because they are not the API's responsibility. Calculations have no "
            "text key, so they are inventoried by resolved assignment target instead, and no coverage "
            "percentage is published for them: persisting a column is not proof the formula matches."
        ),
    },
    "uiFieldAudit": {
        "question": "Can an operator enter every field the API accepts?",
        "tool": "project-memory/parity/ui_field_audit.py",
        "artifact": "project-memory/parity/UI-FIELD-AUDIT.json",
        "note": (
            "Complements the grid-column ratio, which is a lower bound because desktop gridColumns "
            "inventories include hidden state columns. A field the API accepts but no page can supply "
            "is uncapturable regardless of how many <th> elements exist."
        ),
    },
    "depthScoreboard": {
        "question": "Does the web persist what the desktop persists, and can every grid column be captured?",
        "authoritativeMetric": "columnCoveragePct",
        "gridCaveat": DEPTH["gridCaveat"],
        "overall": DEPTH["summary"],
        "parserSelfTestCases": len(test_depth_metrics.CASES),
        "formsByDepthStatus": {},
        "worstTransactionForms": [],
        "familyGaps": {},
        "ratchetBaseline": "project-memory/parity/depth-baseline.json",
    },
    "measurementSelfCheck": {
        "declaredApiRoutes": len(declared_routes),
        "routesClaimedByUnits": len(claimed_routes & declared_routes),
        "infrastructureAllowlisted": len(INFRA_ROUTE_ALLOWLIST),
        "unmappedRoutes": orphan_routes,
        "phantomClaimedRoutes": phantom_routes,
        "transactionVoucherLifecycle": {
            "fullCreateReadEditDelete": sorted(LIFECYCLE_SPLIT["full"]),
            "createWithoutEdit": sorted(LIFECYCLE_SPLIT["createOnly"]),
            "noWritePath": sorted(LIFECYCLE_SPLIT["noWrite"]),
        },
        "note": "The generator fails if any declared business route is unclaimed or any claimed route is missing, so parity counts cannot drift silently.",
    },
    "summary": {
        "forms": surface_summary(forms), "tables": surface_summary(tables),
        "reports": surface_summary(reports), "settings": surface_summary(settings),
        "shortcuts": surface_summary(shortcuts), "invariants": surface_summary(invariants),
        "formCategoryCounts": dict(sorted(form_categories.items())),
        "formMappingCounts": dict(sorted(form_mapping.items())),
        "formMappingByCategory": form_mapping_by_category,
        "suppliedReportBinaries": 255, "absentReferencedReports": len(MISSING_REPORTS),
        "knownReportObligations": len(reports), "reportLayoutStatusCounts": dict(sorted(report_layouts.items())),
        "reportBinderCounts": dict(sorted(report_binders.items())),
        "rawMigrationOnlyDesktopTables": raw_only,
        "releaseDecision": "NO-GO: zero units have desktop comparison or production certification; critical data/security/report/operations blockers remain open.",
    },
    "forms": forms,
    "tables": tables,
    "webOnlyTables": web_only_tables,
    "reports": reports,
    "settings": settings,
    "shortcuts": shortcuts,
    "invariants": invariants,
    "externalEvidenceRequired": [
        "Compatible Windows Crystal runtime/reader for exact TagStkIdtlRpt and improved SalesQuotation extraction.",
        "Another complete installation for the 20 referenced-but-absent RPT files.",
        "Safe project PostgreSQL with seeded migration/RLS fixtures for integration/concurrency/isolation tests.",
        "Desktop runtime and representative sanitized shop data for row, workflow, keyboard and PDF comparisons.",
        "Shop printers/scales/scanners/webcams and service sandboxes/credentials for device/integration certification.",
        "Business-owner decisions for unresolved Dhiran, VP/GOLD_BOOK, rounding, book and report variants.",
    ],
}

# Structural assertions make count drift explicit rather than silently regenerating a new baseline.
assert len(forms) == 204, len(forms)
assert Counter(f["category"] for f in forms) == Counter({"other": 43, "master": 33, "report": 45, "transaction": 61, "utility": 22})
assert len(tables) == 146, len(tables)
assert len([r for r in reports if r["category"] == "supplied-crystal"]) == 255
assert len([r for r in reports if r["category"] == "absent-referenced"]) == 20
assert len(settings) == 57, len(settings)
assert len(API_ROUTE_KEYS) == 369, len(API_ROUTE_KEYS)

g5_passed = [r for r in ALL_UNITS if r["gates"]["desktop_compared"]["status"] == "passed"]
assert len(g5_passed) == len(G5_FORM_ARTIFACTS), (
    len(g5_passed), len(G5_FORM_ARTIFACTS)
)
assert all(row["unitType"] == "form" and row["id"] in G5_FORM_ARTIFACTS for row in g5_passed)
if not G5_FORM_ARTIFACTS:
    assert len(g5_passed) == 0, "G5 must remain 0 when no qualifying per-form artifacts exist"
g6_passed = [r for r in ALL_UNITS if r["gates"]["production_certified"]["status"] == "passed"]
assert len(ALL_UNITS) == 720, len(ALL_UNITS)
assert len(g6_passed) == 0, f"production_certified must remain 0/720, found {len(g6_passed)}/720"
_depth_forms = [r for r in forms if r.get("depthMetrics")]
matrix["depthScoreboard"]["formsByDepthStatus"] = dict(
    sorted(Counter(r["gates"]["depth"]["status"] for r in forms).items())
)
matrix["depthScoreboard"]["tablesByDepthStatus"] = dict(
    sorted(Counter(r["gates"]["depth"]["status"] for r in tables).items())
)
matrix["depthScoreboard"]["worstTransactionForms"] = [
    {
        "form": r["id"],
        "severity": r["severity"],
        "columnCoveragePct": r["depthMetrics"]["columnCoveragePct"],
        "missingColumns": r["depthMetrics"]["desktopWrittenColumns"] - r["depthMetrics"]["webWrittenColumns"],
        "gridCoveragePct": r["depthMetrics"]["gridCoveragePct"],
    }
    for r in sorted(
        (
            x for x in _depth_forms
            if x["category"] == "transaction" and x["depthMetrics"]["columnCoveragePct"] is not None
        ),
        key=lambda x: x["depthMetrics"]["columnCoveragePct"],
    )[:25]
]
DEPTH_FAMILIES = {
    "sales": ["SL_DATA", "SL_DETL", "SL_IDTL", "SL_PR_DETL", "SL_ORD_DATA", "SL_ORD_DETL", "SL_ORD_IDTL", "SL_ORD_ADJ", "BILL_OS_DATA"],
    "purchase": ["PR_DATA", "PR_DETL", "PR_IDTL", "APR_DATA", "APR_DETL", "APR_IDTL"],
    "tagStock": ["BAR_DATA", "BAR_DETL", "BAR_IDTL", "BAR_CAN_DATA", "BAR_CAN_DETL", "BAR_CAN_IDTL", "TAG_DATA", "TAG_PRINT_DATA", "TAG_STOCK_PRINT", "MAIN_STOCK", "ITM_LOT_DETL", "LOT_DETL"],
    "manufacturing": ["MFG_DATA", "MFG_DETL", "MFG_IDTL", "MFG_ISU_REC", "KR_DATA", "KR_DETL", "KR_IDTL", "MLT_DATA", "MLT_DETL"],
    "dhiran": ["DHRN_ISU_DATA", "DHRN_DATA", "DHRN_REC_DATA", "DHRN_REC_DETL", "DHRN_INT_DATA"],
    "finance": ["AC_DATA", "CASH_DATA", "CONTRA_DATA", "PAY_DATA", "PAY_DETL", "TAX_DATA", "ROJ_MEL_DATA", "LDR_ADJ_DATA", "EMP_DATA", "VP_ADJ_DATA", "RATE_CUT_DATA", "RATE_CUT_ISU", "RATE_CUT_ISU_REC"],
    "membership": ["AD_DATA", "AD_MEMB", "AD_ADJ", "AD_OS", "POINT_DATA", "POINT_MEMB"],
    "shared": ["REMARK_DATA", "DM_DATA", "TAG_IMAGE_DATA", "USER_DATA", "DELETE_DATA", "TEMP_BOOK_DATA", "MENU_DATA", "REPORT_DATA", "DESIGN_DETL", "CO_SET_NEW"],
}
for _family, _tabs in DEPTH_FAMILIES.items():
    _rows = [DEPTH["tables"][t] for t in _tabs if t in DEPTH["tables"]]
    _desk = sum(r["desktopWrittenColumns"] for r in _rows)
    _web = sum(r["webWrittenColumns"] for r in _rows)
    matrix["depthScoreboard"]["familyGaps"][_family] = {
        "tables": len(_rows),
        "desktopColumns": _desk,
        "webColumns": _web,
        "gap": _desk - _web,
        "coveragePct": round(_web * 100 / _desk, 1) if _desk else None,
        "tablesNeverWritten": sorted(r["table"] for r in _rows if not r["webWritesTableAtAll"]),
    }
_ui_path = OUT_DIR / "UI-FIELD-AUDIT.json"
if _ui_path.exists():
    _ui = load_json(_ui_path)
    matrix["uiFieldAudit"].update(
        {
            "totalFields": _ui.get("totalFields"),
            "capturable": _ui.get("capturable"),
            "coveragePct": _ui.get("coveragePct"),
            "pagesWithGaps": sorted(
                page for page, row in (_ui.get("pages") or {}).items() if row.get("uncapturable")
            ),
        }
    )
    # Every API-accepted field must be reachable from its page; a regression here means an operator
    # cannot enter something the desktop could.
    assert not matrix["uiFieldAudit"]["pagesWithGaps"], (
        "uncapturable API fields on: " + ", ".join(matrix["uiFieldAudit"]["pagesWithGaps"])
    )

_rb = OUT_DIR / "REPORT-BASELINES.json"
if _rb.exists():
    _rb_data = load_json(_rb)
    _rendered = [r for r in _rb_data.get("reports", []) if r.get("status") == "rendered"]
    matrix["reportBaselines"].update(
        {
            "layouts": len(_rb_data.get("reports", [])),
            "rendered": len(_rendered),
            "positionedObjects": sum(int(r.get("objects") or 0) for r in _rendered),
            "generatedAt": _rb_data.get("generatedAt"),
        }
    )
    assert len(_rendered) > 0, "report baselines retained but nothing rendered"

for _name, _key in (("VALIDATION-AUDIT.json", "validations"), ("CALC-AUDIT.json", "calculations")):
    _p = OUT_DIR / _name
    if _p.exists():
        matrix["behaviourTracing"][_key] = load_json(_p).get("totals")

# An approved contract is a hand-reviewed artifact and the only thing that can pass the `understood`
# gate. One was lost on 2026-07-29 to an overly broad `rm project-memory/contracts/TR_*.contract.md`,
# and because the generator exits 0 when the gate simply drops to zero, the loss was silent. Pin the
# known-approved set so a deletion fails generation instead.
APPROVED_CONTRACTS_EXPECTED = {"TR_MLT_PRO", "TR_SALE", "TR_PURC"}
_contract_dir = ROOT / "project-memory/contracts"
_approved = {
    path.name.split(".")[0]
    for path in _contract_dir.glob("*.contract.md")
    if "Status: approved" in path.read_text(encoding="utf-8", errors="ignore")
}
_lost = APPROVED_CONTRACTS_EXPECTED - _approved
assert not _lost, (
    f"approved contract(s) missing or downgraded: {sorted(_lost)}. "
    "An approved contract is hand-reviewed evidence — restore it rather than lowering this pin."
)

assert matrix["depthScoreboard"]["overall"]["overallColumnCoveragePct"] > 0
assert matrix["g6Status"]["certified"] is False
assert matrix["g6Status"]["productionCertifiedUnits"] == len(g6_passed)
assert matrix["g6Status"]["totalUnits"] == 720
assert all(r["gates"]["production_certified"]["status"] != "passed" for r in ALL_UNITS)
for row in ALL_UNITS:
    assert tuple(row["gates"].keys()) == GATE_NAMES
    assert all(row["gates"][g]["status"] in VALID_STATUSES for g in GATE_NAMES)

json_path = OUT_DIR / "DESKTOP-WEB-PARITY-MATRIX.json"
json_path.write_text(json.dumps(matrix, indent=2, ensure_ascii=False) + "\n", encoding="utf-8")

csv_path = OUT_DIR / "DESKTOP-WEB-PARITY-MATRIX.csv"
fields = [
    "unit_type", "unit_id", "category", "title", "severity", "mapping_classification", "mapping_confidence",
    *GATE_NAMES, "desktop_evidence", "web_evidence", "test_evidence", "blockers", "dependencies", "acceptance_checks"
]
with csv_path.open("w", encoding="utf-8", newline="") as handle:
    writer = csv.DictWriter(handle, fieldnames=fields)
    writer.writeheader()
    for row in ALL_UNITS:
        desktop_uris = [e["uri"] for e in row["gates"]["extracted"]["evidence"]]
        web_uris = [e["uri"] for e in row["gates"]["implemented"]["evidence"]]
        test_uris = [e["uri"] for e in row["gates"]["tested"]["evidence"]]
        writer.writerow({
            "unit_type": row["unitType"], "unit_id": row["id"], "category": row.get("category", ""),
            "title": row.get("title", ""), "severity": row.get("severity", ""),
            "mapping_classification": row.get("mappingClassification", ""),
            "mapping_confidence": row.get("mappingConfidence", ""),
            **{g: row["gates"][g]["status"] for g in GATE_NAMES},
            "desktop_evidence": ";".join(desktop_uris), "web_evidence": ";".join(web_uris),
            "test_evidence": ";".join(test_uris), "blockers": ";".join(row.get("blockers", [])),
            "dependencies": ";".join(row.get("dependencies", [])),
            "acceptance_checks": " || ".join(row.get("acceptanceChecks", [])),
        })


def code(status: str) -> str:
    return {"passed": "P", "in_progress": "IP", "not_started": "NS", "blocked": "B", "evidence_gap": "EG", "regressed": "R", "waived": "W"}[status]


def md_cell(value: Any) -> str:
    return str(value or "—").replace("|", "\\|").replace("\n", " ")


def path_list(values: Iterable[str], limit: int = 3) -> str:
    vals = list(values)
    shown = [f"`{v}`" for v in vals[:limit]]
    if len(vals) > limit:
        shown.append(f"+{len(vals)-limit}")
    return ", ".join(shown) if shown else "—"

md: list[str] = []
md += [
    "# DataCareNext Desktop-to-Web Parity Matrix", "",
    f"**Generated:** {GENERATED_AT}  ",
    "**Machine sources:** `DESKTOP-WEB-PARITY-MATRIX.json`, `DESKTOP-WEB-PARITY-MATRIX.csv`  ",
    "**Decision:** **NO-GO for production or live financial/inventory migration.**", "",
    "This matrix replaces route/model/test-count completion claims with six monotonic gates. The current web has substantial engineering breadth, but **0 forms, tables, reports, settings, shortcuts, or invariants have a desktop-comparison artifact, and 0 are production-certified**.", "",
    "## Gate contract", "",
    "| Code | Gate/status meaning |", "|---|---|",
    "| P | Passed with a cited artifact |", "| IP | Work/evidence exists but pass criteria are not met |",
    "| NS | Not started/no qualifying artifact |", "| B | Blocked by a named external or prerequisite dependency |",
    "| EG | Required desktop evidence is absent from supplied artifacts |", "| W | Formally waived with a dated documented rationale |", "",
    "Gate codes: G1 extracted, G2 understood, G3 implemented, **GD depth**, G4 tested, G5 desktop-compared, G6 production-certified.", "",
]
for g, desc in matrix["gateModel"]["gates"].items():
    md.append(f"- **{g}:** {desc}")
md += ["", "Anti-inflation rule: a route, `ready: true`, model, layout preview, 200 response, build, or mock/builder test is progress—not parity. Only `desktop_compared=passed` contributes to a parity percentage.", ""]

md += ["## Universe and current gates", "", "| Surface | Units | Extracted | Understood | Implemented | Depth | Tested | Desktop-compared | Production-certified |", "|---|---:|---|---|---|---|---|---|---|"]
for label, rows in [("Forms", forms), ("Desktop tables", tables), ("Report obligations", reports), ("Settings", settings), ("Shortcuts", shortcuts), ("Critical invariants", invariants)]:
    cells = []
    for g in GATE_NAMES:
        c = Counter(r["gates"][g]["status"] for r in rows)
        cells.append(", ".join(f"{code(k)} {v}" for k, v in sorted(c.items())))
    md.append(f"| {label} | {len(rows)} | " + " | ".join(cells) + " |")
md += ["", f"Report obligations include **255 supplied RPT binaries plus {len(MISSING_REPORTS)} code-referenced RPTs absent from all supplied roots**. Supplied layouts are 253 complete, one partial (`SalesQuotation`), and one unavailable (`TagStkIdtlRpt`).", ""]

md += ["## Current implementation shape (not parity)", "", "### Form mapping classes", "", "| Mapping class | Forms | Meaning |", "|---|---:|---|"]
class_meaning = {
    "dedicated-current-surface": "Dedicated route/handler exists; behavior remains uncertified.",
    "variant-shared": "Several desktop variants share one current engine/surface.",
    "conceptual-engine": "Behavior is intended to be absorbed by a cross-cutting engine.",
    "conceptual-report-engine": "Computed/generic report engine, not a ported desktop dialog.",
    "generic-crud-scaffold": "Metadata-driven CRUD only.", "generic-report-scaffold": "Generic report/layout surface only.",
    "generic-scaffold": "Adjacent/generic surface only.", "no-current-evidence": "No proved current behavior mapping.",
}
for cls, count in sorted(form_mapping.items()):
    md.append(f"| `{cls}` | {count} | {class_meaning.get(cls, '')} |")
md += ["", "### Mapping shape by desktop category", "", "| Category | Mapping classes |", "|---|---|"]
for category, counts in form_mapping_by_category.items():
    md.append(f"| {category} | " + ", ".join(f"`{cls}` {count}" for cls, count in counts.items()) + " |")
md += ["", "### Engineering breadth kept separate", "", f"- {len(list((ROOT / 'web/apps/web/app').rglob('page.tsx')))} frontend pages; {len(API_ROUTES)} declared API routes; {len(MODEL_BLOCKS)} Prisma models; {len(list((ROOT / 'web/apps/api/test').glob('*.test.ts')))} API test files.", f"- {sum(len(v) for v in WEB_FORM_SPECS.values())} web form-layout asset files normalize to {len(WEB_FORM_SPECS)}/204 distinct desktop form IDs; {len(WEB_SPECS)} web report spec files.", "- One headless-Chromium production smoke covers selected workflows and keyboard paths; there is still no visual, load, or desktop-comparison suite, and the report package remains incomplete.", ""]

md += ["## Release-blocking invariants", "", "| Invariant | Implemented | Tested | Blockers | Acceptance focus |", "|---|---|---|---|---|"]
for row in invariants:
    md.append(f"| {md_cell(row['title'])} | {code(row['gates']['implemented']['status'])} | {code(row['gates']['tested']['status'])} | {md_cell(', '.join(row['blockers']))} | {md_cell(row['acceptanceChecks'][0])} |")

md += ["", "## All 204 desktop forms", "", "The row maps current evidence only. `IP` never means desktop behavior is complete.", "", "| Form | Type | Current mapping | Frontend | API/module evidence | Tests | G1 | G2 | G3 | GD | G4 | G5 | G6 | Risk/blockers |", "|---|---|---|---|---|---|---:|---:|---:|---:|---:|---:|---:|---|"]
for row in forms:
    routes = ", ".join(row["web"]["frontendRoutes"]) or "—"
    modules = path_list(row["web"]["apiModules"], 2)
    tests_md = path_list(row["web"]["tests"], 1)
    gates = [code(row["gates"][g]["status"]) for g in GATE_NAMES]
    risk = row["severity"] + (": " + ", ".join(row["blockers"][:4]) if row["blockers"] else "")
    md.append(f"| `{row['id']}` | {row['category']} | `{row['mappingClassification']}` ({row['mappingConfidence']}) | {md_cell(routes)} | {modules} | {tests_md} | " + " | ".join(gates) + f" | {md_cell(risk)} |")

md += ["", "## Data/schema findings", "", f"All 146 desktop tables exist in migration SQL and {146 - len(raw_only)} are represented by Prisma mappings. Raw-migration-only drift: **{', '.join(f'`{x}`' for x in raw_only) or 'none'}**. The web-only `audit_log` is now migration-owned, FORCE-RLS protected and append-only for `app_user`.", "", "### Critical/high table rows", "", "| Table | Prisma | Usage | RLS E/F/P | Tests | Blockers |", "|---|---|---|---|---|---|"]
for row in tables:
    if row["severity"] not in {"critical", "high"}:
        continue
    rls = row["web"]["rls"]
    md.append(f"| `{row['id']}` | {md_cell(row['web']['prismaModel'])} | {row['web']['usageClassification']} | {int(rls['enable'])}/{int(rls['force'])}/{int(rls['policy'])} | {len(row['web']['testRefs'])} refs | {md_cell(', '.join(row['blockers']))} |")
md += ["", "The JSON/CSV contain all 146 table rows, referencing forms, schema/model/migration/RLS/source/test evidence and per-table acceptance checks.", ""]

md += ["## Report findings", "", f"- Supplied: 255 RPTs; layout status: {dict(sorted(report_layouts.items()))}.", f"- Missing obligations: {len(MISSING_REPORTS)} — " + ", ".join(f"`{x}`" for x in MISSING_REPORTS) + ".", f"- Current binder classification across supplied reports: {dict(sorted(report_binders.items()))}. `SL_DATA_DEFAULT_UNSAFE` means the current binder finds no SL/PR/KR family and silently defaults to sales.", "- Web `SalesQuotation.spec.json` is still an unusable error stub even though the project catalog contains the recovered partial layout.", "- Every report remains G5/G6 `NS`; no desktop PDF/image or physical-printer certification exists.", "", "### Extraction/web exceptions", "", "| Report | Desktop layout | Web usable/indexed | Binder | G1 | G3 | G4 | Blockers |", "|---|---|---|---|---:|---:|---:|---|"]
for row in reports:
    if row["desktop"]["layoutStatus"] != "complete" or not row["web"]["layoutUsable"] or row["web"]["currentBinderFamily"] == "SL_DATA_DEFAULT_UNSAFE":
        md.append(f"| `{row['id']}` | {row['desktop']['layoutStatus']} | {row['web']['layoutUsable']}/{row['web']['layoutIndexed']} | `{row['web']['currentBinderFamily']}` | {code(row['gates']['extracted']['status'])} | {code(row['gates']['implemented']['status'])} | {code(row['gates']['tested']['status'])} | {md_cell(', '.join(row['blockers']))} |")

consumer_settings = [s for s in settings if s["web"]["consumerRefs"]]
md += ["", "## Settings and keyboard", "", f"- Settings: all 57 extracted keys are present in the editable API registry; only {len(consumer_settings)} have an exact-key source reference outside that registry. Registry/storage presence is not behavioral parity.", "- Keyboard: F1/Enter/Escape and Ctrl/Cmd+Enter plus grid movement/removal have shared handlers and selected Chromium workflow coverage; F2/F3/F4/F5/F7/F8/F9/F11/F12 remain absent or form-incomplete.", "", "| Shortcut | Desktop files | Web files | G3 | G4 |", "|---|---:|---:|---:|---:|"]
for row in shortcuts:
    md.append(f"| `{row['id']}` | {len(row['desktop']['sourceRefs'])} | {len(row['web']['sourceRefs'])} | {code(row['gates']['implemented']['status'])} | {code(row['gates']['tested']['status'])} |")

md += [
    "", "## G5 comparison harness", "",
    f"- Runner: `{G5_RUNNER_PATH}`; latest artifact: `{G5_LATEST_PATH}`; current mode: **{G5_CURRENT_MODE}**.",
    f"- Qualifying retained zero-diff form artifacts: **{len(G5_FORM_ARTIFACTS)}**. Skipped, failed, incomplete, or report-only artifacts never advance a form gate.",
    "- External inputs still required: " + " ".join(G5_EXTERNAL_INPUTS),
]

md += [
    "", "## G6 production-certification status", "",
    f"- Ledger: `{G6_STATUS_PATH}`; production-certified units: **0/{len(ALL_UNITS)}**; certified: **false**.",
    "- Local evidence does not clear blocked deployment, DR, hardware/site UAT, live-service, or signer requirements.",
]
for requirement in G6_REQUIREMENTS:
    external = requirement["externalInputRequired"] or "none for this local artifact"
    md.append(
        f"- `{requirement['id']}` — **{requirement['status']}**; artifact: "
        f"`{requirement['artifactPath']}`; external input: {external}"
    )

md += ["", "## Required evidence to advance gates", "", "1. **G2:** source-linked behavior contracts per form/report/setting, including branches, table ownership, delete/reversal, keyboard/focus and exact formula policy.", "2. **G3:** close numbering, loose stock, server reversal, workflow fine-policy, posting/reversal integrity and report/PDF blockers before claiming complete implementation.", "3. **G4:** CI must invoke real posting/reversal/numbering/tenant functions against migrated PostgreSQL and add authorization, cross-tenant, concurrency, failure, browser, migration and restore suites.", "4. **G5:** run scripted workflows on desktop and web with the same sanitized fixture; require row/aggregate reconciliation plus screenshot/PDF/keyboard comparison artifacts.", "5. **G6:** pass security/load/observability/readiness, backup/restore/DR, device/service/site UAT and signed business acceptance.", "", "## External evidence still required", ""]
for item in matrix["externalEvidenceRequired"]:
    md.append(f"- {item}")
md += ["", "## How to regenerate", "", "```bash", "python3 project-memory/parity/build_parity_matrix.py", "```", "", "The generator asserts the frozen universes (204 forms, 146 tables, 255 supplied reports, 20 absent referenced reports, 57 settings, 369 declared API routes) and refuses silent count drift. It also self-checks measurement integrity: every declared business route must be claimed by a desktop unit row (or be one of the declared infrastructure routes), every claimed route must exist, and the transaction voucher-lifecycle split (full create/read/edit/delete vs create-without-edit vs no write path) is recomputed from the route universe rather than asserted by hand.", ""]


# --- Depth scoreboard -------------------------------------------------------
_ds = matrix["depthScoreboard"]
_sb: list[str] = [
    "# Depth scoreboard (generated)",
    "",
    f"Generated {GENERATED_AT} by `project-memory/parity/build_parity_matrix.py`.",
    "Regenerate with that script; it fails if the write-set parser self-test fails or if any",
    "form's column coverage decreases (`depth-baseline.json` ratchet).",
    "",
    "## Headline",
    "",
    "| Metric | Value |",
    "| --- | --- |",
    f"| Desktop written columns | {_ds['overall']['totalDesktopWrittenColumns']} |",
    f"| Web written columns | {_ds['overall']['totalWebWrittenColumns']} |",
    f"| **Column coverage** | **{_ds['overall']['overallColumnCoveragePct']}%** |",
    f"| Desktop tables written | {_ds['overall']['desktopTablesWritten']} |",
    f"| Tables the web never writes | {_ds['overall']['tablesNeverWrittenByWeb']} |",
    f"| Parser self-test fixtures | {_ds['parserSelfTestCases']} |",
    "",
    f"Grid caveat: {_ds['gridCaveat']}",
    "",
    "## Gate distribution",
    "",
    "| Unit | " + " | ".join(sorted(set(_ds["formsByDepthStatus"]) | set(_ds["tablesByDepthStatus"]))) + " |",
    "| --- |" + " ---: |" * len(sorted(set(_ds["formsByDepthStatus"]) | set(_ds["tablesByDepthStatus"]))),
    "| Forms (204) | "
    + " | ".join(
        str(_ds["formsByDepthStatus"].get(k, 0))
        for k in sorted(set(_ds["formsByDepthStatus"]) | set(_ds["tablesByDepthStatus"]))
    )
    + " |",
    "| Tables (146) | "
    + " | ".join(
        str(_ds["tablesByDepthStatus"].get(k, 0))
        for k in sorted(set(_ds["formsByDepthStatus"]) | set(_ds["tablesByDepthStatus"]))
    )
    + " |",
    "",
    "## Family gaps (remediation batches, largest first)",
    "",
    "| Family | Tables | Desktop cols | Web cols | Gap | Coverage | Never written |",
    "| --- | ---: | ---: | ---: | ---: | ---: | --- |",
]
for _name, _v in sorted(_ds["familyGaps"].items(), key=lambda kv: -kv[1]["gap"]):
    _never = ", ".join(_v["tablesNeverWritten"]) or "-"
    _sb.append(
        f"| {_name} | {_v['tables']} | {_v['desktopColumns']} | {_v['webColumns']} | "
        f"{_v['gap']} | {_v['coveragePct']}% | {_never} |"
    )
_sb += [
    "",
    "## Worst transaction forms by persisted-column depth",
    "",
    "| Form | Severity | Column coverage | Missing columns | Grid coverage |",
    "| --- | --- | ---: | ---: | ---: |",
]
for _w in _ds["worstTransactionForms"]:
    _sb.append(
        f"| {_w['form']} | {_w['severity']} | {_w['columnCoveragePct']}% | "
        f"{_w['missingColumns']} | {_w['gridCoveragePct']}% |"
    )
_sb += [
    "",
    "## What `depth: passed` requires",
    "",
    "- >=99% of the desktop write set persisted for every table the form writes",
    "- zero desktop tables left unwritten",
    "- >=95% grid-column coverage where the form has a grid",
    "- an approved per-form contract in `project-memory/contracts/`",
    "",
]
(OUT_DIR / "DEPTH-SCOREBOARD.md").write_text("\n".join(_sb) + "\n", encoding="utf-8")

md_path = OUT_DIR / "DESKTOP-WEB-PARITY-MATRIX.md"
md_path.write_text("\n".join(md), encoding="utf-8")

print(json.dumps({
    "forms": len(forms), "tables": len(tables), "reports": len(reports), "settings": len(settings),
    "shortcuts": len(shortcuts), "invariants": len(invariants), "csvRows": len(ALL_UNITS),
    "apiRoutes": len(API_ROUTES), "rawMigrationOnly": raw_only,
    "unmappedApiRoutes": orphan_routes, "phantomClaimedRoutes": phantom_routes,
    "transactionLifecycle": {k: len(v) for k, v in LIFECYCLE_SPLIT.items()},
    "approvedFormContracts": APPROVED_CONTRACTS, "draftFormContracts": DRAFT_CONTRACTS,
    "g5Passed": len(g5_passed), "g5Total": len(ALL_UNITS),
    "g6Passed": len(g6_passed), "g6Total": len(ALL_UNITS),
    "g5Harness": matrix["g5Harness"],
    "g6Status": matrix["g6Status"],
    "outputs": [rel(json_path), rel(csv_path), rel(md_path)],
}, indent=2))
