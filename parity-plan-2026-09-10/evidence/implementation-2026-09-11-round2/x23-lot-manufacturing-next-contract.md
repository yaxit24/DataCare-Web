# X23 next implementation contract — explicit lot Setting workflow

Recorded 2026-09-11. This is a read-only source and implementation review for the next bounded work package. **No X23 product change or completed desktop parity is claimed by this artifact.** X23 remains open under `12-execution-addendum.md:892–926`, including its prerequisite cards and all other manufacturing variants. Paths below are relative to `imodule-extracted/` unless prefixed with `web/`; line numbers identify the reviewed files, not an immutable API.

## Recommended next operator journey

Implement configured **lot Setting issue → first partial Setting receipt → second receipt → receipt reversal**, with source selection, saved read/edit/delete, stable parent/component/source identities, and reconciled material projections. This is a bounded descendant of X23, not closure of X23.

The actual menu evidence is `unified/src/csharp/DataCareNext/MDI_FORM.cs:9842–9899`: when `MsMfgWithLot == Y`, `Setting Isu`, `Setting Rec`, `Polish Isu`, and `Polish Rec` open `TR_MFG_WITH_LOT` through configured main-book families `MFG STNG ISU`, `MFG STNG REC`, `MFG POLISH ISU`, and `MFG POLISH REC`. Start with the Setting pair. The presence of GHAT branches inside the form is insufficient evidence to label a generic GHAT screen the menu-backed lot workflow.

The first implementable step is to reconcile the schema and effective configuration gates below, then deliver an explicit settings/source-lot/read API and lossless editor. Enable mutations only after the exact Setting projection and direction contract is resolved. Read contracts, pure mappings, identity helpers, and synthetic fixtures can proceed independently of a production write decision.

## Pinned source evidence

All source files in this table are under `unified/src/csharp/DataCareNext/`.

| File | SHA-256 | Relevant reading |
|---|---|---|
| `MDI_FORM.cs` | `cb91085c50d07a07ae5c5a8e6982ef6f9a2c533e2b55d61fc8c35f093f5dfbbc` | 9842–9899, actual lot menu callers |
| `TR_MFG_WITH_LOT.cs` | `ae8a5ee8f2821a388d0389a35de0951f372a5753162a42ba1f89787ca934d5e4` | 4610–4655 and 5044–5199 selectors; 5497–5500 configured book; 5612–5623 stage settings; 5631–5805 saved reader; 5855–6290 save/projection order; 6304–6340 delete |
| `Ac_Tax.cs` | `683d1508b6724a820807eb2806494b093386e8be8bfa8cd9c15a985d3d69fba2` | 419–437 Setting projections; 439–456 Polish projections |
| `Ac_Stock.cs` | `946f9ba4f7e85835f0baf5cdbd2ef71a46c59517bae3e18fd45d29eb8504ef1c` | 461–514 component issue/return stock and branch precedence |
| `Ac_Ledr.cs` | `b58ba77dbd2c960f5928db75993229ad2c7d8c2a2a45adadcf84da27d9fa264a` | 2182 onward lot issue ledger; 2207 onward lot receipt ledger; full account mapping remains a separate gate |
| `MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` | 4989–5064 effective manufacturing mode derivation |
| `MS_UPDATE.cs` | `943525d918df85170ee3a4733bdf81cdc1d5b7e61b5efed27add7bc2883d8cb7` | 18377 base MFG_IDTL DDL; 8545/8600/8604, 28542, 29722 subsequent known fields; lot-column search described below |

This review uses extracted source, existing web code/schema, and source-derived synthetic fixture proposals. It does not supply an observed operational desktop run or a desktop database schema export. Any ambiguous branch must be resolved using the original executable IL, alternate source, actual desktop metadata, or paired runtime evidence; do not substitute intuitive formulas.

## Current web gap and reuse boundary

