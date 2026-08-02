# Migration completion plan — desktop DataCareNext → web

**Purpose.** The work that must be finished, and proven finished, before this web application can replace the
desktop application for a real business. Every item states its evidence source, its implementation, its tests,
its verification and its exit criterion.

**Ground rule carried from the whole project:** the desktop source and the real customer data are the only
authorities. Nothing here permits inventing a value, formula, message or direction. Where the desktop is
ambiguous, the plan says _measure first_ rather than _choose_.

**Status of this document:** written 2026-08-01 against measured counts. Every number below is reproducible by
the command beside it.

---

## 0. Where the project actually stands

The distinction that governs the whole plan:

|                                  | Measure                                   | Value                 |
| -------------------------------- | ----------------------------------------- | --------------------- |
| **Built**                        | web pages · routes · report slugs · tests | 101 · 383 · 48 · 1062 |
| **Verified against the desktop** | vouchers ever compared field-by-field     | **1**                 |

```bash
# desktop scale
ls unified/src/csharp/DataCareNext/*.cs | wc -l          # 204 forms
cat unified/src/csharp/DataCareNext/*.cs | wc -l          # 969,133 lines
# forms never referenced anywhere in web source
# (script in §2.1) -> 72 forms, 158,685 lines
```

That single compared voucher produced 4 blockers, 1 primary-key defect, ~10 open behavioural differences and
2 defects in the comparison tool. **The discovery rate on the first sample is the strongest available evidence
that the remaining surface is not a formality.**

### Correction to this plan's own baseline (2026-08-01)

The plan was written against a count of desktop `.cs` files. **That is the wrong denominator** and is now
superseded, though both numbers are kept because they answer different questions.

| Measure                          | Value                        | Answers                         |
| -------------------------------- | ---------------------------- | ------------------------------- |
| Desktop form files               | 204 forms, 969,133 lines     | how much code exists            |
| **`NextMain.MENU_DATA` entries** | **198 named items, 13 tabs** | **what a user can actually do** |

`MENU_DATA` is the desktop's real menu, with a per-item visibility flag. It is the authoritative surface for a
migration that must reproduce _functionality, features and workflows_, because several form files back many
menu entries (`RP_ALL` backs a dozen reports; `TR_MEMB_ADJ` backs both `Gold Adjust` and `Memb Adjust`) and
several are infrastructure no user ever reaches.

Chained through the `MDI_FORM.cs` dispatch: **186 of 198 resolve to a form, 152 of those are referenced
somewhere in web source, 34 never are, 12 labels the dispatch extraction could not resolve.**

**Two measurement attempts failed first and are recorded so they are not repeated:**

1. Matching menu labels against the web form catalog **by name** reported 165 of 198 missing — including
   `Sales`, `Purchase`, `Rojmel` and `Rate Cut`, which the web demonstrably has. The desktop uses terse labels
   (`Amt In`, `Kr Issue`), the web expanded ones (`Accounts`, `Books / Series`). The match measured the naming
   conventions, not the coverage.
2. Grepping each feature's tables reported a hit for almost everything, because an incidental mention of
   `LBR_TYPE` is indistinguishable from an implementation of the Labour Type master.

So `formReferencedInWeb` in the register is a **weak positive and a strong negative**. It orders the work. A
human classifies each item with evidence, and `pnpm register:check` enforces that the classification is
honest.

### A second business is available, and was here all along

Five SQL Server databases exist in `imodule-extracted`, three already attached:

| Database     | Business         | Contents                                                                |
| ------------ | ---------------- | ----------------------------------------------------------------------- |
| `Live24`     | DHAKAN JEWELLERS | 5150 ledger rows, 190 sales, 3179 Rojmel, 918 accounts                  |
| **`Next25`** | **NJ GOLD**      | **two companies (01, 02)**, 569 accounts, years **2024-25 and 2025-26** |
| `Next23`     | DEMO COMPANY     | 28 ledger rows, 4 sales, 99 accounts — a demo, not a customer           |
| `Next24`     | —                | seed, no vouchers                                                       |
| `NextMain`   | —                | configuration registry, and the source of `MENU_DATA`                   |

**This partly answers the standing caveat.** `Next25` has a different chart of accounts, a second company, and
a fiscal year `Live24` lacks — so multi-company handling, a second year, and the live/dead classifications can
all be tested against something other than one sample. It has few transactions, so it tests **masters and
configuration**, not voucher behaviour. §6.3 (wholesale build-or-exclude) can now be informed rather than
guessed.

### The eight things that make "not done" true

| #   | Gap                                              | Measured                                    |
| --- | ------------------------------------------------ | ------------------------------------------- |
| 1   | Voucher behaviour unverified                     | 1 of 22 families compared; `g5:parity` RED  |
| 2   | Desktop forms with no web reference              | **72 forms / 158,685 lines**                |
| 3   | Crystal report output never compared             | 0 comparisons; 254 baselines are web-vs-web |
| 4   | Column types wrong                               | **226** numeric→text, one-way               |
| 5   | Behaviour settings unproven                      | **37 of 39** have no matrix                 |
| 6   | Wholesale sale form absent                       | `TR_WH_SALE` 18,007 lines                   |
| 7   | Hardware / external integrations never exercised | scales, printers, e-invoice, WhatsApp       |
| 8   | Single-sample bias                               | one company, one fiscal year                |

---

## Phase 0 — Trust the instruments (blocks everything else)

**PHASE 0 COMPLETE at 2026-08-01: 7 of 7 items done, each with a control demonstrated failing.**

| Item                                    | State                 | Evidence                                                                                      |
| --------------------------------------- | --------------------- | --------------------------------------------------------------------------------------------- |
| 0.1 differ pairing + forced-pair signal | **done**              | `bundleDiffPairing.test.ts`; fields compared 271 → 540 → 672                                  |
| 0.2 `footprintOf` fails loudly          | **done**              | `footprintLoud.db.test.ts`, 4 tests                                                           |
| 0.3 replay harness seeds completely     | **done for rounding** | `PARITY_STRICT=1` throws on any unset flag; `parityStrictSettings.test.ts`                    |
| 0.4 type parity closure                 | **done**              | 226 → **0**; migration `20260801120000_column_type_parity`; `pnpm type:parity` baseline empty |
| 0.5 typecheck the tests                 | **done**              | `pnpm typecheck:tests` exit 0, was 114 errors; 5 real test defects found                      |
| 0.6 doc reference checker               | **done**              | `pnpm docs:refs` — 131 citations, 11 with line numbers, 3 controls                            |
| 0.7 completion register                 | **done**              | `pnpm register:check`, 198 items                                                              |

