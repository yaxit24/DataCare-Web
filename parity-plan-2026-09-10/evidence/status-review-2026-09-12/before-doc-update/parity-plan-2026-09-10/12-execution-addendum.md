# Detailed implementation continuation — 12 September 2026

This is the operational continuation of [02-implementation-plan.md](02-implementation-plan.md), based on [the current review](11-current-completion-review.md). It contains **34 execution cards mapped to all 83 original packages**. The matching structured backlog is [13-execution-backlog.json](13-execution-backlog.json). These cards retain the original package acceptance and expand it; they do not reduce it to a shorter checklist.

Current implementation progress and the complete next-write sequence are recorded in [document 40](40-implementation-progress-round14.md), with actual verification in [checkpoint 41](41-implementation-checkpoint-round14.json), following [round 13 in document 38](38-implementation-progress-round13.md), [round 12 in document 36](36-implementation-progress-round12.md), [round 11 in document 34](34-implementation-progress-round11.md), [round 10 in document 32](32-implementation-progress-round10.md), [round 9 in document 30](30-implementation-progress-round9.md), [round 8 in document 28](28-implementation-progress-round8.md), [round 7 in document 26](26-implementation-progress-round7.md), [round 6 in document 24](24-implementation-progress-round6.md), [round 5 in document 22](22-implementation-progress-round5.md), [round 4 in document 20](20-implementation-progress-round4.md), [round 3 in document 18](18-implementation-progress-round3.md), [round 2 in document 16](16-implementation-progress-round2.md) and [round 1 in document 14](14-implementation-progress-2026-09-11.md). Read the current source contracts, verification instructions and remaining descendants before repeating a slice. Each affected structured card also carries an `implementationProgress` entry; its original acceptance and open status remain authoritative.

All cards are open because their full acceptance is incomplete. Many have substantial existing code. A less experienced implementer should read the named files and tests first, preserve working changes, and implement only the missing contract. Do not copy another family's page/writer merely because its label or fields look similar.

## How to execute one card

1. Read its parents in document 02, applicable scenarios and FORM-01–FORM-18 in document 03, the desktop source/mode register, and its existing files. Follow invoked helpers and configuration branches beyond the named form.
2. Write explicit leaf requirement IDs for the selected vertical slice. Record source hash, source lines and caller/constructor/MAIN_BOOK/role/settings/state conditions. Classify which parts already work, which are partial, and which need observation. A TODO is an open requirement, never a passing disposition.
3. Write the expected input, prompts, intermediate values, output and allowed/forbidden table effects **before editing implementation**. Use independent desktop/source vectors. If the outcome is unknown, prepare the capture/fixture and retain the dependency; do not invent a jewelry business rule.
4. Start with one complete mode and meaningful fixture. Trace UI -> actual request -> route adapter -> domain -> tables -> reader -> reopen -> print/report. Add schema changes only where required; deploy/version the migration and update the migration manifest where applicable.
5. Implement the smallest complete path, reuse shared policies with their documented semantics, and wire its UI/error/recovery behavior. Include source selection and read/edit/reversal, not just create. Maintain original IDs, decimal precision and customer/business scope.
6. Execute focused tests and a real-browser journey using the isolated database. Compare stored business rows independently; a response echo or substring test does not establish persistence. Verify one deliberate failure in each changed path using a temporary local test mutation or controlled fault fixture, then restore the implementation.
7. Run the desktop differential and affected documents/reports. Classify any difference, fix its cause and rerun dependent cases. Do not rewrite expected outputs from the new implementation or raise a regression ceiling to erase a defect.
8. Attach the evidence manifest, update the leaf and parent progress records, and leave unsatisfied steps open. Only close the card when its original parent acceptance and cross-module requirements also hold. A code commit or passing mock test is an implementation event, not acceptance.

## Execution order and concrete first slices

Begin X01–X04 to establish scope, measurements, fixtures and trustworthy contracts. X34's CI/evidence infrastructure can start as soon as those definitions exist; its final release acceptance waits for all product evidence. Existing useful domain code need not be frozen while desktop observation is being prepared.

The first implementation queue after the relevant contracts is:

1. Reuse the source/evidence already captured through round 5. Do not reimplement the completed order/report-child, Design component/lifecycle/repeat, Sales/Tour base lifecycle or generic/repair image token slices; read each current progress contract and its remaining descendants.
2. X13/X02: preserve the existing metadata, row, bill and resolved-labour previews, session/browser controls and six Sales/Tour write guards. [Document 40](40-implementation-progress-round14.md) records the implemented diagnostic Save map, exact header Float qualifier, N BAR matcher and separate Serializable Return Update coordinator; none grants a numeric capability. Follow its complete next-write sequence together with the frozen [finite numeric-write contract](evidence/implementation-2026-09-12-round13/return-next-write-contract/implementation-contract.md), mandatory [independent review and stock erratum](evidence/implementation-2026-09-12-round13/return-next-write-contract-review/review.md) and [complete source-effect inventory](evidence/implementation-2026-09-12-round14/return-save-effects-analysis/effects-contract.md). First freeze the fully bound Option A fixture, including raw cells/caches, policy, per-prefix bill phases, N companions, all Save guards and complete effects. Then implement the pure effect plan, fresh versioned observation/admission, exact transaction-owned commit and failure/recovery tests before a separate endpoint and UI Save. MAIN_STOCK.SR_NO=2 and ISR_NO comes from incoming SR_NO; row and book data types have distinct ownership. Revalidate zero, omitted-row, received-side and changed BAR membership after replay; qualify cash, edition/audit and hidden-number/key collision behavior explicitly. The generic salesReturn writer and existing preview tokens do not authorize this path. Trusted mode and same-snapshot ledger/closing integration, remaining financial-writer adoption, source/child/tag admission, outgoing/variant workflows, settlement/reversal, reports and desktop/business/production acceptance remain open. The round4/x13-sale-return-33-next-contract.md classification still governs all 33 incoming, outgoing, hidden/reference and UAE field findings.
3. X11: implement shared help keyboard/search/create behavior from round4/x11-shared-help-next-contract.md and its source hashes. Preserve exact selection identity and event/cached-calculation rules; resolve desktop cancellation differences through independent observation/business acceptance.
4. X14/X17: extend the existing saved-order and repair lifecycles through settlement, reservations, partial delivery, conversion, custody, cancellation/refund and dependent reversals. Preserve nested identities and raw imported values; the basic saved-photo or editor contract does not prove these descendants.
5. X15: implement the dedicated E CRNT entry/write/edit/delete lifecycle and full reports, retaining the saved-document reader and IRN adapter. Do not route credit-note writes through ordinary Sale Return merely because fields overlap.
6. X23: implement explicit Setting lot issue then partial receipt from the existing configured reader/source selectors; prove contention, material conservation, edit/reversal and reports from exact source write sets.
7. X18–X21: finish each contained tag operation with its individual release requirements. X05/X25: reconcile inherited image identity/rights mappings, historical files/MOB_IMAGE, remaining reports and actual devices; preserve the new asynchronous/session/concurrency barriers.
8. Extend the reference method through X07–X10, X12, X16, X22, X24, X26–X29; run X06 comparisons progressively with each family. Complete X30–X32 migration, recovery and variant closure, then X33 all-product acceptance and X34 certification. Discovery and reference environment preparation start earlier, as the original dependencies require.

This ordering is a risk-based implementation queue, not a claim that the first six slices are the only remaining gaps. Every card and original requirement remains mandatory. Start dependencies specify prerequisite contracts/infrastructure; cross-module acceptance still waits for completed dependent behavior.

## Required fixture packs

Create deterministic sanitized packs with stable IDs, seed code, hashes, setup permissions and cleanup. Proposed names below are **deliverables to create**, not existing fixtures. All test databases must be disposable and explicitly identified; running application/customer data is not a fixture.

| Pack | Required contents | Independent checks |
| --- | --- | --- |
| FX-SCOPE | Two tenants; tenant A with two companies, two branches and two fiscal years; deliberately repeated book/voucher/tag/account codes; restricted and permitted roles | Full key sets and untouched sentinel rows in every other scope, including documents and images |
| FX-CONFIG | Two unrelated chart-of-account/book configurations; TOUR ORDER 510, 511 and another configured code; E CRNT 146 plus a second valid series; different rates, rounding, stock and settlement policies | No hard-coded business code assumption; defaults/allowed modes resolve from configuration |
| FX-RICH | Two parent rows, at least two children per applicable child set, distinct HUIDs with leading letters/zeros, distinct source serials and images; unequal weights/rates/customer/karigar amounts | Complete values through payload, DB, reader, unchanged save, single-child edit/removal and parent reorder |
| FX-NUMERIC | Signed midpoint values, zero and omitted overrides, per-piece/per-weight bases, fractional/maximum supported decimals, gold/silver/other, leap-day/month/year date boundaries | Expected values derived from source/desktop vectors at each specified scale, never guessed or rounded with one global tolerance |
| FX-DEPENDENCY | Partially returned sale/purchase, split outstanding allocations, partially consumed order/lot/booking, tag history, unfinished WIP, scheme redemption and active pledge | Remaining quantities/money/fine and valid state transitions; concurrent consume and rollback |
| FX-HISTORY | Two representative sanitized business histories with old years, active/canceled documents, attachments, source references and changed historical settings | Migration keys/values/hashes plus permitted real business continuation using historical and current rules correctly |
| FX-OUTPUT | One-line and multi-page documents, multiple children, long Unicode text, large/negative values, copies, labels, photos, QR/barcodes and printer configurations | Dataset equality first, desktop PDF/image review second, actual physical output where required |
| FX-FAILURE | Lost response after commit, stale edit, canceled lookup, expired session, partial transaction failure, duplicate provider attempt, service/device disconnect and interrupted restore | One accepted effect, no partial rows or lost draft, explicit recovery/status, unchanged unrelated data |

Use deliberately different numbers to reveal swapped mappings. For example, different valid parent weights and child rates are better than filling every numeric field with 1. Validate that the fixture itself obeys the selected desktop mode; do not invent expected totals for an unmeasured formula. Store sensitive raw captures only in the approved ignored evidence area; the public plan contains IDs/hashes and redacted summaries.

## Universal acceptance for each applicable field and action

The original 18-case form matrix and 128 scenario anchors remain required. Expand them for every applicable book, setting, role and branch. For a normal transaction slice, evidence must include:

- New create with rich header, all applicable line/child/tender sets and source references.
- Saved open and unchanged save with equality of **all** persisted business columns and identities, including hidden values; explain allowed audit changes.
- One upstream edit, one override, child insertion/removal/reorder and a saved reopen; assert both immediate calculations and final values.
- Partial consumption/settlement/return, duplicate attempt, exceeded availability and dependent-source edit/delete behavior.
- Permitted cancellation/reversal and exact restoration of stock/money/fine/outstanding/source state.
- Wrong scope/role/period, invalid input, stale version and concurrent contention with zero partial side effects.
- Lost response/retry/session recovery and any required offline behavior.
- Document preview/print/copies and related reports/exports matching the persisted state and independently captured desktop outcome.

For masters, reports, jobs, devices and utilities use their corresponding lifecycle instead of inventing meaningless voucher transitions. Record a reviewed, source-backed not-applicable reason for each nonapplicable universal case. An empty case result does not count as that reason.

## Common evidence contract

Each X-card manifest must link six evidence groups: (1) source/mode contract and hashes; (2) field/action/path matrix; (3) frozen required case IDs; (4) executed tests and complete business-state comparisons; (5) applicable desktop, real-browser, report/device outputs; (6) classified differences and current descendant/parent statuses.

Record task/requirement/case IDs, source/configuration/fixture identity, exact app revision and dirty-tree digest during development, schema/lock/template/build hashes, UTC capture time, local business timezone, runner/test mode, expected and observed outcomes, artifact paths and reviewers. A release needs a reviewed clean candidate and matching deployed image identity. Synthetic and mocked evidence must identify itself and cannot satisfy independent desktop, live device/provider or real-browser/database requirements.

Suggested new leaf record shape:

```json
{
  "id": "REQ-TR_SL_EBILL-ECRNT-edit-line-amount",
  "parents": ["P05-01", "X15"],
  "desktop": {"source": "TR_SL_EBILL.cs", "hash": "to-capture", "mode": "E CRNT"},
  "preconditions": ["saved draft with no locked downstream dependency"],
  "contract": "Source-cited field, trigger, rounding, validation and effect specification",
  "webPath": {"page": "to-verify", "request": "to-verify", "writer": "to-verify", "reader": "to-verify"},
  "expectedCases": ["CASE-ECRNT-EDIT-01", "CASE-ECRNT-REOPEN-01"],
  "implementationState": "unassessed",
  "availabilityState": "partial",
  "engineeringEvidence": [],
  "desktopEvidence": [],
  "businessAcceptance": null,
  "productionAcceptance": null
}
```

The placeholders above are intentionally incomplete examples and must fail any completion gate. Review the actual desktop editing restrictions before adopting the example precondition. Generate real expected case sets from contracts, not from the list of tests that happens to pass.

## Commands and verification discipline

From `imodule-extracted/web`, current commands useful during implementation are:

```sh
pnpm --filter @datacare/api build
pnpm --filter @datacare/api typecheck
pnpm --filter @datacare/web typecheck
node scripts/check-contracts.mjs
node scripts/check-completion-register.mjs --strict
node scripts/check-dead-cells.mjs
node scripts/check-depth.mjs --audit
```

After X03 has provisioned and positively identified the disposable database, inject its `DATABASE_URL` and `MIGRATE_DATABASE_URL` securely, then run the relevant focused suite followed by the required full release suite:

```sh
RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1 pnpm --filter @datacare/api test
pnpm --filter @datacare/web test
pnpm --filter @datacare/core test
pnpm --filter @datacare/web build
pnpm --filter @datacare/web test:browser
pnpm --filter @datacare/web test:routes
node scripts/check-completion-register.mjs --strict --release
node scripts/check-g5-parity.mjs
node scripts/release-certify.mjs --plan
```

`test:browser` and `test:routes` use compatibility mocks. The separately implemented `pnpm test:parity:browser` runs production Next/Fastify against isolated PostgreSQL with zero mocked HTTP requests; round6 checkpoint25 records13 journeys. It is engineering evidence for those fixtures, not independent desktop or whole-product acceptance. Use `node scripts/parity-test-env.mjs -- COMMAND` to run commands in the disposable environment; without `-- COMMAND` it only provisions. API tests require the proper database; never add excludes, set `ALLOW_SKIP_DB_TESTS=1`, remove assertions or change guard ports simply to make the release command green. All 55433-only suites must execute on the verified disposable target.

`--strict --release` and G5 currently fail, correctly. `--plan` only lists release requirements; it is not certification. A `parity-measure --reuse` pass merely checks retained data. Actual release certification needs candidate/evidence configuration, all required environments, and X34's stronger contract. Do not invoke destructive restore/cutover or real provider/customer communication merely to make a review gate pass.

For documentation changes run `python3 parity-plan-2026-09-10/validate_current_review.py` from the repository root after generation. This verifies planning consistency and links; it cannot certify application behavior.

## Detailed execution cards

### X01 — Reconcile scope and replace misleading availability labels

**Status:** open. **Parents:** P00-01. **Start after:** none.

**Current finding:** CR-01/10: all menus are mapped, but blocked/partial paths and unresolved semantic inventory remain.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/docs/COMPLETION-REGISTER.json`
- `web/packages/core/containment.mjs`
- `parity-plan-2026-09-10/evidence/form-register.json`
- `parity-plan-2026-09-10/evidence/additional-control-candidates.json`

**Implementation sequence:**

1. Freeze the reviewed dirty-tree files and desktop executable/source hashes; preserve prior work and old evidence. Read 08 and 09 before classifying controls.
2. Join all 198 menu identities to actual MDI_FORM dispatch, constructor arguments, MAIN_BOOK, permissions, page, route and domain function; distinguish the report Lot IsuRec from the transaction TR_MFG_WITH_LOT.
3. Reconcile 212 primary C# files, the original 204-unit register, eight support units, 916 supplementary declarations, 43 unresolved grid records, report references and table ownership. Resolve semantic duplicates explicitly.
4. Add separate implementationState, availabilityState, verificationState and missingActions/containmentOperation fields; retain legacy state compatibility until all readers are updated. A declaration of implemented-unverified must not imply usable or complete.
5. Create the canonical source-to-mode-to-requirement register. Include every reachable branch even when it is unused in the supplied business data. Link missing artifacts to X32.

**Required verification, in addition to the universal matrix:**

- Every original menu/source/control/report identity resolves to a leaf or reviewed disposition; unknown identities cause failure.
- A contained tag route remains unavailable even when its page and handler exist; an IRN-only page remains partial.
- Changing a label or adding a duplicate route must not increase implemented semantic requirements.
- Adding a new discovered mode grows the expected set and reopens affected package acceptance.

**Close only when:** Complete traceable inventory and truthful availability; no automatic promotion to verified. Inventory completeness is an explicit reviewed result, not the 198-row count.

**Evidence:** retain an `X01` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X02 — Repair scanners before using any percentage

**Status:** open. **Parents:** P00-03. **Start after:** X01.

**Current finding:** CR-09: nested mappings and fixed page lists produce both blind spots and false alerts.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/scripts/check-depth.mjs`
- `web/scripts/check-dead-cells.mjs`
- `project-memory/parity/richness_web.py`
- `project-memory/parity/richness_desktop.py`
- `project-memory/parity/settings_parity.py`
- `web/apps/web/app/(app)/txn/wholesale-sale/page.tsx`
- `web/apps/api/src/modules/sales/rateCut.ts`

**Implementation sequence:**

1. Discover page files and dynamically reachable master/report/book modes independently of the writer map; fail an unmapped discovered path.
2. Track page input to transformed payload to route adapter to nested domain field to calculation/write/read/reopen, including issueYear/issueBook/issueNo/issueSrno -> isuRef -> ISU_* columns. Preserve this working mapping while fixing measurement.
3. Recognize typed settings aliases, recalc wrappers, shared component props and source declaration modifiers; join actual event/caller contracts rather than counting generic field names.
4. Classify each control as editable, derived, hidden identity, display-only or non-business, with conditional mode applicability.
5. Publish stage-specific counts with an unknown denominator until inventory closure. Keep old 73.0% and 97.6% figures labelled historical heuristic outputs; never reset a baseline to manufacture improvement.

**Required verification, in addition to the universal matrix:**

- A valid nested mapping passes; dropping isuRef from the route fails the corresponding path.
- Remove a reader field while leaving the writer intact: reopen coverage must fail.
- Add an extended-grid page without a mapping: audit must fail and name it.
- An identically named field on another route cannot satisfy the missing field.
- MS_PRINT virtual checkboxes and supported wrapper recalc/settings calls are discovered; unused aliases are not treated as effective policy.

**Close only when:** Measurement tools pass independent positive and negative fixtures and reconcile the declared universe; no claimed functional percentage from surface counts.

**Evidence:** retain an `X02` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X03 — Provision reproducible desktop and real web verification

**Status:** open. **Parents:** P00-02, P00-04. **Start after:** X01.