| Reviewed path | Current behavior | Required lot-specific change |
|---|---|---|
| `web/apps/api/src/modules/manufacturing/mfg.ts:215–320` | Generic parent DTO has `lotNo`; component DTO lacks its own `ITM_LOT` and explicit stable `ISR_NO`; parent input lacks explicit preserved `SR_NO`/`OLD_SRNO`. | Add an explicit lot DTO that represents each identity separately. Do not change generic DTO semantics silently. |
| `mfg.ts:649–702` | `idtlRows` derives parent/child serials from array indices, defaults `VCH_SRNO` to parent serial, and does not write component `ITM_LOT`. | Lot source writer uses persisted parent/child serials, component lot, and `VCH_SRNO = 0`. |
| `mfg.ts:704–754` | `isuRecRows` always uses parent net as `IR_WT`, parent item as `IT_CODE`, parent lot as `LOT_NO`, and array index as `IR_SRNO`; omits full source `IR_*` links and `ITM_LOT`. | Implement source-family projection functions; Setting and Polish already differ. |
| `mfg.ts:756–800` | Generic parent stock row has `ITM_LOT = line.lotNo`; no separate lot component return projection. | Source Setting issue stock includes parent plus child lots; receipt component stock uses returned quantities. |
| `mfg.ts:355–375` | Stage lookup selects the first matching company/book row with `LIMIT 1`. | Validate one effective stage/configuration; reject conflicting rows instead of selecting arbitrarily. |
| `mfg.ts:169–196` | Generic book policy reads display `BOOK_NAME` and `BOOK_SNAME`. | Lot family is determined by configured `BOOK_DATA.MAIN_BOOK`, not a display label or hardcoded book code. |
| `mfg.ts:881–968` | Generic receive persists a voucher without locked source availability/partial drawdown enforcement. | Validate and consume the selected source allocation atomically. |
| `mfg.ts:978–1003` | `mfgLotBalance` groups by company and lot, optionally item; no branch/process/karigar/source key or locking. | It is unsuitable as the authorization or conservation check for a selected receipt. Preserve or explicitly rename its existing aggregate contract. |
| `mfg.ts:1036–1080,1241–1335` | Existing replacement guards protect some dependencies; edit rebuilds rows and identities and has no expected-version input. | Reuse only proven period/transaction infrastructure. Add exact source locks, optimistic version, stable identities, lossless loaded snapshots, and downstream rules. |
| `web/apps/web/app/(app)/txn/mfg-issue/page.tsx` | Generic create form; no complete lot picker or saved lifecycle. | Dedicated lot issue workflow. |
| `web/apps/web/app/(app)/txn/mfg-receive/page.tsx` | Generic create form with manual lot/reference fields; no source allocation picker or complete read/edit/delete. | Dedicated lot receipt workflow. |
| `web/apps/web/app/(app)/txn/item-lot/page.tsx` | `TR_ITM_LOT` intake through `/stock/item-lot`. | This is a different operator action; do not count it as the manufacturing journey. |
| `web/apps/web/components/KarigarForm.tsx` | Generic jobwork family. | Shared display components may be reusable; its posting contract does not establish lot equivalence. |

Existing `mfgLifecycle.db.test.ts` and manufacturing/melting tests remain regression coverage. Their passing status cannot certify the missing lot operator contract.

## Schema reconciliation required before rich lot writes