**0.1 and 0.7 each found something the moment they existed** — 0.1 exposed that `ROJ_MEL_DATA` had never been
compared field-by-field at all, and 0.7 replaced this plan's own denominator. That is the argument for doing
Phase 0 before anything else, restated as evidence rather than assertion.

Nothing downstream is believable until the measuring tools are sound. This phase is short and must come first.

### 0.1 The differ must compare everything it claims to

**Evidence it did not:** row keys were built with each side's own numeric scale, so `SR_NO=1` never matched
`SR_NO=1.000000`. `AC_DATA` and `SL_DETL` fell through as "missing + extra" and were never diffed. Fixing it
moved fields compared from **271 to 540**.

**Done:** `apps/api/src/modules/parity/bundleDiff.ts` — `rowKeyOf` takes the counterpart column index.
Regression test `apps/api/test/bundleDiffPairing.test.ts` (3 tests), control proven.

**Remaining work in this area:**

| Item                                    | Implementation                                                                      | Test                                                                                   | Exit criterion                                                       |
| --------------------------------------- | ----------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------- | -------------------------------------------------------------------- |
| Single-row shortcut hides key defects   | `diffBundles` pairs a lone row positionally; make it still _build_ and compare keys | extend `bundleDiffPairing.test.ts` with a 1-row case whose keys differ                 | a 1-row table with mismatched keys reports a difference, not a match |
| `ROW_KEYS` has no entry for most tables | audit all ~50 tables a voucher can write; add keys                                  | assert every table in any `WRITE_TABLES` has a `ROW_KEYS` entry or a documented reason | test enumerates write-set tables and fails on an unkeyed one         |
| Excluded columns are invisible          | 32 columns excluded per case with no report of _which_                              | print and snapshot the exclusion list                                                  | exclusions are a reviewed list, not a silent filter                  |

### 0.2 The extractors must fail loudly

**Evidence:** `parity-extract-pg.mjs` read as the RLS-bound role without setting `app.tenant_id` and reported
`voucher wrote no rows` for a voucher that was present. Fixed.

**Remaining:** `test/support/footprint.ts:63` still has `.catch(() => [{ n: 0 }])`, turning a blocked read into
a count of zero. Replace with an explicit failure; keep the tenant-scoped call pattern.

**Exit criterion:** every parity/footprint helper either returns data or throws — no path returns "empty"
on error. Proven by a control that revokes a grant and shows a thrown error.

### 0.3 The replay harness must seed completely

**Evidence:** the harness seeded `CO_SET` but not `CO_SET_NEW`, so `TOT_AMT_ROF` was absent and the loader kept
its 2dp default. This manufactured **two false defect reports** (whole-rupee rounding, GST-half rounding) that
reached a commit message before being retracted.

**Implementation:** `apps/api/integration/parity-replay-sale.mjs` seeds masters from the real database's own
values. Generalise it:

```
replaySeed(tenant, { fromDatabase: 'Live24', coCode, lcCode, book, vchNo })
  -> reads CO_SET, CO_SET_NEW, YEAR_MAST, TAX_MAST, AC_MAST, GROUP_MAST,
          ITEM_MAST, BOOK_DATA, BOOK_DETL for exactly the rows the voucher touches
  -> substitutes placeholder NAMES only (never codes, never numbers)
```

**Test:** a completeness gate in the spirit of `seedCompleteness.db.test.ts` — for a given voucher, assert every
master row the posting path reads is present, by asserting **zero** `*NotConfigured` errors across a replay of
N vouchers.

**Exit criterion:** a replay that is missing a setting **fails** rather than silently using a default. Add a
strict mode: `resolveRoundingPolicy` etc. throw when a flag row is absent, enabled under `PARITY_STRICT=1`.

_This is the single most important item in Phase 0._ A harness that under-seeds does not produce weak
evidence — it produces confident false evidence.

### 0.4 Type parity must be closed, not just gated

**Done:** `pnpm type:parity`, 226 baselined, control proven.

**Remaining:** the 226 are a real defect with runtime consequences (`SUM` needs casts that can throw;
`ORDER BY` sorts `'9'` after `'10'`).

| Step               | Detail                                                                                               |
| ------------------ | ---------------------------------------------------------------------------------------------------- |
| 1. Classify        | for each of the 226, is the web column read arithmetically? `grep` each against `src`                |
| 2. Migrate         | additive migration per table: add typed column, backfill with a validated cast, swap reads, drop old |
| 3. Guard           | reject non-numeric writes at the boundary before the type changes, so backfill cannot fail           |
| 4. Shrink baseline | `pnpm type:parity --write` after each table; baseline count must only decrease                       |

**Test:** per table, a DB test that writes a non-numeric string and asserts rejection; plus
`type:parity` baseline count assertions.

**Exit criterion:** baseline reaches **0**, or every remaining entry has a written justification in the
baseline file itself.

### 0.5 Typecheck the tests

**Evidence:** `apps/api/tsconfig.test.json` exists and surfaces **114** errors; it is not a gate, so a type
error in a new test is never caught. (It was 112 before this session added two test files — the count grows
silently precisely because it is not a gate.)

**Plan:** clear the 112 in batches by directory; then add `tsc -p tsconfig.test.json --noEmit` to the
verification sequence and to CI.

**Exit criterion:** 0 errors and the command is in the gate list.

### 0.6 Build the documentation reference checker

Every `path:line` citation, table name and numeric claim in the docs must resolve against the tree. The manual
version of this check has caught something **seven** times (§10.4), which is a high enough rate to automate.

**Implementation:** `scripts/check-doc-references.mjs` — extract citations and `<!-- verify: cmd -->` tagged
claims, re-run each, fail on mismatch. **Control:** alter one cited line number and confirm it fails.

### 0.7 Build the completion register

`docs/COMPLETION-REGISTER.json` plus `scripts/check-completion-register.mjs` (§9.1). Without it there is no
machine-checkable definition of done, and progress reverts to assertion.

**Seed it** with all 204 forms in state `unclassified`, all 22 families, 48 report slugs, 39 settings and 7
integrations, so the starting position is explicit rather than implied.

**Phase 0 exit:** all seven items done, each with a control demonstrated failing. Only then is any Phase 1
result meaningful — and the register plus the reference checker are what keep every later phase honest.

---

## Phase 1 — Voucher parity, family by family (the core of the migration)

This is the heart of it. Everything else is scaffolding around this phase.

### 1.1 The method (fixed, do not vary)

Established over four sessions; each step exists because skipping it caused a documented error.

1. **Count the output.** Real rows per book, grouped by row type. Ground truth.
2. **Count the source columns.** A routine guarded on an empty column never fires. (Cut rate cut 40→9.)
3. **Read the desktop source for STRUCTURE only** — tables, guards, `BOOK_DETL` slot, key layout.
4. **Take directions and accounts from the DATA**, unless verified to agree per type.

