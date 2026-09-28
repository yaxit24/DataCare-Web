# Plan to 100% parity — depth, breadth, behaviour (2026-07-28)

Companion to `DEEP-DEPTH-AUDIT-2026-07-28.md`. That audit measured where we are; this plan states
exactly what to build, in what order, and the number each step must move. Completing every phase here
plus the two external-input gates yields full desktop-equivalent parity in the web application.

Reproduce every metric quoted here:

```bash
python3 project-memory/parity/deep_column_audit.py    # persisted-column depth
python3 project-memory/parity/deep_depth_audit.py     # form behaviour signals
python3 project-memory/parity/build_parity_matrix.py  # gates, breadth, self-checks
```

---

## 0. What "100% parity" means here (definition, so it can be verified not argued)

Parity is achieved when **all eight** of the following hold. Anything less is reported as a number,
never as "done".

| # | Criterion | Measure | Today | Target |
|---|---|---|---|---|
| P1 | Every desktop form is implemented or formally waived | matrix `implemented` | 193 + 11 waived, 0 missing | hold |
| P2 | Every desktop-written table is written by the web | column audit | 89 of 122 (33 absent) | 122 of 122 |
| P3 | Every desktop-written column is persisted | column audit | **2,227 / 3,669 = 60.7%** | ≥99% (remainder waived with reason) |
| P4 | Every data-bearing grid column is capturable | grid measure | **17.2%** (lower bound) | ≥95% of data-bearing columns |
| P5 | Every desktop calculation and validation is implemented or waived, with exact message text | contract files + tests | not traced | 100% traced |
| P6 | Every setting/config surface forks behaviour as desktop does | settings gates | 47 impl + 10 waived; `CO_SET_NEW` absent | 100% |
| P7 | Desktop-vs-web comparison is zero-diff per form | G5 artifacts | 0/720 | all in-scope forms |
| P8 | Operational certification signed | G6 ledger | 0/720 | signed |

P1–P6 are fully achievable in this environment. **P7 needs a desktop runtime + sanitized data;
P8 needs hardware, live credentials and named signers.** Those two are the only external blockers.

**Total measured work to close P2–P4:** 2,114 missing columns, 33 missing tables, ~4,050 missing grid
columns, plus ≥2,933 calculation expressions and 1,091 validations to trace (calc counts are capped at
70 per form by the extractor, so treat them as lower bounds).

---

## Phase A — Make depth measurable and gated — **COMPLETE (2026-07-28)**

Delivered, verified by regenerating the matrix:

- **`depth` is now a seventh gate** on every one of the 720 units (`GATE_NAMES`), published in the
  JSON, CSV (`depth` column) and Markdown (`GD` column) outputs.
  `passed` requires ≥99% of the desktop write set, zero unwritten desktop tables, ≥95% grid coverage
  and an approved contract. Current: **forms 1 passed / 83 in_progress / 22 not_started / 25
  evidence_gap / 73 waived**; **tables 13 passed / 70 in_progress / 63 not_started**.
- **Read-only forms are no longer conflated with extraction gaps.** A form whose desktop logic
  catalog records no INSERT/UPDATE is `waived`; a form with no catalog at all is `evidence_gap`.
- **Implementation cannot outrank depth**: `implemented` is downgraded from `passed` whenever `depth`
  is not `passed` or `waived`.
- **Ratchet active**: `depth-baseline.json` records per-form coverage and the generator asserts no
  form's coverage ever decreases.
- **Parser self-test is a precondition** (`test_depth_metrics.py`, 9 fixtures + 4 registry checks).
  The generator refuses to compute depth if it fails, because a gate built on an under-reporting
  parser is worse than no gate.
- **`DEPTH-SCOREBOARD.md`** is regenerated every run: headline, gate distribution, family gaps and
  the worst transaction forms.

**Phase A found five real measurement defects**, each of which had been understating parity. The
headline moved as the parser became faithful, and every step is reproducible:

| Fix | Idiom that was invisible | Coverage after |
|---|---|---:|
| baseline | — | 32.7% |
| `Object.assign(header, {…})` + dynamic masters/settings writers | sale settlement, master CRUD, `CO_SET` | 42.4% |
| factory row builders (`const header = (…) => ({…})`, `function detlRows()`) | karigar, mfg, finance vouchers | 49.1% |
| paren-aware factory bodies (`extra: Record<string, unknown> = {}` defaults) and `return lines.map(() => ({…}))` | `KR_DETL`, `MFG_DETL` | 52.2% |
| inline object keys (`{ CO_CODE: c, LC_CODE: l }` on one line) and `::text` cast guard | every prettier-inlined row object | 52.1% |
| dynamic `INSERT INTO "T"(${cols})`, `Object.keys(data)` writes, `configs.ts` master configs | `POINT_DATA`, `TAG_STOCK`, `BAL_GR` | 52.7% |
| variables bound to factory calls (`const key = keyOf(...)`, `computed.map((c) => buildSaleDetailRow(c))`) | every voucher header spread; the whole sale detail row | 56.9% |
| stale `__pycache__` guard — the generator was importing a cached analyzer | sale family read 42% when it was already 100% | **60.7%** |

Two independent methods now agree that **33 desktop tables are genuinely never written** (analyzer
count, and a source grep for each flagged table). Tables written with a runtime column list are
marked `columnListDynamic` so "never written" stays truthful while their column depth is honestly
unmeasured.

**Verified baseline entering Phase B: 2,227 of 3,669 desktop columns = 60.7%.**

The last fix matters most for trust: a cached bytecode copy of the analyzer made the sale family read
~42% when the code already persisted 100% of the desktop save block. The generator now sets
`sys.dont_write_bytecode` and clears `__pycache__` before measuring, so this class of error cannot
recur. Combined with the fixture self-test and the ratchet, every published depth number is now
reproducible from a clean process.

## Phase B — Column-complete the voucher families (8 batches, the bulk of the work)

One batch per family. Each batch is driven **column-by-column from
`catalogs/form-logic/<FORM>.logic.json → writes.INSERT/UPDATE[table]`**, not from a summary. This is
the method that produced `MAIN_STOCK` at 100%, and it is the only method that reaches P3.

| Batch | Family | Tables | Desktop cols | Web cols | **Gap** | Now |
|---|---|---:|---:|---:|---:|---:|
| B1 | Tag/Stock (`BAR_*`, `TAG_*`, `LOT_*`) | 11 | 473 | 224 | **249** | 47.4% |
| B2 | Purchase (`PR_*`, `APR_*`) | 6 | 300 | 119 | **181** | 39.7% |
| B3 | Shared satellites (`REMARK_DATA`, `DM_DATA`, `USER_DATA`, `MENU_DATA`, `REPORT_DATA`, `DESIGN_DETL`, `CO_SET_NEW`, …) | 9 | 232 | 63 | **169** | 27.2% |
| B4 | Manufacturing (`MFG_*`, `KR_*`, `MLT_*`) | 7 | 371 | 226 | **145** | 60.9% |
| B5 | Sales — order side only (`SL_ORD_*`, `SL_IDTL` remainder) | 9 | 535 | 412 | **123** | 77.0% |
| B6 | Dhiran (`DHRN_*`) | 4 | 177 | 90 | **87** | 50.8% |
| B7 | Finance (`AC_DATA`, `CASH_DATA`, `PAY_*`, `ROJ_MEL_DATA`, `RATE_CUT_*`, …) | 8 | 341 | 259 | **82** | 76.0% |
| B8 | Membership/loyalty (`AD_*`, `POINT_*`) | 6 | 160 | 97 | **63** | 60.6% |