1. `web/packages/db/prisma/schema.prisma:4141–4186` defines scoped `MFG_IDTL` parent/child keys and return/breakage fields but **does not define `ITM_LOT`**. Desktop `TR_MFG_WITH_LOT.cs:6152` writes it; the saved reader at 5775 reads it; `Ac_Stock.Mfg_DM_Stk_Less` consumes it. Dropping it would merge or lose component source identity.
2. `schema.prisma:4189–4254` defines `MFG_ISU_REC.LOT_NO` and full `IR_*` fields but **does not define `ITM_LOT`**. The existing applied raw migration `web/packages/db/prisma/migrations/20260910020000_mfg_isu_rec_item_lot/migration.sql` adds `MFG_ISU_REC.ITM_LOT VARCHAR(15)`. This is physical-schema/Prisma drift to reconcile explicitly, with fresh migration and existing-migrated-database checks. Do not create a duplicate incompatible column.
3. The reviewed `MS_UPDATE.cs` base MFG_IDTL table at 18377 and known subsequent ALTER statements do not establish the missing MFG_IDTL ITM_LOT type, width, default, or nullability. Searches for the table/column combination found no corresponding ADD statement. Other tables use different widths: item-lot and several MAIN_STOCK lot updates use varchar(10), while the web MFG_ISU_REC migration chose varchar(15). **Neither neighboring width establishes the MFG_IDTL contract.**
4. Obtain authoritative desktop metadata for MFG_IDTL.ITM_LOT and MFG_ISU_REC.ITM_LOT: column name/type/width/precision/nullability/default, populated min/max lengths, and representative keys. Check alternate source/DDL and original executable if the update path is conditional. If no metadata is available, record the exact unresolved field and keep mutations requiring it unavailable; read-only contracts and fixture design can still proceed.
5. After reconciliation, root integrates the bounded schema migration, Prisma regeneration, migration manifest, extractor/importer mapping, and restore verification. Test a fresh database and an already migrated database. Backfill only where source identity is proven; never infer every child's lot from its parent's lot.

## Effective configuration and direction gate

`TR_MFG_WITH_LOT.cs:5497–5500` copies the selected book's `MAIN_BOOK`, short name, and `BOOK_INOUT`; it does not infer direction from a route name. At 5612–5623 it loads company/book MFG_MAST `SM_CODE`, `ENTRY_TYPE`, `NEXT_TRAN`, `LAST_TRAN`, `STK_ISU`, and `STK_REC`.

`MS_OPNCOMP.cs:4989–5064` initially sets one-form Y, with-order N, with-ledger N, and with-lot N. Registration references `VK289NEPH` and `VK321NEPH` enable with-lot and disable one-form when manufacturing type is M. A different reference enables with-ledger; work-type branches can subsequently change one-form/order behavior. These are derived installation modes, not equivalent to an invented CO_SET `MFG_WITH_LOT` flag. Current CO_SET `MFG_ONE_FORM` alone is insufficient evidence for the effective mode.

The lot form's ledger dispatch at 6179–6189 calls `Mfg_Lot_Isu_Ledr` for configured I and `Mfg_Lot_Rec_Ledr` for configured O. Yet `Ac_Ledr.cs:2182` has registration guards and its queries filter book direction O for the issue-named helper. The reviewed initialization also leaves with-ledger N for the two lot references. This suggests a potentially unreachable or installation-specific branch; it is **not resolved** by assuming that an issue route means O or reversing the helper names. Generic mfg.ts issue O/receipt I constants cannot settle this discrepancy.

Required configuration fixture: a real exported lot installation's effective manufacturing mode, BOOK_DATA/BOOK_DETL pair, and MFG_MAST rows. Preserve raw registration references privately; return capability/behavior values to the browser, not licensing identifiers. The read API must explain unsupported configuration as a business-facing unavailable operation, while the evidence retains the exact technical cause. Reject conflicting stage records, a wrong MAIN_BOOK family, or ambiguous direction without creating any voucher.

The initial mutation profile should be limited to the independently proven non-one-form, non-order, non-ledger Setting branch, with a resolved final stock projection. Configuration variants outside that profile require their own source and fixture contract before being advertised as available.

## Identity and projection contract

Keep these distinct in the DTO, database read, UI, and tests:

| Identity/value | Desktop meaning and source |
|---|---|
| Voucher key | Tenant + company + branch + voucher year + configured book + voucher number. Scope every read/write. |
| Parent serial | `MFG_DETL.SR_NO` from grid column 0, source 6047; do not replace with array position. |
| Parent old/source serial | `MFG_DETL.OLD_SRNO` from column 36, source 6048; source links target this field. It is not necessarily SR_NO. |
| Parent tag/work lot | `TAG_NO` is column 5 for Setting receipt and column 1 otherwise, source 6051–6060. |
| Parent material lot | `MFG_DETL.LOT_NO` is column 2. It is not necessarily TAG_NO. |
| Issued vs received item | `ISU_IT_CODE` is column 29; `IT_CODE` is the current detail item. Preserve both. |
| Source link | Setting issue stores its own year/book/voucher and OLD_SRNO as REP_*. Other modes copy the selected source grid fields. Read/write all REP_* fields, including account, rather than accepting only a voucher number. |
| Component identity | MFG_IDTL `SR_NO` from backing parent field 22, `ISR_NO` from child field 0; `VCH_SRNO = 0`, source 6147–6152. |
| Component material lot | MFG_IDTL `ITM_LOT` from child field 1, separate for every child; never fall back to parent lot silently. |
| Projection source link | MFG_ISU_REC `IR_LC`, `IR_YRCD`, `IR_DBCD`, `IR_NO`, `IR_SRNO`, `IR_AC`; source serial derives from REP_SRNO, not the current array index. |

`Ac_Tax.cs:419–437` Setting projection, subject to its with-ledger/one-form guards:

- Issue gold parent: ISR_NO 1; sign minus; IR_TYPE S; `IT_CODE = ISU_IT_CODE`; `LOT_NO = TAG_NO`; `ITM_LOT = MFG_DETL.LOT_NO`; `IR_WT = ITM_NWT`; DM pieces/weight from the parent; source IR_* from REP_* and current branch/account. Nongold parents use ISR_NO 2 and a different diamond projection. Do not merge these rows under one assumed parent projection.
- Receipt: ISR_NO 1; sign plus; same item/lot/source mapping; `IR_WT = ITM_NWT`; RTN_CHOL and RTN_GHIS copied; `ITM_GHAT = ITM_GHT_WT`; ITM_LOSS is explicitly zero in this helper. Generic acceptance of a loss field does not prove this branch posts it.
- `Ac_Tax.cs:439–456` Polish uses **gross**, including projected ITM_NWT, and blank ITM_LOT. It must have its own tested projection; do not include it merely by changing the Setting book name.
- Setting issue helper source lacks an explicit current-year SQL restriction where receipt has one. The web must scope the current write set to its exact voucher and preserve selected historical source references; any correction to desktop cross-year side effects must be documented as a preservation/isolation difference pending acceptance.

`Ac_Stock.cs:461–514` stock projection:

- `Mfg_DM_Stk_Less` is guarded by non-one-form mode. Branch precedence is special registration → with-order → with-lot → default. For the lot branch, parent rows use ISR_NO 0, minus/O, TAG_NO N, parent's LOT_NO, and the source's specific net/fine assignments (ITM_FINE uses parent net while KR_FINE uses parent fine). This is not a generic purity recomputation.
- Child issue stock uses persisted SR_NO/ISR_NO and each child's ITM_LOT, pieces and gross. The source condition includes parent serial at most 100; trace its meaning before silently dropping higher-serial imported children.
- `Mfg_DM_Stk_Add` in lot mode posts **RTN_PCS/RTN_GWT**, with each child's lot, as plus/I stock. It does not post the entire issued component weight as returned stock. BROK_* remains separate from physical returned stock.
- Form save 6250–6270 first writes Setting component stock, then `STK_REC == Y` deletes the voucher's MAIN_STOCK again and invokes `Mfg_Stk`. Therefore the final write set depends on call order and stage flags. Do not append both projections. Trace `Mfg_Stk` for the selected fixture and record the resulting table rows before enabling writes.

The full saved reader/writer also includes customer/karigar values, returns, losses, order/design identifiers, remarks, rates, labour, and payment/received rows. Inventory every database column into editable, calculated, preserved-hidden, or explicitly unsupported status. Array DTOs must preserve unknown-to-editor historical fields through an unchanged save; do not reduce the persisted record to the visible columns.

