"""Build the reviewed continuation backlog and its readable instructions; no app/DB changes."""
from pathlib import Path
import json
import re

OUT = Path(__file__).resolve().parent
TASKS = []


def task(number, title, parents, dependencies, finding, files, steps, tests, done):
    TASKS.append({
        'id': f'X{number:02}', 'title': title, 'status': 'open',
        'parents': parents.split(), 'startAfter': dependencies.split(),
        'currentFinding': finding, 'existingFiles': files.splitlines(),
        'implementationSteps': steps.splitlines(), 'verificationCases': tests.splitlines(),
        'acceptance': done,
        'requiredEvidence': ['source/mode contract and source hashes', 'field/action path matrix',
                             'case manifest with expected IDs', 'test results and full business-state comparisons',
                             'applicable desktop/browser/report evidence', 'remaining differences and parent status'],
        'closureRule': 'This card and its parent remain open until all discovered descendants and applicable cross-module acceptance pass.'
    })


task(1, 'Reconcile scope and replace misleading availability labels', 'P00-01', '',
     'CR-01/10: all menus are mapped, but blocked/partial paths and unresolved semantic inventory remain.',
     'web/docs/COMPLETION-REGISTER.json\nweb/packages/core/containment.mjs\nparity-plan-2026-09-10/evidence/form-register.json\nparity-plan-2026-09-10/evidence/additional-control-candidates.json',
     '''Freeze the reviewed dirty-tree files and desktop executable/source hashes; preserve prior work and old evidence. Read 08 and 09 before classifying controls.
Join all 198 menu identities to actual MDI_FORM dispatch, constructor arguments, MAIN_BOOK, permissions, page, route and domain function; distinguish the report Lot IsuRec from the transaction TR_MFG_WITH_LOT.
Reconcile 212 primary C# files, the original 204-unit register, eight support units, 916 supplementary declarations, 43 unresolved grid records, report references and table ownership. Resolve semantic duplicates explicitly.
Add separate implementationState, availabilityState, verificationState and missingActions/containmentOperation fields; retain legacy state compatibility until all readers are updated. A declaration of implemented-unverified must not imply usable or complete.
Create the canonical source-to-mode-to-requirement register. Include every reachable branch even when it is unused in the supplied business data. Link missing artifacts to X32.''',
     '''Every original menu/source/control/report identity resolves to a leaf or reviewed disposition; unknown identities cause failure.
A contained tag route remains unavailable even when its page and handler exist; an IRN-only page remains partial.
Changing a label or adding a duplicate route must not increase implemented semantic requirements.
Adding a new discovered mode grows the expected set and reopens affected package acceptance.''',
     'Complete traceable inventory and truthful availability; no automatic promotion to verified. Inventory completeness is an explicit reviewed result, not the 198-row count.')

task(2, 'Repair scanners before using any percentage', 'P00-03', 'X01',
     'CR-09: nested mappings and fixed page lists produce both blind spots and false alerts.',
     'web/scripts/check-depth.mjs\nweb/scripts/check-dead-cells.mjs\nproject-memory/parity/richness_web.py\nproject-memory/parity/richness_desktop.py\nproject-memory/parity/settings_parity.py\nweb/apps/web/app/(app)/txn/wholesale-sale/page.tsx\nweb/apps/api/src/modules/sales/rateCut.ts',
     '''Discover page files and dynamically reachable master/report/book modes independently of the writer map; fail an unmapped discovered path.
Track page input to transformed payload to route adapter to nested domain field to calculation/write/read/reopen, including issueYear/issueBook/issueNo/issueSrno -> isuRef -> ISU_* columns. Preserve this working mapping while fixing measurement.
Recognize typed settings aliases, recalc wrappers, shared component props and source declaration modifiers; join actual event/caller contracts rather than counting generic field names.
Classify each control as editable, derived, hidden identity, display-only or non-business, with conditional mode applicability.
Publish stage-specific counts with an unknown denominator until inventory closure. Keep old 73.0% and 97.6% figures labelled historical heuristic outputs; never reset a baseline to manufacture improvement.''',
     '''A valid nested mapping passes; dropping isuRef from the route fails the corresponding path.
Remove a reader field while leaving the writer intact: reopen coverage must fail.
Add an extended-grid page without a mapping: audit must fail and name it.
An identically named field on another route cannot satisfy the missing field.
MS_PRINT virtual checkboxes and supported wrapper recalc/settings calls are discovered; unused aliases are not treated as effective policy.''',
     'Measurement tools pass independent positive and negative fixtures and reconcile the declared universe; no claimed functional percentage from surface counts.')

task(3, 'Provision reproducible desktop and real web verification', 'P00-02 P00-04', 'X01',
     'CR-08: mock-browser coverage and port-5433 DB results are not a complete real-stack certificate.',
     'web/docker-compose.yml\nweb/packages/db/prisma/schema.prisma\nweb/packages/db/prisma/rls.sql\nweb/packages/db/setup_roles.sql\nweb/apps/api/test/globalSetup.ts\nweb/apps/api/test/meltingPro.db.test.ts\nweb/apps/api/test/otherCommission.db.test.ts\nweb/apps/web/test/browser.smoke.mjs\nweb/apps/web/test/route-coverage.mjs',
     '''Provision a dedicated disposable database on port 55433, or replace both hard-coded test guards with an equally strong explicit test-target identity check. Do not point mutation suites at the running app database merely because it is reachable.
Apply migration-owned schema, roles and forced RLS from scratch; separate owner setup credentials from non-owner runtime credentials. Fail drift, missing migrations and incorrect role assumptions.
Seed the fixture packs below and start matching API/web builds. Record health, build IDs, migration/lock hashes and source digest; do not infer running-container identity from local source.
Add a separate real-stack Playwright suite using actual login/context selection and requests, with independent DB assertions. Keep existing intercepted tests explicitly labelled mocked.
Prepare the isolated Windows desktop with Crystal dependencies and equivalent sanitized fixtures. Capture actions, prompts, intermediate amounts, outputs and before/after tables; report missing Windows resources as open dependencies.''',
     '''Fresh migrations succeed twice into separate empty targets; owner/runtime role assertions pass.
Both currently 55433-only suites run without exclusion; all required DB suites run with zero skips.
A real-browser save creates rows; a response stub without the row must fail the test.
Every dynamic report/master/book mode is enumerated, not represented by one placeholder URL.
Wrong credentials, unavailable database, wrong schema and stopped API fail before business assertions; they cannot appear as successful empty cases.''',
     'A single documented local/CI setup runs real browser/API/non-owner DB tests and independently attributable desktop captures. Required missing environments keep relevant acceptance open.')

task(4, 'Author complete behavior contracts and numerical vectors', 'P00-05 P01-02', 'X01 X02',
     'CR-10: only 11 contracts exist, eight draft, with 184 missing computed-vector links.',
     'project-memory/contracts\nweb/apps/api/test/goldenVectors.test.ts\nweb/apps/api/src/modules/ops/contractIntegrity.ts\nweb/packages/core/src\nweb/apps/api/src/modules/shared',
     '''Start with purchase, retail sale/return, tag opening, rate-cut receiving and lot manufacturing as reference contracts; then enumerate every remaining form/mode and non-form lifecycle action.
For each action record pre-state, role/book/settings, triggers, default/override precedence, validation and confirmation branches, effects, read/edit/reversal and error behavior.
Review all 28 unenforced-rule records against current code before implementing; record fixed-but-stale entries separately from genuine missing behavior.
Replace each missing formula link with a source-cited golden vector independently checked on desktop, or a reviewed non-calculated disposition. Do not copy a vector based on matching column names.
Cover signed midpoint rounding, rate/weight units, null/blank/zero, per-line/voucher rounding, customer/karigar valuation, date boundaries and maximum supported decimal precision.''',
     '''Change each shared numerical policy in a temporary test copy: all affected family vectors and previews must fail.
Explicit zero remains zero where permitted; omitted override invokes the configured derivation.
Calculating a default twice does not freeze it as an operator override.
An approved contract with missing source, field, branch, vector or mandatory case is rejected.
Negative source-dead claims include all callers/settings/edition modes and runtime corroboration where source is incomplete.''',
     'Every required leaf has an actionable contract and independent oracle; drafted or partially approved documents cannot close a family.')

task(5, 'Close document identity, edits, concurrency and retries', 'P01-01 P01-04 P01-05', 'X03 X04',
     'Order reports now retain complete scope; bounded ordinary Sales versions, imported-state preservation and shared photo revisions are implemented. Cross-family identity, dependency and retry acceptance remains open.',
     'web/apps/api/src/modules/vouchers\nweb/apps/api/src/modules/posting/posting.ts\nweb/apps/api/src/modules/sales/orderDoc.ts\nweb/apps/api/src/routes/txn.ts\nweb/apps/web/lib/api.ts',
     '''Build a per-table identity matrix including padded voucher/ledger keys, tag instances, parent/child serials and historical references; use full tenant/company/location/year/book/voucher scope where applicable.
Trace create/get/list/edit/delete/print/image/report consumers for each family. Correct OrderScope, orderData and its route to carry exact location and year into header/detail/party reads.
Define immutable identities and allowed correction transitions from desktop; preserve unchanged rows and source lineage.
Add optimistic version checks or a documented equivalent to prevent silent stale overwrite, plus transactional locks for stock, booking, outstanding and source allocation.
Implement stable idempotency keys for accepted mutations and response-loss recovery. Scope keys to operator/business operation and compare payload digest; dispatch external effects only after commit.''',
     '''Same book/voucher/tag in two tenants, companies, locations and years returns exactly the selected document, including its print and image.
Two tabs edit the same saved document: stale save conflicts without losing either draft.
Concurrent sale/split/transfer of one tag and concurrent bill/order/booking allocation allow only valid consumption.
Lose the response after commit and retry: one voucher/effect exists and the original result is returned; conflicting key reuse fails.
Failure after header/detail preparation rolls back all required rows; locked or dependent source changes have no partial effects.''',
     'All applicable lifecycle transitions are atomic, correctly scoped and conflict-safe, including documents and downstream consumers; domain tests plus real-browser cases prove it.')

task(6, 'Replay exact posting footprints and reconcile history', 'P01-03', 'X03 X04 X05',
     'The retained 70-case comparison is old and has zero complete matches; current defects cannot be inferred from its field total.',
     'web/apps/api/integration/parity-extract-mssql.mjs\nweb/apps/api/integration/parity-extract-pg.mjs\nweb/apps/api/integration/parity-compare.mjs\nweb/apps/api/integration/parity-replay-generic.mjs\nweb/scripts/parity-measure.mjs\nweb/apps/api/src/modules/shared/rojmel.ts',
     '''Freeze full expected case/table/key/column sets before capture; distinguish empty required tables from missing extraction.
Replay current web code from the same starting fixtures and configurations as the desktop, preserving provenance. Use synthetic cases for harness tests only; never derive expected desktop values from web output.
Classify each old difference as still present, now fixed by current code, extraction/mapping defect or reviewed deliberate behavior difference; retain both old and new evidence.
Compare headers/details/IDTL, ledger role/account/sign/key, Rojmel money and metal rows, stock, tax, outstanding, adjustments, tender identity, images and audits. Assert forbidden writes too.
Correct one business rule at a time and rerun its dependent families/reports. Review every excluded field and technical normalization; financial differences cannot be hidden by tolerance or field removal.''',
     '''Missing/extra table, row, field, duplicate case and incomplete capture fail the comparator.
Fully paid versus outstanding, mixed tender, negative/zero boundaries and multi-line components match complete footprints.
Create, unchanged edit, changed edit and permitted reversal match both intermediate and final state.
A balanced but wrong-account ledger fails; removing both balancing legs also fails.
Retained old evidence cannot certify changed code or a new settings/template version.''',
     'Every required family/mode has a current complete differential with zero unclassified business differences and all downstream balances reconciled.')

task(7, 'Finish shared forms without flattening domain variants', 'P02-01 P02-02 P02-03 P02-04', 'X04',
     'Shared grid/subdetail adoption is progress, but it does not prove every cell, child set or trigger.',
     'web/apps/web/components/ExtendedGrid.tsx\nweb/apps/web/components/SubDetailGrid.tsx\nweb/apps/web/components/GridKeyboard.tsx\nweb/apps/web/components/FormKeys.tsx\nweb/apps/web/lib/lineRecalc.ts\nweb/apps/api/src/modules/shared/stoneSubDetail.ts',
     '''Use a reference form with two parent rows, two different child collections, tender rows and source allocations; list all applicable control contracts before adding columns.
Support stable row/child identity, insertion/removal/reorder, numeric units/precision, lookup filters, derived read-only cells and explicit overrides.
Implement field-change/cell-exit dependency order through shared measured policies; retain per-form customer versus karigar valuation and receive-side differences.
Map each visible input and computed display to the exact route/writer/reader. Hidden IDs remain server-owned; displaying a database column is not an operator requirement.
Complete keyboard save/new/print, row navigation, append/delete, modal escape, focus after validation and remembered columns; observe F10 before assigning its action.''',
     '''Distinct parent and child sentinel values survive browser save/reopen/unchanged save; reordering never moves a child to the wrong parent.
Changing weight/touch/rate/labour updates every dependent value identically in UI/API/DB.
Choose a lookup, cancel another lookup, paste values, scan a code and edit by keyboard; results agree.
At 1366x768 operators can access every required field and total without losing the selected row.
Adding a shared component does not mark untested caller modes complete.''',
     'All applicable form controls and action transitions have real field-path evidence, plus measured operator throughput and accessible error/focus behavior.')

