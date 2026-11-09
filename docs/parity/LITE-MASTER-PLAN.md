# Lite edition master plan: from today to a production SaaS (9 November 2026)

This is the **single ordered work order** for finishing the Lite edition of the web rebuild of the DataCareNext jewellery
ERP and running it for real jewellery shops. It is written so that a model with no memory of earlier sessions can pick
the next item, do it, prove it and land it without guessing.

It does **not** replace the documents it points to. Where a rule already exists it is cited, not retyped:

| Need | Read |
|---|---|
| How to take one menu to done (study, gaps, API, web, tests, visual pass, records, PR) | `docs/agent-prompts/lite/00-GENERIC.md` (+ `00b-REPORT-ADDENDUM.md` for reports) |
| The menu-specific facts for 22 menus | `docs/agent-prompts/lite/NN-*.md` (launch bundles in `launch/`) |
| Commands, traps already met, merge order rules | `docs/handbook/web/handoff-lite-parity.md` §8 and §9 |
| Status (the only authority) | `docs/master-parity-plan-2026-09-29/execution-backlog.json`, `docs/handbook/menu-catalog.jsonl` |
| Gap register (`G###`) | `docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md` §3 |
| The 49 Lite menus with evidence | `docs/parity/FEATURE-MATRIX.md` (generated) |
| Claims (who holds what) | `docs/parity/AGENT-PROGRESS.md` |

If this plan and one of those documents disagree on **process**, the document wins and this plan must be corrected in a
PR. If they disagree on **order or scope**, this plan wins (it is newer), except that the desktop source
(`unified/src/csharp/DataCareNext/*.cs`) always wins on business behaviour.

---

## 0. Read this first (the implementing model's contract)

### 0.1 The ten rules you must not break

1. **The desktop source is the authority.** Every rule you implement cites `FORM.cs:line`. Expected test values come
   from the desktop rule, never from what the web currently prints.
2. **One work package (WP) at a time, one branch, one worktree, one PR.** Never edit `~/DataCare-Web` itself or another
   session's worktree.
3. **Never push to `main`.** Never force-push, never `git reset --hard`, never `git clean -f`, never `--no-verify`, never
   amend a pushed commit. Stage files by name (no `git add .`, no `git add -u` after a conflicted merge).
4. **Never weaken a test to make it pass.** A failing case is a finding: baseline it with a gap id, fix it, remove the
   baseline entry in the same change.
5. **Never invent.** If a template, a decision or a fact is missing, write "missing" and stop or mark the case blocked
   with the reason **before** running it.
6. **Never port a desktop weakness** (string-built SQL, plaintext passwords, unscoped deletes, partial writes, hidden
   backdoors). Reproduce the business result, the message texts and the keyboard flow.
7. **Tests run only on the isolated database** from `web/scripts/parity-test-env.mjs`. Never on real customer data.
   Never print customer names, phones or addresses from a desktop database; aggregate queries only.
8. **Take `N###` / `G###` ids last**, after merging a fresh `origin/main`, as max + 1. Ids must be contiguous.
9. **Quote real gate output** in the PR. "Should pass" is not evidence.
10. **Stop and ask** (end your turn with one clear question) only at the triggers listed in each WP card and in §3.
    Everywhere else, decide with the defaults in this plan and keep going.

### 0.2 The loop (repeat until §1 "Lite is done" holds)

```
1. git -C ~/DataCare-Web fetch origin --prune
2. Read docs/parity/AGENT-PROGRESS.md (claims) and run: python3 docs/tools/session_status.py
3. Pick the next WP: the lowest phase number in §5 whose "Depends" are merged and which nobody has claimed.
   Inside a phase take P0 before P1 before P2. Ties: the smaller size first.
4. Claim it: add a row to AGENT-PROGRESS.md in your branch's first commit.
5. Run the slice runbook (§4) for that WP.
6. Open the PR, wait for green CI, merge by the merge protocol (§4 step S11).
7. Tick the WP in §5 ("State" column) in the same PR or the next docs PR. Go to 1.
```

Never start a second WP while your PR is red. Fix it first.

---

## 1. What "done" means: three levels

| Level | Name | Per menu | Who can set it |
|---|---|---|---|
| L1 | **Web-complete** | Catalog row `FULL`: every desktop mode the Lite operator sees, its lifecycle (create, reopen, edit, delete), its print, its rights; its feature module has **no failing, blocked or baselined case**; its writers have write-set DB tests | Coordinator merges the PR that flips the row; implementing agents propose it in the PR body |
| L2 | **Desktop-verified** | L1 plus every money, weight, fine, tax and rounding formula the menu uses is matched against the desktop's own code on .NET Framework 4.8 (Track O, §6) | Automatic once its golden-vector suite is green |
| L3 | **Production-ready** | L2 for all 49 menus plus the go-live gates of Track P (§7) | Owner sign-off after UAT |

**Lite is done** when all 49 Lite menus are L1, every formula family in §6 is L2, and every gate in §7 is green.
The progress numbers to report are always three, never averaged: *executed coverage*, *browser pass coverage*,
*desktop-match coverage*.

---

## 2. Verified state on 9 November 2026

Read from the repository and GitHub at about 02:30 IST, not copied from older notes.

