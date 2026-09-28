# DataCareNext — Unified Resource Center

> Complete extracted source code, binaries, databases, reports, and artifacts for reproducing the DataCareNext jewelry/accounting ERP application.

**Generated**: 2026-06-23  
**Total Files**: 1,874 | **Total Size**: ~815 MB

---

## Quick Start

To reproduce this application on a Windows machine:
1. Open `src/csharp/DataCareNext.sln` in Visual Studio 2019/2022
2. Copy DLLs from `libs/` to `src/csharp/libs/original/` (or update HintPaths in `.csproj`)
3. Restore SQL Server databases from `database/backups/` 
4. Copy `reports/` folder alongside the built EXE
5. Update `config/SqlName.txt` with your SQL Server instance name
6. Build and run

See `docs/WINDOWS_BUILD_GUIDE.md` for detailed instructions.

---

## Directory Index

### `src/` — Source Code

| Path | Language | Files | Description |
|---|---|---|---|
| `src/csharp/` | C# (decompiled) | **211** | Complete decompiled source from latest EXE (Jun 2026). Primary codebase. |
| `src/csharp/DataCareNext/` | C# | 204 | All form classes, business logic modules, data models |
| `src/csharp/DataCareNext.My/` | C# | 5 | MyProject.cs (form registry), MyApplication, MySettings, MyComputer |
| `src/csharp/DataCareNext.My.Resources/` | C# | 1 | Application resources class |
| `src/csharp/Properties/` | C# | 1 | AssemblyInfo.cs |
| `src/csharp_nextdm/` | C# (decompiled) | **205** | NextDm variant — slightly older, similar codebase |
| `src/vbnet/` | VB.NET (original) | **65** | Original VB.NET source — 59 forms (44 real + 15 stubs), 3 modules, schema |

### Key Source Files

| File | Size | Purpose |
|---|---|---|
| `src/csharp/DataCareNext/TR_SALE.cs` | 889 KB | Main sales transaction (largest form, 559 controls) |
| `src/csharp/DataCareNext/Ac_Ledr.cs` | 1.4 MB | Ledger calculation engine |
| `src/csharp/DataCareNext/MS_UPDATE.cs` | 1.1 MB | Database schema update/migration |
| `src/csharp/DataCareNext/UT_IMPORT.cs` | 1.1 MB | Data import (667 SQL queries) |
| `src/csharp/DataCareNext/UT_EXPORT.cs` | 984 KB | Data export |
| `src/csharp/DataCareNext/MDI_FORM.cs` | 654 KB | Main MDI parent window (144 methods) |
| `src/vbnet/Database/01_Schema.sql` | 304 KB | Complete SQL Server DDL schema |

---

### `libs/` — Third-Party DLLs (REAL, not stubs)

| Subfolder | DLLs | Total Size | Description |
|---|---|---|---|
| `devexpress/` | 55 | ~180 MB | DevExpress v19.1 suite (Grid, Charts, Editors, Bars, etc.) |
| `crystal/` | 6 | ~2 MB | SAP Crystal Reports .NET runtime |
| `dotnetbar/` | 5 | ~6 MB | DevComponents DotNetBar2 UI controls |
| `interop/` | 12 | ~500 KB | MSFlexGrid, Crystal COM interop, stdole |
| `webdriver/` | 3 | ~9 MB | Selenium WebDriver (for WhatsApp automation) |
| `other/` | 12 | ~7 MB | Newtonsoft.Json, RestSharp, QRCoder, TagitIce, WhatsApp, etc. |

Also includes: XML documentation files, locale dirs (de/es/ja/ru), selenium-manager

> **Note**: These are the REAL production DLLs extracted from the deployment package. They replace the 44KB compilation stubs.

---

### `stubs/` — Compilation Stubs

6 C# stub files that provide minimal type definitions for building without the real DLLs:
- `DevExpressStubs.cs` — 95 types
- `CrystalStubs.cs` — 21 types  
- `ExcelInteropStubs.cs` — 21 types
- `QiosStubs.cs` — 12 types
- `CustomLibStubs.cs` — 11 types (WhatsApp, TagitIce)
- `AxFlexGridStubs.cs` — 2 types

---

### `reports/` — Crystal Report Templates

**255 `.rpt` files** covering every report in the application:

