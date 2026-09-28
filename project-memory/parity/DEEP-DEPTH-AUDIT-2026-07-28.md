# Deep depth audit — desktop vs web (2026-07-28)

**Question asked:** the parity matrix reports broad coverage, but the web *feels* like ~30% of the
desktop. Which is true?

**Answer: both, because they measure different things.** Breadth (does a form/route/page exist?) is
near-complete. *Depth* (does it persist and compute what the desktop persists and computes?) is
**60.7% at the persisted-column level and 17.2% (lower bound) at the grid-column level**.

> **Superseded figures.** This document first published 32.7%, then 42.4%. Phase A hardened the
> write-set parser through six fixes (see `PARITY-100-IMPLEMENTATION-PLAN.md`, Phase A) and the
> verified figure is now **60.7%** (eight parser/measurement fixes in total, the last being a stale
> `__pycache__` that made the sale family read ~42% when it was already complete). Each earlier number was an under-report caused by an unparsed
> write idiom, not a change in the code. The tables below are regenerated at the corrected numbers;
> where an older number appears it is labelled. `DEPTH-SCOREBOARD.md` is the live artifact.

Reproduce everything here with:

```bash
python3 project-memory/parity/deep_depth_audit.py     # form-level behaviour signals
python3 project-memory/parity/deep_column_audit.py    # column-level persistence depth
```

Outputs: `DEEP-DEPTH-AUDIT.json`, `DEEP-DEPTH-AUDIT-SUMMARY.json`, `DEEP-COLUMN-AUDIT.json`,
`DEEP-COLUMN-AUDIT-SUMMARY.json`.

---

## 1. Method, and its honest limits

Desktop truth comes from the extracted catalogs, not from reading code by hand:

| Source | What it gives |
|---|---|
| `catalogs/form-logic/<FORM>.logic.json` | `writes.INSERT/UPDATE[table] = [exact columns]`, select tables, F-keys, handlers, timers, serial-port use |
| `catalogs/form-behavior/<FORM>.behavior.json` | grid column inventory, calculation expressions, validations **with exact message text**, inline SQL |
| `catalogs/layouts/<FORM>.initcomp.json` | control inventory by kind (textbox/combo/check/grid) |
| `catalogs/realdb-schema-full.json` | the real desktop database (146 tables) used to discard non-physical columns |

Web truth is parsed from source: row objects resolved to their target table
(`insertRowTx(tx,'T',…,{…})`, `{ table:'T', rows:[header] }` with variable resolution,
`Object.assign(header,{…})`, raw `INSERT INTO "T"(…)`), plus the dynamic writers
(generic master CRUD builds columns from `generated-formfields.ts`; settings builds a dynamic
`UPDATE CO_SET` from its whitelist).

**Two analyzer bugs I found and fixed before trusting the output** — stated because they moved the
headline number materially:

1. `Object.assign(header, {…})` was invisible, so sales settlement columns looked unwritten.
2. Dynamic writers (masters, settings) were invisible, so `CO_SET` read 1.7% and `AC_MAST` 10.6%.

Fixing both moved overall column coverage from **32.7% → 42.4%**. The pre-fix number is what a
careless audit would have published.

**Residual limits, stated rather than hidden:**

- Desktop grid-column inventories include hidden state columns (`cOldGwt`, `cIsuNo`, `cHmId4Wt`…),
  so the 17.2% grid figure understates true user-visible parity. The persisted-column figures do not
  have this problem and are the metric to trust.
- The desktop catalogs are themselves extraction output; a few forms have visibly incomplete write
  sets (e.g. `TR_ITM_LOT` records only `TAG_PRINT_DATA`). Per-form numbers for those are unreliable;
  per-table numbers aggregate over all forms and are robust.
- "Validation count" comparisons are indicative only: one desktop `MsgBox` guard does not map 1:1 to
  one web `throw`.

---

## 2. Headline measurements

| Layer | Desktop | Web | Coverage |
|---|---:|---:|---:|
| **Persisted columns** (all tables) | 3,669 | 2,227 | **60.7%** |
| Tables the desktop writes | 122 | 89 written at all | **33 never written** (confirmed by two independent methods) |
| Avg coverage *of tables the web does write* | — | — | 73.1% |
| **Grid columns** (57 txn forms) | 6,000+ named | ~1,050 rendered | **17.2%** |
| Header input fields (61 txn forms) | 1,340 | ~1,410 | ~100% (median 100%) |
| Desktop calculation expressions | 3,309 | — | not individually traced |
| Desktop validations (with message text) | 1,849 | — | ~62% by crude count ratio |
| Desktop inline SQL statements | 5,128 | — | not individually traced |
| Desktop event handlers | 377 | — | not individually traced |

