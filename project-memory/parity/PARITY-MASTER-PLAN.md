# DataCareNext — Desktop→Web Full Parity Implementation Plan

**Date:** 2026-07-29
**Basis:** `FEATURE-GAP-REGISTER.md` (1,606 absent controls, 75 unreachable settings, 162 form-level gaps)
plus five track-level plans researched in parallel against the desktop source.

**Scope of this document:** the master sequencing, the shared infrastructure, the gate model, and the
blocked/buildable split. Track detail lives in:
`PLAN-CONFIG.md`, `PLAN-TXN.md`, `PLAN-MASTERS.md`, `PLAN-REPORTS.md`, `PLAN-MIGRATION.md`.

---

## 0. P0 — correctness defects found *while planning*. Fix before any feature work.

Planning read the desktop more carefully than the gap audit did and surfaced defects in code that is
already shipping. These are not missing features; they are wrong answers.

### P0-1 The balance sheet cannot reveal a stock discrepancy

`web/apps/api/src/modules/reports/reports.ts:493`
```ts
const closingStock = round2(cr - dr); // balancing figure (closing inventory + trading result)
```
Closing stock is *defined* as whatever makes Assets equal Liabilities. The desktop computes it
independently (`Ac_Final.cs:18-133`, query at `:40`): `MAIN_STOCK` aggregated with `ITM_SIGN` polarity into
`ClPcs`/`ClNwt`, joined to `BAL_GR` for `AVG_FINE`/`AVG_TOUCH`/`AVG_AMT`/`TRAD_AMT`, valued at
operator-entered gold/silver rates — fine basis `ClFine × rate/10` with ledger-fine adjustment, or
`ClNwt × ClRate + ClPcs × PCS_RATE`.

Consequence: **the web balance sheet always balances, so it can never show shrinkage or a valuation
error.** For a gold business that is the single most important thing a balance sheet does. Priority is
therefore above every feature in this plan. Owner: reports track, Task RPT-08, promoted to P0.

### P0-2 `cfg.formFields` silently hides fields

`web/apps/api/src/app.ts:726` — `cfg.formFields ?? GENERATED_FORM_FIELDS[cfg.table]`. An explicit list
**replaces** the generated set instead of overriding it, which is why digital gold, schemes, groups, items
and accounts lost fields. This one line is the root cause of a large share of the 974 missing entry
controls, so fixing it converts many "absent" rows into "already present" at near-zero cost. Owner:
masters track, Task MM-META-003. Must land before per-master field work, or the same fields get added twice.

### P0-3 The settings surface cannot reach `CO_SET_NEW` at all

`settings.ts` reads and writes `CO_SET` only (zero `CO_SET_NEW` references, verified). The 70
`CO_SET_NEW` settings are read by consuming modules, so they govern behaviour while being unmanageable.
Requires dual-table read/write, not more list entries. Owner: config track, Task 5.

---

## 1. Measurement corrections carried into this plan

Planning corrected several of my own figures. Each is now stated with its exact denominator.

| Claim | Correction |
|---|---|
| "100% UI field capturability (496/496)" | Denominator was *web API fields*. Desktop-denominated: **2,949 / 4,555 controls (64.7%)**, a lower bound. |
| "Backend reads 129 of 130 settings" | True only as "129 names appear somewhere in API source". The settings **endpoint** handles 55 `CO_SET` columns and **cannot reach any of the 70 `CO_SET_NEW`**. |
| "Blank-label skip: 12 forms" | **12 total = 11 `TR_*` + 1 `UT_TAG_PRINT`**. |
| "Image capture: 24 forms" | **24 total = 17 `TR_*` + 5 `MS_*` + 2 `RP_*`**. |
| "Route count pinned in 3 places" | Pinned **twice**, both in `routePolicy.test.ts`. `build_parity_matrix.py` *parses* routes but asserts no count. No web route generator exists. |
| "64 transaction gaps" | A manual consolidation. The audit holds **61 `TR_*` rows / 653 missing control names**. Phase 1 must reconcile the 64 slots to source or correct the register. |
| `PRINT_ZOOM`, `CRYSTAL_RPT` | Desktop **writes columns absent from the extracted schema** — same class as the 22 stale Crystal aliases. Excluded from the 130 denominator pending a decision. |

