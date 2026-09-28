#!/usr/bin/env python3
"""Compare configurability: how many settings actually change behaviour on each side.

Declaring a setting is not the same as honouring it. This script separates the two:

Desktop  - every `DC_Main.Ms*` global referenced from form code is a real consumption
           site, because the desktop reads config straight off that global at the point
           of use. Assignments inside the loader are excluded so only reads count.
Web      - the authoritative inventory is every persisted column of CO_SET/CO_SET_NEW
           (settingsInventory.ts). A setting is "honoured" only if its key is referenced
           somewhere in apps/api/src outside the inventory, the display catalog and the
           settings CRUD module - i.e. in business logic that can change an outcome.

Run:  python3 settings_parity.py > SETTINGS-PARITY.json
"""
from __future__ import annotations

import json
import os
import re
import sys
from collections import defaultdict

REPO = os.path.normpath(os.path.join(os.path.dirname(os.path.abspath(__file__)), "..", ".."))
DESKTOP = os.path.join(REPO, "unified", "src", "csharp", "DataCareNext")
API = os.path.join(REPO, "web", "apps", "api", "src")
WEBAPP = os.path.join(REPO, "web", "apps", "web")
INVENTORY = os.path.join(API, "modules", "settings", "settingsInventory.ts")

# Files that merely *describe* settings. A reference here is not a behaviour.
DECLARATION_ONLY = {
    os.path.join(API, "modules", "settings", "settingsInventory.ts"),
    os.path.join(API, "modules", "settings", "settingsCatalog.ts"),
    os.path.join(API, "modules", "settings", "settings.ts"),
}

MS_REF = re.compile(r"\bDC_Main\.(Ms[A-Za-z0-9_]+)\b")
MS_ASSIGN = re.compile(r"\bDC_Main\.(Ms[A-Za-z0-9_]+)\s*=(?!=)")
INV_KEY = re.compile(r"^\s*\{\s*key:\s*'([A-Z0-9_]+)'\s*,\s*table:\s*'(CO_SET|CO_SET_NEW)'", re.M)


def desktop_settings() -> dict:
    reads: dict[str, set[str]] = defaultdict(set)
    assigns: dict[str, set[str]] = defaultdict(set)
    for fn in sorted(os.listdir(DESKTOP)):
        if not fn.endswith(".cs"):
            continue
        path = os.path.join(DESKTOP, fn)
        with open(path, "r", encoding="utf-8", errors="replace") as fh:
            text = fh.read()
        form = os.path.splitext(fn)[0]
        for m in MS_ASSIGN.finditer(text):
            assigns[m.group(1)].add(form)
        for m in MS_REF.finditer(text):
            reads[m.group(1)].add(form)
    # A setting is "consumed" when at least one form other than the loader reads it.
    consumed = {}
    for key, forms in reads.items():
        readers = {f for f in forms if f not in ("DC_Main", "MDI_FORM")}
        assign_only = key in assigns and not readers
        if not assign_only:
            consumed[key] = sorted(readers or forms)
    return {
        "distinctSettings": len(reads),
        "consumedSettings": len(consumed),
        "consumption": dict(sorted(consumed.items(), key=lambda kv: -len(kv[1]))),
    }


