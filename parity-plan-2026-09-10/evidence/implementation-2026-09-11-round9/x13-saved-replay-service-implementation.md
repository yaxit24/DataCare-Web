# X13 saved Incoming Return replay service — Round9 engineering evidence

The bounded server-owned saved-row preview is implemented and its final focused verification passed **6 files / 192 tests / 0 skips**. This is a calculation preview with no business writes. It does not enable numeric Return saving, original-sale admission, tag allocation, component changes, voucher settlement or financial parity. X13 remains open.

The prior plan/checkpoint artifacts are unchanged. This note covers the new replay service, narrow transaction-local readers and their focused tests after checkpoint29. Root's later whole-application build, browser and full-suite results belong to the Round9 checkpoint and are not retroactively claimed by this note.

## Implemented contract

The service exports `getSaleReturnIncomingReplayState`, `previewSaleReturnIncomingReplay`, `saleReturnIncomingReplayInput`, typed DTOs and `SaleReturnIncomingReplayError`. Root wires fresh owning Sales/Sales Return View authorization to GET `/sales-returns/:vchNo/incoming-replay-state` and POST `/sales-returns/:vchNo/incoming-replay`, with explicit selected company/location/year/book query scope and no-store responses. POST is explicitly a read action.

The request accepts only `{replayVersion,rowIdentity,events:[{fieldId,editorText}]}`:0–100 ordered entries, original editor text up to10 characters, exact known stable field IDs, and64-character lowercase hexadecimal version/identity tokens. The supported fields are c19/20/21/23/24/25/26/27/28/36/37/38. Unknown shapes/fields fail400; known unsupported/hidden actions fail422. No client policy, width, caches, raw baseline, source reference, edition, row0/navigation context or copied state is accepted.

The first profile uses the exact nonzero five-digit saved key. It deliberately leaves imported noncanonical/six-to-eight-digit preview support open rather than changing shared numbering. Primary P/I untagged rows are eligible only within the conservative document/period and companion restrictions. Other saved rows remain inspectable. A mathematically projectable row can retain visible/cache/editor maps while its profile disables every action; failed mathematical projection returns all three maps as NULL plus diagnostics. The public capability never grants numeric save.

Loaded overlong editor values are preserved verbatim. The request limit does not truncate them or prevent a valid shorter replacement. Echoing an unchanged value longer than10 characters returns400; an explicit shorter correction can be previewed. This is a declared web/editor bound, not a measured desktop programmatic MaxLength restriction.

## Trusted observation and projection

`readSavedSaleReturnIncomingTx` exposes the existing read-only saved observation plus its domain/date edit reason to a caller-owned transaction. Existing saved DTO/version and metadata mutations retain their previous behavior. `readSaleReturnIncomingConfigurationTx` composes the existing resolver under the same transaction; its public reader delegates to it. Neither helper opens a nested transaction.

Every GET and POST observes saved document tables, effective configuration and relevant complete physical item-master rows inside one tenant-bound RepeatableRead transaction. The composite replay token includes document/configuration versions, exact scope/voucher, profile/projection semantics, supported fields and master raw/physical observations. POST compares it before constructing projected states or accepting events. A stale document, sibling parent, setting or master produces409. The existing metadata token intentionally remains unchanged by this new master observation; it is insufficient alone for replay.

Master candidates include normalized company/item aliases, with complete raw keys preserved. The pure projector contains a discovered alias or duplicate even when an exact master also exists; genuinely different company masters remain outside the observation. Saved/master RATE_TYPE and IT_TYPE must agree until the original DataAdapter duplicate-column binding is established.

Replay ordinals come from a separate fully scoped SQL `ORDER BY SR_NO`, applied to a copy of the saved lines. Identity keys use the same `to_jsonb(t)->>'SR_NO'` representation as the raw snapshot; direct float text can differ for scientific-range values. SQL numeric ordering does not change the old saved DTO or token. Finite positive serial text is checked without converting the identity to JavaScript Number; the selected resolved ordinal is passed to the real reducer context. This test does not claim an impossible pair of distinct values that already collapse in Float storage.

The separate core projector follows primary source saved loading at10353–10438, preserves raw values, formats visible2/3-decimal cells and seeds exactly caches45/46/47/48/49/58/66/67. It does not seed c41/c42, run a row calculation on load, apply new-row defaults or integer-round saved fractional pieces. Description and tag-labour-code fallbacks affect display only. Editor text is a separate2-decimal presentation and does not itself emit an event.

Each preview starts from this trusted baseline and replays the entire ordered journal. Repeated identical entries remain meaningful. Only server-constructed positive-width LeaveCell events reach the frozen core. The source event's original editor text is retained; failure returns its index, attempted text, diagnostics and the last-valid transient prefix. No failed event partially changes that prefix. `aggregateRequired` records the source callback boundary; it does not fabricate final header, tax/refund, outstanding or ledger results.

