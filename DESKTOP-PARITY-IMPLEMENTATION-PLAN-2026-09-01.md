# Desktop→web parity implementation plan

Target: bring the web implementation to **operator-depth parity** with `DataCareNext.exe`.
Baseline: 33.9% operator field surface (1,731 / 5,107). Goal: 100%.

Companion documents (read both before starting):
- `DESKTOP-VS-WEB-RICHNESS-GAP-REPORT-2026-09-01.md` — what is missing and how it was measured
- `project-memory/parity/IDTL-REFERENCE.md` — every desktop sub-detail grid and its columns

---

## 0. How to use this plan

### 0.1 Ground truth locations

| What | Where | Notes |
| --- | --- | --- |
| Desktop source (authoritative) | `unified/src/csharp/DataCareNext/<FORM>.cs` | 204 files, 969,133 lines, decompiled C#. Every reference in this plan is `FORM.cs:line`. |
| Desktop second binary | `unified/src/csharp_nextdm/DataCareNext/` | `NextDm.exe`. **Out of scope** unless §14 decides otherwise. |
| Desktop real schema | `project-memory/parity/DESKTOP-REAL-SCHEMA.json` | 145 tables with column lists. |
| Desktop→web form mapping | `project-memory/parity/DESKTOP-WEB-PARITY-MATRIX.json` | 204 entries, `forms[].web.frontendFiles` / `.apiRoutes`. |
| Web frontend | `web/apps/web/app/(app)/**/page.tsx` | 101 pages, 66 under `/txn/`. |
| Web shared components | `web/apps/web/components/*.tsx` | 24 files. |
| Web API | `web/apps/api/src/modules/**/*.ts` | 193 files. |
| Web route surface | `web/apps/api/src/routes/txn.ts` | 5,358 lines — every transaction route. |
| Posting engine | `web/apps/api/src/modules/posting/posting.ts:508` | `postVoucherTx` — the single balanced-write path. |

### 0.2 Reading a desktop form

Decompiled WinForms follows fixed shapes. An agent must know these to extract requirements:

| Desktop construct | Meaning | Example |
| --- | --- | --- |
| `private TextBox _tAcCode;` | an operator input control | `TR_PURC.cs:124` |
| `private AxMSFlexGrid _MSG;` | a data grid (VB6 ActiveX) | `TR_PURC.cs:79` |
| `mSG.Cols = 88;` | that grid has 88 columns | `TR_PURC.cs:8700` |
| `mSG[0, 12] = "NetWt";` | column 12's header is `NetWt` | `TR_PURC.cs:8760` |
| `mSG[12] = 0;` | column 12 width/alignment (decompiler collapsed two indexers; **width 0 does not reliably mean hidden**) | — |
| `MSG_LeaveCell` / `EnterCell` / `RowColChange` | per-cell recalculation and row-sync hooks | `TR_SALE.cs:9400-9522` |
| `Interaction.MsgBox((object)"…", (MsgBoxStyle)0, …)` | a blocking validation message | `TR_PURC.cs:5488` |
| `(MsgBoxStyle)4 / 32 / 36` | Yes/No — an operator **decision point**, not a notification | `TR_PURC.cs:5491` |
| `DC_Main.Ms<Name>` | a company setting read at point of use | `TR_SALE.cs:16437` |
| `MS_HELP.ShowDialog()` | an F1 master lookup (944 call sites, 134 files) | `TR_SALE.cs:17296` |
| `ReportFileName = "X"` then `PrintReportDirect()` | Crystal print (`Module_Save.cs:106-155`) | 360 sites |

To extract a form's full requirement set:

```bash
F=TR_SALE_RTN
D=unified/src/csharp/DataCareNext
grep -nE "\.Cols\s*=\s*[0-9]+" $D/$F.cs                      # grids and their sizes
grep -nE "\[0,\s*[0-9]+\] = \"" $D/$F.cs                     # every column header
grep -nE "void .*_(LeaveCell|EnterCell|RowColChange)" $D/$F.cs # recalculation hooks
grep -nE "MsgBox\(" $D/$F.cs                                  # validations and prompts
grep -noE "DC_Main\.Ms[A-Za-z0-9_]+" $D/$F.cs | sort -u       # settings it honours
grep -nE "MS_HELP.ShowDialog|ReportFileName" $D/$F.cs         # lookups and prints
```

### 0.3 How the current web works

A transaction page is a client component that owns its own state and posts a JSON body.
There is no form library and **no zod** anywhere; validation is server-side only, via
`throw new <Domain>ValidationError('message')` (596 distinct messages, 46 `assert*`/`require*`
guard helpers).

```
apps/web/app/(app)/txn/<slug>/page.tsx     'use client', local useState, builds the body
        │  imports
        ├─ components/LookupPicker.tsx      F1 master picker (65 pages)
        ├─ components/GridKeyboard.tsx      arrows / Enter-advance / Ctrl+D (15 pages only)
        ├─ components/BookSelect.tsx        voucher book + scope
        ├─ components/TenderPanel.tsx       cash / cheque / card / UPI / kasar
        ├─ components/VoucherChrome.tsx     save / print / delete chrome
        └─ lib/api.ts                       fetch wrapper with token refresh (105 lines)
                │  POST /<domain>/<action>
                ▼
apps/api/src/routes/txn.ts                  auth → RBAC → containment → module call
                │
                ├─ modules/rbac/authorization.ts     View/Edit/Delete/Print per form+location
                ├─ packages/core/containment.mjs     503 fail-closed registry
                └─ modules/<domain>/<module>.ts      validate → compute → withTenant → write
                          └─ modules/posting/posting.ts:508  postVoucherTx (balanced, period-checked)
```

Three facts about this architecture drive the whole plan:

1. **`GlobalFormKeys` is already mounted app-wide** at `app/(app)/layout.tsx:54`, implementing
   F2, F3, F4, F5, F7, F8, F9, F11, F12. Function keys are *not* missing; F6 and F10 are.
2. **The API is much richer than the screens.** 1,993 input fields across 151 input
   interfaces; **192 are named by no frontend file at all**, so no screen can send them.
   `project-memory/parity/GAP-MANIFEST.json` lists every one.
3. **Five workflows are implemented and switched off.** `packages/core/containment.mjs`
   blocks them at 10 routes in `txn.ts` via `containMutation()`, returning 503.

### 0.4 Rules for the implementing agent

1. **Never invent a desktop behaviour.** Every field, default, formula and message must cite
   `FORM.cs:line`. If the desktop source does not show it, it does not go in.
2. **Follow the existing provenance comment convention.** `purchase.ts` already annotates
   fields as `// mSG_PR[i,4]  :13103`. Keep doing that — it is what made this audit possible.
3. **Do not widen an API contract that already has the field.** Check `GAP-MANIFEST.json`
   first. Most of Phase 3 is UI-only work.
4. **Never relax a gate to make a phase pass.** Floors rise, ceilings fall. Editing
   `depth-parity-baseline.json` to pass is visible in review as a baseline diff.
5. **A field is not done when it round-trips to the database. It is done when an unchanged
   reopen-and-save preserves it** — WP-08 found an unchanged save wiping 43 of 109
   `BAR_DETL` columns. Every phase's verification includes a round-trip assertion.
6. **Preserve every `assertOrigin`, RBAC check, period lock and RLS boundary.** Depth work
   must not become a security regression.

---

## 1. The verification contract

Depth is measurable, so no phase is certified by narrative. Five extractors re-derive every
number from source; one gate ratchets them.

| Script | Measures |
| --- | --- |
| `project-memory/parity/richness_desktop.py` | desktop forms, controls, grid columns, validations, settings, cell events |
| `project-memory/parity/richness_web.py` | web pages, inputs, grid columns, component adoption (follows `.tsx` imports to depth 3) |
| `project-memory/parity/richness_join.py` | per-form desktop↔web depth ratio |
| `project-memory/parity/settings_parity.py` + `settings_effect.py` | settings declared vs honoured vs inert, and whether the desktop honours them |
| `project-memory/parity/gap_manifest.py` | API input fields unreachable from any screen |

### 1.1 The gate

```bash
cd web
node scripts/check-depth.mjs             # ratchet: floors may only rise, ceilings only fall
node scripts/check-depth.mjs --phase P3  # certify a phase against targets declared up front
node scripts/check-depth.mjs --audit     # print the full derivation, no pass/fail
```

Verified behaviour at baseline:

| Invocation | Result |
| --- | --- |
| ratchet | passes — `surface 1731/5107 = 33.9%`, `grid cols 755/3508 = 21.5%` |
| `--phase P0` | passes (both targets met) |
| `--phase P2` | **exit 1**, naming all four unmet targets |
| `--phase P99` | **exit 2** — a phase with no declared target cannot be certified |

Floors (may only rise): `web.operatorSurface`, `web.gridColumns`, `web.inputControls`,
`web.txnPagesWithGridKeyboard`, `web.pagesWithLineRecalc`, `web.pagesWithSubDetailGrid`,
`web.apiValidationMessages`, `reports.runnableSlugs`, `ratios.operatorSurfacePct`,
`ratios.gridColumnPct`, `settings.honoured`, `reachability.reachableFromUi`.

Ceilings (may only fall): `settings.inert`, `reachability.apiOnlyUnreachable`,
`containment.operations`, `containment.blockedRoutes`.

The desktop side is pinned: if any desktop number moves, the gate fails with
`DESKTOP BASELINE MOVED`, because every target in this plan is a ratio against it.

### 1.2 Why these metrics and not others

The project already had two gates that both reported near-parity while the product was at
one third depth:

- `DEPTH-SCOREBOARD.md` measured **persisted DB columns** → 98.9%.
- `scripts/check-settings-parity.mjs` measured **settings exposure** → complete.

Neither could see whether an operator can reach a field, or whether a setting changes an
outcome. `check-depth.mjs` measures exactly those two things. It complements, and does not
replace, the existing gates — all of them stay in `RELEASE_GATES`.

### 1.3 Standing verification, run after every task

```bash
cd web
npx tsc -p apps/api/tsconfig.json --noEmit
NODE_OPTIONS=--max-old-space-size=6144 npx tsc -p apps/api/tsconfig.test.json --noEmit
npx tsc -p apps/web/tsconfig.json --noEmit
npx prettier --check .
cd apps/api && TZ=UTC \
  MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public&options=-c%20timezone%3DUTC' \
  DATABASE_URL='postgresql://app_user@127.0.0.1:55433/datacare?schema=public&options=-c%20timezone%3DUTC' \
  npx vitest run
cd .. && node scripts/check-depth.mjs
```

`TZ=UTC` **and** the `options=-c%20timezone%3DUTC` query parameter are both required: the
container session TZ is `Asia/Kolkata` and ~27 clock assertions fail spuriously without them.
Baseline to beat: **155 test files / 1,310 tests passing**.

