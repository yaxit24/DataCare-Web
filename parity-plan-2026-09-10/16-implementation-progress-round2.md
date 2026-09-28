# Implementation continuation — 11 September 2026, round 2

This is an implementation checkpoint for the next slices of [the mandatory execution plan](12-execution-addendum.md). It follows [round 1](14-implementation-progress-2026-09-11.md); the original [checkpoint 15](15-implementation-checkpoint.json) stays frozen. No complete execution card, package, menu, or production release is accepted by this continuation.

## Changes in the application

### X11: Design Book calculation events

`web/packages/core/src/designCalc.ts` now implements ordered parent/component calculation events from `MS_DESIGN_BOOK`, including customer/karigar weights, conversion, pieces and weight rate bases, labour, component aggregation, fine/metal calculations, and the measured cost/MRP branches. Both the browser and API use this kernel. The API starts from its own scoped persisted snapshot and reads master defaults itself; a submitted client baseline cannot replace the saved calculation state.

The form obtains company calculation policy and selected component defaults through Design Book's own read permissions. Numeric commits replay in their source order. Hydrating an imported record does not recalculate it; an explicit recalculation action applies the parent pass. The component per-piece rounding condition was checked against executable IL: the source's rounded-rate/nonzero branch differs at 0.50 versus 0.51. This remains covered by source vectors.

The source contains lossy selection/save quirks, including a component piece-weight reset and omitted parent cost writes. This continuation preserves existing data on an unchanged save. These differences require desktop/business acceptance; they are not silently counted as exact parity. Repeating a previous row through `COL_RPT`, every keyboard/focus branch, downstream order/manufacturing design transfer, and full desktop/runtime comparison remain open.

Invalid numeric refresh now retains the draft and displays field validation. The wide parent/component grids scroll inside their panels; the page no longer shifts its heading and book controls beneath the sidebar when an operator focuses a right-hand cell.

### X14: Order labour edit order and voucher clock

`web/packages/core/src/orderLabour.ts` supplies the measured `TR_SALE_ORD` labour transitions at the requested calculation branch: P uses pieces, G uses gross weight, K uses net plus ghat divided by 1,000, and the default follows the configured net/ghat rule. It preserves whole-rupee half-even amount rounding, configured derived-rate precision, explicit percentage/rate/manual-amount commits, and the unusual source K inverse.

The Tour form records an ordered edit journal, and the API replays it against the locked persisted row. Editing and saving require the selected scope’s calculation policy; a failed lookup keeps the editor disabled and offers Retry. A final browser failure revealed that the earlier editor could accept a rate before settings arrived and lose its journal. The repaired form serializes cell updates against its latest queued row and refuses premature submission. See [the reproduced failure and final network regression](evidence/implementation-2026-09-11-round2/tour-policy-readiness-regression.md). Editing a rate before changing a weight is therefore different from editing it afterward, as in the source. Unchanged imported manual amounts and totals remain intact. The operator can view and change the voucher's wall clock; invalid clock input fails before replacement.

This does not close the later MRP/tax-inclusive/final-percentage passes or visibility-dependent grid branches. Mixed tender/metal/allocation protection remains until those row sets have full editing and reversal support. Delivery, conversions, settlement, cancellation/refund, and cross-module acceptance remain required by X14.

The shared edit/cancel allocation guard now compares the allocation's source book, branch and year, so an unrelated order with the same voucher number no longer blocks this order. Missing legacy source dimensions remain unknown and conservatively block a possible match; any explicitly different dimension excludes it. Regression fixtures cover exact, different and incomplete source identities.

### X05/X25: Complete order report definitions and subreports

The old order JSON extraction had selected a nested `ReportDefinition` instead of the main report. A bounded extractor now recovers the main definitions of `OrderVch`, `OrderBill`, and `TourOrdVch` from their original XML, retaining the independently linked `OrdRec` received-metal subreport.

The binder selects actual scoped order parents, components, and received-metal rows, with full tenant/company/location/year/book/voucher identity and one repeatable-read snapshot. Parent totals are not multiplied by their component count. The renderer applies explicit formula, suppression, copy, grouping, page, and subreport contracts. The form-specific print route selects the advance-only or parent-containing template from the saved document and retains the form's own print permissions.

