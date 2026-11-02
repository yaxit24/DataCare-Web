# Handoff: Lite parity work (state at 2 Nov 2026, evening)

This note lets another session continue the Lite-first parity work without asking the previous session anything. It states the goal, the rules, the open work with exact branches, how each menu is taken to done, the test commands, and the traps found so far. The catalog (`docs/handbook/menu-catalog.jsonl`) and `execution-backlog.json` stay the status authority; this note is a guide, not a record.

## 1. Goal

Make the 49 Lite menus of the web app behave like the desktop (`unified/src/csharp/DataCareNext/*.cs`), then the 29 Basic menus, then the 36 Standard menus. Pro, Advance and Enterprise menus stay behind the edition gate and are never deleted. A menu is done when its catalog row is FULL and its feature module has no failing and no blocked case.

For each menu:

1. Read the desktop form. Cite it as `FORM.cs:line` in code comments, tests and the PR. Derive expected values from the desktop rules, never from web output.
2. Fix every defect found, including defects in shared code.
3. Add unit tests, a DB test through the real Fastify routes on forced RLS, and a zero-mock browser feature module covering T01-T18.
4. Check the visuals and keyboard in Chrome with the DevTools tools (snapshot and `evaluate_script`, no screenshots).
5. Open a small PR, wait for green CI, merge (squash).

## 2. Rules that cost time when missed

Read `AGENTS.md` first. The ones that bit this work:

- Never push to `main`; stage specific files; no force push, no amend; update a branch by merging `origin/main`.
- Tests run only on the isolated Postgres from `web/scripts/parity-test-env.mjs`. Desktop databases: aggregate queries only. DB tests scope every read by `tenant_id`.
- Plan IDs: before taking a G or N id run `git fetch origin` and look at every open PR diff:
  `for n in $(gh pr list --state open --json number --jq '.[].number'); do gh pr diff $n | grep -E '^\+(\| G[0-9]{3} \||### N[0-9]{3})'; done`.
  The PR that merges first keeps the id; the other renumbers. N and G ids must be contiguous and `startAfter` must name an existing slice, so PRs with new records merge one after another.
- Status lives only in `execution-backlog.json`. New Markdown must match a rule in `docs/handbook/doc-register.json` (`docs/handbook/web/*.md` already does). `docs_check` forbids Indian mobile numbers in docs.
- A behaviour change needs a browser-test change or a `Browser-Test-Exempt:` line in the PR body; a file listed in `coverage-map.json` needs a change to that module.
- Size budget: 1,500 lines per file, ceilings only fall. `web/apps/api/src/routes/txn.ts` is near its ceiling (8,360); put new routes in their own file and register them with one line.
- No new `Math.round` helpers (use `round` / `roundHalfEven` from `@datacare/core`).
- Every migration needs its sha256 in `web/apps/api/src/modules/ops/migrationManifest.ts` and in the Prisma model.
- Changing `web/docs/COMPLETION-REGISTER.json` means re-baselining its pinned sha256 in `docs/master-parity-plan-2026-09-29/requirement-index.json` (a dated `rebaselined` block that chains the previous one).
- Surface crawl: Save must be the only `button.primary`.
- Feature modules: every `mutation` case returns `downstream` evidence; refusal cases return `database`.
- Do not run parallel agents unless the owner asks. Keep browser checks short. Leave the foreign stash alone.

## 3. Who owns what (do not touch)

