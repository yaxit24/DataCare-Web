# X25 round 3 — Sales/Tour Order images

Status: **partial implementation; coordinated full API, core, web, build and confirmation-inclusive browser checks passed**. `OrdVchImg` and `TourOrdImg` now have explicit source contracts, actual scoped saved-image bytes, the full main document and independent `OrdRec`. The image controls now select saved order parents rather than an unscoped bare design number. This is bounded engineering evidence, not complete Crystal, historical-transfer, physical-printer or business acceptance.

## Source and implemented contract

The immutable round-2 source trace is `X25-order-image-next-steps-round2-2026-09-11.md`. Its source citations remain applicable; this record implements the bounded image contract and preserves that prior record.

| Source evidence | Implemented behavior |
| --- | --- |
| `../extraction_output/rpt_xml/OrdVchImg.xml` and `TourOrdImg.xml` | Each complete main definition has 16 sections, 93 objects and 22 formulas, with its own independent `OrdRec`. Exact semantic spec hashes protect the registered contract. |
| `Section17.Field22`: one BlobFieldObject; sole used Blob database field `IMAGE_DATA.TAG_IMAGE`, UseCount=1 | The extractor records this explicit two-template mapping. It does not infer an arbitrary blob field for other reports. Image band geometry is left1440/top0/width2175/height1680 twips; the section remains 1680 twips when image bytes are absent. |
| Parent `Section10` → actual component `Section5` rows → image `Section17` → remark `Section8` | Each saved parent has an explicit present/absent image state. Parent totals never fan out through children. The renderer embeds validated JPEG/PNG bytes once per parent and keeps parent, components, image and remark together; an oversized parent group fails explicitly. |
| Both image templates' `@ItemName` | Item name plus design text, even when the parent also has a tag. The non-image `TourOrdVch` tag-prefix rule is not applied to these images. |
| `TR_SALE_ORD.cs:9316–9370,10171–10262`; `TR_TOUR_ORD.cs:7798–7950,8190–8240` | Sales resolves the saved linked design first when DESIGN_IMG_ID is not the explicit N sentinel. Tour resolves saved tag/custom bytes first, then linked design. Blank imported Sales design IDs retain the source's distinction from N. Known tag index without bytes is unavailable, not ordinary absence or permission to silently choose a different image. |
| `MS_DESIGN_BOOK.cs:4697,5242` | Design identity is the saved DESIGN_IMG_ID, company-wide LC_CODE='', entity DESIGN, instance0, typeD. The storage key is widened to255, preserving valid saved IDs longer than the prior30-character limit. |
| Saved TAG_NO/VCH_SRNO; saved header and parent HD_VCH_NO | Tag identity uses exact tenant/company/branch/tag/instance. Custom identity uses tenant/company/branch + entity ORDER + JSON `[year,book,hiddenVoucher,design]`, instance0. Identical designs in the same hidden order share the source image identity; another year/book/hidden order does not. Client filenames and arbitrary image keys are never accepted. |
| `MS_OPNCOMP.cs:948,981,1140–1142`; Sales/Tour print callers | Saved parent presence and CO_SET_NEW.ORD_IMG_PRINT select the source document. No parents still selects OrderVch. The binder rereads the flag and bytes in its existing RepeatableRead snapshot; a concurrent shape change produces explicit template mismatch. |

The TAG_NO value N is the desktop no-tag sentinel (`TR_SALE_ORD.cs:8678,9208–9215`); it is resolved as an empty tag before considering a custom or master image. New Sales rows initialize DESIGN_IMG_ID to N (`TR_SALE_ORD.cs:5558`), while imported blank/null values retain their distinction from N.

The resolver never reads or rewrites branch-wide legacy `IMAGE_DATA` staging and never fetches external desktop URLs during printing. Valid image bytes must pass MIME/signature, declared size, 4MB maximum and a complete Sharp decode with a 25-million-pixel ceiling. Prisma's Uint8Array byte results are normalized before validation. HTML and PDF use embedded bytes, so no subsequent authenticated image request can select another scope or snapshot.

## Form-owned image workflow

