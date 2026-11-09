# Agent progress and claims

Shared coordination file for parallel Kiro sessions on the Lite parity goal. Last updated: 2 November 2026, about 17:20 IST, by session `52f05ab4`
(lane "C", worktree `~/dc-wt/parity-coord`). It complements, and does not replace, `~/dc-wt/LANES.md` (the live board on the shared laptop),
`python3 docs/tools/session_status.py` and the backlogs. Status lives in `docs/master-parity-plan-2026-09-29/execution-backlog.json`.

Edit this file only in a pull request, never in a shared working tree. If two PRs edit the same row, the one that merges second merges `main` and keeps both rows.

## Claims (who holds what right now)

| Claim | Holder | Branch / PR | Files claimed | State | Since |
|---|---|---|---|---|---|
| Tag label text rules (G240, on N225) | session `52f05ab4` | `agent/parity-tag-label-content`, PR to follow | `web/apps/api/src/modules/stock/tagPrint.ts` (renderer only), `tagPrintScreen.ts` (two lines), `test/tagLabelText.test.ts`, the label cases in `modules/tagPrint.mjs` | code and tests done and red-then-green; records written; PR not yet opened | 2 Nov 17:05 |
| WP-06 User Create (`MS_USER`, D34-D36) | agent session (wp06) | `agent/wp06-user-create`, PR to follow | `web/apps/api/src/modules/auth/password.ts`, `passwordAccount.ts`, `sessionContextLogin.ts`, `rbac/users.ts`, `rbac/authorization.ts`, a new `rbac/userMaster.ts` + `routes/userMaster.ts`, a `LOGIN_MAST` migration, `app/(app)/admin/users/page.tsx`, `test/features/modules/usersRights.mjs` | started | 9 Nov |
| WP-09 Esc with no focused control on nine screens (GB-02, under G239) | agent session (wp09) | `agent/wp09-esc-no-focus`, PR to follow | `web/apps/web/lib/screenEscape.ts`, the `onScreenKeyDown` wrappers of Party, Item, Item Group, Product, Tax, Address, Employee, Auto Item, Item Opening and Tag Print, one case per screen in their feature modules | started | 9 Nov |
| Order Cancel | not this session; `~/dc-wt/order-cancel` | `feat/order-cancel`, nothing pushed | `modules/sales/orderCancel.ts`, `test/orderCancel.db.test.ts`, edits to `salesOrder.ts` | **stale suspect**: uncommitted for about 17 h | 1 Nov 23:00 |

Merged today from this session: #218 (Tag Print Esc, G239) and #220 (this coordination set), by the repository owner with all CI jobs green.
There was no open pull request on `main` at 17:15. Every other Lite menu has no open PR and no pushed branch with unmerged work (`gh pr list`, `git branch -r`).

## Do not touch (other sessions' work)

- `~/dc-wt/order-cancel`, `~/dc-wt/lite-approval`, `~/dc-wt/wh-sales`, `~/dc-wt/kiro-impl`, `~/dc-wt/feature-e2e` and every `~/dc-review/*` checkout.
- `~/DataCare-Web` itself (it sits on `feat/sale-return-numeric-write-x13`).
- The stash list is shared across worktrees: `stash@{0}` belongs to `feat/lite-fine-jv-feature`. Leave it.

## Risks for the owner

1. **`feat/lite-approval` has 31 commits that exist on no remote branch.** Approval Isu and Approval Rtn exist only on this laptop. Push the branch, or back it up, before any worktree cleanup. `~/dc-wt` is 73 GB and the disk is at 97 to 98%, so cleanup is likely.
2. **The LFS cache is the only copy of the desktop reference material on this machine.** All 3,026 LFS objects of the working tree (1,130 JPG, 870 DLL, 609 RPT, 42 EXE, the SQL Server backups) are cached in `~/Desktop/imodule-extracted/.git/lfs/objects` (1.0 GB). Deleting that clone would turn them back into pointers; a fresh clone needs `git lfs pull`.
3. **Disk and memory.** The data volume had 11 GiB free at 98%; swap was about 6 GB of 8 GB used. Run one browser stack at a time unless you took a slot; clean finished worktrees whose PR merged.
4. **Order Cancel claim looks abandoned** (see the table). Someone should push its partial work or release the claim.