**Interpretation.** The web reproduces the *shape* of the desktop (forms, header fields, navigation,
routes) far better than it reproduces the *substance* (every column a voucher carries, every grid
column a user types into, every branch a calculation takes). That is precisely why a breadth-based
matrix reads ~90% while a user's experience reads ~30%. Depth is now gated (Phase A), so this
cannot drift again: `depth` is a published gate on all 720 units with a no-regression ratchet.

---

## 3. Where the depth is missing

### 3.1 Vouchers persist a fraction of their columns

| Table | Desktop cols | Web cols | Coverage | Examples of what is dropped |
|---|---:|---:|---:|---|
| `SL_DATA` (sale header) | 97 | 97 | **100%** | `ACK_NO`/`ACK_DATE`/`IRN_NO` (e-invoice), `CARD_ADJ`, `CARD_COM_AMT`, `ADV_AMT`, `DISC_PRC`, `BANK_NAME`, address `ADD1-3`/`CITY` |
| `SL_DETL` (sale line) | 103 | 103 | **100%** | `GHT_AMT`, `ITM_GHT_PRC`, `IT_DISC_AMT`, `DISC_PRC`, `EMP_CODE`, `KR_WEST_PRC` |
| `BAR_DETL` (tag) | 107 | 55 | 51% | `MAIN_MRP`, `KR_COST`, `DESIGN_IMG_ID` |
| `MFG_DETL` | 74 | 51 | 69% | 23 columns |
| `SL_ORD_DETL` | 77 | 26 | 34% | 51 columns |
| `APR_DETL` | 76 | 27 | 36% | 49 columns |
| `SL_ORD_DATA` | 55 | 18 | 33% | 37 columns |
| `DHRN_REC_DATA` | 56 | 22 | 39% | 34 columns |
| `MAIN_STOCK` | 48 | 48 | **100%** | — |
| `TAX_DATA` | 22 | 17 | 77% | key columns only |

`MAIN_STOCK` at 100% is the proof that this is achievable — the stock engine was built to the
desktop's full write set. Most other engines were built to a "good enough" subset.

**Why it matters concretely:** a dropped column is not cosmetic. It breaks (a) reprinting a saved
voucher, (b) reopening a voucher for edit with all values intact, (c) any Crystal report bound to
that column, and (d) downstream registers. This is the mechanical cause of "it works but the bill
isn't the same".

### 3.2 Thirty-three desktop-written tables are never written

The analyzer initially flagged 48. I checked each one against the web sources: **15 are written**
through idioms the parser missed (`AC_DATA`, `CASH_DATA`, `CONTRA_DATA`, `KR_DATA`, `KR_DETL`,
`MFG_DATA`, `MFG_IDTL`, `AD_DATA`, `AD_ADJ`, `AD_OS`, `BAL_GR`, `POINT_DATA`, …). **33 are genuinely
absent.** Largest by desktop column count:

| Table | Desktop columns | What is lost |
|---|---:|---|
| `CO_SET_NEW` | 69 | second company-settings surface (only rounding flags are read today) |
| `TAG_PRINT_DATA` | 60 | tag/label print queue |
| `APR_IDTL` | 46 | approval sub-detail |
| `KR_IDTL` | 45 | karigar sub-detail |
| `PR_IDTL` | 45 | purchase stone/diamond sub-detail |
| `TAG_STOCK_PRINT` | 45 | tag stock print snapshot |
| `BAR_CAN_IDTL` | 43 | tag-cancel sub-detail |
| `DHRN_REC_DETL` | 40 | pledge receipt detail |
| `DESIGN_DETL` | 34 | design detail |

The pattern is consistent: **`*_IDTL` sub-detail tables** (stones, diamonds, components) and
**print-queue tables** are the systematic omission — the web keeps header+detail but drops the third
level and the print snapshots.

### 3.3 Grids are the biggest visible gap

| Form | Desktop grid columns | Web rendered | Coverage |
|---|---:|---:|---:|
| `TR_TAG_SPLIT` | 237 | 12 | 5% |
| `TR_PURC` | 228 | 32 | 14% |
| `TR_SALE` | 190 | 30 | 16% |
| `TR_WH_SALE` | 184 | 11 | 6% |
| `TR_SALE_RTN` | 176 | 16 | 9% |
| `TR_TAG_OPBL` | 153 | 16 | 11% |

Even discounting hidden state columns, an operator who types 25–40 values per line on the desktop
gets 10–15 on the web. This is the single most likely source of "the web is 30%" as a *felt*
experience, and it compounds with §3.1: a column with no grid cell can never be captured.

### 3.4 Configuration and masters: column reach is high, behavioural fidelity is not

My first pass reported these as very thin. That was an analyzer artifact — masters and settings write
**dynamically** (generic CRUD builds the column list from `generated-formfields.ts`; settings builds a
dynamic `UPDATE CO_SET` from its whitelist). Measured correctly:

| Table | Desktop cols | Web cols | Coverage |
|---|---:|---:|---:|
| `CO_SET` | 58 | 56 | 96.6% |
| `CO_MAST` | 37 | 36 | 97.3% |
| `AC_MAST` | 47 | 45 | 95.7% |
| `ITEM_MAST` | 34 | 32 | 94.1% |

