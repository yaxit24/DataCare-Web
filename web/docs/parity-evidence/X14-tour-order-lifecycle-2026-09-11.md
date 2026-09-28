# X14 Tour Order editor and lifecycle — implementation evidence

Status: **partially implemented; the bounded editor and lifecycle slice passed post-change API, database and real-browser verification**. Parents P05-04, P05-06 and X14 remain open. Neither independent desktop acceptance nor complete order/quotation/fulfilment parity is certified by this document.

## 1. Source and mode contract

The frozen source is `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs`. Its full SHA-256 and the implementation/build/schema hashes are in `X14-tour-order-run-2026-09-11.json`. The Tour mode comes from configured `BOOK_DATA.MAIN_BOOK='TOUR ORDER'`, writing SL_ORD_DATA, SL_ORD_DETL and SL_ORD_IDTL. Book code 510 is only a preferred configured selection; 511 and custom Z09 were exercised. A SALES ORDER book is rejected by the Tour API and its print endpoint.

| Desktop source                                        | Measured contract                                                                                  | Implemented path                                                                                                       |
| ----------------------------------------------------- | -------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| TR_SALE_ORD:8527,8668,8770                            | Header, parent and child reads use company/location/year/book/voucher; children have SR_NO/ISR_NO  | Scoped reader, list, create, update, delete; browser carries complete scope                                            |
| TR_SALE_ORD:8770–8797                                 | Load actual independent child rows, retaining both child and parent serials                        | `getTourOrder` returns `lines[].components[]`; independent component editor                                            |
| TR_SALE_ORD:9104–9168                                 | Header includes settlement values, delivery/function dates, employee, description and address      | Reader now returns accepted writer fields; EMP_CODE and VCH_DESC added to header persistence                           |
| TR_SALE_ORD:9203–9306                                 | Parent row identity, specifications, karigar values, image ID and four hallmark identities/weights | Full accepted input-field hydration and preservation, including noncontiguous imported serials                         |
| TR_SALE_ORD:9375–9434                                 | Multiple SL_ORD_IDTL rows under a parent; independent customer/karigar valuation                   | Writer accepts explicit components[] with stable serials; new rows receive unique serials above retained maxima        |
| TR_SALE_ORD:6775–6779,6858–6862; MS_OPNCOMP:1224–1226 | Per-gram labour includes ghat unless LBR_WITH_GHT=N; blank means Y                                 | Shared `labourCharge`, server-loaded company flag, corresponding reader inverse, Tour-authorized preview configuration |
| TR_SALE_ORD:6840–6874                                 | Additional piece/gross/kg bases and whole-rupee labour rounding                                    | **Open**: current making/g path retains shared two-decimal money policy; see remaining work                            |
| TR_SALE_ORD:9918                                      | Printing includes complete desktop voucher identity                                                | `/tour-orders/confirmation`, Tour permissions, configured-family validation and full scoped document query             |

The natural key is `(tenant, CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO)`. Parent identity adds SR_NO; component identity adds ISR_NO. Actor identity is derived by the route from the authenticated session.

## 2. Field, action and path matrix

The round-1 browser path is `apps/web/app/(app)/txn/tour-order/page.tsx` → `tourOrderForm.ts` → scoped `/tour-orders` route → `salesOrder.ts` → persisted order tables → reader → editor hydration. Printed documents at that checkpoint use the dedicated Tour route and `orderDoc.ts`. Later implementation is recorded separately in the round-2 plan checkpoint.

| Group                             | Values preserved by the new editor/reader contract                                                                                                                                                                                                  |
| --------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Header                            | Date, account code/name, bill number, description, net amount, tax percentage/code, advance, cash account inferred from posted debit, bank/card identifiers, cheque reference, delivery/function dates, employee, three address lines, city, mobile |
| Additional accepted header values | UPI amount; gold/silver fine and amount; scheme amount; rate-cut rate/fine/amount; gold/silver adjustment; order adjustment. Their complete settlement workflows are **not** claimed implemented                                                    |
| Parent identity/specification     | SR_NO, OLD_SRNO, VCH_SRNO, item/design/counter, colour, size, remark, product/item/rate types, rate fix, old counter, tag-stock-less flag                                                                                                           |
| Parent valuation                  | Pieces, gross/net/other/bag/ghat weights, touch, wastage, rate, inferred making/g, labour rate/type/percentage, other amount, MRP, karigar net/touch/wastage/fine/name, tag cost                                                                    |
| Parent media/hallmark             | DESIGN_IMG_ID, four hallmark IDs and weights, per-line delivery date. Actual downstream media adoption remains open                                                                                                                                 |
| Child identity                    | ISR_NO and owning SR_NO; item/type, diamond code/name/size/SF number/colour/origin/remark/lab                                                                                                                                                       |
| Customer child values             | Pieces, piece weight, gross weight, conversion percentage/weight, rate type/rate, amount, labour rate/amount and net amount                                                                                                                         |
| Karigar child values              | Weight, less percentage, conversion percentage/weight, rate, amount, labour rate/amount and net amount                                                                                                                                              |

