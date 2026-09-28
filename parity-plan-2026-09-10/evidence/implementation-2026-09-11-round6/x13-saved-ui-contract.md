# X13 saved incoming Sales Return: UI and API integration contract

Status: bounded saved UI implemented and verified through focused tests and the rebuilt actual browser after root froze round5 checkpoint23 (SHA-256 `2f702b34c8e04aa7ad2704e7dc1c3d70846c5e0d35761b206b35a03e112a0498`). This document does not close any of the 33 field findings, certify complete Sales Return parity, or replace the frozen round4 `x13-sale-return-33-next-contract.md/json`. Root's final whole-API checkpoint remains a separate acceptance record.

The first slice is a complete saved-record observation and a narrowly authorized metadata edit. It must not route an imported saved return through the existing numeric replacement writer. The existing create form is a separate legacy workflow; its known original-source, calculation, tag-admission and accounting gaps remain explicit.

## Ownership and implementation boundary

The UI owner may change `apps/web/app/(app)/txn/sale-return/page.tsx`, add `apps/web/lib/salesReturnForm.ts`, `apps/web/components/SaleReturnSavedPanel.tsx`, and focused helper tests. The independent browser owner adds the actual journey. Root owns routes, route authorization and authenticated HTTP tests. The API owner owns the saved raw DTO, version/capability computation and the bounded metadata service.

Do not change generic `VoucherList`, `ExtendedGrid`, `BookSelect`, shared numeric calculators, the ordinary Sales writer, or shared scope behavior for this slice. Do not call `editSaleReturn` from the new metadata path. Do not add a numeric field to a write map merely because the existing page exposes it. Any tag companion update must be explicitly proven and atomic before the server grants its field capability.

## Source facts that determine the UI

Paths and line numbers below refer to `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` unless stated otherwise.

- The incoming grid is `MSG_PR`, initialized at3563 with71 columns. The outgoing `MSG` and its `SL_DETL` writes are a different leg. The incoming write target is `SL_DETL_RTN`, `dataRow5` at14319–14569.
- Incoming visible text cells include Receive Item3 (3588), Counter4, Design5, configured Style6, Size7 and HmId8 (3610). The text commit at4616–4628 assigns the text directly without calling `CommPassTotal_Pr`. The current 33 findings contain the genuine visible text fields `remark` and `huid`.
- The saved reader at10362–10370 displays `ITM_REMARK` when nonempty and otherwise displays `ITEM_MAST.IT_NAME`. This display fallback is not permission to replace an untouched saved NULL/empty remark during a web metadata edit. Keep displayed description and exact raw remark separately; that unchanged preservation is an explicit web loss-prevention behavior requiring desktop/business acceptance.
- Employee is selected in the header and written to `SL_DATA.EMP_CODE` at12877 and every incoming `SL_DETL_RTN.EMP_CODE` at14565. The outgoing leg writes the same header value at15019. Never expose independently editable per-line employees. A conflicting imported header/line employee must remain visible and preserved until the operator deliberately chooses a permitted header edit.
- HmId2/3/4 and four hallmark weights occupy hidden columns59–65 (3723–3729); Design image identity is hidden69 (3733). Original source copying is3964–3973, saved hydration10427–10437, incoming writing14517–14569. They are preserved raw/source values, not freely editable grid cells in this slice.
- Header original identity is `ISU_NO/ISU_LC_CODE/ISU_YRCD/ISU_DBCD` at12825–12837. The primary source stamps the current location into `ISU_LC_CODE`; it does not prove a freely selectable cross-branch source mode. The original year/book/voucher remain independent of the return year/book/voucher. `BILL_NO` is assigned blank by the primary writer at12841; the current web's bill label use is a separate unresolved compatibility issue.
- Source F1 at3880–3882 requires a selected original voucher/book and a blank incoming item entry. It lists eligible original sale rows, excluding already returned tags. Selection copies hidden metadata and source children at3913–4018, then calls `CommPassTotal_Pr` at4023. It is not an ordinary generic tag lookup and cannot be implemented by copying a subset of text fields without the calculation and child contract.
- Original F1 does not assign incoming column40 `VCH_SRNO`. It sets column51 `OLD_SRNO` to the current incoming row at3913. Saved hydration reads existing column40 at10419, while save14481–14497 generates a new admitted instance if column40 is zero. Keep the original sold instance separate from the saved incoming instance; do not reuse the original `VCH_SRNO` as the admitted instance.
- Ghat percentage and labour discount are actual incoming numeric commits, but they call `CommPassTotal_Pr` and depend on cached prior values. Text-only metadata editing cannot claim to implement these calculation triggers. Saved caches include gross45/net46/touch47/west48/rate49/labour rate58/labour percentage66/tax67 at10377–10416. Source numeric ordering and companion stock/accounting are a separate slice.

