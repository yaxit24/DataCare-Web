# Agent 02 — Report → Purchase Rpt   (Lite package L6)

**Type:** BUILD (report) — reuses the RP_ALL engine from agent 01  
**Suggested wave:** 2  
**Do not start building until:** Agent 01 (Sales Report) has merged the shared RP_ALL engine. Start the desktop study and case list earlier if you like, but do not write engine code that duplicates it.  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → Purchase Rpt the desktop `RP_ALL` form in its "Purchase Rpt" caption.

## Identity and hand-offs

- **SLUG** `purchase-report`  **BRANCH** `feat/lite-purchase-report`  **worktree** `~/dc-wt/purchase-report`  **feature module** `purchaseReport`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-purchase-report` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_ALL` — mode: constructor caption 'Purchase Rpt'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8911-8920`
- **Tables:** `PR_DATA`, `PR_DETL`, `PR_IDTL`, `AC_MAST`, `ITEM_MAST`, `BOOK_DATA`
- **Web routes:** `/reports/purchase-register`
- **API:** `GET /reports/purchase-register`, `GET /reports/purchase-by-party`, `GET /reports/purchase-by-item`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** N36, G06, G48, N24, X26, N57, N75, G225, N212
- **Purpose:** Runs purchase register, party, item, bill, group and summary report variants.
- **Recorded gap:** A register exists; the RP_ALL purchase variants, the MAIN_BOOK classification remainder, filters and Crystal templates remain.
- **Sources:** `unified/src/csharp/DataCareNext/RP_ALL.cs:7946-8140`

## Desktop pointers (start your study here)

- `RP_ALL.cs:7946-8140` is the purchase branch.
- Templates: `PurcReport.rpt`, `PurcGroupWise.rpt`, `AcPurcSummRpt.rpt`.
- Variants named in the catalog: register, party, item, bill, group, summary. Confirm each from the source.

## Current web state

- API: `GET /reports/purchase-register` (`routes/txn.ts:6280`), `purchase-by-party`, `purchase-by-item`; generic report page.

## Scope — what you must deliver

- Reuse agent 01's RP_ALL selector/filter/grouping engine. Add only what is purchase-specific (book families: purchase, purchase return, hallmark purchase, other purchase, old-gold purchase — verify from source).
- Dedicated route directory; do not grow the generic report page.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Create purchases through the **Purchase Invoice screen** (setup from `modules/purchaseInvoice.mjs`): two item groups, fine-weight purchase with the fine rule, GST local/inter-state, a purchase return through its screen.
- Edit/delete/return and re-run. Group-wise and party-wise totals equal the sum of vouchers.

## Risks and traps

- Purchase Invoice and Purchase Return have empty baselines on `main` (2 Nov); treat a failing voucher screen as a regression to report, not to work around.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `routes/txn.ts` (one line)
- `rbac/*`
- the shared RP_ALL engine from agent 01 (read-only for you unless a bug blocks you)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
