# Master execution plan

## 1. Work model

Keep the existing 83 `P00`–`P14` packages and 34 `X01`–`X34` cards as parent scope. Use the slices below to order delivery; they are not substitute acceptance criteria. A package is closed only when all of its source-derived children, menus, settings, variants, reports and business journeys pass. Document 07 reconciles every package and document 06 provides module implementation details.

For each slice assign a domain engineer, frontend engineer, independent QA reviewer and relevant business operator. Small teams may share roles, but the person who derives the expected desktop result must not derive it from the new implementation. Record estimates after the slice's branch inventory and test environment exist. There is no supportable fixed delivery date from the current field-count proxy.

Use feature branches and small reviewable changes in `web/`. Change canonical desktop/reference artifacts only to correct provenance with retained originals. Do not merge bulk generated fields unless they are traced through UI → request → domain → persistence → reopen → reports and tested through the actual control. Preserve the raw extraction and historical plan evidence.

## 2. Dependency waves and exit gates

| Wave | Scope and parent work | Concrete deliverables | Exit gate and dependency |
|---|---|---|---|
| W00 Baseline | P00, X01–X04 | Current code/lock/schema hashes; hydrated Windows assets; complete menu/branch inventory; fresh isolated test targets; missing artifact ledger | Every required surface has an owner; desktop capture can be reproduced; checks report skipped/missing honestly. Required before acceptance claims, while source analysis may proceed in parallel. |
| W01 Domain foundations | P01, X05–X06 | Complete scoped identities; numeric profiles; posting ownership graphs; lifecycle/concurrency conventions; imported-value preservation | Representative sale/purchase/cash/tag/return histories survive no-op save and rollback with exact expected footprints. Depends on W00 reference contracts. |
| W02 Operator framework | P02, X07–X09, X29 | Complete form descriptors, child grids, key/focus behavior, lookups, draft/error states, configuration consumers, session adoption | One complex entry form, one master and one report pass complete field/action tests in at least two configurations. Depends on W01 contracts; can run beside master work. |
| W03 Setup and masters | P03, X10–X11 | Fresh tenant/company/branch/year/books; accounts/items/labour/tax/design and children; master imports and live search | A new business is usable without manual SQL or fixed customer codes; master change reaches transaction, stock and report. Depends on W01/W02. |
| W04 Inventory foundation | P07-01/02, X18 | Exact tag/lot/location/custody identity; openings; item-lot and stock availability; source reservations | Duplicate tag text in another scope never substitutes for the intended serial. Opening→read→edit→movement matches reference. Depends on W03. |
| W05 Purchasing | P04, X12 | Retail/wholesale/hallmark/old-item/quotation/consignment variants; returns; supplier settlement | Purchase→tag/lot→payment→return→reversal reconciles all accounts, stock, tax and outstanding; feeds sales fixture pack. Depends on W04. |
| W06 Sales and orders | P05-01/02/04/06/08, X13–X14 | Retail/wholesale/labour/fine invoices; rich orders and quotations; reservations, imports and conversions; tenders | Order/advance→purchase or manufacture→delivery/invoice→settlement, and immediate sale, work via actual browser. Depends on W03–W05; progress narrow Return work concurrently. |
| W07 Returns and statutory notes | P05-03, X13/X15, P11-03 | Trusted saved-return numeric path; reconciled legacy Return routes; full credit-note lifecycle; original references and refund | Partial and repeated return limits, stock/account/tax/custody effects, open/edit/delete/cancel and statutory artifacts independently match. Depends on W01 and proved sale identity; one c27 profile is only an early slice. |
| W08 Finance and fine metal | P06, X16 | Cash/bank/journals/transfers; bill allocations; bullion booking; both rate-cut sides; exact closing and book behavior | Accountant reconciles money and fine balances through mixed settlement, edit, reversal and period close. Depends on W01/W03 and transaction footprints from W05–W07. |
| W09 Tag completion and count | P07-03–06, X18–X22 | Four separately qualified tag operations; physical stock sessions, finalization and permitted reversals | Each containment exit gate passed independently; parent/child conservation, stock identity, concurrency and output proven. Depends on W04 and required finance/mfg effects. |
| W10 Custody and service | P05-05/07, X17 | Approval, consignment, tour, parcel, repair; partial returns/delivery; photos; settlement | End-to-end custody chain agrees at every handoff; goods cannot be sold/returned twice; report and receipt match. Depends on W04/W06/W08. |
| W11 Manufacturing | P08, X23 | Stage/karigar/jobwork/lot/order-linked/design/melting variants; issue/partial receipt; component/loss/settlement | Material/fine/custody/labour conservation across a complete production day and correction cycle; valid Setting issue/receipt writes available. Depends on W03/W04/W08. |
| W12 Loans, members and schemes | P09, X24 | Distinct dhiran/loan modes, interest and release; enrollment, installment, maturity, adjustment, points | Historical and fresh contracts continue correctly through repayment/default/maturity/redemption and exception paths. Depends on W03/W08 and W06 for sales adjustment. |
| W13 Reports, devices and utilities | P10/P11, X25–X29 | Every report/mode/template; print/export/drilldown; devices/providers; correction/renumber/transfer utilities | Dataset and layout comparisons plus physical output pass; utilities preserve complete reference graphs and rollback. Begin alongside owning modules, finish after their effects stabilize. |
| W14 Migration and operations | P12/P13, X30–X32 | Complete ownership conversion manifest; shadow loads; historic continuation; restore/rollback; deployment/continuity; edition/companion closure | Two clean repeatable multi-scope rehearsals; zero unexplained differences; measured recovery; all required editions/artifacts resolved. Design begins W00, final execution after W05–W13. |
| W15 Full acceptance | P14, X33–X34 | Full normal/exception business days; operator UAT; exact-set release certificate; rollout/stabilization/handover | Every required leaf and journey accepted on one current candidate, with production transition and rollback approval. No partial/contained/missing item remains in the full-product scope. |