| Fact | Value |
|---|---|
| `origin/main` | `0f1e6006` (4 Nov, #223); 472 commits |
| Highest ids on `main` | `N228`, `G241`; next free `N229`, `G242` (re-check before taking) |
| Open PRs | #226 `agent/parity-sales-rollback` (T14 rollback matrices for Sales, Sales Order, Sales Return, Purchase Return; G173, part of N166) |
| Lite matrix (2 Nov run) | 49 menus: 0 VERIFIED, 32 PARTIAL, 4 BROKEN, 1 BLOCKED, 12 NOT YET VERIFIED (no browser module) |
| BROKEN rows | Company (G38 T02), Data Backup (G64/N80), Sales Order + Order Report (one case, G206) |
| Baselined failing cases | `company-master.fields.complete-round-trip` (G38), `sales-order.create.scheme-tender` (G206), `data-backup.config.nextmain-allowlist` (G64/N80), two in `data-refresh` (G225, X27/P11-01) |
| Last full feature run | 539 passed, 3 baselined failures, 91 blocked, 0 untested (2 Nov) |
| Desktop runtime | No Windows here. **But** `.github/workflows/dotnet-fx-probe.yml` compiles C# with the .NET Framework 4.8 `csc` on `windows-latest` and has run green (#225). This is the base of Track O |
| Production infrastructure already in the repo | `web/deploy/docker-compose.prod.yml`, `web/deploy/backup.sh`, `web/DEPLOY.md`, `web/apps/api/Dockerfile`, `release:certify`, `restore-drill`, `load:profile`, `project-memory/parity/DR-RUNBOOK.md`, `CUTOVER-RUNBOOK.md`, `UAT-PLAN.md`, `LOAD-PROFILE.md` |

### 2.1 Actions taken today (before this plan)

| Risk | Action | Where it is now |
|---|---|---|
| Approval Isu/Rtn (31 commits, two Lite menus) existed only on this laptop | Pushed as a backup branch, not merged | `origin/backup/lite-approval-2026-11-09` (tip `a9f68b85`); a bundle also exists at `~/dc-backups/feat-lite-approval-a9f68b85.bundle` |
| Gap-analysis branch unpushed | Pushed | `origin/agent/parity-gap-analysis-2026-11-02` |
| Order Cancel uncommitted work (about a week old, session gone) | Saved without touching the worktree | `~/dc-backups/order-cancel-uncommitted-2026-11-09.patch` (edit to `salesOrder.ts`), `~/dc-backups/order-cancel-untracked-2026-11-09.tgz` (`orderCancel.ts`, `orderCancel.db.test.ts`) |
| Disk at 100% (2.7 GiB free) stops Docker and every browser run | Removed eight clean, fully merged worktrees (`base impl live main-ci main n49 pr2 pr3`; all commits on GitHub, re-creatable with `git worktree add`) | 11.6 GiB free |
| Stale stack slot | `~/.cache/datacare-stack-slots/slot-1` is still held by session `52f05ab4` from 2 Nov (no process alive). Not removed (needs the owner's OK) | Use slot 2 or 3; see §4 S4 |

---

## 3. Owner decisions

On 9 November 2026 the owner delegated the open decisions to the implementer with one rule: **implement the desktop
first**. The operator sees and does what the desktop does; the web adds only what an internet-hosted service needs to
be safe. OD-1 to OD-5 are recorded as accepted decisions **D34-D38** in document 12 §4, which is the authority; this
table is a summary. Agents cite the D id in the PR body.

| ID | Question (source) | Decision | Why |
|---|---|---|---|
| OD-1 → D34 | User password rule (GB-10 q1) | Desktop flow and texts verbatim; Argon2id; **minimum 8 characters, no composition rules**, deny-list of common passwords and of the login name and company code; login throttle plus per-account back-off | Operators keep a desktop-like experience; length plus deny-list and throttling protect an internet login better than composition rules (NIST SP 800-63B) |
| OD-2 → D35 | User delete (GB-10 q2) | Desktop flow, texts and result; implemented as deactivation with every session revoked at once; last admin protected | Same operator result; vouchers and audit keep the user code |
| OD-3 → D36 | Lite rights grid (GB-10 q3) | Hidden in the Lite edition, all rights seeded `Y`, as the desktop does | Edition parity |
| OD-4 → D37 | Backup content (D-BKP-3) | Complete restorable company copy **including Argon2id password hashes**; excluded: sessions, tokens, idempotency receipts, integration secrets (listed in the manifest) | A restored company must log in as the desktop's does; hashes are slow to crack, live integration keys are not |
| OD-5 → D38 | Company delete | Desktop action, rights and texts; soft delete at once, purge after 30 days, recovery by the platform operator only | Operator result of the desktop without an irreversible cascade in a hosted system |
| OD-6 | Data Import needs a Lite Soft `.mdb` sample | **Build against a synthetic `.mdb`** generated by a script in the repo (schema from `UT_IMPORT.cs`), keep the case on a real file **blocked** until the owner supplies a sanitized one | Unblocks the build without faking evidence |
| OD-7 | Physical label printers (D29) | Unchanged: device fakes for engineering tests, physical acceptance pending | Needs hardware |
| OD-8 | Order Cancel and Approval branches belong to sessions that have been silent for a week | **Adopt them**: the next agent takes them from the backups in §2.1 | They are abandoned; the work is valuable |

Real stop-and-ask points that remain: anything that needs **customer data**, lifting a containment rule
(`web/packages/core/containment.mjs`), a physical device, Track O stretch steps O3/O4 (§6), and production
deployment to a real host with real customer data (§7).

---

## 4. The slice runbook (do every step, in order)

Placeholders: `<WP>` is the WP id (for example `wp03`), `<SLUG>` a short name (`so-scheme-tender`), `<SLOT>` 2 or 3.

**S0. Check the machine** (8 GB RAM, 8 cores, small free disk).

```bash
df -h /System/Volumes/Data | tail -1        # need >= 8 GiB free before building
docker info >/dev/null 2>&1 && echo docker-ok || open -a Docker   # wait until docker info succeeds
ls ~/.cache/datacare-stack-slots/            # see S4
```

If free disk < 8 GiB: remove your own finished worktrees (`git worktree remove ~/dc-wt/<old>` refuses dirty trees, which
is what you want), then `rm -rf <your-worktree>/web/apps/web/.next` of finished ones. Never delete another session's
worktree, never `docker system prune` without the owner.

**S1. Worktree and branch.**

```bash
cd ~/DataCare-Web && git fetch origin --prune
git worktree add ~/dc-wt/<SLUG> -b agent/<WP>-<SLUG> origin/main
cd ~/dc-wt/<SLUG>/web && pnpm install --frozen-lockfile
export PATH="$HOME/.nvm/versions/node/v24.22.2/bin:$PATH"   # the supported runtime (pnpm runtime:check)
```

**S2. Claim.** Add a row to `docs/parity/AGENT-PROGRESS.md` (claim, branch, files, "started"), commit it alone:
`docs(parity): claim <WP> <menu>`.

**S3. Study (no code yet).** Follow `00-GENERIC.md` step 1. Output a notes file **outside the repo**
(`~/dc-wt/notes/<WP>.md`) with: every button, key, box, grid column, message text and table write of the desktop form,
each with `FORM.cs:line`. Also list the current web files (page, API module, route, tests, feature module) and what they
do. The WP card's "Desktop" and "Web now" rows are your starting points, not the whole truth.

**S4. Gap list and case list (still no code).** Write the frozen case list T01-T18 for the module
(`docs/master-parity-plan-2026-09-29/04-verification-playbook.md` §3). For each case: id, kind, expected value **derived
from the desktop rule** with the citation. Mark a case blocked/N-A only here, with the reason. Then take a stack slot
only when you are about to build or run a browser:

```bash
mkdir ~/.cache/datacare-stack-slots/slot-<SLOT> && echo "owner=<WP> since=$(date '+%F %T')" > ~/.cache/datacare-stack-slots/slot-<SLOT>/owner
# slot 2: DB 55502, API 4621, web 4622 ; slot 3: DB 55503, API 4631, web 4632
```

`mkdir` fails if the slot is taken: then use the other slot or wait. Never take more than one slot.

**S5. Red first.** Write the unit tests, the DB test (real Fastify routes via `app.inject`, forced RLS, scoped by
`tenant_id`) and the browser cases **before** the fix, run them, and see the new ones fail on the current code. Save the
failing output (you will quote it).

```bash
# from web/
PARITY_TEST_PORT=5550<SLOT> RUN_DB_INTEGRITY_TESTS=1 node scripts/parity-test-env.mjs -- \
  pnpm --filter @datacare/api exec vitest run test/<file>.db.test.ts
```

**S6. Implement.** Rules (from `00-GENERIC.md` §3 and the handoff §2, repeated because they are the most often missed):

- Logic in `web/apps/api/src/modules/<area>/<name>.ts`; routes in their **own** file under `web/apps/api/src/routes/`,
  registered with one line (`masterScreens.ts` for masters, beside `txn.ts` otherwise). Literal route paths only.
- `txn.ts` (8,360 lines), `reports/[report]/page.tsx` (1,742) and `modules/sales/salesOrder.ts` are at their size
  ceilings: **do not grow them**. 1,500 lines per new file.
- DB work inside `withTxBudget(prisma, tenantId, 'read'|'voucher', ...)`; `*ValidationError` → 400,
  `*VersionConflictError` → 409; a version token on every editable record; idempotent writes (a replayed request
  must not make a second voucher; use the WP-04 mechanism once it exists).
- No account-code literals: resolve accounts from `BOOK_DETL` slots. Parameterised SQL only.
- Rounding: only `round` / `roundHalfEven` from `@datacare/core`; no new `Math.round` helper.
- Desktop message texts verbatim, spelling included.
- Rights by menu caption (`web/apps/api/src/modules/rbac/formCatalog.ts`), a route policy for every new route; new pages classified in
  `docs/handbook/web-route-editions.json` (`node scripts/generate-edition-table.mjs`).
- Web: match the form spec's layout, tab order and keys (Enter walks editable cells, F1 help, Ctrl+D delete row,
  Alt+S save, Esc close even with no focused control). Save is the only `button.primary`. Lookups reuse
  `lib/lookupEnter.ts`.
- Print: reproduce the named Crystal template's regions, field order, captions and grid columns (decision D20). Check
  that a template is really missing (`git ls-files | grep -i <name>`, `extraction_output/rpt_xml/`) before saying so.
- A migration needs its sha256 in `web/apps/api/src/modules/ops/migrationManifest.ts` and in the Prisma model.

**S7. Green.** Re-run the S5 tests until green. Then the module's whole browser feature run:

```bash
PARITY_TEST_PORT=5550<SLOT> PARITY_API_PORT=46<SLOT>1 PARITY_WEB_PORT=46<SLOT>2 FEATURE_E2E_MODULES=<module> \
  node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
cat test-results/feature-e2e/<module>/run.json | python3 -m json.tool | head -80
```

Build before any browser run after a branch switch or a merge (`API_ORIGIN=http://127.0.0.1:46<SLOT>1 pnpm build`):
a stale `.next` once served old pages (N186).

**S8. Visual and keyboard pass.** Per `00-GENERIC.md` step 5: open the screen from the navigation at 1366x768, snapshot
it, walk the keyboard flow, read console and network, print preview. Write a short summary for the PR. Then **release
the slot**: `rm ~/.cache/datacare-stack-slots/slot-<SLOT>/owner && rmdir ~/.cache/datacare-stack-slots/slot-<SLOT>`.

**S9. Records** (only now take ids).

```bash
git fetch origin && git merge origin/main          # resolve; then check for leftover markers:
git status --short | grep -E '^(UU|AA)' ; git grep -n -E '^(<<<<<<< |>>>>>>> )' -- . ':!*.rpt'
grep -oE '"N[0-9]{3}"' docs/master-parity-plan-2026-09-29/execution-backlog.json | sort -u | tail -1
grep -oE '^\| G[0-9]{3} ' docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md | sort -u | tail -1
for n in $(gh pr list --state open --json number --jq '.[].number'); do gh pr diff $n | grep -E '^\+(\| G[0-9]{3} \||### N[0-9]{3})'; done
```

Take max + 1 for each, not used by an open PR. Update: the catalog row (`menu-catalog.jsonl`), doc 12 gap rows, the
backlog slice, `coverage-map.json`, `baseline.json` (only shrinks), the handbook page if behaviour changed,
`project-memory/HANDOFF.md` (two dated lines), and this plan's §5 "State" cell. Regenerate, never hand-merge:

```bash
python3 docs/tools/docs_check.py --write            # repo root
(cd web && pnpm progress)
python3 docs/parity/build_matrix.py                 # repo root
```

**S10. Gates.** Run all; paste the last lines of each into the PR body.

```bash
# web/
pnpm lint && pnpm typecheck && pnpm typecheck:tests && pnpm format:check && pnpm size:budget && pnpm depth:parity \
  && pnpm depth:deadcells && pnpm test:routes && pnpm settings:parity && pnpm runtime:check && pnpm docs:refs \
  && pnpm register:check && pnpm progress:check
node scripts/check-kernel-conformance.mjs && node scripts/generate-edition-table.mjs --check
PARITY_TEST_PORT=5550<SLOT> node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test
pnpm --filter @datacare/core test && pnpm --filter @datacare/web test
PR_BODY="$(cat ~/dc-wt/notes/<WP>-pr.md)" node scripts/check-browser-test-coverage.mjs --base origin/main --head HEAD
# repo root
python3 docs/master-parity-plan-2026-09-29/validate_plan.py && python3 docs/tools/docs_check.py
```

On this 8 GB machine the full API suite and the full feature run are slow and can swap. It is acceptable to run the
module-scoped ones locally and let CI run the full real-stack job; say so in the PR body and quote CI's result before
merging.

**S11. PR and merge protocol.**

- Commit messages: `<area>: <what changed> (<N###>, <G###>)`, body = why + desktop citation.
- PR title: `L<n>: <Menu> is the desktop <FORM> screen (<N###>, <G###>)` for a menu; `fix(<area>): ...` for a defect.
- PR body sections (in this order): What the desktop does (cited) · What changed · Cases: executed / passed / failed /
  blocked / N-A with ids · The three coverage numbers · Gate output · Not verified and why · Visual summary · Deliberate
  differences (each with its reason, `OD-n` where used) · Open items.
- `gh pr create --base main --head agent/<WP>-<SLUG> --title ... --body-file ~/dc-wt/notes/<WP>-pr.md`
- Wait for CI (`gh pr checks <n> --watch`). Red: read the failing job's artifact (`gh run download <id>`, open
  `01-failure.png` for browser jobs), fix, push, repeat. Never re-run blindly more than once.
