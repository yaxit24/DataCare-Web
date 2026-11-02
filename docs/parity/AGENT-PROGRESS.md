# Agent progress and claims

Shared coordination file for parallel Kiro sessions on the Lite parity goal. Last updated: 2 November 2026, about 16:50 IST, by session `52f05ab4`
(lane "C", worktree `~/dc-wt/parity-coord`). It complements, and does not replace, `~/dc-wt/LANES.md` (the live board on the shared laptop),
`python3 docs/tools/session_status.py` and the backlogs. Status lives in `docs/master-parity-plan-2026-09-29/execution-backlog.json`.

Edit this file only in a pull request, never in a shared working tree. If two PRs edit the same row, the one that merges second merges `main` and keeps both rows.

## Claims (who holds what right now)

| Claim | Holder | Branch / PR | Files claimed | State | Since |
|---|---|---|---|---|---|
| Tag Print Esc with no focused control (G239, on N225) | session `52f05ab4` | `agent/parity-tag-print-escape` / PR #218 | `web/apps/web/app/(app)/txn/tag-print/page.tsx`, `web/apps/web/test/features/modules/tagPrint.mjs` | open; static-gates passed, quality and real-stack pending at last look | 2 Nov 15:25 |
| This coordination set (`docs/parity/*`) | session `52f05ab4` | `agent/parity-coordination` / PR #220 | new files only, plus two rules in `docs/handbook/doc-register.json` | open | 2 Nov 16:30 |
| Order Cancel | not this session; `~/dc-wt/order-cancel` | `feat/order-cancel`, nothing pushed | `modules/sales/orderCancel.ts`, `test/orderCancel.db.test.ts`, edits to `salesOrder.ts` | **stale suspect**: uncommitted for about 16 h | 1 Nov 23:00 |
| GST CSV negative amounts | `ysmtb` identity | PR #217 | GST report CSV | open | 2 Nov |

No other Lite menu has an open PR or a pushed branch with unmerged work (checked against `gh pr list` and `git branch -r` at 16:40).

## Do not touch (other sessions' work)

- `~/dc-wt/order-cancel`, `~/dc-wt/lite-approval`, `~/dc-wt/wh-sales`, `~/dc-wt/kiro-impl`, `~/dc-wt/feature-e2e` and every `~/dc-review/*` checkout.
- `~/DataCare-Web` itself (it sits on `feat/sale-return-numeric-write-x13`).
- The stash list is shared across worktrees: `stash@{0}` belongs to `feat/lite-fine-jv-feature`. Leave it.

## Risks for the owner

1. **`feat/lite-approval` has 31 commits that exist on no remote branch.** Approval Isu and Approval Rtn exist only on this laptop. Push the branch, or back it up, before any worktree cleanup. `~/dc-wt` is 73 GB and the disk is at 97%, so cleanup is likely.
2. **Disk and memory.** The data volume had 11 GiB free at 98% at 16:00; swap was 6.7 of 8 GiB. Do not run more than one browser stack at a time unless you took a slot; clean finished worktrees whose PR merged.
3. **Order Cancel claim looks abandoned** (see the table). Someone should push its partial work or release the claim.

## Done this session

| Item | Result | Evidence |
|---|---|---|
| Repository reconnaissance | desktop is source only; binaries, `.rpt` and the SQL Server backup are Git LFS pointers; 1,069 keyframes and 254 report XML specs exist | `TEST-EVIDENCE.md` §1 |
| Found why `main` was red | `tag-print.keyboard.desktop-keys`, a lost Esc when no control has the focus | `GAP-BACKLOG.md` GB-01 |
| Fix + deterministic case, PR #218 | red before, green after; tag-print 18/18; full feature suite 539 passed, 3 baselined failures, 91 blocked, 0 untested | `TEST-EVIDENCE.md` §2-§4 |
| Static gates on the pushed code | 20 commands, all exit 0 | `TEST-EVIDENCE.md` §5 |
| Matrix and backlog | 49 Lite menus classified; 0 VERIFIED PARITY | `FEATURE-MATRIX.md`, `GAP-BACKLOG.md` |
| Found a stale spec | Year Create's prompt and catalog row overstate the work | `GAP-BACKLOG.md` GB-07 |

## Not done, and why

- No second implementation task was finished. The next candidates were studied, not built (see "Exact next tasks").
- Desktop-runtime comparison: impossible here (no Windows, no binaries).
- API and core packages: untouched, so the 3,789-test DB suite was not run for #218. CI runs it.
- Docker failure and recovery scenarios, restart persistence, mobile layouts, role matrices beyond what the existing modules cover: not executed.

## Checkpoint (to resume without repeating discovery)

- Repository `~/DataCare-Web`, GitHub `yaxit24/DataCare-Web`. Working worktree `~/dc-wt/parity-coord`. `main` was `a25994c6` at 16:40.
- Branch `agent/parity-tag-print-escape`, head `b8bf5185`, PR #218 (open, mergeable). Commits: `18e68380` (the change), then three merges of `main`.
- Branch `agent/parity-coordination` carries this file set (PR #220).
- Build: Node 24.22.2 from `~/.nvm/versions/node/v24.22.2/bin`, `pnpm install --frozen-lockfile`, then build in this order: `@datacare/db` (generate, then build), `types`, `core`, `api`, then `web` with `API_ORIGIN=http://127.0.0.1:<API port>`. Slot 1 ports: DB 55501, API 4611, web 4612, project `dc-parity-coord`. Release the slot (`rmdir ~/.cache/datacare-stack-slots/slot-N`) after every run.
- A full feature run takes about 8 minutes once built; the web build is 2-3 minutes with a warm Turbo cache.
- Re-run `python3 docs/parity/build_matrix.py` after any change to the catalog, the progress page, `run-snapshot.json` or `ownership.json`.

## Exact next independent tasks (in order)

1. **Watch PR #218 to green.** If real-stack fails, read `gh run view --job <id> --log-failed` and compare with `TEST-EVIDENCE.md` §3 before assuming a flake. Do not merge it.
2. **User Create (`MS_USER`, 5,312 lines).** Unowned, security-relevant, 15 of 18 cases still `.pending` in `users`. Start with the desktop study of `MS_USER.cs` and write the pending cases first; the handoff note names it as the next step.
3. **Land `feat/lite-approval`** (GB-03) if its owner does not: it needs the owner's consent because it is another session's branch.
4. **Cash Bank report (`RP_CASH_BANK`)** or **HuId Report (`RP_HUID`)**, whichever is still unowned; each in its own route directory, never in `reports/[report]/page.tsx` (at its size ceiling).
5. **Esc on the nine other wrapper-handler screens** (GB-02): one case per screen first.
6. **Correct the four cash-bank catalog rows** (GB-05) when that module is next touched.
