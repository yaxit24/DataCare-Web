# Datagenex / DataCareNext: complete desktop-to-web parity plan

## Start here for current implementation status

Updated **12 September 2026, round 15 status review — implementation paused**: menu mapping is **198/198 (100%)**, verified menu closure is **0/198 (0%)**, and the true full-feature/workflow implementation percentage remains unmeasured. The latest retained field/control surface audit is **72.1%** (Round 14); the older **73%** review ratio is historical. Neither measures functional parity. Substantial code is present, but both implementation and acceptance work remain.

- [X15 E CRNT lifecycle, 29 September 2026](44-implementation-progress-x15-2026-09-29.md): E Credit Note create/edit/delete/print/IRN-cancel through core arithmetic, a dedicated writer, HTTP and UI; full API/core/web suites and all 18 real-browser journeys passed. X15 stays open pending desktop comparison, business acceptance of six documented adaptations and live provider state.
- [Current Round15 in-progress status](42-implementation-progress-round15.md): pure c27 replay, effect storage context, seven-row financial planning, Save guards and shared composition. Actual core26files/1613cases and strict five-test-file compilation passed. The remaining16 recipe checks have not run; checkpoint43 is not sealed. Numeric saves and known closing remain disabled. The document records all34 remaining-gap areas and the complete next-write sequence.
- [Sealed Round14 continuation](40-implementation-progress-round14.md) and [latest sealed checkpoint41](41-implementation-checkpoint-round14.json): incoming Save mapping, exact header Float qualification, N BAR companion matching and internal Serializable Return Update coordination. Its completed verification applies to its own frozen inputs, before Round15. All34 cards,83 packages and198 whole-menu acceptances remain open.
- [Round 13 continuation](38-implementation-progress-round13.md) and [checkpoint 39](39-implementation-checkpoint-round13.json): historical session/browser, Sales/Tour and saved Return labour-preview integration, with the Round 14 dependency-coverage erratum retained separately.
- [Round-12 verification record](37-implementation-checkpoint-round12.json): source, artifact and check identities for these bounded prerequisites; it does not close full-product acceptance.
- [Round-11 saved bill preview](34-implementation-progress-round11.md) and [checkpoint35](35-implementation-checkpoint-round11.json): preserved integration and historical verification.
- [Round-10 prerequisite implementation](32-implementation-progress-round10.md): pure incoming running totals and stateful bill/tax calculations, before the Round11 integration.
- [Round-9 verified integration](30-implementation-progress-round9.md): saved Incoming Return calculation preview, ordered source events, read-only empty headers and final verification; full numeric workflows remain open.
- [Round-8 verified implementation](28-implementation-progress-round8.md): incoming Return configuration and complete column-setting identity.
- [Round-6 implementation](24-implementation-progress-round6.md): exact saved incoming values and bounded versioned metadata edits.
- [Round-10 immutable checkpoint](33-implementation-checkpoint-round10.json):415 core tests,227 web tests, production build and lint; historical pure aggregate/bill/tax prerequisite verification before API/UI integration.
- [Round-9 immutable integration checkpoint](31-implementation-checkpoint-round9.json):235 API files/2115 tests,264 core tests,227 web tests and15 real browser journeys; all full-product acceptance remains open.
- [Round-8 immutable checkpoint](29-implementation-checkpoint-round8.json): 231 API files/2023 tests, 211 core tests, 195 web tests and 14 real browser journeys; complete desktop acceptance remains open.
- [Round-7 immutable checkpoint](27-implementation-checkpoint-round7.json):225 API files/1824 tests,211 core tests,168 web tests and13 real browser journeys; all full-product acceptance remains open.
- [Round-6 immutable checkpoint](25-implementation-checkpoint-round6.json):223 API files/1776 tests,168 web tests and13 real browser journeys; full product acceptance remains open.
- [Round-5 immutable checkpoint](23-implementation-checkpoint-round5.json): shared Design/tag/master and original Repair image concurrency, 1740 API tests and12 live browser journeys; round6 has its own verification.
- [Round-4 immutable checkpoint](21-implementation-checkpoint-round4.json): configured Sales lifecycle, verified Design selection, imported-value preservation and saved-order photo concurrency.
- [Round-3 immutable checkpoint](19-implementation-checkpoint-round3.json): captured source/evidence identities, 1,674 API tests, seven actual-browser journeys and retained open gates.
- [Round-2 immutable checkpoint](17-implementation-checkpoint-round2.json): final source/evidence hashes, 1,630 API tests, real browser verification and preserved open gates.

- [Historical completion-review baseline](11-current-completion-review.md): retained scope and acceptance findings; document42 is the current paused status. Latest retained static surface proxy is72.1% (Round14), not functional completion; the older73% review proxy is historical.
- [Detailed execution continuation](12-execution-addendum.md): 34 cards, file-level steps, fixture packs, failure cases and evidence requirements covering every original package.
- [Structured execution backlog](13-execution-backlog.json): dependencies and acceptance for those cards.
- [Updated main implementation plan](02-implementation-plan.md) and [83 package records](07-work-items.json): mandatory parent requirements and current open acceptance links.
- [Fresh review evidence](evidence/review-2026-09-11/summary.json): static observations and explicitly dated retained comparisons.

