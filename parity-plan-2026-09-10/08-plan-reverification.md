# Detailed re-verification of the complete conversion plan

> Historical review of 10 September. For the 11 September implementation status and remaining concrete work, read [the current review](11-current-completion-review.md) and [execution continuation](12-execution-addendum.md). The earlier counts and absence statements below are retained as dated evidence, not current completion claims.

Rechecked **10 September 2026** in response to the request to verify whether implementing this plan will make the web application a complete desktop replacement.

## Verdict

**The strengthened plan targets complete functional and operational replacement of the primary desktop product. Completing its coding tasks alone does not establish parity.** Completion must include the discovery tasks, every resulting field/action/branch requirement, independent desktop comparisons, real browser/database journeys, business acceptance and all release gates. If those obligations pass for the agreed product version and operating configurations, there is evidence to accept the web as the desktop replacement for that baseline.

An unconditional promise that the written plan already captures every business rule would be inaccurate. Only 11 authored contract files currently exist; thousands of candidate controls and actions remain unverified, and this recheck found omissions in the original source scanner. Live observation is still needed to resolve dynamically selected behaviour, absent reports, device interactions and edition differences. The plan now explicitly requires discovery to expand the backlog and keeps delivery open until those findings are resolved. Unknowns cannot disappear merely because all 83 package headings have been implemented.

This is a re-verification and strengthening of the **plan**, not a new runtime certificate. No business application code, customer database or release containment was changed.

## What was rechecked

The review reread all 15 phases and 83 work packages, the per-form verification contract, scenario catalog, release rules and machine-readable backlog. It checked these against the frozen form/control/event/menu/report/table/settings registers, original extractor code, primary assembly file inventory and selected desktop behaviour that exposed coverage risks. It also checked how early discovery dependencies differ from final acceptance dependencies.

The review did not independently execute all desktop forms or replay the web against a live database. The earlier retained desktop comparison remains a dated artifact: 70 cases, zero fully matching cases and 510 field differences. Its failure proves that the retained comparison does not establish parity; it is not a fresh measurement of every current web feature. Likewise, the 68 focused tests and typechecks reported in the initial review are not new runtime results from this follow-up.

Reproducible supplementary evidence is in [the source check](evidence/reverification-source-check.json), [additional control candidates](evidence/additional-control-candidates.json), [supporting source register](evidence/supporting-source-register.json) and [capture script](capture_reverification.py). Original scanner evidence remains unchanged.

## Findings that changed the plan

| ID | Weakness in the previous plan/evidence | Strengthening now required | Implementation and verification |
| --- | --- | --- | --- |
| RV-01 | “In scope” and exclusion wording could allow a subset release to be mistaken for the complete product | All reachable primary-product capabilities are required by default, including country/book variants and relied-on companion functions; a pilot is a separate subset result | P00-01, P13-01, P14-03/06; OPS-20; R00/R11/R12 |
| RV-02 | The original declaration parser missed 916 input declarations in 143 source units | Add a separate source register; merge and classify both inventories; test declaration modifiers and rendered control trees; retain old counts only as heuristic history | P00-01/03/05; SET-11; R00/R01/R13 |
| RV-03 | The 204-unit directory and event-name list are not the complete execution contract | Include eight supporting C# files, dependency/caller graphs, constructor modes, async/non-void helpers, startup/timers and all internal business branches; resolve 43 grid entries without literal line matches | P00-01/05, P11-05, P13-02/03; SET-11/12, OPS-22; R00/R01 |
| RV-04 | Offline posting was described as optional despite the desktop's internet-independent operating model | Require an explicit service/connectivity matrix and topology decision; preserve the required ordinary business operations during the agreed outages; any reduced service must be explicitly disclosed | P02-06, P11-02/03, P12-04/05; OPS-16/21; R10/R11 |
| RV-05 | Migration acceptance emphasized row reconciliation more than subsequent use of imported business | Return, settle, consume, deliver, redeem, edit where allowed and reverse against migrated historic and partially completed records; preserve historical rules while applying the right effective rules to new work | P12-03 and affected domain packages; FLOW-07; R03/R04/R09 |
| RV-06 | Generic ergonomics/printing coverage left multi-form work and lifecycle details insufficiently explicit | Preserve an unfinished invoice while consulting related forms; test context isolation, print copy/preview/cancel/default selection, user preferences and scheduled action ownership | P02-04/06, P10-05, P11-05; SET-12, RPT-10, OPS-17/22; R03/R05/R08/R12 |
| RV-07 | “All tests passed” could still mean all returned results passed while required cases were missing | Freeze required requirement/case/table/field/report/device sets first; reject missing, duplicate, skipped, unexpected or invalidly empty results; parent tasks close only after all descendants and cross-module obligations | P00-05, P14-01/02; OPS-18; R00/R01/R13 |
| RV-08 | Candidate provenance needed explicit dependency invalidation and a stricter difference policy | Reopen affected acceptance after shared source/configuration/schema/template changes; distinguish technical representation mapping, deliberate business changes and missing capability | P14-02/03/06; OPS-19/20; R04/R11/R13 |

