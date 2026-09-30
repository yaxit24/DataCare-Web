# Previous-plan reconciliation and completion protocol

Analysis date: 29 September 2026. Repository baseline: `03148fe`. This is a source/document audit, supplemented by four newly executed read-only checks; it is not a new application, desktop, database or business certification. Source and existing code are preserved. The accompanying `previous-package-reconciliation.json` retains every original package contract, all mapped card steps/cases, source/test paths, and current assessment.

## Current conclusion

The repository is a broad but incomplete implementation. All **83 previous packages** and **34 execution cards** remain open. The completion register declares **198/198 implemented-unverified**. A newly executed strict classification check passes; the release-mode check rejects **198/198**. This does not mean no functionality works: it means no complete menu contract has the required acceptance evidence.

Full functional completion is **unmeasured**. The latest retained 72.1% (3,681/5,107) ratio is a static field/control proxy, and 61.3% is a grid-column proxy. Neither measures successful business transitions. Older 73%, 97.6%, 98.9%, “built”, or “certified” statements from other documents must not be converted into current whole-product completion.

Round 15 remains an unsealed snapshot: two of its 18 required checks were retained, and checkpoint 43 does not exist. Checkpoint 41 has the expected SHA-256 `643bf89ad0ac50729c7feff06c28dfa6bf8cca7d6318e498397cd5c57bf9ebea` and remains the latest sealed historical record. Retained Round15 core 26 files/1,613 tests and five-test-file strict compilation are historical results. This reconciliation sub-review did not rerun those tests; the overall planning review separately reran the core and frontend suites as recorded in `evidence/verification-observations.json`.

The new saved incoming Return pipeline is still a diagnostic/pure/read-only composition with `canCommit:false`; trusted numeric Update, actual Save UI, known closing and full effect admission remain open. **Legacy numeric creation is separately active:** `web/apps/api/src/routes/txn.ts:1399` registers `POST /sales-returns` calling `createSaleReturn`. The exported `editSaleReturn` helper at `web/apps/api/src/modules/sales/salesReturn.ts:743` contains numeric delete/rebuild logic but is not imported or registered in `txn.ts`; it does not establish a generic numeric edit HTTP surface. The routed saved edit is `PUT /sales-returns/:vchNo/incoming-metadata` at `txn.ts:1386`. These distinct legacy/helper/metadata paths are not certified by preview/pure-module tests. Do not describe all Return writes as disabled or route the new preview through a legacy writer as an implementation shortcut.

Six explicitly contained operations remain: logical restore, production cutover load, tag transfer, tag cancellation, tag weight difference and tag split. Each has its own release obligation in `web/packages/core/containment.mjs`. The previously discharged tag-opening update does not discharge the other tag operations.

## Current validation and evidence availability

| Newly executed check | Result | What it establishes |
| --- | --- | --- |
| `node scripts/check-completion-register.mjs --strict` | Passed | 198 well-formed declared classifications; no whole-menu acceptance |
| Same command plus `--release` | Failed: 198/198 | Current register cannot satisfy release requirements |
| `node scripts/check-doc-references.mjs` | Failed: four missing browser result files | A clean clone lacks referenced historical generated evidence; prior retained pass is not a current pass |
| `node --test scripts/test/request-field-trace.test.mjs scripts/test/ui-descriptors.test.mjs` | 31 passed, zero skipped | Existing scanner fixtures pass; static trace support is not domain parity |

The missing documentation references are the original real-stack browser result, round3 verified result, round4 blank-source result and round3 image-report delete-confirmation result. Recover them from authoritative retained storage or replace the current acceptance with freshly reproduced evidence; never manufacture successful files to satisfy references.

Both Round15 public manifests contain 1,930 entries. Current file audit: **1769 exact matches; 6 matching-content LFS pointers; 147 other changed files; 8 missing files**. Missing files mostly include generated dist outputs and the report-comparison artifact. Changed files include actual application source, not only LFS pointers. A matching pointer OID is useful provenance but does not make an executable or report binary available. Private inputs and runtime dependencies were not validated. The complete categorized list is in `evidence/previous-plan-validation.json`. Rebaseline and rerun the actual candidate before crediting historical proof.

The file audit was captured at `2026-09-29T02:29:27.095575+00:00`. Parallel team checks may produce ignored build outputs afterward, so the generated-file totals are observations of that moment. Tracked-file counts are `{"changed": 143, "lfs-pointer-for-expected-content": 6, "matches": 1733}`; they are separated from generated/untracked runtime availability in the JSON. None of these counts is a new test result.

## Which prior documents still govern which decisions

| Prior source | Retained value | How the new plan must reconcile it |
| --- | --- | --- |
| `web-implementation-spec/` | Module, data-table and engine reference deep dives | Its ~50-screen/162-model/built/certified narrative is historical. Keep logic references; validate contracts against current source and actual reachable modes. |
| `project-memory/parity/PRODUCTION-DELIVERY-PLAN.md` and `PARITY-MASTER-PLAN.md` | Integrity-first sequencing; full vertical-slice and production obligations | Preserve foundations, real DB and desktop oracle gates; old counts and source-specific defect claims are review leads, not current measurements. |
| `FUNCTIONAL-PARITY-PLAN-2026-08-02.md` | Create/open/edit/delete/daybook distinction and historical correction workflows | Recheck all families, including delete/re-enter and dependent transactions; one customer's historical usage does not limit the full product. |
| `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md` | Present/usable/desktop-verified/production-proven states | Keep states separate and link every claim to a current candidate. Retained 66-case comparisons cannot certify all modes. |
| `DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md` | Database/workflow/form/report dimensions | Carry all four dimensions into each leaf's acceptance; do not compare percentages with different denominators. |
| `DESKTOP-PARITY-IMPLEMENTATION-PLAN-2026-09-01.md` | Operator-depth and field/grid/event extraction | Keep source reference method; resolve decompiler ambiguities (such as width properties) with IL/runtime evidence. |
| `parity-plan-2026-09-10/01`–`10` | Frozen registers, 83 packages, 128 scenario anchors and R00–R14 gates | Preserve all IDs and original acceptance; counts are floors, not a ceiling when new reachable scope appears. |
| Documents 11–13 | Reassessment and all 34 ordered execution cards | Carry current partial work forward, but retain every parent obligation and independent proof requirement. |
| Documents 14–41 | Historical implementation/checkpoint chain | Use bounded implementation and historical results where source/input identity is valid; do not rewrite past results. |
| Document 42 and `web/docs/HANDOFF.md` first current-status blocks | Last retained continuation and Return write sequence | Respect unsealed Round15, legacy-vs-new Return distinction, current source drift and missing evidence. Handoff credentials and old absolute paths must not be copied into deliverables. |

## All 83 packages: status and next closure obligation

Every row's acceptance remains open. “Existing” and “partial” describe code/evidence availability, not verified full functionality. Detailed original implementation instructions and exact linked card verification cases are preserved in `previous-package-reconciliation.json`.

