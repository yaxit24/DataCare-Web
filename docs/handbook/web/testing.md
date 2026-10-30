# Testing handbook

How the web application is tested, what each kind of test proves, how to run it, and the protocol for checking
screens in a real Chrome browser with the Chrome DevTools MCP. Acceptance itself (desktop comparison, operator
sign-off, release certification) is defined in [document 04](../../master-parity-plan-2026-09-29/04-verification-playbook.md);
this page is the engineering side that every slice must satisfy first.

## 1. Test tiers

| Tier                                         | Where                                                          | Size (1 October)                               | Proves                                                                                                                   | Does not prove                          |
| -------------------------------------------- | -------------------------------------------------------------- | ---------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ | --------------------------------------- |
| Kernel unit                                  | `web/packages/core/test/`                                      | 32 files, 1,737 tests                          | Formulas and state transitions for given inputs, including rounding stages                                               | That a screen or writer uses the kernel |
| API unit                                     | `web/apps/api/test/*.test.ts`                                  | part of 290 files                              | Route classification, validation, policies and module logic with in-process Fastify `inject()`                           | Database effects                        |
| API database                                 | `web/apps/api/test/*.db.test.ts`                               | 174 of the 290 files; 3,349 API tests in total | The complete write set of a voucher on a migrated PostgreSQL with the non-owner role and forced RLS; rollback; isolation | Browser behaviour                       |
| Web unit and protocol                        | `web/apps/web/test/*.test.ts`                                  | 40 files, 594 tests + 6 protocol tests         | Helpers, adapters, keyboard and context protocols                                                                        | Integrated business behaviour           |
| Mocked browser smoke                         | `web/apps/web/test/browser.smoke.mjs`                          | —                                              | UI interaction depth against stubbed routes                                                                              | Anything about the API or data          |
| Route reachability                           | `pnpm test:routes`                                             | 239 routes in the last crawl                   | Every page renders for a signed-in user                                                                                  | Correct content                         |
| Zero-mock journeys                           | `web/apps/web/test/parity.real-stack.mjs` + 27 `*.journey.mjs` | 25 journeys, plus two optional runners         | Production Next build → real Fastify → migrated PostgreSQL, driven only through the screen, no request interception      | Desktop equality                        |
| Desktop differential (G5)                    | `web/scripts/check-g5-parity.mjs`, `web/apps/api/integration/` | 0 of 70 cases match today                      | Web write sets equal desktop write sets for replayed desktop vouchers                                                    | Screen behaviour                        |
| Visual and interactive (Chrome DevTools MCP) | §5 below                                                       | Manual or agent-driven, per changed screen     | Layout regions, field order, focus, console and network health, print preview, compared with tutorial keyframes          | Business data correctness on its own    |

A slice is engineering-complete only when the tiers that apply to it are all green (document 11 §7 and
[engineering standards](engineering-standards.md)).

## Feature-level validation requirement

Before claiming a feature works, use the [feature browser validation skill](../../../.kiro/skills/datacare-feature-browser-validation/SKILL.md). It turns the applicable T01–T18 groups into a frozen, feature-specific matrix, drives the real UI, checks intermediate values, complete persisted effects and downstream reports, and exercises stale edits, retries, refusals and rollback. Missing implementation is a failure or blocker, never N/A.

Retain exact case identities and candidate/input hashes with screenshots/traces and independent expectations; run the skill’s evidence validator. Report executed coverage, browser/business pass coverage and independent desktop-match coverage separately. Blocked and untested applicable cases stay in the denominator. The validator checks bundle integrity, not artifact truth; it cannot replace browser execution or evidence review. Existing journey titles and suite totals are not proof that every branch ran. Physical device/provider acceptance and parent release acceptance remain separate.

## 2. Commands

Run from `web/` unless noted.

