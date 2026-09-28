# X25 — Order confirmation identity, family and read consistency

Status: **focused engineering checks passed; full document parity remains open**.

The order confirmation reader now requires tenant/company/location/year/book/voucher identity. It reads the header, detail lines and branch party using that complete ownership context. Optional `OrderScope.family` is supplied by the form-specific routes: `SALES ORDER` for `/sales/order-confirmation` and `TOUR ORDER` for `/tour-orders/confirmation`. Within the same repeatable-read transaction, the reader uses shared `resolveBookPolicyTx` to require a single active book, an explicit matching `MAIN_BOOK`, a compatible direction and a compatible configured `BOOK_TBL_NAME` (`SL_ORD_DATA` when present). Neither order route assumes a particular book code.

Shared book policy now declares the two existing desktop order families (`SALES ORDER` outward and `TOUR ORDER` inward). Its optional stricter family/table requirements are requested by the document reader; existing caller defaults are preserved. The source order writer already declares those directions and rejects a nonblank incompatible table (`salesOrder.ts`, `ORDER_BOOK_MODES` and `resolveOrderBookTx`). `TR_SALE_ORD.cs:9918` is the desktop complete print identity anchor.

The HTML formatter now handles database `Date` values as ISO calendar dates. The reader uses repeatable read so a header and its lines cannot come from different committed edits. The route owner added the separate Tour print route, correct `Karigar/Tour Order` print action and Tour document title; the Tour page now uses that endpoint. That fixes the reviewed integration mismatch where a Tour-only operator needed Sales Order print rights and received a Sales title. Route/browser authorization acceptance is covered by the coordinating real-stack run, not inferred from the reader tests below.

## Focused validation

Command:

```sh
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test -- orderDocumentScope.db.test.ts bookPolicy.test.ts provisioning.db.test.ts
pnpm --filter @datacare/api typecheck
```

Results: **3 test files, 25 tests passed, 0 skipped; API typecheck passed**. Log: `X25-order-document-test-2026-09-11.txt`.

The order fixture has six reused voucher identities varying tenant, company, branch, fiscal year and book. Its six database tests verify:

1. Exact header, line, company and party association for each identity, plus missing voucher/branch behavior.
2. Missing identity rejected before any query.
3. Matching Sales/Tour family with nonstandard Sales book `Z09`, and cross-family refusal.
4. Inactive, blank-family, incompatible-table and duplicate book configurations refused, without removing the saved order.
5. Actual PostgreSQL dates printed as the expected calendar dates.
6. A competing connection commits changed header/line amounts between reader queries: the first read contains one old snapshot and the next read contains the complete new state. Only the scheduling boundary is instrumented; both transactions use real PostgreSQL.

The existing nine shared-policy unit cases and ten company-provisioning database cases pass with the added order contracts. These checks establish the scoped reader and regression behavior; they are not independent desktop or business-user acceptance.

## Still open

Order child/specification output, all field/calculation/settlement display rules, exact desktop layout/copy/pagination, physical printing and other direct document renderers remain applicable X25 descendants. General Crystal limitations and the explicit report-template containment inventory are documented in the companion report-child record. X25 and its P10 parent packages remain open.