- **Merge** (coordinator, or the agent when the owner has delegated merging, as for this plan): only when every check
  is green **and** the branch contains the newest `origin/main` **and** no other PR with plan ids is mid-merge.
  `gh pr merge <n> --squash --subject "<title> (#<n>)"`. Then the next waiting PR merges `origin/main`, renumbers if
  needed, and waits for green again.

**S12. Clean up.** Slot released, Chrome tab closed, `docker ps` shows nothing of yours, worktree removed after merge
(`git worktree remove ~/dc-wt/<SLUG>`), claim row moved to "done" in `AGENT-PROGRESS.md`.

### 4.1 Concurrency on this machine

At most **three** sessions at once: one holding a stack slot for browser runs, two studying/coding/running DB tests
(a DB-test Postgres container is small). Never two full builds at the same time. Prefer GitHub CI for the full
real-stack run (about 20 minutes) over a local full run.

---

## 5. Work packages

Size: S ≤ 1 day, M 1-3 days, L 3-6 days, XL > 6 days of one agent. "Prompt" = the prompt-pack file to read with
`00-GENERIC.md`. "State" is updated when a WP merges.

### Phase 0: stabilise (before anything else)

| WP | Item | Pri | Size | Depends | State |
|---|---|---|---|---|---|
| WP-00a | Machine hygiene (disk ≥ 8 GiB, Docker up, slots) | P0 | S | — | disk done 9 Nov; Docker not running; slot-1 stale |
| WP-00b | Land or close PR #226 (rollback matrices) | P1 | S | — | open |
| WP-00c | This plan merged | P1 | S | — | this PR |

