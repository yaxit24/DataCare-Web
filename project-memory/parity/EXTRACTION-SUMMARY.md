# EXTRACTION SUMMARY — macOS-doable extractions completed + Windows CI staged

_Date 2026-07-02. This run executed the full extraction mandate: (1) staged the one Windows-only step as CI, and (2) completed every macOS-doable extraction end-to-end. All artifacts below were produced this session and verified by counts._

## 1. Windows-only step — STAGED (ready to run, no Mac path exists)
- **`.github/workflows/rpt-extract.yml`** — GitHub Actions (windows-latest) installs the SAP Crystal runtime, builds `RptToXml`, converts all **255 `.rpt` → XML**, uploads a `rpt-xml` artifact. Run it from the Actions tab; unzip into `extraction_output/rpt_xml/`. This is the **only** artifact class that cannot be extracted on macOS (Crystal geometry lives in a proprietary OLE stream readable only by the Windows Crystal SDK). Report **names + fields** are already scraped on the Mac (`rpt_specs.json`), so only pixel geometry is pending. Guide: `WINDOWS-RPT-EXTRACTION-GUIDE.md`.

## 2. Layout-in-code — MINED (the biggest unblocked lever)
- **`unified/tools/initcomp_to_formspec.py`** → `project-memory/catalogs/layouts/*.initcomp.json` (+ `initcomp-index.json`).
- Parsed `InitializeComponent()` in the ILSpy-decompiled C# (cast style: `((Control)X).Location = new Point(..)`) for **160 forms / 6,728 controls** (135 rich ≥15 controls).
- Flagship depth now machine-readable: **TR_SALE 141 controls / 8 grids / 55 inputs**, TR_WH_SALE 133/6, TR_PURC 114/7, TR_TOUR_SALE 115/6, TR_DHRN_REC 111, TR_TAG_OPBL 79/3, UT_SETTING_MAIN 182 controls/7 tabs, MS_COMPANY 129/7 tabs. Combined with the 15 `.resx` layouts → **175 form layouts** ready to drive the React form generator (full field/tab/grid geometry — the form-depth + appearance gap).

## 3. Per-form business logic — CATALOGUED
- **`unified/tools/per_form_logic.py`** → `project-memory/catalogs/form-logic/*.logic.json` (+ index).
- **172 forms**: SQL write-ops **368 INSERT / 386 UPDATE / 1,344 DELETE**, **377 event handlers**, **88 forms with F-key (F1..F12) lookups**, **9 timer forms**, and **2 weighing-scale (serial-port) forms** — `TR_TAG_OPBL` + `MS_DESIGN_BOOK` (browsers can't do serial → the web needs a small local scale-bridge helper).
- Per form: tables touched, INSERT columns (partial — much goes via DevExpress XPO ORM), validation message-box counts, and calc-formula samples (e.g. TR_SALE exposes the old-gold `CustClAmt/OldNetAmt` math). This is the behaviour to port screen-by-screen.

## 4. NextEmp companion — CATALOGUED (`nextemp-catalog.json`)
- `NextEmp.exe` = **bulk WhatsApp/SMS marketing companion** (VB.NET). Form `UT_WHATSAPP_OLD`: SingleMsg, **PartyOsSms** (outstanding reminders), **BirthdaySms**, DgvSms. Template table **`MSG_MAST`** (by `MSG_TYPE`), **Excel contact import** (OLEDB). No web equivalent today.

## 5. AllImage.rar — EXTRACTED, MAJOR FINDING (`allimage-catalog.json`)
- Not an image store — it holds the vendor's own **`DataCareWeb`** (ASP.NET WebForms + EntityFramework + SQL Server): **16 `.aspx` screens** (MS_ACCT, MS_LOGIN, MS_MDIFORM, PT_CASHREC, PT_WHSALE, TR_ORDER_ENTRY, TR_WHSALE, RP_TAGESTIMATE…) + **13 per-screen CSS** (brand `#ff6a00`) — a **design reference for the intended web look per screen** — plus 23 UI icons + image-store dirs (`TagImage`/`FtpImage` runtime-empty, `DhranImage` 2). Extracted to `extracted_code/AllImage/`.

## 6. Real production databases — SCHEMA-CONFIRMED (`realdb-schema-compare.json`)
- String-scanned `Next23.BAK` / `Next24.BAK` / `Next24.mdf`: **146 / 178 modelled tables present** in real data → the data model is validated. The ~20 absent = newer features (AC_IMAGE, DG_GOLD_*, FAN_*, APP_CHATMESSAGES, WEBHOOKINBOX, TAG_IMAGE_DATA, TILE_DATA, MENU_DATA, REMARK_DATA) or model-list noise.
- `Next24.BAK` is staged in the Docker `sql_server` at `/var/opt/mssql/backup/`. **ETL path (for real rowcounts + data migration):** `brew tap microsoft/mssql-release && HOMEBREW_ACCEPT_EULA=Y brew install msodbcsql18 mssql-tools18` → `RESTORE DATABASE` → `bcp`/`sqlpackage` per table → `unified/tools/etl_mssql_to_pg.py` (add `tenant_id` + RLS) → Postgres.

## 7. Version drift + integrations
- **Version-diff** (oldest 15.4MB vs Jun2026 24MB DataCareNext): genuinely-new forms over time = **MS_GOLD_MAST** (digital gold), **MS_LBR_TYPE**, **MS_MFG_MAST**, **MS_STYLE**, **RP_DAY_WORK** (+ regulatory UT_E_INVOICE/TR_UPI_REC/UAE forms). Target the newest build.
- **Integrations** (`integrations-scan.json`): WhatsApp via **Selenium/ChromeDriver browser automation + QR** (older) alongside Cloud API; **Firebase** realtime sync (FireSharp GetAsync/SetAsync/PushAsync); the web ported Cloud API only — Selenium fallback, Firebase sync, and `MSG_MAST` send-log are not yet in the web.

## Net new machine-readable artifacts this run
`catalogs/layouts/` (+160 initcomp manifests), `catalogs/form-logic/` (172 logic specs), `nextemp-catalog.json`, `allimage-catalog.json` (+ extracted DataCareWeb), `realdb-schema-compare.json`, `integrations-scan.json`, `.github/workflows/rpt-extract.yml`, tools `initcomp_to_formspec.py` + `per_form_logic.py`.

## Replication roadmap (using the new artifacts)
1. **Form depth + appearance (macOS, now):** feed the 175 layout manifests + 172 logic specs into a React form generator → rebuild flagship txn/master screens control-for-control (tabs, grids, F-keys), styled from the DataCareWeb CSS reference.
2. **Reports (Windows CI, parallel):** run `rpt-extract.yml` → 255 XML → per-report layout specs → pixel-exact web reports (top ~97 documents first).
3. **Data (macOS):** install msodbcsql18 → restore .BAK → ETL real Next24 data into Postgres for realistic fixtures + migration.
4. **Long tail:** MSG_MAST bulk-messaging (NextEmp), Firebase sync, weighing-scale bridge, digital-gold/franchise masters (newest-build features).
