# Saved Return labour selection preview — next integration contract

Status: prospective integration only, 2026-09-12. This directory changes no product, test, plan or frozen evidence file. No API, DB, browser or compiler result is claimed here. The parent reports that the preceding pure composition passed its 53 focused cases; that is prerequisite evidence, not acceptance of these proposed routes or UI.

## 1. Smallest complete next slice

Add a **separate saved incoming labour-and-bill preview**. Within one selected saved row, it accepts an ordered history of the existing twelve money LeaveCell events plus resolved c13/LCode and c29/TgLCode Enter operations. Every accepted operation runs the existing source-ordered row → incoming aggregate → bill sequence; labour first performs the already implemented master copy. This remains a transient simulation. All saved raw rows/header/companions stay unchanged, `canSaveNumeric:false`, `canPreviewClosing:false`, and `canApplySource:false`.

Keep these old contracts, semantic profiles, four routes, allowlists, hashes and responses unchanged:

- `x13-saved-incoming-replay-v1` / `saved-primary-incoming-money-preview-v1`.
- `x13-saved-incoming-bill-replay-v1` / `saved-primary-incoming-bill-preview-v1`.
- GET/POST `incoming-replay-state` / `incoming-replay`, GET/POST `incoming-bill-replay-state` / `incoming-bill-replay` under `/sales-returns/:vchNo`.

Do not add c13/c29 to either existing parser. Proposed new names are `x13-saved-incoming-labour-bill-replay-v1` and `saved-primary-incoming-resolved-labour-bill-preview-v1`. These are transport/profile choices, not names found in the desktop.

Initial admission retains the current bill preview's complete saved five-digit positive voucher profile, all-row projection, ordinary primary incoming state, configured Return book, period/profile refusals, and no outgoing/tag/component/diamond state. Reuse its proved BAR_DATA exception only where the existing observation proves it. No source voucher/F1, new row, deletion, party/item change, direct cache/weight/touch change, new keyboard navigation, help-list selection, ledger mode selection, outgoing arithmetic admission, or numeric writer is introduced. For this bounded first adoption, require the existing bill observation's `canPreviewBill` as well as the new field capability; thus a document with every old money field hidden remains outside this first profile even if a labour field is visible. That is a rollout restriction, not an asserted desktop rule.

## 2. Source decisions that the adapter must preserve

All line references in this section refer to primary `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs`, pinned in `inputs.json`.

| Source | Consequence |
| --- | --- |
| 4137–4143, 4248–4319, 4322–4380 | These are Enter-key resolved-code operations. Plain LeaveCell at4620–4628 only copies text; it is a different event. Typing, focus, Tab and lookup do not commit the new operation. |
| 4250–4277 / 4324–4351 | Blank exits; absent code opens help and returns before copy/calculation. This profile refuses blank and reports lookup-required for absence; it does not implement or simulate that help dialog. |
| 4279–4292 | Changed c13 clears23,24,21,14,17,28. Same code does not clear. Assign13; fill29 only when its visible text is exactly empty, retaining a space-only or existing value. |
| 4293–4319 | Category prefix01→23,02→21,03→24,04→17,05→14,06→23 and22=`K`,07→28. Copy Format2 including zero. Always call row calculation after a resolved operation. |
| 4353–4380 | Changed c29 clears31,32,30,35. Prefix01/06→31,02→30,03→32,07→35. Prefix04/05 has no value destination but still calculates. Category06 here does not force22=`K`. |
| 4866–5158 | Preserve old comparison caches through copy. Row calculation can overwrite freshly copied values because its comparison cache changed. It then calls incoming fold, then bill. |
| 5162–5202 | Fourteen running totals format after each row in source SR order. UpDown suppresses only the fold. Server fixes UpDown=false in this saved preview; pure UpDown vectors are not a UI option. |
| 16381–16458 | Separate rounded legs, numeric OldNetAmt/OldTaxPrc comparison, manual-tax history, outstanding calculation then inactive-side clear. Replaying only the final row value loses prior bill tax changes. |
| 10353–10438; 10112–10169 | Saved projection/formatting seeds the eight known row caches and saved bill caches. Raw values remain separate. Display row0 is ordinal, not saved SR. No row calculation occurs merely because the row is hydrated. |
| 4508–4512; MS_UPDATE.cs31583; schema.prisma LBR_MAST | Editor MaxLength4 is separate from current master varchar2. This preview deliberately accepts only the existing code1–2 ASCII profile; no DDL widening. |