task(8, 'Complete observable settings behavior', 'P02-05', 'X02 X04',
     'The old scanner reports 45 honored and 82 inert among 130 rows, but typed aliases make these candidate counts unreliable.',
     'web/apps/api/src/modules/settings/settingsInventory.ts\nweb/apps/api/src/modules/shared/settingsBehavior.ts\nweb/apps/web/lib/companySettings.ts\nweb/apps/api/test/settingsEffect.db.test.ts\nweb/apps/api/test/settingsRealValues.test.ts',
     '''Join setting identity by table/key and configured scope; catalogue actual desktop encodings, defaults, invalid values and consumers, including CO_MAST/TAG_SET/book/user preferences.
Trace load -> alias -> UI/server consumer -> persisted/report consequence. Reuse existing consumers before adding another policy layer.
Prioritize SL_TAG_WT_DIFF, CUR_DAY_POSTING, branch account visibility, weight/fine locks, negative stock, estimate/tax, rounding, print/image/copy settings and lot policies.
Implement effect cases per affected family and mode, with direct API enforcement where it governs accepted business state.
Document cache invalidation on company/year/user/book change and concurrent session changes; preserve historic recorded values when current defaults change.''',
     '''For every behavioral setting, the same valid fixture under each supported value produces the independently expected outcome.
Null, blank, zero, Y/N and numeric encodings are distinguished according to source.
A loader read without an outcome assertion does not pass; a field disabled in UI still obeys policy in direct requests.
CUR_DAY_POSTING changes the source-confirmed refresh scope, not an invented posting-date rule.
Switch business settings while another tab has a draft; stale policies cannot silently alter accepted transactions.''',
     'All settings have reviewed dispositions and effect evidence across required consumers; no regex-derived inert count is treated as a verified missing-feature total.')

task(9, 'Preserve form sessions and resolve offline service behavior', 'P02-06', 'X01 X03',
     'CR-11/14: context-change invalidation and the operational outage model are not accepted.',
     'web/apps/web/components/BookSelect.tsx\nweb/apps/web/components/BusinessScope.tsx\nweb/apps/web/components/Shell.tsx\nweb/apps/web/lib/api.ts\nweb/deploy/docker-compose.prod.yml',
     '''Document service requirements for internet outage, LAN loss, app/DB failure and device-bridge loss; identify which operations continue, queue or stop. Resolve intended local/LAN, cloud or disconnected-posting topology before dependent implementation.
Trace whether BookSelect and lookup callers remount on every business context change. Add explicit scoped invalidation where needed, retaining cancellation of stale fetch responses.
Preserve meaningful drafts, selected row and validation errors on recoverable failure, refresh and related-form navigation; define confirmation behavior before context change or draft discard.
Support consulting a ledger/master while an invoice remains open, with per-tab context isolation and stable saved preferences.
Implement recoverable posted-status display and retry via X05. If offline posting is required, specify local identity/stock ownership, permissions, rates, synchronization and conflict policy before coding it.''',
     '''Two businesses use disjoint books; switching in place and with two tabs shows only the correct choices and values.
Expired session during editing preserves draft; retry cannot post under a changed context.
Navigate to a related master/ledger and back: row, children and totals remain intact.
Exercise each agreed outage, server restart and reconnect; no ambiguous accepted sale, duplicated settlement or silent draft loss.
Draft caching alone fails a requirement that ordinary sale posting continue without internet.''',
     'A documented business service decision and tested session/outage behavior support the claimed operational scope. Unresolved topology remains an explicit dependency, not an assumed waiver.')

task(10, 'Complete master data and fresh-business provisioning', 'P03-01 P03-02 P03-04 P03-05', 'X04 X07 X08',
     'Master screens exist; generic row CRUD must still prove conditional fields, child policies and usable branch setup.',
     'web/apps/api/src/modules/masters/master.service.ts\nweb/apps/api/src/modules/masters/configs.ts\nweb/apps/api/src/modules/masters/companyClone.ts\nweb/apps/api/src/modules/masters/stockLimit.ts\nweb/apps/api/src/modules/masters/year.ts\nweb/apps/web/app/(app)/masters/[name]/page.tsx',
     '''Map desktop MS_ACCT/MS_ITEM/MS_PRODUCT/MS_LOCT/book/year/user/rate/labour/slab/counter/diamond variants to dynamic and specialized web masters.
Implement whole-row/settings/reference validations, code generation, text identity lengths, linked photos, credit/tax/bank data and parent-child policy collections.
Trace MS_LOCT provisioning of BOOK_DATA, BOOK_DETL and TABLE_MAST; implement missing atomic cloning and defaults rather than only inserting a location row.
Complete previewable scoped import/export with row-level errors, duplicate/reference policies and rollback; use the same business validation as individual edits.
Verify new company, branch and year can execute purchase, sale, tender and reports with their own configured accounts without SQL fixes.''',
     '''Two shops use different book/account codes; both complete a first business day.
Rich master reopen/save preserves conditional fields, child slabs and images; referenced deletions fail appropriately.
Slab boundaries and item/party policies affect the intended transaction only.
Malformed, duplicate, Unicode and leading-zero import rows produce precise outcomes without partial setup.
Fail branch setup halfway: no partially usable book or permissions remain; year transitions preserve opening balances.''',
     'All reachable master modes and imports are usable and validated, and independent configured-business setup has full-stack evidence.')

task(11, 'Implement design components and complete design identity', 'P03-03', 'X04 X07',
     'Design Book parent/components, source calculations, repeat/keyboard events and scoped Sales Design selection are implemented. Full shared-help commands, remaining settings/downstream consumers and independent desktop acceptance remain open.',
     'unified/src/csharp/DataCareNext/MS_DESIGN_BOOK.cs\nweb/apps/api/src/modules/masters/designBook.ts\nweb/apps/web/app/(app)/masters/design-book/page.tsx\nweb/apps/api/test/designBook.db.test.ts',
     '''Extract DESIGN_DETL/DESIGN_IDTL ownership, serials, defaults, customer/karigar calculations and image lookup from the desktop handlers; do not infer keys from design number alone.
Extend the input, validation, atomic save, reader and deletion paths with per-parent component collections and explicit retained identities.
Add child editing to the dedicated screen and preserve hidden identities on unchanged save and parent reorder.
Associate images by the complete entity key and preserve them through order/manufacturing conversion.
Implement source-confirmed fine, rate basis, labour/other/net cost and MRP derivation/overrides using X04 policies.''',
     '''Two books and two products share a design number but retain different children/images.
Two components per parent carry distinct weight, conversion, customer and karigar values through browser/API/DB/reopen.
Remove one child and reorder parents: remaining serials and ownership are unchanged.
Unchanged save preserves every business column and image association; failed child validation rolls back the entire edit.
Select the design in an order and manufacturing issue: the correct specification and photo follow it.''',
     'Desktop parent/child/image behavior is complete and independently compared, including downstream design specification use.')

task(12, 'Close every purchase and supplier lifecycle', 'P04-01 P04-02 P04-03 P04-04 P04-05', 'X05 X06 X07 X08 X10',
     'Retail, hallmark, old-item, quotation, consignment and other purchase work exists; certify variant depth rather than rebuilding it.',
     'web/apps/api/src/modules/purchase\nweb/apps/web/app/(app)/txn/purchase/page.tsx\nweb/apps/web/app/(app)/txn/purchase-hm/page.tsx\nweb/apps/web/app/(app)/txn/purchase-return/page.tsx\nweb/apps/api/test/purchase.lifecycle.db.test.ts\nweb/apps/api/test/purchaseQuotation.db.test.ts',
     '''For each TR_PURC/TR_PURC_HM menu/book variant, map main, receive/return, IDTL, totals and tender fields through its own writer/reader.
Reuse quotation/old-item/consignment paths after checking their effect exclusions; a quotation must not accidentally consume stock or post an ordinary payable.
Complete source selection for supplier return, remaining quantity/components, original price/tax and permitted historical references.
Finish cash/bank/cheque/card/UPI/advance/kasar identities, bill allocation and correct configured ledger/Rojmel roles.
Drive supplier creation -> rich purchase -> tag/lot availability -> partial return -> mixed settlement -> supplier/stock/tax reports -> permitted correction through real screens.''',
     '''Two configurations, mixed gold/silver, two lines and two components each preserve all header/line/child fields.
Zero/disabled tax, blank/zero rate and manual overrides match each book contract.
Fully paid and outstanding purchases have exact different row footprints; mixed tender identities are retained.
Over-return, repeated source selection, settlement over-allocation and source edits after dependencies fail without effects.
Unchanged edit and return cancellation preserve/restores exact stock, source balances, liability and report totals.''',
     'Every purchasing variant and the complete supplier journey passes independent desktop, real-browser, DB and report acceptance.')

task(13, 'Close retail, wholesale, labour and return depth', 'P05-01 P05-02 P05-03 P05-08', 'X05 X06 X07 X08 X10',
     'Sales grids and subdetails have expanded; preserve separate issued/received, customer/karigar and return semantics.',
     'web/apps/api/src/modules/sales/sales.ts\nweb/apps/api/src/modules/sales/salesReturn.ts\nweb/apps/api/src/modules/sales/wholesaleSaleReturn.ts\nweb/apps/api/src/modules/sales/labourInvoice.ts\nweb/apps/api/src/modules/sales/rateCut.ts\nweb/apps/web/app/(app)/txn/sales/page.tsx\nweb/apps/api/test/salesFamilyLifecycle.db.test.ts',
     '''Enumerate TR_SALE/TR_SALE_HM/TR_WH_SALE/TR_SALE_LBR/return/fine-sale modes with their independent field/action contracts.
Complete applicable source picks, issued and received grids, IDTL sets, old gold, order/scheme redemption, HUID/cost/commission, manual rates and tender identities.
Preserve wholesale isuRef mapping noted in X02; verify it by persisted columns instead of deleting the fields to silence a scanner.
Provide actual source-invoice return selection with remaining components, original pricing/tax/cost and permitted refunds/credits; correct dependency locks and reversal.
Verify all lines, settlement bands, invoice/credit documents and sales/stock/outstanding/tax/commission reports from real UI.''',
     '''Tagged scan, manual untagged sale, mixed old-gold exchange and component-heavy invoice complete on both configured shops.
Issued-only, received-only and two-sided wholesale/labour cases keep their distinct customer/karigar valuations.
Partial/full/repeated return, over-return and cancellation conserve source availability and stock.
Per-piece/per-weight basis, blank/zero/override and taxable/non-taxable modes agree in preview/API/DB/print.
Failed save, concurrent consumption and no-change reopen cannot duplicate sale effects or lose rich values.''',
     'Each sales variant and supported return journey has complete operator and effect parity, including all dependent settlement and reporting.')

task(14, 'Complete Tour Order, quotations and fulfillment conversion', 'P05-04 P05-06', 'X05 X07 X11',
     'Configured ordinary Sales and Tour editors now have bounded full saved-document lifecycles. Remaining financial/tag branches, quotations, delivery, conversion and cross-module acceptance are still required.',
     'unified/src/csharp/DataCareNext/TR_SALE_ORD.cs\nweb/apps/api/src/modules/sales/salesOrder.ts\nweb/apps/web/app/(app)/txn/tour-order/page.tsx\nweb/apps/web/app/(app)/txn/sales-order/page.tsx\nweb/apps/web/app/(app)/txn/sales-quotation/page.tsx\nweb/apps/api/test/tourOrder.db.test.ts',
     '''Reuse TOUR ORDER API wrappers; add BookSelect constrained to the correct MAIN_BOOK and forward the selected book/location/year on list/create/get/edit/delete/print. Remove 510 as an unconditional list/print identity.
Implement selected-voucher hydration and PUT from the browser, including every header, line, component, image and advance; separate new/edit/cancel state and stale version handling.
Capture quotation-to-order/invoice, partial order manufacturing/delivery and source adjustments from desktop. Add explicit source selection and conversion lineage rather than copying rows without consumption.
Keep money/fine advances, production balance, tag reservation and delivered quantities separate. Release each only on its corresponding reversal.
Implement cross-book transfer only from the measured full reference graph; renumbering alone is not transfer.''',
     '''TOUR ORDER books 510 and 511 plus a nonstandard configured code work; a SALES ORDER book is rejected in Tour Order.
Create -> close -> select -> unchanged edit -> changed child -> delete through the screen; get/print/list agree on the selected scope.
Two partial deliveries exhaust one order exactly; canceled delivery restores its allocation.
Repeated/stale conversion, excess allocation, source deletion, locked destination and identity collision fail atomically.
Order -> multiple karigars -> receipts -> tags -> invoice preserves specification, images, advances and source identity.''',
     'All order/quotation/conversion actions are reachable without manual SQL, with correct balances, book scope and independently compared documents.')

