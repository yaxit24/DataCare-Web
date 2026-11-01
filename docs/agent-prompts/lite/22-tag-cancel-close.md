# Agent 22 — Other → Tag Cancel   (Lite package L3)

**Type:** FINISH A MOSTLY-DONE MENU (small) — start only after PR #197 (Stock Adjust) has merged  
**Suggested wave:** 4  
**Do not start building until:** PR #197 merged (it edits `TagCancelForm.tsx`, `tagCancelVoucher.ts` and `tagCancel.mjs`).  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Tag Cancel (`TR_TAG_CAN`, book `TAG CANCEL`) is built and its module passes 12 browser cases (N210, PR #185); it is "module green" on the progress page. The catalog still lists open items. Close the ones that can be closed in the browser.

## Identity and hand-offs

- **SLUG** `tag-cancel-close`  **BRANCH** `feat/lite-tag-cancel-close`  **worktree** `~/dc-wt/tag-cancel-close`  **feature module** `tagCancel`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-tag-cancel-close` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `TR_TAG_CAN` — mode: CurBookHelp('TAG CANCEL')
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8585-8595`
- **Tables:** `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DETL`, `BAR_IDTL`, `MAIN_STOCK`, `DM_DATA`, `DELETE_DATA`
- **Web routes:** `/txn/tag-cancel`
- **API:** `GET /stock/tag-cancel`, `POST /stock/tag-cancel`, `GET /stock/tag-cancel/:vchNo`, `PUT /stock/tag-cancel/:vchNo`, `DELETE /stock/tag-cancel/:vchNo`, `GET /stock/tag-cancel/source`, `GET /stock/tag-cancel/:vchNo/print`
- **Desktop rights:** `CREDPL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** G223, N18, N210, P07-03, X18, X19
- **Purpose:** Writes off a missing or unusable tagged piece without a sales bill.
- **Recorded gap:** Implemented from source (N18, N210): TagCanBill behind print rights and the desktop refusals pass 12 browser cases. Open: no captured desktop BAR_CAN rows, idempotency retry, fault rollback, the Tag Stock report check and a desktop-runtime comparison.
- **Sources:** `project-memory/video-research/_kb/KB_other.md:106-149`

## Desktop pointers (start your study here)

- `TR_TAG_CAN.cs` (5,987 lines), `MDI_FORM.cs:8585-8595`. Print template `TagCanBill`.

## Current web state

- `components/TagCancelForm.tsx`, `modules/stock/tagCancel.ts`, `tagCancelBill.ts`; module `modules/tagCancel.mjs`. **The coverage-map/progress mapping was already fixed on `main` by #189** (the entry now lists `txn/tag-cancel/page.tsx`; the progress page shows Tag Cancel "module green"). Do not redo it; verify it is still true after your rebase.

## Scope — what you must deliver

- The catalog row's remaining open items. Close them by adding cases and any fixes they expose: **idempotency/retry (T13), per-table fault rollback (T14), the Tag Stock report agreement (T16/T18; use agent 04's report if merged, else the existing report), concurrent two-session cancel of the same tag (T12), rights by the caption "Tag Cancel" (T11)**. "No captured desktop BAR_CAN rows" and "desktop-runtime comparison" stay open honestly.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Extend `tagCancel.mjs`; the existing 12 cases stay unchanged.

## Risks and traps

- Small, but it shares files with #197 and agent 04: rebase before you start.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `tagCancel.mjs`
- `TagCancelForm.tsx` (shared with Stock Adjust)
- catalog row of Tag Cancel

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