| Command                                                                                                             | What it runs                                                                                                                                                                                                           |
| ------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `pnpm build`, `pnpm typecheck`, `pnpm lint`, `pnpm format:check`                                                    | Build, type check, lint (policy, ESLint, types) and formatting                                                                                                                                                         |
| `pnpm test`                                                                                                         | All unit tests through Turbo; fails if no database is reachable, unless `ALLOW_SKIP_DB_TESTS=1` is set explicitly                                                                                                      |
| `pnpm typecheck:tests`                                                                                              | Strict compile of API and kernel test sources                                                                                                                                                                          |
| `pnpm test:parity:api`                                                                                              | The isolated database wrapper (`web/scripts/parity-test-env.mjs`: a fresh database on `PARITY_TEST_PORT`, default 55433, with migrations, non-owner role and forced RLS, removed afterwards) around the full API suite |
| `pnpm test:parity:browser`                                                                                          | The same wrapper around the zero-mock browser suite; the web app must have been built with `API_ORIGIN=http://127.0.0.1:4410` (or the `PARITY_API_PORT` in use)                                                        |
| `pnpm test:browser`, `pnpm test:routes`                                                                             | Mocked browser smoke; route reachability                                                                                                                                                                               |
| `pnpm docs:refs`                                                                                                    | Citations and pinned claims in `web/docs`                                                                                                                                                                              |
| `pnpm depth:parity`, `pnpm depth:deadcells`                                                                         | Reachable operator depth ratchet; grid cells that no writer consumes                                                                                                                                                   |
| `pnpm settings:parity`, `pnpm schema:readiness`, `pnpm fresh:provision`, `pnpm type:parity`                         | Setting exposure, desktop column presence, schema and RLS replay from empty, SQL Server/PostgreSQL type parity                                                                                                         |
| `pnpm report-baselines`, `pnpm g5:parity`, `pnpm register:check`                                                    | Report layout drift, desktop evidence gate, completion register                                                                                                                                                        |
| `python3 docs/tools/docs_check.py`, `python3 docs/master-parity-plan-2026-09-29/validate_plan.py` (repository root) | Documentation hub and plan integrity                                                                                                                                                                                   |

**Isolation (N49).** Each checkout gets its own Compose project (a hash of its path; override `PARITY_TEST_PROJECT`)
and its own random credentials in `~/.cache/datacare-parity-test/` (override `PARITY_TEST_STATE_DIR`), outside the
repository. Every run starts from an empty volume and ends with `down --volumes`, also on failure; `PARITY_TEST_KEEP=1`
keeps the database for inspection, and `node scripts/parity-test-env.mjs --down` removes one left running. Two
worktrees run at once on different ports: set `PARITY_TEST_PORT` (database, default 55433) and, for the browser
suites, `PARITY_API_PORT` and `PARITY_WEB_PORT` (defaults 4410 and 4411) and build the web app with the matching
`API_ORIGIN`, which Next fixes at build time. The wrapper hands the command the container ID and the server's
`pg_control_system()` system identifier and fails the run if either changed by the end;
`web/apps/api/test/globalSetup.ts` refuses any database that is not loopback, on the isolated port, the same for both
URLs, logged in as `app_user` without superuser or BYPASSRLS, and (under the wrapper) the server it started. The CI
job `real-stack-browser` runs the three zero-mock suites this way on every pull request.

## 3. Write-set database tests

Every writer change needs a database test that compares the **complete** write set, not selected columns.

1. Use a tenant ID unique to the test file, call `assertIsolatedTestDatabase()`
   (`web/apps/api/test/support/isolatedDatabase.ts`) before touching the database, wipe that tenant's rows before and
   after, and seed with `seedCompany`
   (`web/apps/api/src/modules/ops/seedCompany.ts`). Master rows the scenario needs may be inserted through the owner
   connection with bind parameters; **the voucher under test is always created through its route** with
   `app.inject()`. `web/apps/api/test/purchaseReturnLifecycle.routes.db.test.ts` is a complete example.
2. Capture the voucher's rows with the shared helpers: `footprintOf` and `ledgerLegs` in
   `web/apps/api/test/support/footprint.ts`, and `snapshotTenant` / `diffTenant` in
   `web/apps/api/test/support/tenantSnapshot.ts` to prove nothing else changed. The tables to cover are the form's
   `tablesWrittenCatalog` in `docs/master-parity-plan-2026-09-29/desktop-form-reference.json`.
