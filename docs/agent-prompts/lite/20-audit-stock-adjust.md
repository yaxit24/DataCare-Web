# Agent 20 — Other → Stock Adjust   (Lite package L3)

**Type:** INDEPENDENT AUDIT of open PR #197 — do NOT re-implement  
**Suggested wave:** after #197 is ready  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

> **AUDIT OVERRIDE.** From 00-GENERIC keep §0-§1 (hard rules), §2.1 (machine limits) and the *reporting* style. Skip §3 steps 1-6 as written: you do **not** create a feature module of your own for the menu, take N/G ids, edit records, push a branch or open a PR. You work in a **read-only, detached worktree** of the other session's PR head, put any extra cases in a scratch file outside the repo (or an untracked file in your worktree), and deliver one report file. Report format: for each finding give severity, the case, the desktop citation, expected vs observed, and the evidence path; end with the three coverage numbers for the PR's own matrix plus yours.

## Mission

Another session is building Stock Adjust (`feat/stock-adjust`, PR #197, N221/G234). You are the independent verifier. The aim is a second pair of eyes that did not write the code and does not trust its claims.

## Identity and hand-offs

- **SLUG** `audit-stock-adjust`  **BRANCH** `(none — read-only audit; do not push to feat/stock-adjust)`  **worktree** `~/dc-wt/audit-stock-adjust`  **feature module** `stockAdjust (audit)`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-audit-stock-adjust` (ports come from the stack slot you take, see 00-GENERIC §2.1).
- No browser stack needed for the audit setup until you run their module; the slot rules still apply.

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `TR_TAG_CAN` — mode: CurBookHelp('STOCK ADJUST')
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8616-8627`
- **Tables:** `BAR_CAN_DATA`, `BAR_CAN_DETL`, `MAIN_STOCK`, `BAR_DETL`, `DM_DATA`
- **Web routes:** `/txn/stock-adjust`
- **API:** `POST /stock/adjust`, `DELETE /stock/adjust/:vchNo`
- **Desktop rights:** `C--D--` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** X18, P07-02, G40, G41, N59
- **Purpose:** Posts signed piece and weight stock corrections without a financial ledger entry.
- **Recorded gap:** No saved reopen/edit/print; counter, loss-weight, karigar and component-grid depth and configured-book handling remain.
- **Sources:** `project-memory/video-research/_kb/KB_other.md:150-213`

## Desktop pointers (start your study here)

- Desktop: `TR_TAG_CAN.cs` (5,987 lines) used on a `STOCK ADJUST` book (`CurBookHelp`), `MDI_FORM.cs:8616-8627`; same form as Tag Cancel. Tables `BAR_CAN_DATA`, `BAR_CAN_DETL`, `MAIN_STOCK`, `BAR_DETL`, `DM_DATA`. Signed piece/weight corrections, **no financial ledger entry**.

## Current web state

- PR #197 changes: `txn/stock-adjust/page.tsx` (rewritten around the shared `components/TagCancelForm.tsx`), `lib/tagCancelVoucher.ts`, a migration `…_stock_adjust_book`, `stockAdjust.mjs` (968 lines), `stockAdjust` route DB test, and edits `tagCancel.mjs`.

## Scope — what you must deliver

- Create a **read-only** worktree of the PR head: `git worktree add ~/dc-wt/audit-stock-adjust --detach origin/feat/stock-adjust`. Never push to that branch; never edit the other session's files.
- 1) Re-derive the desktop behaviour yourself from `TR_TAG_CAN.cs` for the STOCK ADJUST mode (signed +/−, counter, loss weight, karigar, component grid, configured book) and list every behaviour. 2) Compare against the PR's case list: which desktop behaviours have **no case**? 3) Run their module and the **Tag Cancel module** (the shared form changed) on a fresh stack. 4) Write **your own additional cases** for every uncovered behaviour and every T-group they skipped (rights by caption, two-session race, retry, per-table rollback, reopen/no-op footprint, Tag Stock report agreement) and run them against the PR head. 5) Check records: contiguous N/G ids against `origin/main`, catalog row, coverage map, progress page.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Report each failure with: case, expected (with desktop citation), observed, evidence path. Check for **tag-cancel regressions** (the PR edits the shared form) and the book-migration safety on a database that already has Stock Adjust rows.

## Risks and traps

- Do not "help" by pushing fixes. Findings go to the owner and to the PR author in a report file `~/datacare-agent-reports/audit-stock-adjust.md` (and, only if the owner says so, as a PR comment).

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- (read-only)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