## Saved record identity and exact data

The saved page uses complete explicit `{coCode,lcCode,coYear,coBook}` on every browse, read and write. The authenticated tenant is server-owned and must not be accepted from a UI payload. The selected book must be active, uniquely configured as workflow `SALES RETURN`, whose actual persisted `MAIN_BOOK` spelling is `SALES RETURNE`; validate the expected `SL_DATA` table and incoming direction. UI filtering uses that exact spelling rather than guessing `SALES RETURN`.

An observation captures immutable `{coCode,lcCode,coYear,coBook,vchNo,version}`. These values are copied from the validated server response, not reconstructed from the current toolbar at save time. A saved line carries exact `SR_NO`, `OLD_SRNO`, `VCH_SRNO` and `TAG_SRNO`, plus its raw item/tag identity. `SL_DETL_RTN` has a composite primary key of tenant/company/location/year/book/voucher/`SR_NO`; it has no `row_id`. `SR_NO` must never become the row's array index. The UI creates a stable client key from the saved identity and keeps display order separate.

The server returns raw database scalar values without lossy numeric/date conversion. PostgreSQL numeric values and identity floats are serialized to their exact database text representation, timestamps preserve microseconds, and SQL NULL remains JSON null. Text preserves spaces, blank and sentinel values. The UI stores the raw DTO unchanged; it derives separate display strings, draft metadata and dirty-field sets. Neither spreading a display object over raw data nor `Number(...)` serialization is allowed in the metadata path.

Root and the API owner agreed to three dedicated routes. These are separate from the existing legacy create/import/read/replacement functions:

- GET `/sales-returns/incoming-recent?coCode=…&lcCode=…&coYear=…&coBook=…`
- GET `/sales-returns/:vchNo/incoming?coCode=…&lcCode=…&coYear=…&coBook=…`
- PUT `/sales-returns/:vchNo/incoming-metadata?coCode=…&lcCode=…&coYear=…&coBook=…` with only the observed version and metadata patch in the JSON body. Scope is mandatory query data on all three routes; it is not allowed as an extra patch field.

Register the static `incoming-recent` route before the voucher parameter route. All three use the owning Sales Return view/update authority and validate the configured return family within the same authoritative read/write transaction. A successful browse is not permission to edit a row without its full saved observation.

Agreed core wire shape (the API may return additional read-only raw/display/provenance fields; the UI must preserve rather than spread them into a mutation):

