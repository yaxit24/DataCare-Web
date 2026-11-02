# GENERIC PROMPT — DataCare-Web, Lite edition menu to "done"

You are an independent engineering agent. You own **one desktop menu** of the DataCareNext jewellery ERP (named in
your menu prompt) and must take it from its current state to *done*: it behaves like the desktop, and every claim is
proven by a frozen browser case list run through the real screen. Your menu prompt below this generic text gives the
menu-specific facts, scope, risks and dependencies. If the two ever disagree, the menu prompt wins on scope and this
text wins on process.

Repository: `~/DataCare-Web` (GitHub `yaxit24/DataCare-Web`). The desktop (`unified/src/csharp/DataCareNext/*.cs`,
decompiled VB.NET WinForms) is rebuilt as a web app in `web/` (Next.js, Fastify API, PostgreSQL with forced row-level
security). **The desktop source is the authority for business behaviour.**

---------------------------------------------------------------------------------------------------------------------

## 0. What "done" means (read twice)

A menu is **done** only when all of these hold (document 15 §5, `docs/handbook/web/standard-progress.md`):

1. Its catalog row in `docs/handbook/menu-catalog.jsonl` is `FULL`, and
2. a browser feature module covers it with **no failing, blocked or baselined case**, and
3. its writers have write-set database tests, and
4. a pull request is open with every gate output quoted.

You will often not reach `FULL` in one pull request (desktop-runtime comparison does not exist yet; some rules need an
owner decision). That is acceptable **if you say so**. Never mark a catalog row `FULL`, never mark a slice accepted,
and never claim desktop match: no case has been run on the original Windows desktop, so desktop-match coverage is 0%
for everything. Report three numbers separately and never average them: *executed coverage*, *browser pass coverage*,
*desktop-match coverage* (`.kiro/skills/datacare-feature-browser-validation/references/evidence-contract.md`).

## 1. Hard rules (violating any of these wastes the owner's time)

- **Never push to `main`. Never merge.** (`gh pr merge`, force-push, `git reset --hard`, `git clean -f`, `--no-verify`
  are blocked in the project agent.) Work on your own branch, open a PR with `gh pr create`, stop there.
- **Never touch another session's branch, worktree (`~/dc-wt/*`, `~/DataCare-Web` itself) or PR.** Create your own
  worktree (section 2). Do not take a slice another session or open PR already owns (`python3 docs/tools/session_status.py`).
- **Stage specific files** (no `git add .`). Keep hooks on. Do not amend pushed commits.
- **Tests only on the isolated database** started by `web/scripts/parity-test-env.mjs`. Never on a database with real
  data. Desktop SQL Server: aggregate queries only; never print names, phones, addresses or row dumps.
- **Never print or copy secrets.** The repo tracks legacy credentials on purpose (`SECURITY-NOTICE.md`); refer to
  environment variables by key name only.
- **Do not weaken a case to make it pass.** A failing case is a finding: record a gap, add it to
  `web/apps/web/test/features/baseline.json` with the gap id, then fix it in a follow-up commit and remove the
  baseline entry in the same change. A case may become N/A or blocked only with a source-backed reason written
  **before** the run.
- **Do not port desktop weaknesses** (string-built SQL, plaintext passwords, global state, unscoped deletes, partial
  writes). Reproduce the *business result*, the *message texts* and the *keyboard flow*, not the unsafe mechanism.
- **Browser-Test-Exempt is not available to you.** Your PR changes browser-visible behaviour, so it changes a feature module.
- **Stop and ask the owner** (end your turn with a clear question) when: a rule needs an owner decision the repo has not
  accepted; a case can only be decided on the Windows desktop; the work would lift a containment rule
  (`web/packages/core/containment.mjs`); it needs customer data; it needs a physical device (device fakes are allowed
  for engineering tests, physical acceptance stays pending, decision D29). Do not guess.

## 2. Setup (do this first, in this order)

