# Windows Guide — Extracting Crystal Report (.rpt) Layouts

**Why this is needed:** The 255 `.rpt` report files hold their exact visual layout (where every field/label sits, fonts, lines, sub-reports) inside a **proprietary Crystal binary format**. On the Mac we already extracted every report's **tables + field names** (`extraction_output/rpt_specs.json`), which is enough to build the correct data. But the **pixel-exact layout** can only be read by SAP's Crystal tool, which **runs only on Windows**. This guide gets that layout out as clean XML.

> You do this **once**. It produces one `.xml` per report. Those XMLs are then used on the Mac to rebuild each report pixel-for-pixel.

---

## Can this be done on the Mac? — No (and why)
- The only reader is `RptToXml.exe`, which loads `CrystalDecisions.CrystalReports.Engine` (SAP's Crystal .NET SDK).
- That SDK is **Windows-only** — even the ".NET Core" fork still needs the Windows Crystal runtime. It cannot load on macOS `dotnet`.
- So: **field/table names = already done on Mac; visual geometry = Windows only.** Nothing else in the whole project needs Windows.

---

## OPTION A — Easiest: GitHub Actions (no Windows PC needed) ⭐ recommended
GitHub runs a free Windows machine in the cloud for you.

1. Put the repo (with `unified/reports/*.rpt`) on GitHub (a private repo is fine).
2. Add the file **`.github/workflows/rpt-extract.yml`** with this content:

```yaml
name: Extract RPT layouts
on: { workflow_dispatch: {} }   # run manually from the Actions tab
jobs:
  rpt:
    runs-on: windows-latest
    steps:
      - uses: actions/checkout@v4
      - name: Install Crystal Reports runtime
        run: choco install crystal-reports-2020-runtime-64bit -y --no-progress
        # if that package name fails, use the SAP MSI (see Option B step 2)
      - name: Get RptToXml
        run: |
          git clone https://github.com/ajryan/RptToXml tool
          # build it, or download RptToXml.exe from the repo's Releases page into .\tool\
          dotnet build tool\RptToXml.sln -c Release
      - name: Convert all .rpt to .xml
        shell: pwsh
        run: |
          $exe = Get-ChildItem -Recurse tool -Filter RptToXml.exe | Select -First 1
          New-Item -ItemType Directory -Force extraction_output\rpt_xml | Out-Null
          Get-ChildItem unified\reports\*.rpt | ForEach-Object {
            & $exe.FullName $_.FullName ("extraction_output\rpt_xml\" + $_.BaseName + ".xml")
          }
      - uses: actions/upload-artifact@v4
        with: { name: rpt-xml, path: extraction_output/rpt_xml }
```

3. On GitHub → **Actions** tab → run **“Extract RPT layouts”**.
4. When it finishes, download the **`rpt-xml`** artifact (a zip of 255 XML files).
5. Unzip it into `extraction_output/rpt_xml/` on the Mac. **Done.**

---

## OPTION B — Manual: your own Windows PC
1. On any Windows 10/11 PC, install **.NET Framework 4.x** (usually already present).
2. Install the **SAP Crystal Reports runtime** (free): download from
   `https://www.sap.com/cmp/td/sap-crystal-reports-visual-studio-trial.html`
   → install **both** the **32-bit** and **64-bit** “runtime engine for .NET framework” MSI files.
3. Get **RptToXml.exe**:
   - Easiest: download the prebuilt `RptToXml.exe` from `https://github.com/ajryan/RptToXml/releases`, **or**
   - Build it: open `RptToXml.sln` in Visual Studio (Community is free) → Build → find `RptToXml.exe` in `bin\Release`.
4. Copy the report folder `unified\reports\` (the 255 `.rpt`) onto the Windows PC, e.g. `C:\rpt\`.
5. Open **PowerShell** in that folder and run:
   ```powershell
   mkdir out
   Get-ChildItem C:\rpt\*.rpt | ForEach-Object { .\RptToXml.exe $_.FullName ("out\" + $_.BaseName + ".xml") }
   ```
6. Copy the `out\` folder back to the Mac as `extraction_output/rpt_xml/`. **Done.**

---

## What you get + what happens next (on the Mac)
Each `<Report>.xml` contains, per report:
- `<Section>` / `<Area>` — the bands (Page Header, Details, Footer…)
- `<FieldObject Left=".." Top=".." Width=".." Height="..">` — **exact position of every field**
- `<TextObject>` — labels + their fonts/colours
- `<FormulaFieldDefinition>` — the formula text (e.g. how a total is computed)
- `<Group>` / `<SortField>` / `<Subreport>` — grouping + nested reports

Then on the Mac (no Windows needed for this part):
1. A parser reads each XML → `reports/<NAME>.spec.json` (bands + field coordinates + formulas).
2. The web report engine renders from that spec → **pixel-exact** bills/vouchers/labels/passbooks.

**Priority order for the 255:** do the ~97 customer-facing documents first (bills, vouchers, tag labels, passbooks, cheques), then the ~50 statutory/columnar, then the ~99 analytic registers last.

---

## One-line summary
> Mac already has every report’s **data** (tables + fields). Only the **visual layout** is Windows-locked. Run **Option A (GitHub Actions)** once → get 255 XML files → the Mac turns them into pixel-exact web reports. No Windows PC purchase required.
