# Agent 12 — ExtraTran → Approval Isu   (Lite package L4)

**Type:** LAND EXISTING WORK — not a fresh build (covers BOTH Approval Isu and Approval Rtn: one form, one writer, one branch)  
**Suggested wave:** 1  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Approval Isu and Approval Rtn are the desktop `TR_APR_ISU` form on the `APR ISU` and `APR RTN` books. A previous session built most of it and **never pushed it**. Your job is to land it safely: recover, rebase, verify, fix what the rebase and a fresh run expose, and open the PR.

## Identity and hand-offs

- **SLUG** `approval-land`  **BRANCH** `feat/lite-approval-land`  **worktree** `~/dc-wt/approval-land`  **feature module** `approvalIssue / approvalReturn`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-approval-land` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `TR_APR_ISU` — mode: CurBookHelp('APR ISU')
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8300-8305`
- **Tables:** `APR_DATA`, `APR_DETL`, `APR_IDTL`, `MAIN_STOCK`, `BAR_DETL`, `DM_DATA`
- **Web routes:** `/txn/tour`
- **API:** `POST /tour/issue`, `DELETE /tour/:vchNo`
- **Desktop rights:** `C-----` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** N22, X17, P05-05, N62, X07, G225, N212
- **Purpose:** Places tagged goods with a party on approval while the business keeps ownership.
- **Recorded gap:** Create-only shared Tour page; APR ISU book enforcement, reopen/edit/delete/print and the partial sale/return custody chain remain.
- **Sources:** `project-memory/video-research/_kb/KB_transaction.md:331-357`

## Desktop pointers (start your study here)

- `TR_APR_ISU.cs` is 8,294 lines: Load `:5355`, Clear `:5697`, Display `:5788`, **Save `:6007`**, **Delete `:6608`**, Print `:6712`, First/Last `:7253/:7282`. Dispatch `MDI_FORM.cs:8300-8305` (issue) and `:8312-8317` (return).
- Tables `APR_DATA`, `APR_DETL`, `APR_IDTL`, `MAIN_STOCK`, `BAR_DETL`, `DM_DATA`. The business keeps ownership: issue moves tags to "approval", return restores availability, billing a part through Sales consumes it.

## Current web state

- **Recovery source:** local worktree `~/dc-wt/lite-approval`, branch `feat/lite-approval` @ `a9f68b85`, **31 commits ahead of origin, not on the remote**, 13 behind main. It contains `modules/tour/approval*.ts`, `routes/approval.ts`, `sales/approvalSaleReferences.ts`, a DB migration, `approvalLifecycle.routes.db.test.ts` (2,229 lines) and three feature modules (`approvalIssue.mjs`, `approvalReturn.mjs`, `approvalHelpers.mjs`). Its records use **N211/G224, which `main` now uses for the Employee master** — renumber.
- Pages today: `txn/tour/page.tsx` (issue) and `txn/tour-return/page.tsx`. Main's catalog still says "Create-only shared Tour page … reopen/edit/delete/print and the partial sale/return custody chain remain".

## Scope — what you must deliver

- **Do not work inside `~/dc-wt/lite-approval`** (it is another session's tree; check `session_status.py` shows no live session on it). Treat it as a read-only source of commits.
- **Recovery recipe (tested on 2 Nov against `origin/main` @ `c6101aeb`).** That branch also carries older Item Opening and Tag Cancel commits that are already on `main` under other hashes, so do **not** rebase it. Exactly **24** commits carry `(N211, G224)`. Use a fresh branch from `origin/main` and cherry-pick only those: `git worktree add ~/dc-wt/approval-land -b feat/lite-approval-land origin/main`, then `for c in $(git log --reverse --format=%h --grep "(N211, G224)" a9f68b85 ^origin/main); do git cherry-pick $c || break; done`. The first commit (`8ece8aa8`) conflicts **only in record and registration files**, not in code: `menu-catalog.jsonl`, `menu-catalog.md`, `standard-progress.md` (regenerate), doc 12, `execution-backlog.json`, `routes/txn.ts` (registration lines), `routePolicy.test.ts`, `coverage-map.json`, `run-features.mjs`, `size-budget.json`. Resolve those by keeping both sides, then renumber ids and regenerate generated files. Later commits may conflict in `schema.prisma`, `kernel-conformance-baseline.json`, `depth-parity-baseline.json`.
- Check the migration: new timestamp ordering after the latest on main, checksum pin, idempotent on a database that already has approval rows.
- Then do the normal method on the result: re-read the desktop source against what was built (its own commit messages list "audited guarantees and gaps" — read them and verify, do not trust them), run `approvalIssue` and `approvalReturn` and `salesInvoice` (it was edited too), fix failures, renumber ids, regenerate generated files, gates, PR.
- Cover **both menus**: issue lifecycle (create/reopen/unchanged save/edit/delete/print/list/First-Last), return lifecycle, partial sale/return custody chain, the `APR ISU` / `APR RTN` book enforcement, dependency reversal (cannot delete an issue with a return or a bill).

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Keep the previous session's case list as the starting point and **extend** it with the T-groups it lacks (T11 rights by caption "Approval Isu"/"Approval Rtn" — G225 aliases were added on main; T12 two-session race on the same tag; T13 retry; T14 rollback per table).
- Downstream: Tag Stock approval-pending tab (agent 04) and Approval Rpt (agent 03) must agree with your vouchers — leave them a clear fixture recipe in the PR.

## Risks and traps

- Biggest merge in the batch (66 files, +12.6k lines). Land it **first**; agents 03, 04 and 22 wait for or consume it.
- It edits `salesInvoice.mjs` and `tagCancel.mjs`: expect conflicts with PR #197 (Stock Adjust) and the Wh Sales follow-up.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `prisma/schema.prisma` + migrations
- `size-budget.json`
- baseline JSONs under `web/parity/`
- `salesInvoice.mjs`, `tagCancel.mjs`
- catalog rows of both menus

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
