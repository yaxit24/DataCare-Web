# Agent 14 — Company → Year Create   (Lite package L5)

**Type:** BUILD (company utility)  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Company → Year Create the desktop `MS_YEAR` screen: create a financial year by copying the baseline masters (the desktop's 17-table copy) and optionally carry balances.

## Identity and hand-offs

- **SLUG** `year-create`  **BRANCH** `feat/lite-year-create`  **worktree** `~/dc-wt/year-create`  **feature module** `yearCreate`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-year-create` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `MS_YEAR` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7421-7430`
- **Tables:** `YEAR_MAST`, `AC_GROUP`, `AC_MAST`, `BAL_GR`, `BOOK_DATA`, `BOOK_DETL`, `CO_SET`, `TAX_MAST`
- **Web routes:** `/masters/year-create`
- **API:** `GET /years`, `POST /years`, `POST /years/carry-forward`
- **Desktop rights:** `C----L` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** G38, G39, G97, N58, N90, X10, X27
- **Purpose:** Creates financial years, clones baseline masters and carries opening balances.
- **Recorded gap:** The desktop 17-table copy and identity convention are not reproduced; delete, Print and branch-safe carry-forward remain. Year close/reopen (web-only, rewrote CL_DATE) was removed by N90.
- **Sources:** `unified/src/csharp/DataCareNext/MS_YEAR.cs:1504-1595`

## Desktop pointers (start your study here)

- `MS_YEAR.cs` is 1,596 lines: Load `:759`, Display `:899`, Print `:961`, **Delete `:970`**, Cancel `:993`, **Save `:1140`**; the 17-table copy is **`NewCompParmCreat :1504-1595`** (also the source for Company, agent 16).
- Tables `YEAR_MAST`, `AC_GROUP`, `AC_MAST`, `BAL_GR`, `BOOK_DATA`, `BOOK_DETL`, `CO_SET`, `TAX_MAST`. Rights `C----L`.
- N90 removed a web-only year close/reopen that rewrote `CL_DATE`: do not reintroduce it.

## Current web state

- Page `masters/year-create/page.tsx` (238 lines); API `modules/masters/year.ts` (172 lines): `GET|POST /years`, `POST /years/carry-forward`. Year-end: `modules/ops/yearEnd.ts` (280 lines).

## Scope — what you must deliver

- The 17-table copy and the year identity convention, exactly; the delete (and what blocks it); Print; the messages. Branch-safe carry-forward.
- Hand the carry-forward **content** (stock, orders, approvals, …) to agent 15 (Balance TrFr); here prove only what `MS_YEAR` itself does.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Create year 2 from year 1 with vouchers present; every copied table has exactly the desktop rows (compare with a hand list), nothing copied that the source does not copy; year selector offers both years; vouchers dated in year 2 post to year 2.
- Duplicate year refused; delete refused when vouchers exist; locks and `CL_DATE` unchanged; second tenant untouched.

## Risks and traps

- Company/Year identity keys appear in every table: a wrong copy corrupts the new year silently. Diff the **whole tenant** before and after.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `ops/seedCompany.ts` (shared copy logic with agent 16 — whoever merges first extracts it)
- `ops/yearEnd.ts`

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
