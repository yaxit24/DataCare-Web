# X13 round6: saved incoming Return metadata contract

Status: implemented bounded contract with focused verification; broad X13 acceptance remains open. Round5/checkpoint23 is frozen. This new slice reads saved primary incoming Return state and edits only explicitly supported metadata; it does not call the legacy destructive editSaleReturn/createSaleReturn replacement path. Full numeric return, new tag admission, original-sale selection, outgoing exchange and UAE behavior remain open. Source evidence is the recovered primary TR_SALE_RTN.cs, not an observed executable desktop session.

## Ownership and public API

Service owner: report_children, new apps/api/src/modules/sales/savedSaleReturn.ts and dedicated service tests. Root owns txn.ts/RBAC, TAG_LBR_CODE migration and authenticated HTTP tests. design_components owns saved UI/helper/tests. tour_order_ui owns the real browser fixture/journey. Coordinate DB slots; no frozen prior evidence is changed.

Exports use dependency-free public DTO types and prisma:any, matching existing service injection:

- getSavedSaleReturnIncoming(prisma, scope, requestedVoucherNo): Promise<SavedSaleReturnIncoming>
- listSavedSaleReturnIncoming(prisma, scope): Promise<{rows:SavedSaleReturnListRow[]}>
- updateSavedSaleReturnMetadata(prisma, scope, requestedVoucherNo, patch): Promise<SavedSaleReturnIncoming>
- SavedSaleReturnError(statusCode:400|404|409|422, code:string, message:string)

Routes: GET /sales-returns/incoming-recent; GET /sales-returns/:vchNo/incoming; PUT /sales-returns/:vchNo/incoming-metadata. Every route requires explicit coCode/lcCode/coYear/coBook query scope, with tenant/session authority resolved by the server. Validate active BOOK_DATA MAIN_BOOK exactly SALES RETURNE (source spelling), inward family, expected table SL_DATA, no hardcoded SRT requirement or fallback to another year/book. Parent lookup must find exactly one SL_DATA header and at least one SL_DETL_RTN row. Missing saved voucher is404; ambiguous saved state422. Neither list nor detail creates defaults or rows.

Root performs fresh Sales/Sales Return View/Update authorization and augments GET/PUT DTO with top-level canUpdate:boolean. It never accepts canUpdate from JSON. Service capabilities describe business eligibility; UI combines top-level own-form canUpdate with those capabilities. PUT returns a full authoritative post-write DTO and new version from the same transaction; no additional GET is necessary to establish save success. A network failure must not cause automatic retry.

## Saved DTO, exact values and display boundary

Scope = {tenantId,coCode,lcCode,coYear,coBook}, all required strings. voucherNo is the canonical saved varchar voucher. RawRow = Record<string,string|null>. Every persisted business scalar is projected to SQL text before JSON reaches JavaScript. Preserve decimal scale/value, numeric zero, empty string, whitespace, SQL NULL, all hidden values and fractional saved identity values. Do not use Number, parseFloat, Date or null-to-zero/default conversion to construct raw rows. Do not serialize numeric JSON first and then stringify an already rounded JavaScript number. All current scalar columns of SL_DATA and SL_DETL_RTN belong in raw; physical row_id/tenant_id and xmin/ctid are excluded from public raw and retained internally where needed for versioning.

VCH_DATE/other date columns remain date text. VCH_TIME timestamp(6) preserves all six fractional digits and wall-clock fields, without a timezone conversion. Existing header ENTRY_TIME is a date column; do not manufacture a clock. Timestamp display formatting must not feed back into the raw snapshot. Fields absent from a source import cannot be reconstructed by this read.

Detail shape:

    {scope,voucherNo,version,
     header:{raw,display:{employeeName,employeeNameReason},capabilities:{employeeCode:{allowed,reason}}},
     lines:[{identity:{srNo,oldSrNo,vchSrno,tagSrNo,itCode,tagNo},raw,
              display:{itemName,itemNameReason,description},
              capabilities:{huid:{allowed,reason},description:{allowed,reason}}}],
     related:{outgoingLines,outgoingComponents,tagHeaders,tagParents,tagComponents},
     provenance:{incomingLineCount,outgoingLineCount,outgoingComponentCount,
                 tagHeaderCount,tagParentCount,tagComponentCount},
     capabilities:{canUpdate,reason}}