**WP-00b.** Check out the PR in its own worktree, merge `origin/main`, run the four modules it touches
(`sales-invoice,sales-order,sales-return,purchase-return`), read CI. If green and the ids do not collide: merge. If the
fault-injection cases reveal a real rollback defect: keep the baseline entries it adds, each with its gap id, and
schedule the fix in WP-26/27.

### Phase 1: make the screens that move money and stock safe (BROKEN rows and P0/P1 integrity)

| WP | Menu(s) | Item | Pri | Size | Depends | Prompt | State |
|---|---|---|---|---|---|---|---|
| WP-01 | Approval Isu, Approval Rtn | Land the built branch | P1 | L | — | 12 | PR #228 (N229/G242); 3 cases blocked on WP-04 follow-up and a Sales Apr No import |
| WP-02 | Order Cancel | Finish from the saved patch | P1 | M | — | 11 | patch saved |
| WP-03 | Sales Order, Order Report | Scheme tender (G206), un-break the rows | P1 | M | — | — | PR #232 (N230); owner chose option (a), follow the source; case passes, baseline entry removed |
| WP-04 | Every voucher create route (Stock Adjust first) | Server-side idempotency: a replayed request never makes a second voucher | P0 | M | — | 20 (Stock Adjust part) | PR #229 (6 routes); follow-up queue for the rest |
| WP-05 | Cash Received/Payment, Bank Received/Payment | T03 calculations, T06 card/UPI settlement | P1 | M | — | — | 2 blocked |
| WP-06 | User Create | MS_USER with OD-1..OD-3 | P0 | L | — | — (see card) | 15 of 18 blocked |
| WP-07 | Company | Identity workflow (G38, N58), delete per OD-5 | P1 | L | — | 16 | BROKEN |
| WP-08 | Data Backup | D-BKP-3 allowlist per OD-4 (G64/N80) | P1 | M | — | 18 | BROKEN |
| WP-09 | Party, Item, Item Group, Product, Tax, Address, Employee, Auto Item, Item Opening | Esc with no focused control (GB-02) | P2 | S | — | — | open |
| WP-10 | Every voucher form with a "next number" read | Typed-number race audit (the G241 pattern) | P2 | M | — | — | open |

**WP-01 Approval Isu + Approval Rtn (land).**
- Desktop: `TR_APR_ISU.cs` (8,294 lines); the approval links in `TR_SALE.cs` (search `APR_DETL`, `ISU_REC`).
- Built work: `origin/backup/lite-approval-2026-11-09`, 31 commits (2 feature modules, about 12.6k lines, 2,229 lines of
  lifecycle tests). It used ids `N211/G224`, which `main` has since given to other slices.
- Do: new branch from `origin/main`; `git merge origin/backup/lite-approval-2026-11-09` (a merge keeps the history and
  conflicts appear once). Conflicts expected only in record/registration files: rebuild `coverage-map.json`, doc 12,
  backlog, catalog and `txn.ts` registrations from `main` plus this work (handoff §9). Renumber `N211/G224` to fresh ids
  in every file and test name that cites them (`git grep -n 'N211\|G224'`). Re-run the two approval modules, the
  `sales-invoice` and `approval-report` modules (shared tag flags), and the DB tests under `test/approval*`.
