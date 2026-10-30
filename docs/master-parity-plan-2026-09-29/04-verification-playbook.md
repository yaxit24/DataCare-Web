# Step-by-step verification and full-product acceptance

## 1. Evidence rules

This document specifies future implementation acceptance. Commands explicitly recorded in `evidence/verification-observations.json` are the only newly run checks claimed by this planning review. A planned test case, source-derived vector, retained old pass and actual original-Windows capture are different evidence classes.

For every run retain: requirement/case IDs, candidate Git commit and dirty-input hash if relevant, lock/schema/template/settings hashes, desktop binary/source hashes, runtime/locale, fixture hash, starting snapshot, ordered operator events, requests/responses, intermediate calculations, final row sets, report/output hashes, logs, start/end times, exit status, tester and reviewer. Store sensitive business fixtures in the repository's approved private evidence location; public review documents should contain sanitized summaries, not credentials or customer records.

Use **exact required-set** validation. Missing, skipped, duplicate or unknown case IDs fail closure. A result count of 100 does not prove the required 100 cases ran. Evidence for another commit/setting/template does not pass merely because it is recent. Capture expected values independently before modifying the web implementation.

### Operational skill and measured feature coverage

Feature verification uses the [feature browser validation skill](../../.kiro/skills/datacare-feature-browser-validation/SKILL.md). Before execution, expand every applicable T01–T18 group below into source-backed cases for the feature’s books, settings, roles, boundaries and downstream states; preserve justified N/A dispositions. Operate the actual screen, check persisted effects and resulting reports, and retain the exact-set evidence bundle. Two sessions, retries and write failures are required where applicable, not optional replacements for the happy path.

The skill’s checker rejects missing/duplicate/unknown cases, changed input identities and missing/tampered required artifacts. It does not execute the browser or certify artifact meaning. Report executed coverage, browser/business pass coverage and independent Windows desktop-match coverage separately; blocked/untested cases remain in the denominator. No source-derived result, skipped desktop comparison or API-only pass becomes a browser/desktop pass. Feature-scope coverage does not close parent acceptance or imply an edition/product percentage.

## 2. Test environments and initial procedure

1. Freeze a clean candidate checkout and exact dependency lock. Hydrate required LFS binaries/templates and verify against `ARTIFACT-MANIFEST.sha256`; classify unavailable artifacts before replay.
2. Provision Windows desktop and SQL Server from an isolated copy of the selected deployment, with matched binary/settings/books, .NET/runtime/locale and necessary Crystal/device components. Preserve original source data read-only.
3. Provision an isolated PostgreSQL target from migrations and a non-owner app role with forced tenant RLS. Inspect the existing `web/scripts/parity-test-env.mjs` and Compose target first: it uses localhost port 55433 and a fixed project/volume, so verify no other task or required database occupies it before startup. Adapt isolation explicitly if needed; do not run against an arbitrary pre-existing database.
4. Load the same sanitized business scenario into both environments. Record mapped source/target types and full initial row hashes. Distinguish real empty sets from query failures.
5. Build workspace dependencies before dependent frontend tests. Start production-built frontend/API for browser acceptance; record executable source and environment. Mocked routes can test UI state but cannot prove integrated business behavior.
6. Verify tenant/company/location/year/book context, rights, period settings and edition before actions. Save screenshots of initial menu/mode and key fields.
7. Run the procedure below, compare, retain failures, and reset only the isolated fixture target between cases. Customer data is not a test reset target.

### Required fixture packs

