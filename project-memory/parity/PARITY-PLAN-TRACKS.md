# Parity Plan — Track Task Detail

Companion to `PARITY-MASTER-PLAN.md`. Each task: id, title, size, files, verification, negative control.
Sizes are relative (S/M/L/XL), not hours. Every desktop claim carries a `file:line` verified during planning.

---

## TRACK A — CONFIGURATION (settings 55/130 → 130/130)

| # | Task | Size | Key files |
|---|---|---|---|
| A1 | Freeze the independent 130-key inventory from `schema.prisma` (60 `CO_SET` + 70 `CO_SET_NEW`) + traceability matrix | XL | `settingsInventory.ts`, `settingsInventory.test.ts`, `settings-parity-matrix.csv`, `SETTINGS-PARITY-DECISIONS.md` |
| A2 | Shared discriminated field contract (boolean/enum/number/date/text) | M | `packages/types/src/settings.ts`, `settingsContract.test.ts` |
| A3 | 130-entry evidence-bearing catalog; source-backed options only | XL | `settingsOptions.ts`, `settingsCatalog.ts`, `settingsCatalog.test.ts` |
| A4 | Server-side validation: option membership, finite numerics, dates, widths, unknown-key rejection | L | `settingsValidation.ts`, `settingsValidation.test.ts` |
| A5 | **Dual-table atomic read/write** (fixes P0-3) | L | `settings.ts`, `settings.test.ts`, `settings.db.test.ts` |
| A6 | Typed route contract + RBAC; no provenance leakage | M | `routes/txn.ts`, `settingsRoute.test.ts`, `routePolicy.test.ts` |
| A7 | Typed field renderers; option `value` is the persisted code, label display-only | L | `SettingFieldControl.tsx`, `settingsState.ts` + tests |
| A8 | Desktop tab navigation: `Setting1`, `Advance Cantrol`, `Setting3`, UAE subgroup | L | `settings/page.tsx`, `SettingsTabs.tsx` |
| A9 | Browser + full round-trip coverage | XL | `browser.smoke.mjs`, `settings.db.test.ts` |
| A10 | `settings-exposure` ratchet gate in CI | M | `check-settings-parity.mjs`, `settings-baseline.json` |
| A11 | Close records; document residual unknowns | S | `FEATURE-GAP-REGISTER.md`, decisions doc |

**Verification pattern.** A1 asserts key equality against `schema.prisma` with a hard `total===130` so the
denominator cannot shrink with the catalog. A5's DB test seeds distinguishable values in all 130 columns,
edits representative fields across **both** tables, and asserts untouched columns unchanged plus rollback.
**Negative controls:** revert the read to `CO_SET` only → all 70 `CO_SET_NEW` assertions fail; change an
option `value` from `Y` to `Yes` → golden mapping fails; remove one descriptor → exposure 99.2% fails.

**Option sets transcribed (sample, all cited).** `LBR_TYPE` `Gorss Wise→G / Net Wise→N / Kg Wise→K /
Pcs Wise→P` (`UT_SETTING.cs:4252-4255`, persistence `:4903-4905`); `RATE_PAR` G/T/K (`:4256-4258`);
`HELP_SERCH` `Selected Col→S / Mobile Mathod→M / Whout Row Short→W / All Column→A` (`:4272-4275`);
`DEFAULT_REMINDER` R/B/O/S/W/D/M (`UT_SETTING_MAIN.cs:8444-8450`); `FONT_NAME` full values
(`:8398-8402`); `GRID_ROW_HIGHT` 20-40 discrete (`:8408-8422`); `TOT_FINE_STK_TYPE` I/G/T (`:8363-8365`).
Desktop misspellings (`Gorss`, `Mathod`, `Whout`, `Advance Cantrol`) are preserved verbatim.

**Decisions required before coding.** (1) `FX_CODE` writes from `cboOzCon.Text` (`UT_SETTING.cs:5131-5135`)
— probable desktop bug, do not reproduce without sign-off. (2) `PRINT_ZOOM` / `CRYSTAL_RPT` are written by
desktop but absent from schema — resolve as drift, excluded from the 130. (3) `LAST_DAY_LOCK=Y` also writes
`LOCK_DATE` (`:9157-9165`) and `TOT_AMT_ROF` also writes `ITM_RATE_ROF` (`:9200-9207`) — preserve only with
an explicit test. (4) Never reproduce the `tDcPwd` hardcoded reveal (`:9181-9188`).