- The lane (same GitHub identity, "ysmtb") owns `dc-wt/feature-e2e` and `dc-wt/e2e-fixes`.
- `dc-wt/order-cancel` owns Order Cancel. `dc-wt/lite-approval` owns Approval Isu / Rtn.
- Web sessions own the 10 Lite Report-tab menus (#195 Ledger Report), #189, #202, #203, #204.
- Sales Return, Purchase Return and Wholesale Sale belong to other sessions. Their module edits made here were parked as patches (see section 5).
- The prompt pack `docs/agent-prompts/lite` (merged in #201) plans agents for 22 menus. Party (#200) and Tag Print (#208) are taken. Check the pack's README and dispatch table before starting a menu so nothing is duplicated.

## 4. Open work, exactly where it is

Worktree used so far: `/Users/yakshitsavaliya/dc-wt/kiro-impl`. Highest ids on main at the last fetch: N225 / G237.

| Item | Branch / PR | State |
|---|---|---|
| Party master (MS_ACCT), N224 / G236 | PR #200 | Merged. It renumbered from N223 / G235 when #195 (Ledger Report) merged first. |
| Tag Print (UT_TAG_PRINT), N225 / G237 | PR #208 | Merged after #200. It renumbered from N224 / G236. |
| Un-blocked browser cases and four defects, N227 / G238 | `feat/lite-unblock-cases`, PR from this branch | See section 6. |
| Sales Order old gold and old silver rows (G206 part) | PR #211 | Another session. It took N225 on a stale base and has to renumber. |
| Data Refresh (#209), Data Backup (#210), Purchase Report (#202), GST Report (#206), Approval In/Out (#203), Purchase whole rupees (#204) | other PRs | Other sessions; do not touch. |
| Data Import, Company, Year Create, Balance TrFr, Books, User Create | not started | Several are in the prompt pack (13-19). User Create is not in the pack: `usersRights` has 15 blocked cases. Check the open PRs first: Data Refresh and Data Backup are taken. |

PRs that carry plan records merge one after another, because N and G ids must be contiguous. Whoever merges second
merges `origin/main`, renumbers and waits for CI again; this cost a full CI cycle three times on 2 Nov.

## 5. Parked patches (not part of any branch)

In `/tmp/kiro-impl/patches/` (they may be gone; each is small and easy to redo):

- `purchase-return-t14-t15.patch`: a fault-injection case and a lock-date case for the Purchase Return module. The lock-date case found the central message bug (section 6).
- `sales-return-t14.patch`: a fault-injection case for Sales Return.

Give these to whoever owns those menus.

## 6. The `feat/lite-unblock-cases` work

Based on `origin/main` (merged up to #208). What it contains:

**Browser cases that were "blocked" and now run (all against the real stack):**

- `tag-cancel` T12 (two operators, one tag), T13 (replayed save), T14 (fault on `MAIN_STOCK` insert), T18 (cancelled tag leaves the available-tags lookup); T15 is `not-applicable` with the desktop reason (`TR_TAG_CAN.cs:2514-2535`, only the STOCK ADJUST book reads `MsPurcLot`). Result 16/16, 0 blocked.
- `daily-rate` T11 (a user without rights: read, print, delete, save all 403), T12, T13, T14, T18. Result 15 of 16; T15 (location 00 also sets `GROUP_MAST.GR_RATE`) stays blocked because the harness has no way to start a session at location 00.
- `purchase-invoice` T14 and T15 (`PR_AMT_TYPE=G` prices on gross weight; the setting is switched and restored). Result 29/29.
- `contra` T14 and T15 (lock date). Result 25/25.
- `cash-bank` T14. Remaining blocked: T03 (calculations), T06 (card and UPI settlement), T15 (employee mandatory, see below, now fixable and awaiting its browser case).

**Defects found by those cases and fixed:**

1. Daily Rate: two operators saving the same new day hit the `RATE_MAST` primary key and the screen showed raw database text. Saves of one day now take an advisory lock; the last writer wins (`web/apps/api/src/modules/masters/dailyRate.ts`). DB test fails on the old writer.
2. Rate lookup (`GET /rate`, behind the ticker): not scoped by location. `TR_SALE.cs:12547` filters `RATE_MAST` by `CO_CODE` and `LC_CODE`. Fixed in `web/apps/api/src/modules/masters/rate.ts`; the route moved to `web/apps/api/src/routes/dailyRate.ts` to keep `txn.ts` under its ceiling. DB test fails on the old code.
3. Lock date: `PeriodLockValidationError` carried a web-only message. It now carries the desktop text `You Cant Save and Delete This Voucher Becouse Lock Date is = dd/MM/yyyy ....` for every form that uses it (`web/apps/api/src/modules/posting/posting.ts`, unit test `periodLockMessage.test.ts`).
4. Cash Received / Payment: the Employee box was sent by the page but dropped by the API. The desktop stores it (`TR_CASH.cs:3050`), refuses a blank when `CO_SET.EMP_CODE_MANDATORY = 'Y'` (`:2907-2911`) and shows it when the voucher is opened (`:2753`). Fixed: `financeEmployeeTx` in `web/apps/api/src/modules/finance/lifecycle.ts`, `EMP_CODE` written to `CASH_DATA` and `PAY_DATA`, read back by `getReceipt` / `getPayment`, the route and `PaymentForm.tsx` pass and load it. DB tests added to `cashReceiptLegs.db.test.ts`; 24 of 24 pass together with the Daily Rate and lock-message tests. Not yet done: the browser case for it (cash-bank T15) and a Chrome pass. The desktop also defaults the box to the logged-in user's employee code (`:2671`); the web has no such field on the session yet.

**Done on this branch:** the cash-bank T15 browser case (blank employee refused with the desktop text and nothing written; the employee chosen is stored in CASH_DATA and shown when the voucher is opened; `CO_SET` and the temporary `EMP_MAST` row are restored in `finally`). Result: cash-bank 19 of 21 (T03 and T06 stay blocked). The modules cash-bank, tag-cancel, daily-rate, purchase-invoice, contra, sales-invoice and sales-order ran on a fresh build with no new failure (the sales-order old-metal case is the known G206 baseline). The full API suite (356 files, 3,789 tests), the web unit tests (713), the smoke test, the session-context and labour-preview checks and every gate in section 8 pass. The plan records are N227 / G238. No separate Chrome pass was made for the Employee box: the page change is two lines (send and load `empCode`) and the browser case drives it through the real UI.


## 7. How a menu is done (the loop)

1. **Study.** Read the form's `.cs` and its layout spec; write notes (what each key, box and message does, with line numbers). Check the prompt pack and the catalog row.
2. **Gap list.** Compare with the web page, API and tables. Record deliberate differences as a gap (G id) with the reason.
3. **API.** Put logic in `apps/api/src/modules/...`, routes in their own `routes/*.ts` file. Wrap DB work in `withTxBudget(prisma, tenantId, 'read'|'voucher', ...)`; map `*ValidationError` to 400 and `*VersionConflictError` to 409; mirror the desktop messages verbatim.
4. **Web.** Match the form spec's positions, tab order, keys (Enter, F1, Ctrl+D, Esc) and messages. Save is the only `button.primary`.
5. **Tests.**
   - Unit tests for the rules.
   - A DB test through the real routes (`app.inject`) on forced RLS, with a case that fails on the old writer.
   - A browser module in `apps/web/test/features/modules/`, registered in `run-features.mjs` and `coverage-map.json`. Use the helpers `C(id, group, kind, source, run)`. T11 rights use a second user; T12 a second slot (`as(user, '<user>#2')`); T13 replays with `page.request.fetch(response.request())`; T14 a plpgsql trigger that raises for a marker value (create it, run, drop it in `finally`); T15 a company setting switched on `CO_SET` / `CO_SET_NEW` and restored (if a row may already exist, update and restore it; do not insert blindly).
6. **Chrome pass.** Start the demo stack, seed data, drive the screen with keys, and measure with `evaluate_script`. Key delivery lags: send a harmless `Shift` to flush, or dispatch `KeyboardEvent`s in the script.
7. **Records and gates**, then the PR.

## 8. Commands (run from `web/` unless stated)

- Build everything: `API_ORIGIN=http://127.0.0.1:4510 pnpm build`. One package: `pnpm --filter @datacare/{core|db|api|web} build`. After merging main, rebuild core and db first. After switching branches, rebuild before any browser run (a stale `.next` served old pages once; that was N186).
- Typecheck: `pnpm --filter @datacare/api exec tsc --noEmit -p tsconfig.json`; for web, `rm -rf apps/web/.next/types` first.
- DB tests: `PARITY_TEST_PORT=55535 RUN_DB_INTEGRITY_TESTS=1 node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/<file>` (run from `web/`, not from `apps/`).
- Feature modules: `PARITY_TEST_PORT=55533 PARITY_API_PORT=4510 PARITY_WEB_PORT=4511 FEATURE_E2E_MODULES=<name,name> node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs`. Results: `test-results/feature-e2e/<module>/run.json`. Module names are the `feature:` value in the module file (for example `settings`, not `settings-effects`). Failure messages in the log show only the first line; read `run.json` or add the body to the assertion message.
- Surface crawl: add `SURFACE_ROUTES=/path` and run `web/apps/web/test/features/run-surface.mjs` the same way.
- Lifecycle checks: `web/apps/web/test/session-context.real-stack.additive.mjs` and `labour-preview-lifecycle.real-stack.mjs` (with `LABOUR_PREVIEW_ARTIFACT_DIR=<dir>`), both through `parity-test-env.mjs`.
- Gates: `pnpm lint`, `typecheck:tests`, `format:check`, `size:budget`, `depth:parity`, `depth:deadcells`, `test:routes`, `settings:parity`, `runtime:check`, `docs:refs`, `register:check`; `node scripts/check-kernel-conformance.mjs`; `node scripts/generate-edition-table.mjs --check`; `pnpm progress` then `node scripts/generate-standard-progress.mjs --check`; `pnpm parity:measure --reuse`. From the repo root: `python3 docs/master-parity-plan-2026-09-29/validate_plan.py` and `python3 docs/tools/docs_check.py --write`. Browser-test gate: `PR_BODY="$(cat body.md)" node scripts/check-browser-test-coverage.mjs --base origin/main --head HEAD`.
- Demo stack: `/tmp/kiro-impl/restart-demo.sh [--no-build]` (ports API 4510, web 4511, DB 55533; it may be gone, in which case use `parity-test-env.mjs` to start a database and run `web/apps/web/test/features/serve.mjs`). Restarting resets its data. Stop it before a feature run: kill the listeners on 4510 and 4511.
- Chrome: DevTools MCP page id changes; log in by navigating to `/login`, filling the demo credentials with the React-safe native setter through `evaluate_script` (a login script from the G179 pass was kept locally under test-results and is not in the repository), then clicking Sign In.
- Merge: `gh pr merge N --squash --subject "<title> (#N)"`.

## 9. Traps already met

- The route-count test scans route files for **literal** paths. A route registered with a variable or template path is not counted and is not checked by the policy scan. Write the full literal string.
- A query parameter named `book` triggers the session book-scope guard; use another name (`bookCode`).
- After merging main: regenerate `pnpm progress` and the standard-progress page rather than merging them by hand. Usual conflicts: `txn.ts` imports and registrations (keep both), the `routePolicy.test.ts` route count (main's count plus yours, keep the comment lines), `migrationManifest` (both entries, name order), `coverage-map.json` (rebuild from main's JSON plus your entry, then prettier), doc 12 / backlog / catalog (rebuild from main plus your records).
- Modules run in one database in CI: another module can leave rows behind (`CO_SET_NEW`, `RATE_MAST`). Cases must tolerate existing rows and clean up their own.
- `EMP_CODE` columns are `varchar(3)`: a longer test code fails the insert. Put a case's setting changes inside the `try` that restores them; a failed setup before the `try` left `EMP_CODE_MANDATORY = Y` on and broke the later cases of three modules.
- Register a new route file in `web/apps/api/src/routes/masterScreens.ts` (masters) or beside it in `web/apps/api/src/routes/txn.ts`; one line, no new import block.
- `docs_check` wants cited paths repo-relative (`web/apps/api/src/...`), not relative to `web/`.
- Real-stack CI takes about 20 minutes; `quality` about 15. Reproduce locally with the same module order before blaming a flaky run.

## 10. Next steps, in order

1. Merge this branch's PR when green (renumber N227 / G238 if another PR with records merges first).
2. User Create (MS_USER, 5,312 lines; module `usersRights` has 15 blocked cases).
3. The company utilities and Data Import that the prompt pack has not yet had picked up (check which of 13-19 are claimed first; Data Refresh and Data Backup are open PRs).
4. Remaining blocked cases in older modules: daily-rate T15 (needs a location-00 session in the harness), cash-bank T03 / T06, tag-opening, fine-jv, party-opening, item-opening, company-open, settings.
5. Give the parked patches (section 5) to the sessions that own Sales Return and Purchase Return.
6. Mark a catalog row FULL only when every desktop mode, the lifecycle and print exist and its module has no failing or blocked case; then `pnpm progress`.
7. Final report: FULL counts out of 49, 78 and 114; test results; the extra pages and code found (the removed fake Stock Adjust writer, the old Tag Print routes, the generic Party page, the employee box that was dropped); readiness per edition; end with every steering note verbatim.

## 11. Steering notes to end the final report (verbatim)

- `[STEERING steer-f255cb97071943069e1d276d3aae46f0: Kept working slice after slice without stopping: merged N169, N171, N172, N173, N174, N175, N168, N165, N186, N51 (sales and purchases), N56, N176 and the cash-and-bank module, and opened the Contra grid rework (#166), each with unit, DB and browser tests and green CI.]`
- `[STEERING steer-ccbc6890c49a49d5b022744f96c0f3d4: Used Docker for every isolated Postgres test database and the local demo stack, and the local Chrome (DevTools) to check the voucher number keys, the printed HSN table and the dates; the Chrome check found that a rebuilt checkout served stale pages, fixed as N186 (G197).]`
- `[STEERING steer-3965cfc4294444f491efd69c03b675f0: Gave the progress numbers by tier from the generated progress page and test runs, and estimated the remaining time from the pace of the last three days (Lite about 3–4 weeks, all of Standard about 9–11 weeks). Then kept working: finished and merged #169 and set up the next Lite masters.]`
- `[STEERING steer-7ea3422cd21d4203b7f673500aa51296: Kept working without stopping toward Lite parity with in-depth checks: confirmed #172 and #173 mergeable with green CI, then rebuilt Item Opening as the desktop TR_ITM_OPBL grid (shared calculation in core, book-000 API with ITOBL stock rows and version tokens, the 17-column keyboard grid) and verified it with 8 unit tests, 8 DB tests, an 18-case browser module (17 pass, rollback blocked) and a Chrome pass that found and fixed three keyboard defects (PR #179, renumbered N209/G222 after #178 took N208/G221); then added the tag grid's karigar weight block (N204/G217, PR #181) with 9 unit tests, a DB case that fails on main's writer, a new browser case and a Chrome save/reopen/delete pass.]`
- `[STEERING steer-ee28b1b6811e419caf280d405be06c2d: Resolved #172's new merge conflict (merged main, kept both doc-12 sections, dropped the two fixed baseline entries, re-verified locally); its CI went green and it merged. For #177, traced the failed CI run to the depth-gate ceiling, confirmed the lane's next commit fixes it, and it merged. Then continued Lite work: PR #179 (Item Opening) and PR #181 (karigar weight block), with #181's dead-cell CI failure fixed and pushed.]`
- `[STEERING steer-e4fc649ea6344adfb098410f8517d1c3: Stopped to answer the status question. Reported the merged PRs (#190, #192), the local slices (Auto Item, Item master, the Stock Adjust rebuild) with their test results, the Docker outage that broke the Item browser run, and the next four steps in order.]`
- `[STEERING steer-2da03d54b21f4fc7afd5e39b6c302bb8: Wrote this handoff note (goal, rules, ownership, exact branch and PR state, the working loop, test commands, traps, ordered next steps) and pushed the unfinished work to its own branch so another session can continue it.]`
