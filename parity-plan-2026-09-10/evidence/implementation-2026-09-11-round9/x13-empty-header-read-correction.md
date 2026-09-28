# X13 empty saved Return header — post-review correction

The real browser uncovered an omitted read contract: an existing configured Return header with no incoming rows could not reach the saved/preview empty state. The shared `savedSaleReturn.snapshot` threw422 before producing either read DTO. The earlier192-test focused result did not cover this case and is not retroactively credited with it.

The correction is deliberately narrow. After the existing fully scoped header/table observation, the service records the no-incoming reason. A locked metadata mutation still throws the same422 `unsupported-state` before any update. An unlocked saved read now returns the exact header, empty incoming rows, related saved records and the no-incoming reason as its domain edit restriction. Header employee and document metadata capabilities are false. The replay service is unchanged: the readable empty observation produces `rows:[]`, `canPreview:false` and `canSaveNumeric:false` with its normal document/configuration/composite versions.

An operator's fresh owning Edit permission is distinct from the document's domain eligibility. The authenticated saved DTO may still report that permission as `canUpdate:true`; its `capabilities.canUpdate` and employee capability remain false for this empty document, and the server rejects the actual mutation. No dummy row, generated identity, counter reservation or write authority is created. A fabricated replay row with the current token returns409. Missing headers retain404. Nonempty DTO/version construction is unchanged, and the existing incoming-recent list still filters nonempty documents; no listing expansion is claimed.

The source change is confined to `apps/api/src/modules/sales/savedSaleReturn.ts`. New actual service and authenticated HTTP tests are in `apps/api/test/savedSaleReturnEmpty.db.test.ts`.

## Focused verification

The isolated port55433 wrapper run passed **5 files / 96 tests / 0 skips**, exit0,17.59s. Log: `replay-empty-header-focused-first.txt`. This was the first focused run of this correction; no failure was hidden, timeout changed or test skipped.

```sh
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test test/savedSaleReturnEmpty.db.test.ts test/savedSaleReturn.db.test.ts test/savedSaleReturn.routes.db.test.ts test/saleReturnIncomingReplay.db.test.ts test/saleReturnIncomingReplay.routes.db.test.ts
```

| File/group | Passing tests |
| --- | ---: |
| New empty-header service and HTTP cases |6|
| Existing saved metadata service |26|
| Existing saved metadata HTTP |9|
| Existing replay service |43|
| Existing replay HTTP |12|

The six new cases prove:

1. Exact raw empty-header clock with six fractional digits, NULL description, blank employee and large decimal remain readable; domain/header capabilities are false; the nonempty sibling book's version remains unchanged.
2. A fresh valid metadata token and a supported employee patch reach the locked service refusal422. A current replay token with a fabricated64-hex row identity receives409.
3. Both actual authenticated GETs return200/no-store and empty rows for View and Edit users. Neither grants domain metadata or numeric authority.
4. An operator with actual owning Edit rights receives422 on employee metadata PUT and409 on fabricated replay POST. This tests domain refusal after authorization, not a malformed request or permission failure.
5. An existing outgoing component remains in related raw data while incoming rows remain empty; no component is relabeled or fabricated as incoming.
6. Inserting a real incoming row after the empty observation changes its token: the old preview request fails409 version-conflict before identity/projection. Truly missing saved/replay headers still fail404.

Before/after assertions compare raw SQL text plus xmin/ctid across24 business/configuration/master tables for the selected and sentinel tenant/books, including empty stock, ledger, tax, outstanding, counter and reservation collections. Authentication/session maintenance is outside that business snapshot. These are actual non-owner-runtime/RLS PostgreSQL and authenticated application routes; no HTTP mocks were used.

## Evidence boundary

The prior `x13-saved-replay-service-implementation.md`, its run manifest, the independent review and prior focused logs are retained unchanged as historical evidence. Their saved-service hash necessarily predates this correction. The new correction manifest pins the current saved service, new tests and96-test log; it does not rewrite the prior source snapshot. Whole-workspace compilation, rebuilt browser execution and full API regression after this change remain root-owned checkpoint evidence.

This fixes read-only empty-state behavior. It does not admit a new incoming item, enable numeric saving, implement source selection/tag/component workflows or close X13 financial/business parity.
