# Independent review of the new execution and verification documents

Reviewed on 29 September 2026. Files inspected: `docs/master-parity-plan-2026-09-29/02-execution-plan.md` and `04-verification-playbook.md`, alongside the preserved previous verification specification, current Round15 recipe and application route source. No repository files were edited by this review.

## Confirmed Return surface correction

- `web/apps/api/src/routes/txn.ts:1399` actively registers legacy numeric creation through `POST /sales-returns` → `createSaleReturn`.
- `web/apps/api/src/modules/sales/salesReturn.ts:743` exports `editSaleReturn`, which contains numeric delete/rebuild logic. A source-wide search finds this definition but no import/call in `txn.ts`, so it does **not** establish a routed generic numeric edit API.
- `web/apps/api/src/routes/txn.ts:1386` registers saved `PUT /sales-returns/:vchNo/incoming-metadata`. This remains distinct from numeric editing. Legacy DELETE also remains at `txn.ts:1440`.
- New saved incoming Return replay/planning remains diagnostic with `canCommit:false`; new trusted numeric Save/Update and known closing remain open.

The current execution/verification documents correctly separate active legacy creation from future saved-return persistence at the level inspected. The earlier scratch reconciliation now explicitly distinguishes active create, unrouted numeric helper, metadata update and future numeric Update; the source correction was applied to `work/plan-reconciliation.md`, `work/reconciliation.json` and the generator without rerunning or overwriting the timestamped input audit.

## Actionable planning clarifications

### 1. Clarify cross-wave start and closure dependencies

Locations: `02-execution-plan.md:20`, `:21`, `:23`, `:26`, `:32`.

W05's exit includes supplier payment/settlement; W06's includes order-to-manufacturing fulfillment; W08 finance says it depends on W05–W07 transaction footprints; W11 manufacturing depends on W08. If all named dependencies mean previous exit gates must close before the next wave begins, these obligations cycle. The paragraph that this is a start-order, not a waterfall, points in the right direction but leaves the actual start/close rules implicit.

Recommended edit: distinguish `startPrerequisites` from `closureDependencies`. Start finance primitives after W01/W03, alongside purchase/sale development, and allow fixture/contract work earlier. Close purchase supplier settlement only after its finance leaf passes; close order→manufacture fulfillment only after the W11 production leaf passes. Do not mark either broad parent complete when its dependent journey is deferred. Similar explicit closure edges apply to W09's manufacturing effects and W13 reports. This preserves incremental work without producing a circular release order.

### 2. Explicitly list the retained context and labour browser suites

Location: `04-verification-playbook.md:308`; related `02-execution-plan.md:43`.

The main `pnpm test:parity:browser` entry point runs `apps/web/test/parity.real-stack.mjs`. It does not itself execute `session-context.real-stack.additive.mjs` or `labour-preview-lifecycle.real-stack.mjs`, both separate required proofs in `parity-plan-2026-09-10/checkpoint_recipe_round15.py`. “Expand to all required journeys” should not hide currently known required suites in a step-by-step recipe.

Recommended edit: add both paths as explicit required browser entry points, run through the inspected disposable test wrapper and their current artifact directories. Record the main suite, session/context lifecycle suite and labour-preview lifecycle suite independently; preserve the distinction between mocked business data and declared faults applied to real responses. The historical 17/14/5 counts are starting required sets, not permanent caps after new cases are added.

### 3. Include strict core-test compilation separately from API test compilation

Location: `04-verification-playbook.md:306`.

`web/package.json` defines `typecheck:tests` only for `apps/api/tsconfig.test.json`. The retained Round15 recipe separately compiles five new core test files with strict flags. Running the advertised API test typecheck plus package core runtime tests does not prove those core test types were checked.

Recommended edit: explicitly run the current required core-test compiler command (or introduce an equivalent package-level core test tsconfig/script during implementation), alongside API test compilation and normal workspace typecheck. Bind the full source/test/dependency input set and require a successful actual run. Do not permanently hardcode five files once the core test set grows.

### 4. Make the release validator's own rejection proof executable

Locations: `04-verification-playbook.md:9`, `:292`–`:296`, `:317`; `02-execution-plan.md:69`.

The documents require exact-set and current-candidate evidence, which is correct. Add an explicit final validator-control procedure so the requirement is itself verified: remove one required leaf/case, duplicate a case, provide an unknown case, stale a dependent calculator/schema/template/settings input, change the candidate after the build, use an empty extraction after a query error, and substitute synthetic data for a required real run. Each must refuse with the specific missing/stale obligation even if all supplied result flags are `passed`.

Map the full R00–R14 gates from the preserved verification specification to the new final acceptance record or a small gate matrix. The new prose covers the principal areas, so this is traceability/enforcement clarification rather than a claim that all those areas are absent. Ensure current required source sets are expanded rather than treating the existing finite menu/browser/G5 datasets as full semantic coverage.

## Acceptance coverage checked

The inspected documents retain full old-package/card scope, independent desktop oracles, real non-owner DB verification, true browser persistence, field/event/child depth, configured accounts, scoped identity, rollback/retries/concurrency, legacy/new Return separation, all four tag operations, manufacturing/loan/scheme continuation, report datasets and physical outputs, provider outcomes, two migration rehearsals, timed recovery, business-role UAT, candidate provenance, rollout and stabilization. No acceptance claim for the current application is introduced by these planning documents. The four clarifications above make execution and gate closure less ambiguous without weakening any previous requirement.

## Resolution in the final planning package

All four suggestions above were incorporated before publication: document 02 distinguishes wave start prerequisites from deferred cross-wave closure; document 04 names the main, session-context and labour browser suites, includes the bounded strict core-test compilation command and requires expanded core-test coverage, and maps R00–R14 with evidence-corruption rejection controls. A separate desktop-source review also added inferred-table reconciliation, qualified sequence reuse, per-field numerical precedence, retained-record coverage wording and explicit post-commit desktop effects. Final independent module/backlog review found no actionable inconsistency; this is planning review, not application acceptance.