- GET/POST/DELETE `/sales-orders/:vchNo/image` and `/tour-orders/:vchNo/image` require the corresponding form's view/update/delete permission. Read payloads expose separate `canUpdate` and `canDelete` capabilities. Shared Design Book images are shown read-only from the order, with a direction to change them in Design Book.
- The server resolves the locked saved parent on writes and checks its identity token. The client submits only full voucher scope, saved parent serial, version, MIME and data. An identity changed after loading is rejected.
- Tour follows the selected hydrated parent's persistent serial, rather than its array position, tag instance or a recent-order table index. New or unselected documents have no image owner. Saved revision and scope changes clear pending display state.
- Sales currently has a create form rather than complete saved-document hydration. A separate configured Sales Order book, saved voucher lookup and saved parent selector now supplies image ownership. This addition does not claim that the broader Sales edit workflow is complete.
- The panel guards loaded responses and asynchronous file/camera work by full identity and request generation. An in-flight operation retains the selected saved endpoint; a file read that completes after changing rows does not create a new POST. Camera capture uses the existing live camera hook and the same upload validation.
- An unchanged imported order edit now preserves its saved TAG_NO and exact VCH_SRNO; the former writer incorrectly replaced every parent tag with N. The read DTO and Tour hydration carry the immutable tag. Ordinary editing rejects assigning/changing a real tag or instance and deleting/remapping a tagged parent, because that stock-allocation transition is not implemented here. Omitted read-only fields on older complete-component clients preserve the saved identity. This does not certify all tag-stock workflows.
- A Tour fallback master remains visible when no custom image exists, but Delete stays disabled for that absent custom target. Select may create the authorized custom override.
- Both desktop image-delete handlers request confirmation (`TR_SALE_ORD.cs:11668`, `TR_TOUR_ORD.cs:9559`). The shared web panel now confirms before issuing DELETE and rechecks saved identity/request generation after the prompt. The real-browser vector cancels first and verifies no DELETE and unchanged saved bytes, then accepts and verifies actual deletion.
- For UI reads only, a known missing import or damaged stored image returns an unavailable diagnostic with the verified saved target and capabilities. An authorized operator may replace/delete that target. Report resolution continues to refuse unavailable or invalid bytes until repaired. Ambiguous or invalid order identities continue to fail.

## Verification record

Focused runs overlap the coordinated suite and must not be added as unique coverage:

| Run | Result |
| --- | --- |
| `orderImageReport.test.ts` + `orderReport.test.ts`, isolated test environment loaded without provisioning/writes | 2 files / 21 tests / 0 skips passed. |
| Isolated wrapper: `orderImageReport.db.test.ts orderImageReport.test.ts orderReport.db.test.ts orderReport.test.ts reportBind.test.ts` | 5 files / 68 tests / 0 skips passed. This prior run had4 new image DB tests; a fifth stronger custom year/book identity vector was added for the final suite. |
| Final focused wrapper: `tourOrderHydration.db.test.ts orderImageWrite.db.test.ts tourOrderPrint.routes.db.test.ts orderImageReport.db.test.ts` | 4 files /31 tests /0 skips passed. Includes imported tag preservation/rejected transitions, source N sentinel,7 image service tests,5 HTTP permission tests and5 image report DB tests. |
| Tour form hydration unit test; API source typecheck after tag preservation | 8 unit tests passed; API typecheck passed. |
| API-only TypeScript build; web strict typecheck; targeted React hook lint | Passed. |
| `node scripts/render-order-image-report-review.mjs` and direct CoreGraphics PDF rasterization | 4 PDFs / 9 actual PDF pages; all image decodes, parent association, band extent and footer geometry checks passed. Every PDF page was visually inspected. |
| Coordinated full API | 216 files / 1,674 tests / 0 skips passed. Includes the final imported-tag preservation, image service, report and HTTP rights vectors. |
| Coordinated core and web tests | Core: 6 files / 87 tests passed. Web: 20 files / 99 tests passed, including the final Design toolbar correction and confirmation-inclusive rerun. |
| Coordinated production build, lint/types and strict API test types | Build: 7 tasks passed; lint/typecheck: 10 tasks passed; strict API test types passed. The confirmation-inclusive rerun also passes all 7 build tasks, all 10 lint/typecheck tasks and all 99 web tests. API sources remain unchanged from the full API run. |
| Real browser against actual API/database | The final confirmation-inclusive combined journey passed with 0 mocked API responses and all 11 image workflow checks. See `browser-delete-confirmation.txt` and `test-results/parity-real-stack-round3-delete-confirmation/result.json`. |

Database fixtures contain distinct genuine portrait PNG and landscape JPEG bytes. They cover Sales versus Tour precedence, exact tag instance, identical visible voucher/design across tenant/company/branch/year, zero children and multiple distinct children, ordinary absence, indexed missing bytes, signature-only malformed payload, and a concurrent image/setting update observed under one snapshot. The additional final-suite vector explicitly stores different custom bytes under complete year/book/hidden/design identities.