**Source for what exists, data for what runs.** The desktop source is a _later version_ than the data —
proven (sale item rows are type `'02'` in source, `'01'` in data) — and the divergence is **not uniform**, so
verify per row type.

### 1.2 Progress — 3 of 16 families, 31 defects fixed

**What the first three families established, which the plan did not anticipate:**

1. **No two families share a key layout.** Sale is 23 characters with the leg type at 22-23; scheme is 33 with a
   bare line right-aligned in 10; cash is 33 with `<line><leg>` right-aligned in 12 — and the cash _Rojmel_ uses
   the scheme's shape, so **one voucher can use two layouts across two of its own tables.**
2. **Leg codes are per-`MAIN_BOOK`, not per-role or per-direction.** `BANK REC` 05/06 is a bank-charges pair
   while `CASH PAY` 05/06 is party/cash. Three distinct schemes in family 3 alone.
3. **A balance assertion cannot catch any of this.** All 31 defects balanced.
4. **Shared helpers encoded one family's assumption as universal** — `buildTransferLedger`, `settlementAc`'s
   `'CASH'` literal in five paths, `lineTotalDesktop`'s hardcoded rounding, the aggregate Rojmel row. This is
   why the per-family records exist rather than a single shared model.
5. **A fix routinely uncovers a sibling.** Resolving one account exposed three more sites; splitting one leg
   pair exposed a stale comment; keying one table exposed that another had never been compared.

### 1.3 The family queue, ordered by real ledger rows

Ordering is by measured output, not by code size.

| #   | Family                  | Book(s)             | Real rows        | Reference voucher                                       | Desktop source                |
| --- | ----------------------- | ------------------- | ---------------- | ------------------------------------------------------- | ----------------------------- |
| 1   | Sale (tax invoice)      | 026/027/029/030/032 | 556              | **DONE** — 13 defects, `comparisons/family-01-sale.md`  | `TR_SALE.cs` 21,586           |
| 2   | Scheme instalment       | 074/075             | 1635 (2622 legs) | **DONE** — 6 defects, `comparisons/family-02-scheme.md` | `TR_MEMB_ENT.cs`              |
| 3   | Cash + bank pay/receive | 001/002 + 11 bank   | 522 + 228        | **DONE** — 12 defects, `comparisons/family-03-cash.md`  | `TR_CASH_*.cs`, `Ac_Tax.cs`   |
| 4   | Purchase                | 035/036             | 115              | incl. one with `PR_BILL_OS < 0`                         | `TR_PURC.cs` 17,255           |
| 5   | Contra / journal        | 017                 | 74               | multi-line                                              | `TR_JV.cs`                    |
| 6   | Rate cut                | 064                 | 66               | one per live type (9)                                   | `TR_RATE_CUT.cs`              |
| 7   | Sales order             | 020                 | 55               | with an adjustment                                      | `TR_SALE_ORD.cs` 12,022       |
| 8   | Scheme adjust           | 076                 | 37               | maturity + bonus                                        | `TR_MEMB_ADJ.cs` ⚠️ uncited   |
| 9   | Fine JV                 | 078                 | 28               | both types                                              | `TR_FINE_JV.cs`               |
| 10  | Karigar receipt         | 052                 | 28               | types 11 and 01                                         | `TR_MFG_KR_ISU_REC.cs` 11,974 |
| 11  | Sales return            | 028/031             | measure          | with an admitted tag                                    | `TR_SALE_RTN.cs` 16,923       |
| 12  | Tag opening             | —                   | measure          | —                                                       | `TR_TAG_OPBL.cs` 14,664       |
| 13  | Tag split               | —                   | measure          | —                                                       | `TR_TAG_SPLIT.cs` 12,940      |
| 14  | Hallmark sale           | —                   | measure          | —                                                       | `TR_SALE_HM.cs` 15,353        |
| 15  | Labour sale             | —                   | measure          | —                                                       | `TR_SALE_LBR.cs` 12,299       |
| 16  | Wholesale sale          | WH SALES            | 38               | **form does not exist**                                 | `TR_WH_SALE.cs` 18,007        |

Families 11–15 need their real row counts measured before ordering — several may be dead for this customer,
which is a legitimate reason to defer but **must be recorded as a fact about `Live24`, not a general claim.**

### 1.3 Per-family procedure

For each family, in order. **Every step produces a retained artifact.**

```bash
# 1. inventory the real output
SQL -d Live24 -Q "... GROUP BY SUBSTRING(LEDR_KEY,22,2) ..."   # row types, must sum to the book total

# 2. inventory the write set
for t in <candidate tables>; do <row count>; done               # zero rows = not a gap

# 3. pick reference vouchers: simplest, most complex, and each edge guard
# 4. extract desktop bundle
PARITY_CASES='[...]' node integration/parity-extract-mssql.mjs
# 5. seed + replay
node integration/parity-replay-<family>.mjs
# 6. extract web bundle, compare
node integration/parity-extract-pg.mjs
node integration/parity-compare.mjs desktop-latest.json web-latest.json
# 7. triage EVERY difference into: fixed | deliberate | unresolved | owner-decision
# 8. fix, test, prove a control, re-run to zero
```

**Triage discipline** (learned by nearly breaking GST returns): before "fixing" a difference to match the
desktop, `grep` who reads the column in the web. If the web reads it and the desktop does not, it is a
**deliberate divergence with a reason**, not a defect.

### 1.4 Per-family exit criteria

A family is **done** when all of these hold and are retained as artifacts:

1. `parity-compare` reports **0 unexplained field differences** for every reference voucher.
2. Every remaining difference is in one of the four categories, in writing, with its measurement.
3. Row-type coverage: every row type present in real data for that book is produced by the web, or its absence
   is explained by a measured guard column.
4. The write set is asserted as an **exact set** (`toEqual`, never `toContain`).
5. Edit and delete are covered: post → edit → assert identity preserved → delete → assert full reversal.
6. A control is demonstrated failing for each new assertion.
7. `LEDR_KEY` reproduced byte-for-byte, including line numbers where the type repeats.
8. **`docs/comparisons/<family>.md` written in the same commit**, with the four-way triage and the artifact
   path; `MODULE-VERIFICATION-CATALOGUE.md` and `STATE-OF-PARITY.md` updated; any correction added to
   `GAP-ANALYSIS-AND-PLAN.md` **with its method error stated**, not just the corrected fact.

### 1.5 Known open items in family 1 (sale) — the template