Use the integrated copy and composition unchanged. The composition's `visiblePatch` is the **pre-calculation** copy, not the final row or a write payload. Do not render it as the authoritative result. Publish only its completed state after editor/result validation.

The exact-decimal mathematical profile remains qualified: current PostgreSQL text, local Decimal precision and established rounding; no measured Windows Double/Format/culture/SQL Server collation equivalence. NULL/unknown category/value and discovered aliases remain refused. c29 category04/05 still requires a qualified numeric master value under the existing conservative copy profile even though the desktop assigns no tag amount for those categories.

## 3. Current files and required additions

Paths below are relative to `web/` unless marked otherwise. Exact source hashes are read-review pins, not a final workspace capture.

| Current seam | Bounded next work |
| --- | --- |
| `apps/api/src/modules/sales/saleReturnIncomingReplay.ts:265–425` | Existing exported `observeSaleReturnIncomingReplayTx` supplies saved/config/master observation, numeric SQL row order, pre-projection callback and server row states. Keep its public v1 DTO/hash unchanged. |
| `apps/api/src/modules/sales/saleReturnBillReplay.ts:324–465` | Its `observe` is private. Expose an internal Tx observation helper with DTO, aggregate state, trusted context and an optional before-projection callback. Preserve the no-option old behavior byte-for-byte at the DTO/hash boundary. Do not call the public wrapper inside another transaction. |
| `apps/api/src/modules/sales/saleReturnIncomingLabour.ts:118+` | Reuse `readSaleReturnIncomingLabourTx` for every distinct entered code in a tenant-bound RR transaction. This is not a public endpoint or a capability issuer today. |
| `packages/core/src/saleReturnIncomingLabourCompose.ts` | Reuse `composeSaleReturnIncomingLabour` once per accepted labour event. No old core/money changes. |
| `apps/api/src/modules/auth/sessionContextAccess.ts` | Current validation is a separate request-admission transaction, not a lock covering preview work. |
| `apps/api/src/modules/auth/sessionContextCommand.ts:265+` | Current financial command helper explicitly requires ReadCommitted. It cannot be used unchanged for the labour reader, which requires RR/Serializable. |
| `apps/api/src/routes/txn.ts:1230–1294`, `modules/rbac/routePolicy.ts:205–221,824+` | Add only the three new exact routes below, canonical Sales/Sales Return ownership and POST-as-read mapping. Retain central and local View checks. |
| `apps/web/lib/salesReturnBillReplay.ts`, `components/SaleReturnBillReplayPanel.tsx` | Reference old phase/strict-response behavior. Add separate labour helper/panel, rather than interpreting a new DTO through the old reader. |
| `apps/web/components/SaleReturnSavedPanel.tsx:165–193,648–666`; preview ownership class in `lib/salesReturnBillReplay.ts` | Extend exclusive ownership to a third `labour` claim with synchronous boolean acknowledgment; preserve row/bill semantics and existing tests. |
| `apps/web/lib/api.ts`, `pageContext.ts`, `components/useOperationLease.ts` | Use existing page tickets, stale/selection-pause behavior and operation leases. No direct fetch or descriptor adoption from an arbitrary preview response. |

Suggested new API module: `saleReturnLabourReplay.ts`. Suggested new browser files: `lib/salesReturnLabourReplay.ts`, `components/SaleReturnLabourReplayPanel.tsx`. Suggested read authority helper: `modules/auth/sessionContextReadSnapshot.ts`. Names are proposed, not existing exports.

## 4. One RR observation bound to the authenticated session

The new GET, lookup and append endpoints require both canonical `x-session-context-id` and `x-session-context-epoch` headers, agreeing with the retained authenticated request identity. Missing/partial pairs refuse with409 `context-stale` in this new profile. Existing routes retain their bootstrap compatibility. The request body never supplies tenant, login company, principal, role, mode or session authority. The explicit query is exactly coCode/lcCode/coYear/coBook, all four unpadded strings, matching the retained session scope; voucherNo stays the existing exact positive five-digit key. Do not fall back to another year/book/row.