3. Assert header, detail, sub-detail, `AC_DATA`, `ROJ_MEL_DATA`, `MAIN_STOCK`, `TAX_DATA`, `BILL_OS_DATA`,
   `TEMP_BOOK_DATA` and audit rows field by field, with expected values derived independently from the desktop source
   or a captured desktop row (kept as an `*.independent.json` fixture in `web/apps/api/test/fixtures/`), never copied
   from the web output.
4. Reopen, save unchanged, and assert nothing changed (T08). Edit one field and assert only its effects changed (T09).
   Delete and assert full reversal plus the `DELETE_DATA` row (T10).
5. Plant a sentinel voucher in another company, location, year and tenant with the same visible number, and assert it
   is untouched (T11).
6. Make a deliberately broken variant (drop one leg, change one sign) and confirm the test fails.

The global setup (`web/apps/api/test/globalSetup.ts`) enables database tests whenever a database is reachable and
fails instead of skipping when none is, unless `ALLOW_SKIP_DB_TESTS=1` is set explicitly.

## 4. Zero-mock browser journeys

- **Harness.** `web/apps/web/test/parity.real-stack.mjs` builds nothing itself: it expects a production build, starts
  the API and web app against the isolated database, logs in through the real login page, and runs each journey with
  Playwright. It records every request and fails if any request was intercepted or mocked.
- **Writing a journey.** One file `web/apps/web/test/<name>.journey.mjs` exporting a function that receives the page,
  the SQL client and the fixture helpers. Drive the screen only (labels, roles, keyboard), read results back from the
  screen and from the database, clean up its own fixture rows, and add the journey to the list in
  `parity.real-stack.mjs` (lines 655–678 on 1 October).
- **What a journey must cover** for a voucher screen: create, print, reopen, edit, save unchanged, delete, and one
  refusal (invalid input or stale version), plus the effect on at least one related report.
- **Current journeys (25):** cash-receipt-payment, column-settings, credit-note, credit-note-entry, e-invoice-entry,
  design-book, design-calculations, design-repeat, generic-image-conflict, image-conflict, manufacturing-lot,
  order-images, purchase-return, repair-image-conflict, sale-amount-basis, sales-order, sales-order-design,
  sales-return-bill-replay, sales-return-labour-replay, sales-return-replay, sales-return-saved, tag-cancel-transfer,
  tag-split, tour-order, wholesale-rate-cut. Optional runners: `session-context.real-stack.additive.mjs` and
  `labour-preview-lifecycle.real-stack.mjs`.
- **Hermetic seeds:** every journey seed `UPDATE` is an upsert or an asserted row count, and a static test fails on
  any other (G23, N49 steps 1–2). The suite runs from an empty volume in the CI job `real-stack-browser`.

## 4a. Feature E2E suites (per-feature, all T01–T18 cases)

The journeys above each prove one workflow. The feature suites under `web/apps/web/test/features/` prove one
**feature** completely: every applicable T01–T18 group of
[the verification playbook](../../master-parity-plan-2026-09-29/04-verification-playbook.md) expanded into
source-backed cases — happy paths, lifecycle (create → reopen → unchanged save → edit → delete → print),
dissimilar lines, tax and tender branches, refusals with no-write proof, rights, two-operator conflicts,
duplicate submission, keyboard, downstream reports.

