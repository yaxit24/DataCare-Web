
# Lite parity: what remains, in order (P0 to P3)

Work list derived from `FEATURE-PARITY-MATRIX.md` (ids `PA-nn`) and `GAP-ANALYSIS-2026-11-02.md`. State at 2 November 2026, `origin/main` `9c651837`. This is a view. The authoritative slice list is `docs/master-parity-plan-2026-09-29/execution-backlog.json`; where a slice already exists the item names it and does not create a second one. Register ids (G, N) are taken at merge time with `~/dc-wt/lanes.sh ids`, not here.

**Two bars.** FULL is the project's bar: the catalog row is FULL and the module has no failing or blocked case. VERIFIED PARITY is this audit's stricter bar and also needs a recorded comparison with the running Windows desktop. Today 0 of 49 menus meet either bar.

**Sizes.** S under a day, M one to three days, L about a week, XL more than a week of focused work for one agent. These are relative sizes from the line counts and the work involved, not forecasts.

**Before taking an item,** read `AGENT-PROGRESS.md` and `~/dc-wt/LANES.md`, add your claim, work in your own worktree and branch, and open a PR without merging it.

## Do these first

| Order | Item | Why first | Size |
|---|---|---|---|
| 1 | P0-1 Back up the approval branch | One disk clean-up loses 12,646 lines of finished work | S (minutes) |
| 2 | P0-3 Balance TrFr: one correct writer | Silent wrong opening balances; nobody owns it | M to L |
| 3 | P0-4 Books delete and reserved-code guards | Deleting a used book hides its vouchers from the registers | S to M |
| 4 | P0-2 Release or push the order-cancel work | Stale claim blocks Order Cancel | S |
| 5 | P0-1 (second part) Land Approval Isu and Rtn | Two Lite menus | L |
| 6 | P0-5 User Create | Access control; needs owner decisions first | L |
| 7 | P1-1 RP_ALL engine with Sales Report | Unblocks Sales, Purchase, Approval and Order reports | XL |

## P0: data integrity, security, business correctness