## Done this session

| Item | Result | Evidence |
|---|---|---|
| Repository reconnaissance | desktop is source plus report templates plus 2021 keyframes; the executable exists (23 MB Windows .NET assembly) but cannot run on this Apple-silicon Mac | `TEST-EVIDENCE.md` §1 |
| Found why `main` was red | `tag-print.keyboard.desktop-keys`, a lost Esc when no control has the focus | `GAP-BACKLOG.md` GB-01 |
| Esc fix + deterministic case, PR #218 (merged) | red before, green after; tag-print 18/18; full feature suite 539 passed, 3 baselined failures, 91 blocked, 0 untested; all three CI jobs green | `TEST-EVIDENCE.md` §2-§4 |
| Coordination docs, PR #220 (merged) | 49 Lite menus classified; 0 VERIFIED PARITY | `FEATURE-MATRIX.md`, `GAP-BACKLOG.md` |
| Tag label text (G240), branch ready | unit tests 10 plus browser cases `output.label-sheet` and `output.label-labour-lines`: red on the old renderer, green on the new | `GAP-BACKLOG.md` GB-08 |
| Stale specs found | Year Create's prompt and catalog row overstate the work (GB-07); several "template not in the repository" notes are wrong (GB-09); the cash-bank catalog text is stale (GB-05) | `GAP-BACKLOG.md` |
| User Create desktop study | done, not built: it needs owner decisions (see GB-10) | `GAP-BACKLOG.md` GB-10 |

## Not done, and why

- No desktop-runtime comparison: the executable cannot run here (no Windows, Wine, Mono or Windows container).
- API and core packages were untouched by #218; for the label change the new code is in the API, so its DB-backed suite should run in CI (the unit file and the browser module were run locally).
- Docker failure and recovery, restart persistence, mobile layouts and role matrices beyond what the existing modules cover: not executed.
- User Create, Cash Bank, HuId, Sales Report, Stock Report, Tag Stock, Books, Year Create, Balance TrFr, Data Import, Approval Isu/Rtn: not implemented in this session.

## Checkpoint (to resume without repeating discovery)

- Repository `~/DataCare-Web`, GitHub `yaxit24/DataCare-Web`. Working worktree `~/dc-wt/parity-coord`. `main` was `9c651837` at 17:15.
- Branch `agent/parity-tag-label-content`: two commits ahead of `main` (the change, then a merge of `main`), plus uncommitted record edits to doc 12, the backlog, the catalog and these files. Open the PR after committing them.
- Build: Node 24.22.2 from `~/.nvm/versions/node/v24.22.2/bin`, `pnpm install --frozen-lockfile`, then build in this order: `@datacare/db` (generate, then build), `types`, `core`, `api`, then `web` with `API_ORIGIN=http://127.0.0.1:<API port>`. Slot 1 ports: DB 55501, API 4611, web 4612, project `dc-parity-coord`. Release the slot (`rmdir ~/.cache/datacare-stack-slots/slot-N`) after every run.
- A full feature run takes about 8 minutes once built; the web build is 2-3 minutes with a warm Turbo cache.
- Re-run `python3 docs/parity/build_matrix.py` after any change to the catalog, the progress page, `run-snapshot.json` or `ownership.json`.

## Exact next independent tasks (in order)

1. **Open the PR for `agent/parity-tag-label-content`** (G240) and watch CI. Do not merge.
2. **Add the PRINT_MAST label-file choice to Tag Print.** The desktop picks one of QrPrint10, BarPrint10, BarPrint13, GhatTagPrnt; the web prints one sheet. Read `SubTagPrint.rpt` first (not extracted; it is in `~/Desktop/imodule-extracted/.git/lfs/objects` as an LFS object if the file is tracked, otherwise ask for it).
3. **Cash Bank report (`RP_CASH_BANK`)** or **HuId Report (`RP_HUID`)**: both unowned; `TagHuIdRpt` and `RojMelCash` templates exist. Each in its own route directory, never in `reports/[report]/page.tsx` (at its size ceiling).
4. **User Create (`MS_USER`)** once the owner decides the password policy and delete semantics (GB-10).
5. **Land `feat/lite-approval`** (GB-03) if its owner does not: it needs the owner's consent because it is another session's branch.
6. **Esc on the nine other wrapper-handler screens** (GB-02): one case per screen first. Taken as WP-09 on `agent/wp09-esc-no-focus` (9 Nov): cases red then green, shared hook `web/apps/web/lib/screenEscape.ts`.
7. **Correct the four cash-bank catalog rows** (GB-05) when that module is next touched.

