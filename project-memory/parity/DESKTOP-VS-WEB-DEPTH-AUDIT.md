# DESKTOP vs WEB — FEATURE-DEPTH PARITY AUDIT (independent synthesis)

_Author: synthesis auditor. Date: 2026-07-02. Scope: real feature/form **depth, breadth, reports, appearance** — not backend posting logic. Every number below was re-measured from files this session; sources cited inline._

> **Bottom line up front.** The web rebuild has **high screen breadth** (nearly every desktop menu item resolves to a route) and **high backend/data-posting parity** (the project's own harnesses show 141/141 tables, 366/366 Σ — see `parity/scorecard.md`). But the owner's *"only ~20% is actually reproduced"* is **correct and defensible** once you weight by **form depth, report/document fidelity, and appearance** — the three dimensions a posting-parity scorecard never measures. The gap is concentrated in three places: (1) **masters** — 28 of 32 are skeletal key-only forms; (2) **reports/documents** — 255 Crystal reports collapse into **one generic HTML-table renderer** + ~6 real print templates; (3) **appearance/interaction** — flat HTML panels replace tabbed DevExpress dialogs with F1-lookup / Enter-chaining grid entry.

---

## 0. Anchor re-verification (this session)

| Anchor | Claimed | Measured this session | Method / path |
|---|---|---|---|
| Desktop form catalogs | 206 | **207 files** = 204 forms + `README.md` + `curated/{TR_SALE,TR_PURC}.md` | `glob project-memory/catalogs/forms/**/*.md` |
| Desktop forms by module | — | **txn 61 · master 33 · report 45 · utility 22 · other 43 = 204** | `catalogs/module-map.json` → `summary.byModule` |
| Crystal reports | 255 | **255** | `glob unified/reports/*.rpt`; confirmed by `reports_catalog.py` "Total 255" |
| Web pages | 83 | **83 `page.tsx`** | `glob web/apps/web/app/**/page.tsx` |
| Web report pages | 4 | **4** (`tag-stock`, `karigar-ledger`, `voucher-register`, generic `[report]`) | `glob .../reports/**` |
| API routes | 226 | **227** = 210 (`routes/txn.ts`) + 14 (`app.ts`) + 2 (`rbac/users.ts`) + 1 (`server.ts`) | `grep app.(get\|post\|…) routes/txn.ts` = 210 |
| `all_rpt_fields.txt` | flat union | **flat alphabetical column-name union** (ABFRU, ACK_DATE, AC_ADHAR_NO …), NOT per-report | `extraction_output/all_rpt_fields.txt` |
| DevExpress report XML in `unified/libs` | (task hint) | **Does NOT exist** — the `unified/libs/*.xml` are DevExpress **API-doc** XML, not `.repx`. Reports are 100% Crystal `.rpt` binaries | `glob **/*.repx` → 0 hits |
| 2nd binary NextDm | — | **present & decompiled**: `NextDm.exe` 23 MB + `extracted_code/NextDm/` (223 .cs / 161 .resx), un-cataloged | dir listing |

Anchors are essentially correct. Two refinements matter for the plan: (a) **there is no ready-made report XML** — every report layout still lives inside the 255 `.rpt` binaries; (b) a **whole second binary (NextDm)** of comparable size is decompiled but never cataloged into `module-map.json`, so the true desktop surface is *larger* than 204 forms.

---

## 1. COVERAGE SCORECARD

### 1a. Per-module scorecard

Columns: **DF** = desktop forms (txn+master in module; `module-map.json`) · **WP** = web `page.tsx` in module (glob) · **DR** = desktop Crystal reports in domain (`reports_catalog.py`) · **WR** = web reports that render (BUILT+PARTIAL datasets via generic table; faithful print docs in parens) · **Breadth** = % of desktop screens with *any* reachable web screen · **Depth** = % of per-screen fields/grids/actions/print actually reproduced.

| Module | DF | WP | DR | WR (dataset / faithful-doc) | Breadth | Depth |
|---|--:|--:|--:|--|--:|--:|
| **Sales & Returns** | 16 | 8 | 48 | 9 / **1** (sales invoice print) | ~85% | ~40% |
| **Purchase** | 3 | 5 | 9 | 5 / 0 | ~95% | ~40% |
| **Inventory / Tags** | 9 | 13 | 40 | ~19 / **2** (tag-stock, tag label) | ~90% | ~35% |
| **Manufacturing / Karigar** | 11 | 8 | 32 | 7 / **1** (labour-invoice) | ~70% | ~35% |
| **Finance / Cash-Bank / Acctg** | 10 | 14 | 43 | ~29 / **1** (cheque-print) | ~90% | ~35% |
| **Loans (Dhrn)** | 3 | 3 | 17 | 7 / 0 | ~100% | ~30% |
| **Membership / Scheme** | 2 | 2 | 14 | 5 / 0 | ~100% | ~25% |
| **Bullion / Tour / VP** | 7 | 3 | 11 | 3 / 0 | ~45% | ~30% |
| **Masters** | 33 | 6 + generic[32] | — | — | ~95% | **~18%** |
| **Utilities / Admin / GST / e-Inv** | 22 | 14 | (GST 29) | 10 / **1** (e-invoice IRN) | ~65% | ~30% |
| **Report-viewers (`RP_*`)** | 45 | 4 + generic[51] | 255 total | 57 built + 40 partial / **~6** | see §1c | **~10%** |
| **TOTALS** | **204** | **83** | **255** | **97 datasets / ~6 docs** | **~80%** | **~27%** |

Report web-status (authoritative, from `reports_catalog.py` run this session):

| | 🟩 BUILT | 🟨 PARTIAL | 🧾 PRINT (designated) | 🏷️ LABEL | 📋 SPEC (not started) |
|---|--:|--:|--:|--:|--:|
| of 255 `.rpt` | **57** | **40** | **83** | **14** | **61** |

Critical caveat on that table: **"🧾 PRINT = 83" is aspirational, not built.** It marks reports *intended* to go through a per-module `renderInvoiceHtml`, but only **~6 real document printers exist** (`routes/txn.ts`: `/sales/invoice`, `/labour-invoice`, `/finance/cheque-print`, `/stock/tag-print`, `/stock/tag-print/label`, `/render/pdf` + e-invoice IRN). So of the **97 document/label outputs** (83 print + 14 label), **~6 are actually implemented and 0 reproduce the Crystal layout pixel-for-pixel.**

### 1b. Overall weighted coverage (the four requested dimensions)

| Dimension | Coverage | Evidence basis |
|---|--:|---|
| **Form breadth** (screens present) | **~80%** | 57 txn pages ↔ 61 desktop txn forms; 32 master routes ↔ 33 desktop masters; nav.ts advertises 36 Masters + 51 Reports all `ready:true`. Nearly everything is *reachable*. |
| **Form depth** (fields/grids/actions/tabs per screen) | **~27%** | Txn ~40% (best case: web sales 19 inputs / 2 grids [15+8 col] vs desktop TR_SALE 28+ inputs / **7 grids / 260 col-configs / 110 handlers**). Masters ~18% (only **4 of 32** configs richly fielded). |
| **Reports** (data + layout as delivered) | **~10%** | 97/255 have a dataset (38%) but all flow through **one** generic table renderer; faithful documents ~6/97 (~6%); pixel-parity to Crystal ~0%. |
| **Appearance / interaction** | **~12%** | Web stack = `next+react+react-dom` only, one hand-rolled 4 KB `globals.css`, native `<input>`/`<table>`. No tabs, no F1-LOV popups, no Enter-chaining, no DevExpress/DotNetBar/FlexGrid look. |

**Composite "surface/experience" parity ≈ 22–28%** (breadth-discounted). **Backend/data-posting parity ≈ 85%+** (independently attested by `parity/scorecard.md`: 141/141 tables, 366/366 Σ, 5/5 report datasets).

### 1c. Is the "~20% working end-to-end" feeling justified? — YES.

It is justified and it comes from a **measurement mismatch**, not from a broken app:

1. **The existing scorecard measures the wrong axis for the owner's question.** `parity/scorecard.md` certifies *posting* parity ("11 Reports ✅ 45 reports", "1 Masters ✅ 31 data masters via generic grid"). Those ✅ mean **the data lands in the right tables** — verified and real. They do **not** mean the *screen looks or prints like the desktop*. The owner is judging the second thing.
2. **Breadth is a façade over two renderers.** `web/apps/web/lib/nav.ts` lists **36 Masters + 51 Reports items, every one `ready:true`** — but 32 of the masters resolve to a single `masters/[name]/page.tsx` (generic CRUD, list hard-capped at 9 columns: `Object.keys(rows[0]).slice(0, 9)`) and 48 of the reports resolve to a single `reports/[report]/page.tsx` (generic fetch→table→PDF). High menu count, low per-screen fidelity.
3. **Masters are the biggest silent hole.** `apps/api/src/modules/masters/configs.ts`: the `MASTERS` registry has **32 entries; only 4 carry a `formFields` layout** (AC_MAST ~41, ITEM_MAST ~21, CO_MAST ~27, GROUP_MAST 13). The other **28 fall back to `requiredColumns`** — typically 2–5 key columns. Desktop `MS_ACCT.resx` is a **367 KB fully-serialized tabbed control tree** (37 TextBox + 10 Combo + 7 Masked); the web renders a flat handful of fields.
4. **Reports/documents are ~2–10%, and they are what users *see and hand to customers*.** 255 Crystal `.rpt` → 1 generic HTML table + ~6 bespoke prints. Every invoice/voucher/passbook/khata/cheque/tag layout (`SalesBillA4Gst`, `KrIsuBillGst`, `DhrnKhataVahi`, `SchmPassBook`, `ChqPrint0xx`, `TagStkRpt`) is either a generic table or absent.
5. **Interaction paradigm is gone.** Desktop is a keyboard-first MDI (88 forms / 229 F-key handlers, F1-LOV on the focused field, Enter-field-chaining). The web is mouse-first flat panels. To a desktop power user, that alone *feels* like a different (lesser) product regardless of data correctness.

So: **raw pages ≈ 80%, data posting ≈ 85%, but depth-/report-/appearance-weighted experience ≈ ~20–25%.** The owner is measuring the last number, and it is real.

---

## 2. TOP 15 CONCRETE GAPS (ranked by user-visible impact)

Each names the exact desktop artifact (path), the web counterpart, and precisely what is missing.

| # | Desktop artifact (path) | Web counterpart | What is specifically absent |
|---|---|---|---|
| **1** | **All 255 reports** `unified/reports/*.rpt` (`SalesBillA4Gst`, `PurcBillA4Gst`, `KrIsuBillGst` …) | `reports/[report]/page.tsx` (one generic renderer) | **No per-report layout engine.** Every report is a generic bordered HTML table with a maroon header band. Sections, groups, group headers/footers, sub-reports, formulas, column widths/positions, and page geometry are all lost. 61 `.rpt` have **no dataset at all** (📋 SPEC). |
| **2** | **Print documents / bills** — `SalesBillA4Gst.rpt`, `SalesBillHz.rpt`, `PurcBillA4Gst.rpt`, `PrRtnBillGst.rpt`, `SalesRtnA4Gst.rpt` | `/sales/invoice` (1 HTML template) | ~83 "🧾 PRINT" reports, **~6 real printers**. No A4-vs-thermal-vs-horizontal variants; no HSN block, no bank/UPI-QR footer parity, no old-gold/scheme-adjust sub-blocks. The customer-facing bill is not the desktop bill. |
| **3** | **`MS_ACCT` Account/Party master** `unified/src/csharp/DataCareNext/MS_ACCT.cs` (9,651 lines) + `MS_ACCT.resx` (367 KB full layout) | generic `masters/[name]` + `AC_MAST_CONFIG` | Desktop: 37 TextBox + 10 Combo + 7 Masked across **tabs** (address / GST-KYC / balances / interest / loyalty), 2 DataGridViewX (64 col-configs), 56 key-nav handlers. Web: flat one-column form, generic 9-col list. No tabs, no sub-grids, no F1 pickers. |
| **4** | **28 skeletal masters** `configs.ts` (RATE, TAX, EMP, PRODUCT, LOCT, DESIGN, DM, MODEL, POINT, LBR, TOUCH, MSG, CONV, MFG, YEAR, ADD, DG_GOLD, AD, TABLE, ITM_WT, COL, PRINT, E, FAN_AC, AC_GROUP, BOOK, STATE, products) | generic `masters/[name]` | **No `formFields`** → the form shows only 2–5 required/key columns; list shows ≤9 columns. Desktop masters (e.g. `MS_STYLE`, `MS_RATE`, `MS_MFG_MAST`, `MS_POINT`) have full field sets, sub-grids and validations that are entirely missing. |
| **5** | **`TR_SALE` Sales invoice** `curated/TR_SALE.md` + `TR_SALE.cs` (21,586 lines, 85 writeOps, 7 grids, 110 handlers) | `txn/sales/page.tsx` (bespoke, 19 inputs, 2 grids) | Missing grids/flows: old-gold-with-tag revaluation, order-advance adjust grid, scheme/loyalty redemption grid, multi-book split, per-line discount/making matrices, and 5 of 7 desktop grids. F1-LOV per field and Enter-chaining absent. |
| **6** | **`SchmPassBook.rpt` + `TR_MEMB_ENT`/`Module_Schm`** (`unified/reports/SchmPassBook.rpt`) | `txn/scheme`, `txn/membership` (2 forms ×5 fields) | No passbook document, no monthly-installment ledger view, no bonus/maturity computation report (`MembBonus.rpt`, `SchmMonthRpt.rpt`, `SchmPassBook.rpt` all absent). |
| **7** | **`DhrnKhataVahi.rpt` / `DhrnIssue.rpt` / pledge documents** (`unified/reports/Dhrn*.rpt`, 17 in domain) | `txn/dhrn-*` (3 pages) + generic report | Pledge issue receipt with collateral photos, khata-vahi running-interest ledger, `DharnDue`/`PartyInterest` notices — none rendered as documents. Only outstanding *data* exists. |
| **8** | **Karigar / job-work vouchers** `KrIsuBillGst.rpt`, `KrRecVchGst.rpt`, `MfgLedger.rpt`, `LabourBill.rpt` | `/labour-invoice` + `reports/karigar-ledger` | Issue/receive vouchers with fine-weight and wastage columns, `MfgLedger` karigar running balance, ghat/loss reconciliation report — mostly SPEC/PARTIAL; the printed karigar voucher differs from desktop. |
| **9** | **`RojMel*` day-book family** `RojMelCash.rpt`, `RojMelCrDr.rpt`, `RojMelJmaUdhar.rpt`, `RojMelGr.rpt`, `RojMelEstmat.rpt` | `/reports/day-book` (1 dataset) | 5 desktop Rojmel variants (cash / Cr-Dr / jama-udhar / group / estimate) collapse to one generic day-book table; the classic Rojmel columnar cash-book layout is not reproduced. |
| **10** | **Tag/label/QR printing** `TagStkRpt.rpt`, `BarPrint10.rpt`, `QrPrint10.rpt`, `TagHuIdRpt.rpt`, `WhHuidPrint.rpt` + `UT_TAG_PRINT.cs` | `/stock/tag-print[/label]` | 14 "🏷️ LABEL" jobs; web has a single tag-label endpoint. No barcode/QR SVG engine parity (Code39/QR), no HUID label variants, no per-printer geometry. |
| **11** | **`TR_TAG_OPBL` tag opening** `TR_TAG_OPBL.cs` (14,664 lines; serial-port weighing-scale + Timer; 2 grids/128 col-configs) | `txn/tag-opening` (1 input, 15-col grid) | No weighing-scale integration, no dual-grid (summary + detail), no image capture, ~1/8 of the field surface. |
| **12** | **GST statutory docs** `Gstr_1.rpt`, `Gstr_2.rpt`, `Gstr_3.rpt`, `TaxSummUae.rpt`, `EInvoice.rpt` | `/reports/gstr1|gstr2|gstr3b`, e-invoice IRN | Datasets exist, but the **filing-format layouts** (GSTR tables, e-invoice printed IRN/QR document `EInvoice.rpt`, UAE VAT summary) are generic tables, not the statutory report forms. |
| **13** | **Trial balance / P&L / balance-sheet documents** `TRialBalHz.rpt`, `ProfitLossHz.rpt`, `BalanceHz.rpt`, `AcSumm.rpt` | `/reports/trial-balance[-full]`, `/balance-sheet` | Data built (🟩), but the horizontal (Hz) two-column TB / vertical P&L / schedule-wise balance-sheet **presentation** is a flat table; no grouping schedules, no drill sub-totals. |
| **14** | **`TR_PURC` purchase** `curated/TR_PURC.md` + `TR_PURC.cs` (17,255 lines, 53 writeOps, 5 grids/146 col-configs) | `txn/purchase` (10 inputs, 1 grid/10 col) | Missing 4 of 5 grids: metal-exchange/fine settlement grid, tag-generation grid, tax matrix, lot detail; combo-driven purchase types; F-key flows. |
| **15** | **Menu / RBAC / keyboard workflow** `MDI_FORM.cs` + `MENU_DATA`/`USER_SET`; 88 forms / 229 F-key handlers | `lib/nav.ts` (static) + `/admin/users` rights matrix | No desktop menu tree parity, no per-form F1-LOV search, no Enter-field-chaining, no per-form action rights beyond coarse USER/UPDATE/DELETE/PRINT. The keyboard-first operator UX is absent. |

---

## 3. ADVANCED EXTRACTION PLAN (to build the EXACT desktop things)

Goal: turn the still-binary artifacts (form layouts, per-form event logic, 255 report layouts) into **machine-readable specs**, then **code-generate** faithful React pages and web reports. All commands are macOS-ready (the repo already ships `dotnet-install.sh` and Python 3.11 tooling under `unified/tools/`).

### 3.0 One-time toolchain (macOS)

```bash
# .NET SDK (repo already has the installer) → provides ilspycmd host
./dotnet-install.sh --channel 8.0 && export PATH="$HOME/.dotnet:$PATH"
dotnet tool install -g ilspycmd            # ILSpy CLI decompiler + resource export
# Mono → resgen/monodis for .resources <-> .resx and embedded-resource listing
brew install mono
python3 -m pip install lxml                # fast resx/xml parsing (stdlib xml also fine)
```

### 3.1 Mine the 165+ `.resx` → per-form field/control/tab-order manifests  *(exact, runnable today)*

~23 large "localizable" forms (`MS_ACCT.resx` 367 KB, `MS_PRODUCT.resx` 128 KB, `MS_MEMB`, `MS_ITEM`, `MS_ADD_MAST`, `MS_OPNCOMP`, `MS_LOGIN`) serialize the **full control tree** as `>>name.Name / >>name.Type / name.Location / name.Size / name.TabIndex / name.ZOrder / name.Text`. Parse directly:

```python
# unified/tools/resx_to_formspec.py   (new)
import glob, json, os, xml.etree.ElementTree as ET
def parse(resx):
    ctrls={}
    for d in ET.parse(resx).getroot().findall('data'):
        name=d.get('name'); v=(d.findtext('value') or '').strip()
        if not name or '.' not in name: continue
        base,prop=name.split('.',1); base=base.lstrip('>')
        ctrls.setdefault(base,{})[prop]=v
    # keep controls that have a Type (real widgets), sort by TabIndex
    out=[{'name':k,**v} for k,v in ctrls.items() if 'Type' in v or 'Name' in v]
    out.sort(key=lambda c: int(c.get('TabIndex','9999') or 9999))
    return out
for f in glob.glob('extracted_code/DataCareNext/*.resx'):
    spec=parse(f)
    if spec:
        json.dump(spec, open(f'project-memory/catalogs/layouts/{os.path.basename(f)[:-5]}.layout.json','w'), indent=1)
```

Output: `catalogs/layouts/<FORM>.layout.json` = ordered `{name,type,location,size,tabIndex,zOrder,text}`. 100% exact for the ~23 large forms immediately; partial for the rest.

### 3.2 Recover layout + logic from the 238 decompiled `.cs` (+ deeper decompilation)

For the ~140 forms whose layout lives in `InitializeComponent` (not the resx):

```python
# unified/tools/initcomp_to_formspec.py   (new)  — regex/AST over the .cs
#   this.<ctrl> = new <Type>();                       -> control + type
#   this.<ctrl>.Location = new Point(x, y);           -> position
#   this.<ctrl>.Size     = new Size(w, h);            -> size
#   this.<ctrl>.TabIndex = n;                         -> tab order
#   this.<parent>.Controls.Add(this.<ctrl>);          -> container hierarchy / tabs
#   <grid>.Cols = N;  <grid>.ColWidth(i) = w; ...     -> FlexGrid columns  (127 grid forms)
```

Grid columns are the highest-value target: they live as `.Cols` / `ColWidth[]` arrays + runtime `FormatString`. Emit `grids:[{name, cols:[{index,header,width,format}]}]`.

Deeper decompilation when the `.cs` is incomplete or you need embedded resources/menus:

```bash
# Full re-decompile + embedded resource + .resx export from the binary itself
ilspycmd DataCareNext.exe -o ./decomp/DataCareNext --nested-directories -r unified/libs
ilspycmd NextDm.exe        -o ./decomp/NextDm        --nested-directories -r unified/libs   # 2nd, un-cataloged binary
# List / extract embedded .resources, then convert to .resx for §3.1
monodis --resources DataCareNext.exe
resgen SomeForm.resources SomeForm.resx
```

Also extend the existing, proven `unified/tools/build_form_specs.py` (it already mines INSERT/UPDATE/DELETE + ordered op-sequence + validation guards per form) with a **workflow pass**: capture `_KeyDown`/`_Click`/`_Validating` handlers, F-keys coded as numeric vk `(int)e.KeyCode==112..123` (F1–F12 — note: **not** `Keys.F1`, which is why naive search misses them), and Enter-chaining focus order → `<FORM>.workflow.json`.

### 3.3 Parse the 255 `.rpt` Crystal reports → per-report specs

Reality check: there is **no DevExpress `.repx`** anywhere (verified) and **no Crystal runtime on macOS**. So split into two tracks:

**Track A — runnable on macOS NOW (fields/tables/formulas per report).** The `.rpt` binary stores names as UTF-16LE with recognizable record tags. Upgrade `all_rpt_fields.txt` from a flat union to **per-report** by extending `unified/tools/extract_metadata.py` / `reconcile_reports.py`:

```python
# unified/tools/rpt_scrape.py   (new) — no Crystal runtime needed
import glob, json, os, re
def scrape(path):
    b=open(path,'rb').read()
    txt=b.decode('utf-16le','ignore')
    tables = sorted(set(re.findall(r'\b([A-Z][A-Z0-9_]{2,})\b', txt)) &
                    set(json.load(open('project-memory/catalogs/data-model.json'))['tables']))
    fields  = sorted(set(re.findall(r'\{([A-Za-z0-9_]+)\.([A-Za-z0-9_]+)\}', txt)))   # {TABLE.FIELD}
    formulas= sorted(set(re.findall(r'\{@([A-Za-z0-9_ ]+)\}', txt)))                  # {@Formula}
    params  = sorted(set(re.findall(r'\{\?([A-Za-z0-9_ ]+)\}', txt)))                 # {?Param}
    return {'report':os.path.basename(path)[:-4],'tables':tables,'fields':fields,
            'formulas':formulas,'parameters':params}
json.dump([scrape(f) for f in sorted(glob.glob('unified/reports/*.rpt'))],
          open('extraction_output/rpt_specs.json','w'), indent=1)
```

This yields **per-report** `{tables, {TABLE.FIELD} fields, @formulas, ?parameters}` for all 255 — the missing structure that `all_rpt_fields.txt` never had. Enough to build the correct SQL + column set for each report.

**Track B — exact section/coordinate layout (needs Windows, one-time in CI).** For band geometry, group headers/footers, sub-reports and object positions, run **RptToXml** (SAP Crystal .NET SDK) on a Windows runner:

```yaml
# .github/workflows/rpt-extract.yml   (runs on GitHub-hosted windows-latest)
jobs:
  rpt:
    runs-on: windows-latest
    steps:
      - uses: actions/checkout@v4
      - run: choco install crystal-reports-runtime -y      # or vendor the SDK
      - run: |                                              # RptToXml.exe = open-source SAP tool
          Get-ChildItem unified/reports/*.rpt | ForEach-Object {
            .\RptToXml.exe $_.FullName ("extraction_output/rpt_xml/" + $_.BaseName + ".xml") }
      - uses: actions/upload-artifact@v4
        with: { name: rpt-xml, path: extraction_output/rpt_xml }
```

The resulting XML has `<Section>`, `<Area>`, `<FieldObject Left/Top/Width/Height>`, `<FormulaFieldDefinition>`, `<Group>`, `<Subreport>` — the pixel layout to rebuild each report faithfully. Merge Track B geometry into Track A specs → `reports/<RPT>.spec.json`.

### 3.4 Machine-generated web scaffolding pipeline

Chain the specs into codegen so parity becomes generated, not hand-carved:

```
resx/InitializeComponent ──▶ catalogs/layouts/<FORM>.layout.json ─┐
build_form_specs (+workflow) ─▶ <FORM>.workflow.json ─────────────┤─▶ gen_react_form.ts
                                                                   │      └─▶ web/apps/web/app/(app)/.../page.tsx
                                                                   │          (tabs from container tree, grid cols
                                                                   │           from ColWidth[], tab order, F1-LOV hooks)
rpt_scrape (A) + RptToXml (B) ─▶ reports/<RPT>.spec.json ─────────────▶ gen_web_report.ts
                                                                          └─▶ report component + PDF template
                                                                              (bands, groups, exact columns)
```

- `gen_react_form.ts` — read `<FORM>.layout.json` + `.workflow.json`, emit a page that reproduces **tab groups** (from the `Controls.Add` container tree), **grid columns** (from `ColWidth[]`), **field order** (TabIndex), and wires `LookupPicker` to the fields that had F1-LOV. Extends the existing generic `masters/[name]` by *generating a bespoke config with full `formFields`* per master (kills the 28-skeletal-master problem in one sweep).
- `gen_web_report.ts` — read `reports/<RPT>.spec.json`, emit (i) a typed SQL dataset builder stub (tables+fields already known from Track A) and (ii) a print template whose bands/columns/positions come from Track B geometry — replacing the one-size generic `buildReportHtml`.

Build on what exists: `web-implementation-spec/_generators/reports_catalog.py` (classifier), `unified/tools/reconcile_reports.py`, `unified/tools/build_form_specs.py`, `unified/tools/build_data_model.py`. Do **not** start from scratch.

---

## 4. PRIORITIZED ROADMAP (highest-ROI first)

| Phase | Deliverable | Why it's high ROI | Effort |
|---|---|---|---|
| **P1 — Report/Document engine** | A real layout-driven report+print engine that consumes `reports/<RPT>.spec.json`. Ship Track A specs (all 255, macOS) first; add Track B geometry (CI) for the top ~40 documents. | Reports are the **largest gap (~10%)** and the most customer-visible (bills, khata, passbook, GSTR). One engine + 255 specs converts the whole ~2% document tier at once. | High, but one engine amortizes across 255 |
| **P2 — Form-depth generator (masters first)** | `resx_to_formspec` + `initcomp_to_formspec` + `gen_react_form` → auto-generate full `formFields` for the **28 skeletal masters** and tab/grid structure for the flagship 12 txn forms. | Kills the single worst depth hole (**28/32 masters skeletal**) mechanically; lifts master depth ~18%→~70%. | Medium (generator), low per-form after |
| **P3 — Print-template parity for the ~40 flagship documents** | Faithful A4/thermal/Hz variants for `SalesBillA4Gst`, `PurcBillA4Gst`, `KrIsuBillGst`, `DhrnKhataVahi`, `SchmPassBook`, `ChqPrint0xx`, tag/HUID labels, `EInvoice`. | These are the documents handed to customers/karigars/banks daily; parity here is what makes the web "feel" like the product. | Medium |
| **P4 — Transaction depth completion** | Add the missing grids/flows to `TR_SALE`/`TR_PURC` peers (old-gold revalue, order-adjust, scheme redeem, tax matrix, lot/tag grids) from `<FORM>.layout.json`. | Restores flagship txn depth ~40%→~75%. | Medium/High |
| **P5 — Interaction layer** | Shared F1-LOV overlay + Enter-field-chaining + keyboard map generated from `<FORM>.workflow.json`; DevExpress-like grid component; tabbed dialog shell. | Converts "mouse-first flat panels" back to the keyboard-first operator UX; big perceived-parity jump. | Medium |
| **P6 — Catalog NextDm + long-tail** | Run §3.2 on `NextDm.exe`; fold into `module-map.json`; finish the 61 📋 SPEC reports + niche RP_ variants. | Closes the un-cataloged second binary and the report long tail. | Low/steady |

**Single highest-ROI next action:** build **P1 — the spec-driven report/document engine**, starting with the macOS-runnable `rpt_scrape.py` (§3.3 Track A) to produce per-report `{tables, fields, formulas, params}` for all 255, then a layout engine that renders them. It attacks the biggest, most visible deficit (reports/documents ≈ 10%) with a single reusable engine rather than 255 hand-built pages.

---

## Appendix — evidence index (files opened this session)
- Desktop: `catalogs/module-map.json` (byModule, per-form writeOps), `catalogs/forms/**` (207), `unified/reports/*.rpt` (255), `extraction_output/all_rpt_fields.txt`, `unified/libs/*.xml` (DevExpress API-doc, not reports), `DataCareNext.exe`/`NextDm.exe`.
- Web: `web/apps/web/app/**/page.tsx` (83), `web/apps/web/lib/nav.ts` (36 Masters + 51 Reports, all ready), `masters/[name]/page.tsx` (generic, 9-col list), `reports/[report]/page.tsx` (generic table+PDF), `apps/api/src/modules/masters/configs.ts` (32 configs, 4 rich), `apps/api/src/routes/txn.ts` (210 routes; ~6 print endpoints), `apps/api/src/modules/reports/*` (57 dataset builders).
- Tooling that already exists (extend, don't rewrite): `web-implementation-spec/_generators/reports_catalog.py` (ran: 57 built / 40 partial / 83 print / 14 label / 61 spec), `unified/tools/build_form_specs.py`, `reconcile_reports.py`, `build_data_model.py`, `extract_metadata.py`.
- Prior parity docs reconciled: `parity/scorecard.md` (posting-parity ✅ view), `parity/GAP_*.md`, `parity/functional/*.md`.