**Current finding:** CR-08: mock-browser coverage and port-5433 DB results are not a complete real-stack certificate.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/docker-compose.yml`
- `web/packages/db/prisma/schema.prisma`
- `web/packages/db/prisma/rls.sql`
- `web/packages/db/setup_roles.sql`
- `web/apps/api/test/globalSetup.ts`
- `web/apps/api/test/meltingPro.db.test.ts`
- `web/apps/api/test/otherCommission.db.test.ts`
- `web/apps/web/test/browser.smoke.mjs`
- `web/apps/web/test/route-coverage.mjs`

**Implementation sequence:**

1. Provision a dedicated disposable database on port 55433, or replace both hard-coded test guards with an equally strong explicit test-target identity check. Do not point mutation suites at the running app database merely because it is reachable.
2. Apply migration-owned schema, roles and forced RLS from scratch; separate owner setup credentials from non-owner runtime credentials. Fail drift, missing migrations and incorrect role assumptions.
3. Seed the fixture packs below and start matching API/web builds. Record health, build IDs, migration/lock hashes and source digest; do not infer running-container identity from local source.
4. Add a separate real-stack Playwright suite using actual login/context selection and requests, with independent DB assertions. Keep existing intercepted tests explicitly labelled mocked.
5. Prepare the isolated Windows desktop with Crystal dependencies and equivalent sanitized fixtures. Capture actions, prompts, intermediate amounts, outputs and before/after tables; report missing Windows resources as open dependencies.

**Required verification, in addition to the universal matrix:**

- Fresh migrations succeed twice into separate empty targets; owner/runtime role assertions pass.
- Both currently 55433-only suites run without exclusion; all required DB suites run with zero skips.
- A real-browser save creates rows; a response stub without the row must fail the test.
- Every dynamic report/master/book mode is enumerated, not represented by one placeholder URL.
- Wrong credentials, unavailable database, wrong schema and stopped API fail before business assertions; they cannot appear as successful empty cases.

**Close only when:** A single documented local/CI setup runs real browser/API/non-owner DB tests and independently attributable desktop captures. Required missing environments keep relevant acceptance open.

**Evidence:** retain an `X03` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X04 — Author complete behavior contracts and numerical vectors

**Status:** open. **Parents:** P00-05, P01-02. **Start after:** X01, X02.

**Current finding:** CR-10: only 11 contracts exist, eight draft, with 184 missing computed-vector links.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `project-memory/contracts`
- `web/apps/api/test/goldenVectors.test.ts`
- `web/apps/api/src/modules/ops/contractIntegrity.ts`
- `web/packages/core/src`
- `web/apps/api/src/modules/shared`

**Implementation sequence:**

1. Start with purchase, retail sale/return, tag opening, rate-cut receiving and lot manufacturing as reference contracts; then enumerate every remaining form/mode and non-form lifecycle action.
2. For each action record pre-state, role/book/settings, triggers, default/override precedence, validation and confirmation branches, effects, read/edit/reversal and error behavior.
3. Review all 28 unenforced-rule records against current code before implementing; record fixed-but-stale entries separately from genuine missing behavior.
4. Replace each missing formula link with a source-cited golden vector independently checked on desktop, or a reviewed non-calculated disposition. Do not copy a vector based on matching column names.
5. Cover signed midpoint rounding, rate/weight units, null/blank/zero, per-line/voucher rounding, customer/karigar valuation, date boundaries and maximum supported decimal precision.

**Required verification, in addition to the universal matrix:**

- Change each shared numerical policy in a temporary test copy: all affected family vectors and previews must fail.
- Explicit zero remains zero where permitted; omitted override invokes the configured derivation.
- Calculating a default twice does not freeze it as an operator override.
- An approved contract with missing source, field, branch, vector or mandatory case is rejected.
- Negative source-dead claims include all callers/settings/edition modes and runtime corroboration where source is incomplete.

**Close only when:** Every required leaf has an actionable contract and independent oracle; drafted or partially approved documents cannot close a family.

**Evidence:** retain an `X04` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X05 — Close document identity, edits, concurrency and retries

**Status:** open. **Parents:** P01-01, P01-04, P01-05. **Start after:** X03, X04.

**Current finding:** Order reports now retain complete scope; bounded ordinary Sales versions, imported-state preservation and shared photo revisions are implemented. Cross-family identity, dependency and retry acceptance remains open. Round 5 adds versioned generic/Design/repair images, source-book readers and guarded shared clients; read document22 for verification and exact remaining descendants.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/vouchers`
- `web/apps/api/src/modules/posting/posting.ts`
- `web/apps/api/src/modules/sales/orderDoc.ts`
- `web/apps/api/src/routes/txn.ts`
- `web/apps/web/lib/api.ts`

**Implementation sequence:**

1. Build a per-table identity matrix including padded voucher/ledger keys, tag instances, parent/child serials and historical references; use full tenant/company/location/year/book/voucher scope where applicable.
2. Trace create/get/list/edit/delete/print/image/report consumers for each family. Correct OrderScope, orderData and its route to carry exact location and year into header/detail/party reads.
3. Define immutable identities and allowed correction transitions from desktop; preserve unchanged rows and source lineage.
4. Add optimistic version checks or a documented equivalent to prevent silent stale overwrite, plus transactional locks for stock, booking, outstanding and source allocation.
5. Implement stable idempotency keys for accepted mutations and response-loss recovery. Scope keys to operator/business operation and compare payload digest; dispatch external effects only after commit.

**Required verification, in addition to the universal matrix:**

- Same book/voucher/tag in two tenants, companies, locations and years returns exactly the selected document, including its print and image.
- Two tabs edit the same saved document: stale save conflicts without losing either draft.
- Concurrent sale/split/transfer of one tag and concurrent bill/order/booking allocation allow only valid consumption.
- Lose the response after commit and retry: one voucher/effect exists and the original result is returned; conflicting key reuse fails.
- Failure after header/detail preparation rolls back all required rows; locked or dependent source changes have no partial effects.

**Close only when:** All applicable lifecycle transitions are atomic, correctly scoped and conflict-safe, including documents and downstream consumers; domain tests plus real-browser cases prove it.

**Evidence:** retain an `X05` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X06 — Replay exact posting footprints and reconcile history

**Status:** open. **Parents:** P01-03. **Start after:** X03, X04, X05.

**Current finding:** The retained 70-case comparison is old and has zero complete matches; current defects cannot be inferred from its field total.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/integration/parity-extract-mssql.mjs`
- `web/apps/api/integration/parity-extract-pg.mjs`
- `web/apps/api/integration/parity-compare.mjs`
- `web/apps/api/integration/parity-replay-generic.mjs`
- `web/scripts/parity-measure.mjs`
- `web/apps/api/src/modules/shared/rojmel.ts`

**Implementation sequence:**

1. Freeze full expected case/table/key/column sets before capture; distinguish empty required tables from missing extraction.
2. Replay current web code from the same starting fixtures and configurations as the desktop, preserving provenance. Use synthetic cases for harness tests only; never derive expected desktop values from web output.
3. Classify each old difference as still present, now fixed by current code, extraction/mapping defect or reviewed deliberate behavior difference; retain both old and new evidence.
4. Compare headers/details/IDTL, ledger role/account/sign/key, Rojmel money and metal rows, stock, tax, outstanding, adjustments, tender identity, images and audits. Assert forbidden writes too.
5. Correct one business rule at a time and rerun its dependent families/reports. Review every excluded field and technical normalization; financial differences cannot be hidden by tolerance or field removal.

**Required verification, in addition to the universal matrix:**

- Missing/extra table, row, field, duplicate case and incomplete capture fail the comparator.
- Fully paid versus outstanding, mixed tender, negative/zero boundaries and multi-line components match complete footprints.
- Create, unchanged edit, changed edit and permitted reversal match both intermediate and final state.
- A balanced but wrong-account ledger fails; removing both balancing legs also fails.
- Retained old evidence cannot certify changed code or a new settings/template version.

**Close only when:** Every required family/mode has a current complete differential with zero unclassified business differences and all downstream balances reconciled.

**Evidence:** retain an `X06` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X07 — Finish shared forms without flattening domain variants

**Status:** open. **Parents:** P02-01, P02-02, P02-03, P02-04. **Start after:** X04.

**Current finding:** Shared grid/subdetail adoption is progress, but it does not prove every cell, child set or trigger.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/web/components/ExtendedGrid.tsx`
- `web/apps/web/components/SubDetailGrid.tsx`
- `web/apps/web/components/GridKeyboard.tsx`
- `web/apps/web/components/FormKeys.tsx`
- `web/apps/web/lib/lineRecalc.ts`
- `web/apps/api/src/modules/shared/stoneSubDetail.ts`

**Implementation sequence:**

1. Use a reference form with two parent rows, two different child collections, tender rows and source allocations; list all applicable control contracts before adding columns.
2. Support stable row/child identity, insertion/removal/reorder, numeric units/precision, lookup filters, derived read-only cells and explicit overrides.
3. Implement field-change/cell-exit dependency order through shared measured policies; retain per-form customer versus karigar valuation and receive-side differences.
4. Map each visible input and computed display to the exact route/writer/reader. Hidden IDs remain server-owned; displaying a database column is not an operator requirement.
5. Complete keyboard save/new/print, row navigation, append/delete, modal escape, focus after validation and remembered columns; observe F10 before assigning its action.

**Required verification, in addition to the universal matrix:**

- Distinct parent and child sentinel values survive browser save/reopen/unchanged save; reordering never moves a child to the wrong parent.
- Changing weight/touch/rate/labour updates every dependent value identically in UI/API/DB.
- Choose a lookup, cancel another lookup, paste values, scan a code and edit by keyboard; results agree.
- At 1366x768 operators can access every required field and total without losing the selected row.
- Adding a shared component does not mark untested caller modes complete.

**Close only when:** All applicable form controls and action transitions have real field-path evidence, plus measured operator throughput and accessible error/focus behavior.

**Evidence:** retain an `X07` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X08 — Complete observable settings behavior

**Status:** open. **Parents:** P02-05. **Start after:** X02, X04.

**Current finding:** The old scanner reports 45 honored and 82 inert among 130 rows, but typed aliases make these candidate counts unreliable.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/settings/settingsInventory.ts`
- `web/apps/api/src/modules/shared/settingsBehavior.ts`
- `web/apps/web/lib/companySettings.ts`
- `web/apps/api/test/settingsEffect.db.test.ts`
- `web/apps/api/test/settingsRealValues.test.ts`

**Implementation sequence:**

1. Join setting identity by table/key and configured scope; catalogue actual desktop encodings, defaults, invalid values and consumers, including CO_MAST/TAG_SET/book/user preferences.
2. Trace load -> alias -> UI/server consumer -> persisted/report consequence. Reuse existing consumers before adding another policy layer.
3. Prioritize SL_TAG_WT_DIFF, CUR_DAY_POSTING, branch account visibility, weight/fine locks, negative stock, estimate/tax, rounding, print/image/copy settings and lot policies.
4. Implement effect cases per affected family and mode, with direct API enforcement where it governs accepted business state.
5. Document cache invalidation on company/year/user/book change and concurrent session changes; preserve historic recorded values when current defaults change.

**Required verification, in addition to the universal matrix:**

- For every behavioral setting, the same valid fixture under each supported value produces the independently expected outcome.
- Null, blank, zero, Y/N and numeric encodings are distinguished according to source.
- A loader read without an outcome assertion does not pass; a field disabled in UI still obeys policy in direct requests.
- CUR_DAY_POSTING changes the source-confirmed refresh scope, not an invented posting-date rule.
- Switch business settings while another tab has a draft; stale policies cannot silently alter accepted transactions.

**Close only when:** All settings have reviewed dispositions and effect evidence across required consumers; no regex-derived inert count is treated as a verified missing-feature total.

**Evidence:** retain an `X08` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X09 — Preserve form sessions and resolve offline service behavior

**Status:** open. **Parents:** P02-06. **Start after:** X01, X03.

**Current finding:** CR-11/14: context-change invalidation and the operational outage model are not accepted.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/web/components/BookSelect.tsx`
- `web/apps/web/components/BusinessScope.tsx`
- `web/apps/web/components/Shell.tsx`
- `web/apps/web/lib/api.ts`
- `web/deploy/docker-compose.prod.yml`

