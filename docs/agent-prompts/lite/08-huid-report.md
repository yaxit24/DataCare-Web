# Agent 08 — Report → HuId Report   (Lite package L6)

**Type:** BUILD (report)  
**Suggested wave:** 2  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → HuId Report the desktop `RP_HUID` form: tags by HUID status across stock, inward, outward and all views with the TagHuIdRpt layout.

## Identity and hand-offs

- **SLUG** `huid-report`  **BRANCH** `feat/lite-huid-report`  **worktree** `~/dc-wt/huid-report`  **feature module** `huidReport`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-huid-report` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_HUID` — mode: constructor caption 'HuId Report'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:9032-9041`
- **Tables:** `BAR_DETL`, `TAG_STOCK_PRINT`, `AC_MAST`, `PRODUCT_MAST`, `GROUP_MAST`, `BOOK_DATA`
- **Web routes:** `/reports/huid`
- **API:** `GET /reports/huid`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** G13, N43, N24, X26, N57, N75, G71, N85
- **Purpose:** Lists tags by HUID status across stock, inward, outward and all views.
- **Recorded gap:** PR #23 added the HUID filters; exact tabs, remaining filters and the TagHuIdRpt layout remain uncertified.
- **Sources:** `unified/src/csharp/DataCareNext/RP_HUID.cs:1752-2189`

## Desktop pointers (start your study here)

- `RP_HUID.cs` (2,731 lines); catalog range `RP_HUID.cs:1752-2189`. Tables `BAR_DETL`, `TAG_STOCK_PRINT`.
- PR #23 already added the HUID filters (G13/N43); read what it did before changing anything.

## Current web state

- `GET /reports/huid` → `modules/reports/huid.ts` (207 lines).

## Scope — what you must deliver

- Exact tabs, the remaining filters, the columns and the TagHuIdRpt layout.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Tags with and without HUIDs through **Tag Opening** and a hallmark **Purchase**; sell one, cancel one, return one; tabs stock/inward/outward/all agree. HUID uniqueness behaviour if the source enforces it.

## Risks and traps

- The TagHuIdRpt template may not be in the repository: if so the layout case is **blocked with that reason**.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `modules/reports/huid.ts`
- `routes/txn.ts` (leave alone)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