def web_settings() -> dict:
    with open(INVENTORY, "r", encoding="utf-8", errors="replace") as fh:
        inv_text = fh.read()
    keys = [(m.group(1), m.group(2)) for m in INV_KEY.finditer(inv_text)]

    # Three tiers of reference, because "the string appears somewhere" is not a behaviour:
    #   plumbing = settings module, routes, the settings page, tests  -> stores/displays it
    #   logic    = any other module under apps/api/src/modules         -> can change an outcome
    #   ui       = any page/component outside the settings page        -> changes what is shown
    logic: list[tuple[str, str]] = []
    plumbing: list[tuple[str, str]] = []
    ui: list[tuple[str, str]] = []
    for base in (API, os.path.join(WEBAPP, "app"), os.path.join(WEBAPP, "components")):
        for root, _dirs, names in os.walk(base):
            for n in names:
                if not (n.endswith(".ts") or n.endswith(".tsx")):
                    continue
                p = os.path.join(root, n)
                rel = os.path.relpath(p, REPO)
                with open(p, "r", encoding="utf-8", errors="replace") as fh:
                    txt = fh.read()
                norm = p.replace(os.sep, "/")
                is_settings_area = "/modules/settings/" in norm or "/app/(app)/settings/" in norm
                # The BEHAVIOUR LOADER is not a consumer.
                #
                # `settingsBehavior.ts` reads every setting into a typed contract, so counting a
                # reference there marks a setting honoured the moment it is loaded — before anything
                # acts on it. That is exactly the distinction this phase exists to enforce: 21 fields
                # were added to the contract and only a handful changed an outcome. Excluding the
                # loader means `honouredInBusinessLogic` counts settings some OTHER module consumes.
                is_loader = norm.endswith("/shared/settingsBehavior.ts")
                # Generated or manifest files list setting NAMES as data (clone column lists, master
                # form-field tables, per-column default tables, seeds, diff tooling). A key appearing
                # there is storage plumbing or an outright name collision with a transaction column
                # (LBR_TYPE, TAX_CODE, FX_RATE, LOCK_DATE all exist as both), never a behaviour.
                is_manifest = any(
                    norm.endswith(s)
                    for s in (
                        "/masters/companyClone.ts",
                        "/masters/companySettings.ts",
                        "/masters/generated-formfields.ts",
                        "/masters/configs.ts",
                        "/posting/desktopColumnDefaults.ts",
                        "/ops/seedCompany.ts",
                        "/parity/bundleDiff.ts",
                    )
                ) or "/prisma/" in norm
                if is_settings_area or is_manifest or is_loader or "/routes/" in norm or "/test" in norm:
                    plumbing.append((rel, txt))
                elif "/apps/api/src/" in norm:
                    logic.append((rel, txt))
                else:
                    ui.append((rel, txt))

    def hits(pat: re.Pattern[str], corpus: list[tuple[str, str]]) -> list[str]:
        return sorted({rel for rel, txt in corpus if pat.search(txt)})

    honoured_logic: dict[str, list[str]] = {}
    shown_ui: dict[str, list[str]] = {}
    plumbed: dict[str, list[str]] = {}
    for key, _table in keys:
        # Require the key as a whole token so short keys cannot match by accident.
        pat = re.compile(r"(?<![A-Za-z0-9_])" + re.escape(key) + r"(?![A-Za-z0-9_])")
        hl = hits(pat, logic)
        hu = hits(pat, ui)
        hp = hits(pat, plumbing)
        if hl:
            honoured_logic[key] = hl[:8]
        if hu:
            shown_ui[key] = hu[:8]
        if hp:
            plumbed[key] = hp[:8]

    inert = sorted(k for k, _t in keys if k not in honoured_logic and k not in shown_ui)
    return {
        "inventoryTotal": len(keys),
        "byTable": {
            "CO_SET": sum(1 for _k, t in keys if t == "CO_SET"),
            "CO_SET_NEW": sum(1 for _k, t in keys if t == "CO_SET_NEW"),
        },
        "honouredInBusinessLogic": len(honoured_logic),
        "referencedInUiOnly": len([k for k in shown_ui if k not in honoured_logic]),
        "storedOrDisplayedOnly": len(inert),
        "inertKeys": inert,
        "honouredKeys": dict(sorted(honoured_logic.items())),
    }


def main() -> int:
    d = desktop_settings()
    w = web_settings()
    out = {
        "kind": "settings-parity",
        "note": (
            "Desktop settings tables per DESKTOP-REAL-SCHEMA.json: CO_SET 58, CO_SET_NEW 70, "
            "CO_MAST 38, TAG_SET 8. The web inventory covers CO_SET and CO_SET_NEW only."
        ),
        "desktop": {
            "distinctGlobalsReferenced": d["distinctSettings"],
            "consumedAtPointOfUse": d["consumedSettings"],
            "settingsTableColumns": {"CO_SET": 58, "CO_SET_NEW": 70, "CO_MAST": 38, "TAG_SET": 8},
        },
        "web": {
            "inventoryTotal": w["inventoryTotal"],
            "byTable": w["byTable"],
            "honouredInBusinessLogic": w["honouredInBusinessLogic"],
            "referencedInUiOnly": w["referencedInUiOnly"],
            "storedOrDisplayedOnly": w["storedOrDisplayedOnly"],
            "settingsTablesNotSurfaced": ["CO_MAST (38 cols)", "TAG_SET (8 cols)"],
        },
        "ratios": {
            "webHonouredOverWebInventory": round(
                100.0 * w["honouredInBusinessLogic"] / max(w["inventoryTotal"], 1), 1
            ),
            "webHonouredOverDesktopConsumed": round(
                100.0 * w["honouredInBusinessLogic"] / max(d["consumedSettings"], 1), 1
            ),
        },
        "webInertKeys": w["inertKeys"],
        "desktopConsumption": d["consumption"],
        "webHonouredKeys": w["honouredKeys"],
    }
    json.dump(out, sys.stdout, indent=1)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