| Pack | Required diversity |
|---|---|
| F01 Scope | Two tenants; two companies in one tenant; two locations; two fiscal years; identical visible voucher numbers/book labels/tag strings across scopes; unrelated sentinels |
| F02 Master/config | Alternate book/account codes, gold/silver/other products, design with dissimilar child components, labour methods, item tax/HSN, all applicable setting branches |
| F03 Numeric | Positive/negative/zero, blank/NULL/missing, exact and near midpoint, max text/number widths, override and event-order sequences, Float representability and timestamp cases |
| F04 Sales/purchase | Immediate and credit trade, old metal, hallmark, wholesale/fine/labour, returns, quotations, discounts, split tenders, partial source consumption |
| F05 Stock/custody | Tagged/untagged/lot/component stock, duplicate historical tag numbers, partial issues/receipts, two operators claiming same stock, stock-count overlap |
| F06 Finance/history | Imported open balances, allocations, cash/bank, rate cuts, gold/silver fine, backdated documents, locked period and year transition |
| F07 Service/mfg | Order-linked and standalone jobwork, karigar stages, lot issue/partial receive, melting/loss, repair images and deliveries |
| F08 Contracts | Dhiran/loan principal/interest dates, partial repayment/release/default; member installments, maturity, adjustments and points |
| F09 Output | Empty/single/multipage reports, long multilingual fields, images, child rows, A4/thermal/label output, barcode/QR scanback |
| F10 Failure | Stale session/rights/master/settings/document; failed write at each boundary; timeout/lost response; duplicate command; offline/reconnect; failed provider callback |

## 3. Mandatory test matrix for every feature

Apply all relevant cases; record an evidence-backed N/A only when the source behavior truly does not apply. The original 18-case matrix and 128 scenario anchors in `parity-plan-2026-09-10/03-verification-and-release.md` remain required; this playbook adds execution detail and does not replace them.

| Case | Steps | Expected proof |
|---|---|---|
| T01 Entry/defaults | Open through every menu/book/mode and role; record defaults/visible columns | Correct constructor/setting branch, scope and initial focus |
| T02 Field route | Change one field using actual control; inspect request, domain, DB, reopen and report | Every applicable stage carries the intended value; no dead field |
| T03 Formula sequence | Execute independent ordered event vector and record intermediate totals/caches | Each phase matches expected values, including rounding/override precedence |
| T04 Lookup | Search/select, cancel, choose another, change parent, delay responses | Correct scoped identity, sort/filter, fills and stale-result rejection |
| T05 Children | Use two dissimilar parent child sets; insert/reorder/copy/delete | Stable child ownership, correct totals, no data movement to wrong parent |
| T06 Required/invalid | Blank/NULL/zero/negative/overflow/length/invalid reference and forbidden edit | Source-defined refusal/message/focus; no partial business writes |
| T07 Create | Save once through browser, then query complete footprint | Exact identity, header/details/children/effects/audit and number assignment |
| T08 Reopen/no-op | Close and reopen imported and new documents; save unchanged if supported | Untouched raw values, clocks, scale, NULL, images and identities preserved |
| T09 Edit | Edit one owned field, save/reopen and compare all changed and unchanged rows | Only allowed effects change; source allocations and reports reconcile |
| T10 Delete/cancel/reverse | Exercise permitted transition, then attempt with downstream dependency | Correct restoration/audit; blocked or controlled dependent reversal as source requires |
| T11 Scope/rights | Call API directly with other scope/role, revoked rights and reused IDs | Server denies invalid authority; no leak/write across sentinel scopes |
| T12 Concurrency | Two sessions load same state; race source use, save, delete, number allocation | One valid result or defined conflict; no overspend/double issue/lost update |
| T13 Retry/unknown | Duplicate request and lose acknowledgment after commit; reconnect | Defined durable result recovery, no duplicate financial effects |
| T14 Rollback | Fail after each table/effect family and before commit | Complete rollback and intact unrelated sentinels |
| T15 Config/history | Change setting/master between preview and save; reopen historic document | Correct snapshot/recompute/conflict rule; no hidden global default |
| T16 Report/output | Run related report/filter/drilldown/export/print after lifecycle steps | Exact dataset totals/identity and accepted visual/physical layout |
| T17 Keyboard/usability | Complete reference workflow using keyboard at supported viewports | Correct event/focus behavior and agreed throughput/accessible interaction |
| T18 Full journey | Continue resulting document through its downstream business chain | All owners' balances/custody/outstanding/reports agree end to end |