| Item                                           | State                              | Next action                                                                                                                                     |
| ---------------------------------------------- | ---------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| `AC_DATA.LEDR_KEY` length                      | ✅ fixed, 23 chars, test + control | —                                                                                                                                               |
| `MAIN_STOCK.ITM_QTY`                           | ✅ fixed to 1 (all 267 real rows)  | apply the same measurement to the other 18 modules that write it                                                                                |
| `SL_DATA.LBR_AMT`                              | ✅ fixed to 0 (all 190 headers)    | —                                                                                                                                               |
| GST tax master resolution                      | ✅ fixed, pins `SR_NO 0`           | —                                                                                                                                               |
| Leg **type codes** 01/03/04 vs 01/02/03        | ❌ open                            | measure all 7 settlement shapes in book 027 (`01/03/04`, `09/10`, `19/20`, `25/26`), derive the role→code map, then implement                   |
| `SL_DETL.TOT_AMT`                              | ⚠️ unresolved                      | desktop inconsistent (36 net+tax vs 94 net). Re-measure across **all** sale books; if still inconsistent, keep `NET_AMT` and record permanently |
| `SL_DETL.ITM_AMT`/`LBR_AMT` component rounding | ❌ open                            | desktop rounds each component (354.00, 74.00); web keeps 354.20, 74.01. Apply `billTotal` precision per component                               |
| `MAIN_STOCK.SR_NO`                             | ⚠️ unresolved                      | 41 of 63 vouchers identical, 20 increment. Test correlation with `TAG_NO` presence                                                              |
| `KR_NET_WT`/`KR_TOUCH`/`KR_FINE`               | ❌ open                            | populated on 102 of 245 real rows. Needs a replay with a known karigar                                                                          |
| `TAG_GWT`/`TAG_NWT`                            | ❌ open                            | needs a **tagged** replay                                                                                                                       |
| `labourFixed` silent zero                      | ❌ open                            | add a guard: reject `labourFixed` without `labourType`                                                                                          |
| Round-off 4th leg                              | 🔶 owner                           | see §6.1                                                                                                                                        |

**Family 1 is the template.** Its open-item table is the shape every other family's must take.

### 1.6 `g5:parity` becomes the gate

Today it is RED for the right reason. It must become the **release gate**:

- one comparison artifact per family per reference voucher, all retained
- `check-g5-parity.mjs` extended: GREEN only when **every** queued family has an artifact with zero
  unexplained differences
- an artifact older than its family's last code change is **stale and fails**

**Exit criterion for Phase 1:** `pnpm g5:parity` GREEN across all live families, on captured evidence, with
staleness enforced.

---

## Phase 2 — Close the form gaps

### 2.1 The measurement

```bash
# forms never referenced anywhere in web source
python3 - <<'PY'
import re, pathlib
forms = [p.stem for p in pathlib.Path('unified/src/csharp/DataCareNext').glob('*.cs')]
web = ''.join(p.read_text(errors='replace')
              for pat, root in (('*.ts','web/apps/api/src'), ('*.tsx','web/apps/web/app'))
              for p in pathlib.Path(root).rglob(pat))
un = [f for f in forms if not re.search(rf'\b{re.escape(f)}\b', web)]
print(len(forms), len(un))
PY
# -> 204 forms, 72 never cited
```

**Caveat on the method, stated because it matters:** _cited_ is a weak positive — a form named in a comment is
not necessarily implemented. _Never cited_ is a strong negative. So **72 is a floor on the gap, not the gap.**
Phase 1 is what converts "cited" into "verified".

### 2.2 The 72, by category

| Category                                      | Forms  | Desktop lines | Treatment                                              |
| --------------------------------------------- | ------ | ------------- | ------------------------------------------------------ |
| **Reports (`RP_`)**                           | **24** | **89,303**    | §3                                                     |
| **Transactions (`TR_`)**                      | **5**  | **38,014**    | §2.3                                                   |
| Masters (`MS_`)                               | 9      | 14,408        | §2.4                                                   |
| Utilities (`UT_`)                             | 5      | 11,183        | §2.5                                                   |
| `Module_WhatsApp`                             | 1      | 4,523         | §7.3                                                   |
| e-invoice DTO classes (`Cls*`, `IRN*`)        | ~22    | ~700          | verify covered by `einvoice.ts`, else implement        |
| Infrastructure (`AuthClass`, `Translator`, …) | ~6     | ~600          | assess individually; several are desktop-only concerns |

### 2.3 The five uncited transaction forms

**Each needs a live/dead determination from real data before any code is written.** That determination is a
fact about `Live24` and must be labelled as such.

| Form              | Lines  | First action                                                                                                                                                                                                                           |
| ----------------- | ------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `TR_SALE_RTN_UAE` | 11,444 | Determine whether the UAE variant is in scope at all — a business decision, not a technical one. If out of scope, record it as an explicit scope exclusion.                                                                            |
| `TR_TOUR_ORD`     | 9,870  | `TOUR SALES` is entirely retired in `Live24` (10 books, 0 active). Confirm, then defer with the fact recorded.                                                                                                                         |
| `TR_SL_PR_ITEM`   | 8,733  | Measure its tables. Likely the item-wise sale/purchase register.                                                                                                                                                                       |
| `TR_PR_SL_HEDG`   | 4,654  | Hedging. Measure; likely dead for this customer.                                                                                                                                                                                       |
| `TR_MEMB_ADJ`     | 3,313  | ⚠️ **Book 076 has 37 real rows and the web already posts scheme adjust.** So the _function_ exists while the _form_ is uncited — this is a citation gap, not a functional one. Resolve by adding the source reference during family 8. |

`TR_MEMB_ADJ` is the clearest illustration of why "uncited" is a floor: the capability is present and tested,
only the provenance comment is missing.

### 2.4 Masters and 2.5 Utilities

**Procedure, identical for both:** for each form, (a) identify its tables, (b) count real rows, (c) check whether
the web writes those tables from any path, (d) classify as _implemented elsewhere_, _live gap_, or _dead here_.

Special attention:

- **`MS_UPDATE` (33,074 lines — the largest desktop form)** is the schema updater / version migrator. Its web
  equivalent is the Prisma migration chain plus `fresh:provision`. **Do not port it.** Instead prove
  equivalence: `schema:readiness` 145/145 and 5231/5231, plus `type:parity` at 0. Record the mapping explicitly
  so its absence is a decision, not an oversight.
- **`UT_IMPORT` (14,466 lines)** is the data importer and one of only two writers of `OP_LDR`. It is the
  **model for Phase 8's migration tooling**, so read it before designing that, not after.
- **`UT_VCH_RE_NUMBR` (4,445 lines)** renumbers vouchers. High-risk, touches `LEDR_KEY` on every affected row.
  If in scope, it needs its own parity family.

### 2.6 Wholesale sale — the one confirmed functional absence

