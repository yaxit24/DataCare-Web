# Literal case index and authorship limits

The23 cases were expanded from hand-entered amounts using only Python deepcopy/string-map construction. Existing dependency code was read to establish interfaces and compare source branch names. No new composition implementation existed, was inspected or executed; no existing calculator, database, browser, test suite or compiler generated these outcomes. Shape counts and exact rejected-state equality were checked using plain JSON only. These are prospective test expectations, not passed tests.

| Cases | Independent expectation |
| --- | --- |
| L01 | Incoming rate1→2, net10/metal100: labour20, incoming120, billtax12, settlement132. |
| L02 | Same code still invokes calculation; numeric-equal caches retain their exact `110.0000`/`10.0` text and manual billtax7. |
| L03–L04 | Tag percent changes tag labour only; same tag/category04 without destination still invokes callbacks. |
| L05–L06 | Fixed labour5 becomes0 when cleared rate differs cache1; it survives with cache0/generationfalse. Bill105+10.50 rounds115.50 to116. |
| L07 | Category06 forces K;10×1001/1000→10.01 rounds labour to10. |
| L08 | Ghat10% sets loss1; default net+loss metal110, while unchanged fine comparison caches retain fine10. |
| L09 | UpDown retains complete prior totals/counters but still invokes bill calculation on their incoming110. |
| L10 | Explicit mathematical outgoing200 vs incoming120 yields received80 and clears inactive payment cells. This is no outgoing-runtime admission claim. |
| L11 | Following L01 with original rate1 yields incoming110, tax11 and settlement121. Collapsing the two events would incorrectly retain manual7/117. |
| L12 | Exact opaque SR42 identity selects grid ordinal2; other row remains byte-equivalent. Aggregate134, billtax13.40, settlement147. |
| L13 | Master2.005 formats to2.01, then row labour20.10 rounds whole to20. Distinct presentation and arithmetic rounding phases. |
| R01–R02/R08 | Stale, missing or ambiguous master observation returns pre-copy state and no journal append. |
| R03–R04 | Missing Fine width or post-copy inverse zero denominator restores copied code/amount/blank/caches and both journals. |
| R05 | Bad sibling c42 fails the fold after selected-row success: every original row and header state survives. |
| R06–R07 | Bad bill tax or outgoing input fails after row/fold success: no copied state escapes. |
| R09–R10 | Unknown selected identity or unsupported UpDown context cannot select a positional fallback or publish the copy. |

All success expectations contain full aggregate state and journals; all refusal expectations contain the entire exact prior state. Runtime getter/prototype/cycle/mutation tests remain listed separately because JSON cannot represent them. Dependency diagnostic codes are semantic expected origins, allowing the final composition DTO to wrap them without changing the expected calculation or rollback facts. A profile expansion or arithmetic correction must be additive and retain these frozen bytes.