### 1.4 The end-to-end depth test every phase must extend

Counting fields proves a screen renders them. It does not prove they survive a save. Each
phase adds cases to one shared round-trip test so depth is proven behaviourally.

Create `web/apps/api/test/operatorDepth.roundtrip.db.test.ts` in P0. Its contract, for every
workflow touched by a phase:

1. POST a voucher with **every** field the screen can now supply, each a distinct
   non-default value.
2. GET the voucher back.
3. Assert every supplied field returns equal — no silent drops.
4. PUT the unmodified payload back.
5. Re-GET and assert byte-equality with step 2, and that no `VCH_SRNO` or serial changed.
6. Where the desktop posts derived rows, assert those too (`MAIN_STOCK`, `AC_DATA`,
   `BOOK_DETL`, `*_IDTL`).

This is the test that catches the WP-08 class of defect (unchanged save wiping 43 columns)
and the "API accepts it, screen never sends it" class simultaneously.

---

## 2. Phase ladder

Ordered by depth gained per unit of risk. P1–P3 are mostly wiring against engines that already
exist and are already tested, so they buy the most depth for the least new surface area.

| Phase | Title | Key exit targets | Surface |
| --- | --- | --- | ---: |
| P0 | Verification infrastructure | gate + round-trip harness live | 1,731 |
| P1 | Suppression bugs & keyboard | `txnPagesWithGridKeyboard ≥ 66` | 1,731 |
| P2 | Shared sub-detail grid | `pagesWithSubDetailGrid ≥ 12`, `gridColumns ≥ 1000` | 2,050 |
| P3 | Wire every field the API accepts | `apiOnlyUnreachable ≤ 40` | 2,200 |
| P4 | Honour the offered settings | `settings.honoured ≥ 105`, `inert ≤ 25` | — |
| P5 | Per-cell recalculation kernel | `pagesWithLineRecalc ≥ 66` | 2,250 |
| P6 | Discharge tag containment | `containment.operations ≤ 2` | — |
| P7 | Grid column completion | `gridColumns ≥ 2400`, `gridColumnPct ≥ 68` | 3,400 |
| P8 | Missing workflows and screens | `pages ≥ 118` | 4,000 |
| P9 | Report parity | `runnableSlugs ≥ 62` | — |
| P10 | Masters depth | `apiValidationMessages ≥ 700` | 4,600 |
| P11 | Parity certification | `operatorSurfacePct ≥ 100`, `gridColumnPct ≥ 100` | 5,107 |

All targets are pre-declared in `web/parity/depth-parity-baseline.json`. Do not add a target
after doing the work.

---

## 3. P0 — Verification infrastructure

No feature change. Nothing after this point is trustworthy without it.

### P0-1 Register the depth gate

**Files:** `web/package.json`, `web/apps/api/src/modules/ops/releaseCertification.ts`,
`web/.github/workflows/release-certification.yml`

- Add script `"depth:parity": "node scripts/check-depth.mjs"`.
- Append to `RELEASE_GATES` (pattern at `releaseCertification.ts:355`):
  `{ id: 'operator-depth', command: 'node scripts/check-depth.mjs' }`.
- The gate already exists and is verified; this task only wires it into CI and release.

**Verify:** `pnpm depth:parity` passes; `node scripts/release-certify.mjs` lists
`operator-depth` among its gates.

### P0-2 Create the round-trip depth harness

**File (new):** `web/apps/api/test/operatorDepth.roundtrip.db.test.ts`

Implement the six-step contract in §1.4. Seed with three workflows that already have rich
API contracts, to prove the harness catches real drops before it is relied on:

| Workflow | Module | Why first |
| --- | --- | --- |
| purchase | `modules/purchase/purchase.ts` | 169 input fields, 98.2% reachable — a good control |
| tag opening | `modules/stock/stockVoucherLifecycle.ts` | WP-08 already found a 43-column drop here |
| karigar receive | `modules/manufacturing/karigar.ts` | shared-component page, tests the composition path |

**Verify:** the three cases pass. Then deliberately delete one field from the purchase
reader's `SELECT`, confirm the test **fails**, and restore it. A harness that cannot fail is
not a harness.

### P0-3 Record the per-form depth budget

**File (new):** `web/parity/depth-budget.json`

For each of the 153 desktop forms with measurable surface, record `desktopSurface`,
`webSurface`, the owning phase, and the target. Generate from `RICHNESS-JOIN.json` rather
than typing it:

```bash
cd project-memory/parity && python3 richness_join.py > RICHNESS-JOIN.json
```

**Verify:** the per-form targets sum to ≥ 5,107 so the ladder actually reaches parity.
This is an arithmetic check on the plan itself — run it and fix the plan if it fails.

### P0 exit

```bash
node scripts/check-depth.mjs --phase P0     # must pass
```
Plus: full suite green (155 files / 1,310 tests), three typechecks clean, prettier clean.

---

## 4. P1 — Suppression bugs and keyboard completion

Small, high-value, low-risk. Three bugs where **the client actively disables working server
logic**, so the numbers are wrong today in production.

### P1-1 Dhiran interest is always zero

**Desktop:** interest mode is chosen by book, with compound default from `MsDhrnCompound`
(`TR_DHRN_REC.cs:5626-5643`, `:5704-5714`); months/days/rate exposed at `:5740-5815`.

**Current web:** `modules/dhrn/dhrn.ts:564-566` and `:757-760` auto-compute interest **only
when `input.interest` is absent**. Both pages always send a number:
- `app/(app)/txn/dhrn-receipt/page.tsx:102-108` → `interest: Number(interest || 0)`
- `app/(app)/txn/dhrn-interest/page.tsx:59-66` → same

So a blank field means "explicitly zero interest", and the monthly/daily/compound engine
never runs.

**Change:** send `interest` only when the operator typed one — `interest: interest === '' ?
undefined : Number(interest)`. Add a read-only "computed interest" display fed by a preview
call so the operator sees what the server will charge, plus the resolved mode, day basis and
compound flag.

**Also:** `dhrn-issue/page.tsx:68-70,152-164` hardcodes `months × 30 / 360` and labels the
field "Annual Int %", but monthly mode treats the percentage as monthly
(`dhrn.ts:317-322`); and `:87-100` always sends `intPrc`, defeating the configured
`DHRN_PRC` fallback at `dhrn.ts:303-307`. Fix both.

**CORRECTION TO THIS PLAN, found while implementing.** The claim that "monthly mode treats the
percentage as monthly" is **false**. `desktopDhrnInterest` (`settingsBehavior.ts`) uses
`annualRatePct` genuinely annually: `days` is `months × 30` in monthly mode, then interest is
`base × (rate/100) × (remainder / intYearDays)`. The "Annual Int %" label was already correct and
was left alone.

The real defect on that page was only the `intPrc` payload: `dhrn.ts:306` resolves
`input.intPrc ?? cfg.dhrnDefaultRate`, and because the rate guard accepts zero, sending
`Number(intPrc || 0)` silently issued a **zero-interest loan** rather than using the company
default. Now omitted when blank. The preview was additionally relabelled "Approximate interest",
since it models only the simple case and ignores `INT_YEAR_DAYS` and `DHIRN_COMPOUND`.

**IMPLEMENTED.** Also removed `required` from the interest-only field — it forced the operator to
type a figure, so the calculation could never run even after the payload was fixed.

**Verify:** three DB tests in `test/dhrnReceipt.db.test.ts`: interest omitted computes a positive
figure; interest supplied overrides it exactly; and an omitted issue rate falls back to
`CO_SET.DHRN_PRC` (12) producing positive interest while an explicit `intPrc: 0` produces zero —
so the fallback is distinguishable from the bug it replaces.

A fixture trap worth recording: `DhrnIssueInput` dates the voucher from **`fromDate`**, not
`vchDate`. Passing `vchDate` silently dated the loan today, making the interest window negative and
the computed interest zero — indistinguishable from the defect under test.

### P1-2 Jobwork/karigar labour is never derived

**Desktop:** labour derives from type and rate over pieces, gross, or `(Net+Ghat)`
(`TR_KR_ISU.cs:4025-4129`; `TR_JDT_REC.cs:4442-4550`).

**Current web:** `components/KarigarForm.tsx:242` always sends a numeric `lbrAmt`, including
`0`. `modules/manufacturing/mfg.ts:448-458` treats any supplied `lbrAmt` as an override, so
`lbrType`/`lbrRate` are dead.

**Change:** omit `lbrAmt` unless the operator typed it. Expose `lbrType` and `lbrRate` in
issue mode (currently hidden).

**IMPLEMENTED, and it uncovered a deeper defect.** Omitting `lbrAmt` was necessary but not
sufficient: `karigar.ts` wrote `LBR_AMT: num(l.lbrAmt)` **straight through, with no derivation at
all** — unlike the job-work path it had no `labourAmount()` fallback, so `LBR_TYPE` and `LBR_RATE`
were persisted but never used. A karigar line could read "per gram at 50" and be charged nothing.
This is why job-work and karigar disagreed on identical input.

Fixed with a single `lineLabour()` helper in `karigar.ts` reusing `mfg.ts`'s `labourAmount` (no
import cycle exists), applied at all four consumption sites: the detail row, `NET_AMT`, the
per-line labour total and the edit path.

**Verify:** DB test — post with `lbrType='N'`, `lbrRate=50`, no `lbrAmt`; assert persisted labour
equals `(net + ghat) × 50 = 950`. Assert an explicit `lbrAmt` of `111.11` still wins. Both pinned
in `test/mfgLifecycle.db.test.ts`.

### P1-3 Karigar issue loses wastage

**Desktop:** issue fine is `((Net + Ghat) × (Touch + West) / 100) − LessWt`
(`TR_KR_ISU.cs:3933-3977`).

**Current web:** `KarigarForm.tsx:155-156` previews `Net × Touch / 100`, and `:202-211` omits
`westPct` from the issue payload, so persisted issue fine drops wastage even though the
server policy at `modules/shared/finePolicy.ts:35-45` supports it.

**Change:** add `westPct` to the issue payload and to the preview formula.

**Verify:** DB test — issue with `touch=91.6`, `westPct=2`; assert fine matches the desktop
formula, not the touch-only one.

### P1-4 Complete the function-key contract

**Desktop:** the menu shows 11 captions (`MDI_FORM.cs:5571-5601`), but the key handler binds only
VK 113-120 and 122-123 (`MDI_FORM.cs:12462-12525`) — that is F2-F9, F11, F12, **and F6 (VK 117)**.