Implement a **separate read-preview RR coordinator**, not a change to the financial command helper:

1. Strictly detach the retained server identity and fixed policy before awaiting. The policy is server-owned Sales/Sales Return/read plus full target scope. Require complete year. Keep immutable credential-owner loginCoCode distinct from selected company and freshly resolved principal owner.
2. Start one `withTenant(...,{isolationLevel:'RepeatableRead'})`. Its tenant setup may already establish a snapshot. Assert exact tenant/isolation. The first application row lock is exactly this tenant/session's `auth_session FOR SHARE`; acquire no business/config/advisory/LOGIN_MAST lock first.
3. Compare immutable subject and full current scope/epoch to retained identity. Validate canonical unknown ledger envelope. Query live expiry with `clock_timestamp()` in a separate statement **after** the lock wait. A snapshot/row-lock serialization conflict is409 `preview-snapshot-conflict`; do not silently retry with new scope or substitute a new base token.
4. Read fresh principal through `loadPrincipalTx`, validate exact stored scope through `validateStoredScopeTx`, refuse forced reset, and authorize the fixed form/read through `authorizeFormTx`, all in this RR snapshot. Do not lock LOGIN_MAST: password reset already locks LOGIN_MAST then session, so reversing that order risks deadlock. These nonlocking principal/form reads establish as-of-snapshot authorization, not a universal lock on all rights writers.
5. Read the complete saved document, effective configuration, item masters, bill tax/settings/account labels and all relevant labour candidates in the same Tx. Build/check versions before numeric projection or any candidate calculation. No parallel independent transaction/wrapper reads. No company clone, generic master CRUD, write or audit call inside this work callback.
6. Before returning, recheck full session identity/scope/epoch/ledger equality and revoked/expiry using SQL `clock_timestamp()`. Keep the SHARE lock until commit. A final expiry/refusal discards the proposed result. Do not touch/rotate session JTI, receipt, epoch, expiry or ledger. Do not extend this read helper into a financial authority claim.

Selection/refresh/revoke acquiring an UPDATE lock first may cause this RR locking read to abort rather than see the newly committed row;409/manual retry is acceptable and must be tested. When this preview acquires SHARE first, those operations wait until its completion. No auth row write or SHARE→UPDATE upgrade is allowed. A successful response is valid for the admitted snapshot and its final live check; a session can change immediately after commit and before browser delivery. The browser ticket and later request version checks handle that boundary. Do not claim cancellation of arbitrary in-flight business writers.

Do not set the PostgreSQL transaction READ ONLY flag while using row locks; this is an application read-only operation with explicit no-business-DML proof. Row-lock internals such as xmax are not persisted business edits; compare raw/xmin/ctid plus schema/state, not an assertion that PostgreSQL never touches any tuple header. Preserve the app's intentional onResponse POST audit. Assert those audit rows separately, including rejected authenticated POSTs; never exempt business/session/config mutations under an audit allowance.

No known ledger mode is inferred from the unknown session object. Keep the existing opening reason `Customer balance requires a resolved ledger mode.`, null closing amount/label and false closing/save capabilities. Pure mode/clock and internal account-balance readers do not yet provide this preview's authenticated vendor/caller authority.

## 5. Separate version and dependency model

Use lowercase64hex SHA256 for opaque versions and the existing opaque row identity. Versions are observation digests, not bearer authorization. Hash deterministic compact JSON with ordinal lexical sorted object keys; preserve array order and exact raw strings/NULL/owned-key distinctions. Do not change old hash implementations to match this new canonicalization.

`baseVersion = H({newContract,newProfile,semanticVersions,scope,voucherNo,sessionBinding,billReplayVersion})`.