| ID | Matrix | Item | What to do | Proof that it is done | Size | Existing owner or slice | Depends on |
|---|---|---|---|---|---|---|---|
| P0-1 | PA-05, PA-42 | **Back up, then land, Approval Isu and Rtn** | Step 1, now: push the branch to a backup name, for example `git push origin feat/lite-approval:refs/heads/backup/lite-approval-2026-11-02` (no PR), or `git bundle create` to a folder outside `~/dc-wt`. Step 2: merge `origin/main` into it and resolve the 20 conflicting files. Seven are record and generated files (rebuild them from `main` as `handoff-lite-parity.md` section 9 says); thirteen are code and test files, including `txn.ts`, `tagCancel.ts`, `TagCancelForm.tsx`, `tagCancel.mjs`, `run-features.mjs`, `coverage-map.json`. Step 3: renumber its record ids and open the PR. | Two feature modules (issue, return) pass their frozen cases; catalog rows updated; `pnpm progress` shows the Lite row rise by two; static gates green | S then L | none; prompt 12 describes it | none |
| P0-2 | PA-10, PA-42 | **Order Cancel claim** | The owner of `~/dc-wt/order-cancel` commits and pushes `orderCancel.ts`, `orderCancel.db.test.ts` and the `salesOrder.ts` edit, or releases the claim on the board so another agent can take N37. | A pushed branch or a released claim in `LANES.md` | S | claim stale since 1 Nov | none |
| P0-3 | PA-01, PA-24 | **Balance TrFr: one correct writer for the account carry** | Keep one writer, the one that goes through the Party Opening writer (`carryForwardOpenings`, the desktop's shape). Make it match `BtmSchm.Rtl_AcOpbl`: join `AC_MAST` and keep `AC_MAIN_GR < '3'`; filter `VCH_DATE <=` the close date; gold and silver as separate signed sums with `'+'` = credit; skip all-zero parties. Make `POST /balance-transfer/year-close` and `/year-end/close` call it or remove them. Take `/utilities/year-end` out of Lite (`editionTable.ts:255`) or point it at the same writer. Rewrite `yearEndCarry.db.test.ts`, which asserts the `'D'`/`'C'` convention. | (a) A DB test with desktop-convention rows (use `evidence/balance-transfer-sign-repro.sql` as the fixture) where gold, silver and money close and read back equal to the desktop figures; (b) running the two actions in either order leaves one opening per party; (c) sales and expense accounts are not carried; (d) a frozen `balance-transfer` browser module T01-T18 | M to L | **G212 / N201**, planned, unowned, rated Med. Raise it to P0 and extend its scope to cover (1) to (6) in PA-01 | N199 merged |
| P0-4 | PA-03 | **Books: delete and reserved-code guards** | In the Books writer: refuse codes 218, 888 and 999 with the desktop text (`MS_BOOK.cs:2593`); refuse delete when `AC_DATA` (company, book) or `MAIN_STOCK` (company, location, book) has rows, with the two desktop texts (`:2710`, `:2717`); delete `BOOK_DETL` rows with the book in the same transaction (check for a cascade first). Today `BOOK_DATA_CONFIG` has `references: []`. This edits shared master code: announce on the board first. | DB test through the real routes: a used book cannot be deleted; 888 cannot be created; unused book delete removes its slots; a browser module `books` | S to M | none; prompt 13 covers the screen | none |
| P0-5 | PA-04 | **User Create** | Write the 15 placeholder cases first. Then add: delete user (with audit and the existing last-administrator guard), change password with old-password check and confirm match (`MS_USER.cs:2205-2250`), reset-all-menu (`:2504`, `:3464`). Keep the web's stronger password policy. | `users` module: 18 of 18 pass; direct-API rights checks per route | L | none; `fix/n169-last-admin` already merged | Owner decisions D-USR-1 to 3 (below) |

## P1: missing core function or broken workflow

| ID | Matrix | Item | What to do | Proof | Size | Existing owner or slice |
|---|---|---|---|---|---|---|
| P1-1 | PA-06, PA-15, PA-16, PA-19 | **RP_ALL engine, then Sales, Purchase, Approval and Order reports** | Build the shared selector, filter and grouping engine in its own route directory (never in `reports/[report]/page.tsx`, at its size ceiling). Sales Report first (13 modes, then selectors). Each case that turns green leaves `baseline.json` in the same PR. | `sales-report` module; the 17 `purchase-report` cases leave the G06 baseline | XL | N24, N36, N57; prompts 01, 02, 03 |
| P1-2 | PA-07, PA-33 | **Stock Report (RP_STOCK) as its own screen** | New route with Group, Product, Item, Design, Safe, Counter, Trading, Size, InOut, OthDtl; re-point the catalog row and F3; keep `/reports/stock-valuation` only if it is a real mode. | `stock-report` module | L to XL | none; prompt 05, after 04 |
| P1-3 | PA-08 | **Tag Stock (RP_TAG) filters and launchers** | Date, product and group selection, Summ, Adjust, Excel, tag weight change and split launchers. | `tag-stock` module separate from `tag-cancel` | L | none; prompt 04 |
| P1-4 | PA-09 | **Sales Return numeric edit on the screen** | Expose `PUT /sales-returns/:vchNo/incoming-numeric` from the Saved returns panel with stale-draft recovery. | `sales-return.edit.numeric` leaves blocked and passes | M | N10 done in the writer; **N11** planned |
| P1-5 | PA-10 | **Order Cancel as the desktop voucher** | Multi-order grid, bounds, ledger, Rojmel, stock and tag rows, lifecycle, print. | `order-cancel` module | L | **N37**; prompt 11; see P0-2 |
| P1-6 | PA-02 | **Balance TrFr: other branches** | First decide which of the 14 desktop buttons need a carry in a single database keyed by year (stock is year-keyed: `yearEnd.ts` reads `MAIN_STOCK` by `CO_YEAR`). Then build them one at a time, each with a conservation check (balance before equals balance after). | Per branch: a conservation test and a browser case | XL | unowned; prompt 15 |
| P1-7 | PA-11 | **Gst Report: labour discount and the 13 blocked cases** | The web `LBR_ISU_DETL` has no discount column; the desktop sums `IT_DISC_AMT` (`RP_GST.cs:2719`). Add the column or compute it, then unblock the cases. | `gst-report` 70 of 70 | M | none (#206, #217 merged) |
| P1-8 | PA-12 | **Sales Order scheme tender** | Owner decides whether to write Rojmel row 05 to fixed account 00079 given 7 real orders carry a scheme amount without one; then build. | `sales-order.create.scheme-tender` passes, baseline entry G206 removed | S decision, M build | G206 |
| P1-9 | PA-17 | **Cash Bank report (RP_CASH_BANK)** | Cash/bank, scheme-member and pending modes, drill-down, AcLedger and PassBook layouts, own route. | `cash-bank-report` module | L | none; prompt 06 |
| P1-10 | PA-14 | **Company identity workflow** | Versioned writer with first-year provisioning (N58). Company delete stays an owner decision. | `company-master.fields.complete-round-trip` passes | L | N58, G38 |
| P1-11 | PA-20, PA-13 | **Data Refresh PR-2 and Data Backup scope** | Prove the Account and Stock builder graphs or keep them preview-only on purpose; classify Field Update and Old Field. Decide D-BKP-3. | `data-refresh` blocked count falls from 8; baseline G64/N80 removed | L | X27/P11-01; N80 |
| P1-12 | PA-25 | **Sales rounding** | Decide D05, then N184 and N185. | The two merged expectations move to the whole-rupee figures in the same PR | M | N184, N185 |
| P1-13 | PA-38 | **Mutation safety** | Runtime schemas (N50), version tokens (N51), idempotent commands (N52). | Replaying a save never makes a second voucher on any Lite screen | L | N50, N51, N52 |
| P1-14 | PA-43, PA-26 | **Lossless reopen, tender and source branches (Sales); hallmark receive (Purchase)** | Per the catalog gap text. | Module cases for each branch | L | N15, N63, N32 |
| P1-15 | PA-39 | **Main CI red** | Find whether `tag-cancel.journey.tag-stock-create-edit-delete` is a race in the case or in the Tag Cancel form. | Ten consecutive green `main` runs | S | Lane D |
| P1-16 | PA-23 | **Books: slot semantics, clone, print** | After P0-4. | `books` module T01-T18 | M | none |

## P2: behaviour or interface mismatch

| ID | Matrix | Item | Size | Existing owner or slice |
|---|---|---|---|---|
| P2-1 | PA-35 | Alt+C, M, T, N, K, O, S, R tab shortcuts on the start screen (`MDI_FORM.cs:12530-12590`) | S | none |
| P2-2 | PA-36 | Esc with no focused control on nine screens: write a case per screen, then a shared hook | M | GB-02, Lane D |
| P2-3 | PA-37 | Receipt screen accessibility: contrast of the red `0 Dr` text, labels on Party Name and PAN | S | lane A inbox |
| P2-4 | PA-22 | Year Create: entry rules and the "Year Is Already Exist" message; do not port the Delete routine | S to M | none |
| P2-5 | PA-21 | Data Import, Lite Soft only, atomic, refuses a company with data. A sample `.mdb` is needed | L | none; prompt 19 |
| P2-6 | PA-18 | HuId Report: tabs, product and group helps, drill-down, layout | M | none; prompt 08 |
| P2-7 | PA-16, PA-19 | Order Report modes and Approval Rpt selectors if not covered by P1-1 | M | none |
| P2-8 | PA-28, PA-30 | Blocked calculation, settlement, rights, rollback and retry cases in cash-bank, party-opening, item-opening, tag-opening | M | none |
| P2-9 | PA-31 | Daily Rate: location-00 session in the harness, external push | M | none |
| P2-10 | PA-32 | Tag label text (PR #222) and physical printer acceptance (D29) | S, then owner | #222 open |
| P2-11 | PA-41 | Fault injector (N166): turns 5 rollback and 3 setting-variant cases from blocked into runnable | L | N166 |
| P2-12 | PA-44 | Ledger Report opening-ledger ageing union | M | none |
| P2-13 | PA-27 | Wh Sales remainder: loose-item detail rows, bill rows, fine kasar | M | N45 |

## P3: minor, or not provable without the desktop

| ID | Matrix | Item | Note |
|---|---|---|---|
| P3-1 | PA-34 | F11 should do nothing in Lite (`MDI_FORM.cs:14217-14240`); the web opens Rojmel | One line in `FormKeys.tsx` plus a case |
| P3-2 | PA-29 | Crystal layouts for AcMast, PartyMast, GroupMast, TaxMast, EmpMast | The `.rpt` files are LFS pointers on a clean clone; the extraction XML exists |
| P3-3 | PA-28b | Contra and Fine Jv Windows comparison; four blocked Fine Jv cases | Needs P3-4 |
| P3-4 | PA-40 | **Windows desktop run** (N03): capture protocol, sanitised fixtures, the same frozen cases on the original | The only way to move any menu from PARTIAL to VERIFIED PARITY |

## Decisions needed from the owner

| Id | Question | Blocks |
|---|---|---|
| D-BT | In a single database keyed by year, which stock, tag, order, scheme, loan and approval balances need a year-end carry? | P1-6 |
| D-USR-1 | User delete: hard delete as the desktop does, or disable and keep history? | P0-5 |
| D-USR-2 | Change-password flow: keep the web's 12-character mixed policy and add the old-password check? | P0-5 |
| D-USR-3 | Does the Lite edition show the per-form rights grid? | P0-5 |
| D05 | Rounding defaults for new companies | P1-12 |
| D-BKP-3 | Data Backup archive scope (tenant configuration envelope) | P1-11 |
| D-SCH | Scheme tender Rojmel row 05 | P1-8 |
| D-CO | Company delete in a hosted multi-tenant system | P1-10 |
| D-WIN | Provide a Windows machine and a sanitised desktop database for the comparison run | P3-4 |

## Index: matrix id to backlog item

PA-01 P0-3 · PA-02 P1-6 · PA-03 P0-4 · PA-04 P0-5 · PA-05 P0-1 · PA-06 P1-1 · PA-07 P1-2 · PA-08 P1-3 · PA-09 P1-4 · PA-10 P0-2, P1-5 · PA-11 P1-7 · PA-12 P1-8 · PA-13 P1-11 · PA-14 P1-10 · PA-15 P1-1 · PA-16 P2-7 · PA-17 P1-9 · PA-18 P2-6 · PA-19 P2-7 · PA-20 P1-11 · PA-21 P2-5 · PA-22 P2-4 · PA-23 P1-16 · PA-24 P0-3 · PA-25 P1-12 · PA-26 P1-14 · PA-27 P2-13 · PA-28 P2-8 · PA-28b P3-3 · PA-29 P3-2 · PA-30 P2-8 · PA-31 P2-9 · PA-32 P2-10 · PA-33 P1-2 · PA-34 P3-1 · PA-35 P2-1 · PA-36 P2-2 · PA-37 P2-3 · PA-38 P1-13 · PA-39 P1-15 · PA-40 P3-4 · PA-41 P2-11 · PA-42 P0-1, P0-2 · PA-43 P1-14 · PA-44 P2-12