- Done when: both menus have green modules with no blocked case, Tour page replaced, Approval Rpt still green.
- Stop and ask if: more than about 20 files conflict in business code (not records), i.e. `main` changed the same writers.

**WP-02 Order Cancel.**
- Desktop: `TR_SL_ORD_ADJ.cs` (4,169 lines). Prompt 11 has the scope (multi-order adjustment, advance, kasar, refund
  through a chosen cash/bank account, ledger/Rojmel/stock/tag write set, lifecycle, print).
- Start: new worktree from `origin/main`; `tar -xzf ~/dc-backups/order-cancel-untracked-2026-11-09.tgz` in the repo root
  (restores `web/apps/api/src/modules/sales/orderCancel.ts` and its DB test); `git apply --3way
  ~/dc-backups/order-cancel-uncommitted-2026-11-09.patch` (ignore the deleted `.rar` hunk: run
  `git checkout -- "DataCareSetup/DataCareNextS 02-02-2026.rar"` if it applies). `salesOrder.ts` is at its size
  ceiling: move any new code from that patch into `orderCancel.ts`.
- Done when: a browser module `order-cancel` with T01-T18 passes; the Sales Order lifecycle module is still green.

**WP-03 Sales Order scheme tender (G206).**
- Desktop: `TR_SALE_ORD.cs:11264-11290` (typed scheme amount), `:11368` (added to the advance), `Ac_Rojmel.cs:19`
  (day-book row type 05 to account 00079). Baseline reason in `web/apps/web/test/features/baseline.json`: 7 of 76 real
  orders carry a scheme amount but no such day-book row.
- Do: first find **why** those 7 orders have no row: read the condition around `Ac_Rojmel.cs:19` and the order save path
  that calls it (`git grep -n "Ac_Rojmel" unified/src/csharp/DataCareNext/TR_SALE_ORD.cs`). Implement exactly the
  source's condition. Use only aggregate SQL on the desktop data (counts by condition, never names).
- Done when: `sales-order.create.scheme-tender` passes and leaves `baseline.json`; Sales Order and Order Report rows are no
  longer BROKEN.
- Stop and ask if: the source writes the row unconditionally and the real data still lacks it (then source and data
  disagree, which is an owner call).

**WP-04 Server-side idempotency for voucher creates (P0).**
- Finding (9 Nov, by reading the code): no voucher writer under `web/apps/api/src/modules` has a request key or replay
  guard. The cash-bank case `retry.double-click` passes only because the page disables its Save button
  (`web/apps/web/test/features/modules/cashBank.mjs:608`); a replayed HTTP request (a network retry on a shop's
  connection, a proxy retry, a double submit from two tabs) posts a second voucher. The matrix records this for Stock
  Adjust; it holds for every create route.
- Do: (1) a shared mechanism in `web/apps/api/src/modules/shared/idempotency.ts`: the page sends an
  `Idempotency-Key` header (a UUID made when the form opens, renewed after a successful save); the API stores
  `(tenant_id, key, route, request_hash, response_status, response_body, created_at)` in a new table inside the **same
  transaction** as the voucher; a repeat with the same key and hash returns the stored response; the same key with a
  different body answers `409 idempotency-key-reused`. Retention 30 days. This is the accepted decision **D18** and
  slice **N52** (gap G29) in `docs/master-parity-plan-2026-09-29/11-audit-implementation-plan-2026-10-01.md`: reuse
  those ids, take no new ones. In progress: PR #229 (the mechanism; Stock Adjust, Tag Cancel, Cash/Bank Received and
  Payment); the other voucher create routes are its follow-up queue, enforced by `idempotencyRoutePolicy.test.ts`. (2) Apply it to Stock Adjust first (its T13 case
  replays with `page.request.fetch(response.request())`), then to every voucher create route, one module per commit.
  (3) A route-policy test that fails when a voucher create route lacks the guard.
- Done when: a DB test per writer replays the same request and finds one voucher; every voucher module has a T13 replay
  case (not a double-click); the route-policy test is green.

**WP-05 Cash and bank vouchers.** Blocked cases T03 (calculations) and T06 (card and UPI settlement) in module
`cash-bank`. Desktop `TR_CASH.cs` (3,849 lines; it serves cash and bank, received and payment). Turn both into
executed cases with desktop-derived values; fix what they find. The T13 replay cases for these four menus come with
WP-04.

**WP-06 User Create (`MS_USER`, 5,312 lines).**
- Facts: `docs/parity/GAP-BACKLOG.md` GB-10 lists the desktop texts and lines. Web: `/admin/users`, module `users`
  (`usersRights`) with 15 blocked cases.
- Do, with OD-1, OD-2, OD-3: desktop message texts; Confirm Password field checked on leaving the box (`:2205-2220`);
  delete = deactivate with session revocation; the Lite edition hides the rights grid and User Rights button; Print.
  Do **not** port: plaintext `LOGIN_PWD`, F1 revealing the stored password, the hidden `ABC` reset tool.
- Done when: all 18 cases executed and passing; a DB test proves a deactivated user's session is refused on the next
  request.

**WP-07 Company (G38, N58).** Prompt 16. Build the versioned Company writer with first-year provisioning; the desktop
New action and editable identity fields; delete per OD-5 (a new background purge job with its own DB test). Coordinate
with WP-22 on `ops/seedCompany.ts` (whoever merges first extracts the shared copy). Done when
`company-master.fields.complete-round-trip` leaves the baseline and the module has no blocked case.

**WP-08 Data Backup (G64/N80).** Prompt 18 plus OD-4. Add the versioned `tenantConfig` section with an explicit
allowlist and the excluded-secrets list to the v2 archive and its manifest. Done when
`data-backup.config.nextmain-allowlist` leaves the baseline. Restore stays out of the screen (desktop hides it).

**WP-09 Esc everywhere (GB-02).** One shared hook in `web/apps/web/lib/` (the Tag Print fix of G239 is the model). One
browser case per screen first (red), then the hook (green).

**WP-10 Next-number race.** For each voucher page that fills its number from a list read, add a held-response case (the
`tag-cancel.reopen.late-list-keeps-typed-voucher-number` case is the model). Fix the same way as G241.

### Phase 2: reports (12 menus)

