# Agent 11 — Other → Order Cancel   (Lite package L3)

**Type:** BUILD (voucher)  
**Suggested wave:** 1  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Other → Order Cancel the desktop `TR_SL_ORD_ADJ` voucher (book `ORDER CANCEL`): a multi-order adjustment voucher that cancels pending sales orders and refunds the advance through a chosen cash/bank account.

## Identity and hand-offs

- **SLUG** `order-cancel`  **BRANCH** `feat/lite-order-cancel`  **worktree** `~/dc-wt/order-cancel`  **feature module** `orderCancel`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-order-cancel` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `TR_SL_ORD_ADJ` — mode: CurBookHelp('ORDER CANCEL')
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8628-8639`
- **Tables:** `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `AC_DATA`, `ROJ_MEL_DATA`, `APR_DETL`, `MAIN_STOCK`
- **Web routes:** `/txn/order-cancel`
- **API:** `POST /sales-orders/:vchNo/cancel-refund`
- **Desktop rights:** `C----L` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** N37, G07, X14, P05-04
- **Purpose:** Cancels pending orders and adjusts advance, kasar and refund through a chosen cash or bank account.
- **Recorded gap:** Single order only; multi-order adjustment, bounds, the full ledger/Rojmel/stock/tag write set, lifecycle and print remain.
- **Sources:** `project-memory/video-research/_kb/KB_other.md:277-369`

## Desktop pointers (start your study here)

- `TR_SL_ORD_ADJ.cs` is 4,169 lines: Load `:2852`, Clear `:3110`, Display `:3184`, **Save `:3410`**, **Delete `:3726`**, **Print `:3794`**, First/Last `:4015/:4044`. Grid columns (KB_other §5.3): `Sr | OrdNo | AcCode | Ac Name | It Desc | OrdAmt | AdjAmt | KsarAmt | PaidAmt | PaiidAc | Paid Ac Name`.
- Tables `SL_ORD_ADJ` (voucher), `SL_ORD_DATA/DETL`, `AC_DATA`, `ROJ_MEL_DATA`, `APR_DETL`, `MAIN_STOCK`. Slice N37 / gap G07 describe the mismatch.

## Current web state

- Page `txn/order-cancel/page.tsx` (280 lines) calls `POST /sales-orders/:vchNo/cancel-refund` — a **per-order void**, not the desktop's voucher. Refund/kasar accounts already resolve from `BOOK_DETL` (N155).

## Scope — what you must deliver

- A real voucher: book chooser, voucher no., date/time, a **multi-row grid** of orders, AdjAmt/KsarAmt/PaidAmt bounds as the source checks them, paid account F1 help, ledger + Rojmel + stock/tag release postings exactly as the source writes them, reopen/edit/delete/print/First/Last/list, version tokens, rights.
- Keep the existing single-order endpoint working only if something still uses it (grep first); otherwise replace it.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Create sales orders through the **Sales Order screen** with advances by cash, by bank, by cheque; cancel one, several in one voucher, a partially adjusted one; refund equals advance − kasar; ledger and day book balance; tags/stock reserved by the order are released.
- Refusals: already cancelled, already invoiced, AdjAmt > OrdAmt, missing paid account — exact texts, no write.
- Delete the cancel voucher: the order returns to pending and every posting is reversed.

## Risks and traps

- The Sales Order module still carries one baselined defect, `sales-order.create.tender-modes` (G206). Read it so you do not trip over it, but do not fix it in this PR unless it blocks you (then a separate commit).

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `modules/sales/salesOrder.ts` (2,372 lines, at ceiling — do not grow; new code goes in a new file)
- `routes/txn.ts` (one line)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