`CO_SET_NEW.ORD_IMG_PRINT=Y` selects separate image templates only for parent-containing orders. Those templates remain explicitly unsupported until their image contract is implemented. The newly supported three report names were outside the previous inferred set of 102: there are now 26 registered contracts, while all 79 previously contained inferred names remain contained. Neither count is a report-parity percentage. Physical/Crystal comparison and every other report obligation remain open.

Each parent item-name formula now follows its own template: ordinary OrderBill prints the design reference even when a tag exists; TourOrdVch follows its tag/design conditional. A final source cross-check exposed and corrected this distinction, with tag-present unit/database fixtures and a refreshed ordinary-order PDF.

### X05/X25: Ledger time preservation

`20260911020000_ledger_entry_timestamp` changes `AC_DATA.ENTRY_TIME` from a date to a timestamp. Shared posting copies the document's `VCH_TIME` unless the leg explicitly supplies a time. The order report computes opening `sum(CR-DR)` before the voucher timestamp and closing balance at or before it, following `DC_Main.MsAcBal`.

The migration retains already-truncated historical values at midnight. It cannot reconstruct time that was discarded earlier. Historical migration must reload or reconcile those values from the original timestamp-bearing source before intraday historical balance acceptance. This migration was applied only to the disposable test database; the running business application's database remains outside this test work.

### X15: Saved E Credit Note browse/read workflow

The E CrntNote page can now browse and search the selected active E CRNT book/year, reopen a saved voucher, inspect persisted header/item/component fields, and display its registration state. Its own form rights govern the readers and provider-status lookup. It uses the original `OLD_SRNO` child relationship where present, preserves visible and original serials, and refuses ambiguous/orphaned children. Loaded results carry their company/branch/year/book identity; a scope change immediately hides a mismatched document in the new render, before effect cleanup. A failed lookup clears the previous document before another IRN action can use it. The existing saved-document IRN adapter remains available.

**Create/edit/delete and complete E Credit Note posting are still open.** The new browser fixture represents an imported document and does not count as the required create-entirely-through-UI case. Source review found material differences from ordinary sales returns and Tour Order calculations. E Credit Note calls dedicated ledger, Rojmel, stock and GST builders; its diamond helper's insertion branch is E Invoice-only. The source also contains TCS/TDS direction restrictions and a negative-round-off ledger branch that can produce an imbalance. Follow the new source contract; do not substitute a sales-return writer, add unexplained balancing rows, or advertise provider acceptance from fake-GSP engineering checks.

The shared invoice/credit-note IRN adapter now preserves an explicit zero detail net amount and zero tax rate. It uses the header fallback only for a missing/null value. Previously, a 100 + 0 document with header net 100 could submit two assessable amounts of 100. Eight added CRN/INV vectors cover this distinction and retain rejection of an all-zero document. These are captured payload checks without live provider calls; quantity fallback and full submission lifecycle remain separate open requirements.

### X02: Descriptor-aware measurement, with old gates preserved

An additive TypeScript AST scanner follows rendered descriptor maps through supported imports and configuration wrappers. Each candidate retains its source file and line, identity/editability classification, and conditional visibility. It rejects unused imports and unsupported transformations instead of counting every matching word. Twelve fixture tests include unused descriptors, removed rendering, dynamic consumers, and identity-changing transformations.

It found 48 Design Book candidates and 68 Tour Order candidates. Across 123 discovered pages, 19 have candidates and 589 distinct candidate definitions were recorded, including 132 conditional definitions. These overlap existing counts and **must not be added to them or expressed as functional parity**. All old measurement values and gate limits remain unchanged: 101 unreachable findings and four wholesale dead-cell findings still need the remaining route/writer/reader tracing. See [the measurement review](evidence/implementation-2026-09-11-round2/depth-scanner-review.md).

## Verification and evidence

New logs and artifacts belong under `evidence/implementation-2026-09-11-round2/`. The [round-2 checkpoint](17-implementation-checkpoint-round2.json) pins the tested product files, evidence, and prior-checkpoint hash. Documentation validation checks the latest source snapshot while recording drift from historical snapshots rather than rewriting them.

Focused checks include 36 Design Book calculation vectors, 23 order-labour vectors, 21 Design Book database/route checks, 41 order database checks, 77 report checks, and a 13-test report/timestamp follow-up. Those focused runs overlap the full suite and are not added to its total. The credit-note reader and ledger-time database tests also passed. The route-universe check correctly detected five new endpoints; its exact expected universe is now 522, with their own form-right mappings tested.

