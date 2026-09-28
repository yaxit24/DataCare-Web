# Desktop-vs-Web FEATURE GAP REGISTER

**Date:** 2026-07-29
**Trigger:** the owner reported that features, configuration and management present in the desktop are
missing from the web. That report is **correct**, and this register quantifies it.

---

## 1. A measurement correction I must state first

I previously reported **"UI field capturability 100% (496/496), 0 gaps"** as a green gate. That number is
arithmetically right and **materially misleading**, because its denominator is *the set of fields the web
API already accepts*. A desktop control the web never implemented at all was invisible to it. It proved the
web's own fields are reachable — not that the desktop's fields exist.

The correct denominator is the desktop. Measured with `feature_gap_audit.py`:

| Control class | Desktop | Present in web | Gap |
|---|---:|---:|---:|
| Data-entry (TextBox/Combo/Masked/Check/Date/Radio) | 2,512 | 1,538 (61.2%) | **974** |
| Commands (buttons = actions/features) | 1,669 | 1,116 (66.9%) | **553** |
| Grids | 251 | 239 (95.2%) | 12 |
| Other (image/list/tree/tab) | 123 | 56 (45.5%) | 67 |
| **Total** | **4,555** | **2,949 (64.7%)** | **1,606** |

**These are LOWER BOUNDS.** The matcher counts a desktop control as present if its name appears *anywhere*
in 3.2 MB of web source, so it over-credits. The real gap is larger.

Matcher validated in both directions: `_BtnSave`, `_chkRateUnFix`, `_TEXT_OLD` resolve true;
`_BtnZZZQuantumFlux`, `_txtNonExistentThing` resolve false. Two matcher defects were found and fixed before
trusting any output (leading-underscore backing fields; case-sensitive prefix stripping that mis-flagged
every standard Save/Print/Exit button).

The parity matrix already conceded this shape independently: only **48 of 204** forms are
`dedicated-current-surface`; 29 sit on **generic scaffolds** (16 CRUD + 12 report + 1 plain).

---

## 2. CONFIGURATION — CLOSED 2026-07-29 (was 75 of 130 unreachable)

**Status: settings exposure 128/128 configurable columns (100%), gated by `pnpm settings:parity`.**

All 130 columns of `CO_SET` + `CO_SET_NEW` are now reachable (128 configurable; the two `CO_CODE` columns are
row identity). The surface is typed rather than free text: 63 boolean, 19 enum, 9 number, 2 date, 35 text.
88 descriptors carry option lists transcribed from desktop source with citations; 35 are marked
`unknownOptions` and stay free text rather than inventing a dropdown — the gate lets that count fall, never
rise.

Two design points that were nearly wrong:
* `COUNTRY_ID` exists in **both** tables and the desktop writes both with different defaults
  (`CO_SET_NEW.COUNTRY_ID='91'` at `Ac_Image.cs:7163`, `CO_SET.COUNTRY_ID='971'` at `Mfg_Module.cs:1506`).
  Keying the catalog by column name silently dropped one, so descriptors are identified by `table.column`.
* `TOT_AMT_ROF` offers the choices 0/1/2 but is an **integer** column. Storage shape now wins over option
  shape, otherwise the text `'0'` would be written into an integer column.

The connection to §0 P0-1 is direct: `CO_SET_NEW.PROFIT_RPT_TYPE` decides whether the balance sheet values
metal at all, and it was one of the unreachable 70.

### Original finding (retained for the record)

`CO_SET` (60) + `CO_SET_NEW` (70) = 130 settings columns. The web's `SETTING_FIELDS` exposes **55**.

**Correction (2026-07-29, found during planning).** I first wrote "the backend reads 129 of 130". That is
true only in the loose sense that 129 column names appear somewhere in API source. The settings **surface**
is narrower than that and the gap is correspondingly larger: `settings.ts` reads and writes **`CO_SET` only**
(zero `CO_SET_NEW` references, verified), so **none of the 70 `CO_SET_NEW` settings can be read or written
through the settings endpoint at all.** Individual values are read directly by their consuming modules
(`counterStockPolicy.ts`, `roundingPolicyLoader.ts`, `sales.ts`, `purchase.ts`, `companySettings.ts`), which
is why behaviour is honoured while remaining unmanageable. Closing this therefore needs dual-table
read/write, not merely more list entries.

These settings **silently govern behaviour at whatever value the database holds, with no way for the owner
to see or change them.** The
desktop exposes them through `UT_SETTING_MAIN` (113 controls, 45% present), `UT_SETTING` (59, 59%) and
`UT_SET_ADMIN` (27, 44%).

Operationally significant examples, all verified absent from the settings UI:

| Setting | What it controls |
|---|---|
| `NEGATIVE_STK_SALE` | whether stock may be sold below zero |
| `CUR_DAY_POSTING` | restrict posting to the current day |
| `SL_NWT_LOCK`, `ITM_FINE_LOCK` | lock net weight / fine against edits |
| `COUNTER_STK` | counter-wise stock enforcement |
| `SALES_WITH_HMTAX`, `PURC_WITH_HMTAX` | hallmark charge inside tax base |
| `SL_TDS_TAX`, `PR_TDS_TAX` | TDS on sales / purchase |
| `TOT_AMT_ROF`, `PR_RATE_ROF` | bill and purchase-rate rounding |
| `OLD_GOLD_TYPE` | old-gold valuation basis |
| `YEAR_GOLD_SL`, `YEAR_SILVER_SL` | year-wise metal sale control |
| `QR_CODE_GEN` | QR on documents |
| `TAG_AUTO_PRINT`, `TAG_VCH_AUTO_SAVE` | tag print/save automation |
| `ESTMATE_TAX`, `ESTMATE_BANK_LOCK` | estimate tax and bank lock |
| `STK_LMIT_WITH_DESIGN` | stock limit by design |
| `USER_KR_TOUCH_HIDE` | hide karigar touch from users |
| `FONT_*`, `GRID_ROW_HIGHT`, `THEME`, `TILE_MENU` | presentation the desktop lets each shop set |

Full list of 75 in the audit JSON.

---

## 3. KEYBOARD — every Ctrl shortcut is discarded

`FormKeys.tsx:41-47` returns with no action when `ctrlKey` is set. The desktop's MDI shell
(`MDI_FORM.cs:12458-12530`) implements:

| Shortcut | Desktop target |
|---|---|
| Ctrl+F1 | Daily Rate |
| Ctrl+F2 | Order Zoom |
| Ctrl+F5 | Bill-wise Receipt |
| Ctrl+F6 | Rate Cut |
| Ctrl+F8 | Bank Receipt |
| Ctrl+F9 | Bank Payment |
| Ctrl+F11 | Cash / Bank |
| Ctrl+F12 | Tag Estimate |
| Ctrl+A / Ctrl+B / Ctrl+O | `MDI_FORM.cs:12597-12620` (Ctrl+B gated on a "Data Export" element) |

Plain F-keys work; **none of the Ctrl combinations do.** For a counter operator these are the fastest paths
in the product.

---

## 4. CROSS-CUTTING absences (verified by count, not sampled)

| Capability | Desktop | Web |
|---|---:|---:|
| **Excel / XLSX export** (`BtnExel`, Excel automation) | 38 forms | **CLOSED** — all 45 reports export |
| **Image capture / attach / delete / zoom on forms** (`BtnImgS/C/D`) | **24 forms** | **0 pages** (one `CameraCapture` component, wired only into repair) |
| **Bill profit on the voucher** (`nBillProfit`) | 4 forms | **engine built** (see §4f) |
| **Blank-label skip before printing** (`nLableSkip`) | **12 forms** | **0** |
| **Voucher transfer** (`tTrfrNo`, `TR_SALE.cs:20656`) | present | **0** |
| **Master list search box** | per-master | **0** (all 7 "filter" hits are `Array.filter()`) |
| **Delete a user** | `MS_USER.cs:2067` | **no DELETE route** on `/admin/users` |
| **Distinct input-tax ledger** (`INPUT_TAX_AC`) | `MS_TAX.cs` | **0** |
| **Olocker policy generation** | `TR_SALE.cs` ×3 | **0** |

---

## 4b. XLSX export — CLOSED 2026-07-30

`GET /reports/:report/export.xlsx` serves **all 45 report builders** through one writer
(`apps/api/src/modules/reports/xlsx.ts`). The route reuses the *same* builder each report route calls, so a
workbook cannot disagree with what the screen shows, and rows are always re-derived server-side — the client
cannot supply them.

Verified by `file(1)` as `Microsoft Excel 2007+` for sales-register, cash-book, trial-balance and
stock-valuation, with the correct MIME type and attachment filename; an unknown slug returns 404.

**Formula injection is closed by construction.** Exported business data routinely begins with `=`, `+`, `-`
or `@` (a negative amount rendered as text, a remark starting with a dash), and a spreadsheet would evaluate
such a cell. Every data value is written as a STRING cell, so no code path can emit a formula. The test
asserts the workbook XML contains no `<f>` element and fails when the protection is removed.

**Package choice, stated precisely.** `write-excel-file@4.1.1` — MIT, one dependency, no native build.
SheetJS `xlsx` was rejected on **supply chain, not on the CVE**: `GHSA-4r6h-8v6p-xvw6` is a READ-path bug and
the advisory says write-only workflows are unaffected, but the fix is 0.19.3+ while public npm stops at 0.18.5
and current builds ship from the vendor's CDN. If a future legacy IMPORT needs SheetJS for reading, that
decision must be revisited with the CVE fully in scope.

A test-design note: my first assertion for "non-numeric value in a numeric column stays text" checked that
the XML lacked `<v>0</v>`, which was wrong — that string is also how a shared-string INDEX of 0 appears. The
assertion now checks the cell TYPE (`t="s"`), which is what actually distinguishes a string cell from a
numeric one.

## 4c. Report date filtering — PARTIAL 2026-07-30

**Measured before:** only **3 of 48** report routes accepted a date range, and the UI never sent one — so
every other report could only be viewed a whole financial year at a time. The desktop filters nearly every
family by a from/to voucher date.