## Source selection and conservation

The selector at 4610–4655 has different branches. One outstanding receipt branch compares issued IR_WT with received `IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS`. A previous-stage/current-stage transfer branch displays previous receipts including DM_WT, with a different availability HAVING expression. The setting material-lot selector at 5044–5199 groups by ITM_LOT, item, source year/book/voucher/serial, account/karigar and process, and some branches filter available pieces. MAIN_STOCK material-lot lookup at 5141 onward requires branch-scoped nonblank lot, TAG_NO N, and positive stock. These are separate selectable source kinds, not a single company-wide lot sum.

Implement an explicit selector result discriminated by source kind, with source identity, item, lot, process, karigar, original quantity, accounted quantity, remaining weight/pieces, and source date. Display enough provenance to distinguish repeated lot labels. The save endpoint resolves the selected source itself and revalidates current availability; UI-displayed balances are advisory.

Recommended lock identity for a source allocation is tenant, company, branch, source year, source book, source voucher, source OLD_SRNO, process, lot/material-lot, issued item, and karigar, as appropriate to the proven selector. Preserve explicit historical source years for unfinished work across year boundaries. Do not filter every source to the active voucher year, and do not aggregate unrelated years/books under one label.

Atomic mutation steps:

1. Validate authenticated company/branch, family, configured mode, master references, period/date, and action rights. Check create vs edit operation independently.
2. Start the standard tenant transaction. Lock current voucher and all old/new allocation sources in a deterministic order. Use stable database row locks or transaction advisory locks keyed by the full identity; an unlocked balance query before a later write is insufficient.
3. Compare expected voucher version against the saved business snapshot under lock. Validate the policy/source version where configuration changes affect calculations.
4. Re-read source rows and relevant posted allocations under lock. For an edit, account for replacing this voucher's prior allocation without counting it twice. Check all weight, pieces, component-return, and breakage limits using the proven source equation and decimal precision.
5. Build all final header/detail/component, MFG_ISU_REC, stock, ledger, remark, audit, source-adjustment and temporary-number rows in memory. Verify the proposed write set conserves source material and respects dependent transitions.
6. Write the replacement and source effects in one transaction, using the established idempotency/numbering infrastructure. Any failure restores the prior entire write set. Return the saved canonical record and version after commit.
7. On cancellation/reversal, remove only this voucher's allocation and projections, restore exact source availability, and recompute any REP_ADJ completion marker from remaining references. The desktop delete resets REP_ADJ through full REP_* and OLD_SRNO joins at 6324; a partial-receipt web workflow cannot mark a source wholly unadjusted while another valid receipt remains without an explicit source/acceptance decision.

Improved locking, idempotency, and lossless preservation are required production behavior. They are not evidence that the desktop implemented the same concurrency mechanism. Keep this distinction in the eventual evidence manifest.

## Proposed implementation files and work packages

The following names are **new proposals**, not existing implemented surfaces.