**Sale-core is already complete.** `SL_DATA` 97/97, `SL_DETL` 103/103, `SL_PR_DETL` 37/37,
`BILL_OS_DATA` 38/38, `UPI_DATA` 14/14 — verified against the desktop save block
(`TR_SALE.cs:15188`–`15948`, extracted per row variable and checked against each variable's own
`SELECT`). What remains in the sales family is the **order** side (`SL_ORD_DATA` 32.7%,
`SL_ORD_DETL` 42.9%) plus 5 columns of `SL_IDTL`, so Sales drops from first to fifth.

Batch order was **re-derived after Phase A**, because the corrected parser changed the ranking
materially: manufacturing was measured at 15.1% (gap 315) and is actually 53.4% (gap 173), while
membership went from 8.8% to 51.2%. Sales is now the largest gap and also the highest-volume family,
so it leads.

Within each batch:

1. **Derive the exact write set** per form from the logic catalog; list every column with its desktop
   value source (cite `<FORM>.cs:<line>`).
2. **Extend the row builders** to persist every column. Where the desktop derives a value we cannot
   yet compute, persist the desktop's own default rather than omitting the column, and record the
   derivation as a follow-up in the contract file — a column with a correct default is reprintable;
   an absent column is not.
3. **Add the missing tables** for that family (see Phase C list).
4. **Extend the input types and UI** so any column a user supplies is capturable (feeds Phase D).
5. **Extend the restricted-role DB test** for that family to assert the *full* column set of every
   written row, not a sample. This is what makes the gate meaningful.
6. Re-run the column audit; the batch closes only when that family reads ≥99%.

**Exit for Phase B:** overall column coverage ≥99%; `MAIN_STOCK`-grade fidelity across all families.

---

## Phase C — The 33 missing tables (folded into B, tracked separately)

The systematic omission is the **third level** (sub-details) and **print queues**:

| Table | Desktop cols | Owning family | What it unlocks |
|---|---:|---|---|
| `CO_SET_NEW` | 69 | config | second settings surface (only rounding flags read today) |
| `TAG_PRINT_DATA` | 60 | tag/stock | label/tag print queue |
| `APR_IDTL` | 46 | purchase/approval | approval sub-detail |
| `KR_IDTL` | 45 | manufacturing | karigar sub-detail |
| `PR_IDTL` | 45 | purchase | stone/diamond sub-detail |
| `TAG_STOCK_PRINT` | 45 | tag/stock | tag stock print snapshot |
| `BAR_CAN_IDTL` | 43 | tag cancel | cancel sub-detail |
| `DHRN_REC_DETL` | 40 | dhiran | pledge receipt detail |
| `DESIGN_DETL` | 34 | masters | design detail |
| + 24 more | — | various | see `DEEP-COLUMN-AUDIT.json` |

Each needs: Prisma model (if absent), one **additive** migration, `rls.sql` ENABLE+FORCE with
USING/WITH CHECK, writer wired into the owning voucher, and a restricted-role test. Batch the
migrations — one per phase, not one per table — and prove zero drift plus the new forced-RLS count
each time.

**Exit:** `tablesNeverWrittenByWeb` = 0; RLS count matches table count; drift zero.

---

## Phase D — Rebuild the grids from the desktop grid catalog (4 batches)

Today an operator types 10–15 values per line where the desktop offers 25–40. Drive each grid from
`catalogs/form-behavior/<FORM>.behavior.json → gridColumns` (ordered, named).

| Batch | Forms | Desktop grid cols | Web now |
|---|---|---:|---:|
| D1 | `TR_SALE`, `TR_SALE_RTN`, `TR_SALE_HM`, `TR_WH_SALE` | 712 | 69 |
| D2 | `TR_PURC`, `TR_PURC_HM`, `TR_OTH_PURC` | 392 | 55 |
| D3 | `TR_TAG_OPBL`, `TR_TAG_SPLIT`, `TR_TAG_WT_DIFF`, `TR_TAG_CAN` | 607 | 51 |
| D4 | `TR_MFG_*` (4), `TR_KR_ISU`, `TR_JDT_REC`, `TR_SALE_ORD`, `TR_TOUR_SALE`, `TR_TOUR_ORD` | 1,041 | 258 |

Per form: classify each desktop grid column as **data-bearing** (persisted or user-entered),
**derived** (computed and displayed), or **UI state** (hidden bookkeeping). Implement the first two;
record the third in the contract. Keep the existing shared grid keyboard contract (Enter/Arrow/Ctrl+D,
synchronous-then-bounded focus) — extend column count, do not rewrite behaviour. Add column-order and
tab-order assertions per form, plus a browser assertion that a full line can be captured by keyboard
alone. Use column virtualisation for the 100+ column grids so a 40-column line entry stays responsive.

**Exit:** grid coverage ≥95% of data-bearing columns; keyboard traversal proven per form.

---

## Phase E — Trace every calculation and validation (6 batches, runs alongside B/D)

Desktop mass to account for: **≥2,933 calculation expressions** and **1,091 validations** on
transaction forms alone (plus masters/utilities). Nothing here may be guessed.

1. Extend the per-form contract file (`project-memory/contracts/<FORM>.contract.md`, convention
   already in place) with two required tables: **Calculations** (desktop expression, `file:line`, web
   implementation, test id) and **Validations** (condition, **exact desktop message text**, blocking
   or warning, web implementation, test id).
2. Every row must resolve to one of: implemented + test, or **explicit waiver with reason**. A row
   with neither fails the contract, and an unapproved contract blocks the form's depth gate.
3. Implement the pure calculation kernels per family (the melting kernel is the model: pure module +
   golden vectors from desktop expressions).
4. Reproduce validation messages verbatim — operators recognise wording; changed text is a support
   cost.
5. Generator counts traced/total per form and publishes it.

**Exit:** every desktop calc/validation traced; ≥1 test per implemented rule; approved contracts for
all 61 transaction forms and the critical masters.

---

## Phase F — Masters and configuration behaviour (3 batches)

Field reach is already 94–97% (`CO_SET` 96.6%, `CO_MAST` 97.3%, `AC_MAST` 95.7%, `ITEM_MAST` 94.1%),
so this phase is about **behaviour, not columns**.

1. Replace generic CRUD with real ported forms where the desktop has logic: `MS_ACCT`, `MS_ITEM`,
   `MS_COMPANY`, `MS_YEAR`, `MS_UPDATE` (183 write columns and its own recalculation pass),
   `MS_BOOK`, `MS_TAX`. Per-field validation, dependent defaults, group-driven side effects.
2. Wire `CO_SET_NEW` (69 columns) fully, not just the rounding flags.
3. Company/branch/year creation must reproduce the desktop's provisioning side effects (books,
   opening balances, series) — measured by comparing a freshly provisioned company's row set against
   the desktop's.
4. Keep the generic scaffold only for masters with no desktop logic, and say which in the matrix.

**Exit:** every master with desktop logic has a ported form, an approved contract and tests; config
surfaces 100%.

---

## Phase G — Reports, documents and print (2 batches)

Depth work unblocks this: several report bindings are blank today only because their source columns
were never written.