task(15, 'Implement the full E Credit Note document workflow', 'P05-01 P11-03', 'X04 X05 X07',
     'CR-02: POST /einvoice/credit-note/irn currently assumes the E CRNT document already exists.',
     'unified/src/csharp/DataCareNext/TR_SL_EBILL.cs\nweb/apps/web/app/(app)/txn/e-crnt-note/page.tsx\nweb/apps/api/src/modules/einvoice/einvoice.ts\nweb/apps/api/src/routes/txn.ts\nweb/apps/api/test/ecreditNoteIrn.db.test.ts',
     '''Read TR_SL_EBILL save/open/delete/browse/print and E CRNT branches; record full header/item/tax/reference fields and exact allowed/forbidden stock, ledger, Rojmel and tax effects. Do not assume an ordinary sale or return writer is equivalent.
Implement explicit E CRNT create/get/list/edit/delete domain and route paths (new names are to be chosen consistently), selected-book validation and full-scope readers.
Replace the IRN-only form with complete entry, browse, reopen/edit, permitted deletion and document preview/print; retain existing IRN submission as a saved-document action.
Preserve invoice/source references, document type CRN, book series and totals; match rounding/zero-tax/discount cases to historical source contracts.
Add provider submit/status/retry/cancel and post-IRN edit restrictions according to measured desktop behavior and current provider requirements verified during X28; expose real pending/failed/live states.''',
     '''Create a new credit note entirely through web UI with no SL_DATA fixture insertion; reopen and compare every applicable field/effect.
Same voucher number in sale and two E CRNT books remains independent; print and IRN use only the selected one.
Mixed item/tax, zero-tax, discounts, blank optional references and multi-page credit note match expected data.
Unchanged/changed edit and permitted deletion preserve identities and exact reversible effects.
Provider timeout after acceptance, retry and cancel resolve one real document status; fake-provider tests remain labelled engineering evidence.''',
     'An operator can create and complete the credit-note lifecycle in web, including documents and provider state. Existing fake-GSP persistence tests alone cannot close it.')

task(16, 'Complete finance, booking and two-sided rate-cut journeys', 'P06-01 P06-02 P06-03 P06-04 P06-05 P06-06', 'X05 X06 X07 X08',
     'RATE_CUT_REC and rich tenders now exist; old absence wording is superseded, but full configured accounting acceptance remains open.',
     'web/apps/api/src/modules/finance\nweb/apps/api/src/modules/sales/rateCut.ts\nweb/apps/api/src/modules/inout/fineInout.ts\nweb/apps/web/components/PaymentForm.tsx\nweb/apps/web/app/(app)/txn/rate-cut/page.tsx\nweb/apps/api/test/rateCutSettlement.db.test.ts',
     '''Verify cash/bank/contra/journal/opening/fine-transfer/bill-to-bill/clearance variants against their own MAIN_BOOK roles and money/metal signs.
Preserve per-line cheque/UPI/card/bank identity, payee, charges, dates, account slots and debit/credit/kasar directions. Do not replace identity rows with header totals.
Reuse rate-cut receive writer/reader/reversal and expose all received-line/child/settlement values; reconcile PR_* totals and both money/fine legs with issue-side results.
Implement multi-party booking and remaining fine/quantity/rate allocation, including basis per piece/gram/ten grams/kg, conversion, premium and ADJ_WT lifecycle.
Finish due-date/aging and residual bill selectors and run opening -> purchase/sale -> mixed payments -> allocation -> clearance -> journal/fine transfer -> closing reports.''',
     '''Issued-only, received-only, two-sided and zero/blank-rate cuts match desktop for each permitted basis and sign.
Split UPI/cheque payments preserve distinct identities and correct book-specific role codes.
Two simultaneous settlements/booking drawdowns cannot overconsume; refund/delete releases only its own allocation.
Changed source totals, locked periods and cross-year historical settlements follow explicit rules.
Trial balance, daybook, bank statement, fine outstanding and supplier/customer balance each reconcile to source documents, not merely aggregate zero.''',
     'All accounting variants and complete business closing have desktop/DB/report agreement and accountant acceptance.')

task(17, 'Join approval, consignment, tour, parcel and repair stages', 'P05-05 P05-07 P05-08', 'X05 X07 X13',
     'Standalone stage pages cannot prove custody, partial completion and settlement continuity.',
     'web/apps/api/src/modules/tour\nweb/apps/api/src/modules/repair\nweb/apps/api/src/modules/sales/vpParcel.ts\nweb/apps/web/app/(app)/txn/tour/page.tsx\nweb/apps/web/app/(app)/txn/tour-return/page.tsx\nweb/apps/web/components/RepairImagePanel.tsx',
     '''Map TR_APR_ISU/TR_TOUR/TR_TOUR_ORD/TR_TOUR_SALE/TR_VP/TR_VP_ADJ and repair callers by issue/return/sale/delivery state and permissions.
Implement remaining source selectors, available issued tags/components, photos, responsibility/location, promised dates and stage history.
Keep customer-owned repair custody distinct from business-owned stock; connect estimate/labour/charges and final settlement.
Support mixed partial sale and return from one issue and partial karigar repair receipt before final customer delivery.
Add dependency-protected stage corrections and reverse the actual source allocation, image/reference and financial effects.''',
     '''Issue multiple items -> sell one -> return another -> reconcile still-out state and source availability.
Duplicate import and over-return fail; cancellation cannot release stock already consumed downstream.
Repair receive -> issue -> partial return -> completion -> customer delivery/refund retains custody and images.
Branch responsibility change, missing photo, device failure and stage reversal produce defined recoverable states.
Customer, employee/karigar, stock and outstanding reports explain every movement.''',
     'All required custody and repair journeys finish through real screens with exact state, settlement and document continuity.')

task(18, 'Complete stock identity/openings and certify tag transfer', 'P07-01 P07-02 P07-03', 'X05 X06 X07',
     'CR-01: stock in/out and opening improvements exist; tag transfer remains contained.',
     'web/apps/api/src/modules/stock/stockInout.ts\nweb/apps/api/src/modules/stock/stockVoucherLifecycle.ts\nweb/apps/api/src/modules/stock/tagOps.ts\nweb/apps/api/src/modules/stock/tagInvariants.ts\nweb/apps/api/test/tagOpeningRoundTrip.db.test.ts\nweb/packages/core/containment.mjs',
     '''Define available/reserved/issued/sold/returned/canceled/replaced/split tag states by exact tag instance and table-specific serial; align lookup, reports and locks.
Reverify item/tag/lot openings, stock in/out and adjustments with complete HUID weights, component costs, images, counters and purchase/manufacturing lineage through browser payloads.
Trace transfer mode in TR_TAG_CAN and related stock helpers; reuse current domain work after comparing exact old/new BAR/IDTL/image and stock identities.
Implement complete transfer list/open/edit/delete, destination/location/counter rules, shared locks and source/destination reversal.
Evaluate transfer containment separately; update stale explanatory text without removing the block until its own desktop, lifecycle and concurrency evidence passes.''',
     '''Two live/historical instances share a visible tag number; transfer selects exactly the intended serial.
Rich opening unchanged save preserves all business columns, children and images; linked stock blocks invalid deletion.
Transfer across permitted counters/locations preserves pieces/gross/net/fine/components/cost and lineage.
Concurrent transfer versus sale, invalid destination and midway failure leave one valid state.
Reverse/edit transfer only when dependency rules permit; reports match before/after desktop snapshots.''',
     'Stock state is consistent everywhere and transfer has its own complete release evidence. Other contained tag operations remain separately gated.')

task(19, 'Certify tag cancellation independently', 'P07-03', 'X18',
     'Tag cancellation has tests and implementation changes but remains blocked at the route.',
     'unified/src/csharp/DataCareNext/TR_TAG_CAN.cs\nweb/apps/api/src/modules/stock/tagOps.ts\nweb/apps/api/test/tagCancelIdentity.db.test.ts\nweb/apps/web/app/(app)/txn/tag-cancel/page.tsx\nweb/packages/core/containment.mjs',
     '''Extract cancellation-specific live serial, source references, tag lot/polish/target-table inputs and permitted dependent states; distinguish transfer mode.
Audit existing cancel reader/writer/reversal against complete BAR detail, child, image and source lineage requirements.
Complete browser selection/open/edit/delete and validation/error focus for only operator-editable fields.
Use shared stock locks and exact availability checks; preserve a discoverable cancel audit/history.
Lift only cancellation containment after reviewed evidence meets the stated gate; neither a helper test nor HTTP 200 is sufficient.''',
     '''Cancel exactly one intended live serial with a historical same-number serial present.
Consumed/reserved/issued tags are handled according to the measured dependency rules.
Unchanged/changed cancel and permitted reversal preserve rich details and restore availability exactly.
Concurrent sale or transfer yields one permitted transition; a denied/failing cancel writes nothing.
Stock, component, image lineage and desktop cancel document/state match.''',
     'Cancellation can be completed and reversed through the allowed web lifecycle with independent evidence, without changing other tag release states.')

task(20, 'Complete atomic tag split and child conservation', 'P07-04', 'X18',
     'Tag split remains contained; inspect current child creation before relying on the registry description of old deficiencies.',
     'web/apps/api/src/modules/stock/tagSplit.ts\nweb/apps/api/src/modules/stock/tagInvariants.ts\nweb/apps/web/app/(app)/txn/tag-split/page.tsx\nweb/packages/core/containment.mjs',
     '''Resolve actual desktop split dispatch and input/output/settlement grids; author quantity, weight, fine, cost and component allocation equations.
Verify/complete atomic parent consumption, unique child serial allocation, BAR headers/details/IDTL, images, parent links, stock and any measured financial effects.
Implement unequal child allocations and explicit residual/wastage/rounding policy; never silently drop remainders.
Expose complete child values and source selection with read/edit/delete and downstream-consumption locks.
Release only the split operation after its own complete artifact set.''',
     '''Unequal split with at least three children, two components and images conserves all applicable measures at source precision.
Duplicate child IDs, empty children, over-allocation and invalid mixed output items fail atomically.
Concurrent parent sale/split allows only one valid consumption.
Inject failure after preparing some children: no orphan barcode, image or stock row remains.
Changed split and reversal preserve identity and refuse invalid downstream dependencies.''',
     'Desktop-equivalent parent/child state, conservation, lifecycle and real-browser behavior are demonstrated before split containment removal.')

task(21, 'Complete weight replacement and sale-driven tag differences', 'P07-05', 'X18 X08',
     'Tag weight difference remains contained; SL_TAG_WT_DIFF is a separate sale-driven policy branch.',
     'web/apps/api/src/modules/stock/tagOps.ts\nweb/apps/web/app/(app)/txn/tag-weight-diff/page.tsx\nweb/apps/api/src/modules/shared/settingsBehavior.ts\nweb/apps/api/src/modules/sales/sales.ts\nweb/packages/core/containment.mjs',
     '''Trace the actual old/new tag replacement contract and Ac_Stock sale-driven SL_TAG_WT_DIFF branches; keep distinct requirement IDs.
Verify/complete serial linkage, barcode detail, IDTL, HUID weights, images, karigar values, settlement, Rojmel and stock effects; net-stock adjustment alone is insufficient.
Provide source/live-instance selector, derived differences and complete reopen/edit/reversal paths.
Apply common tag locks and dependency restrictions; bind financial effects to configured account slots.
Retain containment until all replacement branches, including no-change and source-consumed behavior, have independent results.''',
     '''Positive, negative and no-change weight differences agree on old/new tag and movement state.
Tagged and permitted untagged cases retain components/images and exact reference serials.
Toggle SL_TAG_WT_DIFF on the same sale fixture and compare source-confirmed special stock rows.
Concurrent sale/replace and failed replacement leave no mixed identity or half-posted settlement.
Unchanged edit and allowed reversal reproduce full rich state, not just total net weight.''',
     'Both explicit replacement and sale-driven weight-difference contracts are satisfied with separate evidence and correct release disposition.')

task(22, 'Finish physical stock sessions and inventory reconciliation', 'P07-06', 'X18',
     'Counting endpoints and reports exist; session finalization and business consistency require full acceptance.',
     'web/apps/api/src/modules/stock/physicalStock.ts\nweb/apps/api/src/modules/reports/physicalStock.ts\nweb/apps/web/app/(app)/txn/physical-stock/page.tsx\nweb/apps/api/test/physicalStock.db.test.ts',
     '''Define count-session identity, cutoff/snapshot and permitted counter/location/lot filters from the desktop workflow.
Implement scan/manual input, expected versus counted quantities, duplicate/unknown/wrong-location feedback and component differences.
Define handling of stock movement during counting and require a preview of every adjustment before supported finalization.
Make finalize atomic/idempotent with traceable adjustment references, cancel/reopen rules and report drill-back.
Connect HUID, movement, valuation, stock-level and component outputs to the same stock-state contract.''',
     '''Duplicate scans do not double-count; unknown and wrong-location tags are visible exceptions.
A sale after the snapshot is reconciled explicitly rather than silently overwritten by count finalization.
Two finalization attempts post one permitted adjustment set.
Missing/extra tags, weight/piece/component differences and canceled sessions match desktop rules.
Preview, posted adjustments and stock reports agree exactly.''',
     'A stock clerk can count, resolve discrepancies and finalize/reverse as allowed, with complete stock and report reconciliation.')

