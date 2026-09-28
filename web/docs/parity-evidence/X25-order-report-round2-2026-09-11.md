# X25 round 2 — Recovered Sales/Tour Order documents

Status: **partial implementation; focused engineering checks passed; X25 remains open**. These three documents now print their actual main report and independently scoped received-metal subreport. This record does not certify all Crystal reports, exact desktop appearance, physical printing or business acceptance.

## Source recovery and selection contract

The former `OrderVch`, `OrderBill` and `TourOrdVch` specs contained the first nested `OrdRec` report definition rather than the main report. Their formula arrays also lost content. The bounded extractor now uses direct child XML paths, preserves full formulas, and keeps the independent subreport as a separate spec. It updates only these three files and their three catalog count entries; the other 251 catalog entries remain unchanged.

| Main document | Desktop selection | Recovered main sections / objects | Independent dataset |
| --- | --- | --- | --- |
| `OrderVch` | Sales or Tour Order with no `SL_ORD_DETL` parents | 11 / 58 | `OrdRec` from `SL_PR_DETL` |
| `OrderBill` | Sales Order with parents and image printing disabled | 16 / 93 | `OrdRec` from `SL_PR_DETL` |
| `TourOrdVch` | Tour Order with parents and image printing disabled | 15 / 92 | `OrdRec` from `SL_PR_DETL` |

Source locations are relative to `web`:

- `../extracted_code/DataCareNext/DataCareNext/TR_SALE_ORD.cs:9815–9818,9877–9920`: scoped parent presence, `OrderVch` / `OrderBill` / `OrdVchImg` selection, received-metal presence, selection formula and opening/closing amount overrides.
- `../extracted_code/DataCareNext/DataCareNext/TR_TOUR_ORD.cs:7980–8035`: `OrderVch` / `TourOrdVch` / `TourOrdImg` selection, full voucher selection, received-metal suppression and copy labels.
- `../extracted_code/DataCareNext/DataCareNext/MS_OPNCOMP.cs:948,981,1140–1142`: the setting is **`CO_SET_NEW.ORD_IMG_PRINT`**; blank defaults to `N`. It is not a `CO_SET` field.
- `../extracted_code/DataCareNext/DataCareNext/DC_Main.cs:1463–1483`: opening balance sums `CR_AMT-DR_AMT` before the voucher timestamp; closing includes the timestamp. Both scope company/location/year/account. Data type `C` combines data; other types filter `DATA_TYPE`.
- `../extraction_output/rpt_xml/OrderVch.xml`, `OrderBill.xml`, `TourOrdVch.xml`: main bands, independent `OrdRec`, full formula text, field aliases, static/dynamic suppression, source dimensions and page margins. Each new spec records its XML SHA-256.
- `OrderBill.xml:883` and `TourOrdVch.xml:954`: `RTotal0` sums parent gross weight on group changes. It must not sum a joined parent once for each child.
- XML formulas `OpAmtCrDr` and `ClAmtCrDr` use `> 0` for `Cr`, otherwise `Dr`, including zero. The web preserves this explicit zero behavior.

The three recovered templates are protected by exact semantic spec hashes. Editing a formula, band or source object without reviewing its contract yields `altered-order-report-spec`, not silent partial interpretation. These are explicit source contracts, not filename inference.

## Implemented data and output path

