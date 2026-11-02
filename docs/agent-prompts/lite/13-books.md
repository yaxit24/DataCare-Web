# Agent 13 — Company → Books   (Lite package L5)

**Type:** BUILD (master with wide blast radius)  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Company → Books the desktop `MS_BOOK` screen: voucher series definitions — 3-digit book code, `MAIN_BOOK` family, direction, and the posting-account slots in `BOOK_DETL`.

## Identity and hand-offs

- **SLUG** `books`  **BRANCH** `feat/lite-books`  **worktree** `~/dc-wt/books`  **feature module** `books`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-books` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `MS_BOOK` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7441-7450`
- **Tables:** `BOOK_DATA`, `BOOK_DETL`
- **Web routes:** `/masters/books`
- **API:** `GET /masters/:name`, `POST /masters/:name`, `PUT /masters/:name`, `DELETE /masters/:name`
- **Desktop rights:** `CRED-L` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** G38, N58, G40, N59, N62, X10
- **Purpose:** Defines voucher series: 3-digit book code, MAIN_BOOK family, in/out direction and the posting-account slots in BOOK_DETL.
- **Recorded gap:** Slot semantics, desktop 3-digit codes, branch cloning, reference guards, Print and family-filtered behaviour remain.
- **Sources:** `project-memory/video-research/_kb/KB_transaction.md:176-191`

## Desktop pointers (start your study here)

- `MS_BOOK.cs` is 3,122 lines: Load `:1900`, Clear `:2434`, Display `:2468`, Print `:2570`, **Save `:2579`**, **Delete `:2687`**.
- Tables `BOOK_DATA`, `BOOK_DETL`. Every posting kernel resolves accounts through the slots (the N106–N158 literal sweep moved them there), so slot semantics are the contract between this screen and every voucher.
- Catalog gaps: slot semantics, desktop 3-digit codes, branch cloning, reference guards, Print, family-filtered behaviour.

## Current web state

- Generic `masters/:name` CRUD at `/masters/books` (`masters/configs.ts`). Provisioning seeds ~41 books (`ops/seedCompany.ts`: SL, SRT, SOR, PR, RCT, PAY, CON, JV, TSP, …).

## Scope — what you must deliver

- Per `MAIN_BOOK` family: which slots exist, what each slot means (cash/bank/income/expense/tax/labour/round-off/kasar/gold/silver DR/CR …), which are mandatory, the account lookup filters, the family-filtered book list, code format, next code, default/in-use flags.
- Reference guards: refuse changing a family or deleting a book that has vouchers; the exact texts. Branch cloning (`LC_CODE`). Print.
- A page ≤ 600 lines; slot grid as a component.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Create a book of each Lite family through the screen, then **create a voucher on it through the voucher's own screen** and assert the posting went to the slot accounts you configured (this is the real test). Change a slot account, post again, assert the new account is used and the old voucher unchanged.
- Delete refused with vouchers; provisioned books still match after the page change.
- Rights by caption "Books".

## Risks and traps

- A wrong slot silently posts to the wrong ledger. At the end re-run `salesInvoice`, `purchaseInvoice`, `cashBank`, `contraEntry`, `salesOrder`, `tagCancel`.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `masters/configs.ts`
- `ops/seedCompany.ts`
- `posting/*` (read, do not modify)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