`TR_WH_SALE.cs`, 18,007 lines, 13-table write set. The web ships the 1,503-line **return** form and no sale, and
`TR_WH_SALE_RTN.cs` filters `MAIN_BOOK IN ('WH SALES','TOUR SALES')` — there is no separate return book. So the
web currently offers an operation that can only act on migrated data.

Real usage: **38 ledger rows, ~15 vouchers/year.** `BUL WH SALE` has 2 active books and 0 vouchers.

**Recommendation, unchanged:** scope this against a second customer database before building 18,007 lines'
worth of behaviour for 15 vouchers a year. If a second database shows heavy wholesale use, it becomes a Phase 1
family. **This is an owner decision (§6.3).**

**Phase 2 exit (revised):** driven by `docs/COMPLETION-REGISTER.json` and enforced by
`pnpm register:check --strict`. Every one of the **198 `MENU_DATA` items** — the user-facing surface, not the
form-file count — is in exactly one state, with `verified` requiring an evidence path that exists on disk and
each judgement state requiring a written note. Currently **198 unclassified**.

The form-file view is retained as a secondary check: every one of the 204 desktop forms is in exactly one
bucket — _implemented and verified_,
_implemented elsewhere (with the mapping written)_, _dead in this dataset (with the count)_, or _explicit scope
exclusion (with the decision recorded)_. Zero forms unclassified. This is a written register, checked by a
script that fails on an unclassified form.

---

## Phase 3 — Reports: the largest untouched surface

**24 report forms never referenced, 89,303 desktop lines** — the single biggest block of unexamined
functionality. And of the 48 slugs that _do_ exist, **none has had its output compared to Crystal**.

### 3.1 Two separate problems, do not conflate

|         | Problem                                                       | Can be done locally?                   |
| ------- | ------------------------------------------------------------- | -------------------------------------- |
| **3.2** | Report **data** never compared to the desktop's query results | **Yes** — `Live24` is attached locally |
| **3.3** | Report **layout** never compared to Crystal output            | **No** — needs a Windows box           |

**3.2 is available now and has never been done.** That is the priority.

### 3.2 Report data parity (local, no Crystal needed)

For each of the 48 existing slugs:

1. **Find the desktop's query.** `RP_*.cs` builds SQL as string literals; extract it.
2. **Run both.** Desktop SQL against `Live24` in SQL Server; the web builder against a tenant loaded with the
   same data.
3. **Compare row sets** — same canonicaliser, same union-not-intersection discipline as the voucher differ.
4. **Compare totals and groupings separately** from detail rows; a matching total with mismatched detail is a
   worse failure than an obvious one.

<!-- planned: scripts/check-report-parity.mjs -->

**New tooling required:** `scripts/check-report-parity.mjs` plus a `report-parity-baseline.json`. Model it on
`check-type-parity.mjs`: SKIP (never silent pass) when the SQL Server side is unavailable, exit 1 on a new
mismatch, and a control proven by breaking one report.

**Prerequisite:** loading `Live24` into Postgres for a like-for-like comparison. That is the **Phase 8 migration
tooling**, so Phase 3.2 and Phase 8 share a dependency — build the loader once, use it for both.

**Exit criterion:** all 48 slugs compared, every difference triaged into the four categories, gate GREEN with a
control.

### 3.3 Crystal layout parity (needs Windows)

`docs/PARITY-WINDOWS-PROCEDURE.md` and `docs/WINDOWS-AGENT-PROMPT.md` already specify the capture procedure.

| Step | Detail                                                                                                                      |
| ---- | --------------------------------------------------------------------------------------------------------------------------- |
| 1    | Windows box with the desktop app + Crystal runtime + a restored copy of the customer database                               |
| 2    | Export each `RP_` report to PDF for a fixed parameter set; retain as the reference artifact                                 |
| 3    | Render the web equivalent to PDF for the same parameters                                                                    |
| 4    | Compare: page count, column headers and order, group breaks, subtotal placement, number formats, date formats, page footers |
| 5    | Record per report: exact / acceptable-difference-with-reason / not-acceptable                                               |

**Never claim Crystal pixel parity without a retained artifact.** The 254 existing baselines are web-vs-web
regression checks and must stop being described as parity evidence anywhere.

**Exit criterion:** every in-scope report has a retained side-by-side artifact and a written verdict.

### 3.4 The 24 uncited reports

Classify first, build second. For each: what tables, how many real rows, is there an existing slug that covers
it, is it live for this customer.

From what is already known:

- `RP_DHRN_LOAN` (3,336) — pawnbroking; the six dhrn/loan routines are **dead in `Live24`**. Defer, record.
- `RP_TOUR_ZOOM` (5,861) — `TOUR SALES` retired. Defer, record.
- `RP_GST` (3,944) — ⚠️ **GST returns are statutory.** Even if the web has a GST module, this must be compared
  field by field against the desktop's return output. **High priority.**
- `RP_BILL_PROFIT` (6,121), `RP_STOCK_VALUE` (3,399), `RP_TRADING` (3,321), `RP_OS` (5,679) — core commercial
  reports. Measure and prioritise by whether the business actually runs them.

**Determining which reports the business actually uses cannot be done from the database** — report execution is
not logged. **This requires asking the business owner.** Recorded as an information gap, not guessed.

---

## Phase 4 — Behaviour settings matrix

**37 of 39 behaviour settings have no test** proving each changes the persisted result. They are surfaced and
loaded — `settings:parity` is 128/128 — but that gate proves _presence and mapping_, not _effect_.

### 4.1 What a proven setting looks like

For each setting, a DB test that:

1. posts an identical voucher under value A and value B,
2. asserts the **persisted rows differ in the specific documented way**,
3. cites the desktop source line that defines the behaviour,
4. has a control: forcing the code to ignore the setting makes the test fail.

`TOT_AMT_ROF` is the worked example and the cautionary tale: it is implemented correctly, and its absence from
a test suite meant a harness omission masqueraded as a product defect for two commits.

### 4.2 Queue

Ordered by blast radius: `PR_AMT_TYPE`, remaining `*_ROF`, `FINE_STK_TYPE`, `STK_RPT_TYPE`, `PURC_WITH_LBR`,
`CO_STK_MERGE`, then the rest.

### 4.3 Add a strict mode

`PARITY_STRICT=1` makes every settings loader **throw** when a flag row is absent rather than fall back to a
default. Run the whole DB suite under it in CI. This converts the entire class of "harness omission looks like
a defect" into an immediate failure.

**Exit criterion:** 39 of 39 with a matrix and a control; strict mode green in CI.

---

## Phase 5 — Data migration (desktop database → web)

Real businesses do not start empty. This phase is a hard prerequisite for go-live and is **almost entirely
unbuilt**.

### 5.1 What exists