Closed by carrying the window on `ReportScope` (so a report gains filtering without changing its signature)
plus a `dateWhere(scope, column, params)` helper. The helper exists because each builder assembles its own
positional parameters with hardcoded `$1`/`$2`; a date predicate cannot use a fixed index, so it pushes onto
the caller's array and returns SQL referencing the indices it actually used.

`readScope` now parses `fromDate`/`toDate` and accepts **only** a well-formed ISO date — anything else is
ignored rather than reaching SQL. The report page exposes From/To inputs and passes them to both the view and
the XLSX export.

**Boundaries are inclusive on both ends**, pinned by a fixture with a voucher exactly ON each boundary.
Making the lower bound exclusive fails with `['SRT/00003']` instead of `['SRT/00002','SRT/00003']` — a report
that silently drops the first day of a month is worse than one with no filter, which is why the control tests
the boundary rather than "fewer rows came back".

**Coverage: 3 -> 26 builders.** Wired across the register family (sales-return, purchase-return, contra),
the sales-analysis family (sales-by-party, monthly-sales, daily-sales, top-items, sales-gst-monthly, gstr3b),
the purchase family (monthly-purchase, purchase-by-party, gstr2, gst-input-register), the ledger-derived
reports (outstanding, group-summary, trial-balance-full, karigar-balances), and the geography/CRM reports
(area-outstanding, area-wise-sales, location-wise-sales, customer-crm, bill-outstanding, dhrn-outstanding,
stock-valuation).

Each target was verified individually — its `FROM`/`WHERE` line read to establish whether the date column is
aliased, and the column confirmed as a `date` type in `information_schema`. A first attempt to detect the
alias by regex produced `WHERE` as the alias for unaliased tables and found no date column for most, so it
was discarded rather than trusted; wiring 23 builders from a bad inference would have produced silently
wrong filters.

**Deliberately NOT wired:** `billAging` (its year predicate sits inside a subquery and the report is an
as-of aging snapshot, where a window changes the meaning) and `salesByItem` (the matched block belongs to a
different query in the same function). Both are recorded rather than forced.

Assertions cover four families and check exact rows AND totals — for example the party analysis reports
`bills = 2, total = 600` inside the window against `bills = 4` without it, so the filter is proven to be what
narrowed the result.

Two fixture facts worth recording, both found by the tests failing: `purchaseReturnRegister` reads `PR_DATA`
(not a `PR_DETL_RTN`) and requires a `BOOK_DATA` row with `BOOK_TBL_NAME='PR_DATA'` and `BOOK_NAME ILIKE
'%return%'`; `contraRegister` needs its own `BOOK_DATA` row matching `%contra%`. A report returning zero rows
in a test is as often a missing prerequisite as a broken query.

## 4d. Money/metal settlement engine — BUILT 2026-07-30 (not yet wired to forms)

A jewellery voucher settles in two currencies at once, rupees and fine metal, and the operator fills in
whichever side they know while the form derives the rest. That fill-in-the-blank behaviour was absent from
tour sale, wholesale sale, bullion sale and labour sale, so a party balance could not be closed in rupees and
gold together.

`apps/api/src/modules/sales/settlement.ts` ports the desktop's `BILL_TOTAL` conversion block
(`TR_TOUR_SALE.cs:12999-13130`; the same block appears at `TR_WH_SALE.cs:15372-15419` and
`TR_BUL_SALE.cs:10518-10565`, which is why it is one engine rather than four copies).

Four ordered rules, each filling **only** a field the operator left at zero:
1. explicit rate — `Math.Round(convRate / convPct * 100, 2)`, or `convRate` alone;
2. rate back-calculated from a money/metal pair — `amount * F / fine` at 3 dp;
3. money from metal — `Math.Round(fine * (rate / F), 0)`, whole rupees;
4. metal from money — `amount * F / rate` at 3 dp.

`F` is the rate basis from `MsRatePar` (`CO_SET.RATE_PAR`, `MS_OPNCOMP.cs:672`, default `G`): `T` = per 10 g
-> 10, `K` = per kg -> 1000, else 1. **The direction differs between rules**: deriving money DIVIDES the rate
by `F`, deriving metal MULTIPLIES the amount by `F`. Inverting that fails 3 vectors.

**Rounding is deliberately not uniform.** The explicit rate and every money figure use `Math.Round`, which is
.NET banker's rounding; every rate back-calculation and every fine figure uses `Strings.Format(x, "0.000")`,
which is half-away-from-zero with no `Math.Round` at all. Using one mode throughout disagrees with the desktop
at exact midpoints — swapping money to half-up fails a vector.

20 golden vectors, ids `GV-SETTLE-*`, each citing the desktop line it encodes. Three inverted controls proven:
factor direction (3 failures), money rounding mode (1), and the never-overwrite guard (2).

`MsRatePar` is loaded server-side via `resolveSettingsBehaviorTx().rateBasis` and is never accepted from a
request body. A database round-trip test covers `T`/`K`/`G`, an unrecognised code, and null. Worth recording:
`CO_SET.RATE_PAR` is `varchar(1)`, so the schema itself enforces the desktop's own first-character
truncation — a multi-character value cannot be stored at all.

### Wired into rate cut, and a defect found while wiring

`postRateCut` now resolves the basis server-side and persists the derived settlement to
`RATE_CUT_DATA.DR_AMT` / `CR_AMT` / `CONV_RATE` / `CONV_PRC`, which the schema already had.

**Defect found and fixed: `RATE_CUT_DATA.RATE_PAR` was hardcoded to `'G'`.** The desktop sets `CurRatePar`
from `MsRatePar` for a new voucher (`TR_WH_SALE.cs:12086-12099`) and writes it at `:12974`; on edit it is
read back from the stored row (`:12215`). So a constant `'G'` mislabels every voucher at a shop quoting rates
per 10 grams or per kilogram, and because the value is read back on reopen the error propagates rather than
staying cosmetic. Now written from `resolveSettingsBehaviorTx().rateBasis` and pinned by a parameterised test
over `G`/`T`/`K`; restoring the constant fails with `expected 'G' to be 'T'`.

An ordinary rate-cut voucher is provably unchanged: with no conversion supplied the settlement columns stay
zero and `CONV_RATE` stays null.

**Still not wired into tour sale, wholesale sale, bullion sale or labour sale.** Each needs its own payload,
write set and UI panel, and the plan's four-places rule applies per form. Not claimed as done.

## 4e. Tag image subsystem — BUILT 2026-07-30

24 desktop forms expose attach / capture / replace / delete / enlarge on a photograph (`BtnImgS`, `BtnImgC`,
`BtnImgD`: 17 `TR_*`, 5 `MS_*`, 2 `RP_*`) and the web had none outside the repair workflow.

**Storage decision.** The desktop keeps bytes on a Windows file share and uses `TAG_IMAGE_DATA` purely as an
index — that table has `TAG_NO`, `VCH_SRNO`, `IMAGE_TYPE` and **no byte column**. A multi-tenant server cannot
depend on a shop's file share, and this codebase already had a proven pattern: the repair workflow stores
bytes in a tenant-scoped `bytea` column (`REP_IMAGE`) with MIME type and size beside them. `TAG_IMAGE_BLOB`
mirrors it; `TAG_IMAGE_DATA` is left untouched and kept in step so desktop-shaped reads still resolve.

**Two schema facts corrected my first design, both found by the tests failing:**
* `TAG_IMAGE_DATA.IMAGE_TYPE` is `varchar(1)` and the desktop's own DDL declares
  `IMAGE_TYPE VARCHAR(1) DEFAULT 'T'` (`MS_UPDATE.cs:8995`), with `'D'` for a design image
  (`TR_APR_ISU.cs:7050`). Codes are single characters — storing `'TagImage'` fails the insert outright rather
  than truncating.
* `TAG_IMAGE_DATA`'s primary key is `(tenant_id, CO_CODE, LC_CODE, TAG_NO, VCH_SRNO)` and **excludes**
  `IMAGE_TYPE`. So a tag instance holds ONE image with the type as an attribute. My first blob table keyed on
  the type as well, which would have let it hold rows the desktop index cannot represent; the identity now
  matches exactly.

**Security.** The declared MIME type is never trusted — magic bytes decide, and a declaration that disagrees
with the content is refused, because the stored type is served back to browsers later. A PDF header, an SVG
payload and bare text are all rejected. Both protections are proven by inverted controls.

**A live-verification bug fixed.** The spoofed-MIME rejection returned **500** because `TagImageError` was
not in the route error whitelist, so a client mistake looked like a server fault. `TagImageError` and
`RepairError` are now classified as 400; verified live returning
`{"error":"TagImageError","message":"tag image content is image/jpeg but was declared image/png"}`.

Endpoints (all under the existing `Inventory/Tag Print` right, since the right that shows a tag governs its
photograph): `GET/POST/DELETE /stock/tag-image` and `GET /stock/tag-image/list`. Route count 374 -> 378.

### Surfaced: `TagImagePanel` + first form wired

`apps/web/components/TagImagePanel.tsx` provides Select / Camera / Delete / click-to-enlarge, keyed on the
tag instance `(TAG_NO, VCH_SRNO)` — the identity the desktop uses and the one `TAG_IMAGE_DATA` is keyed on.
The image is fetched as a **blob URL** rather than base64 so a large photo never sits in React state, and the
URL is revoked on change so moving between grid rows does not leak object URLs.

Mounted on **tag opening**, following the focused grid row exactly as the desktop's buttons act on the current
row (`TR_TAG_OPBL.cs:11941-12190`). Browser-verified: the panel follows the focused tag, reports
"No image for this tag", keeps Delete inert with no image, and the camera never claims to be live without a
granted device.

**A robustness gap the smoke test exposed.** The panel treated any non-404 OK response as an image. The smoke
harness mocks unmatched routes with `200 []`, which produced a zero-byte "image": a broken thumbnail with
Delete enabled for something that does not exist. The panel now requires `blob.size > 0` and an
`image/*` content type, and the mock answers 404 for a tag with no photograph, which is what the real route
returns. Trusting the status code alone was the actual bug; the mock was merely what revealed it.