task(23, 'Complete manufacturing variants and the lot workflow', 'P08-01 P08-02 P08-03 P08-04 P08-05 P08-06', 'X04 X05 X07 X11 X18',
     'CR-06: ITM_LOT persistence and mfgLotBalance support parts of the contract; no dedicated lot operator journey was found.',
     'unified/src/csharp/DataCareNext/TR_MFG_WITH_LOT.cs\nweb/apps/api/src/modules/manufacturing/mfg.ts\nweb/apps/api/src/modules/manufacturing/karigar.ts\nweb/apps/api/src/modules/manufacturing/melting.ts\nweb/apps/api/test/mfgLifecycle.db.test.ts\nweb/apps/api/test/meltingPro.db.test.ts\nweb/apps/web/components/KarigarForm.tsx',
     '''Create state/transition and material conservation contracts for order/free/stage/karigar/jobwork/ghat/jadtar/item/lot/melting modes; inspect all MFG source callers and stock flags.
Reuse generic issue/receive logic only where the variant contract matches. Add dedicated TR_MFG_WITH_LOT routes/screen or a proven explicit mode with source-lot selectors and full read/edit/delete; name any proposed path as new until implemented.
Complete lot balance locking and partial consumption, source serials, component return/breakage, chole/ghis/ghat/other losses, customer/karigar valuation and payment/received rows.
Join order/design -> issue/reissue -> partial receipt/rework -> stage completion -> tagging -> delivery/sale, preserving photos and specification.
Verify melting multiple inputs/outputs, assay changes, loss/byproducts/residual fine and financial settlement. Run the dedicated 55433 suite without exclusion.''',
     '''Lot issue -> first partial receipt -> second receipt -> exhausted lot; over-receipt and concurrent drawdown fail.
Several lots and components with distinct source serials preserve allocation and return/breakage through edit/reopen.
One order across multiple karigars/receipts and unfinished work across a year boundary remains traceable.
Multiple melting inputs/outputs with changed purity reconcile physical material and fine against explicit losses.
Failed intermediate stage, reissue, canceled receipt and downstream sale dependencies preserve valid WIP, lot, karigar and stock balances.''',
     'Every manufacturing variant and the full manufacturing business day works in browser with exact material/financial/report evidence; a lot report cannot satisfy the transaction requirement.')

task(24, 'Certify loan, dhiran and scheme business continuations', 'P09-01 P09-02 P09-03 P09-04 P09-05', 'X04 X05 X07 X16',
     'Loan and scheme-gold-adjust surfaces were added; date/interest/custody/redemption variants still need complete acceptance.',
     'web/apps/api/src/modules/dhrn/dhrn.ts\nweb/apps/api/src/modules/membership/scheme.ts\nweb/apps/web/app/(app)/txn/loan-issue/page.tsx\nweb/apps/web/app/(app)/txn/loan-received/page.tsx\nweb/apps/web/app/(app)/txn/scheme/page.tsx\nweb/apps/api/test/dhrnLoanLifecycle.db.test.ts\nweb/apps/api/test/schemeGoldAdjust.db.test.ts',
     '''Reconcile each desktop loan/dhiran/khata/opening/interest menu direction and book; preserve borrower, pledge-item, photo, valuation and custody identity.
Complete source-cited monthly/daily interest, inclusive-date/year basis, principal changes, backdates, blank/zero/manual override and reversal behavior.
Implement full enrollment/member/nominee/terms and installment history with tender identities; distinguish scheme from points/loyalty.
Join arrears/prepayment/bonus/maturity/gold-money adjustment/refund/invoice redemption and canceled invoice release with atomic available-balance control.
Prove the same operations against migrated open loans and partially paid schemes, using historical terms rather than silently applying current defaults.''',
     '''Month ends, leap day, same-day receipt, partial principal and explicit zero interest match independent vectors.
Pledge -> disbursement -> interest/principal -> closure/release preserves item custody and receipts.
Enroll -> split installments -> mature -> partial redemption -> invoice return/cancel reconciles money/fine and member history.
Concurrent redemption, duplicate payment, source receipt deletion after adjustment and over-refund are rejected correctly.
Passbook, loan ledger, scheme commission/balance and accountant reports match full saved state across branches/years.''',
     'Every loan/scheme mode and normal/exception continuation has real operator, desktop, calculation, custody and report acceptance.')

task(25, 'Complete scoped document binding and actual child output', 'P10-01 P10-05 P10-06', 'X05 X07',
     'Order scope and actual child/image binding are implemented for five explicit templates. Historical image provenance, all other report contracts, physical output and full-product acceptance remain open.',
     'web/apps/api/src/modules/reports/reportBind.ts\nweb/apps/api/src/modules/sales/orderDoc.ts\nweb/apps/api/src/routes/txn.ts\nweb/apps/api/test/reportBind.test.ts\nweb/apps/api/test/reportRender.db.test.ts\nunified/src/csharp/DataCareNext/MS_PRINT.cs',
     '''Replace inference-only primary-table detection with explicit template/mode bindings containing required header/detail/child datasets, joins, parameters and formats. Preserve explicit unsupported errors.
Read actual IDTL children keyed to their exact parent; do not synthesize child aliases from a parent detail row. Handle template subreports/groups/formulas according to extracted and runtime evidence.
Correct order document location/year scope and audit all direct document renderers, not just /reports/render.
Match selection/preview/print/cancel, original/duplicate/triplicate, default focus, book/branch formats, headers/footers, images, signatures, QR/barcodes and reprint history.
Preserve data and authorization through PDF/CSV/XLSX and report-to-voucher drill-down. Keep business fields and totals exact; visual tolerances apply only to rasterization.''',
     '''Two children with distinct values print as two correct child records, with no parent-value substitution or duplication.
Same-number vouchers in two locations/years produce independent header/detail/child/party results.
Unknown or ambiguous templates refuse; they cannot render sales as a fallback.
One-line, long Unicode description, many-line/multi-page, missing image, return/negative and large-number documents match desktop data/layout.
Copy labels, preview versus physical print, default printer/template and restricted-role direct render/export behavior meet the contract.''',
     'Each supported document renders correct scoped data including children and has independent semantic, visual and required physical print evidence.')

task(26, 'Close the complete report and mode universe', 'P10-02 P10-03 P10-04 P10-07', 'X01 X06 X25',
     'Report endpoints increased, but the required current desktop-report comparison artifact is absent.',
     'parity-plan-2026-09-10/evidence/report-register.json\nweb/apps/api/src/modules/reports/reportAuthorization.ts\nweb/apps/api/src/modules/reports/reportFilters.ts\nweb/apps/api/src/modules/reports\nweb/apps/web/app/(app)/reports/[report]/page.tsx',
     '''Map all report screens, launcher parameters, direct routes, supplied Crystal files and absent references to explicit required report/mode IDs. Reuse newly implemented report families after contract verification.
Extract formulas, parameters, grouping/sort/subreport/suppression/running-total behavior and dynamic template selection; resolve missing artifacts through X32.
Complete financial/accounting/GST/outstanding/interest/aging/valuation modes and stock/WIP/lot/order/customer/scheme/tour/graph/audit specialists, with all applicable filters.
Define blank/all/single/multiple/invalid/unsupported filter semantics and enforce them consistently on direct routes and exports.
Produce report-comparison evidence per expected mode, fixture and candidate with rows/columns/totals, semantic differences, PDFs/images and operator acceptance; feed exact-set gate X34.''',
     '''All required report IDs return a result, including valid empty datasets; missing/skipped/duplicated reports fail.
Different party/group/location/year/metals/valuation filters select the independently expected rows and totals.
Transactions from X12–X24 reconcile to daybook, stock, outstanding, financial and specialist reports.
View/print/export permissions and drill-back preserve original scope and filter context.
Removing one mandatory report from an otherwise all-pass result must fail certification.''',
     'Every required report/mode is independently compared and approved; endpoint count and web-only layout baselines cannot substitute.')

task(27, 'Complete correction and bulk utility reference closure', 'P11-01', 'X05 X06 X08',
     'Data export/reset/repair work exists, but every reference-changing utility requires a complete ownership graph.',
     'web/apps/api/src/modules/utilities\nweb/apps/api/src/modules/vouchers\nweb/apps/web/app/(app)/utilities/data-repair/page.tsx\nweb/apps/web/app/(app)/utilities/data-export/page.tsx\nweb/apps/web/app/(app)/utilities/estimate-reset/page.tsx\nweb/apps/api/test/correctionWorkflow.db.test.ts',
     '''Trace desktop user-request correction separately from ordinary allowed edits/deletes; preserve requested action, review/authority, reason and history where required.
Build reference graphs for renumber, cross-book transfer, refresh, reset, balance transfer, import/export and year-end; include detail/child, UPI, ledger, stock, tax, allocations, images and historical sources.
Implement preview, authorized execution, progress, cancellation/interruption semantics and deterministic before/after reconciliation.
Apply CUR_DAY_POSTING full/from-date stock-refresh behavior from source; avoid a guessed date restriction.
Keep scope-limited changes atomic and repeat-safe; revalidate all reports and source-link readers affected by key changes.''',
     '''Preview equals actual touched keys/rows/effects on the frozen fixture.
Two companies/years sharing keys remain unaffected outside the selected operation.
Interrupt midway, retry, encounter collision/locked period/dependency: no partial reference rewrite remains.
Repeated reset/refresh cannot duplicate effects; missing required source data fails instead of empty success.
Related records remain discoverable and printable after renumber/transfer/correction.''',
     'Every required utility finishes its supported business operation with complete reference integrity, recovery and audit evidence.')

task(28, 'Validate devices and real provider state machines', 'P11-02 P11-03', 'X09 X15',
     'CR-14: fake integrations and interface tests do not establish shop-device or provider capability; no web Olocker implementation was found in the reviewed source search.',
     'web/apps/api/src/modules/integrations\nweb/apps/api/src/modules/einvoice\nweb/apps/api/src/modules/integrations/messaging.ts\nweb/apps/api/test/scaleProtocol.test.ts\nunified/src/csharp/DataCareNext/OlockerService.cs\nunified/src/csharp/DataCareNext/TR_SALE.cs',
     '''Inventory required OS/browser/scale/scanner/camera/A4/thermal/tag/cheque printer combinations and protocols from actual shops; document installation/pairing/permissions and local bridge responsibility.
Implement stable/tare/unit/precision handling, scanner terminators/focus/duplicates, image capture/ownership and printer-copy/media behavior using existing adapters where valid.
Trace saved/reopened invoice Olocker action and its fields/status/print or policy effects; implement any confirmed missing capability with explicit saved-document linkage.
Verify official current GSP/messaging/rate/provider documentation during implementation, record versions, and distinguish historical compatibility from accepted current requirements.
Persist submission/attempt/provider identities and pending/status/retry/cancel states; handle provider success followed by local persistence failure without duplicate external effects. Use authorized sandbox/test destinations for integration checks.''',
     '''Real scale readings, disconnect/reconnect, unstable weight, unit conversion and scanner bursts enter the correct form values.
Actual supported printers produce readable labels/receipts/A4/cheques with correct copies and dimensions.
Provider timeout after acceptance is resolved through status and stable request identity; retry does not fabricate another success.
Missing credentials, rejected payload, cancel, stale rate and background retry surface actionable states.
Fake IDs/results can never appear as live certification; device/provider evidence names actual tested versions and configuration.''',
     'All required physical/provider workflows have real test evidence and production-ready state handling. Missing devices/credentials remain explicit acceptance dependencies.')

task(29, 'Finish role-specific navigation, lifecycle jobs and audit', 'P11-04 P11-05', 'X01 X05 X09',
     'Route catalogs exist, but per-role end workflows and desktop startup/timer ownership require closure.',
     'web/apps/api/src/modules/rbac/formCatalog.ts\nweb/apps/api/src/modules/rbac/routePolicy.ts\nweb/apps/web/lib/nav.ts\nweb/apps/web/components/Shell.tsx\nunified/src/csharp/DataCareNext.My/MyApplication.cs\nunified/src/csharp/DataCareNext/MDI_FORM.cs',
     '''Reconcile menu/mode authority to list/view/add/edit/delete/print/export/provider/utility actions, including documents and images reached from another form.
Verify tenant isolation with non-owner runtime DB roles and company/location/year/form authority through real API requests; navigation visibility alone is not evidence.
Trace login/load/shutdown, saved preferences, daily-rate/reminders, timers, Module_Schm.bgWorker and async callers; assign server versus browser responsibility explicitly.
Implement job ownership, schedule/timezone, deduplication, retry/credential failure and visible job status so multiple tabs cannot repeat a business action.
Add operator-oriented help/search and recovery prompts; audit actor/time/reason/reference before and after corrections without exposing unnecessary private data in diagnostics.''',
     '''Cashier, accountant, stock clerk, manufacturing, salesperson and read-only roles can finish permitted journeys and cannot directly invoke denied actions.
Denied operations leave no business side effects or leaked cross-scope document/image data.
Two tabs and two worker instances start the same scheduled action: one accepted business effect.
Restart, delayed job, credential error and local-date boundary preserve schedule/status correctness.
Fresh-user onboarding finds every required allowed mode and retains only the correct user/device/form preferences.''',
     'Every action and lifecycle job has measured ownership, role/scope enforcement and discoverable operator behavior across supported contexts.')