| WP | Menu(s) | Desktop form | Pri | Size | Depends | Prompt | State |
|---|---|---|---|---|---|---|---|
| WP-11 | Sales Report + the shared RP_ALL engine | `RP_ALL.cs` (12,662) sales branch | P1 | XL | — | 01 | not started |
| WP-12 | Purchase Rpt (removes 17 G06 baselines) | `RP_ALL` purchase branch | P1 | M | WP-11 | 02 | frozen cases merged |
| WP-13 | Approval Rpt | `RP_ALL` approval branch | P2 | M | WP-11, WP-01 | 03 | partial |
| WP-14 | Order Report | `RP_ALL` order branch | P2 | M | WP-11, WP-03 | — (use 01's pattern) | no longer BROKEN once WP-03 (#232) merges |
| WP-15 | Tag Stock | `RP_TAG.cs` (10,813) | P1 | L | — | 04 | partial |
| WP-16 | Stock Report (new route) | `RP_STOCK.cs` (6,407) | P1 | L | WP-15 | 05 | not started |
| WP-17 | Cash Bank | `RP_CASH_BANK.cs` (4,813) | P1 | L | — | 06 | not started |
| WP-18 | HuId Report | `RP_HUID.cs` (2,731) | P2 | M | — | 08 | filters only |
| WP-19 | Gst Report: the 13 blocked cases | `RP_GST.cs` (3,944) | P1 | M | — | 07 | 57/70 |
| WP-20 | Ledger Report: OP_LDR opening-ledger ageing union, fine prints | `RP_LEDR.cs` | P2 | S | — | 21 | 10/10 |

Rules for every report WP (from `00b-REPORT-ADDENDUM.md`): read-only resolver in its own module, its own route
directory under `web/apps/web/app/(app)/reports/<name>/` (never grow `reports/[report]/page.tsx`), every desktop
selector/filter/grouping/total, drill-down to the voucher, PDF/Excel/CSV, the named Crystal template's regions and
columns. Expected totals are computed in the test from seeded vouchers with the desktop formula, never read back from
the web.

**WP-11** is the most valuable single item: it unblocks four menus. Design the engine as a pure function
`(selection, filters, grouping) → rows + totals` in `@datacare/core` or `apps/api/src/modules/reports/rpAll/` with one
adapter per branch (sales first). Prompt 01 has the branch inventory.

**WP-19.** Includes the labour-work discount: the web `LBR_ISU_DETL` has no discount column while the desktop sums
`IT_DISC_AMT` (`RP_GST.cs:2719`). Adding a column means a migration (S6 rule) and its writer. EXP, EXEMP, DOCS and TCS
sections are part of this WP; the UAE variant is out of scope (Lite India).

### Phase 3: company utilities (5 menus)

| WP | Menu | Desktop form | Pri | Size | Depends | Prompt | State |
|---|---|---|---|---|---|---|---|
| WP-21 | Books | `MS_BOOK.cs` (3,122) | P1 | L | — | 13 | not started |
| WP-22 | Year Create (corrected scope) | `MS_YEAR.cs` (1,596) | P2 | S | — | 14 + GB-07 | not started |
| WP-23 | Balance TrFr | `BtmSchm.cs` (5,638) | P0 | L | WP-22 | 15 | accounts and parties only |
| WP-24 | Data Refresh PR-2 | `MS_UPDATE.cs` (6 visible buttons) | P1 | L | — | 17 | 12/20 |
| WP-25 | Data Import (Lite Soft only) | `UT_IMPORT.cs` (Lite path ≈ 535 lines) | P2 | L | everything else; OD-6 | 19 | not started |

**WP-21 Books.** Wide blast radius: every posting reads book slots. Run the **full** feature suite (on CI) before
merging, not only the books module.

**WP-22 Year Create.** Prompt 14 overstates the work (GB-07): the web already does the first-year 17-table copy (G97),
and the web keeps one database keyed by `CO_YEAR`, so the desktop's restore-and-delete for an existing company has no
equivalent. Real remaining items: the `YEAR_MONTH` alternate-year branch (`MS_YEAR.cs:1153-1198`), "Year Is Already
Exist", rights texts, the print-rights check. Do **not** port the desktop Delete button (it deletes users,
`:970-991`).

**WP-23 Balance TrFr (P0).** Moves money, stock and scheme balances into the next year; a wrong carry is silent. Every
branch the Lite operator can run (account, party, stock, order, scheme, loan, approval, repair, lot, manufacturing; check
in the source which are visible for `MsSoftType = 'L'`) gets a DB test that proves **closing(year N) = opening(year N+1)**
per account and per item for money, gold fine and silver fine. Interruption recovery: the whole transfer is one
transaction, or a resumable job with a checkpoint table; a re-run must not double the openings (idempotency test).

**WP-24 Data Refresh.** Account and Stock become preview + apply with an exact write-set, audit, rollback and replay
proof (Approval Adj is the model); classify Field Update and Old Field into apply / provably no-op on web data /
migration-loader; resolve the two baselined cases (G225, X27/P11-01). The concurrency case needs a synchronization hook
at the repair lock; add one that exists only in test builds.

### Phase 4: close the residuals on existing transaction and master screens

| WP | Menu(s) | Item | Pri | Size | State |
|---|---|---|---|---|---|
| WP-26 | Sales | Lossless reopen on the Sales Invoice screen, tender/source branches, G83 old-metal header valuation, G82 tax codes on web-provisioned companies, Crystal variants, 3 blocked cases | P1 | L | 29/32 |
| WP-27 | Sales Return | Lossless edit, the 5 s transaction budget on create, admissibility, residuals, 2 blocked | P1 | L | 23/25 |
| WP-28 | Purchase | The 95-column hallmark receive branch, lossless reopen, family-filtered books | P1 | L | 31/31 |
| WP-29 | Purchase Rtn | G95 (HSN tax on the print), G96 (grid Enter), 2 blocked | P2 | M | 20/22 |
| WP-30 | Wh Sales | Hand-typed item-detail rows for loose items, SL_IDTL on the print, fine kasar, Rojmel alignment | P2 | M | 27/27 |
| WP-31 | Contra Entry | Multi-line grid, lifecycle, list, print, account roles (G37) | P2 | M | 25/25 |
| WP-32 | Tag Opening, Only Tag Entry | 5 blocked cases, tag label print, G217 karigar block sources, COL_MAST grid | P2 | M | 14/19 |
| WP-33 | Daily Rate | Location-00 session in the harness (T15), the per-location copy, MDI rate labels | P2 | S | 15/16 |
| WP-34 | Tag Print | PRINT_MAST label-file choice (QrPrint10, BarPrint10, BarPrint13, GhatTagPrnt), SubTagPrint sub-report | P3 | M | 18/18 |
| WP-35 | Fine Jv, Party Opening, Item Opening, company-open, settings | The remaining blocked cases (4, 3, 1, 16, n) | P2 | M | — |
| WP-36 | Party, Address, Group, Tax, Employee, Item, AutoItem, Product | Residuals: the N58 help lists on web-provisioned companies; print layouts that are truly absent stay recorded gaps; `TAX_FREE_ITEM`/`EMP_COM_PRC` columns | P3 | M | all green |

