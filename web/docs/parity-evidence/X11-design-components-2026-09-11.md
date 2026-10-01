# X11 design parent/component lifecycle — implementation evidence

Status: **partially implemented; engineering verification passed for this slice; X11 remains open**.
Parents: P03-03, X11. This document does not certify desktop parity or business acceptance.

## Frozen source references

Baseline: `unified/src/csharp/DataCareNext/MS_DESIGN_BOOK.cs`.
SHA-256: `abde981d2825b4fc621a21c92305d36aea99aa3248d8f02f6d5e8644486cf9e3`.

Schema evidence: `unified/src/csharp/DataCareNext/MS_UPDATE.cs`.
SHA-256: `943525d918df85170ee3a4733bdf81cdc1d5b7e61b5efed27add7bc2883d8cb7`.

| Source location | Contract or finding | Implementation/evidence |
| --- | --- | --- |
| MS_DESIGN_BOOK:4447–4536 | Read parents by company/book/product; children sorted by SR_NO/ISR_NO; item name is an ITEM_MAST display join | Reader loads both persisted tables with explicit tenant/company/book/product predicates; nests actual children by SR_NO |
| MS_DESIGN_BOOK:2130–2142, 4718–4735 | Hidden parent serial identifies ownership; SR_NO and ISR_NO must survive visual movement | UI stores immutable serials, allocates increasing draft serials, and sends existing identities; writer validates duplicate/invalid serials |
| MS_DESIGN_BOOK:4652–4701 | Parent business fields include ITM_STYLE, saved date and DESIGN_IMG_ID | Parent preservation plus style schema restoration; omitted business fields survive legacy requests |
| MS_UPDATE:6721 | ITM_STYLE is VARCHAR(50) NOT NULL DEFAULT '' | Migration `20260911010000_design_detail_style`; writer validates width50 and handles blank style |
| MS_DESIGN_BOOK:4730–4751 | Persist every component field listed below | Component input, atomic writer and reader; dedicated child editor; full field DB assertions |
| MS_DESIGN_BOOK:4730–4751 | Component writer does not set DESIGN_NO | New child DESIGN_NO remains null; existing historical child DESIGN_NO is retained |
| MS_DESIGN_BOOK:4795–4796 | Book deletion removes both DESIGN_DETL and DESIGN_IDTL under company/book/product | Full-key transactional delete; parent removal during save removes owned children |
| MS_DESIGN_BOOK:4699, 5242–5244, 5477–5496 | Photograph name is company_book_product_design; desktop file image is shared by this identity, while mobile index also includes current LC_CODE | New parents receive composite DESIGN_IMG_ID; existing IDs retained. Dedicated image route validates a saved parent and uses DESIGN/D storage. Branch-index migration remains open |
| MS_DESIGN_BOOK:5340–5365 | Image deletion is a separate operator action | Book deletion retains image bytes; dedicated image deletion deletes saved photograph. No silent bulk media deletion |

Parent natural key is `(tenant, CO_CODE, BOOK_NAME, PR_CODE, SR_NO)`.
Child natural key adds `ISR_NO`. Design number alone is never used to join children.

## Field path matrix

All fields below travel through `lib/designBookDraft.ts` → Design Book page → POST/PUT route →
`modules/masters/designBook.ts` → DESIGN_IDTL → reader → draft hydration.

| Browser/API field | Desktop column | Storage precision |
| --- | --- | --- |
| isrNo | ISR_NO | Stable numeric serial |
| itCode | IT_CODE | text5 |
| itType | IT_TYPE | text1 |
| pcs | IT_PCS | 12,3 |
| pcsWt | IT_PCS_WT | 14,3 |
| karigarWt | KR_WT | 14,3 |
| karigarLessPct | KR_LESS_PRC | 9,4 |
| grossWt | IT_GWT | 14,3 |
| conversionPct | IT_CON_PRC | 9,4 |
| conversionWt | IT_CON_WT | 14,3 |
| rateType | IT_RATE_TYPE | text1 |
| rate | IT_RATE | 18,2 |
| amount | IT_AMT | 18,2 |
| labourRate | IT_LBR_RATE | 18,2 |
| labourAmount | IT_LBR_AMT | 18,2 |
| netAmount | IT_NET_AMT | 18,2 |