| File                                                | Role                                                                                                                                                                                                                                                                                                                                           |
| --------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `web/apps/web/test/features/harness.mjs`            | Boots the same zero-mock stack as the journeys (disposable DB, in-process API as `app_user`, production Next, Chromium); one real login per user slot, reused through saved browser state because `/auth/login` is limited to 10 per minute; per-case screenshots, API request log, console errors; evidence bundle                            |
| `web/apps/web/test/features/fixtures/catalogue.mjs` | Sample data. The base company comes from the real `seedCompany` provisioning; packs add items, groups, local/inter-state parties, bank account, opening stock, an admin and a restricted clerk, a historic year and a second-tenant sentinel voucher. Masters and sentinels only — the voucher under test is always created through the screen |
| `web/apps/web/test/features/modules/<feature>.mjs`  | The frozen matrix for one feature. Each case cites its desktop source and computes its expected values by hand; mutations read back the database and a downstream screen                                                                                                                                                                       |
| `web/apps/web/test/features/baseline.json`          | Known failures, each with a gap id. Shrink-only                                                                                                                                                                                                                                                                                                |
| `web/apps/web/test/features/run-features.mjs`       | Runs the modules, writes `test-results/feature-e2e/<feature>/{matrix,run}.json`, checks each bundle with the evidence-contract validator and applies the baseline gate                                                                                                                                                                         |

```bash
cd web
API_ORIGIN=http://127.0.0.1:4410 pnpm --filter "@datacare/web..." run build
node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
# one module or a few cases while working on them:
FEATURE_E2E_MODULES=sales-invoice FEATURE_E2E_CASES=sales-invoice.print.pdf \
  node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
```

**Gate.** Every applicable case must pass, except the cases in `baseline.json`. A new failure fails the run,
and so does a baseline entry whose case now passes: remove it in the change that fixed it. Blocked cases need a
reason in the module and stay in the denominator; the run prints executed, browser-pass and desktop-match
coverage separately, as the [evidence contract](../../../.kiro/skills/datacare-feature-browser-validation/references/evidence-contract.md)
requires. The CI step runs inside the `real-stack-browser` job.

**Rule for every feature slice.** A slice that adds or changes a screen's behaviour also adds or updates that
feature's module in the same PR: new cases for the new branch, an updated expected value when the desktop rule
was misread, and the baseline entry removed when a defect is fixed. A defect the suite finds is recorded as a gap
(doc 12) and enters the baseline; it is fixed in its own slice, never by weakening the case. A case may only become
blocked or N/A with a recorded source-backed reason.

The rule is enforced. The static-gates job runs `web/scripts/check-browser-test-coverage.mjs` on every pull request:
a PR that changes a page, component, web library, API module, route or core calculation must change a browser test
(a feature module or baseline, a journey, or the surface baseline). A file listed in
`web/apps/web/test/features/coverage-map.json` must change the feature module that covers it. A change with no
browser-visible effect states why in the PR body with a line `Browser-Test-Exempt: <reason>`; the reason is printed
in the CI log. Run it locally with `node scripts/check-browser-test-coverage.mjs --base origin/main`.

## 4b. UI surface crawl (every page, every button)

`web/apps/web/test/features/run-surface.mjs` logs in and visits every route an operator can reach: every sidebar link
in `web/apps/web/lib/nav.ts` and every page under `web/apps/web/app` that the menu does not link. On each page it
records the heading, every control in the content area and the API calls made on load, then runs three probes:
load voucher 99999 where the page has a voucher-number Load, press the main action on the empty form, and for a
report press Run and Download PDF. With `SURFACE_SWEEP=1` it also presses every distinct button and records what
happened: navigation, popup, download, dialog, a read or write request and its status, a screen change, or nothing.
Buttons that would change data other pages depend on (delete, renumber, year end, provision, reset) run in a last
pass of their own, and pages that change company-wide state run last.

| Finding                                                                                                | Severity | Meaning                                                                                                                                     |
| ------------------------------------------------------------------------------------------------------ | -------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| `page-crash`, `server-error`, `session-lost`, `load-failed`                                            | high     | The page or an action crashed, answered 5xx, or ended the session                                                                           |
| `load-refused`, `silent-refusal`, `no-feedback`, `empty-form-accepted`, `console-error`, `placeholder` | medium   | A refusal the operator cannot see, an action with no response, a create from an empty form, a script error, or a planned-screen placeholder |
| `no-visible-effect`, `no-heading`, `load-refused-by-design`                                            | low      | Recorded in the map for review; not gated                                                                                                   |