A WP in this phase is done when its module has **no blocked case** and its catalog row can be proposed `FULL`.

### Phase 5: Track O, desktop oracle (§6)

| WP | Item | Pri | Size | Depends |
|---|---|---|---|---|
| WP-40 | Golden-vector harness on `windows-latest` (O1 + O2) | P1 | M | — |
| WP-41 | Formula families to L2, one PR per family | P1 | M each | WP-40 |
| WP-42 | Report oracle on a restored desktop database (O3) | P2 | L | owner OK |
| WP-43 | Screen automation of the desktop executable (O4) | P3 | XL | owner OK |

### Phase 6: Track P, production SaaS (§7)

| WP | Item | Pri | Size | Depends |
|---|---|---|---|---|
| WP-50 | Release certification and restore drill green | P0 | M | Phase 1 |
| WP-51 | Security review of every Lite route | P0 | M | Phase 1 |
| WP-52 | Operations: deploy, backups off-host, monitoring, alerting, RPO/RTO drill | P0 | L | WP-50 |
| WP-53 | Customer cutover from a desktop company with reconciliation | P0 | L | Phases 1-3 |
| WP-54 | Performance on a large company and a low-end PC | P1 | M | Phases 1-4 |
| WP-55 | Lite edition gate: a Lite tenant sees exactly the 49 menus | P1 | S | — |
| WP-56 | UAT with a jeweller's operator, then FULL rows and sign-off | P0 | M | everything |

Phases 5 and 6 can run **in parallel** with Phases 2-4 (they touch different files): one session on them, the others on
menus.

---

## 6. Track O: proving the arithmetic against the desktop itself

Why: today desktop-match coverage is 0% because the executable cannot run on this Mac. But the CI already compiles C#
with the .NET Framework 4.8 compiler on GitHub's Windows runner (`.github/workflows/dotnet-fx-probe.yml`,
`web/scripts/dotnet-fx-probe/`), and #225 changed product code on that evidence. Extend it.

- **O1 (exists).** Ad-hoc probes of one rounding rule.
- **O2 (WP-40).** A permanent golden-vector harness:
  1. `web/scripts/desktop-oracle/<family>/Oracle.cs`: the desktop's method bodies **copied verbatim** from
     `unified/src/csharp/DataCareNext/*.cs` (with `FORM.cs:line` in a comment above each), wrapped in a console program
     that reads `vectors.json` (inputs) and writes `expected.json`.
  2. `web/scripts/desktop-oracle/<family>/vectors.json`: inputs generated by a Node script (boundary values: .5 cases,
     zero, negative returns, large weights, every purity, every tax rate in the seed).
  3. A workflow `desktop-oracle.yml` (copy of `dotnet-fx-probe.yml`) compiles each family with `csc
     /r:Microsoft.VisualBasic.dll`, runs it, uploads `expected.json` as an artifact, and commits nothing.
  4. A Node test in `@datacare/core` (`test/desktopOracle.<family>.test.ts`) runs the web implementation on the same
     `vectors.json` and compares with a checked-in copy of `expected.json`. Any refresh of `expected.json` comes only from
     the workflow artifact (record the run id in the file header).
- **Families, in order (WP-41):** (1) sales line: net weight, fine, labour by gram/piece/percent, making, stone, MRP;
  (2) tax and HSN rounding, CGST/SGST/IGST split, round-off (`Fnv`); (3) old gold/silver valuation and conversion weight;
  (4) daily rate derivation by touch; (5) purchase and return amounts, whole rupees (N188); (6) wholesale fine
  settlement and rate cut; (7) ledger running balances in money, gold, silver; (8) GST report cells.
- **O3 (WP-42, ask first).** Restore the desktop SQL Server backup on a Windows runner and run the `RP_*` queries the
  desktop builds, compared against the web report on the same imported data. Needs the owner's OK because the backup is
  real business data: the job may print only aggregates, and artifacts must not contain rows.
- **O4 (WP-43, ask first).** Drive `DataCareNext.exe` itself with UI automation on a Windows runner. Expensive; only if
  O2 and O3 leave important doubts.

A menu reaches L2 when every formula family it uses is green in O2.

---

## 7. Track P: go-live gates for a real jewellery business

Each gate is a WP card above. A gate passes only with a dated evidence file under `docs/parity/` or the existing
`project-memory/parity/` runbooks.

| Gate | Pass criterion | Command / document |
|---|---|---|
| Release certification | `pnpm release:certify` green on the release commit | `web/package.json` |
| Restore drill | `pnpm restore-drill` restores a fresh backup into a scratch database with zero diff, timed (RTO measured) | `project-memory/parity/DR-RUNBOOK.md` |
| Tenant isolation | For every Lite route: a DB test proves a second tenant's token sees and changes nothing (forced RLS) | `test:routes`, route policy tests |
| Authorization | Every Lite route has a policy; a user without View/Edit/Delete/Print gets 403 for that action (T11 in every module) | feature modules |
| Security review | `/security-review` on the release diff; `pnpm advisories` clean; no secret in the repo history added since the last review; login rate-limit and lockout tested | `SECURITY-NOTICE.md` |
| Backups | Nightly encrypted off-host backup, 30-day retention, alert on failure; monthly restore drill | `web/deploy/backup.sh` |
| Monitoring | Health and metrics endpoints scraped; alerts on 5xx rate, p95 latency, DB connections, disk, failed backup | `web/apps/api/src/modules/ops/health.ts`, `metrics.ts` |
| Deploy | `web/deploy/docker-compose.prod.yml` brought up on a clean VM from `web/DEPLOY.md` alone; TLS; zero-downtime migration rehearsal; rollback rehearsal | `web/DEPLOY.md` |
| Cutover | A desktop company imported into a tenant reconciles exactly: trial balance, party balances (money, gold fine, silver fine), stock by item and tag count, open orders and approvals | `project-memory/parity/CUTOVER-RUNBOOK.md` |
| Performance | Voucher save p95 under the 5 s transaction budget on a company of realistic size; screens usable at 1366x768 on a low-end PC | `pnpm load:profile`, `LOAD-PROFILE.md` |
| Edition gate | A Lite tenant's navigation shows exactly the 49 Lite menus; other routes 403 | `generate-edition-table.mjs --check` |
| UAT | An operator runs `UAT-PLAN.md` on the cutover tenant for a working week; every defect fixed or accepted in writing | `project-memory/parity/UAT-PLAN.md` |