- `sessionBinding` contains trusted tenant/session/subject/immutable login company/current co/lc/year/epoch and the exact unknown-ledger envelope. The public descriptor contains only sessionId/contextEpoch/coCode/lcCode/coYear.
- Do not include refresh JTI, auth_session xmin/ctid or receipt fields: refresh that preserves context should not invalidate a calculation base. Expiry is checked live per operation, not used as a fabricated clock value in arithmetic.
- `billReplayVersion` binds the existing document/config/item master and bill setting/tax/account observations; the new semanticVersions explicitly add the row, header, aggregate, labour observation/copy/composition and read-admission versions. Fresh View checks run even when a digest matches. Use exact semanticVersions keys `{adapter,rowProjection,billProjection,aggregate,taxPolicy,labourObservation,labourCopy,labourCompose,sessionRead}`. The existing exports supply every value except proposed adapter=`saved-labour-bill-server-adapter-v1` and sessionRead=`session-read-repeatable-snapshot-v1`. The adapter version covers the frozen row-kernel/money semantics, which have no independent exported runtime version; do not invent an existing row-kernel export. Change the adapter version for any future semantic dependency change.
- Read and bind each complete labour observation by exact enteredCode. Never replace it with only LBR_VAL/category, first row, generic-master page cache, or a token observed in another snapshot. Include the existing observation's full raw fields and xmin/ctid internally through observationVersion. Never put client-supplied raw masters into core input.

`prefixVersion = H({baseVersion,rowIdentity,events,dependencies})`, where `events` is the exact ordered accepted input journal and `dependencies` is the sorted distinct set `{enteredCode,observationVersion}` used by its labour events. Money events remain in order even if text/value repeats. If the same code appears twice its versions must agree with the one current observation; do not erase one occurrence. Initial empty prefix digests are generated by the server per row. The prefix digest does not include a guessed current master for a stored baseline code: saved hydration uses stored values, and no master copy happens until an explicit resolved event.

On **both lookup and append**, re-observe every prior labour dependency, compare every expected version, check baseVersion and reconstruct the entire prior prefix from trusted saved loaded/opened state. Verify its prefixVersion. Reject changed prior master before offering a new observation or a replacement prefix. Rebuilding accepted history under changed settings/master would silently rebase the user's preview. Never do it.

Compare base/master/prefix dependencies before projection/calculation where possible using the bill observer's new internal before-projection hook. The hook must be invoked after bill additional inputs/version are assembled and before saved numeric projection. Projection-time capability checks still occur before applying events. A malformed current header must not turn a detectable stale base into a successful replacement observation.

Physical master versions detect extant-row changes and delete/recreation. An absent→insert→delete cycle that restores the same empty observation has the same hash; clone/restore and universal history sensitivity are not proven. Same RR means one as-of-snapshot observation, not latest-at-response. Unrelated-company or unrelated-code changes should not invalidate the prefix; a discovered relevant case/ASCII-space alias must invalidate/refuse it.

## 6. Exact proposed public protocol

All responses use `Cache-Control: no-store`. The new three routes are:

```
GET  /sales-returns/:vchNo/incoming-labour-replay-state
POST /sales-returns/:vchNo/incoming-labour-observation
POST /sales-returns/:vchNo/incoming-labour-replay
```

The two POSTs are reads in routePolicy and local guard; View-only users can simulate eligible data, and lack of Update cannot fabricate permission to save. Preserve central forced-reset and scope checks, then repeat fresh read admission in the RR coordinator. No legacy Return writer is called.

Use these exact logical types (the implementation may give them longer exported names):

```ts
type Context = { sessionId:string; contextEpoch:string; coCode:string; lcCode:string; coYear:string };
type MoneyField = 'x13.primary-incoming.c19'|'x13.primary-incoming.c20'|
  'x13.primary-incoming.c21'|'x13.primary-incoming.c23'|'x13.primary-incoming.c24'|
  'x13.primary-incoming.c25'|'x13.primary-incoming.c26'|'x13.primary-incoming.c27'|
  'x13.primary-incoming.c28'|'x13.primary-incoming.c36'|'x13.primary-incoming.c37'|
  'x13.primary-incoming.c38';
type LabourField = 'x13.primary-incoming.c13'|'x13.primary-incoming.c29';
type Event = {kind:'moneyLeave';fieldId:MoneyField;editorText:string} |
 {kind:'labourEnter';fieldId:LabourField;editorText:string;observationVersion:string};
type PrefixInput = {baseVersion:string;rowIdentity:string;prefixVersion:string;events:Event[]};
type ObserveInput = PrefixInput & {fieldId:LabourField;editorText:string};
type AppendInput = PrefixInput & {event:Event};
```

