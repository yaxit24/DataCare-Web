# X13 pure aggregate: independent vectors and verification

This slice verifies a pure calculation prerequisite. It does not connect aggregate results to the current HTTP/UI replay, load a desktop form, resolve a ledger, admit an outgoing return, save numeric values, post money/stock, or close complete Return parity. Root owns `saleReturnIncomingAggregate.ts`; this reviewer owns the new test file, portable independent fixture and this evidence. Existing row, projection and money kernels were not changed by this work.

## Independently fixed expectations

`x13-aggregate-independent-vectors.json` and the portable `web/packages/core/test/fixtures/sale-return-incoming-aggregate.v1.json` are byte-identical, SHA256 `97001a2719f491e50c3b1b9d31c96a822b243b9edd69bcd8b767b79e6b3231b5`. The fixture was authored and frozen before inspecting or executing the new implementation. Only its proposed type declarations were read to align shapes. Expected arithmetic and strings were entered from primary source and the frozen round9 requirements/review. `author-aggregate-vectors.py` expands those literal expectations into complete shapes; it never imports a product module or evaluates its formulas, and refuses to overwrite the frozen output files. The test has a literal SHA assertion and uses only its package-local copy, so it does not depend on the extracted desktop folder at test runtime.

The fixture contains eight incoming fold cases, sixteen complete bill-state cases, and one full composite baseline with two explicit event prefixes. Each total observation has all 71 source columns; each bill matrix has all nine rows and six columns, including untouched names, codes and reference text. Header caches use canonical numeric strings after replacement and retain their previous exact text when unchanged. These caches are source Double variables, unlike the source grid's formatted text caches; the representation choice is documented rather than claimed as a desktop string property.

The expectations cover the primary source boundaries:

- `TR_SALE_RTN.cs:5162–5202`: all fourteen aggregate columns in order, formatting after every row addition, c0 preservation, clearing of other totals, hidden c42 inclusion, counter resets, fractional positive/small/negative pieces, blank-row versus no-row differences, exact large cents, and an UpDown skip that does not read malformed numeric cells.
- `TR_SALE_RTN.cs:16381–16458`: independently rounded legs, half-even explicit Math.Round, full-incoming versus payment-difference cache, manually retained tax and unchanged cache text, tax-code-only non-invalidation, saved-open rounding, tax rounding at 0 versus 2, both tender directions, negative/positive opening balances, outstanding before inactive-side clearing, zero-difference behavior, zero-label color retention and unavailable opening balance.
- `TR_SALE_RTN.cs:5157–5158` and `16398–16405`: J1 uses the already frozen complete row baseline from round9, changes Other Amount from 0 to 1 to 0, and checks every row cell/cache, aggregate cell, bill cell/cache and journal flag at each prefix. Incoming 111 gives tax 11.10 and payment total 122; the second prefix returns incoming to 110 but leaves tax 11 and total 121. A single final bill calculation would wrongly retain manual tax 7 and total 117.

The independent reviewer `/root/design_components` checked all eight fold and sixteen bill expectations plus both J1 prefixes directly against source arithmetic and found no mismatch. The later added large bill test was separately proposed and checked by that reviewer: whole incoming `99999999999999999999999999.00` less tender `99999999999999999999999998.00` leaves exact outstanding `1.00` and closing `1`, even with ambient Decimal precision set to 7. This tests the declared mathematical profile; it does not claim the desktop's binary Double retains 26 integer digits.

## Actual tests and boundaries

The final test file has **62 passing tests**. In addition to the frozen golden cases, it tests detached recursively frozen construction without a calculation; source-guard skips preserving the identical state; same-value numeric events; text-only events that journal without aggregating or billing; ordinal/identity invariants; malformed or sparse shapes; the 36-significant-digit result boundary; and rollback of the selected row and both journals when a later aggregate or tender parse fails. No test uses the new calculation function to generate its expected arithmetic.

The pure constructor only validates the declared structure; it is not a saved-row or ledger authority. A structurally valid state can contain a numeric cell that is not yet read. If a later calculated event reaches that cell and refuses it, the composed transition must return the original state without publishing its otherwise successful row update. An unavailable opening observation allows the independently computed bill matrix and caches to remain available, but closing amount and label are null and the previous color is retained. A zero balance is not invented.

