# X02: imported descriptor measurement, bounded round 2 change

This is an additive scanner correction. It does not change product fields, budgets, historical baseline values, acceptance states or any functional-parity percentage. X02 remains open. The independent route, writer and reader path checks specified in the execution card are still required.

## Problem and implemented scope

`project-memory/parity/richness_web.py` follows only `.tsx` component imports. Its object-column expression also expects `label` to be the first property. Consequently the imported `.ts` descriptors in `designBookDraft.ts` and `tourOrderForm.ts` are absent from that heuristic's declaration count. Simply concatenating all imported `.ts` files would incorrectly count unused registries and helper-only arrays.

The new `web/scripts/lib/ui-descriptors.mjs` uses the existing TypeScript parser to start from returned JSX. It follows a rendered descriptor map through local aliases, relative named/default imports and the supported factory return expressions. Object descriptors recognize `key` and `label` independent of property order; typed tuple arrays and array spreads are supported. Literal boolean selector arguments select their actual static branch. A supported `filter`/`flatMap` records candidate origins with a runtime-visibility condition. Identity-changing transforms remain unsupported rather than being credited as the original fields.

Pure imports, type-only imports, uncalled helper JSX, locally calculated JSX that is not returned and an explicit false JSX branch contribute no candidates. Every positive entry records source file, line, key, label, input/grid use, identity/access classification and conditional status. Unsupported consumers retain the consuming file/line/expression and the failed binding/expression explanation. These are static candidates; no dynamic visibility, route forwarding, writer, reader or persistence behaviour is certified.

`check-depth.mjs --audit` now emits a separate `descriptorSurface` stage. `node scripts/measure-ui-descriptors.mjs` emits the complete per-page field origins and unsupported consumers. The old richness, gap, settings and dead-cell detectors and all their ratchet comparisons remain intact. The new candidates must not be added to old totals because those sets overlap and have not been fully reconciled.

## Before and after

| Measure | Before this scanner change | After this scanner change |
| --- | --- | --- |
| Legacy operator surface heuristic | 3653 | 3653 |
| Legacy grid-column heuristic | 2159 | 2159 |
| API input-field heuristic | 2370 | 2370 |
| Globally mentioned API fields | 2269 | 2269 |
| API fields absent from frontend corpus | 101 | 101 |
| Legacy dead-cell columns checked | 606 | 606 |
| Legacy dead-cell findings | 4 wholesale issue fields | Same 4 findings; detector still fails |
| Descriptor stage | Not present | 589 distinct candidates across 19 of 123 discovered pages |
| Descriptor grid / input candidates | Not present | 48 / 589; these sets overlap |
| Descriptor identity / conditional candidates | Not present | 3 / 132; classifications can overlap |
| Unsupported descriptor consumers | Not measured separately | 103, with file-level explanations |

All pre-existing fields of the complete depth audit JSON are equal before and after, not just the rows above. The before depth JSON was saved before editing. The before dead-cell command was observed in the tool output; the retained after log reproduces that observation. `check-dead-cells.mjs`, the wholesale page and `rateCut.ts` remain byte-identical to their checkpoint-15 versions, and were not edited by this task. The source/evidence manifest records this comparison.

Design Book contributes 48 candidates from `designBookDraft.ts`: 32 parent columns, including two transient calculation fields, plus 16 child columns. Three are identities. All 48 are conditional because configured visibility is evaluated at runtime. Header and input maps referring to the same descriptor contribute a single definition identity.

Tour Order contributes 68 input candidates from `tourOrderForm.ts`: 31 header descriptors and 37 parent-row descriptors. The imported arrays are followed because the page actually renders their maps. Generic component props that cannot be resolved are explicitly unsupported; they are not used to invent more Tour candidates.

## Known wholesale nested-mapping finding remains visible

The legacy dead-cell detector still reports `issueYear`, `issueBook`, `issueNo` and `issueSrno`, because it searches the writer for direct `.issue*` dereferences. The real mapping is:

1. `web/apps/web/app/(app)/txn/wholesale-sale/page.tsx:262–268` constructs `sourceRef` from the four input fields as `yrcd`, `dbcd`, `no` and `srno`; line 295 sends `isuRef: sourceRef`.
2. `web/apps/api/src/routes/txn.ts:705–712` forwards the line array through `rateCutInput`; the configured rate-cut routes call this adapter at 6407/6413.
3. `web/apps/api/src/modules/sales/rateCut.ts:774,826–829` reads `l.isuRef` and writes `ISU_YRCD`, `ISU_DBCD`, `ISU_NO` and `ISU_SRNO`. The received-line counterpart is at 907,958–962. Reader SQL includes the columns at 1067–1068 and 1087–1088.

The fixture includes a preservation tripwire for this known source mapping. This is not the X02-required semantic route tracer: a future test must remove `isuRef` at the matching adapter and independently remove a reader field, then prove that the corresponding path fails while same-named fields on another route do not satisfy it. The four false direct-dereference alerts were not deleted, waived or used to lower a budget here. Any valid dead/unreachable gaps remain visible.

## Verification and remaining scope

Run `node --test scripts/test/ui-descriptors.test.mjs`: 12 tests pass. They cover imported aliases, unused/type-only imports, uncalled helpers, dropped render maps, object label ordering, identities, configured factory selectors, conditional/empty filters, false and unknown JSX branches, unresolved factories, identity-changing transforms, read-only controls, same-name isolation and the real Design/Tour origins. Targeted ESLint and Prettier checks pass. These tests use tiny temporary source fixtures; they do not launch the application or database.

Run `node scripts/measure-ui-descriptors.mjs` for complete descriptor origins, `node scripts/check-depth.mjs --audit` for the additive stage and legacy metrics, and `node scripts/check-dead-cells.mjs` to reproduce the still-failing four findings. `python3 project-memory/parity/gap_manifest.py` from the extracted root produces the separate gap manifest.

Remaining X02 work includes general component-prop propagation, re-exported/indirect factories, unsupported dynamic expressions, runtime mode/visibility evidence, page-to-route identity, transformed payload and nested writer mapping, reader/reopen continuity, dynamic book/report modes, settings/recalculation wrappers and independent universe closure. The old global word-presence metric cannot prove that a named API field is supplied by the correct screen. The new stage deliberately makes no replacement percentage or full-card acceptance claim.