---

## TRACK B — TRANSACTIONS (Phase 1 + backlog)

| # | Task | Type | Size |
|---|---|---|---|
| B1 | Authoritative surface manifest + two-mode gate (ratchet / phase1 / complete) | BUILD | M |
| B2 | Route registry generator (**does not exist today**) | BUILD | S |
| B3 | **One settlement engine**: amount↔fine, DR/CR, fine kasar, rate-per mode | BUILD | L |
| B4 | Wire settlement + full CRUD into wholesale and labour sale | WIRING | L |
| B5 | Build `TR_TOUR_SALE` + `TR_BUL_SALE` as distinct surfaces | BUILD | XL |
| B6 | Wire existing silver-cut (`rateCut.ts`) to tour + wholesale | WIRING | M |
| B7 | Wholesale fine interest from elapsed days | BUILD | M |
| B8 | Voucher search/load/edit on wholesale + tour-sale | WIRING | M |
| B9 | Per-voucher document variants + delivery (HUID / image / no-commission / WhatsApp) | BUILD+WIRING | XL |
| B10 | Loyalty **inside** the sale transaction | BUILD+WIRING | L |
| B11 | Bill profit with server-side visibility policy | BUILD | XL |
| B12 | Shared blank-label skip across 11 `TR_*` + `UT_TAG_PRINT` | BUILD+WIRING | L |
| B13 | Atomic voucher transfer (sale + hallmark) | BUILD+WIRING | XL |
| B14 | Generic transaction/tag image persistence + API (**needs storage ADR**) | BUILD | XL |
| B15 | Wire shared image panel to 17 `TR_*` capture surfaces | WIRING | XL |
| B16 | Olocker behind a tested integration boundary | BUILD+WIRING | L |
| B17 | Phase-1 closure: cleanup lists, mutation proof | GATE | M |
| B18-B27 | Backlog: chrome/keyboard/help, sales family, purchase family, DHRN, stock/tag/RFID, manufacturing, finance/card/UPI, membership, bullion/rate-cut, zero-open gate | mixed | XL each |

**Critical state correction.** `/txn/tour` posts **approval issue**; `/txn/bullion` is **booking**. Neither
is the corresponding `TR_*` sale form, so B5 is a build, not a wiring job.

**Golden vectors assigned.** `GV-TXN-SETTLE-001..005` (effective rate `round(convRate/convPct*100,2)`;
factor 10 for `MsRatePar='T'`, 1000 for `'K'`, else 1 — `TR_TOUR_SALE.cs:12999-13046`,
`TR_WH_SALE.cs:15372-15419`, `TR_BUL_SALE.cs:10518-10565`); `GV-LBR-SETTLE-001/002`
(`TR_SALE_LBR.cs:11585-11618`); `GV-WH-FINE-INT-001..003` (`TR_WH_SALE.cs:14735-14749` — absolute
DateDiff, `×12`, `/MsIntYearDays`, 3 dp); `GV-SALE-POINT-EARN-001` (`TR_SALE.cs:19296-19320`);
`GV-SALE-POINT-REDEEM-001` (`:20933-20952`); `GV-LABEL-SKIP-001` (.NET midpoint-to-even,
`TR_TAG_OPBL.cs:11485-11489`); `GV-BILL-PROFIT-{SALE,LBR,TOUR,WH}-001`.

**Deliberately blocked, not guessed.** Bill-profit per-row cost branches must be transcribed in full before
values are populated — no generic "sale minus purchase". Silver-cut stays WIRING only if an adapter test
proves `rateCut.ts` matches the tour/wholesale `BILL_TOTAL` silver branches; otherwise the mismatched part
is reclassified BUILD. `MsRatePar` needs its source loader identified; until then reject rather than accept
a body value.

---

## TRACK C — MASTERS & MANAGEMENT (incl. 18-operation repair console)

