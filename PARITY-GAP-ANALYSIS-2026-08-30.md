# End-to-end parity gap — measured analysis, 2026-08-30

This replaces estimation with measurement. Every number came from running the project's own comparison harness
against retained **real desktop data** (66 vouchers from the live company database), not from reading code and
judging.

## 0. The caveat, and why it cuts both ways

The comparison needs two bundles. The desktop side is real and retained
(`project-memory/parity/bundles/desktop-latest.json`, 66 vouchers, captured 2026-08-02). The web side available
here was captured **2026-08-02**, and the extractor reads rows already in Postgres rather than re-posting them —
so it reflects vouchers posted at some earlier point.

That means the raw totals **overstate** today's gap. Verified below: 1,354 of the 3,787 differences (35.8%) are
already addressed by code that landed on 2026-08-02, and would vanish on a re-post.

It also means nobody can currently tell which. The gap cannot be refreshed cheaply: the local database holds
**1** of the 66 vouchers (`PR_DATA`, tenant `parity-purchase`). Refreshing means replaying 66 real vouchers with
their master data.

**Working blind in both directions is the central problem.** Real fixes go unmeasured, and real regressions
would too.

## 1. Surface inventory

|                   | Desktop                    | Web                           |
| ----------------- | -------------------------- | ----------------------------- |
| Forms / modules   | 199 C# forms (+59 VB)      | 188 API module files          |
| Transaction forms | 60 (`TR_*`)                | 404 registered HTTP endpoints |
| Reports           | 44 (`RP_*`)                | —                             |
| Masters           | 33 (`MS_*`)                | —                             |
| UI surfaces       | 199 forms                  | 101 Next.js pages             |
| Source size       | 991,061 lines (decompiled) | 77,954 lines                  |
| Tests             | —                          | 156 files, 1,314 tests        |

Decompiled C# is far more verbose than TypeScript, so the size ratio is not a completeness ratio.

## 2. Coverage: what exists

From `web/docs/COMPLETION-REGISTER.json`, 198 desktop menu entries: **145 implemented-unverified, 53 absent,
0 verified.** Presence ≈ 73%; proven parity is zero by the project's own register.

## 3. Parity: what matches

`parity-compare.mjs desktop-latest.json web-latest.json`, 66 real vouchers:

```
cases 66 · casesMatched 0
fieldsCompared 23,574 · fieldDifferences 3,787 · fieldsExcluded 1,625
rowsMissing 210 · rowsExtra 210
tablesCompared 368 · tablesDesktopOnly 53 · tablesWebOnly 105
```

Concentration: purchase 51 cases / 3,095 differences; wholesale sale 15 cases / 692.

### 3.1 Rows the web never wrote

| Table              | Cases with desktop rows and zero web rows |
| ------------------ | ----------------------------------------- |
| `MAIN_STOCK`       | **15**                                    |
| `TEMP_BOOK_DATA`   | 15                                        |
| `PR_IDTL`          | 13                                        |
| `DELETE_DATA`      | 7                                         |
| `RATE_CUT_REC`     | 2                                         |
| `RATE_CUT_ISU_REC` | 1                                         |

`MAIN_STOCK` missing in 15 of 66 vouchers means the web **moved no stock at all** for those vouchers. For a
jewellery business that is wrong inventory, not a cosmetic difference.

### 3.2 Rows the web invented

`BILL_OS_DATA` on **51** purchases, `LOT_DETL` on **51**, `TAX_DATA` on 2, `MAIN_STOCK` on 1. Fabricated
outstanding-bill rows corrupt receivables in the opposite direction: balances that do not exist.

## 4. Why the fields differ — and how much is already fixed

All 3,787 differences were re-classified against the committed
`apps/api/src/modules/posting/desktopColumnDefaults.ts`, asking of each: _would today's code already produce the
desktop value?_

|                                                                          | Count     | Share     |
| ------------------------------------------------------------------------ | --------- | --------- |
| ~~Already addressed (bundle predates the fix)~~ **see correction below** | ~~1,354~~ | ~~35.8%~~ |
| **Still genuinely open**                                                 | **2,433** | 64.2%     |

> **CORRECTION 2026-08-30, after measuring.** The 35.8% figure above was an inference from timestamps, and it
> was wrong. The 51 purchase cases have since been replayed through the real module and re-extracted: on
> identical cases the improvement is **159 differences, about 5%** (3,095 → 2,936), not 36%. The August bundle
> evidently already carried `desktopColumnDefaults.ts`. Evidence:
> `project-memory/parity/wp-09/PHASE-0-PARITY-MEASURABLE-EVIDENCE-2026-08-30.md`.

