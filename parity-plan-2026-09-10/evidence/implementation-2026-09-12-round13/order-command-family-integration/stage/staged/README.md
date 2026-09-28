# Remaining five order commands — staged handoff

Status: ready for root integration and execution. No compiler, unit/DB test, browser or build was run by this author. Only source reads, file edits, staged-file formatting, hashes and exact text comparisons were performed. The preimplementation26-schedule fixture and contract remain byte-identical. Independent source review is in the parent directory; it supplies no runtime acceptance.

Integrate the new `salesOrder.ts` source through `order-service.patch` against the pinned baseline, then apply `order-routes.patch` to the root-owned route file without overwriting concurrent changes. `txn.ts.preview` is reference-only. Copy the two new test files and exact `fixtures/orderCommand.independent.json`. All five new required exports live in `modules/sales/salesOrder.ts`:

- `createSalesOrderInSession(prisma,{identity,input})`
- `cancelSalesOrderInSession(prisma,{identity,input:{scope,vchNo,deleteUser?,expectedVersion}})`
- `createTourOrderInSession(prisma,{identity,input})`
- `editTourOrderInSession(prisma,{identity,input,voucherNo})`
- `cancelTourOrderInSession(prisma,{identity,input:{scope,vchNo,deleteUser?,expectedVersion}})`

`identity` remains the strict unknown-input command helper envelope. Session command policy is fixed by each entry. Modern saved mutations require lowercase64-hex versions at both route and service seams; internal legacy versions remain optional. Existing Sales PUT, formulas, F1/labour replay, children, period/consume checks and accounting statements remain unchanged. `createSalesOrderTx` and `cancelSalesOrderTx` are internal transaction composition seams, not alternative HTTP admission. The existing create lifecycle argument remains replacement-only and unmodified.

`extraction-comparison.json` records all48 template literals byte-identical/in-order, create preparation plus complete run body byte-identical, cancellation callback differing only in indentation, and the prior Sales edit preparation/Tx/guard byte-identical. This is a source text comparison, not compiled or executed equivalence. No active repository files were edited by this stage.

The focused set declares24 unit cases and34 DB cases. Unit checks pin the independent fixture, fixed authority, detached scope, exact version refusal, compatibility transaction boundary and static route wiring. DB cases use real service entries, actual transaction SQL, real session/selection locks, exact text+xmin/ctid snapshots, foreign tenant and sibling book sentinels, both create/cancel families, Tour replacement, numbering concurrency, stale document/context, fresh permissions, missing authority, period/issued refusal, final expiry and complete rollback. Test-only proxies inject faults or gates around real SQL and never substitute authoritative query results. They do not prove all26 prospective schedules ran or all five HTTP handlers were exercised; mounted HTTP/browser proof remains root-owned. No new timeout override is introduced. All waits race early operation completion and release/settle in finally.

Use the existing isolated55433/app_user wrapper only when root grants execution. The fixture has unique tenants `next-order-command` and `next-order-foreign`; cleanup affects those tenants only. No database/schema reset or migration is included. Snapshots do not promise unchanged global PostgreSQL sequence counters; rolled-back inserts may advance row_id sequences. Voucher-number reuse is tested from the existing live-row MAX rule, not a sequence rollback assumption.

Two representation qualifications preserve the frozen numerical fixture:

1. DELETE_DATA.VCH_VAL_DR/CR are Float; raw SQL text is `0`/`40`, while the literal financial expectation is numerically0.00/40.00. The DB assertion pins the actual schema representation without changing the independent fixture.
2. **Required next work, not waived:** existing `getSalesOrder(...,{orderMainBook:'TOUR ORDER'})` skips `exactOrderValues` at baseline salesOrder.ts1541. Its `mrp: n(r.ITM_MRP)` at1496 rounds imported999999999999999.99 to a Number. Existing `preserveOrderRow` in orderLifecyclePolicy.ts300–308 refuses that apparent unchanged value with the exact-decimal diagnostic. The new DB case first requires this refusal and unchanged snapshot. It then obtains the exact MRP from the actual SQL-text snapshot and supplies it to the internal service solely to prove the writer's existing exact-input preservation. That second step is not a claim of current Tour UI/GET round-trip support. A separate bounded Tour exact hydration/helper/UI follow-up is required, retaining raw NULL/blank/large-decimal semantics and testing real reopen→unchanged/advance edit; do not weaken this guard to make the UI save pass.

All successful financial paths leave session context/JTI/receipt/expiry/last-used unchanged. Legitimate selection or fixture permission mutations are explicitly separated. No new ledger-mode authority, balance integration, refund path, automatic retry or lost-response idempotency is provided. Unconverted adjustment/refund/consumption routes remain outside this adoption.
