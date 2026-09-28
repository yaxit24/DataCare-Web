# X25 next contract — OrdVchImg and TourOrdImg

Read-only source trace during the round-2 freeze. **Neither image template is implemented or accepted by this record.** Keep both selected-image refusals until the following contract is implemented and verified. No image identity should be guessed from a bare design number or filename.

## Exact report evidence and reuse

- `../extraction_output/rpt_xml/OrdVchImg.xml` and `TourOrdImg.xml` both contain **16 main sections, 93 main objects, the same 22 main formulas, the same main layout and the same independent `OrdRec` subreport**. Direct XML comparison confirms that their main report/formula/print-option/subreport trees are identical.
- Compared with `OrderBill.xml`, their main layout difference is that **GroupFooter `Section17` is visible**. Its one `BlobFieldObject`, `Field22`, is at left 1440 / top 0 / width 2175 / height 1680 twips. The section height is 1680; `EnableSuppressIfBlank=False` and `EnableKeepTogether=True`.
- The XML omits a `DataSource` attribute on that blob object. Its database definition supplies the missing source evidence: **`IMAGE_DATA.TAG_IMAGE` is the only blob field, with `UseCount=1`**. Record this explicit object-to-field contract when extracting; do not generalize “first blob field” to unknown templates.
- The legacy `LeftOuter` image link is `SL_ORD_DETL.(CO_CODE,LC_CODE,SR_NO,DESIGN_NO)` to `IMAGE_DATA.(CO_CODE,LC_CODE,SR_NO,DESIGN)`. It omits year/book/voucher because the desktop first deletes the company's branch image staging rows and stages only the current document. A shared web server must not reuse this cross-document staging assumption.
- Reuse the recovered order header/parent/component/received-metal/ledger/copy contracts and decimal totals. Group order is parent `Section10`, actual child `Section5`, image footer `Section17`, remark footer `Section8`; the image must render once per parent, not once per child.
- Both image variants' `@ItemName` is **always** `ITEM_MAST.IT_NAME + ' Dsgn : ' + SL_ORD_DETL.DESIGN_NO`. The tag-prefix conditional belongs only to non-image `TourOrdVch`. This trace also identified and prompted the round-2 correction to non-image `OrderBill`.
- Both image variants have the same four source `OrdRec` links as `OrderBill`; retain the web's additional branch scoping.
- Original binary reports are present at `../DataCareSetup_extracted/DataCareNextS/Report/{OrdVchImg,TourOrdImg}.rpt` and `../unified/reports/`. Exact Crystal bitmap scale/crop behavior is not exposed in the XML blob object; confirm against the original runtime before asserting pixel parity.

## Desktop image provenance and routing

**Selection:** `TR_SALE_ORD.cs:9815–9818,9877–9910` and `TR_TOUR_ORD.cs:7980–7997` select `OrderVch` when no saved parents exist. With parents, `CO_SET_NEW.ORD_IMG_PRINT=Y` selects `OrdVchImg` for Sales Order or `TourOrdImg` for Tour Order; otherwise select the non-image variant. `MS_OPNCOMP.cs:948,981,1140–1142` reads this company setting and defaults blank to N.

**Sales source:** `TR_SALE_ORD.cs:9316–9370` stages image bytes during save, when the flag is Y. It picks the design image ID when that field is not the N sentinel; otherwise it uses tagged item `TAG_NO + '_' + VCH_SRNO`; otherwise it uses the custom order design filename `DESIGN_NO + '_' + CO_CODE + LC_CODE + CO_YEAR + CO_BOOK + HD_VCH_NO`. Existing local bytes are copied into `IMAGE_DATA.TAG_IMAGE` with current company/branch/book/voucher/parent serial/design. `TR_SALE_ORD.cs:10171–10262` resolves the preview from local files, then mobile image data or configured HTTP source. `11600–11643` shows base64 `MOB_IMAGE` writes to the separate image database.

