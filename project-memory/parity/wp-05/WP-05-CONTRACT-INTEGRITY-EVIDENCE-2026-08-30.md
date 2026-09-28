# WP-05 contract integrity evidence

**Date:** 2026-08-30
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package:** WP-05 — complete source contracts and decisioned divergences (P1-07)
**Status:** enforcement implemented and validated; **WP-05 is NOT closed** — 8 contracts remain drafts and approval is an owner act
**Claim boundary:** this makes the contracts checkable and corrects their measured state. It approves nothing, authors no new rules, and fills no vector cell.

## 1. What was wrong

The contracts are the project's declared source of truth **above** the code (plan §2: "approved behavior contracts; drafts are research, not approval"). Nothing checked them:

- A draft carrying 33 blank vector cells could be flipped to `Status: approved` and would immediately count as G2 evidence. The only "gate" was a review checklist of unticked Markdown boxes.
- A rule could cite a desktop line that does not exist, or a golden vector nobody wrote. Either looks exactly like evidence.
- The stated debt figures were partly wrong, because the two table shapes in use were being parsed as one.

## 2. Measurement corrections

The plan records "30 NOT ENFORCED validations and 184 blank golden-vector cells". Re-measured against current code:

| Figure                | Plan / prior | Measured now | Why it changed                                                                                       |
| --------------------- | -----------: | -----------: | ---------------------------------------------------------------------------------------------------- |
| NOT ENFORCED          |           30 |       **28** | Two rows were **stale**: `You Cant Adjust Negative West % Please Change West %...` is thrown by current code |
| Blank vector cells    |          184 |      **184** | Confirmed                                                                                            |
| Blank test cells      |           37 |        **0** | All 37 are `WAIVED`/`UI-LEVEL` rows that carry a reason — the contracts' own accepted discipline       |
| Validation rows       |          283 |       **37** | The prior count included computed-field rows; there are 37 validations and 248 computed cells         |

The validation rows break down as **28 NOT ENFORCED, 5 WAIVED, 2 UI-LEVEL, 2 ENFORCED**. Zero rows have a positive status and no test, which is why `blankTest` is genuinely 0 rather than hidden.

A near-miss worth recording: a third message, `Please Check Len Connection...You Cant Save Image...`, appears in web source **only inside a comment stating it is waived**. It stays NOT ENFORCED. This is precisely the trap the completion register warns about — "a form named in a comment is not implemented" — and it is why enforcement claims must cite a use site rather than a match.

## 3. What was built

`apps/api/src/modules/ops/contractIntegrity.ts` — pure, unit-tested audit logic. `scripts/check-contracts.mjs` gathers facts and delegates every decision, the same split the release certifier uses.

The desktop sources are present in this workspace (204 files), so **citations are verifiable**: `TR_MLT_PRO.contract.md` claims 5,243 lines and the file has exactly 5,243.

Blocking rules:

| Rule                              | What it refuses                                                      |
| --------------------------------- | -------------------------------------------------------------------- |
| `filename`, `desktop-form-exists` | a contract not named for a real desktop form                          |
| `status-line`                     | missing or duplicated `Status:` line (README rule 3)                  |
| `citation-resolves`               | `FORM.cs:LINE` where the file is absent or the line is out of range   |
| `vector-exists`                   | a `GV-*` id no golden vector defines                                  |
| `approved-has-no-unenforced-rule` | approval while a desktop validation is unenforced                     |
| `approved-has-no-blank-vector`    | approval while a computed cell has no vector                          |
| `approved-asserts-something`      | approval of a document containing no rule at all                      |
| `waiver-carries-reason`           | a waiver with no reason (README rule 5)                              |
| `authored-rule-cites-source`      | a hand-authored rule row with a blank citation (README rule 2)        |
| `debt-ratchet`                    | any rise in NOT ENFORCED, blank vector or blank test totals           |

Two rules had to be made *more* correct after the gate's first run reported the reference approved contracts as defective:

1. **Blank Test is only open when a test is possible.** The contracts' rule is "implemented + test **or** waived with a reason", and a licence-tier gate or an MDI lifecycle notice has nothing for an API test to assert. Waived rows must carry the reason instead — enforced by `waiver-carries-reason`. Demanding a test from them would have taught everyone to ignore the gate.
2. **Shorthand citations are citations.** Hand-authored contracts name the file once and then cite `` `:4207` ``. Reading only the full form skipped 10 of the 12 citations the reference contract relies on most; the parser now resolves the shorthand against the contract's own form.

