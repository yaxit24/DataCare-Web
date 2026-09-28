# X13 next server replay and admission contract — prospective Round9

**Recommendation:** implement a trusted saved-row projection plus a read-only, ordered server replay preview. Begin with twelve amount/labour/discount/tax LeaveCell fields on one eligible saved incoming row. The server reads the baseline and effective configuration itself. All numeric save/apply/stock/financial capabilities remain false. This is a useful integration of the existing independent row kernel and configuration resolver; it is not original-sale admission, a replacement Return writer, or completion of X13.

This new prospective note changes no production code, tests, prior evidence or acceptance criteria. Round8 final global checks were still running when it was authored; no future check or business outcome is credited here. Root must explicitly finish checkpoint29 before starting product work. The companion `x13-replay-validation-matrix.md` and `x13-replay-ui-contract.md` are separately owned prospective notes and should be reconciled with this contract before implementation.

## 1. Why this is the smallest useful next slice

The plan's X13 remains open until source picks, two-sided exchange, component ownership, refunds/credits, reversals, reporting and actual business workflows agree. Round6 implemented an exact saved reader and bounded text metadata edits. Round7 provided a pure row calculator and read-only original-sale candidates. Round8 provided authoritative effective settings/widths and repaired generic column identity. None is a numeric write contract.

Three missing prerequisites can now be addressed together without calling the legacy writer:

1. Project the saved `SL_DETL_RTN` row into the desktop's **loaded visible strings**, preserving raw saved values separately, then seed exactly its eight comparison caches.
2. Read that document, relevant projection masters and effective settings inside one database snapshot, bind them to one composite observation, and re-resolve them on every preview request.
3. Admit only a bounded source-known committed-cell journal to the frozen reducer and return its transient row result. Explicitly stop before the source aggregate callbacks.

Do not add numeric columns to the existing metadata PUT, call `editSaleReturn`, wrap `createSaleReturn` in a dry-run that still allocates sequences, or return a proposed SQL write-set as though it were a complete invoice. The current `salesReturn.ts` writer uses generic Sales `computeLine`/`billTotals`, Number-valued input, current-year original identity and legacy tag rules; its destructive edit deletes/reposts a narrower write set. The new source-specific preview must be independent.

## 2. Primary source locations and the exact boundary

All locations below refer to `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` unless named otherwise.

| Source operation | Location | Consequence for this slice |
| --- | --- | --- |
| Clear incoming grid / initialize new row | 3565–3780 / 3782–3801 | A saved projection starts from cleared slots; new defaults and generated instance40 are a separate admission workflow. |
| Saved incoming query and projection | 10353–10438 | Read complete saved parents, retain identity independently, format loaded cells before creating saved caches. |
| Saved load finishes | 10440–10447 | Calls `MSG_PR_TOT_FILL`; it does not run `CommPassTotal_Pr` per loaded row. Empty replay must not recalculate. |
| EnterCell input presentation and restrictions | 4456–4590 | Hidden navigation and input length/read-only rules are separate from simple LeaveCell switch membership. |
| Committed-cell trigger | 4592–4664 | Numeric commits format then calculate even when numerically unchanged; text commits do not calculate. Item1 can generate a new tag. |
| Row calculations | 4866–5156 | Existing kernel owns ordered row operations only. |
| Aggregate boundary | 5157–5158, 5162–5208, 16381–16476 | Row callbacks retotal all incoming rows and exchange/tender/header state. Preview must report `aggregateRequired`, not fabricate those results. |
| Original-sale single-item F1 | 3880–4026 | Source resolution/copies/child rebinding precede a calculation; this is not an ordinary cell event. |
| LCode / TgLCode Enter | 4248–4381 | Reads `LBR_MAST`, clears/copies conditional fields, then calculates. Neither code is a free client-supplied trusted source action. |
| Gross Enter | 4383–4397 | Validates zero gross, calculates, hides editor and opens incoming child grid. Do not simulate it as a second ordinary blur. |
| Last-row Karigar Enter | 4398–4416 | Can reserve `TAG_SET` and append a row. Not preview-only. |
| Incoming numeric persistence | 14264–14584 | Separate persisted field, identity, date/time, flags and user mappings; row calculation alone does not prove the writer. |
| BAR and child persistence | 13080–13179, 13719–13786 | Companion header/parent/child ownership must be addressed before numeric persistence. |
| Original whole import | 16521–16701 | Different copy/caches/tax/identity behavior from F1; it cannot reuse a post-copy calculator vector as full acceptance. |