1. The family-specific order-confirmation adapter selects the main report from saved scoped parent presence. It requires the corresponding Sales Order or Tour Order print permission and configured active book family. Generic report rendering also requires an explicit validated order family.
2. One tenant `RepeatableRead` transaction reads the header, parents, real components, company/party/book/location, received-metal rows, image setting and ledger balances. Every voucher dataset retains tenant/company/location/year/book/formatted voucher identity. Master joins retain their ownership keys.
3. Parents remain a separate dataset. `SL_ORD_IDTL` uses its own `IT_CODE`, `SR_NO` and `ISR_NO`; its `ITEM_MAST_IDTL.IT_NAME`, pieces and weight never come from the parent. A parent without children remains present and emits no fabricated child band.
4. The full XML parent group renders `Section10`, then actual `Section5` children, then source parent footers. The statically suppressed image section in `OrderBill` stays suppressed. Parent amounts and `RTotal0` count each parent once. The spec-aware item-name helper prints design text for `OrderBill` even when a tag is present; only `TourOrdVch` uses the source tag-prefix conditional.
5. `OrdRec` reads `SL_PR_DETL` independently of order item serials, sorts by its own serial and computes its own piece/weight totals with decimal arithmetic. Duplicate/null received serials fail explicitly. No received rows sets `OldItem=N` and suppresses the subreport.
6. The web scopes `OrdRec` to the branch even where two legacy XML links omit location. This prevents reused voucher identities from another branch appearing in the report.
7. The binder reads `VCH_TIME::text` with the header and uses that exact database text for the ledger cutoff. It does not truncate to seconds or round-trip through JavaScript `Date`, which would lose PostgreSQL microseconds. Missing/invalid timestamps fail rather than invent a midnight cutoff.
8. The coordinating change preserves `AC_DATA.ENTRY_TIME` as `timestamp(6)` and inherits the voucher timestamp when posting. **The migration cannot recover clocks already truncated to dates. Historical source reimport/reconciliation remains required.** No live business database migration was performed in this evidence run.
9. NULL/missing joined fields display blank; numeric zero stays zero. Typed arithmetic handles parent/received totals, copy overrides, tax label, opening/closing balances, debit/credit suffixes and amount words. Complete source string/address formulas are evaluated from the recovered text.
10. Source page dimensions/margins, fonts, alignment and suppression are retained. The bounded renderer allocates pages, repeats source page headers/footers and assigns page numbers after allocation. Large bands that cannot fit a page fail explicitly. HTML and PDF use the same layout; order PDFs honor CSS page size.
11. Supported copy inputs are `O`, `D`, `T`, `CUSTOMER`, `ACCOUNT`; inherited object keys are rejected. When no copy is supplied, the XML default label `ORIGINAL` is retained. The desktop's full print-options dialog, print-copy batches and peripheral workflows are not completed by accepting these labels.
12. A parent-containing order whose company setting selects images fails as `selected-image-order-template-unsupported`, naming `OrdVchImg` or `TourOrdImg`. Conflicting setting rows also fail. Advance-only orders still select `OrderVch`, as in the source.

## Verification matrix

Synthetic fixture identity is owned by `orderReport.db.test.ts`: tenants `order-rpt-contract-a` / `order-rpt-contract-b`, companies 91/92, branches 01/02, years 2026–2027 / 2027–2028, Sales/Tour books and reused vouchers 00001/00002. Tests positively require the disposable PostgreSQL port 55433 and clean only their owned tenants.

| Case | Independent observation / expected result |
| --- | --- |
| Full source extraction | Exact main counts, full non-truncated formula strings, separate subreport spec, reproducible extractor `--check` |
| Tenant/company/branch/year/book isolation | Saved header, party, ordered rows and received descriptions match each complete scoped identity |
| Parent/component cardinality | Two parents, three true child records with distinct names/weights; child counts 2/1; parent money not duplicated by child fanout |
| Received-metal independence | Two distinct received rows sorted by their serial, emitted once; their sum independent of order parent count |
| Ledger second-level selection | Same-day before/equal/after rows; combined opening 13.45 / closing 23.70; type A opening 12.34 / closing 22.59 |
| Ledger microsecond selection | Saved `.123456`, prior `.123455` +2.11, equal `.123456` +3.22, later `.123457` +4000; opening 25.81 and closing 29.03 in both bound values and actual HTML fields |
| Consistent concurrent snapshot | A second connection changes received weight and ledger amount after header read; current report retains the complete old state and subsequent bind sees the complete new state |
| Empty/invalid data | Empty received set suppresses `OrdRec`; wrong family/shape, missing timestamp, duplicate received identity, missing render datasets/fields and changed spec fail |
| Image selection | Setting Y refuses both parent-containing image variants; advance-only document and unrelated company continue correctly |
| HTTP print rights | Tour-only print permission reaches Tour report; wrong family/scope/permission cannot use the adapter; copy and selected-image errors remain explicit |
| HTML/PDF pagination | Three one-page examples and one 60-parent four-page example; actual children, received rows, 60 ordered rows and numeric values retained; no measured main/footer overlap, field/band overflow or page errors |
| Existing reports | Existing binder, parent/child, critical render and engine suites retained in the focused run; no old template registration removed |

Tests compare persisted database values and rendered fields. The concurrent boundary is instrumented, not a claim of a concurrent real-browser journey. The PDF fixtures are deterministic synthetic rendering examples, not desktop goldens or posted business documents.