| Package | Original title | Current classification / evidence anchor | Next closure obligation |
| --- | --- | --- | --- |
| P00-01 | Freeze and reconcile the complete product inventory | X01: inventory-partial | Complete the semantic/transition inventory and truthful partial/contained labels; do not promote a mapped menu to verified. |
| P00-02 | Capture the desktop as an independent reference | X03: environment-evidence-incomplete | Complete reproducible real web/non-owner DB and original desktop capture environments; retained browser passes cover only their declared journeys. |
| P00-03 | Replace misleading completion metrics | X02: measurement-partial | Reconcile scanner blind spots and false positives with independent fixtures before computing a functional percentage. |
| P00-04 | Create a real full-stack verification environment | X03: environment-evidence-incomplete | Complete reproducible real web/non-owner DB and original desktop capture environments; retained browser passes cover only their declared journeys. |
| P00-05 | Make contracts and CI enforce coverage | X04: contracts-and-engines-partial; X34: certifier-partial-coverage-open | Supply every required leaf with source conditions, independent numeric/action oracles and failure expectations; drafts are not acceptance.; Complete exact required-leaf/candidate/dependency enforcement and one truthful current record; partial, stale or absent obligations must prevent full release. |
| P01-01 | Formalize identity and scope for every table family | X05: bounded-implementation-open | Extend exact scope, imported identity, versioning, rollback and retry rules to all document/image families and downstream references. |
| P01-02 | Complete numerical policies and precedence | X04: contracts-and-engines-partial | Supply every required leaf with source conditions, independent numeric/action oracles and failure expectations; drafts are not acceptance. |
| P01-03 | Close complete posting footprints | X06: comparison-evidence-incomplete | Produce current complete desktop/web posting differentials and reconcile every stock, ledger, tax, outstanding and historical continuation. |
| P01-04 | Standardize create/open/edit/delete and correction transitions | X05: bounded-implementation-open | Extend exact scope, imported identity, versioning, rollback and retry rules to all document/image families and downstream references. |
| P01-05 | Make concurrent writes and retries deterministic | X05: bounded-implementation-open | Extend exact scope, imported identity, versioning, rollback and retry rules to all document/image families and downstream references. |
| P02-01 | Define a reusable form contract without flattening variants | X07: shared-ui-partial | Prove every domain-specific cell, child, trigger, keyboard/help, error/focus and operator-throughput contract without flattening variants. |
| P02-02 | Complete child-grid editing and calculation | X07: shared-ui-partial | Prove every domain-specific cell, child, trigger, keyboard/help, error/focus and operator-throughput contract without flattening variants. |
| P02-03 | Implement cell-exit, lookup and totals behaviour | X07: shared-ui-partial | Prove every domain-specific cell, child, trigger, keyboard/help, error/focus and operator-throughput contract without flattening variants. |
| P02-04 | Complete keyboard and high-volume operator ergonomics | X07: shared-ui-partial | Prove every domain-specific cell, child, trigger, keyboard/help, error/focus and operator-throughput contract without flattening variants. |
| P02-05 | Implement settings as observable business policies | X08: settings-partial | Resolve all setting ownership/default/precedence branches and observable effects across consumers; old regex inert counts are not verified gaps. |
| P02-06 | Complete form session and error behaviour | X09: session-partial-service-undecided | Extend the implemented context safeguards across the operational lifecycle and establish accepted offline/outage/topology behavior. |
| P03-01 | Complete party, account and organization masters | X10: masters-partial | Verify conditional master fields, children/imports and complete fresh-company/branch provisioning through real operator flows. |
| P03-02 | Complete item, product, rate, touch, labour and stock-limit masters | X10: masters-partial | Verify conditional master fields, children/imports and complete fresh-company/branch provisioning through real operator flows. |
| P03-03 | Deliver the complete design-book workflow | X11: bounded-implementation-open | Finish shared help/search/create and remaining settings/downstream design consumers, image provenance and independent desktop parent/child comparison. |
| P03-04 | Provision branches, books, years and settings completely | X10: masters-partial | Verify conditional master fields, children/imports and complete fresh-company/branch provisioning through real operator flows. |
| P03-05 | Make master imports, bulk edits and search usable | X10: masters-partial | Verify conditional master fields, children/imports and complete fresh-company/branch provisioning through real operator flows. |
| P04-01 | Close retail/wholesale purchase form depth | X12: existing-lifecycle-unverified | Complete every retail/hallmark/old-item/quotation/consignment purchase variant, supplier settlement, reversal, document and report journey. |
| P04-02 | Complete hallmark, old-gold, quotation and other purchase variants | X12: existing-lifecycle-unverified | Complete every retail/hallmark/old-item/quotation/consignment purchase variant, supplier settlement, reversal, document and report journey. |
| P04-03 | Complete supplier settlement and outstanding lifecycle | X12: existing-lifecycle-unverified | Complete every retail/hallmark/old-item/quotation/consignment purchase variant, supplier settlement, reversal, document and report journey. |
| P04-04 | Complete purchase returns and source linkage | X12: existing-lifecycle-unverified | Complete every retail/hallmark/old-item/quotation/consignment purchase variant, supplier settlement, reversal, document and report journey. |
| P04-05 | Certify the purchasing business journey | X12: existing-lifecycle-unverified | Complete every retail/hallmark/old-item/quotation/consignment purchase variant, supplier settlement, reversal, document and report journey. |
| P05-01 | Close retail and hallmark invoice richness | X13: mixed-legacy-and-diagnostic-partial; X15: read-provider-slice-writer-missing | Complete the nine-step numeric Return path above and all retail/wholesale/labour/source/tag/child/outgoing/edition, ledger/closing, settlement and report branches.; Provide the full E CRNT create/edit/delete/read/document lifecycle and real provider state, beyond IRN on an assumed existing document. |
| P05-02 | Complete wholesale, labour and fine-sale variants | X13: mixed-legacy-and-diagnostic-partial | Complete the nine-step numeric Return path above and all retail/wholesale/labour/source/tag/child/outgoing/edition, ledger/closing, settlement and report branches. |
| P05-03 | Complete retail and wholesale returns | X13: mixed-legacy-and-diagnostic-partial | Complete the nine-step numeric Return path above and all retail/wholesale/labour/source/tag/child/outgoing/edition, ledger/closing, settlement and report branches. |
| P05-04 | Complete orders, quotations and fulfillment | X14: bounded-implementation-open | Extend guarded exact saved Sales/Tour lifecycles through quotations, tender/refund, tags, reservation, delivery, conversion and fulfillment. |
| P05-05 | Complete approval, consignment, tour and parcel workflows | X17: custody-lifecycle-partial | Join approval/consignment/tour/parcel/repair stages through partial receipt/delivery, custody, settlement, cancellation and documents. |
| P05-06 | Implement imports, conversions and voucher transfer as complete operations | X14: bounded-implementation-open | Extend guarded exact saved Sales/Tour lifecycles through quotations, tender/refund, tags, reservation, delivery, conversion and fulfillment. |
| P05-07 | Finish repair as a connected lifecycle | X17: custody-lifecycle-partial | Join approval/consignment/tour/parcel/repair stages through partial receipt/delivery, custody, settlement, cancellation and documents. |
| P05-08 | Certify sales operations as business journeys | X13: mixed-legacy-and-diagnostic-partial; X17: custody-lifecycle-partial | Complete the nine-step numeric Return path above and all retail/wholesale/labour/source/tag/child/outgoing/edition, ledger/closing, settlement and report branches.; Join approval/consignment/tour/parcel/repair stages through partial receipt/delivery, custody, settlement, cancellation and documents. |
| P06-01 | Complete cash, bank and tender identities | X16: existing-lifecycle-unverified | Complete all finance/booking/tender variants, two-sided rate cuts, closing and accountant-approved ledger/report reconciliation. |
| P06-02 | Complete journals, opening balances and location/fine transfers | X16: existing-lifecycle-unverified | Complete all finance/booking/tender variants, two-sided rate cuts, closing and accountant-approved ledger/report reconciliation. |
| P06-03 | Complete bill-to-bill and cross-document settlement | X16: existing-lifecycle-unverified | Complete all finance/booking/tender variants, two-sided rate cuts, closing and accountant-approved ledger/report reconciliation. |
| P06-04 | Complete bullion booking and rate-cut receiving | X16: existing-lifecycle-unverified | Complete all finance/booking/tender variants, two-sided rate cuts, closing and accountant-approved ledger/report reconciliation. |
| P06-05 | Complete wholesale fine/rate-cut arithmetic and docs | X16: existing-lifecycle-unverified | Complete all finance/booking/tender variants, two-sided rate cuts, closing and accountant-approved ledger/report reconciliation. |
| P06-06 | Certify accountant workflows and closing | X16: existing-lifecycle-unverified | Complete all finance/booking/tender variants, two-sided rate cuts, closing and accountant-approved ledger/report reconciliation. |
| P07-01 | Establish complete stock identity and availability | X18: mixed-opening-and-contained-transfer | Prove openings/stock identity and complete transfer lifecycle with its own release evidence before lifting containment. |
| P07-02 | Complete opening, item-lot and stock adjustment forms | X18: mixed-opening-and-contained-transfer | Prove openings/stock identity and complete transfer lifecycle with its own release evidence before lifting containment. |
| P07-03 | Complete and release tag transfer and cancellation | X18: mixed-opening-and-contained-transfer; X19: contained | Prove openings/stock identity and complete transfer lifecycle with its own release evidence before lifting containment.; Prove cancellation/reversal and exact affected references independently of every other tag operation; preserve its containment until qualified. |
| P07-04 | Complete and release tag split | X20: contained | Prove atomic parent/child conservation, identifiers, lifecycle and actual browser outcomes before split release. |
| P07-05 | Complete and release tag weight difference | X21: contained-and-unverified | Complete explicit tag replacement and separate sale-driven SL_TAG_WT_DIFF ownership and release evidence. |
| P07-06 | Complete physical stock and inventory reconciliation | X22: existing-lifecycle-unverified | Complete count-session finalization, discrepancy resolution, permitted reversal and complete stock/report consistency. |
| P08-01 | Extract the complete stage and material model | X23: read-slice-plus-existing-lifecycle | Complete every variant and actual lot issue/partial receipt/operator journey, material/financial conservation and reports. |
| P08-02 | Finish manufacturing line, component and settlement depth | X23: read-slice-plus-existing-lifecycle | Complete every variant and actual lot issue/partial receipt/operator journey, material/financial conservation and reports. |
| P08-03 | Deliver lot-based manufacturing end to end | X23: read-slice-plus-existing-lifecycle | Complete every variant and actual lot issue/partial receipt/operator journey, material/financial conservation and reports. |
| P08-04 | Complete order-linked production and design issue | X23: read-slice-plus-existing-lifecycle | Complete every variant and actual lot issue/partial receipt/operator journey, material/financial conservation and reports. |
| P08-05 | Complete melting and fine-loss settlement | X23: read-slice-plus-existing-lifecycle | Complete every variant and actual lot issue/partial receipt/operator journey, material/financial conservation and reports. |
| P08-06 | Certify the manufacturing business day | X23: read-slice-plus-existing-lifecycle | Complete every variant and actual lot issue/partial receipt/operator journey, material/financial conservation and reports. |
| P09-01 | Reconcile distinct dhiran and loan modes | X24: existing-lifecycle-unverified | Complete date/interest/custody/redemption/default/exception variants and independent business acceptance of each continuation. |
| P09-02 | Complete interest and repayment behaviour | X24: existing-lifecycle-unverified | Complete date/interest/custody/redemption/default/exception variants and independent business acceptance of each continuation. |
| P09-03 | Complete member and scheme enrollment | X24: existing-lifecycle-unverified | Complete date/interest/custody/redemption/default/exception variants and independent business acceptance of each continuation. |
| P09-04 | Complete installments, maturity, adjustment and loyalty | X24: existing-lifecycle-unverified | Complete date/interest/custody/redemption/default/exception variants and independent business acceptance of each continuation. |
| P09-05 | Certify borrower and scheme journeys | X24: existing-lifecycle-unverified | Complete date/interest/custody/redemption/default/exception variants and independent business acceptance of each continuation. |
| P10-01 | Repair report binding and full scope first | X25: document-binding-partial | Finish all report bindings, inherited/historical image rights and identity, children, semantics, visual layouts and required real physical output. |
| P10-02 | Reconcile every report screen, launcher mode and template | X26: report-comparison-incomplete | Inventory and independently compare every required report/mode, including absent comparison artifacts; endpoint counts do not prove results. |
| P10-03 | Complete financial, statutory and management parameters | X26: report-comparison-incomplete | Inventory and independently compare every required report/mode, including absent comparison artifacts; endpoint counts do not prove results. |
| P10-04 | Complete stock, manufacturing, customer and specialist reports | X26: report-comparison-incomplete | Inventory and independently compare every required report/mode, including absent comparison artifacts; endpoint counts do not prove results. |
| P10-05 | Complete document layout and printer output | X25: document-binding-partial | Finish all report bindings, inherited/historical image rights and identity, children, semantics, visual layouts and required real physical output. |
| P10-06 | Complete drill-down, export and print permissions | X25: document-binding-partial | Finish all report bindings, inherited/historical image rights and identity, children, semantics, visual layouts and required real physical output. |
| P10-07 | Certify every report family | X26: report-comparison-incomplete | Inventory and independently compare every required report/mode, including absent comparison artifacts; endpoint counts do not prove results. |
| P11-01 | Complete safe correction, renumber, transfer and refresh utilities | X27: utilities-unverified | Prove every correction/import/export/reset/repair utility against its full reference graph, rollback, recovery and audit contract. |
| P11-02 | Complete actual peripheral workflows | X28: adapters-unverified | Verify actual scales/devices/printers and provider state machines, credentials and required companion integrations; synthetic interfaces are insufficient. |
| P11-03 | Complete messaging, rates and provider-backed statutory flows | X15: read-provider-slice-writer-missing; X28: adapters-unverified | Provide the full E CRNT create/edit/delete/read/document lifecycle and real provider state, beyond IRN on an assumed existing document.; Verify actual scales/devices/printers and provider state machines, credentials and required companion integrations; synthetic interfaces are insufficient. |
| P11-04 | Complete authorization and audit across the whole workflow | X29: roles-session-partial | Complete role-specific operator journeys, fresh scope/rights enforcement, startup/timer/background ownership and audit discoverability. |
| P11-05 | Finish operator setup, navigation and help | X29: roles-session-partial | Complete role-specific operator journeys, fresh scope/rights enforcement, startup/timer/background ownership and audit discoverability. |
| P12-01 | Build the complete source ownership and conversion manifest | X30: production-load-contained | Reconcile complete scoped repeatable migration and continued historical business before production loading is released. |
| P12-02 | Implement staged, scoped and restartable loading | X30: production-load-contained | Reconcile complete scoped repeatable migration and continued historical business before production loading is released. |
| P12-03 | Rehearse reconciliation with representative histories | X30: production-load-contained | Reconcile complete scoped repeatable migration and continued historical business before production loading is released. |
| P12-04 | Certify backup, restore and rollback | X31: recovery-partial-contained | Prove production-like deployment, timed restore and outage/continuity topology with controlled release of contained recovery actions. |
| P12-05 | Complete production deployment and service operations | X31: recovery-partial-contained | Prove production-like deployment, timed restore and outage/continuity topology with controlled release of contained recovery actions. |
| P13-01 | Resolve UAE and edition-dependent behaviour explicitly | X32: scope-artifacts-incomplete | Resolve reachable edition-specific behavior, companion functions, runtime/provider/locale dependencies and all missing artifacts. |
| P13-02 | Assess NextDm and supporting applications | X32: scope-artifacts-incomplete | Resolve reachable edition-specific behavior, companion functions, runtime/provider/locale dependencies and all missing artifacts. |
| P13-03 | Close missing artifacts and unresolved behaviours | X32: scope-artifacts-incomplete | Resolve reachable edition-specific behavior, companion functions, runtime/provider/locale dependencies and all missing artifacts. |
| P14-01 | Execute every requirement and business journey | X33: business-release-unaccepted | Run complete normal/exception business days, independent desktop comparison, role-based UAT and production transition acceptance for the actual candidate. |
| P14-02 | Bind release evidence to the code that actually runs | X34: certifier-partial-coverage-open | Complete exact required-leaf/candidate/dependency enforcement and one truthful current record; partial, stale or absent obligations must prevent full release. |
| P14-03 | Complete business UAT by role and business type | X33: business-release-unaccepted | Run complete normal/exception business days, independent desktop comparison, role-based UAT and production transition acceptance for the actual candidate. |
| P14-04 | Rehearse cutover and rollback on a production-like target | X33: business-release-unaccepted | Run complete normal/exception business days, independent desktop comparison, role-based UAT and production transition acceptance for the actual candidate. |
| P14-05 | Perform controlled business rollout and stabilization | X33: business-release-unaccepted | Run complete normal/exception business days, independent desktop comparison, role-based UAT and production transition acceptance for the actual candidate. |
| P14-06 | Retire contradictory progress claims | X34: certifier-partial-coverage-open | Complete exact required-leaf/candidate/dependency enforcement and one truthful current record; partial, stale or absent obligations must prevent full release. |

## Card-specific implementation evidence and continuation

The files below are exact repository-relative starting points. Each original package may need additional source leaves; this list does not replace the desktop/form/report/settings registers.

### X01 — Reconcile scope and replace misleading availability labels

**Current classification:** inventory-partial. 198 menu entries are declared implemented-unverified; newly executed strict register check passes but release check rejects all 198. The menu count does not close hidden constructor/settings/edition branches.

**Parents:** P00-01. **Start after:** inventory baseline only.

**Source/implementation/test anchors:** `web/docs/COMPLETION-REGISTER.json`; `web/packages/core/containment.mjs`; `parity-plan-2026-09-10/evidence/form-register.json`; `parity-plan-2026-09-10/evidence/additional-control-candidates.json`.

**Implementation and reconciliation sequence:**

1. Freeze the reviewed dirty-tree files and desktop executable/source hashes; preserve prior work and old evidence. Read 08 and 09 before classifying controls.
2. Join all 198 menu identities to actual MDI_FORM dispatch, constructor arguments, MAIN_BOOK, permissions, page, route and domain function; distinguish the report Lot IsuRec from the transaction TR_MFG_WITH_LOT.
3. Reconcile 212 primary C# files, the original 204-unit register, eight support units, 916 supplementary declarations, 43 unresolved grid records, report references and table ownership. Resolve semantic duplicates explicitly.
4. Add separate implementationState, availabilityState, verificationState and missingActions/containmentOperation fields; retain legacy state compatibility until all readers are updated. A declaration of implemented-unverified must not imply usable or complete.
5. Create the canonical source-to-mode-to-requirement register. Include every reachable branch even when it is unused in the supplied business data. Link missing artifacts to X32.

**Required targeted verification:**

- Every original menu/source/control/report identity resolves to a leaf or reviewed disposition; unknown identities cause failure.
- A contained tag route remains unavailable even when its page and handler exist; an IRN-only page remains partial.
- Changing a label or adding a duplicate route must not increase implemented semantic requirements.
- Adding a new discovered mode grows the expected set and reopens affected package acceptance.

**Close only when:** Complete traceable inventory and truthful availability; no automatic promotion to verified. Inventory completeness is an explicit reviewed result, not the 198-row count. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X02 — Repair scanners before using any percentage

**Current classification:** measurement-partial. Request-path and UI-descriptor scanners have implementation and newly rerun 31 positive/negative tests pass. Static depth/dead-cell observations are heuristic and still need runtime leaf coverage; no percentage of complete business behavior is established.

**Parents:** P00-03. **Start after:** X01.