### All wirable forms done — 22 of 24

**The store had to be generalised first.** The 24 forms do NOT all photograph a tag: `MS_ACCT` stores a party
photo, `MS_MEMB` a member photo, `MS_PRODUCT` scheme artwork, `MS_DESIGN_BOOK` a design. Keying everything on
`TAG_NO` would have been wrong for a third of them, so `TAG_IMAGE_BLOB` became `ENTITY_IMAGE` with identity
`(ENTITY_TYPE, ENTITY_KEY, INSTANCE)` — `TAG`, `AC`, `MEMB`, `SCHM`, `DESIGN`, `ITEM`. Only the `TAG` entity is
mirrored into `TAG_IMAGE_DATA`, whose primary key has no room for another entity kind; a test asserts a party
photo does **not** appear there.

Identity per form was read from what each page actually captures, not assumed:

| entity | forms | web surface |
|---|---|---|
| `TAG` | TR_TAG_OPBL, TR_APR_ISU, TR_TOUR_ORD, TR_PURC, TR_PHYSTK, TR_JDT_REC, TR_MFG_KR_ISU_REC, RP_TAG_IMAGE, RP_TAG_ESTMATE | tag-opening, tour, tour-return, purchase, purchase-return, physical-stock, KarigarForm (4 pages), reports/tag-stock |
| `DESIGN` | TR_ITM_LOT, TR_MFG_ORD_ISU, TR_SALE_ORD, MS_DESIGN_BOOK | item-lot, mfg-order-issue, sales-order, masters |
| `ITEM` | TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_ORD_REC, TR_MFG_WITH_LOT | mfg-issue, mfg-receive |
| `AC` | TR_DHRN_ISU, MS_ACCT | dhrn-issue, order-cancel, masters |
| `MEMB` | MS_MEMB | membership |
| `SCHM` | MS_PRODUCT | masters |
| repair | TR_REP_REC | already had `RepairImagePanel` |

19 web surfaces mount a panel; browser-verified 17/17 rendering with no page errors. `KarigarForm` covers four
pages in one mount and the generic master page covers six master routes.

**The two not wired, and why neither is panel work:**
* `MS_UPDATE` — its image buttons **initialise the image database** (`MS_UPDATE.cs:8825-9056`), a repair-console
  operation, not a per-record photograph.
* `TR_PR_SL_UAE` — the waived UAE variant has no web route at all.

**Pages where the desktop images a record the web page does not yet capture** are wired to the identity the
page does have (e.g. `mfg-issue` keys on the item, not a tag) rather than left unwired. Where the desktop keys
on something finer, that is a missing FIELD, recorded separately from the image surface.

One scripted-edit failure worth recording: inserting the import via a regex that matched a multi-line
`import {` landed the statement inside the braces and broke `purchase/page.tsx`. TypeScript caught it
immediately; the fix was to anchor on the LAST complete top-level import instead.

## 4f. Bill profit — ENGINE BUILT 2026-07-30

`apps/api/src/modules/sales/billProfit.ts`. Four desktop forms show the margin on the voucher being written
(`TR_SALE`, `TR_SALE_LBR`, `TR_TOUR_SALE`, `TR_WH_SALE`) and the web had none.

**Per-line cost has three branches, taken in order** (`TR_SALE.cs:17009-17045`). The grid columns were
resolved from the load/write path, not assumed: 30 = `ITM_MRP`, 38 = `TAG_COST`, 48 = `KR_FINE`,
14 = `ITM_NWT`, 22 = `ITM_RATE`, 35 = `TOT_AMT`, 37 = `NET_AMT`, 1 = `TAG_NO`.

1. **MRP line** (`ITM_MRP <> 0`): `profit = NET_AMT − TAG_COST`. The tag carries its own cost.
2. **Tagged line with karigar fine**: `cost = round(KR_FINE × saleRate + TAG_COST, 2)`,
   `profit = TOT_AMT − cost`. Requires **both** a non-zero fine and a non-blank `TAG_NO` — the desktop tests
   both, and dropping the tag condition fails a vector.
3. **Otherwise** derive from the item's average touch: `fine = round(ITM_NWT × AVG_TOUCH / 100, 3)`,
   `cost = round(fine × saleRate, 2)`.

**The most important behaviour is the fourth case: no cost basis means NO profit.** With no MRP, no fine and
no non-zero `AVG_TOUCH` the desktop shows nothing. Reporting `TOT_AMT` as profit would present an unknown
cost as pure margin — the dangerous failure here — so a control that does exactly that fails two vectors.
Branch order is pinned too: reordering fails four.

Note branch 1 uses `NET_AMT` while 2 and 3 use `TOT_AMT`. Both hold the same tax-exclusive whole-rupee figure
in this codebase, but the distinction is preserved because the desktop makes it.

13 golden vectors, ids `GV-PROFIT-*`. Three inverted controls proven.

### Waived: two licence-gated behaviours

`SSRegSrNo == 'KJ001NEKJ'` replaces the sale rate with `ITM_RATE × 100 / GROUP_MAST.GR_TOUCH`
(`:17011-17018`) and adjusts the voucher total by a further term (`:19400-19409`). Both need the licence
serial to reproduce; inventing the condition would change every margin at shops that do not hold it.
**Revocation condition:** supply the registration serial set and the intended semantics.

Visibility is a company setting rather than a serial: the desktop shows the figure when the software edition
is 'E' or `MsBillProfit` (`CO_SET_NEW.BILL_PROFIT`) is 'Y' (`:19392`). The web gates on that setting, which is
now reachable in the settings screen — so this feature became implementable *because* §2 closed.

### Wired into the sale, with both cost inputs read server-side

`createSale` now returns `billProfit` when the company setting is on. Both inputs come from the database, never
from the request — a client-supplied cost would let the caller dictate the margin.

**`ToDaySlRate` is not a raw rate**, and this is the detail most easily got wrong:

    SELECT TOP(1) FINE_GL_RATE, FINE_SL_RATE, VCH_DATE FROM RATE_MAST
     WHERE CO_CODE=? AND LC_CODE=? AND VCH_DATE <= <voucher date> AND SR_NO = 1
     ORDER BY VCH_DATE DESC
    ToDaySlRate = Format(FINE_SL_RATE / 103.0 * 100.0 / 1000.0, "0.00")

* it uses `FINE_SL_RATE` even though the query also selects `FINE_GL_RATE` — using the gold rate gives 970.87
  instead of 7000;
* `/ 103 × 100` **strips a 3% loading**, so costing uses the EX-TAX rate. Keeping the loading yields 7210
  against 7000 and understates every margin by ~3%;
* `/ 1000` converts a per-kilogram quote to per gram;
* `SR_NO = 1` and the newest date **not after** the voucher date, so a back-dated voucher is costed at the
  rate that applied then.

All four pinned by inverted controls. `BILL_PROFIT` is read from `CO_SET_NEW` directly rather than through
`resolveSettingsBehaviorTx`, which covers `CO_SET` and fails closed on a strict one-row rule — a company with
no `CO_SET_NEW` row should simply not show a margin, not break its sale. Default is OFF.

**Still not surfaced on tour sale, wholesale sale or labour sale**, nor rendered in the sales UI.

## 6. Test-infrastructure defects fixed 2026-07-30

Two intermittent failures were diagnosed rather than tolerated, because a flaky gate is not a gate.

**Unbounded DB-test parallelism.** `apps/api` had **no vitest config**, so the default one-worker-per-CPU
file parallelism ran ~112 files — around half of them database tests, each constructing its own
`PrismaClient` — against one PostgreSQL instance with `max_connections = 100`. The signature was failures
that MOVED between files run to run (`settingsBehavior.db` on one pass, `salesFamilyLifecycle.db` the next),
which is contention rather than logic. `maxThreads: 4` gives three consecutive clean 830-test runs where the
unbounded run failed 1-2. A shared database is a genuine serialisation point, so bounding the pool is the fix,
not a way of hiding flakiness — every DB test remains tenant-isolated under forced RLS and no assertion was
weakened.

**A racy browser assertion.** `assert.equal(await getByLabel('Configured book').inputValue(), 'TOP')` read the
value immediately after the heading appeared, but `BookSelect` fills itself from `/context/books` after mount.
Intermittent `actual: '' expected: 'TOP'`. Replaced with a polled `expectValue` helper that asserts the same
thing without depending on timing; three consecutive runs clean.

Also recurring and worth noting: **stale `next-server` processes** (including one on a different Next version)
hold the build directory while `build --force` rewrites it, which produced an earlier smoke crash with no
assertion message. Killing strays before a build run is now part of the sequence.

## 5. Form-level register — 162 evidence-cited gaps

Produced by three independent audits, each required to cite `file:line` it actually read and to grep the web
for the *concept* before declaring absence. Spot-verified by me (see §6).

* **Masters / management — 48** (35 absent, 13 partial)
* **Reports / utilities — 50**
* **Transactions — 64**

### The two largest structural holes

**`MS_UPDATE` — the data-repair console. PARTIALLY CLOSED 2026-07-30.**

A preview-then-apply framework now exists (`apps/api/src/modules/utilities/dataRepair.ts`) with the run
ledger `data_repair_run`, and **5 of the 13 data-repair operations** are implemented and tested:
`karigar-fine`, `active-stock-type`, `approval-reconcile`, `sale-tag-weight`, `opening-balance`.

`opening-balance` (`MS_UPDATE.cs:32662-32695`) is the financially significant one and is `high` risk with a
typed confirmation, because the desktop's own prompt warns the previous opening cannot be recovered. Two
details are pinned by inverted controls: the ledger window is **strictly before** the fiscal opening date —
making it inclusive folds first-day trading into the opening balance (`expected 13999 to be close to 4000`)
— and the sign rule is `> 0 ? 'C' : 'D'`, so a **zero** balance is stored `'D'`.