Do not clear a failure by loosening a comparator, rounding tolerance or required-set list without a reviewed source-backed correction and preserved original failed result.

## 4. Concrete business journey scripts

Each journey runs once on the independently configured desktop and once on the exact web candidate from equivalent initial data. Record every field and branch as a child case; the titles below are journey anchors, not a ceiling on test count. Use applicable old scenario IDs (`SET`, `PUR`, `SAL`, `FLOW`, `FIN`, stock/manufacturing/loan/report groups) in the final traceability record.

### J01 — Fresh business setup to first usable transaction

1. Start an empty tenant; create company, branch/location, fiscal year and books through supported UI/imports.
2. Create chart/group/party, product/item/touch/labour/tax/design and opening amount/fine/stock with deliberately non-default codes.
3. Configure effective rates/rounding, counter/employee, roles and printer templates; log in as cashier and accountant separately.
4. Create the first purchase and cash receipt, print, close and reopen both.
5. Check book/numbering configuration, exact opening date/sign, scopes and master downstream fills. No direct SQL setup or hard-coded account substitution is acceptable.
6. Repeat company/year creation under a second session and verify neither session silently changes the other's scope.

### J02 — Purchase, tag creation, supplier payment and return

1. Enter two purchase lines with different products, touch/labour rules and component details; select supplier and configured purchase book.
2. Apply allowed discount/tax/payment combinations, record event-by-event totals, save and reopen.
3. Create/select required tags or lots and print/scan labels; verify source lineage and component/image association.
4. Pay part of supplier outstanding using the proper cash/bank book; check bill allocations and reports.
5. Return one eligible portion from the original purchase, then attempt an over-return and a duplicate source claim.
6. Edit or reverse according to source rules; verify PR header/detail, stock/tag, ledger/Rojmel/tax, supplier outstanding and untouched second line/scope at every step.

### J03 — Old metal and hallmark purchase variants

1. Create separate old-metal and hallmark purchase cases through their actual menu/book modes.
2. Enter every mode-specific purity/testing/stone/charge/hallmark identifier and tax branch; preserve alphanumeric and blank identifiers.
3. Change upstream weight/touch/rate and manual labour overrides in the captured source order.
4. Save, reopen, edit a permitted field and print each required voucher/report.
5. Confirm distinct source table/stock/fine/tax effects rather than assuming retail purchase behavior covers these modes.

### J04 — Retail sale with mixed tender and customer credit

1. Select tagged and untagged lines, including a component-rich design, using scoped lookups/barcode scans.
2. Apply permitted labour/discount/other charges and tax branch; exercise employee/counter/customer credit/cash-limit validation independently.
3. Set cash/bank/card/UPI/advance/old-metal or scheme components applicable to the selected mode, leaving intentional outstanding.
4. Save, print, reopen and compare full header, detail, sub-detail, stock, tags, AC_DATA, Rojmel, tax and allocations.
5. Make a permitted edit; attempt conflicting sale of the same tag in another session; attempt forbidden deletion after dependent settlement.
6. Verify customer outstanding, daybook, stock, tax and invoice outputs, including approval/order flags where source-linked.

### J05 — Wholesale, labour and fine-metal sale

1. Run each supported mode separately using different book/account mappings and gold/silver/fine settings.
2. Enter quantity/weight/fine and labour method/rate/manual override branches; capture calculated fine and amount independently.
3. Set allowed fine/amount settlement, save, reopen, edit and reverse.
4. Confirm amount and gold/silver fine ledger legs, rate-cut implications, source references and specialized report/print modes.
5. A balanced rupee ledger alone must fail acceptance if fine-metal quantities or account routing differ.

### J06 — Saved incoming Return, narrow c27 profile

