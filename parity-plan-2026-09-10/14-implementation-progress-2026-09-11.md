# Implementation progress and next executable work — 11 September 2026

This records implementation following the completion review. Read it together with [the 34 execution cards](12-execution-addendum.md), [the structured backlog](13-execution-backlog.json), and [the original implementation plan](02-implementation-plan.md). The earlier review is a dated snapshot; its source hashes and findings are retained. This implementation does not close a complete card, original package, or menu acceptance.

## Implemented slices

| Card | Implemented behavior | Acceptance still required |
| --- | --- | --- |
| X03 | Reproducible isolated PostgreSQL 16 environment on localhost:55433, migrations, separate migration owner and runtime app_user, forced tenant RLS, and a real browser/API/DB journey runner | Expand real browser journeys to every required mode, role, failure and transition; independent desktop replay and release environment qualification |
| X11 | DESIGN_IDTL parent/child persistence and editing; stable serials; preserved null/blank/zero/date/image state; source-backed ITM_STYLE migration; versioned atomic replacement/deletion; separate create/edit/delete rights; saved Design Book image upload/read/delete | Desktop-triggered calculations and grid configuration, downstream order/manufacturing transfer, legacy image migration and branch index reconciliation, desktop/UAT comparisons |
| X14 | Configured Tour Order books, full authenticated scope, actual create/reopen/edit/delete browser lifecycle, independent component rows, preserved imported serials, stale/concurrent edit handling, ghat-aware labour base, Tour-owned configuration/print permissions | Full order delivery/conversion/settlement/cancellation depth, remaining calculation bases and rounding, downstream images, independent desktop acceptance |
| X05 / X25 | Order document tenant/company/location/year/book/number selection, active book-family validation, consistent database snapshots, real date formatting and Tour-specific title/rights | Complete order layouts/components, independent financial/footer comparison, other direct document readers and physical prints |
| X25 | Explicit report binding contracts; real scoped SL/PR/KR child records; parent bands rendered once, child bands independently; coherent snapshots; orphan/duplicate refusal | Remaining template families, Crystal formula/group/suppression/subreport behavior and physical/desktop comparisons |

The report registry now identifies 23 registered template contracts. The former inferred set contained 102 names; 79 of those now return an explicit unsupported reason because their required semantics are incomplete. **Neither 23/102 nor 23/254 is a report-parity percentage.** The exact name-by-name disposition is in [the report template inventory](../web/docs/parity-evidence/X25-report-binding-scope-2026-09-11.json). Other application report endpoints remain separate acceptance obligations.

Unsupported imported Tour Orders with mixed tender/allocation/old-metal row sets are protected from edits that would otherwise erase rows. Protection is a temporary limitation, not implementation of those workflows. All original acceptance remains open, including the already documented contained tag workflows and E CrntNote/lot manufacturing gaps.

## Repeatable verification environment

From `imodule-extracted/web`:

```bash
# Create or reuse only the isolated test Compose project. Passwords are generated in ignored .env.parity-test.
node scripts/parity-test-env.mjs

# Build the real browser/API pair with the correct compiled Next rewrite.
API_ORIGIN=http://127.0.0.1:4410 pnpm build

# Full API suite, including real database and authorization cases; no skip escape hatch.
pnpm test:parity:api

# No API interception: real login, company/year selection, Design Book and Tour Order lifecycle.
pnpm test:parity:browser

pnpm --filter @datacare/web test
pnpm --filter @datacare/core test
pnpm typecheck
```

The browser runner binds API port 4410 and Next port 4411 to loopback, refuses a database other than localhost:55433 with app_user, seeds only the synthetic `browser-parity` tenant, and cleans up that tenant and the temporary application processes. It records screenshots and `result.json` under `web/test-results/parity-real-stack/`. The normal application on ports 4000/4001 and its database on 5433 are separate. Run this runner sequentially with the full DB suite, because restore/role fixtures may lock shared tables.

The new schema migration is `20260911010000_design_detail_style`. It has been applied to the disposable test database. Deploy it through the normal migration process before running this code against another database. Do not silently alter the existing application's data or claim that its running containers contain this working tree.