**A test-quality finding worth recording.** The sign control initially did NOT fail when inverted to
`>= 0`, which proved the test never exercised zero. Adding a diamond-only party (the desktop's `HAVING`
counts a diamond term the `SELECT` never returns, so such a row exists with all magnitudes zero) made the
control fail correctly with `expected 'C' to be 'D'`. Without running the control the coverage claim would
have been false.

The safety protocol is deliberately stronger than the desktop's, which runs each repair immediately on a
button press with no preview and no record:

* preview computes an exact per-table insert/update/delete diff and is proven read-only by a test that
  compares every row before and after;
* apply re-derives the candidate set under a per-tenant advisory lock inside one transaction and refuses
  if the recomputed `previewHash` no longer matches what the operator reviewed;
* only the diff is applied, so a healthy row is never rewritten and a second run is a provable no-op;
* the run ledger is append-only — `UPDATE` of a terminal run is always refused and `DELETE` needs an
  explicit `app.allow_repair_purge` opt-in that exists only for retention;
* a replayed apply resolves to the run that already happened instead of repeating the work.

Formula fidelity is pinned, not assumed: `karigar-fine` writes
`round(KR_NET_WT × (KR_TOUCH + KR_WEST_PRC) / 100, 3)` per `MS_UPDATE.cs:32561-32596`, and dropping the
`/100` fails the test. `active-stock-type` reproduces the desktop's unusual
`SUM(CASE WHEN ITM_SIGN='+' THEN VCH_SRNO ELSE -VCH_SRNO END) > 0` presence test verbatim
(`MS_UPDATE.cs:33043-33074`) — summing a *serial number* is odd, but it is what the shop's existing data was
produced by, so "correcting" it to sum pieces would mark a different set of tags active.

### `SRNO_MAST` — a genuine desktop/web divergence, deliberately not implemented

`BtnCounter` (`MS_UPDATE.cs:32465-32495`) backfills `SRNO_MAST` **one row per tag**, filtering existing rows
by `TAG_NO` and inserting where absent. The web schema treats the same table as a **numbering counter**:
`uq_srno_mast_tenant_company_location` is unique on `(tenant_id, CO_CODE, LC_CODE)` and `seedCompany`
provisions exactly one row per company/location with `VCH_SRNO = 0, TAG_SRNO = 0`.

The two meanings are incompatible — a per-tag insert violates the constraint, and relaxing the constraint
would permit a second counter row and hand out duplicate voucher numbers. Which semantics the web should keep
is a product decision, so the operation is absent rather than implemented against a guess. **To resolve:**
either formally waive it (if `SRNO_MAST` is the counter) or give the counter its own table via migration
(if it is a tag registry).

**Still absent: 8 further data repairs** (`btnAc` ledger rebuild, `btnStock`, `btnProblemQry` duplicate-tag repair,
`btnTagDiffSet` serial backfill, `btnTagStkDelete` destructive convert, `BtnCounter`, `btnBarIdtl`,
`BtnMfg`, `BtnOpbal`) **and 6 schema-init operations** (`btnFildUpdate`, `btnFildUpdate2`, `BtnImgData`,
`BtnCrmData`, `btnSchmData`), the last group being SQL-Server DDL that becomes migrations plus readiness
checks under the plan's behavioural-adaptation decision.

### Original finding (retained for the record)

**`MS_UPDATE` — the data-repair console (16 operations, essentially all absent).** The desktop can rebuild
ledgers and tax/loan/scheme postings, reconcile approvals against returns, repair duplicate
`(tag, voucher-serial)` identities, backfill missing tag serials, recompute karigar fine across history,
rebuild opening balances from ledger movement, and strip orphan tag references. The web's Data Refresh
performs **no write-back recompute**. When data drifts, there is no in-product repair path.

**`UT_IMPORT` — legacy migration (11 families, all absent).** Wholesale/retail/Lite MDB installations,
wholesale/Plus/Chudi SQL installations, pledge and loan history, approvals, account masters and openings,
HUID and tag subdetail, loyalty/scheme history, repair and manufacturing history, bill-wise outstanding.
**An existing shop cannot migrate itself onto the web product.**

### Recurring transaction-form patterns

* **Dual money+metal settlement** (DR/CR amount ↔ fine at rate) absent on tour sale, wholesale sale,
  bullion sale, labour sale.
* **Silver-cut settlement** — *exists in the platform* (`rateCut.ts`, purchase) but **not wired** to the tour
  or wholesale-sale pages (0 references on each).
* **Fine interest by elapsed days** (`nIntPrc`, `TR_WH_SALE.cs:14735`) — absent everywhere.
* **Search/reopen an existing voucher** absent on tour sale and wholesale sale (create-only screens).
* **Per-voucher print/send variants** (WhatsApp, HUID-only, with-image, without-commission) — services exist,
  but no per-voucher control on the transaction pages.
* **Loyalty inside the sale** — a separate screen can earn/redeem, but the sale itself stores only a scalar
  `pointValue` and posts no earn/redeem/referral.

---

## 6. Verification performed on the delegated findings

I did not accept the sub-audits on trust. Independently confirmed: `nBillProfit` (20 hits in `TR_SALE.cs`,
4 forms, 0 web); `nLableSkip` (12 forms, 0 web); no `/admin/users` DELETE; `INPUT_TAX_AC` absent; Olocker
absent; `tTrfrNo` real at the cited line; master search genuinely absent.

**Two claims I corrected.** Silver settlement and fine-interest were reported as flatly "absent"; the web
actually contains 49 `silverCut`/`silverFine` references. Checking file-by-file showed the capability exists
in `rateCut.ts`/purchase but is **not wired to the tour and wholesale-sale pages** (0 references each). That
distinction matters for effort: wiring an existing engine is far cheaper than building one. `fineInterest`
is genuinely absent.

---

## 7. Honest bottom line

Depth of what **is** built is high and independently gated — 98.9% persisted-column coverage, 700 tests,
the desktop's own rounding and settlement formulas reproduced (including four real persisted-value defects
found and fixed). Nothing in this register contradicts that.

What this register shows is different: **breadth of surface**. Roughly a third of the desktop's interactive
controls have no web counterpart, three quarters of the settings cannot be changed by the owner, and two
whole utility consoles (data repair, legacy migration) are absent. The prior "100% capturability" gate hid
this by measuring the web against itself.

**Not claimed anywhere here:** that any listed item is trivial, that the counts are exact, or that presence
of a control implies behavioural parity. Counts are lower bounds on the gap.


## 7. Data-repair console: 9 of 13 operations (2026-07-30)

Added `stock-fine-refresh`, `bar-idtl-serial` and `duplicate-cancelled-tag`. Live-verified the full
destructive workflow: preview promised `BAR_DETL delete 2, BAR_CAN_DETL delete 1`; apply was refused with no
confirmation AND with a wrong confirmation (both 400); the correct typed confirmation applied exactly the
promised counts; the second preview returned `[]`.

**A divergence the tests caught.** `bar-idtl-serial` was first written to update rows whose `SR_NO` differed
from the target. But the desktop writes `SET SR_NO = num2, OLD_SRNO = num2` for **every** row in the
selection, so a row whose `SR_NO` is already correct but whose `OLD_SRNO` is stale or null must still be
repaired. Comparing only `SR_NO` left `OLD_SRNO` behind; the control now fails `expected 3 to be 4`.

**Faithful oddities reproduced, not tidied:**
* `stock-fine-refresh`: the candidate query already filters `ITM_FINE <= 0`, making the desktop's inner
  `if (ITM_FINE <= 0)` always true. More importantly the `SL_DETL_RTN` update sits **outside** that `if` and
  matches on tag and serial **alone** — a return line already carrying a good fine **is** overwritten from
  the tag's recomputation. Pinned by a test that seeds a return with fine 5.5 and asserts it becomes 9.000.
  The return rows are therefore updated **first** in the web implementation: repairing `BAR_DETL` first would
  empty the candidate set and silently skip them.
* `duplicate-cancelled-tag`: the desktop's grouping query is scoped by company and location **only** — no
  `CO_YEAR`, unlike its neighbours. Adding a year predicate makes prior-year candidates vanish
  (`expected undefined to be 2`). The DELETE also matches the **cancelled gross weight**, so a tag duplicated
  at two weights keeps the one that was never cancelled; deleting the whole group fails the control.
* `bar-idtl-serial`: `VCH_NO` is a **text** column, so `ORDER BY VCH_NO` is lexicographic while the desktop's
  voucher-change test compares the **numeric** value. Both kept exactly as they are. `OLD_SRNO` is
  overwritten with the new serial, so the prior numbering is **not** recoverable — hence `high` risk.

A registry-wide guard now asserts that every operation whose id/title/description implies deletion is `high`
risk and demands a typed confirmation, so a future destructive op cannot be added as low risk.

**Outstanding: 4 repairs** (`btnAc` ledger rebuild, `btnStock`'s TAG_SRNO/random-tag portion, `btnTagDiffSet`
five-table serial backfill, `btnTagStkDelete` destructive convert, `BtnMfg` needing 22 `Ac_Tax.*_Mfg`
routines) plus the 6 schema-init operations.


## 8. Report families: RP_TAG_ESTMATE and RP_ORDER built; the last two Ctrl chords now mapped

`apps/api/src/modules/reports/orderTagReports.ts`. These two were chosen first because their absence was
load-bearing: `Ctrl+F2` and `Ctrl+F12` were deliberately left UNMAPPED, and `UNMAPPED_CHORDS` in
`formKeys.test.ts` is now **empty** — every Ctrl chord the desktop binds has a real destination. Browser
smoke asserts both navigate.

**Tag estimate** (`RP_TAG_ESTMATE.cs`) has an In/Out source switch that is not the same columns from a
different table:

* `In` reads `BAR_DETL`.
* `Out` reads `MAIN_STOCK` LEFT JOINed back to `BAR_DETL`, taking pieces and weights from **stock** but
  `DESIGN_NO`, `ITM_SIZE` and `KR_NAME` from the **tag ledger**, because `MAIN_STOCK` does not carry them.
  Reading them all from one side reports the wrong figures; a test seeds stock at 7.5 g against a tag at 10 g
  and asserts the weight is 7.5 while the design is the tag's.