Production deployment to a real host with real customer data is a **stop-and-ask** step: the plan prepares and rehearses
it, the owner triggers it.

---

## 8. Troubleshooting recipes

| Symptom | Cause | Fix |
|---|---|---|
| `Docker Desktop is unable to start` / parity env fails at once | Disk under about 1 GiB free | §4 S0; then `open -a Docker` |
| Browser run shows old behaviour | Stale `.next` after a branch switch or merge (N186) | Rebuild (`pnpm build` with `API_ORIGIN`) |
| A case passes alone and fails in the full run | Another module left rows (`CO_SET_NEW`, `RATE_MAST`) | Make the case tolerate existing rows and clean up its own in `finally` |
| Setting changes leak into later modules | Setup before the `try` failed | Put every setting change inside the `try` whose `finally` restores it |
| Route not counted / not policy-checked | Route registered with a variable path | Literal path string |
| `book` query parameter refused | Session book-scope guard | Name it `bookCode` |
| `ORDER BY id` gives 10 before 2 | Sorting the text alias | Order by the table column |
| Insert fails on `EMP_CODE` | Column is `varchar(3)` | Test codes of three characters |
| `validate_plan.py` fails on ids | Not contiguous / collides with an open PR | §4 S9: renumber after merging `main` |
| Generated files conflict | Hand-merged | Take `main`'s side, then regenerate (`docs_check.py --write`, `pnpm progress`, `build_matrix.py`) |
| Conflict markers committed | `git add -u` after a conflicted merge | §4 S9 grep before every commit |
| `typecheck:tests` runs out of memory | 8 GB machine | Close other stacks; it already sets 6 GB heap; run it alone |
| CI real-stack red, local green | Module order or timing | Download the artifact, read `01-failure.png` and `run.json`; reproduce with the same module order |
| Same fix failing three times | You are guessing | Stop, write what you tried and the exact error in `AGENT-PROGRESS.md`, release your slot, ask |

---

## 9. Appendix: the 49 Lite menus mapped to work packages

| Menu | Matrix status (2 Nov) | WP |
|---|---|---|
| Company | BROKEN | WP-07 |
| Year Create | NOT YET VERIFIED | WP-22 |
| Balance TrFr | NOT YET VERIFIED | WP-23 |
| Books | NOT YET VERIFIED | WP-21 |
| User Create | BLOCKED | WP-06 |
| Data Refresh | PARTIAL | WP-24 |
| Data Backup | BROKEN | WP-08 |
| Approval Isu | NOT YET VERIFIED | WP-01 |
| Approval Rtn | NOT YET VERIFIED | WP-01 |
| Fine Jv Entry | PARTIAL | WP-35 |
| Party | PARTIAL | WP-09, WP-36 |
| Address | PARTIAL | WP-09, WP-36 |
| Product | PARTIAL | WP-09, WP-36 |
| Group | PARTIAL | WP-09, WP-36 |
| Item | PARTIAL | WP-09, WP-36 |
| AutoItem | PARTIAL | WP-09, WP-36 |
| Employee | PARTIAL | WP-09, WP-36 |
| Tax | PARTIAL | WP-09, WP-36 |
| Party Opening | PARTIAL | WP-35 |
| Item Opening | PARTIAL | WP-09, WP-35 |
| Tag Opening | PARTIAL | WP-32 |
| Daily Rate | PARTIAL | WP-33 |
| Only Tag Entry | PARTIAL | WP-32 |
| Tag Cancel | PARTIAL | WP-10 (+ Track O) |
| Tag Print | PARTIAL | WP-34 |
| Stock Adjust | PARTIAL | WP-04 |
| Order Cancel | NOT YET VERIFIED | WP-02 |
| Data Import | NOT YET VERIFIED | WP-25 |
| Ledger Report | PARTIAL | WP-20 |
| Stock Report | PARTIAL | WP-16 |
| Tag Stock | PARTIAL | WP-15 |
| Sales Report | NOT YET VERIFIED | WP-11 |
| Purchase Rpt | NOT YET VERIFIED | WP-12 |
| Approval Rpt | NOT YET VERIFIED | WP-13 |
| Order Report | BROKEN | WP-14 (after WP-03) |
| Cash Bank | NOT YET VERIFIED | WP-17 |
| Gst Report | PARTIAL | WP-19 |
| HuId Report | NOT YET VERIFIED | WP-18 |
| Purchase | PARTIAL | WP-28 |
| Purchase Rtn | PARTIAL | WP-29 |
| Sales Order | BROKEN | WP-03 |
| Sales | PARTIAL | WP-26 |
| Sales Return | PARTIAL | WP-27 |
| Wh Sales | PARTIAL | WP-30 |
| Cash Received | PARTIAL | WP-05 |
| Cash Payment | PARTIAL | WP-05 |
| Bank Received | PARTIAL | WP-05 |
| Bank Payment | PARTIAL | WP-05 |
| Contra Entry | PARTIAL | WP-31 |

## 10. Keeping this plan true

- Each merged WP updates its "State" cell in §5 (same PR or the next docs PR).
- When a WP turns out bigger than its card says, split it into `WP-nn.a/b` here before continuing.
- Re-verify §2 at the start of each working day: `git log origin/main -1`, `gh pr list`, the id counters, disk.
- When the owner overrides a default in §3, every open WP that used it is re-checked against the new decision.
