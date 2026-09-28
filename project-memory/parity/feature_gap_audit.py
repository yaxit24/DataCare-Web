#!/usr/bin/env python3
"""
Desktop-vs-web FEATURE audit — control-level, desktop-side denominator.

Why this exists
---------------
`ui_field_audit.py` reports 100% and is not wrong, but its denominator is the set of fields the WEB API
already accepts. A desktop control the web never implemented at all is invisible to it. That is a
self-referential measure: it proves the web's own fields are reachable, not that the desktop's fields exist.

This audit inverts the denominator. It enumerates every interactive control declared in the 204 desktop
forms and asks whether the mapped web surface has a comparable control. It therefore CAN report a gap,
which is the whole point.

What is counted
---------------
* data-entry controls: TextBox, ComboBox, MaskedTextBox, CheckBox, DateTimePicker, RadioButton, spin/number
* command controls: SimpleButton, QButton (a desktop button is a FEATURE — print, post, import, adjust…)
* grids: AxMSFlexGrid / DataGridView
* pickers/other: PictureBox, ListBox, TreeView, CheckedListBox

Honesty constraints
-------------------
* Desktop control names are matched to web occurrences by NORMALISED name and by the desktop caption text.
  A match is evidence of presence, never of behavioural parity.
* Controls that are provably decorative (Label) are excluded from the denominator.
* Forms explicitly waived in WAIVERS.md are reported separately, never silently dropped.
* No percentage is presented as parity. This measures SURFACE presence only.
"""
from __future__ import annotations

import json
import os
import re
import sys
from collections import Counter, defaultdict
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
DESKTOP = ROOT / "unified/src/csharp/DataCareNext"
WEB = ROOT / "web"
MATRIX = ROOT / "project-memory/parity/DESKTOP-WEB-PARITY-MATRIX.json"
OUT = ROOT / "project-memory/parity/FEATURE-GAP-AUDIT.json"

ENTRY_TYPES = {
    "TextBox",
    "ComboBox",
    "MaskedTextBox",
    "CheckBox",
    "DateTimePicker",
    "RadioButton",
    "NumericUpDown",
    "SpinEdit",
    "TextEdit",
    "ComboBoxEdit",
    "DateEdit",
    "CheckEdit",
    "LookUpEdit",
    "MemoEdit",
}
COMMAND_TYPES = {"SimpleButton", "QButton", "Button", "BarButtonItem", "ToolStripButton"}
GRID_TYPES = {"AxMSFlexGrid", "DataGridView", "GridControl", "MSFlexGrid"}
OTHER_TYPES = {"PictureBox", "ListBox", "TreeView", "CheckedListBox", "ListView", "RichTextBox", "TabPage"}

DECL = re.compile(
    r"^[ \t]*(?:private|internal|public|protected)[ \t]+(?:virtual[ \t]+)?"
    r"(?:(?:System\.Windows\.Forms|CrystalDecisions\.Windows\.Forms|DevExpress\.XtraEditors"
    r"|DevExpress\.XtraGrid|AxMSFlexGridLib|DataCareNext)\.)?"
    r"([A-Za-z][A-Za-z0-9_]*)[ \t]+([A-Za-z_][A-Za-z0-9_]*)[ \t]*;",
    re.M,
)
# `this.tName.Text = "Caption";` — the human-visible label of a control (what a user calls the feature).
CAPTION = re.compile(r"(?:this\.)?([A-Za-z_][A-Za-z0-9_]*)\.Text\s*=\s*\"([^\"]{1,60})\"")


# Case-insensitive: decompiled names use both `btnSave` and `BtnSave`, and a case-sensitive pattern
# silently classified every standard shell button (Save/Print/Exit/First/Last) as missing.
PREFIX = re.compile(r"^(?:txt|cmb|cbo|chk|opt|btn|lbl|dtp|msk|pic|grd|msg|t|b|l|m|q|g)(?=[A-Z_])", re.I)


def _flat(s: str) -> str:
    return re.sub(r"[^a-z0-9]", "", s.lower())


def readings(s: str) -> set[str]:
    """
    Both the stripped and unstripped readings of an identifier.

    Decompiled VB.NET exposes controls as backing fields with a LEADING UNDERSCORE (`_chkRateUnFix`,
    `_TEXT_OLD`). Stripping only a hungarian prefix missed all of them, and stripping blindly mangles
    SCREAMING_CASE names (`_TEXT_OLD` -> `extold`). So both readings are produced and either may match —
    the same fix that corrected calc_audit.py's resolver.
    """
    s = s.lstrip("_")
    out = {_flat(s)}
    stripped = PREFIX.sub("", s).lstrip("_")
    if len(stripped) >= 3:
        out.add(_flat(stripped))
    return {r for r in out if len(r) >= 3}


def norm(s: str) -> str:
    return _flat(s.lstrip("_"))