Filters: `PR_CODE`, `GR_CODE`, `IT_TYPE`, `TAG_NO`, plus the date window on both inclusive boundaries.
`IT_TYPE` stores only `Strings.Mid(cboItemTyp.Text, 1, 1)` — the FIRST character of the label — so the route
slices the query value rather than passing a caption.

**Order zoom** (`RP_ORDER.cs`) unions a lot's two sides, and three asymmetries are real:

1. The `+` leg fills the issue weight columns and ZEROES the tag columns; the `-` leg does the reverse. One
   row therefore carries only one side, and the column pair is what says whether metal went out or came back.
2. The `-` leg's item code is **`TAG_IT_CODE`**, not `IT_CODE` — the item the tag became, which can differ
   from the item issued. Pinned by a fixture where they differ.
3. The `-` leg's `BOOK_DATA` join **omits `LC_CODE`**, joining on company and book only. Kept as written.

It is a **drill-down**: a blank lot returns nothing rather than unioning a whole year, which is not a view the
desktop offers. `totals.balanceNwt` (issued − returned) is added because that is the figure the drill-down
exists to answer and neither leg alone shows it.

**An export defect avoided.** Both were first registered in the XLSX registry with default filters, which
would have made every lot-zoom export **empty** — indistinguishable from "no data" rather than "no lot
given". The export route now reads the same query filters the screen sends and calls the same builder.

**Schema surprise:** `BAR_DETL.KR_NAME` is **`varchar(5)`** — it stores a karigar **code**, not a name,
despite what it is called. A descriptive fixture value failed with `22001`.

Live-verified: `In` returns the seeded tag with its design and karigar code, `Out` returns 5 stock rows
(the demo `BAR_DETL` is empty, which is why `In` is legitimately 0 without a seed), the tag filter narrows to
0, a lot-less zoom returns no rows, and the XLSX is `Microsoft Excel 2007+`.


## 9. Measurement correction: the audit was UNDER-reporting (68.5% -> 72.7%)

My own audit had a systematic false negative, and it is worth stating plainly because it is the mirror image
of the earlier "UI field capturability 100%" error. That one over-reported by dividing by the web's own
capability. This one **under-reported** by asking the wrong question.

The matcher asked only: *does this desktop control NAME appear anywhere in the web source?* Every data-driven
web surface fails that test by construction. `MS_GOLD_MAST` measured **41.2%** while all ten of its
operator-editable controls are in fact reachable — the web renders that master from column metadata, so the
string `_nGoldConv` appears nowhere even though `GOLD_CONV` is an editable field on the page.

**Verified against the desktop source before changing anything.** Every one of the ten resolves to a column
the web exposes:

    tContryCode -> COUNTRY_CODE        tBankCode       -> BANK_AC_CODE
    nOzConv     -> OUNCES_CONV         nGoldConv       -> GOLD_CONV
    nSilverConv -> SILVER_CONV         nGoldRate       -> GOLD_FIX_RATE
    nSilverRate -> SILVER_FIX_RATE     nCustBuyRateAdd -> CUST_BUY_RATE_ADD
    nCustSlRateLess -> CUST_SALE_RATE_LESS   chkGoldBookActiv -> SHOW_DG_GOLD

`feature_gap_audit.py` now resolves each control to the column it is assigned from or to, and counts the
control as present if that column is in the web source. **The denominator is unchanged** — still every
control the desktop declares. This fixes the numerator only.

Matcher validated both ways before use: all ten resolve to exactly ONE correct column each; three invented
control names resolve to no binding; no control in the form binds more than three columns, so the regex is
not over-capturing.

**A false-positive risk found and excluded rather than accepted.** Of 228 controls the new rule would flip to
present, 188 are backed by a column appearing in fewer than 20 web files (specific evidence) and **40 are
backed only by shared vocabulary**. The case that forced the split: `MS_AC_GROUP._tServerIp` binds
`MAIN_BOOK` — and the binding is CORRECT, the desktop really does load a server IP from a column named
`MAIN_BOOK` (`tServerIp.Text = Rows[0]["MAIN_BOOK"]`). But `MAIN_BOOK` appears throughout the web source for
its ordinary purpose of book identity, so counting it as coverage of a server-IP field would be a lie.

Those 40 are now reported per form as `weakColumnOnly` and **NOT counted as present**. So:

| Rule | Result |
|---|---|
| control name only (old, under-reports) | 3122 / 4555 = 68.5% |
| **name or SPECIFIC column (adopted)** | **3310 / 4555 = 72.7%** |
| name or any bound column (over-permissive) | 3350 / 4555 = 73.5% |

The honest figure is **72.7%, with the true value between 72.7% and 73.5%**. `MS_GOLD_MAST` is now 17/17 and
that is independently confirmed: `GET /masters/gold-rate/meta` returns 14 fields.

**Remaining real gaps, now that artifacts are removed** (largest absolute first): `RP_ALL` 21/91,
`UT_SETTING_MAIN` 55/113, `UT_WHATSAPP` 21/45, `UT_IMPORT` 13/42, `RP_OS` 22/43, `RP_TAG_IMAGE` 18/36,
`RP_TAG_ESTMATE` 16/34 (the report is built; the gap is its filter panel), `RP_CUST_CRM` 15/33,
`UT_SMS` 14/29, `UT_SET_ADMIN` 12/27, `RP_EMP` 12/24, `UT_AI_TRFR` 9/20, `RP_TRADING` 6/16.


## 10. The shared RP_ALL filter matrix

`apps/api/src/modules/reports/reportFilters.ts`. `RP_ALL` is not one report — it is a launcher with 72
buttons, each setting a Crystal record-selection formula over a different base table while reusing ONE filter
panel. Extracting all 53 formulas that name a `.RPT` file gave the complete dimension list with the exact
column each control drives and how widely it is used:

| Control | Column | Reports |
|---|---|---|
| `tBookCode` | `<data>.CO_BOOK` | 59 |
| `tAcCode` | `<data>.AC_CODE`, or `MEMB_CODE` on `AD_OS`/`AD_DATA` | 58 |
| `tLcCode` | `<data>.LC_CODE` | 58 |
| `cboCity` | `AC_MAST.AC_CITY`, or `AD_MEMB.AC_CITY` on schemes | 57 |
| `cboArea` | `AC_MAST.AC_AREA`, or `AD_MEMB.AC_AREA` on schemes | 57 |
| `tItCode` | **`ITEM_MAST.PR_CODE`** | 55 |
| `cboItemTyp` | `ITEM_MAST.IT_TYPE` (first character only) | 33 |
| `tGrCode` | `ITEM_MAST.GR_CODE`, or **`RATE_CUT_DATA.AC_ANGDIYA`** | 30 |
| `cboState` | `AC_MAST.AC_STATE` | 15 |
| `cboEmploy` | `<data>.EMP_CODE` | 11 |
| `tCustName` | `SL_ORD_DATA.AC_NAME` | 8 |

**Two control names are actively misleading** and both are pinned by inverted controls:

* `tItCode` drives `PR_CODE` — the **product** code, not the item code. Binding it to `IT_CODE` filters the
  wrong column on 30 reports.
* `tGrCode` drives `GR_CODE` on most reports but `AC_ANGDIYA` on the rate-cut family — one control, two
  dimensions. Unifying them would filter the wrong column on seven reports.

**Unsupported filters are REFUSED, not dropped.** A report without an `ITEM_MAST` join genuinely cannot filter
by group. The desktop avoids the problem by not showing the control on that button; the web serves many
reports from one screen, so silently ignoring a filter would show the operator a wider result set as if it
were filtered — the worst possible outcome. `GET /reports/:report/filters` returns the honoured dimensions and
the screen renders only those; an unsupported one returns **400** with the dimension named.

**A shadowing bug caught by live verification.** The book filter was first called `coBook`, which is already
the session scope parameter — so `?coBook=301` was rejected with `book-unavailable` by book-access validation
before the report ran. Renamed to `bookCode`, matching the desktop's `tBookCode`. Live: `bookCode=SL` returns
5 rows, `bookCode=999` returns 0, `itType=Zebra` truncates to `Z` and returns 0, `state=GJ` returns 400.

Blank means **all**, not "match empty" — the desktop appends each predicate only when its control is
non-blank, and a control proving otherwise fails.

Wired into `tag-estimate` first (7 of 11 dimensions; it joins `ITEM_MAST` and the voucher table but not
`AC_MAST`, so area/city/state are honestly reported as unsupported). Remaining builders are a per-report
binding registration, not new logic.


## 11. Filters actually applied, and two defects the work exposed

The matrix from section 10 generated SQL; this made reports apply it. Five reports are bound and **each is
proven to narrow real rows** — `stock-valuation`, `item-group-stock`, `purchase-by-party`,
`sales-return-register`, `tag-estimate`.

**Bindings were verified by READING each builder's SQL, not by scanning for `FROM "T" alias`.** The scan was
wrong three ways, and each would have shipped a broken or silently wrong filter:

* `billOutstanding` and `cashBook` reference `AC_MAST m` inside a **correlated subquery**, so `m` is not in the
  outer `WHERE` scope and a party predicate on it does not compile. They are therefore NOT bound.
* `purchaseByParty` resolves to `reports3.ts`, whose `FROM "PR_DATA"` is **unaliased** — a second function of
  the same name in `reports10.ts` IS aliased `pd` and is not the one registered. Binding `pd` fails with
  `missing FROM-clause entry for table "pd"`, which the control reproduces.
* `dataColumns` differs per table, verified against `information_schema`: `AC_DATA` and `BAR_DETL` have no
  `EMP_CODE`, `RATE_MAST` has no `AC_CODE`. Omitting that declaration makes the query **crash**
  (`column b.EMP_CODE does not exist`) rather than misfilter — the control proves it.