`web/apps/web/test/features/surface-baseline.json` lists known defects (`findings`, each with a gap id) and findings
proved to be the desktop's own behaviour (`byDesign`, each with its source). The gate is shrink-only, like the
feature baseline. CI runs the probes on every pull request (the button sweep takes longer and runs locally). The
committed map is `docs/handbook/web/ui-surface-map.md`, regenerated from a full sweep:

```bash
SURFACE_SWEEP=1 SURFACE_WRITE_DOC=1 node scripts/parity-test-env.mjs -- node apps/web/test/features/run-surface.mjs
```

A `WORKS` verdict means only that the page behaved; it does not mean desktop parity. The map shows parity separately:
the desktop menu-catalog status of each route and whether a journey or feature module proves its lifecycle.

## 5. Visual and interactive verification with Chrome DevTools MCP

Automated journeys prove behaviour; this protocol checks what an operator sees and touches. Run it for every screen a
slice changes, and attach the summary to the pull request. It follows decision D20: layout parity is **semantic**
(regions, field order, captions, grid columns, focus order), not pixel-exact.

### 5.1 Set-up

1. Build and start the stack against the isolated database (§2), or use the demo seed on a throwaway database
   (`SEED_DEMO`, `DEMO_PASSWORD` and `APP_TENANT_ID` set; never a database with customer data).
2. Start Chrome with remote debugging on port 9222 and a **dedicated profile**, never the everyday profile. On the
   maintainer's machine this is `~/.kiro/bin/kiro-chrome.sh`; check it with `curl -s http://127.0.0.1:9222/json/version`.
3. Other sessions may share that Chrome. Open your own tab in an **isolated context**:
   `new_page` with `isolatedContext: "datacare-<slice>"`. Note the page ID and pass it to every later call. Never
   reuse or navigate another session's tab.
4. Set the viewport you are testing: `emulate` with `viewport: "1366x768x1"` (the desktop reference size) and, for
   responsive checks, `"1920x1080x1"` and a tablet size.

### 5.2 Per-screen procedure

| Step                                               | Tool                                                                                                                                                                                                                       | Check                                                                                                                                                                                                       |
| -------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1. Log in through the real page                    | `navigate_page`, `take_snapshot`, `fill_form`, `click`                                                                                                                                                                     | Login succeeds; the company, location and year selector appears                                                                                                                                             |
| 2. Choose the scope                                | `take_snapshot`, `click`                                                                                                                                                                                                   | The shell shows the chosen company, location and year                                                                                                                                                       |
| 3. Open the screen from the navigation, not by URL | `click` on the navigation entry                                                                                                                                                                                            | The book chooser behaves like `CurBookHelp`: one book is auto-selected, several give a choice, none gives a clear error                                                                                     |
| 4. Read the screen structure                       | `take_snapshot` (accessibility tree)                                                                                                                                                                                       | Regions, field labels and order, grid column headers and order match the desktop form; save the snapshot to a file                                                                                          |
| 5. Compare with the desktop                        | Open the matching tutorial keyframe (`project-memory/video-research/<playlist>/<video>/keyframes/kf_NNN.jpg`, found through `project-memory/video-research/_kb/KB_*.md`) and the form layout in `web/apps/api/form-specs/` | Same regions and field order, same captions (allowing reviewed translations), same grid columns; record each difference as accepted (D20) or a defect                                                       |
| 6. Keyboard flow                                   | `press_key` (`Enter`, `Tab`, `F1`, `F2`…`F12`, arrows), `take_snapshot` after each                                                                                                                                         | Enter moves to the next field in desktop order; F1 opens the lookup; grid keys add and remove rows; focus never gets lost                                                                                   |
| 7. Enter a voucher                                 | `fill`, `fill_form`, `click`, `wait_for`                                                                                                                                                                                   | Calculated fields (fine, labour, tax, totals) update as on the desktop for the same inputs                                                                                                                  |
| 8. Network health                                  | `list_network_requests`, `get_network_request` on each mutation                                                                                                                                                            | Every call is to `/api`; no 4xx or 5xx except deliberate refusals; mutation bodies carry no company, location or year that the server should own; responses carry the expected version token once N51 lands |
| 9. Console health                                  | `list_console_messages` (types `error`, `warn`)                                                                                                                                                                            | No errors and no React warnings; record anything else                                                                                                                                                       |
| 10. Save, print, reopen                            | `click`, `wait_for`, `take_screenshot`                                                                                                                                                                                     | Save confirms with the voucher number; print preview shows the selected copies with correct copy labels and a four-digit year; reopening shows every saved value                                            |
| 11. Refusals                                       | invalid input, a stale second tab                                                                                                                                                                                          | A 400 shows field-level messages; a stale edit shows a conflict, not a silent overwrite                                                                                                                     |
| 12. Accessibility                                  | `lighthouse_audit` with `mode: "snapshot"`                                                                                                                                                                                 | No new accessibility failures on the changed screen                                                                                                                                                         |
| 13. Evidence                                       | `take_screenshot` with `filePath`                                                                                                                                                                                          | Screenshots of the initial screen, the filled voucher, the print preview and each refusal                                                                                                                   |