task(30, 'Implement complete migration and continued historical business', 'P12-01 P12-02 P12-03', 'X01 X05 X06 X32',
     'Production loading remains contained; table counts alone do not establish usable migrated workflows.',
     'web/apps/api/integration/cutover.mjs\nweb/apps/api/integration/parity-import-masters.mjs\nweb/apps/api/src/modules/ops/backupManifest.ts\nweb/docs/runbooks/migration.md\nweb/packages/core/containment.mjs',
     '''Inventory every business/shared/auxiliary DB, image/template/file source, schema/type/collation/key/ownership rule and required sequence; assign migrate/rebuild/archive dispositions without omitting unsupported active features.
Implement read-only extraction to validated staging and a restartable scoped shadow loader with dependency order and technical ID mappings. Never substitute tenant-wide replacement for company/year scope.
Validate exact expected table/key/field sets, null/blank/zero and binary hashes; distinguish absent input from explicitly empty table.
Run two representative business histories through two clean shadow loads with reconciliation of money/fine/stock/outstanding/WIP/schemes/loans/photos/templates.
Continue business through UI: print historic vouchers, return imported sale, pay imported bill, consume remaining tag/lot/order, redeem scheme, close loan and reverse the new dependent action. Preserve historical rules and current effective rules separately.''',
     '''Two companies and years sharing identifiers load without cross-scope replacement.
Missing/corrupt rows, orphan references, partial extraction, loader restart and duplicate replay have explicit failing/recoverable outcomes.
Second clean load reproduces exact key/value/hash and sequence state.
Imported partial documents can be completed and reversed without desktop or SQL workaround.
Every difference is reconciled by business effect and reviewed; production load containment is evaluated only after the full gate evidence.''',
     'Complete scoped repeatable migration and active historic continuations are independently reconciled and business accepted before production loading is released.')

task(31, 'Certify restore, deployment and continuity topology', 'P12-04 P12-05', 'X03 X09 X30',
     'Logical restore is contained and Docker health is not a tested production recovery or offline-service result.',
     'web/apps/api/src/modules/ops/backup.ts\nweb/apps/api/src/modules/ops/restoreVerification.ts\nweb/scripts/restore-drill.mjs\nweb/deploy/docker-compose.prod.yml\nweb/DEPLOY.md\nweb/packages/core/containment.mjs',
     '''Reconcile actual deployed API/web/schema/image identities, migrations, TLS/proxy, roles/pools, background services, backup/object storage and configured local/LAN/cloud topology.
Back up DB, attachments, templates, configuration and sequence state; identify protected credentials/keys required for recovery without writing them into plan evidence.
Restore physical and logical company backups into separate targets and run real business continuations; verify another company's data is untouched.
Measure agreed RPO/RTO, load/soak, connection exhaustion, restart, planned outage, failed migration and rollback; include observability and actionable runbooks.
Retain logical-restore containment until its engineering plus controlled deployment/drill and explicit release requirements are satisfied. Keep drill evidence separate from authorization to restore a real customer target.''',
     '''Incomplete/corrupt backup refuses safely; valid restore reproduces exact hashes/counts/keys/balances and sequences.
Interrupted single-company restore does not alter another company and leaves a recoverable state.
Recovered target sells/settles/prints/reports with the same configuration and attachment availability.
Internet/LAN/device/server failure behavior matches X09 service commitments; reconnect does not duplicate work.
Rolling/backward-compatible migration and switchback preserve accepted writes; alerts detect stale backups and failed outbox/provider attempts.''',
     'Production-like deployment and timed recovery/outage acceptance are proven for the selected topology, with explicit controlled release of contained recovery operations.')

task(32, 'Resolve editions, companion functions and absent artifacts', 'P13-01 P13-02 P13-03', 'X01',
     'Edition filenames and delta counts are inventoried; unique business behavior and unresolved runtime artifacts are not closed.',
     'parity-plan-2026-09-10/evidence/edition-delta.json\nparity-plan-2026-09-10/evidence/supporting-source-register.json\nparity-plan-2026-09-10/evidence/report-register.json\nunified/src/csharp/DataCareNext',
     '''Identify exact supported primary/NextDm executable versions and configurations; use hashes and runtime menu/caller evidence rather than filenames to decide their relationship.
Review the 123 changed shared files, primary-only files and UAE forms for unique data/rule/report/operation behavior; attach new leaf tasks to their domain parents.
Inspect NextEmp/NextImage and installer/dependency assets for employee/image/report/device functions consumed by the primary product.
Resolve the 20 absent report references, resource/ActiveX controls, dynamic branches and eight support units with actual desktop observation where needed.
Keep unresolved and untested behaviors required by default. Record source-proven duplicate/dead artifacts with caller/configuration proof; a pilot exclusion cannot silently shrink the full product.''',
     '''Every unique reachable edition/country/companion behavior has a web path and test contract or remains explicitly open.
Two differing binaries cannot share one passing certificate without a reviewed semantic equivalence map.
Missing template/control dependencies prevent the related requirement from closing.
Unexercised behavior in a sparse dataset is never called dead solely due to zero rows.
New variant discovery expands expected requirement/case sets and invalidates affected acceptance.''',
     'The full intended product/version universe has no unresolved reachable behavior or required artifact, and all unique requirements feed domain acceptance.')

task(33, 'Execute full journeys, business UAT and transition acceptance', 'P14-01 P14-03 P14-04 P14-05', 'X03 X06 X12 X13 X14 X15 X16 X17 X18 X19 X20 X21 X22 X23 X24 X25 X26 X27 X28 X29 X30 X31 X32',
     'All-product business and production acceptance are unestablished; isolated passing tests cannot replace this phase.',
     'parity-plan-2026-09-10/03-verification-and-release.md\nweb/docs/PARITY-WINDOWS-PROCEDURE.md\nweb/docs/MODULE-VERIFICATION-CATALOGUE.md',
     '''Expand the 128 scenario anchors and universal form matrix across all applicable contracts/settings/roles/books; freeze expected IDs before running. These anchors are a minimum, not the final test count.
Run the complete real-browser journeys listed below with independent DB and desktop/document/report results; include imported histories and every normal/error/reversal transition.
Ask experienced retail/wholesale/accounting/manufacturing/stock/scheme/loan operators to complete realistic work without scripted click guidance; measure errors, task time, keystrokes, lookup success, print usability and recovery.
Resolve defects and accepted deliberate behavior differences with requirement links; rerun affected descendants/cross-module journeys after changes.
Prepare timed cutover/rollback rehearsal and candidate-specific go/no-go. At separately authorized rollout, reconcile daily closures during the agreed observation window, account for new web writes if rollback is required, and obtain business handover acceptance.''',
     '''Every required journey has a complete pass or a named blocking issue; no skipped/empty/missing journey is counted.
Operators complete normal and exception business without mandatory desktop fallback or manual database work.
Multiple business configurations meet correctness and agreed throughput requirements.
Cutover rehearsal reconciles opening/closing money, fine, stock, outstanding, provider state and attachments.
Rollback handles accepted new web transactions explicitly; stabilization evidence covers all intended deployed configurations.''',
     'Every required business journey and production transition has independent technical and role-based business acceptance for the actual candidate. A successful pilot certifies only its declared subset.')

task(34, 'Enforce exact-set certification and one current progress record', 'P00-05 P14-02 P14-06', 'X01 X02 X04',
     'CR-12/13: nested workflow location, incomplete leaf-set enforcement and candidate provenance remain gaps despite the existing gate framework.',
     'web/.github/workflows/ci.yml\nweb/.github/workflows/release-certification.yml\nweb/scripts/release-certify.mjs\nweb/apps/api/src/modules/ops/releaseCertification.ts\nweb/scripts/check-completion-register.mjs\nweb/apps/api/test/releaseCertification.test.ts\nweb/apps/api/test/kernelConformance.test.ts',
     '''Place/adapt application CI and release workflows under the actual repository-root .github/workflows, preserving correct web working directories and package lock/cache paths. Verify the remote required checks really execute.
Before running certification, verify checked-out commit, relevant clean-tree status, dependency/schema/template hashes and running image/build digests; reject a supplied SHA that does not identify the tested tree.
Freeze requirement/case/report/device/integration/migration/UAT sets and hash them; require exact ID equality, valid statuses, nonzero expected assertions, complete tables/fields and current evidence for each member.
Add explicit real-browser, report-layout/physical device, provider, migration-continuation, recovery/outage and business acceptance evidence to the controlling release contract; the current 17 gate declarations are only a starting point.
Implement dependency-based evidence invalidation and actual CI artifact retrieval. A secret containing a local path is not an uploaded report.
Keep implementation/engineering/desktop/business/production stages separate in the register, 07 backlog and handoff. Review raised bypass ceilings as debt, not as proof of newly correct behavior; full-product release cannot accept dead-in-one-dataset as an exclusion.''',
     '''A one-report all-pass file fails when the required set has more reports; missing/duplicate/unexpected case IDs fail.
Zero executed tests, skipped DB/browser suite, synthetic desktop data and baseline rewrites fail release.
Dirty or mismatched source, image, schema, lock or template identity and stale evidence fail before certification.
Changing shared rounding/posting/settings/binder code invalidates every linked affected result.
All original 83 packages and every new descendant must be accepted; a completed task heading or 198 declared routes cannot close them.
Remote CI evidence retrieval and failing negative controls are retained with the candidate; missing devices/UAT cannot be replaced by mocked checks.''',
     'One auditable current record reports true stage counts; release rejects all missing, stale or incomplete full-product obligations. No 100% claim while any mandatory path is partial, contained or unverified.')