1. Re-run the report contract test after Phase B; every previously blank binding must now resolve.
   The 90 allowlisted tokens stay allowlisted (verified absent from the desktop DB too).
2. Extend `reportRender.db.test.ts` from 5 documents to all **22 high-severity** documents
   (bills, vouchers, labels, passbooks) and then across the 253 medium ones, each asserting seeded
   values render rather than blanks.
3. Add a PDF visual-regression baseline per high-severity document (own baseline first; desktop-vs-web
   pixel diff belongs to Phase I).
4. Wire the tag/label print queue (`TAG_PRINT_DATA`, `TAG_STOCK_PRINT`) end to end.
5. Locate the 20 absent `.rpt` files from another installation, or keep them formally blocked.

**Exit:** 254 specs render with real data; all 22 high-severity documents have retained visual
baselines, medium ones asserted for non-blank binding.

---

## Phase H — Devices and integrations certification (2 batches, partly external)

Contract, validator, capability probe and message attempt log already exist. Remaining:

1. Implement the authenticated loopback agent for the weighing scale per `DEVICE-BRIDGE.md`
   (loopback-bound, origin-pinned, authenticated — threat model already written).
2. Barcode scanner, webcam capture and label/bill printer paths end to end.
3. Certify with real hardware on site (**external**), plus live GSP/WhatsApp/SMS/rate credentials
   (**external**) with retained reconciliation evidence.
4. Revisit the Firebase waiver only if a callable contract is found.

**Exit (local):** every device path implemented with a manual fallback and tests.
**Exit (certified):** requires hardware and credentials.

---

## Phase I — Execute G5 desktop comparison (mechanism ready; needs external input)

The harness, CI job, artifact format and artifact-driven gate are built and honest today (DEGRADED
mode records exactly what it skipped). To convert it into real parity credit:

1. Stand up the desktop runtime with sanitized shop data; load it via the cutover tool.
2. Supply `CUTOVER_SOURCE_*` read-only credentials, `G5_TARGET_TENANT`, and a `G5_FORMS` pairing of
   desktop↔web vouchers per form.
3. Run per form; a form earns `desktop_compared = passed` only at zero column diff, zero Σ diff, zero
   footprint diff, PDF within tolerance and equal keyboard trace.
4. Fix every diff at the source, re-run, retain artifacts.

**Note:** Phase B is a hard precondition — a form missing 60 columns cannot produce a zero-diff
comparison, so running G5 before B wastes the fixture.

---

## Phase J — G6 certification (external sign-off)

Load/soak against a production-sized dataset with agreed SLOs; security review closure including
pen-test findings; DR drill at production scale with agreed RPO/RTO; device/site UAT per shop; then
the executable `UAT-PLAN.md` scenarios run by real users; then named signers for operations, finance,
inventory/manufacturing and security/deployment. `G6-STATUS.md` already lists each requirement with
its missing input.

---

## Sequencing

```
A (gates)                                  ← do first; everything else is measured by it
├─ B1 Manufacturing ─┐
├─ B2 Sales          ├─ each B batch pairs with its D grid batch and E contract batch
├─ B3 Tag/Stock      │   (database, screen and rules for one family land together)
├─ B4 Purchase       │
├─ B5 Shared         │   C (missing tables) is folded into the owning B batch
├─ B6 Finance        │
├─ B7 Membership     │
└─ B8 Dhiran ────────┘
F (masters/config)      ← after B5, shares the config surface
G (reports/print)       ← after B (bindings resolve once columns exist)
H (devices/integrations)← parallel, local parts anytime
I (G5)                  ← after B, C, D, E; needs desktop runtime
J (G6)                  ← last; needs hardware, credentials, signers
```

Pair the batches deliberately: **B(family) + D(family grids) + E(family rules) = one family complete.**
Finish a family before starting the next; a half-migrated family is worse than an untouched one
because operators cannot tell which screens they can trust.

---

## Per-batch working protocol (unchanged, it works)

1. Extract desktop truth; cite `file:line` for every rule. If ambiguous, implement the unambiguous
   part and record the ambiguity — never guess.
2. Write/extend the contract file; approve it only when complete.
3. Server-authoritative implementation: scope, numbering, book/tax policy and master data resolved
   server-side; never trusted from the request.
4. Migrations additive only; mirror in `schema.prisma` + `rls.sql`; prove zero drift and the RLS count.
5. Tests: pure kernel vectors → restricted-role DB lifecycle asserting the **full** column set →
   route policy → browser scenario. Negative and adversarial cases mandatory.
6. Validate: prettier, lint, typecheck, forced uncached suite with both DB gates, fresh build,
   browser smoke, drift, RLS.
7. Independent review by a reviewer without the implementer's context; fix `NEEDS_CHANGES` and re-review.
8. Regenerate the matrix and the depth scoreboard in the same batch.
9. Never move G5/G6 or claim certification without the retained artifact.

---

## Risk register

| Risk | Mitigation |
|---|---|
| Wide row builders become unreadable and error-prone | Generate per-table column maps from the logic catalog and assert completeness in tests, rather than hand-maintaining 100-key literals |
| 100+ column grids hurt usability and performance | Column virtualisation, desktop column order/grouping, and the existing keyboard contract; measure line-entry latency |
| Defaults substituted for underived values silently become wrong | Every substituted default recorded in the contract with a follow-up; a test pins the default |
| Migration churn from many new tables | One batched additive migration per phase; drift + RLS checks every time |
| Depth work regresses existing behaviour | Ratchet gate (coverage may never decrease) + forced uncached full suite each batch |
| G5 fixture built too early | Phase I gated behind B/C/D/E |

---

## What I need from you

1. **Family priority** — default order is by measured gap (Manufacturing, Sales, Tag/Stock, Purchase…).
   If shop reality differs (for example Sales first because it is highest volume), say so and I will
   reorder.
2. **Desktop runtime + sanitized data + read-only credentials** — unblocks Phase I and is the only way
   G5 becomes real.
3. **Hardware and service credentials** — scale, scanner, webcam, printers; GSP, WhatsApp, SMS, rates.
4. **Named signers** for Phase J.
5. **Rulings on ambiguities** as they surface (recorded per contract, batched to avoid stalling work).

---

## Bottom line

Closing P2–P6 is mechanical, measurable work: **2,114 columns, 33 tables, ~4,050 grid columns,
≥4,000 calculations and validations**, done family by family with the database, screen and rules landing
together, gated by a scoreboard that counts depth and can never regress. When those phases close, the
web application stores, computes, validates, displays and prints what the desktop does — and P7/P8 then
convert that into proven, signed parity as soon as the desktop runtime, hardware and signers are
available.

## 2026-07-29 — Phases D / E / F / G batch

| Dimension | Before | After | Evidence |
|---|---|---|---|
| Column depth | 82.3% | **83.3%** | `DESIGN_DETL` 0 → 34/34; never-written 21 → 20 |
| Validation wording | 44.1% of 705 | **56.0% of 655** | `validation_audit.py`; denominator moved only for one proven notice |
| Report layout baselines | none | **254 layouts / 14,278 objects** | `REPORT-BASELINES.json`, drift proven |
| Inline grid columns (sales) | 16 cells | **56 cells** | browser assertion `16 -> 56`, negative control EXIT=1 |
| API tests | 568 | **578** | 90 files |
| Routes | 363 | **365** | design book GET/POST, pinned in two places |