Also found: `FX_CODE` is written from `cboOzCon.Text`, not `cboFxCode.Text` (`UT_SETTING.cs:5131-5135`) —
a probable desktop bug that must **not** be reproduced without sign-off.

---

## 2. Shared infrastructure — build once, before the tracks that consume it

Four tracks independently specified the same components. Building them per-track would triple the work
and guarantee divergence. These are extracted into a Phase 1 shared layer with single owners.

| Component | Consumed by | Why shared |
|---|---|---|
| **S1 Media subsystem** (upload/capture/replace/delete/zoom, tenant-keyed) | 17 `TR_*`, 5 `MS_*`, 2 `RP_*` | One panel + one storage contract for all 24 forms. Requires an ADR first: desktop stores bytes on a file share with `TAG_IMAGE_DATA` as metadata; web `TAG_IMAGE_DATA` has **no byte column** and `IMAGE_DATA` is staging. Do not misuse staging as durable storage. |
| **S2 Object storage + quarantine** | S1, migration bundles, message attachments, report exports | Replaces desktop FTP/file-share. Provider-neutral interface; local adapter for tests. |
| **S3 XLSX writer** | 38 desktop forms across reports, txn, masters | One server-side writer. Reports track owns it; everyone else calls it. |
| **S4 Filter matrix** (15 filters, typed, validated, serialized) | Every report; several masters/txn lookups | The web report UI exposes only Year today. Built once as catalog metadata. |
| **S5 Preview/apply repair framework** (immutable preview hash, advisory lock, one transaction, diff-only apply, append-only audit) | 18 `MS_UPDATE` repairs, bulk stock-date correction, item bulk-apply, party import | Every destructive operation shares one safety protocol. **No destructive op is written before this exists.** |
| **S6 Typed field model** (boolean/enum/number/date/text + desktop-sourced option sets) | Settings (130), masters metadata | Prevents free-text entry of coded values in both surfaces. |
| **S7 Prefix search** (`MS_BOOKLIST.cs:548-600` semantics: case-insensitive **prefix** over rendered cells) | Every master list, several pickers | Desktop is prefix, not substring. One matcher. |
| **S8 Route registry generator** | All tracks (each adds routes) | Does not exist today; 369 is pinned only in two test assertions. Every track adds routes, so this must exist before they do. |

---

## 3. Phase sequencing

```
PHASE 0  P0 correctness            P0-1 balance sheet · P0-2 formFields · P0-3 dual-table settings
   │                               + inventory reconciliation (txn 64→source, masters 48→source)
PHASE 1  Shared layer              S8 routes · S6 typed fields · S2 storage · S1 media
   │                               S3 xlsx · S4 filters · S5 repair framework · S7 search
PHASE 2  Configuration             130/130 settings, grouped to desktop tabs, typed, validated
   │                               (highest value per effort: one screen, 75 settings)
PHASE 3  Cross-cutting UX          Ctrl+F1/F2/F5/F6/F8/F9/F11/F12 + Ctrl+A/B/O · label skip (12)
   │                               media wiring (24 forms) · bill profit (4) · master search
PHASE 4  Masters & management      Item/gold/scheme/account/tax/user + the 18-operation repair console
   │
PHASE 5  Transactions              Settlement engine → wire 4 forms · tour-sale + bullion-sale build
   │                               voucher reopen · print/send variants · loyalty-in-sale · transfer
PHASE 6  Reports & exports         Filter matrix rollout · 50 families · commission modes · drill-down
   │
PHASE 7  Migration                 Export contract · preflight · staging · reconciliation (mechanics)
   │
PHASE 8  Certification             G5 desktop comparison · G6 production · rehearsal evidence
```