Reject extra/missing keys, coercions, duplicate query keys, foreign fields, unsupported kinds, non-JSON input, getters at internal pure boundaries, sparse arrays and malformed hashes. No undefined→NULL/default conversion. Max100 accepted events; append refuses when prior length100. Set each new POST body limit to65,536 UTF-8 bytes (413 above it), and reject a new public DTO above2,097,152 UTF-8 JSON bytes before publishing (422 unsupported-output). Do not truncate raw data/journals to fit. These are new transport bounds, not desktop rules; the old composition additionally retains its own bounded plain-data limits. Money editor text retains the current at-most10 printable ASCII character and core decimal profile. Labour text is exact nonblank unpadded printable ASCII length1–2. A loaded longer code remains readable and untruncated, but only a valid explicit replacement can be committed in this profile. Do not transform code case or apply numeric formatting.

Common response identity is `{contractVersion,profile,context,scope,voucherNo,baseVersion,documentVersion,configurationVersion}` with scope coCode/lcCode/coYear/coBook. Exact context and scope must match both the retained page and selected saved document. The following fields are additional:

**GET:** `{billReplay,semanticVersions,rows,capabilities}`. `billReplay` is the unchanged embedded existing bill state DTO including its unchanged embedded row replay, saved raw header, diagnostics, tax policy and loaded/opened phases. `rows` contains `{rowIdentity,initialPrefixVersion,labourFields:[{fieldId,allowed,reason,maxLength:2,commit:'resolved-enter'}]}` for every existing row; it does not silently drop unsupported rows. `capabilities={canPreview:boolean,canPreviewClosing:false,canSaveNumeric:false,canApplySource:false}`. A valid empty saved header returns rows[] and canPreview=false. Capability for each labour field requires eligible whole-grid bill state plus that exact configured column's nonzero resolved width; unresolved/hidden columns are refused, a conservative initial profile condition. Captions come from embedded configuration c13/c29, never invented DOM width/labels.

**Lookup:** on success add `{rowIdentity,prefixVersion,fieldId,editorText,observationVersion,selection}`. `selection` is the exact four raw string cells `{CO_CODE,LBR_CODE,LBR_CATG,LBR_VAL}` from the unique qualified master. Store complete raw/physical observation only server-side for hashing/replay. This response only confirms a candidate against the specified prefix. It has no new prefix, journal append, copied state, total or save capability. Validate qualification through the existing copy boundary on a private selected-row snapshot, discarding its copy result; do not invoke row/fold/bill for the candidate. Reconstructing already accepted prior events is expected. A same-code candidate still needs explicit subsequent commitment.

**Append:** add `{rowIdentity,prefix,acceptedEvent,effects,capabilities}`. `prefix={prefixVersion,events,preview,phase}`; preview is the existing strict selected-row snapshot (63 visible,8 caches,12 money editor texts), phase is the full71 incoming totals plus existing exact bill state/9×6 matrix/caches/unavailable closing. Codes for the new editor come directly from preview.visible['13'/'29'], separately from money editorTextByField. `events` is the old accepted journal plus exactly the one candidate. `acceptedEvent={event,status:'applied'|'skipped'}` and `effects={aggregateApplied,billApplied,taxRecalculated}` are server derived. Labour success always reports applied and billApplied=true. Capabilities retain all three false authority flags. Never send a partially copied row as preview or expose a core raw state as a future save DTO.

This append protocol deliberately submits the complete old history and one candidate separately. It is stateless with no server journal storage or operation receipt. `prefixVersion` protects correspondence; it is not a write idempotency key. Repeating the exact whole request after uncertain network delivery produces the same mathematical preview when its dependencies still match, with the existing request audit repeated. It must not append the candidate twice in the browser journal.

## 7. Server replay sequence and failure boundaries