| Package | Proposed ownership/files | Deliverable and completion check |
|---|---|---|
| X23-L0: schema/config evidence | Root integrates `packages/db/prisma/schema.prisma`, bounded migration/manifest, import/restore mapping; read source/config fixtures first. | Reconciled ITM_LOT contracts, effective mode/direction, and final STK_REC projection. Fresh/upgraded DB schema checks pass. Unresolved profiles remain unavailable. |
| X23-L1: scoped read/source API | `apps/api/src/modules/manufacturing/mfgLot.ts`; dedicated tests; root routes/RBAC. | Settings, source-lot selector, saved aggregate and version; cross-company/branch/source-family rejection; lossless raw read fixture. |
| X23-L2: pure projection/conservation | New focused core/helper file only if shared by UI/API; dedicated tests. | Explicit Setting row projections and source balances from pinned vectors, including distinct parent/component lots and identities. No silent rerounding during hydration. |
| X23-L3: atomic lifecycle | Same dedicated API module plus integration tests. | Versioned issue/receipt create/edit/delete, source locks, partial/concurrent drawdown, idempotent retry, full failure rollback and dependent-voucher protection. |
| X23-L4: operator editor | `apps/web/components/MfgLotForm.tsx`, page-local draft helper, `/txn/mfg-lot-issue/page.tsx`, `/txn/mfg-lot-receive/page.tsx`. | Configured book/karigar/source pickers, rich parents and nested children, create/load/save/delete, clear source availability and validation, preserved imported snapshots. Root integrates navigation and dedicated action rights. |
| X23-L5: actual browser and reconciliation | A new separate journey imported by root-owned `apps/web/test/parity.real-stack.mjs`; synthetic seed isolated from production. | Issue → two partial receipts → exhausted source → reverse → restored availability, database write sets and reports; zero mocked requests. |

Proposed route family: `/mfg/lot/settings`, `/mfg/lot/sources`, `/mfg/lot/issue`, `/mfg/lot/receive`, with GET saved read and action-specific POST/PUT/DELETE routes. Final route spelling must follow existing route/RBAC conventions. Generic `/mfg/*` compatibility remains separately tested. Bind view/create/edit/delete/print to the selected manufacturing form's own rights; generic Sales or Tag Print rights must not substitute.

The editor should expose configured header book, date/time, voucher identity, karigar/account, source selection and allocation, parent tag/material lot/issued-vs-received item, design/size, pieces and customer/karigar metal values, accountable returns/losses, and nested component lot/item/serial, issue/return/breakage, conversion, rate and labour fields. Use exact source mappings to decide which values are editable. Show hidden fields through a preserved snapshot and a reviewable detail view where useful. Do not let collapsing a grid, changing selection, or an unchanged blur reset saved values.

## Required synthetic fixture pack and assertions

These are proposed source-derived synthetic examples, **not observed desktop outputs**. Each test must use the chosen source profile and confirm its prerequisite configuration.