### What was already solved, and solved well

The desktop writes complete rows — unused numeric columns get `0`, character columns `''` — while the web wrote
only supplied columns, leaving the rest `NULL`. That single difference once accounted for **5,239 of 8,080**
field differences, per `derive-column-defaults.mjs`.

It was fixed the right way. A type rule was tried and _measured to over-reach_: defaulting every numeric to `0`
and every character to `''` removed 3,057 differences but introduced 828 new ones across 17 columns the desktop
genuinely leaves NULL. So the spec is **derived by counting NULLs per column over every row of the real
database** — 49 tables, 1,894 columns defaulted, 249 deliberately left NULL, 1,408 with no evidence to judge
from — and applied in `insertRowTx`, through which `postVoucherTx` routes every voucher and ledger row.

Of the 1,479 "both blank, different spelling" differences, **1,325 are already covered**. The residue is two
columns: `MAIN_STOCK.EMP_CODE` (77) and `MAIN_STOCK.ITM_SIZE` (77).

This matters for planning: the largest single component of the gap has already been closed, and the raw totals
hide it. Recommending "adopt a blank-value convention" would be recommending work that is done.

### What is still open

**2,433 differences across 126 columns in 8 tables:**

| Table           | Open differences | Distinct columns |
| --------------- | ---------------- | ---------------- |
| `PR_DETL`       | 713              | 23               |
| `MAIN_STOCK`    | 658              | 14               |
| `PR_DATA`       | 372              | 30               |
| `ROJ_MEL_DATA`  | 236              | 20               |
| `RATE_CUT_ISU`  | 220              | 26               |
| `RATE_CUT_DATA` | 111              | 32               |
| `AC_DATA`       | 101              | 6                |
| `TAX_DATA`      | 22               | 5                |

The per-column counts give the diagnosis. These columns differ in **77 or 78 of the 78 relevant cases** — every
single one:

```
PR_DETL.TAG_NO 78   PR_DETL.RATE_TYPE 78   PR_DETL.WITH_STOCK 78   PR_DETL.IT_DESC 78
PR_DETL.PR_CODE 78  PR_DETL.DESIGN_IMG_ID 78  PR_DETL.APR_ISU 78   PR_DETL.EMP_ISU 78
MAIN_STOCK.ISR_NO 77  MAIN_STOCK.KR_NWT 77   MAIN_STOCK.KR_FINE 77  MAIN_STOCK.STK_DATE 77
```

A column wrong in _every_ case is not a business-logic bug. It is a **builder that never writes that column**.
This is precisely the defect WP-08d found by hand: karigar's `stockRows` wrote 19 of the 49 columns
`Ac_Stock.cs` writes. The oracle shows the same shape in `PR_DETL`, `PR_DATA`, `RATE_CUT_*` and `ROJ_MEL_DATA`.

Two classes are different in kind and need separate treatment:

- **894 "web wrote nothing, desktop had a value"** — denormalised copies the desktop carries onto transaction
  rows: `AC_DATA.LDR_NAME` (`RUPALBEN DODIYA`), `SL_DATA.MOBILE`, `PR_DETL.DESIGN_NO`. Printed bills and reports
  read these columns, so blank means blank output.
- **87 real text mismatches**, mostly `ROJ_MEL_DATA.LEDR_KEY` — a _constructed_ key differing mid-string
  (`01002024-20250350000214` vs `...0000201`). A key built differently does not join, so daybook lines silently
  fail to associate with their ledger. Highest severity per unit in the whole set.

## 5. The gap is bounded

126 open columns across 8 tables, plus 6 unwritten and 4 fabricated tables. Ordered by oracle frequency, the top
50 columns cover roughly three quarters of the differences. This is a finite, enumerable work item, not an
open-ended defect swamp.

## 6. What this says about the work done so far

Eleven defects are recorded in the plan's §17.3, each found by replaying one voucher family by hand, and each
real: purchase lost ₹2,372.22 of labour; a karigar edit destroyed the tag record, leaving the ornament
unsellable; tag opening wiped 43 of 109 columns; karigar issue never recorded the tag it sent out. Five of five
families examined yielded a money- or identity-losing defect.

The oracle reframes that effort rather than diminishing it. Those eleven are **instances of two systematic
patterns** — incomplete column sets and divergent key construction — which the oracle enumerates across every
family in about forty seconds, and which hand-replay finds at roughly one family per session with ~57 families
left.

The strategic error is not the fixes. It is that the oracle has not been run for a month, so the month's work is
unmeasured, and 36% of the recorded gap turns out to be already closed without anyone knowing.

## 7. Governance state