# Current progress supplements the original acceptance definitions; it does not close cards.
IMPLEMENTATION_PROGRESS = {'X02': {'asOf': '2026-09-11 round 4',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/20-implementation-progress-round4.md',
         'acceptanceChanged': False,
         'implementedOrInvestigated': 'Bounded request tracing now follows actually called named '
                                      'import/export paths instead of borrowing unrelated sibling exports. '
                                      'Four derived Sales/Quotation controls were corrected. Stricter '
                                      'tracing exposes 33 unresolved Sale Return controls among 708 checked '
                                      'columns; no baseline or budget was raised. The depth heuristic '
                                      'additionally counts server-only requireDesignSelection, which must '
                                      'remain server-owned.',
         'remainingBeforeAcceptance': ['Repair remaining unsupported descriptor consumers and dynamic '
                                       'request/helper syntax with failing negative controls; inspect the '
                                       'exact diagnostic paths before crediting any field.',
                                       'Complete full runtime field/value paths through UI, request, writer, '
                                       'reader, reports and reversal. Static consumption and source-name '
                                       'counts are not functional parity.',
                                       'Close the 33 exposed Sale Return paths under X13 and existing '
                                       'depth/kernel debt. Preserve the historical failed and intermediate '
                                       'passing logs, and distinguish stricter discovery from a newly broken '
                                       'runtime path.']},
 'X11': {'asOf': '2026-09-11 round 4',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/20-implementation-progress-round4.md',
         'acceptanceChanged': False,
         'implementedOrInvestigated': 'Sales F1 now lists company/item-product Design Book rows using exact '
                                      'source identity and version, applies only source-defined new-row '
                                      'defaults, preserves existing-row rules and journals ordered '
                                      'selection/clear/calculation events. Picker supports image preview, '
                                      'explicit clear and keyboard focus containment. Existing Design Book '
                                      'lifecycle/repeat/calculation remains.',
         'remainingBeforeAcceptance': ['Read '
                                       'web/docs/parity-evidence/X11-sales-design-selection-round4-contract-2026-09-11.md '
                                       'and round4/x11-help-cancel-source-trace.json before further changes. '
                                       'The deeper shared-help source supersedes the round3 assumption that '
                                       'ordinary Escape necessarily cancels without clearing; web Escape '
                                       'preserves the draft pending independent desktop/business acceptance.',
                                       'Follow '
                                       'evidence/implementation-2026-09-11-round4/x11-shared-help-next-contract.md '
                                       'and its pinned source JSON for CO_SET.HELP_SERCH default S, S/M text '
                                       'and numeric/weight search, W/A traversal, no-match state, keyboard '
                                       'focus, returned fields and MsCreat propagation. Its 10-step '
                                       'implementation sequence and fixture matrix are mandatory; unresolved '
                                       'IL/runtime branches must remain explicit.',
                                       'Implement and verify remaining MS_HELP Up/Down selection, Left/Right '
                                       'active search column, grid Enter/Backspace and F1 create/subcreate '
                                       'modes with exact mode guards; do not equate modal Tab/Escape with '
                                       'the full shared desktop command set.',
                                       'Complete remaining focus/configuration/numeric midpoint and locale '
                                       'branches and downstream manufacturing design use. Tour selection is '
                                       'not inferred from Sales. Independently execute desktop and accept '
                                       'documented differences.']},
 'X14': {'asOf': '2026-09-11 round 4',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/20-implementation-progress-round4.md',
         'acceptanceChanged': False,
         'implementedOrInvestigated': 'Configured ordinary Sales now supports complete '
                                      'New/create/load/edit/delete, exact dates/clocks, complete nested '
                                      'detail hydration, stale-save guards, scoped images/print and '
                                      'source-driven Design selection with cached calculation events. '
                                      'Imported decimals/NULLs/hidden columns survive unchanged edits; '
                                      'explicit field intent distinguishes deliberate zero/blank changes. '
                                      'Tour and prior saved-image/report slices remain.',
         'remainingBeforeAcceptance': ['Read round4 Sales UI/API source contracts and retain '
                                       'same-voucher/two-book, historical-year, raw snapshot, '
                                       'complete-array, stale update/delete and scope-change checks when '
                                       'extending the workflow.',
                                       'Implement desktop pre-opening-date confirmation and lock behavior '
                                       'explicitly; the current web refuses this unsupported branch. '
                                       'Complete later tax/MRP/visibility passes, '
                                       'tender/received-metal/allocation editing and reversal, and supported '
                                       'tag-stock transitions.',
                                       'Complete quotation/order partial delivery, fulfillment conversion, '
                                       'cancellation/refund and cross-module conservation/retries using '
                                       'exact source footprints. Modern HTTP requires source-verified Design '
                                       'events; legacy direct service/import fixture bypass is not proof of '
                                       'equivalent user behavior.',
                                       'Complete shared-help command depth and resolve the documented Escape '
                                       'difference from independent desktop execution. Finish historical '
                                       'image provenance, generic-image client concurrency, real devices and '
                                       'desktop/physical report acceptance.']},
 'X15': {'asOf': '2026-09-11 round 3',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/18-implementation-progress-round3.md',
         'implementedOrInvestigated': 'Scoped saved credit-note reads now retain SL_DATA.LDR_CODE after its '
                                      'exact primary MS_OPNCOMP DDL was confirmed in the executable and '
                                      'migrated. Dedicated writes remain unimplemented.',
         'remainingBeforeAcceptance': ['Reimport/reconcile historical ledger overrides lost before this '
                                       'migration; resolve TCS/TDS and negative-round-off behavior from '
                                       'independent desktop execution.',
                                       'Implement dedicated versioned create/edit/delete with complete '
                                       'accounting, stock, Rojmel and GST writes plus provider '
                                       'pending/retry/cancel mutation barriers.',
                                       'Verify UI creation/posting/reopen/change/reversal/documents and '
                                       'provider acceptance separately from imported reader fixtures.'],
         'acceptanceChanged': False},
 'X23': {'asOf': '2026-09-11 round 3',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/18-implementation-progress-round3.md',
         'implementedOrInvestigated': 'Setting Isu/Rec have own-rights configured-book saved browse, exact '
                                      'parent/component/projection reads, scoped names and verified '
                                      'material-source selectors. Primary component-lot DDL was '
                                      'independently confirmed and migrated; writes remain unavailable.',
         'remainingBeforeAcceptance': ['Establish effective installation lot/order/one-form/ledger mode and '
                                       'configured direction; reconcile installed width/default differences '
                                       'while preserving data.',
                                       'Implement explicit Setting issue then partial receipt, source '
                                       'contention, conservation, edit/reversal and reports from frozen '
                                       'expected writes; do not substitute generic manufacturing '
                                       'projections.',
                                       'Run independent desktop, real-business history and full lifecycle '
                                       'acceptance in addition to scoped read/source fixtures.'],
         'acceptanceChanged': False},
 'X25': {'asOf': '2026-09-11 round 4',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/20-implementation-progress-round4.md',
         'acceptanceChanged': False,
         'implementedOrInvestigated': 'Five explicit order templates include OrdVchImg/TourOrdImg with one '
                                      'decoded image per saved parent, scoped identity, source precedence, '
                                      'strict missing/malformed diagnostics and report pagination. '
                                      'Registry28; old79 inferred templates remain contained. Saved-order '
                                      'photo tokens now include persistent revisions and raw source '
                                      'fingerprints; all application photo writers advance revisions and '
                                      'shared identities serialize concurrent mutations.',
         'remainingBeforeAcceptance': ['Complete historical image file/MOB_IMAGE transfer with proven '
                                       'ownership and collision/missing manifests; verify actual '
                                       'camera/printer/Crystal behavior and production image-volume limits.',
                                       'Add optimistic tokens to generic image editor clients and retain '
                                       'import/restore maintenance barriers; the current shared revision '
                                       'locks prevent stale saved-order writes but do not certify arbitrary '
                                       'out-of-band mutations.',
                                       'Implement every remaining template from its exact source contract '
                                       'and validate formulas, locale, copies, long text, pagination and '
                                       'printed output.',
                                       'Close full-product report acceptance independently from registry '
                                       'counts or synthetic PDF review.']},
 'X05': {'asOf': '2026-09-11 round 4',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/20-implementation-progress-round4.md',
         'acceptanceChanged': False,
         'implementedOrInvestigated': 'Ordinary Sales HTTP edits/deletes require a saved version, explicit '
                                      'configured book and complete parent/component arrays. Explicit field '
                                      'edit intent preserves imported NULLs, exact large decimals, hidden '
                                      'columns and noncontiguous identities. Shared photo revisions '
                                      'serialize writers across different orders using one image identity.',
         'remainingBeforeAcceptance': ['Reuse round4/sales-order-lifecycle-contract.md and '
                                       'order-image-concurrency-contract.md plus API source contract; verify '
                                       'full raw before/after snapshots for every remaining document family, '
                                       'including explicit zero/blank changes and rollback.',
                                       'Extend optimistic revision contracts to generic image editor '
                                       'clients, retain maintenance barriers for restore/import, and prove '
                                       'retry/idempotency semantics across all remaining document writers.',
                                       'Complete cross-family contention, settlement/dependency barriers, '
                                       'historical continuation and independent business acceptance; '
                                       'ordinary Sales and synthetic image tests do not close X05.']},
 'X31': {'asOf': '2026-09-11 round 4',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/20-implementation-progress-round4.md',
         'acceptanceChanged': False,
         'implementedOrInvestigated': 'The company backup manifest includes the new forced-RLS image '
                                      'revision table. Focused restore verifies exact BIGINT serialization '
                                      'above JavaScript safe integer range, complete table checksums and '
                                      'existing rollback/isolation behavior.',
         'remainingBeforeAcceptance': ['Keep image bytes, identity revisions and TAG index in one consistent '
                                       'backup/restore boundary; test imported/deleted/recreated identities '
                                       'and preserve maintenance locking.',
                                       'Complete deployment/continuity topology, versioned restore drills on '
                                       'representative business backups, runtime roles, full lifecycle after '
                                       'restoration and recovery objectives. The isolated 13-test backup run '
                                       'is not production recovery certification.']},
 'X13': {'asOf': '2026-09-11 round 4',
         'status': 'partial-implementation',
         'progressDocument': 'parity-plan-2026-09-10/20-implementation-progress-round4.md',
         'acceptanceChanged': False,
         'implementedOrInvestigated': 'Removed misleading editable oldSrNo/itType controls and discarded '
                                      'payload entries from ordinary Sales/Sales Quotation after desktop and '
                                      'actual-writer verification. The stricter imported-callee audit now '
                                      'exposes 33 Sale Return fields without confirmed write paths. Other '
                                      'X13 business lifecycle requirements remain open.',
         'remainingBeforeAcceptance': ['Follow '
                                       'evidence/implementation-2026-09-11-round4/x13-sale-return-33-next-contract.md '
                                       'and its 33-key source-hashed JSON. Primary MSG/outgoing SL_DETL and '
                                       'MSG_PR/incoming SL_DETL_RTN are distinct grids/write sets; separate '
                                       'UAE RATE_WITH/schema behavior. Preserve explicit unresolved '
                                       'adapter/caller/derived-field classifications.',
                                       'For each Sale Return field below, freeze exact TR_SALE_RETURN/source '
                                       'mode, hidden-versus-input classification, request mapping, '
                                       'authoritative table column, settings/stock/money effects, saved '
                                       'hydration, printed output and reversal behavior; do not blindly copy '
                                       'ordinary Sales write mappings.',
                                       'Resolve fields: ordNo, ordYrcd, ordDbcd, ordSrno, isuNo, isuYrcd, '
                                       'isuDbcd, isuSrno, huid, lessWt, bagWt, tagGrossWt, tagNetWt, ghtPct, '
                                       'itemLot, remark, discountPct, ghatAmount, rateWith, karigarNetWt, '
                                       'karigarTouch, karigarWestPct, karigarFine, employeeCode, '
                                       'orderTagStockAdd, designImageId, hallmarkId2, hallmarkId3, '
                                       'hallmarkId4, hallmarkIdWt, hallmarkId2Wt, hallmarkId3Wt, '
                                       'hallmarkId4Wt.',
                                       'Add field-family fixtures with nondefault values; prove raw writes, '
                                       'unchanged edit, intentional update, dependency/stock conservation '
                                       'and delete rollback. Derived fields must use authoritative source '
                                       'and explicit read-only display; business inputs require actual '
                                       'validated persistence.',
                                       'Retain the existing separate Sales/quotation/return and '
                                       'settlement/received-metal/tag/delivery acceptance requirements; the '
                                       'corrected controls and scanner do not close any full menu.']}}
# Round 5 supplements the bounded earlier slices; no acceptance is promoted.
for _id in ('X05', 'X25'):
    IMPLEMENTATION_PROGRESS[_id].update(asOf='2026-09-11 round 5', progressDocument='parity-plan-2026-09-10/22-implementation-progress-round5.md')
    IMPLEMENTATION_PROGRESS[_id]['implementedOrInvestigated'] += (' Generic/Design/repair HTTP image writes now require observed versions and serialize exact shared identities; absent/unavailable images carry repairable state. Shared clients guard scope, native chooser and camera callbacks and require explicit conflict reload/retry. Repair raw/list reads preserve source imageBook; Receipt images use saved serials and authoritative post-save hydration. Follow round5 image-editor-contract.md and its current verification state.')
    IMPLEMENTATION_PROGRESS[_id]['remainingBeforeAcceptance'] = [
        ('Reconcile all inherited generic image entity/instance and caller-specific rights mappings; preserve the verified client token/async barriers and import/restore maintenance barriers. Full camera/device/history acceptance remains open.' if 'generic image editor' in value else value)
        for value in IMPLEMENTATION_PROGRESS[_id]['remainingBeforeAcceptance']]
IMPLEMENTATION_PROGRESS['X17'] = {
    'asOf': '2026-09-11 round 5', 'status': 'partial-implementation',
    'progressDocument': 'parity-plan-2026-09-10/22-implementation-progress-round5.md', 'acceptanceChanged': False,
    'implementedOrInvestigated': 'Repair images retain the original customer-row year/book/voucher/serial across Karigar Issue, use shared persistent revisions and reject stale mutations. Receipt hydration retains saved noncontiguous serials; post-save reads assign authoritative image identity. Request epochs reject cancelled or superseded responses. This does not implement complete repair custody/settlement transitions.',
    'remainingBeforeAcceptance': [
        'Retain round5 image state/concurrency and real saved-source browser cases; add every repair stage and independently observed desktop image behavior.',
        'Preserve imported parent/child serials and raw values across complete Repair document edits; image identity preservation alone does not prove the existing ordinal document writers.',
        'Complete partial issue/return/delivery, custody conservation, settlement/refund, dependency-protected correction/reversal, reports, device/history and independent business acceptance.'
    ]}
for _id in ('X14',):
    IMPLEMENTATION_PROGRESS[_id]['remainingBeforeAcceptance'] = [value.replace('generic-image client concurrency', 'remaining generic image caller mapping/rights acceptance (reuse round5 client concurrency)') for value in IMPLEMENTATION_PROGRESS[_id]['remainingBeforeAcceptance']]



for _card in TASKS:
    if _card['id'] in ('X05', 'X25', 'X17'):
        _card['currentFinding'] += ' Round 5 adds versioned generic/Design/repair images, source-book readers and guarded shared clients; read document22 for verification and exact remaining descendants.'

# Round 6 starts a separate lossless saved incoming Return slice; no parent acceptance changes.
IMPLEMENTATION_PROGRESS['X13'].update(
    asOf='2026-09-11 round 6', progressDocument='parity-plan-2026-09-10/24-implementation-progress-round6.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round6 implements dedicated scoped incoming Return browse/read and bounded versioned metadata editing, '
    'raw hidden/numeric/identity preservation, TAG_LBR_CODE migration and guarded saved UI. Read document24 '
    'for actual verification status; legacy numerical writes are not accepted by these metadata tests.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'].insert(0,
    'Retain the verified round6 saved metadata contracts and checkpoint25. Follow the round7 incoming calculation '
    'contract and35 independent source-derived vectors (6 unresolved probes); implement original-source F1 '
    'identity/copy/calculation, source RTN_* header accounting, new incoming '
    'tag admission and ownership/consumption/reversal, outgoing exchange leg, settlement and reports. '
    'Do not enable the legacy destructive edit service as a full saved-document PUT or treat restricted metadata edits as complete parity.')

# Round7 adds numerical/source-reading prerequisites; no complete writer or acceptance.
IMPLEMENTATION_PROGRESS['X13'].update(asOf='2026-09-11 round 7', progressDocument='parity-plan-2026-09-10/26-implementation-progress-round7.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round7 implements the Return-specific incoming event kernel and scoped original-sale source readers; '
    'original executable IL resolves the grid property as ColWidth. Read document26 for current verification. '
    'These prerequisites do not enable numeric saved writes or complete original-source application.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'].insert(0,
    'Follow round7 independent calculation review plus35 original and8 width vectors. Resolve/version configured '
    'settings and effective widths, integrate server-owned event replay and complete resolved master/F1 copy '
    'events. Use exact source read DTOs with OLD_SRNO child ownership; retain ambiguous histories visibly. '
    'Follow round7/x13-next-configuration-contract.md:40 stable source columns, actual company/family COL_MAST identity, exact default/clamp/final-override order and12 test groups. Correct BOOK_NAME omission in generic column CRUD before using it to manage configuration. '
    'Complete source apply/new admission/consumption/reversal and full header/exchange/accounting before numeric UI writes.')