## Session D (Kiro, worktree `~/dc-wt/parity-d`), checkpoint 2 Nov 2026, about 20:15 IST

| Item | Result | Evidence |
|---|---|---|
| Main CI red on 2 Nov | Two different NEW failures, each with a readable cause in the run's `real-stack-browser-*` artifact (`gh run download <id>`; open `01-failure.png`) | runs 41438044967, 41437285568 |
| Address Ctrl+E focus race | Fixed, PR #223: focus the code box in a layout effect instead of `setTimeout(0)` | new case `address-master.field.ctrl-e-focuses-code-at-once`: red before, green after; module 18 of 18 |
| Typed Vch No overwritten by the next-number read (Tag Cancel, Stock Adjust, Tag Transfer share the form) | Fixed, PR #223 (G241 under N210 and N217) | `tag-cancel.reopen.late-list-keeps-typed-voucher-number` 22 of 22; `stock-adjust...` red on the old form, 20 of 20 |
| GB-05 cash-bank catalog text | Corrected, PR #224 (docs only) | cash-bank module 19 passed, 2 blocked, 0 failed |
| GB-07 Year Create entry rules | Studied and dropped: the web already validates year code, month and dates (`core/fiscalYear.ts`); what is left is a desktop "restart the software" message | `MS_YEAR.cs:1090-1200, 1394` |

Both PRs had static-gates, quality and real-stack green on CI at the time of writing. Neither is merged; the owner or lane A merges them by the LANES rules (renumber G241 if another PR took it).

Still open, in order: User Create (needs owner decisions on password policy and delete), Balance TrFr (waits on Year Create design), Esc on the nine wrapper-handler screens (GB-02, a shared hook belongs in lane A's `lib/`), the RP_ALL report engine (blocks Sales Report, Purchase Rpt, Order Report), Cash Bank report, HuId Report. Other voucher forms that fill a "next number" when their list read answers may have the same race as Tag Cancel; each needs a held-response case.

Not done: the DB suite (no API or core file changed), desktop-runtime comparison (no Windows runtime), Docker failure/recovery scenarios, mobile layouts, role matrices beyond the existing modules.

## Session of 9 Nov 2026 (Claude Code, worktree `~/dc-wt/master-plan`), about 02:30 IST

| Item | Result | Evidence |
|---|---|---|
| Risk 1 (Approval branch on no remote) | Resolved as a backup: pushed, not merged | `origin/backup/lite-approval-2026-11-09` at `a9f68b85` |
| Risk 4 (stale Order Cancel claim) | Uncommitted work saved without touching the worktree; the claim is released to the plan (OD-8) | `~/dc-backups/order-cancel-uncommitted-2026-11-09.patch`, `~/dc-backups/order-cancel-untracked-2026-11-09.tgz` |
| Risk 3 (disk) | Disk was at 100% (2.7 GiB free). Removed eight clean, merged worktrees (`base impl live main-ci main n49 pr2 pr3`) | 11.6 GiB free. `slot-1` still holds a stale lock from session `52f05ab4` (2 Nov) |
| Master plan | `docs/parity/LITE-MASTER-PLAN.md`: one ordered work order (WP-00 to WP-56), adopted owner defaults OD-1 to OD-8, the slice runbook, Track O (desktop oracle on the .NET Framework runner) and Track P (go-live gates) | this PR |
| New finding | No voucher writer has server-side replay protection; the cash-bank double-click case passes through the disabled button only. Planned as WP-04 (P0) | `LITE-MASTER-PLAN.md` WP-04 |