### 5.3 Evidence

- Save screenshots and snapshots under `web/test-results/visual/<slice>/` (git ignores `test-results/`). Do not
  commit images of customer data.
- Put a short summary in the pull request: screens checked, viewport, keyframes compared, differences with their
  disposition, console and network results.
- A difference that is not an accepted adaptation becomes a gap in the plan (document 12 §8), not a silent note.

### 5.4 Pitfalls

- An `evaluate_script` error "execution context was destroyed" usually means a navigation happened; take a new
  snapshot.
- `fill` on a controlled input that keeps its old value: click the field, select all with `press_key`, then type.
- Use the snapshot `uid` values from the **latest** snapshot only; they change after every render.
- Stop Chrome or close your isolated page when finished; port 9222 gives full control of that browser to any local
  process.

## 6. Business journeys J01–J28: current coverage

Journeys J01–J28 are defined in [document 04 §4](../../master-parity-plan-2026-09-29/04-verification-playbook.md).
This table maps each to the zero-mock journeys that exist today and lists what must be added. "Engineering" means the
browser journey exists; desktop comparison and business sign-off are still required for every row.

| Journey                                         | Existing zero-mock coverage                                                                              | Missing — journey to add                                                                                              | Owners             |
| ----------------------------------------------- | -------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | ------------------ |
| J01 Fresh business setup to first transaction   | None (the audit did it manually)                                                                         | `fresh-company-setup`: provision through the wizard or UI, masters, opening, first purchase and receipt, two sessions | N58, N49           |
| J02 Purchase, tags, supplier payment and return | None                                                                                                     | `purchase-lifecycle`, `purchase-return`                                                                               | N32, N34, N63, N64 |
| J03 Old metal and hallmark purchase             | None                                                                                                     | `hallmark-purchase`, `urd-purchase`                                                                                   | N32, X12           |
| J04 Retail sale with mixed tender and credit    | sale-amount-basis (partial)                                                                              | `retail-sale-lifecycle`: tagged and loose lines, mixed tender, outstanding, edit, conflict                            | N40, N63, X13      |
| J05 Wholesale, labour and fine sale             | wholesale-rate-cut (partial)                                                                             | `labour-sale`, `fine-sale`                                                                                            | N45, N67, N17      |
| J06 Saved incoming return                       | sales-return-saved, -replay, -bill-replay, -labour-replay; labour-preview runner                         | — (engineering covered)                                                                                               | X13                |
| J07 Return, exchange and credit note            | credit-note, credit-note-entry (partial)                                                                 | `sales-return-full`: complete return with refund and exchange                                                         | X13, N50           |
| J08 Quotation, order, advance, fulfilment       | sales-order, sales-order-design, order-images, design-book, design-calculations, design-repeat (partial) | `quotation-to-order-to-sale`                                                                                          | N44, N46           |
| J09 Approval and consignment                    | None                                                                                                     | `approval-issue-return-bill`, `consignment`                                                                           | N22                |
| J10 Tour, order tour and parcel                 | tour-order (partial)                                                                                     | `tour-sale` (after N70), `vp-parcel`                                                                                  | N22, N70           |
| J11 Repair intake to delivery                   | repair-image-conflict (images only)                                                                      | `repair-chain`                                                                                                        | N22                |
| J12 Cash, bank, journal, bill allocation        | cash-receipt-payment (partial)                                                                           | `receipt-payment-lifecycle` (after N64), `bill-to-bill`                                                               | N64, N68           |
| J13 Bullion booking and rate cut                | wholesale-rate-cut (partial)                                                                             | `bullion-booking-sale`                                                                                                | N45, X16           |
| J14 Tag transfer and cancellation               | tag-cancel-transfer                                                                                      | — (engineering covered)                                                                                               | N18                |
| J15 Tag split and weight replacement            | tag-split                                                                                                | `tag-weight-change` (after containment is lifted)                                                                     | N19                |
| J16 Physical stock                              | None                                                                                                     | `physical-stock-session`                                                                                              | N20                |
| J17 Manufacturing lot issue and receipt         | manufacturing-lot (browse)                                                                               | `mfg-lot-issue-receive`                                                                                               | N21, N71           |
| J18 Order-linked job work and melting           | None                                                                                                     | `jobwork-melting`                                                                                                     | N71, X23           |
| J19 Dhiran and loans                            | None                                                                                                     | `dhiran-issue-interest-release`, `loan-cycle`                                                                         | N65                |
| J20 Membership, instalments, maturity, points   | None                                                                                                     | `scheme-cycle`, `points-earn-redeem`                                                                                  | N66, N53           |
| J21 Settings and mode sweep                     | column-settings; session-context runners (partial)                                                       | `settings-sweep` per high-impact setting                                                                              | X08, N77           |
| J22 Report and print universe                   | Route crawl renders every report (rendering only)                                                        | `report-print-wave-a` per bound template                                                                              | N57, N74, N75      |
| J23 Corrections, imports, renumber, transfer    | None                                                                                                     | `utilities-guarded`                                                                                                   | N26                |
| J24 Devices, providers, asynchronous context    | session-context, generic-image-conflict, image-conflict (partial)                                        | `device-scale-camera-label` (manual matrix), `provider-sandbox`                                                       | N25, N54           |
| J25 Migration and historical business day       | None                                                                                                     | `migration-rehearsal-day`                                                                                             | N78, N79           |
| J26 Recovery, outage and upgrade                | None                                                                                                     | `restore-drill-day`                                                                                                   | N80, N28           |
| J27 Whole normal and exception days             | None                                                                                                     | `business-day-<role>` per role                                                                                        | N29                |
| J28 Final release and stabilisation             | None                                                                                                     | Release certifier run on one candidate                                                                                | N82, N30           |