`apps/api/integration/cutover.mjs` and `EXPECTED_MIGRATIONS` / `fresh:provision` for schema. **No proven
end-to-end load of a real customer database into the web has ever been performed.**

### 5.2 What is required

| Step                | Detail                                                                          | Verification                                                          |
| ------------------- | ------------------------------------------------------------------------------- | --------------------------------------------------------------------- |
| 1. Extract          | all 145 tables from SQL Server for one company + year                           | row counts per table match source exactly                             |
| 2. Transform        | type coercion (the 226 columns), tenant injection, text width truncation checks | zero silent truncations; a value that will not fit **fails the load** |
| 3. Load             | into Postgres under one tenant, RLS respected                                   | per-table row counts equal source                                     |
| 4. Reconcile        | ledger totals, per-account balances, stock weights, scheme member balances      | **every figure equal to the desktop's own report output**             |
| 5. Opening balances | `OP_LDR` → `ACOP` legs per §6.2                                                 | net per account equal; detail loss acknowledged                       |
| 6. Rehearse         | full dry run, timed, with rollback                                              | documented duration and a proven rollback                             |

### 5.3 The reconciliation set (the real exit criterion)

A load is **not** successful because it ran without error. It is successful when these agree with the desktop:

- trial balance per account (918 accounts in `Live24`)
- ledger grand totals (5094 rows; Dr and Cr sums)
- closing stock by item and by metal (weight and value)
- scheme member balances (8194 `AD_OS` rows; `Σ(A+) − Σ(D−) − Σ(B−)`)
- bill outstanding per party
- tag inventory count and weight
- **and the 99 knowingly-unbalanced vouchers must reconcile to the same imbalance**, or the deviation must be
  deliberate and recorded (§6.1)

**Exit criterion:** a rehearsed load whose reconciliation report shows zero unexplained differences, with the
report retained.

### 5.4 Known model difference to carry forward

`OP_LDR` holds prior-year **detail** (7011 rows, 2566 for one account); the web carries the **net** as one
`ACOP` leg. Opening figures agree; prior-year drill-down does not exist. Also `OP_LDR` is itself unbalanced
(86,510,920.77 Dr vs 87,615,844.46 Cr across 117 of 918 accounts), so it is a partial copy rather than a
ledger. **If the business needs prior-year detail, this becomes a feature to build, not a difference to
accept — and that is an owner decision (§6.4).**

---

## Phase 6 — Owner decisions (blocking, cannot be resolved from evidence)

These cannot be decided from the repository or the data. Each is stated with its evidence so the decision is
informed, and each **blocks a specific phase**.

### 6.1 The 99 unbalanced vouchers

**Evidence.** `TOT_AMT` is a whole rupee while `TAX_AMT` keeps paise, and the desktop posts the residue nowhere.
89 sale vouchers carry a sub-rupee imbalance (99 of 1567 overall). The web posts it to kasar (`BOOK_DETL` slot 3,
`00057`) and balances. The desktop **does** use that account — book 027 has 15 ledger rows of leg type `26`
naming it — just not for this.

**Decision.** Reproduce the imbalance (byte parity, knowingly unbalanced books) **or** keep the web's balancing
leg (more correct, more auditable, ledger differs by one row per affected voucher).

**Blocks:** Phase 1 family 1 closure, Phase 5 reconciliation.
**Recommendation:** keep the web's leg; it is defensible to an auditor and the desktop's behaviour is very
likely a defect. But it must be a recorded decision, because it changes report output.

### 6.2 The fine double-count on overpaid purchases

**Evidence.** When `PR_BILL_OS < 0`, the desktop writes the fine on **both** types `01` and `13`. Verified on
both real occurrences (vouchers 00004 / −850.00 / 2.050 and 00020 / −122.00 / 3.814). Currently **reproduced
deliberately** and pinned by a test.

**Decision.** Keep reproducing a probable desktop defect, or correct it and diverge.
**Blocks:** Phase 1 family 4 closure.

### 6.3 Wholesale sale — build or exclude

**Evidence.** 18,007 desktop lines, 13-table write set, **38 ledger rows / ~15 vouchers per year** in this
dataset. The web already ships the return form, which today can only act on migrated data.

**Decision.** Build it, or declare it out of scope and remove the orphaned return form from the menu.
**Blocks:** Phase 2 exit.
**Recommendation:** obtain a second customer database first. If wholesale is material elsewhere, build it.

### 6.4 Prior-year ledger detail

**Evidence.** §5.4. Opening figures agree; drill-down into last year's transactions does not exist.
**Decision.** Accept, or build `OP_LDR`-equivalent detail retention.
**Blocks:** Phase 5 exit.

### 6.5 Scope boundaries

`TR_SALE_RTN_UAE` (11,444 lines) — is the UAE variant in scope? `TOUR SALES` and the six dhrn/loan routines are
**dead in this dataset** — are they dead for the business, or merely unused in the sampled year?

**Only the business can answer.** Every "dead" classification in this project is a fact about `Live24`, not
about the business.

### 6.6 Which reports the business actually runs

Report execution is not logged, so **this cannot be measured**. Needed to prioritise Phase 3.

---

## Phase 7 — External integrations

Never exercised against real hardware or credentials. Implemented end to end; **no reading has ever been
fabricated**, and none may be.

| #   | Integration                               | State                            | Verification requirement                           |
| --- | ----------------------------------------- | -------------------------------- | -------------------------------------------------- |
| 7.1 | Weighing scale                            | serial/USB protocol implemented  | a real scale, a real reading, a retained log       |
| 7.2 | Printers (invoice, tag, barcode)          | layouts exist                    | physical print on the customer's stock and printer |
| 7.3 | WhatsApp (`Module_WhatsApp`, 4,523 lines) | **uncited**                      | real credentials; a delivered message              |
| 7.4 | e-invoice / IRN                           | `einvoice.ts` + ~22 DTO classes  | sandbox IRN generated, then production credentials |
| 7.5 | e-way bill                                | assess                           | as above                                           |
| 7.6 | SMS / email                               | assess                           | delivered message                                  |
| 7.7 | Backup / restore                          | assess against desktop behaviour | a restore proven to reproduce a working system     |

**Exit criterion per integration:** a retained artifact from real hardware or a real credential. **A test double
passing is not evidence of an integration working** — it is evidence the code is callable.

---

## Phase 8 — Production hardening

Parity is necessary and not sufficient. A real business also needs the system to stay up and stay safe.

### 8.1 Security