The original EXE IL pinned in Round7 establishes actual `get_ColWidth` for both LeaveCell active-column gating and Fine basis. Never use CSS width, a nonzero Fine value, a renamed caption, or a client visibility flag as authority.

## 3. Initial supported record profile

Give the first rollout a named version, for example `saved-primary-incoming-money-preview-v1`. These are conservative web rollout restrictions, not newly invented desktop business rules:

- An exact five-digit saved voucher key in the complete authenticated tenant/company/location/year/configured Return book. Use the selected saved key unchanged. Explicitly refuse other shapes in this first slice. Current `savedSaleReturn.scopeKey` calls shared `formatVoucherNo`, which rejects numbers above99999 and canonicalizes shorter input; it does **not** already provide the source-reader's exact1–8-digit collision handling. Do not silently normalize coexisting keys or change shared numbering here.
- Exactly one `SL_DATA` header and an unambiguous selected incoming row. Primary incoming `ENTRY_TYPE='P'`, `INOUT_TYPE='I'`; source14303 writes P, while direction comes from the configured book. Preserve imported R/other modes as readable unsupported state.
- First preview is restricted to ordinary untagged incoming rows (`TAG_NO='N'` or exact empty text), no approval/employee issue state, no outgoing `SL_DETL`/`SL_IDTL`, no BAR parents/components or DM companions. Multiple ordinary incoming rows may remain in the saved document, but one request previews exactly one row. A plain BAR header may be retained only under the existing proven unambiguous source-header shape; otherwise deny preview. Other persisted stock/finance rows remain observed and unchanged.
- Require the existing saved document/period edit-eligibility check for this initial conservative profile. Closed/invalid saved dates or saved USER_UPDATE denial remain readable but do not enable preview. This is not a fiscal exception or proof that the desktop disallows every possible read simulation. View-only users may simulate eligible records; they gain no save right.
- Missing/duplicate item master or unresolved type-binding/formatting state yields an explicit unsupported-preview diagnostic. Do not collapse duplicate masters even when display names match. No source-candidate `canSelect` or metadata `canUpdate` flag alone proves this profile.

These restrictions avoid falsely presenting a row simulation as a complete tagged/component/exchange adjustment. They do not prove stock availability even for an untagged row. Expanding the profile requires new explicit source/effect tests, not changing these checks merely to make more imported rows pass.

## 4. Trusted saved raw-to-visible projection

Add a dedicated pure projection helper with a fixed mapping, separate from the constructor. It takes server-observed raw parent, exact item-master observations and deterministic display ordinal; it must not accept a client-built cell map. Preserve full SQL text/null raw data and original microsecond timestamps independently of every display value.

| Slots | Saved-load mapping and rule |
| --- | --- |
| 0 | Display ordinal `i+1` at10359, **not saved SR_NO**. Never use it as row identity. |
| 1,2,4–8,13,22,39 | IT_CODE, TAG_NO, TBL_CODE, DESIGN_NO, ITM_STYLE, ITM_SIZE, HM_ID, LBR_CODE, LBR_TYPE, KR_NAME text. No global trim/default normalizer. |
| 3 | Nonempty saved ITM_REMARK, otherwise item-name display fallback10362–10368. Never overwrite raw ITM_REMARK with the fallback. |
| 9 | `Conversions.ToString(ITM_PCS)`10376, not integer Format. A fractional saved piece value must not become an integer on load. The actual c09 leave rounds0, but c09 is outside this first journal. |
| 10,11,12,15,18 | Loaded three-decimal strings from ITM_GWT, ITM_OTH_WT, ITM_NWT, ITM_GHT_WT, ITM_FINE. |
| 14,16,17,19–21,23–28,30–38 | Loaded two-decimal strings using the explicit source field map: ghat%, touch, west%, item rate/amount, labour%, labour rate/amount, discount%/amount, other, Return MRP, tag%, tag rate/amount/other/cost/MRP, total, tax%, net. Raw 3/4-decimal persisted values remain untouched. |
| 29 | Saved TAG_LBR_CODE; blank falls back to LBR_CODE only in the projected cell10400–10403. Keep raw blank/NULL distinct. |
| 40,43,44,50–57,59–70 | Preserve source-defined hidden identity, flags, product/tag/image/hallmark data; map by the saved source, not outgoing-grid slot meanings. 51/56 load with integer Format; 52 and53 both receive saved PR_CODE,54/55 saved TAG_TYPE;57 is E. Hallmark weights62–65 load three decimals. |
| 41/42 | Cleared and not populated by the saved incoming loop; neither is read by primary row calculator4866–5159. Do not invent a hidden labour-amount or net cache in these slots. |
| 45,46,47,48,49,58,66,67 | Only eight comparison caches: copy the **already projected** cells10,12,16,17,19,23,21,37 respectively. |