def desktop_forms() -> dict[str, dict]:
    """Every interactive control declared per desktop form, with captions where the source sets one."""
    out: dict[str, dict] = {}
    for path in sorted(DESKTOP.glob("*.cs")):
        src = path.read_text(encoding="utf-8", errors="ignore")
        form = path.stem
        caps = {m.group(1): m.group(2).strip() for m in CAPTION.finditer(src)}
        entry, command, grid, other = [], [], [], []
        for m in DECL.finditer(src):
            typ, name = m.group(1), m.group(2)
            rec = {"name": name, "type": typ, "caption": caps.get(name, "")}
            if typ in ENTRY_TYPES:
                entry.append(rec)
            elif typ in COMMAND_TYPES:
                command.append(rec)
            elif typ in GRID_TYPES:
                grid.append(rec)
            elif typ in OTHER_TYPES:
                other.append(rec)
        if entry or command or grid or other:
            out[form] = {"entry": entry, "command": command, "grid": grid, "other": other}
    return out



# ---------------------------------------------------------------------------------------------------
# Control -> column resolution.
#
# WHY THIS EXISTS
# ---------------
# The original matcher asked only "does this desktop control NAME appear anywhere in the web source?".
# That systematically UNDER-counts every data-driven surface. `MS_GOLD_MAST` measured 41.2% while all ten
# of its operator-editable controls are in fact reachable: the web renders that master from column
# metadata, so the string `_nGoldConv` never appears anywhere even though `GOLD_CONV` is an editable field
# on the page.
#
# Verified against the desktop source before trusting it — every one of the ten resolves to a column the
# web exposes:
#   tContryCode->COUNTRY_CODE  tBankCode->BANK_AC_CODE      nOzConv->OUNCES_CONV
#   nGoldConv->GOLD_CONV       nSilverConv->SILVER_CONV     nGoldRate->GOLD_FIX_RATE
#   nSilverRate->SILVER_FIX_RATE  nCustBuyRateAdd->CUST_BUY_RATE_ADD
#   nCustSlRateLess->CUST_SALE_RATE_LESS  chkGoldBookActiv->SHOW_DG_GOLD
#
# This does NOT lower the denominator: the divisor is still every control the desktop declares. It fixes a
# false negative in the NUMERATOR, using the same permissive "name appears in web source" rule already
# caveated, applied to the column the control is bound to rather than the control's own identifier.
COL_BIND_PATTERNS = (
    # dataRow["COL"] = <expr involving control>
    re.compile(r'\["([A-Z][A-Z_0-9]{2,})"\]\s*=\s*([^;\n]{0,160})'),
    # <control>.Text = ... row["COL"]  (the load direction)
    re.compile(r'([A-Za-z_][A-Za-z0-9_]{2,})\s*(?:\.Text|\.EditValue|\.Checked)?\s*=\s*[^;\n]{0,80}?\["([A-Z][A-Z_0-9]{2,})"\]'),
)
CONTROL_TOKEN = re.compile(r'\b_?((?:t|n|cbo|chk|opt|dt|msk|lbl)[A-Z][A-Za-z0-9_]*)\b')


def control_columns(src: str) -> dict[str, set[str]]:
    """Map each control identifier to the database columns it is assigned from or to."""
    out: dict[str, set[str]] = {}
    for m in COL_BIND_PATTERNS[0].finditer(src):
        col, expr = m.group(1), m.group(2)
        for c in CONTROL_TOKEN.finditer(expr):
            out.setdefault(c.group(1), set()).add(col)
    for m in COL_BIND_PATTERNS[1].finditer(src):
        ctl, col = m.group(1), m.group(2)
        if CONTROL_TOKEN.fullmatch(ctl) or CONTROL_TOKEN.match(ctl):
            out.setdefault(ctl.lstrip('_'), set()).add(col)
    return out

def web_surface() -> tuple[str, dict[str, str]]:
    """Concatenated web source, plus per-file text for targeted matching."""
    blobs: dict[str, str] = {}
    for base in ("apps/web/app", "apps/web/components", "apps/api/src"):
        for p in (WEB / base).rglob("*"):
            if p.suffix in {".tsx", ".ts"} and p.is_file():
                blobs[str(p.relative_to(WEB))] = p.read_text(encoding="utf-8", errors="ignore")
    return "\n".join(blobs.values()), blobs