Focused run before the final microsecond fix: **7 files / 77 tests passed, zero skipped**. Required follow-up after that fix: **2 files / 13 tests passed, zero skipped**, including the new microsecond case and Tour print routes. A subsequent source review found and corrected the `OrderBill` item-name mismatch; its **14 unit tests passed, zero skipped**, including two tag-present Sales/Tour vectors. The database fixtures were also strengthened with persisted tag/design pairs. The final coordinated API run then passed **210 files / 1630 tests, zero skipped**, and strict test typechecking passed; see `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round2/api-full-verified.txt` and `test-types-verified.txt`. Do not add these overlapping run counts as unique tests.

```sh
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test -- reportBind.test.ts orderReport.test.ts orderReport.db.test.ts reportChildren.db.test.ts reportRender.db.test.ts reportEngine.test.ts tourOrderPrint.routes.db.test.ts
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test -- orderReport.db.test.ts tourOrderPrint.routes.db.test.ts
python3 scripts/extract-order-report-specs.py --check
node scripts/render-order-report-review.mjs
swift scripts/rasterize-order-report-review.swift output/pdf/order-report-round2
```

The PDF review used direct CoreGraphics page rasterization because Poppler is unavailable on this macOS host. PDFKit's thumbnail method produced incomplete thumbnails; those were replaced by direct page renders of the same PDFs, which retain the complete text. Browser screenshots are supplemental. The retained review folder is `output/pdf/order-report-round2`, including four PDFs, HTML, seven PDF page PNGs and `render-review.json`. After the item-name correction the four PDFs were regenerated against the final API build; the corrected OrderBill page was visually re-reviewed and the other six page PNG hashes were unchanged. All seven PDF pages were visually reviewed; the long fixture has internally consistent saved header net/tax/total amounts 390000/11700/401700.

## Inventory and required follow-up

**26 registered dataset/document contracts; the same 79 previously inferred templates remain contained.** The three recovered order names were outside the previous 102-name substring-inference inventory. The new round-2 inventory retains all 102 old records and appends these three. It does not subtract three from the 79, change an acceptance percentage or rewrite old evidence.

The following work remains required before production/desktop parity acceptance:

1. **Image order variants:** start from `TR_SALE_ORD` / `TR_TOUR_ORD.ImgPrint` and `OrdVchImg.xml` / `TourOrdImg.xml`. Extract their main/subreport definitions with direct paths, prove tenant/company/branch/year/book/voucher/parent image ownership and persistence, implement actual BlobFieldObject/image rendering, and test missing/multiple images, branches and pagination. Remove only these selected-image refusals after those cases pass.
2. **Exact Crystal presentation:** capture desktop goldens for zero/negative/fractional amounts, rounding ties, large values, Indian and non-Indian locales, NULLs and empty masters. Compare `ToWords(amount,0)` spelling/hyphens/rounding, currency/weight decimal formatting, signs and date formats. The web currently uses deterministic English whole-amount words and plain numeric strings; exact Crystal locale behavior is not certified.
3. **Layout and devices:** compare source fonts, field widths, growing text, group keep-together/orphan behavior, long unbroken values, line endpoints across long pages, source minimum subreport whitespace, repeated headers/footers and actual printer output. The current conservative page allocator proves retained data in the tested shapes, not exact Crystal pagination or pixel identity.
4. **Selection/copy workflow:** expose and verify the desktop data-type selector where required; the current order-confirmation adapter uses combined type C. Complete the desktop print-options/copy batch, WhatsApp/export and physical print workflows with their own authorized tests.
5. **Historical ledger clocks:** import original timestamps from an authoritative desktop snapshot, reconcile same-day opening/closing balances, and retain evidence for records previously migrated as dates. Do not invent clock values or close acceptance based on the new schema alone.
6. **Retained report checksum harness:** `scripts/report-baselines.mjs` supplies generic `V:FIELD` markers and lacks the required order parent/child/subreport datasets. It needs reviewed source-valid fixtures for these three contracts; its previous hashes reflect the wrong nested-only extraction. No checksum baseline was regenerated or weakened in this slice. Updating that harness is distinct from desktop golden comparison.
7. **Remaining report universe:** continue the unchanged 79 contained names and all other required reports using explicit source contracts; registration does not itself establish production acceptance. The old 23 contracts retain their previous formula/layout limitations.

The next image contract is recorded in `X25-order-image-next-steps-round2-2026-09-11.md`; it is a source-backed implementation plan, not an image feature completion claim.

Do not close X25, P10 or whole-product parity from this report slice. The accompanying run manifest records exact input and artifact hashes from the shared dirty development tree, not an immutable clean release candidate.