Order of work: J01, J02, J04, J12 and J07 first (they cover the daily cycle of a typical shop), then the remaining
P1-core journeys, then edition journeys, then J25–J28.

## 7. Desktop differential

- `web/apps/api/integration/parity-replay-generic.mjs` replays captured desktop vouchers through the web writers and
  compares the resulting rows with the desktop rows. Today it has builders only for purchase, sales and rate cut, and
  four known input defects (G69, N83).
- The G5 job in `.github/workflows/ci.yml` runs it on `main` against the desktop SQL Server snapshot and is not yet
  blocking (0 of 70 cases match). Making it blocking is part of N82.
- Desktop databases are queried with aggregate queries only; one holds real customer data.

## 8. Rules that keep tests trustworthy

1. Derive expected values independently (desktop source, captured desktop row or a reviewed vector), never from the
   web output.
2. Never loosen a comparator, tolerance or required-case list to make a test pass; fix the code or record a reviewed
   source-backed correction (document 04 §3).
3. Database tests fail, not skip, when no database is reachable (`web/apps/api/test/globalSetup.ts`); skipping needs
   an explicit `ALLOW_SKIP_DB_TESTS=1`.
4. Fixtures are hermetic: each test creates and removes its own rows, with unique codes per run.
5. Time zone and clock are fixed in tests; dates travel as `YYYY-MM-DD` (D19).
6. Every new route is added to the route policy and the exact route-universe test.
