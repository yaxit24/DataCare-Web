# X13 round6 saved incoming Return: independent UI/API contract review

This is a read-only review by the saved UI owner of the independently implemented API service. No database or browser run was started for this review, and no product files were edited. It is a source review of the snapshot below, not an observed desktop execution or a replacement for root's final test evidence.

## Result and verified source boundary

No confirmed mismatch was found between the implemented DTO, saved identity, metadata patch, scope, permission composition, conflict response and authoritative rehydration contract. Two smaller discrepancies are listed separately below; their eventual disposition must be recorded rather than silently treating this preliminary snapshot as final acceptance.

- `savedSaleReturn.ts` converts database scalars to SQL text through `jsonb_each_text` before JSON reaches JavaScript. Business scalar values remain string or null; numerical/date display conversion is not used to reconstruct a write. Internal row IDs, xmin and ctid remain in the observation/version rather than being lost from concurrency checks.
- All queries bind tenant, company, location, year, configured book and canonical voucher. The book policy is evaluated in the same read/write transaction. Browse has no mutation version; detail requires one unambiguous header and at least one incoming row.
- The six protected line fields are SR_NO, OLD_SRNO, VCH_SRNO, TAG_SRNO, IT_CODE and TAG_NO. They compare exactly to the current saved observation before a parameterized full-scope/SR_NO text-only update. Array position never selects the write row. Numeric conversion is used to reject nonfinite/nonpositive identity and sort display, not to rebuild the stored identity.
- The version includes all fourteen protected table observations, complete raw rows, physical row revision/locator/identity, scoped company settings and configured book rows. Read uses RepeatableRead; write uses Serializable, locks the header before the related rows, and maps expected serialization conflicts to409 without automatically retrying.
- Root routes require complete explicit query scope on browse/read/write and owning Sales Return view/update rights. GET and PUT add fresh top-level canUpdate. UI editability also requires the document domain capability and that field's capability; no permission is inferred from visible tags or an editable-looking input.
- HUID and Receive Item changes update only HM_ID and ITM_REMARK on the exact incoming row. Header employee, when allowed, updates only existing SL_DATA/SL_DETL_RTN and the explicitly proven optional BAR_DATA. Numeric calculations, numbering, allocation, stock/ledger replacement and tag/source reassignment are absent from this service.
- Raw NULL/blank description is distinct from the ITEM_MAST display fallback. The UI emits only explicit dirty fields and does not write the fallback on an unrelated HUID edit. Missing/extra identity values and malformed/lossy observations are rejected before controls become editable.
- PUT returns the authoritative post-write DTO in the same transaction. The UI hydrates that response.409 preserves the draft and requires deliberate Reload; uncertain network/HTTP5xx or an invalid post-commit observation also blocks repeat mutation pending Reload.

## Eligibility clarification

The actual line capability is per incoming row; it does not require the entire saved document to be incoming-only. An eligible untagged incoming row can retain HUID/description editing when scoped outgoing rows or SL_IDTL/BAR_IDTL rows are present, because those text edits leave every related row unchanged. A scoped BAR_DETL, a real tag, issued/approval flags, an unsupported incoming entry kind or global editing/period restriction denies those line edits.

Header employee is more restricted. Outgoing rows/components, unsupported incoming rows, ambiguous or unsupported BAR companions, DM_DATA, missing/ambiguous company settings, or an unproven BAR_DATA match deny it. The browser's imported fixture deliberately has preserved related rows and a denied employee field while still permitting the exact incoming HUID edit. Describe this per-field containment precisely; do not advertise general exchange/companion editing.

## Discrepancies sent to root and the API owner

1. **Display diagnostic absent, raw data preserved.** The API contract promises an explanatory diagnostic when the fallback item name is missing or ambiguous. The inspected service instead returns itemName:null and an empty display description when the raw remark is empty and no unique name resolves. It does not arbitrarily select a conflicting name and does not lose the saved raw remark. This is an unimplemented diagnostic, not an observed destructive write.
2. **Special imported date containment requires confirmation.** The contract says invalid saved VCH_DATE denies edits. `periodReason` delegates to `assertPeriodOpen`, whose no-lock branch returns before parsing a nonempty voucher date. PostgreSQL permits special date values such as infinity; static inspection therefore indicates that such a saved value could remain editable with an empty LOCK_DATE. Missing dates and configured-lock invalid dates are already blocked. This edge was not reproduced against PostgreSQL by this reviewer. Root/API owner must either add and verify a bounded validity guard or explicitly retain the limitation.

No product change was made by this reviewer. Any fixes and their focused tests must be linked to the final source snapshot rather than attributed to this preliminary review hash.

## Verification available at review time

Owned UI/helper tests: `x13-saved-ui-tests-first.txt`,1 file26 tests passed. Focused lint: `x13-saved-ui-lint-first.txt`,exit0. Final focused web typecheck: `x13-saved-ui-types-ready.txt`,exit0. Retained `x13-saved-ui-types-guarded.txt` records two callback-narrowing TypeScript errors that were corrected by explicit local aliases before the passing typecheck; runtime validation was not weakened.

The independent API owner reports `saved-incoming-focused.txt`,3 files84 tests passed (21 service,9 authenticated HTTP,54 route policy), including real concurrent edits, child ABA, parent recreation, complete preservation and late rollback. This review did not rerun those tests. Root owns production build, full web/API checks and actual browser evidence, which were still in progress when this review was captured.

Original-source import, incoming calculation/cache replay, tag admission/consumption, outgoing exchange, UAE, versioned deletion, complete print behavior and desktop/business acceptance remain open. This bounded read/metadata review does not close all33 exposed fields or complete X13 parity.

## Inspected source snapshot

Captured UTC: 2026-09-11T08:11:25.435962+00:00

| Path relative to web | SHA-256 |
| --- | --- |
| `apps/api/src/modules/sales/savedSaleReturn.ts` | `95175a61b1e8d4e48ff23d937c0577799bcae90d6fe0e914030d0034eae87a6b` |
| `apps/api/src/modules/posting/posting.ts` | `31cb38b11b25cdfdaaf796ae2d4305888b6f61f71704fde9e97424bacb6df44e` |
| `apps/api/src/routes/txn.ts` | `3a769dd9fd4a8cc0280b9ba158f454b583632453702e99f0ad8f521bc358daa1` |
| `apps/web/lib/salesReturnForm.ts` | `6c5d2a90fac34c715c6d052e16588d265fba1c5c829ca5ad08ba035212dcbf1a` |
| `apps/web/components/SaleReturnSavedPanel.tsx` | `8ea6bcabdda860145176653eba663ca5d97bfece92034db0db291b4155d2e3cf` |
| `apps/web/app/(app)/txn/sale-return/page.tsx` | `3c8f6e46d9c175793321b852d3adbf434a4214cdd566afad0d1fc979079bb29b` |
| `apps/web/test/salesReturnForm.test.ts` | `de31ed726b99e412f92b71e3f6289e67a9defb9cd83b1b27f23bef0f03d219e5` |