The form HTTP test uses separate Tour view-only, update-only, delete-only, print-only and Sales-only users. Existing authorization requires view plus print; the initial new assertion that print alone permits printing was wrong and corrected to403. The failed focused parent log remains retained. No permission policy was loosened.

The browser also asserts the initial Sales row N default. A complete new Sales UI creation is not claimed here: that existing form still lacks configured create-book and voucher-date selection; the image workflow uses explicit saved records.

The new `order-image.journey.mjs` uses the real app, real login/session and actual bytes. It checks shared master read-only controls, saved Sales custom upload/read/delete, Tour tag precedence and replacement, malformed upload rejection, a deliberately delayed real File read during parent selection, actual image-bearing print output, network-delayed book switching, repair of an unavailable imported image and non-deletable fallback master ownership. API responses are never replaced. The final confirmation-inclusive run records all 11 image workflow checks and 19 browser image requests; the cancel/accept check also verifies stored bytes through a fresh API read.

Prior failures remain available under the parent round-3 evidence directory. `browser-real-stack.txt` reached image seeding and rejected a 17-character synthetic DESIGN_NO against the actual 15-character source column; the fixture was corrected to `ORD-DESIGN-0001`, without widening that column. The separate Design Book visual review also found and corrected toolbar/table overflow. `browser-toolbar-fixed.txt` then reached malformed-image upload and exposed an incorrect harness expectation of HTTP 400; the implemented typed image-error contract is HTTP 422. The corrected assertion verifies `OrderImageError` / `invalid-image`, its decoder message, unchanged saved bytes and the unchanged visible image. No application error contract or assertion was loosened. `browser-verified.txt` preserves the succeeding combined run before the final confirmation addition.

## Visual review and open acceptance

The source image rectangle uses aspect-preserving contain sizing. Portrait and landscape fixtures decode visibly and remain associated with their parent on all tested pages. Ordinary absence retains the source blank image section. The18-parent fixture occupies6 pages; its last payment section can flow alone to the final page because source group-footer areas permit section breaks. This is explicitly recorded for desktop/physical-printer acceptance. No arbitrary source grouping change was made to hide that pagination difference.

The three real-browser screenshots show the Sales shared master read-only state, Tour custom image and repaired missing-import image. Saved voucher/parent ownership, source labels, image previews and controls are readable without clipping within these panels at the tested 1600×1000 viewport. The final Sales screenshot is byte-identical to its reviewed predecessor; both final Tour screenshots were inspected again and retain the same readable image panels. All five compiled report runtime hashes still match the independently reviewed PDF manifest after the final API build. The final confirmation changes no report/API code or PDF inputs.

Open work remains:

1. **Historical image transfer.** Source separate Img connection and `MOB_IMAGE nvarchar(MAX)` (`DC_Main.cs:1242`, `MS_UPDATE.cs:8995–8999`), authoritative file stores, import manifests, collisions and unresolved owners must be transferred and reconciled. Three extracted JPEGs without authoritative order ownership are not proof of complete image migration. Old bare-design web uploads are not automatically relabeled.
2. **Desktop golden and device acceptance.** Compare exact Crystal bitmap scale/crop, font/locale, object borders, page allocation, printer paper/margins, camera devices and business-approved examples. XML does not expose all bitmap behavior. No physical device or desktop runtime golden was used in this slice.
3. **Shared master editing difference.** Desktop order image editing can modify the shared master file. Web order controls require the user to change that image through Design Book and its rights. An approved alternative may permit the same action from the order only with additional Design Book update permission.
4. **Lifecycle and import policy.** Agree historical orphan/custom-image retention and cleanup, repaired-source provenance, duplicate saved design identities and unusual remote/mobile cache fallback cases. This slice does not run a live-business image migration.
5. **Carry-forward gaps.** Historical ledger timestamps already truncated to dates require reimport; full copy/data-type dialogs, remaining report families and all earlier business acceptance tasks remain open.

The new inventory has **28 registered dataset/document contracts and the same79 contained former inferred reports**. The two image variants were outside the old102-name inferred inventory. The inventory contains107 records including the5 source-recovered order reports; these counts are not an overall parity percentage.

<!-- not-retained: test-results/parity-real-stack-round3-delete-confirmation/result.json -->

The run output `test-results/parity-real-stack-round3-delete-confirmation/result.json` was written to the gitignored `test-results/` directory and is not retained in the repository.