The final integrated API run passed **210 files / 1,630 tests with no skips**, including the allocation source-scope, ordinary-order item-name and zero IRN amount corrections. Core tests passed **5 files / 76 tests**, and the latest web suite passed **18 files / 83 tests**. Production build, workspace lint/application types and strict API-test types passed. The final real browser run also passed after repairing the configuration-loading race, including actual offline failure, delayed retry, the exact rate-before-ghat journal and its 117 amount, and credit-note scope switching. It uses real authentication and API/database requests with no mocked/intercepted responses. The saved [browser results](evidence/implementation-2026-09-11-round2/browser/result.json) enumerate the checks. All runs, including earlier failures and their fixes, remain in the evidence directory. The configured workspace lint command does not apply ESLint rules to API files; API compile/test checks are recorded separately. An exploratory selected IRN unit run used the unit-only skip flag, but all of those tests also passed in the authoritative full API run with no skip flag or exclusion.

Use the existing isolated commands from `web/`; no skip flags or test exclusions:

```bash
API_ORIGIN=http://127.0.0.1:4410 pnpm build
pnpm test:parity:api
PARITY_ARTIFACT_DIR=test-results/parity-real-stack-round2-tested pnpm test:parity:browser
pnpm --filter @datacare/core test
pnpm --filter @datacare/web test
pnpm lint
pnpm typecheck:tests
```

The real browser suite covers the existing Design Book lifecycle, the new Design Book calculation journey, Tour Order edits/calculation/printing, and saved E Credit Note browse/read. The last journey is deliberately distinguished from credit-note creation or live provider verification.

## Required next implementation, in order

1. Complete X11's remaining grid-repeat/keyboard/focus and downstream design transfer contracts. Compare changed and unchanged saves against an independently observed desktop execution, including the documented loss-prevention differences and cost/MRP configuration variants.
2. Complete X14's later tax/MRP/visibility calculation passes, then each mixed tender/old-metal/allocation write set and reversal. Add full partial-delivery, conversion, cancellation and residual-quantity browser journeys before removing any edit protection.
3. For X15, implement its own explicit versioned create/edit/delete service, using the full source header/parent/child mappings and dedicated side effects. Reconcile schema before writing: the current `SL_DATA` model lacks the desktop's `LDR_CODE` header ledger override (`TR_SL_EBILL` read at 6990, save at 7526); confirm its source type and migrate/import it instead of silently using the item-group default. First resolve the source's TCS/TDS direction and negative-round-off anomalies through independent desktop observations and a documented business rule. Preserve balance invariants and make any accepted correction explicit. Add pending/submitted/retry/cancel provider state and a mutation barrier before enabling edit/delete alongside external submission.
4. Complete `OrdVchImg` and `TourOrdImg` with scoped saved image identities, following [the image implementation contract](../web/docs/parity-evidence/X25-order-image-next-steps-round2-2026-09-11.md), then extend X25's explicit contracts through the exact unsupported inventory. Do not substitute a bare design name for its saved image ID; reconcile the documented entity-key width and legacy image-store differences. Verify financial/formula/locale output, long text, pagination, copied documents, and physical printer behavior against desktop evidence.
5. Carry the same source-contract, real-browser, posted-row and reversal verification method through X23 lot manufacturing, following [its exact next contract](evidence/implementation-2026-09-11-round2/x23-lot-manufacturing-next-contract.md). Reconcile component lot schema, effective manufacturing mode and configured direction before enabling a Setting writer; generic issue/receipt projections are not interchangeable with it. Continue X18–X21 contained tag workflows, then every remaining card and original package. None of their acceptance is waived by this continuation.
6. Repair and remeasure X02 scanners, complete source timestamp migration and X30 reconciliation/rehearsal, prove X31 recovery/service behavior, close X32 variants, and run X33/X34 full-product acceptance and release certification. Existing red release gates remain evidence of unfinished work; do not raise thresholds to conceal them.

The final CLI gates still report the pre-existing 127 rounding-helper uses against a ceiling of 108, and 101 unreachable fields against a ceiling of 96. The four wholesale dead-cell findings also remain visible. No limit or baseline was raised. Exact Crystal formatting, printer output, independent desktop execution, historical source recovery, live provider acceptance and production release certification remain unverified.

All 34 execution cards, 83 packages, and 198 menu acceptances remain open for their complete requirements. The full-feature/workflow completion percentage remains unmeasured; engineering test totals do not establish end-to-end desktop parity.
