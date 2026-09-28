# Staged clock harness review

Read-only disposition: no confirmed weakening or source/fixture mismatch found. This review did not execute tests, compile source, query a database, or change repository files. The159 tests are planned coverage, not an execution result.

The harness pins the exact independent fixture bytes,139 total cases and the24 ready/83 unsupported/32 invalid-input distribution. Every literal case is passed to the adapter without deriving expected dates from its output. Ready and unsupported paths compare exact cutoff, all diagnostic code/sourceField pairs as a sorted complete multiset, nonblank diagnostic text, raw/provenance deep equality, detached containers, recursively frozen results and unchanged/unfrozen callers. Thus duplicate diagnostics also fail; this is not merely a subset assertion.

Missing versus SQL NULL is checked twice: strict raw equality and an explicit own-key comparison for each source field. Both missing, both NULL, mixed missing/NULL and two malformed fields retain independent expected diagnostics. A later caller repair test confirms the original unsupported observation stays missing/NULL and detached. The ready caller-mutation test changes date, clock and both provenance fields after the call without changing the captured result.

The calendar cases discriminate VCH_DATE's day from VCH_TIME's independently valid day; years0001/9999; ordinary and400-year leaps; invalid1900/2100 leap days; invalid unused timestamp dates; and fraction removal through23:59:59.999999 without overflow. The literal one-through-six fraction cases, exact raw comparison and offset/locale/space-separator refusals prevent accepting a generic timestamp parser in place of the named JSONB profile. Terminal newline/control cases address JavaScript end-anchor behavior.

Malformed-envelope vectors require invalid-input and observation:null. Their frozen expectation schema specifies the required error code rather than an exact prose/order or complete diagnostic array, so the harness's `toContain(expected.diagnosticCode)` follows the authored envelope contract. The exact complete diagnostic comparison applies to every inspectable ready/unsupported observation. Non-JSON cases independently assert that getters are not called, symbol/nonenumerable additions are not discarded, inherited custom-prototype fields are refused, cyclic envelopes do not throw and nonfinite raw values are not coerced. Frozen callers remain unchanged and detached output remains frozen.

The assertions do not establish original Windows Date/Format/culture equivalence, factual import-clock reliability, authenticated provenance, live session authority or available closing balance. Real JSONB serialization under DateStyle/TimeZone is a separate staged database test owned by the other agent. The relative `.js` import names the staged TypeScript module; root must change only its integration path when copying into the core test tree. Expected literals must remain unchanged.

Reviewed hashes:

- `/tmp/datacare-return-clock-round13-vectors/saved-sale-return-clock.v1.json`: `d360162bc731cb383e33146c29265586358413821fca0cf5d94c4bdf753cdd78`.
- `/tmp/datacare-return-clock-round13-vectors/savedSaleReturnClock.test.ts`: `7456860c45e955187f681b13713acd47eb43bb25ca162da258592d89a8c241cf`.
- `/tmp/datacare-return-clock-round13/savedSaleReturnClock.ts`: `6e943c3ab5512738c1db33da6c98e1db402eba2e7c8f9bdbc67534767ae94dec`.
- `/tmp/datacare-return-clock-round13/contract.md`: `9d8f19bd79768e4b4610de089a1237b4acb9777a7898e145bf5fe992e4300d6e`.