**Source/implementation/test anchors:** `web/scripts/check-depth.mjs`; `web/scripts/check-dead-cells.mjs`; `project-memory/parity/richness_web.py`; `project-memory/parity/richness_desktop.py`; `project-memory/parity/settings_parity.py`; `web/apps/web/app/(app)/txn/wholesale-sale/page.tsx`; `web/apps/api/src/modules/sales/rateCut.ts`.

**Implementation and reconciliation sequence:**

1. Discover page files and dynamically reachable master/report/book modes independently of the writer map; fail an unmapped discovered path.
2. Track page input to transformed payload to route adapter to nested domain field to calculation/write/read/reopen, including issueYear/issueBook/issueNo/issueSrno -> isuRef -> ISU_* columns. Preserve this working mapping while fixing measurement.
3. Recognize typed settings aliases, recalc wrappers, shared component props and source declaration modifiers; join actual event/caller contracts rather than counting generic field names.
4. Classify each control as editable, derived, hidden identity, display-only or non-business, with conditional mode applicability.
5. Publish stage-specific counts with an unknown denominator until inventory closure. Keep old 73.0% and 97.6% figures labelled historical heuristic outputs; never reset a baseline to manufacture improvement.

**Required targeted verification:**

- A valid nested mapping passes; dropping isuRef from the route fails the corresponding path.
- Remove a reader field while leaving the writer intact: reopen coverage must fail.
- Add an extended-grid page without a mapping: audit must fail and name it.
- An identically named field on another route cannot satisfy the missing field.
- MS_PRINT virtual checkboxes and supported wrapper recalc/settings calls are discovered; unused aliases are not treated as effective policy.

**Close only when:** Measurement tools pass independent positive and negative fixtures and reconcile the declared universe; no claimed functional percentage from surface counts. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X03 — Provision reproducible desktop and real web verification

**Current classification:** environment-evidence-incomplete. Real-stack browser and non-owner PostgreSQL harnesses exist. Historical proof references depend on generated/ignored artifacts absent from this clone; original Windows runtime, fixtures and reproducible current candidate runs must be restored.

**Parents:** P00-02, P00-04. **Start after:** X01.

**Source/implementation/test anchors:** `web/docker-compose.yml`; `web/packages/db/prisma/schema.prisma`; `web/packages/db/prisma/rls.sql`; `web/packages/db/setup_roles.sql`; `web/apps/api/test/globalSetup.ts`; `web/apps/api/test/meltingPro.db.test.ts`; `web/apps/api/test/otherCommission.db.test.ts`; `web/apps/web/test/browser.smoke.mjs`; `web/apps/web/test/route-coverage.mjs`.

**Implementation and reconciliation sequence:**

1. Provision a dedicated disposable database on port 55433, or replace both hard-coded test guards with an equally strong explicit test-target identity check. Do not point mutation suites at the running app database merely because it is reachable.
2. Apply migration-owned schema, roles and forced RLS from scratch; separate owner setup credentials from non-owner runtime credentials. Fail drift, missing migrations and incorrect role assumptions.
3. Seed the fixture packs below and start matching API/web builds. Record health, build IDs, migration/lock hashes and source digest; do not infer running-container identity from local source.
4. Add a separate real-stack Playwright suite using actual login/context selection and requests, with independent DB assertions. Keep existing intercepted tests explicitly labelled mocked.
5. Prepare the isolated Windows desktop with Crystal dependencies and equivalent sanitized fixtures. Capture actions, prompts, intermediate amounts, outputs and before/after tables; report missing Windows resources as open dependencies.

**Required targeted verification:**

- Fresh migrations succeed twice into separate empty targets; owner/runtime role assertions pass.
- Both currently 55433-only suites run without exclusion; all required DB suites run with zero skips.
- A real-browser save creates rows; a response stub without the row must fail the test.
- Every dynamic report/master/book mode is enumerated, not represented by one placeholder URL.
- Wrong credentials, unavailable database, wrong schema and stopped API fail before business assertions; they cannot appear as successful empty cases.

**Close only when:** A single documented local/CI setup runs real browser/API/non-owner DB tests and independently attributable desktop captures. Required missing environments keep relevant acceptance open. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X04 — Author complete behavior contracts and numerical vectors

**Current classification:** contracts-and-engines-partial. Source-linked contracts, core calculators and golden vectors exist, including narrow Return prerequisites. They do not enumerate or certify every branch, setting interaction, numeric conversion and transition.

**Parents:** P00-05, P01-02. **Start after:** X01, X02.

**Source/implementation/test anchors:** `project-memory/contracts`; `web/apps/api/test/goldenVectors.test.ts`; `web/apps/api/src/modules/ops/contractIntegrity.ts`; `web/packages/core/src`; `web/apps/api/src/modules/shared`.

**Implementation and reconciliation sequence:**

1. Start with purchase, retail sale/return, tag opening, rate-cut receiving and lot manufacturing as reference contracts; then enumerate every remaining form/mode and non-form lifecycle action.
2. For each action record pre-state, role/book/settings, triggers, default/override precedence, validation and confirmation branches, effects, read/edit/reversal and error behavior.
3. Review all 28 unenforced-rule records against current code before implementing; record fixed-but-stale entries separately from genuine missing behavior.
4. Replace each missing formula link with a source-cited golden vector independently checked on desktop, or a reviewed non-calculated disposition. Do not copy a vector based on matching column names.
5. Cover signed midpoint rounding, rate/weight units, null/blank/zero, per-line/voucher rounding, customer/karigar valuation, date boundaries and maximum supported decimal precision.

**Required targeted verification:**

- Change each shared numerical policy in a temporary test copy: all affected family vectors and previews must fail.
- Explicit zero remains zero where permitted; omitted override invokes the configured derivation.
- Calculating a default twice does not freeze it as an operator override.
- An approved contract with missing source, field, branch, vector or mandatory case is rejected.
- Negative source-dead claims include all callers/settings/edition modes and runtime corroboration where source is incomplete.

**Close only when:** Every required leaf has an actionable contract and independent oracle; drafted or partially approved documents cannot close a family. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X05 — Close document identity, edits, concurrency and retries

**Current classification:** bounded-implementation-open. Sales/Tour session-bound command admission, exact imported scalar preservation and scoped image/version work have retained bounded evidence. Extend authoritative scope/rights, identity, snapshots, dependency locks and retry semantics across every document family.

**Parents:** P01-01, P01-04, P01-05. **Start after:** X03, X04.

**Source/implementation/test anchors:** `web/apps/api/src/modules/vouchers`; `web/apps/api/src/modules/posting/posting.ts`; `web/apps/api/src/modules/sales/orderDoc.ts`; `web/apps/api/src/routes/txn.ts`; `web/apps/web/lib/api.ts`.

**Implementation and reconciliation sequence:**

1. Build a per-table identity matrix including padded voucher/ledger keys, tag instances, parent/child serials and historical references; use full tenant/company/location/year/book/voucher scope where applicable.
2. Trace create/get/list/edit/delete/print/image/report consumers for each family. Correct OrderScope, orderData and its route to carry exact location and year into header/detail/party reads.
3. Define immutable identities and allowed correction transitions from desktop; preserve unchanged rows and source lineage.
4. Add optimistic version checks or a documented equivalent to prevent silent stale overwrite, plus transactional locks for stock, booking, outstanding and source allocation.
5. Implement stable idempotency keys for accepted mutations and response-loss recovery. Scope keys to operator/business operation and compare payload digest; dispatch external effects only after commit.

**Required targeted verification:**

- Same book/voucher/tag in two tenants, companies, locations and years returns exactly the selected document, including its print and image.
- Two tabs edit the same saved document: stale save conflicts without losing either draft.
- Concurrent sale/split/transfer of one tag and concurrent bill/order/booking allocation allow only valid consumption.
- Lose the response after commit and retry: one voucher/effect exists and the original result is returned; conflicting key reuse fails.
- Failure after header/detail preparation rolls back all required rows; locked or dependent source changes have no partial effects.

**Close only when:** All applicable lifecycle transitions are atomic, correctly scoped and conflict-safe, including documents and downstream consumers; domain tests plus real-browser cases prove it. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X06 — Replay exact posting footprints and reconcile history

**Current classification:** comparison-evidence-incomplete. Extract/replay/diff tools and retained comparison records exist. No fresh complete whole-product desktop differential is established, and the report comparison artifact is absent from this clone.

**Parents:** P01-03. **Start after:** X03, X04, X05.

**Source/implementation/test anchors:** `web/apps/api/integration/parity-extract-mssql.mjs`; `web/apps/api/integration/parity-extract-pg.mjs`; `web/apps/api/integration/parity-compare.mjs`; `web/apps/api/integration/parity-replay-generic.mjs`; `web/scripts/parity-measure.mjs`; `web/apps/api/src/modules/shared/rojmel.ts`.

**Implementation and reconciliation sequence:**

1. Freeze full expected case/table/key/column sets before capture; distinguish empty required tables from missing extraction.
2. Replay current web code from the same starting fixtures and configurations as the desktop, preserving provenance. Use synthetic cases for harness tests only; never derive expected desktop values from web output.
3. Classify each old difference as still present, now fixed by current code, extraction/mapping defect or reviewed deliberate behavior difference; retain both old and new evidence.
4. Compare headers/details/IDTL, ledger role/account/sign/key, Rojmel money and metal rows, stock, tax, outstanding, adjustments, tender identity, images and audits. Assert forbidden writes too.
5. Correct one business rule at a time and rerun its dependent families/reports. Review every excluded field and technical normalization; financial differences cannot be hidden by tolerance or field removal.

**Required targeted verification:**

- Missing/extra table, row, field, duplicate case and incomplete capture fail the comparator.
- Fully paid versus outstanding, mixed tender, negative/zero boundaries and multi-line components match complete footprints.
- Create, unchanged edit, changed edit and permitted reversal match both intermediate and final state.
- A balanced but wrong-account ledger fails; removing both balancing legs also fails.
- Retained old evidence cannot certify changed code or a new settings/template version.

**Close only when:** Every required family/mode has a current complete differential with zero unclassified business differences and all downstream balances reconciled. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X07 — Finish shared forms without flattening domain variants

**Current classification:** shared-ui-partial. Grid, child-detail, keyboard, lookup and calculation components exist. Each domain still needs a complete field/event/error/focus/throughput contract and real browser persistence proof; sharing a renderer is not per-form acceptance.

**Parents:** P02-01, P02-02, P02-03, P02-04. **Start after:** X04.

**Source/implementation/test anchors:** `web/apps/web/components/ExtendedGrid.tsx`; `web/apps/web/components/SubDetailGrid.tsx`; `web/apps/web/components/GridKeyboard.tsx`; `web/apps/web/components/FormKeys.tsx`; `web/apps/web/lib/lineRecalc.ts`; `web/apps/api/src/modules/shared/stoneSubDetail.ts`.

**Implementation and reconciliation sequence:**

1. Use a reference form with two parent rows, two different child collections, tender rows and source allocations; list all applicable control contracts before adding columns.
2. Support stable row/child identity, insertion/removal/reorder, numeric units/precision, lookup filters, derived read-only cells and explicit overrides.
3. Implement field-change/cell-exit dependency order through shared measured policies; retain per-form customer versus karigar valuation and receive-side differences.
4. Map each visible input and computed display to the exact route/writer/reader. Hidden IDs remain server-owned; displaying a database column is not an operator requirement.
5. Complete keyboard save/new/print, row navigation, append/delete, modal escape, focus after validation and remembered columns; observe F10 before assigning its action.

**Required targeted verification:**

- Distinct parent and child sentinel values survive browser save/reopen/unchanged save; reordering never moves a child to the wrong parent.
- Changing weight/touch/rate/labour updates every dependent value identically in UI/API/DB.
- Choose a lookup, cancel another lookup, paste values, scan a code and edit by keyboard; results agree.
- At 1366x768 operators can access every required field and total without losing the selected row.
- Adding a shared component does not mark untested caller modes complete.

**Close only when:** All applicable form controls and action transitions have real field-path evidence, plus measured operator throughput and accessible error/focus behavior. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X08 — Complete observable settings behavior

**Current classification:** settings-partial. Return configuration/width observation and versioned company/family/name Columns editing are bounded implementations. All setting default/precedence/effect branches remain to be reconciled by actual consumer.

**Parents:** P02-05. **Start after:** X02, X04.

**Source/implementation/test anchors:** `web/apps/api/src/modules/settings/settingsInventory.ts`; `web/apps/api/src/modules/shared/settingsBehavior.ts`; `web/apps/web/lib/companySettings.ts`; `web/apps/api/test/settingsEffect.db.test.ts`; `web/apps/api/test/settingsRealValues.test.ts`.

**Implementation and reconciliation sequence:**

1. Join setting identity by table/key and configured scope; catalogue actual desktop encodings, defaults, invalid values and consumers, including CO_MAST/TAG_SET/book/user preferences.
2. Trace load -> alias -> UI/server consumer -> persisted/report consequence. Reuse existing consumers before adding another policy layer.
3. Prioritize SL_TAG_WT_DIFF, CUR_DAY_POSTING, branch account visibility, weight/fine locks, negative stock, estimate/tax, rounding, print/image/copy settings and lot policies.
4. Implement effect cases per affected family and mode, with direct API enforcement where it governs accepted business state.
5. Document cache invalidation on company/year/user/book change and concurrent session changes; preserve historic recorded values when current defaults change.