```ts
type ExactScalar = string | null;
type RawBusinessRow = Record<string, ExactScalar>;
type SavedScope = {
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
};
type FieldCapability = { allowed: boolean; reason: string | null };
type IncomingIdentity = {
  srNo: string;
  oldSrNo: string | null;
  vchSrno: string | null;
  tagSrNo: string | null;
  itCode: string | null;
  tagNo: string | null;
};
type SavedIncomingReturn = {
  scope: SavedScope;
  voucherNo: string;
  version: string;
  canUpdate: boolean; // Root adds fresh owning-form authorization, separate from domain capabilities.
  capabilities: { canUpdate: boolean; reason: string | null };
  header: {
    raw: RawBusinessRow;
    display: { employeeName: string | null; employeeNameReason: string | null };
    capabilities: { employeeCode: FieldCapability };
  };
  lines: Array<{
    identity: IncomingIdentity;
    raw: RawBusinessRow;
    display: {
      itemName: string | null;
      itemNameReason: string | null;
      description: string;
    };
    capabilities: { huid: FieldCapability; description: FieldCapability };
  }>;
  related: Record<
    'outgoingLines' | 'outgoingComponents' | 'tagHeaders' | 'tagParents' | 'tagComponents',
    RawBusinessRow[]
  >;
  provenance: Record<
    'incomingLineCount' | 'outgoingLineCount' | 'outgoingComponentCount' |
    'tagHeaderCount' | 'tagParentCount' | 'tagComponentCount', number
  >;
};
type IncomingRecent = {
  rows: Array<{
    voucherNo: string;
    raw: RawBusinessRow;
    display: Record<string, ExactScalar>;
  }>;
};
type IncomingMetadataRequest = {
  version: string;
  header?: { employeeCode: string };
  lines?: Array<{
    identity: IncomingIdentity;
    changes: { huid?: string; description?: string };
  }>;
};
```

The recent row's raw data includes precise `VCH_DATE`, `VCH_TIME`, `AC_CODE`, `RTN_NET_AMT`, `NET_AMT` and other returned header scalars. It contains no actionable edit version: Load obtains the current observation. The saved card must show both incoming and outgoing saved amount summaries and their provenance, rather than flattening RTN_* and ordinary totals into one generic net value. Record eligibility is server-owned; the UI must not infer it from whether a displayed tag is blank.

The service's returned scope also includes the authenticated `tenantId`. Preserve the received observation, but construct request query scope from only the four agreed company/location/year/book fields; the client never supplies tenant authority. List display is `{customer,date,billNo}`. Related arrays represent scoped `SL_DETL`, `SL_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL` respectively, and must retain that distinction in labels. The UI combines top-level `canUpdate`, document domain `capabilities.canUpdate`, and the individual field's `allowed`; all three must permit an edit.

After the independent review, both nullable display reasons are required in the complete DTO. They describe the saved company item/employee lookup independently of patch authority. Missing or multiple item-master matches produce a reason even when an explicit saved remark remains available; no arbitrary name is selected. An empty saved employee identity has no missing-name warning, while a nonblank missing or ambiguous employee has a reason. Show these business reasons beside Receive Item and Header employee. They must not replace raw values, manufacture a draft edit, or grant/deny a field independently of its capability. An absent or non-string/non-null reason is an incomplete observation and cannot enable editing.

Line metadata eligibility is per incoming row. An eligible untagged incoming HUID/description edit may preserve existing outgoing/component records without editing them; the presence of such records separately denies the wider header employee operation. Do not describe this as permission to edit an outgoing exchange or to synchronize unproven children. Root approved explicit invalid saved-date containment, including PostgreSQL infinity dates, before final acceptance of this slice.

PUT returns the complete authoritative post-write DTO and fresh version directly. Hydrate that response without a mandatory second GET. The existing GET remains the explicit Reload action. Error envelopes are `{error:code,message}`:400 invalid input,404 missing saved record,409 `version-conflict`/`identity-conflict`,422 unsupported/locked/configuration state, and existing401/403 authorization. An uncertain network or HTTP5xx result requires Reload; no automatic resend is permitted.

The version spans the complete header, both legs, components, and the companion write boundary, including physical revision information to detect A→B→A replacement. The UI treats it as opaque. Simple untagged incoming-only records may permit HUID/description. Tagged records remain denied until the exact unconsumed return-owned companion is proven. Employee editing is denied when outgoing or companion effects are unsupported. If granted, employee validation uses company `EMP_MAST` (source15759) and `CO_SET.EMP_CODE_MANDATORY` (source12117; setup `MS_OPNCOMP`710, blank default N at899).

The saved observation must contain:

1. Full saved identity and a nonempty opaque version that changes when any protected persisted data or capability prerequisite changes.
2. The complete saved header and incoming parent rows as raw scalars, including all currently supported business columns, hidden image/hallmark metadata, numeric caches and precise timestamps. A small legacy `getSaleReturn` DTO is insufficient.
3. Separate display metadata such as resolved item name/description fallback. Display resolution must not modify the raw saved value.
4. Capabilities for document/line metadata edits with explicit allowed fields and diagnostic reasons. The UI must not infer edit permission from a role name, presence of a field or successful GET. Missing capability means read-only.
5. A source reference summary read from the saved header, keeping original location/year/book/voucher and any proven source row identity separate from admitted return identity. It must not infer a source link merely from a matching tag number.
6. Record-class diagnostics for mixed/outgoing/UAE/unsupported/imported states. The UI may display these records while preserving raw data; unavailable mutation capability is an explicit boundary, not a reason to omit rows.

The metadata request URL carries full saved scope/voucher; its body contains only observed version, explicit dirty header fields and explicit dirty line fields addressed by their saved identity. It must never include financial replacements, fabricated hidden image/hallmark values or a source snapshot to be trusted by the server. A user clearing a text field sends an explicit empty string; omission means unchanged. SQL NULL is preserved when untouched and is not silently manufactured from an empty input. Reverting a draft to its original displayed value removes its dirty edit only when that operation does not accidentally commit a display fallback over a different raw value. HUID allows10 Unicode characters, description50, and edited employee code3; imported longer untouched values stay readable and preserved.

Server mutation validation must reject unknown fields, unknown/duplicate/renumbered rows, unsupported record classes, stale observations, revoked rights and forged identities before writing. The metadata service applies exact-key updates in one transaction, retains all unsupported raw values, and either maintains proven companion metadata atomically or refuses that field's edit. It must not delete/rebuild financial, stock, child or parent records through the legacy calculation writer.

## Existing-page integration

Add a distinct saved-return mode to the existing page, with page-local browse/load controls. Never hydrate a saved voucher into the current create form and then call POST. The saved editor shows the full loaded scope/voucher/date, original source reference, raw incoming line identities, saved amounts and all preserved metadata. Its only editable controls are the capability-approved HUID/Receive Item fields and one header employee selector if permitted.

The new saved browse must return/display scoped rows from the configured return book. It must have its own explicit row Load action and request epoch. It must not use generic `VoucherList` mutation callbacks or change the shared component. A read-only existing list may remain for the legacy create section, but any saved-mode action must come from the validated loaded identity. No saved Delete action is added by this metadata slice unless root separately supplies a versioned, source-complete contract.

Show the raw saved monetary values in saved mode. Do not run the current page's `calc`, `fineFor`, `labourCharge`, total preview, tender adjustment or create-line filter during hydration, metadata edits or save. Numeric and identity inputs are read-only in this mode. Hidden hallmark/image metadata may appear in a clearly named read-only detail view, with all distinct fields represented, but there is no editable image storage key or generic image editor until a saved-return image resolver is separately authorized.

The employee selector is company-scoped and sends an approved employee code once in the header. Its label must describe the resulting header-owned assignment; never emit one independent employee patch per row from a generic descriptor. If the API capability cannot safely synchronize the primary incoming/outgoing companion rows, the control remains read-only with the returned reason.

Use explicit accessible labels for the saved browse, voucher number, loaded context, HUID, Receive Item and employee. Include stable row-based test IDs keyed by saved identity, not visual index alone. Table horizontal scrolling must contain the grid without expanding the page. Preserve ordinary text selection and native focus; do not borrow unproven F1/Delete/Enter behavior from `TR_SALE` as evidence for this form.

## Asynchronous lifecycle and conflict behavior

Use a synchronous current-context reference and a monotonically increasing generation for every company/location/year/book or mode transition, including A→B→A. Comparing only a scope string is insufficient: an old response from the first A must not become current when the operator later returns to A. Increment generation on new record selection, Cancel/New, explicit reload and unmount. Track browse and document requests separately so a late list cannot overwrite a newer document selection.