1. Import the exact independently frozen saved-header/incoming-line/master/settings/effects/BAR profile required by the existing Round15 composition contract.
2. Open the saved incoming path and record raw fields, current revision, permitted edits and diagnostic values.
3. Replay Other-amount events, including same-value, repeated, positive boundary and undo sequence; compare all intermediate row/totals/bill/rounding caches.
4. Through the future trusted writer, submit only the admitted changed field and required version; verify current same-transaction observations and guards.
5. Inspect exact patches to owned line/header/account/Rojmel/stock/tax fields and preserved raw clocks/NULL/scale/companions, then reopen and run reports.
6. Repeat with stale master/settings/rights/session/document, missing/extra financial rows, BAR duplicate/phantom and nonrepresentable Float; expect explicit refusal and zero unintended writes.
7. Inject rollback and lost acknowledgment. The narrow profile passes only its named cases; all wider Return cases remain open.

### J07 — Complete return, exchange and credit note

1. Create/source an invoice with two different lines and one partial prior return.
2. Use active legacy and new saved-return surfaces as separate tested paths; reconcile or retire their inconsistent behavior by reviewed implementation work.
3. Return a portion, exchange against outgoing items where supported, apply labour/tender/refund adjustments and save/print.
4. Attempt excess, duplicate and wrong-year/book source consumption; race two operators for the same remaining quantity.
5. Create and reopen the required credit note, apply permitted change/cancel lifecycle and provider status transitions in sandbox.
6. Compare sales/source availability, stock/tag/custody, account/fine/tax/Rojmel/outstanding and statutory document/report effects throughout.

### J08 — Quotation to order, advance and fulfillment

1. Create a quotation with two designs and dissimilar children/photos; convert or link to an order using the actual source workflow.
2. Receive partial advance, reserve source tags or request production, change permitted design/child details and reopen.
3. Partially fulfill/deliver, bill the delivered portion, settle advance and retain remaining order balance.
4. Deliver remaining items or cancel remainder; perform supported refund/correction.
5. Verify identity/history, child/image revision, source quantities, advance allocations, tracking statuses, order/delivery/invoice reports and no double fulfillment.

### J09 — Approval and consignment custody

1. Issue several identified items to a party/employee under approval or consignment.
2. Receive one item, sell one from the original issue and leave one outstanding.
3. Verify party/location custody and source flags after each action; attempt selling or receiving the same item twice.
4. Reverse a permitted downstream transaction and confirm source status and balances restore correctly.
5. Reconcile approval/consignment outstanding, stock availability, settlement and documents; an item physically away must not appear as freely available stock.

### J10 — Tour, order tour and parcel lifecycle

1. Create tour/order-tour with exact imported text/NULL/zero values and linked photos/components where applicable.
2. Allocate goods/orders, dispatch parcel and record partial receipt/return/sale under appropriate stages.
3. Change scope in another tab during a delayed image/lookup response; confirm the old response cannot alter the new document.
4. Settle tour/parcel/account balances, cancel only permitted residual stages and print tracking/output variants.
5. Compare complete source lineage, custody, final balances and order/tour reports; a shared order page must preserve tour-specific semantics.

### J11 — Repair intake to final delivery

1. Register customer item, condition, images, weights/components, requested work and estimate/advance.
2. Issue to responsible karigar/stage, receive with measured changes, enter charges/material adjustments and record partial progress.
3. Replace an image concurrently, edit nonimage metadata and reopen; stale image writes must conflict without losing valid metadata.
4. Deliver to customer, settle charges/advance, print receipt and verify custody release.
5. Test cancellation before and after downstream work; compare all balances, linked issues and audit rather than simply toggling a delivered flag.

### J12 — Cash, bank, journal and bill allocation

1. Create cash receipt/payment, bank receipt/payment, transfer and journal cases with configured accounts and instrument fields.
2. Allocate one receipt across two bills; pay one bill in parts; include applicable advance/kasar/fine allocations.
3. Reopen/edit and reverse permitted documents, preserving bill/date/cheque/clearance and original identity.
4. Reconcile cash/bank daybook, party ledger, bill outstanding, fine balances and trial balance at each cutoff.
5. Attempt locked-period, wrong-book and double allocation cases; verify defined refusals and no partial write sets.

