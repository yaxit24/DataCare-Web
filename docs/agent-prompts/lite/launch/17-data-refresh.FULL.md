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

# Agent 17 — Company → Data Refresh   (Lite package L5)

**Type:** BUILD — scope DECIDED 2 Nov (owner-delegated): the 6 operator-visible buttons only  
**Suggested wave:** 3  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first. This file is the menu-specific part.

## Mission

Make Company → Data Refresh the desktop `MS_UPDATE` screen **as an operator sees it**: six repair buttons, each running a preview-first, single-transaction, audited repair. The vendor-only tools the desktop hides behind a secret key are out of scope.

## Identity and hand-offs

- **SLUG** `data-refresh`  **BRANCH** `feat/lite-data-refresh`  **worktree** `~/dc-wt/data-refresh`  **feature module** `dataRefresh`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-data-refresh` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `MS_UPDATE` — mode: direct constructor
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:7461-7470`
- **Tables:** `AC_DATA`, `MAIN_STOCK`, `BAR_DETL`, `BOOK_DATA`, `TAX_DATA`, `OP_DATA`, `MFG_DATA`
- **Web routes:** `/utilities/data-refresh`, `/utilities/data-repair`
- **API:** `POST /utilities/data-refresh`, `GET /utilities/data-repair/operations`, `POST /utilities/data-repair/:id/preview`, `POST /utilities/data-repair/:id/apply`
- **Desktop rights:** `C----L` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `PARTIAL`  **Phase:** `P1-core`  **Owners (slices/gaps):** X27, P11-01, X06
- **Purpose:** Rebuilds or repairs derived ledger, stock, schema, image, scheme and manufacturing data.
- **Recorded gap:** Refresh deliberately avoids write-back; the repair registry covers a subset of desktop operations; ownership graph, rollback and recovery are unproven.
- **Sources:** `web-implementation-spec/03_Modules/13_Utilities_Settings_Integrations/VARIANTS.md:99-119`

## Desktop pointers (start your study here)

- `MS_UPDATE.cs` is 33,074 lines but **an operator sees only six buttons**. All the others are `Visible = false` in the designer (`:1535-1986`) and are revealed only by the secret **Ctrl+O** (`MS_UPDATE_KeyDown :2275-2301`), or by company type (`Mfg Refresh` only when `MsMfgType = "M"`, `:2180-2183`; `Scheme Data` only with `MsAppSchem = "Y"`).
- **In scope (visible by default):** `Account` `btnAc_Click :2334` (67 lines: fills `BOOK_DATA/BOOK_DETL.DATA_TYPE`, `CASH_DATA.CLR_DATE`, rebuilds `BANK_RECONCILE` and restores `AC_DATA.CLR_DATE`, runs `AcRefresh()`, then `Ac_Tax.Vch_Remark` for every in-use book; ends "Account Refersh Process Complete."); `Stock` `btnStock_Click :2671` (181 lines: recomputes `ITM_FINE` where it is <= 0 on `BAR_DETL` / `SL_DETL_RTN` …); `Approval Adj` `btnAprUpdate_Click :8809` (16 lines); `Image Data` `BtnImgData_Click :8825` (232 lines); `Field Update` `btnFildUpdate_Click :3958` (**≈4,850 lines**); `Old Field` `btnFildUpdate2_Click :9412` (**≈22,900 lines**).
- **Out of scope, and why:** the 12 Ctrl+O tools (`Crm Data`, `Problem Qry`, `TagDiff Set`, `All Tag Stock Delete`, `SrNo Mast Update`, `Bar Idtl SrNo Update`, `Sl Wt Diff Set`, `Other Set`, `OpBal Update`, `Tag Sale But Not In BarDetl Adjust`, `A Stock Set`, and the date-ranged ones) are vendor support tools for repairing a customer's damaged database, not operator features. Do **not** build the Ctrl+O reveal. `Mfg Refresh`, `Scheme Data` belong to editions/settings outside Lite.
- Every button first requires the Print right: message `You Have No Print Rights.....` (`UserPrint = "Y"`; rights are read by the menu caption, `:2042`).

## Current web state

- Pages `utilities/data-refresh/page.tsx` (100 lines) and `utilities/data-repair/page.tsx` (391); API `POST /utilities/data-refresh`, `GET /utilities/data-repair/operations`, `POST /utilities/data-repair/:id/preview|apply`. Catalog: "Refresh deliberately avoids write-back; the repair registry covers a subset; ownership graph, rollback and recovery are unproven." Slices X27 / P11-01.

## Decisions already made (owner-delegated on 2 Nov 2026; do not re-open them, do not ask again)

- **D-REF-1 — operator-visible buttons only.** Six buttons (Account, Stock, Field Update, Approval Adj, Image Data, Old Field). The 12 `Ctrl+O` vendor tools, `Mfg Refresh` and `Scheme Data` are out of Lite scope; no hidden shortcut is built.
- **D-REF-2 — preview-first, one transaction, audited, idempotent.** A deliberate safety improvement; the business result of each repair is unchanged.
- **D-REF-3 — the two giant buttons are classified before they are built** (apply / provably-no-op on web data / migration-loader). Nothing from the 27k lines is ported blindly.

## Scope — what you must deliver

- **Screen:** the six desktop captions in the desktop order, a progress indicator, the desktop completion messages (keep the original spelling), the Print-right gate with its exact text. No hidden shortcut.
- **Every operation is preview-first:** counts and a sample of the rows it would change, then Apply in **one transaction** with an audit row, tenant-scoped, idempotent (a second run changes nothing). Never a blind write. This is a deliberate improvement over the desktop's unguarded loops and does not change the business result.
- **PR 1 (small, ship fast): Account, Stock, Approval Adj, Image Data** (about 500 desktop lines in total). Prove each with a controlled corruption of derived data through a fixture, preview, apply, and a **full-tenant diff** showing only the intended rows moved.
- **PR 2: classify `Field Update` and `Old Field` (≈27,700 lines) before building anything.** Table: every UPDATE statement → one of **(a)** the anomaly can occur in data the web writes → implement as a repair; **(b)** it only repairs shapes produced by older desktop versions → write an *anomaly query* and prove, on a tenant populated through every Lite screen, that it returns 0 rows; the button then truthfully reports "no records need adjustment" (this is the desktop's own outcome on a clean database); **(c)** only needed after loading desktop data → list it for the migration loader (slices X30/P12/N30), do not build it here. Implement class (a) only.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Per operation: corrupt → preview shows exactly the rows → apply → derived data equals a clean recompute from the vouchers → run again (no-op) → a voucher saved concurrently during apply (conflict handled, nothing lost).
- Rights by caption "Data Refresh" (G225 lists it as not closed — settle it here), a restricted user is refused by the API.
- Second tenant untouched in every case.

## Risks and traps

- Repair tools can destroy data; preview-first is not optional. If you cannot reproduce a desktop effect exactly, ship preview-only for that operation and say so.
- Classification PR is analysis, not code: do not skip it to "get on with it" — 27k lines of legacy patches must not be ported blindly.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `modules/ops/*`
- the two utilities pages

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