| Gate                  | State                                                                                                                    |
| --------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| Contracts             | 8 drafts, **0 approved**; 28 validations `NOT ENFORCED`; 184 blank golden-vector cells                                   |
| Compatibility kernel  | 108 module-local rounding helpers, 5 book-account bypasses                                                               |
| Tag invariants        | 4 of 12 data-checked (2 of the 4 checked the wrong rows until 2026-08-30)                                                |
| Release certification | `passed=10 failed=3 skipped=1 missing=1` → **NOT CERTIFIED**                                                             |
| G5 desktop comparison | FAILED — no current `latest.json`                                                                                        |
| Report comparison     | MISSING artefact                                                                                                         |
| Documented harness    | `G5-HARNESS.md` names `apps/api/integration/g5-compare.mjs` as "the single CI entry point"; **that file does not exist** |

## 8. Plan — next implementations, in dependency order

> The detailed, execution-ready version of this section is `DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md`,
> which adds the workflow, form and report dimensions this document does not measure, plus the per-form
> priority order. What follows is the summary.

### WP-09 · Restore the parity oracle loop · prerequisite for everything

Without it every claim below is unfalsifiable, and 36% of the measured gap is already stale.

1. Reconcile `G5-HARNESS.md` with reality — the documented entry point is missing; what exists is
   `parity-extract-mssql.mjs`, `parity-extract-pg.mjs`, `parity-compare.mjs`.
2. Make the web bundle reproducible: seed master data, post the 66 vouchers through the real API, extract with
   `parity-extract-pg.mjs`. The 66 case definitions are already in `desktop-latest.json`.
3. Wire `parity-compare.mjs` into release certification with `fieldDifferences`, `rowsMissing`, `rowsExtra` and
   `tablesDesktopOnly` as ratchets that may only shrink.

Exit: one command reproduces today's counts from a clean database, and CI fails when any count grows.

### WP-10 · Column completeness per writer · the 2,433 open differences

Not a new convention — the convention layer exists and works. This is the _builders_.

For each of the 8 tables, pin the desktop's authoritative column set from its writer (as WP-08d did with
`Ac_Stock.cs` for `MAIN_STOCK`'s 49 columns) and add a test that fails when a builder omits one. Work the 126
columns in oracle-frequency order.

Start with `MAIN_STOCK` (658 differences, 14 columns) because it is shared by every family, then `PR_DETL` (713)
and `PR_DATA` (372).

Exit: every builder writes the desktop's full column set for the 8 tables, ratcheted; the residual
`MAIN_STOCK.EMP_CODE` / `ITM_SIZE` blanks resolved.

### WP-11 · Denormalised copies · 894 differences

`AC_DATA.LDR_NAME`, `SL_DATA.MOBILE`, `PR_DETL.DESIGN_NO` and similar: values the desktop copies onto the
transaction row and its reports read back. Decide per column whether the web copies at write time (desktop
parity) or resolves by join at read time (normalised), and record the decision — a join-time answer is defensible
but must then be proven to produce identical report output.

### WP-12 · Rows written and rows invented

Six tables never written (`MAIN_STOCK` 15 cases, `TEMP_BOOK_DATA` 15, `PR_IDTL` 13, `DELETE_DATA` 7,
`RATE_CUT_REC` 2, `RATE_CUT_ISU_REC` 1) and four fabricated (`BILL_OS_DATA` and `LOT_DETL` on 51 purchases
each). `MAIN_STOCK` first: no stock movement is the most serious business error measured.

Exit: `rowsMissing` and `rowsExtra` both 0 across the 66 cases.

### WP-13 · Constructed keys · 87 differences, highest severity per unit

`ROJ_MEL_DATA.LEDR_KEY` is built differently and therefore does not join. Audit every constructed key against its
desktop construction.

Exit: zero differences in any column used as a join key.

### WP-14 · Rate cutting

`RATE_CUT_DATA` (32 divergent columns), `RATE_CUT_ISU` (26), plus two unwritten sub-ledgers. Fixing a metal rate
against outstanding balances is core jewellery trade and is the least correct family measured.

### WP-15 · The 53 absent menu entries

Last. Shipping 53 more unverified screens grows the unverified surface rather than the working one.

## 9. Sequencing

WP-09 alone first — without measurement the rest is unfalsifiable, and it will also reveal how much of the
recorded gap is already closed. Then WP-10, the bulk of the remaining field gap. Then WP-11 through WP-13, which
are correctness rather than count. WP-14 and WP-15 are feature work and belong after the platform can prove that
a single voucher matches the desktop.

No family's register entries should move from `implemented-unverified` to `verified` until that family's cases
match in the oracle.