| Action                      | Route or behaviour                                                                                                                                                                                 |
| --------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Configured book             | BookSelect constrained to TOUR ORDER; preferred 510 only when configured; company/location/year changes reset the selected voucher                                                                 |
| Preview setting             | GET `/tour-orders/configuration`; returns the company's LBR_WITH_GHT policy with Tour view rights. Unknown configuration does not produce a guessed preview                                        |
| Create                      | POST `/tour-orders?coCode=…&lcCode=…&coYear=…&coBook=…`; editor clears after success                                                                                                               |
| List/open                   | GET scoped collection and GET `/:vchNo`; explicit loading/list errors; old scope responses are ignored                                                                                             |
| Edit                        | PUT exact selected identity; sends all accepted fields and explicit child collections plus expectedVersion                                                                                         |
| Concurrent edit/delete      | Advisory mutation lock plus persisted-state digest; stale snapshot returns 409 and retains browser edits. Settings changes also invalidate the digest                                              |
| Delete                      | DELETE exact selected identity with expectedVersion; existing reversal and period/consumption checks remain active                                                                                 |
| Print                       | GET `/tour-orders/confirmation` with complete scope, voucher and format; Tour permission is independent of Sales Order permission                                                                  |
| Legacy client protection    | A saved parent with multiple components cannot be replaced by an omitted/flattened component request. The request fails before deletion; explicit empty component arrays remain deliberate removal |
| Unsupported persisted flows | Existing metal/settlement/stock allocation rows or separate cash/cheque/card tender values block editing so the current writer cannot silently erase them                                          |

Unchanged-save equality was checked for all stored business columns in SL_ORD_DATA, SL_ORD_DETL, SL_ORD_IDTL, AC_DATA and ROJ_MEL_DATA for the supported synthetic fixture. Only technical regenerated row/ledger keys were excluded from the comparison. This is not evidence that every imported desktop column or financial branch is supported.

## 3. Frozen cases and current outcomes

These case IDs identify this bounded slice; they do not replace or reduce the original plan's scenario set.

| Case               | Expected outcome                                                                                                       | Current result                                                                                                       |
| ------------------ | ---------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- |
| X14-EDITOR-01      | Create, close, select, reopen rich header/line/two children                                                            | Passed real browser/API/DB                                                                                           |
| X14-IDENTITY-02    | Imported SR_NO 7 and ISR_NO 10/20 survive unchanged edit                                                               | Passed DB complete business-row comparison                                                                           |
| X14-UNCHANGED-03   | Every supported stored value and balance unchanged after browser and DB unchanged save                                 | Passed                                                                                                               |
| X14-CHILD-04       | Change one child; keep other child, money advance and identities; delete selected voucher                              | Passed real browser/API/DB                                                                                           |
| X14-SCOPE-05       | Collision at same voucher across 510, 511, Z09/location/year cannot cross scopes; SOR rejected                         | Passed DB; Z09 real browser                                                                                          |
| X14-CONFLICT-06    | Stale PUT/DELETE and two concurrent edits preserve state; one concurrent writer succeeds                               | Passed DB; real browser 409 preserves local unsaved text                                                             |
| X14-GHAT-07        | Blank flag includes ghat, N excludes it, policy change invalidates stale request                                       | Passed DB with literal expected 120.40/116.55 values and shared-kernel ratchet unchanged                             |
| X14-DRAFT-08       | Text identifiers, full-precision inferred rate, zeroes, dates and child collections survive; invalid numbers rejected  | Passed 5 frontend tests                                                                                              |
| X14-PRINT-09       | Tour-only print permission, wrong-family denial, exact scoped document identity                                        | Passed 3 dedicated HTTP tests in final API suite and final real-browser print                                        |
| X14-CONTAINMENT-10 | Unsupported saved metal/settlement rows survive a refused edit                                                         | Passed DB                                                                                                            |
| X14-LEGACY-11      | Flattened or missing-line legacy PUT cannot collapse multiple children; explicit empty collections can remove children | Passed final DB regression and real HTTP 400/readback regression; no stored child or version changes after rejection |
| X14-FULFIL-12      | Two partial deliveries exhaust one order; reversal restores allocation                                                 | Open                                                                                                                 |
| X14-CONVERT-13     | Quotation→order/invoice lineage, stale/repeated/excess conversion and source dependency protection                     | Open                                                                                                                 |
| X14-PRODUCTION-14  | Multiple karigars→receipts→tags→invoice retains specifications, pictures, advances and origin                          | Open                                                                                                                 |
| X14-RESILIENCE-15  | Lost response, retry, offline/session recovery and measured business acceptance                                        | Open                                                                                                                 |

## 4. Executed verification