# Round8 closes specific configuration/column-identity prerequisites, not a whole card.
IMPLEMENTATION_PROGRESS['X13'].update(asOf='2026-09-11 round 8', progressDocument='parity-plan-2026-09-10/28-implementation-progress-round8.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round8 adds authoritative incoming configuration observation with exact source precedence, stable field IDs, '
    'effective width predicates, raw diagnostics and versioned settings/book/year/column snapshots. '
    'Column management now includes the form family in its identity. Read document28 for final verification and boundaries.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'][:2] = [
    'Reuse the implemented round7 reducer/source readers and round8 configuration resolver; do not rebuild them or '
    'reuse generic rounding defaults. Follow the frozen35 original plus8 width vectors and independent reviews. '
    'Implement server-owned event replay inside the complete Serializable writer transaction, stable-ID mapping, '
    'resolved master/F1 copy events, stale-configuration recovery and the full absence/phantom revision contract. '
    'Configuration/source read tokens do not authorize numeric writes or stock admission.',
    'Retain round6 metadata and round7/round8 immutable checkpoints. Complete original-source copy/application with '
    'OLD_SRNO child ownership, new incoming admission/consumption/reversal, RTN_* header accounting, outgoing exchange, '
    'tax/settlement/ledger/report writes. Replace or separately correct the legacy import query/book mismatch and '
    'incomplete create payload. Do not enable destructive full-document PUT as a shortcut.'
]
IMPLEMENTATION_PROGRESS['X05'].update(asOf='2026-09-11 round 8', progressDocument='parity-plan-2026-09-10/28-implementation-progress-round8.md')
IMPLEMENTATION_PROGRESS['X05']['implementedOrInvestigated'] += (
    ' Round8 adds company/family/original-name column mutation identity, stale-version rejection and explicit '
    'editor reload/scope guards. This master correction does not close cross-family document concurrency.')
for _id in ['X08', 'X10']:
    IMPLEMENTATION_PROGRESS[_id] = {
        'asOf': '2026-09-11 round 8', 'status': 'partial-implementation',
        'progressDocument': 'parity-plan-2026-09-10/28-implementation-progress-round8.md', 'acceptanceChanged': False,
        'implementedOrInvestigated':
            'Authoritative incoming Return settings/width observation and company/family/original-name column '
            'management are implemented as bounded prerequisites. The dedicated Columns editor preserves identities, '
            'raw untouched values and versions. Read document28 for the exact tests and limits.',
        'remainingBeforeAcceptance': [
            'Connect settings to complete server-owned Return replay and final atomic business effects; configuration '
            'read success alone does not prove operational behavior.',
            'Complete every original card requirement across all master/settings families, field variants, source '
            'provisioning and import/clone/recovery behavior. No other configuration/master identity is presumed fixed.',
            'Resolve software edition, unsupported imported values and history-sensitive configuration revisions '
            'across every writer; complete desktop and business acceptance.'
        ]
    }

IMPLEMENTATION_PROGRESS['X13'].update(asOf='2026-09-11 round 9', progressDocument='parity-plan-2026-09-10/30-implementation-progress-round9.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round9 integrates a trusted saved-row projection and twelve-field server journal preview with separate raw, '
    'visible and comparison-cache values, a composite same-snapshot observation and explicit operator preview '
    'controls, read-only empty-header inspection and explicit conflict/reload behavior. The final bounded slice passed '
    '235 API files/2115 tests,264 core tests,227 web tests,15 real browser journeys and complete compiler/build/lint '
    'checks, with independent source reviews and retained corrections. Read document30 and checkpoint31. '
    'The preview performs no numeric, stock or financial persistence; its complete boundaries are in document30.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'].insert(0,
    'Retain checkpoint31 and the verified round9 row-only preview, including read-only empty saved headers. Build the '
    'next aggregate/header preview as a separately versioned contract. Follow evidence/implementation-2026-09-11-round9/'
    'x13-next-aggregate-requirements.md and the sibling x13-next-aggregate-independent-review.md and '
    'x13-runtime-probe-next-steps.md '
    'for the next source contract: fourteen running formatted totals; source-phase bill/header state and callbacks after '
    'every actual row event; authoritative tax/account/ledger observations; separately named runtime probes. Preserve the frozen projection '
    'and existing metadata behavior, exact event order, scalar text and current scope/rights. Then implement the '
    'remaining source/code-selection, gross/component, keyboard, header, outgoing, settlement and reversal events '
    'with complete atomic persistence; a twelve-field transient result cannot close full Return parity.')

IMPLEMENTATION_PROGRESS['X13'].update(asOf='2026-09-11 round 10', progressDocument='parity-plan-2026-09-10/32-implementation-progress-round10.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round10 adds the pure primary incoming aggregate and stateful bill callback, composed after every '
    'calculated row event, with running formatting, manual-tax caches, payment/received clearing order, '
    'explicit unavailable closing, immutable state and atomic transient rollback. A separate pure resolver implements '
    'qualified CO_SET tax precision, nullable Int32 conversion and ordered company-open fallback/override. The unchanged v1 API/UI '
    'does not yet call this module. Final415 core and227 web tests, strict new-test compilation, production build '
    'and workspace lint passed; immutable checkpoint33 retains actual invocation evidence and unchanged red gates. '
    'Read document32 for verification and remaining integration boundaries.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'][0] = (
    'Retain checkpoint31 and the verified v1 row-only preview. Complete the separately versioned aggregate '
    'API/UI using the pure round10 module and evidence/implementation-2026-09-11-round10/'
    'x13-aggregate-trusted-observation-contract.md. Add detached saved-header projection, exact per-field '
    'Fnv/direct-Val handling, qualified TAX_ROF company-open precedence, full-grid saved/opened/event phases '
    'and same-transaction composite observations. Clients cannot supply policy, cache or phase authority. '
    'Session MsDataType is not selected-book ItmDataType; provision a trusted versioned ledger mode before '
    'resolving balance, otherwise closing stays explicitly unavailable. Use cross-book SUM(CR_AMT-DR_AMT), '
    'source second-precision strict-before cutoff and exact scope/raw identities; distinguish absent groups '
    'from all-NULL groups. Test authenticated API/staleness/no-write snapshots and real browser phases. '
    'Then complete all source/code selection, gross/component/keyboard, header/outgoing, settlement and '
    'reversal events with full atomic persistence and independent desktop/business acceptance.')

IMPLEMENTATION_PROGRESS['X13'].update(asOf='2026-09-11 round 11', progressDocument='parity-plan-2026-09-10/34-implementation-progress-round11.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round11 integrates a separately versioned saved incoming bill preview alongside the retained v1 row-only '
    'preview. It adds exact saved-header projection, full-grid running totals, distinct loaded/opened/event '
    'phases, per-event aggregate and bill callbacks, qualified company-open tax policy and physical tax/account '
    'label observations in one RepeatableRead snapshot. Strict server-owned journals, stale-version checks and '
    'atomic transient failure recovery are exposed through a separate preview UI with retained drafts and '
    'exclusive metadata/preview ownership. Closing remains explicitly unavailable because session ledger mode '
    'is unresolved; numeric, stock, settlement and financial persistence remain disabled. Read document34 and '
    'checkpoint35 for current verification; documents32/33 retain the historical pure-prerequisite proof. '
    'No full desktop, business or production acceptance is established by this bounded integration.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'][0] = (
    'Preserve the separately versioned round11 bill preview and prior v1 row-only/metadata contracts. Follow '
    'evidence/implementation-2026-09-11-round11/x13-round11-handoff-and-remaining-acceptance.md and the frozen '
    'round10 trusted-observation contract/source addendum. Establish trusted versioned session MsDataType '
    'authority before resolving ledger opening or closing; selected-book ItmDataType is not that authority. '
    'Observe exact cross-book SUM(CR_AMT-DR_AMT) under saved company/location/year/customer and source '
    'second-precision strict-before cutoff, distinguishing absent groups from all-NULL groups and accounting '
    'for the original helper GoldWt/SilverWt conversion prerequisites. Keep unresolved balances unavailable. '
    'Then complete full source/code application and admission, gross/component/keyboard/header events, '
    'outgoing/UAE/other variants, tender/refund allocation, numeric stock/financial writers and exact reversal '
    'with complete atomic effects, reports and independent desktop/operator/business/production acceptance. '
    'No preview token or successful arithmetic result authorizes a numeric save.')


IMPLEMENTATION_PROGRESS['X13'].update(asOf='2026-09-11 round 12', progressDocument='parity-plan-2026-09-10/36-implementation-progress-round12.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round12 implements a pure source-qualified session ledger-mode resolver with distinct trusted '
    'company-open and later command observations, literal company01 catalog branches and immutable '
    'replayable history. It also adds an internal RepeatableRead account-balance reader covering all '
    'three source amount/gold/silver sums across books, strict opening and inclusive helper-closing '
    'cutoffs, grouped NULL/absence distinctions and exact physical row observations. A pure saved '
    'Return clock projector also preserves raw date/time and document provenance, validates canonical '
    'PostgreSQL JSONB representations, and combines the voucher date with the timestamp clock at '
    'whole-second precision by discarding fractions without rounding. Independent literal fixtures '
    'precede these implementations. These are prerequisite modules: no authenticated session mode '
    'authority, new operator mode controls, known Return closing or financial writer is introduced. '
    'Read document36 and checkpoint37 for actual verification and limits.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'][0] = (
    'Reuse the round12 pure mode resolver, savedSaleReturnClock projector and internal '
    'desktopAccountBalance reader; their input provenance does not authenticate source observations. '
    'Follow evidence/'
    'implementation-2026-09-11-round12/x13-round12-handoff-and-remaining-acceptance.md. Establish '
    'server-owned company-open classification, effective command edition, scoped context identity, '
    'complete catalog revision, accepted mode history and separate context/mode generations. Persist '
    'bootstrap/reset and accepted command/CAS transitions atomically with session context; preserve '
    'refresh, revocation, failed-open and lost-response recovery semantics. The source caller must '
    'provide the saved date-only VCH_DATE and JSONB VCH_TIME from the same authoritative header '
    'observation, bind raw values, document identity/version and clock projection version, and refuse '
    'missing/NULL/unsupported clocks without fallback, timezone conversion or inferred authority. '
    'Resolve fresh mode, exact ledger observation and existing preview dependencies in one '
    'RepeatableRead transaction, with stale/missing/ambiguous facts refused before replay and no '
    'client mode or selected-book substitution. The fixed-decimal PostgreSQL profile does not '
    'establish original Double/locale/collation equivalence, and a dependency hash cannot establish '
    'durable absence-cycle authority. Keep closing unavailable until that adapter and its independent '
    'API/browser/concurrency/no-write cases pass. Then complete full source/code admission, all '
    'incoming/outgoing/variant events, atomic numeric stock/financial persistence, settlement/refund '
    'and reversal, reports, desktop comparison, business acceptance and production certification.')


# Round13 extends the current implementation record without closing any acceptance.
IMPLEMENTATION_PROGRESS['X13'].update(asOf='2026-09-12 round 13', progressDocument='parity-plan-2026-09-10/38-implementation-progress-round13.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round13 implements atomic login/refresh/selection, epoch-bearing access and browser '
    'context/recovery controls, with14 real browser context checks and17 business journeys. '
    'An exact labour-master reader, source-derived c13/c29 copy and pure atomic copy-row-fold-bill '
    'composition now have separately versioned server/browser preview adoption: three read-only '
    'routes, complete prefix/master re-observation, an exclusive third preview panel,57 new API '
    'cases and75 new web cases. Five further real browser lifecycle cases pass with four declared '
    'actual-response transport faults. The complete API suite passes3050 tests; web522 plus6 native '
    'Node tests and core888 pass. Known ledger '
    'mode/closing and numeric Return persistence remain disabled.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'][0] = (
    'Read document38 for current source and checks. Six Sales/Tour create/edit/delete routes now '
    'retain a transaction-owned session lock. Complete adoption across every remaining financial '
    'writer and resolve fresh role/config/reset ownership before composing trusted '
    'vendor/mode authority, canonical saved clock and complete ledger/config/document observations '
    'in one snapshot. Keep closing unavailable until independent API/browser/concurrency/no-write '
    'cases pass. The LBR_MAST reader, c13/c29 copy and pure atomic copy-row-aggregate-bill prefix '
    'now pass independent24 copy and23 full-state composition literals and actual server/browser '
    'adoption. Preserve their separately versioned three-route contract, complete same-snapshot '
    'master/document/config dependencies, exact previous-prefix rollback and all17 baseline plus '
    '14 context and5 labour lifecycle browser checks. Read the frozen next-write contract in '
    'evidence/implementation-2026-09-12-round13/return-next-write-contract together with the mandatory '
    'return-next-write-contract-review stock erratum and seven additive cases. First implement the '
    'source-cited pure save mapping and representability, then complete independent before/after '
    'business-effect goldens for the finite single saved primary untagged incoming c27-only profile. '
    'Revalidate admission after replay: zero, negative or row-omitting results remain unsupported. '
    'MAIN_STOCK.SR_NO is2 and ISR_NO is the incoming saved ordinal. Do not reuse the generic '
    'salesReturn writer or infer ledger mode from the selected book/client. Only enable a separate '
    'versioned write path after transaction-owned session/document/master/config/ledger checks, '
    'exact effects, retry semantics and DB/HTTP/browser failures are independently verified. Complete '
    'all source/child/tag admission, incoming/outgoing variants, numeric stock/financial persistence, '
    'settlement/reversal, reports and desktop/business/production acceptance. A pending selection '
    'request or selected book never supplies mode authority.')
