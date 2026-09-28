# Next bounded X11 task: Sales Order Design Book selection

Read-only scoping, 2026-09-11. No order product edits are included in this round's Design repeat work. This contract narrows the next implementation to an observed source handler; it is not a claim that all design transfers are the same across forms.

## Source-proven behavior

Source: `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs` in the extracted folder.

- Lines 7307–7317: F1 on order column 4 (Design) queries `DESIGN_DETL` joined through `PRODUCT_MAST` and `ITEM_MAST`. It filters current company and the current order line's item code, thus selecting only designs for that item's product. Sort order is book, design, source serial. `DM043NEDM` changes the displayed third column from product name to die/remark; it does not change the selected output ordinals below.
- The query returns design, book, product-or-remark, size, karigar, gross weight, touch, west percentage, labour percentage, labour rate and `DESIGN_IMG_ID`. Gross weight is displayed but **not assigned** by this selection handler.
- Lines 7337–7364: cancel returns without applying a row. A nonempty selected design assigns column 4 = design, column 6 = size and column 30 = karigar. Column 71 receives the selected design image ID.
- Only when column 53 is not `E`, a nonzero selected touch assigns column 14, nonzero west assigns column 15, and nonzero labour percentage assigns column 20, formatted to two decimals. If selected labour percentage is zero and selected labour rate is nonzero, column 22 receives the labour rate. A zero source default does not clear the corresponding current order value. This condition is based on each row's state, not only whether the overall voucher is new.
- Column 53 initializes to `A` at line 5551 and saved rows hydrate as `E` at line 8750. Adding a new row to an existing order therefore needs distinct handling from an existing saved row.
- A completed selection whose design is empty clears Design and sets image ID to explicit `N` (lines 7366–7370). Preserve the distinction between a canceled picker and an explicit cleared selection.
- The handler resets `MsgOldRow` and calls `MSG_RowColChange`. Lines 10121–10167 rebuild the child **view** from the order's existing `DtIdtl`, selected by order backing identity. They do not read `DESIGN_IDTL`, replace children with Design Book children, or change the parent/child saved identities.
- Lines 10169–10205 select/display the linked design image from its exact image ID under company and image type D. Saved order detail persists `DESIGN_IMG_ID` at line 9297 and hydrates it at line 8740. The round 3 order-image module already implements source selection/precedence for saved images.

Header declarations at lines 5268, 5276, 5328, 5331, 5337, 5343 and 5397 confirm the assignments' field names. Do not infer field names from column numbers on Tour Order, whose layout differs.

The inspected Sales Order and Tour Order forms contain no `DESIGN_IDTL` query in this direct selection path. Tour Order copies `DESIGN_IMG_ID` from a selected tag's `BAR_DETL` at line 6106 and loads `BAR_IDTL` afterward; that is a different tag-adoption workflow. A direct Tour Design Book picker requires its own additional source evidence before implementation.

## Current web surface

- `apps/web/app/(app)/txn/sales-order/page.tsx`: Design is a text input; no source-backed Design Book selection modal is present.
- `apps/api/src/modules/sales/salesOrder.ts`: `designNo`, `designImageId`, `itmSize`, karigar and labour/touch/west fields already have detail storage/read paths. `designImageId` is column 71; new rows use `N`, while explicit imported blanks and existing values are preserved.
- `apps/api/src/modules/images/orderImage.ts`: resolves the saved linked Design image under company, company-level location `''`, instance 0 and type D, with source-derived ordinary/Tour precedence. Use this contract rather than inventing copied files or image IDs.
- `apps/api/src/modules/masters/designBook.ts`: provides scoped Design Book storage and configuration, but not an order-specific item/product design browse/adopt contract.

## Implementation sequence

1. Add a bounded, paginated read service for Sales Order design selection. Input must include current item and order scope. Resolve the item's current company product on the server, then list Design Book parents by that company/product. Return an exact source identity `(company, product, book, SR_NO, OLD_SRNO)` plus selected display/default values, image ID and source version. Same design text in two books must remain distinguishable.
2. Add the route under Sales Order authority, consistent with the operator's create/edit rights. Decide the application’s source-master access policy explicitly with the root; do not accidentally require Tag Print or permit unrelated company data. Read privileges alone must not grant order mutation rights.
3. Add a pure selection helper whose inputs include row state (new versus hydrated), current values and selected source. Implement the exact nonzero and labour-percentage-versus-rate conditions above with the existing decimal/rounding semantics. It must preserve gross weight, pieces, unrelated row fields, child collections and all parent/child identities.
4. In the Sales Order Design input, expose an accessible picker and the source F1 shortcut. Bind requests and selection to document scope, current item and stable parent serial. Cancel is a no-op. Changing item/scope/selected row while lookup is pending must invalidate the response. Apply the chosen source only to the original active row and restore that field's focus.
5. Save/adopt through a server-verifiable source reference so the client cannot invent another item's design or image ownership. Re-resolve the source and detect stale/deleted sources before committing. Do not let selection replay overwrite later intentional edits: order the selection event and subsequent edits explicitly or otherwise preserve the same semantics.
6. Keep linked Design image ownership as a reference to the saved Design entity. Source selection does not upload, duplicate, delete or transfer ownership of that image. Resolve image preview through the existing order-image service after save; an unsaved preview needs a separately authorized Design read contract, not an arbitrary image-key endpoint.
7. Verify the ordinary-order calculation trigger that follows F1/field leave before adding any recalculation. The source F1 handler itself only assigns selected values and refreshes row/child/image context. It does not directly run a generic Design calculation or copy Design totals.

## Required fixtures and acceptance checks

- Two products/items, two books sharing the same Design text, noncontiguous Design source serials/old serials and existing order child serials 3/9. Select by full identity and prove the correct source/image/defaults while preserving the order identities and children.
- Cross-company and wrong-product/item source references fail. Deleted or edited source between browse and save is rejected/reconciled without a partially updated order.
- A new row receives nonzero touch/west/labour percentage. A second source with zero values leaves existing manual values intact. A zero labour percentage plus nonzero labour rate changes only the rate. Both percentage and rate nonzero applies percentage, leaving the prior rate untouched.
- A hydrated E row changes design/size/karigar/image only; it retains its numerical defaults. A newly added A row within that same loaded voucher receives eligible defaults.
- Source gross weight is visible in the picker but never silently replaces current order gross weight. Design components never replace order children in this workflow.
- Cancel preserves the entire in-memory draft and makes no request to save. Explicit clearing follows the source Design/image sentinel contract. Unchanged load/save remains exactly lossless.
- Empty imported image ID, explicit N, valid saved Design image and missing Design image each retain the round 3 precedence behavior. No arbitrary tag/custom image fallback is invented for ordinary Sales Order.
- Real browser: choose item, open picker by F1, select each duplicate-name design, verify new versus hydrated-row defaults, change scope during lookup, save/reload, assert complete parent/child write-set and linked image rendering. Use real API/database responses and capture the final view.

## Explicit unsupported branches

This task does not implement Tour tag adoption, manufacturing design issue, Design Book-to-tag generation, automatic copying of Design children, registration-specific alternate selectors beyond the proven display variation, or desktop/business acceptance for all production configurations. Keep those separate cards with their own source and identity contracts. No complete X11 or X25 parity claim follows from this picker alone.
