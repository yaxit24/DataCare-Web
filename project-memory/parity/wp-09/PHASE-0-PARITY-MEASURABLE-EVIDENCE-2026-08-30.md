# Phase 0 — Make parity measurable

Scope from `DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md`. Status: **items 0.1, 0.3 and 0.4 DONE; 0.2 open and
sized below.**

Phase 0 exists because the parity comparison went unrun for a month. When it was finally run, 1,354 of its 3,787
field differences turned out to be already fixed by code that had landed weeks earlier — the web-side bundle
predated the fix. Work was invisible in both directions.

## 0.1 Harness contract reconciled — DONE

`G5-HARNESS.md` documented `apps/api/integration/g5-compare.mjs` as "the single CI entry point". That file does
not exist. Investigating why produced the important part: it was **deliberately deleted**. `docs/VALIDATION-PLAN.md`
records six proven defects, each of which alone made the comparison unable to fail:

1. every date canonicalised to the empty string — 64 date columns across 42 tables always matched
2. numbers rounded to 3 decimals before comparison
3. `NULL` treated as equal to blank
4. numeric agreement judged by column **sums**, so offsetting errors cancelled
5. text upper-cased before comparison
6. the table set taken as the **intersection** of both schemas, so a table the web never wrote was discarded

So the fix was not to restore the file. `G5-HARNESS.md` was rewritten to document the real three-step flow
(`parity-extract-mssql.mjs` → `parity-extract-pg.mjs` → `parity-compare.mjs`), to record why the old harness must
not return, and to state plainly that the extractor **reads existing rows and posts nothing** — the property that
made the current measurement stale.

Verified: today's `parity-compare.mjs` run reports `tablesDesktopOnly 53`, so it does not take the intersection —
defect 6 is genuinely absent from the replacement, not merely undocumented.

## 0.3 One command — DONE

`pnpm parity:measure` (`web/scripts/parity-measure.mjs`, with pure logic in
`apps/api/src/modules/ops/parityRatchet.ts`) compares the newest bundles, prints the D1 numbers, and evaluates
them against a recorded ceiling.

```
D1 database parity
  cases matched          0 / 66
  fields                 3787 differing of 23574 compared (83.94% agree, 1625 excluded)
  rows                   210 missing, 210 extra
  tables                 368 compared, 53 desktop-only, 105 web-only
```

Modes: default compares the newest bundles; `--reuse` evaluates the newest existing diff (what CI runs);
`--record` writes the ceiling.

## 0.4 Ratchet — DONE

The existing `g5:parity` gate is binary and correct: it asks "is the web at parity?" and answers no. It cannot
express that 3,787 → 2,433 is progress. The ratchet does, and is a **separate gate** so it can never be mistaken
for a parity certificate.

Ceiling: `project-memory/parity/PARITY-RATCHET.json` — 66 case ids, the ten tracked metrics, and per-case metrics.

### Why it cannot be gamed

Every cheap route to a smaller difference count is itself a failure:

| Route | Guard |
| --- | --- |
| compare fewer fields | `fieldsCompared` must not fall |
| exclude more columns | `fieldsExcluded` must not rise |
| compare fewer tables | `tablesCompared` must not fall |
| un-match a case | `casesMatched` must not fall |
| delete an inconvenient case | a reduced case set is refused before any metric is read |
| dilute with easy cases | an expanded set is compared over the **shared** cases only |

The last rule was got wrong first. The initial implementation normalised totals per case, and its own test
exposed the flaw: `tablesCompared` and `fieldsCompared` are sums over cases, so their per-case average moves with
the **composition** of the set. Adding sixty simple cash sales touching four tables each, alongside purchases
touching six, lowers the average and would have been reported as a regression that never happened — which would
have blocked Phase 1, whose entire purpose is expanding the case set from 66 towards ~300. Replaced by a
shared-case comparison, which is the same comparison over the subset where one is meaningful.

A second self-inflicted defect: `--record` originally wrote the ceiling **before** the regression check, so a
regressed run could move the ceiling backwards — a ratchet that ratchets both ways. Now refused explicitly.

### Evidence it works

17 unit tests in `test/parityRatchet.test.ts`, one per gaming route. Two runner-level proofs against the real
artefact:

```
ceiling tampered to 3786 differences / 1 matched case:
  REGRESSED  fieldDifferences worsened: 3786 → 3787
  REGRESSED  casesMatched worsened: 1 → 0
  PARITY_RATCHET_REGRESSED ... EXIT=1

--record attempted on that regressed run:
  --record refused: a regressed run cannot become the new ceiling
  ceiling after refused record: 3000  (unchanged, not overwritten)
```

