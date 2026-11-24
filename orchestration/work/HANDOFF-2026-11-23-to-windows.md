# Handoff 2026-11-23 (night): Mac session → Windows machine

Written at the end of a long Mac session so another machine (Windows, with OpenCode, Codex, later Kiro) can continue
without the Mac's chat context. Read this first, then `orchestration/work/ROADMAP-2026-11-23.md` and
`orchestration/work/QUEUE.md`.

## 1. Owner priorities (standing, from the owner)

1. **The web works end-to-end exactly like the desktop Lite edition**: same menus, screens, field order, keys,
   message texts, calculations, prints. Familiarity for jewellers comes first.
2. Security findings (`orchestration/work/WP-51/security-review.md`) are **deferred** unless they break normal use.
   F-04 (login rate limit shared by everyone behind the proxy) is the only one queued early.
3. Bulk work runs on cheap models (OpenCode Go/free Zen models, Codex). Claude does planning, hard fixes and the
   **independent review of every money/stock PR before merge**. Those reviews found real bugs on #241, #243, #246,
   #248, #262 and #269 that the authors' own tests missed.
4. The owner has authorised merging good PRs ourselves after green CI plus an independent review. Never push to
   main, never force-push.

## 2. State of the repo tonight

Merged to main on 2026-11-23 (17 PRs). These include #244 Tag Stock, #245 GST, #246 Books, #247 Stock Report,
#248 Sales Return, #250 Sales Invoice, #251 Purchase Rtn, #252 Contra, #253 cheap-model routing, #255 Purchase,
#261 voucher-number holes (WP-10), #262 Sales Order "+" SL_ORD_ADJ advance row, #263 masters residuals (WP-36) and
#268 Lite sidebar = exactly the 49 desktop Lite menus (WP-55).

**Update 2026-11-24 (Mac, 14:00):** the queue also merged #254 Data Refresh, #256 Wh Sales, #257 Tag Print,
#259 Purchase Rpt (its 17 baseline failures removed), #258 Daily Rate, #264 Order Report, #265 Sales Report and
#266 Approval Rpt. #264/#265 also point the Lite Report menus "Order Report" and "Sales Report" at the RP_ALL
screens (`web/apps/web/lib/liteMenus.ts`). #269 was last in the queue (re-running a flaky Users case); check
`gh pr view 269` before anything else.

Still open:

| PR | Branch | What | State |
|---|---|---|---|
| #269 | agent/wp03-ratecut-advance | Rate-cut order advance is metal, not money | reviewed (fix 72b221b3); merge if green |
| #267 | agent/wp20-ledger-residuals | Ledger fine prints + Lite ageing (N255) | **blocked on owner**: needs a `Browser-Test-Exempt:` line (text in the PR conversation) or real cases in companyMaster/dataBackup/gstReport |
| #260 | agent/specs-batch-2026-11-23 | This plan, packets, studies, tooling | docs only; queued after #269 |

Follow-ups found while merging (not yet fixed):

- `rpAll/index.ts` `shapeOrderResult` on main runs the `variant.bandFormulas` block twice (a merge duplicate).
  Harmless only if the formulas never read their own output; delete one copy and add a test.
- `wholesale-sale.create.loose-item-detail-rows` fails intermittently on CI (3 times on 24 Nov, green on re-run);
  `users.password-rule.d34` timed out once. Make them deterministic.

Next free plan ids after the open PRs: **N256, G268**. Always re-check `gh pr list --json title` first.

Branches with work in progress (no PR yet):

- `agent/wp32-tag-opening-residuals`: study, cases (Claude-reviewed), tests by a free model (check its run).
- `agent/wp35-blocked-residuals`: study, cases (Claude-reviewed), tests by a free model (check its run).
- `agent/wp41-f2-tax-hsn`: WP-41 family 2 study (`orchestration/work/WP-41/family2-study.md`).
- `agent/wp07-company`: WIP from 22 Nov (Company, WP-07). `agent/wp09-esc-no-focus`: WP-09, old.
- `agent/wp51-security-high` is empty (security parked).

## 3. Owner questions open (answers unblock many of the 186 blocked cases)