These findings are **addressed in the specification**. Their runtime implementations and acceptance evidence remain outstanding. Updating a requirement does not fix the underlying application.

## The newly measured inventory gap

The original scanner's declaration regex expects an access modifier immediately followed by a type and field name. It does not accept an intervening modifier such as `virtual`. The supplemental check searches recognized input types with these modifiers and subtracts the original control identities.

It found **916 additional declaration candidates across 143 primary source units**. Together with the original 1,599 records, there are now 2,515 input declaration candidates in these two indexes. This is not an exhaustive count of semantic fields: visibility, calculated/hidden status, duplicate controls, inherited/resource-driven elements and further parser gaps still need interpretation. It is also not a newly measured web completion percentage.

A concrete example is [MS_PRINT.cs](../unified/src/csharp/DataCareNext/MS_PRINT.cs): the original form register reports zero inputs, while source lines 130, 148 and 166 declare the original, duplicate and triplicate checkboxes. The load and print/view handlers use them to set caller-visible print choices. This proves why the UI denominator cannot be trusted as a completeness certificate.

The full primary C# tree contains **212 files**, while the main namespace register contains 204. The other eight include [MyApplication.cs](../unified/src/csharp/DataCareNext.My/MyApplication.cs), which chooses the login form and enables settings persistence on exit. Some support code may ultimately be compiler-only, but that needs a documented disposition. It cannot be silently ignored by a directory-scoped inventory.

The initial form index also contains **43 named-grid records with no direct literal source-line candidate**. These are unresolved traceability obligations, not 43 proven missing web fields. The supplemental register and semantic extraction tasks keep that distinction explicit.

## Breadth and depth coverage after strengthening

The following coverage areas are explicitly required. [The machine-readable coverage obligations](10-plan-coverage-obligations.json) link the work items, scenario groups and release gates; every one of the 83 packages is accounted for. These links are planning traceability, not proof that all leaf business rules have already been authored.

| Area | Required end state | Main packages |
| --- | --- | --- |
| Product/version inventory | All source, support, menu, country/book, report, data and companion behaviours reconciled with a versioned baseline | P00, P13 |
| Masters and setup | Rich account/customer/item/design/component/slab/company/branch/year/book data, defaults, validations, import and lookup behaviour | P03 |
| Form depth | Headers, all applicable main/child/received/settlement grids, hidden identity, defaults, precision, conditional fields and meaningful prompts | P00-05, P02 and every family |
| Calculation behaviour | Correct triggers, dependency order, fine/weight/labour/rate/tax/interest rules, blank/zero/manual overrides and exact rounding | P01-02, P02-03 and every family |
| Purchase and supplier work | All purchase variants, components, old metal, returns, tenders, outstanding and supplier reports | P04 |
| Retail, wholesale and labour sales | Complete line/child/tender depth, old-gold exchange, order linkage, stock policies, returns and prints | P05-01/03/08, P06-05 |
| Connected commercial workflows | Quotation/order/manufacturing/delivery, approval/consignment/tour/parcel/conversion, repair custody and settlement | P05-04/07, P08-04 |
| Finance and metal accounts | Cash/bank/card/UPI/cheque identities, bill allocations, journals, openings, fine transfer, bullion booking and both rate-cut sides | P06 |
| Inventory and tags | Tag-instance identity, opening/lot/component/image depth, transfer/cancel/split/weight changes, stock count and full reversal/conservation | P07 |
| Manufacturing and karigar | Stage/order/lot issue and receipt, losses, components, rework, settlement, WIP, melting and downstream tagging/sale | P08 |
| Pledge/loan and schemes | Interest/date/principal handling, custody, enrollment/installments/bonus/maturity/redemption/refund and linked accounting | P09 |
| Transaction integrity | Exact postings and forbidden writes, unchanged edits, source dependencies, cancellation/reversal, locking, idempotency and cross-scope isolation | P01 and every family |
| Reports and documents | Every required launch mode, parameter, dataset, formula, layout, drill-down, export, physical print and role restriction | P10 |
| Settings and operator efficiency | Every effective policy, dependent defaults, shortcuts, keyboard throughput, multiple open forms, remembered preferences and recoverable errors | P02, P11-05 |
| Utilities, devices and providers | Correction/refresh/year-end/reference updates, printers/scales/scanners/cameras, messaging/rates/e-invoice/Olocker and reliable background work | P11 |
| Data and business continuity | Complete migration plus continued work on history, images/templates, backup/restore/rollback, chosen connectivity mode and production operation | P12, P02-06 |
| Production acceptance | Full real-browser journeys, independent desktop/write/report comparisons, representative shops/roles, candidate-bound evidence and controlled transition | P14 and R00–R14 |

