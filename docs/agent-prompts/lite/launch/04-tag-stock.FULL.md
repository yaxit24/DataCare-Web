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

# REPORT ADDENDUM — read after 00-GENERIC.md when your menu is a Report-tab menu

A report writes nothing, so the voucher parts of the generic method (T07–T10, T12–T14) become **filters, totals,
drill-down and output**. The standard of proof is higher, not lower: a report is only right if its numbers equal the
numbers you get by adding up the vouchers *you created through the screens*.

## What replaces the voucher matrix

| Group | Report version |
|---|---|
| T01 entry | Open through the **navigation** (Report tab → the menu caption). Every selector the desktop form shows (dates, party, book, product, group, item, tab/mode radio, grouping, "all" boxes) with its default; hidden/shown by edition (Lite) and by setting. Rights are `----PL` (Print, List): a user without them is refused by the **API**, not only hidden. |
| T02 field route | Each filter changes the result the way the desktop's SQL does: change one filter, assert the exact row set (ids), not "some rows". |
| T03 formula | Every total, sub-total, grand total, weight/fine/amount column, rounding stage and sign convention, computed **by hand from the vouchers**, per mode. |
| T04 lookup | Party/item/book helps: F1, type-ahead, cancel, stale response. |
| T05 children | Grouping and drill-down: group headers, nested levels, zoom to the voucher (and to the ledger where the desktop has it), back. |
| T06 invalid | From > To date, a date outside the year, nothing selected, empty result: the desktop message or empty-grid behaviour, and no crash. |
| T11 scope/rights | A sentinel voucher in another company, location, year, book and tenant **never appears**, in the grid, the totals, the drill-down or the export. A user without Print cannot print; without List cannot list. |
| T15 history | Change a master (party name, item group) after the voucher; an older year; an edited and a deleted voucher; a cancelled tag: the report follows the desktop's rule (snapshot vs live master). |
| T16 output | On-screen grid, PDF, CSV/Excel, print window: same rows and totals as the grid, desktop column order and captions, named Crystal template (`*.rpt` in the repo root / `zip_contents/`, XML in `extraction_output/rpt_xml/`) reproduced semantically. Print windows must refresh the session (N173). |
| T17 keyboard | Run it with the keyboard only. |
| T18 journey | **The core of the report cases.** Create the source vouchers through their real screens in the same run (Sales, Purchase, Cash/Bank, Contra, Tag Opening, Approval, Order …, each already has a feature module you can copy setup from), run the report, reconcile to the hand-computed expectation; then **edit one voucher, delete one, cancel one tag, return one sale, and run it again**: the report must follow each step exactly. |

## Report implementation rules

- **Do not extend `app/(app)/reports/[report]/page.tsx`** (1,742 lines, at its size ceiling). Give the report its own
  route directory with a page ≤ 600 lines plus `types.ts`, a data hook and a grid component, exactly like
  `app/(app)/reports/account-ledger/` in PR #195 (`AccountLedgerGrid.tsx`, `useAccountLedger.ts`, `types.ts`). Register
  the API routes in a **new** file under `apps/api/src/routes/`, not in `routes/txn.ts` (8,360 lines, at its ceiling).
- If your report shares an engine with a sibling menu (several menus are the same desktop form with a different caption —
  `RP_ALL` serves Sales Report, Purchase Rpt and Approval Rpt), put the shared selector/filter/grouping code in a shared
  module and **say so in the PR**. If a sibling's PR already merged it, reuse it; do not copy it.
- Totals are computed once, server-side, with the same core kernels the voucher writers use. The grid never re-derives
  money client-side.
- Reports read through `withTenant`; every query is keyed by company, location, year (and book where the desktop does).
  Unscoped `SELECT` is a defect.
- A report's catalog row stays `REPORT` status in the catalog vocabulary until every case passes and no gap is open;
  then it becomes `FULL`. If the Crystal template is missing from the repository, the output case is **blocked with that
  reason** (and stays in the denominator), not N/A.
- Large results: the desktop loads everything; the web may page, but totals and the export must cover the **whole**
  result, and a test must prove it with more rows than a page.


==============================================================================================================

# Agent 04 — Report → Tag Stock   (Lite package L6)

**Type:** BUILD (report)  
**Suggested wave:** 1  
**Prompt generated against:** `origin/main` @ `3fd1adc3` (1–2 Nov 2026). Re-fetch and re-read the catalog row before you start; if `main` moved, trust `main`.