**Required targeted verification:**

- For every behavioral setting, the same valid fixture under each supported value produces the independently expected outcome.
- Null, blank, zero, Y/N and numeric encodings are distinguished according to source.
- A loader read without an outcome assertion does not pass; a field disabled in UI still obeys policy in direct requests.
- CUR_DAY_POSTING changes the source-confirmed refresh scope, not an invented posting-date rule.
- Switch business settings while another tab has a draft; stale policies cannot silently alter accepted transactions.

**Close only when:** All settings have reviewed dispositions and effect evidence across required consumers; no regex-derived inert count is treated as a verified missing-feature total. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X09 — Preserve form sessions and resolve offline service behavior

**Current classification:** session-partial-service-undecided. Session lifecycle/browser draft guards have retained bounded proof. Broader writer coverage and the accepted internet/LAN/server outage service topology remain open; a cloud deployment cannot silently substitute for an offline-capable desktop.

**Parents:** P02-06. **Start after:** X01, X03.

**Source/implementation/test anchors:** `web/apps/web/components/BookSelect.tsx`; `web/apps/web/components/BusinessScope.tsx`; `web/apps/web/components/Shell.tsx`; `web/apps/web/lib/api.ts`; `web/deploy/docker-compose.prod.yml`.

**Implementation and reconciliation sequence:**

1. Document service requirements for internet outage, LAN loss, app/DB failure and device-bridge loss; identify which operations continue, queue or stop. Resolve intended local/LAN, cloud or disconnected-posting topology before dependent implementation.
2. Trace whether BookSelect and lookup callers remount on every business context change. Add explicit scoped invalidation where needed, retaining cancellation of stale fetch responses.
3. Preserve meaningful drafts, selected row and validation errors on recoverable failure, refresh and related-form navigation; define confirmation behavior before context change or draft discard.
4. Support consulting a ledger/master while an invoice remains open, with per-tab context isolation and stable saved preferences.
5. Implement recoverable posted-status display and retry via X05. If offline posting is required, specify local identity/stock ownership, permissions, rates, synchronization and conflict policy before coding it.

**Required targeted verification:**

- Two businesses use disjoint books; switching in place and with two tabs shows only the correct choices and values.
- Expired session during editing preserves draft; retry cannot post under a changed context.
- Navigate to a related master/ledger and back: row, children and totals remain intact.
- Exercise each agreed outage, server restart and reconnect; no ambiguous accepted sale, duplicated settlement or silent draft loss.
- Draft caching alone fails a requirement that ordinary sale posting continue without internet.

**Close only when:** A documented business service decision and tested session/outage behavior support the claimed operational scope. Unresolved topology remains an explicit dependency, not an assumed waiver. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X10 — Complete master data and fresh-business provisioning

**Current classification:** masters-partial. Generic and specialized masters plus company/year/setup code exist; recent column identity fixes apply narrowly. Fresh-company provisioning, conditional validation, imports, dependent references and real operator flows remain open.

**Parents:** P03-01, P03-02, P03-04, P03-05. **Start after:** X04, X07, X08.

**Source/implementation/test anchors:** `web/apps/api/src/modules/masters/master.service.ts`; `web/apps/api/src/modules/masters/configs.ts`; `web/apps/api/src/modules/masters/companyClone.ts`; `web/apps/api/src/modules/masters/stockLimit.ts`; `web/apps/api/src/modules/masters/year.ts`; `web/apps/web/app/(app)/masters/[name]/page.tsx`.

**Implementation and reconciliation sequence:**

1. Map desktop MS_ACCT/MS_ITEM/MS_PRODUCT/MS_LOCT/book/year/user/rate/labour/slab/counter/diamond variants to dynamic and specialized web masters.
2. Implement whole-row/settings/reference validations, code generation, text identity lengths, linked photos, credit/tax/bank data and parent-child policy collections.
3. Trace MS_LOCT provisioning of BOOK_DATA, BOOK_DETL and TABLE_MAST; implement missing atomic cloning and defaults rather than only inserting a location row.
4. Complete previewable scoped import/export with row-level errors, duplicate/reference policies and rollback; use the same business validation as individual edits.
5. Verify new company, branch and year can execute purchase, sale, tender and reports with their own configured accounts without SQL fixes.

**Required targeted verification:**

- Two shops use different book/account codes; both complete a first business day.
- Rich master reopen/save preserves conditional fields, child slabs and images; referenced deletions fail appropriately.
- Slab boundaries and item/party policies affect the intended transaction only.
- Malformed, duplicate, Unicode and leading-zero import rows produce precise outcomes without partial setup.
- Fail branch setup halfway: no partially usable book or permissions remain; year transitions preserve opening balances.

**Close only when:** All reachable master modes and imports are usable and validated, and independent configured-business setup has full-stack evidence. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X11 — Implement design components and complete design identity

**Current classification:** bounded-implementation-open. Design parent/components, repeat/calculation, source-shaped Sales lookup and images have retained bounded work. Finish shared lookup/create settings, all consumers, image provenance and independent desktop comparisons.

**Parents:** P03-03. **Start after:** X04, X07.

**Source/implementation/test anchors:** `unified/src/csharp/DataCareNext/MS_DESIGN_BOOK.cs`; `web/apps/api/src/modules/masters/designBook.ts`; `web/apps/web/app/(app)/masters/design-book/page.tsx`; `web/apps/api/test/designBook.db.test.ts`.

**Implementation and reconciliation sequence:**

1. Extract DESIGN_DETL/DESIGN_IDTL ownership, serials, defaults, customer/karigar calculations and image lookup from the desktop handlers; do not infer keys from design number alone.
2. Extend the input, validation, atomic save, reader and deletion paths with per-parent component collections and explicit retained identities.
3. Add child editing to the dedicated screen and preserve hidden identities on unchanged save and parent reorder.
4. Associate images by the complete entity key and preserve them through order/manufacturing conversion.
5. Implement source-confirmed fine, rate basis, labour/other/net cost and MRP derivation/overrides using X04 policies.

**Required targeted verification:**

- Two books and two products share a design number but retain different children/images.
- Two components per parent carry distinct weight, conversion, customer and karigar values through browser/API/DB/reopen.
- Remove one child and reorder parents: remaining serials and ownership are unchanged.
- Unchanged save preserves every business column and image association; failed child validation rolls back the entire edit.
- Select the design in an order and manufacturing issue: the correct specification and photo follow it.

**Close only when:** Desktop parent/child/image behavior is complete and independently compared, including downstream design specification use. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X12 — Close every purchase and supplier lifecycle

**Current classification:** existing-lifecycle-unverified. Purchase/return/hallmark/quotation modules and lifecycle tests exist. Whole supplier lifecycle, mode depth, source linkage, tender/outstanding/reversal and downstream reports remain unaccepted; no recent card closure is recorded.

**Parents:** P04-01, P04-02, P04-03, P04-04, P04-05. **Start after:** X05, X06, X07, X08, X10.

**Source/implementation/test anchors:** `web/apps/api/src/modules/purchase`; `web/apps/web/app/(app)/txn/purchase/page.tsx`; `web/apps/web/app/(app)/txn/purchase-hm/page.tsx`; `web/apps/web/app/(app)/txn/purchase-return/page.tsx`; `web/apps/api/test/purchase.lifecycle.db.test.ts`; `web/apps/api/test/purchaseQuotation.db.test.ts`.

**Implementation and reconciliation sequence:**

1. For each TR_PURC/TR_PURC_HM menu/book variant, map main, receive/return, IDTL, totals and tender fields through its own writer/reader.
2. Reuse quotation/old-item/consignment paths after checking their effect exclusions; a quotation must not accidentally consume stock or post an ordinary payable.
3. Complete source selection for supplier return, remaining quantity/components, original price/tax and permitted historical references.
4. Finish cash/bank/cheque/card/UPI/advance/kasar identities, bill allocation and correct configured ledger/Rojmel roles.
5. Drive supplier creation -> rich purchase -> tag/lot availability -> partial return -> mixed settlement -> supplier/stock/tax reports -> permitted correction through real screens.

**Required targeted verification:**

- Two configurations, mixed gold/silver, two lines and two components each preserve all header/line/child fields.
- Zero/disabled tax, blank/zero rate and manual overrides match each book contract.
- Fully paid and outstanding purchases have exact different row footprints; mixed tender identities are retained.
- Over-return, repeated source selection, settlement over-allocation and source edits after dependencies fail without effects.
- Unchanged edit and return cancellation preserve/restores exact stock, source balances, liability and report totals.

**Close only when:** Every purchasing variant and the complete supplier journey passes independent desktop, real-browser, DB and report acceptance. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X13 — Close retail, wholesale, labour and return depth

**Current classification:** mixed-legacy-and-diagnostic-partial. Legacy POST /sales-returns actively calls createSaleReturn. The exported editSaleReturn helper retains numeric delete/rebuild logic but is not imported or registered in txn.ts, so it is not a generic numeric edit HTTP surface. The routed saved edit is PUT incoming-metadata; none of these distinct paths is certified by new preview tests. The new saved incoming Return replay/storage/effect/guard path remains diagnostic (canCommit:false), with no new numeric Update endpoint/Save UI or trusted known closing. Ordinary Sales/wholesale/labour/Return family breadth remains open.

**Parents:** P05-01, P05-02, P05-03, P05-08. **Start after:** X05, X06, X07, X08, X10.

**Source/implementation/test anchors:** `web/apps/api/src/modules/sales/sales.ts`; `web/apps/api/src/modules/sales/salesReturn.ts`; `web/apps/api/src/modules/sales/wholesaleSaleReturn.ts`; `web/apps/api/src/modules/sales/labourInvoice.ts`; `web/apps/api/src/modules/sales/rateCut.ts`; `web/apps/web/app/(app)/txn/sales/page.tsx`; `web/apps/api/test/salesFamilyLifecycle.db.test.ts`.

**Implementation and reconciliation sequence:**

1. Enumerate TR_SALE/TR_SALE_HM/TR_WH_SALE/TR_SALE_LBR/return/fine-sale modes with their independent field/action contracts.
2. Complete applicable source picks, issued and received grids, IDTL sets, old gold, order/scheme redemption, HUID/cost/commission, manual rates and tender identities.
3. Preserve wholesale isuRef mapping noted in X02; verify it by persisted columns instead of deleting the fields to silence a scanner.
4. Provide actual source-invoice return selection with remaining components, original pricing/tax/cost and permitted refunds/credits; correct dependency locks and reversal.
5. Verify all lines, settlement bands, invoice/credit documents and sales/stock/outstanding/tax/commission reports from real UI.

**Required targeted verification:**

- Tagged scan, manual untagged sale, mixed old-gold exchange and component-heavy invoice complete on both configured shops.
- Issued-only, received-only and two-sided wholesale/labour cases keep their distinct customer/karigar valuations.
- Partial/full/repeated return, over-return and cancellation conserve source availability and stock.
- Per-piece/per-weight basis, blank/zero/override and taxable/non-taxable modes agree in preview/API/DB/print.
- Failed save, concurrent consumption and no-change reopen cannot duplicate sale effects or lose rich values.

**Close only when:** Each sales variant and supported return journey has complete operator and effect parity, including all dependent settlement and reporting. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X14 — Complete Tour Order, quotations and fulfillment conversion

**Current classification:** bounded-implementation-open. Ordinary Sales/Tour Order New/create/load/edit/delete and exact imported-value/session-bound command work have retained tests. Fulfillment, reservation, conversion, tender/refund, quotations and every source/setting branch remain open.

**Parents:** P05-04, P05-06. **Start after:** X05, X07, X11.

**Source/implementation/test anchors:** `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs`; `web/apps/api/src/modules/sales/salesOrder.ts`; `web/apps/web/app/(app)/txn/tour-order/page.tsx`; `web/apps/web/app/(app)/txn/sales-order/page.tsx`; `web/apps/web/app/(app)/txn/sales-quotation/page.tsx`; `web/apps/api/test/tourOrder.db.test.ts`.

**Implementation and reconciliation sequence:**

1. Reuse TOUR ORDER API wrappers; add BookSelect constrained to the correct MAIN_BOOK and forward the selected book/location/year on list/create/get/edit/delete/print. Remove 510 as an unconditional list/print identity.
2. Implement selected-voucher hydration and PUT from the browser, including every header, line, component, image and advance; separate new/edit/cancel state and stale version handling.
3. Capture quotation-to-order/invoice, partial order manufacturing/delivery and source adjustments from desktop. Add explicit source selection and conversion lineage rather than copying rows without consumption.
4. Keep money/fine advances, production balance, tag reservation and delivered quantities separate. Release each only on its corresponding reversal.
5. Implement cross-book transfer only from the measured full reference graph; renumbering alone is not transfer.

**Required targeted verification:**

- TOUR ORDER books 510 and 511 plus a nonstandard configured code work; a SALES ORDER book is rejected in Tour Order.
- Create -> close -> select -> unchanged edit -> changed child -> delete through the screen; get/print/list agree on the selected scope.
- Two partial deliveries exhaust one order exactly; canceled delivery restores its allocation.
- Repeated/stale conversion, excess allocation, source deletion, locked destination and identity collision fail atomically.
- Order -> multiple karigars -> receipts -> tags -> invoice preserves specification, images, advances and source identity.

**Close only when:** All order/quotation/conversion actions are reachable without manual SQL, with correct balances, book scope and independently compared documents. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X15 — Implement the full E Credit Note document workflow

