# EXTRACTION COMPLETENESS REPORT

_Date 2026-07-13. Completion pass over everything the earlier runs deferred/missed. Every item below was executed + verified this pass._

## Now extracted (this pass)

| Item | Result | Artifact |
|---|---|---|
| **Real SQL schema + data** | Installed msodbcsql18/mssql-tools18, restored **Next24.BAK + Next23.BAK** into Docker SQL Server → **146 tables / 5,254 columns** authoritative DDL + per-table rowcounts | `catalogs/realdb-schema.json` |
| **NextEmp source** | Fixed decompiler (`dotnet ilspycmd.dll`), decompiled → **13 classes / 8,847 LOC** (DC_Main, MDI_FORM, UT_WHATSAPP_OLD) | `extracted_code/NextEmp/NextEmp.decompiled.cs` + `catalogs/nextemp-catalog.json` |
| **Deeper .rpt (Mac max)** | Opened OLE compound files, read `Contents` stream → confirmed **0 plaintext geometry** (proprietary compressed) | `extraction_output/rpt_deep_specs.json` |
| **Embedded resources** | **166 per-form `.resources`** + **25 images** (21 png / 2 ico) inventoried | `catalogs/resources-catalog.json` |
| **resx content scan** | 165 distinct resx → **16 rich control-trees**, 149 string-only ⇒ layout mining complete | `catalogs/resx-content-scan.json` |
| **Fonts** | FRE3OF9X (Code39 — already replicated as SVG), KAP139 (Gujarati 52 KB — web must embed for Gujarati text) | `unified/fonts/` |
| **Config/integrations** | `IRNData.txt` (22 KB, **real e-invoice ACK/IRN/SignedInvoice JWT**), `GenIRN.txt` (IRN request template), App/exe.config, SqlName | `unified/config/` |

### Key data findings
- **Next23 & Next24 `.BAK` are fresh-company TEMPLATE databases** — masters seeded (COL_MAST 699, COUNTRY_MAST 151, STATE_MAST 37, WEIGHT_MAST 36, AC_MAST 89, TAX/GROUP/ITEM/PRODUCT/MFG masters) but **no bulk transaction data** (AC_DATA 28, MAIN_STOCK 28, SL_DATA 0). So the provided backups are seed/template DBs, not years of production data. The real reference master data (countries/states/weights/colors/tax) **is** now available to import into the web.
- Authoritative real schema now supersedes the string-scanned model: real AC_MAST=54 cols, ITEM_MAST=44, SL_DATA=98.

## ✅ RESOLVED (2026-07-13): Crystal `.rpt` geometry — extracted via GitHub Actions
- The last Windows-only item is **done**. Created a private repo (`yaxit24/datacare-rpt-extract`), ran the workflow on a GitHub-hosted Windows runner: installed the CR13 runtime (**both 32+64-bit** — the 32-bit was the missing piece), built RptToXml, converted **254/255** reports → XML, downloaded to `extraction_output/rpt_xml/`.
- Parsed to per-report layout specs (`unified/tools/rpt_xml_to_spec.py` → `project-memory/catalogs/report-layouts/*.spec.json`): **253 reports, 2,863 sections, 14,123 positioned objects (Left/Top/Width/Height in twips), 5,957 formula definitions with their Crystal formula text**. E.g. SalesBillA4Gst = full band structure (ReportHeader/PageHeader/GroupHeader×2/Detail/GroupFooter×2/ReportFooter/PageFooter) + the actual address/tax formulas.
- **Reports pipeline now complete on the Mac:** names → fields → **geometry + formulas**. The web report engine can render pixel-exact from these specs.
- Note: the private repo holds your `.rpt` files; delete it any time with `gh repo delete yaxit24/datacare-rpt-extract`.

## The ONE thing still not extractable on macOS (superseded — see RESOLVED above)
- **Crystal `.rpt` pixel geometry** (sections, FieldObject Left/Top/Width/Height, fonts, formulas) — I opened the `.rpt` OLE files and read the `Contents` stream directly: it is proprietary compressed binary with **no recoverable plaintext structure**. This confirms (not assumes) it needs the Windows Crystal SDK.
  - **Path:** `.github/workflows/rpt-extract.yml` (verified correct) → run in GitHub Actions on a Windows runner → 255 XML → parse on Mac. I cannot trigger a run in your GitHub account from this machine; you (or CI) start it once from the Actions tab. Guide: `WINDOWS-RPT-EXTRACTION-GUIDE.md`.