### J13 — Bullion booking and two-sided rate cut

1. Create booking with configured accounts, fine quantity/rate and partial amount payment; capture current outstanding.
2. Complete rate-cut issue and receiving sides separately, with partial/final settlement and different valid source books.
3. Reopen and edit a permitted field; verify rate/amount/fine rounding and correct source consumption.
4. Reverse a downstream cut in supported order and attempt a duplicate or excess cut.
5. Compare gold/silver fine and money account legs, Rojmel, booking/cut outstanding and both documents; hard-coded account aliases must not be required.

### J14 — Tag transfer and cancellation

1. Select one exact live tag serial among reused historical visible tag numbers.
2. Transfer to another permitted counter/location, reopen and edit/reverse if allowed; verify exact source identity and unchanged quantity/weight/fine.
3. Independently cancel an eligible tag, checking source/sub-detail/image lineage and downstream references.
4. Race cancellation/transfer with a sale; only the valid lifecycle may win and the other receives an explicit conflict.
5. Prove each operation's containment exit gate separately before enabling it. Confirm lookup/list/report/physical labels show the correct lifecycle.

### J15 — Tag split and weight replacement

1. Split one parent into two children with intentionally unequal piece/weight/component allocations.
2. Verify unique serials, parent consumption, each child's barcode/detail/sub-detail/image lineage and sum conservation under source-approved rounding/loss policy.
3. Fail during second child creation and confirm no partial parent consumption/child exists.
4. Perform explicit tag weight replacement and separately a sale-driven tag weight difference; do not merge their ownership rules.
5. Reopen, reverse where permitted and compare stock, Rojmel, karigar, image/serial and specialized reports in every applicable branch.

### J16 — Physical stock session

1. Open count for a defined location/counter/date, scan present tags, rescan a duplicate and include untagged/component stock where supported.
2. Mark missing/unexpected tags, conduct a concurrent sale/transfer and refresh according to the count cutoff rule.
3. Review discrepancy report, apply authorized resolutions and finalize.
4. Attempt second finalization and stale finalize; verify idempotency/conflict and consistent stock ledger.
5. Reopen report and exercise allowed reversal/adjustment with audit; original count observations remain attributable.

### J17 — Manufacturing lot issue and partial receipt

1. Configure actual stage/ENTRY_TYPE/NEXT_TRAN/LAST_TRAN, source book and lot/order mode with nondefault codes.
2. Issue material/component lots with known balances to a karigar/stage; save and reopen exact identities.
3. Receive part, including output/remaining material/loss/labour as the stage allows; finish remaining receipt later.
4. Attempt over-receipt, incompatible stage, same source used twice and concurrent partial receipt.
5. Compare MFG header/details/components, source outstanding, stock/fine, labour/account and work-in-progress reports. Verify atomic rollback at each write family.

### J18 — Order-linked jobwork and melting

1. Start from an accepted order/design with children, issue material through required stages and record partial progression.
2. Execute jobwork/karigar settlement branches; track custody and permitted stage transitions.
3. Run melting on selected sources, record touch/loss/output and link resulting fine/material stock.
4. Attempt downstream-stage deletion; either reject or reverse the complete graph according to source contract.
5. Reconcile material/fine plus explicitly classified loss, labour, order fulfillment and manufacturing/karigar/melting outputs.

### J19 — Dhiran and loan continuations

1. Run distinct source-backed loan/dhiran modes with collateral/custody and date/rate conventions.
2. Calculate interest at independently captured boundary dates, including period end, leap date, partial month and backdating branches that the source supports.
3. Make partial repayment, permitted principal/interest adjustment and collateral release; reopen after each.
4. Continue an imported historical loan, exercise default/exception/closure and attempt duplicate release.
5. Compare principal, interest, fine/custody, account/Rojmel and loan/outstanding/receipt reports. Numeric expectations come from the independent contract, not generic interest formulas.