**Current classification:** read-provider-slice-writer-missing. Scoped saved E Credit Note read and existing-document IRN behavior are bounded slices. A dedicated complete E CRNT document create/edit/delete/print lifecycle is not implemented according to current card evidence.

**Parents:** P05-01, P11-03. **Start after:** X04, X05, X07.

**Source/implementation/test anchors:** `unified/src/csharp/DataCareNext/TR_SL_EBILL.cs`; `web/apps/web/app/(app)/txn/e-crnt-note/page.tsx`; `web/apps/api/src/modules/einvoice/einvoice.ts`; `web/apps/api/src/routes/txn.ts`; `web/apps/api/test/ecreditNoteIrn.db.test.ts`.

**Implementation and reconciliation sequence:**

1. Read TR_SL_EBILL save/open/delete/browse/print and E CRNT branches; record full header/item/tax/reference fields and exact allowed/forbidden stock, ledger, Rojmel and tax effects. Do not assume an ordinary sale or return writer is equivalent.
2. Implement explicit E CRNT create/get/list/edit/delete domain and route paths (new names are to be chosen consistently), selected-book validation and full-scope readers.
3. Replace the IRN-only form with complete entry, browse, reopen/edit, permitted deletion and document preview/print; retain existing IRN submission as a saved-document action.
4. Preserve invoice/source references, document type CRN, book series and totals; match rounding/zero-tax/discount cases to historical source contracts.
5. Add provider submit/status/retry/cancel and post-IRN edit restrictions according to measured desktop behavior and current provider requirements verified during X28; expose real pending/failed/live states.

**Required targeted verification:**

- Create a new credit note entirely through web UI with no SL_DATA fixture insertion; reopen and compare every applicable field/effect.
- Same voucher number in sale and two E CRNT books remains independent; print and IRN use only the selected one.
- Mixed item/tax, zero-tax, discounts, blank optional references and multi-page credit note match expected data.
- Unchanged/changed edit and permitted deletion preserve identities and exact reversible effects.
- Provider timeout after acceptance, retry and cancel resolve one real document status; fake-provider tests remain labelled engineering evidence.

**Close only when:** An operator can create and complete the credit-note lifecycle in web, including documents and provider state. Existing fake-GSP persistence tests alone cannot close it. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X16 — Complete finance, booking and two-sided rate-cut journeys

**Current classification:** existing-lifecycle-unverified. Finance/receipts/payments/journals/booking/rate-cut code exists. Two-sided cuts, exact ledger/fine identities, settlement allocation, partial/retry/reversal and accountant-accepted closing remain open.

**Parents:** P06-01, P06-02, P06-03, P06-04, P06-05, P06-06. **Start after:** X05, X06, X07, X08.

**Source/implementation/test anchors:** `web/apps/api/src/modules/finance`; `web/apps/api/src/modules/sales/rateCut.ts`; `web/apps/api/src/modules/inout/fineInout.ts`; `web/apps/web/components/PaymentForm.tsx`; `web/apps/web/app/(app)/txn/rate-cut/page.tsx`; `web/apps/api/test/rateCutSettlement.db.test.ts`.

**Implementation and reconciliation sequence:**

1. Verify cash/bank/contra/journal/opening/fine-transfer/bill-to-bill/clearance variants against their own MAIN_BOOK roles and money/metal signs.
2. Preserve per-line cheque/UPI/card/bank identity, payee, charges, dates, account slots and debit/credit/kasar directions. Do not replace identity rows with header totals.
3. Reuse rate-cut receive writer/reader/reversal and expose all received-line/child/settlement values; reconcile PR_* totals and both money/fine legs with issue-side results.
4. Implement multi-party booking and remaining fine/quantity/rate allocation, including basis per piece/gram/ten grams/kg, conversion, premium and ADJ_WT lifecycle.
5. Finish due-date/aging and residual bill selectors and run opening -> purchase/sale -> mixed payments -> allocation -> clearance -> journal/fine transfer -> closing reports.

**Required targeted verification:**

- Issued-only, received-only, two-sided and zero/blank-rate cuts match desktop for each permitted basis and sign.
- Split UPI/cheque payments preserve distinct identities and correct book-specific role codes.
- Two simultaneous settlements/booking drawdowns cannot overconsume; refund/delete releases only its own allocation.
- Changed source totals, locked periods and cross-year historical settlements follow explicit rules.
- Trial balance, daybook, bank statement, fine outstanding and supplier/customer balance each reconcile to source documents, not merely aggregate zero.

**Close only when:** All accounting variants and complete business closing have desktop/DB/report agreement and accountant acceptance. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X17 — Join approval, consignment, tour, parcel and repair stages

**Current classification:** custody-lifecycle-partial. Tour/repair/parcel code and repair image identity/version fixes exist. Full approval/consignment/partial custody/receipt/delivery/settlement/cancellation workflows and reconciliation remain open.

**Parents:** P05-05, P05-07, P05-08. **Start after:** X05, X07, X13.

**Source/implementation/test anchors:** `web/apps/api/src/modules/tour`; `web/apps/api/src/modules/repair`; `web/apps/api/src/modules/sales/vpParcel.ts`; `web/apps/web/app/(app)/txn/tour/page.tsx`; `web/apps/web/app/(app)/txn/tour-return/page.tsx`; `web/apps/web/components/RepairImagePanel.tsx`.

**Implementation and reconciliation sequence:**

1. Map TR_APR_ISU/TR_TOUR/TR_TOUR_ORD/TR_TOUR_SALE/TR_VP/TR_VP_ADJ and repair callers by issue/return/sale/delivery state and permissions.
2. Implement remaining source selectors, available issued tags/components, photos, responsibility/location, promised dates and stage history.
3. Keep customer-owned repair custody distinct from business-owned stock; connect estimate/labour/charges and final settlement.
4. Support mixed partial sale and return from one issue and partial karigar repair receipt before final customer delivery.
5. Add dependency-protected stage corrections and reverse the actual source allocation, image/reference and financial effects.

**Required targeted verification:**

- Issue multiple items -> sell one -> return another -> reconcile still-out state and source availability.
- Duplicate import and over-return fail; cancellation cannot release stock already consumed downstream.
- Repair receive -> issue -> partial return -> completion -> customer delivery/refund retains custody and images.
- Branch responsibility change, missing photo, device failure and stage reversal produce defined recoverable states.
- Customer, employee/karigar, stock and outstanding reports explain every movement.

**Close only when:** All required custody and repair journeys finish through real screens with exact state, settlement and document continuity. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X18 — Complete stock identity/openings and certify tag transfer

**Current classification:** mixed-opening-and-contained-transfer. Rich tag-opening roundtrip is separately discharged in containment source, with cited tests; inventory identity/openings still require full acceptance. Tag-transfer remains explicitly disabled and cannot inherit tag-opening evidence.

**Parents:** P07-01, P07-02, P07-03. **Start after:** X05, X06, X07.

**Source/implementation/test anchors:** `web/apps/api/src/modules/stock/stockInout.ts`; `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts`; `web/apps/api/src/modules/stock/tagOps.ts`; `web/apps/api/src/modules/stock/tagInvariants.ts`; `web/apps/api/test/tagOpeningRoundTrip.db.test.ts`; `web/packages/core/containment.mjs`.

**Implementation and reconciliation sequence:**

1. Define available/reserved/issued/sold/returned/canceled/replaced/split tag states by exact tag instance and table-specific serial; align lookup, reports and locks.
2. Reverify item/tag/lot openings, stock in/out and adjustments with complete HUID weights, component costs, images, counters and purchase/manufacturing lineage through browser payloads.
3. Trace transfer mode in TR_TAG_CAN and related stock helpers; reuse current domain work after comparing exact old/new BAR/IDTL/image and stock identities.
4. Implement complete transfer list/open/edit/delete, destination/location/counter rules, shared locks and source/destination reversal.
5. Evaluate transfer containment separately; update stale explanatory text without removing the block until its own desktop, lifecycle and concurrency evidence passes.

**Required targeted verification:**

- Two live/historical instances share a visible tag number; transfer selects exactly the intended serial.
- Rich opening unchanged save preserves all business columns, children and images; linked stock blocks invalid deletion.
- Transfer across permitted counters/locations preserves pieces/gross/net/fine/components/cost and lineage.
- Concurrent transfer versus sale, invalid destination and midway failure leave one valid state.
- Reverse/edit transfer only when dependency rules permit; reports match before/after desktop snapshots.

**Close only when:** Stock state is consistent everywhere and transfer has its own complete release evidence. Other contained tag operations remain separately gated. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X19 — Certify tag cancellation independently

**Current classification:** contained. Tag cancellation is explicitly blocked by parityContainmentRules. Correct live identity, source/subdetail lineage, dependencies, reversal and concurrent conflicts need independent release proof.

**Parents:** P07-03. **Start after:** X18.

**Source/implementation/test anchors:** `unified/src/csharp/DataCareNext/TR_TAG_CAN.cs`; `web/apps/api/src/modules/stock/tagOps.ts`; `web/apps/api/test/tagCancelIdentity.db.test.ts`; `web/apps/web/app/(app)/txn/tag-cancel/page.tsx`; `web/packages/core/containment.mjs`.

**Implementation and reconciliation sequence:**

1. Extract cancellation-specific live serial, source references, tag lot/polish/target-table inputs and permitted dependent states; distinguish transfer mode.
2. Audit existing cancel reader/writer/reversal against complete BAR detail, child, image and source lineage requirements.
3. Complete browser selection/open/edit/delete and validation/error focus for only operator-editable fields.
4. Use shared stock locks and exact availability checks; preserve a discoverable cancel audit/history.
5. Lift only cancellation containment after reviewed evidence meets the stated gate; neither a helper test nor HTTP 200 is sufficient.

**Required targeted verification:**

- Cancel exactly one intended live serial with a historical same-number serial present.
- Consumed/reserved/issued tags are handled according to the measured dependency rules.
- Unchanged/changed cancel and permitted reversal preserve rich details and restore availability exactly.
- Concurrent sale or transfer yields one permitted transition; a denied/failing cancel writes nothing.
- Stock, component, image lineage and desktop cancel document/state match.

**Close only when:** Cancellation can be completed and reversed through the allowed web lifecycle with independent evidence, without changing other tag release states. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X20 — Complete atomic tag split and child conservation

**Current classification:** contained. Tag split is explicitly blocked; current simplified stock movement does not establish parent consume/child serial/detail/image lineage. Atomic conservation plus complete create/reopen/reverse evidence is mandatory.

**Parents:** P07-04. **Start after:** X18.

**Source/implementation/test anchors:** `web/apps/api/src/modules/stock/tagSplit.ts`; `web/apps/api/src/modules/stock/tagInvariants.ts`; `web/apps/web/app/(app)/txn/tag-split/page.tsx`; `web/packages/core/containment.mjs`.

**Implementation and reconciliation sequence:**

1. Resolve actual desktop split dispatch and input/output/settlement grids; author quantity, weight, fine, cost and component allocation equations.
2. Verify/complete atomic parent consumption, unique child serial allocation, BAR headers/details/IDTL, images, parent links, stock and any measured financial effects.
3. Implement unequal child allocations and explicit residual/wastage/rounding policy; never silently drop remainders.
4. Expose complete child values and source selection with read/edit/delete and downstream-consumption locks.
5. Release only the split operation after its own complete artifact set.

**Required targeted verification:**

- Unequal split with at least three children, two components and images conserves all applicable measures at source precision.
- Duplicate child IDs, empty children, over-allocation and invalid mixed output items fail atomically.
- Concurrent parent sale/split allows only one valid consumption.
- Inject failure after preparing some children: no orphan barcode, image or stock row remains.
- Changed split and reversal preserve identity and refuse invalid downstream dependencies.

**Close only when:** Desktop-equivalent parent/child state, conservation, lifecycle and real-browser behavior are demonstrated before split containment removal. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X21 — Complete weight replacement and sale-driven tag differences

**Current classification:** contained-and-unverified. Standalone weight difference is explicitly blocked. Source-shaped tag replacement/image/barcode/Rojmel/karigar branches and separate sale-driven SL_TAG_WT_DIFF obligations remain.

**Parents:** P07-05. **Start after:** X18, X08.

**Source/implementation/test anchors:** `web/apps/api/src/modules/stock/tagOps.ts`; `web/apps/web/app/(app)/txn/tag-weight-diff/page.tsx`; `web/apps/api/src/modules/shared/settingsBehavior.ts`; `web/apps/api/src/modules/sales/sales.ts`; `web/packages/core/containment.mjs`.

**Implementation and reconciliation sequence:**

1. Trace the actual old/new tag replacement contract and Ac_Stock sale-driven SL_TAG_WT_DIFF branches; keep distinct requirement IDs.
2. Verify/complete serial linkage, barcode detail, IDTL, HUID weights, images, karigar values, settlement, Rojmel and stock effects; net-stock adjustment alone is insufficient.
3. Provide source/live-instance selector, derived differences and complete reopen/edit/reversal paths.
4. Apply common tag locks and dependency restrictions; bind financial effects to configured account slots.
5. Retain containment until all replacement branches, including no-change and source-consumed behavior, have independent results.

**Required targeted verification:**

