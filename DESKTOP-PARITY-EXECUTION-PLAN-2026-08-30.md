# Desktop parity execution plan — 2026-08-30

Goal: a web platform a real jewellery business can run instead of the desktop application, where every form,
workflow and database write is provably the same.

Every baseline number here was measured today from the extracted desktop source, the retained real-desktop data,
and the current web code. Sources are named so each can be re-measured rather than believed.

---

## Part A — What "the same as the desktop" has to mean

Parity is not one property. A voucher can save without error, show the right total on screen, and still be wrong
in the database in ways that only surface at month-end. Four independent dimensions must each be proven, and
today each is measured separately:

| #   | Dimension           | Question it answers                                              | Current measured state                                     |
| --- | ------------------- | ---------------------------------------------------------------- | ---------------------------------------------------------- |
| D1  | **Database parity** | After the same input, are the rows and columns identical?        | **0 of 66** real vouchers match                            |
| D2  | **Workflow parity** | Do create / reopen / edit / delete / reverse behave identically? | 11 defects in 5 families examined; ~56 families unexamined |
| D3  | **Form parity**     | Same fields, grid columns, calculations, validations, keyboard?  | grid **4.5%**, controls **25.3%**, validations **61.7%**   |
| D4  | **Report parity**   | Does the same data produce the same report output?               | 45 desktop report forms; comparison artefact **missing**   |

A family is only "at parity" when all four hold for it. Nothing in the system is at parity on that definition
today.

---

## Part B — Measured baseline

### B1. Surface

