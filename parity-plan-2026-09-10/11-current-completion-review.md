# Current implementation and parity review — 11 September 2026

> Subsequent implementation is recorded in [document 14](14-implementation-progress-2026-09-11.md). This review and its source manifest remain the unchanged baseline for that work.

Reviewed against the local working tree on **11 September 2026, Asia/Kolkata**. Machine timestamps use UTC, so the initial captures show 10 September UTC. This review supersedes earlier current-status statements, including the implication that filling the last menu entries completed the implementation plan. There has been substantial implementation progress, but **both functional implementation work and acceptance work remain**.

## What percentage is complete?

| Measure | Current result | What this actually establishes |
| --- | --- | --- |
| Desktop menu entries with a declared web surface | **198/198 = 100%** | Every registered menu entry names a route/page/master/report. Some routes are blocked or cover only part of the desktop workflow. |
| Desktop menu entries certified `verified` | **0/198 = 0%** | No entry currently meets the register's end-to-end evidence bar. This does **not** mean no working code exists. |
| Plan packages accepted with current complete evidence | **0/83 = 0% recorded acceptance** | None has the complete descendant, desktop, browser, report and business evidence required by its acceptance clause. The old 83 `planned` labels were stale tracking, not a measurement of code progress. |
| Fresh legacy scanner field/control ratio | **3,729/5,107 = 73.0%** | An approximate static surface signal only. It is **not 73% functional parity**, and 27% cannot be interpreted as remaining work. |
| Complete working functionality, workflow and richness implementation | **Not yet reliably measurable** | The semantic requirement/transition denominator is not reconciled; no defensible single completion percentage can be calculated from current evidence. |
| Production replacement acceptance | **Not achieved** | Contained operations, incomplete workflows and missing current certification evidence prevent this claim. |

**Use these separate measures in progress reporting. Do not tell the business that full conversion is 100%, 98%, or 73% complete.** The requested working-feature percentage needs a completed requirement inventory and field/transition acceptance evidence first. Inventing weights for phases or averaging test counts would create apparent precision without measuring the requested outcome.

The 73% ratio rose from the dated 52.4% scan. That supports a claim of substantial added surface on the same legacy measurement basis. However, the denominator omits 916 known additional desktop declarations, shared components inflate another reported ratio to 97.6%, aliases confuse setting/recalculation detection, and fields can appear without a complete reader/writer path. Adding the 916 declarations to the denominator would still not repair those semantic mismatches. Neither ratio should be promoted to a functional percentage.

## Checks actually performed in this review

The API build passed. The following audits were rerun against the current tree or explicitly against retained evidence. Logs and source hashes are retained in [the review evidence](evidence/review-2026-09-11/summary.json) and [command results](evidence/review-2026-09-11/checks.json).

| Check | Result | Interpretation |
| --- | --- | --- |
| Register `--strict` | Pass; 198 implemented-unverified | Classifications are structurally valid. |
| Register `--strict --release` | **Fail; all 198 remain unverified** | Whole-menu release acceptance is open. |
| Contract integrity | Pass with debt; 11 contracts, 3 approved, 8 draft | Existing draft debt is permitted by this gate. It does not certify all desktop forms. |
| Contract debt | 28 recorded unenforced rules; 184 missing computed-vector links | These are authored-contract records needing review against current code, not 28 freshly reproduced application defects. |
| Legacy depth audit | 123 page files, 82 transaction pages, 15 SubDetailGrid adoptions | Counts locate investigation work; no formula, workflow or persistence certificate. |
| Dead-cell audit | Fail; four wholesale source-reference fields flagged | **Scanner false-positive candidates:** the page maps these into `isuRef`, and the writer consumes that object. Fix the scanner and verify the real round-trip before changing product behavior. |
| G5 desktop gate | **Fail** | Uses the retained 1 September result; this review did not replay the desktop. |
| Retained parity ratchet | Pass against unchanged evidence | No measured regression in that old artifact; no proof about current changes. |

The retained comparison has **0/70 complete matching cases**, 510 field differences, 153 missing rows, 137 extra rows and 1,701 excluded fields. Its 98.17% agreement among compared fields is not complete workflow parity. The current implementation may already fix some differences; a new independent replay must establish which remain. The most recent retained release record is also dated 1 September and failed. No current report comparison exists at the required report-comparison path.

Earlier implementation-session results reported 1,504 API tests across 196 files, 67 web tests, a web build and 121 route renders. Those were useful engineering checks; they were **not rerun as a full suite here**, were not candidate-bound desktop certification, and excluded two database suites requiring port 55433. This review finds 123 current page files, so the old render count is not current full-route evidence. The current Docker API/web/database health does not establish image/source alignment or parity. Database port 5433 was not used for new mutation tests in this review.

## Concrete gaps and corrections to the previous completion impression