- Positive, negative and no-change weight differences agree on old/new tag and movement state.
- Tagged and permitted untagged cases retain components/images and exact reference serials.
- Toggle SL_TAG_WT_DIFF on the same sale fixture and compare source-confirmed special stock rows.
- Concurrent sale/replace and failed replacement leave no mixed identity or half-posted settlement.
- Unchanged edit and allowed reversal reproduce full rich state, not just total net weight.

**Close only when:** Both explicit replacement and sale-driven weight-difference contracts are satisfied with separate evidence and correct release disposition. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X22 — Finish physical stock sessions and inventory reconciliation

**Current classification:** existing-lifecycle-unverified. Physical stock session/report code and tests exist. Full count/finalize/retry/discrepancy/reversal/concurrent stock-change behavior is not business-accepted.

**Parents:** P07-06. **Start after:** X18.

**Source/implementation/test anchors:** `web/apps/api/src/modules/stock/physicalStock.ts`; `web/apps/api/src/modules/reports/physicalStock.ts`; `web/apps/web/app/(app)/txn/physical-stock/page.tsx`; `web/apps/api/test/physicalStock.db.test.ts`.

**Implementation and reconciliation sequence:**

1. Define count-session identity, cutoff/snapshot and permitted counter/location/lot filters from the desktop workflow.
2. Implement scan/manual input, expected versus counted quantities, duplicate/unknown/wrong-location feedback and component differences.
3. Define handling of stock movement during counting and require a preview of every adjustment before supported finalization.
4. Make finalize atomic/idempotent with traceable adjustment references, cancel/reopen rules and report drill-back.
5. Connect HUID, movement, valuation, stock-level and component outputs to the same stock-state contract.

**Required targeted verification:**

- Duplicate scans do not double-count; unknown and wrong-location tags are visible exceptions.
- A sale after the snapshot is reconciled explicitly rather than silently overwritten by count finalization.
- Two finalization attempts post one permitted adjustment set.
- Missing/extra tags, weight/piece/component differences and canceled sessions match desktop rules.
- Preview, posted adjustments and stock reports agree exactly.

**Close only when:** A stock clerk can count, resolve discrepancies and finalize/reverse as allowed, with complete stock and report reconciliation. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X23 — Complete manufacturing variants and the lot workflow

**Current classification:** read-slice-plus-existing-lifecycle. Manufacturing/karigar/melting code exists; Setting Isu/Rec bounded browse/read/component/source selectors and component-lot DDL are retained. Setting Isu/Rec writes remain unavailable; complete lot/partial receipt/order/rework/material/financial journeys remain.

**Parents:** P08-01, P08-02, P08-03, P08-04, P08-05, P08-06. **Start after:** X04, X05, X07, X11, X18.

**Source/implementation/test anchors:** `unified/src/csharp/DataCareNext/TR_MFG_WITH_LOT.cs`; `web/apps/api/src/modules/manufacturing/mfg.ts`; `web/apps/api/src/modules/manufacturing/karigar.ts`; `web/apps/api/src/modules/manufacturing/melting.ts`; `web/apps/api/test/mfgLifecycle.db.test.ts`; `web/apps/api/test/meltingPro.db.test.ts`; `web/apps/web/components/KarigarForm.tsx`.

**Implementation and reconciliation sequence:**

1. Create state/transition and material conservation contracts for order/free/stage/karigar/jobwork/ghat/jadtar/item/lot/melting modes; inspect all MFG source callers and stock flags.
2. Reuse generic issue/receive logic only where the variant contract matches. Add dedicated TR_MFG_WITH_LOT routes/screen or a proven explicit mode with source-lot selectors and full read/edit/delete; name any proposed path as new until implemented.
3. Complete lot balance locking and partial consumption, source serials, component return/breakage, chole/ghis/ghat/other losses, customer/karigar valuation and payment/received rows.
4. Join order/design -> issue/reissue -> partial receipt/rework -> stage completion -> tagging -> delivery/sale, preserving photos and specification.
5. Verify melting multiple inputs/outputs, assay changes, loss/byproducts/residual fine and financial settlement. Run the dedicated 55433 suite without exclusion.

**Required targeted verification:**

- Lot issue -> first partial receipt -> second receipt -> exhausted lot; over-receipt and concurrent drawdown fail.
- Several lots and components with distinct source serials preserve allocation and return/breakage through edit/reopen.
- One order across multiple karigars/receipts and unfinished work across a year boundary remains traceable.
- Multiple melting inputs/outputs with changed purity reconcile physical material and fine against explicit losses.
- Failed intermediate stage, reissue, canceled receipt and downstream sale dependencies preserve valid WIP, lot, karigar and stock balances.

**Close only when:** Every manufacturing variant and the full manufacturing business day works in browser with exact material/financial/report evidence; a lot report cannot satisfy the transaction requirement. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X24 — Certify loan, dhiran and scheme business continuations

**Current classification:** existing-lifecycle-unverified. Dhrn/loan/scheme lifecycle modules and tests exist. Distinct issue/receipt modes, date/interest/arrears/default/custody/redemption histories and independent business acceptance remain open.

**Parents:** P09-01, P09-02, P09-03, P09-04, P09-05. **Start after:** X04, X05, X07, X16.

**Source/implementation/test anchors:** `web/apps/api/src/modules/dhrn/dhrn.ts`; `web/apps/api/src/modules/membership/scheme.ts`; `web/apps/web/app/(app)/txn/loan-issue/page.tsx`; `web/apps/web/app/(app)/txn/loan-received/page.tsx`; `web/apps/web/app/(app)/txn/scheme/page.tsx`; `web/apps/api/test/dhrnLoanLifecycle.db.test.ts`; `web/apps/api/test/schemeGoldAdjust.db.test.ts`.

**Implementation and reconciliation sequence:**

1. Reconcile each desktop loan/dhiran/khata/opening/interest menu direction and book; preserve borrower, pledge-item, photo, valuation and custody identity.
2. Complete source-cited monthly/daily interest, inclusive-date/year basis, principal changes, backdates, blank/zero/manual override and reversal behavior.
3. Implement full enrollment/member/nominee/terms and installment history with tender identities; distinguish scheme from points/loyalty.
4. Join arrears/prepayment/bonus/maturity/gold-money adjustment/refund/invoice redemption and canceled invoice release with atomic available-balance control.
5. Prove the same operations against migrated open loans and partially paid schemes, using historical terms rather than silently applying current defaults.

**Required targeted verification:**

- Month ends, leap day, same-day receipt, partial principal and explicit zero interest match independent vectors.
- Pledge -> disbursement -> interest/principal -> closure/release preserves item custody and receipts.
- Enroll -> split installments -> mature -> partial redemption -> invoice return/cancel reconciles money/fine and member history.
- Concurrent redemption, duplicate payment, source receipt deletion after adjustment and over-refund are rejected correctly.
- Passbook, loan ledger, scheme commission/balance and accountant reports match full saved state across branches/years.

**Close only when:** Every loan/scheme mode and normal/exception continuation has real operator, desktop, calculation, custody and report acceptance. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X25 — Complete scoped document binding and actual child output

**Current classification:** document-binding-partial. Five explicit order template/image variants and scoped image revisions have retained proof, within registry 28. Older inferred template bindings remain contained; every required layout/copy/export/physical printer outcome still needs source comparison.

**Parents:** P10-01, P10-05, P10-06. **Start after:** X05, X07.

**Source/implementation/test anchors:** `web/apps/api/src/modules/reports/reportBind.ts`; `web/apps/api/src/modules/sales/orderDoc.ts`; `web/apps/api/src/routes/txn.ts`; `web/apps/api/test/reportBind.test.ts`; `web/apps/api/test/reportRender.db.test.ts`; `unified/src/csharp/DataCareNext/MS_PRINT.cs`.

**Implementation and reconciliation sequence:**

1. Replace inference-only primary-table detection with explicit template/mode bindings containing required header/detail/child datasets, joins, parameters and formats. Preserve explicit unsupported errors.
2. Read actual IDTL children keyed to their exact parent; do not synthesize child aliases from a parent detail row. Handle template subreports/groups/formulas according to extracted and runtime evidence.
3. Correct order document location/year scope and audit all direct document renderers, not just /reports/render.
4. Match selection/preview/print/cancel, original/duplicate/triplicate, default focus, book/branch formats, headers/footers, images, signatures, QR/barcodes and reprint history.
5. Preserve data and authorization through PDF/CSV/XLSX and report-to-voucher drill-down. Keep business fields and totals exact; visual tolerances apply only to rasterization.

**Required targeted verification:**

- Two children with distinct values print as two correct child records, with no parent-value substitution or duplication.
- Same-number vouchers in two locations/years produce independent header/detail/child/party results.
- Unknown or ambiguous templates refuse; they cannot render sales as a fallback.
- One-line, long Unicode description, many-line/multi-page, missing image, return/negative and large-number documents match desktop data/layout.
- Copy labels, preview versus physical print, default printer/template and restricted-role direct render/export behavior meet the contract.

**Close only when:** Each supported document renders correct scoped data including children and has independent semantic, visual and required physical print evidence. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X26 — Close the complete report and mode universe

**Current classification:** report-comparison-incomplete. Report routes, filters, rights, registry and datasets exist. Every required report/mode, historical drilldown, export and independently captured desktop dataset/layout needs a complete comparison; current report-comparison-latest.json is absent.

**Parents:** P10-02, P10-03, P10-04, P10-07. **Start after:** X01, X06, X25.

**Source/implementation/test anchors:** `parity-plan-2026-09-10/evidence/report-register.json`; `web/apps/api/src/modules/reports/reportAuthorization.ts`; `web/apps/api/src/modules/reports/reportFilters.ts`; `web/apps/api/src/modules/reports`; `web/apps/web/app/(app)/reports/[report]/page.tsx`.

**Implementation and reconciliation sequence:**

1. Map all report screens, launcher parameters, direct routes, supplied Crystal files and absent references to explicit required report/mode IDs. Reuse newly implemented report families after contract verification.
2. Extract formulas, parameters, grouping/sort/subreport/suppression/running-total behavior and dynamic template selection; resolve missing artifacts through X32.
3. Complete financial/accounting/GST/outstanding/interest/aging/valuation modes and stock/WIP/lot/order/customer/scheme/tour/graph/audit specialists, with all applicable filters.
4. Define blank/all/single/multiple/invalid/unsupported filter semantics and enforce them consistently on direct routes and exports.
5. Produce report-comparison evidence per expected mode, fixture and candidate with rows/columns/totals, semantic differences, PDFs/images and operator acceptance; feed exact-set gate X34.

**Required targeted verification:**

- All required report IDs return a result, including valid empty datasets; missing/skipped/duplicated reports fail.
- Different party/group/location/year/metals/valuation filters select the independently expected rows and totals.
- Transactions from X12–X24 reconcile to daybook, stock, outstanding, financial and specialist reports.
- View/print/export permissions and drill-back preserve original scope and filter context.
- Removing one mandatory report from an otherwise all-pass result must fail certification.

**Close only when:** Every required report/mode is independently compared and approved; endpoint count and web-only layout baselines cannot substitute. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X27 — Complete correction and bulk utility reference closure

**Current classification:** utilities-unverified. Utilities/corrections/import/export modules exist. Full dependency graph, scope, atomicity, rollback/recovery, audit and historical continuation need per-operation qualification.

**Parents:** P11-01. **Start after:** X05, X06, X08.

**Source/implementation/test anchors:** `web/apps/api/src/modules/utilities`; `web/apps/api/src/modules/vouchers`; `web/apps/web/app/(app)/utilities/data-repair/page.tsx`; `web/apps/web/app/(app)/utilities/data-export/page.tsx`; `web/apps/web/app/(app)/utilities/estimate-reset/page.tsx`; `web/apps/api/test/correctionWorkflow.db.test.ts`.

**Implementation and reconciliation sequence:**

1. Trace desktop user-request correction separately from ordinary allowed edits/deletes; preserve requested action, review/authority, reason and history where required.
2. Build reference graphs for renumber, cross-book transfer, refresh, reset, balance transfer, import/export and year-end; include detail/child, UPI, ledger, stock, tax, allocations, images and historical sources.
3. Implement preview, authorized execution, progress, cancellation/interruption semantics and deterministic before/after reconciliation.
4. Apply CUR_DAY_POSTING full/from-date stock-refresh behavior from source; avoid a guessed date restriction.
5. Keep scope-limited changes atomic and repeat-safe; revalidate all reports and source-link readers affected by key changes.

**Required targeted verification:**

- Preview equals actual touched keys/rows/effects on the frozen fixture.
- Two companies/years sharing keys remain unaffected outside the selected operation.
- Interrupt midway, retry, encounter collision/locked period/dependency: no partial reference rewrite remains.
- Repeated reset/refresh cannot duplicate effects; missing required source data fails instead of empty success.
- Related records remain discoverable and printable after renumber/transfer/correction.

**Close only when:** Every required utility finishes its supported business operation with complete reference integrity, recovery and audit evidence. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X28 — Validate devices and real provider state machines

**Current classification:** adapters-unverified. Device/provider adapters and protocol tests exist. Actual shop hardware, reconnect/uncertain outcomes and provider sandbox/production state machines have not achieved full-product acceptance.

**Parents:** P11-02, P11-03. **Start after:** X09, X15.

