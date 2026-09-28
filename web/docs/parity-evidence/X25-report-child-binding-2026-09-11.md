# X25 — Scoped real report component datasets

Status: **partial implementation with focused engineering evidence; X25 remains open**. This record covers the report binder and its parent/component band renderer. The separate order-document scope change is tracked by the coordinating implementation record.

## Source and contract

- `unified/src/csharp/DataCareNext/TR_SALE.cs:14670` reads `SL_IDTL` by company, location, year, book and voucher, joins the child `IT_CODE` to company `ITEM_MAST`, and orders by `SR_NO, ISR_NO`.
- `unified/src/csharp/DataCareNext/TR_PURC.cs:12364` reads parent details; line 12479 independently reads the configured `TblIdtl` with the full scope, item-master join and parent/component serial ordering. `PR_IDTL` and `KR_IDTL` have these separate records in the imported schema.
- `web/apps/api/report-specs/SalesBillHz.spec.json`, `PurcBillA4Gst.spec.json`, and `KrRecVchGst.spec.json` place parent values in GroupHeader `Section9`, child values in Detail `Section5`, and the line footer in `Section10`; voucher totals follow outside the line block.
- `web/apps/api/src/modules/reports/reportBindingContract.ts` explicitly registers the supported dataset/band contracts. `X25-report-binding-scope-2026-09-11.json` captures every name previously accepted by the substring detector, template hashes, the new state and unresolved contract reasons.

## Implemented path

`GET /reports/render` -> `bindReport` -> one repeatable-read tenant transaction -> exact scoped header/parent/child reads -> item-master joins -> parent groups -> `renderReportLayout` -> existing HTML/PDF delivery.

1. `SL_IDTL`, `PR_IDTL` and `KR_IDTL` now contain the actual persisted child records. No `IT_*` child values or item names are copied from `ITM_*` parent values.
2. Header/detail/component queries retain tenant, company, location, year, book and formatted voucher identity. Company-owned item records are joined by tenant/company/child item code. Party, book and location bindings keep their own ownership keys.
3. Parent rows remain a separate dataset with unchanged cardinality. The renderer emits a complete parent/children/footer block per parent, ordered by parent serial and component serial. A parent with zero children remains printable and emits zero component bands. Voucher totals outside the block render once.
4. The transaction uses repeatable read so a concurrent committed edit cannot mix an old header with new component values.
5. Unknown/mixed dataset templates, unsupported objects, extra detail bands, mismatched parent/component band order, child fields outside child bands, parent amount references inside child bands, orphan components, and duplicate component identities fail explicitly. The API returns the existing `unsupported-report-binding` code with a reason.
6. Dates bind as ISO dates (`YYYY-MM-DD`), avoiding the previous truncated weekday-formatted Date string.

## Field/action matrix and fixture identity

The deterministic synthetic fixture is `apps/api/test/reportChildren.db.test.ts`. It seeds only `rpt-child-contract-a` and `rpt-child-contract-b` in the positively identified disposable PostgreSQL instance on port 55433. Two companies, branches and years reuse voucher `00001`, parent serials 1/2, component serials 1/2, account codes and item codes. Components are deliberately inserted in reverse order, with distinct weights, piece counts, amounts and names.

| Case group | Required persisted/output comparisons | Result stage |
| --- | --- | --- |
| SL/PR/KR actual component records | Four actual IDTL rows, exact `IT_NET_AMT`/`IT_AMT`, component item names, exact parent `NET_AMT`, correct order | Focused database test |
| Scope isolation | Exact header customer, child `DM_NAME`, item name, party, book, location for each tenant/company/branch/year | Focused database test |
| Parent/cardinality rendering | Two parent rows; each distinct parent/child amount rendered once; parent precedes its own children | Focused HTML test over actual database rows |
| Concurrent edit | Independent committed edit between queries yields a consistent old snapshot, then a subsequent bind yields the complete new state | Real two-connection database test with an instrumented scheduling boundary |
| Empty child set | Parent retained, no fabricated child band, another branch unchanged | Controlled database fixture change |
| Orphan component | Print refuses with `orphan-child` | Controlled invalid-data fixture |
| Duplicate component serial | Print refuses with `ambiguous-child-serial` | Controlled invalid-data fixture |
| Unknown/mixed/subreport/template changes | Explicit unsupported reason; parent values cannot be repeated in child bands, including through formula references | Unit negative controls |
| Existing critical layouts | Sales, purchase, cash, tag and ledger fixture values remain present; sales now seeds an actual component | Existing focused database render suite |

The tests use saved database reads and rendered value/cardinality assertions. They do not use response echoes as persistence evidence. The concurrency boundary is instrumented; it is not a real-browser case.

## Verification commands

Run from `web`:

```sh
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test -- reportBind.test.ts reportEngine.test.ts reportRender.db.test.ts reportChildren.db.test.ts
pnpm --filter @datacare/api typecheck
```

Final execution results and source hashes are recorded in the companion `X25-report-child-run-2026-09-11.json` after the final focused run. No release gate or parity percentage is advanced by this record.

## Availability changes and remaining acceptance

The previous substring detector selected a presumed primary table for 102 extracted names. This did **not** establish complete rendering: it also accepted aggregation, multi-voucher, return, image and unsupported group/formula shapes. This slice has 23 explicitly registered dataset contracts. The other 79 previously inferred names now fail visibly and remain required X25/X26 work; the exact list is retained in the JSON inventory, not dropped from scope.

`SalesQuotation` has child weight/rate fields in a group footer whose grouping semantics are absent from the extracted spec. `SalesBillA4_WithImage` needs image binding and object rendering. Sales-return templates reference `SL_DETL_RTN`, so they need the actual return parent/source linkage instead of ordinary sale detail substitution. Unregistered multi-voucher reports need selection/grouping/aggregation contracts before registration.

The 23 registered names are **dataset/band registrations, not certified Crystal reports**. Formula evaluator limitations, missing/truncated extracted formulas, group aggregates, dynamic suppression, pagination, copy behavior, opening/closing balances, images, physical printing and independent desktop comparisons remain open. Existing tag/ledger templates retain legacy rendering behavior and do not gain complete report certification. True desktop semantic/layout output, browser/PDF validation, printer evidence and business acceptance have not been supplied by these synthetic fixtures.

Do not close X25 or its P10 parents until all required descendants, direct document paths, independent desktop output, and required device/business acceptance have passed.
