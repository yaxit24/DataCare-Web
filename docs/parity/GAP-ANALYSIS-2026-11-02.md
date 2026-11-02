
# Lite parity gap analysis, 2 November 2026

Independent audit of DataCare-Web against the Desktop Lite Edition (49 menus). Repository state: `origin/main` at `9c651837` (PR #220). It extends, and does not replace, `FEATURE-MATRIX.md` (menu-level view), `GAP-BACKLOG.md` and `AGENT-PROGRESS.md` from PR #220. Feature-level rows are in `FEATURE-PARITY-MATRIX.md`; the ordered work list is in `PRIORITISED-BACKLOG.md`.

Status stays in `docs/master-parity-plan-2026-09-29/execution-backlog.json`. This file records findings and evidence only. No G or N identifiers are taken here: findings carry `PA-nn` ids, and the register ids are allocated at merge time as `~/dc-wt/lanes.sh ids` requires.

## 1. Bottom line

- **Parity is not reached and no menu can be called complete.** 0 of 49 Lite catalog rows are FULL. Browser cases pass for 33 feature modules, but those cases are derived from the decompiled desktop source. Nothing has been compared against a running Windows desktop (see section 3).
- **Fresh browser evidence** (CI run 41437234529, `main` at `bb1f6586`, real Chromium, no mocks): 33 modules, 722 applicable cases, **598 pass, 20 fail (all baselined), 104 blocked, 0 untested**. Per-module numbers: `evidence/ci-main-bb1f6586-modules.json`. They agree with `run-snapshot.json`, except that `purchase-report` (17 frozen failing cases) is now present.
- **Main is red right now.** The two newest `main` runs (41437285568, 41438044967) fail on one NEW failure, `tag-cancel.journey.tag-stock-create-edit-delete`. It passed on the run before. Lane D already claimed this flake in `LANES.md`.

### The highest-priority gaps (all verified against source; details in the matrix)

| Rank | Id | Gap | Why it ranks here | Evidence | Existing owner |
|---|---|---|---|---|---|
| 1 | PA-01 | **Balance TrFr carries the wrong numbers.** `POST /balance-transfer/year-close` (and the web-only `/year-end/close`) merges gold and silver into one weight, reads `'-'` metal legs as positive, writes `SIGN` `'D'`/`'C'` where every web reader and the desktop use `'+'`/`'-'`, and carries non-party accounts (sales, expense) as openings. For the same data the desktop opens a party with gold 6.000 Cr and silver 50.000 Cr; the web leg reads back as silver 64.000 Dr and gold 0. Its delete predicate also clears Party Opening's own ledger legs. | Wrong opening balances in the next year; silent, no error shown | REPRO (`evidence/balance-transfer-sign-repro.sql`) + source | G212 / N201: planned, unowned, rated **Med** and describing only double counting. This finding is larger, so raise it to P0 |
| 2 | PA-03 | **Books can be deleted while vouchers use them, and reserved codes are accepted.** Desktop refuses both (`MS_BOOK.cs:2593`, `:2710`, `:2717`). Web `BOOK_DATA_CONFIG` has `references: []`. The sales and purchase registers `JOIN BOOK_DATA`, so deleting a used book removes its vouchers from the registers. Codes 888 and 999 are the closing-stock valuation books the web itself reads. | Data integrity; hides vouchers from reports | source (both sides) | none |
| 3 | PA-04 | **User Create is a stub.** Web has list, create, rights and password reset only. Desktop also deletes users, changes a password after checking the old one, and resets menu rights. 15 of 18 cases are placeholders. | Rights and access control | source + CI | none |
| 4 | PA-05 | **Approval Isu and Approval Rtn exist only on one laptop.** `feat/lite-approval`: 31 commits, 66 files, +12,646 / -2,168, no remote branch. `git merge-tree` against current `main` reports 20 conflicting files (13 code and test files, 7 record and generated files), and the count grows with every merge. `main` has issue, delete, return and bill routes but no reopen, edit or print. | Two Lite menus depend on it; one disk clean-up loses it (disk is at 96%) | git | unowned |
| 5 | PA-06 | **Sales Report is a header-only, date-only register.** `salesRegister` takes a date range and returns bill totals. Desktop RP_ALL has 13 sales modes (plus 2 UAE-only) with employee, book, party, item and group selectors. Purchase Rpt has 17 frozen cases failing; Order Report has 7 modes missing. | Daily owner reporting | source + CI | N24 planned; prompts 01-03 |
| 6 | PA-07 | **Stock Report (RP_STOCK) does not exist.** The menu and the catalog route to `/reports/tag-stock`, which is RP_TAG. F3 goes to a third screen (`/reports/stock-valuation`). | Inventory visibility | source | none |
| 7 | PA-08 | **Tag Stock (RP_TAG) is a thin copy.** Six tabs and two filters (Counter, Item). Desktop adds Summ, Counter, tag weight change and split launchers, Adjust, Excel and date, product and group selection. | Stock control | source | none |
| 8 | PA-09 | **Sales Return numeric edit is not reachable from the screen.** The writer exists (`PUT /sales-returns/:vchNo/incoming-numeric`, merged via #3). The browser case `sales-return.edit.numeric` stays blocked because no UI exposes it. | Core sales workflow | source + CI | N10, N11 planned |
| 9 | PA-10 | **Order Cancel handles one order only,** and its claim is stale: `~/dc-wt/order-cancel` has uncommitted work from 1 Nov and no branch. | Advance and refund accuracy | git + catalog | N37 planned; claim stale |
| 10 | PA-11 to PA-14 | **Statutory and scheme gaps with failing or blocked cases:** GST Report has 13 blocked cases and a labour discount that is always 0; Sales Order scheme tender fails (G206); Data Backup archive scope waits on D-BKP-3; Company identity workflow fails (G38). | Compliance and money | CI | existing, see matrix |

## 2. Scope and method

What I did, in order:

1. Read the coordination state: `LANES.md`, the agent prompt pack README, `docs/parity/*`, `docs/handbook/web/handoff-lite-parity.md`, the open and merged PR list (`gh pr list`), `execution-backlog.json` (228 slices: 148 implemented-unverified, 69 planned, 11 in progress), the defect baseline and the Lite rows of the progress page.
2. Pulled the latest green and the two newest red `main` CI logs with `gh run view --log` and parsed every module's result (above). This is the browser evidence; no local browser stack was started (section 3).
3. Compared desktop source with web code on both sides for the areas below, citing file and line in the matrix: Balance TrFr, Books, User Create, Approval routes, the Sales and Purchase registers, Stock Report and Tag Stock, the MDI shell keys, and the generic master delete path.
4. Reproduced the Balance TrFr defect in a throwaway Docker Postgres (`postgres:16-alpine`, port 55790, removed afterwards) using the web's own closing query and ledger formulas on hand-built rows.
5. Checked git state of the unpushed branches, and tested the approval branch against current `main` with `git merge-tree --write-tree`.
6. Cross-checked every Lite menu for a route, a page and a navigation entry, and listed the routes five pairs of menus share.

Evidence tags used in the matrix: **SRC** desktop and web code both read; **REPRO** reproduced in Docker; **CI** result of a browser case in the run above; **GIT** read from git or `gh`; **CAT** taken from the catalog or backlog text and not re-checked by me.

## 3. What I could not verify (so nothing is marked complete)

- **No desktop runtime.** The Windows binaries, `.rpt` templates and the SQL Server backup are Git LFS pointers in the repository. There is no Windows machine, so no screen, calculation or printout was compared with the running desktop. Every "web behaviour" is checked against decompiled source and frozen cases only.
- **No local browser session.** The Mac had about 85 MB of free memory and the data volume is at 96%. Other sessions hold the three stack slots. Starting a Postgres, API, web build and Chromium (2 to 3 GB) risked taking their stacks down. The browser results above come from the CI Chromium run, not from a session of mine.
- **Rows tagged CAT** (Cash Bank report, HuId Report, Purchase hallmark receive branch, Wh Sales remainder, Year Create, Data Import, Sales rounding) repeat the catalog or backlog. I did not re-open both sides for them.
- **The "16 missing Lite menus".** I could not find a document that lists 16. My reconstruction is in section 4. If your list differs, say which menus and I will re-cut the table.
- **PA-01 is a SQL-level reproduction,** not a click-through of the Balance TrFr screen. The cross-writer collision (running both actions) is derived from the two delete predicates, not executed.

## 4. The 16 Lite menus without a finished web counterpart (reconstruction)

12 Lite menus have no feature module on `main`; two more only borrow another menu's module; two have modules that are mostly placeholders.

| # | Menu | State on main | Verified fact | Owner |
|---|---|---|---|---|
| 1 | Year Create | no module | Premise in the prompt pack and catalog is partly stale (GB-07) | none |
| 2 | Balance TrFr | no module | PA-01: wrong carry-forward; 14+ desktop buttons, web has 3 actions | G212/N201 unowned |
| 3 | Books | no module | PA-03: no delete guard, no reserved-code check | none |
| 4 | Approval Isu | no module | PA-05: built, unpushed | none |
| 5 | Approval Rtn | no module | PA-05 | none |
| 6 | Order Cancel | no module | PA-10 | stale claim |
| 7 | Data Import | no module | `/masters/accounts` generic master; scope decided as Lite Soft only | none |
| 8 | Sales Report | no module | PA-06 | none |
| 9 | Purchase Rpt | frozen module, 17/17 fail | no screen | none |
| 10 | Approval Rpt | no module | three data modes; InOut fixed in #203 | none |
| 11 | Cash Bank | no module | web `cash-book` is not RP_CASH_BANK (CAT) | none |
| 12 | HuId Report | no module | filters only (CAT) | none |
| 13 | Stock Report | borrows `tag-cancel` | PA-07: screen is RP_TAG | none |
| 14 | Tag Stock | borrows `tag-cancel` | PA-08 | none |
| 15 | Company | module, 21 of 28 blocked, 1 fails | G38 | N58 follow-up |
| 16 | User Create | module, 15 of 18 blocked | PA-04 | none |

## 5. Do not duplicate: who holds what (checked 2 Nov, evening)

| Area | Holder | State |
|---|---|---|
| Tag label text (G240) | session `52f05ab4` | PR #222 open |
| Catalog text for Approval Rpt and Gst Report | PR #221 | open |
| `main` CI flakes (`tag-cancel`, `address-master`) | Lane D | claimed |
| Esc on screens with a wrapper handler (GB-02), four stale cash-bank catalog rows (GB-05) | Lane D | named as next, not yet claimed on the board |
| Approval Isu / Rtn | `~/dc-wt/lite-approval` | unpushed |
| Order Cancel | `~/dc-wt/order-cancel` | uncommitted, stale |
| `feat/sale-return-numeric-write-x13` | `~/DataCare-Web` checkout | on origin, 0 commits ahead of `main`, no PR |

Nobody holds Balance TrFr, Books, User Create, Stock Report, Tag Stock, Cash Bank, HuId or Data Import.

## 6. Corrections to existing documents

- `FEATURE-MATRIX.md` and the catalog say Approval Isu is "create-only". `main` also has delete, return, return delete, line lookup and bill-from-approval (`web/apps/api/src/routes/txn.ts:8080-8201`). Reopen, edit and print are still missing.
- G212 describes only a double count. See PA-01 for what it leaves out.
- `FEATURE-MATRIX.md` shows Stock Report as PARTIAL with module evidence from `tag-cancel`. Those cases cover the Tag Stock output of Tag Cancel; there is no RP_STOCK screen (PA-07).
- Web route table: `/utilities/year-end` is marked Lite (`web/packages/core/src/editionTable.ts:255`) although the desktop Lite menu has no Year-End Close. It carries the PA-01 defect.

## 7. Verification log

| What | How | Result |
|---|---|---|
| Main CI state | `gh run list --branch main` | newest two runs red, one NEW case failure |
| Browser results | `gh run view 41437234529 --log`, parsed | 33 modules, 598 / 20 / 104 |
| Open PRs | `gh pr list` | #221, #222 |
| Balance TrFr | read `BtmSchm.cs`, `yearEnd.ts`, `year.ts`; Docker SQL | PA-01 reproduced |
| Unpushed work | `git rev-list`, `git branch -r --contains`, `git merge-tree` | 31 commits, no remote, 20 conflicting files |
| Docs gates | `python3 docs/tools/docs_check.py` | see the commit message |
