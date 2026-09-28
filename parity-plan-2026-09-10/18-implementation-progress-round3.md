# Implementation continuation — 11 September 2026, round 3

This continuation follows [round 2](16-implementation-progress-round2.md). It implements further descendants of [the mandatory execution plan](12-execution-addendum.md), while retaining all original acceptance requirements. Documents 15 and 17 and their completed evidence remain historical, immutable checkpoints. Full execution-card, package, menu and production acceptance remain open.

## Implemented paths

### X11 — Design Book repeat and keyboard events

Parent and component repeat are explicit, non-calculating events. The browser and server use the same ordered event representation, while the API resolves allowed repeat columns and item defaults from its own scoped data. `COL_RPT` matches the effective renamed header, including hidden supported columns. Reserved identities and image keys are never copied as an accidental consequence of repeating values. A parent repeat captures the previous row's values when the new row is created; subsequent edits to the previous row do not retroactively change the copied snapshot. Component repeat stays within its owning parent.

The grid supports the measured Weight Enter, child-item return and child-net-amount transitions. Source ordering matters: Weight Enter examines the previously committed weight before the typed cell is committed. Invalid input retains the draft and focus. Lookup selection advances only after the owning workflow validates and obtains scoped defaults. Other `LookupPicker` consumers retain their existing advance behavior.

The replay API distinguishes an explicitly keyboard-cleared numeric cell, which follows desktop `Conversion.Val` zero in the calculation event, from a manually submitted invalid numeric value or a saved imported NULL. This distinction was exposed by a database regression and fixed without weakening ordinary input validation.

Required follow-through remains: every remaining focus/prompt branch and configuration combination; downstream Design Book selection into orders and manufacturing; independent desktop execution; and explicit business acceptance of the previously documented loss-prevention differences. Passing these selected repeat cases does not close X11.

### X05/X14/X25 — saved order images and image reports

The two image templates, `OrdVchImg` and `TourOrdImg`, now have explicit recovered report contracts. A saved order with parents and company `ORD_IMG_PRINT=Y` selects its family-specific image template; parentless orders still use `OrderVch`. Both the form confirmation and generic report render routes pass the bound images to the renderer. The binder rechecks the selected company flag within its repeatable-read snapshot and refuses a template/setting disagreement.

Each saved parent receives one resolved image or an explicit absent state. The renderer places a single image in Section17.Field22 after that parent's children. A genuinely absent image retains the source's blank image band. A malformed or unavailable known image refuses printing with a diagnostic. Large documents paginate without repeating the photo for every child; an oversized single parent group is explicitly refused pending its further layout contract.

The resolver follows the saved identity and family-specific precedence:

| Image kind | Owned identity | Selection and limits |
| --- | --- | --- |
| Design Book | Tenant/company, branch blank, saved `DESIGN_IMG_ID`, instance 0, type D | Sales prefers a usable linked design. Tour can use it after its local tag/custom candidate. A bare design number is not a substitute. |
| Tag | Tenant/company/branch, saved tag number and exact saved `VCH_SRNO`, type T | Persisted `TAG_NO='N'` is the desktop no-tag sentinel and becomes an empty grid tag. It must never resolve a shared image named N. |
| Custom order design | Tenant/company/branch, entity ORDER, JSON `[year,book,HD_VCH_NO,designNo]`, instance 0 | Repeated copies of the same design in the same hidden order share the source image; other books, years or hidden orders do not. Header and parent hidden identities must agree. |

Sales preserves the source distinction between explicit design sentinel N and imported blank image IDs. New Sales draft rows now initialize N; the API also supplies N when a new row omits the field. Existing imported blank/null values are not relabeled into master/custom ownership. The source read at `TR_SALE_ORD:8678` and write at `:9208` establish the independent no-tag sentinel above.