**Implementation sequence:**

1. Document service requirements for internet outage, LAN loss, app/DB failure and device-bridge loss; identify which operations continue, queue or stop. Resolve intended local/LAN, cloud or disconnected-posting topology before dependent implementation.
2. Trace whether BookSelect and lookup callers remount on every business context change. Add explicit scoped invalidation where needed, retaining cancellation of stale fetch responses.
3. Preserve meaningful drafts, selected row and validation errors on recoverable failure, refresh and related-form navigation; define confirmation behavior before context change or draft discard.
4. Support consulting a ledger/master while an invoice remains open, with per-tab context isolation and stable saved preferences.
5. Implement recoverable posted-status display and retry via X05. If offline posting is required, specify local identity/stock ownership, permissions, rates, synchronization and conflict policy before coding it.

**Required verification, in addition to the universal matrix:**

- Two businesses use disjoint books; switching in place and with two tabs shows only the correct choices and values.
- Expired session during editing preserves draft; retry cannot post under a changed context.
- Navigate to a related master/ledger and back: row, children and totals remain intact.
- Exercise each agreed outage, server restart and reconnect; no ambiguous accepted sale, duplicated settlement or silent draft loss.
- Draft caching alone fails a requirement that ordinary sale posting continue without internet.

**Close only when:** A documented business service decision and tested session/outage behavior support the claimed operational scope. Unresolved topology remains an explicit dependency, not an assumed waiver.

**Evidence:** retain an `X09` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X10 — Complete master data and fresh-business provisioning

**Status:** open. **Parents:** P03-01, P03-02, P03-04, P03-05. **Start after:** X04, X07, X08.

**Current finding:** Master screens exist; generic row CRUD must still prove conditional fields, child policies and usable branch setup.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/masters/master.service.ts`
- `web/apps/api/src/modules/masters/configs.ts`
- `web/apps/api/src/modules/masters/companyClone.ts`
- `web/apps/api/src/modules/masters/stockLimit.ts`
- `web/apps/api/src/modules/masters/year.ts`
- `web/apps/web/app/(app)/masters/[name]/page.tsx`

**Implementation sequence:**

1. Map desktop MS_ACCT/MS_ITEM/MS_PRODUCT/MS_LOCT/book/year/user/rate/labour/slab/counter/diamond variants to dynamic and specialized web masters.
2. Implement whole-row/settings/reference validations, code generation, text identity lengths, linked photos, credit/tax/bank data and parent-child policy collections.
3. Trace MS_LOCT provisioning of BOOK_DATA, BOOK_DETL and TABLE_MAST; implement missing atomic cloning and defaults rather than only inserting a location row.
4. Complete previewable scoped import/export with row-level errors, duplicate/reference policies and rollback; use the same business validation as individual edits.
5. Verify new company, branch and year can execute purchase, sale, tender and reports with their own configured accounts without SQL fixes.

**Required verification, in addition to the universal matrix:**

- Two shops use different book/account codes; both complete a first business day.
- Rich master reopen/save preserves conditional fields, child slabs and images; referenced deletions fail appropriately.
- Slab boundaries and item/party policies affect the intended transaction only.
- Malformed, duplicate, Unicode and leading-zero import rows produce precise outcomes without partial setup.
- Fail branch setup halfway: no partially usable book or permissions remain; year transitions preserve opening balances.

**Close only when:** All reachable master modes and imports are usable and validated, and independent configured-business setup has full-stack evidence.

**Evidence:** retain an `X10` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X11 — Implement design components and complete design identity

**Status:** open. **Parents:** P03-03. **Start after:** X04, X07.

**Current finding:** Design Book parent/components, source calculations, repeat/keyboard events and scoped Sales Design selection are implemented. Full shared-help commands, remaining settings/downstream consumers and independent desktop acceptance remain open.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `unified/src/csharp/DataCareNext/MS_DESIGN_BOOK.cs`
- `web/apps/api/src/modules/masters/designBook.ts`
- `web/apps/web/app/(app)/masters/design-book/page.tsx`
- `web/apps/api/test/designBook.db.test.ts`

**Implementation sequence:**

1. Extract DESIGN_DETL/DESIGN_IDTL ownership, serials, defaults, customer/karigar calculations and image lookup from the desktop handlers; do not infer keys from design number alone.
2. Extend the input, validation, atomic save, reader and deletion paths with per-parent component collections and explicit retained identities.
3. Add child editing to the dedicated screen and preserve hidden identities on unchanged save and parent reorder.
4. Associate images by the complete entity key and preserve them through order/manufacturing conversion.
5. Implement source-confirmed fine, rate basis, labour/other/net cost and MRP derivation/overrides using X04 policies.

**Required verification, in addition to the universal matrix:**

- Two books and two products share a design number but retain different children/images.
- Two components per parent carry distinct weight, conversion, customer and karigar values through browser/API/DB/reopen.
- Remove one child and reorder parents: remaining serials and ownership are unchanged.
- Unchanged save preserves every business column and image association; failed child validation rolls back the entire edit.
- Select the design in an order and manufacturing issue: the correct specification and photo follow it.

**Close only when:** Desktop parent/child/image behavior is complete and independently compared, including downstream design specification use.

**Evidence:** retain an `X11` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X12 — Close every purchase and supplier lifecycle

**Status:** open. **Parents:** P04-01, P04-02, P04-03, P04-04, P04-05. **Start after:** X05, X06, X07, X08, X10.

**Current finding:** Retail, hallmark, old-item, quotation, consignment and other purchase work exists; certify variant depth rather than rebuilding it.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/purchase`
- `web/apps/web/app/(app)/txn/purchase/page.tsx`
- `web/apps/web/app/(app)/txn/purchase-hm/page.tsx`
- `web/apps/web/app/(app)/txn/purchase-return/page.tsx`
- `web/apps/api/test/purchase.lifecycle.db.test.ts`
- `web/apps/api/test/purchaseQuotation.db.test.ts`

**Implementation sequence:**

1. For each TR_PURC/TR_PURC_HM menu/book variant, map main, receive/return, IDTL, totals and tender fields through its own writer/reader.
2. Reuse quotation/old-item/consignment paths after checking their effect exclusions; a quotation must not accidentally consume stock or post an ordinary payable.
3. Complete source selection for supplier return, remaining quantity/components, original price/tax and permitted historical references.
4. Finish cash/bank/cheque/card/UPI/advance/kasar identities, bill allocation and correct configured ledger/Rojmel roles.
5. Drive supplier creation -> rich purchase -> tag/lot availability -> partial return -> mixed settlement -> supplier/stock/tax reports -> permitted correction through real screens.

**Required verification, in addition to the universal matrix:**

- Two configurations, mixed gold/silver, two lines and two components each preserve all header/line/child fields.
- Zero/disabled tax, blank/zero rate and manual overrides match each book contract.
- Fully paid and outstanding purchases have exact different row footprints; mixed tender identities are retained.
- Over-return, repeated source selection, settlement over-allocation and source edits after dependencies fail without effects.
- Unchanged edit and return cancellation preserve/restores exact stock, source balances, liability and report totals.

**Close only when:** Every purchasing variant and the complete supplier journey passes independent desktop, real-browser, DB and report acceptance.

**Evidence:** retain an `X12` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X13 — Close retail, wholesale, labour and return depth

**Status:** open. **Parents:** P05-01, P05-02, P05-03, P05-08. **Start after:** X05, X06, X07, X08, X10.

**Current finding:** Saved incoming metadata, separate row/bill/labour previews, session/browser controls and six guarded order mutations are implemented. Round14 adds diagnostic incoming Save mapping, exact header Float qualification, N BAR companion matching and an internal Serializable Return Update coordinator. Numeric saves and known closing remain disabled. Document40 and checkpoint41 govern the complete independent fixture, effects, Save guards, versioned admission and exact atomic writer prerequisites; all remaining source/variant, ledger/closing, settlement, report and desktop/business/production acceptance stays open.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/sales/sales.ts`
- `web/apps/api/src/modules/sales/salesReturn.ts`
- `web/apps/api/src/modules/sales/wholesaleSaleReturn.ts`
- `web/apps/api/src/modules/sales/labourInvoice.ts`
- `web/apps/api/src/modules/sales/rateCut.ts`
- `web/apps/web/app/(app)/txn/sales/page.tsx`
- `web/apps/api/test/salesFamilyLifecycle.db.test.ts`

**Implementation sequence:**

1. Enumerate TR_SALE/TR_SALE_HM/TR_WH_SALE/TR_SALE_LBR/return/fine-sale modes with their independent field/action contracts.
2. Complete applicable source picks, issued and received grids, IDTL sets, old gold, order/scheme redemption, HUID/cost/commission, manual rates and tender identities.
3. Preserve wholesale isuRef mapping noted in X02; verify it by persisted columns instead of deleting the fields to silence a scanner.
4. Provide actual source-invoice return selection with remaining components, original pricing/tax/cost and permitted refunds/credits; correct dependency locks and reversal.
5. Verify all lines, settlement bands, invoice/credit documents and sales/stock/outstanding/tax/commission reports from real UI.

**Required verification, in addition to the universal matrix:**

- Tagged scan, manual untagged sale, mixed old-gold exchange and component-heavy invoice complete on both configured shops.
- Issued-only, received-only and two-sided wholesale/labour cases keep their distinct customer/karigar valuations.
- Partial/full/repeated return, over-return and cancellation conserve source availability and stock.
- Per-piece/per-weight basis, blank/zero/override and taxable/non-taxable modes agree in preview/API/DB/print.
- Failed save, concurrent consumption and no-change reopen cannot duplicate sale effects or lose rich values.

**Close only when:** Each sales variant and supported return journey has complete operator and effect parity, including all dependent settlement and reporting.

**Evidence:** retain an `X13` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X14 — Complete Tour Order, quotations and fulfillment conversion

**Status:** open. **Parents:** P05-04, P05-06. **Start after:** X05, X07, X11.

**Current finding:** Configured ordinary Sales and Tour editors now have bounded full saved-document lifecycles. Remaining financial/tag branches, quotations, delivery, conversion and cross-module acceptance are still required.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs`
- `web/apps/api/src/modules/sales/salesOrder.ts`
- `web/apps/web/app/(app)/txn/tour-order/page.tsx`
- `web/apps/web/app/(app)/txn/sales-order/page.tsx`
- `web/apps/web/app/(app)/txn/sales-quotation/page.tsx`
- `web/apps/api/test/tourOrder.db.test.ts`