- Final API suite: `node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test` — **204 files / 1577 tests passed**, including the final legacy-client guard. The four directly related files account for **40 passing tests**: tourOrder.db (2), tourOrderHydration.db (6), salesFamilyLifecycle.db (29) and tourOrderPrint.routes.db (3). PostgreSQL 127.0.0.1:55433 uses the non-owner app_user role with forced RLS; the owner connection is limited to deterministic fixture setup/cleanup.
- Complete web unit suite: **17 files / 75 tests passed**. This includes tourOrderForm.test.ts (5) and derivedValueSources.test.ts (4). The structural calculation guard was not weakened; final changes after this suite were API-only and the real HTTP journey regression.
- API and web typechecks passed for this slice. The API was rebuilt successfully after the final loss-protection guard.
- Production build completed all 7 workspace tasks with the correct API_ORIGIN rewrite. The final API-only guard was compiled again before the last browser run; the manifest records both compiled artifacts and the Next BUILD_ID.
- Final real-stack runner: `node scripts/parity-test-env.mjs -- node apps/web/test/parity.real-stack.mjs` — **passed**, started 2026-09-10T21:53:33.922Z and finished 2026-09-10T21:53:41.769Z (Sep 11 in Asia/Kolkata). Production Next → real Fastify → migrated PostgreSQL; real login/company selection; **zero mocked requests**. The Tour journey includes configured Z09, creation/reopening, both children, unchanged save, one-child change, stale 409 retaining edits, scoped print, deletion and the post-guard legacy HTTP 400/readback check.
- The separate generic mocked browser smoke runner remains failed at its existing F2 Ledger report selector (`browser.smoke.mjs:571`). This real-stack Tour result does not close that unrelated suite failure.

Fixtures are synthetic tenants `tour-order-db`, `tour-hydration-db` and `browser-parity`, not customer or independently captured desktop data. Shared SalesFamilyLifecycle regression fixtures also ran. These results establish engineering behaviour for those cases, not source-independent accounting correctness.

## 5. Outputs and provenance

- Machine manifest: [X14-tour-order-run-2026-09-11.json](X14-tour-order-run-2026-09-11.json).
- Real runner result: [result.json](../../test-results/parity-real-stack/result.json).
- Loaded form: [tour-order-loaded.png](../../test-results/parity-real-stack/tour-order-loaded.png).
- Component grid: [tour-order-components.png](../../test-results/parity-real-stack/tour-order-components.png).
- Tour document scope evidence: [X25-order-document-scope-2026-09-11.md](X25-order-document-scope-2026-09-11.md).
- Real runner console: `/tmp/datacare-parity-browser-final.log` (ephemeral; machine result and artifact hashes are the durable run reference).

Screenshots were inspected and show the selected configured book, rich saved form and two distinct component rows. Wide grids require horizontal scrolling; screenshots do not independently certify all desktop visual states. No desktop executable output, live provider/device certification or business sign-off was captured for this slice.

## 6. Remaining work and completion limits

1. Implement all desktop order labour bases (pieces, gross, kilograms and net), source-triggered labour-rate/percentage/manual override transitions and source-specific rounding. `TR_SALE_ORD:6858–6874` rounds labour amounts to 0 decimals; the current corrected making/g branch uses the shared money kernel at 2 decimals. Freeze executable desktop vectors, including midpoint, zero and override cases, before changing expected totals.
2. Complete separate cash/cheque/card/UPI, old-metal SL_PR_DETL, scheme/rate-cut, fine advances and adjustments. Existing header field persistence is not a working settlement workflow. Remove edit containment only when each affected write set and reversal is implemented and independently compared.
3. Implement quotation conversion, partial manufacturing/delivery allocation, reservations and exact source lineage. Prevent repeated/excess allocation; release only the matching allocation on reversal; block source edits/deletion while dependent documents exist.
4. Connect design selection to the full saved parent/children and actual image identity. The Tour screen currently preserves DESIGN_IMG_ID as data, while its separate designNo image panel does not prove adoption of composite Design Book media. Migrate and verify historical/branch images and all downstream consumers.
5. Measure the complete cross-book transfer reference graph; do not substitute voucher renumbering for transfer.
6. Audit all imported order business columns and hidden metadata beyond the current accepted input mapping. Exercise imported non-default/manual values, schema widths and scopes with independent desktop fixtures; do not generalize synthetic unchanged-save equality to unsupported history.
7. Expand role/period, malformed/stale requests, retry/idempotency, lost-response/session recovery, offline requirements, report/copy/device outputs and business workload acceptance. Optional expectedVersion compatibility for older single-child clients is not a release claim for every client workflow.
8. Compare every required order/quotation report and document against independently captured desktop results, including the Tour title, customer-name precedence, components/images, fiscal identity and settlement balances. The scoped print route passing HTTP checks does not establish document visual equivalence.

**X14, P05-04 and P05-06 remain open. Production parity, independent desktop comparison and business acceptance remain pending.**