### Wiring

- CI (`ci.yml`): `pnpm parity:measure --reuse`, **enforced**, alongside the reported-only `g5:parity`.
- Release certification: new `parity-ratchet` gate. Its evidence check refuses a ceiling that compared no cases
  or no fields (it would constrain nothing) and one whose `caseIds` length disagrees with its `cases` count.
- The record carries `releaseSha`, without which the certifier correctly reported it STALE.

Certifier before: `passed=10 failed=3 skipped=1 missing=1`. After: `passed=11 failed=3 skipped=1 missing=1`.

## 0.2 Reproducible web bundle — DONE

The largest Phase 0 item. `parity-extract-pg.mjs` reads vouchers that must already exist in PostgreSQL, and the
local database holds **1** of the 66, so the web side cannot be refreshed and the 3,787 figure stays an August
baseline.

### Feasibility established

Two questions had to be answered before building anything.

**Does a replay work offline?** Yes. `parity-replay-sale.mjs` already implements the pattern for one reference
voucher — seed masters, post through the real module (`createSale`), leave the rows for the extractor. Its seed
values were read from the real database once and baked in, so it needs no SQL Server. Run here against the local
database it reproduced the desktop totals exactly:

```
REPLAY_OK tenant=parity-replay book=027 vchNo=1
  totals: net 1515, tax 45.45, total 1560, roundOff -0.45
  desktop:  NET_AMT 1515.00  TAX_AMT 45.45  TOT_AMT 1560.00
```

Note its own recorded caveat, which governs how any replay result must be read: **operator inputs are
reconstructed from the persisted rows**, so a field the desktop computed and stored, fed back as an input,
matches by construction and proves nothing. The informative columns are the ones neither side was told — ledger
legs, tax split, Rojmel projection, stock movement, bill outstanding.

**Can the master data be derived without the desktop database?** Yes, and this was the open risk. Master tables
are not voucher-scoped, so they are absent from the bundle — but the desktop's own rows name almost all of it,
and critically the **account slots are derivable from the `AC_DATA` legs the desktop actually posted**. That is
evidence rather than assumption, and it is what makes an offline replay possible.

### New tool: `parity-seed-derive.mjs`

Derives the seed surface from the retained bundle and writes
`project-memory/parity/PARITY-REPLAY-SEED.json`. Not throwaway analysis — it is the seeder's input.

Measured surface for the 66 cases:

| | Derived |
| --- | --- |
| Scope | company `01`, location `00`, year `2024-2025` |
| Books | **6** — see below |
| Account slots | **13** (`00001`, `00003`, `00008`–`00011`, `00042`, `00057`, `00077`, `00081`, `00085`, `00098`, `001008`) |
| Parties | **33**, with names |
| Items | **6** — `999` FINE GOLD, `OG` OLD GOLD, `ORG` NANO CHAIN, `ORS` SILVER ORNAMENTS, `OS` OLD SILVER, `OR925` G.BRACLATE |
| Tax codes | `00`, `10` |

| Book | Name | VCH_TYPE | Cases | Slots |
| --- | --- | --- | --- | --- |
| 034 | WH SALES | `WSALE` | 15 | 6 |
| 035 | PURCHASE | `FGPR` (fine gold) | 29 | 3 |
| 036 | PURCHASE | `FSPR` (fine silver) | 7 | 4 |
| 037 | PURCHASE | `FOGPR` (old gold) | 7 | 2 |
| 038 | PURCHASE | `FOSPR` (old silver) | 5 | 2 |
| 041 | PURCHASE | `TGLPR` (tagged gold) | 3 | 4 |

**Not derivable, and reported rather than guessed:** `CO_SET` and `CO_SET_NEW`. They decide rounding precision
and how a labour amount is represented, so inventing them moves money silently. The values already retained in
`parity-replay-sale.mjs` were read from the real database for this same company and are the correct source.

Also reported: the 12 slot accounts carry no derivable name, because `AC_DATA.LDR_NAME` is populated only on
party legs. They need an `AC_MAST` row but the name does not affect posting.

### Two defects found in the tool while building it

Both were caught by running it rather than reasoning about it:

1. **The header table was matched by `endsWith('_DATA')`**, which also matches `AC_DATA`, `DELETE_DATA`,
   `ROJ_MEL_DATA`, `TAX_DATA` and `TEMP_BOOK_DATA`. Because `AC_DATA` happens to carry an `AC_CODE`, the wrong
   match *silently succeeded* and produced 33 nameless parties, unnamed books and "no tax codes". Replaced by
   pairing the header with its detail table (`PR_DATA` ↔ `PR_DETL`), with a sub-ledger exclusion list.
2. **A flag's value was taken as the positional bundle path**, so `--json out.json` made the tool try to read its
   own output as input.

### What this revealed about the case set

The 15 cases labelled `wsale` are book 034 `WH SALES`, and their write set is `RATE_CUT_DATA`, `RATE_CUT_ISU`,
`RATE_CUT_REC`, `RATE_CUT_ISU_REC` with **no sale header or detail table at all**. So the 66 cases are 51
purchases across five metal-typed books plus 15 wholesale rate-cut vouchers — and rate cutting is the family the
gap analysis already identified as least correct (`RATE_CUT_DATA` 32 divergent columns, `RATE_CUT_ISU` 26).

### Replay built and run — 51 of 51 purchase cases

`parity-replay-purchase.mjs` seeds the 13 master tables from `PARITY-REPLAY-SEED.json` and posts every purchase
case through `createPurchase`, the same module the API route uses. **All 51 replay, every one with the desktop's
`NET_AMT` reproduced exactly.**

Four things the application refused rather than guessed, each a real validation working:

| Refusal | Resolution |
| --- | --- |
| `tax code is not configured: 00` | seed `TAX_MAST` for the codes the cases use — `00` at 0%, `10` as SGST 1.5 + CGST 1.5, measured from the desktop's own `TAX_DATA` rows |
| `missing GROUP_MAST.PURC_AC for item 999` | derive each item's group purchase account from the desktop's metal `ROJ_MEL_DATA` rows, where `LD_CODE` holds it |
| `bank-settlement account is not configured` (2 cases) | pass the book's derived slot-2 account; the desktop's own legs confirm it — both cheque-settled book-041 cases credit `001008`, exactly what slot 2 resolved to |
| `GR_CODE` value too long | `GROUP_MAST.GR_CODE` is `varchar(3)`; use a sequence, not a slice of the item code |

The slot derivation validated itself: slot 1 came out as `00008` for fine gold, `00009` silver, `00010` old gold,
`00011` old silver — the metal-typed structure the five purchase books imply, derived purely from which accounts
the desktop debited.

### The measured result, and a correction to an earlier claim

Comparing the fresh web bundle against the desktop over the **same 51 purchase cases**:

| Table | August bundle | Fresh replay | Δ |
| --- | --- | --- | --- |
| `PR_DETL` | 1,257 | 1,195 | **−62** |
| `PR_DATA` | 929 | 853 | **−76** |
| `MAIN_STOCK` | 658 | 618 | **−40** |
| `TAX_DATA` | 22 | 16 | **−6** |
| `ROJ_MEL_DATA` | 153 | 152 | −1 |
| `AC_DATA` | 76 | 102 | +26 |
| **total** | **3,095** | **2,936** | **−159 (5.1%)** |

**This corrects the gap analysis.** That document claimed 1,354 of 3,787 differences (35.8%) were already fixed
and merely unmeasured, reasoning that the August web bundle predated `desktopColumnDefaults.ts`. Measurement says
otherwise: the real improvement on identical cases is **159, about 5%**, so the August bundle evidently already
carried the defaults. The prediction was a plausible inference from timestamps and it was wrong; this is what the
loop was built to settle.

### Artefacts the replay itself introduced, and their removal

A replay's own seed can manufacture differences, so these must be separated from application defects:

- **`TEMP_BOOK_DATA.BOOK_NAME`, 51 differences — exactly one per case.** `PR_DETL.BOOK_NAME` and
  `AC_DATA.BOOK_NAME` both hold the MAIN_BOOK (`PURCHASE`), not the book's display name. Fixed by taking the
  display name verbatim from the desktop's own `TEMP_BOOK_DATA` — `Gold Purchase`, `Silver purchase`,
  `Old Gold Purchase`, `Old Silver Purchase ` (with its real trailing space, deliberately not trimmed),
  `Gold Purchase Tax`. Now zero.
- **`AC_DATA.AC_CODE`, 1 difference** (`00009` vs `00011`) is the ambiguity already identified: item `OS` appears
  in books 036 and 038 whose purchase accounts differ, so no single item-group value reproduces both.