`REPORT_FILTER_BINDINGS` is now the single source of truth read by both the builders and
`GET /reports/:report/filters`, so the advertised capability and the applied predicate cannot drift. A test
asserts every registered binding is exercised, so one cannot be added without being proven.

### Defect: unbound reports were silently dropping filters

Live verification found `GET /reports/day-book?city=Surat` returning **200 with an unfiltered result set**.
Only the five bound builders called `applyFilters`; the other 37 ignored filters entirely. An operator would
have read a whole-year day book as though it were narrowed to one city — exactly the failure the
"refuse, never drop" design exists to prevent.

Fixed with a **global `preHandler` on every `/reports/*` route** rather than per builder, so coverage does not
depend on a builder remembering to opt in. It names every offending dimension, strips `.csv`/`.xlsx`/`.pdf`
suffixes so an export cannot bypass it, and treats blank as absent. Now 400 for both an unbound report and an
unsupported dimension on a bound one.

### Defect: every unknown path returned 500 instead of 404

Found while testing the guard. The auth `preHandler` runs for unmatched requests, found no
`authorizationPolicy`, and returned `500 route-policy-missing` — so `/totally/unknown` looked like a server
fault. In production that would make ordinary 404 noise indistinguishable from real 500s in alerting.

An unmatched request has no `routeOptions.url`, so that case now returns `404 not-found`. A route that IS
registered but carries no policy still returns a hard 500: that fail-closed behaviour is what forces every new
route into `routePolicy.ts` and was deliberately not softened.

### Browser smoke: the race was a class, not an instance

The polled `expectValue` helper had been applied to one assertion. Another failed later with
`actual: '' expected: 'IOP'`. All **five** immediate `inputValue()` assertions are now polled; the
`isChecked()` assertion is left alone because the test clicks that checkbox itself and it is deterministic.
Four consecutive clean runs.


## 12. RATE_PAR: two more instances of the same defect, and one that was already correct

Auditing every web write of `RATE_PAR` found three more hardcoded `'G'` literals. Checking each against the
desktop showed **two were defects and one was faithful** — a uniform "fix" would have introduced a divergence.

| Web write | Desktop | Verdict |
|---|---|---|
| `wholesaleSaleReturn.ts` | `TR_WH_SALE_RTN.cs:6604-6612` sets `CurRatePar` from `MsRatePar`, `:6787` reads it back | **defect, fixed** |
| `bullion/fineSalePurchase.ts` | `TR_FINE_SL_PR.cs:3955-3963` sets it from `MsRatePar`, `:4288` reads it back | **defect, fixed** |
| `vpParcel.ts` | `TR_VP.cs:5628` writes the literal `"G"` and never references `MsRatePar` at all | **correct as-is** |

**The wholesale case was worse than it looked.** That module inserts into `RATE_CUT_DATA` — the SAME table
`rateCut.ts` writes. So one table carried inconsistent rate bases depending on which form created the voucher:
rate cut derived it from the setting, the return path hardcoded `'G'`. Control fails `expected 'G' to be 'T'`.

**Settlement is deliberately NOT wired into the wholesale sale return.** `TR_WH_SALE_RTN` writes `DR_AMT`,
`CR_AMT`, `DR_FINE`, `CR_FINE`, `CONV_RATE` and `CONV_PRC` as **literal zeros** and derives no money/metal
settlement, unlike its sibling rate-cut form. The test asserts all six stay zero, so a future change cannot
quietly start settling there.

**Schema surprise:** on `RATE_CUT_DATA`, `CONV_RATE` and `CONV_PRC` are **varchar** while `DR_AMT`, `CR_AMT`,
`DR_FINE`, `CR_FINE` and `FINE_RATE` are numeric — they cannot share a `coalesce` (`42804`).

The remaining settlement targets (`TR_TOUR_SALE`, `TR_BUL_SALE`) are **builds, not wiring**: `/txn/tour` is
approval issue and `/txn/bullion` is booking, so neither is the corresponding desktop sale form.


## 13. Data repair 10 of 13, and what `btnAc` really does

`ledger-normalise` ports the portion of `btnAc` that precedes `AcRefresh()` (`MS_UPDATE.cs:2334-2350`):
normalise a blank book `DATA_TYPE` to `'A'` on `BOOK_DATA`/`BOOK_DETL`, default an uncleared
`CASH_DATA.CLR_DATE` to its voucher date, and rebuild `BANK_RECONCILE` from the ledger for account groups
`02`, `22`, `23`.

**What is deliberately excluded, and why.** `btnAc` then calls `AcRefresh()`, which **deletes the entire
general ledger** — all `AC_DATA` except books `888`/`000`, plus all of `ROJ_MEL_DATA`, `TAX_DATA` and
`DHRN_DATA` — and re-derives it by looping over every configured book. Shipping a partial version would be the
worst possible outcome: the ledger deleted and only partly restored, unrecoverably. It needs the complete
per-book posting engine plus the danger-zone protocol (feature flag, verified backup, dual approval) and
remains outstanding. The four statements implemented stand alone and are idempotent.

**One necessary divergence.** The desktop's `DELETE FROM BANK_RECONCILE` carries **no scope whatsoever** — it
wipes every company's and location's rows before reinserting only the current company's. On a shared server
that is cross-company data loss, so the web scopes it to tenant, company and location. A test seeds another
company's row and asserts it survives; unscoping it fails with `expected [] to deeply equal ['OTHERCO']`.

**A real code bug found by the tests.** The shared `scoped()` helper always emitted `CO_YEAR`, but verified
against `information_schema`: `BOOK_DATA`, `BOOK_DETL` and `BANK_RECONCILE` have **no year column** while
`AC_DATA` and `CASH_DATA` do. It failed with `column t.CO_YEAR does not exist`. The helper now takes an
explicit `{ year: false }` option so the assumption cannot be made silently. `AC_DATA` also has **no `SR_NO`**.

Live-verified on real data: the preview found **15 demo books with a blank `DATA_TYPE`**, apply updated exactly
15, the second preview returned `[]`, and a direct query confirms none remain.

Three controls proven: unscoping the reconciliation delete, widening the account groups to include sales, and
dropping the `CLR_DATE IS NULL` guard so an already-cleared date is overwritten. A fourth attempt was rejected
as **invalid** — a backtick inside the shell string broke the edit, so it "passed" against unmodified code and
was redone with a heredoc.

**Outstanding repairs: 3** (`AcRefresh` full ledger rebuild, `btnTagDiffSet` five-table serial backfill,
`btnTagStkDelete` destructive convert) plus the 6 schema-init operations and `BtnMfg`'s 22 `Ac_Tax.*_Mfg`
routines.


## 14. Data repair 11 of 13 — tag serial backfill

`tag-serial-backfill` (`MS_UPDATE.cs:32333-32422`, `btnTagDiffSet`) restores the tag instance number
(`VCH_SRNO`) on SOLD stock rows that lost it, so a tag can be traced back to the ledger row it came from.

Four properties that would each be wrong if the logic were tidied, all pinned by inverted controls:

* **Outward only.** The candidate set is `ITM_SIGN = '-'`. Including inward rows repairs a tag-opening row
  that should keep its zero (`expected 3 to be 2`).
* **Tag AND gross weight.** The primary match carries the weight, and all five updates also carry
  `BOOK_NAME`, so a tag reused at another weight keeps its own serial.
* **The fallback is a different rule, not a looser one.** When the weight does not match, the desktop matches
  the tag alone, updates **only `MAIN_STOCK`**, and drops the weight from the update — deliberately leaving
  the sale, cancellation, rate-cut and labour rows untouched. Letting the fallback propagate fails
  `the fallback must NOT touch the sale row: expected 3 to be +0`.
* **The dedupe deletes only `BOOK_NAME = 'TAG CANCEL'`.** This is the most dangerous one: removing that
  restriction makes the repair **delete a real sale**, and the control proves it —
  `expected [] to deeply equal ['SALE']`.

The desktop reads `Rows[0]` from an unordered result; `DISTINCT ON` with an explicit `ORDER BY` makes "first"
deterministic rather than dependent on physical row order. The target set is resolved **before** any write,
because updating `MAIN_STOCK` empties the candidate set (candidates are defined by `VCH_SRNO = 0`).

`high` risk with typed confirmation: it deletes rows and rewrites voucher identity.

**Outstanding repairs: 2** — `AcRefresh` (the full general-ledger delete-and-rebuild) and `btnTagStkDelete`
(the destructive tag-stock convert), plus the 6 schema-init operations and `BtnMfg`'s 22 `Ac_Tax.*_Mfg`
routines. Both remaining repairs need the danger-zone protocol.


## 15. Schema-init buttons become a readiness gate, and it immediately found a live defect

`MS_UPDATE` has six buttons whose entire job is to CREATE or ALTER tables at runtime — SQL Server DDL fired
from the UI. The web owns schema through migrations and must not run DDL on a button press, so under the
behavioural-adaptation decision the faithful translation is a **readiness check**.

`project-memory/parity/desktop_init_schema.py` extracts every `CREATE TABLE` and `ALTER TABLE … ADD` from the
desktop source: **155 tables, 3343 columns** across `MS_UPDATE`, `MS_OPNCOMP`, `MS_PRODUCT` and `Ac_Image`.
`pnpm schema:readiness` compares that against `information_schema` and reports
**155/155 tables, 3241/3343 columns (96.9%)**.

### It is not a formality — the first run found a form field that could not be saved

`DG_GOLD_MAST.BANK_AC_CODE` is declared by the desktop
(`ALTER TABLE DG_GOLD_MAST ADD BANK_AC_CODE VARCHAR(10) NOT NULL DEFAULT '00075'`) and bound to
`MS_GOLD_MAST`'s `tBankCode`. The web's gold-rate master **rendered a "Bank A/c" input for it**, but the column
was never migrated — so every save failed:

    400 {"error":"invalid-data","detail":"column \"BANK_AC_CODE\" of relation \"DG_GOLD_MAST\" does not exist"}