So the **fields exist**. What is not proven is desktop behaviour *around* those fields: per-field
validation with the desktop's exact messages, dependent defaults, group-driven side effects, and the
master-form workflows (`MS_UPDATE` alone carries 183 write columns and its own recalculation pass).
`CO_SET_NEW` (69 columns) remains genuinely unwritten apart from the rounding flags.

Treat masters as **breadth-complete, depth-unverified** — not as a remaining data gap.

---

## 4. What is genuinely strong

This audit is not a claim that little works. Objectively verified elsewhere in this repo:

- 10 migrations, zero drift, RLS **170/170** forced with write checks; restricted-role tests.
- 524 automated tests including restricted-role database lifecycle suites per voucher family.
- `MAIN_STOCK` at 100% column coverage; signed stock identity and tag single-consumption proven.
- Desktop-exact voucher identity (dual numbering, preserved `MAIN_USER`/`VCH_TIME`, audit shapes).
- Per-workflow fine policies and configured monetary rounding, desktop-cited.
- 254 report specs with real Crystal geometry and a proven data contract.

The gap is **depth of field-level fidelity**, not absence of an application.

---

## 5. Root causes (why depth lagged breadth)

1. **The scoreboard rewarded breadth.** Gates asked "does a surface exist and is it tested?", never
   "does it persist all N columns?". A 20-of-97-column voucher scored the same as a complete one.
2. **Engines were written from behaviour summaries, not from the write set.** Where the write set was
   used as the spec (`MAIN_STOCK`, melting, physical stock, repair), depth is high.
3. **Shared generic engines** (masters CRUD, one sale engine for many books) traded fidelity for
   reach.
4. **Grids were built for keyboard behaviour first** — the shared grid contract is excellent, but the
   column inventory per form was never driven from the desktop grid catalog.

---

## 6. Remediation plan, ordered by measured impact

Each step is measurable by re-running the two analyzers; the target is a number, not an opinion.

| # | Work | Measured target |
|---|---|---|
| 1 | **Make depth a gate.** Add column-coverage to the parity generator per form/table and fail below a floor; publish it beside the existing gates. | depth visible in the matrix |
| 2 | **Complete the write sets of the critical voucher families** (`SL_DATA`/`SL_DETL`, `PR_DATA`/`PR_DETL`, `BAR_DETL`, `SL_ORD_*`, `MFG_DETL`, `DHRN_*`), driven column-by-column from `form-logic` | ≥90% per table, as `MAIN_STOCK` already is |
| 3 | **Add the missing third-level and print tables** (`*_IDTL` sub-details: `PR_IDTL`, `KR_IDTL`, `APR_IDTL`, `BAR_CAN_IDTL`; plus `TAG_PRINT_DATA`, `TAG_STOCK_PRINT`, `DHRN_REC_DETL`, `CO_SET_NEW`) and the per-form satellites (`ROJ_MEL_DATA`, `REMARK_DATA`, `DM_DATA`, `TAG_IMAGE_DATA`, `USER_DATA`, `LOT_DETL`) | 33 → 0 never-written tables |
| 4 | **Rebuild the grids from the desktop grid catalog** for the 12 highest-column forms, including hidden/derived columns needed by §2 | grid coverage 17% → ≥70% of *data-bearing* columns |
| 5 | **Prove master behaviour** (not fields): per-field validation with desktop message text, dependent defaults and side effects for `MS_ACCT`, `MS_ITEM`, `MS_COMPANY`, `MS_YEAR`, `MS_UPDATE` | each master validation traced to a test or waiver |
| 6 | **Trace calculations and validations explicitly**: per form, map each desktop `calc`/`validation` entry to a web implementation or an explicit waiver, with the exact desktop message text | 3,309 calcs and 1,849 validations accounted for |
| 7 | Re-run G5 per form once §2–§4 land — column parity is a precondition for a zero-diff desktop comparison | G5 becomes achievable |

Sequencing note: steps 2 and 4 are the same work seen from the database and the screen; do them per
family together, and finish a family before starting the next.

---

## 7. Bottom line

- Breadth: **near-complete** — every desktop form is implemented or formally waived, 362 routes
  classified, 254 reports with real geometry; masters/config field reach is 94–97%.
- Depth: **60.7% of persisted columns, ≥17.2% of grid columns** — so a migrating shop would find the
  application recognisable and structurally correct, but would hit missing fields on the busiest
  screens and on reprints.
- Your ~30% assessment was a fair description of felt functional depth, and closer to the truth than
  the breadth-based matrix. The verified figure at the layer that matters most (what actually gets
  stored) is **60.7%**, reached only after six parser fixes; `PARITY-100-IMPLEMENTATION-PLAN.md`
  closes the remaining 1,442 columns, 33 tables and the grid gap.