**Tour source:** `TR_TOUR_ORD.cs:7798–7950` stages on print. It first tries the tag-instance or custom-order filename. If absent, a usable saved `DESIGN_IMG_ID` resolves the design mobile image; other paths try configured HTTP/local/mobile sources. It clears/stages `IMAGE_DATA` for the branch. `8190–8240` also shows design-image preview being copied into a tag/custom-order local cache. These cache paths mean an existing explicit order/tag image can take precedence over the reusable design picture. Source cache/fallback quirks require desktop fixtures before claiming exact precedence in ambiguous legacy cases.

**Saved keys:** grid column 42 is persisted `SL_ORD_DETL.VCH_SRNO`; column 71 is `DESIGN_IMG_ID` (`TR_TOUR_ORD.cs:6973,6980,7425,7445`; Sales writer around 9262/9297). `HD_VCH_NO` is a saved hidden voucher identity (`TR_TOUR_ORD.cs:6804,7287,7368`; web `salesOrder.ts:562,582,638`). It is not interchangeable with visible `VCH_NO` or parent `SR_NO`.

**Design master image ID:** `MS_DESIGN_BOOK.cs:4697,5242` builds `CO_CODE + '_' + BOOK_NAME + '_' + PR_CODE + '_' + DESIGN_NO`. This is company-wide, not a branch-specific bare design number.

**Two databases:** `DC_Main.cs:1242` executes `OpenRecordSetImg` against the separate `Img` connection. `MS_UPDATE.cs:8995–8999` creates its `TAG_IMAGE_DATA` and adds `MOB_IMAGE nvarchar(MAX)`. The web's five-column `TAG_IMAGE_DATA` model omits that mobile byte source; comments calling every desktop tag table an index-only store are incomplete. Historical transfer must include the image database and/or authoritative file store.

## Existing web interfaces and missing contracts

| Existing part | Reuse / required correction |
| --- | --- |
| `ENTITY_IMAGE` byte store, `entityImage.ts` | Already holds bytes, detected JPEG/PNG MIME, size and tenant/company/location/entity/key/instance. Reuse bytes and validation; add a transaction-local read helper so report image reads share the order snapshot. Existing `getEntityImage` starts a new transaction. |
| `ENTITY_IMAGE` schema migration | Raw migration-owned table, absent from Prisma models. Its renamed `ENTITY_KEY` remains `varchar(30)`, while saved `DESIGN_IMG_ID` allows 50. Widen with a migration before accepting all valid design keys or a longer custom-order identity; retain the unique ownership tuple and RLS. |
| Tag image identity | Use exact tenant/company/branch + entity TAG + saved `TAG_NO` + saved `VCH_SRNO`, not order row serial or instance zero. Validate returned image type; `getEntityImage` does not include IMAGE_TYPE in its SQL predicate because it is an attribute, not part of the unique key. |
| Design Book image route | `/masters/design-book/image` fixes entity DESIGN, key to saved `DESIGN_IMG_ID`, company scope (`LC_CODE=''`), instance 0, image type D and saved-parent validation. Reuse this identity for linked design images. |
| Current Sales/Tour order panels | Both pass entity DESIGN + **bare designNo** + instance 0 to default `/stock/tag-image`. That route supplies the active branch and defaults type T. These records do not share the Design Book identity. Replace with a form-owned saved-order image resolver/editor; do not silently relabel old ambiguous uploads as master images. |
| Current media permissions | `/stock/tag-image` belongs to Inventory/Tag Print. Order-only users should reach their own image operation under Sales Order or Tour Order rights. Keep print-only access sufficient to render already-owned report bytes without separately fetching a master-media URL. |
| `IMAGE_DATA` staging model | Has bytes but no year and no unique complete order key. Do not use its legacy branch-wide contents as report authority or delete a branch's images during GET/print. Build an in-memory scoped IMAGE_DATA alias per saved parent. |

There are three extracted JPEG files in `../extraction_output/nextimage` (`BLG00001`, `MSG00003`, `ORG00001`), but this trace found no authoritative mapping of those assets to a complete order identity. They are not evidence that the business image collection has been transferred.