Fixed by migration `20260730040000_gold_mast_bank_account` (nullable with the desktop's `'00075'` default; a
hard NOT NULL would reject every pre-existing row). Live-verified: the same save now returns **201**.

**This corrects an earlier claim of mine.** I reported "MS_GOLD_MAST is now 17/17, independently confirmed:
`GET /masters/gold-rate/meta` returns 14 fields". The field count was right but one of those 14 was
unsaveable, so the confirmation was weaker than stated.

The remaining 102 absent columns are baselined in `parity/schema-readiness-baseline.json`, **each with a
reason** naming the unbuilt feature — voucher transfer (`RE_TRFR`, 14 tables), commission modes, the extended
tax model, manufacturing lot linkage, line-level discounts, party statutory identifiers. The gate fails both
when something absent is not baselined AND when a baselined column now exists, so the list cannot rot. Both
controls proven, exit 1 on failure.

### Two migration-infrastructure defects found on the way

**`20260730030000_entity_image_store` was stuck PENDING**, so no further migration could deploy
(`relation "ENTITY_IMAGE" already exists`). Verified the objects were in fact complete — correct columns,
`entity_image_key_uq`, `entity_image_tenant_idx`, RLS forced with a `tenant_isolation` policy — then resolved
it. `TAG_IMAGE_BLOB` remains as an **empty, unreferenced orphan** with the old column shape; dropping a table
is irreversible so it is left in place pending an explicit decision.

**The migration drift manifest was stale by four migrations**, including the three added earlier this session.
`EXPECTED_MIGRATIONS` had 10 entries against 14 applied, so the drift detector was blind to them — a gap in the
gate itself, not the schema. Now pinned with checksums read from `_prisma_migrations`; controls prove both an
unpinned migration and a corrupted checksum fail.

**A latent nondeterminism fixed while there.** `prisma migrate resolve --applied` marks the failed attempt
rolled back and inserts a *second* row with the same name, so a name can appear twice. The health check
collapsed rows into a `Map` keyed by name under `ORDER BY migration_name`, leaving the tie unspecified — the
verdict could differ between runs on identical data. Rolled-back attempts are now excluded, which is also the
correct semantics: a rolled-back record is not applied.

### Browser smoke: the last of the race

Three more value assertions used `page.locator('select').nth(n)` rather than `getByLabel`, which the earlier
sweep missed. All are now polled; four consecutive clean runs. No immediate `inputValue()` assertion of either
form remains.


## 16. Labour model: LBR_TYPE is a weight basis, not a pricing mode

Found while deepening golden vectors (plan layer L1). Four defects in one chain, each proven before it was
fixed.

`CO_SET.LBR_TYPE`'s own option list gives the four values, and the sale grid's write-set bindings give the
arithmetic:

| Code | Label | Formula | Source |
|---|---|---|---|
| `G` | Gorss Wise | `ITM_GWT x LBR_RATE` | `TR_SALE.cs:11104` |
| `N` | Net Wise | `ITM_NWT x LBR_RATE` | `TR_SALE.cs:11119` |
| `K` | Kg Wise | `(ITM_NWT + ITM_GHT_WT) x LBR_RATE / 1000` | `TR_SALE.cs:11108` |
| `P` | Pcs Wise | `ITM_PCS x LBR_RATE` | `TR_SALE.cs:11127` |

with `MsLbrWithGht <> 'N'` adding `ITM_GHT_WT` to the weight bases (`:11112`, `:11100`, `:11123`), and

    LBR_RATE = Math.Round(ITM_RATE x LBR_PRC / 100, MsLbrRof)          TR_SALE.cs:11021

Grid columns resolved from the write set, not assumed: `11=ITM_PCS 12=ITM_GWT 13=ITM_OTH_WT 14=ITM_NWT
17=ITM_GHT_WT 22=ITM_RATE 24=LBR_PRC 25=LBR_TYPE 26=LBR_RATE 27=LBR_AMT`.

### What was wrong

The web modelled labour as `per_gram | per_piece | percentage | fixed` and mapped those to
`per_gram->'G'`, `per_piece->'P'`, `percentage->'%'`, `fixed->'N'`. Three of the four were wrong:

* **`per_gram -> 'G'`** — `G` is GROSS weight. A per-gram charge on net weight is `N`. Fixed.
* **`percentage -> '%'`** — `'%'` is not a value `LBR_TYPE` ever holds; the column is `varchar(1)` and the
  option list is G/N/K/P. A percentage is not a basis: it derives the RATE and keeps whatever basis applies.
* **`fixed -> 'N'`** — the desktop would read that as net-weight-times-rate and recompute a flat charge as a
  rate. `fixed` has **no desktop equivalent** and now falls back to the company default, with the limitation
  recorded rather than disguised.
* **`K` had no representation at all**, so a shop quoting labour per kilogram could not be modelled.

**`LBR_RATE` was never derived.** Proven live before the fix: `ITM_RATE 6200`, `LBR_PRC 12`, and
`LBR_RATE 0.00` where the desktop writes `744`. `LBR_TYPE` and `LBR_RATE` are both read back when a voucher is
reopened, so a zero rate does not merely look wrong — it changes the amount the desktop recomputes.

The amount differed too: the web applied the percentage to the metal amount
(`10 x 0.916 x 6200 x 0.12 = 6815.04`) where the desktop derives a rate and applies the basis
(`10 x 744 = 7440`) — **624.96 on a single line**.

### Fixed and verified

`apps/api/src/modules/shared/labourDesktop.ts` implements the four bases, the with-ghat variant, and the rate
derivation. `SettingsBehavior` now carries `labourType` from `CO_SET.LBR_TYPE`, returning blank for an
unrecognised value rather than guessing a basis.

Live after the fix: `LBR_RATE = 744.00` for the percentage line, and `per_gram` now writes `LBR_TYPE = N`.

**16 golden vectors** (`GV-LBR-*`, `GV-LBRPRC-*`), five inverted controls proven:

| Control | Failure |
|---|---|
| `G` uses net weight | `expected 1000 to be 1050` |
| `K` omits the /1000 | `expected 1000000 to be 1000` — a thousandfold error |
| percentage skips the /100 | `expected 74400 to be 744` |
| half-up instead of banker's | `expected 13 to be 12` |
| unknown code silently accepted | `expected [Function] to throw` |

One of my own vector expectations was wrong and the suite caught it: I asserted `781.25` rounds to `781.3` at
one decimal, which is the half-up answer, in a test whose purpose is banker's rounding. The correct value is
`781.2` because 2 is even.

**Still open:** `fixed` labour has no desktop code, so it cannot round-trip; and the four labour bases are now
correct on the sale path but the same mapping should be audited on purchase, labour-sale and wholesale.


### Labour mapping audited across every path (follow-on)

The sale fix left four more sites carrying the same defective map, found by grepping for `per_gram: 'G'`:
a second forward map in `sales.ts` (the labour-update call), the purchase write set, and both read-back
inverses.

**A bug I nearly shipped.** Correcting the forward map without the inverse creates a round-trip corruption:
once per-gram correctly writes `'N'`, the untouched inverse still read `'N'` as `'fixed'`, so a saved line came
back as a flat charge. `legacyLabourModeFor` is now the single inverse and six `GV-LBRRT-*` vectors assert the
two directions agree. Two controls proven: restoring the old inverse fails
`expected undefined to be 'per_gram'`, and letting `'G'` report per-gram fails `expected 'per_gram' to be
undefined`.

The inverse is deliberately **lossy**: `G` and `K` return `undefined` rather than a wrong mode, because
claiming a gross-weight or per-kilogram line is per-gram would change the amount on the next save.

**Independent corroboration:** `repair/repairReceipt.ts:58` already documented the correct semantics —
`"Desktop LBR_TYPE: P=piece, N=(net+less) weight, K=per-1000, otherwise gross weight"`. The repair module had
it right all along; sale and purchase were the outliers.

Purchase now also derives `LBR_RATE` from `LBR_PRC`, which it did not before.


## 17. L2 write-set footprint: a coverage hole, proven and closed

The lifecycle tests asserted the CONTENT of rows they looked at, but nothing asserted the SET of tables that
received rows.

**Proven by inversion.** Changing the sale's write set to `{ table: 'TAX_DATA', rows: [] }` — dropping every
tax row — passed **26 tests across three files, including the GST suite**. A voucher with no tax rows at all
was indistinguishable from a correct one.

That is precisely the failure the desktop comparison reports as `WEB NEVER WROTE THIS TABLE`, and it is the most
consequential kind of parity defect: the voucher looks right on screen and in its own detail rows while an
entire ledger or tax table is absent.

The assertion now lives in the sales lifecycle fixture, reusing its proven seed rather than duplicating a
hundred-line one. It is **schema-driven** — every table carrying a `VCH_NO` column is probed, so a table nobody
thought to list is still covered — and asserted as an exact SET, so both directions fail: a table that stops
receiving rows, and a table that starts receiving them unexpectedly, which is how a duplicate ledger posting
would appear.

The footprint is **input-dependent**, and that is correct: these fixture lines carry stone sub-details so
`SL_IDTL` is written, and the voucher is created with field auditing so `USER_DATA` is too. A demo sale without
stones writes `TEMP_BOOK_DATA` instead. Pinning it means any change has to be deliberate.

Ledger balance is asserted alongside the footprint, because a footprint check alone would pass if `AC_DATA`
received rows that did not balance.

Two controls proven: dropping the tax rows fails naming `- "TAX_DATA"`, and emptying the ledger lines fails
naming `- "AC_DATA"`.


## 18. L6 configuration matrix: CO_SET.SL_AMT_TYPE

A suite that only exercises defaults tests one shop. `SL_AMT_TYPE` selects the weight the item rate is
multiplied by, so it changes the money on every line (`saleAmountBase`):

| Value | Basis |
|---|---|
| `''` | fine weight (pre-setting web behaviour, preserved deliberately) |
| `'F'` | fine, or net+ghat when fine is 0 |
| `'G'` | gross + ghat |
| `'N'`, `'P'` | net + ghat |

