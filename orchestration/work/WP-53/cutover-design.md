# WP-53 design: customer cutover from a desktop company, with reconciliation

Status: design, 2026-11-23. Worktree `orchwt/specs-batch` at `101fe4be`. Priority P0, size L, depends on Phases 1-3
(docs/parity/LITE-MASTER-PLAN.md:495). Pass criterion in the plan: "A desktop company imported into a tenant
reconciles exactly: trial balance, party balances (money, gold fine, silver fine), stock by item and tag count, open
orders and approvals" (docs/parity/LITE-MASTER-PLAN.md:552).

Citations: repo files as `path:line`, desktop source as `File.cs:N {{quoted}}` (files under
`unified/src/csharp/DataCareNext/`). Web paths are relative to `web/` unless they start at the repo root.

This design **builds on** the existing plan slices N78 (ownership manifest and fail-closed validator) and N79 (scoped
shadow loading, reconciliation, two rehearsals) in
docs/master-parity-plan-2026-09-29/11-audit-implementation-plan-2026-10-01.md:984-1040. It does not replace them. It
narrows them to the Lite edition, fixes the decisions they leave open, and gives the exact reconciliation figures.

---

## 0. What exists today, and why it cannot be used as it is

| Piece | Where | State |
|---|---|---|
| Loader `cutover.mjs` | apps/api/integration/cutover.mjs (576 lines) | Dry run works. **Load is blocked** by the containment rule `production-cutover-load` (packages/core/containment.mjs:96-102), which names its exit gate: "signed ownership manifest, completeness-failing validation, two-company/two-year isolation, and two clean shadow loads". |
| Runbook for the loader | project-memory/parity/CUTOVER-RUNBOOK.md | Describes the loader only. "No real multi-year source database has been migrated with this tool" (:7). |
| Older runbook | docs/runbooks/migration.md | Points at `unified/tools/etl_mssql_to_pg.py` (95 lines, pure coercion core) and says imported users log in with their **plaintext** desktop password (:37). This design reverses that (§3.6). |
| Desktop schema baseline | project-memory/parity/DESKTOP-REAL-SCHEMA.json, project-memory/catalogs/realdb-schema-full.json | 145 tables of a real `Next24.mdf` (structure only, backup date 2025-04-21). **NextMain is not captured** (no `USER_SET`, `MENU_DATA`, `TILE_DATA`, `AC_MAST_SRNO` in it). |
| Desktop data on this machine | unified/database/backups/*.BAK, *.mdf | Git LFS pointers of 132-133 bytes, no data. Port 1433 closed. No aggregate query was possible; every count below is from source code, not from data. |
| Web schema | packages/db/prisma/schema.prisma (175 models) | Desktop-shaped (decision D15), superset of the 145 tables (project-memory/parity/DB-PARITY-REPORT.md §B). |
| Run-record model to copy | `DataRepairRun` (packages/db/prisma/schema.prisma:7201-7223) | Preview hash, counts, operator, backup reference: the right shape for a `cutover_run` table. |

Defects of `cutover.mjs` that this design removes (most are already listed by G63 in document 11 §, line 109):

1. Unscoped extraction: `SELECT cols FROM [db].dbo.[table]` with no company/location/year filter (cutover.mjs:415-419).
   A desktop year database holds **every company** of that year, so a two-company install would load both into one
   tenant.
2. Tenant-wide replacement: `DELETE FROM table WHERE tenant_id=$1` (cutover.mjs:450).
3. Floating comparison: sums in JavaScript doubles with a relative tolerance of 1e-9 (cutover.mjs:191-210). That is
   not "exact to the paisa".
4. CO_YEAR remap of every row (cutover.mjs:217-223). Wrong for the desktop, whose next-year database deliberately keeps
   rows with the **old** CO_YEAR (carried Sales Orders and Approvals, §2.4).
5. Default table list names `TAG_STOCK` (cutover.mjs:35), a web-only table that does not exist in the desktop schema,
   and leaves out `OP_DATA`, `ITM_OPBL`, `BOOK_DETL`, `CO_SET`, `SRNO_MAST`, `LOGIN_MAST`, `APR_*` and more.
6. Runs as the runtime role through `withTenant` (cutover.mjs:441, :449), one `INSERT` per row (:454-460): correct for
   RLS but slow, and it cannot verify the untouched-tenant sentinel (it can't see other tenants).
7. Status `dry-run` counts as passing; a missing table is reported but does not fail (cutover.mjs:259-269, :336).

Decision: **write a new pipeline** (`web/tools/cutover/`, §7) and keep `cutover.mjs` only as the
`--dry-run` diagnostic until slice S4 replaces it. The containment rule stays in place until slice S10.

---

## 1. Source formats and how to obtain them from a shop

### 1.1 What the desktop keeps

- One **main** database plus one database **per financial year**. The connection file is `SqlName.txt` next to the
  executable: DC_Main.cs:968-972 {{SqlServer = streamReader.ReadLine();}} / {{SqlData = streamReader.ReadLine();}} /
  {{SqlMain = streamReader.ReadLine();}}.
- The year database is named from the year code: MS_OPNCOMP.cs:598 {{DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2);}}.
  Variants: `NxAc`/`NxAb` + YY for company types P/B (MS_YEAR.cs:1374-1381) and `Next` + YY + month for the alternate
  (non-April) year (MS_OPNCOMP.cs:584 {{DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2) + tMonth.Text;}}),
  chosen by `YEAR_MAST.OLD_METHOD` / `YEAR_MONTH` (MS_OPNCOMP.cs:566-567).
- The main database (`NextMain`) is where the desktop writes `MENU_DATA`, `USER_SET`, `LOGIN_MAST`, `YEAR_MAST`,
  `LOCT_MAST`, `CO_MAST`, `AC_MAST_SRNO`, `TILE_DATA` (every `OpenRecordSetMc`/`ExeQuteMc` write in the source goes to
  these eight tables). The year database also has copies of `CO_MAST`, `LOCT_MAST`, `LOGIN_MAST`, `YEAR_MAST`
  (they are in the Next24 baseline); **NextMain is authoritative** for them, and the dry run reports any difference.
- `NextImage` holds pictures (DC_Main.cs:1418-1427 opens it separately).
- Inside a year database every business row carries `CO_CODE` (varchar 2), `LC_CODE` (varchar 2; `OP_DATA` has 3) and
  `CO_YEAR` (varchar 9 or 10, value like `2024-2025`). No foreign keys, views, triggers or procedures
  (DB-PARITY-REPORT.md §A): every rule is in the C# code.

### 1.2 Formats we accept, in order of preference

| # | Format | How the shop produces it | Use |
|---|---|---|---|
| A | **Desktop "Data Backup" `.BAK` files** | The operator's own menu. It runs `BACKUP DATABASE <year db> TO DISK = '<path>\NextYY_ddMMyy_HH.BAK'` and `BACKUP DATABASE NextMain TO DISK = '<path>\NextMain.BAK'` (UT_BKP.cs:1234-1248 {{DC_Main.RsQry = "BACKUP DATABASE " + DC_Main.SqlData + " TO DISK ='" + text + ".BAK'";}}). The operator already knows this menu; no tool to install. | **Default** for both dry runs and the final import. |
| B | `.mdf` + `.ldf` file pair | Copied with the SQL Server service stopped (the desktop itself attaches files this way: DC_Main.cs:1023 {{CREATE DATABASE [" + SqlMain + "] ON (FILENAME = N'" + MsSqlDataPath + SqlMain + ".mdf')}}). | Fallback when the shop's backup fails (disk full, permissions). |
| C | Live read from the shop's SQL Server | A SQL login with `db_datareader` only, through a VPN/SSH tunnel; the extractor connects read-only. | Only when backups are impossible (database too large to upload). Not for the final import: we cannot prove what changed during the read. |
| D | Lite Soft `.mdb` (Data Import, WP-25) | Different product, different menu (`UT_IMPORT.cs`), OD-6. | Out of scope here. |

Not accepted: CSV/Excel exports (`UT_EXPORT.cs`). They lose types, NULL versus blank, and hidden columns.

### 1.3 Obtaining them (discovery checklist, done by our support person with the shop)

1. Photograph `SqlName.txt` (server, year database, main database, location). Do not copy the file: the desktop falls
   back to built-in `sa` credentials when it is blank (DC_Main.cs:986-998, the password is in clear text in the
   source). Treat the shop's SQL Server as weakly protected and **never connect to it over the internet**.
2. In the desktop: Company Open list → write down every company code, every year, every location, edition
   (`MsSoftType`; Lite is `L`, MDI_FORM.cs:11296-11298).
3. Run Data Backup for **each year to be carried** (the year opened in the desktop is the one backed up), plus
   NextMain once. Optionally back up `NextImage` with SQL Server Management Studio (no desktop menu for it).
4. Record SQL Server version (`SELECT @@VERSION` in the shop) because a `.bak` restores only on the same or a newer
   version. Staging runs SQL Server 2022, which restores 2008 R2 and later.
5. Upload over HTTPS to the operator's encrypted bucket; record SHA-256 of each file at the shop and again after
   upload. A mismatch stops the run.

### 1.4 Staging host

A dedicated Linux VM (or the Windows runner already planned for WP-42 O3) with SQL Server 2022 Developer/Express,
encrypted disk, no inbound internet. **Not this Mac** (no Docker by rule; Apple Silicon cannot run SQL Server
natively). In CI the synthetic fixture (§7, S9) uses the `mcr.microsoft.com/mssql/server:2022` service container on
`ubuntu-latest`. Restores use `RESTORE DATABASE [src_<run>_NextYY] FROM DISK=... WITH MOVE ..., RECOVERY` under run-
specific names, so two shops or two runs never share a database.

---

## 2. ETL pipeline

### 2.1 Stages

```
.BAK (sha256) ──restore──► SQL Server  src_<run>_NextMain / src_<run>_NextYY      (read-only after restore)
                               │  E: extractor (text-exact SELECT, scoped by CO_CODE)
                               ▼
               Postgres schema cutover_<run>  (staging; raw text columns + source row number; no RLS, no tenant)
                               │  T: transforms (§2.3) → typed tables cutover_<run>.t_<TABLE>, validator report
                               ▼
               public.<TABLE> rows with tenant_id=<tenant>, scoped to (tenant, CO_CODE)   (L: promotion, one txn)
                               │  R: reconciliation (§4) on SQL Server (desktop formulas) vs public (same formulas)
                               ▼
               cutover_run row (state=reconciled|failed) + JSON report of aggregates only
```

- **E (extract).** One query per table and scope. Every float column is selected as
  `CONVERT(varchar(32), col, 3)` (style 3 = 17 significant digits, lossless for a double), every `date` as
  `CONVERT(char(10), col, 23)`, every `datetime` as `CONVERT(varchar(23), col, 126)`, text as is. Nothing passes
  through a JavaScript `Number` or `Date`, so there is no float noise or day shift from the IST time zone (the `mssql`
  driver otherwise turns a `date` into a UTC `Date`). The scope predicate is generated from the manifest:
  `WHERE CO_CODE = @co` for company-owned tables, none for global tables (`STATE_MAST`, `COUNTRY_MAST`), and a declared
  rule for NextMain tables. Rows are written in chunks of 10 000 with a SHA-256 per chunk; the chunk table records
  `(run, table, scope, chunk_no, rows, sha256)`.
- **T (transform).** In Postgres, from staging text into typed staging tables that have exactly the public table's
  columns. Rules in §2.3. The validator (fail-closed, N78 step 3) runs here.
- **L (load/promote).** One transaction per company scope (a Lite company is tens of thousands of rows: the sample
  restored in July had AC_MAST=919, SL_DATA=191 in a demo; a busy shop is around 10^5 to 10^6 rows, which `INSERT ...
  SELECT` from staging handles in minutes). Order follows the manifest's dependencies only for readability; the web
  has no foreign keys on these tables either.
- **R (reconcile).** §4.

### 2.2 Tenant, company, location and year mapping

| Desktop | Web | Rule |
|---|---|---|
| One shop's SQL Server install | One **tenant** (`tenant_id` varchar(24), packages/db/prisma/schema.prisma:13) | Tenant id is a new slug chosen at provisioning (for example `jw-<city>-<n>`). Never reuse a tenant that has data for the same `CO_CODE` (the loader refuses, §6). |
| `CO_CODE` | `CO_CODE`, unchanged | D15 identity convention: identities migrate unchanged (N78 step 4). Several companies in one install become several `CO_CODE`s of the same tenant (open question Q9). |
| `LC_CODE` | `LC_CODE`, unchanged | Lite normally has one location (`01`). |
| `CO_YEAR` (per row) | `CO_YEAR`, unchanged | **No remap.** The value inside each row is kept even when it differs from the database's year (carried orders/approvals, §2.4). |
| Year database name `NextYY` | nothing | Only used to pick the source. `YEAR_MAST` rows (OP_DATE, CL_DATE, OLD_METHOD, YEAR_MONTH) carry the year identity. |
| `LOGIN_MAST`, `USER_SET` (NextMain) | same tables, per tenant | §3.6. |
| `MENU_DATA`, `TILE_DATA` (NextMain) | **not imported** | The web's menu catalogue and edition table own menus (WP-55, `generate-edition-table.mjs`). |

The company is created by the **import itself**, not by `seedCompany`. `seedCompany` inserts literal system accounts
(`WALKIN`, `CASH`, `BANK`, `SALES`, ... apps/api/src/modules/ops/seedCompany.ts:14-55); on a real chart these are
foreign codes that would appear in every party list. The posting engine refuses literal fallbacks and resolves accounts
from `BOOK_DETL` slots (apps/api/src/modules/shared/postingAccounts.ts:1-30), so an imported company posts correctly
only if `BOOK_DATA`/`BOOK_DETL` come from the desktop. A post-load step (S6) adds only web-only rows that have no
desktop source, listed explicitly, and never the literal chart.

### 2.3 Column transforms

**Money and weight (the core risk).** The desktop stores amounts and weights as `float` (53 bits): `AC_DATA.CR_AMT`,
`DR_AMT`, `FINE_WT`, and 1 921 float columns in all (realdb-schema-full.json). The web stores most of them as
`numeric(18,2)` money and `numeric(14,3)` weight (schema.prisma:29-33 for `AC_DATA`), but not all
(`OP_DATA.OP_AMT` is `Float`, schema.prisma:4437). Rules:

1. Canonical per-row value = the 17-digit text from extraction, parsed as `numeric(38,10)`, then cast to the target
   column's type. Postgres rounds a numeric cast half away from zero; the reconciliation's desktop side uses the same
   rounding (`ROUND(CAST(x AS decimal(38,10)), 2)` in T-SQL is also half away from zero), so both sides round the same
   value the same way.
2. For a `double precision` web column the 17-digit text is loaded unrounded (lossless).
3. The validator counts **sub-paise rows** per column: rows where `|x − round(x, 2)| > 1e-9` for money columns
   (`> 1e-9` against 3 decimals for weights). If the count is zero, per-row rounding loses nothing and every total is
   identical. If it is not zero, rounding each row can move a total by up to n × 0.005. The run then **fails** with the
   list of (table, column, rows, maximum residue, effect on each affected account's total) and needs owner decision
   Q4. We never silently round.
4. Integers (`ITM_PCS`, `SR_NO` int) exact; a float `SR_NO` with a fraction fails the validator.

**Text, collation and encoding.**

- 3 011 `varchar` columns and 2 `nvarchar` (realdb-schema-full.json). `varchar` is decoded with the database
  collation's code page (expected `SQL_Latin1_General_CP1_CI_AS`, code page 1252); the extractor reads
  `DATABASEPROPERTYEX(db,'Collation')` and refuses an unknown one. Postgres stores UTF-8.
- SQL Server compares case-insensitively and ignores trailing spaces (`'A01' = 'a01 '`); Postgres does neither.
  For every **key column** declared in the manifest (`*_CODE`, `CO_BOOK`, `VCH_NO`, `TAG_NO`, `LOGIN_NAME`, `LEDR_KEY`)
  the transform applies `rtrim`, and the validator reports (a) values changed by trimming, (b) keys that collide after
  `upper(rtrim(...))`. A collision fails the run (two parties `a01` and `A01` would be one party in the desktop's joins
  and two in the web).
- Non-key text is kept byte-for-byte (after decoding), including trailing spaces, so prints match.
- NULL, empty string and zero are kept distinct (N79 step 4). SQL Server turns an empty string written into a `date`
  into `1900-01-01`; we keep that value and count it, because web readers must see what desktop readers see.
- Widths: the validator compares `max(len(col))` in the source with the web column's width; a value longer than the
  web column fails the run (rather than a mid-load error).
- Legacy Gujarati fonts: some jewellery installs type Gujarati in an ASCII-mapped font, so the bytes are Latin and only
  the print font makes them Gujarati. The data survives unchanged, but the web screens will show Latin letters. Open
  question Q11.

**Dates and times.** `date` → `date` from `YYYY-MM-DD` text. `datetime` (`ENTRY_TIME`, `VCH_TIME`, `ADD_DATE`) is the
shop's wall clock with no zone: load into `timestamp without time zone` unchanged; where the web column is
`timestamptz`, interpret as `Asia/Kolkata`. Opening rows are dated the day before the year opens (Ac_Ledr.cs:13
{{Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy")}}); they are carried as is.

**Secrets (never extracted).** The extractor's SELECT list replaces these columns with `NULL`, so the value never
leaves SQL Server: `LOGIN_MAST.LOGIN_PWD` (plaintext, varchar 15), `CO_MAST.URL_PWD`, `CO_MAST.URL_ID` and every
credential column of `E_MAST`/`CO_SET_NEW` the manifest marks `confidential` (e-invoice/GSP, SMS, WhatsApp). These go
through the existing credential onboarding (project-memory/parity/CREDENTIAL-ONBOARDING.md). Same policy as the
backup decision OD-4/D37 (no secret in a portable artifact).

**Machine paths.** `MSImageSavePath`, printer names, `PRINT_MAST` label file paths and `BOOK_IDTL` device settings are
Windows paths: carried as data, then flagged in the post-load checklist for the operator to set on the web.

**Web-only columns** (exist in the web, not in the source: `tenant_id`, `row_id`, `LOGIN_ACTIVE`,
`PASSWORD_RESET_REQUIRED`, `PASSWORD_CHANGED_AT`, the 20 `TAG_DATA` extras, ...): `tenant_id` from the run, `row_id`
from its sequence, everything else from its column default unless the manifest names a derivation.

### 2.4 Year-end consistency: what a year database contains

This is where a naive import double-counts. Facts from the desktop source:

- **Party openings.** Balance TrFr writes only `OP_DATA` in the next year (BtmSchm.cs:2801 {{INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,  OP_AMT,OP_SIGN,FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,  DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE,DATA_TRFR)}}), `DATA_TRFR='Y'`, book `000`, parties only
  (BtmSchm.cs:2786 {{B.AC_MAIN_GR < '3' and VCH_DATE <=}}). The ledger leg is made later by `AcOp_Ledr`, which inserts
  an `AC_DATA` row `VCH_TYPE 'ACOP'`, `BOOK_NAME 'TR_AC_OPBL'` from `OP_DATA` (Ac_Ledr.cs:13 {{Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,'ACOP',VCH_NO,}}),
  run by Data Refresh (MS_UPDATE.cs:2452 {{Ac_Ledr.AcOp_Ledr("", "");}}) or by Party Opening save (TR_AC_OPBL.cs:2776).
- **Untagged item openings.** `ITM_OPBL` → `MAIN_STOCK` rows `VCH_TYPE 'ITOBL'` (Ac_Stock.cs:15 {{'ITOBL','ITM OPBL','00000',A.IT_CODE,'N'}}).
- **Tag openings.** Balance TrFr copies each tag's `BAR_DETL` row into book `000` of the next year
  (BtmSchm.cs:2358 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}, dated
  BtmSchm.cs:2378 {{mTrfr_dt.AddDays(-1.0)}}); `MAIN_STOCK` `TAGOP` rows are rebuilt from it (Ac_Stock.cs:28).
- **Open Sales Orders and Approvals** are rewritten into the next year database **keeping their original `CO_YEAR`,
  `CO_BOOK`, `VCH_NO`** (orchestration/work/WP-23/study.md, section D, BtmSchm.cs:3048; approvals BtmSchm.cs:4154, with
  a tag line in book `218`, BtmSchm.cs:4388 {{'218','00001'}}).
- `MAIN_STOCK` and `AC_DATA` are **derived**: Data Refresh deletes and regenerates them from the document tables
  (WP-24). They can be stale on a desktop where Data Refresh was not run.

Web facts: the web is one database for all years. A carried opening is an `AC_DATA` leg with `CO_BOOK '000'` and
`BOOK_NAME 'BAL TRFR'`, counted by year-scoped readers and excluded by cross-year readers; a hand-keyed opening
(`TR_AC_OPBL` or `OPENING`) is real history and visible to both (apps/api/src/modules/shared/carriedOpening.ts:1-22).
The tag availability check sums `MAIN_STOCK` across **all years** with no `CO_YEAR` filter
(apps/api/src/modules/stock/stock.ts:103-125).

Consequences, and the decision:

1. **Default scope = the live year database only** (all its vouchers from the year's opening date to the freeze, its
   `OP_DATA`/`ITM_OPBL` openings, its carried tags, orders and approvals), plus NextMain. In the web this year has no
   predecessor, so its `TR_AC_OPBL` legs are the only history and every reader (year-scoped or cross-year) gives the
   desktop's figure. This is exactly how the desktop itself works: the current year database is self-contained.
2. **Prior years are not loaded in the default.** Loading year N and N+1 together would, without rewriting: count a
   tag in N (purchase `+`) and again in N+1 (`TAGOP` `+`) in the cross-year stock check; count party balances twice in
   cross-year readers (N's history plus N+1's `TR_AC_OPBL` leg); and create two rows with the same order identity
   (`CO_YEAR` N, same `VCH_NO`) in `SL_ORD_DATA`. A history import (slice S11, Phase 2) must relabel N+1's carried
   `AC_DATA` legs to `BAL TRFR` (the rule already written in
   packages/db/prisma/migrations/20261122100000_legacy_year_end_openings_carried/migration.sql:22-37, extended to
   `VCH_TYPE 'ACOP'`/`BOOK_NAME 'TR_AC_OPBL'` legs whose `OP_DATA` row has `DATA_TRFR='Y'`), drop or relabel N+1's book
   `000` tag copies and book `218` approval tags, and keep one copy of each carried order. Until S11, the shop keeps
   the desktop installed read-only for looking up older years (Q1).
3. **Best cutover date is the first day of a financial year**, after the shop runs Balance TrFr in the desktop for the
   new year: the import is then openings plus a few days. A mid-year cutover is supported (it is just a bigger live
   year), and it keeps the whole year's GST in one system for the annual return.
4. **Data Refresh before the first dry run** (owner question Q3). Because the import copies derived tables as they
   are, the web reproduces whatever the desktop shows, stale or not. Running desktop Data Refresh (Account and Stock)
   once before dry run 1 makes the signed figures the true ones. After import, the web Data Refresh preview (WP-24)
   is run read-only and must show an empty write-set; a non-empty one is reported (it means a derived table and its
   documents disagree, in the desktop as well).

---

## 3. What to carry

The manifest (S1) lists every one of the 145 + NextMain tables with one disposition. For a **Lite** company:

### 3.1 Masters (carry all rows of the company)

`CO_MAST`, `CO_SET`, `CO_SET_NEW` (secrets nulled), `LOCT_MAST`, `YEAR_MAST`, `AC_GROUP`, `BAL_GR`, `GROUP_MAST`,
`AC_MAST`, `ADD_MAST`, `AC_MAST_SRNO`, `ITEM_MAST`, `ITM_WT_MAST`, `ITM_CITY`, `PRODUCT_MAST`, `DESIGN_MAST`/`_DETL`/
`_IDTL`, `DM_MAST`, `DM_SIZE`, `MODEL_MAST`, `TOUCH_MAST`, `LBR_MAST`, `TAX_MAST`, `STATE_MAST`, `COUNTRY_MAST`,
`EMP_MAST`, `COL_MAST`, `CONV_MAST`, `WEIGHT_MAST`, `POINT_MAST`, `MSG_MAST`, `PRINT_MAST`, `TABLE_MAST`, `TAG_SET`,
`BOOK_DATA`, `BOOK_DETL`, `BOOK_IDTL`, `SRNO_MAST`. All `AC_MAST` rows, not only those with a balance (history rows
reference them).

### 3.2 Vouchers: full live year, not "open items only"

Carry **every voucher of the live year** (header, detail, stone detail, ledger and stock legs): `SL_*`, `PR_*`,
`SL_DETL_RTN`, `SL_PR_DETL`, `CASH_DATA`, `CONTRA_DATA`, `CARD_DATA`, `UPI_DATA`, `BANK_RECONCILE`, `TAX_DATA`,
`BILL_OS_DATA`, `AC_DATA`, `MAIN_STOCK`, `BAR_*`, `BAR_CAN_*`, `APR_*`, `SL_ORD_*`, `SL_ORD_ADJ`, `INOUT_*`, `RATE_CUT_*`,
`CUT_*`, `LOT_DETL`, `ITM_LOT_DETL`, `VP_ADJ_DATA`, `LDR_ADJ_DATA`, `LOCT_AMT`, `ROJMEL_BAL`, `ROJ_MEL_DATA`,
`DELETE_DATA` (the desktop's deletion audit), `TEMP_BOOK_DATA`, `USER_DATA`, `REM_DATA`.

Why not only open items: the operator must be able to reprint and return a bill sold last month, GSTR-1/3B for the
months already filed must be re-runnable, Sales Return needs the original sale, and voucher numbering continues from
`MAX(VCH_NO)+1` of the header table (apps/api/src/modules/vouchers/numbering.ts:141, :158-163), which requires the
year's headers.

### 3.3 Opening balances

Carried as the desktop has them: `OP_DATA` (+ `OP_DETL`, `OP_LDR`), `ITM_OPBL`, and their derived `AC_DATA`
(`ACOP`/`TR_AC_OPBL`) and `MAIN_STOCK` (`ITOBL`, `TAGOP`) legs. **No recomputation** at import. The reconciliation
(§4, R2/R3) proves opening(live year, web) = opening(live year, desktop); the desktop's own
closing(N) = opening(N+1) is the shop's existing state, checked once by R9 when the previous year's backup is supplied.

### 3.4 Tag stock

`BAR_DATA`/`BAR_DETL`/`BAR_IDTL` + `MAIN_STOCK` + `SRNO_MAST`. The web finds a sellable tag from `BAR_DETL` plus the
signed `MAIN_STOCK` balance (stock.ts:100-125); the web-only `TAG_STOCK` is left empty (N78 disposition "rebuild from
migrated facts"; `existsTx` falls back to `BAR_DETL`, stock.ts:128-135). `TAG_SUM_DATA` is rebuilt. `IMAGE_DATA` and
`NextImage` pictures: optional (Q7), into `EntityImage` with SHA-256 per image.

### 3.5 Outstanding, rates, orders, approvals

`BILL_OS_DATA` (bill-wise outstanding) as is. `RATE_MAST` all rows of the live year (the last row per group is today's
rate; history is needed for reprints). Open orders and approvals are already inside the live year database (§2.4).

### 3.6 Users and rights: passwords are not carried

- `LOGIN_MAST` (NextMain) is carried with `LOGIN_PWD = NULL`, `PASSWORD_RESET_REQUIRED = 'Y'`, `LOGIN_ACTIVE = 'Y'`.
  The web login refuses a row without a password (apps/api/src/modules/auth/sessionContextLogin.ts:61-67, :113
  {{if (rows.length !== 1 || !rows[0]?.LOGIN_PWD) return null;}}), so no imported account can log in until it is set.
- Why not carry the plaintext and rehash at first login, as `verifyWithMigration` allows
  (apps/api/src/modules/auth/password.ts:22-36) and docs/runbooks/migration.md:37 says: the plaintext would sit in the
  production database (and in every backup) until each user logs in, desktop passwords are 15 characters or less and
  often trivial, and the D34 rule (8 characters, deny-list) would be bypassed for exactly the accounts that need it
  most. Slice S7 removes the plaintext branch (a stored value that is not Argon2 never verifies).
- Reset flow: (1) the platform operator runs `cutover set-admin-password --tenant --co --login` (S7), which writes an
  Argon2id hash of a random 16-character one-time password with `PASSWORD_RESET_REQUIRED='Y'`, and gives it to the
  shop owner by phone (never e-mail/WhatsApp text); (2) the owner logs in, is forced to change it (existing flow,
  apps/api/src/modules/auth/passwordAccount.ts:33); (3) the owner sets each staff password in User Create (WP-06, the
  desktop flow). Desktop `LOGIN_CATG` and `USER_UPDATE/DELETE/PRINT` are carried.
- Rights: `USER_SET` (NextMain). For a Lite tenant rights are hidden and seeded all `Y` (OD-3/D36), so the post-load
  step regenerates `USER_SET` for the catalogue the way User Create does (apps/api/src/modules/rbac/userMaster.ts:116-
  140) instead of mapping desktop menu captions. For a later Premium cutover, a caption-to-menu mapping table is
  needed (out of scope).

### 3.7 Not carried

`MENU_DATA`, `TILE_DATA` (web catalogue). Report staging tables `FINE_DATA`, `LEDR_AC_DATA`, `REPORT_DATA`,
`TAG_PRINT_DATA`, `TAG_STOCK_PRINT`, `TEMP_ADD`, `TEMP_AD_DATA`, `WEB_DATA` (regenerated, N78). `HDD_MAST` (licence
fingerprint; archive only). **Premium-only families** (`DHRN_*`, `AD_*`, `POINT_DATA`/`POINT_MEMB`, `MFG_*`, `KR_*`,
`LBR_*`, `MLT_*`, `REP_*`, `DM_DATA`, `DM_KR_DATA`, `EMP_DATA`, `BUL_DATA`, `PAY_*`, `CRNT_DATA`, `E_DATA`): for a Lite
import the validator requires **zero rows** in scope; any row stops the run with "this company has data in a menu the
Lite edition does not have" (a former Premium install), and the owner decides.

---

## 4. Reconciliation suite

### 4.1 Three layers

| Layer | Question | Desktop side | Web side | Threshold |
|---|---|---|---|---|
| **L1 storage fidelity** | Did every row and value arrive? | staging (extracted text, typed by the same transform) | `public` rows of (tenant, CO_CODE) | Exact: key sets equal, row counts equal, per-column checksums equal |
| **L2 business figures** | Are the jeweller's numbers identical? | **T-SQL on the restored SQL Server database** (independent of the extractor) | the same formula in Postgres on `public` | Money exact to the paisa, weight exact to 0.001 g, pieces and counts exact |
| **L3 what the operator sees** | Do the web screens show those numbers? | the L2 figure | the web report function (trial balance, outstanding, stock, tag stock, cash book, GST report, next voucher number) | Same as L2 |

L1 catches extractor and transform bugs; L2 catches anything L1 shares with the extractor (it reads SQL Server
directly); L3 catches web reader bugs. Example of what L3 is for: the web Year-End preview signs fine as
`CASE WHEN "SIGN"='C' THEN -FINE_WT ELSE FINE_WT END` (apps/api/src/modules/ops/yearEnd.ts:126) while desktop ledger
legs use `SIGN` `'+'`/`'-'` (Ac_Ledr.cs, 14 inserts with `'G','+'`-style values; the opening query sums
`iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT)`, BtmSchm.cs:2786). If that is a real difference, R1 at L3 shows it on the
first import. (Not verified at runtime here; recorded as a finding to check.)

All figures are per `(CO_CODE, LC_CODE, CO_YEAR)` and as of the freeze date `@d`. Canonical per-row values are used on
both sides: in T-SQL `ROUND(CAST(CONVERT(varchar(32),x,3) AS decimal(38,10)),2)` (or 3 for weight), written below as
`M(x)` and `W(x)`; in Postgres the stored numeric. Additionally each money figure is also computed the desktop's own
way (`ROUND(SUM(x),2)` over floats) and the difference is reported as `residue`; it must be 0.00 when the sub-paise
count (§2.3) is 0.

### 4.2 L1 checks (every table in the manifest)

For each table and scope: row count; the set of business keys (manifest `keys`, for example `AC_DATA.LEDR_KEY`,
`BAR_DETL (CO_BOOK, VCH_NO, SR_NO)`) compared as a sorted hash and, on mismatch, the first 20 differing keys (keys only,
no amounts); for each numeric column `sum`, `min`, `max`, count of NULL; for each text column count of NULL, count of
empty, `md5(string_agg(col, '|' ORDER BY key))`. Plus duplicate keys in the source (the desktop has no primary keys; the
web has `@@unique([tenantId, LEDR_KEY])` on `AC_DATA`, schema.prisma:45, so a duplicate `LEDR_KEY` would fail the load).
A source duplicate is a data-quality finding (§5.2), not a silent drop.

### 4.3 L2/L3 figures

**R1 Trial balance per account** (money, gold fine, silver fine), the gate's first item.

```sql
-- T-SQL (desktop, restored year database)
SELECT CO_CODE, LC_CODE, CO_YEAR, AC_CODE, COUNT(*) AS n,
       SUM(M(DR_AMT)) AS dr, SUM(M(CR_AMT)) AS cr,
       SUM(CASE WHEN IT_TYPE='G' THEN CASE WHEN SIGN='+' THEN W(FINE_WT) ELSE -W(FINE_WT) END ELSE 0 END) AS gold,
       SUM(CASE WHEN IT_TYPE='S' THEN CASE WHEN SIGN='+' THEN W(FINE_WT) ELSE -W(FINE_WT) END ELSE 0 END) AS silver
  FROM AC_DATA WHERE CO_CODE=@co AND VCH_DATE <= @d
 GROUP BY CO_CODE, LC_CODE, CO_YEAR, AC_CODE;
-- Postgres (web): the same text with M(x)=x, W(x)=x, plus AND tenant_id=$tenant
```

Plus the formula-free twin `GROUP BY AC_CODE, IT_TYPE, SIGN` of `SUM(DR_AMT), SUM(CR_AMT), SUM(FINE_WT)` (does not depend
on any sign convention), and the grand totals Σdr = Σcr checked on both sides (a desktop imbalance is reported, not
fixed). L3: `trialBalance()` (apps/api/src/modules/accounting/accounting.ts:101-110) per account equals the L2 row.

**R2 Party outstanding** (money, gold, silver per party and `DATA_TYPE`), with the desktop's own query
(BtmSchm.cs:2786 {{format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount}}, parties `AC_MAIN_GR < '3'`, `VCH_DATE <= @d`) run
in T-SQL and its Postgres translation; L3: `accountBalances()` and `outstandingReport()`
(apps/api/src/modules/reports/reports.ts:297, :727) and the voucher screens' party balance
(`desktopAccountBalance`, apps/api/src/modules/shared/desktopAccountBalance.ts). **Bill-wise outstanding** from
`BILL_OS_DATA`: per `(AC_CODE, BILL_LC, BILL_YRCD, BILL_DBCD, BILL_NO)`
`Σ M(BILL_AMT) − M(REC_AMT) − M(KASAR_AMT)` and the gold/silver twins; L3 `billOutstanding()` (reports.ts:422).

**R3 Stock by item** (untagged and tagged separately), the desktop's closing-stock query (BtmSchm.cs:2933
{{SUM(iif(ITM_SIGN = '+', ITM_PCS, -ITM_PCS)) AS ClPcs,SUM(iif(ITM_SIGN = '+',ITM_NWT,-ITM_NWT)) AS ClWt}}, gross
twin, fine) grouped by `(CO_CODE, LC_CODE, IT_CODE, tagged = TAG_NO NOT IN ('N','') AND TAG_NO IS NOT NULL)` on
`MAIN_STOCK` to `@d`. L3: the Stock report and `closingStockValuation()` (apps/api/src/modules/reports/closingStock.ts:107).

**R4 Tags in stock.** The set of `(LC_CODE, TAG_NO, VCH_SRNO, IT_CODE)` whose signed `MAIN_STOCK` `VCH_SRNO` balance is
positive (BtmSchm.cs:2358), compared **as a set** (count, sorted-key hash, first differing keys), plus per item: tag
count, Σ `ITM_PCS`, Σ W(`ITM_GWT`), Σ W(`ITM_NWT`), Σ W(`ITM_FINE`) from the tag's `BAR_DETL` row. L3: the Tag Stock
report (apps/api/src/modules/reports/tagStock.ts, desktop `RP_TAG`) totals, and for every tag in the set the web's
availability check returns exactly one instance (stock.ts:100-125). Also `checkTagInvariants()`
(apps/api/src/modules/stock/tagInvariants.ts:87) must report no violation that the desktop data does not also have.

**R5 Cash and bank, day by day.** For each cash and bank account (the accounts in slot 1 of the CASH and BANK books'
`BOOK_DETL`, plus accounts in the cash/bank groups the owner confirms, Q12): per `VCH_DATE` Σ M(DR) and Σ M(CR) and the
running closing. Comparing **every day** catches a date shift that a year total would hide. L3: the Cash/Bank report
and Rojmel (desktop `RP_CASH_BANK`, `RP_ROJMEL`).

**R6 GST per month.** From `TAX_DATA`: per `(CO_CODE, LC_CODE, month(VCH_DATE), BOOK_NAME, TRAN_TYPE, TAX_TYPE,
TAX_PRC)` count, Σ M(`NET_AMT`), Σ M(`TAX_AMT`), Σ M(`DISC_AMT`), Σ M(`TOT_AMT`), Σ M(`TAX_FREE_AMT`); from `SL_DATA`
and `PR_DATA` headers per month Σ M(`CGST_TAX`), M(`SGST_TAX`), M(`IGST_TAX`), M(`TOT_AMT`). L3: the GST report per
month (apps/api/src/modules/reports/gstReport.ts, desktop `RP_GST`) and `gstr3b()` (reports.ts:465).

**R7 Last voucher number per book.** For each `(CO_CODE, LC_CODE, CO_YEAR, CO_BOOK)` of `BOOK_DATA`: `MAX(VCH_NO)` in
the book's header table (`BOOK_TBL_NAME`). L3: `nextVoucherNoTx()` (numbering.ts:163) called inside a transaction that is
rolled back returns desktop max + 1 for every book. Tag serial: `SRNO_MAST.TAG_SRNO` per `(CO_CODE, LC_CODE)` equal, and
not lower than the highest serial in `BAR_DETL.TAG_NO` (otherwise the next tag printed in the web would duplicate a
label; numbering.ts:177-215).

**R8 Open orders and approvals** (the gate's last item). Orders open at `@d` with the Balance TrFr rule
(BtmSchm.cs:3024 {{HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END) + SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_GOLD ELSE - B.ORD_GOLD END)}}
+ silver `> 0`): per order the remaining amount, gold, silver, and the set of booked tags. Approvals out at `@d`: the
set of `APR_DETL` issue lines not returned, sold or wholesale-issued, computed read-only with the same conditions the
desktop writes at BtmSchm.cs:4123-4124 (never by running those updates). L3: the Order and Approval reports.

**R9 Carry-forward identity** (only when the previous year's backup is also supplied): closing(N) from R2/R3 on
`NextYY-1` equals `OP_DATA`/`ITM_OPBL` and the carried tags of the live year, per party and item. This checks the
desktop's own carry, which WP-23 says is not transactional (study.md: "There is no transaction in this form"); a
difference is a data-quality finding for the shop, not an import failure.

**R10 Masters and users.** Counts and key sets of `AC_MAST`, `ITEM_MAST`, `BOOK_DATA`, `LOGIN_MAST` (names only),
`TAX_MAST` rates, today's `RATE_MAST` row per group.

### 4.4 Pass and fail

- **Pass** = every L1, L2 and L3 comparison equal (money difference 0.00, weight difference 0.000, counts 0), no
  validator failure, no unexplained skipped row.
- No tolerance band. The only way to pass with a difference is an **explained-difference entry** signed by the owner
  in the run report: a reason code (`SUBPAISE_ROUNDING`, `DESKTOP_DUPLICATE_KEY`, `DESKTOP_STALE_DERIVED`, ...), the
  exact rows/accounts affected and the amount. Default list: empty.
- The report contains aggregates and keys only (the O3 rule, LITE-MASTER-PLAN.md:527-529): no names, mobiles, amounts
  per voucher or row dumps leave the staging host.
- Output: `cutover-report.json` (machine) + `cutover-report.md` (one table per R-check: desktop, web, difference,
  verdict), stored with the run under `project-memory/parity/cutover/<tenant>/<run>/` (sanitized) and the full
  version on the staging host.

---

## 5. Runbook: dry run → sign-off → freeze → final import → go-live, and rollback

### 5.1 Why the "final delta" is a full re-import

The desktop tables have no primary keys, no row versions and no change timestamps, and deletions are physical
(`DELETE_DATA` is an audit copy, not a tombstone the loader can trust). A row-level delta would have to guess. A Lite
year imports in minutes, so the final step **re-extracts the final backup completely into a new run** and promotes
it; the "delta" is a **report** (rows added, changed, removed per table since dry run 2, from the two staging snapshots)
that the operator reads to confirm it matches the days between dry run 2 and the freeze. This gives the safety of a
full load and the review of a delta.

### 5.2 Timeline

| When | Step | Who | Exit |
|---|---|---|---|
| T-21 d | Discovery (§1.3); consent and data-processing agreement for customer data (stop-and-ask, LITE-MASTER-PLAN.md §3); tenant id reserved | Support + owner | Inventory sheet; backups uploaded, SHA-256 matched |
| T-20 d | Inventory run (S0): aggregate-only profile per database: tables, rows per scope, sub-paise counts, duplicate keys, Premium-family rows, collation, widths | Engineer | Data-quality report to the shop (in their terms: "3 parties have the same code in different case") |
| T-18 d | Shop fixes data-quality findings **in the desktop** where possible; runs Data Refresh (Q3) | Shop operator | — |
| T-14 d | **Dry run 1** into a shadow tenant `<tenant>-dr1`: full pipeline, L1-L3 | Engineer | Report; every failure explained or fixed in the pipeline |
| T-10 d | Operator tries the shadow tenant: reprint a bill, sell an imported tag, receive against an imported bill, adjust an old order, return an approval, next voucher number in each book, Tag Print | Shop operator + support | Continuation checklist (N79 step 5) |
| T-7 d | **Dry run 2** from a fresh backup, **timed** end to end (this measures the freeze window) | Engineer | Report all green; timing |
| T-5 d | **Sign-off 1**: owner and jeweller sign the dry-run-2 report (figures they recognise: trial balance totals, top 10 party balances, stock by item, tag count, last bill numbers) | Owner + jeweller | Signed report |
| T-0, close of business | **Freeze**: all desktop users exit; operator runs Data Backup (year + NextMain); support sets the year database read-only (`ALTER DATABASE NextYY SET READ_ONLY`, reversible; Q6) | Shop operator + support | Final `.BAK` uploaded, SHA-256 matched |
| T-0 +1 h | **Final import** into the real tenant (new run), L1-L3, delta report vs dry run 2 | Engineer | All green; delta report reviewed |
| T-0 +2 h | **Sign-off 2** (go/no-go) by the owner on the final report; set the admin one-time password (§3.6) | Owner | Go |
| T+1 d morning | Go-live: owner logs in, sets staff passwords; first sale, first receipt, Daily Rate entry; support on call | Shop + support | First-hour checks pass |
| T+1..T+7 d | Daily: re-run R1/R2/R4/R7 L3 on the live tenant against the frozen desktop figure plus the web vouchers since go-live (voucher register); UAT week (WP-56) | Support | Signed UAT |
| T+90 d | Desktop retired: staging databases dropped, `.BAK` copies destroyed except the encrypted archive (retention per DPA) | Operator | Destruction record |

### 5.3 Rollback

- **Before go-live (any failed gate).** Do not promote, or delete the run's rows: the run is scoped to (tenant,
  `CO_CODE`), so rollback is `DELETE FROM <each manifest table> WHERE tenant_id=$t AND "CO_CODE"=$co` in one
  transaction under the bypass role with the same preflight (S4 provides `cutover rollback --run`). Set the desktop
  database back to `READ_WRITE`. The shop has lost nothing: we only ever read the desktop.
- **After go-live, before the rollback deadline (proposed end of T+3 d, Q10).** Stop web use; export the voucher
  register of every web voucher since go-live (it is the re-keying list); set the desktop back to read-write; the shop
  re-enters those vouchers in the desktop. The web tenant is kept read-only for 30 days for reference.
- **After the deadline.** No rollback to the desktop; defects are fixed forward in the web.
- A `pg_dump` of the database is taken immediately before the final promotion (DR runbook,
  project-memory/parity/DR-RUNBOOK.md); it is the last resort if promotion damaged anything outside the scope (the
  sentinel check in §6 is designed to make that impossible).

---

## 6. RLS, security and audit

**Role.** Promotion writes many tables for one tenant and must also *see other tenants* to prove it did not touch them,
so it runs as the migration role (`MIGRATE_DATABASE_URL`, deploy/.env.example:7), never as `app_user` (which is
`NOBYPASSRLS`, packages/db/setup_roles.sql:22-24). It follows the repo's migration preflight pattern exactly
(packages/db/prisma/migrations/20261122100000_legacy_year_end_openings_carried/migration.sql:10-20):

```sql
BEGIN;
DO $preflight$ BEGIN
  IF NOT EXISTS (SELECT 1 FROM pg_roles WHERE rolname=current_user AND (rolsuper OR rolbypassrls)) THEN
    RAISE EXCEPTION 'cutover promotion requires a role with complete tenant visibility';
  END IF;
END $preflight$;
SET LOCAL row_security = off;
SET LOCAL statement_timeout = '15min';
-- 1. guard: target scope empty (or owned by this run id when re-promoting)
-- 2. sentinel BEFORE: per manifest table, count(*) and md5 of row_id list for tenant_id <> $t, and for tenant $t with CO_CODE <> $co
-- 3. INSERT INTO public."X"(tenant_id, cols...) SELECT $t, cols... FROM cutover_<run>."t_X"   -- tenant_id written explicitly in every statement
-- 4. sentinel AFTER: identical, else RAISE (whole promotion rolls back)
-- 5. UPDATE cutover_run SET state='promoted', promoted_at=now(), sentinel_hash=...
COMMIT;
```

With `row_security = off` the `WITH CHECK (tenant_id = current_setting('app.tenant_id'))` policy
(packages/db/prisma/rls.sql:62-63) does not protect us, so: every statement writes `tenant_id` from one bound
parameter; the staging tables have no `tenant_id` column (they cannot carry a wrong one); the sentinel proves no other
row changed. After commit, a second connection **as `app_user` through `withTenant`** (packages/db/src/tenant.ts:23-49)
re-counts every table for the tenant: the counts must equal the promoted counts, which proves the rows are visible
under forced RLS with the right tenant.

**Staging isolation.** `cutover_<run>` schemas are created and dropped by the migration role; `app_user` gets no grant
on them. `check-fresh-provision.mjs` and `/ready` invariants (apps/api/src/modules/ops/invariants.ts) are unaffected
because staging tables have no `tenant_id`. The schema is dropped after sign-off 2 (+7 days).

**Audit trail.**

- New table `cutover_run` (migration in S4, modelled on `DataRepairRun`, schema.prisma:7201-7223, with a `tenant_id` and
  forced RLS like every tenant table): `run_id`, `tenant_id`, `co_code`, `mode` (`dry-run`/`final`), `state`
  (`extracted`→`validated`→`promoted`→`reconciled`|`failed`|`rolled-back`), `source_files` (names + SHA-256),
  `manifest_sha256`, `pipeline_git_sha`, `schema_migrations_head`, `counts` (per table), `reconciliation` (verdicts and
  totals only), `explained_differences`, `operator`, `approved_by`, timestamps, `sentinel_hash`.
- One `audit_log` row per state change (apps/api/src/modules/ops/audit.ts:15-35; `audit_log` is append-only for the
  app role, setup_roles.sql:30-31).
- The final report records the exact `.BAK` hashes, so anyone can later prove which desktop data the tenant started
  from.

**Data handling.** Backups contain customers' names, mobiles, addresses, PAN/GSTIN, and plaintext desktop passwords:
encrypted at rest and in transit, staging host only, access by named engineers, destroyed per §5.2. The extractor
never selects secret columns (§2.3), so no secret reaches Postgres, logs or reports. Live mode (format C) uses a
`db_datareader` login created for the purpose and removed after.

**Containment.** `production-cutover-load` stays until S10 meets its gate (packages/core/containment.mjs:96-102):
signed manifest (S1), fail-closed validator (S3), two-company/two-year isolation test (S9 fixture), two clean shadow
loads (rehearsals A and B, N79 step 7). Lifting it is a reviewed code change, as the registry requires.

---

## 7. Work breakdown (PR-sized slices)

All new code under `web/tools/cutover/` (Node, ESM, same toolchain as `apps/api/integration`), with unit tests in
`web/tools/cutover/test/` and DB tests in `apps/api/test/cutover*.db.test.ts`. Real customer data is never committed.

| # | Slice | Content | Size | Risk | Depends |
|---|---|---|---|---|---|
| S0 | Inventory (aggregate-only profiler) | `cutover inventory --db`: per table and `(CO_CODE, LC_CODE, CO_YEAR)` row counts, sub-paise counts per float column, duplicate keys after `upper(rtrim)`, max text length vs web width, Premium-family rows, collation, `1900-01-01` counts. Captures the **NextMain** schema into `project-memory/parity/DESKTOP-REAL-SCHEMA-NEXTMAIN.json`. Prints aggregates only. | S | Low | — |
| S1 | Ownership manifest v1 (Lite) | `web/migration/datacare-next/v1/ownership-manifest.json` (path from N78): every table of the 145 + NextMain with source database, disposition (§3), scope columns, keys, secret columns, transforms, validators, Lite rule (must-be-empty). Test: exact coverage of the baseline, no duplicates. | M | Low | S0 (NextMain list) |
| S9 | Synthetic desktop fixture | T-SQL script that creates `NextMain` + `Next24` + `Next25` from the real schema with synthetic rows: 2 companies, 2 years, carried openings/tags/orders/approvals, sub-paise floats, trailing-space and case-duplicate codes, `1900-01-01` dates, a stale derived row, Premium rows in a "former Premium" variant. Runs in the CI `mssql/server:2022` service. Gives the isolation test of the containment gate. | M | Medium (fixture fidelity) | S1 |
| S2 | Extractor | Restore helper (`RESTORE ... WITH MOVE` under run names), text-exact scoped SELECT (§2.1), chunk table with SHA-256, absent ≠ empty, read-only connection. | M | Medium | S1, S9 |
| S3 | Transforms + fail-closed validator | Numeric canonicalization, key `rtrim` + collision check, dates, secret nulling, widths, web-only defaults; validator failure modes each with a test (N78 step 3). Golden files per transform. | M | **High** (money precision) | S2 |
| S4 | Promotion + `cutover_run` + rollback | Migration for `cutover_run` (forced RLS); promotion transaction with preflight, scope guard, sentinels, post-commit `app_user` recount; `cutover rollback --run`. Replaces `cutover.mjs` load path (`cutover.mjs` keeps `--dry-run` only, or is deleted). | L | **High** (RLS bypass) | S3 |
| S5 | Reconciliation suite | R1-R10 as paired SQL files (`recon/<id>.mssql.sql`, `recon/<id>.pg.sql`) + L3 calls into the web report functions; runner and `cutover-report.{json,md}`. Test on the S9 fixture: green; then on a mutated fixture (one paisa changed, one tag removed, one day shifted): each detected by the right R-check. | L | Medium | S4 |
| S6 | Post-load completion | Web-only rows with no desktop source (explicit list; Lite `USER_SET` all `Y` per D36; settings defaults); `TAG_SUM_DATA` rebuild; web Data Refresh preview must be empty; no literal chart. | M | Medium | S4 |
| S7 | Credentials | Import with `LOGIN_PWD NULL` + reset required; `cutover set-admin-password`; remove the plaintext branch of `verifyWithMigration` (password.ts:27-36) with a test that a non-Argon2 stored value never verifies; update docs/runbooks/migration.md:37. | S | Medium (auth) | S4 |
| S8 | Continuation tests | Real-stack browser cases on an imported S9 tenant: reprint, sell imported tag, receipt against imported bill, adjust carried order, approval return, next voucher number, tag print serial. | M | Medium | S5, S6, S7 |
| S10 | Runbook, rehearsals, containment lift | Rewrite project-memory/parity/CUTOVER-RUNBOOK.md from §5; rehearsal A (fixture, injected interruption and corrupt chunk) and B (owner-supplied sanitized real backup, timed freeze, rollback drill); evidence under `docs/parity/`; PR that lifts `production-cutover-load`. | M | High (needs real data; stop-and-ask) | S8, owner Q5 |
| S11 | Prior-year history (Phase 2) | Multi-year import with the de-duplication rules of §2.4 point 2 and R9 per year boundary. | L | High | S10, Q1 |

Order: S0 → S1 → S9 → S2 → S3 → S4 → (S5, S6, S7 in parallel) → S8 → S10. S11 only if the owner asks for history.
Estimated 9-11 PRs before S10. The first slice that touches production code paths is S7 (auth); S4 adds one
migration.

---

## 8. Open questions for the owner

| # | Question | Default if no answer |
|---|---|---|
| Q1 | History: is the live year enough in the web, with the desktop kept read-only for older years? | Yes, live year only; S11 later on request |
| Q2 | Preferred cutover date: first day of a financial year (cleanest), or any day? | Offer 1 April first, accept mid-year |
| Q3 | May the shop run desktop Data Refresh (Account, Stock) before dry run 1, so the signed figures are refreshed ones? | Yes |
| Q4 | If a column has sub-paise values, accept per-row rounding with an itemised explained difference, or keep the float? | Stop and decide per shop; no silent rounding |
| Q5 | Real data: when will a sanitized real backup be available for rehearsal B, and is the DPA in place? (customer data is a stop-and-ask point) | S10 blocked until then; everything else proceeds on the fixture |
| Q6 | Freeze by `ALTER DATABASE ... SET READ_ONLY` on the shop's server (reversible, but a change to their server), or procedurally (everyone logs out, backup taken)? | Read-only, done by support with the shop on the phone |
| Q7 | Carry tag and design pictures (`IMAGE_DATA`, `NextImage`)? | Yes if under 2 GB, as a separate step after go-live |
| Q8 | Carry all desktop users, or only active ones chosen by the owner? Admin one-time password by phone acceptable? | All users, inactive ones deactivated by the owner after go-live; phone |
| Q9 | Several companies in one desktop install: one tenant with several `CO_CODE`, or one tenant per company (different legal owners)? | One tenant per legal owner |
| Q10 | Rollback deadline after go-live, and how long the desktop stays installed read-only? | End of T+3 days; 90 days |
| Q11 | Do any shops type Gujarati in a legacy (ASCII-mapped) font? | Check at discovery; if yes, a font-mapping slice before that shop |
| Q12 | Which account groups are "cash" and "bank" for R5 (desktop group codes vary by chart)? | Accounts in slot 1 of CASH/BANK books plus groups confirmed at discovery |
| Q13 | Former Premium installs that move to Lite: refuse, or import the Premium data unused? | Refuse (Lite validator stops), decide per shop |

---

## Appendix: key evidence used

- Year/main database model: DC_Main.cs:968-972, :1003-1054; MS_OPNCOMP.cs:566-598; MS_YEAR.cs:1366-1384; UT_BKP.cs:1215-1248.
- Carry forward: BtmSchm.cs:2358, :2378, :2786, :2801, :2933, :3024, :3048, :4123-4124, :4154, :4388;
  orchestration/work/WP-23/study.md (sections A-E, lifecycle, open questions 4-5).
- Opening ledger/stock legs: Ac_Ledr.cs:9-25; Ac_Stock.cs:11-34; MS_UPDATE.cs:2452, :32669.
- Web: apps/api/integration/cutover.mjs; packages/core/containment.mjs:96-102; packages/db/src/tenant.ts:23-49;
  packages/db/setup_roles.sql; packages/db/prisma/rls.sql:39-63;
  packages/db/prisma/migrations/20261122100000_legacy_year_end_openings_carried/migration.sql;
  apps/api/src/modules/shared/carriedOpening.ts; apps/api/src/modules/shared/postingAccounts.ts;
  apps/api/src/modules/ops/seedCompany.ts:14-55, :649; apps/api/src/modules/vouchers/numbering.ts:141-215;
  apps/api/src/modules/stock/stock.ts:100-135; apps/api/src/modules/auth/password.ts:22-36;
  apps/api/src/modules/auth/sessionContextLogin.ts:61-113; schema.prisma:12-48, :3786-3809, :4426-4437, :7201-7223.
- Plans: docs/parity/LITE-MASTER-PLAN.md:111-123 (OD-1..OD-8), :495, :527-529, :552;
  docs/master-parity-plan-2026-09-29/11-audit-implementation-plan-2026-10-01.md:109, :984-1040;
  docs/master-parity-plan-2026-09-29/14-phase2-saas-plan.md:124-127.

---

## Build packets for cheap models (Claude verifies each)

Each packet is one PR. The builder reads only the sections named; the verifier (Claude) runs the check listed and
reviews against this design. No packet needs real customer data; all run on the S9 fixture.

1. **S0 Inventory.** Read §2.3, §3.7. Write `web/tools/cutover/inventory.mjs` + unit tests with a fake SQL adapter.
   Output: JSON of aggregates only. Verify: test proves no row value appears in output; sub-paise and case-collision
   counters fire on crafted inputs.
2. **S1 Manifest.** Read §3, §2.2. Write `web/migration/datacare-next/v1/ownership-manifest.json` + coverage test
   against DESKTOP-REAL-SCHEMA.json and the NextMain list. Verify: test fails if one table is removed or duplicated;
   secret columns (`LOGIN_PWD`, `URL_PWD`, `URL_ID`) marked confidential.
3. **S9 Fixture.** Read §2.4, §7 row S9. Write `web/tools/cutover/fixture/*.sql` (synthetic only) + CI job with the
   `mssql/server:2022` service. Verify: fixture contains every edge case listed in S9 (checklist in the PR body).
4. **S2 Extractor.** Read §2.1. Text-exact scoped SELECTs, chunk SHA-256, absent ≠ empty. Verify: second company's
   rows never extracted; float round-trip lossless on fixture; secret columns arrive NULL.
5. **S3 Transforms + validator.** Read §2.3. Golden-file tests per transform; each validator failure mode has a
   failing test. Verify: sub-paise row fails the run; `a01`/`A01` collision fails; width overflow fails.
6. **S4 Promotion.** Read §6. `cutover_run` migration (forced RLS), preflight, scope guard, sentinels, app_user
   recount, rollback command. Verify: DB test with two tenants proves the other tenant and other CO_CODE unchanged;
   promotion refuses a non-bypass role; rollback leaves scope empty.
7. **S5 Reconciliation.** Read §4. Paired `.mssql.sql`/`.pg.sql` files R1-R10, runner, report. Verify: green on the
   fixture; mutated fixture (one paisa, one tag, one day shift, one voucher number) is caught by the right R-check.
8. **S6 Post-load completion.** Read §2.2, §3.4, §3.6 rights. Verify: no literal seed accounts in an imported company;
   Lite USER_SET all `Y`; Data Refresh preview empty on fixture.
9. **S7 Credentials.** Read §3.6. Verify: imported login cannot sign in; set-admin-password then forced change works;
   a plaintext stored value never verifies (test).
10. **S8 Continuation.** Read §5.2 T-10 row. Real-stack cases on imported fixture tenant. Verify: CI real-stack green.
11. **S10 Rehearsals + containment lift.** Architect-led, needs owner Q5; not a cheap-model packet.