### J20 — Membership, installments, maturity and points

1. Enroll member under scheme terms with beginning balances and identity/contact details.
2. Post regular/late/partial installments as supported, correct one installment and reopen history.
3. Mature or adjust to a sale, including bonus/commission/gold conversion branches; cancel/refund under applicable policy.
4. Earn/redeem points, then race two redemptions against the same balance; no unsupported negative balance or duplicate maturity is acceptable.
5. Reconcile member/scheme/point history, account/tender effects, sales linkage and all statements. Imported contracts must continue under their correct terms.

### J21 — Settings and mode sweep

1. For every setting register entry, locate desktop reader, web authoritative loader and all affected modes.
2. Toggle valid branches on a new document; compare UI/lookup/formula/validation/persistence/output.
3. Change the setting while another operator has an open draft and while a historical document exists.
4. Verify the explicitly defined refresh/snapshot/conflict rule; missing/invalid config must not masquerade as a passing default.
5. Produce a setting→consumer→semantic requirement→case map. No setting closes on a regex match alone.

### J22 — Report and print universe

1. Select each report/template/mode and representative empty, single and multipage datasets.
2. Apply all meaningful filters/group/sort/as-of branches; compare underlying rows and calculations against independent desktop output.
3. Drill down to original documents, export and print with role restrictions.
4. Compare visual layout separately from exact business data; check page breaks, totals, child/image sections, fonts and configured devices.
5. Scan printed labels/QR/barcodes and confirm exact identity; record required physical outputs and reviewer acceptance.

### J23 — Corrections, imports, renumber and transfer utilities

1. Build a fixture with linked headers/details, sources, images, account/tax/stock, allocations and external document state.
2. Preview utility action with exact affected set and rejected dependencies.
3. Execute, inspect the whole graph and continue the affected business workflow.
4. Inject midway failure and retry; exercise allowed rollback and compare all unrelated sentinels.
5. Confirm imported duplicates/invalid rows and new fiscal-year transfer do not silently overwrite another scope or strand historical references.

### J24 — Devices, providers and asynchronous context

1. Connect actual supported scanner/scale/camera/printer; perform stable and unstable readings, disconnect/reconnect and permission rejection.
2. Start capture, switch row/document/company and let the delayed response arrive; verify correct rejection or attribution.
3. Execute sandbox e-invoice/message/provider success, reject, timeout, duplicate and ambiguous-acknowledgment cases.
4. Restart worker/service between submit and callback; reconcile before retry and prove no duplicate external/business action.
5. Inspect authorized operator status/audit and correct document versions. Synthetic adapter tests remain a separate lower layer.

### J25 — Migration and historical business day

1. Extract every required owned source table and asset from a fixed multi-company/multi-year snapshot.
2. Stage and validate complete conversion; interrupt and resume; run again to prove idempotency/isolation.
3. Reconcile identities/columns and every stock/money/fine/tax/outstanding/custody/report balance before promotion.
4. Continue an old order, return, supplier payment, loan, scheme, production receipt and tag operation through actual browser flows.
5. Reconcile again and compare untouched tenant/company/year sentinels. Repeat a second independent shadow rehearsal.
6. Production load remains contained until its specific exit gate and release procedure are completed.

### J26 — Recovery, outage and upgrade

1. Take approved physical/logical backup under the supported procedure; record keys/assets/schema and retention metadata.
2. Restore to an isolated target, verify readiness, exact data, sequence/identity continuity, rights and media; time actual RPO/RTO.
3. Lose browser network/API/database at defined save phases; recover drafts and unknown commit state without duplicate financial effects.
4. Upgrade with an active draft, running job and pending provider callback; verify compatibility or explicit conflict/recovery.
5. Exercise candidate rollback and controlled restore drill under their distinct release gates; do not bypass logical-restore containment.

### J27 — Whole normal and exception business days

