# Agent 04 — Report → Tag Stock   (Lite package L6)

**Type:** BUILD (report)  
**Suggested wave:** 1  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → Tag Stock the desktop `RP_TAG` form: inward, outward, in-stock, MRP, approval-pending and all-tags tabs with desktop filters, columns, totals, sub-details and outputs.

## Identity and hand-offs

- **SLUG** `tag-stock`  **BRANCH** `feat/lite-tag-stock`  **worktree** `~/dc-wt/tag-stock`  **feature module** `tagStock`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-tag-stock` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_TAG` — mode: constructor caption 'Tag Stock'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8891-8900`
- **Tables:** `MAIN_STOCK`, `BAR_DETL`, `BAR_IDTL`, `APR_DETL`, `TAG_IMAGE_DATA`, `TAG_STOCK_PRINT`
- **Web routes:** `/reports/tag-stock`
- **API:** `GET /reports/tag-stock`, `GET /reports/tag-stock.csv`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** N24, X26, P10-04, N57, N75, G225, N212
- **Purpose:** Lists inward, outward, in-stock, MRP, approval-pending and all tags with totals.
- **Recorded gap:** Tabs and totals exist; date/tag/product/group filters, full columns and sub-details, Excel/PDF and Crystal layouts are incomplete.
- **Sources:** `unified/src/csharp/DataCareNext/RP_TAG.cs:3977-4325`

## Desktop pointers (start your study here)

- `RP_TAG.cs` is 10,813 lines; the catalog source range is `RP_TAG.cs:3977-4325`. Find the tab/mode radio handling and each query.
- Templates: `TagStkRpt.rpt`, `CntrTagStkRpt.rpt`, `CntrTagSumRpt.rpt`. Tag image: `TAG_IMAGE_DATA`.
- F3 in the desktop opens the Stock Report from many screens (KB_master); not yours — but do not break the shortcut contract.

## Current web state

- Page `app/(app)/reports/tag-stock/page.tsx` (209 lines) and API `GET /reports/tag-stock` + `.csv`.
- **The route `/reports/tag-stock` is also mapped to the Stock Report menu (agent 05).** The desktop has two different forms (`RP_STOCK` and `RP_TAG`); keep this page `RP_TAG` only and let agent 05 create a separate route.

## Scope — what you must deliver

- Tabs: inward, outward, in-stock, MRP, approval-pending, all. Filters: date, tag, product, group, plus any the source offers. Full column set and sub-details (stones/components). Excel/PDF/print, tag image.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Build the tag universe through real screens: **Tag Opening**, a **Purchase** with tags, a **Sale** (tag goes outward), **Tag Cancel**, **Stock Adjust** (when #197 lands), an **Approval Isu** (pending) — then every tab reconciles to the hand count of pieces and weights.
- A cancelled tag leaves in-stock; a returned sale tag comes back; an approval-pending tag is not in-stock (verify against source).
- Pagination vs totals: totals cover all rows.

## Risks and traps

- Tag Cancel catalog row lists "the Tag Stock report check" as an open item — your cases close it; tell agent 22.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `reports/tag-stock/*`
- `routes/txn.ts` (leave alone if the route already exists)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
