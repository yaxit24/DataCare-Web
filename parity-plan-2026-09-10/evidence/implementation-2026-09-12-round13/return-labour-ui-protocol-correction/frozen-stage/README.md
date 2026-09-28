# Labour state wire-scope correction

The real browser diagnostic returned HTTP 200 but the new reader compared the response's exact four-field public scope with the saved metadata scope including tenantId. Document versions were equal. The comparison therefore refused a valid response before opening controls. This is an actual UI protocol defect, not a null-prototype incompatibility: pageContext and the legacy bill reader both accept null prototypes.

The sole runtime change projects coCode, lcCode, coYear and coBook from the saved document into the expected identity. Response scope remains exact: additional response fields, missing owned fields and any owned-value mismatch still refuse. API, raw data, token semantics, body/query shapes and legacy readers are unchanged. The helper baseline includes root's prior type-predicate correction. All runtime bytes outside this one change match the captured baseline.

The new wire fixture is a byte-identical copy of test-results/parity-real-stack-round13-labour-diagnostic/labour-state-diagnostic.json. It contains only the disposable synthetic saved document and response. It is diagnostic input, not independently calculated numerical expectations. Ten new declared regression cases pin it, prove successful real-shape acceptance without mutation, retain the old four-field saved-scope case, reject an extra response tenantId, reject each of four field mismatches and a missing field, and verify that all query paths and both POST builders exclude tenant authority. Existing 65 helper cases and independent arithmetic fixtures are untouched.

No test, compiler, API, database or browser execution was performed for this staged correction. The new test was formatted with the active repository's explicit Prettier configuration. Root must integrate the one-file runtime patch plus new test/fixture, run focused tests and repeat the real browser before claiming acceptance. Original failed browser stages and frozen UI/browser-review stages remain unchanged.

Focused command from web: pnpm --filter @datacare/web exec vitest run test/salesReturnLabourReplay.test.ts test/salesReturnLabourReplay.wire.test.ts