1. Have sales cashier, purchase operator, stock/karigar operator, accountant, manager and administrator complete role-specific tasks using realistic volume.
2. Combine new and imported records, two branches/years, fresh and changed settings, returns/corrections, mixed tenders, devices and prints.
3. Introduce competing stock use, stale drafts, invalid credit/cash/period state, delayed provider acknowledgment and a service interruption.
4. Close the day: reconcile cash/bank, account/fine, stock/custody/WIP, tax, outstanding and management reports.
5. Compare desktop business outcomes and operator time/keystrokes; collect explicit acceptance, failed observations and retest results.

### J28 — Final release and stabilization

1. Freeze exact code/lock/schema/settings/templates/requirements and list the required gate IDs using the existing certifier's planning mode.
2. Reconcile every required semantic leaf and old package/card/menu/report/mode to passing current evidence; reject stale/missing/contained requirements.
3. Run full release gates against this candidate, independently review, rehearse final cutover/rollback and obtain production decision.
4. Perform controlled rollout, verify real business-day results and monitor defined incidents/reconciliation metrics through agreed stabilization.
5. Handover runbooks/training/known adaptations, retain old records/access as required and mark full product complete only after the scope and operational acceptance are actually met.

## 5. Commands and gates

These commands are repository entry points, not proof of completion. Read each script and required environment before running. Build/generate dependencies using the locked workspace. DB-sensitive commands must use the verified isolated target; provider tests must use sandbox/test destinations.

| Layer | Existing entry points from `web/` | Required interpretation |
|---|---|---|
| Core | `pnpm --filter @datacare/core build`; `pnpm --filter @datacare/core test` | Pure calculations/contracts only |
| Frontend unit | `pnpm --filter @datacare/web test` after dependency build | Includes helper/protocol tests; not browser business proof |
| Type/lint/build | `pnpm typecheck`, `pnpm typecheck:tests`, `pnpm lint`, `pnpm build`, `pnpm format:check` | Full workspace engineering checks; do not silently skip tests on errors |
| Core test compilation | Separate strict TypeScript command below; extend to every required core test file | `typecheck:tests` targets API tests only; core build compiles source, and passing Vitest does not prove strict test typing |
| Real API/DB | `pnpm test:parity:api` | Wrapper provisions/migrates an isolated DB and enables DB integrity/security suites |
| Actual browser | `pnpm test:parity:browser` invokes `apps/web/test/parity.real-stack.mjs`; also run `apps/web/test/session-context.real-stack.additive.mjs` and `apps/web/test/labour-preview-lifecycle.real-stack.mjs` under the verified environment and their documented setup | The main command does not run all three suites. Require each applicable retained recipe suite and expand to all required journeys; prove absence of mocked business responses |
| Menu/contract/source | `node scripts/check-completion-register.mjs --strict --release`, `node scripts/check-contracts.mjs`, `node scripts/check-kernel-conformance.mjs`, `pnpm docs:refs` | Structural gates do not replace semantic acceptance |
| Schema/type/setup | `pnpm schema:readiness`, `node scripts/check-type-parity.mjs --release`, `pnpm fresh:provision` | Require actual schema/type exports and scoped DB proof; absent evidence fails |
| Settings/depth | `pnpm settings:parity`, `pnpm depth:audit`, `pnpm depth:parity`, `pnpm depth:deadcells` | Diagnose measured surface paths; adjudicate false positives and blind spots without equating ratios to completion |
| Desktop comparison | `apps/api/integration/parity-extract-mssql.mjs`, `parity-extract-pg.mjs`, `parity-replay-*.mjs`, `parity-compare.mjs`; `pnpm g5:parity` | Capture fresh oracle and execute every required family/mode; gate over an old artifact is not a replay |
| Reports | `apps/api/integration/report-compare.mjs`, `pnpm report-baselines` | Dataset, layout and physical output all required; current absence must not become skip/pass |
| Operations | `pnpm restore-drill`, `pnpm load:profile` | Inspect target/safety contract first; measured candidate-bound operational proof |
| Certification | `node scripts/release-certify.mjs --plan`, then configured `pnpm release:certify` | Current required gate fingerprint and candidate identities must match; no force-pass option |