All related arrays contain complete RawRow values for scoped SL_DETL, SL_IDTL, BAR_DATA, BAR_DETL and BAR_IDTL respectively. They are read-only evidence, not an assertion that outgoing SL_IDTL rows are incoming children. Source incoming original children pass through RtnIdtl to BAR_IDTL; do not merge the two grids. Every identity property except required srNo is string|null and compares exactly to the protected saved observation. SR_NO is the full-scope SL_DETL_RTN composite key, not a position. Never renumber SR_NO/OLD_SRNO/VCH_SRNO/TAG_SRNO or derive a source identity from the displayed row index.

Display description uses raw ITM_REMARK when nonempty; otherwise an unambiguous scoped ITEM_MAST.IT_NAME fallback (TR10362-10370). Keep raw NULL/blank separate so loading and saving without an explicit edit cannot replace it with the fallback. Master-name ambiguity produces an explanatory fallback/diagnostic, never arbitrary first-row authority. Employee display is from company-scoped EMP_MAST. The required nullable itemNameReason and employeeNameReason fields explicitly distinguish missing/multiple saved master matches; even duplicate matches with the same name are ambiguous. Item lookup uses the existing trimmed-code boundary, so distinct stored VARCHAR keys such as GOLD and GOLD-space must not silently share a display authority. A blank/null employee code means no employee selection and produces null employeeName/reason even if a blank-key master exists. These diagnostics never overwrite raw ITM_REMARK or EMP_CODE. List rows provide voucherNo, complete raw header values and display strings; limit the recent list to100 and deterministic date/voucher/physical-row ordering. Duplicate header identities remain visible as ambiguous entries or diagnostics; never silently choose one. The list has no write token and Load always obtains /incoming.

## Patch format and validation

    {version,
     header?:{employeeCode:string},
     lines?:[{identity:{srNo,oldSrNo,vchSrno,tagSrNo,itCode,tagNo},
              changes:{huid?:string,description?:string}}]}

Require a 64-lowercase-hex version and a nonempty bounded patch (maximum200 line entries). Reject unknown root/header/identity/change keys, numeric/source/calculated field changes, duplicate line identities and malformed/non-finite SR identity with400. A mismatched current saved identity is409. Omitted fields mean unchanged. Empty string means an explicit clear. Reject null patch values; raw null remains preserved unless an explicit string edit occurs. Reject over-width values instead of truncating: HM_ID10 Unicode characters, ITM_REMARK50. Employee code is at most3, matching EMP_MAST and source tEmpCode MaxLength3 (2628); imported longer header values remain raw/readable and unchanged unless edited. Nonblank employee must resolve to one company-scoped EMP_MAST row (15759-15789). Blank is allowed only when scoped CO_SET.EMP_CODE_MANDATORY is notY; source MS_OPNCOMP710/897-899 and TR12117/12180. Duplicate/conflicting config or master identities deny the mutation.

Empty or only equal-value patches do not touch rows or change physical versions. A patch containing one disallowed field must fail wholly even if other fields would be allowed. After a real mutation, return the fresh complete DTO; no hidden row replacement and no per-row partial success.

## Capabilities and exact write set

Read remains available for contained saved states. Missing/invalid saved VCH_DATE, existing period lock, invalid lock config, saved SL_DATA.USER_UPDATE=N, no supported incoming rows or unresolved record identity prevent applicable updates. Validate the saved date as a finite standard YYYY-MM-DD calendar day before calling assertPeriodOpen: the shared helper otherwise returns early for blank LOCK_DATE. PostgreSQL infinity, negative infinity and NULL remain raw/readable but block metadata. Use Date only for this independent validation, never to rebuild any saved timestamp. Reuse assertPeriodOpen against the saved date; do not substitute today. BOOK_DATA currently has no USER_UPDATE column; do not invent a schema read. Root form rights and configured-family checks are separate from these domain checks.