| # | Task | Size |
|---|---|---|
| C1 | Reconstruct canonical inventory (replaces the approximate 48 / "~16 repairs") | XL |
| C2 | Monotonic parity ratchet gate | M |
| C3 | **`formFields` resolver — fixes P0-2** | M |
| C4 | Schema-aware contracts: real text widths from `information_schema`, declarative details/commands/media | L |
| C5 | Generic prefix search (`MS_BOOKLIST.cs:548-600`) | S |
| C6 | Item: flags, `IT_GHT_PRC`, Unicode name, bulk-apply to unsold tags (`MS_ITEM.cs:3969-4024`) | L |
| C7 | Digital gold: conversion, fixed rates, markup/markdown, enable book (`MS_GOLD_MAST.cs:1322-1335`) | S |
| C8 | Scheme: amount/duration/bonus, app publish, image, transfer profile (secrets redacted) | L |
| C9 | Account: `LCS_NO`, shareholder flag, copy-from-party, prior-year import, party media | XL |
| C10 | Tax: `INPUT_TAX_AC` + `SR_NO` in business identity so components coexist (`MS_TAX.cs:1608-1659`) | L |
| C11 | User: delete + rights + session revocation, password confirmation, forced reset | L |
| C12 | Close all remaining inventory rows declaratively | XL |
| C13 | **Repair framework S5**: immutable preview hash, advisory lock, one transaction, diff-only apply, append-only audit | XL |
| C14 | Financial/stock/manufacturing/opening rebuilds as diff repairs | XL |
| C15 | Approval, duplicate-tag, serial, weight/fine, orphan, active-stock repairs (9 ops) | XL |
| C16 | Delete/convert-all-tag-stock as isolated danger zone | L |
| C17 | Image/CRM/scheme/field initialization → migrations + readiness checks | XL |
| C18 | Repair console UI + engine-neutral `UT_IMPORT` launch interface | XL |
| C19 | End-to-end sign-off | L |

**Repair test invariant (all 18).** Seed broken data → preview exact insert/update/delete counts → apply →
assert repaired state → **rerun and assert zero diff** → assert healthy and cross-tenant rows
byte-unchanged. Each has a named mutation that must fail it, e.g. karigar fine omitting `/100`
(`MS_UPDATE.cs:32561-32596`), opening balances including post-opening activity (`:32662-32704`), duplicate
repair choosing the wrong survivor (`:9244-9411`), active-stock ignoring signed derivation (`:33043-33106`).

**Destructive-op safeguards.** `btnTagStkDelete` (`MS_UPDATE.cs:32423`) is default-disabled behind a feature
flag, verified backup reference, downloadable row-manifest with checksums, dual approval, typed
operation+company confirmation, and a second fresh preview immediately before apply. Opening-balance rebuild
requires a restore point because the desktop itself warns the old opening cannot be recovered.

---

## TRACK D — REPORTS, DOCUMENTS, EXPORTS (50 families)

| # | Task | Size |
|---|---|---|
| D1 | Freeze the 50-family semantic + filter manifest | XL |
| D2 | Seeded-voucher DB fixture harness with cross-tenant sentinel | L |
| D3 | Shared catalog + 15-filter matrix (S4) | XL |
| D4 | Server-side XLSX writer (S3) | L |
| D5 | Metadata-driven filter/export UI replacing the Year-only toolbar | L |
| D6 | `RP_ALL` hub: approval, order, movement, cash copies, karigar/repair, VP/Angadia, bullion, summaries, labour | XL |
| D7 | Stock/tag/HUID/estimate/image/location families (14 forms) | XL |
| D8 | **P0-1 balance sheet fix** + statements, ledgers, tax, cash, outstanding, pledge (11 forms) | XL |
| D9 | Employee commission (5 modes), CRM, reminder, user, address, customer, day-work | XL |
| D10 | Profitability, order tracking, consignment, tour/sales-purchase zoom | XL |
| D11 | Manufacturing, jadtar, other-item, mfg ledger | XL |
| D12 | Graph reports over verified data | M |
| D13 | Report/export/messaging/statutory utilities | XL |
| D14 | `report-coverage` ratchet gate (independent of the 254-layout gate) | M |
| D15 | Crystal visual parity acquisition + gate — **external blocker** | XL |
| D16 | Release contract: two statuses (data/filter/export complete; visual blocked) | L |