**Why this order.** Phase 0 fixes wrong answers before adding surface. Phase 1 prevents four
reimplementations. Phase 2 is deliberately early: it is one data-driven screen that closes 75 gaps and
unblocks behaviour the owner cannot currently control. Phase 3 is cheap and highly visible to a counter
operator. Phases 4-6 are the bulk. Phase 7 is mechanics-only until a real legacy database exists.

---

## 4. Gate model

Existing gates (must not regress): 7 per-unit gates with `depth`; column depth **98.9%**; **700 tests /
100 files**; lint 447 files; **254 report layout baselines**; route count pinned ×2; UI field audit.

New gates, one per track, each ratchetable and each with a proven failing mutation:

| Gate | Metric | Initial | Target | Proven-failing mutation |
|---|---|---:|---:|---|
| `settings-exposure` | catalog / 130 schema columns | 55 (42.3%) | 130 (100%) | delete one descriptor → 99.2% |
| `txn-surface` | source-backed capabilities closed | baseline 653 missing | 0 non-waived | remove wholesale `silverCut` binding |
| `master-management` | terminal inventory rows | reconciled in Phase 0 | 0 absent/partial | flip one row to `partial` |
| `report-coverage` | 50 families × filters × outputs | ~21 partial | 50 verified | drop one filter |
| `migration-readiness` | signed rehearsal evidence | **FAIL** | FAIL until real DB | relabel synthetic as customer evidence |

Two rules that make these honest:
1. **Every gate must be demonstrated failing** before it is trusted. This project has already had one
   false-passing negative control (a Python `replace()` silently no-oped after prettier reflow).
2. **No gate may lower its own denominator.** Denominators come from the desktop or the schema, never from
   the web's own catalog. This is the exact error that produced "100% capturability".

---

## 5. Blocked vs buildable — stated plainly

| Area | Status | Needs |
|---|---|---|
| Everything in Phases 0-6 | **Buildable now** | nothing external |
| Crystal visual layout parity (21 of 22 critical) | **Blocked** | the `.rpt` files, never supplied |
| Legacy migration *correctness* | **Blocked** | a real customer `.MDB`/SQL Server database |
| MDB/ODBC driver compatibility | **Blocked** | a Windows matrix + real files |
| G5 desktop comparison | **Blocked** | reachable desktop SQL Server + sanitised data + voucher pairing |
| G6 production certification | **Blocked** | named signers, shop-site hardware, live GSP/WhatsApp/SMS credentials |
| Device hardware (scale/scanner/camera/printer) | **Implemented, awaiting hardware** | protocols ported; works on arrival |

Migration mechanics are buildable and worth building; **migration correctness is not claimable from
synthetic fixtures** and the readiness gate must stay red until a signed rehearsal exists. A green
mechanics suite next to a red readiness gate is the intended, honest end state of Phase 7.

---

## 6. Track summaries

**Config (11 tasks).** Independent 130-key inventory from `schema.prisma`; discriminated typed field
union; option sets transcribed with citations (`LBR_TYPE` G/N/K/P at `UT_SETTING.cs:4252-4255`,
`HELP_SERCH` S/M/W/A at `:4272-4275`, `DEFAULT_REMINDER` R/B/O/S/W/D/M at `UT_SETTING_MAIN.cs:8444-8450`,
and ~40 more); anything unproven stays `UNKNOWN-OPTIONS` text with a TODO rather than a guessed enum;
dual-table atomic persistence; desktop tabs (`Setting1`, `Advance Cantrol`, `Setting3`) — **not** the
desktop's hardcoded password reveal at `UT_SETTING_MAIN.cs:9181-9188`.

**Transactions (17 Phase-1 tasks + 10 backlog).** One settlement engine (effective fine rate
`round(convRate/convPct*100,2)`, factor 10 for `T` / 1000 for `K`, `TR_TOUR_SALE.cs:12999-13046`) reused by
4 forms; `TR_TOUR_SALE` and `TR_BUL_SALE` are **separate builds** — `/txn/tour` is approval issue and
`/txn/bullion` is booking, so today's routes are not those forms; fine interest from
`TR_WH_SALE.cs:14735-14749`; voucher transfer from `tTrfrNo` at `TR_SALE.cs:20656`. Golden vector ids
assigned per formula. Bill profit deliberately blocked until every per-row cost branch is transcribed —
no generic "sale minus purchase".