`ENTITY_IMAGE.ENTITY_KEY` is widened from 30 to 255 characters by migration `20260911030000_order_image_identity`. Existing keys are retained byte-for-byte; lossy historical bare-design uploads are not automatically assigned to an order. Saved images are decoded as complete JPEG/PNG data using a direct Sharp dependency, a 4 MB byte limit and a bounded pixel read. Metadata inspection alone is insufficient to establish a valid image; see [Sharp input documentation](https://sharp.pixelplumbing.com/api-input/) and [output documentation](https://sharp.pixelplumbing.com/api-output/).

The Sales and Tour forms now use their own saved-order image routes. A request supplies a voucher and saved parent serial; the server resolves the image key from that saved row. Upload/delete lock the saved parent and require the selected identity token. Permissions are the owning form's View, Edit and Delete rights. Metadata returns separate update/delete capabilities, and a Tour fallback master image does not appear deletable as a nonexistent custom image. Shared Design Book image changes are directed to Design Book. This differs from the desktop's ability to overwrite a shared image from an order form and remains an explicit acceptance item.

The image editor preserves scope across late loads, file chooser and camera callbacks. Missing indexed bytes or corrupt stored bytes show a diagnostic and can be replaced under a valid editable identity. Printing still refuses the same unavailable bytes. TAG replacement/removal maintains its index in the same transaction. The identity token detects a changed saved parent identity; it is not an optimistic revision token for concurrent replacement of the same photo. That additional conflict/retry requirement remains open.

Saved-order edits also preserve the original tag number and instance. Older clients that omit these read-only fields inherit the saved values. Assigning a new tag, changing its instance, or deleting/remapping a tagged parent is refused until the corresponding stock transition is implemented. This fixes a previously destructive unchanged edit that reconstructed the no-tag sentinel. Both image editors now ask for the source-equivalent delete confirmation and recheck the selected identity afterward. A browser cancellation sends no DELETE and retains the stored bytes; acceptance performs the actual deletion.

The new contracts expand the report registry to 28. All 79 previously contained inferred report names remain contained; these counts are inventory, not a report-parity percentage. Four review PDFs span nine pages with genuine portrait/landscape images. Exact Crystal output, real cameras/printers, production image-volume performance, historical image database/file transfer and all other reports remain open. See [the image report contract and evidence](../web/docs/parity-evidence/X25-order-image-report-round3-2026-09-11.md).

### X23 — Setting lot read and source selection

The web now has separate Setting Isu and Setting Rec pages with their own rights and configured book families (`MFG STNG ISU`, `MFG STNG REC`). Each exposes settings, paginated saved browse, full saved parent/component/movement/stock views and the verified material-source selector. Their endpoints are `/mfg/lot/{issue|receive}/settings`, `/list`, `/sources`, and `/:vchNo`.

Saved rows preserve exact decimals, dates, timestamps, blanks, NULLs and original serials. Current scoped account/item names are additional display labels; they do not replace historical saved values or change a saved snapshot/version when a master name changes. Ambiguous current names remain unresolved. Exact imported voucher identifiers up to the physical eight-character width are reachable. Short numeric input pads to the conventional five characters only if its exact persisted key does not exist.

Setting Issue's verified material selector requires a nonblank material lot, no tag and positive gross availability from fully scoped stock contributors. Setting Receipt's verified material selector uses the source's pieces-based outstanding test and requires both the karigar account and an explicit eligible Setting Issue book. It retains source branch/year/book/voucher/serial/account, material lot, item/process and individual contributing identities. Source lists are advisory reads and do not authorize consumption.

The missing component lot DDL was found in primary `Ac_Image.CoFieldAdd` and independently confirmed in the original executable. Migration `20260911040000_mfg_component_lot` adds `MFG_IDTL.ITM_LOT` and `ITM_LOT_AC_CODE` as VARCHAR(10), NOT NULL, default blank. No parent lot is copied into a child. The already installed nullable VARCHAR(15) `MFG_ISU_REC.ITM_LOT` is represented in Prisma without shrinking or rewriting existing values. See [the source contract](evidence/implementation-2026-09-11-round3/x23-lot-read-source-contract.md) and [pinned schema evidence](evidence/implementation-2026-09-11-round3/x23-component-lot-schema-source.json).

**Setting writes remain unavailable.** Effective installation mode, configured movement direction, every writer/projection, partial receipt/conservation, versioned edit/reversal, source contention and physical desktop comparisons must be completed before enabling them. Generic MFG Issue/Receive permissions or projections are not substitutes for these Setting workflows.

### X15 — credit-note header ledger schema

The previously missing `SL_DATA.LDR_CODE` definition was found in primary `MS_OPNCOMP:5709` and confirmed as an exact UTF-16 literal in the original executable at offset `0x12971c6`. Migration `20260911050000_sale_header_ledger` adds VARCHAR(10), NOT NULL, default blank. Scoped E Credit Note reads now retain the actual imported override and distinguish it from the blank group-ledger fallback. The existing field descriptor displays it.

The migration cannot reconstruct overrides previously discarded by import; those require source reimport/reconciliation. The dedicated E Credit Note writer remains unimplemented. Its TCS/TDS direction, negative round-off anomaly, complete accounting/Rojmel/stock/tax writes and provider mutation barriers remain mandatory. [Pinned source evidence](evidence/implementation-2026-09-11-round3/e-credit-ledger-schema-source.json) replaces the earlier missing-DDL investigation dependency; it does not replace the writer or business acceptance.

### X02 — nested request measurement

The dead-cell audit now traces the wholesale source fields through the actual POST `/rate-cut` request, its `sourceRef`/`isuRef` aliases, the route's forwarded lines and the called writer's `ref` into `ISU_YRCD`, `ISU_DBCD`, `ISU_NO` and `ISU_SRNO`. Runtime AST reads exclude comments and type-only declarations. Fixtures require the called writer rather than an unrelated exported reader and reject unused/overwritten mappings. Unsupported dynamic transforms remain explicit.

The audit also implements its previously missing unmapped-registry discovery. Three real quotation/consignment pages add 106 checked columns. It now checks 712 columns on 21 actual registry pages within 23 configured mappings. This is a bounded static audit. It does not prove every field's value through browser, database, reader, reports and reversal, and it must not be converted into a functional completion percentage.

## Verification record

The final coordinated runs below completed against the isolated PostgreSQL stack with a non-owner application role and forced tenant RLS. The final image-confirmation change affects the web only; all 491 captured API/core/database inputs remain identical to the full API run. Focused runs overlap these totals and are not added to them.

| Check | Result | Evidence in `evidence/implementation-2026-09-11-round3/` |
| --- | --- | --- |
| Full API regression | 216 files, 1,674 tests passed, no skips | `api-full.txt` |
| Core regression | 6 files, 87 tests passed | `core-tests.txt` |
| Web regression | 20 files, 99 tests passed | `web-tests-delete-confirmation.txt` |
| Production build | 7 tasks passed | `build-delete-confirmation.txt` |
| Workspace lint/application types | 10 tasks passed | `lint-and-types-delete-confirmation.txt` |
| Strict API test types | Passed with the repository's configured 6 GB compiler heap | `test-types.txt` |
| Real browser integration | Passed, zero mocked requests | `browser-delete-confirmation.txt` |
| Static measurement fixtures | 26 tests passed | `scanner-tests.txt` |
| Dead-cell request tracing | Passed: 712 columns, 21 actual registry pages, 23 mappings | `dead-cells-final.txt` |
| Completion register | 198 mapped menus remain implemented-unverified; zero accepted | `register.txt` |
| Kernel adoption gate | Still fails: 127 rounding helpers against 108 | `kernel-gate.txt` |
| Depth gate | Still fails: 101 unreachable fields against 96 | `depth-gate.txt` |

The final actual-browser artifact is `web/test-results/parity-real-stack-round3-delete-confirmation/result.json`. Its journeys cover Design Book (8 checks), Design calculations (14), repeat/keyboard (14), Tour Order (16), credit-note browse (5), saved order images (11), and Setting lot reads/sources (8). These selected journeys use synthetic scoped fixtures and do not constitute whole-product or independently observed desktop acceptance. The older mocked smoke run passed as compatibility evidence only. Four image-report PDFs and their nine rendered pages received visual review; real Crystal and physical output remain open.

Both earlier failed browser runs are retained: the first exposed an oversized test design number against the real VARCHAR(15) column; the second exposed an incorrect expected HTTP status for malformed image bytes (the route correctly returns 422 and retains the old image). Visual review also found Design toolbar clipping despite passing workflow assertions. The page layout and the browser bounds assertion were corrected before the final passing run. Documentation reference checks and seven checkpoint-chain negative controls pass. No kernel/depth ceiling, accepted menu count, or business acceptance baseline was raised.

The complete prior checkpoints remain immutable. The current validator will chain document 19 to the exact bytes of 17 and verify 17's original link to 15. Positive and negative controls preserve omission, stale-source, missing/tampered predecessor and changed-artifact rejection. No acceptance baseline is raised.

## Next required implementation

1. Finish X11's downstream Design Book transfer. Follow [the exact Sales F1 selection contract](evidence/implementation-2026-09-11-round3/x11-design-to-order-next-contract.md): it selects by item/product, copies design/size/karigar/image, and applies eligible nonzero defaults only to new rows. It does not copy gross weight or DESIGN_IDTL into the order. Preserve existing order children and identities; trace manufacturing selectors separately. Verify two parents with different specifications, unchanged reopen, selective refresh and an independently observed desktop run. Do not infer transfer from the existence of Design Book fields alone.
2. Continue X14's later tax/MRP/visibility passes and each tender/received-metal/allocation write set. Complete tag selection/reservation and identity-changing edits before enabling those mutations. Then implement partial delivery, conversion, cancellation/refund and exact residual restoration, including contention, retries and final reports.
3. Implement X15's dedicated versioned writer using the now-proven ledger override schema. Resolve the source financial anomalies through independent observations and record any accepted correction. Provider pending/submitted/retry/cancel state and a mutation barrier must precede edits/deletes alongside submission.
4. Continue X23 from the saved read/source contract. Establish effective desktop installation mode and reconcile the deliberate installed width differences. Freeze expected posted rows before implementing Setting issue, then partial receipt, edit and reversal. Preserve parent lot, component material lot, lot-account and complete source references as distinct identities.
5. Complete image transfer provenance: source file/image-database inventories, exact desktop image IDs, verified bytes, collision/missing manifests and reconciliation. Add concurrent same-photo replacement/retry behavior, actual device capture and Crystal/physical output acceptance. Continue all remaining X25 templates individually; do not remove existing report containment in bulk.
6. Continue X18–X21 contained tag operations and the remaining X07–X10, X12–X13, X16–X17, X22, X24, X26–X29 families. The bounded scanner result does not waive their runtime paths. Complete X30 historical migration/rehearsal, X31 recovery/service behavior, X32 supported variants and X33/X34 full-product certification.

All 34 execution cards, 83 original packages and 198 menu acceptances remain open for their complete requirements. Whole-product functional/workflow percentage remains unmeasured. Passing selected engineering tests does not establish full desktop replacement.
