# UNEXTRACTED / UN-MINED / UN-REPLICATED — MASTER INVENTORY

_Independent synthesis (session `synthesis`). Date: 2026-07-02. Combines Audit A (desktop binary+source) and Audit B (reports+resources+integrations). **Every count below was re-measured from files this session; paths cited inline.** Goal: enumerate everything in `/Users/yakshitsavaliya/Desktop/imodule-extracted` that is still NOT extracted, NOT catalogued, NOT understood, or NOT replicated in the web build — with the reason and the macOS-vs-Windows extraction path for each._

---

## 1. EXECUTIVE SUMMARY

The desktop product is **two binaries the owner named (DataCareNext.exe + NextDm.exe) plus a third companion (NextEmp.exe)**. The single most important reframing this synthesis delivers is that **NextDm is NOT a second, un-catalogued feature surface.** It decompiles to the *same* assembly/namespace `DataCareNext` (`extracted_code/NextDm/DataCareNext/` = **199 `.cs`** vs DataCareNext's **204 `.cs`**), shares **199 forms with 0 unique to NextDm**, and differs only by ~8 months of version drift (e.g. `TR_SALE.cs` = **21,586 LOC** in DataCareNext vs **21,339 LOC** in NextDm — same file, drifted). **Net-new form surface from NextDm ≈ 0.** The "430 un-catalogued .cs" is the same product decompiled twice. This removes what looked like the largest gap.

Weighting the remaining desktop by *extraction* state:

| State | Share of desktop | What it covers |
|---|--:|---|
| **(a) Extracted AND understood** | **~55%** | 204 form sources decompiled + catalogued (`project-memory/catalogs/forms/` = 204 md); 141/141 data tables modelled; 255 report **names/fields** (`rpt_specs.json`, 53,520 field refs); 15 richest form layouts mined (`catalogs/layouts/`); config/integrations mapped. |
| **(b) Extracted but NOT mined** | **~30%** | Decompiled `.cs` whose *field-level logic* is not yet translated to web specs (per-form validations, calc, event/F-key handlers, inline SQL); ~150 flagship-form layouts that live in `InitializeComponent` code (not resx); version-diff deltas; NextEmp binary. |
| **(c) NOT yet extracted** | **~8%** | `AllImage.rar` (17.56 MB image store), `NextImage.mdf/.ldf` SQL image DB, `SqlData/Next23-25` real databases, `output.xlsx` template, 20 `.rpt` referenced-but-missing, NextEmp source (never decompiled to disk). |
| **(d) Locked / blocked** | **~7%** | **Crystal `.rpt` section+coordinate geometry for all 255 reports** — the *only* genuinely Windows-only artifact class. |

**Single biggest remaining lever — the un-mined layout-in-code + per-form logic that is already decompiled on this Mac.** Roughly **150 flagship forms keep their entire visual layout inside `InitializeComponent()` C#, not in resx** (`TR_SALE.cs` alone makes **141 `.Location`** calls; TR_PURC ~115; TR_TAG_OPBL ~88). Those same files hold the validations, weight/fine/labour calc, F-key LOV wiring and inline SQL that the web has not reproduced (the project's own freshest audit puts **form depth at ~27% and masters at ~18%** — `parity/DESKTOP-VS-WEB-DEPTH-AUDIT.md`). This is the highest-ROI lever because it simultaneously unlocks **form depth AND appearance** for the screens users spend all day in, it gates the masters (28 of 32 are key-only skeletons today), and — critically — **it requires zero Windows dependency** (`ilspycmd`/grep/a new InitializeComponent parser, all macOS). The biggest *blocked* lever is separate: **Crystal `.rpt` geometry** (§3), which is the only thing forcing a Windows CI runner and which owns the visible "documents look nothing like the desktop" gap.

---

## 2. MASTER TABLE OF REMAINING ARTIFACTS

Columns — **Count/Size** · **Current state** · **Unlocks for web parity** · **macOS-doable? (tool) / Windows-only** · **Effort** · **Priority**.

| # | Artifact class | Count / Size | Current state | Unlocks for web parity | macOS? (tool) / Win-only | Effort | Priority |
|---|---|---|---|---|---|---|---|
| 1 | **NextDm forms** | 199 `.cs` (`extracted_code/NextDm/DataCareNext/`); 23.38 MB binary | Decompiled ×2, un-catalogued. **0 forms unique vs DataCareNext**; 76 byte-identical, 123 version-drift | **~Nothing net-new.** Only a version-diff signal (which code is newer). Do **not** re-catalogue | ✅ macOS (`diff` / `ilspycmd`) | Low | **LOW** (diff-only) |
| 2 | **NextEmp** | 320,000 B binary + `.pdb`+`.xml` (`unified/binaries/NextEmp.exe`); **0 `.cs` on disk** | Understood via Audit A (WhatsApp/SMS bulk-messaging companion; `msg_mast`, `UT_WHATSAPP_OLD`, Excel import). Source never persisted | Bulk marketing-list messaging + `MSG_MAST` send-log (no web equivalent) | ✅ macOS (`ilspycmd NextEmp.exe`) | Low | **MED** |
| 3 | **Per-form logic** (validations/calc/handlers/SQL) | 204 forms; sampled 12 ≈ 146,800 LOC / ~486 writeOps / ~714 handlers (`TR_SALE`=21,586 LOC) | Decompiled, **not translated to web specs**. Web depth ~27% | Field-level validations, weight/fine/labour calc, posting side-effects, **weighing-scale serial I/O** (2 forms), **7 background Timers**, F-key VK-int handlers | ✅ macOS (grep / AST over `.cs`) | High | **HIGH** |
| 4 | **`.rpt` GEOMETRY** | 255 reports (`unified/reports/*.rpt`); geometry in OLE `Contents` stream (0/255 plaintext) | Names+fields done (`rpt_specs.json`); **sections / FieldObject Left-Top-W-H / fonts / formulas / params / subreports LOCKED** | Pixel-exact bills/vouchers/labels/passbooks — the #1 visible gap (reports ~10%) | ⛔ **WINDOWS-ONLY** (RptToXml + Crystal .NET SDK) | High | **HIGH** (97 critical) |
| 5 | **Missing `.rpt`** | 20 (`catalogs/report-reconciliation.json` `stillMissing`) | Referenced in code but absent from every source root (e.g. `krisureport`, `franchisebill`, `jdtvch`) | 20 more document layouts once located | ✅ locate (macOS) → then ⛔ Win geometry | Med | **MED** |
| 6 | **`.resx` layouts** | 652 = 165+161 (`extracted_code/*`) ×2 mirror (`unified/resources/*`); **165 distinct DataCareNext, 161 NextDm** | **Mining COMPLETE** for the 15 rich ones (`catalogs/layouts/`, e.g. `MS_ACCT`=152 controls). Remaining are empty shells | Marginal — richest layouts already extracted | ✅ macOS (`resgen`/XML parse) | Low | **LOW** (done) |
| 7 | **`InitializeComponent` layouts** | ~150 forms (layout in code, not resx). `TR_SALE`=141 `.Location`, `TR_PURC`~115, `TR_TAG_OPBL`~88 | **NOT mined** — no parser exists for layout-in-code | Full field/tab/grid geometry for flagship txn+master forms → form depth 27%→high, appearance | ✅ macOS (**new** InitializeComponent `.cs` parser) | Med | **HIGH** |
| 8 | **DevExpress control surface** | ~20 licensed controls (`DataCareNext.exe.licenses`) + DotNetBar2 + Crystal interop | Identified, not emulated. Web = native `<input>`/`<table>` | Widget targets: XtraGrid (FlexGrid), XtraBars Ribbon/Docking, XtraEditors LOV, XtraLayout tabs, TreeList, PivotGrid, RichEdit, Spreadsheet | ✅ macOS (`strings` — done) | Med (build) | **MED** |
| 9 | **Images / fonts** | `AllImage.rar` 17.56 MB (+173 loose files, 8 subdirs); `NextImage.mdf/.ldf`; `FRE3OF9X.TTF` (Code-39, 7,220 B), `KAP139.TTF` (Gujarati, 52,164 B) | `.rar` unexpanded; SQL image DB not read; barcode font web-replaced by SVG; KAP139 usage unknown | Tag/product/scheme/repairing images; Gujarati label glyphs | ✅ macOS (`unrar`; SQL Server-in-Docker for `.mdf`) | Low–Med | **MED** |
| 10 | **Integrations** | WhatsApp (`DevNet.WhatsApp.V2.dll` 5.48 MB Selenium + `WebDriver.dll` 9.2 MB + chromedriver **AND** Graph Cloud API); SMS ×3 gw; `FireSharp.dll` (Firebase); `DirectShowLib.dll` (webcam); `QRCoder.dll` | Web ports **Cloud API only**; drops Selenium; **no `MSG_MAST` send-log**; Firebase/webcam/QR not ported | Send-log persistence, Selenium fallback, Firebase sync, webcam capture, QR | ✅ macOS (`ilspycmd`) | Med | **MED** |
| 11 | **Real SQL databases** | `SqlData/`: `Next23.BAK`, `Next24/.25 .mdf+.ldf`, `NextMain.BAK`, `NextImage.mdf` | **NOT ETL'd.** Real multi-year schema + production data | Ground-truth schema, migration source, realistic test fixtures, multi-year switching semantics | ✅ macOS (SQL Server-in-Docker + `mssql-tools`/`sqlpackage`) | Med | **MED–HIGH** |
| 12 | **Version-diffs** | 8 EXEs: DataCareNext 15.36→22.65→24.06 MB; NextDm 21.27→23.38 MB; NextEmp 0.32 MB | Sizes/dates known. **5 newest-only forms**: `TR_FN_INOUT`, `RP_STOCK_VALUE`, `UT_PWD_UPDATE`, `OlockerService`, `PolicyModels` + regulatory `UT_E_INVOICE`/`TR_UPI_REC`/`TR_PR_SL_UAE`/`TR_SALE_RTN_UAE`/`RP_HUID` | Tells web which features are live vs legacy → target newest (Jun2026) build | ✅ macOS (`diff` / `ilspycmd`) | Low | **MED** |

**Cross-cutting config (all macOS-doable, mostly understood):** `DataCareNext.exe.config`, `App.config`, `SqlName*.txt` (Next23/24/25 DB switching + image path + W/S auth mode), `AuthToken.txt` (25 B license — reference by name only), `GenIRN.txt`/`IRNData.txt` (e-invoice request/response incl. signed JWT + QR PNG — payload ported, print layout `EInvoice.rpt` not). Baked DB identity: `MORVIN\SQLEXPRESS` / cat `Next19`,`Hd19`; DevExpress XPO ORM + raw `SqlClient`.

---

## 3. THE WINDOWS-ONLY SET (exactly one class)

**Only ONE artifact class is genuinely Windows-only: Crystal Reports `.rpt` binary layout GEOMETRY.**

- **What:** For all **255 `.rpt`** (`unified/reports/*.rpt`, 247 also in the deployed `DataCareNextS/Report/`) — the Section/Area structure, per-`FieldObject` `Left/Top/Width/Height`, per-object fonts/borders/colours, `FormulaFieldDefinition` bodies, Group/Sort, page setup, subreport links, and embedded report images.
- **Why blocked:** Crystal stores all of the above inside the OLE compound-document **`Contents` stream in a proprietary, undocumented binary format**. This session confirmed **0/255** reports expose any of it as plaintext in either encoding. The only reader is `RptToXml.exe`, which links `CrystalDecisions.CrystalReports.Engine` — and the **Crystal .NET SDK is Windows-only** (the `CrystalDecisions.*.dll` shipped in `DataCareNextS/` are Windows-target and cannot load on macOS `dotnet`).
- **What is already done on macOS (so it is NOT in this set):** report **names, table bindings, and field references** are fully scraped — `rpt_specs.json` (855,944 B) carries **255 reports, 53,520 field refs, 1,499 table refs**. So the *data contract* of every report is known; only the *pixel layout* is missing.
- **Tiering of the 255 for the Windows pass:** ~**97 CRITICAL** (bills/vouchers/labels/passbooks where the layout *is* the deliverable), **9 HIGH** (≥900 KB image-embedding, e.g. `SalesBillA4_WithImage.rpt` = 4.54 MB, `B2BSaleImgVch` 962 KB, `OrderBill` 944 KB), ~**50 MEDIUM** (statutory/columnar), ~**99 LOW** (analytic registers).
- **Adjacent, resolve first on macOS:** the **20 missing `.rpt`** (§2 row 5) must be *located* (macOS) before geometry can ever be read; and `KAP139.TTF` usage is only confirmable once a report's font table is read (Windows).

**Confirmation that nothing else is Windows-only** — the rest is covered on macOS by the installed `dotnet`:
- `ilspycmd` (invoked via the .NET DLL) decompiles **both** binaries — already produced 204 + 199 `.cs`. ✅
- `monodis` / IL disassembly cover any IL-level questions. ✅
- `resgen`/plain XML parse handle all **652 `.resx`** (15 rich ones already mined to `catalogs/layouts/`). ✅
- `strings` extracts the `.licenses` control list, `AuthToken`, config. ✅
- `unrar` + SQL-Server-in-Docker read `AllImage.rar` and the `.mdf/.bak` data (no Windows needed). ✅
- The **~150 `InitializeComponent` layouts** are plain C# already on disk — a new parser reads them on macOS. ✅

---

## 4. REPLICATION ROADMAP (highest-ROI first)

**Phase 0 — Stop wasted motion (days).** Freeze NextDm as a *diff source only*; **do not catalogue it** (0 net-new forms). Pin the newest **DataCareNext Jun2026** (24.06 MB) as the single source of truth; run one `diff` pass to tag the 5 newest-only forms + regulatory forms as the live target set. macOS.

**Phase 1 — Mine layout-in-code + per-form logic (the biggest unblocked lever) (weeks).** Build an `InitializeComponent` parser to recover geometry/tabs/grids for the ~150 flagship forms (`TR_SALE` 141 `.Location`, `TR_PURC`, `TR_TAG_OPBL`, all masters). In the same pass, extract per-form **validations, weight/fine/labour calc, event + F-key (VK-int) handlers, background Timers, weighing-scale serial I/O, and inline SQL**. Feed directly into the master/txn form specs. Target: masters 18%→full-depth, txn 40%→high-depth. macOS (parser + grep/AST).

**Phase 2 — Emulate the DevExpress/DotNetBar interaction shell (weeks).** Using the ~20-control list (§2 row 8), stand up web equivalents: FlexGrid-style editable grids, tabbed layout dialogs, F1-LOV popups, Enter-field-chaining, ribbon/docking. This closes the "appearance/interaction ≈ 12%" axis. macOS.

**Phase 3 — Report geometry on a Windows CI runner (the blocked lever) (weeks, parallelizable).** Spin up a Windows CI job with the Crystal .NET SDK; run `RptToXml` over all 255 `.rpt` → XML. Rebuild reports pixel-exact **in priority order**: 97 CRITICAL first (bills/vouchers/labels/passbooks), then 9 HIGH image reports, then MEDIUM/LOW. Locate the 20 missing `.rpt` first (macOS) and feed them into the same job. This is the only phase needing Windows and can run in parallel with 1–2.

**Phase 4 — Data, images, integrations (weeks).** ETL `SqlData/Next23-25` + `NextMain.BAK` via SQL-Server-in-Docker → Postgres/web schema (real fixtures + migration). Expand `AllImage.rar` (17.56 MB) and read `NextImage.mdf` for tag/product images. Port remaining integrations: `MSG_MAST` WhatsApp/SMS send-log, Firebase sync (`FireSharp`), webcam capture (`DirectShowLib`), QR. macOS.

**Phase 5 — NextEmp companion + regulatory tail (days–weeks).** Decompile `NextEmp.exe` to disk and port the bulk marketing-list messenger if in scope. Finish newest-only regulatory forms (`UT_E_INVOICE` print, `TR_UPI_REC`, UAE returns, `RP_HUID`). macOS (+ Windows only for the `EInvoice.rpt` print layout).

---

## 5. WHY THINGS REMAIN (root causes)

1. **Proprietary Crystal binary format (the only hard blocker).** `.rpt` geometry lives in an undocumented OLE `Contents` stream readable only by the Windows-only Crystal .NET SDK — so 255 report layouts stayed at name-level despite full macOS decompilation of everything else.
2. **A second binary that looked like new scope but wasn't.** NextDm's 199 `.cs` / 23 MB *appeared* to be an un-catalogued feature surface; it is an older build of the same product (0 unique forms), so effort spent cataloguing it would have been ~96% redundant.
3. **Layout-in-code, not resx.** The Windows-Forms designer serialized only 15 forms into rich `.resx`; the flagship transaction/master forms emit their entire layout as `InitializeComponent()` C# (`.Location`/`.Size` calls). resx mining therefore "completed" while ~150 real layouts remained un-mined because no code-layout parser existed.
4. **Depth ≠ breadth measurement gap.** The web reached ~80% screen breadth and ~85% data-posting parity, so parity scorecards read "done"; but per-form **field/grid/validation depth (~27%)**, **report/document fidelity (~10%)** and **appearance (~12%)** were never the axis those scorecards measured — leaving large *understood-but-not-replicated* mass.
5. **Hardware / integration / data dependencies.** Weighing-scale serial I/O, webcam capture, Selenium-driven WhatsApp, Firebase sync, and Code-39/Gujarati fonts are device- or service-bound; and the real `SqlData` databases + `AllImage`/`NextImage` stores are bulky binary blobs — all deprioritised behind core screens.
6. **Sheer breadth.** 204 forms × thousands of LOC each (12 sampled ≈ 146,800 LOC), 255 reports, 652 resx, 173+ images: the raw surface is large enough that "extracted" outran "mined/replicated."

---

### Appendix — verification log (this session, cited)

- `ls unified/reports/*.rpt` → **255**; deployed `DataCareNextS/Report/*.rpt` → **247**.
- `rpt_specs.json` = 855,944 B → **255 reports, 53,520 field refs, 1,499 table refs** (name-level only; no geometry).
- `catalogs/report-reconciliation.json` → `stillMissing` = **20** (names listed in file).
- `.resx` total **652** = `extracted_code/DataCareNext` 165 + `extracted_code/NextDm` 161 + `unified/resources/DataCareNext` 165 + `unified/resources/NextDm` 161. Largest: `MDI_FORM.resx` 1,154,834 B, `MS_OPNCOMP` 565,886 B, `MS_LOGIN` 411,250 B, `MS_ACCT` 367,706 B.
- `catalogs/layouts/*.layout.json` → **15** mined (MS_ACCT=152 controls, MS_MEMB=100, MS_ADD_MAST=88, MS_ITEM=72 …).
- Canonical source roots: `extracted_code/DataCareNext/DataCareNext/*.cs` = **204**; `extracted_code/NextDm/DataCareNext/*.cs` = **199**. `*_forms.json` = 163 / 161 form entries. Both binaries decompiled into **4 trees** (`extracted_code/{DataCareNext,NextDm}` + `unified/src/{csharp,csharp_nextdm}`).
- `TR_SALE.cs` = **21,586 LOC** (DataCareNext) / **21,339** (NextDm drift); **141 `.Location`** calls (layout-in-code proof).
- `NextEmp.exe` = 320,000 B + `.pdb`+`.xml`; **no decompiled `.cs` anywhere** on disk.
- `AllImage/` = **173** loose files in 8 subdirs; `AllImage.rar` = 17,562,685 B; `NextImage.mdf/.ldf/.rar` present; `SqlData/` = `Next23.BAK`,`Next24/25 .mdf+.ldf`,`NextMain.BAK`,`NextImage`.
- `DataCareNext.exe.licenses` (3,985 B) → ~**20 distinct DevExpress controls** (XtraGrid, XtraBars Ribbon/Docking, XtraEditors, XtraLayout, XtraNavBar, XtraTreeList, XtraPivotGrid, XtraReports, XtraRichEdit, XtraSpreadsheet, XtraPdfViewer, XtraVerticalGrid, XtraWizard, Dashboard, Snap, XtraCharts).
- Fonts: `FRE3OF9X.TTF` 7,220 B (Code-39), `KAP139.TTF` 52,164 B (Gujarati). Integration DLLs present in `DataCareSetup_extracted/DataCareNextS/`: `DevNet.WhatsApp.V2.dll` 5.48 MB, `WebDriver.dll` 9.2 MB, `FireSharp.dll`, `DirectShowLib.dll`, `QRCoder.dll`, `RestSharp.dll`, `HtmlAgilityPack.dll`, `CrystalDecisions.*.dll`.
- Web state (freshest audit `parity/DESKTOP-VS-WEB-DEPTH-AUDIT.md`): 83 `page.tsx`, 227 API routes; report web-status 57 BUILT / 40 PARTIAL / 83 PRINT-designated (~6 real) / 14 LABEL / 61 SPEC; composite experience parity ~22–28%, posting parity ~85%.