| Category | Count | Examples |
|---|---|---|
| Sales/Invoices | ~40 | SalesBillA4Gst.rpt, SalesBillHz.rpt, ItemSalesVch.rpt |
| Purchase | ~15 | PurcBillA4Gst.rpt, PurcReport.rpt, PurcGroupWise.rpt |
| Stock/Tags | ~25 | TagStkRpt.rpt, ItmStkBalance.rpt, TagSplitVch.rpt |
| Accounting | ~30 | AcLedger.rpt, TRialBalHz.rpt, RojMelCash.rpt, BalanceHz.rpt |
| GST/Tax | ~10 | Gstr_1.rpt, Gstr_2.rpt, Gstr_3.rpt, SlTaxRpt.rpt |
| Dhrn (Loan) | ~12 | DhrnIssue.rpt, DhrnKhataVahi.rpt, DhrnOsLetter.rpt |
| Manufacturing | ~8 | MfgVch.rpt, MfgGhatIsu.rpt, MfgLedger.rpt |
| Orders | ~12 | OrderBill.rpt, OrderVch.rpt, OrdVchImg.rpt |
| Members | ~10 | MembVch.rpt, MembPassBook.rpt, MembQr.rpt |
| Wholesale | ~8 | WhSalesBill.rpt, WhSalesRtnBill.rpt |
| E-Invoice | ~3 | EInvoice.rpt, EInvOthIncom.rpt |
| Cheque/Bank | ~8 | ChqPrint010-135.rpt, CashBankBill.rpt |
| Other | ~74 | Various vouchers, summaries, B2B reports |

---

### `resources/` — Embedded Resources (.resx)

| Subfolder | Files | Description |
|---|---|---|
| `DataCareNext/` | 165 | .resx from latest EXE (Jun 2026) — background images, icons |
| `NextDm/` | 161 | .resx from NextDm EXE — nearly identical but slightly different variant |

---

### `database/` — SQL Server Artifacts

#### Schema
- `schema/01_Schema.sql` — **304 KB** complete DDL (all tables, constraints, defaults)

#### Backups
| File | Size | Description |
|---|---|---|
| `Next23.BAK` | 8.3 MB | Year 2023 data backup |
| `Next24.BAK` | 7.8 MB | Year 2024 data backup |
| `Next24.mdf/.ldf` | 38+17 MB | Year 2024 live database |
| `Next25.mdf/.ldf` | 23+10 MB | Year 2025 live database |
| `NextImage.mdf/.ldf` | 9.4+3.5 MB | Image storage database |
| `NextMain.BAK` | 3.1 MB | Main/master data backup |

#### CSV (GST exports)
- `B2B.csv`, `B2CL.csv`, `B2CS.csv`, `HSNSUM.csv`

---

### `config/` — Configuration Files

| File | Purpose |
|---|---|
| `DataCareNext.exe.config` | .NET app config (connection strings, DevExpress skin, framework version) |
| `App.config` / `App_original.config` | VB.NET project App.config (newer / original) |
| `SqlName_setup.txt` | SQL Server connection (from setup deployment) |
| `SqlName_extracted.txt` | SQL Server connection (from decompiled source) |
| `SqlName_B.txt` | Backup SQL connection |
| `GenIRN.txt` | E-Invoice IRN generation config |
| `IRNData.txt` | IRN response data (22 KB) |
| `AuthToken.txt` | Authentication token |
| `Json.Json.txt` | JSON config |

---

### `binaries/` — Compiled Executables (All Versions)

| File | Size | Date | Notes |
|---|---|---|---|
| `DataCareNext_Jun2026.exe` | 24 MB | Jun 11, 2026 | **Latest build** (source decompiled from this) |
| `DataCareNext_Jan2026.exe` | 22.6 MB | Jan 13, 2026 | Setup package version |
| `DataCareNext_oldest.exe` | 15.4 MB | Older | Earliest .NET version found |
| `NextDm_Mar2026.exe` | 23.4 MB | Mar 20, 2026 | Demo/secondary variant |
| `NextDm_Jul2025.exe` | 21.3 MB | Jul 2025 | Setup version of NextDm |
| `NextEmp.exe` | 320 KB | — | Employee management module |