Implemented tagged policy is conservative: any real nonblank/non-N TAG_NO is readable but both line metadata fields are denied until exact unconsumed return-owned companion proof is implemented and tested. Never update the original BAR_DETL by tag text alone. No tag creation, tag reassignment, image-key changes, extra hallmark edits or source-identity changes belong in this slice. Nonzero finite VCH_SRNO/TAG_SRNO on an otherwise untagged saved row is preserved, not replaced with zero. Active APR_ISU/EMP_ISU or unsupported incoming entry kind prevents unsafe edits. Source primary ENTRY_TYPE=P and existing web ENTRY_TYPE=R remain distinct saved values; do not normalize either during metadata edits.

Any scoped BAR_DETL currently denies line metadata until the companion mapping is proven, including differing or missing SR identity. This intentionally contains ambiguous imported tag parents instead of guessing a match. Read-only BAR_IDTL/SL_IDTL arrays may still be preserved during an otherwise eligible incoming line metadata edit.

For an eligible untagged incoming row:

- changes.huid updates only SL_DETL_RTN.HM_ID for its exact saved full-scope SR_NO.
- changes.description updates only SL_DETL_RTN.ITM_REMARK for that exact row.
- Do not copy description to BAR_DETL.ITM_REMARK: primary source14319 writes incoming description, while the inspected BAR writer does not prove that counterpart assignment.

Header employee is one operation. Permit only supported incoming-only records where all relevant incoming rows and any existing employee-bearing companion have proven ownership. Deny if outgoing SL_DETL/SL_IDTL requires an unsupported effect, tagged/issued lines exist, or BAR companions are ambiguous/orphaned. For the proven simple incoming record, update SL_DATA.EMP_CODE and every scoped SL_DETL_RTN.EMP_CODE. If exactly one source-consistent return-owned BAR_DATA exists, require exact saved VCH_DATE, VCH_TIME, current EMP_CODE and VCH_DESC equality with SL_DATA, both header date/time present, STK_IT_CODE exactly empty, and no companion USER_UPDATE=N; update its EMP_CODE as source13112 requires; otherwise no BAR_DATA is fabricated. Any scoped DM_DATA denies employee changes because its employee effect is not established in this slice. Absence from a legacy web record is preserved and remains a separate create-parity gap. Never stamp a per-line employee supplied by a caller. BAR_DETL/BAR_IDTL do not have a proven employee field assignment in this source block.

Allowed write tables/columns are therefore SL_DATA:EMP_CODE; SL_DETL_RTN:HM_ID,ITM_REMARK,EMP_CODE; optional proven BAR_DATA:EMP_CODE. All other business and physical rows remain unchanged. No calls to computeLine, billTotals, postVoucherTx, reverseVoucherTx, editSaleReturn, deleteVoucherWriteSetTx, numbering or image mutation. Preserve MAIN_USER, VCH_DATE, VCH_TIME, ENTRY_TIME, original ISU_* refs, all decimals and all finance/stock rows exactly. No implicit employee/default/HUID repair on read or no-op save.

## Snapshot, CAS and transaction behavior

Read with RepeatableRead; update with Serializable and an exact header row lock, followed by deterministic locks for the affected incoming/companion rows. Revalidate configuration/period/capability in the mutation transaction. Do not use a nested withTenant or build a version from an earlier independent read. Version SHA256 must include a format discriminator, complete scope/voucher, full header, both detail legs, both component datasets, BAR_DATA/BAR_DETL, their physical row_id when present plus xmin/ctid, and the protected companion/write boundary. Include relevant scoped financial/stock rows and policy inputs so a change cannot borrow a stale observation. Canonically order object keys and row arrays; no accidental dependence on database row order. New/removed rows must change the token. Parent and child delete/recreate and value A-to-B-to-A must invalidate stale tokens; values alone are insufficient.

