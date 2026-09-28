# X13 Round10 independent core review

**Disposition: no remaining confirmed defect in the reviewed, bounded pure prerequisites after the corrections below.** This is independent source/test review of the incoming aggregate, stateful bill callback, event composition and company-open tax precision resolver. It grants no numeric-write, API/UI, ledger-resolution, outgoing/admission or desktop-runtime acceptance.

The reviewer read primary `TR_SALE_RTN.cs:5162–5202`, `16381–16458`, the saved-open/header paths, the frozen Round9 requirements/review, both new implementations and their complete tests. The literal aggregate fixture was independently checked against source arithmetic, without generating expected values by executing the implementation. No product/test files were edited and no DB, browser, build or test process was run by this reviewer; execution results below are the named owners’ recorded checks.

## Findings and verified corrections

1. **An applied text-only c0 event could publish inconsistent row identity.** The frozen row reducer accepts c0 as text. The first composition implementation returned an applied row with visible c0=`99` and ordinal1 because it validated rows only through the numeric aggregate path. Root added `validateRows(rows)` after every applied row event, before any callback or journal publication. The final test requires atomic rejection, unchanged visible ordinal and empty prior journals.
2. **A formatted result could exceed its next consumer’s significant-digit limit.** A valid36-digit integer plus cents could initially leave the standalone fold as an apparently successful value that later numeric reads refused. Root aligned formatted/canonical result limits with the declared readable profile: at most36 significant digits, absolute value below1e36, and at most18 decimal places for canonical values. The regression checks refusal with the identical previous totals. This is explicit containment, not a claim that all desktop floating values are supported.
3. **JavaScript `$` admitted a terminal line terminator.** The tax owner identified the canonical-regex issue; independent review confirmed the same issue in the aggregate numeric reader. Tax now refuses changed-by-trim spelling before validation; aggregate explicitly refuses non-ASCII-printable characters before its ASCII-space decimal grammar. Final tests cover newline/carriage-return/separator cases. Ordinary ASCII spaces remain supported by the aggregate reader. The existing row reducer was preserved.

Root also tightened aggregate plain-record/own-column structural checks. The reviewer verified the revised boundary rejects incomplete/custom-prototype observations rather than publishing a detached state missing required columns. No broader JavaScript-object or security-scan claim is made.

## Source behavior and precision reviewed

- The14-column fold retains source row order and formats after each addition; it preserves c0, clears other totals, labels c5, and resets both counters only on the active path. Empty rows and one blank grid row differ. UpDown retains the previous totals/counters without numeric reads.
- Each genuinely calculated row event performs row → whole incoming fold → bill before the next event. Text-only events journal without callbacks; source guards retain the same complete prior state. Positive active ordinals and opaque row identities must agree. The J1 prefix fixture distinguishes settlement122 then121 from an incorrect final-only117.
- Bill calculation rounds each leg first, compares tax caches numerically, preserves matching manual tax/cache text, computes both outstanding sides before inactive-side clearing, and derives closing from post-clear values. Zero closing retains prior color. Unknown opening gives unavailable closing with a reason while preserving independently known bill results.
- Local Decimal precision100 and re-entry into that constructor after the shared half-even primitive prevent global precision from affecting later arithmetic. There is no monetary Number roundtrip. The independent large fold and added large bill test preserve cents and a one-unit residual at ambient precision7. Closing amount remains exact within the profile; only its label is formatted.
- Aggregate or bill failure discards the transient selected-row change and both journals. Full matrix/row/raw snapshots, attempted events and ordered policy/context history are preserved or detached/frozen as appropriate.
- Tax policy admits only the two exact SQL-text/NULL aliases. Canonical Int32 lexical bounds precede fallback or override, with no Number coercion. SQL NULL follows Fnv0; values above5 become2; finalY can resolve a valid negative integer but cannot rescue earlier overflow/malformed text. Raw NULL, zero and blank flag remain distinct. Missing/duplicate physical settings rows and duplicate JSON keys remain the future reader/transport’s responsibility.

## Verification attribution and retained history