**Source/implementation/test anchors:** `web/apps/api/src/modules/integrations`; `web/apps/api/src/modules/einvoice`; `web/apps/api/src/modules/integrations/messaging.ts`; `web/apps/api/test/scaleProtocol.test.ts`; `unified/src/csharp/DataCareNext/OlockerService.cs`; `unified/src/csharp/DataCareNext/TR_SALE.cs`.

**Implementation and reconciliation sequence:**

1. Inventory required OS/browser/scale/scanner/camera/A4/thermal/tag/cheque printer combinations and protocols from actual shops; document installation/pairing/permissions and local bridge responsibility.
2. Implement stable/tare/unit/precision handling, scanner terminators/focus/duplicates, image capture/ownership and printer-copy/media behavior using existing adapters where valid.
3. Trace saved/reopened invoice Olocker action and its fields/status/print or policy effects; implement any confirmed missing capability with explicit saved-document linkage.
4. Verify official current GSP/messaging/rate/provider documentation during implementation, record versions, and distinguish historical compatibility from accepted current requirements.
5. Persist submission/attempt/provider identities and pending/status/retry/cancel states; handle provider success followed by local persistence failure without duplicate external effects. Use authorized sandbox/test destinations for integration checks.

**Required targeted verification:**

- Real scale readings, disconnect/reconnect, unstable weight, unit conversion and scanner bursts enter the correct form values.
- Actual supported printers produce readable labels/receipts/A4/cheques with correct copies and dimensions.
- Provider timeout after acceptance is resolved through status and stable request identity; retry does not fabricate another success.
- Missing credentials, rejected payload, cancel, stale rate and background retry surface actionable states.
- Fake IDs/results can never appear as live certification; device/provider evidence names actual tested versions and configuration.

**Close only when:** All required physical/provider workflows have real test evidence and production-ready state handling. Missing devices/credentials remain explicit acceptance dependencies. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X29 — Finish role-specific navigation, lifecycle jobs and audit

**Current classification:** roles-session-partial. Route/form rights catalogs and shell exist; session safeguards have bounded proof. Complete role journeys, every writer/report/export rights check, background/timer ownership and auditable scheduling remain open.

**Parents:** P11-04, P11-05. **Start after:** X01, X05, X09.

**Source/implementation/test anchors:** `web/apps/api/src/modules/rbac/formCatalog.ts`; `web/apps/api/src/modules/rbac/routePolicy.ts`; `web/apps/web/lib/nav.ts`; `web/apps/web/components/Shell.tsx`; `unified/src/csharp/DataCareNext.My/MyApplication.cs`; `unified/src/csharp/DataCareNext/MDI_FORM.cs`.

**Implementation and reconciliation sequence:**

1. Reconcile menu/mode authority to list/view/add/edit/delete/print/export/provider/utility actions, including documents and images reached from another form.
2. Verify tenant isolation with non-owner runtime DB roles and company/location/year/form authority through real API requests; navigation visibility alone is not evidence.
3. Trace login/load/shutdown, saved preferences, daily-rate/reminders, timers, Module_Schm.bgWorker and async callers; assign server versus browser responsibility explicitly.
4. Implement job ownership, schedule/timezone, deduplication, retry/credential failure and visible job status so multiple tabs cannot repeat a business action.
5. Add operator-oriented help/search and recovery prompts; audit actor/time/reason/reference before and after corrections without exposing unnecessary private data in diagnostics.

**Required targeted verification:**

- Cashier, accountant, stock clerk, manufacturing, salesperson and read-only roles can finish permitted journeys and cannot directly invoke denied actions.
- Denied operations leave no business side effects or leaked cross-scope document/image data.
- Two tabs and two worker instances start the same scheduled action: one accepted business effect.
- Restart, delayed job, credential error and local-date boundary preserve schedule/status correctness.
- Fresh-user onboarding finds every required allowed mode and retains only the correct user/device/form preferences.

**Close only when:** Every action and lifecycle job has measured ownership, role/scope enforcement and discoverable operator behavior across supported contexts. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X30 — Implement complete migration and continued historical business

**Current classification:** production-load-contained. Migration helpers and backup ownership manifests exist, but production-cutover-load remains blocked. Complete table/file ownership, scoped repeatable shadow loading, cross-year identities and historical continuation must be proven.

**Parents:** P12-01, P12-02, P12-03. **Start after:** X01, X05, X06, X32.

**Source/implementation/test anchors:** `web/apps/api/integration/cutover.mjs`; `web/apps/api/integration/parity-import-masters.mjs`; `web/apps/api/src/modules/ops/backupManifest.ts`; `web/docs/runbooks/migration.md`; `web/packages/core/containment.mjs`.

**Implementation and reconciliation sequence:**

1. Inventory every business/shared/auxiliary DB, image/template/file source, schema/type/collation/key/ownership rule and required sequence; assign migrate/rebuild/archive dispositions without omitting unsupported active features.
2. Implement read-only extraction to validated staging and a restartable scoped shadow loader with dependency order and technical ID mappings. Never substitute tenant-wide replacement for company/year scope.
3. Validate exact expected table/key/field sets, null/blank/zero and binary hashes; distinguish absent input from explicitly empty table.
4. Run two representative business histories through two clean shadow loads with reconciliation of money/fine/stock/outstanding/WIP/schemes/loans/photos/templates.
5. Continue business through UI: print historic vouchers, return imported sale, pay imported bill, consume remaining tag/lot/order, redeem scheme, close loan and reverse the new dependent action. Preserve historical rules and current effective rules separately.

**Required targeted verification:**

- Two companies and years sharing identifiers load without cross-scope replacement.
- Missing/corrupt rows, orphan references, partial extraction, loader restart and duplicate replay have explicit failing/recoverable outcomes.
- Second clean load reproduces exact key/value/hash and sequence state.
- Imported partial documents can be completed and reversed without desktop or SQL workaround.
- Every difference is reconciled by business effect and reviewed; production load containment is evaluated only after the full gate evidence.

**Close only when:** Complete scoped repeatable migration and active historic continuations are independently reconciled and business accepted before production loading is released. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X31 — Certify restore, deployment and continuity topology

**Current classification:** recovery-partial-contained. Backup manifest/revision table/BIGINT and company restore engineering have retained bounded work. Logical restore remains contained, and actual target deployment, timed physical/logical restore, outage continuity and rollback are unaccepted.

**Parents:** P12-04, P12-05. **Start after:** X03, X09, X30.

**Source/implementation/test anchors:** `web/apps/api/src/modules/ops/backup.ts`; `web/apps/api/src/modules/ops/restoreVerification.ts`; `web/scripts/restore-drill.mjs`; `web/deploy/docker-compose.prod.yml`; `web/DEPLOY.md`; `web/packages/core/containment.mjs`.

**Implementation and reconciliation sequence:**

1. Reconcile actual deployed API/web/schema/image identities, migrations, TLS/proxy, roles/pools, background services, backup/object storage and configured local/LAN/cloud topology.
2. Back up DB, attachments, templates, configuration and sequence state; identify protected credentials/keys required for recovery without writing them into plan evidence.
3. Restore physical and logical company backups into separate targets and run real business continuations; verify another company's data is untouched.
4. Measure agreed RPO/RTO, load/soak, connection exhaustion, restart, planned outage, failed migration and rollback; include observability and actionable runbooks.
5. Retain logical-restore containment until its engineering plus controlled deployment/drill and explicit release requirements are satisfied. Keep drill evidence separate from authorization to restore a real customer target.

**Required targeted verification:**

- Incomplete/corrupt backup refuses safely; valid restore reproduces exact hashes/counts/keys/balances and sequences.
- Interrupted single-company restore does not alter another company and leaves a recoverable state.
- Recovered target sells/settles/prints/reports with the same configuration and attachment availability.
- Internet/LAN/device/server failure behavior matches X09 service commitments; reconnect does not duplicate work.
- Rolling/backward-compatible migration and switchback preserve accepted writes; alerts detect stale backups and failed outbox/provider attempts.

**Close only when:** Production-like deployment and timed recovery/outage acceptance are proven for the selected topology, with explicit controlled release of contained recovery operations. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X32 — Resolve editions, companion functions and absent artifacts

**Current classification:** scope-artifacts-incomplete. Edition/support-source registers exist. UAE/edition variants, NextDm/companion reachability and missing executable/report/device/locale artifacts must be resolved; lack of current customer usage does not remove reachable source scope.

**Parents:** P13-01, P13-02, P13-03. **Start after:** X01.

**Source/implementation/test anchors:** `parity-plan-2026-09-10/evidence/edition-delta.json`; `parity-plan-2026-09-10/evidence/supporting-source-register.json`; `parity-plan-2026-09-10/evidence/report-register.json`; `unified/src/csharp/DataCareNext`.

**Implementation and reconciliation sequence:**

1. Identify exact supported primary/NextDm executable versions and configurations; use hashes and runtime menu/caller evidence rather than filenames to decide their relationship.
2. Review the 123 changed shared files, primary-only files and UAE forms for unique data/rule/report/operation behavior; attach new leaf tasks to their domain parents.
3. Inspect NextEmp/NextImage and installer/dependency assets for employee/image/report/device functions consumed by the primary product.
4. Resolve the 20 absent report references, resource/ActiveX controls, dynamic branches and eight support units with actual desktop observation where needed.
5. Keep unresolved and untested behaviors required by default. Record source-proven duplicate/dead artifacts with caller/configuration proof; a pilot exclusion cannot silently shrink the full product.

**Required targeted verification:**

- Every unique reachable edition/country/companion behavior has a web path and test contract or remains explicitly open.
- Two differing binaries cannot share one passing certificate without a reviewed semantic equivalence map.
- Missing template/control dependencies prevent the related requirement from closing.
- Unexercised behavior in a sparse dataset is never called dead solely due to zero rows.
- New variant discovery expands expected requirement/case sets and invalidates affected acceptance.

**Close only when:** The full intended product/version universe has no unresolved reachable behavior or required artifact, and all unique requirements feed domain acceptance. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X33 — Execute full journeys, business UAT and transition acceptance

**Current classification:** business-release-unaccepted. Scenario catalog and browser journeys exist. End-to-end normal/exception business days, required roles/configurations and real cutover UAT remain unaccepted across the product.

**Parents:** P14-01, P14-03, P14-04, P14-05. **Start after:** X03, X06, X12, X13, X14, X15, X16, X17, X18, X19, X20, X21, X22, X23, X24, X25, X26, X27, X28, X29, X30, X31, X32.

**Source/implementation/test anchors:** `parity-plan-2026-09-10/03-verification-and-release.md`; `web/docs/PARITY-WINDOWS-PROCEDURE.md`; `web/docs/MODULE-VERIFICATION-CATALOGUE.md`.

**Implementation and reconciliation sequence:**

1. Expand the 128 scenario anchors and universal form matrix across all applicable contracts/settings/roles/books; freeze expected IDs before running. These anchors are a minimum, not the final test count.
2. Run the complete real-browser journeys listed below with independent DB and desktop/document/report results; include imported histories and every normal/error/reversal transition.
3. Ask experienced retail/wholesale/accounting/manufacturing/stock/scheme/loan operators to complete realistic work without scripted click guidance; measure errors, task time, keystrokes, lookup success, print usability and recovery.
4. Resolve defects and accepted deliberate behavior differences with requirement links; rerun affected descendants/cross-module journeys after changes.
5. Prepare timed cutover/rollback rehearsal and candidate-specific go/no-go. At separately authorized rollout, reconcile daily closures during the agreed observation window, account for new web writes if rollback is required, and obtain business handover acceptance.

**Required targeted verification:**

- Every required journey has a complete pass or a named blocking issue; no skipped/empty/missing journey is counted.
- Operators complete normal and exception business without mandatory desktop fallback or manual database work.
- Multiple business configurations meet correctness and agreed throughput requirements.
- Cutover rehearsal reconciles opening/closing money, fine, stock, outstanding, provider state and attachments.
- Rollback handles accepted new web transactions explicitly; stabilization evidence covers all intended deployed configurations.

**Close only when:** Every required business journey and production transition has independent technical and role-based business acceptance for the actual candidate. A successful pilot certifies only its declared subset. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

### X34 — Enforce exact-set certification and one current progress record

**Current classification:** certifier-partial-coverage-open. Release certifier checks exact candidate identities and fixed evidence sets, but complete dynamic requirement/transition inventory and dependency invalidation are still open. Strict classification success is distinct from release acceptance; new current source needs fresh bound evidence.

**Parents:** P00-05, P14-02, P14-06. **Start after:** X01, X02, X04.

**Source/implementation/test anchors:** `web/.github/workflows/ci.yml`; `web/.github/workflows/release-certification.yml`; `web/scripts/release-certify.mjs`; `web/apps/api/src/modules/ops/releaseCertification.ts`; `web/scripts/check-completion-register.mjs`; `web/apps/api/test/releaseCertification.test.ts`; `web/apps/api/test/kernelConformance.test.ts`.

**Implementation and reconciliation sequence:**

