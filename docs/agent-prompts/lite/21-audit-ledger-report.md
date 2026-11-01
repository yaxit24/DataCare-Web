# Agent 21 — Report → Ledger Report   (Lite package L6)

**Type:** INDEPENDENT AUDIT of open PR #195 — do NOT re-implement  
**Suggested wave:** now (PR open since 1 Nov)  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

> **AUDIT OVERRIDE.** From 00-GENERIC keep §0-§1 (hard rules), §2.1 (machine limits) and the *reporting* style. Skip §3 steps 1-6 as written: you do **not** create a feature module of your own for the menu, take N/G ids, edit records, push a branch or open a PR. You work in a **read-only, detached worktree** of the other session's PR head, put any extra cases in a scratch file outside the repo (or an untracked file in your worktree), and deliver one report file. Report format: for each finding give severity, the case, the desktop citation, expected vs observed, and the evidence path; end with the three coverage numbers for the PR's own matrix plus yours.

## Mission

Another session built the Ledger Report as the desktop `RP_LEDR` screen (`feat/lite-ledger-report`, PR #195). Audit it independently. Known problem to confirm first: **it claims `N219/G232`, which `main` already uses for Auto Item**.

## Identity and hand-offs

- **SLUG** `audit-ledger-report`  **BRANCH** `(none — read-only audit; do not push to feat/lite-ledger-report)`  **worktree** `~/dc-wt/audit-ledger-report`  **feature module** `accountLedger (audit)`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-audit-ledger-report` (ports come from the stack slot you take, see 00-GENERIC §2.1).
- No browser stack needed for the audit setup until you run their module; the slot rules still apply.

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_LEDR` — mode: constructor caption 'Ledger Report'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8871-8880`
- **Tables:** `AC_DATA`, `AC_MAST`, `MAIN_STOCK`, `FINE_DATA`, `LEDR_AC_DATA`, `BOOK_DATA`, `LDR_ADJ_DATA`
- **Web routes:** `/reports/account-ledger`
- **API:** `GET /reports/account-ledger/:acCode`, `GET /reports/account-ledger/:acCode/export.pdf`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** N24, X26, P10-02, N57, N75
- **Purpose:** Shows account opening, movements and closing in money, gold and silver with voucher drill-down.
- **Recorded gap:** A basic ledger exists; metal/time/ageing/purchase modes, zero/sign semantics, nested drill-down and many Crystal variants remain.
- **Sources:** `unified/src/csharp/DataCareNext/RP_LEDR.cs:4658-7694`

## Desktop pointers (start your study here)

- `RP_LEDR.cs` is 11,814 lines; catalog range `RP_LEDR.cs:4658-7694`. Dispatch `MDI_FORM.cs:8871-8880`. Money, gold and silver modes; time/ageing/purchase modes; zero/sign semantics; nested drill-down; many Crystal variants (`AcLedger.rpt`, `AcLedgerSelected.rpt`, `AcFineGold.rpt`, `AcSumm.rpt`, `AcGroupRpt.rpt`).

## Current web state

- PR #195 adds `reports/account-ledger/{page,AccountLedgerGrid,useAccountLedger,types}`, API tests `accountLedgerReport(.db).test.ts`, `accountLedger.mjs` (424 lines), edits `txn.ts` and `routePolicy.test.ts`. API `GET /reports/account-ledger/:acCode` and `/export.pdf`.

## Scope — what you must deliver

- Same method as agent 20, read-only worktree: `git worktree add ~/dc-wt/audit-ledger --detach origin/feat/lite-ledger-report`.
- Specific checks: (1) **id collision and record hygiene** vs `origin/main`; (2) every desktop mode and option in `RP_LEDR` vs the 424-line module — list the modes with **no case**; (3) hand-compute ledgers for parties created through Sales/Purchase/Cash screens, including **gold/silver fine columns**, opening balances (Party Opening), Cr/Dr sign conventions, zero-balance rows; (4) drill-down to voucher; (5) PDF equals grid; (6) sentinels in other company/location/year/tenant; (7) rights `----PL`; (8) the catalog says the old web ledger lacked metal/time/ageing/purchase modes — confirm which exist now.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Same reporting format as agent 20; file `~/datacare-agent-reports/audit-ledger-report.md`.

## Risks and traps

- The ledger is the number owners trust most. A wrong closing balance is a high-severity finding.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- (read-only)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
