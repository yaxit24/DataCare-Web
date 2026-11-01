# Agent 03 — Report → Approval Rpt   (Lite package L6)

**Type:** BUILD (report) — reuses the RP_ALL engine; its data comes from agent 12 (Approval Isu/Rtn)  
**Suggested wave:** 2  
**Do not start building until:** Agent 01 has merged the RP_ALL engine, and agent 12 (Approval Isu/Rtn) has merged — the report is only verifiable against approval vouchers made through their real screens.  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → Approval Rpt the desktop `RP_ALL` form in its "Approval Rpt" caption: issue, in/out and pending custody by party and item.

## Identity and hand-offs

- **SLUG** `approval-report`  **BRANCH** `feat/lite-approval-report`  **worktree** `~/dc-wt/approval-report`  **feature module** `approvalReport`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-approval-report` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_ALL` — mode: constructor caption 'Approval Rpt'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8921-8930`
- **Tables:** `APR_DATA`, `APR_DETL`, `BOOK_DATA`, `AC_MAST`, `ITEM_MAST`
- **Web routes:** `/reports/approval-report`
- **API:** `GET /reports/approval-report`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** N22, X17, N24, X26, N57, N75
- **Purpose:** Reports approval issue, in/out and pending custody by party and item.
- **Recorded gap:** Three data modes exist; RP_ALL selectors, grouping, custody reconciliation and Crystal layouts are uncertified.
- **Sources:** `unified/src/csharp/DataCareNext/RP_ALL.cs:8141-8365`

## Desktop pointers (start your study here)

- `RP_ALL.cs:8141-8365`. Template `AprPan.rpt`.
- Custody identity to prove: issued − returned − billed = pending, per party and per item, for pieces, gross, net and fine.

## Current web state

- API: `GET /reports/approval-report` (`routes/txn.ts:6370`, three data modes); generic report page.
- Approval write side: `apps/api/src/modules/tour/` (agent 12 is rewriting it — read the merged version).

## Scope — what you must deliver

- The three data modes the web has map to desktop selectors — confirm or correct from source. Add the RP_ALL selectors, grouping, custody reconciliation and the Crystal layout.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Issue approval through the Approval Isu screen (two parties, tagged and untagged lines, stones), return part, bill part through Sales, then report: pending equals the hand count. Cancel/delete an issue where the desktop allows it and re-run.
- Reconcile with the Tag Stock report "approval pending" tab (agent 04) — assert both agree.

## Risks and traps

- If agent 12 has not merged, do the study and case list only and report "waiting on 12".

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `routes/txn.ts` (one line)
- `rbac/*`
- shared RP_ALL engine

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