| Item             | Requirement                                                                                               |
| ---------------- | --------------------------------------------------------------------------------------------------------- |
| Authentication   | already present; add password policy, lockout, session expiry review                                      |
| Authorisation    | 383 routes policed; **prove** the policy denies — a test per form asserting a non-permitted user gets 403 |
| RLS              | 172 tables forced with policies, proven on a fresh database ✅                                            |
| Audit trail      | who changed what, when — compare against the desktop's `MAIN_USER`/`ENTRY_TIME` behaviour                 |
| Secrets          | no credentials in the repo; rotation documented                                                           |
| Transport        | TLS; secure cookies; CSRF review                                                                          |
| Dependency audit | pinned versions; `npm audit` in CI                                                                        |
| Penetration test | authorised, scoped, on the customer's own deployment                                                      |

**Note on scope:** the web application is network-exposed where the desktop was not. **This is a new attack
surface that did not exist before the migration**, and it deserves an explicit review rather than inheriting the
desktop's assumptions.

### 8.2 Performance and scale

Untested at realistic volume. `Live24` is one company and one year; a real deployment accumulates.

| Item                 | Target to establish                                                                                                                |
| -------------------- | ---------------------------------------------------------------------------------------------------------------------------------- |
| Voucher post latency | measure at 10×, 100× current data                                                                                                  |
| Report generation    | the largest reports against multi-year data                                                                                        |
| Concurrent users     | the real counter shape — `SRNO_MAST` is unique on `(tenant, CO_CODE, LC_CODE)`; **prove voucher numbering under concurrent posts** |
| Database connections | `vitest` already bounded at 4 threads for `max_connections` 100 — size the production pool deliberately                            |
| Index coverage       | `EXPLAIN` every report query against a large dataset                                                                               |

**`SRNO_MAST` concurrency is a genuine risk**, not a hypothetical: two simultaneous sales must not receive the
same voucher number. This needs a test that posts concurrently and asserts uniqueness.

### 8.3 Operations

Backup and restore (tested, timed, with a proven restore), monitoring and alerting, error tracking, log
retention, a documented upgrade path, and a rollback plan for go-live.

### 8.4 User acceptance

**The step no amount of engineering replaces.** The people who use the desktop daily must run their real work
through the web application in parallel for a full cycle — including a month-end and ideally a year-end — and
sign off.

Keyboard behaviour deserves specific attention: the desktop is a keyboard-driven data-entry application. **F-key
bindings, tab order, and grid entry are workflow, not cosmetics.** An operator who types 200 vouchers a day
will reject a form that needs a mouse, regardless of whether its write set matches.

**Exit criterion:** parallel running with zero unexplained discrepancies for one full month-end, signed off.

---

## Governance — how "done" stays honest

### 9.1 The completion register

A single machine-checked file: every one of the 204 desktop forms, every voucher family, every report, every
setting, every integration — each with a state and its evidence artifact path.

`scripts/check-completion-register.mjs`:

- fails on any unclassified item
- fails on any item claiming `verified` without an artifact path that exists
- fails on an artifact older than the code it certifies (staleness)
- prints the counts that make up the headline claim

**No completion claim is made outside this register.**

### 9.2 Rules that survived being violated

Each of these exists because it was broken and cost real work:

1. **Never put `vitest run` and `git commit` in the same shell block.** Three commits on red before this became
   a mechanism instead of an intention.
2. **Every gate demonstrated failing before it is trusted.** ~70 controls proven so far.
3. **A control whose edit did not land is not a control.** Assert the edit, then run.
4. **Assert that string replacements landed.** Prettier reflows files; an unasserted `replace()` silently
   no-ops and produced a document claiming an implemented feature was missing.
5. **Never weaken a test to make it pass.**
6. **A retracted method leaves behind conclusions drawn with it.** Re-check them individually — a false
   `KR_DETL` finding survived its method's retraction for weeks.
7. **Do not overwrite a failure log before reading it.**
8. **`grep` who reads a column before matching the desktop.** Nearly broke GST returns and e-invoicing.
9. **A harness that under-seeds manufactures false defects.** Two retracted findings.
10. **Piping to `head` makes `$?` report head's status** — verify exit codes without a pipe.

### 9.3 What must never be claimed

- Parity of any kind without a retained comparison artifact.
- Crystal layout parity without a PDF pair from a Windows box.
- A working integration without a real reading, print, or delivered message.
- That a "dead" routine is dead for _the business_ — only that it is unused in `Live24`.
- A percentage that counts presence as if it were behaviour. `schema:readiness` at 100% coexisted with 226
  wrong column types; `settings:parity` at 128/128 coexists with 37 unproven behaviours.

### 9.4 Sequencing and dependencies

```
Phase 0 (instruments)  ─── blocks everything
   ├── Phase 1 (voucher parity, family by family)   ← the bulk of the work
   ├── Phase 4 (settings matrix)                     can run in parallel with 1
   └── Phase 2 (form classification)                 can run in parallel with 1
          └── Phase 3.2 (report data parity) ── shares the loader with ── Phase 5 (migration)
                 └── Phase 3.3 (Crystal) ← needs Windows
Phase 6 (owner decisions) ── blocks closure of 1, 2, 5
Phase 10 (docs)           ── NOT a phase: an exit criterion inside every item above
Phase 11 (continuous run) ── the operating protocol for all of it
Phase 7 (integrations)    ── needs hardware and credentials
Phase 8 (hardening + UAT) ── last, and the UAT cannot be shortened
```

**Critical path:** Phase 0 → Phase 1 → Phase 5 → Phase 8 UAT. Phases 3.3 and 7 are gated on resources that do
not currently exist (a Windows box, hardware, credentials) and should be requested **now**, because they will
otherwise become the schedule.

### 9.5 On estimating

I will not put dates on this, and the reason is evidence rather than caution: **the first voucher of the first
family took a full working session and produced four blockers, a primary-key defect, and two defects in the
measuring instrument.** Any estimate made before three or four families are complete would be extrapolating
from a sample of one — the exact error this project has documented six times.

What can be said: after **four families**, the discovery rate per family becomes measurable, and a defensible
projection becomes possible. That is the first point at which a schedule means anything.

### 9.6 The single sentence version

The web application is well engineered and barely compared. **Phase 1 is the migration**; everything else
supports it, and no amount of the rest substitutes for replaying real vouchers, family by family, until the
findings dry up.

---

## 10. Documentation discipline — during implementation, not after

**The rule.** A phase item is not complete when the code works. It is complete when the code works, the tests
prove it, the control has been demonstrated failing, **and the affected documents are updated in the same
commit.** Documentation written afterwards is written from memory, and memory is where the retractions in
`GAP-ANALYSIS-AND-PLAN.md` came from.

### 10.1 Which document absorbs which kind of finding

