# X13 primary incoming Return calculation: independent implementation review

Date: 2026-09-11. Reviewer: `design_components`; implementation owner: `report_children`.

This review covers the pure primary `TR_SALE_RTN.MSG_PR` row reducer in `web/packages/core/src/saleReturnIncoming.ts`, the new decimal-valued helpers in `money.ts`, and their tests. It covers the source path immediately before `MSG_PR_TOT_FILL()` and `BILL_TOTAL()` at desktop lines 5157–5158. It does not authorize or verify a saved numeric write, stock admission, financial posting, full source pickup, UI calculation integration, or complete X13 parity.

The separate [contract review](x13-calculation-contract-independent-review.md), [eight width expectations](x13-calculation-width-independentvectors.json), [original 35 expectations](independentexpectedvectors.json), and [original-assembly IL excerpts](x13-calculation-il-review-excerpts.txt) preceded this implementation and remain unchanged. The independent tests consume byte-identical copies of those expectation files from the core test fixtures and assert their pinned hashes.

## Review method and result

The reviewer read the complete primary `MSG_PR_LeaveCell` and `CommPassTotal_Pr` source, inspected original-assembly IL to resolve the ambiguous single-index grid expressions, checked the reducer branch order, and wrote a separate `packages/core/test/saleReturnIncoming.review.test.ts`. The 33 independent cases include all eight additional width vectors and cases not limited to copying the implementation's arithmetic. No database or browser was started for this review.

The source-driven row arithmetic and branch order are consistent within the documented mathematical decimal policy. Two concrete defects were found during the implementation review cycle and corrected by the implementation owner: malformed leave context previously threw instead of returning a recoverable rejection, and a sign-bit comparison incorrectly blanked a formatted negative zero. Their historical evidence is retained below. The result is a bounded pure-kernel review, with the integration and desktop-execution limits listed at the end.

## Checked source behavior

References below are to `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs`, the primary form, not the separate UAE or outgoing grid.

| Source range | Independently checked implementation behavior |
| --- | --- |
| 4592–4664 | Leave guards precede text commit and parsing; header row, clearing, hidden editor, and zero active-column width preserve the exact prior state and journal. Text-only columns copy their original string without calculation. Numeric columns use the source 0/2/3-decimal group. Column 1 remains an explicitly unsupported admission operation. |
| 4869–4881 | Ghat percentage uses the old visible net before the gross-change branch refreshes net. Clearing other weight to zero with unchanged gross does not invent a refresh absent from the source condition. |
| 4883–4916 | Separate net, touch, and west comparison caches control Fine. Zero combined touch/west applies the source fallback. Untouched cache text and hidden fields remain preserved unless the source branch writes them. |
| 4918–4940 and original IL `CommPassTotal_Pr` IL_065f–IL_0667 | The `F` metal basis uses actual configured column-18 width. Visible/hidden Fine, stale/zero Fine, and ghat-only commits produce the independently specified eight outcomes. Width is not inferred from Fine's numeric value or browser layout. |
| 4941–4958 | Metal calculation preserves the literal basis-plus-pieces nonzero guard, including cancellation. Item rate zero retains the cached/manual metal amount; it does not clear it. P/1/K/default rate bases remain distinct. |
| 4960–5024 | Percentage, labour-rate, and tax caches are separate. A changed labour rate of zero clears labour amount. Forward, generated, and manual-total inverse labour calculations use their own source conditions and rounding. Unknown labour types use gross in the forward/generation/manual branches. |
| 5026–5048 | Tag labour uses the source configured labour precision, independently of the incoming labour amount's whole-unit rounding. The tag and incoming amounts are not collapsed into one value. |
| 5050–5074 | MRP, discount, tax, and ordinary totals retain their source order, including the source's unusual MRP/discount assignments and final-tax overwrite behavior. |
| 5075–5115 | Manual total compares the original editor text, not merely its rounded grid cell. Even when that original value equals the computed total, the percentage update outside the residual-difference guard still runs. The compact labour cache assignment remains distinct from an ordinary two-decimal cache assignment. |
| 5080 | Strict numeric less-than-zero controls blanking after residual formatting. Signed zero is numerically zero and does not take the blanking branch. |
| 5118–5155 | Final tax inversion uses gross for K, while other K inversion branches use net plus ghat and different multipliers. Unknown labour type has no invented tax inverse. Tax cache equality and MRP affect the final net assignment. |
| 5157–5158 | The reducer stops before the form's row/document aggregate callbacks and reports `aggregateRequired`; it does not claim aggregate execution. |

The original IL also proves `MSG_PR_LeaveCell` uses `get_ColWidth(activeColumn)` at IL_0038. `MSG_PR_CLEAR` initializes column 18 width and can set configured hidden columns to zero. The earlier review documents the exact original executable and IL hashes. A future server policy resolver must supply these source configuration values; CSS visibility is not an acceptable substitute.

## Exact data, working precision, and journal review

