# WP-01 parity containment implementation evidence

**Date:** 2026-08-29  
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`  
**Work package:** WP-01 — contain unsafe operations  
**Status:** implemented and validated in the current working tree; no commit created  
**Claim boundary:** this proves containment only. It does **not** prove desktop parity, posting correctness, migration correctness, or production readiness.

## 1. Objective and fail-closed rule

WP-01 prevents operator or CLI access to web mutations already shown to lose, invent, ambiguously identify, or incompletely migrate business state. Read-only diagnostics and inspection remain available where safe.

The authoritative policy is `web/packages/core/containment.mjs`, exported as `@datacare/core/containment` with declarations in `containment.d.mts`. It is consumed by the API, cutover CLI, and Next.js UI.

- Every reviewed operation is blocked by default.
- There is deliberately no environment-variable override.
- Re-enablement requires a reviewed policy code change tied to the rule's named exit evidence.
- The stable API response is HTTP 503 with code `PARITY_CONTAINMENT`, operation, reason, safe alternative, exit gate, `workPackage: "WP-01"`, and `retryable: false`.
- API checks execute after authentication/RBAC, but before request-to-service adaptation or Prisma access.

## 2. Contained operations

| Operation               | Current safe surface                                                        | Contained mutation                                      | Required exit evidence summary                                                                      |
| ----------------------- | --------------------------------------------------------------------------- | ------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| Logical restore         | JSON download remains available with non-DR warning                         | Restore is blocked                                      | Complete manifest, company isolation, atomic failure, count/key/hash/binary round trip              |
| Production cutover load | `--dry-run` remains available                                               | Load mode is blocked before source or target connection | Scope ownership manifest, completeness failures, two-company/two-year isolation, clean shadow loads |
| Tag Opening update      | New create, load/inspect, new/reset, and currently authorized delete remain | PUT/update and loaded detail/image editing are blocked  | Symmetric rich-field read/write and unchanged desktop differential                                  |
| Tag Transfer            | Tag/item lookup and form inspection remain                                  | Create and delete are blocked                           | Exact `VCH_SRNO`, full lifecycle, conservation, lock, reversal, and desktop diff                    |
| Tag Cancellation        | Tag lookup and form inspection remain                                       | Create and delete are blocked                           | Exact live identity, complete detail/sub-detail, lifecycle, lock, reversal, and desktop diff        |
| Tag Weight Difference   | Tag lookup and form inspection remain                                       | Create and delete are blocked                           | Full replacement/serial/image/Rojmel/karigar branch matrix and desktop diff                         |
| Tag Split               | Parent lookup and form inspection remain                                    | Create and delete are blocked                           | Atomic child serial/detail/image lineage, conservation, lifecycle, lock, reversal, and desktop diff |

## 3. API and CLI enforcement

`web/apps/api/src/routes/txn.ts` contains route-level guards for all ten exposed unsafe mutation endpoints:

1. `POST /backup/restore`
2. `PUT /stock/tag-opening/:vchNo`
3. `POST /stock/tag-transfer`
4. `DELETE /stock/tag-transfer/:vchNo`
5. `POST /stock/tag-cancel`
6. `DELETE /stock/tag-cancel/:vchNo`
7. `POST /stock/tag-weight-diff`
8. `DELETE /stock/tag-weight-diff/:vchNo`
9. `POST /stock/tag-split`
10. `DELETE /stock/tag-split/:vchNo`

`web/apps/api/integration/cutover.mjs` evaluates the same shared policy immediately after option parsing. Non-dry-run execution returns a failed machine-readable report before either connector is opened. `runCutover` remains exported only as a dependency-injected unit engine; repository search found no other production caller.

The normal `pnpm restore-drill` alias is also contained. `web/scripts/restore-drill.mjs` evaluates `logical-restore` and exits 1 before reading `DATABASE_URL`, environment-selected tenant values, or constructing `PrismaClient`. A runtime smoke invocation without database configuration returned the shared `PARITY_CONTAINMENT`/`logical-restore` problem and the expected non-zero status.

## 4. Operator-visible containment

`web/apps/web/components/ParityContainmentNotice.tsx` renders a shared accessible `role="alert"` notice with the reason, safe alternative, and exit gate.

Notices and guarded/disabled actions are wired into:

- `/backup`
- `/txn/tag-opening`
- `/txn/tag-transfer`
- `/txn/tag-split`
- `/txn/tag-cancel`
- `/txn/tag-weight-diff`

Loaded Tag Opening vouchers use the rendered `ParityContainmentFieldset` around the complete detail grid, extended fields, scale controls, row actions, and `EntityImagePanel`; date and book are disabled as well. Loaded image lookup now uses persisted `vchSrno` and falls back to row order only for unsaved new rows. Load, New, and currently authorized Delete controls remain outside the fieldset. The submit handler independently rejects a loaded update, so keyboard or synthetic submission cannot bypass the disabled button.

## 5. Automated evidence produced

### Focused tests

| Command/scope                                                                                                         | Result                                                          |
| --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------- |
| `pnpm --filter @datacare/core test -- test/containment.test.ts`                                                       | 1 file, 4 tests passed                                          |
| `ALLOW_SKIP_DB_TESTS=1 pnpm --filter @datacare/api test -- test/parityContainmentRoutes.test.ts test/cutover.test.ts` | 2 files, 7 tests passed                                         |
| `pnpm --filter @datacare/web test -- test/parityContainment.test.ts`                                                  | 1 file, 5 tests passed                                          |
| `ALLOW_SKIP_DB_TESTS=1 pnpm --filter @datacare/api test -- test/rateCut.test.ts`                                      | 1 file, 9 tests passed after stale fixture typing was corrected |

The route test covers all ten endpoints, asserts the shared problem body, uses a Prisma proxy that throws on any access, and proves no Prisma property was touched. Separate cases prove unauthenticated callers receive 401 before RBAC/containment and unauthorized callers receive 403 before containment details. The cutover test proves load mode opens neither connector and dry-run performs no target replacement. The core test verifies the direct restore-drill guard occurs before database configuration/client construction. The web test renders active and inactive containment fieldsets, verifies the disabled HTML state, and checks persisted image identity plus handler/control wiring. This is focused component/route evidence, not full target-browser or device UAT.

The API Vitest global setup reported that the configured database was unreachable. `ALLOW_SKIP_DB_TESTS=1` was therefore required to execute these selected database-independent tests. The selected files did run and pass; unrelated database-backed tests were not run, and this evidence does not claim posting or RLS proof.

### Type, format, and build validation

| Validation                                  | Result                                 |
| ------------------------------------------- | -------------------------------------- |
| Core source typecheck                       | Passed                                 |
| API source typecheck                        | Passed                                 |
| Web source typecheck                        | Passed                                 |
| Full API test/integration TypeScript check  | Passed                                 |
| Direct restore-drill containment smoke      | Passed; exit 1 before database setup   |
| Pinned Prettier check for all changed files | Passed                                 |
| Core production build                       | Passed                                 |
| API production build                        | Passed                                 |
| Next.js production build                    | Passed; all 102 static pages generated |

Next.js emitted the repository's existing warning that the Next.js ESLint plugin is not detected; compilation, lint/type validation, page generation, and build completion still succeeded.

## 6. Incidental validation repairs

The full API test TypeScript check initially exposed four pre-existing fixture errors unrelated to containment. They were corrected without changing production behavior:

- `billToBillDelete.db.test.ts`: made an intentional structural test cast explicit through `unknown`.
- `rateCut.test.ts`: added the now-required desktop book classification (`vchType: "RCUT"`, `bookName: "RATE CUT"`) to three ledger fixtures; all nine pure Rate Cut tests pass.

## 7. WP-01 exit decision

The WP-01 implementation criterion—negative mutation guards plus operator-visible notice—is satisfied by the evidence above. The operations remain contained. They must not be re-enabled until their individual policy exit gates have desktop-derived contracts, differential tests, concurrency/reversal proof, and signed evidence.

The next implementation work is WP-02: repair backup/restore, per-report authorization, Data Repair authority, and posting-account resolution. WP-03 release-gate containment can proceed independently in parallel.
