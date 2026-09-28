# X13 saved Return preview UI — Round9 staged implementation

The saved Return card now has a separate calculation preview for one exact saved incoming row. It uses the server's trusted baseline, configuration captions, field capabilities and editor presentation. Each explicit button/Enter action submits the complete ordered journal; identical repeated values remain distinct events. No result is passed to legacy Return create/edit or the metadata writer.

This is staged product evidence, not final browser acceptance or complete X13 parity. The agreed behavioral and source boundary is `x13-replay-ui-contract.md`; API and pure projection evidence are separately owned.

## Delivered files and behavior

- `apps/web/lib/salesReturnReplay.ts`: strict matching full-scope/document/config/token/raw/six-field-identity readers, 63 visible/eight cache/12 editor maps, exact event-only request construction, conflict recovery and request generations. Ready profile-denied snapshots remain inspectable; failed projection maps are NULL. No decimal passes through Number.
- `apps/web/components/SaleReturnReplayPanel.tsx`: explicit completed-field interaction, readable baseline/preview comparison, retained ordered journal, invalid draft preservation, deliberate reload after stale/uncertain observation, empty/no-incoming state, metadata isolation and guarded keyboard focus. Tab/blur does not commit. Display captions use the configured nonempty label, with an original-label fallback for a blank label so controls retain an accessible name; stable IDs still identify events.
- `apps/web/components/SaleReturnSavedPanel.tsx`: per-hydration observation generation remounts the preview, including unchanged same-version loads; metadata/local book/load actions freeze while preview is open; parent scope/close/reload clears its authority.
- `apps/web/lib/salesReturnForm.ts`: narrow valid-empty-header read support with incoming-line provenance count validation. Metadata fields and backend capabilities remain unchanged. Existing malformed omitted-row tests still reject because the count disagrees.
- `apps/web/test/salesReturnReplay.test.ts`: 32 meaningful helper cases, including independent raw/display/editor text, >10-character saved presentation retained/refused/corrected, blank and ordinary whitespace commits, control-character refusal, complete identity/capabilities, rejected drafts, repeated ordered events, empty and profile-denied observations, and asynchronous generation invalidation.
- `apps/web/test/sales-return-replay.journey.mjs`: 15 planned actual-stack checks, fixture seed/cleanup and exact business/dependency snapshots. Root owns the shared runner integration and execution.

## Verification completed locally

| Check | Result | Evidence |
| --- | --- | --- |
| Focused new helper + existing saved reader | 2 files / 63 tests passed (32 new + 31 existing), no skips | `replay-ui-tests-ready.txt` |
| Web runtime TypeScript project | exit0 | `replay-ui-types-ready.txt` |
| ESLint for the five TypeScript source/test files | exit0, no ignored-file caveat | `replay-ui-lint-ready.txt` |
| New actual journey syntax | `node --check`, exit0 | command outcome recorded in scoped manifest |

Earlier local stages are retained separately: 26 new helper tests passed before blank/whitespace alignment; a first exploratory TypeScript invocation found narrowing errors in the new helper, corrected without weakening validation. The logged first-ready stage has 27 new +31 existing tests and passing types/lint. The 63-test stage supersedes it after control-character, long-text, empty/header and profile-denied coverage. No failed browser or DB run exists for this slice yet.

## Actual-stack journey awaiting root execution

Exports are `seedSalesReturnReplay(sql)`, `cleanupSalesReturnReplay(sql)`, `snapshotSalesReturnReplay(owner,tenantId)`, `salesReturnReplayFixtureTables` and `exerciseSalesReturnReplay(page,{checkpoint,snapshot,holdSalesReturnReads,password,tenantId})`. Root integrates the result as `salesReturnReplay` after the previous fourteen journeys. The fixture deliberately sets the synthetic company's calculation settings only after those journeys have finished; root's tenant cleanup owns final settings removal.

The fixture contains configured books R91/R92 with duplicate voucher00001 and SR17/42, OLD31/58, exact complete saved identities, ordinary P/I untagged rows and explicit finite numerical source values; voucher00002 is tagged/read-only, 00003 has a full large saved editor amount and 00004 has no incoming items. A separate owning View-only login can preview while metadata update remains disabled. Two independent HTTP clients change one saved HUID and one column caption deliberately; each following preview phase is checked against a fresh exact business-table snapshot. Those actor changes are not claimed to be preview writes.

Planned actual checks cover authoritative bootstrap/captions, all12 fields visible as source IDs, repeated ordered commits, invalid draft/no dispatch, Enter versus Tab and blank source semantics, row-only amounts/zero writes, close focus, exact alternate row, real stale document/config conflicts and explicit reload, delayed read across close and book A→B→A, large retained editor correction, tagged and empty observations, View-only preview, strict request bodies and browser exceptions.

Until root runs this journey, there is no real-browser or new DB credit in this UI note. Final root build/full tests and screenshots must be referenced separately after the product/test input snapshot is frozen.

## Remaining parity limits

No numeric persistence, aggregate/tender/refund/ledger calculation, source F1/admission, gross/component entry, row insertion/deletion, tag ownership, outgoing exchange or report closure is delivered. The one-field explicit commit interaction is a bounded completed-cell simulator, not a reproduction of every desktop grid focus event. The ten-character request limit and exact-decimal interpretation are declared web preview boundaries; programmatically assigned long desktop Text, runtime locale/binary formatting and unresolved ADO duplicate column binding remain qualified in the source contracts.
