# Tour Order labour and timestamp: round 2 implementation evidence

This implements a bounded source slice, not complete X14 or Sales Order acceptance. All original execution cards and full desktop/business acceptance remain open. Round 1 documents and checkpoint 15 are historical; this document records the new changes separately.

## Desktop contract implemented

`unified/src/csharp/DataCareNext/TR_SALE_ORD.cs:6743–6874` uses cached prior labour amount/rate/percentage to distinguish committed edits. The relevant cell commit handlers are at 5736–5827. Labour amount rounds to whole rupees with midpoint-to-even semantics. Source configuration is in `MS_OPNCOMP.cs:691,817–819,1297–1303`.

| Basis | Forward labour amount before whole-rupee rounding |
| --- | --- |
| P | Pieces × labour rate |
| G | Gross weight × labour rate; ghat is not added |
| K | (Net weight + ghat weight) × labour rate / 1000; always includes ghat |
| Other / blank | Net weight plus ghat only when `LBR_WITH_GHT = Y`, multiplied by labour rate |

An unchanged committed rate does not reprice an imported manual amount. A percentage change derives labour rate from item rate, rounds with `LBR_ROF`, formats to two decimals and recomputes amount only when the effective rate changes. A manual amount change retains entered paise and derives its associated rate only when amount and current rate are both nonzero. The `K` inverse literally divides by 1000 after dividing by net + ghat (`TR_SALE_ORD.cs:6784`); this intentionally follows the bounded source expression and remains a required desktop-confirmation case. A manual zero amount leaves the earlier rate intact.

Changing basis, weight or pieces alone does not invent a committed labour-rate edit. The web preserves the sequence of actual committed rate/percentage/amount changes in a bounded journal, including the basis at each commit. The server replays this from its own saved prior values. For example, committing rate 37.321 before entering later ghat yields 117; changing rate away and back after that ghat is present yields 120. A final input snapshot alone cannot distinguish those paths.

## Implemented files and storage behaviour

`web/packages/core/src/orderLabour.ts` supplies the shared amount function, commit transition and validated replay. The Tour page/helper uses it on blur; the API uses the same rules and checks the submitted calculated values against replay. The journal is edit intent, not authority: saved prior rate and amount come from scoped database state, and a mismatched result fails before destructive replacement. The API rejects invalid actions, nonfinite numbers, invalid basis and journals longer than 256 events.

`web/apps/api/src/modules/sales/salesOrder.ts` loads scoped `CO_SET_NEW.LBR_WITH_GHT`, `CO_SET.LBR_ROF` and `ALL_ROF_REMOVE`. Missing `LBR_ROF` uses the documented web default of two decimals; this default is not independent proof of the desktop configuration. Invalid/duplicate configuration fails. Changed configuration participates in the existing persisted-state digest, so an editor cannot silently save with an obsolete policy.

Actual `labourRate`, `labourPct` and `labourAmount` are hydrated. Legacy per-gram `making` input remains compatible. Unchanged financial input preserves imported manual line fine, metal amount, labour amount/rate/percentage, line net/total and header totals; child-only and header-text changes preserve these values and all existing components. A legacy flattened PUT still cannot replace a saved multi-child line. Existing version checks, advisory transaction locking and full book/company/branch/year ownership remain in force.

Explicit voucher time accepts `HH:mm`, seconds and up to three fractional digits, normalizes it to milliseconds and persists the complete `VCH_TIME`. A read emits the saved business clock without browser timezone conversion. An unchanged edit preserves it. Historical date-only values cannot recover an already lost clock; source reimport remains necessary. The separate root-owned ledger timestamp migration/posting changes have their own evidence.

## Verification recorded for this slice

Focused database regression passed on the disposable PostgreSQL service at port 55433: three files, 41 tests, including ten Tour hydration tests, 29 Sales family lifecycle tests and two Tour Order tests. Runtime uses the restricted application role; fixture owner credentials are used only for controlled setup. The saved log is `tour-order-focused-db.txt`.

The core labour tests cover 23 cases: all bases, both ghat settings, positive/negative midpoint ties, percentage and manual triggers, source K inverse, zero amount/rate/basis, unchanged manual values, configured precision, rate-before-ghat, rate-away/back and invalid/unbounded replay. Focused web tests passed 12 cases across the eight Tour helper tests and four derived-value ratchet checks. The ratchet was not weakened. Combined round 2 suite/build/browser evidence is recorded by the root checkpoint; it supersedes these focused counts for final regression status.

Database vectors include P/G/K/N amounts, whole-rupee rounding, percentage rate 87.5 producing 262 on a 3-piece vector, manual 150.75 deriving rate 50.25, ordered commits producing 117 versus 120, and a forged/mismatched replay result rolling back the full prior write set. An imported line with stored fine 2.901, metal amount 20301.37, labour rate 37.32, labour amount 120.41, net 20499.77 and total 20501.33 survives unchanged and child-only edits. The database rate column is two decimals; precision beyond that was not falsely claimed as stored. Time 15:42:31.123 survives reopen and unchanged save; explicit 16:05 becomes 16:05:00.000; invalid 25:05 leaves all rows unchanged.

The actual-stack Tour browser journey has been extended to select a configured nondefault book, preserve two child rows, create/open/edit/reopen, test stale and lossy writes, execute labour P/percentage/manual transitions, preserve the manual amount on unchanged save, read the scoped source-derived print and delete. The fixture uses real login, HTTP, application-role PostgreSQL and the production web build, with no intercepted API responses. Its final execution status belongs to the round 2 browser result, not the existence of the journey code.

## Explicit remaining work

The implemented calculation slice stops at 6874. Later total-override, MRP, tax-inclusive and visibility-dependent end passes at 6888 onwards remain open. In particular, 7149–7156 can rederive labour percentage from rate when tax and MRP are zero and grid column 20 is visible. Visibility is a grid configuration property; it must not be inferred from the row's labour-percentage value. No unknown visibility setting was invented to close this branch.

Full parent total/percentage feedback loops, conversion and allocation workflows, settlement and fulfilment, downstream design/photo adoption, imported historical metadata and independent desktop golden outputs remain open. The source's K inverse, configured rounding defaults and all remaining grid-visibility branches require executable desktop comparison before claiming complete desktop transfer. Passing this bounded regression does not close X14, P05-04, P05-06 or the full product.