## 4. Exit evidence

`apps/api/test/contractIntegrity.test.ts` — 17 tests: each rule proved with a synthetic contract (including the negative cases — a waiver *with* a reason must pass, a valid citation must pass), then the rules run against the 11 real contracts and 204 real desktop sources.

Gate result:

```
contracts: 11 (3 approved, 8 draft) | desktop sources: 204 | golden vectors: 27
totals: notEnforced=28, computed=248, blankVector=184, blankTest=0, citations=12
CONTRACTS_OK every citation resolves, every cited vector exists, and no contract claims
             approval while carrying open cells (17 draft debt lines recorded)
```

All 12 desktop line citations resolve. All cited vector ids exist. No approved contract hides an open cell.

Commands: full suite **152 files / 1280 tests passing**; `tsc` clean for api source, api tests and web; `prettier --check` clean. `contract-integrity` added to `RELEASE_GATES` and reads **PASS** in the release certifier (now `passed=9`).

## 5. A finding for the contract owner

Two of the three contracts the plan counts as approved — `TR_PURC` and `TR_SALE` — carry **no resolvable `FORM.cs:LINE` citation at all**. They are generated summaries promoted to `approved`; their rows cite the desktop by verbatim message text and exact grid cell id (`mSG_TOT[29]`), which is traceable but is not the line reference README rule 2 asks for. Only the hand-authored `TR_MLT_PRO` cites lines.

Recorded as **debt, not blocking**, deliberately. The substance is present — the generator read the desktop and the message is quoted verbatim — so the gap is the citation *form*, and retroactively invalidating an owner's approval over form is not a gate's decision. The owner can add line references or amend the README; the gate now says which it is.

## 6. 99 vector links are queued, and none applied

`--candidates` derives, from the approved contracts alone, the mapping *(control name, persisted column) → vector id*. **99 of the 184 blank cells match an approved mapping exactly on both fields** — 54% of the vector debt, dominated by `GV-TOTALS-001` (50 totals-grid column sums), `GV-STONE-001` (16), `GV-PRLINE-*` (17), `GV-SLDETL-001` (6). A further 38 match on control name only and are excluded as too weak.

**None were written into the drafts, and that restraint is the point.** A filled Vector cell asserts "a golden vector pins this formula". Two forms can name a control `cNetWt` and persist `ITM_NWT` while computing from different grid cells — `MSG[14]` in the sale, `MSG[16]` in the tag opening — and `CALC-AUDIT.json` records cell identity but **not the desktop expression**, so equality cannot be established from the retained artefacts. Transcribing the ids would convert 99 visibly-open cells into false passes, which is strictly worse than a blank: the gate exists so blanks cannot be faked, and it would be absurd for its author to fake them.

Each candidate must be confirmed against `unified/src/csharp/DataCareNext/<FORM>.cs`, the only place the expression exists. The report names the control, column, vector and the approved contract the mapping came from, so that confirmation is a reading task rather than a search.

## 7. What remains for WP-05

- 28 NOT ENFORCED validations to implement with verbatim wording, or waive with a reason.
- 184 vector cells: 99 with a confirmable precedent, 85 needing fresh desktop reading.
- 8 contracts to reach `Status: approved` — an **owner act** (README rule 3), which is why this work package cannot be closed by a classifier any more than WP-04 could exclude scope on the owner's behalf.
- Contracts exist for 11 desktop forms. WP-04 established the real denominator: 198 menu entries over 112 distinct forms, so contract coverage is 11 of 112 forms. WP-05's own exit criterion ("every in-scope menu action has an approved contract") is a far larger scope than the 11 retained drafts suggest, and the register's `sharedSurfaceWith` data now says which entries collapse onto one surface and therefore need mode-by-mode contract treatment first.

## 8. Files

- `web/apps/api/src/modules/ops/contractIntegrity.ts` (new)
- `web/scripts/check-contracts.mjs` (new)
- `web/apps/api/test/contractIntegrity.test.ts` (new)
- `web/apps/api/src/modules/ops/releaseCertification.ts` — `contract-integrity` gate added
- `project-memory/contracts/TR_TOUR_SALE.contract.md`, `TR_WH_SALE.contract.md` — stale NOT ENFORCED row corrected with implementation and test citations