## Executed verification

Final command, from the web root:

```sh
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test test/saleReturnIncomingReplay.test.ts test/saleReturnIncomingReplay.db.test.ts test/saleReturnIncomingReplay.routes.db.test.ts test/routePolicy.test.ts test/saleReturnIncomingConfiguration.db.test.ts test/savedSaleReturn.db.test.ts
```

The wrapper used disposable PostgreSQL port55433, migrated schema, forced tenant RLS and the non-owner runtime role. No customer database or HTTP mock was used for these database/HTTP tests. Final log: `replay-service-focused-verified.txt`; exit0;6 files192 tests;38.51s; no skips.

| Coverage | Passing tests |
| --- | ---: |
| New strict replay transport |31|
| New real replay service/observation tests |43|
| Root authenticated replay HTTP integration |12|
| Owning route policy |54|
| Existing saved Return metadata regression |26|
| Existing effective configuration DB regression |26|

The new service cases cover all twelve allowed fields, empty journal/no recalculation, exact raw NULL/blank/decimal/microsecond preservation, book/tenant separation, unsupported historical profiles and companions, hidden and malformed events, recoverable calculator failure, overlong editor correction, scientific-range serial identity/ordinal, company/item aliases, master/document/configuration staleness and physical ABA. A real second connection changes header/configuration/master between actual transaction-local reads; the result remains one coherent RepeatableRead observation, and the next fresh read changes its token.

Three independently authored source vectors are copied byte-for-byte into `apps/api/test/fixtures/saleReturnIncomingReplay.independent.json`. All six ordered prefixes assert all63 visible cells, eight caches, original returned event sequence, aggregate flag and unavailable save capability. Explicit editor assertions are checked exactly. The only stored projection adjustment is source PCS: SQL decimal(12,3) stores1 as1.000, and source saved ToString preserves that representation. Expected arithmetic remains the independently pinned literal output: rate→manual labour ends230; reverse order ends220; an equal manual total still changes visible labour percentage before the next same-valued trigger updates its comparison cache.

No-write tests compare all24 selected/sentinel tenant business/configuration/master tables as SQL text plus xmin/ctid: SL_DATA, SL_DETL_RTN, SL_DETL, SL_IDTL, BAR_DATA, BAR_DETL, BAR_IDTL, MAIN_STOCK, AC_DATA, TAX_DATA, BILL_OS_DATA, ROJ_MEL_DATA, DM_DATA, REMARK_DATA, TEMP_BOOK_DATA, SRNO_MAST, TAG_SET, CO_SET, CO_SET_NEW, COL_MAST, BOOK_DATA, YEAR_MAST, ITEM_MAST and EMP_MAST. Empty collections are included. The reducer-call spy in the serial test observes the actual implementation and verifies context row2; it does not replace the reducer or database response.

## Retained exploratory stages

| Log | Actual result and attribution |
| --- | --- |
| `replay-api-types-first.txt` | Source typecheck passed before the later ordinal/company-alias review changes; not represented as the final strict test compiler. |
| `replay-service-focused-first.txt` |149 passed /43 failed; all new DB cases stopped at the common fixture setup because `SECOND HUID` exceeded source HM_ID varchar10. Corrected to distinct `SECOND H1`. No product guard was relaxed. |
| `replay-service-db-fixture-corrected.txt` |40 passed /3 failed. One fixture omitted mandatory DM_DATA MAIN_SRNO/ISR_NO; supplied actual identity fields. The other failures were a5s transaction expiry and unreachable disposable DB during the overlapping production build. These failures are retained. No product/test timeout was raised. |
| `replay-service-focused-verified.txt` | Final serial6/192 pass after fixture corrections and independent test strengthening. No parallel heavy build ran during this stage. |

The first authenticated HTTP stage is separately root-owned. The final focused set reruns its expanded12 cases against current source. This note does not hide earlier failures or reuse an earlier pass as acceptance for later code.

## Limits that remain

This is the declared mathematical decimal projection/calculation profile. It does not prove universal original VB Double/Format/DBNull/culture behavior or the unresolved ADO duplicate-column name binding. Numeric NULL/malformed/unsupported precision cases remain readable with projection diagnostics. The replay token observes surviving physical rows; absent→insert→delete recurrence is explicitly tested and can return to the original token because no durable tombstone exists.

A preview is consistent as of its transaction snapshot and does not reserve source/stock state until response time. Any future writer must re-resolve configuration, saved/source identities and stock/finance effects inside the same locked/Serializable mutation transaction, with a proved cross-writer protocol. Original F1 versus whole import, tag/instance admission, components, aggregates, refund/credit allocation, stock/ledger/outstanding/report/reversal work, alternate variants and complete desktop/business acceptance remain separate requirements. Passing these tests does not close X13 or establish an overall completion percentage.