**Implementation sequence:**

1. Reuse TOUR ORDER API wrappers; add BookSelect constrained to the correct MAIN_BOOK and forward the selected book/location/year on list/create/get/edit/delete/print. Remove 510 as an unconditional list/print identity.
2. Implement selected-voucher hydration and PUT from the browser, including every header, line, component, image and advance; separate new/edit/cancel state and stale version handling.
3. Capture quotation-to-order/invoice, partial order manufacturing/delivery and source adjustments from desktop. Add explicit source selection and conversion lineage rather than copying rows without consumption.
4. Keep money/fine advances, production balance, tag reservation and delivered quantities separate. Release each only on its corresponding reversal.
5. Implement cross-book transfer only from the measured full reference graph; renumbering alone is not transfer.

**Required verification, in addition to the universal matrix:**

- TOUR ORDER books 510 and 511 plus a nonstandard configured code work; a SALES ORDER book is rejected in Tour Order.
- Create -> close -> select -> unchanged edit -> changed child -> delete through the screen; get/print/list agree on the selected scope.
- Two partial deliveries exhaust one order exactly; canceled delivery restores its allocation.
- Repeated/stale conversion, excess allocation, source deletion, locked destination and identity collision fail atomically.
- Order -> multiple karigars -> receipts -> tags -> invoice preserves specification, images, advances and source identity.

**Close only when:** All order/quotation/conversion actions are reachable without manual SQL, with correct balances, book scope and independently compared documents.

**Evidence:** retain an `X14` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X15 — Implement the full E Credit Note document workflow

**Status:** open. **Parents:** P05-01, P11-03. **Start after:** X04, X05, X07.

**Current finding:** CR-02: POST /einvoice/credit-note/irn currently assumes the E CRNT document already exists.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `unified/src/csharp/DataCareNext/TR_SL_EBILL.cs`
- `web/apps/web/app/(app)/txn/e-crnt-note/page.tsx`
- `web/apps/api/src/modules/einvoice/einvoice.ts`
- `web/apps/api/src/routes/txn.ts`
- `web/apps/api/test/ecreditNoteIrn.db.test.ts`

**Implementation sequence:**

1. Read TR_SL_EBILL save/open/delete/browse/print and E CRNT branches; record full header/item/tax/reference fields and exact allowed/forbidden stock, ledger, Rojmel and tax effects. Do not assume an ordinary sale or return writer is equivalent.
2. Implement explicit E CRNT create/get/list/edit/delete domain and route paths (new names are to be chosen consistently), selected-book validation and full-scope readers.
3. Replace the IRN-only form with complete entry, browse, reopen/edit, permitted deletion and document preview/print; retain existing IRN submission as a saved-document action.
4. Preserve invoice/source references, document type CRN, book series and totals; match rounding/zero-tax/discount cases to historical source contracts.
5. Add provider submit/status/retry/cancel and post-IRN edit restrictions according to measured desktop behavior and current provider requirements verified during X28; expose real pending/failed/live states.

**Required verification, in addition to the universal matrix:**

- Create a new credit note entirely through web UI with no SL_DATA fixture insertion; reopen and compare every applicable field/effect.
- Same voucher number in sale and two E CRNT books remains independent; print and IRN use only the selected one.
- Mixed item/tax, zero-tax, discounts, blank optional references and multi-page credit note match expected data.
- Unchanged/changed edit and permitted deletion preserve identities and exact reversible effects.
- Provider timeout after acceptance, retry and cancel resolve one real document status; fake-provider tests remain labelled engineering evidence.

**Close only when:** An operator can create and complete the credit-note lifecycle in web, including documents and provider state. Existing fake-GSP persistence tests alone cannot close it.

**Evidence:** retain an `X15` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X16 — Complete finance, booking and two-sided rate-cut journeys

**Status:** open. **Parents:** P06-01, P06-02, P06-03, P06-04, P06-05, P06-06. **Start after:** X05, X06, X07, X08.

**Current finding:** RATE_CUT_REC and rich tenders now exist; old absence wording is superseded, but full configured accounting acceptance remains open.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/finance`
- `web/apps/api/src/modules/sales/rateCut.ts`
- `web/apps/api/src/modules/inout/fineInout.ts`
- `web/apps/web/components/PaymentForm.tsx`
- `web/apps/web/app/(app)/txn/rate-cut/page.tsx`
- `web/apps/api/test/rateCutSettlement.db.test.ts`

**Implementation sequence:**

1. Verify cash/bank/contra/journal/opening/fine-transfer/bill-to-bill/clearance variants against their own MAIN_BOOK roles and money/metal signs.
2. Preserve per-line cheque/UPI/card/bank identity, payee, charges, dates, account slots and debit/credit/kasar directions. Do not replace identity rows with header totals.
3. Reuse rate-cut receive writer/reader/reversal and expose all received-line/child/settlement values; reconcile PR_* totals and both money/fine legs with issue-side results.
4. Implement multi-party booking and remaining fine/quantity/rate allocation, including basis per piece/gram/ten grams/kg, conversion, premium and ADJ_WT lifecycle.
5. Finish due-date/aging and residual bill selectors and run opening -> purchase/sale -> mixed payments -> allocation -> clearance -> journal/fine transfer -> closing reports.

**Required verification, in addition to the universal matrix:**

- Issued-only, received-only, two-sided and zero/blank-rate cuts match desktop for each permitted basis and sign.
- Split UPI/cheque payments preserve distinct identities and correct book-specific role codes.
- Two simultaneous settlements/booking drawdowns cannot overconsume; refund/delete releases only its own allocation.
- Changed source totals, locked periods and cross-year historical settlements follow explicit rules.
- Trial balance, daybook, bank statement, fine outstanding and supplier/customer balance each reconcile to source documents, not merely aggregate zero.

**Close only when:** All accounting variants and complete business closing have desktop/DB/report agreement and accountant acceptance.

**Evidence:** retain an `X16` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X17 — Join approval, consignment, tour, parcel and repair stages

**Status:** open. **Parents:** P05-05, P05-07, P05-08. **Start after:** X05, X07, X13.

**Current finding:** Standalone stage pages cannot prove custody, partial completion and settlement continuity. Round 5 adds versioned generic/Design/repair images, source-book readers and guarded shared clients; read document22 for verification and exact remaining descendants.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/tour`
- `web/apps/api/src/modules/repair`
- `web/apps/api/src/modules/sales/vpParcel.ts`
- `web/apps/web/app/(app)/txn/tour/page.tsx`
- `web/apps/web/app/(app)/txn/tour-return/page.tsx`
- `web/apps/web/components/RepairImagePanel.tsx`

**Implementation sequence:**

1. Map TR_APR_ISU/TR_TOUR/TR_TOUR_ORD/TR_TOUR_SALE/TR_VP/TR_VP_ADJ and repair callers by issue/return/sale/delivery state and permissions.
2. Implement remaining source selectors, available issued tags/components, photos, responsibility/location, promised dates and stage history.
3. Keep customer-owned repair custody distinct from business-owned stock; connect estimate/labour/charges and final settlement.
4. Support mixed partial sale and return from one issue and partial karigar repair receipt before final customer delivery.
5. Add dependency-protected stage corrections and reverse the actual source allocation, image/reference and financial effects.

**Required verification, in addition to the universal matrix:**

- Issue multiple items -> sell one -> return another -> reconcile still-out state and source availability.
- Duplicate import and over-return fail; cancellation cannot release stock already consumed downstream.
- Repair receive -> issue -> partial return -> completion -> customer delivery/refund retains custody and images.
- Branch responsibility change, missing photo, device failure and stage reversal produce defined recoverable states.
- Customer, employee/karigar, stock and outstanding reports explain every movement.

**Close only when:** All required custody and repair journeys finish through real screens with exact state, settlement and document continuity.

**Evidence:** retain an `X17` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X18 — Complete stock identity/openings and certify tag transfer

**Status:** open. **Parents:** P07-01, P07-02, P07-03. **Start after:** X05, X06, X07.

**Current finding:** CR-01: stock in/out and opening improvements exist; tag transfer remains contained.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/stock/stockInout.ts`
- `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts`
- `web/apps/api/src/modules/stock/tagOps.ts`
- `web/apps/api/src/modules/stock/tagInvariants.ts`
- `web/apps/api/test/tagOpeningRoundTrip.db.test.ts`
- `web/packages/core/containment.mjs`

**Implementation sequence:**

1. Define available/reserved/issued/sold/returned/canceled/replaced/split tag states by exact tag instance and table-specific serial; align lookup, reports and locks.
2. Reverify item/tag/lot openings, stock in/out and adjustments with complete HUID weights, component costs, images, counters and purchase/manufacturing lineage through browser payloads.
3. Trace transfer mode in TR_TAG_CAN and related stock helpers; reuse current domain work after comparing exact old/new BAR/IDTL/image and stock identities.
4. Implement complete transfer list/open/edit/delete, destination/location/counter rules, shared locks and source/destination reversal.
5. Evaluate transfer containment separately; update stale explanatory text without removing the block until its own desktop, lifecycle and concurrency evidence passes.

**Required verification, in addition to the universal matrix:**

- Two live/historical instances share a visible tag number; transfer selects exactly the intended serial.
- Rich opening unchanged save preserves all business columns, children and images; linked stock blocks invalid deletion.
- Transfer across permitted counters/locations preserves pieces/gross/net/fine/components/cost and lineage.
- Concurrent transfer versus sale, invalid destination and midway failure leave one valid state.
- Reverse/edit transfer only when dependency rules permit; reports match before/after desktop snapshots.

**Close only when:** Stock state is consistent everywhere and transfer has its own complete release evidence. Other contained tag operations remain separately gated.

**Evidence:** retain an `X18` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X19 — Certify tag cancellation independently

**Status:** open. **Parents:** P07-03. **Start after:** X18.

**Current finding:** Tag cancellation has tests and implementation changes but remains blocked at the route.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `unified/src/csharp/DataCareNext/TR_TAG_CAN.cs`
- `web/apps/api/src/modules/stock/tagOps.ts`
- `web/apps/api/test/tagCancelIdentity.db.test.ts`
- `web/apps/web/app/(app)/txn/tag-cancel/page.tsx`
- `web/packages/core/containment.mjs`

**Implementation sequence:**

1. Extract cancellation-specific live serial, source references, tag lot/polish/target-table inputs and permitted dependent states; distinguish transfer mode.
2. Audit existing cancel reader/writer/reversal against complete BAR detail, child, image and source lineage requirements.
3. Complete browser selection/open/edit/delete and validation/error focus for only operator-editable fields.
4. Use shared stock locks and exact availability checks; preserve a discoverable cancel audit/history.
5. Lift only cancellation containment after reviewed evidence meets the stated gate; neither a helper test nor HTTP 200 is sufficient.

**Required verification, in addition to the universal matrix:**

- Cancel exactly one intended live serial with a historical same-number serial present.
- Consumed/reserved/issued tags are handled according to the measured dependency rules.
- Unchanged/changed cancel and permitted reversal preserve rich details and restore availability exactly.
- Concurrent sale or transfer yields one permitted transition; a denied/failing cancel writes nothing.
- Stock, component, image lineage and desktop cancel document/state match.

**Close only when:** Cancellation can be completed and reversed through the allowed web lifecycle with independent evidence, without changing other tag release states.

**Evidence:** retain an `X19` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X20 — Complete atomic tag split and child conservation

**Status:** open. **Parents:** P07-04. **Start after:** X18.

**Current finding:** Tag split remains contained; inspect current child creation before relying on the registry description of old deficiencies.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/stock/tagSplit.ts`
- `web/apps/api/src/modules/stock/tagInvariants.ts`
- `web/apps/web/app/(app)/txn/tag-split/page.tsx`
- `web/packages/core/containment.mjs`