**IMPLEMENTED, with a correction to this plan.** F6 was genuinely missing and is now bound to
`/txn/wholesale-sale`, matching `ShoF6WhSales_Click` → `TR_WH_SALE` (`MDI_FORM.cs:12486-12489`).

**F10 was NOT added.** This plan originally said to add it. That was wrong: VK 121 has no branch in
the desktop handler, so F10 does nothing on the desktop despite the "F10 Reminder" caption. Binding
it would have invented behaviour — a parity claim in the wrong direction. `FormKeys.tsx` records
why, and `test/formKeys.test.ts` now derives the expected key set from the desktop's bound VK codes
(`DESKTOP_BOUND_VK`), so neither dropping F6 nor adding F10 can pass.

### P1-5 Mount `GridKeyboard` on every operator-authored grid

**IMPLEMENTED: 50 of 50.** The target in this plan was corrected twice, both times because the
metric was cruder than the intent. Recording the sequence because the same trap applies to later
phases:

| Stated target | Why it was wrong |
| --- | --- |
| all 66 txn pages | 7 are header-only vouchers with no rows (`bullion`, `dhrn-interest`, `dhrn-receipt`, `employee-jv`, `fine-jv`, `ledger-adjust`, `scheme`) |
| all 59 pages with a `<tbody>` map | 9 of those are read-only or fetched-data tables — bank reconciliation, the rate matrix, the scanned-tag list, reminders — where arrow/append/remove has nothing to act on |
| **50 pages holding a row array + a blank-row factory** | the grids an operator actually authors |

A second measurement error surfaced: the prior adoption count was **14, not 15**. `purchase` had
been counted because `ExtendedGrid.tsx`'s doc comment contains the string `useGridKeyboard`.
Detection now requires an invocation (`useGridKeyboard\s*\(`), and `LookupPicker`/`SubDetailGrid`/
`VoucherTotals` likewise require a JSX element rather than a mention.

