# DataCare Web — master desktop parity implementation plan

Prepared 29 September 2026. Application baseline: `03148fef5899224b8c4c9805ca07161a920efeb1` in `yaxit24/DataCare-Web`. This is a planning and current-state analysis change; it does not implement or certify the remaining application work.

**The existing web application is a substantial implementation, but it is not yet established as a complete replacement for the desktop product.** Preserve it and finish the missing behavior, then independently verify each complete business path. Do not restart the application or reorganize the preserved desktop extraction.

This package is the new entry point for planning. It supplements all original requirements in `parity-plan-2026-09-10/`; it does not erase the 83 packages, 34 continuation cards, source inventories, or historical evidence. Where current source contradicts old status prose, the correction in this package governs the planning assessment. Historical checkpoints still describe only their original inputs.

## Read and execute

| Document | Purpose |
|---|---|
| [Current assessment](01-current-assessment.md) | What is present, what is incomplete, newly run checks, and limits of the evidence |
| [Execution plan](02-execution-plan.md) | Dependency order, work waves, concrete first backlog, owners and exit gates |
| [Shared implementation contracts](03-shared-contracts.md) | Identity, calculations, posting, forms, settings, sessions, reports, integrations and operations |
| [Step-by-step verification](04-verification-playbook.md) | Per-feature tests, complete business journeys, migration rehearsals and release criteria |
| [Desktop reference logic](05-desktop-reference.md) | Canonical desktop paths, symbols, business logic and cross-module side effects |
| [Module implementation detail](06-module-detail.md) | Actual web implementation, gaps, target files, module-specific implementation and test work |
| [Previous-plan reconciliation](07-previous-plan-reconciliation.md) | How much of previous plans is accepted; all 83 original package dispositions |
| [Decisions, delivery and acceptance](08-decisions-and-delivery.md) | Web adaptations, unresolved evidence, milestones, operational acceptance and handover |
| [Retained surface register](09-surface-register.md) | Every enumerated retained desktop source unit, menu mapping, report reference, table and setting, with work routing; semantic discovery remains open |
| [Gap register and amendment, 1 October 2026](10-gap-register-2026-10-01.md) | Current-state corrections after X15/X16/N18/N19 and the audited gaps G01–G18 with their new slices N31–N46 |
| [Audit implementation plan, 1 October 2026](11-audit-implementation-plan-2026-10-01.md) | Full-stack audit results; gaps G20–G66, decisions D15–D22 and implementable slices N47–N82 with steps, tests and acceptance; status corrections; execution order |
| [Machine-readable execution backlog](execution-backlog.json) | Original packages, continuation cards, current evidence and new ordered slices |
| [Requirement index](requirement-index.json) | Stable references to all retained grid, control, event, source, report, table, setting and menu records |
| [Verification observations](evidence/verification-observations.json) | Commands actually run for this analysis, separate from future acceptance tests |
| [Plan integrity validator](validate_plan.py) | Read-only validation of record coverage, source hashes, dependency graph, module/journey coverage and test-log integrity |

The depth of this plan is the combination of these documents **and their explicitly incorporated source registers**. Every field, branch, menu alias and report mode must receive the contract in document 03 and proof in document 04. The pre-existing registers retain literal labels, source lines, event names and suggested routes; they are not placeholders to discard after the headline modules are implemented. The requirement index keeps those records discoverable without copying thousands of unreviewed facts into prose.

Run `python3 docs/master-parity-plan-2026-09-29/validate_plan.py` in the full repository to recheck the package. The index preserves **12,822 raw records**, including overlaps and infrastructure, not 12,822 independently established features. It includes 130 setting records with 128 distinct labels; duplicate labels retain source-row identity for semantic review. The validator's pass certifies planning integrity only.

## Current progress, stated accurately

| Measure | Result at this review | Interpretation |
|---|---:|---|
| Declared desktop menu mappings | 198 / 198 | A mapping can point at a partial or read-only path |
| Whole-menu acceptances recorded as verified | 0 / 198 | No complete menu has a closed acceptance record; this is not zero working code |
| Original packages with full acceptance closed | 0 / 83 | All retain open descendant requirements |
| Continuation cards with full acceptance closed | 0 / 34 | Existing bounded implementations are reusable |
| Latest retained field/control proxy | 3,681 / 5,107 = 72.1% | Dated Round14 static heuristic, not a functional percentage |
| Reliable full-product functional percentage | Not established | The semantic and transition denominator still needs closure |

The new saved-return calculation path remains diagnostic, but legacy return creation still exists. Do not generalize its `canCommit:false` into a claim that every sales-return write is blocked. Lot Setting issue/receipt is read-only.

**Amendment, 1 October 2026 (document 10).** Since this package's baseline, `main` gained the E Credit Note / E Invoice lifecycle (X15), the D1–D6 evaluation fixes, the rebuilt wholesale/rate-cut form (X16) and the tag cancel, transfer and split operations (N18/N19). The containment registry now holds **three** operations: logical restore, production cutover load and tag weight difference. These are engineering results; every acceptance count above is unchanged. Document 10 adds eighteen audited gaps (G01–G18) and slices N31–N46, which are executed before the remaining programme slices.

**Second amendment, 1 October 2026 (document 11).** A full-stack audit ran the current application on an isolated database, drove it in a real browser, crawled all 239 routes and compared it with the desktop databases. The core retail cycle works on a fresh web company, but the audit found red gates, request crashes, missing concurrency and idempotency controls, printed dates without the year, empty final statements, provisioning and identity conventions that differ from the desktop, incomplete lifecycles and template coverage, no migration path and no production hardening. Document 11 records gaps G20–G66 and decisions D15–D22, converts them into slices N47–N82 with file-level steps, tests and acceptance, corrects the status of ten slices that landed since document 10, and fixes the execution order (phases A–F). Acceptance counts are unchanged.

## Definition of the finished product

A trained desktop operator can complete every required business journey in the web application, using the same business meaning, supported configuration branches, calculations, validations, records, stock/custody movements, accounting effects, reports and document outputs. Suitable web interaction may differ, but omitted behavior is not a web adaptation.

Completion requires all of the following together:

1. Every reachable capability and discovered descendant requirement has a disposition and working implementation.
2. Independent desktop comparisons pass for field values, action order, full persisted effects, reopen/edit/delete behavior, reports and printing.
3. Real browser/API/database journeys pass, including permissions, competing operators, failure recovery and historical records.
4. Representative business users accept normal and exception workflows and measured operator efficiency.
5. Migration, backup/restore, continuity, deployment and rollback are rehearsed against the release candidate.
6. The release certificate binds the exact code, dependency lock, schema, settings, templates, requirement set and evidence. No required item is missing, contained, skipped or inferred complete from a page count.

The plan makes these criteria actionable; it is not a promise that unmeasured desktop behavior has already been discovered. New findings become child requirements and keep their parents open. A smaller pilot may be useful, but cannot be called completion of this full-product request.