```bash
cd ~/DataCare-Web && git fetch origin --prune
python3 docs/tools/session_status.py             # who else is working; do not take their slice
git worktree add ~/dc-wt/<SLUG> -b <BRANCH> origin/main     # SLUG and BRANCH are in your menu prompt
cd ~/dc-wt/<SLUG>/web && pnpm install --frozen-lockfile
```

Read, in this order (skim what you already know): `AGENTS.md`, `docs/README.md`, `project-memory/HANDOFF.md` (top
sections), `docs/handbook/web/engineering-standards.md`, `docs/handbook/web/testing.md` (§2, §4a, §4b, §5),
`docs/master-parity-plan-2026-09-29/04-verification-playbook.md` (§3 matrix T01–T18),
`docs/master-parity-plan-2026-09-29/15-standard-edition-plan.md` (§5), your menu's row in
`docs/handbook/menu-catalog.jsonl`, and the skills you will use: `.kiro/skills/datacare-desktop-authority`,
`datacare-test-first`, `datacare-write-set-test`, `datacare-feature-browser-validation`, `datacare-e2e-visual`,
`datacare-verify-before-done`, `datacare-docs-update`, `datacare-plan-update`.

**Study the finished examples before you write anything** (all merged to `main` on 1 November). They are the template for
structure, depth and tone:

| Example | Commit | Look at |
|---|---|---|
| Address master (MS_ADD_MAST) | `42955a7d` (#192) | `web/apps/api/src/modules/masters/addressMaster.ts`, `routes/addressMaster.ts`, `app/(app)/masters/addresses/page.tsx`, `test/features/modules/addressMaster.mjs`, `api/test/addressMaster.db.test.ts` |
| Item master (MS_ITEM) | `9a2ec144` (#193) | `itemMaster.mjs` (1,290 lines of cases), `masters/items/page.tsx`, `lib/lookupEnter.ts` |
| Auto Item, Wh Sales | `df7ddd7f` (#194), `c6101aeb` (#196) | `autoItem.mjs`, `wholesaleSale.mjs` |
| Tag Cancel (voucher with print) | PR #185 | `tagCancel.mjs`, `components/TagCancelForm.tsx`, `modules/stock/tagCancel*.ts` |

Their PR bodies show the expected record-keeping (catalog row, backlog, gap, progress page).

### 2.1 Machine limits and isolation (8 GB RAM, 8 cores — this matters)

Many agents share this laptop. Reading, desktop study, case writing and coding are cheap; **building the web and running
the browser stack is heavy**. So:

- **At most 3 browser stacks run at once, machine-wide.** Take a slot before you build or run a stack and release it
  after (the directory is the lock; `mkdir` is atomic):

  ```bash
  mkdir -p ~/.cache/datacare-stack-slots
  for k in 1 2 3; do mkdir ~/.cache/datacare-stack-slots/slot-$k 2>/dev/null && { SLOT=$k; break; }; done
  [ -n "$SLOT" ] || echo "no free slot: keep working on code/cases and retry in a few minutes"
  # ... build + run ...
  rmdir ~/.cache/datacare-stack-slots/slot-$SLOT      # ALWAYS release, also after a failure
  ```

- Ports by slot (nothing else on this machine uses them; check with `lsof -nP -iTCP:<port> -sTCP:LISTEN` first):

  | Slot | `PARITY_TEST_PORT` (DB) | `PARITY_API_PORT` | `PARITY_WEB_PORT` |
  |---|---|---|---|
  | 1 | 55501 | 4611 | 4612 |
  | 2 | 55502 | 4621 | 4622 |
  | 3 | 55503 | 4631 | 4632 |

- Set `PARITY_TEST_PROJECT=dc-<SLUG>` so your Compose project and database are yours alone. A database named after the
  checkout is torn down by any other run from the same checkout.
- Build the web with the API origin you will run against:
  `API_ORIGIN=http://127.0.0.1:<API port> pnpm --filter "@datacare/web..." run build`
- Run modules with **only your module(s)**, never the full suite while developing:
  `FEATURE_E2E_MODULES=<module> [FEATURE_E2E_CASES=<case id>] node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs`
  Run the full feature suite once, at the end, in your final verification.
- Do not use ports 4410/4411 or 5433/55433/55800 (the owner's own stacks).
- Chrome: another session may share the debugging Chrome on port 9222. Open **your own tab in an isolated context**
  (`new_page` with `isolatedContext: "datacare-<SLUG>"`), keep the page id, pass it to every call, never reuse or
  navigate another session's tab, and close your tab when finished. Viewport `1366x768x1` (the desktop reference size).

## 3. The method — six steps, in order

### Step 1 — Desktop study (no code yet)

Use the `datacare-desktop-authority` skill. Read the form's source end to end and write down, **with `file:line`
citations**: every control and its tab order; every key (Enter flow, F1 help, F-keys, Ctrl-keys, Esc); every mode and
book family and what `CurBookHelp` does; every validation with its **exact message text**; every calculation with its
rounding stage; every table written/read, with column sets; every print and report it feeds; the rights checks
(`FRM_*`, `USER_SET`) and the lock-date/year/`TYPE B` checks; what Load, Display, Clear, Save, Delete, Print, First/Last
do. Also read `web/apps/api/form-specs/DataCareNext.<FORM>.layout.json` (field order/captions) and the matching
`project-memory/video-research/_kb/KB_*.md` section (screen captures and operator narration, with keyframe references).
For printed output find the Crystal template (`*.rpt` at the repo root and `zip_contents/`, XML in
`extraction_output/rpt_xml/`). Mark each finding *source-backed* or *inferred*. Inferred findings are blocked cases, not
passes.

Write this study into the PR description (and, if long, into `docs/handbook/` per `datacare-docs-update`). It must name
what the desktop does that the web currently does not — that list becomes your gap and your case list.

### Step 2 — Freeze the case list (no code yet)

Create the feature module `web/apps/web/test/features/modules/<module>.mjs` **before** fixing anything. Copy the shape
of `addressMaster.mjs`: the `C(id, group, kind, source, run, extra)` factory, `requiredEvidence` by kind
(`mutation` → browser+expected+database+downstream; `refusal` → browser+expected+database; `output` →
browser+expected+output), `notApplicable(...)` with a reason, cases named `<module>.<group>.<what>`. Every case cites
its desktop source and **computes its expected value by hand from the desktop rule — never from the web's output**.

Expand every applicable T-group of the playbook into source-backed cases (do not pad with generic ones; do not skip a
group without a written reason):

| Group | For your menu |
|---|---|
| T01 entry/defaults | open through the real menu; book chooser (one book auto-selected, several give a choice, none gives a clear error); defaults; focus; role variants |
| T02 field route | change each field through its real control; read the request, DB row, reopen, downstream report: no dead field |
| T03 formula | ordered event vector with the intermediate totals and the rounding stage |
| T04 lookup | F1 help, type-ahead, cancel, pick another, stale/slow response rejected, scoped identity |
| T05 children | grid rows: two dissimilar sets, insert/reorder/delete, child ownership |
| T06 required/invalid | blank/zero/negative/overflow/length/bad reference: **exact desktop message**, focus, and **no write** (prove it) |
| T07 create | save once through the browser, then compare the complete write set (every table, every column that matters) |
| T08 reopen/no-op | reopen, save unchanged, compare the full before/after footprint (clocks, NULL vs blank, scale, hidden fields) |
| T09 edit | change one owned field; only allowed rows change; downstream recomputed |
| T10 delete/cancel | delete/reverse; blocked when a downstream document depends on it; audit rows (`DELETE_DATA`) as the desktop writes them |
| T11 scope/rights | other company/location/year/book and restricted user hit the API directly: denied, nothing leaks, nothing written; the desktop rights rows (`USER_SET`, keyed by the menu caption) |
| T12 concurrency | two sessions load the same record; stale save and stale delete rejected (version token); two users claiming the same stock/source |
| T13 retry | duplicate submit and a lost acknowledgement after commit: one durable result |
| T14 rollback | fail after each table of the write set: complete rollback, sentinels intact |
| T15 config/history | change a setting/master between open and save; reopen an older document |
| T16 report/output | print/PDF/CSV and every related report after create, edit, delete |
| T17 keyboard | the whole reference workflow by keyboard at 1366x768 |
| T18 journey | continue the result through its downstream chain (stock, ledger, outstanding, reports) |

Include **every defect already recorded for the menu** (catalog `gaps`, `owners`, doc 12 rows) and every refusal text.
Use distinct, non-default field values. Never seed the voucher under test by SQL: masters and sentinels may be seeded in
`fixtures/catalogue.mjs`; the thing under test is always created through the screen. Register the module in
`run-features.mjs` and add its entry to `web/apps/web/test/features/coverage-map.json` (**list the page file, the
components and the API modules** — a missing page path is why Tag Cancel shows "no module" on the progress page).

Commit the frozen list. From now on the list only grows.

### Step 3 — Run it against the current web, record what fails

Take a stack slot (§2.1), build, run only your module. Every failing case becomes: a gap row (doc 12), a baseline entry
(`baseline.json`, shrink-only), and a fix task. Save the failed run (`test-results/feature-e2e/<module>/`); on a fix
rerun the failing case plus its lifecycle neighbours on the new commit — old evidence never counts for a changed
candidate.

### Step 4 — Fix, test-first

Fix each defect with tests written first (`datacare-test-first`): kernel vectors in `@datacare/core` for calculations;
unit tests; **a write-set database test** for every writer (`datacare-write-set-test`: compare every column of every
written row and diff the whole tenant before/after; include rollback and the stale-version case); route policy test
(`routePolicy.test.ts`); then the browser case. Rules from `engineering-standards.md`, the ones that have bitten
before in this repo:

- New or moved **page ≤ 600 lines**, new API route/module file **≤ 800 lines** — split into components, hooks, `types.ts`
  (see `reports/account-ledger/` in PR #195). Files over 1,500 lines have a ceiling in `web/parity/size-budget.json` that
  **may only fall**; `routes/txn.ts` (8,360) and `reports/[report]/page.tsx` (1,742) are at theirs. **Do not grow either.**
  Put new routes in a new file under `apps/api/src/routes/` and add the one-line registration (see
  `routes/addressMaster.ts`).
- **No account-code literals** in posting code: resolve cash/bank/income/expense accounts from `BOOK_DETL` slots.
- Parameterised SQL only; every table access through `withTenant(...)` with company/location/year in the key; a
  version token on every editable record (stale save → 409 with the desktop-style message); idempotent writes.
- **Desktop message texts verbatim**, including their odd spelling ("Data Are Saved.", "Please Insert Party Name ...").
- Rights: the desktop reads `USER_SET` by the **menu caption** (`MDI_FORM.cs:7034-7046`); make sure your screen is
  reachable by the caption alias in `rbac/formCatalog.ts` and add a route policy. New nav items/pages must be classified
  in `docs/handbook/web-route-editions.json` (`node scripts/generate-edition-table.mjs`).
- Lookups: a lookup box that upper-cases typing used to drop every answer (found in the Item master): reuse
  `lib/lookupEnter.ts` and test it.
- Prints: reproduce the named Crystal template's content and order (semantic layout parity, decision D20 — regions,
  field order, captions, grid columns, not pixels). If the template is not in the repository, say so and record it as
  a gap; do not invent a layout.

### Step 5 — Visual and keyboard check

Use `datacare-e2e-visual` (testing.md §5): your isolated Chrome tab, 1366x768, open the screen **from the navigation, not
by URL**, `take_snapshot` and save it, compare regions/labels/field order/grid columns with the desktop form and the
`_kb` keyframes, walk the Enter/F-key flow, check console and network for errors, print preview. Attach the summary to
the PR.

### Step 6 — Records, gates, PR

1. **Rebase on a fresh `origin/main` first.** Then — and only then — take the **next free** slice id `N###` and gap id
   `G###` (max existing + 1, in `execution-backlog.json` and `12-lineage-verification-2026-10-01.md`). Ids must stay
   contiguous (`validate_plan.py` enforces it), many agents are working at once, and two open PRs already collided on
   `N219/G232`. If another PR merges before yours, rebase again and renumber. Never reserve ids early.
2. Update, in the same PR: the menu's row in `menu-catalog.jsonl` (status stays `PARTIAL`/`REPORT` unless every case
   passes and no gap is open; list owners and the remaining honest gaps), the doc 12 gap rows, the backlog entry, the
   handbook page if you changed behaviour (the code wins over a handbook — fix the handbook), the coverage map, and
   `HANDOFF.md` (a short dated note). **Regenerate generated files, never hand-merge them**:
   `python3 docs/tools/docs_check.py --write` and, in `web/`, `pnpm progress`. After each rebase run them again.
3. Gates — run them and **quote the actual output** in the PR (`datacare-verify-before-done`). CI on GitHub may be
   disabled by a billing failure, so these local results *are* the merge evidence:

```bash
# in web/
pnpm lint && pnpm typecheck && pnpm typecheck:tests && pnpm format:check && pnpm build
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test        # use YOUR slot's PARITY_TEST_PORT
pnpm --filter @datacare/core test && pnpm --filter @datacare/web test && pnpm --filter @datacare/web test:routes
node scripts/check-browser-test-coverage.mjs --base origin/main
pnpm progress:check && pnpm docs:refs
# full feature run once, at the end, on the final commit:
node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
# at the repository root
python3 docs/master-parity-plan-2026-09-29/validate_plan.py && python3 docs/tools/docs_check.py
```

4. Open the PR: title `L<package>: <menu> is the desktop <FORM> screen (N###, G###)` (see the merged examples).
   Body: *what the desktop does* (cited), *what changed*, *cases: executed / passed / failed / blocked / N/A with ids*,
   *the three coverage numbers separately (desktop match 0%)*, *gate output*, *what was NOT verified and why*, *screenshots
   and the visual summary*, *adaptations that differ from the desktop on purpose (each with its reason)*, *open items*.
   Then stop. Do not merge.

## 4. Failure handling

- Stuck on a build/stack problem for more than ~30 minutes: write down what you tried and the exact error, release your
  slot, and report. Do not loop.
- A finding outside your menu (another menu's bug): record it as a gap row with its evidence; do not fix it unless it
  blocks you, and then in a separate small commit/PR of its own.
- The desktop source is ambiguous or unreadable: say which lines, mark the case blocked with that reason, continue
  with the rest.
- Never leave your slot locked, your Chrome tab open, or Docker containers running when you stop
  (`node scripts/parity-test-env.mjs` tears down on exit unless `PARITY_TEST_KEEP=1`).

## 5. Final report (the last message you send)

```
MENU:        <name> (<FORM>)             BRANCH: <branch>        PR: <url or "not opened: why">
STATE:       catalog <before> -> <after>; gaps opened/closed: G..., G...; slice N###
CASES:       total <n> | passed <n> | failed <n> (baselined: ids) | blocked <n> (ids + reasons) | N/A <n> (ids + reasons)
COVERAGE:    executed <x%> | browser pass <y%> | desktop match 0%
GATES:       <each command: pass/fail, one line>
DESKTOP RULES NOT YET PROVEN:  <list>
NEEDS OWNER: <decisions/questions, or "none">
TOUCHED SHARED FILES: <list, so the coordinator can predict merge conflicts>
```


==============================================================================================================

# Agent 18 — Company → Data Backup   (Lite package L5)

**Type:** BUILD — scope DECIDED 2 Nov (owner-delegated): Backup only, exactly like the desktop; **no restore, containment untouched**  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Company → Data Backup the desktop `UT_BKP` screen **as an operator sees it**: pick where to save, press Backup, get "Backup Process Complete." The desktop never shows Restore to the operator; the web does not either.

## Identity and hand-offs

- **SLUG** `data-backup`  **BRANCH** `feat/lite-data-backup`  **worktree** `~/dc-wt/data-backup`  **feature module** `dataBackup`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-data-backup` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `UT_BKP` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7471-7480`
- **Tables:** —
- **Web routes:** `/backup`
- **API:** `GET /backup`, `POST /backup/restore`
- **Desktop rights:** `C-----` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `CONTAINED`  **Phase:** `P1-core`  **Owners (slices/gaps):** G64, N80, X31, P12-05
- **Purpose:** Creates full SQL Server backups (yearly database plus NextMain) on a chosen drive and restores them.
- **Recorded gap:** Web offers a logical JSON export; restore is contained; encrypted off-site backup, scheduled restore drill and rollback remain.
- **Sources:** `project-memory/video-research/_kb/KB_master.md:225-253`

## Desktop pointers (start your study here)

- `UT_BKP.cs` is 1,298 lines. **`BtnRestore.Visible = false` (`:859`) and no code ever sets it true**, so a Lite operator cannot restore from this screen. `btnAttach` ("Dattach", `:899-901`) is shown only when `DC_Main.MsSqlDataPath` is set (`:1099-1102`; read from a file, `DC_Main.cs:976`) and detaches both SQL Server databases and quits the app: a vendor/IT tool specific to SQL Server, meaningless on the web.
- `BtnBkp_Click :1198-1251`: Print right required (`You Have No Print Rights.....`); empty path → `Please Select Path and Try`; remembers the path (registry `NEXT SOFTWARE\BACKUP_DATABASE\BACKUP_PATH`); writes `<path>\Next<YY>[_<company type>]_ddMMyy_HH.BAK` (company database; an existing file of the same name is deleted first) and `NextMain.BAK` (the master/config database); ends `Backup Process Complete.` with a progress bar and timer.
- The restore code (`BtnRestore_Click :1253`, `RESTORE DATABASE …`) exists but is unreachable from the UI.

## Current web state

- Page `backup/page.tsx` (53 lines); `modules/ops/backup.ts` (507) + `backupManifest.ts`; `GET /backup` (per-company JSON export with an integrity manifest); `POST /backup/restore` is **disabled by `web/packages/core/containment.mjs`**; `web/deploy/backup.sh` (`pg_dump` cron). Docs: DR runbook in `project-memory/parity/DR-RUNBOOK.md`.

## Decisions already made (owner-delegated on 2 Nov 2026; do not re-open them, do not ask again)

- **D-BKP-1 — parity = Backup only.** Matches what the desktop operator can do. Restore stays an operator/IT procedure (physical database recovery, DR runbook); `containment.mjs` is **not edited**. No owner decision is needed because the desktop does not offer the operator a restore either.
- **D-BKP-2 — "choose a path" becomes the browser's Save dialog.** A browser cannot write to a server path; the equivalent of the folder picker is the download location. Keep the caption, the progress indicator and the messages.
- **D-BKP-3 — file content = this company's data plus the equivalent of `NextMain`** (this tenant's company/user/rights/menu configuration), as one download named `Next<YY>[_<type>]_ddMMyy_HH` (+ archive extension), integrity manifest inside. No other tenant's data, ever.

## Scope — what you must deliver

- The desktop screen: path/download control, **Backup** button, progress, the three exact messages, the Print-right gate (rights by caption "Data Backup"), audit row for who backed up when.
- The backup **content** must be complete for every Lite dataset (masters, vouchers, tags, openings, settings, rights) and its manifest hash must verify. Prove completeness by restoring it **into a scratch database using the documented physical procedure** (not the web restore) and diffing the tenant to zero.
- Leave `POST /backup/restore` disabled and make sure no UI path reaches it; a test asserts the route still answers the containment refusal.
- No `Dattach`, no restore button, no registry/path persistence on the server.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Backup of a company holding every Lite dataset; byte-stable manifest; a second tenant never in the file; restricted user refused by the API; two backups in the same hour (same name) behave as the desktop (replaced); large company completes and reports progress; restore route still refused.

## Risks and traps

- Do not "helpfully" enable restore. Anything that changes `containment.mjs` is out of scope and a reason to stop.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `ops/backup*.ts`
- `backup/page.tsx`

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