The existing certifier is useful infrastructure, but must enforce the newly completed semantic leaf universe, variant set and required journeys. A green historical menu-only rule with scope exclusions cannot certify this full-product request.

The retained Round15 five-file strict core-test recipe, to rerun on the actual future candidate from `web/`, is:

```sh
pnpm --filter @datacare/core exec tsc --noEmit --strict --noUncheckedIndexedAccess --isolatedModules --target ES2022 --module NodeNext --moduleResolution NodeNext --resolveJsonModule --esModuleInterop --skipLibCheck test/saleReturnOtherAmountReplay.test.ts test/saleReturnEffectContext.test.ts test/saleReturnFinancialEffects.test.ts test/saleReturnSaveGuards.test.ts test/saleReturnSaveComposition.test.ts
```

This is the exact bounded historical command, not full core-test type coverage. Establish an explicit test tsconfig or equivalent exact file list that includes every required core test as the suite expands; retain the original recipe for comparison. This planning review did not run that strict test compilation.

### Retained release-gate mapping and negative controls

Keep the original R00–R14 gate identities from the previous plan and map every machine gate/evidence file to them:

| Gate | Required closure in this package |
|---|---|
| R00 Scope | W00/D01–D02, retained register plus all discovered variants/descendants |
| R01 Contracts | Document 03 complete per-leaf source/input/action/effect/proof contracts |
| R02 Engineering | Fresh complete type/lint/tests/build, mandatory isolated DB tests actually run |
| R03 Interaction | T01–T18 and all applicable real-browser J01–J28 cases/modes |
| R04 Desktop | Independent original-runtime comparisons with zero unexplained row/value differences |
| R05 Reporting | J22, every report/mode dataset, binding, layout, export, rights and physical output |
| R06 Settings | J21, all semantic setting branches and stale/historical behavior |
| R07 Integrity | Identity/scope/numbering/conservation/rollback/concurrency/idempotency in document 03 |
| R08 Devices/providers | J24 and supported actual hardware plus attributable provider evidence |
| R09 Migration | J25 complete manifest, two rehearsals and historical business continuation |
| R10 Recovery/operations | J26, agreed continuity, load, recovery, restart and monitoring outcomes |
| R11 Scope restrictions | No required full-product operation contained, missing, unavailable or dependent on manual/desktop fallback |
| R12 Business acceptance | J27 and operator approval across roles/configurations/normal and exception cases |
| R13 Provenance | Exact frozen candidate/required-set/dependency identity and effective fail-closed enforcement |
| R14 Transition | J28 timed cutover/rollback, responsibility, source-of-truth boundary and stabilization |

Before trusting certification, run automated negative controls in an isolated evidence sandbox: remove one required leaf/result; substitute a stale candidate/schema/template hash; duplicate a case while deleting another; add an unknown case; mark a required case skipped; alter a retained expected value; remove a report/device artifact; leave a required containment active; and modify a dependency after a pass. Every manipulated set must be rejected with the expected reason. Preserve the real evidence unchanged. These tests verify enforcement, not business outcomes, and must not be satisfied by editing the gate list to match the manipulated results.

## 6. Release acceptance record

The final release record must contain: complete scope/version/edition matrix; requirement-set digest; per-leaf implementation/test/desktop/UAT state; no unresolved required gaps; current test and original-runtime evidence; all report/device/provider acceptances; two migration rehearsals; timed recovery; agreed throughput/latency/continuity results; production rollout/rollback authorization; business sign-off by role; training/support/runbooks and retained historical access. Each acceptance names the actual candidate, operator and date.

Do not mark full completion because the 30 new slices, 34 old cards or 83 old packages have checkmarks. Their discovered descendants and cross-module outcomes govern completion.