The constructor accepts already projected visible strings and a separate exact raw SQL snapshot. In saved-cache mode, it seeds only the eight comparison caches 45/46/47/48/49/58/66/67 from their mapped visible cells. It does not implement raw database-to-desktop display projection. Raw strings, NULL, blank strings, timestamps, untouched hidden fields, and complete opaque row identity remain separate from calculated cells.

The independent tests retain raw `9999999999999999.99`, `1234567890123.456`, NULL values, blank strings, and a fractional timestamp through text commits and actual numeric events. Successful states share the immutable raw snapshot. Guarded/rejected events return the very same prior state and journal, with no aggregate request or partial calculation. Accepted journal events, their context, and calculation policy are cloned and frozen, so later caller mutation does not alter the replay record.

The reducer uses its own `Decimal.clone` with precision 100. The independent precision case deliberately changes the global Decimal configuration to precision 7 and round-down, then exercises the reducer and verifies the global settings remain unchanged. It checks the exact product:

```text
1234567890123.456 × 9876543210987.65
= 12193263113702166395214191.31840
source whole-unit rounding, then two-decimal cell text
= 12193263113702166395214191.00
```

The expectation was calculated independently with Python's decimal arithmetic at precision 100. All low integer digits survive; the test would expose a Number conversion or Decimal's default 20-significant-digit working precision. This product exceeds an ordinary saved amount column's range. Its successful pure calculation is proof of kernel precision, not permission to persist that amount or a statement of database range acceptance.

The decimal-valued helpers explicitly select half-up for cell text and half-even for source `Math.Round` sites. The tests separately exercise a negative half-up cell boundary and a configured half-even tag amount. Existing Number-returning helpers remain unchanged; the new reducer does not use them. Original Double representation, runtime/culture-specific `Val`/`Strings.Format` boundaries, and signed-zero display have not been measured by executing the desktop. Mathematical rounding results therefore remain qualified by this port policy.

## Defects found, correction, and retained history

1. The first independent run passed 32 cases: [x13-core-independent-tests-first.txt](x13-core-independent-tests-first.txt). Adding a malformed `context: null` case exposed an actual `TypeError` before the recoverable-error path: [x13-core-independent-tests-context.txt](x13-core-independent-tests-context.txt) records 32 passing and one failing test. The owner added a guard before property access. The owner also corrected event freezing to preserve the actual attempted null/non-object context rather than replacing null with an empty object. The independent 33rd case asserts the rejected diagnostic, exact prior state, and attempted-event equality; its expectation was not weakened.
2. A subsequent coordinated run passed 210 tests across 10 files, with build and strict test typing successful: [core-tests-verified.txt](core-tests-verified.txt), [core-build-verified.txt](core-build-verified.txt), and [core-test-types-verified.txt](core-test-types-verified.txt). This is an intermediate pass and was superseded by the following source correction.
3. The implementation owner's final review found that Decimal `isNegative()` includes signed zero. Desktop line 5080 compares the formatted amount numerically with zero. The reviewer independently confirmed that `.lt(0)` is the correct predicate. The owner added a 72nd implementation test: original manual total `99.999` against metal `100.00` produces a rounded zero residual that must remain a value, not blank. The test's `-0.00` spelling is explicitly a mathematical formatting expectation, not a claim of measured desktop display.
4. [x13-core-independent-lint.txt](x13-core-independent-lint.txt) exited zero but reports that the core review file was ignored because no matching ESLint configuration was supplied. This review assigns it **no core lint coverage**. Type checking and executed tests provide the relevant verification here.

The final coordinated run after both fixes passed **10 core files / 211 tests / zero skips**, including **33 independent review tests**, **72 implementation tests**, and 106 existing core tests. [core-tests-final.txt](core-tests-final.txt) records the complete run. The core build exited zero ([core-build-final.txt](core-build-final.txt)); the owner confirmed strict TypeScript checking of both new test files exited zero ([core-test-types-final.txt](core-test-types-final.txt), an empty successful-output log). The [29-input snapshot](core-input-snapshot-final.json) and [post-run verification](core-input-verification-final.json) record no changed or added inputs. The reviewer independently rehashed all 29 captured inputs when finalizing this review and found every hash still matched. Historical logs and prior independent source artifacts remain unchanged.

## Remaining boundaries before any saved numeric UI integration