Shared infrastructure does not collapse variant coverage. A common page for retail and wholesale, or a common writer for two book modes, still needs a separate contract and evidence for every distinct business branch. A high-level package can require hundreds of cases; it is not complete because a similarly named endpoint exists.

## How the plan prevents “implemented but not equivalent”

For each leaf requirement, the implementation must connect desktop evidence to an actual operator path, request adapter, domain rule, stored values and read/reopen behaviour. Its related ledger, stock, outstanding, tax, allocation, image and report effects must also be checked. A hidden server field need not become editable, but it must remain correct after an unchanged save or a downstream return.

For each action, the contract must describe the initial state, role/book/settings conditions, input and defaults, confirmation and validation alternatives, intermediate calculations, final effects, permitted corrections and failures. The requirement graph expands whenever source inspection or desktop operation reveals a missing branch. New descendants keep their delivery package and release gate open.

The verification program now contains **128 minimum business scenario anchors**, the 18-row universal per-form matrix and T0–T7 evidence layers. These are frameworks for expanding the cases across every applicable mode. They are deliberately not a promise that only 128 automated tests will be enough. The exact-set contract in [the verification document](03-verification-and-release.md#exact-set-completeness-and-certification-contract) rejects a missing case even if every submitted result says pass.

A missing template, dormant setting without a proven disposition, unresolved desktop branch, contained tag operation or unverified provider action remains open. A manual SQL repair or required desktop fallback cannot complete a web journey. A production improvement may change technology and presentation, but any changed business outcome needs a recorded difference and its own acceptance; it must not be described as literal identity.

## The offline-to-web decision must be concrete

“Web-based” does not uniquely mean “cloud-only.” A browser can use a local/LAN web server and database, while an internet-hosted service depends on connectivity to that service. Full disconnected browser synchronization is another architecture with substantially different stock, numbering, security and conflict requirements.

The plan therefore requires a matrix for internet outage, LAN failure, application/database failure and device-bridge failure. For each, identify whether selling, stock lookup, settlement, printing, reporting and provider submissions continue, queue or stop, and how recovery is verified. Ordinary desktop-independent business must retain its required capability for the full operational replacement claim. Cloud-only deployment with draft recovery alone cannot demonstrate that particular equivalence.

No architecture was silently selected in this planning review. This decision must be completed early, before transaction and deployment design is treated as settled. The plan includes verification for the selected topology; it does not pretend that cached screens or a pending outbox implement offline posting.

## What remains necessary before a definitive parity sign-off

1. Establish the exact supported desktop executable/configuration baseline and reconcile all source/runtime behaviour, including the supplemental inventory, reports and companion/version deltas.
2. Author and review the complete leaf contracts and dependency graph. This remains substantive implementation work; the current 11 contract files are not enough to infer completion.
3. Implement every required web path, including the known rate-cut receiving, lot manufacturing, design components, tag, settings and report gaps, while preserving valid existing work.
4. Run independent desktop and web cases with equivalent starting fixtures/configuration. Compare actions and intermediate values, expected table/key/field sets, resulting business state, prints and reports.
5. Demonstrate normal and exception journeys in the real browser/API/database on representative configurations, including continued business after migration, concurrent use, connectivity recovery, devices and providers.
6. Pass every release gate for the actual candidate and complete role-based UAT, recovery/cutover rehearsal and stabilization. No hidden feature exclusions, stale passing subset or mandatory desktop fallback is acceptable.

The accurate answer is therefore conditional: **implement and satisfy the strengthened plan in full, including all discovered requirements and its independent acceptance gates, and the product can be accepted as the complete web replacement for the verified desktop baseline.** Today the plan is stronger and more auditable; neither the plan nor this recheck certifies that the web has already achieved that result.
