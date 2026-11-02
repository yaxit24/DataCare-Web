# Agent 01 — Report → Sales Report   (Lite package L6)

**Type:** BUILD (report) — creates the shared RP_ALL report engine  
**Suggested wave:** 1  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → Sales Report the desktop `RP_ALL` form in its "Sales Report" caption: every sales variant, every filter, exact totals, drill-down and the SaleReport/SalesWithOrder outputs.

## Identity and hand-offs

- **SLUG** `sales-report`  **BRANCH** `feat/lite-sales-report`  **worktree** `~/dc-wt/sales-report`  **feature module** `salesReport`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-sales-report` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_ALL` — mode: constructor caption 'Sales Report'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8901-8910`
- **Tables:** `SL_DATA`, `SL_DETL`, `SL_DETL_RTN`, `AC_MAST`, `ITEM_MAST`, `BOOK_DATA`
- **Web routes:** `/reports/sales-register`
- **API:** `GET /reports/sales-register`, `GET /reports/sales-by-party`, `GET /reports/sales-by-item`, `GET /reports/sales-by-group`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** N36, G06, G48, N24, X26, N57, N75, G225, N212
- **Purpose:** Runs sales register, party, item, group, employee, order-linked and summary variants.
- **Recorded gap:** A register exists; the RP_ALL sales variants, the MAIN_BOOK classification remainder, filters and Crystal templates remain.
- **Sources:** `unified/src/csharp/DataCareNext/RP_ALL.cs:7572-7945`

## Desktop pointers (start your study here)

- `RP_ALL.cs` is 12,662 lines and serves several menu captions. The **Sales Report** branch is `RP_ALL.cs:7572-7945`. Find how the constructor caption selects the branch, then read only the sales branch plus the shared selectors/filters it calls.
- Templates in the repo root / `zip_contents/`: `SaleReport.rpt`, `SalesWithOrder.rpt`, `SaleRtnReport.rpt`, `Gstr_1.rpt` (not yours). XML in `extraction_output/rpt_xml/`.
- MAIN_BOOK classification: the sales variants include sales, sales return, wholesale, hallmark, labour sale, old-item sale books. The catalog says "the MAIN_BOOK classification remainder" is open: enumerate which book families the desktop includes per variant from the source, then prove each with a voucher.

## Current web state

- API: `GET /reports/sales-register` (`apps/api/src/routes/txn.ts:6277`), `sales-by-party`, `sales-by-item`, `sales-by-group`. Rendered by the generic `app/(app)/reports/[report]/page.tsx` (1,742 lines, **at its size ceiling — do not grow it**).
- Reuse: `apps/api/src/modules/reports/` (`reportFilters.ts`, `reportEngine.ts`, `reportPdf.ts`, `reportCsv.ts`, `reportAuthorization.ts`, `reportBind.ts`).

## Scope — what you must deliver

- Create a **shared RP_ALL engine** (selectors: dates, party, book, product/group/item, employee, order-linked toggle, grouping, tab/mode; filter semantics; grouping/zoom) in its own module/directory so that Purchase Rpt (agent 02) and Approval Rpt (agent 03) can reuse it. **Merge this foundation first**: tell the coordinator in your PR when it is reusable.
- A dedicated route directory (page ≤ 600 lines + grid + hook + types), as in PR #195's `reports/account-ledger/`.
- Every sales variant the desktop offers in this caption: register, by party, by item, by group, by employee, order-linked (`SalesWithOrder`), summary — as the source defines them, with the desktop column order and captions.
- Drill-down (zoom to the voucher) and print/PDF/CSV for each variant.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Create the sales through the **Sales Invoice screen** (reuse the setup of `modules/salesInvoice.mjs`): two item groups on one bill, local vs inter-state GST, a sale with old-gold exchange, a hallmark sale, a sale with an order advance, then a **Sales Return** through its screen. Totals reconcile to the vouchers and to the ledger.
- Edit one sale, delete one, return one: the report follows each step.
- Filters one at a time and in combination; From/To around year boundaries; book filter with two sale books.
- Sentinels in another company/location/year/tenant never appear.

## Risks and traps

- Shared engine: the two sibling agents wait for yours. Keep its public surface small and documented.
- As of 2 Nov the Sales Invoice, Sales Return, Purchase Invoice and Purchase Return modules have **empty** baselines (#189 just merged); if a voucher screen misbehaves while you build fixtures, that is a regression to report, not something to code around in the report.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `apps/api/src/routes/txn.ts` (one-line registration only)
- `rbac/routePolicy.ts`, `rbac/formCatalog.ts`
- new files under `apps/api/src/modules/reports/` and `apps/web/app/(app)/reports/`

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