**Implementation sequence:**

1. Resolve actual desktop split dispatch and input/output/settlement grids; author quantity, weight, fine, cost and component allocation equations.
2. Verify/complete atomic parent consumption, unique child serial allocation, BAR headers/details/IDTL, images, parent links, stock and any measured financial effects.
3. Implement unequal child allocations and explicit residual/wastage/rounding policy; never silently drop remainders.
4. Expose complete child values and source selection with read/edit/delete and downstream-consumption locks.
5. Release only the split operation after its own complete artifact set.

**Required verification, in addition to the universal matrix:**

- Unequal split with at least three children, two components and images conserves all applicable measures at source precision.
- Duplicate child IDs, empty children, over-allocation and invalid mixed output items fail atomically.
- Concurrent parent sale/split allows only one valid consumption.
- Inject failure after preparing some children: no orphan barcode, image or stock row remains.
- Changed split and reversal preserve identity and refuse invalid downstream dependencies.

**Close only when:** Desktop-equivalent parent/child state, conservation, lifecycle and real-browser behavior are demonstrated before split containment removal.

**Evidence:** retain an `X20` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X21 — Complete weight replacement and sale-driven tag differences

**Status:** open. **Parents:** P07-05. **Start after:** X18, X08.

**Current finding:** Tag weight difference remains contained; SL_TAG_WT_DIFF is a separate sale-driven policy branch.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/stock/tagOps.ts`
- `web/apps/web/app/(app)/txn/tag-weight-diff/page.tsx`
- `web/apps/api/src/modules/shared/settingsBehavior.ts`
- `web/apps/api/src/modules/sales/sales.ts`
- `web/packages/core/containment.mjs`

**Implementation sequence:**

1. Trace the actual old/new tag replacement contract and Ac_Stock sale-driven SL_TAG_WT_DIFF branches; keep distinct requirement IDs.
2. Verify/complete serial linkage, barcode detail, IDTL, HUID weights, images, karigar values, settlement, Rojmel and stock effects; net-stock adjustment alone is insufficient.
3. Provide source/live-instance selector, derived differences and complete reopen/edit/reversal paths.
4. Apply common tag locks and dependency restrictions; bind financial effects to configured account slots.
5. Retain containment until all replacement branches, including no-change and source-consumed behavior, have independent results.

**Required verification, in addition to the universal matrix:**

- Positive, negative and no-change weight differences agree on old/new tag and movement state.
- Tagged and permitted untagged cases retain components/images and exact reference serials.
- Toggle SL_TAG_WT_DIFF on the same sale fixture and compare source-confirmed special stock rows.
- Concurrent sale/replace and failed replacement leave no mixed identity or half-posted settlement.
- Unchanged edit and allowed reversal reproduce full rich state, not just total net weight.

**Close only when:** Both explicit replacement and sale-driven weight-difference contracts are satisfied with separate evidence and correct release disposition.

**Evidence:** retain an `X21` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X22 — Finish physical stock sessions and inventory reconciliation

**Status:** open. **Parents:** P07-06. **Start after:** X18.

**Current finding:** Counting endpoints and reports exist; session finalization and business consistency require full acceptance.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/stock/physicalStock.ts`
- `web/apps/api/src/modules/reports/physicalStock.ts`
- `web/apps/web/app/(app)/txn/physical-stock/page.tsx`
- `web/apps/api/test/physicalStock.db.test.ts`

**Implementation sequence:**

1. Define count-session identity, cutoff/snapshot and permitted counter/location/lot filters from the desktop workflow.
2. Implement scan/manual input, expected versus counted quantities, duplicate/unknown/wrong-location feedback and component differences.
3. Define handling of stock movement during counting and require a preview of every adjustment before supported finalization.
4. Make finalize atomic/idempotent with traceable adjustment references, cancel/reopen rules and report drill-back.
5. Connect HUID, movement, valuation, stock-level and component outputs to the same stock-state contract.

**Required verification, in addition to the universal matrix:**

- Duplicate scans do not double-count; unknown and wrong-location tags are visible exceptions.
- A sale after the snapshot is reconciled explicitly rather than silently overwritten by count finalization.
- Two finalization attempts post one permitted adjustment set.
- Missing/extra tags, weight/piece/component differences and canceled sessions match desktop rules.
- Preview, posted adjustments and stock reports agree exactly.

**Close only when:** A stock clerk can count, resolve discrepancies and finalize/reverse as allowed, with complete stock and report reconciliation.

**Evidence:** retain an `X22` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X23 — Complete manufacturing variants and the lot workflow

**Status:** open. **Parents:** P08-01, P08-02, P08-03, P08-04, P08-05, P08-06. **Start after:** X04, X05, X07, X11, X18.

**Current finding:** CR-06: ITM_LOT persistence and mfgLotBalance support parts of the contract; no dedicated lot operator journey was found.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `unified/src/csharp/DataCareNext/TR_MFG_WITH_LOT.cs`
- `web/apps/api/src/modules/manufacturing/mfg.ts`
- `web/apps/api/src/modules/manufacturing/karigar.ts`
- `web/apps/api/src/modules/manufacturing/melting.ts`
- `web/apps/api/test/mfgLifecycle.db.test.ts`
- `web/apps/api/test/meltingPro.db.test.ts`
- `web/apps/web/components/KarigarForm.tsx`

**Implementation sequence:**

1. Create state/transition and material conservation contracts for order/free/stage/karigar/jobwork/ghat/jadtar/item/lot/melting modes; inspect all MFG source callers and stock flags.
2. Reuse generic issue/receive logic only where the variant contract matches. Add dedicated TR_MFG_WITH_LOT routes/screen or a proven explicit mode with source-lot selectors and full read/edit/delete; name any proposed path as new until implemented.
3. Complete lot balance locking and partial consumption, source serials, component return/breakage, chole/ghis/ghat/other losses, customer/karigar valuation and payment/received rows.
4. Join order/design -> issue/reissue -> partial receipt/rework -> stage completion -> tagging -> delivery/sale, preserving photos and specification.
5. Verify melting multiple inputs/outputs, assay changes, loss/byproducts/residual fine and financial settlement. Run the dedicated 55433 suite without exclusion.

**Required verification, in addition to the universal matrix:**

- Lot issue -> first partial receipt -> second receipt -> exhausted lot; over-receipt and concurrent drawdown fail.
- Several lots and components with distinct source serials preserve allocation and return/breakage through edit/reopen.
- One order across multiple karigars/receipts and unfinished work across a year boundary remains traceable.
- Multiple melting inputs/outputs with changed purity reconcile physical material and fine against explicit losses.
- Failed intermediate stage, reissue, canceled receipt and downstream sale dependencies preserve valid WIP, lot, karigar and stock balances.

**Close only when:** Every manufacturing variant and the full manufacturing business day works in browser with exact material/financial/report evidence; a lot report cannot satisfy the transaction requirement.

**Evidence:** retain an `X23` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X24 — Certify loan, dhiran and scheme business continuations

**Status:** open. **Parents:** P09-01, P09-02, P09-03, P09-04, P09-05. **Start after:** X04, X05, X07, X16.

**Current finding:** Loan and scheme-gold-adjust surfaces were added; date/interest/custody/redemption variants still need complete acceptance.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/dhrn/dhrn.ts`
- `web/apps/api/src/modules/membership/scheme.ts`
- `web/apps/web/app/(app)/txn/loan-issue/page.tsx`
- `web/apps/web/app/(app)/txn/loan-received/page.tsx`
- `web/apps/web/app/(app)/txn/scheme/page.tsx`
- `web/apps/api/test/dhrnLoanLifecycle.db.test.ts`
- `web/apps/api/test/schemeGoldAdjust.db.test.ts`

**Implementation sequence:**

1. Reconcile each desktop loan/dhiran/khata/opening/interest menu direction and book; preserve borrower, pledge-item, photo, valuation and custody identity.
2. Complete source-cited monthly/daily interest, inclusive-date/year basis, principal changes, backdates, blank/zero/manual override and reversal behavior.
3. Implement full enrollment/member/nominee/terms and installment history with tender identities; distinguish scheme from points/loyalty.
4. Join arrears/prepayment/bonus/maturity/gold-money adjustment/refund/invoice redemption and canceled invoice release with atomic available-balance control.
5. Prove the same operations against migrated open loans and partially paid schemes, using historical terms rather than silently applying current defaults.

**Required verification, in addition to the universal matrix:**

- Month ends, leap day, same-day receipt, partial principal and explicit zero interest match independent vectors.
- Pledge -> disbursement -> interest/principal -> closure/release preserves item custody and receipts.
- Enroll -> split installments -> mature -> partial redemption -> invoice return/cancel reconciles money/fine and member history.
- Concurrent redemption, duplicate payment, source receipt deletion after adjustment and over-refund are rejected correctly.
- Passbook, loan ledger, scheme commission/balance and accountant reports match full saved state across branches/years.

**Close only when:** Every loan/scheme mode and normal/exception continuation has real operator, desktop, calculation, custody and report acceptance.

**Evidence:** retain an `X24` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X25 — Complete scoped document binding and actual child output

**Status:** open. **Parents:** P10-01, P10-05, P10-06. **Start after:** X05, X07.

**Current finding:** Order scope and actual child/image binding are implemented for five explicit templates. Historical image provenance, all other report contracts, physical output and full-product acceptance remain open. Round 5 adds versioned generic/Design/repair images, source-book readers and guarded shared clients; read document22 for verification and exact remaining descendants.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/reports/reportBind.ts`
- `web/apps/api/src/modules/sales/orderDoc.ts`
- `web/apps/api/src/routes/txn.ts`
- `web/apps/api/test/reportBind.test.ts`
- `web/apps/api/test/reportRender.db.test.ts`
- `unified/src/csharp/DataCareNext/MS_PRINT.cs`