1. Parse/detach transport, admit the read snapshot, read all observations and compare base and historical dependency versions. Validate exact opaque selected identity in full SQL numeric SR order. Never substitute array index, formatted hidden51/56, client ordinal or Number-converted SR.
2. Use existing saved projection and header loaded state. Create opened state exactly as current bill observer: incoming fold once, no per-row recalculation on hydrate; outgoing0.00 only because the existing profile proved no outgoing grid; bill opening callback with editOpen=false/upDown=false and unavailable opening. Do not use saved NET_AMT as outgoing total.
3. Rebuild each old event in order. For money, use the current configured width and server ordinal in the existing aggregate reducer. For labour, use the same-snapshot master observation and trusted configuration/context in `composeSaleReturnIncomingLabour`. Revalidate editor/output projection before accepting the transient step. Compare requested prefix digest and reconstructed dependency set. No history deduplication or cache reseeding.
4. Lookup now qualifies its candidate and returns the observation only. Append checks the candidate's field capability and observation version, retains the **entire previous prefix**, then runs either the existing money aggregate event or pure labour composition once. Candidate c13/c29 never uses plain leaveCell; the composition produces its source calculateAfterCopy event itself.
5. If any candidate copy/row/fold/bill/editor/output-bound check fails, retain all original rows/raw/caches/totals/counters/bill/closing and both journals from the accepted prefix. The old reducer alone can return its copied input on failure; rely on the new composition's pre-copy rollback and still validate the final public serialization before publication.
6. Return only after final live/context check and successful transaction completion. A same-code resolved Enter and tag04/05 no-destination operation still append one event and execute callbacks. Do not call bill only once after replaying all row events.

Error envelope: `{error,message,details?}`. Error codes are new-profile choices except preserved auth/ScopeError mapping; do not swallow unknown infrastructure errors into unsupported business state.

| Status/code | Recovery |
| --- | --- |
| 400 invalid-replay-request | Retain browser draft/prefix; no arithmetic acceptance. |
| 401 session-invalid/revoked/expired; 403 forbidden/password-reset-required | Existing auth semantics; freeze preview until explicit reload/auth recovery. No calculation recovery supplied as fresh authority. |
| 404 not-found (preserve existing SavedSaleReturnError code) | Preserve local draft, require reload. Do not invent an empty document. |
| 409 context-stale / preview-snapshot-conflict | Preserve draft and accepted display, require explicit context/data reload; no returned replacement prefix. |
| 409 version-conflict / master-version-conflict / identity-conflict / prefix-conflict | No automatic rebase or new observation. Prior displayed prefix is retained locally but marked stale. |
| 422 unsupported-state / unsupported-field | Clear diagnostic with field where applicable; preserve raw inspection. |
| 422 lookup-required / unsupported-master | Missing/ambiguous/category/value/code profile refusal; no journal/patch. Exact entered text stays visible for correction. |
| 422 calculation-rejected / unsupported-editor / unsupported-output | Candidate refusal includes `details:{eventIndex,event,diagnostics,recovery}` where eventIndex equals old events.length and recovery is the fully reconstructed old `{prefixVersion,events,preview,phase}`. No candidate appears in recovery.events. |

If an old historical event itself fails despite matching dependencies, this is a semantic/profile consistency error: stop with409 prefix-conflict (or explicit internal error), no shortened-prefix success. Do not silently bless a truncated old journal. Candidate recovery must compare exactly to a separate successful request for the old prefix. A malformed/stale request is not entitled to trusted recovery values.

## 8. Browser behavior and accessible controls

Add a third mutually exclusive preview panel owned by the saved document. Claim ownership synchronously before opening/busy/GET; a rejected claim starts no request. Capture document identity/version/scope, page context ticket and operation generation. After every await (lookup and append), before catch/finally changes, focus or navigation, require all to remain current. Closing, unmount, StrictMode cleanup, another selected saved row/document, scope change or selection pause invalidates outstanding work. Preserve existing metadata draft protection and old panels' claim/release semantics.

Offer the existing money fields and two labelled code fields from configuration. A code draft is separate from committed journal and pending qualified observation. Button text may be `Check labour code` then `Preview selection`; Enter may execute the explicit check→append sequence, but it must never dispatch two commits from button+keypress. Do not append on lookup, blur, Tab or merely selecting a field. Same-code Enter appends exactly once. Unknown code reports that exact-code selection is unavailable; this profile has no help-list browser yet.

A lookup result is valid only for the captured document/base, selected row, old prefixVersion, exact fieldId and exact code draft. Editing the draft invalidates its candidate, even if an older network response later arrives. Changing money/labour history invalidates any pending candidate. The append response must match the exact old request journal plus candidate, all version/context/scope identities, embedded semantic versions and false authority flags. Never trust a response solely because its HTTP status is200. Reject a mismatch without erasing draft or accepted prefix.