## Implementation sequence

1. Extend the bounded XML extractor with exactly these two explicit names, source hashes, full independent subreport extraction and the proven `Section17.Field22 -> IMAGE_DATA.TAG_IMAGE` mapping. Preserve the three recovered non-image specs and all older contracts. Both new image names were outside the old 102-name inferred inventory; adding them does not reduce the old 79 contained names.
2. Define a typed server-side resolver from a **saved, fully scoped header and parent**. Support exact tag-instance and saved design-master identities first. For an order-specific non-tag image, the source identity is company/branch/year/book/**hidden voucher**/design; a proposed canonical representation is entity ORDER + JSON encoding `[coYear,coBook,hiddenVoucherNo,designNo]`, instance 0, with tenant/company/branch in existing ownership columns. This preserves the source's shared image for repeated identical designs within one order. Prove this mapping with desktop fixtures before using it for ambiguous legacy imports. Require save before attaching an order-owned image.
3. Add form-owned GET/POST/DELETE image routes accepting year/book/visible voucher/parent serial and resolving canonical keys from saved rows. Do not accept an arbitrary cross-company key from the browser. Reopen, replacement, delete and voucher lifecycle behavior need explicit rules. Keep master design mutation distinct from custom order image mutation.
4. Read image settings, chosen template and image bytes inside the same repeatable-read report operation, or revalidate selection in the binder and fail on a concurrent change. Parentless orders still select `OrderVch`; an image template under N must not silently override the configured choice.
5. Bind a typed optional image for each parent without joining image rows into the child dataset. Emit MIME-validated embedded bytes in HTML/PDF so rendering is deterministic and does not depend on a separately authenticated image request or a remote desktop URL. Enforce image byte limits and successful decoding before PDF creation; never treat a corrupt payload as a valid image.
6. Ordinary absent images retain the parent and the source's 1680-twip blank image section (`LeftOuter`, no suppress-if-blank). Do not insert a made-up picture. Distinguish a known import/index record whose bytes are unavailable from an image that was never attached; expose an explicit unavailable-image diagnostic. Exact warning versus refusal needs the import status contract, not an assumption based solely on `DESIGN_IMG_ID`, which can exist even when no image was uploaded.
7. Import historical files/mobile base64 through a manifest that carries provenance and complete owner identity, validates content and records unresolved collisions. Existing bare-design web images cannot be reassigned automatically when several master/order identities match. No filesystem or HTTP fallback should run inside routine printing.
8. Remove only `OrdVchImg` / `TourOrdImg` selected-image containment after the following evidence passes. Keep exact font/bitmap scaling/physical-printer and historical migration acceptance open until independently demonstrated.

## Required verification

- Two tenants, companies, branches, years and books reuse visible voucher, parent serial, tag number and design number; decoded bytes/hashes in each rendered parent must match its own saved source.
- Two tag instances of one tag have different images; duplicate designs in different hidden vouchers remain independent; repeated same-design lines within one hidden voucher exercise the documented shared-image behavior.
- A design key longer than 30 characters round-trips through the migrated store; ambiguous bare-design legacy uploads remain unresolved rather than selected arbitrarily.
- Test Sales design precedence, Tour existing tag/custom precedence and documented fallback with distinct visible image fixtures; retain both tag and design fields in the saved parent.
- Multiple component rows render one image per parent and unchanged parent totals. No-image parents remain printable with the correct blank band; malformed MIME, corrupt bytes, missing imported bytes and duplicate candidate matches have distinct explicit outcomes.
- Concurrent replace/delete/setting change cannot mix header/children/ledger from one snapshot with image bytes from another. Compare a subsequent print to the complete new state.
- Exercise family-specific image upload/reopen/replace/delete and print using a user with only that form's rights. Compare actual decoded output bytes and visible browser/PDF images, not response echoes or image tag counts alone.
- Use portrait/landscape/large/small source images, multiple pages and page-boundary parents; verify scaling, no clipped images, source section height, parent association and physical desktop output before exact layout acceptance.