1. **Scope and configured families:** two independent Setting issue/receipt book pairs with arbitrary book codes and custom display names, two branches, two years, two companies/tenants. Repeat lot label, item and voucher numbers deliberately. Verify source selection, save, edit and delete cannot cross scope or choose the other pair. A historical source year is selectable only through its explicit identity.
2. **Noncontiguous identity:** parent SR_NO 17, OLD_SRNO 42 and a second distinct parent; children ISR_NO 3 and 9, each with a different ITM_LOT. Reorder parents/children, edit one field, reopen and compare every identity. Verify MFG_IDTL VCH_SRNO source-zero behavior, MFG_ISU_REC IR_SRNO equals source old serial, and unchanged write-set equality across all business columns.
3. **Distinct weight bases:** seed gross different from net, nonzero diamond weight, and issued item different from received item. Assert exact Setting IR_WT net, LOT_NO tag, ITM_LOT material lot, and source IR_* mapping. A Polish configuration is explicitly unsupported until its gross-based vector is implemented; it must not pass through Setting.
4. **Partial receipts:** conditional on the resolved Setting accountable-weight branch, issue net 10.000; receipt net 6.000 + chol 0.200 + ghis 0.100 + ghat 0.100 accounts for 6.400; remaining is 3.600. Second receipt accounts for 3.600 and exhausts the source. Assert database projection sums and picker availability, not only the response total. A source helper that forces ITM_LOSS to zero must not use a nonzero loss to make this vector pass.
5. **Over-consumption and race:** reject a receipt above 3.600 with no mutation. Start two concurrent 2.000 allocations against remaining 3.600; exactly one succeeds and the other sees the updated balance. Repeat with components/pieces and two independent sources to prove no unnecessary global serialization. Verify edit changes old/new source locks in deterministic order.
6. **Return/breakage:** issue two child lots with distinct pieces/weights. Record returned and broken quantities separately. MAIN_STOCK returns only RTN_PCS/RTN_GWT to the same child lot; breakage does not become returned stock. Negative or over-issued quantities fail under the resolved source contract. Check zero/manual/imported nullable values and precision boundaries.
7. **Reversal and dependencies:** reverse the second receipt and restore exactly 3.600; the first remains valid. Delete/edit of an issue with a surviving receipt is refused or follows a separately proven reversal workflow. Reopen the remaining receipt and compare source links. Check REP_ADJ against the surviving partial references. Reversal after downstream tagging/delivery/sale must respect those dependencies.
8. **Atomicity:** inject failure after parent, child, stock, ledger and source-update steps in separate cases. Compare the entire previous write set and source balances. An HTTP response lost after commit followed by an identical idempotency retry returns the same voucher without duplicate material or ledger postings.
9. **Lock/date and rights:** locked period, stale version, duplicate identities, missing source, wrong family, ambiguous MFG_MAST, unsupported mode, and invalid decimals fail before any persisted change. A view-only user can browse but cannot create/edit/delete; create-only cannot overwrite. Test real runtime role with forced RLS.
10. **Reports:** chosen lot/WIP/karigar/stock reports agree with transaction source records after every transition. Include component lot balances, material/fine, returns, breakage and financial rows. Report correctness is additional evidence, not a replacement for the operator journey.
11. **Actual browser:** real login and configured book selection; source picker resolves duplicate labels with provenance; two partial saves; reload unchanged equality; invalid draft retained; stale conflict shown; delete/reversal; narrow/wide viewport grid containment; keyboard navigation to/from nested child fields. Assert no page error and no mocked API.
12. **Paired desktop execution:** run the same accepted fixtures against the pinned desktop; capture entered fields, configuration, before/after tables, reports and print artifacts. Record each mismatch with source/IL investigation. Do not update a golden expected value merely to make the web output pass.

Run focused tests first under the existing disposable 55433 wrapper; coordinate its DB slot. Once all product changes are integrated, root runs strict test types, lint, production build, the full API suite without manufacturing exclusions, actual browser and evidence/checkpoint validation. Include evidence paths and hashes, source hashes, exact configuration profile, commands/outcomes, write-set comparisons, screenshots and remaining branches in the new X23 manifest.

## Explicit unsupported branches and closure limits

- MFG_IDTL.ITM_LOT metadata and effective mode/direction/final stock projection are unresolved prerequisites to production lot writes at this checkpoint.
- Ledger-enabled lot mode, special-registration overrides, with-order and one-form modes require independent reachable-branch and accounting contracts. Do not advertise ledger parity merely because a generic ledger helper exists.
- Polish, GHAT, filling, prepolish, nakshi, mino, jadtar, general karigar/jobwork, free/order-based variants and melting are not covered by the proposed Setting slice. Trace their actual menu callers and distinct weight/purity/return formulas separately.
- Source selection has piece-based, weight-based, previous-stage/current-stage and material-stock variants. Only the specifically implemented and verified selector profile is supported.
- Component rows omitted by desktop nonzero save guards, serials over 100, imported hidden values, cross-year broad SQL, and partial-source REP_ADJ resets require explicit preservation/discrepancy decisions; destructive behavior must not be copied silently.
- Source-defined numeric leave/keyboard rules, labour/taxes/payment/received rows and print layouts still need field-by-field contracts. This scoping document does not resolve every formula in TR_MFG_WITH_LOT.
- Order/design/image transfer into manufacturing, reissue/rework/stage completion, tagging, delivery/sale, image migration, multi-input/output melting, production migration totals and business acceptance remain X23/X11/X18 and plan-wide closure gates.

Close this proposed descendant only when its supported Setting profile has the full operator, material/financial, concurrency, read/edit/delete, browser and paired evidence. Keep X23 open until every required manufacturing variant and the complete manufacturing business day satisfy the plan's common six-part evidence contract.