Header FOR UPDATE coordinates with existing legacy edit/delete header locks. Serializable/predicate reads contain concurrent child or companion changes and phantom insertion; classify expected serialization/write-conflict failures as409 and require explicit client reload, never auto-retry a stale mutation. SQL parameters are used for values. Table names come from a fixed allowlist; dynamically projected identifiers may come only from known schema columns and must be quoted. No caller-controlled columns, SQL or table names.

Read and capability checks may inspect more rows than the update set. Original-sale rows and consumed stock are never changed by this endpoint. If tagged proof is added later, it needs full original-return chain and reissue consumption tests first: source F1 does not assign incoming col40 from the original instance, source save14481-14497 generates it whenzero, whereas existing resolveReturnedTagIdentities reuses original SL_DETL.VCH_SRNO. A same-tag lookup is insufficient ownership evidence.

Error responses use {error:code,message}:400 invalid-input;404 not-found;409 version-conflict/identity-conflict;422 unsupported-state for a denied metadata capability, including period/configuration-related read-only reasons. Existing book-policy errors retain the route validation mapping. Unexpected DB/operational errors retain ordinary500 handling. Auth failures remain existing401/403 and do not produce a writable observation.

## Required schema change

SL_DETL_RTN.TAG_LBR_CODE is source read10400/write14438. Exact source DDL: unified/src/csharp/DataCareNext/MS_OPNCOMP.cs5844 and unified/database/schema/01_Schema.sql3033, VARCHAR(4) NOT NULL DEFAULT empty string. Root adds a narrow migration/model field and schema manifest. Historical absent values cannot be recovered by the empty default; reimport remains needed. Do not add UAE RATE_WITH, ordinary-sale order links or other guessed columns in this migration.

## Source-backed omissions and next dependencies

Primary incoming writer14319-14584 also has ITM_STYLE,LBR_CODE,TAG_MRP,TOT_AMT,APR_ISU,EMP_ISU,DATA_TYPE. Complete raw hydration must retain these and all existing incoming columns. Hidden image/hallmark fields from3964-3973 and14517-14569 are readable preserved data, not mutable storage identities. Primary MSG outgoing SL_DETL/SL_IDTL and incoming MSG_PR SL_DETL_RTN/BAR_IDTL remain separate.

Ghat percentage and line discount stay read-only in this metadata slice. MSG_PR_LeaveCell4592-4663 distinguishes text from calculation commits. CommPassTotal_Pr4866-5162 has cached gross/net/touch/west/rate/labour/tax state, ordered ghat weight before net recalculation, labour discount5022-5024, MRP5053-5071 and manual total5075-5115. Source F1 pickup calls this calculation4023. Header DISC_PRC/DISC_AMT are zero12627/12631; outgoing NET_AMT12623 versus incoming RTN_NET_AMT12707/RTN_TOT_AMT12789 and BILL_TOTAL16381 onward need one coherent accounting port. Current generic return API does not satisfy it. No metadata test closes numerical, finance, tag-generation, report or full33-field parity.

## Verification requirements

1. Full exact read of imported header and incoming rows with noncontiguous SR17/42 and OLD31/58, fractional identity where source schema permits, hidden image/HUID data, null/blank/zero, maximum representable decimal strings and timestamp .123456. Include distinct scoped outgoing/component/companion rows in read/version evidence without crediting them as editable.
2. Same voucher in two configured non-SRT return books, another year/location/tenant; missing/ambiguous header; inactive/wrong-family book; complete-scope route validation. No cross-scope reads or updates.
3. HUID and description updates affect only requested cells/rows. Missing description fallback remains raw NULL on untouched save. Explicit clear stores empty string. Header employee stamps exactly the supported existing employee-bearing rows; no MAIN_USER/time/finance changes.
4. Full physical/business snapshots before/after no-op and mutation, with only intended cell/revision changes. Finance/stock, original source, hidden fields, both component sets and counters remain identical. Assert no replacement, allocation or deletion.
5. Stale token, two simultaneous edits, parent delete/recreate, child/companion edit or ABA, foreign/changed line identity, duplicate row patch, unknown financial/source fields, overlength/null values, closed period, locked saved user flag, invalid/mandatory employee, tagged and issued states. Every rejection leaves the complete prior write boundary unchanged.
6. A late failure after the first allowed update rolls back the whole patch. Successful PUT returns a fresh authoritative DTO. Real browser uses the exact saved key, read-only containment reasons, explicit dirty patches, own-form rights and scope/request guards; stale save requires Reload and never overwrites automatically. Saving metadata does not trigger create or delete.