|                   | Desktop                                    | Web                                |
| ----------------- | ------------------------------------------ | ---------------------------------- |
| Forms             | 204 analysed (199 C# + 59 VB source files) | 101 Next.js pages, 188 API modules |
| Transaction forms | **61**                                     | 404 HTTP endpoints                 |
| Report forms      | **45**                                     | —                                  |
| Master forms      | **33**                                     | —                                  |
| Utility / other   | 22 / 43                                    | —                                  |
| Source size       | 991,061 lines decompiled                   | 77,954 lines                       |
| Severity mix      | 17 critical, 55 high, 89 medium, 43 low    | —                                  |

Source: `project-memory/parity/DEEP-DEPTH-AUDIT.json` (204 per-form records).

### B2. Desktop behaviour that must be reproduced

Across the 61 transaction forms alone:

| Artefact                | Count     |
| ----------------------- | --------- |
| Grid columns            | **5,108** |
| Controls                | 3,612     |
| Calculation expressions | 2,933     |
| Validations             | 1,091     |
| Inline SQL statements   | 2,567     |
| Keyboard key handlers   | 418       |

Whole application: 3,309 calc expressions, 1,849 validations, 5,128 inline SQL, 377 handlers.

### B3. Coverage per dimension

**D1 — database.** `parity-compare.mjs` against `desktop-latest.json` (66 real vouchers):

```
casesMatched 0 / 66 · fieldDifferences 3,787 of 23,574 · rowsMissing 210 · rowsExtra 210
tablesDesktopOnly 53 · tablesWebOnly 105
```

Of the 3,787, **1,354 (35.8%) are already fixed** by `desktopColumnDefaults.ts` and only persist because the web
bundle predates it. **2,433 remain open, in 126 columns across 8 tables.**

Critically, the oracle only covers **2 of 61 transaction families** — `TR_PURC` (51 cases) and `TR_WH_SALE`
(15 cases). A perfect score would prove ~3% of the transaction surface.

**D2 — workflow.** Per-form write-table coverage averages **52.2%** across transaction forms. Exactly **1 of 61**
is fully covered (`TR_UPI_REC`); **2 are at zero** (`TR_SALE_RTN_UAE`, `TR_PR_SL_UAE`).

**D3 — form.** Grid column coverage averages **4.5%**, controls **25.3%**, validations **61.7%**. The UI field
audit covers **10 forms / 496 fields** of 204 forms.

**D4 — reports.** 45 desktop report forms. The release gate reports the comparison artefact as MISSING.

### B4. The trap in the existing numbers

`DEEP-COLUMN-AUDIT-SUMMARY.json` reports **98.9% overall column coverage**. That figure is a union across all
write paths — "does any code anywhere write this column" — and it is not a parity signal. The runtime oracle,
asking "did this voucher write the same value", reports 0 of 66. Where the two disagree, the runtime number is
the real one.

Concretely: `MAIN_STOCK` shows as written, yet karigar's `stockRows` wrote 19 of the 49 columns `Ac_Stock.cs`
writes, and `MAIN_STOCK` accounts for 658 open differences.

---

## Part C — Diagnosis

The open differences are not 2,433 independent bugs. Each of the 126 columns differs in **77 or 78 of the 78
relevant cases** — every single one. A column wrong in every case is a **builder that never writes it**.

Three systematic patterns explain nearly everything measured:

1. **Incomplete column sets.** A builder writes the columns its caller supplies; the desktop writes a complete
   row. 1,029 numeric differences plus most of the 894 empty ones.
2. **Missing denormalised copies.** The desktop carries `AC_DATA.LDR_NAME`, `SL_DATA.MOBILE`,
   `PR_DETL.DESIGN_NO` onto the transaction row and its reports read them back. Blank column, blank bill.
3. **Divergent constructed keys.** `ROJ_MEL_DATA.LEDR_KEY` differs mid-string, so daybook lines never join their
   ledger. 87 differences, highest severity per unit.

The eleven defects found this month by hand-replay are instances of patterns 1 and 3. Hand-replay finds them at
about one family per session with ~56 families left; the oracle enumerates them across all families in seconds.
**The bottleneck is not fixing — it is measuring.**

---

## Part D — Execution plan

### Phase 0 · Make parity measurable · blocks everything

> **Status 2026-08-30: PHASE 0 COMPLETE.** Evidence:
> `project-memory/parity/wp-09/PHASE-0-PARITY-MEASURABLE-EVIDENCE-2026-08-30.md`.
> `pnpm parity:measure` reproduces the numbers from a clean database in one command, is enforced in CI, and is a
> release gate (`parity-ratchet`, PASS). All 66 real desktop vouchers now replay through the real modules —
> 51 purchases via `createPurchase`, 15 wholesale rate-cuts via `postRateCut` — and re-measuring moved the
> ceiling from 3,787 to **3,662** field differences with 180 missing rows (was 210) and 734 MORE fields
> compared. Phase 1 is next.

Nothing after this is falsifiable without it, and today the loop is broken in three places.

**0.1 Repair the harness contract.** `G5-HARNESS.md` names `apps/api/integration/g5-compare.mjs` as "the single
CI entry point". **That file does not exist.** What exists is `parity-extract-mssql.mjs`,
`parity-extract-pg.mjs`, `parity-compare.mjs`. Either restore the entry point or rewrite the document to the
real three-step flow. A documented command that does not run is worse than none.

**0.2 Make the web bundle reproducible.** The extractor reads rows already in Postgres; the local database holds
**1** of the 66 vouchers. Build a replay that seeds master data (accounts, books, items, counters) and posts all
66 vouchers through the real HTTP API — not by direct insert, or the test proves nothing about the API. The 66
case definitions already exist in `desktop-latest.json`.

**0.3 One command, four numbers.** `pnpm parity:measure` outputs D1–D4 from a clean database and writes a dated
artefact.

**0.4 Ratchet in CI.** `fieldDifferences`, `rowsMissing`, `rowsExtra`, `tablesDesktopOnly`, `casesMatched` become
release gates that may only improve. Wire into the existing `release-certification.yml`.

_Exit:_ one command reproduces today's counts from scratch; CI fails when any count worsens. Expect the number to
fall from 3,787 immediately, because 1,354 differences are already fixed.

---

### Phase 1 · Extend the oracle to every family · the real coverage bottleneck

> **Status 2026-08-31: all retained families replayed.** Evidence:
> `project-memory/parity/wp-09/PHASE-1-FAMILY-COVERAGE-EVIDENCE-2026-08-31.md`.
> Nine retained desktop captures were merged by the new `parity-bundle-merge.mjs` into a 70-case bundle across
> **6 families** — the four beyond purchase and wholesale being retail sale, scheme, cash receipt and cash
> payment. All six now replay through their real modules, so the measured set is **70 cases / 6 families /
> 3,813 differences at 85.22% agreement**. Four families have only one case each, and everything beyond these six
> still needs a desktop capture.

66 cases cover 2 of 61 families. Everything else is unmeasured, including `TR_SALE` — the single most important
form in a jewellery shop.

**1.1 Case extraction per family.** Extend `parity-extract-mssql.mjs` usage to pull real vouchers for the
remaining 59 families. Target ≥5 cases per family spanning the branches that matter: cash and credit, tagged and
loose, with and without stones, tax and exempt, edited and deleted. **~300 cases.**

**1.2 Prioritise by severity × size.** Order from the depth audit:

| Order | Form             | Desktop LOC | write-tbl % | grid % | val % | Severity |
| ----- | ---------------- | ----------- | ----------- | ------ | ----- | -------- |
| 1     | `TR_SALE`        | 21,587      | 41.9        | 6.8    | 48.6  | critical |
| 2     | `TR_PURC`        | 17,256      | 50.0        | 0.0    | 82.9  | critical |
| 3     | `TR_SALE_RTN`    | 16,924      | 35.0        | 0.0    | 73.9  | critical |
| 4     | `TR_TAG_OPBL`    | 14,665      | 40.0        | 1.3    | 50.0  | critical |
| 5     | `TR_TAG_SPLIT`   | 12,941      | 11.1        | 0.0    | 0.0   | critical |
| 6     | `TR_WH_SALE`     | 18,008      | 73.7        | 0.0    | 66.7  | high     |
| 7     | `TR_SALE_HM`     | 15,354      | 56.5        | 0.0    | 68.0  | high     |
| 8     | `TR_TOUR_SALE`   | 14,057      | 35.3        | 0.0    | 53.8  | high     |
| 9     | `TR_SALE_ORD`    | 12,023      | 38.9        | 0.0    | 33.3  | high     |
| 10    | `TR_SALE_LBR`    | 12,300      | 35.0        | 0.0    | 31.6  | high     |
| 11    | `TR_INOUT`       | 11,726      | 26.7        | 0.0    | 0.0   | high     |
| 12    | `TR_TAG_WT_DIFF` | 10,469      | 13.3        | 0.0    | 0.0   | high     |
| 13    | `TR_PURC_HM`     | 10,636      | 50.0        | 0.0    | 90.0  | high     |
| 14    | `TR_SL_EBILL`    | 9,955       | 13.3        | 0.0    | 34.6  | high     |
| 15    | `TR_WH_SALE_RTN` | 9,600       | 46.2        | 10.0   | 100.0 | high     |
| 16    | `TR_FN_INOUT`    | 8,609       | 14.3        | 0.0    | 0.0   | high     |

`TR_SALE_RTN_UAE` (11,445) and `TR_PR_SL_UAE` (11,067) are at **0%** on every metric — decide explicitly whether
UAE variants are in scope before spending anything on them.

_Exit:_ every in-scope family has ≥5 real desktop cases in the bundle, and a measured D1 number.

---

### Phase 2 · Close database parity · 2,433 known + whatever Phase 1 reveals

> **Status 2026-08-31: increment 1 done.** Evidence:
> `project-memory/parity/wp-09/PHASE-2-COLUMN-COMPLETENESS-EVIDENCE-2026-08-31.md`.
> Purchase `MAIN_STOCK` closed: **635 → 21** differences, total **3,813 → 3,199** (−16.1%), agreement 85.22% →
> **87.60%**. Ten columns were absent from the builder; their values were derived from the desktop's own 77
> rows at 77/77 confidence. `PR_DETL` (1,195) and `PR_DATA` (853) are next.

**2.1 The 126 known columns.** Work in oracle-frequency order. For each table, pin the desktop's authoritative
column set from its actual writer, exactly as was done for `MAIN_STOCK` via `Ac_Stock.cs`:

| Table           | Open diffs | Columns | Desktop writer to read                  |
| --------------- | ---------- | ------- | --------------------------------------- |
| `PR_DETL`       | 713        | 23      | `TR_PURC.cs` detail save block          |
| `MAIN_STOCK`    | 658        | 14      | `Ac_Stock.cs` (49-column insert)        |
| `PR_DATA`       | 372        | 30      | `TR_PURC.cs` header save block          |
| `ROJ_MEL_DATA`  | 236        | 20      | rojmel writer + `LEDR_KEY` construction |
| `RATE_CUT_ISU`  | 220        | 26      | `TR_RATE_CUT*.cs`                       |
| `RATE_CUT_DATA` | 111        | 32      | `TR_RATE_CUT*.cs`                       |
| `AC_DATA`       | 101        | 6       | ledger poster                           |
| `TAX_DATA`      | 22         | 5       | tax poster                              |

**2.2 Enforce completeness structurally.** A per-table test asserting every builder emits the desktop's full
column set, so a new builder cannot reintroduce the gap. This is the ratchet that makes 2.1 permanent.

**2.3 Denormalised copies.** For each of the ~894 cases decide: copy at write time (desktop parity) or resolve by
join at read time. A join is defensible, but then the _report_ output must be proven identical — otherwise the
column is simply missing.

**2.4 Constructed keys.** Audit every key-shaped column against its desktop construction. `LEDR_KEY` first.

**2.5 Rows written and invented.** Six tables the web never writes (`MAIN_STOCK` in 15 cases, `TEMP_BOOK_DATA`
15, `PR_IDTL` 13, `DELETE_DATA` 7, `RATE_CUT_REC` 2, `RATE_CUT_ISU_REC` 1) and four it fabricates
(`BILL_OS_DATA` and `LOT_DETL` on 51 purchases each). `MAIN_STOCK` first: no stock movement is the worst
business error in the set. Fabricated `BILL_OS_DATA` is second: invented receivables.

Beyond the 8 oracle tables, the static audit names the widest per-table gaps to expect as Phase 1 widens
coverage: `ROJ_MEL_DATA` 41 missing columns, `REMARK_DATA` 39, `TEMP_BOOK_DATA` 33, `BAR_DETL` 31, `DM_DATA` 25,
`BAR_IDTL` 21, `MAIN_STOCK` 21, `TAX_DATA` 17, `BAR_DATA` 16, `SL_ORD_ADJ` 16.

_Exit:_ `fieldDifferences`, `rowsMissing`, `rowsExtra`, `tablesDesktopOnly` all 0 for every case in the bundle.

---

### Phase 3 · Workflow parity · generic, not per-family

Five of five families hand-examined yielded a money- or identity-losing defect. Assume the same rate across the
remaining ~56. Do not hand-write 56 bespoke tests.

**3.1 A generic round-trip harness.** For every voucher family, driven by a table of route triples:
create → reopen → save unchanged → assert **byte-identical** rows. This is the check that found the purchase
₹2,372.22 labour loss, the tag-opening 43-column wipe, and the karigar tag destruction. Generic, it finds all of
them at once.

**3.2 Edit and delete semantics.** Edit with changes → assert only intended columns moved. Delete → assert full
reversal and `DELETE_DATA` written as the desktop writes it. Re-post after delete → assert serial and identity
behaviour matches.

**3.3 Cross-form workflows**, which no single-form test can catch:
purchase → tag → sale; karigar issue → receive → sale; sale → return → stock restoration; rate-cut against
outstanding metal; tag split and weight-difference against `TAG_STOCK`.

**3.4 Concurrency.** WP-07 left 8 of 12 tag invariants unproven under concurrency. Two terminals selling the
same tag is a real Saturday-afternoon event in a jewellery shop.

_Exit:_ every family passes create/reopen/save-unchanged with zero column drift, plus edit, delete and re-post;
all 12 tag invariants enforced under concurrent load.

---

### Phase 4 · Form parity · the largest and least-covered dimension

Grid coverage is **4.5%** of 5,108 desktop grid columns. This is where a jewellery operator actually works: item,
tag, gross and net weight, touch, wastage, making charges, stone details, rate type.

**4.1 Extend the field audit** from 10 forms to all 61 transaction forms. It already captures 496 fields at 100%
capturability on the 10 it covers, so the method works — it needs applying.

**4.2 Grid columns per form.** For each form, enumerate the desktop grid columns from source and assert the web
grid presents the same set in the same order with the same editability. ~4,878 columns to reconcile.

**4.3 Calculations.** 2,933 desktop calc expressions in transaction forms. `CALC-AUDIT.json` already inventories
them; 184 golden-vector cells are blank. Each expression needs a vector proving the web computes the same value —
including negative and midpoint rounding, where 108 module-local helpers still disagree with the kernel.

**4.4 Validations.** 1,091 desktop validations at 61.7%: roughly 418 missing. 28 are recorded `NOT ENFORCED`.
Each needs a test asserting the same refusal for the same input.

**4.5 Keyboard and entry flow.** 418 keyboard handlers. F-key lookups, Enter-to-advance and grid navigation are
how experienced operators enter fifty lines a minute; a mouse-only form is unusable at counter speed even when
every value is correct.

_Exit:_ per form — field set, grid columns, calc vectors, validations and key handlers all proven against the
desktop, recorded in the completion register with evidence.

---

### Phase 5 · Report parity

45 desktop report forms. Reports are how the business sees itself: stock valuation, ledger balances, GST returns,
karigar accounts, daybook.

**5.1 Restore the comparison artefact** the release gate reports MISSING, using the existing
`report-compare.mjs` and `REPORT-BASELINES.json`.
**5.2 Per report**, same parameters against the same data → identical rows, totals and grouping.
**5.3 GST and statutory output** verified against the desktop's own filings; a wrong GSTR-1 is a legal problem,
not a bug. Note `GET /gst/gstr1?city=…` currently drops filters silently.

_Exit:_ every in-scope report matches, with statutory reports signed off against real filed returns.

---

### Phase 6 · The 53 absent menu entries

Deliberately last. 145 of 198 entries are present-but-unverified; shipping 53 more unverified screens grows the
unverified surface rather than the working one. Revisit once D1–D4 hold for the implemented families.

---

## Part E — Cross-cutting work that gates release

| Item                    | Baseline                                                       | Requirement                                        |
| ----------------------- | -------------------------------------------------------------- | -------------------------------------------------- |
| Contracts               | 8 drafts, **0 approved**; 28 `NOT ENFORCED`; 184 blank vectors | Approval is an owner act and cannot be self-signed |
| Rounding kernel         | **108** module-local helpers; negative midpoints disagree      | Migrate to the kernel; ratchet down                |
| Book/account resolution | 5 bypasses; 68 account literals in 15 files                    | Ratchet to 0                                       |
| Tag invariants          | 4 of 12 data-checked                                           | All 12, under concurrency                          |
| `TAG_STOCK` authority   | Unresolved: `TAG_STOCK` vs signed `MAIN_STOCK` sum             | Decide, then enforce everywhere                    |
| Release certification   | `passed=10 failed=3 skipped=1 missing=1`                       | Every gate PASS with fresh evidence                |

---

## Part F · Definition of done, per family

A family moves from `implemented-unverified` to `verified` only when all of these hold:

1. ≥5 real desktop cases in the parity bundle, **0 field differences, 0 row differences**
2. Create / reopen / save-unchanged is byte-identical; edit moves only intended columns; delete fully reverses
3. Field set, grid columns and order, and keyboard flow match the desktop form
4. Every calc expression has a passing golden vector, every desktop validation a passing refusal test
5. Every report reading the family's data matches
6. An approved contract exists, signed by the owner, with no blank or `NOT ENFORCED` cells
7. Evidence recorded and re-runnable by one command

Anything less stays `implemented-unverified`. On this definition **zero of 61 transaction families are done
today** — including the three worked on this month, which are closer but unmeasured.

---

## Part G · Sequencing and honest sizing

**Order:** Phase 0 → Phase 1 → Phase 2 → Phase 3 → Phase 4 → Phase 5 → Phase 6. Phases 2 and 3 can run in
parallel once measurement exists, because they touch the same builders from different angles. Phase 4 is the
long pole and can start per-form as soon as that form has oracle cases.

**Do Phase 0 alone first.** It is small, it is blocking, and it will immediately reclassify roughly a third of
the recorded gap as already fixed. Until then, every other claim of progress is unverifiable — which is exactly
how a month of real fixes went unmeasured.

**Sizing, stated plainly.** The remaining work is not a sprint. The measured scope is 61 transaction forms
averaging ~12,000 lines of desktop logic each, 5,108 grid columns at 4.5% coverage, 2,933 calc expressions,
1,091 validations, 45 reports, and 53 absent screens. Phases 0–2 are weeks and produce a provable database-parity
result for the covered families. Phases 3–5 are the bulk of the programme. Any schedule that promises the whole
of Part F quickly is not describing this codebase.

**What to protect.** The measurement loop, once built, is the asset. Every fix after Phase 0 should move a number
that CI watches; a fix that moves no measured number is indistinguishable from a fix that does nothing — and, as
this month showed, indistinguishable from one that was already done.