The matrix runs all five values through the sales lifecycle fixture with gross 12.000, net 10.000 and touch
91.6, so fine is 9.160 and every basis gives a different amount: **9160, 9160, 12000, 10000, 10000**.

A companion guard asserts the three bases are genuinely distinct. Without it, a fixture change that made gross,
net and fine coincide would leave every matrix row passing regardless of whether the setting was read at all —
the matrix would be vacuous and nobody would notice.

Three controls proven: ignoring the setting entirely fails 3 rows; `G` reading net instead of gross fails 1;
the `F` fallback firing when fine is non-zero fails 1.

**Scope:** 39 settings feed `resolveSettingsBehavior`, and only `SL_AMT_TYPE` has a full value matrix so far.
`PR_AMT_TYPE`, `ALL_ROF_REMOVE` and the four `*_ROF` decimal settings are the obvious next ones — `ALL_ROF_REMOVE`
especially, because it overrides four other settings at once (`MS_OPNCOMP.cs:1297-1303`).


## 19. L4 report data comparison, and a CSV export gap it exposed

**A real capability gap found on the way.** The desktop exports CSV from every report; the web had exactly one
such route (`tag-stock.csv`) alongside a generic XLSX export. `GET /reports/:report/export.csv` now covers all
45 reports, and the CSV and XLSX paths share one `resolveReport` helper so the two formats cannot disagree about
what a report contains.

The comparison (`reportDiff.ts`) compares the DATA — rows and control totals — never the layout.

**Reading a Crystal export is the hard part.** It is not a clean table: it carries a UTF-8 BOM, a title block,
page headers repeated on every page, group captions, blank separators, a grand total, thousands separators and
parenthesised negatives. Counting any artefact as a data row makes the row totals disagree for reasons unrelated
to the business logic, and sends someone hunting a defect that does not exist. On the live run against 50 real
rows the reader skipped **24 repeated headers** and one grand total, and still matched.

**Column names cannot be inferred.** Crystal names fields after the report designer (`AcName`, `Dr Amount`); the
web names them after its row keys (`party`, `dr`). A mapping is required per report, and an unmapped Crystal
column is REPORTED rather than dropped — otherwise the comparison could claim agreement on data it never looked
at.

Two levels, and the weaker one is labelled as such:
* **control totals** — row count and the sum of each mapped numeric column, robust against ordering and
  formatting;
* **row level** — paired by a declared key, field by field. It runs ONLY when a key exists and every mapped
  column is present on the web side; otherwise a row-level verdict would be a statement about the mapping
  rather than the data, and the report says `row level: NOT run`.

19 unit tests. Five controls proven: counting the grand total as data, treating a repeated header as data,
ignoring thousands separators, running a row-level verdict on an incomplete mapping, and letting an empty
report pass.

Live end-to-end on 50 real rows: a Crystal-shaped export synthesised from the web's own, then perturbed. One
paisa was caught as `dr: crystal=58495.77 web=58495.76` with the row named; removing rows was caught as
`crystal 45 web 50`. **Every probe artifact was then deleted** — a proof of the instrument is not evidence about
the applications, and `project-memory/parity/reports/README.md` records that rule.

**A defect in my own file, caught by typechecking:** stray non-ASCII characters were written into the CSV
parser's field loop. Removed, and a scan now confirms no unexpected non-ASCII remains.


## 20. L6 continued: a rounding setting must reach the PERSISTED value

`resolveRoundingPolicy` was already unit tested, including that `ALL_ROF_REMOVE=Y` forces four precisions to 2
while leaving `PR_RATE_ROF` independent (`MS_OPNCOMP.cs:1297-1303`). What nobody had shown is that the resolved
policy reaches the database — a policy object holding the right number is worth nothing if the write path
ignores it.

Measured, not predicted (`rate: 7131.1`, 3% tax):

| Setting | TAX_AMT | CGST_TAX |
|---|---|---|
| `TAX_ROF=5` | 1959.63 | 979.8132 |
| `TAX_ROF=2` | 1959.63 | 979.815 |
| `TAX_ROF=0` | 1960 | 980 |
| `TAX_ROF=5, ALL_ROF_REMOVE=Y` | 1959.63 | **979.815** — behaves as 2 |

**Where a value is observable turned out to be the crux.** `SL_DETL`'s money columns are `numeric(_,2)` and
`SL_DATA.TAX_AMT` is too, so a precision finer than two decimals is truncated by the column before anyone can
read it: 5 and 2 decimals both persist 1959.63. `CGST_TAX`/`SGST_TAX` are `double precision` with no scale,
which is where the desktop's unrounded intra-state halves live, and the only place the distinction survives. My
first version asserted the 5-versus-2 difference on `TAX_AMT`, which made a test that could never fail.

Three controls proven: `ALL_ROF_REMOVE` no longer overriding tax precision, `TAX_ROF` ignored entirely, and
rounding the intra-state halves — the last fails with `expected 1959.64 to be close to 1959.63`, because two
rounded halves no longer sum to the tax. That discrepancy would appear on a filed GST return.

### Process lesson: a control on a workspace PACKAGE needs a rebuild

The halves control passed twice against a deliberately broken build, and the reason was not the assertion.
`packages/core` is a separate package and the API imports its **built output**; vitest transpiles
`apps/api/src` on the fly but not that. Editing `packages/core/src/calc.ts` therefore had no effect until
`pnpm --filter @datacare/core build` ran.

So an inverted control on `packages/core`, `packages/db` or any other workspace package is a **silent no-op**
without a rebuild, and will look like a passing control. Every earlier control in this session happened to sit
in `apps/api/src`, which is why none of them was affected — but that was luck rather than design.


## 21. The desktop databases were in the tree all along

`unified/database/backups/` contains the real DataCareNext SQL Server databases — `Next23`, `Next24`, `Next25`,
`NextMain`, `NextImage` as both `.mdf`/`.ldf` and `.BAK`. SQL Server 2022 runs under emulation in Docker on
arm64, so they can be read here. **The desktop comparison no longer needs the Windows box.**

`Next24.mdf` attached as `Live24` holds genuine desktop-created transactions: **190 sales, 245 sale lines, 74
purchases, 5150 ledger rows, 184 tax rows, 1329 tags, 1856 stock movements, 918 accounts.** Backed up
2025-04-21 from `DESKTOP-IIGOT35\SQLEXPRESS`.

The `.BAK` restores are seed databases — full schema, masters populated, **no vouchers**. Only the loose
`.mdf` carries transactions. Restoring the backup and stopping there would have produced an empty comparison
that looked like agreement.

**This is real business data.** It stays local: `project-memory/parity/bundles/*.json` and
`DESKTOP-REAL-SCHEMA.json` are git-ignored, verified with `git check-ignore`, and the snapshot holds column
names only with no rows.

### Schema parity against the real database: 145/145 tables, 5231/5231 columns

Measured against the real desktop schema rather than my extracted contract, the web schema is a **complete
superset**: every real table and every real column is present.

**And this corrects my own measurement.** `DESKTOP-INIT-SCHEMA.json`, built from decompiled DDL strings,
claimed 155 tables and 3343 columns. The real database has **145 tables and 5231 columns**. My contract:

* **over-claimed 19 tables and 112 columns** belonging to initialisers this company never ran, and
* **missed 9 tables the real database has** — `COL_MAST`, `CONV_MAST`, `COUNTRY_MAST`, `IMAGE_DATA`,
  `LEDR_AC_DATA`, `LOGIN_MAST`, `STATE_MAST`, `TEMP_BOOK_DATA`, `YEAR_MAST` — created by the installer script
  rather than by runtime DDL, and
* **found only 64% of the real columns**, because most are added by the installer, not by the `CREATE TABLE`
  strings I matched.

So the earlier "3241/3343 = 96.9%" was measured against an incomplete and partly fictional denominator. All 102
columns the readiness gate reports absent from the web are **also absent from the real database** — verified
individually. `DESKTOP-REAL-SCHEMA.json` is now the honest denominator.

### FINDING: the web does not maintain the Rojmel

Running the extractor against a real desktop sale (book 027, voucher 00001, 2 lines) gives the desktop's actual
write set:

    AC_DATA 3   BILL_OS_DATA 1   MAIN_STOCK 2   OP_LDR 2   ROJ_MEL_DATA 4
    SL_DATA 1   SL_DETL 2        TAX_DATA 2     TEMP_BOOK_DATA 1

Against the web's pinned footprint, two tables the desktop writes are **never written by the web on a sale**:

| Table | Desktop | Web |
|---|---|---|
| `ROJ_MEL_DATA` | 4 rows per sale | 0 rows ever; written only by `vpParcel.ts` |
| `OP_LDR` | 2 rows per sale | 0 rows ever; exists only as a config table |

The four Rojmel rows are a **combined stock-and-money day book**, not a ledger copy:

    LD_CODE 000888  CR 1087.00  IT_TYPE S  SIGN -  PCS 1  GWT 10.360
    LD_CODE 000888  CR  428.00  IT_TYPE S  SIGN -  PCS 1  GWT  4.600
    LD_CODE 00004   DR 1560.00  IT_TYPE A
    LD_CODE 000888  CR   45.45  IT_TYPE A

`IT_TYPE` separates **S**tock from **A**mount, and the stock rows carry pieces and gross weight. That is what a
jeweller's Rojmel is: metal movement and cash side by side.

The web's `F11` — labelled "Rojmel" — navigates to `/reports/day-book`, and `dayBook` reads `AC_DATA`. So the
web substitutes a **money-only ledger listing** for a report that in the desktop shows weights and pieces
alongside amounts. They are not the same report, and no amount of reading the decompiled source revealed it:
it took seeing what the desktop actually writes.

`SL_IDTL` and `USER_DATA` appear on the web side only, and both are explainable — this sale had no stone
sub-details, and `USER_DATA` is the web's own field-audit table.

**Not yet done:** replaying these real vouchers through the web and diffing them field by field. The bundle
exists, the differ is tested, and the inputs are recoverable from `SL_DETL`. That is the next step and it is now
purely local work.
