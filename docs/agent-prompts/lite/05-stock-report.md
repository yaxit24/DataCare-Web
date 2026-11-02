# Agent 05 — Report → Stock Report   (Lite package L6)

**Type:** BUILD (report) — new route  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → Stock Report the desktop `RP_STOCK` form: stock summarised by group, product, item, design, safe, table or trading dimension, with gross-weight options and drill-down.

## Identity and hand-offs

- **SLUG** `stock-report`  **BRANCH** `feat/lite-stock-report`  **worktree** `~/dc-wt/stock-report`  **feature module** `stockReport`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-stock-report` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_STOCK` — mode: constructor caption 'Stock Report'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8881-8890`
- **Tables:** `MAIN_STOCK`, `ITEM_MAST`, `GROUP_MAST`, `PRODUCT_MAST`, `LOCT_MAST`, `TABLE_MAST`, `BOOK_DATA`
- **Web routes:** `/reports/tag-stock`
- **API:** `GET /reports/tag-stock`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** N24, X26, P10-04, N57, N75, G71, N85
- **Purpose:** Summarises stock by group, product, item, design, safe, table or trading dimension.
- **Recorded gap:** Tag Stock is not RP_STOCK: group/product/item/design/safe/table/trading summaries, gross-weight options and drill-down are missing.
- **Sources:** `unified/src/csharp/DataCareNext/RP_STOCK.cs:4277-5160`

## Desktop pointers (start your study here)

- `RP_STOCK.cs` (6,407 lines); catalog range `RP_STOCK.cs:4277-5160`. Template `ItmStkBalance.rpt`.
- Stock truth in this system is `MAIN_STOCK` signed movements (`ITM_SIGN`); on-hand = Σ signed movement; fine = net × touch / 100. Read `modules/stock/stock.ts` `onHandNet()` and the `_kb/KB_other.md` primitives.

## Current web state

- Today the menu is mapped to `/reports/tag-stock` (the Tag Stock form). The catalog says: "Tag Stock is not RP_STOCK". Create a **new route** (e.g. `/reports/stock-report`) and change the catalog row's `ui` and the nav entry accordingly; classify it in `web-route-editions.json`.

## Scope — what you must deliver

- All summary dimensions the source offers, gross-weight options, drill-down to the movements/tags, print/PDF/CSV.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Stock built through screens: Item Opening, Tag Opening, Purchase, Sale, Sales Return, Purchase Return, Stock Adjust (#197), Tag Cancel. After each, the summary equals Σ signed movements by hand.
- Fine and weight columns, loss/ghat weights where the source shows them, opening vs closing for a date range.

## Risks and traps

- Touches nav (`lib/nav.ts`) and the catalog `ui` of two menus: rebase carefully if agent 04 changes the same row.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `lib/nav.ts`
- `docs/handbook/menu-catalog.jsonl` rows of Stock Report and Tag Stock
- `web-route-editions.json`

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