**Masters (19 tasks).** Inventory reconciliation first; `formFields` resolver (P0-2); schema-real text
widths from `information_schema`; then the **18-operation repair console**, every operation with a DB test
that seeds broken data, previews an exact diff, applies, **reruns to prove idempotence**, and asserts
healthy rows byte-unchanged. Delete/convert-all-tag-stock (`MS_UPDATE.cs:32423-32464`) is isolated as a
danger-zone workflow: default-disabled, feature-flagged, verified backup, dual approval, two fresh
previews. Desktop's password reveal (`MS_USER.cs:2157-2168`) is replaced by forced reset + session
revocation, recorded as an explicit security waiver.

**Reports (16 tasks).** P0-1 first. Then S3/S4 rollout across all 50 families. XLSX:
**`write-excel-file@4.1.1`** (MIT, one dependency, no native deps). SheetJS `xlsx` is rejected on **supply
chain, not on the CVE**: `GHSA-4r6h-8v6p-xvw6` is a read-path bug that explicitly does not affect
write-only use, but the fix is 0.19.3+ while public npm stops at 0.18.5 and current builds ship from the
vendor's CDN. Formula-like strings (`=`, `+`, `-`, `@`) always emitted as text. Every report proven by seeding known vouchers and asserting exact rows and totals — never HTTP 200.
Commission modes transcribed exactly from `RP_EMP.cs:2044-2301`.

**Migration (33 tasks).** Export-first contract `datacare.legacy-export/1.0`: deterministic ZIP, `manifest.json`
+ `complete.json` written last, three-level checksums, canonical decimal **strings** (never IEEE-754), full
preflight in quarantine before any business write. Reconciliation proves row-for-row plus exact monetary and
metal-weight control totals by table, book and account. Tasks 22-32 (the 11 profiles) are **blocked** by
design. Existing live SQL Server `cutover.mjs` retained and hardened to fail closed.

---

## 7. Validation protocol (unchanged, extended)

```bash
cd web
npx prettier --write <touched>
(cd apps/api && npx tsc -p tsconfig.json --noEmit)
(cd apps/web && npx tsc -p tsconfig.json --noEmit)
(cd apps/api && npx vitest run)                 # 700 and rising
pnpm lint && npx prettier --check .
pnpm build --force                              # 7/7
node scripts/report-baselines.mjs               # REPORT_BASELINES_OK 254 — never --write
(cd apps/web && node test/browser.smoke.mjs)    # after build, separately
cd .. && python3 -B project-memory/parity/feature_gap_audit.py     # desktop-denominated
python3 -B project-memory/parity/deep_column_audit.py
python3 -B project-memory/parity/build_parity_matrix.py            # never pipe to /dev/null
```
Plus, as each is created: `pnpm settings:parity`, `pnpm parity:txn:ratchet`, `pnpm report-coverage`,
`pnpm master-management:parity`, `pnpm migration:readiness`.

Constraints that keep biting and must be respected: `python3 -B` (stale bytecode has frozen an audit);
assert every scripted edit landed (prettier reflow silently no-ops `replace()`); `tenant_id` is
`varchar(24)` so DB tests use short kebab tenants; **every statement in a DB test must run inside
`withTenant`** or RLS makes reads return 0 and `DELETE` a silent no-op; add every new write-set table to
every cleanup list; adding an API input field needs four edits including the payload.

---

## 8. What "complete" means

Complete is **not** "all gates green", because two gates cannot go green without external inputs. Complete is:

1. Phases 0-6 finished, all five new gates at target, all existing gates unregressed.
2. Phase 7 mechanics green **with `migration-readiness` red** and that redness correctly explained.
3. Crystal visual parity documented as a release blocker with the exact missing artifacts named.
4. G5/G6 mechanisms CI-wired and waiting on inputs, with no DEGRADED-mode artifact counted as evidence.

Anything claimed beyond that would be a claim I cannot back with a retained artifact.