Use the frozen core's local exact-decimal primitives/profile, never JS Number/parseFloat or global Decimal precision changes. Source `Strings.Format`/Double/DBNull/culture behavior remains unmeasured for some inputs. Initially contain unsupported numeric NULL, malformed/nonfinite values, excess precision or an unproved formatting case with a field-specific diagnostic; retain the raw read and do not guess zero. A declared decimal display profile is not executable-binary parity. Blank editor text may follow the existing core's explicit blank-as-zero mathematical policy; raw SQL NULL is not automatically that editor event.

The source query10353 is `SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE`. A already has persisted RATE_TYPE and IT_TYPE (primary schema `01_Schema.sql`:591 and current Prisma `SL_DETL_RTN`). Source accesses the unsuffixed names10421–10424. `DC_Main.OpenRecordSetDc`:1232–1239 uses DataAdapter.Fill; duplicate-name binding has not been executed here. **Do not assume current master B overwrites persisted A.** Until that binding is established, admit only an unambiguous master whose relevant type values agree exactly with the saved row; disagreement/NULL ambiguity must remain unsupported. Add explicit SQL aliases in the web observation so no driver duplicate-property overwrite can decide this implicitly. A later source-backed resolution may remove only this specific limitation.

Source EnterCell separately formats the twelve numeric editors to two decimals (4538–4541 and4561–4575). After a manual total, visible labour percentage can be three decimals at5115. Opening that editor must therefore use its two-decimal editor presentation while leaving the visible cell, raw and caches unchanged. Return server-derived `editorTextByField` for the baseline and every preview; focus must not itself commit or calculate. Keep the subsequent original edited text separate from the already formatted visible cell for manual-total comparisons.

Creating a state with `cacheMode:'saved'` is allowed only after this projection. It does not call the reducer. Keep the eight caches separate across events; do not reseed them from visible cells after each calculation. Do not fill saved LBR_TYPE from `newRowDefaults`.

## 5. Proposed public API and exact journal

Names below are prospective and must be agreed with root before routing. Use fresh owning `Sales/Sales Return` **view** authorization for this nonpersisting simulation; explicitly classify POST as a read/simulation action rather than relying on method-default create policy. Both routes require explicit `coCode`, `lcCode`, `coYear`, `coBook` query scope and authenticated tenant. Existing central scope/book errors can preempt service validation and must retain their established status.

`GET /sales-returns/:vchNo/incoming-replay-state` returns:

```ts
{
  contractVersion: 'x13-saved-incoming-replay-v1',
  profile: 'saved-primary-incoming-money-preview-v1',
  scope: { coCode, lcCode, coYear, coBook }, voucherNo,
  replayVersion, documentVersion, configurationVersion,
  configuration, // embedded safe existing configuration DTO; version must match
  rows: [{
    identity: { srNo, oldSrNo, vchSrno, tagSrNo, itCode, tagNo },
    rowIdentity, // opaque complete scoped saved identity, never array position
    raw, visible, caches, editorTextByField,
    fieldCapabilities: [{ fieldId, allowed, reason, maxLength: 10, editorDecimals: 2 }],
    diagnostics
  }],
  capabilities: { canPreview, canSaveNumeric: false }
}
```