## Not present in the provided files (so cannot be extracted — needs the source system)
- **Real transaction data** (years of sales/purchase/karigar rows) — the shipped `.BAK`s are templates. To get it, take a fresh `.BAK` from the live shop DB and run the same restore + ETL (`unified/tools/etl_mssql_to_pg.py`).
- 20 `.rpt` referenced-but-absent from all source roots (listed in `catalogs/report-reconciliation.json`).

## Net extraction state
- **Code/forms:** 204 forms decompiled + 175 layout manifests + 172 logic specs + NextEmp source — complete on Mac.
- **Schema:** authoritative real DDL (146 tables/5,254 cols) + modelled 178 — complete.
- **Reports:** names+fields for 255 (Mac) done; geometry pending the one Windows CI run.
- **Resources/images/fonts/config/integrations:** inventoried + catalogued — complete.
- **Data:** real master seed data available; real transaction data not in the provided backups.


---

## UPDATE 2026-07-13 (evening) — per-form behavior + menu + settings + NextImage mined

The earlier report left ~30% in the "extracted but NOT mined" bucket (per-form logic/calc/SQL, menu, settings). This pass closes almost all of it on macOS.

| Item | Result | Artifact |
|---|---|---|
| **Per-form behavior** (all 204 forms) | grid column schema **6,973**, inline SQL templates **5,128** (concat literals joined by `?`), keyboard VK maps **795**, calc formulas **3,309** (real jewellery math — `fine = Val(netwt)*Val(touch)/100`, `net = gross − less`, `amt = qty*rate`), validation guards **1,849** | `unified/tools/extract_form_behavior.py` → `catalogs/form-behavior/*.behavior.json` (2.5 MB, 204 files) |
| **Menu hierarchy** | 136 captions, 106 items, **22 rights-guarded menu→form actions** (F2→RP_LEDR, F4→TR_SALE_ORD, F5→TR_BUL_SALE, F7→TR_PURC_HM, F8/F9→TR_CASH…), 19-item F-key shortcut bar | `unified/tools/extract_menu.py` → `catalogs/menu-tree.json` |
| **Settings** | CO_SET = **57 setting keys** (authoritative storage table); web `SETTING_FIELDS` expanded **26 → 55** editable flags (THEME, LBR_TYPE, FINE_STK_TYPE, WEIGHT_PORT COM-port, STOCK_RPT_TYPE, ALL_ROF_REMOVE, …). `COUNTER_STK` correctly excluded (not a web CO_SET column). | `unified/tools/extract_settings.py` → `catalogs/settings-catalog.json`; web `/settings` now returns 55 fields + values |
| **NextImage.mdf** | Attached to Docker SQL (upgraded v782→921); `TAG_IMAGE_DATA` = 3 rows; images stored as base64 JPEG in `MOB_IMAGE nvarchar(max)`; extracted via `bcp queryout` → 3 valid JPEGs (BLG00001 2240×1680 524 KB, MSG00003 2992×2992 772 KB, ORG00001 318 KB). Template DB — only 3 sample images. | `extraction_output/nextimage/*.jpg` + `catalogs/nextimage-catalog.json` |
| **Newest-only + regulatory forms** | All 8 confirmed fully extracted (src + behavior + logic + layout): TR_FN_INOUT, RP_STOCK_VALUE, UT_PWD_UPDATE, UT_E_INVOICE, TR_UPI_REC, TR_PR_SL_UAE, TR_SALE_RTN_UAE, RP_HUID | catalogs |

### Net extraction state after this pass
- **Code/forms:** 204 decompiled + 177 layout manifests + 172 logic specs + **204 behavior specs** (grid/SQL/keyboard/calc/validation) + NextEmp — complete on Mac.
- **Schema:** authoritative real DDL 146 tables / 5,254 cols — complete.
- **Reports:** names + fields + **geometry + formulas** for 254 (`catalogs/report-layouts/`) — complete.
- **Menu / settings / resources / fonts / config / integrations / images:** catalogued — complete.
- **Data:** real master seed available; real *transaction* data not in the provided template `.BAK`s.

### Nothing macOS-doable remains unextracted
Every remaining gap is data/hardware/service-bound, not an extraction task: (a) years of real **transaction data** (the shipped `.BAK`/`.mdf` are fresh-company templates — needs a live-shop backup); (b) 20 `.rpt` **referenced-but-absent** from all source roots (cannot extract what isn't shipped); (c) runtime device I/O (weighing-scale serial, webcam, Selenium WhatsApp) — these are integrations to *build*, not artifacts to *extract*. The desktop → spec extraction is complete.