**The enabling change was in the hook, not the pages.** Adoption had stalled at 14 because mounting
meant hand-adding `data-grid-row`/`data-grid-column` to every cell of every grid. `GridKeyboard.tsx`
now falls back to deriving row and column from table geometry (`locateCell`, `focusPositionalCell`),
counting rows within `<tbody>` so a header row cannot shift them. Explicit attributes still win where
a page numbers its grid differently. Adoption became a five-line change per page, applied by
`scripts/mount-grid-keyboard.py` for the 24 pages matching the standard shape, plus
`KarigarForm.tsx` and `PaymentForm.tsx` (six pages between them) and six hand-wired outliers
(`tag-split`, `wholesale-sale`, `sales-order`, `fine-sale`, `melting` — two grids — and
`bill-to-bill`'s tender split).

**Verified:** `node apps/web/test/route-coverage.mjs` renders **99/99** routes including client
hydration, so none of the 31 edited files broke.

### P1 exit

```bash
node scripts/check-depth.mjs --phase P1
```
Plus three new DB tests (P1-1..P1-3) green, and `web.operatorSurface` not below 1,731.

---

## 5. P2 — The shared sub-detail grid

The single largest gap class. **38 sub-detail grids across 35 desktop forms; the web renders
zero**, while seven API modules already persist them.

Full column reference: `project-memory/parity/IDTL-REFERENCE.md`.

### P2-0 What already exists server-side

`modules/shared/stoneSubDetail.ts` (110 lines) already implements the shared `*_IDTL` column
block for `SL_ORD_IDTL`, `KR_IDTL`, `BAR_CAN_IDTL`, `PR_IDTL` and `APR_IDTL`, with both the
customer-side (`IT_*`) and karigar-side (`KR_*`) valuation — its own header explains that
dropping the `KR_*` block leaves karigar settlement with no basis for the stone portion.

Modules that already accept a sub-detail array:

| Module | Field | Interface |
| --- | --- | --- |
| `purchase/purchase.ts:133` | `stones?` | `PurchaseStoneInput` |
| `manufacturing/karigar.ts:132` | `stones?` | `KarigarStoneInput` |
| `manufacturing/mfg.ts:287` | `components?` | `MfgComponent` |
| `tour/tour.ts:87` | `stones?` | `TourStoneInput` |
| `stock/tagOps.ts:80` | `stones?` | `TagCancelStoneInput` |
| `sales/vpParcel.ts:75` | `components?` | `VpParcelComponentInput` |
| `sales/wholesaleSaleReturn.ts:80` | `components?` | `WholesaleSaleReturnComponentInput` |

So P2 is **UI work plus two new API arrays** (sales and sale-return), not seven new engines.

### P2-1 Build `SubDetailGrid`

**File (new):** `web/apps/web/components/SubDetailGrid.tsx`

The shared column core, from the union in `IDTL-REFERENCE.md` (count = desktop forms using it):

| Group | Columns |
| --- | --- |
| identity (24–25 forms) | `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `DmColor`, `DmOrigin`, `DmRemark` |
| item (36–37) | `ItCode`, `ItName`, `ItType` |
| quantity (14–37) | `Pcs`, `PcsWt`, `Weight` |
| customer valuation (35–36) | `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt` |
| karigar valuation (10–28) | `KrWt`, `KrLs%`, `KrConWt`, `KrCon%` |
| row identity (35) | `Sr`, `RowSrNo` |

Requirements:
- Column set is **prop-driven** — a form passes the subset its desktop grid declares. Do not
  render all 22 everywhere; `TR_SALE`'s `MSG_IDTL` has 24 columns, `TR_TAG_OPBL`'s has 41.
- Must accept the form-specific tail (`MotiPs`, `MotiWt`, `BrkPcs`, `BrkWt`, `RtnPcs`,
  `RtnWt`, `OldKrWt`, `OldGrWt`, `PRate`, `PAmt`, `OrdPcs`) as extra column descriptors.
- Rows attach to a parent line index; adding/removing a parent line must cascade
  (desktop does this at `TR_PURC.cs:6887-6905`).
- Compose `GridKeyboard` and `LookupPicker` so P1's keyboard contract holds inside it.

**Verify:** component test — render with `TR_PURC/MSG_IDTL`'s 34 columns and assert 34 header
cells; render with `TR_SALE/MSG_IDTL`'s 24 and assert 24. Column lists come from
`IDTL-REFERENCE.md`, not hand-typed.

### P2-2 Adopt on the twelve pages whose API already accepts it

| Page | Desktop grid(s) | Named cols | API field |
| --- | --- | ---: | --- |
| `txn/purchase` | `TR_PURC/MSG_IDTL` + `MSG_PR_IDTL` | 34 + 25 | `stones` (exists) |
| `txn/purchase-hm` | `TR_PURC_HM/MSG_PR_IDTL` | 23 | `stones` (exists) |
| `txn/karigar-issue` + `karigar-receive` | `TR_KR_ISU`, `TR_MFG_KR_ISU_REC/MSG_IDTL` | 24 | `stones` (exists) |
| `txn/jobwork-issue` + `jobwork-receive` | `TR_JDT_REC/MSG_IDTL` | 16 | `components` (exists) |
| `txn/mfg-issue` + `mfg-receive` | `TR_MFG_ISU_REC`, `TR_MFG_ORD_REC/MSG_IDTL` | 22 / 28 | `components` (exists) |
| `txn/tour` | `TR_APR_ISU/MSG_IDTL` | 21 | `stones` (exists) |
| `txn/tag-cancel` | `TR_TAG_CAN` sub-grid | 17 | `stones` (exists) |
| `txn/vp-parcel` | — | — | `components` (exists) |
| `txn/wholesale-sale-return` | `TR_WH_SALE_RTN/MSG_PR_IDTL` | 30 | `components` (exists) |

Note `karigar-issue`/`karigar-receive` and `jobwork-*` share `KarigarForm.tsx`; `payment`/
`receipt` share `PaymentForm.tsx`. Edit the component once.

**Verify per page:** add a case to `operatorDepth.roundtrip.db.test.ts` posting two
sub-detail rows under two different parent lines, asserting they return with correct parent
linkage and survive an unchanged re-save. Then delete a parent line and assert its children
are removed, not orphaned.

### P2-3 Add the two missing API arrays

`TR_SALE/MSG_IDTL` (24 cols, `SL_IDTL`) and `TR_SALE_RTN/MSG_IDTL` + `MSG_RTN_IDTL`
(24 + 24) have no web array. Add `stones?: StoneSubDetailInput[]` to `SaleLineInput`
(`modules/sales/sales.ts`) and `SaleReturnLine` (`modules/sales/salesReturn.ts`), persisting
through `stoneSubDetail.ts` exactly as `purchase.ts:953` does.

Desktop write references: `TR_SALE.cs:8007-8103` (grid), sale `SL_IDTL` write path; return
`TR_SALE_RTN.cs:2911-3007` and `:5208-5305`.

**Verify:** DB test asserting `SL_IDTL` rows exist with both `IT_*` and `KR_*` blocks
populated, and that `postVoucherTx` still balances.

### P2 exit

```bash
node scripts/check-depth.mjs --phase P2
```
Targets: `pagesWithSubDetailGrid ≥ 12`, `gridColumns ≥ 1000`, `operatorSurface ≥ 2050`,
`apiOnlyUnreachable ≤ 150`.

---

## 6. P3 — Wire every field the API already accepts

192 input fields are accepted by a server contract and named by **no** frontend file.
Authoritative list: `project-memory/parity/GAP-MANIFEST.json` (`worstInterfaces`, then
`interfaces` for the full set).

### P3-0 Triage first — not all 192 are defects

Three classes; only the first is work:

| Class | Action | Examples |
| --- | --- | --- |
| operator field with no control | **build the control** | `MfgLine.karigarMinorityWt`, `EnrollSchemeInput.nomineeName` |
| server-derived, correctly absent | mark `@serverDerived` in a comment, exclude from the ceiling | `IrnItemInput.assAmt` (computed from lines), `RequestLogInput.durationMs` |
| internal plumbing, never operator input | move out of an `*Input` interface | `RequestLogInput.correlationId/tenantId`, `FieldAuditInput.originalUser` |

Record the triage in `web/parity/depth-budget.json` so the P3 target of ≤ 40 is auditable
rather than arbitrary. Do **not** widen the interface name convention to hide fields.

### P3-1 `MfgLine` — 27 of 63 unreachable (largest single block)

**File:** `modules/manufacturing/mfg.ts:239-319`. Consumers: `txn/mfg-issue`,
`txn/mfg-receive`, `txn/mfg-order-issue`, plus `KarigarForm.tsx` for jobwork.

Unreachable, grouped, with the desktop grid that owns each:

| Group | Fields | Desktop source |
| --- | --- | --- |
| issue-vs-receive reconciliation | `totalGrossWt`, `totalLessWt`, `oldGrossWt`, `oldFine`, `oldLabourAmount`, `oldOther` | `TR_MFG_ISU_REC.cs:2883-2956` (`DifP`, `DifWt`, issued weights) |
| karigar job-work side | `karigarJobworkWt`, `karigarMinorityWt`, `karigarMinorityAmount` | `TR_MFG_KR_ISU_REC.cs:5824-5900` (minority/casting balances) |
| process losses | `rtnChol`, `rtnGhis`, `itmGhat` | `TR_MFG_ORD_REC.cs:3279-3429` (`Chole`, `Ghis`, `TotGht`) |
| material issue | `mtrlWt`, `mtrlItCode`, `addOtherWt`, `lessOtherWt`, `fittingItCode`, `isuItCode` | `TR_MFG_ORD_REC.cs:4726` — `DifWt = IsNwt − (NetWt+GhtWt+Chole+Ghis+MtrlWt)` |
| stone roll-up | `dmPcs`, `dmWt` | `TR_MFG_ORD_REC.cs:3499-3598` |
| order/design provenance | `designSrNo`, `adjustDate` | `TR_MFG_ORD_REC.cs:3292-3304` |
| repair linkage | `repYrcd`, `repDbcd`, `repNo`, `repSrno`, `repAcCode` | repair issue/receipt link |

The desktop difference formula is the acceptance criterion: with all operands supplied,
`DifWt` must reconcile to the desktop value. Today `mfg-receive/page.tsx:55-59` previews only
`net + ghat + loss`, so it cannot.

**Verify:** DB test reproducing `TR_MFG_ORD_REC.cs:4726` exactly — assert the computed
difference equals `IsNwt − (NetWt + GhtWt + Chole + Ghis + MtrlWt)` for a seeded case, and
that the value round-trips.

### P3-2 `EnrollSchemeInput` — 18 of 35 unreachable

**File:** `modules/membership/scheme.ts`. Page: `txn/scheme`.

`itemGrossWt, phone2, mobile2, district, email, idProof, nomineeName, birthDate,
anniversaryDate, lastBrokenDate, joinDate, expiryDate, bankArea, bankAcNo, bankRtgsNo,
refCode, schemeShort, membBonus`

**Desktop:** `TR_MEMB_ENT.cs:251-279` and `:3075-3136` (main 15-column grid incl. rate,
gross weight, cheque, bank, mobile); `:4555-4600` (`AD_DATA` write).

Also add the desktop's **UPI split grid** (`TR_MEMB_ENT.cs:2367-2397`, 8 columns:
`AcCode, Upi Bank Name, UpiType, Upi Id, UpiAmt, RowSrNo, MemberCode`) which writes
`UPI_DATA` at `:4620-4655`. The web currently has only a `withUpi` boolean and writes no
`UPI_DATA` (`scheme.ts:321-378`) — this needs the array **and** the write.

Birthday/anniversary are not decoration: `RP_REMINDER.cs:1303-1598` drives reminders from
them, which is P9.

**Verify:** DB test asserting `AD_DATA` carries the demographic and bank columns, and that
two `UPI_DATA` rows persist with correct `RowSrNo` and member linkage.

### P3-3 `RateCutInput` / `RateCutLine` — 14 unreachable, plus the missing receive side

**File:** `modules/sales/rateCut.ts`. Page: `txn/rate-cut`.

Unreachable: `add1, add2, add3, hdVchNo, settleDrAmt, settleCrAmt, settleDrFine,
settleCrFine` (header) and `adjustWt, silverFine, issueLcCode, mcxRate, hallmarkFine, isuRef`
(line). The page sends only cash and kasar (`rate-cut/page.tsx:112-133,296-319`).

**Desktop:** `TR_BUL_SALE.cs:9889` — `MSG2_TOTAL` has explicit `Payment` and `Received`
columns, rows `Net, Tax, TDS, Total, Cheque, Card, Cash, Kasar, Outstanding` (`:9981-9992`);
two-sided TDS at `:8880-8893`. MCX rate and premium are separate line columns
(`:5716-5887`).

Two further items are **not** wiring and move to P8:
- the 50-column receive/purchase grid `MSG_PR` (`TR_BUL_SALE.cs:4155-4286`) — `rateCut.ts:1078`
  never writes `RATE_CUT_REC`;
- booking draw-down: desktop maintains `BUL_DATA.ADJ_WT` on save, edit and delete
  (`TR_BUL_SALE.cs:8816-8818`, `:9101-9103`, `:9202-9204`); the web has no `UPDATE BUL_DATA`,
  so booking availability silently drifts. **This is a data-integrity defect, not a depth
  gap** — fix it in P3 even though the grid waits for P8.

**Verify:** DB test — post a rate cut against a booking, assert `BUL_DATA.ADJ_WT` increased
by the cut weight; delete the voucher, assert it returned to its prior value.

### P3-4 Remaining interfaces

| Interface | File | Unreachable | Desktop reference |
| --- | --- | ---: | --- |
| `TourIssueLine` | `tour/tour.ts` | 7 (`adjustGrossWt`, `adjustNetWt`, `isuAcCode/Name`, `isuLcCode`, `metalColor`, `stones`) | `TR_APR_ISU.cs:3058-3276`, `:143-163` (issue source) |
| `SchemeAdjRojmelLine` | `shared/rojmel.ts` | 6 | scheme adjustment rojmel rows |
| `BatchReceiptLineInput` | `finance/batchReceipt.ts` | 4 (`bankCharges`, `chqPrintName`, `clearDate`, `itemDescriptionCode`) | cheque clearing workflow |
| `FineJvRojmelLine` | `shared/rojmel.ts` | 4 | fine JV rojmel rows |
| `ClosingStockInput` | `reports/closingStock.ts` | 3 | `RP_BALANCE.cs:2675-2708` valuation inputs |
| `DesignBookLine` | `masters/designBook.ts` | 3 | `MS_DESIGN_BOOK.cs:2004-2149` (deferred to P10) |
| `ItemOpeningLine` | `stock/stockVoucherLifecycle.ts` | 3 | `TR_TAG_OPBL.cs` |

Also wire the **balance-sheet valuation inputs** the API already accepts —
`closingDate`, `goldRate`, `silverRate`, `ledgerFineGold`, `ledgerFineSilver`
(`routes/txn.ts:4296-4308`) — which the generic report page never renders. Desktop equivalent:
`RP_BALANCE.cs:2675-2708`.

### P3 exit

```bash
node scripts/check-depth.mjs --phase P3
```
Targets: `apiOnlyUnreachable ≤ 40`, `reachableFromUi ≥ 1953`, `operatorSurface ≥ 2200`.
Plus: every remaining unreachable field has a recorded triage class.

---

## 7. P4 — Honour the settings the UI already offers

74 settings are editable, persisted and read by nothing. **66 of them the desktop honours.**
Full list with per-setting desktop reader counts: `project-memory/parity/SETTINGS-EFFECT.json`
(`realGaps`).

### P4-0 Establish the pattern

The web already has the right seam: `modules/shared/settingsBehavior.ts` (39 typed fields
from 36 keys) loaded once per request and passed into domain modules. Every setting below
gets a field there, resolved from `CO_SET`/`CO_SET_NEW`, then read at the point of use — never
from a request body.

Add a companion test file `web/apps/api/test/settingsEffect.db.test.ts` whose contract is:
**for each newly honoured setting, run the same voucher twice with the setting flipped and
assert the outcomes differ.** A setting that produces identical results under both values is
not honoured, whatever the code looks like.

### P4-1 Stock and weight controls (highest business risk)

| Setting | Desktop readers | Behaviour | Desktop reference |
| --- | ---: | --- | --- |
| `NEGATIVE_STK_SALE` | 7 | allow/refuse a sale below stock. Web guards tagged identity via `issueTagTx` (`sales.ts:879-892`) but writes loose `MAIN_STOCK` out rows unchecked (`:1105-1142`) | `TR_SALE.cs:10398` "Negative Stock is Not Allow"; `TR_SALE_HM.cs:7381` |
| `SL_NWT_LOCK` | 11 | lock net weight against operator retyping on sale lines | reader forms per `SETTINGS-EFFECT.json` |
| `ITM_FINE_LOCK` | 3 | lock computed fine | — |
| `SL_TAG_WT_DIFF` | 2 | permit sale when tag weight differs | — |
| `ORD_TAG_STK_LESS` | 3 | allow an order to reduce tag stock | — |
| `STK_LMIT_WITH_DESIGN` | 5 | apply stock limits per design | — |
| `ITM_WITH_LOT_STK` | 10 | lot-wise stock tracking | ties to P8 lot manufacturing |
| `PURC_LOT` | 6 | lot entry on purchase | — |
| `TOT_FINE_STK_TYPE` | 2 | fine stock aggregation basis | — |

**Verify:** for `NEGATIVE_STK_SALE` specifically — seed one unit of loose stock, sell two;
assert refusal when `'N'` and success when `'Y'`. This is the case that can lose real money.

### P4-2 Tax and pricing controls

| Setting | Desktop readers | Behaviour |
| --- | ---: | --- |
| `PURC_WITH_HMTAX` | 31 | gate hallmark tax on purchase. Web always computes it when `hmAmount` is present (`purchase.ts:678-683`) |
| `SALES_WITH_HMTAX` | 28 | same on sales (`sales.ts:753-758`) |
| `PR_TDS_TAX` | 3 | expose/persist purchase TDS. Desktop writes blank/zero when off (`TR_PURC.cs:12160-12172`, `:12990-13003`) and recalculates on change (`:15491-15498`); web always posts TDS (`purchase/page.tsx:182-194`) |
| `ESTMATE_TAX` | 3 | tax on estimates |
| `ESTMATE_BANK_LOCK` | 23 | lock bank account on estimates |
| `SL_MRP_TAX_REVERC` | 2 | MRP-inclusive tax reversal |
| `OLD_PURC_TOUCH` | 5 | old-gold purchase touch default |
| `OLD_GOLD_TYPE` | 1 | old-gold classification |
| `LBR_WITH_GHT` | 23 | include ghat in the labour base |
| `OTH_ITM_WT_REMOVE` | 3 | exclude other-item weight |
| `SILVER_THREE_DIGIT` | 11 | silver weight precision — **a rounding change; route it through `packages/core/src/money.ts` and `shared/roundingPolicy.ts`, never a local helper** |

`purchase-hm/page.tsx:91-106` also never sends `hmTaxPct`, so it silently defaults to bill
GST (`purchase.ts:678`). Fix with `PURC_WITH_HMTAX`.

**Verify:** flip each of `PURC_WITH_HMTAX` and `SALES_WITH_HMTAX` and assert the posted tax
rows differ. For `SILVER_THREE_DIGIT`, assert against the kernel — WP-06 proved local helpers
round negative midpoints toward `+∞` (`-1.005` → `-1` vs kernel `-1.01`).

### P4-3 Workflow, posting and document controls

| Setting | Readers | Behaviour |
| --- | ---: | --- |
| `BRANCH_ALL_AC_SHOW` | 68 | widen account lookups company-wide while the voucher stays in its location. Desktop: `TR_SALE.cs:17296-17320`, `:17354-17385` — when off at a non-`00` branch it combines system accounts `<100` with local accounts `≥200` |
| `EMP_AS_USER` | 57 | treat employee as the user identity |
| `VCH_DESC_HELP_LENT` | 41 | voucher-description helper length |
| `CUR_DAY_POSTING` | 3 | restrict posting to the current day |
| `DUP_PRINT` | 23 | duplicate/triplicate print copies. `VoucherChrome.tsx:151-167` can already render a copy selector but no page supplies `printCopies`, and sales hard-codes `copy=O` (`sales/page.tsx:1460-1480`). Desktop: `TR_SALE.cs:16437-16449`, `MS_PRINT.cs:389-424`, copies flow to Crystal at `Module_Save.cs:150-155` |
| `TAG_AUTO_PRINT`, `TAG_VCH_AUTO_SAVE`, `TAG_ENTRY_DESIGN_GEN` | 2–4 | tag entry automation |
| `QR_CODE_GEN` | 7 | QR on documents. Desktop `TR_TAG_OPBL.cs:9189-9217` |
| `SL_BILL_IMG`, `WH_BILL_IMG`, `ORD_IMG_PRINT`, `DHRN_IMG_PRINT`, `APR_IMG_PRINT`, `KR_DESIGN_IMG_PRINT` | 2–4 | bill-image layouts. Desktop: `TR_PURC.cs:12716-12721`, `TR_APR_ISU.cs:6742-6767` (`AprBillImg.RPT`) |
| `OS_BILL_SMS`, `WAPP_SL_PRINT`, `WAPP_IMG_GWT`, `DEFAULT_REMINDER`, `REMINDER_OPEN` | 1–7 | messaging and reminders |
| `F_DISC_DATE`, `T_DISC_DATE`, `OS_FINE_INT` | 1–3 | discount windows, outstanding fine interest |
| `DESIGN_HELP`, `MOBILE_HELP`, `RATE_MAST_OPEN`, `USER_KR_TOUCH_HIDE`, `YEAR_GOLD_SL`, `YEAR_SILVER_SL`, `COUNTRY_ID` | 1–35 | lookup and display behaviour |

### P4-4 UI-preference settings

15 more, led by `THEME` (152 desktop forms), `MAIN_FONT_CHANGE` (125), `FONT_CHANGE` (71),
`FONT_NAME`/`FONT_SIZE`/`FONT_STYLE_TYPE` (69 each), `GRID_ROW_HIGHT` (68), `GRID_SCROLL`
(60), `SL_ROW_CHANGE` (10), `TILE_MENU`, `PRINT_FORM_BTN`, `OPBL_TRFR_BTN`, `LEDR_BILL_COL`,
`RPT_TOT_SHOW`, `HELP_SERCH`.

Implement as a theme/density provider reading `CO_SET`, applied in `app/(app)/layout.tsx`.
Lower business risk, but `GRID_ROW_HIGHT` and `GRID_SCROLL` materially affect data-entry
speed on the dense grids P2 and P7 introduce — do not skip them.

### P4-5 The 8 settings that are dead on both sides

`STK_RPT_VIEW, BTN_NAME, COUNTRY_CODE, LEN_IMG_PATH, WAPP_DELAY, WAP_DELAY, WEB_IMAGE,
WEB_PATH` — the desktop ignores these too. **Do not implement.** Mark them
`deadOnBothSides` in `settingsCatalog.ts` with the evidence, and subtract them from the
`settings.inert` ceiling so the target of ≤ 25 is honest. Note `WAPP_DELAY` and `WAP_DELAY`
are two separate columns, one almost certainly a historic typo — record which, do not silently
merge.

### P4 exit

```bash
node scripts/check-depth.mjs --phase P4
```
Targets: `settings.honoured ≥ 105`, `settings.inert ≤ 25`. Plus `settingsEffect.db.test.ts`
containing a flip-test for every newly honoured setting.

---

## 8. P5 — The per-cell recalculation kernel

Desktop has **416** `EnterCell`/`LeaveCell`/`RowColChange` handlers driving dependency chains.
The web has per-page ad-hoc previews with divergent formulas, and several pages expose fields
that change nothing on screen.

### P5-1 Extract the desktop chain

Reference implementation is the sale grid, `TR_SALE.cs:9400-9522` (`MSG_LeaveCell` →
`CommPassTotal()`). The chain:

| Step | Formula | Desktop line |
| --- | --- | --- |
| net weight | `gross − ghat` | `TR_SALE.cs:8631` |
| fine | `(net + extra) × (touch + wastage) / 100` | `:10693-10760` |
| item amount | by rate base — fine / gross / net / quantity | `:10827-10932` |
| labour amount | by labour type — per gram / per piece / percentage / fixed | `:11100-11127` |
| net labour | `labour − labour discount` | `:11209` |
| line total | `item + labour + other − discount`, tax-inclusive vs exclusive | `:11548-11632` |

Purchase has the same structure via `MSG_LeaveCell` and its `CommPassTotal*` family
(`TR_PURC.cs:9273-9342`). Karigar issue differs — `((Net+Ghat) × (Touch+West) / 100) − LessWt`
(`TR_KR_ISU.cs:3933-3977`) — so the kernel must be **policy-driven, not one formula**.

### P5-2 Build the kernel

**File (new):** `web/apps/web/lib/lineRecalc.ts` (the gate counts pages mentioning
`lineRecalc`).

- Pure functions, no React, so they are unit-testable and shareable with the server.
- **Must delegate all rounding to `packages/core/src/money.ts` and
  `modules/shared/roundingPolicy.ts`.** WP-06 counted 108 local rounding helpers in 69 files
  and proved they diverge from the kernel on negative midpoints. Do not add a 109th.
- `roundingPolicy` implements *both* desktop mechanisms, selected by whether the flag is
  configured (ties-to-even) or defaulted (half-up). Preserve that distinction.
- Honour the P4 settings that alter the chain: `LBR_WITH_GHT`, `OTH_ITM_WT_REMOVE`,
  `SILVER_THREE_DIGIT`, `ALL_ROF_REMOVE`, and the five `*_ROF` rounding keys.

### P5-3 Adopt on all 66 txn pages

Replace each page's inline preview. Highest-divergence pages first, because these expose
fields that currently do nothing:

| Page | Current defect |
| --- | --- |
| `txn/sales` | preview uses only `net × touch`, `fine × rate`, `net × making` (`page.tsx:375-395`) while the page exposes wastage, ghat, fine override, rate type, MRP, ghat amount, line discounts |
| `txn/sales-order` | `lineNet` uses net/touch/rate/making only (`page.tsx:265-267`) despite 61 extended row fields |
| `txn/wholesale-sale` | offers a rate type but always computes `fine × rate` (`page.tsx:90-94`); the server applies the real branches only on post (`rateCut.ts:190-217`) |
| `txn/mfg-receive` | previews `net + ght + loss` (`page.tsx:55-59`), cannot express `TR_MFG_ORD_REC.cs:4726` |
| `txn/tour` | previews `Net × Touch / 100`; desktop uses `(Net+GhtWt) × (Touch+West) / 100` (`TR_APR_ISU.cs:4008-4159`) |
| `txn/rate-cut` | rate base ignored in preview |
| repair pages | state "server recomputes totals" (`repair-karigar-receipt/page.tsx:749`) — no operator feedback at all |

### P5-4 Row-selection side effects

Desktop `RowColChange` also syncs row remarks and HUID 2-4, filters sub-detail rows to the
selected parent, recalculates sub-detail totals and loads the row's image:
`TR_SALE.cs:16791-16876`, `TR_SALE_RTN.cs:15328-15469`, `TR_SALE_ORD.cs:10121-10256`,
`TR_WH_SALE.cs:13958-14095`, `TR_SALE_LBR.cs:10215-10381`, `TR_SALE_HM.cs:12157-12302`,
`TR_WH_SALE_RTN.cs:4192-4330`.

`GridKeyboard.tsx` has no row-change callback. Add `onRowChange` and use it to drive the P2
sub-detail filtering and the existing `EntityImagePanel`.

### P5-5 Prove client and server agree

The real risk of a client-side kernel is a second source of truth. Add
`web/apps/api/test/recalcAgreement.test.ts`: run the same seeded line set through
`lib/lineRecalc.ts` and through the server's computation, and assert equality to the kernel's
tolerance. Include the WP-06 negative-midpoint case (`-1.005`) and at least one case per
labour type and per rate base.

### P5 exit

```bash
node scripts/check-depth.mjs --phase P5
```
Targets: `pagesWithLineRecalc ≥ 66`, `operatorSurface ≥ 2250`. Plus `recalcAgreement.test.ts`
green, and zero new local rounding helpers (`node scripts/check-kernel-conformance.mjs`
ratchet: `rounding ≤ 108`, `book-account ≤ 5`).

---

## 9. P6 — Discharge the tag/stock containment

Five implemented workflows return **503**. `packages/core/containment.mjs` blocks
`tag-opening-update`, `tag-transfer`, `tag-cancel`, `tag-weight-difference`, `tag-split`
(plus `logical-restore` and `production-cutover-load`, which stay). Enforced by
`containMutation()` at `routes/txn.ts:2914, 3187, 3318, 3326, 3353, 3366, 3386, 3393, 4838,
4851`. There is deliberately no environment override.

Each rule carries an `exitGate` string. **Satisfy the gate, then delete the rule** — never
weaken `containment.mjs` to unblock.

### P6-1 `tag-split`

**Recorded exit gate:** child serials, barcode detail, sub-detail, image and parent-child
lineage (`containment.mjs:72-80`).

| Requirement | Desktop reference | Current web |
| --- | --- | --- |
| child `VCH_SRNO` allocation | `TR_TAG_SPLIT.cs:10692` | absent |
| `BAR_DETL` row per child | `:8449-8457`, `:8524-8532` | absent |
| sub-detail rows (`MSG_IDTL`, `MSG_RTN_IDTL`, 32 cols each) | `:7351-7382`, `:10281-10310` | P2 delivers the grid |
| parent→child lineage | `:5428-5431` (`NewTagId`/`OldTagId`) | absent |
| **imbalance settled to an account** | `:12204-12228` computes `nDrWt`/`nCrWt`; `:9979` permits unequal when an account is supplied; `:10103-10149` persists account, Dr/Cr weight, cheque/card/cash | web **refuses** unless `Σchildren.netWt == parent.netWt ± 0.01` (`tagSplit.ts:42`, `:103-111`) |

The last row is a genuine behavioural divergence, not an omission: the desktop permits an
unequal split settled against an account. Implement that, keeping the equality rule as the
default when no account is given.

Also fix: `ITM_WEST` is hard-coded to zero on both legs (`tagSplit.ts:119-120`, `:144`,
`:170`) while the API accepts `westPct`.

**Verify:** DB test using WP-07's invariants (`modules/stock/tagInvariants.ts`) — split a tag
into three children and assert INV-1 (the `TAG_STOCK` PK `(tenant_id, CO_CODE, LC_CODE,
TAG_NO)` constraint, which has **no `VCH_SRNO`**), INV-2 and INV-3 all hold; assert weight
conservation, or a balanced account posting where it does not.

### P6-2 `tag-weight-difference`

**Exit gate:** tag replacement, barcode detail, image, Rojmel, serial, karigar branches
(`containment.mjs:58-65`).

The web performs one simplified net movement; the desktop performs a full tag OUT plus a full
tag IN (`tagOps.ts:16-20` admits this). Desktop posts ledger, Rojmel and stock
(`TR_TAG_WT_DIFF.cs:8381-8387`) and carries `NewTagId`/`OldTagId` (`:5428-5431`).

Needs the 60-column main grid (`:5257-5431`), the 39-column absorption grid (`:3859-3963`),
and the 25-column sub-detail (`:4579-4679`) — the grids are P7, the posting semantics are P6.

### P6-3 `tag-cancel`

**Exit gate:** live serial identity and source/sub-detail lineage (`containment.mjs:50-57`).
The API already accepts `bagWt`, `lotNo`, `transferItCode`, `stones` (`tagOps.ts:64-100`);
the page sends none (`tag-cancel/page.tsx:13-28`). Desktop: 66-column grid
(`TR_TAG_CAN.cs:2431-2684`), 17-column sub-detail (`:1869-1924`), save at `:5150`, two-phase
effect at `:5250-5277`.

### P6-4 `tag-transfer`

**Exit gate:** exact `VCH_SRNO`, open/edit lineage, shared locking (`containment.mjs:42-49`).
Reuse the P6-1 serial allocation. Model row-level locking on the advisory-lock pattern in
`modules/utilities/dataRepair.ts`.

### P6-5 `tag-opening-update`

**Exit gate:** reopen omits rich barcode fields and update can erase details and images
(`containment.mjs:34-41`). This is exactly the WP-08 defect class — an unchanged save wiped
43 of 109 `BAR_DETL` columns.

Two concrete bugs to fix first:
- `tag-opening/page.tsx:366-373` coerces HUID 2-4 with `Number(...)`, so an alphanumeric HUID
  becomes `undefined`, while the API expects strings (`stockVoucherLifecycle.ts:61-67`).
- on load, only basic fields are overlaid (`page.tsx:295-316`) — the extended values are not
  restored, so a reopen-and-save loses them.

Missing entirely from the page/API: primary `HuId`, `BagWt`, karigar ghat percent/weight
(`TR_TAG_OPBL.cs:9318-9327`), and the 41-column sub-detail (`:3984-4157`).

**Verify:** this is the P0-2 harness's core case. Reopen and save unchanged; assert **all
109** `BAR_DETL` columns are byte-identical and `VCH_SRNO` is unchanged.

### P6-6 Retire the rules

Delete the five entries from `parityContainmentOperations` and their `rule(...)` bodies, and
remove the corresponding `containMutation()` calls. Keep `logical-restore` and
`production-cutover-load`.

### P6 exit

```bash
node scripts/check-depth.mjs --phase P6
```
Targets: `containment.operations ≤ 2`, `containment.blockedRoutes ≤ 2`. Plus every WP-07 tag
invariant green, and `tagInvariants.ts:315`'s note about tag transfer being blocked updated.

---

## 10. P7 — Grid column completion on existing screens

The largest single number in the report: **visible grid columns 755 / 3,508 = 21.5%**, and only
20% even on the 45 dedicated screens. P2 addressed sub-detail grids; P7 addresses the **main**
line grids.

### P7-0 Method, per form

```bash
F=TR_SALE_RTN                                   # the form being closed
D=unified/src/csharp/DataCareNext
grep -nE "\.Cols\s*=\s*[0-9]+" $D/$F.cs         # every grid and its size
grep -nE "\[0,\s*[0-9]+\] = \"" $D/$F.cs        # every column header, in order
```

Then, for each column, classify:

| Class | Action |
| --- | --- |
| operator-entered | render an input in the page's extended mode |
| computed from others | render read-only, compute via `lib/lineRecalc.ts` (P5) |
| hidden state / old-value baseline (`Old*`, `RowValue`, `RowText`, `DataType`) | keep server-side only; it must still round-trip |
| edition-gated (`if MsSoftType == "A"/"E"`) | render conditionally on the same setting |

Note that edition gating is real: `TR_PURC.cs:8737` shows column 6 `Style` present only when
`MsSoftType` is `A` or `E`. Do not render such columns unconditionally.

**Use the extended-mode pattern that already works.** `txn/sales` and `txn/tag-opening` hide
50+ extended fields behind `<details>` and still measure well; `txn/purchase` has a "Full grid"
toggle. Copy that rather than inventing a new layout.

### P7-1 Sales family — desktop surface 1,055, web 283 (26.8%)

| Form | Grids and named columns | Web page | Named missing groups |
| --- | --- | --- | --- |
| `TR_SALE` | `mSG` 108 cols (`:8723-8969`), `mSG_IDTL` 24, `mSG_OLD` 18, `mSG_ORD` 9, `mSG_UPI` 6, `mSG_CRNT` 9 | `txn/sales` | `OrdNo` as a line control, `FixGht%`, `LType`, `LbrAmt` override, `NtLbrAmt`, `PrCost`, `MCom%`, `MComWt`, `KrGht%`, `KrGht`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `GrTch%`, `TagId`; UPI identity rows (`AcCode`, `Upi Bank Name`, `UpiType`, `Upi Id`); per-row current/order allocation |
| `TR_WH_SALE` | `mSG` 101 (`:7977-8182`), `mSG_PR` 42 (`:6143-6253`), `mSG_IDTL` 31 | `txn/wholesale-sale` | the **entire** 42-column purchase/receipt grid; `ItmLot`, `Counter`, `Design`, `Style`, `Color`, `Size`, `HuId`, `BagWt`, `BagTot`, `PsWt`, `Ght%`, `GhtWt`, `FixWst%`, `LTouch`, `LessWt`, `HmFine`, `NetFine`, `SlvrFine`, `ConRate`, `Lbr%`, `LType`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `OrdNo`, `Tax%`, all `Kr*`, `PrCost`, `TagCost`, `Margin`; cheque/card/employee/description/credit-days header fields |
| `TR_SALE_RTN` | `mSG` 48 (`:5872-5987`), `mSG_PR` 71 (`:3568-3703`), `mSG_IDTL` 24, `mSG_RTN_IDTL` 24 | `txn/sale-return` | the **entire** 71-column receive-item grid; `ItName`, `Design`, `Size`, `HmId`, `OthWt`, `Ght%`, `GhtWt`, `West%`, `Lbr%`, `LType`, `OthAmt`, `Mrp`, `Counter`, all `Kr*`, `PrCost`/`TagCost` — the API already accepts much of this (`salesReturn.ts:341-403`) |
| `TR_SALE_ORD` | `mSG` 87 (`:5246-5397`), `mSG_IDTL` 21, `mSG_OLD` 17, `mSG_UPI` 6 | `txn/sales-order` | detailed old-metal rows (`ItCode`, `ItName`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `RTyp`, `Rate`, `ConWt`, `OldRate`, `OldNetAmt`, `OldNwt`) — only aggregate headers exist; UPI identity; `TagNo`, `KrOthWt`, `KrGht%`, `KrGht`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `Margin`, per-line `Tax%` |
| `TR_SALE_HM` | `mSG` 92 (`:6057-6224`), `mSG_IDTL` 25, `mSG_OLD` 14, `mSG_ORD` 8, `mSG_UPI` 6 | `txn/hallmark-sale` | `Counter`, `OrdNo`, `Design`, `Size`, `BagWt`, `LsWt`, `Ght%`, `GhtWt`, `West%`, `Lbr%`, `LType`, `GhtAmt`, `OthAmt`, `Mrp`, `LDisc%`, `LDiscAmt`, `Tax%`, `HmAmt`, `PrCost`, all `Kr*`, `TagCost`, `Margin`, `Image` |
| `TR_SALE_LBR` | `mSG` 60 (`:6097-6194`), `mSG_PR` 39 (`:4633-4737`), `mSG_IDTL` 24, `mSG_ORD` 9, `mSG_UPI` 6 | `txn/labour-sale` | web has 7 line fields against a full tagged-sale voucher; also **no print path** (desktop `:3129`, `:10028`) |
| `TR_WH_SALE_RTN` | `mSG_PR` 106 (`:4353-4578`), `mSG_PR_IDTL` 30 | `txn/wholesale-sale-return` | ~50 named columns incl. all tag-side (`TgNwt`, `TgTch`, `TgW%`, `TgFine`, `TagRate`, `TagItAmt`, `TgLbr%`, `TgLRat`, `TgLAmt`, `TgOth`, `TagCost`, `Margin%`, `TgMrp`), `HmId`–`HmId4` + weights, `HmFine`, `PrCode`; `taxPct` is posted but has no input (`page.tsx:10-33`) |

Two desktop workflow steps here are **imports**, not columns, and belong in P8:
approval-issue→sale bulk import (`TR_SALE.cs:19999-20105`) and quotation→sale import
(`:21014-21100`).

### P7-2 Tag/stock — desktop 527, web 101 (19.2%)

`TR_TAG_SPLIT` grids: `mSG` 73 (`:7433-7698`), `mSG_PR` 91 (`:5025-5306`), `mSG_TOT`/`mSG_PR_TOT`
inherited, `mSG_IDTL` 32, `mSG_RTN_IDTL` 32, `mSG2_TOTAL` 6 (`Payment`/`Received` at
`:11736-11737`).

`TR_TAG_OPBL`: `mSG` 112 (`:5067-5459`), `mSG_IDTL` 41 (`:3984-4157`).
`TR_TAG_WT_DIFF`: `mSG` 60, `mSG_PR` 39, `mSG_IDTL` 25, `mSG2_TOTAL` 6.

Jewellery-specific columns missing across all three and easy to overlook — audit each
explicitly: primary `HuId`, `HuId2`–`HuId4` with their four weights, `BagWt`, `LsWt`,
`KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `Kundan`, `KndTch%`,
`KndNwt`, `Wax`, `KrWax`, `JdtWt`, `JGhatWt`, `TagId`.

### P7-3 Purchase, bullion, dhiran, membership

| Form | Grids | Web page |
| --- | --- | --- |
| `TR_PURC` | `mSG` 88 (`:8700-8938`), `mSG_PR` 70 (`:6219-6418`), `mSG_IDTL` 34, `mSG_PR_IDTL` 25, `mSG2_TOTAL` 5×11 rows (`:14884`, labels `:14960-14976`) | `txn/purchase` |
| `TR_PURC_HM` | `mSG_PR` 95 (`:4546-4784`), `mSG_PR_IDTL` 23, `mSG2_TOTAL` 5×14 (`:9297`, labels `:9378-9403`) | `txn/purchase-hm` |
| `TR_BUL_SALE` | `mSG` 81 (`:5706-5887`), `mSG_PR` 50 (`:4155-4286`), `mSG2_TOTAL` 6×10 with explicit `Payment`/`Received` (`:9889`, `:9981-9992`) | `txn/rate-cut` |
| `TR_BUL_BOOKING` | 19-column multi-party grid (`:188-224`, `:1649-1686`) | `txn/bullion` — currently one header quantity |
| `TR_FN_INOUT` | 77-column main + 32-column item detail (`:2693-2748`, `:3295-3335`) | `txn/fine-inout` — 6 columns; also missing `PARTY_FINE` settlement and TDS (`:5097`, `:5107-5120`) whereas `fineInout.ts:16-18` declares "NO money ledger" |
| `TR_MEMB_ENT` | main 15, installment history 5, UPI split 8 | `txn/scheme` (P3-2) |

`TR_PURC`'s `mSG2_TOTAL` is **row-oriented**, not column-oriented: rows are `Net Amt, Disc Amt,
Tax Amt, Tcs Amt, Tds Amt` (or `Rof Amt` when purchase TDS is off), `Total Amt, Cheque Amt,
Card Amt, Cash Amt, Kasar Amt, Os Amt`, with columns 1–4 selectively editable (`:15005-15055`).
Model it as an editable settlement table, not a grid of lines.

### P7-4 The editable totals band

Every one of these forms has an editable `mSG2_TOTAL` with per-row `Payment` / `Received`
allocation and cell-level navigation (e.g. `TR_SALE_RTN.cs:15954-16079`,
`TR_WH_SALE.cs:14942-15053`). The web shows static aggregate tiles or flat header inputs.

Build `web/apps/web/components/VoucherTotals.tsx` (the gate counts `VoucherTotals`) as a
row-oriented editable settlement table, and adopt it wherever `TenderPanel` is used today.

### P7 exit

```bash
node scripts/check-depth.mjs --phase P7
```
Targets: `gridColumns ≥ 2400`, `gridColumnPct ≥ 68`, `operatorSurface ≥ 3400`. Plus a
round-trip case per form proving the new columns survive an unchanged save.

---

## 11. P8 — Missing workflows and screens

### P8-1 Lot-based manufacturing (no route at all)

`TR_MFG_WITH_LOT.cs` — 60 fields, `mSG` 60 cols (`:2791-2898`), `mSG_IDTL` 23 (`:2999-3092`),
settlement (`:7203-7290`). Difference formula
`DifWt = IsGwt − (NetWt + GhtWt + Chole + Ghis + LotIt…)` at `:4182`; fine
`(Net+Ght) × (Touch+West)/100` at `:4245-4304`.

`mfgLotBalance` already exists at `modules/manufacturing/mfg.ts:974-1001` and is registered on
**no** HTTP route. Add the route, then the page. Ties to setting `ITM_WITH_LOT_STK` (P4).

### P8-2 Rate-cut receive side and booking integrity

The 50-column `MSG_PR` (`TR_BUL_SALE.cs:4155-4286`) and `RATE_CUT_REC` writing
(`rateCut.ts:1078` never writes it). Booking draw-down was fixed in P3-3; the grid lands here.

### P8-3 Sales-family imports and transfers

| Workflow | Desktop | Current web |
| --- | --- | --- |
| approval-issue → sale bulk import | `TR_SALE.cs:19999-20105` ("All Approval Tag In This Voucher Import?"); wholesale `TR_WH_SALE.cs:16622` | no endpoint |
| quotation → final sale import | `TR_SALE.cs:21014-21100` | web can *generate* an estimate but not import one |
| voucher transfer to another book/number | `TR_SALE.cs:20716-20740` rewrites `SL_DATA`, `SL_DETL`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_PR_DETL`, `BILL_OS_DATA`, `UPI_DATA` then rebuilds ledger/rojmel/stock/tax; HM at `TR_SALE_HM.cs:15263-15279` | none |
| bulk wastage adjustment across wholesale lines | `TR_WH_SALE.cs:17269-17333` (F1, blocks over-negative) | none |
| refresh karigar fine/touch from tag master | `TR_WH_SALE.cs:17967-17998` | none |
| order design re-issue | `TR_SALE_ORD.cs:7299-7304` (`DESIGN_ISU='N'`) | none |

Voucher transfer must route through `postVoucherTx` for the rebuild, not raw SQL, so the period
lock and balance checks apply.

### P8-4 Tour / approval family

`TR_TOUR_ORD` (100 fields), `TR_TOUR` (62), `TR_TOUR_SALE` (156 → 68), `TR_APR_ISU` (73).
Pages `txn/tour`, `txn/tour-return` exist and are shared across four desktop forms; the
`TR_APR_ISU` issue-source picker (`:143-163`, `:1400-1436`) and status columns (`:3213-3228`)
are absent.

### P8-5 Missing print paths

`txn/labour-sale` (desktop `TR_SALE_LBR.cs:3129`, `:10028`) and `txn/wholesale-sale`
(`TR_WH_SALE.cs:13654`) have no print action or document route.

### P8-6 Scope decisions — record, do not drift

| Item | Size | Decision needed |
| --- | ---: | --- |
| `TR_PR_SL_UAE` | 95 fields, 4 grids | implement or waive |
| `TR_SALE_RTN_UAE` | 94 fields, 4 grids | implement or waive |
| `NextDm.exe` | 199 forms, 3,420 grid columns | in scope or a separate product |
| `TagStkIdtlRpt.rpt` | 1 of 255 Crystal layouts | the only unextracted layout |

Waivers go in `project-memory/parity/WAIVERS.md` with a reason, and the completion register's
7th state `absent` — not silence. If UAE is waived, `settings.COUNTRY_ID` (35 desktop readers)
still needs honouring in P4 for the non-UAE branches.

### P8 exit

```bash
node scripts/check-depth.mjs --phase P8
```
Targets: `pages ≥ 118`, `operatorSurface ≥ 4000`. Plus every scope decision recorded.

---

## 12. P9 — Report parity

44 desktop report screens (45 `RP_*.cs` files; `RP_ALL` is a 72-button launcher). 44 web slugs
in `modules/reports/reportAuthorization.ts`, of which **26** genuinely correspond. 254 of 255
Crystal layouts are already extracted — a present layout is not a working report, because
`reportBind.ts:36-61` recognises only sales, purchase, karigar, cash, tag-stock and
account-ledger families and defaults everything else to sales.

### P9-1 The 18 missing report workflows

`RP_ADDRESS`, `RP_BILL_PROFIT`, `RP_CONSI_APR`, `RP_DAY_WORK` (`:1011-1176`, `:1410-1472`),
`RP_GRAPH`, `RP_HUID`, `RP_JDTR_ZOOM`, `RP_LC_INOUT`, `RP_MFG` (`:1110-1396`), `RP_MFG_ZOOM`
(`:1454-1894`, `:1924-1987`), `RP_ORD_TRACK`, `RP_OTH_DETL`, `RP_PHY_STOCK` (`:1176-1494`,
`:1830-1864`), `RP_REMINDER` (`:1303-1598`), `RP_STK_LEVEL` (`:914-1117`, `:1331-1450`),
`RP_STOCK_FINE` (`:1153-1479`, `:1533-1601`), `RP_TOUR_ZOOM`, `RP_USER`.

`RP_REMINDER` is the widest: one screen consolidating sales, purchase, item in/out, scheme,
birthday/anniversary, pledge, wholesale and orders. It depends on the demographic fields P3-2
adds.

### P9-2 Report parameter richness

The generic engine has From/To dates and 11 registered `RP_ALL` dimensions
(`reportFilters.ts:1-35`). Missing:

| Parameter class | Desktop | Where to add |
| --- | --- | --- |
| interest rates + divider/days + gold-vs-silver + detail/summary | `RP_OS.cs:5240-5330`, `:5380-5425` | outstanding reports |
| ledger output modes: voucher summary/detail, opening-only vs omit-zero, weighted/gold columns, half-month | `RP_LEDR.cs:6179-6333`, `:6406-6415`, `:6736`, `:7007`, `:8113-8250` | account ledger |
| stock basis (net vs gross) and stock type | `RP_STOCK.cs:4280-4289`, `:4334-4443` | stock reports |
| GST section: B2B, B2CL, B2CS, CDNR, CDNUR, export, advances, exempt, HSN, doc summary | `RP_GST.cs:1648-1675` | GSTR pages |
| balance-sheet valuation (`closingDate`, `goldRate`, `silverRate`, `ledgerFineGold`, `ledgerFineSilver`) | `RP_BALANCE.cs:2675-2708` | **API already accepts these** at `routes/txn.ts:4296-4308` — UI wiring only (P3) |
| multi-select accounts/groups/cities, reference account, district | `RP_OS.cs:5343-5375`, `:4613-5188` | `reportFilters.ts` is scalar-only today |
| group-wise vs area-wise outstanding; opening vs today balance | `RP_OS.cs:3751-3932`, `RP_BALANCE.cs:2675-2708` | area-wise exists; group-wise does not |

### P9-3 Keep report authorization intact

WP-02B verified an exact 48↔48 bijection between report builders and mapped slugs, with the
order `requireAuth`(401) → password-reset → business scope → form resolution (403
`unresolved`) → `authorizeForm`(403) → `enforceReportFilters`(400). Every new slug must join
`REPORT_FORM_BY_SLUG` **and** keep that bijection — the existing 36 authorization tests
enforce it.

Two residuals recorded in WP-02B to fix while here: `GET /gst/gstr1?city=…` silently drops
filters (the guard is scoped to the `/reports/` prefix), and `POST /render/pdf` is classified
`system`.

### P9 exit

```bash
node scripts/check-depth.mjs --phase P9
```
Target: `reports.runnableSlugs ≥ 62`. Plus the 48↔48 bijection test still green, and
`scripts/report-baselines.mjs` regenerated.

---

## 13. P10 — Masters depth

31 master forms, desktop surface 505, web 136 (26.9%). The generic scaffold at
`app/(app)/masters/[name]/page.tsx` (516 lines) can express a **flat scalar row** only: field
types `text`, `number`, `select`, `lookup`, `date` (`master.service.ts:11-23`), required and
static per-column rules, duplicate-key and reference guards (`:24-73`, `:95-168`), configured
entity images, CSV import/export and a nine-column browse grid.

### P10-1 Child grids in the scaffold

`MS_DESIGN_BOOK` is the test case: main `MSG`, component `MSG_IDTL` (29 cols, `:2004-2149`),
browse `DGV`, totals `MSG_TOT` (`:69-140`, `:598-737`, `:1231-1260`). A single-table CRUD page
cannot render it. Add an array field type backed by the P2 `SubDetailGrid`.

`saveDesignBook` (`masters/designBook.ts:78-149`) writes only `DESIGN_DETL`; the desktop also
deletes and reinserts `DESIGN_IDTL` (`MS_DESIGN_BOOK.cs:4725-4752`, load at `:4511-4540`).
And no frontend calls `/masters/design-book` at all — the generic page only calls
`/masters/${name}`.

### P10-2 Master-level calculations

`saveDesignBook` converts caller-supplied numbers and persists them (`designBook.ts:67-75`).
The desktop recalculates net weight, ghat weight, fine, rate-type-dependent item amount,
labour, net amount and MRP (`MS_DESIGN_BOOK.cs:3153-3237`, `:3260-3660`), and component rows
compute pieces×weight, karigar loss, conversion weight, item and labour amounts
(`:2540-2740`). Route these through the P5 kernel.

### P10-3 Conditional and cross-field validation

`columnRules.invalid` receives a single string value (`master.service.ts:45-55`, `:155-161`).
`MS_ACCT.cs:7650-7705` makes city and mobile requirements conditional on installation
settings, registration, account group and multi-branch mode. Extend the rule model to a
predicate over the whole row plus `SettingsBehavior`.

### P10-4 Per-parent collections and provisioning

- Party-wise `TOUCH_MAST` rows and item weight/rate slabs exist as separate flat masters
  (`configs.ts:453-469`, `masters/labourUpdate.ts:87-155`) but cannot be edited under the
  selected parent. Add them as child grids.
- Design images are keyed by `DESIGN_NO` alone (`masters/[name]/page.tsx:24-28`); the desktop
  keys `company_book_product_design` (`MS_DESIGN_BOOK.cs:4697`, `:5474-5496`), so the same
  design number in different books cannot keep distinct images.
- `MS_LOCT.cs:3532-3616`: creating a location clones `BOOK_DATA`, `BOOK_DETL` and `TABLE_MAST`
  from defaults. Web treats `LOCT_MAST` as an ordinary one-table master
  (`configs.ts:103-110`) with no provisioning. Model on `ops/seedCompany.ts:188-224`.

`MS_YEAR` is **already at parity** — create, close, reopen, company clone and carry-forward
exist (`masters/year.ts:26-112`, `:114-180`; routes `txn.ts:4145-4200`). Do not rework it.

### P10 exit

```bash
node scripts/check-depth.mjs --phase P10
```
Targets: `operatorSurface ≥ 4600`, `apiValidationMessages ≥ 700`.

---

## 14. P11 — Parity certification

### P11-1 Close the remaining cross-cutting items

| Item | Work | Reference |
| --- | --- | --- |
| field-specific F1 lookups | 944 desktop `MS_HELP.ShowDialog` sites across 134 files vs `LookupPicker` on 65 pages. Extend `LookupPicker` with per-field query/filter/autofill descriptors instead of per-page code | `TR_SALE.cs:17296-17320`, `:17354-17420`; grid variant `:12195-12320` |
| old-metal dated-rate fill | F1 on old-metal `Rate` reads `RATE_MAST` for the item and voucher date | `TR_SALE.cs:7555-7577`; order `TR_SALE_ORD.cs:4065-4087` |
| touch/wastage master update from a voucher | F1 writes current `Touch`/`West%`/labour rate into `TOUCH_MAST` and confirms "Touch Update" | `TR_WH_SALE.cs:6412-6476` |
| UPI-ID uniqueness | desktop blocks a duplicate UPI ID | `TR_SALE.cs:7075`; `TR_SALE_ORD.cs:3919`; `TR_SALE_LBR.cs:4303`; `TR_SALE_HM.cs:4661` |
| conditional employee-required | blocks save when employee is mandated | `TR_SALE.cs:15017-15030`; `TR_SALE_RTN.cs:12124-12187`; `TR_WH_SALE.cs:12793` |
| delivery/function date required | order requires both in the configured mode | `TR_SALE_ORD.cs:8963`, `:8978` |
| wholesale credit-days / ref-no required | both blocked when missing | `TR_WH_SALE.cs:12799`, `:12806` |
| old-metal rate type must be `N` or `F` | web accepts free text and treats anything non-`N` as fine-wise (`oldGoldValuation.ts:53-60`) | `TR_SALE.cs:7669`; `TR_SALE_ORD.cs:4196` |
| whole-bill duplicate-return guard | desktop refuses re-importing an already-imported bill | `TR_SALE_RTN.cs:16540` |
| scale capture beyond one page | `ScaleCapture` is a faithful WebSerial port of the desktop CH340 profile but is mounted only on `tag-opening` | `TR_TAG_OPBL.cs:7510-7599` |
| transaction-completion messaging | desktop sends customer/admin WhatsApp on sale completion; web has `/integrations/notify` and reminders but no voucher hook | `TR_SALE.cs:16619-16657`; `Module_WhatsApp.cs:1831-1900` |
| `USER_REQUEST` wired to voucher actions | web stores reasons (`utilities/userRequest.ts:41-74`) but delete routes never consult them. **Desktop direct delete needs no reason** — the reason flow is the separate F1 → `UT_USER_REQUEST` handoff | `TR_SALE.cs:17140-17149`; `UT_USER_REQUEST.cs:384-405` |

### P11-2 Certify

```bash
cd web
node scripts/check-depth.mjs --phase P11
RELEASE_SHA=$(git rev-parse HEAD) RELEASE_EVIDENCE_MAX_AGE_HOURS=24 node scripts/release-certify.mjs
```

P11 targets: `operatorSurface ≥ 5107`, `operatorSurfacePct ≥ 100`, `gridColumnPct ≥ 100`,
`settings.honoured ≥ 122`, `settings.inert ≤ 8`, `apiOnlyUnreachable ≤ 20`,
`containment.operations ≤ 2`, `pagesWithLineRecalc ≥ 66`, `reports.runnableSlugs ≥ 62`.

Release certification currently reports `passed=10 failed=3 skipped=1 missing=1` →
`RELEASE_NOT_CERTIFIED`, **by design**. The three failures include the completion register's
release bar, which is RED at 198/198 because plan §14 says `implemented-unverified` is not
done. Parity is not achieved until that bar is green, which requires G5 desktop-comparison
evidence (currently 0/66) — not merely the depth targets above.

### P11-3 Update the record

- `DEPTH-SCOREBOARD.md`: publish operator surface **beside** column coverage. Presenting 98.9%
  alone is how a 34%-depth product was recorded as near-complete.
- Completion register: move items from `implemented-unverified` to `verified` only with G5
  evidence.
- `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md` §17: append the depth results.

---

## 15. Reference index

### Generated artifacts

| File | Contents |
| --- | --- |
| `project-memory/parity/DESKTOP-RICHNESS.json` | per-form controls, grids with full column lists, validations, settings, cell events (204 forms) |
| `project-memory/parity/DESKTOP-RICHNESS-NEXTDM.json` | same for `NextDm.exe` (199 forms, out of scope) |
| `project-memory/parity/WEB-RICHNESS.json` | per-page inputs, columns, composed components, adoption flags |
| `project-memory/parity/RICHNESS-JOIN.json` | per-form depth ratio, `worstByAbsoluteGap`, `formsWithNoWebSurface` |
| `project-memory/parity/SETTINGS-PARITY.json` | 130 / 55 honoured / 74 inert, with per-key evidence |
| `project-memory/parity/SETTINGS-EFFECT.json` | `realGaps` — the 66 inert-but-desktop-honours settings with reader counts |
| `project-memory/parity/GAP-MANIFEST.json` | 192 API fields unreachable from any screen, by interface |
| `project-memory/parity/IDTL-REFERENCE.md` | all 38 desktop sub-detail grids, their columns, and the union ranked by frequency |
| `web/parity/depth-parity-baseline.json` | ratchet baseline + every phase's pre-declared targets |

### Regenerate everything

```bash
cd project-memory/parity
python3 richness_desktop.py DataCareNext > DESKTOP-RICHNESS.json
python3 richness_desktop.py NextDm      > DESKTOP-RICHNESS-NEXTDM.json
python3 richness_web.py                 > WEB-RICHNESS.json
python3 richness_join.py                > RICHNESS-JOIN.json
python3 settings_parity.py              > SETTINGS-PARITY.json
python3 settings_effect.py              > SETTINGS-EFFECT.json
python3 gap_manifest.py                 > GAP-MANIFEST.json
cd ../../web && node scripts/check-depth.mjs --audit
```

### Existing gates that must stay green

`pnpm lint`, `pnpm test`, `pnpm build`, `pnpm format:check`,
`check-completion-register.mjs --strict --release`, `check-contracts.mjs`,
`check-kernel-conformance.mjs`, `pnpm schema:readiness`, `pnpm type:parity`,
`pnpm fresh:provision`, `check-settings-parity.mjs`, `report-baselines.mjs`,
`check-g5-parity.mjs`.

Ratchet ceilings that may only shrink: posting literals **68**; kernel `rounding` **108**,
`book-account` **5**; contracts `notEnforced` **28**, `blankVector` **184**, `blankTest` **0**.

### Standing cautions

1. `fileParallelism: false` in `apps/api/vitest.config.ts` is deliberate — parallel runs
   produced 0→1→3 random `40P01` deadlock failures across three runs. Do not re-enable it.
2. `backupCompany` must stay side-effect free; it is the WP-02A comparison oracle.
   `recordCompanyBackup` is called from `GET /backup` instead.
3. The repair modules' private account resolver is **richer** than the kernel (it accepts
   `LC_CODE` = current, `'00'`, or NULL). Consolidating it into the kernel would regress.
4. Never approve a contract, fill a vector cell, or invent a `BOOK_DETL` slot on the owner's
   behalf. 99 of 184 blank vectors have an exact approved precedent and were still left blank
   because `CALC-AUDIT.json` records cell identity but not the desktop expression.