| Finding | Current evidence and business implication | Follow-up |
| --- | --- | --- |
| CR-01: Surface status hides availability | [Containment registry](../web/packages/core/containment.mjs) still blocks tag transfer, cancellation, split, weight difference, logical restore and production loading. Some domain work has advanced beyond the registry's old explanatory text, but the gate still blocks use. | X01, X18–X21, X30–X31; record availability separately from implementation and evidence. |
| CR-02: E CrntNote is a partial screen | [The page](<../web/apps/web/app/(app)/txn/e-crnt-note/page.tsx>) accepts book/voucher and submits IRN only. [TR_SL_EBILL](../unified/src/csharp/DataCareNext/TR_SL_EBILL.cs) also reads, saves and deletes SL_DATA/SL_DETL and has browse/print behavior (around lines 6968, 7459–7720, 7880–8016). Fresh web entry/edit/reopen/print is not covered by the IRN adapter. Do not create credit notes through a normal sale writer without comparing the different effects. | X15; implement the complete E CRNT document lifecycle before treating this menu as functionally delivered. |
| CR-03: Tour Order browser lifecycle and book selection | [The page](<../web/apps/web/app/(app)/txn/tour-order/page.tsx>) has creation and browsing but no form hydration/update flow; its voucher list and print URL use book 510. API lifecycle work exists. A shop using another TOUR ORDER book needs a complete selected-book path. | X14; configured book selection, read/edit/delete, components, scope and print through the browser. |
| CR-04: Order print scope remains incomplete | [orderDoc.ts](../web/apps/api/src/modules/sales/orderDoc.ts) omits location in OrderScope; the detail query also omits year. The `/sales/order-confirmation` adapter does not pass location. Reused voucher numbers can produce an incorrect order document. | X05, X25; require full identity in every document query, with same-number fixtures across locations and years. |
| CR-05: Design child persistence remains absent in this writer | [designBook.ts](../web/apps/api/src/modules/masters/designBook.ts) manages DESIGN_DETL; its input has no child collection and the module has no DESIGN_IDTL persistence. A rich parent grid does not carry design component specifications. | X11; source-backed parent/child/image lifecycle and downstream specification continuity. |
| CR-06: Lot manufacturing remains only partially represented | [mfg.ts](../web/apps/api/src/modules/manufacturing/mfg.ts) has issue/receive, lot fields and `mfgLotBalance`; the searched route/page set has no dedicated TR_MFG_WITH_LOT operator path. `GET /reports/mfg-lot-isurec` is a report, not the material issue/receipt workflow. Confirm all callers before implementing the dedicated mode. | X23; contract, source selection, partial receipts, losses, reversal and report reconciliation. |
| CR-07: Report binder still lacks real child datasets | [reportBind.ts](../web/apps/api/src/modules/reports/reportBind.ts) has six inferred table families. It aliases values from parent detail rows under IDTL names instead of fetching actual IDTL children. The unsafe sales fallback was removed, but this does not complete component/subreport binding or all report families. | X25–X26; explicit template contracts, real child queries, dataset comparison, Crystal/physical output. |
| CR-08: Full-stack workflow evidence is missing | [browser smoke](../web/apps/web/test/browser.smoke.mjs) and [route coverage](../web/apps/web/test/route-coverage.mjs) start with API_ORIGIN pointing at an unavailable port and fulfill API responses in Playwright. Dynamic masters/reports use sample segment values. | X03, X33; real authentication/API/database journeys and an expanded expected mode set. Keep mock tests for their narrower purpose. |
| CR-09: Measurement defects persist | [Dead-cell checker](../web/scripts/check-dead-cells.mjs) iterates a hard-coded 20-page map, despite claiming to discover unmapped pages; nested wholesale mapping causes four alerts. Depth reports zero recalc adoption and simplistic setting consumer counts despite shared helpers in current code. | X02; independent discovery, route-specific nested mappings, negative controls and unresolved inventory errors. |
| CR-10: Contract coverage and formula proof remain incomplete | Only 11 authored contracts remain; eight are drafts, with the debt above. A few approved contract documents do not certify those families on the current build. | X01, X04, X06; expand all source/mode/decision leaves and rerun independent comparisons. |
| CR-11: Company/book switching needs lifecycle verification | [BookSelect](../web/apps/web/components/BookSelect.tsx) fetches books based on filter/preferred props; company/location/year are not explicit effect dependencies. Whether its caller remounts it on every scope transition is not established here. | X09; test in-place scope change and multiple tabs, then correct component/caller invalidation where needed. This is a risk to verify, not a reproduced cross-company event. |
| CR-12: Delivery workflows are not in the Git repository workflow directory | `git rev-parse --show-toplevel` returns `imodule-extracted`. CI/release YAML is under `web/.github/workflows`; root `.github/workflows` currently contains the report extractor workflow. Merely writing nested YAML does not activate that CI in this repository layout. | X34; move/adapt workflows, verify actual remote check execution and evidence retrieval. |
| CR-13: Release gate set is narrower than the plan | [Certification module](../web/apps/api/src/modules/ops/releaseCertification.ts) checks the declared gate-ID set, but the report predicate accepts a nonempty collection of passing supplied reports without the complete required report/mode IDs. The runner accepts a supplied SHA without a local tree check. No dedicated real-browser, hardware, migration-continuation or UAT gate appears in the current 17-item declaration. | X34; exact required leaf/case sets, missing-case rejection, source/build hashes and every required evidence family. |
| CR-14: Production and offline equivalence remain open | Six containments remain; no current successful whole-product certificate or complete report evidence. The required internet-independent business topology, real device/provider acceptance, multi-business migration continuation and timed recovery remain unaccepted. | X28–X34. Local Docker health alone closes none of these. |