| Finding                                      | Document                                      | What goes in                                                  |
| -------------------------------------------- | --------------------------------------------- | ------------------------------------------------------------- |
| A schema fact, type surprise, or convention  | `TECHNICAL-REFERENCE.md`                      | the fact, its consequence, and the defect it caused           |
| A measurement recipe, gate, control, or trap | `VERIFICATION-REFERENCE.md`                   | the command, and what happens when the step is skipped        |
| Per-module state                             | `MODULE-VERIFICATION-CATALOGUE.md`            | tables + real counts, verified/not, next measurement          |
| A voucher family comparison                  | `docs/comparisons/<family>.md`                | the four-way triage, with the artifact path                   |
| A correction or retraction                   | `GAP-ANALYSIS-AND-PLAN.md`                    | what was claimed, why it was wrong, what the method error was |
| Overall position                             | `STATE-OF-PARITY.md`                          | measured counts only, never an impression                     |
| A new test layer or gate                     | `VALIDATION-PLAN.md`                          | what it can prove **and what it cannot**                      |
| Phase progress                               | `MIGRATION-COMPLETION-PLAN.md` + the register | state change with its evidence path                           |

`FIRST-REAL-COMPARISON.md` becomes the **template**, not a growing file. Each family gets its own comparison
record in `docs/comparisons/`, using the same four categories: _fixed_, _deliberate divergence_, _unresolved_,
_owner decision_.

### 10.2 The per-item commit contract

Every implementation commit carries all five, or it is not finished:

1. the code change,
2. the test that fails without it,
3. evidence the control was demonstrated failing (in the commit message),
4. the document updates,
5. the register state change.

### 10.3 Retractions are additive, never silent edits

When a previous finding turns out to be wrong, **the wrong finding stays** with its correction beside it. Six
retractions are recorded so far and the pattern in them has been more useful than any individual fix — the
`KR_DETL` false positive survived its method's retraction for weeks precisely because a headline was corrected
without revisiting the conclusions drawn with it.

**A retraction must state the method error, not just the corrected fact.** "The rounding is not a defect" is
half a retraction; "the harness seeded `CO_SET` but not `CO_SET_NEW`, so an absent setting looked like a missing
feature" is the whole one.

### 10.4 Verify every reference against the tree before committing

This check has caught something **seven** times: five reversed rate-cut directions, a 220-line stale export
table, the `KR_DETL` retraction, book 043's `CUR_USE`, the ledger total 5194→5094, 44→48 report slugs, and the
test-typecheck count 112→114.

```bash
# every file path, line citation and count in a document must resolve
node scripts/check-doc-references.mjs        # TO BUILD in Phase 0
```

**To build (Phase 0.6):** a script that extracts `path:line` citations, table names and numeric claims tagged
with a `<!-- verify: cmd -->` comment from the docs, re-runs each, and fails on a mismatch. Until it exists,
the check is manual and must still happen.

**Working assumption, stated because the rate justifies it:** any unverified document is roughly half wrong.

### 10.5 Staleness is a gate, not a habit

`check-completion-register.mjs` (§9.1) fails when an artifact is older than the code it certifies. Extend the
same idea to documents: a document claiming a module is verified, whose module has changed since, is stale and
fails. This is what stops the doc set from drifting into fiction during a long implementation.

---

## 11. Continuous execution protocol

Once implementation starts it runs to completion without stopping. This section defines what that means
concretely, so "nonstop" is a procedure rather than an intention.

### 11.1 The loop

```
read the register  ->  take the highest item on the critical path
  ->  measure (never assume)
  ->  implement
  ->  test + demonstrate the control failing
  ->  run the full gate sequence
  ->  read the result, THEN commit (separate step, always)
  ->  update docs + register in the same commit
  ->  push
  ->  repeat
```

**No idle turns.** If an item is blocked, switch tracks (§11.4) rather than stopping. Parallel tracks exist
precisely so a blocker never halts the whole effort: Phase 1 families, Phase 2 classification and Phase 4
settings are independent of each other.

### 11.2 Resume from the register, never from memory

Context is finite and will compact during a run of this length. **Recovery is by re-reading state, not by
recalling it:**

```bash
git log --oneline -20                      # what actually landed
node scripts/check-completion-register.mjs # what is claimed, and whether its evidence exists
(cd apps/api && npx vitest run)            # the true current count
pnpm type:parity && pnpm schema:readiness  # the true current gate state
```

Any belief about progress that these four commands do not confirm is discarded. This is the same discipline as
"source for what exists, data for what runs", applied to the project's own state.

### 11.3 Never leave work uncommitted

A verified-green change is committed before the next item begins. The one time a commit was cancelled
mid-execution, the next session had to reconstruct what was on disk versus what was pushed.

Corollary: **never put `vitest run` and `git commit` in the same shell block.** Three commits landed on red
before this became a mechanism instead of an intention.

### 11.4 When blocked, switch tracks — do not stop

| Blocker                                                             | Action                                                                                                    |
| ------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| A material business rule cannot be resolved from source **or** data | record it in §6, take the next item, **ask at the next natural checkpoint** — do not guess                |
| Needs Windows / hardware / credentials                              | record the requirement, move to work that does not                                                        |
| Two failed attempts at the same approach                            | stop tweaking. Diagnose the root cause, state what went wrong, change approach                            |
| A test fails in a full run but passes in isolation                  | check connections, re-run once; if it moves, it is contention — if it repeats, it is real                 |
| A gate goes red unexpectedly                                        | read the failure log **before** overwriting it; the identity of nine failing tests was lost that way once |

**The only legitimate reason to stop and ask** is a business rule that neither the desktop source nor the real
data can settle — a genuine ambiguity where guessing would embed a wrong answer. Everything else continues.

### 11.5 What "the end" means

Not "the plan's items are ticked". The end is:

1. `check-completion-register.mjs` green — every one of the 204 forms classified, every family verified with a
   live artifact, no staleness;
2. `g5:parity` GREEN on captured evidence across all live families;
3. `type:parity` baseline at 0, or every remaining entry justified in writing;
4. 39 of 39 settings with a matrix and a control;
5. report data parity green; Crystal layout artifacts retained for every in-scope report;
6. a rehearsed data migration whose reconciliation report shows zero unexplained differences;
7. every integration evidenced by a real reading, print or delivered message;
8. the six owner decisions recorded as decisions;
9. **UAT signed off after one full month-end of parallel running.**

Item 9 cannot be shortened, and it is the only one that is not mine to complete.

### 11.6 Honesty conditions that hold throughout

- Never claim parity without a retained artifact.
- Never claim an integration works without a real reading.
- Never present presence as behaviour — `schema:readiness` at 100% coexisted with 226 wrong types, and
  `settings:parity` at 128/128 coexists with 37 unproven behaviours.
- Never call a routine dead for _the business_ — only unused in `Live24`.
- Report the discovery rate alongside progress. **A phase that finds nothing is either finished or badly
  measured, and the second is more likely.**