This status update passed [documentation and backlog coverage checks](evidence/status-review-2026-09-12/document-validation.json) and [web documentation references](evidence/status-review-2026-09-12/docs-refs.txt). The [current status observations](evidence/status-review-2026-09-12/current-status.json) retain the evidence limits. The full `validate_current_review.py` checkpoint validation is still pending for Round 15: checkpoint 43 is absent and the current tree has advanced beyond sealed checkpoint 41. Do not report that full checkpoint validator as passed, weaken its required checks, or rewrite the historical checkpoint to absorb this status update.

The original review and inventories below remain dated history. Implementation acceptance is governed by documents 02/03 plus the current 11/12/13 continuation; scanner-derived historical claims do not override them.

Prepared **10 September 2026** against `/Users/yakshitsavaliya/Desktop/imodule-extracted`.

**The web has substantial reusable functionality, but complete desktop parity and production readiness are not established.** Finishing this requires field-level and workflow-level closure across the application, followed by independent desktop comparisons, business acceptance, hardware validation and migration rehearsals. Adding pages or passing the existing unit tests cannot establish that outcome.

The extracted product is named **DataCareNext** in the executable, source and repository. This plan treats that as the desktop application called Datagenex in the request. `NextDm.exe` and supporting utilities are included in the scope-reconciliation work; they must not silently disappear from consideration.

## Read these in order

1. [Current state, confirmed gaps and evidence limits](01-current-state-and-gaps.md) — findings from the current working tree, corrections to previous audits, and checks actually run.
2. [Detailed implementation plan](02-implementation-plan.md) — 15 phases and 83 work packages with dependencies, implementation locations and acceptance criteria.
3. [Verification, scenarios and production release](03-verification-and-release.md) — 128 business scenario anchors, an 18-case per-form matrix, test layers, invariants, migration, recovery and release gates.
4. [All 204 desktop source units](04-form-register.md) — candidate web mappings, every named desktop grid, event handlers and closure obligations.
5. [All 198 menu entries, 275 report references and 146 table units](05-menu-report-data-register.md) — full retained inventories with current file-presence checks.
6. [Settings and API reachability register](06-settings-api-register.md) — all 130 scanned settings, typed-alias consumer leads and the remaining API-only operator-field candidates.
7. [Machine-readable work packages](07-work-items.json) — dependencies, ownership, acceptance and current planning status.
8. [Detailed plan re-verification](08-plan-reverification.md) — whether completing the plan can establish full parity, new coverage findings and strengthened completion rules.
9. [Additional source register](09-additional-source-register.md) — 916 missed input declarations across 143 source units and eight assembly support files.
10. [Plan coverage obligations](10-plan-coverage-obligations.json) — domain/work-item/scenario/release-gate links, all still planned.

The [evidence directory](evidence/) contains fresh scanner outputs, check results, a source hash manifest, full form/report/table registers and **3,508 named-grid requirement records**, plus input-control and event-handler indexes. These records deliberately start unverified. They are the beginning of field-by-field sign-off, not a claim that every field has already been manually audited.

## What the initial review establishes

- API and web typechecks passed. **51 web tests and 17 core tests passed.** These are limited engineering checks.
- The source scanner sees 2,677 web field/column occurrences against 5,107 desktop occurrences on its distinct-file basis. This **52.4% is a heuristic surface ratio, not a functional completion percentage**. Re-verification found 916 additional desktop input declarations missed by that scanner, so its denominator is also incomplete. The original ratios are retained only as dated scanner output.
- The most recent retained desktop comparison, dated 1 September, has **0 matching complete cases out of 70**, with 510 field differences, 153 missing rows and 137 extra rows. This review reran the gate against that artifact; it did not replay the applications.
- Confirmed remaining work includes lot manufacturing, rate-cut receiving, design component persistence, several tag operations, full report binding, settings effects and complete business workflows.
- Prior “absent” and “done” labels are inconsistent with current code. The plan replaces percentage-driven completion with evidence per requirement and business journey.

## Completion promise

The implementation is complete only when every required full-product desktop requirement has a working web path, its calculations and persisted business effects match independently captured desktop evidence, every required journey passes through the real browser/API/database, and production operations pass their release gates. No required field, menu variant, report, device workflow or migration table may remain missing, contained, skipped or unverified. The outage/service model must preserve the required operational capability; a limited pilot or an explicitly narrower service cannot be called whole-product parity. Completing 83 packages is insufficient unless all discovered descendant requirements and exact required test sets also pass.

This planning package accompanies the ongoing implementation. Its checkpoints distinguish tested application changes from outstanding desktop/business acceptance. Existing uncommitted work is preserved; customer migration and production certification remain separate requirements.