Header actor MAIN_USER comes from the authenticated session. Hidden historical columns come from
scoped database rows, not a client-supplied raw column object. Parent date and image are retained
by the draft mapper. Null, numeric zero and blank text remain distinguishable on unchanged save.

## API and browser lifecycle

- GET `/masters/design-book?bookName=...&prCode=...` preserves the existing flat parent array response, adding `components` and `bookVersion` on each row. An empty array means version `new` for the editor.
- POST creates only an empty book: the route forces `expectedVersion='new'` even if the client sends another value. This prevents view/create-only users from replacing a saved book.
- PUT updates a loaded book using its expected version and update rights.
- DELETE deletes a selected book using delete rights and the expected version.
- A snapshot hash covers all persisted parents and children. An advisory transaction lock serializes reads/replacements even for an initially empty book. Stale saved versions return409.
- Omitted `components` retain existing child rows for older module clients. An explicit empty array removes that parent's children. The new browser always sends explicit child collections.
- The writer constructs and validates the complete replacement before deletion. Both table writes remain in one transaction; a later database insert failure rolls back both datasets.
- New parent/component draft serials increase monotonically; removing a row does not renumber the retained rows. Parent reordering in the browser changes presentation only; reopening sorts by persisted SR_NO because the desktop schema has no independent presentation-order column.
- Dedicated image GET/POST/DELETE use `/masters/design-book/image`, saved DESIGN_IMG_ID, DESIGN/D/instance0, and Design Book permissions. Root integration validates the parent inside the image transaction. The current web image store is company-level with empty LC_CODE.

## Synthetic fixture cases and executed checks

Fixture identifiers: `design-rich-db`, `design-rich-other`, `design-route-db`. These are deterministic
synthetic test tenants, not customer records. Tests use disposable PostgreSQL localhost55433,
forced RLS and the non-owner application role; owner connection is used only for setup/cleanup.

| Case | Executable check | Result |
| --- | --- | --- |
| X11-CHILD-01 | Two parents, two distinct children each; every customer/karigar/conversion/cost field | Pass |
| X11-PRESERVE-02 | Unchanged save preserves all stored rows, including nullable fields, style, per-parent dates, legacy child DESIGN_NO and image IDs | Pass |
| X11-IDENTITY-03 | Reverse parent presentation, remove one child, edit another child's rate, preserve both parent and child serials | Pass |
| X11-LEGACY-04 | Omitted children retain data; explicit empty array clears only selected parent's children | Pass |
| X11-DELETE-05 | Remove a parent and its children; then delete selected book; no remaining owned child rows | Pass |
| X11-SCOPE-06 | Same design/serial in two tenants, companies, books and products; unrelated rows untouched | Pass |
| X11-INVALID-07 | Duplicate/negative serial, blank item, invalid numeric value and excessive item width | Pass; saved book unchanged |
| X11-ROLLBACK-08 | Child numeric overflow after parent replacement begins | Pass; complete previous snapshot restored |
| X11-CONCURRENT-09 | Two edits from same snapshot | Pass; exactly one succeeds, other409; stale delete/create-over-existing refused |
| X11-HTTP-10 | Create/read actual children; create-only cannot POST-overwrite or PUT/DELETE | Pass |
| X11-IMAGE-11 | Upload/read/delete PNG with Design Book rights and no Tag Image rights | Pass |
| X11-IMAGE-SCOPE-12 | Unsaved or different-company image identity | Pass;400/404, no new image |
| X11-HTTP-EDIT-13 | PUT updates one child, preserves untouched values, stale delete409, current delete removes both tables | Pass |
| X11-DRAFT-14 | Actual frontend mapping preserves all values/nulls/zero/date/image/serials and rejects invalid drafts | Pass;5 frontend tests |
| X11-HTTP-INPUT-15 | GET without selected book and DELETE without expectedVersion | Pass;400 |

Executed command:

```sh
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test -- designBook.db.test.ts designComponents.db.test.ts designBook.routes.db.test.ts
```