**Implementation sequence:**

1. Replace inference-only primary-table detection with explicit template/mode bindings containing required header/detail/child datasets, joins, parameters and formats. Preserve explicit unsupported errors.
2. Read actual IDTL children keyed to their exact parent; do not synthesize child aliases from a parent detail row. Handle template subreports/groups/formulas according to extracted and runtime evidence.
3. Correct order document location/year scope and audit all direct document renderers, not just /reports/render.
4. Match selection/preview/print/cancel, original/duplicate/triplicate, default focus, book/branch formats, headers/footers, images, signatures, QR/barcodes and reprint history.
5. Preserve data and authorization through PDF/CSV/XLSX and report-to-voucher drill-down. Keep business fields and totals exact; visual tolerances apply only to rasterization.

**Required verification, in addition to the universal matrix:**

- Two children with distinct values print as two correct child records, with no parent-value substitution or duplication.
- Same-number vouchers in two locations/years produce independent header/detail/child/party results.
- Unknown or ambiguous templates refuse; they cannot render sales as a fallback.
- One-line, long Unicode description, many-line/multi-page, missing image, return/negative and large-number documents match desktop data/layout.
- Copy labels, preview versus physical print, default printer/template and restricted-role direct render/export behavior meet the contract.

**Close only when:** Each supported document renders correct scoped data including children and has independent semantic, visual and required physical print evidence.

**Evidence:** retain an `X25` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X26 — Close the complete report and mode universe

**Status:** open. **Parents:** P10-02, P10-03, P10-04, P10-07. **Start after:** X01, X06, X25.

**Current finding:** Report endpoints increased, but the required current desktop-report comparison artifact is absent.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `parity-plan-2026-09-10/evidence/report-register.json`
- `web/apps/api/src/modules/reports/reportAuthorization.ts`
- `web/apps/api/src/modules/reports/reportFilters.ts`
- `web/apps/api/src/modules/reports`
- `web/apps/web/app/(app)/reports/[report]/page.tsx`

**Implementation sequence:**

1. Map all report screens, launcher parameters, direct routes, supplied Crystal files and absent references to explicit required report/mode IDs. Reuse newly implemented report families after contract verification.
2. Extract formulas, parameters, grouping/sort/subreport/suppression/running-total behavior and dynamic template selection; resolve missing artifacts through X32.
3. Complete financial/accounting/GST/outstanding/interest/aging/valuation modes and stock/WIP/lot/order/customer/scheme/tour/graph/audit specialists, with all applicable filters.
4. Define blank/all/single/multiple/invalid/unsupported filter semantics and enforce them consistently on direct routes and exports.
5. Produce report-comparison evidence per expected mode, fixture and candidate with rows/columns/totals, semantic differences, PDFs/images and operator acceptance; feed exact-set gate X34.

**Required verification, in addition to the universal matrix:**

- All required report IDs return a result, including valid empty datasets; missing/skipped/duplicated reports fail.
- Different party/group/location/year/metals/valuation filters select the independently expected rows and totals.
- Transactions from X12–X24 reconcile to daybook, stock, outstanding, financial and specialist reports.
- View/print/export permissions and drill-back preserve original scope and filter context.
- Removing one mandatory report from an otherwise all-pass result must fail certification.

**Close only when:** Every required report/mode is independently compared and approved; endpoint count and web-only layout baselines cannot substitute.

**Evidence:** retain an `X26` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X27 — Complete correction and bulk utility reference closure

**Status:** open. **Parents:** P11-01. **Start after:** X05, X06, X08.

**Current finding:** Data export/reset/repair work exists, but every reference-changing utility requires a complete ownership graph.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/utilities`
- `web/apps/api/src/modules/vouchers`
- `web/apps/web/app/(app)/utilities/data-repair/page.tsx`
- `web/apps/web/app/(app)/utilities/data-export/page.tsx`
- `web/apps/web/app/(app)/utilities/estimate-reset/page.tsx`
- `web/apps/api/test/correctionWorkflow.db.test.ts`

**Implementation sequence:**

1. Trace desktop user-request correction separately from ordinary allowed edits/deletes; preserve requested action, review/authority, reason and history where required.
2. Build reference graphs for renumber, cross-book transfer, refresh, reset, balance transfer, import/export and year-end; include detail/child, UPI, ledger, stock, tax, allocations, images and historical sources.
3. Implement preview, authorized execution, progress, cancellation/interruption semantics and deterministic before/after reconciliation.
4. Apply CUR_DAY_POSTING full/from-date stock-refresh behavior from source; avoid a guessed date restriction.
5. Keep scope-limited changes atomic and repeat-safe; revalidate all reports and source-link readers affected by key changes.

**Required verification, in addition to the universal matrix:**

- Preview equals actual touched keys/rows/effects on the frozen fixture.
- Two companies/years sharing keys remain unaffected outside the selected operation.
- Interrupt midway, retry, encounter collision/locked period/dependency: no partial reference rewrite remains.
- Repeated reset/refresh cannot duplicate effects; missing required source data fails instead of empty success.
- Related records remain discoverable and printable after renumber/transfer/correction.

**Close only when:** Every required utility finishes its supported business operation with complete reference integrity, recovery and audit evidence.

**Evidence:** retain an `X27` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X28 — Validate devices and real provider state machines

**Status:** open. **Parents:** P11-02, P11-03. **Start after:** X09, X15.

**Current finding:** CR-14: fake integrations and interface tests do not establish shop-device or provider capability; no web Olocker implementation was found in the reviewed source search.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/integrations`
- `web/apps/api/src/modules/einvoice`
- `web/apps/api/src/modules/integrations/messaging.ts`
- `web/apps/api/test/scaleProtocol.test.ts`
- `unified/src/csharp/DataCareNext/OlockerService.cs`
- `unified/src/csharp/DataCareNext/TR_SALE.cs`

**Implementation sequence:**

1. Inventory required OS/browser/scale/scanner/camera/A4/thermal/tag/cheque printer combinations and protocols from actual shops; document installation/pairing/permissions and local bridge responsibility.
2. Implement stable/tare/unit/precision handling, scanner terminators/focus/duplicates, image capture/ownership and printer-copy/media behavior using existing adapters where valid.
3. Trace saved/reopened invoice Olocker action and its fields/status/print or policy effects; implement any confirmed missing capability with explicit saved-document linkage.
4. Verify official current GSP/messaging/rate/provider documentation during implementation, record versions, and distinguish historical compatibility from accepted current requirements.
5. Persist submission/attempt/provider identities and pending/status/retry/cancel states; handle provider success followed by local persistence failure without duplicate external effects. Use authorized sandbox/test destinations for integration checks.

**Required verification, in addition to the universal matrix:**

- Real scale readings, disconnect/reconnect, unstable weight, unit conversion and scanner bursts enter the correct form values.
- Actual supported printers produce readable labels/receipts/A4/cheques with correct copies and dimensions.
- Provider timeout after acceptance is resolved through status and stable request identity; retry does not fabricate another success.
- Missing credentials, rejected payload, cancel, stale rate and background retry surface actionable states.
- Fake IDs/results can never appear as live certification; device/provider evidence names actual tested versions and configuration.

**Close only when:** All required physical/provider workflows have real test evidence and production-ready state handling. Missing devices/credentials remain explicit acceptance dependencies.

**Evidence:** retain an `X28` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X29 — Finish role-specific navigation, lifecycle jobs and audit

**Status:** open. **Parents:** P11-04, P11-05. **Start after:** X01, X05, X09.

**Current finding:** Route catalogs exist, but per-role end workflows and desktop startup/timer ownership require closure.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/rbac/formCatalog.ts`
- `web/apps/api/src/modules/rbac/routePolicy.ts`
- `web/apps/web/lib/nav.ts`
- `web/apps/web/components/Shell.tsx`
- `unified/src/csharp/DataCareNext.My/MyApplication.cs`
- `unified/src/csharp/DataCareNext/MDI_FORM.cs`

**Implementation sequence:**

1. Reconcile menu/mode authority to list/view/add/edit/delete/print/export/provider/utility actions, including documents and images reached from another form.
2. Verify tenant isolation with non-owner runtime DB roles and company/location/year/form authority through real API requests; navigation visibility alone is not evidence.
3. Trace login/load/shutdown, saved preferences, daily-rate/reminders, timers, Module_Schm.bgWorker and async callers; assign server versus browser responsibility explicitly.
4. Implement job ownership, schedule/timezone, deduplication, retry/credential failure and visible job status so multiple tabs cannot repeat a business action.
5. Add operator-oriented help/search and recovery prompts; audit actor/time/reason/reference before and after corrections without exposing unnecessary private data in diagnostics.

**Required verification, in addition to the universal matrix:**

- Cashier, accountant, stock clerk, manufacturing, salesperson and read-only roles can finish permitted journeys and cannot directly invoke denied actions.
- Denied operations leave no business side effects or leaked cross-scope document/image data.
- Two tabs and two worker instances start the same scheduled action: one accepted business effect.
- Restart, delayed job, credential error and local-date boundary preserve schedule/status correctness.
- Fresh-user onboarding finds every required allowed mode and retains only the correct user/device/form preferences.

**Close only when:** Every action and lifecycle job has measured ownership, role/scope enforcement and discoverable operator behavior across supported contexts.

**Evidence:** retain an `X29` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X30 — Implement complete migration and continued historical business

**Status:** open. **Parents:** P12-01, P12-02, P12-03. **Start after:** X01, X05, X06, X32.

**Current finding:** Production loading remains contained; table counts alone do not establish usable migrated workflows.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/integration/cutover.mjs`
- `web/apps/api/integration/parity-import-masters.mjs`
- `web/apps/api/src/modules/ops/backupManifest.ts`
- `web/docs/runbooks/migration.md`
- `web/packages/core/containment.mjs`