1. Place/adapt application CI and release workflows under the actual repository-root .github/workflows, preserving correct web working directories and package lock/cache paths. Verify the remote required checks really execute.
2. Before running certification, verify checked-out commit, relevant clean-tree status, dependency/schema/template hashes and running image/build digests; reject a supplied SHA that does not identify the tested tree.
3. Freeze requirement/case/report/device/integration/migration/UAT sets and hash them; require exact ID equality, valid statuses, nonzero expected assertions, complete tables/fields and current evidence for each member.
4. Add explicit real-browser, report-layout/physical device, provider, migration-continuation, recovery/outage and business acceptance evidence to the controlling release contract; the current 17 gate declarations are only a starting point.
5. Implement dependency-based evidence invalidation and actual CI artifact retrieval. A secret containing a local path is not an uploaded report.
6. Keep implementation/engineering/desktop/business/production stages separate in the register, 07 backlog and handoff. Review raised bypass ceilings as debt, not as proof of newly correct behavior; full-product release cannot accept dead-in-one-dataset as an exclusion.

**Required targeted verification:**

- A one-report all-pass file fails when the required set has more reports; missing/duplicate/unexpected case IDs fail.
- Zero executed tests, skipped DB/browser suite, synthetic desktop data and baseline rewrites fail release.
- Dirty or mismatched source, image, schema, lock or template identity and stale evidence fail before certification.
- Changing shared rounding/posting/settings/binder code invalidates every linked affected result.
- All original 83 packages and every new descendant must be accepted; a completed task heading or 198 declared routes cannot close them.
- Remote CI evidence retrieval and failing negative controls are retained with the candidate; missing devices/UAT cannot be replaced by mocked checks.

**Close only when:** One auditable current record reports true stage counts; release rejects all missing, stale or incomplete full-product obligations. No 100% claim while any mandatory path is partial, contained or unverified. Parent packages remain open until all discovered leaves and applicable cross-module acceptance pass.

## Ordered completion and verification protocol

1. **Freeze and recover the reference set.** Record current Git commit/tree, lockfile, Prisma schema/migrations, report-template bundle, executable and source hashes. Inventory local desktop extraction separately from the repo without editing it. Resolve LFS pointer availability and recover protected fixtures/generated historical evidence. Preserve old logs as old evidence. Gate: every artifact is available, verifiably absent with an acquisition task, or explicitly superseded by new attributable evidence; unavailable required artifacts keep affected leaves open.
2. **Close semantic inventory before calculating progress.** Traverse runtime menu catalog → `MDI_FORM` handler/constructor arguments → source methods/events → all settings/edition/master branches → affected tables/reports/devices. Include 212 primary assembly C# files rather than only the original 204 namespace entries, eight support files, supplemental 916 control candidates and unresolved named grids. Assign stable requirement IDs and map every existing page/route/service/reader/writer/test. Gate: missing paths, unknown modes, duplicate identities and undisposed reports fail the inventory gate. The 83/34/198 counts stay navigational, not a semantic denominator.
3. **Recover independent desktop oracles in parallel.** Prepare original Windows installation, correct runtime/fonts/Crystal/device dependencies and sanitized snapshots. Capture initial state, ordered operator actions and intermediate totals, messages/focus, full database deltas/final rows, report datasets and physical output. Record actual executable/config/data identity. Use two distinct business configurations, two tenants/companies/locations/years and colliding identifiers where scope matters. Source-inferred or synthetic vectors remain labelled and cannot impersonate runtime captures.
4. **Provision disposable web environments and refresh the candidate baseline.** Install the pinned package manager/dependencies, build current source, create a disposable database using a non-owner forced-RLS app role, apply current migrations and seed deterministic scopes. Review `web/scripts/parity-test-env.mjs` target protections before running suites. Do not copy hardcoded credentials from historical handoffs. Run fresh API/core/web tests, strict test compilation, workspace lint/build and the real browser suites; archive exact dependency/input snapshots and failures. Preserve known-red diagnostics. Seal a new checkpoint only after its complete actual recipe is recorded.
5. **Make contracts enforceable and authoritative.** For every leaf define source path/hash/method/line, variant predicates, data identity, default/NULL/blank/zero policies, numeric precision/rounding/event order, rights and locks, complete before/after write sets, reports and failure outcomes. Model adaptation decisions explicitly where a browser/server differs from Windows. Keep source clock/storage qualification separate from user-supplied data. Gate: every requirement has independently chosen positive, negative and boundary vectors; contract drafts or unexplained differences block acceptance.
6. **Finish shared integrity before expanding mutations.** Complete full table-family scope, imported text/numeric identity, exact serial/child references, book-specific account/leg mapping, voucher numbering, period locks, audit, source consumption and image versions. On every write read current scope/rights/config/dependencies inside the transaction, compare saved versions, lock in deterministic order, apply exact affected-count DML, assert conservation/postconditions and fail explicitly on stale/uncertain results. Test concurrency, rollback and lost acknowledgements with a real DB. Do not automatically retry a financially ambiguous operation.
7. **Complete vertical business slices with connected proof.** Implement page fields/events/lookups/keys, typed request mapping, server derivation/calculation, persistence, read/reopen/edit/reversal, documents and downstream reports together. Preserve distinct master/purchase/sales/finance/tag/manufacturing/loan/scheme/custody variants. For each slice run the verification sequence below before calling it done; finishing a shared component cannot implicitly close every consumer.
8. **Finish reports, hardware and providers alongside domain slices.** Report binding must resolve explicit full scope and exact document identity. Compare dataset rows and layout, copy semantics, paper dimensions, page breaks, exports, barcode/HUID scan-back, image provenance and denied rights. Validate scale/scanner/camera/printer protocols on actual agreed devices. Run provider acceptance/rejection/status-query/retry/cancel/timeout cases against attributable sandbox or production-safe fixtures as appropriate; a fake transport is only unit evidence.
9. **Complete migration with historical continuation.** Follow the migration protocol below after domain dependencies permit meaningful acceptance. Keep production-load containment until complete scoped shadow-load evidence and operational release decision exist. A schema count or row-count equality alone cannot release loading.
10. **Accept service topology, recovery and usability.** Decide cloud/LAN/hybrid operation from business needs, documenting internet/LAN/server/device-bridge outages separately. Agree RPO/RTO, supported devices/languages/resolutions, realistic volumes/concurrency and counter task targets before acceptance. Prove draft recovery and save-outcome resolution. If offline writes are supported, define local identity, synchronization, conflict and stock/rights/rate authority; if not supported, explicitly accept the resulting operational difference. Run load/soak and timed restore at the agreed target.
11. **Run whole-business UAT and strict certification.** Execute all required roles, normal and exception business days on migrated representative histories: provision/open → purchase/tag → sale/return → settlement → manufacturing/custody → daybook/stock/tax/closing → backup/recovery. Every required descendant/result ID must appear exactly once and pass; missing/duplicate/stale/empty/synthetic evidence must fail. No contained or missing required capability can be waived into full-product completion. Pilot/subset authorization is a separate outcome.
12. **Rehearse cutover, transition one source of truth and stabilize.** Complete freeze/delta capture, backups, final reconciliation, deployment/health smoke, controlled opening and owner role checks before switching scope. Rehearse rollback before and after accepted web business; accepted new transactions must be replayable/reconciled, not discarded by restoring an old backup. Monitor balances, provider queues, latency/errors and backup health. Handover includes operating procedures, incident contacts, tested restore/cutover procedure and signed business acceptance.

### Exact verification sequence for every required leaf

1. Author a case manifest identifying source hash, executable, initial dataset, scope, mode/settings, action sequence, expected UI states/calculations, requests, complete affected/forbidden rows, output and comparison contract.
2. Run deterministic domain vectors, including boundaries, NULL/blank/zero, signs, negative midpoints, precision, imported large values and event sequences. Freeze independent literal expectations before implementation; retain explicit corrections.
3. Exercise API authorization, scope, input transform, invalid/foreign identities and concurrency versions. Assert the actual route's intended writer/reader; names and DTO declarations are not sufficient.
4. Run create/reopen/unchanged-save/edit-line/edit-header/edit-child/add-delete-reorder/duplicate-submit/timeout/concurrent-save/delete-retry against the disposable real DB. Compare complete before/after row key sets and values, not only totals.
5. Run actual production browser + API + DB with keyboard, pointer, scanner-equivalent input, lookups, correct focus/error/reload and context switching. Capture request values and independently queried persisted rows. Separate real-response fault injection from mocked business responses.
6. Repeat the same independently captured desktop action sequence. Compare initial state, intermediate values, final state and full write deltas; show missing/extra cases/tables/rows/columns separately. Document narrowly permitted technical normalization; preserve business equality.
7. Reconcile related stock/account/fine/tax/outstanding/WIP reports and documents. Check unrelated scopes/records remain unchanged. Test downstream continuation after the document has dependents and after migration.
8. Obtain operator/accountant/manager acceptance of the complete normal and exception journey, its printed output and throughput. Link acceptance to the exact tested candidate.
9. Deliberately corrupt the proof set: remove/duplicate a required case, mismatch source/build/schema, substitute empty extraction, stale a shared dependency, inject one money/weight/identity difference and omit a child. Certification must reject each mutation.
10. Close the leaf only when all applicable layers pass and attach evidence. Close a form/card/package only when all descendants and cross-module obligations close. Reopen downstream acceptance when a dependency changes.

### Migration protocol: source ownership to usable history

1. Enumerate every source database/table/file with source system, tenant/company/location/year/book ownership, natural/physical identity, selection predicate, source and target data domains, conversion rule, dependency order and mandatory/optional status. Include images, reports/templates, hidden-number and provider/audit/reference data.
2. Independently validate predicates with two companies, branches and years sharing identifiers; account for exceptions such as yearless `TEMP_BOOK_DATA` identity and tenant-unique concatenated `LEDR_KEY`. Missing mandatory tables and out-of-scope rows are failures.
3. Freeze immutable sanitized source snapshots and check extraction exit codes, schema/version and expected-empty assertions. Archive manifests/hashes securely; never publish customer data in the repo.
4. Load a shadow target with staged validation and resumable batch identity. Persist checkpoints only after committed batches; retry cannot duplicate rows. Preserve text padding, decimal scale, NULL and dates until a reviewed conversion requires otherwise. Quarantine invalid rows with specific actionable errors; do not silently default them.
5. Reconcile key sets and full transformed values, table and image counts/hashes, duplicates/orphans, sequences, totals for money/gold/silver fine/physical stock/WIP/outstanding/pledges/schemes and all reference graphs. A balanced trial balance does not excuse wrong account/stock detail.
6. Continue unfinished historical workflows through return, payment, receipt, issue, tag consumption, order fulfillment, redemption, correction and reversal. Reopen unchanged rich records and verify exact preservation. Recompute reports after each continuation.
7. Repeat two complete clean shadow loads; interrupt/restart another load and prove the same target result. Concurrent non-target tenant data must remain unchanged. Test corrupt/absent artifact and lost connection refusals.
8. Obtain accountant and operator signoff on reconciled output; establish source freeze/delta capture, cutover window, ownership and rollback of accepted web transactions. Release production loading only after its specific containment gate is discharged with evidence.

### Required final gates and certifier work

Preserve R00–R14 from `parity-plan-2026-09-10/03-verification-and-release.md`: scope, contracts, current engineering, actual browser interactions, independent desktop comparison, reporting, settings, integrity, devices/providers, migration, recovery/operations, absence of required restrictions, business acceptance, candidate provenance and cutover transition.

The present executable gate set in `web/apps/api/src/modules/ops/releaseCertification.ts:1110` includes lint, tests, build, real browser, format, strict release register, contract integrity, kernel conformance, schema/type/provision/settings, report baselines, G5 comparisons, report comparison, restore drill, parity/depth ratchets and candidate postflight. It supplies useful enforcement but uses finite known evidence sets. Extend it to all discovered required leaves and downstream dependencies; neither the retained 70-case comparison nor current browser journey set is the full product denominator. Keep ordinary development CI distinct from release certification, with every actual release gate fatal on missing, skipped, stale or incomplete evidence.

Before final release, ensure **exact equality** between expected and actual requirement/case sets, not merely that every returned result says pass. Bind commit/tree, lockfile, schema/migration bundle, templates, configuration/settings, executable/runtime, dataset/capture and build identities. A commit change, shared calculator/settings/schema/template change or missing required artifact invalidates dependent evidence. Run certification in a clean disposable checkout and retain pre/post identity checks.

### Additional scope that an abbreviated module plan must not lose

- Background startup/timer jobs, application exit/reopen, per-user retained preferences, multi-form/multi-tab operator workflows and context-change races.
- Companion products/NextDm/support assemblies, reachable editions/UAE modes, installer resources, original SQL routines, Crystal formulas, fonts and binary-only behaviors.
- All hidden grid identity/cache cells, child stones/diamonds/components, image origins/revisions, source links, imported noncontiguous serials and exact unused-field preservation.
- Dynamic report launchers, all template/copy variants, reports with no sample rows, filters/summary-detail opening-closing modes, physical devices and print cancellation semantics.
- Tax/provider/legal rules that have changed since the desktop release: determine whether exact legacy behavior or an explicitly approved current rule applies; verify official current requirements during implementation rather than silently transplanting obsolete rules.
- Rich historical records and partially completed transactions, cross-year shared keys, active source references, role/right changes during save, restore followed by new numbering, and accepted transactions after rollback.
- Evidence portability: generated browser artifacts, original binaries represented by LFS pointers, ignored comparison data, test toolchain and private settings are required provenance resources, not implied by a Git clone.

## Readiness decision

Current code is available for systematic verify-and-complete work. The repository does not establish full desktop, business or production readiness. Preserve working slices, complete the remaining contracts/branches and attach progressively stronger proof. Complete means the required operator workflows, outputs, history and production operation work together on the same accepted release candidate.