- Resolve and version actual company/book calculation settings and column widths. The policy object supplied to this kernel is not yet a trusted HTTP configuration resolver.
- Implement and verify complete source copy/master lookup wrappers. `calculateAfterCopy` consumes an already copied snapshot; it performs no lookup, source-version validation, field copy, tag admission, or child transfer. In particular, the original F1 vector is only a bounded post-copy calculator case. Desktop F1 also copies tag labour rate/amount and has separate cache/admission rules. Labour-code Enter can fill blank tag labour code before calculating.
- Implement raw-to-visible saved projection without erasing the exact raw snapshot; constructor cache seeding alone does not reproduce all saved form formatting.
- Complete the row and bill aggregates, incoming/outgoing header mapping, child relationships, new return-owned stock instance creation, generated BAR companions, financial effects, and versioned transaction replay before enabling any numeric save. This review does not weaken the existing metadata-only write boundary.
- Bind a real operator event to complete row identity, original editor text, current source column/context, and an ordered journal. Failed/guarded kernel behavior is tested, but no UI draft/retry flow or writer replay uses it in this slice.
- The finite plain-decimal input grammar, maximum precision/result limits, explicit missing-policy rejection, and divide-by-zero containment are deliberate web behavior. They retain the prior draft instead of guessing permissive `Val` parsing or unmeasured desktop NaN/infinity behavior. Those limits are not evidence of exact desktop rejection behavior.
- Verify desktop executable/runtime and business acceptance for midpoint, binary-double, culture, signed-zero display, and exceptional arithmetic before calling those edge cases exact parity. Keep the separate outgoing grid, UAE variant, and source-help cancellation outside this primary reducer's claim.

## Final reviewed input and evidence hashes

SHA-256 hashes captured after final verification. Paths beginning `web/` or `unified/` are relative to the extracted project root; remaining names are files beside this review. This review is pinned externally by the scoped manifest to avoid a self-referential hash.

| Path | SHA-256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `web/packages/core/src/saleReturnIncoming.ts` | `bbc5df6568da23a75804866ab31c789b9be9850e79681d8193a82e1e3430c805` |
| `web/packages/core/src/money.ts` | `d6fbf799c56f4ed70e7b83006e22adeef4a23ac12f36d91abbf4b8deb0f19131` |
| `web/packages/core/src/index.ts` | `19bfd8bd214c746e4cc5b4d37ede26bf923a0e5dced6aff50a611b5eaccdb301` |
| `web/packages/core/test/saleReturnIncoming.review.test.ts` | `e0045153a2a5bb0b5fb2e61144ac825d4b58a2a2da9da67f06dd062825d30327` |
| `web/packages/core/test/saleReturnIncoming.test.ts` | `25418ca3d52fba42012bf250da7bae6dca73ddcefda06185284fc5bac8a5c6aa` |
| `web/packages/core/test/fixtures/saleReturnIncoming.independent.json` | `ad1184e6bb7f7256e42e85b5469ea3152404fba25566465389bc6a7ba4367527` |
| `web/packages/core/test/fixtures/saleReturnIncoming.widths.json` | `3c0bef2a5aa86fca83d8c0e98b56e36c553595f2b941a06642409ce7e631d309` |
| `x13-incoming-calculation-contract.md` | `3a60edd05ab8837cfffe24283c45e2a91a1421d1ba9cc771b22d9aba756fb5c0` |
| `independentexpectedvectors.json` | `ad1184e6bb7f7256e42e85b5469ea3152404fba25566465389bc6a7ba4367527` |
| `x13-calculation-contract-independent-review.md` | `e2a7c2704d0c7290d7007f1a6be2e33a99a7dbebabfcd3cff90d0f8323699835` |
| `x13-calculation-width-independentvectors.json` | `3c0bef2a5aa86fca83d8c0e98b56e36c553595f2b941a06642409ce7e631d309` |
| `x13-calculation-il-review-excerpts.txt` | `8c60e56122820e7fc18cb35aed07188f5016f185ed1d219f7661566facf09144` |
| `x13-core-independent-tests-first.txt` | `62f04ae7bb5d7a57ec083449013fe98050a34e900cc00dff92722a2de0f8dcb5` |
| `x13-core-independent-tests-context.txt` | `6327830576edb0827b61f18605e6f329866f124cca9e4f6790bb94f95d31898d` |
| `x13-core-independent-lint.txt` | `379874bba05bc850908fc6f889216d6e6c280ac90b28390ca42303485088582b` |
| `core-tests-verified.txt` | `5561e1f0a198ceb42faabf501f9cbb1c12596ae11207e9f2d4a1b13bf09477c1` |
| `core-build-verified.txt` | `79da90d454c83eb7b7c76d1548b439a13925b548ccc7911efbe41f4e31f94aa5` |
| `core-test-types-verified.txt` | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |
| `core-input-snapshot.json` | `d78b24b2efcce6feb64f5ed645e79b54d4e3acf07221400a96ad76c5f677e742` |
| `core-input-verification.json` | `76eac6e7d224ed244b03da945f9330f69423acb0f19d25d793939d972c04e41e` |
| `core-tests-final.txt` | `5eb0d19bdeba5a97111388626e2e6abb3fecfb6d6950893e981122ca5b756707` |
| `core-build-final.txt` | `79da90d454c83eb7b7c76d1548b439a13925b548ccc7911efbe41f4e31f94aa5` |
| `core-test-types-final.txt` | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |
| `core-input-snapshot-final.json` | `ea67acbe72a5eb0dabeabb635b91f0335553b782cd3bbc4f8b9a2bcc2c20fe39` |
| `core-input-verification-final.json` | `a202a4e5c0f5a26d3501c24870fbaab2a7836a12a8acc0a8d27fb1ecaa59deb7` |