Raw/visible/cache objects in this response are for inspection. `visible` and `caches` use numeric source-column string keys, matching the core; raw uses persisted storage-field names. `editorTextByField` uses the twelve stable field IDs and returns text or NULL plus a diagnostic when projection is unsupported. Embed the existing whitelisted configuration DTO rather than issuing an unsynchronized second caption request; `configurationVersion` must equal `configuration.version`. Preserve unsupported saved rows in the response with false field capabilities and explicit diagnostics, not silent omission. A UI launched from the saved card must also require matching `documentVersion` or ask for an explicit authoritative saved reload. None may be echoed back as authority. `rowIdentity` should be an opaque64-hex hash of exact complete scope/voucher/saved identity, resolved against the freshly observed rows; physical revisions belong in replayVersion. Do not use plain SR_NO or tag as an independently authoritative selector.

`POST /sales-returns/:vchNo/incoming-replay` accepts **only**:

```ts
{
  replayVersion: string,
  rowIdentity: string,
  events: Array<{ fieldId: string, editorText: string }>
}
```

Allow0–100 ordered events as an explicit API resource bound, not a desktop rule. Reject unknown keys at every level, wrong types/arrays, malformed64-hex tokens, any policy/width/cell/cache/source/tenant override and any whole raw snapshot. Empty events returns the hydrated baseline unchanged with an empty journal. Each nonempty event's original editor text is retained; do not deduplicate repeated commits, sort them by field, or replace them with final-value diffs.

First accepted stable field IDs are only these twelve:

| Field ID suffix | Original caption | Slot / persisted source field |
| --- | --- | --- |
| c19 | Rate | 19 / ITM_RATE |
| c20 | ItAmt | 20 / ITM_AMT |
| c21 | Lbr% | 21 / LBR_PRC |
| c23 | LRate | 23 / LBR_RATE |
| c24 | LAmt | 24 / LBR_AMT |
| c25 | LDisc% | 25 / DISC_PRC |
| c26 | LDiscAmt | 26 / DISC_AMT |
| c27 | OthAmt | 27 / OTH_AMT |
| c28 | RtnMrp | 28 / ITM_MRP |
| c36 | TotAmt | 36 / TOT_AMT |
| c37 | TaxPrc | 37 / TAX_PRC |
| c38 | NetAmt | 38 / NET_AMT |

Full IDs use `x13.primary-incoming.`. All twelve are numeric two-decimal LeaveCell cases in4592–4664; source EnterCell limits their editor text to10 characters. Apply that public input bound without truncating large saved raw values. Use the existing strict plain-decimal interpretation and explicit diagnostics, not liberal Val-prefix or locale conversion. The server also requires the field's resolved configured width to be positive; known hidden/unresolved fields reject as unsupported, rather than accepting caller visibility or silently claiming an applied event. Renamed captions never identify the event.

Translate an accepted journal entry into a server-built `leaveCell` event: source column from the catalog, opaque rowIdentity, original editorText and trusted positive row/normal-commit context (`clearing:false`, `editorVisible:true`, server width). This is deliberately a completed LeaveCell simulation, not a browser focus recorder. The client supplies no row0/clearing/editorVisible/width knobs. It may not submit `calculateAfterCopy`, c01 admission, LCode/TgLCode, product/tag/image/type changes, gross Enter, new/reordered/deleted rows, child commits, hidden cache/identity cells or unimplemented visible fields.

Success returns `{contractVersion,scope,voucherNo,replayVersion,documentVersion,configurationVersion,rowIdentity,baseline:{visible,caches,editorTextByField},preview:{visible,caches,editorTextByField},events,aggregateRequired,capabilities:{canSaveNumeric:false}}`. `events` retains original field IDs/editor text and result disposition; it is a transient replay journal. Tokens describe the same observed baseline, not a persisted result. Do not return recomputed invoice totals, refund/credit amounts or a saved flag. If an event rejects, return its index/attempted editor text and recoverable diagnostic; a last-valid transient prefix may be displayed separately but never called a committed batch. Existing input text must remain recoverable. Never automatically replay a journal under changed settings.