The dependency graph is a start-order, not a waterfall. Report contracts, desktop captures, device samples and migration inventories should start early. Shared source ownership, ledger calculation, scope handling and sequence allocation should not be changed concurrently by multiple module teams without a single integration owner.

**Start versus closure dependencies:** W05 and W06 can begin with agreed W01 finance and production contracts and their already available implementations. Their supplier-settlement and manufacture-to-fulfillment exit cases remain pending until W08 and W11 integrate. W08 and W11 require the relevant transaction identities/footprints from W05–W07, not already closed entire waves. Track those deferred cross-wave cases explicitly; none of these waves can self-close while a dependent business continuation remains unverified. This avoids interpreting the table as a circular all-or-nothing start gate.

## 3. First implementation backlog after this planning change

These IDs are new delivery slices under the existing parents. Status for all is **planned**, not implemented by this document.

| Slice | Required action and concrete target | Parent/card | Must prove before advancing |
|---|---|---|---|
| N01 | Pin current source, schema, lock, settings, runtime and report-template manifests; make availability of LFS assets and missing generated evidence explicit | P00-01/04, X01/X03 | Clean checkout can reproduce commands; wrong/stale source rejected |
| N02 | Enumerate `MDI_FORM` switch branches, group captions, constructor arguments, hidden actions and `NextDm` deltas against all 198 menu rows | P00-01, P13-02, X01/X32 | Every reachable action mapped; duplicates require evidence, not name matching |
| N03 | Establish Windows runtime capture protocol and sanitized fixture set; record .NET, SQL Server, locale, binary hashes and settings | P00-02, X03/X04 | Same case replays identically; failures/missing environment are not empty-success captures |
| N04 | Re-run safe current engineering baseline, then isolated real API/DB/browser recipe; recover or supersede missing historical artifact references honestly | P00-04/05, X03/X34 | Exact required test identities present, no skip flags, logs bind candidate |
| N05 | Build semantic contracts from retained 3,508 grid, 1,599 control, 916 supplementary input and 5,838 event records; link owner and branch to each | P00-03/05, X02/X04 | No unowned input, hidden column, callback or action; dynamic behavior expands denominator |
| N06 | Audit every active Return mutation against saved diagnostic surfaces; document API authority, UI reachability and missing profile conditions | P05-03, X05/X13 | No statement that previews authorize commits; active legacy writer differences have explicit tasks |
| N07 | Freeze complete incoming-return c27 fixture and all raw source/master/settings/permission/guard/physical membership observations | P01, P05-03, X04/X13 | Independent old/current/expected maps and admitted profile fixed before writer implementation |
| N08 | Add trusted same-transaction Return observation assembly, including clocks, header/line versions and complete financial/BAR membership | P01-01/05, X05/X13 | Reject missing/extra/duplicate/wrong-scope/phantom rows; client witnesses cannot impersonate server authority |
| N09 | Compose existing replay, Float qualification, effect-context, financial planner and ordered guards with proven admission | P01-02/03, X06/X13 | Every intermediate result and affected field agrees with independent vectors and Windows reference |
| N10 | Implement narrowly owned atomic numeric update and transactional result identity; retain unowned raw data and use appropriate serializable conflict handling | P01-04/05, X05/X13 | Rollback after each write family; no broad delete/reinsert; no automatic retry after ambiguous commit |
| N11 | Expose strict endpoint and real saved-return UI Save/reopen, stale draft and result recovery | P02-06, P05-03, X07/X13 | Operator can save admitted change, reopen exact values and receive actionable conflict without losing draft |
| N12 | Reconcile committed Return stock/account/Rojmel/tax/BAR/report effects; extend multirow, labour, outgoing, tag, tender and edition branches individually | P05-03/08, X13 | One narrow c27 test never closes all Return variants |
| N13 | Prove complete identity/default/NULL/clock/numeric contracts for purchase, sale, finance, stock and loan families before wider edits | P01-01–05, X05/X06 | Byte/text preservation where required, semantic type comparison where intentional, no invented defaults |
| N14 | Build fresh company with alternate accounts/book codes and full master data solely through UI/import paths | P03, X10/X11 | No hidden hard-coded book/account requirement; master version/role/scope tests pass |
| N15 | Complete purchase and sale child/tender/source chains on the shared form framework; verify each extended field reaches persistence and reopen | P02/P04/P05, X07/X12/X13 | Dissimilar child rows survive reorder, delete, copy, edit and cancellation |
| N16 | Implement credit-note document lifecycle and independent provider state machine | P05/P11-03, X15/X28 | Lost provider acknowledgment reconciles before retry; document remains truthful |
| N17 | Finish two-sided rate-cut and bullion booking edit/history/settlement using configured accounts | P06-04/05, X16 | Amount and fine balances reconcile after partial cut, reversal and retry |
| N18 | Qualify tag transfer and cancellation separately, preserving exact live serial and referenced children/images | P07-03, X18/X19 | Full lifecycle, conflict, reversal and complete DB diff |
| N19 | Implement tag split and explicit weight replacement separately, including sale-driven `SL_TAG_WT_DIFF` ownership | P07-04/05, X20/X21 | Child identity allocation and conservation; every parent relation and image correct |
| N20 | Complete stock count session/finalization, discrepancy handling and reverse/adjust policy | P07-06, X22 | Duplicate scans and concurrent sales cannot silently corrupt final stock |
| N21 | Enable proven Setting issue/partial receipt and component lot production with stage transition validation | P08-03, X23 | Source outstanding atomically consumed; over-receipt and downstream delete handled |
| N22 | Join order/approval/consignment/tour/parcel/repair chains with billing and custody | P05-04–07, X14/X17 | Same item cannot be in conflicting custody states; partial completions reconcile |
| N23 | Complete dhiran/loan/scheme and points continuations, including historic dates and concurrent redemptions | P09, X24 | Independently calculated balances/interest; no duplicate maturity or overspent points |
| N24 | Complete all report bindings/modes from actual current registry and desktop template calls | P10, X25/X26 | Source report filters/joins/groups/totals match; no unsafe fallback on an unrelated dataset |
| N25 | Exercise printer/scanner/scale/camera and provider flows on supported target hardware/configuration | P11-02/03, X28 | Physical outputs and delayed callbacks match correct current document/session |
| N26 | Close correction, renumber, transfer, imports and maintenance utility reference graphs | P11-01, X27 | Preview and actual affected set agree; failure/retry/restore preserves all linked records |
| N27 | Implement complete staged migration and historical business continuation; retain cutover containment until its gate closes | P12-01–03, X30 | All source tables dispositioned, scoped isolation, exact reconciliation and restartability |
| N28 | Qualify logical restore/deployment/continuity and record operational release authorization separately from engineering proof | P12-04/05, X31 | Timed restore + readiness + isolation + controlled drill; no migration gate substitution |
| N29 | Run every module journey and cross-module normal/exception day with operators | P14-01/03, X33 | All exact required cases executed on current candidate; independent data/report differences resolved |
| N30 | Strengthen exact semantic-leaf and mode enforcement, freeze release inputs, certify and perform controlled rollout | P14-02/04–06, X34 | No stale, absent, duplicate or waived full-product requirement; truthful handover |