Final owner checks passed **62 aggregate tests** and **89 tax-policy tests**, with strict test-file compilation. Root subsequently recorded **415 core tests /13 files**, strict compilation of both new test files including noUncheckedIndexedAccess/isolatedModules, and production build7/7 on unchanged captured inputs. Broader root checks belong to the checkpoint evidence, not additional module acceptance.

The earlier58- and59-test aggregate stages, the test-only discriminated-union typing failure, the initial tax typing/build failure, and the superseded production build remain retained in the owners’ manifests. The final62 revision includes the control-character correction; frozen golden fixture bytes remain unchanged. No failed stage is relabeled as final success.

The reviewed prospective API contract correctly separates session MsDataType from book posting type, saved/load/open/event phases, cross-book second-precision ledger cutoff, and unknown opening. A separate source addendum corrects the MsAcBal call to10197 and function end1487 and qualifies amount-only results against its additional gold/silver conversions. These are future requirements, not implemented server observations.

Original Double/Val/Strings.Format culture, binary midpoint/negative-zero display, historical FLOAT precision, ActiveX event behavior and business acceptance remain unmeasured. Existing row reducer, money helpers and saved projection were not changed by this slice.

## Pinned reviewed inputs and evidence

Paths are relative to `Desktop/imodule-extracted`. Hashes identify final inspected bytes; owner manifests contain the detailed commands, logs, historical stages and before/after input checks.

| Input | SHA-256 |
| --- | --- |
| `web/packages/core/src/saleReturnIncomingAggregate.ts` | `c356eacb0a8f3a509997eb10a56a8bb269edf3791af3909fde1326c222f8d3ed` |
| `web/packages/core/test/saleReturnIncomingAggregate.test.ts` | `316f9d7e2187d252bfa9e7fa754869b79ea227daccfd23a608d022d274d56d12` |
| `web/packages/core/src/saleReturnBillTaxPolicy.ts` | `4e12c8b129cbdc168bafb01cb40a7a723e1db2bfb57af57a3c73f9099b809622` |
| `web/packages/core/test/saleReturnBillTaxPolicy.test.ts` | `1ec8f36a00953de378e6d851e04eda7c305e384ff00c0c6ee58902c95122fdea` |
| `web/packages/core/test/fixtures/sale-return-incoming-aggregate.v1.json` | `97001a2719f491e50c3b1b9d31c96a822b243b9edd69bcd8b767b79e6b3231b5` |
| `web/packages/core/src/saleReturnIncoming.ts` | `bbc5df6568da23a75804866ab31c789b9be9850e79681d8193a82e1e3430c805` |
| `web/packages/core/src/money.ts` | `d6fbf799c56f4ed70e7b83006e22adeef4a23ac12f36d91abbf4b8deb0f19131` |
| `web/packages/core/src/saleReturnIncomingProjection.ts` | `3f3b9ac1e937f1adfbf535283cd66701438b791a24ed691d641c573f63e9d96e` |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/x13-aggregate-independent-tests-run.json` | `0d44228d510f6be71de65904c3b975dee13e8b836aff9743e67754c45fda9843` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/x13-bill-tax-policy-implementation.run.json` | `e8c2ae1a980d12410cb6920c8602a5f8821efe40c2739dfd020835eefb986ef2` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/x13-aggregate-trusted-observation-source-addendum.md` | `9f41889ef665c3a0934412c619921bf5788b853269967ea81e8ca267f09347ae` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/core-aggregate-focused-ascii.txt` | `bb427f5265fff4b71b455533eca2de0e63943ab4e912e5e453644e6972792fac` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/bill-tax-policy-unit-first.txt` | `319038067348207636b094725260282a6205d72b2b4cfdd0bb27bf8f0bad8d08` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/core-tests-verified.run.json` | `b4a4dbd6d37c1ca774c7589e613b7b2ea778990b228d26684742b4e6f602c212` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/core-test-types.run.json` | `eda42a8f6c14ccc9382879ef52cdcc4856e75e58066ecc1894a11ff0f0078704` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/build-final.run.json` | `6ca94ce9fb173345d275f24ae79952e55eda9975de7e173afe8a8ed9547cb511` |