Initial focused result: **3 files,18 tests passed**, including five preexisting parent tests.
The final implementation and additional HTTP input guard test then passed in the full API run:
**204 files,1576 tests**, including **19 X11 tests** and three Tour Order print-permission tests.
Full log: `/tmp/datacare-parity-api-full.log` (start21:38:38 UTC; duration478.73s).
API and web typechecks passed. `pnpm --filter @datacare/web test -- designBookPage.test.ts` passed
one file/five tests. Targeted web ESLint passed; API/test files are outside the current ESLint config
and were checked by TypeScript/test execution. These are synthetic engineering checks, not independent
desktop output captures. The root real-stack run also passed with **zero mocked requests**, using the production Next build,
real Fastify and isolated PostgreSQL. `test-results/parity-real-stack/result.json` records browser
create/reload, two components, style/text page, unchanged edit, saved image upload/read/delete,
changed component, stale edit409 retaining the form, and browser deletion. A frozen X11 summary
is `X11-design-browser-run-2026-09-11.json`. This is web execution evidence, not a desktop oracle.

After that full run, strict test-only typing was strengthened with checked required-row access and
a two-parent fixture tuple; no runtime assertions were removed. A preexisting dataExport test got
an explicit required-table check. **`pnpm typecheck:tests` then passed.** Root coordinates the
subsequent focused run covering those test-only edits.

## Required continuation before X11 closure

1. Implement automatic recalculation from the measured desktop handlers, not from these synthetic persisted values. `CommPassTotal_Idtl` starts2590; it derives karigar weight from pieces×piece weight when nonzero, customer weight from karigar weight×KR_LESS_PRC/100 under its condition, converted weight from customer weight×IT_CON_PRC (no division by100), rate basis, labour and parent other-weight/other-amount. It also uses old-value state and nonzero guards. A simple unconditional formula would change manual overrides and zero transitions. The decompiled per-piece branch contains a bitwise/conversion expression and needs executable desktop vectors before interpretation.
2. Extract and implement parent `CommPassTotal`3213 onward, including fine, labour, cost and MRP conditions. Preserve desktop source-trigger precision and X04 midpoint policy. Do not derive expected values from web output or assume the synthetic row totals above are a calculation oracle.
3. Add independent desktop fixtures for every formula branch, existing/manual override, zero↔nonzero change and source setting. Test load→unchanged save separately from upstream-triggered recalculation.
4. Capture item lookup defaults, configurable TAG_IDTL visibility/repeated values, component descriptions and diamond display columns. The current editor covers the persisted DESIGN_IDTL column set; it does not claim every displayed/conditionally hidden desktop grid column is complete.
5. Wire scoped design selection into actual order and manufacturing issue flows so the exact parent/children/photo follow the selected design. Verify downstream consumption, edits and reversal; do not copy by design number alone.
6. Migrate existing design image bytes/index entries and prove branch/mobile-index behavior. The company-level web media decision needs comparison against the desktop file plus LC_CODE-bearing mobile index; image migration, renaming aliases and downstream photo adoption are not certified by a PNG upload test. Validate ambiguous legacy composite names and duplicate-design image sharing before migration.
7. Extend the passing real browser slice to multiple parents, single-child removal, parent reorder, date variants, complete parent-column comparisons and remaining roles/configurations. Create/reload, unchanged child equality, component edit, images, stale-tab draft retention and deletion now have actual API/database browser evidence. Keep fixture/revision/hash provenance; browser stubs do not qualify.
8. Complete lost-response/session recovery, image-upload versus parent-removal concurrency, large books, source-backed role variants, actual camera checks where required, reports/print output and business acceptance. Current book deletion preserves orphan media like the source's separate deletion action; define retention/migration rules before production cutover.

Desktop evidence: **not captured for this slice**. Business acceptance: **pending**. Production
acceptance: **pending**. Required X11 descendants remain open despite the passing lifecycle tests.

<!-- not-retained: test-results/parity-real-stack/result.json -->

The run output `test-results/parity-real-stack/result.json` was written to the gitignored `test-results/` directory and is not retained in the repository.