The [implementation checkpoint](15-implementation-checkpoint.json) records the final source hashes, actual test outcomes and retained limitations. Earlier focused test manifests remain historical; later edits must be covered by the aggregate run. A successful build or these two real journeys does not establish full-product parity.

## Verification completed for this checkpoint

| Check | Result | Evidence |
| --- | --- | --- |
| Full API suite with actual DB tests enabled | 204 files, 1,577 tests passed; no skipped files/tests reported | [Final API log](evidence/implementation-2026-09-11/api-full-final.txt) |
| Frontend unit/contract tests | 17 files, 75 tests passed | [Frontend log](evidence/implementation-2026-09-11/web-tests.txt) |
| Shared core tests | 3 files, 17 tests passed | [Core log](evidence/implementation-2026-09-11/core-tests.txt) |
| Real browser/API/DB journeys | Design Book and Tour Order passed with zero mocked requests, including final legacy-client loss protection | [Browser result](evidence/implementation-2026-09-11/browser/result.json) |
| Existing mocked browser regression suite | Passed after correcting the settings fixture to the real response shape; keyboard/grid/lifecycle assertions retained | [Smoke log](evidence/implementation-2026-09-11/browser-smoke.txt) |
| Production build | All 7 targets passed; API rebuilt after final API-only guard | [Build](evidence/implementation-2026-09-11/build.txt), [API rebuild](evidence/implementation-2026-09-11/api-rebuild.txt) |
| Lint and application type checks | Passed | [Lint/type log](evidence/implementation-2026-09-11/lint-and-types.txt) |
| Strict test type check | Passed | [Test type log](evidence/implementation-2026-09-11/test-types.txt) |
| Completion register and document references | Passed; menu states remain implemented-unverified | [Register](evidence/implementation-2026-09-11/register.txt), [References](evidence/implementation-2026-09-11/document-references.txt) |
| Kernel adoption CLI | Failed: 127 helpers versus ceiling 108; existing debt retained | [Kernel audit](evidence/implementation-2026-09-11/kernel-audit.txt) |
| Operator-depth gate | Failed: 101 unreachable fields versus ceiling 96; existing debt retained | [Depth gate](evidence/implementation-2026-09-11/depth-gate.txt) |

Browser screenshots show [Design Book components](evidence/implementation-2026-09-11/browser/design-book-components.png), [the loaded Tour Order](evidence/implementation-2026-09-11/browser/tour-order-loaded.png), and [its independent component rows](evidence/implementation-2026-09-11/browser/tour-order-components.png). These are synthetic engineering fixtures; they do not replace independent desktop or business acceptance.

## Exact continuation instructions

### X04 / X05 — Resolve existing audit failures without inflating progress

The current kernel CLI reports 127 module-local rounding helpers against its ceiling of 108. The pre-implementation reviewed hashes prove that 125 findings are in unchanged files; the remaining two helpers already exist in Git HEAD. The kernel test uses a different scope and ceiling (128 including a core helper), so its passing result does not clear the CLI gate. Reconcile the scopes and prove each financial rounding replacement from source vectors; retain the existing ceilings. Some counted helpers convert report geometry rather than money, which requires an evidence-backed classification rather than a blanket exclusion.

The depth audit reports 101 unreachable API fields against ceiling 96; the earlier review already recorded 101. Trace each field to its source: some are genuinely missing operator inputs, while some are intentionally injected by the server or derived from saved transactions. Define exact, tested classifications before changing the detector.

The richness scanner's current 71.5% surface figure is not a completion measurement. It misses declarative columns imported from `.ts` files and assumes `label` is the first object property. Design Book now renders 30 parent and 16 component descriptors from `designBookDraft.ts`; Tour Order imports 37 specification and 30 header descriptors from `tourOrderForm.ts`. Add scanner fixtures covering those real render paths and unrelated/nonrendered declarations. Do not add their counts blindly or rewrite the baseline to claim parity. Both red audit gates remain release blockers.

### X03 — Expand the real-stack harness