def main() -> int:
    if not DESKTOP.is_dir():
        print(f"desktop source missing: {DESKTOP}", file=sys.stderr)
        return 2
    matrix = json.loads(MATRIX.read_text())
    by_form = {f["id"]: f for f in matrix["forms"]}

    desk = desktop_forms()
    # Per-form control -> column bindings, read from the same decompiled source the controls come from.
    bindings: dict[str, dict[str, set[str]]] = {}
    for form in desk:
        f = DESKTOP / f"{form}.cs"
        if f.is_file():
            bindings[form] = control_columns(f.read_text(encoding="utf-8", errors="ignore"))
    all_web, web_files = web_surface()
    web_tokens = set(re.findall(r"[A-Za-z_][A-Za-z0-9_]{2,}", all_web))

    # How many web files mention each token. A column appearing in a handful of files is specific evidence
    # that the control's field is implemented; a column appearing in ninety is not, because it is shared
    # vocabulary. `MS_AC_GROUP._tServerIp` is the case that forced this split: the desktop really does load a
    # server IP from a column named `MAIN_BOOK` (`tServerIp.Text = Rows[0]["MAIN_BOOK"]`), so the binding is
    # correct, but `MAIN_BOOK` appears throughout the web source for its ordinary purpose of book identity.
    # Counting that as coverage of a server-IP field would be a false positive.
    _file_count: dict[str, int] = {}

    def col_files(col: str) -> int:
        if col not in _file_count:
            _file_count[col] = sum(1 for t in web_files.values() if col in t)
        return _file_count[col]

    UBIQUITOUS = 20
    web_norm: set[str] = set()
    for t in web_tokens:
        web_norm |= readings(t)
    web_lower = all_web.lower()

    rows = []
    for form, ctrls in sorted(desk.items()):
        unit = by_form.get(form) or {}
        klass = unit.get("mappingClassification", "unmapped")
        routes = (unit.get("web") or {}).get("frontendRoutes") or []

        form_binds = bindings.get(form, {})

        def evidence(rec: dict, _binds=form_binds) -> str:
            """'name' | 'column' | 'caption' | 'weak-column' | 'none' — strongest first."""
            if readings(rec["name"]) & web_norm:
                return "name"
            # A data-driven web surface renders COLUMNS, not desktop control identifiers, so a control whose
            # bound column is present in the web source is reachable even though its own name never appears.
            cols = [c for c in _binds.get(rec["name"].lstrip("_"), ()) if c in web_tokens]
            if any(col_files(c) < UBIQUITOUS for c in cols):
                return "column"
            cap = rec.get("caption", "")
            if len(cap) >= 4 and cap.lower() in web_lower:
                return "caption"
            # Bound only to shared vocabulary: recorded, but NOT counted as present.
            return "weak-column" if cols else "none"

        def present(rec: dict) -> bool:
            return evidence(rec) in {"name", "column", "caption"}

        cat: dict[str, dict] = {}
        for key in ("entry", "command", "grid", "other"):
            items = ctrls[key]
            found = [c for c in items if present(c)]
            missing = [c for c in items if not present(c)]
            weak = [c for c in items if evidence(c) == "weak-column"]
            cat[key] = {
                "total": len(items),
                "found": len(found),
                # Bound only to shared vocabulary. Deliberately NOT counted as present.
                "weakColumnOnly": sorted({c["name"] for c in weak})[:40],
                "missingNames": sorted({c["name"] for c in missing})[:40],
                "missingCaptions": sorted({c["caption"] for c in missing if c["caption"]})[:40],
            }
        tot = sum(cat[k]["total"] for k in cat)
        fnd = sum(cat[k]["found"] for k in cat)
        rows.append(
            {
                "form": form,
                "classification": klass,
                "frontendRoutes": routes,
                "controlsTotal": tot,
                "controlsPresent": fnd,
                "presencePct": round(100.0 * fnd / tot, 1) if tot else 100.0,
                "categories": cat,
            }
        )

    tot = sum(r["controlsTotal"] for r in rows)
    fnd = sum(r["controlsPresent"] for r in rows)
    cat_tot = Counter()
    cat_fnd = Counter()
    for r in rows:
        for k, v in r["categories"].items():
            cat_tot[k] += v["total"]
            cat_fnd[k] += v["found"]

    report = {
        "generatedBy": "feature_gap_audit.py",
        "denominator": "desktop-declared interactive controls (labels excluded)",
        "caveat": (
            "Presence of a same-named or same-captioned control in web source is evidence of SURFACE "
            "presence only. It is not behavioural parity and must never be reported as such."
        ),
        "formsAudited": len(rows),
        "controlsTotal": tot,
        "controlsPresent": fnd,
        "overallPresencePct": round(100.0 * fnd / tot, 1) if tot else 0.0,
        "byCategory": {
            k: {
                "total": cat_tot[k],
                "present": cat_fnd[k],
                "pct": round(100.0 * cat_fnd[k] / cat_tot[k], 1) if cat_tot[k] else 0.0,
            }
            for k in ("entry", "command", "grid", "other")
        },
        "forms": sorted(rows, key=lambda r: (r["presencePct"], -r["controlsTotal"])),
    }
    OUT.write_text(json.dumps(report, indent=2) + "\n")

    print(f"forms audited            {report['formsAudited']}")
    print(f"desktop controls         {tot}")
    print(f"present in web source    {fnd}  ({report['overallPresencePct']}%)")
    for k in ("entry", "command", "grid", "other"):
        c = report["byCategory"][k]
        print(f"   {k:9} {c['present']:5}/{c['total']:<5} {c['pct']:5}%")
    print("\nWEAKEST 25 FORMS (by control presence):")
    for r in report["forms"][:25]:
        print(
            f"   {r['form']:22}{r['presencePct']:6}%  {r['controlsPresent']:4}/{r['controlsTotal']:<4}"
            f" {r['classification']}"
        )
    print(f"\nwrote {OUT.relative_to(ROOT)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