> Read `00-GENERIC.md` first and `00b-REPORT-ADDENDUM.md`. This file is the menu-specific part.

## Mission

Make Report → Tag Stock the desktop `RP_TAG` form: inward, outward, in-stock, MRP, approval-pending and all-tags tabs with desktop filters, columns, totals, sub-details and outputs.

## Identity and hand-offs

- **SLUG** `tag-stock`  **BRANCH** `feat/lite-tag-stock`  **worktree** `~/dc-wt/tag-stock`  **feature module** `tagStock`
- Isolated Compose project: `PARITY_TEST_PROJECT=dc-tag-stock` (ports come from the stack slot you take, see 00-GENERIC §2.1).

## Catalog facts (copied from `docs/handbook/menu-catalog.jsonl`; re-read the live row)

- **Desktop form(s):** `RP_TAG` — mode: constructor caption 'Tag Stock'
- **Menu dispatch:** `unified/src/csharp/DataCareNext/MDI_FORM.cs:8891-8900`
- **Tables:** `MAIN_STOCK`, `BAR_DETL`, `BAR_IDTL`, `APR_DETL`, `TAG_IMAGE_DATA`, `TAG_STOCK_PRINT`
- **Web routes:** `/reports/tag-stock`
- **API:** `GET /reports/tag-stock`, `GET /reports/tag-stock.csv`
- **Desktop rights:** `----PL` (rights string order = Create, Read, Edit, Delete, Print, List ("-" = the desktop menu does not offer that right))
- **Status:** `REPORT`  **Phase:** `P1-core`  **Owners (slices/gaps):** N24, X26, P10-04, N57, N75, G225, N212
- **Purpose:** Lists inward, outward, in-stock, MRP, approval-pending and all tags with totals.
- **Recorded gap:** Tabs and totals exist; date/tag/product/group filters, full columns and sub-details, Excel/PDF and Crystal layouts are incomplete.
- **Sources:** `unified/src/csharp/DataCareNext/RP_TAG.cs:3977-4325`

## Desktop pointers (start your study here)

- `RP_TAG.cs` is 10,813 lines; the catalog source range is `RP_TAG.cs:3977-4325`. Find the tab/mode radio handling and each query.
- Templates: `TagStkRpt.rpt`, `CntrTagStkRpt.rpt`, `CntrTagSumRpt.rpt`. Tag image: `TAG_IMAGE_DATA`.
- F3 in the desktop opens the Stock Report from many screens (KB_master); not yours — but do not break the shortcut contract.

## Current web state

- Page `app/(app)/reports/tag-stock/page.tsx` (209 lines) and API `GET /reports/tag-stock` + `.csv`.
- **The route `/reports/tag-stock` is also mapped to the Stock Report menu (agent 05).** The desktop has two different forms (`RP_STOCK` and `RP_TAG`); keep this page `RP_TAG` only and let agent 05 create a separate route.

## Scope — what you must deliver

- Tabs: inward, outward, in-stock, MRP, approval-pending, all. Filters: date, tag, product, group, plus any the source offers. Full column set and sub-details (stones/components). Excel/PDF/print, tag image.

## Case emphasis (on top of the T01–T18 expansion in 00-GENERIC §3 step 2)

- Build the tag universe through real screens: **Tag Opening**, a **Purchase** with tags, a **Sale** (tag goes outward), **Tag Cancel**, **Stock Adjust** (when #197 lands), an **Approval Isu** (pending) — then every tab reconciles to the hand count of pieces and weights.
- A cancelled tag leaves in-stock; a returned sale tag comes back; an approval-pending tag is not in-stock (verify against source).
- Pagination vs totals: totals cover all rows.

## Risks and traps

- Tag Cancel catalog row lists "the Tag Stock report check" as an open item — your cases close it; tell agent 22.

## Shared files you are likely to touch (expect merge conflicts here; regenerate generated files, do not hand-merge)

- `reports/tag-stock/*`
- `routes/txn.ts` (leave alone if the route already exists)

## Reminders

- Rebase on fresh `origin/main` and allocate `N###`/`G###` **last**, not first (00-GENERIC §3 step 6).
- Desktop match is 0%; say so. Do not mark the catalog row `FULL` unless every case passes and no gap is open.
- Finish with the final-report block from 00-GENERIC §5.