**XLSX decision.** `write-excel-file@4.1.1` — MIT, single dependency (`fflate`), no native deps, Node >= 18.
`fflate@0.8.2` dev-only, to unzip and inspect XML in tests.

**Why not SheetJS `xlsx`** — stated precisely, because the usual summary is wrong. CVE-2023-30533 /
`GHSA-4r6h-8v6p-xvw6` is a **read-path** prototype-pollution bug affecting SheetJS CE through 0.19.2, and the
advisory explicitly says workflows that only *write* spreadsheets are unaffected. So the CVE does **not**
apply to an export-only use. The rejection rests on supply chain instead: the fix is 0.19.3+, public npm
stops at 0.18.5, and current builds are distributed from the vendor's own CDN. Adding a non-registry
download path is unjustified when a maintained registry package covers a write-only need. If SheetJS is ever
required for *reading* (a legacy import), this decision must be revisited with the CVE fully in scope.

Never enable formula cells: strings starting `=`, `+`, `-`, `@` are always written as text and a test asserts
no `<f>` element is produced.

**Correctness rule for every report.** Seed a known voucher, assert complete ordered rows and exact totals.
Examples: `CASH001 = 1250.25` appears exactly; `APR001` issue 10.000 / return 4.000 → pending 6.000; gold
`ClFine=10, rate=70000, AVG_AMT=500` → 70,500 via `10×(70000/10)+500`. Negative control changes one source
row and proves only the affected report and total move. HTTP 200 is never evidence.

---

## TRACK E — MIGRATION & CUTOVER (mechanics buildable, correctness blocked)

| # | Task | Size | Status |
|---|---|---|---|
| E1 | Authoritative 11-family catalog from `UT_IMPORT.cs` | M | buildable |
| E2 | Export contract v1 spec + golden bundle | L | buildable |
| E3 | Quarantine + whole-package preflight | L | buildable |
| E4 | Immutable migration control-plane (runs, artifacts, results, attestations, RLS) | L | buildable |
| E5 | Exact-decimal mapping mechanics (scaled BigInt, never IEEE-754) | XL | buildable |
| E6 | Staging, tenant lock, atomic apply, recovery, reruns | XL | buildable |
| E7 | Multi-dimensional reconciliation + signatures | L | buildable |
| E8 | Harden existing live SQL Server `cutover.mjs` to fail closed | L | buildable |
| E9 | Authenticated migration API + RBAC | L | buildable |
| E10 | Operator console | L | buildable |
| E11 | Windows ODBC/OLE DB export bridge | XL | contract buildable, **drivers blocked** |
| E12 | Object storage + quarantine (S2) | L | buildable |
| E13 | Tag-image transfer: gallery, bundles, progress (backend exists, no route/UI) | XL | buildable |
| E14-E18 | Message campaigns: state, audiences, spreadsheet round-trip, queue/pacing/retry, translation/attachments, console | L-XL | buildable |
| E19 | Guarded bulk stock-date repair (`UT_IMPORT.cs:11848-11896`) | L | mechanics buildable, mapping blocked |
| E20 | `migration-readiness` fail-closed gate | L | buildable, **stays red** |
| E21 | Real-profile enrollment protocol | M | buildable |
| E22-E32 | Profiles F01-F11 | XL each | **BLOCKED — need a real legacy DB** |
| E33 | Signed rehearsal | XL | **BLOCKED** |

**Export contract essentials.** Deterministic ZIP; `manifest.json` + `complete.json` (written last) +
`tables/*.ndjson`; three checksum levels (per-file, content-root, archive sidecar); canonical decimal and
date **strings**; full preflight in quarantine — archive bombs, traversal, digest/length mismatch, ordinal
mismatch, malformed NDJSON, row-count and control mismatch — **all rejected before any business write**.

**Reconciliation proves** row-for-row target equality plus exact monetary and gross/net/fine weight control
totals, by table, by book and by account, with zero unexplained rejected/missing/extra rows, and detached
Ed25519 signatures from operator + independent reviewer.

**Idempotency identity** `(tenantId, exportId, archiveSha256, contractVersion, profileVersion)`: same digest
replays the prior immutable report with zero row delta; different digest under the same export id is
rejected as tampering.
