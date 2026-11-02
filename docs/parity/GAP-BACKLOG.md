# Lite edition gap backlog (parity view)

Last refreshed: 2 November 2026, about 16:45 IST, on `main` at `a25994c6`. A person keeps this file current; there is no generator.

**This is a view, not the register.** The authoritative gap register is table §3 of `docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md`
(IDs `G###`), and slice status lives in `docs/master-parity-plan-2026-09-29/execution-backlog.json`. Items here point to those. An item that
is **not yet in doc 12** has an ID of the form `GB-nn` and says so; whoever fixes it records the real `G###` then (IDs must stay contiguous and are
taken last, after a rebase).

**Priority** (the task's scale): **P0** critical data integrity, security or business correctness; **P1** missing core functionality or broken workflow;
**P2** behavioural or UI/UX mismatch; **P3** minor, or not provable without a desktop runtime.
**Evidence tags:** *source* = read in the desktop C# with a citation; *run* = a browser case executed in this session; *catalog* = taken from the
menu catalog text and not re-checked; *inferred* = my reading, not proven.

**Desktop reference limit.** Source and keyframes only; no Windows runtime, no binaries (Git LFS pointers). Desktop-match coverage is 0% for every item.

## A. Found in this session

| ID | Pri | Item | Evidence | Where recorded | Owner / status |
|---|---|---|---|---|---|
| GB-01 | P1 | `main` was red: `tag-print.keyboard.desktop-keys` failed in 7 of 24 CI runs between 06:30 and 09:01 UTC on 2 Nov, and again on main after #209 | run + CI logs | **G239** (PR #218) | PR #218 open, fix verified red then green; CI pending |
| GB-02 | P2 | Nine other screens handle Esc only in a wrapper `onKeyDown`, so Esc is lost when no control has the focus: Party, Item, Item Group, Product, Tax, Address, Employee, Auto Item, Item Opening | inferred (same code shape as Tag Print; not run) | G239 "not closed" note | unowned; needs a case per screen, then a shared hook |
| GB-03 | P1 | `feat/lite-approval` holds 31 commits on no remote branch; Approval Isu and Approval Rtn (two Lite menus, about 12.6k lines and 2,229 lines of lifecycle tests per the prompt pack) exist only on this laptop | source: `git log`, `git branch -r --contains` | not a product gap; delivery risk | unowned; owner should push or back it up |
| GB-04 | P2 | `~/dc-wt/order-cancel` claims Order Cancel with about 16 h old uncommitted work and no pushed branch | source: `git status`, file times | LANES.md Lane B2 (stale) | owner should push or release |
| GB-05 | P2 | Catalog gap text is stale for Cash Received / Payment / Bank Received / Bank Payment: it says no reopen, edit, delete or reprint and that a repeated submit makes a second voucher, but `cash-bank.reopen-edit-delete.receipt`, `edit.unchanged-save`, `delete.audit` and `retry.double-click` pass | run | `docs/handbook/menu-catalog.jsonl` rows | unowned; correct the four rows when the module is next touched |
| GB-06 | P3 | `docs/handbook/web/standard-progress.md` counts a menu as having a module when `coverage-map.json` lists its page; Stock Report and Tag Stock show "module green" only because the `tag-cancel` module covers their Tag Stock output cases | source | progress generator | note only; do not read it as full coverage of RP_STOCK or RP_TAG |
| GB-07 | P2 | **Year Create: the prompt pack and the catalog row overstate the work.** The desktop's 17-table copy (`NewCompParmCreat`, `MS_YEAR.cs:1504-1595`) runs only when a new company gets its first year (`:1357-1362`); the web already does that (`year.ts`, G97). For an existing company the desktop restores the previous year's whole database as a new one and then deletes the other years' rows with 97 DELETE statements over 95 tables (`:1239-1282`, `:1403-1502`; 90 keyed by year, 5 unscoped, 2 by company); the web has one database keyed by `CO_YEAR`, so there is nothing to port. The desktop `&Delete` button is visible but runs the User-form routine "Are You Sure To Delete This User now?" and deletes `LOGIN_MAST` and `USER_SET` rows named by the typed year text (`:970-991`): it deletes no year. Print only checks the print right (`:961-968`). The desktop exits the whole application after a new year is created or found to exist (`:1394-1400`) | source | G97 (partly); catalog row and prompt 14 contradict it | unowned. Real remaining checks: year-code and date entry rules (`:1090-1136`), the `YEAR_MONTH` alternate-year branch (`:1153-1198`), the "Year Is Already Exist" message, rights texts. Do **not** port the Delete routine (weakness) |

## B. Open in the register and still unowned, ranked

| Pri | Menu | Gap (register ID) | Why this rank | Size |
|---|---|---|---|---|
| P0 | Balance TrFr | Web carries accounts and party openings only; stock, order, scheme, loan, approval, repair, lot and manufacturing branches, Print and interruption recovery remain (catalog; N58, X10, X27) | Moves money, stock and scheme balances between financial years; a wrong carry-forward is silent. Waits for Year Create | L |
| P0 | User Create | 15 of 18 browser cases are `.pending` placeholders; user delete and print, action-level enforcement, atomic audit remain (catalog) | Rights and user management. Not in the prompt pack. `fix/n169-last-admin` and `lite-rights-aliases` already merged, so the base is sound | L |
| P1 | Approval Isu / Approval Rtn | Create-only shared Tour page on `main`; custody chain, edit, delete, print absent (catalog) | Two Lite menus; the built work is the GB-03 unpushed branch, so the first step is landing it, not rebuilding | L |
| P1 | Cash Bank report | Cash Book does not prove the RP_CASH_BANK modes, drill-down or AcLedger/PassBook layouts (catalog) | Daily cash and bank book. Read-only, so low risk. `RP_CASH_BANK.cs` is 4,813 lines | L |
| P1 | Sales Report / Purchase Rpt / Order Report | The shared RP_ALL engine does not exist; frozen Purchase Rpt cases (#202) wait for it (catalog, N24) | One engine unblocks three menus; `RP_ALL.cs` is 12,662 lines | XL |
| P1 | Stock Report, Tag Stock | RP_STOCK summaries and drill-down missing; RP_TAG filters and columns incomplete (catalog) | Inventory visibility. Tag Stock is the larger form (`RP_TAG.cs`, 10,813 lines) | XL |
| P1 | Books | Slot semantics, desktop 3-digit codes, cloning, reference guards, Print (catalog) | Every posting reads the book slots; wide blast radius | L |
| P1 | Company | G38: rich identity workflow absent; the executable T02 case fails (baselined) | The only fix is the versioned writer plus first-year provisioning (N58) | L |
| P1 | Data Refresh | Account and Stock are preview-only; Field Update and Old Field still to classify (PR-2) | Repairs that rewrite ledger and stock | L |
| P2 | HuId Report | PR #23 added filters; the desktop form also has product and group helps, a search box, Stock/In/Out buttons, a tag-no box, a party help, double-click drill-down and a Crystal print (`RP_HUID.cs`: `tSerchAll_TextChanged :1655`, `BtnStock/In/Out_Click :2151-2161`, `DGV_DoubleClick :2252`, `tAcCode_KeyDown :2684`) | Compliance register; smaller form (2,731 lines). The `TagHuIdRpt` template may not be in the repository | M |
| P2 | Order Cancel | Single order only; multi-order adjustment and the full write set remain (catalog; N37) | Claimed but stale (GB-04) | M |
| P2 | Data Import | Only generic master-row import; scope decided as Lite Soft only, atomic, refusing a company that already has data | Lowest priority by owner decision | L |

## C. Recorded blockers that are not work items

- **Owner decisions pending:** D-BKP-3 (Data Backup archive scope, G64/N80); Company delete (cascade delete is unsafe in a hosted multi-tenant system and no guarded equivalent is accepted); physical label printers (D29).
- **Artifacts missing from the repository:** Crystal templates for AcMast, PartyMast, GroupMast, TaxMast, EmpMast and the Tag labels (the web prints its own sheets, recorded per menu); `TagHuIdRpt` unconfirmed; a sample Lite Soft `.mdb` for Data Import; the Windows binaries and SQL Server backup (LFS pointers).
- **Harness limits:** a location-00 session (Daily Rate T15), and `company-open` has 16 of 18 cases pending.
- **Process:** GitHub Actions had a billing failure on 28 October; it runs again now (CI results were read from the run logs on 2 November).

## D. How to take an item

1. Read `AGENT-PROGRESS.md` and `python3 docs/tools/session_status.py`; do not take a menu with an owner there.
2. Add your claim to `AGENT-PROGRESS.md` (and the `~/dc-wt/LANES.md` board if you work on this machine) **before** editing code.
3. Work in your own worktree and branch `agent/parity-<module>-<task>`; open a PR; do not merge.
4. Record a real `G###`/`N###` last, after rebasing on `origin/main` (`~/dc-wt/lanes.sh ids`).