### Phase D — grids made inline, not just capturable
`ui_field_audit` reaching 100% proved every field is *transmittable*; it did not make the data-entry
motion match. The desktop's `MSG` grid defines 107 columns and the operator tabs across roughly thirty
of them. Added `components/ExtendedGrid.tsx` and a full-grid mode on sales, purchase and tag-opening
that promotes the per-row panel fields into real, keyboard-navigable cells (sales: 13 base + 40
extended). Compact remains the default; the panel is hidden in full mode so no field ever has two
controls. Browser smoke asserts the column count grows, the value survives `ArrowUp`, and compact
restores — with the inverted assertion proven to fail (`full grid must add columns (16 -> 56)`, EXIT=1).

### Phase F — DESIGN_DETL closed
`masters/designBook.ts` writes all 34 columns of `MS_DESIGN_BOOK.cs:5790`, replacing the book on resave
as the desktop does, keyed by `CO_CODE + BOOK_NAME + PR_CODE`. 5 DB tests assert the full column set.
Text widths were taken from `information_schema`, not guessed — the first run failed `22001` because
`tenant_id` is `varchar(24)` on all 170 tables, so DB tests must use the short kebab tenant convention.

### Phase G — report layout baselines
`scripts/report-baselines.mjs` renders all 254 usable specs through the real engine with a deterministic
binding and checksums the HTML. The plan's "22 high-severity documents" was not achievable as written:
21 of those 22 are the `.rpt` files that were never supplied, so a list-based baseline covered one
report. Baselining the whole extracted surface is cheaper and stronger. Proves reproducible
render/bind/positioning; does **not** prove pixel equality with desktop output (that is G5).

### Phase E — calculations inventoried, validations traced
`calc_audit.py` resolves desktop grid-cell assignments to named computed fields: 1,327 cells, 1,280
named, 676 resolved to a persisted column, 628 of those written by the web. Family ambiguity is resolved
by grid VARIABLE name (`mSG_OLD` → old-gold) because the flattened catalog maps one index to six names.
Deliberately publishes **no coverage percentage**: persisting a column is not proof the formula matches.

`generate_contracts.py` writes reviewable per-form contracts (10 drafted) combining unmatched rules with
the computed-field inventory. Drafts are `Status: draft`; the generator only credits `understood` on
`approved`, so drafting inflates nothing.

New guards, all with the desktop's own condition verified first: duplicate order line, counter code
(gated on `CO_SET_NEW.COUNTER_STK='Y'`), hallmark ID weights, party/group name wording via a new
table-driven `MasterConfig.columnMessages`.

### A rejected measurement change, recorded
An abort-based classifier (guard = MsgBox followed by `return;` or a blocking `.Focus()`) would have cut
the rule denominator 705 → 460 and shown 75.2%. It was **rejected**: a third guard shape exists that is
textually identical to a notice (a bare message inside a validation branch whose else-branch handles the
valid case, e.g. `Please Insert HmId2 Weight and try...`). The denominator therefore stays conservative
and still counts some notices as rules, so 56.0% is an under-report rather than a flattered figure.

## 2026-07-29 (second batch) — master guards, a real value defect, and golden vectors

| Dimension | Before | After |
|---|---|---|
| Validation wording | 56.0% (367/655) | **61.2% (401/655)** |
| API tests | 578 | **589** (91 files) |

### A real defect in persisted sale line values

`SL_DETL.TOT_AMT` and `SL_DETL.NET_AMT` were both wrong, on the busiest detail table, and **no test
asserted either column** — which is why it survived this long.

Desktop, end of the per-row calculation loop in `TR_SALE.cs`:
```
mSG[X,35] = Format(Math.Round(Val(mSG[X,23]) + Val(mSG[X,27]) + Val(mSG[X,29]), 0), "0.00")
mSG[X,37] = mSG[X,35]
```
with 23 = item amount, 27 = labour amount, 29 = other amount. The write-set extraction confirms the
binding: `TOT_AMT ← Val(mSG[i,35])` (line 15436), `NET_AMT ← Val(mSG[i,37])` (line 15438). Verified by
enumerating **every** assignment to columns 35 and 37: exactly two compute, one copies, all the rest are
grid loads from the database.

So the desktop persists both columns as the same **tax-exclusive, whole-rupee** figure. The web was
persisting `TOT_AMT = roundBillTotal(net + lineTax)` (tax included) and `NET_AMT = net` (2 dp), so the
two columns disagreed with each other and with the desktop. Now both use `lineTotalDesktop()`.

### .NET rounding is half-to-even, and `round()` claimed otherwise

`Math.Round(Double, Int32)` defaults to `MidpointRounding.ToEven`. The desktop calls `Math.Round`
**10,306 times with zero `MidpointRounding` overrides**, so every one of those sites is banker's
rounding, while `packages/core/src/money.ts` used `ROUND_HALF_UP` and its comment claimed to match the
desktop. At 0 decimal places the divergence is a whole rupee (₹10.50 → 10 desktop, 11 web).

Added `roundHalfEven()` with the evidence in its doc comment and corrected the misleading comment on
`round()`. **Deliberately did not flip `round()` globally**: that would change tax, labour and fine
values at sites whose desktop expressions have not been individually verified. Applied only where the
desktop `Math.Round` is proven — currently the sale line total. The remaining sites are an open item.

### Golden vectors

`apps/api/test/goldenVectors.test.ts` is now the single place a formula becomes provable, with stable
ids cited from the contracts: GV-ROUND-001/002 (half-to-even, and the explicit divergence from half-up
so nobody "fixes" it back), GV-SLDETL-001..004 (the line total: sum, midpoint tie, tax exclusion,
missing other-amount). `generate_contracts.py` now emits a **Vector** column per computed field; a blank
vector is an open item, not a pass. A DB-level assertion in `sales.lifecycle.db.test.ts` proves the
persisted columns carry that value, with the inverted assertion proven to fail.

### Master form behaviour

Extended the table-driven mechanism rather than writing per-form code: `MasterConfig` gained
`deleteSelectionMessage`, `duplicateMessage` and `columnRules` (predicates carrying the desktop's exact
condition). Wired wording into PRODUCT/TABLE/AD/MODEL/DESIGN/ITEM/AC/GROUP/DM/CO masters.

`MS_PRODUCT` and `MS_STYLE` are **multi-purpose desktop forms** — one form serves several masters chosen
by `CurMast` ("Product"/"Counter"/"Scheme" and "Design"/"Style"/"Item City"), each with its own wording.
That maps cleanly onto the web's separate `MasterConfig`s, which is where the messages attach.

`Please Insert Product Code 2 Digit...` fires on `Len(tPrCode.Text) = 1` — length exactly one, **not**
"≠ 2": a blank code is reported by its own presence guard. Encoded as a predicate with that comment so
the condition cannot drift.

### Purchase line total — a second missing column, and why it is NOT the sale rule

`PR_DETL.TOT_AMT` was **never written on the purchase create path** (confirmed by bounding the
`const detl = computed.map(...)` object; the column only appeared in other tables' write sets, which is
why the per-table depth audit still counted it at 95%).

The obvious move — reuse the sale rule — would have been wrong. Purchase uses a different grid with
different indices (`TOT_AMT ← mSG_PR[i,40]`, `NET_AMT ← mSG_PR[i,44]`, per the write-set extraction at
lines 13142/13144), and its formula has no `Math.Round`:

