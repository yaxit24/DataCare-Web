# Agent 06 — Report → Cash Bank   (Lite package L6)

**Type:** BUILD (report)  
**Suggested wave:** 2  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → Cash Bank the desktop `RP_CASH_BANK` form (cash/bank book, and the scheme/pending/member modes where the Lite edition shows them) with drill-down into the account movements.

## Identity and hand-offs

- **SLUG** `cash-bank-report`  **BRANCH** `feat/lite-cash-bank-report`  **worktree** `~/dc-wt/cash-bank-report`  **feature module** `cashBankReport`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-cash-bank-report` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_CASH_BANK` — mode: constructor caption 'Cash Bank'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8941-8950`
- **Tables:** `AC_DATA`, `AC_MAST`, `BOOK_DATA`, `CASH_DATA`, `UPI_DATA`, `AD_DATA`, `AD_MEMB`
- **Web routes:** `/reports/cash-book`
- **API:** `GET /reports/cash-book`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** X16, P06-01, N24, X26, N57, N75, G225, N212
- **Purpose:** Shows cash/bank or scheme-member balances and drills into account movements.
- **Recorded gap:** Cash Book does not prove the RP_CASH_BANK scheme/pending/member modes, drill-down or the AcLedger/PassBook layouts.
- **Sources:** `unified/src/csharp/DataCareNext/RP_CASH_BANK.cs:2084-2357`

## Desktop pointers (start your study here)

- `RP_CASH_BANK.cs` (4,813 lines); catalog range `RP_CASH_BANK.cs:2084-2357`. Templates `RojMelCash.rpt`, `AcLedger.rpt`, PassBook layouts.
- Tables include `AD_DATA`/`AD_MEMB` (scheme members): **decide from the source whether the Lite edition shows those modes** (edition `MsSoftType`, `MDI_FORM.cs:11236-11330`); if not, record those cases N/A with that citation before running.

## Current web state

- API `GET /reports/cash-book` (`routes/txn.ts:6696`) → `cashBook(...)`; generic report page.

## Scope — what you must deliver

- Cash vs bank selection, opening/closing, day-wise vs summarized, the pending mode, drill-down to the account ledger (agent 21 audits the Ledger Report; link, do not rebuild), print/PDF/CSV.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Vouchers from the existing **cash-bank** module setup: Cash Received/Payment, Bank Received/Payment, Contra (note G37 open), a cheque with and without a bank, a sale with cash tender. Opening balance carried from a previous year.
- Edit/delete a voucher and re-run; closing balance equals opening + Σ receipts − Σ payments by hand.

## Risks and traps

- G229 (date outside the year) was just fixed on main; assert the report never shows an out-of-year voucher.
- The Contra module baseline holds `contra.report.contra-register` (G37): the Contra register report is known-broken. Your Cash Bank cases involving Contra will meet it. Record the overlap in your PR and do not fix the register unless it blocks you (then a separate commit).

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `routes/txn.ts` (one line)
- `rbac/*`

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