The fixture's ledger example is explicitly **not executed**: saved raw clock `12:00:00.900000` maps to the primary source's second-precision cutoff `12:00:00`; all-book credits before the cutoff yield 17 in combined mode C or 10 in mode A, while the helper's separate less-than-or-equal closing query yields 37 in mode C. `DC_Main.cs:1463–1492` and Return lines 10106/10197/10226 establish that prerequisite. No database query or account-balance acceptance is credited by this core test. Root's new tax-policy prerequisite and future authoritative observation adapter are separate work.

The numerical boundary deliberately contains unmeasured Val prefixes, exponent/culture syntax, nonfinite values, excessive precision and non-ASCII whitespace/control characters. These are recoverable limits of the exact-decimal preview profile, not new claimed desktop business prohibitions. Financial/stock writers, saved-open outgoing callbacks, header/tender editor permissions and runtime/locale parity remain open.

## Verification stages, including failures

1. Initial focused runtime: 58 tests passed in 529ms, `core-aggregate-focused-first.txt`. The first strict test-file compiler failed because the local helper `event()` was annotated as the full event union even though it always returns `leaveCell`; spreading its context therefore produced an invalid type. The error is retained in `core-aggregate-test-types-first.txt`. Narrowing that test-helper return type fixed it. No product or golden expectation changed.
2. Formatted 58-test stage: runtime passed in 396ms and strict test-file compilation passed, recorded in `core-aggregate-focused-verified.txt` and `core-aggregate-test-types-verified.txt`. Eleven scoped inputs matched before/after in `core-aggregate-focused-inputs.json` and its verification. This is a historical stage; its index hash predates root's later tax export, and its test hash predates the additional case below. That older compiler command did not include noUncheckedIndexedAccess.
3. Approved 59-test precision stage: the one independently proposed large bill residual test passed with the other tests in 549ms. Strict test-file compilation with noUncheckedIndexedAccess also passed. Logs are `core-aggregate-focused-bill-precision.txt` and `core-aggregate-test-types-bill-precision.txt`. The golden fixture was unchanged. This stage is historical after the subsequently confirmed ASCII issue.
4. Final 62-test ASCII stage: another reviewer identified that JavaScript regex `$` can accept a terminal newline, and trim could silently remove it despite the declared ASCII-space input profile. Root added the explicit ASCII printable-character check before trimming/parsing. Exactly three new read-cell regressions were added: `12\n`, `12\r`, and `12\u2028`. Runtime passed all 62 in **434ms**, exit 0, in `core-aggregate-focused-ascii.txt`. Strict test-file compilation with noUncheckedIndexedAccess passed, exit 0, in `core-aggregate-test-types-ascii.txt`. Ten direct scoped inputs were captured before and verified unchanged afterward in `core-aggregate-ascii-inputs.json` and `core-aggregate-ascii-input-verification.json`.

The terminal-control defect was established by source/regex review, not by a claimed failed run of these three new cases before the fix. The frozen arithmetic fixture remained unchanged throughout. Root's independent implementation review also prompted the earlier c0 ordinal-invariant and result-domain corrections; their corrected paths are covered by this test file, but this note does not invent a pre-fix test failure for them.

Reproduction commands for the final scoped stage:

```sh
pnpm --filter @datacare/core test -- test/saleReturnIncomingAggregate.test.ts
pnpm --filter @datacare/core exec tsc --noEmit --strict --noUncheckedIndexedAccess --target ES2022 --module NodeNext --moduleResolution NodeNext --esModuleInterop --skipLibCheck test/saleReturnIncomingAggregate.test.ts
```

The current scoped test imports the aggregate source module directly, which imports the frozen row and money modules. The final scoped capture deliberately omits `index.ts`; root owns its tax export integration and the complete workspace capture/build/full-suite checks. No full workspace, API, browser, lint or desktop runtime result is inferred from this focused evidence. Root's later comprehensive logs can be pinned separately without relabeling any stage above.

Final owned test SHA256: `316f9d7e2187d252bfa9e7fa754869b79ea227daccfd23a608d022d274d56d12`.

Aggregate product source at this verified stage SHA256: `c356eacb0a8f3a509997eb10a56a8bb269edf3791af3909fde1326c222f8d3ed`.

All fixture expectations, source references and verification artifacts are pinned by the accompanying `x13-aggregate-independent-tests-run.json`. This note claims only the bounded pure prerequisite and its observed tests; it changes no plan percentage or complete-module acceptance.