### 3a. Gap-closure slices added on 1 October 2026

The audited gaps G01–G18 ([document 10](10-gap-register-2026-10-01.md)) add slices N31–N46. They run **before**
the remaining programme slices N19 (weight difference) to N30, because several of them block a daily workflow
or print a wrong document. N16, N17, N18 and the split half of N19 are `implemented-unverified` on `main`
(engineering evidence only).

| Slice | Required action and concrete target | Parent/card | Must prove before advancing |
|---|---|---|---|
| N31 | Scope sales/purchase/quotation/credit-note document readers by company, location, year and book; no literal book default | P10-01, P01-01, X05/X25 | Same voucher number in two locations/years prints only the selected one |
| N32 | Hallmark/tag-wise purchase: configured book, reopen/edit/delete/print, then the TR_PURC_HM receive grid | P04-02, X12 | Screen save → reopen → edit → delete with column-level row comparison |
| N33 | Other Expenses (OTH EXP): configured book, desktop grid, full lifecycle and print | P04-02, X12 | Forward/reverse tax, discount and inter/intra split match desktop arithmetic |
| N34 | Purchase Return: original-purchase selector, remaining quantities, Rojmel and diamond rows, reopen/edit/print | P04-04, X12 | Tagged and partial returns accepted, over-return refused, reversal exact |
| N35 | Sales Return original book from active SALES books | P05-03, X13 | Import from a non-default sales book; wrong family refused |
| N36 | Registers classify by stored amounts and MAIN_BOOK, not literal book codes | P10-03, X26 | Desktop-shaped fixture totals equal the desktop rule |
| N37 | Order Cancel as the desktop adjustment voucher (multi-order, bounds, ledger/Rojmel/stock/tag, lifecycle, print) | P05-04, X14 | Bounds refused atomically; full write set; reversal |
| N38 | Wholesale quotation mode | P05-02/04, X13/X14 | No stock/ledger rows; print; conversion lineage |
| N39 | Estimate document from the company master | P05-01, X13 | Two companies print their own headers |
| N40 | Hallmark sale reopen/edit/delete | P05-01, X13 | Unchanged save preserves HUIDs and hallmark charge |
| N41 | Line previews honour LBR_WITH_GHT | P02-05, X08 | Preview equals posted labour with the setting Y and N |
| N42 | Enforce EMP_CODE_MANDATORY on sales | P05-01, X13 | Desktop message; no partial write |
| N43 | Document template registry: sales/purchase variants, copies, HUID print, Other Income voucher | P10-05, X25 | Dataset equality then desktop layout review |
| N44 | Sales Order tenders, old-metal advance and delivery allocation | P05-04, X14 | Advance consumed exactly once across deliveries |
| N45 | Wholesale remaining branches listed in the X16 progress record | P05-02, P06-05, X16 | Each branch has a write-set test and journey |
| N46 | Quotation → invoice conversion with lineage | P05-06, X14 | Source identity kept; repeated conversion refused |