for _context_card in ['X09', 'X29']:
    IMPLEMENTATION_PROGRESS[_context_card] = {
        'asOf': '2026-09-12 round 13',
        'progressDocument': 'parity-plan-2026-09-10/38-implementation-progress-round13.md',
        'implementedOrInvestigated': 'Atomic session lifecycle and browser context/recovery controls '
            'retain drafts on uncertain switching, reject late responses and prevent obsolete '
            'route/component callbacks from navigating.14 real browser lifecycle checks pass with '
            'five declared real-response transport faults;17 business journeys pass without interception. '
            'Six order mutations have transaction-bound session admission. Other writers, full offline '
            'continuity and role/job/audit acceptance remain open.',
        'remainingBeforeAcceptance': [
            'Maintain current browser and broad regressions, with transport-fault and mocked compatibility results separate.',
            'Implement session authority inside every participating financial transaction and inventory '
            'all other writers. Resolve role/config concurrency, selected-credential reset ownership '
            'and duplicate credential identity admission.',
            'Complete original card obligations, offline/service topology, multi-form continuity, '
            'physical devices/providers and independent desktop/business/production acceptance.']}


for _order_card in ['X05', 'X14']:
    IMPLEMENTATION_PROGRESS[_order_card].update(
        asOf='2026-09-12 round 13',
        progressDocument='parity-plan-2026-09-10/38-implementation-progress-round13.md')
    IMPLEMENTATION_PROGRESS[_order_card]['implementedOrInvestigated'] += (
        ' Round13 retains one session SHARE lock through Sales/Tour Order create, edit and delete, '
        'fresh transaction-local scope/principal/form checks and the unchanged financial write set. '
        'Modern Tour edit/delete now require canonical saved versions; legacy internal wrappers retain '
        'their documented behavior. Focused source-preservation, real PostgreSQL and financial HTTP '
        'checks pass. Tour exact mapped scalar projection and saved-form restoration now pass real '
        'browser unchanged/advance-only roundtrips with large decimals, NULL/zero and exact SQL '
        'parent/child preservation. Complete other writer, desktop and business acceptance remains open.')
    IMPLEMENTATION_PROGRESS[_order_card]['remainingBeforeAcceptance'].insert(0,
        'Read document38. Preserve the verified Tour exact scalar/NULL/zero GET-editor-payload '
        'roundtrip, original DTO/version matching and parent/child identity restoration. The real '
        'browser unchanged and advance-only paths pass with exact SQL snapshots; retain unsupported '
        'changed-decimal refusal and the unchanged Sales/new-Tour serializer behavior. Continue every '
        'remaining calculation profile, order tender/refund/fulfillment/adjustment/variant and '
        'transaction-adoption obligation; this bounded pass does not close the card.')


# Round14 records diagnostic save prerequisites; earlier round records remain intact.
IMPLEMENTATION_PROGRESS['X13'].update(
    asOf='2026-09-12 round 14',
    progressDocument='parity-plan-2026-09-10/40-implementation-progress-round14.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round14 adds the complete incoming Save field projection, exact binary64 qualification '
    'for three Float header targets, source-shaped N BAR header/parent matching and a separate '
    'internal Serializable Return Update coordinator. The pure mappings remain canCommit:false; '
    'no numeric endpoint, writer, known closing or existing preview capability is enabled. '
    'Document40 and checkpoint41 record actual verification, source qualifications and retained '
    'failures, including the Round13 final-source API dependency-coverage erratum. Earlier '
    'round counts above remain historical evidence with their stated limits.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'][0] = (
    'Follow document40 and checkpoint41, the frozen Round13 return-next-write-contract and '
    'mandatory review/stock erratum, and the Round14 return-save-effects-analysis. Preserve all '
    'existing previews and session/browser/order contracts. Freeze a complete independent Option A '
    'fixture with raw header/rows,63 visible cells, eight caches, width/calculation policy, full '
    'loaded/opened/per-prefix bill phases, qualified16-field N BAR context, all master/config/guard '
    'facts and every before/after effect. Resolve symbolic bindings before claiming executable '
    'goldens. Build the pure effect plan:221 source-owned entries per phase across seven conditional '
    'financial rows plus full saved line/header and retained/absent companions; preserve unowned '
    'NULL/text/identities. MAIN_STOCK.SR_NO is2 and ISR_NO comes from incoming SR_NO, with row '
    'and book data types kept distinct. Add separately versioned fresh Update admission, exact '
    'physical/dependency versions, Save guards, cash/edition/audit authority and cross-year '
    'temporary/key collision checks. Replay only the accepted ordered c27 history and refuse '
    'unsupported zero/omission/received/BAR-membership transitions; no-op means the whole plan '
    'is unchanged. Implement one exact Serializable commit with deterministic locks, typed '
    'row-qualified DML, affected-count/conservation checks and final context/clock, without '
    'generic salesReturn writer reuse or automatic retry. Verify complete rollback, stale/SSI '
    'conflicts and ambiguous acknowledgment recovery before endpoint/UI adoption; then verify '
    'reopen, reports and independent desktop outcomes. Continue all other writer adoption, '
    'trusted mode/ledger/closing, source/tag/child and outgoing/variant workflows, settlement '
    'and full business/production acceptance. A hash, selected book or caller-qualified context '
    'does not establish authority; numeric/source/closing capability remains disabled.')


# Round15 is an in-progress status snapshot; Round14 and earlier records remain intact.
IMPLEMENTATION_PROGRESS['X13'].update(
    asOf='2026-09-12 round 15 paused status review',
    progressDocument='parity-plan-2026-09-10/42-implementation-progress-round15.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round15 adds pure saved c27 replay, strict effect storage context, complete221-field '
    'seven-row financial planning, ordered Save guards and six common composition cases. '
    'The integrated replay has45 tests after a separately retained owned-NULL correction; '
    'its original44-case stage is historical. Core26files/1613tests and strict compilation '
    'of five new core test files passed. The remaining16 checks have not run; implementation '
    'is paused for status review and checkpoint43 is not sealed. Latest sealed checkpoint41 '
    'applies only to the earlier Round14 inputs. No API route, UI Save, numeric writer, known '
    'closing or full acceptance is enabled; every diagnostic remains canCommit:false.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'][0] = (
    'Read document42 for the full nine-step continuation and all34 remaining-gap areas; '
    'preserve sealed40/41, the frozen Round13 next-write contract/stock erratum and complete '
    'Round14 effect inventory. Implementation is paused. The common J01 literal and pure '
    'composition do not establish trusted hydration or authority. Qualify full raw/physical '
    'document/master/config/guard observations, actual16-field N BAR context, all221 financial '
    'entries per phase and every retained/absent BAR/temp/remark/DM/OS/child/audit/external '
    'reference. TEMP_BOOK_DATA identity excludes year; ledger keys and hidden numbers need '
    'cross-year collision checks. Preserve source stockSR2/ISRincomingSR and distinct row/book '
    'DATA_TYPE. Resolve period/fresh ordinary Update, defaulter, employee/counter/bank/cash '
    'and special-account/fine guards plus edition-E USER_DATA current-user/date/text authority. '
    'LedrCash spans years/dates/modes/books with positive customer/current-voucher cash sums; '
    'new cash0 or a dated/year-scoped balance reader is not a substitute. Keep ISO/text0 '
    'preservation adaptation distinct from unproved Windows/STR/storage equivalence. Bind '
    'versions before projection, replay every accepted c27 prefix and revalidate complete '
    'poststate/effect membership; zero, row omission, received side and BAR disappearance '
    'remain refusals. Whole-plan no-op extends beyond line/header and seven financial rows. '
    'Then implement one exact Serializable commit with deterministic locks, typed qualified '
    'DML, affected counts/conservation/stored postconditions and final context/clock, without '
    'generic writer reuse or auto-retry. Prove rollback, stale/SSI/phantom conflicts and lost '
    'acknowledgment recovery before endpoint/UI adoption; a selection receipt is not a '
    'financial receipt. Reopen/report/desktop/business/production verification and all '
    'remaining events, source/tag/child/outgoing/edition, settlement and closing requirements '
    'remain mandatory. Preserve every83-package/34-card obligation and all198 open acceptances.')

for _card in TASKS:
    if _card['id'] in IMPLEMENTATION_PROGRESS:
        _card['implementationProgress'] = IMPLEMENTATION_PROGRESS[_card['id']]
    if _card['id'] == 'X13':
        _card['currentFinding'] = (
            'Saved metadata, separate row/bill/labour previews, session/browser controls and '
            'six guarded order mutations remain implemented. Round14 Save/Float/N BAR and '
            'Serializable prerequisites are preserved. Round15 adds pure c27 replay, effect '
            'storage context, seven-row financial planning, Save guards and common composition; '
            'core26/1613 and strict five-test-file compilation passed. Implementation is paused; '
            'the other16 recipe checks have not run and checkpoint43 is not sealed. Read42 for '
            'complete trusted observation/effect/guard/admission/atomic-write prerequisites and '
            'all remaining gaps. Latest sealed41 remains prior-input evidence. Numeric saves, '
            'known closing and full desktop/business/production acceptance remain disabled/open.')



def build():
    ids = {t['id'] for t in TASKS}
    assert len(ids) == len(TASKS) == 34
    work = json.loads((OUT / '07-work-items.json').read_text())
    work_ids = {x['id'] for x in work['workItems']}
    covered = {p for t in TASKS for p in t['parents']}
    assert covered == work_ids, (work_ids - covered, covered - work_ids)
    for t in TASKS:
        assert set(t['startAfter']) <= ids
        for location in t['existingFiles']:
            assert (OUT.parent / location).exists(), (t['id'], location)
    payload = {'kind': 'datacare.parity-execution-backlog/1.0', 'reviewDate': '2026-09-12',
               'scope': 'Full reachable desktop product; supplements all 83 original packages, never replaces their acceptance.',
               'statusMeaning': 'Open means required acceptance is incomplete; substantial existing code may already satisfy parts of the card.',
               'dependencyMeaning': 'Start-after dependencies govern substantive implementation. Source reading and fixture/contract preparation may proceed earlier. Closure also requires parent cross-module acceptance; these edges do not waive it.',
               'wholeProductImplementationPercentage': None,
               'percentageReason': 'Semantic requirement/transition universe and current evidence are not yet complete.',
               'tasks': TASKS,
               'currentStatusReview': '42-implementation-progress-round15.md',
               'latestSealedCheckpoint': '41-implementation-checkpoint-round14.json',
               'latestImplementationProgress': 'parity-plan-2026-09-10/42-implementation-progress-round15.md'}
    (OUT / '13-execution-backlog.json').write_text(json.dumps(payload, indent=2) + '\n')
    intro = (OUT / 'execution-addendum-intro.md').read_text()
    lines = [intro.rstrip(), '\n## Detailed execution cards\n']
    for t in TASKS:
        lines += [f"### {t['id']} — {t['title']}\n",
                  f"**Status:** open. **Parents:** {', '.join(t['parents'])}. **Start after:** {', '.join(t['startAfter']) or 'none'}.\n",
                  f"**Current finding:** {t['currentFinding']}\n", '**Read/reuse these existing paths** (relative to `imodule-extracted/`):\n']
        lines.extend(f'- `{p}`' for p in t['existingFiles'])
        lines += ['\n**Implementation sequence:**\n']
        lines.extend(f'{i}. {s}' for i, s in enumerate(t['implementationSteps'], 1))
        lines += ['\n**Required verification, in addition to the universal matrix:**\n']
        lines.extend(f'- {s}' for s in t['verificationCases'])
        lines += [f"\n**Close only when:** {t['acceptance']}\n",
                  f"**Evidence:** retain an `{t['id']}` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.\n"]
    (OUT / '12-execution-addendum.md').write_text('\n'.join(lines) + '\n')
    for item in work['workItems']:
        relevant = [t for t in TASKS if item['id'] in t['parents']]
        item['status'] = 'open'
        item['currentReview'] = {
            'date': '2026-09-12', 'acceptance': 'not-established',
            'implementation': 'existing-work-requires-leaf-verification',
            'executionTasks': [t['id'] for t in relevant],
            'review': '11-current-completion-review.md',
            'currentStatusReview': '42-implementation-progress-round15.md',
            'latestSealedCheckpoint': '41-implementation-checkpoint-round14.json',
            'instruction': 'Reuse existing implementation. Follow linked execution cards plus this package contract; do not equate open acceptance with absent code.'}
        item['nextActions'] = [f"{t['id']}: {t['title']}" for t in relevant]
    work['currentStatusReview'] = '42-implementation-progress-round15.md'
    work['latestSealedCheckpoint'] = '41-implementation-checkpoint-round14.json'
    work['lastReviewed'] = '2026-09-12'
    work['note'] = 'Original83 packages and all34 open cards retained. Document42 records the paused Round15 in-progress status, pure replay/storage/effect/guard composition, actual core26/1613 and strict five-test-file compilation, retained failures and the full remaining-gap/write sequence. The other16 recipe checks have not run; checkpoint43 is not sealed. Latest sealed41 and document40 remain unchanged prior-input evidence. Numeric saves, known closing and full desktop/business/production acceptance remain open; no functional percentage is inferred.'
    work['completionContract']['currentExecutionBacklog'] = '13-execution-backlog.json'
    work['completionContract']['currentReview'] = '11-current-completion-review.md'
    (OUT / '07-work-items.json').write_text(json.dumps(work, indent=2) + '\n')
    print(f'Generated {len(TASKS)} execution cards covering all {len(covered)} original packages.')


if __name__ == '__main__':
    build()