Every browse/load/save/readback captures its exact scope, selection generation and operation ID before awaiting. Before dispatching a write and after every await, verify ownership. State, errors, saved results, print links and enabled controls are rendered only when the captured loaded identity belongs to the current generation. Scope changes immediately suppress old actions during render, before effects finish. A stale callback cannot clear or overwrite a new draft.

The metadata Save button is enabled only when a current observation has permitted dirty edits, no operation is running and no reload/conflict barrier is active. Disable the saved editor's mutation controls during its pending save. Keep raw observation, draft and a prepared immutable request distinct so later keystrokes cannot silently rebase a request already being sent.

On409, keep the entered draft visible, show the conflict, and require explicit reload/review before another save. Do not automatically replay the same metadata patch on a newer version. A reload that discards draft changes must say so explicitly in its action label or provide a retained comparison draft; do not silently lose the user's values.

After a successful mutation, hydrate its authoritative returned DTO under the captured identity, establish its new version/capabilities and clear only the edits confirmed committed. If the mutation succeeded but its returned observation cannot be validated, report that the save completed, lock repeat mutation and offer Reload. Do not resend the committed patch to compensate for a malformed response. An HTTP5xx or network error leaves the outcome uncertain and also requires Reload. A response from the old scope must never hydrate the new scope even if the write itself completed successfully.

No-action unchanged metadata saves should either be disabled in the UI or use the API's explicitly defined no-op semantics; they must never trigger numeric recalculation, voucher renumbering, table replacement, timestamp rounding or legacy default filling.

## Disposition of the current 33 exposed fields

| Fields | Saved-mode disposition | Why it remains bounded |
| --- | --- | --- |
| `huid`, `remark` | HUID and Receive Item draft controls only when the server grants the field capability; preserve raw text otherwise. | Source visible text commits and incoming writers are proven; companion tag propagation still needs exact target proof. |
| `ghtPct`, `discountPct` | Exact saved read-only values. | Source numeric cache/event ordering, MRP/manual total/tax effects are not implemented by a text metadata patch. |
| `employeeCode` | One permitted header selector; per-line saved values read-only. | Source header-owned stamp must be atomically consistent with every affected leg. |
| `designImageId`, `hallmarkId2/3/4`, `hallmarkIdWt/2Wt/3Wt/4Wt` | Preserve raw values, optionally show read-only details. | Hidden copied identities/weights; no freely editable source equivalent is established. |
| `isuNo/isuYrcd/isuDbcd` | Show separate saved header original reference. | They are not arbitrary incoming line fields. |
| `isuSrno`, `ordNo/ordYrcd/ordDbcd/ordSrno` | Unsupported/unproven incoming edits. | A different original/admitted instance or ordinary Sales order link must not be invented. |
| `lessWt` | Do not introduce a second write competing with `otherWt`. | Existing writer consumes `otherWt`; source labels its single cell OthWt. |
| `bagWt`, `karigarNetWt/karigarTouch/karigarWestPct/karigarFine`, `orderTagStockAdd` | Preserve any raw imported values outside this metadata map; no incoming edit. | Primary outgoing constants/caches or alternate source-only evidence. |
| `tagGrossWt/tagNetWt`, `itemLot`, `ghatAmount`, `rateWith` | Explicit unsupported mode fields; never silently map to another return field. | Ordinary-sale/source/tag modes or UAE semantics need a separate proven writer/schema contract. |

The new saved mode must not falsely relabel all descriptors as writer-verified. The legacy full-grid fields remain an open diagnostic until their own mode-specific disposition and end-to-end proof are implemented.

## Known existing import/create/print defects deferred to the next coordinated slice

These findings are preserved so the saved metadata slice cannot accidentally be advertised as a full repair of Sales Return:

1. Page258 sends import query `coBook=origBook`; route1114 reads `qs.book ?? 'SAL'`. A non-SAL original book therefore falls back to SAL. The current submit313–354 omits `origBook` entirely and sends one `billNo` as both current `BILL_NO` and `origVchNo`.
2. Page217 reads only `coYear`; create/import requests omit explicit company/location and separate original year/location. Current API source lookup599–629 uses the return year/location. A cookie/session scope change can make a retained draft refer to a different record.
3. Import250–281 has no operation/epoch guard and may replace a newer draft after scope or row changes. It reduces a source row to nine fields, changes `pcs=0` to1 through `||1`, changes numeric zeros to blank, and reverse-derives Making/g from labour amount/net. It drops child and hidden metadata.
4. Current page rows have positional React keys, no raw saved snapshot and no admitted/original identity separation. Dynamic serialization343–350 trims all text, omits clears and converts decimal drafts through Number; malformed input can become JSON null. The create row filter can omit a metadata-only row.
5. Save354 always POSTs and leaves the draft in create mode; another click creates another voucher. There is no authoritative saved reopen, no version and no page load-to-edit path. The API exports `editSaleReturn` but the route registry has no Sales Return PUT adapter.
6. Current preview284–305 ignores many entered manual amounts, MRP/rate basis/discount fields and source caches. The current writer uses outgoing-style header totals and `ENTRY_TYPE='R'`; primary incoming source uses its separate RTN_* totals and saved entry type P. This metadata slice must preserve those imported values, not normalize them.
7. Current result print599 and list print614 build links from the current selected book plus an older voucher number, with session scope implicit. Changing scope/book can associate the result with a different document. Saved-mode print, if supplied by root, must use validated loaded identity and permission.
8. Generic `VoucherList.remove` at54 sends no book/full scope/version; its list request depends only on table/book and Sale Return supplies no onLoad. Do not reuse its mutation path for the new saved editor.
9. The current BookSelect call370 has no `SALES RETURNE` filter. Many form/tender controls stay editable during save. Neither the current grid's generic keyboard comment citing TR_SALE nor its exposed hidden fields proves primary Sales Return operator equivalence.

## Required tests before this slice can be accepted

Helper tests must use independently constructed raw DTOs, not the serializer's own output as the sole expected value. Include SR17/42, OLD31/58, distinct admitted/original tag instances, exact numeric strings near the decimal width limit, microsecond timestamps, SQL NULL/empty/sentinel text, zero quantities, all seven extra hallmark values, image IDs and distinct child/unsupported rows. Prove unchanged hydration emits no metadata patches and HUID/description changes affect only their exact saved row. Test display description fallback separately from raw remark; clearing, reverting and unrelated edits must preserve raw NULL.

Capability tests cover view-only users, independently denied HUID/description/employee fields, mixed/unsupported record classes, invalid employee codes, revoked rights, forged hidden values and duplicate/unrecognized row identity. The browser must not enable a field whose capability is missing; server rejection must still preserve the draft and all database rows.

Lifecycle tests cover concurrent load A1/B/A2 with reversed completion order, overlapping browse/load, Cancel while loading, book and company/location/year changes during save/readback, stale409, successful mutation with failed readback and disabled duplicate submit. An old A callback must never become current after A→B→A.

Root's authenticated HTTP/database fixtures must prove exact full-business write-set preservation for unchanged and single-field metadata edits, including stock, ledgers, outstanding, tax, children, tag companion records, counters, hidden voucher IDs and timestamps. Do not exclude physical rows from comparison without a documented reason; metadata updates should not replace them. Two configured return books share a voucher, and two original years share another voucher with different bill labels. Include another tenant/company/location and a foreign-party source. Test companion drift/missing/ambiguous identity as refusal rather than guessing an update target.

The actual browser journey opens the existing Sales Return page's saved mode, selects a configured return book, browses/loads a saved imported record, inspects HUID/Receive Item/employee and read-only metadata, edits one allowed field, saves through the real API and reopens with unchanged identities/caches. It then exercises a second real client's stale edit, draft retention, explicit reload, and scope/book changes with old controls immediately suppressed. Capture full-grid and metadata screenshots, verify horizontal bounds, accessible focus and zero unhandled page errors. Root serializes DB/browser runs and owns whole-workspace verification.