Suggested error classes:400 malformed envelope/unknown field;403 own-form denial;404 absent saved key;409 stale replay observation/row identity mismatch;422 unsupported projection/profile/known hidden action or calculator refusal. A422 calculation response can include baseline and last-valid preview for recovery. Database/unknown programming errors are not reclassified as successful containment.

## 6. One observation, then server re-resolution

Existing public `getSavedSaleReturnIncoming`, `getSaleReturnIncomingConfiguration` and source readers each open their own transaction. Do not call them in Promise.all and claim one coherent replay. Extract narrowly typed transaction-local read/projection helpers (or add the new service's fixed observations) under coordinated ownership, preserving existing DTOs and tests. They must use the caller transaction and never nest `withTenant`.

The composite replayVersion binds at least:

- Exact authenticated scope/voucher, all raw and physical saved header/incoming/outgoing/component/companion/finance observations used by the profile and existing document token, including row counts, xmin and ctid.
- Current configuration version and its complete relevant settings/column/book/year observations, catalog/profile version and edition uncertainty.
- Exact item-master rows used for fallback/type qualification, including duplicates, absence and physical revisions. Existing saved metadata version355–364 does **not** include itemNames264–268; neither its token nor effective configuration alone authenticates those projection inputs.
- Fixed raw-to-visible formatter/mapping semantic version and exact supported field list. No token may depend solely on derived booleans or displayed totals.

GET and POST each read a coherent `RepeatableRead` snapshot. POST rebuilds the composite observation and compares the supplied token before constructing state or applying events. No cached client output is promoted to server state. A read-only preview is valid for its observed snapshot and grants no reservation through response time. Explicitly retain the Round8 absent→insert→delete token-recurrence limitation: surviving xmin/ctid cannot record removed history. This is acceptable only as the declared nonpersisting observation contract; do not claim universal ABA protection.

A future **writer** requires all of these observations and source/stock admission to be re-resolved within the same locked/Serializable transaction as the write, with deliberate conflict handling. Row locks do not cover absent COL_MAST/source/stock rows, and the new generic column advisory lock is not adopted by clone/restore/raw writers. Do not claim cross-writer phantom safety until a shared protocol or proven serialization/write contract exists.

## 7. Source-row admission is still missing

The original-sale candidate reader's `available`/`canSelect` permits inspection only; its `canApplyIncoming:false` remains correct. Before any future source event or saved numeric application, implement separate source admission contracts:

1. **Original scope and reference:** preserve source company/location/year/book/voucher and full parent SR/OLD/VCH_SRNO/TAG_SRNO/item/tag/version. No current-year default, printed BILL_NO identity, tag-only Rows[0] or caller-supplied raw values. Source linked Returns span Return years/books; incomplete reference/NULL tag evidence remains ambiguous.
2. **F1 versus whole import:** F1 copies source ITM_* and labour into both incoming/tag rate31/amount32, assigns incoming OLD to new row and calculates4023. Whole import16561–16701 copies KR_* by default with a registration exception, preserves source OLD, has different positive-tax handling and does not calculate each row. Its Rows[0] hallmark/image anomaly needs explicit acceptance. Do not silently fix or merge these paths.
3. **Parent/child identity:** original Sales child SR_NO follows parent OLD_SRNO (TR_SALE15385–15386/15565–15597), not necessarily parent SR. Return source F1 rebinds child buffer23 while whole import preserves source OLD. Return BAR_IDTL persistence13719–13786 uses new Return scope/OLD/instance/ISR. Resolve zero, duplicate and orphan components without joining by array order or tag fallback.
4. **New admitted instance/tag:** incoming40 is separately generated3782–3801 and14482–14497; it is not the sold source's VCH_SRNO. NewTagNo4666–4732 and RepitTagNo4734–4864 depend on tag-repeat/company/import/product/tag-type state and BAR/SRNO/MAIN_STOCK/TAG_SET evidence. Last-row Enter can insert TAG_SET before voucher save4398–4407. Unique allocation, rollback/reservations, concurrent returns and cancellation must be designed and tested; copying the old instance is not admission.
5. **LBR_MAST:** changing LCode clears23/24/21/14/17/28, conditionally fills29, applies category01–07 and calculates4248–4320. TgLCode has its own clearing/category mapping4322–4381. Resolve full scoped master/version first; direct text or a declared post-copy cause cannot authenticate those copies.
6. **Remaining amounts and availability:** source selection exclusion is not a quantity/weight/refund balance proof. Partial/full/repeated return, over-return, consumed/issued stock, approval/employee ownership and released reservations remain separate live-transaction gates. No debt is closed by admitting a dry-run source selection.

## 8. Numeric persistence and financial limits

The preview stops before aggregate callbacks. Source `MSG_PR_TOT_FILL` accumulates rows with its own formatted summation and `BILL_TOTAL`16381–16476 compares rounded outgoing and incoming sides, computes header tax, payment bands, outstanding and customer closing balance. The row's NET_AMT is therefore not automatically the voucher refundable amount.

Preserve source-specific discount ownership:5022–5026 derives discount amount only under nonzero percentage/labour predicates; zero percentage can retain a manual amount. MRP5051–5070 has its own discount/tax order, and ordinary total5071 onward subtracts that stored/derived discount. Do not apply a generic invoice-wide discount, normalize retained values to zero or treat a field named Net Amount as permanently read-only merely because it is sometimes derived. The first twelve events exercise these branches only in a transient row.

A future writer must map each affected field to SL_DETL_RTN and every proven BAR/MAIN_STOCK/DM/AC/outstanding/tender/report effect, preserve exact raw values for unchanged columns, apply stored decimal scale only to actual written values, and preserve six-digit saved clocks. Direct source maps14307–14584 write independent SR/OLD/instance/tag/hallmark/employee/image fields and cached visible amounts; they do not authorize writing a normalized full client snapshot. BAR header/parent creation, BAR_IDTL rebinding, MAIN_STOCK/DM deletion/rebuild13427–13451 and delete/reversal15059 onward require exact companion ownership and transactional failure tests. Outgoing MSG/SL_DETL and UAE/alternate forms remain separate contracts.

Do not write SL_DETL_RTN alone and call the result a harmless numeric patch. Even Other Amount can change row total/net, header balance, refund/tender, ledger and reports. No required ledger/report work may be omitted to mark the twelve-field preview as a production-complete editor.

## 9. Verification and ownership checklist for the next implementation

- **Projection owner:** new pure `saleReturnIncomingProjection.ts` and independent fixtures. Assert exact raw NULL/empty/microseconds; fractional Pcs unchanged; two/three-decimal source display and separately seeded caches; display ordinal versus SR17/42 and OLD31/58; blank description/TgLCode fallbacks only in visible cells; hidden41/42 blank; no-event no recalculation; huge decimals and malformed/NULL conversion diagnostic. Test conflicting versus agreeing saved/master RATE_TYPE/IT_TYPE and duplicate masters explicitly.
- **Replay service owner:** new `saleReturnIncomingReplay.ts`, transaction-local read adapters and focused real DB tests. Capture zero-write before/after all existing document/source/finance/stock/counter/sequence rows. Exercise two books/years with same voucher, two rows with noncontiguous identities, sibling tenant/company, invalid record profiles and exact five-digit refusal boundaries. A token for one row/document cannot select another.
- **Event tests:** all twelve fields; rate→manual amount versus amount→rate; repeated same text must retain source trigger semantics; discount zero retention; MRP/non-MRP and tax cache order; manual total original text before formatting; K inverses and negative-zero source comparison. Reuse immutable Round7 expected strings, but author new independent expected projection+multi-event vectors instead of computing expectations with the same reducer.
- **Authority tests:** forged raw/cells/caches/width/policy/sourceRef/edition/context rejected; stable IDs survive caption rename; hidden or unresolved configured field refused; original c01/LCode/TgLCode/gross Enter/tag/child commands refused. Preview always returns canSaveNumeric:false regardless of View/Update rights.
- **Staleness tests:** edit header/selected or sibling parent/component, change relevant settings, add/remove/rename Fine, change relevant master while metadata/config tokens stay otherwise unchanged, same-value physical update, delete/recreate. Re-read complete baseline under one coherent snapshot; instrument real queries to interleave database changes. Preserve the explicit absent→insert→delete equality limitation instead of claiming a tombstone that does not exist.
- **HTTP owner (root):** fresh own-form View permission, explicit full scope, static/dynamic route ordering, POST read-action classification, no-store, strict400/403/404/409/422 responses and no-write negative snapshots. Unknown errors must remain observable. Do not call destructive writer or allocation helpers.
- **Optional UI owner:** distinct preview-only panel; generation guards for scope/document A→B→A, failed load with no valid token, stale409 with draft retained, explicit reload and explicit replay, rejected event text retained, no automatic save or total/report claims. Source-only read display remains separate. A selected preview result must never be submitted to the legacy Save button.
- **Regression owner (root):** focused pure/service/HTTP tests and independent expected vectors first; preserve frozen Round7 fixtures, Round6 metadata, original-sale reader and Round8 configuration/column tests. Then final captured-input build/type/full API/browser checks. No DB slot overlap, skip flags, ceiling changes or invented completion percentage. Record remaining numeric/admission/financial gates even when every preview test passes.

No product implementation is authorized by this note alone. The next checkpoint may claim trusted saved-row calculation preview after its tests pass; it may not claim complete transfer of Return functionality or financial parity.

## 10. Prospective read-input snapshot

The following hashes identify read inputs to this new planning note. They are not a new Round8 execution snapshot and do not mutate any earlier artifact.

Captured UTC: 2026-09-11T11:02:12.561015+00:00

| Path relative to web | SHA256 |
| --- | --- |
| `../unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `../unified/src/csharp/DataCareNext/TR_SALE.cs` | `b122837a890d99c370ec60e309b59a5207b65556493ce29f62ca6584e428d690` |
| `../unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `../unified/database/schema/01_Schema.sql` | `1eb684c7e2bec72a330a9038a2da72ffea669b3ae7ef50b85b34e0e3126efa0d` |
| `packages/db/prisma/schema.prisma` | `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754` |
| `packages/core/src/saleReturnIncoming.ts` | `bbc5df6568da23a75804866ab31c789b9be9850e79681d8193a82e1e3430c805` |
| `packages/core/src/money.ts` | `d6fbf799c56f4ed70e7b83006e22adeef4a23ac12f36d91abbf4b8deb0f19131` |
| `apps/api/src/modules/sales/savedSaleReturn.ts` | `05c2218ad69b0c0cd8cf1a4e542816a9fcae5c48057ed8c1b27dc1596ba94a06` |
| `apps/api/src/modules/sales/saleReturnSource.ts` | `07f5116677cf88e8c0f879e40f29f811ada866af13f2462cce11f5762fcc7395` |
| `apps/api/src/modules/sales/saleReturnIncomingConfiguration.ts` | `f7161a49c156621f048f7105f9648018f5726c017938f9e2bb356d74905f9308` |
| `apps/api/src/modules/sales/salesReturn.ts` | `612ddcd8f3b0cb8f0368435495125c8b50ed2f8cd03adad11f1cef12cf1d2a70` |
| `apps/api/src/modules/vouchers/numbering.ts` | `ccf924ae90087c682e8ea915dcaa018cc59e250e9c1825b68600dc20fb2f09db` |
| `../parity-plan-2026-09-10/12-execution-addendum.md` | `4a1f1326ee7d834bcbeed75f113b8b61aa3868186d7f3df48eca9c7edaf88d0e` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-original-sale-selection-contract.md` | `c4ea6eb670a475217b960d1368482060cfa3f0a658d62eb299ba0f4987ea471e` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-calculation-implementation-review.md` | `351a80bfb55f4c7413cc8e287677e690a37cdbb68f7905402d6bd003a9028490` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-next-configuration-contract.md` | `e1cb24964b8d1e9ab5dc2fa687f520a5084d08ef9fbe510e9eaad85265171a46` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round8/x13-incoming-configuration-implementation.md` | `526b9aca0450003b558d9ef295f8099a10e9e0261c070283692ec250f07007cd` |