#### Debug Symbols (`debug/`)
- `DataCareNext.pdb` (7.9 MB) — full debug symbols for Jan 2026 build
- `DataCareNext.xml` — XML documentation
- `NextEmp.pdb` / `.xml`
- `Auto WhatsApp Launcher.pdb`

---

### `images/` — Image Assets

| Path | Files | Description |
|---|---|---|
| `AllImage/AllImage/` | 150 | Product/jewelry images |
| `AllImage/DataCareWeb/` | 148 | Web-related images |
| `AllImage/SmallImage/` | 12 | Thumbnail images |
| `AllImage/TagImage/` | 11 | Tag barcode/label images |
| `AllImage/DhranImage/` | 2 | Loan-related images |
| `app.ico` | — | Application icon |
| `QR.jpg`, `Wapp.ico` | — | QR code sample, WhatsApp icon |

---

### `fonts/` — Custom Fonts

- `FRE3OF9X.TTF` — Code 39 barcode font (for tag/label printing)
- `KAP139.TTF` — Gujarati/custom font

---

### `extraction_metadata/` — Analysis Artifacts

| Subfolder | Files | Description |
|---|---|---|
| `pe_info/` | 4 | PE header analysis, .NET metadata |
| `string_dumps/` | 6 | All extracted strings, resources, IL dumps |
| `categorized/` | 6 | Categorized forms, SQL queries, architecture |
| `audit/` | 7 | Build error baselines, type coverage, parity checks |
| Root files | 3 | RPT field analysis, database tables, event log |

---

### `docs/` — Documentation

- `WINDOWS_BUILD_GUIDE.md` — Detailed build instructions for Windows
- `report.md` — Exhaustive extraction verification report
- `report-template-parity.md` — Report template comparison
- Various parity and acceptance test docs

---

### `tools/` — Build & Audit Scripts

| File | Purpose |
|---|---|
| `extract_dotnet.py` | .NET binary extraction tool |
| `extract_metadata.py` | Metadata extraction tool |
| `audit_type_coverage.py` | Type coverage audit |
| `audit_next1106_parity.py` | Parity verification |
| `fix_timer_ambiguities.py` | Build error fixer |
| `fix_field_accessed_auto_properties.py` | Property accessor fixer |
| `parse_build_errors.py` | Build error parser |
| `compare_pe_identity.py` | PE binary comparison |
| `compare_manifest_resources.py` | Resource comparison |
| `verify_original_libs.ps1` | DLL verification (PowerShell) |

---

### `templates/` — Data Templates

- `TagEntry.xlsx` — Tag data entry template
- `output.xlsx` — Export output sample

---

### `setup_installer/` — Original VB6 Setup Files

- `SETUP.LST` — VB6-era setup manifest (references JSoft.exe, DAO 3.5)
- `setup.exe` — Bootstrap installer
- `JSoft.CAB` — Original VB6 application cabinet
- `setup.rar` — Additional setup resources
- `Support/` — Support files

---

## Architecture Summary

```
DataCareNext = Jewelry/Gold ERP Application
├── Language: VB.NET → Compiled .NET Framework 4.7.2 → Decompiled to C#
├── UI: Windows Forms + DevExpress v19.1 + DevComponents DotNetBar2
├── DB: SQL Server Express (yearly databases: Next23, Next24, Next25)
├── Reports: SAP Crystal Reports (255 .rpt templates)
├── Integrations: WhatsApp (Selenium), E-Invoice/GST, QR codes, SMS
├── Forms: 161 WinForms (Master data, Transactions, Reports, Utilities)
├── Business Logic: 13,995 SQL queries, 8,308 methods, 5,413 event handlers
└── Total Source: 931,865 lines of C# code
```

## Version History

| Version | Size | Date | Source |
|---|---|---|---|
| DataCare (VB6) | 10.2 MB | ~2010 | JSoft.exe, DAO/Jet 3.5 |
| DataCareNext (early .NET) | 15.4 MB | ? | First .NET migration |
| DataCareNext (setup) | 22.6 MB | Jan 2026 | Setup RAR deployment |
| NextDm (setup) | 21.3 MB | Jul 2025 | Demo variant in setup |
| NextDm (updated) | 23.4 MB | Mar 2026 | Updated demo |
| **DataCareNext (latest)** | **24.0 MB** | **Jun 2026** | **Primary source for decompilation** |