Passing these tests closes only the demonstrated saved read/metadata contract. Original-source import, incoming numeric commit replay, generated tag identities/children, outgoing exchange, UAE mode, complete reversal and desktop/business acceptance remain separate requirements.

## Implemented UI verification

The final owned helper suite passes31 tests in `x13-saved-ui-tests-diagnostics.txt`; focused lint and web typecheck both exited0. Root's post-diagnostic `web-tests.txt` passes24 files168 tests, `build.txt` reports7 successful tasks, `lint.txt` reports10 successful lint/type tasks, and `test-types.txt` is the passing strict API test typecheck. These are scoped implementation checks, not a complete module/33-field parity percentage.

The rebuilt `test-results/parity-real-stack-round6-complete/result.json` reports13 passing real-stack journeys, including the saved Return journey's8 grouped assertions and15 requests with zero mocked responses. The Return journey proves configured browse/load, exact saved/raw/source identities, HUID-only PUT and authoritative reopen, unchanged complete database boundary, independent-client stale409 with retained draft, explicit discard/reload/revised save, same-number book isolation, tagged read-only containment, cancelled/A→B→A held-read suppression, explicit request scope and no unhandled browser errors. Five captured Return screens are recorded by the browser owner.

This rebuilt journey checks a known item fallback with no false missing-master warning. Missing/ambiguous master reasons and special saved-date containment additionally have API and helper proof; do not infer a positive missing-master browser fixture from the known-name journey. The earlier browser-first run passed its prior source stage and remains historical rather than being credited to the later diagnostic correction. The earlier TypeScript callback-narrowing failure is retained in `x13-saved-ui-types-guarded.txt`; the local-alias correction preserved runtime validation and the final check passed.

The independent source review and approved fixes are recorded separately in `x13-saved-ui-api-review.md` and `x13-saved-ui-review-followup.md`; the original finding was not rewritten after correction. The final scoped UI manifest pins these artifacts and the current source. Root independently owns final full-API results, before/after input hashes and checkpoint acceptance. No database or browser process was launched by the saved UI owner.

## Read-only source capture

Captured at 2026-09-11T07:37:20.190268+00:00. Paths are relative to the web workspace. These hashes identify the inspected pre-implementation snapshot; they do not claim later implementation verification. Root route/schema files may change in later authorized batches.

| Path | SHA-256 |
| --- | --- |
| `../unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `apps/web/app/(app)/txn/sale-return/page.tsx` | `4ef52449c4da2ab5f5b8bf2d12740aef605e086ff24f11b210272f089a963680` |
| `apps/api/src/modules/sales/salesReturn.ts` | `612ddcd8f3b0cb8f0368435495125c8b50ed2f8cd03adad11f1cef12cf1d2a70` |
| `apps/api/src/modules/sales/sales.ts` | `f9edc60fb957d5efc708bc321b1fd905ff186f1d87519728b874a8af79b62f12` |
| `apps/api/src/routes/txn.ts` | `0af1e071370d7e976ce2e4e7679d7c699bf5b4a7c92036bb294352d68a4fdb01` |
| `apps/api/src/modules/shared/bookPolicy.ts` | `e5a9a6c75f2c4ccb66f7c2504253876ca9b9b3687e5003de8bf4c9362c03ed74` |
| `apps/web/components/VoucherList.tsx` | `0a16f82d6b050e5f42f2e01b32c464458b0f14a97b83a26d5624733583ee2bb6` |
| `apps/web/components/ExtendedGrid.tsx` | `a886f629ca36d86bd3b35f845f742420515a470dfa99ae04697adf90bba16ba1` |
| `packages/db/prisma/schema.prisma` | `da810d40fecbe8c5ef631fc66e458d3bcfeb641c67521a6f29f6c6732b2248d2` |