## Existing work that should be reused

The current tree contains purchase/sales quotations, bullion/old-item sales, stock in/out, loans, scheme gold adjustment, tour orders, credit-note IRN handling, additional reports and utilities. Rate-cut receiving now has RATE_CUT_REC persistence and lifecycle work. Shared subdetail editing and several tender/header/line paths have been expanded. Report binding rejects an unknown family and uses stronger scope for its supported path. These are implementation gains; the original descriptions of those pieces as entirely missing are historical.

The follow-up plan therefore starts with **reusing and verifying these implementations**, not recreating them. It also avoids claiming that all other gaps are only paperwork: E CrntNote entry, Tour Order browser editing, design components, report children, lot workflows and contained operations are concrete outstanding implementation obligations.

## Phase-level current position

| Phase | Current position | Remaining closure |
| --- | --- | --- |
| P00 | Inventory and tooling exist; incomplete semantic coverage and independent environment evidence | X01–X04, X34 |
| P01 | Posting, scope, lifecycle and numerical helpers exist with substantial tests | X04–X06; all branches, exact effects, conflicts, retries and desktop replay |
| P02 | Grids, keyboard, subdetails and settings consumers expanded | X07–X09; variant-specific calculations, settings effects and session/outage behavior |
| P03 | Master screens and rich design parents exist | X10–X11; design children, provisioning and real configured-shop validation |
| P04 | Purchase families/quotations/returns and settlement implemented to varying depth | X12; every variant and supplier journey |
| P05 | Major sales/order/custody paths exist; explicit screen/conversion gaps remain | X13–X15, X17; rich lifecycle and connected journeys |
| P06 | Finance/rate-cut receiving/bullion work exists | X16; two-sided calculations, allocation, identity and closing |
| P07 | Stock foundation and opening work exist; four tag workflows blocked | X18–X22; exact identity, component/image preservation and separate release evidence |
| P08 | Manufacturing helpers, lot fields and lifecycle tests exist | X23; complete lot/operator/stage journeys and conservation |
| P09 | Dhiran, loan and scheme families extended | X24; historical, maturity/redemption, interest and custody comparisons |
| P10 | Many report endpoints added; fallback fixed; output equivalence incomplete | X25–X26; actual children, all modes, data/layout/physical output |
| P11 | Utilities and adapters exist; operational acceptance remains partial | X27–X29; correction/reference closure, providers/devices, lifecycle jobs and roles |
| P12 | Migration/recovery/deployment scaffolding exists; loading/restore contained | X30–X31; complete scoped loading, continued historic business, recovery/topology |
| P13 | Source/edition deltas inventoried; semantic/runtime disposition unfinished | X32; geography, companions, missing artifacts and reachable variants |
| P14 | Certification scaffolding exists; all-product acceptance open | X33–X34 and all descendants; exact-set release, UAT, cutover and stabilization |

## How a real percentage will be calculated

X01/X02/X04 must establish a versioned set of **semantic leaf requirements and mandatory transitions**, mapped to every source item, mode and cross-module journey. A field repeated in several modes gets separate obligations where behavior differs. Source-backed duplicates can share an implementation while retaining their coverage links. Hidden identities, derived values, reports and error transitions are included.

Publish five counts against that declared set: implemented with a complete path, engineering-verified, independently desktop-matched, business-accepted, and production-certified. For each stage use `100 × requirements satisfying that stage / all required requirements`. Show requirement and journey coverage separately; never infer one from the other. Missing evidence remains open. Newly discovered requirements expand the denominator and reopen affected parents. If inventory closure is incomplete, display **percentage unavailable**, together with discovered counts and unresolved coverage, instead of a false whole-product percentage.

No extra percentage is assigned merely for creating the updated plan. The new [execution addendum](12-execution-addendum.md) and [machine backlog](13-execution-backlog.json) turn this review into concrete remaining work; they do not certify that work.
