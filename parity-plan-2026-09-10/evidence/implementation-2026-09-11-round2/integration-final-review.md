# Final integration review: two bounded data-correctness fixes

The final round 2 review inspected the credit-note reader/browser and IRN action, shared ledger timestamp migration/posting enrichment, and Tour labour journal integration. It was not a broad security scan or full desktop acceptance review. Two concrete defects were found and corrected with the root agent's authorization. Product and test sources were then frozen for the root's final combined verification.

## Allocation references use the source order's complete identity

Previously `assertOrderUnconsumedTx` in `web/apps/api/src/modules/sales/salesOrder.ts` matched `SL_ORD_ADJ` using only tenant, company and order number. This blocked an unallocated order when another branch, financial year or book reused its voucher number. The allocation's own `LC_CODE`/`CO_YEAR`/`CO_BOOK` identify the later settlement document; `ORD_LC`, `ORD_YRCD` and `ORD_DBCD` identify the original order.

The guard now retains the tenant/company/order-number checks and compares each populated source-order dimension to the target order. A null or trimmed-blank dimension is unknown and conservatively permits a possible match; it does not borrow the allocation document's own scope. Any populated dimension that differs rules out that allocation for this order. Thus an entirely unspecified legacy reference still blocks, but a known other book is not turned into a match merely because branch/year are unspecified.

Both edit and cancel use this guard. The focused real database run passed one file / 12 tests (`tourOrderHydration.db.test.ts`), including two new cases: exact referenced order blocked; reused number in another book, branch or year allowed to edit/cancel; child rows retained; full state unchanged after refusal; unknown legacy references blocked; explicitly different book with other dimensions blank allowed. The external allocation row remains intact. Test database: disposable port 55433 with restricted runtime role and controlled owner fixtures. The retained log is `allocation-scope-db.txt`.

The separate outstanding/settlement workflow still requires its own complete identity review. This bounded guard correction does not close allocation, settlement or conversion parity.

## IRN adapter preserves explicit zero amounts and tax rates

`submitIrnForCreditNote` delegates to `submitIrnForSale`. Its item adapter previously used `N(detail.NET_AMT) || N(header.NET_AMT)` and the equivalent tax-percentage expression. For a stored document with line net amounts 100 and 0, header net 100, the zero line was turned into another 100 assessable item. It could also inherit a nonzero header tax percentage despite an explicit zero detail percentage.

The adapter now chooses the fallback only for null/undefined detail values before numeric conversion. Explicit zero stays zero. The change applies to both CRN and ordinary INV payloads; the configured-book family check and document type remain intact. No quantity fallback or provider policy was changed.

The dedicated `creditNoteIrnAmounts.test.ts` covers both document families with mixed 100/0 amounts and header 100, asserting assessable total 100 and total including the first line's tax 103. It separately distinguishes null and absent values, which still use the header fallback, from zero. An entirely zero-total document remains rejected by the existing `ValDtls.TotInvVal` validator and never reaches the transport.

The final focused unit run passed three files / 19 tests: eight new adapter cases plus the existing six payload tests and five GSP tests. It uses explicit SQL-response fixtures and the existing deterministic fake transport; network calls are forbidden. `ALLOW_SKIP_DB_TESTS=1` was explicit because these are selected unit files. This result is not evidence of real database posting, live provider acceptance or release readiness. The retained log is `irn-zero-amounts-unit.txt`.

## Other reviewed paths and limits

The current credit-note `Fields` component iterates the ordered descriptor labels and reads only keys actually present on each stored row, so database JSON key order no longer determines the screen layout. The earlier bag/ghat/stone/karigar label visibility gaps have been addressed. The reader retains its complete scope and source `OLD_SRNO` child mapping; this review did not find another confirmed regression in those bounded paths.

The ledger migration changes `AC_DATA.ENTRY_TIME` from date to timestamp while preserving historical date-only values at midnight. Shared enrichment prefers an explicitly supplied leg time, otherwise a document `VCH_TIME`, then the existing date fallback. The dedicated database timestamp test covers inherited time, explicit-leg precedence and before/equal cutoff sums. Lost historical times remain unrecoverable without source reimport. This review did not perform a new database or desktop run for that separate migration.

Tour's committed labour journal uses server-owned prior rate/amount plus explicit edit intent, preserves imported manual values on unchanged edits, and rejects a mismatch before replacing the write set. Remaining source branches and desktop-confirmation limits are recorded in `tour-order-labour-evidence.md`. No complete X14/X15 acceptance, live provider approval or functional percentage is claimed here.