1. #267: allow `Browser-Test-Exempt` lines? (#264, #265, #261, #262, #263 already carry them.)
2. #269: rate-cut order postings. The desktop posts day-book 07 / ledger key 11 against account 00008, one-sided.
   Post exactly / balanced equivalent / keep today's balanced entries (current)?
3. Order Report, Making Panding/Summ: the desktop hides fully adjusted orders only for registration HM310NEPK
   (RP_ALL.cs:10925). The web follows the general behaviour. Keep?
4. Approval Rpt: which setting supplies the A/B MsDataType (D3)? Where does MsAllBranchAcShow live?
5. Masters (#263): export the desktop's 35 account-group rows (AC_GROUP) from a restored database; web layouts for
   the 5 missing master prints; Employee F1 create-account as modal or page; Group Save stricter than the desktop?
6. Tag Print: does the item-detail amount print "1,235" or "1235"? Daily Rate: clear the screen after save as the
   desktop does (logged as a follow-up)?
7. WP-25/WP-53 cutover: a sanitised real desktop backup (.BAK) and a Lite Soft `.mdb` for the dry run; the 13
   questions in `orchestration/work/WP-53/cutover-design.md` §8 and the 8 in WP-25's study.
8. WP-05 T06 card/UPI settlement on Cash/Bank (TR_CASH has no such mode); OD-7 label printers.

## 4. What to run next (order)

1. Let the merge queue finish (section 6). Fix stops by hand with the rules there.
2. `orchestration/work/QUEUE.md`: the planner's 31 packets.
   - Done or in flight: WP-11.browser (done), WP-20.tests and WP-20.implement (done and in #267), WP-55 (merged
     #268), WP-41.f2.study (done).
   - Next: WP-35.tests → WP-35.implement → WP-35.browser; WP-32.tests → implement → implement-print → browser → ui;
     WP-51.f04; WP-04 idempotency batches A and B.
   - Every money/stock implement step gets a Claude review packet (`*.verify`) before the PR.
3. New packets to write (planner left them): WP-10 follow-ups (customer-entry lock, Tag Split late-list race,
   unique keys plus 409 on header tables after a duplicate scan), WP-25 Data Import (Lite Soft `.mdb` extractor on
   the WP-53 pipeline), WP-53 cutover slices S1-S11, WP-36 leftovers (needs the AC_GROUP rows).
4. Backlog bugs found today: `orderDoc.ts:151` subtracts old gold and scheme twice from the balance due; the order
   header `OLD_GL` leaves out `RCUT_FINE` (TR_SALE_ORD.cs:9143); the RATE_CUT family has no version token;
   tag-adjust DELETE has no version token.

## 5. Windows machine setup

Install:

- Git for Windows, including Git Bash. The queue scripts are bash; run them in Git Bash or WSL2.
- Docker Desktop with the WSL2 backend. Every DB/browser test starts a throwaway Postgres through
  `web/scripts/parity-test-env.mjs`. Give Docker 6-8 GB RAM.
- Node 24 (nvm-windows: `nvm install 24.22.2`), then `corepack enable` (pnpm comes from `web/package.json`).
- Python 3.12+ (`python` must run `docs/tools/*.py`, `docs/parity/build_matrix.py`,
  `docs/master-parity-plan-2026-09-29/validate_plan.py`).
- GitHub CLI `gh`, then `gh auth login`.
- OpenCode: `npm i -g opencode-ai`, then `opencode auth login -p opencode-go` (Go plan). The free Zen models need no
  key: `opencode/qwen4-max-free`, `opencode/deepseek-v4.1-flash-free`, `opencode/hy4-flash-free`.
- Codex CLI (`npm i -g @openai/codex`, ChatGPT sign-in). Use model `gpt-6-astra`; the global default `gpt-6.1-sol`
  is rejected on a ChatGPT sign-in.
- Kiro: optional, later. Add a runner entry in `orchestration/config/runners.json` modelled on the opencode one.

Repository and worktrees:

```bash
git clone https://github.com/yaxit24/DataCare-Web.git && cd DataCare-Web
git worktree add ../dc-wt/orch agent/specs-batch-2026-11-23   # dispatcher + packets (until #260 merges)
cd web && pnpm install --frozen-lockfile                      # once per worktree; about 100 MB with the pnpm store
```

Dispatcher environment (Git Bash):

```bash
export DATACARE_WT_ROOT=~/dc-wt/orchwt DATACARE_STATE_ROOT=~/dc-wt/orch-state
node orchestration/bin/orch.mjs providers        # shows which runners/models are usable
node orchestration/bin/orch.mjs check orchestration/packets/<P>.md
node orchestration/bin/orch.mjs run orchestration/packets/<P>.md --runner codex --model gpt-6-astra --attempts 2 --commit --accept-partial
```

`orchestration/tools/merge-queue/par.sh <packet> <runner> <model> <worktree-dir>` runs one packet and pushes the
branch. Start several in parallel on different models; free models tolerate about 3 at once.

Secrets: provider keys live outside git, in `$DATACARE_STATE_ROOT/providers.env` (OpenRouter key). Recreate them by
hand on Windows and never commit them. `limits.json` in the state dir records which model is rate-limited until
when; delete an entry to retry it.

Lessons from today:

- Make sure `opencode` is on PATH for the dispatcher, or it silently falls back to Claude.
- Codex's sandbox has **no Docker**. Packets whose gate runs browser tests fail inside Codex. Let the dispatcher
  run the gate, or have a Claude/local session finish the screen-and-browser loop (WP-14 and WP-11 were finished
  that way).
- Free models stall sometimes (no log growth for 30+ minutes): kill the run and reassign.
- Only one local Docker test stack at a time on small machines. The Mac used a lock:
  `until mkdir /tmp/dc-stack.lock 2>/dev/null; do sleep 20; done … rmdir /tmp/dc-stack.lock`. GitHub CI is the
  free full run.
- `.next` build folders are large; delete them after a run.

## 6. Merge queue (only ONE machine runs it at a time)

`orchestration/tools/merge-queue/merge-queue2.sh PR:worktree …` brings each branch up to date with main, resolves
the recurring conflicts by rule, regenerates the generated docs, pushes, waits for CI and squash-merges only when
every check passes. It stops at the first thing it cannot decide.

Rules it applies, scripts in the same folder:

- `resolve-code.py`: route total in `routePolicy.test.ts` (main's total + this branch's delta); migration manifest
  (main's entries, then ours).
- `resolve-sections.py`: lineage doc 12 sections. `resolve-reqindex.py`: requirement-index.json rebaseline chains.
- `resolve-catalog.py`: menu-catalog rows (per row, the side that changed it). `resolve-budget.py`: size budget
  (shrink-only, take the lower ceiling).
- `orchestration/tools/resolve-records.mjs`: the rest of the record files.

By hand: code conflicts in `app.ts`, `routePolicy.ts`, `txn.ts`, `run-features.mjs`, `coverage-map.json` are almost
always "keep both sides" (main's first). Migration timestamp collisions: rename ours to a later timestamp.

The scripts have Mac paths (`~/dc-wt/...`, `~/.nvm/...`). Adjust PATH and paths at the top for Windows.

A PR without plan ids (tooling, fixes) still loses the race against the queue on `doc-register.md`. Put it into the
queue instead of merging it on the side. Regenerate `doc-register.md` from a clean checkout: untracked local files
change it, and CI then reports it stale.

CI baseline failure to ignore: `company-master.fields.complete-round-trip`. Occasional flakes: Chrome screenshot
capture, `companyMasterContainment.db.test.ts`, `wholesale-sale.create.loose-item-detail-rows`,
`users.password-rule.d34`. Re-run the failed job once (`gh run rerun <id> --failed`).

## 7. What is still running on the Mac (stop it before starting the queue on Windows)

- Merge queue (last: #269 then #260). Check `gh pr list`; anything merged is done.
- `codex-night.sh` and the free-model WP-32/WP-35 test runs have ended (Codex limit / timeouts); nothing of theirs
  is pending. Re-run those packets from section 4.

If the Mac is shut down, these stop. Nothing is lost: all completed work is pushed. Restart from section 4.

## 8. Progress measure (main, CI run 45200201179)

49 of 49 Lite menus have a web screen. Browser cases: 853 of 1,057 applicable pass (81%), 186 blocked, 18 failing
(17 fixed by #259). No menu is FULL yet (FULL needs every case proven plus owner UAT). Production track
(WP-50..56: release certification, ops/backups, cutover, UAT): designed, mostly not built.