### 3b. Audit implementation slices added on 1 October 2026

The full-stack audit ([document 11](11-audit-implementation-plan-2026-10-01.md)) adds gaps G20–G66 and slices
N47–N82, each with steps, tests and acceptance in document 11 §6. They run in six phases; earlier slices still in
progress continue inside them.

| Phase | Purpose | Slices |
|---|---|---|
| A | Trustworthy build: gates, harness and CI | N47, N48, N49 (N81 in parallel) |
| B | Stop wrong documents and data loss | N56, N53, N40, first milestones of N51, N50 and N54, the N34 remainder |
| C | Multi-user and data foundations | N50, N51, N52, N55, N58–N63 |
| D | Workflow completeness | N64–N72 with N20–N23, N32, N37, N38, N44–N46 |
| E | Documents and operator experience | N57, N73, N43, N74–N77 with N24 |
| F | Migration, operations and release | N78, N79 (with N27), N80, N81, N82 with N25, N28–N30 |

## 4. Ready-to-implement definition for a feature

Before coding a feature, its card must contain:

1. Parent package/card and stable semantic requirement IDs; menu aliases and all caller modes.
2. Canonical desktop source path, SHA-256, symbol and lines; SQL/helper calls and relevant template/settings.
3. Current web path, route, module, reader/writer, schema columns and existing tests, explicitly distinguishing verified from inspected.
4. Input/display/derived/hidden fields, child identities, supported state transitions, visibility/permission conditions, numerical trigger order and errors/focus.
5. Complete table ownership and downstream graph, including images, source allocations, stock, account, tax, Rojmel, outstanding, audit and external document state.
6. Independent fixtures with initial rows, ordered actions, intermediate values, complete expected final rows, failure paths and unchanged-scope sentinels.
7. Implementation steps, dependencies, test commands, desktop comparison procedure, operator script and close-only-when criteria.

If a contract cannot yet be determined from extraction, the next deliverable is a capture/research task with named missing evidence, not an invented calculation or guessed dropdown option.

## 5. Repeatable delivery loop

1. Freeze the slice's input set and independent fixtures. Read source callers and helpers, not only the form's designer section.
2. Run the current related checks; record existing failures separately from new regressions.
3. Implement domain and storage changes, migrations, authorization and lifecycle together, then API and actual operator controls.
4. Run exact unit/contract tests; real isolated DB tests with non-owner role; API tests; actual browser interaction; original desktop differential; report/print checks.
5. Exercise concurrent operators, stale configuration/rights, duplicate submission, ambiguous acknowledgment and rollback boundaries.
6. Compare the complete persisted business footprint and untouched sentinels; perform reopen/edit/reversal and dependent report checks.
7. Review with an independent engineer and operator. Retain unresolved differences as failing requirements, not comments under a green parent.
8. Update only current status records with evidence IDs and tested source hashes. Preserve historical records. Integrate and rerun impacted cross-module journeys.

Work may proceed when a broader gate is known red, but no red or absent required gate may be hidden in a completed parent or release claim.