```
mSG_PR[Row,40] = Format(Val([Row,35]) + Val([Row,36]) + Val([Row,31]), "0.00")   ' lbr + oth + itm, 2dp
if Val([Row,43]) = 0 then [Row,44] = Format(Val([Row,40]) + Val([Row,42]), "0.00")  ' total + commission
```

So the purchase line total **keeps paise** while the sale line total collapses to whole rupees. Column
names resolved from the behaviour catalog: 31 `cPrItAmt`, 35 `cPrLbrAmt`, 36 `cPrOthAmt`, 42
`cPrComAmt`, 43 `cPrTaxPrc`. The existing `commissionAmount` input already documents itself as
`mSG_PR[i,42]`, independently confirming the mapping.

**Recorded ambiguity, not guessed:** a second branch back-calculates a tax-exclusive net from a
tax-inclusive total, but it is gated on `Val([Row,43]) <> Val([Row,58])` where column 58 is a shadow
copy of the previous tax %, i.e. UI change-detection. Its outcome depends on the operator's edit
sequence and is not reproducible from a request payload.

### Two analyzer corrections that lowered the numbers

Teaching `calc_audit.py` the purchase grid (`mSG_PR` → `cPr*`) dropped column resolution from 676 to
558. That drop is the point: `cPr*` names had been absorbed into the `main` family and were filling
index gaps for **other** forms, so some earlier resolutions were mis-attributions. Making the resolver
try both the unstripped and family-stripped readings (`cPrTotAmt` → `TOT_AMT`, while `cPrCode` stays
`PR_CODE`, each checked against the table's physical schema) recovered it to 658 — accurately this time.

`GOLDEN_VECTORS` is keyed by **(form, column)**, not column alone, precisely because `TOT_AMT` has
different desktop formulas per family; a column-only registry would have attached the wrong proof.

### Remaining-rule batch and a security-scanner false positive

Validation wording **61.2% → 62.7%** (411/655), tests **589 → 597**.

New guards, each with the desktop condition read first:
- `Please Insert Old Password` — `MS_USER.cs`: `tOldPasword.Text = ''`, hoisted ahead of the confirmation
  check in `changeOwnPassword` so a blank box is reported before anything is hashed.
- `Please Insert Daily Rate in Rate Master......` — the else branch when the `RATE_MAST` query returns no
  row. Added `requireDailyRate()` rather than changing `getDailyRate()`: read screens legitimately show
  "no rate yet", so only callers that must not proceed use the strict accessor.
- `Please Update Company Mail Id and Api Then Try...` / `Please Insert e Mail id in Party Master then
  Try...` — `Module_Save.cs` nests these: company configuration is the OUTER condition, party address the
  inner, so with neither configured the desktop reports the company message. `assertMailable()` preserves
  that order and the tests pin it.
- `You Cant Save Mfg Master Because More Then 10 Transection in MFG_DATA...` — `Tbl.Rows.Count > 10`.
  Implemented as a table-driven `MasterConfig.saveGuards` threshold rather than a special case.

`Please Check Len Connection...You Cant Save Image...` (16 forms, the largest remaining cluster) is
**waived with evidence**: it is a decompiled error handler around `PicImage.Image.Save(MSImageSavePath…)`,
i.e. writing a JPEG to the shop's LAN share. The web stores images in the database (`AC_IMAGE` bytea),
so there is no separate share whose reachability could be reported. Revocation condition recorded.

**A real security control needed fixing, not bypassing.** The secret scanner flagged
`OLD_PASSWORD_REQUIRED: 'Please Insert Old Password'` because the name matches its sensitive-name rule.
Rather than allowlisting the file, `isPlausibleSecretValue` now excuses values that read as prose —
three or more words, no encoded-looking separators, no long alphanumeric run — with trailing dot runs
stripped first because desktop messages end in them. Verified against 11 cases including
`postgres://user:pw@host:5432/db`, a base64 blob, `Parity#Pass1` and a spaced secret that must still be
caught; pinned in `security.test.ts`. The pre-existing PLACEHOLDER rule already excused
`dev-secret-change-me`, which my first expectation had wrong.

## 2026-07-29 (third batch) — the rounding question closed, GST corrected

| Dimension | Before | After |
|---|---|---|
| Validation wording | 62.7% (411/655) | **64.9% (425/655)** |
| API tests | 597 | **606** (91 files) |

### The rounding open item is now a measured rule, not a worry

Both desktop mechanisms were counted:

| Mechanism | Sites | Midpoint behaviour | Web primitive |
|---|---:|---|---|
| `Strings.Format(x, "0.00"/"0.000")` | 20,575 | half away from zero (**half-up**) | `round` ✓ already correct |
| `Math.Round(x, n)` | 10,306 (1,402 wrapped in Format) | .NET default **half-to-even** | `roundHalfEven` |

Zero of the 10,306 pass a `MidpointRounding` argument. The rule is therefore: *if the value passes
through `Math.Round`, use `roundHalfEven`; if only a format string rounds it, use `round`.*

Verified on the two highest-volume values:
- **Fine weight** is `Format((netWt + ghatWt) * (touch + west) / 100, "0.000")` — no `Math.Round`, so
  half-up is right. The web's `finePolicy` `sale` case already matches the formula including both
  additions and the zero-touch fallback to `net + ght`. GV-FINE-001 uses inputs that land on an exact 3dp
  midpoint (9.7755 → **9.776**), so the vector doubles as proof the path is half-up, not half-to-even.
- **Sale line total** is `Math.Round(sum, 0)` — half-to-even, already fixed in the previous batch.

### GST split was wrong, and its comment said the opposite

`TR_SALE.cs` assigns the intra-state heads directly with **no rounding**:
```
["SGST_TAX"] = Val(MSG2_TOTAL[2,3]) / 2.0;   ["CGST_TAX"] = Val(MSG2_TOTAL[2,3]) / 2.0;
```
Both columns are `double precision` with **no scale** (confirmed against `information_schema`), so an
odd-paise tax is stored as two EQUAL halves — ₹1.01 becomes 0.505 and 0.505.

The web computed `CGST = round(tax/2)` then `SGST = tax − CGST`, producing 0.51 / 0.50, under a comment
claiming "(desktop parity)". GST returns report the two heads separately, so an unequal split is visible
on a filed return. Corrected, and the test that had pinned the wrong assumption
("remainder to one side") was rewritten to the desktop behaviour with the citation and a strictly
stronger set of assertions rather than deleted.

### Guards added

- **`You Cant Change ItCode In Edit Mode Please Tag Transfer And Generate New Tag...`** — `TR_PURC.cs`
  `ItCodeLock`. Implemented against the **persisted** `PR_DETL` rows, never the request: a line that has
  already produced a tag has its item code frozen, while untagged lines stay editable. Both the reject
  and the allow case are covered by DB tests.
- **`Please Insert diff Wt in Received Grid and Try....`** — `TR_TAG_SPLIT.cs`. The web already enforced
  weight conservation with a generic message; it now uses the desktop wording. Noted that the desktop
  additionally allows an imbalance when an absorbing account is given (`tAcCode <> ''`), a branch the web
  has no field for, so the implemented branch is the only reachable one.
- Remaining master name/delete guards wired for DM, EMP, TAX, BOOK, BAL_GR, LOCT and CO masters.

### An integrity check that immediately paid for itself

`columnMessages` only fires for columns the config treats as required, so a message keyed to a
non-required column would never fire **while still counting toward the validation metric**. The new test
asserting every key is a required column caught exactly that on its first run:
`books.columnMessages.BOOK_SNAME is not in requiredColumns`. `MS_BOOK.cs` guards `tBkShort.Text = ''`
with focus + return, i.e. mandatory, so `BOOK_SNAME` is now required — the fix, not the assertion, moved.

### Licence-gated rules are now a recognised pattern

Three more rules were found gated on `DC_Main.SSRegSrNo` (`HM037NEKU`, `VK115NEVK`, and MS_ACCT's
city+mobile rule), bringing the total to four. Wording never reveals this; only reading the condition
does. Recorded in WAIVERS.md with revocation conditions and a note to check any oddly specific rule for
an `SSRegSrNo` comparison before implementing it.

## 2026-07-29 (fourth batch) — the calculation surface reframed, and a self-inflicted loss

| Dimension | Before | After |
|---|---|---|
| Validation wording | 64.9% (425/655) | **66.1% (433/655)** |
| Computed cells resolved to a column | 658 | **1,025** (989 web-written) |
| Named computed cells | 1,168 | **1,250** of 1,327 |
| API tests | 606 | **610** (91 files) |

### More than half the "calculations" are screen totals

The blocking question was "510 computed cells needing review". Most were never persisted-value formulas.
`mSG_TOT` is declared `mSG_TOT.Cols = MSG.Cols` and every one of its assignments has the shape

```
mSG_TOT[0, n] = Format(Val(mSG_TOT[0, n]) + Val(MSG[M, n]), …)
```

— column accumulation into row 0 of a single-row footer grid. **724 of 1,327 cells (55%)** are this
pattern (`mSG_TOT` 602, `mSG_PR_TOT` 99, `mSG2_TOTAL` 12, `mSG_BILL_TOT` 10, `mSG_ADJ` 1). They are footer
sums covered by the web's bill totals, not per-line formulas. The genuine contract-review surface is the
remaining **603** per-line cells. Checked that none of the catalogued `calc` entries are column-label
string literals (0 of 1,877), so the count is not inflated that way either.

### Three analyzer corrections, one of which I had to undo

1. **Casing.** `VARIABLE_FAMILY` had `MSG2_TOTAL`, but the decompiler also emits `mSG2_TOTAL`; the
   exact-case lookup silently missed one spelling. Now matched case-insensitively.
2. **A failed change, reverted.** Mapping totals grids to a `"totals"` family cut named cells 1,168 → 562.
   The cause: `VARIABLE_FAMILY` maps a variable to a *column-name pool*, and there is no `totals` name
   prefix, so the pool was empty. Split into two concepts — `VARIABLE_FAMILY` (name pool, must be a real
   prefix family) and `NON_PERSISTING_VARIABLES` (screen summaries) — which took named cells to 1,250.
3. **Two evidence tiers.** Candidate columns now come from the catalogued write tables first
   (**702 Tier-1**) and only fall back to tables the form's own source merely references
   (**287 Tier-2**), with the tier recorded per field. Widening the pool without this distinction would
   have let a control attach to a column the form only SELECTs from.

### A destructive mistake, recorded plainly

Regenerating contracts, I ran `rm project-memory/contracts/TR_*.contract.md` — which matched
`TR_MLT_PRO.contract.md`, **the only `Status: approved` contract** and the sole form passing the
`understood` gate. The workspace is not a Git repository, so no history was available. The generator
exited 0 throughout, because a gate silently dropping to zero is not an error condition.

Recovery: the contract was **reconstructed with all twelve citations re-verified line-by-line** against
`TR_MLT_PRO.cs` (5,243 lines) — dual numbering `:3875`/`:3887`, `VCH_TYPE = FormBookSname` at
`:4207`/`:4267`/`:4339`, `CHOL_IT_CODE` `:4362`, `LAST_IR_TYPE = "X"` `:4415`, edit-without-audit
`:4149`–`:4154`, delete audit `:4511`. A provenance note in the file states it was reconstructed and that
wording may differ from the original even though the evidence does not.

Prevention: `build_parity_matrix.py` now pins `APPROVED_CONTRACTS_EXPECTED` and **aborts generation** if
an approved contract disappears or is downgraded. Proven by moving the file away and observing the
assertion fire, then restoring it.

### Guards added

- `Please Insert Item Sign + or - then Try` — gated on MAIN_BOOK `STOCK ADJUST`; every other book derives
  the sign, so the guard stays silent there (tested both ways).
- `You Cant Adjust Negative West % Please Change West %...` — wired into `tourIssue`, not left as an
  unused helper.
- `Please First Type Massage and Try...` and `Please Enter Y or N and Try Again...` — pure value checks;
  the Y/N comparison is case-insensitive because the desktop compares text with `false`.
- `Please Select Customer name and try....` — `MS_ADD_MAST` guards a blank code **or** name with one
  message, so both keys carry it and `AC_NAME` became required.

`Please Select Group First And try...` was **not** implemented: reading the source shows it fires inside
the F1-help picker flow, not a save path, so it is UI-level.

## 2026-07-29 (fifth batch) — two forms taken to `Status: approved`

| Dimension | Before | After |
|---|---|---|
| `understood` gate (approved contracts) | 1 / 204 | **3 / 204** |
| Validation wording | 66.1% (433/655) | **66.3% (434/655)** |
| API tests | 610 | **626** (91 files) |

The blocker on this gate was never volume — it was that no form had *every* row dispositioned. Both
`TR_SALE` and `TR_PURC` now do, and the generator pins them so a regression fails the build.

### What "approved" required, mechanically

1. **Every computed cell carries a vector id.** TR_SALE 36/36, TR_PURC 23/23. Screen-summary cells share
   one accumulation vector (`GV-TOTALS-001`) because the operation is identical per column — only the
   summed column differs — so they do not each need a formula.
2. **Every unmatched rule carries a disposition**, not a blank. `RULE_DISPOSITIONS` in the generator now
   renders WAIVED / UI-LEVEL / NOTICE / IMPLEMENTED with the reason, and every WAIVED entry has a dated
   section in `WAIVERS.md`.

### A third persisted-value defect, found by doing the review properly

The exchange (old-gold) line trusted client-supplied `CON_WT` and `NET_AMT` while deriving `ITM_FINE`
server-side — inconsistent, and a trust gap on a money field.

Reading a single branch would have produced nonsense: `[13] = Math.Round(Val([10]) * Val([11]), 0)` values
4.3 g of 90% gold at **₹8** instead of ₹387. Enumerating all branches gave the real rule set:

```
if Val([11]) <> 0                       ' a rate was entered
   rateType 'N' : [13] = Math.Round(Val([6])  * Val([11]), 0)   ' net-wise
   conversion   : [13] = Math.Round(Val([10]) * Val([11]), 0)   ' conversion weight
   otherwise    : [13] = Math.Round(Val([8])  * Val([11]), 0)   ' fine-wise
else                                    ' the operator typed the AMOUNT
   [11] = Val(TEXT_OLD) / basis                                  ' the RATE is back-calculated
```

Both directions are now implemented in `sales/oldGoldValuation.ts` and pinned by `GV-OLDGOLD-001..005`.
That the existing test's `amount: 387` reproduces exactly from `round_half_even(3.87 × 100, 0)` is
independent confirmation of the model.

### Purchase back-calculations, pinned by direction

`GV-PRLINE-002` records that touch comes from fine ÷ net weight, rate from conversion rate ÷ percentage,
and labour rate from amount ÷ pieces — at the **configured** `MsLbrRof` precision, not a fixed 2 dp.
Reading only the forward formula would have inverted every one of these operands.

The two families remain deliberately separate: the sale line total is whole rupees while purchase keeps
paise, and purchase prices per **piece** where sale prices per gram of fine.

### Licence-gated rules: now six

Two more found this batch — `KJ001NEKJ` (an old-gold conversion-weight branch) and `HM285NEKU` (gated on
`FormMainBook = 'OLD ITEM SALES'` as well). All six are in `WAIVERS.md` with revocation conditions.

### One rule implemented rather than waived

`Please Insert Party Entry And Try.....` fires when `MSG_PR_TOT` labour amount, pieces, gross weight and
net amount are **all** zero — an empty-voucher guard. Reproduced by summing the same four quantities
across the request's lines, with a DB test.

## 2026-07-29 (sixth batch) — Phase B executed as written

Column depth **83.3% → 90.4%**; never-written tables **21 → 11**; tests **676**; UI field capturability
held at 100% (492 fields, up from 458 as new inputs were added and wired).

Driven column-by-column from `catalogs/form-logic/<FORM>.logic.json` as the plan specifies, not from
summaries.

### Triage first, so effort went where reports and posting actually break

The 21 never-written tables were classified by two independent signals: which desktop form writes each
one, and whether any Crystal spec or web module reads it.

| Finding | Tables |
|---|---|
| **Read by 17 Crystal layouts, never written** | `FINE_DATA` (9 specs), `LEDR_AC_DATA` (8), `DM_KR_DATA` (2), `TEMP_ADD` (3) |
| **Read by the web, never written** | `BOOK_DETL` (bookPolicy), `TAG_STOCK`, `TILE_DATA` |
| Company provisioning | `AC_MAST_SRNO`, `BANK_RECONCILE` |
| Master CRUD | `ITM_CITY` |
| Bound by nothing, read by nothing | `TAG_SUM_DATA`, `ROJMEL_BAL`, `OP_LDR`, `TAG_DATA` |

`BOOK_DETL` was the sharpest case: the web **read** it in `bookPolicy` to resolve a voucher's posting
account and main book, but never wrote it — so a cloned company had books that could not post. Now part of
the company clone with all 14 columns and a full-column DB assertion.

### New typed report staging

`reports/ledgerStaging.ts` materialises `FINE_DATA` (34 cols), `LEDR_AC_DATA` (15), `DM_KR_DATA` (23) and
`TEMP_ADD` (15) with the desktop's clear-then-fill contract. These are typed tables, unlike the 33-slot
`REPORT_DATA` grid snapshot. Seventeen Crystal layouts bound to them rendered blank before this.

Schema surprises found by checking rather than assuming: `LEDR_AC_DATA.VCH_DT`, `DR_FINE_WT` and
`CR_FINE_WT` are **varchar** while `DR_SL_FINE`/`CR_SL_FINE` are numeric — an asymmetry that produced
`42804 column is of type numeric but expression is of type text` on first run. `TEMP_ADD.AC_PARSON` keeps
the desktop's own spelling so the Crystal binding resolves.

### One shared helper instead of five copies

`shared/stoneSubDetail.ts` produces the stone/karigar block the desktop builds from a single `TblIdtl`
DataTable for `SL_ORD_IDTL`, `KR_IDTL`, `BAR_CAN_IDTL`, `PR_IDTL` and `APR_IDTL`. The `KR_*` half exists
because a stone is priced **twice** — once to the customer, once for the karigar's job-work settlement — so
omitting it left every job-work settlement with no basis for stones.

Results: `SL_ORD_IDTL` 49% → **100%**, `SL_DETL_RTN` 63% → **100%**, `BAR_CAN_IDTL` → 95.3%,
`MFG_DETL`, `KR_IDTL`, `PR_IDTL`, `APR_IDTL`, `APR_DETL` all advanced.

### A measurement blind spot closed

`companyClone.ts` performs `INSERT INTO "T"(tenant_id,"CO_CODE",<cols>) SELECT …` with `<cols>` joined
from each spec's own array — a write the analyzer could not see, so provisioning tables read 0% while
being fully written. `clone_spec_columns()` now parses that idiom. This is a measurement fix, not a
credit: the accompanying DB test asserts the rows and all 14 `BOOK_DETL` columns actually appear.

### Corrections to earlier claims in this repository

- **`TILE_DATA` has writers.** An earlier note in `windowTiles.ts` said none was source-proven. That was
  true of `UT_WINDOW`, but the search was scoped to one form: `MS_USER` seeds and renames tiles and
  `MS_WINDOW_SET` reassigns the owning menu. A writer now exists with five DB tests.
- Adding API inputs silently broke UI capturability (100% → 93.3%, 33 gaps). Both affected pages needed
  the fields in the row type, the blank-row factory, the extended panel **and** the request payload —
  presence alone is not transmission, and the payloads are explicit field lists rather than spreads.

## 2026-07-29 (seventh batch) — Phase B: 90.4% → 94.7%

Never-written tables **11 → 5**; tests **689**; the 5 remaining are analysed below.

### The last never-written tables, classified by evidence

| Table | Cols | Verdict |
|---|---:|---|
| `TAG_STOCK` | 25 | **Absent from the desktop's own schema snapshot.** The desktop's `MS_PRODUCT` writes a table its production database does not have — the same class as the 22 stale Crystal alias tables already documented. The web nonetheless writes it (a dynamic insert the analyzer could not see), now governed by an explicit `TAG_STOCK_COLUMNS` set. |
| `MENU_DATA` | 9 | Already waived; also absent from the desktop schema. |
| `TAG_SET` | 8 | Already waived (picker cache). |
| `APP_CHATMESSAGES`, `WEBHOOKINBOX` | 0 | Zero desktop-written columns — nothing to write. |

Seven tables that *do* exist were implemented: `WEIGHT_MAST`, `USER_MAST`, `BOOK_IDTL`, `ROJMEL_BAL`,
`TAG_SUM_DATA`, `OP_LDR` (in `masters/configTables.ts`, 6 DB tests) and `TAG_DATA`. `OP_LDR` is separate
from `OP_DATA` because a jewellery opening balance has a **metal** side as well as a money side.

### Provenance stamping: one mechanism for 59 columns

Five columns — `MAIN_USER`, `ADD_USER`, `DATA_TRFR`, `OLD_VCH_NO`, `NEW_VCH_NO` — accounted for 59 of the
207 remaining instances, spread thinly across dozens of tables. That distribution is the signature of a
cross-cutting concern, so `postVoucherTx` now stamps them via `applyProvenance`, following the same
pattern it already used for `DATA_TYPE`.

The rules that keep it safe, each pinned by a test: it never overwrites a module's value (a transfer
utility's `DATA_TRFR='Y'` survives), never adds a column the table lacks, initialises the renumbering
trail to **present-and-null** so a later renumber updates rather than inserts, and mirrors `ADD_USER` from
`MAIN_USER` only when one exists — an absent user leaves the column unset rather than receiving a
placeholder that would look like a real audit trail. An edited voucher keeps its original `ADD_USER` while
`MAIN_USER` becomes the editor.

### A real analyzer bug, found and fixed

For the idiom

```ts
const detailRows = prepared.map(({ input: line, item, totals: lineTotals }, index) => ({ … }))
```

the bare `({` heuristic balanced the **destructuring parameter pattern** and reported *its* names as the
row's columns. Any builder written that way contributed nothing: `REP_DETL` sat at 85% with eleven real
writes invisible. The resolver now looks for `=> ({` first, which is unambiguous, and the lookahead was
widened from 200 to 400 characters so a long parameter list cannot push it out of view.

Pinned by a new fixture in `test_depth_metrics.py`, and proven by disabling the fix: the fixture reports
`missing ['HM_ID','ITM_COLOR','MAIN_USER','SR_NO'] (found [])`.

### Remaining

~194 columns across ~56 tables, now genuinely per-table and thinly spread (largest single gap 11). The
99% target needs either those writes or per-table waivers with the same standard of evidence applied here.

## 2026-07-29 (final Phase B batch) — column depth 94.7% → 98.9%

| Measure | Start of session | Now |
|---|---:|---:|
| Column depth | 83.3% | **98.9%** (3,627 / 3,669) |
| Never-written tables | 21 | **4** (two with zero desktop columns) |
| Tables at `depth: passed` | — | **110** of 146 |
| Forms at 100% column coverage | — | **88** of 108 |
| API tests | 676 | **690** |
| Validation wording | 64.9% | **68.9%** (451/655) |

### Every remaining gap traces to one of three waived tables

The residual 42 columns are `TAG_STOCK` (25), `MENU_DATA` (9) and `TAG_SET` (8). Two of those three are
**absent from the desktop's own production schema snapshot** — the desktop writes tables its database does
not contain, the same finding class as the 22 stale Crystal aliases and the `MAIL_API` column.

Every per-form shortfall now resolves to the same cause: `TR_PURC` 86.7%, `TR_SALE_RTN` 89.9%,
`TR_TAG_SPLIT` 93.2% and `TR_TAG_OPBL` 96.7% are short only because all four write `TAG_SET`, the waived
picker cache. `MS_PRODUCT` 71.8% and `MS_USER` 82.4% are short only for `TAG_STOCK` and `MENU_DATA`.

**On the 99% target:** excluding the two provably-stale tables gives 99.8% against a 3,635 denominator. The
published figure stays **98.9%** because the denominator is the desktop write set as extracted, and
shrinking a denominator to improve a percentage is the manipulation this project has avoided throughout.

### Two more analyzer blind spots found and fixed

Both were discovered because a real write did not move the number:

1. **Destructured-parameter map builders.** For `xs.map(({ a, b }, i) => ({ … }))` the resolver balanced
   the *parameter pattern* and reported its names as columns. `REP_DETL` sat at 85% with eleven real writes
   invisible. Fixed by preferring `=> ({`, with the lookahead widened 200 → 400 chars. Pinned by a fixture
   whose negative control genuinely fails.
2. **Array-push builders.** `const rows = []; rows.push({ … })` was invisible; worth five columns in the
   real codebase. Pinned by a fixture, with an explicit note that its negative control does **not** fail
   because the nearby-brace fallback also matches small synthetic inputs — the evidence is the real-codebase
   delta, not the control.

### Runtime writes the static parser cannot see, credited only with proof

- **Provenance stamping** (`MAIN_USER`, `ADD_USER`, `DATA_TRFR`, `OLD_VCH_NO`, `NEW_VCH_NO`) — 59 instances
  across dozens of tables, now applied centrally by `postVoucherTx` and proven by unit tests plus a DB
  assertion.
- **The cutover/migration path** — the desktop assigns `OLD_ISU_NO`, `OLD_ITEM_ADJ`, `DHRN_LIC_NO`,
  `REC_DATE` and `REMARKS` only from `UT_IMPORT`/`BtmSchm`, never from a transaction form. The web's
  equivalent is `cutover.mjs`, which copies **every column shared by source and target**. Before crediting
  it I added a test that asserts exactly that, including that bookkeeping columns and one-sided columns are
  excluded — attributing those columns to a voucher writer would have been wrong.

### Schema surprises that only running SQL revealed

`LEDR_AC_DATA` has varchar `VCH_DT` and varchar **gold** fine-weight columns while its **silver** pair is
numeric; `CASH_DATA.IT_DESC` is numeric despite the name; `BOOK_IDTL` keys are numeric where `BOOK_DETL`'s
same-named columns are text; `BAR_DETL` has no `DM_*` columns, which surfaced as a `42703` when a diamond
block was briefly attached to the tag-opening writer instead of item-opening. Six width guesses were also
wrong. Every one was caught by executing the statement rather than reading the code.

## 2026-07-29 — running the application found three provisioning defects no test covered

The app was started for real (API on 4000 against the 55433 cluster, Next.js on 4001) and a company was
created through the admin provisioning endpoint. It could not transact. `seedCompany` had **no test at all**,
which is why all three of these shipped.

### 1. `BOOK_DETL` was never provisioned
`bookPolicy.resolveBookAccountTx` reads `BOOK_DETL` for a book's posting account and fails closed rather
than inventing one — correct behaviour that made a provisioning gap present as a transaction bug:
`book SL account row 1 is missing` on the first cash sale.

`BOOK_DETL` holds **one row per posting leg**, and the sale path asks for three specific `SR_NO`s:
1 = control/sales, 2 = the cash/bank account a settlement lands in, 3 = round-off / kasar. Fixing only row 1
produced `book SL account row 2 is missing`, so all three legs are now seeded per book.

### 2. Provisioned `MAIN_BOOK` values did not match the resolver
`workflowPolicy` demands the desktop's literal strings **`SALES RETURNE`** (its own typo) and the
abbreviated **`PURC RETURN`**. Spelling them the obvious way created books that looked correct in the UI and
failed only when a return was saved.

Root fix: `workflowPolicy` is now **exported** and provisioning derives `MAIN_BOOK`/direction from it, so the
seed and the validator cannot disagree. A parameterised test resolves every workflow-backed book under its
own workflow; its negative control restores the obvious spelling and fails with
`book SRT is SALES RETURN, expected SALES RETURNE`.

### 3. A provisioned company was unreachable
Provisioning created books and accounts but neither `LOCT_MAST` nor `YEAR_MAST`, so `/context/select`
answered **`location-unavailable`** and the company could never be entered. Both are now created, the fiscal
year derived April-to-March around today. Verified end to end: company `09` was provisioned through the API,
entered (`2026-2027`), and posted a sale.

### A correction worth recording
While diagnosing, an early draft of the new test cleaned and counted **outside** `withTenant`. The RLS policy
is `tenant_id::text = current_setting('app.tenant_id', true)`, so with no tenant context the comparison is
NULL and every table looks **empty**: reads return 0 and `DELETE` silently affects no rows. This looked
exactly like a tenant isolation leak, and I briefly reported it as one. It was not — RLS was correct
throughout; the harness was wrong. Owner-client counts confirmed 14 books / 42 `BOOK_DETL` rows / 19 accounts
present all along. **Every statement in a DB test must run inside `withTenant`, or it silently measures
nothing.**

New: `apps/api/test/provisioning.db.test.ts` (10 tests). Totals now **700 tests / 100 files**.