**Implementation sequence:**

1. Inventory every business/shared/auxiliary DB, image/template/file source, schema/type/collation/key/ownership rule and required sequence; assign migrate/rebuild/archive dispositions without omitting unsupported active features.
2. Implement read-only extraction to validated staging and a restartable scoped shadow loader with dependency order and technical ID mappings. Never substitute tenant-wide replacement for company/year scope.
3. Validate exact expected table/key/field sets, null/blank/zero and binary hashes; distinguish absent input from explicitly empty table.
4. Run two representative business histories through two clean shadow loads with reconciliation of money/fine/stock/outstanding/WIP/schemes/loans/photos/templates.
5. Continue business through UI: print historic vouchers, return imported sale, pay imported bill, consume remaining tag/lot/order, redeem scheme, close loan and reverse the new dependent action. Preserve historical rules and current effective rules separately.

**Required verification, in addition to the universal matrix:**

- Two companies and years sharing identifiers load without cross-scope replacement.
- Missing/corrupt rows, orphan references, partial extraction, loader restart and duplicate replay have explicit failing/recoverable outcomes.
- Second clean load reproduces exact key/value/hash and sequence state.
- Imported partial documents can be completed and reversed without desktop or SQL workaround.
- Every difference is reconciled by business effect and reviewed; production load containment is evaluated only after the full gate evidence.

**Close only when:** Complete scoped repeatable migration and active historic continuations are independently reconciled and business accepted before production loading is released.

**Evidence:** retain an `X30` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X31 — Certify restore, deployment and continuity topology

**Status:** open. **Parents:** P12-04, P12-05. **Start after:** X03, X09, X30.

**Current finding:** Logical restore is contained and Docker health is not a tested production recovery or offline-service result.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/apps/api/src/modules/ops/backup.ts`
- `web/apps/api/src/modules/ops/restoreVerification.ts`
- `web/scripts/restore-drill.mjs`
- `web/deploy/docker-compose.prod.yml`
- `web/DEPLOY.md`
- `web/packages/core/containment.mjs`

**Implementation sequence:**

1. Reconcile actual deployed API/web/schema/image identities, migrations, TLS/proxy, roles/pools, background services, backup/object storage and configured local/LAN/cloud topology.
2. Back up DB, attachments, templates, configuration and sequence state; identify protected credentials/keys required for recovery without writing them into plan evidence.
3. Restore physical and logical company backups into separate targets and run real business continuations; verify another company's data is untouched.
4. Measure agreed RPO/RTO, load/soak, connection exhaustion, restart, planned outage, failed migration and rollback; include observability and actionable runbooks.
5. Retain logical-restore containment until its engineering plus controlled deployment/drill and explicit release requirements are satisfied. Keep drill evidence separate from authorization to restore a real customer target.

**Required verification, in addition to the universal matrix:**

- Incomplete/corrupt backup refuses safely; valid restore reproduces exact hashes/counts/keys/balances and sequences.
- Interrupted single-company restore does not alter another company and leaves a recoverable state.
- Recovered target sells/settles/prints/reports with the same configuration and attachment availability.
- Internet/LAN/device/server failure behavior matches X09 service commitments; reconnect does not duplicate work.
- Rolling/backward-compatible migration and switchback preserve accepted writes; alerts detect stale backups and failed outbox/provider attempts.

**Close only when:** Production-like deployment and timed recovery/outage acceptance are proven for the selected topology, with explicit controlled release of contained recovery operations.

**Evidence:** retain an `X31` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X32 — Resolve editions, companion functions and absent artifacts

**Status:** open. **Parents:** P13-01, P13-02, P13-03. **Start after:** X01.

**Current finding:** Edition filenames and delta counts are inventoried; unique business behavior and unresolved runtime artifacts are not closed.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `parity-plan-2026-09-10/evidence/edition-delta.json`
- `parity-plan-2026-09-10/evidence/supporting-source-register.json`
- `parity-plan-2026-09-10/evidence/report-register.json`
- `unified/src/csharp/DataCareNext`

**Implementation sequence:**

1. Identify exact supported primary/NextDm executable versions and configurations; use hashes and runtime menu/caller evidence rather than filenames to decide their relationship.
2. Review the 123 changed shared files, primary-only files and UAE forms for unique data/rule/report/operation behavior; attach new leaf tasks to their domain parents.
3. Inspect NextEmp/NextImage and installer/dependency assets for employee/image/report/device functions consumed by the primary product.
4. Resolve the 20 absent report references, resource/ActiveX controls, dynamic branches and eight support units with actual desktop observation where needed.
5. Keep unresolved and untested behaviors required by default. Record source-proven duplicate/dead artifacts with caller/configuration proof; a pilot exclusion cannot silently shrink the full product.

**Required verification, in addition to the universal matrix:**

- Every unique reachable edition/country/companion behavior has a web path and test contract or remains explicitly open.
- Two differing binaries cannot share one passing certificate without a reviewed semantic equivalence map.
- Missing template/control dependencies prevent the related requirement from closing.
- Unexercised behavior in a sparse dataset is never called dead solely due to zero rows.
- New variant discovery expands expected requirement/case sets and invalidates affected acceptance.

**Close only when:** The full intended product/version universe has no unresolved reachable behavior or required artifact, and all unique requirements feed domain acceptance.

**Evidence:** retain an `X32` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X33 — Execute full journeys, business UAT and transition acceptance

**Status:** open. **Parents:** P14-01, P14-03, P14-04, P14-05. **Start after:** X03, X06, X12, X13, X14, X15, X16, X17, X18, X19, X20, X21, X22, X23, X24, X25, X26, X27, X28, X29, X30, X31, X32.

**Current finding:** All-product business and production acceptance are unestablished; isolated passing tests cannot replace this phase.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `parity-plan-2026-09-10/03-verification-and-release.md`
- `web/docs/PARITY-WINDOWS-PROCEDURE.md`
- `web/docs/MODULE-VERIFICATION-CATALOGUE.md`

**Implementation sequence:**

1. Expand the 128 scenario anchors and universal form matrix across all applicable contracts/settings/roles/books; freeze expected IDs before running. These anchors are a minimum, not the final test count.
2. Run the complete real-browser journeys listed below with independent DB and desktop/document/report results; include imported histories and every normal/error/reversal transition.
3. Ask experienced retail/wholesale/accounting/manufacturing/stock/scheme/loan operators to complete realistic work without scripted click guidance; measure errors, task time, keystrokes, lookup success, print usability and recovery.
4. Resolve defects and accepted deliberate behavior differences with requirement links; rerun affected descendants/cross-module journeys after changes.
5. Prepare timed cutover/rollback rehearsal and candidate-specific go/no-go. At separately authorized rollout, reconcile daily closures during the agreed observation window, account for new web writes if rollback is required, and obtain business handover acceptance.

**Required verification, in addition to the universal matrix:**

- Every required journey has a complete pass or a named blocking issue; no skipped/empty/missing journey is counted.
- Operators complete normal and exception business without mandatory desktop fallback or manual database work.
- Multiple business configurations meet correctness and agreed throughput requirements.
- Cutover rehearsal reconciles opening/closing money, fine, stock, outstanding, provider state and attachments.
- Rollback handles accepted new web transactions explicitly; stabilization evidence covers all intended deployed configurations.

**Close only when:** Every required business journey and production transition has independent technical and role-based business acceptance for the actual candidate. A successful pilot certifies only its declared subset.

**Evidence:** retain an `X33` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

### X34 — Enforce exact-set certification and one current progress record

**Status:** open. **Parents:** P00-05, P14-02, P14-06. **Start after:** X01, X02, X04.

**Current finding:** CR-12/13: nested workflow location, incomplete leaf-set enforcement and candidate provenance remain gaps despite the existing gate framework.

**Read/reuse these existing paths** (relative to `imodule-extracted/`):

- `web/.github/workflows/ci.yml`
- `web/.github/workflows/release-certification.yml`
- `web/scripts/release-certify.mjs`
- `web/apps/api/src/modules/ops/releaseCertification.ts`
- `web/scripts/check-completion-register.mjs`
- `web/apps/api/test/releaseCertification.test.ts`
- `web/apps/api/test/kernelConformance.test.ts`

**Implementation sequence:**

1. Place/adapt application CI and release workflows under the actual repository-root .github/workflows, preserving correct web working directories and package lock/cache paths. Verify the remote required checks really execute.
2. Before running certification, verify checked-out commit, relevant clean-tree status, dependency/schema/template hashes and running image/build digests; reject a supplied SHA that does not identify the tested tree.
3. Freeze requirement/case/report/device/integration/migration/UAT sets and hash them; require exact ID equality, valid statuses, nonzero expected assertions, complete tables/fields and current evidence for each member.
4. Add explicit real-browser, report-layout/physical device, provider, migration-continuation, recovery/outage and business acceptance evidence to the controlling release contract; the current 17 gate declarations are only a starting point.
5. Implement dependency-based evidence invalidation and actual CI artifact retrieval. A secret containing a local path is not an uploaded report.
6. Keep implementation/engineering/desktop/business/production stages separate in the register, 07 backlog and handoff. Review raised bypass ceilings as debt, not as proof of newly correct behavior; full-product release cannot accept dead-in-one-dataset as an exclusion.

**Required verification, in addition to the universal matrix:**

- A one-report all-pass file fails when the required set has more reports; missing/duplicate/unexpected case IDs fail.
- Zero executed tests, skipped DB/browser suite, synthetic desktop data and baseline rewrites fail release.
- Dirty or mismatched source, image, schema, lock or template identity and stale evidence fail before certification.
- Changing shared rounding/posting/settings/binder code invalidates every linked affected result.
- All original 83 packages and every new descendant must be accepted; a completed task heading or 198 declared routes cannot close them.
- Remote CI evidence retrieval and failing negative controls are retained with the candidate; missing devices/UAT cannot be replaced by mocked checks.

**Close only when:** One auditable current record reports true stage counts; release rejects all missing, stale or incomplete full-product obligations. No 100% claim while any mandatory path is partial, contained or unverified.

**Evidence:** retain an `X34` manifest linking all six evidence types in the common evidence contract; record remaining descendants rather than marking a partial card complete.