What remains in `AC_DATA` is dominated by **real** defects, of exactly the classes the gap analysis named:

```
PARTY_AC_CODE  52   desktop ''                web '00008'      web writes a value the desktop leaves blank
LDR_NAME       41   desktop 'RUPALBEN DODIYA' web ''           denormalised copy not carried
LEDR_KEY        8   desktop ...0000118        web ...0000155   constructed key differs
```

### The ratchet caught the obvious mistake

Measuring the 51-case run against the recorded 66-case ceiling was refused:

```
case set  reduced
REGRESSED 15 case(s) present in the ceiling are absent from this run: wsale-034-00001, …
EXIT=1
```

2,936 is a smaller number than 3,787 and it would have looked like progress. It is not: the 15 rate-cut cases
were simply not compared. The ceiling stays at 66 cases until the rate-cut replay exists.

### The rate-cut family, and the full 66-case loop

The 15 `wsale` cases are book 034 `WH SALES` posting through `rateCut.ts`. `parity-replay-wsale.mjs` replays all
15; 14 reproduce the desktop's `SL_NET_AMT` exactly and one (`wsale-034-00015`) returns 0 against 98,434 — a real
difference now visible rather than hidden.

Its book slots needed the module's own map (`goldAc:1, cashAc:3, kasarAc:4, lbrAc:6, othAc:11`). Two were
assigned from evidence in the desktop's legs:

- **`goldAc` = 00098** — the only account carrying the metal leg (`IT_TYPE 'G'`, DR=CR=0, non-zero `FINE_WT`),
  which is the split-leg structure `rateCut.ts` documents, on every case
- **`cashAc` = 00001** — the only account posted in both directions across the set

The other three have no distinguishing signature on these vouchers, so they are filled from the leftovers and
**logged as unverified**, exactly as the purchase slots were before the comparison validated them.

Both families then had to land in ONE tenant, because a purchase-only extract is a reduced case set and the
ratchet refuses it. `--no-wipe` plus `WHERE NOT EXISTS` guards on the shared masters (books 034 and 035 share
accounts 00001, 00008, 00057) make the wholesale replay compose with the purchase one.

### Result: the loop is closed and the numbers moved

```
                    August bundle    fresh replay      delta
cases matched          0 / 66           0 / 66            -
fieldDifferences        3,787            3,662          -125
rowsMissing               210              180           -30
rowsExtra                 210              193           -17
fieldsCompared         23,574           24,308          +734
agreement              83.94%           84.94%         +1.00pt
```

`fieldsCompared` rising matters as much as `fieldDifferences` falling: the fresh bundle has more rows to compare
because fewer are missing. The ratchet reported four improvements and no regressions on an **identical** case
set, so the ceiling was re-recorded at 66 cases / 3,662 differences.

Release certification: `parity-ratchet` PASS, `passed=11 failed=3 skipped=1 missing=1`.

### What is now true that was not this morning

`pnpm parity:measure` reproduces the parity numbers from a clean database in one command, over all 66 real
desktop vouchers, and CI fails if any of them worsens. The month-long blind spot — where 159 differences' worth of
real fixes sat unmeasured and a regression would have been equally invisible — is closed.

### Remaining beyond Phase 0

1. `wsale-034-00015` returns net 0 against the desktop's 98,434 — the first case-level defect the loop surfaced.
2. Move the derived `PURC_AC`, book display names and rate-cut slot roles into `parity-seed-derive.mjs`, so the
   spec carries them and both replays stay mechanical.
3. Resolve the `OS` item ambiguity: its purchase account differs by book, which the web's item-group resolution
   cannot express.
4. The three unverified rate-cut slots (`kasarAc`, `lbrAc`, `othAc`) need role evidence from a wider capture.
5. Phase 1 of the execution plan: extend the case set beyond these two families, starting with `TR_SALE`, which
   has no cases at all.

## Verification

- `156 test files / 1331 tests` pass (was 155 / 1314; +17 ratchet tests)
- `tsc` clean on api-src, api-test and web; `prettier --check .` clean
- `pnpm parity:measure --reuse` exits 0; regression paths exit 1 as shown above
- release certifier `passed=11 failed=3 skipped=1 missing=1`, with `parity-ratchet` PASS

## What this changes for the work that follows

Every fix from here should move a number that CI watches. A fix that moves no measured number is
indistinguishable from a fix that does nothing — and, as the 1,354 already-repaired differences showed,
indistinguishable from one that was already done.