1. Reuse `apps/web/test/parity.real-stack.mjs` for real runtime startup and tenant isolation. Do not change it to intercept `/api` requests.
2. Add fixtures and exported journey functions per mode. Use nondefault book codes and repeated voucher numbers across branch/year/company; cover restricted users as well as administrators.
3. Require browser create → close/reopen → unchanged edit → changed edit → stale edit refusal → print → delete/reverse, where the desktop supports each transition. Assert independent database business rows and downstream reports, not only response values.
4. Keep contained transitions explicitly unavailable until their prerequisites and tests pass. Add failed-save rollback, cross-period refusal and retry/no-duplicate cases. Implement all other X03 requirements before closing it.

### X11 — Complete design specification semantics

1. Read [the X11 source contract and remaining requirements](../web/docs/parity-evidence/X11-design-components-2026-09-11.md). Continue from the new parent/component DTO; do not flatten children or regenerate serials on reorder.
2. Trace `MS_DESIGN_BOOK` change/leave handlers for customer versus karigar weights, conversion, labour, rate basis and parent-derived totals. Define source vectors before adding calculations. Preserve distinct blank, null and explicit zero behavior.
3. Implement configured columns/defaults/keyboard triggers; compare visible and hidden field state on reopen. Avoid turning a display blank into a persisted null by accident.
4. Trace selection into orders/manufacturing. Transfer the exact selected parent and all component fields with stable identifiers. Add actual browser transfer plus resulting transaction/report assertions.
5. Reconcile old `DESIGN_IMG_ID`, legacy image files and branch-specific mobile `TAG_IMAGE_DATA` indexes. The new image bytes are company-scoped (`LC_CODE=''`); this is an explicit web storage choice requiring migration/continuation evidence. Newly saved designs use their composite desktop image key. Deleting a design book retains its image bytes, matching the separately managed desktop images; do not claim image deletion from book deletion.
6. Retain Design Book-specific rights and mandatory loaded versions on PUT/DELETE. Test a creator cannot overwrite through POST, and foreign/unsaved image keys cannot be read or attached.

### X14 — Complete the order workflow, not just its editor

1. Reuse `salesOrder.ts`, `tourOrderForm.ts`, and the real Tour journey. Preserve accepted rich header fields, all independent children and noncontiguous `SR_NO`/`ISR_NO` values.
2. Implement source-driven labour P/G/K bases, ghat configuration, percentage branches and desktop rounding. The current correction handles whether ghat belongs in the per-net-weight base; it does not close all desktop calculation branches.
3. Build the actual cash/cheque/card/UPI/old-gold/old-silver/scheme/rate-cut settlement and ledger contracts. Use independent expected write sets for `SL_ORD_*`, tender/account/stock/adjustment tables and all reversals. Remove an edit containment only after lossless hydration, write-set and unchanged-edit tests for that row set exist.
4. Implement partial delivery, conversion to sale/manufacturing, residual quantities/amounts, linked-document navigation, cancellation/refund and duplicate-retry behavior. Verify all affected stock/account/report totals before and after each transition.
5. Keep print/configuration on Tour-owned permissions. Compare the complete document to desktop, including component specifications, calculations, image use, terms and physical output. The corrected scope/title/date are only part of this work.

### X25 — Extend exact report contracts

1. Select the next named template from the exact inventory; read its extracted spec plus the caller's source dataset and parameter construction.
2. Add an explicit binding contract with full keys, alias ownership, parent and child bands, formulas, group/order/filter behavior, summaries and empty/null rules. A matching filename or table name is insufficient.
3. Use two distinct children, a zero-child parent, repeated voucher identities and different item-master/component values. Assert no parent fan-out and no duplicate totals. Include malformed/orphan/duplicate cases and a concurrent edit snapshot test.
4. Add executable expected desktop text/numeric output and layout/physical-print evidence. Only then remove that template's unsupported disposition; keep the rest named and open.
5. Audit the other direct document readers for full scope and snapshot consistency. Do not assume fixing `orderData` fixes invoice/return/quotation readers.

## Current completion meaning

All 198 menu entries remain `implemented-unverified`; all 34 execution cards and 83 original packages remain open for their full acceptance. No whole-product implementation percentage is invented. This checkpoint advances specific functional slices and adds reproducible evidence; complete conversion still requires the remaining plan, desktop comparison, migration rehearsal, operational qualification and business acceptance.