Freeze row choice after an accepted event or unresolved changed editor text, matching the old single-row flow. The user can explicitly discard/reopen to choose another row; do not rebase history onto a different saved identity. On failure preserve code/money draft, last accepted row and bill, and error diagnostics. A matching validated422 recovery may confirm that same prefix; it must not replace it with a shorter or changed one. Network uncertainty permits explicit retry of the identical pending request while dependencies remain current; no local arithmetic, refresh-cookie logic or persisted financial operation ID is added.

Use api.ts for page headers and late-result gating. Require a ready page descriptor before opening. On a context-stale or selection-unconfirmed page, show the existing recovery direction, keep unsaved work available to copy, and block lookup/append before network. The preview must not call pinPageContext/resetForNavigation to make an old draft fit a new response. A refreshed access cookie with the same descriptor may complete under existing API behavior; a different descriptor must never retry the old body automatically.

Present saved raw, on-opening and after-N-commits values distinctly. Always render code strings as text and raw NULL/blank separately in saved inspection. Retain accessible labelled editors, keyboard Enter, busy status, field-specific role=alert, focus restoration only for the current operation, and explicit discard/reload. Show that no saved amounts/payments change and closing remains unavailable. No save/apply button, local aggregate calculation, optimistic copy patch or hidden writer submission.

## 9. Independent acceptance plan

The adjacent `http-ui-independent-candidates.json` contains prospective literal results and behavioral schedules, authored without executing a new service or reducer. It pins the earlier independent24 copy cases and23 full-state composition cases; keep those bytes unchanged. Their synthetic outgoing, arbitrary cache text/history, UpDown and malformed sibling states prove pure boundaries only. Do not force them through DB fixtures by weakening normal saved admission.

For a real API fixture, independently seed a canonical saved projection: net10,metal100,labour rate1/amount10,total/net110, ordinary N labour basis, zero discounts/item tax/other/tag arithmetic, header incoming110,bill tax10%,manual tax7, no outgoing, qualified configuration. Saved header projection seeds canonical caches; do not transplant the pure fixture's synthetic `110.0000` cache string into a supposedly loaded HTTP state. The opened payment is117; BB/category01/value2 yields120/12/132; then AA/category01/value1 yields110/11/121. Complete saved rows/headers must be seeded using the existing projection's actual required columns, not test-only server states. Independent expected matrices and prefix rows should be frozen before writing new service code/tests; do not generate expectations by invoking the implementation.

Run real owner-setup/app_user tests for same-snapshot aliases/ABA/expiry/locks and actual authenticated mounted routes. Compare all original Return raw+physical tables, relevant settings/master tables and auth_session before/after; compare intentional audit rows separately. Include foreign scope sentinels and noncontiguous SR identities. Verify new endpoints use fresh read rights and no numeric-write permissions, precise status mappings and no new legacy-writer call. Root owns DB/compiler/build serialization and final snapshots.

Browser acceptance requires real HTTP, actual cookies/page context and mounted panel, independently checked server/DB observations. Hold real lookup/replay responses to prove late close/unmount/document/scope handling, same-session A→B→A and same-scope epoch changes, retained code draft, no double commit, and exact matching prefix after retry. Keep every old v1 row/bill browser assertion and endpoint response contract intact. Pure unit tests do not replace these runtime checks.

## 10. Explicit remaining prerequisites and boundaries

Required before adoption: implement and review the separate RR session read-admission helper; expose a behavior-preserving internal bill observer hook; implement strict three-route transport/version reconstruction; build the third panel and ownership extension; freeze independent reachable full HTTP expected matrices; then run focused and old-profile regression plus real browser/unchanged-business snapshots. None exists merely because the pure composer is available.

Not required for this slice and still open: authenticated vendor edition/mode initialization and command integration; trusted caller opening-balance/clock lifecycle; complete original-source/F1 item/party/tag/consumption/children admission; blank/help/cancel and wider code/collation profiles; outgoing/UAE branches; all numeric/stock/accounting writes and reversals; runtime Windows equivalence and original X13 acceptance. Session-bound preview is not completion of transaction-bound session protection for every writer. No progress percentage or full-financial-parity claim follows from this contract.
