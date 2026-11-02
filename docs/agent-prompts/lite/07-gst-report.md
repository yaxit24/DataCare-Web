# Agent 07 — Report → Gst Report   (Lite package L6)

**Type:** BUILD (report)  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → Gst Report the desktop `RP_GST` form (non-UAE): the GST registers, summaries, returns and CSV outputs, exact grids and exact CSV.

## Identity and hand-offs

- **SLUG** `gst-report`  **BRANCH** `feat/lite-gst-report`  **worktree** `~/dc-wt/gst-report`  **feature module** `gstReport`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-gst-report` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_GST`, `RP_TAX` — mode: RP_GST outside the UAE edition, RP_TAX for UAE
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8951-8971`
- **Tables:** `TAX_DATA`, `TAX_MAST`, `BOOK_DATA`, `AC_MAST`, `LOCT_MAST`
- **Web routes:** `/reports/gst-report`
- **API:** `GET /reports/gst-report`, `GET /reports/gstr1`, `GET /reports/gstr2`, `GET /reports/gstr3b`, `GET /reports/hsn-summary`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-edition`  **Owners (slices/gaps):** N24, X26, P10-03, N36, G48, N57, N75, G225, N212
- **Purpose:** Launches GST/tax registers, summaries, returns and CSV outputs for the jurisdiction.
- **Recorded gap:** The web is a launcher over reports; RP_GST/RP_TAX jurisdiction modes, exact grids and CSV and the Crystal outputs are not certified.
- **Sources:** `web-implementation-spec/04_Cross_Cutting_Engines/gst-engine.md:8-45`

## Desktop pointers (start your study here)

- `RP_GST.cs` (3,944 lines). The UAE edition uses `RP_TAX.cs` (2,405 lines) — **out of scope for Lite**; the dispatch is `MDI_FORM.cs:8951-8971`. Templates `Gstr_1.rpt`, `Gstr_2.rpt`.
- Tables: `TAX_DATA`, `TAX_MAST`, `BOOK_DATA`, `AC_MAST`, `LOCT_MAST`. The HSN table and printed HSN tax split were fixed in N174 — reuse it.

## Current web state

- Today a **launcher** over reports: `GET /reports/gst-report` (`modules/reports/gstLauncherReport.ts`, 62 lines), `gstr1`, `gstr2`, `gstr3b`, `hsn-summary`.

## Scope — what you must deliver

- Replace the launcher with what `RP_GST` actually shows and exports. Prove every mode and the CSV byte layout (column order, number format, date format, empty-value convention).

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Sales and purchases through their screens covering: local (CGST/SGST), inter-state (IGST), exempt/zero-rated, a return/credit note, HSN split, B2B vs B2C, GST on labour/making, TCS where relevant, different tax rates in one bill. GSTR-1/2/3B totals tie to the vouchers and to `TAX_DATA`.
- Period filters, a voucher edited after the return period, deleted voucher.

## Risks and traps

- Money-critical: statutory output. Every number must be hand-computed. Anything the source does not settle is a blocked case, not an assumption.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `routes/txn.ts` (one line)
- `modules/reports/gstLauncherReport.ts`

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