Acceptance will be limited to the tested saved metadata contract. The33-field map and broader X13 release blockers remain open unless separately proved and dispositioned.

## Focused implementation checkpoint

The new service and service tests are frozen after the focused run. Exact executed command: `node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test -- test/savedSaleReturn.db.test.ts test/savedSaleReturn.routes.db.test.ts test/routePolicy.test.ts`. Evidence `saved-incoming-focused.txt`:3 files,84 tests passed,zero skips; service21,authenticated HTTP9,route policy54;4.43s total. No customer/live-business data was used; wrapper provisioned the isolated localhost55433 target and non-owner forced-RLS role.

`saved-incoming-service-first.txt` remains historical evidence:20 service tests passed,one fixture failed before its intended assertion because DM_DATA requires MAIN_SRNO and ISR_NO. The fixture now supplies those source-schema keys. No product guard was weakened. The corrected full focused run includes the late rollback, real concurrent CAS, component ABA, same-business/same-row-ID parent recreation, both-child-set preservation, and source-consistent BAR_DATA employee vectors.

Root owns final whole-API/type/build/browser verification and checkpoint. Those final outcomes must be linked after completion; the focused run alone does not establish all form parity, numeric calculation equivalence or production acceptance.

## Final focused source stage after review diagnostics

The follow-up source review found two confirmed gaps against this contract: assertPeriodOpen skips date parsing when LOCK_DATE is blank; and missing/duplicate master names had no explicit diagnostic. Root authorized these bounded corrections before the final whole-API run. API now validates the saved calendar first and returns required nullable itemNameReason/employeeNameReason alongside preserved raw values. The UI owns their rendering.

`saved-incoming-focused-verified.txt` is the final current focused run:3 files,89 tests passed,zero skips; service26,authenticated HTTP9,route policy54;12.49s. Five added service cases cover infinity/negative-infinity/NULL saved dates, a valid leap day with the original independent microsecond clock retained, and master ambiguity/missing/no-selection diagnostics plus raw no-op preservation. The earlier84-pass stage remains historical and is not relabeled as covering this code.

`saved-incoming-focused-diagnostics.txt` retains an88-pass/one-failure intermediate run. Its fixture tried to insert an exact duplicate ITEM_MAST primary key, so it failed before the diagnostic assertion. The corrected vector uses distinct legal VARCHAR keys GOLD and GOLD-space that collide under the existing trimmed lookup, with identical names; the schema remains unchanged. The final case also verifies a blank employee code never selects a stray blank-key employee master. No assertion or source restriction was removed to obtain the final pass.


## Final coordinated verification and freeze

The final full API run (`api-full-complete.txt`) passed223 files/1776 tests/zero skips in204.41s. Root captured1028 consumed inputs before the run in `api-input-snapshot-complete.json` (SHA256 f431d79293573072501298408076a393a6604dcac20f5f71ae1c37eef987c8b0); `api-input-verification-complete.json` records no changed or added inputs. The scoped manifest refresh independently rechecked every1028 recorded hash against the held source/build inputs. This complete run covers the final26 service cases and final diagnostics code; the earlier84-pass focused stage remains historical.

Final strict API test compilation exited0 (`test-types.txt`); production build7 tasks (`build.txt`), lint/typecheck10 tasks (`lint.txt`), web24 files/168 tests (`web-tests.txt`), and core8 files/106 tests (`core-tests.txt`) passed. The coordinated actual browser passed13 journeys with zero mocked requests (`browser-complete.txt`); the legacy mocked compatibility smoke also passed (`browser-smoke-complete.txt`) and is a separate, narrower form of evidence. These results establish the bounded saved-read/metadata implementation and its regression checks. Numeric Return saving, full33-field closure, executable desktop comparison, business acceptance and production deployment remain open.
